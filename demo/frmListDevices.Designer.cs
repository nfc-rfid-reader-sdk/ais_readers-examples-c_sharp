namespace DL_AIS_Readers
{
    partial class frmListDevices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnGetDLLInfo = new System.Windows.Forms.Button();
            this.btnCloseDevice = new System.Windows.Forms.Button();
            this.btnOpenDevice = new System.Windows.Forms.Button();
            this.btnEnumerate = new System.Windows.Forms.Button();
            this.gbDevicesFilter = new System.Windows.Forms.GroupBox();
            this.btnShowFilterList = new System.Windows.Forms.Button();
            this.btnHideFilterList = new System.Windows.Forms.Button();
            this.lbId = new System.Windows.Forms.Label();
            this.btnListClear = new System.Windows.Forms.Button();
            this.tbId = new System.Windows.Forms.TextBox();
            this.cbList = new System.Windows.Forms.ComboBox();
            this.btnListDel = new System.Windows.Forms.Button();
            this.btnListAdd = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClearLogBox = new System.Windows.Forms.ToolStripSplitButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.panelTop.SuspendLayout();
            this.gbDevicesFilter.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnGetDLLInfo);
            this.panelTop.Controls.Add(this.btnCloseDevice);
            this.panelTop.Controls.Add(this.btnOpenDevice);
            this.panelTop.Controls.Add(this.btnEnumerate);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(784, 45);
            this.panelTop.TabIndex = 0;
            // 
            // btnGetDLLInfo
            // 
            this.btnGetDLLInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGetDLLInfo.Location = new System.Drawing.Point(12, 12);
            this.btnGetDLLInfo.Name = "btnGetDLLInfo";
            this.btnGetDLLInfo.Size = new System.Drawing.Size(145, 23);
            this.btnGetDLLInfo.TabIndex = 0;
            this.btnGetDLLInfo.Text = "Get DLL Information";
            this.btnGetDLLInfo.UseVisualStyleBackColor = true;
            this.btnGetDLLInfo.Click += new System.EventHandler(this.btnGetDLLInfo_Click);
            // 
            // btnCloseDevice
            // 
            this.btnCloseDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseDevice.Enabled = false;
            this.btnCloseDevice.Location = new System.Drawing.Point(623, 12);
            this.btnCloseDevice.Name = "btnCloseDevice";
            this.btnCloseDevice.Size = new System.Drawing.Size(145, 23);
            this.btnCloseDevice.TabIndex = 3;
            this.btnCloseDevice.Text = "Close Selected Device";
            this.btnCloseDevice.UseVisualStyleBackColor = true;
            this.btnCloseDevice.Click += new System.EventHandler(this.btnCloseDevice_Click);
            // 
            // btnOpenDevice
            // 
            this.btnOpenDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDevice.Enabled = false;
            this.btnOpenDevice.Location = new System.Drawing.Point(472, 12);
            this.btnOpenDevice.Name = "btnOpenDevice";
            this.btnOpenDevice.Size = new System.Drawing.Size(145, 23);
            this.btnOpenDevice.TabIndex = 2;
            this.btnOpenDevice.Text = "Open Selected Device";
            this.btnOpenDevice.UseVisualStyleBackColor = true;
            this.btnOpenDevice.Click += new System.EventHandler(this.btnOpenDevice_Click);
            // 
            // btnEnumerate
            // 
            this.btnEnumerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnumerate.Location = new System.Drawing.Point(321, 12);
            this.btnEnumerate.Name = "btnEnumerate";
            this.btnEnumerate.Size = new System.Drawing.Size(145, 23);
            this.btnEnumerate.TabIndex = 1;
            this.btnEnumerate.Text = "Enumerate Devices";
            this.btnEnumerate.UseVisualStyleBackColor = true;
            this.btnEnumerate.Click += new System.EventHandler(this.btnEnumerate_Click);
            // 
            // gbDevicesFilter
            // 
            this.gbDevicesFilter.Controls.Add(this.btnShowFilterList);
            this.gbDevicesFilter.Controls.Add(this.btnHideFilterList);
            this.gbDevicesFilter.Controls.Add(this.lbId);
            this.gbDevicesFilter.Controls.Add(this.btnListClear);
            this.gbDevicesFilter.Controls.Add(this.tbId);
            this.gbDevicesFilter.Controls.Add(this.cbList);
            this.gbDevicesFilter.Controls.Add(this.btnListDel);
            this.gbDevicesFilter.Controls.Add(this.btnListAdd);
            this.gbDevicesFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDevicesFilter.Location = new System.Drawing.Point(0, 45);
            this.gbDevicesFilter.Name = "gbDevicesFilter";
            this.gbDevicesFilter.Size = new System.Drawing.Size(784, 85);
            this.gbDevicesFilter.TabIndex = 1;
            this.gbDevicesFilter.TabStop = false;
            this.gbDevicesFilter.Text = "Devices Filter:";
            // 
            // btnShowFilterList
            // 
            this.btnShowFilterList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowFilterList.Location = new System.Drawing.Point(472, 48);
            this.btnShowFilterList.Name = "btnShowFilterList";
            this.btnShowFilterList.Size = new System.Drawing.Size(145, 23);
            this.btnShowFilterList.TabIndex = 6;
            this.btnShowFilterList.Text = "Show Filter List";
            this.btnShowFilterList.UseVisualStyleBackColor = true;
            this.btnShowFilterList.Click += new System.EventHandler(this.btnShowFilterList_Click);
            // 
            // btnHideFilterList
            // 
            this.btnHideFilterList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideFilterList.Enabled = false;
            this.btnHideFilterList.Location = new System.Drawing.Point(623, 47);
            this.btnHideFilterList.Name = "btnHideFilterList";
            this.btnHideFilterList.Size = new System.Drawing.Size(145, 23);
            this.btnHideFilterList.TabIndex = 7;
            this.btnHideFilterList.Text = "Hide Filter List";
            this.btnHideFilterList.UseVisualStyleBackColor = true;
            this.btnHideFilterList.Click += new System.EventHandler(this.btnHideFilterList_Click);
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(163, 22);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(19, 13);
            this.lbId.TabIndex = 1;
            this.lbId.Text = "Id:";
            // 
            // btnListClear
            // 
            this.btnListClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListClear.Location = new System.Drawing.Point(623, 18);
            this.btnListClear.Name = "btnListClear";
            this.btnListClear.Size = new System.Drawing.Size(145, 23);
            this.btnListClear.TabIndex = 5;
            this.btnListClear.Text = "Clear Filter List";
            this.btnListClear.UseVisualStyleBackColor = true;
            this.btnListClear.Click += new System.EventHandler(this.btnListClear_Click);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(187, 20);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(60, 20);
            this.tbId.TabIndex = 2;
            this.tbId.Text = "0";
            // 
            // cbList
            // 
            this.cbList.DropDownWidth = 200;
            this.cbList.FormattingEnabled = true;
            this.cbList.Location = new System.Drawing.Point(12, 19);
            this.cbList.Name = "cbList";
            this.cbList.Size = new System.Drawing.Size(145, 21);
            this.cbList.TabIndex = 0;
            // 
            // btnListDel
            // 
            this.btnListDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListDel.Location = new System.Drawing.Point(472, 19);
            this.btnListDel.Name = "btnListDel";
            this.btnListDel.Size = new System.Drawing.Size(145, 23);
            this.btnListDel.TabIndex = 4;
            this.btnListDel.Text = "Remove from Filter List";
            this.btnListDel.UseVisualStyleBackColor = true;
            this.btnListDel.Click += new System.EventHandler(this.btnListDel_Click);
            // 
            // btnListAdd
            // 
            this.btnListAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListAdd.Location = new System.Drawing.Point(321, 19);
            this.btnListAdd.Name = "btnListAdd";
            this.btnListAdd.Size = new System.Drawing.Size(145, 23);
            this.btnListAdd.TabIndex = 3;
            this.btnListAdd.Text = "Add to Filter List";
            this.btnListAdd.UseVisualStyleBackColor = true;
            this.btnListAdd.Click += new System.EventHandler(this.btnListAdd_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.btnClearLogBox});
            this.statusStrip.Location = new System.Drawing.Point(0, 519);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabel.ForeColor = System.Drawing.Color.Green;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(270, 17);
            this.statusLabel.Text = "Status Ok";
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
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 130);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gridView);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbLog);
            this.splitContainer.Panel2MinSize = 185;
            this.splitContainer.Size = new System.Drawing.Size(784, 389);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.TabIndex = 9;
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView.GridColor = System.Drawing.Color.Black;
            this.gridView.Location = new System.Drawing.Point(0, 0);
            this.gridView.MultiSelect = false;
            this.gridView.Name = "gridView";
            this.gridView.ReadOnly = true;
            this.gridView.RowHeadersVisible = false;
            this.gridView.RowHeadersWidth = 20;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(784, 200);
            this.gridView.TabIndex = 0;
            this.gridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellDoubleClick);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Location = new System.Drawing.Point(0, 0);
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(784, 185);
            this.tbLog.TabIndex = 0;
            this.tbLog.Text = "";
            // 
            // frmListDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 541);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gbDevicesFilter);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(800, 580);
            this.Name = "frmListDevices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AIS Reders Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListDevices_FormClosing);
            this.Load += new System.EventHandler(this.frmListDevices_Load);
            this.panelTop.ResumeLayout(false);
            this.gbDevicesFilter.ResumeLayout(false);
            this.gbDevicesFilter.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnGetDLLInfo;
        private System.Windows.Forms.Button btnCloseDevice;
        private System.Windows.Forms.Button btnOpenDevice;
        private System.Windows.Forms.Button btnEnumerate;
        private System.Windows.Forms.GroupBox gbDevicesFilter;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Button btnListClear;
        private System.Windows.Forms.Button btnListDel;
        private System.Windows.Forms.Button btnListAdd;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.ComboBox cbList;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.Button btnShowFilterList;
        private System.Windows.Forms.Button btnHideFilterList;
        private System.Windows.Forms.ToolStripSplitButton btnClearLogBox;
    }
}