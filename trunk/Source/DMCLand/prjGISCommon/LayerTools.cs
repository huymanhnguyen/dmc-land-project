using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public class LayerTools
    {
        /* -----------------------NHỮNG CHỨC NĂNG THAM KHẢO CẦN KIỂM TRA-------------------------------*/
        /* Test */
        /// <summary>
        /// Tìm tất cả các đối tượng trong một lớp với ....
        /// </summary>
        /// <param name="strTableAlias"></param>
        private MapInfo.Data.IResultSetFeatureCollection SearchTable(MapInfo.Mapping.Map map, string strTableAlias, string strFieldName, string strValue)
        {
            string strSQL = strFieldName + " Like '" + strValue + "%' ";

            MapInfo.Data.IQueryFilter qf = new MapInfo.Data.SqlExpressionFilter(strSQL);
            MapInfo.Data.QueryDefinition qd = new MapInfo.Data.QueryDefinition(qf, "*");

            MapInfo.Data.SearchInfo si = new MapInfo.Data.SearchInfo(null, qd);
            //MapInfo.Data.IResultSetFeatureCollection ifc = MapInfo.Engine.Session.Current.Catalog.Search(tb, si);
            MapInfo.Data.IResultSetFeatureCollection ifc = MapInfo.Engine.Session.Current.Catalog.Search(strTableAlias, si);
            ////MapInfo.Data.TableInfoMemTable ti = new MapInfo.Data.TableInfoMemTable("temp_Query01"); 
            return ifc;
        }
        /* End Test */
        /* Test */
        public void LayerTransparent(MapInfo.Mapping.Map map, string strLayerName)
        {

            MapInfo.Styles.SimpleInterior simpleInterior =
               new MapInfo.Styles.SimpleInterior(0, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, true);
            MapInfo.Styles.CompositeStyle compositeStyle = new MapInfo.Styles.CompositeStyle();// (feature.Style);
            compositeStyle.AreaStyle.Interior = simpleInterior;

            //
            MapInfo.Data.MIConnection connection = new MapInfo.Data.MIConnection();
            connection.Open();
            MapInfo.Data.MICommand command = connection.CreateCommand();
            command.CommandText = "update " + strLayerName + "  set SW_GEOMETRY = SW_GEOMETRY,  MI_Style=@style";
            command.Parameters.Add("@style", compositeStyle);
            command.Prepare();
            command.ExecuteNonQuery();

            //
            command.Cancel();
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
        /* End Test */
        /*---------------------------------------------------------------------------------------------*/

        /* Test */
        public void SearchWithSql(MapInfo.Mapping.Map map, string strTableName, string strColumnName1, string strKey1, string strColumnName2, string strKey2)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strTableName */
            if (map.Layers[strTableName] == null)
                return;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strTableName];
            /* Chắc chắn rằng tồn tại cột có tên là strColumnName1 */
            if (featureLayer.Table.TableInfo.Columns[strColumnName1] == null)
                return;
            /* Chắc chắn rằng tồn tại cột có tên là strColumnName2 */
            if (featureLayer.Table.TableInfo.Columns[strColumnName2] == null)
                return;
            /* Khai báo đối tượng kết nối */
            MapInfo.Data.MIConnection miConnection = new MapInfo.Data.MIConnection();
            /* Mở kết nối */
            miConnection.Open();
            /* Khai báo đối tượng thực thi câu lệnh */
            MapInfo.Data.MICommand miCommand = miConnection.CreateCommand();
            /* Khai báo chuỗi truy vấn dữ liệu */
            miCommand.CommandText = "select * from " + strTableName + " where (" + strColumnName1 + " like '%'+@name+'%') " + " and (" + strColumnName2 + " like '%'+@name2+'%') ";
            miCommand.Parameters.Add("@name", strKey1);
            miCommand.Parameters.Add("@name2", strKey2);
            /* Nhận các đối tượng tìm được vào tâp hợp các Feature */
            MapInfo.Data.IResultSetFeatureCollection irfc = miCommand.ExecuteFeatureCollection();
            /* UnSelect những đối tượng đang được Select */
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            if (irfc.Count <= 0)
            {
                System.Windows.Forms.MessageBox.Show("KHÔNG tìm được thửa đất nào!", "DMCLand");
            }
            else
            {
                /* Select tất cả những Feature tìm được */
                MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(irfc);
                //if (irfc.Count == 1)
                //{
                //    map.Center = new MapInfo.Geometry.DPoint(irfc[0].Geometry.Centroid.x, irfc[0].Geometry.Centroid.y);
                //    MapInfo.Geometry.Distance d = new MapInfo.Geometry.Distance(0.5, map.Zoom.Unit);
                //    map.Zoom = d;
                //}
                //else
                //{
                /* Zoom (nhìn) tòan bộ những Feature được Select */
               

                map.SetView(irfc.Envelope);
                //}
            }
        }
        /* EndTest */

        
        public bool CreateLayerWithTemplateLayer(MapInfo.Mapping.Map map, string strTemplateTableName, string strNewTableName)
        {
            /* Chắc chắn rằng TỒN TẠI đối tượng bản đồ - map */
            if (map == null)
                return false;
            /* Chắc chắn rằng TỒN TẠI lớp bản đồ mẫu có tên là strTemplateTableName */
            if (map.Layers[strTemplateTableName] == null)
                return false;
            /* Kiểm tra sự tồn tại của lớp bản đồ có tên là strNewTableName */
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(strNewTableName) != null)// (map.Layers.Contains(map.Layers[strNewTableName]))
            {
                /* Nếu đã tồn tại lớp bản đồ có tên là strNewTableName 
                 thì đóng bảng đó lại */
                MapInfo.Engine.Session.Current.Catalog.CloseTable(strNewTableName); 
            }
            /* Khai báo FeatureLayer mẫu mà chúng ta cần lấy cấu trúc trường thuộc tính */
            MapInfo.Mapping.FeatureLayer featureLayerTemplate = (MapInfo.Mapping.FeatureLayer)map.Layers[strTemplateTableName];
            /* Khai báo và xác định hệ tọa độ, với hệ tọa độ là hệ tọa độ của FeatureLayer mẫu */
            MapInfo.Geometry.CoordSys coordsys = featureLayerTemplate.CoordSys;  //MapInfo.Engine.Session.Current.CoordSysFactory.CreateLongLat(DatumID.NAD83);
            /* Khai báo đối tượng bảng mẫu */
            MapInfo.Data.Table tableTemplate = featureLayerTemplate.Table;
       


            /* Khai báo, đặt tên, gắn hệ tọa độ vào đối tượng TableInfo của bảng cần tạo */
            MapInfo.Data.TableInfo tableInfo = MapInfo.Data.TableInfoFactory.CreateTemp(strNewTableName, coordsys);
            /* Thêm các trường thuộc tính của FeatureLayer cần tạo với cấu trúc là các trường thuộc tính của FeatureLayer mẫu */
            for (int i = 0; i < tableTemplate.TableInfo.Columns.Count - 1; i++)
            {
                /* Add tên và kiểu cho từng trường thuộc tính */
                tableInfo.Columns.Add(new MapInfo.Data.Column(tableTemplate.TableInfo.Columns[i].Alias, tableTemplate.TableInfo.Columns[i].DataType));
            }
            /* Khai báo và tạo bảng với TableInfo đã được xác định */
            MapInfo.Data.Table tableNew = MapInfo.Engine.Session.Current.Catalog.CreateTable(tableInfo);
            /* Tạo FeatureLayer với Table và đã được xác định ở trên */
            MapInfo.Mapping.FeatureLayer featureLayerNew = new MapInfo.Mapping.FeatureLayer(tableNew, strNewTableName);
            /* Add FeatureLayer vừa tạo vào bản đồ chung */
            map.Layers.Add(featureLayerNew);
            /* Trả về giá trị cho hàm là bảng vừa tạo */
            return true;
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
            mapControl.Map.Invalidate(); /* CẦN KIỂM TRA LẠI PHƯƠNG THỨC NÀY */
        }

        /// <summary>
        /// Nhận Feature đang được select trên một lớp có trên là strLayerName
        /// </summary>
        /// <param name="map"></param>
        /// <param name="strLayerName"></param>
        /// <returns></returns>
        public MapInfo.Data.Feature GetSelectedFeature(MapInfo.Mapping.Map map, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return null;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return null;
            /* Khai báo và khởi tạo phương thức nhận các Feature đang được lựa chọn
             trên lớp có tên là strLayerName*/
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            /* Khai báo và gắn giá trị cho biến tập hợp các Feature đang được lựa chọn
             trên lớp có tên là strLayerName*/
            MapInfo.Data.IResultSetFeatureCollection irfc = featureTools.SelectFeatures(map, strLayerName);
            /* Chắc chắn tồn tại tập hợp các Feature */
            if (irfc == null)
                return null;
            /* Chắc chắn rằng chỉ có một đối tượng được lựa chọn */
            if (irfc.Count != 1)
                return null;
            /* Khai báo biến kiểu Feature nhận giá trị là đối tượng được lựa chọn */
            MapInfo.Data.Feature feature = irfc[0];
            return feature;
        }

        public void LayerShowNodes(MapInfo.Mapping.Map map, string strLayerName, bool blShowNode)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            featureLayer.ShowNodes = blShowNode;
        }
        /// <summary>
        /// Hiển thị tâm của Feature trên Layer
        /// </summary>
        /// <param name="lyr"></param>
        /// <param name="blShowCentroid"></param>

        public void LayerShowCentroids(MapInfo.Mapping.Map map, string strLayerName, bool blShowCentroid)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            featureLayer.ShowCentroids = blShowCentroid;

            ////FIX ZOOM 
            //MapInfo.Mapping.FeatureLayer featureLayer = (FeatureLayer)mapControl1.Map.Layers["Đất"];
            //featureLayer.VisibleRangeEnabled = false;
            //featureLayer.VisibleRange = new MapInfo.Mapping.VisibleRange(0.001, true, 1500, false, DistanceUnit.Meter);
            //featureLayer.VisibleRange.Within(mapControl1.Map.Zoom);
        }
        /// <summary>
        /// Hiển thị Hướng của đường thẳng trong Layer
        /// </summary>
        /// <param name="lyr"></param>
        /// <param name="blShowLineDirection"></param>
        public void LayerShowLineDirection(MapInfo.Mapping.Map map, string strLayerName, bool blShowLineDirection)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            featureLayer.ShowLineDirection = blShowLineDirection;
        }
        /// <summary>
        /// Ẩn hiện lớp bản đồ
        /// </summary>
        /// <param name="lyr"></param>
        /// <param name="blEnable"></param>
        public void LayerEnable(MapInfo.Mapping.Map map, string strLayerName, bool blEnable)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strLayerName */
            if (map.Layers[strLayerName] == null)
                return;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            featureLayer.Enabled = blEnable;
        }

        /// <summary>
        /// Tạo lớp Soạn Sơ đồ thửa đất
        /// Phương thức này được sử dụng trong trường hợp lấy rộng vùng
        /// Note: Cần xem lại phương thức này. Hiện tại cấu trúc lớp
        /// được Fix cứng trong code. Có thể lấy cấu trúc lớp từ cơ sở
        /// dữ liệu để tránh lỗi phát sinh có thể xảy ra do không tương thích
        /// </summary>
        /// <param name="map">Tên đối tượng bản đồ</param>
        /// <param name="strNewTableName">Tên lớp Soạn sơ đồ thửa đất</param>
        /// <returns>Giá trị trả về kiểu Boolean xác định phương thức đã thực thi
        /// có thành công hay không?</returns>
        public bool CreateLayerWithTemplateTable(MapInfo.Mapping.Map map, MapInfo.Data.Table tableTemp)
        {
            /* Khai báo biến tạm kiểu  Boolean */
            bool boolTemp = true;
            try
            {
                /* Chắc chắn rằng TỒN TẠI đối tượng bản đồ - map */
                if (map == null)
                    return false;
                /* Kiểm tra sự tồn tại của lớp bản đồ có tên trùng với tên 
                 * của bảng cần tạo*/
                if (map.Layers.Contains(map.Layers[tableTemp.Alias]))
                {
                    /* Nếu đã tồn tại lớp bản đồ có tên trùng với tên bảng cần tạo
                     thì Remove lớp đó */
                    map.Layers.Remove(tableTemp.Alias);
                }
                /* Tạo FeatureLayer với Table và đã được xác định ở trên */
                MapInfo.Mapping.FeatureLayer featureLayerNew = new MapInfo.Mapping.FeatureLayer(tableTemp);
                /* Add FeatureLayer vừa tạo vào bản đồ chung */
                map.Layers.Add(featureLayerNew);
            }
            catch (Exception ex)
            {
                boolTemp = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            /* Trả về giá trị cho hàm là bảng vừa tạo */
            return boolTemp;
        }

        public MapInfo.Data.Table CreateTableSoanSoDoThuaDat(string strNewTableName)
        {

            /* Kiểm tra sự tồn tại của lớp bản đồ có tên là strNewTableName */
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(strNewTableName) != null)// (map.Layers.Contains(map.Layers[strNewTableName]))
            {
                /* Nếu đã tồn tại lớp bản đồ có tên là strNewTableName 
                 thì đóng bảng đó lại */
                MapInfo.Engine.Session.Current.Catalog.CloseTable(strNewTableName);
            }

            /* Khai báo bảng tạm */
            MapInfo.Data.Table tblTemp = null;
            try
            {
                /* Khai báo và xác định hệ tọa độ, với hệ tọa độ là hệ tọa độ của FeatureLayer mẫu */
                MapInfo.Geometry.CoordSys coordsys = MapInfo.Engine.Session.Current.CoordSysFactory.CreateLongLat(MapInfo.Geometry.DatumID.WGS84);
                /* Khai báo, đặt tên, gắn hệ tọa độ vào đối tượng TableInfo của bảng cần tạo */
                MapInfo.Data.TableInfo tableInfo = MapInfo.Data.TableInfoFactory.CreateTemp(strNewTableName, coordsys);
                /* Thêm các trường thuộc tính của FeatureLayer cần tạo với cấu trúc là các trường thuộc tính của FeatureLayer mẫu */
                /* ------------Add tên và kiểu cho từng trường thuộc tính----------------- */
                tableInfo.Columns.Add(new MapInfo.Data.Column("MaHoSoCapGCN", MapInfo.Data.MIDbType.Int));
                tableInfo.Columns.Add(new MapInfo.Data.Column("MaDoiTuong", MapInfo.Data.MIDbType.Int));
                tableInfo.Columns.Add(new MapInfo.Data.Column("ToBanDo", MapInfo.Data.MIDbType.String));
                tableInfo.Columns.Add(new MapInfo.Data.Column("SoThua", MapInfo.Data.MIDbType.String));
                tableInfo.Columns.Add(new MapInfo.Data.Column("DienTich", MapInfo.Data.MIDbType.dBaseDecimal));
                tableInfo.Columns.Add(new MapInfo.Data.Column("featureID", MapInfo.Data.MIDbType.Int));
                tableInfo.Columns.Add(new MapInfo.Data.Column("TYLEIN", MapInfo.Data.MIDbType.Double));
                //tableInfo.Columns.Add(new MapInfo.Data.Column("MI_STYLE", MapInfo.Data.MIDbType.String));
                //tableInfo.Columns.Add(new MapInfo.Data.Column("SW_MEMBER", MapInfo.Data.MIDbType.Int));
                //tableInfo.Columns.Add(new MapInfo.Data.Column("SW_GEOMETRY", MapInfo.Data.MIDbType.FeatureGeometry));
                tableInfo.Columns.Add(new MapInfo.Data.Column("Temp", MapInfo.Data.MIDbType.Boolean));
                tableInfo.Columns.Add(new MapInfo.Data.Column("FixZoom", MapInfo.Data.MIDbType.Double));
                /* Khai báo và tạo bảng với TableInfo đã được xác định */
                tblTemp = MapInfo.Engine.Session.Current.Catalog.CreateTable(tableInfo);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Tạo bảng Sơ đồ thửa đất" + System.Environment.NewLine + ex.Message, "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
            return tblTemp;
        }


        
    }
}
