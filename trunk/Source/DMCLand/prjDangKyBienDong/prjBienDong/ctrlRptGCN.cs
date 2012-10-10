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
using System.Drawing.Printing;

namespace DMC.Land.DangKyBienDong
{
    public partial class ctrlRptGCN : UserControl
    {
        public ctrlRptGCN()
        {
            InitializeComponent();
        }
        private CrystalDecisions.CrystalReports.Engine.ReportDocument  objRep;
        /* Khai báo biến nhận chuỗi kết nối cơ sở dữ liệu */
        private string strConnection = "";
        /* Khai báo biến nhận Mã hồ sơ cấp GCN */
        private string strMaHoSoCapGCN = "";
        /* Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu */
        public string Connection
        {
            set { strConnection = value;}
        }
        /* Khai báo thuộc tính nhận Mã hồ sơ cấp GCN */
        public string MaHoSoCapGCN
        {
            set { strMaHoSoCapGCN = value;}
        }

        public void ShowDataGCN4()
        {
          try
          {
                /* Khai báo và khởi tạo đối tượng ReportDocument */
                objRep = new ReportDocument();
                string strFile = "";
                DataTable dtMatBonGCN = new DataTable();
                if (strMaHoSoCapGCN == "")
                {
                    MessageBox.Show(this, "Chưa có thông tin cấp GCN!", "DMCLand", MessageBoxButtons.OK);
                    return;
                }
                strFile = Application.StartupPath + "\\Reports\\GiayChungNhan\\" + "rptGCN4.rpt";
                objRep.Load(strFile, OpenReportMethod.OpenReportByDefault);
                //dtMatBonGCN.Clear();
                /* Nôi dung thay đổi và cơ sở pháp lý */


                /* Khai báo lớp thông tin Mặt 4 Giấy chứng nhận */
                clsMatBonGCN MatBonGCN = new clsMatBonGCN();
                MatBonGCN.Connection = strConnection;
                MatBonGCN.MaHoSoCapGCN = strMaHoSoCapGCN;
                dtMatBonGCN = MatBonGCN.SelectNoiDungThayDoiVaCoSoPhapLyByMaHoSoCapGCN();
                string strNoiDungMatBonGCN = "";
                string strNewLine = "";
                if (dtMatBonGCN != null)
                {
                    /* Nội dung ghi mặt bốn Giấy chứng nhận (Nội dung thay đổi và cơ sở pháp lý) */
                    if (dtMatBonGCN.Rows.Count > 0)
                     {
                        
                        for (int i = 0; i < dtMatBonGCN.Rows.Count; i++)
                        {
                           if (dtMatBonGCN.Rows[i]["Chon"].ToString() == "False")
                            {
                                //if (strNoiDungMatBonGCN != "")
                                //{
                                    strNewLine += System.Environment.NewLine;
                                //}
                                
                            }  
                        if (dtMatBonGCN.Rows[i]["Chon"].ToString() == "True")
                        {
                            //if (strNoiDungMatBonGCN != "")
                            //{
                            if (strNoiDungMatBonGCN != "")
                            {
                                if (strNewLine == "")
                                {
                                    strNoiDungMatBonGCN += System.Environment.NewLine;
                                }
                            }
                                strNoiDungMatBonGCN += strNewLine + dtMatBonGCN.Rows[i]["NoidungSoBienDong"].ToString();
                            //}
                            //else
                            //{
                            //    strNoiDungMatBonGCN += dtMatBonGCN.Rows[i]["NoidungSoBienDong"].ToString() + System.Environment.NewLine;
                            //}                             
                        }
                        }
                    }
                }
                objRep.ParameterFields["NoiDungThayDoiVaCoSoPhapLy"].CurrentValues.AddValue(strNoiDungMatBonGCN);
                /* Gán đối tượng ReportDocument cho điều khiển CrystalReportViewer */
                this.crptGCN.ReportSource = objRep;
                this.crptGCN.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, " Hiển thị nội dung mặt bốn GCN: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK);
            }
        }

        private void toolCongCuIn_Click(object sender, EventArgs e)
        {
            try
            {
                printDialog.Document = printDocument;
                printDialog.AllowSomePages = false;
                printDialog.AllowSelection = false;
                printDocument.DefaultPageSettings.Landscape = true;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    int ncopy = printDocument.PrinterSettings.Copies;
                    string  printerName = printDocument.PrinterSettings.PrinterName;
                    objRep.PrintOptions.PrinterName = printerName;
                    objRep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;
                    objRep.PrintToPrinter(ncopy, false, 0, 0);
                }
            }
            catch( Exception ex)
            {
                 MessageBox.Show (this," In Giấy chứng nhận " + System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + ex.Message,"DMCLand",MessageBoxButtons.OK);
            }
        }

        private void toolCongCuXem_Click(object sender, EventArgs e)
        {
            try
            {
                /* Hiển thị Nội dung thay đổi và cơ sở pháp lý
                 * trên mặt 4 Giấy chứng nhận */
                this.ShowDataGCN4();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi hiển thị mặt 4 giấy chứng nhận", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
