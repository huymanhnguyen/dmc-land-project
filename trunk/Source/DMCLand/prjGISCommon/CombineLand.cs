using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace DMC.GIS.Common
{
    public  class CombineLand
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
        public XmlDocument xmlThuaDat(string  [] intDanhSachMaThua,string strThuaCon)
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
            XmlNode nameNodeThuaDat;
            XmlNode nameNodeLoaiBienDong;

            for (int i = 0; i < intDanhSachMaThua.Length; i++)
            {
                // Tạo một phần tử lồng bên trong (cùng với một đặc tính).
                nodeThuaDat = doc.CreateElement("ThuaDat");
                nodeRoot.AppendChild(nodeThuaDat);
                // Tạo và thêm các phần tử con cho nút này
                // (cùng với dữ liệu text).
                nameNodeThuaDat = doc.CreateElement("MaThua");
                nameNodeLoaiBienDong = doc.CreateElement("LoaiBienDong");
                nameNodeThuaDat.AppendChild(doc.CreateTextNode(intDanhSachMaThua[i].ToString()));
                nameNodeLoaiBienDong.AppendChild(doc.CreateTextNode("1".ToString() ));
                nodeThuaDat.AppendChild(nameNodeThuaDat);
                nodeThuaDat.AppendChild(nameNodeLoaiBienDong);
            }
            return doc;
        }

        public void CancelCombine(MapInfo.Mapping.Map map, string strCombineLayerName, ref  MapInfo.Data.Feature[] featuresCombine)
        {
            /* ------------------ ĐẢM BẢO RẰNG TỒN TẠI NHỮNG ĐỐI TƯỢNG CẦN THỰC THI -------------------*/
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                return;
            /* Chắc chắn rằng tồn tại lớp  có tên là strLayerName trong bản đồ.
             Ở đây lớp này chính là lớp THỬA ĐẤT chứa thửu đất mà bạn định tách*/
            if (map.Layers[strCombineLayerName] == null)
                return;
            /* Chắc chắn rằng tồn tại Feature.
             Ở đây Feature này chính là thửa đất bạn định tách*/
            if (featuresCombine  == null)
                return;
            /* -------------------THỰC THI HÀNH ĐỘNG HỦY LỆNH TÁCH THỬA -------------------------------*/
            /* Xóa Feature - Thửa đất định TÁCH */
            featuresCombine  = null;
            /* Xóa tất cả các Feature trong lớp THỬA ĐẤT */
            DMC.GIS.Common.FeatureTools featureTool = new DMC.GIS.Common.FeatureTools();
            featureTool.TenBangDat = strTenBangDat;
            featureTool.DeleteAllFeatures(map, strCombineLayerName );
        }

        public  MapInfo.Data.Feature[] PrepareCombine(MapInfo.Windows.Controls.MapControl mapControl, string strLayerName,  string strTempLayerName)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ trong điều khiển bản đồ mapControl */
            if (mapControl.Map == null)
                return null;
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName trong bản đồ */
            if (mapControl.Map.Layers[strLayerName] == null)
                return null;
            /* Lựa chọn các Feature cần tách, ghép */
            DMC.GIS.Common.FeatureTools featureTools = new DMC.GIS.Common.FeatureTools();
            MapInfo.Data.IResultSetFeatureCollection irfc;
            irfc = featureTools.SelectFeatures(mapControl.Map, strLayerName);
            /* Xác định các Region trong các đối tượng được Select */
            MapInfo.Data.Feature[] featuresRegion = featureTools.checkRegionsInFeatureCollection(irfc);
            /* Chắc chắn rằng tồn tại đối tượng kiểu Vùng được lựa chọn */
            if ( featuresRegion == null)
                return null  ;
            /* Chắc chắn rằng có nhiều hơn một VÙNG (THỬA) cần ghép */
            if (featuresRegion.Length <= 1)
            {
                System.Windows.Forms.MessageBox.Show("Hãy chọn NHIỀU HƠN MỘT thửa đất để ghép!");
                return null;
            }
            /* Tạo lớp tạm để tách, ghép */
            DMC.GIS.Common.LayerTools createFeatureLayer = new DMC.GIS.Common.LayerTools();
            bool boolCreateLayer = createFeatureLayer.CreateLayerWithTemplateLayer(mapControl.Map, strLayerName, strTempLayerName);
            /* Với các đối tượng được lựa chọn, ta đưa vào trong lớp tạm để xử lý */
            featureTools.insertRegionsToFeatureLayer(mapControl.Map, featuresRegion, strTempLayerName);
            /* Cho phép Edit lớp Thửa đất */
            DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
            layerTool.EditableLayer(mapControl, strTempLayerName, true);
            /* Lựa chọn những thửa đất định ghép */
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(irfc);
            /* Hiển thị những thửa đất định ghép lên toàn màn hình */
            mapControl.Map.SetView(irfc.Envelope);
            /* */
            return featuresRegion;
        }
        public void NhatKyNguoiDung(string ChucNang, string MoTa, string strMaThuaDat)
        {
            prjNhatKyNguoiDung.clsNhatKyNguoiDung clsNhatky = new prjNhatKyNguoiDung.clsNhatKyNguoiDung();
            clsNhatky.Connection = strConnection;
            clsNhatky.MaHoSoCapGCN = "";
            clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh;
            clsNhatky.MaThuaDat = strMaThuaDat;
            clsNhatky.NghiepVu = "Ghép thửa đất";
            clsNhatky.ChucNang = ChucNang;
            clsNhatky.MoTa = MoTa;
            clsNhatky.DuongDanFile = Application.StartupPath;
            clsNhatky.LuuNhatKyNguoiDung();
        }
        public  bool   ApplyCombine(MapInfo.Mapping.Map map, string strLayerName, MapInfo.Data.Feature[] featuresCombine, string strLandCombiningLayerName)
        {
            //MapInfo.Mapping.Map map = MapInfo.Engine.Session.Current.MapFactory[mapControl1.Map.Alias]; // Giữ lại
            /* Chắc chắn rằng tồn tại đối tượng bản đồ - map */
            if (map == null)
                /* Kết thức thực hiện ghép thửa*/
                return true;
            /* Chắc chắn rằng tồn tại lớp có tên là strLayerName trên bản đồ */
            if (map.Layers[strLayerName] == null)
                /* Kết thúc thực hiện ghép thửa*/
                return true;
            /* Chắc chắn rằng tồn tại lớp có tên là strTempLayerName trên bản đồ */
            if (map.Layers[strLandCombiningLayerName] == null)
                /* Kết thúc thực hiện ghép thửa*/
                return true;            
            /* Chắc chắn rằng tồn tập các Feature cần gộp
             những Feature này sẽ được xóa trong ở phương thức này*/
            if (featuresCombine == null)
                /* Kết thúc thực hiện ghép thửa */
                return true;

            /* KIỂM TRA LẠI ĐOẠN CODE NÀY */
            /* -------------------------------------------------------- */
            /* Khai báo biến, nhận chỉ số thửa đất sau khi gộp */
            string strCombiningLandIndex = "";
            strCombiningLandIndex = CombiningLandIndex(featuresCombine); 
            /* -------------------------------------------------------- */

            /* Xác định Feature chính trong các Feature cần gộp. 
             Thực chất của việc này nhằm lấy MÃ ĐƠN VỊ HÀNH CHÍNH và SỐ HIỆU TỜ BẢN ĐỒ
             theo THỬA ĐẤT CÓ DIỆN TÍCH LỚN NHẤT */
            MapInfo.Data.Feature featureMain = this.FeatureMain(featuresCombine);

            /* Lựa chọn tất cả các đối tượng trên lớp thửa đất */
            MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchAll();
            MapInfo.Data.IResultSetFeatureCollection irfc = MapInfo.Engine.Session.Current.Catalog.Search(strLandCombiningLayerName, si);
            ////MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            if (irfc.Count <= 0)
            {
                if ( System.Windows.Forms.MessageBox.Show("KHÔNG tìm thấy đối tượng nào!" +
                        System.Environment.NewLine + " Bạn có muốn KẾT THÚC quá trình ghép thửa không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
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
                featureTool.TenBangDat = strTenBangDat;
                MapInfo.Data.Feature[] featuresRegion = featureTool.checkRegionsInFeatureCollection(irfc);
                /* Chắc chắn rằng tồn tại Feature kiểu Region */
                if (featuresRegion == null)
                {
                    /* Xóa toàn bộ dữ liệu lớp GHÉP THỬA ĐẤT */
                    if ( System.Windows.Forms.MessageBox.Show("Thao tác GHÉP thửa CHƯA ĐÚNG!" +
                        System.Environment.NewLine + " KHÔNG có thửa đất nào được cập nhật." +
                        System.Environment.NewLine + " Bạn có muốn KẾT THÚC quá trình ghép thửa không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        featureTool.DeleteAllFeatures(map, strLandCombiningLayerName);
                        /* Kết thúc thực hiện */
                        return true;
                    }
                    else
                    {
                        /* Tiếp tục thực hiện */
                        return false;
                    }
                }
                /* Chỉ cập nhật trong trường hợp có DUY NHẤT MỘT vùng được tạo ra */
                if (featuresRegion.Length != 1)
                {
                    if ( System.Windows.Forms.MessageBox.Show("Thao tác GHÉP thửa CHƯA ĐÚNG!" +
                    System.Environment.NewLine + "Bạn phải chắc chắn rằng có DUY NHẤT MỘT thửa đất được tạo thành!" +
                        System.Environment.NewLine + " Bạn có muốn KẾT THÚC quá trình ghép thửa không?", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            /* Xóa toàn bộ dữ liệu lớp GHÉP THỬA ĐẤT */
                            featureTool.DeleteAllFeatures(map, strLandCombiningLayerName);
                            /* Kết thúc thực hiện */
                            return true;
                        }
                        else
                        {
                            /* Tiếp tục thực hiện */
                            return false;
                        }
                }
                /* Thông báo cho người dùng trước khi xác nhận GHÉP THỬA */
                System.Windows.Forms.DialogResult result;
                result = System.Windows.Forms.MessageBox.Show(" Bạn có muốn cập nhật không", "DMCLand", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    /* Xóa toàn bộ dữ liệu lớp GHÉP THỬA ĐẤT */
                    featureTool.DeleteAllFeatures(map, strLandCombiningLayerName);
                    /* Kết thúc thực hiện */
                    return true;
                }
                ///* Khai báo biến, nhận chỉ số thửa đất sau khi gộp */
                //string strCombiningLandIndex = "";
                //strCombiningLandIndex = CombiningLandIndex(ref  featuresCombine); 
                /* Khai báo và gán giá trị cho Feature kiểu Region cần insert vào lớp thửa đất */
                MapInfo.Data.Feature featureRegion = featuresRegion[0];
                /* Add Feature đã Combine vào lớp đất */
                /* Nếu cập nhật thành công thì xóa dữ liệu cũ */

                /* Khai báo danh sách mã thửa đất cần ghép */
                string [] intDanSachMaThua = new string [featuresCombine.Length];
                /* Gán giá trị cho danh sách mã thửa đất cần ghép */
                for (int i = 0; i < featuresCombine.Length; i++)
                {
                    if (featuresCombine[i].Key.Value.ToString().Split('.')[0] == null)
                    {
                        /* Kết thúc thực hiện */
                        return true;
                    }
                    intDanSachMaThua[i] =   featuresCombine[i].Key.Value.ToString().Split('.')[0] ;
                }
                /* Tạo tài liệu XML chứa danh sách thửa đất cần ghép */
                XmlDocument xmlThuaDat = this.xmlThuaDat( intDanSachMaThua,"123".ToString());

                if (featureTool.insertRegionToFeatureLayer(map, featureRegion, strLayerName, strCombiningLandIndex, featureMain, xmlThuaDat.InnerXml.ToString()))
                {
                    ///* Remove lớp THỬA ĐẤT khỏi bản đồ tổng thể */
                    //map.Layers.Remove(strTempLayerName);
                    /* Xóa toàn bộ dữ liệu trên lớp  THỬA ĐẤT */
                    featureTool.DeleteAllFeatures(map, strLandCombiningLayerName);


                    ///* Delete thửa đất cần tách trên bản đồ ĐẤT */
                    //featureTool.DeleteFeatures(map, ref  featuresCombine, strLayerName);

                    /* LƯU TOÀN BỘ THỬA ĐẤT CẦN GHÉP VÀO LỊCH SỬ (tblDLieuKGianThuaDatLichSu) VÀ
                     * XÓA CHÚNG Ở BẢNG THỬA ĐẤT HIỆN THỜI (tblDLieuKGianThuaDat) */

                    /* Gọi phương thức để lưu các thửa đất cần ghép vào lịch sử và xóa chúng ở
                     * bảng thửa đất hiện thời */
                    DMC.GIS.Common.clsGhepThua GhepThua = new clsGhepThua();
                    GhepThua.Connection = strConnection;
                    GhepThua.MaDonViHanhChinh = strMaDonViHanhChinh;
                    GhepThua.ThuaDat = xmlThuaDat.InnerXml.ToString();
                    GhepThua.LuuLichSuBienDong();
        //            Dim nodelist As XmlNodeList = xmlDocument.DocumentElement.ChildNodes
        //If nodelist.Count > 0 Then
        //    strUserName = nodelist(0).ChildNodes(0).InnerText
        //End If
                    NhatKyNguoiDung("Ghép", "Ghép thửa đất " + xmlThuaDat.InnerXml.ToString(),"");
                    /* Hiển thị lớp đất */
                    DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
                    layerTool.LayerEnable(map, strLayerName, true);
                }
            }
            return true;
        }

        public MapInfo.Data.Feature FeatureMain(MapInfo.Data.Feature[] featuresCombine)
        {
            /* Chắc chắn rằng tồn tại Feature trong mảng featureCombine */
            if (featuresCombine == null)
                return null ;
            /* Khai báo MultiPolygon */
            MapInfo.Geometry.MultiPolygon multiPolygon = null;
            /* Khai báo Feature tạm thời */
            MapInfo.Data.Feature featureTemp = null;
            /* Khai báo biến diện tích tạm thời */
            double dblMaxArea = 0.0;

            foreach (MapInfo.Data.Feature feature in featuresCombine)
            {
                if (feature.Geometry.TypeName == "MultiPolygon")
                {
                    multiPolygon = (MapInfo.Geometry.MultiPolygon)feature.Geometry;
                    /* Khai báo Feature tạm */
                    if (dblMaxArea < multiPolygon.Area(MapInfo.Geometry.AreaUnit.SquareMeter))
                    {
                        dblMaxArea = multiPolygon.Area(MapInfo.Geometry.AreaUnit.SquareMeter);
                        featureTemp = feature;
                    }

                }
            }
            return featureTemp;
        }

        public string CombiningLandIndex(MapInfo.Data.Feature[] featuresCombine)
        {
            /* Chắc chắn rằng tồn tại Feature trong mảng featureCombine */
            if (featuresCombine == null)
                return "";
            /* Khai báo biến trung gian kiểu String. Lưu Số hiệu thửa đất sau khi
             thực hiên thao tác GỘP THỬA */
            string strCombiningLandIndex = "";
            /* Khai báo biến trung gian xác định chỉ số Feature thành phần trong
             tập các Feature */
            int intFeatureIndex = 0;
            ///* Khai báo 1 Feature có các trường như các Feature trong featureCombine */
            //MapInfo.Data.Feature featureTemp = new MapInfo.Data.Feature(featuresCombine[0].Table.TableInfo.Columns);  

            foreach (MapInfo.Data.Feature feature in featuresCombine)
            {
                intFeatureIndex += 1;
                /* Khai báo Feature tạm */
                if (intFeatureIndex ==1 )
                    //featureTemp["SoThua"]  += "(" + feature["SoThua"].ToString().Trim() + ")";
//                    strCombiningLandIndex += "[" + feature["SoThua"].ToString().Trim() + "]";
                    strCombiningLandIndex += "" + feature["SoThua"].ToString().Trim() + "";//sua theo long bien
                else
                    //featureTemp["SoThua"] += "+" + "(" + feature["SoThua"].ToString().Trim() + ")";
                    //strCombiningLandIndex += "+" + "[" + feature["SoThua"].ToString().Trim() + "]";
                strCombiningLandIndex += "+" + "" + feature["SoThua"].ToString().Trim() + "";//sua theo long bien
            }
            return strCombiningLandIndex;
        }
    }
}
