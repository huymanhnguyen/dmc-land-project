using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjToTrinhQuyetDinh
{
    public partial class ctrToTrinhQuyetDinh : UserControl
    {
        private string strConnection = "";
        private string strMaHoSoCapGCN = "";
        private string  strMaDVHC="";
        private string[] strTenMaDVHC;
        /* Nghĩa vụ tài chính */
        private string strNghiaVuTaiChinh = "";

        public string Connection {
            set { strConnection = value; }
            get { return  strConnection; }
        }
        public string MaHoSoCapGCN
        {
            set { strMaHoSoCapGCN= value; }
            get { return strMaHoSoCapGCN ; }
        }
        public string  MaDVHC
        {
            set { strMaDVHC  = value; }
            get { return strMaDVHC; }
        }
        public string[] TenMaDVHC
        {
            set { strTenMaDVHC = value; }
            get { return strTenMaDVHC; }
        }
        public ctrToTrinhQuyetDinh()
        {
            InitializeComponent();
        }

        public void LoadThongTinToTrinh() {
            try
            {
                if (strConnection != "")
                {
                    clsToTrinhQuyetDinh cls = new clsToTrinhQuyetDinh();
                    cls.Connection = strConnection;
                    cls.MaHoSoCapGCN = strMaHoSoCapGCN;
                    DataTable dtHoSo = new DataTable();
                    dtHoSo = cls.SelectThongTinDatNhaO();
                    if (dtHoSo.Rows.Count > 0)
                    {
                        txtSoToTrinh.Text = dtHoSo.Rows[0]["ToTrinhPhuong"].ToString();
                        if (dtHoSo.Rows[0]["NgayTrinhPhuong"].ToString() != "")
                        {
                            dtpNgayTrinh.Value = Convert.ToDateTime(dtHoSo.Rows[0]["NgayTrinhPhuong"].ToString());
                        }
                        else
                        {
                            dtpNgayTrinh.Value = DateTime.Now;
                        }
                        strNghiaVuTaiChinh = dtHoSo.Rows[0]["NghiaVuTaiChinh"].ToString();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Tờ trình phường " + ex.Message);
            }
        }

        public string ChuSuDung()
        {
            clsToTrinhQuyetDinh cls = new clsToTrinhQuyetDinh();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            DataTable dt = new DataTable();
            DataTable dtHoSo = new DataTable();
            dt = cls.SelectChuHoSoCapGCN();
            dtHoSo = cls.SelectThongTinDatNhaO();
            string str = "";
            if (dt.Rows.Count > 0)
            {
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["GioiTinh"].ToString() == "True")
                    {
                        if (i == 0)
                        {
                            str = str + " ông " + dt.Rows[i]["hoten"];
                        }
                        else
                        {
                            str = str + " và ông " + dt.Rows[i]["hoten"];
                        }
                    }
                    else{
                        if (i==0){
                             str = str + " bà " + dt.Rows[i]["hoten"];
                        }else{
                            str = str + " và bà " + dt.Rows[i]["hoten"];
                        }
                    }
                }
            }
            if (dtHoSo.Rows.Count > 0)
            {
                
                        str =  str + " tại " + dtHoSo.Rows[0]["DiaChiThua"];
                   
            }
            return str;
        }
        public string ChuSoHuu()
        {
            clsToTrinhQuyetDinh cls = new clsToTrinhQuyetDinh();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            DataTable dt = new DataTable();
            DataTable dtHoSo = new DataTable();
            dt = cls.SelectChuHoSoCapGCN();
            dtHoSo = cls.SelectThongTinDatNhaO();
            string str = "";
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        str += " "; //+ dt.Rows[i]["HoTen"];
                    }
                    else
                    {
                        str += " ,";// +dt.Rows[i]["HoTen"];
                    }
                    str = str + dt.Rows[i]["QuanHe"] + " " + dt.Rows[i]["HoTen"];
                }
            }
           
            return str;
        }
        //lay thong tin ve phuong, quan, thanh pho
            public string [] DonViHanhChinh()
            {
              clsToTrinhQuyetDinh cls =new clsToTrinhQuyetDinh();
                cls.Connection = strConnection;
                cls.MaDVHC = strMaDVHC;
                DataTable dtDVHC = new  DataTable();
                dtDVHC = cls.SelectDVHC();
                string [] arrMangGiaTriDVHC=new string [3] ;
                if  (dtDVHC.Rows.Count > 0 ){
                    arrMangGiaTriDVHC[0] = dtDVHC.Rows[0]["Ten"].ToString();
                    arrMangGiaTriDVHC[1] = dtDVHC.Rows[0]["TenHuyen"].ToString();
                    arrMangGiaTriDVHC[2] = dtDVHC.Rows[0]["TenTinh"].ToString();
                }
                return arrMangGiaTriDVHC;
            }
        private void cmdToTrinh_Click(object sender, EventArgs e)
        {
            string[] DVHC = new string[3];
            DVHC = DonViHanhChinh();
            frmToTrinh frm = new frmToTrinh();
            frm.Connection = strConnection ;
            frm.MaHoSoCapGCN = strMaHoSoCapGCN ;
            frm.TenMaDVHC = DVHC;
            frm.ChuSuDung = ChuSuDung();
            frm.SoToTrinh = txtSoToTrinh.Text.Trim();
            frm.NgayTrinh = dtpNgayTrinh.Value;
            frm.NguoiKyTrinh = txtNguoiTrinhKy.Text.Trim();
            /* Nghĩa vụ tài chính */
            frm.NghiaVuTaiChinh = strNghiaVuTaiChinh;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized; 
            frm.Show();
        }

        private void cmdQuyetDinh_Click(object sender, EventArgs e)
        {
            string[] DVHC = new string[3];
            DVHC = DonViHanhChinh();
            frmQuyetDinh frm = new frmQuyetDinh();
            frm.Connection = strConnection;
            frm.MaHoSoCapGCN = strMaHoSoCapGCN;
            frm.TenMaDVHC = DVHC;
            frm.ChuSuDung = ChuSuDung();
            frm.SoToTrinh = txtSoToTrinh.Text.Trim();
            frm.NgayQuyetDinh = dtpNgayQuyetDinh.Value;
            frm.NgayTrinh = dtpNgayTrinh.Value.Day.ToString() + "/" + dtpNgayTrinh.Value.Month.ToString() + "/" + dtpNgayTrinh.Value.Year.ToString() ;
            frm.ChuSoHuu = ChuSoHuu();
            frm.NguoiKyQuyetDinh = txtNguoiQuyetDinhKy.Text.Trim();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized; 
            frm.Show();
        }

        private void ctrToTrinhQuyetDinh_Load(object sender, EventArgs e)
        {
            LoadThongTinToTrinh();
            this.dtpNgayQuyetDinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayQuyetDinh.Format = DateTimePickerFormat.Custom;
            //this.dtpNgayQuyetDinh.ShowCheckBox = true;
            this.dtpNgayTrinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayTrinh.Format = DateTimePickerFormat.Custom;
           // this.dtpNgayTrinh.ShowCheckBox = true;
        }

        private void dtpNgayQuyetDinh_ValueChanged(object sender, EventArgs e)
        {

        }
        //jd3t2-qh36r-x7w2w-7r3xt-dvrpq
    }
}
