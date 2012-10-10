using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMC.Land.TinhToanDenBu
{
    public partial class frmChiTietDenBu : Form
    {
        public frmChiTietDenBu()
        {
            InitializeComponent();
        }
        private DataTable dt;

        public DataTable MyTable
        {
            get { return dt; }
            set { dt = value; }
        }

        private void frmChiTietDenBu_Load(object sender, EventArgs e)
        {
            
            grdChiTietDenBu.DataSource = dt;
        }
    }
}
