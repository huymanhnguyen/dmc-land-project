using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace prjToolUploadMap
{
    public partial class frmBaoCaoDuAnDoThi : Form
    {
        private string strconnect = "";


        public string Connect
        {
            get { return strconnect; }
            set { strconnect = value; }
        }

        public void ShowDuAnQuiHoachDoThi()
        {

            clsToolUploadMap cls = new clsToolUploadMap();
            cls.Connection = strconnect;
            DataTable dt = new DataTable();
            reportDocument1.FileName = Application.StartupPath + @"\Reports\quanlyquihoachDoThi.rpt";

            cls.BaocaoquiHoach("1", dt);
            reportDocument1.SetDataSource(dt);
            this.crystalReportViewer1.ReportSource = reportDocument1;

        }


        public frmBaoCaoDuAnDoThi()
        {
            InitializeComponent();
        }

        private void frmBaoCaoDuAnDoThi_Load(object sender, EventArgs e)
        {

        }
    }
}
