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
    public partial class frmChiaDoan : Form
    {
        public frmChiaDoan()
        {
            InitializeComponent();
        }

        private void frmChiaDoan_Load(object sender, EventArgs e)
        {
            /* Hiển thị độ dài đoạn thẳng trên Form */
            this.lblTongDoDai.Text  = System.Math.Round (DMC.Land.TachThua.CommonLand.dblLineLength,6).ToString();
            /* Thiết lập giá trị lớn nhất cho khoảng cách cần chia */
            this.numDoDaiDoanDau.Maximum = System.Math.Round(DMC.Land.TachThua.CommonLand.dblLineLength,2);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            /* Xác nhận không chia đoạn thẳng */
           DMC.Land.TachThua.CommonLand.boolChiaDoanThang = false;
            /* Gán giá trị khoảng chia về giá trị mặc định */
           DMC.Land.TachThua.CommonLand.dblDistance = 0.0;
            this.Hide();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

           DMC.Land.TachThua.CommonLand.dblDistance = Convert.ToDouble(this.numDoDaiDoanDau.Value );
            /* Xác nhận chia đoạn thẳng */
           DMC.Land.TachThua.CommonLand.boolChiaDoanThang = true;
            this.Hide();
        }

        private void numDoDaiDoanDau_ValueChanged(object sender, EventArgs e)
        {
            /* Nếu thay đổi độ dài đoạn đầu thì hiển thị độ dài đoạn sau */
            decimal dblTemp;
            dblTemp =DMC.Land.TachThua.CommonLand.dblLineLength - numDoDaiDoanDau.Value;
            this.txtDoDaiDoanCuoi.Text = System.Math.Round ( (dblTemp),2).ToString();
        }
    }
}
