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
using MapInfo.Windows.Dialogs;
using DMC.GIS.Common;
using MapInfo.Data.Find;
using MapInfo.Text;
using System.Data.SqlClient;
using System;


namespace DMC.GIS.Common
{
    public  class clsMainSoanHoSo
    {
        double inch = 0.07028;
        private const int  LOGPIXELSY = 90 ;
        private const int LOGPIXELSX = 88;
        private Spacing _textSpacing = Spacing.Single;
        private TextStyle _textStyle = null;
        private double _conSize = 201218534;
        public string strConnection;
        private string strConnectionstring;
        private string strLayerName;
        public SqlConnection conn;
        public string SererName;
        public string DatabaseName;
        public string UID;
        public string Upass;
        private string strBanDo;
        private string strMaDonViHanhChinh = "";
        private double dlHeightFont = 0;
        private double dlTyLeZoomView = 0;
        private double dlDienTichThua = 0;

        public double DienTichThua
        {
            get { return dlDienTichThua; }
            set { dlDienTichThua = value; }
        }
        private DRect drLable;

        public DRect DrecLable
        {
            get { return drLable; }
            set { drLable = value; }
        }
        public double TyLeZoomView
        {
            get { return dlTyLeZoomView; }
            set { dlTyLeZoomView = value; }
        }
        public double HeightFont
        {
            get { return dlHeightFont; }
            set { dlHeightFont = value; }
        }
        private double dlWidthFont = 0;

        public double WidthFont
        {
            get { return dlWidthFont; }
            set { dlWidthFont = value; }
        }
        private string strFontName = "";

        public string MyFontName
        {
            get { return strFontName; }
            set { strFontName = value; }
        }
        public string MaDonViHanhChinh {
            set { strMaDonViHanhChinh = value; }
            get { return strMaDonViHanhChinh; }
        }

