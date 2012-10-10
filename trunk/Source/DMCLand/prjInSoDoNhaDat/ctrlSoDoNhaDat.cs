using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace DMC.Land.InSoDoNhaDat
{
    public partial class ctrlSoDoNhaDat : UserControl
    {
        public ctrlSoDoNhaDat()
        {
            InitializeComponent();
        }
        /* Khai báo biến nhận đối tượng bản đồ */
        MapInfo.Mapping.Map mapSoDoNhaDat = null;
        /* Khai báo biến thiết lập chiều cao của Ảnh */
        double   dblHeightScale = 1.0;
        /* Khai báo thuộc tính nhận chiều cao của Ảnh */
        public double  HeightScale
        {
            set { dblHeightScale = value;}
            get { return dblHeightScale; }
        }
        /* Khai báo thuộc tính nhận đối tượng bản đồ */
        public MapInfo.Mapping.Map SoDoNhaDat
        {
            set { mapSoDoNhaDat = value;}
            get { return mapSoDoNhaDat;}
        }
        /* Khai báo biến kiểu mảng Byte hình ảnh bản đồ cần in */
        byte[] bytImage = null;
        /* Khai báo thuộc tính kiểu mảng Byte hình ảnh bản đồ cần in */
        public byte[] Image
        {
            set { bytImage = value; }
            get { return bytImage; }
        }
        private void Printing()
        {
            MapInfo.Printing.MapPrinting printMap = new MapInfo.Printing.MapPrinting();
            printMap.Map = mapSoDoNhaDat;
            /* Set the page layout - optional */
            printMap.ShowDialog = true;
            printMap.Print();
        }

        private void Previewing()
        {
            MapInfo.Printing.MapPrinting printMap = new MapInfo.Printing.MapPrinting();
            printMap.Map = mapSoDoNhaDat;
            /* Set the page layout - optional */
            printMap.ShowDialog = true;
            printMap.PrintPreview();
        }

        public void  ShowReport()
        {
            try
            {
                /* Khai báo và khởi tạo đối tượng ReportDocument */
                ReportDocument objRep = new ReportDocument();
                string strFile  = "";
                strFile = Application.StartupPath + "\\Reports\\GiayChungNhan\\" + "rptGCN3.rpt";
                objRep.Load(strFile, OpenReportMethod.OpenReportByDefault);
                if (bytImage != null)
                {
                    /* Thiết lập chiều cao của ảnh Sơ đồ nhà đất */
                    this.setObjectHeight(ref objRep, "image");                  
                    DataTable dtLandImage = new DataTable();
                    // object of data row
                    DataRow drImage;
                    // add the column in table to store the image of Byte array type
                    dtLandImage.Columns.Add("Image", System.Type.GetType("System.Byte[]"));
                    drImage = dtLandImage.NewRow();
                    drImage[0] = bytImage;
                    /* Add cột Image cho bảng dtLandImage */
                    dtLandImage.Rows.Add(drImage);
                    objRep.SetDataSource(dtLandImage); 
                }
                else
                {

                }
                /* Gán đối tượng ReportDocument cho điều khiển CrystalReportViewer */
                this.crptMap.ReportSource = objRep;
                this.crptMap.Refresh();
            }
            catch ( Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this," Hiển thị sơ đồ nhà đất: " + System.Environment.NewLine + " Lỗi: " + ex.Message,"DMCLand",MessageBoxButtons.OK );
            }
        }

        private void toolCongCuXem_Click(object sender, EventArgs e)
        {
            /* Kiểm tra dữ liệu trước khi hiển thị */
            if (bytImage == null)
                return;
            this.ShowReport();
        }

        private void  setObjectHeight( ref ReportDocument objRep , string   strObjectName)
        {
            foreach ( ReportObject  objX in objRep.ReportDefinition.ReportObjects)
            {
                /* Ten cua Object */
                if (objX.Name == strObjectName )
                {
                    if (dblHeightScale > 0)
                    {
                        objX.Height = Convert.ToInt16(dblHeightScale * objX.Width);
                    }
                }
            }
        }

    }
}
