using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ADRcpLib;
using ADUtilsLib.Initializer;
using ADUtilsLib.Utils;

namespace ReaderSDK
{
    public partial class ucMReadDemo : UserControl
    {
        private const int READ_STOP = 0;
        private const int READ_START = 1;
        private const int READ_SETANT = 2;
        private const int READ_SETANT_WAIT = 3;
        private const int READ_SETANTOK = 4;
        private const int READ_IDENTIFY = 5;
        private const int READ_IDENTIFY_WAIT = 6;
        private const int READ_IDENTIFYOK = 7;
        private const int READ_EXIT = 8;

        bool mIsStop = true;
        bool mIsStart = false;
        int mIsStatus = 0;
        int mLoopDelay = 0;
        int mLoopInterval = 0;

        DateTime nReadShowTime = DateTime.Now;
        int nReadShowRate = 50;

        int nInventoryCount = 0;
        int isStopAutoRead = 1; //Whether to take an active approach to work.
        int mCommandDelay = 2; //Whether it is an active working method
        int mCurrentAnt = 0xff; //Current Antenna

        #region --- Auto Cycle Variables ---
        // Biến bật/tắt chu trình tự động
        private bool mIsAutoCycleActive = false;

        // Enum để theo dõi trạng thái của chu trình tự động
        private enum AutoCycleState
        {
            Waiting,      // Đang chờ 10 phút
            Clearing,     // Đang xóa bảng
            StartingScan, // Chuẩn bị quét
            Scanning,     // Đang quét (trong 2 phút)
            Stopping,     // Đang dừng quét
            Exporting     // Đang xuất file
        }
        private AutoCycleState mCurrentCycleState = AutoCycleState.Waiting;

        // Biến theo dõi mốc thời gian (cho 10 phút chờ và 2 phút quét)
        private DateTime mCycleNextStartTime;
        private DateTime mScanStopTime;

        // Hằng số (dễ dàng thay đổi thời gian)
        private const int WAIT_MINUTES = 2;
        private const int SCAN_MINUTES = 1;
        #endregion

        public ucMReadDemo()
        {
            InitializeComponent();
        }

        public void ChangeLanguage()
        {
            try
            {
                string[] m_def_en = new string[] { "Start Reading Tags", "Stop", "Clear", "Save", "Single Read" };

                string[] m_def_vn = new string[] { "Khởi động đọc thẻ", "Dừng đọc thẻ", "Xóa", "Lưu", "Đọc thẻ một lần" };

                string[] m_def_jp = new string[] { "「カード読み取り開始」" , "「カード読み取り停止」" ,"「クリア」","「保存」","「単回読み取り」" };

                string[] MainValue = IniSettings.LoadLanguage(@"mm/readdemo", m_def_en, m_def_vn, m_def_jp);
                int index = 0;

                if (mIsStatus > 0)
                {
                    index++;
                    btnReadMultiple.Text = MainValue[index++];
                }
                else
                {
                    btnReadMultiple.Text = MainValue[index++];
                    index++;
                }
                btnClearScreen.Text = MainValue[index++];
                btnExport.Text = MainValue[index++];
                btnSingleRead.Text = MainValue[index++];
            }
            catch { }
        }

