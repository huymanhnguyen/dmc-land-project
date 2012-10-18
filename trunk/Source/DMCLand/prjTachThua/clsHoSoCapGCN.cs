using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DMC.Database;

namespace DMC.Land.TachThua
{
    public class clsHoSoCapGCN
    {
        /* */
        string[] strParas = { "@MaThuaDat" ,"@MaDonViHanhChinh"};
        /* Khai báo biến nhận Mã thửa đất */
        private string strMaThuaDat = "";
        /* Khai báo biến nhận Mã Hồ sơ cấp GCN */
        private string strMaHoSoCapGCN = "";
        /* Khai báo biến nhận chuỗi kết nối cơ sở dữ liệu */
        private string strConnection = "";
        /* Khai báo biến nhận thông báo lỗi */
        private string strError = "";
        private string strToBanDo = "";
        private string strSoThua = "";
        private string strDienTich = "0";
        private string strDiaChiDat = "";
        private string strTrangThai = "0";
        private string strMaDonViHanhChinh = null;
        private string strLuaChon = "";

        public string LuaChon
        {
            get { return strLuaChon; }
            set { strLuaChon = value; }
        }


        public string MaDonViHanhChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
        }
        public string TrangThai
        {
            get { return strTrangThai; }
            set { strTrangThai = value; }
        }

        public string ToBanDo
            
        {
            set { strToBanDo = value; }
            get { return strToBanDo; }
        }
        public string SoThua
        {
            set { strSoThua = value; }
            get { return strSoThua; }
        }
        /* Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu */
        public string Connection
        {
            set { strConnection = value; }
        }
        /* Khai báo thuộc tính chỉ ghi Mã thửa đất */
        public string MaThuaDat
        {
            set { strMaThuaDat = value; }
        }

        public string DienTich
        {
            set { strDienTich = value; }
        }
        public string DiaChiDat
        {
            set { strDiaChiDat = value; }
        }

        /* Khai báo thuộc tính nhận Mã hồ sơ cấp GCN */
        public string MaHoSoCapGCN
        {
            set { strMaHoSoCapGCN = value; }
            get { return strMaHoSoCapGCN; }
        }


