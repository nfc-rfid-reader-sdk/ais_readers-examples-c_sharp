using System.Text;

namespace DL_AIS_Readers
{
    partial class frmSelectedDevice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClearLogBox = new System.Windows.Forms.ToolStripSplitButton();
            this.spacerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.lbDeviceId = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnGetTime = new System.Windows.Forms.Button();
            this.btnSubmitLocalDateTime = new System.Windows.Forms.Button();
            this.tbDateTimeLocal = new System.Windows.Forms.TextBox();
            this.btnSubmitDateTime = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimeDevice = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSubmitPassword = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRepeatPasswd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNewPasswd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOldPasswd = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.tbInfo = new System.Windows.Forms.RichTextBox();
            this.gbAdminPassword = new System.Windows.Forms.GroupBox();
            this.btnSetAdminPassword = new System.Windows.Forms.Button();
            this.tbAdminPassword = new System.Windows.Forms.TextBox();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.gbGetLogByIndex = new System.Windows.Forms.GroupBox();
            this.chkGetLogByIndex = new System.Windows.Forms.CheckBox();
            this.numIndexTo = new System.Windows.Forms.NumericUpDown();
            this.numIndexFrom = new System.Windows.Forms.NumericUpDown();
            this.lblbIndexTo = new System.Windows.Forms.Label();
            this.lbIndexFrom = new System.Windows.Forms.Label();
            this.btnGetWholeLog = new System.Windows.Forms.Button();
            this.gridLog = new System.Windows.Forms.DataGridView();
            this.tabPageRTE = new System.Windows.Forms.TabPage();
            this.btnStartRTEMonitor = new System.Windows.Forms.Button();
            this.btnStopRTEMonitor = new System.Windows.Forms.Button();
            this.gridRTE = new System.Windows.Forms.DataGridView();
            this.tabPageBlacklist = new System.Windows.Forms.TabPage();
            this.btnWriteBlackList = new System.Windows.Forms.Button();
            this.gbBlackList = new System.Windows.Forms.GroupBox();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.btnListRemove = new System.Windows.Forms.Button();
            this.BtnListImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnListClear = new System.Windows.Forms.Button();
            this.btnListPut = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.tbListCardSn = new System.Windows.Forms.TextBox();
            this.gbSingle = new System.Windows.Forms.GroupBox();
            this.btnSingledUnblockCard = new System.Windows.Forms.Button();
            this.btnSingleBlockCard = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tbSingleCardSn = new System.Windows.Forms.TextBox();
            this.lstBlacklist = new System.Windows.Forms.ListBox();
            this.btnReadBlackList = new System.Windows.Forms.Button();
            this.tabPageSecPass = new System.Windows.Forms.TabPage();
            this.gbUIDWhitelist = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tbWhitelistUid = new System.Windows.Forms.MaskedTextBox();
            this.btnWriteWhitelist = new System.Windows.Forms.Button();
            this.btnReadWhitelist = new System.Windows.Forms.Button();
            this.btnRemoveFromWhitelist = new System.Windows.Forms.Button();
            this.btnImportWhitelist = new System.Windows.Forms.Button();
            this.btnExportWhitelist = new System.Windows.Forms.Button();
            this.btnClearWhitelist = new System.Windows.Forms.Button();
            this.btnPutOnWhitelist = new System.Windows.Forms.Button();
            this.lbWhitelistUid = new System.Windows.Forms.Label();
            this.gbDeviceUserInterface = new System.Windows.Forms.GroupBox();
            this.chkGreenSlave = new System.Windows.Forms.CheckBox();
            this.chkRedSlave = new System.Windows.Forms.CheckBox();
            this.chkRelayState = new System.Windows.Forms.CheckBox();
            this.chkDoorState = new System.Windows.Forms.CheckBox();
            this.chkIntercomState = new System.Windows.Forms.CheckBox();
            this.btnSetLight = new System.Windows.Forms.Button();
            this.chkGreenMaster = new System.Windows.Forms.CheckBox();
            this.chkRedMaster = new System.Windows.Forms.CheckBox();
            this.btnRelayOff = new System.Windows.Forms.Button();
            this.btnRelayOn = new System.Windows.Forms.Button();
            this.lbDurationUnit = new System.Windows.Forms.Label();
            this.lbDuration = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.btnLockOpen = new System.Windows.Forms.Button();
            this.lstWhitelist = new System.Windows.Forms.ListBox();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbAdminPassword.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.gbGetLogByIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIndexTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIndexFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLog)).BeginInit();
            this.tabPageRTE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRTE)).BeginInit();
            this.tabPageBlacklist.SuspendLayout();
            this.gbBlackList.SuspendLayout();
            this.gbList.SuspendLayout();
            this.gbSingle.SuspendLayout();
            this.tabPageSecPass.SuspendLayout();
            this.gbUIDWhitelist.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.gbDeviceUserInterface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.btnClearLogBox,
            this.spacerLabel,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 534);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabel.ForeColor = System.Drawing.Color.Green;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(270, 17);
            this.statusLabel.Text = "Status Ok ";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClearLogBox
            // 
            this.btnClearLogBox.BackColor = System.Drawing.SystemColors.Control;
            this.btnClearLogBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearLogBox.DropDownButtonWidth = 0;
            this.btnClearLogBox.ForeColor = System.Drawing.Color.Blue;
            this.btnClearLogBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearLogBox.Name = "btnClearLogBox";
            this.btnClearLogBox.Size = new System.Drawing.Size(84, 20);
            this.btnClearLogBox.Text = "Clear Log Box";
            this.btnClearLogBox.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnClearLogBox.ButtonClick += new System.EventHandler(this.btnClearLogBox_ButtonClick);
            // 
            // spacerLabel
            // 
            this.spacerLabel.AutoSize = false;
            this.spacerLabel.Name = "spacerLabel";
            this.spacerLabel.Size = new System.Drawing.Size(200, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel1.Text = "Log Progress:";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Margin = new System.Windows.Forms.Padding(3);
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.ToolTipText = "Log progress";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.Controls.Add(this.tabControl);
            this.splitContainer.Panel1MinSize = 340;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbLog);
            this.splitContainer.Panel2MinSize = 190;
            this.splitContainer.Size = new System.Drawing.Size(784, 534);
            this.splitContainer.SplitterDistance = 340;
            this.splitContainer.TabIndex = 50;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageInfo);
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Controls.Add(this.tabPageRTE);
            this.tabControl.Controls.Add(this.tabPageBlacklist);
            this.tabControl.Controls.Add(this.tabPageSecPass);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(784, 340);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.lbDeviceId);
            this.tabPageInfo.Controls.Add(this.groupBox5);
            this.tabPageInfo.Controls.Add(this.groupBox4);
            this.tabPageInfo.Controls.Add(this.groupBox2);
            this.tabPageInfo.Controls.Add(this.gbAdminPassword);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(776, 314);
            this.tabPageInfo.TabIndex = 1;
            this.tabPageInfo.Text = "Device Info";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // lbDeviceId
            // 
            this.lbDeviceId.AutoSize = true;
            this.lbDeviceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbDeviceId.Location = new System.Drawing.Point(15, 14);
            this.lbDeviceId.Name = "lbDeviceId";
            this.lbDeviceId.Size = new System.Drawing.Size(66, 13);
            this.lbDeviceId.TabIndex = 0;
            this.lbDeviceId.Text = "Device Id:";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.btnGetTime);
            this.groupBox5.Controls.Add(this.btnSubmitLocalDateTime);
            this.groupBox5.Controls.Add(this.tbDateTimeLocal);
            this.groupBox5.Controls.Add(this.btnSubmitDateTime);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.dateTimeDevice);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(403, 162);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox5.Size = new System.Drawing.Size(358, 139);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Date and time (UTC):";
            // 
            // btnGetTime
            // 
            this.btnGetTime.Location = new System.Drawing.Point(13, 24);
            this.btnGetTime.Name = "btnGetTime";
            this.btnGetTime.Size = new System.Drawing.Size(91, 25);
            this.btnGetTime.TabIndex = 0;
            this.btnGetTime.Text = "Get from device";
            this.btnGetTime.UseVisualStyleBackColor = true;
            this.btnGetTime.Click += new System.EventHandler(this.btnGetTime_Click);
            // 
            // btnSubmitLocalDateTime
            // 
            this.btnSubmitLocalDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitLocalDateTime.Location = new System.Drawing.Point(59, 104);
            this.btnSubmitLocalDateTime.Name = "btnSubmitLocalDateTime";
            this.btnSubmitLocalDateTime.Size = new System.Drawing.Size(140, 25);
            this.btnSubmitLocalDateTime.TabIndex = 5;
            this.btnSubmitLocalDateTime.Text = "Submit Local DateTime";
            this.btnSubmitLocalDateTime.UseVisualStyleBackColor = true;
            this.btnSubmitLocalDateTime.Click += new System.EventHandler(this.btnSubmitLocalDateTime_Click);
            // 
            // tbDateTimeLocal
            // 
            this.tbDateTimeLocal.Location = new System.Drawing.Point(205, 53);
            this.tbDateTimeLocal.Name = "tbDateTimeLocal";
            this.tbDateTimeLocal.ReadOnly = true;
            this.tbDateTimeLocal.Size = new System.Drawing.Size(140, 20);
            this.tbDateTimeLocal.TabIndex = 4;
            // 
            // btnSubmitDateTime
            // 
            this.btnSubmitDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitDateTime.Enabled = false;
            this.btnSubmitDateTime.Location = new System.Drawing.Point(205, 104);
            this.btnSubmitDateTime.Name = "btnSubmitDateTime";
            this.btnSubmitDateTime.Size = new System.Drawing.Size(140, 25);
            this.btnSubmitDateTime.TabIndex = 6;
            this.btnSubmitDateTime.Text = "Submit DateTime";
            this.btnSubmitDateTime.UseVisualStyleBackColor = true;
            this.btnSubmitDateTime.Click += new System.EventHandler(this.btnSubmitDateTime_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Local DateTime:";
            // 
            // dateTimeDevice
            // 
            this.dateTimeDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeDevice.CustomFormat = "d.M.yyyy. HH:mm:ss";
            this.dateTimeDevice.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDevice.Location = new System.Drawing.Point(205, 26);
            this.dateTimeDevice.Name = "dateTimeDevice";
            this.dateTimeDevice.Size = new System.Drawing.Size(140, 20);
            this.dateTimeDevice.TabIndex = 2;
            this.dateTimeDevice.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Device DateTime:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnSubmitPassword);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.tbRepeatPasswd);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tbNewPasswd);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.tbOldPasswd);
            this.groupBox4.Location = new System.Drawing.Point(403, 10);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox4.Size = new System.Drawing.Size(358, 141);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Change password:";
            // 
            // btnSubmitPassword
            // 
            this.btnSubmitPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitPassword.Location = new System.Drawing.Point(138, 105);
            this.btnSubmitPassword.Name = "btnSubmitPassword";
            this.btnSubmitPassword.Size = new System.Drawing.Size(207, 23);
            this.btnSubmitPassword.TabIndex = 6;
            this.btnSubmitPassword.Text = "Submit password";
            this.btnSubmitPassword.UseVisualStyleBackColor = true;
            this.btnSubmitPassword.Click += new System.EventHandler(this.btnSubmitPassword_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Repeat new password:";
            // 
            // tbRepeatPasswd
            // 
            this.tbRepeatPasswd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRepeatPasswd.Location = new System.Drawing.Point(138, 75);
            this.tbRepeatPasswd.Name = "tbRepeatPasswd";
            this.tbRepeatPasswd.Size = new System.Drawing.Size(207, 20);
            this.tbRepeatPasswd.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "New password:";
            // 
            // tbNewPasswd
            // 
            this.tbNewPasswd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNewPasswd.Location = new System.Drawing.Point(138, 49);
            this.tbNewPasswd.Name = "tbNewPasswd";
            this.tbNewPasswd.Size = new System.Drawing.Size(207, 20);
            this.tbNewPasswd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Old password:";
            // 
            // tbOldPasswd
            // 
            this.tbOldPasswd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOldPasswd.Location = new System.Drawing.Point(138, 23);
            this.tbOldPasswd.Name = "tbOldPasswd";
            this.tbOldPasswd.Size = new System.Drawing.Size(207, 20);
            this.tbOldPasswd.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnGetInfo);
            this.groupBox2.Controls.Add(this.tbInfo);
            this.groupBox2.Location = new System.Drawing.Point(10, 108);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(377, 193);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info:";
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetInfo.Location = new System.Drawing.Point(225, 158);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(142, 25);
            this.btnGetInfo.TabIndex = 1;
            this.btnGetInfo.Text = "Get Info";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfo.Location = new System.Drawing.Point(10, 23);
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new System.Drawing.Size(357, 129);
            this.tbInfo.TabIndex = 0;
            this.tbInfo.Text = "";
            // 
            // gbAdminPassword
            // 
            this.gbAdminPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAdminPassword.Controls.Add(this.btnSetAdminPassword);
            this.gbAdminPassword.Controls.Add(this.tbAdminPassword);
            this.gbAdminPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbAdminPassword.Location = new System.Drawing.Point(10, 37);
            this.gbAdminPassword.Margin = new System.Windows.Forms.Padding(10);
            this.gbAdminPassword.Name = "gbAdminPassword";
            this.gbAdminPassword.Padding = new System.Windows.Forms.Padding(10);
            this.gbAdminPassword.Size = new System.Drawing.Size(377, 61);
            this.gbAdminPassword.TabIndex = 1;
            this.gbAdminPassword.TabStop = false;
            this.gbAdminPassword.Text = "AdminPassword: ";
            // 
            // btnSetAdminPassword
            // 
            this.btnSetAdminPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetAdminPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSetAdminPassword.Location = new System.Drawing.Point(225, 24);
            this.btnSetAdminPassword.Name = "btnSetAdminPassword";
            this.btnSetAdminPassword.Size = new System.Drawing.Size(142, 25);
            this.btnSetAdminPassword.TabIndex = 1;
            this.btnSetAdminPassword.Text = "Set Admin Password";
            this.btnSetAdminPassword.UseVisualStyleBackColor = true;
            this.btnSetAdminPassword.Click += new System.EventHandler(this.btnSetAdminPassword_Click);
            // 
            // tbAdminPassword
            // 
            this.tbAdminPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAdminPassword.Location = new System.Drawing.Point(10, 26);
            this.tbAdminPassword.Name = "tbAdminPassword";
            this.tbAdminPassword.Size = new System.Drawing.Size(203, 20);
            this.tbAdminPassword.TabIndex = 0;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.gbGetLogByIndex);
            this.tabPageLog.Controls.Add(this.btnGetWholeLog);
            this.tabPageLog.Controls.Add(this.gridLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(776, 314);
            this.tabPageLog.TabIndex = 2;
            this.tabPageLog.Text = "Device Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // gbGetLogByIndex
            // 
            this.gbGetLogByIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGetLogByIndex.Controls.Add(this.chkGetLogByIndex);
            this.gbGetLogByIndex.Controls.Add(this.numIndexTo);
            this.gbGetLogByIndex.Controls.Add(this.numIndexFrom);
            this.gbGetLogByIndex.Controls.Add(this.lblbIndexTo);
            this.gbGetLogByIndex.Controls.Add(this.lbIndexFrom);
            this.gbGetLogByIndex.Location = new System.Drawing.Point(620, 9);
            this.gbGetLogByIndex.Name = "gbGetLogByIndex";
            this.gbGetLogByIndex.Size = new System.Drawing.Size(142, 137);
            this.gbGetLogByIndex.TabIndex = 2;
            this.gbGetLogByIndex.TabStop = false;
            // 
            // chkGetLogByIndex
            // 
            this.chkGetLogByIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGetLogByIndex.AutoSize = true;
            this.chkGetLogByIndex.Location = new System.Drawing.Point(9, 14);
            this.chkGetLogByIndex.Name = "chkGetLogByIndex";
            this.chkGetLogByIndex.Size = new System.Drawing.Size(107, 17);
            this.chkGetLogByIndex.TabIndex = 6;
            this.chkGetLogByIndex.Text = "Get Log by Index";
            this.chkGetLogByIndex.UseVisualStyleBackColor = true;
            // 
            // numIndexTo
            // 
            this.numIndexTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numIndexTo.Location = new System.Drawing.Point(9, 103);
            this.numIndexTo.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numIndexTo.Name = "numIndexTo";
            this.numIndexTo.Size = new System.Drawing.Size(123, 20);
            this.numIndexTo.TabIndex = 5;
            this.numIndexTo.Validated += new System.EventHandler(this.numIndexTo_Validated);
            // 
            // numIndexFrom
            // 
            this.numIndexFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numIndexFrom.Location = new System.Drawing.Point(9, 59);
            this.numIndexFrom.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numIndexFrom.Name = "numIndexFrom";
            this.numIndexFrom.Size = new System.Drawing.Size(123, 20);
            this.numIndexFrom.TabIndex = 3;
            this.numIndexFrom.Validated += new System.EventHandler(this.numIndexFrom_Validated);
            // 
            // lblbIndexTo
            // 
            this.lblbIndexTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbIndexTo.AutoSize = true;
            this.lblbIndexTo.Location = new System.Drawing.Point(6, 87);
            this.lblbIndexTo.Name = "lblbIndexTo";
            this.lblbIndexTo.Size = new System.Drawing.Size(48, 13);
            this.lblbIndexTo.TabIndex = 2;
            this.lblbIndexTo.Text = "Index to:";
            // 
            // lbIndexFrom
            // 
            this.lbIndexFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIndexFrom.AutoSize = true;
            this.lbIndexFrom.Location = new System.Drawing.Point(6, 43);
            this.lbIndexFrom.Name = "lbIndexFrom";
            this.lbIndexFrom.Size = new System.Drawing.Size(59, 13);
            this.lbIndexFrom.TabIndex = 0;
            this.lbIndexFrom.Text = "Index from:";
            // 
            // btnGetWholeLog
            // 
            this.btnGetWholeLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetWholeLog.Location = new System.Drawing.Point(620, 156);
            this.btnGetWholeLog.Name = "btnGetWholeLog";
            this.btnGetWholeLog.Size = new System.Drawing.Size(142, 23);
            this.btnGetWholeLog.TabIndex = 1;
            this.btnGetWholeLog.Text = "Get Log";
            this.btnGetWholeLog.UseVisualStyleBackColor = true;
            this.btnGetWholeLog.Click += new System.EventHandler(this.btnGetWholeLog_Click);
            // 
            // gridLog
            // 
            this.gridLog.AllowUserToAddRows = false;
            this.gridLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLog.GridColor = System.Drawing.Color.Black;
            this.gridLog.Location = new System.Drawing.Point(15, 15);
            this.gridLog.MultiSelect = false;
            this.gridLog.Name = "gridLog";
            this.gridLog.ReadOnly = true;
            this.gridLog.RowHeadersVisible = false;
            this.gridLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLog.Size = new System.Drawing.Size(590, 286);
            this.gridLog.TabIndex = 0;
            // 
            // tabPageRTE
            // 
            this.tabPageRTE.Controls.Add(this.btnStartRTEMonitor);
            this.tabPageRTE.Controls.Add(this.btnStopRTEMonitor);
            this.tabPageRTE.Controls.Add(this.gridRTE);
            this.tabPageRTE.Location = new System.Drawing.Point(4, 22);
            this.tabPageRTE.Name = "tabPageRTE";
            this.tabPageRTE.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRTE.Size = new System.Drawing.Size(776, 314);
            this.tabPageRTE.TabIndex = 3;
            this.tabPageRTE.Text = "Device RTE";
            this.tabPageRTE.UseVisualStyleBackColor = true;
            // 
            // btnStartRTEMonitor
            // 
            this.btnStartRTEMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartRTEMonitor.Location = new System.Drawing.Point(620, 249);
            this.btnStartRTEMonitor.Name = "btnStartRTEMonitor";
            this.btnStartRTEMonitor.Size = new System.Drawing.Size(142, 23);
            this.btnStartRTEMonitor.TabIndex = 1;
            this.btnStartRTEMonitor.Text = "Start RTE Monitor";
            this.btnStartRTEMonitor.UseVisualStyleBackColor = true;
            this.btnStartRTEMonitor.Click += new System.EventHandler(this.btnStartRTEMonitor_Click);
            // 
            // btnStopRTEMonitor
            // 
            this.btnStopRTEMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopRTEMonitor.Enabled = false;
            this.btnStopRTEMonitor.Location = new System.Drawing.Point(620, 278);
            this.btnStopRTEMonitor.Name = "btnStopRTEMonitor";
            this.btnStopRTEMonitor.Size = new System.Drawing.Size(142, 23);
            this.btnStopRTEMonitor.TabIndex = 2;
            this.btnStopRTEMonitor.Text = "Stop RTE Monitor";
            this.btnStopRTEMonitor.UseVisualStyleBackColor = true;
            this.btnStopRTEMonitor.Click += new System.EventHandler(this.btnStopRTEMonitor_Click);
            // 
            // gridRTE
            // 
            this.gridRTE.AllowUserToAddRows = false;
            this.gridRTE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRTE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridRTE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRTE.GridColor = System.Drawing.Color.Black;
            this.gridRTE.Location = new System.Drawing.Point(15, 15);
            this.gridRTE.MultiSelect = false;
            this.gridRTE.Name = "gridRTE";
            this.gridRTE.ReadOnly = true;
            this.gridRTE.RowHeadersVisible = false;
            this.gridRTE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRTE.Size = new System.Drawing.Size(590, 286);
            this.gridRTE.TabIndex = 0;
            // 
            // tabPageBlacklist
            // 
            this.tabPageBlacklist.Controls.Add(this.btnWriteBlackList);
            this.tabPageBlacklist.Controls.Add(this.gbBlackList);
            this.tabPageBlacklist.Controls.Add(this.btnReadBlackList);
            this.tabPageBlacklist.Location = new System.Drawing.Point(4, 22);
            this.tabPageBlacklist.Name = "tabPageBlacklist";
            this.tabPageBlacklist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBlacklist.Size = new System.Drawing.Size(776, 314);
            this.tabPageBlacklist.TabIndex = 4;
            this.tabPageBlacklist.Text = "Device Blacklist";
            this.tabPageBlacklist.UseVisualStyleBackColor = true;
            // 
            // btnWriteBlackList
            // 
            this.btnWriteBlackList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWriteBlackList.Location = new System.Drawing.Point(571, 11);
            this.btnWriteBlackList.Name = "btnWriteBlackList";
            this.btnWriteBlackList.Size = new System.Drawing.Size(191, 23);
            this.btnWriteBlackList.TabIndex = 1;
            this.btnWriteBlackList.Text = "Write Blacklist to device";
            this.btnWriteBlackList.UseVisualStyleBackColor = true;
            this.btnWriteBlackList.Click += new System.EventHandler(this.btnWriteBlackList_Click);
            // 
            // gbBlackList
            // 
            this.gbBlackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBlackList.Controls.Add(this.gbList);
            this.gbBlackList.Controls.Add(this.gbSingle);
            this.gbBlackList.Controls.Add(this.lstBlacklist);
            this.gbBlackList.Location = new System.Drawing.Point(12, 37);
            this.gbBlackList.Name = "gbBlackList";
            this.gbBlackList.Size = new System.Drawing.Size(750, 265);
            this.gbBlackList.TabIndex = 2;
            this.gbBlackList.TabStop = false;
            // 
            // gbList
            // 
            this.gbList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbList.Controls.Add(this.btnListRemove);
            this.gbList.Controls.Add(this.BtnListImport);
            this.gbList.Controls.Add(this.btnExport);
            this.gbList.Controls.Add(this.btnListClear);
            this.gbList.Controls.Add(this.btnListPut);
            this.gbList.Controls.Add(this.label16);
            this.gbList.Controls.Add(this.tbListCardSn);
            this.gbList.Location = new System.Drawing.Point(328, 11);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(200, 244);
            this.gbList.TabIndex = 1;
            this.gbList.TabStop = false;
            this.gbList.Text = "Card list actions:";
            // 
            // btnListRemove
            // 
            this.btnListRemove.Location = new System.Drawing.Point(9, 90);
            this.btnListRemove.Name = "btnListRemove";
            this.btnListRemove.Size = new System.Drawing.Size(185, 23);
            this.btnListRemove.TabIndex = 3;
            this.btnListRemove.Text = "Remove from the list";
            this.btnListRemove.UseVisualStyleBackColor = true;
            this.btnListRemove.Click += new System.EventHandler(this.btnListRemove_Click);
            // 
            // BtnListImport
            // 
            this.BtnListImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnListImport.Location = new System.Drawing.Point(9, 211);
            this.BtnListImport.Name = "BtnListImport";
            this.BtnListImport.Size = new System.Drawing.Size(185, 23);
            this.BtnListImport.TabIndex = 6;
            this.BtnListImport.Text = "Import list from .CSV";
            this.BtnListImport.UseVisualStyleBackColor = true;
            this.BtnListImport.Click += new System.EventHandler(this.BtnListImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(9, 182);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(185, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export list to .CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnListClear
            // 
            this.btnListClear.Location = new System.Drawing.Point(9, 119);
            this.btnListClear.Name = "btnListClear";
            this.btnListClear.Size = new System.Drawing.Size(185, 23);
            this.btnListClear.TabIndex = 4;
            this.btnListClear.Text = "Clear list";
            this.btnListClear.UseVisualStyleBackColor = true;
            this.btnListClear.Click += new System.EventHandler(this.btnListClear_Click);
            // 
            // btnListPut
            // 
            this.btnListPut.Location = new System.Drawing.Point(9, 61);
            this.btnListPut.Name = "btnListPut";
            this.btnListPut.Size = new System.Drawing.Size(185, 23);
            this.btnListPut.TabIndex = 2;
            this.btnListPut.Text = "Put on the list";
            this.btnListPut.UseVisualStyleBackColor = true;
            this.btnListPut.Click += new System.EventHandler(this.btnListPut_Click);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Card SN:";
            // 
            // tbListCardSn
            // 
            this.tbListCardSn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbListCardSn.Font = new System.Drawing.Font("Courier New", 8F);
            this.tbListCardSn.Location = new System.Drawing.Point(66, 26);
            this.tbListCardSn.Name = "tbListCardSn";
            this.tbListCardSn.Size = new System.Drawing.Size(128, 20);
            this.tbListCardSn.TabIndex = 1;
            // 
            // gbSingle
            // 
            this.gbSingle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSingle.Controls.Add(this.btnSingledUnblockCard);
            this.gbSingle.Controls.Add(this.btnSingleBlockCard);
            this.gbSingle.Controls.Add(this.label14);
            this.gbSingle.Controls.Add(this.tbSingleCardSn);
            this.gbSingle.Location = new System.Drawing.Point(539, 11);
            this.gbSingle.Name = "gbSingle";
            this.gbSingle.Size = new System.Drawing.Size(200, 244);
            this.gbSingle.TabIndex = 2;
            this.gbSingle.TabStop = false;
            this.gbSingle.Tag = "Single card actions:";
            // 
            // btnSingledUnblockCard
            // 
            this.btnSingledUnblockCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSingledUnblockCard.Location = new System.Drawing.Point(66, 90);
            this.btnSingledUnblockCard.Name = "btnSingledUnblockCard";
            this.btnSingledUnblockCard.Size = new System.Drawing.Size(128, 23);
            this.btnSingledUnblockCard.TabIndex = 3;
            this.btnSingledUnblockCard.Text = "Unblock card";
            this.btnSingledUnblockCard.UseVisualStyleBackColor = true;
            this.btnSingledUnblockCard.Visible = false;
            // 
            // btnSingleBlockCard
            // 
            this.btnSingleBlockCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSingleBlockCard.Location = new System.Drawing.Point(66, 61);
            this.btnSingleBlockCard.Name = "btnSingleBlockCard";
            this.btnSingleBlockCard.Size = new System.Drawing.Size(128, 23);
            this.btnSingleBlockCard.TabIndex = 2;
            this.btnSingleBlockCard.Text = "Block card";
            this.btnSingleBlockCard.UseVisualStyleBackColor = true;
            this.btnSingleBlockCard.Visible = false;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Card SN:";
            this.label14.Visible = false;
            // 
            // tbSingleCardSn
            // 
            this.tbSingleCardSn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSingleCardSn.Location = new System.Drawing.Point(66, 26);
            this.tbSingleCardSn.Name = "tbSingleCardSn";
            this.tbSingleCardSn.Size = new System.Drawing.Size(128, 20);
            this.tbSingleCardSn.TabIndex = 1;
            this.tbSingleCardSn.Visible = false;
            // 
            // lstBlacklist
            // 
            this.lstBlacklist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBlacklist.Font = new System.Drawing.Font("Courier New", 8F);
            this.lstBlacklist.FormattingEnabled = true;
            this.lstBlacklist.ItemHeight = 14;
            this.lstBlacklist.Location = new System.Drawing.Point(11, 17);
            this.lstBlacklist.Name = "lstBlacklist";
            this.lstBlacklist.Size = new System.Drawing.Size(307, 228);
            this.lstBlacklist.TabIndex = 0;
            this.lstBlacklist.DoubleClick += new System.EventHandler(this.lstBlacklist_DoubleClick);
            // 
            // btnReadBlackList
            // 
            this.btnReadBlackList.Location = new System.Drawing.Point(11, 11);
            this.btnReadBlackList.Name = "btnReadBlackList";
            this.btnReadBlackList.Size = new System.Drawing.Size(191, 23);
            this.btnReadBlackList.TabIndex = 0;
            this.btnReadBlackList.Text = "Read Blacklist from device";
            this.btnReadBlackList.UseVisualStyleBackColor = true;
            this.btnReadBlackList.Click += new System.EventHandler(this.btnReadBlackList_Click);
            // 
            // tabPageSecPass
            // 
            this.tabPageSecPass.Controls.Add(this.gbUIDWhitelist);
            this.tabPageSecPass.Location = new System.Drawing.Point(4, 22);
            this.tabPageSecPass.Name = "tabPageSecPass";
            this.tabPageSecPass.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSecPass.Size = new System.Drawing.Size(776, 314);
            this.tabPageSecPass.TabIndex = 5;
            this.tabPageSecPass.Text = "Device Specific";
            this.tabPageSecPass.UseVisualStyleBackColor = true;
            // 
            // gbUIDWhitelist
            // 
            this.gbUIDWhitelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUIDWhitelist.Controls.Add(this.groupBox9);
            this.gbUIDWhitelist.Controls.Add(this.gbDeviceUserInterface);
            this.gbUIDWhitelist.Controls.Add(this.lstWhitelist);
            this.gbUIDWhitelist.Enabled = false;
            this.gbUIDWhitelist.Location = new System.Drawing.Point(12, 6);
            this.gbUIDWhitelist.Name = "gbUIDWhitelist";
            this.gbUIDWhitelist.Size = new System.Drawing.Size(750, 296);
            this.gbUIDWhitelist.TabIndex = 0;
            this.gbUIDWhitelist.TabStop = false;
            this.gbUIDWhitelist.Text = "UID Whitelist:";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.tbWhitelistUid);
            this.groupBox9.Controls.Add(this.btnWriteWhitelist);
            this.groupBox9.Controls.Add(this.btnReadWhitelist);
            this.groupBox9.Controls.Add(this.btnRemoveFromWhitelist);
            this.groupBox9.Controls.Add(this.btnImportWhitelist);
            this.groupBox9.Controls.Add(this.btnExportWhitelist);
            this.groupBox9.Controls.Add(this.btnClearWhitelist);
            this.groupBox9.Controls.Add(this.btnPutOnWhitelist);
            this.groupBox9.Controls.Add(this.lbWhitelistUid);
            this.groupBox9.Location = new System.Drawing.Point(328, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(200, 270);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "List actions:";
            // 
            // tbWhitelistUid
            // 
            this.tbWhitelistUid.Font = new System.Drawing.Font("Courier New", 8F);
            this.tbWhitelistUid.Location = new System.Drawing.Point(39, 89);
            this.tbWhitelistUid.Mask = ">AA:AA:AA:AA:AA:AA:AA";
            this.tbWhitelistUid.Name = "tbWhitelistUid";
            this.tbWhitelistUid.ShortcutsEnabled = false;
            this.tbWhitelistUid.Size = new System.Drawing.Size(150, 20);
            this.tbWhitelistUid.TabIndex = 3;
            this.tbWhitelistUid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWhitelistUid_KeyDown);
            this.tbWhitelistUid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWhitelistUid_KeyPress);
            // 
            // btnWriteWhitelist
            // 
            this.btnWriteWhitelist.Location = new System.Drawing.Point(9, 53);
            this.btnWriteWhitelist.Name = "btnWriteWhitelist";
            this.btnWriteWhitelist.Size = new System.Drawing.Size(185, 23);
            this.btnWriteWhitelist.TabIndex = 1;
            this.btnWriteWhitelist.Text = "Write Whitelist to device";
            this.btnWriteWhitelist.UseVisualStyleBackColor = true;
            this.btnWriteWhitelist.Click += new System.EventHandler(this.btnWriteWhitelist_Click);
            // 
            // btnReadWhitelist
            // 
            this.btnReadWhitelist.Location = new System.Drawing.Point(9, 24);
            this.btnReadWhitelist.Name = "btnReadWhitelist";
            this.btnReadWhitelist.Size = new System.Drawing.Size(185, 23);
            this.btnReadWhitelist.TabIndex = 0;
            this.btnReadWhitelist.Text = "Read Whitelist from device";
            this.btnReadWhitelist.UseVisualStyleBackColor = true;
            this.btnReadWhitelist.Click += new System.EventHandler(this.btnReadWhitelist_Click);
            // 
            // btnRemoveFromWhitelist
            // 
            this.btnRemoveFromWhitelist.Location = new System.Drawing.Point(9, 149);
            this.btnRemoveFromWhitelist.Name = "btnRemoveFromWhitelist";
            this.btnRemoveFromWhitelist.Size = new System.Drawing.Size(185, 23);
            this.btnRemoveFromWhitelist.TabIndex = 5;
            this.btnRemoveFromWhitelist.Text = "Remove card from the list";
            this.btnRemoveFromWhitelist.UseVisualStyleBackColor = true;
            this.btnRemoveFromWhitelist.Click += new System.EventHandler(this.btnRemoveFromWhitelist_Click);
            // 
            // btnImportWhitelist
            // 
            this.btnImportWhitelist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportWhitelist.Location = new System.Drawing.Point(9, 237);
            this.btnImportWhitelist.Name = "btnImportWhitelist";
            this.btnImportWhitelist.Size = new System.Drawing.Size(185, 23);
            this.btnImportWhitelist.TabIndex = 8;
            this.btnImportWhitelist.Text = "Import list from .CSV";
            this.btnImportWhitelist.UseVisualStyleBackColor = true;
            this.btnImportWhitelist.Click += new System.EventHandler(this.btnImportWhitelist_Click);
            // 
            // btnExportWhitelist
            // 
            this.btnExportWhitelist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportWhitelist.Location = new System.Drawing.Point(9, 208);
            this.btnExportWhitelist.Name = "btnExportWhitelist";
            this.btnExportWhitelist.Size = new System.Drawing.Size(185, 23);
            this.btnExportWhitelist.TabIndex = 7;
            this.btnExportWhitelist.Text = "Export list to .CSV";
            this.btnExportWhitelist.UseVisualStyleBackColor = true;
            this.btnExportWhitelist.Click += new System.EventHandler(this.btnExportWhitelist_Click);
            // 
            // btnClearWhitelist
            // 
            this.btnClearWhitelist.Location = new System.Drawing.Point(9, 178);
            this.btnClearWhitelist.Name = "btnClearWhitelist";
            this.btnClearWhitelist.Size = new System.Drawing.Size(185, 23);
            this.btnClearWhitelist.TabIndex = 6;
            this.btnClearWhitelist.Text = "Clear list";
            this.btnClearWhitelist.UseVisualStyleBackColor = true;
            this.btnClearWhitelist.Click += new System.EventHandler(this.btnClearWhitelist_Click);
            // 
            // btnPutOnWhitelist
            // 
            this.btnPutOnWhitelist.Location = new System.Drawing.Point(9, 120);
            this.btnPutOnWhitelist.Name = "btnPutOnWhitelist";
            this.btnPutOnWhitelist.Size = new System.Drawing.Size(185, 23);
            this.btnPutOnWhitelist.TabIndex = 4;
            this.btnPutOnWhitelist.Text = "Put card on the list";
            this.btnPutOnWhitelist.UseVisualStyleBackColor = true;
            this.btnPutOnWhitelist.Click += new System.EventHandler(this.btnPutOnWhitelist_Click);
            // 
            // lbWhitelistUid
            // 
            this.lbWhitelistUid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWhitelistUid.AutoSize = true;
            this.lbWhitelistUid.Location = new System.Drawing.Point(6, 92);
            this.lbWhitelistUid.Name = "lbWhitelistUid";
            this.lbWhitelistUid.Size = new System.Drawing.Size(27, 13);
            this.lbWhitelistUid.TabIndex = 2;
            this.lbWhitelistUid.Text = "UId:";
            // 
            // gbDeviceUserInterface
            // 
            this.gbDeviceUserInterface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDeviceUserInterface.Controls.Add(this.chkGreenSlave);
            this.gbDeviceUserInterface.Controls.Add(this.chkRedSlave);
            this.gbDeviceUserInterface.Controls.Add(this.chkRelayState);
            this.gbDeviceUserInterface.Controls.Add(this.chkDoorState);
            this.gbDeviceUserInterface.Controls.Add(this.chkIntercomState);
            this.gbDeviceUserInterface.Controls.Add(this.btnSetLight);
            this.gbDeviceUserInterface.Controls.Add(this.chkGreenMaster);
            this.gbDeviceUserInterface.Controls.Add(this.chkRedMaster);
            this.gbDeviceUserInterface.Controls.Add(this.btnRelayOff);
            this.gbDeviceUserInterface.Controls.Add(this.btnRelayOn);
            this.gbDeviceUserInterface.Controls.Add(this.lbDurationUnit);
            this.gbDeviceUserInterface.Controls.Add(this.lbDuration);
            this.gbDeviceUserInterface.Controls.Add(this.numDuration);
            this.gbDeviceUserInterface.Controls.Add(this.btnLockOpen);
            this.gbDeviceUserInterface.Location = new System.Drawing.Point(539, 16);
            this.gbDeviceUserInterface.Name = "gbDeviceUserInterface";
            this.gbDeviceUserInterface.Size = new System.Drawing.Size(200, 270);
            this.gbDeviceUserInterface.TabIndex = 2;
            this.gbDeviceUserInterface.TabStop = false;
            this.gbDeviceUserInterface.Text = "Device User Interface:";
            // 
            // chkGreenSlave
            // 
            this.chkGreenSlave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGreenSlave.AutoSize = true;
            this.chkGreenSlave.ForeColor = System.Drawing.Color.Green;
            this.chkGreenSlave.Location = new System.Drawing.Point(104, 211);
            this.chkGreenSlave.Name = "chkGreenSlave";
            this.chkGreenSlave.Size = new System.Drawing.Size(85, 17);
            this.chkGreenSlave.TabIndex = 12;
            this.chkGreenSlave.Text = "Green Slave";
            this.chkGreenSlave.UseVisualStyleBackColor = true;
            // 
            // chkRedSlave
            // 
            this.chkRedSlave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRedSlave.AutoSize = true;
            this.chkRedSlave.ForeColor = System.Drawing.Color.Red;
            this.chkRedSlave.Location = new System.Drawing.Point(104, 188);
            this.chkRedSlave.Name = "chkRedSlave";
            this.chkRedSlave.Size = new System.Drawing.Size(76, 17);
            this.chkRedSlave.TabIndex = 11;
            this.chkRedSlave.Text = "Red Slave";
            this.chkRedSlave.UseVisualStyleBackColor = true;
            // 
            // chkRelayState
            // 
            this.chkRelayState.AutoSize = true;
            this.chkRelayState.Enabled = false;
            this.chkRelayState.Location = new System.Drawing.Point(104, 125);
            this.chkRelayState.Name = "chkRelayState";
            this.chkRelayState.Size = new System.Drawing.Size(81, 17);
            this.chkRelayState.TabIndex = 6;
            this.chkRelayState.Text = "Relay State";
            this.chkRelayState.UseVisualStyleBackColor = true;
            // 
            // chkDoorState
            // 
            this.chkDoorState.AutoSize = true;
            this.chkDoorState.Enabled = false;
            this.chkDoorState.Location = new System.Drawing.Point(9, 148);
            this.chkDoorState.Name = "chkDoorState";
            this.chkDoorState.Size = new System.Drawing.Size(77, 17);
            this.chkDoorState.TabIndex = 7;
            this.chkDoorState.Text = "Door State";
            this.chkDoorState.UseVisualStyleBackColor = true;
            // 
            // chkIntercomState
            // 
            this.chkIntercomState.AutoSize = true;
            this.chkIntercomState.Enabled = false;
            this.chkIntercomState.Location = new System.Drawing.Point(104, 148);
            this.chkIntercomState.Name = "chkIntercomState";
            this.chkIntercomState.Size = new System.Drawing.Size(95, 17);
            this.chkIntercomState.TabIndex = 8;
            this.chkIntercomState.Text = "Intercom State";
            this.chkIntercomState.UseVisualStyleBackColor = true;
            // 
            // btnSetLight
            // 
            this.btnSetLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetLight.Location = new System.Drawing.Point(6, 237);
            this.btnSetLight.Name = "btnSetLight";
            this.btnSetLight.Size = new System.Drawing.Size(188, 23);
            this.btnSetLight.TabIndex = 13;
            this.btnSetLight.Text = "Set Light";
            this.btnSetLight.UseVisualStyleBackColor = true;
            this.btnSetLight.Click += new System.EventHandler(this.btnSetLight_Click);
            // 
            // chkGreenMaster
            // 
            this.chkGreenMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGreenMaster.AutoSize = true;
            this.chkGreenMaster.ForeColor = System.Drawing.Color.Green;
            this.chkGreenMaster.Location = new System.Drawing.Point(9, 211);
            this.chkGreenMaster.Name = "chkGreenMaster";
            this.chkGreenMaster.Size = new System.Drawing.Size(90, 17);
            this.chkGreenMaster.TabIndex = 10;
            this.chkGreenMaster.Text = "Green Master";
            this.chkGreenMaster.UseVisualStyleBackColor = true;
            // 
            // chkRedMaster
            // 
            this.chkRedMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRedMaster.AutoSize = true;
            this.chkRedMaster.ForeColor = System.Drawing.Color.Red;
            this.chkRedMaster.Location = new System.Drawing.Point(9, 188);
            this.chkRedMaster.Name = "chkRedMaster";
            this.chkRedMaster.Size = new System.Drawing.Size(81, 17);
            this.chkRedMaster.TabIndex = 9;
            this.chkRedMaster.Text = "Red Master";
            this.chkRedMaster.UseVisualStyleBackColor = true;
            // 
            // btnRelayOff
            // 
            this.btnRelayOff.Location = new System.Drawing.Point(104, 90);
            this.btnRelayOff.Name = "btnRelayOff";
            this.btnRelayOff.Size = new System.Drawing.Size(90, 23);
            this.btnRelayOff.TabIndex = 5;
            this.btnRelayOff.Text = "Relay Off";
            this.btnRelayOff.UseVisualStyleBackColor = true;
            this.btnRelayOff.Click += new System.EventHandler(this.btnRelayOff_Click);
            // 
            // btnRelayOn
            // 
            this.btnRelayOn.Location = new System.Drawing.Point(6, 90);
            this.btnRelayOn.Name = "btnRelayOn";
            this.btnRelayOn.Size = new System.Drawing.Size(90, 23);
            this.btnRelayOn.TabIndex = 4;
            this.btnRelayOn.Text = "Relay On";
            this.btnRelayOn.UseVisualStyleBackColor = true;
            this.btnRelayOn.Click += new System.EventHandler(this.btnRelayOn_Click);
            // 
            // lbDurationUnit
            // 
            this.lbDurationUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDurationUnit.AutoSize = true;
            this.lbDurationUnit.Location = new System.Drawing.Point(168, 29);
            this.lbDurationUnit.Name = "lbDurationUnit";
            this.lbDurationUnit.Size = new System.Drawing.Size(26, 13);
            this.lbDurationUnit.TabIndex = 2;
            this.lbDurationUnit.Text = "[ms]";
            // 
            // lbDuration
            // 
            this.lbDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDuration.AutoSize = true;
            this.lbDuration.Location = new System.Drawing.Point(6, 29);
            this.lbDuration.Name = "lbDuration";
            this.lbDuration.Size = new System.Drawing.Size(50, 13);
            this.lbDuration.TabIndex = 0;
            this.lbDuration.Text = "Duration:";
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(62, 26);
            this.numDuration.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.ReadOnly = true;
            this.numDuration.Size = new System.Drawing.Size(100, 20);
            this.numDuration.TabIndex = 1;
            this.numDuration.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // btnLockOpen
            // 
            this.btnLockOpen.Location = new System.Drawing.Point(6, 61);
            this.btnLockOpen.Name = "btnLockOpen";
            this.btnLockOpen.Size = new System.Drawing.Size(188, 23);
            this.btnLockOpen.TabIndex = 3;
            this.btnLockOpen.Text = "Lock Open";
            this.btnLockOpen.UseVisualStyleBackColor = true;
            this.btnLockOpen.Click += new System.EventHandler(this.btnLockOpen_Click);
            // 
            // lstWhitelist
            // 
            this.lstWhitelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWhitelist.Font = new System.Drawing.Font("Courier New", 8F);
            this.lstWhitelist.FormattingEnabled = true;
            this.lstWhitelist.ItemHeight = 14;
            this.lstWhitelist.Location = new System.Drawing.Point(11, 22);
            this.lstWhitelist.Name = "lstWhitelist";
            this.lstWhitelist.Size = new System.Drawing.Size(307, 256);
            this.lstWhitelist.TabIndex = 0;
            this.lstWhitelist.DoubleClick += new System.EventHandler(this.lstWhitelist_DoubleClick);
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(0, 0);
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(784, 190);
            this.tbLog.TabIndex = 0;
            this.tbLog.Text = "";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmSelectedDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 556);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(800, 595);
            this.Name = "frmSelectedDevice";
            this.Text = "AIS Readers Demo - Selected device";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSelectedDevice_FormClosed);
            this.Load += new System.EventHandler(this.frmSelectedDevice_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbAdminPassword.ResumeLayout(false);
            this.gbAdminPassword.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.gbGetLogByIndex.ResumeLayout(false);
            this.gbGetLogByIndex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIndexTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIndexFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLog)).EndInit();
            this.tabPageRTE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRTE)).EndInit();
            this.tabPageBlacklist.ResumeLayout(false);
            this.gbBlackList.ResumeLayout(false);
            this.gbList.ResumeLayout(false);
            this.gbList.PerformLayout();
            this.gbSingle.ResumeLayout(false);
            this.gbSingle.PerformLayout();
            this.tabPageSecPass.ResumeLayout(false);
            this.gbUIDWhitelist.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.gbDeviceUserInterface.ResumeLayout(false);
            this.gbDeviceUserInterface.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TabPage tabPageRTE;
        private System.Windows.Forms.TabPage tabPageBlacklist;
        private System.Windows.Forms.TabPage tabPageSecPass;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbAdminPassword;
        private System.Windows.Forms.TextBox tbAdminPassword;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRepeatPasswd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNewPasswd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOldPasswd;
        private System.Windows.Forms.Button btnSubmitPassword;
        private System.Windows.Forms.Button btnSubmitDateTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimeDevice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.Label lbDeviceId;
        private System.Windows.Forms.Button btnSetAdminPassword;
        private System.Windows.Forms.Button btnGetWholeLog;
        private System.Windows.Forms.DataGridView gridLog;
        private System.Windows.Forms.Button btnStartRTEMonitor;
        private System.Windows.Forms.Button btnStopRTEMonitor;
        private System.Windows.Forms.DataGridView gridRTE;
        private System.Windows.Forms.Button btnWriteBlackList;
        private System.Windows.Forms.GroupBox gbBlackList;
        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.Button btnListRemove;
        private System.Windows.Forms.Button BtnListImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnListClear;
        private System.Windows.Forms.Button btnListPut;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbListCardSn;
        private System.Windows.Forms.GroupBox gbSingle;
        private System.Windows.Forms.Button btnSingledUnblockCard;
        private System.Windows.Forms.Button btnSingleBlockCard;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbSingleCardSn;
        private System.Windows.Forms.ListBox lstBlacklist;
        private System.Windows.Forms.Button btnReadBlackList;
        private System.Windows.Forms.GroupBox gbUIDWhitelist;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnRemoveFromWhitelist;
        private System.Windows.Forms.Button btnImportWhitelist;
        private System.Windows.Forms.Button btnExportWhitelist;
        private System.Windows.Forms.Button btnClearWhitelist;
        private System.Windows.Forms.Button btnPutOnWhitelist;
        private System.Windows.Forms.Label lbWhitelistUid;
        private System.Windows.Forms.GroupBox gbDeviceUserInterface;
        private System.Windows.Forms.ListBox lstWhitelist;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.RichTextBox tbInfo;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox tbDateTimeLocal;
        private System.Windows.Forms.Button btnGetTime;
        private System.Windows.Forms.Button btnSubmitLocalDateTime;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnLockOpen;
        private System.Windows.Forms.Label lbDurationUnit;
        private System.Windows.Forms.Label lbDuration;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Button btnRelayOff;
        private System.Windows.Forms.Button btnRelayOn;
        private System.Windows.Forms.CheckBox chkGreenMaster;
        private System.Windows.Forms.CheckBox chkRedMaster;
        private System.Windows.Forms.Button btnSetLight;
        private System.Windows.Forms.CheckBox chkRelayState;
        private System.Windows.Forms.CheckBox chkDoorState;
        private System.Windows.Forms.CheckBox chkIntercomState;
        private System.Windows.Forms.ToolStripSplitButton btnClearLogBox;
        private System.Windows.Forms.ToolStripStatusLabel spacerLabel;
        private System.Windows.Forms.CheckBox chkGreenSlave;
        private System.Windows.Forms.CheckBox chkRedSlave;
        private System.Windows.Forms.Button btnWriteWhitelist;
        private System.Windows.Forms.Button btnReadWhitelist;
        private System.Windows.Forms.MaskedTextBox tbWhitelistUid;
        private System.Windows.Forms.GroupBox gbGetLogByIndex;
        private System.Windows.Forms.CheckBox chkGetLogByIndex;
        private System.Windows.Forms.NumericUpDown numIndexTo;
        private System.Windows.Forms.NumericUpDown numIndexFrom;
        private System.Windows.Forms.Label lblbIndexTo;
        private System.Windows.Forms.Label lbIndexFrom;
    }

    class TypesHelper
    {
        private static string BytesToString(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }

        private static byte[] StringToBytes(string value)
        {
            // convert string to byte array
            byte[] bytes = Encoding.ASCII.GetBytes(value);

            return bytes;
        }
    }
}

