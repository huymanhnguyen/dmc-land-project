using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using MapInfo.Data;
using MapInfo.Mapping;
using MapInfo.Engine;
using MapInfo.Geometry;
using MapInfo.Styles;
using MapInfo.Tools;
using MapInfo.Windows.Controls;
using MapInfo.Windows.Dialogs;
using DMC.GIS.Common;
using MapInfo.Data.Find;
using MapInfo.Text;
using System.Data.SqlClient;
using System;

namespace DMC.Land.SoanHoSo
{
    public partial class frmSetTextStyle : Form
    {
        private double _conSize = 201218534;
        TextStyle _textStyle = null;
        string strText;
       MapControl map;
       double Angle;
       Table tab;
       Feature feature;
       string DoiTuong;
       private string strTenBang="";
       private long   lgFeatureID = 0;
       private DMC.GIS.Common.clsMainSoanHoSo cls;
       private bool booActive = false;
       ctrSoanHS ctr;
       private double dlTyLeZoomThua;
       private double dlDienTichThua;
       public ctrSoanHS CtrForm
       {
           get { return ctr; }
           set { ctr = value; }
       }
       public double DienTichThua
       {
           get { return dlDienTichThua; }
           set { dlDienTichThua = value; }
       }
       private double dlTyLeZoomHienTai;
       public double TyLeZoomThua
       {
           get { return dlTyLeZoomThua; }
           set { dlTyLeZoomThua = value; }
       }
       public double TyLeZoomHienTai
       {
           get { return dlTyLeZoomHienTai; }
           set { dlTyLeZoomHienTai = value; }
       }

       public bool ActiveEx
       {
           get { return booActive; }
           set { booActive = value; }
       }
       public frmSetTextStyle()
        {
            InitializeComponent();
            cls = new clsMainSoanHoSo();
            cls.TyLeZoomView = dlTyLeZoomThua;
            cls.DienTichThua = dlDienTichThua;
        }
        #region Các hàm thuộc tính gọi khởi tạo các giá trị
       public MapControl SetMapConT
        {
            set {  map=value ; }
        }
       public string SetDoiTuong
        {
            set {  DoiTuong = value; }
        }
        public TextStyle  get_TextStyle
        {
            set {  _textStyle = value; }
        }

        public Feature SetFeature
        {
            set {  feature = value; }
        }
        public Table SetTable
         {
             set {  tab = value; }
         }
        public string  SetObiText
        {
            set {  strText = value; }
        }
        public TextStyle SetTextStyle
        {
            set {  _textStyle = value; }
        }
        public string TenBang {
            set {  strTenBang = value; }
        }
        public long   FeatureID
        {
            set {  lgFeatureID = value; }
        }
       #endregion
        #region lấy các giá trinh ban nhận đuợc của đôi tượng truyền vào điều khiển
        public void GetFont() {
            Graphics g = CreateGraphics();
            FontFamily[] families = FontFamily.GetFamilies(g);
            // Draw text using each of the font families.
            foreach (FontFamily family in families)
            {
                comboBoxTextFontFamily.Items.Add(family.Name);
            }
            comboBoxTextFontFamily.Text = ".VNArial";
            g.Dispose();
        }