        private void SetAntHeadText(int maxAnt, ColumnHeader columnHeaderAnt)
        {
            if (maxAnt > 0)
            {
                columnHeaderAnt.Text = "ANT1";
                for (int m = 1; m < maxAnt; m++)
                {
                    columnHeaderAnt.Text += "/ANT" + (m + 1);
                }
                if (maxAnt <= 2)
                    columnHeaderAnt.Width = 50 * maxAnt;
                else
                    columnHeaderAnt.Width = 40 * maxAnt;
            }
            else
            {
                columnHeaderAnt.Text = "ANT";
                columnHeaderAnt.Width = 40 * 1;
            }
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
            int rtn = (Data.Type & 0x7f);
            switch (Data.Code)
            {
                case RcpBase.RCP_MM_PARA:
                    if (Data.Length > 0)
                    {
                        isStopAutoRead = Data.Payload[1];
                        btnReadMultiple.Enabled = btnSingleRead.Enabled = isStopAutoRead == 0;
                    }
                    break;
                case RcpBase.RCP_MM_ANT:

                    if (Data.Length >= 3)
                    {

                    }
                    else
                    {
                        mIsStatus = READ_SETANTOK;
                    }
                    break;
                case RcpBase.RCP_MM_READ_C_UII:
                    if (rtn == RcpBase.RCP_MSG_NOTI || rtn == RcpBase.RCP_MSG_AUTO)
                    {
                        int intTagType = (Data.Payload[0] >> 5 & 0x7);
                        int pcepclen = RcpBase.GetCodeLen(Data.Payload[1]);
                        int datalen = Data.Length - 1;

                        TagInfo cp = new TagInfo
                        {
                            TagType = TagType.TYPE_6C,
                            Length = datalen,//Remove the antenna number and RSSI
                            Antenna = (Data.Payload[0] & 0x1f),
                            PCData = ConvertData.GetData(Data.Payload, 1, 2),
                            EPCData = ConvertData.GetData(Data.Payload, 3, pcepclen - 2),
                            Rssi = GetRssi(Data.Payload[Data.Length - 1]) + "dBm"
                        };
                        if ((datalen - pcepclen - 1) > 0)
                        {
                            if (cEPC.Width == 440) cEPC.Width = 240;
                            cp.DataBytes = ConvertData.GetData(Data.Payload, 1 + pcepclen, datalen - pcepclen);
                            cp.Rssi = "null";
                        }
                        TagsTableInsertTag(cp);
                    }
                    else if (rtn == RcpBase.RCP_MSG_OK || rtn == RcpBase.RCP_MSG_ERR)
                    {
                        ledAllTags.Text = m_dtTagTable.AllTags.ToString();

                        if (SingleReadFlag)
                        {
                            ledInventoryTimes.Text = DateTime.Now.Subtract(dtStart).TotalSeconds.ToString("0.00");
                        }

                        if (SingleReadFlag)
                        {
                            SingleReadFlag = false;
                        }
                        else
                        {
                            if (mIsStatus == READ_IDENTIFY_WAIT)
                            {
                                mIsStatus = READ_IDENTIFYOK;
                            }
                        }
                    }
                    break;
            }
        }

        DateTime dtStart = DateTime.Now;
        private void btnReadMultiple_Click(object sender, EventArgs e)
        {
            if (mIsStart)
            {
                ScanStop();
            }
            else
            {
                ScanStart();
            }
        }

        private void ScanStart()
        {
            mIsStop = false;
            nReadShowRate = 50;
            mCommandDelay = 2;
            if (nudMaxTag.Value > 100)
            {
                mCommandDelay = (int)(nudMaxTag.Value / 100) * 2;
            }
            InitInventoryPara();
            InitAnt();
            mIsStatus = READ_START;
        }

        private void ScanStop()
        {
            mIsStatus = READ_EXIT;
        }

        private void InitInventoryPara()
        {
            this.listViewEPC.Items.Clear();
            this.m_dtTagTable.Clear();
            nInventoryCount = 0;
            ledInventoryTags.Text = m_dtTagTable.InventoryTags.ToString();
            ledInventoryTimes.Text = "0";
            ledAllTags.Text = m_dtTagTable.AllTags.ToString();
            ledAllTimes.Text = "0";
            dtStart = DateTime.Now;
        }

        private void btnClearScreen_Click(object sender, EventArgs e)
        {
            InitInventoryPara();
        }

        #region ---mult ant deal---
        int nAntIndex = 0;
        List<int> nAntChooseList = new List<int>();

        private void SetCurrentAnt(int i)
        {
            ledCurrentAnt.Text = i.ToString();
        }

