Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlThongTinKyGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã hồ sơ cấp GCN
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinKyGCN As New DataTable
    Private shortAction As Short = 0
    Private strThongTinCu As String
    Private strMaDonViHanhChinh As String
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Private MaLoaiBienDong As String = ""
    Public Property MaKhoa() As String
        Get
            Return MaLoaiBienDong
        End Get
        Set(ByVal value As String)
            MaLoaiBienDong = value
        End Set
    End Property
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Thông tin ký GCN"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    ''' <summary>
    ''' Hiển thị thông tin ký GCN
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        'Khai báo và khởi tạo lớp Thông tin ký GCN
        Dim ThongTinKyGCN As New clsThongTinKyGCN
        Try
            'Gán giá trị thuộc tính cho trường hợp truy vấn
            With ThongTinKyGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Gọi phương thức truy vấn thông tin ký GCN
            Dim dt As New DataTable
            If ThongTinKyGCN.GetData(dtThongTinKyGCN) = "" Then
                'Trình bày dữ liệu lên Form
                If dtThongTinKyGCN.Rows.Count > 0 Then
                    Me.txtNguoiKyGCN.Text = dtThongTinKyGCN.Rows(0).Item("NguoiKyGCN").ToString
                    If IsDBNull(dtThongTinKyGCN.Rows(0).Item("DiaDanhNoiCap")) Then
                        Me.txtDiaDanhNoiCap.Text = "Long Biên"
                    Else
                        Me.txtDiaDanhNoiCap.Text = dtThongTinKyGCN.Rows(0).Item("DiaDanhNoiCap").ToString
                    End If
                    Me.txtTieuDeKyGCN.Text = dtThongTinKyGCN.Rows(0).Item("TieuDeKyGCN").ToString
                    If Not IsDate(dtThongTinKyGCN.Rows(0).Item("NgayKyGCN").ToString) Then
                        Me.dtpNgayKyGCN.Value = Date.Now.Date
                        Me.dtpNgayKyGCN.Checked = False
                    Else
                        Me.dtpNgayKyGCN.Value = Convert.ToDateTime(dtThongTinKyGCN.Rows(0).Item("NgayKyGCN").ToString)
                        Me.dtpNgayKyGCN.Checked = True
                    End If
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin ký Cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
    End Sub

    'Trường hợp chưa có thông tin thì nhận thông tin Mặc định
    Public Sub ThongTinMacDinh(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0).Item("DiaDanhNoiCap")) Then
                Me.txtDiaDanhNoiCap.Text = "Long Biên"
            Else
                Me.txtDiaDanhNoiCap.Text = dt.Rows(0).Item("DiaDanhNoiCap").ToString
            End If

            Me.txtNguoiKyGCN.Text = dt.Rows(0).Item("NguoiKyGCN").ToString
            Me.txtTieuDeKyGCN.Text = dt.Rows(0).Item("TieuDeKyGCN").ToString
            If Not IsDate(dt.Rows(0).Item("NgayKyGCN").ToString) Then
                Me.dtpNgayKyGCN.Value = Date.Now.Date
                Me.dtpNgayKyGCN.Checked = False
            Else
                Me.dtpNgayKyGCN.Value = Convert.ToDateTime(dt.Rows(0).Item("NgayKyGCN").ToString)
                Me.dtpNgayKyGCN.Checked = True
            End If
        End If
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp thông tin ký Cấp GCN
        Dim ThongTinKyGCN As New clsThongTinKyGCN
        Try
            'Xác nhận giá trị cần cập nhật
            With ThongTinKyGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                If Me.dtpNgayKyGCN.Checked Then
                    .NgayKyGCN = Me.dtpNgayKyGCN.Text
                Else
                    .NgayKyGCN = Nothing
                End If
                .NguoiKyGCN = Me.txtNguoiKyGCN.Text.Trim
                .DiaDanhNoiCap = Me.txtDiaDanhNoiCap.Text.Trim
                .TieuDeKyGCN = Me.txtTieuDeKyGCN.Text.Trim
                Dim str As String = ""
                'Trường hợp cập nhật thông tin ký GCN
                If shortAction = 2 Then
                    ThongTinKyGCN.UpdateThongTinKyGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Cập nhật", "Thay (" & strThongTinCu & ") bằng (" & txtDiaDanhNoiCap.Text & " - " & txtNguoiKyGCN.Text & " - " & txtTieuDeKyGCN.Text & ")")
                ElseIf shortAction = 3 Then
                    ThongTinKyGCN.DeleteThongTinKyGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Thêm", txtDiaDanhNoiCap.Text & " - " & txtNguoiKyGCN.Text & " - " & txtTieuDeKyGCN.Text)
                    'Xóa dữ liệu trên Form
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin ký GCN " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtNguoiKyGCN.ReadOnly = Not blnCapNhat
            .txtDiaDanhNoiCap.ReadOnly = Not blnCapNhat
            .txtTieuDeKyGCN.ReadOnly = Not blnCapNhat
            .dtpNgayKyGCN.Enabled = blnCapNhat
            If blnCapNhat Then
                .txtNguoiKyGCN.BackColor = Color.White
                .txtDiaDanhNoiCap.BackColor = Color.White
                .txtTieuDeKyGCN.BackColor = Color.White
            Else
                .txtNguoiKyGCN.BackColor = Color.LightYellow
                .txtDiaDanhNoiCap.BackColor = Color.LightYellow
                .txtTieuDeKyGCN.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongTinKyGCN.Clear()
            .txtNguoiKyGCN.Text = ""
            .txtDiaDanhNoiCap.Text = "Long Biên"
            .txtTieuDeKyGCN.Text = ""
            .dtpNgayKyGCN.Value = Date.Now
            .dtpNgayKyGCN.Checked = False
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox2.Enabled = True
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnGhi.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                .btnTuDienNguoiKyGCN.Enabled = blnStartEdited
                .btnTieuDeKyGCN.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnGhi.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                    .btnTuDienNguoiKyGCN.Enabled = Not blnStartDeleted
                    .btnTieuDeKyGCN.Enabled = Not blnStartDeleted
                End If
            Else
                Me.GroupBox2.Enabled = False
            End If
            
        End With
    End Sub


    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        shortAction = 2
        With Me
            'Trạng thái chức năng
            .TrangThaiChucNang(True)
            'Trạng thái cập nhật
            .TrangThaiCapNhat(True)
            strThongTinCu = txtDiaDanhNoiCap.Text & " - " & txtNguoiKyGCN.Text & " - " & txtTieuDeKyGCN.Text
        End With
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If strMaHoSoCapGCN <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                With Me
                    shortAction = 3
                    .UpdateData()
                    'Trạng thái ban đầu
                    .TrangThaiBanDau()
                    ''Trạng thái chức năng
                    '.TrangThaiChucNang(True, True)
                End With
                If (strError = "") Then
                    MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                Else
                    MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                End If
                'Else
                '    'Trạng thái chức năng
                '    Me.TrangThaiChucNang()
            End If
        End If
        'Hiển thị dữ liệu
        Me.ShowData()
        strError = ""
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Try
            'Cập nhật thông tin ký GCN
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin ký GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        'Hiển thị lại dữ liệu
        Me.ShowData()
        strError = ""
    End Sub

    Private Sub ctrlThongTinKyGCN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .dtpNgayKyGCN
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
            'Trang thai chuc nang
            .TrangThaiChucNang(True, True)
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Xóa dữ liệu trên Form
            .TrangThaiBanDau()
            'Hiển thị dữ liệu
            Me.ShowData()
        End With
        shortAction = 0
    End Sub

    Private Sub btnTuDienNguoiKyGCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTuDienNguoiKyGCN.Click
        'Chắc chắn tồn tại Mã hồ sơ cấp GCN
        If (strMaHoSoCapGCN = "") Then
            Return
        End If
        Dim TuDienNguoiKyGCN As New frmTuDienNguoiKyGCN
        Dim dtNguoiKyGCN As New DataTable
        With TuDienNguoiKyGCN
            .CtrlTuDienNguoiKyGCN.Connection = strConnection
            'Hiển thị dữ liệu
            .CtrlTuDienNguoiKyGCN.showData()
            .ShowDialog()
            dtNguoiKyGCN = .CtrlTuDienNguoiKyGCN.dtTuDienNguoiKyGCNSelect
            'Kiểm tra xem có một người ký GCN nào được lựa chọn không
            If (dtNguoiKyGCN Is Nothing) Then
                Return
            End If
            If (dtNguoiKyGCN.Rows.Count < 1) Then
                Return
            End If
            'Gán Tên người ký GCN vào ô nhập liệu trên Form
            Me.txtNguoiKyGCN.Text = dtNguoiKyGCN.Rows(0).Item("HoTen").ToString
        End With
    End Sub

    Private Sub btnTieuDeKyGCN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTieuDeKyGCN.Click
        'Chắc chắn tồn tại Mã hồ sơ cấp GCN
        If (strMaHoSoCapGCN = "") Then
            Return
        End If
        Dim TuDienTieuDeKyGCN As New frmTuDienTieuDeKyGCN
        Dim dtTieuDeKyGCN As New DataTable
        With TuDienTieuDeKyGCN
            .CtrlTuDienTieuDeKyGCN.Connection = strConnection
            'Hiển thị dữ liệu
            .CtrlTuDienTieuDeKyGCN.showData()
            .ShowDialog()
            dtTieuDeKyGCN = .CtrlTuDienTieuDeKyGCN.dtTuDienTieuDeKyGCNSelect
            'Kiểm tra xem có Tiêu đề ký GCN nào được lựa chọn không
            If (dtTieuDeKyGCN Is Nothing) Then
                Return
            End If
            If (dtTieuDeKyGCN.Rows.Count < 1) Then
                Return
            End If
            'Gán Tiêu đề ký GCN vào ô nhập liệu trên Form
            Me.txtTieuDeKyGCN.Text = dtTieuDeKyGCN.Rows(0).Item("TieuDeKyGCN").ToString
        End With
    End Sub

    Private Sub txtDiaDanhNoiCap_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiaDanhNoiCap.KeyDown
        If (e.KeyValue = 13) Then
            txtTieuDeKyGCN.Focus()
        End If
    End Sub

    Private Sub txtTieuDeKyGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTieuDeKyGCN.KeyDown
        If (e.KeyValue = 13) Then
            txtNguoiKyGCN.Focus()
        End If
    End Sub

    Private Sub txtNguoiKyGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNguoiKyGCN.KeyDown
        If (e.KeyValue = 13) Then
            btnGhi.Focus()
        End If
    End Sub

    Private Sub cmDiaDanh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmDiaDanh.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtDiaDanhNoiCap.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub
End Class
