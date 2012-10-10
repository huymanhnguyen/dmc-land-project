using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
namespace prjTongHopIn
{
    
    class clsTongHopIn
    {
        private SqlConnection sqlCon;
        private string strConnection  = "";
        private string strError = "";
        private string strMaDonViHanhChinh= "";
        private string strTenChuSuDung = "";
        private string strNgaySinh = "";
        private string strSoDinhDanh = "";
        private string strDiaChiChuSuDung = "";
        private string strGhiChuChuSuDung = "";
        private string strToBanDo = "";
        private string strSoThua = "";
        private string strDiaChiDat = "";
        private string strDienTich = "";
        private string strDienTichBangChu = "";
        private string strDienTichChung = "";
        private string strDienTichRieng = "";
        private string strMucDichSuDung = "";
        private string strThoiHan = "";
        private string strNguonGoc = "";
        private string strDiaChiNha = "";
        private string strDienTichXayDung = "";
        private string strDienTichSan = "";
        private string strKetCau = "";
        private string strCapHang = "";
        private string strSoTang = "";
        private string strNamHoanThanhXD = "";
        private string strThoiHanSuDung = "";
        private string strTenCongTrinh = "";
        private string strDienTichCoRung = "";
        private string strNguonGocTaoLap = "";
        private string strCayLauNam = "";
        private string strGhiChuTrang2 = "";
        private string strNhungThayDoiKhiCapGiay = "";
        private string strInBanDo = "";
        private string strTyLe = "";
        private string strSoVaoSo = "";
        private string strUyQuyen = "";
        private string strHuyenCap = "";
        private string strNguoiKy = "";
        private string strMaVach = "";
        private string strTextMaVach = "";
        private string strCoQuanCap = "";
        //khai bao cac thuoc tinh
        public string Connection {
            set { strConnection = value; }
        }
        public string Error
        {
            set { strError = value; }
        }
        public string MaDonViHanhChinh
        {
            set { strMaDonViHanhChinh = value; }
        }
        public string TenChuSuDung
        {
            set { strTenChuSuDung = value; }
        }
        public string NgaySinh
        {
            set { strNgaySinh = value; }
        }
        public string SoDinhDanh
        {
            set { strSoDinhDanh = value; }
        }
        public string DiaChiChuSuDung
        {
            set { strDiaChiChuSuDung = value; }
        }
        public string GhiChuChuSuDung
        {
            set { strGhiChuChuSuDung = value; }
        }
        public string ToBanDo
        {
            set { strToBanDo = value; }
        }
        public string SoThua
        {
            set { strSoThua = value; }
        }
        public string DiaChiDat
        {
            set { strDiaChiDat = value; }
        }
        public string DienTich
        {
            set { strDienTich = value; }
        }
        public string DienTichBangChu
        {
            set { strDienTichBangChu = value; }
        }
        public string DienTichChung
        {
            set { strDienTichChung = value; }
        }
        public string DienTichRieng
        {
            set { strDienTichRieng = value; }
        }
        public string MucDichSuDung
        {
            set { strMucDichSuDung = value; }
        }
        public string ThoiHan
        {
            set { strThoiHan = value; }
        }
        public string NguonGoc
        {
            set { strNguonGoc = value; }
        }
        public string DiaChiNha
        {
            set { strDiaChiNha = value; }
        }
        public string DienTichXayDung
        {
            set { strDienTichXayDung = value; }
        }
        public string DienTichSan
        {
            set { strDienTichSan = value; }
        }
        public string KetCau
        {
            set { strKetCau = value; }
        }
        public string CapHang
        {
            set { strCapHang = value; }
        }
        public string SoTang
        {
            set { strSoTang = value; }
        }
        public string NamHoanThanhXD
        {
            set { strNamHoanThanhXD = value; }
        }
        public string ThoiHanSuDung
        {
            set { strThoiHanSuDung = value; }
        }
        public string TenCongTrinh
        {
            set { strTenCongTrinh = value; }
        }
        public string DienTichCoRung
        {
            set { strDienTichCoRung = value; }
        }
        public string NguonGocTaoLap
        {
            set { strNguonGocTaoLap = value; }
        }
        public string CayLauNam
        {
            set { strCayLauNam = value; }
        }
        public string GhiChuTrang2
        {
            set { strGhiChuTrang2 = value; }
        }
        public string NhungThayDoiKhiCapGiay
        {
            set { strNhungThayDoiKhiCapGiay = value; }
        }
        public string InBanDo
        {
            set { strInBanDo = value; }
        }
        public string SoVaoSo
        {
            set { strSoVaoSo = value; }
        }
        public string UyQuyen
        {
            set { strUyQuyen = value; }
        }
        public string HuyenCap
        {
            set { strHuyenCap = value; }
        }
        public string NguoiKy
        {
            set { strNguoiKy = value; }
        }
        public string MaVach
        {
            set { strMaVach = value; }
        }
        public string TextMaVach
        {
            set { strTextMaVach = value; }
        }
        public string CoQuanCap {
            set { strCoQuanCap = value; }
        }

    public bool  OpenConnection(){
        Boolean boolSuccessfully   = false;
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
   public System.Data.DataTable GetTable(string sp, string  [] Values , string [] paras){
        string strError = "";
        System.Data.DataTable MyTable =new DataTable ();
        try {
            Connection = strConnection;
            if (OpenConnection()) {
                if  (paras.Length != Values.Length) {
                    return null;
                }
                getValue(MyTable, sp, paras, Values);
            }
        }
        catch (Exception ex){
            strError = ex.Message;
        }
        return MyTable;
   }
       
    public void getValue(DataTable  dtResult , string  strSP , string  []strPara,string [] strValues){
        try {
            System.Data.SqlClient.SqlCommand sqlCom = new SqlCommand() ;
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = strSP;
            SqlParameter sqlPara; 
            for (int  i = 0;i< strPara.Length - 1;i++){
                sqlPara = new  SqlParameter(strPara[i], strValues[i]);
                sqlCom.Parameters.Add(sqlPara);
            }
            SqlDataAdapter sqlDataAdapter = new  SqlDataAdapter(sqlCom);
            sqlDataAdapter.Fill(dtResult);
        }
        catch (Exception ex){
            strError = ex.Message;
            MessageBox.Show(" Hiển thị dữ liệu bị Lỗi " + strError);
        }
        }

    public void ExecuteSP(string strSP , string []strParameters, string strValues,string strResult) { 
            try{
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = strSP;
                SqlParameter sqlPara ;
                for(int  i = 0;  i < strValues.Length - 1;i++){
                    sqlPara = new  SqlParameter(strParameters[i], strValues[i]);
                    sqlCom.Parameters.Add(sqlPara);
                }
                strResult = sqlCom.ExecuteScalar().ToString ();
            }
         catch ( Exception ex ){
            strError = ex.Message;
            MessageBox.Show(" Lỗi thực thi dữ bị Lỗi " + strError );
            }
      }
    }
}
        