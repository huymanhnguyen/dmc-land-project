using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public  class LayerConnection
    {
        /// <summary>
        /// Mở một bản đồ trong cơ sở dữ liệu không gian
        /// </summary>
        /// <param name="mapControl"></param>
        /// <param name="lyrs"></param>
        /// <param name="strAlias"></param>
        /// <param name="strConnection"></param>
        /// <param name="strQuery"></param>
        public void OpenLayer(ref MapInfo.Windows.Controls.MapControl map, string strAlias, string strConnection, string strTableName, string strMaDonViHanhChinh)
        {
            try
            {
                /* Kiểm tra sự tồn tại lớp có tên là strAlias */
                if (map.Map.Layers.Contains(map.Map.Layers[strAlias]))
                    /* Nếu tồn tại lớp có tên là strAlias thì đóng lớp đó lại trước khi thực hiện */
                    MapInfo.Engine.Session.Current.Catalog.CloseTable(strAlias);

               // OpenConnection(ref  miConnection);

                MapInfo.Data.MIConnection miConnection = new MapInfo.Data.MIConnection();
                miConnection.Open();

                MapInfo.Data.Table[] tables = new MapInfo.Data.Table[1];
                MapInfo.Data.TableInfoServer tableInfoServer = new MapInfo.Data.TableInfoServer(strAlias);
                tableInfoServer.Alias = strAlias;
                tableInfoServer.ConnectString = strConnection;
                string strQuery = "";
                strQuery = "Select * From " + strTableName;// +" Where MaDonViHanhChinh = '" + strMaDonViHanhChinh + "'";
   //             strQuery = "Select * From " + strTableName + " Where MaDonViHanhChinh = " + strMaDonViHanhChinh + "";
                tableInfoServer.Query = strQuery;
                tableInfoServer.Toolkit = MapInfo.Data.ServerToolkit.Odbc;
                /* Kiểm tra xem tablInfoServer có mở hay không 
                 * Nếu đang mở thì ta đóng lại */
                miConnection.Catalog.CloseTable(strAlias);
                tables[0] = miConnection.Catalog.OpenTable(tableInfoServer);
                MapInfo.Mapping.FeatureLayer featureLayer = new MapInfo.Mapping.FeatureLayer(tables[0]);
               // MapInfo.Data.IResultSetFeatureCollection fcNewLine = MapInfo.Engine.Session.Current.Catalog.Search(tables[0], MapInfo.Data.SearchInfoFactory.SearchAll());
                map.Map.Layers.Add(featureLayer);

                miConnection.Close();

                //string strQuery = "";
                //strQuery = "Select * From " + strTableName + " Where MaDonViHanhChinh = " + strMaDonViHanhChinh + "";
                //MapInfo.Data.MIConnection Connection = new MapInfo.Data.MIConnection();
                //Connection.Open();
                //MapInfo.Data.Table[] tables = new MapInfo.Data.Table[1];
                //MapInfo.Data.TableInfoServer tis1 = new MapInfo.Data.TableInfoServer(strAlias, strConnection, strQuery, MapInfo.Data.ServerToolkit.Odbc);
                //tables[0] = Connection.Catalog.OpenTable(tis1);
                //MapInfo.Mapping.FeatureLayer lyrs = new MapInfo.Mapping.FeatureLayer(tables[0]);
                //map.Map.Layers.Add(lyrs);
                //Connection.Close();
                //MapInfo.Data.IResultSetFeatureCollection fcNewLine = MapInfo.Engine.Session.Current.Catalog.Search(tables[0], MapInfo.Data.SearchInfoFactory.SearchAll());

                //MapInfo.Data.Table tab = null;
                //clsMainSoanHoSo cls = new clsMainSoanHoSo();
                //if (MapInfo.Engine.Session.Current.Catalog.GetTable("Dat") != null)
                //{
                //    MapInfo.Engine.Session.Current.Catalog.CloseTable("Dat");
                //}
                ////tao doi tuong table co ten la tmp cho bang thua dat
                //tab = cls.CreateDataTable(map.Map, tables[0].Alias, "Dat", tables[0]);
                //MapInfo.Styles.CompositeStyle cs = new MapInfo.Styles.CompositeStyle();
                //foreach (MapInfo.Data.Feature f in fcNewLine)
                //{
                //    cls.UpdateDoiTuong(tab, f.Geometry, "", cs);
                //}
                //MapInfo.Mapping.FeatureLayer ly = new MapInfo.Mapping.FeatureLayer(tab);
                //map.Map.Layers.Add(lyrs);
                //Connection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi mở lớp bản đồ: " + System.Environment.NewLine + ex.Message, "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        public void OpenLayer(ref MapInfo.Mapping.Map map, string strAlias, string strConnection, string strTableName)
        {
            try
            {
                /* Kiểm tra sự tồn tại lớp có tên là strAlias */
                if (map.Layers.Contains(map.Layers[strAlias]))
                    /* Nếu tồn tại lớp có tên là strAlias thì đóng lớp đó lại trước khi thực hiện */
                    MapInfo.Engine.Session.Current.Catalog.CloseTable(strAlias);

                //OpenConnection(ref  miConnection);

                MapInfo.Data.MIConnection miConnection = new MapInfo.Data.MIConnection();
                miConnection.Open();

                MapInfo.Data.Table[] tables = new MapInfo.Data.Table[1];
                MapInfo.Data.TableInfoServer tableInfoServer = new MapInfo.Data.TableInfoServer(strAlias);
                tableInfoServer.Alias = strAlias;
                tableInfoServer.ConnectString = strConnection;
                string strQuery = "";
               strQuery = "Select * From " + strTableName;
               // strQuery = "Select * From " + strTableName + "Where MaDonViHanhChinh = " + strMaDonViHanhChinh;
                tableInfoServer.Query = strQuery;
                tableInfoServer.Toolkit = MapInfo.Data.ServerToolkit.Odbc;
                /* Kiểm tra xem tablInfoServer có mở hay không 
                 * Nếu đang mở thì ta đóng lại */
                miConnection.Catalog.CloseTable(strAlias);
                tables[0] = miConnection.Catalog.OpenTable(tableInfoServer);
                MapInfo.Mapping.FeatureLayer featureLayer = new MapInfo.Mapping.FeatureLayer(tables[0]);
                map.Layers.Add(featureLayer);
                miConnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi mở lớp bản đồ: " + System.Environment.NewLine + ex.Message, "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        public void OpenConnection(ref MapInfo.Data.MIConnection miConnection)
        {
            if (miConnection.State == System.Data.ConnectionState.Closed)
            {
                miConnection.Open();
            }
        }
        public void CloseConnection(ref MapInfo.Data.MIConnection miConnection)
        {
            if (miConnection.State == System.Data.ConnectionState.Open )
            {
                miConnection.Close();
            }
        }
    }
}