        public int Sizefont(double  DienTichText, double DienTichThua, double Zoom)
        { // 1point = 0.0375 m
            // dien tich o chu 1 point 	 	0.0375 * 0.0375 = 0.00140625
            //font = 8: ty le 226.37085052427096 / (0.0000140625 * 8) = 20 121.8534
            double fontSize = 1;
            fontSize = DienTichText * (20 * Zoom) / DienTichThua;
            return Convert.ToInt16( fontSize);
        }
        public void SetupControl() {
            MapInfo.Styles.Font f = new MapInfo.Styles.Font();
            f = _textStyle.Font;
            TextStyle ts= (TextStyle)feature.Style ;
            LegacyText txt= (LegacyText)feature .Geometry ;
            numericUpDownTextAngle.Value = System.Convert.ToInt32(txt.Layout.Angle);
            try
            {
                Int16 fontSize = cls.GetFontSize(txt, map);
                numericUpDownTextSize.Value = fontSize;
            }
            catch (Exception ex) { numericUpDownTextSize.Value = 1; }
          
           // numericUpDownTextSize.Value= System.Convert.ToDecimal( f.Size);
            for (int i = 0; i < comboBoxTextFontFamily.Items.Count;i++ )
            {
                string s;
                char[]c=new char[1];
                c[0] =System.Convert.ToChar(" ");
                s = comboBoxTextFontFamily.Items[i].ToString();
                s = s.Replace(" ","") ;
                if (s==f.Name.ToString()) {
                    comboBoxTextFontFamily.SelectedItem = comboBoxTextFontFamily.Items[i];
                }
            }
            if (comboBoxTextFontFamily.Text == "") {
                comboBoxTextFontFamily.SelectedItem = comboBoxTextFontFamily.Items[0];
            }
                
            if (f.FontWeight == MapInfo.Styles.FontWeight.Bold){
                checkBoxTextBold.Checked = true;
            }
            if (f.FontFaceStyle == MapInfo.Styles.FontFaceStyle.Italic)
            {
                checkBoxTextBold.Checked = true;
            } if (f.FontWeight == MapInfo.Styles.FontWeight.Bold)
            {
                checkBoxTextItalic.Checked = true;

            } if (f.TextDecoration == TextDecoration.Underline)
            {
                checkBoxTextUnderline.Checked = true;
            }
            if (f.TextDecoration == TextDecoration.Strikeout)
            {
                checkBoxTextStrikeout.Checked = true;
            }  
            if (f.TextCase == TextCase.AllCaps )
            {
                checkBoxTextAllCaps.Checked = true;
            }
            if (f.DblSpace)
            {
                checkBoxTextDoubleSpace.Checked = true;
            }
            if (f.Shadow)
            {
                checkBoxTextShadow.Checked = true;
            }
            if (f.TextEffect == TextEffect.Halo)
            {
                radioButtonTextHalo.Checked = true;
            }
            else {
                if (f.TextEffect == TextEffect.Box)
                {
                    radioButtonTextOpaque.Checked = true;
                }
                else {
                    radioButtonTextNoBackground.Checked = true;
                }
            
            }
        }
       
       #endregion
        #region Nhận các giá trị đựoc thiết lập mới cho đối tượng
            private void buttonTextForeColor_Click(object sender, EventArgs e)
            {
                MapInfo.Styles.Font f = _textStyle.Font;
                ColorDialog dlg = new ColorDialog();
                dlg.Color = f.ForeColor;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    f.ForeColor = dlg.Color;
                    _textStyle.Font = f;
                }	
            }

