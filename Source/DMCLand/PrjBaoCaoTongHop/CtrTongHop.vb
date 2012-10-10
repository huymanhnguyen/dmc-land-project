Imports System.Data.SqlClient
Imports DMC.Land.User
Imports System.Xml
Public Class CtrTongHop
    Dim app As New Object
    Private strNamIn As Int16 = 0
    Private strConnection As String = ""
    Public User As New clsUser
    Private strUsername As String = ""
    Private strDVHC As String
    Private strDonViHanhChinh As String = ""
    Private strMaQuyen As String = ""
    Dim conn = New SqlConnection

    Private strMaChu As String = ""
    Private strNgay As String = ""
    Private strThang As String = ""
    Private strNam As String = ""
    Private strTuNgay As String = ""
    Private strDenNgay As String = ""
  
    Public Property TuNgay() As String
        Get
            Return strTuNgay
        End Get
        Set(ByVal value As String)
            strTuNgay = value
        End Set
    End Property
    Public Property DenNgay() As String
        Get
            Return strDenNgay
        End Get
        Set(ByVal value As String)
            strDenNgay = value
        End Set
    End Property
    Public Property Get_MaChu() As String
        Get
            Return strMaChu
        End Get
        Set(ByVal value As String)
            strMaChu = value
        End Set
    End Property

    Public Property MaQuyen() As String
        Get
            Return strMaQuyen
        End Get
        Set(ByVal value As String)
            strMaQuyen = value
        End Set
    End Property
    Public Property DVHC() As String
        Get
            Return strDVHC
        End Get
        Set(ByVal value As String)
            strDVHC = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return strUsername
        End Get
        Set(ByVal value As String)
            strUsername = value
        End Set
    End Property
    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public Sub ctrLoad_Tonghop() '(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'LoadNam()
            'cboNam.Text = Year(Now)
            conn.ConnectionString = strConnection
            Try
                conn.Open()
            Catch ex As Exception
                MessageBox.Show("Lỗi kết nối" & ex.Message)
            End Try
            'CtrChonDonViHanhChinh1.Get_arrMaDVHC = strDVHC  'frmDangNhap.UcKetNoi1.Get_MaDVHC ' User.Get_MaDVHC
            'CtrChonDonViHanhChinh1.Get_Maquyen = strMaQuyen 'frmDangNhap.UcKetNoi1.Get_MaQuyen ' User.Get_MaQuyen
            'CtrChonDonViHanhChinh1.Get_sqlConnect = conn
            'CtrChonDonViHanhChinh1.HienThiThongTinLenTreeview()

        Catch ex As Exception
            MsgBox("Connection failen !")

            Me.Dispose()
        End Try
    End Sub

    
    Public Function DonViHanhChinh() As String()
        Dim cls As New clsBaoCaoTongHop
        cls.Connection = strConnection
        cls.MaDonViHanhChinh = strDVHC
        Dim dtDVHC As New DataTable
        dtDVHC = cls.SelectDVHC
        Dim arrMangGiaTriDVHC(3) As String
        If dtDVHC.Rows.Count > 0 Then
            arrMangGiaTriDVHC(0) = dtDVHC.Rows(0).Item("TenTinh").ToString.ToUpper
            arrMangGiaTriDVHC(1) = dtDVHC.Rows(0).Item("TenHuyen").ToString.ToUpper
            arrMangGiaTriDVHC(2) = dtDVHC.Rows(0).Item("Ten").ToString.ToUpper
        End If
        Return arrMangGiaTriDVHC
    End Function

   

    Private Sub cboXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboXem.Click
        Dim cls As New clsBaoCaoTongHop
        cls.Connection = strConnection
        'Button14.Cursor = Cursors.WaitCursor
        If (strDVHC = 0) Then
            MessageBox.Show("Chọn đơn vị hành chính", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim frm As New frmXemThongTin
        Dim dtBaoCao As New DataTable
        Select Case cboLoaiHoSo.Text.ToUpper.Trim
            Case "Hồ sơ tiếp nhận".ToUpper

                Dim parasHoSoSoDKBD() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam

                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesHoSoDKBD() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachTiepNhanHoSo", parasHoSoSoDKBD, ValuesHoSoDKBD)
 
                frm.txtTongHoSo.Text = dtBaoCao.Rows.Count
                frm.DataGridView1.DataSource = dtBaoCao
                frm.DataGridView1.Columns("SoTT").HeaderText = "Số TT"
                frm.DataGridView1.Columns("MaHoSoCapGCN").Visible = False
                frm.DataGridView1.Columns("ThoiDiemTiepNhan").HeaderText = "Thời điểm tiếp nhận"
                frm.DataGridView1.Columns("ThoiDiemTiepNhan").DefaultCellStyle.Format = "dd / MM / yyyy"
                frm.DataGridView1.Columns("SoHoSoTiepNhan").HeaderText = "Số tiếp nhận"
                frm.DataGridView1.Columns("TenNguoiTiepNhan").HeaderText = "Người tiếp nhận"
                frm.DataGridView1.Columns("TenNguoiDiKeKhai").HeaderText = "Người kê khai"
                frm.DataGridView1.Columns("NguoiVietDon").HeaderText = "Người viết đơn"
 
            Case "Hồ sơ xét duyệt".ToUpper 
                Dim parasHoSoXDCS() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam

                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesHoSoXDCS() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachHoSoXetDuyetCS", parasHoSoXDCS, ValuesHoSoXDCS)
 
                frm.txtTongHoSo.Text = dtBaoCao.Rows.Count
                frm.DataGridView1.DataSource = dtBaoCao
                frm.DataGridView1.Columns("MaHoSoCapGCN").HeaderText = "Mã hồ sơ cấp GCN"
                frm.DataGridView1.Columns("NgayXetDuyet").HeaderText = "Ngày xét duyệt"
                frm.DataGridView1.Columns("ToBanDo").HeaderText = "Tờ bản đồ"
                frm.DataGridView1.Columns("SoThua").HeaderText = "Số thửa"
                frm.DataGridView1.Columns("DiaChiThua").HeaderText = "Địa chỉ thửa"
                frm.DataGridView1.Columns("DiaChiThua").Width = 300
                frm.DataGridView1.Columns("ChuHoSo").HeaderText = "Chủ hồ sơ"
                frm.DataGridView1.Columns("ChuHoSo").Width = 150
                frm.DataGridView1.Columns("NgayXetDuyet").DefaultCellStyle.Format = "dd / MM / yyyy" 
            Case "Hồ sơ thẩm định".ToUpper
                  
                Dim parasHoSoThamDinh() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam

                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesHoThamDinh() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachHoSoThamDinh", parasHoSoThamDinh, ValuesHoThamDinh)

 
                frm.txtTongHoSo.Text = dtBaoCao.Rows.Count
                frm.DataGridView1.DataSource = dtBaoCao
                frm.DataGridView1.Columns("MaHoSoCapGCN").HeaderText = "Mã hồ sơ cấp GCN"
                frm.DataGridView1.Columns("NgayThamDinh").HeaderText = "Ngày thẩm định"
                frm.DataGridView1.Columns("ToBanDo").HeaderText = "Tờ bản đồ"
                frm.DataGridView1.Columns("SoThua").HeaderText = "Số thửa"
                frm.DataGridView1.Columns("ChuHoSo").HeaderText = "Chủ hồ sơ"
                frm.DataGridView1.Columns("ChuHoSo").Width = 150
                frm.DataGridView1.Columns("DiaChiThua").HeaderText = "Địa chỉ thửa"
                frm.DataGridView1.Columns("DiaChiThua").Width = 300
                frm.DataGridView1.Columns("DonViThamDinh").HeaderText = "Đơn vị thẩm định"
                frm.DataGridView1.Columns("HoTenCanBoThamDinh").HeaderText = "Họ tên cán bộ thẩm định"
                frm.DataGridView1.Columns("HoTenCanBoThamDinh").Width = 150
                frm.DataGridView1.Columns("NgayThamDinh").DefaultCellStyle.Format = "dd / MM / yyyy" 
            Case "Hồ sơ phê duyệt".ToUpper
                  
                Dim parasHoSoPheDuyet() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam

                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesHoPheDuyet() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachHoSoPheDuyet", parasHoSoPheDuyet, ValuesHoPheDuyet)

 
                frm.txtTongHoSo.Text = dtBaoCao.Rows.Count
                frm.DataGridView1.DataSource = dtBaoCao
                frm.DataGridView1.Columns("MaHoSoCapGCN").HeaderText = "Mã hồ sơ cấp GCN"
                frm.DataGridView1.Columns("NgayPheDuyet").HeaderText = "Ngày phê duyệt"
                frm.DataGridView1.Columns("ToBanDo").HeaderText = "Tờ bản đồ"
                frm.DataGridView1.Columns("SoThua").HeaderText = "Số thửa"
                frm.DataGridView1.Columns("ChuHoSo").HeaderText = "Chủ hồ sơ"
                frm.DataGridView1.Columns("ChuHoSo").Width = 150
                frm.DataGridView1.Columns("DiaChiThua").HeaderText = "Địa chỉ thửa"
                frm.DataGridView1.Columns("DiaChiThua").Width = 300
                frm.DataGridView1.Columns("YKienPheDuyet").HeaderText = "Ý kiến phê duyệt"
                frm.DataGridView1.Columns("HoTenCanBoPheDuyet").HeaderText = "Họ tên cán bộ phê duyệt"
                frm.DataGridView1.Columns("HoTenCanBoPheDuyet").Width = 150
                frm.DataGridView1.Columns("NgayPheDuyet").DefaultCellStyle.Format = "dd / MM / yyyy" 
            Case "Hồ sơ cấp GCN".ToUpper
                 
                Dim parasHoSoSoCapGCN() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam

                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesHoSoCapGCN() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachHoSoCapGCN", parasHoSoSoCapGCN, ValuesHoSoCapGCN)
 
                frm.txtTongHoSo.Text = dtBaoCao.Rows.Count
                frm.DataGridView1.DataSource = dtBaoCao
                frm.DataGridView1.Columns("MaHoSoCapGCN").HeaderText = "Mã hồ sơ cấp GCN"
                frm.DataGridView1.Columns("NgayKyGCN").HeaderText = "Ngày ký GCN"
                frm.DataGridView1.Columns("ToBanDo").HeaderText = "Tờ bản đồ"
                frm.DataGridView1.Columns("SoThua").HeaderText = "Số thửa"
                frm.DataGridView1.Columns("ChuHoSo").HeaderText = "Chủ hồ sơ"
                frm.DataGridView1.Columns("ChuHoSo").Width = 150
                frm.DataGridView1.Columns("DiaChiThua").HeaderText = "Địa chỉ thửa"
                frm.DataGridView1.Columns("DiaChiThua").Width = 300
                frm.DataGridView1.Columns("NguoiKyGCN").HeaderText = "Họ tên người ký GCN"
                frm.DataGridView1.Columns("NguoiKyGCN").Width = 150
                frm.DataGridView1.Columns("NgayKyGCN").DefaultCellStyle.Format = "dd / MM / yyyy" 
            Case "Hồ sơ biến động".ToUpper
  
                Dim parasHoSoSoDKBD() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam

                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesHoSoDKBD() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachHoSoDangKyBienDong", parasHoSoSoDKBD, ValuesHoSoDKBD)

 
                frm.txtTongHoSo.Text = dtBaoCao.Rows.Count
                frm.DataGridView1.DataSource = dtBaoCao
                frm.DataGridView1.Columns("MaHoSoCapGCN").HeaderText = "Mã hồ sơ cấp GCN"
                frm.DataGridView1.Columns("ThoiDiemDangKy").HeaderText = "Ngày đăng ký biến động"
                frm.DataGridView1.Columns("ToBanDo").HeaderText = "Tờ bản đồ"
                frm.DataGridView1.Columns("SoThua").HeaderText = "Số thửa"
                frm.DataGridView1.Columns("ChuHoSo").HeaderText = "Chủ hồ sơ"
                frm.DataGridView1.Columns("ChuHoSo").Width = 150
                frm.DataGridView1.Columns("DiaChiThua").HeaderText = "Địa chỉ thửa"
                frm.DataGridView1.Columns("DiaChiThua").Width = 300
                frm.DataGridView1.Columns("TenNguoiDangKy").HeaderText = "Họ tên người đăng ký"
                frm.DataGridView1.Columns("TenNguoiDangKy").Width = 150
                frm.DataGridView1.Columns("ThoiDiemDangKy").DefaultCellStyle.Format = "dd / MM / yyyy"

        End Select
        frm.Show()
    End Sub

    Public Function fileReport(ByVal LoaiBC As String) As String
        Dim ViTri As Short
        Dim path As String
        ViTri = InStr(4, Application.ExecutablePath, "\", CompareMethod.Binary)
        path = Application.ExecutablePath.Substring(0, ViTri) & Application.ProductName
        Dim file As String = ""
        Select Case LoaiBC
            Case "Hồ sơ tiếp nhận".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\DanhSachTiepNhan.rpt"
            Case "Hồ sơ xét duyệt".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\DanhSachXDCS.rpt"
            Case "Hồ sơ thẩm định".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\DanhSachHoSoThamDinh.rpt"
            Case "Hồ sơ phê duyệt".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\DanhSachPheDuyet.rpt"
            Case "Hồ sơ cấp GCN".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\DanhSachHoSoCGCNrpt.rpt"
            Case "Hồ sơ biến động".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\DanhSachBienDong.rpt"
        End Select

        Return file
    End Function

    Private Sub cmdIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIn.Click
        Dim cls As New clsBaoCaoTongHop
        cls.Connection = strConnection 
        If (strDVHC = 0) Then
            MessageBox.Show("Chọn đơn vị hành chính", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim Tngay As String = ""
        Dim DNgay As String = ""
        
        Dim dtBaoCao As New DataTable
        Select Case cboLoaiHoSo.Text.ToUpper.Trim
            Case "Hồ sơ tiếp nhận".ToUpper

                Dim parasTiepNhanHoSo() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam 
                Tngay = strNgay + "/" + strThang + "/" + strNam
                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam 
                DNgay = strNgay + "/" + strThang + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesTiepNhanHoSo() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachTiepNhanHoSo", parasTiepNhanHoSo, ValuesTiepNhanHoSo)
 
            Case "Hồ sơ xét duyệt".ToUpper 
                Dim parasTiepNhanHoSo() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam 
                Tngay = strNgay + "/" + strThang + "/" + strNam

                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam 
                DNgay = strNgay + "/" + strThang + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesTiepNhanHoSo() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachHoSoXetDuyetCS", parasTiepNhanHoSo, ValuesTiepNhanHoSo)
            Case "Hồ sơ thẩm định".ToUpper 
                Dim parasTiepNhanHoSo() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam 
                Tngay = strNgay + "/" + strThang + "/" + strNam
                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam 
                DNgay = strNgay + "/" + strThang + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesTiepNhanHoSo() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachHoSoThamDinh", parasTiepNhanHoSo, ValuesTiepNhanHoSo)
            Case "Hồ sơ phê duyệt".ToUpper
 
                Dim parasTiepNhanHoSo() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam 
                Tngay = strNgay + "/" + strThang + "/" + strNam
                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam 
                DNgay = strNgay + "/" + strThang + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesTiepNhanHoSo() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachHoSoPheDuyet", parasTiepNhanHoSo, ValuesTiepNhanHoSo)
                 

            Case "Hồ sơ cấp GCN".ToUpper 
                Dim parasTiepNhanHoSo() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam 
                Tngay = strNgay + "/" + strThang + "/" + strNam
                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam 
                DNgay = strNgay + "/" + strThang + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesTiepNhanHoSo() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachHoSoCapGCN", parasTiepNhanHoSo, ValuesTiepNhanHoSo)

            Case "Hồ sơ biến động".ToUpper
                Dim parasTiepNhanHoSo() As String = {"@MaDVHC", "@TuNgay", "@DenNgay"}
                strNgay = Me.DateTimePicker4.Value.Day
                strThang = Me.DateTimePicker4.Value.Month
                strNam = Me.DateTimePicker4.Value.Year
                strTuNgay = strThang + "/" + strNgay + "/" + strNam
                Tngay = strNgay + "/" + strThang + "/" + strNam
                strNgay = Me.DateTimePicker3.Value.Day
                strThang = Me.DateTimePicker3.Value.Month
                strNam = Me.DateTimePicker3.Value.Year
                strDenNgay = strThang + "/" + strNgay + "/" + strNam
          
                DNgay = strNgay + "/" + strThang + "/" + strNam
                strDonViHanhChinh = strDVHC
                Dim ValuesTiepNhanHoSo() As String = {strDonViHanhChinh, strTuNgay, strDenNgay}
                dtBaoCao = cls.GetData_SP("SP_DanhSachHoSoDangKyBienDong", parasTiepNhanHoSo, ValuesTiepNhanHoSo)
        End Select
        If dtBaoCao.Rows.Count <> 0 Then
            dtBaoCao.Columns.Add("Tinh")
            dtBaoCao.Columns.Add("Huyen")
            dtBaoCao.Columns.Add("Xa")
            dtBaoCao.Columns.Add("MaTinh")
            dtBaoCao.Columns.Add("MaHuyen")
            dtBaoCao.Columns.Add("MaXa")
            dtBaoCao.Rows(0).Item("Tinh") = DonViHanhChinh(0)
            dtBaoCao.Rows(0).Item("Huyen") = DonViHanhChinh(1)
            dtBaoCao.Rows(0).Item("Xa") = DonViHanhChinh(2)


            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim s As String = "SELECT MaTinh,Mahuyen,MaXa FROM tblTuDienDonViHanhChinh where MaDonViHanhChinh=" & strDVHC.ToString
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = s
            da.SelectCommand = cmd
            dt.Clear()
            da.Fill(dt)
            dtBaoCao.Rows(0).Item("MaTinh") = dt.Rows(0)(0)
            dtBaoCao.Rows(0).Item("MaHuyen") = dt.Rows(0)(1)
            dtBaoCao.Rows(0).Item("MaXa") = dt.Rows(0)(2)

            dtBaoCao.Columns.Add("TuNgay")
            dtBaoCao.Columns.Add("DenNgay")
            dtBaoCao.Rows(0).Item("TuNgay") = Tngay
            dtBaoCao.Rows(0).Item("Denngay") = DNgay

        End If
        Dim strFileBaoCao As String = ""
        strFileBaoCao = fileReport(cboLoaiHoSo.Text.ToUpper.Trim)
        Dim frm As New frmInBaoCao
        frm.DB = dtBaoCao
        frm.FileReport = strFileBaoCao
        frm.LoadReport()
        frm.Show()


    End Sub
End Class
