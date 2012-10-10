using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMC.Land.BienDong.DangKy;
using DMC.Land.DangKyBienDong;
using System.Xml;

namespace prjBienDong
{
    public partial class ctrlDangKyBienDong : UserControl 
    {
        public ctrlDangKyBienDong ()
        {
            InitializeComponent();
        }
        string strNoiDungBienDongCu = "";
            DataTable dtDangKyBienDong = new DataTable();
            DataTable dtDangKyBienDongSelect = new DataTable();
            //Khai báo biến nhận chuỗi kết nối Database
            private string strConnection = ""; 
            /* Khai báo biến nhận thông báo lỗi */
            private string strError = ""; 
            /* Khai báo biến nhận Mã hồ sơ cấp GCN */
            private string strMaHoSoCapGCN = "";
            private short shortAction = 0;
            /* Khai báo biến Mã đăng ký biến động */
            private string strMaDangKyBienDong = "";
            private string strMaThuaDat = "";
            private string strTenPhuong = "";
            private string strNhom="";
            private Int32 MaDKBienDong = 0;
            public Int32 MaBD
            {
                get { return MaDKBienDong; }
                set { MaDKBienDong = value; }
             }
            public string Nhom
            {
                get { return strNhom; }
                set { strNhom = value; }
            }
         private string  MaLoaiBienDong  = "";
         public string   MaKhoa
            { get {return MaLoaiBienDong ;}
                set { MaLoaiBienDong = value; }
            }
      
            public string TenPhuong
            {
                get { return strTenPhuong; }
                set { strTenPhuong = value; }
            }
            private string strTenDonViHanhChinh = "";

            public string TenDonViHanhChinh
            {
                get { return strTenDonViHanhChinh; }
                set { strTenDonViHanhChinh = value; }
            }
            public string MaThuaDat
            {
                get { return strMaThuaDat; }
                set { strMaThuaDat = value; }
            }
            private string strkyhieu = "";
            public string KyHieu
            {
                set
                {
                    strkyhieu = value;
                }
                get { return strkyhieu; }
            }
        // Khai bao thuoc tinh Flag
            private string strFlag = "";

          
            public string Flag
            {
                get
                {
                    return strFlag;
                }
                set
                {
                    strFlag = value;
                }

            }
            //Khai báo thuộc tính nhận chuỗi kết nối Database
            public string  Connection
            {
                set 
                {
                    strConnection = value;
                }
            }
            public string  MaHoSoCapGCN
            {
                set 
                {
                    strMaHoSoCapGCN = value;
                }
            }

            private string strMaDonViHanhChinh = "";