        private void InitAnt()
        {
            nAntIndex = 0;
            nAntChooseList = SystemPub.AntCurrentListInt;
            if (nAntChooseList.Count > 0)
                SetCurrentAnt(nAntChooseList[nAntIndex]);
            else
                SetCurrentAnt(0);
        }

        private int ChangeAnt()
        {
            int CurrentAnt = 0xff;
            if (nudInventoryCount.Value != 0 && nInventoryCount >= nudInventoryCount.Value)
            {
                ScanStop();
                return CurrentAnt;
            }

            if (SystemPub.RcpBase.Type != "S")
            {
                CurrentAnt = 0;
                SetCurrentAnt(CurrentAnt);
                return CurrentAnt;
            }

            if (nAntChooseList.Count == 0)
            {
                ScanStop();
                MessageBox.Show("Have not choose Ant!", "Ant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return CurrentAnt;
            }

            byte[] ant = new byte[2] { 0xff, 0xff };
            byte current = (byte)(nAntChooseList[nAntIndex]);
            CurrentAnt = current;


            SetCurrentAnt(current);
            nAntIndex++;
            if (nAntIndex >= nAntChooseList.Count)
            {
                nAntIndex = 0;
                nInventoryCount++;
            }
            return CurrentAnt;
        }

        #endregion

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (mIsAutoCycleActive)
            {
                ProcessAutoCycle();
            }
            if (mIsStart)
            {
                if (mIsAutoCycleActive)
                {
                    ledAllTimes.Text = DateTime.Now.Subtract(dtStart).TotalSeconds.ToString("0.00");
                }
                else
                {
                    ledAllTimes.Text = DateTime.Now.Subtract(dtStart).TotalSeconds.ToString("0.00");
                    int nRunTimes = (int)DateTime.Now.Subtract(dtStart).TotalSeconds;
                    if (nudRunTimes.Value != 0 && nRunTimes >= nudRunTimes.Value)
                    {
                        ScanStop();
                    }
                }
            }
            switch (mIsStatus)
            {
                case READ_EXIT:
                    TagTableUpdate(true);

                    if (!mIsAutoCycleActive)
                    {
                        btnSingleRead.Enabled = true;
                    }

                    mIsStatus = READ_STOP;
                    mIsStart = false;

                    if (!mIsAutoCycleActive)
                    {
                        ChangeLanguage();
                    }

                    break;
                case READ_START:
                    mIsStart = true;

                    if (!mIsAutoCycleActive)
                    {
                        btnSingleRead.Enabled = false;
                        ChangeLanguage();
                    }

                    mIsStatus = READ_SETANT;
                    break;
                case READ_SETANT:
                    if (mIsStop) return;

                    mCurrentAnt = ChangeAnt();

                    if (mIsAutoCycleActive && mCurrentAnt == 0xff)
                    {
                        // Nếu ChangeAnt() trả về 0xff (do nudInventoryCount),
                        // nhưng đang ở chế độ auto, hãy bỏ qua và tiếp tục
                        mIsStatus = READ_SETANT; // Thử lại ở tick sau
                        return;
                    }

                    if (mCurrentAnt == 0)
                    {
                        mIsStatus = READ_IDENTIFY;
                    }
                    else if (mCurrentAnt >= 1 && mCurrentAnt <= 16)
                    {
                        mIsStatus = READ_IDENTIFY;
                    }
                    Application.DoEvents();
                    break;

                case READ_SETANTOK:
                    mIsStatus = READ_IDENTIFY;
                    break;
                case READ_IDENTIFY:
                    if (mIsStop) return;
                    if (mLoopInterval++ < (nudInventoryInterval.Value / 10))
                    {
                        return;
                    }
                    mLoopDelay = 0;
                    mLoopInterval = 0;
                    if (mCurrentAnt == 0)
                    {
                        SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_READ_C_UII, RcpBase.RCP_MSG_CMD));
                    }
                    else if (mCurrentAnt >= 1 && mCurrentAnt <= 16)
                    {
                        List<byte> param = new List<byte>();
                        param.Add(1);
                        param.Add((byte)mCurrentAnt);
                        SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_READ_C_UII, RcpBase.RCP_MSG_CMD, param.ToArray()));
                    }
                    mIsStatus = READ_IDENTIFY_WAIT;
                    Application.DoEvents();
                    break;
                case READ_IDENTIFYOK:
                    mIsStatus = READ_SETANT;
                    break;
                case READ_SETANT_WAIT:
                case READ_IDENTIFY_WAIT:
                    if (mLoopDelay++ > ((mCommandDelay * 1000) / 10))
                    {
                        mIsStatus = READ_SETANT;
                        return;
                    }
                    break;
                default:
                    break;
            }
        }
        //private void btnExport_Click(object sender, EventArgs e)
        //{
        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string localFilePath = saveFileDialog.FileName.ToString(); //Get the file path

        //        StreamWriter sw = new StreamWriter(localFilePath, true);

        //        try
        //        {
        //            foreach (ListViewItem lvi in listViewEPC.Items)
        //            {
        //                string strbuf = lvi.SubItems[2].Text;
        //                sw.WriteLine(strbuf); sw.Flush();
        //            }
        //        }
        //        catch { }
        //        sw.Close();
        //        sw = null;
        //        btnExport.Enabled = false;
        //        listViewEPC.Items.Clear();
        //        MessageBox.Show("Save OK!");
        //    }
        //}

        private void ExportTagsTable()
        {
            // CÁC HẰNG SỐ CỤC BỘ (LOCAL CONSTANTS)
            // *** RẤT QUAN TRỌNG: CẦN THAY ĐỔI ĐƯỜNG DẪN NÀY CHO CHÍNH XÁC VỚI HỆ THỐNG CỦA BẠN ***
            const string EXPORT_FILE_PATH_BASE = "C:\\xampp\\htdocs\\RFID2.3\\scan_logs\\";

            // Tên file sẽ được tạo ra
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"tags_scan_{timestamp}.txt";
            string filePath = Path.Combine(EXPORT_FILE_PATH_BASE, fileName);

            try
            {
                // 1. Đảm bảo thư mục lưu trữ tồn tại
                Directory.CreateDirectory(EXPORT_FILE_PATH_BASE);

                // 2. Ghi dữ liệu EPC vào file
                int tagCount = m_dtTagTable.Table.Rows.Count;
                if (tagCount == 0)
                {
                    MessageBox.Show("Không có thẻ nào được quét để xuất file.", "Xuất File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    foreach (DataRow rowfs in m_dtTagTable.Table.Rows)
                    {
                        // Lấy Device ID (EPC)
                        string epc = rowfs["EPC"].ToString();
                        sw.WriteLine(epc);
                    }
                }

                // 3. Thông báo cho người dùng khi thành công
                MessageBox.Show($"Đã xuất thành công {tagCount} EPC vào file: \n{filePath}",
                                "Xuất file thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // 4. Thông báo lỗi chi tiết
                MessageBox.Show($"Lỗi khi xuất dữ liệu: Vui lòng kiểm tra lại đường dẫn ({EXPORT_FILE_PATH_BASE}) và quyền ghi.\nChi tiết lỗi: {ex.Message}",
                                "Lỗi Xuất File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thay thế toàn bộ hàm này trong ucMReadDemo.cs
        private void btnExport_Click(object sender, EventArgs e)
        {
            // Gọi phương thức xuất file đã tạo
            ExportTagsTable();
            // Giữ lại dòng này để tắt nút nếu cần, nhưng không cần thiết
            // btnExport.Enabled = false; 
        }

        bool SingleReadFlag = false;
        private void btnSingleRead_Click(object sender, EventArgs e)
        {
            InitInventoryPara();
            SystemPub.SendSio(new ProtocolPacket(SystemPub.RcpBase.Address, RcpBase.RCP_MM_READ_C_UII, RcpBase.RCP_MSG_CMD));
            dtStart = DateTime.Now;
            SingleReadFlag = true;
        }

        TagsTable m_dtTagTable = new TagsTable();

        private void TagsTableInsertTag(TagInfo cp)
        {
            if (this.InvokeRequired)
            {
                TagsTableInsertTagUnsafe InvokeRefreshInsert = new TagsTableInsertTagUnsafe(TagsTableInsertTag);
                this.Invoke(InvokeRefreshInsert, new object[] { cp });
            }
            else
            {
                if (cp.DataString != "/")
                {
                    if (cDATA.Width != 240) cDATA.Width = 240;
                }
                if (cp.CRCString != "/")
                {
                    if (cDATA.Width != 60) cDATA.Width = 60;
                }

                if (m_dtTagTable.InventoryTags >= nudMaxTag.Value)
                {
                    TagTableUpdate(false);
                    return;
                }
                if (m_dtTagTable.TagsTableInsert(cp))
                {
                    ledInventoryTags.Text = m_dtTagTable.InventoryTags.ToString(); //Tổng số nhãn
                    ledInventoryTimes.Text = DateTime.Now.Subtract(dtStart).TotalSeconds.ToString("0.00");
                    btnExport.Enabled = m_dtTagTable.InventoryTags > 0;
                }

                ledAllTags.Text = m_dtTagTable.AllTags.ToString(); //Tổng số nhãn
                if (m_dtTagTable.InventoryTags >= nudMaxTag.Value)
                {
                    ScanStop();
                }
                TagTableUpdate(false);
            }
        }

        private void TagTableUpdate(bool flag)
        {
            if (this.InvokeRequired)
            {
                TagsTableUpdateUnsafe InvokeRefreshShow = new TagsTableUpdateUnsafe(TagTableUpdate);
                this.Invoke(InvokeRefreshShow, new object[] { flag });
            }
            else
            {
                //Tạo danh sách
                int nEpcCountFS = listViewEPC.Items.Count;
                int nEpcLengthFS = m_dtTagTable.InventoryTags;
                if (nEpcCountFS < nEpcLengthFS)
                {
                    DataRow rowfs = m_dtTagTable.Table.Rows[nEpcLengthFS - 1];
                    ListViewItem itemfs = new ListViewItem();
                    itemfs.Text = (nEpcCountFS + 1).ToString();
                    itemfs.SubItems.Add(rowfs["PC"].ToString());
                    itemfs.SubItems.Add(rowfs["EPC"].ToString());
                    itemfs.SubItems.Add(rowfs["CRC"].ToString());
                    itemfs.SubItems.Add(rowfs["DATA"].ToString());
                    itemfs.SubItems.Add(rowfs["COUNT"].ToString());

                    itemfs.SubItems.Add(rowfs["ANTSTRING"].ToString());

                    itemfs.SubItems.Add(rowfs["RSSI"].ToString());
                    listViewEPC.Items.Add(itemfs);
                    listViewEPC.Items[nEpcCountFS].EnsureVisible();
                }

                TagTableShow(flag);
            }
        }

        private void TagTableShow(bool flag)
        {
            if (this.InvokeRequired)
            {
                TagsTableShowUnsafe InvokeRefreshUpdate = new TagsTableShowUnsafe(TagTableShow);
                this.Invoke(InvokeRefreshUpdate, new object[] { flag });
            }
            else
            {
                //Cập nhật số lần đọc trong danh sách
                if (m_dtTagTable.AllTags % nReadShowRate == 1 || DateTime.Now.Subtract(nReadShowTime).TotalSeconds > 2 || flag)
                {
                    int nIndex = 0;
                    foreach (DataRow rowfs in m_dtTagTable.Table.Rows)
                    {
                        ListViewItem itemfs = listViewEPC.Items[nIndex];
                        itemfs.SubItems[5].Text = rowfs["COUNT"].ToString();
                        itemfs.SubItems[6].Text = rowfs["ANTSTRING"].ToString();
                        itemfs.SubItems[7].Text = rowfs["RSSI"].ToString();
                        nIndex++;
                    }
                    nReadShowTime = DateTime.Now;
                    SetAntHeadText(m_dtTagTable.MaxAntNum, cAnt);
                }
            }
        }

        private void btnToggleAutoCycle_Click(object sender, EventArgs e)
        {
            mIsAutoCycleActive = !mIsAutoCycleActive;

            if (mIsAutoCycleActive)
            {
                // === BẮT ĐẦU CHU TRÌNH ===
                btnToggleAutoCycle.Text = "Stop Auto Cycle";

                // Bắt đầu chu trình đầu tiên ngay lập tức
                mCycleNextStartTime = DateTime.Now;
                mCurrentCycleState = AutoCycleState.Waiting;

                // Vô hiệu hóa các nút điều khiển thủ công
                btnReadMultiple.Enabled = false;
                btnClearScreen.Enabled = false;
                btnExport.Enabled = false;
                btnSingleRead.Enabled = false;
            }
            else
            {
                // === DỪNG CHU TRÌNH ===
                btnToggleAutoCycle.Text = "Start Auto Cycle";

                // Nếu đang quét, dừng ngay lập tức
                if (mIsStart)
                {
                    ScanStop();
                }
                mCurrentCycleState = AutoCycleState.Waiting;

                // Kích hoạt lại các nút điều khiển thủ công
                btnReadMultiple.Enabled = true;
                btnClearScreen.Enabled = true;
                btnExport.Enabled = true;
                btnSingleRead.Enabled = true;
            }
        }
        private void ProcessAutoCycle(){
            switch (mCurrentCycleState)
            {
                case AutoCycleState.Waiting:
                    // Chờ (10 phút) rồi kiểm tra xem đã đến lúc bắt đầu chu trình mới chưa
                    if (DateTime.Now >= mCycleNextStartTime){
                        mCurrentCycleState = AutoCycleState.Clearing;
                    }
                    break;
                case AutoCycleState.Clearing:
                    // Trigger state Clear bằng cách gọi hàm tự động clear (giống như nhấn nút Clear)
                    InitInventoryPara();
                    mCurrentCycleState = AutoCycleState.StartingScan;
                    break;
                case AutoCycleState.StartingScan:
                    // Trigger state Start Reading bằng cách gọi hàm scan (giống như nhấn nút Start)
                    ScanStart();
                    // Đặt mốc thời gian dừng quét (2 phút)
                    mScanStopTime = DateTime.Now.AddMinutes(SCAN_MINUTES);
                    mCurrentCycleState = AutoCycleState.Scanning;
                    break;
                case AutoCycleState.Scanning:
                    // Chờ (2 phút) rồi Kiểm tra xem đã hết 2 phút quét chưa
                    if (DateTime.Now >= mScanStopTime){
                        mCurrentCycleState = AutoCycleState.Stopping;
                    }
                    break;
                case AutoCycleState.Stopping:
                    // Trigger state Stop
                    ScanStop();
                    mCurrentCycleState = AutoCycleState.Exporting;
                    break;
                case AutoCycleState.Exporting:
                    // Chờ cho đến khi máy quét thực sự dừng (mIsStatus == READ_STOP)
                    if (mIsStatus == READ_STOP)
                    {
                        // Đặt mốc thời gian chờ (10 phút)
                        mCycleNextStartTime = DateTime.Now.AddMinutes(WAIT_MINUTES);

                        // Đổi trạng thái để ngăn Timer lặp lại
                        mCurrentCycleState = AutoCycleState.Waiting;

                        // Trigger state Export
                        ExportTagsTable();
                    }
                    break;
            }
        }


    }
}
