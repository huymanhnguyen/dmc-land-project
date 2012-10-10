using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public  class SearchTools
    {

        public  MapInfo.Data.IResultSetFeatureCollection SearchWithGeometry( MapInfo.Mapping.Map map, string strLayerName)// , MapInfo.Data.Feature feature)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ chứa lớp strLayerName cần tìm theo Geometry */
            if (map == null)
                return null;
            /* Chắc chắn rằng tồn tại lớp bản đồ cần Search theo Geometry */
            if (map.Layers[strLayerName] == null)
                return null ;
            /* Lựa chọn các Feature */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc;
            irfc = featureTools.SelectFeatures(map, strLayerName);
            /* Xác định các Region trong các đối tượng được Select */
            MapInfo.Data.Feature[] featuresRegion = featureTools.checkRegionsInFeatureCollection(irfc);
            /* Chắc chắn rằng tồn tại đối tượng kiểu Vùng được lựa chọn */
            if (featuresRegion == null)
                return null ;
            /* Chắc chắn rằng chỉ có một thửa đất được lựa chọn */
            if (featuresRegion.Length != 1)
                return null  ;
            /* */
            MapInfo.Data.SearchInfo searchInfo = MapInfo.Data.SearchInfoFactory.SearchWithinGeometry(featuresRegion[0].Geometry, MapInfo.Data.ContainsType.Centroid);
            MapInfo.Data.IResultSetFeatureCollection irfcSearchGeometry = MapInfo.Engine.Session.Current.Catalog.Search(strLayerName, searchInfo);
            return irfcSearchGeometry;
        }

        public MapInfo.Data.IResultSetFeatureCollection SearchWithGeometry(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.FeatureGeometry featureGeometry)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ chứa lớp strLayerName cần tìm theo Geometry */
            if (map == null)
                return null;
            /* Chắc chắn rằng tồn tại lớp bản đồ cần Search theo Geometry */
            if (map.Layers[strLayerName] == null)
                return null;
            /* Lựa chọn các Feature */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            /* */
            MapInfo.Data.SearchInfo searchInfo = MapInfo.Data.SearchInfoFactory.SearchWithinGeometry(featureGeometry,MapInfo.Data.ContainsType.Centroid);
            MapInfo.Data.IResultSetFeatureCollection irfcSearchGeometry = MapInfo.Engine.Session.Current.Catalog.Search(strLayerName, searchInfo);
            return irfcSearchGeometry;
        }

        /// <summary>
        /// Tìm tất cả các Feature trên lớp giao với FeatureGeometry 
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tìm kiếm</param>
        /// <param name="strLayerName">Lớp cần tìm các Feature giao với FeatureGeometry</param>
        /// <param name="featureGeometry">Feature  cho trước để tìm các Feature giao với nó</param>
        /// <returns>Giá trị trả về là tập các Feature giao với FeatureGeometry</returns>
        public MapInfo.Data.IResultSetFeatureCollection SearchWithIntersect(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.FeatureGeometry featureGeometry)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ chứa lớp strLayerName cần tìm theo Geometry */
            if (map == null)
                return null;
            /* Chắc chắn rằng tồn tại lớp bản đồ cần Search theo Geometry */
            if (map.Layers[strLayerName] == null)
                return null;
            /* Lựa chọn các Feature */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            /* */
            MapInfo.Data.SearchInfo searchInfo = MapInfo.Data.SearchInfoFactory.SearchIntersectsGeometry(featureGeometry, MapInfo.Data.IntersectType.Geometry);//  MapInfo.Data.ContainsType.Centroid);
            MapInfo.Data.IResultSetFeatureCollection irfcSearchIntersect = MapInfo.Engine.Session.Current.Catalog.Search(strLayerName, searchInfo);
            return irfcSearchIntersect;
        }

        public MapInfo.Data.IResultSetFeatureCollection SearchAll(MapInfo.Mapping.Map map, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ chứa lớp strLayerName cần tìm theo Geometry */
            if (map == null)
                return null;
            /* Chắc chắn rằng tồn tại lớp bản đồ cần Search theo Geometry */
            if (map.Layers[strLayerName] == null)
                return null;
            /* Lựa chọn tất cả các Feature */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            /* */
            MapInfo.Data.SearchInfo searchInfo = MapInfo.Data.SearchInfoFactory.SearchAll();
            MapInfo.Data.IResultSetFeatureCollection irfcSearchIntersect = MapInfo.Engine.Session.Current.Catalog.Search(strLayerName, searchInfo);
            return irfcSearchIntersect;
        }

        /// <summary>
        /// Tìm kiếm Feature theo trường dữ liệu thuộc tính và giá trị có kiểu dữ liệu 
        /// tương ứng với trường thuộc tính đó, trong một đơn vị hành chính xác định.
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tìm</param>
        /// <param name="strTableName">Tên bảng (lớp) cần tìm</param>
        /// <param name="strColumnName">Tên cột cần tìm</param>
        /// <param name="strKey">Tên giá trị cần tìm</param>
        /// <param name="strMaDonViHanhChinh">Tên đơn vị hành chính</param>
        public MapInfo.Data.IResultSetFeatureCollection SearchWithColumn(MapInfo.Mapping.Map map, string strTableName, string strColumnName, string strKey, string strMaDonViHanhChinh)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return null ;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strTableName */
            if (map.Layers[strTableName] == null)
                return null ;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strTableName];
            /* Chắc chắn rằng tồn tại cột có tên là strColumnName1 */
            if (!featureLayer.Table.TableInfo.Columns.Contains(featureLayer.Table.TableInfo.Columns[strColumnName]))
                return null ;
            /* Chắc chắn rằng thửa đất cần tìm phải nằm trong một đơn vị hành chính có MÃ ĐƠN VỊ HÀNH CHÍNH xác định */
            if (strMaDonViHanhChinh == null)
                return null ;
            if (strMaDonViHanhChinh == "")
                return null ;
            /* Chắc chắn rằng tồn tại giá trị cần tìm */
            if (strKey == null)
                return null ;
            if (strKey == "")
                return null ;
            /* Khai báo đối tượng kết nối */
            MapInfo.Data.MIConnection miConnection = new MapInfo.Data.MIConnection();
            /* Mở kết nối */
            miConnection.Open();
            /* Khai báo đối tượng thực thi câu lệnh */
            MapInfo.Data.MICommand miCommand = miConnection.CreateCommand();
            /* Khai báo chuỗi truy vấn dữ liệu */
            /* Trường hợp trường có kiểu là String.
             Khi đó thực hiện kiểu truy vấn tương đối chuỗi */
            if (featureLayer.Table.TableInfo.Columns[strColumnName].DataType == MapInfo.Data.MIDbType.String)
            {
                miCommand.CommandText = "select * from " + strTableName + " where (" + strColumnName + " like '%'+@name+'%') and ( " + "MaDonViHanhChinh = '" + strMaDonViHanhChinh + "')" ;
                miCommand.Parameters.Add("@name", strKey);
            }
            /* Trường hợp dữ liệu có kiểu số */
            else if ((featureLayer.Table.TableInfo.Columns[strColumnName].DataType == MapInfo.Data.MIDbType.Int) ||
               (featureLayer.Table.TableInfo.Columns[strColumnName].DataType == MapInfo.Data.MIDbType.SmallInt) ||
                (featureLayer.Table.TableInfo.Columns[strColumnName].DataType == MapInfo.Data.MIDbType.Double))
            {
                Decimal decimalOut;
                if (Decimal.TryParse(strKey, out decimalOut))
                    miCommand.CommandText = "select * from " + strTableName + " where (" + strColumnName + " = " + strKey + " ) and ( " + "MaDonViHanhChinh = '" + strMaDonViHanhChinh + "')" ;
                else
                {
                    System.Windows.Forms.MessageBox.Show("Vui lòng kiểm tra lại...  " + System.Environment.NewLine + "Dữ liệu phải là kiểu SỐ!", "DMCLand");
                    return null ;
                }
            }
            else
                return null ;
            //miCommand.Parameters.Add("@name",MapInfo.Data.MIDbType.Int);
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
                /* Chỉ lựa chọn khi có một đối tượng bản đồ được tìm thấy */
                /* Vì chọn tất cả các đối tượng tìm được sẽ làm chậm quá trình xử lý */
                if (irfc.Count == 1)
                {
                    /* Select Feature tìm được */
                    MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(irfc);
                    /* Zoom (nhìn) tòan bộ Feature được Select */
                    map.SetView(irfc.Envelope);
                }
            }
            /* Gắn các Feature tìm được cho hàm */
            return irfc;
        }
        /// <summary>
        /// Tìm kiếm Feature theo trường dữ liệu thuộc tính và giá trị có kiểu dữ liệu 
        /// tương ứng với trường thuộc tính đó, trong một đơn vị hành chính xác định.
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tìm</param>
        /// <param name="strTableName">Tên bảng (lớp) cần tìm</param>
        /// <param name="strColumnName">Tên cột cần tìm</param>
        /// <param name="strKey">Tên giá trị cần tìm</param>
        /// <param name="strMaDonViHanhChinh">Tên đơn vị hành chính</param>
        public MapInfo.Data.IResultSetFeatureCollection SearchWithColumnToBanDoSoThua(MapInfo.Mapping.Map map, string strTableName, string strSqlWhere, string strMaDonViHanhChinh)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return null;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strTableName */
            if (map.Layers[strTableName] == null)
                return null;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strTableName];
            /* Chắc chắn rằng tồn tại cột có tên là strColumnName1 */
            
            /* Chắc chắn rằng thửa đất cần tìm phải nằm trong một đơn vị hành chính có MÃ ĐƠN VỊ HÀNH CHÍNH xác định */
            if (strMaDonViHanhChinh == null)
                return null;
            if (strMaDonViHanhChinh == "")
                return null;            
            /* Khai báo đối tượng kết nối */
            MapInfo.Data.MIConnection miConnection = new MapInfo.Data.MIConnection();
            /* Mở kết nối */
            miConnection.Open();
            /* Khai báo đối tượng thực thi câu lệnh */
            MapInfo.Data.MICommand miCommand = miConnection.CreateCommand();
            /* Khai báo chuỗi truy vấn dữ liệu */
            /* Trường hợp trường có kiểu là String.
             Khi đó thực hiện kiểu truy vấn tương đối chuỗi */
      
                miCommand.CommandText = "select * from " + strTableName + " where " + strSqlWhere  +" ( " + "MaDonViHanhChinh = '" + strMaDonViHanhChinh + "')";
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
                /* Chỉ lựa chọn khi có một đối tượng bản đồ được tìm thấy */
                /* Vì chọn tất cả các đối tượng tìm được sẽ làm chậm quá trình xử lý */
                if (irfc.Count == 1)
                {
                    /* Select Feature tìm được */
                    MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(irfc);
                    /* Zoom (nhìn) tòan bộ Feature được Select */
                    map.SetView(irfc.Envelope);
                }
            }
            /* Gắn các Feature tìm được cho hàm */
            return irfc;
        }
        /// <summary>
        /// Tìm kiếm Feature theo trường dữ liệu thuộc tính và giá trị có kiểu dữ liệu 
        /// tương ứng với trường thuộc tính đó.
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tìm</param>
        /// <param name="strTableName">Tên bảng (lớp) cần tìm</param>
        /// <param name="strColumnName">Tên cột cần tìm</param>
        /// <param name="strKey">Tên giá trị cần tìm</param>
        public MapInfo.Data.IResultSetFeatureCollection SearchWithColumn(MapInfo.Mapping.Map map, string strTableName, string strColumnName, string strKey)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return null ;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strTableName */
            if (map.Layers[strTableName] == null)
                return null ;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strTableName];
            /* Chắc chắn rằng tồn tại cột có tên là strColumnName1 */
            if (!featureLayer.Table.TableInfo.Columns.Contains(featureLayer.Table.TableInfo.Columns[strColumnName]))
                return null ;
            /* Chắc chắn rằng tồn tại giá trị cần tìm */
            if (strKey == null)
                return null ;
            if (strKey == "")
                return null ;
            /////* Khai báo đối tượng kết nối */
            ////MapInfo.Data.MIConnection miConnection = new MapInfo.Data.MIConnection();
            /////* Mở kết nối */
            ////miConnection.Open();
            /////* Khai báo đối tượng thực thi câu lệnh */
            ////MapInfo.Data.MICommand miCommand = miConnection.CreateCommand();
            /////* Khai báo chuỗi truy vấn dữ liệu */
            /////* Trường hợp trường có kiểu là String.
            //// Khi đó thực hiện kiểu truy vấn tương đối chuỗi */
            ////if (featureLayer.Table.TableInfo.Columns[strColumnName].DataType == MapInfo.Data.MIDbType.String)
            ////{
            ////    miCommand.CommandText = "select * from [" + strTableName + "] where (" + strColumnName + " = @value )";
            ////    miCommand.Parameters.Add("@value", strKey);
            ////}
            /////* Trường hợp dữ liệu có kiểu số */
            ////else if ((featureLayer.Table.TableInfo.Columns[strColumnName].DataType == MapInfo.Data.MIDbType.Int) ||
            ////   (featureLayer.Table.TableInfo.Columns[strColumnName].DataType == MapInfo.Data.MIDbType.SmallInt) ||
            ////    (featureLayer.Table.TableInfo.Columns[strColumnName].DataType == MapInfo.Data.MIDbType.Double))
            ////{
            ////    Decimal decimalOut;
            ////    if (Decimal.TryParse(strKey, out decimalOut))
            ////        miCommand.CommandText = "select * from [" + strTableName + "] where (" + strColumnName + " = " + strKey + " )";
            ////    else
            ////    {
            ////        return null;
            ////    }
            ////}
            ////else
            ////    return null;
            ////miCommand.Parameters.Add("@name", MapInfo.Data.MIDbType.Int);
            /////* Nhận các đối tượng tìm được vào tâp hợp các Feature */
            ////MapInfo.Data.IResultSetFeatureCollection irfc = miCommand.ExecuteFeatureCollection();
            MapInfo.Data.Table table = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(strTableName);
            MapInfo.Data.IResultSetFeatureCollection irfc = MapInfo.Engine.Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("" + strColumnName + "= '" + strKey + "'")); // " like '%'+@name+'%')
            /* UnSelect những đối tượng đang được Select */
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            if (irfc.Count <= 0)
            {
                return null;
            }
            else
            {
                /* Trả về cho hàm tất cả những Feature tìm được */
                return irfc;
            }
        }

        /// <summary>
        /// Tìm kiếm Feature theo ID của đối tượng.
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp cần tìm</param>
        /// <param name="strTableName">Tên bảng (lớp) cần tìm</param>
        /// <param name="strKey">Tên giá trị cần tìm</param>
        public MapInfo.Data.IResultSetFeatureCollection SearchWithKey(MapInfo.Mapping.Map map, string strTableName, string strKey)
        {
            /* Khai báo tên trường chứa ID của đối tượng bản đồ */
            string strColumnName =  "SW_MEMBER";
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (map == null)
                return null;
            /* Chắc chắn rằng tồn tại lớp bản đồ có tên là strTableName */
            if (map.Layers[strTableName] == null)
                return null;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strTableName];
            /* Chắc chắn rằng tồn tại cột có tên là strColumnName1 */
            if (!featureLayer.Table.TableInfo.Columns.Contains(featureLayer.Table.TableInfo.Columns[strColumnName]))
                return null; 
            /* Chắc chắn rằng tồn tại giá trị cần tìm */
            if (strKey == null)
                return null;
            if (strKey == "")
                return null;
            /* Khai báo biến tạm chứa tập hợp các Feature tìm được */
            //MapInfo.Data.IResultSetFeatureCollection irfc = null;
            /* Gọi phương thức tìm Feature theo trường của bảng */
           // irfc = this.SearchWithColumn(map, strTableName, strColumnName, strKey);
            MapInfo.Data.Table table = null;
            table = MapInfo.Engine.Session.Current.Catalog.GetTable(strTableName);
            MapInfo.Data.IResultSetFeatureCollection irfc = MapInfo.Engine.Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchWhere("SW_MEMBER = " + strKey + "")); // " like '%'+@name+'%')
            /* Chắc chắn rằng chỉ có một Feature tìm được */
            if (irfc.Count != 1)
                return null;
            /* Trả về giá trị tìm được cho hàm */
            return irfc;
        }

        /// <summary>
        /// Tìm kiếm đối tượng theo tọa độ vị trí điểm cho trước 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="strAliasName"></param>
        /// <param name="strLayerName"></param>
        /// <param name="dPoint"></param>
        /// <returns></returns>
        public MapInfo.Data.IResultSetFeatureCollection searchWithPosition(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Geometry.DPoint dPoint) //, string strAliasName
        {
            MapInfo.Data.MIConnection connection = new MapInfo.Data.MIConnection();
            connection.Open();
            /* Chắc chắn rằng bản đồ tồn tại */
            if (map == null)
                return null;
            /* Chắc chắn rằng lớp tồn tại */
            if (map.Layers[strLayerName] == null)
                return null;
            /* Chắc chắn rằng lớp đang được hiển thị */
            if (map.Layers[strLayerName].Enabled != true)
                return null;
            /* Tạo đối tượng Distance từ bản đồ và khoảng cách điểm ảnh (pixelDistance) */
            MapInfo.Geometry.Distance distance = MapInfo.Mapping.SearchInfoFactory.ScreenToMapDistance(map, 1);
            /* Sử dụng lớp SearchInfoFactory để trả về một thông tin tìm kiếm dựa trên kiểu tìm kiếm.
             * Trong trường hợp này là SearchNearest */
            MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchNearest(dPoint, map.GetDisplayCoordSys(), distance);
            /* QueryDefinition (để trả về), trong trường hợp này là tất cả  các cột '*' */
            si.QueryDefinition.Columns = new string[] { "*" };
            /* Thực hiện tìm kiếm trên bảng, trả về một đối tượng IResultSetFeatureCollection ... */
            MapInfo.Data.IResultSetFeatureCollection irfc = MapInfo.Engine.Session.Current.Catalog.Search(strLayerName, si); // strAliasName
            return irfc;
        }
    }
}
