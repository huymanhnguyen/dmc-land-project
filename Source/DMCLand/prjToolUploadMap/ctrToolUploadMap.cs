using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MapInfo.Data;
using MapInfo.Mapping;
using MapInfo.Engine;
using MapInfo.Geometry;
using MapInfo.Tools;
using MapInfo.Windows.Controls;
using System.Xml;
using System.IO;
using MapInfo.Styles;
using DMC.GIS.Common;
using System.Data.SqlClient;
using Microsoft.VisualBasic;


namespace prjToolUploadMap
{
    public partial class ctrToolUploadMap : UserControl
    {
        public System.Drawing.Point MousePositionBeforeMoved, LocationBeforeMoved;
        private string strMaDonViHanhChinh = "";
        private string strConnectionstring;
        private string strConnection = "";
        private bool KetQuaGhi = false;
        /* Khai báo biến kiểm tra lỗi */
        private string strError = "";
        private string  strMa = "";
        clsDatabase clsData = new clsDatabase(); 
        /* Khai báo biến xác định kiểu thao tác cơ sở dữ liệu */
        private short shortAction = 0;
        private string strMaBanDo = "";
        Boolean kiemtracheck = false; 
        private string strDonViHanChinh = "";
        public string Connection
        {
            get { return strConnection; }
            set { strConnection = value; }
        }
        public ctrToolUploadMap()
        {
            InitializeComponent();
            mapControl1.Map.ViewChangedEvent += new ViewChangedEventHandler(Map_ViewChanged);
            mapControl1.Tools.FeatureSelecting += new FeatureSelectingEventHandler(FeatureSelecting);
            mapControl1.Tools.FeatureSelected += new FeatureSelectedEventHandler(FeatureSelected);
            clsData = new clsDatabase();
            clsData.SetConnection(strConnection);
            panLayer.Hide();
            panToaDo.Hide();
        }
        private void SetupLoad()
        {
            /* Đặt tên cho bản đồ */
            mapControl1.Map.Name = "Bản đồ";

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
        private void ctrToolUploadMap_Load(object sender, EventArgs e)
        {
            SetupLoad();
            StaProgressBar.Visible = false; ;
            strConnectionstring = "DRIVER=SQL Server;" + strConnection + ";DLG=0";
            try
            {
                /* Trạng thái cập nhật */
                this.TrangThaiCapNhat(false);
                /* Trạng thái chức năng */
                this.TrangThaiChucNang(false, false);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(this, " Nạp dữ liệu ban đầu " + System.Environment.NewLine + " Dự án" +
                " Lỗi: " + strError, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }       
        public  void LoadDanhSachDuAn()
        { 
                btnThem.Enabled = true; 
                clsToolUploadMap cls = new clsToolUploadMap();
                cls.Connection = strConnection;
                cls.MaDonViHanhChinh = "1004"; 
                DataTable dt = new DataTable();
                cls.SelTenBanDoDuAn(dt);

                grdDuAn.DataSource = dt;
                for (int i =0 ; i < dt.Columns.Count ;i ++ ){
                    grdDuAn.Columns[i].Visible = false;
                }
                grdDuAn.Columns["TenBanDo"].Visible = true;
                grdDuAn.Columns["TenBanDo"].HeaderText = "Tên";
 
        }
        private void toolStripLuu_Click(object sender, EventArgs e)
        {         
            GhiFile();
        }
        private void mapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            DPoint P = new DPoint();
            System.Drawing.PointF pointf = new System.Drawing.PointF();
            pointf.X = e.X;
            pointf.Y = e.Y;
            P = ConvertDpoint(pointf, mapControl1);
            StatusToaDoX.Text = P.x.ToString();
            StatusToaDoY.Text = P.y.ToString();
        }
        //chuyen tu toa do man hinh ve toa do thuc
        public DPoint ConvertDpoint(PointF Point, MapControl map)
        {
            DPoint pointDisplay = new DPoint();
            if (map.Map != null)
            {
                MapInfo.Geometry.DisplayTransform converter = map.Map.DisplayTransform;
                converter.FromDisplay(Point, out pointDisplay);
            }
            return pointDisplay;

        }
        public Table GetNewLayer(string strAlias, string strConnection, string strQuery)
        {
            MapInfo.Data.Table[] tables = new Table[1];
            try
            {
                MIConnection Connection = new MIConnection();
                Connection.Open();

                TableInfoServer tis1 = new TableInfoServer(strAlias, strConnection, strQuery, MapInfo.Data.ServerToolkit.Odbc);
                tables[0] = Connection.Catalog.OpenTable(tis1);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
            return tables[0];

        }
        //ghi thông số thay đổi thuộc tính zoom trên bản đồ vào thanh tabar
        private void Map_ViewChanged(object o, ViewChangedEventArgs e)
        {
            try
            {
                // Get the map
                MapInfo.Mapping.Map map = (MapInfo.Mapping.Map)o;
                if ((0 < mapControl1.Map.Zoom.Value) && (mapControl1.Map.Zoom.Value < 100000))
                {
                    double dblZoom = System.Convert.ToDouble(string.Format("{0:E2}", mapControl1.Map.Zoom.Value));
                    mapControl1.Map.Zoom = new MapInfo.Geometry.Distance(dblZoom, DistanceUnit.Meter);
                    StatusZoom.Text = "Zoom: " + dblZoom.ToString() + " m";
                }
            }
            catch (Exception ex)
            {
            }
        }
        public string ChuyenKieuDuLieu(string KieuDuLieu)
        {
            string NewKieuDuLieu = "";
            switch (KieuDuLieu)
            {
                case "Binary":
                    NewKieuDuLieu = "Binary(8000)";
                    break;
                case "Boolean":
                    NewKieuDuLieu = "bit";
                    break;
                case "CoordSys":
                    NewKieuDuLieu = "";
                    break;
                case "Date":
                    NewKieuDuLieu = "DateTime";
                    break;
                case "DateTime":
                    NewKieuDuLieu = "DateTime";
                    break;
                case "dBaseDecimal":
                    NewKieuDuLieu = "decimal(18, 0)";
                    break;
                case "Double":
                    NewKieuDuLieu = "float";
                    break;
                case "FeatureGeometry":
                    NewKieuDuLieu = "";
                    break;
                case "Grid":
                    NewKieuDuLieu = "";
                    break;
                case "Int":
                    NewKieuDuLieu = "int";
                    break;
                case "Key":
                    NewKieuDuLieu = "";
                    break;
                case "Raster":
                    NewKieuDuLieu = "";
                    break;
                case "SmallInt":
                    NewKieuDuLieu = "smallint";
                    break;
                case "String":
                    NewKieuDuLieu = "nvarchar(max)";
                    break;
                case "Style":
                    NewKieuDuLieu = "";
                    break;
                case "Time":
                    NewKieuDuLieu = "smalldatetime";
                    break;
                case "Wms":
                    NewKieuDuLieu = "";
                    break;
            }
            return NewKieuDuLieu;
        }
        //Dua cac doi tuong tren ban do vao CSDL
        public void ChapNhanGhi(CoordSys coorS, IResultSetFeatureCollection irfc, Table tabThua, System.Windows.Forms.ToolStripProgressBar process)
        {
            process.Maximum = irfc.Count;
            foreach (Feature myFeature in irfc)
            {
                MapInfo.Data.Feature f = new MapInfo.Data.Feature(tabThua.TableInfo.Columns);
                MultiPolygon poly = null;
                MapInfo.Data.Feature fff = null;
                //nếu đối tượng trên Map là rectangle thì phải chuyển về dạng MultiPolygon
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Rectangle"))
                {
                    MapInfo.Geometry.Rectangle rect = (MapInfo.Geometry.Rectangle)myFeature.Geometry;
                    MapInfo.Geometry.Rectangle rectNew = new MapInfo.Geometry.Rectangle(coorS, rect);
                    poly = rectNew.CreateMultiPolygon();
                    fff = new MapInfo.Data.Feature(poly, myFeature.Style);
                    f.Geometry = fff.Geometry;
                    f.Style = myFeature.Style;
                }
                //nếu đối tượng trên Map là Elip thì phải chuyển về dạng MultiPolygon
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Ellipse"))
                {
                    MapInfo.Geometry.Ellipse elip = (MapInfo.Geometry.Ellipse)myFeature.Geometry;
                    MapInfo.Geometry.Ellipse elipNew = new MapInfo.Geometry.Ellipse(coorS, elip);

                    poly = elipNew.CreateMultiPolygon(100);
                    fff = new MapInfo.Data.Feature(poly, myFeature.Style);
                    f.Geometry = fff.Geometry;
                    f.Style = myFeature.Style;
                }
                //neu là đối tượng point
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.Point"))
                {
                    MapInfo.Geometry.Point point = new MapInfo.Geometry.Point(coorS, (MapInfo.Geometry.Point)myFeature.Geometry);
                    f.Geometry = point;
                    f.Style = myFeature.Style;
                }
                //neu là đối tượng text
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.LegacyText"))
                {
                    MapInfo.Geometry.LegacyText point = new MapInfo.Geometry.LegacyText(coorS, (MapInfo.Geometry.LegacyText)myFeature.Geometry);
                    f.Geometry = point;
                    f.Style = myFeature.Style;
                }
                //Nếu là dối tượng đường
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiCurve"))
                {
                    foreach (Curve Cur in (MultiCurve)myFeature.Geometry)
                    {
                        DPoint[] d = Cur.SamplePoints();
                        MapInfo.Geometry.FeatureGeometry Line = new MapInfo.Geometry.MultiCurve(coorS, CurveSegmentType.Linear, d);
                        f.Geometry = Line;
                        f.Style = myFeature.Style;
                    }
                }
                //nếu là đối tượng MultiPolygon
                if (myFeature.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                {
                    f.Geometry = myFeature.Geometry;
                    f.Style = myFeature.Style;
                }
                if (f.Geometry == null)
                {
                    tabThua.InsertFeature(myFeature);
                }
                else
                {
                    tabThua.InsertFeature(f);
                }
                //insert feature vào bảng 

                //hien thi process
                process.Value = process.Value + 1;
                f = null;
            }
        }
        //xoá các bản ghi cũ đã tôn tại để thay bằng các bản ghi mới đã được chỉnh lý
        public void DelRecoreOld(string strBang, SqlConnection conn)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from  " + strBang + "  where  temp = 'True'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();

        }
        //ham ket noi co so du lieu
        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                string strConnec;
                strConnec = "";

                strConnec = strConnection;
                conn.ConnectionString = strConnec;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối =>>" + ex.Message);
            }
            return conn;
        }
        //xac nhan ghi thanh cong cuoi dung ()
        public void GhiXacNhan(string strBang, string MaDonViHanhChinh)
        {
            //xac nhan ghi thanh cong
            SqlConnection conn = new SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn = Connect();
            }
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Update " + strBang + " set MaDonViHanhChinh = " + MaDonViHanhChinh + ", temp = 'True' where MaDonViHanhChinh is Null";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();


            cmd.Dispose();
        }       
        private void grdDuAn_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                strMaBanDo = grdDuAn.Rows[e.RowIndex].Cells["MaBanDo"].Value.ToString();
                txtTenDuAn.Text = grdDuAn.Rows[e.RowIndex].Cells["TenBanDo"].Value.ToString();
                txtTyLe.Text = grdDuAn.Rows[e.RowIndex].Cells["TYle"].Value.ToString();           
 
            }
        }
        private void toolStripHienThiBanDo_Click(object sender, EventArgs e)
        {
            MapInfo.Engine.Session.Current.Catalog.CloseAll();
            HienThiBanDo(strMaDonViHanhChinh);
        }
        //thuc hien viec load tham 1 ban do moi
        public void HienThiBanDo(string MaDonViHanhChinh)
        {
            try
            {
                if (grdDuAn.CurrentRow.Cells["tenBanDo"].Value.ToString() != "")
                {
                    mapControl1.Map.Name = "Bản đồ " + grdDuAn.CurrentRow.Cells["tenbando"].Value.ToString().ToUpper();
                }
                else
                {
                    mapControl1.Map.Name = "Bản đồ";
                    return;
                }
                //xoa tat ca cac file trong thu muc chua
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\HienThiFileQuyHoach\");
                FileInfo[] file = dir.GetFiles("*.tab");
                string pathDir = Application.StartupPath + @"\HienThiFileQuyHoach\";
                // xoa file tmp khi undo den giai doan giua rui lam tiep
                for (int i = 0; i < file.Length; i++)
                {
                    XoaFileTmp(pathDir, file[i].Name);
                }

                // xuat ra file tab tu csdl
                toolXuatFileMap(MaDonViHanhChinh);

                //Mo file da xuat ra
                // dong tat ca cac lay o hien thoi
                mapControl1.Map.Layers.Clear();
                FileInfo[] fileLoad = dir.GetFiles("*.tab");
                for (int i = 0; i < fileLoad.Length; i++)
                {
                    // MapInfo.Data.Table NameLayer = MapInfo.Engine.Session.Current.Catalog.GetTable(NameLayer);
                    MapInfo.Data.Table NameLayer = MapInfo.Engine.Session.Current.Catalog.OpenTable(dir + "\\" + fileLoad[i].Name);
                    FeatureLayer fl = new FeatureLayer(NameLayer);
                    mapControl1.Map.Layers.Add(fl);
                    mapControl1.Map.SetView(fl);
                }
            }
            catch (FeatureException ex)
            {
                MessageBox.Show("Mở bản đồ không thành công !!!", "Thông báo");
            }
        }
        //ham chức nang thực hiện chức năng mở 1 bảng của bản đồ và đưa lên bản đồ       
        public void TrangThaiBanDau()
        { 
            this.txtTenDuAn.Text = "";
            this.txtTyLe.Text = "";
        }
        public void TrangThaiChucNang(bool blnStartEdited, bool blnStartDeleted)
        {

            this.btnSua.Enabled = !blnStartEdited;
            this.btnXoa.Enabled = !blnStartEdited;
             this.btnThem.Enabled = !blnStartEdited;
            this.btnCapNhat.Enabled = blnStartEdited;
            this.btnHuyLenh.Enabled = blnStartEdited;
            if (blnStartDeleted)
            {
                this.btnCapNhat.Enabled = !blnStartDeleted;
                this.btnHuyLenh.Enabled = !blnStartDeleted;
            }
        }
        public void TrangThaiCapNhat(bool blnCapNhat)
        {
            this.txtTenDuAn.ReadOnly = !blnCapNhat;
            this.txtTyLe.ReadOnly = !blnCapNhat;
            //Thiết đặt màu nền cho các điều khiển
            if (blnCapNhat)
            {
                this.txtTenDuAn.BackColor = Color.White;
                this.txtTyLe.BackColor = Color.White;
            }
            else
            {
                this.txtTenDuAn.BackColor = Color.LightYellow;
                this.txtTyLe.BackColor = Color.LightYellow;
            }
        }
        private string auto_sThoiGian()
        {
            string sNgayThangNam;
            string sGioPhutGiay;
            string sMiliGiay;

            sNgayThangNam = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            sGioPhutGiay = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            sMiliGiay = DateTime.Now.Millisecond.ToString();
            return sNgayThangNam + sGioPhutGiay + sMiliGiay;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            btnThem.Enabled = false; 
            strMaDonViHanhChinh = ""; 
            strMaBanDo = auto_sThoiGian();


            shortAction = 2;
            /* Thiết lập các điều khiển về trạng thái ban đầu */
            this.TrangThaiBanDau();
            /* Thiết lập các điều khiển về trạng thái cập nhật */
            this.TrangThaiCapNhat(true);
            /* Thiết lập trạng thái thêm mới cho các điều khiển cập nhật */
            this.TrangThaiChucNang(true, false);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (strMaBanDo != "")
            {
                shortAction = 3;
                /* Trạng thái chức năng */
                this.TrangThaiChucNang(true, false);
                /* Trạng thái cập nhật */
                this.TrangThaiCapNhat(true);
                btnThem.Enabled = false; 
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(this, " Bạn phải chọn Dự án cần sửa thông tin!", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            /* Nếu tồn tại mã cần xóa */
            if (strMaBanDo != "")
            {
                if (System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        shortAction = 4;
                        this.UpdateData();
                        strMaDonViHanhChinh = "";
                        /* Trang thai ban dau */
                        this.TrangThaiBanDau();
                        /* Hien thi du lieu */
                        grdDuAn.Columns.Clear();
                        /* Trang thai chuc nang */
                        this.TrangThaiChucNang(false, false);
                    }
                    catch (Exception ex)
                    {
                        strError = ex.Message;
                    }
                    if (strError == "")
                        System.Windows.Forms.MessageBox.Show(this, " Bạn đã cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        System.Windows.Forms.MessageBox.Show(this, " Cập nhật chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    /* Trang thai chuc nang */
                    this.TrangThaiChucNang(false, false);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(this, " Bạn phải chọn Dự án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /* Trạng thái cập nhật */
            this.TrangThaiCapNhat(false);
            strError = "";
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTenDuAn.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show(this, "Bạn phải nhập Tên dự án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDuAn.Focus();
                return;
            }
            strMaDonViHanhChinh = "1004";
            /* Cập nhật thông tin dự án */
            this.UpdateData();
            /* Hiển thị lại dữ liệu */
            grdDuAn.Columns.Clear();

          
            /* Trang thai chuc nang */
            this.TrangThaiChucNang(false, false);
            /* Trang thai cap nhat */
            this.TrangThaiCapNhat(false);

            if (strError == "")
                System.Windows.Forms.MessageBox.Show(this, " Bạn đã cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                System.Windows.Forms.MessageBox.Show(this, " Cập nhật chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /* Khoi tao gia tri cho bien dung chung */
            strMa = "";
            strError = "";
            LoadDanhSachDuAn();
        }
        private void btnHuyLenh_Click(object sender, EventArgs e)
        {
            /* Hiển thị dữ liệu */
            btnThem.Enabled = true; 
            if (strMaDonViHanhChinh != "")
                grdDuAn.Columns.Clear();
            /* Xóa dữ liệu trên Form */
            this.TrangThaiBanDau();
            /* Khởi tạo giá trị ban đầu cho biến dùng chung */
            strMaDonViHanhChinh = "";
            /* Trạng thái chức năng */
            this.TrangThaiChucNang(false, false);
            /* Trạng thái cập nhật */
            this.TrangThaiCapNhat(false);
            shortAction = 0;
        }
        private Boolean checking(System.Web.UI.WebControls.CheckBox cb)
        {  Boolean kt= false ;
        if (cb.Checked == true)
        {
            return kt = true;
        }
        else
            return kt = false;
        }
        public void UpdateData()
        {
            /* Khai báo và khởi tạo đối tượng Từ điển người ký GCN */
            clsToolUploadMap toolupload = new clsToolUploadMap();
            try
            {
                /* Gán giá trị cho các thuộc tính */
                toolupload.Connection = strConnection;
                toolupload.TenbanDo = txtTenDuAn.Text;
                toolupload.TyLe = txtTyLe.Text;
                toolupload.MabanDo = strMaBanDo; 
                
                toolupload.MaDonViHanhChinh = "1004"; 
                toolupload.DADT = kiemtracheck;

                string strResults = "";
                string str = "";
                if (shortAction == 2)
                {
                    // toolupload.MaDonViHanhChinh = grdQuanHuyen.CurrentRow.Cells["MaDonViHanhChinh"].Value.ToString() ;
                    strResults = toolupload.ThemDuAn(shortAction.ToString());
                }
                else if (shortAction == 3)
                {
                    //toolupload.MaDonViHanhChinh = grdQuanHuyen.CurrentRow.Cells["MaDonViHanhChinh"].Value.ToString(); ;
                    strResults = toolupload.CapNhatDuAn(shortAction.ToString());
                }
                else if (shortAction == 4)
                {
                    //toolupload.MaDonViHanhChinh = grdQuanHuyen.CurrentRow.Cells["MaDonViHanhChinh"].Value.ToString(); ;
                    strResults = toolupload.CapNhatDuAn(shortAction.ToString());
                }

              
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(" Cập nhật dữ liệu " + System.Environment.NewLine + " Dự án" + " Lỗi: " + ex.Message.ToString(), "DMCLand", MessageBoxButtons.OK);
            }
        }
        private Boolean  checking(System.Windows.Forms.CheckBox  cb)
        {
            Boolean kt = false;
            if (cb.Checked == true)
            {
                return kt = true;
            }
            else return kt = false;
        }
        private void toolStripDongBanDo_Click(object sender, EventArgs e)
        {
            MapInfo.Engine.Session.Current.Catalog.CloseAll();
        }
        private void cmdHienThi_Click(object sender, EventArgs e)
        {
            if (mapControl1.Map.Layers.Count > 0)
            {
                Table tableLayer = null;
                tableLayer = MapInfo.Engine.Session.Current.Catalog.GetTable(mapControl1.Map.Layers[0].Alias);
                FeatureLayer fl = new FeatureLayer(tableLayer);
                mapControl1.Map.SetView(fl);
                //tableLayer.Close();
            }
        }
        public void ExportDuLieuBanDo()
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\tmpFileQuyHoach\");
            FileInfo[] file = dir.GetFiles("*.tab");
            string pathDir = Application.StartupPath + @"\HienThiFileQuyHoach\";
            // xoa file tmp khi undo den giai doan giua rui lam tiep
            for (int i = 0; i < file.Length; i++)
            {
                XoaFileTmp(pathDir, file[i].Name);
            }
            //tao file
            for (int i = 0; i < file.Length; i++)
            {
                MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(lyrControl.Map.Layers[i].Alias);
                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());
                if (irfc != null)
                {
                    ExportsFileTab(lyrControl.Map.Layers[i].Alias, irfc);
                }
            }
        }
        public void GhiFile()
        {
            try
            {
                StaProgressBar.Visible = true;

                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\tmpFileQuyHoach\");
                FileInfo[] file = dir.GetFiles("*.tab");
                string pathDir = Application.StartupPath + @"\tmpFileQuyHoach\";
                //xoa tat ca cac file da co trong thu muc tmpFileQuyHoach

                StaProgressBar.Maximum = file.Length;
                StaProgressBar.Value = 0;
                for (int i = 0; i < file.Length; i++)
                {
                    XoaFileTmp(pathDir, file[i].Name);
                    StaProgressBar.Value = StaProgressBar.Value + 1;
                }
                // tao moi cac file temp moi

                for (int i = 0; i < lyrControl.Map.Layers.Count; i++)
                {
                    StaProgressBar.Value = 0;
                    MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(lyrControl.Map.Layers[i].Alias);
                    IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());
                    if (irfc != null)
                    {
                        // ExportsFileTab(lyrControl.Map.Layers[i].Alias, irfc);
                        // thuc hien copy file sang file temp de ghi
                        string path = "";

                        path = tab.TableInfo.TablePath;
                        string dirSoure = "";
                        string[] arpath = path.Split('\\');
                        for (int j = 0; j < arpath.Length - 1; j++)
                        {
                            dirSoure = dirSoure + arpath[j] + "\\";
                        }
                        File.Copy(dirSoure + lyrControl.Map.Layers[i].Alias + ".tab", pathDir + lyrControl.Map.Layers[i].Alias + ".tab");
                        File.Copy(dirSoure + lyrControl.Map.Layers[i].Alias + ".ID", pathDir + lyrControl.Map.Layers[i].Alias + ".ID");
                        File.Copy(dirSoure + lyrControl.Map.Layers[i].Alias + ".Map", pathDir + lyrControl.Map.Layers[i].Alias + ".Map");
                        File.Copy(dirSoure + lyrControl.Map.Layers[i].Alias + ".Dat", pathDir + lyrControl.Map.Layers[i].Alias + ".Dat");
                    }
                }

                //luu file tab vao csdl

                // xoa file tmp khi undo den giai doan giua rui lam tiep
                FileInfo[] fileGhi = dir.GetFiles("*.tab");

                StaProgressBar.Maximum = fileGhi.Length;
                StaProgressBar.Value = 0;
                for (int i = 0; i < fileGhi.Length; i++)
                {
                    string LayerName = fileGhi[i].Name.Remove(fileGhi[i].Name.Length - 4, 4);
                    byte[] TablFile = GhiFileMap(LayerName, "tab");
                    byte[] MaplFile = GhiFileMap(LayerName, "Map");
                    byte[] IDlFile = GhiFileMap(LayerName, "ID");
                    byte[] DatlFile = GhiFileMap(LayerName, "dat");
                    UpdateMapFile(1, LayerName, strMaDonViHanhChinh, TablFile, MaplFile, IDlFile, DatlFile, mapControl1.Map.Center.x, mapControl1.Map.Center.y, Convert.ToDouble(mapControl1.Map.Zoom.Value));
                    StaProgressBar.Value = StaProgressBar.Value + 1;
                }
                StaProgressBar.Visible = false;
            }
            catch (Exception ex)
            {
                StaProgressBar.Visible = true;
                MessageBox.Show("Lỗi ghi dữ liệu ");
            }

        }
        //LayMaThuaDat khi biet Ma HoSoCapGCN
        public void UpdateMapFile(int flag, string strLayerName, string MaDonViHanhChinh, byte[] fileTab, byte[] fileMap, byte[] fileID, byte[] filedat, double CenterX, double CenterY, double Zoom)
        {
            SqlConnection conn = new SqlConnection();
            conn = Connect();
            SqlCommand sqlCommand = new SqlCommand(); ;
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "spThongTinBanDoDuAn";
            SqlParameter sqlPara;
            DataSet dtResult = new DataSet();
            if ((MaDonViHanhChinh != null) & (MaDonViHanhChinh != "") & (MaDonViHanhChinh != "0"))
            {
                System.Data.SqlClient.SqlParameter MaBanDo = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter MaHoSo = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter LayerName = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter byFileTab = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter byFileMap = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter byFileID = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter byFileDat = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter dlCenterX = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter dlCenterY = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter dlZoom = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter intflag = new System.Data.SqlClient.SqlParameter();
                //@MaHoSo, @FileTab, @fileDat, @FileID, @FileMap, @PCenterX, @PCenterY, @Zoom

                MaBanDo = new System.Data.SqlClient.SqlParameter("@MaBanDo", System.Data.SqlDbType.NVarChar, 20);
                MaBanDo.Value = strMaBanDo;
                sqlCommand.Parameters.Add(MaBanDo);

                LayerName = new System.Data.SqlClient.SqlParameter("@LayerName", System.Data.SqlDbType.NVarChar, 200);
                LayerName.Value = strLayerName;
                sqlCommand.Parameters.Add(LayerName);
                MaHoSo = new System.Data.SqlClient.SqlParameter("@MaDonViHanhChinh", System.Data.SqlDbType.NVarChar, 20);
                MaHoSo.Value = MaDonViHanhChinh;
                sqlCommand.Parameters.Add(MaHoSo);
                byFileTab = new System.Data.SqlClient.SqlParameter("@FileTab", System.Data.SqlDbType.VarBinary, int.MaxValue - 1);
                byFileTab.Value = fileTab;
                sqlCommand.Parameters.Add(byFileTab);
                byFileDat = new System.Data.SqlClient.SqlParameter("@fileDat", System.Data.SqlDbType.VarBinary, int.MaxValue - 1);
                byFileDat.Value = filedat;
                sqlCommand.Parameters.Add(byFileDat);
                byFileID = new System.Data.SqlClient.SqlParameter("@FileID", System.Data.SqlDbType.VarBinary, int.MaxValue - 1);
                byFileID.Value = fileID;
                sqlCommand.Parameters.Add(byFileID);
                byFileMap = new System.Data.SqlClient.SqlParameter("@FileMap", System.Data.SqlDbType.VarBinary, int.MaxValue - 1);
                byFileMap.Value = fileMap;
                sqlCommand.Parameters.Add(byFileMap);
                dlCenterX = new System.Data.SqlClient.SqlParameter("@PCenterX", System.Data.SqlDbType.Decimal);
                dlCenterX.Value = CenterX;
                sqlCommand.Parameters.Add(dlCenterX);
                dlCenterY = new System.Data.SqlClient.SqlParameter("@PCenterY", System.Data.SqlDbType.Decimal);
                dlCenterY.Value = CenterY;
                sqlCommand.Parameters.Add(dlCenterY);
                dlZoom = new System.Data.SqlClient.SqlParameter("@Zoom", System.Data.SqlDbType.Decimal);
                dlZoom.Value = Zoom;
                sqlCommand.Parameters.Add(dlZoom);
                intflag = new System.Data.SqlClient.SqlParameter("@flag", System.Data.SqlDbType.Int);
                intflag.Value = flag;
                sqlCommand.Parameters.Add(intflag);
            }
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }
        public void ExportsFileTab(string LayerName, IResultSetFeatureCollection irfc)
        {
            string fileName = "";
            fileName = Application.StartupPath;

            //lay duong dan file du lieu temp can tao ra
            fileName = fileName + @"\tmpFileQuyHoach\" + LayerName + ".TAB";
            //tao bang tam 
            MapInfo.Data.Table table = CreateTmpTab(LayerName, "tmpFile" + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
            MapInfo.Data.TableInfoNative native = (MapInfo.Data.TableInfoNative)MapInfo.Data.TableInfoFactory.CreateFromFeatureCollection(MapInfo.Data.TableType.Native, table);
            native.TablePath = fileName;
            native.WriteTabFile();
            MapInfo.Data.Table nativetable = MapInfo.Engine.Session.Current.Catalog.CreateTable(native);
            table.Close();
            nativetable.Close();
            native.Dispose();
            nativetable = MapInfo.Engine.Session.Current.Catalog.OpenTable(fileName);

            StaProgressBar.Maximum = irfc.Count;
            StaProgressBar.Value = 0;

            // them du lieu thay doi tren map vao file vua tao        
            foreach (Feature f in irfc)
            {
                nativetable.InsertFeature(f);
                StaProgressBar.Value = StaProgressBar.Value + 1;
            }
            nativetable.Close();
            irfc.Close();
            StaProgressBar.Visible = false;
        }
        // thu tuc xoa file temp
        public void XoaFileTmp(string dir, string fileName)
        {
            string tabFile, datFile, idFile, mapFile;
            System.IO.FileInfo tabFileObj = new System.IO.FileInfo(dir + "\\" + fileName.ToUpper());
            tabFile = tabFileObj.Name.ToString();

            datFile = tabFileObj.Name.Replace(".TAB".ToUpper(), ".DAT".ToUpper());
            System.IO.FileInfo datFileObj = new System.IO.FileInfo(dir + "\\" + datFile);
            idFile = tabFileObj.Name.Replace(".TAB".ToUpper(), ".ID".ToUpper());
            System.IO.FileInfo idFileObj = new System.IO.FileInfo(dir + "\\" + idFile);
            mapFile = tabFileObj.Name.Replace(".TAB".ToUpper(), ".MAP".ToUpper());
            System.IO.FileInfo mapFileObj = new System.IO.FileInfo(dir + "\\" + mapFile);

            tabFileObj.Delete();
            datFileObj.Delete();
            idFileObj.Delete();
            mapFileObj.Delete();

        }
        //load file khi thuc thi undo redo
        public void LoadFileTmp(string fileName, MapControl pMap, string LayerName)
        {
            try
            {
                Table tabTmp = null;
                Table tab = null;
                //bang cua map vua load tu file
                tabTmp = MapInfo.Engine.Session.Current.Catalog.OpenTable(fileName);
                IResultSetFeatureCollection irfc = Session.Current.Catalog.Search(tabTmp, MapInfo.Data.SearchInfoFactory.SearchAll());
                //bang tren map hien thoi
                tab = MapInfo.Engine.Session.Current.Catalog.GetTable(LayerName);
                IResultSetFeatureCollection irfcTmp = Session.Current.Catalog.Search(tab, MapInfo.Data.SearchInfoFactory.SearchAll());

                int i = 0;
                foreach (Feature f in irfc)
                {
                    try
                    {
                        tab.DeleteFeature(irfcTmp[i]);
                    }
                    catch (Exception ex) { }
                    tab.InsertFeature(f);

                    i = i + 1;
                }
                irfc.Close();
                irfcTmp.Close();
                EditableLayer(pMap, LayerName, true);
                int iLayerIndex = pMap.Map.Layers.IndexOf(pMap.Map.Layers[LayerName]);
                pMap.Map.Layers.Move(iLayerIndex, 0);
            }
            catch (Exception ex) { }

        }
        //thuc thi viec them doi tuong vao Layer
        public byte[] GhiFileMap(string LayerName, string KieuFile)
        {
            string file = "";
            byte[] byfile;
            string fileName = "";
            fileName = Application.StartupPath;
            //lay duong dan file du lieu temp can tao ra
            file = fileName + @"\tmpFileQuyHoach\" + LayerName + "." + KieuFile;
            byfile = ReadFile(file);
            return byfile;
        }
        public byte[] ReadFile(string strPath)
        {
            //'Initialize byte array with a null value initially.
            byte[] byteData;
            //'Use FileInfo object to get file size.
            FileInfo fInfo = new System.IO.FileInfo(strPath);
            long numBytes;
            numBytes = fInfo.Length;
            //'Open file stream de doc file
            FileStream fStream;
            fStream = new System.IO.FileStream(strPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //'Use BinaryReader to read file stream into byte array.
            System.IO.BinaryReader br = new System.IO.BinaryReader(fStream);
            //'When you use BinaryReader, you need to supply number of bytes to read from file.
            //'In this case we want to read entire file. So supplying total number of bytes.
            byteData = br.ReadBytes((int)numBytes);
            return byteData;
        }
        public bool WriteFile(string LayerName, string KieuFile, byte[] byteContent)
        {
            FileStream objFstream = null;
            try
            {
                objFstream = File.Open(Application.StartupPath + @"\HienThiFileQuyHoach\" + LayerName + "." + KieuFile, FileMode.Create, FileAccess.Write);
                long lngLen = byteContent.Length;
                objFstream.Write(byteContent, 0, (int)lngLen);
                objFstream.Flush();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Lỗi ghi dữ liệu: " + ex.Message);
                return false;
            }
            finally
            {
                objFstream.Close();
            }
        }
        public DataTable GetFileMap(int flag, string MaDonViHanhChinh)
        {
            DataTable dt = new DataTable();
            if ((MaDonViHanhChinh != "") & (MaDonViHanhChinh != "") & (MaDonViHanhChinh != "0"))
            {
                SqlConnection conn = new SqlConnection();
                conn = Connect();

                SqlCommand sqlCommand = new SqlCommand(); ;
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "spThongTinBanDoDuAn";


                System.Data.SqlClient.SqlParameter MaBanDo = new System.Data.SqlClient.SqlParameter();
                MaBanDo = new System.Data.SqlClient.SqlParameter("@MaBanDo", System.Data.SqlDbType.NVarChar, 20);
                MaBanDo.Value = grdDuAn.CurrentRow.Cells["MaBanDo"].Value.ToString();
                sqlCommand.Parameters.Add(MaBanDo);
                System.Data.SqlClient.SqlParameter MaHoSo = new System.Data.SqlClient.SqlParameter();
                MaHoSo = new System.Data.SqlClient.SqlParameter("@MaDonViHanhChinh", System.Data.SqlDbType.NVarChar, 20);
                MaHoSo.Value = MaDonViHanhChinh;
                sqlCommand.Parameters.Add(MaHoSo);
                System.Data.SqlClient.SqlParameter intflag = new System.Data.SqlClient.SqlParameter();
                intflag = new System.Data.SqlClient.SqlParameter("@flag", System.Data.SqlDbType.Int);
                intflag.Value = flag;
                sqlCommand.Parameters.Add(intflag);

                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(dt);
            }
            return dt;
        }
        private void toolXuatFileMap(string MaDonViHanhChinh)
        {
            DataTable dt = new DataTable();
            dt = GetFileMap(0, MaDonViHanhChinh);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string LayerName = "";
                    LayerName = dt.Rows[i]["LayerName"].ToString();
                    if (WriteFile(LayerName, "tab", (byte[])dt.Rows[i]["FileTab"]) == false)
                    {
                        MessageBox.Show(" Không export được file Tab");
                        return;
                    }
                    if (WriteFile(LayerName, "Dat", (byte[])dt.Rows[i]["FileDat"]) == false)
                    {
                        MessageBox.Show(" Không export được file Dat");
                        return;
                    }
                    if (WriteFile(LayerName, "ID", (byte[])dt.Rows[i]["FileID"]) == false)
                    {
                        MessageBox.Show(" Không export được file ID");
                        return;
                    }
                    if (WriteFile(LayerName, "Map", (byte[])dt.Rows[i]["FileMap"]) == false)
                    {
                        MessageBox.Show(" Không export được file Map");
                        return;
                    }
                }
            }
        }
        //======================chua su dung
        public void UpdateDoiTuong(Table tab, FeatureGeometry myFeature, string DoiTuong, CompositeStyle style)
        {
            MIConnection Connection = new MIConnection();
            Connection.Open();
            if (DoiTuong == "")
            {
                DoiTuong = "0";
            }
            int tmpDoiTuong;
            tmpDoiTuong = Convert.ToInt32(DoiTuong);
            MapInfo.Data.MICommand micomm = Connection.CreateCommand();
            //khai báo câu lệnh select
            micomm.CommandText = "insert into " + tab.Alias + " (MI_Geometry,MaDoiTuong,MI_STYLE) values(@obj,@MaDoiTuong,@MyStyle)";
            //truyền giá trị tham biến
            micomm.Parameters.Add("@obj", myFeature);
            micomm.Parameters.Add("@MaDoiTuong", DoiTuong);
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
        //thuc thi viec them doi tuong vao Layer
        public void UpdateLoadDoiTuong(Table tab, FeatureGeometry myFeature, string DoiTuong, Style style)
        {
            MIConnection Connection = new MIConnection();
            Connection.Open();
            if (DoiTuong == "")
            {
                DoiTuong = "0";
            }
            int tmpDoiTuong;
            tmpDoiTuong = Convert.ToInt32(DoiTuong);
            MapInfo.Data.MICommand micomm = Connection.CreateCommand();
            //khai báo câu lệnh select
            micomm.CommandText = "insert into " + tab.Alias + " (MI_Geometry,MaDoiTuong,MI_STYLE) values(@obj,@MaDoiTuong,@MyStyle)";
            //truyền giá trị tham biến
            micomm.Parameters.Add("@obj", myFeature);
            micomm.Parameters.Add("@MaDoiTuong", DoiTuong);
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
        //cho phep thao tac chinh sua tren layer hay ko
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
        }
        //lay ma doi duong de dua vao CSDL
        public String GetMaDoiTuong(Feature myFeature, string LayerName)
        {
            string Value;
            Value = "";
            try
            {
                MapInfo.Data.MIConnection connection = new MapInfo.Data.MIConnection();
                connection.Open();
                MapInfo.Data.MICommand command = connection.CreateCommand();
                command.CommandText = "select MaDoiTuong from " + LayerName + " WHERE obj=@obj";
                command.Parameters.Add("@obj", myFeature.Geometry);
                MapInfo.Data.MIDataReader dataReader = null;

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    Value = dataReader.GetValue("MaDoiTuong").ToString();
                }
                command.Dispose();
                connection.Close();
                connection.Dispose();
                dataReader.Dispose();
            }
            catch (Exception ex)
            {
                return "";
            }
            return Value;
        }
        // tao bang temp
        public Table CreateTmpTab(string tabOld, string TabTmpName)
        {
            MapInfo.Data.Table tab = MapInfo.Engine.Session.Current.Catalog.GetTable(tabOld);
            //TableInfo
            MapInfo.Data.TableInfo ti = MapInfo.Data.TableInfoFactory.CreateTemp(TabTmpName);
            for (int i = 0; i < tab.TableInfo.Columns.Count; i++)
            {
                if (tab.TableInfo.Columns[i].Alias.ToUpper() != "Obj".ToUpper() && tab.TableInfo.Columns[i].Alias.ToUpper() != "MI_Geometry".ToUpper() && tab.TableInfo.Columns[i].Alias.ToUpper() != "MI_Style".ToUpper())
                {
                    if (tab.TableInfo.Columns[i].DataType == MIDbType.String)
                    {
                        ti.Columns.Add(new MapInfo.Data.Column(tab.TableInfo.Columns[i].Alias, tab.TableInfo.Columns[i].DataType, 10, 2));
                    }
                    else
                    {
                        ti.Columns.Add(new MapInfo.Data.Column(tab.TableInfo.Columns[i].Alias, tab.TableInfo.Columns[i].DataType));
                    }
                }
            }
            if (MapInfo.Engine.Session.Current.Catalog.GetTable(TabTmpName) != null)
            {
                MapInfo.Engine.Session.Current.Catalog.CloseTable(TabTmpName);
            }
            MapInfo.Data.Table table = MapInfo.Engine.Session.Current.Catalog.CreateTable(ti);
            return table;
        }
        //ham dung de di chuyen panel (su kien mouseMove)
        public void PanMouseMove(System.Windows.Forms.Panel p, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Control C = p;
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    int dx = Control.MousePosition.X - MousePositionBeforeMoved.X;
                    int dy = Control.MousePosition.Y - MousePositionBeforeMoved.Y;
                    C.Location = new System.Drawing.Point(LocationBeforeMoved.X + dx, LocationBeforeMoved.Y + dy);
                }
            }
        }
        //ham dung de di chuyen panel (su kien mouseDown)
        public void PanMouseDown(System.Windows.Forms.Panel p, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MousePositionBeforeMoved = Control.MousePosition;
                LocationBeforeMoved = p.Location;
            }
        } 
        private void panMenuPanToanDo_MouseDown(object sender, MouseEventArgs e)
        {
            PanMouseDown(panToaDo, e);
        }
        private void panMenuPanToanDo_MouseMove(object sender, MouseEventArgs e)
        {
            PanMouseMove(panToaDo, e);
        }
        private void cmdClosePanToaDo_Click(object sender, EventArgs e)
        {
            panToaDo.Hide();
        }
        private void mapToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        { 
            string MyCurso = e.Button.Name;
            if (MyCurso == toolBarThongTin.Name)
            {
                toolBarThongTin.Pushed = true;
                cboLayer.Items.Clear();
                for (int i = 0; i < lyrControl.Map.Layers.Count; i++)
                {
                    cboLayer.Items.Add(lyrControl.Map.Layers[i].Alias);
                }

                panToaDo.Hide();
                panLayer.Show();
            }
            else
            {
                toolBarThongTin.Pushed = false;
            }
        }
        public void FeatureSelected(object sender, FeatureSelectedEventArgs e)
        {
            try
            {
                string strLayerName = "";
                strLayerName = cboLayer.Text;
                if (strLayerName != "")
                {
                    Table table = null;
                    table = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerName);

                    grThongTin.Height = 25 * (table.TableInfo.Columns.Count - 1);
                    panToaDo.Height = grThongTin.Height + 50;
                    grThongTin.Rows.Clear();
                    grThongTin.Rows.Add(table.TableInfo.Columns.Count - 1);
                    for (int i = 1; i < table.TableInfo.Columns.Count - 1; i++)
                    {
                        if (table.TableInfo.Columns[i].Alias != "Obj")
                        {
                            grThongTin.Rows[i].Cells[0].Value = table.TableInfo.Columns[i].Alias;
                            grThongTin.Rows[i].Cells[0].ReadOnly = true;
                        }
                    }
                    //lấy tập hợp tất cả các đối tượng được chọn
                    IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
                    if (irfc == null)
                    {
                        return;
                    }
                    if (irfc.Count != 1)
                    {
                        return;
                    }
                    for (int i = 1; i < table.TableInfo.Columns.Count - 1; i++)
                    {
                        if (table.TableInfo.Columns[i].Alias != "Obj")
                        {
                            DMC.GIS.Common.FeatureInfo featureInfo = new DMC.GIS.Common.FeatureInfo();
                            MapInfo.Data.Feature feature = featureInfo.GetSelectedLandInfo(mapControl1.Map, strLayerName);
                            grThongTin.Rows[i].Cells[1].Value = feature[table.TableInfo.Columns[i].Alias].ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { }

        }
        public void FeatureSelecting(object sender, FeatureSelectingEventArgs e)
        {
            e.Cancel = false;
        }      
        private void panmnuLopLayer_MouseDown(object sender, MouseEventArgs e)
        {
            PanMouseDown(panLayer, e);
        }
        private void panmnuLopLayer_MouseMove(object sender, MouseEventArgs e)
        {
            PanMouseMove(panLayer, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panLayer.Hide();
        } 
        private void cmdChapNhan_Click(object sender, EventArgs e)
        {
            string strLayerName = "";
            strLayerName = cboLayer.Text;
            if (strLayerName != "")
            {
                Table table = null;
                table = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerName);
                //lấy tập hợp tất cả các đối tượng được chọn
                IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[table];
                if (irfc == null)
                {
                    return;
                }
                if (irfc.Count != 1)
                {
                    return;
                }
                for (int i = 0; i < table.TableInfo.Columns.Count - 1; i++)
                {
                    if (grThongTin.Rows.Count > 0)
                    {

                        if (table.TableInfo.Columns[i].Alias != "Obj")
                        {
                            /* Cập nhật thông tin thửa đất */
                            DMC.GIS.Common.FeatureInfo featureInfo = new DMC.GIS.Common.FeatureInfo();
                            MapInfo.Data.Feature feature = featureInfo.GetSelectedLandInfo(mapControl1.Map, strLayerName);
                            if (feature == null)
                                return;
                            feature[table.TableInfo.Columns[i].Alias] = grThongTin.Rows[i].Cells[1].Value.ToString().Trim();
                            feature.Update(true);
                        }
                    }
                }


            }
        }
        
        private void panMenuPanToanDo_MouseDown_1(object sender, MouseEventArgs e)
        {
            PanMouseDown(panToaDo, e);

        }
        private void panMenuPanToanDo_MouseMove_1(object sender, MouseEventArgs e)
        {
            PanMouseMove(panToaDo, e);
        }
        private void panToaDo_MouseMove(object sender, MouseEventArgs e)
        {
            PanMouseMove(panToaDo, e);
        }
        private void panToaDo_MouseDown(object sender, MouseEventArgs e)
        {
            PanMouseMove(panToaDo, e);
        }
        private void panmnuLopLayer_MouseDown_1(object sender, MouseEventArgs e)
        {
            PanMouseDown(panLayer, e);
        }
        private void panmnuLopLayer_MouseMove_1(object sender, MouseEventArgs e)
        {
            PanMouseMove(panLayer, e);
        }
        private void panLayer_MouseMove(object sender, MouseEventArgs e)
        {
            PanMouseMove(panLayer, e);
        }
        private void panLayer_MouseDown(object sender, MouseEventArgs e)
        {
            PanMouseDown(panLayer, e);
        }
 

    }
    }