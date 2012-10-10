using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DMC.Database;
using System.Windows.Forms;
using System.Xml;
namespace prjBienDong
{
    class clsDangKyBienDong
    {

        private string[] strParas = {"@MaDangKyBienDong","@MaThuaDat", "@MaHoSoCapGCN", "@MaCoQuanChinhLyGCN", "@ThuTuHoSoBienDong"
            , "@MaLoaiBienDong", "@ThoiDiemDangKy", "@LoaiThoiHanBienDong", "@NgayBatDau", "@NgayKetThuc"
            , "@NoidungSoDiaChinh", "@NoidungSoBienDong", "@NoiDungSoMucKe","@NoiDungSoCapGCN"
            , "@NoiDungMatBonGCN", "@TenNguoiDangKy", "@SoCMTNguoiDangKy", "@DiaChiNguoiDangKy", "@HoanTatDangKyBienDong","@Chon","@MatInbienDong","@LoaiBienDong",
"@NoiDungDat","@DienTich","@MaChu","@SoHopDong","@NgayHopDong" ,"@CoQuanCongChung","@Ghichu","@DienTichRieng","@DienTichChung","@InNguoiNhanINMatIGCN","@DienTichChuyenDich","@ViTriIn","@QuyenSDD","@TaiSanGanDat"	,"@TaiSanVaDat", "@TheChap", "@BaoLanh" ,"@BDToanPhan","@BDMotPhan","@SoCongChung","@NgayCongChung","@NguoiTheChap","@SoDinhDanh"	,"@NgayCap","@DiaChi"};

        private string[] Paras = { "@Flag", "@MaHoSoCapGCN" };

        private    string  strConnection  = "";// Khai báo biến nhận chuỗi kết nối Database
        private    string  strError;  /* Khai báo biến kiểm tra lỗi */
        private    string  strMaDangKyBienDong;
        private    string  strMaHoSoCapGCN;
        private    string  strMaCoQuanChinhLyGCN;
        private    string  intThuTuHoSoBienDong ;
        private    string  strMaLoaiBienDong;
        private    string  dtmThoiDiemDangKy;
        private    string  blnLoaiThoiHanBienDong;
        private    string  dtmNgayBatDau;
        private    string  dtmNgayKetThuc;
        private    string  strNoidungSoDiaChinh;
        private    string  strNoidungSoBienDong ;
        private    string  strNoiDungSoMucKe ;
        private    string  strNoiDungSoCapGCN ;
        private    string  strNoiDungMatBonGCN ;
        private    string  strTenNguoiDangKy ;
        private    string  strSoCMTNguoiDangKy ;
        private    string  strDiaChiNguoiDangKy ;
        private    string  blnHoanTatDangKyBienDong ;
        private    string  blnChon;
        private string blnChonInMat;
        private string strMaThuaDat;
        private Int32 MaNguoiDKBDTC;
        private string strHoTenNguoiNhanTC;
        private string  strDiaChiNhanTC;
        private string   SoCMND;
        private string strGhiChuTC;
        private string  strquyenSDD  ;
        private string strtaSanGanDat  ;
        private string strtaiSanVaDat  ;
        private string strSoCongChung;
        private string strNgayCongChung;
        private string strTheChap ;
        private string strBaoLanh ;
        private string strSoHopDong;
        private string strNgayHopDong;

        private string strSoDinhDanhNguoiTC = "";

        public string SoDinhDanhNguoiTC
        {
            get { return strSoDinhDanhNguoiTC; }
            set { strSoDinhDanhNguoiTC = value; }
        }

        private string strNgayCapSoDinhDanhTC = "";

        public string NgayCapSoDinhDanhTC
        {
            get { return strNgayCapSoDinhDanhTC; }
            set { strNgayCapSoDinhDanhTC = value; }
        }

        private string strDiaChiNguoiTheChap = "";

        public string DiaChiNguoiTheChap
        {
            get { return strDiaChiNguoiTheChap; }
            set { strDiaChiNguoiTheChap = value; }
        }

        private string strBDToanPhan = "";

        public string BDToanPhan
        {
            get { return strBDToanPhan; }
            set { strBDToanPhan = value; }
        }
        private string strBDMotPhan = "";

