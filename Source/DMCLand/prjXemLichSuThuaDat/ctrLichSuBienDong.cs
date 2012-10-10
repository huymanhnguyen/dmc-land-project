using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using MapInfo.Data;
using MapInfo.Mapping;
using MapInfo.Engine;
using MapInfo.Geometry;
using MapInfo.Styles;
using MapInfo.Tools;
using MapInfo.Windows.Controls;
using DMC.GIS.Common;
using MapInfo.Data.Find;
using MapInfo.Text;
using System.Data.SqlClient;
using System;

namespace prjXemLichSuThuaDat
{
    public partial class ctrLichSuBienDong : UserControl
    {
        private string strConnection = "";

        private clsMainSoanHoSo cls = new clsMainSoanHoSo();
        public string Connection
        {
            get { return strConnection; }
            set { strConnection = value; }
        }
        
        private string strMaThuaDat = "";

        public string MaThuaDat
        {
            get { return strMaThuaDat; }
            set { strMaThuaDat = value; }
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

        public ctrLichSuBienDong()
        {
            InitializeComponent();
        }

        private void ctrLichSuBienDong_Load(object sender, EventArgs e)
        {
            SetupLoad();
        }

        public void BanDoTongThe()
        {
            string strTenBanDoTongThe = "Bản_Đồ_Đất";
            MapInfo.Mapping.FeatureLayer[] lyrs = new MapInfo.Mapping.FeatureLayer[1];
            string str = "";
            string strConec = "";
            strConec = "DRIVER={SQL Server};" + strConnection + ";DLG=SQL_DRIVER_NOPROMPT";
            str = "select * from " + strTenBangDat + "";
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(strTenBanDoTongThe) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(strTenBanDoTongThe);
            }
            cls.OpenLayer(ref mapControl1, ref lyrs[0], strTenBanDoTongThe, strConec, str);     
        }

        private void SetupLoad()
        {
            /* Đặt tên cho bản đồ */
            mapControl1.Map.Name = "Bản đồ địa chính";
            mapControl1.Map.Zoom = new MapInfo.Geometry.Distance(1500, DistanceUnit.Meter);
            /* Không hiển thị ToolTip */
            lyrControl.ToolTip.Active = false;

            lyrControl.Map = mapControl1.Map;
            lyrControl.Tools = mapControl1.Tools;
            lyrControl.CheckBoxes = true;
            lyrControl.TabControl.Visible = false;
            lyrControl.ToolBar.Buttons[0].Visible = false;
            lyrControl.ToolBar.Buttons[1].Visible = false;
            lyrControl.ToolBar.Buttons[2].Visible = false;

            mapToolBar1.MapControl.Map = mapControl1.Map;
            mapToolBar1.MapControl.Tools = mapControl1.Tools;

        }
        public void ShowBanDo(string strMa, string  time) {
            //tao layer tam
            string str ="";
            string strConec = "";
            strConec = "DRIVER={SQL Server};" + strConnection + ";DLG=SQL_DRIVER_NOPROMPT";
            str = "select * from " + strTenBangDat + "LICHSU   where MaThuaDat = " + strMa;// +" and NgayBienDong = '" + time + "'";
            Table TableThuaDat = null;
            if (MapInfo.Engine.Session.Current.Catalog.GetTable("BanDo") != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable("BanDo");
            }
            TableThuaDat = cls.GetNewLayer("BanDo", strConec, str);
       

            Table dt = null;
            string thuaDat = "Thửa_Đất_Lịch_Sử";
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(thuaDat) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(thuaDat);
            }
            //tao doi tuong table co ten la tmp cho bang thua dat
            dt = cls.CreateDataTable(mapControl1.Map, "BanDo", thuaDat, TableThuaDat);
            IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(TableThuaDat, MapInfo.Data.SearchInfoFactory.SearchAll());

             if (irfc == null)
                {
                    return;
                }
                if (irfc.Count == 0)
                {
                    return;
                }
                //lay tat ca cac doi tuong tim duoc dua len tren mot layer tmp cua ban do
              
                foreach (Feature f in irfc)
                {
                    Feature ff = new Feature(dt.TableInfo.Columns);
                    ff.Geometry = f.Geometry;
                    ff.Style = new CompositeStyle();
                    dt.InsertFeature(ff);
                    //cls.UpdateDoiTuong(dt, f.Geometry, "", new CompositeStyle(), "");
                   
                }

            FeatureLayer fl = new FeatureLayer(dt);
            mapControl1.Map.Layers.Add(fl);
            mapControl1.Map.SetView(irfc);
        }
        public void DanhSachBienDong(string strMa) {
            clsLichSuBienDong clsls = new clsLichSuBienDong();
            clsls.Connection = strConnection;
            clsls.MaDonViHanhChinh = strMaDonViHanhChinh ;
            clsls.MaThuaDat = strMa;
            DataTable dt = new DataTable();
            dt= clsls.selDanhSachBienDong();
            grdLSBienDong.DataSource = dt;
            changeTile();
        }
        public void changeTile()
        { 
            grdLSBienDong.Columns["ThoiDiemDangKy"].HeaderText = "Loại hình biến động";
            grdLSBienDong.Columns["ToBanDo"].HeaderText = "Tờ bản đồ";
            grdLSBienDong.Columns["SoThua"].HeaderText = "Số thửa";
            grdLSBienDong.Columns["DienTich"].HeaderText = "Diện tích";
            grdLSBienDong.Columns["MaHoSoCapGCN"].Visible = false;
            grdLSBienDong.Columns["MaThuaDat"].Visible = false;
            grdLSBienDong.Columns["NoiDung"].HeaderText = "Nội dung";
        }

        private void grdLSBienDong_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 ){
                string maThua = "";
                maThua = grdLSBienDong.Rows[e.RowIndex].Cells["MaThuaDat"].Value.ToString();
                strMaThuaDat = maThua;
                ShowBanDo(maThua, grdLSBienDong.Rows[e.RowIndex].Cells["ThoiDiemDangKy"].Value.ToString());
            }
        }

        private void cmdHoSo_Click(object sender, EventArgs e)
        {
            
        }
    }
}

