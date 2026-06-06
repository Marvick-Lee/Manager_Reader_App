using ReaderLib.Initializer;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReaderSDK.Components
{
    public partial class StatusListView : UserControl
    {
        public StatusListView()
        {
            InitializeComponent();
        }

        public void ChangeLanguage()
        {

            switch (IniSettings.AppsLanguage)
            {
                case LngType.CHN:
                    lvwPackectMsg.Columns[0].Text = "时间";
                    lvwPackectMsg.Columns[1].Text = "数据类型";
                    lvwPackectMsg.Columns[2].Text = "数据包(16进制)";
                    //listViewStatus.Columns[3].Text = "细节";

                    lvwStatusMsg.Columns[0].Text = "时间";
                    lvwStatusMsg.Columns[1].Text = "当前状态";
                    break;
                default:
                    lvwPackectMsg.Columns[0].Text = "Time";
                    lvwPackectMsg.Columns[1].Text = "RCP Type";
                    lvwPackectMsg.Columns[2].Text = "RCP Packet(HEX)";
                    //listViewStatus.Columns[3].Text = "Details";

                    lvwStatusMsg.Columns[0].Text = "Time";
                    lvwStatusMsg.Columns[1].Text = "Current Status";
                    break;
            }
        }

        public void SetStatusMsg(string s)
        {
            if (!_IsShowStatus) return;
            if (this.IsDisposed)
                return;

            if (!InvokeRequired)
            {
                __DisplayStatusString(s);
                return;
            }

            this.BeginInvoke(new MethodInvoker(delegate()
            {
                __DisplayStatusString(s);
            }));
        }
        public void SetLog(byte[] d, int isRx)
        {
            if (!_IsShowStatus) return;
            if (this.IsDisposed)
                return;

            if (!InvokeRequired)
            {
                __DisplayPacketString(d, isRx);
                return;
            }

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                __DisplayPacketString(d, isRx);
            }));
        }

        private void __DisplayStatusString(string s)
        {
            if (!this.IsDisposed)
            {
                ListViewItem lvt = new ListViewItem(DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00") + " " + DateTime.Now.Millisecond.ToString("000"));

                lvt.SubItems.Add(s);

                // listViewMsg.Visible = false;
                if (lvwStatusMsg.Items.Count > 3000)
                {
                    lvwStatusMsg.Items.Clear();
                }
                lvwStatusMsg.Items.Add(lvt).EnsureVisible();
                lvwStatusMsg.Update();
                //listViewStatus.Visible = true;
            }
        }

        private void __DisplayPacketString(byte[] d,int isRx)
        {
            if (!this.IsDisposed)
            {
                StringBuilder byteToString = new StringBuilder();

                for (int i = 0; i < d.Length; i++)
                {
                    byteToString.Append(string.Format("{0:X2} ", d[i]));
                }
                if (d[0] == 0xcc && d[4] == 0x32)
                {
                    isRx = 2;
                }
                if (d[0] == 0xcc && d[3] == 0x20 && d[4] == 0x05)
                {
                    isRx = 2;
                }

                ListViewItem lvt = new ListViewItem(DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00") + " " + DateTime.Now.Millisecond.ToString("000"));


                Color bc = Color.White;

                switch (isRx)
                {
                    case 0:
                        lvt.BackColor = Color.OldLace;
                        lvt.SubItems.Add(IniSettings.GetLanguageString("RCP CMD", "下发命令"));
                        break;
                    case 1:
                        lvt.BackColor = Color.Lavender;
                        lvt.SubItems.Add(IniSettings.GetLanguageString("RCP RSP", "设备回复"));
                        break;
                    case 2:
                        lvt.BackColor = Color.LemonChiffon;
                        lvt.SubItems.Add(IniSettings.GetLanguageString("RCP AUTO", "设备上送"));
                        break;
                    default:
                        lvt.BackColor = Color.White;
                        lvt.SubItems.Add("");
                        break;
                }
                lvt.SubItems.Add(byteToString.ToString());

                // listViewMsg.Visible = false;
                if (lvwPackectMsg.Items.Count > 500)
                {
                    lvwPackectMsg.Items.Clear();
                }
                lvwPackectMsg.Items.Add(lvt).EnsureVisible();
                lvwPackectMsg.Update();
                //listViewStatus.Visible = true;
            }
        }
        private bool _IsShowStatus = true;
        public bool IsShowStatus
        {
            set
            {
                _IsShowStatus = value;
                lvwPackectMsg.Visible = _IsShowStatus;
            }
            get { return _IsShowStatus; }
        }

        #region ---DispalyMsg---
        private StringBuilder msgSb = new StringBuilder();

        private void tsMenuItemClear_Click(object sender, EventArgs e)
        {
            lvwStatusMsg.Items.Clear();
            lvwPackectMsg.Items.Clear();
            msgSb.Remove(0, msgSb.Length);
        }

        private void tsMenuItemCopy_Click(object sender, EventArgs e)
        {
            if (lvwPackectMsg.SelectedItems != null && lvwPackectMsg.SelectedItems.Count != 0)
            {
                string strmsg = "";
                for (int i = 0; i < lvwPackectMsg.Columns.Count; i++)
                {
                    strmsg += lvwPackectMsg.SelectedItems[0].SubItems[i].Text + "\t";
                }
                try
                {
                    Clipboard.SetText(strmsg);
                }
                catch { }
            }
        }

        private void tsMenuItemCopyAll_Click(object sender, EventArgs e)
        {
            msgSb.Remove(0, msgSb.Length);
            foreach (ListViewItem lvi in lvwPackectMsg.Items)
            {
                string strmsg = "";
                for (int i = 0; i < lvwPackectMsg.Columns.Count; i++)
                {
                    try
                    {
                        strmsg += lvi.SubItems[i].Text + "\t";
                    }
                    catch { }
                }
                msgSb.Append(strmsg + Environment.NewLine);
            }
            if (msgSb != null && msgSb.Length != 0) Clipboard.SetText(msgSb.ToString());
        }

        #endregion
    }
}