            private void buttonTextBackColor_Click(object sender, EventArgs e)
            {
                MapInfo.Styles.Font f = _textStyle.Font;
                ColorDialog dlg = new ColorDialog();
                dlg.Color = f.BackColor;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    f.BackColor = dlg.Color;
                    _textStyle.Font = f;
                    //SetTextSample();
                }			
            }

            private void numericUpDownTextSize_ValueChanged(object sender, EventArgs e)
            {
                MapInfo.Styles.Font f = _textStyle.Font;
                f.Size = (short)numericUpDownTextSize.Value;
                _textStyle.Font = f;
            }

            private void numericUpDownTextAngle_ValueChanged(object sender, EventArgs e)
            {
                Angle = (double)numericUpDownTextAngle.Value;
            }

            private void checkBoxTextBold_CheckedChanged(object sender, EventArgs e)
            {
                MapInfo.Styles.Font f = _textStyle.Font;
                f.FontWeight = checkBoxTextBold.Checked ? FontWeight.Bold : FontWeight.Normal;
                _textStyle.Font = f;
            }

            private void checkBoxTextAllCaps_CheckedChanged(object sender, EventArgs e)
            {
                MapInfo.Styles.Font f = _textStyle.Font;
                f.TextCase = checkBoxTextAllCaps.Checked ? TextCase.AllCaps : TextCase.Default;
                _textStyle.Font = f;
            }

            private void radioButtonTextNoBackground_CheckedChanged(object sender, EventArgs e)
            {
                if (this.radioButtonTextNoBackground.Checked)
                {
                    MapInfo.Styles.Font f = _textStyle.Font;
                    f.TextEffect = TextEffect.None;
                    _textStyle.Font = f;
                }
            }

            private void checkBoxTextItalic_CheckedChanged(object sender, EventArgs e)
            {
                MapInfo.Styles.Font f = _textStyle.Font;
                f.FontFaceStyle = checkBoxTextItalic.Checked ? FontFaceStyle.Italic : FontFaceStyle.Normal;
                _textStyle.Font = f;
            }

            private void checkBoxTextDoubleSpace_CheckedChanged(object sender, EventArgs e)
            {
                MapInfo.Styles.Font f = _textStyle.Font;
                f.DblSpace = checkBoxTextDoubleSpace.Checked;
                _textStyle.Font = f;
            }

            private void radioButtonTextHalo_CheckedChanged(object sender, EventArgs e)
            {
                if (this.radioButtonTextHalo.Checked)
                {
                    MapInfo.Styles.Font f = _textStyle.Font;
                    f.TextEffect = TextEffect.Halo;
                    _textStyle.Font = f;
                }
            }

            private void checkBoxTextUnderline_CheckedChanged(object sender, EventArgs e)
            {
                MapInfo.Styles.Font f = _textStyle.Font;
                if (checkBoxTextUnderline.Checked)
                {
                    f.TextDecoration |= TextDecoration.Underline;
                }
                else
                {
                    f.TextDecoration &= ~TextDecoration.Underline;
                }
                _textStyle.Font = f;
            }

            private void checkBoxTextShadow_CheckedChanged(object sender, EventArgs e)
            {
                MapInfo.Styles.Font f = _textStyle.Font;
                f.Shadow = checkBoxTextShadow.Checked;
                _textStyle.Font = f;
            }

            private void radioButtonTextOpaque_CheckedChanged(object sender, EventArgs e)
            {
                if (this.radioButtonTextOpaque.Checked)
                {
                    MapInfo.Styles.Font f = _textStyle.Font;
                    f.TextEffect = TextEffect.Box;
                    _textStyle.Font = f;
                }
            }

            private void checkBoxTextStrikeout_CheckedChanged(object sender, EventArgs e)
            {
                MapInfo.Styles.Font f = _textStyle.Font;
                if (checkBoxTextStrikeout.Checked)
                {
                    f.TextDecoration |= TextDecoration.Strikeout;
                }
                else
                {
                    f.TextDecoration &= ~TextDecoration.Strikeout;
                }
                _textStyle.Font = f;
            }
            private void comboBoxTextFontFamily_SelectedIndexChanged(object sender, EventArgs e)
            {
                MapInfo.Styles.Font f = _textStyle.Font;
                f.Name = comboBoxTextFontFamily.SelectedItem.ToString();
                _textStyle.Font = f;
            }       
        #endregion
        private void frmSetTextStyle_Load(object sender, EventArgs e)
        {
            Angle = 0.0;
            //_textStyle = new TextStyle();
            textBoxTextText.Text = strText;
            GetFont();
            SetupControl();
            MapInfo.Styles.Font f = _textStyle.Font;
            f.Size = (short)numericUpDownTextSize.Value;
            _textStyle.Font = f;
        }
        //chấp nhận sự thay đổi
        private  void cmdChapNhan_Click(object sender, EventArgs e)
        {
            if (numericUpDownTextSize.Value > 1)
            {
                cls.HeightFont = ctr.heightFont;
                cls.WidthFont = ctr.widthFont;
                cls.MyFontName = ctr.fontName;
                cls.setTextStyle(strTenBang, map, textBoxTextText.Text, feature, tab, _textStyle, Angle, DoiTuong, lgFeatureID, tab.Alias, dlDienTichThua, dlTyLeZoomThua);
                ctr.ExportsFileTab();
                this.Hide();
            }
            else
            {
                numericUpDownTextSize.Focus();
            }
        }
        //không thay đổi
        private void cmdHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
     
