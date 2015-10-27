using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using HND_AIS = System.UIntPtr;

namespace DL_AIS_Readers
{
    public partial class frmListDevices : Form
    {
        const string TITLE_ADITIONAL_TXT = " - List devices";
        frmFilterList dlgFilterList;
        SortedList<UInt64, Form> device_list;
        bool _isAnyDeviceAttached = false;

        public Boolean isAnyDeviceAttached
        {
            get
            {
                return this._isAnyDeviceAttached;
            }
            set
            {
                this._isAnyDeviceAttached = value;
                if (this._isAnyDeviceAttached)
                {
                    btnOpenDevice.Enabled = true;
                }
                else
                {
                    btnOpenDevice.Enabled = false;
                }
            }
        }

        public frmListDevices()
        {
            InitializeComponent();
        }

        private void btnGetDLLInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string str_dll_ver = ais_readers.GetDLLVersion();
                Helper.AppendText(tbLog, "GetDllVersion() returns: ", Color.Navy);
                Helper.AppendText(tbLog, str_dll_ver + "\n", Color.Black);
                Helper.SetStatusOk(statusLabel);
            }
            catch (Exception exception)
            {
                Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
                return;
            }
        }

        private void btnEnumerate_Click(object sender, EventArgs e)
        {
            UInt32 devices_count;
            DL_STATUS status;
            string status_msg;
            HND_AIS hnd_device;
            UInt32 Device_Type, Device_ID, Device_FW_VER, Device_CommSpeed, 
                   Device_isOpened, Device_Status, System_Status;
            string Device_Serial, Device_FTDI_Serial;

            // Shuld be a warning before close all opened devices
            gridView.Rows.Clear();
            try
            {
                devices_count = ais_readers.AIS_List_UpdateAndGetCount();
                Helper.AppendText(tbLog, "Listed devices succesfully enumerated. ", Color.Green);
                Helper.AppendText(tbLog, "Number of attached devices is: ", Color.Navy);
                Helper.AppendText(tbLog, "" + devices_count + "\n", Color.Black);
                Helper.SetStatusOk(statusLabel);

                if (isAnyDeviceAttached = (devices_count > 0))
                {
                    for (int i = 0; i < devices_count; i++)
                    {
                        try
                        {
                            status = ais_readers.AIS_List_GetInformation(
                                out hnd_device, // assigned Handle
                                out Device_Serial, // device serial number
                                out Device_Type, // device type
                                out Device_ID, // device identification number (master)
                                out Device_FW_VER, // version of firmware
                                out Device_CommSpeed, // communication speed
                                out Device_FTDI_Serial, // FTDI COM port identification
                                out Device_isOpened, // is Device opened
                                out Device_Status, // actual device status
                                out System_Status // actual system status
                            );
                            if (status != DL_STATUS.DL_OK)
                            {
                                status_msg = ais_readers.status2str(status);
                                throw new Exception("AIS status: " + status_msg);
                            }
                            else
                            {
                                string[] new_row = new string[] { (i + 1).ToString(), hnd_device.ToString(), Device_Serial, 
                                     Device_Type.ToString(), Device_ID.ToString(), Device_FW_VER.ToString(), 
                                     Device_CommSpeed.ToString(), Device_FTDI_Serial, Device_isOpened.ToString(), 
                                     Device_Status.ToString(), System_Status.ToString()};
                                gridView.Rows.Add(new_row);
                            }
                        }
                        catch (Exception exception)
                        {
                            Helper.AppendText(tbLog, "Warning: ", Color.Purple);
                            Helper.AppendText(tbLog, exception.Message + "\n", Color.Purple);
                            Helper.SetStatusWarning(statusLabel);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
            }
        }

        private void btnListAdd_Click(object sender, EventArgs e)
        {
            Int32 device_idx = cbList.SelectedIndex;
            UInt32 device_id = Convert.ToUInt32(tbId.Text);

            dlgFilterList.OuterListAdd(device_idx, device_id);
        }

        private void btnListDel_Click(object sender, EventArgs e)
        {
            Int32 device_idx = cbList.SelectedIndex;
            UInt32 device_id = Convert.ToUInt32(tbId.Text);

            dlgFilterList.OuterListDel(device_idx, device_id);
        }

        private void btnListClear_Click(object sender, EventArgs e)
        {
            dlgFilterList.OuterListClear();
        }

        private void btnOpenDevice_Click(object sender, EventArgs e)
        {
            UInt64 ui_hnd_device;
            UInt32 device_id;
            DEVICE_TYPES device_type;
            HND_AIS hnd_device;
            DL_STATUS status;
            string status_msg;

            ui_hnd_device = Convert.ToUInt64(gridView.SelectedRows[0].Cells[1].Value);
            hnd_device = new HND_AIS(ui_hnd_device);
            device_type = (DEVICE_TYPES)Convert.ToUInt32(gridView.SelectedRows[0].Cells[3].Value);
            device_id = Convert.ToUInt32(gridView.SelectedRows[0].Cells[4].Value);
            try
            {
                status = ais_readers.AIS_Open(hnd_device);

                if (status != DL_STATUS.DL_OK)
                {
                    status_msg = ais_readers.status2str(status);
                    throw new Exception("AIS status: " + status_msg);
                }
                else
                {
                    tbLog.AppendText("Device with assigned handle value "
                        + hnd_device
                        + " successfully opened.\n");
                    Helper.SetStatusOk(statusLabel);
                }
            }
            catch (Exception exception)
            {
                Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
                return;
            }
            NewDeviceByHndForm(ui_hnd_device, device_type, device_id);
        }

        private void NewDeviceByHndForm(UInt64 ui_hnd_device, DEVICE_TYPES device_type, UInt32 device_id)
        {
            frmSelectedDevice dialog;
            HND_AIS hnd_device = new HND_AIS(ui_hnd_device);

            if (device_list == null)
            {
                device_list = new SortedList<UInt64, Form>();
            }

            if (!device_list.ContainsKey(ui_hnd_device))
            {
                dialog = new frmSelectedDevice(hnd_device, device_type, device_id);
                device_list.Add(ui_hnd_device, dialog);
                dialog.ChildFormClosedEvent += new frmSelectedDevice.ChildFormClosedEventHandler(this.btnCloseDevice_Click);
                dialog.Show();
            }

            btnCloseDevice.Enabled = device_list.Count > 0;
        }

        private void btnCloseDevice_Click(object sender, EventArgs e)
        {
            UInt64 ui_hnd_device;
            HND_AIS hnd_device;
            DL_STATUS status;
            string status_msg;

            if (device_list == null) 
            {
                Helper.AppendText(tbLog, "There is no opened devices.\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
                return;
            }

            if (sender is frmSelectedDevice)
            {
                ui_hnd_device = ((CustomClosingEventArgs)e).UiHandle;
            }
            else
            {
                ui_hnd_device = Convert.ToUInt64(gridView.SelectedRows[0].Cells[1].Value);
            }
            hnd_device = new HND_AIS(ui_hnd_device);
            if (!device_list.ContainsKey(ui_hnd_device))
            {
                Helper.AppendText(tbLog, "Specified device with handle value ("
                    + ui_hnd_device
                    + ") not opened.\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
                return;
            }

            try
            {
                if (sender.Equals(btnCloseDevice))
                {
                    device_list[ui_hnd_device].Close();
                }

                status = ais_readers.AIS_Close(hnd_device);

                if (status != DL_STATUS.DL_OK)
                {
                    status_msg = ais_readers.status2str(status);
                    throw new Exception("AIS status: " + status_msg);
                }
                else
                {
                    tbLog.AppendText("Device with assigned handle value ("
                        + ui_hnd_device
                        + ") successfully closed.\n");
                    Helper.SetStatusOk(statusLabel);
                }

                device_list[ui_hnd_device] = null;
                device_list.Remove(ui_hnd_device);

                if (device_list.Count() == 0)
                {
                    btnCloseDevice.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                Helper.AppendText(tbLog, exception.Message, Color.Red);
                Helper.SetStatusErr(statusLabel);
                return;
            }
        }

        private void SetupDataGridView()
        {
            gridView.ColumnCount = 11;

            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            gridView.Columns[0].Name = "Idx";
            gridView.Columns[1].Name = "Handle";
            gridView.Columns[2].Name = "SN";
            gridView.Columns[3].Name = "Type";
            gridView.Columns[4].Name = "Id";
            gridView.Columns[5].Name = "FW";
            gridView.Columns[6].Name = "bps";
            gridView.Columns[7].Name = "FTDI SN";
            gridView.Columns[8].Name = "Opened";
            gridView.Columns[9].Name = "DevStatus";
            gridView.Columns[10].Name = "SysStatus";
        }

        private void frmListDevices_Load(object sender, EventArgs e)
        {
            this.Text += " v" + this.ProductVersion;
            this.Text += TITLE_ADITIONAL_TXT;

            if (dlgFilterList == null)
            {
                dlgFilterList = new frmFilterList(tbLog, statusLabel);
                dlgFilterList.frmInit();
            }
            dlgFilterList.ChildFormOnHideEvent += new frmFilterList.ChildFormOnHideEventHandler(this.HandleChildFormOnHideEvent);
            SetupDataGridView();

            string[] names = Enum.GetNames(typeof(DEVICE_TYPES));
            for (UInt32 i = 0; i < names.Length; i++)
            {
                cbList.Items.Add(names[i]);
            }
            Helper.SetAutoDropDownWidth(cbList);
            cbList.SelectedIndex = 0;

            try
            {
                tbLog.Text = "";
                string str_dll_ver = ais_readers.GetDLLVersion();
                Helper.AppendText(tbLog,
                    "Library " + ais_readers.DLL_NAME + " successfully loaded.\n",
                    Color.Green);
                Helper.AppendText(tbLog, "GetDllVersion() returns: ", Color.Navy);
                Helper.AppendText(tbLog, str_dll_ver + "\n", Color.Black);
                Helper.SetStatusOk(statusLabel);
            }
            catch (Exception exception)
            {
                Helper.AppendText(tbLog, exception.Message, Color.Red);
                Helper.SetStatusErr(statusLabel);
                DisableAllControls();
                return;
            }
        }

        private void DisableAllControls()
        {
            foreach (Control x in this.Controls)
            {
                if (x.GetType() != typeof(StatusStrip))
                    x.Enabled = false;
            }
        }

        public void HandleChildFormOnHideEvent()
        {
            btnHideFilterList.Enabled = false;
            btnShowFilterList.Enabled = true;
        }

        private void btnShowFilterList_Click(object sender, EventArgs e)
        {
            btnHideFilterList.Enabled = true;
            btnShowFilterList.Enabled = false;
            dlgFilterList.Show();
        }

        private void btnHideFilterList_Click(object sender, EventArgs e)
        {
            btnHideFilterList.Enabled = false;
            btnShowFilterList.Enabled = true;
            dlgFilterList.Hide();
        }

        private void gridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnOpenDevice_Click(sender, e);
            }
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Space)
            {
                btnOpenDevice_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnClearLogBox_ButtonClick(object sender, EventArgs e)
        {
            tbLog.Clear();
        }

        private void frmListDevices_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device_list == null)
                return;

            SortedList<UInt64, Form> local_list = new SortedList<UInt64, Form>(device_list);

            if (local_list.Count() == 0)
                return;

            foreach (KeyValuePair<UInt64, Form> item in local_list)
            {
                try
                {
                    item.Value.Close();
                }
                catch (Exception exception)
                {
                    Helper.AppendText(tbLog, exception.Message, Color.Red);
                    Helper.SetStatusErr(statusLabel);
                    return;
                }
            }
        }
    }
}
