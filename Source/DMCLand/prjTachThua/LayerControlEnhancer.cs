///////////////////////////////////////////////////////////////////////////////
//
//   (c) Pitney Bowes MapInfo Corporation, 2008.  All rights reserved.
//
//   The source code below is provided as sample code only. The end user of the
//   Licensed Product that contains this code may use the code below for
//   development purposes. This software is provided by Pitney Bowes MapInfo
//   "as is" and any express or implied warranties, including, but not limited
//   to, the implied warranties of merchantability and fitness for a particular
//   purpose are disclaimed.  In no event shall Pitney Bowes MapInfo be liable
//   for any direct, indirect, incidental, special, exemplary, or consequential
//   damages (including, but not limited to, procurement of substitute goods or
//   services; loss of use, data or profits; or business interruption) however
//   caused and whether in contract, strict liability, or tort (including
//   negligence) arising in any way out of the use of this software, even if
//   advised of the possibility of such damage.
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using MapInfo.Mapping;
using MapInfo.Windows.Dialogs;
using MapInfo.Windows.Controls;
using MapInfo.Data;

namespace MapInfo.Samples.LayerControl
{
    /// <summary>
    /// A class that enhances a desktop LayerControl with custom context-menu items.
    /// 
    /// The following code demonstrates how you can use this class to add
    /// custom menuitems to the layer tree's right-click menu.   
    /// 
    ///   MapInfo.Samples.LayerControl.LayerControlEnhancer lce = 
    ///		new MapInfo.Samples.LayerControl.LayerControlEnhancer(); 
    ///   lce.LayerControl = layerControl1; 
    ///   lce.AddLayerToLabelEnhancement();
    ///   
    /// This code assumes that layerControl1 is a reference to an existing
    /// LayerControl object.  To apply this enhancement to the LayerControl that
    /// appears inside a LayerControlDlg dialog, reference the dialog's 
    /// LayerControl property. For example: 
    /// 
    ///   lce.LayerControl = mapToolBar1.LayerControlDlg.LayerControl; 
    /// 
    /// Once the enhancement has been applied, the user will be able to
    /// right-click on a FeatureLayer node or a LabelSource node, then 
    /// choose items off the context menu to find the LabelSource node
    /// (if any) that corresponds to the FeatureLayer node, and vice versa.
    /// 
    /// </summary>
    public class LayerControlEnhancer
    {
        MapInfo.Windows.Controls.LayerControl _lc = null;

        MapInfo.Mapping.Map mapTest;

        // Keep a reference to the first LabelLayer in the map, 
        // if there is one: 
        LabelLayer _firstLabelLayer = null;


        public LayerControlEnhancer()
        {
        }

        /// <summary>
        /// The LayerControl property must be assigned before you can 
        /// call the AddLayerToLabelEnhancement method. 
        /// </summary>
        public MapInfo.Windows.Controls.LayerControl LayerControl
        {
            get
            {
                return _lc;
            }
            set
            {
                _lc = value;
            }
        }

