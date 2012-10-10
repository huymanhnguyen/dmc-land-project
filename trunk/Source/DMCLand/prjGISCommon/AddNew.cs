using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public  class AddNew
    {

        /* Khai báo biến nhận mã đơn vị hành chính */
        private int intMaDonViHanhChinh = 0;
        /* Khai báo thuộc tính nhận mã đơn vị hành chính */
        public int MaDonViHanhChinh
        {
            set
            {
                intMaDonViHanhChinh  = value;
            }
        }

        public void CancelAddNew(MapInfo.Mapping.Map map, string strAddNewLayerName)
        {
            /* ------------------ ĐẢM BẢO RẰNG TỒN TẠI NHỮNG ĐỐI TƯỢNG CẦN THỰC THI -------------------*/
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp  có tên là strLayerName trong bản đồ.
             Ở đây lớp này chính là lớp THỬA ĐẤT chứa thửu đất mà bạn định tách*/
            if (map.Layers[strAddNewLayerName] == null)
                return;
            /* -------------------THỰC THI HÀNH ĐỘNG HỦY LỆNH TÁCH THỬA -------------------------------*/
            /* Xóa tất cả các Feature trong lớp có tên là strAddNewLayerName - THỬA ĐẤT */
            DMC.GIS.Common.FeatureTools featureTool = new DMC.GIS.Common.FeatureTools();
            featureTool.DeleteAllFeatures(map, strAddNewLayerName);

        }

        public bool  PrepareAddNew(MapInfo.Windows.Controls.MapControl mapControl, string strLandLayerName, string strAddNewLandLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ đồ */
            if (mapControl.Map == null)
                return false ;
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName trong bản đồ */
            if (mapControl.Map.Layers[strLandLayerName] == null)
                return false;
            else
            {
                /* Nếu CHƯA tồn tại thì tạo lớp tạm có tên là strAddNewLandLayerName - THỬA ĐẤT */
                DMC.GIS.Common.LayerTools createFeatureLayer = new DMC.GIS.Common.LayerTools();
                bool boolCreateLayer = createFeatureLayer.CreateLayerWithTemplateLayer(mapControl.Map, strLandLayerName, strAddNewLandLayerName);
                
            }
            /* Cho phép Edit lớp có tên là strAddNewLandLayerName - THỬA ĐẤT */
            DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
            layerTool.EditableLayer(mapControl, strAddNewLandLayerName , true);
            return true;
        }

        public bool  ApplyAddNew(MapInfo.Mapping.Map map, string strLayerName, string strTempLayerName)
        {
            //MapInfo.Mapping.Map map = MapInfo.Engine.Session.Current.MapFactory[mapControl1.Map.Alias]; // Giữ lại
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            /* Lựa chọn tất cả các đối tượng trên lớp có tên là strTempLayerName - THỬA ĐẤT */
            MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchAll();
            MapInfo.Data.IResultSetFeatureCollection irfc = MapInfo.Engine.Session.Current.Catalog.Search(strTempLayerName, si);
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            /* Kiểm tra các đối tượng được chọn, chỉ lấy đối tượng dạng vùng */
            MapInfo.Data.Feature[] featuresRegion = featureTools.checkRegionsInFeatureCollection(irfc);
            /* Chỉ thực thi khi tồn tại VÙNG (THỬA ĐẤT) được lựa chọn để thêm vào lớp */
            if (featuresRegion == null)
            {
                if (System.Windows.Forms.MessageBox.Show("KHÔNG tìm thấy THỬA nào được tạo ra!" +
                        System.Environment.NewLine + " Bạn có muốn KẾT THÚC việc thêm mới không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    /* Kết thúc thực hiện */
                    return true;
                }
                else
                {
                    /* Tiếp tục thực hiện */
                    return false;
                }
            }
            /* Chỉ thực thi khi có ít nhất một VÙNG (THỬA ĐẤT) được lựa chọn để thêm vào lớp */
            if (featuresRegion.Length < 1)
            {
                if (System.Windows.Forms.MessageBox.Show("KHÔNG tìm thấy đối tượng nào!" +
                        System.Environment.NewLine + " Bạn có muốn KẾT THÚC việc thêm mới không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    /* Kết thúc thực hiện */
                    return true;
                }
                else
                {
                    /* Tiếp tục thực hiện */
                    return false;
                }
            }
            else
            {
                /* Add tất cả các Feature thành phần sau khi tách vào lớp đất */
                /* Nếu cập nhật thành công thì xóa dữ liệu rác */
                if (featureTools.insertRegionsToFeatureLayer(map, featuresRegion, strLayerName, intMaDonViHanhChinh))
                {
                    /* Xóa toàn bộ dữ liệu lớp THỬA ĐẤT */
                    featureTools.DeleteAllFeatures(map, strTempLayerName);
                    /* Hiển thị lớp đất */
                    DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
                    layerTools.LayerEnable(map, strLayerName, true);
                }
            }
            /* Kết thúc thực hiện */
            return true;
        }
    }
}
