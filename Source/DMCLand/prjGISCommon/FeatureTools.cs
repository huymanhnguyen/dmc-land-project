using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public  class FeatureTools
    {
               /* Khai báo biến nhận chuỗi kết nối Database */
        private string strConnection = "";
        private string strtmpMaThuaDatCon = "";

        public string MaThuaDatCon
        {
            get { return strtmpMaThuaDatCon; }
            set { strtmpMaThuaDatCon = value; }
        }
        private string strTenBangDat = "";

        public string TenBangDat
        {
            get { return strTenBangDat; }
            set { strTenBangDat = value; }
        }
        /* Khai báo thuộc tính nhận chuỗi kết nối Database */
        public string Connection
        {
            set
            {
                strConnection = value;
            }
        }
        /* -----------------------NHỮNG CHỨC NĂNG THAM KHẢO CẦN KIỂM TRA-------------------------------*/
        /* Test */
        /// <summary>
        /// Xoay đối tượng trên bản đồ với góc xoay cho trước 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="featureRotate"></param>
        /// <param name="dPoint"></param>
        /// <param name="doubleAngle"></param>
        private void RotateFeature(MapInfo.Mapping.Map map, MapInfo.Data.Feature featureRotate, MapInfo.Geometry.DPoint dPoint, double doubleAngle )
        {
            MapInfo.Geometry.IGeometryEdit idt = featureRotate.Geometry.GetGeometryEditor();
            idt.Rotate(dPoint , doubleAngle);
            featureRotate.Geometry.EditingComplete(); 
        }

        /// <summary>
        /// Refresh Layer with before Layer Name
        /// </summary>
        /// <param name="map"></param>
        /// <param name="strLayerName"></param>
        private void RefreshLayer(MapInfo.Mapping.Map map, string strLayerName)
        {
            MapInfo.Mapping.FeatureLayer featureLayer ;
            featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            featureLayer.Table.Refresh();
            
            map.Invalidate(true); /* Cần xem lại phương thức này */
        }

        /* End Test */

        /*----------------------------------------------------------------------------------------------*/

        public void  CreateBuffer(MapInfo.Mapping.Map map, string strLayerName, double dblWidth)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ trong điều khiển bản đồ mapControl */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName trong bản đồ */
            if (map.Layers[strLayerName] == null)
                return;
            /* Lựa chọn các Feature */
            ////DMC.Land.TachThua.FeatureTools featureTools = new DMC.Land.TachThua.FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc;
            irfc = this.SelectFeatures(map, strLayerName);
            /* Xác định các Region trong các đối tượng được Select */
            MapInfo.Data.Feature[] featuresRegion = this.checkRegionsInFeatureCollection(irfc);
            /* Chắc chắn rằng tồn tại đối tượng kiểu Vùng được lựa chọn */
            if (featuresRegion == null)
                return ;
            /* Chắc chắn rằng chỉ có một thửa đất được lựa chọn */
            if (featuresRegion.Length != 1)
                return ;
            /* Khai báo và gán giá trị cho Buffer feature */
            MapInfo.Data.Feature featureBuffer = this.Buffer(featuresRegion[0],dblWidth );
            /* Chắc chắn rằng tồn tại Buffer Feature */
            if (featureBuffer == null)
                return ;
            /* Với các đối tượng được lựa chọn, ta đưa vào trong lớp tạm để xử lý */
            this.insertFeatureToFeatureLayer(map ,featureBuffer, strLayerName);
        }

        public MapInfo.Data.Feature Buffer(MapInfo.Data.Feature feature, double dblWidth)
        {
            /* Chắc chắn rằng tồn tại Feature cần lấy Buffer Feature */
            if (feature == null)
                return null;
            /* Khai báo FeatureGeometry chứa Buffer của feature */
            MapInfo.Geometry.FeatureGeometry featureGeometry = feature.Geometry.Buffer(dblWidth, MapInfo.Geometry.DistanceUnit.Meter, 3, MapInfo.Geometry.DistanceType.Spherical);
            /* Khai báo kiểu của Buffer */
            MapInfo.Styles.SimpleLineStyle bl = new MapInfo.Styles.SimpleLineStyle(new MapInfo.Styles.LineWidth(1, MapInfo.Styles.LineWidthUnit.Point));
            MapInfo.Styles.SimpleInterior si = new MapInfo.Styles.SimpleInterior(0);
            MapInfo.Styles.AreaStyle areaStyle = new MapInfo.Styles.AreaStyle(bl, si);
            MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(areaStyle, null, null, null);
            /* Add Buffer feature tới bảng */
            MapInfo.Data.Feature featureBuffer  = new MapInfo.Data.Feature(featureGeometry, cs);
            return featureBuffer;
        }




        /// <summary>
        /// Xác định DANH SÁCH TỌA ĐỘ CÁC ĐỈNH TỪ MỘT POLYGON CHO TRƯỚC
        /// </summary>
        /// <param name="polygon"> Polygon cần xác định danh sách toạn độ các đỉnh </param>
        /// <returns>Trả về danh sách tọa độ các đỉnh của Polygon</returns>
        public MapInfo.Geometry.DPoint[] VertexPoints(MapInfo.Geometry.Polygon polygon)
        {
            /* Chắc chắn rằng tồn tại Polygon cần xác định danh sách tọa độ các đỉnh */
            if (polygon == null)
                return null;
            /* Khai báo danh sách điểm chung gian */
            MapInfo.Geometry.DPoint[] dPointsPolygon = polygon.Exterior.SamplePoints();
            return dPointsPolygon;
        }
      
        public void ChiaDoanThang(MapInfo.Mapping.Map map, string strLayerName, double dblDistance)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            if (featureLayer == null)
                return;
            /* Xác định những Feature nào đang được lựa chọn trên lớp có tên là strLayerName */
            ////TachThua.FeatureTools featureTool = new FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc =  this.SelectFeatures(map, strLayerName);
            if (irfc == null)
                return;
            /* Chắc chắn rằng chỉ chọn một  đối tượng */
            if (irfc.Count != 1)
                return;
            /* Xác nhận Feature cần thực thi */
            MapInfo.Data.Feature feature = irfc[0];
            /* Chỉ thực hiện với những Feature có kiểu là MultiCurve (Line, Polylines) */
            if (feature.Geometry.Type != MapInfo.Geometry.GeometryType.MultiCurve)
                return;
            /* Nếu Feature đó có kiểu là MultiCurve thì thì ép kiểu */
            MapInfo.Geometry.MultiCurve multiCurve = (MapInfo.Geometry.MultiCurve)feature.Geometry;
            /* Chỉ chia đoạn khi đối tượng MultiCurve có một đoạn */
            if (multiCurve.CurveSegmentTotal != 1)
                return;
            /* Chắc chắn rằng đoạn đầu có độ dài nhỏ hơn độ dài đoạn thẳng cần chia */
            if (multiCurve.Length(MapInfo.Geometry.DistanceUnit.Meter) <= dblDistance)
                return;
            /* Khai báo biến có kiểu DPoint, chứa danh sách điểm của MultiCurve */
            MapInfo.Geometry.DPoint[] dPoints;
            /* Gán danh sách các đỉnh của MultiCurve vào giá trị cho biến danh sách */
            dPoints = multiCurve[0].SamplePoints();
            /* Nhận tọa độ điểm chia */
            /* Khai báo biến nhận tọa độ điểm chia có kiểu DPoint */
            MapInfo.Geometry.DPoint dPointSplit = new MapInfo.Geometry.DPoint();
            dPointSplit = this.ToaDoDiemChia (dPoints, dblDistance);
            /* Nếu tồn tại điểm chia thì tạo 2 đoạn thẳng mới */
            if (dPointSplit == null)
                return;
            /* Xác nhận toạ độ 2 điểm của đoạn 1 */
            MapInfo.Geometry.DPoint[] dPointSegment1 = new MapInfo.Geometry.DPoint[2];
            dPointSegment1[0] = dPoints[0];
            dPointSegment1[1] = dPointSplit; 
            this.CreatePolyline(map, strLayerName, dPointSegment1);
            /* Xác nhận tạo độ 2 điểm của đoạn 2 */
            MapInfo.Geometry.DPoint[] dPointSegment2 = new MapInfo.Geometry.DPoint[2] ;
            dPointSegment2[0] = dPointSplit;
            dPointSegment2[1] = dPoints[1];
            this.CreatePolyline(map, strLayerName, dPointSegment2);
            /* Xóa đoạn thẳng cần chia */
            featureLayer.Table.DeleteFeature(feature);
        }

        /// <summary>
        /// Xác định độ dài đoan thẳng trên bản đồ
        /// </summary>
        /// <param name="map">Đối tượng bản đồ</param>
        /// <param name="strLayerName">Tên lớp chứa đoạn thẳng cần tính độ dài</param>
        /// <returns>Đọ dài của đoạn thẳng trên bản đồ</returns>
        public decimal  DoDaiDoanThang(MapInfo.Mapping.Map map, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return 0;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            if (featureLayer == null)
                return 0;
            /* Xác định những Feature nào đang được lựa chọn trên lớp có tên là strLayerName */
            ////TachThua.FeatureTools featureTool = new FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc = this.SelectFeatures(map, strLayerName);
            if (irfc == null)
                return 0;
            /* Chắc chắn rằng chỉ chọn một  đối tượng */
            if (irfc.Count != 1)
                return 0;

            MapInfo.Data.Feature feature;
            feature = irfc[0];

            /* Chỉ thực hiện với những Feature có kiểu là MultiCurve (Line, Polylines) */
            if (feature.Geometry.Type != MapInfo.Geometry.GeometryType.MultiCurve)
                return 0;
            /* Nếu Feature đó có kiểu là MultiCurve thì thì ép kiểu */
            MapInfo.Geometry.MultiCurve multiCurve = (MapInfo.Geometry.MultiCurve)feature.Geometry;
            /* Chỉ chia đoạn khi đối tượng MultiCurve có một đoạn */
            if (multiCurve.CurveSegmentTotal != 1)
            {
                return 0;
            }
            /* Khai báo biến có kiểu DPoint, chứa danh sách điểm của MultiCurve */
            MapInfo.Geometry.DPoint[] dPoints;
            /* Gán danh sách các đỉnh của MultiCurve vào giá trị cho biến danh sách */
            dPoints = multiCurve[0].SamplePoints();

            /* Tạo Polygon (MultiPolygon) tương ứng với danh sách điểm */
            ////TachThua.FeatureTools featureTools = new FeatureTools();
            /* Tính độ dài đoạn thẳng dựa vào tọa độ 2 điểm */
            decimal dblTemp = 0;
            dblTemp =  this.DoDaiDoanThang(dPoints);
            //// Xác nhận độ dài đoạn thẳng bằng công cụ có sẵn của MapXTreme
            //dblTemp = multiCurve.Length(MapInfo.Geometry.DistanceUnit.Meter);
            return dblTemp;
        }

        /// <summary>
        /// Xác định độ của đoạn thẳng khi biết tọa độ 2 điểm của đoạn thẳng đó 
        /// </summary>
        /// <param name="dPoint">Danh sách tọa độ 2 điểm của đoạn thẳng</param>
        /// <returns>Giá trị trả về là độ dài của đoạn thẳng</returns>
        public  decimal  DoDaiDoanThang(MapInfo.Geometry.DPoint[] dPoint)
        {
            double X1, X2, Y1, Y2;
            X1 = dPoint[0].x;
            Y1 = dPoint[0].y;
            X2 = dPoint[1].x;
            Y2 = dPoint[1].y;
            decimal  dblTempDistance;
            dblTempDistance = Convert.ToDecimal( System.Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2)));
            return dblTempDistance;
        }

        /// <summary>
        /// Xác định khoảng cách giữa 2 điểm khi biết tọa độ của chúng
        /// </summary>
        /// <param name="dPointFirst">Tọa độ điểm đầu</param>
        /// <param name="dPointSecond">Tọa độ điểm cuối</param>
        /// <returns></returns>
        public double  TwoPointsDistance(MapInfo.Geometry.DPoint dPointFirst , MapInfo.Geometry.DPoint dPointSecond)
        {
            double X1, X2, Y1, Y2;
            X1 = dPointFirst.x ;
            Y1 = dPointFirst.y;
            X2 = dPointSecond.x;
            Y2 = dPointSecond.y;
            double  dblTempDistance;
            dblTempDistance = System.Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));
            return dblTempDistance;
        }


        /// <summary>
        /// Xác định tọa độ điểm chia của đoạn thẳng, chia theo khoảng cách tính từ vị trí của điểm đầu
        /// Phương thức này chỉ lấy tọa độ điểm chia nằm giữa 2 điểm của đoạn cần chia
        /// </summary>
        /// <param name="dPoint">Tọa độ 2 điểm đầu của đoạn thẳng</param>
        /// <param name="dblDistance">Khoảng cách cần chia đoạn thẳng</param>
        /// <returns>Giá trị trả về là tọa độ của điểm chia nằm giữa đoạn thẳng</returns>
        public  MapInfo.Geometry.DPoint  ToaDoDiemChia(MapInfo.Geometry.DPoint[] dPoint , double dblDistance )
        {
            MapInfo.Geometry.DPoint  pointTemp ;
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
                pointTemp.y  = dPoint[0].y;
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

        /// <summary>
        /// Xác định tọa độ HAI điểm chia của đoạn thẳng, chia theo khoảng cách tính từ vị trí của điểm đầu
        /// </summary>
        /// <param name="dPoint">Tọa độ 2 điểm đầu của đoạn thẳng</param>
        /// <param name="dblDistance">Khoảng cách cần chia đoạn thẳng</param>
        /// <returns>Giá trị trả về là danh sách tọa độ của 2 điểm chia.
        /// Một điểm nằm giữa đoạn thẳng
        /// Điểm còn lại nằm ngoài đường thẳng, đối diện với điểm chia thứ nhất qua điểm đầu</returns>
        public MapInfo.Geometry.DPoint[] ToaDoDiemChia2(MapInfo.Geometry.DPoint[] dPoint, double dblDistance)
        {
            MapInfo.Geometry.DPoint[] dPointTemp = new MapInfo.Geometry.DPoint[2] ;
            /* Chắc chắn rằng tồn tại tọa độ 2 điểm đầu của đoạn thẳng */
            if (dPoint == null)
                return null;
            /* Chắc chắn rằng danh sách điểm chứa tọa độ 2 điểm đầu của đoạn thẳng có độ dài bằng 2 */
            if (dPoint.Length != 2)
                return null;
            /* Xác định điểm chia thứ nhất */
            dPointTemp[0] = this.ToaDoDiemChia(dPoint, dblDistance);
            /* Xác định điểm chia thứ 2 theo công thức tính tọa độ điểm đối xứng: 
             * X2 = 2Xo - X1;
             * Y2 = 2Yo - Y1; */
            dPointTemp[1].x = 2 * dPoint[0].x - dPointTemp[0].x;
            dPointTemp[1].y = 2 * dPoint[0].y - dPointTemp[0].y;
            return dPointTemp;
        }


        public MapInfo.Styles.CompositeStyle LandStyle()
        {
            //MapInfo.Styles.SimpleInterior simpleInterior =
            //    new MapInfo.Styles.SimpleInterior(MapInfo.Styles.SimpleInterior.MinFillPattern, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, true);
            MapInfo.Styles.SimpleInterior simpleInterior =
                new MapInfo.Styles.SimpleInterior(0, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, true);
         
            MapInfo.Styles.CompositeStyle compositeStyle = new MapInfo.Styles.CompositeStyle();// (feature.Style);
            compositeStyle.AreaStyle.Interior = simpleInterior;

            //MapInfo.Styles.SimpleLineStyle simpleLineStyle;
            //MapInfo.Styles.LineWidth lineWidth =
            //    new MapInfo.Styles.LineWidth(MapInfo.Styles.LineWidth.MaxPixel, MapInfo.Styles.LineWidthUnit.Pixel);
            //simpleLineStyle =
            //    new MapInfo.Styles.SimpleLineStyle(new MapInfo.Styles.LineWidth(50, MapInfo.Styles.LineWidthUnit.Point), MapInfo.Styles.SimpleLineStyle.MaxLinePattern, System.Drawing.Color.Blue);
            //compositeStyle.AreaStyle.Border = simpleLineStyle;
            return compositeStyle;
        }

        public void insertFeaturesToLayerSQL(MapInfo.Mapping.Map map, MapInfo.Data.IResultSetFeatureCollection ifs,string strLayerName, string strTableName )
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName ] == null)
                return;
            /* Chắc chắn rằng tồn tại đối tượng feature cần insert */
            if (ifs == null)
                return;
            /* Test */
          //  string strConnection = "Server=dmc-chung;DATABASE=georgetown; UID=;PWD=;Trusted_Connection=Yes;";
            MapInfo.Data.MIConnection miConnection = new MapInfo.Data.MIConnection();
            miConnection.ConnectionString = strConnection;
            MapInfo.Data.MICommand miCommand = new MapInfo.Data.MICommand();
            miCommand.Connection = miConnection;
            miCommand.CommandType = System.Data.CommandType.Text;
            /* EndTest */

            /* Khai báo và xác định FeatureLayer cần insert Feature, với tên cho trước tương ứng. */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            /* Khai  báo bảng của FeatureLayer */
            MapInfo.Data.Table table = featureLayer.Table;

            foreach (MapInfo.Data.Feature feature in ifs)
            {
                /* Chỉ cho insert đối tượng dạng vùng */
                /* CẦN XEM LẠI ĐỂ TỐI ƯU HƠN */
                if ((feature.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon) ||
                    (feature.Geometry.Type == MapInfo.Geometry.GeometryType.Polygon) ||
                    (feature.Geometry.Type == MapInfo.Geometry.GeometryType.Rectangle))
                {
                    /* Khai báo và xác định các trường thuộc tính của Feature cần insert */
                    MapInfo.Data.Feature featureInsert = new MapInfo.Data.Feature(table.TableInfo.Columns);
                    featureInsert.Geometry = feature.Geometry;
                    /* Khai báo và khởi tạo biến kiểu của thửa đất */
                    MapInfo.Styles.CompositeStyle landStyle = new MapInfo.Styles.CompositeStyle();
                    /* Gán giá trị cho biến kiểu của đối tượng thửa đất */
                    landStyle = LandStyle();
                    featureInsert.Style = landStyle;
                    featureInsert["SoThua"] = "Test"; //Test

                    /*Test MI_STYLE,  featureInsert["MI_STYLE"] + ", " + */

                    MapInfo.Data.MIConnection connection = new MapInfo.Data.MIConnection();
                    if ( connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();

                    MapInfo.Data.MICommand command = connection.CreateCommand();
                    command.CommandText = "Insert into Đất(MI_STYLE,MI_Geometry) select MI_STYLE,MI_Geometry " +
                        " from Search   ";
                    // values (@style, @geometry)";

                    //command.Parameters.Add("@style", landStyle);
                    //command.Parameters.Add("@geometry", feature.Geometry);
                    command.Prepare();
                    command.ExecuteNonQuery(); 


                    /* EndTest */

                    //featureLayer.Table.InsertFeature(featureInsert);
                }
            }
        }

        /// <summary>
        /// Kiểm tra các Feature dạng vùng trong tập hợp các Features
        /// </summary>
        /// <param name="irfc"></param>
        /// <returns></returns>
        public MapInfo.Data.Feature[] checkRegionsInFeatureCollection( MapInfo.Data.IResultSetFeatureCollection irfc)
        {
            /* Khai báo danh sách mảng các Feature tạm thời */
            System.Collections.ArrayList arrayListFeature = new System.Collections.ArrayList();

            /* Chắc chắn rằng tồn tại đối tượng feature trong tập các Feature cần kiểm tra */
            if (irfc == null)
                return null ;
            /* Chắc chắn rằng tồn tại ít nhất một phần tử */
            if (irfc.Count < 1)
                return null;
            foreach (MapInfo.Data.Feature feature in irfc)
            {
                /* Chỉ cho insert đối tượng dạng vùng */
                if ((feature.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon) ||
                    (feature.Geometry.Type == MapInfo.Geometry.GeometryType.Polygon) ||
                    (feature.Geometry.Type == MapInfo.Geometry.GeometryType.Rectangle))
                {
                    /* Insert Feature dạng vùng */
                    arrayListFeature.Add(feature);
                }
            }
            /* Chắc chắn rằng có nhiều hơn một vùng */
            if (arrayListFeature.Count < 1)
                return null;
            /* Khai báo danh sách các Feature tạm thời chứa các Feature có kiểu vùng tìm được */
            MapInfo.Data.Feature[] featuresTemp = new MapInfo.Data.Feature[arrayListFeature.Count];

            for (int i = 0; i < arrayListFeature.Count; i++)
            {
                featuresTemp[i] = (MapInfo.Data.Feature)arrayListFeature[i];
            }
            /* Gán tập các Feature dạng vùng cho hàm */
            return featuresTemp;
        }
        /// <summary>
        /// Phương thức này dùng để Insert các vùng lên một lớp.
        /// Phương thức này sử dụng trong trường hợp xác nhận TÁCH, NẮN CHỈNH THỬA ĐẤT.
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="featuresRegion"></param>
        /// <param name="strLayerName"></param>
        /// <param name="featureOriginal"></param>
        /// <returns></returns>
        //public bool insertRegionsToFeatureLayer(MapInfo.Mapping.Map map, MapInfo.Data.Feature[] featuresRegion, string strLayerName, MapInfo.Data.Feature featureOriginal, string strXMLMaThuaDatCha)
        //{
        //    /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
        //    if (map == null)
        //        return false;
        //    /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
        //    if (map.Layers[strLayerName] == null)
        //        return false;
        //    /* Chắc chắn rằng tồn tại đối tượng feature cần insert */
        //    if (featuresRegion  == null)
        //        return false;

        //    /* Khai báo và xác định FeatureLayer cần insert Feature, với tên cho trước tương ứng. */
        //    MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
        //    /* Khai  báo bảng của FeatureLayer */
        //    MapInfo.Data.Table table = featureLayer.Table;
        //    bool boolSuccessfully = false;
        //    try
        //    {
        //        /* Số Region trong mảng các Regions - featureRegion */
        //        int intFeaturesNumber = 0;
        //        string[] mangKey = new string[featuresRegion.Length];
        //        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        //        conn.ConnectionString =strConnection ;
        //        conn.Open ();
        //        int i =0;
        //        clsDatabase clsData = new clsDatabase();
        //        foreach (MapInfo.Data.Feature feature in featuresRegion)
        //        {
        //            /* Tăng giá trị đếm số Feature sau mỗi vòng lặp */
        //            intFeaturesNumber += 1;
        //            /* Khai báo và xác định các trường thuộc tính của Feature cần insert */
        //            MapInfo.Data.Feature featureInsert = new MapInfo.Data.Feature(table.TableInfo.Columns);
        //            featureInsert.Geometry = feature.Geometry;
        //            /* Khai báo và khởi tạo biến kiểu của thửa đất */
        //            MapInfo.Styles.CompositeStyle landStyle = new MapInfo.Styles.CompositeStyle();
        //            /* Gán giá trị cho biến kiểu của đối tượng thửa đất */
        //            landStyle = LandStyle();
        //            featureInsert.Style = landStyle;
        //            /* Gán giá trị cho các trường thuộc tính */
        //            featureInsert["MaDonViHanhChinh"] = featureOriginal["MaDonViHanhChinh"];
        //            featureInsert["ToBanDo"] = featureOriginal["ToBanDo"];
        //            /* Trường hợp có nhiều hơn một vùng thì sau một vòng lặp.
        //             Thì ta đánh lại số thửa, bằng cách tăng thêm một hậu tố "-intFeaturesNumber".
        //             Đồng thời THAY ĐỔI trạng thái thửa đất. Trường hợp này thường là TÁCH THỬA*/
        //            if (featuresRegion.Length > 1)
        //            {
        //                featureInsert["SoThua"] = "(" + featureOriginal["SoThua"].ToString().Trim() + ")" + "-" + intFeaturesNumber.ToString();
        //                featureInsert["Status"] = 0;
        //                featureInsert["DanhSachMaThuaDatCha"] = strXMLMaThuaDatCha ;
        //            }
        //            /* Trường hợp có duy nhất 1 vùng thì ta giữ nguyên thuộc tính SỐ HIỆU THỬA.
        //             Đồng thời GIỮ NGUYÊN trạng thái thửa đất. Trường hợp này thường là NẮN CHỈNH THỬA*/
        //            else
        //            {
        //                featureInsert["SoThua"] = featureOriginal["SoThua"];
        //                featureInsert["Status"] = featureOriginal["Status"];
        //                featureInsert["DanhSachMaThuaDatCha"] = strXMLMaThuaDatCha ;
        //            }
        //            /* Diện tích Feature mới tạo ra được tính theo diện tích Feature đó trên bản đồ */
        //            featureInsert["DienTichTuNhien"] = this.Area(featureInsert);
        //            /* Đoạn này bắt lỗi cho trường hợp lỗi Deadlock */
        //        Outer:
        //            try
        //            {
        //                /* Thiết đặt lại giá trị của biến boolSuccessfully về giá trị
        //                 * mặc định */
        //                boolSuccessfully = false;
        //                /* Insert dữ liệu vào bảng */
        //                MapInfo.Data.Key k = new MapInfo.Data.Key();
        //                k = featureLayer.Table.InsertFeature(featureInsert);
        //                // lấy lại key của thửa đất vừa tạo

        //                mangKey[i] = clsData.SelRecoreNew(conn);
        //                    i = i + 1;
        //                /* Nếu Insert thành công thì thiết lập giá trị cho biến boolSuccessfully */
        //                if (k != null)
        //                    boolSuccessfully = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                if (System.Windows.Forms.MessageBox.Show("Quá trình tách thửa bị lỗi!" +
        //                    System.Environment.NewLine + " Bạn có muốn TIẾP TỤC thử lại quá trình tách thửa không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
        //                {
        //                    System.Threading.Thread.Sleep(1000);
        //                    goto Outer;
        //                }
        //                else {
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        /* Làm tươi lớp bản đồ sau khi cập nhật dữ liệu */
        //        featureLayer.Table.Refresh();
        //    }
        //    return boolSuccessfully;
        //}
        public bool insertRegionsToFeatureLayer(MapInfo.Mapping.Map map, MapInfo.Data.Feature[] featuresRegion, string strLayerName, MapInfo.Data.Feature featureOriginal, string strXMLMaThuaDatCha,string strMaThuaDatCon)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return false;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return false;
            /* Chắc chắn rằng tồn tại đối tượng feature cần insert */
            if (featuresRegion == null)
                return false;

            /* Khai báo và xác định FeatureLayer cần insert Feature, với tên cho trước tương ứng. */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            /* Khai  báo bảng của FeatureLayer */
            MapInfo.Data.Table table = featureLayer.Table;
            bool boolSuccessfully = false;
            try
            {
                /* Số Region trong mảng các Regions - featureRegion */
                int intFeaturesNumber = 0;
                strMaThuaDatCon = "";
                string[] mangKey = new string[featuresRegion.Length];
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
                conn.ConnectionString = strConnection;
                conn.Open();
                int i = 0;
                clsDatabase clsData = new clsDatabase();
                clsData.TenBangDat = strTenBangDat;
                foreach (MapInfo.Data.Feature feature in featuresRegion)
                {
                    /* Tăng giá trị đếm số Feature sau mỗi vòng lặp */
                    intFeaturesNumber += 1;
                    /* Khai báo và xác định các trường thuộc tính của Feature cần insert */
                    MapInfo.Data.Feature featureInsert = new MapInfo.Data.Feature(table.TableInfo.Columns);
                    featureInsert.Geometry = feature.Geometry;
                    /* Khai báo và khởi tạo biến kiểu của thửa đất */
                    MapInfo.Styles.CompositeStyle landStyle = new MapInfo.Styles.CompositeStyle();
                    /* Gán giá trị cho biến kiểu của đối tượng thửa đất */
                    landStyle = LandStyle();
                    featureInsert.Style = landStyle;

                    /* Gán giá trị cho các trường thuộc tính */
                    featureInsert["MaDonViHanhChinh"] = featureOriginal["MaDonViHanhChinh"];
                    featureInsert["ToBanDo"] = featureOriginal["ToBanDo"];
                    /* Trường hợp có nhiều hơn một vùng thì sau một vòng lặp.
                     Thì ta đánh lại số thửa, bằng cách tăng thêm một hậu tố "-intFeaturesNumber".
                     Đồng thời THAY ĐỔI trạng thái thửa đất. Trường hợp này thường là TÁCH THỬA*/
                    if (featuresRegion.Length > 1)
                    {
                        featureInsert["SoThua"] = "" + featureOriginal["SoThua"].ToString().Trim() + "" + "(" + intFeaturesNumber.ToString()+ ")";
                        featureInsert["Status"] = 0;
                        featureInsert["DanhSachMaThuaDatCha"] = strXMLMaThuaDatCha;
                    }
                    /* Trường hợp có duy nhất 1 vùng thì ta giữ nguyên thuộc tính SỐ HIỆU THỬA.
                     Đồng thời GIỮ NGUYÊN trạng thái thửa đất. Trường hợp này thường là NẮN CHỈNH THỬA*/
                    else
                    {
                        featureInsert["SoThua"] = featureOriginal["SoThua"];
                        featureInsert["Status"] = featureOriginal["Status"];
                        featureInsert["DanhSachMaThuaDatCha"] = strXMLMaThuaDatCha;
                    }
                    /* Diện tích Feature mới tạo ra được tính theo diện tích Feature đó trên bản đồ */
                    featureInsert["DienTichTuNhien"] = String.Format("{0:0.00}", this.Area(featureInsert)); //this.Area(featureInsert);
                /* Đoạn này bắt lỗi cho trường hợp lỗi Deadlock */
                Outer:
                    try
                    {
                        /* Thiết đặt lại giá trị của biến boolSuccessfully về giá trị
                         * mặc định */
                        boolSuccessfully = false;
                        /* Insert dữ liệu vào bảng */
                        MapInfo.Data.Key k = new MapInfo.Data.Key();
                        k = featureLayer.Table.InsertFeature(featureInsert);
                        // lấy lại key của thửa đất vừa tạo

                        mangKey[i] = clsData.SelRecoreNew(conn);
                        i = i + 1;
                        /* Nếu Insert thành công thì thiết lập giá trị cho biến boolSuccessfully */
                        if (k != null)
                            boolSuccessfully = true;
                        
                    }
                    catch (Exception ex)
                    {
                        if (System.Windows.Forms.MessageBox.Show("Quá trình tách thửa bị lỗi!" +
                            System.Environment.NewLine + " Bạn có muốn TIẾP TỤC thử lại quá trình tách thửa không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Threading.Thread.Sleep(1000);
                            goto Outer;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                for (int j = 0; j < mangKey.Length; j++) {
                    strtmpMaThuaDatCon = strtmpMaThuaDatCon + mangKey[j] + ",";
                }
                if (mangKey.Length > 0)
                {
                    strtmpMaThuaDatCon = strtmpMaThuaDatCon.Substring(0, strtmpMaThuaDatCon.Length - 1);
                }
            }
            finally
            {
                //lay mang doi tuong thua dat con de luu vao lich su
                
                /* Làm tươi lớp bản đồ sau khi cập nhật dữ liệu */

                featureLayer.Table.Refresh();
            }
            return boolSuccessfully;
        }
        /// <summary>
        /// Tính diện tích một Feature có kiểu là kiểu vùng 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        private double Area(MapInfo.Data.Feature feature)
        {
            /* Chắc chắn rằng tồn tại Feature cần tính diện tích */
            if (feature == null)
                return 0.0 ;
            /* Khai báo và khởi tạo biến trung gian */
            double dblArea = 0.0;
            /* Tính diện tích trong trường hợp Feature là kiểu MultiPolygon */
            if (feature.Geometry.TypeName == "MultiPolygon")
            {
                MapInfo.Geometry.MultiPolygon multiPolygon = (MapInfo.Geometry.MultiPolygon)feature.Geometry;
                dblArea = multiPolygon.Area(MapInfo.Geometry.AreaUnit.SquareMeter);
                return dblArea;
            }
            /* Tính diện tích trong trường hợp Feature là kiểu Rectangle */
            else if (feature.Geometry.TypeName == "Rectangle")
            {
                MapInfo.Geometry.Rectangle rectangle = (MapInfo.Geometry.Rectangle)feature.Geometry;
                dblArea = rectangle.Area(MapInfo.Geometry.AreaUnit.SquareMeter);
                return dblArea;
            }
            /* Trường hợp Feature không phải là kiểu vùng */
            else 
                return 0.0;
        }

        /// <summary>
        /// Insert các Features lên một lớp. Trong trường hợp TÁCH THỬA.
        /// Trong trường hợp này các thửa mới tạo thành trước khi Insert vào
        /// lớp đất được giữ nguyên một số giá trị thuộc tính của thửa trước khi tách
        /// Các thuộc tính được giữ nguyên bao gồm:
        /// + Tờ bản đồ.
        /// + Số thửa.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="ifs"></param>
        /// <param name="strLayerName"></param>
        /// <param name="featureSplit"></param>
        /// <returns></returns>
        public bool insertFeaturesToFeatureLayer(MapInfo.Mapping.Map map, MapInfo.Data.IResultSetFeatureCollection ifs, string strLayerName, MapInfo.Data.Feature featureOriginal)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return false  ;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return false  ;
            /* Chắc chắn rằng tồn tại đối tượng feature cần insert */
            if (ifs == null)
                return false ;

            /* Khai báo và xác định FeatureLayer cần insert Feature, với tên cho trước tương ứng. */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            /* Khai  báo bảng của FeatureLayer */
            MapInfo.Data.Table table = featureLayer.Table;

            bool boolSuccessfully = false;

            foreach (MapInfo.Data.Feature feature in ifs)
            {
                /* Chỉ cho insert đối tượng dạng vùng */
                /* CẦN XEM LẠI ĐỂ TỐI ƯU HƠN */
                if ((feature.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon ) ||
                    (feature.Geometry.Type == MapInfo.Geometry.GeometryType.Polygon) ||
                    (feature.Geometry.Type == MapInfo.Geometry.GeometryType.Rectangle)) 
                {
                    /* Khai báo và xác định các trường thuộc tính của Feature cần insert */
                    MapInfo.Data.Feature featureInsert = new MapInfo.Data.Feature(table.TableInfo.Columns);
                    featureInsert.Geometry = feature.Geometry;
                    /* Khai báo và khởi tạo biến kiểu của thửa đất */
                    MapInfo.Styles.CompositeStyle landStyle = new MapInfo.Styles.CompositeStyle();
                    /* Gán giá trị cho biến kiểu của đối tượng thửa đất */
                    landStyle = LandStyle();
                    featureInsert.Style = landStyle; 
                    /* Gán giá trị cho các trường thuộc tính */
                    featureInsert["MaDonViHanhChinh"] = featureOriginal["MaDonViHanhChinh"];
                    featureInsert["ToBanDo"] = featureOriginal["ToBanDo"] ;
                    featureInsert["SoThua"]= featureOriginal["SoThua"];
                    featureInsert["Status"] = 0;
                    featureInsert["DienTichTuNhien"]= "0.0";
                    try
                    {
                        ///* Thiết lập chế độ bắt đầu cập nhật bảng là None */
                        //featureLayer.Table.BeginAccess(MapInfo.Data.TableAccessMode.None);
                        ///* Thiết lập chế độ bắt đầu cập nhật bảng */
                        //featureLayer.Table.BeginAccess(MapInfo.Data.TableAccessMode.Write);
                        /* Insert dữ liệu vào bảng */
                        MapInfo.Data.Key key = featureLayer.Table.InsertFeature(featureInsert);
                        /* Nếu Insert thành công thì thiết lập giá trị cho biến boolSuccessfully */
                        if (key != null)
                            boolSuccessfully = true;
                        ///* Thiết lập chế độ kết thúc cập nhật bảng */
                        //featureLayer.Table.EndAccess();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Lỗi: " + System.Environment.NewLine + ex.Message  , "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                    finally
                    {
                        ///* Thiết lập chế độ bắt đầu cập nhật bảng là None */
                        //featureLayer.Table.BeginAccess(MapInfo.Data.TableAccessMode.None);
                    }
                }
            }
            /* Làm tươi lớp bản đồ sau khi cập nhật dữ liệu */
            featureLayer.Table.Refresh();
            return boolSuccessfully;
        }

        public bool insertFeaturesToFeatureLayer(MapInfo.Mapping.Map map, MapInfo.Data.IResultSetFeatureCollection ifs, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return false;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return false;
            //if (MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerName)== null )
            //    return false;

            /* Chắc chắn rằng tồn tại đối tượng feature cần insert */
            if (ifs == null)
                return false;

            /* Khai báo và xác định FeatureLayer cần insert Feature, với tên cho trước tương ứng. */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            /* Khai  báo bảng của FeatureLayer */
            MapInfo.Data.Table table = featureLayer.Table;

            bool boolSuccessfully = false;

            foreach (MapInfo.Data.Feature feature in ifs)
            {
                /* Chỉ cho insert đối tượng dạng vùng */
                /* CẦN XEM LẠI ĐỂ TỐI ƯU HƠN */
                if ((feature.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon) ||
                    (feature.Geometry.Type == MapInfo.Geometry.GeometryType.Polygon) ||
                    (feature.Geometry.Type == MapInfo.Geometry.GeometryType.Rectangle))
                {
                    /* Khai báo và xác định các trường thuộc tính của Feature cần insert */
                    MapInfo.Data.Feature featureInsert = new MapInfo.Data.Feature(table.TableInfo.Columns);
                    featureInsert.Geometry = feature.Geometry;
                    /* Khai báo và khởi tạo biến kiểu của thửa đất */
                    MapInfo.Styles.CompositeStyle landStyle = new MapInfo.Styles.CompositeStyle();
                    /* Gán giá trị cho biến kiểu của đối tượng thửa đất */
                    landStyle = LandStyle();
                    featureInsert.Style = landStyle;
                    ///* Gán giá trị cho các trường thuộc tính */
                    //featureInsert["MaDonViHanhChinh"] = featureOriginal["MaDonViHanhChinh"];
                    //featureInsert["ToBanDo"] = featureOriginal["ToBanDo"];
                    //featureInsert["SoThua"] = featureOriginal["SoThua"];
                    //featureInsert["Status"] = 0;
                    //featureInsert["DienTichTuNhien"] = "0.0";

                    ///* Thiết lập chế độ bắt đầu cập nhật bảng */
                    //featureLayer.Table.BeginAccess(MapInfo.Data.TableAccessMode.Write);

                    /* Insert dữ liệu vào bảng */
                    MapInfo.Data.Key key = featureLayer.Table.InsertFeature(featureInsert);
                    /* Nếu Insert thành công thì thiết lập giá trị cho biến boolSuccessfully */
                    if (key != null)
                        boolSuccessfully = true;

                    ///* Thiết lập chế độ kết thúc cập nhật bảng */
                    //featureLayer.Table.EndAccess();
                }
            }
            /* Làm tươi lớp bản đồ sau khi cập nhật dữ liệu */
            featureLayer.Table.Refresh();
            return boolSuccessfully;
        }


        /// <summary>
        /// Phương thức này thực thi việc Insert một vùng vào một lớp.
        /// Phương thức này sử dụng cho trường hợp xác nhận trong chức năng
        /// GỘP THỬA - COMBINE 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="featureRegion"></param>
        /// <param name="strLayerName"></param>
        /// <returns></returns>
        public bool insertRegionToFeatureLayer(MapInfo.Mapping.Map map, MapInfo.Data.Feature featureRegion, string strLayerName , string strCombiningLandIndex, MapInfo.Data.Feature featureMain, string strDanhSachMaThuaDatCha)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return false;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return false;
            /* Chắc chắn rằng tồn tại đối tượng feature cần insert */
            if (featureRegion  == null)
                return false;

            /* Khai báo và xác định FeatureLayer cần insert Feature, với tên cho trước tương ứng. */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            /* Khai  báo bảng của FeatureLayer */
            MapInfo.Data.Table table = featureLayer.Table;

            bool boolSuccessfully = false;

            ///* Thiết lập chế độ bắt đầu cập nhật bảng */
            //featureLayer.Table.BeginAccess(MapInfo.Data.TableAccessMode.Write);

            /* Khai báo và xác định các trường thuộc tính của Feature cần insert */
            MapInfo.Data.Feature featureInsert = new MapInfo.Data.Feature(table.TableInfo.Columns);
            featureInsert.Geometry = featureRegion.Geometry;
            /* Khai báo và khởi tạo biến kiểu của thửa đất */
            MapInfo.Styles.CompositeStyle landStyle = new MapInfo.Styles.CompositeStyle();
            /* Gán giá trị cho biến kiểu của đối tượng thửa đất */
            landStyle = LandStyle();
            featureInsert.Style = landStyle;
            /* Gán giá trị cho các trường thuộc tính */
            featureInsert["MaDonViHanhChinh"] = featureMain["MaDonViHanhChinh"];
            featureInsert["ToBanDo"] = featureMain["ToBanDo"];
            /* KIỂM TRA LẠI SỐ HIỆU THỬA ĐẤT SAU KHI GHÉP THỬA */
            //featureInsert["SoThua"] = strCombiningLandIndex ;
            featureInsert["SoThua"] = strCombiningLandIndex;
            featureInsert["Status"] = 0;
            featureInsert["DienTichTuNhien"] = String.Format("{0:0.00}", this.Area(featureInsert));  //this.Area(featureInsert);
            /* Danh sách mã thửa đất cha */
            featureInsert["DanhSachMaThuaDatCha"] = strDanhSachMaThuaDatCha;

            /* Insert dữ liệu vào bảng */
            MapInfo.Data.Key key = featureLayer.Table.InsertFeature(featureInsert);
            /* Nếu Insert thành công thì thiết lập giá trị cho biến boolSuccessfully */
            if (key != null)
                boolSuccessfully = true;

            ///* Thiết lập chế độ kết thúc cập nhật bảng */
            //featureLayer.Table.EndAccess();

            /* Làm tươi lớp bản đồ sau khi cập nhật dữ liệu */
            featureLayer.Table.Refresh();
            return boolSuccessfully;
        }


        /// <summary>
        /// Insert các Features lên một lớp, với mã đơn vị hành chính xác định. Trong trường hợp 
        /// THÊM MỚI THỬA ĐẤT
        /// </summary>
        /// <param name="map"></param>
        /// <param name="ifs"></param>
        /// <param name="strLayerName"></param>
        /// <returns></returns>
        public bool insertRegionsToFeatureLayer(MapInfo.Mapping.Map map, MapInfo.Data.Feature[]  featuresRegion, string strLayerName,int intMaDonViHanhChinh)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return false;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return false;
            /* Chắc chắn rằng tồn tại đối tượng feature cần insert */
            if (featuresRegion  == null)
                return false;

            /* Khai báo và xác định FeatureLayer cần insert Feature, với tên cho trước tương ứng. */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            /* Khai  báo bảng của FeatureLayer */
            MapInfo.Data.Table table = featureLayer.Table;

            bool boolSuccessfully = false;

            foreach (MapInfo.Data.Feature feature in featuresRegion)
            {
                /* Khai báo và xác định các trường thuộc tính của Feature cần insert */
                MapInfo.Data.Feature featureInsert = new MapInfo.Data.Feature(table.TableInfo.Columns);
                featureInsert.Geometry = feature.Geometry;
                /* Khai báo và khởi tạo biến kiểu của thửa đất */
                MapInfo.Styles.CompositeStyle landStyle = new MapInfo.Styles.CompositeStyle();
                /* Gán giá trị cho biến kiểu của đối tượng thửa đất */
                landStyle = LandStyle();
                featureInsert.Style = landStyle;
                /* Gán giá trị cho các trường thuộc tính */
                featureInsert["MaDonViHanhChinh"] = intMaDonViHanhChinh;
                featureInsert["ToBanDo"] = "0";
                featureInsert["SoThua"] = "0";
                featureInsert["Status"] = 0;
                featureInsert["DienTichTuNhien"] = String.Format("{0:0.00}", this.Area(featureInsert)); ;//this.Area(featureInsert);

                ///* Thiết lập chế độ bắt đầu cập nhật bảng */
                //featureLayer.Table.BeginAccess(MapInfo.Data.TableAccessMode.Write);

                /* Insert dữ liệu vào bảng */
                MapInfo.Data.Key key = featureLayer.Table.InsertFeature(featureInsert);
                /* Nếu Insert thành công thì thiết lập giá trị cho biến boolSuccessfully */
                if (key != null)
                    boolSuccessfully = true;

                ///* Thiết lập chế độ kết thúc cập nhật bảng */
                //featureLayer.Table.EndAccess();
            }

            /* Làm tươi lớp bản đồ sau khi cập nhật dữ liệu */
            featureLayer.Table.Refresh();

            return boolSuccessfully;
        }


        /// <summary>
        /// Insert các Features lên một lớp. Trong trường hợp 
        /// INSERT CÁC THỬA CẦN GỘP LÊN LỚP TẠM ĐỂ XỬ LÝ
        /// </summary>
        /// <param name="map"></param>
        /// <param name="ifs"></param>
        /// <param name="strLayerName"></param>
        /// <returns></returns>
        public bool insertRegionsToFeatureLayer(MapInfo.Mapping.Map map, MapInfo.Data.Feature[] featuresRegion, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return false;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return false;
            /* Chắc chắn rằng tồn tại đối tượng feature cần insert */
            if (featuresRegion == null)
                return false;

            /* Khai báo và xác định FeatureLayer cần insert Feature, với tên cho trước tương ứng. */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            /* Khai  báo bảng của FeatureLayer */
            MapInfo.Data.Table table = featureLayer.Table;

            bool boolSuccessfully = false;

            foreach (MapInfo.Data.Feature feature in featuresRegion)
            {
                /* Khai báo và xác định các trường thuộc tính của Feature cần insert */
                MapInfo.Data.Feature featureInsert = new MapInfo.Data.Feature(table.TableInfo.Columns);
                featureInsert.Geometry = feature.Geometry;
                /* Khai báo và khởi tạo biến kiểu của thửa đất */
                MapInfo.Styles.CompositeStyle landStyle = new MapInfo.Styles.CompositeStyle();
                /* Gán giá trị cho biến kiểu của đối tượng thửa đất */
                landStyle = LandStyle();
                featureInsert.Style = landStyle;
                /* Gán giá trị cho các trường thuộc tính */
                featureInsert["ToBanDo"] = "";
                featureInsert["SoThua"] = "";
                featureInsert["Status"] = 0;
                ///* Thiết lập chế độ bắt đầu cập nhật bảng */
                //featureLayer.Table.BeginAccess(MapInfo.Data.TableAccessMode.Write);

                /* Insert dữ liệu vào bảng */
                MapInfo.Data.Key key = featureLayer.Table.InsertFeature(featureInsert);
                /* Nếu Insert thành công thì thiết lập giá trị cho biến boolSuccessfully */
                if (key != null)
                    boolSuccessfully = true;

                ///* Thiết lập chế độ kết thúc cập nhật bảng */
                //featureLayer.Table.EndAccess();
            }

            /* Làm tươi lớp bản đồ sau khi cập nhật dữ liệu */
            featureLayer.Table.Refresh();

            return boolSuccessfully;
        }

        public bool  insertFeatureToFeatureLayer(MapInfo.Mapping.Map map, MapInfo.Data.Feature feature, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return false  ;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return false ;
            /* Chắc chắn rằng tồn tại đối tượng feature cần insert */
            if (feature == null)
                return false  ;
            /* Khai báo biến trung kiểu bool */
            bool boolSuccessfully = false;
            /* Khai báo và xác định FeatureLayer cần insert Feature, với tên cho trước tương ứng. */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            /* Khai  báo bảng của FeatureLayer */
            MapInfo.Data.Table table = featureLayer.Table;
            /* Khai báo và xác định các trường thuộc tính của Feature cần insert */
            MapInfo.Data.Feature featureInsert = new MapInfo.Data.Feature(table.TableInfo.Columns);
            featureInsert.Geometry = feature.Geometry;
            /* Khai báo và khởi tạo biến kiểu của thửa đất */
            MapInfo.Styles.CompositeStyle landStyle = new MapInfo.Styles.CompositeStyle();
            /* Gán giá trị cho biến kiểu của đối tượng thửa đất */
            landStyle = LandStyle();
            featureInsert.Style = landStyle; 

            ///* Xác nhận bắt đầu cập nhật bảng */
            //featureLayer.Table.BeginAccess(MapInfo.Data.TableAccessMode.Write);

            /* Insert dữ liệu vào bảng */
            MapInfo.Data.Key key = featureLayer.Table.InsertFeature(featureInsert);
            /* Nếu cập nhật thành công, gán giá trị cho biến boolSucessfully */
            if (key != null)
                boolSuccessfully = true;

            ///* Kết thúc cập nhật dữ liệu vào bảng */
            //featureLayer.Table.EndAccess();

            /* Làm tươi lớp bản đồ sau khi cập nhật dữ liệu */
            featureLayer.Table.Refresh();
            return boolSuccessfully;
        }

        public void DeleteAllFeatures(MapInfo.Mapping.Map map,string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            /* Lựa chọn tất cả các đối tượng trên lớp thửa đất */
            MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchAll();
            MapInfo.Data.IResultSetFeatureCollection irfs = MapInfo.Engine.Session.Current.Catalog.Search(strLayerName, si);

            foreach (MapInfo.Data.Feature feature in irfs)
            {
                /* Xóa Feature*/
                irfs.Table.DeleteFeature(feature);
            }
        }

        /// <summary>
        /// Xóa tập hợp các Feature trên một lớp có tên là strLayerName
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần xóa tập các Feature</param>
        /// <param name="features">Danh sách các Feature cần xóa</param>
        /// <param name="strLayerName">Tên lớp chứa danh sách các Feature cần xóa</param>
        public void DeleteFeatures(MapInfo.Mapping.Map map, ref  MapInfo.Data.Feature[] features, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại Feature cần xóa */
            if (features == null)
                return;
            /* Khai báo FeatureLayer cần thực thi */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;

            ///* Xác nhận bắt đầu cập nhật bảng */
            //table.BeginAccess(MapInfo.Data.TableAccessMode.Write);

            foreach (MapInfo.Data.Feature feature in features)
            {
                //if (feature.Geometry.Type.ToString() == "MultiPolygon")
                //{
                /* Xóa Feature*/
                table.DeleteFeature(feature);
                //}
            }

            ///* Xác nhận kết thúc cập nhật bảng */
            //table.EndAccess();

            /* Làm tươi dữ liệu */
            table.Refresh();
        }

        public  void DeleteFeature(MapInfo.Mapping.Map map, MapInfo.Data.Feature feature, string strLayerName)
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

            ///* Xác nhận bắt đầu cập nhật bảng */
            //table.BeginAccess(MapInfo.Data.TableAccessMode.Write);

            /* Xóa Feature */
            table.DeleteFeature(feature);

            ///* Xác nhận kết thúc cập nhật bảng */
            //table.EndAccess();

            /* Làm tươi bảng vừa cập nhật */
            table.Refresh();
        }

        public  void PolygonToLines(MapInfo.Mapping.Map map, MapInfo.Geometry.Polygon polygon, string strLayerName)
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
            /* Trường hợp các điểm phía ngoài Polygon */
            MapInfo.Geometry.DPoint[] dPointsExteriorPolygon = polygon.Exterior.SamplePoints();
            MultiPointToLines(map, strLayerName, dPointsExteriorPolygon);
            /* Trường hợp các điểm phía trong Polygon */
            /* Break thành các đối tượng dạng Line cho từng Interior Polygon một */
            for (int i = 0; i < polygon.InteriorCount; i++)
            {
                MapInfo.Geometry.DPoint[] dPointsInteriorPolygon = polygon.Interior(i).SamplePoints();
                MultiPointToLines(map, strLayerName, dPointsInteriorPolygon);
            }
        }

        /// <summary>
        /// Vẽ Line, Polyline trên lớp
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp có tên là strLayerName cần vẽ polyline</param>
        /// <param name="strLayerName">Tên lớp cần vẽ Polyline</param>
        /// <param name="dPoints">Danh sách điểm Node của Polyline</param>
        public void CreatePolyline(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint[] dPoints)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại danh sách điểm */
            if (dPoints == null)
                return;
            /* Chắc chắn rằng danh sách điểm có số phần tử lớn hơn 1 */
            if (dPoints.Length <= 1)
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
            MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(null , bl, null, null);
            /* Khai báo Feature dạng Line cần tạo */
            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Gán giá trị cho Feature cần tạo */
            feature.Geometry = g;
            feature.Style = cs;
            /* Add Line vào FeatureLayer cho trước */
            featureLayer.Table.InsertFeature(feature);
        }

        /// <summary>
        /// Vẽ một đối tượng Polyline với kiểu Polyline xác định cho trước
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp có tên là strLayerName</param>
        /// <param name="strLayerName">Tên lớp cần vẽ Polyline</param>
        /// <param name="dPoints">Danh sách điểm nude của Polyline</param>
        /// <param name="cs">Kiểu của polyline</param>
        public void CreatePolyline(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint[] dPoints,MapInfo.Styles.CompositeStyle cs)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại danh sách điểm */
            if (dPoints == null)
                return;
            /* Chắc chắn rằng danh sách điểm có số phần tử lớn hơn 1 */
            if (dPoints.Length <= 1)
                return;
            /* Khai báo FeatureLayer cần thực thi */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;
            /* Khai báo FeatureGeometry dạng Line với tọa độ và Hệ tọa độ đã xác định */
            //MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiCurve(map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, dPoints);
            MapInfo.Geometry.CoordSys coordsys = featureLayer.CoordSys;
            MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiCurve(coordsys, MapInfo.Geometry.CurveSegmentType.Linear, dPoints);

            ///* Khai báo kiểu Line */
            //MapInfo.Styles.SimpleLineStyle bl = new MapInfo.Styles.SimpleLineStyle(null,intPatternIndex);
            //MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(null, bl, null, null);
            /* Khai báo Feature dạng Line cần tạo */
            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Gán giá trị cho Feature cần tạo */
            feature.Geometry = g;
            feature.Style = cs;
            /* Add Line vào FeatureLayer cho trước */
            clsMainSoanHoSo cls = new clsMainSoanHoSo();
            string MaDoiTuong = "4";
            cls.UpdateDoiTuong(featureLayer.Table, feature.Geometry, MaDoiTuong, cs,"0");
            //featureLayer.Table.InsertFeature(feature);
        }

        /// <summary>
        /// Vẽ một đối tượng Polyline với kiểu Polyline xác định cho trước
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp có tên là strLayerName</param>
        /// <param name="strLayerName">Tên lớp cần vẽ Polyline</param>
        /// <param name="dPoints">Danh sách điểm nude của Polyline</param>
        /// <param name="cs">Kiểu của polyline</param>
        public void CreatePolyline(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint[] dPoints, MapInfo.Styles.CompositeStyle cs, string strObjectGroupField , string strObjectGroupValue)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại danh sách điểm */
            if (dPoints == null)
                return;
            /* Chắc chắn rằng danh sách điểm có số phần tử lớn hơn 1 */
            if (dPoints.Length <= 1)
                return;
            /* Chắc chắn rằng tồn tại tên Trường xác định nhóm đối tượng */
            if (strObjectGroupField.Trim() == "")
                return;
            /* Chắc chắn rằng tồn tại giá trị trường xác định nhóm đối tượng */
            if (strObjectGroupValue.Trim() == "")
                return;
            /* Khai báo FeatureLayer cần thực thi */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;
            /* Khai báo FeatureGeometry dạng Line với tọa độ và Hệ tọa độ đã xác định */
            //MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiCurve(map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, dPoints);
            MapInfo.Geometry.CoordSys coordsys = featureLayer.CoordSys;
            MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiCurve(coordsys, MapInfo.Geometry.CurveSegmentType.Linear, dPoints);

            ///* Khai báo kiểu Line */
            //MapInfo.Styles.SimpleLineStyle bl = new MapInfo.Styles.SimpleLineStyle(null,intPatternIndex);
            //MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(null, bl, null, null);
            /* Khai báo Feature dạng Line cần tạo */
            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Gán giá trị cho Feature cần tạo */
            feature.Geometry = g;
            feature.Style = cs;
            /* Chắc chắn rằng tồn tại cột có tên là strObjectGroupField */
            if (featureLayer.Table.TableInfo.Columns.Contains(featureLayer.Table.TableInfo.Columns[strObjectGroupField]))
            {
                if (featureLayer.Table.TableInfo.Columns[strObjectGroupField].DataType == MapInfo.Data.MIDbType.Int)
                    /* Gán giá trị vào trường strObjectGroupField để xác định kiểu đối tượng vừa tạo */
                    feature[strObjectGroupField] = Convert.ToInt32(strObjectGroupValue.Trim());
                else
                    /* Gán giá trị vào trường strObjectGroupField để xác định kiểu đối tượng vừa tạo */
                    feature[strObjectGroupField] = strObjectGroupValue;
            }
            /* Add Line vào FeatureLayer cho trước */
            featureLayer.Table.InsertFeature(feature);
        }


        /// <summary>
        /// Tạo MultiPoint từ tập hợp các điểm
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tạo MultiPoint </param>
        /// <param name="strLayerName">Tên lớp cần tạo MultiPoint</param>
        /// <param name="dPoints">Tập hợp các điểm cần tạo MultiPoint</param>
        public void CreatePoint(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint[] dPoints)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại danh sách điểm */
            if (dPoints == null)
                return;
            /* CẦN XEM LẠI */
            /* Chắc chắn rằng danh sách điểm có số phần tử lớn hơn 1. Với điều kiện này
             ta sẽ không đánh dấu những Feature dạng điểm */
            if (dPoints.Length <= 1)
                return;
            /* Khai báo FeatureLayer cần thực thi */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;
            /* Khai báo FeatureGeometry dạng Point với tọa độ và Hệ tọa độ đã xác định */
            MapInfo.Geometry.CoordSys coordsys = featureLayer.CoordSys;
            MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiPoint(coordsys,dPoints);
            /* Khai báo kiểu Point */
            MapInfo.Styles.SimpleVectorPointStyle bp = new MapInfo.Styles.SimpleVectorPointStyle();
            MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(null, null , null, bp );
            /* Khai báo Feature dạng Pont cần tạo */
            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Gán giá trị cho Feature cần tạo */
            feature.Geometry = g;
            feature.Style = cs;
            /* Add Point vào FeatureLayer cho trước */
            featureLayer.Table.InsertFeature(feature);
        }
        /// <summary>
        /// Tạo điểm trên lớp bản đồ
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tạo điểm</param>
        /// <param name="strLayerName">Tên lớp bản đồ</param>
        /// <param name="dPoint">Tạo độ điểm cần tạo</param>
        public void CreatePoint(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint dPoint)
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
            /* Khai báo FeatureGeometry dạng Point với tọa độ và Hệ tọa độ đã xác định */
            MapInfo.Geometry.CoordSys coordsys = featureLayer.CoordSys;
            MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.Point(coordsys, dPoint);
            /* Khai báo kiểu Point */
            MapInfo.Styles.SimpleVectorPointStyle bp = new MapInfo.Styles.SimpleVectorPointStyle();
            MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(null, null, null, bp);
            /* Khai báo Feature dạng Pont cần tạo */
            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Gán giá trị cho Feature cần tạo */
            feature.Geometry = g;
            feature.Style = cs;
            /* Add Point vào FeatureLayer cho trước */
            featureLayer.Table.InsertFeature(feature);
        }

        /// <summary>
        /// Tạo Text trên lớp bản đồ
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tạo điểm</param>
        /// <param name="strLayerName">Tên lớp bản đồ</param>
        /// <param name="dPoint">Toạ độ điểm cần tạo</param>
        /// <param name="strCaption"> Caption của Text cần tạo </param>
        public void CreateText(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint dPoint, string strCaption, int intFontSize)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại Caption của Text */
            if (strCaption == "")
                return;
            MapInfo.Geometry.DRect rect = new MapInfo.Geometry.DRect(dPoint.x-0.25, dPoint.y - 0.5, dPoint.x + 0.25, dPoint.y + 0.5);
            /* Khai báo FeatureLayer cần thực thi */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;
            /* Khai báo FeatureGeometry dạng Point với tọa độ và Hệ tọa độ đã xác định */
            MapInfo.Geometry.CoordSys coordsys = featureLayer.CoordSys;
            MapInfo.Geometry.LegacyText legacyText = new MapInfo.Geometry.LegacyText(coordsys, rect, strCaption);
            /* Khai báo Feature dạng LegacyText cần tạo */
            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Khai báo kiểu Legacy Text */
            MapInfo.Styles.CompositeStyle cs  = new MapInfo.Styles.CompositeStyle(new MapInfo.Styles.TextStyle(new MapInfo.Styles.Font(".vnarial", intFontSize)));
            /* Gán giá trị cho Feature cần tạo */
            feature.Geometry = legacyText;
            feature.Style = cs;
            /* Add Point vào FeatureLayer cho trước */
            featureLayer.Table.InsertFeature(feature);
        }
        /// <summary>
        /// Tạo Text trên lớp bản đồ
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tạo điểm</param>
        /// <param name="strLayerName">Tên lớp bản đồ</param>
        /// <param name="dPoint">Toạ độ điểm cần tạo</param>
        /// <param name="strCaption"> Caption của Text cần tạo </param>
        /// <param name="dblWidth">Khống chế chiều rộng của Text (chỉ với trường hợp 1 kí tự)</param>
        /// <param name="dblHeight">Khống chế chiều cao của Text (chỉ với trường hợp 1 kí tự) </param>
        public void CreateText(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint dPoint, string strCaption, int intFontSize, double dblWidth, double dblHeight)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại Caption của Text */
            if (strCaption == "")
                return;
            /* Chắc chắn rằng tồn tại chiều cao Text */
            if (dblHeight == 0.00)
                return;
            /* Chắc chắn rằng tồn tại chiều rộng Text */
            if (dblWidth == 0.00)
                return;
            /* Khai báo và gán giá trị cho biến nửa chiều rộng */
            double dblHalfWidth;
            dblHalfWidth = dblWidth / 2;
            /* Khai báo và gán giá trị biến nửa chiều cao */
            double dblHalfHeight;
            dblHalfHeight = dblHeight / 2;
            MapInfo.Geometry.DRect rect = new MapInfo.Geometry.DRect(dPoint.x - dblHalfWidth, dPoint.y - dblHalfHeight, dPoint.x + dblHalfWidth, dPoint.y + dblHalfHeight);
            /* Khai báo FeatureLayer cần thực thi */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;
            /* Khai báo FeatureGeometry dạng Point với tọa độ và Hệ tọa độ đã xác định */
            MapInfo.Geometry.CoordSys coordsys = featureLayer.CoordSys;
            MapInfo.Geometry.LegacyText legacyText = new MapInfo.Geometry.LegacyText(coordsys, rect, strCaption);
            /* Khai báo Feature dạng LegacyText cần tạo */
            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Khai báo kiểu Legacy Text */
            MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(new MapInfo.Styles.TextStyle(new MapInfo.Styles.Font(".vnarial", intFontSize)));
            /* Gán giá trị cho Feature cần tạo */
            feature.Geometry = legacyText;
            feature.Style = cs;
            /* Add Point vào FeatureLayer cho trước */
            featureLayer.Table.InsertFeature(feature);
        }

        /// <summary>
        /// Tạo Text trên lớp bản đồ
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tạo điểm</param>
        /// <param name="strLayerName">Tên lớp bản đồ</param>
        /// <param name="dPoint">Toạ độ điểm cần tạo</param>
        /// <param name="strCaption"> Caption của Text cần tạo </param>
        /// <param name="dblWidth">Khống chế chiều rộng của Text (chỉ với trường hợp 1 kí tự)</param>
        /// <param name="dblHeight">Khống chế chiều cao của Text (chỉ với trường hợp 1 kí tự) </param>
        /// <param name="strObjectGroupField">Tên trường kiểu đối tượng để xác định đối tượng là thuộc nhóm đối tượng nào</param>
        /// <param name="strObjectGroupValue">Giá trị xác định đối tượng thuộc nhóm nào</param>

        public void CreateText(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint dPoint, string strCaption, int intFontSize, double dblWidth, double dblHeight, string strObjectGroupField, string strObjectGroupValue)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại Caption của Text */
            if (strCaption == "")
                return;
            /* Chắc chắn rằng tồn tại chiều cao Text */
            if (dblHeight == 0.00)
                return;
            /* Chắc chắn rằng tồn tại chiều rộng Text */
            if (dblWidth == 0.00)
                return;
            /* Chắc chắn rằng tồn tại tên Trường xác định nhóm đối tượng */
            if (strObjectGroupField.Trim() == "")
                return;
            /* Chắc chắn rằng tồn tại giá trị trường xác định nhóm đối tượng */
            if (strObjectGroupValue.Trim() == "")
                return;
            /* Khai báo và gán giá trị cho biến nửa chiều rộng */
            double dblHalfWidth;
            dblHalfWidth = dblWidth / 2;
            /* Khai báo và gán giá trị biến nửa chiều cao */
            double dblHalfHeight;
            dblHalfHeight = dblHeight / 2;
            MapInfo.Geometry.DRect rect = new MapInfo.Geometry.DRect(dPoint.x - dblHalfWidth, dPoint.y - dblHalfHeight, dPoint.x + dblHalfWidth, dPoint.y + dblHalfHeight);
            /* Khai báo FeatureLayer cần thực thi */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;
            /* Khai báo FeatureGeometry dạng Point với tọa độ và Hệ tọa độ đã xác định */
            MapInfo.Geometry.CoordSys coordsys = featureLayer.CoordSys;
            MapInfo.Geometry.LegacyText legacyText = new MapInfo.Geometry.LegacyText(coordsys, rect, strCaption);
            /* Khai báo Feature dạng LegacyText cần tạo */
            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Khai báo kiểu Legacy Text */
            MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(new MapInfo.Styles.TextStyle(new MapInfo.Styles.Font(".vnarial", intFontSize)));
            /* Gán giá trị cho Feature cần tạo */
            feature.Geometry = legacyText;
            feature.Style = cs;
            /* Chắc chắn rằng tồn tại cột có tên là strObjectGroupField */
            if (featureLayer.Table.TableInfo.Columns.Contains(featureLayer.Table.TableInfo.Columns[strObjectGroupField]))
            {
                if (featureLayer.Table.TableInfo.Columns[strObjectGroupField].DataType == MapInfo.Data.MIDbType.Int)
                    /* Gán giá trị vào trường strObjectGroupField để xác định kiểu đối tượng vừa tạo */
                    feature[strObjectGroupField] = Convert.ToInt32(strObjectGroupValue.Trim());
                else 
                    /* Gán giá trị vào trường strObjectGroupField để xác định kiểu đối tượng vừa tạo */
                    feature[strObjectGroupField] = strObjectGroupValue;
            }
            /* Add Point vào FeatureLayer cho trước */
            featureLayer.Table.InsertFeature(feature);
        }

        public void MarkedPoints(MapInfo.Mapping.Map map, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            if (featureLayer == null)
                return;
            /* Xác định những Feature nào đang được lựa chọn trên lớp có tên là strLayerName */
            ////TachThua.FeatureTools featureTool = new FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc = this.SelectFeatures(map, strLayerName);
            if (irfc == null)
                return;
            foreach (MapInfo.Data.Feature feature in irfc)
            {
                /* Khai báo biến có kiểu DPoint, chứa danh sách điểm của MultiCurve */
                MapInfo.Geometry.DPoint[] dPoints = null  ;
                /* Chỉ thực hiện với những Feature có kiểu là đường hoặc vùng */
                if (feature.Geometry.Type == MapInfo.Geometry.GeometryType.MultiCurve)
                {
                    /* Nếu Feature đó có kiểu là MultiCurve thì thì ép kiểu */
                    MapInfo.Geometry.MultiCurve multiCurve = (MapInfo.Geometry.MultiCurve)feature.Geometry;
                    /* Gán danh sách các đỉnh của MultiCurve vào giá trị cho biến danh sách */
                    dPoints = multiCurve[0].SamplePoints();
                }
                else if (feature.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon)
                {
                    /* Nếu Feature đó có kiểu là MultiPolygon thì thì ép kiểu */
                    MapInfo.Geometry.MultiPolygon  multiPolygon = (MapInfo.Geometry.MultiPolygon)feature.Geometry;
                    /* Gán danh sách các đỉnh của MultiPolygon vào giá trị cho biến danh sách */
                    dPoints = multiPolygon[0].Exterior.SamplePoints();
                }
                if (dPoints != null)
                {
                    /* Đánh dấu điểm tương ứng với danh sách điểm */
                    ////TachThua.FeatureTools featureTools = new FeatureTools();
                    this.CreatePoint(map, strLayerName, dPoints);
                }
            }
        }

        public void ConvertToMultiPolygon(MapInfo.Mapping.Map map, string strLayerName  )
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            MapInfo.Mapping.FeatureLayer featureLayer = ( MapInfo.Mapping.FeatureLayer )map.Layers[strLayerName];
            if (featureLayer == null)
                return;
            /* Xác định những Feature nào đang được lựa chọn trên lớp có tên là strLayerName */
            ////TachThua.FeatureTools featureTool = new FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc = this.SelectFeatures(map, strLayerName );
            if (irfc == null)
                return;
            foreach (MapInfo.Data.Feature feature in irfc)
            {
                /* Chỉ thực hiện với những Feature có kiểu là MultiCurve (Line, Polylines) */
                if (feature.Geometry.Type != MapInfo.Geometry.GeometryType.MultiCurve)
                    return;
                /* Nếu Feature đó có kiểu là MultiCurve thì thì ép kiểu */
                MapInfo.Geometry.MultiCurve multiCurve = (MapInfo.Geometry.MultiCurve)feature.Geometry;
                /* Chỉ chuyển về MultiPolygon khi điểm đầu và điểm cuối của MultiCurve (Polilines)  trùng nhau */
                if (multiCurve[0].StartPoint.ToString() == multiCurve[multiCurve.CurveCount - 1].EndPoint.ToString())
                {
                    /* Khai báo biến có kiểu DPoint, chứa danh sách điểm của MultiCurve */
                    MapInfo.Geometry.DPoint[] dPoints;
                    /* Gán danh sách các đỉnh của MultiCurve vào giá trị cho biến danh sách */
                    dPoints = multiCurve[0].SamplePoints();
                    /* Tạo Polygon (MultiPolygon) tương ứng với danh sách điểm */
                    ////TachThua.FeatureTools featureTools = new FeatureTools();
                    MapInfo.Data.Feature featurePolygon;
                    featurePolygon = this.CreatePolygon(map, strLayerName, dPoints);
                    if (featurePolygon != null)
                    {
                        /* Nếu tạo thành công thì xóa Feature cũ */
                        featureLayer.Table.DeleteFeature(feature);
                    }
                }
            }
        }

        public MapInfo.Data.Feature CreatePolygon(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint[] dPoints)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return null  ;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return null   ;
            /* Chắc chắn rằng tồn tại danh sách điểm */
            if (dPoints == null)
                return null   ;
            /* Chắc chắn rằng danh sách điểm có số phần tử lớn hơn 1 */
            if (dPoints.Length <= 1)
                return null   ;
            /* Chỉ chuyển về MultiPolygon khi điểm đầu và điểm cuối của trùng nhau */
            if (dPoints[0].ToString() != dPoints[dPoints.Length -1].ToString())
                return null   ;
            /* Khai báo FeatureLayer cần thực thi */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;
            /* Khai báo FeatureGeometry dạng MultiPolygon với tọa độ và Hệ tọa độ đã xác định */
            MapInfo.Geometry.CoordSys coordsys = featureLayer.CoordSys;
            MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiPolygon(coordsys , MapInfo.Geometry.CurveSegmentType.Linear, dPoints);

            MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();
            cs = LandStyle();
            /* Khai báo Feature dạng Line cần tạo */
            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Gán giá trị cho Feature cần tạo */
            feature.Geometry = g;
            feature.Style = cs;
            MapInfo.Data.Key k = featureLayer.Table.InsertFeature(feature );
            return feature ;
        }

        /// <summary>
        /// Break những Feature đang được lựa chọn trong lớp thành các Line
        /// </summary>
        /// <param name="map"></param>
        /// <param name="strLayerName"></param>
        public  void BreakFeatureCollectionInLayer(MapInfo.Mapping.Map map,string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return ;
            /* Chắc chắn rằng tồn tại lớp có tên là "strLayerName" trong bản đồ "map" */
            if (map.Layers[strLayerName] == null)
                return ;
            ////TachThua.FeatureTools breakFeature = new FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc;
            irfc = this.SelectFeatures(map, strLayerName);
            /* Chắc chắn rằng tồn tại Feature trong FeatureCollection */
            if (irfc == null)
                return;
            foreach (MapInfo.Data.Feature f in irfc)
            {
                if ( f.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon)
                {
                    MapInfo.Geometry.MultiPolygon multiPolygon = (MapInfo.Geometry.MultiPolygon)f.Geometry;
                    foreach (MapInfo.Geometry.Polygon polygon in multiPolygon)
                    {
                        PolygonToLines(map, polygon, strLayerName);
                    }
                    /* Xóa Feature sau khi đã Break */
                    //TachThua.FeatureTools delete = new FeatureTools();
                    this.DeleteFeature(map, f, strLayerName);
                }
                else if ( f.Geometry.Type == MapInfo.Geometry.GeometryType.MultiCurve)
                {
                    MapInfo.Geometry.MultiCurve  multiCurve = (MapInfo.Geometry.MultiCurve)f.Geometry;
                    foreach (MapInfo.Geometry.Curve  curve in multiCurve )
                    {
                        MapInfo.Geometry.DPoint[] dPoints;
                        dPoints = curve.SamplePoints();
                        MultiPointToLines(map, strLayerName, dPoints);
                    }
                    /* Xóa Feature sau khi đã Break */
                    //TachThua.FeatureTools delete = new FeatureTools();
                    this.DeleteFeature(map, f, strLayerName);
                }
            }
        }

        public void BreakAllFeaturesInLayer(MapInfo.Mapping.Map map, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là "strLayerName" trong bản đồ "map" */
            if (map.Layers[strLayerName] == null)
                return;
            DMC.GIS.Common.SearchTools searchTools = new SearchTools();
            MapInfo.Data.IResultSetFeatureCollection irfc;
            irfc = searchTools.SearchAll(map, strLayerName);
            /* Chắc chắn rằng tồn tại Feature trong FeatureCollection */
            if (irfc == null)
                return;
            foreach (MapInfo.Data.Feature f in irfc)
            {
                if (f.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon)
                {
                    MapInfo.Geometry.MultiPolygon multiPolygon = (MapInfo.Geometry.MultiPolygon)f.Geometry;
                    foreach (MapInfo.Geometry.Polygon polygon in multiPolygon)
                    {
                        PolygonToLines(map, polygon, strLayerName);
                    }
                    /* Xóa Feature sau khi đã Break */
                    ////TachThua.FeatureTools delete = new FeatureTools();
                    this.DeleteFeature(map, f, strLayerName);
                }
                else if (f.Geometry.Type == MapInfo.Geometry.GeometryType.MultiCurve)
                {
                    MapInfo.Geometry.MultiCurve multiCurve = (MapInfo.Geometry.MultiCurve)f.Geometry;
                    foreach (MapInfo.Geometry.Curve curve in multiCurve)
                    {
                        MapInfo.Geometry.DPoint[] dPoints;
                        dPoints = curve.SamplePoints();
                        MultiPointToLines(map, strLayerName, dPoints);
                    }
                    /* Xóa Feature sau khi đã Break */
                    ////TachThua.FeatureTools delete = new FeatureTools();
                    this.DeleteFeature(map, f, strLayerName);
                }
            }
        }


        public  bool  MultiPointToLines (MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint[] dPoints )
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return false;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName trong đối tượng bản đồ map */
            if (map.Layers[strLayerName] == null)
                return false;
            /* Chắc chắn rằng tồn tại danh sách điểm */
            if (dPoints == null)
                return false;
            /* Chắc chắn rằng danh sách điểm có số phần tử lớn hơn 1 */
            if (dPoints.Length <= 1)
                return false;
            /* Khai báo và khởi tạo biến tạm kiểu điểm */
            MapInfo.Geometry.DPoint[] dPointTemp = new MapInfo.Geometry.DPoint[2];
            for (int i = 0; i < dPoints.Length - 1; i++)
            {
                dPointTemp[0] = dPoints[i];
                dPointTemp[1] = dPoints[i + 1];
                /* Tạo Line */
                CreatePolyline(map,  strLayerName,dPointTemp);
            }
            return true;
        }
        /// <summary>
        /// Nhận tất cả  các Feature đang được Select trên một lớp có tên là strLayerName
        /// </summary>
        /// <param name="map"></param>
        /// <param name="strLayerName"></param>
        /// <returns></returns>
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
            MapInfo.Data.IResultSetFeatureCollection irfc = session.Selections.DefaultSelection[table];
            return irfc;
        }
        /// <summary>
        /// Gộp các Feature đang được select trên lớp có tên là strLayerName
        /// </summary>
        /// <param name="map"></param>
        /// <param name="strLayerName"></param>
        /// <returns></returns>
        public  bool CombineFeatures(MapInfo.Mapping.Map map, string strLayerName)
        {
            try
            {
                /* Chắc chắn rằng tồn tại đối tượng bản đồ */
                if (map == null)
                    return false;
                /* Khai báo lớp có các Features muốn combine */
                MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
                /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
                if (featureLayer == null)
                    return false;
                /* Khai báo bảng tương ứng với lớp muốn combine */
                MapInfo.Data.Table table = featureLayer.Table;
                MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
                /* Gắn giá trị mặc định cho Feature */
                MapInfo.Data.Feature feature = null;
                /* Khai báo và khởi tạo lớp FeatureTools có chứa hàm trả về tập hợp các đối tượng được Select */
                ////TachThua.FeatureTools featureTool = new FeatureTools();
                /* Khai báo tập hợp các Feature được Select */
                MapInfo.Data.IResultSetFeatureCollection irfc;
                /* Gán giá trị cho biến tập hợp */
                irfc = this.SelectFeatures(map, strLayerName);
                /* Chắc chắn rằng có từ 2 đối tượng được chọn để Combine */
                if (irfc == null)
                    return false;
                if (irfc.Count <= 1)
                    return false;
                /* Chắc chắn rằng những đối tượng cần gộp phải có cùng kiểu */
                foreach (MapInfo.Data.Feature f in irfc)
                {
                    if (irfc[0].Geometry.TypeName != f.Geometry.TypeName)
                        return false;
                }
                /* Chỉ combine các features trong cùng một lớp có tên là strLayerName */
                if (irfc.BaseTable.Alias == featureLayer.Table.Alias)
                {
                    /* Tạo Feature từ tập hợp các Feature vừa chọn để combine */
                    feature = featureProcessor.Combine(irfc);

                }
                /* Add Feature vừa tạo vào lớp có tên là strLayerName */
                table.InsertFeature(feature);

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
                System.Windows.Forms.MessageBox.Show("Không thể gộp được đối tượng!" + System.Environment.NewLine + "Cần kiểm tra lại thao tác vẽ đối tượng","DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool CombineAllFeaturesInLayer(MapInfo.Mapping.Map map, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return false;
            /* Khai báo lớp có các Features muốn combine */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
            if (featureLayer == null)
                return false;
            /* Khai báo bảng tương ứng với lớp muốn combine */
            MapInfo.Data.Table table = featureLayer.Table;
            MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
            /* Gắn giá trị mặc định cho Feature */
            MapInfo.Data.Feature feature = null;
            /* Khai báo và khởi tạo lớp SearchTools có chứa hàm trả về tập hợp toàn bộ các đối tượng được trong lớp */
            DMC.GIS.Common.SearchTools  searchTools =  new SearchTools();
            /* Khai báo tập hợp các Feature được Select */
            MapInfo.Data.IResultSetFeatureCollection irfc;
            /* Gán giá trị cho biến tập hợp */
            irfc = searchTools.SearchAll(map, strLayerName);
            /* Chắc chắn rằng có từ 2 đối tượng được chọn để Combine */
            if (irfc == null)
                return false;
            if (irfc.Count <= 1)
                return false;
            /* Chắc chắn rằng những đối tượng cần gộp phải có cùng kiểu */
            foreach (MapInfo.Data.Feature f in irfc)
            {
                if (irfc[0].Geometry.TypeName != f.Geometry.TypeName)
                    return false;
            }
            /* Chỉ combine các features trong cùng một lớp có tên là strLayerName */
            if (irfc.BaseTable.Alias == featureLayer.Table.Alias)
            {
                /* Tạo Feature từ tập hợp các Feature vừa chọn để combine */
                feature = featureProcessor.Combine(irfc);
            }
            /* Add Feature vừa tạo vào lớp có tên là strLayerName */
            table.InsertFeature(feature);

            /* Test */
            foreach (MapInfo.Data.Feature f in irfc)
            {
                /* Xóa Feature*/
                table.DeleteFeature(f);
            }
            /* EndTest */

            return true;
        }



        /// <summary>
        /// Lây giao của các đối tượng đang được lựa chọn trên một lớp
        /// </summary>
        /// <param name="map"></param>
        /// <param name="strLayerName"></param>
        /// <returns></returns>
        public  bool IntersectFeatures(MapInfo.Mapping.Map map, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return false;
            /* Khai báo lớp có các Features muốn Intersect */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
            if (featureLayer == null)
                return false;
            /* Khai báo bảng tương ứng với lớp muốn Intersect */
            MapInfo.Data.Table table = featureLayer.Table;
            MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
            /* Gắn giá trị mặc định cho Feature */
            MapInfo.Data.Feature feature = null;
            /* Khai báo và khởi tạo lớp FeatureTools có chứa hàm trả về tập hợp các đối tượng được Select */
            ////TachThua.FeatureTools featureTool = new FeatureTools();
            /* Khai báo tập hợp các Feature được Select */
            MapInfo.Data.IResultSetFeatureCollection irfc ;
            /* Gán giá trị cho biến tập hợp */
            irfc = this.SelectFeatures(map, strLayerName);
            /* Chắc chắn rằng có từ 2 đối tượng được chọn để Intersect */
            if (irfc == null)
                return false;
            if (irfc.Count <= 1)
                return false;
            /* Chỉ combine các features trong cùng một lớp có tên là strLayerName */
            if (irfc.BaseTable.Alias == featureLayer.Table.Alias)
            {
                /* Tạo Feature từ tập hợp các Feature vừa chọn để Intersect */
                feature = featureProcessor.Intersect(irfc);
            }
            /* Add Feature vừa tạo vào lớp có tên là strLayerName */
            table.InsertFeature(feature);


            return true;


            //MapInfo.FeatureProcessing.FeatureProcessor fp = new MapInfo.FeatureProcessing.FeatureProcessor();
            //MapInfo.Data.Columns newCols = new MapInfo.Data.Columns();
            ////newCols.Add(new Column("continent", "continent"));
            ////newCols.Add(new Column("Cap_Pop", "Sum(Cap_Pop)"));
            //MapInfo.Data.FeatureCollection fc = fp.Intersect("continent", tableWorldCap, newCols);


        }

        /// <summary>
        /// Lây giao của toàn bộ các đối tượng trên một lớp
        /// </summary>
        /// <param name="map"></param>
        /// <param name="strLayerName"></param>
        /// <returns></returns>
        public bool IntersectInLayer(MapInfo.Mapping.Map map, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return false;
            /* Khai báo lớp có các Features muốn Intersect */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
            if (featureLayer == null)
                return false;
            /* Khai báo bảng tương ứng với lớp muốn Intersect */
            MapInfo.Data.Table table = featureLayer.Table;
            MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
            /* Gắn giá trị mặc định cho Feature */
            MapInfo.Data.Feature feature = null;
            /* Khai báo và khởi tạo lớp FeatureTools có chứa hàm trả về tập hợp các đối tượng được Select */
            ////TachThua.FeatureTools featureTool = new FeatureTools();
            /* Lựa chọn tất cả các đối tượng trên lớp */
            MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchAll();
            MapInfo.Data.IResultSetFeatureCollection irfc = MapInfo.Engine.Session.Current.Catalog.Search(strLayerName, si);
            /* Chắc chắn rằng có từ 2 đối tượng được chọn để Intersect */
            if (irfc == null)
                return false;
            if (irfc.Count <= 1)
                return false;
            /* Chỉ combine các features trong cùng một lớp có tên là strLayerName */
            if (irfc.BaseTable.Alias == featureLayer.Table.Alias)
            {
                /* Tạo Feature từ tập hợp các Feature vừa chọn để Intersect */
                feature = featureProcessor.Intersect(irfc);
            }
            /* Add Feature vừa tạo vào lớp có tên là strLayerName */
            table.InsertFeature(feature);
            return true;
        }


        //public bool IntersectFeatureWithFeatureCollection(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Data.Feature feature, MapInfo.Data.IResultSetFeatureCollection irfc)
        //{
        //    /* Chắc chắn rằng tồn tại đối tượng bản đồ */
        //    if (map == null)
        //        return false;

        //    /* Khai báo lớp có các Features muốn combine */
        //    MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
        //    /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
        //    if (featureLayer == null)
        //        return false;

        //    /* Khai báo bảng tương ứng với lớp muốn combine */
        //    MapInfo.Data.Table table = featureLayer.Table;
        //    MapInfo.FeatureProcessing.FeatureProcessor featureProcessor = new MapInfo.FeatureProcessing.FeatureProcessor();
        //    /* Gắn giá trị mặc định cho Feature */
        //    MapInfo.Data.Feature feature = null;
        //    /* Khai báo và khởi tạo lớp FeatureTools có chứa hàm trả về tập hợp các đối tượng được Select */
        //    TachThua.FeatureTools featureTool = new FeatureTools();
        //    /* Khai báo tập hợp các Feature được Select */
        //    MapInfo.Data.IResultSetFeatureCollection irfc;
        //    /* Gán giá trị cho biến tập hợp */
        //    irfc = featureTool.SelectFeatures(map, strLayerName);
        //    /* Chắc chắn rằng có từ 2 đối tượng được chọn để Combine */
        //    if (irfc == null)
        //        return false;
        //    if (irfc.Count <= 1)
        //        return false;
        //    /* Chỉ combine các features trong cùng một lớp có tên là strLayerName */
        //    if (irfc.BaseTable.Alias == featureLayer.Table.Alias)
        //    {
        //        /* Tạo Feature từ tập hợp các Feature vừa chọn để combine */
        //        feature = featureProcessor.Intersect(irfc);
        //    }
        //    /* Add Feature vừa tạo vào lớp có tên là strLayerName */
        //    table.InsertFeature(feature);
        //    return true;
        //}

        /// <summary>
        /// Source này download trên mạng. Nói về việc tạo một Rectangle trên lớp.
        /// Mục đích: Tham khảo cách tạo các trường thuộc tính của đối tượng đồ họa
        /// và cách thiết lập hệ tọa độ cho đối tượng cần thêm vào lớp.
        /// </summary>
        /// <param name="dPoints"></param>
        /// <param name="map"></param>
        private void AddRectangleToMap(MapInfo.Geometry.DPoint[] dPoints, MapInfo.Mapping.Map map )
        {
            MapInfo.Geometry.DRect dRect; MapInfo.Geometry.Rectangle newRect;
            MapInfo.Styles.SimpleLineStyle simLineStyle;

            MapInfo.Styles.SimpleInterior simInterior;
            MapInfo.Styles.AreaStyle rectAreaStyle; MapInfo.Styles.CompositeStyle rectCompositeStyle;
            MapInfo.Data.MIConnection miConn;

            MapInfo.Data.TableInfoMemTable ti;
            MapInfo.Data.Column col1 = default(MapInfo.Data.Column); MapInfo.Geometry.CoordSysFactory miCF;
            MapInfo.Geometry.CoordSysFactory miCSF;

            string mbCoordSys = string.Empty;
            MapInfo.Data.Key k;

            MapInfo.Geometry.CoordSys LongLatCSys;

            // Clear the previous selection if any
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();

            try
            {
                dRect = new MapInfo.Geometry.DRect(dPoints[0].y, dPoints[0].x, dPoints[0].y, dPoints[0].x);

                miCF = MapInfo.Engine.Session.Current.CoordSysFactory;
                LongLatCSys = miCF.CreateLongLat(MapInfo.Geometry.DatumID.WGS84);

                newRect = new MapInfo.Geometry.Rectangle(LongLatCSys, dRect);
                double totalArea = newRect.Area(MapInfo.Geometry.AreaUnit.SquareMile);

                // sets the style and color to the line drawn
                simLineStyle = new MapInfo.Styles.SimpleLineStyle(new MapInfo.Styles.LineWidth(3, MapInfo.Styles.LineWidthUnit.Pixel), 2, System.Drawing.Color.Red, false);

                simInterior = new MapInfo.Styles.SimpleInterior(0, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, true);
                rectAreaStyle =  new MapInfo.Styles.AreaStyle(simLineStyle, simInterior);

                rectCompositeStyle = new MapInfo.Styles.CompositeStyle(rectAreaStyle); 
                MapInfo.Data.Feature  selectFeature = new MapInfo.Data.Feature(newRect, rectCompositeStyle);

                // Creates new MIConnection
                miConn = new MapInfo.Data.MIConnection();

                miConn.Open();
                MapInfo.Data.Table  oSelection = miConn.Catalog.GetTable("temp"); if (oSelection != null)
                {
                    oSelection.Close();
                }

                ti = new MapInfo.Data.TableInfoMemTable("temp"); col1 = MapInfo.Data.ColumnFactory.CreateStringColumn("Name", 30);
                col1.Indexed = true;

                ti.Columns.Add(col1);
                ti.Columns.Add(MapInfo.Data.ColumnFactory.CreateStyleColumn());

                // sets the co-ordinate system of the map.
                MapInfo.Geometry.CoordSys LatLongCSys = default(MapInfo.Geometry.CoordSys);

                miCSF = new MapInfo.Geometry.CoordSysFactory(); mbCoordSys = "CoordSys Earth Projection 1, 74";

                LatLongCSys = miCSF.CreateFromMapBasicString(mbCoordSys);
                ti.Columns.Add(MapInfo.Data.ColumnFactory.CreateFeatureGeometryColumn(LatLongCSys));

                oSelection = miConn.Catalog.CreateTable(ti);

                // Inserts the SelectedFeature into oSelection

                k = oSelection.InsertFeature(selectFeature);

                // Loads the seletion into map
                map.Load(new MapInfo.Mapping.MapTableLoader(oSelection));

            }
            catch (Exception)
            {
                throw;
            }

        }


        //if (mapControl1.Map.Layers["Thửa đất"] == null)
        //    return;
        //if (mapControl1.Map.Layers["Thửa đất"].Enabled == true)
        //{
        //    /* Khai báo đối tượng dạng tọa độ điểm của bản đồ */
        //    MapInfo.Geometry.DPoint pointMap;
        //    /* Chuyển tọa độ màn hình về tọa độ bản đồ */
        //    TachThua.MapTools convertDisplayPoint = new MapTools();
        //    pointMap = convertDisplayPoint.ConvertDisplayPointToMapPoint(mapControl1.Map, e.X, e.Y);
        //    /* Khai báo biến tập các Feature tìm được.
        //     Trong trường hợp tìm theo vị trí */
        //    MapInfo.Data.IResultSetFeatureCollection irfc;
        //    /* Gán giá trị cho biến tập các Feature tìm được */
        //    TachThua.SearchTools search = new SearchTools();

        //    irfc = search.searchWithPosition(mapControl1.Map, "Thửa đất", "Thửa đất", pointMap);

        //    if (irfc == null)
        //        return;
        //    //contextMenuTachThua.Show(this.mapControl1 , e.Location);
        //    TachThua.FeatureTools breakFeature = new FeatureTools();
        //    breakFeature.BreakFeatureCollectionInLayer(mapControl1.Map, irfc, "Thửa đất");
        //}

        internal MapInfo.Geometry.DPoint[] VertexPoints(MapInfo.Geometry.DPoint[] polygonLandPlot)
        {
            try
            {
                return polygonLandPlot;
            }catch(Exception ex ){}
            return polygonLandPlot;
        }
    }
}
