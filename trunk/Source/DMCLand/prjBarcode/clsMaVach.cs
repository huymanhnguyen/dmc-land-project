using System;
using System.Collections.Generic;
using System.Text;

namespace DMC.Barcode
{
    class clsMaVach
    {
        // Khai báo biến chuỗi kết nối cơ sở dữ liệu
        private string strConnection = "";
        // Khai báo biến kiểm tra lỗi
        //
       
        private string strError;
        //Khai báo biến Mã Hồ sơ cấp GCN
        private string strMaHoSoCapGCN;
        // Khai báo biến lưu hình ảnh mã vạch
        private byte[] bytAnhMaVach;
        /* Khai báo biến kiểu boolean, có hoặc không in mã vạch */
        private bool boolInMaVach = false;
        private string strGiaTriMaVach = "";

        public string GiaTriMaVach
        {
            get { return strGiaTriMaVach; }
            set { strGiaTriMaVach = value; }
        }
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
        //Khai bao thuoc tinh ung voi bien 
        public string MaHoSoCapGCN
        {
            get
            {
                return strMaHoSoCapGCN;
            }
            set
            {
                strMaHoSoCapGCN = value;
            }
        }
        //Khai bao thuoc tinh ung voi bien 
        public byte[] AnhMaVach
        {
            get
            {
                return bytAnhMaVach;
            }
            set
            {
                bytAnhMaVach = value;
            }
        }
        //Khai bao thuoc tinh ung voi bien 
        public bool  InMaVach
        {
            get
            {
                return boolInMaVach;
            }
            set
            {
                boolInMaVach  = value;
            }
        }

