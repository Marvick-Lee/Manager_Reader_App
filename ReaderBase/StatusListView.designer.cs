namespace ReaderSDK.Components
{
    partial class StatusListView
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvwPackectMsg = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSpet = new System.Windows.Forms.Label();
            this.lvwStatusMsg = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwPackectMsg
            // 
            this.lvwPackectMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwPackectMsg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwPackectMsg.ContextMenuStrip = this.contextMenuStrip;
            this.lvwPackectMsg.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvwPackectMsg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwPackectMsg.FullRowSelect = true;
            this.lvwPackectMsg.Location = new System.Drawing.Point(0, 0);
            this.lvwPackectMsg.MultiSelect = false;
            this.lvwPackectMsg.Name = "lvwPackectMsg";
            this.lvwPackectMsg.Size = new System.Drawing.Size(610, 130);
            this.lvwPackectMsg.TabIndex = 5;
            this.lvwPackectMsg.UseCompatibleStateImageBehavior = false;
            this.lvwPackectMsg.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "RCP Packet (HEX)";
            this.columnHeader3.Width = 420;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemClear,
            this.tsMenuItemCopy,
            this.tsMenuItemCopyAll});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(100, 70);
            // 
            // tsMenuItemClear
            // 
            this.tsMenuItemClear.Name = "tsMenuItemClear";
            this.tsMenuItemClear.Size = new System.Drawing.Size(99, 22);
            this.tsMenuItemClear.Text = "C&lear";
            this.tsMenuItemClear.Click += new System.EventHandler(this.tsMenuItemClear_Click);
            // 
            // tsMenuItemCopy
            // 
            this.tsMenuItemCopy.Name = "tsMenuItemCopy";
            this.tsMenuItemCopy.Size = new System.Drawing.Size(99, 22);
            this.tsMenuItemCopy.Text = "&Copy";
            this.tsMenuItemCopy.Click += new System.EventHandler(this.tsMenuItemCopy_Click);
            // 
            // tsMenuItemCopyAll
            // 
            this.tsMenuItemCopyAll.Name = "tsMenuItemCopyAll";
            this.tsMenuItemCopyAll.Size = new System.Drawing.Size(99, 22);
            this.tsMenuItemCopyAll.Text = "Copy &All";
            this.tsMenuItemCopyAll.Click += new System.EventHandler(this.tsMenuItemCopyAll_Click);
            // 
            // lblSpet
            // 
            this.lblSpet.BackColor = System.Drawing.Color.Black;
            this.lblSpet.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSpet.Location = new System.Drawing.Point(610, 0);
            this.lblSpet.Name = "lblSpet";
            this.lblSpet.Size = new System.Drawing.Size(1, 130);
            this.lblSpet.TabIndex = 6;
            this.lblSpet.Text = "label1";
            // 
            // lvwStatusMsg
            // 
            this.lvwStatusMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwStatusMsg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader4});
            this.lvwStatusMsg.ContextMenuStrip = this.contextMenuStrip;
            this.lvwStatusMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwStatusMsg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwStatusMsg.FullRowSelect = true;
            this.lvwStatusMsg.Location = new System.Drawing.Point(611, 0);
            this.lvwStatusMsg.MultiSelect = false;
            this.lvwStatusMsg.Name = "lvwStatusMsg";
            this.lvwStatusMsg.Size = new System.Drawing.Size(347, 130);
            this.lvwStatusMsg.TabIndex = 7;
            this.lvwStatusMsg.UseCompatibleStateImageBehavior = false;
            this.lvwStatusMsg.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Time";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Current Status";
            this.columnHeader4.Width = 234;
            // 
            // StatusListView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lvwStatusMsg);
            this.Controls.Add(this.lblSpet);
            this.Controls.Add(this.lvwPackectMsg);
            this.Name = "StatusListView";
            this.Size = new System.Drawing.Size(958, 130);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwPackectMsg;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemClear;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemCopyAll;
        private System.Windows.Forms.Label lblSpet;
        private System.Windows.Forms.ListView lvwStatusMsg;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
