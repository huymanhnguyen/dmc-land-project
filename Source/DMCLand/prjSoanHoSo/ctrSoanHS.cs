using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DMC.GIS.Common;
using MapInfo.Data;
using MapInfo.Engine;
using MapInfo.Geometry;
using MapInfo.Mapping;
using MapInfo.Styles;
using MapInfo.Text;
using MapInfo.Tools;
using MapInfo.Windows.Controls;
using MapInfo.Windows.Dialogs;
namespace DMC.Land.SoanHoSo
{
    public partial class ctrSoanHS : UserControl
    {
        //cho phep di chuyen chinh sua doi tuong cua thua
        int intUndo = 0;
        public System.Drawing.Point MousePositionBeforeMoved, LocationBeforeMoved;
        public bool ChangeFeature;
        private bool EditThuaDat;
        public  double dlTyLeZoomView = 0;
        public double dlDienTichThua = 0;
        public static MapInfo.Tools.EditMode EditMode = MapInfo.Tools.EditMode.None;
        #region Khai bao bien doi tuong windown
        //khai bao ket noi sql
        public SqlConnection conn;
        /* Khai báo biến nhận Tên máy chủ */
        private string strServerName = "";
        /* Khai báo thuộc tính nhận tên máy chủ */
        public string SererName
        {
            set { strServerName = value;}
        }
        /* Khai báo biến nhận Tên cơ sở dữ liệu */
        private string strDatabaseName = "";
        /* Khai báo thuộc tính nhận Tên Cơ sở dữ liệu */
        public string DatabaseName
        {
            set {strDatabaseName = value;}
        }

        private string strBangDVHC = "";

        public string TenBangDVHC
        {
            get { return strBangDVHC; }
            set { strBangDVHC = value; }
        }
        /* Khai báo biến nhận UserName */
        private string strUID = "";
        /* Khai báo thuộc tính nhận UserName */
        public string UID
        {
            set {strUID = value;} 
        }
        /* Khai báo biến nhận PassWord */
        private string strUpass = "";
        /* Khai báo thuộc tính nhận PassWord*/
        public string Upass
        {
            set { strUpass = value;}
        }
        public bool ChangeNewFeature {
            set {
                ChangeFeature = value;
            }
            get { return ChangeFeature; }
        }
        public bool TrangThaiPhucHoi = true;
        private string  strMaDonViHanhChinh ="";
        public string MaDonViHanhChinh{
            set { strMaDonViHanhChinh = value; }
            get { return strMaDonViHanhChinh; }
        }
        public double heightFont = 0;
        public double widthFont = 0;
        public string fontName = "Time New Roman";
        public int fontSize = 8;
        public string KeyGanThua="";
        private bool DiChuyenDinhThua=false ;
        private DPoint DiemCuoiChonThua;
        private DPoint GanDinhVaoVung;
        private string strConnectionstring;
        private string strConnectData;
        private string MyCurso;
        private long  FeatureID;
        private string LayerName;
        private string BanDo;
        private Boolean DuongChucNang= true ;
public string tabBanDo
{
  get { return BanDo; }
  set { BanDo = value; }
}
        private string ThuaDat;
        private string strBang;

public string tabSoanHoSo
{
  get { return strBang; }
  set { strBang = value; }
}
        private string strBangHoSo;
        private string LopNha;

public string tabNha
{
  get { return LopNha; }
  set { LopNha = value; }
}
        private string NhanDinh;
        private string NhanThua;
        private string NhanKichThuoc;
        private string NhanNode;
        private string DuongBao;
        private string [] DoiTuongCopy ;
        private string Nhan;//bien goi toi ten nhan duoc su dung
        private string DoiTuong;//chi ro lop doi tuong nao duoc thao tac
        private double TyleBanDo;
        private string CurentLayer="";
        private double FixZoom = 0; 
        private string TenLopDat;
        private string TenLopNha; 
        private int SizeMapWidth = 0;
        private int SizeMapHeigt = 0;
        /* Khai báo biến nhận Mã Hồ sơ cấp GCN */
        private long lgMaHoSoCapGCN = 0;
        /* Khai báo thuộc tính nhận Mã Hồ sơ cấp GCN */
        public long  HoSoCapGCN
        {
            set {lgMaHoSoCapGCN = value;}
        }
        private string OldKey;
        private byte[] byteLandImage;
        private double strZoom100 = 0;


        //-------------------
        #endregion
        #region Khai bao bien doi tuong Map
        //su ly cac bien toan cuc
        //Biến định dạng
        private SimpleLineStyle _lineStyle = null;
        private SimpleInterior _fillStyle = null;
        private AreaStyle _areaStyle = null;
        private SimpleVectorPointStyle _vectorSymbol = null;
        private BitmapPointStyle _bitmapSymbol = null;
        private FontPointStyle _fontSymbol = null;
        private TextStyle _textStyle = null;
        private LineStyleDlg _lineStyleDlg = null;
        private AreaStyleDlg _areaStyleDlg = null;
        private TextStyleDlg _textStyleDlg = null;
        private SymbolStyleDlg _symbolStyleDlg = null;
        private IFeatureCollection LuuBoDem = null;
        private MICommand _miCommand;
        private MIConnection _miConnection;
        private DPoint pointStart;
        private DPoint pointEnd;
        private Table TableThuaDat = null;
        private DPoint MousePointEnd;
        private DPoint DPointCenter;
        private DMC.GIS.Common.clsMainSoanHoSo cls;
        private clsDatabase clsData;
        //=============================
        private CompositeStyle CopyStyle = null;
        //----------------------------
        #endregion

        System.Windows.Forms.StatusBarPanel _selectPanel = new System.Windows.Forms.StatusBarPanel();
        System.Windows.Forms.StatusBarPanel _editPanel = new System.Windows.Forms.StatusBarPanel();
        System.Windows.Forms.StatusBarPanel _insertPanel = new System.Windows.Forms.StatusBarPanel();
        public ctrSoanHS()
        {
            InitializeComponent();
            #region Khai bao su kiem map
            // Listen to some map events
            
            mapControl1.Map.ViewChangedEvent += new ViewChangedEventHandler(Map_ViewChanged);

            // Listen to some tool events
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

            

            ToolBarSetup();
                    
            mapControl1.Map.ViewChangedEvent += new ViewChangedEventHandler(Map_ViewChanged);
            mapControlView.Map.ViewChangedEvent += new ViewChangedEventHandler(MapView_ViewChanged);
            #endregion
            #region Khoi tao cac doi tuong bien

            NhanDinh = "Nhãn đỉnh";
            NhanKichThuoc = "Nhãn cạnh";
            NhanNode = "Nhãn nút";
            NhanThua = "Nhãn thửa";
            DuongBao = "Đường bao";
            DoiTuong = "";
            ThuaDat = "Thửa_đất";
            TenLopDat = "Bản_đồ_đất";
            TenLopNha = "Bản_đồ_nhà";
            LayerName = ThuaDat;

           
            strBangHoSo = "tblHoSoCapGCN";
          
            this._miConnection = new MIConnection();
            _miConnection.Open();
            this._miCommand = _miConnection.CreateCommand();
            #endregion
        }
        public string GetConnection()
        {
            return strConnectData;
        }
        //hien thi thuoc tinh cua thua dat duoc chon 
        public void LoadDLThuocTinh() {
            try
            {
                txtToBanDo.Text = clsData.GetValueCol(BanDo, "ToBanDo", Convert.ToInt64(FeatureID.ToString().Split('.')[0])).ToString();
                txtSoThua.Text = clsData.GetValueCol(BanDo, "SoThua", Convert.ToInt64(FeatureID.ToString().Split('.')[0])).ToString();
                txtDienTich.Text = clsData.GetValueCol(BanDo, "DienTichTuNhien", Convert.ToInt64(FeatureID.ToString().Split('.')[0])).ToString();
                TrangThaiHoSoCapGCN();
                //TrangThaiCapGCN(clsData.GetValueCol(BanDo, "Status", FeatureID).ToString());
            }catch (Exception ex ) {}
        }
        public ToolStripProgressBar toolProcess()
        {
            return staProcess;
        }

        //ham ket noi co so du lieu
        public SqlConnection Connect()
        {
            try
            {
                string strConnec;
                strConnec = "";
                //cay lenh ket noi co so du lieu
                strConnec = "Data Source=" + strServerName  + ";Initial Catalog=" + strDatabaseName + " ;User ID=" + strUID + " ;PassWord=" + strUpass + "";
                conn = new SqlConnection();
                conn.ConnectionString = strConnec;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            return conn;
        }
        #region Khai bao cấu hình ban đầu cho Map
        //khai bao dieu khien tool xu ly ban do
        private void ToolBarSetup() {           
            mapToolBar1.MapControl = mapControl1;
            mapToolBar1.MapControl.Map = mapControl1.Map;
        }

        //thiet lap cau hinh ban dau cho map
        public void MapSet()
        {
         
            mapControl1.Map.Zoom = new MapInfo.Geometry.Distance(1000, DistanceUnit.Meter);
            layerControl1.Map = mapControl1.Map;
            layerControl1.Tools = mapControl1.Tools;
            layerControl1.ToolTip.Active = false;
            layerControl1.Map = mapControl1.Map;
            layerControl1.Tools = mapControl1.Tools;
            layerControl1.CheckBoxes = true;
            layerControl1.TabControl.Visible = false;
            layerControl1.ToolBar.Buttons[0].Visible = false;
            layerControl1.ToolBar.Buttons[1].Visible = false;
            layerControl1.ToolBar.Buttons[2].Visible = false;

            //MapInfo.Geometry.CoordSys coordSys = Session.Current.CoordSysFactory.CreateLongLat(DatumID.WGS84);
            //mapControl1.Map.SetDisplayCoordSys(coordSys);

            //CoordSys NonEarth Units "m" Bounds (511287.246773, 2324061.46) (512254.45, 2325230.952994)
           // mapControl1.Map.SetDisplayCoordSys(coordSysFactory.CreateCoordSys("mapinfo:coordsys 8,1001,7,117,0,1,20500000,0"));
        }
        #endregion
        //khai bao thuoc tinh tinh ty le ban do so voi mapcontrol
        public double TyLeBanDo()
        {
            TyleBanDo = 1;
            return TyleBanDo;
        }
        //Mo bang moi de dua vao Map
        public void OpenLayer(MapControl pMap)
        {
            try
            {
                string str;
                str = "";
                //neu ton tai thi update select, khong ton tai thi update vao
                clsData.KitraTonTai(strBang, BanDo, FeatureID, lgMaHoSoCapGCN);

                str = "Select * from " + strBang + " where  MaHoSoCapGCN=" + lgMaHoSoCapGCN + "";

                //tao layer tam
                if (MapInfo.Engine.Session.Current.Catalog.GetTable("tmp") != null)
                {
                    MapInfo.Engine.Session.Current.Catalog.CloseTable("tmp");
                }
                TableThuaDat = cls.GetNewLayer("tmp", strConnectionstring, str);


                MIConnection miConnection = new MIConnection();
                if (miConnection.State == ConnectionState.Closed)
                    miConnection.Open();
                // TableThuaDat.BeginAccess(TableAccessMode.Read);

                // tao layer tmp cho thua can soan
                Table dt = null;
                if (MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName) != null)
                {
                    MapInfo.Engine.Session.Current.Catalog.CloseTable(LayerName);
                }
                //tao doi tuong table co ten la tmp cho bang thua dat
                dt = cls.CreateDataTable(mapControl1.Map, "tmp", LayerName, TableThuaDat);

              

                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(TableThuaDat, MapInfo.Data.SearchInfoFactory.SearchAll());
                if (irfc == null)
                {
                    return;
                }
                if (irfc.Count == 0)
                {
                    return;
                }
                //lay tat ca cac doi tuong tim duoc dua len tren mot layer tmp cua ban do
                foreach (Feature f in irfc)
                {
                    if (f.Geometry != null)
                    {
                        CompositeStyle cs = new CompositeStyle();
                        //lay ma doi tuong
                        String doiTuong;
                        doiTuong = "";
                        doiTuong = clsData.getValue(strBang, "Madoituong", f.Key.Value);
                        
                        //Them doi tuong vao bang
                        if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                        { 
                            
                            LegacyText txt = (LegacyText)f.Geometry;
                            Int16 fontSize = cls.GetFontSize(txt, pMap); 
                            TextStyle ts = (TextStyle)f.Style;
                            ts.Font.Size = fontSize;
                            ts.Font.Name = ".VnArial";

                            DPoint dcent = new DPoint();
                            dcent = txt.Centroid;
                            pMap.Map.Center = dcent;
                            MapInfo.Geometry.LegacyText g = new MapInfo.Geometry.LegacyText(mapControl1.Map.GetDisplayCoordSys(), txt);
                            cs.ApplyStyle(ts);
                            cls.UpdateDoiTuong(dt, g, doiTuong, cs, "");                            
                        }
                        else {
                            cs.ApplyStyle(f.Style);
                            cls.UpdateDoiTuong(dt, f.Geometry, doiTuong, cs,"");
                        }
                        
                    }
                    // cls.UpdateDoiTuong(dt, f.Geometry, doiTuong, cs);
                }
                FeatureLayer fl = new FeatureLayer(dt);

                pMap.Map.Layers.Add(fl);
                pMap.Map.SetView(fl);
                dlTyLeZoomView = System.Convert.ToDouble(string.Format("{0:E2}", pMap.Map.Zoom.Value)); 
                cls.TyLeZoomView = dlTyLeZoomView ;
                EditableLayer(pMap, LayerName, true);
                int iLayerIndex = pMap.Map.Layers.IndexOf(pMap.Map.Layers[LayerName]);
                pMap.Map.Layers.Move(iLayerIndex, 0);
                pMap.Map.DrawingAttributes.EnableTranslucency = true;
                pMap.Map.DrawingAttributes.SmoothingMode = SmoothingMode.AntiAlias;

                string DienTichThuaKeKhai = "";

                DienTichThuaKeKhai = clsData.GetValueCol(BanDo, "DienTichTuNhien", FeatureID);
                if ((DienTichThuaKeKhai == "") || (DienTichThuaKeKhai == "0")|| (DienTichThuaKeKhai == null)  )
                {
                    DienTichThuaKeKhai = "100";
                }
                dlDienTichThua = Convert.ToDouble(DienTichThuaKeKhai);
 
                ExportsFileTab();
            }
            catch (Exception ex) { dlDienTichThua = 100; }
        }
        #region Các hàm xử lý bản đồ
        
