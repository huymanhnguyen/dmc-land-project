using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public  class WallBorderlines
    {

        /// <summary>
        /// Tạo bao vùng cho đối tượng theo Buffer
        /// </summary>
        /// <param name="map">Tên bản đồ chứa lớp có Feature cần tạo bao tường</param>
        /// <param name="strLayerName">Tên lớp chứa Feature cần tạo bao vùng</param>
        /// <param name="dblDistance">Khoảng cách từ vùng bao đến đối tượng Feature cần tạo bao vùng</param>
        public void CreateWallBorderlineWithBuffer(MapInfo.Mapping.Map map, string strLayerName, double dblDistance)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là "strLayerName" trong bản đồ "map" */
            if (map.Layers[strLayerName] == null)
                return;
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc;
            irfc = featureTools.SelectFeatures(map, strLayerName);
            /* Chắc chắn rằng tồn tại Feature trong FeatureCollection */
            if (irfc == null)
                return;

            if (dblDistance == 0.00)
                return;
            foreach (MapInfo.Data.Feature f in irfc)
            {
                if (f.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon)
                {

                    /* Khai báo Buffer Feature */
                    MapInfo.Data.Feature featureBuffer;
                    /* Xác nhận Buffer của Feature */
                    featureBuffer = featureTools.Buffer(f, dblDistance);
                    /* Chuyển Buffer về đối tượng kiểu multiPolygon */
                    MapInfo.Geometry.MultiPolygon multiPolygonBuffer = (MapInfo.Geometry.MultiPolygon)featureBuffer.Geometry;
                    /* Xác nhận danh sách tọa độ các đỉnh  mỗi Polygon trong multiPolygon.
                     * Sau đó vẽ Polyline từ các đỉnh xác định được */
                    foreach (MapInfo.Geometry.Polygon polygonBuffer in multiPolygonBuffer)
                    {
                        MapInfo.Geometry.DPoint[] dPointBuffer;
                        dPointBuffer = polygonBuffer.Exterior.SamplePoints();
                        /* Vẽ bao tường */
                        featureTools.CreatePolyline(map, strLayerName, dPointBuffer, this.LineStyle());
                    }
                }
            }
        }


        /// <summary>
        /// Tạo bao vùng cho đối tượng 
        /// </summary>
        /// <param name="map">Tên bản đồ chứa lớp có Feature cần tạo bao tường</param>
        /// <param name="strLayerName">Tên lớp chứa Feature cần tạo bao vùng</param>
        /// <param name="dblDistance">Khoảng cách từ vùng bao đến đối tượng Feature cần tạo bao vùng</param>
        public void CreateWallBorderline(MapInfo.Mapping.Map map, string strLayerName, double dblDistance)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là "strLayerName" trong bản đồ "map" */
            if (map.Layers[strLayerName] == null)
                return;
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc;
            irfc = featureTools.SelectFeatures(map, strLayerName);
            /* Chắc chắn rằng tồn tại Feature trong FeatureCollection */
            if (irfc == null)
                return;

            if (dblDistance == 0.00)
                return;
            foreach (MapInfo.Data.Feature f in irfc)
            {
                if (f.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon)
                {
                    MapInfo.Geometry.MultiPolygon multiPolygon = (MapInfo.Geometry.MultiPolygon)f.Geometry;
                    foreach (MapInfo.Geometry.Polygon polygon in multiPolygon)
                    {
                        /* XÁC ĐỊNH DANH SÁCH TỌA ĐỘ GÓC TƯỜNG */
                        /* Khai báo và gán  giá trị cho biến chứa tọa độ danh sách các góc tường */
                        MapInfo.Geometry.DPoint[] dPointWallCornerPoints;
                        dPointWallCornerPoints = this.WallCornerPoints(polygon, dblDistance);
                        /* Khai báo và gán giá trị cho biến chứa danh sách tọa độ các góc tường bao
                         * bao gồm cả tọa độ cuối cùng trùng với tọa độ điểm đầu để có thể tạo thành
                         * đường khép kín*/
                        MapInfo.Geometry.DPoint[] dPointWallCornerPoints2 = new MapInfo.Geometry.DPoint[dPointWallCornerPoints.Length + 1 ] ;
                        for (int i = 0; i <= dPointWallCornerPoints.Length; i++)
                        {
                            if (i < dPointWallCornerPoints.Length)
                            {
                                dPointWallCornerPoints2[i] = dPointWallCornerPoints[i];
                            }
                            else
                            {
                                dPointWallCornerPoints2[i] = dPointWallCornerPoints[0];
                            }
                        }
                        /* Vẽ bao tường */
                        featureTools.CreatePolyline(map, strLayerName, dPointWallCornerPoints2  ,this.LineStyle());

                        
                        }
                    //tao duong bao trong cua thua bi khoet
                    foreach (MapInfo.Geometry.Polygon pl in multiPolygon)
                    {
                        DMC.GIS.Common.WallBorderlines WallBorderlines = new DMC.GIS.Common.WallBorderlines();
                        if (pl.InteriorCount > 0)
                        {
                            for (int k = 0; k < pl.InteriorCount; k++)
                            {
                                MapInfo.Geometry.DPoint[] dTrong = pl.Interior(k).SamplePoints();

                                MapInfo.Geometry.MultiPolygon multipoly = new MapInfo.Geometry.MultiPolygon(map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, dTrong);
                                MapInfo.Data.Table table = null;
                                table = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerName);
                                 MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();
                                 MapInfo.Data.Feature fff = null;
                                 fff = new MapInfo.Data.Feature(multipoly, cs);
                                //tạo mới đối tượng
                                f.Geometry = fff.Geometry;
                                f.Style = cs;
                                MapInfo.Data.Key key =  table.InsertFeature(fff);
                                MapInfo.Data.IResultSetFeatureCollection fLine = MapInfo.Engine.Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("MI_Key ='" + key + "'"));
                                foreach (MapInfo.Data.Feature myFeature in fLine)
                                {
                                    if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon")) {
                                        MapInfo.Geometry.MultiPolygon MymultiPolygon = (MapInfo.Geometry.MultiPolygon)myFeature.Geometry;
                                        foreach (MapInfo.Geometry.Polygon poly in MymultiPolygon)
                                       { 
                                       
                                    
                                MapInfo.Geometry.DPoint[] dPointWallCornerPoints = this.WallCornerPoints_Tmp(poly, dblDistance);
                                /* Khai báo và gán giá trị cho biến chứa danh sách tọa độ các góc tường bao
                                 * bao gồm cả tọa độ cuối cùng trùng với tọa độ điểm đầu để có thể tạo thành
                                 * đường khép kín*/
                                MapInfo.Geometry.DPoint[] dPointWallCornerPoints2 = new MapInfo.Geometry.DPoint[dPointWallCornerPoints.Length + 1];
                                for (int i = 0; i <= dPointWallCornerPoints.Length; i++)
                                {
                                    if (i < dPointWallCornerPoints.Length)
                                    {
                                        dPointWallCornerPoints2[i] = dPointWallCornerPoints[i];
                                    }
                                    else
                                    {
                                        dPointWallCornerPoints2[i] = dPointWallCornerPoints[0];
                                    }
                                }
                                /* Vẽ bao tường */
                                featureTools.CreatePolyline(map, strLayerName, dPointWallCornerPoints2, this.LineStyle());
                                       }
                                    }
                                   
                                }
                                table.DeleteFeature(key);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tạo bao vùng cho đối tượng 
        /// </summary>
        /// <param name="map">Tên bản đồ chứa lớp có Feature cần tạo bao tường</param>
        /// <param name="strLayerName">Tên lớp chứa Feature cần tạo bao vùng</param>
        /// <param name="dblDistance">Khoảng cách từ vùng bao đến đối tượng Feature cần tạo bao vùng</param>
        /// <param name="strObjectGroupField">Tên trường xác định nhóm đối tượng</param>
        /// <param name="strObjectGroupValue">Giá trị xác định nhóm đối tượng</param>
        public void CreateWallBorderline(MapInfo.Mapping.Map map, string strLayerName, double dblDistance, string strObjectGroupField, string strObjectGroupValue)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là "strLayerName" trong bản đồ "map" */
            if (map.Layers[strLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại tên Trường xác định nhóm đối tượng */
            if (strObjectGroupField.Trim() == "")
                return;
            /* Chắc chắn rằng tồn tại giá trị trường xác định nhóm đối tượng */
            if (strObjectGroupValue.Trim() == "")
                return;
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc;
            irfc = featureTools.SelectFeatures(map, strLayerName);
            /* Chắc chắn rằng tồn tại Feature trong FeatureCollection */
            if (irfc == null)
                return;

            if (dblDistance == 0.00)
                return;
            foreach (MapInfo.Data.Feature f in irfc)
            {
                if (f.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon)
                {
                    MapInfo.Geometry.MultiPolygon multiPolygon = (MapInfo.Geometry.MultiPolygon)f.Geometry;
                    foreach (MapInfo.Geometry.Polygon polygon in multiPolygon)
                    {
                        /* XÁC ĐỊNH DANH SÁCH TỌA ĐỘ GÓC TƯỜNG */
                        /* Khai báo và gán  giá trị cho biến chứa tọa độ danh sách các góc tường */
                        MapInfo.Geometry.DPoint[] dPointWallCornerPoints;
                        dPointWallCornerPoints = this.WallCornerPoints(polygon, dblDistance);
                        /* Khai báo và gán giá trị cho biến chứa danh sách tọa độ các góc tường bao
                         * bao gồm cả tọa độ cuối cùng trùng với tọa độ điểm đầu để có thể tạo thành
                         * đường khép kín*/
                        MapInfo.Geometry.DPoint[] dPointWallCornerPoints2 = new MapInfo.Geometry.DPoint[dPointWallCornerPoints.Length + 1];
                        for (int i = 0; i <= dPointWallCornerPoints.Length; i++)
                        {
                            if (i < dPointWallCornerPoints.Length)
                            {
                                dPointWallCornerPoints2[i] = dPointWallCornerPoints[i];
                            }
                            else
                            {
                                dPointWallCornerPoints2[i] = dPointWallCornerPoints[0];
                            }
                        }
                        /* Vẽ bao tường */
                        featureTools.CreatePolyline(map, strLayerName, dPointWallCornerPoints2, this.LineStyle(), strObjectGroupField, strObjectGroupValue);
                    }
                }
            }
        }


        #region Kiểu của tường bao 
        /// <summary>
        /// Kiểu của tường bao
        /// </summary>
        /// <returns></returns>
        private MapInfo.Styles.CompositeStyle LineStyle()
        {
            MapInfo.Styles.SimpleLineStyle bl = new MapInfo.Styles.SimpleLineStyle(new MapInfo.Styles.LineWidth(1, MapInfo.Styles.LineWidthUnit.Pixel), 6,System.Drawing.Color.Blue);
            MapInfo.Styles.CompositeStyle compositeStyle = new MapInfo.Styles.CompositeStyle(null, bl, null, null);
            return compositeStyle;
        }
        #endregion 

        #region Xác định danh sách tọa độ các góc tường
        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygonLandPlot"></param>
        /// <param name="dblDistance"></param>
        /// <returns></returns>
        public MapInfo.Geometry.DPoint[] WallCornerPoints(MapInfo.Geometry.Polygon polygonLandPlot, double dblDistance)
        {
            /* Khai báo danh sách góc thửa */
            MapInfo.Geometry.DPoint[] dPointLandPlotCornerPoints;
            /* Khai báo lớp chứa phương thức xác định danh sách các đỉnh của một thửa */
            DMC.GIS.Common.FeatureTools featureTools = new FeatureTools();
            dPointLandPlotCornerPoints = featureTools.VertexPoints(polygonLandPlot);
            /* Khai báo và gán giá trị cho biến danh sách điểm thứ 2 nằm trên đường
             * phân giác thứ hai của các góc thửa tương ứng */
            MapInfo.Geometry.DPoint[] dPointSecondBisectrixPoints;
            dPointSecondBisectrixPoints = this.SecondBisectrixPoints(polygonLandPlot);
            /* Khai báo số góc tường */
            int intWallCornerCounts = dPointSecondBisectrixPoints.Length;
            /* Khai báo biến trung gian tọa độ góc tường */
            MapInfo.Geometry.DPoint[] dPointWallCornerPoints = new MapInfo.Geometry.DPoint[intWallCornerCounts];
            /* Danh sách khoảng cách góc thửa và góc tường tương ứng */
            double[] dblLandPlotCornerToWallCornerDistanceList;
            double dblDistanceTmp;
            if (dblDistance >= 0)
            {
                dblDistanceTmp = dblDistance;
            }
            else
            {
                dblDistanceTmp = dblDistance * (-1);
            }
            dblLandPlotCornerToWallCornerDistanceList = this.LandPlotCornerToWallCornerDistanceList(dPointLandPlotCornerPoints, dblDistanceTmp);
            /* Xác định và gán giá trị cho danh sách tọa độ góc tường */
            for (int i = 0; i < intWallCornerCounts; i++)
            {
                /* Khai báo danh sách tọa độ chưa 2 điểm.
                 * Điểm thứ nhất là góc thửa, điểm thứ 2 là điểm thứ 2 nằm trên đường phân giác của góc thửa đó */
                MapInfo.Geometry.DPoint[] dPointStraights = new MapInfo.Geometry.DPoint[2];
                dPointStraights[0] = dPointLandPlotCornerPoints[i];
                dPointStraights[1] = dPointSecondBisectrixPoints[i];
                /* Tọa độ 2 điểm góc tường nghi vấn */
                MapInfo.Geometry.DPoint[] dPointSuspectPoints = new MapInfo.Geometry.DPoint[2];
                /* Khai báo tọa độ điểm góc tường xác định */
                MapInfo.Geometry.DPoint dPointWallCornerPoint = new MapInfo.Geometry.DPoint();
                /* Nếu khoảng cách đưa vào là dương thì ta nhận bao tường bên ngoài thửa */
                if ( dblDistance > 0 )
                {
                    dPointSuspectPoints = featureTools.ToaDoDiemChia2(dPointStraights, dblLandPlotCornerToWallCornerDistanceList[i]);
                    dPointWallCornerPoint = this.OutsidePoint(dPointSuspectPoints, polygonLandPlot);
                }
                else if (dblDistance < 0)  /* Nếu khoảng cách đưa vào là âm thì ta nhận bao tường bên trong thửa */
                {
                    dPointSuspectPoints = featureTools.ToaDoDiemChia2(dPointStraights, dblLandPlotCornerToWallCornerDistanceList[i]);
                    dPointWallCornerPoint = this.InsidePoint(dPointSuspectPoints, polygonLandPlot); 
                }
                /* Gán giá trị tọa độ cho danh sách tọa độ góc tường của góc thứ i */
                dPointWallCornerPoints[i] = dPointWallCornerPoint;
            }
            /* Trả về danh sách tọa độ góc tường cho hàm */
            return dPointWallCornerPoints;
        }
        public MapInfo.Geometry.DPoint[] WallCornerPoints_Tmp(MapInfo.Geometry.Polygon polygonLandPlot, double dblDistance)
        {
            /* Khai báo danh sách góc thửa */
            MapInfo.Geometry.DPoint[] dPointLandPlotCornerPoints;
            /* Khai báo lớp chứa phương thức xác định danh sách các đỉnh của một thửa */
            DMC.GIS.Common.FeatureTools featureTools = new FeatureTools();
            dPointLandPlotCornerPoints = featureTools.VertexPoints(polygonLandPlot);
            /* Khai báo và gán giá trị cho biến danh sách điểm thứ 2 nằm trên đường
             * phân giác thứ hai của các góc thửa tương ứng */
            MapInfo.Geometry.DPoint[] dPointSecondBisectrixPoints;
            dPointSecondBisectrixPoints = this.SecondBisectrixPoints_Tmp(polygonLandPlot);
            /* Khai báo số góc tường */
            int intWallCornerCounts = dPointSecondBisectrixPoints.Length;
            /* Khai báo biến trung gian tọa độ góc tường */
            MapInfo.Geometry.DPoint[] dPointWallCornerPoints = new MapInfo.Geometry.DPoint[intWallCornerCounts];
            /* Danh sách khoảng cách góc thửa và góc tường tương ứng */
            double[] dblLandPlotCornerToWallCornerDistanceList;
            double dblDistanceTmp;
            if (dblDistance >= 0)
            {
                dblDistanceTmp = dblDistance;
            }
            else
            {
                dblDistanceTmp = dblDistance * (-1);
            }
            dblLandPlotCornerToWallCornerDistanceList = this.LandPlotCornerToWallCornerDistanceList(dPointLandPlotCornerPoints, dblDistanceTmp);
            /* Xác định và gán giá trị cho danh sách tọa độ góc tường */
            for (int i = 0; i < intWallCornerCounts; i++)
            {
                /* Khai báo danh sách tọa độ chưa 2 điểm.
                 * Điểm thứ nhất là góc thửa, điểm thứ 2 là điểm thứ 2 nằm trên đường phân giác của góc thửa đó */
                MapInfo.Geometry.DPoint[] dPointStraights = new MapInfo.Geometry.DPoint[2];
                dPointStraights[0] = dPointLandPlotCornerPoints[i];
                dPointStraights[1] = dPointSecondBisectrixPoints[i];
                /* Tọa độ 2 điểm góc tường nghi vấn */
                MapInfo.Geometry.DPoint[] dPointSuspectPoints = new MapInfo.Geometry.DPoint[2];
                /* Khai báo tọa độ điểm góc tường xác định */
                MapInfo.Geometry.DPoint dPointWallCornerPoint = new MapInfo.Geometry.DPoint();
                /* Nếu khoảng cách đưa vào là dương thì ta nhận bao tường bên ngoài thửa */
                if (dblDistance < 0)
                {
                    dPointSuspectPoints = featureTools.ToaDoDiemChia2(dPointStraights, dblLandPlotCornerToWallCornerDistanceList[i]);
                    dPointWallCornerPoint = this.OutsidePoint(dPointSuspectPoints, polygonLandPlot);
                }
                else if (dblDistance > 0)  /* Nếu khoảng cách đưa vào là âm thì ta nhận bao tường bên trong thửa */
                {
                    dPointSuspectPoints = featureTools.ToaDoDiemChia2(dPointStraights, dblLandPlotCornerToWallCornerDistanceList[i]);
                    dPointWallCornerPoint = this.InsidePoint(dPointSuspectPoints, polygonLandPlot);
                }
                /* Gán giá trị tọa độ cho danh sách tọa độ góc tường của góc thứ i */
                dPointWallCornerPoints[i] = dPointWallCornerPoint;
            }
            /* Trả về danh sách tọa độ góc tường cho hàm */
            return dPointWallCornerPoints;
        }


        #endregion


        /// <summary>
        /// Danh sách tọa độ điểm thứ 2 nằm trên đường phân giác, tương ứng với từng góc thửa đất
        /// </summary>
        /// <param name="multiPolygonLandplot">Thông tin hình học thửa đất</param>
        /// <returns></returns>
        private MapInfo.Geometry.DPoint[] SecondBisectrixPoints(MapInfo.Geometry.Polygon polygonLandplot)
        {
            /* Chắc chắn rằng tồn tại thửa đất cần xác định tọa độ các góc tường */
            if (polygonLandplot == null)
                return null;
            /* Khai báo và gán giá trị cho biến chứa danh sách tọa độ góc thửa */
            MapInfo.Geometry.DPoint[] dPointLandPlotCorners;
            /* Khai báo lớp chứa phương thức xác định danh sách các đỉnh của một thửa */
            DMC.GIS.Common.FeatureTools featureTools = new FeatureTools();
            dPointLandPlotCorners = featureTools.VertexPoints(polygonLandplot);
            int intCounter = dPointLandPlotCorners.Length - 1;
            /* Khai báo biến trung gian chứa danh sách tọa độ điểm thứ hai nằm trên đường phân giác của góc thửa đất */
            MapInfo.Geometry.DPoint[] dPointSecondBisectrixPoinsTemp = new MapInfo.Geometry.DPoint[intCounter];
            for (int i = 0; i < intCounter  ; i++)
            {
                /* Khai báo và gán giá trị cho biến chứa tọa độ các điểm tạo nên một góc thửa */
                MapInfo.Geometry.DPoint[] dPointLandPlotCorner = new MapInfo.Geometry.DPoint[3] ;
                if (i < (intCounter - 1))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        dPointLandPlotCorner[j] = dPointLandPlotCorners[i + j];
                    }
                    /* Gán giá trị cho tọa độ điểm thứ hai nằm trên đường phân giác tương ứng với tọa độ góc thửa
                     * Trong trường hợp này tao phải dịch lên một chỉ số của tọa độ điểm thứ hai nằm trên đường phân giác
                     để tương ứng với góc thửa */
                    dPointSecondBisectrixPoinsTemp[i + 1] = this.dPointLandPlotCornersBisectrix(dPointLandPlotCorner);
                }
                /* Tọa độ điểm phân giác thứ hai tương ứng với tọa độ góc thửa có chỉ số là 0 */
                else if (i == (intCounter - 1 ))
                {
                    dPointLandPlotCorner[0] = dPointLandPlotCorners[i];
                    dPointLandPlotCorner[1] = dPointLandPlotCorners[i + 1];
                    dPointLandPlotCorner[2] = dPointLandPlotCorners[1];
                    /* Gán giá trị cho tọa độ điểm thứ hai nằm trên đường phân giác tương ứng với tọa độ góc thửa */
                    dPointSecondBisectrixPoinsTemp[0] = this.dPointLandPlotCornersBisectrix(dPointLandPlotCorner);
                }
            }
            return dPointSecondBisectrixPoinsTemp;
        }
        private MapInfo.Geometry.DPoint[] SecondBisectrixPoints_Tmp(MapInfo.Geometry.Polygon polygonLandplot)
        {
            /* Chắc chắn rằng tồn tại thửa đất cần xác định tọa độ các góc tường */
            if (polygonLandplot == null)
                return null;
            /* Khai báo và gán giá trị cho biến chứa danh sách tọa độ góc thửa */
            MapInfo.Geometry.DPoint[] dPointLandPlotCorners;
            /* Khai báo lớp chứa phương thức xác định danh sách các đỉnh của một thửa */
            DMC.GIS.Common.FeatureTools featureTools = new FeatureTools();
            dPointLandPlotCorners = featureTools.VertexPoints(polygonLandplot);
            int intCounter = dPointLandPlotCorners.Length - 1;
            /* Khai báo biến trung gian chứa danh sách tọa độ điểm thứ hai nằm trên đường phân giác của góc thửa đất */
            MapInfo.Geometry.DPoint[] dPointSecondBisectrixPoinsTemp = new MapInfo.Geometry.DPoint[intCounter];
            for (int i = 0; i < intCounter; i++)
            {
                /* Khai báo và gán giá trị cho biến chứa tọa độ các điểm tạo nên một góc thửa */
                MapInfo.Geometry.DPoint[] dPointLandPlotCorner = new MapInfo.Geometry.DPoint[3];
                if (i < (intCounter - 1))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        dPointLandPlotCorner[j] = dPointLandPlotCorners[i + j];
                    }
                    /* Gán giá trị cho tọa độ điểm thứ hai nằm trên đường phân giác tương ứng với tọa độ góc thửa
                     * Trong trường hợp này tao phải dịch lên một chỉ số của tọa độ điểm thứ hai nằm trên đường phân giác
                     để tương ứng với góc thửa */
                    dPointSecondBisectrixPoinsTemp[i + 1] = this.dPointLandPlotCornersBisectrix(dPointLandPlotCorner);
                }
                /* Tọa độ điểm phân giác thứ hai tương ứng với tọa độ góc thửa có chỉ số là 0 */
                else if (i == (intCounter - 1))
                {
                    dPointLandPlotCorner[0] = dPointLandPlotCorners[i];
                    dPointLandPlotCorner[1] = dPointLandPlotCorners[i + 1];
                    dPointLandPlotCorner[2] = dPointLandPlotCorners[1];
                    /* Gán giá trị cho tọa độ điểm thứ hai nằm trên đường phân giác tương ứng với tọa độ góc thửa */
                    dPointSecondBisectrixPoinsTemp[0] = this.dPointLandPlotCornersBisectrix(dPointLandPlotCorner);
                }
            }
            return dPointSecondBisectrixPoinsTemp;
        }
        /// <summary>
        /// XÁC ĐỊNH CHỈ SỐ CỦA ĐOẠN THẲNG CẠNH DÀI
        /// </summary>
        /// <param name="dpointLandPlotCorners">
        /// Biến chuyền vào là danh sách gồm 3 điểm (tạo thành một góc của thửa đất - 2 cạch của thửa đất )
        /// </param>
        /// <returns>Giá trị trả về sẽ là thứ tự của đoạn thẳng dài hơn:
        /// 1. Tương ứng với đoạn thẳng thứ nhất
        /// 2. Tương ứng với đoạn thẳng thứ hai
        /// </returns>
        private   int intIndexLongStraight(MapInfo.Geometry.DPoint[] dpointLandPlotCorners, ref decimal decSplitDistance )
        {
            /* Chắc chắn rằng danh sách điểm đưa vào gồm 3 điểm */
            if (dpointLandPlotCorners.Length != 3)
            {
                decSplitDistance = 0;
                return 0;
            }
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            /* Khai báo và khởi tạo biến tọa độ 2 điểm đầu cạnh thứ nhất */
            MapInfo.Geometry.DPoint[] dPointFirstStraight = new MapInfo.Geometry.DPoint[2];
            dPointFirstStraight[0] = dpointLandPlotCorners[0];
            dPointFirstStraight[1] = dpointLandPlotCorners[1];
            /* Khai báo và khở tạo biến độ dài đoạn thẳng thứ nhất */
            decimal decFirstStraightDistance = 0;
            decFirstStraightDistance = featureTools.DoDaiDoanThang(dPointFirstStraight);

            /* Khai báo và khởi tạo biến tọa độ 2 điểm đầu cạnh thứ hai */
            MapInfo.Geometry.DPoint[] dPointSecondStraight = new MapInfo.Geometry.DPoint[2];
            dPointSecondStraight[0] = dpointLandPlotCorners[1];
            dPointSecondStraight[1] = dpointLandPlotCorners[2];
            /* Khai báo và khở tạo biến độ dài đoạn thẳng thứ hai */
            decimal decSecondStraightDistance = 0;
            decSecondStraightDistance = featureTools.DoDaiDoanThang(dPointSecondStraight);
            /* So sách độ dài 2 đoạn thẳng để xác định đoạn thẳng dài hơn */
            if (decFirstStraightDistance > decSecondStraightDistance)
            {
                decSplitDistance = decSecondStraightDistance;
                return 1;
            }
            else
            {
                decSplitDistance = decFirstStraightDistance;
                return 2;
            }
        }

        private int intIndexLongStraight(MapInfo.Geometry.DPoint[] dpointLandPlotCorners)
        {
            /* Chắc chắn rằng danh sách điểm đưa vào gồm 3 điểm */
            if (dpointLandPlotCorners.Length != 3)
            {
                return 0;
            }
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            /* Khai báo và khởi tạo biến tọa độ 2 điểm đầu cạnh thứ nhất */
            MapInfo.Geometry.DPoint[] dPointFirstStraight = new MapInfo.Geometry.DPoint[2];
            dPointFirstStraight[0] = dpointLandPlotCorners[0];
            dPointFirstStraight[1] = dpointLandPlotCorners[1];
            /* Khai báo và khở tạo biến độ dài đoạn thẳng thứ nhất */
            decimal decFirstStraightDistance = 0;
            decFirstStraightDistance = featureTools.DoDaiDoanThang(dPointFirstStraight);

            /* Khai báo và khởi tạo biến tọa độ 2 điểm đầu cạnh thứ hai */
            MapInfo.Geometry.DPoint[] dPointSecondStraight = new MapInfo.Geometry.DPoint[2];
            dPointSecondStraight[0] = dpointLandPlotCorners[1];
            dPointSecondStraight[1] = dpointLandPlotCorners[2];
            /* Khai báo và khởI tạo biến độ dài đoạn thẳng thứ hai */
            decimal decSecondStraightDistance = 0;
            decSecondStraightDistance = featureTools.DoDaiDoanThang(dPointSecondStraight);
            /* So sách độ dài 2 đoạn thẳng để xác định đoạn thẳng dài hơn */
            if (decFirstStraightDistance > decSecondStraightDistance)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// Xác định TỌA ĐỘ ĐIỂM CHIA TRÊN CẠNH DÀI CỦA GÓC
        /// Sao cho khoảng cách từ vị trí đó tới góc thửa
        ///  bằng độ dài của cạnh ngắn
        /// </summary>
        /// <param name="dpointLandPlotCorners">Danh sách 3 điểm tọa thành góc thửa</param>
        /// <returns>Giá trị trả về là tọa độ của điểm chia</returns>
        private MapInfo.Geometry.DPoint SplitPoint(MapInfo.Geometry.DPoint[] dpointLandPlotCorners)
        {
            ///* Chắc chắn rằng tồn tại danh sách điểm tạo thành một góc thửa */
            //if (dpointLandPlotCorners == null)
            //    return null;
            ///* Chắc chắn rằng danh sách điểm đưa vào gồm 3 điểm */
            //if (dpointLandPlotCorners.Length != 3)
            //    return null;

            /* Khai báo lớp FeatureTools */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            /* Khai báo biến tạm chứa độ dài điểm chia */
            MapInfo.Geometry.DPoint dPointSplitTemp;
            /* Khai báo biến nhận độ dại của đoạn ngắn tọa thành góc thửa */
            decimal decShortStraightDistance = 0;
            /* Xác định chỉ số của đoạn dài */
            int i = 0;
            i = this.intIndexLongStraight(dpointLandPlotCorners,ref decShortStraightDistance);
            /* Khai báo biến nhận tọa độ 2 điểm của đoạn cần chia */
            MapInfo.Geometry.DPoint[] dPointSplit = new MapInfo.Geometry.DPoint[2];
            /* Nếu cạnh dài là đoạn đầu thì điểm đầu của đoạn là thứ 2 (Co chi so bang 1),
            điểm cuối của đoạn là điểm thứ nhất (Co chi so bang 0) của mảng dpointLandPlotCorners */
            if (i == 1)
            {
                dPointSplit[0] = dpointLandPlotCorners[i];
                dPointSplit[1] = dpointLandPlotCorners[i -1];
            }
            /* Nếu cạnh dài là đoạn thứ 2 thì điểm đầu của đoạn là thứ 2 (Co chi so la 1) ,
            điểm cuối của đoạn là điểm thứ ba (Co chi so la 2) của mảng dpointLandPlotCorners */
            else if (i == 2)
            {
                dPointSplit[0] = dpointLandPlotCorners[i - 1];
                dPointSplit[1] = dpointLandPlotCorners[i];
            }
            /* Xác nhận tọa độ điểm chia */
            //decShortStraightDistance = decShortStraightDistance ;// / 2; //TEST
            dPointSplitTemp = featureTools.ToaDoDiemChia(dPointSplit, Convert.ToDouble(decShortStraightDistance)); 
            return dPointSplitTemp ;
        }

        /// <summary>
        /// Xác định TỌA ĐỘ TRUNG ĐIỂM CỦA ĐOẠN THẲNG
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        private MapInfo.Geometry.DPoint MidllePoint(MapInfo.Geometry.DPoint startPoint, MapInfo.Geometry.DPoint endPoint)
        {
            /* Khai báo biến trung gian kiểu Point */
            MapInfo.Geometry.DPoint pointTemp = new MapInfo.Geometry.DPoint();
            /* Chắc chắn rằng tồn tại điểm đầu của đoạn thẳng */
            if (startPoint == null)
                return pointTemp ;
            /* Chắc chắn rằng tồn tại điểm cuối của đoạn thẳng */
            if (endPoint == null)
                return  pointTemp ;
            pointTemp.x = (startPoint.x  + endPoint.x) / 2;
            pointTemp.y  = (startPoint.y  + endPoint.y) / 2;
            return pointTemp;
        }

        /// <summary>
        /// Xác định ĐIỂM THỨ 2 NẰM TRÊN ĐƯỜNG PHÂN GIÁC GÓC THỬA
        /// (điểm thứ nhất chính là góc thửa)
        /// </summary>
        /// <param name="dpointLandPlotCorners">Danh sách tọa độ gồm 3 điểm tạo thành góc thửa</param>
        /// <returns>Giá trị trả về là điểm nằm trên đường phần giác góc thửa</returns>
        private MapInfo.Geometry.DPoint dPointLandPlotCornersBisectrix(MapInfo.Geometry.DPoint[] dpointLandPlotCorner)
        {
            /* Khai báo biến trung gian kiểu DPoint */
            MapInfo.Geometry.DPoint dPointTemp = new MapInfo.Geometry.DPoint();
            /* Khai báo tọa độ điểm thứ 2 của đoạn ngắn */
            MapInfo.Geometry.DPoint dPointShortStraightSecond = new MapInfo.Geometry.DPoint();
            /* Khai báo tọa độ của điểm chia */
            MapInfo.Geometry.DPoint dPointSplit = new MapInfo.Geometry.DPoint();
            /* Trường hợp 3 điểm thẳng hàng thì tọa độ điểm thứ 2 nằm trên đường phân giác ta lấy
             * đúng bằng tọa độ điểm giữa */
            if ((dpointLandPlotCorner[0].x == dpointLandPlotCorner[1].x) && (dpointLandPlotCorner[0].x == dpointLandPlotCorner[2].x))
            {
                dPointTemp.y  =  dpointLandPlotCorner[1].y ;
                dPointTemp.x = dpointLandPlotCorner[1].x + 1.0; /* + 1.0 là ta lấy một điểm bấy kỳ nằm trên đường phân giác*/
                return dPointTemp;
            }
            if ((dpointLandPlotCorner[0].y == dpointLandPlotCorner[1].y) && (dpointLandPlotCorner[0].y == dpointLandPlotCorner[2].y))
            {
                dPointTemp.x = dpointLandPlotCorner[1].x;
                dPointTemp.y  = dpointLandPlotCorner[1].y  + 1.0; /* + 1.0 là ta lấy một điểm bấy kỳ nằm trên đường phân giác*/
                return dPointTemp;
            }

            if (this.intIndexLongStraight(dpointLandPlotCorner) == 1)
            {
                dPointShortStraightSecond = dpointLandPlotCorner[2];
            }
            else if (this.intIndexLongStraight(dpointLandPlotCorner) == 2)
            {
                dPointShortStraightSecond = dpointLandPlotCorner[0];
            }
            dPointSplit = this.SplitPoint(dpointLandPlotCorner);
            /* Xác nhận tọa độ của điểm nằm trên đường phân giác */
            dPointTemp = this.MidllePoint(dPointShortStraightSecond, dPointSplit); 
            return dPointTemp;
        }

        #region Xác định số đo của một góc khi biết danh sách tọa độ 3 điểm tạo thành góc đó
        /// <summary>
        /// Trị đo của góc sẽ được dựa theo công thức: S= (1/2)*a*b*SinC = Căn bậc 2 của (p*(p-a)*(p-b)*(p-c))
        /// Trong đó: p là nửa chu vi của tam giác: p = (1/2)*(a+b+c)
        /// =>SinC = (2*S)/(a*b)
        /// =>C = arcSin[(2*S)/(a*b)]
        /// </summary>
        /// <param name="dPointTriangleCorners"></param>
        /// <returns>Giá trị trả về là trị đo của góc được tính theo Radian</returns>
        private   double AngleMeasuredValue(MapInfo.Geometry.DPoint[] dPointTriangleCorners)
        {
            /* Khai báo biến trung gian */
            double dblAngleMeasuredValueTemp = 0.0; 
            /* Khai báo biến độ dài các cạnh của tam giác (a, b, c), chu vi tam giác (p), và diện tích tam giác (S) */
            double a, b, c, p,S;
            /* Chắc chắn rằng tồn tại góc cần tính trị đo */
            if (dPointTriangleCorners == null)
                return 0.0;
            /* Chắc chắn rằng tham trị đưa vào có độ dài bằng 3 - tương ứng với 3 điểm tạo thành góc */
            if (dPointTriangleCorners.Length != 3)
                return 0.0;
            /* Khai báo lớp FeatureTools */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            /* Khai báo, khởi tạo và gắn giá trị cho tọa độ 2 điểm của cạnh thứ nhất */
            MapInfo.Geometry.DPoint[] dPointFirstStraight = new  MapInfo.Geometry.DPoint[2];
            dPointFirstStraight[0] = dPointTriangleCorners[0] ;
            dPointFirstStraight[1] = dPointTriangleCorners[1];
            /* Khai báo, khởi tạo và gắn giá trị cho tọa độ 2 điểm của cạnh thứ hai */
            MapInfo.Geometry.DPoint[] dPointSecondStraight = new MapInfo.Geometry.DPoint[2];
            dPointSecondStraight[0] = dPointTriangleCorners[1];
            dPointSecondStraight[1] = dPointTriangleCorners[2];
            /* Khai báo, khởi tạo và gắn giá trị cho tọa độ 2 điểm của cạnh thứ ba */
            MapInfo.Geometry.DPoint[] dPointThirdStraight = new MapInfo.Geometry.DPoint[2];
            dPointThirdStraight[0] = dPointTriangleCorners[0];
            dPointThirdStraight[1] = dPointTriangleCorners[2];
            /* Tính độ dài cạnh a */
            a = (double)featureTools.DoDaiDoanThang(dPointFirstStraight);
            /* Tính độ dài cạnh b */
            b = (double)featureTools.DoDaiDoanThang(dPointSecondStraight);
            /* Tính độ dài cạnh c */
            c = (double)featureTools.DoDaiDoanThang(dPointThirdStraight);
            /* Tính nửa chu vi của tam giác - p */
            p = (a + b + c)/2;
            /* Tính diện tích tam giác bằng công thức Herong */
            S = System.Math.Sqrt(p* (p - a)*(p - b)*(p - c));
            /* Nếu S = 0 => 3 điểm thẳng hàng */
            if (S == 0)
            {
                return System.Math.PI;
            }
            /* Xác định giá trị của Sin - (2*S)/(a*b) */
            double dblSinValue;
            dblSinValue = (2 * S) / (a * b);
            /* Chắc chắn rằng giá trị Sin của góc trong khoảng từ -1 đến 1 */
            if ((dblSinValue < -1) || (dblSinValue > 1))
            {
                //System.Windows.Forms.MessageBox.Show("Lỗi: " + System.Environment.NewLine + "Giá trị Sin phải trong khoảng từ -1 đến 1");
                //return dblAngleMeasuredValueTemp;
                /* CẦN KIỂM TRA LẠI */
                dblSinValue = 1.0;
            }
            /* Tính trị đo của góc bằng: ArcSin[(2*S)/(a*b)] */
            /* Ở đây có 2 trường hợp: Góc tù hoặc góc nhọn
             * Nếu góc là tù thì góc cần tìm sẽ bằng: (PI - ArcSinC)
             * Xác định góc tù  bằng việc sử dụng định lý Pitago:
             * Nếu cạnh c > cạnh góc vuông => góc C là tù */
            if (c <= System.Math.Sqrt(a * a + b * b))
            {
                dblAngleMeasuredValueTemp = System.Math.Asin(dblSinValue);
            }
            else
            {
                dblAngleMeasuredValueTemp = System.Math.PI -  System.Math.Asin(dblSinValue);
            }
            
            return dblAngleMeasuredValueTemp;
        }
        #endregion
        #region Khoảng cách từ điểm góc thửa đến điểm góc tường tương ứng. (Hai điểm này cùng nằm trên đường phân giác của góc thửa)
        /// <summary>
        /// Xác định khoảng cách giữa góc thửa và góc tường tương ứng
        /// Nó được xác định bằng: (Khoảng cách tường tới cạnh thửa)/Sin(Nửa trị đo của góc thửa) 
        /// </summary>
        /// <param name="dPointTriangleCorners">Tọa độ 2 điểm tạo thành góc thửa</param>
        /// <param name="dblWallToLandPlotEdgeDistance">Khoảng cách tường tới cạnh thửa đất</param>
        /// <returns></returns>
        private double LandPlotCornerToWallCornerDistance(MapInfo.Geometry.DPoint[] dPointTriangleCorners, double dblWallToLandPlotEdgeDistance)
        {
            /* Chắc chắn rằng khoảng cách từ tường tới cạnh thửa đất khác 0 */
            if (dblWallToLandPlotEdgeDistance == 0)
                return 0.0;
            /* Trị đo của góc thửa */
            double dblLandPlotMeasuredValue;
            dblLandPlotMeasuredValue = this.AngleMeasuredValue(dPointTriangleCorners);
            /* Khai báo biến trung gian */
            double dblLandPlotCornerToWallCornerDistance;
            dblLandPlotCornerToWallCornerDistance = dblWallToLandPlotEdgeDistance / System.Math.Sin(dblLandPlotMeasuredValue/2);  
            return dblLandPlotCornerToWallCornerDistance;
        }

        /// <summary>
        /// Danh sách khoảng cách góc thửa đến góc tường tương ứng
        /// </summary>
        /// <param name="dPointLandPlotCorners">Danh sách tọa độ các góc thửa</param>
        /// <param name="dblWallToLandPlotEdgeDistance">Khoảng cách từ cạnh thửa đến cạnh tường</param>
        /// <returns></returns>
        private double[]  LandPlotCornerToWallCornerDistanceList(MapInfo.Geometry.DPoint[] dPointLandPlotCorners , double  dblWallToLandPlotEdgeDistance)
        {
            /* Khai báo biến độ dài danh sách */
            int intCounter = dPointLandPlotCorners.Length - 1;
            /* Trừ 1 vì điểm góc thửa trùng toạ độ điểm cuối và điểm đầu */
            double[] dblLandPlotCornerToWallCornerDistanceList = new double[intCounter] ;
            /* Khai báo điểm góc thửa */
            MapInfo.Geometry.DPoint[] dPointTriangleCorners = new MapInfo.Geometry.DPoint[3];
            /* Khai báo biến khoảng cách từ góc tường tới góc thửa, cho một góc thửa */
            double dblLandPlotCornerToWallCornerDistance;

            for (int i = 0; i < intCounter; i++)
            {
                if (i == 0)
                {
                    dPointTriangleCorners[0] = dPointLandPlotCorners[1];
                    dPointTriangleCorners[1] = dPointLandPlotCorners[0];
                    dPointTriangleCorners[2] = dPointLandPlotCorners[intCounter -1];
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        dPointTriangleCorners[j] = dPointLandPlotCorners[i + j - 1];
                    }
                 }
                /* Gán giá trị khoảng cách từ góc thửa tới góc tường */
                /* Trong trường hợp này nếu 3 điểm thẳng hàng thì khoảng cách từ góc tường tới góc thửa
                 * chính bằng khoảng cách từ cạnh tường bao tới cạnh thửa đất */
                if ((dPointTriangleCorners[0].x == dPointTriangleCorners[1].x) && (dPointTriangleCorners[0].x == dPointTriangleCorners[2].x))
                {
                    dblLandPlotCornerToWallCornerDistance = dblWallToLandPlotEdgeDistance;
                }
                else if ((dPointTriangleCorners[0].y  == dPointTriangleCorners[1].y) && (dPointTriangleCorners[0].y == dPointTriangleCorners[2].y))
                {
                    dblLandPlotCornerToWallCornerDistance = dblWallToLandPlotEdgeDistance;
                }
                else
                {
                    dblLandPlotCornerToWallCornerDistance = this.LandPlotCornerToWallCornerDistance(dPointTriangleCorners, dblWallToLandPlotEdgeDistance);
                }
                /* Gán giá trị khoảng cách cho từng phân tử trong danh sách */
                dblLandPlotCornerToWallCornerDistanceList[i] = dblLandPlotCornerToWallCornerDistance;
            }
            return dblLandPlotCornerToWallCornerDistanceList;
        }
        #endregion

        #region Xác định một điểm nằm bên trong hay bên ngoài một vùng
        /* Thuật toán này được lấy từ địa chỉ:
         * http://local.wasp.uwa.edu.au/~pbourke/geometry/insidepoly/ */
        bool InsidePolygon(MapInfo.Geometry.Polygon  polygon, MapInfo.Geometry.DPoint dPoint)
        {
            int i;
            double angle = 0;
            MapInfo.Geometry.DPoint p1, p2;
            /* Khai báo danh sách điểm của Polygon */
            MapInfo.Geometry.DPoint[] dPointPolygonPoints;
            /* Khai báo lớp chứa phương thức xác định danh sách các đỉnh của một thửa */
            DMC.GIS.Common.FeatureTools featureTools = new FeatureTools();
            dPointPolygonPoints = featureTools.VertexPoints(polygon);
            /* Khai báo số đỉnh của Polygon */
            int n;
            n = dPointPolygonPoints.Length - 1; // -1 vì cách tính của Mapinfo thì điểm đầu và điểm cuối trùng nhau

            for (i = 0; i < n; i++)
            {
                p1.x = dPointPolygonPoints[i].x - dPoint.x;
                p1.y = dPointPolygonPoints[i].y - dPoint.y;
                p2.x = dPointPolygonPoints[(i + 1) % n].x - dPoint.x;
                p2.y = dPointPolygonPoints[(i + 1) % n].y - dPoint.y;
                angle += Angle2D(p1.x, p1.y, p2.x, p2.y);
            }

            if ( System.Math.Abs(angle) < System.Math.PI)
                return (false);
            else
                return (true);
        }

        /*
           Return the angle between two vectors on a plane
           The angle is from vector 1 to vector 2, positive anticlockwise
           The result is between -pi -> pi
        */
        double Angle2D(double x1, double y1, double x2, double y2)
        {
            double dtheta, theta1, theta2;

            theta1 = System.Math.Atan2(y1, x1);
            theta2 = System.Math.Atan2(y2, x2);
            dtheta = theta2 - theta1;
            while (dtheta > System.Math.PI)
                dtheta -= 2.0 * System.Math.PI;
            while (dtheta < - System.Math.PI)
                dtheta += 2.0 * System.Math.PI;
            return (dtheta);
        }

        /// <summary>
        /// Xác định điểm nằm trong vùng
        /// </summary>
        /// <param name="dPoints"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        private MapInfo.Geometry.DPoint InsidePoint(MapInfo.Geometry.DPoint[] dPoints, MapInfo.Geometry.Polygon polygon)
        {
            /* Khai báo biến trung gian */
            /* Dùng giá trị âm (-) để nhận biết vì trong tọa độ thực địa chính, không có giá trị âm */
            MapInfo.Geometry.DPoint dPointTemp = new MapInfo.Geometry.DPoint(-1, -1);
            /* */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools(); 
            /* Chắc chắn rằng tồn tại danh sách điểm cần xác định điểm bên trong vùng */
            if (dPoints == null)
            {
                return dPointTemp;
            }
            /* Chắc chắn rằng tồn tại vùng cần xét */
            if (polygon == null)
            {
                return dPointTemp;
            }
            /* Khai báo và gán giá trị cho tọa độ trung điểm của đoạn thẳng - điểm này chính là điểm góc thửa */
            MapInfo.Geometry.DPoint dPointMiddlePoint;
            dPointMiddlePoint.x = (dPoints[0].x + dPoints[1].x) / 2;
            dPointMiddlePoint.y = (dPoints[0].y + dPoints[1].y) / 2;
            /* Khai báo và gán giá trị cho danh sách tọa độ 2 điểm đầu của đoạn thẳng cận biên */
            MapInfo.Geometry.DPoint[] dPointMarginalStraights = new MapInfo.Geometry.DPoint[2] ;
            /* Điểm đầu là trung điểm - điểm góc thửa */
            dPointMarginalStraights[0] = dPointMiddlePoint;
            /* Điểm cuối là điểm dPoints[0] */
            dPointMarginalStraights[1] = dPoints[0] ;
            /* Khai báo và gán giá trị cho điểm lân cận trung điểm của đoạn thẳng về phía dPoints[0] */
            MapInfo.Geometry.DPoint dPointMarginal;
            dPointMarginal = featureTools.ToaDoDiemChia(dPointMarginalStraights, 0.01);

            if (this.InsidePolygon(polygon, dPointMarginal))//dPoints[0]))
            {
                dPointTemp = dPoints[0];
            }
            else
            {
                dPointTemp = dPoints[1];
            }
            /* Trả về điểm nằm trong vùng  cho hàm */
            return dPointTemp;
        }

        /// <summary>
        /// Xác định điểm nằm ngoài vùng
        /// </summary>
        /// <param name="dPoints"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        private MapInfo.Geometry.DPoint OutsidePoint(MapInfo.Geometry.DPoint[] dPoints, MapInfo.Geometry.Polygon polygon)
        {
            /* Khai báo biến trung gian */
            /* Dùng giá trị âm (-) để nhận biết vì trong tọa độ thực địa chính, không có giá trị âm */
            MapInfo.Geometry.DPoint dPointTemp = new MapInfo.Geometry.DPoint(-1, -1);
            /* */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools(); 
            /* Chắc chắn rằng tồn tại danh sách điểm cần xác định điểm bên trong vùng */
            if (dPoints == null)
            {
                return dPointTemp;
            }
            /* Chắc chắn rằng tồn tại vùng cần xét */
            if (polygon == null)
            {
                return dPointTemp;
            }
            /* Khai báo và gán giá trị cho tọa độ trung điểm của đoạn thẳng - điểm này chính là điểm góc thửa */
            MapInfo.Geometry.DPoint dPointMiddlePoint;
            dPointMiddlePoint.x = (dPoints[0].x + dPoints[1].x) / 2;
            dPointMiddlePoint.y = (dPoints[0].y + dPoints[1].y) / 2;
            /* Khai báo và gán giá trị cho danh sách tọa độ 2 điểm đầu của đoạn thẳng cận biên */
            MapInfo.Geometry.DPoint[] dPointMarginalStraights = new MapInfo.Geometry.DPoint[2];
            /* Điểm đầu là trung điểm - điểm góc thửa */
            dPointMarginalStraights[0] = dPointMiddlePoint;
            /* Điểm cuối là điểm dPoints[0] */
            dPointMarginalStraights[1] = dPoints[0];
            /* Khai báo và gán giá trị cho điểm lân cận trung điểm của đoạn thẳng về phía dPoints[0] */
            MapInfo.Geometry.DPoint dPointMarginal;
            dPointMarginal = featureTools.ToaDoDiemChia(dPointMarginalStraights, 0.01);

            if (this.InsidePolygon(polygon, dPointMarginal))//dPoints[0]))
            {
                dPointTemp = dPoints[1];
            }
            else
            {
                dPointTemp = dPoints[0];
            }
            /* Trả về điểm nằm ngoài vùng  cho hàm */
            return dPointTemp;
        }

        #endregion
    }

}
