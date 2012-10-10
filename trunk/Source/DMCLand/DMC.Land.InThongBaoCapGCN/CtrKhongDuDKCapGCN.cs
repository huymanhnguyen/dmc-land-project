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
    public partial class CtrKhongDuDKCapGCN : UserControl
    {
        public CtrKhongDuDKCapGCN()
        {
            InitializeComponent();
        }
        private string strMaHoSoCapGCN ;
        private string strConnection="";
        private string strNgayThongBao = "";
       private  string strToTrinh = "";
       private string strNgayTrinh = "";
       private string strNgayt = "";
       private string strNgaytt = "";
       private string strNgaytn = "";
       private string strNgayThamDinh = "";
       private string strThangThamDinh = "";
       private string strNguoiThamDinh = "";
       private string strNamThamDinh = "";
      
       private string strYKienThamDinh = "";
       private string strdonvihanhchinh = "";
       private string strUserName = "";

       public string UserName
       {
           get { return strUserName; }
           set { strUserName = value; }
       }
        //public string ToTrinh
        //    {set {strToTrinh =value;}
        //         get {return strToTrinh ;}
        //      }
        //public string NgayTrinh
        //{ set {strNgayTrinh =value ;}
        //     get {return strNgayTrinh ;}
        // }
        // public string NgayThamDinh
        // { set {strNgayThamDinh  =value; }
        //    get {return strNgayThamDinh ; }
        // }

        //public string ThangThamDinh
        //{set {strThangThamDinh =value ;}
        //     get {return strThangThamDinh ;}
        // }
        //public string NamThamDinh
        //{ 
        //     set{strNamThamDinh =value ;}
        //    get { return strNamThamDinh ;}
             
        // }
        //public string YKien
        //{  set {strYKienThamDinh =value;}
        //    get {return strYKienThamDinh ;}
        // }

        //public string NguoiThamDinh
        //{
        //    set { strNguoiThamDinh = value; }
        //    get { return strNguoiThamDinh; }
        // }

        public string DVHC
        {
            set { strdonvihanhchinh = value; }
            get { return strdonvihanhchinh; }
         }
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
        public  string  Conection
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
        public string ToTrinh()
        { 
            clsInThongBaoCapGCN cls = new clsInThongBaoCapGCN();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            DataTable dt = new DataTable();
            dt = cls.selectToTrinh();
            string str = "";
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0]["Totrinhphuong"].ToString ();
             }
            return str;
         }

        public string NgayTrinh()
        {
            clsInThongBaoCapGCN cls = new clsInThongBaoCapGCN();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            DataTable dt = new DataTable();
            dt = cls.selectToTrinh();
            string str = "";
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0]["NgayTrinhPhuong"].ToString ();
            }
            return str;
        }

        public string NgayThamDinh()
        {

            clsInThongBaoCapGCN cls = new clsInThongBaoCapGCN();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            DataTable dt = new DataTable();
            dt = cls.selectThamDinh();
            string str = "";
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0]["ngaythamdinhdknd"].ToString ();
            }
            return str;

        }
        public string NguoiThamDinh()
        {

            clsInThongBaoCapGCN cls = new clsInThongBaoCapGCN();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            DataTable dt = new DataTable();
            dt = cls.selectThamDinh();
            string str = "";
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0]["hotencanbothamdinhdknd"].ToString();
            }
            return str;

        }
        public string YKienThamDinh()
        {

            clsInThongBaoCapGCN cls = new clsInThongBaoCapGCN();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            DataTable dt = new DataTable();
            dt = cls.selectThamDinh();
            string str = "";
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0]["ykienthamdinhdknd"].ToString();
            }
            return str;

        }

        //public string TenPhuong()
        //{
        //    clsInThongBaoCapGCN cls = new clsInThongBaoCapGCN();
        //    cls.Connection = strConnection;
        //    cls.MaHoSoCapGCN = strMaHoSoCapGCN;
        //    DataTable dt = new DataTable();
        //    dt = cls.selectTenDVHC ();
        //    string str = "";
        //    if (dt.Rows.Count > 0)
        //    {
        //        str = dt.Rows[0]["ten"].ToString();
        //    }
        //    return str;
        //}
        public string fileReport()
        {
            short ViTri;
            string path;
            string file = "";
            file = Application.ProductName;
            file = Application.StartupPath + @"\Reports\ThongBaoCapGCN\rptKhongDuDieuKien.rpt";
            return file;
        }

        private void ctrInThongBaoCapGCN_Load()
        {

            strNgayThamDinh = NgayThamDinh();
            if (strNgayThamDinh .Length >0 )
            {
            strNgayThamDinh = strNgayThamDinh.Substring(strNgayThamDinh .IndexOf ("/")+1, strNgayThamDinh .LastIndexOf ("/")-strNgayThamDinh .IndexOf ("/")-1);
            }

            strThangThamDinh  = NgayThamDinh();
            if (strThangThamDinh .Length > 0)
            {
                strThangThamDinh  =strThangThamDinh .Substring (0,strThangThamDinh .IndexOf ("/"));

            }
            strNamThamDinh = NgayThamDinh();
               if (strNamThamDinh .Length >0)
               {
                   strNamThamDinh = strNamThamDinh.Substring(strNamThamDinh.LastIndexOf("/")+1,4);
                }

               strNgayTrinh = NgayTrinh();
               if (strNgayTrinh.Length  > 0)
               {
                   strNgayt  = strNgayTrinh.Substring(strNgayTrinh.IndexOf ("/")+1,strNgayTrinh .LastIndexOf ("/")-strNgayTrinh .IndexOf ("/")-1);

                }
               strNgayTrinh = NgayTrinh();
               if (strNgayTrinh.Length > 0)
               {
                   strNgaytt = strNgayTrinh.Substring(0, strNgayTrinh.IndexOf("/")); 
                }
               strNgayTrinh = NgayTrinh();
               if (strNgayTrinh.Length > 0)
               {
                   strNgaytn = strNgayTrinh.Substring(strNgayTrinh.LastIndexOf("/") + 1, 4);
                 }

               strNgayTrinh = strNgayt + "/" + strNgaytt + "/" + strNgaytn;


               clsInThongBaoCapGCN cls = new clsInThongBaoCapGCN();
               cls.Connection = strConnection;
               cls.DVHC  = strdonvihanhchinh ;
               reportDocument1.FileName = fileReport();
               //cls.KNReports(reportDocument1);
               DataTable dtHoSo = new DataTable();
               dtHoSo = cls.selectTenDVHC();
               dtHoSo.Columns.Add("ChuSuDung");
               dtHoSo.Columns.Add("ToTrinh") ;
               dtHoSo.Columns.Add("NgayTrinh");
               dtHoSo.Columns.Add("NgayThamDinh");
               dtHoSo.Columns.Add("ThangThamDinh");
               dtHoSo.Columns.Add("NamThamDinh");
               dtHoSo.Columns.Add("NguoiThamDinh"); 
               dtHoSo.Columns.Add("YKienThamDinh"); 
               dtHoSo.Rows[0]["ChuSuDung"] = ChuSuDung();
               dtHoSo.Rows[0]["NgayThamDinh"] = strNgayThamDinh;
               dtHoSo.Rows[0]["ThangThamDinh"] = strThangThamDinh ;
               dtHoSo.Rows[0]["NamThamDinh"] = strNamThamDinh ;
               dtHoSo.Rows[0]["ToTrinh"]= ToTrinh();
               dtHoSo.Rows[0]["NgayTrinh"] = strNgayTrinh ;
               dtHoSo.Rows[0]["NguoiThamDinh"]= NguoiThamDinh();
               dtHoSo.Rows[0]["YKienThamDinh"] = YKienThamDinh();


               reportDocument1.SetDataSource(dtHoSo);
               crystalReportViewer1.ReportSource = reportDocument1;

               NhatKyNguoiDung("In Thông Báo","In thông báo không đủ điều kiện cấp GCN");
        }
        public void NhatKyNguoiDung(string ChucNang, string MoTa)
        {
            prjNhatKyNguoiDung.clsNhatKyNguoiDung clsNhatky = new prjNhatKyNguoiDung.clsNhatKyNguoiDung();
            clsNhatky.Connection = strConnection;
            clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN;
            clsNhatky.MaDonViHanhChinh = strdonvihanhchinh;
            clsNhatky.UserName = strUserName;
            clsNhatky.NghiepVu = "In thông báo cấp GCN";
            clsNhatky.ChucNang = ChucNang;
            clsNhatky.MoTa = MoTa;
            clsNhatky.DuongDanFile = Application.StartupPath; 
            clsNhatky.LuuNhatKyNguoiDung();
        }
        private void btnInBC_Click(object sender, EventArgs e)
        {
            ctrInThongBaoCapGCN_Load();
        }

        private void CtrKhongDuDKCapGCN_Load(object sender, EventArgs e)
        {

        }
    }
}
