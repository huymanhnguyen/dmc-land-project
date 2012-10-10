using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace prjPhieuChuyenThongTinDiaChinh
{
    public partial class ctrPhieuChuyenThongTinDiaChinh : UserControl
    {
         private string strConnection = "";
        private string strMaHoSoCapGCN = "";
        private string strMaDVHC = "";
        private string[] strTenMaDVHC;
        public string Connection
        {
            set { strConnection = value; }
            get { return strConnection; }
        }
        public string MaHoSoCapGCN
        {
            set { strMaHoSoCapGCN = value; }
            get { return strMaHoSoCapGCN; }
        }
        public string MaDVHC
        {
            set { strMaDVHC = value; }
            get { return strMaDVHC; }
        }
        public string[] TenMaDVHC
        {
            set { strTenMaDVHC = value; }
            get { return strTenMaDVHC; }
        }
        public ctrPhieuChuyenThongTinDiaChinh()
        {
            InitializeComponent();
        }
        public string ChuSuDung()
        {
            clsPhieuChuyenThongTinDiaChinh cls = new clsPhieuChuyenThongTinDiaChinh();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            DataTable dt = new DataTable();
            dt = cls.SelectChuHoSoCapGCN();
            string str = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str = str + dt.Rows[i]["hoten"] + ",";
                }
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }
        //lay thong tin ve phuong, quan, thanh pho
        public string[] DonViHanhChinh()
        {
            clsPhieuChuyenThongTinDiaChinh cls = new clsPhieuChuyenThongTinDiaChinh();
            cls.Connection = strConnection;
            cls.MaDVHC = strMaDVHC;
            DataTable dtDVHC = new DataTable();
            dtDVHC = cls.SelectDVHC();
            string[] arrMangGiaTriDVHC = new string[3];
            if (dtDVHC.Rows.Count > 0)
            {
                arrMangGiaTriDVHC[0] = dtDVHC.Rows[0]["Ten"].ToString();
                arrMangGiaTriDVHC[1] = dtDVHC.Rows[0]["TenHuyen"].ToString();
                arrMangGiaTriDVHC[2] = dtDVHC.Rows[0]["TenTinh"].ToString();
            }
            return arrMangGiaTriDVHC;
        }
        public string fileReport()
        {
            string file = "";
            file = Application.ProductName;
            file = Application.StartupPath + @"\Reports\NghiaVuTaiChinh\rptPhieuChuyenThongTinDiaChinh.rpt";
            return file;
        }
        public void ctrPhieuChuyenThongTinDiaChinh_Load()
        {
            clsPhieuChuyenThongTinDiaChinh cls = new clsPhieuChuyenThongTinDiaChinh();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            reportDocument1.FileName = fileReport();
            DataTable dtHoSo = new DataTable();
            DataTable dtNguonGoc = new DataTable();
            dtHoSo = cls.SelectThongTinDatNhaO();
            dtNguonGoc = cls.SelectThongTinDatNhaO();
            string[] DVHC = new string[3];
            DVHC = DonViHanhChinh();
            try
            {
                if (dtHoSo.Rows.Count > 0)
                {
                    dtHoSo.Columns.Add("ChuSuDung");
                    dtHoSo.Rows[0]["ChuSuDung"] = ChuSuDung();
                    dtHoSo.Columns.Add("TenQuanHoa");
                    dtHoSo.Rows[0]["TenQuanHoa"] = DVHC[1].ToUpper();
                    dtHoSo.Columns.Add("TenQuanThuong");
                    dtHoSo.Rows[0]["TenQuanThuong"] = DVHC[1];
                    dtHoSo.Columns.Add("NgayHeThong");
                    dtHoSo.Rows[0]["NgayHeThong"] = DVHC[1].Trim().Substring(5) + ", Ngày ........... tháng ........ năm " + DateTime.Now.Year;
                    
                    reportDocument1.SetDataSource(dtHoSo);
                    crystalReportViewer1.ReportSource = reportDocument1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message);
            }
        }
    }
}
