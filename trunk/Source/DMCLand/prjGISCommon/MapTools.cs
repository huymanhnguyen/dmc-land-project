using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public  class MapTools
    {
        /* Test */
        private void ExportMapToImage(MapInfo.Mapping.Map map, bool boolTransparentBackground)
        {
            try
            {
                MapInfo.Mapping.MapExport mxp = new MapInfo.Mapping.MapExport(map);
                mxp.Format = MapInfo.Mapping.ExportFormat.WindowsPng;
                if (boolTransparentBackground)
                {
                    mxp.TransparentColor = System.Drawing.Color.Orchid;
                    map.BackgroundBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Orchid);
                }
                else
                {
                    map.BackgroundBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi xuất bản đồ ra ảnh: " + System.Environment.NewLine + ex.Message , "DMCLand"
                    , System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        /* EndTest*/


        /// <summary>
        /// Nhận hình ảnh thửa đất từ bản đồ
        /// </summary>
        /// <param name="map">Đối tượng bản đồ cần nhận hình ảnh</param>
        /// <param name="dblPaperWidth">Chiều rộng kích thước ảnh cần xuất ra</param>
        /// <param name="dblPaperHeight">Chiều cao kích thước ảnh cần xuất ra</param>
        /// <returns>Giá trị trả về có kiểu mảng byte là hình ảnh bản đồ </returns>
        public  byte[] ExportMapToImage(MapInfo.Mapping.Map map, int intPaperWidth, int intPaperHeight)
        {
            byte[] byteImage = null;
            try
            {
                //Make a clone of the map
                MapInfo.Mapping.Map printMap = (MapInfo.Mapping.Map)map.Clone();
                //Create a MapExport object to export the cloned map to an image
                //The MapExport object has the option to remove the border around the image
                MapInfo.Mapping.MapExport exportObject = new MapInfo.Mapping.MapExport(printMap);
                /* Test - Nếu có thời gian cần kiểm tra lại phương thức này */
                exportObject.Map.SetView(map.Bounds.Center(), map.GetDisplayCoordSys(), map.Scale);
                /* EndTest */
                //Set preferred size here

                short scale = 1;
                //int intPaperWidth = exportObject.ExportSize.PixelSize.Width;
                //int intPaperHeight = exportObject.ExportSize.PixelSize.Height;
                short res = exportObject.ExportSize.Resolution;
                res = (short)(res * scale);

                exportObject.ExportSize = new MapInfo.Mapping.ExportSize(intPaperWidth * scale, intPaperHeight * scale, res);
                
                
                //exportObject.ExportSize = new MapInfo.Mapping.ExportSize(dblPaperWidth, dblPaperHeight);         
                exportObject.PixelFormat = MapInfo.Mapping.ExportPixelFormat.Format24bpp;
                
                //*** Turn off the black border ***
                exportObject.Border = MapInfo.Mapping.ExportBorder.Off;
                //Chose desired Format
                //exportObject.Format = MapInfo.Mapping.ExportFormat.Png;
                exportObject.Format = MapInfo.Mapping.ExportFormat.Tiff;
                exportObject.Transparent = true;

                exportObject.BorderPen.DashCap = System.Drawing.Drawing2D.DashCap.Flat;
                //Export the map to an image
                System.Drawing.Image printImage = exportObject.Export();

                /* Convert data type from Image to Byte Array */
                byteImage = this.imageToByteArray(printImage);

                ////Remove the cloned map from the MapFactory to free resources.
                //MapInfo.Engine.Session.Current.MapFactory.Remove(printMap);
                //printMap = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi xuất bản đồ ra ảnh: " + System.Environment.NewLine + ex.Message , "DMCLand"
                    , System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return byteImage;
        }
        /// <summary>
        /// Chuyển từ dữ liệu kiểu ảnh về giữ liệu kiểu mảng byte
        /// </summary>
        /// <param name="imageIn">Tham số truyền vào là dữ liệu kiểu anh</param>
        /// <returns>Giá trị trả về là dữ liệu kiểu mảng byte</returns>
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            try {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch(Exception ex ){
            
            }          
            
            return ms.ToArray();
        }

        /// <summary>
        /// Chuyển dữ liệu từ mảng byte về dữ liệu kiểu ảnh
        /// </summary>
        /// <param name="byteArrayIn">Tham số truyền vào là dữ liệu kiểu mảng byte</param>
        /// <returns>Giá trị trả về là dữ liệu kiểu ảnh</returns>
        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public void ViewEntireLayer(MapInfo.Mapping.Map map, string strLayerName )
        {
            try
            {
                /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
                if (map == null)
                    return;
                /* Chắc chắn rằng lớp thực hiện xem toàn bản đồ không phải là LableLayer */
                if (map.Layers[strLayerName].Type.ToString() == "Label")
                    return;
                MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
                /* Chắc chắn rằng tồn tại FeatureLayer với tên là strLayerName */
                if (featureLayer == null)
                    return;
                map.SetView(featureLayer);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi xem toàn bản đồ: " + System.Environment.NewLine + ex.Message , "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public void EditingMode(MapInfo.Windows.Controls.MapControl mapControl, MapInfo.Tools.EditMode editMode  )
        {
            /* Chắc chắn rằng tồn tại điều khiển bản đồ */
            if (mapControl == null)
                return;
            mapControl.Tools.SelectMapToolProperties.EditMode = editMode;
            //mapControl.Tools.SelectMapToolProperties.MoveDuplicateNodesMode = DuplicateNode.SameLayer;
        }


        public  void SnapEnable(MapInfo.Windows.Controls.MapControl mapControl, short shortSnapTolerance, bool  boolSnapEnable )
        {
            try
            {
                /* Chắc chắn rằng tồn tại điều khiển bản đồ */
                if (mapControl == null)
                    return;
                mapControl.Tools.MapToolProperties.SnapEnabled = boolSnapEnable;
                //= !mapControl.Tools.MapToolProperties.SnapEnabled;
                if (shortSnapTolerance < 0)
                    shortSnapTolerance = 0;
                mapControl.Tools.MapToolProperties.SnapTolerance = shortSnapTolerance;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi thiết lập chế độ bắt điểm: " + System.Environment.NewLine + ex.Message , "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public  MapInfo.Geometry.DPoint ConvertDisplayPointToMapPoint(MapInfo.Mapping.Map map, int intX, int intY)
        {
            /* Khai báo và khởi tạo tọa độ thực tương ứng tọa độ màn hình */
            MapInfo.Geometry.DPoint pointMap = new MapInfo.Geometry.DPoint();
            try
            {
                /* Khai báo và khởi tạo và gán giá trị tọa độ điểm click chuột (Tọa độ màn hình - Pixcel) */
                System.Drawing.PointF pointDisplay = new System.Drawing.PointF(intX, intY);
                /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
                if (map != null)
                {
                    /* Chuyển tọa độ Pixcel về tọa độ thực */
                    MapInfo.Geometry.DisplayTransform converter = map.DisplayTransform;
                    converter.FromDisplay(pointDisplay, out pointMap);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi chuyển tọa độ màn hình sang tọa độ bản đồ: " + System.Environment.NewLine + ex.Message 
                    , "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return pointMap;
        }

        #region Hiển thị
        /// <summary>
        /// Hiển thị THỬA ĐẤT được lựa chọn theo Mã thửa đất trên bản đồ tổng thể
        /// </summary>
        public void ShowLand(MapInfo.Mapping.Map  map, string strLayerName , string strMaThuaDat ,  string  strMaDonViHanhChinh)
        {
            try
            {
                /* Chắc chắn rằng tồn tại Mã thửa đất */
                if (strMaThuaDat == "")
                    return;
                /* Chắc chắn rằng tồn tại Mã đơn vị hành chính */
                if (strMaDonViHanhChinh == "")
                    return;
                DMC.GIS.Common.SearchTools searchTools = new SearchTools();
                searchTools.SearchWithColumn(map, strLayerName, "SW_Member", strMaThuaDat, strMaDonViHanhChinh);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi hiển thị Thửa đất lựa chọn trên bản đồ: " + System.Environment.NewLine + ex.Message 
                , "DMCLand" , System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị bản đồ tổng thể nhà đất
        /// </summary>
        /// <param name="map"> Đối tượng bản đồ </param>
        /// <param name="strConnection">Tên kết nối</param>
        /// <param name="strLandTableName">Tên bảng đất</param>
        /// <param name="strLandTableAliasName">Tên bí danh bảng đất</param>
        /// <param name="strBuildingTableName">Tên bảng nhà</param>
        /// <param name="strBuildingTableAliasName">Tên bí danh bảng nhà</param>
        /// <param name="strMaDonViHanhChinh">Mã đơn vị hành chính</param>
        /// <returns>Kết quả trả về là bản đồ được mở</returns>
        public MapInfo.Windows.Controls.MapControl ShowMap(MapInfo.Windows.Controls.MapControl map, string strConnection
            ,string strLandTableName, string strLandTableAliasName
            , string strBuildingTableName , string strBuildingTableAliasName
            , string strQuiHoachTableName, string strQuiHoachTableAliasName
            , string strMaDonViHanhChinh)
        {
            try
            {
                /* KIỂM TRA GIÁ TRỊ ĐẦU VÀO TRƯỚC KHI THỰC THI */
                /* Chắc chắn rằng tồn tại tên bảng ĐẤT */
                if (strLandTableName == null)
                    return null;
                else if (strLandTableName == "")
                    return null;
                /* Chắc chắn rằng tồn tại tên bảng NHÀ */
                if (strBuildingTableName == null)
                    return null;
                else if (strBuildingTableName == "")
                    return null;
                /* Chắc chắn rằng tồn tại tên đơn vị hành chính */
                if (strMaDonViHanhChinh == "")
                    return null;
                /* Chắc chắn rằng tồn tai chuỗi kết nối cơ sở dữ liệu */
                if (strConnection == "")
                    return null;

                /* Khai báo và khởi tạo kết nối */
                DMC.GIS.Common.LayerConnection layerConnection = new DMC.GIS.Common.LayerConnection();

                ///////* Khai báo và khởi tạo kết nối kiểu Mapinfo */
                //////MapInfo.Data.MIConnection miConnection = new MapInfo.Data.MIConnection();

                /* Khai báo biến chuỗi kết nối cơ sở dữ liệu không gian */
                string strMapConnection = "";
                /* Gán giá trị cho biến kết nối cơ sở dữ liệu không gian kiểu Mapinfo
                 bằng THUỘC TÍNH CONNECTION của lớp, kết hợp với tham số khác bao gồm:
                 1. Khai báo Driver: Driver = sQL Server
                 2. Không cho hiện hộp hồi thoại DLG = 0 */
                strMapConnection = "DRIVER=SQL Server;" + strConnection + ";DLG=0";
               
                /* Chắc chắn rằng có dữ liệu truyền vào là hợp lệ  */
                if ((strBuildingTableAliasName != "") && (strBuildingTableName != ""))
                {
                    /* Mở lớp nhà */
                    layerConnection.OpenLayer(ref map, strBuildingTableAliasName, strMapConnection, strBuildingTableName, strMaDonViHanhChinh);
                    
                }
               
                /* Chắc chắn rằng có dữ liệu truyền vào là hợp lệ  */
                if ((strLandTableAliasName != "") && (strLandTableName != ""))
                {
                    /* Mở lớp đất */
                  layerConnection.OpenLayer(ref map, strLandTableAliasName, strMapConnection, strLandTableName, strMaDonViHanhChinh);                  
                    
                }
                ///* Chắc chắn rằng có dữ liệu truyền vào là hợp lệ  */
                //if ((strQuiHoachTableAliasName != "") && (strQuiHoachTableName != ""))
                //{
                //    /* Mở lớp bản đồ qui hoạch */
                //    layerConnection.OpenLayer(ref map, strQuiHoachTableAliasName, strMapConnection, strQuiHoachTableName, strMaDonViHanhChinh);
                //}
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi hiển thị bản đồ: "
                    + System.Environment.NewLine + ex.Message, "DMCLand");
            }
            return map;
        }
        #endregion


        
    }
}
