using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DMC.Land.ThongTinTiepNhanHoSo
{
    public partial class ctrlThongTinTiepNhanHoSo : UserControl
    {
        public ctrlThongTinTiepNhanHoSo()
        {
            InitializeComponent();
        }
        ///* Định nghĩa trạng thái Tiếp nhận Hồ sơ có
        // * giá trị bằng 1 */
        //readonly int TRANG_THAI_TIEP_NHAN = 1;
        private bool blnNonNumberEntered;
        /* Khai báo biến nhận chuỗi kết nối Database */
        private string  strConnection = "" ;
        /* Khai báo biến kiểm tra lỗi */
        private string  strError = "" ; 
        ///* Khai báo biến trạng thái Hồ sơ cấp GCN */
        //private long longTrangThaiHoSoCapGCN = 0;
        /* Khai bao bien MaHoSoCapGCN dung chung */
        private string strMaHoSoTiepNhan;
        private long   longMaHoSoCapGCN = 0;
        private DataTable dtThongTinTiepNhanHoSo = new DataTable();
        private short  shortAction  = 0;
        private bool TrangThaiTiepNhan = false;
        private DataTable   dtFound;
        private string CMTCu = "";
      private   string strThongTinCu = "";

        private string strMaDonViHanhChinh = null;
        
        public string MaDonViHanhChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
        } 
        /* Khai báo thuộc tính nhận chuỗi kết nối Database */
        public string  Connection
        {
            set {strConnection = value;}
        }
        ///* Khai báo thuộc tính chỉ đọc - trạng thái
        // * Hồ sơ cấp GCN. */
        //public long TrangThaiHoSoCapGCN
        //{
        //    get { return longTrangThaiHoSoCapGCN;}
        //}
        private string MaLoaiBienDong = "";
        public string MaKhoa
        {
            set { MaLoaiBienDong = value; }
            get { return MaLoaiBienDong; }
        }
        public long   MaHoSoCapGCN
        {
            set {longMaHoSoCapGCN = value;}
            get { return longMaHoSoCapGCN;}
        }

        public void NhatKyNguoiDung(string ChucNang, string MoTa)
        {
            prjNhatKyNguoiDung.clsNhatKyNguoiDung clsNhatky = new prjNhatKyNguoiDung.clsNhatKyNguoiDung();
            clsNhatky.Connection = strConnection;
            clsNhatky.MaHoSoCapGCN = longMaHoSoCapGCN.ToString() ;
            clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh;
            clsNhatky.NghiepVu = "Chức năng tiếp nhận hồ sơ";
            clsNhatky.ChucNang = ChucNang;
            clsNhatky.MoTa = MoTa;
            clsNhatky.DuongDanFile = Application.StartupPath;
            clsNhatky.LuuNhatKyNguoiDung();
        }
        /// <summary>
        /// Phương thức xem chuỗi có phải là kiểu ngày không
        /// </summary>
        /// <param name="anyString">Chuỗi cần kiểm tra</param>
        /// <returns></returns>
        private  static bool IsDate(string anyString)//, out DateTime resultDate)
        {
            DateTime resultDate;
            bool isDate = true;

            if (anyString == null)
            {
                anyString = "";
            }
            try
            {
                resultDate = DateTime.Parse(anyString);
            }
            catch
            {
                resultDate = DateTime.MinValue;
                isDate = false;
            }

            return isDate;
        }


        /// <summary>
        /// Phương thức xem chuỗi có phải là dãy số hay không
        /// </summary>
        /// <param name="str">Chuỗi cần kiểm tra</param>
        /// <returns></returns>
        private static bool isNumberic(string str)
        {
            try
            {
                str = str.Trim();
                int foo = int.Parse(str);
                return (true);
            }
            catch (FormatException)
            {
                return (false);
            }
        }


        /*  Hien thi du lieu Phe duyet */
        public void  ShowData()
        {
            if (this.MaLoaiBienDong != "MG")
            {
                this.groupBox2.Enabled = true;
             }
            else{ this.groupBox2 .Enabled =false ;}

            /* Khai bao va khoi tao doi tuong */
             DMC.Land.ThongTinTiepNhanHoSo.clsThongTinTiepNhanHoSo  ThongTinTiepNhan = new clsThongTinTiepNhanHoSo();
             DMC.Land.ThongTinTiepNhanHoSo.clsThongTinTiepNhanHoSo ThongTinTiepNhan1 = new clsThongTinTiepNhanHoSo();
            try
            {
                /* Gan gia tri cho cac thuoc tinh doi voi truong hop truy van */
                
                /* Nhận chuỗi kết nối Database */
                ThongTinTiepNhan.Connection = strConnection;
                shortAction = 0;
                ThongTinTiepNhan.MaHoSoCapGCN = longMaHoSoCapGCN;

                

                    /*Hien thi trang thai tiep nhan ho so cap giay chung nhan*/
                    DataTable dtNguonCap = new DataTable();
                    DataTable dt = new DataTable();
                    ThongTinTiepNhan1.Connection = strConnection;
                    ThongTinTiepNhan1.MaHoSoCapGCN = longMaHoSoCapGCN;
                    ThongTinTiepNhan1.GetTrangThaiTiepNhanHS(dt);
                    ThongTinTiepNhan1.GetNguonCapHoSo(dtNguonCap);
                    if (dtNguonCap.Rows.Count >0){
                        cboNguonCapHoSo.DataSource = dtNguonCap;
                        cboNguonCapHoSo.ValueMember = "MaNguonHoSo";
                        cboNguonCapHoSo.DisplayMember = "TenNguonHoSo";
                    }

                    /* Khởi tạo trạng thái ban đầu */

                    TrangThaiBanDau();
                    /* Gọi phương thức nhận dữ liệu */
                    if (ThongTinTiepNhan.GetData(dtThongTinTiepNhanHoSo) == "")
                    {
                        /* Trình bày dữ liệu lên Form */
                        if (dtThongTinTiepNhanHoSo.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtThongTinTiepNhanHoSo.Rows.Count; i++)
                            {
                                /* Mã Hồ sơ tiếp nhận */
                                strMaHoSoTiepNhan = dtThongTinTiepNhanHoSo.Rows[i]["MaHoSoTiepNhan"].ToString();
                                /* Nơi nhận hồ sơ */
                                this.txtNoiNhanHoSo.Text = dtThongTinTiepNhanHoSo.Rows[i]["NoiNhanHoSo"].ToString();
                                /* Ngày nhận đủ hồ sơ */
                                if (!IsDate(dtThongTinTiepNhanHoSo.Rows[i]["NgayNhanDuHoSo"].ToString()))
                                {
                                    this.dtpNgayNhanDuHoSo.Value = DateTime.Now;
                                    this.dtpNgayNhanDuHoSo.Checked = false;
                                }
                                else
                                {
                                    this.dtpNgayNhanDuHoSo.Value = Convert.ToDateTime(dtThongTinTiepNhanHoSo.Rows[i]["NgayNhanDuHoSo"].ToString());
                                    this.dtpNgayNhanDuHoSo.Checked = true;
                                }

                                /* Ngày tiếp nhận */
                                if (!IsDate(dtThongTinTiepNhanHoSo.Rows[i]["ThoiDiemTiepNhan"].ToString()))
                                {
                                    this.dtpThoiDiemTiepNhan.Value = DateTime.Now;
                                    this.dtpThoiDiemTiepNhan.Checked = false;
                                }
                                else
                                {
                                    this.dtpThoiDiemTiepNhan.Value = Convert.ToDateTime(dtThongTinTiepNhanHoSo.Rows[i]["ThoiDiemTiepNhan"].ToString());
                                    this.dtpThoiDiemTiepNhan.Checked = true;
                                }

                                /* Số hồ sơ */
                                this.txtSoHoSoTiepNhan.Text = dtThongTinTiepNhanHoSo.Rows[i]["SoHoSoTiepNhan"].ToString();
                                /* Số thứ tự hồ sơ */
                                this.txtThuTuTiepNhan.Text = dtThongTinTiepNhanHoSo.Rows[i]["ThuTuTiepNhan"].ToString();

                                this.txtTenNguoiTiepNhan.Text = dtThongTinTiepNhanHoSo.Rows[i]["TenNguoiTiepNhan"].ToString();
                                this.txtTenNguoiDiKeKhai.Text = dtThongTinTiepNhanHoSo.Rows[i]["TenNguoiDiKeKhai"].ToString();
                                this.cmbQuanHe.Text = dtThongTinTiepNhanHoSo.Rows[i]["QuanHe"].ToString();
                                this.cboDinhDanh.Text = dtThongTinTiepNhanHoSo.Rows[i]["DinhDanh"].ToString();
                                this.txtCMTNguoiDiKeKhai.Text = dtThongTinTiepNhanHoSo.Rows[i]["CMTNguoiDiKeKhai"].ToString();
                                CMTCu = dtThongTinTiepNhanHoSo.Rows[i]["CMTNguoiDiKeKhai"].ToString();
                                if (!IsDate(dtThongTinTiepNhanHoSo.Rows[i]["NgayCap"].ToString()))
                                {
                                    this.dtpNgayCap.Value = DateTime.Now;
                                    this.dtpNgayCap.Checked = false;
                                }
                                else
                                {
                                    this.dtpNgayCap.Value = Convert.ToDateTime(dtThongTinTiepNhanHoSo.Rows[i]["NgayCap"].ToString());
                                    this.dtpNgayCap.Checked = true;
                                }
                                this.txtNoiCap.Text = dtThongTinTiepNhanHoSo.Rows[i]["noiCap"].ToString();
                                this.txtSoDienThoaiNguoiDiKeKhai.Text = dtThongTinTiepNhanHoSo.Rows[i]["SoDienThoaiNguoiDiKeKhai"].ToString();
                                this.txtDiaChiNguoiDiKeKhai.Text = dtThongTinTiepNhanHoSo.Rows[i]["DiaChiNguoiDiKeKhai"].ToString();
                                this.txtNguoiVietDon.Text = dtThongTinTiepNhanHoSo.Rows[i]["NguoiVietDon"].ToString();
                                if (dtThongTinTiepNhanHoSo.Rows[i]["MaNguonHoSo"].ToString() != "")
                                {
                                    int mahs = Convert.ToInt16( dtThongTinTiepNhanHoSo.Rows[i]["MaNguonHoSo"]);
                                    this.cboNguonCapHoSo.SelectedValue  = mahs;
                                }
                                /* Thời điểm Viết đơn */
                                if (!IsDate(dtThongTinTiepNhanHoSo.Rows[i]["ThoiDiemVietDon"].ToString()))
                                {
                                    this.dtpThoiDiemVietDon.Value = DateTime.Now;
                                    this.dtpThoiDiemVietDon.Checked = false;
                                }
                                else
                                {
                                    this.dtpThoiDiemVietDon.Value = Convert.ToDateTime(dtThongTinTiepNhanHoSo.Rows[i]["ThoiDiemVietDon"].ToString());
                                    this.dtpThoiDiemVietDon.Checked = true;
                                }

                                if (dtThongTinTiepNhanHoSo.Rows[i]["isChu_NguoiDaiDien"].ToString().ToUpper() == "True".ToUpper())
                                {
                                    radNguoiDaiDien.Checked = true;
                                }
                                else
                                {
                                    radChuSuDung.Checked = true;
                                }

                            } TrangThaiTiepNhan = true;
                        }

                        else
                        {
                            TrangThaiTiepNhan = false;
                        }
                    }
               
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show (this," Hiển thị Thông tin tiếp nhận Hồ sơ " +  System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + ex.Message,"DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        
        }
        public void  UpdateData()
        {
            /* Khai báo và khởi tạo đối tượng */
            clsThongTinTiepNhanHoSo ThongTinTiepNhan = new clsThongTinTiepNhanHoSo();
            try
            {
                /* Xác nhận giá trị cần cập nhật */
                /* Nhận chuỗi kết nối Database */
                ThongTinTiepNhan.Connection = strConnection;
                ThongTinTiepNhan.MaHoSoCapGCN = longMaHoSoCapGCN;
                ThongTinTiepNhan.MaHoSoTiepNhan = strMaHoSoTiepNhan;
                if (dtpNgayNhanDuHoSo.Checked == false)
                {
                    ThongTinTiepNhan.NgayNhanDuHoSo = null ;
                }
                else
                {
                    ThongTinTiepNhan.NgayNhanDuHoSo = dtpNgayNhanDuHoSo.Text; 
                }
                ThongTinTiepNhan.NoiNhanDuHoSo = txtNoiNhanHoSo.Text.Trim();
                /* Kiểu tra xem có giá trị truyền vào không? */
                if (txtSoHoSoTiepNhan.Text.Trim() != "")
                {
                    /* Kiểm tra giá trị truyền vào có là kiểu số hay không? */
                    if (isNumberic(txtSoHoSoTiepNhan.Text.Trim()))
                    {
                        ThongTinTiepNhan.SoHoSoTiepNhan = Convert.ToInt32(txtSoHoSoTiepNhan.Text.Trim());
                    }
                    /* Nếu không có giá trị truyền vào thì ta mặc định bằng 0 */
                    else
                    {
                        ThongTinTiepNhan.SoHoSoTiepNhan = 0;
                    }
                }
                /* Nếu không có giá trị truyền vào thì ta mặc định bằng 0 */
                else
                {
                    ThongTinTiepNhan.SoHoSoTiepNhan = 0;
                }
                /* Kiểm tra dữ liệu truyền vào Số thứ tự hồ sơ */
                if (txtThuTuTiepNhan.Text.Trim() != "")
                {
                    if (isNumberic(txtThuTuTiepNhan.Text.Trim()))
                    {
                        ThongTinTiepNhan.ThuTuTiepNhan  = Convert.ToInt32(txtThuTuTiepNhan.Text.Trim());
                    }
                    else
                    {
                        ThongTinTiepNhan.ThuTuTiepNhan  = 0;
                    }
                }
                else
                {
                    ThongTinTiepNhan.ThuTuTiepNhan = 0;
                }

                /* Thời gian tiếp nhận */
                if (dtpThoiDiemTiepNhan.Checked == false)
                {
                    ThongTinTiepNhan.ThoiDiemTiepNhan  = null;
                }
                else
                {
                    ThongTinTiepNhan.ThoiDiemTiepNhan  = dtpThoiDiemTiepNhan.Text;
                }

                ThongTinTiepNhan.TenNguoiTiepNhan = txtTenNguoiTiepNhan.Text.Trim();
                ThongTinTiepNhan.TenNguoiDiKeKhai = txtTenNguoiDiKeKhai.Text.Trim();
                ThongTinTiepNhan.QuanHe = cmbQuanHe.Text.Trim();
                ThongTinTiepNhan.DinhDanh = cboDinhDanh.Text.Trim();
                ThongTinTiepNhan.CMTNguoiDiKeKhai = txtCMTNguoiDiKeKhai.Text.Trim();


                if (dtpNgayCap.Checked == false)
                {
                    ThongTinTiepNhan.NgayCap = null;
                }
                else
                {
                    ThongTinTiepNhan.NgayCap = dtpNgayCap.Text;
                }
 
                ThongTinTiepNhan.NoiCap= txtNoiCap.Text.Trim();
                ThongTinTiepNhan.SoDienThoaiNguoiDiKeKhai = txtSoDienThoaiNguoiDiKeKhai.Text.Trim();
                ThongTinTiepNhan.DiaChiNguoiDiKeKhai = txtDiaChiNguoiDiKeKhai.Text.Trim();
                ThongTinTiepNhan.NguoiVietDon = txtNguoiVietDon.Text.Trim();
                ThongTinTiepNhan.MaNguonHoSo = cboNguonCapHoSo.SelectedValue.ToString() ;
                if (radNguoiDaiDien.Checked)
                {
                    ThongTinTiepNhan.IsChu_NguoiDaiDien = "1";
                }
                else
                {
                    ThongTinTiepNhan.IsChu_NguoiDaiDien = "0";
                }

                if (dtpThoiDiemVietDon.Checked == false)
                {
                    ThongTinTiepNhan.ThoiDiemVietDon = null;
                }
                else
                {
                    ThongTinTiepNhan.ThoiDiemVietDon = dtpThoiDiemVietDon.Text;
                }

                string  str = "";
                /* Trường hợp thêm mới Hồ sơ tiếp nhận */
                if (shortAction == 1)
                {
                    ThongTinTiepNhan.InsertThongTinTiepNhanByMaHoSoCapGCN(str);
                    NhatKyNguoiDung("Thêm", "Tên người kê khai:" + txtTenNguoiDiKeKhai.Text + "- Số CMT:" + txtCMTNguoiDiKeKhai.Text + " - Địa chỉ: " + txtDiaChiNguoiDiKeKhai.Text);
                }
                else if (shortAction == 2)
                {
                    ThongTinTiepNhan.UpdateThongTinTiepNhanByMaHoSoCapGCN(str);
                    NhatKyNguoiDung("Sửa", "Thay (" +  strThongTinCu  +") bằng Tên người kê khai:" + txtTenNguoiDiKeKhai.Text + "- Số CMT:" + txtCMTNguoiDiKeKhai.Text + " - Địa chỉ: " + txtDiaChiNguoiDiKeKhai.Text);
                }
                shortAction = 0;
                strError = ThongTinTiepNhan.Err;

               
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(this," Cập nhật thông tin Tiếp nhận hồ sơ " + System.Environment.NewLine + " Lỗi: " +  System.Environment.NewLine + strError,"DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        public void  TrangThaiCapNhat(bool  blnCapNhat )
        {
            
            this.dtpNgayNhanDuHoSo.Enabled  = blnCapNhat;
            this.dtpThoiDiemTiepNhan.Enabled = blnCapNhat ;
            this.dtpNgayCap.Enabled = blnCapNhat;
            this.cmbQuanHe.Enabled = blnCapNhat;
            //this.txtMaXa.ReadOnly = !blnCapNhat;
            this.txtSoHoSoTiepNhan.ReadOnly =  !blnCapNhat;
            this.txtThuTuTiepNhan.ReadOnly  = !blnCapNhat;
            this.txtNoiNhanHoSo.ReadOnly = !blnCapNhat ;

            radNguoiDaiDien.Enabled = blnCapNhat;
            radChuSuDung.Enabled = blnCapNhat;

            this.txtTenNguoiTiepNhan.ReadOnly = !blnCapNhat ;	
            this.txtTenNguoiDiKeKhai.ReadOnly = !blnCapNhat ;
            this.cboDinhDanh.Enabled = blnCapNhat;
            this.txtCMTNguoiDiKeKhai.ReadOnly = !blnCapNhat ;
            this.txtNoiCap.ReadOnly = !blnCapNhat;
            this.txtSoDienThoaiNguoiDiKeKhai.ReadOnly = !blnCapNhat ;	
            this.txtDiaChiNguoiDiKeKhai.ReadOnly = !blnCapNhat ;	
            this.txtNguoiVietDon.ReadOnly = !blnCapNhat;

            this.dtpThoiDiemVietDon.Enabled = blnCapNhat;
            this.cboNguonCapHoSo.Enabled = blnCapNhat;

            if (blnCapNhat)
            {
                //this.txtMaXa.BackColor = Color.White;
                this.txtNoiNhanHoSo.BackColor = Color.White;
                this.txtSoHoSoTiepNhan.BackColor = Color.White;
                this.txtThuTuTiepNhan.BackColor = Color.White;

                this.txtTenNguoiTiepNhan.BackColor = Color.White;
                this.txtTenNguoiDiKeKhai.BackColor = Color.White;
                this.txtCMTNguoiDiKeKhai.BackColor = Color.White;
                this.txtSoDienThoaiNguoiDiKeKhai.BackColor = Color.White;
                this.txtNoiCap.BackColor = Color.White;
                this.txtDiaChiNguoiDiKeKhai.BackColor = Color.White;
                this.txtNguoiVietDon.BackColor = Color.White;
            }
            else
            {
                //this.txtMaXa.BackColor = Color.LightYellow;
                this.txtNoiNhanHoSo.BackColor = Color.LightYellow ;
                this.txtSoHoSoTiepNhan.BackColor = Color.LightYellow;
                this.txtThuTuTiepNhan.BackColor = Color.LightYellow;

                this.txtTenNguoiTiepNhan.BackColor = Color.LightYellow;
                this.txtTenNguoiDiKeKhai.BackColor = Color.LightYellow;
                this.txtCMTNguoiDiKeKhai.BackColor = Color.LightYellow;
                this.txtNoiCap.BackColor = Color.LightYellow;
                this.txtSoDienThoaiNguoiDiKeKhai.BackColor = Color.LightYellow;
                this.txtDiaChiNguoiDiKeKhai.BackColor = Color.LightYellow;
                this.txtNguoiVietDon.BackColor = Color.LightYellow;
            }
        }

        public void  TrangThaiBanDau()
        {
            dtThongTinTiepNhanHoSo.Clear();
            //this.txtMaXa.Text = "";
            this.txtSoHoSoTiepNhan.Text  = "";
            this.txtThuTuTiepNhan.Text  = "";
            this.dtpNgayNhanDuHoSo.Value = DateTime.Now ;
            this.dtpNgayNhanDuHoSo.Checked = false;
            this.dtpThoiDiemTiepNhan.Value = DateTime.Now;
            this.dtpThoiDiemTiepNhan.Checked = false;
            this.dtpNgayCap.Value = DateTime.Now;
            this.dtpNgayCap.Checked = false;
            this.txtNoiNhanHoSo.Text = "";

            this.txtTenNguoiTiepNhan.Text = "";
            this.txtTenNguoiDiKeKhai.Text = "";
            this.cmbQuanHe.Text = "";
            this.cboDinhDanh.Text = "CMND";
            this.txtCMTNguoiDiKeKhai.Text = "";
            this.txtNoiCap.Text = "";
            this.txtSoDienThoaiNguoiDiKeKhai.Text = "";
            this.txtDiaChiNguoiDiKeKhai.Text = "";
            this.txtNguoiVietDon.Text = "";
            this.dtpThoiDiemVietDon.Value = DateTime.Now;
            this.dtpThoiDiemVietDon.Checked  = false;
            
              
            
        }

        public void  TrangThaiChucNang(bool  blnStartEdited , bool  blnStartDeleted)
        {
            if (TrangThaiTiepNhan) {
                btnThem.Enabled = false ;
                }
                else
                {
                    btnThem.Enabled = !blnStartEdited;
                }
            
            this.btnSua.Enabled = !blnStartEdited;
            this.btnXoa.Enabled = !blnStartEdited;
            this.btnCapNhat.Enabled = blnStartEdited;
            this.btnHuyLenh.Enabled = blnStartEdited; 
            //this.chkChonTraCuu.Enabled = blnStartEdited;
            if (blnStartDeleted)
            {
                this.btnCapNhat.Enabled = !blnStartDeleted;
                this.btnHuyLenh.Enabled = !blnStartDeleted;
               
            }
        }

        private void btnHuyLenh_Click(object sender, EventArgs e)
        {

            /* Xóa dữ liệu trên Form */
            this.TrangThaiBanDau();
            /* Hiển thị dữ liệu */
            if (longMaHoSoCapGCN != 0)
            {
                this.ShowData();
            }
            /* Trạng thái chức năng */
            this.TrangThaiChucNang(false,false);
            /* Trạng thái cập nhật */
            this.TrangThaiCapNhat(false);
            shortAction = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            shortAction  = 2;
            /* Trạng thái chức năng */
            this.TrangThaiChucNang(true,false);
            /* Trạng thái cập nhật */
            this.TrangThaiCapNhat(true);
            strThongTinCu = "Tên người kê khai:" + txtTenNguoiDiKeKhai.Text + "- Số CMT:" + txtCMTNguoiDiKeKhai.Text + " - Địa chỉ: " + txtDiaChiNguoiDiKeKhai.Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if ( longMaHoSoCapGCN != 0)
            {
                if ( System.Windows.Forms.MessageBox.Show(this,"Toàn bộ thông tin Tiếp nhận Hồ sơ sẽ bị xóa" +System.Environment.NewLine  +  "Bạn chắc chắn muốn XÓA không?","DMCLand",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string str = "";
                    clsThongTinTiepNhanHoSo ThongTinTiepNhan = new clsThongTinTiepNhanHoSo();
                    ThongTinTiepNhan.Connection = strConnection;
                    ThongTinTiepNhan.MaHoSoCapGCN = longMaHoSoCapGCN;
                    ThongTinTiepNhan.DeleteThongTinTiepNhanByMaHoSoCapGCN(str);
                    NhatKyNguoiDung("Xóa", strThongTinCu );
                    /* Trạng thái ban đầu */
                    this.TrangThaiBanDau();
                    /* Trạng thái chức năng */
                    this.TrangThaiChucNang(true, true);
                    if (strError == "")
                        System.Windows.Forms.MessageBox.Show(this," Cập nhật THÀNH CÔNG!","DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    else
                        System.Windows.Forms.MessageBox.Show(this," Cập nhật KHÔNG thành công!","DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            /* Trạng thái cập nhật */
            this.TrangThaiCapNhat(false);
            /* Thiết lập lại giá trị Mã Hồ sơ tiếp nhận bằng rỗng */
            strMaHoSoTiepNhan = null; 
            strError = "";
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                ///* Kiểm tra tính hợp lệ của thông tin đầu vào */
                //if ( dtpThoiDiemTiepNhan.Checked == false )
                //{
                //    if (System.Windows.Forms.MessageBox.Show(this, "Chưa có NGÀY TIẾP NHẬN HỒ SƠ" + System.Environment.NewLine + "Bạn có muốn nhập NGÀY TIẾP NHẬN HỒ SƠ không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //    {
                //        dtpThoiDiemTiepNhan.Focus();
                //        return;
                //    }
                //}
                //if ( txtSoHoSoTiepNhan.Text.Trim() == "")
                //{
                //    if (System.Windows.Forms.MessageBox.Show(this, "Chưa có SỐ HỒ SƠ TIẾP NHẬN" + System.Environment.NewLine + "Bạn có muốn nhập SỐ HỒ SƠ TIẾP NHẬN không?" , "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //    {
                //        this.txtSoHoSoTiepNhan.Focus();
                //        return;
                //    }
                //}

                //if (txtMaXa.Text.Trim() == "")
                //{
                //    if (System.Windows.Forms.MessageBox.Show(this, "Chưa có MÃ ĐƠN VỊ HÀNH CHÍNH" + System.Environment.NewLine + "Bạn có muốn nhập MÃ ĐƠN VỊ HÀNH CHÍNH không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //    {
                //        this.txtMaXa.Focus();
                //        return;
                //    }
                //}

                //if (!isNumberic(txtMaXa.Text.Trim()))
                //{
                //    if (System.Windows.Forms.MessageBox.Show(this, "MÃ ĐƠN VỊ HÀNH CHÍNH phải là dãy số có 5 CHỮ SỐ " + System.Environment.NewLine + "Bạn có muốn nhập lại MÃ ĐƠN VỊ HÀNH CHÍNH không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //    {
                //        this.txtMaXa.Focus();
                //        return;
                //    }
                //}

                /* Cập nhật thông tin */
                this.UpdateData();

         
            }
            catch ( Exception ex)
            {
                strError = ex.Message;
                System.Windows.Forms.MessageBox.Show(this, " Cập nhật Thông tin tiếp nhận hồ sơ" + System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /* Hiển thị lại dữ liệu */
            this.ShowData();
            /* Trạng thai chức năng */
            this.TrangThaiChucNang(false,false);
            /* Trạng thái cập nhật */
            this.TrangThaiCapNhat(false);


            if (strError == "")
                System.Windows.Forms.MessageBox.Show(this," Bạn đã cập nhật thành công!","DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                System.Windows.Forms.MessageBox.Show(this," Cập nhật chưa thành công!","DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Information);
            strError = "";
        }

        private void ctrlThongTinTiepNhanHoSo_Load(object sender, EventArgs e)
        {
            /* Ngày nhận đủ hồ sơ */
            this.dtpNgayNhanDuHoSo.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhanDuHoSo.Format = DateTimePickerFormat.Custom ;
            this.dtpNgayNhanDuHoSo.ShowCheckBox = true;
            /* Ngày tiếp nhận hồ sơ */
            this.dtpThoiDiemTiepNhan.CustomFormat = "dd/MM/yyyy";
            this.dtpThoiDiemTiepNhan.Format = DateTimePickerFormat.Custom;
            this.dtpThoiDiemTiepNhan.ShowCheckBox = true;
            /* Ngày tiếp viết đơn */
            this.dtpThoiDiemVietDon .CustomFormat = "dd/MM/yyyy";
            this.dtpThoiDiemVietDon.Format = DateTimePickerFormat.Custom;
            this.dtpThoiDiemVietDon.ShowCheckBox = true;
            /* Ngày cap CMT*/
            this.dtpNgayCap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayCap.Format = DateTimePickerFormat.Custom;
            this.dtpNgayCap.ShowCheckBox = true;
            /* Trạng thái cập nhật */
            this.TrangThaiCapNhat(false);
            /* Trạng thái chức năng */
            this.TrangThaiChucNang(true, true); 
        }
        private void txtSoHoSoTiepNhan_KeyDown(object sender, KeyEventArgs e)
        {
           
            try
            {

                if (txtSoHoSoTiepNhan.ReadOnly == false)
                {
                    if ((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode == Keys.Decimal) || (e.KeyCode  == Keys.OemPeriod) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                    {
                        blnNonNumberEntered = true;
                    }
                    else
                    {
                        if ((e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Right) && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down))
                        {
                            System.Windows.Forms.MessageBox.Show(this, "Vui lòng chỉ nhập số vào ô này!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            blnNonNumberEntered = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, " Số hồ sơ " + System.Environment.NewLine + " Nhập kiểu số " +
                 System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyValue == 13)
            {
                txtThuTuTiepNhan.Focus(); 
            }
        }

        private void txtSoHoSoTiepNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ( txtSoHoSoTiepNhan.ReadOnly == false)
                {
                    if (blnNonNumberEntered == true)
                    {
                        blnNonNumberEntered = false;
                    }
                    else
                    {
                        e.KeyChar  = char.MinValue;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, " Nhập thông tin số hồ sơ " +
                       System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtThuTuTiepNhan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (txtThuTuTiepNhan.ReadOnly == false)
                {
                    if ((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode == Keys.Decimal) || (e.KeyCode == Keys.OemPeriod) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                    {
                        blnNonNumberEntered = true;
                    }
                    else
                    {
                        if ((e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Right) && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down))
                        {
                            System.Windows.Forms.MessageBox.Show(this, "Vui lòng chỉ nhập số vào ô này!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            blnNonNumberEntered = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, " Nhập số thứ tự hồ sơ " +
                 System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyValue == 13)
            {
                cboNguonCapHoSo.Focus();
            }
        }

        private void txtThuTuTiepNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtThuTuTiepNhan.ReadOnly == false)
                {
                    if (blnNonNumberEntered == true)
                    {
                        blnNonNumberEntered = false;
                    }
                    else
                    {
                        e.KeyChar = char.MinValue;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, " Nhập thông tin số thứ tự hồ sơ " +
                       System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoHoSoTiepNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //if ((strMaHoSoTiepNhan == null) || (strMaHoSoTiepNhan == ""))
           // {
                shortAction = 1;
                /* Thiết lập trạng thái ban đầu */
                this.TrangThaiBanDau();
                /* Thiết lập trạng thái cập nhật cho các điều khiển */
                this.TrangThaiCapNhat(true);
                /* Trạng thái chức năng */
                this.TrangThaiChucNang(true, false); 
          // }
        }

        private void dtpNgayNhanDuHoSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtNoiNhanHoSo.Focus();
            }
        }

        private void txtNoiNhanHoSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtTenNguoiTiepNhan.Focus();
            }
        }

        private void txtTenNguoiTiepNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtTenNguoiDiKeKhai.Focus();
            }
        }

        private void txtTenNguoiDiKeKhai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                cmbQuanHe.Focus();
            }
        }


        private void cmbQuanHe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                cboDinhDanh.Focus();
            }
        }

        private void cboDinhDanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtCMTNguoiDiKeKhai.Focus();
            }
        }

        private void txtCMTNguoiDiKeKhai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                dtpNgayCap.Focus();
            }
        }

        private void dtpNgayCap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtNoiCap.Focus();
            }
        }

        private void txtNoiCap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtSoDienThoaiNguoiDiKeKhai.Focus();
            }
        }

        private void txtSoDienThoaiNguoiDiKeKhai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtDiaChiNguoiDiKeKhai.Focus();
            }
        }

        private void txtDiaChiNguoiDiKeKhai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                dtpThoiDiemVietDon.Focus();
            }
        }

        private void dtpThoiDiemVietDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtNguoiVietDon.Focus();
            }
        }

        private void txtNguoiVietDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnCapNhat.Focus();
            }
        }

        private void cboNguonCapHoSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtNoiNhanHoSo.Focus();
            }
        }

        private void cmdTraCuuCSD_Click(object sender, EventArgs e)
        {
            try{
            frmTraCuu TraCuu = new frmTraCuu();
            TraCuu.ctrlTraCuu1.Connection = strConnection;
           
            TraCuu.ctrlTraCuu1.Nhom = "GDCN";
            TraCuu.StartPosition = FormStartPosition.CenterScreen;
            TraCuu.ShowDialog();
            
            dtFound = TraCuu.ctrlTraCuu1.Selected;
             
            if (dtFound.Rows.Count < 1){
                return;
            }
            else{
            txtTenNguoiDiKeKhai.Text = dtFound.Rows[0]["HoTen"].ToString();
          //  cmbQuanHe.Text = dtFound.Rows[0]["QuanHe"].ToString();
            cboDinhDanh.Text = dtFound.Rows[0]["DinhDanh"].ToString();
            txtCMTNguoiDiKeKhai.Text = dtFound.Rows[0]["SoDinhDanh"].ToString();
           

                if (IsDate(dtFound.Rows[0]["NgayCap"].ToString())) {
                        dtpNgayCap.Value = Convert.ToDateTime( dtFound.Rows[0]["NgayCap"]);
                        dtpNgayCap.Checked = true;
                } else
                {
                    
                    dtpNgayCap.Value = DateTime.Now;
                        dtpNgayCap.Checked = false;
                }

            txtNoiCap.Text = dtFound.Rows[0]["NoiCap"].ToString();
            
            }
            }catch (Exception ex ) {
                MessageBox.Show("Lỗi");
            }
        
        }
 

        private void cmdNoiNhanHoSo_Click(object sender, EventArgs e)
        {
            frmThamSoMacDinh frm = new frmThamSoMacDinh();
            frm.ctrThamSoMacDinh1.Connection = strConnection;
            frm.ctrThamSoMacDinh1.ShowData();
            frm.ShowDialog();
            if (frm.ctrThamSoMacDinh1.MoTa != "")
            {
                txtNoiNhanHoSo.Text = frm.ctrThamSoMacDinh1.MoTa.Trim();
            }

        }

  
        //private void txtMaDonViHanhChinh_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {

        //        if (txtMaXa.ReadOnly == false)
        //        {
        //            if ((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode == Keys.Decimal) || (e.KeyCode == Keys.OemPeriod) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
        //            {
        //                blnNonNumberEntered = true;
        //            }
        //            else
        //            {
        //                if ((e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Right) && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down))
        //                {
        //                    System.Windows.Forms.MessageBox.Show(this, "Vui lòng CHỈ NHẬP SỐ vào ô này!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    blnNonNumberEntered = false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(this, " Mã đơn vị hành chính " +
        //         System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void txtMaDonViHanhChinh_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        if (txtMaXa.ReadOnly == false)
        //        {
        //            if (blnNonNumberEntered == true)
        //            {
        //                blnNonNumberEntered = false;
        //            }
        //            else
        //            {
        //                e.KeyChar = char.MinValue;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(this, " Mã đơn vị hành chính " +
        //               System.Environment.NewLine + " Lỗi: " + System.Environment.NewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

    }
}
