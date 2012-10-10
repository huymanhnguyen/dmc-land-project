using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMC.GIS.Common;

namespace HienThiBanDoTongThe
{
    public partial class frmBanDoTongThe : Form
    {
        public frmBanDoTongThe()
        {
            InitializeComponent();
            #region Khai báo các sự kiện cho lớp bản đồ tổng thể với các hàm sự kiện tương ứng
            /* Sự kiện phép chọn/không chọn đối tượng */
            mapControl1.Tools.FeatureSelecting += new MapInfo.Tools.FeatureSelectingEventHandler(FeatureSelecting);
            /* Sự kiện cho phép/không cho phép thêm đối tượng */
            mapControl1.Tools.FeatureAdding += new MapInfo.Tools.FeatureAddingEventHandler(FeatureAdding);
            /* Sự kiện cho phép thay đổi/không thay đổi đối tượng */
            mapControl1.Tools.FeatureChanging += new MapInfo.Tools.FeatureChangingEventHandler(FeatureChanging);
            /* Sự kiện cho phép/không cho phép thay đổi node đối tượng */
            mapControl1.Tools.NodeChanging += new MapInfo.Tools.NodeChangingEventHandler(NodeChanging);
            /* Sự kiện cho phép/không cho phép thêm Lable (Nhãn) của đối tượng */
            mapControl1.Tools.LabelAdding += new MapInfo.Tools.LabelAddingEventHandler(LabelAdding);
            #endregion
        }

        #region Khai báo các biến sự kiện thực thi trạng thái bản đồ
        
        /// <summary>
        /// Biến sự kiện Cancel Selection. Mặc định cho chọn các đối tượng bản đồ
        /// </summary>
        static bool boolFeatureSelection = true;
        /// <summary>
        /// Biến sự kiện Feature Adding. Mặc định không cho phép thêm các Feature lên bản đồ
        /// </summary>
        static bool boolFeatureAdding = false;
        static bool boolFeatureChange = false;
        static bool boolFeatureNodeChange = false;
        static bool boolFeatureLableAdding = false;

        #endregion

        #region Các hàm sự kiện thực thi chức năng bản đồ
        /// <summary>
        /// Hàm cho phép chọn/không chọn đối tượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeatureSelecting(object sender, MapInfo.Tools.FeatureSelectingEventArgs e)
        {
            e.Cancel = boolFeatureSelection;
        }

        /// <summary>
        /// Hàm cho phép thêm/không thêm đối tượng bản đồ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeatureAdding(object sender, MapInfo.Tools.FeatureAddingEventArgs e)
        {
            e.Cancel = boolFeatureAdding ;
        }
        #endregion

        /// <summary>
        /// Hàm cho phép/không cho phép thay đổi đối tượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeatureChanging(object sender, MapInfo.Tools.FeatureChangingEventArgs e)
        {
            e.Cancel = boolFeatureChange;
        }
        /// <summary>
        /// Cho phép/không cho phép thay đổi Node của đối tượng trên bản đồ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeChanging(object sender, MapInfo.Tools.NodeChangingEventArgs e)
        {
            e.Cancel = boolFeatureNodeChange;

        }
        /// <summary>
        /// Cho phép/không cho phép thêm Lable (Nhãn) vào bản đồ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelAdding(object sender, MapInfo.Tools.LabelAddingEventArgs e)
        {
             e.Cancel = boolFeatureLableAdding;
        }


        /* Khai báo và khởi tạo đối tượng */
        DLayers DMCGISActiveX = new DLayers();



        private void SetupLoad()
        {
            /* Đặt tên cho bản đồ */
            mapControl1.Map.Name = "Bản đồ địa chính";

            /* Không hiển thị ToolTip */
            layerControl1.ToolTip.Active = false;

            layerControl1.Map = mapControl1.Map;
            layerControl1.Tools = mapControl1.Tools;
            layerControl1.CheckBoxes = true;
            layerControl1.TabControl.Visible = false;
            layerControl1.ToolBar.Buttons[0].Visible = false;
            layerControl1.ToolBar.Buttons[1].Visible = false;
            layerControl1.ToolBar.Buttons[2].Visible = false;
        }

        private void toolBanDoTongTheConnection_Click(object sender, EventArgs e)
        {
            ///* Setup Map */
            //SetupMap();
            DMC.GIS.Common.LayerConnection MoBanDo = new DMC.GIS.Common.LayerConnection();

            MapInfo.Mapping.Map map = mapControl1.Map;

            //map = mapControl1.Map;
            ////MoBanDo.OpenLayer(ref  mapControl1, ref lyrs[0], "Nhà", "DRIVER={SQL Server};SERVER=dmc-chung;UID=sa;PWD =;PWD =;DATABASE=georgetown;Trusted_Connection=No;", "select * from Nha");

            MapInfo.Data.MIConnection miConnection = new MapInfo.Data.MIConnection();
            MoBanDo.OpenLayer(ref miConnection,  ref  map, "Nhà", "DRIVER=SQL Server;SERVER=dmc-chung;UID=administrator;APP=Microsoft (R) Visual Studio (R) 2008;WSID=THANHVL;DATABASE=georgetown;Trusted_Connection=Yes;","Nha3", "1");
            MoBanDo.OpenLayer(ref  miConnection,  ref   map, "Đất", "DRIVER=SQL Server;SERVER=dmc-chung;UID=administrator;APP=Microsoft (R) Visual Studio (R) 2008;WSID=THANHVL;DATABASE=georgetown;Trusted_Connection=Yes;", "Dat3", "1");

            /* Mặc định không hiển thị lớp nhà */
            map.Layers["Nhà"].Enabled = false;

            SetupLoad();

            /* Add menu chọn hệ tọa độ cho bản đồ */
            AddChooseCoordSysMenuitem();
            /* Add menu tạo Nhãn và Trạng thái cấp GCN cho các lớp bản đồ */
            AddLayerMenu();

        }

