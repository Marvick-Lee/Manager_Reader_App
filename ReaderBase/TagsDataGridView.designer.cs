namespace ReaderSDK.Components
{
    partial class TagsDataGridView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDecCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHexByteSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEpc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRssi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPop = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopyEPC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiClearScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.pnlPageControl = new System.Windows.Forms.Panel();
            this.btnLeft = new System.Windows.Forms.Button();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlDistinguish = new System.Windows.Forms.Panel();
            this.cmbShowLen = new System.Windows.Forms.ComboBox();
            this.cmbStartPoint = new System.Windows.Forms.ComboBox();
            this.chkDivAlarm = new System.Windows.Forms.CheckBox();
            this.chkDivAddr = new System.Windows.Forms.CheckBox();
            this.chkDivAnt = new System.Windows.Forms.CheckBox();
            this.pnlCount = new System.Windows.Forms.Panel();
            this.lblSumSymbol = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.cmsPop.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlPageControl.SuspendLayout();
            this.pnlDistinguish.SuspendLayout();
            this.pnlCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.AllowUserToDeleteRows = false;
            this.dgvShow.AllowUserToResizeColumns = false;
            this.dgvShow.AllowUserToResizeRows = false;
            this.dgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvShow.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvShow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colAddress,
            this.colDecCard,
            this.colHexByteSum,
            this.colPc,
            this.colEpc,
            this.colCrc,
            this.colData,
            this.colCount,
            this.colAnt,
            this.colRssi});
            this.dgvShow.ContextMenuStrip = this.cmsPop;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShow.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShow.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvShow.Location = new System.Drawing.Point(0, 32);
            this.dgvShow.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.dgvShow.MultiSelect = false;
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.ReadOnly = true;
            this.dgvShow.RowHeadersVisible = false;
            this.dgvShow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvShow.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShow.RowTemplate.Height = 23;
            this.dgvShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShow.Size = new System.Drawing.Size(950, 451);
            this.dgvShow.TabIndex = 94;
            this.dgvShow.TabStop = false;
            this.dgvShow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvShow_MouseClick);
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colID.FillWeight = 120F;
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 42;
            // 
            // colAddress
            // 
            this.colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAddress.HeaderText = "ADDRESS";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            this.colAddress.Visible = false;
            // 
            // colDecCard
            // 
            this.colDecCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDecCard.HeaderText = "HEX/DEC/WG";
            this.colDecCard.Name = "colDecCard";
            this.colDecCard.ReadOnly = true;
            this.colDecCard.Width = 90;
            // 
            // colHexByteSum
            // 
            this.colHexByteSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHexByteSum.HeaderText = "LENGTH";
            this.colHexByteSum.Name = "colHexByteSum";
            this.colHexByteSum.ReadOnly = true;
            this.colHexByteSum.Width = 66;
            // 
            // colPc
            // 
            this.colPc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPc.HeaderText = "PC";
            this.colPc.Name = "colPc";
            this.colPc.ReadOnly = true;
            this.colPc.Visible = false;
            // 
            // colEpc
            // 
            this.colEpc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEpc.FillWeight = 200F;
            this.colEpc.HeaderText = "EPC/TID";
            this.colEpc.MinimumWidth = 200;
            this.colEpc.Name = "colEpc";
            this.colEpc.ReadOnly = true;
            // 
            // colCrc
            // 
            this.colCrc.HeaderText = "CRC";
            this.colCrc.Name = "colCrc";
            this.colCrc.ReadOnly = true;
            this.colCrc.Visible = false;
            this.colCrc.Width = 48;
            // 
            // colData
            // 
            this.colData.HeaderText = "DATA";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Visible = false;
            this.colData.Width = 54;
            // 
            // colCount
            // 
            this.colCount.HeaderText = "COUNT";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            this.colCount.Width = 60;
            // 
            // colAnt
            // 
            this.colAnt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAnt.HeaderText = "Ant1";
            this.colAnt.Name = "colAnt";
            this.colAnt.ReadOnly = true;
            this.colAnt.Visible = false;
            // 
            // colRssi
            // 
            this.colRssi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colRssi.HeaderText = "RSSI";
            this.colRssi.Name = "colRssi";
            this.colRssi.ReadOnly = true;
            this.colRssi.Width = 54;
            // 
            // cmsPop
            // 
            this.cmsPop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopyEPC,
            this.toolStripSeparator1,
            this.tsmiClearScreen});
            this.cmsPop.Name = "cmsPop";
            this.cmsPop.Size = new System.Drawing.Size(161, 54);
            // 
            // tsmiCopyEPC
            // 
            this.tsmiCopyEPC.Name = "tsmiCopyEPC";
            this.tsmiCopyEPC.Size = new System.Drawing.Size(160, 22);
            this.tsmiCopyEPC.Text = "Copy EPC/TID";
            this.tsmiCopyEPC.Click += new System.EventHandler(this.tsmiCopyEPC_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // tsmiClearScreen
            // 
            this.tsmiClearScreen.Name = "tsmiClearScreen";
            this.tsmiClearScreen.Size = new System.Drawing.Size(160, 22);
            this.tsmiClearScreen.Text = "Clear All Items";
            this.tsmiClearScreen.Click += new System.EventHandler(this.tsmiClearScreen_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.pnlPageControl);
            this.pnlInfo.Controls.Add(this.btnClear);
            this.pnlInfo.Controls.Add(this.pnlDistinguish);
            this.pnlInfo.Controls.Add(this.pnlCount);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(950, 32);
            this.pnlInfo.TabIndex = 95;
            // 
            // pnlPageControl
            // 
            this.pnlPageControl.AutoSize = true;
            this.pnlPageControl.Controls.Add(this.btnLeft);
            this.pnlPageControl.Controls.Add(this.lblCurrentPage);
            this.pnlPageControl.Controls.Add(this.btnRight);
            this.pnlPageControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPageControl.Location = new System.Drawing.Point(644, 0);
            this.pnlPageControl.Name = "pnlPageControl";
            this.pnlPageControl.Size = new System.Drawing.Size(180, 32);
            this.pnlPageControl.TabIndex = 91;
            this.pnlPageControl.Visible = false;
            // 
            // btnLeft
            // 
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLeft.Location = new System.Drawing.Point(0, 0);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(60, 32);
            this.btnLeft.TabIndex = 88;
            this.btnLeft.Text = "<<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCurrentPage.Location = new System.Drawing.Point(60, 0);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(60, 32);
            this.lblCurrentPage.TabIndex = 89;
            this.lblCurrentPage.Text = "1/2";
            this.lblCurrentPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRight
            // 
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRight.Location = new System.Drawing.Point(120, 0);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(60, 32);
            this.btnRight.TabIndex = 90;
            this.btnRight.Text = ">>";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClear.Location = new System.Drawing.Point(460, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 32);
            this.btnClear.TabIndex = 87;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlDistinguish
            // 
            this.pnlDistinguish.AutoSize = true;
            this.pnlDistinguish.Controls.Add(this.cmbShowLen);
            this.pnlDistinguish.Controls.Add(this.cmbStartPoint);
            this.pnlDistinguish.Controls.Add(this.chkDivAlarm);
            this.pnlDistinguish.Controls.Add(this.chkDivAddr);
            this.pnlDistinguish.Controls.Add(this.chkDivAnt);
            this.pnlDistinguish.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDistinguish.Location = new System.Drawing.Point(0, 0);
            this.pnlDistinguish.Name = "pnlDistinguish";
            this.pnlDistinguish.Padding = new System.Windows.Forms.Padding(3);
            this.pnlDistinguish.Size = new System.Drawing.Size(460, 32);
            this.pnlDistinguish.TabIndex = 86;
            // 
            // cmbShowLen
            // 
            this.cmbShowLen.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbShowLen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShowLen.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbShowLen.FormattingEnabled = true;
            this.cmbShowLen.Items.AddRange(new object[] {
            "Show len 2 byte",
            "Show len 3 byte",
            "Show len 4 byte"});
            this.cmbShowLen.Location = new System.Drawing.Point(337, 3);
            this.cmbShowLen.Name = "cmbShowLen";
            this.cmbShowLen.Size = new System.Drawing.Size(120, 25);
            this.cmbShowLen.TabIndex = 92;
            this.cmbShowLen.SelectionChangeCommitted += new System.EventHandler(this.cmbShowLen_SelectionChangeCommitted);
            // 
            // cmbStartPoint
            // 
            this.cmbStartPoint.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbStartPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartPoint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbStartPoint.FormattingEnabled = true;
            this.cmbStartPoint.Items.AddRange(new object[] {
            "卡号偏移0",
            "卡号偏移1",
            "卡号偏移2",
            "卡号偏移3",
            "卡号偏移4",
            "卡号偏移5",
            "卡号偏移6",
            "卡号偏移7",
            "卡号偏移8",
            "卡号偏移9"});
            this.cmbStartPoint.Location = new System.Drawing.Point(237, 3);
            this.cmbStartPoint.Name = "cmbStartPoint";
            this.cmbStartPoint.Size = new System.Drawing.Size(100, 25);
            this.cmbStartPoint.TabIndex = 88;
            this.cmbStartPoint.SelectionChangeCommitted += new System.EventHandler(this.cmbStartPoint_SelectionChangeCommitted);
            // 
            // chkDivAlarm
            // 
            this.chkDivAlarm.AutoSize = true;
            this.chkDivAlarm.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDivAlarm.Location = new System.Drawing.Point(159, 3);
            this.chkDivAlarm.Name = "chkDivAlarm";
            this.chkDivAlarm.Size = new System.Drawing.Size(78, 26);
            this.chkDivAlarm.TabIndex = 89;
            this.chkDivAlarm.TabStop = false;
            this.chkDivAlarm.Text = "Div Alarm";
            this.chkDivAlarm.UseVisualStyleBackColor = true;
            // 
            // chkDivAddr
            // 
            this.chkDivAddr.AutoSize = true;
            this.chkDivAddr.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDivAddr.Location = new System.Drawing.Point(69, 3);
            this.chkDivAddr.Name = "chkDivAddr";
            this.chkDivAddr.Size = new System.Drawing.Size(90, 26);
            this.chkDivAddr.TabIndex = 87;
            this.chkDivAddr.TabStop = false;
            this.chkDivAddr.Text = "Div Address";
            this.chkDivAddr.UseVisualStyleBackColor = true;
            this.chkDivAddr.CheckedChanged += new System.EventHandler(this.chkDivAddr_CheckedChanged);
            // 
            // chkDivAnt
            // 
            this.chkDivAnt.AutoSize = true;
            this.chkDivAnt.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDivAnt.Location = new System.Drawing.Point(3, 3);
            this.chkDivAnt.Name = "chkDivAnt";
            this.chkDivAnt.Size = new System.Drawing.Size(66, 26);
            this.chkDivAnt.TabIndex = 93;
            this.chkDivAnt.TabStop = false;
            this.chkDivAnt.Text = "Div Ant";
            this.chkDivAnt.UseVisualStyleBackColor = true;
            this.chkDivAnt.CheckedChanged += new System.EventHandler(this.chkDivAnt_CheckedChanged);
            // 
            // pnlCount
            // 
            this.pnlCount.AutoSize = true;
            this.pnlCount.Controls.Add(this.lblSumSymbol);
            this.pnlCount.Controls.Add(this.lblSum);
            this.pnlCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCount.Location = new System.Drawing.Point(824, 0);
            this.pnlCount.Name = "pnlCount";
            this.pnlCount.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCount.Size = new System.Drawing.Size(126, 32);
            this.pnlCount.TabIndex = 85;
            // 
            // lblSumSymbol
            // 
            this.lblSumSymbol.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSumSymbol.Location = new System.Drawing.Point(3, 3);
            this.lblSumSymbol.Name = "lblSumSymbol";
            this.lblSumSymbol.Size = new System.Drawing.Size(60, 26);
            this.lblSumSymbol.TabIndex = 88;
            this.lblSumSymbol.Text = "Sum:";
            this.lblSumSymbol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSum
            // 
            this.lblSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSum.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSum.Location = new System.Drawing.Point(63, 3);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(60, 26);
            this.lblSum.TabIndex = 92;
            this.lblSum.Text = "0";
            this.lblSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // TagsDataGridView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.pnlInfo);
            this.Name = "TagsDataGridView";
            this.Size = new System.Drawing.Size(950, 483);
            this.Load += new System.EventHandler(this.TagsDataGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.cmsPop.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlPageControl.ResumeLayout(false);
            this.pnlDistinguish.ResumeLayout(false);
            this.pnlDistinguish.PerformLayout();
            this.pnlCount.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlDistinguish;
        private System.Windows.Forms.ComboBox cmbShowLen;
        private System.Windows.Forms.ComboBox cmbStartPoint;
        private System.Windows.Forms.CheckBox chkDivAlarm;
        private System.Windows.Forms.CheckBox chkDivAddr;
        private System.Windows.Forms.CheckBox chkDivAnt;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.ContextMenuStrip cmsPop;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyEPC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearScreen;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Panel pnlCount;
        private System.Windows.Forms.Label lblSumSymbol;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDecCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHexByteSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEpc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRssi;
        private System.Windows.Forms.Panel pnlPageControl;
    }
}
