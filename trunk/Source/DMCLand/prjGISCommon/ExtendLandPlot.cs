using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapInfo.Data;
namespace DMC.GIS.Common
{
    /// <summary>
    /// THỬA ĐẤT MỞ RỘNG
    /// Lớp này được sử dụng trong chức năng nới rộng của một thửa đất,
    /// để lấy râu thửa trong phần SOẠN HỒ SƠ KĨ THUẬT
    /// </summary>
    public class ExtendLandPlot
    {
        public void CreateExtendLandPlot(MapInfo.Windows.Controls.MapControl  mapControl, string strLayerName, string strTempLayerName , double dblWidth)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (mapControl == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là "strLayerName" trong bản đồ "map" */
            if (mapControl.Map.Layers[strLayerName] == null)
                return;
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            /* Khai báo và gán giá trị cho biến nhận tập hợp các Feature đagn được Select trên lớp strLayerName */
            MapInfo.Data.IResultSetFeatureCollection irfc = null;
            irfc = featureTools.SelectFeatures(mapControl.Map, strLayerName);
            /* Chắc chắn rằng tồn tại Feature trong FeatureCollection */
            if (irfc == null)
                return;
            /* Chắc chắn rằng chỉ có một Feature được lựa chọn */
            if (irfc.Count != 1)
                return;
            /* Tạo lớp TempLayerName */
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            bool boolCreateLayer = layerTools.CreateLayerWithTemplateLayer(mapControl.Map, strLayerName, strTempLayerName);
            //MapInfo.Data.Table tableTemp = layerTools.CreateTableSoanSoDoThuaDat(strTempLayerName);
            //if (tableTemp == null)
            //    return;
            //bool boolCreateLayer = layerTools.CreateLayerWithTemplateTable(mapControl.Map, tableTemp);

            /* */
            DMC.GIS.Common.SearchTools searchTools = new SearchTools();

            MapInfo.Data.Feature featureSelected = irfc[0];
            /* Khai báo Feature nhận Buffer của thửa đất */
            MapInfo.Data.Feature featureBuffer;

            if (featureSelected.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon)
            {
                MapInfo.Geometry.MultiPolygon multiPolygon = (MapInfo.Geometry.MultiPolygon)featureSelected.Geometry;
                foreach (MapInfo.Geometry.Polygon polygon in multiPolygon)
                {
                    /* Xác định phần thửa mở rộng 
                     * Note: Trường hợp khoảng nới rộng bằng 0 thì ta lấy nguyên thửa */
                    if (dblWidth > 0.0)
                    {
                        /* Lấy Buffer */
                        featureBuffer = featureTools.Buffer(featureSelected, dblWidth);
                        ///* Test */
                        //// sets the style and color to the line drawn
                        //MapInfo.Styles.SimpleLineStyle simLineStyle = new MapInfo.Styles.SimpleLineStyle(new MapInfo.Styles.LineWidth(1, MapInfo.Styles.LineWidthUnit.Pixel), 2, System.Drawing.Color.Red, false);
                        //MapInfo.Styles.SimpleInterior simInterior = new MapInfo.Styles.SimpleInterior(0, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, true);
                        //MapInfo.Styles.AreaStyle rectAreaStyle = new MapInfo.Styles.AreaStyle(simLineStyle, simInterior);
                        //MapInfo.Styles.CompositeStyle rectCompositeStyle = new MapInfo.Styles.CompositeStyle(rectAreaStyle);
                        //MapInfo.Geometry.DRect dRect = new MapInfo.Geometry.DRect(polygon.Bounds.x1, polygon.Bounds.y1, polygon.Bounds.x2, polygon.Bounds.y2);

                        ///* Khai báo FeatureLayer cần thực thi */
                        //MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)mapControl.Map.Layers[strLayerName];
                        //MapInfo.Geometry.CoordSys coordsys = featureLayer.CoordSys;

                        //MapInfo.Geometry.Rectangle newRect = new MapInfo.Geometry.Rectangle(coordsys ,dRect);
                        //featureBuffer = new MapInfo.Data.Feature(newRect, rectCompositeStyle);
                        ///* EndTest */

                        /* Search Intersect between Buffer and Features in strLayerName */
                        MapInfo.Data.IResultSetFeatureCollection irfcSearch = searchTools.SearchWithIntersect(mapControl.Map, strLayerName, featureBuffer.Geometry);
                        /* Insert irfcSearch vào TempLayerName */
                        /* Với các đối tượng được lựa chọn, ta đưa vào trong lớp tạm để xử lý */
                        featureTools.insertFeaturesToFeatureLayer(mapControl.Map, irfcSearch, strTempLayerName);

                        /* Insert Buffer vào TempLayerName */
                        featureTools.insertFeatureToFeatureLayer(mapControl.Map, featureBuffer, strTempLayerName);

                        /* Break all Features in strTempLayerName Layer */
                        featureTools.BreakAllFeaturesInLayer(mapControl.Map, strTempLayerName);
                        /* Combine all Features in strTempLayerName Layer */
                        featureTools.CombineAllFeaturesInLayer(mapControl.Map, strTempLayerName);
                        /* Break againt all Features in strTempLayerName Layer */
                        featureTools.BreakAllFeaturesInLayer(mapControl.Map, strTempLayerName);
                        /* Lấy Buffer2 nhỏ hơn Buffer 1 để Search tất cả các đối tượng nằm trong
                         * Buffer 1 không bao gồm Buffer 1*/
                        MapInfo.Data.Feature featureBuffer2 = featureTools.Buffer(featureSelected, dblWidth - 0.05);
                        /* Search Intersect between Buffer2 and Features in strTempLayerName */
                        MapInfo.Data.IResultSetFeatureCollection irfcSearch2 = searchTools.SearchWithIntersect(mapControl.Map, strTempLayerName, featureBuffer2.Geometry);
                        /* Lựa chọn tất cả các đối tượng trên lớp strTempLayerName */
                        MapInfo.Data.IResultSetFeatureCollection irfcSearchAll = searchTools.SearchAll(mapControl.Map, strTempLayerName);
                        if (irfcSearchAll == null)
                            return;
                        /* Với mỗi đối tượng trên lớp strTempLayerName. Nếu đối tượng đó không nằm 
                         * trong tập hợp các đối tượng nằm trong Buffer 2 thì ta xóa đối tượng đó*/
                        foreach (MapInfo.Data.Feature feature in irfcSearchAll)
                        {
                            bool boolDelete = true;
                            foreach (MapInfo.Data.Feature feature2 in irfcSearch2)
                            {
                                if (feature.Key == feature2.Key)
                                {
                                    boolDelete = false;
                                }
                            }
                            if (boolDelete == true)
                            {
                                featureTools.DeleteFeature(mapControl.Map, feature, strTempLayerName);
                            }
                        }
                    }
                    /* Insert featureSelected into strTempLayerName Layer */
                    featureTools.insertFeatureToFeatureLayer(mapControl.Map, featureSelected, strTempLayerName);
                    /* Cho phép Edit lớp Tạm (Lớp thửa đất) */
                    DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
                    layerTool.EditableLayer(mapControl, strTempLayerName, true);
                    /* Hiển thị những thửa đất định ghép lên toàn màn hình */
                    mapControl.Map.SetView(featureSelected);
                }
            }
        }

