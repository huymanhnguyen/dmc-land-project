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
    public partial class frmViewEntireLayer : Form
    {
        public frmViewEntireLayer()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            /* Ẩn Form */
            this.Hide();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            /* Zoom toàn bộ lớp bản đồ với tên lớp được cho trước */
            DMC.GIS.Common.MapTools mapTools = new DMC.GIS.Common.MapTools();
            mapTools.ViewEntireLayer(DMC.Land.TachThua.CommonLand.mapControl.Map , cmbLayersName.Text.Trim());
            /* Ẩn Form */
            this.Hide();
        }

        private void frmViewEntireLayer_Load(object sender, EventArgs e)
        {
            /* Chắc chắn rằng tồn tại đối tượng bản đồ */
            if (DMC.Land.TachThua.CommonLand.mapControl.Map  == null)
                return;
            /* Chắc chắn rằng có tồn tại lớp bản đồ trên đối tượng bản đồ */
            if (DMC.Land.TachThua.CommonLand.mapControl.Map.Layers.Count < 1)
                return;
            /* Khai báo và gán giá trị biến số lớp của bản đồ */
            int intLayerNumber =DMC.Land.TachThua.CommonLand.mapControl.Map.Layers.Count;
            /* Khai báo và khởi tạo cho biến mảng tên các lớp trên bản đồ */
            string[] strLayersName = new string[intLayerNumber];
            /* Gán giá trị cho biến mảng danh sách tên các lớp của bản đồ */             
            for (int i = 0; i < intLayerNumber; i++)
            {
                strLayersName[i] =DMC.Land.TachThua.CommonLand.mapControl.Map.Layers[i].Alias;
            }
            /* Gán giá trị cho điều khiển combox chứa danh sách tên các lớp bản đồ */
            cmbLayersName.DataSource = strLayersName;
        }
    }
}
