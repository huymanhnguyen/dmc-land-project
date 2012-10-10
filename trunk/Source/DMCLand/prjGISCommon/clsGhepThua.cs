using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DMC.GIS.Common
{
    public class clsGhepThua
    {
        private string[] Paras = { "@xml","@MaDonViHanhChinh" };
        /* Khai báo biến nhận chuỗi kết nối Database */
        private string strConnection = ""; 
        /* Khai báo biến kiểm tra lỗi  */
        private string strError = "";  
        private string   strThuaDat = null ;
        private string strMaThuaDatCon = "";
        private string strMaDonViHanhChinh = "";

        public string MaDonViHanhChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
        }
        public string MaThuaDatCon
        {
            get { return strMaThuaDatCon; }
            set { strMaThuaDatCon = value; }
        }
        /* Khai báo thuộc tính nhận chuỗi kết nối Database */
        public string Connection
        {
            set
            {
                strConnection = value;
            }
        }
        /* Khai báo thuộc tính ứng với biến lỗi */
        public string Err
        {
            get
            {
                return strError;
            }
        }

        /* Khai báo thuộc tính ứng với biến Danh sách mã thửa đất cần ghép */
        public string  ThuaDat
        {
            get
            {
                return strThuaDat;
            }
            set
            {
                strThuaDat = value;
            }
        }

        /// <summary>
        /// Lưu thửa đất vào lịch sử biến động (tblDLieuKGianThuaDatLichSu)
        /// Đồng thời xóa thông tin thửa đất ở bảng hiện thời (tblDLieuKGianThuaDat)
        /// </summary>
        /// <param name="strRecords"></param>
        /// <returns></returns>
        public string LuuLichSuBienDong()
        {
            string strRecords = "";
            //return this.Execute("spLuuLichSuBienDongGhep", strRecords);
            return this.Execute("spInsertDLieuKGianThuaDatLichSuByGhep", strRecords);
        }

        /// <summary>
        /// Hàm thực thi thủ tục SQL
        /// </summary>
        /// <param name="strStoreProcedureName">Tên thủ tục SQL cần thực thi</param>
        /// <param name="strRecords"></param>
        /// <returns></returns>
        private string Execute(string strStoreProcedureName, string strRecords)
        {
            try
            {
                /* Khoi tao doi tuong clsSqlDatabase */
                DMC.Database.clsDatabase Database = new DMC.Database.clsDatabase();
                /* Nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                /*  Neu ket noi co so du lieu thanh cong */
                if (Database.OpenConnection() == true)
                {
                    /* Khai bao mang gia tri */
                    string[] Values = { strThuaDat, strMaDonViHanhChinh };
                    /* Chắc chắn rằng số tham biến bằng số tham trị */
                    if (Paras.Length != Values.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Giá trị truyền vào không tương thích", "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return "Giá trị truyền vào không tương thích";
                    }
                    /* Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase */
                    Database.ExecuteSP(strStoreProcedureName, Paras, Values, ref strRecords);
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
    }
}
