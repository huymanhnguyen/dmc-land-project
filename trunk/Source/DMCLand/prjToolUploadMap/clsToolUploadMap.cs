using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMC.Database;
using System.Windows.Forms;
using System.Data;
using Microsoft.VisualBasic;
namespace prjToolUploadMap
{
    class clsToolUploadMap
    {
        
        
        private string strError = "";

        private string strMabanDo = "";
        private string strQuiMo="";
        private string strPhamViQuiHoach="";
        private string strThuocPhuong="";
        private string strDonViThucHien="";
        private string strNamPheDuyet="";
        private string strQuyetDinhPheDuyet="";
        private string strTienDo="";
        private string strGhiChu = "";
        private Boolean strDADT = false;
        public Boolean DADT
        {
            get { return strDADT; }
            set { strDADT = value; }
        
        }

        private string strTenTepDuLieuNguon  = "";
        public string TenTepDuLieuNguon
        {
            get { return strTenTepDuLieuNguon; }
            set { strTenTepDuLieuNguon  = value; }
        }

        private string strMaTaiLieuKemTheo = "";
        public string MaTaiLieuKemTheo
        
        {
            get { return strMaTaiLieuKemTheo; }
            set { strMaTaiLieuKemTheo = value.ToString (); }
        }

        private string strMoTa = "";
        public string MoTa
        {
           get { return strMoTa; }
            set { strMoTa = value; } 
            
          }

        private Byte[] strbyteTaiLieu ;
    //Khai báo thuộc tính kiểu mảng Byte nhận Tài liệu
     public Byte[] TaiLieu
     {
         get {return  strbyteTaiLieu ; }
         set { strbyteTaiLieu = value; }
     }
      
        public string QuiMo
        {
            get { return strQuiMo; }
            set { strQuiMo  = value; }
        }
        public string PhamViQuiHoach
        {
            get { return strPhamViQuiHoach ; }
            set { strPhamViQuiHoach  = value; }
        }
        public string ThuocPhuong
        {
            get { return strThuocPhuong; }
            set { strThuocPhuong  = value; }
        }

        public string DonViThucHien
        {
            get { return strDonViThucHien ; }
            set { strDonViThucHien  = value; }
        }

        public string NamPheDuyet
        {
            get { return strNamPheDuyet ; }
            set { strNamPheDuyet  = value; }
        }

        public string QuyetDinhPheDuyet
        {
            get { return strQuyetDinhPheDuyet; }
            set { strQuyetDinhPheDuyet  = value; }
        }
        public string TienDo
        {
            get { return strTienDo; }
            set { strTienDo  = value; }
        }
        public string GhiChu
        {
            get { return strGhiChu ; }
            set { strGhiChu  = value; }
        }
        public string MabanDo
        {
            get { return strMabanDo; }
            set { strMabanDo = value; }
        }
        private string strTenbanDo = "";

        public string TenbanDo
        {
            get { return strTenbanDo; }
            set { strTenbanDo = value; }
        }
        private string strTyLe = "";

        public string TyLe
        {
            get { return strTyLe; }
            set { strTyLe = value; }
        }



        public string Error
        {
            get { return strError; }
            set { strError = value; }
        }
        private string strConnection = "";
        public string Connection
        {
            get { return strConnection; }
            set { strConnection = value; }
        }
        private string strMaDonViHanhChinh = "";
        public string MaDonViHanhChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
        }
        public string strTenDuAn = "";
        public string TenDuAn
        {
            get { return strTenDuAn; }
            set { strTenDuAn = value; }
        }





        // Định nghĩa phương thức thực thị dữ liệu
        public string Execute(string strRecord, string strStoreProcedureName,string[] Paras, string[] Values)
        {
            /* Khởi tạo đối tượng thực thi cơ sở dữ liệu */
            clsDatabase Database = new clsDatabase();
            try
            {
                /* Nếu kết nối thành công */
                Database.Connection = strConnection;
                if (Database.OpenConnection() == true)
                {
                   /* Gọi phương thức ExecuteSP của đối tượng thao tác cơ sở dữ liệu */
                    Database.ExecuteSP(strStoreProcedureName, Paras, Values, ref  strRecord);
                    /* Kiểm tra lỗi phát sinh trong quá trình thực thi với cơ sở dữ liệu */
                    strError = Database.Err;
                    /* Đóng kết nối */
                    Database.CloseConnection();
                    //
                    strError = "";
                }
            }
            catch (Exception ex)
            {
                strError = ex.ToString();
            }
            finally
            {
                /* Đóng kết nối */
                Database.CloseConnection();
            }
            return strError;
        }

