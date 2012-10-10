using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public  class VertexLable
    {
        /// <summary>
        /// Tạo nhãn của các đỉnh tạo thành thửa đất
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tạo đỉnh</param>
        /// <param name="strLayerName">Tên lớp chứa thửa đất cần tạo đỉnh</param>
        public void CreateVertexLable(MapInfo.Mapping.Map map, string strLayerName, double dblDistance, double dblHeight, double dblWidth)
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
            /* Kiểm tra dữ liệu đầu vào */
            if (dblDistance == 0.00)
                return;
            if (dblHeight == 0.00)
                return;
            if (dblWidth == 0.00)
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
                        /* Khai báo lớp chứa phương thức xác định danh sách các góc tường */
                        DMC.GIS.Common.WallBorderlines WallBorderlines = new DMC.GIS.Common.WallBorderlines();
                        dPointWallCornerPoints = WallBorderlines.WallCornerPoints(polygon, dblDistance);
                        for (int i = 0; i <= dPointWallCornerPoints.Length - 1; i++)
                        {
                            /* Vẽ Text */
                            featureTools.CreateText(map, strLayerName, dPointWallCornerPoints[i], (i + 1).ToString(), 8,dblWidth,dblHeight);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tạo nhãn của các đỉnh tạo thành thửa đất
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tạo đỉnh</param>
        /// <param name="strLayerName">Tên lớp chứa thửa đất cần tạo đỉnh</param>
        /// <param name="strObjectGroupField">Tên trường kiểu đối tượng, giá trị thuộc trường này xác định đối tượng thuộc nhóm nào</param>
        /// <param name="strObjectGroupValue">Giá trị xác định đối tượng thuộc nhóm nào</param>
        public void CreateVertexLable(MapInfo.Mapping.Map map, string strLayerName, double dblDistance, double dblHeight, double dblWidth, string strObjectGroupField, string strObjectGroupValue)
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
            /* Kiểm tra dữ liệu đầu vào */
            if (dblDistance == 0.00)
                return;
            if (dblHeight == 0.00)
                return;
            if (dblWidth == 0.00)
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
                        /* Khai báo lớp chứa phương thức xác định danh sách các góc tường */
                        DMC.GIS.Common.WallBorderlines WallBorderlines = new DMC.GIS.Common.WallBorderlines();
                        dPointWallCornerPoints = WallBorderlines.WallCornerPoints(polygon, dblDistance);
                        for (int i = 0; i <= dPointWallCornerPoints.Length - 1; i++)
                        {
                            /* Vẽ Text */
                            featureTools.CreateText(map, strLayerName, dPointWallCornerPoints[i], (i + 1).ToString(), 8, dblWidth, dblHeight,strObjectGroupField,strObjectGroupValue);
                        }
                    }
                }
            }
        }

        public void DeleteVertexLable(MapInfo.Mapping.Map map, string strLayerName)
        {
            //DMC.GIS.Common.SearchTools searchTools = new SearchTools();
            ///* */
            //MapInfo.Data.IResultSetFeatureCollection irfc;
            //irfc =  searchTools.SearchWithColumn(map, strLayerName, "TyLeIn", "1");
            //if (irfc.Count > 0)
            //{
            //}
            /* Lựa chọn tất cả các đối tượng trên lớp thửa đất */
            MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchAll();
            MapInfo.Data.IResultSetFeatureCollection irfs = MapInfo.Engine.Session.Current.Catalog.Search(strLayerName, si);
            /* */
            if (irfs.Count <= 0)
                return;
            foreach (MapInfo.Data.Feature feature in irfs)
            {
                if (feature.Geometry.Type == MapInfo.Geometry.GeometryType.LegacyText)
                {
                    /* Xóa Feature*/
                    irfs.Table.DeleteFeature(feature);
                }
            }
        }
    }
}