        private void Map_MapDraw(object o, MapDrawEventHandler e)
        { 
            
        }
        //ghi thông số thay đổi thuộc tính zoom trên bản đồ vào thanh tabar
        private void Map_ViewChanged(object o, ViewChangedEventArgs e)
        {
            try
            {
                // Get the map
                MapInfo.Mapping.Map map = (MapInfo.Mapping.Map)o;
                // Display the zoom level
                //Table tab =  MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                // IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());
                // mapControl1.Map.SetView(irfc);
                if (( 0 < mapControl1.Map.Zoom.Value) && (mapControl1.Map.Zoom.Value < 10000))
                {
                    double dblZoom = System.Convert.ToDouble(string.Format("{0:E2}", mapControl1.Map.Zoom.Value));

                  //  mapControl1.Map.Zoom = new MapInfo.Geometry.Distance(dblZoom, DistanceUnit.Meter);
                    mapControl1.Map.Zoom = new MapInfo.Geometry.Distance(dblZoom, DistanceUnit.Meter);
                    toolBarZoom.Text = "Zoom: " + dblZoom.ToString() + " m      Scale: " + mapControl1.Map.Scale.ToString() ;
                    toolCboTyLe.Text = dblZoom.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MapView_ViewChanged(object o, ViewChangedEventArgs e)
        {
            try
            {
                //if (PMove != mapControlView.Map.Center)
                //{
                if ((0 < mapControlView.Map.Zoom.Value) && (mapControlView.Map.Zoom.Value < 10000))
                {
                double dblZoom = System.Convert.ToDouble(string.Format("{0:E2}", mapControlView.Map.Zoom.Value));
                mapControlView.Map.Zoom = new MapInfo.Geometry.Distance(dblZoom, DistanceUnit.Meter);
                mapControl1.Map.Zoom = mapControlView.Map.Zoom;
                mapControl1.Map.SetView(mapControlView.Map.Bounds.Center(), mapControlView.Map.GetDisplayCoordSys(), mapControlView.Map.Zoom);
                    //Map_ViewChanged(mapControl1.Map, e);
                }
                //PMove = mapControlView.Map.Center;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void mapToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            MyCurso = e.Button.ToolTipText;
            OldKey = mapControl1.Tools.LeftButtonTool;
            
        }
         //'hien thi trang thai cua ho so cap giay chung nhan
    public void TrangThaiHoSoCapGCN(){
        if  (lgMaHoSoCapGCN  != 0) {
          DataTable dt = new  DataTable();
           dt = clsData.SelectTrangThaiHoSo(lgMaHoSoCapGCN.ToString());
            int R = 0;
            int G = 0;
            int B = 0;
            if (dt.Rows.Count > 0)
            {
                picTrangThaiCapGCN.Visible = true;
                labTrangThaiCapGCN.Visible = true;
                R = (int)dt.Rows[0]["R"];
                G = (int)dt.Rows[0]["G"];
                B = (int)dt.Rows[0]["B"];
                picTrangThaiCapGCN.BackColor = Color.FromArgb(R, G, B);
                labTrangThaiCapGCN.Text = (string)dt.Rows[0]["Mota"];
                labTrangThaiCapGCN.ForeColor = Color.FromArgb(R, G, B);
            }
            else {
                picTrangThaiCapGCN.Visible = false ;
                labTrangThaiCapGCN.Visible = false ;
            }

    }
    }
        //public void TrangThaiCapGCN(string  TrangThai) {
        //    switch (TrangThai) {
        //        case "0":
        //            picTrangThaiCapGCN.BackColor = System.Drawing.Color.White;
        //            labTrangThaiCapGCN.Text = "Hồ sơ kê khai";
        //            labTrangThaiCapGCN.ForeColor = System.Drawing.Color.White;
        //            break;
        //        case "1":
        //            picTrangThaiCapGCN.BackColor = System.Drawing.Color.Yellow;
        //            labTrangThaiCapGCN.Text = "Hồ sơ cấp cơ sở";
        //            labTrangThaiCapGCN.ForeColor = System.Drawing.Color.Yellow;
        //            break;
        //        case "2":
        //            picTrangThaiCapGCN.BackColor = System.Drawing.Color.Wheat;
        //            labTrangThaiCapGCN.Text = "Xét duyệt cấp phường";
        //            labTrangThaiCapGCN.ForeColor = System.Drawing.Color.Wheat;
        //            break;
        //        case "3":
        //            picTrangThaiCapGCN.BackColor = System.Drawing.Color.Blue;
        //            labTrangThaiCapGCN.Text = "Chưa thẩm định";
        //            labTrangThaiCapGCN.ForeColor = System.Drawing.Color.Blue;
        //            break;
        //        case "4":
        //            picTrangThaiCapGCN.BackColor = System.Drawing.Color.Brown;
        //            labTrangThaiCapGCN.Text = "Thẩm định";
        //            labTrangThaiCapGCN.ForeColor = System.Drawing.Color.Brown;
        //            break;
        //        case "5":
        //            picTrangThaiCapGCN.BackColor = System.Drawing.Color.Cyan;
        //            labTrangThaiCapGCN.Text = "Phê duyệt";
        //            labTrangThaiCapGCN.ForeColor = System.Drawing.Color.Cyan;
        //            break;
        //        case "6":
        //            picTrangThaiCapGCN.BackColor = System.Drawing.Color.DarkGreen;
        //            labTrangThaiCapGCN.Text = "Hồ sơ đang chờ cấp GCN";
        //            labTrangThaiCapGCN.ForeColor = System.Drawing.Color.DarkGreen;
        //            break;
        //        case "7":
        //            picTrangThaiCapGCN.BackColor = System.Drawing.Color.Green;
        //            labTrangThaiCapGCN.Text = "Hồ sơ đã cấp GCN";
        //            labTrangThaiCapGCN.ForeColor = System.Drawing.Color.Green;
        //            break;
        //        default:
        //            picTrangThaiCapGCN.BackColor = System.Drawing.Color.Black;
        //            labTrangThaiCapGCN.Text = "Không tồn tại";
        //            labTrangThaiCapGCN.ForeColor = System.Drawing.Color.Black;
        //            break;
        //    }
        //}

        //ham thuc thi viec load lai map sau khi insert feature
        public void RefeshMap(MapInfo.Mapping.Map pMap, string layerName)
        {
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(layerName) != null)
            {
                pMap.Layers.Remove(layerName);
                MapInfo.Engine.Session.Current.Catalog.CloseTable(layerName);
            }

        }
        //cho phep thao tac chinh sua tren layer hay ko
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

        //tra gia tri map
        private MapInfo.Mapping.Map GetMapObj(string Map)
        {
            MapInfo.Mapping.Map myMap = MapInfo.Engine.Session.Current.MapFactory[Map];
            if (myMap == null)
            {
                myMap = MapInfo.Engine.Session.Current.MapFactory[0];
            }
            return myMap;
        }

        private MapInfo.Mapping.Map GetMap(MapControl pMap, string MapName)
        {
            MapInfo.Mapping.Map myMap = MapInfo.Engine.Session.Current.MapFactory[pMap.Map.Layers[CurentLayer].Map.Alias];
            if (myMap == null)
            {
                myMap = MapInfo.Engine.Session.Current.MapFactory[MapName];
            }
            return myMap;
        }
        #endregion

        //load form ban dau
        public void LoadForm()
        {
            try
            {
                mapControl1.Dock = DockStyle.Fill;
                //mapControl1.Map.Clear();
                if (MapInfo.Engine.Session.Current.Catalog.Count > 0)
                {
                    mapControl1.Map.Clear();
                }
                EditThuaDat = true;
                ChangeFeature = true;
                strConnectData = "Data Source=" + strServerName + ";Initial Catalog=" + strDatabaseName + " ;User ID=" + strUID + " ;PassWord=" + strUpass + "";
                strConnectionstring = "DRIVER={SQL Server};SERVER=" + strServerName + ";UID=" + strUID + ";PWD=" + strUpass + ";DATABASE=" + strDatabaseName + ";DLG=SQL_DRIVER_NOPROMPT";
                //khoi tao bien cho cac lop ham chuc nang xu ly
                cls = new clsMainSoanHoSo();
                cls.LayerName(LayerName);
                cls.BanDo(BanDo);
                cls.MaDonViHanhChinh = strMaDonViHanhChinh;
                cls.Connectionstring(strConnectionstring);
                cls.SetConnection(strConnectData);
                clsData = new clsDatabase();
                clsData.MaDonViHanhChinh = strMaDonViHanhChinh;
                clsData.SetConnection(strConnectData);
                //lay ma thua dat
                
                //Thiet lap an cac panel ban dau
                panelLeft.Hide();
                panDanhSachToaDo.Hide();
                panDiem.Hide();
                panXemIn.Hide();
                panKhoangCach.Hide();
                panDaoDiem.Hide();
                panThemDanhSachToaDo.Hide();
                panToaDo.Hide();
                panBuffer.Hide();
                panXoayDoiTuong.Hide();
                panThemDiemLamGocXoay.Hide();
                panKhoangCachChia.Hide();
                panToaDoDiem.Hide();
                panXemInMap.Hide();
                panBanKinhDuongTron.Hide();
                panTamDuongTron.Hide();
                panViTriDiemChuyen.Hide();
                //thiet lap cac dinh dang style ban dau
                _textStyle = new TextStyle();
                _vectorSymbol = new SimpleVectorPointStyle();
                _lineStyle = new SimpleLineStyle();
                _fillStyle = new SimpleInterior();
                _areaStyle = new AreaStyle();
                CopyStyle = new CompositeStyle();
                //thiet lap map 
                MapSet();
                //xoa du lieu tmp trong csdl
                clsData.XoaTmp(strBang, lgMaHoSoCapGCN);
                intUndo = 0;
                //mo bang
                FeatureID = clsData.GetMaThuaDat(strBangHoSo, lgMaHoSoCapGCN);

             ////////////////////////////////////////////////////////////////////////
                ////// Du lieu Hoang Mai se chay doan lenh nay tru phuong Hoang Liet
                ////// Du lieu Hoang Mai se chay doan lenh nay tru phuong Hoang Liet
                //if (strMaDonViHanhChinh != "100337" && strMaDonViHanhChinh != "100334")
                //{
                //    MapInfo.Geometry.CoordSysFactory miCSF = new MapInfo.Geometry.CoordSysFactory();
                //    MapInfo.Geometry.CoordSys LatLongCSys = default(MapInfo.Geometry.CoordSys);//Earth Projection 8, 104, "m", 105, 0, 0.9996, 500000, 0 Bounds (-7745844.29597, -9997964.94324) (8745844.29597, 9997964.94324)
                //   // string s = "CoordSys Earth Projection 8, 9999, 28, -191.90441429, -39.30318279, -111.45032835, -0.00928836, 0.01975479, -0.00427372, 0.252906278, 0," + (char)34 + "m" + (char)34 + ", 105, 0, 0.9996, 500000, 0 Bounds (-7745844.29597, -9997964.94324) (8745844.29597, 9997964.94324)";

                //    string s = "CoordSys Earth Projection 8, 104, " + (char)34 + "m" + (char)34 + ", 105, 0, 0.9996, 500000, 0 Bounds (-7749281.53901, -10002137.4978) (8749281.53901, 10002137.4978)";
                //    LatLongCSys = miCSF.CreateFromMapBasicString(s);
                //    if (LatLongCSys != mapControl1.Map.GetDisplayCoordSys())
                //    {
                //        mapControl1.Map.SetDisplayCoordSys(LatLongCSys);
                //    }
                //    else
                //    {
                //    }
                //}

                /////////////////////////////////////////////////////////////
                


                cls.LopBanDo(mapControl1, LayerName, LopNha, BanDo, TenLopDat, TenLopNha);
                LoadMapView(mapControlView, TenLopDat);
                panelLeft.Show();

                
                /* Khai báo lớp các chức năng bản đồ dùng chung */
                DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
                mapTools.ShowLand(mapControl1.Map, TenLopDat , FeatureID.ToString(), strMaDonViHanhChinh.ToString());


               

                OpenLayer(mapControl1);
                //load du lieu thuoc tinh
                LoadDLThuocTinh();
                ////cho phep chinh sua tren Map
                //cls.LopBanDo(mapControl1, LayerName, LopNha, BanDo, TenLopDat, TenLopNha);
                ////an panel ben trai
                //panelLeft.Hide();
            }
            catch (Exception ex) {  }
        }           
        //goi toi form soan ho so
        private void SoanHoSo(MapControl pMap)
        {
            try
            {
                frmDieuKhien frm = new frmDieuKhien();
                frm.SetCurentLayer(CurentLayer);
                frm.SetMapConT(pMap);
                frm.SetLableName(Nhan);
                frm.SetTyLe(TyleBanDo);
                frm.Connection = strConnectData;
                frm.ConnectionString = strConnectionstring;
                frm.NhanCanh = NhanKichThuoc;
                frm.NhanDinh = NhanDinh;
                frm.NhanNode = NhanNode;
                frm.NhanThua = NhanThua;
                frm.LayerName = LayerName;
                frm.FeatureID = FeatureID;
                frm.TenBang = strBang;
                frm.BanDo = BanDo;
                frm.DuongBao = DuongBao;
                frm.Process = staProcess;
                frm.TyLeZommView = dlTyLeZoomView;
                frm.TyLeDienTichThua = dlDienTichThua;
                frm.CtrForm = this;
                frm.Show();
            }catch( Exception ex ){}
        }
        //hien thi form dieu khien
        private void mnuSoanHoSo_Click(object sender, System.EventArgs e)
        {
            SoanHoSo(mapControl1);
        }
        private void mnuSoanHoSoThuaDat_Click(object sender, System.EventArgs e)
        {
            SoanHoSo(mapControl1);
        }
   
        //ham tao 1 bang moi trong map
        private MapInfo.Data.Table CreateNewMapDataTable(MapInfo.Mapping.Map map, string strTemplateTableName, string strNewTableName)
        {
            //tạo mới đối tượng FeatureLayer
            MapInfo.Mapping.FeatureLayer featureLayerTemplate = (FeatureLayer)map.Layers[strTemplateTableName];
            //tạo mới bảng
            MapInfo.Data.Table tableTemplate = featureLayerTemplate.Table;

            FeatureLayer fl = new FeatureLayer(tableTemplate);
            //tạo mới 1 đối tượng TableInfo
            MapInfo.Data.TableInfo tableInfo = MapInfo.Data.TableInfoFactory.CreateTemp(strNewTableName, fl.CoordSys);
            //add tên các cột dữ liệu từ các cột dữ liệu truyền vào
            for (int i = 0; i < tableTemplate.TableInfo.Columns.Count - 1; i++)
            {
                tableInfo.Columns.Add(new MapInfo.Data.Column(tableTemplate.TableInfo.Columns[i].Alias, tableTemplate.TableInfo.Columns[i].DataType));
            }
            //Tạo mới đối tượng bảng
            MapInfo.Data.Table tableNew = MapInfo.Engine.Session.Current.Catalog.CreateTable(tableInfo);
            MapInfo.Mapping.FeatureLayer featureLayerNew = new MapInfo.Mapping.FeatureLayer(tableNew, strNewTableName);
            //add đối tượng bảng vừa tạo vào map
            map.Layers.Add(featureLayerNew);
            //trả về giá trị bảng vừa tạo
            return tableNew;
        }

        private void mnuCloseAllTable_Click(object sender, System.EventArgs e)
        {

            string str;
            for (int i = 0; i < mapControl1.Map.Layers.Count; i++)
            {
                str = mapControl1.Map.Layers[i].Alias;
                mapControl1.Map.Layers.Remove(str);
            }
            mapControl1.Map.Clear();
        }

        //hàm kiểm tra chuỗi nhập vào có phải là số không
        public bool Ktra(string str)
        {
            char[] ar = str.ToCharArray();
            bool kt;
            kt = true;
            int j = 0;
            for (int i = 0; i <= ar.Length - 1; i++)
            {
                if (j > 1)
                {
                    kt = false;
                    return kt;
                }
                if ((j < 1) && (!System.Char.IsNumber(ar[i])))
                {
                    if (ar[i] == System.Convert.ToChar("."))
                    {
                        j = j + 1;
                    }
                    kt = false;
                    MessageBox.Show(str + " không phải là số!!");
                    return kt;
                }
            }
            return kt;
        }

        public void ChonDoiTuongGhiDanhSachToaDo(Feature f){
            DPoint[] d = null;
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
                staProcess.Value = staProcess.Value + 1;
            }
            catch (Exception ex) { }

        }
        //hien thi danh sach toa do
        public bool DoiTuongThuaGoc(MapControl pMap, string LayerName)
        {
            try
            {
               
                //goi du lieu bang hien thoi
                MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);

                IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];

               // IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong =1001 or MaDoiTuong=101"));
                //tim tat ca cac doi tuong duoc chon dua vao mang
                FeatureLayer Lyr = pMap.Map.Layers[LayerName] as FeatureLayer;
                if (irfc == null)
                {
                    MessageBox.Show("Chọn thửa đất chính ??");
                    return false ;
                }
                if (irfc.Count == 0) 
                {
                    MessageBox.Show("Chọn thửa đất chính ??");
                    return false ;
                }
                if (irfc.Count != 1)
                {
                    MessageBox.Show("Chỉ chọn thửa đất làm thửa đất chính !!!");
                    return false;
                }
                //staProcess.Visible = true;
                //staProcess.Maximum = irfc.Count;
                //staProcess.Value = 0;
                //int i = 0;
                foreach (Feature f in irfc)
                {
                    if (f.Geometry.GetType().ToString() == "MapInfo.Geometry.MultiPolygon")
                    {
                        ChonDoiTuongGhiDanhSachToaDo(f);
                        //i = i + 1;
                    }                   
                }
                //if ((i > 1) || (i ==0))
                //{
                //    MessageBox.Show("Kiểm tra thửa đất duy nhất ở dạng vùng ??");
                //    return false;
                //}
                //staProcess.Visible = false;
            }
            catch (Exception ex) { }
            return true;
        }
        //hien thi danh sach toa do
        public void ToaDo(MapControl pMap, string LayerName)
        {
            try
            {
                //goi du lieu bang hien thoi
                MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                // MapInfo.Data.Feature myfc = MapInfo.Engine.Session.Current.Catalog.SearchForFeature(table, MapInfo.Data.SearchInfoFactory.SearchWhere("featureID=" + FeatureID + ""));
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
                staProcess.Visible = true;
                staProcess.Maximum = irfc.Count;
                staProcess.Value = 0;
                foreach (Feature f in irfc)
                {
                    ChonDoiTuongGhiDanhSachToaDo(f);
                }
                staProcess.Visible = false;
            }
            catch (Exception ex) { }
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
        public void TaoPan(int Count, string[] ValueX, string[] ValueY, string[] ValueHSGoc, string[] ValueChieuDai,int SoLan,int STT)
        {
            try
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
            }catch( Exception ex){}
        }
        //xem truoc khi in
        //public void LoadXemTruocKhiIn(MapControl pMap, ToolStripProgressBar staProcess)
        //{
        //    MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
        //    IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());
        //    if (irfc == null)
        //    {
        //        return;
        //    }
        //    if (irfc.Count == 0)
        //    {
        //        return;
        //    }
        //    Table ThuaDat = null;
        //    //lay du lieu dua vao bang thua dat
        //    ThuaDat = MapInfo.Engine.Session.Current.Catalog.GetTable("tmp");
        //    //neu bang xemin da ton tai thi dong lai
        //    if (MapInfo.Engine.Session.Current.Catalog.GetTable("XemIn") != null)
        //    {
        //        MapInfo.Engine.Session.Current.Catalog.CloseTable("XemIn");
        //    }
        //    //tao moi bang xemin
        //    MapInfo.Data.Table dt = cls.CreateTable(pMap.Map, ThuaDat, "XemIn");
        //    //goi bang hien thoi
        //    Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
        //    //insert tat ca cac doi tuong tren map vao bang XemIn
        //    staProcess.Visible = true;
        //    staProcess.Maximum = irfc.Count;
        //    staProcess.Value = 0;
        //    foreach (Feature MyFeature in irfc)
        //    {
        //        dt.InsertFeature(MyFeature);
        //        staProcess.Value = staProcess.Value + 1;
        //    }
        //    staProcess.Visible = false;
        //    //dua du lieu len mapXemIn
        //    FeatureLayer fl = new FeatureLayer(dt);
        //    mapXemIn.Map.Layers.Add(fl);
        //    mapXemIn.Map.SetView(fl);
        //}

        //chon che do zoom phu hop voi ban in
        private void cboTyLeIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////tinh ti le phan tram
            //double PhanTram;
            //PhanTram = TyleBanDo / 100;
            //double zoom;
            //zoom = 0.1;
            //if (cboTyLeIn.Text != "")
            //{
            //    if (cboTyLeIn.Text == "Auto Fix")
            //    {//neu chon tu dong fix thi zoom chinh bang ty le ban do
            //        zoom = System.Convert.ToDouble(TyleBanDo);
            //    }
            //    else
            //    {// fix thi zoom chinh bang thong so nhân phần trăm tỷ lệ bản đô
            //        zoom = System.Convert.ToDouble(Convert.ToDouble(cboTyLeIn.Text) * PhanTram);
            //    }
            //}
            ////hien thi muc zoom cua mapXemIn
            //GetZoom(zoom, mapXemIn);
            ////gan Fixzoom
            //FixZoom = zoom;
        }

