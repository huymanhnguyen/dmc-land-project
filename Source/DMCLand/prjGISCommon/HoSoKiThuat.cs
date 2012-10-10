using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public class HoSoKiThuat
    {
        // Khai báo biến chuỗi kết nối cơ sở dữ liệu
        private string strConnection = "";
        // Khai báo biến kiểm tra lỗi
        private string strError; 
        //Khai báo biến Mã Hồ sơ cấp GCN
        private string  strMaHoSoCapGCN;
        // Khai báo biến lưu hình ảnh hồ sơ kĩ thuật
        private byte[]  bytHoSoKiThuatThuaDat;
        private string strHienThiAnhThua = "0";

        public string HienThiAnhThua
        {
            get { return strHienThiAnhThua; }
            set { strHienThiAnhThua = value; }
        }
        //Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
        public string  Connection
        {
            set
            {
                strConnection = value;
            }
        }
        //Khai bao thuoc tinh ung voi bien
        public string  Err
        {
            get
            {
                return strError;
            }
        }
        //Khai bao thuoc tinh ung voi bien 
        public string  MaHoSoCapGCN
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
        public  byte[] HoSoKiThuatThuaDat
        {
            get
            {
                return bytHoSoKiThuatThuaDat;
            }
            set
            {
                //bytHoSoKiThuatThuaDat = new byte[value.Length];
                bytHoSoKiThuatThuaDat = value;
            }
        }

        /// <summary>
        /// Cập nhật Hình ảnh hồ sơ kĩ thuật thửa đất vào bảng 
        /// tblHoSoCapGCN.
        /// </summary>
        /// <returns></returns>
        private string  Execute(string strStoreProcedureName)
        {
            try
            {
                DMC.Database.clsDatabase  Database =  new DMC.Database.clsDatabase();
                //Neu ket noi co so du lieu thanh cong
                Database.Connection = strConnection;
                if  (Database.OpenConnection() == true  )
                {
                    /*  Khai báo đối tượng SqlCommand */
                    System.Data.SqlClient.SqlCommand  sqlCommand = new System.Data.SqlClient.SqlCommand();

                    /* Gán kết nối tới cơ sở dữ liệu */
                    sqlCommand.Connection =  new System.Data.SqlClient.SqlConnection(strConnection);
                    /*  Xác định kểu thực thi câu lệnh Sql là StoredProcedure */
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    /*  Nhận tên Thủ tục trong cơ sở dữ liệu */
                    sqlCommand.CommandText = strStoreProcedureName ;
                    /*  Khai báo đối tượng SqlParameter */
                    System.Data.SqlClient.SqlParameter  sqlParaMaHoSoCapGCN = new  System.Data.SqlClient.SqlParameter();
                    System.Data.SqlClient.SqlParameter sqlParaHoSoKiThuat = new System.Data.SqlClient.SqlParameter();
                    System.Data.SqlClient.SqlParameter sqlParaHienThiHoSoKiThuat = new System.Data.SqlClient.SqlParameter();
                    /* Duyệt qua từng phần tử giá trị */

                    /*  Khởi tạo đối tượng SqlParameter */
                    sqlParaMaHoSoCapGCN = new System.Data.SqlClient.SqlParameter("@MaHoSoCapGCN", System.Data.SqlDbType.BigInt);
                    sqlParaMaHoSoCapGCN.Value = strMaHoSoCapGCN;
                    sqlCommand.Parameters.Add(sqlParaMaHoSoCapGCN);
                    /*  Khởi tạo đối tượng SqlParameter */
                    sqlParaHienThiHoSoKiThuat = new System.Data.SqlClient.SqlParameter("@HienThiAnhThua", System.Data.SqlDbType.NVarChar,10);
                    sqlParaHienThiHoSoKiThuat.Value = strHienThiAnhThua;
                    sqlCommand.Parameters.Add(sqlParaHienThiHoSoKiThuat);
                    if (strStoreProcedureName.ToUpper() != "spUpdateHoSoCapGCNByHoSoKiThuatThamDinh".ToUpper()){ 
                    /*  Khởi tạo đối tượng SqlParameter */
                        sqlParaHoSoKiThuat = new System.Data.SqlClient.SqlParameter("@HoSoKiThuat", System.Data.SqlDbType.VarBinary, bytHoSoKiThuatThuaDat.Length );
                        sqlParaHoSoKiThuat.Value = bytHoSoKiThuatThuaDat;
                        sqlCommand.Parameters.Add(sqlParaHoSoKiThuat);
                    }
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
                System.Windows.Forms.MessageBox.Show("Lỗi: " + System.Environment.NewLine + strError , "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); 
            }
            return strError;
        }


        /// <summary>
        /// Cập nhật Hình ảnh Sơ đồ Nhà đất
        /// </summary>
        /// <returns></returns>
        public string UpdateHoSoCapGCNBySoDoNhaDat()
        {
            string str = Execute("spUpdateHoSoCapGCNBySoDoNhaDat");
            return str;
        }

        /// <summary>
        /// Cập nhật Hình ảnh hồ sơ kĩ thuật cho Giấy chứng nhận
        /// </summary>
        /// <returns></returns>
        public string UpdateHoSoCapGCNByHoSoKiThuatGCN()
        {
            string str = Execute("spUpdateHoSoCapGCNByHoSoKiThuatGCN");
            return str;
        }

        /// <summary>
        /// Cập nhật Hình ảnh hồ sơ kĩ thuật cho: Phiếu thẩm định,
        /// Sơ đồ thửa đất...
        /// </summary>
        /// <returns></returns>
        public string UpdateHoSoCapGCNByHoSoKiThuatThamDinh()
        {
            string str = Execute("spUpdateHoSoCapGCNByHoSoKiThuatThamDinh");
            return str;
        }

        /// <summary>
        /// Select Hồ sơ kĩ thuật theo Mã Hồ sơ cấp GCN
        /// </summary>
        /// <param name="strStoreProcedureName"></param>
        /// <returns></returns>
        public byte[]  SelectHoSoKiThuat( string  strStoreProcedureName) 
        {
            /* Chắc chắn rằng tồn tại Tên Store procedure */
            if (strStoreProcedureName == "") 
            {
                return null;
            }
            /* Chắc chắn rằng Mã Hồ sơ cấp GCN là kiểu số */
            if (strMaHoSoCapGCN == "")
            {
                return null ;
            }
            /* Khai báo mảng tạm kiểu Byte */
            byte[] bytTemp = null;
            /* Initialize DataTalbe. */
            System.Data.DataTable dtHoSoKiThuat = new System.Data.DataTable("tblHoSoCapGCN");
            try
            {
                /* Khai báo và khởi tạo đối tượng SqlCommand */
                System.Data.SqlClient.SqlCommand sqlCommand  = new System.Data.SqlClient.SqlCommand();
                /* Gán kết nối cơ sở dữ liệu */
                sqlCommand.Connection = new System.Data.SqlClient.SqlConnection(strConnection);
                /* Nhận kiểu thực thì câu lệnh truy vấn cơ sở dữ liệu là thủ tục  */
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                /* Gán Tên thủ tục */
                sqlCommand.CommandText = strStoreProcedureName;
                /*  Khởi tạo đối tượng SqlParameter */
                System.Data.SqlClient.SqlParameter sqlParaMaHoSoCapGCN = new System.Data.SqlClient.SqlParameter("@MaHoSoCapGCN", System.Data.SqlDbType.BigInt);
                sqlParaMaHoSoCapGCN.Value = Convert.ToInt64(strMaHoSoCapGCN);
                sqlCommand.Parameters.Add(sqlParaMaHoSoCapGCN);
                /* Declare and initialize SqlDataAdapter Object */
                System.Data.SqlClient.SqlDataAdapter  sqlDataAdapter =  new System.Data.SqlClient.SqlDataAdapter(sqlCommand);
                /* Insert data into DataTable */
                sqlDataAdapter.Fill(dtHoSoKiThuat);
                if (dtHoSoKiThuat.Rows.Count > 0)
                {
                    if (dtHoSoKiThuat.Rows[0][0].ToString()  != "")
                    {
                        bytTemp = (byte[])dtHoSoKiThuat.Rows[0][0];
                        strHienThiAnhThua = dtHoSoKiThuat.Rows[0][1].ToString();
                    }
                    else
                    {
                        bytTemp = null;
                        strHienThiAnhThua = "False";
                    }
                }
                else
                {
                    bytTemp = null;
                    strHienThiAnhThua = "False";
                }
            }
            catch ( Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(" Hiển thị dữ liệu " + System.Environment.NewLine  + " Lỗi " + System.Environment.NewLine  + ex.Message,"DMCLand",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error );
            }
            return bytTemp;
        }
    }
}
