using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace prjInBaoCaKetQuaThamDinh
{
    public partial class ctrInBaoCaoKetQuaThamDinh : UserControl
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
        public ctrInBaoCaoKetQuaThamDinh()
        {
            InitializeComponent();
        }
        public string fileReport()
        {
            string file = "";
            file = Application.ProductName;
            file = Application.StartupPath + @"\Reports\KetQuaThamDinh\rptBCKetQuaThamDinh.rpt";
            return file;
        }
        public string ChuSuDung()
        {
            clsBaoCaoKetQuaThamDinh cls = new clsBaoCaoKetQuaThamDinh();
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
        //lay thong tin ve phuong, quan, thanh pho
        public string[] DonViHanhChinh()
        {
            clsBaoCaoKetQuaThamDinh cls = new clsBaoCaoKetQuaThamDinh();
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


       //private void  HideSubReport(ref  ReportDocument objRep , string  strSubReportName)
       //{

       // foreach (ReportObject  objX in objRep.ReportDefinition.ReportObjects)
       // {
       //     /* Neu la SubReportName */
       //     if (objX.GetType()  is SubreportObject)
       //     {
       //         /* Ten cua SubReportName la  */
       //         if (objX.Name == strSubReportName)
       //         {
       //             SubreportObject objSubReport = (SubreportObject)objX;
       //             objSubReport.ObjectFormat.EnableSuppress = true;
       //         }
       //     }
       // }
       //}


        public void ctrInBaoCaoKetQuaThamDinh_Load()
        {
            clsBaoCaoKetQuaThamDinh cls = new clsBaoCaoKetQuaThamDinh();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            reportDocument1.FileName = fileReport();
            DataTable dtHoSo = new DataTable();
            DataTable dtNguonGoc = new DataTable();
            dtHoSo = cls.SelectThongTinDatNhaO();
            dtNguonGoc = cls.SelectThongTinNguonGoc();
            string[] DVHC = new string[3];
            DVHC = DonViHanhChinh();
            try
            {
                if (dtHoSo.Rows.Count > 0)
                {
                    dtHoSo.Columns.Add("ChuSuDung");
                    dtHoSo.Rows[0]["ChuSuDung"] = ChuSuDung();
                    dtHoSo.Columns.Add("TenQuan");
                    dtHoSo.Rows[0]["TenQuan"] = DVHC[1].ToUpper();
                    dtHoSo.Columns.Add("TenQuanThuong");
                    dtHoSo.Rows[0]["TenQuanThuong"] = DVHC[1];
                    dtHoSo.Columns.Add("NgayHT");
                    dtHoSo.Rows[0]["NgayHT"] = DVHC[1].Trim().Substring(5) + ", Ngày ........... tháng ........ năm " + DateTime.Now.Year;

                    string strChiTietNguonGoc = "";

                    if (dtNguonGoc.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtNguonGoc.Rows.Count; i++)
                        {
                            if (dtNguonGoc.Rows[i]["ChiTiet"].ToString() != "")
                            {
                                strChiTietNguonGoc += " " + dtNguonGoc.Rows[i]["ChiTiet"].ToString();
                            }
                        }
                    }
                    /* Chi tiết nguồn gốc sử dụng */
                    dtHoSo.Columns.Add("ChiTiet");
                    dtHoSo.Rows[0]["ChiTiet"] = strChiTietNguonGoc;

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