        /// <summary>
        /// Danh sách Hồ sơ cấp GCN tìm được theo Mã thửa đất cấp GCN
        /// </summary>
        /// <returns>Giá trị trả về kiểu Datatable chứa danh sách Hồ sơ cấp GCN</returns>
        public DataTable SelectHoSoCapGCNByMaThuaDat()
        {
            /* Khai biến tạm thời kiểu Datatable */
            DataTable dtResults = new DataTable();
            try
            {
                /* Khai báo đối tượng clsDatabase */
                clsDatabase Database = new clsDatabase();
                /* Nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                /* Nếu kết nỗi thành công */
                if (Database.OpenConnection())
                {
                    /* khai báo mảng giá trị */
                    string[] strValues = { strMaThuaDat,strMaDonViHanhChinh  };
                    /* Kiểm tra tính hợp lệ của dữ liệu trước khi thực thi câu lệnh SQL */
                    if (strParas.Length != strValues.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                    Database.getValue(ref dtResults, "spSelectHoSoCapGCNByMaThuaDat", strParas, strValues);
                    Database.CloseConnection();
                    strError = "";
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi hiển thị danh sách Hồ sơ cấp GCN theo mã thửa đất: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtResults;
        }
        public void Updatethuadatdangthaotac(ref string strRecord)
        {
            try
            {
                /* Khai báo đối tượng clsDatabase */
                clsDatabase Database = new clsDatabase();
                /* Nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                /* Nếu kết nỗi thành công */
                if (Database.OpenConnection())
                {
                    /* khai báo mảng giá trị */
                    string[] strpara = { "@MaThuaDat", "@ToBanDo", "@SoThua","@MaDonViHanhChinh", "@InOut" };
                    string[] strValues = { strMaThuaDat, strToBanDo, strSoThua,strMaDonViHanhChinh, "0" };
                    /* Kiểm tra tính hợp lệ của dữ liệu trước khi thực thi câu lệnh SQL */
                    if (strpara.Length != strValues.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //string kq = "";
                    Database.ExecuteSP("spUpdateThuaDatDangThaoTac", strpara, strValues, ref strRecord);
                    Database.CloseConnection();
                    strError = "";
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi update trạng thái thửa đất đang thao tác: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void InsThuaDatDangThaoTac(ref string strRecord)
        {
            try
            {
                /* Khai báo đối tượng clsDatabase */
                clsDatabase Database = new clsDatabase();
                /* Nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                
                /* Nếu kết nỗi thành công */
                if (Database.OpenConnection())
                {
                    /* khai báo mảng giá trị */
                    string[] strpara = { "@MaThuaDat", "@ToBanDo", "@SoThua", "@DienTich","@MaDonViHanhChinh", "@InOut" };
                    string[] strValues = { strMaThuaDat, strToBanDo, strSoThua, strDienTich, strMaDonViHanhChinh, "1" };
                    /* Kiểm tra tính hợp lệ của dữ liệu trước khi thực thi câu lệnh SQL */
                    if (strpara.Length != strValues.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string kq = "";
                    Database.ExecuteSP("spInsertThuaDatDangThaoTac", strpara, strValues, ref strRecord);
                    Database.CloseConnection();
                    strError = "";
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi thêm vào danh sách thửa đất đang thao tác: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable SelThongTinHoSoByToBanDoSoThua()
        {
            DataTable dt = new DataTable();
            string[] paras = { "@ToBanDo", "@SoThua","MaDonViHanhChinh","@MaThuaDat" };
            string[] values = { strToBanDo, strSoThua ,strMaDonViHanhChinh ,strMaThuaDat };
            dt = Gettable("spSelectMaHoSoCapGCNByToBanDoSoThua", paras, values);
            return dt;    

          }
        public DataTable SelThongTinThuaDat()
        {
            DataTable dt = new DataTable();
            string[] paras = { "@IsCoBanDo", "MaDonViHanhChinh", "@ToBanDo", "@SoThua", "@DiaChiThua" };
            string[] values = { "1", strMaDonViHanhChinh,strToBanDo,strSoThua,  strDiaChiDat };
            dt = Gettable("spSelectThongTinThuaDat", paras, values);
            return dt;

        }
        public DataTable SelThongTinHoSoByMaHoSoCapGCN()
        {
            DataTable dt = new DataTable();
            string[] paras = { "@MaHoSoCapGCN" };
            string[] values = { strMaHoSoCapGCN };
            dt = Gettable("spSelectThongTinHoSoByMaHoSoCapGCN", paras, values);
            return dt;    

        }
        public DataTable SelTrangThaiCapGCN()
        {
            DataTable dt = new DataTable();
            string[] paras = { "@flag", "@TrangThai" };
            string[] values = { "0", strTrangThai };
            dt = Gettable("spDMTrangThaiHoSo", paras, values);
            return dt;    

             
        }
        public DataTable SelAllTrangThai()
        {
            DataTable dt = new DataTable();
            string[] paras = { "@flag" };
            string[] values = { "1" };
            dt = Gettable("spDMTrangThaiHoSo", paras, values);
            return dt;    

        }

        public DataTable SelectTongHopChu()
        {
            DataTable dt = new DataTable();
            string[] paras =   { "@MaHoSoCapGCN" } ;
            string[] values = { strMaHoSoCapGCN  };
            dt = Gettable("sp_selectTenChu", paras, values);
            return dt;
        }
        public DataTable SelAllMucDichSDD()
        {
            DataTable dt = new DataTable();
            string[] paras = { "@flag" };
            string[] values = { "1" };
            dt = Gettable("spDMTrangThaiMucDichSuDungDat", paras, values);
            return dt;         
        }
        public DataTable SelMucDichDayCapGCN()
        {
            DataTable dt = new DataTable();
            string[] paras = { "@flag", "@KyHieu" };
            string[] values = { "0", strTrangThai.ToString() };
            dt = Gettable("spDMTrangThaiMucDichSuDungDat", paras, values);
            return dt;


        }
        /// <summary>
        /// Danh sách Hồ sơ cấp GCN tìm được theo Mã thửa đất cấp GCN
        /// </summary>
        /// <returns>Giá trị trả về kiểu Datatable chứa danh sách Hồ sơ cấp GCN</returns>
        public void UpdateSoanHS(ref string strRecord)
        {
            try
            {
                /* Khai báo đối tượng clsDatabase */
                clsDatabase Database = new clsDatabase();
                /* Nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                /* Nếu kết nỗi thành công */
                if (Database.OpenConnection())
                {
                    /* khai báo mảng giá trị */
                    string[] strpara = { "@MaHoSoCapGCN","@MaThuaDat", "@ToBanDo","@SoThua","@DienTich" ,"@MaDonViHanhChinh","@LuaChon"};
                    string[] strValues = {strMaHoSoCapGCN, strMaThuaDat,strToBanDo,strSoThua , strDienTich ,strMaDonViHanhChinh ,strLuaChon };
                    /* Kiểm tra tính hợp lệ của dữ liệu trước khi thực thi câu lệnh SQL */
                    if (strpara.Length != strValues.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string kq="";
                    Database.ExecuteSP("spUpdateThongTinThuaDatBySoanHS", strpara, strValues ,ref strRecord );
                    Database.CloseConnection();
                    strError = "";
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi hiển thị danh sách Hồ sơ cấp GCN theo mã thửa đất: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

        public DataTable SelCheckHoSoByToBanDoSoThua()
        {
            DataTable dt = new DataTable();
            string[] paras = { "@ToBanDo", "@SoThua", "@MaDonViHanhChinh" ,"@MaThuaDat","@MaHoSoCapGCN","@LuaChon"};
            string[] values = { strToBanDo, strSoThua, strMaDonViHanhChinh,strMaThuaDat,strMaHoSoCapGCN ,strLuaChon };
            dt = Gettable("spSelectCheckHoSoByMaThuaDat", paras, values);
            return dt;
        }
  
        public DataTable SelDanhSachThuaTrung()
        {
            DataTable dt = new DataTable();
            string[] paras = { "@flag","@MaDonViHanhChinh" };
            string[] values = { "0" ,strMaDonViHanhChinh};
            dt = Gettable("spSelectToBanDoSoThuaTrungLap", paras, values);
            return dt;
        }

        public DataTable SelDanhSachThuaTrungChiTiet()
        {
            DataTable dt = new DataTable();
            string[] paras = { "@flag", "@ToBanDo", "@SoThua", "@MaDonViHanhChinh" };
            string[] values = { "1", strToBanDo, strSoThua, strMaDonViHanhChinh };
            dt = Gettable("spSelectToBanDoSoThuaTrungLap", paras, values);
            return dt;
        }

        public DataTable Gettable(string storeName, string[] paras, string[] values)
        {
            clsDatabase Database = new clsDatabase();
            DataTable dt = new DataTable();
            try
            {
                Database.Connection = strConnection;
                /* Nếu kết nối thành công */
                if (Database.OpenConnection())
                {
                    if (paras.Length != values.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                    Database.getValue(ref dt, storeName, paras, values);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public DataTable SelMaQuan(string DonViHanhChinh)
        {
            DataTable dt = new DataTable();
            string[] paras = { "@flag", "@MaDonViHanhChinh" };
            string[] values = { "6", DonViHanhChinh };
            dt = Gettable("spThongTinFileDLIEUKGIANNHANQUIHOACH", paras, values);
            return dt;
        }

        public DataTable SelTenBanDo(string DonViHanhChinh)
        {
            DataTable dt = new DataTable();
            string[] paras = { "@flag", "@MaDonViHanhChinh" };
            string[] values = { "9", DonViHanhChinh };
            dt = Gettable("spThongTinFileDLIEUKGIANNHANQUIHOACH", paras, values);
            return dt;
        }

        public void XoaBanDo(string DonViHanhChinh,string LayerName)
        {
            try
            {
                /* Khai báo đối tượng clsDatabase */
                clsDatabase Database = new clsDatabase();
                /* Nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                /* Nếu kết nỗi thành công */
                if (Database.OpenConnection())
                {
                    /* khai báo mảng giá trị */
                    string[] strpara = { "@flag", "@MaDonViHanhChinh", "@LayerName" };
                    string[] strValues = { "8", DonViHanhChinh, LayerName };
                    /* Kiểm tra tính hợp lệ của dữ liệu trước khi thực thi câu lệnh SQL */
                    if (strpara.Length != strValues.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu truyền vào chưa hợp lệ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string kq = "";
                    Database.ExecuteSP("spThongTinFileDLIEUKGIANNHANQUIHOACH", strpara, strValues, ref kq);
                    Database.CloseConnection();
                    strError = "";
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi hiển thị danh sách Hồ sơ cấp GCN theo mã thửa đất: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
