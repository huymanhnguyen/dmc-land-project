using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.Land.ThongTinTiepNhanHoSo
{
    public class clsThongTinTiepNhanHoSo
    {
        private string[] Paras = {"@MaHoSoTiepNhan","@MaHoSoCapGCN","@SoHoSoTiepNhan"
            , "@ThuTuTiepNhan", "@ThoiDiemTiepNhan", "@NgayNhanDuHoSo", "@NoiNhanHoSo"
            ,"TenNguoiTiepNhan","TenNguoiDiKeKhai","@QuanHe","CMTNguoiDiKeKhai","@NgayCap","@NoiCap","SoDienThoaiNguoiDiKeKhai"
            ,"DiaChiNguoiDiKeKhai","NguoiVietDon","ThoiDiemVietDon","@isChu_NguoiDaiDien","@DinhDanh","@MaNguonHoSo"};
        private string[] Para = { "@Flag", "@MaHoSoCapGCN","@MaDonViHanhChinh" };
        private string[] ParaTrangThai = { "@MaHoSoCapGCN" };
        private string  strConnection  = ""; /* Khai báo biến nhận chuỗi kết nối Database */
        private string  strError = "";  /* Khai bao bien kiem tra loi  */
        private string strMaHoSoTiepNhan;
        private long longMaHoSoCapGCN = 0;
        private long  longSoHoSoTiepNhan = 0;
        private long   longThuTuTiepNhan = 0;
        private string  dtmThoiDiemTiepNhan = null;
        private string  dtmNgayNhanDuHoSo = null ;
        private string  strNoiNhanHoSo = null;
        private string  strTenNguoiTiepNhan	= null;
        private string  strTenNguoiDiKeKhai	= null;
        private string  strCMTNguoiDiKeKhai	= null;
        private string  strSoDienThoaiNguoiDiKeKhai	= null;
        private string  strDiaChiNguoiDiKeKhai	= null;
        private string  strNguoiVietDon	= null;
        private string dtpThoiDiemVietDon = null;
        private string strQuanHe = null;
        private string strNgayCap = null;
        private string strisChu_NguoiDaiDien = null;
        private string strMaDonViHanhChinh = null;
        private string strDinhDanh = null;
        private string strMaNguonHoSo = null;

        public string MaNguonHoSo
        {
            get { return strMaNguonHoSo; }
            set { strMaNguonHoSo = value; }
        }
        public string DinhDanh
        {
            get { return strDinhDanh; }
            set { strDinhDanh = value; }
        }
        public string MaDonViHanhChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
        }
    
        public string IsChu_NguoiDaiDien
        {
            get { return strisChu_NguoiDaiDien; }
            set { strisChu_NguoiDaiDien = value; }
        }


        public string NgayCap
        {
            get { return strNgayCap; }
            set { strNgayCap = value; }
        }
        private string strNoiCap = null;

        public string NoiCap
        {
            get { return strNoiCap; }
            set { strNoiCap = value; }
        }
        public string QuanHe
        {
            get { return strQuanHe; }
            set { strQuanHe = value; }
        }
        /* Khai báo thuộc tính nhận chuỗi kết nối Database */
        public string  Connection
        {
            set {strConnection = value ;}
        }
        /* Khai báo thuộc tính ứng với biến lỗi */
        public string  Err
        {
            get {return strError ;}
        }
        /* Khai báo thuộc tính Mã hồ sơ tiếp nhận */
        public string MaHoSoTiepNhan
        {
            get
            {
                return strMaHoSoTiepNhan;
            }
            set
            {
                strMaHoSoTiepNhan = value;
            }
        }

      
        /* Khai báo thuộc tính ứng với biến Mã hồ sơ cấp GCN */
        public long   MaHoSoCapGCN
        {
            get
            {
                return longMaHoSoCapGCN;
            }
            set
            {
                longMaHoSoCapGCN = value;
            }
        }


        /* Khai báo thuộc tính số Hồ sơ */
        public long SoHoSoTiepNhan
        {
            get
            {
                return longSoHoSoTiepNhan ;
            }
            set
            {
                longSoHoSoTiepNhan = value;
            }
        }
        /* Khai báo thuộc tính số Thứ tự hồ sơ */
        public long ThuTuTiepNhan
        {
            get
            {
                return longThuTuTiepNhan ;
            }
            set
            {
                longThuTuTiepNhan = value;
            }
        }
        /* Khai báo thuộc tính Thời gian tiếp nhận */
        public string  ThoiDiemTiepNhan
        {
            get
            {
                return dtmThoiDiemTiepNhan ;
            }
            set
            {
                dtmThoiDiemTiepNhan  = value;
            }
        }
        /* Khai báo thuộc tính Ngày nhận đủ hồ sơ */
        public string  NgayNhanDuHoSo
        {
            get
            {
                return dtmNgayNhanDuHoSo;
            }
            set
            {
                dtmNgayNhanDuHoSo = value;
            }
        }
        /* Khai báo thuộc tính Nơi nhận hồ sơ */
        public string  NoiNhanDuHoSo
        {
            get
            {
                return strNoiNhanHoSo ;
            }
            set
            {
                strNoiNhanHoSo  = value;
            }
        }

        /* Khai báo thuộc tính Nơi nhận hồ sơ */
        public string  TenNguoiTiepNhan
        {
            get
            {
                return strTenNguoiTiepNhan ;
            }
            set
            {
                strTenNguoiTiepNhan  = value;
            }
        }
	
        /* Khai báo thuộc tính Nơi nhận hồ sơ */
        public string  TenNguoiDiKeKhai
        {
            get
            {
                return strTenNguoiDiKeKhai ;
            }
            set
            {
                strTenNguoiDiKeKhai  = value;
            }
        }
	
        /* Khai báo thuộc tính Nơi nhận hồ sơ */
        public string  CMTNguoiDiKeKhai
        {
            get
            {
                return strCMTNguoiDiKeKhai ;
            }
            set
            {
                strCMTNguoiDiKeKhai  = value;
            }
        }
	
        /* Khai báo thuộc tính Nơi nhận hồ sơ */
        public string  SoDienThoaiNguoiDiKeKhai
        {
            get
            {
                return strSoDienThoaiNguoiDiKeKhai;
            }
            set
            {
                strSoDienThoaiNguoiDiKeKhai  = value;
            }
        }
	
        /* Khai báo thuộc tính Nơi nhận hồ sơ */
        public string  DiaChiNguoiDiKeKhai
        {
            get
            {
                return strDiaChiNguoiDiKeKhai ;
            }
            set
            {
                strDiaChiNguoiDiKeKhai  = value;
            }
        }
	
        /* Khai báo thuộc tính Nơi nhận hồ sơ */
        public string  NguoiVietDon
        {
            get
            {
                return strNguoiVietDon ;
            }
            set
            {
                strNguoiVietDon  = value;
            }
        }
        /* Khai báo thuộc tính Nơi nhận hồ sơ */
        public string ThoiDiemVietDon
        {
            get
            {
                return dtpThoiDiemVietDon;
            }
            set
            {
                dtpThoiDiemVietDon  = value;
            }
        }


        /// <summary>
        /// Thêm mới thông tin tiếp nhận Hồ sơ bởi Mã hồ sơ cấp GCN
        /// </summary>
        /// <param name="strRecords"></param>
        /// <returns></returns>
        public string InsertThongTinTiepNhanByMaHoSoCapGCN(string strRecords)
        {
            return this.Execute("spInsertThongTinTiepNhanByMaHoSoCapGCN", strRecords);
        }

        /// <summary>
        /// Cập nhật thông tin tiếp nhận Hồ sơ bởi Mã hồ sơ cấp GCN
        /// </summary>
        /// <param name="strRecords"></param>
        /// <returns></returns>
        public string UpdateThongTinTiepNhanByMaHoSoCapGCN(string strRecords)
        {
            return this.Execute("spUpdateThongTinTiepNhanByMaHoSoCapGCN", strRecords);
        }

        /// <summary>
        /// Xóa thông tin tiếp nhận Hồ sơ cấp GCN bởi Mã Hồ sơ cấp GCN
        /// </summary>
        /// <param name="strRecords"></param>
        /// <returns></returns>
        public string DeleteThongTinTiepNhanByMaHoSoCapGCN(string strRecords)
        {
            return this.Execute("spDeleteThongTinTiepNhanByMaHoSoCapGCN", strRecords);
        }

        /// <summary>
        /// Hàm thực thi thủ tục SQL
        /// </summary>
        /// <param name="strStoreProcedureName">Tên thủ tục SQL cần thực thi</param>
        /// <param name="strRecords"></param>
        /// <returns></returns>
        private  string  Execute(string strStoreProcedureName ,string  strRecords )
        {
            try
            {
                /* Khai báo và khởi tạo lớp thao tác cơ sở dữ liệu */
                DMC.Database.clsDatabase  Database = new DMC.Database.clsDatabase();
                /* Nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                /*  Nếu kết nối cơ sở dữ liệu thành công */
                if  (Database.OpenConnection() == true )
                { 
                    /* Khai báo mảng giá trị */
                    string[] Values = {strMaHoSoTiepNhan , longMaHoSoCapGCN.ToString(),longSoHoSoTiepNhan.ToString()
                        , longThuTuTiepNhan.ToString(),dtmThoiDiemTiepNhan,dtmNgayNhanDuHoSo,strNoiNhanHoSo
                        ,strTenNguoiTiepNhan,strTenNguoiDiKeKhai,strQuanHe ,strCMTNguoiDiKeKhai,strNgayCap,strNoiCap ,strSoDienThoaiNguoiDiKeKhai
                        ,strDiaChiNguoiDiKeKhai,strNguoiVietDon,dtpThoiDiemVietDon,strisChu_NguoiDaiDien ,strDinhDanh,strMaNguonHoSo};
                    /* Chắc chắn rằng số tham biến bằng số tham trị */
                    if (Paras.Length != Values.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Giá trị truyền vào không tương thích", "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return "Giá trị truyền vào không tương thích";
                    }
                    /* Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase */
                    Database.ExecuteSP(strStoreProcedureName , Paras, Values,ref strRecords);
                    strError = Database.Err;
                    Database.CloseConnection();
                }
            }
            catch ( Exception ex )
            {
                strError = ex.Message;
            }
            return strError;
        }

        private string ExecuteTrangThai(string strStoreProcedureName, string Records)
        {
            try
            {
                DMC.Database.clsDatabase Database = new DMC.Database.clsDatabase();
                Database.Connection = strConnection;
                if (Database.OpenConnection() == true)
                {
                    string[] Values = { "1", longMaHoSoCapGCN.ToString(),strMaDonViHanhChinh};
                    if (Para.Length != Values.Length)
                    {

                        System.Windows.Forms.MessageBox.Show("Giá trị truyền vào không tương thích", "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return "Giá trị truyền vào không tương thích";
                    }
                    Database.ExecuteSP(strStoreProcedureName, Para, Values, ref Records);
                    strError = Database.Err;
                    Database.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return strError;
        }

        public string UpdateTrangThaiHoSoCapGCN(string strRecords)
        {
            return this.ExecuteTrangThai("spUpdateTrangThaiHoSoCapGCN", strRecords);
        }

        /// <summary>
        /// Hàm nhận kết quả truy vấn
        /// </summary>
        /// <param name="dtResults"> Tên bảng kết quả truy vấn nhận được </param>
        /// <returns></returns>
        public string  GetData(System.Data.DataTable  dtResults)
        {
            try
            {
                /*  Khởi tạo đối tượng clsDatabase */
                DMC.Database.clsDatabase  Database = new DMC.Database.clsDatabase();
                /* Khai báo nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                /* Nếu kết nối thành công */
                if  (Database.OpenConnection() == true )
                {
                    /* Neu ket noi co so du lieu thanh cong */
                    /* Khai báo mảng giá trị */
                    string[] Values = {strMaHoSoTiepNhan , longMaHoSoCapGCN.ToString(),longSoHoSoTiepNhan.ToString()
                        , longThuTuTiepNhan.ToString(),dtmThoiDiemTiepNhan,dtmNgayNhanDuHoSo,strNoiNhanHoSo
                        ,strTenNguoiTiepNhan,strTenNguoiDiKeKhai,strQuanHe ,strCMTNguoiDiKeKhai,strNgayCap,strNoiCap ,strSoDienThoaiNguoiDiKeKhai
                        ,strDiaChiNguoiDiKeKhai,strNguoiVietDon,dtpThoiDiemVietDon,strisChu_NguoiDaiDien,strDinhDanh,strMaNguonHoSo};                    /* Chắc chắn rằng số tham biến bằng số tham trị */
                    if (Paras.Length != Values.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Giá trị truyền vào không tương thích", "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return "Giá trị truyền vào không tương thích";
                    }
                    /* Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase */
                    Database.getValue(ref dtResults, "spSelectThongTinTiepNhanHoSoByMaHoSoCapGCN", Paras, Values);
                    Database.CloseConnection();
                    strError = "";
                }
            }
            catch ( Exception ex)
            {
                strError = ex.Message;
            }
            return strError;
        }

        /*Phuong thuc hien thi trang thai Tiep Nhan Ho So*/

        public string GetTrangThaiTiepNhanHS(System.Data.DataTable dtResult)
        {
            try
            {
                DMC.Database.clsDatabase DataBase = new DMC.Database.clsDatabase();
                DataBase.Connection = strConnection;
                if (DataBase.OpenConnection() == true)
                {
                    string[] ValuesTrangThaiTiepNhan={longMaHoSoCapGCN.ToString()};
                    if(ParaTrangThai.Length !=ValuesTrangThaiTiepNhan.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Giá trị truyền vào không tương thích", "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return "Giá trị truyền vào không tương thích";
                    }
                    DataBase.getValue(ref dtResult,"spSelectTrangThaiTiepNhanHoSoCapGCN",ParaTrangThai,ValuesTrangThaiTiepNhan);
                    DataBase.CloseConnection();
                    strError="";
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return strError;
        }
        public string GetNguonCapHoSo(System.Data.DataTable dtResult)
        {
            try
            {
                DMC.Database.clsDatabase DataBase = new DMC.Database.clsDatabase();
                DataBase.Connection = strConnection;
                if (DataBase.OpenConnection() == true)
                {
                    string[] ParasNguonHS = { "@flag" };
                    string[] ValuesNguonHS = { "0" };
                    if (ParasNguonHS.Length != ValuesNguonHS.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Giá trị truyền vào không tương thích", "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return "Giá trị truyền vào không tương thích";
                    }
                    DataBase.getValue(ref dtResult, "spNguonChuyenHoSo", ParasNguonHS, ValuesNguonHS);
                    DataBase.CloseConnection();
                    strError = "";
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return strError;
        }

        public System.Data.DataTable KtraCMD()  {
            System.Data.DataTable   dt = new  System.Data.DataTable();
            //String [] para  = {"@flag", "@CMT", "@CMT2"};
            //String [] value  = {strFlag, strSoDinhDanh, strSoDinhDanh2} ;
            //Database.getValue(ref dtResults, "spSelectKeyChuSuDung", para, value);
            //Database.CloseConnection();
            //strError = "";
            return dt;
        }
    }
}
