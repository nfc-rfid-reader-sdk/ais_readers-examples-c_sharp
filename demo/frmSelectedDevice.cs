using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using HND_AIS = System.UIntPtr;

namespace DL_AIS_Readers
{
    public partial class frmSelectedDevice : Form
    {
#if THREAD_PROTECT
        private Mutex mut = new Mutex();
#endif
        private HND_AIS hnd_device;
        private DEVICE_TYPES device_type;
        private Thread instanceOfThreadMainLoop;
        private DeviceMainLoop instanceOfDeviceMainLoop;
        private UInt32 device_id;
        private bool LogInProgress = false;
        private bool IsDeviceDisconnected = false;
        private string AdminPassword = "1111";
        private List<string> blacklist_items;
        private List<string> whitelist_items;

        public delegate void ChildFormClosedEventHandler(object sender, CustomClosingEventArgs e);
        public event ChildFormClosedEventHandler ChildFormClosedEvent;
        public delegate void PercentUpdatedEventHandler(Int32 percent);
        public PercentUpdatedEventHandler PercentUpdated;
        public delegate void LogFinishedEventHandler();
        public LogFinishedEventHandler LogFinished;
        public delegate void DeviceDisconnectedEventHandler();
        public DeviceDisconnectedEventHandler DeviceDisconnected;
        public delegate void RTEHappenedEventHandler(UInt32 num_of_rte);
        public RTEHappenedEventHandler RTEHappened;
        public delegate void LibFaultStatusEventHandler(DL_STATUS status);
        public LibFaultStatusEventHandler LibFaultStatus;
        public delegate void MainLoopFaultStatusEventHandler(DL_STATUS status);
        public MainLoopFaultStatusEventHandler MainLoopFaultStatus;


        public frmSelectedDevice(HND_AIS param_hnd_device, 
            DEVICE_TYPES param_device_type,
            UInt32 param_device_id)
        {
            hnd_device = param_hnd_device;
            device_type = param_device_type;
            device_id = param_device_id;
            InitializeComponent();
        }

        private void frmSelectedDevice_Load(object sender, EventArgs e)
        {
            TimeZoneInfo localZone = TimeZoneInfo.Local;

            gbAdminPassword.Text += "\"" + AdminPassword + "\"";
            SetupGridLog(gridLog);
            SetupGridLog(gridRTE);
            this.Text = "Device Type: " + device_type + "     Device Id: " + device_id;
            lbDeviceId.Text = "Device handle: " + hnd_device;

            DisplayLocalDateTimeNow();

            PercentUpdated = new PercentUpdatedEventHandler(ProgressEvent);
            LogFinished = new LogFinishedEventHandler(LogFinishedEvent);
            DeviceDisconnected = new DeviceDisconnectedEventHandler(DeviceDisconnectedEvent);
            RTEHappened = new RTEHappenedEventHandler(RTEHappenedEvent);
            LibFaultStatus = new LibFaultStatusEventHandler(LibFaultStatusEvent);
            MainLoopFaultStatus = new MainLoopFaultStatusEventHandler(MainLoopFaultStatusEvent);

#if THREAD_PROTECT
            instanceOfDeviceMainLoop = new DeviceMainLoop(hnd_device, this, mut);
#else
            instanceOfDeviceMainLoop = new DeviceMainLoop(hnd_device, this);
#endif
            instanceOfThreadMainLoop = new Thread(new ThreadStart(instanceOfDeviceMainLoop.run));
            instanceOfThreadMainLoop.Start();

            blacklist_items = new List<string>();
            lstBlacklist.DataSource = blacklist_items;
            gbUIDWhitelist.Enabled = device_type == DEVICE_TYPES.DL_AIS_BASE_HD_XRCA;

            if (gbUIDWhitelist.Enabled)
            {
                whitelist_items = new List<string>();
                lstWhitelist.DataSource = whitelist_items;
            }
        }

        private void SetupGridLog(DataGridView gridView)
        {
            gridView.ColumnCount = 8;

            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            gridView.Columns[0].Name = "Idx";
            gridView.Columns[1].Name = "Action";
            gridView.Columns[2].Name = "Reader Id";
            gridView.Columns[3].Name = "Card Id";
            gridView.Columns[4].Name = "System Id";
            gridView.Columns[5].Name = "Date";
            gridView.Columns[6].Name = "Time";
            gridView.Columns[7].Name = "NFC Uid";
        }

        private void frmSelectedDevice_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (instanceOfDeviceMainLoop != null)
            {
                instanceOfDeviceMainLoop.stop();
                if (instanceOfThreadMainLoop != null)
                {
                    if (!IsDeviceDisconnected)
                    {
                        instanceOfThreadMainLoop.Join();
                    }
                    instanceOfThreadMainLoop = null;
                }
                instanceOfDeviceMainLoop = null;
            }
            ChildFormClosedEvent(sender, new CustomClosingEventArgs(hnd_device.ToUInt64()));
        }

        private void setAdminPassword(string password)
        {
            AdminPassword = password;
            gbAdminPassword.Text = "Admin Password: \"" + AdminPassword + "\"";
        }

        private void btnSetAdminPassword_Click(object sender, EventArgs e)
        {
            setAdminPassword(tbAdminPassword.Text);
            tbAdminPassword.Text = "";
            Helper.AppendText(tbLog, "Admin Password has been set to: \"" + AdminPassword + "\".\n", Color.Black);
            Helper.SetStatusOk(statusLabel);
        }

        private void btnSubmitPassword_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            string status_msg;

