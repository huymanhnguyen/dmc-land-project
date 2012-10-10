using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HienThiBanDoTongThe
{
    public  class LayerControlChooseCoordSys
    {
        #region Chọn hệ tọa độ
        //public  void AddChooseCoordSysMenuitem( ref MapInfo.Windows.Controls.LayerControl layerControl )
        //{
        //    // Create a new menuitem, which calls the MenuItemChooseCoordSys
        //    // method (see below). 
        //    System.Windows.Forms.MenuItem chooseCoordSysMenuItem = new System.Windows.Forms.MenuItem("&Chọn hệ tọa độ...",
        //        new System.EventHandler(this.MenuItemChooseCoordSys));

        //    // Each type of object that can appear in the layer tree 
        //    // has a collection of menuitems displayed when the user
        //    // right-clicks.  Obtain a reference to that collection, 
        //    // and add our new menuitem to the collection. 
        //    System.Collections.IList menuItems =
        //        layerControl.GetLayerTypeMenuItems(typeof(MapInfo.Mapping.Map));
        //    /* Xóa menu mặc định */
        //    menuItems.Clear();

        //    // Insert a separator and a new menuitem to the collection of menuitems.  
        //    menuItems.Add(new System.Windows.Forms.MenuItem("-"));
        //    menuItems.Add(chooseCoordSysMenuItem);
        //}
        //// The method called when the user chooses the Choose Coordinate System menuitem
        //public  void MenuItemChooseCoordSys(ref MapInfo.Windows.Controls.MapControl mapControl, Object sender, System.EventArgs e)
        //{
        //    if (mapControl.Map.IsDisplayCoordSysReadOnly)
        //    {
        //        // We cannot allow the user to change the coordinate system if 
        //        // the coordinate system is locked due to a raster layer. 
        //        //MessageBox.Show("Coordinate system is currently restricted, due to a raster layer.");
        //    }
        //    else
        //    {
        //        MapInfo.Windows.Dialogs.CoordSysPickerDlg csysDlg = new MapInfo.Windows.Dialogs.CoordSysPickerDlg();
        //        csysDlg.SelectedCoordSys = mapControl.Map.GetDisplayCoordSys();
        //        if (csysDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            MapInfo.Geometry.CoordSys csysNew = csysDlg.SelectedCoordSys;
        //            if (csysNew != mapControl.Map.GetDisplayCoordSys())
        //            {
        //                mapControl.Map.SetDisplayCoordSys(csysNew);
        //            }
        //        }
        //    }
        //}

        #endregion
    }
}
