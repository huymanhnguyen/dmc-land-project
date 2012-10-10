using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System;
namespace DMC.GIS.Common
{
    public class clsDatabase
    {
       private  SqlConnection conn;
       private string strConnection;
       private string SererName;
       private string DatabaseName;
       private string strMaDonViHanhChinh = "";
       private string UID;
       private string Upass;
       private Int64 strMaHoSoCapGCN;
      // ctrSoanHS frm = new ctrSoanHS();
       public string MaDonViHanhChinh {
           set { strMaDonViHanhChinh = value; }
           get { return strMaDonViHanhChinh; }
       }

       public void SetConnection(string value)
       {
           strConnection = value;
       }
       public string GetConnection()
       {
           return strConnection;
       }

       public long GetMaHoSoCapGCN()
       {
           return strMaHoSoCapGCN;
       }
       private string strTenBangDat = "";

       public string TenBangDat
       {
           get { return strTenBangDat; }
           set { strTenBangDat = value; }
       }
       private string TenBangSoan = "";

       public string BanSoan
       {
           get { return TenBangSoan; }
           set { TenBangSoan = value; }
       }
        //ham ket noi co so du lieu
        public SqlConnection Connect()
        {
            try
            {
                string strConnec;
                strConnec = "";

                strConnec = strConnection;//"Data Source=" + SererName + ";Initial Catalog=" + DatabaseName + " ;User ID=" + UID + " ;PassWord=" + Upass + "";
                conn = new SqlConnection();
                conn.ConnectionString = strConnec;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }catch(Exception ex){
                MessageBox.Show("Lỗi kết nối =>>" + ex.Message );
            }
            return conn;
        }
        //xac nhan ghi thanh cong cuoi dung ()
        public void GhiXacNhan(long  FeatureID, long MaHoSoCapGCN,string strBang)
        {
            //xac nhan ghi thanh cong
                conn = new SqlConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn = Connect();
                }
                SqlCommand cmd;
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Update " + strBang + " set FeatureID=" + FeatureID.ToString().Split('.')[0] + ",MaHoSoCapGCN=" + MaHoSoCapGCN + ", temp = 'True' where MaHoSoCapGCN = " + MaHoSoCapGCN + "";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Xác nhận ghi thành công");
                cmd.Dispose();
        }
        //Lay gia tri cua truong dua vao FeatureID
        public string GetValueCol(string BanDo, string col, long  FeatureID)
        {
            conn = new SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                Connect();
            }
            string Value;
            Value = "";
            SqlCommand cmd;
            SqlDataReader crd;
          
            string str;
            str = "select " + col + " from " + BanDo + " where SW_member=" + FeatureID.ToString().Split('.')[0] + "";
            cmd = new SqlCommand(str, conn);
            crd = cmd.ExecuteReader();
            while (crd.Read())
            {
                Value = crd[col].ToString();
            }
            crd.Dispose();
            cmd.Dispose();
            return Value;
        }
        //lay gia tri dua vao ten cot va key cua Feature (lay tu CSDL)
        public string getValue(string strBang, string col, string Key)
        {
            conn = new SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                Connect();
            }
            string Value;
            Value = "";
            SqlCommand cmd;
            SqlDataReader crd;
            string str;
            str = "select " + col + " from " + strBang + " where Sw_member='" + Key + "'";
            cmd = new SqlCommand(str, conn);
            try
            {
                crd = cmd.ExecuteReader();
                while (crd.Read())
                {
                    Value = crd[col].ToString();
                }
                cmd.Dispose();
                crd.Dispose();
            }
            finally
            {
                conn.Close();
            }
            
            return Value;

        }
        //chuc nang ghi danh sach toa do vao trong CSDL
        public void GhiDanhSachToaDo(SqlConnection conn, DMC.Interface.GridView.ctrlGridView  dt,long MaHoSoCapGCN,long FeatureID) {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Connect();
                }
                //xoa du lieu cu
                if (dt.Rows.Count > 0)
                {
                    deleteDSToaDo(conn,dt,MaHoSoCapGCN );
                }
                //them du lieu moi vao
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.CommandText = "sp_InsertDanhSachToaDoThuaDat";// "Update " + strBang + " set MaHoSoCapGCN=" + strMaHoSoCapGCN + ",FeatureID=" + FeatureID + ", MaDoiTuong =" + DoiTuong + " where MaHoSoCapGCN is null";

                    cmd.Parameters.Add(new SqlParameter("@Flag", 1));
                        cmd.Parameters.Add(new SqlParameter("@MaHoSoCapGCN", MaHoSoCapGCN));
                        cmd.Parameters.Add(new SqlParameter("@MaThuaDat", FeatureID.ToString().Split('.')[0]));
                        cmd.Parameters.Add(new SqlParameter("@SoThuTu",  dt.Rows[i].Cells [1].Value ));
                        cmd.Parameters.Add(new SqlParameter("@ToaDoX",String.Format("{0:#,##0.00}",Math.Round( Convert.ToDouble( dt.Rows[i].Cells[2].Value),2).ToString())));
                        cmd.Parameters.Add(new SqlParameter("@ToaDoY", String.Format("{0:#,##0.00}", Math.Round(Convert.ToDouble(dt.Rows[i].Cells[3].Value), 2).ToString())));
                        cmd.Parameters.Add(new SqlParameter("@HeSoGoc", dt.Rows[i].Cells[4].Value));
                        cmd.Parameters.Add(new SqlParameter("@ChieuDai", dt.Rows[i].Cells[5].Value));

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
            }catch(Exception ex ){
                MessageBox.Show(ex.Message);
            }
        }
        public void deleteDSToaDo(SqlConnection conn, DMC.Interface.GridView.ctrlGridView dt, long MaHoSoCapGCN)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Connect();
                }
                    SqlCommand cmd;
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "sp_InsertDanhSachToaDoThuaDat";// "Update " + strBang + " set MaHoSoCapGCN=" + strMaHoSoCapGCN + ",FeatureID=" + FeatureID + ", MaDoiTuong =" + DoiTuong + " where MaHoSoCapGCN is null";

                    cmd.Parameters.Add(new SqlParameter("@Flag", 2));
                    cmd.Parameters.Add(new SqlParameter("@MaHoSoCapGCN", MaHoSoCapGCN));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //kiem  tra danh sach toa do da ton tai chua
        public bool KtTonTaiDSToaDo(string MaHoSoCapGCN){
            bool kt = false;
            try
            {
                
                if (conn.State == ConnectionState.Closed)
                {
                    Connect();
                }
                SqlCommand cmd;
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_InsertDanhSachToaDoThuaDat";
                cmd.Parameters.Add(new SqlParameter("@Flag", 3));
                cmd.Parameters.Add(new SqlParameter("@MaHoSoCapGCN", MaHoSoCapGCN));
                cmd.ExecuteNonQuery();
                DataSet dtResult = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dtResult);
                if (dtResult.Tables[0].Rows.Count > 0)
                {
                    kt = true;
                }
                else {
                    kt = false;
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                kt = false  ;
            }
            return kt;
        }



        //LayMaThuaDat khi biet Ma HoSoCapGCN
        public long    GetMaThuaDat(string strBangHoSo, long MaHoSoCapGCN) {
            conn = new SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                Connect();
            }
             SqlCommand cmd=new SqlCommand();;
             cmd.Connection = conn;
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.CommandText = "sp_SelectMaThuaDat";
             SqlParameter sqlPara ;
             DataSet dtResult = new DataSet();
            if (MaHoSoCapGCN != null){
                cmd.Parameters.Add(new SqlParameter("@MaHoSoCapGCN", MaHoSoCapGCN));
            }
            else{
                cmd.Parameters.Add(new SqlParameter("@MaHoSoCapGCN", System.DBNull.Value));
            }
           
            try {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dtResult);
            }
            catch(Exception ex){
            
            }
             
             long  MaThua;
             MaThua = 0;
             if (dtResult.Tables[0].Rows.Count > 0)
             {
                 MaThua = Convert.ToInt64(dtResult.Tables[0].Rows[0]["MaThuaDat"].ToString().Split('.')[0]);
             }
     
            return MaThua;
        }
        //LayMaThuaDat khi biet Ma HoSoCapGCN
        public void UpdateMapFile(int flag, string  MaHoSoCapGCN,byte[] fileTab,byte[] fileMap, byte[]fileID,byte[]filedat,double CenterX,double CenterY,double Zoom)
        {
            conn = new SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                Connect();
            }
            SqlCommand sqlCommand = new SqlCommand(); ;
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "spThongTinFileHSKT";
            SqlParameter sqlPara;
            DataSet dtResult = new DataSet();
            if (MaHoSoCapGCN != null)
            {
                System.Data.SqlClient.SqlParameter MaHoSo = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter byFileTab = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter byFileMap = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter byFileID = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter byFileDat = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter dlCenterX = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter dlCenterY= new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter dlZoom = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter intflag = new System.Data.SqlClient.SqlParameter();
                //@MaHoSo, @FileTab, @fileDat, @FileID, @FileMap, @PCenterX, @PCenterY, @Zoom

                MaHoSo = new System.Data.SqlClient.SqlParameter("@MaHoSo", System.Data.SqlDbType.BigInt);
                MaHoSo.Value = MaHoSoCapGCN;
                sqlCommand.Parameters.Add(MaHoSo);
                byFileTab = new System.Data.SqlClient.SqlParameter("@FileTab", System.Data.SqlDbType.VarBinary, int.MaxValue - 1);
                byFileTab.Value = fileTab;
                sqlCommand.Parameters.Add(byFileTab);
                byFileDat = new System.Data.SqlClient.SqlParameter("@fileDat", System.Data.SqlDbType.VarBinary, int.MaxValue - 1);
                byFileDat.Value = filedat;
                sqlCommand.Parameters.Add(byFileDat);
                byFileID = new System.Data.SqlClient.SqlParameter("@FileID", System.Data.SqlDbType.VarBinary, int.MaxValue - 1);
                byFileID.Value = fileID;
                sqlCommand.Parameters.Add(byFileID);
                byFileMap = new System.Data.SqlClient.SqlParameter("@FileMap", System.Data.SqlDbType.VarBinary, int.MaxValue - 1);
                byFileMap.Value = fileMap;
                sqlCommand.Parameters.Add(byFileMap);
                dlCenterX = new System.Data.SqlClient.SqlParameter("@PCenterX", System.Data.SqlDbType.Decimal);
                dlCenterX.Value = CenterX;
                sqlCommand.Parameters.Add(dlCenterX);
                dlCenterY = new System.Data.SqlClient.SqlParameter("@PCenterY", System.Data.SqlDbType.Decimal);
                dlCenterY.Value = CenterY;
                sqlCommand.Parameters.Add(dlCenterY);
                dlZoom = new System.Data.SqlClient.SqlParameter("@Zoom", System.Data.SqlDbType.Decimal);
                dlZoom.Value = Zoom;
                sqlCommand.Parameters.Add(dlZoom);
                intflag = new System.Data.SqlClient.SqlParameter("@flag", System.Data.SqlDbType.Int);
                intflag.Value = flag ;
                sqlCommand.Parameters.Add(intflag);
            }
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }
        //LayMaThuaDat khi biet Ma HoSoCapGCN
        public void UpdateZoomMapFile(int flag, string MaHoSoCapGCN, double Zoom)
        {
            conn = new SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                Connect();
            }
            SqlCommand sqlCommand = new SqlCommand(); ;
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "spThongTinFileHSKT";
            SqlParameter sqlPara;
            DataSet dtResult = new DataSet();
            if (MaHoSoCapGCN != null)
            {
                System.Data.SqlClient.SqlParameter MaHoSo = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter dlZoom = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter intflag = new System.Data.SqlClient.SqlParameter();
                //@MaHoSo, @FileTab, @fileDat, @FileID, @FileMap, @PCenterX, @PCenterY, @Zoom

                MaHoSo = new System.Data.SqlClient.SqlParameter("@MaHoSo", System.Data.SqlDbType.BigInt);
                MaHoSo.Value = MaHoSoCapGCN;
                sqlCommand.Parameters.Add(MaHoSo);
      
                dlZoom = new System.Data.SqlClient.SqlParameter("@Zoom", System.Data.SqlDbType.Decimal);
                dlZoom.Value = Zoom;
                sqlCommand.Parameters.Add(dlZoom);
                intflag = new System.Data.SqlClient.SqlParameter("@flag", System.Data.SqlDbType.Int);
                intflag.Value = flag;
                sqlCommand.Parameters.Add(intflag);
            }
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }
        public DataTable  GetFileMap(int flag,string strMaHoSoCapGCN) {
           DataTable dt = new DataTable();
        if (strMaHoSoCapGCN !="")
        {
            conn = new SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                Connect();
            }
            SqlCommand sqlCommand = new SqlCommand(); ;
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "spThongTinFileHSKT";
            
                System.Data.SqlClient.SqlParameter MaHoSo = new System.Data.SqlClient.SqlParameter();
                MaHoSo = new System.Data.SqlClient.SqlParameter("@MaHoSo", System.Data.SqlDbType.BigInt);
                MaHoSo.Value = strMaHoSoCapGCN;
                sqlCommand.Parameters.Add(MaHoSo);
                System.Data.SqlClient.SqlParameter intflag = new System.Data.SqlClient.SqlParameter();
                 intflag = new System.Data.SqlClient.SqlParameter("@flag", System.Data.SqlDbType.Int);
                intflag.Value = flag ;
                sqlCommand.Parameters.Add(intflag);
                
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(dt);
            }
        return dt;
        }

        //update thong tin ma doi tuong
        public void UpdateFeature(string strBang, string MaDoiTuong, Int64 strMaHoSoCapGCN, long   FeatureID, SqlConnection conn)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = conn;
            if (MaDoiTuong == "") { MaDoiTuong = "0"; }
            int DoiTuong;
            DoiTuong = Convert.ToInt32(MaDoiTuong);
            cmd.CommandText = "Update " + strBang + " set MaHoSoCapGCN=" + strMaHoSoCapGCN + ",FeatureID=" + FeatureID.ToString().Split('.')[0] + ", MaDoiTuong =" + DoiTuong + " where MaHoSoCapGCN is null";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        //xoa ban ghi tam trong CSDL
        public void XoaTmp(string strBang, long strMaHoSoCapGCN)
        {
            conn = new SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn = Connect();
            }
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from " + strBang + " where (temp is null) and (MaHoSoCapGCN=" + strMaHoSoCapGCN + ")";
            cmd.CommandType = CommandType.Text;
           cmd.ExecuteNonQuery();
            cmd.Dispose();
            XoaThuaGoc(strBang, strMaHoSoCapGCN);
        }
        //xoa ban ghi tam trong CSDL
        public void XoaThuaGoc(string strBang, long strMaHoSoCapGCN)
        {
            conn = new SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn = Connect();
            }
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from " + strBang + " where (SoThua <>'') and (ToBanDo <> '') and (SoThua is not null) and (ToBanDo is not null) and (MaHoSoCapGCN=" + strMaHoSoCapGCN + ")";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();

        }
        //public void DeleteFeature(string strBang, string MaDoiTuong, string FeatureID)
        //{
            
        //    if (conn.State == ConnectionState.Closed)
        //    {
        //        conn = Connect();
        //    }
        //    SqlCommand cmd;
        //    cmd = new SqlCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandText = "delete from  " + strBang + " where SW_member=" + FeatureID + " and  MaDoiTuong ='" + MaDoiTuong + "'";
        //    cmd.CommandType = CommandType.Text;
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //update ty le zoom vao trong CSDL (chuc nang xem truoc khi in)
        public void UpdateFixZoom(string strBang, double fixZoom, Int64 MaHoSoCapGCN)
        {
            conn = new SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn = Connect();
            }
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Update " + strBang + " set FixZoom =" + fixZoom + " where MaHoSoCapGCN = " + MaHoSoCapGCN + "";
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
            }
        }
        //xoá các bản ghi cũ đã tôn tại để thay bằng các bản ghi mới đã được chỉnh lý
        public void DelRecoreOld(string strBang, Int64 MaHoSoCapGCN, SqlConnection conn)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from  " + strBang + "  where MaHoSoCapGCN =" + MaHoSoCapGCN + " and temp = 'True'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();

        }

        //xoá các bản ghi cũ đã tôn tại để thay bằng các bản ghi mới đã được chỉnh lý
        public void GanLaiDuLieuBanDoVaThuocTinh(string strBang, string  strMaDonViHanhChinh,string strToBanDo,string strSoThua, string  strConnection)
        {
            try
            {
                conn = new SqlConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = strConnection;
                    conn.Open();
                }
                SqlCommand sqlCommand = new SqlCommand(); ;
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "spUpdateLaiThongTinHoSoThuaDat";

                System.Data.SqlClient.SqlParameter MaDonVIhanhChinh = new System.Data.SqlClient.SqlParameter();
                MaDonVIhanhChinh = new System.Data.SqlClient.SqlParameter("@MaDonViHanhChinh", System.Data.SqlDbType.NVarChar, 200);
                MaDonVIhanhChinh.Value = strMaDonViHanhChinh;
                sqlCommand.Parameters.Add(MaDonVIhanhChinh);
                System.Data.SqlClient.SqlParameter ToBanDo = new System.Data.SqlClient.SqlParameter();
                ToBanDo = new System.Data.SqlClient.SqlParameter("@ToBanDo", System.Data.SqlDbType.NVarChar, 200);
                ToBanDo.Value = strToBanDo;
                sqlCommand.Parameters.Add(ToBanDo);
                System.Data.SqlClient.SqlParameter SoThua = new System.Data.SqlClient.SqlParameter();
                SoThua = new System.Data.SqlClient.SqlParameter("@SoThua", System.Data.SqlDbType.NVarChar, 200);
                SoThua.Value = strSoThua;
                sqlCommand.Parameters.Add(SoThua);
                sqlCommand.ExecuteNonQuery();
            }catch(Exception ex){}
        }
        //xoá các bản ghi cũ đã tôn tại để thay bằng các bản ghi mới đã được chỉnh lý
        public void DelRecoreTmp(string strBang, long MaHoSoCapGCN, SqlConnection conn)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from  " + strBang + "  where (temp is null) and (MaHoSoCapGCN =" + MaHoSoCapGCN + ")";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();

        }
        //xoá các bản ghi cũ đã tôn tại để thay bằng các bản ghi mới đã được chỉnh lý
        public string  SelRecoreNew(SqlConnection conn)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select Max(SW_MEMBER) from " + strTenBangDat;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();
            return dt.Rows[0][0].ToString();
          }
        //kiem tra xem ban ghi da ton tai trong bang soan chua, neu chua ton tai thi insert vao ban ghi moi
        public void KitraTonTai(string strBang,string BanDo, long  FeatureID, long MaHoSoCapGCN)
        {
            conn = new SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn = Connect();
            }
            string str;
            str = "select * from " + strBang + " where  MaHoSoCapGCN =" + MaHoSoCapGCN  + ""; //FeatureID =" + FeatureID + "";
            SqlDataAdapter dat = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            dat.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                string strSql;
                strSql = "insert into " + strBang + "(MaHoSoCapGCN, MaDoiTuong,ToBanDo, SoThua, DienTich, FeatureID, TYLEIN, MI_STYLE, SW_GEOMETRY) select '" + MaHoSoCapGCN + "','1001', ToBanDo, SoThua, DienTichTuNhien, SW_member, TYLEIN,  MI_STYLE, SW_GEOMETRY from " + BanDo + " where SW_MEMBER=" + FeatureID.ToString().Split('.')[0] + " and MaDonViHanhChinh = '" + strMaDonViHanhChinh  + "'";
                SqlCommand cmd;
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        //lay thong tin ve thua dat bao gom ten thua va dien tich tu nhien
        public string[] TenThuaDienTich(string BanDo, long FeatureID)
        {
            string[] ThuaDienTich = new string[2];
            string TenThua;
            string DienTich;
            TenThua = "";
            DienTich = "";
            DienTich = GetValueCol(BanDo, "DienTichTuNhien",Convert.ToInt64( FeatureID.ToString().Split('.')[0]));
            TenThua = GetValueCol(BanDo, "SoThua", Convert.ToInt64(FeatureID.ToString().Split('.')[0]));
            ThuaDienTich[0] = TenThua;
            ThuaDienTich[1] = DienTich;
            return ThuaDienTich;
        }
        public DataTable SelectTrangThaiHoSo(string strMaHoSoCapGCN)
        {
            DataTable dt = new DataTable();
                    if (strMaHoSoCapGCN != "")
                    {
                        conn = new SqlConnection();
                        if (conn.State == ConnectionState.Closed)
                        {
                            Connect();
                        }
                        SqlCommand sqlCommand = new SqlCommand(); ;
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "spSelectTrangThaiHoSoCapGCN";

                        System.Data.SqlClient.SqlParameter MaHoSo = new System.Data.SqlClient.SqlParameter();
                        MaHoSo = new System.Data.SqlClient.SqlParameter("@MaHoSoCapGCN", System.Data.SqlDbType.NVarChar,200);
                        MaHoSo.Value = strMaHoSoCapGCN;
                        sqlCommand.Parameters.Add(MaHoSo);
                      
                        sqlCommand.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(dt);
                    }
                    return dt;
        }
          
    }
}