        /// <summary>
        /// Call this method to enhance the LayerControl with custom 
        /// menu items.  
        /// </summary>
        public void AddLayerToLabelEnhancement(ref MapInfo.Mapping.Map  map)
        {
            if (_lc == null)
            {
                throw new NullReferenceException("LayerControl property is null");
            }

            // Create new menuitems to find a LabelSource in the layer tree. 

            // "Find Labels" Menu item:
            // jumps from the selected FeatureLayer to a matching LabelSource 
            MenuItem gotoLabelsMenuItem = new MenuItem("Hiển thị nhãn",
                new System.EventHandler(this.MenuItemFindMatchingLabels),
                Shortcut.CtrlL);

            // "Find Similar Labels" menu item: 
            // jumps from a LabelSource to the NEXT LabelSource that uses 
            // the same table: 
            //////MenuItem gotoNextLabelsMenuItem =
            //////    new MenuItem("Hiển thị màu trạng thái cấp GCN",
            //////        new System.EventHandler(this.MenuItemFindMatchingLabels),
            //////            Shortcut.None);

            // Create new menuitems to find a FeatureLayer in the layer tree:

            // "Find Layer" Menu item: 
            // jumps from the selected LabelSource to a matching FeatureLayer  
            MenuItem gotoLayerMenuItem = new MenuItem("Find Similar &Layer",
                new System.EventHandler(this.MenuItemFindMatchingLayer),
                Shortcut.CtrlL);

            // "Find Similar Layer" Menu item: 
            // jumps from the selected FeatureLayer node to another FeatureLayer 
            // that is displaying the same table: 
            //////MenuItem gotoNextLayerMenuItem =
            //////    new MenuItem("Trạng thái cấp GCN",
            //////        new System.EventHandler(this.MenuItemFindMatchingLayer),
            //////        Shortcut.None);

            // Each type of object that can appear in the layer tree 
            // has a collection of menuitems displayed when the user
            // right-clicks.  Obtain a reference to that collection, 
            // and add our new menuitems to the collection. 

            IList labelsourceMenuItems =
                _lc.GetLayerTypeMenuItems(typeof(MapInfo.Mapping.LabelSource));

            /* Xóa LayerMenu mặc định */
            labelsourceMenuItems.Clear();

            // Insert a separator and new menuitems to the LabelSource menu. 
            labelsourceMenuItems.Add(new MenuItem("-"));
            labelsourceMenuItems.Add(gotoLayerMenuItem);
            //////labelsourceMenuItems.Add(gotoNextLabelsMenuItem);


            IList featurelayerMenuItems =
                _lc.GetLayerTypeMenuItems(typeof(MapInfo.Mapping.FeatureLayer));

            /* Xóa LayerMenu mặc định */
            featurelayerMenuItems.Clear ();

            // Insert a separator and new menuitems to the FeatureLayer menu. 
            featurelayerMenuItems.Add(new MenuItem("-"));
            featurelayerMenuItems.Add(gotoLabelsMenuItem);
            ////featurelayerMenuItems.Add(gotoNextLayerMenuItem);
            mapTest = map;


            /* Test: Xóa LableLayer */
            IList labellayerMenuItems =
                _lc.GetLayerTypeMenuItems(typeof(MapInfo.Mapping.LabelLayer ));

            /* Xóa LayerMenu mặc định */
            labellayerMenuItems.Clear();

        }

        // The method called when the user chooses the Find Labels menuitem 
        private void MenuItemFindMatchingLabels(Object sender, System.EventArgs e)
        {
            PerformFindLabels(ref  mapTest );
        }

        private void PerformFindLabels(ref  MapInfo.Mapping.Map map )
        {
            //// See which item the user right-clicked on. 
            //// NOTE: Do not use the LayerControl.SelectedObject property here, 
            //// because nodes in the layer tree are not immediately selected 
            //// when the user right-clicks; instead, use the 
            //// ContextMenuTargetObject property. 
            //object obj = _lc.ContextMenuTargetObject;
            //if (obj is FeatureLayer)
            //{
            //    // Identify the table that's used by the 
            //    // currently-selected FeatureLayer:  
            //    Table sourceTable = ((FeatureLayer)obj).Table;
            //    SelectNextLabelSource(sourceTable, null);
            //}
            //else if (obj is LabelSource)
            //{
            //    // Identify the table that's the basis for the 
            //    // currently-selected LabelSource: 
            //    Table sourceTable = ((LabelSource)obj).Table;
            //    SelectNextLabelSource(sourceTable, (LabelSource)obj);
            //}
            /* Test */

            object obj = _lc.ContextMenuTargetObject;

            if (obj is FeatureLayer)
            {
                // Identify the table that's used by the
                // currently-selected FeatureLayer 
                Table sourceTable = ((FeatureLayer)obj).Table;
                if (sourceTable.Alias == "Đất")
                {
                    /* Khai báo và khởi tạo đối tượng LableLayer */
                    DMC.GIS.Common.LableLayer NhanDat = new DMC.GIS.Common.LableLayer();
                    /* Hiển thị Số hiệu thửa đất */
                    NhanDat.ShowLabelLayer(ref map, "Đất", "tobando", "Nhãn đất (Tờ bản đồ) ", false, "LeftCenter");
                    NhanDat.ShowLabelLayer(ref map, "Đất", "SoThua", "Nhãn đất (Số thửa) ", true, "TopCenter");
                    /* Hiển thị Diện tích thửa đất */
                    NhanDat.ShowLabelLayer(ref map, "Đất", "DienTichTuNhien", "Nhãn đất (Diện tích)", false, "BottomCenter");
                }
                else if ( sourceTable.Alias == "Nhà")
                {
                    /* Khai báo và khởi tạo đối tượng LableLayer */
                    DMC.GIS.Common.LableLayer NhanDat = new DMC.GIS.Common.LableLayer();
                    /* Hiển thị Số hiệu thửa đất */
                    NhanDat.ShowLabelLayer(ref map, "Nhà", "LoaiNha", "Nhãn nhà", false, "CenterCenter");
                }
            }
            /* EndTest */
        }