        public string BDMotPhan
        {
            get { return strBDMotPhan; }
            set { strBDMotPhan = value; }
        }

        private string strInNguoiNhanINMatIGCN = "0";

        private string strDienTichChuyenDich = "";

        public string DienTichChuyenDich
        {
            get { return strDienTichChuyenDich; }
            set { strDienTichChuyenDich = value; }
        }


        private string strViTriIn = "0";

        public string ViTriIn
        {
            get { return strViTriIn; }
            set { strViTriIn = value; }
        }
        public string InNguoiNhanINMatIGCN {
            get { return strInNguoiNhanINMatIGCN;}
            set { strInNguoiNhanINMatIGCN=value;}
        }

        public string  SoHopDong
        {
            get { return strSoHopDong; }
            set { strSoHopDong = value; }
         }
        public string NgayHopDong
        {
            get { return strNgayHopDong; }
            set { strNgayHopDong = value; }
          }
        private string strSoHopDongTC;
        private string strNgayHopDongTC;

        public string SoHopDongTC
        {
            get { return strSoHopDongTC ; }
            set { strSoHopDongTC   = value; }
        }
        public string NgayHopDongTC
        {
            get { return strNgayHopDongTC ; }
            set { strNgayHopDongTC  = value; }
        }
        public string  TheChap
        {
            get { return strTheChap; }
            set { strTheChap = value; }
        }
        public string BaoLanh
        {
            get { return strBaoLanh; }
            set { strBaoLanh = value; }
        }
        public string SoCongChung
        {
            get
            { return strSoCongChung ; }
            set { strSoCongChung = value; }
        }
        public string NgayCongChung
        {
            get
            { return strNgayCongChung ; }
            set { strNgayCongChung = value; }
        }
        public string HoTenNhanTC
        {
            get
            { return strHoTenNguoiNhanTC; }
            set { strHoTenNguoiNhanTC = value; }
          }
        public string DiaChiNhanTC
        {
            get { return strDiaChiNhanTC ; }
            set { strDiaChiNhanTC = value; }
          }
        public string CMTTC
        {
            get { return SoCMND; }
            set { SoCMND = value; }
          }
       
        public Int32 MaDKBDTC
        {
            set { MaNguoiDKBDTC = value; }
            get { return MaNguoiDKBDTC; }
         }

        public string GhiChuNguoiTC
        {
            set { strGhiChuTC = value; }
            get {return  strGhiChuTC; }
           }
        public string  QuyenSDD
        {
            set { strquyenSDD = value; }
            get { return strquyenSDD; }
           }

        public string  TaiSanGanDat
        {
            set { strtaSanGanDat = value; }
            get { return  strtaSanGanDat; }
           }
        public string  TaiSanVaDat
        {
            get {return  strtaiSanVaDat; }
            set { strtaiSanVaDat = value; }
          }


        private string strLoaiBienDong = "";

        private string strGhiChu = "";

        public string GhiChu
        {
            get { return strGhiChu; }
            set { strGhiChu = value; }
        }

        public string LoaiBienDong
        {
            get { return strLoaiBienDong; }
            set { strLoaiBienDong = value; }
        }
        private string strNoiDungDat = "";

        public string NoiDungDat
        {
            get { return strNoiDungDat; }
            set { strNoiDungDat = value; }
        }
        private string strDienTich = "0";

        public string DienTich
        {
            get { return strDienTich; }
            set { strDienTich = value; }
        }
        private string strDienTichRieng = "0";
        public string DienTichRieng
        {
            get { return strDienTichRieng = "0"; }
            set { strDienTichRieng = value; }
          }
        private string strDienTichChung = "0";
        public string DienTichChung
        {
            get { return strDienTichChung; }
            set { strDienTichChung = value; }
         }
        private string  xmlMaChu="";

        public string  MaChu
        {
            get { return xmlMaChu; }
            set { xmlMaChu = value; }
        }
       
        private string strCoQuanCongChung = "";

        public string CoQuanCongChung
        {
            get { return strCoQuanCongChung; }
            set { strCoQuanCongChung = value; }
        }

