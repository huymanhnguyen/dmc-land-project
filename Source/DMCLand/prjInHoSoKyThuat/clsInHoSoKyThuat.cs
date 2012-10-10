using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace prjInHoSoKyThuat
{
    class  clsInHoSoKyThuat
    {
        private string [] ParaToaDo   = {"@Flag","@MaHoSoCapGCN"};
        private string [] Para  = {"@MaHoSoCapGCN"};
        private string strMaHoSoCapGCN   = "";
        /* Khai báo biến nhận chuỗi kết nối cơ sở dữ liệu */
        private  string strConnection   = "";
        /* Khai báo Mã thửa đất */
        private string strMaThuaDat   = "";
        /* Khai báo biến kiểu chuỗi nhận Số thứ tự */
        private string strSoThuTu = "";
        /* Tọa độ X */
        private string strToaDoX = "";
        /* Tọa độ Y */
        private string strToaDoY = "";
        /* Hệ số góc */
        private string strHeSoGoc = "";
        /* Chiều dai cạnh */
        private string strChieuDai = "";
        /* Chủ Hồ sơ cấp GCN */
        private string strChuHoSoCapGCN = "";

        private SqlConnection sqlCon;
        /* Khai báo kiểu chuỗi thông báo lỗi */
        private string strError = "";
        /* Khai báo thuộc tính thông báo lỗi */
        public string Error
        {
            set { strError = value; }
        }
        /* Khai báo thuôc tính chuỗi kết nối cơ sở dữ liệu */
        public string Connection  
        {
            get{return strConnection ;}
            set{ strConnection  = value;}
        }
        /* Khai báo thuộc tín Mã hồ sơ cấp Giấy chứng nhận */
       public string MaHoSoCapGCN  
       {
            get{return strMaHoSoCapGCN;}
            set{ strMaHoSoCapGCN  = value;}
       }
        /* Khai báo thuộc tính Mã thửa đất*/
       public string MaThuaDat
       {
            get{return strMaThuaDat ;}
            set{ strMaThuaDat  = value;}
       }
        /* Khai báo thuộc tính Số thứ tự */
       public string SoThuTu
       {
           get{return strSoThuTu;}
           set { strSoThuTu= value; }
       }
        /* Khai báo thuộc tính tọa độ X */
       public string ToaDoX
       {
           get{return strToaDoX ;}
           set { strToaDoX  = value; }
       }
        /* Khai báo thuôc tính Tọa độ Y */
       public string ToaDoY
       {
           get{return strToaDoY;}
           set { strToaDoY  = value; }
       }
        /* Khai báo thuộc tính Hệ số góc */
       public string HeSoGoc
       {
           get{return strHeSoGoc;}
           set{strHeSoGoc  = value;}
       }
        /* Thuộc tính chiều dài cạnh */
       public string ChieuDai
       {
           get{return strChieuDai ;}
           set{strChieuDai  = value;}
       }
        /* */
       public string ChuHoSoCapGCN
       {
           get{return strChuHoSoCapGCN ;}
           set { strChuHoSoCapGCN  = value; }
       }
        /* */
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
           System.Data.DataTable dtResults = new DataTable();
           try
           {
               Connection = strConnection;
               if (OpenConnection())
               {
                   if (paras.Length != Values.Length)
                   {
                       return null;
                   }
                  dtResults = getValue( sp, paras, Values);
               }
           }
           catch (Exception ex)
           {
               strError = ex.Message;
               MessageBox.Show("Lỗi: " + strError);
           }
           return dtResults;
       }

       public DataTable  getValue( string strSP, string[] strPara, string[] strValues)
       {
           DataTable dtResult = new DataTable();
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
           return dtResult;
       }
        public System.Data.DataTable SelectChuHoSoCapGCN()  
        {
            DataTable dtChu =  new DataTable(); 
            string strError   = "";
            try{
                  string  [] Values= {strMaHoSoCapGCN};
                  dtChu = GetTable("spSelectChuHoSoCapGCN", Values, Para);
                strError = "";
            }
            catch (Exception ex){
                strError = ex.Message;
                MessageBox.Show("Lỗi: " + strError);
            }
            return dtChu;
        }
        public System.Data.DataTable SelectThuaDatCapGCNWithHoSoKyThuat()
        {
            DataTable dtThongTinHoSo = new DataTable();
            string strError = "";
            try
            {
                string[] Values = { strMaHoSoCapGCN };
                dtThongTinHoSo = GetTable("spSelectThuaDatCapGCNWithHoSoKyThuat", Values, Para);
                strError = "";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show("Lỗi: " + strError);
            }
            return dtThongTinHoSo;
        }
        public System.Data.DataTable DanhSachToaDo()
        {
            DataTable dtToaDo = new DataTable();
            string strError = "";
            try
            {
                string[] Values = { "1", strMaHoSoCapGCN  };
                dtToaDo = GetTable("sp_SelectInHoSoKyThuat_DanhSachToaDo", Values, ParaToaDo);
                strError = "";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show("Lỗi: " + strError);
            }
            return dtToaDo;
        }
        public System.Data.DataTable HoSoKyThuat()
        {
            DataTable dtHoSoKyThuat = new DataTable();
            string strError = "";
            try
            {
                string[] Values = { strMaHoSoCapGCN };
                dtHoSoKyThuat = GetTable("sp_SelectHoSoKyThuat", Values, Para);
                strError = "";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show("Lỗi: " + strError);
            }
            return dtHoSoKyThuat;
        }
    }
}
