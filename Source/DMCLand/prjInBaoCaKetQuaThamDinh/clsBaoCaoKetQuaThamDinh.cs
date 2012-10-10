using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace prjInBaoCaKetQuaThamDinh
{
    class clsBaoCaoKetQuaThamDinh
    {
        private string[] Para = { "@MaHoSoCapGCN" };
        private string[] ParaDVHC = { "@MaDVHC" };
        private string strConnection = "";
        private string strMaHoSoCapGCN = "";
        private string strMaDVHC = "";
        private string[] strTenMaDVHC;
        private SqlConnection sqlCon;
        private string strError = "";
        public string Connection
        {
            set { strConnection = value; }
            get { return strConnection; }
        }
        public string MaHoSoCapGCN
        {
            set { strMaHoSoCapGCN = value; }
            get { return strMaHoSoCapGCN; }
        }
        public string MaDVHC
        {
            set { strMaDVHC = value; }
            get { return strMaDVHC; }
        }
        public string[] TenMaDVHC
        {
            set { strTenMaDVHC = value; }
            get { return strTenMaDVHC; }
        }
        public bool OpenConnection()
        {
            Boolean boolSuccessfully = false;
            try
            {
                sqlCon = new SqlConnection(strConnection);
                sqlCon.Open();
                strError = "";
                boolSuccessfully = true;
            }
            catch (Exception eq)
            {
                strError = eq.Message;
                System.Windows.Forms.MessageBox.Show("Lỗi kết nối dữ liệu" + strError);
            }
            return boolSuccessfully;
        }
        public System.Data.DataTable SelectDVHC()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string strError = "";
            try
            {
                string[] Values = { strMaDVHC };
                dt = GetTable("spSelectHuyenTinh", Values, ParaDVHC);
                strError = "";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        public System.Data.DataTable GetTable(string sp, string[] Values, string[] paras)
        {
            string strError = "";
            System.Data.DataTable MyTable = new DataTable();
            try
            {
                Connection = strConnection;
                if (OpenConnection())
                {
                    if (paras.Length != Values.Length)
                    {
                        return null;
                    }
                    MyTable = getValue(sp, paras, Values);
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return MyTable;
        }

        public System.Data.DataTable getValue(string strSP, string[] strPara, string[] strValues)
        {
            System.Data.DataTable dtResult = new System.Data.DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = strSP;
                SqlParameter sqlPara;
                for (int i = 0; i < strPara.Length; i++)
                {
                    sqlPara = new SqlParameter(strPara[i], strValues[i]);
                    sqlCom.Parameters.Add(sqlPara);
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCom);
                sqlDataAdapter.Fill(dtResult);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(" Hiển thị dữ liệu bị Lỗi " + strError);
            }
            return dtResult;
        }
        public System.Data.DataTable SelectChuSuDung()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string strError = "";
            try
            {
                string[] Values = { strMaHoSoCapGCN };
                dt = GetTable("spSelectChuHoSoCapGCN", Values, Para);
                strError = "";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        public System.Data.DataTable SelectThongTinDatNhaO()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string strError = "";
            try
            {
                string[] Values = { strMaHoSoCapGCN };
                dt = GetTable("sp_selectThongTinDatInQuyetDinh", Values, Para);
                strError = "";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        public System.Data.DataTable SelectThongTinNguonGoc()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string strError = "";
            try
            {
                string[] Values = { strMaHoSoCapGCN };
                dt = GetTable("spSelectNguonGocChiTietByMaHoSoCapGCN", Values, Para);
                strError = "";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
    }
}
