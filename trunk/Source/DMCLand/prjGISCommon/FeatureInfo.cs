using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public  class FeatureInfo
    {
        /// <summary>
        /// Nhận ID của đối tượng
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public string GetSelectedLandID(MapInfo.Mapping.Map map, string strLayerName , string strIDColumnName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return null ;
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            if (featureLayer  == null)
                return null;
            /* Chắc chắn rằng tồn tại trường thuộc tính có tên là strIDColumnName */
            if (!featureLayer.Table.TableInfo.Columns.Contains(featureLayer.Table.TableInfo.Columns[strIDColumnName]))
                return null ;
            /* Khai báo và khởi tạo phương thức nhận Feature đang được select 
             trên một lớp xác định */
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            /* Khai báo một Feature tạm, là Feature đang được Select ở lớp strLayerName */
            MapInfo.Data.Feature feature = layerTools.GetSelectedFeature(map, strLayerName);
            /* Chắc chắn rằng có một Feature đang được Select */
            if (feature == null)
                return null;
            /* Chắc chắn rằng Feature đó có kiểu là kiểu vùng */
            if ((feature.Geometry.TypeName != "MultiPolygon") &&
                (feature.Geometry.TypeName != "Polygon") &&
                (feature.Geometry.TypeName != "Rectangle"))
                return null;
            /* Khai báo và khởi tạo biến có kiểu string, lưu trữ ID của THỬA ĐẤT */
            string strLandID = null;
            strLandID = feature[strIDColumnName].ToString();
            return strLandID;
        }

        /// <summary>
        /// Phương thức này nhận Feature kiểu VÙNG (THỬA ĐẤT) đang được Select trên bản đồ
        /// </summary>
        /// <param name="map"></param>
        /// <param name="strLayerName"></param>
        /// <returns></returns>
        public MapInfo.Data.Feature GetSelectedLandInfo(MapInfo.Mapping.Map map, string strLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return null;
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName */
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            if (featureLayer == null)
                return null;
            /* Khai báo và khởi tạo phương thức nhận Feature đang được select 
             trên một lớp xác định */
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            /* Khai báo một Feature tạm, là Feature đang được Select ở lớp strLayerName */
            MapInfo.Data.Feature feature = layerTools.GetSelectedFeature(map, strLayerName);
            /* Chắc chắn rằng có một Feature đang được Select */
            if (feature == null)
                return null;
            /* Chắc chắn rằng Feature đó có kiểu là kiểu vùng */
            if ((feature.Geometry.TypeName != "MultiPolygon") &&
                (feature.Geometry.TypeName != "Polygon") &&
                (feature.Geometry.TypeName != "Rectangle"))
                return null;
            return feature;
        }

    }

    
}
