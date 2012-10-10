using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using MapInfo.Data;
using MapInfo.Mapping;
using MapInfo.Windows.Controls;
using MapInfo.Geometry;
using MapInfo.Styles;
using MapInfo.Engine;
using MapInfo.DBMSWrapper;

namespace DMC.GIS.Common
{
    interface IDLayers
    {
        //void LayerShowNodes(ref FeatureLayer lyr, bool blShowNode);
        //void LayerShowCentroids(ref FeatureLayer lyr, bool blShowCentroid);
        //void LayerShowLineDirection(ref FeatureLayer lyr, bool blShowLineDirection);
        //void LayerEnable(ref FeatureLayer lyr, bool blEnable);
        //void ShowSearchGeometry(FeatureGeometry g, bool clear);
        //void ShowSearchGeometry(FeatureGeometry g);
    }

    public class DLayers : IDLayers 
    {
        public   Table tempTable = null  ;
        public   Selection selection = Session.Current.Selections.DefaultSelection;
        public   Catalog catalog = Session.Current.Catalog;


        //#region Bật tắt lớp, chồng xếp lớp
        ///// <summary>
        ///// Bật tắt lớp bản đồ
        ///// </summary>
        ///// <param name="lstvw"> ListView điều khiển lớp bản đồ</param>
        ///// <param name="blDanhSachLop"> Danh sách trạng thái các lớp bản đồ </param>
        ///// <returns> Trả về giá trị là mục vừa được bật (tắt) lớp </returns>
        //public int TrangThaiLopBanDo(ref System.Windows.Forms.ListView lstvw, ref bool[] blDanhSachLop)
        //{
        //    // Khai báo chỉ số lớp lựa chọn
        //    int intChiSoLuaChon ;
        //    intChiSoLuaChon = blDanhSachLop.Length + 1;

        //    System.Windows.Forms.ListViewItem lvi = new ListViewItem();
        //    lvi =  lstvw.FocusedItem;
        //    /* Chỉ thực hiện khi có lớp được lựa chọn */
        //    if (lvi != null)
        //    {
        //        if (lvi.Index >= 0)
        //        {
        //            /* Xác nhận chỉ số của Item đang được lựa chọn */
        //            intChiSoLuaChon = lvi.Index;
        //            /* Nếu mục đó đang check chọn thì bỏ check */
        //            if (lstvw.Items[intChiSoLuaChon].Checked)
        //            {
        //                lstvw.Items[intChiSoLuaChon].Checked = false;
        //                blDanhSachLop[intChiSoLuaChon] = false;
        //            }
        //            /* Nếu mục đó không được check thì check cho mục đó */
        //            else
        //            {
        //                lstvw.Items[intChiSoLuaChon].Checked = true;
        //                blDanhSachLop[intChiSoLuaChon] = true;
        //            }
        //        }
        //    }
        //    /* Trả về chỉ số lựa chọn */
        //    return intChiSoLuaChon;
        //}

        ///// <summary>
        ///// Hiển thị các lớp bản đồ lên ListView
        ///// </summary>
        ///// <param name="lstvw"></param>
        ///// <param name="strDanhSachLop"></param>
        ///// <param name="blDanhSachLop"></param>
        //public void HienThiLopBanDoTrenListView(ref System.Windows.Forms.ListView lstvw, ref string[] strDanhSachLop, ref bool[] blDanhSachLop)
        //{
        //    /* Làm sạch ListView */
        //    lstvw.Clear();
        //    /* Cho phép ListView hiển thị Check box */
        //    lstvw.CheckBoxes = true;
        //    /* Không cho phép lựa chọn nhiều lớp cùng lúc */
        //    lstvw.MultiSelect = false;
        //    /* Chọn cả dòng */
        //    /* CHƯA ĐƯỢC */
        //    lstvw.FullRowSelect = false;
        //    /* Add các lớp bản đồ và trạng thái lớp bản đồ tương ứng lên ListView  */
        //    for (int i = 0; i < strDanhSachLop.Length; i++)
        //    {
        //        lstvw.Items.Add(strDanhSachLop[i]);
        //        lstvw.Items[i].Checked = blDanhSachLop[i];
        //    }
        //}


