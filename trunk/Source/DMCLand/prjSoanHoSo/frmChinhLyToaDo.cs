using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DMC.Land.SoanHoSo
{
    public partial class frmChinhLyToaDo : Form
    {
        private string strConnection = "";
        private string strMaHoSo = "";
        private SqlConnection conn = new SqlConnection();
        private BindingSource bSource = new BindingSource();
        private SqlDataAdapter dAdapter = new SqlDataAdapter();
        private  DataSet ds = new DataSet();
        private DataTable dTable = new DataTable();
        SqlCommandBuilder cBuilder = new SqlCommandBuilder();
        public string Connection { 
            set{
                strConnection = value;
            }
            get {
                return strConnection;
            }
        }
        public string MaHoSo
        {
            set
            {
                strMaHoSo  = value;
            }
            get
            {
                return strMaHoSo;
            }
        }
        public frmChinhLyToaDo()
        {
            InitializeComponent();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLuu_Click(object sender, EventArgs e)
        {
            DeleteData();
            UpdateDataBase(grdDanhSachToaDo);
        }
        public SqlConnection MoKetNoi() {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = strConnection;
                    conn.Open();
                }
            }catch(Exception ex ){
                MessageBox.Show("Lỗi kết nối =>>" + ex.Message );
            }
            return conn;
        }
        private void SelectDataBase()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = MoKetNoi();
                cmd.CommandText = "sp_DanhSachToaDo";
                cmd.CommandType = CommandType.StoredProcedure;
                
                if (strMaHoSo != null)
                {
                    cmd.Parameters.Add(new SqlParameter("@Flag", 1));
                    cmd.Parameters.Add(new SqlParameter("@MaHoSoCapGCN", strMaHoSo));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@Flag", 0));
                    cmd.Parameters.Add(new SqlParameter("@MaHoSoCapGCN", System.DBNull.Value));
                }
                dAdapter = new SqlDataAdapter(cmd);
                dAdapter.Fill(ds, "tab");
                 cBuilder = new SqlCommandBuilder(dAdapter);
                bSource = new BindingSource();
                bSource.DataSource = ds.Tables["tab"];
                grdDanhSachToaDo.DataSource = bSource;
                formatHeaderText();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateDataBase(DMC.Interface.GridView.ctrlGridView  gr)
        {
            try
            {
                for (int i = 0; i < gr.Rows.Count; i++)
                {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = MoKetNoi();
                cmd.CommandText = "sp_DanhSachToaDo";
                cmd.CommandType = CommandType.StoredProcedure;
                    if (strMaHoSo != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@Flag", 2));
                        cmd.Parameters.Add(new SqlParameter("@MaHoSoCapGCN", strMaHoSo));
                        cmd.Parameters.Add(new SqlParameter("@SoThuTu", gr.Rows[i].Cells["SoThuTu"].Value));
                        cmd.Parameters.Add(new SqlParameter("@ToaDoX", gr.Rows[i].Cells["ToaDoX"].Value));
                        cmd.Parameters.Add(new SqlParameter("@ToaDoY", gr.Rows[i].Cells["ToaDoY"].Value));
                        cmd.Parameters.Add(new SqlParameter("@HeSoGoc", gr.Rows[i].Cells["HeSoGoc"].Value));
                        cmd.Parameters.Add(new SqlParameter("@ChieuDai", gr.Rows[i].Cells["ChieuDai"].Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@Flag", 0));
                        cmd.Parameters.Add(new SqlParameter("@MaHoSoCapGCN", System.DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@SoThuTu", System.DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ToaDoX", System.DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ToaDoY", System.DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HeSoGoc", System.DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ChieuDai", System.DBNull.Value));
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DeleteData()
        {
                try
                {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = MoKetNoi();
                        cmd.CommandText = "sp_DanhSachToaDo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (strMaHoSo != null)
                        {
                            cmd.Parameters.Add(new SqlParameter("@Flag", 3));
                            cmd.Parameters.Add(new SqlParameter("@MaHoSoCapGCN", strMaHoSo));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@Flag", 0));
                            cmd.Parameters.Add(new SqlParameter("@MaHoSoCapGCN", System.DBNull.Value));
                        }
                        cmd.ExecuteNonQuery();
                    }
               
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
           
        }
        public void formatHeaderText() {
            grdDanhSachToaDo.Columns["SoThuTu"].HeaderText = "Số thứ tự";
            grdDanhSachToaDo.Columns["ToaDoX"].HeaderText = "Toạ độ X";
            grdDanhSachToaDo.Columns["ToaDoY"].HeaderText = "Toạ độ Y";
            grdDanhSachToaDo.Columns["HeSoGoc"].HeaderText = "Hệ số góc";
            grdDanhSachToaDo.Columns["ChieuDai"].HeaderText = "Chiều dài";
        
        }
        private void frmChinhLyToaDo_Load(object sender, EventArgs e)
        {
            this.grdDanhSachToaDo.AutoResizeColumns(
             DataGridViewAutoSizeColumnsMode.AllCells);
           
            SelectDataBase();
           
        }
       
    }
}
