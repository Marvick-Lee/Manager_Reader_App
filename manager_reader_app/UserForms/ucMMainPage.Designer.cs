namespace ReaderSDK
{
    partial class ucMMainPage
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
            this.tabWriteEPC = new System.Windows.Forms.TabPage();
            this.tabBaseSettings = new System.Windows.Forms.TabPage();
            this.tabReadDemo = new System.Windows.Forms.TabPage();
            this.tabMain = new System.Windows.Forms.TabControl();
            //this.tabCustomSettings = new System.Windows.Forms.TabPage();
            //this.tabSeniorSettings = new System.Windows.Forms.TabPage();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabWriteEPC
            // 
            this.tabWriteEPC.Location = new System.Drawing.Point(4, 25);
            this.tabWriteEPC.Name = "tabWriteEPC";
            this.tabWriteEPC.Size = new System.Drawing.Size(950, 484);
            this.tabWriteEPC.TabIndex = 4;
            this.tabWriteEPC.Text = "EPC(GEM 2) READ&&WRITE";
            this.tabWriteEPC.UseVisualStyleBackColor = true;
            // 
            // tabBaseSettings
            // 
            this.tabBaseSettings.Location = new System.Drawing.Point(4, 25);
            this.tabBaseSettings.Name = "tabBaseSettings";
            this.tabBaseSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaseSettings.Size = new System.Drawing.Size(950, 484);
            this.tabBaseSettings.TabIndex = 1;
            this.tabBaseSettings.Text = "BASE SETTINGS";
            this.tabBaseSettings.UseVisualStyleBackColor = true;
            // 
            // tabReadDemo
            // 
            this.tabReadDemo.Location = new System.Drawing.Point(4, 25);
            this.tabReadDemo.Name = "tabReadDemo";
            this.tabReadDemo.Padding = new System.Windows.Forms.Padding(3);
            this.tabReadDemo.Size = new System.Drawing.Size(950, 484);
            this.tabReadDemo.TabIndex = 0;
            this.tabReadDemo.Text = "READ DEMO";
            this.tabReadDemo.UseVisualStyleBackColor = true;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabReadDemo);
            this.tabMain.Controls.Add(this.tabBaseSettings);
            //this.tabMain.Controls.Add(this.tabSeniorSettings);
            //this.tabMain.Controls.Add(this.tabCustomSettings);
            this.tabMain.Controls.Add(this.tabWriteEPC);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(958, 513);
            this.tabMain.TabIndex = 0;
            // 
            // tabCustomSettings
            // 
            //this.tabCustomSettings.Location = new System.Drawing.Point(4, 25);
            //this.tabCustomSettings.Name = "tabCustomSettings";
            //this.tabCustomSettings.Size = new System.Drawing.Size(950, 484);
            //this.tabCustomSettings.TabIndex = 3;
            //this.tabCustomSettings.Text = "CUSTOM SETTINGS";
            //this.tabCustomSettings.UseVisualStyleBackColor = true;
            // 
            // tabSeniorSettings
            // 
            //this.tabSeniorSettings.Location = new System.Drawing.Point(4, 25);
            //this.tabSeniorSettings.Name = "tabSeniorSettings";
            //this.tabSeniorSettings.Size = new System.Drawing.Size(950, 484);
            //this.tabSeniorSettings.TabIndex = 2;
            //this.tabSeniorSettings.Text = "SENIOR SETTINGS";
            //this.tabSeniorSettings.UseVisualStyleBackColor = true;
            // 
            // ucMMainPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tabMain);
            this.Name = "ucMMainPage";
            this.Size = new System.Drawing.Size(958, 513);
            this.Load += new System.EventHandler(this.ucMMainPage_Load);
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabWriteEPC;
        private System.Windows.Forms.TabPage tabBaseSettings;
        private System.Windows.Forms.TabPage tabReadDemo;
        private System.Windows.Forms.TabControl tabMain;
        //private System.Windows.Forms.TabPage tabSeniorSettings;
        //private System.Windows.Forms.TabPage tabCustomSettings;
    }
}
