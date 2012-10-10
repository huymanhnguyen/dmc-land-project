using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.Land.TachThua
{
    class LandPlotHistory
    {
        // Khai báo biến chuỗi kết nối cơ sở dữ liệu
        private string strConnection = "";
        // Khai báo biến kiểm tra lỗi
        private string strError;
        //Khai báo biến Mã Thửa đất
        private long longMaThuaDat;
        //Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
        public string Connection
        {
            set
            {
                strConnection = value;
            }
        }
        //Khai bao thuoc tinh ung voi bien
        public string Err
        {
            get
            {
                return strError;
            }
        }
        /* Khai báo thuộc tính ứng với biến */
        public long MaThuaDat
        {
            get
            {
                return longMaThuaDat ;
            }
            set
            {
                longMaThuaDat  = value;
            }
        }

        /// <summary>
        /// Lưu lịch sử thửa đất khi thực hiện biến động bản đồ
        /// </summary>
        /// <returns></returns>
        private string Execute(string strStoreProcedureName)
        {
            try
            {
                DMC.Database.clsDatabase Database = new DMC.Database.clsDatabase();
                /* Nếu kết nối cơ sở dữ liệu thành công */
                Database.Connection = strConnection;
                if (Database.OpenConnection() == true)
                {
                    /*  Khai báo đối tượng SqlCommand */
                    System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();

                    /* Gán kết nối tới cơ sở dữ liệu */
                    sqlCommand.Connection = new System.Data.SqlClient.SqlConnection(strConnection);
                    /*  Xác định kểu thực thi câu lệnh Sql là StoredProcedure */
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    /*  Nhận tên Thủ tục trong cơ sở dữ liệu */
                    sqlCommand.CommandText = strStoreProcedureName;
                    /*  Khai báo đối tượng SqlParameter */
                    System.Data.SqlClient.SqlParameter sqlParaMaThuaDat = new System.Data.SqlClient.SqlParameter();
                    /* Duyệt qua từng phần tử giá trị */

                    /*  Khởi tạo đối tượng SqlParameter */
                    sqlParaMaThuaDat = new System.Data.SqlClient.SqlParameter("@MaThuaDat", System.Data.SqlDbType.BigInt);
                    sqlParaMaThuaDat.Value = longMaThuaDat ;
                    sqlCommand.Parameters.Add(sqlParaMaThuaDat);

                    if (sqlCommand.Connection.State == System.Data.ConnectionState.Closed)
                        sqlCommand.Connection.Open();
                    /*  Thực thi thủ tục hệ thống */
                    //strResult = sqlCom.ExecuteScalar();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show("Lỗi: " + System.Environment.NewLine + strError, "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return strError;
        }

        /// <summary>
        /// Insert Thửa đất vào lịch sử theo Mã thửa đất
        /// </summary>
        /// <returns></returns>
        public string InsertLichSuThuaDatByMaThuaDat()
        {
            string str = Execute("");
            return str;
        }

        /// <summary>
        /// Select Thông tin lịch sử thửa đất theo Mã thửa đất hiện thời
        /// (Mã thửa đất hiện thời là Mã thửa đất đang tồn tại có nguồn gốc
        /// là thửa đất lịch sử)
        /// </summary>
        /// <param name="strStoreProcedureName"></param>
        /// <returns></returns>
        public byte[] SelectTblDLieuKGianThuaDatLichSuByMaThuaHienThoi(string strStoreProcedureName)
        {
            /* Chắc chắn rằng tồn tại Tên Store procedure */
            if (strStoreProcedureName == "")
            {
                return null;
            }
            /* Chắc chắn rằng tồn tại Mã thửa đất*/
            if (longMaThuaDat  == 0)
            {
                return null;
            }
            /* Initialize DataTable. */
            System.Data.DataTable dtLichSuThuaDat = new System.Data.DataTable("TblDLieuKGianThuaDat");
            try
            {
                /* Khai báo và khởi tạo đối tượng SqlCommand */
                System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
                /* Gán kết nối cơ sở dữ liệu */
                sqlCommand.Connection = new System.Data.SqlClient.SqlConnection(strConnection);
                /* Nhận kiểu thực thì câu lệnh truy vấn cơ sở dữ liệu là thủ tục  */
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                /* Gán Tên thủ tục */
                sqlCommand.CommandText = strStoreProcedureName;
                /*  Khởi tạo đối tượng SqlParameter */
                System.Data.SqlClient.SqlParameter sqlParaMaThuaDat = new System.Data.SqlClient.SqlParameter("@MaThuaDat", System.Data.SqlDbType.BigInt);
                sqlParaMaThuaDat.Value = Convert.ToInt64(longMaThuaDat);
                sqlCommand.Parameters.Add(sqlParaMaThuaDat);
                /* Declare and initialize SqlDataAdapter Object */
                System.Data.SqlClient.SqlDataAdapter sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(sqlCommand);
                /* Insert data into DataTable */
                sqlDataAdapter.Fill(dtLichSuThuaDat);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(" Hiển thị dữ liệu " + System.Environment.NewLine + " Lỗi " + System.Environment.NewLine + ex.Message, "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return (byte[])dtLichSuThuaDat.Rows[0][0];
        }
    }
}
