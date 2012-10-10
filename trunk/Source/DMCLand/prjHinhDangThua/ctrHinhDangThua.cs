using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using MapInfo.Data;
using MapInfo.Mapping;
using MapInfo.Engine;
using MapInfo.Geometry;
using MapInfo.Styles;
using MapInfo.Tools;
using MapInfo.Windows.Controls;
using DMC.GIS.Common;
using MapInfo.Data.Find;
using MapInfo.Text;
using System.Data.SqlClient;
using System;
using DMC.GIS.Common;

namespace prjHinhDangThua
{
    public partial class ctrHinhDangThua : UserControl
    {
        private string strServerName = "";
        /* Khai báo thuộc tính nhận tên máy chủ */
        public string SererName
        {
            set { strServerName = value; }
        }
        /* Khai báo biến nhận Tên cơ sở dữ liệu */
        private string strDatabaseName = "";
        /* Khai báo thuộc tính nhận Tên Cơ sở dữ liệu */
        public string DatabaseName
        {
            set { strDatabaseName = value; }
        }
        /* Khai báo biến nhận UserName */
        private string strUID = "";
        /* Khai báo thuộc tính nhận UserName */
        public string UID
        {
            set { strUID = value; }
        }
        /* Khai báo biến nhận PassWord */
        private string strUpass = "";
        /* Khai báo thuộc tính nhận PassWord*/
        public string Upass
        {
            set { strUpass = value; }
        }
       
        private string strMaDonViHanhChinh = "";
        public string MaDonViHanhChinh
        {
            set { strMaDonViHanhChinh = value; }
            get { return strMaDonViHanhChinh; }
        }
        private string strMaThuaDat = "";
        public string MaThuaDat
        {
            set { strMaThuaDat = value; }
            get { return strMaThuaDat; }
        }
        private string strConnection = "";
        public string Connection
        {
            set { strConnection = value; }
            get { return strConnection; }
        }
        public ctrHinhDangThua()
        {
            InitializeComponent();
        }
        private string strTenBangBanDo = "";

        public string TenBangBanDo
        {
            get { return strTenBangBanDo; }
            set { strTenBangBanDo = value; }
        }
        public  void ctrHinhDangThua_Load()
        {
            HienThiBanDo(mapControl1,"DangThua");
        }
        public void HienThiBanDo(MapControl pMap, string CurentLayerName)
        {
            try
            {
                clsMainSoanHoSo cls = new clsMainSoanHoSo();
                MapInfo.Mapping.FeatureLayer[] lyrs = new MapInfo.Mapping.FeatureLayer[1];
                string str;
                string strConnectionstring = "";
                str = "";
                strConnectionstring = "DRIVER=SQL Server;" + strConnection + ";DLG=SQL_DRIVER_NOPROMPT";
                str = "Select * from " + strTenBangBanDo + " where  SW_member = " + strMaThuaDat + " and MaDonViHanhChinh =" + strMaDonViHanhChinh;
               // strConnectionstring = "DRIVER={SQL Server};SERVER=dmc-svr\\map;UID=sa;PWD=1;DATABASE=georgetown;DLG=SQL_DRIVER_NOPROMPT";
                if (MapInfo.Engine.Session.Current.Catalog.GetTable(CurentLayerName) != null)
                {
                    MapInfo.Engine.Session.Current.Catalog.CloseTable(CurentLayerName);
                }
                Table tab = null;
                tab=cls.GetNewLayer(CurentLayerName, strConnectionstring, str);
                //FeatureLayer fly = new FeatureLayer(tab);
                //mapControl1.Map.Layers.Add(fly);
                //mapControl1.Map.SetView(fly);
                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());
                if (irfc == null)
                {
                    return;
                }
                if (irfc.Count == 0)
                {
                    return;
                }
                //lay tat ca cac doi tuong tim duoc dua len tren mot layer tmp cua ban do
                Table  dt =null;
                if (MapInfo.Engine.Session.Current.Catalog.GetTable("temp") != null)
                {
                    MapInfo.Engine.Session.Current.Catalog.CloseTable("temp");
                }
                dt = cls.CreateDataTable(mapControl1.Map,CurentLayerName, "temp", tab);
                
                CompositeStyle cs = new CompositeStyle();
                foreach (Feature f in irfc)
                {
                    Feature fnew = new Feature(f.Geometry, cs);
                    dt.InsertFeature(fnew);
                }
                FeatureLayer fl = new FeatureLayer(dt);
                mapControl1.Map.Layers.Add(fl);
                mapControl1.Map.SetView(fl);
            }
            catch (FeatureException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
