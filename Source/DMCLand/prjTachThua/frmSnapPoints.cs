using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TachThua
{
    public partial class frmSnapPoints : Form
    {
        public frmSnapPoints()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
           DMC.Land.TachThua.CommonLand.boolSnapEnable  = chkSnapEnable.Checked;
           DMC.Land.TachThua.CommonLand.shortTolerance  = (short )numKhoangCachBatDinh.Value;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void chkSnapEnable_CheckedChanged(object sender, EventArgs e)
        {
            this.numKhoangCachBatDinh.Enabled = chkSnapEnable.Checked ;
        }

        private void frmSnapPoints_Load(object sender, EventArgs e)
        {
            this.chkSnapEnable.Checked =DMC.Land.TachThua.CommonLand.boolSnapEnable;
            this.numKhoangCachBatDinh.Enabled =DMC.Land.TachThua.CommonLand.boolSnapEnable ;
            this.numKhoangCachBatDinh.Value =DMC.Land.TachThua.CommonLand.shortTolerance;
        }
    }
}
