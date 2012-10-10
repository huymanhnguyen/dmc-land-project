using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MapInfo.Data;
using MapInfo.Mapping;
using MapInfo.Engine;
using MapInfo.Geometry;
using MapInfo.Tools;
using MapInfo.Windows.Controls;
using System.Xml;

using DMC.GIS.Common;
using System.IO;
using MapInfo.Styles;
using System.Data.SqlClient;
namespace TachThua
{
    public partial class ctrlTachThua : UserControl
    {
        public ctrlTachThua()
        {
            InitializeComponent();
            mapControl1.Map.DrawEvent += new MapDrawEventHandler(mapcontrol1_MapDraw);
            mapControl1.Tools.Activating += new ToolActivatingEventHandler(ToolActivating);
            mapControl1.Tools.Activated += new ToolActivatedEventHandler(ToolActivatedFired);
            mapControl1.Tools.Used += new ToolUsedEventHandler(ToolUsed);
            mapControl1.Tools.Ending += new ToolEndingEventHandler(ToolEnding);
            mapControl1.Tools.FeatureAdding += new FeatureAddingEventHandler(FeatureAdding);
            mapControl1.Tools.FeatureAdded += new FeatureAddedEventHandler(FeatureAdded);
            mapControl1.Tools.FeatureSelecting += new FeatureSelectingEventHandler(FeatureSelecting);
            mapControl1.Tools.FeatureSelected += new FeatureSelectedEventHandler(FeatureSelected);
            mapControl1.Tools.FeatureChanging += new FeatureChangingEventHandler(FeatureChanging);

            mapControl1.Tools.FeatureChanged += new MapInfo.Tools.FeatureChangedEventHandler(FeatureChanged);
            mapControl1.Tools.NodeChanging += new NodeChangingEventHandler(NodeChanging);
            mapControl1.Tools.NodeChanged += new NodeChangedEventHandler(NodeChanged);
            mapControl1.Tools.LabelAdding += new LabelAddingEventHandler(LabelAdding);
            mapControl1.Tools.LabelAdded += new LabelAddedEventHandler(LabelAdded);
            mapControl1.Tools.Add("CustomArc", new MyPolygonTool(true, true, true,
              mapControl1.Viewer, mapControl1.Handle.ToInt32(), mapControl1.Tools,
              mapControl1.Tools.MouseToolProperties, mapControl1.Tools.MapToolProperties));
            mapControl1.Tools.Add("CustomPolygon", new MyPolygon(true, true, true,
                mapControl1.Viewer, mapControl1.Handle.ToInt32(), mapControl1.Tools,
                mapControl1.Tools.MouseToolProperties, mapControl1.Tools.MapToolProperties));
            //mapControl1.Tools.Add("CustomPolylineMapTool", new DoVeChieuDai(true, true, true,
            // mapControl1.Viewer, mapControl1.Handle.ToInt32(), mapControl1.Tools,
            // mapControl1.Tools.MouseToolProperties, mapControl1.Tools.MapToolProperties));
            mapControl1.Tools.Add("CustomPolylineMapTool", new DoVeChuViDienTich(true, true, true,
             mapControl1.Viewer, mapControl1.Handle.ToInt32(), mapControl1.Tools,
             mapControl1.Tools.MouseToolProperties, mapControl1.Tools.MapToolProperties));
        }
        private void mapcontrol1_MapDraw(object sender, MapDrawEventArgs e)
        {
            if (mapControl1.Map.Zoom.Value < 30)
            {
                mapControl1.Map.Zoom = new Distance(30, DistanceUnit.Meter);
            }
        }

