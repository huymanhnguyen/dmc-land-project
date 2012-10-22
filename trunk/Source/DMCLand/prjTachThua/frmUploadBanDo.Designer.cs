namespace DMC.Land.TachThua
{
    partial class frmUploadBanDo
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusToaDoX = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusToaDoY = new System.Windows.Forms.ToolStripStatusLabel();
            this.StaProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lyrControl = new MapInfo.Windows.Controls.LayerControl();
            this.mapToolBar1 = new MapInfo.Windows.Controls.MapToolBar();
            this.mapToolBarButton10 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton2 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton3 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton4 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton5 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton6 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton7 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton8 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton9 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapControl1 = new MapInfo.Windows.Controls.MapControl();
            this.radBanDoQuan = new System.Windows.Forms.RadioButton();
            this.radBanDoPhuong = new System.Windows.Forms.RadioButton();
            this.cboLoaiBanDo = new System.Windows.Forms.ComboBox();
            this.cmdLuu = new System.Windows.Forms.Button();
            this.cmdHienTHi = new System.Windows.Forms.Button();
            this.cmdXoaBanDo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Location = new System.Drawing.Point(2, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(827, 449);
            this.panel2.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusZoom,
            this.StatusToaDoX,
            this.StatusToaDoY,
            this.StaProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(827, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusZoom
            // 
            this.StatusZoom.AutoSize = false;
            this.StatusZoom.Name = "StatusZoom";
            this.StatusZoom.Size = new System.Drawing.Size(150, 17);
            this.StatusZoom.Text = "...";
            // 
            // StatusToaDoX
            // 
            this.StatusToaDoX.AutoSize = false;
            this.StatusToaDoX.Name = "StatusToaDoX";
            this.StatusToaDoX.Size = new System.Drawing.Size(150, 17);
            this.StatusToaDoX.Text = "...";
            // 
            // StatusToaDoY
            // 
            this.StatusToaDoY.AutoSize = false;
            this.StatusToaDoY.Name = "StatusToaDoY";
            this.StatusToaDoY.Size = new System.Drawing.Size(109, 17);
            this.StatusToaDoY.Text = "...";
            // 
            // StaProgressBar
            // 
            this.StaProgressBar.AutoSize = false;
            this.StaProgressBar.Name = "StaProgressBar";
            this.StaProgressBar.Size = new System.Drawing.Size(300, 16);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lyrControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mapToolBar1);
            this.splitContainer1.Panel2.Controls.Add(this.mapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(827, 421);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 2;
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
            this.lyrControl.Location = new System.Drawing.Point(0, 0);
            this.lyrControl.Map = null;
            this.lyrControl.Name = "lyrControl";
            this.lyrControl.OriginalMap = null;
            this.lyrControl.PointSampleMaximumPointSize = 18;
            this.lyrControl.SelectedObject = null;
            this.lyrControl.SelectedTab = MapInfo.Windows.Controls.PropertiesCategory.Custom;
            this.lyrControl.ShowContextMenu = true;
            this.lyrControl.ShowMapNode = true;
            this.lyrControl.Size = new System.Drawing.Size(162, 421);
            this.lyrControl.TabIndex = 2;
            this.lyrControl.Tools = null;
            this.lyrControl.UpdateWhenCollectionChanges = true;
            this.lyrControl.UpdateWhenMapViewChanges = true;
            this.lyrControl.UpdateWhenNameChanges = true;
            // 
            // mapToolBar1
            // 
            this.mapToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.mapToolBarButton10,
            this.mapToolBarButton2,
            this.mapToolBarButton3,
            this.mapToolBarButton4,
            this.mapToolBarButton5,
            this.mapToolBarButton6,
            this.mapToolBarButton7,
            this.mapToolBarButton8,
            this.mapToolBarButton9});
            this.mapToolBar1.DropDownArrows = true;
            this.mapToolBar1.Location = new System.Drawing.Point(0, 0);
            this.mapToolBar1.MapControl = this.mapControl1;
            this.mapToolBar1.Name = "mapToolBar1";
            this.mapToolBar1.ShowToolTips = true;
            this.mapToolBar1.Size = new System.Drawing.Size(661, 28);
            this.mapToolBar1.TabIndex = 1;
            // 
            // mapToolBarButton10
            // 
            this.mapToolBarButton10.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.OpenTable;
            this.mapToolBarButton10.Name = "mapToolBarButton10";
            this.mapToolBarButton10.ToolTipText = "Open Table";
            // 
            // mapToolBarButton2
            // 
            this.mapToolBarButton2.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectRectangle;
            this.mapToolBarButton2.Name = "mapToolBarButton2";
            this.mapToolBarButton2.ToolTipText = "Marquee Select";
            // 
            // mapToolBarButton3
            // 
            this.mapToolBarButton3.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectRadius;
            this.mapToolBarButton3.Name = "mapToolBarButton3";
            this.mapToolBarButton3.ToolTipText = "Radius Select";
            // 
            // mapToolBarButton4
            // 
            this.mapToolBarButton4.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectPolygon;
            this.mapToolBarButton4.Name = "mapToolBarButton4";
            this.mapToolBarButton4.ToolTipText = "Polygon Select";
            // 
            // mapToolBarButton5
            // 
            this.mapToolBarButton5.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectRegion;
            this.mapToolBarButton5.Name = "mapToolBarButton5";
            this.mapToolBarButton5.ToolTipText = "Region Select";
            // 
            // mapToolBarButton6
            // 
            this.mapToolBarButton6.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.ZoomIn;
            this.mapToolBarButton6.Name = "mapToolBarButton6";
            this.mapToolBarButton6.ToolTipText = "Zoom-in";
            // 
            // mapToolBarButton7
            // 
            this.mapToolBarButton7.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.ZoomOut;
            this.mapToolBarButton7.Name = "mapToolBarButton7";
            this.mapToolBarButton7.ToolTipText = "Zoom-out";
            // 
            // mapToolBarButton8
            // 
            this.mapToolBarButton8.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Pan;
            this.mapToolBarButton8.Name = "mapToolBarButton8";
            this.mapToolBarButton8.ToolTipText = "Pan";
            // 
            // mapToolBarButton9
            // 
            this.mapToolBarButton9.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Select;
            this.mapToolBarButton9.Name = "mapToolBarButton9";
            this.mapToolBarButton9.ToolTipText = "Select";
            // 
            // mapControl1
            // 
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.IgnoreLostFocusEvent = false;
            this.mapControl1.Location = new System.Drawing.Point(0, 0);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(661, 421);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.Tools.LeftButtonTool = null;
            this.mapControl1.Tools.MiddleButtonTool = null;
            this.mapControl1.Tools.RightButtonTool = null;
            // 
            // radBanDoQuan
            // 
            this.radBanDoQuan.AutoSize = true;
            this.radBanDoQuan.Location = new System.Drawing.Point(84, 9);
            this.radBanDoQuan.Name = "radBanDoQuan";
            this.radBanDoQuan.Size = new System.Drawing.Size(87, 17);
            this.radBanDoQuan.TabIndex = 0;
            this.radBanDoQuan.Text = "Bản đồ quận";
            this.radBanDoQuan.UseVisualStyleBackColor = true;
            this.radBanDoQuan.CheckedChanged += new System.EventHandler(this.radBanDoQuan_CheckedChanged);
            // 
            // radBanDoPhuong
            // 
            this.radBanDoPhuong.AutoSize = true;
            this.radBanDoPhuong.Checked = true;
            this.radBanDoPhuong.Location = new System.Drawing.Point(187, 9);
            this.radBanDoPhuong.Name = "radBanDoPhuong";
            this.radBanDoPhuong.Size = new System.Drawing.Size(99, 17);
            this.radBanDoPhuong.TabIndex = 1;
            this.radBanDoPhuong.TabStop = true;
            this.radBanDoPhuong.Text = "Bản đồ phường";
            this.radBanDoPhuong.UseVisualStyleBackColor = true;
            this.radBanDoPhuong.CheckedChanged += new System.EventHandler(this.radBanDoPhuong_CheckedChanged);
            // 
            // cboLoaiBanDo
            // 
            this.cboLoaiBanDo.FormattingEnabled = true;
            this.cboLoaiBanDo.Location = new System.Drawing.Point(84, 32);
            this.cboLoaiBanDo.Name = "cboLoaiBanDo";
            this.cboLoaiBanDo.Size = new System.Drawing.Size(201, 21);
            this.cboLoaiBanDo.TabIndex = 2;
            // 
            // cmdLuu
            // 
            this.cmdLuu.Location = new System.Drawing.Point(297, 32);
            this.cmdLuu.Name = "cmdLuu";
            this.cmdLuu.Size = new System.Drawing.Size(65, 24);
            this.cmdLuu.TabIndex = 3;
            this.cmdLuu.Text = "Lưu";
            this.cmdLuu.UseVisualStyleBackColor = true;
            this.cmdLuu.Click += new System.EventHandler(this.cmdLuu_Click);
            // 
            // cmdHienTHi
            // 
            this.cmdHienTHi.Location = new System.Drawing.Point(368, 33);
            this.cmdHienTHi.Name = "cmdHienTHi";
            this.cmdHienTHi.Size = new System.Drawing.Size(65, 23);
            this.cmdHienTHi.TabIndex = 4;
            this.cmdHienTHi.Text = "Hiển thị";
            this.cmdHienTHi.UseVisualStyleBackColor = true;
            this.cmdHienTHi.Click += new System.EventHandler(this.cmdHienTHi_Click);
            // 
            // cmdXoaBanDo
            // 
            this.cmdXoaBanDo.Location = new System.Drawing.Point(439, 32);
            this.cmdXoaBanDo.Name = "cmdXoaBanDo";
            this.cmdXoaBanDo.Size = new System.Drawing.Size(66, 24);
            this.cmdXoaBanDo.TabIndex = 5;
            this.cmdXoaBanDo.Text = "Xóa";
            this.cmdXoaBanDo.UseVisualStyleBackColor = true;
            this.cmdXoaBanDo.Click += new System.EventHandler(this.cmdXoaBanDo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tên bản đồ";
            // 
            // frmUploadBanDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(830, 507);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdXoaBanDo);
            this.Controls.Add(this.cmdHienTHi);
            this.Controls.Add(this.cmdLuu);
            this.Controls.Add(this.cboLoaiBanDo);
            this.Controls.Add(this.radBanDoPhuong);
            this.Controls.Add(this.radBanDoQuan);
            this.Controls.Add(this.panel2);
            this.Name = "frmUploadBanDo";
            this.Text = "frmUploadBanDo";
            this.Load += new System.EventHandler(this.frmUploadBanDo_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusZoom;
        private System.Windows.Forms.ToolStripStatusLabel StatusToaDoX;
        private System.Windows.Forms.ToolStripStatusLabel StatusToaDoY;
        private System.Windows.Forms.ToolStripProgressBar StaProgressBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public MapInfo.Windows.Controls.LayerControl lyrControl;
        private MapInfo.Windows.Controls.MapToolBar mapToolBar1;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton10;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton2;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton3;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton4;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton5;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton6;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton7;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton8;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton9;
        public MapInfo.Windows.Controls.MapControl mapControl1;
        private System.Windows.Forms.RadioButton radBanDoQuan;
        private System.Windows.Forms.RadioButton radBanDoPhuong;
        private System.Windows.Forms.ComboBox cboLoaiBanDo;
        private System.Windows.Forms.Button cmdLuu;
        private System.Windows.Forms.Button cmdHienTHi;
        private System.Windows.Forms.Button cmdXoaBanDo;
        private System.Windows.Forms.Label label1;
    }
}