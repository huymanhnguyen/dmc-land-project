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
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            /* Xác định tên trường thuộc tính cần tìm */
            string strColumnName = "", strValue = "";
            if (cmbColumnName.Text.Trim() == "Tờ bản đồ")
                strColumnName = "ToBanDo";
            else if (cmbColumnName.Text.Trim() == "Số hiệu thửa đất")
                strColumnName = "SoThua";
            else if (cmbColumnName.Text.Trim() == "Diện tích thửa đất")
                strColumnName = "DienTichTuNhien";
            else if (cmbColumnName.Text.Trim() == "Trạng thái hồ sơ cấp GCN")
                strColumnName = "Status";
            /* Trường hợp không phải là một trong các trường trên thì ngừng thực thi */
            else
            {
                /* Thông báo cho người dùng biết rằng: Tên trường không đúng */
                System.Windows.Forms.MessageBox.Show("Tên trường không đúng!", "DMCLand");
                this.cmbColumnName.Focus();
                return;
            }
            /* Kiểm tra giá trị tìm kiếm cho phù hợp với kiểu dữ liệu của trường thuộc tính */
            strValue = txtValue.Text.Trim();
            if (strValue == "")
            {
                /* Thông báo cho người dùng biết rằng: Cần phải nhập giá trị cần tìm */
                System.Windows.Forms.MessageBox.Show("Bạn phải nhập giá trị cần tìm!", "DMCLand");
                this.txtValue.Focus();
                return;
            }
            if (strColumnName.ToString() == "DienTichTuNhien")
            {
                Decimal decimalOut = new Decimal();
                if (!Decimal.TryParse(strValue, out decimalOut))
                {
                    System.Windows.Forms.MessageBox.Show("Vui lòng kiểm tra lai dữ liệu đầu vào...", "DMCLand");
                    return;
                }
            }

            DMC.GIS.Common.SearchTools searchTools = new DMC.GIS.Common.SearchTools();
            searchTools.SearchWithColumn(DMC.Land.TachThua.CommonLand.mapControl.Map , "Đất", strColumnName, strValue,DMC.Land.TachThua.CommonLand.MaDonViHanhChinh);

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
