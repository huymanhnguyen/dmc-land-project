using System.Drawing;
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
using MapInfo.Windows.Dialogs;
using DMC.GIS.Common;
using MapInfo.Data.Find;
using MapInfo.Text;
using System;

namespace DMC.Land.SoanHoSo
{

    public partial class frmDieuKhien : Form
    {
        private bool AnHienForm;
        private string strConnection; 
        private string strConnectionString;
        private string strBanDo;
        private string strNhanDinh;
        private string strNhanThua;
        private string strNhanCanh;
        private long  strFeatureID;
        private string strLayerName;
        private string strNhanNode;
        private string strDuongBao;
        private string strNhanKichThuoc;
        private string strTenBang;
        public ToolStripProgressBar toolProcess;
       
        CompositeStyle cs = new CompositeStyle();
        MapControl map;
        string strCurrentLayer;
        string strLableName;
        double TyleBanDo;
        private DMC.GIS.Common.clsMainSoanHoSo cls;
        private DMC.GIS.Common.clsDatabase clsData;
        private bool bolactiveTool=false ;
        ctrSoanHS ctr;
        private double dlTyLeZommView = 0;
        private double dlTyLeDienTichThua = 0;

        public double TyLeDienTichThua
        {
            get { return dlTyLeDienTichThua; }
            set { dlTyLeDienTichThua = value; }
        }
        public double TyLeZommView
        {
            get { return dlTyLeZommView; }
            set { dlTyLeZommView = value; }
        }
        public ctrSoanHS CtrForm
        {
            get { return ctr; }
            set { ctr = value; }
        }
        public bool ActiveTool
        {
            get { return bolactiveTool; }
            set { bolactiveTool = value; }
        }
        public string Connection
        {
            set { strConnection = value; }
        }
        public string ConnectionString
        {
            set { strConnectionString = value; }
        }
        public string BanDo
        {
            set { strBanDo = value; }
        }
        public string TenBang
        {
            set { strTenBang = value; }
        }
        public string NhanThua
        {
            set { strNhanThua = value; }
        }
        public string NhanDinh
        {
            set { strNhanDinh = value; }
        }
        public string NhanNode
        {
            set { strNhanNode = value; }
        }
        public string NhanKichThuoc
        {
            set { strNhanKichThuoc = value; }
        }
        public string NhanCanh
        {
            set { strNhanCanh = value; }
        }
        public string DuongBao
        {
            set { strDuongBao = value; }
        }
        public string LayerName
        {
            set { strLayerName = value; }
        }
        public long  FeatureID
        {
           set{ strFeatureID = value;}
        }
        public ToolStripProgressBar  Process
        {
            set { toolProcess = value; }
        }
        public frmDieuKhien()
        {
            InitializeComponent();
            clsData = new DMC.GIS.Common.clsDatabase();
            clsData.SetConnection(strConnection);
            cls = new DMC.GIS.Common.clsMainSoanHoSo();
            cls.LayerName(strLayerName);
            cls.BanDo(strBanDo);
            cls.Connectionstring(strConnectionString);
            cls.SetConnection(strConnection);
            cls.TyLeZoomView = dlTyLeZommView;
            AnHienForm = false;
        }
        #region Các hàm thuộc tính 
            public MapControl  getMapConT() {
                return map;
            }
            public void SetMapConT(MapControl Value)
            {
                map = Value;
            }
            public void SetCurentLayer(string Value)
            {
                strCurrentLayer = Value;
            }
            public void SetLableName(string Value)
            {
                strLableName = Value;
            }
            public void SetTyLe(double  Value)
            {
                TyleBanDo = Value;
            }
        #endregion
        #region Gọi các hàm xử lý 
            //hien thi nhan dỉnh cho thửa đất
                    private void cmdNhan_Click(object sender, EventArgs e)
                {
                    ///* Khai báo khoảng cách nhãn và góc thửa */
                    //double dblDistance;
                    ///* Khai báo biến độ cao của nhãn */
                    //double dblHeight;
                    ///* Khai báo biến độ Rộng của nhãn */
                    //double dblWidth;
                    ///* Khai báo và khởi tạo Form nhập khoảng cách */
                    //DMC.Land.TachThua.frmVertexLable vertexLable = new DMC.Land.TachThua.frmVertexLable();
                    ///* Thiết lập hộp hồi thoại giữa màn hình */
                    //vertexLable.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    ///* Hiển thị hộp hồi thoại */
                    //vertexLable.ShowDialog();
                    ///* Nhận giá trị khoảng cách từ đỉnh tởi nhãn */
                    //dblDistance = vertexLable.Distance;
                    ///* Nhận giá trị chiều cao của nhãn */
                    //dblHeight = vertexLable.Height;
                    ///* Nhận giá trị chiều Rông của nhãn */
                    //dblWidth = vertexLable.Width;
                    ///* Khai báo lớp chứa phương thức tạo nhãn đỉnh */
                    //DMC.GIS.Common.VertexLable VertexLable = new DMC.GIS.Common.VertexLable();
                    ////VertexLable.DeleteVertexLable(mapControl1.Map, "Thửa đất");
                    ///* Tạo nhãn đỉnh */
                    //VertexLable.CreateVertexLable(map.Map, "Thửa_đất", dblDistance, dblHeight, dblWidth,"MaDoiTuong","1");
                    cls.HeightFont = ctr.heightFont;
                    cls.WidthFont = ctr.widthFont ;
                    cls.MyFontName  = ctr.fontName ;
                    cls.TyLeZoomView = dlTyLeZommView;
                    cls.DienTichThua = dlTyLeDienTichThua;
                    cls.HienThiNhanDinh(strCurrentLayer, map, TyleBanDo, strNhanDinh, toolProcess, strLayerName);
                    ctr.ExportsFileTab();
                 }
        //thuc hien chuc nang dan kich thuoc cho doi tuong thua dat
                private void cmdKichThuoc_Click(object sender, EventArgs e)
                {
                    cls.HeightFont = ctr.heightFont;
                    cls.WidthFont = ctr.widthFont;
                    cls.MyFontName = ctr.fontName;
                    cls.TyLeZoomView = dlTyLeZommView;
                    cls.DienTichThua = dlTyLeDienTichThua;
                    cls.HienThiKichThuoc(strCurrentLayer, map, cs, TyleBanDo, strNhanDinh, toolProcess, strLayerName);
                    ctr.ExportsFileTab();
                }
        //thuc hien chuc nang gan nhan dinh cho thua dat
                private void cmdDinh_Click(object sender, EventArgs e)
                {
                    cls.TyLeZoomView = dlTyLeZommView;
                    cls.DienTichThua  = dlTyLeDienTichThua ;
                    cls.HienThiDinh(strCurrentLayer, map, strNhanDinh , strLayerName);
                    ctr.ExportsFileTab();
                }
        //thuc hien chuc nang gan duong bao cho doi tuong thua dat
               private void cmdDuongBao_Click(object sender, EventArgs e)
                {
                    /* Khoảng cách tường bao và thửa đất */
                    double dblDistance;
                    /* Khai báo và khởi tạo Form nhập khoảng cách */
                    DMC.Land.TachThua.frmWallBorder frmWallBorder = new DMC.Land.TachThua.frmWallBorder();
                    /* Thiết lập chế độ hiển thị hộp hồi thoại giữa màn hình */
                    frmWallBorder.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    /* Hiển thị hộp hồi thoại nhận tham số trước khi tạo bao tường */
                    frmWallBorder.ShowDialog();
                    dblDistance = frmWallBorder.Distance;
                    ///* Khai báo chế độ lấy tương đối */
                    //bool boolRelatively = false;
                    //boolRelatively = frmWallBorder.Relatively;
                    /* Khai báo lớp chứa phương thức Tạo bao tường */
                    DMC.GIS.Common.WallBorderlines WallBorder = new DMC.GIS.Common.WallBorderlines();
                    /* Tạo bao tường */
                    if (!frmWallBorder.Relatively)
                    {
                        /* Trường hợp vẽ chính xác */
                        WallBorder.CreateWallBorderline(map.Map, strLayerName, dblDistance);
                        ctr.ExportsFileTab();
                    }
                    else
                    {
                        /* Trường hợp vẽ tương đối - theo Buffer */
                        WallBorder.CreateWallBorderlineWithBuffer(map.Map, strLayerName, dblDistance);
                        ctr.ExportsFileTab();
                    }

                }
        //dan ten thua , dien tich cho thua dat duoc chon
                private void cmdThua_Click(object sender, EventArgs e)
                {
                    cls.HeightFont = ctr.heightFont;
                    cls.WidthFont = ctr.widthFont;
                    cls.MyFontName = ctr.fontName;
                    clsData.SetConnection(strConnection);
                    string[] TenThuaDienTich = new string[2];
                    TenThuaDienTich = clsData.TenThuaDienTich(strBanDo, strFeatureID);
                    cls.TyLeZoomView = dlTyLeZommView;
                    cls.DienTichThua = dlTyLeDienTichThua ;
                    cls.TenThuaDienTich(strBanDo, strLayerName, map, cs, TyleBanDo, strNhanDinh, strLayerName, strFeatureID, TenThuaDienTich);
                    ctr.ExportsFileTab();
                }
            #endregion
        #region Gọi các hàm xoá đối tượng
        //xoa dinh cua thua dat da dan
            private void cmdXoaDinh_Click(object sender, EventArgs e)
            {
                cls.XoaFeature(map, strNhanNode, "MapInfo.Geometry.Point", "3", strLayerName);
                ctr.ExportsFileTab();
            }
        //xoa nhan dinh cua thua da gan nhna
            private void cmdXoaNhan_Click(object sender, EventArgs e)
            {
                cls.XoaFeature(map, strNhanDinh, "MapInfo.Geometry.LegacyText", "1", strLayerName);
                ctr.ExportsFileTab();
            }
        //xoa nhan kich thuoc dua doi tuong chieu dan canh
            private void cmdXoaKichThuoc_Click(object sender, EventArgs e)
            {
                cls.XoaFeature(map, strNhanCanh, "MapInfo.Geometry.LegacyText", "2", strLayerName);
                ctr.ExportsFileTab();
            }
        //xoa duong bao cua doi tuong thua dat
            private void cmdXoaDuongBao_Click(object sender, EventArgs e)
            {
                cls.XoaFeature(map, strDuongBao, "MapInfo.Geometry.MultiCurve", "4", strLayerName);
                ctr.ExportsFileTab();
            }
        //xoa nhan ten thua dat va dien tich
            private void cmdXoaTenThua_Click(object sender, EventArgs e)
            {
                cls.XoaFeature(map, strNhanThua, "MapInfo.Geometry.LegacyText", "5", strLayerName);
                ctr.ExportsFileTab();
            }
        #endregion
            public bool KiemTraSize(double size)
            {
                bool kt;
                double sizeGioiHan = 0;
                    Table tab = null;
                    tab = MapInfo.Engine.Session.Current.Catalog.GetTable(strLayerName);
                    IResultSetFeatureCollection irfc = Session.Current.Selections.DefaultSelection[tab];
                    if (irfc == null) {
                        return false;
                    }
                    if (irfc.Count == 0)
                    {
                        return false;
                    }
                    foreach(Feature f in irfc){
                        if (f.Geometry.GetType().ToString().Equals("MapInfo.Geometry.MultiPolygon"))
                        {
                            if (f.Geometry.Bounds.Height() > f.Geometry.Bounds.Width())
                            {
                                sizeGioiHan = f.Geometry.Bounds.Width();
                            }
                            else {
                                sizeGioiHan = f.Geometry.Bounds.Height();
                            }
                            if ((size > sizeGioiHan) || (size < 0))
                            {

                                MessageBox.Show("Không nên cho đường bao quá lớn (0-" + Convert.ToInt16(sizeGioiHan) + ") !!");
                                txtSize.Text = "" + 5 + "";
                                kt = false;
                                return kt;
                            }
                            else {
                                kt = true;
                            }
                        }
                    }

                    kt = true;
                return kt;
            }
        //thoat
        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
	    }
    }
