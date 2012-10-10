using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMC.Database;
using System.Windows.Forms;
using System.Data;

namespace DMC.Land.TuDienCanBoNhiepVu
{
    public  class clsTuDienCanBoNghiepVu
    {
        //Khai báo Parameters
        string[] Paras = { "@Ma", "@GioiTinh", "@HoTen", "@ChucDanh", "@ChucVu"};
        //Khai báo biến nhận chuỗi kết nối cơ sở dữ liệu
        string strConnection = "";
        //Khai báo biến kiểm tra lỗi
        string strError = "";
        /*Khai báo biến tương ứng với các thuộc tính của các trường 
        thao tác  với bảng Từ điển người xét duyệt */
        string strMa = "";
        string strGioiTinh = "";
        string strHoTen = "";
        string strChucDanh = "";
        string strChucVu = "";
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
        public string GioiTinh
        {
            set { strGioiTinh = value; }
            get { return strGioiTinh; }
        }
        public string HoTen
        {
            set { strHoTen = value; }
            get { return strHoTen; }
        }
        public string ChucDanh
        {
            set { strChucDanh = value; }
            get { return strChucDanh; }
        }
        public string ChucVu
        {
            set { strChucVu = value; }
            get { return strChucVu; }
        }

        #region
        /// <summary>
        /// Thêm mới Người ký GCN vào bảng Từ điển người ký GCN
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string InsertTuDienCanBoKyGCN(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spInsertTuDienNguoiKyGCN");
        }

        /// <summary>
        /// Xóa người ký GCN từ bảng Từ điển người ký GCN
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string DeleteTuDienCanBoKyGCN(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spDeleteTuDienNguoiKyGCN");
        }

        /// <summary>
        /// Cập nhật thông tin Người ký GCN trong bảng
        /// Từ điển người ký GCN
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string UpdateTuDienCanBoKyGCN(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spUpdateTuDienNguoiKyGCN");
        }

        /// <summary>
        /// Liệt kê danh sách Người ký GCN
        /// </summary>
        /// <param name="dtRecords"></param>
        /// <returns></returns>
        public string SelectTuDienCanBoKyGCN(ref DataTable dtRecords)
        {
            return this.SelectData("spSelectTuDienNguoiKyGCN", ref dtRecords);
        }
        #endregion

        #region TỪ ĐIỂN CÁN BỘ XÉT DUYỆT

        /// <summary>
        /// Thêm mới Người xét duyệt vào bảng Từ điển người xét duyệt
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string InsertTuDienCanBoXetDuyet(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spInsertTuDienNguoiXetDuyet");
        }

        /// <summary>
        /// Xóa người xét duyệt từ bảng Từ điển người xét duyệt
        /// Note: Khi đó sẽ  xóa cả  các bản ghi liên quan trong
        /// bảng Hội đồng xét duyệt
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string DeleteTuDienCanBoXetDuyet(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spDeleteTuDienNguoiXetDuyet");
        }

        /// <summary>
        /// Cập nhật thông tin Người xét duyệt trong bảng
        /// Từ điển người xét duyệt
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string UpdateTuDienCanBoXetDuyet(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spUpdateTuDienNguoiXetDuyet");
        }

        public string SelectTuDienCanBoXetDuyet(ref DataTable dtRecords)
        {
            return this.SelectData("spSelectTuDienNguoiXetDuyet", ref dtRecords);
        }
        #endregion

        #region TỪ ĐIỂN CÁN BỘ THẨM ĐỊNH

        /// <summary>
        /// Thêm mới CÁN BỘ THẨM ĐỊNH vào bảng Từ điển NGƯỜI THẨM ĐỊNH
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string InsertTuDienCanBoThamDinh(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spInsertTuDienNguoiThamDinh");
        }
        /// <summary>
        /// Xóa người xét duyệt từ bảng Từ điển người THẨM ĐỊNH
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string DeleteTuDienCanBoThamDinh(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spDeleteTuDienNguoiThamDinh");
        }
        /// <summary>
        /// Cập nhật thông tin Người THẨM ĐỊNH trong bảng
        /// Từ điển người THẨM ĐỊNH
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string UpdateTuDienCanBoThamDinh(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spUpdateTuDienNguoiThamDinh");
        }

        /// <summary>
        /// Lựa chọn từ điển cán bộ THẨM ĐỊNH
        /// </summary>
        /// <param name="dtRecords"></param>
        /// <returns></returns>
        public string SelectTuDienCanBoThamDinh(ref DataTable dtRecords)
        {
            return this.SelectData("spSelectTuDienNguoiThamDinh", ref dtRecords);
        }
        #endregion

        #region TỪ ĐIỂN CÁN BỘ PHÊ DUYỆT

        /// <summary>
        /// Thêm mới CÁN BỘ PHÊ DUYỆT vào bảng Từ điển NGƯỜI PHÊ DUYỆT
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string InsertTuDienCanBoPheDuyet(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spInsertTuDienNguoiPheDuyet");
        }
        /// <summary>
        /// Xóa người xét duyệt từ bảng Từ điển người PHÊ DUYỆT
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string DeleteTuDienCanBoPheDuyet(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spDeleteTuDienNguoiPheDuyet");
        }
        /// <summary>
        /// Cập nhật thông tin Người PHÊ DUYỆT trong bảng
        /// Từ điển người PHÊ DUYỆT
        /// </summary>
        /// <param name="strRecord"></param>
        /// <returns></returns>
        public string UpdateTuDienCanBoPheDuyet(ref string strRecord)
        {
            return this.Execute(ref  strRecord, "spUpdateTuDienNguoiPheDuyet");
        }

        /// <summary>
        /// Lựa chọn từ điển cán bộ PHÊ DUYỆT
        /// </summary>
        /// <param name="dtRecords"></param>
        /// <returns></returns>
        public string SelectTuDienCanBoPheDuyet(ref DataTable dtRecords)
        {
            return this.SelectData("spSelectTuDienNguoiPheDuyet", ref dtRecords);
        }
        #endregion

        // Định nghĩa phương thức thực thị dữ liệu
        public string  Execute( ref string  strRecord, string strStoreProcedureName)
        {
            /* Khởi tạo đối tượng thực thi cơ sở dữ liệu */
            clsDatabase Database = new clsDatabase();
            try
            {
                /* Nếu kết nối thành công */
                Database.Connection = strConnection;
                if (Database.OpenConnection() == true )
                {
                    /* Khai báo mảng giá trị */
                    string[] Values = {strMa, strGioiTinh, strHoTen, strChucDanh,strChucVu };
                    /* Gọi phương thức ExecuteSP của đối tượng thao tác cơ sở dữ liệu */
                    Database.ExecuteSP(strStoreProcedureName , Paras, Values, ref  strRecord);
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


        private  string SelectData(string strStoreProcedureName, ref DataTable  dtRecords)
        {
            /* Khởi tạo đối tượng thao tác dữ liệu */
            clsDatabase Database = new clsDatabase();
            try
            {
                /* Gán chuỗi kết nối cơ sở dữ liệu */
                Database.Connection = strConnection;
                /* Nếu kết nối thành công */
                if (Database.OpenConnection() == true )
                {
                    /* Khai báo mảng giá trị */
                    string[] Values = {strMa ,strGioiTinh,strHoTen,strChucDanh,strChucVu  };
                    /* Gọi phương thức GetValues của đối tượng thực thi cơ sở dữ liệu */
                    Database.getValue(ref dtRecords, strStoreProcedureName , Paras, Values);
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