        // The method called when the user chooses the Find Layer menuitem 
        private void MenuItemFindMatchingLayer(Object sender, System.EventArgs e)
        {
            PerformFindLayer();
        }

        private void PerformFindLayer()
        {
            //// See which item the user right-clicked on. 
            //// NOTE: Do not use the LayerControl.SelectedObject property here, 
            //// because nodes in the layer tree are not immediately selected 
            //// when the user right-clicks; instead, use the 
            //// ContextMenuTargetObject property.
            object obj = _lc.ContextMenuTargetObject;

            if (obj is FeatureLayer)
            {
                // Identify the table that's used by the
                // currently-selected FeatureLayer 
                Table sourceTable = ((FeatureLayer)obj).Table;
                if (sourceTable.Alias == "Đất")
                {
                    /* Khai báo và khởi tạo lớp chứa phương thức tạo Theme Trạng thái thửa đất */
                    DMC.GIS.Common.LayerTheme layerTheme = new DMC.GIS.Common.LayerTheme();
                    layerTheme.TrangThaiCapGCN(mapTest, "Đất", "Status", "Trạng thái cấp GCN");

                    ///* Test: Trạng thái cấp GCN */
                    //// Create a ranged theme on the USA layer.
                    //Map map = mapTest;
                    //FeatureLayer lyr = map.Layers["Đất"] as MapInfo.Mapping.FeatureLayer;
                    //MapInfo.Mapping.Thematics.IndividualValueTheme thm = new MapInfo.Mapping.Thematics.IndividualValueTheme(lyr, "Status", null);

                    //thm.Name = "Trạng thái cấp GCN";

                    //lyr.Modifiers.Append(thm);

                    //// Change the default fill colors from Red->Gray to White->Blue
                    //MapInfo.Styles.AreaStyle ars;
                    //// Get the style from our first bin
                    //MapInfo.Styles.CompositeStyle cs = thm.Bins[0].Style;
                    //// Get the region -- Area -- style
                    //ars = cs.AreaStyle;
                    //// Change the fill color
                    //ars.Interior = MapInfo.Styles.StockStyles.RedFillStyle();
                    //// Update the CompositeStyle with the new region color
                    //cs.AreaStyle = ars;
                    //// Update the bin with the new CompositeStyle settings
                    //thm.Bins[0].Style = cs;

                    //// Change the style settings on the last bin
                    //int nLastBin = thm.Bins.Count - 1;
                    //cs = thm.Bins[nLastBin].Style;
                    //ars = cs.AreaStyle;
                    //ars.Interior = MapInfo.Styles.StockStyles.HollowFillStyle();
                    //thm.Bins[nLastBin].Style = cs;

                    //// Tell the theme how to fill in the other bins
                    ////thm.SpreadBy = MapInfo.Mapping.Thematics.SpreadByPart.Color;
                    ////thm.ColorSpreadBy = MapInfo.Mapping.Thematics.ColorSpreadMethod.Rgb;
                    //thm.RecomputeBins();// .RecomputeStyles();

                    /////* Test Feature Transparent */
                    ////MapInfo.Styles.SimpleInterior simpleinteriorTransparents = new MapInfo.Styles.SimpleInterior(); ;
                    ////simpleinteriorTransparents.Transparent = true;

                    ////// use linestyle also
                    ////FeatureRenderer fr = mapTest  as FeatureRenderer;
                    ////Feature f =  fr.AreaSample(10.0);
                    ////MapInfo.Styles.CompositeStyle csTransparent = (MapInfo.Styles.CompositeStyle)f.Style;
                    //////cs.AreaStyle.Border = _lineStyle;
                    ////csTransparent.AreaStyle.Interior = simpleinteriorTransparents ;
                    ////fr.Feature = f;
                    /////* EndTest */





                    //// Create a legend
                    //MapInfo.Mapping.Legends.Legend legend = map.Legends.CreateLegend(new Size(6, 6));
                    //legend.Border = true;
                    //MapInfo.Mapping.Legends.ThemeLegendFrame frame = MapInfo.Mapping.Legends.LegendFrameFactory.CreateThemeLegendFrame("Area", "Area", thm);
                    //legend.Frames.Append(frame);
                    //frame.Title = "Trạng thái cấp GCN";
                    //frame.Rows[0].Text = "Cấp GCN";
                    //frame.Rows[1].Text = "Phê duyệt";
                    //frame.Rows[2].Text = "Thẩm định";
                    //frame.Rows[3].Text = "Xét duyệt cấp Phường";
                    //frame.Rows[4].Text = "Kê khai cấp GCN";
                    //frame.Rows[5].Text = "Thông tin gốc";
                    //map.Adornments.Append(legend);
                    //// Set the initial legend location to be the lower right corner of the map control.
                    //System.Drawing.Point pt = new System.Drawing.Point(0, 0);
                    //pt.X = mapTest.Size.Width - legend.Size.Width;
                    //pt.Y = mapTest.Size.Height - legend.Size.Height;
                    //legend.Location = pt;

                    ///* EndTest */
                }
            }
        }