        public System.Drawing.Point MousePositionBeforeMoved, LocationBeforeMoved;
        //public string LayerName;
        private clsDatabase clsData = new clsDatabase();
        public void BanDo(string value)
        {
            strBanDo= value;
        }
        public void Connectionstring(string value)
        {
            strConnectionstring = value;
        }
        public void LayerName(string value)
        {
            strLayerName = value;
        }
        public void SetConnection(string value)
        {
            strConnection = value;
        }
        public string GetConnection()
        {
            return  strConnection;
        }
        public SqlConnection getCon(string strConnection)
        {

            try
            {
                
                
                string strConnec;
                strConnec = "";

                strConnec = strConnection;
                conn = new SqlConnection();
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
        //ham chức nang thực hiện chức năng mở 1 bảng của bản đồ và đưa lên bản đồ
        public void OpenLayer(ref MapControl mapControl, ref FeatureLayer lyrs, string strAlias, string strConnection, string strQuery)
        {
            try
            {
                MIConnection Connection = new MIConnection();
                
                Connection.Open();
                MapInfo.Data.Table[] tables = new MapInfo.Data.Table[1];
                TableInfoServer tis1 = new TableInfoServer(strAlias, strConnection, strQuery, MapInfo.Data.ServerToolkit.Odbc);
                tables[0] = Connection.Catalog.OpenTable(tis1);
                lyrs = new FeatureLayer(tables[0]);
                mapControl.Map.Layers.Add(lyrs);
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public Table GetNewLayer(string strAlias, string strConnection, string strQuery)
        {
            MapInfo.Data.Table[] tables = new Table[1];
            try
            {
                MIConnection Connection = new MIConnection();
                
                Connection.Open();

                TableInfoServer tis1 = new TableInfoServer(strAlias, strConnection, strQuery, MapInfo.Data.ServerToolkit.Odbc);
                tables[0] = Connection.Catalog.OpenTable(tis1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tables[0];

        }
        //ham chức năng thực thi chức năng chuyển từ Polygon sang polyline
        public void ConvertToPolyline(MapControl pMap, string LayerName, ToolStripProgressBar staProcess)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (pMap.Map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là "strLayerName" trong bản đồ "map" */
            //if (map.Layers[strLayerName] == null)
            Table table = null;
            Table ThuaDat = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            ThuaDat = MapInfo.Engine.Session.Current.Catalog.GetTable("tmp");
            if (MapInfo.Engine.Session.Current.Catalog.GetTable("Polyline") != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable("Polyline");
            }
          
            //chọn tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            /* Chắc chắn rằng tồn tại Feature trong FeatureCollection */
            if (irfc == null)
                return;
            staProcess.Maximum = irfc.Count;
            staProcess.Value = 0;
            CompositeStyle cs = new CompositeStyle();
            MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
            foreach (MapInfo.Data.Feature f in irfc)
            {
                string DoiTuong;
                DoiTuong = GetMaDoiTuong(f, strLayerName);
                DPoint[] d = null;
                try
                {
                    if (f.Geometry.GetType().ToString() == "MapInfo.Geometry.MultiPolygon")
                    {
                        MapInfo.Geometry.MultiPolygon multiPolygon = (MapInfo.Geometry.MultiPolygon)f.Geometry;
                        foreach (MapInfo.Geometry.Polygon polygon in multiPolygon)
                        {
                            if (polygon.InteriorCount > 0)
                            {
                                for (int i = 0; i < polygon.InteriorCount; i++)
                                {
                                    DPoint[] dIn = null;
                                    dIn = polygon.Interior(i).SamplePoints();
                                    //tao cac doan thang tu danh sach diem vua chon duoc vao bang dt
                                    MapInfo.Data.Table dt = CreateTable(pMap.Map, table, "Polyline");
                                    CreateNewLine(pMap, dt, dIn);
                                    //
                                    MapInfo.Data.IResultSetFeatureCollection fcNewLine = Session.Current.Catalog.Search(dt, MapInfo.Data.SearchInfoFactory.SearchAll());
                                    Session.Current.Selections.DefaultSelection.Add(fcNewLine);

                                    Feature feature = new Feature(dt.TableInfo.Columns);
                                    /* Tạo Feature từ tập hợp các Feature vừa chọn để combine */
                                    feature = featureProcessor.Combine(fcNewLine);
                                    UpdateDoiTuong(table, feature.Geometry, "101", cs,"0");
                                    //table.InsertFeature(feature);
                                    dt.Close();
                                }
                            }
                        }
                        foreach (MapInfo.Geometry.Polygon polygon in multiPolygon)
                        {
                            d = polygon.Exterior.SamplePoints();
                            //tao cac doan thang tu danh sach diem vua chon duoc vao bang dt
                            MapInfo.Data.Table dt = CreateTable(pMap.Map, table, "Polyline");
                            CreateNewLine(pMap, dt, d);
                            //
                            MapInfo.Data.IResultSetFeatureCollection fcNewLine = Session.Current.Catalog.Search(dt, MapInfo.Data.SearchInfoFactory.SearchAll());
                            Session.Current.Selections.DefaultSelection.Add(fcNewLine);

                            Feature feature = new Feature(dt.TableInfo.Columns);
                            /* Tạo Feature từ tập hợp các Feature vừa chọn để combine */
                            feature = featureProcessor.Combine(fcNewLine);
                            UpdateDoiTuong(table, feature.Geometry, "101", cs,"0");
                            //table.InsertFeature(feature);
                            dt.Close();
                        }
                        /* Xóa Feature sau khi đã Break */
                        table.DeleteFeature(f);
                        // CombineFeatures(pMap.Map , LayerName, staProcess);

                    }

                    staProcess.Value = staProcess.Value + 1;
                }
            
            catch(Exception ex ){}
            }
            bool ktLine = true;
            try
            {
                foreach (MapInfo.Data.Feature f in irfc)
                {
                    if (f.Geometry.GetType().ToString() != "MapInfo.Geometry.MultiCurve")
                    {
                        ktLine = false;
                        goto Nhan;
                    }
                }
            Nhan:
                if (ktLine)
                {
                    Feature feature = new Feature(table.TableInfo.Columns);
                    feature = featureProcessor.Combine(irfc);
                    foreach (MapInfo.Data.Feature f in irfc)
                    {
                        if (f.Geometry.GetType().ToString() == "MapInfo.Geometry.MultiCurve")
                        {
                            table.DeleteFeature(f);
                        }
                    }
                    UpdateDoiTuong(table, feature.Geometry, "101", cs,"0");
                   // table.InsertFeature(feature);
                }
            }catch(Exception ex ){}
        }      
        //hàm chức năng  thực thi việc chuyển từ thửa sang cạnh
        public void BreakFeatureCollectionInLayer(MapInfo.Mapping.Map map, string strLayerName, ToolStripProgressBar staProcess)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là "strLayerName" trong bản đồ "map" */
            //if (map.Layers[strLayerName] == null)
            Table table = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerName);
            //chọn tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];

            //MapInfo.Data.IResultSetFeatureCollection irfc;
            //irfc = SelectFeatures(map, strLayerName);
            /* Chắc chắn rằng tồn tại Feature trong FeatureCollection */
            if (irfc == null)
                return;
            if (irfc.Count  == 0)
                return;
            staProcess.Maximum = irfc.Count;
            staProcess.Value = 0;
            foreach (MapInfo.Data.Feature f in irfc)
            {
                try
                {
                    string DoiTuong;
                    DoiTuong = GetMaDoiTuong(f, strLayerName);
                    CompositeStyle cs = new CompositeStyle();
                    if (f.Geometry.GetType().ToString() == "MapInfo.Geometry.MultiCurve")
                    {

                        MapInfo.Geometry.MultiCurve multiCurve = (MapInfo.Geometry.MultiCurve)f.Geometry;
                        foreach (MapInfo.Geometry.Curve curve in multiCurve)
                        {
                            MapInfo.Geometry.DPoint[] dPoints;
                            dPoints = curve.SamplePoints();
                            cs.ApplyStyle(f.Style);
                            MultiPointToLines(map, strLayerName, dPoints, cs, DoiTuong);
                        }
                        /* Xóa Feature sau khi đã Break */
                        DeleteFeature(map, f, strLayerName);
                    }
                   
                   staProcess.Value = staProcess.Value + 1;
                }catch(Exception ex ){} 
            }
        }
        //hàm thực thi việc xoá đối tượng được chọn
        public void DeleteFeature(MapInfo.Mapping.Map map, MapInfo.Data.Feature feature, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại Feature cần xóa */
            if (feature == null)
                return;
            /* Khai báo FeatureLayer cần thực thi */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;
            /* Xóa Feature sau khi đã Break */
            table.DeleteFeature(feature);
        }
        //hàm chuyển từ thửa sang cạnh
        public void PolygonToLines(MapInfo.Mapping.Map map, MapInfo.Geometry.Polygon polygon, string strLayerName, CompositeStyle cs, string DoiTuong)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strFeatureLayer */
            if (map.Layers[strLayerName] == null)
                return;
            if (polygon == null)
                return;
            /* Chắc chắn rằng tồn tại polygon */
            MapInfo.Geometry.DPoint[] dPointTemp = new MapInfo.Geometry.DPoint[2];
            MapInfo.Geometry.DPoint[] dPointsPolygon = polygon.Exterior.SamplePoints();
            MultiPointToLines(map, strLayerName, dPointsPolygon, cs, DoiTuong);
        }
        //hàm chức năng tạo đường từ tập hợp cạnh
        public void CreateLine(MapInfo.Mapping.Map map, MapInfo.Geometry.DPoint[] dPoints, string strLayerName, CompositeStyle cs)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            /* Khai báo FeatureLayer cần thực thi */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;
            /* Khai báo FeatureGeometry dạng Line với tọa độ và Hệ tọa độ đã xác định */
            //MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiCurve(map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, dPoints);
            MapInfo.Geometry.CoordSys coordsys = featureLayer.CoordSys;
            MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiCurve(coordsys, MapInfo.Geometry.CurveSegmentType.Linear, dPoints);

            /* Khai báo kiểu Line */
            MapInfo.Styles.SimpleLineStyle bl = new MapInfo.Styles.SimpleLineStyle();
            // MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(null, bl, null, null);
            /* Khai báo Feature dạng Line cần tạo */
            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Gán giá trị cho Feature cần tạo */
            feature.Geometry = g;
            feature.Style = cs;
            /* Add Line vào FeatureLayer cho trước */
            featureLayer.Table.InsertFeature(feature);
        }
        //hàm chức năng lấy tập hợp các đối tượng được chọn
        public MapInfo.Data.IResultSetFeatureCollection SelectFeatures(MapInfo.Mapping.Map map, string strLayerName)
        {
            if (map.Layers[strLayerName] == null)
                return null;
            if (map.Layers[strLayerName] == null)
                return null;
            if (map.Layers[strLayerName].Enabled == false)
                return null;
            MapInfo.Engine.ISession session = MapInfo.Engine.Session.Current;
            MapInfo.Data.Table table = session.Catalog[map.Layers[strLayerName].Alias];
            MapInfo.Data.IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchAll());
            return irfc;
        }
        public bool MultiPointToLines(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint[] dPoints, CompositeStyle cs, string DoiTuong)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return false;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName trong đối tượng bản đồ map */
            if (map.Layers[strLayerName] == null)
                return false;
            /* Khai báo và khởi tạo biến tạm kiểu điểm */
            MapInfo.Geometry.DPoint[] dPointTemp = new MapInfo.Geometry.DPoint[2];
            Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerName);
            for (int i = 0; i < dPoints.Length - 1; i++)
            {
                dPointTemp[0] = dPoints[i];
                dPointTemp[1] = dPoints[i + 1];
                /* Tạo Line */
                MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiCurve(map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, dPointTemp);
                //update đối tượng vào bảng
                UpdateDoiTuong(table, g, "101", cs,"0");
            }
            return true;
        }
        //ham dung de tang kich thuoc cua canh giu nguyen trang thai goc quay
        public DPoint[] TangToaDoDiem(DPoint[] OldPoint, double Tyle, double ChieuDai)
        {
            DPoint[] NewP = new DPoint[OldPoint.Length];
            double x, y;
            x = 0;
            y = 0;
            if (Tyle == 0)
            {
                x = 0;
                y = ChieuDai;
            }
            else
            {
                if (Tyle == 1)
                {
                    x = ChieuDai;
                    y = 0;
                }
                else
                {
                    x = ChieuDai;
                    y = x / Tyle;
                }
            }

            double xc1, xc2, xc3, xc4, yc1, yc2, yc3, yc4, xd1, xd2, xd3, xd4, yd1, yd2, yd3, yd4;
            DPoint c1, c2, c3, c4, d1, d2, d3, d4;
            //toa do điểm C
            xc1 = OldPoint[0].x - x / 2;
            yc1 = OldPoint[0].y - y / 2;
            c1.x = xc1;
            c1.y = yc1;

            xc3 = OldPoint[0].x + x / 2;
            yc3 = OldPoint[0].y - y / 2;
            c3.x = xc3;
            c3.y = yc3;

            xc2 = OldPoint[0].x - x / 2;
            yc2 = OldPoint[0].y + y / 2;
            c2.x = xc2;
            c2.y = yc2;

            xc4 = OldPoint[0].x + x / 2;
            yc4 = OldPoint[0].y + y / 2;
            c4.x = xc4;
            c4.y = yc4;

            //toa do diem D
            xd1 = OldPoint[1].x - x / 2;
            yd1 = OldPoint[1].y - y / 2;
            d1.x = xd1;
            d1.y = yd1;

            xd3 = OldPoint[1].x + x / 2;
            yd3 = OldPoint[1].y - y / 2;
            d3.x = xd3;
            d3.y = yd3;

            xd2 = OldPoint[1].x - x / 2;
            yd2 = OldPoint[1].y + y / 2;
            d2.x = xd2;
            d2.y = yd2;

            xd4 = OldPoint[1].x + x / 2;
            yd4 = OldPoint[1].y + y / 2;
            d4.x = xd4;
            d4.y = yd4;

            if (TangCanh(OldPoint[0], OldPoint[1], c1, d1)[0].x != 0)
            {
                NewP[0] = c1;
                NewP[1] = d1;
            }
            if (TangCanh(OldPoint[0], OldPoint[1], c1, d2)[0].x != 0)
            {
                NewP[0] = c1;
                NewP[1] = d2;
            } if (TangCanh(OldPoint[0], OldPoint[1], c1, d3)[0].x != 0)
            {
                NewP[0] = c1;
                NewP[1] = d3;
            } if (TangCanh(OldPoint[0], OldPoint[1], c1, d4)[0].x != 0)
            {
                NewP[0] = c1;
                NewP[1] = d4;
            } if (TangCanh(OldPoint[0], OldPoint[1], c2, d1)[0].x != 0)
            {
                NewP[0] = c2;
                NewP[1] = d1;
            } if (TangCanh(OldPoint[0], OldPoint[1], c2, d2)[0].x != 0)
            {
                NewP[0] = c2;
                NewP[1] = d2;
            } if (TangCanh(OldPoint[0], OldPoint[1], c2, d3)[0].x != 0)
            {
                NewP[0] = c2;
                NewP[1] = d3;
            } if (TangCanh(OldPoint[0], OldPoint[1], c2, d4)[0].x != 0)
            {
                NewP[0] = c2;
                NewP[1] = d4;
            } if (TangCanh(OldPoint[0], OldPoint[1], c3, d1)[0].x != 0)
            {
                NewP[0] = c3;
                NewP[1] = d1;
            } if (TangCanh(OldPoint[0], OldPoint[1], c3, d2)[0].x != 0)
            {
                NewP[0] = c3;
                NewP[1] = d2;
            } if (TangCanh(OldPoint[0], OldPoint[1], c3, d3)[0].x != 0)
            {
                NewP[0] = c3;
                NewP[1] = d3;
            }
            if (TangCanh(OldPoint[0], OldPoint[1], c3, d4)[0].x != 0)
            {
                NewP[0] = c3;
                NewP[1] = d4;
            } if (TangCanh(OldPoint[0], OldPoint[1], c4, d1)[0].x != 0)
            {
                NewP[0] = c4;
                NewP[1] = d1;
            } if (TangCanh(OldPoint[0], OldPoint[1], c4, d2)[0].x != 0)
            {
                NewP[0] = c4;
                NewP[1] = d2;
            } if (TangCanh(OldPoint[0], OldPoint[1], c4, d3)[0].x != 0)
            {
                NewP[0] = c4;
                NewP[1] = d3;
            } if (TangCanh(OldPoint[0], OldPoint[1], c4, d4)[0].x != 0)
            {
                NewP[0] = c4;
                NewP[1] = d4;
            }

            return NewP;
        }
        //hàm thực hiện chức năng tăng độ dài cạnh
        public DPoint[] TangCanh(DPoint a, DPoint b, DPoint c, DPoint d)
        {
            DPoint[] cd = new DPoint[2];
            double GocXetBAC;
            double GocXetABD;
            GocXetBAC = XetGoc180(b, a, c);
            GocXetABD = XetGoc180(a, b, d);
            if ((GocXetBAC == 180) && (GocXetABD == 180))
            {
                cd[0] = c;
                cd[1] = d;
            }
            return cd;
        }
        //hàm thực hiện chức năng giảm độ dài của dạnh
        public DPoint[] GiamCanh(DPoint a, DPoint b, DPoint c, DPoint d)
        {
            DPoint[] cd = new DPoint[2];
            double GocXetACD;
            double GocXetCDB;
            GocXetACD = XetGoc180(a, c, d);
            GocXetCDB = XetGoc180(c, d, b);
            if ((GocXetACD == 180) && (GocXetCDB == 180))
            {
                cd[0] = c;
                cd[1] = d;
            }
            return cd;
        }
        //hàm thưc hiện chức năng tính toạ độ góc khi biết 3 điểm
        public double XetGoc180(DPoint p1, DPoint p2, DPoint p3)
        {
            double goc;
            //vecter u(a1,b1),v(a2,b2) qua 2 duong thang p2p1,p2p3 => cos (goc)=(a1a2 + b1b2)/(sqrt(a1&a1 + b1*b1)* sqrt(a1*a1 + b2*b2))
            goc = Math.Round(((p1.x - p2.x) * (p3.x - p2.x) + (p1.y - p2.y) * (p3.y - p2.y)) / (Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y)) * Math.Sqrt((p3.x - p2.x) * (p3.x - p2.x) + (p3.y - p2.y) * (p3.y - p2.y))), 4);
            DPoint PointXet = new DPoint();
            PointXet.x = (p1.x + p3.x) / 2;
            PointXet.y = (p1.y + p3.y) / 2;
            double tmpGoc;
            tmpGoc = Math.Acos(goc) * 180 / Math.PI;
            return tmpGoc;
        }
        //chon nguoc doi tuong
        //public void ChonNguocDoiTuong(string LayerName)
        //{
        //    //chọn bảng hiện thời
        //    MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
        //    //lấy tất cả các đối tượng đựoc chọn
        //    IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
        //    IResultSetFeatureCollection fc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchAll());
        //    if (irfc == null)
        //    {
        //        return;
        //    }
        //    if (irfc.Count == 0)
        //    {
        //        return;
        //    }
        //    string sWhere = "";
        //   string[] MaDoiTuong = new string[irfc.Count];
        //   string[] MangDoiTuong = new string[irfc.Count];
        //    int j = 0;
        //    for (int i = 0; i < irfc.Count; i++ )
        //    {
        //        string DoiTuong;
        //        DoiTuong = GetMaDoiTuong(irfc[i],LayerName );
        //        MaDoiTuong[i] = DoiTuong;
        //        sWhere = sWhere + "MaDoiTuong= " + DoiTuong + " or "+"";
                
        //    }
        //    sWhere = sWhere.Remove(sWhere.Length - 3);
        //    if (sWhere == "MaDoiTuong=  ")
        //    {
        //            return;
        //        }
        //   IResultSetFeatureCollection myfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere(sWhere));

        //   foreach (Feature f in irfc)
        //    {
        //        myfc.Remove(f);
        //    }
        //        MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
        //    //chọn lại các đối tượng
        //        MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(myfc);

        //}
        public void ChonNguocDoiTuong(string LayerName)
        {
            //chọn bảng hiện thời
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tất cả các đối tượng đựoc chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            IResultSetFeatureCollection fc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchAll());
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
                fc.Remove(f);
            }
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            //chọn lại các đối tượng
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(fc);

        }
        //ham dung de giam kich thuoc cua canh giu nguyen trang thai goc quay
        public DPoint[] GiamToaDoDiem(DPoint[] OldPoint, double Tyle, double ChieuDai)
        {
            DPoint[] NewP = new DPoint[OldPoint.Length];
            double x, y;
            x = 0;
            y = 0;
            if (Tyle == 0)
            {
                x = 0;
                y = ChieuDai;
            }
            else
            {
                if (Tyle == 1)
                {
                    x = ChieuDai;
                    y = 0;
                }
                else
                {
                    x = ChieuDai;
                    y = x / Tyle;
                }
            }

            double xc1, xc2, xc3, xc4, yc1, yc2, yc3, yc4, xd1, xd2, xd3, xd4, yd1, yd2, yd3, yd4;
            DPoint c1, c2, c3, c4, d1, d2, d3, d4;
            //toa do điểm C
            xc1 = OldPoint[0].x - x / 2;
            yc1 = OldPoint[0].y - y / 2;
            c1.x = xc1;
            c1.y = yc1;

            xc3 = OldPoint[0].x + x / 2;
            yc3 = OldPoint[0].y - y / 2;
            c3.x = xc3;
            c3.y = yc3;

            xc2 = OldPoint[0].x - x / 2;
            yc2 = OldPoint[0].y + y / 2;
            c2.x = xc2;
            c2.y = yc2;

            xc4 = OldPoint[0].x + x / 2;
            yc4 = OldPoint[0].y + y / 2;
            c4.x = xc4;
            c4.y = yc4;

            //toa do diem D
            xd1 = OldPoint[1].x - x / 2;
            yd1 = OldPoint[1].y - y / 2;
            d1.x = xd1;
            d1.y = yd1;

            xd3 = OldPoint[1].x + x / 2;
            yd3 = OldPoint[1].y - y / 2;
            d3.x = xd3;
            d3.y = yd3;

            xd2 = OldPoint[1].x - x / 2;
            yd2 = OldPoint[1].y + y / 2;
            d2.x = xd2;
            d2.y = yd2;

            xd4 = OldPoint[1].x + x / 2;
            yd4 = OldPoint[1].y + y / 2;
            d4.x = xd4;
            d4.y = yd4;

            if (GiamCanh(OldPoint[0], OldPoint[1], c1, d1)[0].x != 0)
            {
                NewP[0] = c1;
                NewP[1] = d1;
                goto Nhan;
            }
            if (GiamCanh(OldPoint[0], OldPoint[1], c1, d2)[0].x != 0)
            {
                NewP[0] = c1;
                NewP[1] = d2;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c1, d3)[0].x != 0)
            {
                NewP[0] = c1;
                NewP[1] = d3;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c1, d4)[0].x != 0)
            {
                NewP[0] = c1;
                NewP[1] = d4;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c2, d1)[0].x != 0)
            {
                NewP[0] = c2;
                NewP[1] = d1;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c2, d2)[0].x != 0)
            {
                NewP[0] = c2;
                NewP[1] = d2;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c2, d3)[0].x != 0)
            {
                NewP[0] = c2;
                NewP[1] = d3;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c2, d4)[0].x != 0)
            {
                NewP[0] = c2;
                NewP[1] = d4;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c3, d1)[0].x != 0)
            {
                NewP[0] = c3;
                NewP[1] = d1;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c3, d2)[0].x != 0)
            {
                NewP[0] = c3;
                NewP[1] = d2;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c3, d3)[0].x != 0)
            {
                NewP[0] = c3;
                NewP[1] = d3;
                goto Nhan;
            }
            if (GiamCanh(OldPoint[0], OldPoint[1], c3, d4)[0].x != 0)
            {
                NewP[0] = c3;
                NewP[1] = d4;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c4, d1)[0].x != 0)
            {
                NewP[0] = c4;
                NewP[1] = d1;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c4, d2)[0].x != 0)
            {
                NewP[0] = c4;
                NewP[1] = d2;
                goto Nhan;
            } if (TangCanh(OldPoint[0], OldPoint[1], c4, d3)[0].x != 0)
            {
                NewP[0] = c4;
                NewP[1] = d3;
                goto Nhan;
            } if (GiamCanh(OldPoint[0], OldPoint[1], c4, d4)[0].x != 0)
            {
                NewP[0] = c4;
                NewP[1] = d4;
                goto Nhan;
            }
        Nhan:
            return NewP;
            //DPoint[] NewP = new DPoint[OldPoint.Length];
            //double x, y;
            //x = ChieuDai;
            //y = x / Tyle;

            //if (OldPoint[0].x > OldPoint[1].x)
            //{
            //    if (OldPoint[0].y < OldPoint[1].y)
            //    {
            //        //tinh toa do x cua diem thu 2]
            //        NewP[0].x = OldPoint[0].x - x;
            //        //tinh toa do y cua diem thu 2
            //        NewP[0].y = OldPoint[0].y - y;
            //        //tinh toa do x cua diem thu 2]
            //        NewP[1].x = OldPoint[1].x + x;
            //        //tinh toa do y cua diem thu 2
            //        NewP[1].y = OldPoint[1].y + y;
            //    }
            //    else
            //    {
            //        //tinh toa do x cua diem thu 2]
            //        NewP[0].x = OldPoint[0].x - x;
            //        //tinh toa do y cua diem thu 2
            //        NewP[0].y = OldPoint[0].y - y;
            //        //tinh toa do x cua diem thu 2]
            //        NewP[1].x = OldPoint[1].x + x;
            //        //tinh toa do y cua diem thu 2
            //        NewP[1].y = OldPoint[1].y + y;
            //    }
            //}
            //else
            //{

            //    if (OldPoint[0].y < OldPoint[1].y)
            //    {
            //        //tinh toa do x cua diem thu 2]
            //        NewP[0].x = OldPoint[0].x + x;
            //        //tinh toa do y cua diem thu 2
            //        NewP[0].y = OldPoint[0].y + y;
            //        //tinh toa do x cua diem thu 2]
            //        NewP[1].x = OldPoint[1].x - x;
            //        //tinh toa do y cua diem thu 2
            //        NewP[1].y = OldPoint[1].y - y;
            //    }
            //    else
            //    {
            //        //tinh toa do x cua diem thu 2]
            //        NewP[0].x = OldPoint[0].x + x;
            //        //tinh toa do y cua diem thu 2
            //        NewP[0].y = OldPoint[0].y + y;
            //        //tinh toa do x cua diem thu 2]
            //        NewP[1].x = OldPoint[1].x - x;
            //        //tinh toa do y cua diem thu 2
            //        NewP[1].y = OldPoint[1].y - y;
            //    }
            //}
            //return NewP;
        }

        //TINH GOC TAO BOI 3 DIEM (GOC NAM GIUA P2
        public double HeSoGoc3DinhManHinh(MapControl pMap, Feature f, PointF p1, PointF p2, PointF p3)
        {

            double goc;
            //vecter u(a1,b1),v(a2,b2) qua 2 duong thang p2p1,p2p3 => cos (goc)=(a1a2 + b1b2)/(sqrt(a1&a1 + b1*b1)* sqrt(a1*a1 + b2*b2))
            goc = ((p1.X - p2.X) * (p3.X - p2.X) + (p1.Y - p2.Y) * (p3.Y - p2.Y)) / (Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y)) * Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y)));
            PointF PointXet = new PointF();
            PointXet.X = (p1.X + p3.X) / 2;
            PointXet.Y = (p1.Y + p3.Y) / 2;

            double tmpGoc;
            tmpGoc = Math.Acos(goc) * 180 / Math.PI;
            if (!f.Geometry.ContainsPoint(ConvertDpoint(PointXet, pMap)))
            {
                tmpGoc = 360 - tmpGoc;
            }
            return tmpGoc;
        }
        //tinh he so goc cua 3 dinh khi biet toa do cua 3 dinh do (toa do thuc)
        public double HeSoGoc3Dinh(Feature f, DPoint p1, DPoint p2, DPoint p3)
        {
            //TINH GOC TAO BOI 3 DIEM (GOC NAM GIUA P2
            double goc;
            //vecter u(a1,b1),v(a2,b2) qua 2 duong thang p2p1,p2p3 => cos (goc)=(a1a2 + b1b2)/(sqrt(a1&a1 + b1*b1)* sqrt(a1*a1 + b2*b2))
            goc = ((p1.x - p2.x) * (p3.x - p2.x) + (p1.y - p2.y) * (p3.y - p2.y)) / (Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y)) * Math.Sqrt((p3.x - p2.x) * (p3.x - p2.x) + (p3.y - p2.y) * (p3.y - p2.y)));
            DPoint PointXet = new DPoint();
            PointXet.x = (p1.x + p3.x) / 2;
            PointXet.y = (p1.y + p3.y) / 2;
            double tmpGoc;
            tmpGoc = Math.Acos(goc) * 180 / Math.PI;
            if (!f.Geometry.ContainsPoint(PointXet))
            {
                tmpGoc = 360 - tmpGoc;
            }
            return tmpGoc;
        }
        //tinh he so goc cua 3 dinh khi biet toa do cua 3 dinh do (toa do thuc)
        public double HeSoGoc( DPoint p1, DPoint p2, DPoint p3)
        {
            //TINH GOC TAO BOI 3 DIEM (GOC NAM GIUA P2
            double goc;
            //vecter u(a1,b1),v(a2,b2) qua 2 duong thang p2p1,p2p3 => cos (goc)=(a1a2 + b1b2)/(sqrt(a1&a1 + b1*b1)* sqrt(a1*a1 + b2*b2))
            goc = Math.Round( ((p1.x - p2.x) * (p3.x - p2.x) + (p1.y - p2.y) * (p3.y - p2.y)) / (Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y)) * Math.Sqrt((p3.x - p2.x) * (p3.x - p2.x) + (p3.y - p2.y) * (p3.y - p2.y))),3);
            DPoint PointXet = new DPoint();
            PointXet.x = (p1.x + p3.x) / 2;
            PointXet.y = (p1.y + p3.y) / 2;
            double tmpGoc;
            tmpGoc = Math.Acos(goc) * 180 / Math.PI;
            return tmpGoc;
        }
        //chuyen tu toa do thuc ve toa do man hinh
        public PointF ConvertPoinF(DPoint d, MapControl map)
        {
            System.Drawing.PointF pointDisplay = new PointF();
            if (map.Map != null)
            {
                MapInfo.Geometry.DisplayTransform converter = map.Map.DisplayTransform;
                converter.ToDisplay(d, out pointDisplay);
            }
            return pointDisplay;

        }
        public System.Drawing.Point  ConvertPoint(DPoint d, MapControl map)
        {
            System.Drawing.Point pointDisplay = new System.Drawing.Point();
            if (map.Map != null)
            {
                MapInfo.Geometry.DisplayTransform converter = map.Map.DisplayTransform;
                converter.ToDisplay(d, out pointDisplay);
            }
            return pointDisplay;

        }
        //chuyen tu toa do man hinh ve toa do thuc
        public DPoint ConvertDpoint(PointF Point, MapControl map)
        {
            DPoint pointDisplay = new DPoint();
            if (map.Map != null)
            {
                MapInfo.Geometry.DisplayTransform converter = map.Map.DisplayTransform;
                converter.FromDisplay(Point, out pointDisplay);
            }
            return pointDisplay;

        }
        //tao moi bang tmp
        public void NewTmpTableBanDo(MapControl mapControl, string BanDo, string LayerName)
        {
            Table TableBando = null;
            string strBanDo;
            strBanDo = "";
            //khai bao chuoi select
            strBanDo = "Select * from " + BanDo + "";
            //Mo bang moi
            if (MapInfo.Engine.Session.Current.Catalog.GetTable("BanDo") != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable("BanDo");
            }
            TableBando = GetNewLayer("BanDo", strConnectionstring, strBanDo);
            //Tao mot Table moi
            Table dt = null;
            if (MapInfo.Engine.Session.Current.Catalog.GetTable("tmpBanDo") != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable("tmpBanDo");
            }

            dt = CreateDataTable(mapControl.Map, "BanDo", "tmpBanDo", TableBando);
            Table tab = null;
            //goi bang hien hien thoi
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerName);
            IResultSetFeatureCollection Lfc = Session.Current.Selections.DefaultSelection[tab];
            if (Lfc == null)
            {
                return;
            }
            if (Lfc.Count == 0)
            {
                MessageBox.Show("Chọn đối tượng !!");
                return;
            }
            DPoint Center = new DPoint();
            DRect rect = new DRect();
            foreach (Feature f in Lfc)
            {
                //lay toa do tam va duong bao cua layer hient hoi
                Center = f.Geometry.Centroid;
                rect = f.Geometry.Bounds;
            }
            mapControl.Map.SetView(rect, mapControl.Map.GetDisplayCoordSys());

            PointF point = ConvertPoinF(Center, mapControl);
            //lấy tất cả các đối tượng nằm trong vùng được chọn
            IResultSetFeatureCollection irfc = MapInfo.Engine.Session.Current.Catalog.Search(TableBando, MapInfo.Mapping.SearchInfoFactory.SearchWithinScreenRadius(mapControl.Map.Layers[strLayerName].Map, point, 5000, ContainsType.Centroid));
           // dt.InsertFeatures(irfc);
            foreach (Feature f in irfc)
            {
                Feature fTmp = null;
                fTmp = new Feature(dt.TableInfo.Columns);
                fTmp.Geometry = f.Geometry;
                fTmp.Style = f.Style;
                dt.InsertFeature(fTmp);
            }
        }
        public void ConvertTmpBanDo_Canh(MapControl map, ToolStripProgressBar staProcess, string  strBanDo, string LayerName)
        {
            NewTmpTableBanDo(map,strBanDo,strLayerName);
            BreakFeatureCollectionInLayer(map.Map, "tmpBanDo", staProcess);
        }
        //tinh goc quay cua nhan
        public double[] AngleText(MapControl pMap, DPoint[] d)
        {
            double[] HeSoGoc = new double[d.Length];
            for (int i = 0; i < d.Length; i++)
            {
                System.Drawing.PointF p1;
                System.Drawing.PointF p2;
                p1 = ConvertPoinF(d[i], pMap);
                if (i + 1 == d.Length)
                {
                    p2 = ConvertPoinF(d[0], pMap);
                }
                else
                {
                    p2 = ConvertPoinF(d[i + 1], pMap);
                }

                HeSoGoc[i] = -Convert.ToSingle(Math.Atan((Convert.ToSingle(p2.Y) - Convert.ToSingle(p1.Y)) /
                         (Convert.ToSingle(p2.X) - Convert.ToSingle(p1.X))) * (180 / Math.PI));
            }

            return HeSoGoc;
        }
        //ham tao bang moi 
        public MapInfo.Data.Table CreateDataTable(MapInfo.Mapping.Map map, string strTemplateTableName, string strNewTableName, Table tab)
        {
            MapInfo.Mapping.FeatureLayer featureLayerTemplate = new FeatureLayer(tab);
            MapInfo.Data.Table tableTemplate = featureLayerTemplate.Table;
            FeatureLayer fl = new FeatureLayer(tableTemplate);
            MapInfo.Data.TableInfo tableInfo = MapInfo.Data.TableInfoFactory.CreateTemp(strNewTableName, fl.CoordSys);
            for (int i = 0; i < tableTemplate.TableInfo.Columns.Count - 1; i++)
            {
                tableInfo.Columns.Add(new MapInfo.Data.Column(tableTemplate.TableInfo.Columns[i].Alias, tableTemplate.TableInfo.Columns[i].DataType));
            }
            MapInfo.Data.Table tableNew = MapInfo.Engine.Session.Current.Catalog.CreateTable(tableInfo);
            MapInfo.Mapping.FeatureLayer featureLayerNew = new MapInfo.Mapping.FeatureLayer(tableNew, strNewTableName);
            return tableNew;
        }
        //gan nhan dinh cho cac dinh cua ban do
        public void HienThiNhanDinh(string Curent, MapControl mapcontrol, double TyLe, string Nhan,ToolStripProgressBar staProcess, string LayerName)
        {

            DPoint ToaDoTamThua = new DPoint();
            //MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(Curent);
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            MapInfo.Data.Feature myfc = new Feature(table.TableInfo.Columns);
            //myfc = MapInfo.Engine.Session.Current.Catalog.SearchForFeature(table, MapInfo.Data.SearchInfoFactory.SearchWhere("featureID='"+FeatureID +"'"));
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count != 1)
            {
                MessageBox.Show("Chọn đối tượng cần gán nhãn");
                return;
            }
            if (!KtraSuTonTai(LayerName, "1"))
            {
                return;
            }
            foreach (Feature f in irfc)
            {
                //nếu đối tượng được chọn có kiểu MultiPolygon
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                {
                    myfc = f;
                    ToaDoTamThua = f.Geometry.Centroid;
                }
                else
                {
                    //nếu không thì thông báo
                    MessageBox.Show("Chọn đối tượng cần gán nhãn");
                    return;
                }
            }
            FeatureLayer Lyr = mapcontrol.Map.Layers[LayerName] as FeatureLayer;

            if (Lyr != null)
            {
                MapInfo.Geometry.DPoint[] dPointSize = null; ;
                MapInfo.Geometry.DPoint[] dPointSizetmp = null;
                MapInfo.Geometry.DPoint[] dPointSizetmp1 = null;
                MapInfo.Geometry.DPoint[] dPointSizeIn = null; ;
                DPoint[] d;
                MultiPolygon plg = (MultiPolygon)myfc.Geometry;
                int SoPolygon = 0;
                int i;
                i = 0;
                DPoint[] dTrong = null;
                double KC = 0;
                double DienTichTyLe = 0;                
                foreach (Polygon pl in plg)
                {
                    DMC.GIS.Common.WallBorderlines WallBorderlines = new DMC.GIS.Common.WallBorderlines();
                    //lấy tập hợp toạ độ các đỉnh
                    d = pl.Exterior.SamplePoints();
                    DienTichTyLe = dlDienTichThua;


                    drLable = pl.Bounds;
                    double DienTichNhan = 0;
                    DienTichNhan = DienTichCuaNhan(2, DienTichTyLe, dlTyLeZoomView);//DienTichCuaNhan(1, DienTichTyLe, System.Convert.ToDouble(string.Format("{0:E2}", mapcontrol.Map.Zoom.Value)));
                    KC = Math.Sqrt(DienTichNhan);

                    if (pl.InteriorCount > 0)
                    {
                        for (int k = 0; k < pl.InteriorCount; k++)
                        {
                            dTrong = pl.Interior(k).SamplePoints();
                            DPoint[] dd = new DPoint[dTrong.Length - 1];
                            for (int j = 0; j < dd.Length; j++) {
                                dd[j] = dTrong[j];
                            }
                                //dPointSizeIn = new DPoint[dTrong.Length - 1];
                                dPointSizeIn = new DPoint[dTrong.Length];
                            //dPointSizeIn = WallBorderlines.WallCornerPoints(pl, KC / 12);
                            dPointSizeIn = DiemDanDinh(myfc , dTrong, KC, false );
                            mpxDrawText(mapcontrol, mapcontrol.Map.Layers[LayerName].Alias, Nhan, dPointSizeIn, TyLe, SoPolygon, DienTichTyLe);
                            SoPolygon = SoPolygon + dPointSizeIn.Length -1;
                        }
                    }

                    DPoint[] dSize = new DPoint[d.Length - 1];
                    dPointSize = new DPoint[d.Length];
                    dPointSizetmp = new DPoint[d.Length];

                    dPointSizetmp = DiemDanDinh(myfc, d, KC , false);
                    //dPointSize = WallBorderlines.WallCornerPoints(pl, KC / 12);

                    mpxDrawText(mapcontrol , mapcontrol.Map.Layers[LayerName].Alias, Nhan, dPointSizetmp, KC, SoPolygon, DienTichTyLe);
                    //mpxDrawText(mapcontrol.Map.Layers[LayerName].Map, mapcontrol.Map.Layers[LayerName].Alias, Nhan, dPointSize, TyLe, SoPolygon);
                  SoPolygon = SoPolygon + dPointSizetmp.Length;
                }
                mapcontrol.Map.Invalidate();
                table.Refresh();
            }
        }
        //========================Tim diem nam tren duong phan giac====================================
        //so sanh khoang cach tu 2 diem toi 1 diem va lay diem gan hon
        public DPoint  SoSanhKhoangCachDinh(Feature f, DPoint d1, DPoint dGoc, DPoint d2,bool ChonNghiem, double Kc) {
            double m1, m2;
            double m = 0;
            DPoint  d = new DPoint ();
            DPoint [] dList=new DPoint[2];
            DPoint dTrungDiem = new DPoint();
            DPoint DiemGiua = new DPoint();
            DiemGiua.x = (d1.x + d2.x) / 2;
            DiemGiua.y = (d1.y + d2.y) / 2;
            m1 = TinhKhoangCach2Diem(d1, dGoc);
            m2 = TinhKhoangCach2Diem(d2, dGoc);
            if (m1 > m2)
            {
                //return d2;
                dList[0] = dGoc;
                dList[1] = d1;
                d = ToaDoDiemChia(dList, m2);
                dTrungDiem.x = (d.x + d2.x) / 2;
                dTrungDiem.y = (d.y + d2.y) / 2;
            }
            else
            {
                //return d1;    
                dList[0] = dGoc;
                dList[1] = d2;
                d = ToaDoDiemChia(dList, m1);
                dTrungDiem.x = (d.x + d1.x) / 2;
                dTrungDiem.y = (d.y + d1.y) / 2;
            }
            dList[0] = dGoc;
            dList[1] = dTrungDiem;
            dTrungDiem = ToaDoDiemChia(dList, Kc);
            if (HeSoGoc(d1, dTrungDiem, d2) == 180)
            {
                //tinh khoang cach tu trung diem toi 1 diem d1
                double h = 0;
                double h1 = 0;
                double x = 0;
                double y = 0;
                h = TinhKhoangCach2Diem(dTrungDiem, d1);
                x = d1.y - dTrungDiem.y;
                y = Math.Sqrt(h * h - x * x);
                double nx1, nx2;
                double ny1, ny2;
                nx1 = dTrungDiem.x - Math.Sqrt(x * x);
                nx2 = dTrungDiem.x + Math.Sqrt(x * x);
                ny1 = dTrungDiem.y - Math.Sqrt(y * y);
                ny2 = dTrungDiem.y + Math.Sqrt(y * y);
                double goc1, goc2, goc3, goc4;
                DPoint diem1 = new DPoint();
                DPoint diem2 = new DPoint();
                DPoint diem3 = new DPoint();
                DPoint diem4 = new DPoint();
                diem1.x = nx1;
                diem1.y = ny1;
                diem2.x = nx1;
                diem2.y = ny2;
                diem3.x = nx2;
                diem3.y = ny1;
                diem4.x = nx2;
                diem4.y = ny2;
                goc1 = HeSoGoc(d1, dTrungDiem, diem1);
                goc2 = HeSoGoc(d1, dTrungDiem, diem2);
                goc3 = HeSoGoc(d1, dTrungDiem, diem3);
                goc4 = HeSoGoc(d1, dTrungDiem, diem4);


              
                if (ChonNghiem)
                {
                    if (goc1 == 90)
                    {
                        if (f.Geometry.ContainsPoint(diem1))
                        {
                           return diem1;
                        }
                        else
                        {
                            dTrungDiem.x = 2 * dGoc.x - diem1.x;
                            dTrungDiem.y = 2 * dGoc.y - diem1.y;
                        }
                    }
                    if (goc2 == 90)
                    {
                        if (f.Geometry.ContainsPoint(diem2))
                        {
                            return diem2;
                        }
                        else
                        {
                            dTrungDiem.x = 2 * dGoc.x - diem2.x;
                            dTrungDiem.y = 2 * dGoc.y - diem2.y;
                        }
                    }
                    if (goc3 == 90)
                    {
                        if (f.Geometry.ContainsPoint(diem3))
                        {
                            return diem3;
                        }
                        else
                        {
                            dTrungDiem.x = 2 * dGoc.x - diem3.x;
                            dTrungDiem.y = 2 * dGoc.y - diem3.y;
                        }
                    }
                    if (goc4 == 90)
                    {
                        if (f.Geometry.ContainsPoint(diem4))
                        {
                            return diem4;
                        }
                        else
                        {
                            dTrungDiem.x = 2 * dGoc.x - diem4.x;
                            dTrungDiem.y = 2 * dGoc.y - diem4.y;
                        }
                    }
                }
                else {
                    if (goc1 == 90)
                    {
                        if (f.Geometry.ContainsPoint(diem1))
                        {
                            dTrungDiem.x = 2 * dGoc.x - diem1.x;
                            dTrungDiem.y = 2 * dGoc.y - diem1.y;
                        }
                        else
                        {

                            return diem1;
                        }
                    }
                    if (goc2 == 90)
                    {
                        if (f.Geometry.ContainsPoint(diem2 ))
                        {
                            dTrungDiem.x = 2 * dGoc.x - diem2.x;
                            dTrungDiem.y = 2 * dGoc.y - diem2.y;
                        }
                        else
                        {

                            return diem2;
                        }
                    }
                    if (goc3 == 90)
                    {
                        if (f.Geometry.ContainsPoint(diem3))
                        {
                            dTrungDiem.x = 2 * dGoc.x - diem3.x;
                            dTrungDiem.y = 2 * dGoc.y - diem3.y;
                        }
                        else
                        {

                            return diem3;
                        }
                    }
                    if (goc4 == 90)
                    {
                        if (f.Geometry.ContainsPoint(diem4))
                        {

                            dTrungDiem.x = 2 * dGoc.x - diem4.x;
                            dTrungDiem.y = 2 * dGoc.y - diem4.y;
                        }
                        else
                        {
                            return diem4;
                        }
                    }
                }
            }
            else
            {
                if (ChonNghiem)
                {
                    //truong hop nam ngoai
                    if (f.Geometry.ContainsPoint(dTrungDiem))
                    {
                        return dTrungDiem;
                    }
                    else {
                        dTrungDiem.x = 2 * dGoc.x - dTrungDiem.x;
                        dTrungDiem.y = 2 * dGoc.y - dTrungDiem.y;
                    }
                }
                else { 
                //truong hop nam trong
                    if (f.Geometry.ContainsPoint(dTrungDiem))
                    {
                        dTrungDiem.x = 2 * dGoc.x - dTrungDiem.x;
                        dTrungDiem.y = 2 * dGoc.y - dTrungDiem.y;
                    }
                    else
                    {

                        return dTrungDiem;
                    }
                }
            }

            
           
            return dTrungDiem;
        }
        //lay ra 2 nghiem x cua phuong trinh qua diem goc va diem tim duoc tren duong phan giac
        //da la diem goc cua dinh dang xet
        //d0 la diem nam tren duong phan giac cua canh xuat phat tu dinh da
        //kc la khoang cach
        public double [] NghiemPT(DPoint da, DPoint d0, double kc) {
            double xa,ya,xo,yo;
            xa=da.x;
            ya=da.y;
            xo=d0.x;
            yo=d0.y;
            double[] dd = new double[2];
            double b=0;
            double delta = 0;
            double c = 0;
            double a = 0;
            double a1=0;
            double b1 = 0;
            double c1 = 0;
            //a1 = (xa - xo) * (xa - xo);
            //b1 = (ya * (xa - xo)  - (xa * yo - xo * ya));
            //c1 = kc * kc * (xa - xo) * (xa - xo);
            //b =  -(a1 * xa + b1 * (ya - yo));
            //c = a1 * xa * xa + b1 * b1   - c1;
            //a = a1 + (ya - yo) * (ya - yo);
            //delta = b * b - a * c;
            //dd[0] = (-b - Math.Sqrt(delta)) / a;
            //dd[1] = (-b +  Math.Sqrt(delta)) / a;


            //tinh lai
            a = (da.y - d0.y) / (da.x - d0.x);
            delta = kc * kc / (a * a + 1);
            dd[0] = (da.x  - Math.Sqrt(delta)) ;
            dd[1] = (da.x  + Math.Sqrt(delta));

            //dd[0]= ((xa-x0)*(xa-x0)*xa  + ((ya*(xa-xo)+xa*yo + xo*ya )*(ya-yo))-Math.Sqrt((xa-x0)*(xa-x0)*(ya-yo)*(ya-yo) * ((xa-xo)*(xa-xo)*xa*xa + (ya*(xa-xo)+ (xa-xo-xo*ya))* (ya*(xa-xo)+ (xa-xo-xo*ya)))-kc*kc*(xa-xo)))/((xa-xo)*(xa-xo) + (ya-yo)*(ya-yo ));
         
            return dd;
        }
        
        //lay toan do diem 2 nghiem cua phuong trinh
        public DPoint[] dDiemNghiem(DPoint da, double [] d ,double kc) {
            DPoint[] dpoit = new DPoint[4];
            double x1 = d[0];
            double x2 = d[1];
            double y1 = 0;
            double y2=0;
            double y3 = 0;
            double y4=0;
            DPoint d1 = new DPoint();
            DPoint d2 = new DPoint();
            DPoint d3 = new DPoint();
            DPoint d4 = new DPoint();
            //voi x1
            double c1 = 0;
            double c2 = 0;

            c1 = da.y * da.y - kc * kc + (da.x - x1) * (da.x - x1);
            y1 = da.y - Math.Sqrt(da.y * da.y - c1);
            y2 = da.y + Math.Sqrt(da.y * da.y - c1);
            c2 = da.y * da.y - kc * kc + (da.x - x2) * (da.x - x2);
            y3 = da.y - Math.Sqrt(da.y * da.y - c2);  //((da.y - d0.y) / (da.x - d0.x)) * x1 + (da.x * d0.y - d0.x * da.y) / (da.x - d0.y);
            y4 = da.y + Math.Sqrt(da.y * da.y - c2);

            //y1 = Math.Sqrt(kc * kc - (da.x - d[0]) * (da.x - d[0]));
            //y2 = Math.Sqrt(kc * kc - (da.x - d[1]) * (da.x - d[1]));
            dpoit[0].x = x1;
            dpoit[0].y = y1;
            dpoit[1].x = x1;
            dpoit[1].y = y2;
            dpoit[2].x = x2;
            dpoit[2].y = y3;
            dpoit[3].x = x2;
            dpoit[3].y = y4;
            return dpoit;
        }
        //xet diem nam trong
        public DPoint XetnghiemDiemTrong(Feature f, DPoint[] d ,double GocPhanGiac , DPoint dGoc,DPoint GocDiem) {
            DPoint dDiem = new DPoint();
            double Goc1, Goc2, Goc3, Goc4;
            Goc1 = Math.Round(HeSoGoc(GocDiem, dGoc, d[0]), 3);
            Goc2 = Math.Round(HeSoGoc(GocDiem, dGoc, d[1]), 3);
            Goc3 = Math.Round(HeSoGoc(GocDiem, dGoc, d[2]), 3);
            Goc4 = Math.Round(HeSoGoc(GocDiem, dGoc, d[3]), 3);
            GocPhanGiac = Math.Round(GocPhanGiac / 2, 3);
            if ((f.Geometry.ContainsPoint(d[0])))// && (GocPhanGiac== Goc1))
            {
                dDiem = d[0];
            }
            if ((f.Geometry.ContainsPoint(d[1])))//&& (GocPhanGiac == Goc2))
            {
                dDiem = d[1];
            }
            if ((f.Geometry.ContainsPoint(d[2])))//&& (GocPhanGiac == Goc3))
            {
                dDiem = d[2];
            }
            if ((f.Geometry.ContainsPoint(d[3])))//&& (GocPhanGiac == Goc4))
            {
                dDiem = d[3];
            }
            return dDiem;
        }
        //xet diem nam ngoai
        //xet diem nam trong
        public DPoint XetnghiemDiemNgoai(Feature f, DPoint[] d, double GocPhanGiac, DPoint dGoc, DPoint GocDiem)
        {
            DPoint dDiem = new DPoint();
            double Goc1, Goc2, Goc3, Goc4;
            Goc1 = Math.Round( HeSoGoc(GocDiem, dGoc, d[0]),3);
            Goc2 = Math.Round(HeSoGoc(GocDiem, dGoc, d[1]), 3);
            Goc3 = Math.Round(HeSoGoc(GocDiem, dGoc, d[2]), 3);
            Goc4 =Math.Round( HeSoGoc(GocDiem, dGoc, d[3]),3);
           GocPhanGiac=  Math.Round( GocPhanGiac/2,3);
            if ((!f.Geometry.ContainsPoint(d[0])) && (GocPhanGiac== Goc1))
            {
                dDiem = d[0];
            }
            if ((!f.Geometry.ContainsPoint(d[1]))&& (GocPhanGiac == Goc2))
            {
                dDiem = d[1];
            }
            if ((!f.Geometry.ContainsPoint(d[2]))&& (GocPhanGiac == Goc3))
            {
                dDiem = d[2];
            }
            if ((!f.Geometry.ContainsPoint(d[3]))&& (GocPhanGiac == Goc4))
            {
                dDiem = d[3];
            }
            return dDiem;
        }
        //hàm chức năng tìm điểm dán đỉnh
        public DPoint[] DiemDanDinh(Feature f, DPoint[] d,double KC, bool ChonNghiem) {
            DPoint[] DiemCanTim = new DPoint[d.Length];
            DPoint Diem1=new DPoint();
            DPoint Diem2=new DPoint();
            DPoint Diem3=new DPoint();
            DPoint DTrungDiem = new DPoint();
            DPoint[] ToaDoX = new DPoint[2];
            double GocPhanGiac = 0;
            DPoint[] ToaDo4Nghiem = new DPoint[4];
           
            for (int i = 0; i < d.Length; i++)
                {
                    if (i == 0)
                    {
                        Diem1 = d[d.Length - 1];
                        Diem2 = d[i];
                        Diem3 = d[i + 1];
                    }
                   
                    else if (i == d.Length - 1)
                    {
                        Diem1 = d[d.Length - 2];
                        Diem2 = d[i];
                        Diem3 = d[0];
                    }
                    else
                    {
                        Diem1 = d[i - 1];
                        Diem2 = d[i];
                        Diem3 = d[i + 1];
                    }
                    DTrungDiem = SoSanhKhoangCachDinh(f, Diem1, Diem2, Diem3, ChonNghiem,KC );


                    //kiem tra lai nghiem
                    double KhoangCachMoi = 0;
                    KhoangCachMoi = TinhKhoangCach2Diem(DTrungDiem, Diem2);
                    if (KhoangCachMoi - KC > 1)
                    {
                        DTrungDiem = Diem2;
                    }

                    //

                //ToaDoX[0]=Diem2;
                //ToaDoX[1] = DTrungDiem;
                DiemCanTim[i] = DTrungDiem;//ToaDoDiemChia(ToaDoX, KC);
               
                    if (i == d.Length - 1) {
                        DiemCanTim[d.Length-1] = DiemCanTim[0];
                    }
                }
            return DiemCanTim;
        }
       
        //========================================
        //gam dinh cho cac dinh cua ban do
        public void HienThiDinh(string Curent, MapControl mapcontrol, string Nhan,string LayerName)
        {//goi bảng hiện thời
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            MapInfo.Data.Feature myfc = new Feature(table.TableInfo.Columns);
            //lấy tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc == null)
            {
                MessageBox.Show("Chọn đối tượng cần gán nhãn");
                return;
            }
            if (irfc.Count != 1)
            {
                MessageBox.Show("Chọn đối tượng cần gán nhãn");
                return;
            }
            if (!KtraSuTonTai(LayerName, "3"))
            {
                return;
            }
            foreach (Feature f in irfc)
            {
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                {
                    myfc = f;
                }
                else
                {
                    MessageBox.Show("Chọn đối tượng cần gán nhãn");
                    return;
                }

            }
            FeatureLayer Lyr = mapcontrol.Map.Layers[LayerName] as FeatureLayer;
            if (Lyr != null)
            {
                DPoint[] d;
                MultiPolygon plg = (MultiPolygon)myfc.Geometry;
                foreach (Polygon pl in plg)
                {
                    d = pl.Exterior.SamplePoints();
                    //gọi hàm dán node
                    if (pl.InteriorCount > 0) {
                        for (int i = 0; i < pl.InteriorCount;i++ )
                        {
                            DPoint[] dIn = null;
                            dIn = pl.Interior(i).SamplePoints();
                            mpxDrawNode(mapcontrol.Map.Layers[LayerName].Map, mapcontrol.Map.Layers[LayerName].Alias, Nhan, dIn , Nhan, LayerName);
                        }

                    }
                    mpxDrawNode(mapcontrol.Map.Layers[LayerName].Map, mapcontrol.Map.Layers[LayerName].Alias, Nhan, d, Nhan, LayerName);
                    //  EditableLayer(mapcontrol, Nhan, true);
                }
                mapcontrol.Map.Invalidate();
                table.Refresh();
            }
        }
        public bool KtraSuTonTai(string LayerName,string  DoiTuong ) {
            bool XacNhan = false;
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tập hợp tất cả các dối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchAll());
            if (irfc == null)
            {
                return false ;
            }
            if (irfc.Count == 0)
            {
                return false ;
            }
            
            foreach(Feature f in irfc){
                string MaDoiTuong;
                MaDoiTuong = "";
                MaDoiTuong = GetMaDoiTuong(f, LayerName);
                if (DoiTuong == MaDoiTuong) {
                    XacNhan = false;
                    return XacNhan;
                }
                XacNhan = true;
            }
            return XacNhan;
        }

        public double TinhChieuDaiLongLat(double lat1, double lng1 ,double lat2,double lng2) {
            var R = 6371000; // 6.302.369 km (change this constant to get miles) // look like earth's radius :))
            var dLat = (lat2 - lat1) * Math.PI / 180;
            var dLng = (lng2 - lng1) * Math.PI / 180;
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
          Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
          Math.Sin(dLng / 2) * Math.Sin(dLng / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            if (d > 1) return d ;
            else if (d <= 1) return d * 1000 ;
            return d;
        }
        //gam nhan kich thuoc cho cac canh cua ban do
        public void HienThiKichThuoc(string Curent, MapControl mapcontrol, CompositeStyle ts, Double TyLe, string Nhan, ToolStripProgressBar staProcess, string LayerName)
        {

            //gọi bảng hiện thời
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            MapInfo.Data.Feature myfc = new Feature(table.TableInfo.Columns);
            //lấy tập hợp tất cả các dối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc == null)
            {

                return;
            }
            if (irfc.Count != 1)
            {
                MessageBox.Show("Chọn đối tượng cần gán nhãn");
                return;
            }

            if (!KtraSuTonTai(LayerName, "2")) {
                return;
            }
            FeatureLayer Lyr = mapcontrol.Map.Layers[LayerName] as FeatureLayer;
            double KC = 0;
            double DienTichTyLe = 0;
            if (Lyr != null)
            {
                foreach (Feature f in irfc)
                {
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                    {
                       
                        DPoint[] d = null; ;
                        double MySize;
                        MySize = 0.0;
                        MapInfo.Geometry.MultiPolygon multiPolygon = (MapInfo.Geometry.MultiPolygon)f.Geometry;
                        foreach (MapInfo.Geometry.Polygon poly in multiPolygon)
                        {
                            DienTichTyLe = dlDienTichThua;


                            drLable = poly.Bounds;
                            double DienTichNhan = 0;

                            DienTichNhan = DienTichCuaNhan(2, DienTichTyLe, dlTyLeZoomView);//DienTichCuaNhan(1, DienTichTyLe, System.Convert.ToDouble(string.Format("{0:E2}", mapcontrol.Map.Zoom.Value)));
                            KC = Math.Sqrt(DienTichNhan);


                            MapInfo.Geometry.DPoint[] dPointSizetmp = null;
                            MapInfo.Geometry.DPoint[] dPointSize = null; ;
                            dPointSizetmp = new DPoint[poly.Exterior.SamplePoints().Length - 1];
                            dPointSize = new DPoint[poly.Exterior.SamplePoints().Length];
                            if (poly.InteriorCount>0){
                                for (int i = 0; i < poly.InteriorCount;i++ )
                                {
                                    DPoint[] dIn = null;
                                    dIn=poly.Interior(i).SamplePoints();
                                    DPoint[] dsizeIn = new DPoint[dIn.Length];
                                    dsizeIn = TapHopDiemCanTim(f, dIn, KC, false );
                                    string [] LineSizeIN = new string [dIn.Length - 1];
                                    int jj;
                                    for (int ii = 0; ii < dIn.Length - 1; ii++)
                                    {
                                        jj = ii + 1;
                                        if (ii == dIn.Length - 1)
                                        {
                                            jj = 0;
                                        }
                                        //lay kich thuoc canh noi 2 dinh lien ke
                                        MySize = System.Math.Sqrt((dIn[ii].x - dIn[jj].x) * (dIn[ii].x - dIn[jj].x) + (dIn[ii].y - dIn[jj].y) * (dIn[ii].y - dIn[jj].y));
                                     
                                        double tmp = System.Math.Round(MySize, 2);
                                        LineSizeIN[ii] = String.Format("{0:#,##0.00}", tmp);
                                    }
                                    double[] ValueHSGocIn;
                                    //lấy hệ số góc nghiêng của text
                                    ValueHSGocIn = AngleText(mapcontrol, dIn);
                                    //gọi hàm hiển thị kích thước cạnh
                                    mpxDrawTextSize(Curent, mapcontrol, mapcontrol.Map.Layers[LayerName].Alias, Nhan, LineSizeIN, dsizeIn, KC, ValueHSGocIn, DienTichTyLe);
                                    
                                 }
                            }
                            
                        d = new DPoint[dPointSize.Length];
                        d = poly.Exterior.SamplePoints();
                          
                      
                        dPointSize = TapHopDiemCanTim(f, d,KC, false );
                        DPoint[] dSize = new DPoint[d.Length - 1];
                        string [] LineSize = new string [d.Length - 1];
                        int j;

                        for (int i = 0; i < d.Length - 1; i++)
                        {
                            j = i + 1;
                            if (i == d.Length - 1)
                            {
                                j = 0;
                            }
                            //lay kich thuoc canh noi 2 dinh lien ke
                            MySize = System.Math.Sqrt((d[i].x - d[j].x) * (d[i].x - d[j].x) + (d[i].y - d[j].y) * (d[i].y - d[j].y));
                           double tmp = System.Math.Round(MySize, 2);

                            LineSize[i] = String.Format("{0:#,##0.00}", tmp);//string.Format(tmp.ToString(), "#.##");
                        }
                            double[] ValueHSGoc;
                            //lấy hệ số góc nghiêng của text
                            ValueHSGoc = AngleText(mapcontrol, d);
                            //gọi hàm hiển thị kích thước cạnh
                            mpxDrawTextSize(Curent, mapcontrol, mapcontrol.Map.Layers[LayerName].Alias, Nhan, LineSize, dPointSize, KC, ValueHSGoc, DienTichTyLe);
                            // ChangeTextInOut(mapcontrol, LayerName, 2 ,  staProcess, false,TyLe);

                            mapcontrol.Map.Invalidate();
                            table.Refresh();
                        
                        }
                    }
                    else
                    {
                       MessageBox.Show("Chọn đối tượng cần gán nhãn");

                        return;
                    }

                }
            }
            
        }
         //gan nhan ten thua va dien tich cua thua
        public void TenThuaDienTich(string tblBanDo, string Curent, MapControl mapcontrol, CompositeStyle ts, double TyLe, string Nhan, string LayerName, long FeatureID, string[] TenThuaDienTich)
        {
            // clsDatabase clsData = new clsDatabase();
            //gọi bảng hiện thời
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tables, MapInfo.Data.SearchInfoFactory.SearchWhere("featureID='"& FeatureID &"'");
            MapInfo.Data.Feature myfc = new Feature(table.TableInfo.Columns);
            //lây tập hợp tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if ((irfc == null))
            {
                return;
            }
            if (irfc.Count != 1)
            {
                MessageBox.Show("Chọn đối tượng cần gán nhãn");
                return;
            }
            if (!KtraSuTonTai(LayerName, "5"))
            {
                return;
            }
            foreach (Feature f in irfc)
            {
                //nếu đối tượng có kiểu dữ liệu là MultiPolygon
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                {
                    myfc = f;
                }
                else
                {
                    MessageBox.Show("Chọn đối tượng cần gán nhãn");
                    return;
                }

             

            } FeatureLayer Lyr = mapcontrol.Map.Layers[LayerName] as FeatureLayer;
            if (Lyr != null)
            {
                // Lyr.ShowNodes = true;
               // string[] TenThuaDienTich = new string[2];
                DPoint d;
                MultiPolygon plg = (MultiPolygon)myfc.Geometry;
                double DienTichTyLe = 0;
                 DienTichTyLe = dlDienTichThua;
                //tim tam doi tuong
                DPoint Center = new DPoint();
                IResultSetFeatureCollection Lfc = Session.Current.Selections.DefaultSelection[table];
                if (Lfc == null)
                {
                    MessageBox.Show("Chọn đối tượng !!");
                    return;
                }

                foreach (Feature f in Lfc)
                {
                    //lay toa do tam 
                    Center = f.Geometry.Centroid;
               
                    //foreach (Polygon pl in (MultiPolygon) f.Geometry )
                    //{
                        d.x = Center.x;
                        d.y = Center.y;
                        //gọi hàm dãn nhãn số thửa và diện tích
                        mpxDrawTenThuaDienTich(mapcontrol.Map.Layers[LayerName].Map, mapcontrol.Map.Layers[LayerName].Alias, Nhan, TenThuaDienTich, d, TyLe, Nhan, LayerName, DienTichTyLe);
                    //}
                }
                mapcontrol.Map.Invalidate();
                table.Refresh();

            }
        }
        //ham thuc thi chuc nang combine doi tuong lai
        public bool CombineFeatures(MapControl mapcontrol, string strLayerName, ToolStripProgressBar staProcess)
        {
            try
            {
                /* Chắc chắn rằng tồn tại đối tượng bản đồ */
                if (mapcontrol.Map == null)
                    return false;
                /* Khai báo lớp có các Features muốn combine */
                MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)mapcontrol.Map.Layers[strLayerName];
                /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
                if (featureLayer == null)
                    return false;
                
                /* Gắn giá trị mặc định cho Feature */
                MapInfo.Data.Feature feature = null;
                /* Khai báo và khởi tạo lớp FeatureTools có chứa hàm trả về tập hợp các đối tượng được Select */

                MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerName);

                /* Khai báo tập hợp các Feature được Select */
                //MapInfo.Data.IResultSetFeatureCollection irfc;
                /* Gán giá trị cho biến tập hợp */
                MapInfo.Data.IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
               // irfc = SelectFeaturesAll(mapcontrol.Map, strLayerName);

                //Feature pft = new Feature(table.TableInfo.Columns);
                //MapInfo.Geometry.Point lt = new MapInfo.Geometry.Point(mapcontrol.Map.GetDisplayCoordSys(), irfc[0].Geometry.Centroid);
                //pft.Geometry = lt;
                //UpdateDoiTuong(table, pft.Geometry, "0", new CompositeStyle());
                //return true;


                /* Chắc chắn rằng có từ 2 đối tượng được chọn để Combine */
                if (irfc == null)
                    return false;
                if (irfc.Count == 0)
                    return false;



               
                //lay ma doi tuong
                CompositeStyle cs = new CompositeStyle();
                string madoituong = "";
                foreach (Feature fMa in irfc) {
                    madoituong = GetMaDoiTuong(fMa, strLayerName);
                }
               
                /* Khai báo bảng tương ứng với lớp muốn combine */
              
                MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
                /* Chỉ combine các features trong cùng một lớp có tên là strLayerName */
                if (irfc.BaseTable.Alias == featureLayer.Table.Alias)
                {
                    /* Tạo Feature từ tập hợp các Feature vừa chọn để combine */
                    feature = featureProcessor.Combine(irfc);
                }
                /* Add Feature vừa tạo vào lớp có tên là strLayerName */

               // table.InsertFeature(feature);

                //UpdateDoiTuong(table, feature.Geometry, "0", new CompositeStyle());
                //return true;


                DPoint[] d;
                MultiCurve mc = (MultiCurve)feature.Geometry;
                MapInfo.Data.Key [] keyAction =new Key[mc.CurveCount ] ;
                int index = 0;
                foreach (Curve cv in mc)
                {
                    d = cv.SamplePoints();
                    MultiPolygon poly = new MultiPolygon(mapcontrol.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, d);
                    Feature fff = new Feature(table.TableInfo.Columns);
                    fff = new MapInfo.Data.Feature(poly, feature.Style);
                    
                    keyAction[index] = table.InsertFeature(fff);
                    index = index + 1;
                }
               
                /* Test */
                foreach (MapInfo.Data.Feature f in irfc)
                {
                    /* Xóa Feature*/
                    table.DeleteFeature(f);
                }
                

               // IResultSetFeatureCollection Myfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchAll());
                string dieuKien = "";
                for (int i = 0; i < keyAction.Length; i++) {
                    dieuKien = dieuKien + " MI_Key ='" + keyAction[i] + "' or ";
                }
                dieuKien = dieuKien.Substring(0, dieuKien.Length-4);
                IResultSetFeatureCollection Myfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere(dieuKien));
                if (Myfc == null) {
                    return false;
                }
                if (Myfc.Count==0)
                {
                    return false;
                }
                //kiem tra truong hop thua nam trong thua //luu lai cac thua nam trong nhau
                IResultSetFeatureCollection [] MyIrfc = new IResultSetFeatureCollection[Myfc.Count];
                //Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchAll());
                bool ktraGiaoThua = false;
                for (int i = 0; i < Myfc.Count; i++) {
                    IResultSetFeatureCollection Myfctmp = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MI_key = ''"));
                    int m = 0;
                    for (int j =0; j < Myfc.Count ;j++){
                        if (i != j)
                        {
                            if (Myfc[i].Geometry.Contains(Myfc[j].Geometry))
                            {
                                if (m == 0)
                                {
                                    Myfctmp.Add(Myfc[i]);
                                    Myfctmp.Add(Myfc[j]);

                                }
                                else
                                {
                                    Myfctmp.Add(Myfc[j]);
                                }
                                m = m + 1;

                            }
                        }
                    }
                    
                    MyIrfc[i] = Myfctmp;
                   
                }
                int cout =0;
                string TimKeyGopThua = "";
                for (int k = 0; k < MyIrfc.Length ; k++){
                    if (MyIrfc[k].Count > 0)
                    {
                        cout = cout + 1;
                        ktraGiaoThua = true;
                    }
                }
                if (ktraGiaoThua)
                {
                    //neu nhu ton tai thua dat chong len nhau thi thuc thi 
                    MapInfo.Data.Key[] keyNew = new Key[cout];
                    int ii = 0;
                    for (int k = 0; k < MyIrfc.Length; k++)
                    {
                        if (MyIrfc[k].Count > 0)
                        {

                            IResultSetFeatureCollection fcAc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MI_key=''")); ;
                            for (int i = 0; i < MyIrfc[k].Count; i++)
                            {
                                fcAc.Add(MyIrfc[k][i]);
                            }
                            Feature ftea = new Feature(table.TableInfo.Columns);
                            FeatureGeometry fg = null;
                            MultiPolygon mulPo = DienTichMax(fcAc);
                            MapInfo.Data.Key KeyMax = KeyFeatureMax(fcAc);
                            foreach (Feature ff in fcAc)
                            {
                                //kiem tra truong hop 2 thua ko nam giao nhau truoc da

                                if (KeyMax != ff.Key)
                                {
                                    ftea.Geometry = mulPo.Difference((MultiPolygon)ff.Geometry);
                                    mulPo = (MultiPolygon)ftea.Geometry;
                                    ftea.Style = ff.Style;
                                }

                            }

                            keyNew[ii] = table.InsertFeature(ftea);
                            ii = ii + 1;
                            foreach (Feature fdel in fcAc)
                            {
                                table.DeleteFeature(fdel);//=============
                            }
                        }
                    }

                    //phan tich lai cac khoa cua cac thua moi tao
                    string key = "";
                    for (int i = 0; i < keyNew.Length; i++)
                    {
                        key = key + " MI_Key ='" + keyNew[i] + "' or ";
                    }
                    key = key.Substring(0, key.Length - 4);
                    TimKeyGopThua = key;
                }
                else {
                    TimKeyGopThua = dieuKien;
                }
                //combince tat ca cac doi tuong lai
                IResultSetFeatureCollection fcCombine = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere(TimKeyGopThua));

                featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
                /* Chỉ combine các features trong cùng một lớp có tên là strLayerName */
                Feature feaCom = new Feature(table.TableInfo.Columns);
                if (fcCombine.BaseTable.Alias == featureLayer.Table.Alias)
                {
                    /* Tạo Feature từ tập hợp các Feature vừa chọn để combine */
                    feaCom = featureProcessor.Combine(fcCombine);
                  // table.InsertFeature(feaCom);
                    SimpleInterior si = new SimpleInterior();
                    si.Pattern = 1;
                    cs.ApplyStyle(si);
                    UpdateDoiTuong(table, feaCom.Geometry, madoituong, cs, "0");
                }
                foreach (MapInfo.Data.Feature f in fcCombine)
                {
                    /* Xóa Feature*/
                    table.DeleteFeature(f);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
                return false;
            }
            return true;
        }
        //hàm tìm xem trong cac thửa thửa nào có diện tích lớn nhất
        public MultiPolygon DienTichMax(IResultSetFeatureCollection Myfc)
        {
            double Max = 0;
            int a = 0;
            for (int i = 0; i < Myfc.Count; i++)
            {
                MultiPolygon mt = (MultiPolygon)(Myfc[i].Geometry);
                double dientich = mt.Area(AreaUnit.SquareMeter);
                if (Max < dientich)
                {
                    a = i;
                    Max = dientich;
                }
            }
            return (MultiPolygon)(Myfc[a].Geometry);
        }
        //tìm key lớn nhất của các dối tượng thửa
        public MapInfo.Data.Key KeyFeatureMax(IResultSetFeatureCollection Myfc)
        {
            double Max = 0;
            int a = 0;
            for (int i = 0; i < Myfc.Count; i++)
            {
                MultiPolygon mt = (MultiPolygon)(Myfc[i].Geometry);
                double dientich = mt.Area(AreaUnit.SquareMeter);
                if (Max < dientich)
                {
                    a = i;
                    Max = dientich;
                }
            }
            return Myfc[a].Key;
        }
        //ham tra ve doi tuong vua duoc combine
        public Feature FeatureCombine(MapInfo.Mapping.Map map, string strLayerName, ToolStripProgressBar staProcess)
        {
            /* Khai báo và khởi tạo lớp FeatureTools có chứa hàm trả về tập hợp các đối tượng được Select */
            /* Gắn giá trị mặc định cho Feature */
            MapInfo.Data.Feature feature = null;
            Feature fff = null;
             try
                {
                    /* Chắc chắn rằng tồn tại đối tượng bản đồ */
                    if (map == null)
                        return null ;
                    /* Khai báo lớp có các Features muốn combine */
                    MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
                    /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
                    if (featureLayer == null)
                        return null ;
                   
                    /* Khai báo tập hợp các Feature được Select */
                    MapInfo.Data.IResultSetFeatureCollection irfc;
                    /* Gán giá trị cho biến tập hợp */
                    irfc = SelectFeaturesAll(map, strLayerName);
                    /* Chắc chắn rằng có từ 2 đối tượng được chọn để Combine */
                    if (irfc == null)
                        return null ;
                    if (irfc.Count == 0)
                        return null;
                    /* Khai báo bảng tương ứng với lớp muốn combine */
                    MapInfo.Data.Table table = featureLayer.Table;
                    MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
                    /* Chỉ combine các features trong cùng một lớp có tên là strLayerName */
                    if (irfc.BaseTable.Alias == featureLayer.Table.Alias)
                    {
                        /* Tạo Feature từ tập hợp các Feature vừa chọn để combine */
                        feature = featureProcessor.Combine(irfc);
                    }
                    /* Add Feature vừa tạo vào lớp có tên là strLayerName */

                    DPoint[] d;
                    MultiCurve mc = (MultiCurve)feature.Geometry;
                    staProcess.Maximum = mc.CurveCount;
                    staProcess.Value = 0;
                    foreach (Curve cv in mc)
                    {
                        d = cv.SamplePoints();
                        MultiPolygon poly = new MultiPolygon(map.GetDisplayCoordSys(), CurveSegmentType.Linear, d);
                       fff = new Feature(table.TableInfo.Columns);
                        fff = new MapInfo.Data.Feature(poly, feature.Style);
                       // table.InsertFeature(fff);
                        staProcess.Value = staProcess.Value + 1;
                    }


                    /* Test */
                    foreach (MapInfo.Data.Feature f in irfc)
                    {
                        /* Xóa Feature*/
                        table.DeleteFeature(f);
                    }
                    /* EndTest */
                }
             catch (Exception ex)
             {
                 return null;
             }
         return fff;
        }
        //chức năng thực hiện viêc chon tat ca cac doi tuong tren ban do
        public MapInfo.Data.IResultSetFeatureCollection SelectFeaturesAll(MapInfo.Mapping.Map map, string strLayerName)
        {
            if (map.Layers[strLayerName] == null)
                return null;
            if (map.Layers[strLayerName] == null)
                return null;
            if (map.Layers[strLayerName].Enabled == false)
                return null;
            MapInfo.Engine.ISession session = MapInfo.Engine.Session.Current;
            MapInfo.Data.Table table = session.Catalog[map.Layers[strLayerName].Alias];
            MapInfo.Data.IResultSetFeatureCollection irfc = session.Selections.DefaultSelection[table];
            return irfc;
        }
        //ham chuc nang lay danh sach toa do trong grid de tra ra doi tuong dpoint
        public DPoint[] GetPointList(DataGridView grd)
        {
            DPoint[] pointList = null; ;
            if (grd.Rows.Count > 0)
            {
                //Khai báo mảng các điểm nhận giá trị từ grid
                pointList = new DPoint[grd.Rows.Count + 1];
                for (int i = 0; i < grd.Rows.Count; i++)
                {
                    pointList[i].x = Convert.ToDouble(grd.Rows[i].Cells[0].Value);
                    pointList[i].y = Convert.ToDouble(grd.Rows[i].Cells[1].Value);
                    //lấy thêm giá trị đầu tiên ở cuối mảng
                    if (i == grd.Rows.Count - 1)
                    {
                        pointList[i + 1].y = pointList[0].y;
                        pointList[i + 1].x = pointList[0].x;
                    }
                }

            }
            return pointList;
        }
        //ham thuc thi viec gan nhan Ten thua va Dien tich
        public void mpxDrawTenThuaDienTich(MapInfo.Mapping.Map pMap, string pTabName, string newLayer, string[] Value, DPoint d, Double Tyle, string Nhan, string LayerName, double DienTich)
        {
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(newLayer) == null)
            {
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(pTabName);
                DPoint[] PPoint = new DPoint[2];
                //dinh nghia doi tuong font
                DPoint PStart;
                DPoint PEnd;
                double chieucaoRec = 0;
                double myZoom = System.Convert.ToDouble(string.Format("{0:E2}", pMap.Zoom.Value));
                int fontSize = 25;
                TextStyle ts = mpxMkTextStyle(fontSize, ".VnArial");
                ts.Font.Size = fontSize;
                MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();               
                for (int i = 0; i < Value.Length; i++)
                {
                    string drectext = "";
                
                    MapInfo.Geometry.LegacyText g = null;
                    if (i == 0)
                    {
                        ts.Font.TextDecoration = MapInfo.Styles.TextDecoration.Underline;
                        g = MapInfo.Text.TextFactory.CreateLegacyText(pMap.GetDisplayCoordSys(), d, Alignment.CenterCenter, Value[i].ToString(), pMap, ts.Font);
                        chieucaoRec = g.TextBounds.Height();
                        g.Layout.Angle = 0;
                        cs.ApplyStyle(ts);
                        UpdateDoiTuong(tab, g, "5", cs, fontSize.ToString() + "," + System.Convert.ToDouble(string.Format("{0:E2}", pMap.Zoom.Value)).ToString());
                    }
                    else if (i == 1)
                    {
                        DPoint dthua = new DPoint();
                        dthua.x =d.x ;
                        dthua.y = d.y - chieucaoRec;
                        ts.Font.TextDecoration = MapInfo.Styles.TextDecoration.None;
                        g = MapInfo.Text.TextFactory.CreateLegacyText(pMap.GetDisplayCoordSys(), dthua, Alignment.CenterCenter, Value[i].ToString(), pMap, ts.Font);
                        g.Layout.Angle = 0;
                        cs.ApplyStyle(ts);
                        UpdateDoiTuong(tab, g, "5", cs, fontSize.ToString() + "," + System.Convert.ToDouble(string.Format("{0:E2}", pMap.Zoom.Value)).ToString());
                    }
                   
                   
                }
            }

        }
        //ham thuc thi viec ve nut diem
        public void mpxDrawNode(MapInfo.Mapping.Map pMap, string pTabName, string newLayer, DPoint[] d, string Nhan, string LayerName)
        {
            MapInfo.Geometry.FeatureGeometry pt;
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(newLayer) == null)
            {
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                //dinh nghia font
                MapInfo.Styles.SimpleVectorPointStyle vs = new MapInfo.Styles.SimpleVectorPointStyle(33, System.Drawing.Color.Black, 10);
                MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(vs);
                for (int i = 0; i < d.Length; i++)
                {
                    //gọi hàm tạo node
                    pt = mpxMkFeaturePoint(pMap.GetDisplayCoordSys(), d[i].x, d[i].y);
                    //update doi tưọng vừa tạo vào bảng
                    UpdateDoiTuong(tab, pt, "3", cs,"");
                }
            }
        }
        //ham thuc thi viec ve duong thang
        public void mpxDrawLine(MapInfo.Mapping.Map pMap, string pTabName, string newLayer, DPoint[] d, CompositeStyle cs, string LayerName, ToolStripProgressBar staProcess)
        {
            //SqlConnection conn = new SqlConnection();
            //clsDatabase clsData = new clsDatabase();
            //conn = clsData.Connect();

            if (MapInfo.Engine.Session.Current.Catalog.GetTable(newLayer) == null)
            {
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                DPoint PStart;
                DPoint PEnd;
                DPoint[] PPoint = new DPoint[2];
                MapInfo.Styles.SimpleLineStyle bl = new MapInfo.Styles.SimpleLineStyle();
                staProcess.Maximum = d.Length;
                staProcess.Value = 0;
                for (int i = 0; i < d.Length - 1; i++)
                {
                    //thiết lập giá trị cho điểm đầu và điểm cuối của cạnh
                    PStart.x = d[i].x;
                    PStart.y = d[i].y;
                    PEnd.x = d[i + 1].x;
                    PEnd.y = d[i + 1].y;
                    PPoint[0] = PStart;
                    PPoint[1] = PEnd;
                    //tạo đối tượng Line
                    MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiCurve(pMap.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, PPoint);

                    MapInfo.Geometry.MultiCurve curve = new MapInfo.Geometry.MultiCurve(pMap.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, PPoint);
                    MapInfo.Geometry.FeatureGeometry curveBuffer = curve.Buffer(500, MapInfo.Geometry.DistanceUnit.Millimeter, 30);
                    //update đối tượng vào bảng
                    UpdateDoiTuong(tab, g, "4", cs,"");
                    staProcess.Value = staProcess.Value + 1;
                }
            }
        }
         public void CreateNewLine(MapControl pMap, Table tab, DPoint [] d ) {
                DPoint PStart;
                DPoint PEnd;
                DPoint[] PPoint = new DPoint[2];
                MapInfo.Styles.SimpleLineStyle bl = new MapInfo.Styles.SimpleLineStyle();
                CompositeStyle cs = new CompositeStyle();
                for (int i = 0; i < d.Length - 1; i++)
                {
                    //thiết lập giá trị cho điểm đầu và điểm cuối của cạnh
                    PStart.x = d[i].x;
                    PStart.y = d[i].y;
                    PEnd.x = d[i + 1].x;
                    PEnd.y = d[i + 1].y;
                    PPoint[0] = PStart;
                    PPoint[1] = PEnd;
                    //tạo đối tượng Line
                    MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiCurve(pMap.Map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, PPoint);
                    //update đối tượng vào bảng
                    UpdateDoiTuong(tab, g, "0", cs,"");
                }
        }
        //ham thuc hien chuc nang gan duong bao
        public void GanDuongBao(string Curent, MapControl mapcontrol, CompositeStyle ts, string Nhan, string LayerName, ToolStripProgressBar staProcess)
        {
            Map pMap = mapcontrol.Map.Layers[LayerName].Map;
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            MapInfo.Data.Feature myfc = MapInfo.Engine.Session.Current.Catalog.SearchForFeature(table, MapInfo.Data.SearchInfoFactory.SearchWhere("featureID<>''"));
            DPoint[] d = null;
            MultiPolygon plg = (MultiPolygon)myfc.Geometry;
            foreach (Polygon pl in plg)
            {
                //lấy tập hợp các đỉnh thửa
                d = pl.Exterior.SamplePoints();
            }
            //gọi hàm vẽ đường
            mpxDrawLine(mapcontrol.Map.Layers[LayerName].Map, mapcontrol.Map.Layers[LayerName].Alias, Nhan, d, ts, LayerName, staProcess);
            mapcontrol.Map.Invalidate();
            table.Refresh();
        }
        //thuc thi viec them doi tuong vao Layer
        public void UpdateDoiTuong(Table tab, FeatureGeometry myFeature, string DoiTuong, CompositeStyle style,string drecText)
        {
            MIConnection Connection = new MIConnection();
            
            Connection.Open();
            if (DoiTuong == "")
            {
                DoiTuong = "0";
            }
           
            int tmpDoiTuong;
            tmpDoiTuong = Convert.ToInt32(DoiTuong);
            MapInfo.Data.MICommand micomm = Connection.CreateCommand();
            //khai báo câu lệnh select
            if ((drecText == "") ||   (drecText == "0"))
            {
                micomm.CommandText = "insert into " + tab.Alias + " (MI_Geometry,MaDoiTuong,MI_STYLE) values(@obj,@MaDoiTuong,@MyStyle)";
                //truyền giá trị tham biến
                micomm.Parameters.Add("@obj", myFeature);
                micomm.Parameters.Add("@MaDoiTuong", DoiTuong);
                micomm.Parameters.Add("@MyStyle", style);
            }
                else
            {
                micomm.CommandText = "insert into " + tab.Alias + " (MI_Geometry,MaDoiTuong,drecText,MI_STYLE) values(@obj,@MaDoiTuong,@drecText,@MyStyle)";
                //truyền giá trị tham biến
                micomm.Parameters.Add("@obj", myFeature);
                micomm.Parameters.Add("@MaDoiTuong", DoiTuong);
                micomm.Parameters.Add("@MyStyle", style);
                micomm.Parameters.Add("@drecText", drecText);
            } 
          
            try
            {
                micomm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            micomm.Dispose();
            Connection.Close();
            Connection.Dispose();
        }
        //thuc thi viec them doi tuong vao Layer
        public void UpdateLoadDoiTuong(Table tab, FeatureGeometry myFeature, string DoiTuong, Style style)
        {
            MIConnection Connection = new MIConnection();
            
            Connection.Open();
            if (DoiTuong == "")
            {
                DoiTuong = "0";
            }
            int tmpDoiTuong;
            tmpDoiTuong = Convert.ToInt32(DoiTuong);
            MapInfo.Data.MICommand micomm = Connection.CreateCommand();
            //khai báo câu lệnh select
            micomm.CommandText = "insert into " + tab.Alias + " (MI_Geometry,MaDoiTuong,MI_STYLE) values(@obj,@MaDoiTuong,@MyStyle)";
            //truyền giá trị tham biến
            micomm.Parameters.Add("@obj", myFeature);
            micomm.Parameters.Add("@MaDoiTuong", DoiTuong);
            micomm.Parameters.Add("@MyStyle", style);
            try
            {
                micomm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            micomm.Dispose();
            Connection.Close();
            Connection.Dispose();
        }
 
        //ham thay doi style cho doi tuong text
        public void setTextStyle(string tblBang, MapControl Map, string Value, Feature f, Table tab, TextStyle ts, double angle, string DoiTuong, long  FeatureID,string LayerName,double DienTichThua,double TyLeZoom)
        { 
            DoiTuong = "";
           DoiTuong = GetMaDoiTuong(f,LayerName); 
           DPoint[] PPoint = new DPoint[2];
           DPoint d = new DPoint();
           d = f.Geometry.Centroid;  
           MapInfo.Geometry.LegacyText g = MapInfo.Text.TextFactory.CreateLegacyText(Map.Map.GetDisplayCoordSys(), d, Alignment.CenterCenter, Value.ToString(), Map.Map, ts.Font);
           g.Layout.Angle = angle;
           CompositeStyle cs = new CompositeStyle();
           cs.ApplyStyle(ts);                   
            //update doi tượng vào bảng
           UpdateDoiTuong(tab, g, DoiTuong, cs, ts.Font.Size.ToString() + "," + System.Convert.ToDouble(string.Format("{0:E2}", Map.Map.Zoom.Value)).ToString());
            //xoa doi tuong cu
            if (f.Key != null)
            {
                tab.DeleteFeature(f);
            }
        }

      public double DienTichCuaNhan(int fontSize, double DienTichThua, double Zoom)
        { // 1point = 0.0375 m
            // dien tich o chu 1 point 	 	0.0375 * 0.0375 = 0.00140625
            //font = 8: ty le 226.37085052427096 / (0.0000140625 * 8) = 20 121.8534
            double DienTichText = 0;
            //DienTichText = DienTichThua * fontSize /  (20*Zoom);
            double tyle = DienTichThua / (40 * Zoom);
            DienTichText = fontSize * tyle;// 0.00140625 * DienTichThua;// (0.00140625 * DienTichThua * Zoom);// 0.00140625 * DienTichThua;// (DienTichThua * 2);
            return DienTichText;
        }

      //public double[] FontSizeText(double zoom)
      //{

      //}
 

        //ham thuc thi viec ve ten cach dinh thua
        public void mpxDrawText(MapControl  pMap, string pTabName, string newLayer, DPoint[] d, double Tyle, int soPolygon,double DienTich)//, TextStyle ts)
        {
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(newLayer) == null)
            {
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(pTabName); 
                DPoint[] PPoint = new DPoint[2];
                //khai báo định dạng font cho text
                double myZoom =System.Convert.ToDouble(string.Format("{0:E2}", pMap.Map.Zoom.Value));
                int fontSize = 20 ;
                TextStyle ts = mpxMkTextStyle(fontSize, ".VnArial");
                ts.Font.Size = fontSize;
                MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();
               
                for (int i = 0; i < d.Length - 1; i++)
                { 
                    MapInfo.Geometry.LegacyText g = MapInfo.Text.TextFactory.CreateLegacyText(pMap.Map.GetDisplayCoordSys(), d[i], Alignment.CenterCenter, (soPolygon + i + 1).ToString(), pMap.Map, ts.Font);
                   
                    cs.ApplyStyle(ts);
                    UpdateDoiTuong(tab, g, "1", cs, fontSize.ToString() + "," + System.Convert.ToDouble(string.Format("{0:E2}", pMap.Map.Zoom.Value)).ToString());
                  
                }
            }
        }

     
        //tim tap hop diem can tim
        public DPoint [] TapHopDiemCanTim(Feature f, DPoint[] d,double KhoangCach,bool chonNghiem)
        {
            DPoint [] DiemCanTim =new DPoint[d.Length ];
            int j = 0;
            for (int i = 0; i < d.Length; i++) {
                j = i + 1;
                if (i == d.Length - 1)
                {
                    DiemCanTim[i] = DiemCanTim[0];//DiemD(f,d[d.Length-1],d[0],KhoangCach, chonNghiem );
                }
                else {
                    DiemCanTim[i] = DiemD(f, d[i], d[j], KhoangCach, chonNghiem);
                }
            }
            return DiemCanTim;
        }
        //tinh toa do o diem D nam tren duong trung truc cua AB va cach ab 1 khoang h
        public DPoint DiemD(Feature f, DPoint DiemA, DPoint DiemB,double KhoangCach, bool ChonNghiem) {
            DPoint DiemCanTim = new DPoint();
            DPoint TrungDiem = new DPoint();
            double xa, xb, ya, yb;
            //khai bao nghiem diem
            DPoint d1 = new DPoint();
            DPoint d2 = new DPoint();
            DPoint d3 = new DPoint();
            DPoint d4 = new DPoint();
            //khai bao he so goc cua cac nghiem voi AB
            double goc1, goc2, goc3, goc4;
            //toa do trugn diem
            TrungDiem.x = Math.Abs( (DiemA.x  + DiemB.x) / 2);
            TrungDiem.y = Math.Abs((DiemA.y + DiemB.y) / 2);
            double hy = Math.Abs((DiemA.x - DiemB.x) * (DiemA.x - DiemB.x));
            double hx = Math.Abs((DiemA.y - DiemB.y) * (DiemA.y - DiemB.y));
            xa = TrungDiem.x - Math.Sqrt(hx);
            xb = TrungDiem.x + Math.Sqrt(hx);
            ya = TrungDiem.y - Math.Sqrt(hy);
            yb = TrungDiem.y + Math.Sqrt(hy);
            //toa do cua 4 diem tim duoc 
            d1.x = xa;
            d1.y = ya;

            d2.x = xa;
            d2.y = yb;

            d3.x = xb;
            d3.y = ya;

            d4.x = xb;
            d4.y = yb;
            //tinh goc
            goc1 = HeSoGoc(DiemA, TrungDiem, d1);
            goc2 = HeSoGoc(DiemA, TrungDiem, d2);
            goc3 = HeSoGoc(DiemA, TrungDiem, d3);
            goc4 = HeSoGoc(DiemA, TrungDiem, d4);
            DPoint [] DiemChia1=new DPoint [2];
            DPoint[] DiemChia2 = new DPoint[2];
            DPoint[] DiemChia3 = new DPoint[2];
            DPoint[] DiemChia4 = new DPoint[2];
            DiemChia1[0] = TrungDiem;
            DiemChia1[1] = d1;
            DiemChia2[0] = TrungDiem;
            DiemChia2[1] = d2;
            DiemChia3[0] = TrungDiem;
            DiemChia3[1] = d3;
            DiemChia4[0] = TrungDiem;
            DiemChia4[1] = d4;
            DPoint diemtmp1 = new DPoint();
            DPoint diemtmp2 = new DPoint();
            DPoint diemtmp3 = new DPoint();
            DPoint diemtmp4 = new DPoint();
            diemtmp1=   ToaDoDiemChia(DiemChia1, KhoangCach);
            diemtmp2 = ToaDoDiemChia(DiemChia2, KhoangCach);
            diemtmp3 = ToaDoDiemChia(DiemChia3, KhoangCach);
            diemtmp4 = ToaDoDiemChia(DiemChia4, KhoangCach);
            if (ChonNghiem)
            {
                if (f.Geometry.ContainsPoint(diemtmp1) && (goc1 == 90))
                {
                    DiemCanTim = diemtmp1;
                }
                if (f.Geometry.ContainsPoint(diemtmp2) && (goc2 == 90))
                {
                    DiemCanTim = diemtmp2;
                }
                if (f.Geometry.ContainsPoint(diemtmp3) && (goc3 == 90))
                {
                    DiemCanTim = diemtmp3;
                }
                if (f.Geometry.ContainsPoint(diemtmp4) && (goc4 == 90))
                {
                    DiemCanTim = diemtmp4;
                }
            }
            else {
                if (!f.Geometry.ContainsPoint(diemtmp1) && (goc1 == 90))
                {
                    DiemCanTim = diemtmp1;
                }
                if (!f.Geometry.ContainsPoint(diemtmp2) && (goc2 == 90))
                {
                    DiemCanTim = diemtmp2;
                }
                if (!f.Geometry.ContainsPoint(diemtmp3) && (goc3 == 90))
                {
                    DiemCanTim = diemtmp3;
                }
                if (!f.Geometry.ContainsPoint(diemtmp4) && (goc4 == 90))
                {
                    DiemCanTim = diemtmp4;
                }
            }

            //kiem tra lại nghiệm
            double Khoangcachmoi =0;
            Khoangcachmoi = TinhKhoangCach2Diem(DiemCanTim, TrungDiem);

            if (Khoangcachmoi - KhoangCach > 1)
            {
                DiemCanTim = TrungDiem;
            }

            return DiemCanTim;

        }
        //tinh toa do o diem D nam tren duong trung truc cua AB va cach ab 1 khoang h
        //diem C la diem nam tren goc chua tia phan giac
        public DPoint DiemGanNhanDinh(DPoint DiemA, DPoint DiemB, DPoint DiemC)
        {
            double Size = 0;
            DPoint DiemCanTim = new DPoint();
            DPoint TrungDiem = new DPoint();
            double xa, xb, ya, yb;
            //khai bao nghiem diem
            DPoint d1 = new DPoint();
            DPoint d2 = new DPoint();
            DPoint d3 = new DPoint();
            DPoint d4 = new DPoint();
            //khai bao he so goc cua cac nghiem voi AB
            double goc1, goc2, goc3, goc4;
            //toa do trugn diem
            TrungDiem.x = Math.Abs((DiemA.x + DiemB.x) / 2);
            TrungDiem.y = Math.Abs((DiemA.y + DiemB.y) / 2);

            Size = TinhKhoangCach2Diem(DiemC, TrungDiem);

            double hy = Math.Abs((DiemA.x - DiemB.x) * (DiemA.x - DiemB.x));
            double hx = Math.Abs((DiemA.y - DiemB.y) * (DiemA.y - DiemB.y));
            xa = TrungDiem.x - Math.Sqrt(hx);
            xb = TrungDiem.x + Math.Sqrt(hx);
            ya = TrungDiem.y - Math.Sqrt(hy);
            yb = TrungDiem.y + Math.Sqrt(hy);
            //toa do cua 4 diem tim duoc 
            d1.x = xa;
            d1.y = ya;

            d2.x = xa;
            d2.y = yb;

            d3.x = xb;
            d3.y = ya;

            d4.x = xb;
            d4.y = yb;
            //tinh goc
            goc1 = HeSoGoc(DiemA, TrungDiem, d1);
            goc2 = HeSoGoc(DiemA, TrungDiem, d2);
            goc3 = HeSoGoc(DiemA, TrungDiem, d3);
            goc4 = HeSoGoc(DiemA, TrungDiem, d4);
            DPoint[] DiemChia1 = new DPoint[2];
            DPoint[] DiemChia2 = new DPoint[2];
            DPoint[] DiemChia3 = new DPoint[2];
            DPoint[] DiemChia4 = new DPoint[2];
            DiemChia1[0] = TrungDiem;
            DiemChia1[1] = d1;
            DiemChia2[0] = TrungDiem;
            DiemChia2[1] = d2;
            DiemChia3[0] = TrungDiem;
            DiemChia3[1] = d3;
            DiemChia4[0] = TrungDiem;
            DiemChia4[1] = d4;
            DPoint diemtmp1 = new DPoint();
            DPoint diemtmp2 = new DPoint();
            DPoint diemtmp3 = new DPoint();
            DPoint diemtmp4 = new DPoint();
            diemtmp1 = ToaDoDiemChia(DiemChia1, Size);
            diemtmp2 = ToaDoDiemChia(DiemChia2, Size);
            diemtmp3 = ToaDoDiemChia(DiemChia3, Size);
            diemtmp4 = ToaDoDiemChia(DiemChia4, Size);
                if ( (goc1 == 90) && diemtmp1.x != DiemC.x && diemtmp1.y != DiemC.y)
                {
                    DiemCanTim = diemtmp1;
                }
                if ((goc2 == 90) && diemtmp2.x != DiemC.x && diemtmp2.y != DiemC.y)
                {
                    DiemCanTim = diemtmp2;
                }
                if ((goc3 == 90) && diemtmp3.x != DiemC.x && diemtmp3.y != DiemC.y)
                {
                    DiemCanTim = diemtmp3;
                }
                if ((goc4 == 90) && diemtmp4.x != DiemC.x && diemtmp4.y != DiemC.y)
                {
                    DiemCanTim = diemtmp4;
                }
         
            return DiemCanTim;

        }
        //lay ra 2 diem co khoang cach nho nhat tu 2 diem(lay ra tam giac can de lay duong trung truc)
        public DPoint[] ToaDo3Dinh(DPoint d1, DPoint d2, DPoint d3) {
            double size1, size2, size3,size;
            DPoint[] ToaDoDiem = new DPoint[2];
            DPoint []DiemChia=new DPoint[2];
            size1 = TinhKhoangCach2Diem(d2, d1);
            size2 = TinhKhoangCach2Diem(d2, d3);
            //lay diem ngan nhat
            if (size1 > size2)
            {
                size = size2;
                ToaDoDiem[0] = d1;
                DiemChia[0]=d2;
                DiemChia[1]=d1;
                ToaDoDiem[1] = ToaDoDiemChia(DiemChia,size2);
            }
            else {
                size = size1;
                ToaDoDiem[0] = d3;
                DiemChia[0] = d2;
                DiemChia[1] = d3;
                ToaDoDiem[1] = ToaDoDiemChia(DiemChia, size1);
            }
            return ToaDoDiem;
        }
        //hàm tạo đối tượng điểm
        public MapInfo.Geometry.FeatureGeometry mpxMkFeaturePoint(MapInfo.Geometry.CoordSys pSys, double x, double y)
        {
            MapInfo.Geometry.Point pt = new MapInfo.Geometry.Point(pSys, x, y);
            MapInfo.Geometry.FeatureGeometry geo = pt as MapInfo.Geometry.FeatureGeometry;
            return geo;
        }
        //hàm tạo đối tượng Table
        public MapInfo.Data.Table mpxMkTable(MapInfo.Geometry.CoordSys pCoordSys, string pTabName, string pColumnName)
        {
            MapInfo.Data.Catalog Cat = MapInfo.Engine.Session.Current.Catalog;
            MapInfo.Data.Table tblTemp = Cat.GetTable(pTabName);
            if (tblTemp != null) Cat.CloseTable(pTabName);
            MapInfo.Data.TableInfoMemTable imt = new MapInfo.Data.TableInfoMemTable(pTabName);
            imt.Columns.Add(MapInfo.Data.ColumnFactory.CreateFeatureGeometryColumn(pCoordSys));
            imt.Columns.Add(MapInfo.Data.ColumnFactory.CreateStyleColumn());
            imt.Columns.Add(MapInfo.Data.ColumnFactory.CreateStringColumn(pColumnName, 40));
            return Cat.CreateTable(imt);
        }
        //hàm tạo đối tượng TextStyle
        public MapInfo.Styles.TextStyle mpxMkTextStyle(System.Drawing.Color pColor, double pSize, string pFontName)
        {
            MapInfo.Styles.TextStyle ts = new MapInfo.Styles.TextStyle();
            ts.Font.ForeColor = pColor;
            ts.Font.Size = pSize;
            ts.Font.Name = pFontName;
            ts.ApplyStyle(ts);
            return ts;
        }
        //hàm tạo đối tượng textstyle
        public MapInfo.Styles.TextStyle mpxMkTextStyle(double pSize, string pFontName)
        {
            MapInfo.Styles.TextStyle ts = new MapInfo.Styles.TextStyle();
            ts.Font.ForeColor = System.Drawing.Color.Black;
            ts.Font.Size = pSize;
            //ts.Font.FontWeight = MapInfo.Styles.FontWeight.Bold;
            ts.Font.Name = pFontName;
            return ts;
        }
        //hàm add thêm dòng cho bảng
        public void mpxTableAddRow(MapInfo.Data.Table pTable, MapInfo.Geometry.FeatureGeometry pGeometry, MapInfo.Styles.Style pStyle, string pColumnName, string pColumnValue)
        {
            Feature ftr = new Feature(pTable.TableInfo.Columns);
            ftr.Geometry = pGeometry;
            ftr.Style = pStyle;
            ftr[pColumnName] = pColumnValue;
            pTable.InsertFeature(ftr);
        }
        public void mpxDrawImg(MapInfo.Mapping.Map pMap, double x, double y, string pTabName)
        {
            string sColName = "name";
            MapInfo.Data.Table dt = mpxMkTable(pMap.GetDisplayCoordSys(), pTabName, sColName);
            MapInfo.Geometry.FeatureGeometry pt = mpxMkFeaturePoint(pMap.GetDisplayCoordSys(), x, y);
            MapInfo.Styles.BitmapPointStyle cs =
                new MapInfo.Styles.BitmapPointStyle("v13.BMP", MapInfo.Styles.BitmapStyles.None, System.Drawing.Color.White, 24);
            mpxTableAddRow(dt, pt, cs, "name", "truck");
            FeatureLayer lyr = new FeatureLayer(dt);
            pMap.Layers.Add(lyr);
            int iLayerIndex = pMap.Layers.IndexOf(lyr);
            pMap.Layers.Move(iLayerIndex, pMap.Layers.Count - 1);
        }

        public double HangSoFont(double HeSoGoc,DRect dr)
        {
            double h = 0;
            double goc = 0;
            double dai = 0;
            goc = HeSoGoc;
            h = dr.Height();
            if (goc >= 180) {
                goc = 360 - goc;
            }
            if (goc < 0)
            {
                goc = Math.Abs(goc);
            }
            dai = h /Math.Abs( Math.Cos(goc));
            return dai;
        }
        //gan nhan kich thuoc cac doan
        public void mpxDrawTextSize(string Current, MapControl  pMap, string pTabName, string newLayer, string[] MySise, DPoint[] d, Double TyLe, double[] HeSoGoc, double DienTich)
        {
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(newLayer) == null)
            {
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(pTabName);
                DPoint[] PPoint = new DPoint[2];
                //khai báo định dạng font cho text
                double myZoom = System.Convert.ToDouble(string.Format("{0:E2}", pMap.Map.Zoom.Value));               
                MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();                 
                for (int i = 0; i < d.Length - 1; i++)
                {
                    TextStyle ts = mpxMkTextStyle(12, ".VnArial");
                    //double HangSoF = 0;
                    //HangSoF = HangSoFont(0, dr);
                    int fontSize = 15;
                    ts.Font.Size = fontSize; 
                    cs.ApplyStyle(ts);
                     MapInfo.Geometry.LegacyText g = MapInfo.Text.TextFactory.CreateLegacyText(pMap.Map.GetDisplayCoordSys(), d[i], Alignment.CenterCenter, MySise[i].ToString(), pMap.Map, ts.Font);
                     g.Layout.Angle = HeSoGoc[i];
                    //update đối tượng vừa tạo vào bảng 
                    UpdateDoiTuong(tab, g, "2", cs, fontSize.ToString() + "," + System.Convert.ToDouble(string.Format("{0:E2}", pMap.Map.Zoom.Value)).ToString());
             
                };
            }
          
        }
         
        public Int16 GetFontSize(MapInfo.Geometry.LegacyText g,MapControl pMap)
        {
             Int16 Fontsize = 0;
            try
            {
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable("Thửa_đất");
                MapInfo.Geometry.LegacyText gtmp = new LegacyText(pMap.Map.GetDisplayCoordSys(), g);
                gtmp.Layout.Angle = 0;
                //ILegacyTextEdit il=  g.GetLegacyTextEditor();
                //il.Rotate(g.Centroid, g.Layout.Angle);
                //////RectangleF rtftmp = new RectangleF();
                //////  MapInfo.Geometry.DisplayTransform cvRTF = pMap.Map.DisplayTransform;
                //////  cvRTF.ToDisplay(g.TextBounds, out rtftmp);


                //////RectangleF rtf = new RectangleF();
                //////rtf = FindBoundingRect(rtftmp, (float)g.Layout.Angle);

                //////Fontsize = Convert.ToInt16(rtf.Height / 1.5);
                //////if (Fontsize < 0)
                //////{
                //////    Fontsize = 1;
                //////} 
                CompositeStyle cs = new CompositeStyle();
              //  cs.TextStyle.Font.Size = 15;
                UpdateDoiTuong(tab, gtmp, "111", cs, "");

                IResultSetFeatureCollection myfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong=111"));
                if (myfc.Count > 0)
                {
                    foreach (Feature f in myfc)
                    {
                        System.Drawing.Rectangle rt = new System.Drawing.Rectangle();
                        TextStyle ts = (TextStyle)f.Style;

                        MapInfo.Geometry.DisplayTransform converter = pMap.Map.DisplayTransform;
                        converter.ToDisplay(f.Geometry.Bounds, out rt);
                        Fontsize = Convert.ToInt16(rt.Height / 1.5);
                        if (Fontsize < 0)
                        {
                            Fontsize = 1;
                        }

                      tab.DeleteFeature(f);
                    }
                }
            }
            catch (Exception ex) { Fontsize = 1; }
           return Fontsize;
        }

        private RectangleF FindBoundingRect(RectangleF rect, float angle)
        {
            // Do a quick short cut here if the text is not really rotated
            // but is instead horizontal or rotated.
            if (angle == 0 || angle == 180 || angle == 360)
            {
                return new RectangleF(0, 0, rect.Width, rect.Height);
            }
            else if (angle == 90 || angle == 270)
            {
                return new RectangleF(0, 0, rect.Height, rect.Width);
            }
            else if (angle > 360)
            {
                // Don't handle this case for now.
                return new RectangleF(0, 0, 0, 0);
            }

            // First transform the angle to radians.
            float radianAngle = angle * (float)(Math.PI / 180.0F);
            float radian90Degrees = 90 * (float)(Math.PI / 180.0F);

            // First find the rotated point 1. This is the bottom right point. The radius
            // for this point is the width.
            float x = (float)(rect.Width * Math.Cos(radianAngle));
            float y = (float)(rect.Width * Math.Sin(radianAngle));
            PointF p1 = new PointF(x, y);

            // Now find point 3 which is also easy. This is the top left point. The
            // radius for this point is the height.
            x = (float)(rect.Height * Math.Cos(radianAngle + radian90Degrees));
            y = (float)(rect.Height * Math.Sin(radianAngle + radian90Degrees));
            PointF p3 = new PointF(x, y);

            // Point 2, the top right point, is a bit trickier. First find the angle
            // from the bottom left up to the top left when the rect is not rotated.
            float radianAngleP2 = (float)Math.Atan(rect.Height / rect.Width);

            // Now find the length of the diagonal line between these two points.
            float radiusP2 = (float)Math.Sqrt((rect.Height * rect.Height) + (rect.Width * rect.Width));

            // Now we can find the x,y of point 2 rotated by the specified angle.
            x = (float)(radiusP2 * Math.Cos(radianAngle + radianAngleP2));
            y = (float)(radiusP2 * Math.Sin(radianAngle + radianAngleP2));

            PointF p2 = new PointF(x, y);

            // Now based on the original angle we can figure out the width and height
            // of our returned rectagle.
            float width = 0;
            float height = 0;

            if (angle < 90)
            {
                width = p1.X + Math.Abs(p3.X);
                height = p2.Y;
            }
            else if (angle < 180)
            {
                width = Math.Abs(p2.X);
                height = p1.Y + Math.Abs(p3.Y);
            }
            else if (angle < 270)
            {
                width = Math.Abs(p1.X) + p3.X;
                height = Math.Abs(p2.Y);
            }
            else
            {
                width = p2.X;
                height = Math.Abs(p1.Y) + p3.Y;
            }

            return new RectangleF(0, 0, width, height);
        }

        //hàm thiết lập style cho text
        public void SetStyleText(MapInfo.Windows.Controls.MapControl mapControl, string strLandLayerName, TextStyle ts, string LayerName)
        {
            Table tab = null;
            //goi bang
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //tap hop cac doi tuong duoc chon
            IResultSetFeatureCollection Lfc = Session.Current.Selections.DefaultSelection[tab];
            if (Lfc == null)
            {
                return;
            }
            if (Lfc.Count == 0)
            {
                return;
            }
            foreach (Feature f in Lfc)
            {
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                {
                    string DoiTuong;
                    DoiTuong = "";
                    DoiTuong = GetMaDoiTuong(f, LayerName); 
                    DPoint d = new DPoint();
                    d = f.Geometry.Centroid; 
                    MapInfo.Geometry.LegacyText gValue = new LegacyText(mapControl.Map.GetDisplayCoordSys(), (LegacyText)f.Geometry);                
                    CompositeStyle cs = new CompositeStyle();
                    cs.ApplyStyle(ts);
                    //xoa doi tuong cu
                    tab.DeleteFeature(f);
                    UpdateDoiTuong(tab, gValue, DoiTuong, cs, ts.Font.Size.ToString() + "," + System.Convert.ToDouble(string.Format("{0:E2}", mapControl.Map.Zoom.Value)).ToString());
                }
            }
            //cap nhat lai cac thong tin cho doi tuong moi
            mapControl.Map.Invalidate();
            tab.Refresh();
         
        }
        //Feature la doi tuong text--------- xu ly doi tuogn text(dua ra ngoai hoac vao trong thua dat)
        public void XuLyText(MapControl map, Feature fLayer, string LayerName, Table tab, Feature f, double size, bool outIn, DPoint Dcenter, bool TrueFalse,DPoint dDiem)
        {

            DPoint dDat = new DPoint();
            DPoint POject = new DPoint();
            POject = f.Geometry.Centroid;


            //Dua ra ngoai
            if (outIn)
            {
                TrueFalse = TrueFalse & false;
                //truong hop Tam nam ben trong cua Thua
                if (setPointOutIn(map, LayerName, fLayer, Dcenter))
                {
                    //truong hop doi tuong da nam ben ngoai doi tuong thi thoi, nam ben trong thi dua ra ngoai
                    if (setPointOutIn(map, LayerName, fLayer, POject))
                    {
                        dDat = dDiem;//2* dDiem.x - POject.x ;
                        //dDat.y = //2 * dDiem.y - POject.y;
                        //if (POject.x > Dcenter.x)
                        //{
                        //    if (POject.y > Dcenter.y)
                        //    {
                        //        dDat.x = POject.x + size;
                        //        dDat.y = POject.y + size;
                        //    }
                        //    //POject.y < Center.y
                        //    else
                        //    {
                        //        dDat.x = POject.x;// +size;
                        //        dDat.y = POject.y - size;
                        //    }
                        //    //  POject.x < Center.x
                        //}
                        //else //POject.x < Dcenter.x
                        //{
                        //    if (POject.y > Dcenter.y)
                        //    {
                        //        dDat.x = POject.x - size;
                        //        dDat.y = POject.y;// +size;
                        //    }
                        //    //POject.y < Center.y
                        //    else
                        //    {
                        //        dDat.x = POject.x - size;
                        //        dDat.y = POject.y - size;
                        //    }
                        //}
                       // SetText(map, tab, f, dDat);
                    }

                } //truong hop Tam nam ben ngoai cua Thua
                //else
                //{
                //    //truong hop doi tuong da nam ben ngoai doi tuong thi thoi, nam ben trong thi dua ra ngoai
                //    if (setPointOutIn(map, LayerName, fLayer, POject))
                //    {
                //        if (POject.x > Dcenter.x)
                //        {
                //            if (POject.y > Dcenter.y)
                //            {
                //                dDat.x = POject.x + size;
                //                dDat.y = POject.y + size;
                //            }
                //            //POject.y < Center.y
                //            else
                //            {
                //                dDat.x = POject.x - size;
                //                dDat.y = POject.y - size;
                //            }
                //            //  POject.x < Center.x
                //        }
                //        else //POject.x < Dcenter.x
                //        {
                //            if (POject.y > Dcenter.y)
                //            {
                //                dDat.x = POject.x - size;
                //                dDat.y = POject.y - size;
                //            }
                //            //POject.y < Center.y
                //            else
                //            {
                //                dDat.x = POject.x - size;
                //                dDat.y = POject.y - size;

                //                //kiem tra lai xem toa do dung chua
                //                if ((Dcenter.x < dDat.x) && (setPointOutIn(map, LayerName, fLayer, POject)))
                //                {

                //                }
                //            }
                //        }
                //        SetText(map, tab, f, dDat);
                //    }
                //}
            }



            //dua vao trong
            else
            {
                //truong hop Tam nam ben trong cua Thua
                if (setPointOutIn(map, LayerName, fLayer, Dcenter))
                {
                    //truong hop doi tuong da nam ben trong doi tuong thi thoi, nam ben ngoai thi dua vao trong
                    if (setPointOutIn(map, LayerName, fLayer, POject) == false)
                    {
                        dDat = dDiem;
                        ////truong hop doi tuong da nam ben trong doi tuong thi thoi, nam ben ngoai thi dua ra trong
                        //if (POject.x > Dcenter.x)
                        //{
                        //    if (POject.y > Dcenter.y)
                        //    {
                        //        dDat.x = POject.x - size;
                        //        dDat.y = POject.y - size;
                        //    }
                        //    //POject.y < Center.y
                        //    else
                        //    {
                        //        dDat.x = POject.x - size;
                        //        dDat.y = POject.y;// +size;
                        //    }
                        //    //  POject.x < Center.x
                        //}
                        //else //POject.x < Dcenter.x
                        //{
                        //    if (POject.y > Dcenter.y)
                        //    {
                        //        dDat.x = POject.x;// +size;
                        //        dDat.y = POject.y - size;
                        //    }
                        //    //POject.y < Center.y
                        //    else
                        //    {
                        //        dDat.x = POject.x + size;
                        //        dDat.y = POject.y + size;
                        //    }
                        //}
                       // SetText(map, tab, f, dDat);
                    }
                    //MessageBox.Show("truong hop Tam nam ben trong cua Thua");
                } //truong hop Tam nam ben ngoai cua Thua
                else
                {
                    dDat = dDiem;
                    //MessageBox.Show("truong hop Tam nam ben ngoai cua Thua");
                    ////truong hop doi tuong da nam ben ngoai doi tuong thi thoi, nam ben trong thi dua ra ngoai
                    //if (setPointOutIn(map, LayerName, fLayer, POject))
                    //{
                    //    if (POject.x > Dcenter.x)
                    //    {
                    //        if (POject.y > Dcenter.y)
                    //        {
                    //            dDat.x = POject.x + size;
                    //            dDat.y = POject.y + size;
                    //        }
                    //        //POject.y < Center.y
                    //        else
                    //        {
                    //            dDat.x = POject.x - size;
                    //            dDat.y = POject.y - size;
                    //        }
                    //        //  POject.x < Center.x
                    //    }
                    //    else //POject.x < Dcenter.x
                    //    {
                    //        if (POject.y > Dcenter.y)
                    //        {
                    //            dDat.x = POject.x - size;
                    //            dDat.y = POject.y - size;
                    //        }
                    //        //POject.y < Center.y
                    //        else
                    //        {
                    //            dDat.x = POject.x - size;
                    //            dDat.y = POject.y - size;

                    //            //kiem tra lai xem toa do dung chua
                    //            if ((Dcenter.x < dDat.x) && (setPointOutIn(map, LayerName, fLayer, POject)))
                    //            {

                    //            }
                    //        }
                    //    }
                    //    SetText(map, tab, f, dDat);
                    //}

                }
            }

        }
        //kiem tra xem toa do cua doi tuong co nam trong layer khong
        public bool setPointOutIn(MapControl pMap, string LayerName, Feature fLayer, DPoint DCenter)
        {
            bool KT;
            KT = false;
            if (DCenter == null)
            {
                return false;
            }
            //Nếu đối tượng là MultiPolygon
            if (fLayer.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
            {
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                //tạo mới đối tượng điểm trung tâm
                MapInfo.Geometry.Point P = new MapInfo.Geometry.Point(pMap.Map.GetDisplayCoordSys(), DCenter);
                //nếu điểm nằm trong thửa
                if (fLayer.Geometry.Contains(P))
                {
                    KT = true;
                }
                //nếu điểm nằm ngoài thửa
                else
                {
                    KT = false;
                }
            }

            return KT;
        }
        //tao danh sach toa do dien cua duong bao
        public DPoint[] NewPoind(MapControl map, Feature fLayer, string LayerName, Table tab, double size, DPoint Dcenter, DPoint[] PBao)
        {
            DPoint[] PNewLine = new DPoint[PBao.Length];
            DPoint dDat = new DPoint();
            //truong hop Tam nam ben trong cua Thua
            if (setPointOutIn(map, LayerName, fLayer, Dcenter))
            {
                for (int i = 0; i < PBao.Length; i++)
                {

                    if (setPointOutIn(map, LayerName, fLayer, PBao[i]))
                    {
                        if (PBao[i].x > Dcenter.x)
                        {
                            if (PBao[i].y > Dcenter.y)
                            {
                                dDat.x = PBao[i].x - size;
                                dDat.y = PBao[i].y - size;
                            }
                            //POject.y < Center.y
                            else
                            {
                                dDat.x = PBao[i].x - size;
                                dDat.y = PBao[i].y + size;
                            }
                            //  POject.x < Center.x
                        }
                        else //POject.x < Dcenter.x
                        {
                            if (PBao[i].y > Dcenter.y)
                            {
                                dDat.x = PBao[i].x + size;
                                dDat.y = PBao[i].y - size;
                            }
                            //POject.y < Center.y
                            else
                            {
                                dDat.x = PBao[i].x + size;
                                dDat.y = PBao[i].y + size;
                            }
                        }

                    }
                    PNewLine[i] = dDat;
                }
            }
            return PNewLine;
        }
        //tao moi 1 doi tuong text
        public void SetText(MapControl pMap, Table tab, Feature fThua, Feature f,int  DoiTuong, DPoint d,bool TrongNgoai)
        {
            TextStyle ts = (TextStyle)f.Style;
            CompositeStyle cs = new CompositeStyle();
            MapInfo.Geometry.LegacyText gtext = new MapInfo.Geometry.LegacyText(pMap.Map.GetDisplayCoordSys(), (LegacyText)f.Geometry);
            MapInfo.Geometry.LegacyText g = MapInfo.Text.TextFactory.CreateLegacyText(pMap.Map.GetDisplayCoordSys(), gtext.Centroid, Alignment.CenterCenter, gtext.Caption.ToString(), pMap.Map, ts.Font);
            g.Layout.Angle = gtext.Layout.Angle;
            cs.ApplyStyle(ts);
            UpdateDoiTuong(tab, g, DoiTuong.ToString(), cs, ts.Font.Size.ToString() + "," + System.Convert.ToDouble(string.Format("{0:E2}", pMap.Map.Zoom.Value)).ToString());
            tab.DeleteFeature(f);
            
        }
        //goi ham thuc thi đưa ra ngoài hoặc đưa vào trong của nhãn đỉnh
        public void ChangeTextInOut(MapControl pMap, string LayerName, int DoiTuong, ToolStripProgressBar staProcess, bool TrongNgoai, double TyLe)
        {

            Table tab = null;
            Feature fLayer = null;
           Table ThuaDat = null;
            //gọi bảng thửa đất
            ThuaDat = MapInfo.Engine.Session.Current.Catalog.GetTable("Tmp");
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            DPoint[] dOject = null;
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[tab];
            if (irfc == null)
            {
                return;
            }
            //lay toa do cac dinh thua
            foreach (Feature f in irfc)
            {
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                {
                    fLayer = f;
                    
                }
                else
                {
                    MessageBox.Show("Chọn đối tượng");
                    return;
                }
            }
            //xu ly text
            IResultSetFeatureCollection fc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong =" + DoiTuong + ""));
            if (fc.Count == 0)
            {
                return;
            }
            else
            {
                DPoint[] d = null;
                d = ToaDoDinhThua(pMap, LayerName);
                DPoint [] dCanh = new DPoint[d.Length];
                if (TyLe >  15){
                    TyLe = 15;      
                }
                foreach (Feature f in irfc)
                {
                     dOject = LayGiaoDiemCacDuongSongSong(pMap, f, ThuaDat, TyLe / 10, LayerName, d, staProcess, TrongNgoai);
                       if (DoiTuong == 2)
                            {
                                for (int i = 0; i < dOject.Length; i++)
                                {
                                    if (i == dOject.Length - 1)
                                    {
                                        dCanh[i] = dCanh[0];
                                        goto outFor;
                                    }

                                    DPoint dTB = ToaDoTrungDiem(dOject[i], dOject[i + 1]);
                                    dCanh[i] = dTB;
                                }
                            outFor:
                                dOject = dCanh;
                            }
                            if (dOject == null)
                            {
                                return;
                            }
                            int k = 0;
                            int j;
                }
             for(int i =0 ; i < fc.Count ;i++){
                            //neu doi tuong la nhan dinh
                
                         if (DoiTuong == 1)
                         {
                             if (dOject[i].x != 0)
                             {
                                 SetText(pMap, tab, fLayer, (Feature)fc[i], DoiTuong, dOject[i], TrongNgoai);
                             }
                         }
                         //neu doi tuong la nhan canh

                         if (DoiTuong == 2)
                         {
                             if (i == 0)
                             {
                                 if (dOject[fc.Count - 1].x != 0)
                                 {
                                     SetText(pMap, tab, fLayer, (Feature)fc[i], DoiTuong, dOject[fc.Count - 1], TrongNgoai);
                                 }
                             }
                             else
                             {
                                 if (dOject[i - 1].x != 0)
                                 {
                                     SetText(pMap, tab, fLayer, (Feature)fc[i], DoiTuong, dOject[i - 1], TrongNgoai);
                                 }
                             }
                        
                 }
                    }
            }
        }
        //thiet lap dinh dang style cho doi tuong node, line, area
        public void SetStyle(MapInfo.Windows.Controls.MapControl mapControl, string strLandLayerName, CompositeStyle cs, string LayerName)
        {
            Table tab = null;
            //goi bang
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //tap hop cac doi tuong duoc chon
            IResultSetFeatureCollection Lfc = Session.Current.Selections.DefaultSelection[tab];
            if (Lfc == null)
            {
                return;
            }
            if (Lfc.Count == 0)
            {
                return;
            }

            foreach (Feature myFeature in Lfc)
            {
                try
                {
                String DoiTuong;
              
                //lấy mã đối tượng
                DoiTuong = GetMaDoiTuong(myFeature,LayerName );
                //cập nhật đối tượng vào bảng
              
                    UpdateDoiTuong(tab, myFeature.Geometry, DoiTuong, cs, "");
                    //xoá đối tượng cũ
                    tab.DeleteFeature(myFeature);
               
            }catch (Exception ex){}
                //refesh map
                mapControl.Invalidate();
                tab.Refresh();
            }
        }
        //ham tao duong bao cho thua dat
        public void TaoDuongBao(MapControl pMap, double size, string LayerName, ToolStripProgressBar staProcess,bool DuongBaoTrongNgoai)
        {
            CompositeStyle cs = new CompositeStyle();
            Table table = null;
            Table ThuaDat = null;
            //gọi bảng thửa đất
            ThuaDat = MapInfo.Engine.Session.Current.Catalog.GetTable("Tmp");
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            MapInfo.Data.IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            DPoint [] d=null;

            try
            {
                foreach (Feature f in irfc){
                DPoint[] dDinhThua = null;
                dDinhThua = ToaDoDinhThua(pMap, LayerName);
                d = LayGiaoDiemCacDuongSongSong(pMap,f,ThuaDat, size, LayerName, dDinhThua, staProcess, DuongBaoTrongNgoai);
                if (d == null) {
                    return;
                }
                    //Định dạng cho đối tượng Line vừa tạo
                    SimpleLineStyle ls = new SimpleLineStyle();
                    ls.Pattern = 3;
                    ls.Width = new LineWidth((double)2, LineWidthUnit.Pixel); ;
                    cs.ApplyStyle(ls);
                    //update đường bao vừa bạo vào Bảng
                    mpxDrawLine(pMap.Map, "", "", d, cs, LayerName, staProcess);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //lay giao diem cua cca duong thang (dung trong truong hop ve duogn bao)
        public DPoint[] LayGiaoDiem(MapControl pMap, Feature f, IResultSetFeatureCollection irfc, ToolStripProgressBar staProcess,bool InOut)
        {
            //khai báo mảng các đối tượng đường
            MultiCurve[] cv = new MultiCurve[irfc.Count];
            int i;
            i = 0;
            for (i = 0; i < irfc.Count; i++)
            {//Nếu đối tượng có kiểu dữliệu MultiCurve
                if (irfc[i].Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                {
                    //gán đối tượng đó vào mảng
                    cv[i] = (MapInfo.Geometry.MultiCurve)irfc[i].Geometry;
                }
            }
            //khai báo tập hợp các đỉnh
            DPoint[] d = new DPoint[i + 1];
            try
            {
                staProcess.Maximum = i;
                staProcess.Value = 0;
                for (int j = 0; j < i; j++)
                {
                    int ChiSo;
                    if (j == i - 1)
                    {
                        ChiSo = 0;
                    }
                    else
                    {
                        ChiSo = j + 1;
                    }
                Nhan:
                    //khai báo đối tượng MultiPoint
                    MapInfo.Geometry.MultiPoint po = new MultiPoint(pMap.Map.GetDisplayCoordSys());
                    //lấy giao điểm của 2 đối tượng Line liền kề nhau
                    if (i == 13) {
                        MessageBox.Show(" ");
                    }

                    po = cv[j].IntersectNodes(cv[ChiSo], IntersectTypes.InclAll);

                    //truong hop khong co giao diem cat nhau
                    if (po.PointCount == 0)
                    {
                        if (ChiSo == i - 1)
                        {
                            ChiSo = 0;
                            goto outFor;
                        }
                        else
                        {
                            ChiSo = ChiSo + 1;
                            goto Nhan;
                        }
                    }
                    else
                    {
                        //truong hop co giao diem
                        for (int k = 0; k < po.PointCount; k++)
                        {
                            //neu giao diem nam trong
                            if (InOut)
                            {
                                //truong hop giao diem nam trong thua thi lay luon
                                if (f.Geometry.ContainsPoint(po[k]))
                                {
                                    d[j] = po[k];
                                }
                                else
                                {
                                    //truong hop giao diem nam ngoai thua thi xet lai
                                    ChiSo = ChiSo + 1;
                                    goto Nhan;
                                }
                            }
                            else
                            {
                                //neu giao diem nam ngoai
                                if (!f.Geometry.ContainsPoint(po[k]))
                                {
                                    d[j] = po[k];
                                }
                                else
                                {
                                    ChiSo = ChiSo + 1;
                                    goto Nhan;
                                }
                            }
                        }
                    }

                    if (j == i - 1)
                    {
                        d[j + 1] = d[0];
                    }
                outFor:
                    staProcess.Value = staProcess.Value + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return d;
        }
        //ham tao duong thang song song
        public void TaoDuongSongSong(MapControl pMap,  double KhoangCach, bool ChonNghiem, string LayerName)
        {
            Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            DPoint[] Pline = new DPoint[2];
            DPoint[] NghiemSongSong = new DPoint[4];
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[tab];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count == 0)
            {
                return;
            }
            Feature f = new Feature(tab.TableInfo.Columns);
            foreach (Feature Cv in irfc)
            {
                if (Cv.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                {
                    MapInfo.Geometry.MultiCurve MulMc = (MapInfo.Geometry.MultiCurve)Cv.Geometry;
                    NghiemSongSong = TaoDuongSongSongKoTangKT(pMap, tab, MulMc, KhoangCach);

                    if (ChonNghiem)
                    {
                        Pline[0] = NghiemSongSong[0];
                        Pline[1] = NghiemSongSong[1];
                    }
                    else
                    {
                        Pline[0] = NghiemSongSong[2];
                        Pline[1] = NghiemSongSong[3];
                    }

                    String DoiTuong;
                    //lấy mã đối tượng
                    DoiTuong = GetMaDoiTuong(Cv, LayerName);
                    //tạo mới đối tượng Line
                    MapInfo.Geometry.MultiCurve curve = new MapInfo.Geometry.MultiCurve(pMap.Map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, Pline);
                    //khai báo định dạng cho Line

                    CompositeStyle cs = new CompositeStyle();
                    cs.ApplyStyle(Cv.Style);
                    Feature fff = new Feature(tab.TableInfo.Columns);
                    fff.Geometry =(FeatureGeometry) curve;
                    fff.Style = cs;
                    //update giá trị vào mảng
                    //tab.InsertFeature(fff);
                    UpdateDoiTuong(tab, curve, DoiTuong, cs,"");
                }
            }
        }
        //di chuyen doi tuong (dung cho sao dep va copy)
        public void MoveObj(MapControl mapControl, string [] DoiTuongCopy, string LayerName, DPoint MousePointEnd)
        {
            Table tab = null;
            //goi bang
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            CompositeStyle cs = new CompositeStyle();
           
            Feature pft = new Feature(tab.TableInfo.Columns);
            for (int i = 0; i < DoiTuongCopy.Length; i++) {
                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchWhere("MI_Key ='" + DoiTuongCopy[i] + "'"));
                if (irfc == null)
                {
                    return;
                }
            
                foreach (Feature f in irfc)
                {
                    //lay ma doi tuong
                    string MaDoiTuong;
                    MaDoiTuong = GetMaDoiTuong(f, LayerName);
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Rectangle"))
                    {

                        MapInfo.Geometry.Rectangle rect = (MapInfo.Geometry.Rectangle)f.Geometry;
                        MapInfo.Geometry.Rectangle rectNew = new MapInfo.Geometry.Rectangle(mapControl.Map.GetDisplayCoordSys(), MousePointEnd, rect.Width(DistanceUnit.Meter, DistanceType.Cartesian), rect.Height(DistanceUnit.Meter, DistanceType.Cartesian), DistanceUnit.Meter, DistanceType.Cartesian); 
                        //MapInfo.Geometry.Rectangle rectNew = new MapInfo.Geometry.Rectangle(mapControl.Map.GetDisplayCoordSys(), rect);
                        //chuyển dạng rectang sang dang MultiPolygon
                        MultiPolygon poly = rectNew.CreateMultiPolygon();
                        pft = new MapInfo.Data.Feature(poly, f.Style);
                        //tạo mới đối tượng
                        UpdateDoiTuong(tab, pft.Geometry, MaDoiTuong, cs,"");
                    }
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Ellipse"))
                    {
                        MapInfo.Geometry.Ellipse rect = (MapInfo.Geometry.Ellipse)f.Geometry;
                        DPoint DCent=new DPoint();
                        double x,y;
                        x=rect.XRadius(DistanceUnit.Meter,DistanceType.Cartesian);
                        y=rect.YRadius(DistanceUnit.Meter,DistanceType.Cartesian);
                        DCent.x=MousePointEnd.x + x/2;
                        DCent.y = MousePointEnd.y - y/2;
                        MapInfo.Geometry.Ellipse rectNew = new MapInfo.Geometry.Ellipse(mapControl.Map.GetDisplayCoordSys(), DCent, x, y, DistanceUnit.Meter, DistanceType.Spherical);
                        //chuyển dạng rectang sang dang MultiPolygon
                        MultiPolygon poly = rectNew.CreateMultiPolygon(18);
                      
                        pft = new MapInfo.Data.Feature(poly, f.Style);
                        //tạo mới đối tượng
                        UpdateDoiTuong(tab, pft.Geometry, MaDoiTuong, cs,"");
                    }
                    //tao moi tung doi tuong
                    //neu doi tuong la multipolygon
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                    {
                        //lay style của đối tượng
                        cs.ApplyStyle(f.Style);
                        DPoint[] d;
                        //chuyển đối tượng về dạng MultiPolygon
                        MultiPolygon fOld = (MultiPolygon)f.Geometry;
                        foreach (Polygon pl in fOld)
                        {
                            //lấy tập hợp toạ độ các đỉnh cả thửa
                            d = pl.Exterior.SamplePoints();
                            //Tạo mảng điẻm của Line
                            DPoint[] NewPoint = NewTmpPoint(d, MousePointEnd);
                            //tạo đối tượng MultiPolygon
                            MultiPolygon mp = new MultiPolygon(mapControl.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, NewPoint);
                            pft = new Feature(mp, cs);
                            //update đppó tượng vào mảng
                            UpdateDoiTuong(tab, pft.Geometry, MaDoiTuong, cs,"");
                        }
                    }
                    //neu doi tuong la multiCurve
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                    {
                        //lay style của đối tượng
                        cs.ApplyStyle(f.Style);
                        DPoint[] d;
                        //chuyển đối tượng sagn dạng MultiCurve
                        MultiCurve tmpLine = (MultiCurve)f.Geometry;
                        foreach (Curve cv in tmpLine)
                        {
                            //lấy toạ độ điểm của Line
                            d = cv.SamplePoints();
                            //khai báo mảng điểm của đối tượng Line
                            DPoint[] NewPoint = NewTmpPoint(d, MousePointEnd);
                            //tạo mới đối tượng Line từ mảng điểm
                            MultiCurve lt = new MultiCurve(mapControl.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, NewPoint);
                            pft.Geometry = lt;
                            //update đối tượng vào bảng
                            UpdateDoiTuong(tab, pft.Geometry, MaDoiTuong, cs,"");
                        }
                    }
                    //neu doi tuong la point
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Point"))
                    {
                        //khai báo style của đối tượng
                        cs.ApplyStyle(f.Style);
                        DPoint[] d = new DPoint[1];
                        //chuyển dối tượng về dạng point
                        MapInfo.Geometry.Point tmpPoint = new MapInfo.Geometry.Point(mapControl.Map.GetDisplayCoordSys(), (MapInfo.Geometry.Point)f.Geometry);
                        d[0].x = tmpPoint.X;
                        d[0].y = tmpPoint.Y;
                        //tạo mới đôi tượng point
                        DPoint[] NewPoint = NewTmpPoint(d, MousePointEnd);
                        MapInfo.Geometry.Point lt = new MapInfo.Geometry.Point(mapControl.Map.GetDisplayCoordSys(), NewPoint[0].x, NewPoint[0].y);
                        pft.Geometry = lt;
                        //update đối tượng vừa tạo vào bảng
                        UpdateDoiTuong(tab, pft.Geometry, MaDoiTuong, cs,"");

                    }
                    //neu doi tuong la legacyText
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                    {
                       int Size = 1;
                        //lay font size
                        LegacyText txt = (LegacyText)f.Geometry;
                        Int16 fontSize =  GetFontSize(txt, mapControl);
                        TextStyle ts = new TextStyle();
                        ts = (TextStyle)f.Style;
                        ts.Font.Size = fontSize;
                        DPoint[] PPoint = new DPoint[2];
                        DPoint d = new DPoint();
                        d = MousePointEnd; 
                        MapInfo.Geometry.LegacyText lt = MapInfo.Text.TextFactory.CreateLegacyText(mapControl.Map.GetDisplayCoordSys(), d, Alignment.CenterCenter, txt.Caption.ToString(), mapControl.Map, ts.Font);
                        lt.Layout.Angle = txt.Layout.Angle;
                        cs.ApplyStyle(ts); 
                        pft.Geometry = lt;
                        pft.Style = cs;
                        UpdateDoiTuong(tab, pft.Geometry, MaDoiTuong, cs, "");
                    }
                }
            }
            mapControl.Map.Invalidate();
            tab.Refresh();

        }
        public int Sizefont(double DienTichText, double DienTichThua, double Zoom)
        { // 1point = 0.0375 m
            // dien tich o chu 1 point 	 	0.0375 * 0.0375 = 0.00140625
            //font = 8: ty le 226.37085052427096 / (0.0000140625 * 8) = 20 121.8534
            double fontSize = 1;
            fontSize = DienTichText * (20 * Zoom) / DienTichThua;
            return Convert.ToInt16(fontSize);
        }
        //dao thu tu vi tri cac dinh
        //public void DaoThuTuDinhThua(MapControl map, Table tab, bool ktXuoiNguoc, string LayerName)
        //{
        //    //lấy tập hợp tất cả các đối tượng nhãn đỉnh
        //    IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong =1"));
        //    if (irfc == null)
        //    {
        //        return;
        //    }
        //    if (irfc.Count == 0)
        //    {
        //        return;
        //    }
        //    int Value;
        //    Value = 1;
        //    foreach (Feature f in irfc)
        //    {
        //        string MaDoiTuong;
        //        //lấy mã đối tượng
        //        MaDoiTuong = GetMaDoiTuong(f, LayerName);
        //        //tạo mới đối tượng nhãn đỉnh
        //        LegacyText OldTextDinh = new LegacyText(map.Map.GetDisplayCoordSys(), (LegacyText)f.Geometry);
        //        Value = Convert.ToInt32(OldTextDinh.Caption);
        //        //nếu đảo theo chiều kim đồng hồ
        //        if (ktXuoiNguoc)
        //        {
        //            if (Value == irfc.Count)
        //            {
        //                Value = 1;
        //            }
        //            else
        //            {
        //                Value = Value + 1;
        //            }
        //        }
        //        //nếu đảo theo chiều ngược kim đồng hồ
        //        else
        //        {

        //            if (Value == 1)
        //            {
        //                Value = irfc.Count;
        //            }
        //            else
        //            {
        //                Value = Value - 1;
        //            }
        //        }
        //        //tạo bounds nhãn đỉnh
                
        //        DPoint d = new DPoint();
        //        DPoint PStart;
        //        DPoint PEnd;
        //        DPoint[] PPoint = new DPoint[2];
        //        d = f.Geometry.Centroid ;
        //        CompositeStyle cs = new CompositeStyle();
        //        TextStyle ts = (TextStyle)f.Style;
        //        double ChieuDai;
        //        double DienTichNhan = 0;
        //        int fontSize =0;
        //        LegacyText txt = (LegacyText)f.Geometry;
        //        //MapInfo.Geometry.DRect rect = MapInfo.Text.TextFactory.CalculateTextBounds(mapControl.Map.GetDisplayCoordSys(), d, Alignment.CenterCenter, txt.Caption.ToString(), System.Convert.ToDouble(string.Format("{0:E2}", pMap.Map.Zoom.Value)), ts.Font);
                
        //        //tạo mới nhãn đỉnh
        //        LegacyText NewTextDinh = new LegacyText(map.Map.GetDisplayCoordSys(), rect, Value.ToString());
        //        //khai báo style cho text
        //        fontSize = Sizefont(rect.Width() * rect.Height(), dlDienTichThua, dlTyLeZoomView);
        //        ts.Font.Size = fontSize;

        //        cs.ApplyStyle(ts);
        //        //update đối tượng vào bảng
            
        //        UpdateDoiTuong(tab, NewTextDinh, MaDoiTuong, cs, drectext);
        //        //xoá đối tượng cũ đi
        //        tab.DeleteFeature(f);
        //    }
        //}
        //kiem tra du lieu va goi ham tao duong chuc nang(sogn song hoac vuogn goc)
        public void TaoDuongChucNang(MapControl pMap, string LayerName, bool ChucNang, double KhoangCach, bool DiemXoay, bool accep, bool ChonNghiem)//, double KhoangCach, bool ChonNghiem, bool ChucNang, bool DiemXoay)
        {
            if (accep)
            {
                if (ChucNang)
                {
                    //neu goi toi chuc nang ta duong song song
                    TaoDuongSongSongVuongGoc(pMap, LayerName, KhoangCach, ChucNang, ChonNghiem, DiemXoay);
                }
                else
                {
                    //neu goi toi chuc nang ta duong vuong goc
                    TaoDuongSongSongVuongGoc(pMap, LayerName, KhoangCach, ChucNang, ChonNghiem, DiemXoay);
                }
            }
        }
        //ham tao duong vuogn goi tao trung diem cua duong
        public void TaoDuongVuongGoc(MapControl pMap, Double KhoangCach, Boolean ChonNghiem, bool DiemXoay, string LayerName)
        {
            MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[tab];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count == 0)
            {
                return;
            }
            Feature f = new Feature(tab.TableInfo.Columns);
            foreach (Feature Cv in irfc)
            {
                if (Cv.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                    {
                        foreach (Curve Cur in (MultiCurve)Cv.Geometry)
                        {
                            //lay ma doi tượng
                            String doiTuong;
                            doiTuong = "";
                            doiTuong = GetMaDoiTuong(Cv, LayerName);

                            DPoint[] d = Cur.SamplePoints();
                            DPoint[] newPoint = new DPoint[2];
                            //tao 1 doi tuong diem de xeet goc quay ban dau cua doi tuong
                            double GocBanDau = 0;
                            GocBanDau = XacDinhGocQuay(d[0], d[1], true);
                            double gocXoay = 0;
                            if (ChonNghiem)
                            {
                                gocXoay = 90;
                            }
                            else
                            {
                                gocXoay = 270;
                            }
                            if (DiemXoay)
                            {
                                newPoint = getAnglePoint(pMap, d[0], d[1], GocBanDau, gocXoay, KhoangCach, true);
                            }
                            else
                            {
                                newPoint = getAnglePoint(pMap, d[1], d[0], GocBanDau, gocXoay, KhoangCach, true);
                            }
                            //tạo đối tượng Line từ toạ độ điểm vừa nhận được
                            MapInfo.Geometry.FeatureGeometry Line = new MapInfo.Geometry.MultiCurve(pMap.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, newPoint);
                            f.Geometry = (FeatureGeometry)Line;
                            f.Style = Cv.Style;
                            CompositeStyle cs = new CompositeStyle();
                            cs.ApplyStyle(f.Style);
                            //update đối tượng vào bảng
                           // tab.InsertFeature(f);
                           UpdateDoiTuong(tab, f.Geometry, doiTuong, cs,"");
                        }
                }
            }
            
        }
         //ham chuc nang tao duong song song va duong vuong goc cua mot canh
        public void TaoDuongSongSongVuongGoc(MapControl pMap, string LayerName, double KhoangCach, bool SV,bool ChonNghiem,bool DiemXoay)
        {
            if (SV)
            //tao duong song song
            {
             //gọi hàm tạo đường song song
                if (ChonNghiem==true)
                {
                    TaoDuongSongSong(pMap,  2 * KhoangCach, true, LayerName );
                }
                //gọi hàm tạo đường song song
                if (ChonNghiem==false)
                {
                    TaoDuongSongSong(pMap,  2 * KhoangCach, false, LayerName);
                }
            }
            //tao duong vuong goc
            else
            {
              TaoDuongVuongGoc(pMap, KhoangCach, ChonNghiem, DiemXoay, LayerName);
                
            }

        }
        //Tao vung tu danh sach toa do nhap vao
        public void TaoVungTuDSToaDo(MapControl pMap, string LayerName, DMC.Interface.GridView.ctrlGridView grdDanhSachToaDo)
        {
            //nếu danh sách toạ đó có từ 3 điểm trở lên
            if (grdDanhSachToaDo.Rows.Count > 2)
            {
                //lấy danh sách toạ độ điểm từ grid
                DPoint[] PointList = new DPoint[grdDanhSachToaDo.Rows.Count];
                PointList = GetPointList(grdDanhSachToaDo);
                CompositeStyle cs = new CompositeStyle();
                //tạo đối tượng Line từ danh sách toạ độ
                MultiCurve mc = new MultiCurve(pMap.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, PointList);

                Table tab = null;
                //gọi bảng hiện thời
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                Table ThuaDat = null;
                //gọi bảng map
                ThuaDat = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                if (MapInfo.Engine.Session.Current.Catalog.GetTable("DPolygon") != null)
                {
                    MapInfo.Engine.Session.Current.Catalog.CloseTable("DPolygon");
                }
                //tạo mới một bảng
                MapInfo.Data.Table dt = CreateTable(pMap.Map, ThuaDat, "DPolygon");

                Feature fff = new Feature(dt.TableInfo.Columns);
                fff.Geometry = (MapInfo.Geometry.FeatureGeometry)mc;
                fff.Style = cs;
                //insert đối tượng Line vừa tạo vào bảng mới tạo
                dt.InsertFeature(fff);
                //gọi đói tượng FeatureProcessor
                MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
                //tạo mới 1 dối tượng Feature
                Feature feature = new Feature(tab.TableInfo.Columns); ;
                //bỏ tất cả select của Map
                MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
                //lay tap hop cac canh song song cua canh cua thua
                IResultSetFeatureCollection fc = Session.Current.Catalog.Search(dt, MapInfo.Data.SearchInfoFactory.SearchAll());
                MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(fc);

                if ((fc == null) || (fc.Count == 0))
                    return;
                //gắn tất cả các đối tượng Line vào 1 đối tượng
                feature = featureProcessor.Combine(fc);
                //insert vào bảng mới tạo
                dt.InsertFeature(feature);

                DPoint[] d;
                //tạo mới 1 dối tượng Line
                MultiCurve mcc = (MultiCurve)feature.Geometry;
                foreach (Curve cv in mcc)
                {//lấy toạ độ điểm của từng đối tượng Line
                    d = cv.SamplePoints();
                    //tạo đối tượng polygon từ danh sách toạ độ vừa nhận
                    MultiPolygon poly = new MultiPolygon(pMap.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, d);
                    //tạo mới đối tượng Feature
                    Feature fea = new Feature(dt.TableInfo.Columns);
                    fea = new MapInfo.Data.Feature(poly, feature.Style);
                    //Insert đối tương polygon vừa tạo vào bảng hiện thời
                    tab.InsertFeature(fea);
                }
                //xoá tất cả các đối tượng Line vừa tạo
                foreach (MapInfo.Data.Feature f in fc)
                {
                    dt.DeleteFeature(f);
                }
                //tắt bảng vừa tạo ở trên
                if (MapInfo.Engine.Session.Current.Catalog.GetTable("DPolygon") != null)
                {
                    MapInfo.Engine.Session.Current.Catalog.CloseTable("DPolygon");
                }
            }
        }
        //xu ly chuc nang xoay doi tuong
        public void XoayDoiTuong(MapControl pMap, string LayerName, bool ChieuQuay, double gocXoay)
        {
            Table table = null;
            DPoint DiemQuay = new DPoint();
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tập hợp tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            IResultSetFeatureCollection myfcDiemXoay = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong=101"));
            if (myfcDiemXoay == null)
            {
                return;
            }
            if (myfcDiemXoay.Count == 0)
            {
                return;
            }
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count == 0)
            {
                return;
            }
            //lay toa do diem đặt làm gốc để xoay đối tượng
            foreach (Feature f in myfcDiemXoay)
            {
                MapInfo.Geometry.Point point = new MapInfo.Geometry.Point(pMap.Map.GetDisplayCoordSys(), (MapInfo.Geometry.Point)f.Geometry);
                DiemQuay.x = point.X;
                DiemQuay.y = point.Y;
            }

            MapInfo.Data.Feature fea = new MapInfo.Data.Feature(table.TableInfo.Columns);
            //khia báo 1 đối tượng MultiPolygon
            MultiPolygon poly = null;
            MapInfo.Data.Feature fff = null;
            fff = new Feature(table.TableInfo.Columns);
            CoordSys coorS = pMap.Map.GetDisplayCoordSys();

            foreach (Feature f in irfc)
            {
                //lay ma doi tượng
                String doiTuong;
                doiTuong = "";
                doiTuong = GetMaDoiTuong(f, LayerName);
                if (doiTuong == "1001") {
                    return;
                }
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Rectangle"))
                {
                    MapInfo.Geometry.Rectangle rect = (MapInfo.Geometry.Rectangle)f.Geometry;

                    MapInfo.Geometry.Rectangle rectNew = new MapInfo.Geometry.Rectangle(coorS, rect);
                    //chuyển dạng rectang sang dang MultiPolygon
                    poly = rectNew.CreateMultiPolygon();
                    foreach (Polygon po in (MultiPolygon)poly)
                    {
                        DPoint[] d = null;
                        d = po.Exterior.SamplePoints();
                        //xac dinh goc quay tai 1 diem

                        DPoint[] ToaDoDiemMoi = new DPoint[d.Length];
                        ToaDoDiemMoi[0] = d[0];
                        for (int i = 0; i < d.Length; i++)
                        {
                            double GocBanDau = 0;
                            double size = 0;
                            size = TinhKhoangCach2Diem(DiemQuay, d[i]);
                            DPoint[] NewPoint = new DPoint[2];
                            GocBanDau = XacDinhGocQuay(DiemQuay, d[i], ChieuQuay);
                            NewPoint = getAnglePoint(pMap, DiemQuay, d[i], GocBanDau, gocXoay, size, ChieuQuay);
                            ToaDoDiemMoi[i] = NewPoint[1];

                        }
                        MultiPolygon newPolygon = new MultiPolygon(pMap.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, ToaDoDiemMoi);

                        fff.Geometry = (FeatureGeometry)newPolygon;
                        fff.Style = f.Style;

                    }
                    CompositeStyle cs = new CompositeStyle();
                    cs.ApplyStyle(f.Style);
                    //update đối tượng vào bảng
                    UpdateDoiTuong(table, fff.Geometry, doiTuong, cs,"");
                }
                //nếu đối tượng có kiểu Elip
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Ellipse"))
                {
                    MapInfo.Geometry.Ellipse elip = (MapInfo.Geometry.Ellipse)f.Geometry;
                    DPoint[] d = null;
                    d = elip.Bounds.DefiningPoints();
                    DRect drect = new DRect();
                    //xac dinh goc quay tai 1 diem
                    //DPoint DiemQuay = new DPoint();
                    DPoint[] ToaDoDiemMoi = new DPoint[d.Length];
                    for (int i = 0; i < d.Length; i++)
                    {
                        double GocBanDau = 0;
                        double size = 0;
                        size = TinhKhoangCach2Diem(DiemQuay, d[i]);
                        DPoint[] NewPoint = new DPoint[2];
                        GocBanDau = XacDinhGocQuay(DiemQuay, d[i], ChieuQuay);
                        NewPoint = getAnglePoint(pMap, DiemQuay, d[i], GocBanDau, gocXoay, size, ChieuQuay);
                        ToaDoDiemMoi[i] = NewPoint[1];
                    }
                    drect.x1 = ToaDoDiemMoi[0].x;
                    drect.y1 = ToaDoDiemMoi[0].y;
                    drect.x2 = ToaDoDiemMoi[1].x;
                    drect.y2 = ToaDoDiemMoi[1].y;
                    MapInfo.Geometry.Ellipse elipNew = new MapInfo.Geometry.Ellipse(coorS, drect);
                    poly = elipNew.CreateMultiPolygon(100);
                    fff.Geometry = (FeatureGeometry)poly;
                    fff.Style = f.Style;
                    CompositeStyle cs = new CompositeStyle();
                    cs.ApplyStyle(f.Style);
                    //update đối tượng vào bảng
                    UpdateDoiTuong(table, fff.Geometry, doiTuong, cs,"");
                }
                //nếu dối tượng có kiểu dữ liệu Legatext
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                {
                    //tạo mới đối tượng LegacyText
                    MapInfo.Geometry.LegacyText LTmp = new MapInfo.Geometry.LegacyText(coorS, (MapInfo.Geometry.LegacyText)f.Geometry);
                    Int16 fontSize =  GetFontSize(LTmp, pMap);
                    double GocBanDau = 0;
                    DPoint[] newPoint = new DPoint[2];
                    DPoint[] ToaDoDiemMoi = new DPoint[2];
                    DPoint[] GocText = new DPoint[LTmp.Bounds.DefiningPoints().Length];
                    GocText = LTmp.Bounds.DefiningPoints();

                    for (int i = 0; i < GocText.Length; i++)
                    {
                        GocBanDau = XacDinhGocQuay(DiemQuay, GocText[i], ChieuQuay);
                        newPoint = getAnglePoint(pMap, DiemQuay, GocText[i], GocBanDau, gocXoay, TinhKhoangCach2Diem(DiemQuay, GocText[i]), ChieuQuay);
                        ToaDoDiemMoi[i] = newPoint[1];
                    }
                    DRect rect = new DRect();

                    rect.x1 = ToaDoDiemMoi[0].x;
                    rect.y1 = ToaDoDiemMoi[0].y;
                    rect.x2 = ToaDoDiemMoi[1].x;
                    rect.y2 = ToaDoDiemMoi[1].y;
                    MapInfo.Geometry.LegacyText Lt = null;
                    if (ChieuQuay)
                    {
                        Lt = new LegacyText(coorS, rect, gocXoay + GocBanDau, LTmp.Caption);
                    }
                    else
                    {
                        Lt = new LegacyText(coorS, rect, gocXoay - GocBanDau, LTmp.Caption);
                    }

                    fff.Geometry = Lt;
                    fff.Style = f.Style;
                    CompositeStyle cs = new CompositeStyle();
                    TextStyle ts = (TextStyle)f.Style;
                    ts.Font.Size = fontSize;
                    cs.ApplyStyle(ts);
                    //update đối tượng vào bảng
                    UpdateDoiTuong(table, fff.Geometry, doiTuong, cs,"");
                }
                //nếu đối tượng có kiểu dữ liệu MultiCurve
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                {
                    foreach (Curve Cur in (MultiCurve)f.Geometry)
                    {
                        DPoint[] d = Cur.SamplePoints();
                        DPoint[] newPoint = new DPoint[2];
                        DPoint[] ToaDoDiemMoi = new DPoint[d.Length];
                        //tao 1 doi tuong diem de xeet goc quay ban dau cua doi tuong
                        double GocBanDau = 0;
                        for (int i = 0; i < d.Length; i++)
                        {
                            GocBanDau = XacDinhGocQuay(DiemQuay, d[i], ChieuQuay);
                            newPoint = getAnglePoint(pMap, DiemQuay, d[i], GocBanDau, gocXoay, TinhKhoangCach2Diem(DiemQuay, d[i]), ChieuQuay);
                            ToaDoDiemMoi[i] = newPoint[1];
                        }

                        //tạo đối tượng Line từ toạ độ điểm vừa nhận được
                        MapInfo.Geometry.FeatureGeometry Line = new MapInfo.Geometry.MultiCurve(coorS, CurveSegmentType.Linear, ToaDoDiemMoi);
                        fff.Geometry = (FeatureGeometry)Line;
                        fff.Style = f.Style;
                        CompositeStyle cs = new CompositeStyle();
                        cs.ApplyStyle(f.Style);
                        //update đối tượng vào bảng
                        UpdateDoiTuong(table, fff.Geometry, doiTuong, cs,"");
                    }

                }
                //nếu đối tượng có kiểu dữ liệu MultiPolygon
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                {

                    foreach (Polygon po in (MultiPolygon)f.Geometry)
                    {
                        DPoint[] d = null;
                        d = po.Exterior.SamplePoints();
                        //xac dinh goc quay tai 1 diem
                        DPoint[] ToaDoDiemMoi = new DPoint[d.Length];
                        for (int i = 0; i < d.Length; i++)
                        {
                            double GocBanDau = 0;
                            double size = 0;
                            size = TinhKhoangCach2Diem(DiemQuay, d[i]);
                            DPoint[] NewPoint = new DPoint[2];
                            GocBanDau = XacDinhGocQuay(DiemQuay, d[i], ChieuQuay);
                            NewPoint = getAnglePoint(pMap, DiemQuay, d[i], GocBanDau, gocXoay, size, ChieuQuay);
                            ToaDoDiemMoi[i] = NewPoint[1];
                        }
                        MultiPolygon newPolygon = new MultiPolygon(pMap.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, ToaDoDiemMoi);

                        fff.Geometry = (FeatureGeometry)newPolygon;
                        fff.Style = f.Style;
                        CompositeStyle cs = new CompositeStyle();
                        cs.ApplyStyle(f.Style);
                        //update đối tượng vào bảng
                        UpdateDoiTuong(table, fff.Geometry, doiTuong, cs,"");
                    }
                }
                table.DeleteFeature(f);
            }
            pMap.Refresh();
        }
        //ham lay tam cua thua dat
        public DPoint GetTamThua(MapControl pMap, string LayerName)
        {

            DPoint TamThua = new DPoint();
            Table table = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong =1001"));
            if (irfc == null)
            {
                return TamThua; ;
            }
            foreach (Feature f in irfc)
            {
                TamThua = f.Geometry.Centroid;
            }
            return TamThua;
        }
        //an dieu khien danh sach toa do(xoa cac nut duoc chon)
        public void AnPanToaDo(System.Windows.Forms.Panel panToaDo, string LayerName)
        {
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong=10"));
            if (irfc == null)
            {
                return;
            }
            else
            {
                foreach (Feature f in irfc)
                {
                    //xoá bằng hết, bằng sạch
                    tab.DeleteFeature(f);
                }
            }

            panToaDo.Hide();
        }
        //hàm tạo mới điểm (dung cho viec chọn điểm ( xem toa do))
        public void getSelectNode(MapControl pMap, DataGridView grDanhSachToaDo, int index, string LayerName)
        {
            if (index >= 0)
            {
                //lấy toạ dộ điểm từ gridview
                DPoint node = new DPoint();
                node.x = Convert.ToDouble(grDanhSachToaDo.Rows[index].Cells[2].Value);
                node.y = Convert.ToDouble(grDanhSachToaDo.Rows[index].Cells[3].Value);
                //lấy bảng hiện thời
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                //dinh nghia font
                MapInfo.Styles.SimpleVectorPointStyle vs = new MapInfo.Styles.SimpleVectorPointStyle(33, System.Drawing.Color.Red, 10);
                MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(vs);
                //tìm tat cả các đối tượng có cùng mã đỗi tượng là 10 (quy định 1 mã để xử lý)
                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong=10"));
                if (irfc == null)
                {
                    return;
                }

                foreach (Feature f in irfc)
                {
                    //xoá bằng hết, bằng sạch
                    tab.DeleteFeature(f);
                }
                //tạo mới đối tượng điểm 
                MapInfo.Geometry.FeatureGeometry pt;
                pt = mpxMkFeaturePoint(pMap.Map.GetDisplayCoordSys(), node.x, node.y);
                MapInfo.Data.Feature pft = new MapInfo.Data.Feature(tab.TableInfo.Columns);
                pft.Geometry = pt;
                pft.Style = cs;
                //quy dinh ma search nay la 10
                UpdateDoiTuong(tab, pt, "10", cs,"");
            }
        }
        //chuc nang copy dinh dang cua doi tuong
        public void CopyDinhDang(MapControl pMap,CompositeStyle CopyStyle, String LayerName)
        {
            //gọi lại bảng hiện thời
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tập hợp tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];

            if ((irfc == null) || (irfc.Count == 0) || (irfc.Count > 1))
            {
                MessageBox.Show("Chọn đối tượng để sao chép định dạng");
                return;
            }
            CompositeStyle cs = new CompositeStyle();
            //cs = Session.Current.Selections.DefaultSelection.Style;
            foreach (Feature f in irfc)
            {

                if (f.Geometry.GetType().ToString() == "MapInfo.Geometry.LegacyText")
                {
                    LegacyText txt = (LegacyText)f.Geometry;
                    Int16 fontSize = GetFontSize(txt, pMap);                   
                    TextStyle ts = (TextStyle)f.Style;
                    ts.Font.Size = fontSize;
                    CopyStyle.ApplyStyle(ts);
                }
                else
                {
                    CopyStyle.ApplyStyle(f.Style);
                }
            }
        }
        //chuc nang dan dinh dang cua doi tuong
        public void DanDinhDang(string tblBang, MapControl pMap, long FeatureID, CompositeStyle CopyStyle, string LayerName,Double DienTichThua, double TyleZoom)
        {
            //gọi lại bảng hiện thời
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tập hợp tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if ((irfc == null) || (irfc.Count == 0))
            {
                MessageBox.Show("Chọn đối tượng để dán định dạng");
                return;
            }
            foreach (Feature myFeature in irfc)
            {

                string doituong;
                doituong = "0";
                //lấy mã đối tượng
                doituong = GetMaDoiTuong(myFeature,LayerName );
                //nếu là đối tượng text
                if (myFeature.Geometry.GetType().ToString() == "MapInfo.Geometry.LegacyText")
                {
                    LegacyText g = (LegacyText)myFeature.Geometry;
                    setTextStyle(tblBang, pMap, g.Caption, myFeature, table, CopyStyle.TextStyle, g.Layout.Angle, doituong, Convert.ToInt64(FeatureID.ToString().Split('.')[0]), LayerName, DienTichThua, TyleZoom);
                }
                //nếu không phải là đối tượng text
                else
                {
                    // xoá đối tượng cũ
                    table.DeleteFeature(myFeature);
                    //gọi hàm tạo mới đối tượng
                    UpdateDoiTuong(table, myFeature.Geometry, doituong, CopyStyle,"");

                }
            }
        }
        //lay ma doi duong de dua vao CSDL
        public String GetMaDoiTuong(Feature myFeature,string LayerName)
        {
            string Value;
            Value = "";
            try{
            MapInfo.Data.MIConnection connection = new MapInfo.Data.MIConnection();
            
            connection.Open();
            MapInfo.Data.MICommand command = connection.CreateCommand();
            command.CommandText = "select MaDoiTuong from " + LayerName + " WHERE obj=@obj";
            command.Parameters.Add("@obj", myFeature.Geometry);
            MapInfo.Data.MIDataReader dataReader = null;
            
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {

                Value = dataReader.GetValue("MaDoiTuong").ToString();
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
            dataReader.Dispose();
            }
            catch(Exception ex ){
               return "";
            }
            return Value;
        }

        //lay ma doi duong de dua vao CSDL
        public String [] GetTextBound(Map map,Feature myFeature, string LayerName)
        {
            string Value = "";
            string[] GiaTriTraVe = new string[2];
            try
            {
                MapInfo.Data.MIConnection connection = new MapInfo.Data.MIConnection();
                
                connection.Open();
                MapInfo.Data.MICommand command = connection.CreateCommand();
                command.CommandText = "select DrecText from " + LayerName + " WHERE obj=@obj";
                command.Parameters.Add("@obj", myFeature.Geometry);
                MapInfo.Data.MIDataReader dataReader = null;

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    Value = dataReader.GetValue("DrecText").ToString();


                    string[] fontZoom = Value.Split(','); 
                    if (fontZoom.Length == 2)
                    {
                        GiaTriTraVe[0] = fontZoom[0];
                        GiaTriTraVe[1] = fontZoom[1];
                    }
                    else
                    {
                        GiaTriTraVe[0] = fontZoom[0];
                        if (map.Zoom.Value > 100)
                        {
                            GiaTriTraVe[1] = "100";
                        }
                        else
                        {
                            GiaTriTraVe[1] = map.Zoom.Value.ToString();
                        } 
                    }
                }
                command.Dispose();
                connection.Close();
                connection.Dispose();
                dataReader.Dispose();
            }
            catch (Exception ex)
            {
                
            }
            return GiaTriTraVe;
        }

        public bool TamDuongTron(MapControl pMap, string LayerName, DPoint dTam)
        {
            Table tab = null;
            tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            if (tab == null)
            {
                return false;
            }

            CompositeStyle cs = new CompositeStyle();
            Feature pft = new Feature(tab.TableInfo.Columns);
            MapInfo.Geometry.Point lt = new MapInfo.Geometry.Point(pMap.Map.GetDisplayCoordSys(), dTam.x, dTam.y);
            pft.Geometry = lt;
            pft.Style = cs;
            UpdateDoiTuong(tab, pft.Geometry, "9", cs,"");
            return true;
        }
        public bool VeDuongTron(MapControl pMap, string LayerName, double BanKinh)
        {
            Table table = null;
            DPoint dTam = new DPoint();
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tập hợp tất cả các đối tượng được chọn
            IResultSetFeatureCollection myfcTam = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong=9"));
            if (myfcTam == null)
            {
                return false;
            }
            if (myfcTam.Count == 0)
            {
                return false;
            }

            //lay toa do diem đặt làm tam hinh trong
            foreach (Feature f in myfcTam)
            {
                MapInfo.Geometry.Point point = new MapInfo.Geometry.Point(pMap.Map.GetDisplayCoordSys(), (MapInfo.Geometry.Point)f.Geometry);
                dTam.x = point.X;
                dTam.y = point.Y;
            }

            // ve duong tron
            Feature pft = new Feature(table.TableInfo.Columns);
            MapInfo.Geometry.Ellipse rect = new Ellipse(pMap.Map.GetDisplayCoordSys(), dTam, BanKinh, BanKinh, DistanceUnit.Meter, DistanceType.Cartesian);
            MultiPolygon poly = rect.CreateMultiPolygon(100);
            DPoint[] d = null;
            foreach (Polygon pl in poly)
            {
                d = pl.Exterior.SamplePoints();
            }

            MapInfo.Data.Table dt = CreateTable(pMap.Map, table, "Polyline");
            CreateNewLine(pMap, dt, d);
            //
            MapInfo.Data.IResultSetFeatureCollection fcNewLine = Session.Current.Catalog.Search(dt, MapInfo.Data.SearchInfoFactory.SearchAll());
            Session.Current.Selections.DefaultSelection.Add(fcNewLine);

            Feature feature = new Feature(dt.TableInfo.Columns);
            /* Tạo Feature từ tập hợp các Feature vừa chọn để combine */
            MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
            feature = featureProcessor.Combine(fcNewLine);
            UpdateDoiTuong(table, feature.Geometry, "", new CompositeStyle(),"");
            //table.InsertFeature(feature);
            dt.Close();
            table.DeleteFeature(myfcTam[0]);
            myfcTam.Table.Close();
            return true;
        }
        public void Giao2DuongTron(MapControl pMap, string LayerName)
        {
            Table table = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tập hợp tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count != 2)
            {

                MessageBox.Show("Chọn hai đoạn thẳng cần lấy giao điểm !");
                return;
            }
            //DPoint GiaoDiem = new DPoint();
            MapInfo.Geometry.MultiPoint GiaoDiem = new MultiPoint(pMap.Map.GetDisplayCoordSys());
            int j = 0;
            //lay giao diem 2 doan thang
            DPoint[] cv = new DPoint[4];
            string MaDoiTuong;
            CompositeStyle cs = new CompositeStyle();
            for (int i = 0; i < irfc.Count - 1; i++)
            {
                cs.ApplyStyle(irfc[i].Style);
                MaDoiTuong = GetMaDoiTuong(irfc[i], LayerName);
                MultiCurve cv1 = new MultiCurve(pMap.Map.GetDisplayCoordSys());
                MultiCurve cv2 = new MultiCurve(pMap.Map.GetDisplayCoordSys());
                if (irfc[i].Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve") && irfc[j].Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                {
                    j = i + 1;
                    cv1 = (MultiCurve)irfc[i].Geometry;
                    cv2 = (MultiCurve)irfc[j].Geometry;
                    GiaoDiem = cv1.IntersectNodes(cv2, IntersectTypes.InclAll);
                    for (int k = 0; k < GiaoDiem.PointCount; k++)
                    {
                        DPoint dp = new DPoint();
                        dp = GiaoDiem[k];
                        FeatureGeometry pt = mpxMkFeaturePoint(pMap.Map.GetDisplayCoordSys(), dp.x, dp.y);
                        UpdateDoiTuong(table, pt, "", new CompositeStyle(),"");
                    }
                }
            }

        }
        //ham chuc nang tinh khoang cach giua 2 diem
        public double TinhKhoangCach2Diem(DPoint c, DPoint d)
        {
            double size;
            size = System.Math.Sqrt(Math.Abs((c.x - d.x) * (c.x - d.x) + (c.y - d.y) * (c.y - d.y)));
            return size;
        }
        //hàm tạo đường song song song cach deu cac canh cua thua để xử lý việc tạo đường bao
        public Table TaoDuongSongSongDuongBao(Feature fThua, MapControl pMap, Table tab, Table TableThua, IResultSetFeatureCollection irfc, double KhoangCach, ToolStripProgressBar staProcess,bool InOut,string LayerName)
        {
            //khai bao trung diem cua canh
            DPoint dTrungDiem = new DPoint();

            if (MapInfo.Engine.Session.Current.Catalog.GetTable("Dline") != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable("Dline");
            }
            MapInfo.Data.Table dt = CreateTable(pMap.Map, tab, "Dline");
            staProcess.Maximum = irfc.Count;
            staProcess.Value = 0;
            foreach (Feature f in irfc)
            {
                DPoint[] Pointline = new DPoint[2];
                DPoint[] Pline = new DPoint[2];
                MapInfo.Geometry.MultiCurve MulMc = (MapInfo.Geometry.MultiCurve)f.Geometry;
                DPoint[] d = new DPoint[2];
                double tyle;
                tyle = 0.0;
                foreach (Curve Mc in MulMc)
                {
                    d = Mc.SamplePoints();
                    tyle = (d[0].x - d[1].x) / (d[0].y - d[1].y);
                    //d = TangToaDoDiem(d, tyle, 2);
                    Pline = d;
                }
                TableThua.DeleteFeature(f);

                double MySize;
                MySize = TinhKhoangCach2Diem(Pline[0], Pline[1]);// System.Math.Sqrt((Pline[0].x - Pline[1].x) * (Pline[0].x - Pline[1].x) + (Pline[0].y - Pline[1].y) * (Pline[0].y - Pline[1].y));
                double x, y, x1, y1, x2, y2;
                //tinh khang cach x
                x = (KhoangCach * (System.Math.Abs(Pline[0].y - Pline[1].y))) / MySize;
                //tinh khoang cach y
                y = Math.Sqrt(KhoangCach * KhoangCach - x * x);
                DPoint[] DLine = new DPoint[2];
                double xc1, xc2, xc3, xc4, yc1, yc2, yc3, yc4, xd1, xd2, xd3, xd4, yd1, yd2, yd3, yd4;
                DPoint c1, c2, c3, c4, d1, d2, d3, d4;
                DPoint t1d1, t1d2, t1d3, t1d4, t2d1, t2d2, t2d3, t2d4, t3d1, t3d2, t3d3, t3d4, t4d1, t4d2, t4d3, t4d4;
                double c1d1, c1d2, c1d3, c1d4, c2d1, c2d2, c2d3, c2d4, c3d1, c3d2, c3d3, c3d4, c4d1, c4d2, c4d3, c4d4;
                double c1b1, c1b2, c1b3, c1b4, c2b1, c2b2, c2b3, c2b4, c3b1, c3b2, c3b3, c3b4, c4b1, c4b2, c4b3, c4b4;
                //lay toa do cac diem la nghiem 
                //toa do điểm C
                xc1 = Pline[0].x - x / 2;
                yc1 = Pline[0].y - y / 2;
                c1.x = xc1;
                c1.y = yc1;

                xc3 = Pline[0].x + x / 2;
                yc3 = Pline[0].y - y / 2;
                c3.x = xc3;
                c3.y = yc3;

                xc2 = Pline[0].x - x / 2;
                yc2 = Pline[0].y + y / 2;
                c2.x = xc2;
                c2.y = yc2;

                xc4 = Pline[0].x + x / 2;
                yc4 = Pline[0].y + y / 2;
                c4.x = xc4;
                c4.y = yc4;

                //toa do diem D
                xd1 = Pline[1].x - x / 2;
                yd1 = Pline[1].y - y / 2;
                d1.x = xd1;
                d1.y = yd1;

                xd3 = Pline[1].x + x / 2;
                yd3 = Pline[1].y - y / 2;
                d3.x = xd3;
                d3.y = yd3;

                xd2 = Pline[1].x - x / 2;
                yd2 = Pline[1].y + y / 2;
                d2.x = xd2;
                d2.y = yd2;

                xd4 = Pline[1].x + x / 2;
                yd4 = Pline[1].y + y / 2;
                d4.x = xd4;
                d4.y = yd4;

                //tinh trung diem cho tung doan de xet truong hop nam trong thua
                //c1d1
                t1d1 = ToaDoTrungDiem(c1, d1);
                c1d1 = TinhKhoangCach2Diem(c1, d1);
                c1b1 = Math.Round(TinhKhoangCach2Diem(c1, Pline[1]), 4);
                // c1d2
                t1d2 = ToaDoTrungDiem(c1, d2);
                c1d2 = TinhKhoangCach2Diem(c1, d2);
                //c1d3
                t1d3 = ToaDoTrungDiem(c1, d3);
                c1d3 = TinhKhoangCach2Diem(c1, d3);
                //c1d4
                t1d4 = ToaDoTrungDiem(c1, d4);
                c1d4 = TinhKhoangCach2Diem(c1, d4);
                //c2d1
                t2d1 = ToaDoTrungDiem(c2, d1);
                c2d1 = TinhKhoangCach2Diem(c2, d1);
                c2b1 = Math.Round(TinhKhoangCach2Diem(c2, Pline[1]), 4);
                // c2d2
                t2d2 = ToaDoTrungDiem(c2, d1);
                c2d2 = TinhKhoangCach2Diem(c2, d2);
                //c2d3
                t2d3 = ToaDoTrungDiem(c2, d3);
                c2d3 = TinhKhoangCach2Diem(c2, d3);
                //c2d4
                t2d4 = ToaDoTrungDiem(c2, d4);
                c2d4 = TinhKhoangCach2Diem(c2, d4);
                //c3d1
                t3d1 = ToaDoTrungDiem(c3, d1);
                c3d1 = TinhKhoangCach2Diem(c3, d1);
                c3b1 = Math.Round(TinhKhoangCach2Diem(c3, Pline[1]), 4);
                // c3d2
                t3d2 = ToaDoTrungDiem(c3, d2);
                c3d2 = TinhKhoangCach2Diem(c3, d2);
                //c3d3
                t3d3 = ToaDoTrungDiem(c3, d3);
                c3d3 = TinhKhoangCach2Diem(c3, d3);
                //c3d4
                t3d4 = ToaDoTrungDiem(c3, d3);
                c3d4 = TinhKhoangCach2Diem(c3, d3);
                //c4d1
                t4d1 = ToaDoTrungDiem(c4, d1);
                c4d1 = TinhKhoangCach2Diem(c4, d1);
                c4b1 = Math.Round(TinhKhoangCach2Diem(c4, Pline[1]), 4);
                // c4d2
                t4d2 = ToaDoTrungDiem(c4, d2);
                c4d2 = TinhKhoangCach2Diem(c4, d2);
                //c4d3
                t4d3 = ToaDoTrungDiem(c4, d3);
                c4d3 = TinhKhoangCach2Diem(c4, d3);
                //c4d4
                t4d4 = ToaDoTrungDiem(c4, d4);
                c4d4 = TinhKhoangCach2Diem(c4, d4);


                double KC;
                KC = Math.Round(Math.Sqrt(KhoangCach * KhoangCach / 4 + MySize * MySize), 4);
                //truong hop gan duong bao trong
                if (InOut)
                {
                    //kiem tra toa do diem (trung diem cua 2 diem nam trong thua va khoang cach 2 diem bang khang cac doan thang cho truoc)
                    if ((fThua.Geometry.ContainsPoint(t1d1)) && (c1d1 == MySize) && (KC == c1b1))
                    {
                        DLine[0] = c1;
                        DLine[1] = d1;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t1d2)) && (c1d2 == MySize) && (KC == c1b1))
                    {
                        DLine[0] = c1;
                        DLine[1] = d2;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t1d3)) && (c1d3 == MySize) && (KC == c1b1))
                    {
                        DLine[0] = c1;
                        DLine[1] = d3;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t1d4)) && (c1d4 == MySize) && (KC == c1b1))
                    {
                        DLine[0] = c1;
                        DLine[1] = d4;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t2d1)) && (c2d1 == MySize) && (KC == c2b1))
                    {
                        DLine[0] = c2;
                        DLine[1] = d1;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t2d2)) && (c2d2 == MySize) && (KC == c2b1))
                    {
                        DLine[0] = c2;
                        DLine[1] = d2;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t2d3)) && (c2d3 == MySize) && (KC == c2b1))
                    {
                        DLine[0] = c2;
                        DLine[1] = d3;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t2d4)) && (c2d4 == MySize) && (KC == c2b1))
                    {
                        DLine[0] = c2;
                        DLine[1] = d4;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t3d1)) && (c3d1 == MySize) && (KC == c3b1))
                    {
                        DLine[0] = c3;
                        DLine[1] = d1;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t3d2)) && (c3d2 == MySize) && (KC == c3b1))
                    {
                        DLine[0] = c3;
                        DLine[1] = d2;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t3d3)) && (c3d3 == MySize) && (KC == c3b1))
                    {
                        DLine[0] = c3;
                        DLine[1] = d3;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t3d4)) && (c3d4 == MySize) && (KC == c3b1))
                    {
                        DLine[0] = c3;
                        DLine[1] = d4;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t4d1)) && (c4d1 == MySize) && (KC == c4b1))
                    {
                        DLine[0] = c4;
                        DLine[1] = d1;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t4d2)) && (c4d2 == MySize) && (KC == c4b1))
                    {
                        DLine[0] = c4;
                        DLine[1] = d2;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t4d3)) && (c4d3 == MySize) && (KC == c4b1))
                    {
                        DLine[0] = c4;
                        DLine[1] = d3;
                        goto Nhan;
                    }
                    if ((fThua.Geometry.ContainsPoint(t4d4)) && (c4d4 == MySize) && (KC == c4b1))
                    {
                        DLine[0] = c4;
                        DLine[1] = d4;
                        goto Nhan;
                    }
                }
                    //truong hop gan duong bao ngoai
                else {
                    //kiem tra toa do diem (trung diem cua 2 diem nam trong thua va khoang cach 2 diem bang khang cac doan thang cho truoc)
                    if (!(fThua.Geometry.ContainsPoint(t1d1)) && (c1d1 == MySize) && (KC == c1b1))
                    {
                        DLine[0] = c1;
                        DLine[1] = d1;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t1d2)) && (c1d2 == MySize) && (KC == c1b1))
                    {
                        DLine[0] = c1;
                        DLine[1] = d2;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t1d3)) && (c1d3 == MySize) && (KC == c1b1))
                    {
                        DLine[0] = c1;
                        DLine[1] = d3;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t1d4)) && (c1d4 == MySize) && (KC == c1b1))
                    {
                        DLine[0] = c1;
                        DLine[1] = d4;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t2d1)) && (c2d1 == MySize) && (KC == c2b1))
                    {
                        DLine[0] = c2;
                        DLine[1] = d1;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t2d2)) && (c2d2 == MySize) && (KC == c2b1))
                    {
                        DLine[0] = c2;
                        DLine[1] = d2;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t2d3)) && (c2d3 == MySize) && (KC == c2b1))
                    {
                        DLine[0] = c2;
                        DLine[1] = d3;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t2d4)) && (c2d4 == MySize) && (KC == c2b1))
                    {
                        DLine[0] = c2;
                        DLine[1] = d4;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t3d1)) && (c3d1 == MySize) && (KC == c3b1))
                    {
                        DLine[0] = c3;
                        DLine[1] = d1;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t3d2)) && (c3d2 == MySize) && (KC == c3b1))
                    {
                        DLine[0] = c3;
                        DLine[1] = d2;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t3d3)) && (c3d3 == MySize) && (KC == c3b1))
                    {
                        DLine[0] = c3;
                        DLine[1] = d3;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t3d4)) && (c3d4 == MySize) && (KC == c3b1))
                    {
                        DLine[0] = c3;
                        DLine[1] = d4;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t4d1)) && (c4d1 == MySize) && (KC == c4b1))
                    {
                        DLine[0] = c4;
                        DLine[1] = d1;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t4d2)) && (c4d2 == MySize) && (KC == c4b1))
                    {
                        DLine[0] = c4;
                        DLine[1] = d2;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t4d3)) && (c4d3 == MySize) && (KC == c4b1))
                    {
                        DLine[0] = c4;
                        DLine[1] = d3;
                        goto Nhan;
                    }
                    if (!(fThua.Geometry.ContainsPoint(t4d4)) && (c4d4 == MySize) && (KC == c4b1))
                    {
                        DLine[0] = c4;
                        DLine[1] = d4;
                        goto Nhan;
                    }
                
                }
            Nhan:
                DLine = TangToaDoDiem(DLine, tyle, 5000);

                dt = InsertTableDuongBao(pMap, f, dt, DLine, LayerName);
                staProcess.Value = staProcess.Value + 1;
                
            }
            return dt;
        }
        //tinh toa do trung diem cua doan thang
        public DPoint ToaDoTrungDiem(DPoint c1, DPoint d1)
        {
            DPoint dTrungDiem = new DPoint();
            dTrungDiem.x = (c1.x + d1.x) / 2;
            dTrungDiem.y = (c1.y + d1.y) / 2;
            return dTrungDiem;
        }
        //insert bảng
        public Table InsertTableDuongBao(MapControl pMap, Feature f, Table dt, DPoint[] DLine,string LayerName)
        {
            String DoiTuong;
            DoiTuong = GetMaDoiTuong(f, LayerName);
            MapInfo.Geometry.MultiCurve curve = new MapInfo.Geometry.MultiCurve(pMap.Map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, DLine);
            CompositeStyle cs = new CompositeStyle();
            Feature fff = new Feature(dt.TableInfo.Columns);
            fff.Geometry = curve;
            fff.Style = f.Style;
            dt.InsertFeature(fff);
            return dt;
        }
        //ham tao 1 bang moi trong map
        public MapInfo.Data.Table CreateTable(MapInfo.Mapping.Map map, Table tabTmp, string strNewTableName)
        {
            FeatureLayer fl = new FeatureLayer(tabTmp);
            MapInfo.Data.TableInfo tableInfo = MapInfo.Data.TableInfoFactory.CreateTemp(strNewTableName, fl.CoordSys);
            for (int i = 0; i < tabTmp.TableInfo.Columns.Count - 1; i++)
            {
                if ((tabTmp.TableInfo.Columns[i].Alias != "MI_Geometry") & (tabTmp.TableInfo.Columns[i].Alias != "MI_Style"))
                {
                    tableInfo.Columns.Add(new MapInfo.Data.Column(tabTmp.TableInfo.Columns[i].Alias, tabTmp.TableInfo.Columns[i].DataType));
                }
             
            }
            MapInfo.Data.Table tableNew = MapInfo.Engine.Session.Current.Catalog.CreateTable(tableInfo);
            return tableNew;
        }
        //tim toa do moi cua doi tuong
        public DPoint[] NewTmpPoint(DPoint[] OldPoint, DPoint EndPoint)
        {
            DPoint[] NewP = new DPoint[OldPoint.Length];
            double x, y;
            //tinh khang cach x
            x = Math.Abs(OldPoint[0].x - EndPoint.x);
            //tinh khoang cach y
            y = Math.Abs(OldPoint[0].y - EndPoint.y);
            for (int i = 0; i < OldPoint.Length; i++)
            {
                if (OldPoint[0].x > EndPoint.x)
                {
                    if (OldPoint[0].y > EndPoint.y)
                    {
                        //tinh toa do x cua diem thu 2]
                        NewP[i].x = OldPoint[i].x - x;
                        //tinh toa do y cua diem thu 2
                        NewP[i].y = OldPoint[i].y - y;
                    }
                    else
                    {
                        //tinh toa do x cua diem thu 2]
                        NewP[i].x = OldPoint[i].x - x;
                        //tinh toa do y cua diem thu 2
                        NewP[i].y = OldPoint[i].y + y;
                    }
                }
                else
                {
                    if (OldPoint[0].y > EndPoint.y)
                    {
                        //tinh toa do x cua diem thu 2]
                        NewP[i].x = OldPoint[i].x + x;
                        //tinh toa do y cua diem thu 2
                        NewP[i].y = OldPoint[i].y - y;
                    }
                    else
                    {
                        //tinh toa do x cua diem thu 2]
                        NewP[i].x = OldPoint[i].x + x;
                        //tinh toa do y cua diem thu 2
                        NewP[i].y = OldPoint[i].y + y;
                    }
                }
            }
            return NewP;
        }
        //ham dung de di chuyen panel (su kien mouseMove)
        public void PanMouseMove(System.Windows.Forms.Panel p, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Control C = p;
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    int dx = Control.MousePosition.X - MousePositionBeforeMoved.X;
                    int dy = Control.MousePosition.Y - MousePositionBeforeMoved.Y;
                    C.Location = new System.Drawing.Point(LocationBeforeMoved.X + dx, LocationBeforeMoved.Y + dy);
                }
            }
        }
        //ham dung de di chuyen panel (su kien mouseDown)
        public void PanMouseDown(System.Windows.Forms.Panel p, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MousePositionBeforeMoved = Control.MousePosition;
                LocationBeforeMoved = p.Location;
            }
        }
        //ham dung de di chuyen panel (su kien mouseMove)
        public void ToolMouseMove(System.Windows.Forms.ToolStrip p, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Control C = p;
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    int dx = Control.MousePosition.X - MousePositionBeforeMoved.X;
                    int dy = Control.MousePosition.Y - MousePositionBeforeMoved.Y;
                    C.Location = new System.Drawing.Point(LocationBeforeMoved.X + dx, LocationBeforeMoved.Y + dy);
                }
            }
        }
        //ham dung de di chuyen panel (su kien mouseDown)
        public void ToolMouseDown(System.Windows.Forms.ToolStrip  p, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MousePositionBeforeMoved = Control.MousePosition;
                LocationBeforeMoved = p.Location;
            }
        }
        //Dua toan bo du lieu hieu co tu CSDl len layer khi load
        public void addObj(string tblBang, MapControl map, CoordSys coorS, IResultSetFeatureCollection irfc, Table dt)
        {
            CompositeStyle cs = new CompositeStyle();
            //clsDatabase clsData = new clsDatabase();
            foreach (Feature myFeature in irfc)
            {
                //lay ma doi tượng
                String doiTuong;
                doiTuong = "";
                doiTuong = clsData.getValue(tblBang, "Madoituong", myFeature.Key.Value.ToString().Split('.')[0]);

                //khai bao 1 Feature mới
                MapInfo.Data.Feature f = new MapInfo.Data.Feature(dt.TableInfo.Columns);
                //khia báo 1 đối tượng MultiPolygon
                MultiPolygon poly = null;
                MapInfo.Data.Feature fff = null;
                //Nến đối tượng có kiểu dữ liệu là Rectangle
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Rectangle"))
                {
                    MapInfo.Geometry.Rectangle rect = (MapInfo.Geometry.Rectangle)myFeature.Geometry;
                    MapInfo.Geometry.Rectangle rectNew = new MapInfo.Geometry.Rectangle(coorS, rect);
                    //chuyển dạng rectang sang dang MultiPolygon
                    poly = rectNew.CreateMultiPolygon();
                    fff = new MapInfo.Data.Feature(poly, myFeature.Style);
                    //tạo mới đối tượng
                    f.Geometry = fff.Geometry;
                    f.Style = myFeature.Style;
                    cs.ApplyStyle(myFeature.Style);
                    //update đối tượng vào bảng
                    UpdateDoiTuong(dt, f.Geometry, doiTuong, cs, "");
                }
                //nếu đối tượng có kiểu Elip
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Ellipse"))
                {
                    MapInfo.Geometry.Ellipse elip = (MapInfo.Geometry.Ellipse)myFeature.Geometry;
                    MapInfo.Geometry.Ellipse elipNew = new MapInfo.Geometry.Ellipse(coorS, elip);
                    //chuyển dạng Elip ve kiểu MultiPolygon
                    poly = elipNew.CreateMultiPolygon(100);
                    fff = new MapInfo.Data.Feature(poly, myFeature.Style);
                    //tạo mới đối tượng
                    f.Geometry = fff.Geometry;
                    f.Style = myFeature.Style;
                    cs.ApplyStyle(myFeature.Style);
                    //update đối tượng vào bảng
                    UpdateDoiTuong(dt, f.Geometry, doiTuong, cs, "");
                }
                //nếu đối tượng có kiểu dữ liệu là Point
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Point"))
                {
                    //tạo mới 1 đối tượng Point
                    MapInfo.Geometry.Point point = new MapInfo.Geometry.Point(coorS, (MapInfo.Geometry.Point)myFeature.Geometry);
                    f.Geometry = point;
                    f.Style = myFeature.Style;
                    cs.ApplyStyle(myFeature.Style);
                    //update đối tượng vào bảng
                    UpdateDoiTuong(dt, f.Geometry, doiTuong, cs, "");
                }
                //nếu dối tượng có kiểu dữ liệu Legatext
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                {
                   
                    TextStyle ts = new TextStyle();
                    LegacyText txt = (LegacyText)myFeature.Geometry;
                    Int16 fontSize =  GetFontSize(txt, map);
                    ts = (TextStyle)f.Style;
                    ts.Font.Size = fontSize;
                    MapInfo.Geometry.LegacyText lt = MapInfo.Text.TextFactory.CreateLegacyText(coorS, txt.Centroid, Alignment.CenterCenter, txt.Caption.ToString(), map.Map, ts.Font);
                    lt.Layout.Angle = txt.Layout.Angle;
                    cs.ApplyStyle(ts); 
                    //update đối tượng vào bảng
                    UpdateDoiTuong(dt, lt, doiTuong, cs, "");
                }
                //nếu đối tượng có kiểu dữ liệu MultiCurve
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                {
                    foreach (Curve Cur in (MultiCurve)myFeature.Geometry)
                    {
                        //lấy toạ độ điểm đầu và cuối
                        DPoint[] d = Cur.SamplePoints();
                        //tạo đối tượng Line từ toạ độ điểm vừa nhận được
                        MapInfo.Geometry.FeatureGeometry Line = new MapInfo.Geometry.MultiCurve(coorS, CurveSegmentType.Linear, d);
                        f.Geometry = Line;
                        f.Style = myFeature.Style;
                    }
                    cs.ApplyStyle(myFeature.Style);
                    //update đối tượng vào bảng
                    UpdateDoiTuong(dt, f.Geometry, doiTuong, cs, "");
                }
                //nếu đối tượng có kiểu dữ liệu MultiPolygon
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                {
                    foreach (Polygon Cur in (MultiPolygon)myFeature.Geometry)
                    {
                        f.Geometry = myFeature.Geometry;
                        f.Style = myFeature.Style;
                    }
                    cs.ApplyStyle(myFeature.Style);
                    //update đối tượng vào bảng
                    UpdateDoiTuong(dt, f.Geometry, doiTuong, cs, "");
                }
                //thiết lập định dạng cho đối tượng Feature vừa tạo
              
                
            }
            map.Map.Invalidate();
            dt.Refresh();

        }
        //lay gia tri cua truong dua vao ten bang va ten tuong (lay ngay tren Map)
        public string GetValueField(Table tab, string ColumnName)
        {
            MapInfo.Engine.Selection selection = MapInfo.Engine.Session.Current.Selections.DefaultSelection;
            MapInfo.Data.IResultSetFeatureCollection featureCollection = selection[tab];
            MapInfo.Data.MIConnection connection = new MapInfo.Data.MIConnection();
            
            connection.Open();

            MapInfo.Data.MICommand command = connection.CreateCommand();
            command.CommandText = "select Sothua from " + tab.Alias + " where WHERE obj=obj";

            MapInfo.Data.MIDataReader dataReader = command.ExecuteReader();

            string Value;
            Value = "";
            while (dataReader.Read())
            {
                Value = (string)dataReader.GetValue(ColumnName);
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
            dataReader.Dispose();
            return Value;

        }
        //xoa nhan cua cac feature
        public void XoaNhan(MapControl pMap, string Kieu, string MaDoiTuong, string LayerName)
        {
            //lấy tập hợp các đối tượng được chọn theo ma đối tượng
            IResultSetFeatureCollection irfc = getfeatureColec(MaDoiTuong, LayerName);
            //gọi hàm gọi bảng hiện thời
            Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            foreach (MapInfo.Data.Feature f in irfc)
            {
                //delete
                table.DeleteFeature(f);
            }
            pMap.Map.Invalidate();
            table.Refresh();
        }
        //Thuc hien viec chon cac lop doi tuong de xu ly
        public void TachLopDoiTuong(string MaDoiTuong, string LayerName)
        {
            SelectFeatureCollection(getfeatureColec(MaDoiTuong, LayerName));
        }
        //lay tap hop cac doi tuong dua vao madoituong
        public MapInfo.Data.IResultSetFeatureCollection getfeatureColec(string MaDoiTuong, string LayerName)
        {
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(LayerName, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong = " + MaDoiTuong + ""));
            return irfc;
        }
        //thuc thi viec select cac doi tuong duoc chon
        public void SelectFeatureCollection(IResultSetFeatureCollection fc)
        {
            //xoa tat ca các đối tượng đã chọn
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            //select các đối tượng đã được chọn
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(fc);
        }
        //ham thuc thi cong viec xoa cac feature
        public void XoaFeature(MapControl mapcontrol, string Tenbang, string Kieu, string MaDoiTuong, string LayerName)
        {
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(Tenbang) != null)
            {
                //xoa feature temp
                for (int i = 0; i < mapcontrol.Map.Layers.Count; i++)
                {
                    if (mapcontrol.Map.Layers[i].Alias == Tenbang)
                    {
                        mapcontrol.Map.Layers.Remove(Tenbang);
                        MapInfo.Engine.Session.Current.Catalog.CloseTable(Tenbang);
                    }
                }
                //xoa feature da ton tai
                XoaNhan(mapcontrol, Kieu, MaDoiTuong, LayerName);
            }
            else
            {
                //xoa feature da ton tai
                XoaNhan(mapcontrol, Kieu, MaDoiTuong, LayerName);
            }
        }
        //Lay danh sach toa do dinh Thua
        public DPoint[] ToaDoDinhThua(MapControl pMap, string LayerName)
        { 
         Table table = null;
            DPoint[] d = null;
            //gọi bảng hiện thời
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tập hợp tất cả các dối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
           if (irfc == null)
            {
                return null;
            }
            if (irfc.Count == 0)
            {
                return null;
            } 
            try
            {
                Table ThuaDat = null;
                //gọi bảng thửa đất
                ThuaDat = MapInfo.Engine.Session.Current.Catalog.GetTable("Tmp");

                //DPoint[] dPhanGiac = null;
                foreach (Feature f in irfc)
                {
                    //nếu đối tượng có kiểu dữ liệu MultiPolygon
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                    {
                        foreach (Polygon pl in (MultiPolygon)f.Geometry)
                        {
                            //Lấy tập hợp tất cả các đỉnh thửa
                            d = pl.Exterior.SamplePoints();
                        }
                    }
                }
            }
            catch (Exception ex)
            {}
            return d;
        }
        //Lay danh sach toa do dinh Thua
        public DPoint[] ToaDoTrungDiemCanh(MapControl pMap, string LayerName)
        {
                DPoint[] d = ToaDoDinhThua(pMap, LayerName);
                if (d == null) {
                    return null;
                }
                DPoint[] dSize = new DPoint[d.Length];
                int j;

                for (int i = 0; i < d.Length; i++)
                {
                    j = i + 1;
                  
                    if (i == d.Length - 1)
                    {
                        dSize[d.Length - 1] = dSize[0];
                        goto Nhan;
                    }
                   //Lay toa do dien trung tam cua cac canh giua 2 dinh
                    dSize[i].x = System.Math.Abs(d[i].x + d[j].x) / 2;
                    dSize[i].y = System.Math.Abs(d[i].y + d[j].y) / 2;
                
                }
            Nhan:
            return dSize;
        }
        public DPoint[] LayGiaoDiemCacDuongSongSong(MapControl pMap,Feature fObject,Table ThuaDat, double size, string LayerName, DPoint []d, ToolStripProgressBar staProcess,bool DuongBaoTrongNgoai)
        { 
        CompositeStyle cs = new CompositeStyle();
            Table table = null;
           DPoint[] dDiem = null;
            //gọi bảng hiện thời
          // SelecThuaDat(LayerName);
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);

            
            //irfc = Session.Current.Selections.DefaultSelection[table];
            //lấy tập hợp tất cả các đối tượng là Line
            IResultSetFeatureCollection fLine = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong =4"));
            //xoa duong bao cu
            if (fLine != null)
            {
                foreach (Feature f in fLine)
                {
                    table.DeleteFeature(f);
                }
            }
           
            //d = ToaDoDinhThua(pMap, LayerName);
            try
            {
                Feature f = fObject;
                    if (d != null)
                    {
                        //vẽ lại các đường Line xung quanh thửa đất
                        mpxDrawLine(pMap.Map, "", "", d, cs, LayerName, staProcess);
                        //tao cac canh cua thua dat
                        IResultSetFeatureCollection fcc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong =4"));
                        Table tab = null;
                        //lay cac duong song song voi cac canh cua thua dat
                        tab = TaoDuongSongSongDuongBao(f, pMap, ThuaDat, table, fcc, size, staProcess, DuongBaoTrongNgoai,LayerName );
                        //xoa cac vung bi chon
                        MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
                        //lay tap hop cac canh song song cua canh cua thua
                        IResultSetFeatureCollection fc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());
                        MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(fc);
                        //lay giao diem cac canh song song song do
                        dDiem = LayGiaoDiem(pMap, f, fc, staProcess, DuongBaoTrongNgoai);
                        SelecThuaDat(LayerName);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dDiem;
        }
        /// <summary>  tao duong song song khong tang kich thuoc</summary>
        /// <param name="pMap"></param>
        /// <param name="tab"></param>
        /// <param name="MulMc"></param>
        /// <param name="KhoangCach"></param>
        /// <returns></returns>

        public DPoint [] TaoDuongSongSongKoTangKT(MapControl pMap, Table tab, MapInfo.Geometry.MultiCurve MulMc, double KhoangCach)
        {
            CompositeStyle cs = new CompositeStyle();
            
            //lay ra 2 nghiem dung(can 4 diem)
                DPoint[] TapHopNghiem = new DPoint[4];
                DPoint[] Pointline = new DPoint[2];
                DPoint[] Pline = new DPoint[2];
                DPoint[] d = new DPoint[2];
                double tyle;
                tyle = 0.0;
                foreach (Curve Mc in MulMc)
                {
                    d = Mc.SamplePoints();
                    tyle = (d[0].x - d[1].x) / (d[0].y - d[1].y);
                    //d = TangToaDoDiem(d, tyle, 2);
                    Pline = d;
                }

                double MySize;
                MySize = TinhKhoangCach2Diem(Pline[0], Pline[1]);// System.Math.Sqrt((Pline[0].x - Pline[1].x) * (Pline[0].x - Pline[1].x) + (Pline[0].y - Pline[1].y) * (Pline[0].y - Pline[1].y));
                double x, y;
                //tinh khang cach x
                x = (KhoangCach * (System.Math.Abs(Pline[0].y - Pline[1].y))) / MySize;
                //tinh khoang cach y
                y = Math.Sqrt(KhoangCach * KhoangCach - x * x);
                DPoint[] DLine = new DPoint[2];
                double xc1, xc2, xc3, xc4, yc1, yc2, yc3, yc4, xd1, xd2, xd3, xd4, yd1, yd2, yd3, yd4;
                DPoint c1, c2, c3, c4, d1, d2, d3, d4;
                double c1d1, c1d2, c1d3, c1d4, c2d1, c2d2, c2d3, c2d4, c3d1, c3d2, c3d3, c3d4, c4d1, c4d2, c4d3, c4d4;
                double c1b1, c2b1, c3b1,  c4b1;
                //lay toa do cac diem la nghiem 
                //toa do điểm C
                xc1 = Pline[0].x - x / 2;
                yc1 = Pline[0].y - y / 2;
                c1.x = xc1;
                c1.y = yc1;

                xc3 = Pline[0].x + x / 2;
                yc3 = Pline[0].y - y / 2;
                c3.x = xc3;
                c3.y = yc3;

                xc2 = Pline[0].x - x / 2;
                yc2 = Pline[0].y + y / 2;
                c2.x = xc2;
                c2.y = yc2;

                xc4 = Pline[0].x + x / 2;
                yc4 = Pline[0].y + y / 2;
                c4.x = xc4;
                c4.y = yc4;

                //toa do diem D
                xd1 = Pline[1].x - x / 2;
                yd1 = Pline[1].y - y / 2;
                d1.x = xd1;
                d1.y = yd1;

                xd3 = Pline[1].x + x / 2;
                yd3 = Pline[1].y - y / 2;
                d3.x = xd3;
                d3.y = yd3;

                xd2 = Pline[1].x - x / 2;
                yd2 = Pline[1].y + y / 2;
                d2.x = xd2;
                d2.y = yd2;

                xd4 = Pline[1].x + x / 2;
                yd4 = Pline[1].y + y / 2;
                d4.x = xd4;
                d4.y = yd4;

                //tinh trung diem cho tung doan de xet truong hop nam trong thua
                //c1d1
                c1d1 = TinhKhoangCach2Diem(c1, d1);
                c1b1 = Math.Round(TinhKhoangCach2Diem(c1, Pline[1]), 4);
                // c1d2
                c1d2 = TinhKhoangCach2Diem(c1, d2);
                //c1d3
                c1d3 = TinhKhoangCach2Diem(c1, d3);
                //c1d4
                c1d4 = TinhKhoangCach2Diem(c1, d4);
                //c2d1
                c2d1 = TinhKhoangCach2Diem(c2, d1);
                c2b1 = Math.Round(TinhKhoangCach2Diem(c2, Pline[1]), 4);
                // c2d2
                c2d2 = TinhKhoangCach2Diem(c2, d2);
                //c2d3
                c2d3 = TinhKhoangCach2Diem(c2, d3);
                //c2d4
                c2d4 = TinhKhoangCach2Diem(c2, d4);
                //c3d1
                c3d1 = TinhKhoangCach2Diem(c3, d1);
                c3b1 = Math.Round(TinhKhoangCach2Diem(c3, Pline[1]), 4);
                // c3d2
                c3d2 = TinhKhoangCach2Diem(c3, d2);
                //c3d3
                c3d3 = TinhKhoangCach2Diem(c3, d3);
                //c3d4
                c3d4 = TinhKhoangCach2Diem(c3, d3);
                //c4d1
                c4d1 = TinhKhoangCach2Diem(c4, d1);
                c4b1 = Math.Round(TinhKhoangCach2Diem(c4, Pline[1]), 4);
                // c4d2
                c4d2 = TinhKhoangCach2Diem(c4, d2);
                //c4d3
                c4d3 = TinhKhoangCach2Diem(c4, d3);
                //c4d4
                c4d4 = TinhKhoangCach2Diem(c4, d4);


                double KC;
                KC = Math.Round(Math.Sqrt(KhoangCach * KhoangCach / 4 + MySize * MySize), 4);
                //truong hop gan duong bao trong
               int i=0;
               try
               {
                   //kiem tra toa do diem (trung diem cua 2 diem nam trong thua va khoang cach 2 diem bang khang cac doan thang cho truoc)
                   if ((c1d1 == MySize) && (KC == c1b1) && (XetGoc180(Pline[0], c1, d1) == 90))
                   {

                       //lay tap hop nghiem
                       TapHopNghiem[i] = c1;
                       TapHopNghiem[i + 1] = d1;
                       i = i + 2;
                       //goto Nhan;
                   }
                   if ((c1d2 == MySize) && (KC == c1b1) && (XetGoc180(Pline[0], c1, d2) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c1;
                       TapHopNghiem[i + 1] = d2;
                       i = i + 2;
                   }
                   if ((c1d3 == MySize) && (KC == c1b1) && (XetGoc180(Pline[0], c1, d3) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c1;
                       TapHopNghiem[i + 1] = d3;
                       i = i + 2;
                   }
                   if ((c1d4 == MySize) && (KC == c1b1) && (XetGoc180(Pline[0], c1, d4) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c1;
                       TapHopNghiem[i + 1] = d4;
                       i = i + 2;
                   }
                   if ((c2d1 == MySize) && (KC == c2b1) && (XetGoc180(Pline[0], c2, d1) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c2;
                       TapHopNghiem[i + 1] = d1;
                       i = i + 2;
                   }
                   if ((c2d2 == MySize) && (KC == c2b1) && (XetGoc180(Pline[0], c2, d2) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c2;
                       TapHopNghiem[i + 1] = d2;
                       i = i + 2;
                   }
                   if ((c2d3 == MySize) && (KC == c2b1) && (XetGoc180(Pline[0], c2, d3) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c2;
                       TapHopNghiem[i + 1] = d3;
                       i = i + 2;
                   }
                   if ((c2d4 == MySize) && (KC == c2b1) && (XetGoc180(Pline[0], c2, d4) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c2;
                       TapHopNghiem[i + 1] = d3;
                       i = i + 2;
                   }
                   if ((c3d1 == MySize) && (KC == c3b1) && (XetGoc180(Pline[0], c3, d1) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c3;
                       TapHopNghiem[i + 1] = d1;
                       i = i + 2;
                   }
                   if ((c3d2 == MySize) && (KC == c3b1) && (XetGoc180(Pline[0], c3, d2) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c3;
                       TapHopNghiem[i + 1] = d2;
                       i = i + 2;
                   }
                   if ((c3d3 == MySize) && (KC == c3b1) && (XetGoc180(Pline[0], c3, d3) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c3;
                       TapHopNghiem[i + 1] = d3;
                       i = i + 2;
                   }
                   if ((c3d4 == MySize) && (KC == c3b1) && (XetGoc180(Pline[0], c3, d4) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c3;
                       TapHopNghiem[i + 1] = d4;
                       i = i + 2;
                   }
                   if ((c4d1 == MySize) && (KC == c4b1) && (XetGoc180(Pline[0], c4, d1) == 90))
                   {
                       //lay tap hop nghiem
                       TapHopNghiem[i] = c4;
                       TapHopNghiem[i + 1] = d1;
                       i = i + 2;
                   }
                   if ((c4d2 == MySize) && (KC == c4b1) && (XetGoc180(Pline[0], c4, d2) == 90))
                   {
                       TapHopNghiem[i] = c4;
                       TapHopNghiem[i + 1] = d2;
                       i = i + 2;
                   }
                   if ((c4d3 == MySize) && (KC == c4b1) && (XetGoc180(Pline[0], c4, d3) == 90))
                   {
                       TapHopNghiem[i] = c4;
                       TapHopNghiem[i + 1] = d3;
                       i = i + 2;
                   }
                   if ((c4d4 == MySize) && (KC == c4b1) && (XetGoc180(Pline[0], c4, d4) == 90))
                   {
                       TapHopNghiem[i] = c4;
                       TapHopNghiem[i + 1] = d4;
                       i = i + 2;
                   }
               }catch(Exception ex ){
                 //  MessageBox.Show(ex.Message);
               }
               return TapHopNghiem;
        }
        //ham co chuc nang select lai thua dat dc chon
        public void SelecThuaDat(string LayerName ) {
            Table table = null;
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong =1001"));
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(irfc);
        }
        //tinh goc quay cua doi tuong so voi chieu nam ngang cua truc X
        public double XacDinhGocQuay(DPoint DiemNut, DPoint DiemQuay, bool ChieuQuay)
        {
            double GocBanDau = 0;
            DPoint oldGoc = new DPoint();
            if (ChieuQuay)
            {
                if (DiemNut.x < DiemQuay.x)
                {
                    if (DiemNut.y < DiemQuay.y)
                    {
                        oldGoc.x = DiemNut.x + 3;
                        oldGoc.y = DiemNut.y;
                        GocBanDau = HeSoGoc(DiemQuay, DiemNut, oldGoc);
                    }
                    else
                    {
                        oldGoc.x = DiemNut.x + 3;
                        oldGoc.y = DiemNut.y;
                        GocBanDau = 360 - HeSoGoc(DiemQuay, DiemNut, oldGoc);
                    }
                }
                else
                {
                    if (DiemNut.y < DiemQuay.y)
                    {
                        oldGoc.x = DiemNut.x - 3;
                        oldGoc.y = DiemNut.y;
                        GocBanDau = 180 - HeSoGoc(DiemQuay, DiemNut, oldGoc);
                    }
                    else
                    {
                        oldGoc.x = DiemNut.x - 3;
                        oldGoc.y = DiemNut.y;
                        GocBanDau = 180 + HeSoGoc(DiemQuay, DiemNut, oldGoc);
                    }
                }
            }
            else
            {
                if (DiemNut.x < DiemQuay.x)
                {
                    if (DiemNut.y < DiemQuay.y)
                    {
                        oldGoc.x = DiemNut.x + 3;
                        oldGoc.y = DiemNut.y;
                        GocBanDau = HeSoGoc(DiemQuay, DiemNut, oldGoc);
                    }
                    else
                    {
                        oldGoc.x = DiemNut.x + 3;
                        oldGoc.y = DiemNut.y;
                        GocBanDau = 360 - HeSoGoc(DiemQuay, DiemNut, oldGoc);
                    }
                }
                else
                {
                    if (DiemNut.y < DiemQuay.y)
                    {
                        oldGoc.x = DiemNut.x - 3;
                        oldGoc.y = DiemNut.y;
                        GocBanDau = 180 - HeSoGoc(DiemQuay, DiemNut, oldGoc);
                    }
                    else
                    {
                        oldGoc.x = DiemNut.x - 3;
                        oldGoc.y = DiemNut.y;
                        GocBanDau = 180 + HeSoGoc(DiemQuay, DiemNut, oldGoc);
                    }
                }
            }
            return GocBanDau;
        }

        //tinh toa do diem quay moi
        public DPoint[] getAnglePoint(MapControl pMap, DPoint StartP, DPoint EndP, double angleOld, double angle, double size, bool ChieuQuay)
        {
            if ((angle == 0) || (size == 0))
                return null;
            DPoint[] newPoint = new DPoint[2];
            MapInfo.Geometry.LegacyArc sector = null;
            if (ChieuQuay)
            {
                sector = new LegacyArc(pMap.Map.GetDisplayCoordSys(), StartP, size, size,
                MapInfo.Geometry.DistanceUnit.Meter, MapInfo.Geometry.DistanceType.Spherical, angleOld, angleOld + angle);
            }
            else
            {
                sector = new LegacyArc(pMap.Map.GetDisplayCoordSys(), StartP, size, size,
                     MapInfo.Geometry.DistanceUnit.Meter, MapInfo.Geometry.DistanceType.Spherical, angleOld, angleOld - angle);
            }
            newPoint[0] = StartP;
            newPoint[1] = sector.EndPoint;
            return newPoint;
        }

        //ham thuc hien huy chon tat ca cac doi tuong
        public void CancelSelect() {
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
        }
        //ham thuc hien chon tat ca cac doi tuong
        public void SelectAll(MapControl pMap, string LayerName)
        {
            MapInfo.Data.Table table = Session.Current.Catalog[pMap.Map.Layers[strLayerName].Alias];
            MapInfo.Data.IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchAll());
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(irfc);
        }

        //ham chuc nang thuc hien nhiem vu chon dieu khien
        public void ExecutePushMapTool(MapToolBar maptoolBar, MapToolBarButton maptool, string OldKey)
        {
            for (int i = 0; i < maptoolBar.Buttons.Count; i++)
            {
                if (maptoolBar.Buttons[i] == maptool)
                {
                    maptool.Pushed = true;
                    //OldKey = maptool.ButtonType.ToString();
                }
                else
                {
                    maptoolBar.Buttons[i].Pushed = false;
                }
            }

        }
        //Dua cac doi tuong tren ban do vao CSDL
        public void ChapNhanGhi(MapControl pMap,string strBang, Int64  MaHoSoCapGCN, long  FeatureID, IResultSetFeatureCollection irfc, Table tabThua, System.Windows.Forms.ToolStripProgressBar process, string LayerName, string layertmp)
        {
            CoordSys coor = pMap.Map.GetDisplayCoordSys();
            string doituong;
                process.Maximum = irfc.Count; 

                foreach (Feature myFeature in irfc)
                {
                    CompositeStyle cs = new CompositeStyle();
                    doituong = "0";
                    //lấy mã đối tượng
                    doituong = GetMaDoiTuong(myFeature, LayerName);
                    MapInfo.Data.Feature f = new MapInfo.Data.Feature(tabThua.TableInfo.Columns);
                    MultiPolygon poly = null;
                    MapInfo.Data.Feature fff = null;
                    //nếu đối tượng trên Map là rectangle thì phải chuyển về dạng MultiPolygon
                    if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Rectangle"))
                    {
                        MapInfo.Geometry.Rectangle rect = (MapInfo.Geometry.Rectangle)myFeature.Geometry;
                        MapInfo.Geometry.Rectangle rectNew = new MapInfo.Geometry.Rectangle(pMap.Map.GetDisplayCoordSys(), rect);
                        poly = rectNew.CreateMultiPolygon();
                        fff = new MapInfo.Data.Feature(poly, myFeature.Style);
                        f.Geometry = fff.Geometry;
                        f.Style = myFeature.Style;
                        cs.ApplyStyle(f.Style);
                        UpdateDoiTuong(tabThua, f.Geometry, doituong, cs, "");
                    }
                    //nếu đối tượng trên Map là Elip thì phải chuyển về dạng MultiPolygon
                    if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Ellipse"))
                    {
                        MapInfo.Geometry.Ellipse elip = (MapInfo.Geometry.Ellipse)myFeature.Geometry;
                        MapInfo.Geometry.Ellipse elipNew = new MapInfo.Geometry.Ellipse(pMap.Map.GetDisplayCoordSys(), elip);

                        poly = elipNew.CreateMultiPolygon(100);
                        fff = new MapInfo.Data.Feature(poly, myFeature.Style);
                        f.Geometry = fff.Geometry;
                        f.Style = myFeature.Style;
                        cs.ApplyStyle(f.Style);
                        UpdateDoiTuong(tabThua, f.Geometry, doituong, cs, "");
                    }
                    //neu là đối tượng point
                    if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Point"))
                    {
                        MapInfo.Geometry.Point point = new MapInfo.Geometry.Point(pMap.Map.GetDisplayCoordSys(), (MapInfo.Geometry.Point)myFeature.Geometry);
                        f.Geometry = point;
                        f.Style = myFeature.Style;
                        cs.ApplyStyle(f.Style);
                        UpdateDoiTuong(tabThua, f.Geometry, doituong, cs, "");
                    }
                    //neu là đối tượng text
                    if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                    {
                        LegacyText txt = (LegacyText)myFeature.Geometry;
                        Int16 fontSize = GetFontSize(txt,pMap);
                        TextStyle ts = new TextStyle();
                        ts = (TextStyle)myFeature.Style;
                        ts.Font.Size = fontSize;
                        
                        MapInfo.Geometry.LegacyText point = MapInfo.Text.TextFactory.CreateLegacyText(pMap.Map.GetDisplayCoordSys(), txt.Centroid, Alignment.CenterCenter, txt.Caption.ToString(), pMap.Map, ts.Font);
                        point.Layout.Angle = txt.Layout.Angle;
                        f.Geometry = point;
                        f.Style = ts;
                        cs.ApplyStyle(ts);
                        UpdateDoiTuong(tabThua, point, doituong, cs,"");
                       
                    }
                    //Nếu là dối tượng đường
                    if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                    {
                        foreach (Curve Cur in (MultiCurve)myFeature.Geometry)
                        {
                            DPoint[] d = Cur.SamplePoints();
                            MapInfo.Geometry.MultiCurve Line = new MapInfo.Geometry.MultiCurve(pMap.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, d);
                            f.Geometry = Line;
                            f.Style = myFeature.Style;
                            cs.ApplyStyle(myFeature.Style);
                            UpdateDoiTuong(tabThua, f.Geometry, doituong, cs, "");
                        }
                    }
                    //nếu là đối tượng MultiPolygon
                    if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                    {
                        foreach (Polygon Cur in (MultiPolygon)myFeature.Geometry)
                        {
                            f.Geometry = myFeature.Geometry;
                            f.Style = myFeature.Style;
                            cs.ApplyStyle(f.Style);
                            SimpleInterior si = new SimpleInterior();
                            si.Pattern = 1;
                            cs.ApplyStyle(si);
                            UpdateDoiTuong(tabThua, f.Geometry, doituong, cs, "");
                        }
                    }
                    //insert feature vào bảng    
                    //CompositeStyle cs = new CompositeStyle();
                   
                    //if (!myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                    //{
                    //    cs.ApplyStyle(f.Style);
                    //    UpdateDoiTuong(tabThua, f.Geometry, doituong, cs,"");
                    //}
                       // tabThua.InsertFeature(f);
                   
                   
                    //goi hàm update
                        clsData.UpdateFeature(strBang, doituong, MaHoSoCapGCN, Convert.ToInt64(FeatureID.ToString().Split('.')[0]), getCon(strConnection));
                    //hien thi process
                    process.Value = process.Value + 1;
                    f = null;
                }
        }
        //hàm chức nang lấy giao điểm 2 đoạn thẳng
        public void GiaoDiem2DoanThang(MapControl pMap, string LayerName)
        {
            Table table = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tập hợp tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count != 2)
            {

                MessageBox.Show("Chọn hai đoạn thẳng cần lấy giao điểm !");
                return;
            }
            //DPoint GiaoDiem = new DPoint();
            MapInfo.Geometry.MultiPoint GiaoDiem = new MultiPoint(pMap.Map.GetDisplayCoordSys());
            int j = 0;
            //lay giao diem 2 doan thang
            DPoint[] cv = new DPoint[4];
            string MaDoiTuong;
            CompositeStyle cs = new CompositeStyle();
            for (int i = 0; i < irfc.Count - 1; i++)
            {
                cs.ApplyStyle(irfc[i].Style);
                MaDoiTuong = GetMaDoiTuong(irfc[i],LayerName );

                if (irfc[i].Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve") && irfc[j].Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                {
                    j = i + 1;
                    MultiCurve cv1 = (MultiCurve)irfc[i].Geometry;
                    MultiCurve cv2 = (MultiCurve)irfc[j].Geometry;
                    GiaoDiem = cv1.IntersectNodes(cv2, IntersectTypes.InclAll);

                    foreach (Curve c1 in cv1)
                    {
                        cv[0] = c1.StartPoint;
                        cv[1] = c1.EndPoint;
                    }
                    foreach (Curve c2 in cv2)
                    {
                        cv[2] = c2.StartPoint;
                        cv[3] = c2.EndPoint;
                    }
                }
                if (GiaoDiem.PointCount != 0)
                {
                    //ve lai cac doan thang tu giao diem cua 2 doan thang toi dau cac doan
                    for (int k = 0; k < cv.Length; k++)
                    {
                        DPoint[] d = new DPoint[2];
                       
                        d[0] = GiaoDiem[0];
                        d[1] = cv[k];
                        CreateLine(pMap.Map, d, LayerName, cs);
                        }
                    table.DeleteFeature(irfc[i]);
                    table.DeleteFeature(irfc[j]);
                }
            }
        }

        //ham chuc nang chia doan thang ra lam hai doan theo 1 kich thuoc cho san
        public void ChiaDoanThang(MapControl pMap, string LayerName,double KhoangCachChia,bool LayDiem_ChiaCanh)
        {
            Table table = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
            //lấy tập hợp tất cả các đối tượng được chọn
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count == 0)
            {
                MessageBox.Show("Chọn đoạn thẳng cần chia !");
                return;
            }
            CompositeStyle cs = new CompositeStyle();
            for (int i = 0; i < irfc.Count; i++)
            {
                if (irfc[i].Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                {
                    cs.ApplyStyle(irfc[i].Style);
                    string MaDoiTuong = "";
                     MaDoiTuong = GetMaDoiTuong(irfc[i],LayerName );
                    DPoint DiemChia = new DPoint();
                    MultiCurve cv=(MultiCurve)irfc[i].Geometry ;
                    foreach ( Curve c in cv ){
                        DPoint[] d = new DPoint[2];
                        d = c.SamplePoints();
                        DiemChia = ToaDoDiemChia(d, KhoangCachChia);
                        DPoint []d1 =new DPoint[2];
                        DPoint []d2 =new DPoint[2];
                        d1[0]=c.StartPoint;
                        d1[1]=DiemChia ;;
                        d2[0]=DiemChia ;;
                        d2[1]=c.EndPoint ;
                        double KC;//chieu dai 2 doan thang 
                        KC=cv.Length(DistanceUnit.Meter);
                        if (LayDiem_ChiaCanh)//truong hop chia canh
                        {
                            if (KhoangCachChia > KC)
                            {
                                CreateLine(pMap.Map, d1, LayerName, cs);
                            }
                            else
                            {
                                CreateLine(pMap.Map, d2, LayerName, cs);
                                CreateLine(pMap.Map, d1, LayerName, cs);
                            }
                            table.DeleteFeature(irfc[i]);
                        }
                        else {
                            MapInfo.Styles.SimpleVectorPointStyle vs = new MapInfo.Styles.SimpleVectorPointStyle(33, System.Drawing.Color.Red, 10);
                            //MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(vs);
                            cs = new MapInfo.Styles.CompositeStyle(vs);
                            //tạo mới đối tượng điểm 
                            MapInfo.Geometry.FeatureGeometry pt;
                            pt = mpxMkFeaturePoint(pMap.Map.GetDisplayCoordSys(), DiemChia.x, DiemChia.y);
                            MapInfo.Data.Feature pft = new MapInfo.Data.Feature(table.TableInfo.Columns);
                            pft.Geometry = pt;
                            pft.Style = cs;
                            //quy dinh ma search nay la 10
                            UpdateDoiTuong(table, pt, "0", cs,"");
                        }
                    }
                   
                }
            }
        }
        //chia doan thang theo 1 khaong nao do gia tri tra ve la diem chia
        public MapInfo.Geometry.DPoint ToaDoDiemChia(MapInfo.Geometry.DPoint[] dPoint, double dblDistance)
        {
            MapInfo.Geometry.DPoint pointTemp;
            /* Nếu x1 = x2
             Khi đó phương trình đường thẳng sẽ là x = x1(x2)*/
            if (dPoint[0].x == dPoint[1].x)
            {
                /* Nếu y1 = y2. Tức 2 điểm trùng nhau
                 * Trong trường hợp này thì ta chỉ tính điểm chia phục vụ cho
                 bài toán tìm điểm chia nằm trên đường phân giác của góc. Khi đó:
                 y = y1(=y2) và x = x1(=x2) + dblDistance(- dblDistance;) ;*/
                if (dPoint[0].y == dPoint[1].y)
                {
                    pointTemp.y = dPoint[0].y;
                    pointTemp.x = dPoint[0].x + dblDistance;
                }
                else
                {
                    pointTemp.x = dPoint[0].x;
                    if (dPoint[0].y < dPoint[1].y)
                        pointTemp.y = dPoint[0].y + dblDistance;
                    else
                        pointTemp.y = dPoint[0].y - dblDistance;
                }
            }
            /* Nếu y1 = y2
             Khi đó phương trình đường thẳng sẽ là y = y1 (y2) */
            else if (dPoint[0].y == dPoint[1].y)
            {
                pointTemp.y = dPoint[0].y;
                if (dPoint[0].x < dPoint[1].x)
                    pointTemp.x = dPoint[0].x + dblDistance;
                else
                    pointTemp.x = dPoint[0].x - dblDistance;
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

                ///* Trường hợp x1 < x2 thì tọa độ X của điểm chia sẽ được tính như sau:
                //  */
                //if ( X1  < X2  )
                //    pointTemp.x  = X1  + dblDistance /( System.Math.Sqrt(1 + (( Y2-Y1)* (Y2 - Y1 ))/((X2 - X1 )*(X2 - X1 ))));
                ///* Trường hợp x1 < x2 thì tọa độ X của điểm chia sẽ được tính như sau:
                //  */
                //else
                //    pointTemp.x = X1 - dblDistance /(System.Math.Sqrt(1 + ((Y2 - Y1) * (Y2 - Y1)) / ((X2 - X1) * (X2 - X1))));

                /* Trường hợp x1 < x2 thì tọa độ X của điểm chia sẽ được tính như sau: */
                if (X1 < X2)
                {
                    pointTemp.x = X1 + dblDistance * (System.Math.Cos(System.Math.Atan((Y2 - Y1) / (X2 - X1))));
                }
                /* Trường hợp x1 < x2 thì tọa độ X của điểm chia sẽ được tính như sau: */
                else
                {
                    pointTemp.x = X1 - dblDistance * (System.Math.Cos(System.Math.Atan((Y2 - Y1) / (X2 - X1))));
                }

                /* Tọa độ y của điểm chia */
                pointTemp.y = ((Y2 - Y1) * (pointTemp.x - X1)) / (X2 - X1) + Y1;
            }
            return pointTemp;
        }

        //ham chức nang giảm kích thước cạnh được chọn
        public void GiamKichThuocCanh(MapControl pMap, string LayerName, ToolStripProgressBar staProcess)
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
                            d = GiamToaDoDiem(d, tyle, 2);
                            cs.ApplyStyle(f.Style);
                            mpxDrawLine(pMap.Map, "", "", d, cs, LayerName, staProcess);
                            tab.DeleteFeature(f);
                            staProcess.Value = staProcess.Value + 1;
                        }
                    }
                }
                staProcess.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chọn đối tượng !");
            }
        }
        //thuc hien viec load tham 1 ban do moi
        public void HienThiBanDo(MapControl pMap, string strTableName, string sWhere, string CurentLayerName, bool boolZoom)
        {
            try
            {
                MapInfo.Mapping.FeatureLayer[] lyrs = new MapInfo.Mapping.FeatureLayer[1];
                string str;
                str = "";
                if (sWhere == "") {
                    str = "Select * from " + strTableName;// +" where MaDonViHanhChinh =" + strMaDonViHanhChinh;
                }//
                else { 
                    str = "Select * from " + strTableName +  " " + sWhere + " " + " and MaDonViHanhChinh ='" + strMaDonViHanhChinh +"'"; }
               
               if (MapInfo.Engine.Session.Current.Catalog.GetTable(CurentLayerName) != null)
               {
                   MapInfo.Engine.Session.Current.Catalog.CloseTable(CurentLayerName);
               }
                OpenLayer(ref pMap, ref lyrs[0], CurentLayerName, strConnectionstring, str);             
               
            }
            catch (FeatureException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //ham thuc hien chuc nang copy tu ban do tong the sang ban do thua dat
        public void CopyTuBanDoTongThe(MapControl pMap, string LayerThua, string LayerBanDo)
        {
            Table tabThua = null;
            Table tabBanDo = null;
            tabThua = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerThua);
            tabBanDo = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerBanDo);
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[tabBanDo];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count < 1)
            {
                return;
            }
            Feature fTmp = new Feature(tabThua.TableInfo.Columns);
            foreach (Feature f in irfc)
            {
                fTmp.Geometry = f.Geometry;
                fTmp.Style = f.Style;
                tabThua.InsertFeature(fTmp);
            }
        }
       
        //lay ra lop ban do nha va dat
        public void LopBanDo(MapControl pMap, string LayerName, string LopNha, string BanDo, string TenLopDat, string TenLopNha)
        {
            try
            {
                //gọi hàm hiển thị lớp nhà
                HienThiBanDo(pMap, LopNha, "", TenLopNha , false);
                //ẩn khi load ban đầu
                pMap.Map.Layers[TenLopNha ].Enabled = false;
                //gọi hàm load lớp đất
                HienThiBanDo(pMap, BanDo, "", TenLopDat , false); ;
                //ẩn lớp đất khi khởi tạo ban đầu
               pMap.Map.Layers[TenLopDat].Enabled = false;
                //đưa lớp đất lên vị trí trên cùng
                int iLayerIndex = pMap.Map.Layers.IndexOf(pMap.Map.Layers[LayerName]);
                pMap.Map.Layers.Move(iLayerIndex, 0);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }
        //ham chuc nang ve tam thua dat
        public void VeTamThua(MapControl pMap, string LayerName)
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
                    DPoint d = new DPoint();
                    //Nếu đối tượng là MultiPolygon thì mở điều khiển thuộc tính vùng
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                    {
                        d = f.Geometry.Centroid;
                        MapInfo.Geometry.FeatureGeometry pt;
                        MapInfo.Styles.SimpleVectorPointStyle vs = new MapInfo.Styles.SimpleVectorPointStyle(33, System.Drawing.Color.Red, 10);
                        MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(vs);

                        //gọi hàm tạo node
                        pt = mpxMkFeaturePoint(pMap.Map.GetDisplayCoordSys(), d.x, d.y);
                        //update doi tưọng vừa tạo vào bảng
                        UpdateDoiTuong(table, pt, "0", cs,"");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        //hàm chức năng thực hiện việc bỏ chọn tất cả các đối tượng
        public void DelSelect(MapControl pMap, string LayerName ,bool TrangThaiKhoa) {
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
                    string MaDoiTuong = "";
                    MaDoiTuong=GetMaDoiTuong(f, LayerName);
                    if (TrangThaiKhoa)//trạng thái Đóng khóa
                    {
                        if ((MaDoiTuong != "1001") && (MaDoiTuong != "101"))
                        {
                            table.DeleteFeature(f);
                        }
                    }
                    else { //trạng thái mởi khóa
                        table.DeleteFeature(f);
                    }
                }
                pMap.Refresh();
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// dTam là gốc chọn trên bản đồ(B)
        /// dGoc là diểm giả định đầu tiên nhập vào (A)
        /// M là giao điểm hạ từ DTam xuống ox và DGoc xuong oy
        /// </summary>
        /// <param name="dtam"></param>
        /// <param name="grdToaDoGiaDinh"></param>
        /// <param name="grdToaDoTHuc"></param>
        public void ChuyenToaDoThuc(DPoint dtam, DataGridView grdToaDoGiaDinh, DataGridView grdToaDoTHuc)
        {

            DPoint A =new DPoint ();
            DPoint B =new DPoint();
            B=dtam;
            DPoint[] dmang = new DPoint[grdToaDoGiaDinh.Rows.Count];
            DPoint dGoc = new DPoint();
            if ((grdToaDoGiaDinh.Rows[0].Cells[0].Value.ToString() == "") || (grdToaDoGiaDinh.Rows[0].Cells[1].Value.ToString () == ""))
            {
                return;
            }

            grdToaDoTHuc.Columns.Clear();
            grdToaDoTHuc.Columns.Add(grdToaDoGiaDinh.Columns[0].Name, grdToaDoGiaDinh.Columns[0].HeaderText);
            grdToaDoTHuc.Columns.Add(grdToaDoGiaDinh.Columns[1].Name, grdToaDoGiaDinh.Columns[1].HeaderText);

            dGoc.x = Convert.ToDouble( grdToaDoGiaDinh.Rows[0].Cells[0].Value);
            dGoc.y = Convert.ToDouble( grdToaDoGiaDinh.Rows[0].Cells[1].Value);
            A = dGoc;
            //goi M la diem vuông góc hạn từ dtam xuong ox và dgoc xuong oy
            DPoint M = new DPoint();
            M.x = dtam.x;
            M.y = dGoc.y;
            double BA = 0;
            double MA = 0;
            BA = TinhKhoangCach2Diem(dtam, dGoc);
            MA = TinhKhoangCach2Diem(M, dGoc);
            double cosa = 0;
            cosa = MA / BA;
            for (int i = 0; i < grdToaDoGiaDinh.Rows.Count ; i++)
            {
                if ((grdToaDoGiaDinh.Rows[i].Cells[0].Value.ToString() == "") || (grdToaDoGiaDinh.Rows[i].Cells[1].Value.ToString() == ""))
                {
                    return;
                }
                DPoint Diem = new DPoint();
                DPoint d = new DPoint();
                d.x = Convert.ToDouble( grdToaDoGiaDinh.Rows[i].Cells[0].Value);
                d.y = Convert.ToDouble( grdToaDoGiaDinh.Rows[i].Cells[1].Value);
                if ((d.x >= A.x) & (d.y >= A.y))
                {
                    Diem.x = B.x + Math.Abs(d.x - A.x);
                    Diem.y = B.y + Math.Abs(d.y - A.y);
                }
                if ((d.x >= A.x) & (d.y <= A.y))
                {
                    Diem.x = B.x + Math.Abs(d.x - A.x);
                    Diem.y= B.y - Math.Abs(d.y - A.y);
                    
                }
                if ((d.x <= A.x) & (d.y <= A.y))
                {
                    Diem.x = B.x - Math.Abs(d.x - A.x);
                    Diem.y = B.y - Math.Abs(d.y - A.y);
                }
                if ((d.x <= A.x) & (d.y >= A.y))
                {
                    Diem.x = B.x - Math.Abs(d.x - A.x);
                    Diem.y = B.y + Math.Abs(d.y - A.y);
                }
                grdToaDoTHuc.Rows.Add(1);
                grdToaDoTHuc.Rows[i].Cells[0].Value = Diem.x;
                grdToaDoTHuc.Rows[i].Cells[1].Value = Diem.y;
            }

        }
        //hàm tạo mới điểm (dung cho viec chọn điểm ( xem toa do))
        public void getSelectDiemGocDan(MapControl pMap, DataGridView grDanhSachToaDo, int index, string LayerName)
        {
            if (index >= 0)
            {
                //lấy toạ dộ điểm từ gridview
                DPoint node = new DPoint();
                node.x = Convert.ToDouble(grDanhSachToaDo.Rows[index].Cells[2].Value);
                node.y = Convert.ToDouble(grDanhSachToaDo.Rows[index].Cells[3].Value);
                //lấy bảng hiện thời
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                //dinh nghia font
                MapInfo.Styles.SimpleVectorPointStyle vs = new MapInfo.Styles.SimpleVectorPointStyle(1, System.Drawing.Color.Black, 1);
                MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(vs);

                //tìm tat cả các đối tượng có cùng mã đỗi tượng là 10 (quy định 1 mã để xử lý)
                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong=11"));
                if (irfc == null)
                {
                    return;
                }

                foreach (Feature f in irfc)
                {
                    //xoá bằng hết, bằng sạch
                    tab.DeleteFeature(f);
                }
                //tạo mới đối tượng điểm 
                MapInfo.Geometry.FeatureGeometry pt;
                pt = mpxMkFeaturePoint(pMap.Map.GetDisplayCoordSys(), node.x, node.y);
                MapInfo.Data.Feature pft = new MapInfo.Data.Feature(tab.TableInfo.Columns);

                pft.Geometry = pt;
                pft.Style = cs;

                //quy dinh ma search nay la 10
                UpdateDoiTuong(tab, pt, "11", cs,"");
                TaoLaiPolygon(pMap, LayerName, node);
                IResultSetFeatureCollection myirfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong=11 or MaDoiTuong=10 "));
                foreach (Feature f in myirfc)
                {
                    //xoá bằng hết, bằng sạch
                    tab.DeleteFeature(f);
                }
            }
        }
        public void TaoLaiPolygon(MapControl pmap, string layerName, DPoint dp)
        {
            Table table = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(layerName);
            MapInfo.Data.Feature myfc = new Feature(table.TableInfo.Columns);
            IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
            if (irfc == null)
            {
                return;
            }
            if (irfc.Count != 1)
            {
                MessageBox.Show("Chọn đối tượng cần gán nhãn");
                return;
            }
            string MaDoiTuong = "";
            foreach (Feature f in irfc)
            {
                //nếu đối tượng được chọn có kiểu MultiPolygon
                if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                {
                    //lay ma doi tuong                   
                    MaDoiTuong = GetMaDoiTuong(f, layerName);
                    myfc = f;
                }
                else
                {
                    //nếu không thì thông báo
                    MessageBox.Show("Chọn đối tượng cần gán nhãn");
                    return;
                }
            }
            DPoint[] d = null;
            MultiPolygon plg = (MultiPolygon)myfc.Geometry;
            foreach (Polygon pl in plg)
            {
                d = pl.Exterior.SamplePoints();
                DPoint DiemLamGoc = new DPoint();
                DiemLamGoc = KiemTraDiemLamGoc(pmap, table);
                if ((DiemLamGoc.x != 0) && (DiemLamGoc.y != 0))
                {
                    CompositeStyle cs = new CompositeStyle();
                    Feature pft = new Feature(table.TableInfo.Columns);
                    d = SetLaiMangDpoid(d, d, dp);
                    MultiPolygon mp = new MultiPolygon(pmap.Map.GetDisplayCoordSys(), CurveSegmentType.Linear, d);
                    pft = new Feature(mp, cs);
                    //update đppó tượng vào mảng
                    SimpleInterior si = new SimpleInterior();
                    si.Pattern = 1;
                    cs.ApplyStyle(si);
                    UpdateDoiTuong(table, pft.Geometry, MaDoiTuong, cs,"");
                    table.DeleteFeature(myfc);
                }
            }
        }
        //chuyen diem vua chon ve vi tri goc
        public DPoint[] SetLaiMangDpoid(DPoint[] dThua, DPoint[] arrPoint, DPoint dp)
        {
            DPoint[] NewArr = new DPoint[arrPoint.Length];
            int ViTri = 0;
            int j = 0;
            for (int i = 0; i < dThua.Length; i++)
            {
                if ((System.Math.Round(dThua[i].x, 3) == System.Math.Round(dp.x, 3)) && (System.Math.Round(dThua[i].y, 3) == System.Math.Round(dp.y, 3)))
                {
                    ViTri = i;
                    goto Nhan;
                }

            }
        Nhan:
            for (int i = ViTri; i < arrPoint.Length; i++)
            {
                NewArr[j] = arrPoint[i];
                j = j + 1;
            }
            for (int i = 1; i <= ViTri; i++)
            {
                NewArr[j] = arrPoint[i];
                j = j + 1;
            }
            return NewArr;

        }
        //kiem tra xem thua dat co chon doi tuong diem goc hay khong
        public DPoint KiemTraDiemLamGoc(MapControl pmap, Table tab)
        {
            DPoint dp = new DPoint();
            IResultSetFeatureCollection Myfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchWhere("MaDoiTuong= 11"));
            if (Myfc == null)
            {
                return dp;
            }
            if (Myfc.Count == 0)
            {
                return dp;
            }
            foreach (Feature f in Myfc)
            {
                MapInfo.Geometry.Point pt = new MapInfo.Geometry.Point(pmap.Map.GetDisplayCoordSys(), (MapInfo.Geometry.Point)f.Geometry);
                dp.x = pt.X;
                dp.y = pt.Y;
            }
            return dp;
        }

    }
}