        public void NhatKyNguoiDung(string ChucNang, string MoTa ,string  strMaThuaDat)
        {
            prjNhatKyNguoiDung.clsNhatKyNguoiDung clsNhatky = new prjNhatKyNguoiDung.clsNhatKyNguoiDung();
            clsNhatky.Connection = strConnection;
            clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN.ToString();
            clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh;
            clsNhatky.MaThuaDat = strMaThuaDat;
            clsNhatky.NghiepVu = "Tách ghép thửa";
            clsNhatky.ChucNang = ChucNang;
            clsNhatky.MoTa = MoTa;
            clsNhatky.DuongDanFile = Application.StartupPath;
            clsNhatky.LuuNhatKyNguoiDung();
        }
        public void ToolActivating(object sender, ToolActivatingEventArgs e)
        {

        }
        public void ToolActivatedFired(object sender, ToolActivatedEventArgs e)
        {

        }
        public void ToolUsed(object sender, ToolUsedEventArgs e)
        { }
        public void ToolEnding(object sender, ToolEndingEventArgs e)
        {
        }
        public void FeatureAdding(object sender, FeatureAddingEventArgs e)
        {
            try
            {          
                e.Cancel = false;
            }
            catch
            {
            }
        }
        public void FeatureAdded(object sender, FeatureAddedEventArgs e)
        {
            try { ExportsFileTab(); }
            catch (Exception ex) { }
        }
        public void FeatureSelecting(object sender, FeatureSelectingEventArgs e)
        {
            e.Cancel = false;
        }
        public void FeatureSelected(object sender, FeatureSelectedEventArgs e)
        {
            //hien thi thong so chieu dai len thanh taskbar
            txtChieuDaiDoanThangChia.Text = GetChieuDai(mapControl1, LayerName).ToString();
            //hien thi thong so dien tich thua len thanh taskbar
            DMC.GIS.Common.FeatureInfo featureInfo = new DMC.GIS.Common.FeatureInfo();
            string s = "";
            s = featureInfo.GetSelectedLandID(mapControl1.Map, "Đất", "SW_Member");
            FeatureID = Convert.ToInt32(featureInfo.GetSelectedLandID(mapControl1.Map, "Đất", "SW_Member"));
            //load danh sach toa do, he so goc , chieu dai 
            ToaDo(mapControl1, LayerName);

            toolStaDienTichTrenBanDo.Text = "       Diện tích đo trên bản đồ:  " + System.Math.Round(GetDienTich(mapControl1, TenLopDat), 2).ToString() + " (m2)";
        }
        //lay thogn tin ve dien tich cua doi tuong duoc chon
        public double GetDienTich(MapControl map, string LayerName)
        {
            double mySize, areaSize;
            mySize = 0.0;
            areaSize = 0.0;
            Table tab = null;
            //lay bang hien thoi
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tất cả các đối tượng được chọ
            IResultSetFeatureCollection Lfc = Session.Current.Selections.DefaultSelection[tab];
            if ((Lfc == null) || (Lfc.Count == 0))
            {
                return 0.0;
            }
            foreach (Feature f in Lfc)
            {
                try
                {
                    //nếu đối tượng được chọn là MultiPolygon
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                    {
                        MultiPolygon plg = (MultiPolygon)f.Geometry;
                        foreach (Polygon pl in plg)
                        {
                            //tính diện tích thửa
                            mySize = pl.Area(AreaUnit.SquareMeter, DistanceType.Spherical);
                            areaSize = areaSize + mySize;                            
                        }

                    }
                }
                catch (Exception ex) { }
            }
            return areaSize;
        }
        public void FeatureChanging(object sender, FeatureChangingEventArgs e)
        {
            ExportsFileTab();
        }
        public void NodeChanging(object sender, NodeChangingEventArgs e)
        {
            ExportsFileTab();
        }
        public void FeatureChanged(object sender, MapInfo.Tools.FeatureChangedEventArgs e)
        { }
        public void NodeChanged(object sender, NodeChangedEventArgs e)
        {
        }
        public void LabelAdding(object sender, LabelAddingEventArgs e)
        {
            ExportsFileTab();
            e.Cancel = false;
        }
        public void LabelAdded(object sender, LabelAddedEventArgs e)
        {
        }
        public void ToaDo(MapControl pMap, string LayerName)
        {
            //goi du lieu bang hien thoi
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //   MapInfo.Data.Feature myfc = MapInfo.Engine.Session.Current.Catalog.SearchForFeature(table, MapInfo.Data.SearchInfoFactory.SearchWhere("SW_Member = " + FeatureID + ""));
            //tim tat ca cac doi tuong duoc chon dua vao mang
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            FeatureLayer Lyr = pMap.Map.Layers[LayerName] as FeatureLayer;
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count == 0)
            {
                return;
            }
            DPoint[] d = null;
            foreach (Feature f in irfc)
            {
                try
                {
                    //neu doi tuong multiPolygon
                    if (f.Geometry.GetType().ToString() == "MapInfo.Geometry.MultiPolygon")
                    {
                        MultiPolygon plg = (MultiPolygon)f.Geometry;
                        int SoLan = 0;
                        int STT = 0;
                        foreach (Polygon pl in plg)
                        {
                            //lấy tập hợp các điểm của thửa
                            d = pl.Exterior.SamplePoints();
                            //khai báo mảng các đối tượng về toạ độ X,Y, Hệ số góc và chiều dài
                            string[] ValueX = new string[d.Length];
                            string[] ValueY = new string[d.Length];
                            string[] ValueHSGoc = new string[d.Length];
                            String[] HeSoGoc = new string[d.Length];
                            string[] ValueChieuDai = new string[d.Length];
                            //lay thong tin ve toa do X,Y cua cac dinh
                            for (int i = 0; i < d.Length - 1; i++)
                            {
                                double MySize;
                                MySize = 0.0;
                                if ((i == 0))
                                {
                                    MySize = Math.Round(System.Math.Sqrt((d[d.Length - 2].x - d[0].x) * (d[d.Length - 2].x - d[0].x) + (d[d.Length - 2].y - d[0].y) * (d[d.Length - 2].y - d[0].y)), 2);
                                }
                                else
                                {
                                    MySize = Math.Round(System.Math.Sqrt((d[i].x - d[i - 1].x) * (d[i].x - d[i - 1].x) + (d[i].y - d[i - 1].y) * (d[i].y - d[i - 1].y)), 2);
                                }

                                //lay toa do X
                                ValueX[i] = d[i].x.ToString();
                                //Lay toa do theo Y
                                ValueY[i] = d[i].y.ToString();
                                //begin lay thogn so chieu dai
                                ValueChieuDai[i] = MySize.ToString();

                            }
                            //Begin Tinh toa do goc cua cac dinh
                            int j, k;
                            for (int i = 0; i < d.Length - 1; i++)
                            {
                                j = i + 1;
                                k = j + 1;
                                if (i == d.Length - 3)
                                {
                                    j = d.Length - 2;
                                    k = 0;
                                }
                                if (i == d.Length - 2)
                                {
                                    j = 0;
                                    k = 1;
                                }
                                ValueHSGoc[i] = Math.Round(cls.HeSoGoc3Dinh(f, d[i], d[j], d[k]), 2).ToString();


                            }
                            for (int i = 0; i < ValueHSGoc.Length - 1; i++)
                            {
                                if (i == 0)
                                {
                                    HeSoGoc[i] = ValueHSGoc[ValueHSGoc.Length - 2];
                                }
                                else
                                {
                                    HeSoGoc[i] = ValueHSGoc[i - 1];
                                }
                            }
                            if (SoLan == 0)
                            {
                                TaoPan(d.Length, ValueX, ValueY, HeSoGoc, ValueChieuDai, SoLan, STT);
                                STT = d.Length - 1;
                            }
                            else
                            {
                                TaoPan(d.Length, ValueX, ValueY, HeSoGoc, ValueChieuDai, SoLan, STT);
                                STT = d.Length - 1;
                            }
                            SoLan = SoLan + 1;
                        }

                        //end--------------------
                    }
                }
                catch (Exception ex) { }
            }
        }
        //lay he so goc cua 3 dinh khi biett toa do 3 dinh do
        public double GetAlpha(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double HeSoGoc;
            HeSoGoc = 0.0;
            double goc;
            DPoint p1 = new DPoint();
            DPoint p2 = new DPoint();
            DPoint p3 = new DPoint();
            p1.x = x1;
            p1.y = y1;
            p2.x = x2;
            p2.y = y2;
            p3.x = x3;
            p3.y = y3;
            //he so goc duoc tinh theo cong thuc
            //vecter u(a1,b1),v(a2,b2) qua 2 duong thang p2p1,p2p3 => cos (goc)=(a1a2 + b1b2)/(sqrt(a1&a1 + b1*b1)* sqrt(a1*a1 + b2*b2))
            goc = ((p1.x - p2.x) * (p3.x - p2.x) + (p1.y - p2.y) * (p3.y - p2.y)) / (Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y)) * Math.Sqrt((p3.x - p2.x) * (p3.x - p2.x) + (p3.y - p2.y) * (p3.y - p2.y)));

            HeSoGoc = Math.Round(Math.Acos(goc) * 180 / Math.PI, 2);
            return HeSoGoc;
        }
        //tao danh sach toa do
        public void TaoPan(int Count, string[] ValueX, string[] ValueY, string[] ValueHSGoc, string[] ValueChieuDai, int SoLan, int STT)
        {
            //solan la truong hop thua dat co nhieu  multiPolygon
            if (SoLan == 0)
            {
                grDanhSachToaDo.Rows.Clear();
                grDanhSachToaDo.Height = 26;
                panToaDo.Height = 85;
            }
            //add tat ca cac thong tin ve toa do x,y, he so goc, chieu dai vao Grid
            for (int i = 0; i < Count - 1; i++)
            {
                grDanhSachToaDo.Height = 250;
                panToaDo.Height = 310;
                DataGridViewRow dr = new DataGridViewRow();
                grDanhSachToaDo.Rows.Add(dr);
                grDanhSachToaDo.Rows[STT + i].Cells[0].Value = false;
                grDanhSachToaDo.Rows[STT + i].Cells[1].Value = STT + i + 1;
                grDanhSachToaDo.Rows[STT + i].Cells[2].Value = ValueX[i];
                grDanhSachToaDo.Rows[STT + i].Cells[3].Value = ValueY[i];
                grDanhSachToaDo.Rows[STT + i].Cells[4].Value = ValueHSGoc[i];
                grDanhSachToaDo.Rows[STT + i].Cells[5].Value = ValueChieuDai[i];
            }
        }
        public double GetChieuDai(MapControl map, string LayerName)
        {
            Table tab = null;
            double MySize, LineSize;
            MySize = 0.0;
            LineSize = 0.0;
            //lay bang hiện thời
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tất cả các đối tượng được chọn
            IResultSetFeatureCollection Lfc = Session.Current.Selections.DefaultSelection[tab];
            if ((Lfc == null) || Lfc.Count == 0)
            {
                return 0.0;
            }
            foreach (Feature f in Lfc)
            {
                try
                {
                    //Nếu là đối tượng multiCurve
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                    {
                        MultiCurve plg = (MultiCurve)f.Geometry;
                        foreach (Curve pl in plg)
                        {//gán chiều dài
                            MySize = System.Math.Round(pl.Length(DistanceUnit.Meter, DistanceType.Cartesian), 2);
                            LineSize = LineSize + MySize;
                        }

                    }
                }
                catch (Exception ex) { }
            }
            return LineSize;

        }
        //MapInfo.Mapping.Legends.Legend legend;
        /* Khai báo và khởi tạo đối tượng */
        //DLayers DMCGISActiveX = new DLayers();
        ///* Khai báo biến xác định hành động hiện thời của ứng dụng */
        //static string  strAction = "";
        ///* Khai báo biến với kiểu Feature, lưu trữ thửa cần tách */
        //static MapInfo.Data.Feature featureEdit = null;
        ///* Khai báo biến với kiểu Feature, lưu trữ thửa cần tách */
        //static MapInfo.Data.Feature featureSplit = null;
        ///* Khai báo mảng Feature, lưu trữ những thửa cần ghép */
        //static MapInfo.Data.Feature[]  featuresCombine = null;

        /* KHAI BÁO CÁC FIELD VÀ PROPERTIES */
        /* Khai báo chuỗi kết nối */


        public event MouseEventHandler ChonHoSoTuThuaDat;
        private string strConnection = "";
        public string Connection
        {
            get { return strConnection; }
            set { strConnection = value; }
        }
        /* Khai báo Mã đơn vị hành chính */
        private string strMaDonViHanhChinh = "";
        public string MaDonViHanhChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
        }
        /* Khai báo Mã thửa đất */
        private string strMaThuaDat = "";
        public string MaThuaDat
        {
            get { return strMaThuaDat; }
            set
            {
                if (value == "")
                    strMaThuaDat = "0";
                else
                    strMaThuaDat = value;
            }
        }
        private string strToBanDo = "";
        public string ToBanDo
        {
            get { return strToBanDo; }
            set { strToBanDo = value; }
        }
        private string strSoThua = "";
        public string SoThua
        {
            get { return strSoThua; }
            set { strSoThua = value; }
        }
        /* Khai báo biến kiểu bool xác nhận bản đồ tổng thể đã được hiển thị */
        private bool boolMapShowed = false;
        public bool MapShowed
        {
            get { return boolMapShowed; }
            set
            {
                boolMapShowed = value;
            }
        }
        /* Khai báo Mã hồ sơ cấp GCN */
        private string strMaHoSoCapGCN = "";
        public string MaHoSoCapGCN
        {
            get { return strMaHoSoCapGCN; }
            set { strMaHoSoCapGCN = value; }

        }

        public static CoordSys coordsys;
        public static double ChieuDaiCanh = 0;
        public static double ChuViDo = 0;
        public static double DienTichDo = 0;
         public bool TrangThaiPhucHoi = true;
        private string OldKey;
        private string MyCurso;
        private string LayerName = "Thua_Dat";
        private string TenLopDat = "Đất";
        private string[] DoiTuongCopy;
        private string strTenBangDat = "";//"tblDuLieuKhongGianThuaDat";

        public string TenBangDat
        {
            get { return strTenBangDat; }
            set { strTenBangDat = value; }
        }
        private bool DiChuyenDinhThua = false;
        private int intUndo = 0;
        private bool EditThuaDat=false ;
        private CompositeStyle CopyStyle = null;
        private DPoint MousePointEnd;
        private int SizeMapWidth = 0;
        private int SizeMapHeigt = 0;
        private int FeatureID;
        private DPoint DiemCuoiChonThua;
        private DPoint GanDinhVaoVung;
        private double toolX;
        private double toolY;
        private DMC.GIS.Common.clsMainSoanHoSo cls = new clsMainSoanHoSo();
        public static MapInfo.Tools.EditMode EditMode = MapInfo.Tools.EditMode.None;



        /// <summary>
        /// Hiển thị bản đồ tổng thể
        /// Note: Cần xem lại phương thức này để chuẩn hóa lại
        /// </summary>
        /// <param name="strLandTableName">Tên bảng Đất - Trong cơ sở dữ liệu</param>
        /// <param name="strLandTableAliasName">Tên bí danh bảng đất - Hiển thị trên Form</param>
        /// <param name="strBuildingTableName">Tên bảng nhà - Trong cơ sở dữ liệu</param>
        /// <param name="strBuildingTableAliasName">Tên bí danh bảng nhà - Hiển thị trên Form </param>
        /// <param name="strQuiHoachTableName">Tên bảng Qui Hoạch - Trong cơ sở dữ liệu</param>
        /// <param name="strQuiHoachTableAliasName">Tên bí danh bảng Qui hoạch - Hiển thị trên Form </param>/// 
        public void HienThiBanDoTongThe(string strLandTableName, string strLandTableAliasName
            , string strBuildingTableName, string strBuildingTableAliasName
            , string strQuiHoachTableName, string strQuiHoachTableAliasName)
        {

            // kiem tra xem đơn vị hành chính là phường hay quận
            DataTable dt = new DataTable();
            DMC.Land.TachThua.clsHoSoCapGCN cls = new DMC.Land.TachThua.clsHoSoCapGCN();
            cls.Connection = strConnection;
            dt = cls.SelMaQuan(strMaDonViHanhChinh);

            string [] strDVHCQuan = new string[dt.Rows .Count ] ;
            
            if (dt.Rows.Count == 1)
            {
                strDVHCQuan[0] = dt.Rows[0][0].ToString();
            }
            else { }
            if (dt.Rows.Count > 1)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    strDVHCQuan[i] = dt.Rows[i][0].ToString();
                }
            
            }
            // hiển thị bản đồ quy hoach và bản đồ nhà
           // HienThiBanDoQuyHoach(strDVHCQuan);

            /* Khai báo lớp các chức năng bản đồ dùng chung */
            DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
            /* Gán giá trị cho biến dùng chung */
            DMC.Land.TachThua.CommonLand.mapControl = mapTools.ShowMap(mapControl1, strConnection, strLandTableName, strLandTableAliasName
                , strBuildingTableName, strBuildingTableAliasName 
                , strQuiHoachTableName, ""
                , strMaDonViHanhChinh);

           HienThiBanDoQuyHoach(strDVHCQuan);
            //lyrControl.Map.Layers[strBuildingTableAliasName].Enabled = false;
            //lyrControl.Map.Layers[strQuiHoachTableAliasName].Enabled = false;
            coordsys = mapControl1.Map.GetDisplayCoordSys();
            /* Gán giá trị cho biến đơn vị hành chính dùng chung
             bằng THUỘC TÍNH MÃ ĐƠN VỊ HÀNH CHÍNH của lớp*/
            DMC.Land.TachThua.CommonLand.MaDonViHanhChinh = strMaDonViHanhChinh;
            /* Add Menu cho Bản đồ và cho các lớp trên bản đồ trong sự kiện click chuột phải lên LayerControl */
            AddChooseCoordSysMenuitem();
             //MapInfo.Geometry.CoordSys coordSys = Session.Current.CoordSysFactory.CreateLongLat(DatumID.IndianThailandVietnam );
             //mapControl1.Map.SetDisplayCoordSys(coordSys);
            AddLayerMenu();
        }

        #region "Mo ban do quy hoach va nha"
       
        //thuc hien viec load tham 1 ban do moi
        public void HienThiBanDoQuyHoach(string[] mMaDonViHanhChinh)
        {
            try
            {
                
                //xoa tat ca cac file trong thu muc chua
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\HienThiFileQuyHoach\");
                FileInfo[] file = dir.GetFiles("*.tab");
                string pathDir = Application.StartupPath + @"\HienThiFileQuyHoach\";
                // xoa file tmp khi undo den giai doan giua rui lam tiep
                for (int i = 0; i < file.Length; i++)
                {
                    XoaFileTmp(pathDir, file[i].Name);
                }

                // xuat ra file tab tu csdl
                string MaDonViHanhChinh = "";
                int dem = 0;
                dem = mMaDonViHanhChinh.Length    ;

                if (dem == 1)
                {
                    MaDonViHanhChinh = mMaDonViHanhChinh[0].ToString ();
                    toolXuatFileMap(MaDonViHanhChinh);
                }
                if (dem > 1)
                {
                    for (int i = 0; i <= dem - 1; i++)
                    {
                        MaDonViHanhChinh = mMaDonViHanhChinh[i].ToString();
                        toolXuatFileMap(MaDonViHanhChinh);
                    }
                
                }
                

                //Mo file da xuat ra
                // dong tat ca cac lay o hien thoi
               // mapControl1.Map.Layers.Clear();
                FileInfo[] fileLoad = dir.GetFiles("*.tab");
                for (int i = 0; i < fileLoad.Length; i++)
                {
                    // MapInfo.Data.Table NameLayer = MapInfo.Engine.Session.Current.Catalog.GetTable(NameLayer);
                    MapInfo.Data.Table NameLayer = MapInfo.Engine.Session.Current.Catalog.OpenTable(dir + "\\" + fileLoad[i].Name);
                    FeatureLayer fl = new FeatureLayer(NameLayer);
                    mapControl1.Map.Layers.Add(fl);
                    lyrControl.Map.Layers[NameLayer.Alias].Enabled = false; 
                }
            }
            catch (FeatureException ex)
            {
                MessageBox.Show("Mở bản đồ không thành công !!!", "Thông báo");
            }
        }
        // thu tuc xoa file temp
        public void XoaFileTmp(string dir, string fileName)
        {
            string tabFile, datFile, idFile, mapFile;
            System.IO.FileInfo tabFileObj = new System.IO.FileInfo(dir + "\\" + fileName.ToUpper());
            tabFile = tabFileObj.Name.ToString();

            datFile = tabFileObj.Name.Replace(".TAB".ToUpper(), ".DAT".ToUpper());
            System.IO.FileInfo datFileObj = new System.IO.FileInfo(dir + "\\" + datFile);
            idFile = tabFileObj.Name.Replace(".TAB".ToUpper(), ".ID".ToUpper());
            System.IO.FileInfo idFileObj = new System.IO.FileInfo(dir + "\\" + idFile);
            mapFile = tabFileObj.Name.Replace(".TAB".ToUpper(), ".MAP".ToUpper());
            System.IO.FileInfo mapFileObj = new System.IO.FileInfo(dir + "\\" + mapFile);

            tabFileObj.Delete();
            datFileObj.Delete();
            idFileObj.Delete();
            mapFileObj.Delete();

        }
        private void toolXuatFileMap(string MaDonViHanhChinh)
        {
            DataTable dt = new DataTable();
            dt = GetFileMap(0, MaDonViHanhChinh);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string LayerName = "";
                    LayerName = dt.Rows[i]["LayerName"].ToString();
                    if (WriteFile(LayerName, "tab", (byte[])dt.Rows[i]["FileTab"]) == false)
                    {
                        MessageBox.Show(" Không export được file Tab");
                        return;
                    }
                    if (WriteFile(LayerName, "Dat", (byte[])dt.Rows[i]["FileDat"]) == false)
                    {
                        MessageBox.Show(" Không export được file Dat");
                        return;
                    }
                    if (WriteFile(LayerName, "ID", (byte[])dt.Rows[i]["FileID"]) == false)
                    {
                        MessageBox.Show(" Không export được file ID");
                        return;
                    }
                    if (WriteFile(LayerName, "Map", (byte[])dt.Rows[i]["FileMap"]) == false)
                    {
                        MessageBox.Show(" Không export được file Map");
                        return;
                    }
                }
            }
        }
        //thuc thi viec them doi tuong vao Layer
        public byte[] GhiFileMap(string LayerName, string KieuFile)
        {
            string file = "";
            byte[] byfile;
            string fileName = "";
            fileName = Application.StartupPath;
            //lay duong dan file du lieu temp can tao ra
            file = fileName + @"\tmpFileQuyHoach\" + LayerName + "." + KieuFile;
            byfile = ReadFile(file);
            return byfile;
        }
        public byte[] ReadFile(string strPath)
        {
            //'Initialize byte array with a null value initially.
            byte[] byteData;
            //'Use FileInfo object to get file size.
            FileInfo fInfo = new System.IO.FileInfo(strPath);
            long numBytes;
            numBytes = fInfo.Length;
            //'Open file stream de doc file
            FileStream fStream;
            fStream = new System.IO.FileStream(strPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //'Use BinaryReader to read file stream into byte array.
            System.IO.BinaryReader br = new System.IO.BinaryReader(fStream);
            //'When you use BinaryReader, you need to supply number of bytes to read from file.
            //'In this case we want to read entire file. So supplying total number of bytes.
            byteData = br.ReadBytes((int)numBytes);
            return byteData;
        }
        public bool WriteFile(string LayerName, string KieuFile, byte[] byteContent)
        {
            FileStream objFstream = null;
            try
            {
                objFstream = File.Open(Application.StartupPath + @"\HienThiFileQuyHoach\" + LayerName + "." + KieuFile, FileMode.Create, FileAccess.Write);
                long lngLen = byteContent.Length;
                objFstream.Write(byteContent, 0, (int)lngLen);
                objFstream.Flush();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Lỗi ghi dữ liệu: " + ex.Message);
                return false;
            }
            finally
            {
                objFstream.Close();
            }
        }
        //ham ket noi co so du lieu
        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                string strConnec;
                strConnec = "";

                strConnec = strConnection;
                conn.ConnectionString = strConnec;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối =>>" + ex.Message);
            }
            return conn;
        }
        public DataTable GetFileMap(int flag, string MaDonViHanhChinh)
        {
            DataTable dt = new DataTable();
            if ((MaDonViHanhChinh != "") & (MaDonViHanhChinh != "") & (MaDonViHanhChinh != "0"))
            {
                SqlConnection conn = new SqlConnection();
                conn = Connect();

                SqlCommand sqlCommand = new SqlCommand(); ;
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "spThongTinFileDLIEUKGIANNHANQUIHOACH";

               
                System.Data.SqlClient.SqlParameter MaHoSo = new System.Data.SqlClient.SqlParameter();
                MaHoSo = new System.Data.SqlClient.SqlParameter("@MaDonViHanhChinh", System.Data.SqlDbType.NVarChar, 20);
                MaHoSo.Value = MaDonViHanhChinh;
                sqlCommand.Parameters.Add(MaHoSo);
                System.Data.SqlClient.SqlParameter intflag = new System.Data.SqlClient.SqlParameter();
                intflag = new System.Data.SqlClient.SqlParameter("@flag", System.Data.SqlDbType.Int);
                intflag.Value = flag;
                sqlCommand.Parameters.Add(intflag);

                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(dt);
            }
            return dt;
        }
        # endregion
        /// <summary>
        /// Hiển thị THỬA ĐẤT được lựa chọn theo Mã thửa đất trên bản đồ tổng thể
        /// </summary>
        public void HienThiThuaDat(string strLandTableAliasName)
        {
            /* Chắc chắn rằng tồn tại tên bí danh của lớp đất */
            if (strLandTableAliasName.Trim() == "")
                return;
            /* Khai báo lớp các chức năng bản đồ dùng chung */
            DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
            mapTools.ShowLand(mapControl1.Map, strLandTableAliasName, strMaThuaDat, strMaDonViHanhChinh);

        }
   
        private void SetupLoad()
        {
            /* Đặt tên cho bản đồ */
            mapControl1.Map.Name = "Bản đồ địa chính";
            mapControl1.Map.Zoom = new MapInfo.Geometry.Distance(1500, DistanceUnit.Meter);
            /*******************************************************************************************/
            //MapInfo.Mapping.VisibleRange visRange = new MapInfo.Mapping.VisibleRange(0, true, 10, false , MapInfo.Geometry.DistanceUnit.Meter);
            //FIX ZOOM 
            //MapInfo.Mapping.FeatureLayer featureLayer = (FeatureLayer)mapControl1.Map.Layers[LayerName];
            //featureLayer.VisibleRangeEnabled = false;
            //featureLayer.VisibleRange = new MapInfo.Mapping.VisibleRange(1, true, 15, false, DistanceUnit.Meter);
            //featureLayer.VisibleRange.Within(mapControl1.Map.Zoom);
            //ZoomIn(mapControl1.Map.Zoom.Value);
            //ZoomOut(mapControl1.Map.Zoom.Value);
            /*******************************************************************************************/

            /* Không hiển thị ToolTip */
            lyrControl.ToolTip.Active = false;

            lyrControl.Map = mapControl1.Map;
            lyrControl.Tools = mapControl1.Tools;
            lyrControl.CheckBoxes = true;
            lyrControl.TabControl.Visible = false;
            lyrControl.ToolBar.Buttons[0].Visible = false;
            lyrControl.ToolBar.Buttons[1].Visible = false;
            lyrControl.ToolBar.Buttons[2].Visible = false;
            mapToolBar.MapControl.Map = mapControl1.Map;
            mapToolBar.MapControl.Tools = mapControl1.Tools;
           
        }
        //   // thiết lập giá trị zoomin
        //public void ZoomIn(Double times)  
        //    {  
        //        if(times<1 || times>10) return;
        //        MapInfo.Geometry.Distance previousZoom=this.mapControl1.Map.Zoom;   
        //        mapControl1.Map.Zoom=new MapInfo.Geometry.Distance(previousZoom.Value/(2*times),previousZoom.Unit);
        //        mapToolBarButtonZoomIn.Visible = true;
        //    }
        //// thiết lập giá trị zoomout
        //public void ZoomOut(Double times)  
        //{  
        //        if(times<1 || times>10) return;  
        //        MapInfo.Geometry.Distance previousZoom=this.mapControl1.Map.Zoom;  
        //        mapControl1.Map.Zoom=new MapInfo.Geometry.Distance(previousZoom.Value*(2*times),previousZoom.Unit);
        //        mapToolBarButtonZoomOut.Visible = true;
        //}  

        private void ctrlTachThua_Load(object sender, EventArgs e)
        {

            try
            {
                SetupLoad();
                panDiem.Hide();
                panThemDanhSachToaDo.Hide();
                panToaDo.Hide();
                panXoayDoiTuong.Hide();
                panThemDiemLamGocXoay.Hide();
                panToaDoDiem.Hide();
                panKhoangCachChia.Hide();
                panBanKinhDuongTron.Hide();
                panTamDuongTron.Hide();
                panViTriDiemChuyen.Hide();
                intUndo = 0;
                ExportsFileTab();
                LoadThongTinTobanDoSoThuaTrungLap();
                
            }
            catch {  
            }


            //////////*************************//////////////////////////////
           ////// Du lieu Hoang Mai se chay doan lenh nay tru phuong Hoang Liet
            //if (strMaDonViHanhChinh != "100337" && strMaDonViHanhChinh!= "100334") 
            //{
            //    MapInfo.Geometry.CoordSysFactory miCSF = new MapInfo.Geometry.CoordSysFactory();
            //    MapInfo.Geometry.CoordSys LatLongCSys = default(MapInfo.Geometry.CoordSys);//Earth Projection 8, 104, "m", 105, 0, 0.9996, 500000, 0 Bounds (-7745844.29597, -9997964.94324) (8745844.29597, 9997964.94324)
            //    string s = "CoordSys Earth Projection 8, 9999, 28, -191.90441429, -39.30318279, -111.45032835, -0.00928836, 0.01975479, -0.00427372, 0.252906278, 0," + (char)34 + "m" + (char)34 + ", 105, 0, 0.9996, 500000, 0 Bounds (-7745844.29597, -9997964.94324) (8745844.29597, 9997964.94324)";
            //    LatLongCSys = miCSF.CreateFromMapBasicString(s);
            //    if (LatLongCSys != mapControl1.Map.GetDisplayCoordSys())
            //    {
            //        mapControl1.Map.SetDisplayCoordSys(LatLongCSys);
            //    }
            //    else 
            //    { 
            //    }
            //}

           

        /////
        }

        #region Chọn hệ tọa độ
        private void AddChooseCoordSysMenuitem()
        {
            // Create a new menuitem, which calls the MenuItemChooseCoordSys
            // method (see below). 
            MenuItem chooseCoordSysMenuItem = new MenuItem("&Chọn hệ tọa độ...",
                new System.EventHandler(this.MenuItemChooseCoordSys));

            // Each type of object that can appear in the layer tree 
            // has a collection of menuitems displayed when the user
            // right-clicks.  Obtain a reference to that collection, 
            // and add our new menuitem to the collection. 
            System.Collections.IList menuItems =
                lyrControl.GetLayerTypeMenuItems(typeof(MapInfo.Mapping.Map));
            /* Xóa menu mặc định */
            menuItems.Clear();

            // Insert a separator and a new menuitem to the collection of menuitems.  
            menuItems.Add(new MenuItem("-"));
            menuItems.Add(chooseCoordSysMenuItem);
        }
        // The method called when the user chooses the Choose Coordinate System menuitem
        private void MenuItemChooseCoordSys(Object sender, System.EventArgs e)
        {
            if (mapControl1.Map.IsDisplayCoordSysReadOnly)
            {
                // We cannot allow the user to change the coordinate system if 
                // the coordinate system is locked due to a raster layer. 
                //MessageBox.Show("Coordinate system is currently restricted, due to a raster layer.");
            }
            else
            {
                MapInfo.Windows.Dialogs.CoordSysPickerDlg csysDlg = new MapInfo.Windows.Dialogs.CoordSysPickerDlg();
                csysDlg.SelectedCoordSys = mapControl1.Map.GetDisplayCoordSys();
                if (csysDlg.ShowDialog(this) == DialogResult.OK)
                {
                    CoordSys csysNew = csysDlg.SelectedCoordSys;
                    if (csysNew != mapControl1.Map.GetDisplayCoordSys())
                    {
                        mapControl1.Map.SetDisplayCoordSys(csysNew);
                    }
                }
            }
        }

        #endregion
        #region Hiển thị LayerMenu
        private void AddLayerMenu()
        {
            // Add custom items to the FeatureLayer and LabelSource menus
            MapInfo.Samples.LayerControl.LayerControlEnhancer lce = new MapInfo.Samples.LayerControl.LayerControlEnhancer();
            lce.LayerControl = lyrControl;
            MapInfo.Mapping.Map map;
            map = mapControl1.Map;
            lce.AddLayerToLabelEnhancement(ref map);

            /* Test : Không hiển thị LableLayer Children */
            // Obtain the helper object that is being used to dictate the
            // behavior of LabelLayer nodes in the layer tree.
            MapInfo.Windows.Controls.ILayerNodeHelper labelLayerHelper =
                lyrControl.GetLayerTypeHelper(typeof(MapInfo.Mapping.LabelLayer));

            // Reconfigure the helper to specify that it should NOT display 
            // any "child" nodes.  By default, each LabelLayer does show a  
            // child node for each LabelSource in the layer.  Setting 
            // ShowChildren to false will cause LayerControl to not display
            // any nodes for LabelSource objects.  This simplifies the layer
            // tree, and prevents the user from seeing properties of 
            // individual LabelSources (which might or might not be 
            // appropriate for your application). 
            labelLayerHelper.ShowChildren = false;

            // Change which image is displayed for LabelLayer nodes.  
            // In this example we will set all LabelLayer nodes to display
            // with the icon that is ordinarly used for LabelSource nodes.
            ILayerNodeHelper labelSourceHelper =
                lyrControl.GetLayerTypeHelper(typeof(LabelSource));

            labelLayerHelper.Image = labelSourceHelper.Image;
            /* EndTest */

        }
        #endregion
     
        private void mapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (mapToolBar.Buttons["toolBarButtonDoChieuDaiCanh"].Pushed)
            //{
            //    toolStripStatusChieuDaiCanh.Text = "Chiều dài cạnh: " + ChieuDaiCanh + " (m)";
            //}

            try
            {
                if (mapToolBar.Buttons["toolBarButtonChuViDienTich"].Pushed)
                {
                    toolStripStatusChieuDaiCanh.Text = "Chiều dài cạnh: " + ChieuDaiCanh + " (m)";
                    toolStripStatusChuVi.Text = "Chu vi: " + ChuViDo + " (m)";
                    toolStripStatusDienTich.Text = "Diện tích: " + DienTichDo + " (m2)";
                }
                DMC.GIS.Common.MapTools convertDisplayPoint = new DMC.GIS.Common.MapTools();
                MapInfo.Geometry.DPoint pointMap = convertDisplayPoint.ConvertDisplayPointToMapPoint(mapControl1.Map, e.X, e.Y);
                string strZoom = mapControl1.Map.Zoom.Value.ToString();
                string strZoomUnit = mapControl1.Map.Zoom.Unit.ToString();
                this.statusStrip1.Items[0].Text = "Zoom: " + strZoom + " " + strZoomUnit + "; " + "Vị trí di chuột: " + pointMap.x.ToString() + ", " + pointMap.y.ToString();
                DPoint P = new DPoint();
                System.Drawing.PointF pointf = new System.Drawing.PointF();
                pointf.X = e.X;
                pointf.Y = e.Y;
                P = cls.ConvertDpoint(pointf, mapControl1);
                toolX = P.x;
                toolY = P.y;
                MousePointEnd = cls.ConvertDpoint(pointf, mapControl1);
            }
            catch
            {
               
            }
            
            

        }

        private void mapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            /* Nếu click chuột phải thì hiển thị Menu chức năng */
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuTachThua.Show(mapControl1, e.Location);
            }
            /* Nếu click chuột trái thì nhận ID thửa đất nếu có */
            else if (e.Button == MouseButtons.Left)
            {

            }
        }


        private void frmTachThua2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // toggle snap mode if user presses the 'S' key
            if (e.KeyChar == 's')
                mapControl1.Tools.MapToolProperties.SnapEnabled
                    = !mapControl1.Tools.MapToolProperties.SnapEnabled;
        }

        private void toolSnap_Click(object sender, EventArgs e)
        {
            frmSnapPoints snapPoint = new frmSnapPoints();
            snapPoint.ShowDialog();
            DMC.GIS.Common.MapTools mapTool = new DMC.GIS.Common.MapTools();
            mapTool.SnapEnable(mapControl1, DMC.Land.TachThua.CommonLand.shortTolerance, DMC.Land.TachThua.CommonLand.boolSnapEnable);
        }

        private void toolConvertToLines_Click(object sender, EventArgs e)
        {
            DMC.GIS.Common.FeatureTools convertFeatures = new FeatureTools();
            convertFeatures.BreakFeatureCollectionInLayer(mapControl1.Map, LayerName);
            ExportsFileTab();
            //CombineFeatures(mapControl1.Map, LayerName);
            //IntersectFeatures(mapControl1.Map, LayerName);
        }

        private void toolPrepareSplit_Click(object sender, EventArgs e)
        {
            /* Gán giá trị cho biến hành động */
            DMC.Land.TachThua.CommonLand.stringAction = "Split";
            DMC.GIS.Common.SplitLand splitLand = new SplitLand();
            /* */
            DMC.Land.TachThua.CommonLand.featureSplit = splitLand.PrepareSplit(mapControl1, "Đất", LayerName);
            /* Nếu chuẩn bị thửa để tách không thành công thì thay đổi giá trị của biến
             strAction = "" */
            if (DMC.Land.TachThua.CommonLand.featureSplit == null)
                DMC.Land.TachThua.CommonLand.stringAction = "";
            /* Hiển thị các node */
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            layerTools.LayerShowCentroids(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowCentroids);
            layerTools.LayerShowLineDirection(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowLineDirection);
            layerTools.LayerShowNodes(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowNodes);
            /* Xác nhận chế độ hiệu chỉnh là không cho phép di chuyển các đối tượng trên lớp */
            DMC.GIS.Common.MapTools mapTool = new DMC.GIS.Common.MapTools();
            mapTool.EditingMode(mapControl1, EditMode.None);
            intUndo = 0;
            ExportsFileTab();

        }

        private void toolPrepareCombine_Click(object sender, EventArgs e)
        {
            /* Gán giá trị cho biến hành động */
            DMC.Land.TachThua.CommonLand.stringAction = "Combine";
            /* Khai báo và khởi tạo đối tượng */
            DMC.GIS.Common.CombineLand combineLand = new DMC.GIS.Common.CombineLand();
            /* Gán giá trị cho tập các Feature cần ghép */
            DMC.Land.TachThua.CommonLand.featuresCombine = combineLand.PrepareCombine(mapControl1, "Đất", LayerName);
            /* Nếu chuẩn bị dữ liệu để ghép không thành công thì thay đổi lại giá trị 
             của biến hành động strAction = "" */
            if (DMC.Land.TachThua.CommonLand.featuresCombine == null)
                DMC.Land.TachThua.CommonLand.stringAction = "";
            /* Hiển thị các node */
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            layerTools.LayerShowCentroids(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowCentroids);
            layerTools.LayerShowLineDirection(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowLineDirection);
            layerTools.LayerShowNodes(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowNodes);
            /* Xác nhận chế độ hiệu chỉnh là không cho phép di chuyển các đối tượng trên lớp */
            DMC.GIS.Common.MapTools mapTool = new DMC.GIS.Common.MapTools();
            mapTool.EditingMode(mapControl1, EditMode.None);
            intUndo = 0;
            ExportsFileTab();
        }

        private void toolNanChinh_Click(object sender, EventArgs e)
        {
            /* Gán giá trị cho biến hành động */
            DMC.Land.TachThua.CommonLand.stringAction = "Edit";
        }

        private void toolCombineFeatures_Click(object sender, EventArgs e)
        {
            /* Gộp các đối tượng */
            DMC.GIS.Common.FeatureTools featureTool = new DMC.GIS.Common.FeatureTools();
            featureTool.CombineFeatures(mapControl1.Map, LayerName);
            //cls.CombineFeatures(mapControl1.Map, LayerName, staProcess);
            ExportsFileTab();
            mapControl1.Map.Invalidate();
        }

        private void toolConvertToPolygon_Click(object sender, EventArgs e)
        {
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            //featureTools.ConvertToMultiPolygon(mapControl1.Map, LayerName);
            cls.CombineFeatures(mapControl1, LayerName, staProcess);
            ExportsFileTab();
        }

        private void toolNanChinhMarkedPoints_Click(object sender, EventArgs e)
        {
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            featureTools.MarkedPoints(mapControl1.Map, LayerName);
        }

        private void toolPrepareEdit_Click(object sender, EventArgs e)
        {
            /* Gán giá trị cho biến hành động */
            DMC.Land.TachThua.CommonLand.stringAction = "Edit";
            DMC.GIS.Common.LandEditing landEditing = new DMC.GIS.Common.LandEditing();
            /* */
            DMC.Land.TachThua.CommonLand.featureEdit = landEditing.PrepareEditing(mapControl1, "Đất", LayerName);
            /* Nếu chuẩn bị thửa để nắn chỉnh không thành công thì thay đổi giá trị của biến
             strAction = "" */
            if (DMC.Land.TachThua.CommonLand.featureEdit == null)
                DMC.Land.TachThua.CommonLand.stringAction = "";
            /* Thiết lập chế độ hiển thị cho lớp nắn chỉnh */
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            layerTools.LayerShowCentroids(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowCentroids);
            layerTools.LayerShowLineDirection(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowLineDirection);
            layerTools.LayerShowNodes(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowNodes);
            /* Xác nhận chế độ hiệu chỉnh là không cho phép di chuyển các đối tượng trên lớp */
            DMC.GIS.Common.MapTools mapTool = new DMC.GIS.Common.MapTools();

            mapTool.EditingMode(mapControl1, EditMode.None);
            intUndo = 0;
            ExportsFileTab();

        }

        private void toolMarkedPoints_Click(object sender, EventArgs e)
        {
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            featureTools.MarkedPoints(mapControl1.Map, LayerName);
        }

        private void toolExtent_Click(object sender, EventArgs e)
        {
            frmViewEntireLayer viewEntireLayer = new frmViewEntireLayer();
            viewEntireLayer.ShowDialog();
        }

        private void toolSegmentSpliting_Click(object sender, EventArgs e)
        {
            frmChiaDoan ChiaDoan = new frmChiaDoan();
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            DMC.Land.TachThua.CommonLand.dblLineLength = featureTools.DoDaiDoanThang(mapControl1.Map, LayerName);
            ChiaDoan.ShowDialog();
            if (DMC.Land.TachThua.CommonLand.boolChiaDoanThang)
            {
                featureTools.ChiaDoanThang(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.dblDistance);
                ExportsFileTab();
            }
            /* Thiết lập giá trị mặc định cho các biến dùng chung sau khi chia đoạn */
            DMC.Land.TachThua.CommonLand.dblDistance = 0.0;
            DMC.Land.TachThua.CommonLand.boolChiaDoanThang = false;
        }

        public void FormClosing()
        {
            MapInfo.Engine.Session.Current.Catalog.CloseAll();
           // XoaFileTmp();
        }

        public void XoaFileTmp()
        {
            string fileName = "";
            fileName = Application.StartupPath;
            try
            {

                DirectoryInfo dir = new DirectoryInfo(fileName + @"\tempTach\");
                FileInfo[] file = dir.GetFiles("*.tab");
                for (int i = 0; i < file.Length; i++)
                {
                    XoaFileTmp(dir + "\\" + file[i].Name);
                }
            }
            catch (Exception fas)
            {
                MessageBox.Show(fas.Message);
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            /* Khai báo biến kết thúc hành động thực hiện */
            bool boolEnd = true;
            /* Xác nhận hành động NẮN CHỈNH THỬA ĐẤT */
            if (DMC.Land.TachThua.CommonLand.stringAction == "Edit")
            {
                /* Xác nhận nắn chỉnh thửa đất */
                DMC.GIS.Common.LandEditing landEditing = new DMC.GIS.Common.LandEditing();
                /* Truyền chuỗi kết nối cơ sở dữ liệu */
                landEditing.Connection = strConnection;
                landEditing.MaDonViHanhChinh = strMaDonViHanhChinh;
                landEditing.TenBangDat = strTenBangDat;
                boolEnd = landEditing.ApplyEditing(mapControl1.Map, "Đất", ref DMC.Land.TachThua.CommonLand.featureEdit, LayerName);
            }
            /* Xác nhận hành động GHÉP THỬA */
            else if (DMC.Land.TachThua.CommonLand.stringAction == "Combine")
            {
                /* Xác nhận GHÉP */
                DMC.GIS.Common.CombineLand combineLand = new DMC.GIS.Common.CombineLand();
                /* Truyền chuỗi kết nối cơ sở dữ liệu */
                combineLand.Connection = strConnection;
                combineLand.MaDonViHanhChinh = strMaDonViHanhChinh ;
                combineLand.TenBangDat = strTenBangDat;
                boolEnd = combineLand.ApplyCombine(mapControl1.Map, "Đất", DMC.Land.TachThua.CommonLand.featuresCombine, LayerName);
            }
            /* Xác nhận hành động TÁCH THỬA */
            else if (DMC.Land.TachThua.CommonLand.stringAction == "Split")
            {
                /* Xác nhận TÁCH */
                DMC.GIS.Common.SplitLand splitLand = new DMC.GIS.Common.SplitLand();
                /* Truyền chuỗi kết nối cơ sở dữ liệu */
                splitLand.Connection = strConnection;
                splitLand.MaDonViHanhChinh = strMaDonViHanhChinh;
                splitLand.TenBangDat = strTenBangDat;
                boolEnd = splitLand.ApplySplit(mapControl1.Map, "Đất", ref DMC.Land.TachThua.CommonLand.featureSplit, LayerName);
            }
            else if (DMC.Land.TachThua.CommonLand.stringAction == "AddNew")
            {
                /* Xác nhận THÊM MỚI */
                DMC.GIS.Common.AddNew addNew = new DMC.GIS.Common.AddNew();
                /* Truyền mã đơn vị hành chính cho trường hợp thêm mới thửa đất lên bản đồ thửa đất */
                addNew.MaDonViHanhChinh = Convert.ToInt32(strMaDonViHanhChinh);
                boolEnd = addNew.ApplyAddNew(mapControl1.Map, "Đất", LayerName);
            }
            /* Nếu kết thúc hành động  thực hiện */
            if (boolEnd == true)
            {
                /* Đóng lớp thửa đất */
                MapInfo.Engine.Session.Current.Catalog.CloseTable(LayerName);
                /* Xác nhận lại hành động */
                DMC.Land.TachThua.CommonLand.stringAction = "";
            }
            return;
        }

        private void toolEditingMode_Click(object sender, EventArgs e)
        {
            /* Khai báo hộp hồi thoại thiết lập chế độ hiệu chỉnh bản đồ */
            frmEditingMode editingMode = new frmEditingMode();
            /* Hiển thị hộp hồi thoại */
            editingMode.ShowDialog();
            /* Xác nhận chế độ hiệu chỉnh đã được thiết lập trên hộp hồi thoại */
            DMC.GIS.Common.MapTools mapTool = new DMC.GIS.Common.MapTools();
            mapTool.EditingMode(mapControl1, DMC.Land.TachThua.CommonLand.EditMode);
        }

        private void toolLayerVisibility_Click(object sender, EventArgs e)
        {
            frmLayerVisibility layerVisibility = new frmLayerVisibility();
            layerVisibility.ShowDialog();
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            /* Thiết lập chế độ hiển thị tâm đối tượng cho lớp THỬA ĐẤT */
            layerTools.LayerShowCentroids(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowCentroids);
            /* Thiết lập chế độ hiển thị tâm đối tượng cho lớp ĐẤT */
            layerTools.LayerShowCentroids(mapControl1.Map, "Đất", DMC.Land.TachThua.CommonLand.boolShowCentroids);
            /* Thiết lập chế độ hiển thị hướng đường cho lớp THỬA ĐẤT */
            layerTools.LayerShowLineDirection(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowLineDirection);
            /* Thiết lập chế độ hiển thị hướng đường cho lớp ĐẤT */
            layerTools.LayerShowLineDirection(mapControl1.Map, "Đất", DMC.Land.TachThua.CommonLand.boolShowLineDirection);
            /* Thiết lập chế độ hiển thị các đỉnh của đối tượng cho lớp THỬA ĐẤT */
            layerTools.LayerShowNodes(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowNodes);
            /* Thiết lập chế độ hiển thị các đỉnh của đối tượng cho lớp ĐẤT */
            layerTools.LayerShowNodes(mapControl1.Map, "Đất", DMC.Land.TachThua.CommonLand.boolShowNodes);
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            switch (DMC.Land.TachThua.CommonLand.stringAction)
            {
                case "Split":
                    {
                        DMC.GIS.Common.SplitLand split = new DMC.GIS.Common.SplitLand();
                        split.CancelSplit(mapControl1.Map, LayerName, ref DMC.Land.TachThua.CommonLand.featureSplit);
                        break;
                    }
                case "Edit":
                    {
                        DMC.GIS.Common.LandEditing Edit = new DMC.GIS.Common.LandEditing();
                        Edit.CancelEdit(mapControl1.Map, LayerName, ref DMC.Land.TachThua.CommonLand.featureEdit);
                        break;
                    }
                case "Combine":
                    {
                        DMC.GIS.Common.CombineLand combine = new DMC.GIS.Common.CombineLand();
                        combine.CancelCombine(mapControl1.Map, LayerName, ref DMC.Land.TachThua.CommonLand.featuresCombine);
                        break;
                    }
                case "AddNew":
                    {
                        DMC.GIS.Common.AddNew addNew = new DMC.GIS.Common.AddNew();
                        addNew.CancelAddNew(mapControl1.Map, LayerName);
                        break;
                    }
                default: break;
            }
            /* Hủy hành động hiện thời */
            DMC.Land.TachThua.CommonLand.stringAction = "";
            /* Bỏ chọn tất cả các đối tượng */
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            /* Đóng lớp thửa đất */
            MapInfo.Engine.Session.Current.Catalog.CloseTable(LayerName);

        }

        public void ThemThuaMoi()
        {
            /* Gán giá trị cho biến hành động */
            DMC.Land.TachThua.CommonLand.stringAction = "AddNew";
            DMC.GIS.Common.AddNew addNew = new DMC.GIS.Common.AddNew();
            /* */
            bool boolPrepareAddNew = addNew.PrepareAddNew(mapControl1, "Đất", LayerName);
            /* Nếu chuẩn bị thửa để tách không thành công thì thay đổi giá trị của biến
             strAction = "" */
            if (!boolPrepareAddNew)
                DMC.Land.TachThua.CommonLand.stringAction = "";
            else
            {
                ///* Chuẩn bị tách thửa thành công thì ZoomExtent lớp Thửa đất */
                //TachThua.MapTools mapTools = new MapTools();
                //mapTools.ViewEntireLayer(mapControl1.Map, LayerName);
            }
            /* Hiển thị các node */

            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            layerTools.LayerShowCentroids(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowCentroids);
            layerTools.LayerShowLineDirection(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowLineDirection);
            layerTools.LayerShowNodes(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowNodes);
            //them vao 1 nut xem the nao
            Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            FeatureLayer fl = mapControl1.Map.Layers[LayerName] as MapInfo.Mapping.FeatureLayer;

            /* Xác nhận chế độ hiệu chỉnh là không cho phép di chuyển các đối tượng trên lớp */
            DMC.GIS.Common.MapTools mapTool = new DMC.GIS.Common.MapTools();
            mapTool.EditingMode(mapControl1, EditMode.None);
            //tao file undo
            intUndo = 0;
            ExportsFileTab();

            //bat chuc nang snap
            mapControl1.Tools.MapToolProperties.SnapEnabled
               = !mapControl1.Tools.MapToolProperties.SnapEnabled;
            mapControl1.Tools.MapToolProperties.SnapTolerance = 1;
            // set the insertion and edit filters to allow all tools to work on Temp
            ToolFilter toolFilter =
                (ToolFilter)mapControl1.Tools.AddMapToolProperties.InsertionLayerFilter;
            if (toolFilter != null && !toolFilter.IncludeLayer(fl))
                toolFilter.SetExplicitInclude(fl, true);
            toolFilter = (ToolFilter)mapControl1.Tools.SelectMapToolProperties.EditableLayerFilter;
            if (toolFilter != null && !toolFilter.IncludeLayer(fl))
                toolFilter.SetExplicitInclude(fl, true); 
        }


        private void toolPrepareAddNew_Click(object sender, EventArgs e)
        {
            /* Gán giá trị cho biến hành động */
            DMC.Land.TachThua.CommonLand.stringAction = "AddNew";
            DMC.GIS.Common.AddNew addNew = new DMC.GIS.Common.AddNew();
            /* */
            bool boolPrepareAddNew = addNew.PrepareAddNew(mapControl1, "Đất", LayerName);
            /* Nếu chuẩn bị thửa để tách không thành công thì thay đổi giá trị của biến
             strAction = "" */
            if (!boolPrepareAddNew)
                DMC.Land.TachThua.CommonLand.stringAction = "";
            else
            {
                ///* Chuẩn bị tách thửa thành công thì ZoomExtent lớp Thửa đất */
                //TachThua.MapTools mapTools = new MapTools();
                //mapTools.ViewEntireLayer(mapControl1.Map, LayerName);
            }
            /* Hiển thị các node */
           
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            layerTools.LayerShowCentroids(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowCentroids);
            layerTools.LayerShowLineDirection(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowLineDirection);
            layerTools.LayerShowNodes(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowNodes);
            //them vao 1 nut xem the nao
            Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName) ;
            FeatureLayer fl = mapControl1.Map.Layers[LayerName] as MapInfo.Mapping.FeatureLayer;

            /* Xác nhận chế độ hiệu chỉnh là không cho phép di chuyển các đối tượng trên lớp */
            DMC.GIS.Common.MapTools mapTool = new DMC.GIS.Common.MapTools();
            mapTool.EditingMode(mapControl1, EditMode.None);
            //tao file undo
              intUndo = 0;
            ExportsFileTab();
            
            //bat chuc nang snap
                 mapControl1.Tools.MapToolProperties.SnapEnabled
                    = !mapControl1.Tools.MapToolProperties.SnapEnabled;
            mapControl1.Tools.MapToolProperties.SnapTolerance = 1;

            ToolFilter toolFilter =
                    (ToolFilter)mapControl1.Tools.AddMapToolProperties.InsertionLayerFilter;
            if (toolFilter != null && !toolFilter.IncludeLayer(fl))
                toolFilter.SetExplicitInclude(fl, true);
            toolFilter = (ToolFilter)mapControl1.Tools.SelectMapToolProperties.EditableLayerFilter;
            if (toolFilter != null && !toolFilter.IncludeLayer(fl))
                toolFilter.SetExplicitInclude(fl, true); 
        }
        private void toolSearch_Click(object sender, EventArgs e)
        {
            /* Tìm kiếm thửa đất theo thông tin thuộc tính */
            frmSearch search = new frmSearch();
            search.ShowDialog();
        }

        private void toolTest_Click(object sender, EventArgs e)
        {
            ///* Khai báo lớp MapTools */
            //DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
            ///* Nhận ảnh hồ sơ kĩ thuật thửa đất */
            //byte[] byteLandImage = mapTools.ExportMapToImage(mapControl1.Map, 400, 400);

            ///* Khai báo lớp chứa phương thức cập nhật Ảnh hồ sơ kĩ thuật thửa đất
            // * vào cơ sở dữ liệu */
            //DMC.GIS.Common.HoSoKiThuat HoSoKiThuat = new DMC.GIS.Common.HoSoKiThuat();
            //HoSoKiThuat.Connection = strConnection;
            //HoSoKiThuat.MaHoSoCapGCN = strMaHoSoCapGCN;
            //HoSoKiThuat.HoSoKiThuatThuaDat = byteLandImage;
            //HoSoKiThuat.UpdateHoSoCapGCNByHoSoKiThuatThamDinh();
        }

        private void toolInformation_Click(object sender, EventArgs e)
        {
            frmInfoTool infoTool = new frmInfoTool();
            infoTool.ShowInTaskbar = false;
            infoTool.StartPosition = FormStartPosition.CenterScreen;
            infoTool.Show();
        }

        private void contextMenuLandProfile_Click(object sender, EventArgs e)
        {
            try
            {
                /* Nhận ID thửa đất đang được Select */
                DMC.GIS.Common.FeatureInfo featureInfo = new DMC.GIS.Common.FeatureInfo();
                string strLandID = null;
                strLandID = featureInfo.GetSelectedLandID(mapControl1.Map, "Đất", "SW_Member").ToString().Split('.')[0];
                /* Nếu tồn tại một thửa đất đang được lựa chọn thì gán giá trị cho biến
                 strMaThuaDat bằng Mã thửa đất đó */
                if (strLandID != null)
                {
                    /* Xác nhận thửa đất cần tác nghiệp */
                    strMaThuaDat = strLandID;
                    /* Xác nhận danh sách Hồ sơ cấp GCN của thửa đất */
                    DMC.Land.TachThua.clsHoSoCapGCN HoSoCapGCN = new DMC.Land.TachThua.clsHoSoCapGCN();
                    HoSoCapGCN.Connection = strConnection;
                    HoSoCapGCN.MaThuaDat = strMaThuaDat;
                    HoSoCapGCN.MaDonViHanhChinh = strMaDonViHanhChinh ;
                    /* Khai báo bảng chứa danh sách Hồ sơ tìm được theo Mã thửa đất */
                    DataTable dtHoSoCapGCN = new DataTable();
                    dtHoSoCapGCN = HoSoCapGCN.SelectHoSoCapGCNByMaThuaDat();
                    if (dtHoSoCapGCN != null)
                    {
                        if (dtHoSoCapGCN.Rows.Count > 0)
                            strMaHoSoCapGCN = dtHoSoCapGCN.Rows[0]["MaHoSoCapGCN"].ToString();
                        else
                            strMaHoSoCapGCN = "";
                    }
                    else
                    {
                        strMaHoSoCapGCN = "";
                    }

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi xác nhận thửa đất: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolWallBorder_Click(object sender, EventArgs e)
        {
            try
            {
                /* Khoảng cách tường bao và thửa đất */
                double dblDistance;
                /* Khai báo và khởi tạo Form nhập khoảng cách */
                DMC.Land.TachThua.frmWallBorder frmWallBorder = new DMC.Land.TachThua.frmWallBorder();
                /* Thiết lập chế độ hiển thị hộp hồi thoại giữa màn hình */
                frmWallBorder.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                /* Hiển thị hộp hồi thoại nhận tham số trước khi tạo bao tường */
                frmWallBorder.ShowDialog();
                dblDistance = frmWallBorder.Distance;
                ///* Khai báo chế độ lấy tương đối */
                //bool boolRelatively = false;
                //boolRelatively = frmWallBorder.Relatively;
                /* Khai báo lớp chứa phương thức Tạo bao tường */
                DMC.GIS.Common.WallBorderlines WallBorder = new DMC.GIS.Common.WallBorderlines();
                /* Tạo bao tường */
                if (!frmWallBorder.Relatively)
                {
                    /* Trường hợp vẽ chính xác */
                    WallBorder.CreateWallBorderline(mapControl1.Map, LayerName, dblDistance);
                }
                else
                {
                    /* Trường hợp vẽ tương đối - theo Buffer */
                    WallBorder.CreateWallBorderlineWithBuffer(mapControl1.Map, LayerName, dblDistance);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi vẽ tường bao: " + System.Environment.NewLine + ex.Message
                    , "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LoadThongTin(string ToBanDo, string SoThua,string strMaThuaDat)
        {
            DMC.Land.TachThua.clsHoSoCapGCN cls = new DMC.Land.TachThua.clsHoSoCapGCN();
            cls.Connection = strConnection;
            cls.ToBanDo = ToBanDo.Trim();
            cls.SoThua = SoThua.Trim();
            cls.MaThuaDat = strMaThuaDat;
            cls.MaDonViHanhChinh = strMaDonViHanhChinh;
            DataTable dt = new DataTable();
            dt = cls.SelThongTinHoSoByToBanDoSoThua();
            if (dt.Columns.Count > 0)
            {
                grdDSHoSo.DataSource = dt;
                grdDSHoSo.Columns["MaHoSoCapGCN"].HeaderText = "Mã hồ sơ";
                grdDSHoSo.Columns["DienTich"].HeaderText = "Diện tích";
                grdDSHoSo.Columns["DiaChi"].HeaderText = "Địa chỉ";
                grdDSHoSo.Columns["MaThuaDat"].Visible = false;
            }else{
                grdDSHoSo.Columns.Clear(); 
                grdvwHoSo.Columns.Clear();
            }

        }
        private void toolVertexLable_Click(object sender, EventArgs e)
        {
            try
            {
                /* Khai báo khoảng cách nhãn và góc thửa */
                double dblDistance;
                /* Khai báo biến độ cao của nhãn */
                double dblHeight;
                /* Khai báo biến độ Rộng của nhãn */
                double dblWidth;
                /* Khai báo và khởi tạo Form nhập khoảng cách */
                DMC.Land.TachThua.frmVertexLable vertexLable = new DMC.Land.TachThua.frmVertexLable();
                /* Thiết lập hộp hồi thoại giữa màn hình */
                vertexLable.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                /* Hiển thị hộp hồi thoại */
                vertexLable.ShowDialog();              
                /* Nhận giá trị khoảng cách từ đỉnh tởi nhãn */
                dblDistance = vertexLable.Distance;
                /* Nhận giá trị chiều cao của nhãn */
                dblHeight = vertexLable.Height;
                /* Nhận giá trị chiều Rông của nhãn */
                dblWidth = vertexLable.Width;
                /* Khai báo lớp chứa phương thức tạo nhãn đỉnh */
                DMC.GIS.Common.VertexLable VertexLable = new DMC.GIS.Common.VertexLable();
                //VertexLable.DeleteVertexLable(mapControl1.Map, LayerName);
                /* Tạo nhãn đỉnh */
                VertexLable.CreateVertexLable(mapControl1.Map, LayerName, dblDistance, dblHeight, dblWidth);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi vẽ nhãn thửa đỉnh: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolExtendLandPlot_Click(object sender, EventArgs e)
        {
            /* Khai báo lớp chứa phương thức lấy Thửa đất mở rộng */
            DMC.GIS.Common.ExtendLandPlot extendLandPlot = new DMC.GIS.Common.ExtendLandPlot();
            /* Hiển thị hộp hồi thoại nhập khoảng cách mở rộng thửa đất */
            DMC.Land.TachThua.frmExtendLandPlot frmExtend = new DMC.Land.TachThua.frmExtendLandPlot();
            /* Đua hộp hồi thoại về tâm màn hình */
            frmExtend.StartPosition = FormStartPosition.CenterScreen;
            /* Hiển thị hộp hồi thoại */
            frmExtend.ShowDialog();
            /* Khai báo khoảng cách mở rộng thửa */
            double dblDistance = frmExtend.Distance;
            /* Tạo thửa đất mở rộng */
            extendLandPlot.CreateExtendLandPlot(mapControl1, "Đất", LayerName, dblDistance);
            /* Hiển thị các node */
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            layerTools.LayerShowNodes(mapControl1.Map, LayerName, DMC.Land.TachThua.CommonLand.boolShowNodes);
        }

        private void toolPerpendicularLines_Click(object sender, EventArgs e)
        {
            ///* Tạo đường vuông góc */
            //DMC.GIS.Common.clsMainSoanHoSo SoanHoSo = new DMC.GIS.Common.clsMainSoanHoSo();
            //SoanHoSo.TaoDuongChucNang(mapControl1, LayerName, false);
            /* Tạo đường song song */
            double KhoangCach;
            bool DiemXoay;
            bool ChonNghiem;
            bool accep;
            KhoangCach = 0.0;
            //DMC.Land.SoanHoSo.frmSongSongVuongGoc
            DMC.Land.SoanHoSo.frmSongSongVuongGoc MyfrmSongSongVuongGoc = new DMC.Land.SoanHoSo.frmSongSongVuongGoc();
            //MyfrmSongSongVuongGoc.ChucNang(ChucNang);
            MyfrmSongSongVuongGoc.ShowDialog();
            accep = MyfrmSongSongVuongGoc.accep();
            ChonNghiem = MyfrmSongSongVuongGoc.ChonDuong();
            DiemXoay = MyfrmSongSongVuongGoc.ChonDiem();
            KhoangCach = MyfrmSongSongVuongGoc.KhoangCach();
            DMC.GIS.Common.clsMainSoanHoSo SoanHoSo = new clsMainSoanHoSo();
            SoanHoSo.TaoDuongChucNang(mapControl1, LayerName, false , KhoangCach, DiemXoay, accep, ChonNghiem);
            ExportsFileTab();
            MyfrmSongSongVuongGoc.Close();
        }

        private void toolParallel_Click(object sender, EventArgs e)
        {
            /* Tạo đường song song */
            double KhoangCach;
            bool DiemXoay;
            bool ChonNghiem;
            bool accep;
            KhoangCach = 0.0;
            //DMC.Land.SoanHoSo.frmSongSongVuongGoc
            DMC.Land.SoanHoSo.frmSongSongVuongGoc MyfrmSongSongVuongGoc = new DMC.Land.SoanHoSo.frmSongSongVuongGoc();
            //MyfrmSongSongVuongGoc.ChucNang(ChucNang);
            MyfrmSongSongVuongGoc.ShowDialog();
            accep = MyfrmSongSongVuongGoc.accep();
            ChonNghiem = MyfrmSongSongVuongGoc.ChonDuong();
            DiemXoay = MyfrmSongSongVuongGoc.ChonDiem();
            KhoangCach = MyfrmSongSongVuongGoc.KhoangCach();
            DMC.GIS.Common.clsMainSoanHoSo SoanHoSo = new clsMainSoanHoSo();
            SoanHoSo.TaoDuongChucNang(mapControl1, LayerName, true, KhoangCach, DiemXoay, accep, ChonNghiem);
            ExportsFileTab();
            MyfrmSongSongVuongGoc.Close();
        }

        private void mapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ChonHoSoTuThuaDat != null)
            {
                /* Hiển thị thông tin thửa đất */
                DMC.GIS.Common.FeatureInfo featureInfo = new DMC.GIS.Common.FeatureInfo();
                MapInfo.Data.Feature feature = featureInfo.GetSelectedLandInfo(mapControl1.Map, "Đất");
                if (feature == null)
                    return;
                strSoThua = feature["SoThua"].ToString();
                strToBanDo = feature["ToBanDo"].ToString();
                strMaThuaDat = feature["SW_MEMBER"].ToString();
                ChonHoSoTuThuaDat(sender, e);
            }
           
        }


        #region HIỂN THỊ, CẬP NHẬT THÔNG TIN THỬA ĐẤT

        private void mapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            
            /* Xóa dữ liệu trên Form */
            this.TrangThaiBanDau();
            /* Chắc chắn rằng người dùng click chuột trái */
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            try
            {
                /* Hiển thị thông tin thửa đất */
                DMC.GIS.Common.FeatureInfo featureInfo = new DMC.GIS.Common.FeatureInfo();
                MapInfo.Data.Feature feature = featureInfo.GetSelectedLandInfo(mapControl1.Map, "Đất");
                if (feature == null)
                    return;
                //this.txtDiaChi.Text = feature["DiaChi"].ToString();
                if (feature["DienTichTuNhien"].ToString() != null)
                {
                    this.numDienTich.Value = Convert.ToDecimal(feature["DienTichTuNhien"].ToString());
                }
                this.txtSoHieuThua.Text = feature["SoThua"].ToString();
                this.txtToBanDo.Text = feature["ToBanDo"].ToString();
                this.strMaThuaDat = feature["SW_MEMBER"].ToString();
                LoadThongTin(feature["ToBanDo"].ToString(), feature["SoThua"].ToString(), strMaThuaDat);
            }
            catch (Exception ex)
            {
            }
        }

        public void TrangThaiCapNhat(bool blnCapNhat)
        {
            this.txtDiaChi.ReadOnly = !blnCapNhat;
            this.txtSoHieuThua.ReadOnly = !blnCapNhat;
            this.txtToBanDo.ReadOnly = !blnCapNhat;
            this.numDienTich.ReadOnly = !blnCapNhat;
            if (blnCapNhat)
            {
                this.txtDiaChi.BackColor = Color.White;
                this.txtSoHieuThua.BackColor = Color.White;
                this.txtToBanDo.BackColor = Color.White;
            }
            else
            {
                this.txtDiaChi.BackColor = Color.LightYellow;
                this.txtSoHieuThua.BackColor = Color.LightYellow;
                this.txtToBanDo.BackColor = Color.LightYellow;
            }
        }

        public void TrangThaiBanDau()
        {
            /* Thiết lập trên Form nhập liệu */
            this.txtDiaChi.Text = "";
            this.txtSoHieuThua.Text = "";
            this.txtToBanDo.Text = "";
            this.numDienTich.Value = 0.0M;
        }

        public void TrangThaiChucNang(bool blnStartEdited, bool blnStartDeleted)
        {
            this.btnSua.Enabled = !blnStartEdited;
            this.btnGhi.Enabled = blnStartEdited;
            this.btnHuyLenh.Enabled = blnStartEdited;
            if (blnStartDeleted)
            {
                this.btnGhi.Enabled = !blnStartDeleted;
                this.btnHuyLenh.Enabled = !blnStartDeleted;
            }
        }




        #endregion

        private void btnHuyLenh_Click(object sender, EventArgs e)
        {
            try
            {

                /* Thiết lập trạng thái cập nhật */
                this.TrangThaiCapNhat(false);
                /* Thiết lập trạng thái chức năng */
                this.TrangThaiChucNang(false, false);
                /* Hiển thị thông tin thửa đất */
                DMC.GIS.Common.FeatureInfo featureInfo = new DMC.GIS.Common.FeatureInfo();
                MapInfo.Data.Feature feature = featureInfo.GetSelectedLandInfo(mapControl1.Map, "Đất");
                if (feature == null)
                    return;
                //this.txtDiaChi.Text = feature["DiaChi"].ToString();
                if (feature["DienTichTuNhien"].ToString() != null)
                {
                    this.numDienTich.Value = Convert.ToDecimal(feature["DienTichTuNhien"].ToString());
                }
                this.txtSoHieuThua.Text = feature["SoThua"].ToString();
                this.txtToBanDo.Text = feature["ToBanDo"].ToString();
            }
            catch (Exception ex)
            {

            }

        }

        private void toolIntersection_Click(object sender, EventArgs e)
        {
            DMC.GIS.Common.FeatureTools featureTools = new FeatureTools();
            featureTools.IntersectFeatures(mapControl1.Map, LayerName);
        }

        private void toolKhoetVung_Click(object sender, EventArgs e)
        {
            DMC.GIS.Common.clsKhoetVung KhoetVung = new clsKhoetVung();
            KhoetVung.KhoetVung(mapControl1.Map, LayerName);
        }

        private void toolPrinting_Click(object sender, EventArgs e)
        {
            try
            {
                /* In trực tiếp bản đồ */
                DMC.Land.InSoDoNhaDat.frmInSoDoNhaDat InSoDoNhaDat = new DMC.Land.InSoDoNhaDat.frmInSoDoNhaDat();
                /* Khai báo biến nhận Hình ảnh bản đồ */
                byte[] bytImage = null;
                /* Nhận hình ảnh bản đồ */
                DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
                bytImage = mapTools.ExportMapToImage(mapControl1.Map, mapControl1.Map.Size.Width, mapControl1.Map.Size.Height);
                InSoDoNhaDat.ctrlSoDoNhaDat.Image = bytImage;
                double dblScale = Convert.ToDouble(mapControl1.Map.Size.Height) / Convert.ToDouble(mapControl1.Map.Size.Width);
                InSoDoNhaDat.ctrlSoDoNhaDat.HeightScale = dblScale;
                /* Hiển thị Report Sơ đồ nhà đất */
                InSoDoNhaDat.StartPosition = FormStartPosition.CenterScreen;
                InSoDoNhaDat.WindowState = FormWindowState.Maximized;
                InSoDoNhaDat.Show();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi in bản đồ: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Thiết lập grid lưu trữ kết quả tìm kiếm

        /// <summary>
        /// Ẩn tất cả các cột trên Grid
        /// </summary>
        /// <param name="grdvw"></param>
        private void HideAllColumns(ref  DMC.Interface.GridView.ctrlGridView grdvw)
        {
            //Ẩn tất cả các cột trên Grid
            for (int i = 0; i < grdvw.Columns.Count; i++)
            {
                grdvw.Columns[i].Visible = false;
            }
            grdvw.RowHeadersVisible = false;
        }

        public void LoadThongTinTobanDoSoThuaTrungLap()
        {
            DMC.Land.TachThua.clsHoSoCapGCN clshs = new DMC.Land.TachThua.clsHoSoCapGCN();
            clshs.Connection = strConnection;
            clshs.MaDonViHanhChinh  = strMaDonViHanhChinh ;
            DataTable dt = new DataTable();
            dt=clshs.SelDanhSachThuaTrung();
            grdDanhSachThuaTrung.DataSource = dt;
            FormatGridDanhSachMaTrung();
        }
        /* Thiết đặt hiển thị DataGridView */
        private void FormatGridDanhSachMaTrung()
        {
            string strError = "";
            try
            {
                /* Ẩn tất cả các cột trên Grid */
                this.HideAllColumns(ref  grdDanhSachThuaTrung);
                this.grdDanhSachThuaTrung.Columns["ToBanDo"].Width = 80;
                this.grdDanhSachThuaTrung.Columns["ToBanDo"].HeaderText = "Số tờ";
                this.grdDanhSachThuaTrung.Columns["ToBanDo"].ReadOnly = true;
                this.grdDanhSachThuaTrung.Columns["ToBanDo"].Visible = true;
                this.grdDanhSachThuaTrung.Columns["ToBanDo"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdDanhSachThuaTrung.Columns["SoThua"].Width = 80;
                this.grdDanhSachThuaTrung.Columns["SoThua"].HeaderText = "Số thửa";
                this.grdDanhSachThuaTrung.Columns["SoThua"].ReadOnly = true;
                this.grdDanhSachThuaTrung.Columns["SoThua"].Visible = true;
                this.grdDanhSachThuaTrung.Columns["SoThua"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdDanhSachThuaTrung.Columns["DienTichTuNhien"].Width = 80;
                this.grdDanhSachThuaTrung.Columns["DienTichTuNhien"].HeaderText = "Diện tích";
                this.grdDanhSachThuaTrung.Columns["DienTichTuNhien"].ReadOnly = true;
                this.grdDanhSachThuaTrung.Columns["DienTichTuNhien"].Visible = true;
                this.grdDanhSachThuaTrung.Columns["DienTichTuNhien"].SortMode = DataGridViewColumnSortMode.NotSortable;


                this.grdDanhSachThuaTrung.Columns["SoLuong"].Width = 80;
                this.grdDanhSachThuaTrung.Columns["SoLuong"].HeaderText = "Số lượng";
                this.grdDanhSachThuaTrung.Columns["SoLuong"].ReadOnly = true;
                this.grdDanhSachThuaTrung.Columns["SoLuong"].Visible = true;
                this.grdDanhSachThuaTrung.Columns["SoLuong"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdDanhSachThuaTrung.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.grdDanhSachThuaTrung.RowHeadersVisible = false;
                this.grdDanhSachThuaTrung.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.grdDanhSachThuaTrung.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                /* Khong cho phep them */
                this.grdDanhSachThuaTrung.AllowUserToAddRows = false;
                /* Khong cho phep xoa */
                this.grdDanhSachThuaTrung.AllowUserToDeleteRows = false;
                /* Khong lua chon bat ky dong nao luc ban dau */
                this.grdDanhSachThuaTrung.ClearSelection();

            }
            catch (Exception ex)
            {
                strError = "";
                strError = ex.ToString();
                MessageBox.Show(" Thiết đặt hiển thị Thửa đất tìm được " + System.Environment.NewLine +
                    "Lỗi: " + System.Environment.NewLine + ex.ToString(), "DMCLand");
            }

        }
        /* Thiết đặt hiển thị DataGridView */
        private void FormatGridContruction(ref  DMC.Interface.GridView.ctrlGridView grdvw)
        {
            string strError = "";
            try
            {
                /* Ẩn tất cả các cột trên Grid */
                this.HideAllColumns(ref  grdvw);

                /* Chỉ hiển thị những cột cần thiết */
                this.grdvw.Columns["SW_MEMBER"].Width = 50;
                this.grdvw.Columns["SW_MEMBER"].HeaderText = "Mã";
                this.grdvw.Columns["SW_MEMBER"].ReadOnly = true;
                this.grdvw.Columns["SW_MEMBER"].Visible = true;
                this.grdvw.Columns["SW_MEMBER"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdvw.Columns["ToBanDo"].Width = 80;
                this.grdvw.Columns["ToBanDo"].HeaderText = "Số tờ";
                this.grdvw.Columns["ToBanDo"].ReadOnly = true;
                this.grdvw.Columns["ToBanDo"].Visible = true;
                this.grdvw.Columns["ToBanDo"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdvw.Columns["SoThua"].Width = 80;
                this.grdvw.Columns["SoThua"].HeaderText = "Số thửa";
                this.grdvw.Columns["SoThua"].ReadOnly = true;
                this.grdvw.Columns["SoThua"].Visible = true;
                this.grdvw.Columns["SoThua"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    this.grdvw.Columns["DienTich"].Width = 80;
                this.grdvw.Columns["DienTich"].HeaderText = "Diện tích";
                this.grdvw.Columns["DienTich"].ReadOnly = true;
                this.grdvw.Columns["DienTich"].Visible = true;
                this.grdvw.Columns["DienTich"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdvw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.grdvw.RowHeadersVisible = false;
                this.grdvw.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.grdvw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                /* Khong cho phep them */
                this.grdvw.AllowUserToAddRows = false;
                /* Khong cho phep xoa */
                this.grdvw.AllowUserToDeleteRows = false;
                /* Khong lua chon bat ky dong nao luc ban dau */
                this.grdvw.ClearSelection();

            }
            catch (Exception ex)
            {
                strError = "";
                strError = ex.ToString();
                MessageBox.Show(" Thiết đặt hiển thị Thửa đất tìm được " + System.Environment.NewLine +
                    "Lỗi: " + System.Environment.NewLine + ex.ToString(), "DMCLand");
            }

        }


        private DataTable Results(IResultSetFeatureCollection irfc)
        {
            /* Khai báo và khởi tạo bảng tạm */
            DataTable dtResults = new DataTable();
            try
            {
                /* Kiểm tra dữ liệu đầu vào */
                if (irfc == null)
                    return null;
                if (irfc.Count < 1)
                    return null;
                /* Gán các cột cho bảng */
                /* Định nghĩa và gán cột Mã thửa đất */
                DataColumn dc = dtResults.Columns.Add("SW_MEMBER", typeof(Int64));
                /* Định nghĩa và gán cột Tờ bản đồ */
                dtResults.Columns.Add("ToBanDo", typeof(string));
                /* Định nghĩa và gán cột Số thửa */
                dtResults.Columns.Add("SoThua", typeof(string));
                /* Định nghĩa và gán cột Diên tích */
                dtResults.Columns.Add("DienTich", typeof(Decimal));
                for (int i = 0; i < irfc.Count; i++)
                {
                    /* Gán giá trị cho các dòng */
                    DataRow dr = dtResults.NewRow();
                    /* Tờ bản đồ */
                    dr["ToBanDo"] = irfc[i]["ToBanDo"];
                    /* Số thửa */
                    dr["SoThua"] = irfc[i]["SoThua"];
                    /* Diện tích */
                    dr["DienTich"] = irfc[i]["DienTichTuNhien"];
                    /* Mã thửa đất */
                    dr["SW_MEMBER"] = irfc[i]["SW_MEMBER"];
                    /* Add tất cả các giá trị vào một bản ghi của bảng */
                    dtResults.Rows.Add(dr);
                }
                /* Xác nhận thay đổi */
                dtResults.AcceptChanges();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi chuyển thửa tìm được về dạng bảng: "
                    + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /* Trả giá trị cho hàm */
            return dtResults;
        }

        #endregion



        private void grdDSHoSo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DMC.Land.TachThua.clsHoSoCapGCN cls = new DMC.Land.TachThua.clsHoSoCapGCN();
            cls.Connection = strConnection;
            cls.MaHoSoCapGCN = grdDSHoSo.Rows[e.RowIndex].Cells[0].Value.ToString();
            DataTable dt = new DataTable();
            dt = cls.SelThongTinHoSoByMaHoSoCapGCN();
            if (dt.Columns.Count > 0)
            {
                grdvwHoSo.Columns.Clear();
                grdvwHoSo.Columns.Add("Truong", "Tên");
                grdvwHoSo.Columns.Add("GiaTri", "Giá trị");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    grdvwHoSo.Rows.Add();
                    grdvwHoSo.Rows[i].Cells["Truong"].Value = dt.Columns[i].ColumnName;
                    grdvwHoSo.Rows[i].Cells["GiaTri"].Value = dt.Rows[0][i];
                }
                grdvwHoSo.Columns["Truong"].DefaultCellStyle.BackColor = Color.Silver;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                picWait.Visible = false;

                /* Tìm thửa đất trên bản đồ với Số hiệu thửa */
                /* Khai báo lớp Tìm kiếm */
                string strSoThua = "";
                string strTobanDo = "";
                strSoThua = this.txtSoThuaTimKiem.Text.Trim();
                strTobanDo = this.txtToBanDoTimKiem.Text.Trim();
                if ((strSoThua == "") && (strTobanDo == ""))
                    return;
                DMC.GIS.Common.SearchTools searchTools = new SearchTools();
                IResultSetFeatureCollection irfcSearched = null;
                string strSearch = "";
                if (strSoThua != "")
                {
                    strSearch = strSearch + " (sothua = '" + strSoThua + "') and ";
                }
                if (strTobanDo != "")
                {
                    strSearch = strSearch + " (ToBanDo = '" + strTobanDo + "') and ";
                }

                irfcSearched = searchTools.SearchWithColumnToBanDoSoThua(mapControl1.Map, "Đất", strSearch, strMaDonViHanhChinh);
                if (irfcSearched == null)
                    return;
                /* Khai báo bảng chứa kết quả tìm được */
                DataTable dtResults = new DataTable();
                dtResults = this.Results(irfcSearched);
                if (dtResults == null)
                    return;
                if (dtResults.Rows.Count < 1)
                    return;
                grdvw.DataSource = dtResults;
                this.FormatGridContruction(ref this.grdvw);
                // picWait.Visible = false ;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi tìm thửa đất trên bản đồ: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdvw_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                /* Không active chức năng khi click chuột phải */
                if (e.Button == MouseButtons.Right)
                    return;
                /* Chắc chắn rằng người dùng click chuột trên bản ghi có dữ liệu */
                if (e.RowIndex < 0)
                    return;
                string strMaThuaDat;
                strMaThuaDat = grdvw.Rows[e.RowIndex].Cells["SW_MEMBER"].Value.ToString().ToString().Split('.')[0];
                DMC.GIS.Common.SearchTools searchTools = new SearchTools();
                IResultSetFeatureCollection irfcSearched = null;
                irfcSearched = searchTools.SearchWithColumn(mapControl1.Map, "Đất", "SW_MEMBER", strMaThuaDat, strMaDonViHanhChinh);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi hiển thị thửa đất được chọn trên bản đồ: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolXoaThuaDat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Có chắc chắn xoá thửa đất đang chọn không?",
                    "DMCLand",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (MessageBox.Show("Xác nhận chắc chắn xoá thửa đất?",
                   "DMCLand",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    Table tabBanDo = null;
                    tabBanDo = MapInfo.Engine.Session.Current.Catalog.GetTable("Đất");
                    IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[tabBanDo];
                    if (irfc == null)
                    {
                        return;
                    }
                    if (irfc.Count > 1)
                    {
                        System.Windows.Forms.MessageBox.Show(this, "Hãy chọn xoá từng thửa một !!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    foreach (Feature f in irfc)
                    {
                        tabBanDo.DeleteFeature(f);
                    }
                }
            }
        }

        private void toolLSBienDong_Click(object sender, EventArgs e)
        {
            string strMa = "";
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable("Đất");
            //tim mã thửa đất
            IResultSetFeatureCollection Lfc = Session.Current.Selections.DefaultSelection[tab];
            if ((Lfc == null))
            {
                return;
            }
            if (Lfc.Count != 1)
            {
                System.Windows.Forms.MessageBox.Show(this, "Hãy chọn từng thửa một !!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Feature f in Lfc)
            {
                //lay ma so cua thua dat  dc chon
                strMa = f.Key.Value.ToString().Split('.')[0];
                DMC.Land.TachThua.frmLichSuBienDong frm = new DMC.Land.TachThua.frmLichSuBienDong();
                frm.ctrLichSuBienDong1.Connection = strConnection;
                frm.ctrLichSuBienDong1.MaDonViHanhChinh  = strMaDonViHanhChinh ;
                frm.ctrLichSuBienDong1.TenBangDat = strTenBangDat;
                frm.ctrLichSuBienDong1.MaThuaDat = strMa;
                frm.ctrLichSuBienDong1.DanhSachBienDong(strMa);
                frm.ctrLichSuBienDong1.BanDoTongThe();
                frm.ShowDialog();

            }
        }

        

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {

                /* Thiết lập trạng thái cập nhật */
                this.TrangThaiCapNhat(false);
                /* Thiết lập trạng thái chức năng */
                this.TrangThaiChucNang(false, false);

                /* Cập nhật thông tin thửa đất */
                DMC.GIS.Common.FeatureInfo featureInfo = new DMC.GIS.Common.FeatureInfo();
                MapInfo.Data.Feature feature = featureInfo.GetSelectedLandInfo(mapControl1.Map, "Đất");
                if (feature == null)
                    return;
                //feature["DiaChi"] = this.txtDiaChi.Text ;
                if (this.numDienTich.Text.Trim() != "")
                {
                    feature["DienTichTuNhien"] = this.numDienTich.Value.ToString();
                }
                feature["SoThua"] = this.txtSoHieuThua.Text.Trim();
                feature["ToBanDo"] = this.txtToBanDo.Text.Trim();
                feature.Update(true);
                DMC.Land.TachThua.clsHoSoCapGCN cls = new DMC.Land.TachThua.clsHoSoCapGCN();
                cls.Connection = strConnection;
                cls.MaThuaDat = feature.Key.Value.ToString().Split('.')[0];
                cls.ToBanDo = txtToBanDo.Text.Trim();
                cls.SoThua = txtSoHieuThua.Text.Trim(); 
                cls.DienTich = numDienTich.Value.ToString();
                cls.MaDonViHanhChinh = strMaDonViHanhChinh.ToString();

                //DataTable dtCheckToBanDoSoThua = new DataTable();
                //dtCheckToBanDoSoThua = cls.SelCheckHoSoByToBanDoSoThua();
                //if (dtCheckToBanDoSoThua.Rows.Count > 0)
                //{
                    DMC.Land.TachThua.frmHoSoCapGCN frm = new DMC.Land.TachThua.frmHoSoCapGCN();
                    frm.Connection = strConnection;

                    frm.ToBanDo = txtToBanDo.Text.Trim();
                    frm.SoThua = txtSoHieuThua.Text.Trim();
                    frm.MaHoSoCapGCN = strMaHoSoCapGCN;
                    frm.MaThuaDat = feature.Key.Value.ToString().Split('.')[0];
                    frm.MaDonViHanhChinh = strMaDonViHanhChinh.ToString();
                    frm.ShowDialog();
                    if (frm.ChapNhan == "1")
                    {
                        string kq = "";
                        // cap nhat theo ma thua dat
                        if (frm.LuaChon == "1")
                        {
                            cls.MaHoSoCapGCN = frm.MaHoSoCapGCN;
                            cls.MaThuaDat = frm.MaThuaDat;
                            cls.ToBanDo = txtToBanDo.Text.Trim();
                            cls.SoThua = txtSoHieuThua.Text.Trim();
                        }
                        // cap nhat theo to ban do so thua
                        if (frm.LuaChon == "2")
                        {
                            cls.MaHoSoCapGCN = frm.MaHoSoCapGCN;
                            cls.MaThuaDat = feature.Key.Value.ToString().Split('.')[0]; ;
                            cls.ToBanDo = frm.ToBanDo;
                            cls.SoThua = frm.SoThua;
                        }
                        //Cap nhat theo ma ho so
                        if (frm.LuaChon == "3")
                        {
                            cls.MaHoSoCapGCN = frm.MaHoSoCapGCN;
                            cls.MaThuaDat = feature.Key.Value.ToString().Split('.')[0];
                            cls.ToBanDo = txtToBanDo.Text.Trim();
                            cls.SoThua = txtSoHieuThua.Text.Trim();
                        }
                        if (frm.LuaChon == "")
                        {
                            cls.MaHoSoCapGCN = frm.MaHoSoCapGCN;
                            cls.MaThuaDat = feature.Key.Value.ToString().Split('.')[0];
                            cls.ToBanDo = txtToBanDo.Text.Trim();
                            cls.SoThua = txtSoHieuThua.Text.Trim();
                        }
                        cls.LuaChon = frm.LuaChon;
                        cls.UpdateSoanHS(ref kq);
                        frm.Close();
                        NhatKyNguoiDung("Sửa", "Tờ bản đồ:" + txtSoHieuThua.Text + " - Số thửa: " + txtToBanDo.Text, feature.Key.Value.ToString().Split('.')[0]);
                    }
                //}
               

            }
            catch (Exception ex)
            {

            }
        }

      

        // tao bang temp
        public Table CreateTmp(string tabOld, string TabTmpName)
        {
            MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(tabOld);
            //TableInfo
            MapInfo.Data.TableInfo ti = MapInfo.Data.TableInfoFactory.CreateTemp(TabTmpName);
            for (int i = 0; i < tab.TableInfo.Columns.Count; i++)
            {
                //if (tab.TableInfo.Columns[i].Alias.ToUpper() != "Obj".ToUpper() && tab.TableInfo.Columns[i].Alias.ToUpper() != "SW_Geometry".ToUpper() && tab.TableInfo.Columns[i].Alias.ToUpper() != "MI_Style".ToUpper())
                //{
                ti.Columns.Add(new MapInfo.Data.Column(tab.TableInfo.Columns[i].Alias, tab.TableInfo.Columns[i].DataType));
                //   }
            }
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(TabTmpName) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(TabTmpName);
            }
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.CreateTable(ti);
            return table;
        }

        // tao bang temp
        public Table CreateTmpTab(string tabOld, string TabTmpName)
        {
            MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(tabOld);
            if (tab == null)
            {
                return null;
            }
            //TableInfo
            MapInfo.Data.TableInfo ti = MapInfo.Data.TableInfoFactory.CreateTemp(TabTmpName);
            for (int i = 0; i < tab.TableInfo.Columns.Count; i++)
            {
                if (tab.TableInfo.Columns[i].Alias.ToUpper() != "Obj".ToUpper() && tab.TableInfo.Columns[i].Alias.ToUpper() != "MI_Geometry".ToUpper() && tab.TableInfo.Columns[i].Alias.ToUpper() != "MI_Style".ToUpper())
                {
                    if (tab.TableInfo.Columns[i].DataType == MIDbType.String)
                    {
                        ti.Columns.Add(new MapInfo.Data.Column(tab.TableInfo.Columns[i].Alias, tab.TableInfo.Columns[i].DataType, 10, 2));
                    }
                    else
                    {
                        ti.Columns.Add(new MapInfo.Data.Column(tab.TableInfo.Columns[i].Alias, tab.TableInfo.Columns[i].DataType));
                    }
                }
            }
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(TabTmpName) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(TabTmpName);
            }
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.CreateTable(ti);
            return table;
        }
        private void ToolTrangThaiCapGCN_Click(object sender, EventArgs e)
        {
            
        }

       
            // xoa file tmp khi undo den giai doan giua rui lam tiep
             private void PhucHoiFile(string LoaiFile)
                {
                    DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\TempTach\");
                    FileInfo[] file = dir.GetFiles("*" + LoaiFile);
                    int LenCount = file.Length-1;
                    string fileDich = Application.StartupPath + @"\RestoreMapTach\tmp" + LenCount + "." + LoaiFile;
                    string fileNguon = Application.StartupPath + @"\TempTach\tmp" + LenCount + "." + LoaiFile;
                    File.Copy(fileNguon, fileDich);
                }

        public void ExportsFileTab()
        {
            try
            {

                // xoa file tmp khi undo den giai doan giua rui lam tiep
                MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                if (tab == null)
                {
                    return;
                }
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\TempTach\");
                DirectoryInfo dirPhucHoi = new DirectoryInfo(Application.StartupPath + @"\RestoreMapTach\");
                FileInfo[] file = dir.GetFiles("*.tab");
                if (TrangThaiPhucHoi)
                {
                    try
                    {
                        FileInfo[] filePhucHoi = dirPhucHoi.GetFiles("*.tab");
                        if (file.Length > 0)
                        {

                            for (int i = 0; i < filePhucHoi.Length; i++)
                            {
                                try
                                {
                                    XoaFileTmp(dirPhucHoi + "\\" + filePhucHoi[i].Name);
                                }
                                catch (Exception ex) { }
                            }
                            PhucHoiFile("Tab");
                            PhucHoiFile("Dat");
                            PhucHoiFile("ID");
                            PhucHoiFile("Map");
                        }
                        TrangThaiPhucHoi = false;
                    }
                    catch (Exception ex) { TrangThaiPhucHoi = false; }
                }
                for (int i = intUndo; i < file.Length; i++)
                {
                    try
                    {
                        XoaFileTmp(dir + "\\" + file[i].Name);
                    }
                    catch (Exception ex) { }
                }

                string fileName = "";
                fileName = Application.StartupPath;
                //an chuc nang redo
                toolRedo.Enabled = false;
                //hien thi chuc nang undo
                toolUndo.Enabled = true;


                //lay duong dan file du lieu temp can tao ra
                fileName = fileName + @"\TempTach\tmp" + intUndo + ".TAB";

                MapInfo.Data.Table table = CreateTmpTab(LayerName, "fileTmp" + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second);
                MapInfo.Data.TableInfoNative native = (MapInfo.Data.TableInfoNative)MapInfo.Data.TableInfoFactory.CreateFromFeatureCollection(MapInfo.Data.TableType.Native, table);
                native.TablePath = fileName;
                native.WriteTabFile();
                if (MapInfo.Engine.Session.Current.Catalog.CloseTable("tmp" + intUndo) != null)
                {
                    MapInfo.Engine.Session.Current.Catalog.CloseTable("tmp" + intUndo);
                }
                MapInfo.Data.Table nativetable = MapInfo.Engine.Session.Current.Catalog.CreateTable(native);
                table.Close();
                nativetable.Close();
                native.Dispose();
                nativetable = MapInfo.Engine.Session.Current.Catalog.OpenTable(fileName);
                mapControl1.Map.DrawingAttributes.EnableTranslucency = true;
                mapControl1.Map.DrawingAttributes.SmoothingMode = SmoothingMode.AntiAlias;
                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());

                // them du lieu thay doi tren map vao file vua tao        
                foreach (Feature f in irfc)
                {
                    string MaDT = "";
                    MaDT = cls.GetMaDoiTuong(f, LayerName);
                    CompositeStyle cs = new CompositeStyle();
                    cs.ApplyStyle(f.Style);
                    cls.UpdateDoiTuong(nativetable, f.Geometry, MaDT, cs, "");
                }
                toolUndo.Enabled = true;
                intUndo = intUndo + 1;
                nativetable.Close();
                irfc.Close();
            }catch (Exception ex){}
        }
        // thu tuc xoa file temp
        public void XoaFileTmp(string fileName)
        {
            string tabFile, datFile, idFile, mapFile;
            System.IO.FileInfo tabFileObj = new System.IO.FileInfo(fileName.ToUpper());
            tabFile = tabFileObj.Name.ToString();
            datFile = tabFileObj.Name.Replace(".TAB".ToUpper(), ".DAT".ToUpper());
            System.IO.FileInfo datFileObj = new System.IO.FileInfo(tabFileObj.Directory + "\\" + datFile);
            idFile = tabFileObj.Name.Replace(".TAB".ToUpper(), ".ID".ToUpper());
            System.IO.FileInfo idFileObj = new System.IO.FileInfo(tabFileObj.Directory + "\\" + idFile);
            mapFile = tabFileObj.Name.Replace(".TAB".ToUpper(), ".MAP".ToUpper());
            System.IO.FileInfo mapFileObj = new System.IO.FileInfo(tabFileObj.Directory + "\\" + mapFile);

            tabFileObj.Delete();
            datFileObj.Delete();
            idFileObj.Delete();
            mapFileObj.Delete();

        }


        //load file khi thuc thi undo redo
        //load file khi thuc thi undo redo
        public void LoadFileTmp(string fileName, MapControl pMap)
        {
            try
            {
                Table tabTmp = null;
                Table tab = null;
                //bang cua map vua load tu file
                tabTmp = MapInfo.Engine.Session.Current.Catalog.OpenTable(fileName);
                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tabTmp, MapInfo.Data.SearchInfoFactory.SearchAll());
                //bang tren map hien thoi
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                IResultSetFeatureCollection irfcTmp = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());
                int i = 0;
                foreach (Feature f in irfc)
                {
                    try
                    {
                        tab.DeleteFeature(irfcTmp[i]);
                    }
                    catch (Exception ex) { }
                    CompositeStyle cs = new CompositeStyle();                    
                    cs.ApplyStyle(f.Style);
                    cls.UpdateDoiTuong(tab, f.Geometry, "", cs, "");
                    i = i + 1;
                }
                 try
                    {
                        tab.DeleteFeature(irfcTmp[i]);
                    }
                 catch (Exception ex) { }
                irfc.Close();
                irfcTmp.Close();
                EditableLayer(pMap, LayerName, true);
                int iLayerIndex = pMap.Map.Layers.IndexOf(pMap.Map.Layers[LayerName]);
                pMap.Map.Layers.Move(iLayerIndex, 0);
            }
            catch (Exception ex) { }

        }
        public void EditableLayer(MapInfo.Windows.Controls.MapControl mapControl, string strLayerName, bool boolEditableLayer)
        {
            /* Chắc chắn rằng tồn tại điều khiển bản đồ - mapControl */
            if (mapControl == null)
                return;
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (mapControl.Map == null)
                return;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)mapControl.Map.Layers[strLayerName];
            /* Chắc chắn rằng tồn tại lớp bản đồ, có tên là strLayerName */
            if (featureLayer == null)
                return;
            MapInfo.Mapping.ToolFilter toolFilter =
                (MapInfo.Mapping.ToolFilter)mapControl.Tools.AddMapToolProperties.InsertionLayerFilter;
            if (toolFilter != null && !toolFilter.IncludeLayer(featureLayer))
                toolFilter.SetExplicitInclude(featureLayer, boolEditableLayer);
            toolFilter = (MapInfo.Mapping.ToolFilter)mapControl.Tools.SelectMapToolProperties.EditableLayerFilter;
            if (toolFilter != null && !toolFilter.IncludeLayer(featureLayer))
                toolFilter.SetExplicitInclude(featureLayer, boolEditableLayer);
        }
        private void toolExportsFile_Click(object sender, EventArgs e)
        {
            ExportsFileTab();
        }

        private void toolUndo_Click(object sender, EventArgs e)
        {
            toolUndo.Enabled = false;
            string fileName = "";
            fileName = Application.StartupPath;
            DirectoryInfo dir = new DirectoryInfo(fileName + @"\TempTach\");
            FileInfo[] file = dir.GetFiles("*.tab");

            if (intUndo >= 0 && intUndo <= file.Length)
            {
                for (int i = intUndo; i <= file.Length; i++)
                {
                    MapInfo.Engine.Session.Current.Catalog.CloseTable("tmp" + i);
                }

                if (intUndo == 0)
                {
                    toolUndo.Enabled = false;
                    toolRedo.Enabled = true;
                }
                else
                {
                    toolUndo.Enabled = true;
                    toolRedo.Enabled = true;
                }

                if (intUndo > 0)
                {
                    intUndo = intUndo - 1;
                    UndoRedo(intUndo);
                }
                else
                {
                    UndoRedo(0);
                }
            }
            toolUndo.Enabled = true;
        }

        private void toolRedo_Click(object sender, EventArgs e)
        {
            toolRedo.Enabled = false;
            string fileName = "";
            fileName = Application.StartupPath;
            DirectoryInfo dir = new DirectoryInfo(fileName + @"\TempTach\");
            FileInfo[] file = dir.GetFiles("*.tab");

            if (intUndo == file.Length)
            {
                toolRedo.Enabled = false;
                toolUndo.Enabled = true;
            }
            else
            {
                toolRedo.Enabled = true;
                toolUndo.Enabled = true;
            }

            if (intUndo <= file.Length)
            {
                if (intUndo < file.Length)
                {
                    intUndo = intUndo + 1;
                    UndoRedo(intUndo);
                }
                else
                { UndoRedo(file.Length); }

            }
            toolRedo.Enabled = true;

        }
        private void UndoRedo(int fileCount)
        {
            string fileName = "";
            fileName = Application.StartupPath;
            int intFile = fileCount;
            fileName = fileName + @"\TempTach\tmp" + fileCount.ToString() + ".TAB";
            LoadFileTmp(fileName, mapControl1);
        }

        private void toolCopyDoiTuong_Click(object sender, EventArgs e)
        {
            CopyOject(LayerName);
        }

        private void toolCopyDinhDanh_Click(object sender, EventArgs e)
        {
            cls.CopyDinhDang(mapControl1,CopyStyle, LayerName);
        }
        public void CopyOject(string LayerName)
        {
            Table tab = null;
            //gọi bảng hiện thời
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[tab];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count == 0)//
            {
                return;
            }
            DoiTuongCopy = new string[irfc.Count];
            //lưu vào đối tượng bộ đệm
            int i = 0;
            foreach (Feature f in irfc)
            {
                DoiTuongCopy[i] = f.Key.Value.ToString().Split('.')[0];
                i = i + 1;
            }

        }

        private void toolPasteDoiTuong_Click(object sender, EventArgs e)
        {
            try
            {
                if (DoiTuongCopy.Length > 0)
                {
                    cls.MoveObj(mapControl1, DoiTuongCopy, LayerName, MousePointEnd);
                    ExportsFileTab();
                }
            }
            catch (Exception ex) { }
        }

        private void toolPasteDinhDang_Click(object sender, EventArgs e)
        {
            cls.DanDinhDang("", mapControl1, 0, CopyStyle, LayerName,0,0);
            ExportsFileTab();
        }

        private void toolCopyTuBanDo_Click(object sender, EventArgs e)
        {
            cls.CopyTuBanDoTongThe(mapControl1, LayerName, TenLopDat);
            ExportsFileTab();
        }

        private void toolThemDiem_Click(object sender, EventArgs e)
        {
            panDiem.Show();
            ShowLocation(panDiem);
        }
        public void ShowLocation(System.Windows.Forms.Panel Mypanel)
        {

            Mypanel.Location = new System.Drawing.Point((SizeMapWidth - Convert.ToInt32(Mypanel.Width / 2)), SizeMapHeigt - Mypanel.Height / 2);
            Mypanel.BringToFront();
            // Mypanel.Location.Y = SizeMapHeigt - Mypanel.Height / 2;
        }

        private void toolThemDSDiem_Click(object sender, EventArgs e)
        {
            //hiên thị panel thêm danh sách toạ độ
            panThemDanhSachToaDo.Show();
            ShowLocation(panThemDanhSachToaDo);
            txtX.Text = "";
            txtY.Text = "";
            txtX.Focus();
            //tạo mới danh sách
            grdDanhSachToaDo.Rows.Clear();
        }

        private void toolChonNguoc_Click(object sender, EventArgs e)
        {
            cls.ChonNguocDoiTuong(LayerName);
        }

        private void toolEditThuaDat_Click(object sender, EventArgs e)
        {
            if (mapControl1.Map == null)
                return;
            if (mapControl1.Map.Layers[LayerName] == null)
                return;
            if (toolEditThuaDat.CheckState == CheckState.Checked)
            {
                EditThuaDat = true;
                toolEditThuaDat.Checked = false;
                EditMode = MapInfo.Tools.EditMode.Objects;
                mapControl1.Tools.SelectMapToolProperties.EditMode = EditMode;
                this.toolEditThuaDat.Image = global::DMC.Land.TachThua.Properties.Resources._lock;

            }
            else
            {
                EditThuaDat = false;
                toolEditThuaDat.Checked = true;
                EditMode = MapInfo.Tools.EditMode.Nodes;
                mapControl1.Tools.SelectMapToolProperties.EditMode = EditMode;
                this.toolEditThuaDat.Image = global::DMC.Land.TachThua.Properties.Resources.lock_off;
            }
        }

        private void toolmnuXoayDoiTuong_Click(object sender, EventArgs e)
        {
            panThemDiemLamGocXoay.Show();
            ShowLocation(panThemDiemLamGocXoay);
            panXoayDoiTuong.Hide();
        }

        private void toolChiaDoanThang_Click(object sender, EventArgs e)
        {
            chkToaDoDIem_ChiaCanh.Checked = true;
            panKhoangCachChia.Show();
            ShowLocation(panKhoangCachChia);
        }

        private void toolGiaoHaiDoanThang_Click(object sender, EventArgs e)
        {
            cls.GiaoDiem2DoanThang(mapControl1, LayerName);
        }

        private void toolMovePointInPolygon_Click(object sender, EventArgs e)
        {
            DiChuyenDinhThua = true;
            GanDinhVaoVung = DiemCuoiChonThua;
        }

        private void toolToaDoDiem_Click(object sender, EventArgs e)
        {
            LayToaDoDiem(mapControl1, LayerName);
            panToaDoDiem.Show();
            ShowLocation(panToaDoDiem);
        }

        private void toolSDSToaDo_Click(object sender, EventArgs e)
        {
            //panDanhSachToaDo.Show();
            panToaDo.Show();
            ShowLocation(panToaDo);
        }
        public void LayToaDoDiem(MapControl pMap, string LayerName)
        {
            Table table = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count != 1)
            {
                MessageBox.Show("Chọn đối tượng điểm để xem toạ độ !!!");
                return;
            }
            foreach (Feature f in irfc)
            {
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Point"))
                {
                    MapInfo.Geometry.Point d = new MapInfo.Geometry.Point(pMap.Map.GetDisplayCoordSys(), (MapInfo.Geometry.Point)f.Geometry);
                    txtToaDoDiemX.Text = d.X.ToString();
                    txtToaDoDiemY.Text = d.Y.ToString();
                }
            }
        }

        private void panMnuToaDoDiem_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panToaDoDiem, e);
        }

        private void panMnuToaDoDiem_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panToaDoDiem, e);
        }

        private void panToaDoDiem_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panToaDoDiem, e);
        }

        private void panToaDoDiem_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panToaDoDiem, e);
        }

        private void cmdCloseToaDoDiem_Click(object sender, EventArgs e)
        {
            panToaDoDiem.Hide();
        }
        private void cmdThoatToaDoDiem_Click(object sender, EventArgs e)
        {
            panToaDoDiem.Hide();
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panDiem, e);
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panDiem, e);
        }

        private void cmdCloseDiem_Click(object sender, EventArgs e)
        {
            panDiem.Hide();
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            panDiem.Hide();
        }

        private void panelDSToaDo_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panThemDanhSachToaDo, e);
        }

        private void panelDSToaDo_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panThemDanhSachToaDo, e);
        }

        private void panThemDanhSachToaDo_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panThemDanhSachToaDo, e);
        }

        private void panThemDanhSachToaDo_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panThemDanhSachToaDo, e);
        }

        private void cmdCloseThemDSToaDo_Click(object sender, EventArgs e)
        {
            panThemDanhSachToaDo.Hide();
        }

        private void cmdThoatDSToaDo_Click(object sender, EventArgs e)
        {
            panThemDanhSachToaDo.Hide();
        }

        private void panMenuPanToanDo_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panToaDo, e);
        }

        private void panMenuPanToanDo_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panToaDo, e);
        }

        private void panToaDo_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panToaDo, e);
        }

        private void panToaDo_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panToaDo, e);
        }

        private void cmdClosePanToaDo_Click(object sender, EventArgs e)
        {
            panToaDo.Hide();
        }

        private void panMnuThemDiemLamGocXoay_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panThemDiemLamGocXoay, e);
        }

        private void panMnuThemDiemLamGocXoay_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panThemDiemLamGocXoay, e);
        }

        private void panThemDiemLamGocXoay_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panThemDiemLamGocXoay, e);
        }

        private void panThemDiemLamGocXoay_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panThemDiemLamGocXoay, e);
        }

        private void cmdCloseThemDIemLamGocQuay_Click(object sender, EventArgs e)
        {
            panThemDiemLamGocXoay.Hide();
        }

        private void mnupanXoayDoiTuong_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panXoayDoiTuong, e);
        }

        private void mnupanXoayDoiTuong_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panXoayDoiTuong, e);
        }

        private void panXoayDoiTuong_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panXoayDoiTuong, e);
        }

        private void panXoayDoiTuong_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panXoayDoiTuong, e);
        }

        private void cmdClosepanXoayDoiTuong_Click(object sender, EventArgs e)
        {
            panXoayDoiTuong.Hide();
        }

        private void panDiem_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panDiem, e);
        }

        private void panDiem_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panDiem, e);
        }

        private void cmdChapNhanToaDo_Click(object sender, EventArgs e)
        {
            panToaDo.Hide();
        }

        private void cmdBoQuaThemDiemlamGocXoay_Click(object sender, EventArgs e)
        {
            panThemDiemLamGocXoay.Hide();
        }

        private void cmdThemDiemLamGocXoay_Click(object sender, EventArgs e)
        {
            DPoint d = new DPoint(); ;
            try
            {
                Table table = null;
                table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                //lấy tập hợp tất cả các đối tượng được chọn
                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong=101"));
                if (irfc != null)
                {
                    if (irfc.Count > 0)
                    {
                        foreach (Feature f in irfc)
                        {
                            table.DeleteFeature(f);
                        }
                    }
                }
                //kiểm tra xem toạ độ X,Y có trống hay ko
                if ((txtToaDoXoayX.Text != "") && (txtToaDoXoayY.Text != ""))
                {
                    //convert sang kieu du lieu double
                    d.x = Convert.ToDouble(txtToaDoXoayX.Text);
                    d.y = Convert.ToDouble(txtToaDoXoayY.Text);
                    //gọi hàm thêm mới điểm
                    //update doi tuong vao map va quy dinh ma cua doi tuong nay la 101
                    ThemDiem(mapControl1, d, LayerName, "101");
                    //an panel
                    panThemDiemLamGocXoay.Hide();
                    panXoayDoiTuong.Show();
                    ShowLocation(panXoayDoiTuong);
                    txtGocXoayDoiTuong.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiểm tra dữ liệu nhập vào !!!");
            }
        }
        //ham them moi 1 diem
        public void ThemDiem(MapControl pMap, DPoint d, string LayerName, string DoiTuong)
        {
            MapInfo.Geometry.FeatureGeometry pt;
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //dinh nghia font
            MapInfo.Styles.SimpleVectorPointStyle vs = new MapInfo.Styles.SimpleVectorPointStyle(33, System.Drawing.Color.Yellow, 10);
            MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(vs);
            //tạo đối tượng điểm
            pt = cls.mpxMkFeaturePoint(pMap.Map.GetDisplayCoordSys(), d.x, d.y);
            //hiển thị điểm lên Map
            cls.UpdateDoiTuong(tab, pt, DoiTuong, cs,"");

        }
        private void cmdChapNhanGocQuayDoiTuong_Click(object sender, EventArgs e)
        {
            bool ChieuQuay;
            if (radXoayDoiTuongCungChieu.Checked)
            {
                ChieuQuay = true;
            }
            else
            {
                ChieuQuay = false;
            }
            double gocXoay;
            gocXoay = Convert.ToDouble(txtGocXoayDoiTuong.Value);
            if (gocXoay <= 0)
            {
                return;
            }

            try
            {
                cls.XoayDoiTuong(mapControl1, LayerName, ChieuQuay, gocXoay);
                ExportsFileTab();
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdTaoVungDSToaDo_Click(object sender, EventArgs e)
        {
            if (grdDanhSachToaDoThuc.RowCount > 3)
            {
                cls.TaoVungTuDSToaDo(mapControl1, LayerName, grdDanhSachToaDoThuc);
                ExportsFileTab();
            }
        }

        private void cmdTaoDuongDSToaDo_Click(object sender, EventArgs e)
        {
            //Nếu danh sách toạ độ lớn hơn 1
            if (grdDanhSachToaDoThuc.Rows.Count > 2)
            {
                DPoint[] PointList = new DPoint[grdDanhSachToaDoThuc.Rows.Count];
                //lấy danh sách toạ độ điểm từ grid
                PointList = cls.GetPointList(grdDanhSachToaDoThuc);
                CompositeStyle cs = new CompositeStyle();
                //gọi hàm tạo đường
                cls.mpxDrawLine(mapControl1.Map, "", "", PointList, cs, LayerName, staProcess);
                ExportsFileTab();
            }
            else
            {
                MessageBox.Show("Đối tượng đường cần có toạ độ 2 điểm");
            }
        }

        private void mapControl1_Click(object sender, EventArgs e)
        {

            //gan toa do vao dieu khien de tao nut
            txtToaDoX.Text = toolX.ToString();
            txtToaDoY.Text = toolY.ToString();
            txtToaDoXoayX.Text = toolX.ToString();
            txtToaDoXoayY.Text = toolY.ToString();
            txtTamOx.Text = toolX.ToString();
            txtTamOy.Text = toolY.ToString();
            txtViTriX.Text = toolX.ToString();
            txtViTriY.Text = toolY.ToString();
            DPoint DiemCuoi = new DPoint();
            DiemCuoi.x = Convert.ToDouble(toolX);
            DiemCuoi.y = Convert.ToDouble(toolY);
            DiemCuoiChonThua = DiemCuoi;
            if (DiChuyenDinhThua)
            {
                DPoint DiemDiChuyen = new DPoint();
                DiemDiChuyen.x = Convert.ToDouble(toolX);
                DiemDiChuyen.y = Convert.ToDouble(toolY);
                GanDiemTheoVung(mapControl1, LayerName, GanDinhVaoVung, DiemCuoi);
            }
           // MessageBox.Show(mapControl1.Map.GetDisplayCoordSys().ToString());
        }

        public void GanDiemTheoVung(MapControl pMap, string LayerName, DPoint dDiem, DPoint DiemTrongThua)
        {
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());

            DPoint DiemCanTim = new DPoint();
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count == 0)
            {
                return;
            }
            DPoint[] dNew = null;//mang cac diem moi tao tu polygon tim duoc
            DPoint[] DiemThua = null;
            foreach (Feature f in irfc)
            {
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                {
                    foreach (Polygon poly in (MultiPolygon)f.Geometry)
                    {
                        DiemThua = poly.Exterior.SamplePoints();

                        double[] ChieuDai = new double[DiemThua.Length];
                        double GiaTriMin = 0;
                        if (f.Geometry.ContainsPoint(DiemTrongThua))
                        {
                            //tim tap hop chieu dai tu dinh chon den dinh thua
                            for (int i = 0; i < DiemThua.Length; i++)
                            {
                                double MySize = 0;
                                MySize = Math.Abs((DiemThua[i].x - DiemTrongThua.x) * (DiemThua[i].x - DiemTrongThua.x) - (DiemThua[i].y - DiemTrongThua.y) * (DiemThua[i].y - DiemTrongThua.y));
                                ChieuDai[i] = MySize;
                            }
                            GiaTriMin = ChieuDai[0];
                            //tim khoang cach nho nhat
                            for (int i = 1; i < ChieuDai.Length; i++)
                            {
                                GiaTriMin = Math.Min(ChieuDai[i], GiaTriMin);
                            }
                            dNew = new DPoint[DiemThua.Length];
                            //so sanh lai chieu dai nho nhat de tim ra dinh can tim
                            for (int i = 0; i < DiemThua.Length; i++)
                            {
                                double MySize = 0;
                                MySize = Math.Abs((DiemThua[i].x - DiemTrongThua.x) * (DiemThua[i].x - DiemTrongThua.x) - (DiemThua[i].y - DiemTrongThua.y) * (DiemThua[i].y - DiemTrongThua.y));
                                if (GiaTriMin == MySize)
                                {
                                    DiemCanTim = DiemThua[i];
                                    dNew[i] = dDiem;
                                }
                                else
                                {
                                    dNew[i] = DiemThua[i];
                                }

                            }
                            //tạo đối tượng polygon từ danh sách toạ độ vừa nhận
                            MultiPolygon polygon = new MultiPolygon(pMap.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, dNew);
                            //tạo mới đối tượng Feature
                            Feature fea = new Feature(tab.TableInfo.Columns);
                            fea = new MapInfo.Data.Feature(polygon, f.Style);
                            //Insert đối tương polygon vừa tạo vào bảng hiện thời
                            tab.InsertFeature(fea);

                            tab.DeleteFeature(f);
                            ExportsFileTab();
                        }
                    }
                }
            }
            DiChuyenDinhThua = false;
        }

        private void cmdThemDSToaDo_Click(object sender, EventArgs e)
        {
            if (txtX.Value == 0)
            {
                return;
            }
            if (txtY.Value == 0)
            {
                return;
            }
            txtX.Focus();
            //tạo dòng mới
            DataGridViewRow dr = new DataGridViewRow();
            //add dòng vừa tạo vào grid
            grdDanhSachToaDo.Rows.Add(dr);
            //gán các giá trị vừa nhập vào grid
            grdDanhSachToaDo.Rows[grdDanhSachToaDo.Rows.Count - 1].Cells[0].Value = txtX.Text;
            grdDanhSachToaDo.Rows[grdDanhSachToaDo.Rows.Count - 1].Cells[1].Value = txtY.Text;
            txtX.Text = "";
            txtY.Text = "";
            txtX.Focus();
        }

        private void cmdChapNhan_Click(object sender, EventArgs e)
        {
            DPoint d = new DPoint(); ;
            try
            {
                //kiểm tra xem toạ độ X,Y có trống hay ko
                if ((txtToaDoX.Text != "") && (txtToaDoY.Text != ""))
                {
                    //convert sang kieu du lieu double
                    d.x = Convert.ToDouble(txtToaDoX.Text);
                    d.y = Convert.ToDouble(txtToaDoY.Text);
                    //gọi hàm thêm mới điểm
                    ThemDiem(mapControl1, d, LayerName, "0");
                    ExportsFileTab();
                    //an panel
                    panDiem.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiểm tra dữ liệu nhập vào !!!" + ex.Message);
            }
        }

        private void mapControl1_Resize(object sender, EventArgs e)
        {
            SizeMapWidth = Convert.ToInt32(mapControl1.Width / 2);
            SizeMapHeigt = Convert.ToInt32(mapControl1.Height / 2);
        }

        private void panMnuKhoangCachChia_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panKhoangCachChia, e);
        }

        private void panMnuKhoangCachChia_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panKhoangCachChia, e);
        }

        private void panKhoangCachChia_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panKhoangCachChia, e);
        }

        private void panKhoangCachChia_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panKhoangCachChia, e);
        }

        private void cmdClosepanKhoangCachChia_Click(object sender, EventArgs e)
        {
            panKhoangCachChia.Hide();
        }

        private void cmdChiaDiem_Click(object sender, EventArgs e)
        {
            cls.ChiaDoanThang(mapControl1, LayerName, Convert.ToDouble(numKhoangCachChia.Value), true);
            ExportsFileTab();
        }

        private void cmdChiaDoanThang_Click(object sender, EventArgs e)
        {
            cls.ChiaDoanThang(mapControl1, LayerName, Convert.ToDouble(numKhoangCachChia.Value), false);
            ExportsFileTab();
        }

        private void numKhoangCachChia_ValueChanged(object sender, EventArgs e)
        {
            //thay doi gia tri cua chieu dai doan thang can chia
            double GiaTri;
            GiaTri = Convert.ToDouble(txtChieuDaiDoanThangChia.Text) - Convert.ToDouble(numKhoangCachChia.Value);
            try
            {
                txtConLaiKhoangCachChia.Value = Convert.ToDecimal(GiaTri);
            }
            catch (Exception ex)
            {
            }
        }

        private void txtConLaiKhoangCachChia_ValueChanged(object sender, EventArgs e)
        {
            double GiaTri;
            GiaTri = Convert.ToDouble(txtChieuDaiDoanThangChia.Text) - Convert.ToDouble(txtConLaiKhoangCachChia.Value);
            try
            {
                numKhoangCachChia.Value = Convert.ToDecimal(GiaTri);
            }
            catch (Exception ex)
            {
            }
        }

        private void toolTachRegion_Click(object sender, EventArgs e)
        {
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            if (tab == null)
            {
                return;
            }
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[tab];
            foreach (Feature f in irfc)
            {
                if (f.Geometry.GetType().ToString() == "MapInfo.Geometry.MultiPolygon")
                {
                    MultiPolygon mp = (MultiPolygon)f.Geometry;
                    foreach (Polygon pg in mp)
                    {
                        MultiPolygon newmp = new MultiPolygon(mapControl1.Map.GetDisplayCoordSys(), pg);
                        Feature fnew = new Feature(tab.TableInfo.Columns);
                        fnew.Geometry = newmp;
                        fnew.Style = f.Style;
                        tab.InsertFeature(fnew);
                    }

                }
                tab.DeleteFeature(f);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            /* Thiết lập trạng thái cập nhật */
            this.TrangThaiCapNhat(true);
            /* Thiết lập trạng thái chức năng */
            this.TrangThaiChucNang(true, false);
        }

        private void mapToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            MyCurso = e.Button.ToolTipText;
            OldKey = mapControl1.Tools.LeftButtonTool;

            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            mapControl1.Map.Invalidate();

            if (MyCurso == "CustomArc")
            {
                if (tab == null)
                { return; }
                else
                {
                    mapControl1.Tools.LeftButtonTool = "CustomArc";
                }

            }
            else
            {
                toolBarArc.Pushed = false;
            }
            //if (e.Button.Name == "toolBarButtonDoChieuDaiCanh")
            //{
            //    mapControl1.Tools.LeftButtonTool = "CustomPolylineMapTool";
            //    ChieuDaiCanh = 0;
            //}
            //else
            //{
            //    toolBarButtonDoChieuDaiCanh.Pushed = false;
            //    ChieuDaiCanh = 0;
            //}
            if (e.Button.Name == "toolBarButtonChuViDienTich")
            {
                mapControl1.Tools.LeftButtonTool = "CustomPolylineMapTool";
                DienTichDo  = 0;
                ChuViDo = 0;
            }
            else
            {
                toolBarButtonChuViDienTich.Pushed = false;
                DienTichDo = 0;
                ChuViDo = 0;
            }
            if (e.Button.Name == "toolBarPolygon")
            {
                if (tab == null)
                {
                    return;
                }
                else
                {
                    mapControl1.Tools.LeftButtonTool = "CustomPolygon";
                }
            }
            else
            {
                toolBarPolygon.Pushed = false;
            }
            
        }

        private void mapControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //neu an nut S cua ban phim thi chuc nang snap se duoc thuc hien
            if (e.KeyChar == 's')
                mapControl1.Tools.MapToolProperties.SnapEnabled
                    = !mapControl1.Tools.MapToolProperties.SnapEnabled;
            mapControl1.Tools.MapToolProperties.SnapTolerance = 1;
        }
        public void RefreshMap(MapControl pMap, string LayerName)
        {
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            pMap.Map.Invalidate();
            if (tab == null)
            { return; }
            tab.Refresh();
        }

        private void mapControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((mapControl1.Tools.LeftButtonTool == "Pan") || (mapControl1.Tools.LeftButtonTool == "ZoomIn") || (mapControl1.Tools.LeftButtonTool == "ZoomOut"))
            {
                mapControl1.Tools.LeftButtonTool = OldKey;
                mapControl1.Refresh();
            }
        }
        //ham chuc nang thuc thi viec an va hien nut tren map
        public void AnHienNut(MapControl pMap, string LayerName)
        {
            if (mapControl1.Map == null)
                return;
            if (mapControl1.Map.Layers[LayerName] == null)
                return;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)pMap.Map.Layers[LayerName];
            if (featureLayer.ShowNodes)
                featureLayer.ShowNodes = false;
            else
            {
                featureLayer.ShowNodes = true;
            }
        }
        public void ConverPolyLine(MapControl pMap, string LayerName, ToolStripProgressBar staProcess)
        {
            cls.BreakFeatureCollectionInLayer(pMap.Map, LayerName, staProcess);
        }
        public void HuongCuaDoanThang(MapControl pMap, string LayerName)
        {
            if (pMap.Map == null)
                return;
            if (pMap.Map.Layers[LayerName] == null)
                return;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)pMap.Map.Layers[LayerName];
            //neu huong doan thang da duoc hien thi thi tat di
            if (featureLayer.ShowLineDirection)
                featureLayer.ShowLineDirection = false;
            else
            {
                //neu da tat di roi thi lai hien thi len
                featureLayer.ShowLineDirection = true;
            }
        }
        private void mapControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ////neu an ban phim dau cach thi chuc nang pan duoc goi den
            //if ((e.KeyData == (Keys.Space)))
            //{
            //    if (mapControl1.Tools.LeftButtonTool != "AddText")
            //    {
            //        mapControl1.Tools.LeftButtonTool = "Pan";
            //        RefreshMap(mapControl1, LayerName);
            //    }
            //}
            ////neu an to hop phim ctr + i thi chuc nang ZoomIn duoc thuc thi
            //if ((e.KeyData == (Keys.Control | Keys.I)))
            //{
            //    mapControl1.Tools.LeftButtonTool = "ZoomIn";
            //    RefreshMap(mapControl1, LayerName);
            //}
            ////neu an to hop phim ctr + O thi chuc nang ZoomOut duoc thuc thi
            //if ((e.KeyData == (Keys.Control | Keys.O)))
            //{
            //    mapControl1.Tools.LeftButtonTool = "ZoomOut";
            //    RefreshMap(mapControl1, LayerName);
            //}
            //if ((e.KeyData == (Keys.Control | Keys.Space)))
            //{
            //    mapControl1.Tools.LeftButtonTool = "Select";
            //    cls.ExecutePushMapTool(mapToolBar, mapToolBarButtonSelect, OldKey);
            //}
            //neu an ban phim dau cach thi chuc nang pan duoc goi den
            if ((e.KeyData == (Keys.Space)))
            {
                if (mapControl1.Tools.LeftButtonTool != "AddText")
                {
                    mapControl1.Tools.LeftButtonTool = "Pan";
                    RefreshMap(mapControl1, LayerName);
                }
            }
            //neu an to hop phim ctr + i thi chuc nang ZoomIn duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Z)))
            {
                mapControl1.Tools.LeftButtonTool = "ZoomIn";
                RefreshMap(mapControl1, LayerName);
            }
            //neu an to hop phim ctr + O thi chuc nang ZoomOut duoc thuc thi
            if ((e.KeyData == (Keys.Shift | Keys.Z)))
            {
                mapControl1.Tools.LeftButtonTool = "ZoomOut";
                RefreshMap(mapControl1, LayerName);
            }
            //neu an to hop phim ctr + D thi chuc nang Huy chon tat cac cac doi tuong duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.D)))
            {
                cls.CancelSelect();
            }
            //neu an to hop phim ctr + A thi chuc nang "Chon tat ca cac doi tuong" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.A)))
            {
                cls.SelectAll(mapControl1, LayerName);
            }
            //neu an phim delete thi chuc nang "Xoa doi tuong" duoc thuc thi
            //if ((e.KeyData == (Keys.Delete)))
            //{
            //    if (toolEditThuaDat.CheckState == CheckState.Checked)
            //    {
            //        cls.DelSelect(mapControl1, LayerName, false);
            //    }
            //    else
            //    {
            //        cls.DelSelect(mapControl1, LayerName, true);
            //    }
            //}
            //lay cac dieu khien tren thanh cong cu chuan
            //an to hop phim Ctr va phim ==>
            //"dau cach" thi chuc nang select duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Space)))
            {
                mapControl1.Tools.LeftButtonTool = "Select";
                cls.ExecutePushMapTool(mapToolBar, mapToolBarButtonSelect, OldKey);
            }
            //"Q" thi chuc nang Them duong tron duoc thuc thi
           
            //"L" thi chuc nang "Them doi tuong Duong thang" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.L)))
            {
                mapControl1.Tools.LeftButtonTool = "AddLine";
                cls.ExecutePushMapTool(mapToolBar, mapToolBarButtonAddLine, OldKey);
            }
            //"P" thi chuc nang "Them doi tuong diem" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.P)))
            {
                mapControl1.Tools.LeftButtonTool = "AddPoint";
                cls.ExecutePushMapTool(mapToolBar, mapToolBarButtonAddPoint, OldKey);
            }
            ////"W" thi chuc nang "Them Doi tuong Polygon" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.W)))
            {
                mapControl1.Tools.LeftButtonTool = "AddPolygon";
                cls.ExecutePushMapTool(mapToolBar, mapToolBarButtonAddPolygon, OldKey);
            }
            //"Y" thi chuc nang "them Doi tuong polyline" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Y)))
            {
                mapControl1.Tools.LeftButtonTool = "AddPolyline";
                cls.ExecutePushMapTool(mapToolBar, mapToolBarButtonAddPolyline, OldKey);
            }
      
            //An to hop phim ctr + shift voi  ==>
            //"P" thi chuc nang "Chon theo Doi tuong Polygon" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Shift | Keys.P)))
            {
                mapControl1.Tools.LeftButtonTool = "SelectPolygon";
                cls.ExecutePushMapTool(mapToolBar, mapToolBarButtonSelectPolygon, OldKey);
            }
            //"R" thi chuc nang "Chon theo Doi tuong Radius" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Shift | Keys.R)))
            {
                mapControl1.Tools.LeftButtonTool = "SelectRadius";
                cls.ExecutePushMapTool(mapToolBar, mapToolBarButtonSelectRadius, OldKey);
            }
            //"T" thi chuc nang "Chon theo Doi tuong Rect" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Shift | Keys.T)))
            {
                mapControl1.Tools.LeftButtonTool = "SelectRect";
                cls.ExecutePushMapTool(mapToolBar, mapToolBarButtonSelectRectangle, OldKey);
            }
            
            //an to hop phim Ctr + C thi chuc nang copy duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.C)))
            {
                //CopyOject(LayerName);
            }
            //an to hop phim Ctr + V thi chuc nang Paste duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.V)))
            {

                if (DoiTuongCopy.Length > 0)
                {
                    // cls.MoveObj(mapControl1, DoiTuongCopy, LayerName, MousePointEnd);
                }
            }
            if ((e.KeyData == (Keys.Control | Keys.Alt | Keys.C)))
            {
                cls.CopyDinhDang(mapControl1, CopyStyle, LayerName);
            }
            if ((e.KeyData == (Keys.Control | Keys.Alt | Keys.V)))
            {
                cls.DanDinhDang(strTenBangDat, mapControl1, Convert.ToInt64(FeatureID.ToString().Split('.')[0]), CopyStyle, LayerName, 0, 0);
                ExportsFileTab();
            }
           
            if ((e.KeyData == (Keys.Control | Keys.I)))
            {
                cls.ChonNguocDoiTuong(LayerName);
            }
          
            if ((e.KeyData == (Keys.Alt | Keys.V)))
            {
                cls.CombineFeatures(mapControl1, LayerName, staProcess);
            }
            if ((e.KeyData == (Keys.Alt | Keys.D)))
            {
                cls.ConvertToPolyline(mapControl1, LayerName, staProcess);
                ExportsFileTab();
            }
            if ((e.KeyData == (Keys.Alt | Keys.C)))
            {
                ConverPolyLine(mapControl1, LayerName, staProcess);
                ExportsFileTab();
            }
            if ((e.KeyData == (Keys.Alt | Keys.X)))
            {
                panThemDiemLamGocXoay.Show();
                ShowLocation(panThemDiemLamGocXoay);
                panXoayDoiTuong.Hide();
            }
            if ((e.KeyData == (Keys.Alt | Keys.T)))
            {
                chkToaDoDIem_ChiaCanh.Checked = true;
                panKhoangCachChia.Show();
                ShowLocation(panKhoangCachChia);
            }
            if ((e.KeyData == (Keys.Alt | Keys.G)))
            {
                cls.GiaoDiem2DoanThang(mapControl1, LayerName);
            }
            if ((e.KeyData == (Keys.Alt | Keys.B)))
            {
                DiChuyenDinhThua = true;
                GanDinhVaoVung = DiemCuoiChonThua;
            }
            if ((e.KeyData == (Keys.Alt | Keys.Z)))
            {
                AnHienNut(mapControl1, LayerName);
            }
            if ((e.KeyData == (Keys.Alt | Keys.H)))
            {
                HuongCuaDoanThang(mapControl1, LayerName);
            }
            if ((e.KeyData == (Keys.Alt | Keys.F)))
            {
                LayToaDoDiem(mapControl1, LayerName);
                panToaDoDiem.Show();
                ShowLocation(panToaDoDiem);
            }
           
            if ((e.KeyData == (Keys.Alt | Keys.S)))
            {
                panToaDo.Show();
            }
           
        }
        public void ThongTinKiemKeMucDichSuDung(string MaMucDich)
        {

            DMC.Land.TachThua.clsHoSoCapGCN clsTT = new DMC.Land.TachThua.clsHoSoCapGCN();
            clsTT.Connection = strConnection;
            clsTT.TrangThai = MaMucDich.ToString();
            DataTable dt = new DataTable();
            dt = clsTT.SelMucDichDayCapGCN();
            string tabAlia = "";
            int R, G, B;
            tabAlia = dt.Rows[0]["MoTa"].ToString();
            R = (int)dt.Rows[0]["R"];
            G = (int)dt.Rows[0]["G"];
            B = (int)dt.Rows[0]["B"];
            Color cr = Color.FromArgb(R, G, B);
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable("Đất");
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MucDichSuDung='" + MaMucDich + "'"));

            if (MapInfo.Engine.Session.Current.Catalog.GetTable(tabAlia) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(tabAlia);
            }
            Table tab = null;
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(tabAlia) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(tabAlia);
            }
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(tabAlia.Replace(" ", "_")) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(tabAlia.Replace(" ", "_"));
            }
            //tao doi tuong table co ten la tmp cho bang thua dat

            tab = cls.CreateDataTable(mapControl1.Map, table.Alias, tabAlia.Replace(" ", "_"), table);

            CompositeStyle cs = new CompositeStyle();
            foreach (Feature f in irfc)
            {
                ((SimpleInterior)cs.AreaStyle.Interior).ForeColor = cr;
                cls.UpdateDoiTuong(tab, f.Geometry, "", cs,"");
            }
            FeatureLayer fl = new FeatureLayer(tab);
            mapControl1.Map.Layers.Add(fl);
            int iLayerIndex = mapControl1.Map.Layers.IndexOf(mapControl1.Map.Layers[tabAlia.Replace(" ", "_")]);
            mapControl1.Map.Layers.Move(iLayerIndex, mapControl1.Map.Layers.Count - 1);

        }
        public void ThongTinTrangThaiCapGCN(int TrangThai)
        {

            DMC.Land.TachThua.clsHoSoCapGCN clsTT = new DMC.Land.TachThua.clsHoSoCapGCN();
            clsTT.Connection = strConnection;
            clsTT.TrangThai = TrangThai.ToString();
            DataTable dt = new DataTable();
            dt = clsTT.SelTrangThaiCapGCN();
            string tabAlia = "";
            int R, G, B;
            tabAlia = dt.Rows[0]["MoTa"].ToString();
            R =(int) dt.Rows[0]["R"];
            G= (int)dt.Rows[0]["G"];
            B=(int) dt.Rows[0]["B"];
            Color cr = Color.FromArgb(R, G, B);
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable("Đất");
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("Status=" + TrangThai + ""));

            if (MapInfo.Engine.Session.Current.Catalog.GetTable(tabAlia) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(tabAlia);
            }
            Table tab = null;
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(tabAlia) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(tabAlia);
            }
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(tabAlia.Replace(" ", "_")) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(tabAlia.Replace(" ", "_"));
            }
            //tao doi tuong table co ten la tmp cho bang thua dat

            tab = cls.CreateDataTable(mapControl1.Map, table.Alias, tabAlia.Replace(" ", "_"), table);

            CompositeStyle cs = new CompositeStyle();
            foreach (Feature f in irfc)
            {
                ((SimpleInterior)cs.AreaStyle.Interior).ForeColor = cr;
                if (f.Geometry !=null ){
                 cls.UpdateDoiTuong(tab, f.Geometry, "", cs,"");
                }
            }
            FeatureLayer fl = new FeatureLayer(tab);
            mapControl1.Map.Layers.Add(fl);
            int iLayerIndex = mapControl1.Map.Layers.IndexOf(mapControl1.Map.Layers[tabAlia.Replace(" ", "_")]);
            mapControl1.Map.Layers.Move(iLayerIndex, mapControl1.Map.Layers.Count-1);
                   
        }
        private void ToolTrangThaiGCN_Click(object sender, EventArgs e)
        {
            DMC.Land.TachThua.clsHoSoCapGCN clsTT = new DMC.Land.TachThua.clsHoSoCapGCN();
            clsTT.Connection = strConnection;
            DataTable dt = new DataTable();
            dt = clsTT.SelAllTrangThai();
           
            for (int i =0 ; i < dt.Rows.Count; i ++)
            {
                ThongTinTrangThaiCapGCN((int)dt.Rows[i]["KyHieu"]);
            }
        }

        private void toolStripMenuItemOutCT_Click(object sender, EventArgs e)
        {
            MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            if (tab == null)
            {
                return;
            }
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\RestoreMapTach\");
            FileInfo[] file = dir.GetFiles("*.tab");
            string fileName = "";
            int IndexPhucHoi = 0;
            IndexPhucHoi = file.Length  ;
            fileName = Application.StartupPath;
            //lay duong dan file du lieu temp can tao ra
            if (IndexPhucHoi >0)
                {
                    fileName = fileName + @"\RestoreMapTach\" + file[0];
                LoadFileTmp(fileName, mapControl1);
                File.Delete(fileName);
                File.Delete(fileName.Replace("Tab", "Id"));
                File.Delete(fileName.Replace("Tab", "Dat"));
                File.Delete(fileName.Replace("Tab", "Map"));
                }
        }

        private void toolStripMenuItemUndo_Click(object sender, EventArgs e)
        {
         if (intUndo > 2)
            {
                // xoa file tmp khi undo den giai doan giua rui lam tiep
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\tempTach\");
                FileInfo[] file = dir.GetFiles("*.tab");
                intUndo = file.Length - 2;
                string fileName = "";
                fileName = Application.StartupPath;
                //lay duong dan file du lieu temp can tao ra
                fileName = fileName + @"\tempTach\tmp" + intUndo + ".TAB";
                try
                {
                    for (int i = intUndo; i <= file.Length; i++)
                    {
                        MapInfo.Engine.Session.Current.Catalog.CloseTable("tmp" + i);
                    }
                }
                catch (Exception ex) { }
                LoadFileTmp(fileName, mapControl1);
            }
        }

        private void toolStripMenuItemBanDoKiemKe_Click(object sender, EventArgs e)
        {
            DMC.Land.TachThua.clsHoSoCapGCN clsTT = new DMC.Land.TachThua.clsHoSoCapGCN();
            clsTT.Connection = strConnection;
            DataTable dt = new DataTable();
            dt = clsTT.SelAllMucDichSDD();
           for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThongTinKiemKeMucDichSuDung(dt.Rows[i]["KyHieu"].ToString());
            }
             
        }

        //tat trang thai kiem ke
        private void toolStripMenuItemKiemKe_Click(object sender, EventArgs e)
        {
            try
            {
                DMC.Land.TachThua.clsHoSoCapGCN clsTT = new DMC.Land.TachThua.clsHoSoCapGCN();
                clsTT.Connection = strConnection;
                DataTable dt = new DataTable();
                dt = clsTT.SelAllMucDichSDD();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (MapInfo.Engine.Session.Current.Catalog.GetTable(dt.Rows[i]["MoTa"].ToString().Replace(" ", "_")) != null)
                    {
                        MapInfo.Engine.Session.Current.Catalog.CloseTable(dt.Rows[i]["MoTa"].ToString().Replace(" ", "_"));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(""); }
        }
        //tat trang thai ho so
        private void toolStripMenuItemTatTrangThaiHoSo_Click(object sender, EventArgs e)
        {
            try
            {
                DMC.Land.TachThua.clsHoSoCapGCN clsTT = new DMC.Land.TachThua.clsHoSoCapGCN();
                clsTT.Connection = strConnection;
                DataTable dt = new DataTable();
                dt = clsTT.SelAllTrangThai();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (MapInfo.Engine.Session.Current.Catalog.GetTable(dt.Rows[i]["MoTa"].ToString().Replace(" ", "_")) != null)
                    {
                        MapInfo.Engine.Session.Current.Catalog.CloseTable(dt.Rows[i]["MoTa"].ToString().Replace(" ", "_"));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(""); }
        }

        private void toolStripConvertPolyLine_Click(object sender, EventArgs e)
        {
            //goi ham convert
            cls.ConvertToPolyline(mapControl1, LayerName, staProcess);
            ExportsFileTab();
            mapControl1.Map.Invalidate();
        }

        private void panMnuTamDuongTron_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panTamDuongTron, e);
        }

        private void panMnuTamDuongTron_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panTamDuongTron, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panTamDuongTron.Hide();
        }

        private void panMnuBanKinhDuongTron_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panBanKinhDuongTron, e);
        }

        private void panMnuBanKinhDuongTron_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panBanKinhDuongTron, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panBanKinhDuongTron.Hide();
        }

        private void cmdChapNhanTamDuongTrong_Click(object sender, EventArgs e)
        {
            DPoint dTam = new DPoint();

            dTam.x = Convert.ToDouble(txtTamOx.Text);
            dTam.y = Convert.ToDouble(txtTamOy.Text);

            if (cls.TamDuongTron(mapControl1, LayerName, dTam))
            {
                panTamDuongTron.Hide();
                panBanKinhDuongTron.Show();
                ShowLocation(panBanKinhDuongTron);
                ExportsFileTab();
            }
        }

        private void cmdVeDuongTron_Click(object sender, EventArgs e)
        {
            if (numBanKinhDuongTron.Value <= 0)
            {
                return;
            }
            double BanKinh = 0;
            BanKinh = (double)numBanKinhDuongTron.Value;
            cls.VeDuongTron(mapControl1, LayerName, BanKinh);
            ExportsFileTab();
        }

        private void toolVeDuongTron_Click(object sender, EventArgs e)
        {
            panTamDuongTron.Show();
           ShowLocation(panTamDuongTron);
        }

        private void toolGiao2DuongTron_Click(object sender, EventArgs e)
        {
            cls.Giao2DuongTron(mapControl1, LayerName);
            ExportsFileTab();
        }

        private void panel9_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panViTriDiemChuyen, e);
        }

        private void panel9_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panViTriDiemChuyen, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panViTriDiemChuyen.Hide();
        }

        private void cmdBoQuaDIemVITri_Click(object sender, EventArgs e)
        {
            panViTriDiemChuyen.Hide();
        }

        private void cmdChapNhanDiemViTri_Click(object sender, EventArgs e)
        {
            if (grdDanhSachToaDo.RowCount > 2)
            {
                DPoint dTam = new DPoint();

                dTam.x = Convert.ToDouble(txtTamOx.Text);
                dTam.y = Convert.ToDouble(txtTamOy.Text);

                if (cls.TamDuongTron(mapControl1, LayerName, dTam))
                {
                    if ((dTam.x != 0) & (dTam.y != 0))
                    {
                        panTamDuongTron.Hide();
                        //thuc thi viec chuyen doi du lieu
                        cls.ChuyenToaDoThuc(dTam, grdDanhSachToaDo, grdDanhSachToaDoThuc);                        
                    }
                }
            }
        }

        private void cmdChuyenToaDoThuc_Click(object sender, EventArgs e)
        {
            panViTriDiemChuyen.Show();
            ShowLocation(panViTriDiemChuyen);
        }
        //tu dong tim den dinh gan nhat
        private void toolStripTuDongGanDinh_Click(object sender, EventArgs e)
        {
            Table tabTHua =  MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            Table tabBanDo = MapInfo.Engine.Session.Current.Catalog.GetTable(TenLopDat );

            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[tabTHua];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count != 1)
            {
                return;
            }
            Feature f = (Feature)irfc[0];

            if (tabTHua == null) { return; }

           
            //tao mot lop layer tam de luu cac thua tim thay

            if (MapInfo.Engine.Session.Current.Catalog.GetTable("loptmp") != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable("loptmp");
            }
            Table dt = cls.CreateTable(mapControl1.Map, tabBanDo, "loptmp");
            DMC.GIS.Common.SearchTools searchTools = new DMC.GIS.Common.SearchTools();
            MapInfo.Data.IResultSetFeatureCollection fc = searchTools.SearchWithIntersect(mapControl1.Map, tabBanDo.Alias, f.Geometry);

            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(dt.TableInfo.Columns);

           foreach (Feature ff in fc)
            {
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                {
                    //Mamg diem can tim 
                    DPoint[] dmang = new DPoint[1];
                    //================================================
                    DPoint[] dThuaChon = null;
                    DPoint[] dThua = null;
                    MultiPolygon plgTHuaChon = (MultiPolygon)f.Geometry;
                    MultiPolygon plgThuaTim = (MultiPolygon)ff.Geometry;


                    //lay tap hop dinh cua Vugn Thua chon
                    foreach (Polygon pl in plgTHuaChon)
                    {
                        dThuaChon = pl.Exterior.SamplePoints();
                    }
                    //lay tap hop diem cua vung thua tim thay
                    foreach (Polygon pl in plgThuaTim)
                    {
                        dThua = pl.Exterior.SamplePoints();
                    }

                    //kiem tra xem co diem nao nam trong thua khong
                    bool kt1 = false;
                    for (int i = 0; i < dThuaChon.Length - 1; i++)
                    {
                        if (ff.Geometry.ContainsPoint(dThuaChon[i]))
                        {
                            kt1 = true;
                        }
                    }


                    //kiem tra xem co diem nao nam trong thua khong
                    bool kt2 = false;
                    for (int i = 0; i < dThua.Length - 1; i++)
                    {
                        if (f.Geometry.ContainsPoint(dThua[i]))
                        {
                            kt2 = true;
                        }
                    }

                    MultiCurve cv1 = new MultiCurve(mapControl1.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, dThuaChon);
                    MultiCurve cv2 = new MultiCurve(mapControl1.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, dThua);


                    int VitriDiem = 0;
                    //lay vi tri diem cuoi cung cua thua chon truoc khi diem nam trong thua tim thay
                    if (kt1)
                    {
                        for (int i = 0; i < dThuaChon.Length - 1; i++)
                        {
                            if (i == 0)
                            {
                                if (ff.Geometry.ContainsPoint(dThuaChon[i]) && !ff.Geometry.ContainsPoint(dThuaChon[dThuaChon.Length - 1]))
                                {
                                    VitriDiem = i;
                                    goto thoat1;
                                }
                            }
                            else
                            {
                                if (ff.Geometry.ContainsPoint(dThuaChon[i]) && !ff.Geometry.ContainsPoint(dThuaChon[i - 1]))
                                {
                                    VitriDiem = i;
                                    goto thoat1;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dThuaChon.Length; i++)
                        {
                            DPoint[] dd = new DPoint[2];
                            dd[0] = dThuaChon[i];
                            if (i == dThuaChon.Length - 1)
                            {
                                dd[1] = dThuaChon[0];
                            }
                            else
                            {
                                dd[1] = dThuaChon[i + 1];
                            }
                            MultiCurve cv1tmp = new MultiCurve(mapControl1.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, dd);
                            MultiPoint mP = new MultiPoint(mapControl1.Map.GetDisplayCoordSys());
                            mP = cv2.IntersectNodes(cv1tmp, IntersectTypes.InclAll);
                            if (mP.PointCount > 0)
                            {

                                VitriDiem = i + 1;

                            }
                        }

                    }
                thoat1:
                    //xet lai mang diem cho thua duoc chon
                    DPoint[] dmangdiemTHuachon = new DPoint[1];


                    for (int i = VitriDiem - 1; i >= 0; i--)
                    {
                        dmangdiemTHuachon[dmangdiemTHuachon.Length - 1] = dThuaChon[i];
                        dmangdiemTHuachon = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)dmangdiemTHuachon, new DPoint[dmangdiemTHuachon.Length + 1]);
                    }
                    for (int i = dThuaChon.Length - 2; i >= VitriDiem; i--)
                    {
                        dmangdiemTHuachon[dmangdiemTHuachon.Length - 1] = dThuaChon[i];
                        dmangdiemTHuachon = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)dmangdiemTHuachon, new DPoint[dmangdiemTHuachon.Length + 1]);
                    }

                    dmangdiemTHuachon[dmangdiemTHuachon.Length - 1] = dmangdiemTHuachon[0];


                    //DPoint[] d = new DPoint[dmangdiemTHuachon.Length];
                    //d = dmangdiemTHuachon;
                    //DPoint PStart;
                    //DPoint PEnd;
                    //DPoint[] PPoint = new DPoint[2];
                    ////khai báo định dạng font cho text
                    //int fontSize = 5;
                    //TextStyle ts = cls.mpxMkTextStyle(fontSize, ".VnArial");

                    //MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();
                    //cs.ApplyStyle(ts);

                    //double ChieuDai;
                    //double DienTichNhan = 0;
                    //DienTichNhan = cls.DienTichCuaNhan(fontSize, 100, 20);
                    //ChieuDai = Math.Sqrt(DienTichNhan);
                    //for (int i = 0; i < d.Length - 1; i++)
                    //{
                    //    //tạo đối tượng bounds cho text
                    //    PStart.x = d[i].x - ChieuDai / 2;
                    //    PStart.y = d[i].y - ChieuDai / 2;
                    //    PEnd.x = d[i].x + ChieuDai / 2;
                    //    PEnd.y = d[i].y + ChieuDai / 2;
                    //    MapInfo.Geometry.DRect tmp = new MapInfo.Geometry.DRect(PStart, PEnd);
                    //    DPoint PStartNew = new DPoint();
                    //    DPoint PEndNew = new DPoint();
                    //    PStartNew.x = d[i].x - tmp.Height() / 2;
                    //    PStartNew.y = d[i].y - tmp.Width() / 2;
                    //    PEndNew.x = d[i].x + tmp.Height() / 2;
                    //    PEndNew.y = d[i].y + tmp.Width() / 2;
                    //    MapInfo.Geometry.DRect rect = new MapInfo.Geometry.DRect(PStartNew, PEndNew);
                    //    //tạo mới đối tượng text
                    //    MapInfo.Geometry.LegacyText g = new MapInfo.Geometry.LegacyText(mapControl1.Map.GetDisplayCoordSys(), rect, (i + 1).ToString());

                    //    //update đối tượng vào bảngF
                    //    cls.UpdateDoiTuong(dt, g, "1", cs);
                    //}



                    //xet lai mang diem cho thua tim thay

                    int VitriDiemThua = 0;
                    //lay vi tri diem cuoi cung cua thua chon truoc khi diem nam trong thua tim thay
                    if (kt2)
                    {
                        for (int i = 0; i < dThua.Length - 1; i++)
                        {
                            if (i == 0)
                            {
                                if (f.Geometry.ContainsPoint(dThua[i]) && !f.Geometry.ContainsPoint(dThua[dThua.Length - 1]))
                                {
                                    VitriDiemThua = i;
                                    goto thoat2;
                                }
                            }
                            else
                            {
                                if (f.Geometry.ContainsPoint(dThua[i]) && !f.Geometry.ContainsPoint(dThua[i - 1]))
                                {
                                    VitriDiemThua = i;
                                    goto thoat2;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dThua.Length - 1; i++)
                        {
                            DPoint[] dd = new DPoint[2];
                            dd[0] = dThua[i];
                            dd[1] = dThua[i + 1];
                            MultiCurve cv2tmp = new MultiCurve(mapControl1.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, dd);
                            MultiPoint mP = new MultiPoint(mapControl1.Map.GetDisplayCoordSys());
                            mP = cv1.IntersectNodes(cv2tmp, IntersectTypes.InclAll);
                            if (mP.PointCount > 0)
                            {

                                VitriDiemThua = i + 1;
                            }
                        }

                    }
                thoat2:
                    DPoint[] dmangdiemTHua = new DPoint[1];

                    if (VitriDiemThua == 0)
                    {
                        VitriDiemThua = dThua.Length - 1;
                    }
                    for (int i = VitriDiemThua - 1; i >= 0; i--)
                    {
                        dmangdiemTHua[dmangdiemTHua.Length - 1] = dThua[i];
                        dmangdiemTHua = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)dmangdiemTHua, new DPoint[dmangdiemTHua.Length + 1]);
                    }
                    for (int i = dThua.Length - 2; i >= VitriDiemThua; i--)
                    {
                        dmangdiemTHua[dmangdiemTHua.Length - 1] = dThua[i];
                        dmangdiemTHua = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)dmangdiemTHua, new DPoint[dmangdiemTHua.Length + 1]);
                    }



                    dmangdiemTHua[dmangdiemTHua.Length - 1] = dmangdiemTHua[0];



                    //lay tat ca cac diem nam ngoai thua duoc chon ()
                    for (int i = 0; i < dmangdiemTHuachon.Length - 1; i++)
                    {
                        if (!ff.Geometry.ContainsPoint(dmangdiemTHuachon[i]))
                        {

                            dmang[dmang.Length - 1] = dmangdiemTHuachon[i];
                            dmang = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)dmang, new DPoint[dmang.Length + 1]);

                        }
                    }

                    dThua = dmangdiemTHua;

                    //lay giao diem cua thua quy hoach va thua dat
                    MultiCurve cvThuaChon = new MultiCurve(mapControl1.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, dmangdiemTHuachon);
                    MultiCurve cvThua = new MultiCurve(mapControl1.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, dThua);
                    MultiPoint mPoint = new MultiPoint(mapControl1.Map.GetDisplayCoordSys());
                    mPoint = cvThuaChon.IntersectNodes(cvThua, IntersectTypes.InclAll);
                    if (mPoint.PointCount > 1)
                    {

                        //tinh khoang cach tu 2 diem cuoi cua mang thua den 2 diem giao
                        double d1 = 0;
                        double d2 = 0;

                        double d3 = 0;
                        double d4 = 0;


                        d1 = cls.TinhKhoangCach2Diem(dmang[dmang.Length - 2], mPoint[0]);
                        d2 = cls.TinhKhoangCach2Diem(dmang[dmang.Length - 2], mPoint[1]);
                        //(1)
                        if (d1 < d2)
                        {
                            //diem giao thu nhat cua thua duoc chon voi thua tim duoc
                            dmang[dmang.Length - 1] = mPoint[0];
                            dmang = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)dmang, new DPoint[dmang.Length + 1]);

                        }
                        else
                        {
                            //diem giao thu hai cua thua duoc chon voi thua tim duoc
                            dmang[dmang.Length - 1] = mPoint[1];
                            dmang = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)dmang, new DPoint[dmang.Length + 1]);
                        }


                        //================Tim mang diem=====================================
                        DPoint[] DTrongTHua = new DPoint[1];

                        for (int i = 0; i < dThua.Length - 1; i++)
                        {
                            if (f.Geometry.ContainsPoint(dThua[i]))
                            {
                                DTrongTHua[DTrongTHua.Length - 1] = dThua[i];
                                DTrongTHua = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)DTrongTHua, new DPoint[DTrongTHua.Length + 1]);

                            }
                        }

                        DTrongTHua[DTrongTHua.Length - 1] = DTrongTHua[0];


                        if (DTrongTHua.Length > 1)
                        {

                            if (d1 < d2)
                            {
                                d3 = cls.TinhKhoangCach2Diem(DTrongTHua[0], mPoint[0]);
                                d4 = cls.TinhKhoangCach2Diem(DTrongTHua[DTrongTHua.Length - 2], mPoint[0]);
                            }
                            else
                            {
                                d3 = cls.TinhKhoangCach2Diem(DTrongTHua[0], mPoint[1]);
                                d4 = cls.TinhKhoangCach2Diem(DTrongTHua[DTrongTHua.Length - 2], mPoint[1]);
                            }



                            if (d3 < d4)
                            {
                                for (int i = 0; i < DTrongTHua.Length - 1; i++)
                                {
                                    dmang[dmang.Length - 1] = DTrongTHua[i];
                                    dmang = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)dmang, new DPoint[dmang.Length + 1]);
                                }
                            }
                            else
                            {
                                for (int i = DTrongTHua.Length - 2; i >= 0; i--)
                                {
                                    dmang[dmang.Length - 1] = DTrongTHua[i];
                                    dmang = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)dmang, new DPoint[dmang.Length + 1]);
                                }

                            }
                        }

                        //kiem tra lai truong hop (1)
                        if (d1 < d2)
                        {
                            //diem giao thu hai cua thua duoc chon voi thua tim duoc
                            dmang[dmang.Length - 1] = mPoint[1];
                            dmang = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)dmang, new DPoint[dmang.Length + 1]);
                        }
                        else
                        {
                            //diem giao thu nhat cua thua duoc chon voi thua tim duoc
                            dmang[dmang.Length - 1] = mPoint[0];
                            dmang = (DPoint[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array)dmang, new DPoint[dmang.Length + 1]);

                        }
                    }


                    dmang[dmang.Length - 1] = dmang[0];





                    /* Gán giá trị cho Feature cần tạo */
                    MultiPolygon poly = new MultiPolygon(mapControl1.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, dmang);

                    feature = new MapInfo.Data.Feature(poly, new CompositeStyle());
                    // feature.Geometry = feature.Geometry.ConvexHull();
                    feature.Style = new CompositeStyle();
                    MapInfo.Data.IResultSetFeatureCollection ir1 = Session.Current.Catalog.Search(tabTHua, MapInfo.Data.SearchInfoFactory.SearchAll());

                    foreach (Feature ffff in ir1)
                    {
                        tabTHua.DeleteFeature(ffff);
                    }
                    MapInfo.Data.Feature ftmp = new MapInfo.Data.Feature(tabTHua.TableInfo.Columns);
                    ftmp.Geometry = feature.Geometry;
                    ftmp.Style = new CompositeStyle();
                    tabTHua.InsertFeature(ftmp);
                    MapInfo.Data.IResultSetFeatureCollection ir2 = Session.Current.Catalog.Search(tabTHua, MapInfo.Data.SearchInfoFactory.SearchAll());
                    MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(ir2);
                    f = (Feature)ir2[0];
                }
            }
           //FeatureLayer fl = new FeatureLayer(dt);
           //mapControl1.Map.Layers.Add(fl);
        }

        private void grdDanhSachThuaTrungChiTiet_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                /* Không active chức năng khi click chuột phải */
                if (e.Button == MouseButtons.Right)
                    return;
                /* Chắc chắn rằng người dùng click chuột trên bản ghi có dữ liệu */
                if (e.RowIndex < 0)
                    return;
                string strMaThuaDat;
                strMaThuaDat = grdDanhSachThuaTrungChiTiet.Rows[e.RowIndex].Cells["SW_MEMBER"].Value.ToString().ToString().Split('.')[0];
                DMC.GIS.Common.SearchTools searchTools = new SearchTools();
                IResultSetFeatureCollection irfcSearched = null;
                irfcSearched = searchTools.SearchWithColumn(mapControl1.Map, "Đất", "SW_MEMBER", strMaThuaDat, strMaDonViHanhChinh);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi hiển thị thửa đất được chọn trên bản đồ: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdDanhSachThuaTrung_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 ){
            DMC.Land.TachThua.clsHoSoCapGCN clshs = new DMC.Land.TachThua.clsHoSoCapGCN();
            clshs.Connection = strConnection;

            string strToBanDo = "";
                string strSoThua="";
                strToBanDo = grdDanhSachThuaTrung.Rows[e.RowIndex].Cells["tobando"].Value.ToString().Trim();
                strSoThua = grdDanhSachThuaTrung.Rows[e.RowIndex].Cells["sothua"].Value.ToString().ToString().Trim();
                clshs.ToBanDo = strToBanDo;
                clshs.SoThua = strSoThua;
                clshs.MaDonViHanhChinh = strMaDonViHanhChinh ;
            DataTable dt = new DataTable();
            dt = clshs.SelDanhSachThuaTrungChiTiet();
            grdDanhSachThuaTrungChiTiet.DataSource = dt;
            FormatGridDanhSachTrungMaChiTiet();
        }
        }

        /* Thiết đặt hiển thị DataGridView */
        private void FormatGridDanhSachTrungMaChiTiet()
        {
            string strError = "";
            try
            {
                /* Ẩn tất cả các cột trên Grid */
                this.HideAllColumns(ref  grdDanhSachThuaTrungChiTiet);

                /* Chỉ hiển thị những cột cần thiết */
                this.grdDanhSachThuaTrungChiTiet.Columns["SW_MEMBER"].Width = 50;
                this.grdDanhSachThuaTrungChiTiet.Columns["SW_MEMBER"].HeaderText = "Mã";
                this.grdDanhSachThuaTrungChiTiet.Columns["SW_MEMBER"].ReadOnly = true;
                this.grdDanhSachThuaTrungChiTiet.Columns["SW_MEMBER"].Visible = true;
                this.grdDanhSachThuaTrungChiTiet.Columns["SW_MEMBER"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdDanhSachThuaTrungChiTiet.Columns["ToBanDo"].Width = 80;
                this.grdDanhSachThuaTrungChiTiet.Columns["ToBanDo"].HeaderText = "Số tờ";
                this.grdDanhSachThuaTrungChiTiet.Columns["ToBanDo"].ReadOnly = true;
                this.grdDanhSachThuaTrungChiTiet.Columns["ToBanDo"].Visible = true;
                this.grdDanhSachThuaTrungChiTiet.Columns["ToBanDo"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdDanhSachThuaTrungChiTiet.Columns["SoThua"].Width = 80;
                this.grdDanhSachThuaTrungChiTiet.Columns["SoThua"].HeaderText = "Số thửa";
                this.grdDanhSachThuaTrungChiTiet.Columns["SoThua"].ReadOnly = true;
                this.grdDanhSachThuaTrungChiTiet.Columns["SoThua"].Visible = true;
                this.grdDanhSachThuaTrungChiTiet.Columns["SoThua"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdDanhSachThuaTrungChiTiet.Columns["DienTichTuNhien"].Width = 80;
                this.grdDanhSachThuaTrungChiTiet.Columns["DienTichTuNhien"].HeaderText = "Diện tích";
                this.grdDanhSachThuaTrungChiTiet.Columns["DienTichTuNhien"].ReadOnly = true;
                this.grdDanhSachThuaTrungChiTiet.Columns["DienTichTuNhien"].Visible = true;
                this.grdDanhSachThuaTrungChiTiet.Columns["DienTichTuNhien"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdDanhSachThuaTrungChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.grdDanhSachThuaTrungChiTiet.RowHeadersVisible = false;
                this.grdDanhSachThuaTrungChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.grdDanhSachThuaTrungChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                /* Khong cho phep them */
                this.grdDanhSachThuaTrungChiTiet.AllowUserToAddRows = false;
                /* Khong cho phep xoa */
                this.grdDanhSachThuaTrungChiTiet.AllowUserToDeleteRows = false;
                /* Khong lua chon bat ky dong nao luc ban dau */
                this.grdDanhSachThuaTrungChiTiet.ClearSelection();

            }
            catch (Exception ex)
            {
                strError = "";
                strError = ex.ToString();
                MessageBox.Show(" Thiết đặt hiển thị Thửa đất tìm được " + System.Environment.NewLine +
                    "Lỗi: " + System.Environment.NewLine + ex.ToString(), "DMCLand");
            }

        }

        private void toolTachThuaConnection_Click(object sender, EventArgs e)
        {
            DMC.Land.TachThua.frmUploadBanDo frm = new DMC.Land.TachThua.frmUploadBanDo();
            frm.Connection = strConnection;
            frm.MaDonViHanChinh = strMaDonViHanhChinh;
            frm.ShowDialog();
        }

       


    }
}
 class Class1
    {
        List<DPoint> tapdiem;
        bool[] tapdiemdadi;
        List<DPoint> tapketqua;
        private Map pMap;
        int count;
        public Map map {
            set { pMap = value; }
            get { return pMap; }
        }
        public List<DPoint> arrtapDiem
        {
            set { tapdiem = value; }
            get { return tapdiem; }
        }
        public List < DPoint>  arrKetQua
        {
            set { tapketqua = value; }
            get { return tapketqua; }
        }
        public int CountPoint
        {
            set { count = value; }
            get { return count; }
        }
        
        public Class1 (IEnumerable<DPoint> tapdiemxet)
        {
            tapdiem = new List<DPoint>(tapdiemxet);
            tapketqua = new List<DPoint>();

            tapdiemdadi = new bool[tapdiem.Count];
            for (int i = 0; i < tapdiem.Count; i++)
                tapdiemdadi[i] = false;            
        }
        /// <summary>
        /// i la diem dang xet
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public void TryOthers(List<DPoint> ls, int i)
        {
            if (i < tapdiem.Count)
            {
                //for (int j = 0; j < tapdiem.Count-1 ; j++)
                    for (int j = 0; j < tapdiem.Count; j++)
                {
                    //if (tapdiemdadi[j] == false && (ls.Count > 1 ? !XetGiao(ls, tapdiem[j], ls[ls.Count - 1]) : true))
                        if ( (ls.Count > 1 ? !XetGiao(ls, tapdiem[j], ls[ls.Count -1]) : true  ) && tapdiemdadi[j] == false )
                    {

                        // Danh dau diem dang xet da duoc di
                        tapdiemdadi[j] = true;
                        // Thu cau hinh tiep theo

                        ls.Add(tapdiem[j]);

                        TryOthers(ls, i + 1);

                        tapdiemdadi[j] = true;
                    }
                 }
            }
            
        }

        private bool XetGiao(List<DPoint> DiemDaDiQua, DPoint x1, DPoint x2)
        {
            // tao mot tap hop cac diem qua 2 diem x1, x2
            DPoint [] DLine = new DPoint[2];
            DLine[0]=x1;
            DLine[1]=x2 ;
            //tao tap hop diem da qua
            DPoint[] TapDiemDaQua = new DPoint[DiemDaDiQua.Count];
            for (int i = 0; i < DiemDaDiQua.Count; i++) {
                TapDiemDaQua[i] = DiemDaDiQua[i];
            }
            //tao multilPolyLine qua tap hop diem x1,x2
            MultiCurve poDLine = new MultiCurve(pMap.GetDisplayCoordSys(), CurveSegmentType.Linear, DLine);
            //tao multilPolyLine qua tap hop diem da di qua
            MultiCurve poDiemDaQua = new MultiCurve(pMap.GetDisplayCoordSys(), CurveSegmentType.Linear, TapDiemDaQua);
            MultiPoint  point = new MultiPoint(pMap.GetDisplayCoordSys());
            //lay giao diem cua 2 polyline tim dc
            point = poDLine.IntersectNodes(poDiemDaQua, IntersectTypes.InclAll);
          
                if (point.PointCount > 0)
                {
                    foreach (DPoint dp in point) {
                        double dx1, dx2, dy1, dy2, dx, dy;
                        dx=Convert.ToDouble(string.Format("{0:0.0}", dp.x));
                        dy = Convert.ToDouble(string.Format("{0:0.0}", dp.y));
                        dx1 = Convert.ToDouble(string.Format("{0:0.0}", DLine[0].x));
                        dy1 = Convert.ToDouble(string.Format("{0:0.0}", DLine[0].y));
                        dx2 = Convert.ToDouble(string.Format("{0:0.0}", DLine[1].x));
                        dy2 = Convert.ToDouble(string.Format("{0:0.0}", DLine[1].y));
                        if (((dx==dx1)&&(dy==dy1 ))||((dx==dx2)&&(dy==dy2)))
                        {
                            return false;
                        }
                        else {
                            return true;
                        }
                    }
                    //neu co giao diem
                    return true   ;
                }
                else
                {
                    //neu ko co giao diem
                    return false  ;
                }
           
         }

    }

public class MyPolygonTool : CustomArcMapTool, IAddMapToolProperties
{
    #region Private Properties

    //Internal coordinates to help create the arc with.
    private DPoint _startPoint;
    private DPoint _endPoint;
    private DPoint[] d = null;
    //Internal reference to check if the user cancelled the action.
    private bool isCancelled;

    //Internal object for accessing the AddMapToolProperties.
    private AddMapToolProperties _addMapToolProperties;

    #endregion

    #region Constructor(s)

    public MyPolygonTool(bool alterObject, bool callComplete, bool drawRubberObject, MapInfo.Mapping.FeatureViewer featureViewer, int hWnd, MapInfo.Tools.MapTools mapTools, MapInfo.Tools.IMouseToolProperties mouseToolProperties, MapInfo.Tools.IMapToolProperties mapToolProperties)
        : base(alterObject, callComplete, drawRubberObject, featureViewer, hWnd, mapTools, mouseToolProperties, mapToolProperties)
    {
        //initialize private properties.
        isCancelled = true;
        _addMapToolProperties = new AddMapToolProperties(MapInfo.Tools.MapTools.GetAddMapToolProperties(((MapInfo.Mapping.Map)featureViewer)));
    }

    #endregion

    #region Override Methods

    public override void OnMouseDown(object sender, MouseEventArgs mea)
    {
        isCancelled = false;
        //d[mea.Clicks] = GetDPointFromMouseCoords(mea.X, mea.Y);
        _startPoint = GetDPointFromMouseCoords(mea.X, mea.Y);
        base.OnMouseDown(sender, mea);
    }

    public override void OnMouseUp(object sender, MouseEventArgs mea)
    {
        if (!isCancelled)
        {
            //call the private method to set the endpoint
            _endPoint = GetDPointFromMouseCoords(mea.X, mea.Y);
            try
            {
                insertArc();
            }
            catch (Exception ex) { }
            isCancelled = true;
        }
        base.OnMouseUp(sender, mea);
    }

    public override void OnKeyDown(object sender, KeyEventArgs kea)
    {
        //check to see if the user has cancelled the drawing of the featuregeometry
        switch (kea.KeyCode)
        {
            case Keys.Escape:
                isCancelled = true;
                d = null;
                break;
            default:
                break;
        }
        base.OnKeyDown(sender, kea);
    }

    #endregion

    #region Private Methods

    private DPoint GetDPointFromMouseCoords(int mouseX, int mouseY)
    {
        MapInfo.Geometry.DPoint newPoint = new DPoint(0, 0);
        //use the feature viewer to translate the mouse coordinates into real earth coordinates.
        this.FeatureViewer.DisplayTransform.FromDisplay(new PointF(mouseX, mouseY), out newPoint);
        return newPoint;
    }

    private void insertArc()
    {
        //this example does not check for null InsertionLayer or where the start and end points are the same
        //both of which may cause errors

        //call private method to determine the start angle used for drawing the legacyarc.
        int startAngle = getStartAngle();

        //call private method to determine the minimum bounding rectangle for the ellipse that defines the elliptical arc.
        DRect d = getLargerDRectFromQuad(startAngle);

        //create the legacyarc object and insert.
        MapInfo.Geometry.LegacyArc lArc = new MapInfo.Geometry.LegacyArc(((MapInfo.Mapping.Map)this.FeatureViewer).GetDisplayCoordSys(), d, startAngle, startAngle + 90);

        //get a reference to the layer defined in the AddMapToolProperties object.
        MapInfo.Mapping.MapLayerEnumerator mle = ((MapInfo.Mapping.Map)this.FeatureViewer).Layers.GetMapLayerEnumerator(this.InsertionLayerFilter);

        //move the cursor into the first position and get the table associated with that featurelayer.
        mle.MoveNext();
        MapInfo.Data.Table table = ((MapInfo.Mapping.FeatureLayer)mle.Current).Table;

        //insert the legacyarc into the table.
        table.InsertFeature(new MapInfo.Data.Feature(lArc, this.CompositeStyle));
    }

    private DRect getLargerDRectFromQuad(int startAngle)
    {
        int corner;
        int center;

        MapInfo.Geometry.DRect quadRect = new MapInfo.Geometry.DRect(_startPoint, _endPoint);

        //the startcorner out of a drect is always the lowerleft.
        //
        // B*******C|B*******C
        // * *|* *
        // * 1 *|* 2 *
        // * *|* *
        // A*******D|A*******D
        // ---------+---------
        // B*******C|B*******C
        // * *|* *
        // * 3 *|* 4 *
        // * *|* *
        // A*******D|A*******D
        //
        //using the diagram above as a reference, if you think of the
        //quadrect as one of the four quadrants shown. It is 1/4 of the
        //larger rectangle which is the mbr of the ellipse defining the arc.
        //If the quadrect is represented by quad 3, then we need to determine
        //the point located at 2C so that we can create the arc.
        //
        switch (startAngle)
        {
            case 0:
                corner = 2;
                center = 0;
                break;
            case 90:
                corner = 1;
                center = 3;
                break;
            case 180:
                corner = 0;
                center = 2;
                break;
            case 270:
                corner = 3;
                center = 1;
                break;
            default:
                corner = 2;
                center = 0;
                break;
        }

        //get the new corner to create the larger rectangle by
        //rotating the outermost corner (3A) around the center (3C) 180 degrees
        //you could also use math to determine the new corner by
        //figuring out the number of degrees in the x and y directions
        //and adding or subtracting those values with the center values
        MapInfo.Geometry.Point newCorner = new MapInfo.Geometry.Point(((Map)FeatureViewer).GetDisplayCoordSys(), quadRect.Corners()[corner]);
        newCorner.GetGeometryEditor().Rotate(quadRect.Corners()[center], 180);
        newCorner.EditingComplete();

        return new DRect(quadRect.Corners()[corner], newCorner.Data);
    }

    private int getStartAngle()
    {
        if (_startPoint.x > _endPoint.x)
        {
            if (_startPoint.y > _endPoint.y)
            {
                return 270;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            if (_startPoint.y > _endPoint.y)
            {
                return 180;
            }
            else
            {
                return 90;
            }
        }
    }

    #endregion

    #region IAddMapToolProperties Members

    public IMapLayerFilter InsertionLayerFilter
    {
        get
        {
            return _addMapToolProperties.InsertionLayerFilter;
        }
        set
        {
            _addMapToolProperties.InsertionLayerFilter = value;
        }
    }

    public bool UseDefaultCompositeStyle
    {
        get
        {
            return _addMapToolProperties.UseDefaultCompositeStyle;
        }
        set
        {
            _addMapToolProperties.UseDefaultCompositeStyle = value;
        }
    }

    public bool UseDefaultInsertionLayerFilter
    {
        get
        {
            return _addMapToolProperties.UseDefaultInsertionLayerFilter;
        }
        set
        {
            _addMapToolProperties.UseDefaultInsertionLayerFilter = value;
        }
    }

    public event MapLayerFilterChangedEventHandler InsertionLayerFilterChanged
    {
        add
        {
            _addMapToolProperties.InsertionLayerFilterChanged += value;
        }
        remove
        {
            _addMapToolProperties.InsertionLayerFilterChanged -= value;
        }
    }

    public bool HasDefaultAddMapToolProperties
    {
        get
        {
            return _addMapToolProperties.HasDefaultAddMapToolProperties;
        }
    }

    public MapInfo.Styles.CompositeStyle CompositeStyle
    {
        get
        {
            return _addMapToolProperties.CompositeStyle;
        }
        set
        {
            _addMapToolProperties.CompositeStyle = value;
        }
    }

    public event EventHandler CompositeStyleChanged
    {
        add
        {
            _addMapToolProperties.CompositeStyleChanged += value;
        }
        remove
        {
            _addMapToolProperties.CompositeStyleChanged -= value;
        }
    }

    #endregion

    #region ISerializable Members

    public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
    {
        base.GetObjectData(info, context);
    }

    #endregion
}


public class MyPolygon : CustomPolygonMapTool, IAddMapToolProperties
{
    #region Private Properties
    private DPoint[] d = null ; 
   
    //Internal reference to check if the user cancelled the action.
    private bool isCancelled;

    //Internal object for accessing the AddMapToolProperties.
    private AddMapToolProperties _addMapToolProperties;

    #endregion

    #region Constructor(s)

    public MyPolygon(bool alterObject, bool callComplete, bool drawRubberObject, MapInfo.Mapping.FeatureViewer featureViewer, int hWnd, MapInfo.Tools.MapTools mapTools, MapInfo.Tools.IMouseToolProperties mouseToolProperties, MapInfo.Tools.IMapToolProperties mapToolProperties)
        : base(alterObject, callComplete, drawRubberObject, featureViewer, hWnd, mapTools, mouseToolProperties, mapToolProperties)
    {
        //initialize private properties.
        _addMapToolProperties = new AddMapToolProperties(MapInfo.Tools.MapTools.GetAddMapToolProperties(((MapInfo.Mapping.Map)featureViewer)));
    }

    #endregion

    #region Override Methods
    
    public override void OnMouseDown(object sender, MouseEventArgs mea)
    {
        //call the private method to set the startpoint
        if (d == null)
        {
            d = new DPoint[1];
        }
        d[d.Length-1] = GetDPointFromMouseCoords(mea.X, mea.Y);
        DPoint[] tempReDim = new DPoint[d.Length + 1];
        if (d != null)
            System.Array.Copy(d, tempReDim,
            System.Math.Min(d.Length, tempReDim.Length));
        d = tempReDim;
        base.OnMouseDown(sender, mea);
    }

    //public override void OnMouseUp(object sender, MouseEventArgs mea)
    //{
        
    //        d[d.Length - 1] = GetDPointFromMouseCoords(mea.X, mea.Y);
    //        DPoint[] tempReDim = new DPoint[d.Length + 1];
    //        if (d != null)
    //            System.Array.Copy(d, tempReDim,
    //            System.Math.Min(d.Length, tempReDim.Length));
    //        d = tempReDim;
       
    //    base.OnMouseUp(sender, mea);
    //}

    public override void OnKeyDown(object sender, KeyEventArgs kea)
    {
        //check to see if the user has cancelled the drawing of the featuregeometry
        switch (kea.KeyValue)
        {
              
            case 27:
                if ((d != null) && (d.Length > 2))
                {
                    d[d.Length - 1] = d[0];
                    insertArc();
                    d = null;
                    break;
                }
                d = null;
                break;
           
            default:
                break;
               
        }
        base.OnKeyDown(sender, kea);
    }

    #endregion

    #region Private Methods

    private DPoint GetDPointFromMouseCoords(int mouseX, int mouseY)
    {
        MapInfo.Geometry.DPoint newPoint = new DPoint(0, 0);
        //use the feature viewer to translate the mouse coordinates into real earth coordinates.
        this.FeatureViewer.DisplayTransform.FromDisplay(new PointF(mouseX, mouseY), out newPoint);
        return newPoint;
    }

    private void insertArc()
    {
        //this example does not check for null InsertionLayer or where the start and end points are the same
        //create the legacyarc object and insert.
        MapInfo.Geometry.MultiPolygon lArc = new MapInfo.Geometry.MultiPolygon(((MapInfo.Mapping.Map)this.FeatureViewer).GetDisplayCoordSys(), CurveSegmentType.Linear, d);

        //get a reference to the layer defined in the AddMapToolProperties object.
        MapInfo.Mapping.MapLayerEnumerator mle = ((MapInfo.Mapping.Map)this.FeatureViewer).Layers.GetMapLayerEnumerator(this.InsertionLayerFilter);

        //move the cursor into the first position and get the table associated with that featurelayer.
        mle.MoveNext();
        MapInfo.Data.Table table = ((MapInfo.Mapping.FeatureLayer)mle.Current).Table;
        //insert the legacyarc into the table.
        table.InsertFeature(new MapInfo.Data.Feature(lArc, this.CompositeStyle));
    }

   

    #endregion

    #region IAddMapToolProperties Members

    public IMapLayerFilter InsertionLayerFilter
    {
        get
        {
            return _addMapToolProperties.InsertionLayerFilter;
        }
        set
        {
            _addMapToolProperties.InsertionLayerFilter = value;
        }
    }

    public bool UseDefaultCompositeStyle
    {
        get
        {
            return _addMapToolProperties.UseDefaultCompositeStyle;
        }
        set
        {
            _addMapToolProperties.UseDefaultCompositeStyle = value;
        }
    }

    public bool UseDefaultInsertionLayerFilter
    {
        get
        {
            return _addMapToolProperties.UseDefaultInsertionLayerFilter;
        }
        set
        {
            _addMapToolProperties.UseDefaultInsertionLayerFilter = value;
        }
    }

    public event MapLayerFilterChangedEventHandler InsertionLayerFilterChanged
    {
        add
        {
            _addMapToolProperties.InsertionLayerFilterChanged += value;
        }
        remove
        {
            _addMapToolProperties.InsertionLayerFilterChanged -= value;
        }
    }

    public bool HasDefaultAddMapToolProperties
    {
        get
        {
            return _addMapToolProperties.HasDefaultAddMapToolProperties;
        }
    }

    public MapInfo.Styles.CompositeStyle CompositeStyle
    {
        get
        {
            return _addMapToolProperties.CompositeStyle;
        }
        set
        {
            _addMapToolProperties.CompositeStyle = value;
        }
    }

    public event EventHandler CompositeStyleChanged
    {
        add
        {
            _addMapToolProperties.CompositeStyleChanged += value;
        }
        remove
        {
            _addMapToolProperties.CompositeStyleChanged -= value;
        }
    }

    #endregion

    #region ISerializable Members

    public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
    {
        base.GetObjectData(info, context);
    }

    #endregion
}


//public class DoVeChieuDai : CustomPolylineMapTool, IAddMapToolProperties
//{
//    #region Private Properties
//    private DPoint[] d = null;
//    public double ChieuDai = 0;
//    //Internal reference to check if the user cancelled the action.
//    private bool isCancelled;

//    //Internal object for accessing the AddMapToolProperties.
//    private AddMapToolProperties _addMapToolProperties;

//    #endregion

//    #region Constructor(s)

//    public DoVeChieuDai(bool alterObject, bool callComplete, bool drawRubberObject, MapInfo.Mapping.FeatureViewer featureViewer, int hWnd, MapInfo.Tools.MapTools mapTools, MapInfo.Tools.IMouseToolProperties mouseToolProperties, MapInfo.Tools.IMapToolProperties mapToolProperties)
//        : base(alterObject, callComplete, drawRubberObject, featureViewer, hWnd, mapTools, mouseToolProperties, mapToolProperties)
//    {
//        //initialize private properties.
//        _addMapToolProperties = new AddMapToolProperties(MapInfo.Tools.MapTools.GetAddMapToolProperties(((MapInfo.Mapping.Map)featureViewer)));
//    }
//    #endregion

//    #region Override Methods

//    public override void OnMouseDown(object sender, MouseEventArgs mea)
//    {

//        base.OnMouseDown(sender, mea);
//    }

//    public override void OnMouseMove(object sender, MouseEventArgs mea)
//    {

//        base.OnMouseMove(sender, mea);
//    }
//    public override void OnMouseUp(object sender, MouseEventArgs mea)
//    {
//        //call the private method to set the startpoint
//        if (d == null)
//        {
//            d = new DPoint[1];
//            d[d.Length - 1] = GetDPointFromMouseCoords(mea.X, mea.Y);
//        }
//        else
//        {
//            DPoint[] tempReDim = new DPoint[d.Length + 1];
//            if (d != null)
//                System.Array.Copy(d, tempReDim,
//                System.Math.Min(d.Length, tempReDim.Length));
//            d = tempReDim;
//            d[d.Length - 1] = GetDPointFromMouseCoords(mea.X, mea.Y);
//            TachThua.ctrlTachThua.ChieuDaiCanh = ViewChieuDai();
//        }

//        base.OnMouseUp(sender, mea);
//    }

//    public override void OnKeyDown(object sender, KeyEventArgs kea)
//    {
//        //check to see if the user has cancelled the drawing of the featuregeometry
//        switch (kea.KeyCode)
//        {
//            case Keys.Escape:
//                d = null;
//                break;
//            default:
//                break;
//            //d = null;
//            //ChieuDai = 0;


//        }
//        base.OnKeyDown(sender, kea);
//    }

//    #endregion

//    #region Private Methods

//    private DPoint GetDPointFromMouseCoords(int mouseX, int mouseY)
//    {
//        MapInfo.Geometry.DPoint newPoint = new DPoint(0, 0);
//        //use the feature viewer to translate the mouse coordinates into real earth coordinates.
//        this.FeatureViewer.DisplayTransform.FromDisplay(new PointF(mouseX, mouseY), out newPoint);
//        return newPoint;
//    }

//    public double ViewChieuDai()
//    {

//        double ChieuDaiCanh = 0;
//        for (int i = 0; i < d.Length - 1; i++)
//        {
//            if ((d[i].x != 0) && (d[i].y != 0))
//            {
//                if ((d[i + 1].x != 0) && (d[i + 1].y != 0))
//                {
//                    ChieuDaiCanh = ChieuDaiCanh + System.Math.Sqrt(Math.Abs((d[i].x - d[i + 1].x) * (d[i].x - d[i + 1].x) + (d[i].y - d[i + 1].y) * (d[i].y - d[i + 1].y)));
//                    ChieuDaiCanh = System.Math.Round(ChieuDaiCanh, 2);
//                }
//            }
//        }
//        return ChieuDaiCanh;
//    }



//    #endregion

//    #region IAddMapToolProperties Members

//    public IMapLayerFilter InsertionLayerFilter
//    {
//        get
//        {
//            return _addMapToolProperties.InsertionLayerFilter;
//        }
//        set
//        {
//            _addMapToolProperties.InsertionLayerFilter = value;
//        }
//    }

//    public bool UseDefaultCompositeStyle
//    {
//        get
//        {
//            return _addMapToolProperties.UseDefaultCompositeStyle;
//        }
//        set
//        {
//            _addMapToolProperties.UseDefaultCompositeStyle = value;
//        }
//    }

//    public bool UseDefaultInsertionLayerFilter
//    {
//        get
//        {
//            return _addMapToolProperties.UseDefaultInsertionLayerFilter;
//        }
//        set
//        {
//            _addMapToolProperties.UseDefaultInsertionLayerFilter = value;
//        }
//    }

//    public event MapLayerFilterChangedEventHandler InsertionLayerFilterChanged
//    {
//        add
//        {
//            _addMapToolProperties.InsertionLayerFilterChanged += value;
//        }
//        remove
//        {
//            _addMapToolProperties.InsertionLayerFilterChanged -= value;
//        }
//    }

//    public bool HasDefaultAddMapToolProperties
//    {
//        get
//        {
//            return _addMapToolProperties.HasDefaultAddMapToolProperties;
//        }
//    }

//    public MapInfo.Styles.CompositeStyle CompositeStyle
//    {
//        get
//        {
//            return _addMapToolProperties.CompositeStyle;
//        }
//        set
//        {
//            _addMapToolProperties.CompositeStyle = value;
//        }
//    }

//    public event EventHandler CompositeStyleChanged
//    {
//        add
//        {
//            _addMapToolProperties.CompositeStyleChanged += value;
//        }
//        remove
//        {
//            _addMapToolProperties.CompositeStyleChanged -= value;
//        }
//    }

//    #endregion

//    #region ISerializable Members

//    public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
//    {
//        base.GetObjectData(info, context);
//    }

//    #endregion
//}

public class DoVeChuViDienTich : CustomPolylineMapTool, IAddMapToolProperties
{
    #region Private Properties
    private DPoint[] d = null;
    public double ChieuDai = 0;
    //Internal reference to check if the user cancelled the action.
    private bool isCancelled;

    //Internal object for accessing the AddMapToolProperties.
    private AddMapToolProperties _addMapToolProperties;

    #endregion

    #region Constructor(s)

    public DoVeChuViDienTich(bool alterObject, bool callComplete, bool drawRubberObject, MapInfo.Mapping.FeatureViewer featureViewer, int hWnd, MapInfo.Tools.MapTools mapTools, MapInfo.Tools.IMouseToolProperties mouseToolProperties, MapInfo.Tools.IMapToolProperties mapToolProperties)
        : base(alterObject, callComplete, drawRubberObject, featureViewer, hWnd, mapTools, mouseToolProperties, mapToolProperties)
    {
        //initialize private properties.
        _addMapToolProperties = new AddMapToolProperties(MapInfo.Tools.MapTools.GetAddMapToolProperties(((MapInfo.Mapping.Map)featureViewer)));
    }
    #endregion

    #region Override Methods

    public override void OnMouseDown(object sender, MouseEventArgs mea)
    {

        base.OnMouseDown(sender, mea);
    }

    public override void OnMouseMove(object sender, MouseEventArgs mea)
    {

        base.OnMouseMove(sender, mea);
    }
    public override void OnMouseUp(object sender, MouseEventArgs mea)
    {
        //call the private method to set the startpoint
        if (d == null)
        {
            d = new DPoint[1];
            d[d.Length - 1] = GetDPointFromMouseCoords(mea.X, mea.Y);
        }
        else
        {
            DPoint[] tempReDim = new DPoint[d.Length + 1];
            if (d != null)
                System.Array.Copy(d, tempReDim,
                System.Math.Min(d.Length, tempReDim.Length));
            d = tempReDim;
            d[d.Length - 1] = GetDPointFromMouseCoords(mea.X, mea.Y);
            TachThua.ctrlTachThua.DienTichDo = ViewDienTich();
            TachThua.ctrlTachThua.ChuViDo = ViewChuVi();
            TachThua.ctrlTachThua.ChieuDaiCanh = ViewChieuDai();
        }

        base.OnMouseUp(sender, mea);
    }

    public override void OnKeyDown(object sender, KeyEventArgs kea)
    {
        //check to see if the user has cancelled the drawing of the featuregeometry
        switch (kea.KeyCode)
        {
            case Keys.Escape:
                d = null;
                break;
            default:
                break;
            //d = null;
            //ChieuDai = 0;


        }
        base.OnKeyDown(sender, kea);
    }

    #endregion

    #region Private Methods

    private DPoint GetDPointFromMouseCoords(int mouseX, int mouseY)
    {
        MapInfo.Geometry.DPoint newPoint = new DPoint(0, 0);
        //use the feature viewer to translate the mouse coordinates into real earth coordinates.
        this.FeatureViewer.DisplayTransform.FromDisplay(new PointF(mouseX, mouseY), out newPoint);
        return newPoint;
    }
    public double ViewChieuDai()
    {

        double ChieuDaiCanh = 0;
        for (int i = 0; i < d.Length - 1; i++)
        {
            if ((d[i].x != 0) && (d[i].y != 0))
            {
                if ((d[i + 1].x != 0) && (d[i + 1].y != 0))
                {
                    ChieuDaiCanh = ChieuDaiCanh + System.Math.Sqrt(Math.Abs((d[i].x - d[i + 1].x) * (d[i].x - d[i + 1].x) + (d[i].y - d[i + 1].y) * (d[i].y - d[i + 1].y)));
                    ChieuDaiCanh = System.Math.Round(ChieuDaiCanh, 2);
                }
            }
        }
        return ChieuDaiCanh;
    }
    public double ViewDienTich()
    {

        double DienTich = 0;
        if (d.Length>2)
        {
            DPoint[] dcv = new DPoint[d.Length + 1];
            System.Array.Copy(d, dcv,
                System.Math.Min(d.Length, dcv.Length));
            dcv[d.Length] = dcv[0];
            MultiPolygon pg = new MultiPolygon(TachThua.ctrlTachThua.coordsys, CurveSegmentType.Linear, dcv);
            DienTich = pg.Area(AreaUnit.SquareMeter, DistanceType.Spherical);
            DienTich = System.Math.Round(DienTich, 2);
        }
        return DienTich;
    }
    public double ViewChuVi()
    {

        double ChuVi = 0;
        if (d.Length > 2)
        {
            DPoint[] dcv = new DPoint[d.Length + 1];
            System.Array.Copy(d, dcv,
                System.Math.Min(d.Length, dcv.Length));
            dcv[d.Length] = dcv[0];
            MultiPolygon pg = new MultiPolygon(TachThua.ctrlTachThua.coordsys, CurveSegmentType.Linear, dcv);
            ChuVi = pg.Perimeter(DistanceUnit.Meter, DistanceType.Spherical);
            ChuVi = System.Math.Round(ChuVi, 2);
        }
        return ChuVi;
    }


    #endregion

    #region IAddMapToolProperties Members

    public IMapLayerFilter InsertionLayerFilter
    {
        get
        {
            return _addMapToolProperties.InsertionLayerFilter;
        }
        set
        {
            _addMapToolProperties.InsertionLayerFilter = value;
        }
    }

    public bool UseDefaultCompositeStyle
    {
        get
        {
            return _addMapToolProperties.UseDefaultCompositeStyle;
        }
        set
        {
            _addMapToolProperties.UseDefaultCompositeStyle = value;
        }
    }

    public bool UseDefaultInsertionLayerFilter
    {
        get
        {
            return _addMapToolProperties.UseDefaultInsertionLayerFilter;
        }
        set
        {
            _addMapToolProperties.UseDefaultInsertionLayerFilter = value;
        }
    }

    public event MapLayerFilterChangedEventHandler InsertionLayerFilterChanged
    {
        add
        {
            _addMapToolProperties.InsertionLayerFilterChanged += value;
        }
        remove
        {
            _addMapToolProperties.InsertionLayerFilterChanged -= value;
        }
    }

    public bool HasDefaultAddMapToolProperties
    {
        get
        {
            return _addMapToolProperties.HasDefaultAddMapToolProperties;
        }
    }

    public MapInfo.Styles.CompositeStyle CompositeStyle
    {
        get
        {
            return _addMapToolProperties.CompositeStyle;
        }
        set
        {
            _addMapToolProperties.CompositeStyle = value;
        }
    }

    public event EventHandler CompositeStyleChanged
    {
        add
        {
            _addMapToolProperties.CompositeStyleChanged += value;
        }
        remove
        {
            _addMapToolProperties.CompositeStyleChanged -= value;
        }
    }

    #endregion

    #region ISerializable Members

    public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
    {
        base.GetObjectData(info, context);
    }

    #endregion
}