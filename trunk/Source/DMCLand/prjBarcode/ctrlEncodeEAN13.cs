using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DMC.Barcode
{
    public partial class ctrlEncodeEAN13 : UserControl
    {
        public event MouseEventHandler TaoMaVachTuDong;
        // Khai báo biến chuỗi kết nối cơ sở dữ liệu
        private string strConnection = "";
        // Khai báo biến kiểm tra lỗi
        private string strError;
        //Khai báo biến Mã Hồ sơ cấp GCN
        private string strMaHoSoCapGCN;
        //// Khai báo biến lưu hình ảnh hồ sơ kĩ thuật
        //private byte[] bytAnhMaVach;
        //Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
        private string strUserName = "";

        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }
        private string strMaDonViHanhChinh = "";

        public string MaDonViHanhChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
        }
        public string Connection
        {
            set
            {
                strConnection = value;
            }
        }
        //Khai bao thuoc tinh ung voi bien
        public string Err
        {
            get
            {
                return strError;
            }
        }
        private string  MaLoaiBienDong  = "";
    public string MaKhoa
    {
        get {return MaLoaiBienDong ;}
        set {MaLoaiBienDong =value ;}
    }
       
        //Khai bao thuoc tinh ung voi bien 
        public string MaHoSoCapGCN
        {
            get
            {
                return strMaHoSoCapGCN;
            }
            set
            {
                strMaHoSoCapGCN = value;
            }
        }


        DMC.Barcode.Barcode Barcode = new DMC.Barcode.Barcode();
        public ctrlEncodeEAN13()
        {
            InitializeComponent();
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            /* Kiểu tra tích hợp lệ của dữ liệu đầu vào */
            if (this.txtDaySoMaVach.Text.Length < 13)//!= 13
            {
                System.Windows.Forms.MessageBox.Show ("Dãy số phải lớn hơn 13 số!","DMCLand");
                this.txtDaySoMaVach.Focus();
                return;
            }
            int W = Convert.ToInt32(this.txtWidth.Text.Trim());
            int H = Convert.ToInt32(this.txtHeight.Text.Trim());
            DMC.Barcode.TYPE type = DMC.Barcode.TYPE.UNSPECIFIED;
            /* Kiểu mã vạch */
            if (cmbBarcodeType.Text.Trim() == "CODE128A")
            {
                type = DMC.Barcode.TYPE.CODE128A;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Bạn phải chọn một kiểu phù hợp!", "DMCLand");
                this.cmbBarcodeType.Focus();
                return;
            }
            try
            {
                if (type != DMC.Barcode.TYPE.UNSPECIFIED)
                {
                    Barcode.IncludeLabel = this.chkGenerateLabel.Checked;
                    //===== Encoding performed here =====
                    picBarcode.Image = Barcode.Encode(type, this.txtDaySoMaVach.Text.Trim(), this.btnForeColor.BackColor, this.btnBackColor.BackColor, W, H);
                    //===================================

                    //show the encoding time
                    //this.lblEncodingTime.Text = "(" + Math.Round(Barcode.EncodingTime, 0, MidpointRounding.AwayFromZero).ToString() + "ms)";
                }//if

                picBarcode.Width = picBarcode.Image.Width;
                picBarcode.Height = picBarcode.Image.Height;

                //reposition the barcode image to the middle
                picBarcode.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - picBarcode.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - picBarcode.Height / 2);
            }//try
            catch (Exception ex)
            {
                MessageBox.Show(this, "Có lỗi xảy ra","DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }//catch
           // TaoMaVachTuDong(sender, e);
        }

        public bool ktTonTaiMaVach()
        {
            bool kt = false;
            clsMaVach MaVach = new clsMaVach();
            MaVach.Connection = strConnection;
            MaVach.GiaTriMaVach = txtDaySoMaVach.Text.Trim() ;
            DataTable dt = new DataTable();
            dt = MaVach.SelectCheckMaVach();
            if (dt.Rows.Count > 0)
            {
                kt = false;
            }
            else
            {
                kt = true;
            }
            return kt;
        }

        public void NhatKyNguoiDung(string ChucNang,string MoTa)
        {
            prjNhatKyNguoiDung.clsNhatKyNguoiDung clsNhatky = new prjNhatKyNguoiDung.clsNhatKyNguoiDung();
            clsNhatky.Connection = strConnection;
            clsNhatky.MaHoSoCapGCN  = strMaHoSoCapGCN;
            clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh;
            clsNhatky.NghiepVu = "Chức năng tạo mã vạch";
            clsNhatky.ChucNang = ChucNang;
            clsNhatky.MoTa = MoTa ;
            clsNhatky.DuongDanFile = Application.StartupPath;
            clsNhatky.LuuNhatKyNguoiDung();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                clsMaVach MaVach = new clsMaVach();
                MaVach.Connection = strConnection;
                MaVach.MaHoSoCapGCN = strMaHoSoCapGCN;
                MaVach.InMaVach = this.chkInMaVach.Checked;
                MaVach.GiaTriMaVach = txtDaySoMaVach.Text.Trim();
                MaVach.AnhMaVach = this.imageToByteArray(picBarcode.Image);
                MaVach.UpdateHoSoCapGCNByMaVach();
                NhatKyNguoiDung("Ghi", "Tạo mã " + txtDaySoMaVach.Text );
                /* Hiển thị lại thông tin Mã vạch và
                 * thiết lập lại chế độ cập nhật của các điều khiển trên Form */
                this.ShowData(); 
         }

        //private void btnSaveXML_Click(object sender, EventArgs e)
        //{
        //    btnEncode_Click(sender, e);

        //    using (SaveFileDialog sfd = new SaveFileDialog())
        //    {
        //        sfd.Filter = "XML Files|*.xml";
        //        if (sfd.ShowDialog() == DialogResult.OK)
        //        {
        //            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
        //            {
        //                sw.Write(Barcode.XML);
        //            }//using
        //        }//if
        //    }//using
        //}

        //private void btnLoadXML_Click(object sender, EventArgs e)
        //{
        //    using (OpenFileDialog ofd = new OpenFileDialog())
        //    {
        //        ofd.Multiselect = false;
        //        if (ofd.ShowDialog() == DialogResult.OK)
        //        {
        //            using (DMC.Barcode.BarcodeXML XML = new DMC.Barcode.BarcodeXML())
        //            {
        //                XML.ReadXml(ofd.FileName);

        //                //load image from xml
        //                this.picBarcode.Width = XML.Barcode[0].ImageWidth;
        //                this.picBarcode.Height = XML.Barcode[0].ImageHeight;
        //                this.picBarcode.Image = DMC.Barcode.Barcode.GetImageFromXML(XML);

        //                //populate the screen
        //                this.txtData.Text = XML.Barcode[0].RawData;
        //                this.chkGenerateLabel.Checked = XML.Barcode[0].IncludeLabel;

        //                switch (XML.Barcode[0].Type)
        //                {
        //                    case "UCC13":
        //                    case "EAN13":
        //                        break;
        //                    default: throw new Exception("Không hỗ trợ kiểu Mã hóa này!");
        //                }
        //                this.btnForeColor.BackColor = ColorTranslator.FromHtml(XML.Barcode[0].Forecolor);
        //                this.btnBackColor.BackColor = ColorTranslator.FromHtml(XML.Barcode[0].Backcolor); ;
        //                this.txtWidth.Text = XML.Barcode[0].ImageWidth.ToString();
        //                this.txtHeight.Text = XML.Barcode[0].ImageHeight.ToString();

        //                //populate the local object
        //                btnEncode_Click(sender, e);

        //                //reposition the barcode image to the middle
        //                picBarcode.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - picBarcode.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - picBarcode.Height / 2);
        //            }//using
        //        }//if
        //    }//using
        //}

        private void ctrlEncodeEAN13_Load(object sender, EventArgs e)
        {
            Bitmap temp = new Bitmap(1, 1);
            temp.SetPixel(0, 0, this.BackColor);
            picBarcode.Image = (Image)temp;

            this.btnBackColor.BackColor = this.Barcode.BackColor;
            this.btnForeColor.BackColor = this.Barcode.ForeColor;

            //reposition the barcode image to the middle
            picBarcode.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - picBarcode.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - picBarcode.Height / 2);
        }

        private void btnForeColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.AnyColor = true;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    this.Barcode.ForeColor = colorDialog.Color;
                    this.btnForeColor.BackColor = this.Barcode.ForeColor;
                }//if
            }//using
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.AnyColor = true;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    this.Barcode.BackColor = colorDialog.Color;
                    this.btnBackColor.BackColor = this.Barcode.BackColor;
                }//if
            }//using
        }

        private void btnSaveDisk_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
            sfd.FilterIndex = 2;
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DMC.Barcode.SaveTypes savetype = DMC.Barcode.SaveTypes.UNSPECIFIED;
                switch (sfd.FilterIndex)
                {
                    case 1: /* BMP */ savetype = DMC.Barcode.SaveTypes.BMP; break;
                    case 2: /* GIF */ savetype = DMC.Barcode.SaveTypes.GIF; break;
                    case 3: /* JPG */ savetype = DMC.Barcode.SaveTypes.JPG; break;
                    case 4: /* PNG */ savetype = DMC.Barcode.SaveTypes.PNG; break;
                    case 5: /* TIFF */ savetype = DMC.Barcode.SaveTypes.TIFF; break;
                    default: break;
                }//switch
                Barcode.SaveImage(sfd.FileName, savetype);
            }//if
        }

        /// <summary>
        /// Chuyển dữ liệu từ mảng byte về dữ liệu kiểu ảnh
        /// </summary>
        /// <param name="byteArrayIn">Tham số truyền vào là dữ liệu kiểu mảng byte</param>
        /// <returns>Giá trị trả về là dữ liệu kiểu ảnh</returns>
        private  System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// Chuyển từ dữ liệu kiểu ảnh về giữ liệu kiểu mảng byte
        /// </summary>
        /// <param name="imageIn">Tham số truyền vào là dữ liệu kiểu anh</param>
        /// <returns>Giá trị trả về là dữ liệu kiểu mảng byte</returns>
        private  byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            /* Chắc chắn rằng tồn tại Ảnh cần chuyển đổi */
            if (imageIn == null)
                return null;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public void ShowData()
        {
            /* Thiết lập trạng thái ban đầu */
            this.TrangThaiBanDau();
            clsMaVach MaVach = new clsMaVach();
            System.Data.DataTable dtMaVach;
            MaVach.Connection = strConnection ;
            MaVach.MaHoSoCapGCN = strMaHoSoCapGCN ;
            dtMaVach = MaVach.SelectData();
            byte[] bytTemp = null;
            if (dtMaVach.Rows.Count > 0)
            {
                /* Hiển thị thông tin có cho phép In mã vạch ra GCN không? */
                if (dtMaVach.Rows[0]["InMaVach"].ToString() != "")
                {
                    this.chkInMaVach.Checked = Convert.ToBoolean(dtMaVach.Rows[0]["InMaVach"].ToString());
                }
                else
                {
                    this.chkInMaVach.Checked = false;
                }
                /* Hiển thị Mã vạch */
                if (dtMaVach.Rows[0]["AnhMaVach"].ToString() != "")
                {
                    bytTemp = (byte[])dtMaVach.Rows[0]["AnhMaVach"];
                }
            }

            if (bytTemp != null)
            {
               
                picBarcode.Image = this.byteArrayToImage(bytTemp);
            }
            else
            {
                picBarcode.Image = null;
            }

            this.chkGenerateLabel.Checked = true;
            this.txtHeight.Text = "50";
            if (dtMaVach.Rows.Count > 0)
            {
                this.txtDaySoMaVach.Text = dtMaVach.Rows[0]["MaSoGCN"].ToString();
            }
            else {
                this.txtDaySoMaVach.Text = "";
            }
            this.txtWidth.Text = "190";
            picBarcode.Height = Convert.ToInt16(txtHeight.Text);
            picBarcode.Width = Convert.ToInt16(txtWidth.Text);
            this.btnBackColor.BackColor = Color.White;
            this.btnForeColor.BackColor = Color.Black;
            /* Thiết lập trạng thái chức năng */
            this.TrangThaiChucNang(false, false);
            /* Thiết lập lại trạng thái cập nhật */
            this.TrangThaiCapNhat(false);
        }

        private void txtDaySoMaVach_Click(object sender, EventArgs e)
        {
            //if (txtMaPhuong.Text.Length != 5)
            //{
            //    System.Windows.Forms.MessageBox.Show(this, "Mã xã/phường phải gồm 5 số" + System.Environment.NewLine + "Vui lòng kiểm tra lại Mã đơn vị hành chính", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtMaPhuong.Focus();
            //    return;
            //}
            //if (txtMaNamKyCapGCN.Text.Length != 2)
            //{
            //    System.Windows.Forms.MessageBox.Show(this, "Mã năm ký cấp GCN phải gồm 2 số" + System.Environment.NewLine + "Vui lòng kiểm tra lại Năm ký cấp GCN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtMaNamKyCapGCN.Focus();
            //    return;
            //}
            //if (txtMaHoSoGoc.Text.Length != 6)
            //{
            //    System.Windows.Forms.MessageBox.Show(this, "Mã Hồ sơ gốc phải gồm 6 số" + System.Environment.NewLine + "Vui lòng kiểm tra lại Số Hồ sơ gốc", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtMaHoSoGoc.Focus();
            //    return;
            //}
            //txtDaySoMaVach.Text = txtMaPhuong.Text + txtMaNamKyCapGCN.Text + txtMaHoSoGoc.Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            /* this.picBarcode.Image = null; */
            clsMaVach MaVach = new clsMaVach();
            MaVach.Connection = strConnection;
            MaVach.MaHoSoCapGCN = strMaHoSoCapGCN;
            MaVach.InMaVach = false;
            MaVach.AnhMaVach = null;
            MaVach.UpdateHoSoCapGCNByMaVach();
            /* Hien thi thong tin ma vach */
            this.ShowData();
        }

        /// <summary>
        /// Thiết lập trạng thái cho chế độ cập nhật
        /// </summary>
        /// <param name="blnCapNhat"></param>
        public void TrangThaiCapNhat(bool blnCapNhat)
        {

            this.txtDaySoMaVach.ReadOnly = !blnCapNhat;
            //this.txtHeight.ReadOnly = !blnCapNhat;
            //this.txtWidth.ReadOnly = !blnCapNhat;

            this.chkGenerateLabel.Enabled = blnCapNhat;
            this.chkInMaVach.Enabled = blnCapNhat;

            this.cmbBarcodeType.Enabled = blnCapNhat;

            this.btnBackColor.Enabled = blnCapNhat;
            this.btnForeColor.Enabled = blnCapNhat;

            if (blnCapNhat)
            {
                this.txtDaySoMaVach.BackColor = Color.White;
                //this.txtHeight.BackColor = Color.White;
                //this.txtWidth.BackColor = Color.White;
            }
            else
            {
                this.txtDaySoMaVach.BackColor = Color.LightYellow;
                //this.txtHeight.BackColor = Color.LightYellow;
                //this.txtWidth.BackColor = Color.LightYellow;
            }
        }

        public void TrangThaiBanDau()
        {
            this.txtDaySoMaVach.Text = "";
            this.txtHeight.Text = "";
            this.txtWidth.Text = "";

            this.chkGenerateLabel.Checked = true;
            this.chkInMaVach.Checked = false;

            //reposition the barcode image to the middle
            picBarcode.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - picBarcode.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - picBarcode.Height / 2);
        }

        public void TrangThaiChucNang(bool blnStartEdited, bool blnStartDeleted)
        {
            if (this.MaLoaiBienDong != "MG")
            {
                this.groupBox3.Enabled = true;
                this.btnEncode.Enabled = blnStartEdited;
                this.btnSua.Enabled = !blnStartEdited;
                this.btnXoa.Enabled = !blnStartEdited;
                this.btnSave.Enabled = blnStartEdited;
                this.btnHuyLenh.Enabled = blnStartEdited;
                if (blnStartDeleted)
                {
                    this.btnEncode.Enabled = !blnStartDeleted;
                    this.btnSave.Enabled = !blnStartDeleted;
                    this.btnHuyLenh.Enabled = !blnStartDeleted;
                }

            }
            else
            {
                this.groupBox3.Enabled = false;
              }
             
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            /* shortAction = 2; */
            /* Trạng thái chức năng */
            this.TrangThaiChucNang(true, false);
            /* Trạng thái cập nhật */
            this.TrangThaiCapNhat(true);
        }

        private void btnHuyLenh_Click(object sender, EventArgs e)
        {
            /* Hiển thị lại dữ liệu */
            this.ShowData();
        }

        private void chkGenerateLabel_CheckedChanged(object sender, EventArgs e)
        {

        }



    }
}
