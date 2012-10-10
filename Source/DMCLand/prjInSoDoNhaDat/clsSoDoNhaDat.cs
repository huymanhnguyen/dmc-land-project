using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapInfo.Windows.Controls;
using MapInfo.Printing;

namespace prjInSoDoNhaDat
{
    class clsSoDoNhaDat
    {
        /* Khai báo biến nhận chuỗi kết nối cơ sở dữ liệu */
        string strConnection = "";
        /* Khai báo biến mã hồ sơ cấp GCN */
        string strMaHoSoCapGCN = "";
        /* Khai báo biến nhận đối tượng bản đồ */
        MapInfo.Mapping.Map mapSoDoNhaDat = null;
        /* Khai báo biến kiểu mảng Byte hình ảnh bản đồ cần in */
        byte[] bytImage = null; 
        /* Khai báo thuộc tính kiểu mảng Byte hình ảnh bản đồ cần in */
        public byte[] Image 
        {
            set { bytImage = value;}
            get { return bytImage;}
        }
        /* Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu */
        public string Connection
        {
            set { strConnection = value; }
            get {return strConnection;} 
        }
        /* Khai báo thuộc tính nhận Mã hồ sơ cấp GCN */
        public string MaHoSoCapGCN
        {
            set { strMaHoSoCapGCN = value; }
            get { return strMaHoSoCapGCN; }             
        }
        /* Khai báo thuộc tính nhận Đối tượng bản đồ */
        public MapInfo.Mapping.Map SoDoNhaDat
        {
            set { mapSoDoNhaDat  = value;}
            get { return mapSoDoNhaDat;}             
        }

    }
}
