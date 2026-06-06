namespace ReaderSDK.Components
{
    partial class TagDataDeal
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
            this.lblPCLen = new System.Windows.Forms.Label();
            this.nudPCLen = new System.Windows.Forms.NumericUpDown();
            this.txtPCLen = new System.Windows.Forms.TextBox();
            this.chkAdd = new System.Windows.Forms.CheckBox();
            this.nudAddStep = new System.Windows.Forms.NumericUpDown();
            this.chkAddHex = new System.Windows.Forms.CheckBox();
            this.lblAddStep = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblCardAll = new System.Windows.Forms.Label();
            this.nudCard = new System.Windows.Forms.NumericUpDown();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.rtxtCardAll = new System.Windows.Forms.RichTextBox();
            this.ftxtCard = new ReaderSDK.Components.FormatTextBox();
            this.ftxtEndData = new ReaderSDK.Components.FormatTextBox();
            this.nudHeadLen = new System.Windows.Forms.NumericUpDown();
            this.lblHead = new System.Windows.Forms.Label();
            this.ftxtHeadData = new ReaderSDK.Components.FormatTextBox();
            this.nudEndLen = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudPCLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeadLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndLen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPCLen
            // 
            this.lblPCLen.AutoSize = true;
            this.lblPCLen.Location = new System.Drawing.Point(12, 12);
            this.lblPCLen.Name = "lblPCLen";
            this.lblPCLen.Size = new System.Drawing.Size(77, 12);
            this.lblPCLen.TabIndex = 0;
            this.lblPCLen.Text = "EPC编码长度:";
            // 
            // nudPCLen
            // 
            this.nudPCLen.Location = new System.Drawing.Point(132, 8);
            this.nudPCLen.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudPCLen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPCLen.Name = "nudPCLen";
            this.nudPCLen.Size = new System.Drawing.Size(40, 21);
            this.nudPCLen.TabIndex = 0;
            this.nudPCLen.TabStop = false;
            this.nudPCLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPCLen.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudPCLen.ValueChanged += new System.EventHandler(this.nudPCLen_ValueChanged);
            // 
            // txtPCLen
            // 
            this.txtPCLen.Location = new System.Drawing.Point(178, 8);
            this.txtPCLen.Name = "txtPCLen";
            this.txtPCLen.ReadOnly = true;
            this.txtPCLen.Size = new System.Drawing.Size(35, 21);
            this.txtPCLen.TabIndex = 20;
            this.txtPCLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkAdd
            // 
            this.chkAdd.AutoSize = true;
            this.chkAdd.Location = new System.Drawing.Point(418, 10);
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.Size = new System.Drawing.Size(72, 16);
            this.chkAdd.TabIndex = 2;
            this.chkAdd.TabStop = false;
            this.chkAdd.Text = "是否递增";
            this.chkAdd.UseVisualStyleBackColor = true;
            this.chkAdd.CheckedChanged += new System.EventHandler(this.chkAdd_CheckedChanged);
            // 
            // nudAddStep
            // 
            this.nudAddStep.Location = new System.Drawing.Point(372, 8);
            this.nudAddStep.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudAddStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAddStep.Name = "nudAddStep";
            this.nudAddStep.Size = new System.Drawing.Size(40, 21);
            this.nudAddStep.TabIndex = 1;
            this.nudAddStep.TabStop = false;
            this.nudAddStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudAddStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAddStep.ValueChanged += new System.EventHandler(this.nudAddStep_ValueChanged);
            // 
            // chkAddHex
            // 
            this.chkAddHex.AutoSize = true;
            this.chkAddHex.Location = new System.Drawing.Point(520, 10);
            this.chkAddHex.Name = "chkAddHex";
            this.chkAddHex.Size = new System.Drawing.Size(120, 16);
            this.chkAddHex.TabIndex = 3;
            this.chkAddHex.TabStop = false;
            this.chkAddHex.Text = "是否按10进制递增";
            this.chkAddHex.UseVisualStyleBackColor = true;
            this.chkAddHex.CheckedChanged += new System.EventHandler(this.chkAddHex_CheckedChanged);
            // 
            // lblAddStep
            // 
            this.lblAddStep.AutoSize = true;
            this.lblAddStep.Location = new System.Drawing.Point(252, 12);
            this.lblAddStep.Name = "lblAddStep";
            this.lblAddStep.Size = new System.Drawing.Size(59, 12);
            this.lblAddStep.TabIndex = 21;
            this.lblAddStep.Text = "递增步长:";
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(12, 42);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(71, 12);
            this.lblCard.TabIndex = 16;
            this.lblCard.Text = "待写入卡号:";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(12, 102);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(119, 12);
            this.lblEnd.TabIndex = 18;
            this.lblEnd.Text = "尾部固定数据(Byte):";
            // 
            // lblCardAll
            // 
            this.lblCardAll.AutoSize = true;
            this.lblCardAll.Location = new System.Drawing.Point(12, 132);
            this.lblCardAll.Name = "lblCardAll";
            this.lblCardAll.Size = new System.Drawing.Size(95, 12);
            this.lblCardAll.TabIndex = 19;
            this.lblCardAll.Text = "待写入完整卡号:";
            // 
            // nudCard
            // 
            this.nudCard.Location = new System.Drawing.Point(132, 38);
            this.nudCard.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudCard.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCard.Name = "nudCard";
            this.nudCard.Size = new System.Drawing.Size(40, 21);
            this.nudCard.TabIndex = 4;
            this.nudCard.TabStop = false;
            this.nudCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCard.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudCard.ValueChanged += new System.EventHandler(this.nudCard_ValueChanged);
            // 
            // btnPlus
            // 
            this.btnPlus.AutoSize = true;
            this.btnPlus.Location = new System.Drawing.Point(557, 37);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(75, 22);
            this.btnPlus.TabIndex = 10;
            this.btnPlus.TabStop = false;
            this.btnPlus.Text = "加一";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.AutoSize = true;
            this.btnMinus.Location = new System.Drawing.Point(638, 36);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(75, 22);
            this.btnMinus.TabIndex = 11;
            this.btnMinus.TabStop = false;
            this.btnMinus.Text = "减一";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnRight
            // 
            this.btnRight.AutoSize = true;
            this.btnRight.Location = new System.Drawing.Point(638, 126);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 22);
            this.btnRight.TabIndex = 13;
            this.btnRight.TabStop = false;
            this.btnRight.Text = "右移";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.AutoSize = true;
            this.btnLeft.Location = new System.Drawing.Point(557, 126);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 22);
            this.btnLeft.TabIndex = 12;
            this.btnLeft.TabStop = false;
            this.btnLeft.Text = "左移";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // rtxtCardAll
            // 
            this.rtxtCardAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtCardAll.DetectUrls = false;
            this.rtxtCardAll.Location = new System.Drawing.Point(132, 129);
            this.rtxtCardAll.MaxLength = 35;
            this.rtxtCardAll.Multiline = false;
            this.rtxtCardAll.Name = "rtxtCardAll";
            this.rtxtCardAll.ReadOnly = true;
            this.rtxtCardAll.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtxtCardAll.Size = new System.Drawing.Size(322, 21);
            this.rtxtCardAll.TabIndex = 14;
            this.rtxtCardAll.TabStop = false;
            this.rtxtCardAll.Text = "";
            this.rtxtCardAll.WordWrap = false;
            // 
            // ftxtCard
            // 
            this.ftxtCard.ErrorInvalid = false;
            this.ftxtCard.InputChar = '0';
            this.ftxtCard.InputMask = "HH-HH-HH-HH";
            this.ftxtCard.Location = new System.Drawing.Point(178, 38);
            this.ftxtCard.MaxLength = 11;
            this.ftxtCard.Name = "ftxtCard";
            this.ftxtCard.Size = new System.Drawing.Size(276, 21);
            this.ftxtCard.StdInputMask = ReaderSDK.Components.FormatTextBox.InputMaskType.Custom;
            this.ftxtCard.TabIndex = 5;
            this.ftxtCard.TabStop = false;
            this.ftxtCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ftxtCard.TextChanged += new System.EventHandler(this.ftxtCard_TextChanged);
            // 
            // ftxtEndData
            // 
            this.ftxtEndData.ErrorInvalid = false;
            this.ftxtEndData.InputChar = '0';
            this.ftxtEndData.InputMask = "";
            this.ftxtEndData.Location = new System.Drawing.Point(178, 98);
            this.ftxtEndData.MaxLength = 0;
            this.ftxtEndData.Name = "ftxtEndData";
            this.ftxtEndData.Size = new System.Drawing.Size(276, 21);
            this.ftxtEndData.StdInputMask = ReaderSDK.Components.FormatTextBox.InputMaskType.None;
            this.ftxtEndData.TabIndex = 9;
            this.ftxtEndData.TabStop = false;
            this.ftxtEndData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ftxtEndData.TextChanged += new System.EventHandler(this.ftxtHeadEnd_TextChanged);
            // 
            // nudHeadLen
            // 
            this.nudHeadLen.Location = new System.Drawing.Point(132, 68);
            this.nudHeadLen.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudHeadLen.Name = "nudHeadLen";
            this.nudHeadLen.Size = new System.Drawing.Size(40, 21);
            this.nudHeadLen.TabIndex = 6;
            this.nudHeadLen.TabStop = false;
            this.nudHeadLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudHeadLen.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudHeadLen.ValueChanged += new System.EventHandler(this.nudHeadLen_ValueChanged);
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.Location = new System.Drawing.Point(12, 72);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(119, 12);
            this.lblHead.TabIndex = 17;
            this.lblHead.Text = "前部固定数据(Byte):";
            // 
            // ftxtHeadData
            // 
            this.ftxtHeadData.ErrorInvalid = false;
            this.ftxtHeadData.InputChar = '0';
            this.ftxtHeadData.InputMask = "HH-HH-HH-HH";
            this.ftxtHeadData.Location = new System.Drawing.Point(178, 68);
            this.ftxtHeadData.MaxLength = 11;
            this.ftxtHeadData.Name = "ftxtHeadData";
            this.ftxtHeadData.Size = new System.Drawing.Size(276, 21);
            this.ftxtHeadData.StdInputMask = ReaderSDK.Components.FormatTextBox.InputMaskType.Custom;
            this.ftxtHeadData.TabIndex = 7;
            this.ftxtHeadData.TabStop = false;
            this.ftxtHeadData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ftxtHeadData.TextChanged += new System.EventHandler(this.ftdHeadData_TextChanged);
            // 
            // nudEndLen
            // 
            this.nudEndLen.Location = new System.Drawing.Point(132, 98);
            this.nudEndLen.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudEndLen.Name = "nudEndLen";
            this.nudEndLen.Size = new System.Drawing.Size(40, 21);
            this.nudEndLen.TabIndex = 8;
            this.nudEndLen.TabStop = false;
            this.nudEndLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudEndLen.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudEndLen.ValueChanged += new System.EventHandler(this.nudEndLen_ValueChanged);
            // 
            // TagDataDeal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.nudEndLen);
            this.Controls.Add(this.nudHeadLen);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.ftxtHeadData);
            this.Controls.Add(this.rtxtCardAll);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.nudCard);
            this.Controls.Add(this.lblPCLen);
            this.Controls.Add(this.nudPCLen);
            this.Controls.Add(this.txtPCLen);
            this.Controls.Add(this.chkAdd);
            this.Controls.Add(this.nudAddStep);
            this.Controls.Add(this.chkAddHex);
            this.Controls.Add(this.lblAddStep);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.ftxtCard);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.ftxtEndData);
            this.Controls.Add(this.lblCardAll);
            this.Name = "TagDataDeal";
            this.Size = new System.Drawing.Size(800, 160);
            this.Load += new System.EventHandler(this.TagDataDeal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPCLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeadLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndLen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPCLen;
        private System.Windows.Forms.NumericUpDown nudPCLen;
        private System.Windows.Forms.TextBox txtPCLen;
        private System.Windows.Forms.CheckBox chkAdd;
        private System.Windows.Forms.NumericUpDown nudAddStep;
        private System.Windows.Forms.CheckBox chkAddHex;
        private System.Windows.Forms.Label lblAddStep;
        private System.Windows.Forms.Label lblCard;
        private ReaderSDK.Components.FormatTextBox ftxtCard;
        private System.Windows.Forms.Label lblEnd;
        private ReaderSDK.Components.FormatTextBox ftxtEndData;
        private System.Windows.Forms.Label lblCardAll;
        private System.Windows.Forms.NumericUpDown nudCard;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.RichTextBox rtxtCardAll;
        private System.Windows.Forms.NumericUpDown nudHeadLen;
        private System.Windows.Forms.Label lblHead;
        private ReaderSDK.Components.FormatTextBox ftxtHeadData;
        private System.Windows.Forms.NumericUpDown nudEndLen;
    }
}
