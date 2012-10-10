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
    public partial class frmSongSongVuongGoc : Form
    {
        private bool bolTaoDuong;
        private bool bolChonDiem;
        private double  dblKhoangCach;
        private bool bolChucNang;
        private bool bolaccep;
        ctrSoanHS ctr;

        public ctrSoanHS CtrForm
        {
            get { return ctr; }
            set { ctr = value; }
        }
        public frmSongSongVuongGoc()
        {
            InitializeComponent();
        }
        public bool ChonDuong() 
        {
         return    bolTaoDuong;
        }
        public bool ChonDiem()
        {
           return  bolChonDiem ;
        }
        public bool accep()
        {
            return bolaccep;
        }
        public double KhoangCach()
        {
            return dblKhoangCach; ;
        }
        public void ChucNang(bool value)
        {
            bolChucNang = value; ;
        }
        private void frmSongSongVuongGoc_Load(object sender, EventArgs e)
        {
            bolaccep = false;
            if (bolChucNang)
            {
                this.Height = 93;
                this.Text = "TAO DUONG SONG SONG";
            }
            else {
                this.Height = 150;
                this.Text="TAO DUONG VUONG GOC";
            }
        }

        private void cmdChapNhanKhoangCach_Click(object sender, EventArgs e)
        {

            dblKhoangCach = 0.0;
            if (Convert.ToDouble(txtKhoangCach.Value) <= 0)
            {
                return;
            }
            else
            {
                dblKhoangCach = Convert.ToDouble(txtKhoangCach.Value);
            }

            if (radNghiemSognSong1.Checked)
            {
                bolTaoDuong = true;
            }
            if (radNghiemSognSong2.Checked)
            {
                bolTaoDuong = false;
            }
            if (radDiemDauVuongGoc.Checked)
            {
                bolChonDiem = true;
            }
            if (radDiemCuoiVuongGoc.Checked)
            {
                bolChonDiem = false;
            }
            bolaccep = true;
            this.Hide();
        }
    }
}