        ///// <summary>
        ///// Đưa lớp bản đồ lựa chọn lên trên và đưa lớp bản đồ ngay phía trên xuống vị trí lựa chọn
        ///// </summary>
        ///// <param name="lstvw"></param>
        ///// <param name="strDanhSachLop"></param>
        ///// <param name="blDanhSachLop"></param>
        //public int  ChongXepLopBanDo(ref System.Windows.Forms.ListView lstvw, ref string[] strDanhSachLop, ref bool[] blDanhSachLop)
        //{
        //    // Khai báo chỉ số lớp lựa chọn
        //    int intChiSoLuaChon;
        //    intChiSoLuaChon  = strDanhSachLop.Length + 1;
        //    System.Windows.Forms.ListViewItem lvi = new ListViewItem();
        //    lvi =  lstvw.FocusedItem;
        //    if (lvi != null)
        //    {
        //        if (lvi.Index  >= 0)
        //        {
        //            intChiSoLuaChon = lvi.Index;
        //            // Khai báo các biến nhận tên lớp và trạng thái lớp đứng trên lớp lựa chọn
        //            string strTenLopTruoc;
        //            bool blTrangThaiLopTruoc;
        //            strTenLopTruoc = strDanhSachLop[intChiSoLuaChon - 1];
        //            blTrangThaiLopTruoc = blDanhSachLop[intChiSoLuaChon - 1];
        //            // Đảo tên lớp và trạng thái lớp lựa chọn lên trên. Tên và trạng thái lớp trước lớp lựa chọn xuống dưới
        //            strDanhSachLop[intChiSoLuaChon - 1] = strDanhSachLop[intChiSoLuaChon];
        //            blDanhSachLop[intChiSoLuaChon - 1] = blDanhSachLop[intChiSoLuaChon];
        //            strDanhSachLop[intChiSoLuaChon] = strTenLopTruoc;
        //            blDanhSachLop[intChiSoLuaChon] = blTrangThaiLopTruoc;
        //            /* Cập nhật thay đổi vào danh sách thứ tự lớp bản đồ */
        //            lstvw.Clear();
        //            lstvw.CheckBoxes = true;
        //            for (int i = 0; i < strDanhSachLop.Length; i++)
        //            {
        //                lstvw.Items.Add(strDanhSachLop[i]).Checked = blDanhSachLop[i];
        //            }
        //        }
        //    }
        //    return intChiSoLuaChon;
        //}

        ///// <summary>
        ///// Đưa lớp bản đồ lựa chọn xuống dưới và đưa lớp bản đồ ngay phía dưới lên vị trí lựa chọn
        ///// </summary>
        ///// <param name="lstvw"></param>
        ///// <param name="strDanhSachLop"></param>
        ///// <param name="blDanhSachLop"></param>
        ///// <param name="blXuongDuoi"></param>
        //public int  ChongXepLopBanDo(ref System.Windows.Forms.ListView lstvw, ref string[] strDanhSachLop, ref bool[] blDanhSachLop, bool blXuongDuoi)
        //{
        //    // Khai báo chỉ số lớp lựa chọn
        //    int intChiSoLuaChon;
        //    intChiSoLuaChon = blDanhSachLop.Length + 1;
        //    if (blXuongDuoi)
        //    {
        //        System.Windows.Forms.ListViewItem lvi = new ListViewItem();
        //        lvi =  lstvw.FocusedItem;
        //        if (lvi != null)
        //        {
        //            /* Chỉ thực hiện khi có lớp được lựa chọn và lớp chọn không phải vị trí cuối cùng */
        //            if ( ( (strDanhSachLop.Length - 1) > lvi.Index) && ( lvi.Index  >= 0))
        //            {
        //                intChiSoLuaChon = lvi.Index;
        //                // Khai báo các biến nhận tên lớp và trạng thái lớp đứng dưới lớp lựa chọn
        //                string strTenLopSau;
        //                bool blTrangThaiLopSau;
        //                strTenLopSau = strDanhSachLop[intChiSoLuaChon + 1];
        //                blTrangThaiLopSau = blDanhSachLop[intChiSoLuaChon + 1];
        //                //Đảo tên lớp và trạng thái lựa chọn xuống dưới. Tên lớp và trạng thái lớp sau lớp lựa chọn lên trên
        //                strDanhSachLop[intChiSoLuaChon + 1] = strDanhSachLop[intChiSoLuaChon];
        //                blDanhSachLop[intChiSoLuaChon + 1] = blDanhSachLop[intChiSoLuaChon];
        //                strDanhSachLop[intChiSoLuaChon] = strTenLopSau;
        //                blDanhSachLop[intChiSoLuaChon] = blTrangThaiLopSau;
        //                /* Cập nhật thay đổi vào danh sách thứ tự lớp bản đồ */
        //                lstvw.Clear();
        //                lstvw.CheckBoxes = true;
        //                for (int i = 0; i < strDanhSachLop.Length; i++)
        //                {
        //                    lstvw.Items.Add(strDanhSachLop[i]).Checked = blDanhSachLop[i];
        //                }
        //            }
        //        }
        //    }
        //    return intChiSoLuaChon;
        //}

