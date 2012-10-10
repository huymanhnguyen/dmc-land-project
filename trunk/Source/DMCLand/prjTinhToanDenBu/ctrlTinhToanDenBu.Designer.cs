namespace DMC.Land.TinhToanDenBu
{
    partial class ctrlTinhToanDenBu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLopBanDo = new System.Windows.Forms.TabPage();
            this.lyrControl = new MapInfo.Windows.Controls.LayerControl();
            this.tabPageThongTindenBu = new System.Windows.Forms.TabPage();
            this.cmdChiTiet = new System.Windows.Forms.Button();
            this.cmdTinh = new System.Windows.Forms.Button();
            this.txtTongGiaTriTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGiaTriTienTrenM2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongDienTich = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mapToolBar = new MapInfo.Windows.Controls.MapToolBar();
            this.mapToolBarButtonArrow = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonZoomIn = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonZoomOut = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonCenter = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonPan = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonSelect = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonSelectRectangle = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonSelectRadius = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonSelectPolygon = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonAddPoint = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonAddLine = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonAddPolyline = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButtonAddPolygon = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapControl1 = new MapInfo.Windows.Controls.MapControl();
            this.toolStripTinhToanDenBu = new System.Windows.Forms.ToolStrip();
            this.toolStripHienThiBanDo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTinhToanDenBu = new System.Windows.Forms.ToolStripButton();
            this.toolStripTinhDienTich = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageLopBanDo.SuspendLayout();
            this.tabPageThongTindenBu.SuspendLayout();
            this.toolStripTinhToanDenBu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mapToolBar);
            this.splitContainer1.Panel2.Controls.Add(this.mapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(697, 516);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLopBanDo);
            this.tabControl1.Controls.Add(this.tabPageThongTindenBu);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(193, 516);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageLopBanDo
            // 
            this.tabPageLopBanDo.Controls.Add(this.lyrControl);
            this.tabPageLopBanDo.Location = new System.Drawing.Point(4, 22);
            this.tabPageLopBanDo.Name = "tabPageLopBanDo";
            this.tabPageLopBanDo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLopBanDo.Size = new System.Drawing.Size(185, 490);
            this.tabPageLopBanDo.TabIndex = 0;
            this.tabPageLopBanDo.Text = "Lớp bản đồ";
            this.tabPageLopBanDo.UseVisualStyleBackColor = true;
            // 
            // lyrControl
            // 
            this.lyrControl.AllowDragAndDrop = true;
            this.lyrControl.AllowRenaming = true;
            this.lyrControl.AutomaticLabelRemoval = MapInfo.Windows.Controls.LayerControl.LabelRemoval.Prompt;
            this.lyrControl.CheckBoxes = false;
            this.lyrControl.ConfirmLayerRemoval = true;
            this.lyrControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lyrControl.EditNameAfterInsertingLayer = true;
            this.lyrControl.FeatureLayerImageType = MapInfo.Windows.Controls.LayerControl.ImageType.Sample;
            this.lyrControl.ItemHeight = 20;
            this.lyrControl.Location = new System.Drawing.Point(3, 3);
            this.lyrControl.Map = null;
            this.lyrControl.Name = "lyrControl";
            this.lyrControl.OriginalMap = null;
            this.lyrControl.PointSampleMaximumPointSize = 18;
            this.lyrControl.SelectedObject = null;
            this.lyrControl.SelectedTab = MapInfo.Windows.Controls.PropertiesCategory.Custom;
            this.lyrControl.ShowContextMenu = true;
            this.lyrControl.ShowMapNode = true;
            this.lyrControl.Size = new System.Drawing.Size(179, 484);
            this.lyrControl.TabIndex = 0;
            this.lyrControl.Tools = null;
            this.lyrControl.UpdateWhenCollectionChanges = true;
            this.lyrControl.UpdateWhenMapViewChanges = true;
            this.lyrControl.UpdateWhenNameChanges = true;
            // 
            // tabPageThongTindenBu
            // 
            this.tabPageThongTindenBu.Controls.Add(this.cmdChiTiet);
            this.tabPageThongTindenBu.Controls.Add(this.cmdTinh);
            this.tabPageThongTindenBu.Controls.Add(this.txtTongGiaTriTien);
            this.tabPageThongTindenBu.Controls.Add(this.label3);
            this.tabPageThongTindenBu.Controls.Add(this.txtGiaTriTienTrenM2);
            this.tabPageThongTindenBu.Controls.Add(this.label2);
            this.tabPageThongTindenBu.Controls.Add(this.txtTongDienTich);
            this.tabPageThongTindenBu.Controls.Add(this.label1);
            this.tabPageThongTindenBu.Location = new System.Drawing.Point(4, 22);
            this.tabPageThongTindenBu.Name = "tabPageThongTindenBu";
            this.tabPageThongTindenBu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageThongTindenBu.Size = new System.Drawing.Size(185, 490);
            this.tabPageThongTindenBu.TabIndex = 1;
            this.tabPageThongTindenBu.Text = "Thông tin đền bù";
            this.tabPageThongTindenBu.UseVisualStyleBackColor = true;
            // 
            // cmdChiTiet
            // 
            this.cmdChiTiet.Location = new System.Drawing.Point(6, 161);
            this.cmdChiTiet.Name = "cmdChiTiet";
            this.cmdChiTiet.Size = new System.Drawing.Size(173, 24);
            this.cmdChiTiet.TabIndex = 7;
            this.cmdChiTiet.Text = "Hiển thị chi tiết";
            this.cmdChiTiet.UseVisualStyleBackColor = true;
            this.cmdChiTiet.Click += new System.EventHandler(this.cmdChiTiet_Click);
            // 
            // cmdTinh
            // 
            this.cmdTinh.Location = new System.Drawing.Point(6, 135);
            this.cmdTinh.Name = "cmdTinh";
            this.cmdTinh.Size = new System.Drawing.Size(173, 24);
            this.cmdTinh.TabIndex = 6;
            this.cmdTinh.Text = "Tính";
            this.cmdTinh.UseVisualStyleBackColor = true;
            this.cmdTinh.Click += new System.EventHandler(this.cmdTinh_Click);
            // 
            // txtTongGiaTriTien
            // 
            this.txtTongGiaTriTien.Enabled = false;
            this.txtTongGiaTriTien.Location = new System.Drawing.Point(3, 109);
            this.txtTongGiaTriTien.Name = "txtTongGiaTriTien";
            this.txtTongGiaTriTien.Size = new System.Drawing.Size(177, 20);
            this.txtTongGiaTriTien.TabIndex = 5;
            this.txtTongGiaTriTien.Text = "0";
            this.txtTongGiaTriTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tổng giá trị (VNĐ)";
            // 
            // txtGiaTriTienTrenM2
            // 
            this.txtGiaTriTienTrenM2.Location = new System.Drawing.Point(3, 70);
            this.txtGiaTriTienTrenM2.Name = "txtGiaTriTienTrenM2";
            this.txtGiaTriTienTrenM2.Size = new System.Drawing.Size(177, 20);
            this.txtGiaTriTienTrenM2.TabIndex = 3;
            this.txtGiaTriTienTrenM2.Text = "0";
            this.txtGiaTriTienTrenM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giá trị(VNĐ/m2)";
            // 
            // txtTongDienTich
            // 
            this.txtTongDienTich.Enabled = false;
            this.txtTongDienTich.Location = new System.Drawing.Point(4, 31);
            this.txtTongDienTich.Name = "txtTongDienTich";
            this.txtTongDienTich.Size = new System.Drawing.Size(177, 20);
            this.txtTongDienTich.TabIndex = 1;
            this.txtTongDienTich.Text = "0";
            this.txtTongDienTich.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng diện tích (m2)";
            // 
            // mapToolBar
            // 
            this.mapToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.mapToolBarButtonArrow,
            this.mapToolBarButtonZoomIn,
            this.mapToolBarButtonZoomOut,
            this.mapToolBarButtonCenter,
            this.mapToolBarButtonPan,
            this.mapToolBarButtonSelect,
            this.mapToolBarButtonSelectRectangle,
            this.mapToolBarButtonSelectRadius,
            this.mapToolBarButtonSelectPolygon,
            this.mapToolBarButtonAddPoint,
            this.mapToolBarButtonAddLine,
            this.mapToolBarButtonAddPolyline,
            this.mapToolBarButtonAddPolygon});
            this.mapToolBar.DropDownArrows = true;
            this.mapToolBar.Location = new System.Drawing.Point(0, 0);
            this.mapToolBar.MapControl = this.mapControl1;
            this.mapToolBar.Name = "mapToolBar";
            this.mapToolBar.ShowToolTips = true;
            this.mapToolBar.Size = new System.Drawing.Size(500, 28);
            this.mapToolBar.TabIndex = 1;
            // 
            // mapToolBarButtonArrow
            // 
            this.mapToolBarButtonArrow.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Arrow;
            this.mapToolBarButtonArrow.Name = "mapToolBarButtonArrow";
            this.mapToolBarButtonArrow.ToolTipText = "Arrow";
            // 
            // mapToolBarButtonZoomIn
            // 
            this.mapToolBarButtonZoomIn.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.ZoomIn;
            this.mapToolBarButtonZoomIn.Name = "mapToolBarButtonZoomIn";
            this.mapToolBarButtonZoomIn.ToolTipText = "Zoom-in";
            // 
            // mapToolBarButtonZoomOut
            // 
            this.mapToolBarButtonZoomOut.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.ZoomOut;
            this.mapToolBarButtonZoomOut.Name = "mapToolBarButtonZoomOut";
            this.mapToolBarButtonZoomOut.ToolTipText = "Zoom-out";
            // 
            // mapToolBarButtonCenter
            // 
            this.mapToolBarButtonCenter.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Center;
            this.mapToolBarButtonCenter.Name = "mapToolBarButtonCenter";
            this.mapToolBarButtonCenter.ToolTipText = "Center";
            // 
            // mapToolBarButtonPan
            // 
            this.mapToolBarButtonPan.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Pan;
            this.mapToolBarButtonPan.Name = "mapToolBarButtonPan";
            this.mapToolBarButtonPan.ToolTipText = "Pan";
            // 
            // mapToolBarButtonSelect
            // 
            this.mapToolBarButtonSelect.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Select;
            this.mapToolBarButtonSelect.Name = "mapToolBarButtonSelect";
            this.mapToolBarButtonSelect.ToolTipText = "Select";
            // 
            // mapToolBarButtonSelectRectangle
            // 
            this.mapToolBarButtonSelectRectangle.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectRectangle;
            this.mapToolBarButtonSelectRectangle.Name = "mapToolBarButtonSelectRectangle";
            this.mapToolBarButtonSelectRectangle.ToolTipText = "Marquee Select";
            // 
            // mapToolBarButtonSelectRadius
            // 
            this.mapToolBarButtonSelectRadius.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectRadius;
            this.mapToolBarButtonSelectRadius.Name = "mapToolBarButtonSelectRadius";
            this.mapToolBarButtonSelectRadius.ToolTipText = "Radius Select";
            // 
            // mapToolBarButtonSelectPolygon
            // 
            this.mapToolBarButtonSelectPolygon.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectPolygon;
            this.mapToolBarButtonSelectPolygon.Name = "mapToolBarButtonSelectPolygon";
            this.mapToolBarButtonSelectPolygon.ToolTipText = "Polygon Select";
            // 
            // mapToolBarButtonAddPoint
            // 
            this.mapToolBarButtonAddPoint.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.AddPoint;
            this.mapToolBarButtonAddPoint.Name = "mapToolBarButtonAddPoint";
            this.mapToolBarButtonAddPoint.ToolTipText = "Add Point";
            // 
            // mapToolBarButtonAddLine
            // 
            this.mapToolBarButtonAddLine.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.AddLine;
            this.mapToolBarButtonAddLine.Name = "mapToolBarButtonAddLine";
            this.mapToolBarButtonAddLine.ToolTipText = "Add Line";
            // 
            // mapToolBarButtonAddPolyline
            // 
            this.mapToolBarButtonAddPolyline.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.AddPolyline;
            this.mapToolBarButtonAddPolyline.Name = "mapToolBarButtonAddPolyline";
            this.mapToolBarButtonAddPolyline.ToolTipText = "Add Polyline";
            // 
            // mapToolBarButtonAddPolygon
            // 
            this.mapToolBarButtonAddPolygon.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.AddPolygon;
            this.mapToolBarButtonAddPolygon.Name = "mapToolBarButtonAddPolygon";
            this.mapToolBarButtonAddPolygon.ToolTipText = "Add Polygon";
            // 
            // mapControl1
            // 
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.IgnoreLostFocusEvent = false;
            this.mapControl1.Location = new System.Drawing.Point(0, 0);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(500, 516);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.Tools.LeftButtonTool = null;
            this.mapControl1.Tools.MiddleButtonTool = null;
            this.mapControl1.Tools.RightButtonTool = null;
            // 
            // toolStripTinhToanDenBu
            // 
            this.toolStripTinhToanDenBu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripHienThiBanDo,
            this.toolStripButtonTinhToanDenBu,
            this.toolStripTinhDienTich});
            this.toolStripTinhToanDenBu.Location = new System.Drawing.Point(0, 0);
            this.toolStripTinhToanDenBu.Name = "toolStripTinhToanDenBu";
            this.toolStripTinhToanDenBu.Size = new System.Drawing.Size(697, 25);
            this.toolStripTinhToanDenBu.TabIndex = 1;
            this.toolStripTinhToanDenBu.Text = "toolStrip1";
            // 
            // toolStripHienThiBanDo
            // 
            this.toolStripHienThiBanDo.Image = global::DMC.Land.TinhToanDenBu.Properties.Resources.LopBanDo;
            this.toolStripHienThiBanDo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripHienThiBanDo.Name = "toolStripHienThiBanDo";
            this.toolStripHienThiBanDo.Size = new System.Drawing.Size(99, 22);
            this.toolStripHienThiBanDo.Text = "Hiển thị bản đồ";
            this.toolStripHienThiBanDo.Click += new System.EventHandler(this.toolStripHienThiBanDo_Click);
            // 
            // toolStripButtonTinhToanDenBu
            // 
            this.toolStripButtonTinhToanDenBu.Image = global::DMC.Land.TinhToanDenBu.Properties.Resources.thm_individual;
            this.toolStripButtonTinhToanDenBu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTinhToanDenBu.Name = "toolStripButtonTinhToanDenBu";
            this.toolStripButtonTinhToanDenBu.Size = new System.Drawing.Size(150, 22);
            this.toolStripButtonTinhToanDenBu.Text = "Lấy phần diện tích đền bù";
            this.toolStripButtonTinhToanDenBu.Click += new System.EventHandler(this.toolStripButtonTinhToanDenBu_Click);
            // 
            // toolStripTinhDienTich
            // 
            this.toolStripTinhDienTich.Image = global::DMC.Land.TinhToanDenBu.Properties.Resources.Buff;
            this.toolStripTinhDienTich.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTinhDienTich.Name = "toolStripTinhDienTich";
            this.toolStripTinhDienTich.Size = new System.Drawing.Size(153, 22);
            this.toolStripTinhDienTich.Text = "Tính diện tích phần đền bù";
            this.toolStripTinhDienTich.Click += new System.EventHandler(this.toolStripTinhDienTich_Click);
            // 
            // ctrlTinhToanDenBu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.toolStripTinhToanDenBu);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ctrlTinhToanDenBu";
            this.Size = new System.Drawing.Size(697, 544);
            this.Load += new System.EventHandler(this.ctrlTinhToanDenBu_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageLopBanDo.ResumeLayout(false);
            this.tabPageThongTindenBu.ResumeLayout(false);
            this.tabPageThongTindenBu.PerformLayout();
            this.toolStripTinhToanDenBu.ResumeLayout(false);
            this.toolStripTinhToanDenBu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLopBanDo;
        private System.Windows.Forms.TabPage tabPageThongTindenBu;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonArrow;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonZoomIn;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonZoomOut;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonCenter;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonPan;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonSelect;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonSelectRectangle;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonSelectRadius;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonSelectPolygon;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonAddPoint;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonAddLine;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonAddPolyline;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButtonAddPolygon;
        public MapInfo.Windows.Controls.LayerControl lyrControl;
        public MapInfo.Windows.Controls.MapControl mapControl1;
        public MapInfo.Windows.Controls.MapToolBar mapToolBar;
        private System.Windows.Forms.ToolStrip toolStripTinhToanDenBu;
        private System.Windows.Forms.ToolStripButton toolStripHienThiBanDo;
        private System.Windows.Forms.ToolStripButton toolStripButtonTinhToanDenBu;
        private System.Windows.Forms.ToolStripButton toolStripTinhDienTich;
        private System.Windows.Forms.Button cmdChiTiet;
        private System.Windows.Forms.Button cmdTinh;
        private System.Windows.Forms.TextBox txtTongGiaTriTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGiaTriTienTrenM2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongDienTich;
        private System.Windows.Forms.Label label1;
    }
}