        public string MaThuaDat
        {
            get { return strMaThuaDat; }
            set { strMaThuaDat = value; }
        }
        private string strFlag;

        public string Flag
        {
            get
            {
                return strFlag;
            }
            set
            {
                strFlag = value;
            }
        }

        public string Chon
        {
            get { return blnChon; }
            set { blnChon = value; }
        }
        public string ChonInMat
        {
            get { return blnChonInMat ; }
            set { blnChonInMat  = value; }
        }
        //Khai báo thuộc tính nhận chuỗi kết nối Database
        public string Connection
        {
            set {strConnection = value;}
        }
         //Khai báo thuộc tính đọc lỗi
        public string  Err
        {
            get { return strError;}
        }
        //Khai bao thuoc tinh ung voi bien shFlag
        public string MaDangKyBienDong
        {
            get {return strMaDangKyBienDong;}
            set {strMaDangKyBienDong = value;}
         }
        //Khai bao thuoc tinh ung voi bien 
        public  string  MaHoSoCapGCN
        {
            get{return strMaHoSoCapGCN;}
            set{strMaHoSoCapGCN = value;}
        }

        public  string  MaCoQuanChinhLyGCN
        {
            set {strMaCoQuanChinhLyGCN = value;}
            get {return strMaCoQuanChinhLyGCN;}
        }

        public string   ThuTuHoSoBienDong
        {
            get{return intThuTuHoSoBienDong;}
            set{intThuTuHoSoBienDong = value;}
         }

        public  string  MaLoaiBienDong
        {
            get{return strMaLoaiBienDong;}
            set{strMaLoaiBienDong = value;}
        }
        public string   ThoiDiemDangKy
        {
           get{return dtmThoiDiemDangKy;}
           set{dtmThoiDiemDangKy = value;}
        }

        public  string  LoaiThoiHanBienDong
        {
            get{return blnLoaiThoiHanBienDong;}
            set{blnLoaiThoiHanBienDong = value;}
        }
        public  string  NgayBatDau
        {
            get{return dtmNgayBatDau;}
            set{dtmNgayBatDau = value;}
        }
        public  string  NgayKetThuc
        {
            get{return dtmNgayKetThuc;}
            set{dtmNgayKetThuc = value;}
        }
        public  string  NoidungSoDiaChinh
        {
            get{return strNoidungSoDiaChinh;}
            set{strNoidungSoDiaChinh = value;}
        }
        public  string  NoidungSoBienDong
        {
            get{return strNoidungSoBienDong;}
            set{strNoidungSoBienDong = value;}
        }
        public  string  NoiDungSoMucKe
        {
            get{return strNoiDungSoMucKe  ;}
            set{strNoiDungSoMucKe = value;}
        }
        public  string  NoiDungSoCapGCN
        {
            get{return strNoiDungSoCapGCN;}
            set{strNoiDungSoCapGCN = value;}
        }
        public  string  NoiDungMatBonGCN
        {
            get{return strNoiDungMatBonGCN;}
            set{strNoiDungMatBonGCN = value;}
        }
        public  string  TenNguoiDangKy
        {
            get{return strTenNguoiDangKy;}
            set{strTenNguoiDangKy = value;}
        }
        public  string  SoCMTNguoiDangKy
        {
            get{return strSoCMTNguoiDangKy;}
            set{strSoCMTNguoiDangKy = value;}
        }
        public  string  DiaChiNguoiDangKy
        {
            get{return strDiaChiNguoiDangKy;}
            set{strDiaChiNguoiDangKy = value;}
        }
        public  string  HoanTatDangKyBienDong
        {
            get{return blnHoanTatDangKyBienDong;}
            set{blnHoanTatDangKyBienDong = value;}
        }

        /// <summary>
        /// Thêm mới thông tin Đăng ký biến động
        /// </summary>
        public void InsertDangKyBienDong(ref string strRecord)
        {
           this.Execute ("spInsertDangKyBienDongByMaHoSoCapGCN",ref  strRecord );
           this.UpdateStausMaHoSoCapGCN("");
        }
        // thêm mới vào thông tin thế chấp

        public void InsertTheChap(ref string strRecord)
        {
            this.ExecuteDKTC("SP_InsetTheChap", ref  strRecord);
           
        }

