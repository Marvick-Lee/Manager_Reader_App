namespace ReaderSDK
{
    partial class ucMWriteEPC
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkIsSelectTag = new System.Windows.Forms.CheckBox();
            this.lblAccessPwd = new System.Windows.Forms.Label();
            this.lblSelectedItem = new System.Windows.Forms.Label();
            this.txtSelectedItem = new System.Windows.Forms.TextBox();
            this.btnSelectTarget = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnScanTag = new System.Windows.Forms.Button();
            this.tabInformation = new System.Windows.Forms.TabControl();
            this.tabRW = new System.Windows.Forms.TabPage();
            this.pnlRW = new System.Windows.Forms.Panel();
            this.btnWriteAscii = new System.Windows.Forms.Button();
            this.txtDataAscii = new System.Windows.Forms.TextBox();
            this.lblDataAscii = new System.Windows.Forms.Label();
            this.txtDataHex = new System.Windows.Forms.TextBox();
            this.btnWriteHex = new System.Windows.Forms.Button();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.cmbMem = new System.Windows.Forms.ComboBox();
            this.lblDataHex = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblMem = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.tabLock = new System.Windows.Forms.TabPage();
            this.pnlLock = new System.Windows.Forms.Panel();
            this.btnLock = new System.Windows.Forms.Button();
            this.cmbLockAction = new System.Windows.Forms.ComboBox();
            this.lblLockAction = new System.Windows.Forms.Label();
            this.cmbLockType = new System.Windows.Forms.ComboBox();
            this.lblLockType = new System.Windows.Forms.Label();
            this.tabKill = new System.Windows.Forms.TabPage();
            this.pnlKill = new System.Windows.Forms.Panel();
            this.lblKillPwd = new System.Windows.Forms.Label();
            this.btnKill = new System.Windows.Forms.Button();
            this.ftxtAccessPwd = new ADControlsLib.Windows.Forms.FormatTextBox();
            this.ftxtKillPwd = new ADControlsLib.Windows.Forms.FormatTextBox();
            this.cdgvShow = new ADControlsLib.Windows.Forms.TagsDataGridView();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabInformation.SuspendLayout();
            this.tabRW.SuspendLayout();
            this.pnlRW.SuspendLayout();
            this.tabLock.SuspendLayout();
            this.pnlLock.SuspendLayout();
            this.tabKill.SuspendLayout();
            this.pnlKill.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.ftxtAccessPwd);
            this.panel4.Controls.Add(this.chkIsSelectTag);
            this.panel4.Controls.Add(this.lblAccessPwd);
            this.panel4.Controls.Add(this.lblSelectedItem);
            this.panel4.Controls.Add(this.txtSelectedItem);
            this.panel4.Controls.Add(this.btnSelectTarget);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 442);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(900, 38);
            this.panel4.TabIndex = 75;
            // 
            // chkIsSelectTag
            // 
            this.chkIsSelectTag.AutoSize = true;
            this.chkIsSelectTag.Checked = true;
            this.chkIsSelectTag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsSelectTag.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkIsSelectTag.Location = new System.Drawing.Point(748, 0);
            this.chkIsSelectTag.Name = "chkIsSelectTag";
            this.chkIsSelectTag.Size = new System.Drawing.Size(150, 36);
            this.chkIsSelectTag.TabIndex = 4;
            this.chkIsSelectTag.Text = "Is select tag to edit";
            this.chkIsSelectTag.UseVisualStyleBackColor = true;
            this.chkIsSelectTag.CheckedChanged += new System.EventHandler(this.chkIsSelectTag_CheckedChanged);
            // 
            // lblAccessPwd
            // 
            this.lblAccessPwd.AutoSize = true;
            this.lblAccessPwd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccessPwd.Location = new System.Drawing.Point(6, 12);
            this.lblAccessPwd.Name = "lblAccessPwd";
            this.lblAccessPwd.Size = new System.Drawing.Size(141, 15);
            this.lblAccessPwd.TabIndex = 0;
            this.lblAccessPwd.Text = "Access Password (HEX)";
            this.lblAccessPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectedItem
            // 
            this.lblSelectedItem.AutoSize = true;
            this.lblSelectedItem.Location = new System.Drawing.Point(298, 11);
            this.lblSelectedItem.Name = "lblSelectedItem";
            this.lblSelectedItem.Size = new System.Drawing.Size(83, 12);
            this.lblSelectedItem.TabIndex = 96;
            this.lblSelectedItem.Text = "Selected Item";
            this.lblSelectedItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSelectedItem
            // 
            this.txtSelectedItem.Location = new System.Drawing.Point(413, 8);
            this.txtSelectedItem.Name = "txtSelectedItem";
            this.txtSelectedItem.Size = new System.Drawing.Size(211, 21);
            this.txtSelectedItem.TabIndex = 97;
            this.txtSelectedItem.Text = "0000";
            // 
            // btnSelectTarget
            // 
            this.btnSelectTarget.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectTarget.Location = new System.Drawing.Point(628, 5);
            this.btnSelectTarget.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectTarget.Name = "btnSelectTarget";
            this.btnSelectTarget.Size = new System.Drawing.Size(80, 28);
            this.btnSelectTarget.TabIndex = 98;
            this.btnSelectTarget.TabStop = false;
            this.btnSelectTarget.Text = "Select";
            this.btnSelectTarget.UseVisualStyleBackColor = true;
            this.btnSelectTarget.Click += new System.EventHandler(this.btnSelectTarget_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnScanTag);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(900, 36);
            this.panel1.TabIndex = 74;
            // 
            // btnScanTag
            // 
            this.btnScanTag.AutoSize = true;
            this.btnScanTag.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnScanTag.Location = new System.Drawing.Point(3, 3);
            this.btnScanTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnScanTag.Name = "btnScanTag";
            this.btnScanTag.Size = new System.Drawing.Size(134, 28);
            this.btnScanTag.TabIndex = 3;
            this.btnScanTag.TabStop = false;
            this.btnScanTag.Text = "Single Read Tag";
            this.btnScanTag.UseVisualStyleBackColor = true;
            this.btnScanTag.Click += new System.EventHandler(this.btnScanTag_Click);
            // 
            // tabInformation
            // 
            this.tabInformation.Controls.Add(this.tabRW);
            this.tabInformation.Controls.Add(this.tabLock);
            this.tabInformation.Controls.Add(this.tabKill);
            this.tabInformation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabInformation.ItemSize = new System.Drawing.Size(120, 20);
            this.tabInformation.Location = new System.Drawing.Point(0, 480);
            this.tabInformation.Name = "tabInformation";
            this.tabInformation.SelectedIndex = 0;
            this.tabInformation.Size = new System.Drawing.Size(900, 200);
            this.tabInformation.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabInformation.TabIndex = 76;
            // 
            // tabRW
            // 
            this.tabRW.Controls.Add(this.pnlRW);
            this.tabRW.Location = new System.Drawing.Point(4, 24);
            this.tabRW.Name = "tabRW";
            this.tabRW.Padding = new System.Windows.Forms.Padding(3);
            this.tabRW.Size = new System.Drawing.Size(892, 172);
            this.tabRW.TabIndex = 4;
            this.tabRW.Text = "READ/WRITE";
            this.tabRW.UseVisualStyleBackColor = true;
            // 
            // pnlRW
            // 
            this.pnlRW.Controls.Add(this.btnWriteAscii);
            this.pnlRW.Controls.Add(this.txtDataAscii);
            this.pnlRW.Controls.Add(this.lblDataAscii);
            this.pnlRW.Controls.Add(this.txtDataHex);
            this.pnlRW.Controls.Add(this.btnWriteHex);
            this.pnlRW.Controls.Add(this.lblLength);
            this.pnlRW.Controls.Add(this.txtStart);
            this.pnlRW.Controls.Add(this.txtLength);
            this.pnlRW.Controls.Add(this.cmbMem);
            this.pnlRW.Controls.Add(this.lblDataHex);
            this.pnlRW.Controls.Add(this.lblStart);
            this.pnlRW.Controls.Add(this.lblMem);
            this.pnlRW.Controls.Add(this.btnRead);
            this.pnlRW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRW.Location = new System.Drawing.Point(3, 3);
            this.pnlRW.Name = "pnlRW";
            this.pnlRW.Size = new System.Drawing.Size(886, 166);
            this.pnlRW.TabIndex = 2;
            // 
            // btnWriteAscii
            // 
            this.btnWriteAscii.Location = new System.Drawing.Point(622, 95);
            this.btnWriteAscii.Name = "btnWriteAscii";
            this.btnWriteAscii.Size = new System.Drawing.Size(120, 30);
            this.btnWriteAscii.TabIndex = 2304;
            this.btnWriteAscii.TabStop = false;
            this.btnWriteAscii.Text = "Write";
            this.btnWriteAscii.UseVisualStyleBackColor = true;
            this.btnWriteAscii.Click += new System.EventHandler(this.btnWriteAscii_Click);
            // 
            // txtDataAscii
            // 
            this.txtDataAscii.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDataAscii.Location = new System.Drawing.Point(170, 99);
            this.txtDataAscii.Name = "txtDataAscii";
            this.txtDataAscii.Size = new System.Drawing.Size(448, 23);
            this.txtDataAscii.TabIndex = 2303;
            // 
            // lblDataAscii
            // 
            this.lblDataAscii.AutoSize = true;
            this.lblDataAscii.Location = new System.Drawing.Point(12, 102);
            this.lblDataAscii.Name = "lblDataAscii";
            this.lblDataAscii.Size = new System.Drawing.Size(77, 12);
            this.lblDataAscii.TabIndex = 2302;
            this.lblDataAscii.Text = "Data (Ascii)";
            // 
            // txtDataHex
            // 
            this.txtDataHex.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDataHex.Location = new System.Drawing.Point(170, 69);
            this.txtDataHex.Name = "txtDataHex";
            this.txtDataHex.Size = new System.Drawing.Size(448, 23);
            this.txtDataHex.TabIndex = 2301;
            // 
            // btnWriteHex
            // 
            this.btnWriteHex.Location = new System.Drawing.Point(622, 65);
            this.btnWriteHex.Name = "btnWriteHex";
            this.btnWriteHex.Size = new System.Drawing.Size(120, 30);
            this.btnWriteHex.TabIndex = 2300;
            this.btnWriteHex.TabStop = false;
            this.btnWriteHex.Text = "Write";
            this.btnWriteHex.UseVisualStyleBackColor = true;
            this.btnWriteHex.Click += new System.EventHandler(this.btnWriteHex_Click);
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(292, 42);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(119, 12);
            this.lblLength.TabIndex = 2298;
            this.lblLength.Text = "Length (Word Count)";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(170, 39);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(96, 21);
            this.txtStart.TabIndex = 2297;
            this.txtStart.Text = "2";
            this.txtStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(450, 39);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(96, 21);
            this.txtLength.TabIndex = 2296;
            this.txtLength.Text = "6";
            this.txtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbMem
            // 
            this.cmbMem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMem.FormattingEnabled = true;
            this.cmbMem.Items.AddRange(new object[] {
            "00-RFU",
            "01-EPC",
            "02-TID",
            "03-USER"});
            this.cmbMem.Location = new System.Drawing.Point(170, 7);
            this.cmbMem.Name = "cmbMem";
            this.cmbMem.Size = new System.Drawing.Size(96, 20);
            this.cmbMem.TabIndex = 2295;
            // 
            // lblDataHex
            // 
            this.lblDataHex.AutoSize = true;
            this.lblDataHex.Location = new System.Drawing.Point(12, 72);
            this.lblDataHex.Name = "lblDataHex";
            this.lblDataHex.Size = new System.Drawing.Size(65, 12);
            this.lblDataHex.TabIndex = 2294;
            this.lblDataHex.Text = "Data (HEX)";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(12, 42);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(149, 12);
            this.lblStart.TabIndex = 2293;
            this.lblStart.Text = "Start Address (Word Ptr)";
            // 
            // lblMem
            // 
            this.lblMem.AutoSize = true;
            this.lblMem.Location = new System.Drawing.Point(12, 12);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(83, 12);
            this.lblMem.TabIndex = 2292;
            this.lblMem.Text = "Target Memory";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(622, 35);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(120, 30);
            this.btnRead.TabIndex = 2291;
            this.btnRead.TabStop = false;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tabLock
            // 
            this.tabLock.Controls.Add(this.pnlLock);
            this.tabLock.Location = new System.Drawing.Point(4, 24);
            this.tabLock.Name = "tabLock";
            this.tabLock.Padding = new System.Windows.Forms.Padding(3);
            this.tabLock.Size = new System.Drawing.Size(892, 172);
            this.tabLock.TabIndex = 2;
            this.tabLock.Text = "LOCK";
            this.tabLock.UseVisualStyleBackColor = true;
            // 
            // pnlLock
            // 
            this.pnlLock.Controls.Add(this.btnLock);
            this.pnlLock.Controls.Add(this.cmbLockAction);
            this.pnlLock.Controls.Add(this.lblLockAction);
            this.pnlLock.Controls.Add(this.cmbLockType);
            this.pnlLock.Controls.Add(this.lblLockType);
            this.pnlLock.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLock.Location = new System.Drawing.Point(3, 3);
            this.pnlLock.Name = "pnlLock";
            this.pnlLock.Size = new System.Drawing.Size(886, 36);
            this.pnlLock.TabIndex = 2;
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(620, 5);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(120, 30);
            this.btnLock.TabIndex = 2294;
            this.btnLock.TabStop = false;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // cmbLockAction
            // 
            this.cmbLockAction.DisplayMember = "2";
            this.cmbLockAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLockAction.FormattingEnabled = true;
            this.cmbLockAction.Items.AddRange(new object[] {
            "Open",
            "Perma Open",
            "PWD R/W",
            "Perma NOT R/W"});
            this.cmbLockAction.Location = new System.Drawing.Point(450, 8);
            this.cmbLockAction.Name = "cmbLockAction";
            this.cmbLockAction.Size = new System.Drawing.Size(98, 20);
            this.cmbLockAction.TabIndex = 2293;
            this.cmbLockAction.Tag = "";
            // 
            // lblLockAction
            // 
            this.lblLockAction.AutoSize = true;
            this.lblLockAction.Location = new System.Drawing.Point(292, 12);
            this.lblLockAction.Name = "lblLockAction";
            this.lblLockAction.Size = new System.Drawing.Size(77, 12);
            this.lblLockAction.TabIndex = 2292;
            this.lblLockAction.Text = "Lock Action:";
            this.lblLockAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbLockType
            // 
            this.cmbLockType.DisplayMember = "2";
            this.cmbLockType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLockType.FormattingEnabled = true;
            this.cmbLockType.Items.AddRange(new object[] {
            "USER",
            "TID",
            "EPC",
            "Access Pwd",
            "Kill Pwd"});
            this.cmbLockType.Location = new System.Drawing.Point(170, 8);
            this.cmbLockType.Name = "cmbLockType";
            this.cmbLockType.Size = new System.Drawing.Size(99, 20);
            this.cmbLockType.TabIndex = 2291;
            this.cmbLockType.Tag = "";
            // 
            // lblLockType
            // 
            this.lblLockType.AutoSize = true;
            this.lblLockType.Location = new System.Drawing.Point(12, 12);
            this.lblLockType.Name = "lblLockType";
            this.lblLockType.Size = new System.Drawing.Size(65, 12);
            this.lblLockType.TabIndex = 2290;
            this.lblLockType.Text = "Lock Type:";
            this.lblLockType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabKill
            // 
            this.tabKill.Controls.Add(this.pnlKill);
            this.tabKill.Location = new System.Drawing.Point(4, 24);
            this.tabKill.Name = "tabKill";
            this.tabKill.Padding = new System.Windows.Forms.Padding(3);
            this.tabKill.Size = new System.Drawing.Size(892, 172);
            this.tabKill.TabIndex = 0;
            this.tabKill.Text = "KILL";
            this.tabKill.UseVisualStyleBackColor = true;
            // 
            // pnlKill
            // 
            this.pnlKill.Controls.Add(this.ftxtKillPwd);
            this.pnlKill.Controls.Add(this.lblKillPwd);
            this.pnlKill.Controls.Add(this.btnKill);
            this.pnlKill.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKill.Location = new System.Drawing.Point(3, 3);
            this.pnlKill.Name = "pnlKill";
            this.pnlKill.Size = new System.Drawing.Size(886, 36);
            this.pnlKill.TabIndex = 1;
            // 
            // lblKillPwd
            // 
            this.lblKillPwd.AutoSize = true;
            this.lblKillPwd.Location = new System.Drawing.Point(12, 12);
            this.lblKillPwd.Name = "lblKillPwd";
            this.lblKillPwd.Size = new System.Drawing.Size(119, 12);
            this.lblKillPwd.TabIndex = 2292;
            this.lblKillPwd.Text = "Kill Password(HEX):";
            this.lblKillPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(620, 4);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(120, 30);
            this.btnKill.TabIndex = 2291;
            this.btnKill.TabStop = false;
            this.btnKill.Text = "Kill";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // ftxtAccessPwd
            // 
            this.ftxtAccessPwd.ErrorInvalid = false;
            this.ftxtAccessPwd.InputChar = '0';
            this.ftxtAccessPwd.InputMask = "HHHHHHHH";
            this.ftxtAccessPwd.Location = new System.Drawing.Point(153, 8);
            this.ftxtAccessPwd.MaxLength = 8;
            this.ftxtAccessPwd.Name = "ftxtAccessPwd";
            this.ftxtAccessPwd.Size = new System.Drawing.Size(100, 21);
            this.ftxtAccessPwd.StdInputMask = ADControlsLib.Windows.Forms.FormatTextBox.InputMaskType.Custom;
            this.ftxtAccessPwd.TabIndex = 99;
            this.ftxtAccessPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ftxtKillPwd
            // 
            this.ftxtKillPwd.ErrorInvalid = false;
            this.ftxtKillPwd.InputChar = '0';
            this.ftxtKillPwd.InputMask = "HHHHHHHH";
            this.ftxtKillPwd.Location = new System.Drawing.Point(147, 9);
            this.ftxtKillPwd.MaxLength = 8;
            this.ftxtKillPwd.Name = "ftxtKillPwd";
            this.ftxtKillPwd.Size = new System.Drawing.Size(100, 21);
            this.ftxtKillPwd.StdInputMask = ADControlsLib.Windows.Forms.FormatTextBox.InputMaskType.Custom;
            this.ftxtKillPwd.TabIndex = 2293;
            this.ftxtKillPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cdgvShow
            // 
            this.cdgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdgvShow.Location = new System.Drawing.Point(0, 36);
            this.cdgvShow.Name = "cdgvShow";
            this.cdgvShow.Size = new System.Drawing.Size(900, 406);
            this.cdgvShow.TabIndex = 77;
            this.cdgvShow.CellClick += new ADControlsLib.Windows.Forms.TagsDataGridView.CellClickEventHandler(this.cdgvShow_CellClick);
            // 
            // ucMWriteEPC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.cdgvShow);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabInformation);
            this.Name = "ucMWriteEPC";
            this.Size = new System.Drawing.Size(900, 680);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabInformation.ResumeLayout(false);
            this.tabRW.ResumeLayout(false);
            this.pnlRW.ResumeLayout(false);
            this.pnlRW.PerformLayout();
            this.tabLock.ResumeLayout(false);
            this.pnlLock.ResumeLayout(false);
            this.pnlLock.PerformLayout();
            this.tabKill.ResumeLayout(false);
            this.pnlKill.ResumeLayout(false);
            this.pnlKill.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkIsSelectTag;
        private System.Windows.Forms.Label lblAccessPwd;
        private System.Windows.Forms.Label lblSelectedItem;
        private System.Windows.Forms.TextBox txtSelectedItem;
        private System.Windows.Forms.Button btnSelectTarget;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnScanTag;
        private System.Windows.Forms.TabControl tabInformation;
        private System.Windows.Forms.TabPage tabRW;
        private System.Windows.Forms.Panel pnlRW;
        private System.Windows.Forms.Button btnWriteAscii;
        private System.Windows.Forms.TextBox txtDataAscii;
        private System.Windows.Forms.Label lblDataAscii;
        private System.Windows.Forms.TextBox txtDataHex;
        private System.Windows.Forms.Button btnWriteHex;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.ComboBox cmbMem;
        private System.Windows.Forms.Label lblDataHex;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblMem;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TabPage tabLock;
        private System.Windows.Forms.Panel pnlLock;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.ComboBox cmbLockAction;
        private System.Windows.Forms.Label lblLockAction;
        private System.Windows.Forms.ComboBox cmbLockType;
        private System.Windows.Forms.Label lblLockType;
        private System.Windows.Forms.TabPage tabKill;
        private System.Windows.Forms.Panel pnlKill;
        private System.Windows.Forms.Label lblKillPwd;
        private System.Windows.Forms.Button btnKill;
        private ADControlsLib.Windows.Forms.FormatTextBox ftxtAccessPwd;
        private ADControlsLib.Windows.Forms.FormatTextBox ftxtKillPwd;
        private ADControlsLib.Windows.Forms.TagsDataGridView cdgvShow;
    }
}
