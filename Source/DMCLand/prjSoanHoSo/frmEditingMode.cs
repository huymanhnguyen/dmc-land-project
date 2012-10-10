using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMC.Land.SoanHoSo
{
    public partial class frmEditingMode : Form
    {
        public frmEditingMode()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.radioAddNode.Checked)
               DMC.Land.TachThua.CommonLand.EditMode = MapInfo.Tools.EditMode.AddNode;
            else if (this.radioNodes.Checked)
               DMC.Land.TachThua.CommonLand.EditMode = MapInfo.Tools.EditMode.Nodes;
            else if (this.radioNone.Checked)
               DMC.Land.TachThua.CommonLand.EditMode = MapInfo.Tools.EditMode.None;
            else
               DMC.Land.TachThua.CommonLand.EditMode = MapInfo.Tools.EditMode.Objects;
            this.Hide();
        }

        private void frmEditingMode_Load(object sender, EventArgs e)
        {
            if (DMC.Land.TachThua.CommonLand.EditMode == MapInfo.Tools.EditMode.AddNode)
                this.radioAddNode.Checked = true;
            else if (DMC.Land.TachThua.CommonLand.EditMode == MapInfo.Tools.EditMode.Nodes)
                this.radioNodes.Checked = true;
            else if (DMC.Land.TachThua.CommonLand.EditMode == MapInfo.Tools.EditMode.None)
                this.radioNone.Checked = true;
            else
                this.radioObjects.Checked = true;
        }

    }
}