        ///// <summary>
        ///// Tìm đối tượng theo giá trị cho một trường dữ liệu trong bảng
        ///// </summary>
        ///// <param name="tableName"> Tên bảng cần truy vấn</param>
        ///// <param name="columnName"> Tên trường cần truy vấn </param>
        ///// <param name="strKey"> Giá trị cần tìm cho trường dữ liệu </param>
        // public static void SearchWithSql(ref MapControl mapControl, string tableName, string columnName, string strKey)  
        // {
        //     MapInfo.Data.MIConnection miConnection = new MIConnection();
        //     miConnection.Open();
        //     MapInfo.Data.MICommand miCommand = miConnection.CreateCommand();
        //     miCommand.CommandText = "select * from " + tableName + " where " + columnName + " like '%'+@name+'%'";
        //     miCommand.Parameters.Add("@name", strKey);
        //     IResultSetFeatureCollection ifs = miCommand.ExecuteFeatureCollection();
        //     MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
        //     MapInfo.Mapping.Map myMap = MapInfo.Engine.Session.Current.MapFactory[mapControl.Map.Alias];
        //     if (ifs.Count <= 0)
        //     {
        //         MessageBox.Show ("Cannot find the point");
        //     }
        //     else
        //     {
        //         //
        //         MessageBox.Show ("");
        //         MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(ifs);
        //         if (ifs.Count == 1)
        //         {
        //             myMap.Center = new DPoint(ifs[0].Geometry.Centroid.x, ifs[0].Geometry.Centroid.y);
        //             MapInfo.Geometry.Distance d = new MapInfo.Geometry.Distance(0.5, myMap.Zoom.Unit);
        //             myMap.Zoom = d;
        //         }
        //         else
        //         {
        //             myMap.SetView(ifs.Envelope);
        //         }
        //     }  
        // }  

        // /// <summary>
        ///// Tìm đối tượng với giá trị cần tìm trong một trường dữ liệu của một lớp
        // /// </summary>
        // /// <param name="layerName"></param>
        // /// <param name="columnName"></param>
        // /// <param name="strKey"></param>
        // public static void SearchWithFind(ref MapControl mapControl, string layerName, string columnName, string strKey)  
        //   {
        //       //MapInfo.Data.Find.Find find = null;
        //       //MapInfo.Mapping.Map map = MapInfo.Engine.Session.Current.MapFactory[mapControl.Map.Alias];

        //       //// Do the find  
        //       //MapInfo.Mapping.FeatureLayer findLayer = (MapInfo.Mapping.FeatureLayer)map.Layers[layerName];
        //       //find = new MapInfo.Data.Find.Find(findLayer.Table, findLayer.Table.TableInfo.Columns[columnName]);
        //       //MapInfo.Data.Find.FindResult findResult = find.Search(strFind);
        //       //if (findResult.ExactMatch)
        //       //{
        //       //    // Set the map's center and zoom  
        //       //    map.Center = new DPoint(findResult.FoundPoint.X, findResult.FoundPoint.Y);
        //       //    MapInfo.Geometry.Distance d = new MapInfo.Geometry.Distance(2, map.Zoom.Unit);
        //       //    map.Zoom = d;
        //       //    MessageBox.Show("");
        //       //}
        //       //else
        //       //{
        //       //    MessageBox.Show("Cannot find the Point");
        //       //}
        //       //find.Dispose();  
        //  }  

        ///// <summary>
        // /// Tìm đối tượng với giá trị cần tìm cho một trường dữ liệu của một bảng
        ///// </summary>
        ///// <param name="tableName"> Tên bảng cần tìm </param>
        ///// <param name="columnName"> Tên cột cần tìm</param>
        ///// <param name="strKey"> Giá trị cần tìm</param>
        //public static void SearchWithSearch(ref MapControl mapControl, string tableName, string columnName, string strKey)  
        //{  
        //     MapInfo.Mapping.Map map = MapInfo.Engine.Session.Current.MapFactory[mapControl.Map.Alias];  
       
        //     SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchWhere(columnName + " like '%" + strKey + "%'");  
        //     IResultSetFeatureCollection ifs = MapInfo.Engine.Session.Current.Catalog.Search(tableName, si);  
        //     MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();  
        //     if (ifs.Count <= 0)  
        //     {  
        //         MessageBox.Show ( "Cannot find the point");  
        //     }  
        //     else  
        //     {  
        //         //
        //         MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(ifs);  
        //         MessageBox.Show ("");  
        //         if (ifs.Count == 1)  
        //         {  
        //             map.Center = new DPoint(ifs[0].Geometry.Centroid.x, ifs[0].Geometry.Centroid.y);  
        //             MapInfo.Geometry.Distance d = new MapInfo.Geometry.Distance(0.5, map.Zoom.Unit);  
        //         }  
        //         else  
        //         {  
        //             map.SetView(ifs.Envelope);  
        //         }  
        //         ////
        //         //ListBox1.Items.Clear();  
        //         //foreach (Feature feature in ifs)  
        //         //{  
        //         //    ListBox1.Items.Add(feature["name"].ToString());  
        //         //}  
        //     }  
        // }  
   
