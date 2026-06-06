using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using ADSioLib;

using ADUtilsLib.Initializer;

namespace ReaderSDK
{
    public partial class frmConnect : Form
    {
        public frmConnect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载通讯默认值
        /// </summary>
        private void LoadCommunication()
        {
            IniSettings.LoadCommunication();

            cmbPortName.Items.Clear();
            foreach (string st in SerialPort.GetPortNames())
            {
                int i = 0;
                for (i = st.Length - 1; i > 3; i--)
                {
                    if (SystemPub.IsUint(st.Substring(i, 1)))
                    {
                        break;
                    }
                }
                cmbPortName.Items.Add(st.Substring(0, (i + 1)));
            }

            try
            {
                cmbPortName.Text = IniSettings.PortName;
                cmbBaudRate.Text = IniSettings.BaudRate.ToString();
                txtRemoteIP.Text = IniSettings.IP;
                txtRemotePort.Text = IniSettings.IPPort.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            LoadCommType(IniSettings.Communication);
        }

        /// <summary>
        /// 加载界面语言选择
        /// </summary>
        public void LoadCommLanguage()
        {
            try
            {
                string[] m_def_en = new string[] { "Configuration",
                                                    "Serial Interface","Net Interface","USB Interface",
                                                    "PortName","BaudRate","Remote IP","Remote Port"};

                string[] m_def_cn = new string[] { "通讯参数配置",
                                                    "串口通讯(RS232/RS485)", "网络通讯(TCP/WIFI)", "USB通讯(虚拟键盘/编程模式)",
                                                    "串口选择","波特率","远程IP地址","远程IP端口"};

                string[] m_def_tw = new string[] { "通訊參數設定",
                                                    "串口通訊(RS232/RS485)", "網絡通訊(TCP/WIFI)", "USB通訊(虛擬鍵盤/編程模式)",
                                                    "串行埠選擇", "串行傳輸速率", "遠程IP地址", "遠程IP埠" };

                string[] MainValue = IniSettings.LoadLanguage("sioconfig", m_def_en, m_def_cn, m_def_tw);
                int index = 0;

                this.Text = IniSettings.GetLanguageString("Select the device connection mode", "设备连接方式选择");
                grbComm.Text = MainValue[index++];

                rdbSerial.Text = MainValue[index++];
                rdbNet.Text = MainValue[index++];
                rdbUsb.Text = MainValue[index++];
                grbSerial.Text = rdbSerial.Text;
                grbNet.Text = rdbNet.Text;
                grbUsb.Text = rdbUsb.Text;

                lblPortName.Text = MainValue[index++];
                lblBaudRate.Text = MainValue[index++];

                lblRemoteIP.Text = MainValue[index++];
                lblRemotePort.Text = MainValue[index++];
            }
            catch { }
        }

        private void frmConnect_Load(object sender, EventArgs e)
        {
            LoadCommLanguage();
            LoadCommunication();
        }

        private void SioBase_StatusEvent(object sender, StatusEventArgs e)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    pnlConnect.Enabled = true;
                    Application.DoEvents();

                    switch (e.Status)
                    {
                        case (int)StatusType.CONNECT_OK:
                            try
                            {
                                int intVer = Convert.ToInt32(e.Msg);
                                SystemPub.SioVersion = "V" + intVer / 256 + "." + intVer % 256 / 16 + intVer % 16;
                                rtxtRes.AppendText("USB Version> :"+ SystemPub.SioVersion + "\r\n");
                            }
                            catch { }
                            rtxtRes.AppendText("CONNECTED OK> " + e.Msg + "(" + SystemPub.SioBase.ToString() + ")\r\n");
                            this.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                Application.DoEvents();
                                Thread.Sleep(200);
                                Application.DoEvents();
                                Thread.Sleep(200);
                                Application.DoEvents();
                                Thread.Sleep(200);
                                Application.DoEvents();
                                this.Close();
                            }));
                            break;
                        case (int)StatusType.CONNECT_FAIL:
                            rtxtRes.AppendText("ERROR> " + e.Msg + "(" + SystemPub.SioBase.ToString() + ")\r\n");
                            break;
                        case (int)StatusType.DISCONNECT_OK:
                            rtxtRes.AppendText("DISCONNECT OK> " + e.Msg + "(" + SystemPub.SioBase.ToString() + ")\r\n");
                            break;
                        case (int)StatusType.DISCONNECT_EXCEPT:
                            rtxtRes.AppendText("ERROR> " + e.Msg + "(" + SystemPub.SioBase.ToString() + ")\r\n");
                            break;
                        default:
                            break;
                    }
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void frmConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SystemPub.SioBase.onStatus -= SioBase_StatusEvent;
            }
            catch { }
        }

        int commType = 0;


        private void rdbCheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked) return;
            if (mChangeCommFlag) return;
            if (rdbSerial.Checked)
            {
                LoadCommType(0);
            }
            else if (rdbNet.Checked)
            {
                LoadCommType(1);
            }
            else if (rdbUsb.Checked)
            {
                LoadCommType(2);
            }
        }

        /// <summary>
        /// 重复加载限制标志
        /// </summary>
        private bool mChangeCommFlag = false;

        private void LoadCommType(int type)
        {
            IniSettings.Communication = (int)type;
            commType = type;
            mChangeCommFlag = true;

            switch (commType)
            {
                case 0:
                    rdbSerial.Checked = true;
                    rdbSerial.ForeColor = Color.Blue;
                    break;
                case 1:
                    rdbNet.Checked = true;
                    rdbNet.ForeColor = Color.Blue;
                    break;
                case 2:
                    rdbUsb.Checked = true;
                    rdbUsb.ForeColor = Color.Blue;
                    LoadUsbDevice();
                    break;
                default:
                    break;
            }
            grbSerial.Visible = rdbSerial.Checked;
            grbNet.Visible = rdbNet.Checked;
            grbUsb.Visible = rdbUsb.Checked;
            mChangeCommFlag = false;
        }


        private void LoadUsbDevice()
        {
            List<DictionaryEntry> deviceList = new List<DictionaryEntry>();
            if (SioUsb.GetHidDeviceList(ref deviceList))
            {
                cmbUsbDeviceList.DataSource = deviceList;
                cmbUsbDeviceList.DisplayMember = "key";
                cmbUsbDeviceList.ValueMember = "value";

                cmbUsbDeviceList.SelectedIndex = 0;

                rtxtRes.AppendText(IniSettings.GetLanguageString("USB device arrived!", "发现USB设备!\r\n"));
            }
        }

        private void InitSio(int commType)
        {
            IniSettings.PortName = cmbPortName.Text;
            IniSettings.BaudRate = Convert.ToInt32(cmbBaudRate.Text);
            IniSettings.IP = txtRemoteIP.Text;
            IniSettings.IPPort = Convert.ToInt32(txtRemotePort.Text);

            try
            {
                IniSettings.USBDevPath = ((DictionaryEntry)cmbUsbDeviceList.SelectedItem).Value.ToString();

                string usbkey = ((DictionaryEntry)cmbUsbDeviceList.SelectedItem).Key.ToString();
                if (usbkey.Contains("HID_110"))
                    IniSettings.USBType = 1;
                else if (usbkey.Contains("HID_300"))
                    IniSettings.USBType = 2;
                else
                    IniSettings.USBType = 0;
            }
            catch { }


            if (SystemPub.IsConnectedSio)
            {
                {
                    SystemPub.DisConnectSio();
                }
            }

            switch (commType)
            {
                case 0:
                    SystemPub.SioBase = new SioCom();
                    break;
                case 1:
                    SystemPub.SioBase = new SioNet();
                    break;
                case 2:
                    SystemPub.SioBase = new SioUsb();
                    break;
                default:
                    break;
            }

            SystemPub.SioBase.onStatus += SioBase_StatusEvent;
        }

        private void btnConnected_Click(object sender, EventArgs e)
        {
            InitSio(commType);

            switch (commType)
            {
                case 0:
                    //SystemPub.SioBase = new SioCom();
                    break;
                case 1:
                    IPStatus ipsta = Ping(IniSettings.HostName);
                    if (ipsta != IPStatus.Success)
                    {
                        rtxtRes.AppendText("PING:" + txtRemoteIP.Text + " " + ipsta.ToString());
                        return;
                    }
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            SystemPub.SioBase.Connect(IniSettings.HostName, IniSettings.HostPort);
        }
        /// <summary>
        /// 检测网络 PING url
        /// </summary>
        /// <param name="hostNameOrAddress">一个 System.String，它标识作为 ICMP 回送消息目标的计算机。为此参数指定的值可以是主机名，也可以是以字符串形式表示的 IP 地址。</param>
        /// <returns></returns>
        public static IPStatus Ping(string hostNameOrAddress)
        {
            IPStatus sta = IPStatus.TimedOut;
            Ping p = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            string data = "abc";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 200;
            try
            {
                PingReply reply = p.Send(hostNameOrAddress, timeout, buffer, options);
                sta = reply.Status;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (p != null)
                {
                    // 2.0 下ping 的一个bug，需要显示转型后释放
                    IDisposable disposable = p;
                    disposable.Dispose();

                    p.Dispose();
                }
            }
            return sta;
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            rtxtRes.AppendText("PING:" + txtRemoteIP.Text + " " + Ping(txtRemoteIP.Text).ToString());
        }
    }
}
