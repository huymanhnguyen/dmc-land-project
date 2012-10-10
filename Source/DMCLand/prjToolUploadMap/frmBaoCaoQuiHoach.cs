using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data .SqlClient ;


namespace prjToolUploadMap
{
    public partial class frmBaoCaoQuiHoach : Form
    { 
        
        private string strconnect="";
           

        public string Connect
        {
            get { return strconnect; }
            set { strconnect = value; }      
        }


        public void ShowDuAnQuiHoach()
        {  

          clsToolUploadMap cls = new clsToolUploadMap ();        
          cls.Connection = strconnect ;
          DataTable dt=new DataTable ();
         reportDocument1.FileName  = Application.StartupPath + @"\Reports\quanlyquihoach.rpt";
            
         cls.BaocaoquiHoach("0",dt);
        reportDocument1.SetDataSource(dt);
         this.crystalReportViewer1  .ReportSource = reportDocument1;
        
        }


        public frmBaoCaoQuiHoach()
        {
            InitializeComponent();
        }

        private void frmBaoCaoQuiHoach_Load(object sender, EventArgs e)
        {

        }
    }
}