        ///// <summary>
        ///// select features in feature collection
        ///// </summary>
        ///// <param name="fc"></param>
        //public void SelectFeatureCollection(ref MapControl mapControl, IResultSetFeatureCollection fc)
        //{
        //    // force map to update
        //    mapControl.Update();

        //    selection.Clear();
        //    selection.Add(fc);
        //}
        ///// <summary>
        ///// find cities nearest to center within 1 pixel radius
        ///// </summary>
        //public void MapSearchNearest(ref MapControl mapControl, System.Drawing.Point mapPoint )
        //{
        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        System.Drawing.Rectangle rect = mapControl.Bounds;
        //        System.Drawing.Point pt = new System.Drawing.Point(rect.Left, rect.Top);
        //        pt.X += rect.Width / 2;
        //        pt.Y += rect.Height / 2;


        //        SearchInfo si = MapInfo.Mapping.SearchInfoFactory.SearchNearest(mapControl.Map , mapPoint , 1);
        //        IResultSetFeatureCollection fc = catalog.Search("Dat", si);


        //        rect.X = pt.X;
        //        rect.Y = pt.Y;
        //        rect.Width = 0;
        //        rect.Height = 0;
        //        rect.Inflate(3, 3);
        //        // show search geometry on screen for visual confirmation
        //        MapInfo.Geometry.MultiPolygon p = MapInfo.Mapping.SearchInfoFactory.CreateScreenRect(mapControl.Map , rect);
        //        ShowSearchGeometry(p);

        //        SelectFeatureCollection(ref mapControl, fc);
        //    }
        //    finally
        //    {
        //        Cursor.Current = Cursors.Default;
        //    }
        //}
        ///// <summary>
        ///// Hiển thị Geometry tìm được
        ///// </summary>
        ///// <param name="g"></param>
        //public void ShowSearchGeometry(FeatureGeometry g)
        //{
        //    ShowSearchGeometry(g, true);
        //}
        //        /// <summary>
        ///// Hiển thị các node của các Feature trên Layer 
        ///// </summary>
        ///// <param name="lyr"></param>
        ///// <param name="blShowNode"></param>
        //public void LayerShowNodes(ref FeatureLayer lyr, bool blShowNode)
        //{
        //    lyr.ShowNodes = blShowNode;

        //}
        ///// <summary>
        ///// Hiển thị tâm của Feature trên Layer
        ///// </summary>
        ///// <param name="lyr"></param>
        ///// <param name="blShowCentroid"></param>
        
        //public void LayerShowCentroids(ref FeatureLayer lyr, bool blShowCentroid)
        //{
        //    lyr.ShowCentroids = blShowCentroid;
        //}
        ///// <summary>
        ///// Hiển thị Hướng của đường thẳng trong Layer
        ///// </summary>
        ///// <param name="lyr"></param>
        ///// <param name="blShowLineDirection"></param>
        //public void LayerShowLineDirection(ref FeatureLayer lyr, bool blShowLineDirection)
        //{
        //    lyr.ShowLineDirection = blShowLineDirection;
        //}
        ///// <summary>
        ///// Ẩn hiện lớp bản đồ
        ///// </summary>
        ///// <param name="lyr"></param>
        ///// <param name="blEnable"></param>
        //public void LayerEnable(ref FeatureLayer lyr, bool blEnable)
        //{
        //    lyr.Enabled = blEnable;
        //}
        ///// <summary>
        ///// add geometry to temp layer with hollow style
        ///// </summary>
        ///// <param name="g"></param>
        ///// <param name="clear"></param>
        //public void ShowSearchGeometry(FeatureGeometry g, bool clear)
        //{
        //    if (clear)
        //    {
        //        // first clear out any other geometries from table
        //        (tempTable as IFeatureCollection).Clear();
        //    }

        //    Style s = null;
        //    if (g is IGenericSurface) // closed geometry, use area style
        //    {
        //        s = new AreaStyle(new SimpleLineStyle(new LineWidth(2, LineWidthUnit.Pixel), 2, Color.Red, false), new SimpleInterior(0));
        //    }
        //    else if (g is MapInfo.Geometry.Point)
        //    {
        //        s = new SimpleVectorPointStyle(34, Color.Red, 18);
        //    }
        //    Feature f = new Feature(g, s);

        //    //Add feature to temp table
        //    tempTable.InsertFeature(f);
        //}

        //#endregion
    }
}
