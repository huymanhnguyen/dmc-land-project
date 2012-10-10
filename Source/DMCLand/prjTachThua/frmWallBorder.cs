using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMC.Land.TachThua
{
    public partial class frmWallBorder : Form
    {
        public frmWallBorder()
        {
            InitializeComponent();
        }
        /* Khoảng cách từ tường tới thửa đất */
        private double  dblDistance ;
        public double Distance
        {
            get { return dblDistance;}
            set { dblDistance = value;}
        }
        /* Khai báo biến xác nhận lấy tương đối */
        private bool boolRelatively = false;
        public bool Relatively
        {
            get { return boolRelatively ; }
            set { boolRelatively  = value; }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            dblDistance = (double)this.numDistance.Value;
            if (chkKieuBao.Checked)
            {
                dblDistance = 0 - dblDistance;
            }
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            dblDistance = 0.00;
            this.Hide();
        }

        private void rdbtnAccurate_Click(object sender, EventArgs e)
        {
            this.Default();
        }
        private void Default()
        {
            rdbtnAccurate.Checked = true;
            numDistance.Enabled = true;
            boolRelatively = false;
        }

        private void frmWallBorder_Load(object sender, EventArgs e)
        {
            this.Default();
        }

        private void rdbtnRelatively_Click(object sender, EventArgs e)
        {
            boolRelatively = true;
        }

        private void chkKieuBao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKieuBao.Checked)
            {
                chkKieuBao.Text = "Đường bao trong thửa";
             
            }
            else {
                chkKieuBao.Text = "Đường bao ngoài thửa";
             
            }

        }

        private void numDistance_ValueChanged(object sender, EventArgs e)
        {
            if (numDistance.Value < 0)
            {
                numDistance.Value = 0;
            }
        }

        private void numDistance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Subtract)
            {
                numDistance.Value = Convert.ToDecimal( 0);
            }
        }
    }
}