        /// <summary>
        /// Cập nhật Hình ảnh mã vạch GCN vào bảng 
        /// tblHoSoCapGCN.
        /// </summary>
        /// <returns></returns>
        private string Execute(string strStoreProcedureName)
        {
            try
            {
                DMC.Database.clsDatabase Database = new DMC.Database.clsDatabase();
                //Neu ket noi co so du lieu thanh cong
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
                    System.Data.SqlClient.SqlParameter sqlParaGiaTriMaVach= new System.Data.SqlClient.SqlParameter();
                    System.Data.SqlClient.SqlParameter sqlParaMaHoSoCapGCN = new System.Data.SqlClient.SqlParameter();
                    System.Data.SqlClient.SqlParameter sqlParaInMaVach = new System.Data.SqlClient.SqlParameter();
                    System.Data.SqlClient.SqlParameter sqlParaAnhMaVach = new System.Data.SqlClient.SqlParameter();
                    /* Duyệt qua từng phần tử giá trị */

                    /*  Khởi tạo đối tượng SqlParameter */
                    sqlParaGiaTriMaVach = new System.Data.SqlClient.SqlParameter("@GiaTriMaVach", System.Data.SqlDbType.NVarChar ,50);
                    sqlParaGiaTriMaVach.Value = strGiaTriMaVach;
                    sqlCommand.Parameters.Add(sqlParaGiaTriMaVach);
                    /*  Khởi tạo đối tượng SqlParameter */
                    sqlParaMaHoSoCapGCN = new System.Data.SqlClient.SqlParameter("@MaHoSoCapGCN", System.Data.SqlDbType.BigInt);
                    sqlParaMaHoSoCapGCN.Value = strMaHoSoCapGCN;
                    sqlCommand.Parameters.Add(sqlParaMaHoSoCapGCN);
                    /*  Khởi tạo đối tượng SqlParameter */
                    sqlParaInMaVach = new System.Data.SqlClient.SqlParameter("@InMaVach", System.Data.SqlDbType.Bit);
                    sqlParaInMaVach.Value = boolInMaVach;
                    sqlCommand.Parameters.Add(sqlParaInMaVach);
                    /*  Khởi tạo đối tượng SqlParameter */
                    sqlParaAnhMaVach = new System.Data.SqlClient.SqlParameter("@AnhMaVach", System.Data.SqlDbType.VarBinary);
                    sqlParaAnhMaVach.Value = bytAnhMaVach;
                    sqlCommand.Parameters.Add(sqlParaAnhMaVach);

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
        /// Cập nhật Hình ảnh hồ sơ kĩ thuật cho Giấy chứng nhận
        /// </summary>
        /// <returns></returns>
        public string UpdateHoSoCapGCNByMaVach()
        {
            string str = this.Execute("spUpdateHoSoCapGCNByMaVach");
            return str;
        }

        /// <summary>
        /// Select Mã vạch GCN theo Mã Hồ sơ cấp GCN
        /// </summary>
        /// <param name="strStoreProcedureName"></param>
        /// <returns></returns>
        public System.Data.DataTable SelectData()
        {
            ///* Chắc chắn rằng tồn tại Tên Store procedure */
            //if (strStoreProcedureName == "")
            //{
            //    return null;
            //}
            /* Chắc chắn rằng Mã Hồ sơ cấp GCN là kiểu số */
            if (strMaHoSoCapGCN == "")
            {
                return null;
            }
            /* Initialize DataTalbe. */
            System.Data.DataTable dtMaVach = new System.Data.DataTable("tblHoSoCapGCN");
            try
            {
                /* Khai báo và khởi tạo đối tượng SqlCommand */
                System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
                /* Gán kết nối cơ sở dữ liệu */
                sqlCommand.Connection = new System.Data.SqlClient.SqlConnection(strConnection);
                /* Nhận kiểu thực thì câu lệnh truy vấn cơ sở dữ liệu là thủ tục  */
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                /* Gán Tên thủ tục */
                sqlCommand.CommandText = "spSelectHoSoCapGCNByMaVach";
                /*  Khởi tạo đối tượng SqlParameter */
                System.Data.SqlClient.SqlParameter sqlParaMaHoSoCapGCN = new System.Data.SqlClient.SqlParameter("@MaHoSoCapGCN", System.Data.SqlDbType.BigInt);
                sqlParaMaHoSoCapGCN.Value = Convert.ToInt64(strMaHoSoCapGCN);
                sqlCommand.Parameters.Add(sqlParaMaHoSoCapGCN);
                /* Declare and initialize SqlDataAdapter Object */
                System.Data.SqlClient.SqlDataAdapter sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(sqlCommand);
                /* Insert data into DataTable */
                sqlDataAdapter.Fill(dtMaVach);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(" Hiển thị dữ liệu " + System.Environment.NewLine + " Lỗi " + System.Environment.NewLine + ex.Message, "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            //byte[] bytTemp = null ;
            //if (dtMaVach.Rows.Count > 0)
            //{
            //    if (dtMaVach.Rows[0]["AnhMaVach"].ToString() != "")
            //    {
            //        bytTemp = (byte[])dtMaVach.Rows[0]["AnhMaVach"];
            //    }
            //}
            //return bytTemp ;
            return dtMaVach;
        }

        public System.Data.DataTable SelectCheckMaVach()
        {
            ///* Chắc chắn rằng tồn tại Tên Store procedure */
            //if (strStoreProcedureName == "")
            //{
            //    return null;
            //}
            /* Chắc chắn rằng Mã Hồ sơ cấp GCN là kiểu số */
            if (strMaHoSoCapGCN == "")
            {
                return null;
            }
            /* Initialize DataTalbe. */
            System.Data.DataTable dtMaVach = new System.Data.DataTable("CheckMaVach");
            try
            {
                /* Khai báo và khởi tạo đối tượng SqlCommand */
                System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
                /* Gán kết nối cơ sở dữ liệu */
                sqlCommand.Connection = new System.Data.SqlClient.SqlConnection(strConnection);
                /* Nhận kiểu thực thì câu lệnh truy vấn cơ sở dữ liệu là thủ tục  */
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                /* Gán Tên thủ tục */
                sqlCommand.CommandText = "spSelectCheckMaVach";
                /*  Khởi tạo đối tượng SqlParameter */
                System.Data.SqlClient.SqlParameter sqlParaMaHoSoCapGCN = new System.Data.SqlClient.SqlParameter("@GiaTriMaVach", System.Data.SqlDbType.NVarChar,50);
                sqlParaMaHoSoCapGCN.Value = strGiaTriMaVach;
                sqlCommand.Parameters.Add(sqlParaMaHoSoCapGCN);
                /* Declare and initialize SqlDataAdapter Object */
                System.Data.SqlClient.SqlDataAdapter sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(sqlCommand);
                /* Insert data into DataTable */
                sqlDataAdapter.Fill(dtMaVach);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(" Hiển thị dữ liệu " + System.Environment.NewLine + " Lỗi " + System.Environment.NewLine + ex.Message, "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            //byte[] bytTemp = null ;
            //if (dtMaVach.Rows.Count > 0)
            //{
            //    if (dtMaVach.Rows[0]["AnhMaVach"].ToString() != "")
            //    {
            //        bytTemp = (byte[])dtMaVach.Rows[0]["AnhMaVach"];
            //    }
            //}
            //return bytTemp ;
            return dtMaVach;
        }
    }
}
