using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.Land.TachThua
{
    public static  class CommonLand
    {
        /* XEM LẠI CÁC BIẾN TRONG PHẦN NÀY XEM CÓ NHẤT THIẾT PHẢI KHAI BÁO 
         TRONG LỚP DÙNG CHUNG NÀY HAY KHÔNG */
        /* Khai báo biến xác định hành động hiện thời của ứng dụng */
        public  static string stringAction = "";

        /* Khai báo biến với kiểu Feature, lưu trữ thửa cần nắn chỉnh */
        public  static MapInfo.Data.Feature featureEdit = null;
        /* Khai báo biến với kiểu int, lưu trữ thửa cần nắn chỉnh */
        public static int intEdit = 0;

        /* Khai báo biến với kiểu Feature, lưu trữ thửa cần tách */
        public  static MapInfo.Data.Feature featureSplit = null;
        /* Khai báo biến với kiểu int, lưu trữ thửa cần tách */
        public static int intSplit = 0;


        /* Khai báo mảng Feature, lưu trữ những thửa cần ghép */
        public  static MapInfo.Data.Feature[] featuresCombine = null;
        /* Khai báo mảng int lưu trữ những thửa cần ghép */
        public static int[] intCombines = null;

        /* Các thông số thiết lập chế độ bắt dính node */
        public static short shortTolerance = 5;
        public static bool boolSnapEnable = false;

        /* Các thông số thiết lập chế độ hiệu chỉnh bản đồ */
        public static MapInfo.Tools.EditMode EditMode = MapInfo.Tools.EditMode.None;

        /* Các thông số thiết lập chế độ hiển thị lớp bản đồ */
        public static bool boolShowNodes = true ;
        public static bool boolShowCentroids = false;
        public static bool boolShowLineDirection = true ;
        /* -----------------------------------------*/
        /* Độ dài đoạn thẳng cần chia */
        public static decimal dblLineLength = 0 ;
        /* Khoảng cách đoạn đầu cần chia */
        public static double dblDistance = 0.0;
        /* Xác nhận chia đoạn thẳng */
        public static bool boolChiaDoanThang = false;
        /* ------------------------------------------*/
        //public static MapInfo.Mapping.Map map = null;
        public static MapInfo.Windows.Controls.MapControl mapControl = null;
        /* Khai báo biến lưu giữ MÃ ĐƠN VỊ HÀNH CHÍNH HIỆN THỜI */
        public static string  MaDonViHanhChinh = null ;

    }
}
