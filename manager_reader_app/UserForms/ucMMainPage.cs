using ADRcpLib;
using ADUtilsLib.Initializer;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ReaderSDK
{
    public partial class ucMMainPage : UserControl
    {
        ucMReadDemo mReadDemo = new ucMReadDemo();
        ucMBaseSettings mBaseSettings = new ucMBaseSettings();
        //ucMSeniorSettings mSeniorSettings = new ucMSeniorSettings();
        ucMWriteEPC mWriteEPC = new ucMWriteEPC();

        //ucMCustomSettings mCustomSettings = new ucMCustomSettings();

        public ucMMainPage()
        {
            InitializeComponent();
        }
        #region ---PUBLIC----
        public void ChangeLanguage()
        {
            try
            {
                string[] m_def_en = new string[] {" READ DEMO ",
                    " BASE SETTINGS ",
                    //" SENIOR SETTINGS ",
                    //" CUSTOM SETTINGS ",
                    " EPC(GEN 2) READ&&WRITE "};

                string[] m_def_cn = new string[] { "读卡演示", "基本参数",  "EPC(GEN 2) 读写操作" }; //"高级参数", "自定义参数设置",

                string[] m_def_tw = new string[] { "讀卡演示", "基本參數",  "EPC(GEN 2) 讀寫操作" }; //"高級參數", "自定義參數設置",

                string[] MainValue = IniSettings.LoadLanguage(@"mm/base", m_def_en, m_def_cn, m_def_tw);
                int index = 0;

                tabReadDemo.Text = MainValue[index++];
                tabBaseSettings.Text = MainValue[index++];
                //tabSeniorSettings.Text = MainValue[index++];
                //tabCustomSettings.Text = MainValue[index++];
                tabWriteEPC.Text = MainValue[index++];
            }
            catch { }

            
            mReadDemo.ChangeLanguage();
            mBaseSettings.ChangeLanguage();
            //mSeniorSettings.ChangeLanguage();
            //mCustomSettings.ChangeLanguage();
            mWriteEPC.ChangeLanguage();
            
        }
        #endregion

        #region ---local----
        public void ParseRsp(ProtocolPacket Data)
        {
            switch (Data.Code)
            {
                case RcpBase.RCP_MM_RESET:
                    ResetOperation();
                    break;
                case RcpBase.RCP_CMD_INFO:
                    if (Data.Length > 12 && (Data.Type & 0x7f) == 0)
                    {
                        #region ---Parameter---
                        string strInfo = Encoding.ASCII.GetString(Data.Payload, 0, Data.Length);

                        #endregion
                        ResetOperation();
                    }
                    //mCustomSettings.ParseRsp(Data);
                    break;
                case RcpBase.RCP_MM_ANT:
                case RcpBase.RCP_MM_PARA:
                case RcpBase.RCP_MM_OUTCARD:
                    mBaseSettings.ParseRsp(Data);
                    break;

                case RcpBase.RCP_MM_EPT:
                case RcpBase.RCP_MM_ADDR:
                case RcpBase.RCP_MM_UART:
                case RcpBase.RCP_MM_SET_GPIO:
                case RcpBase.RCP_MM_GET_GPIO:
                    //mCustomSettings.ParseRsp(Data);
                    break;
                case RcpBase.RCP_MM_GET_TX_PWR:
                case RcpBase.RCP_MM_SET_TX_PWR:
                case RcpBase.RCP_MM_GET_REGION:
                case RcpBase.RCP_MM_SET_REGION:
                case RcpBase.RCP_MM_GET_CH:
                case RcpBase.RCP_MM_SET_CH:
                case RcpBase.RCP_MM_GET_MODULATION:
                case RcpBase.RCP_MM_SET_MODULATION:
                case RcpBase.RCP_MM_GET_HOPPING_TBL:
                case RcpBase.RCP_MM_SET_HOPPING_TBL:
                case RcpBase.RCP_MM_GET_FH_LBT:
                case RcpBase.RCP_MM_SET_FH_LBT:
                    //mSeniorSettings.ParseRsp(Data);
                    break;
                case RcpBase.RCP_MM_READ_C_UII:
                case RcpBase.RCP_MM_READ_C_DT:
                case RcpBase.RCP_MM_WRITE_C_DT:
                case RcpBase.RCP_MM_GET_ACCESS_EPC_MATCH:
                case RcpBase.RCP_MM_SET_ACCESS_EPC_MATCH:
                    if (tabWriteEPC == tabMain.SelectedTab)
                    {
                          mWriteEPC.ParseRsp(Data);
                    }
                    else
                    {  
                         mReadDemo.ParseRsp(Data);
                    }
                    break;
                default:
                    break;
            }
        }

        private bool processing = false;

        private Thread SyncThread = null;
        public void ResetOperation()
        {
            Application.DoEvents();
            Thread.Sleep(200);
            Application.DoEvents();
            Thread.Sleep(200);
            Application.DoEvents();
            Thread.Sleep(200);
            if (processing) return;

            if (SyncThread == null || SyncThread.IsAlive == false)
            {
                SyncThread = new Thread(new ThreadStart(syncParameters));
                SyncThread.Start();
            }
        }

        private void syncParameters()
        {
            processing = true;
            Thread.Sleep(100);

            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_PARA, RcpBase.RCP_MSG_GET));
            Application.DoEvents();
            Thread.Sleep(100);

            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_OUTCARD, RcpBase.RCP_MSG_GET));
            Application.DoEvents();
            Thread.Sleep(100);
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_EPT, RcpBase.RCP_MSG_GET));
            Application.DoEvents();
            Thread.Sleep(100);

            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_GET_REGION, RcpBase.RCP_MSG_CMD));
            Application.DoEvents();
            Thread.Sleep(100);
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_GET_CH, RcpBase.RCP_MSG_CMD));
            Application.DoEvents();
            Thread.Sleep(100);
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_GET_TX_PWR, RcpBase.RCP_MSG_CMD));
            Application.DoEvents();
            Thread.Sleep(100);
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_GET_FH_LBT, RcpBase.RCP_MSG_CMD));
            Application.DoEvents();
            Thread.Sleep(100);
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_GET_MODULATION, RcpBase.RCP_MSG_CMD));
            Application.DoEvents();
            Thread.Sleep(100);
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_ADDR, RcpBase.RCP_MSG_GET));
            Application.DoEvents();
            Thread.Sleep(100);
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_UART, RcpBase.RCP_MSG_GET));
            Application.DoEvents();
            Thread.Sleep(100);
            List<byte> param = new List<byte>();
            param.Add((byte)(1));
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_GET_GPIO, RcpBase.RCP_MSG_CMD, param.ToArray()));
            Application.DoEvents();
            Thread.Sleep(100);

            processing = false;
        }
        #endregion

        private void ucMMainPage_Load(object sender, System.EventArgs e)
        {
            mReadDemo.Parent = tabReadDemo;
            mBaseSettings.Parent = tabBaseSettings;
            //mSeniorSettings.Parent = tabSeniorSettings;
            mWriteEPC.Parent = tabWriteEPC;

            //mCustomSettings.Parent = tabCustomSettings;

            mReadDemo.Dock = DockStyle.Fill;
            mBaseSettings.Dock = DockStyle.Fill;
            //mSeniorSettings.Dock = DockStyle.Fill;
            mWriteEPC.Dock = DockStyle.Fill;

            //mCustomSettings.Dock = DockStyle.Fill;

            //if (IniSettings.Communication ==2)
            //{
            //    this.tabMain.TabPages.Remove(this.tabCustomSettings);
            //}
        }
    }
}