        private void grDanhSachToaDo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //goi ham hien thị nút điểm lên bản đồ
                ChonNutDiem(e.RowIndex);
                grDanhSachToaDo.Columns[3].DefaultCellStyle.BackColor = System.Drawing.Color.Chocolate;
                grDanhSachToaDo.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.Cyan;
                //gọi hàm tạo mới điểm vừa chọn trong danh sach toạ độ
                cls.getSelectNode(mapControl1, grDanhSachToaDo, e.RowIndex, LayerName);
            }
            catch (Exception ex) { }
        }
        #region Code reporting relevant map, tool, and mouse events to user


        public void ToolActivating(object sender, ToolActivatingEventArgs e)
        {
            
        }
        public void ToolActivatedFired(object sender, ToolActivatedEventArgs e)
        {
          
        }
        public void ToolUsed(object sender, ToolUsedEventArgs e)
        {
            try
            {
                pointStart = e.MapCoordinate;
                if (e.ToolName == "AddText")
                {

                    MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                    DMC.Land.SoanHoSo.frmSetTextStyle frm = new DMC.Land.SoanHoSo.frmSetTextStyle();
                    Feature f = new Feature(tab.TableInfo.Columns);
                    DPoint d2 = new DPoint();
                    d2.x = pointStart.x + 1;
                    d2.y = pointStart.y + 1;
                    DRect dr = new DRect(pointStart, d2);
                    LegacyText txt = new LegacyText(mapControl1.Map.GetDisplayCoordSys(), dr, " ");
                    TextStyle cs = new TextStyle();
                    frm.CtrForm = this;
                    f.Geometry = txt;
                    f.Style = cs;
                    //truyền tham số cho đối tượng form
                    frm.SetMapConT = mapControl1;
                    frm.SetFeature = null;
                    frm.SetObiText = "";
                    frm.SetTable = tab;
                    frm.SetFeature = f;
                    frm.SetTextStyle = cs;
                    frm.TenBang = strBang;
                    frm.FeatureID = FeatureID;
                    frm.DienTichThua = dlDienTichThua;
                    frm.TyLeZoomThua = dlTyLeZoomView;
                    frm.ShowDialog();

                    RefreshMap(mapControl1, LayerName);

                }
            }catch(Exception ex ){}
        }
        public void ToolEnding(object sender, ToolEndingEventArgs e)
        {
        }
        public void FeatureAdding(object sender, FeatureAddingEventArgs e)
        {
                            ChangeFeature = false;
                e.Cancel = false;
                mapControl1.Refresh();          
            
            
        }
        public void FeatureAdded(object sender, FeatureAddedEventArgs e)
        {
            ChangeFeature = false;
            try {
                ExportsFileTab();
            }catch(Exception ex ){}
        }
        public void FeatureSelecting(object sender, FeatureSelectingEventArgs e)
        {
            e.Cancel = false;
        }
        public void FeatureSelected(object sender, FeatureSelectedEventArgs e)
        {
            try
            {
                //hien thi thong so chieu dai len thanh taskbar
                toolChieuDai.Text = System.Math.Round(GetChieuDai(mapControl1, LayerName), 2).ToString() + " (m)";
                txtChieuDaiDoanThangChia.Text = GetChieuDai(mapControl1, LayerName).ToString();
                numKhoangCachChia.Value = Convert.ToDecimal(txtChieuDaiDoanThangChia.Text);
                txtConLaiKhoangCachChia.Value = 0;
                //hien thi thong so dien tich thua len thanh taskbar
                toolDienTich.Text = System.Math.Round(GetDienTich(mapControl1, LayerName), 2).ToString() + " (m2)";
                //load danh sach toa do, he so goc , chieu dai 
                ToaDo(mapControl1, LayerName);
            }catch (Exception ex){}
        }

        public void FeatureChanging(object sender, FeatureChangingEventArgs e)
        {
            ExportsFileTab();
            ChangeFeature = false;
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count == 0)
            {
                return;
            }
            if (EditThuaDat){
                foreach (Feature f in irfc)
                {
                    try
                    {
                        //nếu đối tượng được chọn có kiểu MultiPolygon
                        if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon") || f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                        { 
                            string MaDoiTuong;
                            MaDoiTuong = cls.GetMaDoiTuong(f, ThuaDat);
                            //neu doi tuong la thua dat hoac duong cua thua dat thi ko cho phep di chuyen
                            if ((MaDoiTuong == "1001")||(MaDoiTuong == "101"))
                            {
                                e.Cancel = true;
                            }
                            else
                            {
                                e.Cancel = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
           
        }
        public void FeatureChanged(object sender, MapInfo.Tools.FeatureChangedEventArgs e)
        {
            ChangeFeature = false;
            pointEnd = e.MapCoordinate;
            RefreshMap(mapControl1, LayerName);
        }
        public void NodeChanging(object sender, NodeChangingEventArgs e)
        {
            ExportsFileTab();
            ChangeFeature = false;
            e.Cancel = false;
        }
        public void FeatureMove(object sender, CollectionEventHandler e)
        {
             mapToolBar1.MapControl=mapControlView;
            mapControl1.Map = mapControlView.Map ;
        }

        public void NodeChanged(object sender, NodeChangedEventArgs e)
        {
            ChangeFeature = false;
        }

        public void LabelAdding(object sender, LabelAddingEventArgs e)
        {
            ExportsFileTab();
            ChangeFeature = false;
            e.Cancel = false;
        }

        public void LabelAdded(object sender, LabelAddedEventArgs e)
        {
            ChangeFeature = false;
        }

        #endregion
        #region goi den cac dieu khien dialog
        //gọi hàm thay đổi thuộc tính đối tượng nút
        public void OpenDlgNode(MapControl pMap, string LayerName)
        {
            _symbolStyleDlg = null;
            if (_symbolStyleDlg == null)
            {
                _symbolStyleDlg = new SymbolStyleDlg();
                _symbolStyleDlg.SymbolStyle = _vectorSymbol;
            }
            if (_symbolStyleDlg.ShowDialog() == DialogResult.OK)
            {
                CompositeStyle cs = new CompositeStyle();
                MapInfo.Styles.BasePointStyle sym = _symbolStyleDlg.SymbolStyle;
                if (sym is MapInfo.Styles.BitmapPointStyle)
                {
                    _bitmapSymbol = sym as MapInfo.Styles.BitmapPointStyle;
                    cs.ApplyStyle(_bitmapSymbol);

                }
                else if (sym is MapInfo.Styles.FontPointStyle)
                {
                    _fontSymbol = sym as MapInfo.Styles.FontPointStyle;
                    cs.ApplyStyle(_bitmapSymbol);

                }
                else
                {
                    _vectorSymbol = sym as MapInfo.Styles.SimpleVectorPointStyle;
                    cs.ApplyStyle(_vectorSymbol);

                }
                cls.SetStyle(pMap, pMap.Map.Layers[LayerName].Alias, cs, LayerName);
                ExportsFileTab();
            }
        }
        //Gọi hàm thay đổi thuộc tính Line
        public void OpenDlgLine(MapControl pMap, string LayerName)
        {
            _lineStyleDlg = null;
            if (_lineStyleDlg == null)
            {
                _lineStyleDlg = new LineStyleDlg();
            }
            _lineStyleDlg.LineStyle = _lineStyle;
            if (_lineStyleDlg.ShowDialog() == DialogResult.OK)
            {
                CompositeStyle cs = new CompositeStyle();
                BaseLineStyle ls = _lineStyleDlg.LineStyle;
                if (ls is SimpleLineStyle)
                {
                    _lineStyle = (SimpleLineStyle)ls;
                    cs.ApplyStyle(_lineStyle);
                    cls.SetStyle(pMap, pMap.Map.Layers[LayerName].Alias, cs, LayerName);
                    ExportsFileTab();
                    pMap.Refresh();
                }
                else
                {
                    throw new System.NotImplementedException("New style type not handled.");
                }
            }
        }
        //goi hàm thay đổi thuộc tính đối tượng text
        public void OpenDlgText(MapControl pMap, string LayerName)
        {
            _textStyleDlg = null;
            if (_textStyleDlg == null)
            {
                _textStyleDlg = new TextStyleDlg();
                _textStyleDlg.FontStyle.Size = 10;
               
            }
            if (_textStyleDlg.ShowDialog() == DialogResult.OK)
            {
                _textStyle.Font = _textStyleDlg.FontStyle;
                cls.TyLeZoomView = dlTyLeZoomView;
                cls.DienTichThua = dlDienTichThua;
                cls.SetStyleText(pMap, pMap.Map.Layers[LayerName].Alias, _textStyle, LayerName);
                ExportsFileTab();
                mapControl1.Refresh();
                // OpenLayer(mapControl1.Map);
            }
        }
        //Gọi hàm thay đổi thuộc tính đối tượng vùng
        public void OpenDlgArea(MapControl pMap, string LayerName)
        {
            if (_areaStyleDlg == null)
            {
                _areaStyleDlg = new AreaStyleDlg();
            }
            _areaStyleDlg.AreaStyle = new AreaStyle(_lineStyle, _fillStyle);
            if (_areaStyleDlg.ShowDialog() == DialogResult.OK)
            {
                CompositeStyle cs = new CompositeStyle();
                if (_areaStyleDlg.AreaStyle.Border is SimpleLineStyle)
                {
                    _lineStyle = (SimpleLineStyle)_areaStyleDlg.AreaStyle.Border;
                    cs.ApplyStyle(_lineStyle);
                }
                else
                {
                    throw new System.NotImplementedException("New style type not handled.");
                }
                if (_areaStyleDlg.AreaStyle.Interior is SimpleInterior)
                {
                    _fillStyle = (SimpleInterior)_areaStyleDlg.AreaStyle.Interior;

                    cs.ApplyStyle(_fillStyle);

                }
                else
                {
                    throw new System.NotImplementedException("New style type not handled.");
                }
                if (_areaStyleDlg.AreaStyle is AreaStyle)
                {
                    _areaStyle = (AreaStyle)_areaStyleDlg.AreaStyle;
                    cs.ApplyStyle(_areaStyle);

                }
                else
                {
                    throw new System.NotImplementedException("New style type not handled.");
                }
                cls.SetStyle(pMap, pMap.Map.Layers[LayerName].Alias, cs, LayerName);
                ExportsFileTab();
            }

        }

        //hiển thị hộp điều khiển thay đổi thuộc tính text
        private void mnuStyleText_Click(object sender, EventArgs e)
        {
            OnCheckNodeStyle(mnuStyleText);
            ChangeTextAll(strBang, mapControl1, LayerName);
            RefreshMap(mapControl1, LayerName);
        }
        //hiển thị hộp điều khiển thay đổi thuộc tính Line
        private void mnustyleLine_Click(object sender, EventArgs e)
        {
            OnCheckNodeStyle(mnustyleLine);
            OpenDlgLine(mapControl1, LayerName);
        }
        //hiển thị hộp điều khiển thay đổi thuộc tính Area
        private void mnuStyleArea_Click(object sender, EventArgs e)
        {
            OnCheckNodeStyle(mnuStyleArea);
            OpenDlgArea(mapControl1, LayerName);
        }
        //hiển thị hộp điều khiển thay đổi thuộc tính nút
        private void mnuStyleNode_Click(object sender, EventArgs e)
        {
            OnCheckNodeStyle(mnuStyleNode);
            OpenDlgNode(mapControl1, LayerName);
        }

        //Ham thiet lap viec chon duy nhat 1 kieu style de xu ly
        public void OnCheckNodeStyle(ToolStripMenuItem Tool)
        {
            ToolStripMenuItem[] myTool = new ToolStripMenuItem[4];
            myTool[0] = mnuStyleText;
            myTool[1] = mnustyleLine;
            myTool[2] = mnuStyleNode;
            myTool[3] = mnuStyleArea;
            for (int i = 0; i < myTool.Length; i++)
            {
                if (myTool[i] == Tool)
                {
                    myTool[i].Checked = true;
                }
                else
                {
                    myTool[i].Checked = false;
                }
            }
        }
        #endregion
        #region Hàm chọn đối tượng(nhãn đỉnh, nhãn thửa ... )
        //chon toan bo nhan dinh
        public void ChonNhanDinh()
        {
            Nhan = NhanDinh;
            DoiTuong = "1";
            OnCheckNodeNhan(mnuNhanDinh);
            cls.TachLopDoiTuong(DoiTuong, LayerName);
        }
        //chon toan bo nhan canh
        public void ChonNhanCanh(String LayerName)
        {
            Nhan = NhanKichThuoc;
            DoiTuong = "2";
            OnCheckNodeNhan(mnuNhanCanh);
            cls.TachLopDoiTuong(DoiTuong, LayerName);
        }
        //chon toan bo nhan nut
        public void ChonNhanNode(String LayerName)
        {
            Nhan = NhanNode;
            DoiTuong = "3";
            OnCheckNodeNhan(mnuNhanNut);
            cls.TachLopDoiTuong(DoiTuong, LayerName);
        }
        //chon toan bo nhan thua
        public void ChonNhanThua(String LayerName)
        {
            Nhan = NhanThua;
            DoiTuong = "5";
            OnCheckNodeNhan(mnuNhanThua);
            cls.TachLopDoiTuong(DoiTuong, LayerName);
        }
        //chon toan bo duogn bao
        public void ChonDuongBao(String LayerName)
        {
            Nhan = DuongBao;
            DoiTuong = "4";
            OnCheckNodeNhan(mnuDuongBao);
            cls.TachLopDoiTuong(DoiTuong, LayerName);
        }
        private void mnuNhanDinh_Click(object sender, EventArgs e)
        {
            ChonNhanDinh();
        }
        private void mnuNhanCanh_Click(object sender, EventArgs e)
        {
            ChonNhanCanh(LayerName);
        }
        private void mnuNhanNut_Click(object sender, EventArgs e)
        {
            ChonNhanNode(LayerName);
        }
        private void mnuNhanThua_Click(object sender, EventArgs e)
        {
            ChonNhanThua(LayerName);
        }
        private void mnuDuongBao_Click(object sender, EventArgs e)
        {
            ChonDuongBao(LayerName);
        }
        //Ham thiet lap viec chon duy nhat 1 lop ban do de xu ly
        public void OnCheckNodeNhan(ToolStripMenuItem Tool)
        {
            //khai bao mang doi tuong duoc chon
            ToolStripMenuItem[] myTool = new ToolStripMenuItem[5];
            myTool[0] = mnuNhanDinh;
            myTool[1] = mnuNhanCanh;
            myTool[2] = mnuNhanNut;
            myTool[3] = mnuNhanThua;
            myTool[4] = mnuDuongBao;
            for (int i = 0; i < myTool.Length; i++)
            {
                if (myTool[i] == Tool)
                {
                    //neu chon doi tuong thi checked
                    myTool[i].Checked = true;
                }
                else
                {
                    //neu doi tuong ko duoc chon
                    myTool[i].Checked = false;
                }
            }
            //di chuyen doi tuong len lop tren cung
            for (int j = 0; j < mapControl1.Map.Layers.Count; j++)
            {
                if (mapControl1.Map.Layers[j].Alias == Nhan)
                {
                    //cho phep edit lop doi tuong duoc chon
                    int iLayerIndex = mapControl1.Map.Layers.IndexOf(mapControl1.Map.Layers[Nhan]);
                    mapControl1.Map.Layers.Move(iLayerIndex, 0);
                    EditableLayer(mapControl1, Nhan, true);
                }
                else
                {
                    //khong cho phep edit lop doi tuong khong duoc chon
                    EditableLayer(mapControl1, mapControl1.Map.Layers[j].Alias, false);
                }
            }
        }
        # endregion
        #region phan buffer
        #region Phan tao buffer (xep Chung lam)
        private Feature DrawCircle(MapControl mapcontrol)
        {
            int buff;
            double MySize;
            buff = 20;
            DPoint PP;

            if (MapInfo.Engine.Session.Current.Catalog.GetTable("Buff") != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable("Buff");
            }
            MapInfo.Data.Table dt = CreateNewMapDataTable(mapcontrol.Map, LayerName, "Buff");
            MapInfo.Geometry.DPoint center = mapcontrol.Map.Layers[LayerName].Map.Center;
            PP.x = mapcontrol.Map.Layers[LayerName].Map.Bounds.x1;
            PP.y = mapcontrol.Map.Layers[LayerName].Map.Bounds.y1;
            MySize = System.Math.Sqrt((PP.x - center.x) * (PP.x - center.x) + (PP.y - center.y) * (PP.y - center.y));
            MySize = MySize + buff;
            MapInfo.Data.Table table = null;

            MapInfo.Geometry.Ellipse circle = new MapInfo.Geometry.Ellipse(mapcontrol.Map.GetDisplayCoordSys(), center, MySize, MySize, MapInfo.Geometry.DistanceUnit.Meter, MapInfo.Geometry.DistanceType.Spherical);
            MapInfo.Styles.AreaStyle circleStyle = new MapInfo.Styles.AreaStyle();
            // _fillStyle = (SimpleInterior)_areaStyleDlg.AreaStyle.Interior;
            // circleStyle = _areaStyleDlg.AreaStyle;
            MapInfo.Data.Feature f = new MapInfo.Data.Feature(circle, circleStyle);
            MultiPolygon poly = circle.CreateMultiPolygon(50);
            MapInfo.Styles.AreaStyle cs = new MapInfo.Styles.AreaStyle();
            MapInfo.Data.Feature fff = new MapInfo.Data.Feature(poly, cs);
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(dt.Alias);
            MapInfo.Data.Feature pft = new MapInfo.Data.Feature(table.TableInfo.Columns);
            pft.Geometry = fff.Geometry;
            pft.Style = circleStyle;

            table.InsertFeature(f);
            //FeatureLayer fl = new FeatureLayer(table);
            //mapcontrol.Map.Layers.Add(fl);
            return fff;
        }
        public void BufferFeature(MapControl mapcontrol)
        {
            //ve 1 hinh tron 


            //load du lieu ban do tong the
            string strSql;
            strSql = "select * from " + BanDo;
            MIConnection Connection = new MIConnection();
            Connection.Open();
            MapInfo.Data.Table tables = null;
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(BanDo) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(BanDo);
            }
            TableInfoServer tis1 = new TableInfoServer(BanDo, strConnectionstring, strSql, MapInfo.Data.ServerToolkit.Odbc);
            tables = Connection.Catalog.OpenTable(tis1);
            FeatureLayer lyr = new FeatureLayer(tables);
            mapControl1.Map.Layers.Add(lyr);


            tables.InsertFeature(DrawCircle(mapcontrol));
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tables, MapInfo.Data.SearchInfoFactory.SearchAll());

            //lay thong tin collection
            if (MapInfo.Engine.Session.Current.Catalog.GetTable("Circle") != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable("Circle");
            }
            MapInfo.Data.Table dt = CreateNewMapDataTable(mapcontrol.Map, LayerName, "Circle");
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(dt.Alias);


            MapInfo.Data.Feature feature = null;
            MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
            feature = featureProcessor.ConvexHull(irfc);
            table.InsertFeature(feature);

        }
        public double DrawBuff()
        {
            DPoint Center;
            double Maxvalue;
            Maxvalue = 0;
            Center = mapControl1.Map.Layers[LayerName].Map.Center;

            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            MapInfo.Data.Feature myfc = MapInfo.Engine.Session.Current.Catalog.SearchForFeature(table, MapInfo.Data.SearchInfoFactory.SearchWhere("featureID='" + FeatureID.ToString().Split('.')[0] + "'"));
            FeatureLayer Lyr = mapControl1.Map.Layers[LayerName] as FeatureLayer;

            if (Lyr != null)
            {
                DPoint[] d = null;

                MultiPolygon plg = (MultiPolygon)myfc.Geometry;
                foreach (Polygon pl in plg)
                {
                    d = pl.Exterior.SamplePoints();
                }
                double MySize;
                MySize = 0.0;
                double[] LineSize = new double[d.Length - 1];
                for (int i = 0; i < d.Length - 1; i++)
                {
                    //lay kich thuoc canh noi 2 dinh lien ke
                    MySize = System.Math.Sqrt((d[i].x - Center.x) * (d[i].x - Center.x) + (d[i].y - Center.y) * (d[i].y - Center.y));
                    LineSize[i] = System.Math.Round(MySize, 2);
                }
                Maxvalue = 0;
                for (int i = 0; i < LineSize.Length; i++)
                {
                    Maxvalue = Math.Max(LineSize[i], Maxvalue);
                }

            }
            return Maxvalue;
        }
        //goi form thuc thi tao buffer hien thi
        public void Buffer(MapControl pMap, string LayerName)
        {
            frmBuffer frm = new frmBuffer();
            frm.SetMapConT(pMap);
            frm.ShowDialog();
            frm.Close();
        }
        //ham tao buffer
        public void getBuff(int buff, MapControl mapcontrol, bool kieu)
        {

            int MySize;
            MySize = 0;
            Table TabTmmBanDo = null;
            TabTmmBanDo = MapInfo.Engine.Session.Current.Catalog.GetTable("tmpBanDo");
            //lay thong tin ve layer hien thoi
            DPoint Center = new DPoint();
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection Lfc = Session.Current.Selections.DefaultSelection[tab];
            MapInfo.Geometry.DRect rect = new DRect();
            if (Lfc == null)
            {
                MessageBox.Show("Chọn đối tượng !!");
                return;
            }
            foreach (Feature f in Lfc)
            {
                //lay toa do tam va duong bao cua layer hient hoi
                Center = f.Geometry.Centroid;
                rect = f.Geometry.Bounds;
            }
            //dua layer hien thoi ve tam ban do
            mapcontrol.Map.SetView(rect, mapcontrol.Map.GetDisplayCoordSys());// (Lfc.Envelope);
            //chieu dai tu tam toi dinh cua duong bao
            MySize = System.Convert.ToInt32(System.Math.Round(System.Math.Sqrt((rect.x1 - Center.x) * (rect.x1 - Center.x) + (rect.y1 - Center.y) * (rect.y1 - Center.y)), 0));
            // cong them phan buff
            MySize = MySize + buff * 160;//1609
            //chuyen toa do thuc ve toa do man hinh
            System.Drawing.PointF point = cls.ConvertPoinF(Center, mapcontrol);
            //lay tap hop cac doi tuong  
            //neu lay theo duong tron
            IResultSetFeatureCollection fc = null;
            FeatureLayer fl = new FeatureLayer(tab);
            if (kieu == false)
            {
                fc = MapInfo.Engine.Session.Current.Catalog.Search(TabTmmBanDo, MapInfo.Mapping.SearchInfoFactory.SearchWithinScreenRadius(mapcontrol.Map.Layers["tmpBanDo"].Map, point, MySize, 1000, ContainsType.Geometry));
            }
            //neu lay theo HCN
            if (kieu)
            {
                DPoint p = new DPoint();
                p.x = Center.x;
                p.y = Center.y;
                SearchInfo si = MapInfo.Mapping.SearchInfoFactory.SearchWithinScreenRect(mapcontrol.Map.Layers["tmpBanDo"].Map, NewBound(mapcontrol, rect, buff * 160, p), ContainsType.Centroid);
                fc = MapInfo.Engine.Session.Current.Catalog.Search(TabTmmBanDo, si);
            }
            if (fc == null)
            {
                return;
            }


            if (fc.Count == 0)
            {
                IResultSetFeatureCollection IrThua = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());
                foreach (Feature f in IrThua)
                {
                    if (!f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                    {
                        tab.DeleteFeature(f);
                    }
                }

            }
            //select cac doi tuong
            cls.SelectFeatureCollection(fc);

            //them cac layer vua lay ra vao bang Soan
            foreach (Feature f in fc)
            {
                tab.InsertFeature(f);
                MapInfo.Engine.Session.Current.Catalog.GetTable("tmpBanDo");
            }
            MapInfo.Engine.Session.Current.Catalog.CloseTable("tmpBanDo");
        }
        #endregion
        //tao lai duogn bao
        public void TaoLaiDuongBao(MapControl pMap, Table ThuaDat, Table table, string LayerName, double size, ToolStripProgressBar staProcess, int i)
        {
            //khai bao cac doi tuong
            CompositeStyle cs = new CompositeStyle();
            Table tmpLine = null;
            DPoint[] d = null;
            try
            {
                if (i == 0)
                {
                    MapInfo.Data.IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
                    DPoint[] dDinhThua = null;
                    dDinhThua = cls.ToaDoDinhThua(pMap, LayerName);
                    foreach (Feature f in irfc)
                    {
                        d = cls.LayGiaoDiemCacDuongSongSong(pMap, f, ThuaDat, size, LayerName, dDinhThua, staProcess, false);
                        if (d == null)
                        {
                            return;
                        }
                        //update đường bao vừa bạo vào Bảng
                        cls.mpxDrawLine(pMap.Map, "", "", d, cs, LayerName, staProcess);
                        i = i + 1;
                    }
                }
                else
                {
                    //    MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();

                    tmpLine = cls.CreateTable(pMap.Map, ThuaDat, "LineBuff");

                    ChonDuongBao(LayerName);
                    Feature fFeature = null;
                    //goi ham FeatureConbine
                    fFeature = cls.FeatureCombine(pMap.Map, LayerName, staProcess);
                    tmpLine.InsertFeature(fFeature);

                    //MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(fFeature);
                    IResultSetFeatureCollection irfcTmp = Session.Current.Catalog.Search(tmpLine, MapInfo.Data.SearchInfoFactory.SearchAll());
                    // (IResultSetFeatureCollection)fFeature;
                    //cls.CombineFeatures(pMap.Map, LayerName, staProcess);
                    cls.SelectFeatureCollection(irfcTmp);
                    DPoint[] dDinhThua = null;
                    dDinhThua = cls.ToaDoDinhThua(pMap, tmpLine.Alias);

                    d = cls.LayGiaoDiemCacDuongSongSong(pMap, fFeature, ThuaDat, size, LayerName, dDinhThua, staProcess, false);
                    if (d == null)
                    {
                        return;
                    }
                    //update đường bao vừa bạo vào Bảng
                    cls.mpxDrawLine(pMap.Map, "", "", d, cs, LayerName, staProcess);
                    MapInfo.Engine.Session.Current.Catalog.CloseTable("LineBuff");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //ham chuc nang combine thanh doi tuong Line
        public MultiCurve CombineCurver(MapInfo.Mapping.Map map, string strLayerName, IResultSetFeatureCollection irfc)
        {
            if (irfc == null)
            {
                return null;
            }
            /* Khai báo lớp có các Features muốn combine */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            //khai bao doi tuong Fearure
            Feature feature = null;
            /* Khai báo bảng tương ứng với lớp muốn combine */
            MapInfo.Data.Table table = featureLayer.Table;
            MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
            /* Chỉ combine các features trong cùng một lớp có tên là strLayerName */
            if (irfc.BaseTable.Alias == featureLayer.Table.Alias)
            {
                /* Tạo Feature từ tập hợp các Feature vừa chọn để combine */
                feature = featureProcessor.Combine(irfc);
            }
            MultiCurve fCV = (MultiCurve)feature.Geometry;
            return fCV;
        }
        //tao khung duogn bao quanh
        public void TaoKhungDuongBuffer(MapControl pMap, Table ThuaDat, Table table, string LayerName, ToolStripProgressBar staProcess, double size)
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    TaoLaiDuongBao(pMap, ThuaDat, table, LayerName, size, staProcess, i);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //lay giao diem cua DuongBao buffer voi cac canh cua ban do dat
        public void GiaoDiemBuffVabanDo(MapControl pMap, Table tab, Feature FeaKhungBao, MultiCurve CvCanh, MultiCurve[] CvDuongbao, string LayerName, ToolStripProgressBar staProcess)
        {
            DPoint[] DiemCanhTmp = new DPoint[2];
            DPoint[] DiemCanh = new DPoint[2];
            CompositeStyle cs = new CompositeStyle();
            MapInfo.Geometry.MultiPoint po = new MultiPoint(pMap.Map.GetDisplayCoordSys());
            foreach (Curve c in CvCanh)
            {
                DiemCanhTmp[0] = c.StartPoint;
                DiemCanhTmp[1] = c.EndPoint;
            }
            if (FeaKhungBao.Geometry.ContainsPoint(DiemCanhTmp[0]))
            {
                DiemCanh[0] = DiemCanhTmp[0];
                DiemCanh[1] = DiemCanhTmp[1];
            }
            else
            {
                DiemCanh[0] = DiemCanhTmp[1];
                DiemCanh[1] = DiemCanhTmp[0];
            }

            for (int i = 0; i < CvDuongbao.Length; i++)
            {
                po = CvDuongbao[i].IntersectNodes(CvCanh, IntersectTypes.InclAll);
                if (po.PointCount != 0)
                {
                    for (int j = 0; j < po.PointCount; j++)
                    {
                        DPoint[] PointCanh = new DPoint[2];
                        PointCanh[0] = po[j];
                        PointCanh[1] = DiemCanh[0];
                        cls.mpxDrawLine(pMap.Map, LayerName, "", PointCanh, cs, LayerName, staProcess);
                    }

                }
            }

        }
        //ve 1 rectang moi
        public System.Drawing.Rectangle NewBound(MapControl map, DRect drec, int buff, DPoint p)
        {
            int hei, wit, x, y;
            double MySize;
            hei = 0;
            wit = 0;

            //chieu dai tu tam den dinh HCN bao quanh
            MySize = System.Math.Sqrt((drec.x1 - p.x) * (drec.x1 - p.x) + (drec.y1 - p.y) * (drec.y1 - p.y));
            //tinh toa do dinh hinh cn moi
            double xa, ya;
            System.Drawing.Rectangle g = new System.Drawing.Rectangle();
            if ((drec.Width() == 0) || (drec.Height() == 0))
            {
                return g;
            }

            xa = buff * drec.Width() / 2 / MySize;
            ya = buff * drec.Height() / 2 / MySize;
            DRect newRec = new DRect();
            newRec.x1 = drec.x1 - xa;
            newRec.y1 = drec.y1 + ya;
            newRec.x2 = drec.x2 + xa;
            newRec.y2 = drec.y2 - ya;

            hei = System.Convert.ToInt32(System.Math.Round(newRec.Height(), 0));
            wit = System.Convert.ToInt32(System.Math.Round(newRec.Width(), 0));

            x = map.DisplayRectangle.X - System.Convert.ToInt32(System.Math.Round(xa, 0)) / 2;
            y = map.DisplayRectangle.Y - System.Convert.ToInt32(System.Math.Round(ya, 0)) / 2;
            g = new System.Drawing.Rectangle(x, y, wit, hei);
            return g;
        }
        //tao buffer theo hinh chu nhat
        public IResultSetFeatureCollection BuffHinhChuNhat(int buff, MapControl mapcontrol)
        {
            Table tabTmpBanDo = null;
            tabTmpBanDo = MapInfo.Engine.Session.Current.Catalog.GetTable("tmpBanDo"); ;
            //tinh chieu dai tu tam toi dinh xa nhat
            double MySize;
            DRect rect = new DRect();
            MySize = 0;
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection Lfc = Session.Current.Selections.DefaultSelection[tab];
            if ((Lfc == null) || (Lfc.Count == 0))
            {
                MessageBox.Show("Chọn đối tượng !!");
                return null;
            }
            DPoint Center = new DPoint();
            foreach (Feature f in Lfc)
            {
                //lay toa do tam va duong bao cua layer hient hoi
                Center = f.Geometry.Centroid;
                rect = f.Geometry.Bounds;
            }
            MySize = System.Math.Round(System.Math.Sqrt((rect.x1 - Center.x) * (rect.x1 - Center.x) + (rect.y1 - Center.y) * (rect.y1 - Center.y)), 3);
            double MaxValueX;
            double MaxValueY;
            // tinh toa do dinh hinh chu nhat bao quanh
            MaxValueX = rect.Width() / 2 + Math.Sqrt(2) * buff;
            MaxValueY = rect.Height() / 2 + Math.Sqrt(2) * buff;
            DPoint point = new DPoint();
            point.x = rect.x2 - MaxValueX;
            point.y = rect.y2 - MaxValueY;

            MapInfo.Geometry.Rectangle g = new MapInfo.Geometry.Rectangle(mapcontrol.Map.Layers[LayerName].Map.GetDisplayCoordSys(), point, MaxValueX, MaxValueY, DistanceUnit.Meter, DistanceType.Cartesian);
            MapInfo.Geometry.MultiPolygon poly = g.CreateMultiPolygon();
            MapInfo.Styles.AreaStyle rectStyle = new MapInfo.Styles.AreaStyle();
            MapInfo.Data.Feature fff = new MapInfo.Data.Feature(poly, rectStyle);
            tabTmpBanDo.InsertFeature(fff);
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tabTmpBanDo, MapInfo.Data.SearchInfoFactory.SearchAll());
            return irfc;
        }
        public void LayRa(int buff, MapControl mapcontrol)
        {

            IResultSetFeatureCollection irfc = BuffHinhChuNhat(buff, mapcontrol);
            if (irfc == null) { return; }
            Session.Current.Selections.DefaultSelection.Clear();
            Session.Current.Selections.DefaultSelection.Add(irfc);

            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            MapInfo.Mapping.FeatureLayer fl = new FeatureLayer(irfc.Table);
            mapcontrol.Map.Layers.Add(fl);
            MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
            MapInfo.Data.Feature f = null;
            f = featureProcessor.Intersect(irfc);
            table.InsertFeature(f);
        }

        public void XoaBuff()
        {
            conn = clsData.Connect();
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from " + strBang + "  where FeatureID =" + FeatureID.ToString().Split('.')[0] + " and madoituong='0'";
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion
        #region các hàm trả về thông số thửa đất
        //lay thogn tin ve chieu dai cua doi tuong duoc chon
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
                            MySize =System.Math.Round( pl.Length(DistanceUnit.Meter, DistanceType.Spherical ),2);
                            LineSize = LineSize + MySize;
                        }

                    }
                }catch(Exception ex ){}
            }
            return LineSize;

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
                            mySize = pl.Area(AreaUnit.SquareMeter , DistanceType.Spherical  );
                            areaSize = areaSize + mySize;
                            //lấy thông số về tỷ lệ bản đồ (tuỳ chỉnh cho phù hợp)
                            TyleBanDo = areaSize / 12; // 2 + areaSize / 10;
                           // dlDienTichThua = mySize;
                        }

                    }
                }catch(Exception ex ){}
            }
            return areaSize;
        }
        //lay thogn tin ve do zoom
        public void GetZoom(double times, MapControl map)
        {
            MapInfo.Geometry.Distance previousZoom = map.Map.Zoom;
            map.Map.Zoom = new MapInfo.Geometry.Distance(times, DistanceUnit.Meter);
        }
        #endregion
        #region Ghi xac nhan (luu vao trong csdl)
        //chấp nhận lưu những thay đổi
        private void mnuGhi_Click(object sender, System.EventArgs e)
        {
            SaveData();
        }
        //ham ghi nhung thay doi tren map
        public void SaveData() {
            GhiXacNhan(mapControl1);
        }
        //thuc thi viec ghi du lieu
        public void GhiXacNhan(MapControl map)
        {
            int i = 0;
        GhiLai:            
            Table tab = null;
            //láy đối tượng bảng hiện thời
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //chọn tất cả các đối tượng có trên Map
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());
            if ((irfc == null) || (irfc.Count == 0))
            {
                return;
            }
            //lay bảng 
            //mapControl1.Map.SetView(irfc);
            
            Table TableThuaDat = null;
            TableThuaDat = MapInfo.Engine.Session.Current.Catalog.GetTable("tmp");
            try
            {
                if (DoiTuongThuaGoc(mapControl1, LayerName)==false ) {
                    return;
                }
                //chuyen du lieu ban do vao CSDL
                staProcess.Value = 0;
                cls.DienTichThua = dlDienTichThua;
                cls.TyLeZoomView = dlTyLeZoomView;
                cls.ChapNhanGhi(mapControl1, strBang, lgMaHoSoCapGCN, Convert.ToInt64(FeatureID.ToString().Split('.')[0]), irfc, TableThuaDat, staProcess, LayerName, LayerName);
                //xoa ban ghi cu
                staProcess.Value = 0;
                staProcess.Maximum = 100;
                clsData.DelRecoreOld(strBang, lgMaHoSoCapGCN ,Connect());
                staProcess.Value = staProcess.Value + 33;
                //update fixzoom
                if (FixZoom == 0)
                {
                    FixZoom = TyleBanDo;
                }
                clsData.UpdateFixZoom(strBang, FixZoom, lgMaHoSoCapGCN );
                staProcess.Value = staProcess.Value + 33;
                //xac nhan ghi da thanh cong
                GhiPhanInHoSo(true );
                GhiPhanInHoSo(false );
                try
                {
                    LuuFileMap(FeatureID.ToString().Split('.')[0]);
                    byte[] TablFile = GhiFileMap(FeatureID.ToString().Split('.')[0], "tab");
                    byte[] MaplFile = GhiFileMap(FeatureID.ToString().Split('.')[0], "Map");
                    byte[] IDlFile = GhiFileMap(FeatureID.ToString().Split('.')[0], "ID");
                    byte[] DatlFile = GhiFileMap(FeatureID.ToString().Split('.')[0], "dat");
                    clsData.UpdateMapFile(1, lgMaHoSoCapGCN.ToString(), TablFile, MaplFile, IDlFile, DatlFile, mapControl1.Map.Center.x, mapControl1.Map.Center.y, Convert.ToDouble(mapControl1.Map.Zoom.Value));
                }
                catch (Exception ex) { }
                //ghi phan in danh sach toa do vao CSDL
                if (clsData.KtTonTaiDSToaDo(lgMaHoSoCapGCN.ToString()))
                {
                    if (MessageBox.Show("Bạn có muốn tiếp tục ghi lại danh sách tọa độ không ???",
                           "DMCLand",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        GhiDanhSachToaDo(conn);

                    }
                }
                else {
                    GhiDanhSachToaDo(conn);
                }

                //luu file tab vao csdl
                     //ghi xac nhan ghi thanh cong
                   clsData.GhiXacNhan(Convert.ToInt64(FeatureID.ToString().Split('.')[0]), lgMaHoSoCapGCN, strBang);
                   NhatKyNguoiDung("Soạn hồ sơ kỹ thuật", "Soạn hồ sơ kỹ thuật");
                //ghi vao phan in ho so
                ChangeFeature = true;
                staProcess.Value = staProcess.Value + 34;

            }
            catch (Exception ex)
            {
                System.Threading.Thread.Sleep(5000);
                clsData.DelRecoreTmp(strBang, lgMaHoSoCapGCN, Connect());
                i = i + 1;
                if (i == 3) {
                    if (MessageBox.Show("Lỗi không ghi được dữ liệu. Bạn có muốn tiếp tục ghi lại không ???",
                   "DMCLand",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        goto GhiLai;
                    }
                    else {
                        return;
                    }
                   }
                goto GhiLai;
                
            }
        }
        #endregion
        #region Xử lý text
        
        //ham thuc thi chen doi tuong text
        public void setChenText(MapControl Map, string Value, DRect rect, Table tab, TextStyle ts, double angle, string DoiTuong)
        {
            MapInfo.Geometry.LegacyText g = new MapInfo.Geometry.LegacyText(Map.Map.GetDisplayCoordSys(), rect, angle, Value);
            Feature tmp = new Feature(tab.TableInfo.Columns);
            tmp.Geometry = g;
            tmp.Style = ts;
            //tao moi doi tuong
            tab.InsertFeature(tmp);
            conn = clsData.Connect();
            clsData.UpdateFeature(strBang, DoiTuong, lgMaHoSoCapGCN, Convert.ToInt64(FeatureID.ToString().Split('.')[0]), Connect());
        }

        #endregion
        #region cac chuc nang tuong tac truc tiep toi mapcontrol
        private void mapControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //neu an nut S cua ban phim thi chuc nang snap se duoc thuc hien
            if (e.KeyChar == 's')
                mapControl1.Tools.MapToolProperties.SnapEnabled
                    = !mapControl1.Tools.MapToolProperties.SnapEnabled;
            mapControl1.Tools.MapToolProperties.SnapTolerance = 1;     
            
        }
        private void mapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            DPoint P = new DPoint();
            System.Drawing.PointF pointf = new System.Drawing.PointF();
            pointf.X = e.X;
            pointf.Y = e.Y;
            P = cls.ConvertDpoint(pointf, mapControl1);
            toolX.Text = P.x.ToString();
            toolY.Text = P.y.ToString();
            MousePointEnd = cls.ConvertDpoint(pointf, mapControl1);
            ToolBarSetup();
        }
        private void mapControl1_Click(object sender, EventArgs e)
        {

            //gan toa do vao dieu khien de tao nut
            txtToaDoX.Text = toolX.Text;
            txtToaDoY.Text = toolY.Text;
            txtToaDoXoayX.Text = toolX.Text;
            txtToaDoXoayY.Text = toolY.Text;
            txtTamOx.Text = toolX.ToString();
            txtTamOy.Text = toolY.ToString();
            txtViTriX.Text = toolX.ToString();
            txtViTriY.Text = toolY.ToString();
            DPoint DiemCuoi = new DPoint();
            DiemCuoi.x = Convert.ToDouble(toolX.Text);
            DiemCuoi.y = Convert.ToDouble(toolY.Text);
            DiemCuoiChonThua = DiemCuoi;
            if (DiChuyenDinhThua)
            {
                DPoint DiemDiChuyen=new DPoint() ;
                DiemDiChuyen.x=Convert.ToDouble( toolX.Text);
                DiemDiChuyen.y=Convert.ToDouble( toolY.Text);
                GanDiemTheoVung(mapControl1, LayerName, GanDinhVaoVung, DiemCuoi);
            }
        }
        //khi kich vao ban do
        private void mapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Table tab = null;
                //lay bang hien thoi
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                //lay lây tất cả đối tượng được chọn
                IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[tab];
                if (irfc == null)
                {
                    return;
                }
                if (irfc.Count == 0)
                {
                    return;
                }
                DPoint[] d = new DPoint[1];
               
                foreach (Feature f in irfc)
                {
                    //nếu đối tượng có kiểu MultiPolygon
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                    {
                        //Lấy toạ độ tâm thửa
                        DPointCenter = f.Geometry.Centroid;
                        d[0] = DPointCenter;

                       
                    }

                }
            }
        catch(Exception ex ){
            Console.Write(ex.Message);
        }
            
        }
        private void mapControl1_DoubleClick(object sender, EventArgs e)
        {
            System.Threading.ReaderWriterLock l = new System.Threading.ReaderWriterLock();
            l.AcquireWriterLock(System.Threading.Timeout.Infinite);


          

            if (mapControl1.Tools.LeftButtonTool == "Select")
            {
                //lop thua dat
                Table table = null;
                table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                //lấy tất cả các đối tượng được chọn
                IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
                if (irfc == null)
                {
                    return;
                }
                if (irfc.Count == 0)
                {
                    return;
                }
                try
                {
                    foreach (Feature f in irfc)
                    {
                        //Nếu đối tượng là rectang thì mở điều khiển thuộc tính nut
                       
                        if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Rectangle"))
                        {
                            OpenDlgArea(mapControl1, LayerName);
                        }
                        //Nếu đối tượng là elip thì mở điều khiển thuộc tính nut
                        if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Ellipse"))
                        {
                            OpenDlgArea(mapControl1, LayerName);
                        }
                       
                        //Nếu đối tượng là Point thì mở điều khiển thuộc tính nut
                        if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Point"))
                        {
                            OpenDlgNode(mapControl1, LayerName);
                        }
                        //Nếu đối tượng là MultiPolygon thì mở điều khiển thuộc tính vùng
                        if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                        {
                            OpenDlgArea(mapControl1, LayerName);
                        }
                        //Nếu đối tượng là legacytext thì mở bảng điều khiển thuộc tính text
                        if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                        {
                            ChangeText(strBang, mapControl1, LayerName);
                        }
                        //Nếu đối tượng là MultiCurve thì mở bảng điều khiển thuộc tính Line
                        if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                        {
                            OpenDlgLine(mapControl1, LayerName);
                        }
                        
                    }

                    //lop dat
                    Table tab = null;
                    //lay thong tin ve bảng của thửa đất
                    tab = MapInfo.Engine.Session.Current.Catalog.GetTable(TenLopDat);
                    //lấy tất cả các đối tượng được chọn
                    IResultSetFeatureCollection Lfc = Session.Current.Selections.DefaultSelection[tab];
                    if ((Lfc == null) || (Lfc.Count == 0))
                    {
                        return;
                    }
                    foreach (Feature f in Lfc)
                    {
                        //lay ma so cua thua dat  dc chon
                        MessageBox.Show(f.Key.Value);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                l.ReleaseWriterLock();
            }
        }
        //ham thay doi noi dung va dinh dang cua doi tuong text
        public void ChangeText(string tblBang, MapControl PMap, string LayerName)
        {
            //clsDatabase clsData = new clsDatabase { };
            try
            {
                DMC.Land.SoanHoSo.frmSetTextStyle frm = new DMC.Land.SoanHoSo.frmSetTextStyle();
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                IResultSetFeatureCollection fc = null;
                fc = MapInfo.Engine.Session.Current.Selections.DefaultSelection[tab];
                if (fc == null)
                {
                    return;
                }
                if (fc.Count == 0)
                {
                    return;
                }
                foreach (Feature f in fc)
                {

                    DPoint[] tmpP = new DPoint[2];
                    
                    //neu la doi tuong text
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                    {
                        //lay danh sach toa do diem bao quan doi tuong text
                        tmpP = f.Geometry.Bounds.DefiningPoints();
                        string DoiTuong;
                        //lấy mã đối tượng
                        DoiTuong = cls.GetMaDoiTuong(f, LayerName);
                        MapInfo.Geometry.LegacyText ftext = null;
                        ftext = (MapInfo.Geometry.LegacyText)f.Geometry;
                        //truyền tham số cho đối tượng form
                        frm.SetMapConT=PMap;
                        frm.SetObiText=ftext.Caption;
                        frm.SetFeature=f;
                        frm.SetDoiTuong=DoiTuong;
                        frm.SetTable=tab;
                        frm.SetTextStyle=(TextStyle)f.Style;
                        frm.TenBang = strBang;
                        frm.FeatureID = FeatureID;
                        frm.TyLeZoomThua = dlTyLeZoomView;
                        frm.DienTichThua = dlDienTichThua;
                        frm.CtrForm =this;
                        frm.ShowDialog();
                    }
                }
                
                PMap.Map.Invalidate();
                tab.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //ham thay doi noi dung va dinh dang cua doi tuong text
        public void ChangeTextAll(string tblBang, MapControl PMap, string LayerName)
        {
            try
            {
                //tao moi doi tuong form frmStyleText de thay doi thuoc tinh cua doi tuong text
                DMC.Land.SoanHoSo.frmStyleText frm = new DMC.Land.SoanHoSo.frmStyleText();
                //lay doi tuong bang chua cac doi tuong map
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                IResultSetFeatureCollection fc = null;
                //lay tap hop tat ca cac doi tuong duoc chon
                fc = MapInfo.Engine.Session.Current.Selections.DefaultSelection[tab];
                if (fc == null)
                {
                    return;
                }
                if (fc.Count == 0)
                {
                    return;
                }
                    frm.SetTable = tab;
                    frm.TenBang = strBang;
                    frm.FeatureID = FeatureID;
                    frm.SetMapConT = PMap;
                    frm.SetIrfc = fc;
                    frm.TyLeZoomThua = dlTyLeZoomView;
                    frm.DienTichThua = dlDienTichThua;
                    frm.CtrForm = this;
                    frm.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Các hàm về điểm
        public DPoint getPointCenter()
        {
            Table tab = null;
            DPoint Center = new DPoint();
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tất cả các đối tượng được chọ
            IResultSetFeatureCollection Lfc = Session.Current.Selections.DefaultSelection[tab];
            if ((Lfc == null) || (Lfc.Count == 0))
            {
                MessageBox.Show("Chọn đối tượng !!");
                return Center;
            }
            foreach (Feature f in Lfc)
            {
                //lay toa do tam va duong bao cua layer hient hoi
                Center = f.Geometry.Centroid;
            }
            return Center;
        }

        //lay danh sach doi tuong diem moi de ve duong bao
        public DPoint[] getPoint(MapControl mapcontrol, string Nhan)
        {
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            MapInfo.Data.Feature myfc = new Feature(table.TableInfo.Columns);
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc.Count != 1)
            {
                MessageBox.Show("Chọn đối tượng");
                return null;
            }
            foreach (Feature f in irfc)
            {
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                {
                    myfc = f;
                }
                else
                {
                    MessageBox.Show("Chọn đối tượng");
                    return null;
                }
            }
            FeatureLayer Lyr = mapcontrol.Map.Layers[LayerName] as FeatureLayer;
            DPoint[] d = null;
            if (Lyr != null)
            {
                MultiPolygon plg = (MultiPolygon)myfc.Geometry;
                foreach (Polygon pl in plg)
                {
                    d = pl.Exterior.SamplePoints();
                }
            }
            return d;
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
        //toa do diem chia khi biet duogn thang
        private MapInfo.Geometry.DPoint ToaDoDiemChia(MapInfo.Geometry.DPoint[] dPoint, double dblDistance)
        {
            MapInfo.Geometry.DPoint pointTemp;
            /* Nếu x1 = x2
             Khi đó phương trình đường thẳng sẽ là x = x1(x2)*/
            if (dPoint[0].x == dPoint[1].x)
            {
                pointTemp.x = dPoint[0].x;
                if (dPoint[0].y < dPoint[1].y)
                    pointTemp.y = dPoint[0].y + System.Math.Sqrt(dblDistance);
                else
                    pointTemp.y = dPoint[0].y - System.Math.Sqrt(dblDistance);
            }
            /* Nếu y1 = y2
             Khi đó phương trình đường thẳng sẽ là y = y1 (y2) */
            else if (dPoint[0].y == dPoint[1].y)
            {
                pointTemp.y = dPoint[0].y;
                if (dPoint[0].x < dPoint[1].y)
                    pointTemp.x = dPoint[0].x + System.Math.Sqrt(dblDistance);
                else
                    pointTemp.x = dPoint[0].x - System.Math.Sqrt(dblDistance);
            }
            /* Trường hợp X1 != X2 và Y1 != Y2 */
            /* Khi đó phương trình đường thẳng sẽ là (x - x1)/(x2 - x1) = (y - y1)/(y2 - y1) */
            else
            {
                double X1, Y1, X2, Y2;
                X1 = dPoint[0].x;
                Y1 = dPoint[0].y;
                X2 = dPoint[1].x;
                Y2 = dPoint[1].y;
                /* Trường hợp x1 < x2 thì tọa độ X của điểm chia sẽ được tính như sau:
                  */
                if (X1 < X2)
                    pointTemp.x = X1 + dblDistance / (System.Math.Sqrt(1 + ((Y2 - Y1) * (Y2 - Y1)) / ((X2 - X1) * (X2 - X1))));
                /* Trường hợp x1 < x2 thì tọa độ X của điểm chia sẽ được tính như sau:
                  */
                else
                    pointTemp.x = X1 - dblDistance / (System.Math.Sqrt(1 + ((Y2 - Y1) * (Y2 - Y1)) / ((X2 - X1) * (X2 - X1))));
                /* Tọa độ y của điểm chia */
                pointTemp.y = ((Y2 - Y1) * (pointTemp.x - X1)) / (X2 - X1) + Y1;
            }
            return pointTemp;
        }
        //ham goi chuc nang chon doi tuong diem khi hien thi danh sach toa do diem
        public void ChonNutDiem(int index)
        {
            for (int i = 0; i < grDanhSachToaDo.RowCount; i++)
            {
                if (index == i)
                {
                    grDanhSachToaDo.Rows[index].Cells[0].Value = true;
                }
                else
                {
                    grDanhSachToaDo.Rows[i].Cells[0].Value = false;
                }
            }
        }
        # endregion
        #region chức năng các điều khiển
        private void toolBuff_Click(object sender, EventArgs e)
        {
            panBuffer.Show();
            ShowLocation(panBuffer);
            // Buffer();
        }
        private void toolCboTyLe_TextChanged(object sender, EventArgs e)
        {
            toolTyLe.Text = toolCboTyLe.Text;
            double zoom;
            zoom = 0.1;
            if (toolTyLe.Text != "")
            {
                zoom = System.Convert.ToDouble(toolTyLe.Text);
            }
            GetZoom(zoom, mapControl1);
        }
        private void toolCanhRaNgoai_Click(object sender, EventArgs e)
        {
            cls.ChangeTextInOut(mapControl1, LayerName, 2, staProcess, false, TyleBanDo);
        }

        private void toolCanhVaoTrong_Click(object sender, EventArgs e)
        {
            cls.ChangeTextInOut(mapControl1, LayerName, 2, staProcess, true, TyleBanDo);
        }

        private void toolDinhRaNgoai_Click(object sender, EventArgs e)
        {
            cls.ChangeTextInOut(mapControl1, LayerName, 1, staProcess, false, TyleBanDo);
        }

        private void toolDinhVaoTrong_Click(object sender, EventArgs e)
        {
            cls.ChangeTextInOut(mapControl1, LayerName, 1, staProcess, true, TyleBanDo);
        }
        public void TaoDuongVuongGoc(string LayerName)
        {
            //lấy bảng hiện thời
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //Lấy tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count == 0)
            {
                return;
            }
            staProcess.Visible = true;
            staProcess.Maximum = irfc.Count;
            staProcess.Value = 0;
            foreach (Feature f in irfc)
            {
                //Nếu đối tượng được chọn là MultiCủve
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                {
                    //Tạo đường vuông góc rùi đưa vào map
                    //cls.TaoDuongVuongGoc(mapControl1, table, f);
                    staProcess.Value = staProcess.Value + 1;
                }
            }
            staProcess.Visible = false;
        }
        private void toolTaoDuongVuongGoc_Click(object sender, EventArgs e)
        {
            TaoDuong(false);
        }

        public void TangKichThuocCanh(String LayerName)
        {
            try
            {
                CompositeStyle cs = new CompositeStyle();
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                //Lấy tất cả các đối tượng được chọn
                IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[tab];
                if ((irfc == null) || (irfc.Count == 0))
                {
                    return;
                }
                DPoint[] d = new DPoint[2];
                staProcess.Visible = true;
                staProcess.Maximum = irfc.Count;
                staProcess.Value = 0;
                foreach (Feature f in irfc)
                {
                    //Nếu đối tượng được chọn là đối tượng Line
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                    {
                        foreach (Curve cv in (MapInfo.Geometry.MultiCurve)f.Geometry)
                        {
                            d = cv.SamplePoints();
                            double tyle;

                            if (d[0].x == d[1].x)
                            {
                                tyle = 0;
                            }
                            else
                            {
                                if (d[0].y == d[1].y)
                                {
                                    tyle = 1;
                                }
                                else
                                {
                                    tyle = (d[0].x - d[1].x) / (d[0].y - d[1].y);
                                }
                            }
                            d = cls.TangToaDoDiem(d, tyle, 2);
                            cs.ApplyStyle(f.Style);
                            cls.mpxDrawLine(mapControl1.Map, "", "", d, cs, LayerName, staProcess);
                            tab.DeleteFeature(f);
                            staProcess.Value = staProcess.Value + 1;
                        }

                    }

                }
                staProcess.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chọn đối tượng");
            }
        }
        //tang kich thuoc cua canh len
        private void toolTangKichThuocCanh_Click(object sender, EventArgs e)
        {
            TangKichThuocCanh(LayerName);
        }
       
        //giam kich thuoc cua canh len
        private void toolGiamKichThuocCanh_Click(object sender, EventArgs e)
        {
            cls.GiamKichThuocCanh(mapControl1, LayerName, staProcess);
        }
        //hien thi chuc nang them danh sach toa do
        private void toolThemDSToaDo_Click(object sender, EventArgs e)
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
        private void toolNhanThua_Click(object sender, EventArgs e)
        {
            ChonNhanThua(LayerName);
        }
        //tao duong thang song song voi 1 duong thang khac
        private void toolTaoDuongSongSong_Click(object sender, EventArgs e)
        {
            TaoDuong(true);
        }
        private void toolXoayDoiTuong_Click(object sender, EventArgs e)
        {
                panThemDiemLamGocXoay.Show();
                ShowLocation(panThemDiemLamGocXoay);
                panXoayDoiTuong.Hide();
        }
        private void toolChonNguocDoiTuong_Click(object sender, EventArgs e)
        {
            cls.ChonNguocDoiTuong(LayerName);
        }
        //khi nhan vao nut export ra anh thi se thuc hien chuc nang export anh
        private void toolExportMap_Click(object sender, EventArgs e)
        {
            // Export the map to a file
            using (MapExport mx = new MapExport(mapControl1.Map))
            {
                try
                {
                    mx.Format = ExportFormat.Gif;
                    string sfile;
                    sfile = @Application.StartupPath + "\\Export\\" + FeatureID.ToString().Split('.')[0] + ".wmf";
                    mx.Export(sfile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Khong tim thay thu muc chua file" + ex.Message);
                }
            }
        }
        //khi nhan vao chuc nang chuyen tu dang polygon sang dang polyline
        private void toolConvertPolyLine_Click(object sender, EventArgs e)
        {
            //goi ham convert
            ConverPolyLine(mapControl1, LayerName, staProcess);
        }
        private void toolConvertPolyvon_Click(object sender, EventArgs e)
        {
            //goi ham CombineFeatures
            cls.CombineFeatures(mapControl1, LayerName, staProcess);
        }
        private void toolDuongBao_Click(object sender, EventArgs e)
        {
            ChonDuongBao(LayerName);
            ////TaoDuongBao(mapControl1, TyleBanDo/2);
            //CompositeStyle cs = new CompositeStyle();
            //Table table = null;
            //table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            ////chọn tất cả các đối tượng được chọn
            //IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            //if (irfc == null)
            //{
            //    return;
            //}
            //if (irfc.Count == 0)
            //{
            //    return;
            //}
            //try
            //{
            //    Table ThuaDat = null;
            //    ThuaDat = MapInfo.Engine.Session.Current.Catalog.GetTable("Tmp");
            //    DPoint[] d = null;
            //    //DPoint[] dPhanGiac = null;
            //    foreach (Feature f in irfc)
            //    {
            //        if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
            //        {
            //            foreach (Polygon pl in (MultiPolygon)f.Geometry)
            //            {
            //                d = pl.Exterior.SamplePoints();
            //            }
            //        }
            //        cls.mpxDrawLine(mapControl1.Map, "", "", d, cs, LayerName, staProcess);
            //        //tao cac canh cua thua dat
            //        IResultSetFeatureCollection fcc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong =4"));
            //        Table tab = null;
            //        //lay cac duong song song voi cac canh cua thua dat
            //        tab = cls.TaoDuongSongSongDuongBao(f, mapControl1, ThuaDat, table, fcc, TyleBanDo / 100, staProcess, false,LayerName );
            //        //xoa cac vung bi chon
            //        MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            //        //lay tap hop cac canh song song cua canh cua thua
            //        IResultSetFeatureCollection fc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());
            //        MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(fc);
            //        //lay giao diem cac canh song song song do
            //        d = cls.LayGiaoDiem(mapControl1, f, fc, staProcess, false);
            //        //ve duong bao
            //        SimpleLineStyle ls = new SimpleLineStyle();
            //        ls.Pattern = 3;
            //        ls.Width = new LineWidth((double)2, LineWidthUnit.Pixel); ;
            //        cs.ApplyStyle(ls);
            //        cls.mpxDrawLine(mapControl1.Map, "", "", d, cs, LayerName, staProcess);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        //ham thuc hien chuc nang chuyen tu dang polygon sang dang polyline
        public void ConverPolyLine(MapControl pMap, string LayerName, ToolStripProgressBar staProcess)
        {
            cls.BreakFeatureCollectionInLayer(pMap.Map, LayerName, staProcess);
        }

        #endregion
        #region sự kiện click vào các nút
        //chap nhan them moi diem
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
                    ThemDiem(mapControl1, d, LayerName,"0");
                    ExportsFileTab();
                    //an panel
                    panDiem.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiểm tra dữ liệu nhập vào !!!" + ex.Message );
            }
        }
       
        //goi chuc nang nhap khoang cach khi tao duong song song voi duong thang cho truoc
        private void cmdChapNhanKhoangCach_Click(object sender, EventArgs e)
        {
            DMC.GIS.Common.clsMainSoanHoSo cls = new DMC.GIS.Common.clsMainSoanHoSo();
            double KhoangCach;
            bool DiemXoay = true;
            bool ChonNghiem = true;
            KhoangCach = 0.0;
            if (Convert.ToDouble(txtKhoangCach.Value) <= 0)
            {
                return;
            }
            else
            {
                KhoangCach = Convert.ToDouble(txtKhoangCach.Value);
            }

            if (radNghiemSognSong1.Checked)
            {
                ChonNghiem = true;
            }
            if (radNghiemSognSong2.Checked)
            {
                ChonNghiem = false;
            }
            if (radDiemCuoiVuongGoc.Checked)
            {
                DiemXoay = true;
            }
            if (radDiemCuoiVuongGoc.Checked)
            {
                DiemXoay = false;
            }

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
            cls.TaoDuongChucNang(mapControl1, LayerName, DuongChucNang, KhoangCach, DiemXoay, accep, ChonNghiem);
            ExportsFileTab();
            MyfrmSongSongVuongGoc.Close();
            //panKhoangCach.Show();

            //cls.TaoDuongChucNang(mapControl1, LayerName, DuongChucNang);//, KhoangCach, ChonNghiem, DuongChucNang, DiemXoay);
            //ẩn panel khoảng cách
            panKhoangCach.Hide();
        }
        //khi kich vao chuc nang dao vi tri dinh theo chieu kim dong ho
        private void cmdDaoTheoChieuKim_Click(object sender, EventArgs e)
        {
            //Table tab = null;
            ////goi bang hiện thời
            //tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            ////gọi hàm đảo vị trí các đỉnh 
            //cls.TyLeZoomView = dlTyLeZoomView;
            //cls.DienTichThua = dlDienTichThua;
            //cls.DaoThuTuDinhThua(mapControl1, tab, true,LayerName );
            //ExportsFileTab();
        }
        //khi kich vao chuc nang dao vi tri dinh nguoc chieu kim dong ho
        private void cmdDaoNguocChieuKim_Click(object sender, EventArgs e)
        {
            //Table tab = null;
            ////goi bang hiện thời
            //tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            ////gọi hàm đảo vị trí các đỉnh 
            //cls.TyLeZoomView = dlTyLeZoomView;
            //cls.DienTichThua = dlDienTichThua;
            //cls.DaoThuTuDinhThua(mapControl1, tab, false,LayerName );
            //ExportsFileTab();
        }
        //them danh sach toa do vao grid
        private void cmdThemDSToaDo_Click(object sender, EventArgs e)
        {
            if (txtX.Value == 0){
            return ;
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
        //chuyen danh sach toa do thanh duong
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

        

        //chuyen danh sach toa do thanh vung
        private void cmdTaoVungDSToaDo_Click(object sender, EventArgs e)
        {
            if (grdDanhSachToaDoThuc.RowCount >3 ){
                cls.TaoVungTuDSToaDo(mapControl1, LayerName, grdDanhSachToaDoThuc);
            ExportsFileTab();
            }
        }
        #endregion
        #region sao chep, dan

        public void Cut(string LayerName)
        {
            Table tab = null;
            //gọi lại bảng hiện thời
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //Lấy tập hợp các đối tượng và lưu vào đối tượng bộ đệm
            LuuBoDem = Session.Current.Selections.DefaultSelection[tab];
            //lấy tất cả các đối tượng đựoc chọn
            IResultSetFeatureCollection fc = Session.Current.Selections.DefaultSelection[tab];
            if (fc == null)
            {
                return;
            }
            if (fc.Count == 0)
            {
                return;
            }
            foreach (Feature f in fc)
            {
                //Lưu vào bộ đệm các đối tượng được chọn
                LuuBoDem.Add(f);
                //xoá các đối tượng được chọn
                tab.DeleteFeature(f);
            }
        }

        //chuc nang cat doi tuong dua vao bo dem 
        private void toolCut_Click(object sender, EventArgs e)
        {
            Cut(LayerName);
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
            DoiTuongCopy=new string [irfc.Count];
            //lưu vào đối tượng bộ đệm
            int i=0;
            foreach(Feature f in irfc){
                DoiTuongCopy[i] = f.Key.Value;
                i = i + 1;
            }

            //MapInfo.Data.IFeatureCollection ifc = irfc as IFeatureCollection;
            //LuuBoDem = ifc;
            // LuuBoDem.Add(ifc);
        }
        //chuc nang copy doi tuong
        private void toolCopyObject_Click(object sender, EventArgs e)
        {
            CopyOject(LayerName);
        }

        private void toolPasteObject_Click(object sender, EventArgs e)
        {
            //gọi hàm di chuyển đối tượng để dán vào vị trí được chọn
            if (DoiTuongCopy.Length > 0)
            {
                   cls.DienTichThua = dlDienTichThua;
                   cls.TyLeZoomView = dlTyLeZoomView;
                cls.MoveObj(mapControl1, DoiTuongCopy, LayerName, MousePointEnd);
            }
        }

        //copy dinh dang cua doi tuong
        private void toolCopyStyle_Click(object sender, EventArgs e)
        {
            cls.CopyDinhDang(mapControl1 ,CopyStyle, LayerName);
        }
        //chuc nang dan dinh dang cua doi tuong
        private void toolPasteStyle_Click(object sender, EventArgs e)
        {
            cls.DanDinhDang(strBang, mapControl1, Convert.ToInt64(FeatureID.ToString().Split('.')[0]), CopyStyle, LayerName, dlDienTichThua, dlTyLeZoomView);
        }
        #endregion
        #region xu ly cho phan an hien panel
        //KHONG THEM MOI DIEM
        private void cmdHuy_Click(object sender, EventArgs e)
        {
            panDiem.Hide();
        }
        private void toolThemDiemToaDo_Click(object sender, EventArgs e)
        {
            labTileThemDiem.Text = "THÊM ĐIỂM";
            panDiem.Show();
            ShowLocation(panDiem);
        }

        private void cmdChapNhanToaDo_Click(object sender, EventArgs e)
        {
            cls.AnPanToaDo(panToaDo, LayerName);
        }
        private void cmdClosePanToaDo_Click(object sender, EventArgs e)
        {
            cls.AnPanToaDo(panToaDo, LayerName);
        }
        private void cmdCloseThemDSToaDo_Click(object sender, EventArgs e)
        {
            panThemDanhSachToaDo.Hide();
        }
        private void cmdThoatDSToaDo_Click(object sender, EventArgs e)
        {
            panThemDanhSachToaDo.Hide();
        }
        private void cmdClosePanDaoDiem_Click(object sender, EventArgs e)
        {
            panDaoDiem.Hide();
        }
       
        private void toolDaoDiem_Click(object sender, EventArgs e)
        {
            panDaoDiem.Show();
            ShowLocation(panDaoDiem);
        }
      
        private void cmdCloseDiem_Click(object sender, EventArgs e)
        {
            panDiem.Hide();
        }
        private void cmdCloseToaDo_Click(object sender, EventArgs e)
        {
            panDanhSachToaDo.Hide();
        }
        private void cmdCloseKhoangCach_Click(object sender, EventArgs e)
        {
            panKhoangCach.Hide();
        }
        private void cmdChapNhanXemIn_Click(object sender, EventArgs e)
        {
            panXemIn.Hide();
        }
        private void toolXemTruocKhiIn_Click(object sender, EventArgs e)
        {
            //LoadXemTruocKhiIn(mapControl1, staProcess);
            panXemIn.Show();
            ShowLocation(panXemIn);
        }
        private void cmdBoQuaDSToaDo_Click(object sender, EventArgs e)
        {
            panDanhSachToaDo.Hide();
        }
        private void toolDSToaDo_Click(object sender, EventArgs e)
        {
            //panDanhSachToaDo.Show();
            panToaDo.Show();
            ShowLocation(panToaDo);
        }
        private void cmdHuyBuff_Click(object sender, EventArgs e)
        {
            panBuffer.Hide();
        }
        private void cmdClosepanXoayDoiTuong_Click(object sender, EventArgs e)
        {
            panXoayDoiTuong.Hide();
            Table table = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection myfcDiemXoay = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong=101"));
            if (myfcDiemXoay==null ){
                return;
            }
            if (myfcDiemXoay.Count  == 0)
            {
                return;
            }
            foreach (Feature f in myfcDiemXoay) {
                table.DeleteFeature(f);
            }
        }
        private void cmdCloseThemDIemLamGocQuay_Click(object sender, EventArgs e)
        {
            panThemDiemLamGocXoay.Hide();
        }

        private void cmdBoQuaThemDiemlamGocXoay_Click(object sender, EventArgs e)
        {
            panThemDiemLamGocXoay.Hide();
        }
        #endregion
        #region xu ly cho phan panel cua phan soan ho so
        private void panXoayDoiTuong_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panXoayDoiTuong, e);
        }

        private void panXoayDoiTuong_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panXoayDoiTuong, e);
        }

        private void mnupanXoayDoiTuong_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panXoayDoiTuong, e);
        }

        private void mnupanXoayDoiTuong_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panXoayDoiTuong, e);
        }
        private void panToaDo_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panToaDo, e);
        }

        private void panToaDo_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panToaDo, e);
        }
        private void panMenuPanToanDo_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panToaDo, e);
        }

        private void panMenuPanToanDo_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panToaDo, e);
        }
        //lay vi tri chuot truoc khi di chuyen danh sach toa do
        private void panDanhSachToaDo_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panDanhSachToaDo, e);
        }
        //di chuyen danh sach toa do
        private void panDanhSachToaDo_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panDanhSachToaDo, e);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panDiem, e);
        }
        //hien thi dieu khien them moi diem
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panDiem, e);
        }
        private void panKhoangCach_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panKhoangCach, e);
        }

        private void panKhoangCach_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panKhoangCach, e);
        }
        private void panXemIn_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panXemIn, e);
        }

        private void panXemIn_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panXemIn, e);
        }
        private void panMnuKhoangCach_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panKhoangCach, e);
        }
       

        private void panMnuKhoangCach_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panKhoangCach, e);
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panDanhSachToaDo, e);
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panDanhSachToaDo, e);
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panDiem, e);
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panDiem, e);
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panXemIn, e);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panDaoDiem, e);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panDaoDiem, e);
        }

        private void panDaoDiem_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panDaoDiem, e);
        }

        private void panDaoDiem_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panDaoDiem, e);
        }
        private void panelDSToaDo_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panThemDanhSachToaDo, e);
        }

        private void panelDSToaDo_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panThemDanhSachToaDo, e);
        }

        private void panThemDanhSachToaDo_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panThemDanhSachToaDo, e);
        }

        private void panThemDanhSachToaDo_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panThemDanhSachToaDo, e);
        }
        private void panBuffer_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panBuffer, e);
        }

        private void panBuffer_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panBuffer, e);
        }

        private void panBufferMenu_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panBuffer, e);
        }

        private void panBufferMenu_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panBuffer, e);
        }
        private void panThemDiemLamGocXoay_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panThemDiemLamGocXoay, e);
        }

        private void panThemDiemLamGocXoay_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panThemDiemLamGocXoay, e);
        }

        private void panMnuThemDiemLamGocXoay_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panThemDiemLamGocXoay, e);
        }

        private void panMnuThemDiemLamGocXoay_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panThemDiemLamGocXoay, e);
        }
        private void panKhoangCachChia_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panKhoangCachChia, e);
        }

        private void panMnuKhoangCachChia_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panKhoangCachChia, e);
        }

        private void panKhoangCachChia_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panKhoangCachChia, e);
        }

        private void panMnuKhoangCachChia_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panKhoangCachChia, e);
        }
        #endregion
        #region goi den cac nut tren thanh cong cu
        private void toolRefesh_Click(object sender, EventArgs e)
        {
            RefreshMap(mapControl1, LayerName);
        }
        public void RefreshMap(MapControl pMap, string LayerName){
         Table tab = null;
        tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
        pMap.Map.Invalidate();
        tab.Refresh();
      }
        private void toolSoanHoSo_Click(object sender, EventArgs e)
        {
            SoanHoSo(mapControl1);
        }
        //private void toolChenText_Click(object sender, EventArgs e)
        //{
        //    ChenText(mapControl1 ,LayerName);
        //}
        private void toolNhanCanh_Click(object sender, EventArgs e)
        {
            ChonNhanCanh(LayerName);
        }
        private void toolNhanDinh_Click_1(object sender, EventArgs e)
        {
            ChonNhanDinh();
        }
        private void toolNut_Click(object sender, EventArgs e)
        {
            ChonNhanNode(LayerName);
        }
        //private void toolBuffer_Click(object sender, EventArgs e)
        //{
        //    //panBuffer.Show();
        //    //ShowLocation(panBuffer);
        //    //Buffer();
        //}
        private void toolXacNhan_Click(object sender, EventArgs e)
        {
            //PanProcess.Show();
            staProcess.Visible = true;
            GhiXacNhan(mapControl1);
            //PanProcess.Hide();
            staProcess.Visible = false;
        }
        private void toolNode_Click(object sender, EventArgs e)
        {
            OpenDlgNode(mapControl1, LayerName);
        }
        private void toolCanh_Click(object sender, EventArgs e)
        {
            OpenDlgLine(mapControl1, LayerName);
        }
        private void toolText_Click(object sender, EventArgs e)
        {
            ChangeTextAll(strBang, mapControl1, LayerName);
            RefreshMap(mapControl1, LayerName);
            //OpenDlgText(mapControl1, LayerName);
        }
        private void toolVung_Click(object sender, EventArgs e)
        {
            OpenDlgArea(mapControl1, LayerName);
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            panelLeft.Hide();
        }
        private void toolCat_Click(object sender, EventArgs e)
        {
            Cut(LayerName);
        }

        private void toolChep_Click(object sender, EventArgs e)
        {
            //CopyOject(LayerName);
        }

        private void toolPaste_Click(object sender, EventArgs e)
        {
            //gọi hàm di chuyển đối tượng để dán vào vị trí được chọn
            //cls.MoveObj(mapControl1, LuuBoDem, LayerName, MousePointEnd);
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
        public void ShowLocation(System.Windows.Forms.Panel Mypanel)
        {
           
            Mypanel.Location = new System.Drawing.Point((SizeMapWidth - Convert.ToInt32(Mypanel.Width / 2)), SizeMapHeigt - Mypanel.Height / 2);
            Mypanel.BringToFront();
           // Mypanel.Location.Y = SizeMapHeigt - Mypanel.Height / 2;
        }
        public void TaoDuong(bool ChonDuong) {
            DMC.GIS.Common.clsMainSoanHoSo cls = new DMC.GIS.Common.clsMainSoanHoSo(); ;
            double KhoangCach;
            bool DiemXoay;
            bool ChonNghiem;
            bool accep;
            KhoangCach = 0.0;
            //DMC.Land.SoanHoSo.frmSongSongVuongGoc
            DMC.Land.SoanHoSo.frmSongSongVuongGoc MyfrmSongSongVuongGoc = new DMC.Land.SoanHoSo.frmSongSongVuongGoc();
            MyfrmSongSongVuongGoc.ChucNang(ChonDuong);
            MyfrmSongSongVuongGoc.ShowDialog();
            accep = MyfrmSongSongVuongGoc.accep();
            ChonNghiem = MyfrmSongSongVuongGoc.ChonDuong();
            DiemXoay = MyfrmSongSongVuongGoc.ChonDiem();
            KhoangCach = MyfrmSongSongVuongGoc.KhoangCach();
            cls.TaoDuongChucNang(mapControl1, LayerName, ChonDuong, KhoangCach, DiemXoay, accep, ChonNghiem);
            MyfrmSongSongVuongGoc.Close();
        }

        private void toolDuongSongSong_Click(object sender, EventArgs e)
        {
            TaoDuong(true);
            //panKhoangCach.Show();
            //txtKhoangCach.Focus();
        }

        private void toolDuongVuongGoc_Click(object sender, EventArgs e)
        {
            TaoDuong(false);
        }

        private void toolTangCanh_Click(object sender, EventArgs e)
        {
            TangKichThuocCanh(LayerName);
        }

        private void toolGiamCanh_Click(object sender, EventArgs e)
        {
            cls.GiamKichThuocCanh(mapControl1, LayerName,staProcess);
        }

        private void toolChonNguoc_Click(object sender, EventArgs e)
        {
            cls.ChonNguocDoiTuong(LayerName);
        }

        private void toolDaoViTriDiem_Click(object sender, EventArgs e)
        {
            panDaoDiem.Show();
            ShowLocation(panDaoDiem);

        }

        private void toolConVertLine_Click(object sender, EventArgs e)
        {
            //goi ham convert
            ConverPolyLine(mapControl1, LayerName, staProcess);
            ExportsFileTab();
            mapControl1.Map.Invalidate();
        }

        private void toolConverPolygon_Click(object sender, EventArgs e)
        {
            //goi ham CombineFeatures
            cls.CombineFeatures(mapControl1 , LayerName, staProcess);
            ExportsFileTab(); 
            mapControl1.Map.Invalidate();
        }

        private void toolSDSToaDo_Click(object sender, EventArgs e)
        {
            //panDanhSachToaDo.Show();
            //panToaDo.Show();
            panToaDo.Show();
            ShowLocation(panToaDo);
        }

        private void toolXemTruocIn_Click(object sender, EventArgs e)
        {
            //LoadXemTruocKhiIn(mapControl1, staProcess);
           // panXemIn.Show();
            ////panXemIn.Show();
            ////ShowLocation(panXemIn);
            //hien thi Map hient hoi

            //lop dat
            try
            {
                Table tab = null;
                //lay thong tin ve bảng của thửa đất
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                FeatureLayer fl = new FeatureLayer(tab);
                //mapXemIn.Map.Layers.Clear();
                mapXemIn.Map.Layers.Add(fl);
                mapXemIn.Map.SetView(fl);//mapXemIn.Map.Zoom.Value
                mapXemIn.Map.Zoom = new MapInfo.Geometry.Distance(dlTyLeZoomView, DistanceUnit.Meter);
                strZoom100 = System.Convert.ToDouble(string.Format("{0:E2}", mapXemIn.Map.Zoom.Value));
                cboTyLeIn.Text = mapXemIn.Map.Zoom.Value.ToString();
                numTyLePhanTram.Text = Convert.ToString(100);
                panXemInMap.Show();
                ShowLocation(panXemInMap);
            }catch(Exception ex){}
        }
        private void toolSoanHoSo_Click_1(object sender, EventArgs e)
        {
            SoanHoSo(mapControl1);
        }
        private void toolCopyDoiTuong_Click(object sender, EventArgs e)
        {
            CopyOject(LayerName);
        }

        private void toolCopyDinhDanh_Click(object sender, EventArgs e)
        {
            cls.CopyDinhDang(mapControl1 ,CopyStyle, LayerName);
        }

        private void toolPasteDoiTuong_Click(object sender, EventArgs e)
        {
            //gọi hàm di chuyển đối tượng để dán vào vị trí được chọn
            
            if (DoiTuongCopy.Length > 0)
            {
                cls.DienTichThua = dlDienTichThua;
                cls.TyLeZoomView = dlTyLeZoomView;
                cls.MoveObj(mapControl1, DoiTuongCopy, LayerName, MousePointEnd);
            }
        }
        
        private void toolPasteDinhDang_Click(object sender, EventArgs e)
        {
            cls.DanDinhDang(strBang, mapControl1, Convert.ToInt64(FeatureID.ToString().Split('.')[0]), CopyStyle, LayerName, dlDienTichThua, dlTyLeZoomView);
            ExportsFileTab();
        }
        private void toolDSLopBanDo_Click(object sender, EventArgs e)
        {
            cls.LopBanDo(mapControl1, LayerName, LopNha, BanDo,TenLopDat ,TenLopNha );
            LoadMapView(mapControlView,TenLopDat);
            panelLeft.Show();
        }

        public void LoadMapView(MapControl pMap, string CurentLayerName)
        {
      
            try
            {
                Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(CurentLayerName);
                FeatureLayer fl = new FeatureLayer(table);
                IResultSetFeatureCollection fcc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("SW_member =" + FeatureID.ToString().Split('.')[0] + ""));
                mapControlView.Map.Layers.Add(fl);
                mapControlView.Map.SetView(fcc.Envelope);
            }catch(Exception ex ){}
        }
        #endregion
        #region cac ham temp

        public DPoint[] DiemTaoDuongBao(IResultSetFeatureCollection irfc)
        {
            MultiCurve[] cv = new MultiCurve[irfc.Count];
            int i;
            i = 0;
            // foreach (Feature f in irfc)
            // {
            DPoint[] d = new DPoint[irfc.Count + 1];
            for (i = 0; i < irfc.Count; i = i + 2)
            {
                if (irfc[i].Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                {
                    cv[i] = (MapInfo.Geometry.MultiCurve)irfc[i].Geometry;
                    foreach (Curve c in cv[i])
                    {
                        d[i] = c.StartPoint;
                        d[i + 1] = c.EndPoint;
                        if (i == irfc.Count - 2)
                        {
                            d[i + 2] = c.EndPoint;
                        }
                    }
                }
            }
            return d;
        }
        public double BanKinhDuongTrongTamGiac(DPoint p1, DPoint p2, DPoint p3)
        {
            double r;
            double a, b, c;
            a = System.Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y));
            b = System.Math.Sqrt((p1.x - p3.x) * (p1.x - p3.x) + (p1.y - p3.y) * (p1.y - p3.y));
            c = System.Math.Sqrt((p3.x - p2.x) * (p3.x - p2.x) + (p3.y - p2.y) * (p3.y - p2.y));

            r = (a * b * c) / (a * b + b * c + c * a);
            return r;
        }
        //xac dinh giao diem cua 2 duogn thang(chua ra (^_^))
        public DPoint GiaoDiem2DuongThang(MultiCurve mc1, MultiCurve mc2)
        {
            DPoint d = new DPoint();
            DPoint[] PC1 = new DPoint[2];
            DPoint[] PC2 = new DPoint[2];
            foreach (Curve c1 in mc1)
            {
                foreach (Curve c2 in mc2)
                {


                    PC1 = c1.SamplePoints();
                    PC2 = c2.SamplePoints();

                    double a1, a2, b1, b2;

                    a1 = Math.Abs((PC1[0].y - PC1[1].y) / (PC1[0].x - PC1[1].x));
                    b1 = Math.Abs((PC1[0].x * PC1[1].y - PC1[0].y * PC1[1].x) / (PC1[0].x - PC1[1].x));
                    a2 = Math.Abs((PC2[0].y - PC2[1].y) / (PC2[0].x - PC2[1].x));
                    b2 = Math.Abs((PC2[0].x * PC2[1].y - PC2[0].y * PC2[1].x) / (PC2[0].x - PC2[1].x));
                    d.x = (b1 - b2) / (a1 - a2);
                    d.y = (a1 * (b1 - b2) + b1 * (a1 - a2)) / (a1 - a2);
                }
            }
            return d;
        }

        #endregion

        private void cmdChapNhanBuff_Click(object sender, EventArgs e)
        {
            Table table = null;
            Table ThuaDat = null;
            Table BanDoTmp = null;
            Table BanDo = null;
            DPoint TamThua = new DPoint();
            TamThua = cls.GetTamThua(mapControl1, LayerName);
            //khai bao doi tuong Pointf la tam cua ban do theo poxel
            System.Drawing.PointF pointTamThua = new System.Drawing.PointF();
            pointTamThua = cls.ConvertPoinF(TamThua, mapControl1);
            //gọi bảng thửa đất
            ThuaDat = MapInfo.Engine.Session.Current.Catalog.GetTable("Tmp");
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            CompositeStyle cs = new CompositeStyle();

            //--------------------------------------------------------------------------------------------------------------
            //tao khung duong buff bao quanh thua dat
            TaoKhungDuongBuffer(mapControl1, ThuaDat, table, LayerName, staProcess, System.Convert.ToInt32(txtBuff.Text));
            //lay tat ca cac gia tri line cua khung vua tao
            IResultSetFeatureCollection fcc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong =4"));
            if (fcc == null)
            {
                return;
            }
            //khoi tao 1 mang chua cac canh cua khung vua tao
            MultiCurve[] mCuverCanhDuongbao = new MultiCurve[fcc.Count];
            for (int i = 0; i < fcc.Count; i++)
            {
                mCuverCanhDuongbao[i] = (MultiCurve)fcc[i].Geometry;
            }

            //--------------------------------------------------------------------------------------------------------------
            //Tao 1 doi tuong polygon de kiem tra
            Table dKhungBao = null;
            if (MapInfo.Engine.Session.Current.Catalog.GetTable("KhungBao") != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable("KhungBao");
            }
            dKhungBao = cls.CreateTable(mapControl1.Map, ThuaDat, "KhungBao");
            cs = new CompositeStyle();
            foreach (Feature f in fcc)
            {
                cls.UpdateDoiTuong(dKhungBao, f.Geometry, "0", cs,"");
            }
            FeatureLayer feaLayerKhungBao = new FeatureLayer(dKhungBao);
            mapControl1.Map.Layers.Add(feaLayerKhungBao);
            MapInfo.Data.IResultSetFeatureCollection irfcKhungBao = Session.Current.Catalog.Search(dKhungBao, MapInfo.Data.SearchInfoFactory.SearchAll());
            cls.SelectFeatureCollection(irfcKhungBao);
            Feature feaKhungBao = cls.FeatureCombine(mapControl1.Map, dKhungBao.Alias, staProcess);


            //--------------------------------------------------------------------------------------------------------------
            //mo du lieu cua ban do thua dat
            string str;
            str = "Select * from  " + BanDo ;
            if (MapInfo.Engine.Session.Current.Catalog.GetTable("BanDoBuffTmp") != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable("BanDoBuffTmp");

            }
            BanDoTmp = cls.GetNewLayer("BanDoBuffTmp", strConnectionstring, str);
            //--------------------------------------------------------------------------------------------------------------
            //tao moi ban do tam
            if (MapInfo.Engine.Session.Current.Catalog.GetTable("BanDoBuff") != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable("BanDoBuff");
            }
            BanDo = cls.CreateTable(mapControl1.Map, ThuaDat, "BanDoBuff");
            //lay cac doi tuong tron vong ban kinh  500m
            FeatureLayer feaLayer = new FeatureLayer(BanDoTmp);
            mapControl1.Map.Layers.Add(feaLayer);
            //--------------------------------------------------------------------------------------------------------------
            IResultSetFeatureCollection fLineBanDo = MapInfo.Engine.Session.Current.Catalog.Search(BanDoTmp, MapInfo.Mapping.SearchInfoFactory.SearchWithinScreenRadius(feaLayer, pointTamThua, 1000, 100, ContainsType.Geometry));
            //MapInfo.Data.IFeatureCollection fLineBanDo = Session.Current.Catalog.Search(BanDoTmp, MapInfo.Data.SearchInfoFactory.SearchAll());
            //tao mot Layer tam tren ban do
            cs = new CompositeStyle();

            //BanDo.InsertFeatures(fLineBanDo);

            foreach (Feature f in fLineBanDo)
            {
                cs.ApplyStyle(f.Style);
                cls.UpdateDoiTuong(BanDo, f.Geometry, "0", cs,"");
            }
            mapControl1.Map.Layers.Remove("BanDoBuffTmp");
            FeatureLayer fBanDo = new FeatureLayer(BanDo);
            mapControl1.Map.Layers.Add(fBanDo);
            //lay tat ca cac doi tuong cua bang vua chon
            MapInfo.Data.IResultSetFeatureCollection irfcBanDo = Session.Current.Catalog.Search(BanDo, MapInfo.Data.SearchInfoFactory.SearchAll());
            cls.SelectFeatureCollection(irfcBanDo);
            //--------------------------------------------------------------------------------------------------------------
            //breah thanh cac duogn line
            ConverPolyLine(mapControl1, "BanDoBuff", staProcess);
            //lay tat ca cac doi tuong cua bang ban do da duoc tao thanh cac duong Line
            MapInfo.Data.IResultSetFeatureCollection irfcBanDoLine = Session.Current.Catalog.Search(BanDo, MapInfo.Data.SearchInfoFactory.SearchAll());
            cls.SelectFeatureCollection(irfcBanDoLine);

            //lay ra mang doi tuong canh duoc chon
            MultiCurve[] DoiTuongLineBanDo = new MultiCurve[irfcBanDoLine.Count];
            int k = 0;
            foreach (Feature f in irfcBanDoLine)
            {
                DoiTuongLineBanDo[k] = (MultiCurve)f.Geometry;
                k = k + 1;
            }
            
            //--------------------------------------------------------------------------------------------------------------

            //insert Khung ban do vao de kiem tra
            // BanDo.InsertFeature(feaKhungBao);
            //xoa tat cac cac canh ko nam trong khung bao
            foreach (Feature f in irfcBanDoLine)
            {
                if (!feaKhungBao.Geometry.Contains(f.Geometry))
                {
                    BanDo.DeleteFeature(f);
                }
                else
                {
                    table.InsertFeature(f);
                }
            }
            //--------------------------------------------------------------------------------------------------------------
            //tao moi cac duong thang la giao diem cua duong bao quanh voi cac duong cua ban do
            for (int i = 0; i < DoiTuongLineBanDo.Length; i++)
            {
                GiaoDiemBuffVabanDo(mapControl1, table, feaKhungBao, DoiTuongLineBanDo[i], mCuverCanhDuongbao, LayerName, staProcess);
            }
            foreach (Feature f in fcc)
            {
                table.DeleteFeature(f);
                //}
            }
            //dong bang KHung bao Lai
            MapInfo.Engine.Session.Current.Catalog.CloseTable("BanDoBuff");
            MapInfo.Engine.Session.Current.Catalog.CloseTable("KhungBao");
            panBuffer.Hide();
        }
      
        public bool ChonKieu()
        {
            bool Kieu = true;
            if (radDuongBao.Checked)
            {
                Kieu = false;
            }
            if (radKhung.Checked)
            {
                Kieu = true;
            }
            return Kieu;
        }
        public bool Ktra()
        {
            char[] ar = txtBuff.Text.ToCharArray();
            bool kt;
            kt = true;
            for (int i = 0; i <= ar.Length - 1; i++)
            {
                if (!System.Char.IsNumber(ar[i]))
                {
                    kt = false;
                    MessageBox.Show("Buffer phải là số nguyên !!");
                    return kt;
                }
            }
            return kt;
        }

        //neu chap nhan goc xoay cua doi tuong can xoay
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
             if (gocXoay <= 0) {
                 return;
             }
           
            try {
               cls.XoayDoiTuong(mapControl1, LayerName,ChieuQuay,gocXoay);
               ExportsFileTab();
            }
                  catch(Exception ex ){
                }
            }



        private void mapControl1_KeyUp(object sender, KeyEventArgs e)
        {
             if ((mapControl1.Tools.LeftButtonTool == "Pan") || (mapControl1.Tools.LeftButtonTool == "ZoomIn")||(mapControl1.Tools.LeftButtonTool == "ZoomOut")){
              mapControl1.Tools.LeftButtonTool = OldKey;
              mapControl1.Refresh();
            }
        }

        private void mapControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //neu an ban phim dau cach thi chuc nang pan duoc goi den
            if ((e.KeyData == (Keys.Space)))
            {
                if (mapControl1.Tools.LeftButtonTool != "AddText"){
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
            if ((e.KeyData == (Keys.Delete)))
            {
                if (toolEditThuaDat.CheckState == CheckState.Checked)
                {
                    cls.DelSelect(mapControl1, LayerName,false );
                }
                else
                {
                    cls.DelSelect(mapControl1, LayerName,true  );
                }
            }
            //lay cac dieu khien tren thanh cong cu chuan
            //an to hop phim Ctr va phim ==>
            //"dau cach" thi chuc nang select duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Space)))
            {
                mapControl1.Tools.LeftButtonTool = "Select";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton6, OldKey);
            }
            //"Q" thi chuc nang Them duong tron duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Q)))
            {
                mapControl1.Tools.LeftButtonTool = "AddCircle";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton16 , OldKey);
            }
            //"E" thi chuc nang "Them doi tuong Elip" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.E)))
            {
                mapControl1.Tools.LeftButtonTool = "AddEllipse";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton17 , OldKey);
            }
            //"L" thi chuc nang "Them doi tuong Duong thang" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.L)))
            {
                mapControl1.Tools.LeftButtonTool = "AddLine";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton13, OldKey);
            }
            //"P" thi chuc nang "Them doi tuong diem" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.P)))
            {
                mapControl1.Tools.LeftButtonTool = "AddPoint";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton12, OldKey);
            }
            ////"W" thi chuc nang "Them Doi tuong Polygon" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.W)))
            {
                mapControl1.Tools.LeftButtonTool = "AddPolygon";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton18, OldKey);
            }
            //"Y" thi chuc nang "them Doi tuong polyline" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Y)))
            {
                mapControl1.Tools.LeftButtonTool = "AddPolyline";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton14, OldKey);
            }
            //"R" thi chuc nang "them doi tuong hinh chu nhat" duoc thuc thi
            if ((e.KeyData == (Keys.Control |Keys.R)))
            {
                mapControl1.Tools.LeftButtonTool = "AddRectangle";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton15 , OldKey);
            }
            //"T" thi chuc nang "them doi tuong text" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.T)))
            {
                mapControl1.Tools.LeftButtonTool = "AddText";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton11, OldKey);
            }
            //An to hop phim ctr + shift voi  ==>
            //"P" thi chuc nang "Chon theo Doi tuong Polygon" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Shift | Keys.P)))
            {
                mapControl1.Tools.LeftButtonTool = "SelectPolygon";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton9, OldKey);
            }
            //"R" thi chuc nang "Chon theo Doi tuong Radius" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Shift | Keys.R)))
            {
                mapControl1.Tools.LeftButtonTool = "SelectRadius";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton8, OldKey);
            }
            //"T" thi chuc nang "Chon theo Doi tuong Rect" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Shift | Keys.T)))
            {
                mapControl1.Tools.LeftButtonTool = "SelectRect";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton7, OldKey);
            }
            //"G" thi chuc nang "Chon theo Doi tuong Region" duoc thuc thi
            if ((e.KeyData == (Keys.Control | Keys.Shift | Keys.G)))
            {
                mapControl1.Tools.LeftButtonTool = "SelectRegion";
                cls.ExecutePushMapTool(mapToolBar1, mapToolBarButton10, OldKey);
            }
            //an to hop phim Ctr + C thi chuc nang copy duoc thuc thi
            if ((e.KeyData == (Keys.Control |  Keys.C)))
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
                cls.DanDinhDang(strBang, mapControl1, Convert.ToInt64(FeatureID.ToString().Split('.')[0]), CopyStyle, LayerName, dlDienTichThua, dlTyLeZoomView);
                ExportsFileTab();
            }
            if ((e.KeyData == (Keys.Alt | Keys.Q)))
            {
                TaoDuong(true);
            }
            if ((e.KeyData == (Keys.Alt | Keys.W)))
            {
                TaoDuong(false);
            }
            if ((e.KeyData == (Keys.Control | Keys.I)))
            {
                cls.ChonNguocDoiTuong(LayerName);
            }
            if ((e.KeyData == (Keys.Alt | Keys.I)))
            {
                panDaoDiem.Show();
                ShowLocation(panDaoDiem);
            }
            if ((e.KeyData == (Keys.Alt | Keys.V)))
            {
                cls.CombineFeatures(mapControl1 , LayerName, staProcess);
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
            if ((e.KeyData == (Keys.Alt | Keys.M)))
            {
                BaoVung(mapControl1, LayerName, Convert.ToInt64(FeatureID.ToString().Split('.')[0]));
            }
            if ((e.KeyData == (Keys.Alt | Keys.S)))
            {
                panToaDo.Show();
            }
            if ((e.KeyData == (Keys.Alt | Keys.P)))
            {
                panXemIn.Show();
            }
            if ((e.KeyData == (Keys.Control | Keys.Shift | Keys.S)))
            {
                //PanProcess.Show();
                staProcess.Visible = true;
                GhiXacNhan(mapControl1);
                //PanProcess.Hide();
                staProcess.Visible = false;
            }
           
        }

        private void mnuTamThua_Click(object sender, EventArgs e)
        {
            cls.VeTamThua(mapControl1, LayerName);
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
        public void BaoVung(MapControl pMap, string strTenLopSoan, long FeatureID)
        {
            cls.LopBanDo(mapControl1, LayerName, LopNha, BanDo, TenLopDat, TenLopNha);
            DMC.GIS.Common.ExtendLandPlot extendLandPlot = new DMC.GIS.Common.ExtendLandPlot();
            /* Hiển thị hộp hồi thoại nhập khoảng cách mở rộng thửa đất */
            DMC.Land.TachThua.frmExtendLandPlot frmExtend = new DMC.Land.TachThua.frmExtendLandPlot();
            frmExtend.StartPosition = FormStartPosition.CenterScreen;
            frmExtend.ShowDialog();
            if (frmExtend.OK)
            {
                if (MapInfo.Engine.Session.Current.Catalog.GetTable("Dat") != null)
                {
                    MapInfo.Engine.Session.Current.Catalog.CloseTable("Dat");
                }
                Table  dt =null;
                dt = cls.GetNewLayer("Dat", strConnectionstring, "select * from " + BanDo);

                FeatureLayer fl = new FeatureLayer(dt);
                pMap.Map.Layers.Add(fl);

                /* Khai báo khoảng cách mở rộng thửa */
                double dblDistance = frmExtend.Distance;
                extendLandPlot.CreateExtendLandPlot(pMap, "Dat", FeatureID.ToString().Split('.')[0], strTenLopSoan, dblDistance);
                MapInfo.Engine.Session.Current.Catalog.CloseTable("Dat");
             
                Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchAll());
                if (irfc == null)
                {
                    return;
                }
                if (irfc.Count == 0)
                {
                    return;
                }
               
                foreach (Feature f in irfc)
                {
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                    {
                        foreach (Polygon Cur in (MultiPolygon)f.Geometry)
                        {
                            Feature fnew = new Feature(table.TableInfo.Columns);
                            fnew.Geometry = f.Geometry;
                            fnew.Style = f.Style;
                            table.DeleteFeature(f);
                            cls.UpdateDoiTuong(table, fnew.Geometry, "1001", new CompositeStyle(), "");
                        }
                    }
                }
            }
           // SelectLaiThuaDat(pMap, LayerName, FeatureID);
        }

        public void SelectLaiThuaDat(MapControl pMap, string LayerName, long FeatureID) {
            Table table = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection fc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("SW_MEMBER =" + FeatureID.ToString().Split('.')[0] + ""));
            //xoa tat ca các đối tượng đã chọn
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            //select các đối tượng đã được chọn
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(fc);
            fc.Close();
        }

        private void toolBaoThua_Click(object sender, EventArgs e)
        {
            //goi ham thuc thi chuc nang bao vung
            BaoVung(mapControl1, LayerName, Convert.ToInt64(FeatureID.ToString().Split('.')[0]));
        }


        private void numKhoangCachChia_ValueChanged(object sender, EventArgs e)
        {
            //thay doi gia tri cua chieu dai doan thang can chia
            
            double GiaTri;
            GiaTri= Convert.ToDouble(txtChieuDaiDoanThangChia.Text) -Convert.ToDouble( numKhoangCachChia.Value);
            try
            {
                txtConLaiKhoangCachChia.Value = Convert.ToDecimal(GiaTri);
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdClosepanKhoangCachChia_Click(object sender, EventArgs e)
        {
            panKhoangCachChia.Hide();
        }
        //ham chuc nang thuc thi viec an va hien nut tren map
        public void AnHienNut(MapControl pMap, string LayerName){
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

        private void toolShowNode_Click(object sender, EventArgs e)
        {
            //goi ham thuc thi chuc nang an hien nut
            AnHienNut(mapControl1, LayerName);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            
            /* Khai báo lớp MapTools */
            DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
            /* Nhận ảnh hồ sơ kĩ thuật thửa đất */
            byteLandImage = mapTools.ExportMapToImage(mapControl1.Map,Convert.ToInt32(numWidth.Value), Convert.ToInt32(numHeight.Value));
            Image bm = Image.FromStream(new MemoryStream(byteLandImage));
            Bitmap tmp = new Bitmap(bm.Width, bm.Height);

            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.DrawImage(bm, new PointF(0, 0));
                g.FillRectangle(Brushes.White , new RectangleF(0, 0, bm.Width, 17));
                g.DrawString("BASAO.COM.VN", new System.Drawing.Font("Arial", 10), Brushes.Gainsboro, new PointF(5, 5));
            }
           // bm.Dispose();
            /* Chuyển mảng byte về Image và hiển thị Ảnh Hồ sơ thửa đất lên Form */
            picXemTruocKhiIn.Image = null;
            //picXemTruocKhiIn.Image.Size.Width = 400;
            //picXemTruocKhiIn.Image.Size.Height = 400;
            picXemTruocKhiIn.Image = tmp;//mapTools.byteArrayToImage(byteLandImage);
            byteLandImage = mapTools.imageToByteArray(tmp);
            //tmp.Dispose();
        }
        //chuc nang ghi danh sach toa do vao CSDL
        public void GhiDanhSachToaDo(SqlConnection conn) {
            if (grDanhSachToaDo.Rows.Count > 0)
            {
                //goi ham ghi danh sach toa do vao csdl
                clsData.GhiDanhSachToaDo(conn, grDanhSachToaDo, lgMaHoSoCapGCN, Convert.ToInt64(FeatureID.ToString().Split('.')[0]));
            }
        }

        //ham thuc thi viec ghi du lieu anh cua thua dat vao CSDL(phuc vu cho viec in an)
        public void GhiPhanInHoSo(bool kt) {
            DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
            double dblScale = Convert.ToDouble(mapControl1.Map.Size.Height) / Convert.ToDouble(mapControl1.Map.Size.Width);
            if (kt)
            {
                byteLandImage = mapTools.ExportMapToImage(mapControl1.Map, Convert.ToInt32(480), Convert.ToInt32(480 * dblScale));
            }
            else
            {
                byteLandImage = mapTools.ExportMapToImage(mapControl1.Map, Convert.ToInt32(480), Convert.ToInt32(480 * dblScale));
            }
                       
            Image bm = Image.FromStream(new MemoryStream(byteLandImage));
            Bitmap tmp = new Bitmap(bm.Width, bm.Height);

            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                g.DrawImage(bm, new PointF(0, 0));
                g.FillRectangle(Brushes.White, new RectangleF(0, 0, bm.Width, 17));
                //  g.DrawString("BASAO.COM.VN", new System.Drawing.Font("Arial", 10), Brushes.Gainsboro, new PointF(5, 5));
            }
            byteLandImage = mapTools.imageToByteArray(tmp);



            ///* Khai báo lớp MapTools */
            //DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
            ///* Nhận ảnh hồ sơ kĩ thuật thửa đất */
            //if (kt)
            //{
            //    byteLandImage = mapTools.ExportMapToImage(mapControl1.Map, Convert.ToInt32(480), Convert.ToInt32(400));
            //}
            //else {
            //    byteLandImage = mapTools.ExportMapToImage(mapControl1.Map, Convert.ToInt32(480), Convert.ToInt32(400));
            //}

            /* Khai báo lớp chứa phương thức cập nhật Ảnh hồ sơ kĩ thuật thửa đất
          * vào cơ sở dữ liệu */
            DMC.GIS.Common.HoSoKiThuat HoSoKiThuat = new DMC.GIS.Common.HoSoKiThuat();
            HoSoKiThuat.Connection = strConnectData;
            HoSoKiThuat.MaHoSoCapGCN = lgMaHoSoCapGCN.ToString();
            HoSoKiThuat.HoSoKiThuatThuaDat = byteLandImage;
            if (kt)
            {
                HoSoKiThuat.UpdateHoSoCapGCNByHoSoKiThuatThamDinh();
            }
            else {
                HoSoKiThuat.UpdateHoSoCapGCNByHoSoKiThuatGCN ();
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            /* Khai báo lớp chứa phương thức cập nhật Ảnh hồ sơ kĩ thuật thửa đất
           * vào cơ sở dữ liệu */
            DMC.GIS.Common.HoSoKiThuat HoSoKiThuat = new DMC.GIS.Common.HoSoKiThuat();
            HoSoKiThuat.Connection = strConnectData;
            HoSoKiThuat.MaHoSoCapGCN = lgMaHoSoCapGCN.ToString();
            HoSoKiThuat.HoSoKiThuatThuaDat = byteLandImage;
            HoSoKiThuat.UpdateHoSoCapGCNByHoSoKiThuatThamDinh();
        }
        //ham thuc thi viec hien thi huong cua doan thang
        public void HuongCuaDoanThang(MapControl pMap, string LayerName) {
            if (mapControl1.Map == null)
                return;
            if (mapControl1.Map.Layers[LayerName] == null)
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
        private void toolHuongDuong_Click(object sender, EventArgs e)
        {
            //goi ham thuc thi hien thi huong cua doan thang
            HuongCuaDoanThang(mapControl1, LayerName);
        }
        private void cmdCloseXemIn_Click(object sender, EventArgs e)
        {
            panXemIn.Hide();
        }

        private void panXemInMenu_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panXemIn, e);
        }

        private void panXemInMenu_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panXemIn, e);
        }

        private void cmdThoatToaDoDiem_Click(object sender, EventArgs e)
        {
            panToaDoDiem.Hide();
        }

        private void cmdCloseToaDoDiem_Click(object sender, EventArgs e)
        {
            panToaDoDiem.Hide();
        }

        private void panMnuToaDoDiem_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panToaDoDiem, e);
        }

        private void panMnuToaDoDiem_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panToaDoDiem, e);
        }

        private void panToaDoDiem_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panToaDoDiem, e);
        }

        private void panToaDoDiem_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panToaDoDiem, e);
        }
        //hien thi toa do diem
        private void toolToaDoDiem_Click(object sender, EventArgs e)
        {
            LayToaDoDiem(mapControl1, LayerName);
            panToaDoDiem.Show();
            ShowLocation(panToaDoDiem);
        }
        //ham thuc thi chuc nang lay toa do diem dc chon
        public void LayToaDoDiem(MapControl pMap, string LayerName ) {
            try
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
                irfc.Close();
            }catch(Exception ex ){}
        }
        //chon doi tuong van ban tren map
        private void toolChonVanBan_Click(object sender, EventArgs e)
        {
            ChonLoaiDoiTuong(mapControl1, LayerName, "MapInfo.Geometry.LegacyText");
        }
        //chon doi tuong vung tren map
        private void toolChonVung_Click(object sender, EventArgs e)
        {
            ChonLoaiDoiTuong(mapControl1, LayerName, "MapInfo.Geometry.MultiPolygon");
        }
        //chon doi tuong duong tren map
        private void toolChonDuong_Click(object sender, EventArgs e)
        {
            ChonLoaiDoiTuong(mapControl1, LayerName, "MapInfo.Geometry.MultiCurve");
        }
        //chon doi tuong diem tren map
        private void toolChonDiem_Click(object sender, EventArgs e)
        {
            ChonLoaiDoiTuong(mapControl1, LayerName, "MapInfo.Geometry.Point");
        }
        //ham thuc thi chuc nang chon loai doi tuong tren ban do
        public void ChonLoaiDoiTuong(MapControl pMap, string LayerName, string LoaiDoiTuong) {
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lay tat ca cac doi truong tren ban do
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());

            if (irfc == null)
            {
                return;
            }
            if (irfc.Count  == 0)
            {
                return;
            }
            //xoa chon tat ca cac doi tuong
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            //thuc hien viec chon cac doi tuong
            foreach(Feature f in irfc ){
                //neu khogn phai la loai doi tuong duoc chon 
                if (LoaiDoiTuong!=f.Geometry.GetType().ToString())
                {
                    //thi remove no di chu de do lam gi nua
                    irfc.Remove(f);
                }
            }
            //chon doi tuong con lai
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(irfc);
            irfc.Close();
        }
        //chon nhan dinh
        private void toolGrChonNhanDinh_Click(object sender, EventArgs e)
        {
            ChonNhanDinh();
        }
        //chon nhan canh
        private void toolGrChonNhanCanh_Click(object sender, EventArgs e)
        {
            ChonNhanCanh(LayerName);
        }
        //chon nhan thua
        private void toolGrChonNhanThua_Click(object sender, EventArgs e)
        {
            ChonNhanThua(LayerName);
        }
        //chon nhan nut
        private void toolGrChonNhanNut_Click(object sender, EventArgs e)
        {
            ChonNhanNode(LayerName);
        }
        //chon nhan duong bao
        private void toolGrChonNhanDuongbao_Click(object sender, EventArgs e)
        {
            ChonDuongBao(LayerName);
        }

        private void toolChuyenThanhPolyline_Click(object sender, EventArgs e)
        {
            //goi ham convert
            cls.ConvertToPolyline(mapControl1, LayerName, staProcess);
            ExportsFileTab();
            mapControl1.Map.Invalidate();
        }
        //copy doi tuong thua tu ban do tong the
        private void toolCopyTuBanDo_Click(object sender, EventArgs e)
        {
            //cls.CopyTuBanDoTongThe(mapControl1, LayerName, TenLopDat );
        }
        // goi chuc nang chia doan thang hien thi diem
        private void cmdChiaDiem_Click(object sender, EventArgs e)
        {
            cls.ChiaDoanThang(mapControl1, LayerName, Convert.ToDouble(numKhoangCachChia.Value), true);
            ExportsFileTab();
        }
        //goi chuc nang chia doan thang
        private void cmdChiaDoanThang_Click(object sender, EventArgs e)
        {
            cls.ChiaDoanThang(mapControl1, LayerName, Convert.ToDouble(numKhoangCachChia.Value), false);
            ExportsFileTab();
        }
        //thay doi gia gi cua doi tuong doan thang tu chuc nang chia doan thang
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

        private void toolMovePointInPolygon_Click(object sender, EventArgs e)
        {
            DiChuyenDinhThua=true ;
            GanDinhVaoVung = DiemCuoiChonThua;
        }
      //chuc nang gan diem theo vung (chon diem==> chon chuc nang gan diem==> chon vung)
        public void GanDiemTheoVung(MapControl pMap, string LayerName, DPoint dDiem, DPoint DiemTrongThua)
        {
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());

            DPoint DiemCanTim=new DPoint();
            if (irfc == null) {
                return ;
            }
            if (irfc.Count  == 0)
            {
                return ;
            }
            DPoint[] dNew = null;//mang cac diem moi tao tu polygon tim duoc
           DPoint [] DiemThua=null;
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
                                else {
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
            irfc.Close();
            DiChuyenDinhThua = false;
        }
        //thay doi cac nhin tu ban do nho ben canh 
        private void mapControlView_MouseMove(object sender, MouseEventArgs e)
        {
            mapToolBar1.MapControl = mapControlView;
            mapToolBar1.MapControl.Map = mapControlView.Map;
        }

        public void Undo(string LayerName) {
            string file;
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            
        }
        //chuc nang khi tat phien lam viec soan ho so thua dat
        public  void FormClosing()
        {
            //tat tat ca
            MapInfo.Engine.Session.Current.Catalog.CloseTable(TenLopNha );
            MapInfo.Engine.Session.Current.Catalog.CloseTable(TenLopDat );
            MapInfo.Engine.Session.Current.Catalog.CloseTable(LayerName );
            MapInfo.Engine.Session.Current.Catalog.CloseAll();
            mapControl1.Map.Clear();
            mapControl1.Map.Layers.Clear();
            XoaFileTmp();
        }

        public void XoaFileTmp() {
            string fileName = "";
            fileName = Application.StartupPath;
            try
            {

                DirectoryInfo dir = new DirectoryInfo(fileName + @"\TempSoan\");
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


        //chuc nang cho phep thay doi doi tuong thua dat va doi tuong duong
        private void toolEditThuaDat_Click(object sender, EventArgs e)
        {
            if (mapControl1.Map == null)
                return;
            if (mapControl1.Map.Layers[LayerName] == null)
                return;
            if (toolEditThuaDat.CheckState==CheckState.Checked ){
                EditThuaDat=true ;
                toolEditThuaDat.Checked = false;
                EditMode = MapInfo.Tools.EditMode.Objects ;
                mapControl1.Tools.SelectMapToolProperties.EditMode = EditMode;
                this.toolEditThuaDat.Image = global::DMC.Land.SoanHoSo.Properties.Resources._lock;
             
            }
            else
            {
                EditThuaDat=false ;
                toolEditThuaDat.Checked = true ;
                EditMode = MapInfo.Tools.EditMode.Nodes;
                mapControl1.Tools.SelectMapToolProperties.EditMode = EditMode;
                this.toolEditThuaDat.Image = global::DMC.Land.SoanHoSo.Properties.Resources.lock_off;
            }
        }

        private void toolTyLe_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void toolChinhLyToaDo_Click(object sender, EventArgs e)
        {
            frmChinhLyToaDo frm = new frmChinhLyToaDo();
            frm.Connection = strConnectData;
            frm.MaHoSo = lgMaHoSoCapGCN.ToString();
            frm.ShowDialog();
        }

        private void toolPrinting_Click(object sender, EventArgs e)
        {
            ///* In trực tiếp bản đồ */
            //DMC.Land.InSoDoNhaDat.frmInSoDoNhaDat InSoDoNhaDat = new DMC.Land.InSoDoNhaDat.frmInSoDoNhaDat();
            ///* Khai báo biến nhận Hình ảnh bản đồ */
            //byte[] bytImage = null;
            ///* Nhận hình ảnh bản đồ */
            //DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
            //bytImage = mapTools.ExportMapToImage(mapControl1.Map, mapControl1.Map.Size.Width, mapControl1.Map.Size.Height);
            //InSoDoNhaDat.ctrlSoDoNhaDat.Image = bytImage;
            //double dblScale = Convert.ToDouble(mapControl1.Map.Size.Height) / Convert.ToDouble(mapControl1.Map.Size.Width);
            //InSoDoNhaDat.ctrlSoDoNhaDat.HeightScale = dblScale;
            ///* Hiển thị Report Sơ đồ nhà đất */
            //InSoDoNhaDat.StartPosition = FormStartPosition.CenterScreen;
            //InSoDoNhaDat.WindowState = FormWindowState.Maximized;
            //InSoDoNhaDat.Show();

            /* In trực tiếp bản đồ */
            DMC.Land.InSoDoNhaDat.frmInSoDoNhaDat InSoDoNhaDat = new DMC.Land.InSoDoNhaDat.frmInSoDoNhaDat();
            /* Khai báo biến nhận Hình ảnh bản đồ */
            byte[] bytImage = null;
            /* Nhận hình ảnh bản đồ */
            DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
            bytImage = mapTools.ExportMapToImage(mapControl1.Map, mapControl1.Map.Size.Width, mapControl1.Map.Size.Height);
            Image bm = Image.FromStream(new MemoryStream(bytImage));
            Bitmap tmp = new Bitmap(bm.Width, bm.Height);

            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                g.DrawImage(bm, new PointF(0, 0));
                g.FillRectangle(Brushes.White, new RectangleF(0, 0, bm.Width, 17));
              //  g.DrawString("BASAO.COM.VN", new System.Drawing.Font("Arial", 10), Brushes.Gainsboro, new PointF(5, 5));
            }
            picXemTruocKhiIn.Image = null;
            picXemTruocKhiIn.Image = tmp;
            bytImage = mapTools.imageToByteArray(tmp);

            InSoDoNhaDat.ctrlSoDoNhaDat.Image = bytImage;

            double dblScale = Convert.ToDouble(mapControl1.Map.Size.Height) / Convert.ToDouble(mapControl1.Map.Size.Width);

            InSoDoNhaDat.ctrlSoDoNhaDat.HeightScale = dblScale;
            /* Hiển thị Report Sơ đồ nhà đất */
            InSoDoNhaDat.StartPosition = FormStartPosition.CenterScreen;
            InSoDoNhaDat.WindowState = FormWindowState.Maximized;
            InSoDoNhaDat.Show();
        }

        private void mapControl1_Resize(object sender, EventArgs e)
        {
            SizeMapWidth = Convert.ToInt32( mapControl1.Width / 2);
            SizeMapHeigt = Convert.ToInt32( mapControl1.Height  / 2);
        }

        private void toolThemDiem_Click(object sender, EventArgs e)
        {
            panDiem.Show();
            ShowLocation(panDiem);
        }

        private void toolDoKhoangCach_MouseDown(object sender, MouseEventArgs e)
        {
           // cls.ToolMouseDown(toolDoKhoangCach, e);
        }

        private void toolDoKhoangCach_MouseMove(object sender, MouseEventArgs e)
        {
         //   cls.ToolMouseMove(toolDoKhoangCach, e);
        }
        public int Sizefont(double DienTichText, double DienTichThua, double Zoom)
        { // 1point = 0.0375 m
            // dien tich o chu 1 point 	 	0.0375 * 0.0375 = 0.00140625
            //font = 8: ty le 226.37085052427096 / (0.0000140625 * 8) = 20 121.8534
            double fontSize = 1;
            fontSize = DienTichText * (20 * Zoom) / DienTichThua;
            return Convert.ToInt16(fontSize);
        }
        public double DienTichCuaNhan(int fontSize, double DienTichThua, double Zoom)
        { // 1point = 0.0375 m
            // dien tich o chu 1 point 	 	0.0375 * 0.0375 = 0.00140625
            //font = 8: ty le 226.37085052427096 / (0.0000140625 * 8) = 20 121.8534
            double DienTichText = 0;
            DienTichText = DienTichThua * fontSize / (20 * Zoom);
            return DienTichText;
        }
        private void PhucHoiFile(string LoaiFile)
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\TempSoan\");
            FileInfo[] file = dir.GetFiles("*" + LoaiFile);
            int LenCount = file.Length - 1;
            string fileDich = Application.StartupPath + @"\RestoreMapSoan\tmp" + LenCount + "." + LoaiFile;
            string fileNguon = Application.StartupPath + @"\TempSoan\tmp" + LenCount + "." + LoaiFile;
            File.Copy(fileNguon, fileDich);
        }
        public void ExportsFileTab()
        {
            try
            {
                // xoa file tmp khi undo den giai doan giua rui lam tiep

                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\TempSoan\");
                DirectoryInfo dirPhucHoi = new DirectoryInfo(Application.StartupPath + @"\RestoreMapSoan\");
                FileInfo[] file = dir.GetFiles("*.tab");
                //phuc hoi lai file vua bi thoat chuong trinh
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
                fileName = fileName + @"\TempSoan\tmp" + intUndo + ".TAB";
                MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                //tao bang tam 
                MapInfo.Data.Table table = CreateTmpTab(LayerName, "fileTmp" + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second);
                MapInfo.Data.TableInfoNative native = (MapInfo.Data.TableInfoNative)MapInfo.Data.TableInfoFactory.CreateFromFeatureCollection(MapInfo.Data.TableType.Native, table);
                native.TablePath = fileName;
                native.WriteTabFile();
                if (MapInfo.Engine.Session.Current.Catalog.GetTable("tmp" + intUndo) != null)
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
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                    { 
                        LegacyText txt = (LegacyText)f.Geometry;
                        Int16 fontSize = cls.GetFontSize(txt, mapControl1); 
                        TextStyle ts = new TextStyle();
                        ts = (TextStyle)f.Style;
                        ts.Font.Size = fontSize;

                        DPoint d = new DPoint(); 
                        DPoint[] PPoint = new DPoint[2];
                        d = f.Geometry.Centroid;

                        MapInfo.Geometry.LegacyText gValue = new LegacyText(mapControl1.Map.GetDisplayCoordSys(), (LegacyText)f.Geometry);
                        cs.ApplyStyle(ts);
                        cls.UpdateDoiTuong(nativetable, gValue, MaDT, cs, "");
                    }
                    else
                    {
                        cs.ApplyStyle(f.Style);
                        cls.UpdateDoiTuong(nativetable, f.Geometry, MaDT, cs, "");
                    }

                     

                }
                intUndo = intUndo + 1;
                nativetable.Close();
                irfc.Close();
            }catch(Exception ex){}
        }
        // thu tuc xoa file temp
        public void XoaFileTmp(string fileName)
        { 
            string tabFile,datFile,idFile,mapFile;
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

        // tao bang temp
        public Table CreateTmpTab(string tabOld,string TabTmpName) {
            MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(tabOld);
            //TableInfo
            MapInfo.Data.TableInfo ti = MapInfo.Data.TableInfoFactory.CreateTemp(TabTmpName);
            for (int i = 0; i < tab.TableInfo.Columns.Count; i++)
            {
                if (tab.TableInfo.Columns[i].Alias.ToUpper() != "Obj".ToUpper() && tab.TableInfo.Columns[i].Alias.ToUpper() != "MI_Geometry".ToUpper() && tab.TableInfo.Columns[i].Alias.ToUpper() != "MI_Style".ToUpper())
                {
                    if (tab.TableInfo.Columns[i].DataType == MIDbType.String)
                    {
                        ti.Columns.Add(new MapInfo.Data.Column(tab.TableInfo.Columns[i].Alias, tab.TableInfo.Columns[i].DataType, 100, 20));
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
        //load file khi thuc thi undo redo
        public void LoadFileTmp(string fileName,MapControl pMap) 
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
                    string MaDT = "";
                    MaDT = cls.GetMaDoiTuong(f, tabTmp.Alias);
                    CompositeStyle cs = new CompositeStyle();
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                    { 
                        //lay font size
                        LegacyText txt = (LegacyText)f.Geometry;
                        Int16 fontSize = cls.GetFontSize(txt, pMap);
                        TextStyle ts = new TextStyle();
                        ts = (TextStyle)f.Style;
                        ts.Font.Size = fontSize;
 
                        DPoint d = new DPoint(); 
                        DPoint[] PPoint = new DPoint[2];
                        d = f.Geometry.Centroid;
                        MapInfo.Geometry.LegacyText gValue = new LegacyText(pMap.Map.GetDisplayCoordSys(), (LegacyText)f.Geometry);
                        MapInfo.Geometry.LegacyText g = MapInfo.Text.TextFactory.CreateLegacyText(pMap.Map.GetDisplayCoordSys(), d, Alignment.CenterCenter, txt.Caption.ToString(), pMap.Map, ts.Font);
                        g.Layout.Angle = gValue.Layout.Angle;
                        cs.ApplyStyle(ts);
                        cls.UpdateDoiTuong(tab, g, MaDT, cs, "");
                    }
                    else
                    {
                        cs.ApplyStyle(f.Style);
                        cls.UpdateDoiTuong(tab , f.Geometry, MaDT, cs, "");
                    }
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
            catch (Exception ex){ }
            
        }
        private void toolExportsFile_Click(object sender, EventArgs e)
        {
            ExportsFileTab();           
        }

        private void toolUndo_Click(object sender, EventArgs e)
        {
            toolUndo.Enabled = false ;
            string fileName = "";
            fileName = Application.StartupPath;
            DirectoryInfo dir = new DirectoryInfo(fileName + @"\TempSoan\");
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
            toolUndo.Enabled = true ;
                   //khi undo den gioi han cuoi cung thi an chuc nang undo va hien thi chuc nang redo          
          
        }

        private void toolRedo_Click(object sender, EventArgs e)
        {
            toolRedo.Enabled = false;
         string fileName = "";
            fileName = Application.StartupPath;
            DirectoryInfo dir = new DirectoryInfo(fileName + @"\TempSoan\");
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
                if (intUndo <  file.Length)
                {
                    intUndo = intUndo + 1;
                    UndoRedo(intUndo);    
                }
                else
                { UndoRedo(file.Length); }
                            
             }
            toolRedo.Enabled = true ;
            //khi redo de gioi han max thi an cong cu redo va hien thi chuc nang undo
           
        }
        private void UndoRedo(int fileCount) {
            string fileName = "";
            fileName = Application.StartupPath;
                int intFile = fileCount;
                fileName = fileName + @"\TempSoan\tmp" + fileCount.ToString() + ".TAB";
                LoadFileTmp(fileName,mapControl1 );
        }

        private void mapControl1_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Font myFont = new System.Drawing.Font(fontName, fontSize);
            //System.Drawing.SizeF StringSize =new  System.Drawing.SizeF();
            //StringSize = e.Graphics.MeasureString("A", myFont);
            //heightFont = StringSize.Height/TyleBanDo;
            //widthFont = StringSize.Width / TyleBanDo;
        }

        private void ToolBatdinh_Click(object sender, EventArgs e)
        {
            frmSnapPoints snapPoint = new frmSnapPoints();
            snapPoint.ShowDialog();
            DMC.GIS.Common.MapTools mapTool = new DMC.GIS.Common.MapTools();
            mapTool.SnapEnable(mapControl1, DMC.Land.TachThua.CommonLand.shortTolerance, DMC.Land.TachThua.CommonLand.boolSnapEnable);
        }

        private void toolHieuChinh_Click(object sender, EventArgs e)
        {
            /* Khai báo hộp hồi thoại thiết lập chế độ hiệu chỉnh bản đồ */
            frmEditingMode editingMode = new frmEditingMode();
            /* Hiển thị hộp hồi thoại */
            editingMode.ShowDialog();
            /* Xác nhận chế độ hiệu chỉnh đã được thiết lập trên hộp hồi thoại */
            DMC.GIS.Common.MapTools mapTool = new DMC.GIS.Common.MapTools();
            mapTool.EditingMode(mapControl1, DMC.Land.TachThua.CommonLand.EditMode);
        }

        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            double chieurong, chieucao;
            chieurong = mapControl1.Width;
            chieucao = mapControl1.Height;
            double tyle = 0.0;
            tyle = chieurong / chieucao;
            double wi =Convert.ToDouble( numWidth.Value);
            numHeight.Value =Convert.ToDecimal( wi / tyle);
        }

        private void numHeight_ValueChanged(object sender, EventArgs e)
        {
            double chieurong, chieucao;
            chieurong = mapControl1.Width;
            chieucao = mapControl1.Height;
            double tyle = 0.0;
            tyle = chieurong / chieucao;
            double hi =Convert.ToDouble( numHeight.Value);
            numWidth.Value = Convert.ToDecimal( hi   * tyle);
        }

        public void LuuFileMap(string MaHoSo)
        {
            // xoa file tmp khi undo den giai doan giua rui lam tiep
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\DataHSKT\");
            FileInfo[] file = dir.GetFiles("*.tab");
            for (int i = 0; i < file.Length; i++)
            {
                XoaFileTmp(dir + "\\" + file[i].Name);
            }

            string fileName = "";
            fileName = Application.StartupPath;
            //lay duong dan file du lieu temp can tao ra
            fileName = fileName + @"\DataHSKT\" + MaHoSo + ".TAB";
            MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //tao bang tam 
            try
            {
                MapInfo.Data.Table tabHS = MapInfo.Engine.Session.Current.Catalog.GetTable(MaHoSo);
                if (tabHS.IsOpen)
                {
                    tabHS.Close();
                }
            }
            catch (Exception ex) { }

            MapInfo.Data.Table table = CreateTmpTab(LayerName, MaHoSo);

            MapInfo.Data.TableInfoNative native = (MapInfo.Data.TableInfoNative)MapInfo.Data.TableInfoFactory.CreateFromFeatureCollection(MapInfo.Data.TableType.Native, table);
            native.TablePath = fileName;
            native.WriteTabFile();
            MapInfo.Data.Table nativetable = MapInfo.Engine.Session.Current.Catalog.CreateTable(native);
            table.Close();
            nativetable.Close();
            native.Dispose();
            nativetable = MapInfo.Engine.Session.Current.Catalog.OpenTable(fileName);
            mapControl1.Map.DrawingAttributes.EnableTranslucency = true;
            mapControl1.Map.DrawingAttributes.SmoothingMode = SmoothingMode.AntiAlias;
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());

            foreach (Feature f in irfc)
            {
                string MaDT = "";
                MaDT = cls.GetMaDoiTuong(f, LayerName);
                CompositeStyle cs = new CompositeStyle();
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                {
                    LegacyText txt = (LegacyText)f.Geometry;
                    Int16 fontSize = cls.GetFontSize(txt, mapControl1);
                    TextStyle ts = new TextStyle();
                    ts = (TextStyle)f.Style;
                    ts.Font.Size = fontSize;

                    DPoint d = new DPoint();
                    DPoint[] PPoint = new DPoint[2];
                    d = f.Geometry.Centroid;

                    MapInfo.Geometry.LegacyText gValue = new LegacyText(mapControl1.Map.GetDisplayCoordSys(), (LegacyText)f.Geometry);
                    cs.ApplyStyle(ts);
                    cls.UpdateDoiTuong(nativetable, gValue, MaDT, cs, "");
                }
                else
                {
                    cs.ApplyStyle(f.Style);
                    cls.UpdateDoiTuong(nativetable, f.Geometry, MaDT, cs, "");
                }



            }
            //nativetable.InsertFeatures(irfc);
            nativetable.Close();
            irfc.Close();
          
        }
        public byte [] GhiFileMap(string MaHoSo,string KieuFile)
        {
            string file = "";
            byte [] byfile  ;
            string fileName = "";
            fileName = Application.StartupPath;
            //lay duong dan file du lieu temp can tao ra
            file = fileName + @"\DataHSKT\" + MaHoSo + "." + KieuFile;
            byfile = ReadFile(file );
            return byfile;
        }
        public byte [] ReadFile(string  strPath ) 
        {
            //'Initialize byte array with a null value initially.
            byte [] byteData ;
            //'Use FileInfo object to get file size.
            FileInfo  fInfo = new  System.IO.FileInfo(strPath);
            long  numBytes ;
            numBytes = fInfo.Length;
            //'Open file stream de doc file
             FileStream fStream ;
            fStream = new  System.IO.FileStream(strPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //'Use BinaryReader to read file stream into byte array.
            System.IO.BinaryReader br = new  System.IO.BinaryReader(fStream);
            //'When you use BinaryReader, you need to supply number of bytes to read from file.
            //'In this case we want to read entire file. So supplying total number of bytes.
            byteData = br.ReadBytes((int)numBytes);
            return byteData;
        }
        public bool WriteFile(string MaHoSoCapGCN, string KieuFile, byte[] byteContent)
        {
             FileStream objFstream = null ;
            try {
                objFstream = File.Open(Application.StartupPath + @"\DataHSKT\" + MaHoSoCapGCN + "." + KieuFile, FileMode.Create, FileAccess.Write);
                long lngLen = byteContent.Length;
                objFstream.Write(byteContent, 0, (int)lngLen);
                objFstream.Flush();
                return true ;
            }
            catch( Exception ex){
                MessageBox.Show  (" Lỗi ghi dữ liệu: " + ex.Message);
                return false;
            }
            finally
            {
                objFstream.Close();
            }
        }

        private void toolXuatFileMap_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = clsData.GetFileMap(0,lgMaHoSoCapGCN.ToString());
            if (dt.Rows.Count > 0)
            {

                if (WriteFile(lgMaHoSoCapGCN.ToString(), "tab", (byte[])dt.Rows[0]["FileTab"]) == false)
                {
                    MessageBox.Show(" Không export được file Tab");
                    return;
                }
                if (WriteFile(lgMaHoSoCapGCN.ToString(), "Dat", (byte[])dt.Rows[0]["FileDat"]) == false)
                {
                    MessageBox.Show(" Không export được file Dat" );
                    return;
                }
                if (WriteFile(lgMaHoSoCapGCN.ToString(), "ID", (byte[])dt.Rows[0]["FileID"]) == false)
                {
                    MessageBox.Show(" Không export được file ID" );
                    return;
                }
                if (WriteFile(lgMaHoSoCapGCN.ToString(), "Map", (byte[])dt.Rows[0]["FileMap"]) == false)
                {
                    MessageBox.Show(" Không export được file Map");
                    return;
                }
                //if (WriteFile(lgMaHoSoCapGCN.ToString(), "IND", (byte[])dt.Rows[0]["FileMap"]) == false)
                //{
                //    MessageBox.Show(" Không export được file Map");
                //    return;
                //}
            }
        }

            private void paneMnuXemInMap_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panXemInMap, e);
        }

        private void paneMnuXemInMap_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panXemInMap, e);
        }

           private void button2_Click(object sender, EventArgs e)
        {
            panXemInMap.Hide();
        }

        private void numTyLeZoom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double TyleZoom = 0;
                double TyLePhanTram = 0;
                double ZZoom =0;
                double dblValue = 0;
                double dblZoom = strZoom100;
                TyleZoom = dblZoom / 100;
                dblValue = Convert.ToDouble(numTyLeZoom.Value);
                ZZoom = dblValue * 100 / (dblZoom);
                numTyLePhanTram.Text = System.Convert.ToDouble(string.Format("{0:E2}", ZZoom)).ToString();
                TyLePhanTram = Convert.ToDouble(numTyLePhanTram.Text);
                mapXemIn.Map.Zoom = new MapInfo.Geometry.Distance(dblZoom * TyLePhanTram / 100, DistanceUnit.Meter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdGhiZoomIn_Click(object sender, EventArgs e)
        {
            
            clsData.UpdateZoomMapFile(5, lgMaHoSoCapGCN.ToString(),Convert.ToDouble( numTyLeZoom.Value));

        }

        private void numTyLePhanTram_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double TyleZoom = 0;
                double TyLePhanTram = 0;
                double dblZoom = strZoom100;
                TyleZoom = dblZoom / 100;
                TyLePhanTram = Convert.ToDouble(numTyLePhanTram.Text);
                mapXemIn.Map.Zoom = new MapInfo.Geometry.Distance(dblZoom * TyLePhanTram / 100, DistanceUnit.Meter);
                numTyLeZoom.Value =Convert.ToDecimal( dblZoom * TyLePhanTram / 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (intUndo > 2)
            {
                // xoa file tmp khi undo den giai doan giua rui lam tiep
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\tempSoan\");
                FileInfo[] file = dir.GetFiles("*.tab");
                intUndo = file.Length - 2;
                string fileName = "";
                fileName = Application.StartupPath;
                //lay duong dan file du lieu temp can tao ra
                fileName = fileName + @"\tempSoan\tmp" + intUndo + ".TAB";
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

        private void panMnuBanKinhDuongTron_MouseDown(object sender, MouseEventArgs e)
        {
            cls.PanMouseDown(panBanKinhDuongTron, e);
        }

        private void panMnuBanKinhDuongTron_MouseMove(object sender, MouseEventArgs e)
        {
            cls.PanMouseMove(panBanKinhDuongTron, e);
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

        private void button4_Click(object sender, EventArgs e)
        {
            panBanKinhDuongTron.Hide();
        }

        private void cmdChuyenToaDoThuc_Click(object sender, EventArgs e)
        {
            panViTriDiemChuyen.Show();
            ShowLocation(panViTriDiemChuyen);
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

        private void toolChonDiemGoc_Click(object sender, EventArgs e)
        {
            panToaDo.Show();
            ShowLocation(panToaDo);
        }

        private void toolStripMenuItemNotUndo_Click(object sender, EventArgs e)
        {
            if (intUndo > 2)
            {
                // xoa file tmp khi undo den giai doan giua rui lam tiep
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\tempSoan\");
                FileInfo[] file = dir.GetFiles("*.tab");
                intUndo = file.Length - 2;
                string fileName = "";
                fileName = Application.StartupPath;
                //lay duong dan file du lieu temp can tao ra
                fileName = fileName + @"\tempSoan\tmp" + intUndo + ".TAB";
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

        private void toolStripMenuItemOutCT_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\RestoreMapSoan\");
            FileInfo[] file = dir.GetFiles("*.tab");
            string fileName = "";
            int IndexPhucHoi = 0;
            IndexPhucHoi = file.Length;
            fileName = Application.StartupPath;
            //lay duong dan file du lieu temp can tao ra
            if (IndexPhucHoi > 0)
            {
                fileName = fileName + @"\RestoreMapSoan\" + file[0];
                LoadFileTmp(fileName, mapControl1);
                File.Delete(fileName);
                File.Delete(fileName.Replace("Tab", "Id"));
                File.Delete(fileName.Replace("Tab", "Dat"));
                File.Delete(fileName.Replace("Tab", "Map"));
            }
        }

 
        private void grDanhSachToaDo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //goi ham hien thị nút điểm lên bản đồ
                ChonNutDiem(e.RowIndex);
                grDanhSachToaDo.Columns[3].DefaultCellStyle.BackColor = System.Drawing.Color.Chocolate;
                grDanhSachToaDo.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.Cyan;
                //gọi hàm tạo mới điểm vừa chọn trong danh sach toạ độ
                cls.getSelectDiemGocDan(mapControl1, grDanhSachToaDo, e.RowIndex, LayerName);
                panToaDo.Hide();
            }
            catch (Exception ex) { }
        }

   
        private void ToolStripSaoChepTuDat_Click(object sender, EventArgs e)
        {
            cls.CopyTuBanDoTongThe(mapControl1, LayerName, TenLopDat);
        }

        private void ToolStripSaoChepTuNha_Click(object sender, EventArgs e)
        {
            cls.CopyTuBanDoTongThe(mapControl1, LayerName, TenLopNha );
        }

        private void toolNhanThuaXungQuanh_Click(object sender, EventArgs e)
        {
            try
            {
                //    cls.LopBanDo(mapControl1, LayerName, LopNha, BanDo, TenLopDat, TenLopNha);
                DMC.GIS.Common.ExtendLandPlot extendLandPlot = new DMC.GIS.Common.ExtendLandPlot();
                /* Hiển thị hộp hồi thoại nhập khoảng cách mở rộng thửa đất */
                DMC.Land.TachThua.frmExtendLandPlot frmExtend = new DMC.Land.TachThua.frmExtendLandPlot();
                frmExtend.StartPosition = FormStartPosition.CenterScreen;
                frmExtend.ShowDialog();
                if (frmExtend.OK)
                {
                    Table table = null;
                    Table tableThuaDat = null;
                    table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                    tableThuaDat = MapInfo.Engine.Session.Current.Catalog.GetTable(TenLopDat);
                    //lấy tất cả các đối tượng được chọn
                    IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
                    if (irfc == null)
                    {
                        return;
                    }
                    if (irfc.Count != 1)
                    {
                        return;
                    }
                    Feature f = (Feature)irfc[0];

                    DRect rect = f.Geometry.Bounds;
                    DPoint pt = f.Geometry.Centroid;
                    PointF point = cls.ConvertPoinF(pt, mapControl1);
                    //lấy tất cả các đối tượng nằm trong vùng được chọn
                   // IResultSetFeatureCollection fc = MapInfo.Engine.Session.Current.Catalog.Search(tableThuaDat, MapInfo.Mapping.SearchInfoFactory.SearchWithinScreenRadius(mapControl1.Map.Layers[LayerName].Map, point, System.Convert.ToInt32(frmExtend.Distance ), ContainsType.Centroid));
                    
                    DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
                    DMC.GIS.Common.SearchTools searchTools = new DMC.GIS.Common.SearchTools();

                    MapInfo.Data.Feature featureBuffer;
                    featureBuffer = featureTools.Buffer(f, frmExtend.Distance );

                    /* Search Intersect between Buffer and Features in strLayerName */
                    MapInfo.Data.IResultSetFeatureCollection fc = searchTools.SearchWithIntersect(mapControl1.Map, tableThuaDat.Alias, featureBuffer.Geometry);
                    foreach (Feature ff in fc)
                    { 
                            MapInfo.Geometry.LegacyText g = null;
                            string strsoThua = "";
                            long lgKey = Convert.ToInt64(ff.Key.Value.ToString().Split('.')[0]);
                            strsoThua = clsData.GetValueCol(BanDo, "sothua", lgKey);  
                            DPoint[] PPoint = new DPoint[2];
                            DPoint d = new DPoint();
                            d = ff.Geometry.Centroid; 
                             int fontS = 15;
                             TextStyle ts = cls.mpxMkTextStyle(fontS, ".VnArial");
                            ts.Font.Size = fontSize;
                            ts.Font.TextDecoration = MapInfo.Styles.TextDecoration.Underline; 
                            MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();
                            g = MapInfo.Text.TextFactory.CreateLegacyText(mapControl1.Map.GetDisplayCoordSys(), d, Alignment.CenterCenter, strsoThua.ToString(), mapControl1.Map, ts.Font);
                            g.Layout.Angle = 0;
                            cs.ApplyStyle(ts);
                            cls.UpdateDoiTuong(table, g, "0", cs, fontS.ToString() + "," + System.Convert.ToDouble(string.Format("{0:E2}", mapControl1.Map.Zoom.Value)).ToString());
                       
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
         
        }
        public void HienThiTHuaBenCanh(Int16  KhoangCach) 
        {
            Table table = null;
            Table tableThuaDat = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            tableThuaDat = MapInfo.Engine.Session.Current.Catalog.GetTable(TenLopDat);
            //lấy tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count != 1)
            {
                return;
            }
            Feature f = (Feature)irfc[0];

            DRect rect = f.Geometry.Bounds;
            DPoint pt = f.Geometry.Centroid;
            PointF point = cls.ConvertPoinF(pt, mapControl1);
            //lấy tất cả các đối tượng nằm trong vùng được chọn
            IResultSetFeatureCollection fc = MapInfo.Engine.Session.Current.Catalog.Search(tableThuaDat, MapInfo.Mapping.SearchInfoFactory.SearchWithinScreenRadius(mapControl1.Map.Layers[LayerName].Map, point, KhoangCach, ContainsType.Centroid));
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(fc);
            foreach (Feature ff in fc)
            { 
               
                string strsoThua = "";
                long lgKey = Convert.ToInt64(ff.Key.Value.ToString().Split('.')[0]);
                strsoThua = clsData.GetValueCol(BanDo, "sothua", lgKey); 
                DPoint d = new DPoint();
                d = ff.Geometry.Centroid;      
                int ktFont = 15;
                TextStyle ts = cls.mpxMkTextStyle(ktFont, ".VnArial");
                ts.Font.Size=ktFont;
                 MapInfo.Geometry.LegacyText g = MapInfo.Text.TextFactory.CreateLegacyText(mapControl1.Map.GetDisplayCoordSys(), d, Alignment.CenterCenter, strsoThua.ToString(), mapControl1.Map, ts.Font);
                MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();
                cs.ApplyStyle(ts);
                cls.UpdateDoiTuong(table, g, "0", cs, ktFont.ToString() + "," + System.Convert.ToDouble(string.Format("{0:E2}", mapControl1.Map.Zoom.Value)).ToString());

            }
        }
        public void NhatKyNguoiDung(string ChucNang, string MoTa)
        {
            prjNhatKyNguoiDung.clsNhatKyNguoiDung clsNhatky = new prjNhatKyNguoiDung.clsNhatKyNguoiDung();
            clsNhatky.Connection = strConnectData;
            clsNhatky.MaHoSoCapGCN = lgMaHoSoCapGCN.ToString() ;
            clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh;
            clsNhatky.NghiepVu = "Chức năng soạn hồ sơ kỹ thuật";
            clsNhatky.ChucNang = ChucNang;
            clsNhatky.MaThuaDat = FeatureID.ToString();
            clsNhatky.MoTa = MoTa;
            clsNhatky.DuongDanFile = Application.StartupPath;
            clsNhatky.LuuNhatKyNguoiDung();
        }
        private void toolStripSetView_Click(object sender, EventArgs e)
        {
            /* Zoom toàn bộ lớp bản đồ với tên lớp được cho trước */
            DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
            mapTools.ViewEntireLayer(mapControl1.Map, LayerName );
        }

        private void toolStrip2_MouseDown(object sender, MouseEventArgs e)
        {
           // cls.ToolMouseDown(toolStrip2, e);
        }

        private void toolStrip2_MouseMove(object sender, MouseEventArgs e)
        {
          //  cls.ToolMouseMove (toolStrip2, e);
        }

        private void toolConvertCadToMap_Click(object sender, EventArgs e)
        {
             string  Path  = "";
             Path = System.Windows.Forms.Application.StartupPath + @"\Tools\imutgui.exe";
                if (System.IO.File.Exists(Path) )
                 {
                    System.Diagnostics.Process.Start(Path);
                  }else{
                     MessageBox.Show("Kiểm tra lại file thực thi Convert File!!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }

        private void toolImportFileMap_Click(object sender, EventArgs e)
        {
             OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Title = "Chon tai lieu";
            dlgOpenFile.Filter = "Table File Tab (*.Tab)|*.Tab";
            if (dlgOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {

                MapInfo.Data.Table tabTmp = MapInfo.Engine.Session.Current.Catalog.OpenTable(dlgOpenFile.FileName); 
                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tabTmp, MapInfo.Data.SearchInfoFactory.SearchAll());
                //bang tren map hien thoi
                MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                IResultSetFeatureCollection irfcTmp = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());
                int i = 0;
                foreach (Feature f in irfc)
                {
                    try
                    {
                        tab.DeleteFeature(irfcTmp[i]);
                    }
                    catch (Exception ex) { }
                    tab.InsertFeature(f);
                    //CompositeStyle cs = new CompositeStyle();
                    //if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                    //{
                    //    int Size = 1;
                    //    //lay font size
                    //    LegacyText txt = (LegacyText)f.Geometry;
                    //    TextStyle ts = (TextStyle)f.Style ;
                    //    string fontsize = 0;
                    //    double fs = Convert.ToDouble(fontsize);
                    //    if (ts.Font.Size  == 0 )
                    //    {
                    //        Size = 1;
                    //    } 
                    //    ts.Font.Size = Size;
                    //    MapInfo.Geometry.LegacyText gValue = new LegacyText(mapControl1.Map.GetDisplayCoordSys(), (LegacyText)f.Geometry);
                    //    MapInfo.Geometry.LegacyText g = new MapInfo.Geometry.LegacyText(mapControl1.Map.GetDisplayCoordSys(), txt.TextBounds, gValue.Layout.Angle, gValue.Caption);
                    //    cs.ApplyStyle(ts);
                    //    cls.UpdateDoiTuong(tab, g, MaDT, cs, Size.ToString());
                    //}
                    //else
                    //{
                    //    cs.ApplyStyle(f.Style);
                    //    cls.UpdateDoiTuong(tab, f.Geometry, MaDT, cs, "");
                    //}
                
                    i = i + 1;
                }
            }
        }

        private void layerControl1_Load(object sender, EventArgs e)
        {

        }



        //private void button2_Click(object sender, System.EventArgs e)
        //{ 
        //    Graphics g = panel1.CreateGraphics(); 
        //    for (float a = 0; a <= 360; a += 5) 
        //    { 
        //        panel1.Refresh();
        //        DrawDemo(g, "Hello World", a);
        //        System.Threading.Thread.Sleep(500);
        //    } 
        //} 
        //private void DrawDemo(Graphics g, string text, float a) 
        //{ 
        //    Font f1 = new Font("Arial", 10);
        //    g.ResetTransform();
        //    g.TranslateTransform(g.VisibleClipBounds.Width / 2, g.VisibleClipBounds.Height / 2);
        //    g.DrawString(text, f1, new SolidBrush(Color.Green), 0, 0);
        //    SizeF s1 = g.MeasureString(text, f1); 
        //    g.DrawRectangle(new Pen(Color.Green), 0, 0, s1.Width, s1.Height); 
        //    g.RotateTransform(a, MatrixOrder.Prepend);
        //    g.DrawString(text, f1, new SolidBrush(Color.Blue), 0, 0);
        //    SizeF s2 = g.MeasureString(text, f1);
        //    g.DrawRectangle(new Pen(Color.Blue), 0, 0, s2.Width, s2.Height); 
        //    PointF[] points = { new PointF(0, 0), new PointF(s2.Width, 0), new PointF(s2.Width, s2.Height), new PointF(0, s2.Height) };
        //    g.TransformPoints(CoordinateSpace.Page, CoordinateSpace.World, points); 
        //    g.ResetTransform(); 
        //    g.DrawRectangle(new Pen(Color.Red), EnclosingRectangle(points)); 
        //}
        //private Rectangle EnclosingRectangle(PointF[] points) 
        //{ float x1 = float.MaxValue;
        //    float x2 = float.MinValue;
        //    float y1 = float.MaxValue;
        //    float y2 = float.MinValue;
        //    foreach (PointF p in points) {
        //        if (x1 > p.X) x1 = p.X; 
        //        if (x2 < p.X) x2 = p.X;
        //        if (y1 > p.Y) y1 = p.Y; 
        //        if (y2 < p.Y) y2 = p.Y;
        //    } 
        //    return Rectangle.Ceiling(RectangleF.FromLTRB(x1, y1, x2, y2)); }

    }
}
