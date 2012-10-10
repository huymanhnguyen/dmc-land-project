using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace prjXemLichSuThuaDat
{
    class clsLichSuBienDong
    {
      private SqlConnection sqlCon = new SqlConnection() ;
      private DateTime strThoiDiemBienDong;

      public DateTime ThoiDiemBienDong
      {
          get { return strThoiDiemBienDong; }
          set { strThoiDiemBienDong = value; }
      }
      private string strMaDonViHanhChinh = "";

      public string MaDonViHanhChinh
      {
          get { return strMaDonViHanhChinh; }
          set { strMaDonViHanhChinh = value; }
      }
        private string strConnection = "";
        private string strError = "";

        public string Connection
        {
            get { return strConnection; }
            set { strConnection = value; }
        }
        private string strMaThuaDat = "";

        public string MaThuaDat
        {
            get { return strMaThuaDat; }
            set { strMaThuaDat = value; }
        }

        public  System.Data.DataTable  selDanhSachBienDong()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
             try
            {
                if (OpenConnection())
                {
                    dt = new System.Data.DataTable();
                    string[] Para = { "@flag", "@MaThuaDat" ,"@MaDonViHanhChinh"};
                    string[] value = { "0", strMaThuaDat ,strMaDonViHanhChinh };
                    getValue(dt, "spThongTinBienDongHoSo", Para, value);
                }
          }
         catch (Exception ex)
         {
         }
             return dt;
        }
        public void getValue(System.Data.DataTable dtResult, string strSP, string[] strPara, string[] strValues)
        {
            try
            {
                System.Data.SqlClient.SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = System.Data.CommandType.StoredProcedure;
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
            }
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
            }
            return boolSuccessfully;
        }
    }
}