        /// <summary>
        /// Find a LabelSource node in the layer tree which uses the 
        /// specified table, and select that node.  If there are no 
        /// LabelSources that use the specified table, ask the user 
        /// whether a LabelSource should be added to the map. 
        /// </summary>
        /// <param name="sourceTable">
        /// A table which may or may not be labeled currently</param>
        /// <param name="currentLabelSource">
        /// If null is passed, we will select the first LabelSource we find
        /// that uses the specified table; if currentLabelSource is not
        /// null, we will search for the next LabelSource that uses 
        /// the same table. 
        /// </param>
        private void SelectNextLabelSource(
            Table sourceTable, LabelSource currentLabelSource)
        {
            LabelSource matchingLabelSource =
                LocateNextLabelSource(_lc.Map, sourceTable, currentLabelSource, true);

            if (matchingLabelSource != null)
            {
                // There is at least one LabelSource found that uses
                // the specified table.  
                if (_lc.ContextMenuTargetObject == matchingLabelSource)
                {
                    // The user right-clicked on a LabelSource in the tree,
                    // and the only LabelSource that we found is the 
                    // same one the user right-clicked.  So we failed
                    // to find a Next LabelSource. 
                    MapInfo.Windows.MessageBox.Show(
                        "There are no more label sources based on the table:\n\n"
                        + sourceTable.TableInfo.Description);
                }
                else
                {
                    // We found an appropriate match; select its tree node. 
                    _lc.SelectedObject = matchingLabelSource;
                }
            }
            else
            {
                // There are NO LabelSource nodes that use the specified table.
                // The user must have right-clicked a FeatureLayer node 
                // and then clicked Find Labels, but we could not find any.
                // Ask the user if we should create a new LabelSource. 
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult dr = MessageBox.Show(
                    null,
                    "There are no labels for the selected layer: \n\n"
                    + sourceTable.TableInfo.Description + "\n\n"
                    + "Do you want to create a new label source?",
                    "No Labels Found", buttons);

                if (dr == DialogResult.Yes)
                {
                    if (_firstLabelLayer == null)
                    {
                        // There are NO LabelLayers in the map; build one.
                        _firstLabelLayer = new LabelLayer("Label Layer");
                        _lc.Map.Layers.Insert(0, _firstLabelLayer);
                    }
                    LabelSource newSource = new LabelSource(sourceTable);
                    if (sourceTable.TableInfo.TableType == TableType.Wms ||
                        sourceTable.TableInfo.TableType == TableType.Grid ||
                        sourceTable.TableInfo.TableType == TableType.Raster)
                    {
                        // For a Raster Image layer, just label with the layer name.
                        newSource.DefaultLabelProperties.Caption =
                            "'" + sourceTable.TableInfo.Description + "'";
                    }

                    _firstLabelLayer.Sources.Append(newSource);

                    if (!_lc.UpdateWhenCollectionChanges)
                    {
                        // The LayerControl is currently configured to NOT update
                        // automatically when a new node is added to the tree; 
                        // so we will force the LayerTree to regenerate, so that
                        // the new LabelSource node appears. 
                        Map map = _lc.Map;
                        _lc.Map = null;
                        _lc.Map = map;
                    }

                    _lc.SelectedObject = newSource;
                }
            }
        }

