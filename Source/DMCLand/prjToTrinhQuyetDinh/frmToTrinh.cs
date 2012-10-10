using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjToTrinhQuyetDinh
{
    public partial class frmToTrinh : Form
    {
        private string strConnection = "";
        private string strMaHoSoCapGCN = "";
        private string[] strTenMaDVHC;
        private string strSoToTrinh = "";
        private DateTime strNgayTrinh;
        private string strNguoiKyTrinh = "";
        private string strChuSuDung = "";
        private string strNghiaVuTaiChinh = "";
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
        public string[] TenMaDVHC
        {
            set { strTenMaDVHC = value; }
            get { return strTenMaDVHC; }
        }
        public string SoToTrinh
        {
            set { strSoToTrinh = value; }
            get { return strSoToTrinh; }
        }
        public DateTime NgayTrinh
        {
            set { strNgayTrinh = value; }
            get { return strNgayTrinh; }
        }
        public string NguoiKyTrinh
        {
            set { strNguoiKyTrinh = value; }
            get { return strNguoiKyTrinh; }
        }
        public string ChuSuDung
        {
            set { strChuSuDung = value; }
            get { return strChuSuDung; }
        }
        public string NghiaVuTaiChinh
        {
            set { strNghiaVuTaiChinh = value; }
            get { return strNghiaVuTaiChinh; }
        }
        public frmToTrinh()
        {
            InitializeComponent();
        }

        public string fileReport()
        {
            string file = "";
            file = Application.ProductName;
            file = Application.StartupPath + @"\Reports\ToTrinhQuyetDinh\rptTotrinh.rpt";
            return file;
        }
        private void frmToTrinh_Load(object sender, EventArgs e)
        {
            clsToTrinhQuyetDinh cls = new clsToTrinhQuyetDinh();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            reportDocument1.FileName = fileReport();
            DataTable dtHoSo = new DataTable();
            dtHoSo = cls.SelectThongTinDatNhaO();
            try
            {
                if (dtHoSo.Rows.Count > 0)
                {
                    dtHoSo.Columns.Add("ChuSuDung");
                    dtHoSo.Rows[0]["ChuSuDung"] = strChuSuDung;
                    dtHoSo.Columns.Add("TenQuan");
                    dtHoSo.Rows[0]["TenQuan"] = strTenMaDVHC[1].ToString().ToUpper();
                    dtHoSo.Columns.Add("TenQuanThuong");
                    dtHoSo.Rows[0]["TenQuanThuong"] = strTenMaDVHC[0];
                    dtHoSo.Columns.Add("NgayHT");
                    dtHoSo.Rows[0]["NgayHT"] = strTenMaDVHC[1].Trim().Substring(5) + ", Ngày " + strNgayTrinh.Day + " tháng " + strNgayTrinh.Month + " năm " + strNgayTrinh.Year;
                    dtHoSo.Columns.Add("SoToTrinh");
                    dtHoSo.Rows[0]["SoToTrinh"] = strSoToTrinh;
                    dtHoSo.Columns.Add("TruongPhong");
                    dtHoSo.Rows[0]["TruongPhong"] = strNguoiKyTrinh;
                    ///* Nghĩa vụ tài chính */
                    //dtHoSo.Columns.Add("NghiaVuTaiChinh");
                    //dtHoSo.Rows[0]["NghiaVuTaiChinh"] = strNghiaVuTaiChinh;
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