            if (tbNewPasswd.Text.Equals(tbRepeatPasswd.Text))
            {
                try
                {
                    status = ais_readers.AIS_ChangePassword(hnd_device, tbOldPasswd.Text, tbNewPasswd.Text); ;

                    if (status != DL_STATUS.DL_OK)
                    {
                        status_msg = ais_readers.status2str(status);
                        throw new Exception("AIS status: " + status_msg);
                    }
                    else
                    {
                        setAdminPassword(tbNewPasswd.Text);
                        tbOldPasswd.Text = "";
                        tbNewPasswd.Text = "";
                        tbRepeatPasswd.Text = "";
                        Helper.AppendText(tbLog, "Password changed successfully.\n", Color.Green);
                        Helper.SetStatusOk(statusLabel);
                    }
                }
                catch (Exception exception)
                {
                    Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                    Helper.SetStatusErr(statusLabel);
                }
            }
            else
            {
                Helper.AppendText(tbLog, "You must repeat new password in \"Repeat new password\" text box.\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            string status_msg, ftdi_serial;
            UInt32 hardware_type, firmware_version;
            UInt32 battery_status = 0, battery_available_percent = 0;
            DateTime dt;

            tbInfo.Clear();
            try
            {
                status = ais_readers.AIS_GetVersion(
                    hnd_device, 
                    out hardware_type,
                    out firmware_version);

                if (status != DL_STATUS.DL_OK)
                {
                    status_msg = ais_readers.status2str(status);
                    throw new Exception("AIS status: " + status_msg);
                }

                status = ais_readers.AIS_GetFTDISerial(hnd_device, out ftdi_serial);
                if (status != DL_STATUS.DL_OK)
                {
                    status_msg = ais_readers.status2str(status);
                    throw new Exception("AIS status: " + status_msg);
                }

                if (device_type == DEVICE_TYPES.DL_AIS_20)
                {
                    status = ais_readers.AIS_BatteryGetInfo(hnd_device,
                                                            out battery_status,
                                                            out battery_available_percent);
                    if (status != DL_STATUS.DL_OK)
                    {
                        status_msg = ais_readers.status2str(status);
                        throw new Exception("AIS status: " + status_msg);
                    }
                }

                Int32 timezone, dst_bias;
                bool is_dst;

                DateTime utc = DateTime.UtcNow;
                status = ais_readers.AIS_GetTime(hnd_device, out dt, out timezone, out is_dst, out dst_bias);

                // Test vectors: ---------------------------------
                //is_dst = false;
                //timezone = 9;
                //dst_bias = 9;
                // -----------------------------------------------

                TimeSpan udc_diff = dt - utc;
                if (status != DL_STATUS.DL_OK)
                {
                    status_msg = ais_readers.status2str(status);
                    throw new Exception("AIS status: " + status_msg);
                }
                else
                {
                    TimeZoneInfo localZone = TimeZoneInfo.Local;
                    
                    Helper.AppendText(tbInfo, "Hardware type: " + hardware_type + "\n", Color.Navy);
                    Helper.AppendText(tbInfo, "Firmware version: " + firmware_version + "\n", Color.Navy);
                    Helper.AppendText(tbInfo, "FTDI Serial number: " + ftdi_serial + "\n", Color.Black);
                    Helper.AppendText(tbInfo, "Device date (UTC): " + dt.ToLongDateString() + "\n", Color.Navy);
                    Helper.AppendText(tbInfo, "Device time (UTC): " + dt.ToLongTimeString() + "\n", Color.Navy);
                    if ((localZone.BaseUtcOffset.Hours * 60 + localZone.BaseUtcOffset.Minutes) != timezone)
                    {
                        Helper.AppendText(tbInfo, "Device time zone offset differs from the local one:\n", Color.Red);
                        Helper.AppendText(tbInfo, "\tDevice time zone offset: " +  timezone + " min.\n", Color.Red);
                        Helper.AppendText(tbInfo, "\tLocal time zone offset: " + (localZone.BaseUtcOffset.Hours * 60 + localZone.BaseUtcOffset.Minutes) + " min.\n", Color.Red);
                    }
                    if (localZone.IsDaylightSavingTime(dt) != is_dst)
                    {
                        Helper.AppendText(tbInfo, "Device daylight saving differs from the local one:\n", Color.Red);
                        Helper.AppendText(tbInfo, String.Format("\tDevice daylight saving: {0}\n", is_dst ? "active" : "inactive"), Color.Red);
                        Helper.AppendText(tbInfo, String.Format("\tLocal daylight saving for device date_time: {0}\n", localZone.IsDaylightSavingTime(dt) ? "active" : "inactive"), Color.Red);
                    }
                    else if (is_dst)
                    {
                        TimeSpan local_dst_delta = Helper.getDaylightDeltaOnSpecificDateTime(localZone, dt);
                        if ((local_dst_delta.Hours * 60 + local_dst_delta.Minutes) != dst_bias)
                        {
                            Helper.AppendText(tbInfo, "Device daylight saving bias differs from the local one:\n", Color.Red);
                            Helper.AppendText(tbInfo, "\tDevice daylight saving bias: " + dst_bias + " min.\n", Color.Red);
                            Helper.AppendText(tbInfo, "\tLocal daylight saving bias for device date_time: " + (local_dst_delta.Hours * 60 + local_dst_delta.Minutes) + " min.\n", Color.Red);
                        }
                    }
                    if (Math.Abs(udc_diff.TotalSeconds) > ais_readers.MAX_DATE_TIME_DIFF_IN_SEC)
                    {
                        Helper.AppendText(tbInfo, String.Format("Device date_time (UTC) differs from the local UTC time, on this PC, by: {0:F4}", udc_diff.TotalDays) + " days\n", Color.Red);
                    }
                    Helper.AppendText(tbInfo, "Batery status: " + battery_status + "\n", Color.Black);
                    Helper.AppendText(tbInfo, "Batery available: " + battery_available_percent + " %\n", Color.Black);
                    Helper.AppendText(tbLog, "Device information read successfully.\n", Color.Green);
                    Helper.SetStatusOk(statusLabel);
                }
            }
            catch (Exception exception)
            {
                Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void DisplayLocalDateTimeNow() 
        {
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            DateTime now = DateTime.Now;

            tbLocalDateTime.Text = now.ToString();
            tbLocalUTC.Text = DateTime.UtcNow.ToString();
            tbLocalTimeZoneStandardName.Text = localZone.StandardName;
            tbLocalTimeZoneName.Text = localZone.DisplayName;
            tbLocalTimeZoneOffset.Text = (localZone.BaseUtcOffset.Hours * 60 + localZone.BaseUtcOffset.Minutes).ToString();

            if (localZone.SupportsDaylightSavingTime)
            {
                TimeSpan local_dst_delta = Helper.getDaylightDeltaForSpecificYear(localZone, now.Year);

                tbLocalDstName.Text = localZone.DaylightName;
                tbLocalDstDelta.Text = (local_dst_delta.Hours * 60 + local_dst_delta.Minutes).ToString();
                chkLocalDstActive.Checked = localZone.IsDaylightSavingTime(now);
            }
            else
            {
                tbLocalDstName.Text = "";
                tbLocalDstDelta.Text = "";
                chkLocalDstActive.Checked = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageDateTime)
            {
                DisplayLocalDateTimeNow();
            }

            UInt32 intercom, door, relay_state;

            if (device_type == DEVICE_TYPES.DL_AIS_BASE_HD_XRCA)
            {
                //ais_readers.AIS_GetIoState(hnd_device, out intercom, out door, out relay_state);
                //chkIntercomState.Checked = intercom != 0;
                //chkDoorState.Checked = door != 0;
                //chkRelayState.Checked = relay_state != 0;
            }
        }

        private void btnGetTime_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            string status_msg;
            Int32 timezone, dst_bias;
            bool is_dst;
            DateTime utc = DateTime.UtcNow;
            DateTime dt;
            TimeSpan udc_diff, total_time_offset;
            TimeZoneInfo localZone = TimeZoneInfo.Local;

            try
            {
                status = ais_readers.AIS_GetTime(hnd_device, out dt, out timezone, out is_dst, out dst_bias);
                if (status != DL_STATUS.DL_OK)
                {
                    status_msg = ais_readers.status2str(status);
                    throw new Exception("AIS status: " + status_msg);
                }
                else
                {
                    // Test vectors: ---------------------------------
                    //is_dst = false;
                    //timezone = 9;
                    //dst_bias = 9;
                    // -----------------------------------------------

                    total_time_offset = new TimeSpan(0, timezone, 0);
                    if (is_dst)
                        total_time_offset += new TimeSpan(0, dst_bias, 0);

                    udc_diff = dt - utc;
                    dtpDeviceUTC.Value = dt;
                    numDeviceTimeZoneOffset.Value = timezone;
                    numDeviceDstDelta.Value = dst_bias;
                    chkDeviceDstActive.Checked = is_dst;
                    dtpDeviceTime.Value = dt + total_time_offset;

                    dtpDeviceUTC.Visible = true;
                    dtpDeviceTime.Visible = true;
                    btnSubmitDateTime.Enabled = true;
                    
                    Helper.AppendText(tbLog, "Device date and time read successfully.\n", Color.Green);
                    if ((localZone.BaseUtcOffset.Hours * 60 + localZone.BaseUtcOffset.Minutes) != timezone)
                    {
                        Helper.AppendText(tbLog, "Device time zone offset differs from the local one:\n", Color.Red);
                        Helper.AppendText(tbLog, "\tDevice time zone offset: " + timezone + " min.\n", Color.Red);
                        Helper.AppendText(tbLog, "\tLocal time zone offset: " + (localZone.BaseUtcOffset.Hours * 60 + localZone.BaseUtcOffset.Minutes) + " min.\n", Color.Red);
                    }
                    if (localZone.IsDaylightSavingTime(dt) != is_dst)
                    {
                        Helper.AppendText(tbLog, "Device daylight saving differs from the local one:\n", Color.Red);
                        Helper.AppendText(tbLog, String.Format("\tDevice daylight saving: {0}\n", is_dst ? "active" : "inactive"), Color.Red);
                        Helper.AppendText(tbLog, String.Format("\tLocal daylight saving for device date_time: {0}\n", localZone.IsDaylightSavingTime(dt) ? "active" : "inactive"), Color.Red);
                    }
                    else if (is_dst)
                    {
                        TimeSpan local_dst_delta = Helper.getDaylightDeltaOnSpecificDateTime(localZone, dt);
                        if ((local_dst_delta.Hours * 60 + local_dst_delta.Minutes) != dst_bias)
                        {
                            Helper.AppendText(tbLog, "Device daylight saving bias differs from the local one:\n", Color.Red);
                            Helper.AppendText(tbLog, "\tDevice daylight saving bias: " + dst_bias + " min.\n", Color.Red);
                            Helper.AppendText(tbLog, "\tLocal daylight saving bias for device date_time: " + (local_dst_delta.Hours * 60 + local_dst_delta.Minutes) + " min.\n", Color.Red);
                        }
                    }
                    if (Math.Abs(udc_diff.TotalSeconds) > ais_readers.MAX_DATE_TIME_DIFF_IN_SEC)
                    {
                        Helper.AppendText(tbLog, String.Format("Device date_time (UTC) differs from the local UTC time, on this PC, by: {0:F4}", udc_diff.TotalDays) + " days\n", Color.Red);
                    }

                    Helper.SetStatusOk(statusLabel);

                    btnSubmitDateTime.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void SubmitDateTime(DateTime dt, Int32 time_zone, bool dst, Int32 dst_bias, string MsgOnSuccess)
        {
            DL_STATUS status;
            string status_msg;

            try
            {
                status = ais_readers.AIS_SetTime(hnd_device, AdminPassword, dt, time_zone, dst, dst_bias);
                if (status != DL_STATUS.DL_OK)
                {
                    status_msg = ais_readers.status2str(status);
                    throw new Exception("AIS status: " + status_msg);
                }
                else
                {
                    Helper.AppendText(tbLog, MsgOnSuccess, Color.Green);
                    Helper.SetStatusOk(statusLabel);
                    btnGetTime_Click(this, new EventArgs());
                }
            }
            catch (Exception exception)
            {
                Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void btnSubmitLocalDateTime_Click(object sender, EventArgs e)
        {
            SubmitDateTime(DateTime.Now, Convert.ToInt32(tbLocalTimeZoneOffset.Text), chkLocalDstActive.Checked, Convert.ToInt32(tbLocalDstDelta.Text),
                "Device DateTime have been successfully set to local DateTime.\n");
        }

        private void btnSubmitDateTime_Click(object sender, EventArgs e)
        {
            SubmitDateTime(dtpDeviceUTC.Value, Convert.ToInt32(numDeviceTimeZoneOffset.Value), chkDeviceDstActive.Checked, Convert.ToInt32(numDeviceDstDelta.Value),
                "Device DateTime have been successfully set.\n");
        }

        private void btnGetWholeLog_Click(object sender, EventArgs e)
        {
            DL_STATUS status;

            if (!LogInProgress)
            {
                toolStripProgressBar.Value = 0;
                gridLog.Rows.Clear();

                if (chkGetLogByIndex.Checked)
                {
                    status = ais_readers.AIS_GetLogByIndex(hnd_device, AdminPassword, (UInt32)numIndexFrom.Value, (UInt32)numIndexTo.Value);
                }
                else if (chkGetLogByTime.Checked)
                {
                    status = ais_readers.AIS_GetLogByTime(hnd_device, AdminPassword, dtpLogTimeFrom.Value, dtpLogTimeTo.Value);
                }
                else
                {
                    status = ais_readers.AIS_GetLog_Set(hnd_device, AdminPassword);
                }

                if (status == DL_STATUS.DL_OK)
                {
                    LogInProgress = true;
                    Helper.AppendText(tbLog, "Log download setup successful.\n", Color.Green);
                    Helper.SetStatusOk(statusLabel);
                    btnGetWholeLog.Enabled = false;
                }
                else
                {
                    Helper.AppendText(tbLog, "Log download setup error. ", Color.Red);
                    Helper.AppendText(tbLog, "AIS status: " + status.ToString() + ".\n", Color.Red);
                    Helper.SetStatusErr(statusLabel);
                }
            }
        }

        private void ProgressEvent(Int32 percent) 
        {
            toolStripProgressBar.Value = percent;
        }

        private void LogFinishedEvent()
        {
            DL_STATUS status;
            UInt32 log_count, log_idx, log_action, log_reader_id, log_card_id, log_system_id, nfc_uid_len;
            DateTime log_date_time;
            CultureInfo invC = CultureInfo.InvariantCulture;
            byte[] nfc_uid = Enumerable.Repeat((byte)0, ais_readers.NFC_UID_MAX_LEN).ToArray();
            string str_nfc_uid;

            log_count = ais_readers.AIS_ReadLog_Count(hnd_device);
            for (UInt32 i = 0; i < log_count; i++)
            {

                status = ais_readers.AIS_ReadLog(hnd_device, out log_idx, out log_action, out log_reader_id,
                                                out log_card_id, out log_system_id, nfc_uid, out nfc_uid_len, out log_date_time);
                if (status == DL_STATUS.DL_OK)
                {
                    str_nfc_uid = BitConverter.ToString(nfc_uid, 0, (Int32)nfc_uid_len);
                    str_nfc_uid = str_nfc_uid.Replace('-', ':');
                    string[] new_row = new string[] { log_idx.ToString(), log_action.ToString(), log_reader_id.ToString(), 
                                     log_card_id.ToString(), log_system_id.ToString(), log_date_time.ToString("dd.MM.yyyy.", invC), 
                                     log_date_time.ToString("HH:mm:ss", invC), str_nfc_uid};
                    gridLog.Rows.Add(new_row);
                }
            }

            MessageBox.Show("Log successfully finished.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Helper.AppendText(tbLog, "Log successfully finished.\n", Color.Green);
            Helper.SetStatusOk(statusLabel);
            LogInProgress = false;
            btnGetWholeLog.Enabled = true;
        }

        private void DeviceDisconnectedEvent()
        {
            IsDeviceDisconnected = true;
            Close();
        }

        private void RTEHappenedEvent(UInt32 num_of_rte)
        {
            DL_STATUS status;
            UInt32 rte_idx, rte_action, rte_reader_id, rte_card_id, rte_system_id, nfc_uid_len;
            DateTime rte_date_time;
            CultureInfo invC = CultureInfo.InvariantCulture;
            string str_nfc_uid;
            byte[] nfc_uid = Enumerable.Repeat((byte)0, ais_readers.NFC_UID_MAX_LEN).ToArray();

            if (btnStopRTEMonitor.Enabled)
            {
                for (UInt32 i = 0; i < num_of_rte; i++)
                {
                    status = ais_readers.AIS_ReadRTE(hnd_device, out rte_idx, out rte_action, out rte_reader_id,
                                                     out rte_card_id, out rte_system_id, nfc_uid, out nfc_uid_len, out rte_date_time);

                    if (status == DL_STATUS.DL_OK)
                    {
                        str_nfc_uid = BitConverter.ToString(nfc_uid, 0, (Int32)nfc_uid_len);
                        str_nfc_uid = str_nfc_uid.Replace('-', ':');
                        string[] new_row = new string[] { rte_idx.ToString(), rte_action.ToString(), rte_reader_id.ToString(), 
                                             rte_card_id.ToString(), rte_system_id.ToString(), rte_date_time.ToString("dd.MM.yyyy.", invC), 
                                             rte_date_time.ToString("HH:mm:ss", invC), str_nfc_uid};
                        gridRTE.Rows.Add(new_row);
                    }
                }
            }
        }

        private void LibFaultStatusEvent(DL_STATUS status)
        {
            Helper.AppendText(tbLog, "Error status event occurred in library. ", Color.Purple);
            Helper.AppendText(tbLog, "AIS status: " + status.ToString() + ".\n", Color.Purple);
        }

        private void MainLoopFaultStatusEvent(DL_STATUS status)
        {
            Helper.AppendText(tbLog, "Error status event occurred while executing Main Library Loop. ", Color.Purple);
            Helper.AppendText(tbLog, "AIS status: " + status.ToString() + ".\n", Color.Purple);
        }

        private void btnStartRTEMonitor_Click(object sender, EventArgs e)
        {
            gridRTE.Rows.Clear();
            Helper.AppendText(tbLog, "RTE Monitor activated.\n", Color.Black);
            Helper.SetStatusOk(statusLabel);
            btnStartRTEMonitor.Enabled = false;
            btnStopRTEMonitor.Enabled = true;
        }

        private void btnStopRTEMonitor_Click(object sender, EventArgs e)
        {
            btnStartRTEMonitor.Enabled = true;
            btnStopRTEMonitor.Enabled = false;
            Helper.AppendText(tbLog, "RTE Monitor deactivated.\n", Color.Black);
            Helper.SetStatusOk(statusLabel);
        }

        private void btnReadBlackList_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            Int32 size;
            char[] delimiters = { ';', '.', ',', ' ', '\t', '\r', '\n'};

#if THREAD_PROTECT
            mut.WaitOne();
#endif
            status = ais_readers.AIS_Blacklist_GetSize(hnd_device, AdminPassword, out size);
#if THREAD_PROTECT
            mut.ReleaseMutex();
#endif

            if (status == DL_STATUS.DL_OK)
            {
                StringBuilder sb = new StringBuilder(size);

#if THREAD_PROTECT
                mut.WaitOne();
#endif
                status = ais_readers.AIS_Blacklist_Read(hnd_device, sb);
#if THREAD_PROTECT
                mut.ReleaseMutex();
#endif

                if (status == DL_STATUS.DL_OK)
                {
                    string s_black_list = sb.ToString();
                    string[] as_black_list_items = s_black_list.Split(delimiters);
                    blacklist_items.Clear();
                    for (Int32 i = 0; i < as_black_list_items.Count(); i++)
                    {
                        if (Helper.IsStringNumericDigitsOnly(as_black_list_items[i]))
                        {
                            blacklist_items.Add(as_black_list_items[i]);
                        }
                    }
                    lstBlacklist.DataSource = null;
                    blacklist_items.Sort(new AlphanumComparatorFast());
                    lstBlacklist.DataSource = blacklist_items;
                    Helper.AppendText(tbLog, "Blacklist successfully read from the device.\n", Color.Green);
                    Helper.SetStatusOk(statusLabel);
                }
                else
                {
                    Helper.AppendText(tbLog, "Error while reading Blacklist. ", Color.Red);
                    Helper.AppendText(tbLog, "AIS status: " + status.ToString() + ".\n", Color.Red);
                    Helper.SetStatusErr(statusLabel);
                }
            } 
            else
            {
                Helper.AppendText(tbLog, "Error while reading Blacklist. ", Color.Red);
                Helper.AppendText(tbLog, "AIS status: " + status.ToString() + ".\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void btnListPut_Click(object sender, EventArgs e)
        {
            UInt32 id1, id2, from, to;
            bool changed = false, wrong_input = false;

            if (Helper.IsStringNumericDigitsOnly(tbListCardSn.Text))
            {
                if (blacklist_items.Contains(tbListCardSn.Text))
                {
                    Helper.AppendText(tbLog, "Card SN is already on the local Blacklist.\n", Color.Purple);
                    Helper.SetStatusInputWarning(statusLabel);
                }
                else
                {
                    blacklist_items.Add(tbListCardSn.Text);
                    changed = true;
                }
            }
            else
            {
                string[] as_black_list_items = tbListCardSn.Text.Split('-');
                if (as_black_list_items.Count() == 2)
                {
                    if (Helper.IsStringNumericDigitsOnly(as_black_list_items[0])
                        && Helper.IsStringNumericDigitsOnly(as_black_list_items[1]))
                    {
                        string new_item;
                        id1 = Convert.ToUInt32(as_black_list_items[0]);
                        id2 = Convert.ToUInt32(as_black_list_items[1]);

                        if (id1 <= id2) 
                        {
                            from = id1;
                            to = id2;
                        }
                        else
                        {
                            from = id2;
                            to = id1;
                        }

                        for (UInt32 i = from; i <= to; i++)
                        {
                            new_item = i.ToString();
                            if (!blacklist_items.Contains(new_item))
                            {
                                blacklist_items.Add(new_item);
                                changed = true;
                            }
                        }
                        if (!changed)
                        {
                            Helper.AppendText(tbLog, "All SN from the range are already on the local Blacklist.\n", Color.Purple);
                            Helper.SetStatusInputWarning(statusLabel);
                        }
                    }
                    else
                    {
                        wrong_input = true;
                    }
                }
                else
                {
                    wrong_input = true;
                }
            }

            if (wrong_input)
            {
                Helper.AppendText(tbLog, "Wrong user input.\n", Color.Purple);
                Helper.SetStatusInputWarning(statusLabel);
            }

            if (changed)
            {
                lstBlacklist.DataSource = null;
                blacklist_items.Sort(new AlphanumComparatorFast());
                lstBlacklist.DataSource = blacklist_items;
                Helper.AppendText(tbLog, "Item(s) successfully added to the local Blacklist.\n", Color.Black);
                Helper.SetStatusOk(statusLabel);
            }
        }

        private void btnListRemove_Click(object sender, EventArgs e)
        {

            if (!Helper.IsStringNumericDigitsOnly(tbListCardSn.Text))
            {
                Helper.AppendText(tbLog, "Wrong user input.\n", Color.Purple);
                Helper.SetStatusInputWarning(statusLabel);
                return;
            }

            if (blacklist_items.Contains(tbListCardSn.Text))
            {
                Int32 selectedIndex = blacklist_items.IndexOf(tbListCardSn.Text);

                blacklist_items.RemoveAt(selectedIndex);
                lstBlacklist.DataSource = null;
                lstBlacklist.DataSource = blacklist_items;
                Helper.AppendText(tbLog, "Item(s) successfully removed from the local Blacklist.\n", Color.Black);
                Helper.SetStatusOk(statusLabel);
            }
            else
            {
                Helper.AppendText(tbLog, "Card SN not on the local Blacklist.\n", Color.Purple);
                Helper.SetStatusInputWarning(statusLabel);
            }
        }

        private void btnListClear_Click(object sender, EventArgs e)
        {
            blacklist_items.Clear();
            lstBlacklist.DataSource = null;
            lstBlacklist.DataSource = blacklist_items;
            Helper.AppendText(tbLog, "Local Blacklist has been cleared.\n", Color.Black);
            Helper.SetStatusOk(statusLabel);
        }

        private void lstBlacklist_DoubleClick(object sender, EventArgs e)
        {
            Int32 selectedIndex = lstBlacklist.SelectedIndex;

            tbListCardSn.Text = blacklist_items[selectedIndex];
        }

        private void btnWriteBlackList_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            string str_blacklist = "";

            for (Int32 i = 0; i < blacklist_items.Count; i++)
            {
                if (i > 0) 
                {
                    str_blacklist += ",";
                }
                str_blacklist += blacklist_items[i];
            }

#if THREAD_PROTECT
            mut.WaitOne();
#endif
            status = ais_readers.AIS_Blacklist_Write(hnd_device, AdminPassword, str_blacklist);
#if THREAD_PROTECT
            mut.ReleaseMutex();
#endif

            if (status == DL_STATUS.DL_OK)
            {
                Helper.AppendText(tbLog, "Blacklist successfully written to the device.\n", Color.Green);
                Helper.SetStatusOk(statusLabel); ;
            }
            else
            {
                string status_msg = ais_readers.status2str(status);
                Helper.AppendText(tbLog, "AIS status: " + status_msg + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {            
            string str_blacklist = "";
            string path;
            DialogResult result;
            SaveFileDialog file_dialog = new SaveFileDialog();

            file_dialog.FileName = "blacklist";
            file_dialog.DefaultExt = "txt";
            file_dialog.Filter = "txt files (*.txt)|*.txt|coma separated values (*.csv)|*.csv|All files (*.*)|*.*";
            file_dialog.FilterIndex = 1;
            file_dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
                
            result = file_dialog.ShowDialog();
            if (result == DialogResult.OK)
	        {
		        path = file_dialog.FileName;

                for (Int32 i = 0; i < blacklist_items.Count; i++)
                {
                    if (i > 0) 
                    {
                        str_blacklist += ",";
                    }
                    str_blacklist += blacklist_items[i];
                }

                try
                {
                    File.WriteAllText(path, str_blacklist, Encoding.ASCII);
                }
                catch (Exception exception)
                {
                    Helper.AppendText(tbLog, "Error while writing file to disc: ", Color.Red);
                    Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                    Helper.SetStatusErr(statusLabel);
                    return;
                }
                Helper.AppendText(tbLog, "File succesfuly written to disc.\n", Color.Green);
                Helper.SetStatusOk(statusLabel);
            }
        }

        private void BtnListImport_Click(object sender, EventArgs e)
        {
            char[] delimiters = { ';', '.', ',', ' ', '\t', '\r', '\n' };
            string s_black_list = "";
            string path;
            string[] as_black_list_items;
            DialogResult result;
            OpenFileDialog file_dialog = new OpenFileDialog();

            file_dialog.Filter = "txt files (*.txt)|*.txt|coma separated values (*.csv)|*.csv|All files (*.*)|*.*";
            file_dialog.FilterIndex = 1;
            file_dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
                
            result = file_dialog.ShowDialog();
            if (result == DialogResult.OK)
	        {
                path = file_dialog.FileName;

                try
                {
                    s_black_list = File.ReadAllText(path, Encoding.ASCII);
                }
                catch (Exception exception)
                {
                    Helper.AppendText(tbLog, "Error while reading file from disc: ", Color.Red);
                    Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                    Helper.SetStatusErr(statusLabel);
                    return;
                }

                as_black_list_items = s_black_list.Split(delimiters);
                
                blacklist_items.Clear();
                
                for (Int32 i = 0; i < as_black_list_items.Count(); i++)
                {
                    if (Helper.IsStringNumericDigitsOnly(as_black_list_items[i]))
                    {
                        blacklist_items.Add(as_black_list_items[i]);
                    }
                }

                lstBlacklist.DataSource = null;
                blacklist_items.Sort(new AlphanumComparatorFast());
                lstBlacklist.DataSource = blacklist_items;

                Helper.AppendText(tbLog, "File succesfuly read from disc.\n", Color.Green);
                Helper.SetStatusOk(statusLabel);
            }
        }

        private void btnLockOpen_Click(object sender, EventArgs e)
        {
            DL_STATUS status;

            status = ais_readers.AIS_LockOpen(hnd_device, (UInt32)numDuration.Value);
            if (status == DL_STATUS.DL_OK)
            {
                Helper.AppendText(tbLog, "Unlock signal has been successfuly sent. Signal duration is: " 
                    + numDuration.Value.ToString()  + " ms\n", Color.Green);
                Helper.SetStatusOk(statusLabel);
            }
            else
            {
                string status_msg = ais_readers.status2str(status);
                Helper.AppendText(tbLog, "AIS status: " + status_msg + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void btnSetLight_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            string temp = "", green_master_str = "(green master ", red_master_str = "(red master ";
            string green_slave_str = "(green slave ", red_slave_str = "(red slave ";
            UInt32 green_master, red_master, green_slave, red_slave;

            if (chkGreenMaster.Checked) {
                green_master = 1;
                green_master_str += "ON)";
            }
            else 
            {
                green_master = 0;
                green_master_str += "OFF)";
            }

            if (chkRedMaster.Checked) {
                red_master = 1;
                red_master_str += "ON)";
            }
            else 
            {
                red_master = 0;
                red_master_str += "OFF)";
            }

            if (chkGreenSlave.Checked)
            {
                green_slave = 1;
                green_slave_str += "ON)";
            }
            else
            {
                green_slave = 0;
                green_slave_str += "OFF)";
            }

            if (chkRedSlave.Checked)
            {
                red_slave = 1;
                red_slave_str += "ON)";
            }
            else
            {
                red_slave = 0;
                red_slave_str += "OFF)";
            }

            status = ais_readers.AIS_LightControl(hnd_device, green_master, red_master, green_slave, red_slave);
            if (status == DL_STATUS.DL_OK)
            {
                Helper.AppendText(tbLog, "Light signal has been successfuly set. ", Color.Black);
                Helper.AppendText(tbLog, green_master_str + " ", Color.Green);
                Helper.AppendText(tbLog, red_master_str + " ", Color.Red);
                Helper.AppendText(tbLog, green_slave_str + " ", Color.Green);
                Helper.AppendText(tbLog, red_slave_str + ".\n", Color.Red);
                Helper.SetStatusOk(statusLabel);
            }
            else
            {
                string status_msg = ais_readers.status2str(status);
                Helper.AppendText(tbLog, "AIS status: " + status_msg + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void btnRelayOn_Click(object sender, EventArgs e)
        {
            DL_STATUS status;

            status = ais_readers.AIS_RelayStateSet(hnd_device, 1);
            if (status == DL_STATUS.DL_OK)
            {
                Helper.AppendText(tbLog, "Relay state set to ON.\n", Color.Green);
                Helper.SetStatusOk(statusLabel);
            }
            else
            {
                string status_msg = ais_readers.status2str(status);
                Helper.AppendText(tbLog, "AIS status: " + status_msg + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void btnRelayOff_Click(object sender, EventArgs e)
        {
            DL_STATUS status;

            status = ais_readers.AIS_RelayStateSet(hnd_device, 0);
            if (status == DL_STATUS.DL_OK)
            {
                Helper.AppendText(tbLog, "Relay state set to OFF.\n", Color.Green);
                Helper.SetStatusOk(statusLabel);
            }
            else
            {
                string status_msg = ais_readers.status2str(status);
                Helper.AppendText(tbLog, "AIS status: " + status_msg + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void btnClearLogBox_ButtonClick(object sender, EventArgs e)
        {
            tbLog.Clear();
        }

        private void btnReadWhitelist_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            char[] delimiters = { ',', ';', '\t', '\r', '\n'};
            string s_whitelist = "";

#if THREAD_PROTECT
            mut.WaitOne();
#endif
            status = ais_readers.AIS_Whitelist_Read(hnd_device, AdminPassword, out s_whitelist);
#if THREAD_PROTECT
            mut.ReleaseMutex();
#endif

            if (status == DL_STATUS.DL_OK)
            {
                string[] as_whitelist_items = s_whitelist.Split(delimiters);
                whitelist_items.Clear();

                string uid_str;
                UInt32 uid_len;
                char[] pair_separators = { ':', '.', '-' };

                for (Int32 i = 0; i < as_whitelist_items.Count(); i++)
                {
                    if (getNfcUidFromRawString(as_whitelist_items[i], pair_separators, out uid_str, out uid_len))
                    {
                        whitelist_items.Add(uid_str);
                    }
                }

                lstWhitelist.DataSource = null;
                whitelist_items.Sort(new AlphanumComparatorFast());
                lstWhitelist.DataSource = whitelist_items;
                Helper.AppendText(tbLog, "Whitelist successfully read from the device.\n", Color.Green);
                Helper.SetStatusOk(statusLabel);
            }
            else
            {
                Helper.AppendText(tbLog, "Error while reading Whitelist. ", Color.Red);
                Helper.AppendText(tbLog, "AIS status: " + status.ToString() + ".\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void tbWhitelistUid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || (e.Control) || (e.Alt))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void tbWhitelistUid_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!Regex.IsMatch(e.KeyChar.ToString(), "^[0-9a-fA-F\r]+$"))
                e.KeyChar = '.';
        }

        private bool getNfcUidFromRawString(string raw_str, out string uid, out UInt32 uid_len)
        {
            char[] delimiters = { ':' };

            return getNfcUidFromRawString(raw_str, delimiters, out uid, out uid_len);
        }

        private bool getNfcUidFromRawString(string raw_str, char[] delimiters, out string uid, out UInt32 uid_len)
        {
            string[] hex_pairs;
            bool stop_count_valid_from_start = false;
            bool result = false;

            uid = "";
            uid_len = 0;
            hex_pairs = raw_str.Split(delimiters);

            for (UInt32 i = 0; i < hex_pairs.Length; i++)
            {
                string test = hex_pairs[i].Trim();
                if (test == "")
                {
                    stop_count_valid_from_start = true;
                    continue;
                }

                if (test.Length != 2)
                {
                    result = true;
                    break;
                }
                else if (Helper.IsStringHexPair(test))
                {
                    if (!stop_count_valid_from_start)
                    {
                        if (uid_len++ > 0)
                            uid += ":";
                        uid += test;
                    }
                }
                else
                {
                    result = true;
                    break;
                }
            }

            result |= (uid_len != 4) && (uid_len != 7) && (uid_len != 10);
            return !result;
        }

        private void btnPutOnWhitelist_Click(object sender, EventArgs e)
        {
            bool input_ok;
            UInt32 valid_from_start;
            string uid;

            input_ok = getNfcUidFromRawString(tbWhitelistUid.Text, out uid, out valid_from_start);

            if (input_ok)
            {
                whitelist_items.Add(uid);
                lstWhitelist.DataSource = null;
                whitelist_items.Sort(new AlphanumComparatorFast());
                lstWhitelist.DataSource = whitelist_items;

                Helper.AppendText(tbLog, "Card UId successfully added to the local Whitelist.\n", Color.Black);
                Helper.SetStatusOk(statusLabel);
            }
            else
            {
                Helper.AppendText(tbLog, "Wrong user input.\n", Color.Purple);
                Helper.SetStatusInputWarning(statusLabel);
            }
        }

        private void lstWhitelist_DoubleClick(object sender, EventArgs e)
        {
            Int32 selectedIndex = lstWhitelist.SelectedIndex;

            tbWhitelistUid.Text = whitelist_items[selectedIndex];
        }

        private void btnRemoveFromWhitelist_Click(object sender, EventArgs e)
        {
            bool input_ok;
            UInt32 uid_len;
            string uid;

            input_ok = getNfcUidFromRawString(tbWhitelistUid.Text, out uid, out uid_len);

            if (!input_ok)
            {
                Helper.AppendText(tbLog, "Wrong user input.\n", Color.Purple);
                Helper.SetStatusInputWarning(statusLabel);
                return;
            }

            if (whitelist_items.Contains(uid))
            {
                Int32 selectedIndex = whitelist_items.IndexOf(uid);

                whitelist_items.RemoveAt(selectedIndex);
                lstWhitelist.DataSource = null;
                lstWhitelist.DataSource = whitelist_items;
                Helper.AppendText(tbLog, "Item successfully removed from the local Whitelist.\n", Color.Black);
                Helper.SetStatusOk(statusLabel);
            }
            else
            {
                Helper.AppendText(tbLog, "Card UId not on the local Whitelist.\n", Color.Purple);
                Helper.SetStatusInputWarning(statusLabel);
            }
        }

        private void btnClearWhitelist_Click(object sender, EventArgs e)
        {
            whitelist_items.Clear();
            lstWhitelist.DataSource = null;
            lstWhitelist.DataSource = whitelist_items;
            Helper.AppendText(tbLog, "Local Whitelist has been cleared.\n", Color.Black);
            Helper.SetStatusOk(statusLabel);
        }

        private void btnWriteWhitelist_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            string str_whitelist = "";

            for (Int32 i = 0; i < whitelist_items.Count; i++)
            {
                if (i > 0)
                {
                    str_whitelist += ",";
                }
                str_whitelist += whitelist_items[i];
            }

#if THREAD_PROTECT
            mut.WaitOne();
#endif
            status = ais_readers.AIS_Whitelist_Write(hnd_device, AdminPassword, str_whitelist);
#if THREAD_PROTECT
            mut.ReleaseMutex();
#endif

            if (status == DL_STATUS.DL_OK)
            {
                Helper.AppendText(tbLog, "Whitelist successfully written to the device.\n", Color.Green);
                Helper.SetStatusOk(statusLabel); ;
            }
            else
            {
                string status_msg = ais_readers.status2str(status);
                Helper.AppendText(tbLog, "AIS status: " + status_msg + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void btnExportWhitelist_Click(object sender, EventArgs e)
        {
            string str_whitelist = "";
            string path;
            DialogResult result;
            SaveFileDialog file_dialog = new SaveFileDialog();

            file_dialog.FileName = "whitelist";
            file_dialog.DefaultExt = "txt";
            file_dialog.Filter = "txt files (*.txt)|*.txt|coma separated values (*.csv)|*.csv|All files (*.*)|*.*";
            file_dialog.FilterIndex = 1;
            file_dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();

            result = file_dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = file_dialog.FileName;

                for (Int32 i = 0; i < whitelist_items.Count; i++)
                {
                    if (i > 0)
                    {
                        str_whitelist += ",";
                    }
                    str_whitelist += whitelist_items[i];
                }

                try
                {
                    File.WriteAllText(path, str_whitelist, Encoding.ASCII);
                }
                catch (Exception exception)
                {
                    Helper.AppendText(tbLog, "Error while writing file to disc: ", Color.Red);
                    Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                    Helper.SetStatusErr(statusLabel);
                    return;
                }
                Helper.AppendText(tbLog, "File succesfuly written to disc.\n", Color.Green);
                Helper.SetStatusOk(statusLabel);
            }
        }

        private void btnImportWhitelist_Click(object sender, EventArgs e)
        {
            char[] delimiters = { ',', ';', '\t', '\r', '\n' };
            string s_white_list = "";
            string path;
            string[] as_white_list_items;
            DialogResult result;
            OpenFileDialog file_dialog = new OpenFileDialog();

            file_dialog.Filter = "txt files (*.txt)|*.txt|coma separated values (*.csv)|*.csv|All files (*.*)|*.*";
            file_dialog.FilterIndex = 1;
            file_dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();

            result = file_dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = file_dialog.FileName;

                try
                {
                    s_white_list = File.ReadAllText(path, Encoding.ASCII).ToUpper();
                }
                catch (Exception exception)
                {
                    Helper.AppendText(tbLog, "Error while reading file from disc: ", Color.Red);
                    Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                    Helper.SetStatusErr(statusLabel);
                    return;
                }

                as_white_list_items = s_white_list.Split(delimiters);

                whitelist_items.Clear();

                string uid_str;
                UInt32 uid_len;
                char[] pair_separators = { ':', ' ', '-', '.' };

                for (Int32 i = 0; i < as_white_list_items.Count(); i++)
                {
                    if (getNfcUidFromRawString(as_white_list_items[i], pair_separators, out uid_str, out uid_len))
                    {
                        whitelist_items.Add(uid_str);
                    }
                }

                lstWhitelist.DataSource = null;
                whitelist_items.Sort(new AlphanumComparatorFast());
                lstWhitelist.DataSource = whitelist_items;

                Helper.AppendText(tbLog, "File succesfuly read from disc.\n", Color.Green);
                Helper.SetStatusOk(statusLabel);
            }

        }

        private void numIndexFrom_Validated(object sender, EventArgs e)
        {
            if (numIndexFrom.Text == "")
            {
                numIndexFrom.Text = "0";
            }
        }

        private void numIndexTo_Validated(object sender, EventArgs e)
        {
            if (numIndexTo.Text == "")
            {
                numIndexTo.Text = "0";
            }
        }

        private void chkGetLogByIndex_Click(object sender, EventArgs e)
        {
            chkGetLogByTime.Checked = false;
        }

        private void chkGetLogByTime_Click(object sender, EventArgs e)
        {
            chkGetLogByIndex.Checked = false;
        }

        private void chkGetLogByIndex_CheckedChanged(object sender, EventArgs e)
        {
            lbIndexFrom.Enabled = chkGetLogByIndex.Checked;
            numIndexFrom.Enabled = chkGetLogByIndex.Checked;
            lbIndexTo.Enabled = chkGetLogByIndex.Checked;
            numIndexTo.Enabled = chkGetLogByIndex.Checked;
        }

        private void chkGetLogByTime_CheckedChanged(object sender, EventArgs e)
        {
            lbLogTimeFrom.Enabled = chkGetLogByTime.Checked;
            dtpLogTimeFrom.Enabled = chkGetLogByTime.Checked;
            lbLogTimeFrom.Enabled = chkGetLogByTime.Checked;
            dtpLogTimeTo.Enabled = chkGetLogByTime.Checked;
        }
    }

    public class CustomClosingEventArgs : EventArgs
    {
        private UInt64 priv_ui_handle;
        public UInt64 UiHandle 
        {
            get
            {
                return priv_ui_handle;
            }
        }

        public CustomClosingEventArgs(UInt64 parm_ui_handle)
        {
            priv_ui_handle = parm_ui_handle;
        }
    }

    public class DeviceMainLoop
    {
#if THREAD_PROTECT
        private Mutex mut;
#endif
        private HND_AIS hnd_device;
        private frmSelectedDevice form;
        private bool stop_request = false;

#if THREAD_PROTECT
        public DeviceMainLoop(HND_AIS hnd_ais, frmSelectedDevice param_form, Mutex param_mut)
        {
            hnd_device = hnd_ais;
            form = param_form;
            mut = param_mut;
        }
#endif

        public DeviceMainLoop(HND_AIS hnd_ais, frmSelectedDevice param_form)
        {
            hnd_device = hnd_ais;
            form = param_form;
        }

        public void stop()
        {
            stop_request = true;
        }

        public void run()
        {
            DL_STATUS status, lib_status;
            UInt32 num_of_rte, percent = 0, tmp_percent;
            bool log_event, cmd_finished_edge = false, cmd_finished, timeout_occurred;

            while (!stop_request)
            {

#if THREAD_PROTECT
                mut.WaitOne();
#endif

                status = ais_readers.AIS_MainLoop(hnd_device, 
                    out num_of_rte,
                    out log_event, // indicate new data in log buffer
                    out cmd_finished, // indicate command finish
                    out tmp_percent, // indicate percent of command execution
                    out timeout_occurred, // debug only
                    out lib_status);

#if THREAD_PROTECT
                mut.ReleaseMutex();
#endif

                if (tmp_percent != percent)
                {
                    percent = tmp_percent;
                    form.Invoke(form.PercentUpdated, new Object[] { (Int32)percent });
                }

                if (cmd_finished_edge && !cmd_finished)
                {
                    cmd_finished_edge = false;
                }

                if (!cmd_finished_edge && cmd_finished)
                {
                    form.Invoke(form.PercentUpdated, new Object[] { 100 });
                    form.Invoke(form.LogFinished);
                    cmd_finished_edge = true;
                }

                if (status == DL_STATUS.NO_DEVICES)
                {
                    stop_request = true;
                    form.Invoke(form.DeviceDisconnected);
                    break;
                }
                else if (status == DL_STATUS.DL_OK)
                {
                    if (num_of_rte > 0)
                    {
                        form.Invoke(form.RTEHappened, new Object[] { num_of_rte });
                    }
                    if (lib_status != DL_STATUS.DL_OK)
                    {
                        form.Invoke(form.LibFaultStatus, new Object[] { lib_status });
                    }
                }
                else
                {
                    form.Invoke(form.MainLoopFaultStatus, new Object[] { status });
                }
                Thread.Yield();
            }
        }
    }
}