            public string MaDonViHanhChinh
            {
                get { return strMaDonViHanhChinh; }
                set { strMaDonViHanhChinh = value; }
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
                    this.HideAllColumns(ref  grdvwDangKyBienDong);

                    /* Chỉ hiển thị những cột cần thiết */

                    this.grdvwDangKyBienDong.Columns["Chon"].Width=50;
                    this.grdvwDangKyBienDong.Columns["Chon"].HeaderText = "Chon";
                    this.grdvwDangKyBienDong.Columns["Chon"].ReadOnly = true;
                    this.grdvwDangKyBienDong.Columns["Chon"].Visible = true;
                    this.grdvwDangKyBienDong.Columns["Chon"].DisplayIndex = 0;
                    this.grdvwDangKyBienDong.Columns["Chon"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    this.grdvwDangKyBienDong.Columns["MatInBienDong"].Width = 50;
                    this.grdvwDangKyBienDong.Columns["MatInBienDong"].HeaderText = "Mặt in";
                    this.grdvwDangKyBienDong.Columns["MatInBienDong"].ReadOnly = true;
                    this.grdvwDangKyBienDong.Columns["MatInBienDong"].Visible = true;
                    this.grdvwDangKyBienDong.Columns["MatInBienDong"].DisplayIndex = 0;
                    this.grdvwDangKyBienDong.Columns["MatInBienDong"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    this.grdvwDangKyBienDong.Columns["TenNguoiDangKy"].Width = 170;
                    this.grdvwDangKyBienDong.Columns["TenNguoiDangKy"].HeaderText = "Tên Người Đăng Ký";
                    this.grdvwDangKyBienDong.Columns["TenNguoiDangKy"].ReadOnly = true;
                    this.grdvwDangKyBienDong.Columns["TenNguoiDangKy"].Visible = true;
                    this.grdvwDangKyBienDong.Columns["TenNguoiDangKy"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    this.grdvwDangKyBienDong.Columns["DiaChiNguoiDangKy"].Width = 180;
                    this.grdvwDangKyBienDong.Columns["DiaChiNguoiDangKy"].HeaderText = "Địa Chỉ Người Đăng Ký";
                    this.grdvwDangKyBienDong.Columns["DiaChiNguoiDangKy"].ReadOnly = true;
                    this.grdvwDangKyBienDong.Columns["DiaChiNguoiDangKy"].Visible = true;
                    this.grdvwDangKyBienDong.Columns["DiaChiNguoiDangKy"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    this.grdvwDangKyBienDong.Columns["ThoiDiemDangKy"].Width = 120;
                    this.grdvwDangKyBienDong.Columns["ThoiDiemDangKy"].HeaderText = "Thời Điểm Đăng Ký";
                    this.grdvwDangKyBienDong.Columns["ThoiDiemDangKy"].ReadOnly = true;
                    this.grdvwDangKyBienDong.Columns["ThoiDiemDangKy"].Visible = true;
                    this.grdvwDangKyBienDong.Columns["ThoiDiemDangKy"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    this.grdvwDangKyBienDong.Columns["NoidungSoBienDong"].Width = 200;
                    this.grdvwDangKyBienDong.Columns["NoidungSoBienDong"].HeaderText = "Nội Dung Biến Động";
                    this.grdvwDangKyBienDong.Columns["NoidungSoBienDong"].ReadOnly = true;
                    this.grdvwDangKyBienDong.Columns["NoidungSoBienDong"].Visible = true;
                    this.grdvwDangKyBienDong.Columns["NoidungSoBienDong"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    this.grdvwDangKyBienDong.Columns["GhiChu"].Width = 200;
                    this.grdvwDangKyBienDong.Columns["GhiChu"].HeaderText = "Ghi chú";
                    this.grdvwDangKyBienDong.Columns["GhiChu"].ReadOnly = true;
                    this.grdvwDangKyBienDong.Columns["GhiChu"].Visible = true;
                    this.grdvwDangKyBienDong.Columns["GhiChu"].SortMode = DataGridViewColumnSortMode.NotSortable;


                    this.grdvwDangKyBienDong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    this.grdvwDangKyBienDong.RowHeadersVisible = false;
                    this.grdvwDangKyBienDong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.grdvwDangKyBienDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    /* Khong cho phep them */
                    this.grdvwDangKyBienDong.AllowUserToAddRows = false;
                    /*Khonh cho phep sap xep*/
                    this.grdvwDangKyBienDong.AllowUserToOrderColumns = false;
                    /* Khong cho phep xoa */
                    this.grdvwDangKyBienDong.AllowUserToDeleteRows = false;
                    /* Khong lua chon bat ky dong nao luc ban dau */
                    /*this.grdvwDangKyBienDong.ClearSelection();*/
                    

                }
                catch (Exception ex)
                {
                    strError = "";
                    strError = ex.ToString();
                    MessageBox.Show(" Thiết đặt hiển thị Từ điển người Biến Động " + System.Environment.NewLine +
                        "Lỗi: " + System.Environment.NewLine + ex.ToString(), "DMCLand");
                }

            }

            /* Hiển thị dữ liệu lên Grid */

            public void   ShowData()
            {
                //if (this.MaLoaiBienDong != "MG")
                //{
              this.groupBox3.Enabled = true ;

                //}
                //else {
                //    this.groupBox3.Enabled = false;
                //}
                try
                {
                    /* Khai báo và khởi tạo lớp đăng ký biến động */
                    clsDangKyBienDong DangKyBienDong = new clsDangKyBienDong();
                    /* Gán giá trị cho thuộc tính cần cho điều kiện truy vấn */
                    DangKyBienDong.Connection = strConnection;
                    DangKyBienDong.MaHoSoCapGCN = strMaHoSoCapGCN;
                    /* Khởi tạo giá trị cho biến Mã đăng ký biến động */
                    DangKyBienDong.MaDangKyBienDong = strMaDangKyBienDong;
                    /* Khởi tạo giá trị cho biến dtDangKyBienDong */
                    dtDangKyBienDong.Clear();
                    /* Xóa sạch thông tin lưu lại trên Form */
                    this.TrangThaiBanDau();

                    /* Gọi phương thức hiển thị dữ liệu . Nếu nhận dữ liệu thành công thì hiển thị lên Grid */
                    if (DangKyBienDong.SelectThongTinBienDong(ref dtDangKyBienDong) == "")
                    {
                        /* Hiển thị dữ liệu lên Grid */
                        this.grdvwDangKyBienDong.DataSource = dtDangKyBienDong;
                        if (dtDangKyBienDong.Rows.Count > 0)
                        {
                            /* Thiết đặt giao diện hiển thị Grid */
                            this.FormatGridContruction();
                        }
                        else
                        {
                            this.HideAllColumns(ref grdvwDangKyBienDong);
                           
                        }
                    }
                    CheckLoaiBienDong();
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    MessageBox.Show(this, " Đăng ký biến động " + System.Environment.NewLine + " Hiển thị dữ liệu " + " Lỗi: " + System.Environment.NewLine
                           + strError, "DMCLand", MessageBoxButtons.OK);
                }
                ///* Thiết lập trạng thái chức năng */
                // this.TrangThaiChucNang(false, false);
                ///* Thiết lập trạng thái cập nhật */
                // this.TrangThaiCapNhat(false);
            }
            public void NhatKyNguoiDung(string ChucNang, string MoTa)
            {
                prjNhatKyNguoiDung.clsNhatKyNguoiDung clsNhatky = new prjNhatKyNguoiDung.clsNhatKyNguoiDung();
                clsNhatky.Connection = strConnection;
                clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN;
                clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh;
                clsNhatky.NghiepVu = "Chức năng tạo mã vạch";
                clsNhatky.ChucNang = ChucNang;
                clsNhatky.MoTa = MoTa;
                clsNhatky.DuongDanFile = Application.StartupPath;
                clsNhatky.LuuNhatKyNguoiDung();
            }
            public void UpdateData()
            {
                /* Khai báo và khởi tạo lớp Đăng ký biến động */
                clsDangKyBienDong DangKyBienDong = new clsDangKyBienDong();
                /* trường hợp mã biến động không phải là thế chấp */
                try
                {
                    //Nhận chuỗi kết nối Database
                    DangKyBienDong.Connection = strConnection;
                    DangKyBienDong.Flag = strFlag;
                    if (strMaHoSoCapGCN != null)
                    {
                        if (strMaHoSoCapGCN != "")
                        {
                            DangKyBienDong.MaHoSoCapGCN = strMaHoSoCapGCN;
                            DangKyBienDong.MaThuaDat = strMaThuaDat;
                        }
                        else
                        {
                            MessageBox.Show(this, " Lỗi cập nhật đăng ký biến động " + System.Environment.NewLine, "DMCLand", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, " Lỗi cập nhật đăng ký biến động " + System.Environment.NewLine, "DMCLand", MessageBoxButtons.OK);
                        return;
                    }


                    //truong hop chuyen nhuong
                    if (cboLoaiBienDong.SelectedValue.ToString().ToUpper()  == "CN" )
                    {
                        DangKyBienDong.LoaiBienDong = "CN";
                        DangKyBienDong.DienTich = numDienTich.Value.ToString();
                        DangKyBienDong.DienTichRieng = mDtRieng.Value.ToString();
                        DangKyBienDong.DienTichChung = mDtChung.Value.ToString();
                        DangKyBienDong.DienTichChuyenDich = txtDienTichChuyenDich.Text.ToString();
                        if (dhkLoaiBienDong.Checked)
                        {
                            DangKyBienDong.BDMotPhan = "True";
                        }
                        else
                        {
                            DangKyBienDong.BDToanPhan = "False";
                        }

                    }
                    // truong hop the chap 
                    else if (cboLoaiBienDong.SelectedValue.ToString().ToUpper() == "TCBL")
                    {
                        DangKyBienDong.LoaiBienDong = "TCBL";

                        if (radioquyensdd.Checked)
                        {
                            DangKyBienDong.QuyenSDD = "True";
                        }
                        if (radiotaisangandat.Checked)
                        {
                            DangKyBienDong.TaiSanGanDat = "True";
                        }

                        if (radioquyensdvats.Checked)
                        {
                            DangKyBienDong.TaiSanVaDat = "True";
                        }

                        if (this.checkTheChap.Checked)
                        {
                            DangKyBienDong.TheChap = "True";
                        }

                        if (checkBaoLanh.Checked)
                        {
                            DangKyBienDong.BaoLanh = "True";
                        }

                        DangKyBienDong.SoCongChung = this.txtSoCongChung.Text;
                        if (this.dtpNgayCongChung.Checked)
                        {
                            DangKyBienDong.NgayCongChung = this.dtpNgayCongChung.Text;
                        }
                        else
                        {
                            DangKyBienDong.NgayCongChung = null;
                        }

                        DangKyBienDong.HoTenNhanTC = this.txtHoTenNguoiTheChap.Text;
                        DangKyBienDong.SoDinhDanhNguoiTC = this.txtSoDinhDanhNguoiTC.Text;
                        DangKyBienDong.DiaChiNguoiTheChap = this.txtDiaChiNguoiTC.Text;

                        if (this.dtpNgayCapSoDinhDanh.Checked)
                        {
                            DangKyBienDong.NgayCapSoDinhDanhTC = this.dtpNgayCapSoDinhDanh.Text;
                        }
                        else
                        {
                            DangKyBienDong.NgayCapSoDinhDanhTC = null;
                        }

                    }
                    else
                    {
                        DangKyBienDong.LoaiBienDong = "K";
                    }

                    DangKyBienDong.SoHopDong = txtSoHopDong.Text.Trim();
                    if (this.dtpNgayHopDong.Checked)
                    {
                        DangKyBienDong.NgayHopDong = this.dtpNgayHopDong.Text;
                    }
                    else
                    {
                        DangKyBienDong.NgayHopDong = null;
                    }
                    DangKyBienDong.CoQuanCongChung = txtCoQuanCongChung.Text.Trim();
                    // if (grdChuNhanChuyenNhuong.RowCount>0){
                    DangKyBienDong.MaChu = xmlMaChuSuDung(grdChuNhanChuyenNhuong).InnerXml.ToString();
                    //   }

                    DangKyBienDong.MaDangKyBienDong = strMaDangKyBienDong;
                    DangKyBienDong.DiaChiNguoiDangKy = this.txtDiaChiNguoiDangKy.Text.Trim();

                    if (this.chkchon.Checked == true)
                        DangKyBienDong.Chon = "True";
                    else
                        DangKyBienDong.Chon = "False";
                    if (this.radInMat4.Checked)
                        DangKyBienDong.ChonInMat = "True";
                    else
                        DangKyBienDong.ChonInMat = "False";
                    if (this.cmbLoaiThoiHanBienDong.Text == "Lâu dài")
                        DangKyBienDong.LoaiThoiHanBienDong = "0";
                    else
                        DangKyBienDong.LoaiThoiHanBienDong = "1";

                    DangKyBienDong.MaCoQuanChinhLyGCN = this.txtMaCoQuanChinhLyGCN.Text.Trim();
                    DangKyBienDong.MaLoaiBienDong = this.txtMaBienDong.Text.Trim();
                    if (this.DTPNgayBatDau.Checked)
                    {
                        DangKyBienDong.NgayBatDau = this.DTPNgayBatDau.Text;
                    }
                    else
                    {
                        DangKyBienDong.NgayBatDau = null;
                    }
                    if (this.DTPNgayKetThuc.Checked)
                    {
                        DangKyBienDong.NgayKetThuc = this.DTPNgayKetThuc.Text;
                    }
                    else
                    {
                        DangKyBienDong.NgayKetThuc = null;
                    }
                    DangKyBienDong.NoiDungMatBonGCN = this.txtMatBonGCN.Text.Trim();
                    DangKyBienDong.NoidungSoBienDong = this.txtSoBienDong.Text.Trim();
                    DangKyBienDong.NoiDungSoCapGCN = this.txtSoCapGCN.Text.Trim();
                    DangKyBienDong.NoidungSoDiaChinh = this.txtSoDiaChinh.Text.Trim();
                    DangKyBienDong.NoiDungSoMucKe = this.txtSoMucKe.Text.Trim();
                    DangKyBienDong.SoCMTNguoiDangKy = this.txtSoCMTNDNguoiDangKy.Text.Trim();
                    DangKyBienDong.TenNguoiDangKy = this.txtTenNguoiDangKy.Text.Trim();
                    DangKyBienDong.GhiChu = this.txtGhiChu.Text.Trim();
                    if (this.DTPNgayGioDangKy.Checked)
                    {
                        DangKyBienDong.ThoiDiemDangKy = this.DTPNgayGioDangKy.Text;
                    }
                    else
                    {
                        DangKyBienDong.ThoiDiemDangKy = null;
                    }

                    if (this.chkInChuChuyenNhuong.Checked)
                        DangKyBienDong.InNguoiNhanINMatIGCN = "True";
                    else
                        DangKyBienDong.InNguoiNhanINMatIGCN = "False";
                    DangKyBienDong.ThuTuHoSoBienDong = this.numThuTuHoSoBienDong.Text.Trim();
                    DangKyBienDong.ViTriIn = numViTriInBD.Value.ToString();
                    string str = "";
                    /* Hiển thị dữ liệu */
                    if (shortAction == 0)
                    {
                        DangKyBienDong.SelectThongTinBienDong(ref dtDangKyBienDong);
                    }
                    /* Trường hợp thêm mới Thông tin đăng ký biến động */
                    if (shortAction == 1)
                    {
                        DangKyBienDong.InsertDangKyBienDong(ref str);
                        NhatKyNguoiDung("Đăng ký biến động", txtSoBienDong.Text);
                    }
                    else if (shortAction == 2)
                    {
                        /* Cập nhật thông tin đăng ký biến động */
                        DangKyBienDong.UpdateDangKyBienDongByMaDangKyBienDong(ref str);
                        NhatKyNguoiDung("Sửa biến động", "Thay (" + strNoiDungBienDongCu + ") Bằng (" + txtSoBienDong.Text + ")");
                    }
                    else if (shortAction == 3)
                    {
                        /* Xóa thông tin đăng ký biến động */
                        DangKyBienDong.DeleteDangKyBienDongByMaDangKyBienDong(ref str);
                        NhatKyNguoiDung("Xóa biến động biến động", txtSoBienDong.Text);
                    }
                    strError = DangKyBienDong.Err;
                }


                catch (Exception ex)
                {
                    strError = ex.Message;
                    MessageBox.Show(this, " Đăng ký biến động " + System.Environment.NewLine + " Cập nhật dữ liệu " + " Lỗi: " + System.Environment.NewLine
                           + strError, "DMCLand", MessageBoxButtons.OK);
                }
            }

            //    if (this.txtMaBienDong.Text != "TC" && this.txtMaBienDong .Text != "XC")
            //    {
            //        try
            //        {
            //            //Nhận chuỗi kết nối Database
            //            DangKyBienDong.Connection = strConnection;
            //            DangKyBienDong.Flag = strFlag;
            //            if (strMaHoSoCapGCN != null)
            //            {
            //                if (strMaHoSoCapGCN != "")
            //                {
            //                    DangKyBienDong.MaHoSoCapGCN = strMaHoSoCapGCN;
            //                    DangKyBienDong.MaThuaDat = strMaThuaDat;
            //                }
            //                else
            //                {
            //                    MessageBox.Show(this, " Lỗi cập nhật đăng ký biến động " + System.Environment.NewLine, "DMCLand", MessageBoxButtons.OK);
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show(this, " Lỗi cập nhật đăng ký biến động " + System.Environment.NewLine, "DMCLand", MessageBoxButtons.OK);
            //                return;
            //            }

            //            if (dhkLoaiBienDong.Checked)
            //            {
            //                DangKyBienDong.LoaiBienDong = "True";
            //            }
            //            else
            //            {
            //                DangKyBienDong.LoaiBienDong = "False";
            //            }

            //            //DangKyBienDong.NoiDungDat = strNoiDungBienDongCu;
            //            DangKyBienDong.DienTich = numDienTich.Value.ToString();
            //            DangKyBienDong.DienTichRieng = mDtRieng.Value.ToString();
            //            DangKyBienDong.DienTichChung = mDtChung.Value.ToString();
            //            //DangKyBienDong.MotPhanChuSuDung = txt1PhanChuSuDung.Text.Trim();
            //            DangKyBienDong.SoHopDong = txtSoHopDong.Text.Trim();
            //            if (this.dtpNgayHopDong.Checked)
            //            {
            //                DangKyBienDong.NgayHopDong = this.dtpNgayHopDong.Text;
            //            }
            //            else
            //            {
            //                DangKyBienDong.NgayHopDong = null;
            //            }
            //            DangKyBienDong.CoQuanCongChung = txtCoQuanCongChung.Text.Trim();
            //            // if (grdChuNhanChuyenNhuong.RowCount>0){
            //            DangKyBienDong.MaChu = xmlMaChuSuDung(grdChuNhanChuyenNhuong).InnerXml.ToString();
            //            //   }
            //            DangKyBienDong.MaDangKyBienDong = strMaDangKyBienDong;
            //            DangKyBienDong.DiaChiNguoiDangKy = this.txtDiaChiNguoiDangKy.Text.Trim();
                        
            //            if (this.chkchon.Checked == true)
            //                DangKyBienDong.Chon = "True";
            //            else
            //                DangKyBienDong.Chon = "False";
            //            if (this.radInMat4.Checked)
            //                DangKyBienDong.ChonInMat = "True";
            //            else
            //                DangKyBienDong.ChonInMat = "False";
            //            if (this.cmbLoaiThoiHanBienDong.Text == "Lâu dài")
            //                DangKyBienDong.LoaiThoiHanBienDong = "0";
            //            else
            //                DangKyBienDong.LoaiThoiHanBienDong = "1";

            //            DangKyBienDong.MaCoQuanChinhLyGCN = this.txtMaCoQuanChinhLyGCN.Text.Trim();
            //            DangKyBienDong.MaLoaiBienDong = this.txtMaBienDong.Text.Trim();
            //            if (this.DTPNgayBatDau.Checked)
            //            {
            //                DangKyBienDong.NgayBatDau = this.DTPNgayBatDau.Text;
            //            }
            //            else
            //            {
            //                DangKyBienDong.NgayBatDau = null;
            //            }
            //            if (this.DTPNgayKetThuc.Checked)
            //            {
            //                DangKyBienDong.NgayKetThuc = this.DTPNgayKetThuc.Text;
            //            }
            //            else
            //            {
            //                DangKyBienDong.NgayKetThuc = null;
            //            }
            //            DangKyBienDong.NoiDungMatBonGCN = this.txtMatBonGCN.Text.Trim();
            //            DangKyBienDong.NoidungSoBienDong = this.txtSoBienDong.Text.Trim();
            //            DangKyBienDong.NoiDungSoCapGCN = this.txtSoCapGCN.Text.Trim();
            //            DangKyBienDong.NoidungSoDiaChinh = this.txtSoDiaChinh.Text.Trim();
            //            DangKyBienDong.NoiDungSoMucKe = this.txtSoMucKe.Text.Trim();
            //            DangKyBienDong.SoCMTNguoiDangKy = this.txtSoCMTNDNguoiDangKy.Text.Trim();
            //            DangKyBienDong.TenNguoiDangKy = this.txtTenNguoiDangKy.Text.Trim();
            //            DangKyBienDong.GhiChu = this.txtGhiChu.Text.Trim();
            //            if (this.DTPNgayGioDangKy.Checked)
            //            {
            //                DangKyBienDong.ThoiDiemDangKy = this.DTPNgayGioDangKy.Text;
            //            }
            //            else
            //            {
            //                DangKyBienDong.ThoiDiemDangKy = null;
            //            }

            //            if (this.chkInChuChuyenNhuong.Checked)
            //                DangKyBienDong.InNguoiNhanINMatIGCN = "True";
            //            else
            //                DangKyBienDong.InNguoiNhanINMatIGCN = "False";
            //            DangKyBienDong.ThuTuHoSoBienDong = this.numThuTuHoSoBienDong.Text.Trim();
            //            DangKyBienDong.DienTichChuyenDich = txtDienTichChuyenDich.Text.Trim();
            //            DangKyBienDong.ViTriIn = numViTriInBD.Value.ToString();
            //            string str = "";
            //            /* Hiển thị dữ liệu */
            //            if (shortAction == 0)
            //            {
            //                DangKyBienDong.SelectThongTinBienDong(ref dtDangKyBienDong);
            //            }
            //            /* Trường hợp thêm mới Thông tin đăng ký biến động */
            //            if (shortAction == 1)
            //            {
            //                DangKyBienDong.InsertDangKyBienDong(ref str);
            //                NhatKyNguoiDung("Đăng ký biến động", txtSoBienDong.Text );
            //            }
            //            else if (shortAction == 2)
            //            {
            //                /* Cập nhật thông tin đăng ký biến động */
            //                DangKyBienDong.UpdateDangKyBienDongByMaDangKyBienDong(ref str);
            //                NhatKyNguoiDung("Sửa biến động","Thay (" + strNoiDungBienDongCu  + ") Bằng (" + txtSoBienDong.Text + ")" );
            //            }
            //            else if (shortAction == 3)
            //            {
            //                /* Xóa thông tin đăng ký biến động */
            //                DangKyBienDong.DeleteDangKyBienDongByMaDangKyBienDong(ref str);
            //                NhatKyNguoiDung("Xóa biến động biến động", txtSoBienDong.Text);
            //            }
            //            strError = DangKyBienDong.Err;
            //        }


            //        catch (Exception ex)
            //        {
            //            strError = ex.Message;
            //            MessageBox.Show(this, " Đăng ký biến động " + System.Environment.NewLine + " Cập nhật dữ liệu " + " Lỗi: " + System.Environment.NewLine
            //                   + strError, "DMCLand", MessageBoxButtons.OK);
            //        }
            //    }
            //       /* trường hợp mã biến động là biến động thế chấp */
            //       /*************************************************/
            //       /*************************************************/
            //       /*************************************************/
            //    else if (this.txtMaBienDong.Text == "TC" || this.txtMaBienDong .Text == "XC") 
            //    {
                   
            //        try
            //        {
            //            //Nhận chuỗi kết nối Database
            //            DangKyBienDong.Connection = strConnection;
            //            DangKyBienDong.Flag = strFlag;
            //            if (strMaHoSoCapGCN != null)
            //            {
            //                if (strMaHoSoCapGCN != "")
            //                {
            //                    DangKyBienDong.MaHoSoCapGCN = strMaHoSoCapGCN;
            //                    DangKyBienDong.MaThuaDat = strMaThuaDat;
            //                }
            //                else
            //                {
            //                    MessageBox.Show(this, " Lỗi cập nhật đăng ký biến động " + System.Environment.NewLine, "DMCLand", MessageBoxButtons.OK);
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show(this, " Lỗi cập nhật đăng ký biến động " + System.Environment.NewLine, "DMCLand", MessageBoxButtons.OK);
            //                return;
            //            }

            //            if (dhkLoaiBienDong.Checked)
            //            {
            //                DangKyBienDong.LoaiBienDong = "True";
            //            }
            //            else
            //            {
            //                DangKyBienDong.LoaiBienDong = "False";
            //            }

            //            //DangKyBienDong.NoiDungDat = txtNoiDungDat.Text.Trim();
            //            DangKyBienDong.DienTich = numDienTich.Value.ToString();
            //            //DangKyBienDong.MotPhanChuSuDung = txt1PhanChuSuDung.Text.Trim();
            //            DangKyBienDong.SoHopDong = txtSoHopDong.Text.Trim();
            //            if (this.dtpNgayHopDong.Checked)
            //            {
            //                DangKyBienDong.NgayHopDong = this.dtpNgayHopDong.Text;
            //            }
            //            else
            //            {
            //                DangKyBienDong.NgayHopDong = null;
            //            }
            //            DangKyBienDong.CoQuanCongChung = txtCoQuanCongChung.Text.Trim();
            //            // if (grdChuNhanChuyenNhuong.RowCount>0){
            //            DangKyBienDong.MaChu = xmlMaChuSuDung(grdChuNhanChuyenNhuong).InnerXml.ToString();
            //            //   }
            //            DangKyBienDong.MaDangKyBienDong = strMaDangKyBienDong;
            //            DangKyBienDong.DiaChiNguoiDangKy = this.txtDiaChiNguoiDangKy.Text.Trim();

            //            if (this.chkchon.Checked == true)
            //                DangKyBienDong.Chon = "True";
            //            else
            //                DangKyBienDong.Chon = "False";
            //            if (this.radInMat4.Checked)
            //                DangKyBienDong.ChonInMat = "True";
            //            else
            //                DangKyBienDong.ChonInMat = "False";
            //            if (this.cmbLoaiThoiHanBienDong.Text == "Lâu dài")
            //                DangKyBienDong.LoaiThoiHanBienDong = "0";
            //            else
            //                DangKyBienDong.LoaiThoiHanBienDong = "1";

            //            DangKyBienDong.MaCoQuanChinhLyGCN = this.txtMaCoQuanChinhLyGCN.Text.Trim();
            //            DangKyBienDong.MaLoaiBienDong = this.txtMaBienDong.Text.Trim();
            //            if (this.DTPNgayBatDau.Checked)
            //            {
            //                DangKyBienDong.NgayBatDau = this.DTPNgayBatDau.Text;
            //            }
            //            else
            //            {
            //                DangKyBienDong.NgayBatDau = null;
            //            }
            //            if (this.DTPNgayKetThuc.Checked)
            //            {
            //                DangKyBienDong.NgayKetThuc = this.DTPNgayKetThuc.Text;
            //            }
            //            else
            //            {
            //                DangKyBienDong.NgayKetThuc = null;
            //            }
            //            DangKyBienDong.NoiDungMatBonGCN = this.txtMatBonGCN.Text.Trim();
            //            DangKyBienDong.NoidungSoBienDong = this.txtSoBienDong.Text.Trim();
            //            DangKyBienDong.NoiDungSoCapGCN = this.txtSoCapGCN.Text.Trim();
            //            DangKyBienDong.NoidungSoDiaChinh = this.txtSoDiaChinh.Text.Trim();
            //            DangKyBienDong.NoiDungSoMucKe = this.txtSoMucKe.Text.Trim();
            //            DangKyBienDong.SoCMTNguoiDangKy = this.txtSoCMTNDNguoiDangKy.Text.Trim();
            //            DangKyBienDong.TenNguoiDangKy = this.txtTenNguoiDangKy.Text.Trim();
            //            DangKyBienDong.GhiChu = this.txtGhiChu.Text.Trim();
            //            if (this.DTPNgayGioDangKy.Checked)
            //            {
            //                DangKyBienDong.ThoiDiemDangKy = this.DTPNgayGioDangKy.Text;
            //            }
            //            else
            //            {
            //                DangKyBienDong.ThoiDiemDangKy = null;
            //            }
            //            DangKyBienDong.ThuTuHoSoBienDong = this.numThuTuHoSoBienDong.Text.Trim();
            //            string str = "";
            //            /* Hiển thị dữ liệu */
            //            if (shortAction == 0)
            //            {
            //                DangKyBienDong.SelectThongTinBienDong(ref dtDangKyBienDong);
            //            }
            //            /* Trường hợp thêm mới Thông tin đăng ký biến động */
            //            if (shortAction == 1)
            //            {
            //                DangKyBienDong.InsertDangKyBienDong(ref str);
            //                NhatKyNguoiDung("Đăng ký biến động", txtSoBienDong.Text);
            //            }
            //            else if (shortAction == 2)
            //            {
            //                /* Cập nhật thông tin đăng ký biến động */
            //                DangKyBienDong.UpdateDangKyBienDongByMaDangKyBienDong(ref str);
            //                NhatKyNguoiDung("Sửa biến động", "Thay (" + strNoiDungBienDongCu + ") Bằng (" + txtSoBienDong.Text + ")");
            //            }
            //            else if (shortAction == 3)
            //            {
            //                /* Xóa thông tin đăng ký biến động */
            //                DangKyBienDong.DeleteDangKyBienDongByMaDangKyBienDong(ref str);
            //                NhatKyNguoiDung("Xóa biến động biến động", txtSoBienDong.Text);
            //            }
            //            strError = DangKyBienDong.Err;
            //        }


            //        catch (Exception ex)
            //        {
            //            strError = ex.Message;
            //            MessageBox.Show(this, " Đăng ký biến động " + System.Environment.NewLine + " Cập nhật dữ liệu " + " Lỗi: " + System.Environment.NewLine
            //                   + strError, "DMCLand", MessageBoxButtons.OK);
            //        }
            //        /* insert vào bảng người nhận thế chấp */

                
            //        if (checkTheChap.Checked)
            //        {
            //            DangKyBienDong.TheChap = "True";
            //        }
            //        else
            //        {
            //            DangKyBienDong.TheChap = "False";
            //        }
            //        if (checkBaoLanh.Checked)
            //        {
            //            DangKyBienDong.BaoLanh = "True";
            //        }
            //        else
            //        {
            //            DangKyBienDong.BaoLanh = "False";
            //        }  
            //        if (radioquyensdd.Checked)
            //        {
            //            DangKyBienDong.QuyenSDD = "True";
            //        }
            //        else
            //        {
            //            DangKyBienDong.QuyenSDD = "False";
            //        }
            //        //DangKyBienDong.QuyenSDD = this.radioquyensdd.Checked;
            //        if (radiotaisangandat.Checked)
            //        {
            //            DangKyBienDong.TaiSanGanDat = "True";
            //        }
            //        else
            //        {
            //            DangKyBienDong.TaiSanGanDat = "False";
            //        }
            //    //    DangKyBienDong.TaiSanGanDat = this.radiotaisangandat.Checked;
            //        if (radioquyensdvats.Checked)
            //        {
            //            DangKyBienDong.TaiSanVaDat = "True";
            //        }
            //        else
            //        {
            //            DangKyBienDong.TaiSanVaDat = "False";
            //        } 
                     
                   
            //        /* Trường hợp thêm mới Thông tin vào chi tiết thế chấp */
            //        string strt = "";
            //        if (shortAction == 1)
            //        {
            //            this.MaDKBienDong = DangKyBienDong.SelectMaDangKBD();
            //            DangKyBienDong.MaDKBDTC = MaDKBienDong;
            //          DangKyBienDong.InsertTheChap(ref  strt);
            //          NhatKyNguoiDung("Đăng ký biến động", txtSoBienDong.Text);
            //          KhoiTaoTheChap();
                     
                        
            //        }
            //        else if (shortAction == 2)
            //        {
            //            DangKyBienDong.MaDKBDTC = MaDKBienDong; 
            //            NhatKyNguoiDung("Sửa biến động", "Thay (" + strNoiDungBienDongCu + ") Bằng (" + txtSoBienDong.Text + ")");
            //            DangKyBienDong.UpdateTheChap(ref  strt);
            //        }
            //        else if (shortAction == 3)
            //        {
            //            /* Xóa thông tin về thế chấp*/
                       
            //            DangKyBienDong.MaDKBDTC = MaDKBienDong;
            //           DangKyBienDong.DeleteTheChap (ref  strt);
            //           NhatKyNguoiDung("Xóa biến động biến động", txtSoBienDong.Text);
            //           KhoiTaoTheChap();
                       
            //        }                
            //    }
            //        shortAction = 0;
            //}

            public void KhoiTaoTheChap()
            { 
                this.radioquyensdd.Checked = false;
                this.radioquyensdvats.Checked = false;
                this.radiotaisangandat.Checked = false; 
                this.checkBaoLanh.Checked = false;
                this.checkTheChap.Checked = false;
                this.txtDienTichChuyenDich.Text = "";
                txtHoTenNguoiTheChap.Text = "";
                txtSoDinhDanhNguoiTC.Text = "";
                dtpNgayCapSoDinhDanh.Checked = false;
                txtDiaChiNguoiTC.Text = "";
            }
        /// <summary>
        /// Thiết lập trạng thái cập nhật/không cập nhật cho các điều khiển
        /// </summary>
        /// <param name="blnCapNhat">Biến kiểu bool xác định chế độ là cập nhật/không cập nhật</param>
            public void  TrangThaiCapNhat( Boolean blnCapNhat)
            {
                //if (!blnCapNhat.HasValue)
                //    blnCapNhat = false;

                

                this.txtDiaChiNguoiDangKy.ReadOnly = !blnCapNhat;
                this.txtMaBienDong.ReadOnly = !blnCapNhat;
                this.txtMaCoQuanChinhLyGCN.ReadOnly = !blnCapNhat;
                this.txtMatBonGCN.ReadOnly = !blnCapNhat;
                this.txtSoBienDong.ReadOnly = !blnCapNhat;
                this.txtSoCapGCN.ReadOnly = !blnCapNhat;
                this.txtSoCMTNDNguoiDangKy.ReadOnly = !blnCapNhat;
                this.txtSoDiaChinh.ReadOnly = !blnCapNhat;
                this.txtSoMucKe.ReadOnly = !blnCapNhat;
                this.txtTenNguoiDangKy.ReadOnly = !blnCapNhat;
                this.numThuTuHoSoBienDong.ReadOnly = true   ;
                //this.chkChinhLyGCN.Enabled = blnCapNhat;
                this.numViTriInBD.Enabled = blnCapNhat;
                this.cmbLoaiThoiHanBienDong.Enabled = blnCapNhat;
                this.DTPNgayBatDau.Enabled = blnCapNhat;
                this.DTPNgayGioDangKy.Enabled = blnCapNhat;
                this.DTPNgayKetThuc.Enabled = blnCapNhat;
                // phan loai biend ong
                this.dhkLoaiBienDong.Enabled = blnCapNhat;
                this.numDienTich.Enabled = blnCapNhat;
                this.mDtChung.Enabled = blnCapNhat;
                this.mDtRieng.Enabled = blnCapNhat;
                this.txtDienTichChuyenDich.ReadOnly = !blnCapNhat;
                this.radioquyensdd.Enabled = blnCapNhat;
                this.radioquyensdvats.Enabled = blnCapNhat;
                this.radiotaisangandat.Enabled = blnCapNhat;
                this.checkBaoLanh.Enabled = blnCapNhat;
                this.checkTheChap.Enabled = blnCapNhat;
                this.txtSoCongChung.ReadOnly = !blnCapNhat;
                this.dtpNgayCongChung.Enabled = blnCapNhat;

                txtHoTenNguoiTheChap.ReadOnly = !blnCapNhat;
                txtSoDinhDanhNguoiTC.ReadOnly = !blnCapNhat;
                dtpNgayCapSoDinhDanh.Enabled = blnCapNhat;
                txtDiaChiNguoiTC.ReadOnly = !blnCapNhat;
                this.txtSoHopDong.ReadOnly = !blnCapNhat;
                this.dtpNgayHopDong.Enabled = blnCapNhat;
                this.txtCoQuanCongChung.ReadOnly = !blnCapNhat;
                txtGhiChu.ReadOnly = !blnCapNhat;

                if ((cboLoaiBienDong.DataSource != null) & (cboLoaiBienDong.SelectedValue != null ))
                {
                    if (cboLoaiBienDong.SelectedValue.ToString().ToUpper() == "CN") 
                    {
                        grChuyenNhuong.Enabled = true;
                        grHopDong.Enabled = true;
                        grTheChapBaoLanh.Enabled = false;
                    }
                    else if  (cboLoaiBienDong.SelectedValue.ToString().ToUpper() == "TCBL") 
                    {
                        grChuyenNhuong.Enabled = false;
                        grHopDong.Enabled = true;
                        grTheChapBaoLanh.Enabled = true;
                    }
                    else
                    {
                        grChuyenNhuong.Enabled = false;
                        grHopDong.Enabled = false;
                        grTheChapBaoLanh.Enabled = false;
                    }
                }
                else {
                    grChuyenNhuong.Enabled = false;
                    grHopDong.Enabled = false;
                    grTheChapBaoLanh.Enabled = false; 
                }
               
                //this.txtNoiDungDat.ReadOnly = !blnCapNhat;
               
                

                if (blnCapNhat)
                {
                    this.txtDiaChiNguoiDangKy.BackColor = Color.White;
                    this.txtMaBienDong.BackColor = Color.White;
                    this.txtMaCoQuanChinhLyGCN.BackColor = Color.White;
                    this.txtMatBonGCN.BackColor = Color.White;
                    this.txtSoBienDong.BackColor = Color.White;
                    this.txtSoCapGCN.BackColor = Color.White;
                    this.txtSoCMTNDNguoiDangKy.BackColor = Color.White;
                    this.txtSoDiaChinh.BackColor = Color.White;
                    this.txtSoMucKe.BackColor = Color.White;
                    this.txtTenNguoiDangKy.BackColor = Color.White;
                    this.numThuTuHoSoBienDong.BackColor = Color.White;
                    this.grdvwDangKyBienDong.BackgroundColor = Color.White;
                    this.txtGhiChu.BackColor = Color.White;
                    if ((cboLoaiBienDong.DataSource != null) & (cboLoaiBienDong.SelectedValue != null))
                    {
                        if (cboLoaiBienDong.SelectedValue.ToString().ToUpper() == "CN")
                        {
                            this.txtDienTichChuyenDich.BackColor = Color.White;
                        }
                        else if (cboLoaiBienDong.SelectedValue.ToString().ToUpper() == "TCBL")
                        {
                            this.txtSoCongChung.BackColor = Color.White;

                            txtHoTenNguoiTheChap.BackColor = Color.White;
                            txtSoDinhDanhNguoiTC.BackColor = Color.White;
                            txtDiaChiNguoiTC.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    this.txtDiaChiNguoiDangKy.BackColor = Color.LightYellow;
                    this.txtMaBienDong.BackColor = Color.LightYellow;
                    this.txtMaCoQuanChinhLyGCN.BackColor = Color.LightYellow;
                    this.txtMatBonGCN.BackColor = Color.LightYellow;
                    this.txtSoBienDong.BackColor = Color.LightYellow;
                    this.txtSoCapGCN.BackColor = Color.LightYellow;
                    this.txtSoCMTNDNguoiDangKy.BackColor = Color.LightYellow;
                    this.txtSoDiaChinh.BackColor = Color.LightYellow;
                    this.txtSoMucKe.BackColor = Color.LightYellow;
                    this.txtTenNguoiDangKy.BackColor = Color.LightYellow;
                    this.numThuTuHoSoBienDong.BackColor = Color.LightYellow;

                   // this.txtNoiDungDat.BackColor = Color.LightYellow;
                    this.txtSoHopDong.BackColor = Color.LightYellow;
                    this.txtGhiChu.BackColor = Color.LightYellow;
                    this.txtDienTichChuyenDich.BackColor = Color.LightYellow;
                    if ((cboLoaiBienDong.DataSource != null) & (cboLoaiBienDong.SelectedValue != null))
                    {
                        if (cboLoaiBienDong.SelectedValue.ToString().ToUpper() == "CN")
                        {
                            this.txtDienTichChuyenDich.BackColor = Color.LightYellow;
                        }
                        else if (cboLoaiBienDong.SelectedValue.ToString().ToUpper() == "TCBL")
                        {
                            this.txtSoCongChung.BackColor = Color.LightYellow;

                            txtHoTenNguoiTheChap.BackColor = Color.LightYellow;
                            txtSoDinhDanhNguoiTC.BackColor = Color.LightYellow;
                            txtDiaChiNguoiTC.BackColor = Color.LightYellow;
                        }
                    }
                }
            }
        /// <summary>
        /// Thiết lập trạng thái ban đầu cho các điều khiển
        /// </summary>
            public void  TrangThaiBanDau()
            {
                //dtDangKyBienDong.Clear();
                this.txtDiaChiNguoiDangKy.Text = "";
                this.txtMaBienDong.Text = "";
                this.txtMatBonGCN.Text = "";
                this.txtMaCoQuanChinhLyGCN.Text = "VP";
                this.txtSoBienDong.Text = "";
                this.txtSoCapGCN.Text = "";
                this.txtSoCMTNDNguoiDangKy.Text = "";
                this.txtSoDiaChinh.Text = "";
                this.txtSoMucKe.Text = "";
                this.txtTenNguoiDangKy.Text = "";
                this.numThuTuHoSoBienDong.Text = "";
                this.txtDienTichChuyenDich.Text = "";
                //this.chkChinhLyGCN.Checked = false;
                //this.chkChinhLyGCN.Enabled = false;
                this.cmbLoaiThoiHanBienDong.Enabled = false;
                this.chkchon.Checked = false;
                this.chkchon.Enabled = false;

                this.DTPNgayBatDau.Text = "";
                this.DTPNgayBatDau.Checked = false;
                this.DTPNgayBatDau.Enabled = false;

                this.DTPNgayGioDangKy.Text = "";
                this.DTPNgayGioDangKy.Checked = false;
                this.DTPNgayGioDangKy.Enabled = false;

                this.DTPNgayKetThuc.Text = "";
                this.DTPNgayKetThuc.Checked = false;
                this.DTPNgayKetThuc.Enabled = false;

                btnMaBienDong.Enabled = false;
                btnMaCoQuanThucHien.Enabled = false;
                
                this.dhkLoaiBienDong.Enabled  = false ;
                //this.txtNoiDungDat.Text = "";
                this.numDienTich.Value = 0;
                this.numDienTich.Enabled = false;
                this.txtSoHopDong.Text = "";
                this.dtpNgayHopDong.Enabled  = false ;                
                this.txtCoQuanCongChung.Text = "";
                this.txtGhiChu.Text = "";
                this.numViTriInBD.Value = 0;

                KhoiTaoTheChap();


            }


            public void TrangThaiChucNang( Boolean blnStartEdited  , Boolean blnStartDeleted )
            {
                //if (this.MaLoaiBienDong != "MG")
                //{
                   // this.groupBox3.Enabled = true;
                    this.btnSua.Enabled = !blnStartEdited;
                    this.btnXoa.Enabled = !blnStartEdited;
                    this.btnDangKyBienDong.Enabled = !blnStartEdited;
                    this.btnCapNhat.Enabled = blnStartEdited;
                    this.btnHuyLenh.Enabled = blnStartEdited;
                    if (blnStartDeleted)
                    {
                        this.btnCapNhat.Enabled = !blnStartDeleted;
                        this.btnHuyLenh.Enabled = !blnStartDeleted;
                    }
                    /* Ẩn chức năng Thêm đăng ký nếu đã tồn tại thông tin đăng ký */

                    //if (this.strMaDangKyBienDong != "")
                    //{
                    //    this.btnDangKyBienDong.Enabled = false;
                    //}

                //}
                //else
                //{
                //    this.groupBox3.Enabled = false;
                //}
               
            }

            private void ctrlDangKyBienDong_Load(object sender, EventArgs e)  
            {
                /* Thiết lập định dạng ngày tháng */
                this.DTPNgayBatDau.CustomFormat = "dd/MM/yyyy";
                this.DTPNgayBatDau.Format = DateTimePickerFormat.Custom;
                this.DTPNgayBatDau.ShowCheckBox = true;
                this.DTPNgayBatDau.Checked = false;

                this.DTPNgayGioDangKy.CustomFormat = "dd/MM/yyyy hh:mm";
                this.DTPNgayGioDangKy.Format = DateTimePickerFormat.Custom;
                this.DTPNgayGioDangKy.ShowCheckBox = true;
                this.DTPNgayGioDangKy.Checked = false;

                this.DTPNgayKetThuc.CustomFormat = "dd/MM/yyyy";
                this.DTPNgayKetThuc.Format = DateTimePickerFormat.Custom;
                this.DTPNgayKetThuc.ShowCheckBox = true;
                this.DTPNgayKetThuc.Checked = false;

                this.dtpNgayHopDong.CustomFormat = "dd/MM/yyyy";
                this.dtpNgayHopDong.Format = DateTimePickerFormat.Custom;
                this.dtpNgayHopDong.ShowCheckBox = true;
                this.dtpNgayHopDong.Checked = false;

                this.dtpNgayCongChung.CustomFormat = "dd/MM/yyyy";
                this.dtpNgayCongChung.Format = DateTimePickerFormat.Custom;
                this.dtpNgayCongChung.ShowCheckBox = true;
                this.dtpNgayCongChung.Checked = false;

                this.dtpNgayCapSoDinhDanh.CustomFormat = "dd/MM/yyyy";
                this.dtpNgayCapSoDinhDanh.Format = DateTimePickerFormat.Custom;
                this.dtpNgayCapSoDinhDanh.ShowCheckBox = true;
                this.dtpNgayCapSoDinhDanh.Checked = false;

                /* Thiết lập trạng thái khởi tạo ban đầu cho các điều khiển */
                this.TrangThaiBanDau();
                /* Thiết lập chế độ không cập nhật cho các điều khiển */
                this.TrangThaiCapNhat(false );
                /* Thiết lập trạng thái chức năng cho các điều khiển cập nhật dữ liệu */
                this.TrangThaiChucNang(true, true);
                this.KhoiTaoTheChap();
                this.btnThuTu.Enabled = false;
                this.numThuTuHoSoBienDong.Enabled = false;
                this.btnMaCoQuanThucHien.Enabled = false;
                this.btnMaBienDong.Enabled = false;

            }

            private void btnDangKyBienDong_Click(object sender, EventArgs e)
            {
                // thế chấp 
                this.radioquyensdd.Checked = false;
                this.radioquyensdvats.Checked = false;
                this.radiotaisangandat.Checked = false; 
                /* Chắc chắn rằng chưa đăng ký biến động lần nào */
                //if (this.strMaDangKyBienDong != "")
                //{
                //    return;
                //}
                shortAction = 1;
                /* Thiết lập trạng thái ban đầu */
                this.TrangThaiBanDau();
                /* Trạng thái cập nhật */
                this.TrangThaiCapNhat(true);
                /* Trạng thái chức năng */
                this.TrangThaiChucNang(true,false );
                this.numThuTuHoSoBienDong.Enabled = true;
                this.btnThuTu.Enabled = true;
                this.btnMaBienDong.Enabled = true;
                this.btnMaCoQuanThucHien.Enabled = true;
                chkchon.Enabled = true;

                clsDangKyBienDong DangKyBienDong = new clsDangKyBienDong();
                /* Gán giá trị cho thuộc tính cần cho điều kiện truy vấn */
                DangKyBienDong.Connection = strConnection;
                DangKyBienDong.MaHoSoCapGCN = strMaHoSoCapGCN;
                DataTable dtChuHS = new DataTable();
                DangKyBienDong.SelectThongTinChuSuDung(dtChuHS);
                if (dtChuHS.Rows.Count > 0)
                {
                    txtTenNguoiDangKy.Text = dtChuHS.Rows[0]["HoTen"].ToString();
                    txtSoCMTNDNguoiDangKy.Text = dtChuHS.Rows[0]["SoDinhDanh"].ToString();
                    txtDiaChiNguoiDangKy.Text = dtChuHS.Rows[0]["DiaChi"].ToString();

                }

            }

            private void btnSua_Click(object sender, EventArgs e)
            {
                /* Chắc chắn rằng tồn tại Mã đăng ký biến động cần sửa thông tin */
                if (this.strMaDangKyBienDong == "")
                {
                    return;
                }
                shortAction = 2;
                /* Trạng thái chức năng */
                this.TrangThaiChucNang(true,false );
                /* Trạng thái cập nhật */
                this.TrangThaiCapNhat(true );
                this.numThuTuHoSoBienDong.Enabled = true;
                this.btnThuTu.Enabled = true;
                this.btnMaBienDong.Enabled = true;
                this.btnMaCoQuanThucHien.Enabled = true;
                chkchon.Enabled = true;
            }

            
            private void btnCapNhat_Click(object sender, EventArgs e)
            {
                /* Cập nhật thông tin bảng đăng ký biến động */
                this.UpdateData();
                /* Hiển thị dữ liệu */
                this.ShowData();
                //Trang thai chuc nang
                this.TrangThaiChucNang(false ,false );
                    //Trang thai cap nhat
                this.TrangThaiCapNhat(false );

                if (strError == "" || strError == "OK") 
                    MessageBox.Show (this," Bạn đã cập nhật thành công!", "DMCLand",MessageBoxButtons.OK );
                else 
                    MessageBox.Show (this," Cập nhật chưa thành công!", "DMCLand" , MessageBoxButtons.OK );
                strError = "";
            }

            private void btnXoa_Click(object sender, EventArgs e)
            {
                try
                {
                    if (strMaHoSoCapGCN != "")
                    {
                        string strMessage = "Bạn chắc chắn muốn xóa không?";
                        string strCaption = "DMCLand!";
                        MessageBoxButtons btnMessage = MessageBoxButtons.YesNo;
                        DialogResult dlgResult = DialogResult.Yes;
                        if (MessageBox.Show(this, strMessage, strCaption, btnMessage, MessageBoxIcon.Information) == dlgResult)
                        {
                            shortAction = 3;
                            this.UpdateData();
                            if ((strError == "") || (strError == "OK"))
                                MessageBox.Show(this, " Bạn đã cập nhật thành công!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show(this, " Cập nhật chưa thành công!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    /* Hiển thị dữ liệu */
                    this.ShowData();
                    this.TrangThaiChucNang(false, false);
                    strError = "";
                    this.btnThuTu.Enabled = false;
                    this.numThuTuHoSoBienDong.Enabled = false;
                    this.btnMaCoQuanThucHien.Enabled = false;
                    this.btnMaBienDong.Enabled = false;
                    chkchon.Enabled = false; 
                    this.radioquyensdd.Checked = false;
                    this.radioquyensdvats.Checked = false;
                    this.radiotaisangandat.Checked = false; 
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }

            }

            private void btnHuyLenh_Click(object sender, EventArgs e)
            {
                //Xoa du lieu tren Form
                this.TrangThaiBanDau();
                //Hien thi du lieu
                if (strMaHoSoCapGCN != "")
                {
                    this.ShowData();
                    //Trang thai chuc nang
                    this.TrangThaiChucNang(false,false );
                    //Trang thai cap nhat 
                    this.TrangThaiCapNhat(false );
                    this.btnThuTu.Enabled = false;
                    this.numThuTuHoSoBienDong.Enabled = false;
                    this.btnMaCoQuanThucHien.Enabled = false;
                    this.btnMaBienDong.Enabled = false;
                    chkchon.Enabled = false;

                    //thế chấp 
                    this.radioquyensdd.Checked = false;
                    this.radioquyensdvats.Checked = false;
                    this.radiotaisangandat.Checked = false; 
                }
                shortAction = 0;
            }

            private void cmbLoaiThoiHanBienDong_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmbLoaiThoiHanBienDong.Text == "Có thời hạn")
                {
                    this.DTPNgayBatDau.Enabled = true;
                    this.DTPNgayBatDau.Checked = true;

                    this.DTPNgayKetThuc.Enabled = true;
                    this.DTPNgayKetThuc.Checked = true;
                }
                else
                {
                    this.DTPNgayBatDau.Enabled = false;
                    this.DTPNgayBatDau.Checked = false;
                    
                    this.DTPNgayKetThuc.Enabled = false;
                    this.DTPNgayKetThuc.Checked = false;
                }
            }

          

            //private void btnInGCN_Click(object sender, EventArgs e)
            //{
            //    frmInMatBonGCN InGCN = new frmInMatBonGCN();
            //    InGCN.ctrlRptGCN.Connection = strConnection;
            //    InGCN.ctrlRptGCN.MaHoSoCapGCN = strMaHoSoCapGCN;
            //    InGCN.StartPosition = FormStartPosition.CenterScreen;
            //    InGCN.WindowState = FormWindowState.Maximized;
            //    InGCN.Show();
            //}

            //private void SelectColumn(DataGridView grdvw,Int32 intRowIndex ,Int32 intColumnIndex)
            //{
            //    if (intRowIndex < 0)
            //    {
            //        return;
            //    }
            //   else
            //    {
            //        if (grdvw.Rows[intRowIndex].Cells["Chon"].Value.ToString() == "")
            //        {
            //            grdvw.Rows[intRowIndex].Cells["Chon"].Value = "False";
            //        }
            //        else
            //        {
            //            grdvw.Rows[intRowIndex].Cells["Chon"].Value = "True";
            //        }
            //    }
            //}
            /*Sự kiện khi người dùng kích đúp chuột vào ô dữ liệu trong Grid*/

          
             private void grdvwDangKyBienDong_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
            {
                /* Khong cho click chuot phai */
                if (e.Button.ToString() == "Right")
                {
                    return;
                } 
               
                /* Khoi tao doi tuong clsTimKiem */
                clsDangKyBienDong DangKyBienDong = new clsDangKyBienDong();
                if (e.RowIndex >= 0)
                {
                    try
                    {
                        /*  Gan gia tri cho cac thuoc tinh doi voi truong hop truy van */
                        /* Cập nhật dữ liệu tương Ứng khi click chuột vào thuộc tính  
                        lớp Từ điển người xét duyệt */
                        strMaDangKyBienDong = dtDangKyBienDong.Rows[e.RowIndex]["MaDangKyBienDong"].ToString();
                        DangKyBienDong.MaDangKyBienDong = dtDangKyBienDong.Rows[e.RowIndex]["MaDangKyBienDong"].ToString();
                        DangKyBienDong.MaHoSoCapGCN = dtDangKyBienDong.Rows[e.RowIndex]["MaHoSoCapGCN"].ToString();
                        strMaHoSoCapGCN = dtDangKyBienDong.Rows[e.RowIndex]["MaHoSoCapGCN"].ToString();
                        DangKyBienDong.MaCoQuanChinhLyGCN = dtDangKyBienDong.Rows[e.RowIndex]["MaCoQuanChinhLyGCN"].ToString();
                        DangKyBienDong.ThuTuHoSoBienDong = dtDangKyBienDong.Rows[e.RowIndex]["ThuTuHoSoBienDong"].ToString();
                        DangKyBienDong.MaLoaiBienDong = dtDangKyBienDong.Rows[e.RowIndex]["MaLoaiBienDong"].ToString();
                        DangKyBienDong.ThoiDiemDangKy = dtDangKyBienDong.Rows[e.RowIndex]["ThoiDiemDangKy"].ToString();
                        DangKyBienDong.NoidungSoDiaChinh = dtDangKyBienDong.Rows[e.RowIndex]["NoidungSoDiaChinh"].ToString();
                        DangKyBienDong.NoidungSoBienDong = dtDangKyBienDong.Rows[e.RowIndex]["NoidungSoBienDong"].ToString();
                        DangKyBienDong.NoiDungSoMucKe = dtDangKyBienDong.Rows[e.RowIndex]["NoiDungSoMucKe"].ToString();
                        DangKyBienDong.NoiDungSoCapGCN = dtDangKyBienDong.Rows[e.RowIndex]["NoiDungSoCapGCN"].ToString();
                        DangKyBienDong.NoiDungMatBonGCN = dtDangKyBienDong.Rows[e.RowIndex]["NoiDungMatBonGCN"].ToString();
                        DangKyBienDong.TenNguoiDangKy = dtDangKyBienDong.Rows[e.RowIndex]["TenNguoiDangKy"].ToString();
                        DangKyBienDong.SoCMTNguoiDangKy = dtDangKyBienDong.Rows[e.RowIndex]["SoCMTNguoiDangKy"].ToString();
                        DangKyBienDong.DiaChiNguoiDangKy = dtDangKyBienDong.Rows[e.RowIndex]["DiaChiNguoiDangKy"].ToString();
                        DangKyBienDong.NgayBatDau = dtDangKyBienDong.Rows[e.RowIndex]["NgayBatDau"].ToString();
                        DangKyBienDong.NgayKetThuc = dtDangKyBienDong.Rows[e.RowIndex]["NgayKetThuc"].ToString();
                        DangKyBienDong.DienTichChuyenDich = dtDangKyBienDong.Rows[e.RowIndex]["DienTichChuyenDich"].ToString();
                        DangKyBienDong.ViTriIn = dtDangKyBienDong.Rows[e.RowIndex]["ViTriIn"].ToString();

                        strNoiDungBienDongCu = DangKyBienDong.NoidungSoBienDong;
                        //loai bien dong
                        //MaDangKyBienDong, ChuSuDung, CMT, NgayCap, DiaChi, SoHopDong, NgayHopDong, CoQuanCongChung
                        //MaDangKyBienDong, NoiDungDat, DienTichCap, ChuSuDung, SoHopDong, NgayHopDong, CoQuanCongChung


                        DangKyBienDong.LoaiBienDong = dtDangKyBienDong.Rows[e.RowIndex]["LoaiBienDong"].ToString();
                        DangKyBienDong.NoiDungDat  = dtDangKyBienDong.Rows[e.RowIndex]["NoiDungDat"].ToString(); ;
                        DangKyBienDong.DienTich = dtDangKyBienDong.Rows[e.RowIndex]["DienTich"].ToString(); ;
                        DangKyBienDong.SoHopDong = dtDangKyBienDong.Rows[e.RowIndex]["SoHopDong"].ToString(); ;
                        DangKyBienDong.NgayHopDong = dtDangKyBienDong.Rows[e.RowIndex]["NgayHopDong"].ToString(); ;
                        DangKyBienDong.CoQuanCongChung  = dtDangKyBienDong.Rows[e.RowIndex]["CoQuanCongChung"].ToString(); ;
                        DangKyBienDong.GhiChu = dtDangKyBienDong.Rows[e.RowIndex]["Ghichu"].ToString(); ;


                        if (dtDangKyBienDong.Rows[e.RowIndex]["LoaiThoiHanBienDong"].ToString() == "True")
                            DangKyBienDong.LoaiThoiHanBienDong = "1";
                        else if (dtDangKyBienDong.Rows[e.RowIndex]["LoaiThoiHanBienDong"].ToString() == "False")
                            DangKyBienDong.LoaiThoiHanBienDong = "0";
                        else
                            DangKyBienDong.LoaiThoiHanBienDong = "";

                        if (dtDangKyBienDong.Rows[e.RowIndex]["HoanTatDangKyBienDong"].ToString() == "True")
                            DangKyBienDong.HoanTatDangKyBienDong = "1";
                        else if (dtDangKyBienDong.Rows[e.RowIndex]["HoanTatDangKyBienDong"].ToString() == "False")
                            DangKyBienDong.HoanTatDangKyBienDong = "0";
                        else
                            DangKyBienDong.HoanTatDangKyBienDong = "";

                        if (dtDangKyBienDong.Rows[e.RowIndex]["Chon"].ToString() == "True")
                            DangKyBienDong.Chon = "1";
                        else if (dtDangKyBienDong.Rows[e.RowIndex]["Chon"].ToString() == "False")
                            DangKyBienDong.Chon = "0";
                        else
                            DangKyBienDong.Chon = "";
                        if (dtDangKyBienDong.Rows[e.RowIndex]["MatInBienDong"].ToString() == "True")
                            DangKyBienDong.ChonInMat = "1";
                        else if (dtDangKyBienDong.Rows[e.RowIndex]["MatInBienDong"].ToString() == "False")
                            DangKyBienDong.ChonInMat = "0";
                        else
                            DangKyBienDong.ChonInMat = "";

                        if (dtDangKyBienDong.Rows[e.RowIndex]["QuyenSDD"].ToString() == "True")
                            DangKyBienDong.QuyenSDD = "1";
                        else if (dtDangKyBienDong.Rows[e.RowIndex]["QuyenSDD"].ToString() == "False")
                            DangKyBienDong.QuyenSDD = "0";
                        else
                            DangKyBienDong.QuyenSDD = "";

                        if (dtDangKyBienDong.Rows[e.RowIndex]["TaiSanGanDat"].ToString() == "True")
                            DangKyBienDong.TaiSanGanDat = "1";
                        else if (dtDangKyBienDong.Rows[e.RowIndex]["TaiSanGanDat"].ToString() == "False")
                            DangKyBienDong.TaiSanGanDat = "0";
                        else
                            DangKyBienDong.TaiSanGanDat = "";


                        if (dtDangKyBienDong.Rows[e.RowIndex]["TaiSanVaDat"].ToString() == "True")
                            DangKyBienDong.TaiSanVaDat = "1";
                        else if (dtDangKyBienDong.Rows[e.RowIndex]["TaiSanVaDat"].ToString() == "False")
                            DangKyBienDong.TaiSanVaDat = "0";
                        else
                            DangKyBienDong.TaiSanVaDat = "";


                        if (dtDangKyBienDong.Rows[e.RowIndex]["TheChap"].ToString() == "True")
                            DangKyBienDong.TheChap = "1";
                        else if (dtDangKyBienDong.Rows[e.RowIndex]["TheChap"].ToString() == "False")
                            DangKyBienDong.TheChap = "0";
                        else
                            DangKyBienDong.TheChap = "";


                        if (dtDangKyBienDong.Rows[e.RowIndex]["BaoLanh"].ToString() == "True")
                            DangKyBienDong.BaoLanh = "1";
                        else if (dtDangKyBienDong.Rows[e.RowIndex]["BaoLanh"].ToString() == "False")
                            DangKyBienDong.BaoLanh = "0";
                        else
                            DangKyBienDong.BaoLanh = "";

                        if (dtDangKyBienDong.Rows[e.RowIndex]["BDToanPhan"].ToString() == "True")
                            DangKyBienDong.BDToanPhan = "1";
                        else if (dtDangKyBienDong.Rows[e.RowIndex]["BDToanPhan"].ToString() == "False")
                            DangKyBienDong.BDToanPhan = "0";
                        else
                            DangKyBienDong.BDToanPhan = "";

                        if (dtDangKyBienDong.Rows[e.RowIndex]["BDMotPhan"].ToString() == "True")
                            DangKyBienDong.BDMotPhan = "1";
                        else if (dtDangKyBienDong.Rows[e.RowIndex]["BDMotPhan"].ToString() == "False")
                            DangKyBienDong.BDMotPhan = "0";
                        else
                            DangKyBienDong.BDMotPhan = "";

                        DangKyBienDong.SoCongChung = dtDangKyBienDong.Rows[e.RowIndex]["SoCongChung"].ToString(); ;
                        DangKyBienDong.NgayCongChung = dtDangKyBienDong.Rows[e.RowIndex]["NgayCongChung"].ToString(); ;
                        //NguoiTheChap,SoDinhDanh	,NgayCap,DiaChi
                        DangKyBienDong.HoTenNhanTC = dtDangKyBienDong.Rows[e.RowIndex]["NguoiTheChap"].ToString();
                        DangKyBienDong.SoDinhDanhNguoiTC = dtDangKyBienDong.Rows[e.RowIndex]["SoDinhDanh"].ToString();
                        DangKyBienDong.DiaChiNguoiTheChap = dtDangKyBienDong.Rows[e.RowIndex]["DiaChi"].ToString();
                       DangKyBienDong.NgayCapSoDinhDanhTC = dtDangKyBienDong.Rows[e.RowIndex]["NgayCap"].ToString();

                        /* Hiển thị dữ liệu tương ứng lên Form */

                        if (DangKyBienDong.LoaiBienDong == "1")
                        {
                            this.dhkLoaiBienDong.Checked = true;
                        }
                        else {
                            this.dhkLoaiBienDong.Checked = false ;
                        }

                    //this.txtNoiDungDat.Text =   DangKyBienDong.NoiDungDat   ;
                    if (DangKyBienDong.DienTich != "")
                    {
                        this.numDienTich.Value = Convert.ToDecimal(DangKyBienDong.DienTich);
                    }
                    else {
                        this.numDienTich.Value = 0;
                    }
                    if (dtDangKyBienDong.Rows[e.RowIndex]["DienTichRieng"].ToString() != "")
                    {
                        this.mDtRieng.Value = Convert.ToDecimal(dtDangKyBienDong.Rows[e.RowIndex]["DienTichRieng"].ToString());
                    }
                    else
                    {
                        this.mDtRieng.Value = 0; 
                     }
                    if (dtDangKyBienDong.Rows[e.RowIndex]["DienTichChung"].ToString() != "")
                    {
                        this.mDtChung .Value = Convert.ToDecimal(dtDangKyBienDong.Rows[e.RowIndex]["DienTichChung"].ToString());
                    }
                    else
                    {
                        this.mDtRieng.Value = 0;
                    }
                       this.txtSoHopDong.Text = DangKyBienDong.SoHopDong  ;
                       if (DangKyBienDong.NgayHopDong.ToString() != "")
                       {
                           this.dtpNgayHopDong.Value = Convert.ToDateTime(DangKyBienDong.NgayHopDong.ToString());
                           this.dtpNgayHopDong.Checked = true;
                       }
                       else
                       {
                           this.dtpNgayHopDong.Value = DateTime.Now;
                           this.dtpNgayHopDong.Checked = false;
                       }

                     this.txtCoQuanCongChung.Text =   DangKyBienDong.CoQuanCongChung ;

                      

                        if (DangKyBienDong.ThoiDiemDangKy.ToString() != "")
                        {
                            this.DTPNgayGioDangKy.Value = Convert.ToDateTime(DangKyBienDong.ThoiDiemDangKy.ToString());
                            this.DTPNgayGioDangKy.Checked = true;
                        }
                        else
                        {
                            this.DTPNgayGioDangKy.Value = DateTime.Now;
                            this.DTPNgayGioDangKy.Checked = false;
                        }
                        this.numThuTuHoSoBienDong.Text = DangKyBienDong.ThuTuHoSoBienDong.ToString();
                        this.txtTenNguoiDangKy.Text = DangKyBienDong.TenNguoiDangKy.ToString();

                        if (DangKyBienDong.LoaiThoiHanBienDong == "1")
                            this.Text = "Lâu dài";
                        else if (DangKyBienDong.LoaiThoiHanBienDong == "0")
                            this.Text = "Có thời hạn";
                        else
                            this.cmbLoaiThoiHanBienDong.Text = "";

                        if (DangKyBienDong.Chon == "1")
                        {
                            this.chkchon.Checked = true;
                            if (DangKyBienDong.ChonInMat == "1")
                            {
                                radInMat4.Checked = true;
                                radInMat3.Checked = false ;
                            }
                            else
                            {
                                radInMat4.Checked = false;
                                radInMat3.Checked = true ;
                            }
                        }
                        else
                        {
                            this.chkchon.Checked = false;
                        }
                        this.txtSoCMTNDNguoiDangKy.Text = DangKyBienDong.SoCMTNguoiDangKy.ToString();
                        this.txtDiaChiNguoiDangKy.Text = DangKyBienDong.DiaChiNguoiDangKy.ToString();
                        this.txtMaBienDong.Text = DangKyBienDong.MaLoaiBienDong.ToString();
                        if (DangKyBienDong.NgayBatDau.ToString() != "")
                        {
                            this.DTPNgayBatDau.Value = Convert.ToDateTime(DangKyBienDong.NgayBatDau.ToString());
                            this.DTPNgayBatDau.Checked = true;
                        }
                        else
                        {
                            this.DTPNgayBatDau.Value = DateTime.Now;
                            this.DTPNgayBatDau.Checked = false;
                        }
                        if (DangKyBienDong.NgayKetThuc.ToString() != "")
                        {
                            this.DTPNgayKetThuc.Value = Convert.ToDateTime(DangKyBienDong.NgayKetThuc.ToString());
                            this.DTPNgayKetThuc.Checked = true;
                        }
                        else
                        {
                            this.DTPNgayKetThuc.Value = DateTime.Now;
                            this.DTPNgayKetThuc.Checked = false;
                        }
                        this.txtSoBienDong.Text = DangKyBienDong.NoidungSoBienDong.ToString();
                        this.txtSoCapGCN.Text = DangKyBienDong.NoiDungSoCapGCN.ToString();
                        this.txtSoDiaChinh.Text = DangKyBienDong.NoidungSoDiaChinh.ToString();
                        this.txtSoMucKe.Text = DangKyBienDong.NoiDungSoMucKe.ToString();
                        this.txtMatBonGCN.Text = DangKyBienDong.NoiDungMatBonGCN.ToString();
                        this.txtMaCoQuanChinhLyGCN.Text = DangKyBienDong.MaCoQuanChinhLyGCN.ToString();
                        this.txtGhiChu.Text = DangKyBienDong.GhiChu.ToString();
                        this.numViTriInBD.Value = Convert.ToDecimal(DangKyBienDong.ViTriIn);

                        if (DangKyBienDong.LoaiBienDong != "")
                        {
                            cboLoaiBienDong.SelectedValue = DangKyBienDong.LoaiBienDong;
                        }
                        if (DangKyBienDong.QuyenSDD == "1")
                        {
                            this.radioquyensdd.Checked = true;
                        }else
                        {
                            this.radioquyensdd.Checked = false ;
                        }
                        if (DangKyBienDong.TaiSanGanDat == "1")
                        {
                            this.radiotaisangandat.Checked = true;
                        }
                        else {
                            this.radiotaisangandat.Checked = false;
                        }

                        if (DangKyBienDong.TaiSanVaDat == "1")
                        {
                            this.radioquyensdvats.Checked = true;
                        }
                        else
                        {
                            this.radioquyensdvats.Checked = false;
                        }

                        if (DangKyBienDong.TheChap == "1")
                        {
                            this.checkTheChap.Checked = true;
                        }
                        else {
                            this.checkTheChap.Checked = false;
                        }


                        if (DangKyBienDong.BaoLanh == "1")
                        {
                            this.checkBaoLanh.Checked = true;
                        }
                        else
                        {
                            this.checkBaoLanh.Checked = false;
                        }


                        if (DangKyBienDong.BDMotPhan == "1")
                        {
                            this.dhkLoaiBienDong.Checked = true;
                        }
                        else
                        {
                            this.dhkLoaiBienDong.Checked = false;
                        }

                        this.txtHoTenNguoiTheChap.Text = DangKyBienDong.HoTenNhanTC;
                        this.txtSoDinhDanhNguoiTC.Text = DangKyBienDong.SoDinhDanhNguoiTC;
                        this.txtDiaChiNguoiTC.Text = DangKyBienDong.DiaChiNguoiTheChap;
                        if (DangKyBienDong.NgayCapSoDinhDanhTC.ToString() != "")
                        {
                            this.dtpNgayCapSoDinhDanh.Value = Convert.ToDateTime(DangKyBienDong.NgayCapSoDinhDanhTC.ToString());
                            this.dtpNgayCapSoDinhDanh.Checked = true;
                        }
                        else
                        {
                            this.dtpNgayCapSoDinhDanh.Value = DateTime.Now;
                            this.dtpNgayCapSoDinhDanh.Checked = false;
                        }

                        this.txtSoCongChung.Text = DangKyBienDong.SoCongChung;
                        if (DangKyBienDong.NgayCongChung.ToString() != "")
                        {
                            this.dtpNgayCongChung.Value = Convert.ToDateTime(DangKyBienDong.NgayCongChung.ToString());
                            this.dtpNgayCongChung.Checked = true;
                        }
                        else
                        {
                            this.dtpNgayCongChung.Value = DateTime.Now;
                            this.dtpNgayCongChung.Checked = false;
                        }

                        CheckLoaiBienDong();
                        if ((cboLoaiBienDong.DataSource != null) & (cboLoaiBienDong.SelectedValue != null))
                        {
                            if (cboLoaiBienDong.SelectedValue.ToString().ToUpper() == "CN")
                            {
                                DataTable dtNguoiChuyenNhuong = new DataTable();
                                DangKyBienDong.Connection = strConnection;
                                DangKyBienDong.SelThongTinNguoiChuyenNhuong(dtNguoiChuyenNhuong);
                                grdChuNhanChuyenNhuong.DataSource = dtNguoiChuyenNhuong;
                                this.txtDienTichChuyenDich.Text = DangKyBienDong.DienTichChuyenDich.ToString();



                                if (dtNguoiChuyenNhuong.Rows.Count > 0)
                                {
                                    if (dtNguoiChuyenNhuong.Rows[0]["InNguoiNhanINMatIGCN"].ToString().ToUpper() == "True".ToString().ToUpper())
                                    {
                                        chkInChuChuyenNhuong.Checked = true;
                                    }
                                    else
                                    {
                                        chkInChuChuyenNhuong.Checked = false;
                                    }
                                }


                                FormatGridContruction(grdChuNhanChuyenNhuong);

                            }
                            else {

                                grdChuNhanChuyenNhuong.Columns.Clear(); 
                            }
                        }
                        else
                        {

                            grdChuNhanChuyenNhuong.Columns.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        strError = ex.Message;
                        System.Windows.Forms.MessageBox.Show(this, " Hiển thị dữ liệu lên Form " + System.Environment.NewLine + "Thông Tin Biến Động" +
                               System.Environment.NewLine + " Lỗi: " + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
             public XmlDocument xmlMaChuSuDung(DataGridView  grd)
             {
                 /* Chắc chắn rằng Tồn tại danh sách mã thửa đất */
                 //if (grd.RowCount == 0)
                 //{
                 //    return null;
                 //}
                 // Tạo một tài liệu mới rỗng.
                 XmlDocument doc = new XmlDocument();
                 // Tạo và chèn một phần tử mới.
                 XmlNode nodeRoot = doc.CreateElement("root");
                 doc.AppendChild(nodeRoot);

                 XmlNode nodeChuSuDung;
                 XmlNode nameNode;

                 for (int i = 0; i < grd.RowCount; i++)
                 {
                     // Tạo một phần tử lồng bên trong (cùng với một đặc tính).
                     nodeChuSuDung = doc.CreateElement("MaChus");
                     nodeRoot.AppendChild(nodeChuSuDung);
                     // Tạo và thêm các phần tử con cho nút này
                     // (cùng với dữ liệu text).
                     nameNode = doc.CreateElement("MaChu");
                     nameNode.AppendChild(doc.CreateTextNode(grd.Rows[i].Cells["machu"].Value.ToString()));
                     nodeChuSuDung.AppendChild(nameNode);
                 }
                 return doc;
             }
             private void grdvwDangKyBienDong_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
             {
                 try
                 {
                     if (e.RowIndex >= 0)
                     {
                         /* Xác định Mã hồ sơ cấp phát */
                         strMaHoSoCapGCN = dtDangKyBienDong.Rows[e.RowIndex]["MaHoSoCapGCN"].ToString();
                         /* Khởi tạo đối tượng DataTable chứa bản ghi (Thông tin hồ sơ cấp phát) được lựa chọn */
                         dtDangKyBienDongSelect = new DataTable();
                         /* Copy định dạng của đối tượng dt... vào đối  
                          tượng DataTable chứa bản ghi (Thông tin hồ sơ cấp phát) được lựa chọn */
                         dtDangKyBienDongSelect = dtDangKyBienDong.Clone();
                         /* Add bản những hồ sơ cấp phát được lựa chọn vào biến kiểu DataTable dùng chung */
                         dtDangKyBienDongSelect.ImportRow(dtDangKyBienDong.Rows[e.RowIndex]);
                     }
                 }
                 catch (Exception ex)
                 {
                     System.Windows.Forms.MessageBox.Show(this, "Lỗi: " + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }
             }

             private void btnThuTu_Click(object sender, EventArgs e)
             {
                 try
                 {
                     int intThuTuHoSoBienDongLonNhat = 0;
                     clsDangKyBienDong DangKyBienDong = new clsDangKyBienDong();
                     DataTable dtThuTuHoSoBienDongLonNhat = new DataTable();
                     DangKyBienDong.Connection = strConnection;
                     dtDangKyBienDong = DangKyBienDong.SelectThuTuHoSoBienDongLonNhats();
                     if (dtDangKyBienDong.Rows.Count > 0)
                     {
                         intThuTuHoSoBienDongLonNhat = Int32.Parse(dtDangKyBienDong.Rows[0]["ThuTuHoSoBienDong"].ToString());
                         int ThuTu = 0;
                         ThuTu = intThuTuHoSoBienDongLonNhat + 1;
                         numThuTuHoSoBienDong.Text  = ThuTu .ToString();
                         
                     }
                     else {
                         numThuTuHoSoBienDong.Text = "1";
                     
                     }
                 }
                 catch (Exception ex)
                 {
                     strError = ex.Message;
                     MessageBox.Show(this, " Đăng ký biến động " + System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + strError, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
             }

             private void btnMaBienDong_Click(object sender, EventArgs e)
             {
                 try
                     {
                         //Khai báo và khởi tạo Form chứa điều khiển Bảng mã
                         frmBangMa frm = new frmBangMa();
                         //Nhận chuỗi kết nối cơ sở dữ liệu
                         frm.ctrlTuDienLoaiHinhBienDong.Connection = strConnection;
                         frm.ctrlTuDienLoaiHinhBienDong.DonViDangKy = this.txtMaCoQuanChinhLyGCN.Text;
                         //frm.ctrlBangMa.t = "Bảng mã loại hình biến động";
                         frm.ShowDialog();
                         if (frm.ctrlTuDienLoaiHinhBienDong.KyHieu != "")
                         {
                             //Hien thi tab bien dong chi tiet
                             /* Hiển thị Mã biến động */
                             this.txtMaBienDong.Text = frm.ctrlTuDienLoaiHinhBienDong.KyHieu;
                             //Hien thi Noi dung bien dong len 4 quyen so va mat 4 giay chung nhan
                             this.txtSoBienDong.Text = " " + frm.ctrlTuDienLoaiHinhBienDong.NoiDungGhiSo;
                             this.txtSoCapGCN.Text = " " + frm.ctrlTuDienLoaiHinhBienDong.NoiDungGhiSo;
                             this.txtSoDiaChinh.Text = " " + frm.ctrlTuDienLoaiHinhBienDong.NoiDungGhiSo;
                             this.txtSoMucKe.Text = " " + frm.ctrlTuDienLoaiHinhBienDong.NoiDungGhiSo;
                             this.txtMatBonGCN.Text = " " + frm.ctrlTuDienLoaiHinhBienDong.NoiDungGhiSo;
                             frm.ctrlTuDienLoaiHinhBienDong.KyHieu = "";
                             frm.ctrlTuDienLoaiHinhBienDong.MoTa = "";
                         }
                         else {
                             //Hien thi tab bien dong chi tiet
                         }
                     }
                     catch (Exception ex)
                     {
                         strError = ex.Message;
                         MessageBox.Show(this, " Đăng ký biến động " + System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + strError, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
           
             }

             private void btnMaCoQuanThucHien_Click(object sender, EventArgs e)
             {
                 this.txtMaBienDong.Text = "";
                 try
                 {
                     //Khai báo và khởi tạo Form chứa điều khiển Bảng mã cơ quan thực hiện
                     frmMaCoQuanThucHien frmma = new frmMaCoQuanThucHien();
                     //Nhận chuỗi kết nối cơ sở dữ liệu
                     frmma.ctrlMaCoQuanThucHien.Connection = strConnection;
                     frmma.ctrlMaCoQuanThucHien.ShowData();
                     frmma.ShowDialog();
                     if (frmma.ctrlMaCoQuanThucHien.KyHieu != "")
                     {
                         /* Hiển thị Mã biến động */
                         this.txtMaCoQuanChinhLyGCN.Text = frmma.ctrlMaCoQuanThucHien.KyHieu;
                         this.KyHieu = frmma.ctrlMaCoQuanThucHien.KyHieu;
                         frmma.ctrlMaCoQuanThucHien.KyHieu = "";
                         frmma.ctrlMaCoQuanThucHien.MoTa = "";
                     }
                 }
                 catch (Exception ex)
                 {
                     strError = ex.Message;
                     MessageBox.Show(this, " Đăng ký biến động " + System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + strError, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
             }

             private void chkchon_CheckedChanged(object sender, EventArgs e)
             {
                 if (chkchon.Checked)
                 {
                     radInMat3.Visible = true;
                     radInMat4.Visible = true; 
                 }
                 else{
                     radInMat3.Visible = false ;
                     radInMat4.Visible = false ;             
                  }
             }

            
             public void CheckLoaiBienDong() { 
                if (dhkLoaiBienDong.Checked)
                 {
                     dhkLoaiBienDong.Text = "Biến động một phần";
                     numDienTich.Enabled = true;
                     chkInChuChuyenNhuong.Visible = false;
                     chkInChuChuyenNhuong.Checked = false;
                     cmdTaoHoSoMoi.Enabled = false ;
                     txtDienTichChuyenDich.Text = "";
                 }
                 else {
                     dhkLoaiBienDong.Text = "Biến động toàn phần";
                     numDienTich.Enabled = false ;
                    chkInChuChuyenNhuong.Visible=true;
                    cmdTaoHoSoMoi.Enabled = true;
                    txtDienTichChuyenDich.Text = "";
                 }
             }
             private void cmdTongHopNoiDungBienDong_Click(object sender, EventArgs e)
             {
                 string str = "";
                 string strCSD = "";
                 string strChuTheChap = "";
                 clsDangKyBienDong cls = new clsDangKyBienDong();
                 cls.Connection = strConnection;
                 cls.MaThuaDat = strMaThuaDat;
                 cls.MaHoSoCapGCN = strMaHoSoCapGCN;
                 DataTable dt = new DataTable();
                 cls.SelectThongTinDat(dt);
                 string strNoiDungDat = "";
                 if (dt.Rows.Count > 0)
                 {
                     strNoiDungDat = "Thửa đất " + dt.Rows[0]["SoThua"].ToString() + " thuộc tờ bản đồ số " + dt.Rows[0]["ToBanDo"].ToString() + " tại " + dt.Rows[0]["DiaChi"].ToString();
                 }
               
                 // lấy thông tin người đc chuyển nhượng
                     for (int i = 0; i < grdChuNhanChuyenNhuong.Rows.Count; i++)
                     {
                         string QuanHe = "";
                         string HoTen = "";
                         string NamSinh = "";
                         string SoCMT = "";
                         string HKTT = "";
                         if (grdChuNhanChuyenNhuong.Rows[i].Cells["QuanHe"].Value.ToString() != "")
                         {
                             QuanHe = grdChuNhanChuyenNhuong.Rows[i].Cells["QuanHe"].Value.ToString();
                         }
                         if (grdChuNhanChuyenNhuong.Rows[i].Cells["HoTen"].Value.ToString() != "")
                         {
                             HoTen = grdChuNhanChuyenNhuong.Rows[i].Cells["HoTen"].Value.ToString();
                         }
                         if (grdChuNhanChuyenNhuong.Rows[i].Cells["NamSinh"].Value.ToString() != "")
                         {
                             NamSinh = ", sinh năm " +  grdChuNhanChuyenNhuong.Rows[i].Cells["NamSinh"].Value.ToString();
                         }
                         if (grdChuNhanChuyenNhuong.Rows[i].Cells["SoDinhDanh"].Value.ToString() != "")
                         {
                             SoCMT = ", CMND số " + grdChuNhanChuyenNhuong.Rows[i].Cells["SoDinhDanh"].Value.ToString();
                         }
                         if (grdChuNhanChuyenNhuong.Rows[i].Cells["DiaChi"].Value.ToString() != "")
                         {
                             HKTT = ", HKTT tại " +  grdChuNhanChuyenNhuong.Rows[i].Cells["DiaChi"].Value.ToString();
                         }


                         if (i == 0)
                         {
                             strCSD = strCSD + QuanHe  + " " + HoTen  + NamSinh  + SoCMT  + HKTT ; 
                         }
                         else
                         {
                             if (i == grdChuNhanChuyenNhuong.Rows.Count - 1)
                             {
                                 strCSD = strCSD + " và " + QuanHe + " " + HoTen + NamSinh + SoCMT + HKTT; 
                             }
                             else
                             {
                                 strCSD = strCSD + ", " + QuanHe + " " + HoTen + NamSinh + SoCMT + HKTT; 
                             }
                         }
                        
                         
                     } 

                 //trường hợp chuyển nhượng
                 if (cboLoaiBienDong.SelectedValue.ToString().ToUpper()=="CN")//(this.txtMaBienDong.Text != "TC" && this.txtMaBienDong.Text != "XC")
                 {
                    if (dhkLoaiBienDong.Checked)
                         {
                             str = strNoiDungDat + " đã được ..... quyền sử dụng " + numDienTich.Value + " m2 đất ở đô thị sang " + strCSD + " theo hợp đồng ..... quyền sử dụng đất và tài sản gắn liền với đất số " + txtSoHopDong.Text + " ngày " + dtpNgayHopDong.Text + " do " + txtCoQuanCongChung.Text + ", Tp Hà Nội công chứng./.";
                         }
                         else
                         {
                             str = "Chủ sử dụng đất nay là " + strCSD + " theo hợp đồng ..... quyền sử dụng đất số " + txtSoHopDong.Text + " ngày " + dtpNgayHopDong.Text + " do " + txtCoQuanCongChung.Text + ", Tp Hà Nội công chứng./.";
                         }

                    this.txtSoBienDong.Text = " " + str;
                    this.txtSoCapGCN.Text = " " + str;
                    this.txtSoDiaChinh.Text = " " + str;
                    this.txtSoMucKe.Text = " " + str;
                    this.txtMatBonGCN.Text = " " + str;
                 }
                     //trường hợp thế chấp bảo lãnh
                 else if (cboLoaiBienDong.SelectedValue.ToString().ToUpper()=="TCBL"){
                     string strTaiSanTC = "";
                      if (this.radioquyensdd.Checked == true)
                     { strTaiSanTC = "quyền sử dụng đất "; }
                     else if (this.radioquyensdvats.Checked == true)
                     { strTaiSanTC = "quyền sử dụng đất và tài sản gắn liền với đất "; }
                     else if (this.radiotaisangandat.Checked == true)
                     { strTaiSanTC = "tài sản gắn với đất "; }
                     if (txtHoTenNguoiTheChap.Text != "")
                     {
                         strChuTheChap =  txtHoTenNguoiTheChap.Text;
                     }
                     if (txtSoDinhDanhNguoiTC.Text  != "")
                     {
                         strChuTheChap = strChuTheChap + " Số ĐK " + txtSoDinhDanhNguoiTC.Text;
                     }
                     if (dtpNgayCapSoDinhDanh.Checked  )
                     {
                         strChuTheChap = strChuTheChap + " ngày " + dtpNgayCapSoDinhDanh.Text;
                     }
                     if (txtDiaChiNguoiTC.Text != "")
                     {
                         strChuTheChap = strChuTheChap + " tại địa chỉ " + txtDiaChiNguoiTC.Text;
                     }
                    
                      if (this.checkTheChap.Checked == true)
                      {
                          //strNoiDungDat = strNoiDungDat + " đã được thế chấp cho " + strChuTheChap + " theo số công chứng: " + this.txtSoCongChung.Text + " ngày " + this.dtpNgayCongChung.Text + " của số hợp đồng " + this.txtSoHopDong.Text + " ngày " + this.dtpNgayHopDong.Text + " với loại tài sản thế chấp là " + strTaiSanTC;
                          // bỏ nội dung thông tin thửa đất
                          strNoiDungDat =" Đã được thế chấp cho " + strChuTheChap + " theo số công chứng: " + this.txtSoCongChung.Text + " ngày " + this.dtpNgayCongChung.Text + " của số hợp đồng " + this.txtSoHopDong.Text + " ngày " + this.dtpNgayHopDong.Text + " với loại tài sản thế chấp là " + strTaiSanTC + " theo hồ sơ số....";
                      }
                      if (this.checkBaoLanh.Checked == true)
                      {
                          strNoiDungDat = strNoiDungDat + " đã được " + strChuTheChap + " theo số công chứng: " + this.txtSoCongChung.Text + " ngày " + this.dtpNgayCongChung.Text + " của số hợp đồng " + this.txtSoHopDong.Text + " ngày " + this.dtpNgayHopDong.Text + " bảo lãnh về " + strTaiSanTC;
                      }

                      //if (this.checkTheChap.Checked == true)
                      //   {
                      //       strNoiDungDat = strNoiDungDat + " đã được thế chấp cho " + this.textnguoinhantc.Text + " địa chỉ: " + this.DiachinguoiTC.Text + " Số công chứng: " + this.texSoCongChung.Text + " ngày công chứng " + this.textNgayCongChung.Text + "số hợp đồng là " + this.textSoHopDong.Text +" ngày hợp đồng " +this.textNgayHopDong .Text + " với loại tài sản thế chấp là " + strTaiSanTC;
                      //   }
                      //   if (this.checkBaoLanh.Checked == true)
                      //   {
                      //       strNoiDungDat = strNoiDungDat + " đã được " + this.textnguoinhantc.Text + " địa chỉ: " + this.DiachinguoiTC.Text + " Số công chứng: " + this.texSoCongChung.Text + " ngày công chứng " + this.textNgayCongChung.Text +"số hợp đồng là " + this.textSoHopDong.Text + " ngày hợp đồng " + this.textNgayHopDong.Text  + " bảo lãnh về " + strTaiSanTC;
                      //   }

                      this.txtSoBienDong.Text = " " + strNoiDungDat;
                      this.txtSoCapGCN.Text = " " + strNoiDungDat;
                      this.txtSoDiaChinh.Text = " " + strNoiDungDat;
                      this.txtSoMucKe.Text = " " + strNoiDungDat;
                      this.txtMatBonGCN.Text = " " + strNoiDungDat;
                 }
                 // tổng hợp nội dung 


               

               
             }

             private void cmdLayDuLieu_Click(object sender, EventArgs e)
             {
                 //clsDangKyBienDong cls = new clsDangKyBienDong();
                 //cls.Connection = strConnection;
                 //cls.MaThuaDat = strMaThuaDat;
                 //cls.MaHoSoCapGCN = strMaHoSoCapGCN;
                 //DataTable dt = new DataTable();
                 //cls.SelectThongTinDat(dt);
                 //if (dt.Rows.Count > 0)
                 //{ 
                 //   txtNoiDungDat.Text  ="Thửa đất "+ dt.Rows[0]["SoThua"].ToString() +" thuộc tờ bản đồ số "+ dt.Rows[0]["ToBanDo"].ToString() +" tại "+ dt.Rows[0]["DiaChi"].ToString() ;
                 //}

             }

             private void dhkLoaiBienDong_CheckedChanged(object sender, EventArgs e)
             {
                 CheckLoaiBienDong(); ;
             }

             private void dmcNguoiNhanChuyenNhuong_Click(object sender, EventArgs e)
             {
                 frmNguoiNhanChuyenNhuong frm = new frmNguoiNhanChuyenNhuong();

                 //Gán chuỗi kết nối cơ sở dữ liệu
                 frm.ctrlChuCQNN1.Connection = strConnection;
                 frm.ctrlChuCQNN1.MaHoSoCapGCN = strMaHoSoCapGCN;
                 frm.ctrlChuCQNN1.TenPhuong = strTenPhuong;
                  frm.ctrlChuCQNN1.MaDonViHanhChinh=strMaDonViHanhChinh ;
                 //Thiết lập chế độ active/unactive các chức năng
                 frm.ctrlChuCQNN1.TrangThaiChucNang(false, false);
                 frm.ctrlChuCQNN1.ShowData();

                 //Gán chuỗi kết nối cơ sở dữ liệu
                 frm.ctrlChuGDCN1.Connection = strConnection;
                 frm.ctrlChuGDCN1.MaHoSoCapGCN = strMaHoSoCapGCN;
                 frm.ctrlChuGDCN1.TenPhuong = strTenPhuong;
                 frm.ctrlChuGDCN1.MaDonViHanhChinh = strMaDonViHanhChinh;
                 //Thiết lập chế độ active/unactive các chức năng
                 frm.ctrlChuGDCN1.TrangThaiChucNang(false, false);
                 frm.ctrlChuGDCN1.ShowData();

                 //Gán chuỗi kết nối cơ sở dữ liệu
                 frm.ctrlChuTCDN1.Connection = strConnection;
                 frm.ctrlChuTCDN1.MaHoSoCapGCN = strMaHoSoCapGCN;
                 frm.ctrlChuTCDN1.TenPhuong = strTenPhuong;
                 frm.ctrlChuTCDN1.MaDonViHanhChinh = strMaDonViHanhChinh;
                 //Thiết lập chế độ active/unactive các chức năng
                 frm.ctrlChuTCDN1.TrangThaiChucNang(false, false);
                 frm.ctrlChuTCDN1.ShowData();
                 frm.ShowDialog();

                 DataTable dt = new DataTable();
                 dt.Columns.Clear();
                 grdChuNhanChuyenNhuong.Columns.Clear();
                 for (int i = 0; i < frm.ctrlChuGDCN1.grdChuDuocChon.ColumnCount; i++)
                 {
                     dt.Columns.Add(frm.ctrlChuGDCN1.grdChuDuocChon.Columns[i].Name);
                    // grdChuNhanChuyenNhuong.Columns.Add(frm.ctrlChuGDCN1.grdvwChu.Columns[i].Name, frm.ctrlChuGDCN1.grdvwChu.Columns[i].HeaderText);
                 }
                 for (int i = 0; i < frm.ctrlChuGDCN1.grdChuDuocChon.RowCount; i++)
                 { 
                     dt.Rows.Add();
                      for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            dt.Rows[dt.Rows.Count - 1][k] = frm.ctrlChuGDCN1.grdChuDuocChon.Rows[i].Cells[k].Value;
                        } 
                 }
                 for (int i = 0; i < frm.ctrlChuTCDN1.grdvwChu.RowCount - 1; i++)
                 {
                     if (frm.ctrlChuTCDN1.grdvwChu.Rows[i].Cells["Chon"].Value.ToString()  == "True")
                     {
                         dt.Rows.Add();
                         for (int k = 0; k < dt.Columns.Count; k++)
                         {
                             dt.Rows[dt.Rows.Count - 1][k] = frm.ctrlChuTCDN1.grdvwChu.Rows[i].Cells[k].Value;
                         }
                     }
                 }
                 for (int i = 0; i < frm.ctrlChuCQNN1.grdvwChu.RowCount - 1; i++)
                 {
                     if (frm.ctrlChuCQNN1.grdvwChu.Rows[i].Cells["Chon"].Value.ToString() == "True")
                     {
                         dt.Rows.Add();
                         for (int k = 0; k < dt.Columns.Count; k++)
                         {
                             dt.Rows[dt.Rows.Count - 1][k] = frm.ctrlChuCQNN1.grdvwChu.Rows[i].Cells[k].Value;
                         }
                     }
                 }
                 grdChuNhanChuyenNhuong.DataSource = dt;
                 FormatGridContruction(grdChuNhanChuyenNhuong);
                     
             }

            private void  FormatGridContruction(DataGridView grdvw )
            {
        try 
        {
            //Ẩn tất cả các cột
            this.HideAllColumns(grdChuNhanChuyenNhuong);
            //Chỉ hiển thị những Cột cần thiết
            
              //  'Kiểm tra xem nếu có cột chọn thì Hiển thị lên
                if  (grdvw.Columns.Contains("Chon")) 
            {
                grdChuNhanChuyenNhuong.Columns["MaChu"].HeaderText = "Mã chủ";
                grdChuNhanChuyenNhuong.Columns["MaChu"].Width = 100;
                grdChuNhanChuyenNhuong.Columns["MaChu"].Visible = false;
                grdChuNhanChuyenNhuong.Columns["MaChu"].DisplayIndex = 0;
                grdChuNhanChuyenNhuong.Columns["MaChu"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    
            }
               // 'Họ tên
                if (grdChuNhanChuyenNhuong.Columns.Contains("HoTen")) 
            {
                grdChuNhanChuyenNhuong.Columns["HoTen"].HeaderText = "Tên";
                grdChuNhanChuyenNhuong.Columns["HoTen"].Width = 200;
                grdChuNhanChuyenNhuong.Columns["HoTen"].Visible = true;
                grdChuNhanChuyenNhuong.Columns["HoTen"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

                if (grdChuNhanChuyenNhuong.Columns.Contains("DiaChi"))
                {
                    grdChuNhanChuyenNhuong.Columns["DiaChi"].HeaderText = "Địa chỉ";
                    grdChuNhanChuyenNhuong.Columns["DiaChi"].Width = 200;
                    grdChuNhanChuyenNhuong.Columns["DiaChi"].Visible = true;
                    grdChuNhanChuyenNhuong.Columns["DiaChi"].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if (grdChuNhanChuyenNhuong.Columns.Contains("DiaChi"))
                {
                    grdChuNhanChuyenNhuong.Columns["SoDinhDanh"].HeaderText = "Số định danh (CMT ,Số đăng ký)";
                    grdChuNhanChuyenNhuong.Columns["SoDinhDanh"].Width = 300;
                    grdChuNhanChuyenNhuong.Columns["SoDinhDanh"].Visible = true;
                    grdChuNhanChuyenNhuong.Columns["SoDinhDanh"].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if (grdChuNhanChuyenNhuong.Columns.Contains("DiaChi"))
                {
                    //'Ngày cấp định danh 1
                        grdChuNhanChuyenNhuong.Columns["NgayCap"].HeaderText = "Ngày cấp";
                        grdChuNhanChuyenNhuong.Columns["NgayCap"].Width = 150;
                        grdChuNhanChuyenNhuong.Columns["NgayCap"].Visible = true;
                        grdChuNhanChuyenNhuong.Columns["NgayCap"].SortMode = DataGridViewColumnSortMode.NotSortable;
                     }
                if (grdChuNhanChuyenNhuong.Columns.Contains("DiaChi"))
                {
                         //'Nơi cấp định danh 1
                        grdChuNhanChuyenNhuong.Columns["NoiCap"].HeaderText = "Nơi cấp";
                        grdChuNhanChuyenNhuong.Columns["NoiCap"].Width = 150;
                        grdChuNhanChuyenNhuong.Columns["NoiCap"].Visible = true;
                        grdChuNhanChuyenNhuong.Columns["NoiCap"].SortMode = DataGridViewColumnSortMode.NotSortable;
                       
                     
                }

               
                grdChuNhanChuyenNhuong.AllowUserToAddRows = false;
                grdChuNhanChuyenNhuong.AllowUserToDeleteRows = false;
                grdChuNhanChuyenNhuong.GridColor = Color.WhiteSmoke;
                grdChuNhanChuyenNhuong.BorderStyle =BorderStyle.Fixed3D ; 
                grdChuNhanChuyenNhuong.RowHeadersVisible = false;
                grdChuNhanChuyenNhuong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdChuNhanChuyenNhuong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }
        catch (Exception ex){
            MessageBox.Show (" Danh sách Chủ tìm được", "DMCLand",MessageBoxButtons.OK );
        }
            }

         private void  HideAllColumns(DataGridView grdvw  ){
            //'Ẩn tất cả các cột trên Grid
            
                for (int i = 0;i < grdvw.Columns.Count ; i ++)
                {
                    grdvw.Columns[i].Visible = false;
                }
                grdvw.RowHeadersVisible = false;
            
        }
 

         private void richTextBox1_TextChanged(object sender, EventArgs e)
         {

         }

         private void checkTheChap_Click(object sender, EventArgs e)
         {
             if (checkBaoLanh.Checked == true)
             {
                 checkBaoLanh.Checked = false;
             }
            
         }

         private void checkBaoLanh_Click(object sender, EventArgs e)
         {
             if (checkTheChap.Checked == true )
             {
                 checkTheChap.Checked = false;
             }
            

         }

         private void groupBienDongMotPhan_Enter(object sender, EventArgs e)
         {

         }

         private void btnTraCuu_Click(object sender, EventArgs e)
         {
            if ((strMaHoSoCapGCN == "") && (strMaHoSoCapGCN == "0"))
            {
                return;
            }
            frmLichSuBD frm = new frmLichSuBD();  
                frm.ctrLichSuHSBienDong1.Connection = strConnection;
               frm.ctrLichSuHSBienDong1 .MaHoSoCapGCN = strMaHoSoCapGCN;
                frm.ctrLichSuHSBienDong1.MaThuaDat = strMaThuaDat;
                frm.ctrLichSuHSBienDong1.MaDonViHanhChinh = strMaDonViHanhChinh ;
                frm.ctrLichSuHSBienDong1.ShowData();
                frm.ShowDialog();
         }

         private void DTPNgayGioDangKy_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 btnThuTu.Focus();
             }
         }

         private void btnThuTu_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 numThuTuHoSoBienDong.Focus();
             }
         }

         private void numThuTuHoSoBienDong_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
               
                 txtTenNguoiDangKy.Focus();
             }
         }

         private void txtTenNguoiDangKy_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 txtSoCMTNDNguoiDangKy.Focus();
             }
         }

         private void txtSoCMTNDNguoiDangKy_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 txtDiaChiNguoiDangKy.Focus();
             }
         }

         private void txtDiaChiNguoiDangKy_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 btnMaCoQuanThucHien.Focus();
             }
         }

         private void btnMaCoQuanThucHien_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 txtMaCoQuanChinhLyGCN.Focus();
             }
         }

         private void txtMaCoQuanChinhLyGCN_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 btnMaBienDong.Focus();
             }
         }

         private void btnMaBienDong_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 txtMaBienDong.Focus();
             }
         }

         private void txtMaBienDong_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 cmbLoaiThoiHanBienDong.Focus();
             }
         }

         private void cmbLoaiThoiHanBienDong_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 DTPNgayBatDau.Focus();
             }
         }

         private void DTPNgayBatDau_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 DTPNgayKetThuc.Focus();
             }
         }

         private void DTPNgayKetThuc_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 txtGhiChu.Focus();
             }
         }

