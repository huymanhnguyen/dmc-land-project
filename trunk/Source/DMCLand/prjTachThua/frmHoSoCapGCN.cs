using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMC.Land.TachThua
{
    public partial class frmHoSoCapGCN : Form
    {
        private string strChapNhan = "";

        public string ChapNhan
        {
            get { return strChapNhan; }
            set { strChapNhan = value; }
        }
        private string strConnection = "";

        public string Connection
        {
            get { return strConnection; }
            set { strConnection = value; }
        }
        private string strToBanDo = "";

        public string ToBanDo
        {
            get { return strToBanDo; }
            set { strToBanDo = value; }
        }

        private string strSoThua = "";

        public string SoThua
        {
            get { return strSoThua; }
            set { strSoThua = value; }
        }

        private string strMaDonViHanhChinh = "";

        public string MaDonViHanhChinh
        {
            get { return strMaDonViHanhChinh; }
            set { strMaDonViHanhChinh = value; }
        }
        private string strMaHoSoCapGCN = "";

        public string MaHoSoCapGCN
        {
            get { return strMaHoSoCapGCN; }
            set { strMaHoSoCapGCN = value; }
        }

        private string strLuaChon = "";

        public string LuaChon
        {
            get { return strLuaChon; }
            set { strLuaChon = value; }
        }

        private string strMaThuaDat = "";

        public string MaThuaDat
        {
            get { return strMaThuaDat; }
            set { strMaThuaDat = value; }
        }



        public frmHoSoCapGCN()
        {
            InitializeComponent();
        }
        public string TongHopChu(string strMaHoSoCapGCN)
        {

            string strTongHop = "";
            DMC.Land.TachThua.clsHoSoCapGCN clsHS = new DMC.Land.TachThua.clsHoSoCapGCN();
            DataTable dt = new DataTable();

            //Gán chuỗi kết nối Database cho clsTimKiem
            clsHS.Connection = strConnection;
            //Mã đơn vị hành chính
            clsHS.MaHoSoCapGCN = strMaHoSoCapGCN;

            try
            {
                //Goi phuong thuc GetData de khoi tao doi tuong clsTimKiem
                dt = clsHS.SelectTongHopChu();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count ; i++)
                    {
                        strTongHop = strTongHop + dt.Rows[i]["QuanHe"].ToString() + ": " + dt.Rows[i]["HoTen"].ToString() + ", ";
                    }
                    strTongHop = strTongHop.Substring(0, strTongHop.Length - 2);
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(this, "Lỗi: " + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strTongHop;
        }
        public void ShowData()
        {
            if (radMaThuaDat.Checked)
            {
                strLuaChon = "1";
            }
            if (radToBanDoSoThua.Checked)
            {
                strLuaChon = "2";
            }
            if (radMaHoSoCapGCN.Checked)
            {
                strLuaChon = "3";
            }
            clsHoSoCapGCN cls = new clsHoSoCapGCN();
            cls.MaDonViHanhChinh = strMaDonViHanhChinh;
            cls.Connection = strConnection;
            cls.ToBanDo = strToBanDo;
            cls.SoThua = strSoThua;
            cls.MaHoSoCapGCN = strMaHoSoCapGCN;
            cls.MaThuaDat = strMaThuaDat;
            cls.LuaChon = strLuaChon;
            DataTable dtCheckToBanDoSoThua = new DataTable();
            dtCheckToBanDoSoThua = cls.SelCheckHoSoByToBanDoSoThua();
            grdHoSoCapGCN.DataSource = dtCheckToBanDoSoThua;

            for (int i = 0; i < grdHoSoCapGCN.Rows.Count; i++)
            {
                string strCSD = "";
                strCSD = TongHopChu(grdHoSoCapGCN.Rows[i].Cells["MaHoSoCapGCN"].Value.ToString());
                grdHoSoCapGCN.Rows[i].Cells["ChuSuDung"].Value = strCSD;
                
            }
        }
        private void frmHoSoCapGCN_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void grdHoSoCapGCN_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void radMaThuaDat_CheckedChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void radToBanDoSoThua_CheckedChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void radMaHoSoCapGCN_CheckedChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void cmdChapNhan_Click(object sender, EventArgs e)
        {
            if (grdHoSoCapGCN.SelectedRows.Count > 0)
            {
                strChapNhan = "1";
                strMaHoSoCapGCN = grdHoSoCapGCN.CurrentRow.Cells["MaHoSoCapGCN"].Value.ToString();
                strMaThuaDat = grdHoSoCapGCN.CurrentRow.Cells["MaThuaDat"].Value.ToString();
                strToBanDo = grdHoSoCapGCN.CurrentRow.Cells["ToBanDo"].Value.ToString();
                strSoThua = grdHoSoCapGCN.CurrentRow.Cells["SoThua"].Value.ToString();
                this.Hide();
            }
            else
            {
                MessageBox.Show(this,"Chọn hồ sơ cần gắn vào thửa đất","DMCLand",MessageBoxButtons.OK,MessageBoxIcon.Warning  );
            }
          
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            strChapNhan = "0";
            strMaHoSoCapGCN = "";
            strMaThuaDat = "";
            strToBanDo = "";
            strSoThua = "";
            strLuaChon = "";
            this.Hide();
        }
    }
}