        public void UpdateTheChap(ref string strRecord)
        {
            this.ExecuteDKTC("SP_updateTheChap", ref  strRecord);

        }
        public void DeleteTheChap(ref string strRecord)
        {
            this.ExecuteDKTC("SP_DeleteTheChap", ref  strRecord);

        }
      

        public DataTable GetSP_TheChap(string strStoreProcedureName)
        {
            DataTable Mytable = new DataTable();
            clsDatabase Database = new clsDatabase();
            /* Nhận chuỗi kết nối Database */

            Database.Connection = strConnection;
            string[] strParas = { "@MaDangKyBienDong "};
            string[] strValues = { MaNguoiDKBDTC.ToString () };

            if (Database.OpenConnection())
            {
                Database.getValue(ref Mytable, strStoreProcedureName, strParas, strValues);
                Database.CloseConnection();

            }
            else
            {
                MessageBox.Show("lỗi kết nôi CSDL ");
            }
            return Mytable;
        }


        /// <summary>
        /// Xóa thông tin đăng ký biến động theo Mã Đăng ký biến động
        /// </summary>
        public void DeleteDangKyBienDongByMaDangKyBienDong(ref string strRecord)
        {
           this.Execute("spDeleteDangKyBienDongByMaDangKyBienDong", ref strRecord);
         
        }

        /// <summary>
        /// Xóa thông tin đăng ký biến động theo Mã hồ sơ cấp GCN
        /// </summary>
        public void DeleteDangKyBienDongByMaHoSoCapGCN(ref string strRecord)
        {
           this.Execute("spDeleteDangKyBienDongByMaHoSoCapGCN", ref strRecord);
            //string strRecords = "";
            //this.Execute("spDeleteDangKyBienDongByMaHoSoCapGCN", ref  strRecords);
        }

        /// <summary>
        /// Xóa thông tin đăng ký biến động theo Mã thông tin đăng ký biến động
        /// </summary>
        public void UpdateDangKyBienDongByMaDangKyBienDong(ref string strRecord)
        {
           this.Execute("spUpdateDangKyBienDongByMaDangKyBienDong", ref strRecord);
           this.UpdateStausMaHoSoCapGCN("");
          
        }

        // Tao phuong thuc cap nhat trang thai ho so cap giay chung nhan
        public void UpdateTrangThaiHSCapGCN(ref string strRecord)
        {
            this.ExcuteTrangThaiHS("spUpdateTrangThaiHoSoCapGCN", ref strRecord);
        }

        /* Phương thức lấy về số thứ tự sổ biến động lớn nhất */

        public DataTable SelectThuTuHoSoBienDongLonNhats()
        {
            /* Khai báo đối tượng clsDatabase */
            clsDatabase Database = new clsDatabase();
            /* Nhận chuỗi kết nối Database */
            Database.Connection = strConnection;
            SqlDataAdapter dapter = new SqlDataAdapter("spSelectThuTuHoSoBienDongLonNhat",strConnection);
            dapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            dapter.Fill(ds, "tblDangKyBienDong");         
            return ds.Tables["tblDangKyBienDong"];
        }

