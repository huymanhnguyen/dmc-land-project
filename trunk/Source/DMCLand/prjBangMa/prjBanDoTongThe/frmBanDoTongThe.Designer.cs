namespace HienThiBanDoTongThe
{
    partial class frmBanDoTongThe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBanDoTongThe));
            this.toolTachThuaZoomOut = new System.Windows.Forms.ToolStrip();
            this.toolBanDoTongTheConnection = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.layerControl1 = new MapInfo.Windows.Controls.LayerControl();
            this.mapControl1 = new MapInfo.Windows.Controls.MapControl();
            this.mapToolBarBanDoTongThe = new MapInfo.Windows.Controls.MapToolBar();
            this.mapToolBarArrow = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarZoomIn = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarZoomOut = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarCenter = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarPan = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarSelect = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarRectangle = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarSelectRadius = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarSelectPolygon = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarSelectRegion = new MapInfo.Windows.Controls.MapToolBarButton();
            this.statusBanDoTongThe = new System.Windows.Forms.StatusStrip();
            this.statusBanDoTongTheToaDoDiChuot = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTest = new System.Windows.Forms.ToolStripLabel();
            this.toolTachThuaZoomOut.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusBanDoTongThe.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTachThuaZoomOut
            // 
            this.toolTachThuaZoomOut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBanDoTongTheConnection,
            this.toolTest});
            this.toolTachThuaZoomOut.Location = new System.Drawing.Point(0, 0);
            this.toolTachThuaZoomOut.Name = "toolTachThuaZoomOut";
            this.toolTachThuaZoomOut.Size = new System.Drawing.Size(856, 25);
            this.toolTachThuaZoomOut.TabIndex = 5;
            this.toolTachThuaZoomOut.Text = "toolStrip1";
            // 
            // toolBanDoTongTheConnection
            // 
            this.toolBanDoTongTheConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBanDoTongTheConnection.Image = ((System.Drawing.Image)(resources.GetObject("toolBanDoTongTheConnection.Image")));
            this.toolBanDoTongTheConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBanDoTongTheConnection.Name = "toolBanDoTongTheConnection";
            this.toolBanDoTongTheConnection.Size = new System.Drawing.Size(134, 22);
            this.toolBanDoTongTheConnection.Text = "Kết nối dữ liệu không gian";
            this.toolBanDoTongTheConnection.Click += new System.EventHandler(this.toolBanDoTongTheConnection_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(-2, 54);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.layerControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(860, 560);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 9;
            // 
            // layerControl1
            // 
            this.layerControl1.AllowDragAndDrop = true;
            this.layerControl1.AllowRenaming = true;
            this.layerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layerControl1.AutomaticLabelRemoval = MapInfo.Windows.Controls.LayerControl.LabelRemoval.Prompt;
            this.layerControl1.CheckBoxes = false;
            this.layerControl1.ConfirmLayerRemoval = true;
            this.layerControl1.EditNameAfterInsertingLayer = true;
            this.layerControl1.FeatureLayerImageType = MapInfo.Windows.Controls.LayerControl.ImageType.Sample;
            this.layerControl1.ItemHeight = 20;
            this.layerControl1.Location = new System.Drawing.Point(3, 3);
            this.layerControl1.Map = null;
            this.layerControl1.Name = "layerControl1";
            this.layerControl1.OriginalMap = null;
            this.layerControl1.PointSampleMaximumPointSize = 18;
            this.layerControl1.SelectedObject = null;
            this.layerControl1.SelectedTab = MapInfo.Windows.Controls.PropertiesCategory.Custom;
            this.layerControl1.ShowContextMenu = true;
            this.layerControl1.ShowMapNode = true;
            this.layerControl1.Size = new System.Drawing.Size(203, 554);
            this.layerControl1.TabIndex = 0;
            this.layerControl1.Tools = null;
            this.layerControl1.UpdateWhenCollectionChanges = true;
            this.layerControl1.UpdateWhenMapViewChanges = true;
            this.layerControl1.UpdateWhenNameChanges = true;
            // 
            // mapControl1
            // 
            this.mapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mapControl1.IgnoreLostFocusEvent = false;
            this.mapControl1.Location = new System.Drawing.Point(3, 3);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(644, 554);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.Text = "mapControl1";
            this.mapControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapControl1_MouseMove);
            this.mapControl1.Tools.LeftButtonTool = null;
            this.mapControl1.Tools.MiddleButtonTool = null;
            this.mapControl1.Tools.RightButtonTool = null;
            // 
            // mapToolBarBanDoTongThe
            // 
            this.mapToolBarBanDoTongThe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mapToolBarBanDoTongThe.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.mapToolBarArrow,
            this.mapToolBarZoomIn,
            this.mapToolBarZoomOut,
            this.mapToolBarCenter,
            this.mapToolBarPan,
            this.mapToolBarSelect,
            this.mapToolBarRectangle,
            this.mapToolBarSelectRadius,
            this.mapToolBarSelectPolygon,
            this.mapToolBarSelectRegion});
            this.mapToolBarBanDoTongThe.Dock = System.Windows.Forms.DockStyle.None;
            this.mapToolBarBanDoTongThe.DropDownArrows = true;
            this.mapToolBarBanDoTongThe.Location = new System.Drawing.Point(-2, 23);
            this.mapToolBarBanDoTongThe.MapControl = this.mapControl1;
            this.mapToolBarBanDoTongThe.Name = "mapToolBarBanDoTongThe";
            this.mapToolBarBanDoTongThe.ShowToolTips = true;
            this.mapToolBarBanDoTongThe.Size = new System.Drawing.Size(857, 28);
            this.mapToolBarBanDoTongThe.TabIndex = 10;
            // 
            // mapToolBarArrow
            // 
            this.mapToolBarArrow.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Arrow;
            this.mapToolBarArrow.Name = "mapToolBarArrow";
            this.mapToolBarArrow.ToolTipText = "Arrow";
            // 
            // mapToolBarZoomIn
            // 
            this.mapToolBarZoomIn.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.ZoomIn;
            this.mapToolBarZoomIn.Name = "mapToolBarZoomIn";
            this.mapToolBarZoomIn.ToolTipText = "Zoom-in";
            // 
            // mapToolBarZoomOut
            // 
            this.mapToolBarZoomOut.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.ZoomOut;
            this.mapToolBarZoomOut.Name = "mapToolBarZoomOut";
            this.mapToolBarZoomOut.ToolTipText = "Zoom-out";
            // 
            // mapToolBarCenter
            // 
            this.mapToolBarCenter.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Center;
            this.mapToolBarCenter.Name = "mapToolBarCenter";
            this.mapToolBarCenter.ToolTipText = "Center";
            // 
            // mapToolBarPan
            // 
            this.mapToolBarPan.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Pan;
            this.mapToolBarPan.Name = "mapToolBarPan";
            this.mapToolBarPan.ToolTipText = "Pan";
            // 
            // mapToolBarSelect
            // 
            this.mapToolBarSelect.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Select;
            this.mapToolBarSelect.Name = "mapToolBarSelect";
            this.mapToolBarSelect.ToolTipText = "Select";
            // 
            // mapToolBarRectangle
            // 
            this.mapToolBarRectangle.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectRectangle;
            this.mapToolBarRectangle.Name = "mapToolBarRectangle";
            this.mapToolBarRectangle.ToolTipText = "Marquee Select";
            // 
            // mapToolBarSelectRadius
            // 
            this.mapToolBarSelectRadius.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectRadius;
            this.mapToolBarSelectRadius.Name = "mapToolBarSelectRadius";
            this.mapToolBarSelectRadius.ToolTipText = "Radius Select";
            // 
            // mapToolBarSelectPolygon
            // 
            this.mapToolBarSelectPolygon.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectPolygon;
            this.mapToolBarSelectPolygon.Name = "mapToolBarSelectPolygon";
            this.mapToolBarSelectPolygon.ToolTipText = "Polygon Select";
            // 
            // mapToolBarSelectRegion
            // 
            this.mapToolBarSelectRegion.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectRegion;
            this.mapToolBarSelectRegion.Name = "mapToolBarSelectRegion";
            this.mapToolBarSelectRegion.ToolTipText = "Region Select";
            // 
            // statusBanDoTongThe
            // 
            this.statusBanDoTongThe.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBanDoTongTheToaDoDiChuot});
            this.statusBanDoTongThe.Location = new System.Drawing.Point(0, 617);
            this.statusBanDoTongThe.Name = "statusBanDoTongThe";
            this.statusBanDoTongThe.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusBanDoTongThe.Size = new System.Drawing.Size(856, 22);
            this.statusBanDoTongThe.TabIndex = 11;
            this.statusBanDoTongThe.Text = "statusStrip1";
            // 
            // statusBanDoTongTheToaDoDiChuot
            // 
            this.statusBanDoTongTheToaDoDiChuot.Name = "statusBanDoTongTheToaDoDiChuot";
            this.statusBanDoTongTheToaDoDiChuot.Size = new System.Drawing.Size(81, 17);
            this.statusBanDoTongTheToaDoDiChuot.Text = "Toa do di chuot";
            // 
            // toolTest
            // 
            this.toolTest.Name = "toolTest";
            this.toolTest.Size = new System.Drawing.Size(28, 22);
            this.toolTest.Text = "Test";
            this.toolTest.Click += new System.EventHandler(this.toolTest_Click);
            // 
            // frmBanDoTongThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 639);
            this.Controls.Add(this.statusBanDoTongThe);
            this.Controls.Add(this.mapToolBarBanDoTongThe);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolTachThuaZoomOut);
            this.Name = "frmBanDoTongThe";
            this.Text = "Ban do tong the";
            this.Load += new System.EventHandler(this.frmBanDoTongThe_Load);
            this.toolTachThuaZoomOut.ResumeLayout(false);
            this.toolTachThuaZoomOut.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.statusBanDoTongThe.ResumeLayout(false);
            this.statusBanDoTongThe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolTachThuaZoomOut;
        private System.Windows.Forms.ToolStripButton toolBanDoTongTheConnection;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MapInfo.Windows.Controls.LayerControl layerControl1;
        private MapInfo.Windows.Controls.MapControl mapControl1;
        private MapInfo.Windows.Controls.MapToolBar mapToolBarBanDoTongThe;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarArrow;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarZoomIn;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarZoomOut;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarCenter;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarPan;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarSelect;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarRectangle;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarSelectRadius;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarSelectPolygon;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarSelectRegion;
        private System.Windows.Forms.StatusStrip statusBanDoTongThe;
        private System.Windows.Forms.ToolStripStatusLabel statusBanDoTongTheToaDoDiChuot;
        private System.Windows.Forms.ToolStripLabel toolTest;
    }
}

