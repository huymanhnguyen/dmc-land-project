namespace prjXemLichSuThuaDat
{
    partial class ctrLichSuBienDong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mapToolBar1 = new MapInfo.Windows.Controls.MapToolBar();
            this.mapToolBarButton1 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton2 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton3 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton4 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapControl1 = new MapInfo.Windows.Controls.MapControl();
            this.cmdPhucHoi = new System.Windows.Forms.Button();
            this.cmdHoSo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lyrControl = new MapInfo.Windows.Controls.LayerControl();
            this.mapToolBarButton5 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.mapToolBarButton6 = new MapInfo.Windows.Controls.MapToolBarButton();
            this.grdLSBienDong = new DMC.Interface.GridView.ctrlGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLSBienDong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.grdLSBienDong);
            this.groupBox1.Location = new System.Drawing.Point(3, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lịch sử biến động";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.mapToolBar1);
            this.groupBox2.Controls.Add(this.mapControl1);
            this.groupBox2.Location = new System.Drawing.Point(285, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(667, 559);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hình dạng thửa";
            // 
            // mapToolBar1
            // 
            this.mapToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.mapToolBarButton1,
            this.mapToolBarButton2,
            this.mapToolBarButton3,
            this.mapToolBarButton4,
            this.mapToolBarButton5,
            this.mapToolBarButton6});
            this.mapToolBar1.DropDownArrows = true;
            this.mapToolBar1.Location = new System.Drawing.Point(3, 16);
            this.mapToolBar1.MapControl = this.mapControl1;
            this.mapToolBar1.Name = "mapToolBar1";
            this.mapToolBar1.ShowToolTips = true;
            this.mapToolBar1.Size = new System.Drawing.Size(661, 28);
            this.mapToolBar1.TabIndex = 1;
            // 
            // mapToolBarButton1
            // 
            this.mapToolBarButton1.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Select;
            this.mapToolBarButton1.Name = "mapToolBarButton1";
            this.mapToolBarButton1.ToolTipText = "Select";
            // 
            // mapToolBarButton2
            // 
            this.mapToolBarButton2.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.ZoomIn;
            this.mapToolBarButton2.Name = "mapToolBarButton2";
            this.mapToolBarButton2.ToolTipText = "Zoom-in";
            // 
            // mapToolBarButton3
            // 
            this.mapToolBarButton3.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.ZoomOut;
            this.mapToolBarButton3.Name = "mapToolBarButton3";
            this.mapToolBarButton3.ToolTipText = "Zoom-out";
            // 
            // mapToolBarButton4
            // 
            this.mapToolBarButton4.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.Pan;
            this.mapToolBarButton4.Name = "mapToolBarButton4";
            this.mapToolBarButton4.ToolTipText = "Pan";
            // 
            // mapControl1
            // 
            this.mapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mapControl1.IgnoreLostFocusEvent = false;
            this.mapControl1.Location = new System.Drawing.Point(6, 50);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(655, 503);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.Text = "mapControl1";
            this.mapControl1.Tools.LeftButtonTool = null;
            this.mapControl1.Tools.MiddleButtonTool = null;
            this.mapControl1.Tools.RightButtonTool = null;
            // 
            // cmdPhucHoi
            // 
            this.cmdPhucHoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPhucHoi.Location = new System.Drawing.Point(204, 539);
            this.cmdPhucHoi.Name = "cmdPhucHoi";
            this.cmdPhucHoi.Size = new System.Drawing.Size(75, 23);
            this.cmdPhucHoi.TabIndex = 2;
            this.cmdPhucHoi.Text = "Phục hồi";
            this.cmdPhucHoi.UseVisualStyleBackColor = true;
            // 
            // cmdHoSo
            // 
            this.cmdHoSo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdHoSo.Location = new System.Drawing.Point(123, 539);
            this.cmdHoSo.Name = "cmdHoSo";
            this.cmdHoSo.Size = new System.Drawing.Size(75, 23);
            this.cmdHoSo.TabIndex = 3;
            this.cmdHoSo.Text = "Hồ sơ";
            this.cmdHoSo.UseVisualStyleBackColor = true;
            this.cmdHoSo.Click += new System.EventHandler(this.cmdHoSo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lyrControl);
            this.groupBox3.Location = new System.Drawing.Point(3, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 324);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // lyrControl
            // 
            this.lyrControl.AllowDragAndDrop = true;
            this.lyrControl.AllowRenaming = true;
            this.lyrControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lyrControl.AutomaticLabelRemoval = MapInfo.Windows.Controls.LayerControl.LabelRemoval.Prompt;
            this.lyrControl.CheckBoxes = false;
            this.lyrControl.ConfirmLayerRemoval = true;
            this.lyrControl.EditNameAfterInsertingLayer = true;
            this.lyrControl.FeatureLayerImageType = MapInfo.Windows.Controls.LayerControl.ImageType.Sample;
            this.lyrControl.ItemHeight = 20;
            this.lyrControl.Location = new System.Drawing.Point(4, 12);
            this.lyrControl.Map = null;
            this.lyrControl.Name = "lyrControl";
            this.lyrControl.OriginalMap = null;
            this.lyrControl.PointSampleMaximumPointSize = 18;
            this.lyrControl.SelectedObject = null;
            this.lyrControl.SelectedTab = MapInfo.Windows.Controls.PropertiesCategory.Custom;
            this.lyrControl.ShowContextMenu = true;
            this.lyrControl.ShowMapNode = true;
            this.lyrControl.Size = new System.Drawing.Size(272, 545);
            this.lyrControl.TabIndex = 2;
            this.lyrControl.Tools = null;
            this.lyrControl.UpdateWhenCollectionChanges = true;
            this.lyrControl.UpdateWhenMapViewChanges = true;
            this.lyrControl.UpdateWhenNameChanges = true;
            // 
            // mapToolBarButton5
            // 
            this.mapToolBarButton5.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectPolygon;
            this.mapToolBarButton5.Name = "mapToolBarButton5";
            this.mapToolBarButton5.ToolTipText = "Polygon Select";
            // 
            // mapToolBarButton6
            // 
            this.mapToolBarButton6.ButtonType = MapInfo.Windows.Controls.MapToolButtonType.SelectRectangle;
            this.mapToolBarButton6.Name = "mapToolBarButton6";
            this.mapToolBarButton6.ToolTipText = "Marquee Select";
            // 
            // grdLSBienDong
            // 
            this.grdLSBienDong.AllowUserToAddRows = false;
            this.grdLSBienDong.AllowUserToDeleteRows = false;
            this.grdLSBienDong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLSBienDong.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLSBienDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLSBienDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdLSBienDong.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdLSBienDong.Location = new System.Drawing.Point(6, 19);
            this.grdLSBienDong.Name = "grdLSBienDong";
            this.grdLSBienDong.ReadOnly = true;
            this.grdLSBienDong.RowHeadersWidth = 25;
            this.grdLSBienDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLSBienDong.Size = new System.Drawing.Size(264, 169);
            this.grdLSBienDong.TabIndex = 0;
            this.grdLSBienDong.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdLSBienDong_CellMouseClick);
            // 
            // ctrLichSuBienDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmdHoSo);
            this.Controls.Add(this.cmdPhucHoi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrLichSuBienDong";
            this.Size = new System.Drawing.Size(955, 574);
            this.Load += new System.EventHandler(this.ctrLichSuBienDong_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLSBienDong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DMC.Interface.GridView.ctrlGridView grdLSBienDong;
        private MapInfo.Windows.Controls.MapControl mapControl1;
        private System.Windows.Forms.Button cmdPhucHoi;
        private MapInfo.Windows.Controls.MapToolBar mapToolBar1;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton1;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton2;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton3;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton4;
        private System.Windows.Forms.Button cmdHoSo;
        private System.Windows.Forms.GroupBox groupBox3;
        public MapInfo.Windows.Controls.LayerControl lyrControl;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton5;
        private MapInfo.Windows.Controls.MapToolBarButton mapToolBarButton6;
    }
}
