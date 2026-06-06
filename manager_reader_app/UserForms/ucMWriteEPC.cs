using ADRcpLib;
using ADUtilsLib.Initializer;
using ADUtilsLib.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ReaderSDK
{
    public partial class ucMWriteEPC : UserControl
    {
        private bool isSelectItems = false;
        private string strSelectedItem = "";

        public ucMWriteEPC()
        {
            InitializeComponent();
            cmbMem.SelectedIndex = 1;
            cmbLockType.SelectedIndex = 2;
            cmbLockAction.SelectedIndex = 0;
        }

        public void ChangeLanguage()
        {

            string[] m_def_en = new string[] {  "Read Tags",
                                                    "Single Read Tag",
                                                    "Access Pwd","Choice Item:","IsSelect tag to edit",
                                                    "READ/WRITE","LOCK","KILL","QUICK WRITE TAG",
                                                    "Target Memory","Start Address(Word Ptr)","Length(Word Count)","Data(Hex)","Data(Ascii)",
                                                    "Read tag menory","Write data to tag","Write data to tag",

                                                    "Mask Mem","Action(pwd/perma)",
                                                    "Lock",

                                                    "Kill Password(Hex)",
                                                    "Kill / Recom"};

            string[] m_def_cn = new string[] {  "读取标签数",
                                                    "读取标签",
                                                    "访问密码","选中项:","是否选中标签操作",
                                                    "读写操作","锁定操作","销毁操作","快速写标签",
                                                     "标签分区","起始地址(Word Ptr)","长度(Word Count)","数据(Hex)","数据(Ascii)",
                                                     "读标签数据","写数据到标签","写数据到标签",

                                                    "锁定块","操作类型",
                                                    "锁定/解锁标签",

                                                    "销毁密码(Hex)",
                                                    "销毁标签"};

            string[] m_def_tw = new string[] {  "讀取標籤數",
                                                    "讀取標籤",
                                                    "訪問密碼","選中項:","是否選中標籤操作",
                                                    "讀/寫操作","鎖定操作","銷毀操作","快速寫標籤",
                                                    "訪問密碼(Hex)","標籤分區","起始地址(Word Ptr)","長度(Word Count)","數據(Hex)","數據(Ascii)",
                                                    "讀標籤數據","寫數據到標籤","寫數據到標籤",

                                                    "鎖定分區","操作類型",
                                                    "鎖定/解鎖標籤",

                                                    "銷毀密碼(Hex)",
                                                    "銷毀標籤"};

            string[] MainValue = IniSettings.LoadLanguage(@"mm/writetepc", m_def_en, m_def_cn, m_def_tw);
            int index = 0;

            index++;
            btnScanTag.Text = MainValue[index++];
            lblAccessPwd.Text = MainValue[index++];
            lblSelectedItem.Text = MainValue[index++];

            chkIsSelectTag.Text = MainValue[index++];

            tabRW.Text = MainValue[index++];
            tabLock.Text = MainValue[index++];
            tabKill.Text = MainValue[index++];
            index++;//tabEpcQuick.Text = MainValue[index++];

            lblMem.Text = MainValue[index++];
            lblStart.Text = MainValue[index++];
            lblLength.Text = MainValue[index++];
            lblDataHex.Text = MainValue[index++];
            lblDataAscii.Text = MainValue[index++];

            btnRead.Text = MainValue[index++];
            btnWriteHex.Text = MainValue[index++];
            btnWriteAscii.Text = MainValue[index++];

            lblLockType.Text = MainValue[index++];
            lblLockAction.Text = MainValue[index++];
            btnLock.Text = MainValue[index++];

            lblKillPwd.Text = MainValue[index++];
            btnKill.Text = MainValue[index++];

            cdgvShow.ChangeLanguage();
        }

        private string GetRssi(byte rssi)
        {
            int rssidBm = (sbyte)rssi; // rssidBm is negative && in bytes
            rssidBm -= Convert.ToInt32("-20", 10);
            rssidBm -= Convert.ToInt32("3", 10);
            return rssidBm.ToString();
        }

        public void ParseRsp(ProtocolPacket Data)
        {
            switch (Data.Code)
            {
                case RcpBase.RCP_MM_READ_C_UII:
                    string strepc = "";
                    if (Data.Type == 2 || Data.Type == 5)
                    {
                        int pcepclen = RcpBase.GetCodeLen(Data.Payload[1]);
                        int datalen = Data.Length - 2;//去掉天线号去掉rssi
                        TagInfo cp = new TagInfo
                        {
                            TagType = TagType.TYPE_6C,
                            Length = datalen,//去掉天线号去掉RSSI
                            Antenna = Data.Payload[0],
                            PCData = ConvertData.GetData(Data.Payload, 1, 2),
                            EPCData = ConvertData.GetData(Data.Payload, 3, pcepclen - 2),
                            Rssi = GetRssi(Data.Payload[Data.Length - 1]) + "dBm"
                        };
                        if ((datalen - pcepclen) > 0) cp.DataBytes = ConvertData.GetData(Data.Payload, 1 + pcepclen, datalen - pcepclen);
                        cdgvShow.Add(cp);
                        strepc = cp.EPCString;
                    }

                    break;
                case RcpBase.RCP_MM_READ_C_DT:
                    if (Data.Type == 0)
                    {
                        int pcepclen = RcpBase.GetCodeLen(Data.Payload[1]);
                        int datalen = Data.Length - pcepclen - 1;//去掉天线号去掉PC+EPc
                        TagInfo cp = new TagInfo
                        {
                            TagType = TagType.TYPE_6C,
                            Length = datalen,
                            Antenna = Data.Payload[0],
                            PCData = ConvertData.GetData(Data.Payload, 1, 2),
                            EPCData = ConvertData.GetData(Data.Payload, 3, pcepclen - 2),
                            DataBytes = ConvertData.GetData(Data.Payload, 1 + pcepclen, datalen)
                        };
                        cdgvShow.Add(cp);
                        txtDataHex.Text = cp.DataString;
                        txtDataAscii.Text = Encoding.GetEncoding("gb2312").GetString(cp.DataBytes, 0, cp.DataBytes.Length);

                     
                        Application.DoEvents();

                    }
                    break;
                case RcpBase.RCP_MM_WRITE_C_DT:
                    if (Data.Type == 0)
                    {
                        int pcepclen = RcpBase.GetCodeLen(Data.Payload[1]);
                        int datalen = Data.Length - pcepclen - 1;//去掉天线号去掉PC+EPc
                        TagInfo cp = new TagInfo
                        {
                            TagType = TagType.TYPE_6C,
                            Length = datalen,
                            Antenna = Data.Payload[0],
                            PCData = ConvertData.GetData(Data.Payload, 1, 2),
                            EPCData = ConvertData.GetData(Data.Payload, 3, pcepclen - 2)
                        };
                        cdgvShow.Add(cp);
                    }
                    break;
                case RcpBase.RCP_MM_GET_ACCESS_EPC_MATCH:
                    break;
                case RcpBase.RCP_MM_SET_ACCESS_EPC_MATCH:

                    if (Data.Type == 0)
                    {
                        if (!isSelectItems)
                        {
                            isSelectItems = true;
                            strSelectedItem = txtSelectedItem.Text;
                            btnSelectTarget.Text = "Clear";
                            txtSelectedItem.ReadOnly = true;
                        }
                        else
                        {
                            isSelectItems = false;
                            strSelectedItem = "";
                            txtSelectedItem.Text = "";
                            txtSelectedItem.ReadOnly = false;
                            btnSelectTarget.Text = "Select";
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnScanTag_Click(object sender, EventArgs e)
        {
            cdgvShow.Clear();
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_READ_C_UII, RcpBase.RCP_MSG_CMD));
        }
        
        private void cdgvShow_CellClick(string epc)
        {
            if (!isSelectItems)
                txtSelectedItem.Text = epc.Length > 24 ? epc.Substring(0, 24) : epc;

        }

        private void btnSelectTarget_Click(object sender, EventArgs e)
        {
            if (isSelectItems)
            {
                List<byte> param = new List<byte>();
                param.Add(0);
                param.Add(0);
                SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_SET_ACCESS_EPC_MATCH, RcpBase.RCP_MSG_CMD, param.ToArray()));
            }
            else
            {
                if (txtSelectedItem.Text != strSelectedItem)
                {
                    byte mode = (byte)2;
                    byte epclen = (byte)(txtSelectedItem.Text.Length / 2);
                    byte[] epc = ConvertData.HexStringToByteArray(txtSelectedItem.Text);

                    List<byte> param = new List<byte>();
                    param.Add(mode);
                    param.Add(epclen);
                    param.AddRange(epc);
                    SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_SET_ACCESS_EPC_MATCH, RcpBase.RCP_MSG_CMD, param.ToArray()));
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            cdgvShow.Clear();
            byte[] ap = ConvertData.HexStringToByteArray(ftxtAccessPwd.Text);
            byte mb = (byte)cmbMem.SelectedIndex;
            byte sa = (byte)Convert.ToInt32(txtStart.Text);
            byte dl = (byte)Convert.ToInt32(txtLength.Text);

            List<byte> param = new List<byte>();
            param.AddRange(ap);
            param.Add(mb);
            param.Add(sa);
            param.Add(dl);

            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_READ_C_DT, RcpBase.RCP_MSG_CMD, param.ToArray()));
        }

        private void btnWriteHex_Click(object sender, EventArgs e)
        {
            cdgvShow.Clear();
            byte[] ap = ConvertData.HexStringToByteArray(ftxtAccessPwd.Text);
            byte mb = (byte)cmbMem.SelectedIndex;
            byte sa = (byte)Convert.ToInt32(txtStart.Text);
            byte dl = (byte)Convert.ToInt32(txtLength.Text);
            byte[] dt = ConvertData.HexStringToByteArray(txtDataHex.Text);
            dl = (byte)(dt.Length / 2);
            txtLength.Text = dl.ToString();

            List<byte> param = new List<byte>();
            param.AddRange(ap);
            param.Add(mb);
            param.Add(sa);
            param.Add(dl);
            param.AddRange(dt);

            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_WRITE_C_DT, RcpBase.RCP_MSG_CMD, param.ToArray()));
        }

        private void btnWriteAscii_Click(object sender, EventArgs e)
        {
            cdgvShow.Clear();
            byte[] ap = ConvertData.HexStringToByteArray(ftxtAccessPwd.Text);
            byte mb = (byte)cmbMem.SelectedIndex;
            byte sa = (byte)Convert.ToInt32(txtStart.Text);
            byte dl = (byte)Convert.ToInt32(txtLength.Text);
            byte[] dt = Encoding.GetEncoding("gb2312").GetBytes(txtDataAscii.Text.Trim());
            dl = (byte)(dt.Length / 2);
            txtLength.Text = dl.ToString();

            List<byte> param = new List<byte>();
            param.AddRange(ap);
            param.Add(mb);
            param.Add(sa);
            param.Add(dl);
            param.AddRange(dt);

            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_WRITE_C_DT, RcpBase.RCP_MSG_CMD, param.ToArray()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">0~4</param>
        /// <param name="action">0~3</param>
        /// <returns></returns>
        private byte[] GetLockData(int type, int action)
        {
            byte[] lockdata;

            int intlockkey = 0;
            int lockindex = (type) * 2;
            //加载ACTION
            intlockkey = (action << lockindex);

            //加载mask
            int lockmask = 0;
            switch (action)
            {
                case 0:
                    lockmask = 2;
                    break;
                case 1:
                    lockmask = 1;
                    break;
                case 2:
                    lockmask = 2;
                    break;
                case 3:
                    lockmask = 3;
                    break;
            }
            intlockkey += (lockmask << (lockindex + 10));


            lockdata = new byte[3];
            lockdata[0] = (byte)(intlockkey >> 16);
            lockdata[1] = (byte)(intlockkey >> 8);
            lockdata[2] = (byte)(intlockkey);
            return lockdata;
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            byte[] lockdata = GetLockData(cmbLockType.SelectedIndex, cmbLockAction.SelectedIndex);

            byte[] ap = ConvertData.HexStringToByteArray(ftxtAccessPwd.Text);

            List<byte> param = new List<byte>();
            param.AddRange(ap);
            param.AddRange(lockdata);

            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_LOCK_C, RcpBase.RCP_MSG_CMD, param.ToArray()));
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            byte[] ap = ConvertData.HexStringToByteArray(ftxtKillPwd.Text);

            List<byte> param = new List<byte>();
            param.AddRange(ap);

            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_KILL_RECOM_C, RcpBase.RCP_MSG_CMD, param.ToArray()));
        }

        private void chkIsSelectTag_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkIsSelectTag.Checked)
            {
                isSelectItems = true;
                btnSelectTarget_Click(btnSelectTarget, e);
            }
        }
    }
}
