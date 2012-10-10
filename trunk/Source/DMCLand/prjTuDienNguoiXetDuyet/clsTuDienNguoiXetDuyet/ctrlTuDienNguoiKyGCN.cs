using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMC.Land.TuDienCanBoNghiepVu
{
    public partial class ctrlTuDienNguoiKyGCN : UserControl
    {
        public ctrlTuDienNguoiKyGCN()
        {
            InitializeComponent();
        }
        /* Khai báo biến nhận chuỗi kết nối */
        private string  strConnection = "";
        /* Khai báo biến kiểm tra lỗi */
        private string strError = "";
        /* Mã người ký GCN */
        private string strMa = "";
        /* Khai báo biến xác định kiểu thao tác cơ sở dữ liệu */
        private short shortAction = 0;
        /* Khai báo đối tượng kiểu Datatable nhận dữ liệu từ bảng Từ điển
         người ký GCN */
        private DataTable dtTuDienNguoiKyGCN = new DataTable();

        public DataTable  dtTuDienNguoiKyGCNSelect = new DataTable ();
        /* Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu */
        public string Connection
        {
            set { strConnection = value; }
        }
        public string Ma
        {
            set { strMa = value;}
            get { return strMa; }
        }


        public void  UpdateData()
        {
            /* Khai báo và khởi tạo đối tượng Từ điển người ký GCN */
            DMC.Land.TuDienCanBoNhiepVu.clsTuDienCanBoNghiepVu TuDienNguoiKyGCN =  new DMC.Land.TuDienCanBoNhiepVu.clsTuDienCanBoNghiepVu();
            try
            {
                /* Gán giá trị cho các thuộc tính */
                TuDienNguoiKyGCN.Conneciton  = strConnection ;
                TuDienNguoiKyGCN.Ma = strMa;
                TuDienNguoiKyGCN.ChucDanh = txtChucDanh.Text.Trim();
                TuDienNguoiKyGCN.ChucVu  = txtChucVu.Text.Trim();
                TuDienNguoiKyGCN.HoTen = txtHoTen.Text.Trim() ;
                if (cmbGioiTinh.Text.Trim() == "Nam")
                {
                    TuDienNguoiKyGCN.GioiTinh = "True";
                }
                else
                {
                    TuDienNguoiKyGCN.GioiTinh = "False";
                }

                string strResults = "";
                string  str = "";

                if (shortAction == 0)
                {
                    strResults = TuDienNguoiKyGCN.SelectTuDienCanBoKyGCN (ref dtTuDienNguoiKyGCN);
                }
                else if (shortAction == 1 )
                {
                    strResults =  TuDienNguoiKyGCN.InsertTuDienCanBoKyGCN(ref str);
                }
                else if ( shortAction == 2)
                {
                    strResults =  TuDienNguoiKyGCN.UpdateTuDienCanBoKyGCN(ref str );
                }
                else if (shortAction == 3 )
                {
                    strResults =  TuDienNguoiKyGCN.DeleteTuDienCanBoKyGCN(ref str);
                }

                /* Nếu cập nhật thành công */
                if ( strResults  == "")
                {
                    //TrangThaiBanDau();
                    shortAction = 0;
                }
                strError = TuDienNguoiKyGCN.Error ;
            }
            catch ( Exception ex)
            {
                strError = ex.Message ;
                System.Windows.Forms.MessageBox.Show (" Lỗi cập nhật dữ liệu từ điển người xét duyệt ", "DMCLand",MessageBoxButtons.OK);
            }
        }

        /* Hiển thị dữ liệu lên Grid */
        public void showData()
        {
            try
            {
                /* Thiết lập trạng thái ban đầu cho các điều khiển */
                this.TrangThaiBanDau();
                /* Khởi tạo đối tượng dtTuDienNguoiXetDuyet */
                dtTuDienNguoiKyGCN = new DataTable();
                /* Khởi tạo từ điển người ký GCN */
                DMC.Land.TuDienCanBoNhiepVu.clsTuDienCanBoNghiepVu TuDienNguoiKyGCN = new DMC.Land.TuDienCanBoNhiepVu.clsTuDienCanBoNghiepVu();
                /* Nhận giá trị cho chuỗi kết nối cơ sở dữ liệu */
                TuDienNguoiKyGCN.Conneciton = strConnection;
                /* Gán giá trị cho tham số cần truy vấn */
                TuDienNguoiKyGCN.Ma = "";
                TuDienNguoiKyGCN.GioiTinh = "";
                TuDienNguoiKyGCN.HoTen = "";
                TuDienNguoiKyGCN.ChucDanh = "";
                TuDienNguoiKyGCN.ChucVu = "";
                /* Gọi phương thức getData. Nếu nhận dữ liệu thành công thì hiển thị lên Grid */
                if (TuDienNguoiKyGCN.SelectTuDienCanBoKyGCN(ref  dtTuDienNguoiKyGCN) == "")
                {
                    /* Hiển thị dữ liệu lên Grid */
                    this.grdvwTuDien.DataSource = dtTuDienNguoiKyGCN;
                    if (dtTuDienNguoiKyGCN.Rows.Count > 0)
                    {
                        /* Thiết đặt giao diện hiển thị Grid */
                        this.FormatGridContruction();
                    }
                    else
                    {
                        this.HideAllColumns(ref grdvwTuDien);
                    }
                    ctrFilterGrid1.MyGrid = grdvwTuDien;
                    ctrFilterGrid1.MydataTable =dtTuDienNguoiKyGCN;
                    ctrFilterGrid1.TaoContol();
                }
            }
            catch (Exception ex)
            {
                strError = "";
                strError = ex.ToString();
                MessageBox.Show(" Hiển thị dữ liệu Từ điển người ký GCN " + System.Environment.NewLine +
                    "Lỗi: " + System.Environment.NewLine + ex.ToString(), "DMCLand");
            }
            /* Thiết lập trạng thái chức năng cho các điểu khiển */
            this.TrangThaiChucNang(false, false);
            /* Thiết lập trạng thái không cập nhật cho các điều khiển */
            this.TrangThaiCapNhat(false);
        }
        /// <summary>
        /// Ẩn tất cả các cột trên Grid
        /// </summary>
        /// <param name="grdvw"></param>
        private void  HideAllColumns(ref  DMC.Interface.GridView.ctrlGridView  grdvw)
        {
        //Ẩn tất cả các cột trên Grid
            for (int  i = 0; i <  grdvw.Columns.Count; i++)
            {
                grdvw.Columns[i].Visible  = false;
            }
                grdvw.RowHeadersVisible = false;
        }

        /* Thiết đặt hiển thị DataGridView */
        private void FormatGridContruction()
        {
            try
            {
                /* Ẩn tất cả các cột trên Grid */
                this.HideAllColumns(ref  grdvwTuDien);

                /* Chỉ hiển thị những cột cần thiết */
                this.grdvwTuDien.Columns["GioiTinh"].Width  = 100;
                this.grdvwTuDien.Columns["GioiTinh"].HeaderText = "Giới tính (Nam)";
                this.grdvwTuDien.Columns["GioiTinh"].ReadOnly = true;
                this.grdvwTuDien.Columns["GioiTinh"].Visible  = true;
                this.grdvwTuDien.Columns["GioiTinh"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdvwTuDien.Columns["HoTen"].Width = 200;
                this.grdvwTuDien.Columns["HoTen"].HeaderText = "Họ tên";
                this.grdvwTuDien.Columns["HoTen"].ReadOnly = true;
                this.grdvwTuDien.Columns["HoTen"].Visible  = true;
                this.grdvwTuDien.Columns["HoTen"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdvwTuDien.Columns["ChucDanh"].Width = 200;
                this.grdvwTuDien.Columns["ChucDanh"].HeaderText = "Chức danh";
                this.grdvwTuDien.Columns["ChucDanh"].ReadOnly = true;
                this.grdvwTuDien.Columns["ChucDanh"].Visible  = true;
                this.grdvwTuDien.Columns["ChucDanh"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdvwTuDien.Columns["ChucVu"].Width = 200;
                this.grdvwTuDien.Columns["ChucVu"].HeaderText = "Chức vụ";
                this.grdvwTuDien.Columns["ChucVu"].ReadOnly = true;
                this.grdvwTuDien.Columns["ChucVu"].Visible = true;
                this.grdvwTuDien.Columns["ChucVu"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdvwTuDien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.grdvwTuDien.RowHeadersVisible = false;
                this.grdvwTuDien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.grdvwTuDien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                /* Khong cho phep them */
                this.grdvwTuDien.AllowUserToAddRows = false;
                /* Khong cho phep xoa */
                this.grdvwTuDien.AllowUserToDeleteRows = false;
                /* Khong lua chon bat ky dong nao luc ban dau */
                this.grdvwTuDien.ClearSelection();

            }
            catch (Exception ex)
            {
                strError = "";
                strError = ex.ToString();
                MessageBox.Show(" Thiết đặt hiển thị Từ điển người ký GCN " + System.Environment.NewLine +
                    "Lỗi: " + System.Environment.NewLine + ex.ToString(), "DMCLand");
            }

        }


        ///* Gán những bản ghi đã được lựa chọn vào đối tượng dtNguoiXetDuyetLuaChon */
        ///// <summary>
        ///// Cần xem lại phương thức này
        ///// Note: Hiện tai phường thức này tạm thời chưa dùng đến
        ///// </summary>
        ///// <returns></returns>
        //private  DataTable  selectedRecords()
        //{
        //    /* Làm sạch dữ liệu */
        //    DataTable  dtNguoiXetDuyetLuaChon = new DataTable();
        //    dtNguoiXetDuyetLuaChon.Rows.Clear();
        //    /* Add Tên các cột tương ứng vào bảng Những người xét duyệt được lựa chọn */
        //    dtNguoiXetDuyetLuaChonAddColumns(ref  dtNguoiXetDuyetLuaChon) ;
        //    try
        //    {
        //        int intCounter = this.grdvwTuDienNguoiXetDuyet.Rows.Count;
        //        if (intCounter  > 0)
        //        {
        //            int i = 0;
        //            for (i = 0; i < intCounter; i++)
        //            {
        //                if (this.grdvwTuDienNguoiXetDuyet.Rows[i].Cells["columnChon"].Value  != null )
        //                {
        //                    if (this.grdvwTuDienNguoiXetDuyet.Rows[i].Cells["columnChon"].Value.ToString() == "True")
        //                    {
        //                        dtNguoiXetDuyetLuaChon.Rows.Add(dtTuDienNguoiXetDuyet.Rows[i].ItemArray);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = "";
        //        strError = ex.ToString();
        //        MessageBox.Show(" Lựa chọn dữ liệu Từ điển người xét duyệt " + System.Environment.NewLine +
        //            "Lỗi: " + System.Environment.NewLine + ex.ToString(), "DMCLand");
        //    }
        //    return dtNguoiXetDuyetLuaChon;
        //}
        ///* Add TÊN các cột tương ứng từ các cột bên bảng dtTuDienNguoiXetDuyet 
        // sang bảng dtNguoiXetDuyetLuaChon */
        ///// <summary>
        ///// Cần xem lại phương thức này
        ///// Note: Hiện tại phương thức này chưa dùng đến
        ///// </summary>
        ///// <param name="dtNguoiXetDuyetLuaChon"></param>
        //private void dtNguoiXetDuyetLuaChonAddColumns(ref DataTable dtNguoiXetDuyetLuaChon )
        //{
        //    int intColumnCounter = this.grdvwTuDienNguoiXetDuyet.ColumnCount-1;
        //    int intCounter = 0;
        //    string strColumnName;
        //    if (intColumnCounter > 0)
        //    {
        //        for (intCounter = 0; intCounter < intColumnCounter; intCounter++)
        //        {
        //            strColumnName = dtTuDienNguoiXetDuyet.Columns[intCounter].ColumnName.ToString();
        //            dtNguoiXetDuyetLuaChon.Columns.Add(strColumnName);
        //        }
        //    }
        //}
        ///* Lựa chọn tất cả các bản ghi trên Grid */
        ///// <summary>
        ///// Cần xem lại phương thức này
        ///// Note: Hiện tại phương thức này chưa dùng đến
        ///// </summary>
        ///// <param name="blnSelectAll"></param>
        //private  void selectAll(Boolean blnSelectAll)
        //{
        //    try
        //    {
        //        int intCounter;
        //        intCounter = this.grdvwTuDienNguoiXetDuyet.Rows.Count;
        //        if (intCounter > 0)
        //        {
        //            int i = 0;
        //            if (blnSelectAll == false)
        //            {
        //                for (i = 0; i < intCounter; i++)
        //                {
        //                    this.grdvwTuDienNguoiXetDuyet.Rows[i].Cells["columnChon"].Value = false ;
        //                }
        //            }
        //            else 
        //            {
        //                for (i = 0; i < intCounter; i++)
        //                {
        //                    this.grdvwTuDienNguoiXetDuyet.Rows[i].Cells["columnChon"].Value = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.ToString();
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void btnThem_Click(object sender, EventArgs e)
        {
        strMa = "";
        shortAction = 1;
        /* Thiết lập các điều khiển về trạng thái ban đầu */
        this.TrangThaiBanDau();
        /* Thiết lập các điều khiển về trạng thái cập nhật */
        this.TrangThaiCapNhat(true);
        /* Thiết lập trạng thái thêm mới cho các điều khiển cập nhật */
        this.TrangThaiChucNang(true,false);
        }


    public void  TrangThaiCapNhat(bool  blnCapNhat)
    {
            /* Thiết đặt trạng thái các điều khiển theo trạng thái cập nhật dữ liệu */
            this.grdvwTuDien.BackgroundColor = Color.White;
            this.cmbGioiTinh.Enabled = blnCapNhat ;
            this.txtChucDanh.ReadOnly = !blnCapNhat;
            this.txtChucVu.ReadOnly = !blnCapNhat;            
            this.txtHoTen.ReadOnly = !blnCapNhat;
            //Thiết đặt màu nền cho các điều khiển
            if (blnCapNhat)
            {
                this.txtChucDanh.BackColor  = Color.White ;
                this.txtChucVu.BackColor = Color.White;
                this.txtHoTen.BackColor  = Color.White ;
            }
            else
            {
                this.txtChucDanh.BackColor = Color.LightYellow;
                this.txtChucVu.BackColor = Color.LightYellow;
                this.txtHoTen.BackColor  = Color.LightYellow;
            }
    }

        public void  TrangThaiBanDau()
        {
            //Ẩn tất cả các cột
            //if (boolClearGrid)
            //{
            //    this.HideAllColumns(ref grdvwTuDienNguoiXetDuyet);
            //}
            this.cmbGioiTinh.Text = "";
            this.txtChucDanh.Text = "";
            this.txtHoTen.Text = "";
        }

        public void  TrangThaiChucNang(bool  blnStartEdited , bool   blnStartDeleted)
        {
            
            this.btnSua.Enabled = !blnStartEdited;
            this.btnXoa.Enabled = !blnStartEdited;
            this.btnThem.Enabled = !blnStartEdited;
            this.btnCapNhat.Enabled = blnStartEdited;
            //this.btnHuyLenh.Enabled = blnStartEdited
            if (blnStartDeleted)
            {
                this.btnCapNhat.Enabled = !blnStartDeleted;
                this.btnHuyLenh.Enabled = !blnStartDeleted;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (strMa != "" )
            {
                shortAction = 2;
                /* Trạng thái chức năng */
                this.TrangThaiChucNang(true,false);
                /* Trạng thái cập nhật */
                this.TrangThaiCapNhat(true);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show (this, " Bạn phải chọn Người ký GCN cần sửa thông tin!", "DMCLand",MessageBoxButtons.OK );
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            /* Nếu tồn tại mã cần xóa */
            if (strMa != "" )
            {
                if (System.Windows.Forms.MessageBox.Show ("Bạn chắc chắn muốn xóa không?","DMCLand",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        shortAction  = 3;
                        this.UpdateData();
                        strMa = "";
                        /* Trang thai ban dau */
                        this.TrangThaiBanDau();
                        /* Hien thi du lieu */
                        this.showData();
                        /* Trang thai chuc nang */
                        this.TrangThaiChucNang(false,false );
                    }
                    catch ( Exception ex)
                    {
                        strError = ex.Message;
                    }
                    if (strError == "") 
                        System.Windows.Forms.MessageBox.Show(this, " Bạn đã cập nhật thành công!","DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Information );
                    else
                        System.Windows.Forms.MessageBox.Show (this, " Cập nhật chưa thành công!", "DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Information );
                }
                else
                {
                    /* Trang thai chuc nang */
                    this.TrangThaiChucNang(false , false );
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show (this," Bạn phải chọn Người ký GCN cần xóa!", "DMCLand",MessageBoxButtons.OK ,MessageBoxIcon.Information);
            }
            /* Trạng thái cập nhật */
            this.TrangThaiCapNhat(false );
            strError = "";
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show (this,"Bạn phải nhập Họ tên người ký GCN!", "DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtHoTen.Focus();
                return ;
            }
            /* Cập nhật thông tin người ký GCN */
            this.UpdateData();
            /* Hiển thị lại dữ liệu */
            this.showData();
            /* Trang thai chuc nang */
            this.TrangThaiChucNang(false,false );
            /* Trang thai cap nhat */
            this.TrangThaiCapNhat(false );

            if (strError == "")
                System.Windows.Forms.MessageBox.Show(this, " Bạn đã cập nhật thành công!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                System.Windows.Forms.MessageBox.Show(this, " Cập nhật chưa thành công!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /* Khoi tao gia tri cho bien dung chung */
            strMa = "";
            strError = "";
        }

        //private void btnSelectAll_Click(object sender, EventArgs e)
        //{
        //    this.selectAll(true);
        //}

        //private void btnUnSelect_Click(object sender, EventArgs e)
        //{
        //    this.selectAll(false);
        //}

        //private void btnOK_Click(object sender, EventArgs e)
        //{
        //    this.selectedRecords();
        //}

        private void ctrlTuDienNguoiXetDuyet_Load(object sender, EventArgs e)
        {
            try
            {
                /* Trạng thái cập nhật */
                this.TrangThaiCapNhat(false );
                /* Trạng thái chức năng */
                this.TrangThaiChucNang(false,false);
            }
            catch ( Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(this, " Nạp dữ liệu ban đầu " + System.Environment.NewLine + " Từ điển người ký GCN " +
                " Lỗi: " + strError, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grdvwTuDien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /* Khong cho click chuot phai */
            if (e.Button.ToString() == "Right")
                return ;
            
            /* Khoi tao doi tuong clsTimKiem */
            DMC.Land.TuDienCanBoNhiepVu.clsTuDienCanBoNghiepVu TuDienNguoiKyGCN = new DMC.Land.TuDienCanBoNhiepVu.clsTuDienCanBoNghiepVu();
            if ( e.RowIndex >= 0)
            {
                try
                {
                    /*  Gan gia tri cho cac thuoc tinh doi voi truong hop truy van */
                    /* Cập nhật dữ liệu tương Ứng khi click chuột vào thuộc tính  
                    lớp Từ điển người xét duyệt */
                    int RowID = Convert.ToInt16(grdvwTuDien.CurrentRow.Cells["STT"].Value) - 1;
                    TuDienNguoiKyGCN.Ma = dtTuDienNguoiKyGCN.Rows[RowID]["Ma"].ToString();
                    strMa = dtTuDienNguoiKyGCN.Rows[RowID]["Ma"].ToString();
                    TuDienNguoiKyGCN.ChucDanh = dtTuDienNguoiKyGCN.Rows[RowID]["ChucDanh"].ToString();
                    TuDienNguoiKyGCN.ChucVu = dtTuDienNguoiKyGCN.Rows[RowID]["ChucVu"].ToString();
                    TuDienNguoiKyGCN.HoTen = dtTuDienNguoiKyGCN.Rows[RowID]["HoTen"].ToString();
                    if (dtTuDienNguoiKyGCN.Rows[RowID]["GioiTinh"].ToString() == "True")
                        TuDienNguoiKyGCN.GioiTinh = "1";
                    else if (dtTuDienNguoiKyGCN.Rows[RowID]["GioiTinh"].ToString() == "False")
                        TuDienNguoiKyGCN.GioiTinh = "0";
                    else /* if  (dtTuDienNguoiXetDuyet.Rows[e.RowIndex]["GioiTinh"] == null ) */
                        TuDienNguoiKyGCN.GioiTinh = "";

                    /* Hiển thị dữ liệu tương ứng lên Form */
                    
                        /* Chức danh */
                        this.txtChucDanh.Text = TuDienNguoiKyGCN.ChucDanh.ToString();
                        /* Chức vụ */
                        this.txtChucVu.Text = TuDienNguoiKyGCN.ChucVu.ToString();
                        /* Họ tên */
                        this.txtHoTen.Text = TuDienNguoiKyGCN.HoTen.ToString(); 
                        /* Giới tính */
                        if (TuDienNguoiKyGCN.GioiTinh == "1")
                            this.cmbGioiTinh.Text = "Nam";
                        else if (TuDienNguoiKyGCN.GioiTinh == "0")
                            this.cmbGioiTinh.Text = "Nữ";
                        else 
                            this.cmbGioiTinh.Text = "";
                }
                catch ( Exception ex)
                {
                    strError = ex.Message;
                    System.Windows.Forms.MessageBox.Show (this," Hiển thị dữ liệu lên Form " + System.Environment.NewLine  + "Từ điển người ký GCN" +
                           System.Environment.NewLine  + " Lỗi: " + ex.Message,"DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

        private void btnHuyLenh_Click(object sender, EventArgs e)
        {
            /* Hiển thị dữ liệu */
            if (strMa != "" )
                this.showData();
            /* Xóa dữ liệu trên Form */
            this.TrangThaiBanDau();
            /* Khởi tạo giá trị ban đầu cho biến dùng chung */
            strMa = "";
            /* Trạng thái chức năng */
            this.TrangThaiChucNang(false, false);
            /* Trạng thái cập nhật */
            this.TrangThaiCapNhat(false);
            shortAction = 0;
        }

        private void grdvwTuDien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    /* Xác định Mã người ký GCN */
                    int RowID = Convert.ToInt16(grdvwTuDien.CurrentRow.Cells["STT"].Value) - 1;
                    strMa = dtTuDienNguoiKyGCN.Rows[RowID]["Ma"].ToString();
                    /* Khởi tạo đối tượng DataTable chứa bản ghi (Thông tin Chủ sử dụng) được lựa chọn */
                    dtTuDienNguoiKyGCNSelect  = new DataTable();
                    /* Copy định dạng của đối tượng dtChuSuDungTCDN vào đối 
                     tượng DataTable chứa bản ghi (Thông tin Chủ sử dụng) được lựa chọn */
                    dtTuDienNguoiKyGCNSelect  = dtTuDienNguoiKyGCN.Clone();
                    /* Add bản những Người ký GCN được lựa chọn vào biến kiểu DataTable dùng chung */
                    dtTuDienNguoiKyGCNSelect.ImportRow(dtTuDienNguoiKyGCN.Rows[RowID]);
                    /* Ẩn Form tra cứu thông tin Chủ sử dụng */
                    /* NOTE: CẦN VIẾT SỰ KIỆN ẨN FORM TRA CỨU Ở ĐÂY */
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi: " + ex.Message, "DMCLand",MessageBoxButtons.OK ,MessageBoxIcon.Warning );
            }
        }

        private void cmbGioiTinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtHoTen.Focus();
            }
        }

        private void txtHoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtChucDanh.Focus();
            }
        }

        private void txtChucDanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtChucVu.Focus();
            }
        }

        private void txtChucVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnCapNhat.Focus();
            }
        }

        private void grdvwTuDien_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                ctrFilterGrid1.TaoContol();
            }
            catch (Exception ex) { }
        }
    }
}
