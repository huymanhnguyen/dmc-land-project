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
    public partial class frmQuyetDinh : Form
    {
        private string strConnection = "";
        private string strMaHoSoCapGCN = "";
        private string[] strTenMaDVHC;
        private string strSoToTrinh = "";
        private DateTime strNgayQuyetDinh ;
        private string strNgayTrinh = "";
        private string strChuSoHuu = "";
        private string strNguoiQuyetDinhKy = "";
        private string strChuSuDung = "";

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
        public DateTime NgayQuyetDinh
        {
            set { strNgayQuyetDinh = value; }
            get { return strNgayQuyetDinh ; }
        }
        public string NguoiKyQuyetDinh
        {
            set { strNguoiQuyetDinhKy= value; }
            get { return strNguoiQuyetDinhKy ; }
        }
        public string ChuSuDung
        {
            set { strChuSuDung = value; }
            get { return strChuSuDung; }
        }
        public string ChuSoHuu
        {
            set { strChuSoHuu = value; }
            get { return strChuSoHuu; }
        }
        public string NgayTrinh
        {
            set { strNgayTrinh = value; }
            get { return strNgayTrinh; }
        }
        public frmQuyetDinh()
        {
            InitializeComponent();
        }
        public string fileReport()
        {
            string file = "";
            file = Application.ProductName;
            file = Application.StartupPath + @"\Reports\ToTrinhQuyetDinh\rptQuyetDinh.rpt";
            return file;
        }
        private void frmQuyetDinh_Load(object sender, EventArgs e)
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
                    dtHoSo.Rows[0]["TenQuan"] = strTenMaDVHC[1].ToUpper();
                    dtHoSo.Columns.Add("TenQuanThuong");
                    dtHoSo.Rows[0]["TenQuanThuong"] = strTenMaDVHC[0];
                    dtHoSo.Columns.Add("NgayHT");
                    dtHoSo.Rows[0]["NgayHT"] = strTenMaDVHC[1].Trim().Substring(5) + ", Ngày " + strNgayQuyetDinh.Day + " tháng " + strNgayQuyetDinh.Month + " năm " + strNgayQuyetDinh.Year;
                    dtHoSo.Columns.Add("SoToTrinh");
                    dtHoSo.Rows[0]["SoToTrinh"] = strSoToTrinh;
                    dtHoSo.Columns.Add("NgayTrinh");
                    dtHoSo.Rows[0]["NgayTrinh"] = strNgayTrinh;
                    dtHoSo.Columns.Add("ChuSoHuu");
                    dtHoSo.Rows[0]["ChuSoHuu"] = strChuSoHuu;
                    dtHoSo.Columns.Add("NguoiKy");
                    dtHoSo.Rows[0]["NguoiKy"] = strNguoiQuyetDinhKy;
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