        /// <summary>
        /// Find a LabelSource in the map which uses the 
        /// specified table, and return it, or return null 
        /// if no suitable LabelSource exists.  
        /// </summary>
        /// <param name="map">The Map object to search</param>
        /// <param name="sourceTable">
        /// A table which may or may not be labeled currently</param>
        /// <param name="currentLabelSource">
        /// If null is passed, we will return the first LabelSource we find
        /// that uses the specified table; if currentLabelSource is not
        /// null, we will search for the next LabelSource that uses 
        /// the same table. 
        /// </param>
        /// <param name="wrapAround">true if you want a "find next" search
        /// to wrap around to the beginning of the layer tree, if necessary,
        /// to find the next LabelSource; false if you do not the search to wrap.
        /// </param>
        /// <returns>A LabelSource object (which may be identical to
        /// the currentLabelSource param, e.g. if the currentLabelSource 
        /// param represents the only LabelSource in the map); or null if 
        /// the map does not contain any LabelSource based on the specified table. 
        /// </returns>
        private LabelSource LocateNextLabelSource(
            Map map, Table sourceTable, LabelSource currentLabelSource, bool wrapAround)
        {
            // Get a collection of all LabelLayers in the map
            FilterByLayerType labelLayerFilter =
                new FilterByLayerType(LayerType.Label);

            MapLayerEnumerator mapLayerEnum =
                map.Layers.GetMapLayerEnumerator(
                labelLayerFilter, MapLayerEnumeratorOptions.Recurse);

            _firstLabelLayer = null;
            LabelSource matchingLabelSource = null;
            LabelSource firstMatchingLabelSource = null;
            bool bPassedCurrentLabelSource = false;

            // Given the set of all LabelLayers in the layer tree,
            // search each LabelLayer to try to find a LabelSource 
            // child node that is based on the specified table 
            // (the sourceTable param).  
            // OR: If a non-null currentLabelSource param
            // was passed in, then it represents an existing
            // LabelSource, and our job is to find the NEXT 
            // LabelSource that uses the same table. 
            foreach (LabelLayer ll in mapLayerEnum)
            {
                if (_firstLabelLayer == null)
                {
                    // Make a note of the first LabelLayer we find;
                    // later, if we decide to create a new LabelSource, 
                    // it will go into this first LabelLayer. 
                    _firstLabelLayer = ll;
                }

                // Look through this LabelLayer's collection of LabelSources
                foreach (LabelSource lblSource in ll.Sources)
                {
                    if (lblSource.Table == sourceTable)
                    {
                        // This LabelSource uses the correct table
                        if (firstMatchingLabelSource == null)
                        {
                            // We found our first match, so make a note of it,
                            // even though it may not be ideal (i.e. it may not
                            // be the "next" LabelSource that was requested).  
                            firstMatchingLabelSource = lblSource;
                        }

                        // Now determine whether this match is an ideal match.
                        // We may have been passed a LabelSource, and asked
                        // to find the "next" LabelSource.  So we may need 
                        // to skip over the current LabelSource if it's
                        // the same as the LabelSource that was passed in. 
                        if (currentLabelSource != null
                            && !bPassedCurrentLabelSource)
                        {
                            // We WERE asked to find the "next" LabelSource,
                            // which means that our first task is to find 
                            // the LabelSource that the user right-clicked.
                            // But according to the flag, we have not yet
                            // looped past the currently-selected LabelSource. 
                            // So we will continue the loop instead of 
                            // assigning  matchingLabelSource.  
                            if (lblSource == currentLabelSource)
                            {
                                // We were asked to find the next LabelSource,
                                // and this LabelSource is the same one that 
                                // was passed in.  In this case, just set the
                                // flag, so that the next match will be used.  
                                bPassedCurrentLabelSource = true;
                            }
                            continue;
                        }

                        // We found a LabelSource that is a perfect match.
                        matchingLabelSource = lblSource;
                        break;
                    }
                } // This ends the "for each LabelSource in this LabelLayer" loop

                if (matchingLabelSource != null)
                {
                    // We found an ideal match, so we can skip searching 
                    // the other LabelLayers.  Break the outer foreach loop: 
                    break;
                }
            } // This ends the "for each LabelLayer" loop

            if (matchingLabelSource == null)
            {
                // We end up here if we did not find an ideal match; for
                // example, if we were asked to find the "next" node, and 
                // we did not find a next matching node, but we did find a 
                // previous matching node, we end up here.  
                // At this point, since we did not find a perfect match, 
                // we will consider a less-than-perfect match.
                if (wrapAround)
                {
                    // Wrapping is On, meaning that when we search for
                    // the next LabelSource, we should wrap around to the top of
                    // the layer list, if necessary
                    matchingLabelSource = firstMatchingLabelSource;
                }
                else
                {
                    // Wrap is Off, meaning: if we did not find a Next LabelSource,
                    // return the LabelSource that was originally specified, 
                    // which will tell the caller, "there IS no Next LabelSource." 
                    matchingLabelSource = currentLabelSource;
                }
            }
            return matchingLabelSource;
        }

