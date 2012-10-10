using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace DMC.GIS.Common
{
    public  class SplitLand
    {
        /* Khai báo biến nhận chuỗi kết nối Database */
        private string strConnection = ""; 
        /* Khai báo thuộc tính nhận chuỗi kết nối Database */
        public string Connection
        {
            set
            {
                strConnection = value;
            }
        }
        private string strMaDonViHanhChinh = "";

        public string MaDonViHanhChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
        }
        private string strTenBangDat = "";

        public string TenBangDat
        {
            get { return strTenBangDat; }
            set { strTenBangDat = value; }
        }
        /// <summary>
        /// Tạo một tài liệu XML với danh sách mã thửa đất
        /// </summary>
        /// <param name="intDanhSachMaThua">Danh sách mã thửa đất</param>
        /// <returns>Giá trị trả về là một tài liệu XML chứa
        /// danh sách mã thửa đất</returns>
        public XmlDocument xmlThuaDat(string [] intDanhSachMaThua)
        {
            /* Chắc chắn rằng Tồn tại danh sách mã thửa đất */
            if (intDanhSachMaThua == null)
            {
                return null;
            }
            // Tạo một tài liệu mới rỗng.
            XmlDocument doc = new XmlDocument();
            // Tạo và chèn một phần tử mới.
            XmlNode nodeRoot = doc.CreateElement("root");
            doc.AppendChild(nodeRoot);

            XmlNode nodeThuaDat;
            XmlNode nameNode;

            for (int i = 0; i < intDanhSachMaThua.Length; i++)
            {
                // Tạo một phần tử lồng bên trong (cùng với một đặc tính).
                nodeThuaDat = doc.CreateElement("ThuaDat");
                nodeRoot.AppendChild(nodeThuaDat);
                // Tạo và thêm các phần tử con cho nút này
                // (cùng với dữ liệu text).
                nameNode = doc.CreateElement("MaThua");
                nameNode.AppendChild(doc.CreateTextNode(intDanhSachMaThua[i].ToString()));
                nodeThuaDat.AppendChild(nameNode);
            }
            return doc;
        }



        public void CancelSplit(MapInfo.Mapping.Map map, string strSplitLayerName, ref  MapInfo.Data.Feature featureSplit)
        {
            /* ------------------ ĐẢM BẢO RẰNG TỒN TẠI NHỮNG ĐỐI TƯỢNG CẦN THỰC THI -------------------*/
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp  có tên là strLayerName trong bản đồ.
             Ở đây lớp này chính là lớp THỬA ĐẤT chứa thửu đất mà bạn định tách*/
            if (map.Layers[strSplitLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại Feature.
             Ở đây Feature này chính là thửa đất bạn định tách*/
            if (featureSplit == null)
                return;
            /* -------------------THỰC THI HÀNH ĐỘNG HỦY LỆNH TÁCH THỬA -------------------------------*/
            /* Xóa Feature - Thửa đất định TÁCH */
            featureSplit = null;
            /* Xóa tất cả các Feature trong lớp THỬA ĐẤT */
            DMC.GIS.Common.FeatureTools featureTool = new DMC.GIS.Common.FeatureTools();
            featureTool.DeleteAllFeatures(map, strSplitLayerName);
        }

        public  MapInfo.Data.Feature PrepareSplit(MapInfo.Windows.Controls.MapControl mapControl, string strLandLayerName, string strSplitLandLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ đồ */
            if (mapControl.Map == null)
                return null ;
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName trong bản đồ */
            if (mapControl.Map.Layers[strLandLayerName] == null)
                return null ;
            /* Lựa chọn các Feature cần tách, ghép */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc;
            irfc = featureTools.SelectFeatures(mapControl.Map, strLandLayerName);
            /* Chắc chắn rằng tồn tại đối tượng được lựa chọn */
            if (irfc == null)
                return null  ;
            if (irfc.Count != 1)
            {
                System.Windows.Forms.MessageBox.Show("Chỉ chọn MỘT thửa đất để tách!");
                return null;
            }
            /* Tạo lớp tạm để tách, ghép */
            DMC.GIS.Common.LayerTools createFeatureLayer = new DMC.GIS.Common.LayerTools();


          

            bool boolCreateLayer = createFeatureLayer.CreateLayerWithTemplateLayer(mapControl.Map, strLandLayerName, strSplitLandLayerName);
            /* Khai báo một biến tạm kiểu Feature */
            MapInfo.Data.Feature featureTemp;
            featureTemp = irfc[0];
            DMC.GIS.Common.FeatureTools insertFeature = new DMC.GIS.Common.FeatureTools();
            /* Với một thửa đất được lựa chọn, ta đưa vào trong lớp trung gian có tên là strTempLayerName ("Thửa đất") để xử lý */
            insertFeature.insertFeatureToFeatureLayer(mapControl.Map, featureTemp, strSplitLandLayerName);
            /* Cho phép Edit lớp Thửa đất */
            DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
            layerTool.EditableLayer(mapControl, strSplitLandLayerName, true);
            /* Select thửa đất định tách */
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(irfc);
            /* Hiển thị thửa đất định tách lên toàn bản đồ */
            mapControl.Map.SetView(irfc.Envelope);
            /* Gán giá trị cho biến Feature cần tách (dùng chung) */
            return featureTemp;
        }
        public void NhatKyNguoiDung(string ChucNang, string MoTa, string strMaThuaDat)
        {
            prjNhatKyNguoiDung.clsNhatKyNguoiDung clsNhatky = new prjNhatKyNguoiDung.clsNhatKyNguoiDung();
            clsNhatky.Connection = strConnection;
            clsNhatky.MaHoSoCapGCN = "";
            clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh;
            clsNhatky.MaThuaDat = strMaThuaDat;
            clsNhatky.NghiepVu = "Tách thửa đất";
            clsNhatky.ChucNang = ChucNang;
            clsNhatky.MoTa = MoTa;
            clsNhatky.DuongDanFile = Application.StartupPath;
            clsNhatky.LuuNhatKyNguoiDung();
        }
        public  bool  ApplySplit(MapInfo.Mapping.Map map, string strLayerName, ref  MapInfo.Data.Feature featureSplit, string strLandSplitingLayerName)
        {
            //MapInfo.Mapping.Map map = MapInfo.Engine.Session.Current.MapFactory[mapControl1.Map.Alias]; // Giữ lại
            /* Lựa chọn tất cả các đối tượng trên lớp thửa đất */
            MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchAll();
            MapInfo.Data.IResultSetFeatureCollection irfc = MapInfo.Engine.Session.Current.Catalog.Search(strLandSplitingLayerName, si);
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            if (irfc.Count <= 0)
            {
                if( System.Windows.Forms.MessageBox.Show("KHÔNG tìm thấy đối tượng nào!" +
                        System.Environment.NewLine + " Bạn có muốn KẾT THÚC quá trình tách thửa không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes )
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
                DMC.GIS.Common.FeatureTools featureTool = new DMC.GIS.Common.FeatureTools();
                /* Khai báo tập các Feature chứa các Feature có kiểu là Region */
                /* Xác nhận các Feature có kiểu là Region trong tập các Feature */
                MapInfo.Data.Feature[] featuresRegion = featureTool.checkRegionsInFeatureCollection(irfc);
                /* Chắc chắn rằng tồn tại một Feature kiểu Region */
                if (featuresRegion == null)
                {
                    /* Xóa toàn bộ dữ liệu lớp TÁCH THỬA ĐẤT */
                    if ( System.Windows.Forms.MessageBox.Show("Thao tác tách thửa CHƯA ĐÚNG!" +
                    System.Environment.NewLine + " KHÔNG có thửa đất nào được cập nhật." +
                        System.Environment.NewLine + " Bạn có muốn KẾT THÚC quá trình tách thửa không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes )
                    {
                        featureTool.DeleteAllFeatures(map, strLandSplitingLayerName);
                        /* Kết thúc thực hiện */
                        return true;
                    }
                    else
                    {
                        /* Tiếp tục thực hiện */
                        return false;
                    }
                }
                /* Chỉ cập nhật trong trường hợp có nhiều hơn một vùng được tạo ra */
                if (featuresRegion.Length < 2)
                {
                    if ( System.Windows.Forms.MessageBox.Show("Thao tác tách thửa CHƯA ĐÚNG!" +
                        System.Environment.NewLine + " Bạn phải chắc chắn rằng có NHIỀU HƠN MỘT thửa đất cần cập nhật" +
                        System.Environment.NewLine + " Bạn có muốn KẾT THÚC quá trình tách thửa không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes )
                        {
                            /* Xóa toàn bộ dữ liệu lớp TÁCH THỬA ĐẤT */
                            featureTool.DeleteAllFeatures(map, strLandSplitingLayerName);
                            /* Kết thúc thực hiện */
                            return true;
                        }
                        else
                        {
                            /* Tiếp tục thực hiện */
                            return false;
                        }
                }
                /* Thông báo cho người dùng trước khi xác nhận tách thửa */
                System.Windows.Forms.DialogResult result;
                result = System.Windows.Forms.MessageBox.Show("Có: " + featuresRegion.Length.ToString() + " thửa đất mới được tạo" + System.Environment.NewLine +
                " Bạn có muốn CẬP NHẬT không", "DMCLand",System.Windows.Forms.MessageBoxButtons.YesNo );
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    /* Xóa toàn bộ dữ liệu lớp TÁCH THỬA ĐẤT */
                    featureTool.DeleteAllFeatures(map, strLandSplitingLayerName);
                    return true;
                }

                /* Add tất cả các Feature thành phần sau khi tách vào lớp đất */
                /* Nếu cập nhật thành công thì xóa dữ liệu rác */

                /* Khai báo danh sách mã thửa đất cần TÁCH */
                string [] intDanSachMaThua = new string [1];
                /* Gán giá trị cho danh sách mã thửa đất cần TÁCH */

                if (featureSplit.Key.Value.ToString().Split('.')[0] == null)
                {
                    return true;
                }
                intDanSachMaThua[0] = featureSplit.Key.Value.ToString().Split('.')[0];

                /* Tạo tài liệu XML chứa danh sách thửa đất cần ghép */
                XmlDocument xmlThuaDat = this.xmlThuaDat(intDanSachMaThua);
                featureTool.Connection = strConnection;
                string strMaThuaDatCon = "";
                featureTool.TenBangDat = strTenBangDat;
                if (featureTool.insertRegionsToFeatureLayer(map,featuresRegion, strLayerName,featureSplit,xmlThuaDat.InnerXml.ToString(),strMaThuaDatCon ))
                {
                    ///* Remove lớp THỬA ĐẤT khỏi bản đồ tổng thể */
                    //map.Layers.Remove(strTempLayerName);
                    /* Xóa toàn bộ dữ liệu lớp THỬA ĐẤT */
                    featureTool.DeleteAllFeatures(map, strLandSplitingLayerName);

                    /* ------------ XÓA THỬA ĐẤT CẦN TÁCH BẰNG CÔNG CỤ CỦA MAPXTREME ----------*/
                    ///* Delete thửa đất cần tách trên bản đồ ĐẤT */
                    //featureTool.DeleteFeature(map, featureSplit, strLayerName);

                    /* ------------ XÓA THỬA ĐẤT CẦN TÁCH BẰNG SQLSERVER ----------*/
                    /* Lưu thửa đất cần tách vào lịch sử biến động (tblDLieuKGianThuaDatLichSu)
                     * , đồng thời xóa thông tin của nó ở bảng dữ liệu hiện thời (tblDLieuKGianThuaDat)*/
                    DMC.GIS.Common.clsTachThua TachThua = new clsTachThua();
                    TachThua.Connection = strConnection;
                    TachThua.MaDonViHanhChinh = strMaDonViHanhChinh;
                    if (featureSplit.Key == null)
                    {
                        System.Windows.Forms.MessageBox.Show("Tách thửa KHÔNG thành công","DMCLand");
                        return true;
                    }

                    TachThua.MaThuaDat = Convert.ToInt64( featureSplit.Key.Value.ToString().Split('.')[0]);
                    TachThua.MaThuaDatCon = featureTool.MaThuaDatCon;
                    TachThua.LuuLichSuBienDong();
                    NhatKyNguoiDung("Tách", "Tách thửa đất " + featureSplit.Key.Value.ToString().Split('.')[0].ToString(), featureSplit.Key.Value.ToString().Split('.')[0].ToString());
                    /* Hiển thị lớp đất */
                    DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
                    layerTool.LayerEnable(map, strLayerName, true);
                }
            }
            return true;
        }
    }
}
