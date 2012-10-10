using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    class clsTachThua
    {
        private string[] Paras = { "@MaThuaDat", "@MaThuaDatCon", "@MaDonViHanhChinh" };
        private string strConnection = ""; /* Khai báo biến nhận chuỗi kết nối Database */
        private string strError = "";  /* Khai bao bien kiem tra loi  */
        private long longMaThuaDat = 0;
        private string strMaThuaDatCon = "";
        private string strMaDonViHanhChinh = "";

        public string MaDonViHanhChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
        }
        public string MaThuaDatCon
        {
            get { return strMaThuaDatCon; }
            set { strMaThuaDatCon = value; }
        }
        /* Khai báo thuộc tính nhận chuỗi kết nối Database */
        public string Connection
        {
            set
            {

                strConnection = value;
            }
        }
        /* Khai báo thuộc tính ứng với biến lỗi */
        public string Err
        {
            get
            {
                return strError;
            }
        }

        /* Khai báo thuộc tính ứng với biến Mã thửa đất */
        public long MaThuaDat
        {
            get
            {
                return longMaThuaDat;
            }
            set
            {
                longMaThuaDat = value;
            }
        }

        /// <summary>
        /// Lưu thửa đất vào lịch sử biến động (tblDLieuKGianThuaDatLichSu)
        /// Đồng thời xóa thông tin thửa đất ở bảng hiện thời (tblDLieuKGianThuaDat)
        /// </summary>
        /// <param name="strRecords"></param>
        /// <returns></returns>
        public string LuuLichSuBienDong()
        {
            string strRecords = "";
            //return this.Execute("spLuuLichSuBienDongTachThua", strRecords);
            return this.Execute("spInsertDLieuKGianThuaDatLichSuByTachThua", strRecords);
        }

        /// <summary>
        /// Hàm thực thi thủ tục SQL
        /// </summary>
        /// <param name="strStoreProcedureName">Tên thủ tục SQL cần thực thi</param>
        /// <param name="strRecords"></param>
        /// <returns></returns>
        private string Execute(string strStoreProcedureName, string strRecords)
        {
            try
            {
                /* Khoi tao doi tuong clsSqlDatabase */
                DMC.Database.clsDatabase Database = new DMC.Database.clsDatabase();
                /* Nhận chuỗi kết nối Database */
                Database.Connection = strConnection;
                /*  Neu ket noi co so du lieu thanh cong */
                if (Database.OpenConnection() == true)
                {
                    /* Khai bao mang gia tri */
                    string[] Values = { longMaThuaDat.ToString(), strMaThuaDatCon,  strMaDonViHanhChinh };
                    /* Chắc chắn rằng số tham biến bằng số tham trị */
                    if (Paras.Length != Values.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Giá trị truyền vào không tương thích", "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return "Giá trị truyền vào không tương thích";
                    }
                    /* Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase */
                    Database.ExecuteSP(strStoreProcedureName, Paras, Values, ref strRecords);
                    strError = Database.Err;
                    Database.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return strError;
        }


        ///// <summary>
        ///// Hàm nhận kết quả truy vấn
        ///// </summary>
        ///// <param name="dtResults"> Tên bảng kết quả truy vấn nhận được </param>
        ///// <returns></returns>
        //public string GetData(System.Data.DataTable dtResults)
        //{
        //    try
        //    {
        //        /*  Khởi tạo đối tượng clsDatabase */
        //        DMC.Database.clsDatabase Database = new DMC.Database.clsDatabase();
        //        /* Khai báo nhận chuỗi kết nối Database */
        //        Database.Connection = strConnection;
        //        /* Nếu kết nối thành công */
        //        if (Database.OpenConnection() == true)
        //        {
        //            /* Neu ket noi co so du lieu thanh cong */
        //            /* Khai bao mang gia tri */
        //            string[] Values = { longMaThuaDat.ToString(), longMaHoSoCapGCN.ToString(), longSoHoSo.ToString(), longSoThuTuHoSo.ToString(), dtmThoiGianTiepNhan, dtmNgayNhanDuHoSo, strNoiNhanHoSo };
        //            /* Chắc chắn rằng số tham biến bằng số tham trị */
        //            if (Paras.Length != Values.Length)
        //            {
        //                System.Windows.Forms.MessageBox.Show("Giá trị truyền vào không tương thích", "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        //                return "Giá trị truyền vào không tương thích";
        //            }
        //            /* Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase */
        //            Database.getValue(ref dtResults, "spSelectThongTinTiepNhanHoSoByMaHoSoCapGCN", Paras, Values);
        //            Database.CloseConnection();
        //            strError = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    return strError;
        //}
    }
}
