using ReaderLib;
using ReaderLib.Initializer;
using ReaderLib.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ReaderSDK.Components
{
    public partial class TagsDataGridView : UserControl
    {
        public delegate void CellClickEventHandler(string epc);
        public event CellClickEventHandler CellClick;

        TagsDataTable tagsDataTable = new TagsDataTable();
        DateTime dtStart = DateTime.Now;

        DateTime nReadShowTime = DateTime.Now;
        int nReadShowRate = 50;

        int nAllTags = 0;
        int nInventoryTags = 0;

        int nInventoryTagsPages = 1;
        int nInventoryTagsPageCurrent = 1;
        const int InventoryTagsPagesMax = 30;

        int nMaxAnt = 0;

        #region ---Base Config---
        public void ChangeLanguage()
        {
            colID.HeaderText = IniSettings.GetLanguageString("ID", "序号");
            colAddress.HeaderText = IniSettings.GetLanguageString("ADDRESS", "地址");
            colDecCard.HeaderText = IniSettings.GetLanguageString("HEX / DEC / WG", "16进制 / 10进制/ 标准韦根");
            colHexByteSum.HeaderText = IniSettings.GetLanguageString("LENGTH", "长度");
            colCount.HeaderText = IniSettings.GetLanguageString("COUNT", "重复");

            chkDivAnt.Text = IniSettings.GetLanguageString("Div Ant", "区分天线");
            chkDivAddr.Text = IniSettings.GetLanguageString("Div Address", "区分地址");
            chkDivAlarm.Text = IniSettings.GetLanguageString("Div Alarm", "区分报警");
            lblSumSymbol.Text = IniSettings.GetLanguageString("Sum Tags", "标签总数");
            tsmiClearScreen.Text = IniSettings.GetLanguageString("Clear All Items", "清空显示数据");
            btnClear.Text = IniSettings.GetLanguageString("Clear", "清空");
            btnLeft.Text = IniSettings.GetLanguageString("<<", "上一页");
            btnRight.Text = IniSettings.GetLanguageString("<<", "下一页");

            cmbStartPoint.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                cmbStartPoint.Items.Add(IniSettings.GetLanguageString("Byte offset-", "卡片偏移-") + i);
            }
            try
            {
                cmbStartPoint.SelectedIndex = IniSettings.WritePosition;
            }
            catch { cmbStartPoint.SelectedIndex = 0; }

            cmbShowLen.Items.Clear();
            for (int i = 2; i < 9; i++)
            {
                cmbShowLen.Items.Add(IniSettings.GetLanguageString("Show Len ", "显示 ") + (i) + IniSettings.GetLanguageString(" Bytes", " 字节"));
            }
            try
            {
                cmbShowLen.SelectedIndex = IniSettings.WriteMode - 2;
            }
            catch { cmbShowLen.SelectedIndex = 1; }
        }
        #endregion

        public TagsDataGridView()
        {
            InitializeComponent();
        }

        private void TagsDataGridView_Load(object sender, EventArgs e)
        {
            ChangeLanguage();
        }

        public void Clear()
        {
            colAnt.HeaderText = "ANT1";
            colCrc.Visible = false;
            colData.Visible = false;
            nInventoryTags = 0;
            nAllTags = 0;
            nInventoryTagsPages = 1;
            nInventoryTagsPageCurrent = 1;
            nMaxAnt = 0;
            dtStart = DateTime.Now;
            nReadShowTime = DateTime.Now;

            lblSum.Text = "";
            tagsDataTable.Clear();
            dgvShow.Rows.Clear();
        }

        public string GetEPCString(int index)
        {
            if (tagsDataTable.Table.Rows.Count > index)
                return tagsDataTable.Table.Rows[index]["EPC"].ToString();
            return "";
        }

        private void SetAntHeadText(int ant)
        {
            if (ant > nMaxAnt)
            {
                nMaxAnt = ant;
                if (nMaxAnt > 0)
                {
                    colAnt.HeaderText = "ANT1";
                    for (int m = 1; m < nMaxAnt; m++)
                    {
                        colAnt.HeaderText += "/ANT" + (m + 1);
                    }
                }
                else
                {
                    colAnt.HeaderText = "ANT";
                }
            }
        }

        private void SetHeadText(TagInfo info)
        {
            SetAntHeadText(info.Antenna);
            if (!colPc.Visible)
            {
                if (info.PCString != "/" && info.PCString != "") colPc.Visible = true;
            }
            if (!colCrc.Visible)
            {
                if (info.CRCString != "/" && info.CRCString != "") colCrc.Visible = true;
            }
            if (!colData.Visible)
            {
                if (info.DataString != "/" && info.DataString != "") colData.Visible = true;
            }
        }

        public void Add(TagInfo info)
        {
            AddItem(info);
        }
        public void Add(List<TagInfo> infoArray)
        {
            for(int i = 0;i<infoArray.Count;i++)
            AddItem(infoArray[i]);
        }

        public void AddItem(TagInfo info)
        {
            if (this.InvokeRequired)
            {
                TagsDataTableInsertTagUnsafe InvokeRefreshInsert = new TagsDataTableInsertTagUnsafe(AddItem);
                this.Invoke(InvokeRefreshInsert, new object[] { info });
            }
            else
            {
                SetHeadText(info);
                nAllTags++;
                tagsDataTable.DataTagTableInsert(info);

                nInventoryTags = tagsDataTable.Table.Rows.Count; //标签总数
                lblSum.Text = nInventoryTags.ToString();
                nInventoryTagsPages = (nInventoryTags / InventoryTagsPagesMax) + (((nInventoryTags % InventoryTagsPagesMax) > 0) ? 1 : 0);
                if (nInventoryTagsPages == 0) nInventoryTagsPages = 1;
                InvetoryTagsInit();
                UpdateItems(true);
            }
        }
        public void UpdateItems(bool flag)
        {
            if (this.InvokeRequired)
            {
                TagsDataTableUpdateUnsafe InvokeRefreshInsert = new TagsDataTableUpdateUnsafe(UpdateItems);
                this.Invoke(InvokeRefreshInsert, new object[] { flag });
            }
            else
            {
                if (flag)
                {
                    //形成列表
                    int nEpcCountFS = dgvShow.Rows.Count;
                    if (nEpcCountFS >= InventoryTagsPagesMax) return;
                    nEpcCountFS += (nInventoryTagsPageCurrent - 1) * InventoryTagsPagesMax;
                    int nEpcLengthFS = tagsDataTable.Table.Rows.Count;
                    if (nEpcCountFS < nEpcLengthFS)
                    {
                        DataRow rowfs = tagsDataTable.Table.Rows[nEpcLengthFS - 1];

                        int index = dgvShow.Rows.Add();
                        DataGridViewRow dataGridViewRow = dgvShow.Rows[index];
                        string strCard = GetShortCard(rowfs[3].ToString());
                        dataGridViewRow.Tag = nEpcCountFS + 1;
                        dataGridViewRow.SetValues(nEpcCountFS + 1,
                                rowfs[0].ToString(),
                                strCard,
                                rowfs[1].ToString(),
                                rowfs[2].ToString(),
                                rowfs[3].ToString(),
                                rowfs[4].ToString(),
                                rowfs[5].ToString(),
                                rowfs[6].ToString(),
                                GetAntString(rowfs),
                                rowfs[7].ToString());
                    }
                }
                else
                {
                    dgvShow.Rows.Clear();
                    int intstart = (nInventoryTagsPageCurrent - 1) * InventoryTagsPagesMax;
                    int intlen = nInventoryTagsPages > nInventoryTagsPageCurrent ? (intstart + InventoryTagsPagesMax) : nInventoryTags;
                    for (int i = intstart; i < intlen; i++)
                    {
                        DataRow rowfs = tagsDataTable.Table.Rows[i];

                        int index = dgvShow.Rows.Add();
                        DataGridViewRow dataGridViewRow = dgvShow.Rows[index];
                        string strCard = GetShortCard(rowfs[3].ToString());
                        dataGridViewRow.Tag = i + 1;
                        dataGridViewRow.SetValues(i + 1,
                                rowfs[0].ToString(),
                                strCard,
                                rowfs[1].ToString(),
                                rowfs[2].ToString(),
                                rowfs[3].ToString(),
                                rowfs[4].ToString(),
                                rowfs[5].ToString(),
                                rowfs[6].ToString(),
                                GetAntString(rowfs),
                                rowfs[7].ToString());
                    }
                }
            }
        } 

        private string GetAntString(DataRow row)
        {
            if (chkDivAnt.Checked)
            {
                string strAnt = row["ANT00"].ToString();
                if (nMaxAnt > 0)
                {
                    strAnt = row[9].ToString().PadLeft(4, ' ');

                    for (int m = 1; m < nMaxAnt; m++)
                    {
                        strAnt += " / " + row[9 + m].ToString().PadLeft(4,' ');
                    }
                }
                return strAnt;
            }
            else
            {
                return row["ANT00"].ToString();
            }
        }

        public void ShowItems(bool flag)
        {
            if (this.InvokeRequired)
            {
                TagsDataTableShowUnsafe InvokeRefreshUpdate = new TagsDataTableShowUnsafe(ShowItems);
                this.Invoke(InvokeRefreshUpdate, new object[] { flag });
            }
            else
            {
                //更新列表中读取的次数
                if (nAllTags % nReadShowRate == 0 || DateTime.Now.Subtract(nReadShowTime).TotalSeconds > 2 || flag)
                {
                    foreach (DataGridViewRow dgvr in dgvShow.Rows)
                    {
                        try
                        {
                            DataRow rowfs = tagsDataTable.Table.Rows[Convert.ToInt32(dgvr.Tag) - 1];

                            dgvr.Cells["colAnt"].Value = GetAntString(rowfs);
                            dgvr.Cells["colCount"].Value = rowfs["COUNT"].ToString();
                            dgvr.Cells["colRssi"].Value = rowfs["RSSI"].ToString();
                        }
                        catch { }
                    }
                    nReadShowTime = DateTime.Now;
                }
            }
        }

        public DataGridView View
        {
            get { return dgvShow; }
        }

        private void chkDivAnt_CheckedChanged(object sender, EventArgs e)
        {
            colAnt.Visible = chkDivAnt.Checked;
        }

        private void chkDivAddr_CheckedChanged(object sender, EventArgs e)
        {
            colAddress.Visible = chkDivAddr.Checked;
        }
        
        private void cmbShowLen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IniSettings.WriteMode = cmbShowLen.SelectedIndex + 2;
            for (int i = 0; i < dgvShow.Rows.Count; i++)
            {
                dgvShow["colDecCard", i].Value = GetShortCard(Convert.ToString(dgvShow["colEpc", i].Value));
            }
        }

        private void cmbStartPoint_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IniSettings.WritePosition = cmbStartPoint.SelectedIndex;
            for (int i = 0; i < dgvShow.Rows.Count; i++)
            {
                dgvShow["colDecCard", i].Value = GetShortCard(Convert.ToString(dgvShow["colEpc", i].Value));
            }
        }
        
        private string GetShortCard(string datastring)
        {
            int index = cmbStartPoint.SelectedIndex < 0 ? 0 : cmbStartPoint.SelectedIndex;
            int lensize = cmbShowLen.SelectedIndex + 2;

            if (index + lensize > datastring.Length / 2) return "error param";

            ulong lngCard = ConvertData.HexStringToDecLong(datastring, index, lensize);

            ulong wgCard = ConvertData.HexStringToWGLong(datastring, index, lensize);

            string strCard = ConvertData.DecLongToHexString(lngCard, lensize);

            return "[" + strCard + "] [" + lngCard + "] [" + wgCard.ToString() + "]";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void tsmiCopyEPC_Click(object sender, EventArgs e)
        {
            string strmsg = dgvShow.SelectedRows[0].Cells["colEpc"].Value.ToString();
            Clipboard.SetText(strmsg);
        }

        private void tsmiClearScreen_Click(object sender, EventArgs e)
        {
            Clear();
        }

        #region ---卡号获取超时变色显示---
        private int intActiveCount = 0;
        private const int ACTIVEMARK = 10;
        /// <summary>
        /// 卡号获取超时过程
        /// </summary>
        private void ActiveTime()
        {
            intActiveCount++;
            if (intActiveCount > ACTIVEMARK)
            {
                intActiveCount = 0;
                for (int i = 0; i < dgvShow.Rows.Count; i++)
                {
                    if (this.dgvShow.Rows[i].DefaultCellStyle.BackColor == Color.OldLace)
                    {
                        this.dgvShow.Rows[i].DefaultCellStyle.BackColor = Color.Lavender;
                    }
                    else if (this.dgvShow.Rows[i].DefaultCellStyle.BackColor == Color.Lavender)
                    {
                        this.dgvShow.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }
        #endregion

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            ActiveTime();
            ShowItems(false);
        }
        /// <summary>
        /// 获取点击DataGridView行号
        /// </summary>
        /// <param name="dataGridView">DataGridView</param>
        /// <param name="mouseLocation_Y">鼠标点击位置</param>
        /// <returns></returns>
        public static int GetRowIndexAt(DataGridView dataGridView, int mouseLocation_Y)
        {
            if (dataGridView.FirstDisplayedScrollingRowIndex < 0)
            {
                return -1;
            }
            if (dataGridView.ColumnHeadersVisible == true && mouseLocation_Y <= dataGridView.ColumnHeadersHeight)
            {
                return -1;
            }
            int index = dataGridView.FirstDisplayedScrollingRowIndex;
            int displayedCount = dataGridView.DisplayedRowCount(true);
            for (int k = 1; k <= displayedCount;)
            {
                if (dataGridView.Rows[index].Visible == true)
                {
                    Rectangle rect = dataGridView.GetRowDisplayRectangle(index, true);  // 取该区域的显示部分区域   
                    if (rect.Top <= mouseLocation_Y && mouseLocation_Y < rect.Bottom)
                    {
                        return index;
                    }
                    k++;
                }
                index++;
            }
            return -1;
        }
            private void dgvShow_MouseClick(object sender, MouseEventArgs e)
        {
            int index = GetRowIndexAt(dgvShow, e.Y);
            if (index == -1)
            {
                dgvShow.CurrentCell = null;
                return;
            }
            CellClick?.Invoke(dgvShow.SelectedRows[0].Cells["colEpc"].Value.ToString());
        }

        private void InvetoryTagsInit()
        {
            if (nInventoryTagsPageCurrent > nInventoryTagsPages)
            {
                nInventoryTagsPageCurrent = 1;
                InventoryTagsChange(false);
                return;
            }
            else
            {
                btnLeft.Enabled = (nInventoryTagsPageCurrent > 1);
                btnRight.Enabled = (nInventoryTagsPageCurrent < nInventoryTagsPages);
                lblCurrentPage.Text = nInventoryTagsPageCurrent + " / " + nInventoryTagsPages;
            }
            pnlPageControl.Visible = nInventoryTagsPages > 1;
        }
        private void InventoryTagsChange(bool isplus)
        {
            if(isplus)
            {
                if (nInventoryTagsPageCurrent < nInventoryTagsPages) nInventoryTagsPageCurrent++;
            }
            else
            {
                if (nInventoryTagsPageCurrent > 1) nInventoryTagsPageCurrent--;
            }

            InvetoryTagsInit();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            InventoryTagsChange(false);
            Application.DoEvents();
            UpdateItems(false);
            Application.DoEvents();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            InventoryTagsChange(true);
            Application.DoEvents();
            UpdateItems(false);
            Application.DoEvents();
        }

    }
}
