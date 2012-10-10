using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MapInfo.Mapping;
using MapInfo.Windows.Controls;
namespace DMC.Land.SoanHoSo
{
    
    public partial class frmBuffer : Form
    {
        MapControl map;
        int Buff;
        ctrSoanHS frm;
        DMC.GIS.Common.clsMainSoanHoSo cls;
        public frmBuffer()
        {
            InitializeComponent();
            frm= new ctrSoanHS();
            cls = new DMC.GIS.Common.clsMainSoanHoSo();
        }
        public void SetMapConT(MapControl Value)
        {
            map = Value;
        }
        private void cmdChapNhan_Click(object sender, EventArgs e)
        {
           if (Ktra()==false ){
               return;
           }
            Buff = 0;
            Buff = System.Convert.ToInt32 ( txtBuff.Text);
           
            frm.getBuff(Buff, map, ChonKieu());
            this.Hide();
        }

        private void radDuongBao_CheckedChanged(object sender, EventArgs e)
        {
            ChonKieu();
        }
        public bool ChonKieu() {
            bool Kieu = true;
            if (radDuongBao.Checked)
            {
                Kieu = false  ;
            }
            if (radKhung.Checked)
            {
                Kieu = true ;
            }
            return Kieu;
        }

        private void radKhung_CheckedChanged(object sender, EventArgs e)
        {
            ChonKieu();
        }

        private void frmBuffer_Load(object sender, EventArgs e)
        {
            ChonKieu();
        }

        private void txtBuff_TextChanged(object sender, EventArgs e)
        {
            //if (System.Char.IsNumber(txtBuff.Text)){}
        }

        private void txtBuff_KeyDown(object sender, KeyEventArgs e)
        {
        
        }
        public bool Ktra() {
            char[] ar = txtBuff.Text.ToCharArray();
            bool kt;
            kt = true;
            for (int i = 0; i <= ar.Length - 1; i++)
            {
                if (!System.Char.IsNumber(ar[i]))
                {
                    kt = false;
                    MessageBox.Show("Buffer phải là số nguyên !!");
                    return kt;
                }
            }
            return kt;
        }
    }
}