        /// <summary>
        /// Find a FeatureLayer in the layer tree which uses the 
        /// specified table, and select that layer's node.  
        /// If there are no layers that use the specified table, 
        /// ask the user whether a layer should be added to the map. 
        /// </summary>
        /// <param name="sourceTable">
        /// A table which may or may not be displayed in the map</param>
        /// <param name="currentFeatureLayer">
        /// If null is passed, we will return the first FeatureLayer we find
        /// that uses the specified table; if currentFeatureLayer is not
        /// null, we will search for the next FeatureLayer that uses 
        /// the same table. 
        /// </param>
        private void SelectNextFeatureLayer(
            Table sourceTable, FeatureLayer currentFeatureLayer)
        {
            FeatureLayer matchingFeatureLayer =
                LocateNextFeatureLayer(_lc.Map, sourceTable, currentFeatureLayer, true);

            if (matchingFeatureLayer != null)
            {
                // There is at least one FeatureLayer found that uses
                // the specified table.  
                if (_lc.ContextMenuTargetObject == matchingFeatureLayer)
                {
                    // The user right-clicked on a FeatureLayer in the tree,
                    // and the only FeatureLayer that we found is the 
                    // same one the user right-clicked.  So we failed
                    // to find a Next FeatureLayer. 
                    MapInfo.Windows.MessageBox.Show(
                        "There are no more layers based on the table:\n\n"
                        + sourceTable.TableInfo.Description);
                }
                else
                {
                    // We found an appropriate match; select its tree node.
                    _lc.SelectedObject = matchingFeatureLayer;
                }
            }
            else
            {
                // There are NO FeatureLayer nodes that use the specified table.
                // The user must have right-clicked a LabelSource node 
                // and then clicked Find Layer, but we could not find one.
                // Ask the user if we should create a new FeatureLayer.
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(
                    null,
                    "The selected label source displays labels for this table: \n\n"
                    + sourceTable.TableInfo.Description + "\n\n"
                    + "but there are no layers displaying that table. \n\n"
                    + "Do you want to insert a new layer to display that table?",
                    "No Layer Found", buttons);

                if (result == DialogResult.Yes)
                {
                    FeatureLayer newLayer = new FeatureLayer(sourceTable);
                    _lc.Map.Layers.Add(newLayer);

                    if (!_lc.UpdateWhenCollectionChanges)
                    {
                        // The LayerControl is currently configured to NOT update
                        // automatically when a new node is added to the tree; 
                        // so we will force the LayerTree to regenerate, so that
                        // the new layer node appears. 
                        Map map = _lc.Map;
                        _lc.Map = null;
                        _lc.Map = map;
                    }

                    _lc.SelectedObject = newLayer;
                }
            }
        }