         private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 dhkLoaiBienDong.Focus();
             }
         }

         private void dhkLoaiBienDong_KeyDown(object sender, KeyEventArgs e)
         {
             //if (e.KeyValue == 13)
             //{
             //    cmdLayDuLieu.Focus();
             //}
         }

         private void cmdLayDuLieu_KeyDown(object sender, KeyEventArgs e)
         {
             //if (e.KeyValue == 13)
             //{
             //    txtNoiDungDat.Focus();
             //}
         }

         private void txtNoiDungDat_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 numDienTich.Focus();
             }
         }

         private void numDienTich_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 mDtChung.Focus();
             }
         }

         private void mDtChung_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 mDtRieng.Focus();
             }
         }

         private void mDtRieng_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 dmcNguoiNhanChuyenNhuong.Focus();
             }
         }

         private void dmcNguoiNhanChuyenNhuong_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 chkInChuChuyenNhuong.Focus();
             }
         }

         private void chkInChuChuyenNhuong_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 txtSoHopDong.Focus();
             }
         }

         private void txtSoHopDong_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 dtpNgayHopDong.Focus();
             }
         }

         private void dtpNgayHopDong_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 txtCoQuanCongChung.Focus();
             }
         }

         private void txtCoQuanCongChung_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 cmdTongHopNoiDungBienDong.Focus();
             }
         }
 
         private void textNgayCongChung_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 checkTheChap.Focus();
             }
         }

         private void checkTheChap_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 checkBaoLanh.Focus();
             }
         }
 
        
         private void textNgayHopDong_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 radioquyensdd.Focus();
             }
         }

         private void radioquyensdd_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 radiotaisangandat.Focus();
             }
         }

         private void radiotaisangandat_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 radioquyensdvats.Focus();
             }
         }
 
         private void richTextTC_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue == 13)
             {
                 
             }
         }

         private void cmdTongHopNoiDungBienDong_KeyDown(object sender, KeyEventArgs e)
         {

         }

         private void txtSoBienDong_KeyDown(object sender, KeyEventArgs e)
         {

         }

         private void chkLuuHoSo_KeyDown(object sender, KeyEventArgs e)
         {

         }

         private void chkchon_KeyDown(object sender, KeyEventArgs e)
         {

         }
         public bool CheckTaoHoSoCHuyenNhuong()
         {
             bool kt = false;
             clsDangKyBienDong cls = new clsDangKyBienDong();
             cls.Connection = strConnection;
             cls.MaHoSoCapGCN = strMaHoSoCapGCN;
             cls.MaDangKyBienDong = strMaDangKyBienDong;
             DataTable dt = new DataTable();
             cls.SelCheckTaoHoSoMoi(dt);
             if (dt.Rows.Count > 0)
             {
                 if (dt.Rows[0][0].ToString() == "True")
                 {
                     kt = false ;
                 }
                 else {
                     kt = true ;
                 }
             }
             return kt;
         }
         private void cmdTaoHoSoMoi_Click(object sender, EventArgs e)
         {
             if (grdChuNhanChuyenNhuong.RowCount > 0)
             {
                 if (strMaDangKyBienDong != "")
                 {
                     if (CheckTaoHoSoCHuyenNhuong())
                     {
                         clsDangKyBienDong cls = new clsDangKyBienDong();
                         cls.Connection = strConnection;
                         cls.MaHoSoCapGCN = strMaHoSoCapGCN;
                         cls.MaDangKyBienDong = strMaDangKyBienDong;

                         cls.MaThuaDat = strMaThuaDat; 
                         DataTable dt = new DataTable();
                         cls.SelectThongTinDat(dt);
                         string strNoiDungDat = "";
                         if (dt.Rows.Count > 0)
                         {
                             strNoiDungDat = "Thửa đất " + dt.Rows[0]["SoThua"].ToString() + " thuộc tờ bản đồ số " + dt.Rows[0]["ToBanDo"].ToString() + " tại " + dt.Rows[0]["DiaChi"].ToString();
                         }


                         string str = "";
                         cls.TaoHoSoMoiVoiChuChuyenNhuongMoi(ref str);
                         cls.DaThucHienTaoHoSoMoi(ref str);

                         NhatKyNguoiDung("Tạo hồ sơ mới từ phần biến động", "Tạo hồ sơ:  " + strMaHoSoCapGCN + ". Với của thửa đất:  " + strNoiDungDat + " . Với nội dung biến động: " + txtSoBienDong.Text);

                         MessageBox.Show(this, "Thành công!!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     else
                     {

                         MessageBox.Show(this, "Hồ sơ đã được tạo mới một lần !!!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         return;
                     }
                 }
             }
         }

         private void txtDienTichChuyenDich_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.F7)
             {
                 if (dhkLoaiBienDong.Checked)
                 {
                     txtDienTichChuyenDich.Text = "Diện tích đất ở sử dụng riêng chuyển dịch là " + mDtRieng.Value.ToString() + " m2 giới hạn bởi các điểm ....... và " + mDtChung.Value.ToString() + " m2 ngõ đi chung giới hạn bởi các điểm ....... theo Hồ sơ kỹ thuật thửa đất số ...../HSKT do Công ty Cp khảo sát và đo đạc địa chính lập ngày ../../20..";
                 }
                 else 
                 {
                     clsDangKyBienDong cls = new clsDangKyBienDong();
                     cls.Connection = strConnection;
                     cls.MaThuaDat = strMaThuaDat;
                     cls.MaHoSoCapGCN = strMaHoSoCapGCN;
                     DataTable dt = new DataTable();
                     cls.SelectThongTinDat(dt);
                     if (dt.Rows.Count > 0)
                     {
                         txtDienTichChuyenDich.Text = "Thửa đất số: " + dt.Rows[0]["SoThua"].ToString() + "  ; Tờ bản đồ số: " + dt.Rows[0]["ToBanDo"].ToString() + "  ;Diện tích: " + dt.Rows[0]["DienTich"].ToString()  + " m2;";
                     }                    
                 
                 }
             }
         }

         private void chkChuyenNhuongTheChap_CheckedChanged(object sender, EventArgs e)
         {
             ChuyenNhuongTheChap();
         }

         public void ChuyenNhuongTheChap()
         {
             //if (chkChuyenNhuongTheChap.Checked)
             //{
             //    chkChuyenNhuongTheChap.Text = "Chuyển nhượng";
             //    dmcNguoiNhanChuyenNhuong.Text = "Tra cứu người nhận Chuyển Nhượng";
             //    grChuyenNhuong.Enabled = true;
             //    grTheChapBaoLanh.Enabled = false;
             //}
             //else {
             //    chkChuyenNhuongTheChap.Text = "Thế chấp bảo lãnh";
             //    dmcNguoiNhanChuyenNhuong.Text = "Tra cứu người nhận Thế Chấp";
             //    grChuyenNhuong.Enabled = false;
             //    grTheChapBaoLanh.Enabled = true;
             //}
             
             string Values = "";
             Values = cboLoaiBienDong.SelectedValue.ToString().ToUpper();

             if (Values ==  "CN") {
                     grChuyenNhuong.Enabled = true;
                     grTheChapBaoLanh.Enabled = false;
                     grHopDong.Enabled = true;
             }
             else if (Values == "TCBL")
             {
                 grChuyenNhuong.Enabled = false;
                 grTheChapBaoLanh.Enabled = true;
                 grHopDong.Enabled = true;
             }
             else
             {
                 grChuyenNhuong.Enabled = false;
                 grTheChapBaoLanh.Enabled = false;
                 grHopDong.Enabled = false;
             }
         }

         private void cboLoaiBienDong_SelectedIndexChanged(object sender, EventArgs e)
         {
             ChuyenNhuongTheChap();

         }

         public void LoaiBienDong()
         {
             clsDangKyBienDong cls = new clsDangKyBienDong();
             cls.Connection = strConnection;
             DataTable dt = new DataTable();
             cls.SelThongTinLoaiBienDong(dt);
             cboLoaiBienDong.DataSource = dt;
             cboLoaiBienDong.DisplayMember = "Mota";
             cboLoaiBienDong.ValueMember = "LoaiBienDong";
         }

        }

    }