        /// <summary>
        /// Phương thức thực thi cơ sở dữ liệu
        /// </summary>
        /// <param name="strStoreProcedureName">Tên thủ tục SQLServer</param>
        /// <param name="strRecords"></param>
        /// <returns></returns>
        private  string  Execute(string strStoreProcedureName, ref  string  strRecords )
        {
            try
            {
                /* Khai báo đối tượng clsDatabase */
                clsDatabase Database = new clsDatabase();
                /* Nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                /* Nếu kết nối thành công */
                if (Database.OpenConnection())
                {
                    /* Khai báo mảng giá trị */
                    string[] strValues = {MaDangKyBienDong, strMaThuaDat, MaHoSoCapGCN, MaCoQuanChinhLyGCN, ThuTuHoSoBienDong, MaLoaiBienDong 
                    , ThoiDiemDangKy, LoaiThoiHanBienDong, NgayBatDau, NgayKetThuc, NoidungSoDiaChinh, NoidungSoBienDong, NoiDungSoMucKe 
                    , NoiDungSoCapGCN, NoiDungMatBonGCN, TenNguoiDangKy 
                    , SoCMTNguoiDangKy, DiaChiNguoiDangKy, HoanTatDangKyBienDong,Chon,blnChonInMat, strLoaiBienDong ,strNoiDungDat,strDienTich,xmlMaChu,strSoHopDong,strNgayHopDong,strCoQuanCongChung ,strGhiChu ,strDienTichRieng,strDienTichChung ,strInNguoiNhanINMatIGCN ,strDienTichChuyenDich,strViTriIn,strquyenSDD,strtaSanGanDat	,strtaiSanVaDat, strTheChap, strBaoLanh ,strBDToanPhan,strBDMotPhan,strSoCongChung,strNgayCongChung,strHoTenNguoiNhanTC ,strSoDinhDanhNguoiTC	,strNgayCapSoDinhDanhTC,strDiaChiNguoiTheChap  };
                    /* Kiểm tra tính hợp lệ của dữ liệu trước khi thực thi câu lệnh SQL */
                    if (strParas.Length != strValues.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return "Dữ liệu truyền vào chưa hợp lệ";
                    }
                    Database.ExecuteSP(strStoreProcedureName, strParas, strValues, ref  strRecords);
                    strError = Database.Err;
                    Database.CloseConnection();
             }
        }
        catch (Exception ex)
        {
            strError = ex.Message ;
            MessageBox.Show(  " Lỗi khi thực thi đăng ký biến động ");// ,   MessageBoxIcon.Information , "DMCLand");
        }
        return strError;
        }

        /// <summary>
        /// thực thi đăng ký thế chấp
        /// </summary>
        /// <param name="strStoreProcudureName"></param>
        /// <param name="strRecord"></param>
        /// <returns></returns>

