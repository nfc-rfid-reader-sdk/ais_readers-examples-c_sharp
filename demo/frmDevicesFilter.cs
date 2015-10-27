using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DL_AIS_Readers
{
    public partial class frmFilterList : Form
    {
        RichTextBox tbLog;
        ToolStripStatusLabel statusLabel;
        public delegate void ChildFormOnHideEventHandler();
        public event ChildFormOnHideEventHandler ChildFormOnHideEvent;

        public frmFilterList(RichTextBox tb_log, ToolStripStatusLabel status_label)
        {
            tbLog = tb_log;
            statusLabel = status_label;
            InitializeComponent();
        }

        private void frmFilterList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        public void frmInit()
        {
            string raw_default_filter_list;
            string[] names = Enum.GetNames(typeof(DEVICE_TYPES));

            for (UInt32 i = 0; i < names.Length; i++)
            {
                cbList.Items.Add(names[i]);
            }
            Helper.SetAutoDropDownWidth(cbList);
            cbList.SelectedIndex = 0;

            SetupDataGridView();

            raw_default_filter_list = ais_readers.AIS_List_GetDevicesForCheck();
            populateGrid(raw_default_filter_list, true);
        }

        private void SetupDataGridView()
        {
            gridView.ColumnCount = 3;

            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            gridView.Columns[0].Name = "Device Type Id";
            gridView.Columns[1].Name = "Device Type";
            gridView.Columns[2].Name = "Id";
        }

        private void frmFilterList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                ChildFormOnHideEvent();
            }
        }

        private void bListAdd_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            string status_msg;
            string[] names = Enum.GetNames(typeof(DEVICE_TYPES));
            UInt32[] values = (UInt32[])Enum.GetValues(typeof(DEVICE_TYPES));

            try
            {
                UInt32 device_mark = values[cbList.SelectedIndex];
                UInt32 device_id = Convert.ToUInt32(tbId.Text);

                status = ais_readers.AIS_List_AddDeviceForCheck(device_mark, device_id);
                if (status != DL_STATUS.DL_OK)
                {
                    status_msg = ais_readers.status2str(status);
                    throw new Exception("AIS status: " + status_msg);
                }
                else
                {
                    string[] new_row = new string[] { device_mark.ToString(), names[cbList.SelectedIndex].ToString(), device_id.ToString() };
                    gridView.Rows.Add(new_row);
                    gridView.ClearSelection();
                    Helper.AppendText(tbLog, ""
                        + names[cbList.SelectedIndex]
                        + " device with Id: "
                        + device_id
                        + " successfully aded to search list.\n", Color.Green);
                    Helper.SetStatusOk(statusLabel);
                }
            }
            catch (Exception exception)
            {
                Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
                return;
            }
        }

        private void bListClear_Click(object sender, EventArgs e)
        {
            ais_readers.AIS_List_EraseAllDevicesForCheck();
            gridView.Rows.Clear();
            Helper.AppendText(tbLog, "Filter list cleared.\n", Color.Green);
            Helper.SetStatusOk(statusLabel);
        }

        private void gridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string device_name;
                string[] names = Enum.GetNames(typeof(DEVICE_TYPES));
                UInt32[] values = (UInt32[])Enum.GetValues(typeof(DEVICE_TYPES));
                UInt32 device_mark, device_id;
                Int32 idx;

                device_mark = Convert.ToUInt32(gridView.SelectedRows[0].Cells[0].Value);
                device_name = gridView.SelectedRows[0].Cells[1].Value.ToString();
                device_id = Convert.ToUInt32(gridView.SelectedRows[0].Cells[2].Value);
                if (values.Contains(device_mark))
                {
                    idx = Array.FindIndex(names, name => name.Contains(device_name));
                    cbList.SelectedIndex = idx;
                    tbId.Text = device_id.ToString();
                }
            }
        }

        private void bListDel_Click(object sender, EventArgs e)
        {
            DL_STATUS status;
            string status_msg;
            string[] names = Enum.GetNames(typeof(DEVICE_TYPES));
            UInt32[] values = (UInt32[])Enum.GetValues(typeof(DEVICE_TYPES));

            try
            {
                UInt32 device_mark = values[cbList.SelectedIndex];
                UInt32 device_id = Convert.ToUInt32(tbId.Text);

                status = ais_readers.AIS_List_EraseDeviceForCheck(device_mark, device_id);
                if (status != DL_STATUS.DL_OK)
                {
                    status_msg = ais_readers.status2str(status);
                    throw new Exception("AIS status: " + status_msg);
                }
                else
                {
                    DataGridViewRow row = gridView.Rows
                        .Cast<DataGridViewRow>()
                        .Where(m => m.Cells["Device Type Id"].Value.ToString().Equals(device_mark.ToString()))
                        .Where(m => m.Cells["Id"].Value.ToString().Equals(device_id.ToString()))
                        .First();

                    gridView.Rows.Remove(row);
                    gridView.ClearSelection();
                    Helper.AppendText(tbLog, "Device successfully removed from the filter list.\n", Color.Green);
                    Helper.SetStatusOk(statusLabel);
                }
            }
            catch (Exception exception)
            {
                Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                Helper.SetStatusErr(statusLabel);
                return;
            }
        }

        private void frmFilterList_VisibleChanged(object sender, EventArgs e)
        {
            gridView.ClearSelection();
        }


        public void OuterListAdd(Int32 device_idx, UInt32 device_id)
        {
            cbList.SelectedIndex = device_idx;
            tbId.Text = device_id.ToString();
            bListAdd_Click(this, new EventArgs());
        }

        public void OuterListDel(Int32 device_idx, UInt32 device_id)
        {
            cbList.SelectedIndex = device_idx;
            tbId.Text = device_id.ToString();
            bListDel_Click(this, new EventArgs());
        }

        public void OuterListClear()
        {
            bListClear_Click(this, new EventArgs());
        }

        private bool populateGrid(string s_search_list, bool init_flag)
        {
            DL_STATUS status;
            string status_msg;
            bool device_added = false;
            string[] as_list_items;
            char[] delimiters = { ':', ';', '.', ',', ' ', '\t' };
            string[] line_delimiters = { "\r\n", "\r", "\n" };
            string[] names = Enum.GetNames(typeof(DEVICE_TYPES));
            UInt32[] values = (UInt32[])Enum.GetValues(typeof(DEVICE_TYPES));
            string[] str_values = new string[values.Count()];

            for (UInt32 i = 0; i < values.Count(); i++)
                str_values[i] = values[i].ToString();

            as_list_items = s_search_list.Split(line_delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (Int32 i = 0; i < as_list_items.Count(); i++)
            {
                string[] value_pair = as_list_items[i].Split(delimiters);
                if ((value_pair.Count() != 2)
                    || !Helper.IsStringNumericDigitsOnly(value_pair[0])
                    || !Helper.IsStringNumericDigitsOnly(value_pair[1]))
                {
                    Helper.AppendText(tbLog, "Warning: error in file at row " + i + ".\n", Color.Purple);
                    Helper.SetStatusWarning(statusLabel);
                    continue;
                }

                try
                {
                    UInt32 device_mark = Convert.ToUInt32(value_pair[0]);
                    UInt32 device_id = Convert.ToUInt32(value_pair[1]);

                    if (!init_flag)
                    {
                        status = ais_readers.AIS_List_AddDeviceForCheck(device_mark, device_id);
                    }
                    else
                    {
                        status = DL_STATUS.DL_OK;
                    }

                    if (status != DL_STATUS.DL_OK)
                    {
                        status_msg = ais_readers.status2str(status);
                        throw new Exception("AIS status: " + status_msg);
                    }
                    else
                    {
                        Int32 idx = Array.FindIndex(str_values, val => val.Contains(device_mark.ToString()));
                        string[] new_row = new string[] { device_mark.ToString(), names[idx].ToString(), device_id.ToString() };
                        gridView.Rows.Add(new_row);
                        gridView.ClearSelection();

                        if (!init_flag)
                        {
                            Helper.AppendText(tbLog, ""
                                + names[cbList.SelectedIndex]
                                + " device with Id: "
                                + device_id
                                + " successfully aded to search list.\n", Color.Green);
                            Helper.SetStatusOk(statusLabel);
                        }
                        device_added = true;
                    }
                }
                catch (Exception exception)
                {
                    Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                    Helper.SetStatusErr(statusLabel);
                }
            }
            return device_added;
        }

        private void btnListLoad_Click(object sender, EventArgs e)
        {
            bool device_from_file_added = false;
            string s_search_list = "";
            string path;

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
                    s_search_list = File.ReadAllText(path, Encoding.ASCII);
                }
                catch (Exception exception)
                {
                    Helper.AppendText(tbLog, "Error while reading file from disc: ", Color.Red);
                    Helper.AppendText(tbLog, exception.Message + "\n", Color.Red);
                    Helper.SetStatusErr(statusLabel);
                    return;
                }

                ais_readers.AIS_List_EraseAllDevicesForCheck();
                gridView.Rows.Clear();

                device_from_file_added = populateGrid(s_search_list, false);

                if (device_from_file_added)
                {
                    Helper.AppendText(tbLog, "File succesfuly read from disc.\n", Color.Green);
                    Helper.SetStatusOk(statusLabel);
                }
                else
                {
                    Helper.AppendText(tbLog, "None of the devices specified in file added to a list. Does the format of the file is correct?\n", Color.Red);
                    Helper.SetStatusErr(statusLabel);
                }
            }
        }

        private void btnListSave_Click(object sender, EventArgs e)
        {
            string str_serch_list = "";
            string path;
            DialogResult result;
            SaveFileDialog file_dialog = new SaveFileDialog();

            file_dialog.FileName = "search_list";
            file_dialog.DefaultExt = "txt";
            file_dialog.Filter = "txt files (*.txt)|*.txt|coma separated values (*.csv)|*.csv|All files (*.*)|*.*";
            file_dialog.FilterIndex = 1;
            file_dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();

            result = file_dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = file_dialog.FileName;

                for (Int32 i = 0; i <  gridView.Rows.Count; i++)
                {
                    if (i > 0)
                    {
                        str_serch_list += "\r\n";
                    }
                    str_serch_list += gridView.Rows[i].Cells[0].Value.ToString();
                    str_serch_list += ",";
                    str_serch_list += gridView.Rows[i].Cells[2].Value.ToString();
                }

                try
                {
                    File.WriteAllText(path, str_serch_list, Encoding.ASCII);
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
    }
}
