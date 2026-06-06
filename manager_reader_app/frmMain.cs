using ADRcpLib;
using ADUtilsLib.Initializer;
using System;
using System.Text;
using System.Windows.Forms;

namespace ReaderSDK
{
    public partial class frmMain : Form
    {
        ucMMainPage ucMainPage = new ucMMainPage();

        public void InterfaceInit()
        {
            if (ucMainPage != null)
            {
                ucMainPage.Parent = pnlInformation;
                ucMainPage.Dock = DockStyle.Fill;
            }
        }
        public void InterfaceEnabled(bool flags)
        {
            if (ucMainPage != null) ucMainPage.Enabled = flags;
        }

        public void InterfaceProtocolPacket(ProtocolPacket protocolPacket)
        {
            if (ucMainPage != null) ucMainPage.ParseRsp(protocolPacket);
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InterfaceInit();
            this.Text = "Manager Reader";
            RcpInit();
        }

        private void RcpInit()
        {
            SystemPub.RcpBase.RxRspParsed += RcpBase_RxRspParsed;
            SystemPub.RcpBase.TxRspParsed += RcpBase_TxRspParsed;
        }

        private void RcpBase_TxRspParsed(object sender, ProtocolEventArgs e)
        {
            statusListView1.SetLog(e.Data, 0);
        }

        private void RcpBase_RxRspParsed(object sender, ProtocolEventArgs e)
        {
            statusListView1.SetLog(e.Data, 1);
            if (this.IsDisposed)
                return;

            if (!this.InvokeRequired)
            {
                __ParseRsp(e.Protocol);
                return;
            }

            this.Invoke(new MethodInvoker(delegate ()
            {
                try
                {
                    __ParseRsp(e.Protocol);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }));
        }

        private void __ParseRsp(ProtocolPacket protocolPacket)
        {
            tsStatusPortOpen.Text = "CONNECTED";
            switch (protocolPacket.Code)
            {
                case RcpBase.RCP_CMD_INFO:
                    if (protocolPacket.Length > 30 && (protocolPacket.Type & 0x7f) == 0)
                    {
                        #region ---Parameter---
                        string strInfo = Encoding.ASCII.GetString(protocolPacket.Payload, 0, protocolPacket.Length);

                        tsFWVersion.Text = "Type:" + SystemPub.RcpBase.Mode + SystemPub.RcpBase.Type + " - Version:" + SystemPub.RcpBase.Version + " - Address: " + SystemPub.RcpBase.Address;
                        #endregion
                    }
                    break;
            }
            InterfaceProtocolPacket(protocolPacket);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemPub.DisConnectSio();
        }
        private void tsmiConnect_Click(object sender, EventArgs e)
        {
            if (SystemPub.IsConnectedSio)
            {
                tsFWVersion.Text = "";
                SystemPub.SioBase.onReceived -= SioBase_onReceived;
                SystemPub.DisConnectSio();
                SystemPub.RcpBase.Address = 65535;
                return;
            }
            new frmConnect().ShowDialog();
            if (SystemPub.IsConnectedSio)
            {
                SystemPub.SioBase.onReceived += SioBase_onReceived;

                this.Invoke(new MethodInvoker(delegate ()
                {
                    SystemPub.SendSio(new ProtocolPacket(65535, RcpBase.RCP_CMD_INFO, RcpBase.RCP_MSG_GET, null));

                }));
            }

            tsStatusPortOpen.Text = SystemPub.IsConnectedSio ? "OPEN" : "CLOSE";
        }

        private void SioBase_onReceived(object sender, ADSioLib.ReceivedEventArgs e)
        {
            SystemPub.RcpBase.ReciveBytePkt(e.Data);
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            tsmiConnect.Text = SystemPub.IsConnectedSio ? "DisConnect" : "Connect";

            //tsmiInfo.Visible = SystemPub.IsConnectedSio;

            InterfaceEnabled(SystemPub.IsConnectedSio);

            tsStatusPort.Text = IniSettings.HostName;
            tsStatusBr.Text = IniSettings.HostPort.ToString();
        }

        private void tsmiInfo_Click(object sender, EventArgs e)
        {
            SystemPub.SendSio(new ProtocolPacket(65535, RcpBase.RCP_CMD_INFO, RcpBase.RCP_MSG_GET, null));
        }

        private void mnuBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
