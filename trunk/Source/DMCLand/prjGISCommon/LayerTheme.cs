using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    /// <summary>
    /// Lớp này thực hiện các chức năng về Layer Theme như:
    /// Bật tắt trạng thái (màu) cấp GCN thửa đất
    /// </summary>
    public  class LayerTheme
    {
        #region Trạng thái cấp GCN
        public void  TrangThaiCapGCN( MapInfo.Mapping.Map map, string strLayerName, string  strExpression, string strThemeName  )
        {
                    /* Test: Trạng thái cấp GCN */
                    // Create a ranged theme on the USA layer.
                    MapInfo.Mapping.FeatureLayer lyr = map.Layers[strLayerName ] as MapInfo.Mapping.FeatureLayer;
                    MapInfo.Mapping.Thematics.IndividualValueTheme thm = new MapInfo.Mapping.Thematics.IndividualValueTheme(lyr, strExpression , null);
                    thm.Name = strThemeName;// "Trạng thái cấp GCN";
                    lyr.Modifiers.Append(thm);
                    // Change the default fill colors from Red->Gray to White->Blue
                    MapInfo.Styles.AreaStyle ars;
                    // Get the style from our first bin
                    MapInfo.Styles.CompositeStyle cs = thm.Bins[0].Style;
                    // Get the region -- Area -- style
                    ars = cs.AreaStyle;
                    // Change the fill color
                    ars.Interior = MapInfo.Styles.StockStyles.RedFillStyle();
                    // Update the CompositeStyle with the new region color
                    cs.AreaStyle = ars;
                    // Update the bin with the new CompositeStyle settings
                    thm.Bins[0].Style = cs;
                    // Change the style settings on the last bin
                    int nLastBin = thm.Bins.Count - 1;
                    cs = thm.Bins[nLastBin].Style;
                    ars = cs.AreaStyle;
                    ars.Interior = MapInfo.Styles.StockStyles.HollowFillStyle();
                    thm.Bins[nLastBin].Style = cs;

                    // Tell the theme how to fill in the other bins
                    //thm.SpreadBy = MapInfo.Mapping.Thematics.SpreadByPart.Color;
                    //thm.ColorSpreadBy = MapInfo.Mapping.Thematics.ColorSpreadMethod.Rgb;
                    thm.RecomputeBins();// .RecomputeStyles();

                    ///* Test Feature Transparent */
                    //MapInfo.Styles.SimpleInterior simpleinteriorTransparents = new MapInfo.Styles.SimpleInterior(); ;
                    //simpleinteriorTransparents.Transparent = true;

                    //// use linestyle also
                    //FeatureRenderer fr = mapTest  as FeatureRenderer;
                    //Feature f =  fr.AreaSample(10.0);
                    //MapInfo.Styles.CompositeStyle csTransparent = (MapInfo.Styles.CompositeStyle)f.Style;
                    ////cs.AreaStyle.Border = _lineStyle;
                    //csTransparent.AreaStyle.Interior = simpleinteriorTransparents ;
                    //fr.Feature = f;
                    ///* EndTest */
                    // Create a legend
                    MapInfo.Mapping.Legends.Legend legend = map.Legends.CreateLegend(new System.Drawing.Size(6, 6));
                    legend.Border = true;
            
                    MapInfo.Mapping.Legends.ThemeLegendFrame frame = MapInfo.Mapping.Legends.LegendFrameFactory.CreateThemeLegendFrame("Area", "Area", thm);
                    legend.Frames.Append(frame);
                    frame.Title = "Trạng thái cấp GCN";
                    frame.Rows[0].Text = "Cấp GCN";
                    frame.Rows[1].Text = "Phê duyệt";
                    frame.Rows[2].Text = "Thẩm định";
                    frame.Rows[3].Text = "Xét duyệt cấp Phường";
                    frame.Rows[4].Text = "Kê khai cấp GCN";
                    frame.Rows[5].Text = "Thông tin gốc";
                    map.Adornments.Append(legend);
                    // Set the initial legend location to be the lower right corner of the map control.
                    System.Drawing.Point pt = new System.Drawing.Point(0, 0);
                    pt.X = map.Size.Width - legend.Size.Width;
                    pt.Y = map.Size.Height - legend.Size.Height;
                    legend.Location = pt;
                    /* EndTest */
        }
        #endregion

        #region Hiển thị màu trạng thái cấp GCN. Để thực thi chức năng này ở đây có hai phương thức nạp chồng hàm.
        ///// <summary>
        ///// Hiện thị trạng thái (màu) cấp GCN thửa đất. Gồm 
        ///// các trường hợp:
        ///// 1. Hồ sơ gốc
        ///// 2. Kê khai
        ///// 3. Xét duỵệt cấp Phường
        ///// 4. Thẩm định
        ///// 5. Phê duyệt
        ///// 6. Cấp GCN
        ///// 7. Không cấp GCN
        ///// </summary>
        ///// <param name="mapControl"> Điều khiển bản đồ tham chiếu</param>
        ///// <param name="intLayerIndex"> Chỉ số của lớp cần tạo Theme (Bật trạng thái màu) tương ứng
        ///// với các giá trị của trường: strTenTruong</param>
        ///// <param name="strFieldName"> Tên trường dữ liệu của Layer mà các giá trị
        ///// của trường đó dùng để tạo Theme </param>
        //public void TrangThaiCapGCN(ref MapInfo.Mapping.Map map, int intLayerIndex , string strFieldName )
        //{
        //    try
        //    {
        //        /* Kiểm tra tính hợp lệ của giá trị intChiSoLop */
        //        /* Chỉ thực hiện khi Chỉ số lớp nhỏ hơn số lớp của Map */
        //        if ((intLayerIndex < map.Layers.Count) && (intLayerIndex >= 0))
        //        {
        //            MapInfo.Mapping.FeatureLayer fLyr = map.Layers[intLayerIndex] as MapInfo.Mapping.FeatureLayer;
        //            if (fLyr != null)
        //            {
        //                // Create an individual value theme
        //                MapInfo.Mapping.Thematics.IndividualValueTheme thm = new MapInfo.Mapping.Thematics.IndividualValueTheme(fLyr, strFieldName, null);
        //                // Add the theme to the FeatureStyleModifiers list
        //                fLyr.Modifiers.Append(thm);
        //            }
        //            else
        //            {
        //                System.Windows.Forms.MessageBox.Show(
        //                    "Lớp thứ: " + intLayerIndex.ToString() + " KHÔNG tìm thấy; Đổ màu trạng thái KHÔNG được thực hiện!");
        //                return;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Lỗi: " + ex.Message,"DMCLand");
        //    }
        //}

        ///// <summary>
        ///// Hiện thị trạng thái (màu) cấp GCN thửa đất. Gồm 
        ///// các trường hợp:
        ///// 1. Hồ sơ gốc
        ///// 2. Kê khai
        ///// 3. Xét duỵệt cấp Phường
        ///// 4. Thẩm định
        ///// 5. Phê duyệt
        ///// 6. Cấp GCN
        ///// 7. Không cấp GCN
        ///// </summary>
        ///// <param name="mapControl"> Điều khiển bản đồ tham chiếu</param>
        ///// <param name="strLayerName"> Tên của lớp cần tạo Theme (Bật trạng thái màu) tương ứng
        ///// với các giá trị của trường: strFieldName</param>
        ///// <param name="strFieldName"> Tên trường dữ liệu của Layer mà các giá trị
        ///// của trường đó dùng để tạo Theme </param>
        //public void TrangThaiCapGCN(ref MapInfo.Mapping.Map  map, string strLayerName, string strFieldName)
        //{
        //    try
        //    {
        //        MapInfo.Mapping.FeatureLayer fLyr = map.Layers[strLayerName] as MapInfo.Mapping.FeatureLayer;
        //        if (fLyr != null)
        //        {
        //            // Create an individual value theme
        //            MapInfo.Mapping.Thematics.IndividualValueTheme thm = new MapInfo.Mapping.Thematics.IndividualValueTheme(fLyr, strFieldName, null);
        //            // Add the theme to the FeatureStyleModifiers list
        //            fLyr.Modifiers.Append(thm);
        //        }
        //        else
        //        {
        //            System.Windows.Forms.MessageBox.Show(
        //                "Lớp : " + strLayerName  + " KHÔNG tìm thấy; Đổ màu trạng thái KHÔNG được thực hiện!");
        //            return;
        //        }
        //    }
        //    catch ( Exception ex )
        //    {
        //        System.Windows.Forms.MessageBox.Show("Lỗi: " +  ex.Message,"DMCLand");
        //    }
        //}
        //#endregion
        //#region
        ///// <summary>
        ///// Xóa màu trạng thái thửa đất
        ///// </summary>
        ///// <param name="mapControl"> Điều khiển bản đồ tham chiếu cần thực hiện </param>
        ///// <param name="strLayerName"> Tên lớp cần thực hiên xóa trạng thái màu (Theme) </param>
        //public void XoaTrangThaiCapGCN(ref MapInfo.Windows.Controls.MapControl mapControl, string  strLayerName )
        //{
        //    try
        //    {
        //        /* Tham chiếu tới lớp cần thực hiện */
        //        MapInfo.Mapping.FeatureLayer lyr = (MapInfo.Mapping.FeatureLayer)mapControl.Map.Layers[strLayerName];
        //        /* Kiểm tra tính hợp lệ */
        //        if (lyr == null)
        //        {
        //            System.Windows.Forms.MessageBox.Show(
        //                "Lớp: " + strLayerName + " không tìm thấy; Xóa màu trạng thái thửa đất không được thực hiện!");
        //            return;
        //        }
        //        else
        //        {
        //            // Reference the layer's collection of themes and other modifiers
        //            MapInfo.Mapping.FeatureStyleModifiers modifiers = lyr.Modifiers;

        //            // remove any IndividualValueTheme objects
        //            System.Collections.ArrayList aliases = new System.Collections.ArrayList();
        //            foreach (MapInfo.Mapping.FeatureStyleModifier mod in modifiers)
        //            {
        //                MapInfo.Mapping.Thematics.IndividualValueTheme ivTheme = mod as MapInfo.Mapping.Thematics.IndividualValueTheme;
        //                if (ivTheme != null)
        //                {
        //                    // We found a modifier that is an IndividualValueTheme. 
        //                    // Remember its name so we can remove it after this loop.
        //                    aliases.Add(ivTheme.Alias);
        //                }
        //            }
        //            foreach (string s in aliases)
        //            {
        //                modifiers.Remove(s);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Lỗi: " + ex.Message, "DMCLand");
        //    }
        //}
        ///// <summary>
        ///// Xóa màu trạng thái thửa đất
        ///// </summary>
        ///// <param name="mapControl"> Điều khiển bản đồ tham chiếu cần thực hiện </param>
        ///// <param name="intLayerIndex"> Chỉ số lớp cần thực hiên xóa trạng thái màu (Theme) </param>
        //public void XoaTrangThaiCapGCN(ref MapInfo.Windows.Controls.MapControl mapControl, int  intLayerIndex)
        //{
        //    try
        //    {
        //        /* Kiểm tra tính hợp lệ của dữ liệu */
        //        if ( ( intLayerIndex >= mapControl.Map.Layers.Count  ) && (intLayerIndex < 0) )
        //        {
        //            System.Windows.Forms.MessageBox.Show(
        //                "Lớp thứ: " + intLayerIndex + " không tìm thấy; Xóa màu trạng thái thửa đất không được thực hiện!");
        //            return;
        //        }
        //        /* Tham chiếu tới lớp cần thực hiện */
        //        MapInfo.Mapping.FeatureLayer lyr = (MapInfo.Mapping.FeatureLayer)mapControl.Map.Layers[intLayerIndex];
        //        /* Kiểm tra tính hợp lệ */
        //        if (lyr == null)
        //        {
        //            System.Windows.Forms.MessageBox.Show(
        //                "Lớp thứ: " + intLayerIndex + " không tìm thấy; Xóa màu trạng thái thửa đất không được thực hiện!");
        //            return;
        //        }
        //        else
        //        {
        //            // Reference the layer's collection of themes and other modifiers
        //            MapInfo.Mapping.FeatureStyleModifiers modifiers = lyr.Modifiers;

        //            // remove any IndividualValueTheme objects
        //            System.Collections.ArrayList aliases = new System.Collections.ArrayList();
        //            foreach (MapInfo.Mapping.FeatureStyleModifier mod in modifiers)
        //            {
        //                MapInfo.Mapping.Thematics.IndividualValueTheme ivTheme = mod as MapInfo.Mapping.Thematics.IndividualValueTheme;
        //                if (ivTheme != null)
        //                {
        //                    // We found a modifier that is an IndividualValueTheme. 
        //                    // Remember its name so we can remove it after this loop.
        //                    aliases.Add(ivTheme.Alias);
        //                }
        //            }
        //            foreach (string s in aliases)
        //            {
        //                modifiers.Remove(s);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Lỗi: " + ex.Message, "DMCLand");
        //    }
        //}
        #endregion

        //#region Test. Trạng thái hồ sơ cấp GCN thửa đất
        //// Add an IndividualValueTheme to the specified layer.
        //public void DoAddTheme(ref MapInfo.Windows.Controls.MapControl mapControl, string strLayerToTheme, string expression, string strLayerName)
        //{
        //    // First obtain a reference to the layer that will own the theme
        //    FeatureLayer lyr = (FeatureLayer)mapControl.Map.Layers[strLayerToTheme];
        //    if (lyr == null)
        //    {
        //        MessageBox.Show("Layer " + strLayerToTheme + " not found; theme cannot be added.");
        //        return;
        //    }

        //    MapInfo.Mapping.Thematics.IndividualValueTheme ivTheme = null;
        //    try
        //    {
        //        // Create the theme.  Pass null for the theme's alias. 
        //        ivTheme = new MapInfo.Mapping.Thematics.IndividualValueTheme(lyr, expression, null);
        //    }
        //    catch (System.NullReferenceException)
        //    {
        //        // This exception can occur if you specify an expression 
        //        // that is not valid for this layer.
        //        MessageBox.Show("Unable to create theme; check expression syntax. "
        //            + "Layer: " + strLayerToTheme + ", Expression: " + expression,
        //            "Error");
        //        return;
        //    }

        //    // Set the theme's ApplyStylePart property to control which display
        //    // attributes are overridden by the theme. If you specify StylePart.All: 
        //    //     ivTheme.ApplyStylePart = StylePart.All; 
        //    // the theme will control each country's fill pattern and color. 
        //    // If you specify StylePart.Color, the theme will control each country's
        //    // color, but will not alter each region's fill pattern.  
        //    // If you have specified a fill pattern using a display style override,
        //    // and you do not want the individual value theme to interfere with that
        //    // fill pattern, set ApplyStylePart to StylePart.Color.  
        //    ivTheme.ApplyStylePart = MapInfo.Mapping.Thematics.StylePart.Color;

        //    // Now add the theme to the layer's collection of style modifiers.
        //    // Insert it at the top of the list of modifiers, so that it will
        //    // definitely be visible.  (If the layer has other modifiers, 
        //    // such as style overrides, and you append the theme to the 
        //    // bottom of the list, the style overrides might override the theme.)
        //    lyr.Modifiers.Insert(0, ivTheme);
        //    MessageBox.Show("Added new IndividualValueTheme to layer " + strLayerName
        //        + " using expression: " + expression, "Theme Added");

        //    /* Test */
        //    mapControl.Update();
        //    /* */
        //}

        //// Examine the layer's IndividualValueTheme, if there is one,
        //// and display information about some of the theme's properties.
        //public void DoThemeInfo(ref  MapInfo.Windows.Controls.MapControl mapControl, string strLayerName)
        //{
        //    // First obtain a reference to the layer
        //    FeatureLayer lyr = (FeatureLayer)mapControl.Map.Layers[strLayerName];
        //    if (lyr == null)
        //    {
        //        MessageBox.Show(
        //            "Layer " + strLayerName + " not found; no theme information to display.");
        //        return;
        //    }

        //    // Reference the layer's collection of themes and other modifiers
        //    FeatureStyleModifiers modifiers = lyr.Modifiers;

        //    // See if the collection contains any IndividualValueTheme objects
        //    MapInfo.Mapping.Thematics.IndividualValueTheme ivTheme = null;
        //    int counter = 0;
        //    foreach (FeatureStyleModifier mod in modifiers)
        //    {
        //        if (mod is MapInfo.Mapping.Thematics.IndividualValueTheme)
        //        {
        //            // We did find an IndividualValueTheme in the collection
        //            counter++;
        //            if (ivTheme == null)
        //            {
        //                // Keep a reference to the top-most theme we find
        //                ivTheme = mod as MapInfo.Mapping.Thematics.IndividualValueTheme;
        //            }
        //        }
        //    }
        //    if (counter > 1)
        //    {
        //        MessageBox.Show("Found " + counter + " IndividualValueThemes on layer "
        //            + strLayerName + "; displaying information for topmost theme.");
        //    }
        //    if (ivTheme != null)
        //    {
        //        string str = "Individual Value Theme properties: ";
        //        str += "Theme name: '" + ivTheme.Name + "'. ";
        //        str += "Theme expression: '" + ivTheme.Expression + "'. ";
        //        str += "Theme has " + ivTheme.Bins.Count + " bins. ";
        //        if (ivTheme.Visible)
        //        {
        //            str += " Theme is visible at the current zoom level. ";
        //        }
        //        else
        //        {
        //            str += " Theme is not currently visible. ";
        //        }
        //        MessageBox.Show(str);
        //    }
        //    else
        //    {
        //        MessageBox.Show("No IndividualValueTheme objects found for layer " + strLayerName);
        //    }
        //}

        //// Remove all IndividualValueThemes from the World layer
        //public void DoClearThemes(ref MapInfo.Windows.Controls.MapControl mapControl, string strLayerName)
        //{
        //    // First obtain a reference to the layer
        //    FeatureLayer lyr = (FeatureLayer)mapControl.Map.Layers[strLayerName];
        //    if (lyr == null)
        //    {
        //        MessageBox.Show(
        //            "Layer " + strLayerName + " not found; no themes to remove.");
        //        return;
        //    }

        //    // Reference the layer's collection of themes and other modifiers
        //    FeatureStyleModifiers modifiers = lyr.Modifiers;

        //    // remove any IndividualValueTheme objects
        //    System.Collections.ArrayList aliases = new System.Collections.ArrayList();
        //    foreach (FeatureStyleModifier mod in modifiers)
        //    {
        //        MapInfo.Mapping.Thematics.IndividualValueTheme ivTheme = mod as MapInfo.Mapping.Thematics.IndividualValueTheme;
        //        if (ivTheme != null)
        //        {
        //            // We found a modifier that is an IndividualValueTheme. 
        //            // Remember its name so we can remove it after this loop.
        //            aliases.Add(ivTheme.Alias);
        //        }
        //    }
        //    foreach (string s in aliases)
        //    {
        //        modifiers.Remove(s);
        //    }
        //    MessageBox.Show("Removed " + aliases.Count
        //        + " IndividualValueTheme(s) from layer: " + strLayerName);
        //}
        //#endregion
    }
}
