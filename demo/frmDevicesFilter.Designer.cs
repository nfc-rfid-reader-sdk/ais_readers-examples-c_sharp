namespace DL_AIS_Readers
{
    partial class frmFilterList
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
            this.gbDevicesFilter = new System.Windows.Forms.GroupBox();
            this.btnListSave = new System.Windows.Forms.Button();
            this.btnListLoad = new System.Windows.Forms.Button();
            this.lbId = new System.Windows.Forms.Label();
            this.bListClear = new System.Windows.Forms.Button();
            this.tbId = new System.Windows.Forms.TextBox();
            this.cbList = new System.Windows.Forms.ComboBox();
            this.bListDel = new System.Windows.Forms.Button();
            this.bListAdd = new System.Windows.Forms.Button();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.gbDevicesFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDevicesFilter
            // 
            this.gbDevicesFilter.Controls.Add(this.btnListSave);
            this.gbDevicesFilter.Controls.Add(this.btnListLoad);
            this.gbDevicesFilter.Controls.Add(this.lbId);
            this.gbDevicesFilter.Controls.Add(this.bListClear);
            this.gbDevicesFilter.Controls.Add(this.tbId);
            this.gbDevicesFilter.Controls.Add(this.cbList);
            this.gbDevicesFilter.Controls.Add(this.bListDel);
            this.gbDevicesFilter.Controls.Add(this.bListAdd);
            this.gbDevicesFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDevicesFilter.Location = new System.Drawing.Point(0, 0);
            this.gbDevicesFilter.Name = "gbDevicesFilter";
            this.gbDevicesFilter.Size = new System.Drawing.Size(570, 85);
            this.gbDevicesFilter.TabIndex = 4;
            this.gbDevicesFilter.TabStop = false;
            this.gbDevicesFilter.Text = "Devices Filter:";
            // 
            // btnListSave
            // 
            this.btnListSave.Location = new System.Drawing.Point(130, 48);
            this.btnListSave.Name = "btnListSave";
            this.btnListSave.Size = new System.Drawing.Size(117, 23);
            this.btnListSave.TabIndex = 7;
            this.btnListSave.Text = "Save Filter List";
            this.btnListSave.UseVisualStyleBackColor = true;
            this.btnListSave.Click += new System.EventHandler(this.btnListSave_Click);
            // 
            // btnListLoad
            // 
            this.btnListLoad.Location = new System.Drawing.Point(12, 48);
            this.btnListLoad.Name = "btnListLoad";
            this.btnListLoad.Size = new System.Drawing.Size(112, 23);
            this.btnListLoad.TabIndex = 6;
            this.btnListLoad.Text = "Load Filter List";
            this.btnListLoad.UseVisualStyleBackColor = true;
            this.btnListLoad.Click += new System.EventHandler(this.btnListLoad_Click);
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(163, 22);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(19, 13);
            this.lbId.TabIndex = 5;
            this.lbId.Text = "Id:";
            // 
            // bListClear
            // 
            this.bListClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bListClear.Location = new System.Drawing.Point(412, 48);
            this.bListClear.Name = "bListClear";
            this.bListClear.Size = new System.Drawing.Size(145, 23);
            this.bListClear.TabIndex = 4;
            this.bListClear.Text = "Clear Filter List";
            this.bListClear.UseVisualStyleBackColor = true;
            this.bListClear.Click += new System.EventHandler(this.bListClear_Click);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(187, 20);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(60, 20);
            this.tbId.TabIndex = 1;
            this.tbId.Text = "0";
            // 
            // cbList
            // 
            this.cbList.FormattingEnabled = true;
            this.cbList.Location = new System.Drawing.Point(12, 19);
            this.cbList.Name = "cbList";
            this.cbList.Size = new System.Drawing.Size(145, 21);
            this.cbList.TabIndex = 0;
            // 
            // bListDel
            // 
            this.bListDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bListDel.Location = new System.Drawing.Point(412, 19);
            this.bListDel.Name = "bListDel";
            this.bListDel.Size = new System.Drawing.Size(145, 23);
            this.bListDel.TabIndex = 3;
            this.bListDel.Text = "Remove from Filter List";
            this.bListDel.UseVisualStyleBackColor = true;
            this.bListDel.Click += new System.EventHandler(this.bListDel_Click);
            // 
            // bListAdd
            // 
            this.bListAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bListAdd.Location = new System.Drawing.Point(261, 19);
            this.bListAdd.Name = "bListAdd";
            this.bListAdd.Size = new System.Drawing.Size(145, 23);
            this.bListAdd.TabIndex = 2;
            this.bListAdd.Text = "Add to Filter List";
            this.bListAdd.UseVisualStyleBackColor = true;
            this.bListAdd.Click += new System.EventHandler(this.bListAdd_Click);
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
            this.gridView.Location = new System.Drawing.Point(0, 85);
            this.gridView.MultiSelect = false;
            this.gridView.Name = "gridView";
            this.gridView.ReadOnly = true;
            this.gridView.RowHeadersVisible = false;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(570, 319);
            this.gridView.TabIndex = 9;
            this.gridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellDoubleClick);
            // 
            // frmFilterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 404);
            this.ControlBox = false;
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.gbDevicesFilter);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(586, 420);
            this.Name = "frmFilterList";
            this.Text = "Devices Filter List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFilterList_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.frmFilterList_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFilterList_KeyDown);
            this.gbDevicesFilter.ResumeLayout(false);
            this.gbDevicesFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDevicesFilter;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Button bListClear;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.ComboBox cbList;
        private System.Windows.Forms.Button bListDel;
        private System.Windows.Forms.Button bListAdd;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.Button btnListSave;
        private System.Windows.Forms.Button btnListLoad;
    }
}