        private string ExecuteDKTC(string strStoreProcedureName, ref  string strRecords)
        {
            try
            {
                /* Khai báo đối tượng clsDatabase */
                clsDatabase Database = new clsDatabase();
                /* Nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                /* Nếu kết nối thành công */
                if (Database.OpenConnection())
                {
                    /* Khai báo mảng giá trị */
                    string[] strValueTC = { MaNguoiDKBDTC.ToString (), strHoTenNguoiNhanTC, strDiaChiNhanTC, SoCMND, strGhiChuTC, strquyenSDD.ToString (), strtaSanGanDat.ToString (), strtaiSanVaDat.ToString (),strTheChap .ToString (),strBaoLanh .ToString (),strSoCongChung,strNgayCongChung ,strSoHopDongTC   ,strNgayHopDongTC   };
                    string[] strParaTC ={"@MaDangKyBienDong","@HoTenNguoiNhanTheChap","@DiaChiNguoiNhanTheChap","@SoCMND","@GhiChu","@QuyenSDD","@TaiSanGanDat",
                 "@TaiSanVaDat","@TheChap","@BaoLanh","@SoCongChung","@NgayCongChung","@SoHopDong","@NgayHopDong"};
                    /* Kiểm tra tính hợp lệ của dữ liệu trước khi thực thi câu lệnh SQL */
                    if (strParaTC.Length != strValueTC.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return "Dữ liệu truyền vào chưa hợp lệ";
                    }
                    Database.ExecuteSP(strStoreProcedureName, strParaTC, strValueTC, ref  strRecords);
                    strError = Database.Err;
                    Database.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show(" Lỗi khi thực thi đăng ký thế chấp ");// ,   MessageBoxIcon.Information , "DMCLand");
            }
            return strError;
        } 

        private string ExcuteTrangThaiHS(string strStoreProcudureName, ref string strRecord)
        {
            try
            {
                /* Khai bao va khoi tao doi tuong thao tac voi DataBase */
                clsDatabase DataBase = new clsDatabase();
                // Nhan ve chuoi ket noi
                DataBase.Connection = strConnection;
                if (DataBase.OpenConnection()==true )
                {
                    string[] Values = { strFlag, strMaHoSoCapGCN };
                    if (Paras.Length != Values.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return "Dữ liệu truyền vào chưa hợp lệ";
                    }

                    DataBase.ExecuteSP(strStoreProcudureName, Paras, Values,ref  strRecord);
                    strError = DataBase.Err;
                    DataBase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show(" Đăng ký biến động " + System.Environment.NewLine + " Lỗi: " + ex.Message);// ,   MessageBoxIcon.Information , "DMCLand");
            }
            return strError;

        }

        /// <summary>
        /// Liệt kê thông tin đăng ký biến động
        /// </summary>
        /// <param name="dtRecords"></param>
        /// <returns></returns>
        public string SelectThongTinBienDong(ref System.Data.DataTable dtRecords)
        {
            return this.GetData("spSelectDangKyBienDongByMaHoSoCapGCN", ref dtRecords);
        }
        /// lấy ra mã biến động vừa update
        /// 
        public DataTable GetData_SP(string strStoreProcedureName)
         {   DataTable Mytable = new DataTable ();
              clsDatabase Database = new clsDatabase();
                /* Nhận chuỗi kết nối Database */
             
                Database.Connection = strConnection;
                string [] strParas = new string[0];
                 string [] strValues = new string[0];

              if (Database.OpenConnection())
              {
                  Database.getValue(ref Mytable, strStoreProcedureName, strParas, strValues);
                    Database.CloseConnection();
                    
                }
              else { MessageBox .Show ("lỗi kết nôi CSDL ");
                }
              return Mytable;
         }

        public Int32 SelectMaDangKBD()
        {
            Int32 MaDKBD = 0;
            DataTable dt = new DataTable() ;
            string strStoreProcedureName = "SP_MaDKBD";
            dt = GetData_SP(strStoreProcedureName);
            if (dt.Rows .Count >0 )
            {
                MaDKBD = Convert.ToInt32(dt.Rows[0][0]);
            }
            return MaDKBD;
          
        }
        /// <summary>
        /// Truy vấn thông tin đăng ký biến động
        /// </summary>
        /// <param name="dtRecords"></param>
        /// <returns></returns>
        public string  GetData(string strStoreProcedureName,ref  System.Data.DataTable  dtRecords )
        {
            try
            {
                /* Khai báo đối tượng clsDatabase */
                clsDatabase Database = new clsDatabase();
                /* Nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                //Nếu kết nỗi thành công
                if (Database.OpenConnection())
                {
                     /* khai báo mảng giá trị */
                    string[] strValues = {MaDangKyBienDong, strMaThuaDat, MaHoSoCapGCN, MaCoQuanChinhLyGCN, ThuTuHoSoBienDong, MaLoaiBienDong 
                    , ThoiDiemDangKy, LoaiThoiHanBienDong, NgayBatDau, NgayKetThuc, NoidungSoDiaChinh, NoidungSoBienDong, NoiDungSoMucKe 
                    , NoiDungSoCapGCN, NoiDungMatBonGCN, TenNguoiDangKy 
                    , SoCMTNguoiDangKy, DiaChiNguoiDangKy, HoanTatDangKyBienDong,Chon,blnChonInMat, strLoaiBienDong ,strNoiDungDat,strDienTich,xmlMaChu,strSoHopDong,strNgayHopDong,strCoQuanCongChung ,strGhiChu ,strDienTichRieng,strDienTichChung ,strInNguoiNhanINMatIGCN ,strDienTichChuyenDich,strViTriIn,strquyenSDD,strtaSanGanDat	,strtaiSanVaDat, strTheChap, strBaoLanh ,strBDToanPhan,strBDMotPhan,strSoCongChung,strNgayCongChung,strHoTenNguoiNhanTC ,strSoDinhDanhNguoiTC	,strNgayCapSoDinhDanhTC,strDiaChiNguoiTheChap  };
                    ///* Kiểm tra tính hợp lệ của dữ liệu trước khi thực thi câu lệnh SQL */
                    //if (strParas.Length != strValues.Length)
                    //{
                    //    System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return "Dữ liệu truyền vào chưa hợp lệ";
                    //}
                    Database.getValue(ref dtRecords, strStoreProcedureName, strParas, strValues);
                    Database.CloseConnection();
                    strError = "";
                }
            }
            catch (Exception ex)
            {
                strError = ex.ToString();
               
            }
            return strError;
        }
        ///update trang thai hồ sơ cấp GCN
        ///khi đăng ký biến động cho 1 hồ sơ thì luu hồ sơ đó vào lịch sử 
        ///bằng cách update trang thai (status =0) trong bang hồ sơ cấp GCN
        ///
        public void UpdateStausMaHoSoCapGCN( string strRecord)
        {
           // this.ExcuteStatusHS("spUpdateStatusMaHoSoCapGCN", ref strRecord);
            //string strRecords = "";
            //this.Execute("spDeleteDangKyBienDongByMaHoSoCapGCN", ref  strRecords);
        }
        private string ExcuteStatusHS(string strStoreProcudureName, ref string strRecord)
        {
            try
            {
                string[] paraStatus = { "@MaHoSoCapGCN" };
                /* Khai bao va khoi tao doi tuong thao tac voi DataBase */
                clsDatabase DataBase = new clsDatabase();
                // Nhan ve chuoi ket noi
                DataBase.Connection = strConnection;
                if (DataBase.OpenConnection() == true)
                {
                    string[] Values = { strMaHoSoCapGCN };
                    if (Paras.Length != Values.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return "Dữ liệu truyền vào chưa hợp lệ";
                    }

                    DataBase.ExecuteSP(strStoreProcudureName, paraStatus, Values, ref  strRecord);
                    strError = DataBase.Err;
                    DataBase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show(" Đăng ký biến động " + System.Environment.NewLine + " Lỗi: " + ex.Message);// ,   MessageBoxIcon.Information , "DMCLand");
            }
            return strError;

        }

        public void  SelectThongTinDat(DataTable dt)
        {
            try
            {
                string[] paraThuaDat = { "@MaThuaDat","@MaHoSoCapGCN" };
                /* Khai bao va khoi tao doi tuong thao tac voi DataBase */
                clsDatabase DataBase = new clsDatabase();
                // Nhan ve chuoi ket noi
                DataBase.Connection = strConnection;
                if (DataBase.OpenConnection() == true)
                {
                    string[] ValueThuaDat = { strMaThuaDat , strMaHoSoCapGCN };
                    if (paraThuaDat.Length != ValueThuaDat.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       
                    }
                    DataBase.getValue(ref dt, "spSelectThongTinDatByDangKyBienDong", paraThuaDat, ValueThuaDat);
                    DataBase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show(" Đăng ký biến động " + System.Environment.NewLine + " Lỗi: " + ex.Message);// ,   MessageBoxIcon.Information , "DMCLand");
            }
        }

        public void SelectThongTinChuSuDung(DataTable dt)
        {
            try
            {
                string[] paraThuaDat = { "@MaHoSoCapGCN" };
                /* Khai bao va khoi tao doi tuong thao tac voi DataBase */
                clsDatabase DataBase = new clsDatabase();
                // Nhan ve chuoi ket noi
                DataBase.Connection = strConnection;
                if (DataBase.OpenConnection() == true)
                {
                    string[] ValueThuaDat = {  strMaHoSoCapGCN };
                    if (paraThuaDat.Length != ValueThuaDat.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    DataBase.getValue(ref dt, "spChu", paraThuaDat, ValueThuaDat);
                    DataBase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show(" Đăng ký biến động " + System.Environment.NewLine + " Lỗi: " + ex.Message);// ,   MessageBoxIcon.Information , "DMCLand");
            }
        }

        public void SelThongTinNguoiChuyenNhuong(DataTable dt)
        {
            try
            {
                string[] paraNguoiCN = { "@MaDangKyBienDong"};
                /* Khai bao va khoi tao doi tuong thao tac voi DataBase */
                clsDatabase DataBase = new clsDatabase();
                // Nhan ve chuoi ket noi
                DataBase.Connection = strConnection;
                if (DataBase.OpenConnection() == true)
                {
                    string[] ValuenguoiCN = { strMaDangKyBienDong  };
                    if (paraNguoiCN.Length != ValuenguoiCN.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    DataBase.getValue(ref dt, "spSelectThongTinNguoiChuyenNhuong", paraNguoiCN, ValuenguoiCN);
                    DataBase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show(" Đăng ký biến động " + System.Environment.NewLine + " Lỗi: " + ex.Message);// ,   MessageBoxIcon.Information , "DMCLand");
            }
        }

        public void SelThongTinLoaiBienDong(DataTable dt)
        {
            try
            {
                string[] paraNguoiCN = {};
                /* Khai bao va khoi tao doi tuong thao tac voi DataBase */
                clsDatabase DataBase = new clsDatabase();
                // Nhan ve chuoi ket noi
                DataBase.Connection = strConnection;
                if (DataBase.OpenConnection() == true)
                {
                    string[] ValuenguoiCN = {};
                    if (paraNguoiCN.Length != ValuenguoiCN.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    DataBase.getValue(ref dt, "spSelectLoaiBienDong", paraNguoiCN, ValuenguoiCN);
                    DataBase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show(" Đăng ký biến động " + System.Environment.NewLine + " Lỗi: " + ex.Message);// ,   MessageBoxIcon.Information , "DMCLand");
            }
        }

        public  string  TaoHoSoMoiVoiChuChuyenNhuongMoi( ref string strRecord)
        {
            try
            {
                string[] paraStatus = { "@MaHoSoCapGCN", "@MaDangKyBienDong" };
                /* Khai bao va khoi tao doi tuong thao tac voi DataBase */
                clsDatabase DataBase = new clsDatabase();
                // Nhan ve chuoi ket noi
                DataBase.Connection = strConnection;
                if (DataBase.OpenConnection() == true)
                {
                    string[] Values = { strMaHoSoCapGCN ,strMaDangKyBienDong };
                    if (paraStatus.Length != Values.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return "Dữ liệu truyền vào chưa hợp lệ";
                    }

                    DataBase.ExecuteSP("spTaoHoSoMoiByChuyenNhuong", paraStatus, Values, ref  strRecord);
                    strError = DataBase.Err;
                    DataBase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show(" Tạo hồ sơ " + System.Environment.NewLine + " Lỗi: " + ex.Message);// ,   MessageBoxIcon.Information , "DMCLand");
            }
            return strError;

        }
        public void SelCheckTaoHoSoMoi(DataTable dt)
        {
            try
            {
                string[] paraNguoiCN = { "@flag","@MaDangKyBienDong" };
                /* Khai bao va khoi tao doi tuong thao tac voi DataBase */
                clsDatabase DataBase = new clsDatabase();
                // Nhan ve chuoi ket noi
                DataBase.Connection = strConnection;
                if (DataBase.OpenConnection() == true)
                {
                    string[] ValuenguoiCN = {"0", strMaDangKyBienDong };
                    if (paraNguoiCN.Length != ValuenguoiCN.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    DataBase.getValue(ref dt, "spCheckTaoHoSoChuyenNhuong", paraNguoiCN, ValuenguoiCN);
                    DataBase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show(" Đăng ký biến động " + System.Environment.NewLine + " Lỗi: " + ex.Message);// ,   MessageBoxIcon.Information , "DMCLand");
            }
        }
        public string DaThucHienTaoHoSoMoi(ref string strRecord)
        {
            try
            {
                string[] paraNguoiCN = { "@flag", "@MaDangKyBienDong" };
                /* Khai bao va khoi tao doi tuong thao tac voi DataBase */
                clsDatabase DataBase = new clsDatabase();
                // Nhan ve chuoi ket noi
                DataBase.Connection = strConnection;
                if (DataBase.OpenConnection() == true)
                {
                    string[] ValuenguoiCN = { "1", strMaDangKyBienDong };
                    if (paraNguoiCN.Length != ValuenguoiCN.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return "Dữ liệu truyền vào chưa hợp lệ";
                    }

                    DataBase.ExecuteSP("spCheckTaoHoSoChuyenNhuong", paraNguoiCN, ValuenguoiCN, ref  strRecord);
                    strError = DataBase.Err;
                    DataBase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show(" Tạo hồ sơ " + System.Environment.NewLine + " Lỗi: " + ex.Message);// ,   MessageBoxIcon.Information , "DMCLand");
            }
            return strError;

        }
    }
}
