using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjInHoSoKyThuat
{
    public partial class CtrInHoSoKyThuat : UserControl
    {
        /* Khai báo và khởi tạo biến Mã hồ sơ cấp GCN */
        private string  strMaHoSoCapGCN = "";
        /* Khai báo và khởi tạo Mã thửa đất */
        private  string strMaThuaDat = "";
        /* Khai báo và khởi tạo chuỗi kết nối cơ sở dữ liệu */
        private string strConnection = "";
        /* Khai báo thuộc tính Mã hồ sơ cấp GCN */
        public string MaHoSoCapGCN
        {
            get { return strMaHoSoCapGCN; }
            set { strMaHoSoCapGCN = value; }
        }
        /* Khai báo thuộc tính chuỗi kết nối cơ sở dữ liệu */
        public string Conection
        {
            get {return strConnection;}
            set {strConnection = value;}
        }

        public CtrInHoSoKyThuat()
        {
            InitializeComponent();
        }
        public string ChuHoSoCapGCN() 
        {
            string strChuHoSoCapGCN = "";
            try
            {
                clsInHoSoKyThuat HoSoKyThuat = new clsInHoSoKyThuat();
                HoSoKyThuat.Connection = strConnection;
                HoSoKyThuat.MaHoSoCapGCN = strMaHoSoCapGCN;
                DataTable dt = new DataTable();
                dt = HoSoKyThuat.SelectChuHoSoCapGCN();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strChuHoSoCapGCN = strChuHoSoCapGCN + dt.Rows[i]["HoTen"] + ",";
                    }
                    strChuHoSoCapGCN = strChuHoSoCapGCN.Substring(0, strChuHoSoCapGCN.Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"Lỗi: " + System.Environment.NewLine + ex.Message,"DMCLand",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
            return strChuHoSoCapGCN;
        }

         public string  fileReport() 
         {
            string  file  = "";
            try
            {
                file = Application.ProductName;
                file = Application.StartupPath + @"\Reports\rptHoSoKyThuat.rpt";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Lỗi: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return file;
         }

         public void CtrInHoSoKyThuat_Load()
         {
            clsInHoSoKyThuat HoSoKyThuat = new clsInHoSoKyThuat();
            HoSoKyThuat.Connection = strConnection;
            HoSoKyThuat.MaHoSoCapGCN = strMaHoSoCapGCN;
            HoSoKyThuat.MaThuaDat = strMaThuaDat;
            reportDocument1.FileName = fileReport();
            DataTable dtHoSo =new DataTable();
            DataTable dtDanhSachToaDo =new DataTable();
            DataTable dtHoSoKyThuat = new DataTable();
            try
            {
                dtHoSo  = HoSoKyThuat.SelectThuaDatCapGCNWithHoSoKyThuat();
                dtDanhSachToaDo = HoSoKyThuat.DanhSachToaDo();
                dtHoSoKyThuat = HoSoKyThuat.HoSoKyThuat();
                if (dtHoSo.Rows.Count > 0)
                {
                    dtHoSo.Columns.Add("ChuHoSoCapGCN");
                    dtHoSo.Rows[0]["ChuHoSoCapGCN"] = ChuHoSoCapGCN();
                }
                //if (dtDanhSachToaDo.Rows.Count > 0)
                //{
                    reportDocument1.Subreports["DanhSachToaDo"].SetDataSource(dtDanhSachToaDo);
                //}
                //if (dtHoSoKyThuat.Rows.Count > 0)
                //{
                    reportDocument1.Subreports["HoSoThuaDat"].SetDataSource(dtHoSoKyThuat);
                //}
                reportDocument1.SetDataSource(dtHoSo);
                crystalReportViewer1.ReportSource = reportDocument1;
            }
            catch( Exception ex)
            {
                MessageBox.Show(this,"Lỗi hiển thị báo cáo: " + System.Environment.NewLine  + ex.Message,"DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
