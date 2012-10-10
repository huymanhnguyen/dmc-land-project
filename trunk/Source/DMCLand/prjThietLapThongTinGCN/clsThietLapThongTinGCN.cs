using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DMC.Database;

namespace prjThietLapThongTinGCN
{
    class clsThietLapThongTinGCN
    {
        //Khai báo Parameters
        string[] Paras = { "@Ma", "@TieuDeKyGCN", "@MoTa"};
        //Khai báo biến nhận chuỗi kết nối cơ sở dữ liệu
        string strConnection = "";
        //Khai báo biến kiểm tra lỗi
        string strError = "";
        /*Khai báo biến tương ứng với các thuộc tính của các trường 
        thao tác  với bảng Từ điển người xét duyệt */
        string strMa = "";
        string strMoTa = "";
        string strTieuDeKyGCN = "";
        /* Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu */
        public string Conneciton
        {
            set { strConnection = value; }
        }
        /* Khai báo thuộc tính kiểm tra lỗi */
        public string Error
        {
            get { return strError; }
        }
        /* Khai báo thuộc tính ứng với các biến là các trường dữ liệu
        của bảng Từ điển người xét duyệt */
        public string Ma
        {
            set { strMa = value; }
            get { return strMa; }
        }
        public string MoTa
        {
            set { strMoTa = value; }
            get { return strMoTa; }
        }
        public string TieuDeKyGCN
        {
            set { strTieuDeKyGCN = value; }
            get { return strTieuDeKyGCN; }
        }
        #region
        /// <summary>
        /// Thêm mới Tiêu đề ký GCN vào bảng Từ điển Tiêu đề ký GCN
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string InsertTuDienTieuDeKyGCN(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spInsertTuDienTieuDeKyGCN");
        }

        /// <summary>
        /// Xóa người ký GCN từ bảng Từ điển Tiêu đề ký GCN
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string DeleteTuDienTieuDeKyGCN(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spDeleteTuDienTieuDeKyGCN");
        }

        /// <summary>
        /// Cập nhật thông tin Tiêu đề ký GCN trong bảng
        /// Từ điển Tiêu đề ký GCN
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string UpdateTuDienTieuDeKyGCN(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spUpdateTuDienTieuDeKyGCN");
        }

        /// <summary>
        /// Liệt kê danh sách Tiêu đề ký GCN
        /// </summary>
        /// <param name="dtRecords"></param>
        /// <returns></returns>
        public string SelectTuDienTieuDeKyGCN(ref DataTable dtRecords)
        {
            return this.SelectData("spSelectTuDienTieuDeKyGCN", ref dtRecords);
        }
        #endregion


        /*  Định nghĩa phương thức thực thi dữ liệu */
        public string Execute(ref string strRecord, string strStoreProcedureName)
        {
            /* Khởi tạo đối tượng thực thi cơ sở dữ liệu */
            clsDatabase Database = new clsDatabase();
            try
            {
                /* Nếu kết nối thành công */
                Database.Connection = strConnection;
                if (Database.OpenConnection() == true)
                {
                    /* Khai báo mảng giá trị */
                    string[] Values = { strMa, strTieuDeKyGCN, strMoTa };
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


        private string SelectData(string strStoreProcedureName, ref DataTable dtRecords)
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
                    /* Khai báo mảng giá trị */
                    string[] Values = { strMa, strTieuDeKyGCN, strMoTa };
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
    }
}
