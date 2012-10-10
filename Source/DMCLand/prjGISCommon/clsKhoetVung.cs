using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public class clsKhoetVung
    {
        /// <summary>
        /// Khoét một vùng theo một vùng nằm trong vùng đó.
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp có vùng cần khoét</param>
        /// <param name="strLayerName">Tên lớp chứa vùng cần khoét</param>
        /// <returns>Đối tượng trả về là vùng đã được khoét</returns>
        public MapInfo.Data.Feature KhoetVung(MapInfo.Mapping.Map map, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return null;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return null;

            /* Khai báo FeatureLayer cần thực thi */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;
            /* Khai báo FeatureGeometry dạng MultiPolygon với tọa độ và Hệ tọa độ đã xác định */
            MapInfo.Geometry.CoordSys coordsys = featureLayer.CoordSys;

            /* Lựa chọn Feature cần khoét */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc;
            irfc = featureTools.SelectFeatures(map, strLayerName);
            /* Chắc chắn rằng tồn tại đối tượng được lựa chọn */
            if (irfc == null)
                return null;
            /* Chắc chắn rằng chỉ tồn tại một vùng được lựa chọn để khoét */
            if (irfc.Count != 1)
            {
                System.Windows.Forms.MessageBox.Show("Chỉ chọn MỘT vùng để khoét!");
                return null;
            }
            /* Chắc chắn rằng đối tượng được lựa chọn để khoét vùng phải là kiểu vùng*/
            if (irfc[0].Geometry.Type != MapInfo.Geometry.GeometryType.MultiPolygon)
            {
                return null;
            }
            /* Chuyển Feature cần khoét về MultiPolygon */
            MapInfo.Geometry.MultiPolygon multiPolygonKhoet = (MapInfo.Geometry.MultiPolygon)irfc[0].Geometry;

            DMC.GIS.Common.SearchTools searchTools = new SearchTools();
            /* Lựa chọn tất cả các đối tượng nằm bên trong đối tượng định khoét*/
            MapInfo.Data.IResultSetFeatureCollection irfcSearchInter = searchTools.SearchWithGeometry(map, strLayerName, irfc[0].Geometry);
            /* Chắc chắn rằng chỉ tồn 2 vùng nằm bên trong vùng cần khoét 
             * (bao gồm cả vùng cần khoét) */
            if (irfcSearchInter.Count != 2)
                return null;

            /* Chắc chắn rằng đối tượng bên trong cũng phải là kiểu vùng */
            if ((irfcSearchInter[0].Geometry.Type != MapInfo.Geometry.GeometryType.MultiPolygon) || (irfcSearchInter[1].Geometry.Type != MapInfo.Geometry.GeometryType.MultiPolygon))
            {
                return null;
            }

            /* Xác định vùng bên trong thửa đất cần khoét*/
            MapInfo.Geometry.MultiPolygon multiPolygonInter = (MapInfo.Geometry.MultiPolygon)irfcSearchInter[0].Geometry;
            if (multiPolygonKhoet.Area(MapInfo.Geometry.AreaUnit.SquareMeter) != multiPolygonInter.Area(MapInfo.Geometry.AreaUnit.SquareMeter))
            {
                multiPolygonInter = (MapInfo.Geometry.MultiPolygon)irfcSearchInter[0].Geometry;
            }
            else
            {
                multiPolygonInter = (MapInfo.Geometry.MultiPolygon)irfcSearchInter[1].Geometry;
            }
            /* Khai báo số vòng trong multiPolygon của vùng sau khi khoét
             * Số này bằng số vòng của vùng trước khi khoét cộng thêm 1 */
            int intRingCount = multiPolygonKhoet.RingTotal + 1;
            /* Khai báo mảng các vòng của vùng sau khi khoét */
            MapInfo.Geometry.Ring[] rings = new MapInfo.Geometry.Ring[intRingCount];
            /* Khai báo biến đếm */
            int iCounter = 0;
            /* Xác định các vòng ngoài */
            for (int j = 0; j < multiPolygonKhoet.PolygonCount; j++)
            {
                rings[j] = (MapInfo.Geometry.Ring)multiPolygonKhoet[j].Exterior;
                iCounter++;
            }

            /* Xác định các vòng trong */
            for (int m = 0; m < multiPolygonKhoet.PolygonCount; m++)
            {
                for (int l = 0; l < multiPolygonKhoet[m].InteriorCount; l++ )
                {
                    rings[iCounter] = (MapInfo.Geometry.Ring)multiPolygonKhoet[m].Interior(l);
                    iCounter++;
                }
            }
            /* Vòng bên trong cuối cùng chính là vòng ngoài của vùng bên trong đối 
             * tượng cần khoét*/
            rings[intRingCount - 1] = (MapInfo.Geometry.Ring)multiPolygonInter[0].Exterior;

            /* Tạo vùng sau khi khoét từ các vòng vừa được xác định */
            MapInfo.Geometry.FeatureGeometry g = new MapInfo.Geometry.MultiPolygon(coordsys, rings);
            /* Chọn kiểu cho vùng sau khi khoét */
            MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();
            cs = LandStyle();
            /* Khai báo Feature dạng Line cần tạo */
            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Gán giá trị cho Feature cần tạo */
            feature.Geometry = g;
            feature.Style = cs;
            MapInfo.Data.Key k = featureLayer.Table.InsertFeature(feature);
            /* Xóa thửa ban đầu */
            if (k.Value != null)
            {
                featureLayer.Table.DeleteFeature(irfc[0]);
            }
            /* Refresh lại lớp */
            featureLayer.Table.Refresh();
            return feature;
        }


        public MapInfo.Styles.CompositeStyle LandStyle()
        {
            MapInfo.Styles.SimpleInterior simpleInterior =
                new MapInfo.Styles.SimpleInterior(MapInfo.Styles.SimpleInterior.MinFillPattern, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, true);
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
    }
}
