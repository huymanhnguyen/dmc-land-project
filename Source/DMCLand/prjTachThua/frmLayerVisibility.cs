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
    public partial class frmLayerVisibility : Form
    {
        public frmLayerVisibility()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            /* Ẩn hộp hồi thoại (Form) */
            this.Hide();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            /* Gán giá trị cho biến thiết đặt chế độ hiển thị lớp dùng chung */
           DMC.Land.TachThua.CommonLand.boolShowCentroids = chkShowCentroid.Checked;
           DMC.Land.TachThua.CommonLand.boolShowLineDirection = chkShowLineDirection.Checked;
           DMC.Land.TachThua.CommonLand.boolShowNodes = chkShowNodes.Checked;
            /* Ẩn Form hộp hồi thoại (Form) */
            this.Hide();
        }

        private void frmLayerVisibility_Load(object sender, EventArgs e)
        {
            /* Hiển thị các giá trị thiết đặt lớp lên các check box tương ứng */
            chkShowCentroid.Checked =DMC.Land.TachThua.CommonLand.boolShowCentroids;
            chkShowLineDirection.Checked =DMC.Land.TachThua.CommonLand.boolShowLineDirection;
            chkShowNodes.Checked =DMC.Land.TachThua.CommonLand.boolShowNodes;
        }
    }
}
