using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MapInfo.Geometry;
using DMC.GIS.Common;
using MapInfo;
using MapInfo.Mapping ;
using MapInfo.Data ;

namespace DMC.Land.TinhToanDenBu
{
    public partial class ctrlTinhToanDenBu : UserControl
    {
        public ctrlTinhToanDenBu()
        {
            InitializeComponent();
        }

        private string strLayerDenBu ="Phần đền bù";

        /* Khai báo biến Mã đơn vị hành chính */
        private string strMaDonViHanhChinh;
        /* Khai báo chuỗi kết nối */
        private string strConnection = "";
        /* Khai báo thuộc tính chuỗi kết nối cơ sở dữ liệu */
        public string Connection
        {
            get { return strConnection; }
            set { strConnection = value; }
        }
        public string DonViHanhChinh
        {
            get { return strMaDonViHanhChinh ; }
            set { strMaDonViHanhChinh = value; }
        }
        /// <summary>
        /// Thiết lập ban đầu cho Bản đồ */
        /// </summary>
        private void SetupLoad()
        {
            /* Đặt tên cho bản đồ */
            mapControl1.Map.Name = "Bản đồ địa chính";
            mapControl1.Map.Zoom = new MapInfo.Geometry.Distance(1500, DistanceUnit.Meter);
            /* Không hiển thị ToolTip */
            lyrControl.ToolTip.Active = false;
            /* Thiết lập cho LayerControl */
            lyrControl.Map = mapControl1.Map;
            lyrControl.Tools = mapControl1.Tools;
            lyrControl.CheckBoxes = true;
            lyrControl.TabControl.Visible = false;
            lyrControl.ToolBar.Buttons[0].Visible = false;
            lyrControl.ToolBar.Buttons[1].Visible = false;
            lyrControl.ToolBar.Buttons[2].Visible = false;
            /* Thiết lập cho MapToolBar */
            mapToolBar.MapControl.Map = mapControl1.Map;
            mapToolBar.MapControl.Tools = mapControl1.Tools;

        }


