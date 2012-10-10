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

namespace DMC.Land.TachThua
{
    public partial class frmUploadBanDo : Form
    {
        private string strMaDonViHanhChinh = ""; 
        private string strConnection = ""; 
        /* Khai báo biến kiểm tra lỗi */  
        clsDatabase clsData = new clsDatabase();
        /* Khai báo biến xác định kiểu thao tác cơ sở dữ liệu */ 
        private string strDonViHanChinh = "";
        public string MaDonViHanChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
        }
        public string Connection
        {
            get { return strConnection; }
            set { strConnection = value; }
        }
        public frmUploadBanDo()
        {
            InitializeComponent();
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
        private void cmdLuu_Click(object sender, EventArgs e)
        {
            GhiFile();
        }
        public void GhiFile()
        {
            try
            {
                if (lyrControl.Map.Layers.Count  != 1)
                {
                    MessageBox.Show("Chỉ được chọn một lớp bản đồ để đưa vào CSDL", "DMCLand");
                    return;
                }
                string LoaiBanDo = "";
                //thiet lap thong tin ban dau
                if (radBanDoQuan.Checked)
                {
                    DataTable dt = new DataTable();
                    DMC.Land.TachThua.clsHoSoCapGCN cls = new clsHoSoCapGCN();
                    cls.Connection = strConnection;
                    dt = cls.SelMaQuan(strMaDonViHanhChinh);
                    if (dt.Rows.Count > 0)
                    {
                        strMaDonViHanhChinh = dt.Rows[0][0].ToString();
                    }
                    LoaiBanDo = "Q";
                }
                else {
                    LoaiBanDo = "P";
                }


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
                    string LayerName = lyrControl.Map.Layers[i].Alias; 
                    byte[] TablFile = GhiFileMap(LayerName, "tab");
                    byte[] MaplFile = GhiFileMap(LayerName, "Map");
                    byte[] IDlFile = GhiFileMap(LayerName, "ID");
                    byte[] DatlFile = GhiFileMap(LayerName, "dat");
                    UpdateMapFile(1, cboLoaiBanDo.Text,LoaiBanDo, strMaDonViHanhChinh, TablFile, MaplFile, IDlFile, DatlFile, mapControl1.Map.Center.x, mapControl1.Map.Center.y, Convert.ToDouble(mapControl1.Map.Zoom.Value));
                    StaProgressBar.Value = StaProgressBar.Value + 1;
                }
                MessageBox.Show("Thành công", "DMCLand");
                StaProgressBar.Visible = false;
            }
            catch (Exception ex)
            {
                StaProgressBar.Visible = true;
                MessageBox.Show("Lỗi ghi dữ liệu ");
            }

        }
        //LayMaThuaDat khi biet Ma HoSoCapGCN
        public void UpdateMapFile(int flag, string strLayerName,string strLoaiBanDo, string MaDonViHanhChinh, byte[] fileTab, byte[] fileMap, byte[] fileID, byte[] filedat, double CenterX, double CenterY, double Zoom)
        {
            SqlConnection conn = new SqlConnection();
            conn = Connect();
            SqlCommand sqlCommand = new SqlCommand(); ;
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "spThongTinFileDLIEUKGIANNHANQUIHOACH";
            SqlParameter sqlPara;
            DataSet dtResult = new DataSet();
            if ((MaDonViHanhChinh != null) & (MaDonViHanhChinh != "") & (MaDonViHanhChinh != "0"))
            {
                System.Data.SqlClient.SqlParameter DVHC = new System.Data.SqlClient.SqlParameter();
                System.Data.SqlClient.SqlParameter LoaiBanDo = new System.Data.SqlClient.SqlParameter();
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

                LoaiBanDo = new System.Data.SqlClient.SqlParameter("@LoaiBanDo", System.Data.SqlDbType.NVarChar, 20);
                LoaiBanDo.Value = strLoaiBanDo;
                sqlCommand.Parameters.Add(LoaiBanDo);

                LayerName = new System.Data.SqlClient.SqlParameter("@LayerName", System.Data.SqlDbType.NVarChar, 200);
                LayerName.Value = strLayerName;
                sqlCommand.Parameters.Add(LayerName);

                DVHC = new System.Data.SqlClient.SqlParameter("@MaDonViHanhChinh", System.Data.SqlDbType.NVarChar, 20);
                DVHC.Value = MaDonViHanhChinh;
                sqlCommand.Parameters.Add(DVHC);
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
                sqlCommand.CommandText = "spThongTinFileDLIEUKGIANNHANQUIHOACH"; 
 
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

        private string XacDinhDVHC(string DVHC)
        {
            if (radBanDoQuan.Checked)
            {
                DataTable dt = new DataTable();
                DMC.Land.TachThua.clsHoSoCapGCN cls = new clsHoSoCapGCN();
                cls.Connection = strConnection;
                dt = cls.SelMaQuan(DVHC);
                if (dt.Rows.Count > 0)
                {
                    strMaDonViHanhChinh = dt.Rows[0][0].ToString();
                }
                else {
                    strMaDonViHanhChinh = DVHC;
                }
            }
            return strMaDonViHanhChinh;
        }

        private void cmdHienTHi_Click(object sender, EventArgs e)
        {
            MapInfo.Engine.Session.Current.Catalog.CloseAll();
            //thiet lap thong tin ban dau
            HienThiBanDo(XacDinhDVHC(strMaDonViHanhChinh));
        }
        //thuc hien viec load tham 1 ban do moi
        public void HienThiBanDo(string MaDonViHanhChinh)
        {
            try
            {       mapControl1.Map.Name = "Bản đồ " + cboLoaiBanDo.Text ;
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

        private void frmUploadBanDo_Load(object sender, EventArgs e)
        {
            SetupLoad();
            StaProgressBar.Visible = false; ;
            ShowTenBanDo();
        }

        public void ShowTenBanDo()
        {
            string DVHC = XacDinhDVHC(strMaDonViHanhChinh);
            DataTable dt = new DataTable();
            DMC.Land.TachThua.clsHoSoCapGCN cls = new clsHoSoCapGCN();
            cls.Connection = strConnection;
            dt = cls.SelTenBanDo(DVHC);
            if (dt.Rows.Count > 0)
            {
                cboLoaiBanDo.DataSource = dt;
                cboLoaiBanDo.DisplayMember = "layername";
            }         

        }

        private void cmdXoaBanDo_Click(object sender, EventArgs e)
        {
            if (cboLoaiBanDo.Text.Trim() == "")
            {
                MessageBox.Show("Chọn bản đồ", "DMCLand");
                cboLoaiBanDo.Focus();
                return;
            }
             DMC.Land.TachThua.clsHoSoCapGCN cls = new clsHoSoCapGCN();
             cls.Connection = strConnection;
             cls.XoaBanDo(XacDinhDVHC(strMaDonViHanhChinh).ToString(), cboLoaiBanDo.Text.Trim()); 
        }

        private void radBanDoPhuong_CheckedChanged(object sender, EventArgs e)
        {
            ShowTenBanDo();
        }

        private void radBanDoQuan_CheckedChanged(object sender, EventArgs e)
        {
            ShowTenBanDo();
        }
    }
}