 // đọc file
        public byte[] ReadFile(string strPath)
        {
            //Initialize byte array with a null value initially.
            byte[] byteData = null;
            //Use FileInfo object to get file size.
            System.IO.FileInfo fInfo = new System.IO.FileInfo(strPath);
            long numBytes = 0;
            numBytes = fInfo.Length;
            //Open file stream de doc file
            System.IO.FileStream fStream = null;
            fStream = new System.IO.FileStream(strPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //Use BinaryReader to read file stream into byte array.
            System.IO.BinaryReader br = new System.IO.BinaryReader(fStream);
            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            byteData = br.ReadBytes(Convert.ToInt32(numBytes));
            return byteData;
        }
        // save file
        public bool SaveFile(string strSaveFileName, byte[] byteContent)
        {
            System.IO.FileStream objFstream = null;
            try
            {
                objFstream = System.IO.File.Open(strSaveFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                long lngLen = byteContent.Length;
                objFstream.Write(byteContent, 0, Convert.ToInt32(lngLen));
                objFstream.Flush();
                return true;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(" Lỗi ghi dữ liệu: " + Constants.vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand");
                return false;
            }
            finally
            {
                objFstream.Close();
            }
        }


       
        private string SelectData(string strStoreProcedureName, string[] Paras, string[] Values,  DataTable dtRecords)
        {
            /* Khởi tạo đối tượng thao tác dữ liệu */
            clsDatabase Database = new clsDatabase();
            try
            {
                /* Gán chuỗi kết nối cơ sở dữ liệu */
                Database.Connection = strConnection;
                /* Nếu kết nối thành công */
                if (Database.OpenConnection() == true)
                {
                    /* Gọi phương thức GetValues của đối tượng thực thi cơ sở dữ liệu */
                    Database.getValue(ref dtRecords, strStoreProcedureName, Paras, Values);
                    /* Đóng kết nối cơ sở dữ liệu */
                    Database.CloseConnection();
                    //
                    strError = "";
                }
            }
            catch (Exception ex)
            {
                strError = ex.ToString();
            }
            finally
            {
                Database.CloseConnection();
            }
            return strError;
        }
        //spSelectDonViHanhChinhUploadMap
        public string SelDonViTinh(DataTable dt)
        {
            string[] paras = { "@flag" };
            string []values = {"0"};
            return  SelectData("spSelectDonViHanhChinhUploadMap", paras, values, dt);
        }
        public string SelDonViTinhByMaDonVihanhChinh(DataTable dt)
        {
            string[] paras = { "@flag" ,"@MaDonViHanhChinh"};
            string[] values = { "1" ,strMaDonViHanhChinh };
            return SelectData("spSelectDonViHanhChinhUploadMap", paras, values, dt);
        }
        public string SelDonViHuyenByMaDonVihanhChinh(DataTable dt)
        {
            string[] paras = { "@flag", "@MaDonViHanhChinh" };
            string[] values = { "2", strMaDonViHanhChinh };
            return SelectData("spSelectDonViHanhChinhUploadMap", paras, values, dt);
        }
        public string TaoBangMap(string TableName, string TenCot, string MaDonViHanhChinh)
        {
            string kq = "";
            string[] paras = { "@flag", "@TenBang", "@TenCot","@MaDonViHanhChinh" };
            string[] values = { "0", TableName, TenCot, MaDonViHanhChinh };
            Execute(kq , "spTaoTableMap", paras, values);
            return kq;
        }

        public string SelBanDoByMaDonVihanhChinh(DataTable dt)
        {
            string[] paras = { "@flag", "@MaDonViHanhChinh" };
            string[] values = { "1", strMaDonViHanhChinh };
            return SelectData("spTaoTableMap", paras, values, dt);
        }
        public string SelKiemTraTonTaiBan(string TableName, DataTable dt)
        {
            string[] paras = { "@flag", "@TenBang" };
            string[] values = { "2", TableName };
            return SelectData("spTaoTableMap", paras, values, dt);
        }
        //public string CapNhatDuAn(string flag)
        //{
        //    string kq = "";
        //    string[] paras = { "@flag","@MaDonViHanhChinh","@TenDuAn" };
        //    string[] values = { flag,  MaDonViHanhChinh ,strTenDuAn };
        //    Execute(kq, "spDuAnUpLoadBanDo", paras, values);
        //    return kq;
        //}
        //public string UpDuAn(string flag)
        //{
        //    string kq = "";
        //    string[] paras = { "@flag", "@MaDonViHanhChinh", "@TenDuAn" };
        //    string[] values = { flag, MaDonViHanhChinh, strTenDuAn };
        //    Execute(kq, "spDuAnUpLoadBanDo", paras, values);
        //    return kq;
        //}
        public string CapNhatDuAn(string flag)
        {
            string kq = "";
            string[] paras = { "@flag", "@MaBanDo", "@TenBanDo", "@Tyle", "@DonViHanhChinh" };
            string[] values = { flag, strMabanDo, strTenbanDo, strTyLe,strMaDonViHanhChinh };
            Execute(kq, "spThongTinBanDoQuyHoach", paras, values );
            return kq;
        }

        public string ThemDuAn(string flag)
        {
            string kq = "";
            string[] paras = { "@flag", "@MaBanDo", "@TenBanDo", "@Tyle", "@DonViHanhChinh" };
            string[] values = { flag, strMabanDo, strTenbanDo, strTyLe, strMaDonViHanhChinh };
            Execute(kq, "spThongTinBanDoQuyHoach", paras, values );
            return kq;
        }
 

        public string  SelectTaiLieuKemTheo(string flag,ref DataTable table)
        { 
              string[] paras = { "@flag", "@MaTaiLieuKemTheo" };
              string[] values = { flag, strMaTaiLieuKemTheo };
              return SelectData("spTaiLieuBanDoKemTheo", paras, values, table);
        }
 
        public string SelTenBanDoDuAn(DataTable dt)
        {
            string[] paras = { "@flag", "@DonViHanhChinh" };
            string[] values = { "0", strMaDonViHanhChinh };
            return SelectData("spThongTinBanDoQuyHoach", paras, values, dt);
        }

        public string TenTaiLieuDinhKem(DataTable dt)
        {
            string[] paras = { "@flag","@MaBanDo" };
            string[] values = { "0",strMabanDo  };
            return SelectData("spTaiLieuBanDoKemTheo", paras, values, dt);
        }

        public string BaocaoquiHoach(string flag,DataTable dt)
        {
            string[] paras = { "@flag" };
            string[] values = { flag };
            return SelectData("SP_SeLectDuAnBanDo ", paras, values, dt);
        
        }


    }
}
