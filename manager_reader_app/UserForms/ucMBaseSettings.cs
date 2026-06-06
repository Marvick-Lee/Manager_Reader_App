using ADRcpLib;
using ADUtilsLib.Initializer;
using ADUtilsLib.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ReaderSDK
{
    public partial class ucMBaseSettings : UserControl
    {
        public ucMBaseSettings()
        {
            InitializeComponent();
        }
        
        public void ChangeLanguage()
        {
            int intSelectItem = 0;

            #region ---Basic Para---
            try
            {
                string[] m_def_en = new string[] {
                                                    "Basic Parameters Control",
                                                    "Byte Offset","Out Interval","Pulse Width","Pulse Period",

                                                    "Work Mode","Command","Active","Passive","Read Type","Read Interval","Read Delay",
                                                    "Output Mode","Same ID interval","Buzzer",
                                                    "Access Pwd","Memory Block","Start(Word)","Length(Word)",
                                                    "Get","Set","Default"
                };

                string[] m_def_cn = new string[] { "基本参数设置",
                                                    "数据偏移", "输出周期",  "脉冲宽度","脉冲周期",
                                                    "工作模式", "应答方式", "主动方式", "被动方式",  "读卡类型", "读卡间隔","读卡延时",
                                                    "通讯模式","相同ID输出间隔", "嗡鸣器",
                                                    "访问密码","其他区域卡号", "起始地址", "数据长度",
                                                    "获取","设置","默认值"
                };
                string[] m_def_tw = new string[] { "基本參數配置",
                                                    "數據偏移",  "輸出周期","脈衝寬度", "脈衝周期",
                                                    "工作模式", "應答方式", "主動方式", "被動方式", "讀卡類型", "讀卡間隔", "讀卡延時",
                                                   "通訊模式", "相同ID輸出間隔", "蜂嗚器",
                                                    "訪問密碼", "其他區域卡號", "起始地址", "數據長度",
                                                    "獲取", "設置", "默認值"
                };

                string[] MainValue = IniSettings.LoadLanguage(@"mm/basesettings", m_def_en, m_def_cn, m_def_tw);
                int index = 0;

                grbBase.Text = MainValue[index++];
                #region ---Wiegand---
                lblByteOffset.Text = MainValue[index++];
                lblOutInterval.Text = MainValue[index++];
                lblPulseWidth.Text = MainValue[index++];
                lblPulsePeriod.Text = MainValue[index++];
                #endregion

                lblWorkMode.Text = MainValue[index++];
                intSelectItem = cmbWorkMode.SelectedIndex;
                cmbWorkMode.Items.Clear();
                cmbWorkMode.Items.Add(MainValue[index++]);
                cmbWorkMode.Items.Add(MainValue[index++]);
                cmbWorkMode.Items.Add(MainValue[index++]);
                cmbWorkMode.SelectedIndex = intSelectItem;

                lblReadType.Text = MainValue[index++];
                lblReadInterval.Text = MainValue[index++];
                lblReadDelay.Text = MainValue[index++];

                lblOutputMode.Text = MainValue[index++];
                lblSameIDinterval.Text = MainValue[index++];
                lblBeep.Text = MainValue[index++];

                lblAccessPwd.Text = MainValue[index++];
                lblMemory.Text = MainValue[index++];
                lblStartAddress.Text = MainValue[index++];
                lblLength.Text = MainValue[index++];

                #region ---Button---
                btnGetBase.Text = MainValue[index++];
                btnSetBase.Text = MainValue[index++];
                btnDefBase.Text = MainValue[index++];
                #endregion

            }
            catch { }
            #endregion
            #region ---OutType---
            try
            {
                string[] m_def_en = new string[] {
                                                    "OutPut Parameters Control",
                                                    "Out Mode","Disabled","Virtual Keyboard(USB)","Custom data format output",
                                                    "Out Type","Decimal","Hex","Wiegand","ASCII","BAILING","CUSTOM",
                                                    "Show Length","Out Start","Out Byte",

                                                    "Out Head Len","Out Head Data","Out End Len",
                                                    "Out End Data","Is Key Enter","Quick Set",
                                                    "Get","Set","Default",
                                                    "01--Decimal Num,first 3 bytes(WG26)",
                                                    "02--Decimal Num,first 4 bytes(WG34)",
                                                    "03--Decimal Num,end 3 bytes(WG26)",
                                                    "04--Decimal Num,end 4 bytes(WG34)",
                                                    "05--WG Num,first 3 bytes(WG26)",
                                                    "06--WG Num,first 4 bytes(WG34)",
                                                    "07--WG Num,end 3 bytes(WG26)",
                                                    "08--WG Num,end 4 bytes(WG34)",
                                                    "09--Hex Num,first 3 bytes(WG26)",
                                                    "10--Hex Num,first 4 bytes(WG34)",
                                                    "11--Hex Num,end 3 bytes(WG26)",
                                                    "12--Hex Num,end 4 bytes(WG26)",
                                                    "13--Hex Num,first 12 bytes(EPC)",
                                                    "14--Hex Num,end 12 bytes(TID),(need set Read Type)",
                                                    "15--Hex Num,first 24 bytes(EPC+TID),(need set Read Type)"

                };

                string[] m_def_cn = new string[] { "输出参数设置","输出模式","停用","虚拟键盘/仿真键盘输出(USB)","自定义数据格式输出",
                                                    "输出类型","10进制","16进制","标准韦根","ASCII码","BAILING","CUSTOM",
                                                    "显示长度", "输出起始", "输出长度",
                                                    "前面附加", "前面附加数据", "尾部附加", "尾部附加数据", "是否带回车", "快速参数选择",
                                                    "获取","设置","默认值" ,
                                                    "01--10进制卡号,前3个字节8位ASCII码(WG26)",
                                                    "02--10进制卡号,前4个字节10位ASCII码(WG34)",
                                                    "03--10进制卡号,后3个字节8位ASCII码(WG26)",
                                                    "04--10进制卡号,后4个字节10位ASCII码(WG34)",
                                                    "05--标准WG卡号,前3个字节8位ASCII码(WG26)",
                                                    "06--标准WG卡号,前4个字节10位ASCII码(WG34)",
                                                    "07--标准WG卡号,后3个字节8位ASCII码(WG26)",
                                                    "08--标准WG卡号,后4个字节10位ASCII码(WG34)",
                                                    "09--16进制卡号,前3个字节6位ASCII码(WG26)",
                                                    "10--16进制卡号,前4个字节8位ASCII码(WG34)",
                                                    "11--16进制卡号,后3个字节6位ASCII码(WG26)",
                                                    "12--16进制卡号,后3个字节8位ASCII码(WG26)",
                                                    "13--EPC卡号,前12字节24位ASCII码",
                                                    "14--TID卡号,后12字节24位ASCII码(需要设置读卡类型)",
                                                    "15--EPC卡号+TID卡号,前24字节48位ASCII码(需要设置读卡类型)"
                };
                string[] m_def_tw = new string[] { "輸出參數配置","輸出模式","停用","虛擬鍵盤/仿真鍵盤輸出(USB)","自定義數據格式輸出",
                                                    "輸出類型", "10進制","16進制","標準韋根","ASCII碼","BAILING","CUSTOM",
                                                    "顯示長度", "輸出起始位置", "輸出長度",
                                                    "頭部附加", "頭部附加數據", "尾部附加", "尾部附加數據", "是否帶回車", "快速參數選擇",
                                                    "獲取", "設置", "默認值",
                                                    "01--10進制卡號,前3個字節8位ASCII碼(WG26)",
                                                    "02--10進制卡號,前4個字節10位ASCII碼(WG34)",
                                                    "03--10進制卡號,後3個字節8位ASCII碼(WG26)",
                                                    "04--10進制卡號,後4個字節10位ASCII碼(WG34)",
                                                    "05--標準WG卡號,前3個字節8位ASCII碼(WG26)",
                                                    "06--標準WG卡號,前4個字節10位ASCII碼(WG34)",
                                                    "07--標準WG卡號,後3個字節8位ASCII碼(WG26)",
                                                    "08--標準WG卡號,後4個字節10位ASCII碼(WG34)",
                                                    "09--16進制卡號,前3個字節6位ASCII碼(WG26)",
                                                    "10--16進制卡號,前4個字節8位ASCII碼(WG34)",
                                                    "11--16進制卡號,後3個字節6位ASCII碼(WG26)",
                                                    "12--16進制卡號,後3個字節8位ASCII碼(WG26)",
                                                    "13--EPC卡號,前12字節24位ASCII碼",
                                                    "14--TID卡號,後12字節24位ASCII碼(需要設置讀卡類型)",
                                                    "15--EPC卡號+TID卡號,前24字節48位ASCII碼(需要設置讀卡類型)"
                };

                string[] MainValue = IniSettings.LoadLanguage(@"mm/routputsettings", m_def_en, m_def_cn, m_def_tw);
                int index = 0;

                grbOutType.Text = MainValue[index++];

                lblOutEnabled.Text = MainValue[index++];
                intSelectItem = cmbOutEnabled.SelectedIndex;
                cmbOutEnabled.Items.Clear();
                for (int i = 0; i < 3; i++)
                {
                    cmbOutEnabled.Items.Add(MainValue[index++]);
                }
                cmbOutEnabled.SelectedIndex = intSelectItem;

                lblOutMode.Text = MainValue[index++];
                intSelectItem = cmbOutType.SelectedIndex;
                cmbOutType.Items.Clear();
                cmbOutType.Items.Add(MainValue[index++]);
                cmbOutType.Items.Add(MainValue[index++]);
                cmbOutType.Items.Add(MainValue[index++]);
                cmbOutType.Items.Add(MainValue[index++]);
                cmbOutType.Items.Add(MainValue[index++]);
                cmbOutType.Items.Add(MainValue[index++]);
                cmbOutType.SelectedIndex = intSelectItem;

                lblOutLen.Text = MainValue[index++];
                lblOutStart.Text = MainValue[index++];
                lblOutWord.Text = MainValue[index++];

                lblOutHeadLen.Text = MainValue[index++];
                lblOutHeadData.Text = MainValue[index++];
                lblOutEndLen.Text = MainValue[index++];
                lblOutEndData.Text = MainValue[index++];
                lblCheck.Text = MainValue[index++];
                lblOutQuick.Text = MainValue[index++];

                btnGetOutPut.Text = MainValue[index++];
                btnSetOutPut.Text = MainValue[index++];
                btnDefOutPut.Text = MainValue[index++];

                intSelectItem = cmbOutQuick.SelectedIndex;
                cmbOutQuick.Items.Clear();
                for (int i = 0; i < 15; i++)
                {
                    cmbOutQuick.Items.Add(MainValue[index++]);
                }
                cmbOutQuick.SelectedIndex = intSelectItem;
            }
            catch { }


            #endregion

            #region ---Ant---

            try
            {
                string[] m_def_en = new string[] {  "Ant Control","Choose Ant:", "Ant List:", "Current Use Ant:",
                                                    "Get","Set","Def","Clear All","Select All"
                };

                string[] m_def_cn = new string[] { "天线控制","天线选择:",  "天线列表:","当前使用天线:",
                                                    "获取","设置","默认值","清除所有","选择所有"
                };
                string[] m_def_tw = new string[] { "天線控制","天線選擇:",  "天線列表:","當前使用天線:",
                                                    "獲取", "設置", "默認值", "清除所有", "選擇所有"
                };

                string[] MainValue = IniSettings.LoadLanguage(@"mm/antsettings", m_def_en, m_def_cn, m_def_tw);
                int index = 0;

                grbAnt.Text = MainValue[index++];
                lblAntChoose2.Text = lblAntChoose.Text = MainValue[index++];
                lblSelectAnt.Text = MainValue[index++];
                lblAntCurrent.Text = MainValue[index++];

                btnGetAnt.Text = MainValue[index++];
                btnSetAnt.Text = MainValue[index++];
                btnDefAnt.Text = MainValue[index++];
                btnClearAll.Text = MainValue[index++];
                btnSelectAll.Text = MainValue[index++];

                if (SystemPub.RcpBase != null)
                {
                    switch (SystemPub.RcpBase.Type)
                    {
                        case "S":
                            grbAnt.Visible = true;
                            pnlAntS4.Visible = true;
                            pnlAntM8.Visible = false;
                            grbOutType.Visible = false;
                            break;
                    }
                }
            }
            catch { }
            #endregion
            grbOutType.Visible = IniSettings.Communication == 2;
        }

        public void ParseRsp(ProtocolPacket Data)
        {
            int intCtmIndex = 0;
            switch (Data.Code)
            {
                case RcpBase.RCP_MM_PARA:
                    intCtmIndex = 0;
                    if (Data.Length > 0)
                    {
                        cmbOutMode.SelectedIndex = Data.Payload[intCtmIndex++];

                        cmbWorkMode.SelectedIndex = Data.Payload[intCtmIndex++];
                        cmbReadType.SelectedIndex = Data.Payload[intCtmIndex++] - 1;
                        nudReadInterval.Value = Data.Payload[intCtmIndex++];
                        nudReadDelay.Value = Data.Payload[intCtmIndex++];

                        nudByteOffset.Value = Data.Payload[intCtmIndex++];
                        nudOutInterval.Value = Data.Payload[intCtmIndex++];
                        nudPulseWidth.Value = Data.Payload[intCtmIndex++];
                        nudPulsePeriod.Value = Data.Payload[intCtmIndex++];

                        nudSameid.Value = ConvertData.ByteArrayToDecLong(Data.Payload, intCtmIndex, 2);
                        intCtmIndex += 2;

                        cmbBeep.SelectedIndex = Data.Payload[intCtmIndex++];

                        ftxtAccessPwd.Text = ConvertData.ByteArrayToHexString(Data.Payload, intCtmIndex, 4);
                        intCtmIndex += 4;

                        cmbMBlock.SelectedIndex = Data.Payload[intCtmIndex++];
                        nudMStart.Value = Data.Payload[intCtmIndex++];
                        nudMLength.Value = Data.Payload[intCtmIndex++];

                        intCtmIndex += 7;
                    }
                    break;
                case RcpBase.RCP_MM_OUTCARD:
                    intCtmIndex = 0;
                    if (Data.Length > 0)
                    {
                        try
                        {
                            cmbOutEnabled.SelectedIndex = Data.Payload[intCtmIndex++];
                            cmbOutType.SelectedIndex = Data.Payload[intCtmIndex++];
                            nudOutLen.Value = Data.Payload[intCtmIndex++];
                            cmbCheck.SelectedIndex = Data.Payload[intCtmIndex++];

                            nudOutStart.Value = Data.Payload[intCtmIndex++];
                            cmbOutWord.Text = Data.Payload[intCtmIndex++].ToString();

                            if (Data.Length > 24)
                            {
                                nudOutHeadLen.Value = Data.Payload[intCtmIndex++];
                                txtOutHeadData.Text = ConvertData.ByteArrayToHexString(Data.Payload, intCtmIndex, (byte)(nudOutHeadLen.Value));
                                intCtmIndex += 20;
                                nudOutEndLen.Value = Data.Payload[intCtmIndex++];
                                txtOutEndData.Text = ConvertData.ByteArrayToHexString(Data.Payload, intCtmIndex, (byte)(nudOutEndLen.Value));
                                intCtmIndex += 20;
                            }
                            else
                            {
                                nudOutHeadLen.Value = Data.Payload[intCtmIndex++];
                                txtOutHeadData.Text = ConvertData.ByteArrayToHexString(Data.Payload, intCtmIndex, (byte)(nudOutHeadLen.Value));
                                intCtmIndex += 8;
                                nudOutEndLen.Value = Data.Payload[intCtmIndex++];
                                txtOutEndData.Text = ConvertData.ByteArrayToHexString(Data.Payload, intCtmIndex, (byte)(nudOutEndLen.Value));
                                intCtmIndex += 8;
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    break;
                case RcpBase.RCP_MM_ANT:

                    if (Data.Length >= 3)
                    {
                        ftxtAntChoose.Text = ConvertData.ByteArrayToHexString(Data.Payload, 1, 2);
                        int intChooseAnt = Data.Payload[1] << 8 | Data.Payload[2];

                        txtAntCurrent.Text = "Ant_" + Data.Payload[0];

                        chkAnt01.Checked = ((intChooseAnt & (0x0001 << 0)) > 0);
                        chkAnt01.ForeColor = chkAnt01.Checked ? SystemColors.Highlight : System.Drawing.Color.Black;

                        chkAnt02.Checked = ((intChooseAnt & (0x0001 << 1)) > 0);
                        chkAnt02.ForeColor = chkAnt02.Checked ? SystemColors.Highlight : System.Drawing.Color.Black;

                        chkAnt03.Checked = ((intChooseAnt & (0x0001 << 2)) > 0);
                        chkAnt03.ForeColor = chkAnt03.Checked ? SystemColors.Highlight : System.Drawing.Color.Black;

                        chkAnt04.Checked = ((intChooseAnt & (0x0001 << 3)) > 0);
                        chkAnt04.ForeColor = chkAnt04.Checked ? SystemColors.Highlight : System.Drawing.Color.Black;

                        chkAnt05.Checked = ((intChooseAnt & (0x0001 << 4)) > 0);
                        chkAnt05.ForeColor = chkAnt05.Checked ? SystemColors.Highlight : System.Drawing.Color.Black;

                        chkAnt06.Checked = ((intChooseAnt & (0x0001 << 5)) > 0);
                        chkAnt06.ForeColor = chkAnt06.Checked ? SystemColors.Highlight : System.Drawing.Color.Black;

                        chkAnt07.Checked = ((intChooseAnt & (0x0001 << 6)) > 0);
                        chkAnt07.ForeColor = chkAnt07.Checked ? SystemColors.Highlight : System.Drawing.Color.Black;

                        chkAnt08.Checked = ((intChooseAnt & (0x0001 << 7)) > 0);
                        chkAnt08.ForeColor = chkAnt08.Checked ? SystemColors.Highlight : System.Drawing.Color.Black;
                    }
                    break;
            }

        }
        

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_SECRET_C_DT, RcpBase.RCP_MSG_CMD, new byte[] { 0, 0, 0, 0 }));
        }

        private void cmbReadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAdditionalData.Visible = cmbReadType.SelectedIndex == 2;
        }

        private void btnGetBase_Click(object sender, EventArgs e)
        {
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_PARA, RcpBase.RCP_MSG_GET));
        }

        private void btnSetBase_Click(object sender, EventArgs e)
        {
            List<byte> param = new List<byte>();

            param.Add( (byte)cmbOutMode.SelectedIndex);

            param.Add( (byte)cmbWorkMode.SelectedIndex);
            param.Add( (byte)(cmbReadType.SelectedIndex + 1));
            param.Add( (byte)nudReadInterval.Value);
            param.Add( (byte)nudReadDelay.Value);

            param.Add( (byte)nudByteOffset.Value);
            param.Add( (byte)nudOutInterval.Value);
            param.Add( (byte)nudPulseWidth.Value);
            param.Add( (byte)nudPulsePeriod.Value);

            param.Add( (byte)(nudSameid.Value / 256));
            param.Add( (byte)(nudSameid.Value % 256));
            param.Add( (byte)cmbBeep.SelectedIndex);

            byte[] access = ConvertData.HexStringToByteArray(ftxtAccessPwd.Text);
            param.Add( access[0]);
            param.Add( access[1]);
            param.Add( access[2]);
            param.Add( access[3]);
            param.Add( (byte)cmbMBlock.SelectedIndex);
            param.Add( (byte)nudMStart.Value);
            param.Add( (byte)nudMLength.Value);

            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_PARA, RcpBase.RCP_MSG_SET, param.ToArray()));

        }

        private void btnDefBase_Click(object sender, EventArgs e)
        {
            cmbOutMode.SelectedIndex = 0;
            cmbWorkMode.SelectedIndex = 1;
            cmbReadType.SelectedIndex = 1;

            nudReadInterval.Value = 10;
            nudReadDelay.Value = 1;

            if (SystemPub.RcpBase.Type == "D")
            {
                cmbOutMode.SelectedIndex = 1;
                nudReadInterval.Value = 20;
            }

            nudByteOffset.Value = 2;
            nudOutInterval.Value = 30;
            nudPulseWidth.Value = 10;
            nudPulsePeriod.Value = 15;

            nudSameid.Value = 1;
            cmbBeep.SelectedIndex = 1;

            ftxtAccessPwd.Text = "00000000";
            cmbMBlock.SelectedIndex = 2;
            nudMStart.Value = 0;
            nudMLength.Value = 6;
        }

        private void btnGetOutPut_Click(object sender, EventArgs e)
        {
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_OUTCARD, RcpBase.RCP_MSG_GET));
        }

        private void btnSetOutPut_Click(object sender, EventArgs e)
        {
            List<byte> param = new List<byte>();
            param.Add((byte)(cmbOutEnabled.SelectedIndex));

            param.Add((byte)(cmbOutType.SelectedIndex));
            param.Add((byte)(nudOutLen.Value));
            param.Add((byte)(cmbCheck.SelectedIndex));

            param.Add((byte)(nudOutStart.Value));
            param.Add((byte)(Convert.ToByte(cmbOutWord.Text.Trim())));

            param.Add((byte)(nudOutHeadLen.Value));
            param.AddRange(ConvertData.HexStringToByteArray(txtOutHeadData.Text, 0, (int)nudOutHeadLen.Value));
            for (int i = (byte)(nudOutHeadLen.Value); i < 20; i++)
                param.Add(0);

            param.Add((byte)(nudOutEndLen.Value));
            param.AddRange(ConvertData.HexStringToByteArray(txtOutEndData.Text, 0, (int)nudOutEndLen.Value));
            for (int i = (byte)(nudOutEndLen.Value); i < 20; i++)
                param.Add(0);

            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_OUTCARD, RcpBase.RCP_MSG_SET, param.ToArray()));
        }

        private void btnDefOutPut_Click(object sender, EventArgs e)
        {
            cmbOutType.SelectedIndex = 0;
            nudOutLen.Value = 8;
            nudOutStart.Value = 2;
            cmbOutWord.SelectedIndex = 1;
            nudOutHeadLen.Value = 0;
            nudOutEndLen.Value = 0;
            txtOutHeadData.Text = "";
            txtOutEndData.Text = "";
            cmbCheck.SelectedIndex = 1;
            cmbOutEnabled.SelectedIndex = 0;

            cmbOutQuick.SelectedIndex = 0;
            if (SystemPub.RcpBase.Type == "D")
            {
                cmbCheck.SelectedIndex = 1;
                cmbOutEnabled.SelectedIndex = 1;
            }
        }

        private void cmbOutEnabled_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlOutType.Visible = cmbOutEnabled.SelectedIndex > 0;
            btnQuick.Visible = cmbOutEnabled.SelectedIndex == 1;
        }

        private void cmbOutQuick_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCheck.SelectedIndex = 1;

            cmbReadType.SelectedIndex = 1;
            switch (cmbOutQuick.SelectedIndex)
            {
                case 0:
                    cmbOutType.SelectedIndex = 0;
                    nudOutLen.Value = 8;
                    nudOutStart.Value = 2;
                    cmbOutWord.SelectedIndex = 1;
                    break;
                case 1:
                    cmbOutType.SelectedIndex = 0;
                    nudOutLen.Value = 10;
                    nudOutStart.Value = 2;
                    cmbOutWord.SelectedIndex = 2;
                    break;
                case 2:
                    cmbOutType.SelectedIndex = 0;
                    nudOutLen.Value = 8;
                    nudOutStart.Value = 11;
                    cmbOutWord.SelectedIndex = 1;
                    break;
                case 3:
                    cmbOutType.SelectedIndex = 0;
                    nudOutLen.Value = 10;
                    nudOutStart.Value = 10;
                    cmbOutWord.SelectedIndex = 2;
                    break;
                case 4:
                    cmbOutType.SelectedIndex = 2;
                    nudOutLen.Value = 8;
                    nudOutStart.Value = 2;
                    cmbOutWord.SelectedIndex = 1;
                    break;
                case 5:
                    cmbOutType.SelectedIndex = 2;
                    nudOutLen.Value = 10;
                    nudOutStart.Value = 2;
                    cmbOutWord.SelectedIndex = 2;
                    break;
                case 6:
                    cmbOutType.SelectedIndex = 2;
                    nudOutLen.Value = 8;
                    nudOutStart.Value = 11;
                    cmbOutWord.SelectedIndex = 1;
                    break;
                case 7:
                    cmbOutType.SelectedIndex = 2;
                    nudOutLen.Value = 10;
                    nudOutStart.Value = 10;
                    cmbOutWord.SelectedIndex = 2;
                    break;
                case 8:
                    cmbOutType.SelectedIndex = 1;
                    nudOutLen.Value = 6;
                    nudOutStart.Value = 2;
                    cmbOutWord.SelectedIndex = 1;
                    break;
                case 9:
                    cmbOutType.SelectedIndex = 1;
                    nudOutLen.Value = 8;
                    nudOutStart.Value = 2;
                    cmbOutWord.SelectedIndex = 2;
                    break;
                case 10:
                    cmbOutType.SelectedIndex = 1;
                    nudOutLen.Value = 6;
                    nudOutStart.Value = 11;
                    cmbOutWord.SelectedIndex = 1;
                    break;
                case 11:
                    cmbOutType.SelectedIndex = 1;
                    nudOutLen.Value = 8;
                    nudOutStart.Value = 10;
                    cmbOutWord.SelectedIndex = 2;
                    break;
                case 12:
                    cmbOutType.SelectedIndex = 1;
                    nudOutLen.Value = 24;
                    nudOutStart.Value = 2;
                    cmbOutWord.SelectedIndex = 10;
                    break;
                case 13:
                    cmbOutType.SelectedIndex = 1;
                    nudOutLen.Value = 24;
                    nudOutStart.Value = 14;
                    cmbOutWord.SelectedIndex = 10;
                    cmbReadType.SelectedIndex = 2;

                    cmbReadType.SelectedIndex = 2;
                    cmbMBlock.SelectedIndex = 2;
                    nudMStart.Value = 0;
                    nudMLength.Value = 6;
                    break;
                case 14:
                    cmbOutType.SelectedIndex = 1;
                    nudOutLen.Value = 48;
                    nudOutStart.Value = 2;
                    cmbOutWord.SelectedIndex = 22;

                    cmbReadType.SelectedIndex = 2;
                    cmbMBlock.SelectedIndex = 2;
                    nudMStart.Value = 0;
                    nudMLength.Value = 6;
                    break;
            }
        }

        private void btnCDCDisabled_Click(object sender, EventArgs e)
        {
            List<byte> param = new List<byte>();
            param.Add(0);
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, 0xBD, RcpBase.RCP_MSG_SET, param.ToArray()));
        }

        private void btnCDCEnabled_Click(object sender, EventArgs e)
        {
            List<byte> param = new List<byte>();
            param.Add(1);
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, 0xBD, RcpBase.RCP_MSG_SET, param.ToArray()));
        }

        private void btnModeSPP_Click(object sender, EventArgs e)
        {
            List<byte> param = new List<byte>();
            param.Add(0);
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, 0xBE, RcpBase.RCP_MSG_SET, param.ToArray()));
        }

        private void btnModeHID_Click(object sender, EventArgs e)
        {
            List<byte> param = new List<byte>();
            param.Add(1);
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, 0xBE, RcpBase.RCP_MSG_SET, param.ToArray()));
        }

        private void chkAnt_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if (cb.Tag != null)
            {
                cb.ForeColor = System.Drawing.Color.Black;
                int index = Convert.ToInt32(cb.Tag) + 1;
                if (cb.Checked)
                {
                    cb.ForeColor = SystemColors.Highlight;
                    if (!lblSelectionList.Text.Contains(index.ToString()))
                    {
                        lblSelectionList.Text += index.ToString() + ",";
                    }
                }
                else
                {
                    if (lblSelectionList.Text.Contains(index.ToString()))
                    {
                        lblSelectionList.Text = lblSelectionList.Text.Replace(index.ToString() + ",", "");
                    }
                }
            }

            int intChooseAnt = 0;

            if (chkAnt01.Checked) intChooseAnt |= (0x0001 << (Convert.ToInt32(chkAnt01.Tag)));
            if (chkAnt02.Checked) intChooseAnt |= (0x0001 << (Convert.ToInt32(chkAnt02.Tag)));
            if (chkAnt03.Checked) intChooseAnt |= (0x0001 << (Convert.ToInt32(chkAnt03.Tag)));
            if (chkAnt04.Checked) intChooseAnt |= (0x0001 << (Convert.ToInt32(chkAnt04.Tag)));
            if (chkAnt05.Checked) intChooseAnt |= (0x0001 << (Convert.ToInt32(chkAnt05.Tag)));
            if (chkAnt06.Checked) intChooseAnt |= (0x0001 << (Convert.ToInt32(chkAnt06.Tag)));
            if (chkAnt07.Checked) intChooseAnt |= (0x0001 << (Convert.ToInt32(chkAnt07.Tag)));
            if (chkAnt08.Checked) intChooseAnt |= (0x0001 << (Convert.ToInt32(chkAnt08.Tag)));

            if (intChooseAnt == 0) intChooseAnt = 1;
            string strChooseAnt = ConvertData.DecLongToHexString((ulong)intChooseAnt, 2);
            ftxtAntChoose.Text = strChooseAnt;
            if (SystemPub.AntCurrentListString != lblSelectionList.Text) SystemPub.AntCurrentListString = lblSelectionList.Text;
        }

        private void btnSetAnt_Click(object sender, EventArgs e)
        {
            byte current = 0xff;
            byte[] ant = ConvertData.HexStringToByteArray(ftxtAntChoose.Text);

            List<byte> param = new List<byte>();
            param.Add(current);
            param.AddRange(ant);

            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_ANT, RcpBase.RCP_MSG_SET, param.ToArray()));
        }

        private void btnGetAnt_Click(object sender, EventArgs e)
        {
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_ANT, RcpBase.RCP_MSG_GET));
        }

        private void btnDefAnt_Click(object sender, EventArgs e)
        {
            btnClearAll_Click(btnClearAll, e);
            btnSelectAll_Click(btnSelectAll, e);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            chkAnt01.Checked = chkAnt02.Checked = chkAnt03.Checked = chkAnt04.Checked = false;
            chkAnt05.Checked = chkAnt06.Checked = chkAnt07.Checked = chkAnt08.Checked = false;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            btnClearAll_Click(btnClearAll, e);

            if (pnlAntS4.Visible)
            {
                chkAnt04.Checked = chkAnt03.Checked = chkAnt02.Checked = chkAnt01.Checked = true;
            }
            if (pnlAntM8.Visible)
            {
                chkAnt08.Checked = chkAnt07.Checked = chkAnt06.Checked = chkAnt05.Checked = true;
            }
        }
    }
}
