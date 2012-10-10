using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMC.Land.InThongBaoCapGCN
{
    public partial class ctrInThongBaoCapGCN : UserControl
    {
        private string strMaHoSoCapGCN ;
        private string strConnection="";
        private string strNgayThongBao = "";
        public string MaHoSoCapGCN
        {
            get { return strMaHoSoCapGCN; }
            set { strMaHoSoCapGCN = value; }
        }
        public string NgayThongBao
        {
            get { return strNgayThongBao ; }
            set { strNgayThongBao = value; }
        }
        public string Conection
        {
            get
            {
                return strConnection;
            }
            set
            {
                strConnection = value;
            }
        }
        
        public ctrInThongBaoCapGCN()
        {
            InitializeComponent();
        }
        public string ChuSuDung()
        {
            clsInThongBaoCapGCN cls = new clsInThongBaoCapGCN();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            DataTable dt = new DataTable();
            dt = cls.SelectChuSuDung();
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
        public string fileReport()
        {
            short ViTri;
            string path;
            string file = "";
            file = Application.ProductName;
            file = Application.StartupPath + @"\Reports\ThongBaoCapGCN\rptThongBaoCapGCN.rpt";
            return file;
        }

        private void ctrInThongBaoCapGCN_Load()
        {
            clsInThongBaoCapGCN cls = new clsInThongBaoCapGCN();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            reportDocument1.FileName = fileReport();
            //cls.KNReports(reportDocument1);
            DataTable dtHoSo = new DataTable();
            dtHoSo = cls.ThongTinHoSo();
            if (dtHoSo.Rows.Count > 0)
            {
                dtHoSo.Columns.Add("ChuSuDung");
                dtHoSo.Columns.Add("NgayThang");
                dtHoSo.Columns.Add("DiaChiLayGCN");
                dtHoSo.Columns.Add("SoQD");
                dtHoSo.Columns.Add("GiamDoc");
                dtHoSo.Rows[0]["ChuSuDung"] = ChuSuDung();
                dtHoSo.Rows[0]["NgayThang"] = strNgayThongBao;// "Hà Nội, ngày " + dtpNgayNhan.Value.Day + " tháng " + dtpNgayNhan.Value.Month + " năm " + dtpNgayNhan.Value.Year;
                dtHoSo.Rows[0]["DiaChiLayGCN"] = txtDiaChiNoiNhan.Text.Trim() ;
                dtHoSo.Rows[0]["SoQD"] = dtHoSo.Rows[0]["SoQuyetDinhCapGCN"] + " ngày " + string.Format("{0: dd/MM/yyyy}", dtHoSo.Rows[0]["NgayQuyetDinhCapGCN"]) + " ";//(dtHoSo.Rows[0]["NgayQuyetDinhCapGCN"].ToString(), "dd/MM/yyyy", null).ToString();
                dtHoSo.Rows[0]["GiamDoc"] = txtNguoiKy.Text.Trim();
            }
           
            reportDocument1.SetDataSource(dtHoSo);
            crystalReportViewer1.ReportSource = reportDocument1;
        }

        private void cmdHienThi_Click(object sender, EventArgs e)
        {
            ctrInThongBaoCapGCN_Load();
        }

        private void txtNguoiKy_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