        private void frmBanDoTongThe_Load(object sender, EventArgs e)
        {
            SetupLoad();
        }

        #region Chọn hệ tọa độ
        private void AddChooseCoordSysMenuitem()
        {
            // Create a new menuitem, which calls the MenuItemChooseCoordSys
            // method (see below). 
            MenuItem chooseCoordSysMenuItem = new MenuItem("&Chọn hệ tọa độ...",
                new System.EventHandler(this.MenuItemChooseCoordSys));

            // Each type of object that can appear in the layer tree 
            // has a collection of menuitems displayed when the user
            // right-clicks.  Obtain a reference to that collection, 
            // and add our new menuitem to the collection. 
            System.Collections.IList menuItems =
                layerControl1.GetLayerTypeMenuItems(typeof(MapInfo.Mapping.Map));
            /* Xóa menu mặc định */
            menuItems.Clear();

            // Insert a separator and a new menuitem to the collection of menuitems.  
            menuItems.Add(new MenuItem("-"));
            menuItems.Add(chooseCoordSysMenuItem);
        }
        // The method called when the user chooses the Choose Coordinate System menuitem
        private void MenuItemChooseCoordSys(Object sender, System.EventArgs e)
        {
            if (mapControl1.Map.IsDisplayCoordSysReadOnly)
            {
                // We cannot allow the user to change the coordinate system if 
                // the coordinate system is locked due to a raster layer. 
                //MessageBox.Show("Coordinate system is currently restricted, due to a raster layer.");
            }
            else
            {
                MapInfo.Windows.Dialogs.CoordSysPickerDlg csysDlg = new MapInfo.Windows.Dialogs.CoordSysPickerDlg();
                csysDlg.SelectedCoordSys = mapControl1.Map.GetDisplayCoordSys();
                if (csysDlg.ShowDialog(this) == DialogResult.OK)
                {
                    MapInfo.Geometry.CoordSys csysNew = csysDlg.SelectedCoordSys;
                    if (csysNew != mapControl1.Map.GetDisplayCoordSys())
                    {
                        mapControl1.Map.SetDisplayCoordSys(csysNew);
                    }
                }
            }
        }

        #endregion
        #region Hiển thị LayerMenu
        private void AddLayerMenu()
        {
            // Add custom items to the FeatureLayer and LabelSource menus
            MapInfo.Samples.LayerControl.LayerControlEnhancer lce = new MapInfo.Samples.LayerControl.LayerControlEnhancer();
            lce.LayerControl = layerControl1;
            MapInfo.Mapping.Map map;
            map = mapControl1.Map;
            lce.AddLayerToLabelEnhancement(ref map);

            /* Test : Không hiển thị LableLayer Children */
            // Obtain the helper object that is being used to dictate the
            // behavior of LabelLayer nodes in the layer tree.
            MapInfo.Windows.Controls.ILayerNodeHelper labelLayerHelper =
                layerControl1.GetLayerTypeHelper(typeof(MapInfo.Mapping.LabelLayer));

            // Reconfigure the helper to specify that it should NOT display 
            // any "child" nodes.  By default, each LabelLayer does show a  
            // child node for each LabelSource in the layer.  Setting 
            // ShowChildren to false will cause LayerControl to not display
            // any nodes for LabelSource objects.  This simplifies the layer
            // tree, and prevents the user from seeing properties of 
            // individual LabelSources (which might or might not be 
            // appropriate for your application). 
            labelLayerHelper.ShowChildren = false;

            // Change which image is displayed for LabelLayer nodes.  
            // In this example we will set all LabelLayer nodes to display
            // with the icon that is ordinarly used for LabelSource nodes.
            MapInfo.Windows.Controls.ILayerNodeHelper labelSourceHelper =
                layerControl1.GetLayerTypeHelper(typeof(MapInfo.Mapping.LabelSource));

            labelLayerHelper.Image = labelSourceHelper.Image;
            /* EndTest */

        }
        #endregion

        private void mapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.PointF DisplayPoint = new PointF(e.X, e.Y);

            MapInfo.Geometry.DPoint MapPoint = new MapInfo.Geometry.DPoint();
            MapInfo.Geometry.DisplayTransform converter = this.mapControl1.Map.DisplayTransform;
            converter.FromDisplay(DisplayPoint, out MapPoint);
            this.statusBanDoTongThe.Items[0].Text = "Vị trí di chuột: " + MapPoint.x.ToString() + ", " + MapPoint.y.ToString();

        }

        private void toolTest_Click(object sender, EventArgs e)
        {
            if (boolFeatureSelection)
            {
                boolFeatureSelection = false;
            }
            else
            {
                boolFeatureSelection = true;
            }
        }





    }
}