        /// <summary>
        /// Find a FeatureLayer in the map which uses the 
        /// specified table, and return it. 
        /// </summary>
        /// <param name="map">The Map object to search</param>
        /// <param name="sourceTable">
        /// A table which may or may not be displayed in a FeatureLayer</param>
        /// <param name="currentFeatureLayer">
        /// If null is passed, we will return the first FeatureLayer we find
        /// that uses the specified table; if currentFeatureLayer is not
        /// null, we will search for the next FeatureLayer that uses 
        /// the same table. 
        /// </param>
        /// <param name="wrapAround">true if you want a "find next" search
        /// to wrap around to the beginning of the layer tree, if necessary,
        /// to find the next layer; false if you do not want the search to wrap.
        /// </param>
        /// <returns>A FeatureLayer object (which may be identical to
        /// the currentFeatureLayer param, e.g. if the currentFeatureLayer 
        /// param represents the only FeatureLayer in the map); or null if 
        /// the map does not contain any FeatureLayer based on the specified table. 
        /// </returns>
        private FeatureLayer LocateNextFeatureLayer(
            Map map, Table sourceTable, FeatureLayer currentFeatureLayer, bool wrapAround)
        {
            FilterByLayerType featureLayerFilter =
                new FilterByLayerType(
                    LayerType.Normal, LayerType.Grid,
                    LayerType.Raster, LayerType.Wms);

            MapLayerEnumerator mapLayerEnum =
                map.Layers.GetMapLayerEnumerator(
                    featureLayerFilter, MapLayerEnumeratorOptions.Recurse);

            FeatureLayer matchingFeatureLayer = null;
            FeatureLayer firstMatchingFeatureLayer = null;
            bool bPassedCurrentFeatureLayer = false;

            foreach (FeatureLayer featLyr in mapLayerEnum)
            {
                if (featLyr.Table == sourceTable)
                {
                    // This FeatureLayer uses the correct table
                    if (firstMatchingFeatureLayer == null)
                    {
                        // We found our first match, so make a note of it,
                        // even though it may not be ideal (i.e. it may not
                        // be the "next" FeatureLayer that was requested). 
                        firstMatchingFeatureLayer = featLyr;
                    }

                    // Now determine whether this match is an ideal match.
                    // We may have been passed a FeatureLayer, and asked
                    // to find the "next" FeatureLayer.  So we may need 
                    // to skip over the current FeatureLayer if it's
                    // the same as the FeatureLayer that was passed in. 
                    if (currentFeatureLayer != null
                        && !bPassedCurrentFeatureLayer)
                    {
                        // We WERE asked to find the "next" FeatureLayer,
                        // which means that our first task is to find 
                        // the FeatureLayer that the user right-clicked.
                        // But according to the flag, we have not yet
                        // looped past the currently-selected FeatureLayer. 
                        // So we will continue the loop instead of 
                        // assigning  matchingFeatureLayer. 
                        if (featLyr == currentFeatureLayer)
                        {
                            bPassedCurrentFeatureLayer = true;
                        }
                        continue;
                    }

                    matchingFeatureLayer = featLyr;
                    break;
                }
            }

            if (matchingFeatureLayer == null)
            {
                // We did not find an ideal match (i.e. we may have been
                // asked to find the Next FeatureLayer, and there may not
                // have been a Next FeatureLayer).  
                // At this point, since we did not find a perfect match, 
                // we will consider a less-than-perfect match.
                if (wrapAround)
                {
                    // wrapAround is true, meaning that when we search for
                    // the next layer, we should wrap around to the top of
                    // the layer list, if necessary
                    matchingFeatureLayer = firstMatchingFeatureLayer;
                }
                else
                {
                    // wrapAround is false, meaning that when we cannot find
                    // a next layer, we should return the layer that was 
                    // originally specified, which will tell the caller, 
                    // "there is no Next layer." 
                    matchingFeatureLayer = currentFeatureLayer;
                }
            }
            return matchingFeatureLayer;
        }

    }
}