        public void CreateExtendLandPlot(MapInfo.Windows.Controls.MapControl mapControl, string strLayerName,string strMaDoiTuong, string strTempLayerName, double dblWidth)
        {
            Table tabInf = null;
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (mapControl == null)
                return;
            /* Chắc chắn rằng tồn tại lớp có tên là "strLayerName" trong bản đồ "map" */
            if (mapControl.Map.Layers[strLayerName] == null)
                return;
            /* Khai báo lớp chứa các chức năng về Feature */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            /* Khai báo lớp chứa các công cụ tìm kiếm */
            DMC.GIS.Common.SearchTools searchTools = new DMC.GIS.Common.SearchTools();
            /* Khai báo và gán giá trị cho biến nhận tập hợp các Feature tìm được theo Key trên lớp strLayerName */
            MapInfo.Data.IResultSetFeatureCollection irfc = null;
            irfc = searchTools.SearchWithKey (mapControl.Map, strLayerName,strMaDoiTuong);
            /* Chắc chắn rằng tồn tại Feature trong FeatureCollection */
            if (irfc == null)
                return;
            /* Chắc chắn rằng chỉ có một Feature được lựa chọn */
            if (irfc.Count != 1)
                return;
            /* Tạo lớp TempLayerName */
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();

            bool boolCreateLayer = layerTools.CreateLayerWithTemplateLayer(mapControl.Map, "tmp", strTempLayerName); //20100323
            tabInf = MapInfo.Engine.Session.Current.Catalog.GetTable(strTempLayerName);
            //MapInfo.Data.Table tableTemp = layerTools.CreateTableSoanSoDoThuaDat(strTempLayerName);
            //if (tableTemp == null)
            //    return;
            //bool boolCreateLayer = layerTools.CreateLayerWithTemplateTable(mapControl.Map,tableTemp);

            MapInfo.Data.Feature featureSelected = irfc[0];
            /* Khai báo Feature nhận Buffer của thửa đất */
            MapInfo.Data.Feature featureBuffer;

            if (featureSelected.Geometry.Type == MapInfo.Geometry.GeometryType.MultiPolygon)
            {
                MapInfo.Geometry.MultiPolygon multiPolygon = (MapInfo.Geometry.MultiPolygon)featureSelected.Geometry;

                //xoa het du lieu cu
                featureTools.DeleteAllFeatures(mapControl.Map, strTempLayerName);

                foreach (MapInfo.Geometry.Polygon polygon in multiPolygon)
                {
                    ////xoa het du lieu cu
                    //featureTools.DeleteAllFeatures(mapControl.Map, strTempLayerName);

                    /* Xác định phần thửa mở rộng 
                     * Note: Trường hợp khoảng nới rộng bằng 0 thì ta lấy nguyên thửa */
                    if (dblWidth > 0.0)
                    {
                        /* Lấy Buffer */
                        featureBuffer = featureTools.Buffer(featureSelected, dblWidth);

                        /* Search Intersect between Buffer and Features in strLayerName */
                        MapInfo.Data.IResultSetFeatureCollection irfcSearch = searchTools.SearchWithIntersect(mapControl.Map, strLayerName, featureBuffer.Geometry);
                        /* Insert irfcSearch vào TempLayerName */
                        /* Với các đối tượng được lựa chọn, ta đưa vào trong lớp tạm để xử lý */
                        featureTools.insertFeaturesToFeatureLayer(mapControl.Map, irfcSearch, strTempLayerName);

                        /* Insert Buffer vào TempLayerName */
                        featureTools.insertFeatureToFeatureLayer(mapControl.Map, featureBuffer, strTempLayerName);

                        /* Break all Features in strTempLayerName Layer */
                        featureTools.BreakAllFeaturesInLayer(mapControl.Map, strTempLayerName);
                        /* Combine all Features in strTempLayerName Layer */
                        featureTools.CombineAllFeaturesInLayer(mapControl.Map, strTempLayerName);
                        /* Break againt all Features in strTempLayerName Layer */
                        featureTools.BreakAllFeaturesInLayer(mapControl.Map, strTempLayerName);
                        /* Lấy Buffer2 nhỏ hơn Buffer 1 để Search tất cả các đối tượng nằm trong
                         * Buffer 1 không bao gồm Buffer 1*/
                        MapInfo.Data.Feature featureBuffer2 = featureTools.Buffer(featureSelected, dblWidth - 0.05);
                        /* Search Intersect between Buffer2 and Features in strTempLayerName */
                        MapInfo.Data.IResultSetFeatureCollection irfcSearch2 = searchTools.SearchWithIntersect(mapControl.Map, strTempLayerName, featureBuffer2.Geometry);
                        /* Chắc chắn rằng tồn tại đối tượng nằm trong phần giao giữa Buffer2 và các Feature trên lớp strTempLayerName */
                        if (irfcSearch2 == null)
                            return;
                        /* Lựa chọn tất cả các đối tượng trên lớp strTempLayerName */
                        MapInfo.Data.IResultSetFeatureCollection irfcSearchAll = searchTools.SearchAll(mapControl.Map, strTempLayerName);
                        /* Chắc chắn rằng tồn tại đối tượng trên lớp strTempLayerName */
                        if (irfcSearchAll == null)
                            return;
                        /* Với mỗi đối tượng trên lớp strTempLayerName. Nếu đối tượng đó không nằm 
                         * trong tập hợp các đối tượng nằm trong Buffer 2 thì ta xóa đối tượng đó*/
                        foreach (MapInfo.Data.Feature feature in irfcSearchAll)
                        {
                            bool boolDelete = true;
                            foreach (MapInfo.Data.Feature feature2 in irfcSearch2)
                            {
                                if (feature.Key == feature2.Key)
                                {
                                    boolDelete = false;
                                }
                            }
                            if (boolDelete == true)
                            {
                                featureTools.DeleteFeature(mapControl.Map, feature, strTempLayerName);
                            }
                        }
                    }
                    /* Insert featureSelected into strTempLayerName Layer */
                    featureTools.insertFeatureToFeatureLayer(mapControl.Map, featureSelected, strTempLayerName);
                    ///* Hiển thị các node */
                    //DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
                    //layerTools.LayerShowNodes(mapControl.Map, strTempLayerName, DMC.GIS.Common.CommonLand.boolShowNodes);
                    /* Cho phép Edit lớp Tạm (Lớp thửa đất) */
                    DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
                    layerTool.EditableLayer(mapControl, strTempLayerName, true);
                    /* Hiển thị những thửa đất định ghép lên toàn màn hình */
                    mapControl.Map.SetView(featureSelected);
                }
            }
        }



        /// <summary>
        /// Xác định một Feature có thuộc một tập hợp các Feature không
        /// </summary>
        /// <param name="feature">Feature cần mang ra xác định</param>
        /// <param name="irfc">Tập hợp các Feature</param>
        /// <returns>Giá trị trả về kiểu True/False cho biết Feature đó có thuộc tập hợp các Fêature - FeatureCollection hay không</returns>
        private bool FeatureInFeatureCollection( MapInfo.Data.Feature feature, MapInfo.Data.FeatureCollection featureCollection)
        {
            /* Duyệt để so sánh với từng Feature trong tập hợp các Feature */
            foreach (MapInfo.Data.Feature featureTemp in featureCollection)
            {
                /* Nếu thấy Key của Feature mang ra so sánh  bằng Key của 
                 * một trong các Feature của tập hợp các Feature thì dừng lại */
                if (feature.Key == featureTemp.Key)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