        /// <summary>
        /// Xác nhận vùng giải phóng mặt bằng 
        /// </summary>
        /// <param name="map">Đối tượng bản đồ chứa lớp thông tin vùng giải phóng 
        /// mặt bằng và chứa lớp Thửa đất</param>
        /// <param name="strLopGiaiPhongMatBang">Tên Lớp giải phóng mặt bằng</param>
        /// <returns>Giá trị trả về là vùng giải phóng mặt bằng đã được lựa chọn</returns>
        private MapInfo.Data.Feature VungGiaiPhongMatBang(MapInfo.Mapping.Map map, string strLopGiaiPhongMatBang)
        {
            /* Khai báo vùng giải phóng Mặt bằng tạm thời */
            MapInfo.Data.Feature featureTemp = null;
            try
            {
                /* Chắc chắn tồn tại đối tượng bản đồ */
                if (map == null)
                {
                    return null;
                }
                /* Chắc chắn tồn tại lớp Giải phóng mặt bằng */
                if (map.Layers[strLopGiaiPhongMatBang] == null)
                    return null;
                /* Xác nhận vùng giải phóng mặt bằng */
                DMC.GIS.Common.FeatureInfo featureInfo = new DMC.GIS.Common.FeatureInfo();
                featureTemp = featureInfo.GetSelectedLandInfo(map, strLopGiaiPhongMatBang);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi xác nhận Vùng giải phóng mặt bằng" , "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /* Trả về vùng giải phóng mặt bằng nhận được */
            return featureTemp;
        }
        private void CapNhatThongTinVungDenBu(MapInfo.Mapping.Map map, string strTenLopThuaDat, string strTenLopGiaiPhongMatBang)
        {

            /* Khai báo Feature là vùng qui hoạch được lựa chọn để tính toán đền bù*/
            MapInfo.Geometry.FeatureGeometry fgQuiHoach = null;
            /* Khai báo và khởi tạo tập hợp các thửa đất bị cắt bởi chỉ giới đường đỏ */
            MapInfo.Data.IResultSetFeatureCollection irfcThuaDatTrongQuiHoach = null;
            /* Kiểm tra tính hợp lệ của dữ liệu */
            /* Chắc chắn rằng tồn tại đối tượng bản đồ trong điều khiển bản đồ mapControl */
            if (map == null)
                return;
            /* Kiểm tra sự tồn tại của lớp thửa đất */
            if (map.Layers[strTenLopThuaDat] == null)
                return;
            /* Kiểm tra sự tồn tại của lớp denn bu */
            if (map.Layers[strLayerDenBu] == null)
                return;
            /* Kiểm tra sự tồn tại của lớp Giải phóng mặt bằng */
            if (map.Layers[strTenLopGiaiPhongMatBang] == null)
                return;
            /* Xác định một vùng được lựa chọn để tính toán đền bù */
            //lay vung giai phong mat bang
            MapInfo.Data.Feature featureSelected = null;
            Table tabVungGiaiPhong = MapInfo.Engine.Session.Current.Catalog.GetTable(strTenLopGiaiPhongMatBang);
            Table tabVungDenBu = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerDenBu);
            MapInfo.Data.IResultSetFeatureCollection fc = MapInfo.Engine.Session.Current.Catalog.Search(tabVungGiaiPhong, MapInfo.Data.SearchInfoFactory.SearchAll());
            MapInfo.Data.IResultSetFeatureCollection fcDenBu = MapInfo.Engine.Session.Current.Catalog.Search(tabVungDenBu, MapInfo.Data.SearchInfoFactory.SearchAll());
            if (fc.Count == 1)
            {
                featureSelected = fc[0];
            }
            /* Kiểm tra chắc chắn có một vùng được lựa chọn trên lớp Tính toán đền bù */
            if (featureSelected == null)
                return;
            if (featureSelected.Geometry.Type != MapInfo.Geometry.GeometryType.MultiPolygon)
            {
                System.Windows.Forms.MessageBox.Show(this, "Không có vùng qui hoạch nào được lựa chọn", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /* Xác định tập các thửa đất bị cắt bởi chỉ giới qui hoạch */
            DMC.GIS.Common.SearchTools seachTools = new DMC.GIS.Common.SearchTools();
            irfcThuaDatTrongQuiHoach = seachTools.SearchWithIntersect(map, strTenLopThuaDat, featureSelected.Geometry);
            foreach (Feature f in fcDenBu) { 
                foreach  (Feature fQH in irfcThuaDatTrongQuiHoach){
                    if (fQH.Geometry.ContainsPoint( f.Geometry.Centroid))
                    {
                        MapInfo.Data.Feature myfcQH = MapInfo.Engine.Session.Current.Catalog.SearchForFeature("Đất", MapInfo.Data.SearchInfoFactory.SearchWhere("MI_key = '" + fQH.Key + "'"));
                        MapInfo.Data.Feature myfcTD = MapInfo.Engine.Session.Current.Catalog.SearchForFeature(strLayerDenBu, MapInfo.Data.SearchInfoFactory.SearchWhere("MI_key = '" + f.Key + "'"));
                        CapNhatLaiGiaTriThua(myfcQH, myfcTD);
                        goto TiepTuc;
                    }
                }
            TiepTuc: ;
            }
            
        }
        private void TinhToanDenBu(MapInfo.Mapping.Map map, string strTenLopThuaDat, string strTenLopGiaiPhongMatBang, string strTenLopTrongChiGioi
            ,string strTenLopNgoaiChiGioi)
        {
           
            /* Khai báo Feature là vùng qui hoạch được lựa chọn để tính toán đền bù*/
            MapInfo.Geometry.FeatureGeometry fgQuiHoach = null;
            /* Khai báo và khởi tạo tập hợp các thửa đất bị cắt bởi chỉ giới đường đỏ */
            MapInfo.Data.IResultSetFeatureCollection irfcThuaDatTrongQuiHoach = null;
            /* Khai báo và khởi tạo tập hợp phần diện tích các thửa đất nằm trong chỉ giới đường đỏ */
            MapInfo.Data.IResultSetFeatureCollection irfcPhanDienTichTrongChiGioi = null;
            /* Khai báo và khởi tạo tập hợp phần diện tích các thửa đất nằm ngoài chỉ giới đường đỏ */
            MapInfo.Data.IResultSetFeatureCollection irfcPhanDienTichNgoaiChiGioi = null;
            /* Kiểm tra tính hợp lệ của dữ liệu */
            /* Chắc chắn rằng tồn tại đối tượng bản đồ trong điều khiển bản đồ mapControl */
            if (map == null)
                return;
            /* Kiểm tra sự tồn tại của lớp thửa đất */
            if (map.Layers[strTenLopThuaDat] == null)
                return;
            /* Kiểm tra sự tồn tại của lớp Giải phóng mặt bằng */
            if (map.Layers[strTenLopGiaiPhongMatBang] == null)
                return;
            /* Xác định một vùng được lựa chọn để tính toán đền bù */

            MapInfo.Data.Feature featureSelected = null;
            featureSelected = this.VungGiaiPhongMatBang(map, strTenLopGiaiPhongMatBang);

            /* Kiểm tra chắc chắn có một vùng được lựa chọn trên lớp Tính toán đền bù */
            if (featureSelected == null)
                return;
            if (featureSelected.Geometry.Type != MapInfo.Geometry.GeometryType.MultiPolygon)
            {
                System.Windows.Forms.MessageBox.Show(this, "Không có vùng qui hoạch nào được lựa chọn", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /* Xác định tập các thửa đất bị cắt bởi chỉ giới qui hoạch */
            DMC.GIS.Common.SearchTools  seachTools = new DMC.GIS.Common.SearchTools();
            irfcThuaDatTrongQuiHoach = seachTools.SearchWithIntersect(map, strTenLopThuaDat, featureSelected.Geometry);
            /* Chắc chắn rằng tìm được ít nhất một đối  */
            DMC.GIS.Common.clsMainSoanHoSo cls = new DMC.GIS.Common.clsMainSoanHoSo();
            MapInfo.Data.Table dt= MapInfo.Engine.Session.Current.Catalog.GetTable(strTenLopThuaDat );
            MapInfo.Data.Table dtTrongChiGioi = MapInfo.Engine.Session.Current.Catalog.GetTable(strTenLopTrongChiGioi);
            MapInfo.Data.Table dtNgoaiChiGioi = MapInfo.Engine.Session.Current.Catalog.GetTable(strTenLopNgoaiChiGioi);
            MapInfo.Data.Table tblTemp = null;
            //if (MapInfo.Engine.Session.Current.Catalog.GetTable("temp").IsOpen)
            //{
            //    MapInfo.Engine.Session.Current.Catalog.GetTable("temp").Close();
            //}
            tblTemp = cls.CreateTable(mapControl1.Map, dt, "temp");
            if (irfcThuaDatTrongQuiHoach == null) {
                return;
            }

            foreach (MapInfo.Data.Feature f in irfcThuaDatTrongQuiHoach)
            {
                InsertFeature(tblTemp, f.Geometry, f.Style);
            }
         
            //InsertFeature(tblTemp, featureSelected.Geometry, featureSelected.Style);
            MapInfo.Mapping.FeatureLayer fl = new MapInfo.Mapping.FeatureLayer(tblTemp);
            MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
            mapControl1.Map.Layers.Add(fl);
            MapInfo.Data.IResultSetFeatureCollection fc = MapInfo.Engine.Session.Current.Catalog.Search(tblTemp, MapInfo.Data.SearchInfoFactory.SearchAll());
           // MessageBox.Show(featureSelected.Key.Value);
            /* Tạo Feature từ tập hợp các Feature vừa chọn để combine */

            MapInfo.Data.Key k;
            k = tblTemp.InsertFeature(featureSelected);
            MapInfo.Data.IResultSetFeatureCollection fcQuyHoach = MapInfo.Engine.Session.Current.Catalog.Search(tblTemp, MapInfo.Data.SearchInfoFactory.SearchWhere("MI_key = '" + k + "'"));
            if (fcQuyHoach == null)
            {
                return;
            }
            if (fc == null)
            {
                return;
            }
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerDenBu);
            MapInfo.Data.IResultSetFeatureCollection fcDenBu = MapInfo.Engine.Session.Current.Catalog.Search(table, MapInfo.Data.SearchInfoFactory.SearchAll());
            foreach (MapInfo.Data.Feature fDenBu in fcDenBu)
            {
                table.DeleteFeature(fDenBu);
            }
            foreach (MapInfo.Data.Feature fQuyHoach in fcQuyHoach)
            {
                foreach (MapInfo.Data.Feature fNew in fc)
                {
                    if (!featureSelected.Geometry.Contains(fNew.Geometry))
                    {
                        BreakFeature(mapControl1.Map, fQuyHoach, fNew, "temp");
                    }
                    else {
                        Feature f = new Feature(fNew.Table.TableInfo.Columns);
                        MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();
                        ((MapInfo.Styles.SimpleInterior)cs.AreaStyle.Interior).ForeColor = Color.Red;

                        f.Geometry = fNew.Geometry;
                        f.Style = cs;
                        table.InsertFeature(f);
                    }
                }
            }
            CapNhatThongTinVungDenBu(mapControl1.Map, "Đất", "Giải phóng mặt bằng");
            DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
            layerTool.EditableLayer(mapControl1, strLayerDenBu , true);
            MapInfo.Engine.Session.Current.Catalog.CloseTable("temp"); 
            

            /* Xác định phần diện tích các thửa đất nằm trong chỉ giới qui hoạch */

            /* Hiển thị phần diện tích các thửa đất nằm trong chỉ giới qui hoạch 
             * lên một lớp mới */

            /* Xác định phần diện tích các thửa nằm ngoài chỉ giới qui hoạch */

            /* Hiển thị phần diện tích các thửa đất nằm ngoài chỉ giới qui hoạch 
             * lên một lớp mới */
           //MessageBox.Show(irfcThuaDatTrongQuiHoach.Count.ToString());
        }


        //dung de insert feature vao bang
        public void InsertFeature(MapInfo.Data.Table tab ,MapInfo.Geometry.Geometry geo, MapInfo.Styles.Style style)
        {
            MapInfo.Data.MIConnection Connection = new MapInfo.Data.MIConnection();
            Connection.Open();
            MapInfo.Data.MICommand micomm = Connection.CreateCommand();
            //khai báo câu lệnh select
            micomm.CommandText = "insert into " + tab.Alias  + " (MI_Geometry,MI_STYLE) values(@obj,@MyStyle)";
            //truyền giá trị tham biến
            micomm.Parameters.Add("@obj", geo);
            micomm.Parameters.Add("@MyStyle", style);
            try
            {
                micomm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            micomm.Dispose();
            Connection.Close();
            Connection.Dispose();
        }

        /// <summary>
        /// Hiển thị lớp Giải phòng mặt bằng
        /// Lớp này cho phép người dùng tự biên tập, chỉnh sửa
        /// vẽ thêm các đối tượng dạng vùng để tính toán qui hoạch
        /// đền bù, giải phóng mặt bằng
        /// </summary>
        private void HienThiLopGiaiPhongMatBang()
        {
            /* Tạo lớp tạm có thể thêm mới, biên tập và chỉnh sửa */
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            bool boolCreateLayer = layerTools.CreateLayerWithTemplateLayer(mapControl1.Map, "Đất", "Giải phóng mặt bằng");
            /* Cho phép Edit lớp Giải phóng mặt bằng */
            DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
            layerTool.EditableLayer(mapControl1, "Giải phóng mặt bằng", true);
        }


        private void HienThiCacLopTinhToanDenBu()
        {

            /* Tạo lớp tạm để  */
            DMC.GIS.Common.LayerTools layerTools = new DMC.GIS.Common.LayerTools();
            /* Khai báo và khởi tạo lớp thiết lập chế độ cho phép và không cho phép
             * chỉnh sửa */
            DMC.GIS.Common.LayerTools layerTool = new DMC.GIS.Common.LayerTools();
            /* Khai báo lớp các thửa đất trong chỉ giới qui hoạch */
            bool boolCreateLayer = layerTools.CreateLayerWithTemplateLayer(mapControl1.Map, "Đất", strLayerDenBu);
            layerTool.EditableLayer(mapControl1, strLayerDenBu , true);

            ///* Khai báo lớp thửa đất nằm ngoài chỉ giới qui hoạch */
            //layerTools.CreateLayerWithTemplateLayer(mapControl1.Map, "Đất", "Ngoài chỉ giới");
            //layerTool.EditableLayer(mapControl1, "Ngoài chỉ giới", true);
        }

        /// <summary>
        /// Hiển thị bản đồ Thửa đất, qui hoạch
        /// </summary>
        private  void HienThiBanDo()
        {
            /* Khai báo đối tượng bản đồ */
            MapInfo.Windows.Controls.MapControl  map = null;
            map = this.mapControl1;
            /* Khai báo và khởi tạo lớp bản đồ */
            DMC.GIS.Common.LayerConnection layerConnection = new DMC.GIS.Common.LayerConnection();
            /* Khai báo lại biến chuỗi kết nối cho phù hợp */
            string  strCon = "";
            /* Định dạng lại chuỗi kết nối đến cơ sở dữ liệu không gian */
            strCon = "DRIVER=SQL Server;" + strConnection + "; DLG=0";
            /* Mở bản đồ tất cả các thửa đất (Trên toàn quận) */
            layerConnection.OpenLayer(ref map, "Đất", strCon, "tblDLieuKGianThuaDat", strMaDonViHanhChinh);
            /* Mở bản đồ Qui hoạch */
            layerConnection.OpenLayer(ref map, "Qui hoạch", strCon, "tblDLieuKGianQuiHoach", strMaDonViHanhChinh);
        }

        private void ctrlTinhToanDenBu_Load(object sender, EventArgs e)
        {
            /* Thiết lập khi nạp ban đầu */
            this.SetupLoad();
        }

        private void toolStripHienThiBanDo_Click(object sender, EventArgs e)
        {
            /* Hiển thị Lớp bản đồ qui hoạch, lớp bản đồ Đất */
            this.HienThiBanDo();
            /* Hiển thị lớp Giải phóng mặt bằng
             * Lớp này cho phép thêm, sửa, xóa một vùng qui hoạch nào đó */
            this.HienThiLopGiaiPhongMatBang();
            /* Hiển thị lớp Tính toán đền bù 
             *thực chất đây là 3 lớp xác định vị trí tương đối với chỉ giới qui hoạch
             *bao gồm: Nằm trong, giữa, ngoài chỉ giới qui hoạch (còn gọi là chỉ giới
             đường đỏ)*/
            this.HienThiCacLopTinhToanDenBu();
        }

        private void toolStripButtonTinhToanDenBu_Click(object sender, EventArgs e)
        {
            this.TinhToanDenBu(mapControl1.Map, "Đất", "Giải phóng mặt bằng", "Trong chỉ giới", "Ngoài chỉ giới");
        }

        //tim vung bi cat boi 2 thua dat
        public void BreakFeature(MapInfo.Mapping.Map map, Feature fQH, Feature fThua, string strLayerName) {
            DPoint[] dQH=null ;
            DPoint[] dThua=null;
            MapInfo.Mapping.FeatureLayer featureLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[strLayerName];
            MapInfo.Data.Table table = featureLayer.Table;
            //chuyen thanh poltygon
            MultiPolygon plgQH = (MultiPolygon)fQH.Geometry;
            MultiPolygon plgThua = (MultiPolygon)fThua.Geometry;

            
            //lay tap hop dinh cua Vugn quy hoach
            foreach (Polygon pl in plgQH)
            {
                dQH = pl.Exterior.SamplePoints();
            }
            //lay tap hop diem cua vung thua
            foreach (Polygon pl in plgThua)
            {
                dThua = pl.Exterior.SamplePoints();
            }

            //lay tat ca cac diem cua thua dat nam trong thua quy hoach
            //tuc la diem nam tren thua quy hoach
            DPoint[] tmpDiemTrongThuaDat = new DPoint[dQH.Length];
            int iThua = 0;
            int iLenThua = 0;
            for (int i = 0; i < dQH.Length-1; i++)
            {
                if (fThua.Geometry.ContainsPoint(dQH[i]))
                {
                    tmpDiemTrongThuaDat[iThua] = dQH[i];
                    iThua += 1;
                    iLenThua += 1;
                }
            }
            //lay mang nay
            DPoint[] DiemTrongThuaDat = new DPoint[iLenThua];
            int iiThua =0;
            for (int i = 0; i < dQH.Length; i++) { 
                if (tmpDiemTrongThuaDat[i].x != 0){
                    DiemTrongThuaDat[iiThua] = tmpDiemTrongThuaDat[i];
                    iiThua += 1;
                }
            }

            //lay tat ca cac diem cua thua quy hoach nam trong thua dat
            //tuc la cac diem cua thua dat
            DPoint[] tmpDiemTrongQuyHoach = new DPoint[dThua.Length];
            int iQH =0;
            int iLenQH = 0;
            for(int i = 0; i <dThua.Length -1; i ++ ){
               if (fQH.Geometry.ContainsPoint(dThua[i])){
                   tmpDiemTrongQuyHoach[iQH] = dThua[i];
                   iQH+=1;
                   iLenQH += 1;
                   
               }
            }
            //lay mang nay
            DPoint[] DiemTrongQuyHoach= new DPoint[iLenQH];
            int iiGH = 0;
            for (int i = 0; i < dThua.Length; i++)
            {
                if (tmpDiemTrongQuyHoach[i].x != 0)
                {
                    DiemTrongQuyHoach[iiGH] = tmpDiemTrongQuyHoach[i];
                    iiGH += 1;
                }
            }

            //lay giao diem cua thua quy hoach va thua dat
            MultiCurve cvQH = new MultiCurve(map.GetDisplayCoordSys(), CurveSegmentType.Linear, dQH);
            MultiCurve cvThua = new MultiCurve(map.GetDisplayCoordSys(), CurveSegmentType.Linear, dThua);
            MultiPoint mPoint = new MultiPoint(map.GetDisplayCoordSys());
            mPoint = cvQH.IntersectNodes(cvThua, IntersectTypes.InclAll);
            DPoint[] GiaoDiem = new DPoint[mPoint.PointCount];
            int iGiaoDiem=0;
            foreach (DPoint dp in mPoint ){
                GiaoDiem[iGiaoDiem] = dp;
                iGiaoDiem += 1;
            }
            //gom cac diem trong thua quy hoach, thua dat va giao diem cua thua quy hoach va thua dat
            DPoint[] dDiemCanTim = new DPoint[mPoint.PointCount + iLenQH+ iLenThua +1 ];
            int iChay = 0;
            DPoint dChayDauQH = new DPoint();
            for (int i = 0; i < iGiaoDiem-1; i++)
            {
                dDiemCanTim[iChay] = GiaoDiem[i];
                dChayDauQH = dDiemCanTim[iChay];
                iChay += 1;
            }
            if (DiemTrongQuyHoach.Length > 0)
            {
                DPoint P21 = DiemTrongQuyHoach[0];
                DPoint P22 = DiemTrongQuyHoach[iLenQH - 1];
                double d21, d22;
                d21 = System.Math.Sqrt(Math.Abs((P21.x - dChayDauQH.x) * (P21.x - dChayDauQH.x) + (P21.y - dChayDauQH.y) * (P21.y - dChayDauQH.y)));
                d22 = System.Math.Sqrt(Math.Abs((dChayDauQH.x - P22.x) * (dChayDauQH.x - P22.x) + (dChayDauQH.y - P22.y) * (dChayDauQH.y - P22.y)));
                if (d21 > d22)
                {
                    for (int i = iLenQH - 1; i > -1; i--)
                    {
                        dDiemCanTim[iChay] = DiemTrongQuyHoach[i];
                        iChay += 1;
                    }

                }
                else
                {
                    for (int i = 0; i < iLenQH; i++)
                    {
                        dDiemCanTim[iChay] = DiemTrongQuyHoach[i];
                        iChay += 1;
                    }
                }
            }
            if (GiaoDiem.Length > 0)
            {
                dDiemCanTim[iChay] = GiaoDiem[GiaoDiem.Length - 1];
            }
            else {
                return;
            }
                DPoint dChayDau = new DPoint();
                dChayDau = dDiemCanTim[iChay];
                iChay += 1;
            
            if (DiemTrongThuaDat.Length > 0)
            {
               
                DPoint P1 = DiemTrongThuaDat[0];
                DPoint P2 = DiemTrongThuaDat[iLenThua - 1];
                double d11, d12;
                d11 = System.Math.Sqrt(Math.Abs((P1.x - dChayDau.x) * (P1.x - dChayDau.x) + (P1.y - dChayDau.y) * (P1.y - dChayDau.y)));
                d12 = System.Math.Sqrt(Math.Abs((dChayDau.x - P2.x) * (dChayDau.x - P2.x) + (dChayDau.y - P2.y) * (dChayDau.y - P2.y)));
                if (d11 > d12)
                {

                    for (int i = iLenThua - 1; i > -1; i--)
                    {
                        dDiemCanTim[iChay] = DiemTrongThuaDat[i];
                        iChay += 1;
                    }
                }
                else
                {
                    for (int i = 0; i < iLenThua; i++)
                    {
                        dDiemCanTim[iChay] = DiemTrongThuaDat[i];
                        iChay += 1;
                    }
                }
            }


            


            //////tao vung cho tap hop diem tim dc
            dDiemCanTim[dDiemCanTim.Length - 1] = dDiemCanTim[0];
            //////======================================================================
            //////thiet lap lai danh sach diem cho dugn thu tu
            ////List<DPoint> ListPoint;

            ////Class1 cls = new Class1(dDiemCanTim);
            ////cls.map = mapControl1.Map;
            ////cls.CountPoint = dDiemCanTim.Length;
            ////ListPoint = new List<DPoint>();
            ////cls.TryOthers(ListPoint, 0);
            ////DPoint[] DketQua = new DPoint[dDiemCanTim.Length];
            ////for (int i = 0; i < ListPoint.Count; i++)
            ////{
            ////    DketQua[i] = ListPoint[i];
            ////}
            ////DketQua[DketQua.Length - 1] = DketQua[0];


          
           // //=====================================================================

            MapInfo.Data.Table tableDenBu = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerDenBu); 

            MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();
            ((MapInfo.Styles.SimpleInterior)cs.AreaStyle.Interior).ForeColor=Color.Red ;

            MapInfo.Data.Feature feature = new MapInfo.Data.Feature(table.TableInfo.Columns);
            /* Gán giá trị cho Feature cần tạo */
            MultiPolygon poly = new MultiPolygon(map.GetDisplayCoordSys(), CurveSegmentType.Linear, dDiemCanTim);
            feature = new MapInfo.Data.Feature(poly, cs);
            feature.Geometry = feature.Geometry.ConvexHull();
            feature.Style = cs;
            MapInfo.Data.Key k = tableDenBu.InsertFeature(feature);
        //  mpxDrawNode(mapControl1.Map, "temp", "", DketQua, "nhanNode", "temp");
        //mpxDrawText(mapControl1.Map, "temp", "Dinh", DketQua);
        }


            public void mpxDrawNode(MapInfo.Mapping.Map pMap, string pTabName, string newLayer, DPoint[] d, string Nhan, string LayerName)
        {
            MapInfo.Geometry.FeatureGeometry pt;
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(newLayer) == null)
            {
                Table tab = null;
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                //dinh nghia font
                MapInfo.Styles.SimpleVectorPointStyle vs = new MapInfo.Styles.SimpleVectorPointStyle(33, System.Drawing.Color.Yellow, 10);
                MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle(vs);
                for (int i = 0; i < d.Length; i++)
                {
                    //gọi hàm tạo node
                    pt = mpxMkFeaturePoint(pMap.GetDisplayCoordSys(), d[i].x, d[i].y);
                    //update doi tưọng vừa tạo vào bảng
                    InsertFeature(tab, pt, cs);
                }
               
            }
        }
            public void mpxDrawText(MapInfo.Mapping.Map pMap, string pTabName, string newLayer, DPoint[] d)//, TextStyle ts)
            {
                if (MapInfo.Engine.Session.Current.Catalog.GetTable(newLayer) == null)
                {
                    Table tab = null;
                    tab = MapInfo.Engine.Session.Current.Catalog.GetTable(pTabName);
                    DPoint PStart;
                    DPoint PEnd;
                    DPoint[] PPoint = new DPoint[2];
                    MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();
                    for (int i = 0; i < d.Length - 1; i++)
                    {
                        //tạo đối tượng bounds cho text
                        PStart.x = d[i].x - cs.TextStyle.Font.Size * 0.1 / 2;
                        PStart.y = d[i].y - cs.TextStyle.Font.Size * 0.1 / 2;
                        PEnd.x = d[i].x + cs.TextStyle.Font.Size * 0.1 / 2;
                        PEnd.y = d[i].y + cs.TextStyle.Font.Size * 0.1 / 2;
                        PPoint[0] = PStart;
                        PPoint[1] = PEnd;
                        //khai báo đối tượng bounds text
                        MapInfo.Geometry.DRect tmp = new MapInfo.Geometry.DRect(PStart, PEnd);
                        DPoint PStartNew = new DPoint();
                        DPoint PEndNew = new DPoint();
                        PStartNew.x = d[i].x - tmp.Height() / 2;
                        PStartNew.y = d[i].y - tmp.Width() / 2;
                        PEndNew.x = d[i].x + tmp.Height() / 2;
                        PEndNew.y = d[i].y + tmp.Width() / 2;
                        MapInfo.Geometry.DRect rect = new MapInfo.Geometry.DRect(PStartNew, PEndNew);
                        //tạo mới đối tượng text
                        MapInfo.Geometry.LegacyText g = new MapInfo.Geometry.LegacyText(pMap.GetDisplayCoordSys(), rect, (i ) .ToString());

                        //update đối tượng vào bảng
                        InsertFeature(tab,(Geometry)g, cs);
                    }
                }
            }
            public MapInfo.Geometry.FeatureGeometry mpxMkFeaturePoint(MapInfo.Geometry.CoordSys pSys, double x, double y)
            {
                MapInfo.Geometry.Point pt = new MapInfo.Geometry.Point(pSys, x, y);
                MapInfo.Geometry.FeatureGeometry geo = pt as MapInfo.Geometry.FeatureGeometry;
                return geo;
            }

            private void toolStripTinhDienTich_Click(object sender, EventArgs e)
            {
                double TongDienTich = 0;
                MapInfo.Data.Table tableDenBu = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerDenBu);
                MapInfo.Data.IResultSetFeatureCollection fc = MapInfo.Engine.Session.Current.Catalog.Search(tableDenBu, MapInfo.Data.SearchInfoFactory.SearchAll());
                if (fc == null)
                {
                    return;
                }
                if (fc.Count  == 0)
                {
                    return;
                }
                
                foreach (Feature f in fc)
                {
                    if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                    {
                        MultiPolygon plgThua = (MultiPolygon)f.Geometry;
                        TongDienTich = TongDienTich + Convert.ToDouble(string.Format("{0:0.00}", plgThua.Area(AreaUnit.SquareMeter))); ;
                    }
                }
                txtTongDienTich.Text = TongDienTich.ToString();
            }
        public static bool IsDouble(string theValue)
                {
                    try
                    {
                        Convert.ToDouble(theValue);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                    }
            private void cmdTinh_Click(object sender, EventArgs e)
            {
                double GiaTriTienTrenM2 = 0;
                double TongGiaTri = 0;
                double TongDienTich = 0;

                if ((txtGiaTriTienTrenM2.Text != "") & (IsDouble(txtGiaTriTienTrenM2.Text)))
                {
                    GiaTriTienTrenM2 = Convert.ToDouble(txtGiaTriTienTrenM2.Text);
                }
                TongGiaTri = Convert.ToDouble(txtTongDienTich.Text);
                TongDienTich = TongGiaTri * GiaTriTienTrenM2;
                txtTongGiaTriTien.Text = string.Format("{0:###,#.00}", TongDienTich.ToString());  ;
            }

            public void CapNhatLaiGiaTriThua(Feature fOld, Feature fNew)
            {
                if (fOld == null)
                    return;
                if (fNew == null)
                    return;
                double DienTichFNew =0;
                if (fNew.Geometry.TypeName == "MultiPolygon")
                {
                    MultiPolygon mp = (MultiPolygon)fOld.Geometry ;
                    DienTichFNew = mp.Area(AreaUnit.SquareMeter); 
                }
                fNew["DienTichTuNhien"] = DienTichFNew;
                fNew["SoThua"] = fOld["SoThua"];
                fNew["ToBanDo"] = fOld["ToBanDo"];
                fNew["MaDonViHanhChinh"] = this.strMaDonViHanhChinh;
                fNew.Update(true);
            }

            private void cmdChiTiet_Click(object sender, EventArgs e)
            {
                frmChiTietDenBu frm = new frmChiTietDenBu();
                DataTable dt = new DataTable();
                dt.Columns.Add("ToBanDo");
                dt.Columns.Add("SoThua");
                dt.Columns.Add("DienTichTuNhien");
                dt.Columns.Add("GiaTriTienTrenM2");
                dt.Columns.Add("TongGiaTri");
                MapInfo.Data.Table tableDenBu = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerDenBu);
                MapInfo.Data.IResultSetFeatureCollection fc = MapInfo.Engine.Session.Current.Catalog.Search(tableDenBu, MapInfo.Data.SearchInfoFactory.SearchAll());
                if (fc == null) { return; }
                if (fc.Count  == 0) { return; }
                int i = 0;
                foreach (Feature f in fc) {
                    string ToBanDo = "";
                    string SoThua = "";
                    string DienTich = "";
                    string GiaTriM2 = "0";
                    string TongTien = "0";
                    MapInfo.Data.Feature myfcTD = MapInfo.Engine.Session.Current.Catalog.SearchForFeature(strLayerDenBu, MapInfo.Data.SearchInfoFactory.SearchWhere("MI_key = '" + f.Key + "'"));
                    ToBanDo = myfcTD["ToBanDo"].ToString();
                    SoThua = myfcTD["SoThua"].ToString();
                    DienTich = myfcTD["DienTichTuNhien"].ToString();
                    GiaTriM2 = txtGiaTriTienTrenM2.Text ;
                    TongTien = (Convert.ToDouble(DienTich) * Convert.ToDouble(GiaTriM2)).ToString();
                    TongTien = string.Format("{0:###,#.00}", TongTien.ToString()); ;
                     dt.Rows.Add(1);

                     dt.Rows[i]["ToBanDo"] = ToBanDo;
                     dt.Rows[i]["SoThua"] = SoThua;
                     dt.Rows[i]["DienTichTuNhien"] = DienTich;
                     dt.Rows[i]["GiaTriTienTrenM2"] = GiaTriM2;
                     dt.Rows[i]["TongGiaTri"] = TongTien;
                     TongTien = "0";
                   i = i + 1;
                }
                frm.MyTable = dt;
                frm.Show();
            }
            
          
    }
}
