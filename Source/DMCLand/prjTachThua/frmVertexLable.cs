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
    public partial class frmVertexLable : Form
    {
        public frmVertexLable()
        {
            InitializeComponent();
        }
        /* Khai báo biến khoảng cách từ đỉnh tới Nhãn */
        private double dblDistance;
        /* Khai báo biến Độ rộng của nhãn */
        private double dblWidth;
        /* Khai báo biến Chiều cao của nhãn */
        private double dblHeight;
        /* Khai báo thuộc tính từ đỉnh tới nhãn */
        public double Distance
        {
            get { return dblDistance; }
            set { dblDistance = value; }
        }
        /* Khai báo thuộc tính Độ rộng của nhãn */
        public double Width
        {
            get { return dblWidth;}
            set { dblWidth = value;}
        }
        /* Khai báo thuộc tính Chiều cao của nhãn */
        public double Height
        {
            get { return dblHeight;}
            set { dblHeight = value; }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            /* Xác nhận khoảng cách từ đỉnh tới nhãn */
            dblDistance = (double)this.numDistance.Value;
            /* Xác định chiều cao của nhãn */
            dblHeight = (double)this.numHeight.Value;
            /* Xác định chiểu Rộng của nhãn */
            dblWidth = (double)this.numWidth.Value;
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            dblDistance = 0.00;
            dblWidth = 0.00;
            dblHeight = 0.00;
            this.Hide();
        }

        private void rdbtnDefault_Click(object sender, EventArgs e)
        {
            /* Thiết lập mặc định */
            this.Default();
        }

        private void rdbtnCustomized_Click(object sender, EventArgs e)
        {
            /* Cho phép hiệu chỉnh kích thước Nhãn đỉnh */
            numWidth.Enabled = true;
            numHeight.Enabled = true;
        }

        private void frmVertexLable_Load(object sender, EventArgs e)
        {
            /* Thiết lập mặc định */
            this.Default();
        }

        private void Default()
        {
            /* Đặt default */
            rdbtnDefault.Checked = true;
            /* Không cho phép hiệu chỉnh kích thước Nhãn đỉnh */
            numWidth.Enabled = false;
            numHeight.Enabled = false;
            /* Gán giá trị kích thước nhãn mặc định */
            numWidth.Value = (decimal)0.50;
            numHeight.Value =(decimal)1.00;
        }
    }
}
