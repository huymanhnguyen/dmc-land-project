using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace DMC.GIS.Common
{
    public  class LandEditing
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
        private string strTenBangDat = "";

        public string TenBangDat
        {
            get { return strTenBangDat; }
            set { strTenBangDat = value; }
        }
        private string strMaDonViHanhChinh = "";

        public string MaDonViHanhChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
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

        public void CancelEdit(MapInfo.Mapping.Map map, string strEditingLayerName, ref  MapInfo.Data.Feature featureEditing)
        {
            /* ------------------ ĐẢM BẢO RẰNG TỒN TẠI NHỮNG ĐỐI TƯỢNG CẦN THỰC THI -------------------*/
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp  có tên là strLayerName trong bản đồ.
             Ở đây lớp này chính là lớp THỬA ĐẤT chứa thửu đất mà bạn định tách*/
            if (map.Layers[strEditingLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại Feature.
             Ở đây Feature này chính là thửa đất bạn định tách*/
            if (featureEditing == null)
                return;
            /* -------------------THỰC THI HÀNH ĐỘNG HỦY LỆNH TÁCH THỬA -------------------------------*/
            /* Xóa Feature - Thửa đất định TÁCH */
            featureEditing = null;
            /* Xóa tất cả các Feature trong lớp THỬA ĐẤT */
            DMC.GIS.Common.FeatureTools featureTool = new DMC.GIS.Common.FeatureTools();
            featureTool.DeleteAllFeatures(map, strEditingLayerName);
        }

        public MapInfo.Data.Feature PrepareEditing(MapInfo.Windows.Controls.MapControl mapControl, string strLandLayerName, string strLandEditingLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ đồ */
            if (mapControl.Map == null)
                return null;
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName trong bản đồ */
            if (mapControl.Map.Layers[strLandLayerName] == null)
                return null;
            /* Lựa chọn các Feature cần nắn chỉnh */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc;
            irfc = featureTools.SelectFeatures(mapControl.Map, strLandLayerName);
            /* Chắc chắn rằng tồn tại đối tượng được lựa chọn */
            if (irfc == null)
                return null;
            /* Chỉ cho phép nắn chỉnh từng thửa một */
            if (irfc.Count != 1)
            {
                System.Windows.Forms.MessageBox.Show("Chỉ chọn MỘT thửa đất để nắn chỉnh!");
                return null;
            }
            /* Tạo lớp tạm để nắn chỉnh */
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            bool boolCreateLayer = layerTools.CreateLayerWithTemplateLayer(mapControl.Map, strLandLayerName, strLandEditingLayerName);
            /* Khai báo một biến tạm kiểu Feature */
            MapInfo.Data.Feature featureTemp;
            featureTemp = irfc[0];
            //TachThua.FeatureTools featureTools = new FeatureTools();
            /* Với một thửa đất được lựa chọn, ta đưa vào trong lớp trung gian có tên là strTempLayerName ("Thửa đất") để xử lý */
            featureTools.insertFeatureToFeatureLayer(mapControl.Map, featureTemp, strLandEditingLayerName);
            /* Cho phép Edit lớp Thửa đất */
            DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
            layerTool.EditableLayer(mapControl, strLandEditingLayerName, true);
            /* Select thửa đất cần nắn chỉnh */
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(irfc);
            /* Hiển thị thửa đất cần nắn chỉnh lên toàn bản đồ */
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
            clsNhatky.NghiepVu = "Chỉnh sửa thửa đất";
            clsNhatky.ChucNang = ChucNang;
            clsNhatky.MoTa = MoTa;
            clsNhatky.DuongDanFile = Application.StartupPath;
            clsNhatky.LuuNhatKyNguoiDung();
        }
        public bool  ApplyEditing(MapInfo.Mapping.Map map, string strLayerName, ref  MapInfo.Data.Feature featureEdit, string strLandEditingLayerName)
        {
            //MapInfo.Mapping.Map map = MapInfo.Engine.Session.Current.MapFactory[mapControl1.Map.Alias]; // Giữ lại

            /* Lựa chọn tất cả các đối tượng trên lớp nắn chỉnh thửa đất */
            MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchAll();
            MapInfo.Data.IResultSetFeatureCollection irfc = MapInfo.Engine.Session.Current.Catalog.Search(strLandEditingLayerName, si);
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            if (irfc.Count <= 0)
            {
                if (System.Windows.Forms.MessageBox.Show("KHÔNG tìm thấy đối tượng nào!" +
                                            System.Environment.NewLine + " Bạn có muốn KẾT THÚC quá trình nắn chỉnh thửa không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes )
                {
                    /* Kết thúc thực hiện nắn chỉnh */
                    return true;
                }
                else
                {
                    /* Tiếp tục thực hiện nắn chỉnh */
                    return false;
                }
            }
            else
            {
                DMC.GIS.Common.FeatureTools featureTool = new DMC.GIS.Common.FeatureTools();
                featureTool.Connection = strConnection;
                featureTool.TenBangDat = strTenBangDat;
                /* Khai báo tập các Feature chứa các Feature có kiểu là Region */
                /* Xác nhận các Feature có kiểu là Region trong tập các Feature */
                MapInfo.Data.Feature[] featuresRegion = featureTool.checkRegionsInFeatureCollection(irfc);
                featureTool.TenBangDat = strTenBangDat;
                /* Chắc chắn rằng tồn tại một Feature kiểu Region */
                if (featuresRegion == null)
                {
                    /* CẦN KIỂM TRA LẠI PHẦN NÀY */
                    /* Xóa toàn bộ dữ liệu lớp NẮN CHỈNH THỬA ĐẤT */
                    if (System.Windows.Forms.MessageBox.Show("Thao tác nắn chỉnh CHƯA ĐÚNG!" +
                        System.Environment.NewLine + " KHÔNG có thửa đất nào được cập nhật." +
                        System.Environment.NewLine + " Bạn có muốn KẾT THÚC quá trình nắn chỉnh thửa không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes )
                    {
                        /* Xóa toàn bộ dữ liệu lớp NẮN CHỈNH THỬA ĐẤT */
                        featureTool.DeleteAllFeatures(map, strLandEditingLayerName);
                        /* Kết thúc thực hiện nắn chỉnh */
                        return true;
                    }
                    else
                    {
                        /* Tiếp tục thực hiện nắn chỉnh */
                        return false;
                    }
                }
                /* Chỉ cập nhật trong trường hợp chỉ có một vùng được tạo ra */
                if (featuresRegion.Length != 1)
                {
                    if (System.Windows.Forms.MessageBox.Show("Thao tác nắn chỉnh CHƯA ĐÚNG!" +
                        System.Environment.NewLine + " Bạn phải chắc chắn rằng chỉ có MỘT thửa đất cần cập nhật" +
                        System.Environment.NewLine + " Bạn có muốn KẾT THÚC quá trình nắn chỉnh thửa không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes )
                    {
                        /* Xóa toàn bộ dữ liệu lớp NẮN CHỈNH THỬA ĐẤT */
                        featureTool.DeleteAllFeatures(map, strLandEditingLayerName);
                        /* Kết thúc thực hiện nắn chỉnh */
                        return true;
                    }
                    else
                    {
                        /* Tiếp tục thực hiện nắn chỉnh */
                        return false;
                    }
                }
                /* Add Feature sau khi nắn chỉnh vào lớp đất
                   Nếu cập nhật thành công thì xóa dữ liệu rác */

                /* Khai báo danh sách mã thửa đất cần NẮN CHỈNH */
                string [] intDanSachMaThua = new string [1];
                /* Gán giá trị cho danh sách mã thửa đất cần NẮN CHỈNH */

                if (featureEdit.Key.Value.ToString().Split('.')[0] == null)
                {
                    /* Kết thúc thực hiện nắn chỉnh */
                    return true;
                }
                intDanSachMaThua[0] = featureEdit.Key.Value.ToString().Split('.')[0] ;

                /* Tạo tài liệu XML chứa danh sách thửa đất cần ghép */
                XmlDocument xmlThuaDat = this.xmlThuaDat(intDanSachMaThua);
                string strMaThuaDatCon = "";
                if (featureTool.insertRegionsToFeatureLayer(map, featuresRegion, strLayerName, featureEdit, xmlThuaDat.InnerXml.ToString(), strMaThuaDatCon))
                {
                    /* Xóa toàn bộ dữ liệu lớp NẮN CHỈNH THỬA ĐẤT */
                    featureTool.DeleteAllFeatures(map, strLandEditingLayerName);

                    /* ------------ XÓA THỬA ĐẤT CẦN TÁCH BẰNG CÔNG CỤ CỦA MAPXTREME ----------*/
                    ///* Delete thửa đất trước khi nắn chỉnh trên bản đồ ĐẤT */
                    //featureTool.DeleteFeature(map, featureEdit , strLayerName);

                    /* ------------ XÓA THỬA ĐẤT CẦN TÁCH BẰNG SQLSERVER ----------*/
                    /* Lưu thửa đất cần nắn chỉnh vào lịch sử biến động (tblDLieuKGianThuaDatLichSu)
                     * , đồng thời xóa thông tin của nó ở bảng dữ liệu hiện thời (tblDLieuKGianThuaDat)*/
                    DMC.GIS.Common.clsNanChinhThua NanChinh = new clsNanChinhThua();
                    NanChinh.Connection = strConnection;
                    NanChinh.MaDonViHanhChinh = strMaDonViHanhChinh;


                    if (featureEdit.Key == null)
                    {
                        System.Windows.Forms.MessageBox.Show("Tách thửa KHÔNG thành công", "DMCLand");
                        /* Kết thúc thực hiện nắn chỉnh */
                        return true;
                    }

                    NanChinh.MaThuaDat = Convert.ToInt32(featureEdit.Key.Value.ToString().Split('.')[0]);
                    NanChinh.MaThuaDatCon = featureTool.MaThuaDatCon;
                    featureTool.TenBangDat = strTenBangDat;
                    clsDatabase clsdata = new clsDatabase();
                    
                    NanChinh.LuuLichSuBienDong();
                    clsdata.GanLaiDuLieuBanDoVaThuocTinh(strTenBangDat, strMaDonViHanhChinh, featureEdit["ToBanDo"].ToString(), featureEdit["SoThua"].ToString(), strConnection);
                    NhatKyNguoiDung("Nắn chỉnh", "nắn chỉnh To Ban Do : " + featureEdit["ToBanDo"].ToString() + "; So thua:  " + featureEdit["SoThua"].ToString() + "", featureEdit.Key.Value.ToString().Split('.')[0].ToString());
                    /* Hiển thị lớp đất */
                    DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
                    layerTool.LayerEnable(map, strLayerName, true);
                }
            }
            /* Kết thúc thực hiện nắn chỉnh */
            return true;
        }
    }
}
