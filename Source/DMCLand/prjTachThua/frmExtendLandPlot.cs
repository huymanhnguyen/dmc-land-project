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
    
    public partial class frmExtendLandPlot : Form
    {
        private bool bolOk = false;
        public bool OK {
            set { bolOk = value; }
            get { return bolOk; }
        }
        public frmExtendLandPlot()
        {
            InitializeComponent();
        }
        /* Khai báo biến khoảng cách từ đỉnh tới Nhãn */
        private double dblDistance;
        /* Khai báo thuộc tính từ đỉnh tới nhãn */
        public double Distance
        {
            get { return dblDistance; }
            set { dblDistance = value; }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            /* Xác nhận khoảng cách từ đỉnh tới nhãn */
            dblDistance = (double)this.numDistance.Value;
            bolOk = true;
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            bolOk = false;
            dblDistance = 0.0;
            this.Hide();
        }

        private void frmExtendLandPlot_Load(object sender, EventArgs e)
        {
            /* Thiết lập mặc định */
            this.Default();
        }

        private void rdbtnCustomized_Click(object sender, EventArgs e)
        {
            /* Cho phép hiệu chỉnh khoảng cách */
            numDistance.Enabled = true;
        }

        private void Default()
        {
            /* Đặt default */
            rdbtnDefault.Checked = true;
            /* Không cho phép hiệu chỉnh khoảng cách */
            numDistance.Enabled = false;
            /* Gán giá trị kích thước nhãn mặc định */
            numDistance.Value = (decimal)0.5;
        }

        private void rdbtnDefault_Click(object sender, EventArgs e)
        {
            /* Thiết lập mặc định */
            this.Default();
        }
    }
}
