using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjThietLapThongTinGCN
{
    public partial class ctrlTuDienTieuDeKyGCN : UserControl
    {
        public ctrlTuDienTieuDeKyGCN()
        {
            InitializeComponent();
        }
        /* Khai báo biến nhận chuỗi kết nối */
        private string strConnection = "";
        /* Khai báo biến kiểm tra lỗi */
        private string strError = "";
        /* Mã Tiêu đề ký GCN */
        private string strMa = "";
        /* Khai báo biến xác định kiểu thao tác cơ sở dữ liệu */
        private short shortAction = 0;
        /* Khai báo đối tượng kiểu Datatable nhận dữ liệu từ bảng Từ điển
         tiêu đề ký GCN */
        private DataTable dtTuDienTieuDeKyGCN = new DataTable();

        public DataTable dtTuDienTieuDeKyGCNSelect = new DataTable();
        /* Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu */
        public string Connection
        {
            set { strConnection = value; }
        }
        public string Ma
        {
            set { strMa = value; }
            get { return strMa; }
        }


        public void UpdateData()
        {
            /* Khai báo và khởi tạo đối tượng Từ điển tiêu đề ký GCN */
            clsThietLapThongTinGCN TieuDeKyGCN = new clsThietLapThongTinGCN();
            try
            {
                /* Gán giá trị cho các thuộc tính */
                TieuDeKyGCN.Conneciton = strConnection;
                TieuDeKyGCN.Ma = strMa;
                TieuDeKyGCN.MoTa = txtMoTa.Text.Trim();
                TieuDeKyGCN.TieuDeKyGCN = txtTieuDeKyGCN.Text.Trim();
                string strResults = "";
                string str = "";

                if (shortAction == 0)
                {
                    strResults = TieuDeKyGCN.SelectTuDienTieuDeKyGCN (ref dtTuDienTieuDeKyGCN);
                }
                else if (shortAction == 1)
                {
                    strResults = TieuDeKyGCN.InsertTuDienTieuDeKyGCN(ref str);
                }
                else if (shortAction == 2)
                {
                    strResults = TieuDeKyGCN.UpdateTuDienTieuDeKyGCN(ref str);
                }
                else if (shortAction == 3)
                {
                    strResults = TieuDeKyGCN.DeleteTuDienTieuDeKyGCN(ref str);
                }

                /* Nếu cập nhật thành công */
                if (strResults == "")
                {
                    //TrangThaiBanDau();
                    shortAction = 0;
                }
                strError = TieuDeKyGCN.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(" Cập nhật dữ liệu " + System.Environment.NewLine + " Từ điển Tiêu đề ký GCN " + " Lỗi: " + ex.Message.ToString(), "DMCLand", MessageBoxButtons.OK);
            }
        }

        /* Hiển thị dữ liệu lên Grid */
        public void showData()
        {
            try
            {
                /* Thiết lập trạng thái ban đầu cho các điều khiển */
                this.TrangThaiBanDau();
                /* Khởi tạo đối tượng dtTuDienTieuDeKyGCN */
                dtTuDienTieuDeKyGCN = new DataTable();
                /* Khởi tạo từ điển Tiêu đề ký GCN */
                clsThietLapThongTinGCN TuDienTieuDeKyGCN = new clsThietLapThongTinGCN();
                /* Nhận giá trị cho chuỗi kết nối cơ sở dữ liệu */
                TuDienTieuDeKyGCN.Conneciton = strConnection;
                /* Gán giá trị cho tham số cần truy vấn */
                TuDienTieuDeKyGCN.Ma = "";
                TuDienTieuDeKyGCN.TieuDeKyGCN = "";
                TuDienTieuDeKyGCN.MoTa = "";
                /* Gọi phương thức getData. Nếu nhận dữ liệu thành công thì hiển thị lên Grid */
                if (TuDienTieuDeKyGCN.SelectTuDienTieuDeKyGCN(ref  dtTuDienTieuDeKyGCN) == "")
                {
                    /* Hiển thị dữ liệu lên Grid */
                    this.grdvwTuDien.DataSource = dtTuDienTieuDeKyGCN;
                    if (dtTuDienTieuDeKyGCN.Rows.Count > 0)
                    {
                        /* Thiết đặt giao diện hiển thị Grid */
                        this.FormatGridContruction();
                    }
                    else
                    {
                        this.HideAllColumns(ref grdvwTuDien);
                    }
                }
            }
            catch (Exception ex)
            {
                strError = "";
                strError = ex.ToString();
                MessageBox.Show(" Hiển thị dữ liệu Từ điển Tiêu đề ký GCN " + System.Environment.NewLine +
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
        private void HideAllColumns(ref  DMC.Interface.GridView.ctrlGridView grdvw)
        {
            //Ẩn tất cả các cột trên Grid
            for (int i = 0; i < grdvw.Columns.Count; i++)
            {
                grdvw.Columns[i].Visible = false;
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
                this.grdvwTuDien.Columns["TieuDeKyGCN"].Width = 400;
                this.grdvwTuDien.Columns["TieuDeKyGCN"].HeaderText = "Tiêu đề ký GCN";
                this.grdvwTuDien.Columns["TieuDeKyGCN"].ReadOnly = true;
                this.grdvwTuDien.Columns["TieuDeKyGCN"].Visible = true;
                this.grdvwTuDien.Columns["TieuDeKyGCN"].SortMode = DataGridViewColumnSortMode.NotSortable;

                this.grdvwTuDien.Columns["MoTa"].Width = 200;
                this.grdvwTuDien.Columns["MoTa"].HeaderText = "Mô tả";
                this.grdvwTuDien.Columns["MoTa"].ReadOnly = true;
                this.grdvwTuDien.Columns["MoTa"].Visible = true;
                this.grdvwTuDien.Columns["MoTa"].SortMode = DataGridViewColumnSortMode.NotSortable;

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
                MessageBox.Show(" Thiết đặt hiển thị Từ điển Tiêu đề ký GCN " + System.Environment.NewLine +
                    "Lỗi: " + System.Environment.NewLine + ex.ToString(), "DMCLand");
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            strMa = "";
            shortAction = 1;
            /* Thiết lập các điều khiển về trạng thái ban đầu */
            this.TrangThaiBanDau();
            /* Thiết lập các điều khiển về trạng thái cập nhật */
            this.TrangThaiCapNhat(true);
            /* Thiết lập trạng thái thêm mới cho các điều khiển cập nhật */
            this.TrangThaiChucNang(true, false);
        }


        public void TrangThaiCapNhat(bool blnCapNhat)
        {
            /* Thiết đặt trạng thái các điều khiển theo trạng thái cập nhật dữ liệu */
            this.grdvwTuDien.BackgroundColor = Color.White;
            this.txtTieuDeKyGCN.ReadOnly = !blnCapNhat;
            this.txtMoTa.ReadOnly = !blnCapNhat;
            //Thiết đặt màu nền cho các điều khiển
            if (blnCapNhat)
            {
                this.txtTieuDeKyGCN.BackColor = Color.White;
                this.txtMoTa.BackColor = Color.White;
            }
            else
            {
                this.txtTieuDeKyGCN.BackColor = Color.LightYellow;
                this.txtMoTa.BackColor = Color.LightYellow;
            }
        }

        public void TrangThaiBanDau()
        {
            //Ẩn tất cả các cột
            //if (boolClearGrid)
            //{
            //    this.HideAllColumns(ref grdvwTuDienNguoiXetDuyet);
            //}
            this.txtTieuDeKyGCN.Text = "";
            this.txtMoTa.Text = "";
        }

        public void TrangThaiChucNang(bool blnStartEdited, bool blnStartDeleted)
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
            if (strMa != "")
            {
                shortAction = 2;
                /* Trạng thái chức năng */
                this.TrangThaiChucNang(true, false);
                /* Trạng thái cập nhật */
                this.TrangThaiCapNhat(true);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(this, " Bạn phải chọn Tiêu đề ký GCN cần sửa thông tin!", "DMCLand", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            /* Nếu tồn tại mã cần xóa */
            if (strMa != "")
            {
                if (System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn xóa không?", "DMCLand", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        shortAction = 3;
                        this.UpdateData();
                        strMa = "";
                        /* Trang thai ban dau */
                        this.TrangThaiBanDau();
                        /* Hien thi du lieu */
                        this.showData();
                        /* Trang thai chuc nang */
                        this.TrangThaiChucNang(false, false);
                    }
                    catch (Exception ex)
                    {
                        strError = ex.Message;
                    }
                    if (strError == "")
                        System.Windows.Forms.MessageBox.Show(this, " Bạn đã cập nhật thành công!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        System.Windows.Forms.MessageBox.Show(this, " Cập nhật chưa thành công!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    /* Trang thai chuc nang */
                    this.TrangThaiChucNang(false, false);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(this, " Bạn phải chọn Tiêu đề ký GCN cần xóa!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /* Trạng thái cập nhật */
            this.TrangThaiCapNhat(false);
            strError = "";
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTieuDeKyGCN.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show(this, "Bạn phải nhập Tiêu đề ký GCN!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTieuDeKyGCN.Focus();
                return;
            }
            /* Cập nhật thông tin Tiêu đề ký GCN */
            this.UpdateData();
            /* Hiển thị lại dữ liệu */
            this.showData();
            /* Trang thai chuc nang */
            this.TrangThaiChucNang(false, false);
            /* Trang thai cap nhat */
            this.TrangThaiCapNhat(false);

            if (strError == "")
                System.Windows.Forms.MessageBox.Show(this, " Bạn đã cập nhật thành công!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                System.Windows.Forms.MessageBox.Show(this, " Cập nhật chưa thành công!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /* Khoi tao gia tri cho bien dung chung */
            strMa = "";
            strError = "";
        }

        private void ctrlTuDienTieuDeKyGCN_Load(object sender, EventArgs e)
        {
            try
            {
                /* Trạng thái cập nhật */
                this.TrangThaiCapNhat(false);
                /* Trạng thái chức năng */
                this.TrangThaiChucNang(false, false);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(this, " Nạp dữ liệu ban đầu " + System.Environment.NewLine + " Từ điển Tiêu đề ký GCN " +
                " Lỗi: " + strError, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grdvwTuDien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /* Không cho click chuột phải */
            if (e.Button.ToString() == "Right")
                return;

            /* Khởi tạo đối tượng */
            clsThietLapThongTinGCN  TieuDeKyGCN = new clsThietLapThongTinGCN();
            if (e.RowIndex >= 0)
            {
                try
                {
                    /*  Gan gia tri cho cac thuoc tinh doi voi truong hop truy van */
                    /* Cập nhật dữ liệu tương Ứng khi click chuột vào thuộc tính  
                    lớp Từ điển Tiêu đề ký GCN */
                    TieuDeKyGCN.Ma = dtTuDienTieuDeKyGCN.Rows[e.RowIndex]["Ma"].ToString();
                    strMa = dtTuDienTieuDeKyGCN.Rows[e.RowIndex]["Ma"].ToString();
                    TieuDeKyGCN.TieuDeKyGCN = dtTuDienTieuDeKyGCN.Rows[e.RowIndex]["TieuDeKyGCN"].ToString();
                    TieuDeKyGCN.MoTa = dtTuDienTieuDeKyGCN.Rows[e.RowIndex]["MoTa"].ToString();
                    /* Hiển thị dữ liệu tương ứng lên Form */
                    /* Tiêu đề ký GCN */
                    this.txtTieuDeKyGCN.Text = TieuDeKyGCN.TieuDeKyGCN.ToString();
                    /* Mô tả */
                    this.txtMoTa.Text = TieuDeKyGCN.MoTa.ToString();
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    System.Windows.Forms.MessageBox.Show(this, " Hiển thị dữ liệu lên Form " + System.Environment.NewLine + "Từ điển Tiêu đề ký GCN" +
                           System.Environment.NewLine + " Lỗi: " + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnHuyLenh_Click(object sender, EventArgs e)
        {
            /* Hiển thị dữ liệu */
            if (strMa != "")
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
                    /* Xác định Mã Tiêu đề ký GCN */
                    strMa = dtTuDienTieuDeKyGCN.Rows[e.RowIndex]["Ma"].ToString();
                    /* Khởi tạo đối tượng DataTable chứa bản ghi (Thông tin Tiêu đề ký GCN) được lựa chọn */
                    dtTuDienTieuDeKyGCNSelect = new DataTable();
                    /* Copy định dạng của đối tượng dtTuDienTieuDeKyGCN vào đối 
                     tượng DataTable chứa bản ghi (Thông tin Tiêu đề ký GCN) được lựa chọn */
                    dtTuDienTieuDeKyGCNSelect = dtTuDienTieuDeKyGCN.Clone();
                    /* Add bản những Tiêu đề ký GCN được lựa chọn vào biến kiểu DataTable dùng chung */
                    dtTuDienTieuDeKyGCNSelect.ImportRow(dtTuDienTieuDeKyGCN.Rows[e.RowIndex]);
                    /* Ẩn Form tra cứu thông tin Tiêu đề ký GCN */
                    /* NOTE: CẦN VIẾT SỰ KIỆN ẨN FORM TRA CỨU Ở ĐÂY */
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, "Lỗi: " + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
