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
    public partial class frmInfoTool : Form
    {
        public frmInfoTool()
        {
            InitializeComponent();
        }

        private void frmInfoTool_Load(object sender, EventArgs e)
        {
            DMC.GIS.Common.FeatureInfo featureInfo = new DMC.GIS.Common.FeatureInfo();
            /* */
            MapInfo.Data.Feature feature = featureInfo.GetSelectedLandInfo(DMC.Land.TachThua.CommonLand.mapControl.Map , "Đất");
            if (feature == null)
                return;
            this.txtDienTich.Text =  feature["DienTichTuNhien"].ToString();
            this.txtSoHieuThua.Text = feature["SoThua"].ToString();
            this.txtToBanDo.Text = feature["ToBanDo"].ToString();
        }
    }
}
