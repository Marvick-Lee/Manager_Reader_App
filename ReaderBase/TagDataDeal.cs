
using ReaderLib.Initializer;
using ReaderLib.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReaderSDK.Components
{
    public partial class TagDataDeal : UserControl
    {
        private bool mIsAdd = false;
        private int mIsAddStep = 1;
        private bool mIsAddHex = false;
        private string mCardMask = "000000000000000000000000";
        private bool mIsChange = false;

        public TagDataDeal()
        {
            InitializeComponent();
        }

        public void ChangeLanguage()
        {
            lblPCLen.Text = IniSettings.GetLanguageString("PC", "编码长度");
            lblAddStep.Text = IniSettings.GetLanguageString("Add Step", "递增步长");
            chkAdd.Text = IniSettings.GetLanguageString("Auto Add", "是否递增");
            chkAddHex.Text = IniSettings.GetLanguageString("Dec Add ", "是否按10进制递增");

            lblCard.Text = IniSettings.GetLanguageString("Write Num(Byte)", "待写入卡号");
            lblHead.Text = IniSettings.GetLanguageString("Fix Head Num(Byte)", "前部固定数据(Byte)");
            lblEnd.Text = IniSettings.GetLanguageString("Fix End Num(Byte)", "尾部固定数据(Byte)");
            lblCardAll.Text = IniSettings.GetLanguageString("Write All Num", "待写入完整卡号");
            btnPlus.Text = IniSettings.GetLanguageString("Plus 1", "加一");
            btnMinus.Text = IniSettings.GetLanguageString("Minus 1", "减一");
            btnLeft.Text = IniSettings.GetLanguageString("Move Left", "左移");
            btnRight.Text = IniSettings.GetLanguageString("Move Right", "右移");
        }

        public void PassOnKeys(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                btnLeft_Click(btnLeft, e);
            }
            else if (e.KeyCode == Keys.Right)
            {
                btnRight_Click(btnRight, e);
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Add)
            {
                btnPlus_Click(btnPlus, e);
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Subtract)
            {
                btnMinus_Click(btnMinus, e);
            }
        }

        private void TagDataDeal_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                try
                {
                    IniSettings.LoadReader();
                    ChangeLanguage();
                    LoadInit();
                }
                catch { }
            }));
        }

        private void LoadInit()
        {            
            this.rtxtCardAll.SelectionAlignment = HorizontalAlignment.Center;
            AllTagLen = IniSettings.TagLen;
            TagLen = IniSettings.WriteMode;
            TagPosition = IniSettings.WritePosition;
            mIsAdd = IniSettings.WriteAutoAdd;
            mIsAddStep = IniSettings.WriteAutoAddStep;
            mIsAddHex = IniSettings.WriteAutoAddHex;
            TagString = IniSettings.TagNumber;
            mCardMask = IniSettings.TagMask;

            ChangePara();
        }

        private void ChangeValue()
        {
            if (TagLen > 6) TagLen = 6;
            if (TagLen > AllTagLen) TagLen = AllTagLen;
            if (TagLen < 2) TagLen = 3;
            if (TagPosition + TagLen > AllTagLen) TagPosition = AllTagLen - TagLen;

            if (TagLen > TagString.Length / 2)
                TagString = TagString.PadLeft(TagLen * 2, '0');
            else
                TagString = TagString.Substring(TagString.Length - TagLen * 2, TagLen * 2);

            if (AllTagLen > (mCardMask.Length / 2))
                mCardMask = mCardMask.PadLeft(AllTagLen * 2, '0');
            else
                mCardMask = mCardMask.Substring(mCardMask.Length - AllTagLen * 2, AllTagLen * 2);

            AllTagString = mCardMask.Remove(TagPosition * 2, TagLen * 2);
            AllTagString = AllTagString.Insert(TagPosition * 2, TagString);
        }

        private void ChangePara()
        {
            mIsChange = true;
            ChangeValue();
            string strHexMaskTemp = "HH";
            string strHexMask = "";
            //PC编码
            nudPCLen.Value = AllTagLen / 2;
            txtPCLen.Text = ConvertData.DecLongToHexString((ulong)((int)(nudPCLen.Value) << 3), 1);

            //待写入卡号
            nudCard.Maximum = AllTagLen > 6 ? 6 : AllTagLen;
            nudCard.Value = TagLen;

            nudAddStep.Value = mIsAddStep;
            chkAdd.Checked = mIsAdd;
            chkAddHex.Checked = mIsAddHex;

            nudHeadLen.Maximum = AllTagLen - TagLen;
            nudHeadLen.Value = TagPosition;

            nudEndLen.Maximum = AllTagLen - TagLen;
            nudEndLen.Value = AllTagLen - TagPosition - TagLen;

            //待写入前部固定数据
            if (TagPosition > 0)
            {
                ftxtHeadData.Enabled = true;
                strHexMask = strHexMaskTemp;
                for (int i = 0; i < TagPosition - 1; i++) strHexMask += "-" + strHexMaskTemp;
                ftxtHeadData.InputMask = strHexMask;
                ftxtHeadData.Value = mCardMask.Substring(0, TagPosition * 2);
            }
            else
            {
                ftxtHeadData.InputMask = "";
                ftxtHeadData.Text = "";
                ftxtHeadData.Enabled = false;
            }

            //待写入尾部固定数据
            if (AllTagLen - TagPosition - TagLen > 0)
            {
                ftxtEndData.Enabled = true;
                strHexMask = strHexMaskTemp;
                for (int i = 0; i < AllTagLen - TagPosition - TagLen - 1; i++) strHexMask += "-" + strHexMaskTemp;
                ftxtEndData.InputMask = strHexMask;
                ftxtEndData.Value = mCardMask.Substring(mCardMask.Length - (AllTagLen - TagPosition - TagLen) * 2, (AllTagLen - TagPosition - TagLen) * 2);
            }
            else
            {
                ftxtEndData.InputMask = "";
                ftxtEndData.Text = "";
                ftxtEndData.Enabled = false;
            }

            //待写入卡号
            if (mIsAddHex)
                strHexMaskTemp = "00";
            strHexMask = strHexMaskTemp;
            for (int i = 0; i < TagLen - 1; i++) strHexMask += "-" + strHexMaskTemp;
            ftxtCard.InputMask = strHexMask;
            ftxtCard.Value = TagString;

            //待写入完整卡号
            int headlen = TagPosition*2;
            int cardlen = TagLen*2;
            int endlen = (AllTagLen - TagPosition - TagLen)*2;
            string headstring = mCardMask.Substring(0, headlen);
            string cardstring = TagString;
            string endstring = mCardMask.Substring(headlen + cardlen, endlen);
            if (headlen > 0)
            {
                headstring = ConvertData.StringInsertChar(headstring, 2, '-') + "-";
            }
            if (cardlen > 0)
            {
                cardstring = ConvertData.StringInsertChar(cardstring, 2, '-');
            }

            if (endlen > 0)
            {
                endstring = "-" + ConvertData.StringInsertChar(endstring, 2, '-');
            }
            rtxtCardAll.Clear();
            rtxtCardAll.SelectionStart = rtxtCardAll.Text.Length;
            rtxtCardAll.SelectionLength = 0;
            rtxtCardAll.SelectionColor = Color.Black;
            rtxtCardAll.AppendText(headstring);

            rtxtCardAll.SelectionStart = rtxtCardAll.Text.Length;
            rtxtCardAll.SelectionLength = 0;
            rtxtCardAll.SelectionColor = Color.Red;
            rtxtCardAll.AppendText(cardstring);

            rtxtCardAll.SelectionStart = rtxtCardAll.Text.Length;
            rtxtCardAll.SelectionLength = 0;
            rtxtCardAll.SelectionColor = Color.Black;
            rtxtCardAll.AppendText(endstring);

            Application.DoEvents();

            //快速写卡处理
            try
            {
                GetEditData();
            }
            catch { }
            mIsChange = false;

        }

        /// <summary>
        /// 获取待写入数据及位置
        /// </summary>
        public string GetEditData()
        {
            int intLength = TagString.Length / 2;
            int intPosition = TagPosition;

            ShortAddress = intPosition / 2;
            ShortLen = intLength;

            ShortLen = ShortLen / 2 + ShortLen % 2;

            if (intPosition % 2 > 0 && intLength % 2 == 0)
            {
                ShortLen += 1;
            }
            ShortString = AllTagString.Substring((ShortAddress) * 4, ShortLen * 4);

            return ShortString;
        }

        /// <summary>
        /// 整个卡号16进制字符串
        /// </summary>
        public string AllTagString { get; private set; } = "000000000000000000000000";

        /// <summary>
        /// 整个卡号16进制字符串
        /// </summary>
        public byte[] AllTagBytes
        {
            get { return ConvertData.HexStringToByteArray(AllTagString); }
        }

        /// <summary>
        /// 整个卡号长度
        /// </summary>
        public int AllTagLen { get; private set; } = 12;

        /// <summary>
        /// 可变卡号16进制字符串
        /// </summary>
        public string TagString { get; private set; } = "00000000";

        /// <summary>
        /// 可变卡号16进制字符串
        /// </summary>
        public byte[] TagBytes
        {
            get { return ConvertData.HexStringToByteArray(TagString); }
        }
        /// <summary>
        /// 可变卡号长度
        /// </summary>
        public int TagLen { get; private set; } = 4;

        /// <summary>
        /// 可变卡号在整个卡号的位置
        /// </summary>
        public int TagPosition { get; private set; } = 0;

        /// <summary>
        /// 快写卡号
        /// </summary>
        public string ShortString { get; private set; } = "";
        /// <summary>
        /// 快写卡号地址(word)
        /// </summary>
        public int ShortAddress { get; private set; } = 0;
        /// <summary>
        /// 快写卡号长度(word)
        /// </summary>
        public int ShortLen { get; private set; } = 0;
       
        /// <summary>
        /// 设置掩码
        /// </summary>
        /// <param name="originalTag"></param>
        public void SetTagMask(string originalTag)
        {
            mCardMask = originalTag;
            ChangePara();
        }

        /// <summary>
        /// 自动添加卡号
        /// </summary>
        public void AutoAddCard()
        {
            if (chkAdd.Checked)
            {
                AddCard((int)nudAddStep.Value);
            }
        }
        /// <summary>
        /// 卡号自增
        /// </summary>
        /// <param name="count">次数</param>
        public void AddCard(int count=1)
        {
            for(int i = 0;i<count;i++)
            {
                if (mIsAddHex)
                {
                    TagString = ConvertData.PlusDecString(TagString);
                }
                else
                {
                    TagString = ConvertData.PlusHexString(TagString);
                }
            }
            ChangePara();
            IniSettings.TagNumber = TagString;
        }

        /// <summary>
        /// 卡号自减
        /// </summary>
        /// <param name="count">次数</param>
        public void SubtractCard(int count=1)
        {
            for (int i = 0; i < count; i++)
            {
                if (mIsAddHex)
                {
                    TagString = ConvertData.MinusDecString(TagString);
                }
                else
                {
                    TagString = ConvertData.MinusHexString(TagString);
                }
            }
            ChangePara();
            IniSettings.TagNumber = TagString;
        }

        private void nudPCLen_ValueChanged(object sender, EventArgs e)
        {
            if (mIsChange) return;
            AllTagLen = (int)nudPCLen.Value * 2;
            ChangePara();
            IniSettings.TagLen = AllTagLen;
        }

        private void nudAddStep_ValueChanged(object sender, EventArgs e)
        {
            if (mIsChange) return;
            mIsAddStep = (int)nudAddStep.Value;
            ChangePara();
            IniSettings.WriteAutoAddStep = mIsAddStep;
        }

        private void chkAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (mIsChange) return;
            mIsAdd = chkAdd.Checked;
            ChangePara();
            IniSettings.WriteAutoAdd = mIsAdd;
        }

        private void chkAddHex_CheckedChanged(object sender, EventArgs e)
        {
            if (mIsChange) return;
            mIsAddHex = chkAddHex.Checked;

            if (mIsAddHex)
            {
                TagString = ConvertData.HexStringToDecString(TagString, TagLen*2);
            }
            else
            {
                TagString = ConvertData.DecStringToHexString(TagString, TagLen);
            }

            ChangePara();
            IniSettings.WriteAutoAddHex = mIsAddHex;
        }

        private void nudCard_ValueChanged(object sender, EventArgs e)
        {
            if (mIsChange) return;
            TagLen = (int)nudCard.Value;
            ChangePara();
            IniSettings.WriteMode = TagLen;
        }

        private void nudHeadLen_ValueChanged(object sender, EventArgs e)
        {
            if (mIsChange) return;
            TagPosition = (int)nudHeadLen.Value;
            if (TagPosition + TagLen > AllTagLen) TagPosition = AllTagLen - TagLen;
            ChangePara();
            IniSettings.WritePosition = TagPosition;
        }

        private void nudEndLen_ValueChanged(object sender, EventArgs e)
        {
            if (mIsChange) return;
            TagPosition = AllTagLen - TagLen - (int)nudEndLen.Value;
            if (TagPosition < 0) TagPosition = 0;
            ChangePara();
            IniSettings.WritePosition = TagPosition;
        }

        private void ftdHeadData_TextChanged(object sender, EventArgs e)
        {
            if (mIsChange) return;
            mCardMask = ftxtHeadData.Value.ToUpper() + ftxtCard.Value.ToUpper() + ftxtEndData.Value.ToUpper();
            ChangePara();
            IniSettings.TagMask = mCardMask;
        }

        private void ftxtHeadEnd_TextChanged(object sender, EventArgs e)
        {
            if (mIsChange) return;
            mCardMask = ftxtHeadData.Value.ToUpper() + ftxtCard.Value.ToUpper() + ftxtEndData.Value.ToUpper();
            ChangePara();
            IniSettings.TagMask = mCardMask;
        }

        private void ftxtCard_TextChanged(object sender, EventArgs e)
        {
            if (mIsChange) return;
            TagString = ftxtCard.Value.ToUpper();
            ChangePara();
            IniSettings.TagNumber = TagString;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            AddCard(1);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            SubtractCard(1);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (TagPosition > 0) TagPosition--;
            ChangePara();
            IniSettings.WritePosition = TagPosition;

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            TagPosition++;
            if (TagPosition + TagLen > AllTagLen) TagPosition = AllTagLen - TagLen;
            ChangePara();
            IniSettings.WritePosition = TagPosition;
        }
    }
}
