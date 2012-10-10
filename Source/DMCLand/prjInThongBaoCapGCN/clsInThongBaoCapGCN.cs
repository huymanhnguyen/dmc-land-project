using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace DMC.Land.InThongBaoCapGCN
{
    class clsInThongBaoCapGCN
    {
        private string [] Para  = {"@MaHoSoCapGCN"};
        private string strMaHoSoCapGCN   = "";
        private  string strConnection   = "";
        private string strChuSuDung = "";
        private SqlConnection sqlCon;
        private string strError = "";
        public string Error
        {
            set { strError = value; }
        }
   public string Connection  {
        get{
            return strConnection ;
        }
        set{ strConnection  = value;}
    }
   public string MaHoSoCapGCN  {
        get{
            return strMaHoSoCapGCN ;
        }
        set{ strMaHoSoCapGCN  = value;}
    }
  
   public string ChuSuDung
   {
       get
       {
           return strChuSuDung ;
       }
       set { strChuSuDung  = value; }
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
           MessageBox.Show("Lỗi kết nối dữ liệu" + strError);
       }
       return boolSuccessfully;
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
               getValue(MyTable, sp, paras, Values);
           }
       }
       catch (Exception ex)
       {
           strError = ex.Message;
       }
       return MyTable;
   }

   public void getValue(DataTable dtResult, string strSP, string[] strPara, string[] strValues)
   {
       try
       {
           System.Data.SqlClient.SqlCommand sqlCom = new SqlCommand();
           sqlCom.Connection = sqlCon;
           sqlCom.CommandType = CommandType.StoredProcedure;
           sqlCom.CommandText = strSP;
           SqlParameter sqlPara;
           for (int i = 0; i < strPara.Length ; i++)
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
           MessageBox.Show(" Hiển thị dữ liệu bị Lỗi " + strError);
       }
   }
    public System.Data.DataTable SelectChuSuDung()  {
        DataTable dt =  new DataTable(); 
        string strError   = "";
        try{
              string  [] Values= {strMaHoSoCapGCN};
              dt = GetTable("sp_SelectInPhieuChuSuDung", Values, Para);
            strError = "";
        }
        catch (Exception ex){
            strError = ex.Message;
        }
        return dt;
    }
    public System.Data.DataTable ThongTinHoSo()
    {
        DataTable dt = new DataTable();
        string strError = "";
        try
        {
            string[] Values = { strMaHoSoCapGCN };
            dt = GetTable("sp_SelectThongBaoHoSoCapGCN", Values, Para);
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
