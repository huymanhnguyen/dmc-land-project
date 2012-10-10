Imports System.Windows.Forms
Imports System.Drawing
Public Class ctrlThongTinSoCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã hồ sơ cấp GCN
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinSoCapGCN As New DataTable
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
        clsNhatky.NghiepVu = "Thông tin cấp GCN"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    ''' <summary>
    ''' Hiển thị thông tin Sổ quản lý
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox2.Enabled = True
        Else
            Me.GroupBox2.Enabled = False
        End If
        'Khai báo và khởi tạo lớp Sổ quản lý
        Dim ThongTinSoCapGCN As New clsThongTinSoCapGCN
        Try
            'Gán giá trị thuộc tính cho trường hợp truy vấn
            With ThongTinSoCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Gọi phương thức truy vấn thông tin Sổ quản lý
            Dim dt As New DataTable
            If ThongTinSoCapGCN.GetData(dtThongTinSoCapGCN) = "" Then
                'Trình bày dữ liệu lên Form
                If dtThongTinSoCapGCN.Rows.Count > 0 Then
                    If IsDBNull(dtThongTinSoCapGCN.Rows(0).Item("KyHieuThamQuyenCapGCN")) Then
                        Me.cmbKyHieuThamQuyenCapGCN.Text = "CH"
                    Else
                        Me.cmbKyHieuThamQuyenCapGCN.Text = dtThongTinSoCapGCN.Rows(0).Item("KyHieuThamQuyenCapGCN").ToString
                    End If

                    Me.txtThuTuVaoSoCapGCN.Text = dtThongTinSoCapGCN.Rows(0).Item("ThuTuVaoSoCapGCN").ToString
                    Me.txtSoVaoSoCapGCN.Text = dtThongTinSoCapGCN.Rows(0).Item("SoVaoSoCapGCN").ToString
                    If Not IsDate(dtThongTinSoCapGCN.Rows(0).Item("NgayVaoSoCapGCN").ToString) Then
                        Me.dtpNgayVaoSoCapGCN.Value = Date.Now.Date
                        Me.dtpNgayVaoSoCapGCN.Checked = False
                    Else
                        Me.dtpNgayVaoSoCapGCN.Value = Convert.ToDateTime(dtThongTinSoCapGCN.Rows(0).Item("NgayVaoSoCapGCN").ToString)
                        Me.dtpNgayVaoSoCapGCN.Checked = True
                    End If
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Sổ Cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp thông tin Sổ cấp GCN
        Dim ThongTinSoCapGCN As New clsThongTinSoCapGCN
        Try
            'Xác nhận giá trị cần cập nhật
            With ThongTinSoCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                If Me.dtpNgayVaoSoCapGCN.Checked Then
                    .NgayVaoSoCapGCN = Me.dtpNgayVaoSoCapGCN.Text
                Else
                    .NgayVaoSoCapGCN = Nothing
                End If
                .KyHieuThamQuyenCapGCN = Me.cmbKyHieuThamQuyenCapGCN.Text.Trim

                ''Chắc chắn rằng Số thứ tự vào sổ cấp GCN phải là kiểu số
                'If Not IsNumeric(Me.txtThuTuVaoSoCapGCN.Text.Trim) Then
                '    System.Windows.Forms.MessageBox.Show("Thứ tự vào sổ cấp GCN phải là kiểu số", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Exit Sub
                'End If
                ''Chắc chắn rằng thứ tự vào sổ cấp GCN phải gồm 5 số
                'If Me.txtThuTuVaoSoCapGCN.Text.Trim.Length <> 5 Then
                '    System.Windows.Forms.MessageBox.Show("Thứ tự vào sổ cấp GCN phải gồm 5 số", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Exit Sub
                'End If
                .ThuTuVaoSoCapGCN = Me.txtThuTuVaoSoCapGCN.Text.Trim
                .SoVaoSoCapGCN = Me.txtSoVaoSoCapGCN.Text.Trim
                Dim str As String = ""
                'Cập nhật thông tin sổ cấp GCN
                If shortAction = 2 Then
                    ThongTinSoCapGCN.UpdateThongTinSoCapGCNByMaHoSoCapGCN()
                    'strThongTinCu = "Thẩm quyền:" & cmbKyHieuThamQuyenCapGCN.Text & " - Số TT " & txtThuTuVaoSoCapGCN.Text & "- Số vào sổ" & txtSoVaoSoCapGCN.Text 
                    NhatKyNguoiDung("Cập nhật", "thay (" & strThongTinCu & ") bằng (" & strThongTinCu = "Thẩm quyền:" & cmbKyHieuThamQuyenCapGCN.Text & " - Số TT " & txtThuTuVaoSoCapGCN.Text & "- Số vào sổ" & txtSoVaoSoCapGCN.Text & ")")
                    'Xóa thông tin sổ cấp GCN
                ElseIf shortAction = 3 Then
                    ThongTinSoCapGCN.DeleteThongTinSoCapGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Xóa", strThongTinCu = "Thẩm quyền:" & cmbKyHieuThamQuyenCapGCN.Text & " - Số TT " & txtThuTuVaoSoCapGCN.Text & "- Số vào sổ" & txtSoVaoSoCapGCN.Text)
                    'Xóa dữ liệu trên Form
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Sổ cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .btnSoVaoSoCapGCN.Enabled = blnCapNhat
            .btnThuTuVaoSoCapGCN.Enabled = blnCapNhat
            .cmbKyHieuThamQuyenCapGCN.Enabled = blnCapNhat
            .txtThuTuVaoSoCapGCN.ReadOnly = Not blnCapNhat
            .txtSoVaoSoCapGCN.ReadOnly = Not blnCapNhat
            .dtpNgayVaoSoCapGCN.Enabled = blnCapNhat
            If blnCapNhat Then
                .cmbKyHieuThamQuyenCapGCN.BackColor = Color.White
                .txtThuTuVaoSoCapGCN.BackColor = Color.White
                .txtSoVaoSoCapGCN.BackColor = Color.White
            Else
                .cmbKyHieuThamQuyenCapGCN.BackColor = Color.LightYellow
                .txtThuTuVaoSoCapGCN.BackColor = Color.LightYellow
                .txtSoVaoSoCapGCN.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongTinSoCapGCN.Clear()
            .cmbKyHieuThamQuyenCapGCN.Text = "CH"
            .txtThuTuVaoSoCapGCN.Text = ""
            .txtSoVaoSoCapGCN.Text = ""
            .dtpNgayVaoSoCapGCN.Value = Date.Now
            .dtpNgayVaoSoCapGCN.Checked = False
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
                If blnStartDeleted Then
                    .btnGhi.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
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
            strThongTinCu = "Thẩm quyền:" & cmbKyHieuThamQuyenCapGCN.Text & " - Số TT " & txtThuTuVaoSoCapGCN.Text & "- Số vào sổ" & txtSoVaoSoCapGCN.Text
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
                    'Trạng thái chức năng
                    .TrangThaiChucNang(True, True)
                End With
                If (strError = "") Then
                    MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                Else
                    MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                End If
            Else
                'Trạng thái chức năng
                Me.TrangThaiChucNang()
            End If
        End If
        'Trạng thái cập nhật 
        Me.TrangThaiCapNhat()
        strError = ""
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Try
            'Cập nhật thông tin Sổ quản lý
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin vào sổ cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()

        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        strError = ""
    End Sub

    Private Sub ctrlThongTinSoCapGCN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .dtpNgayVaoSoCapGCN
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
            If strMaHoSoCapGCN <> "" Then
                .ShowData()
            End If
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub

    Private Sub btnSoVaoSoCapGCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoVaoSoCapGCN.Click
        'Tổng hợp thông tin Số vào sổ cấp GCN
        Dim strSoVaoSoCapGCN As String = ""
        Dim strThuTuVaoSoCapGCN As String = ""
        If (cmbKyHieuThamQuyenCapGCN.Text.Trim.Length = 2) And IsNumeric(txtThuTuVaoSoCapGCN.Text.Trim) Then
            Select Case txtThuTuVaoSoCapGCN.Text.Trim.Length
                Case 1
                    'Chắc chắn rằng số thứ tự khác 0
                    If txtThuTuVaoSoCapGCN.Text.Trim = "0" Then
                        Exit Sub
                    End If
                    strThuTuVaoSoCapGCN = "0000" + txtThuTuVaoSoCapGCN.Text.Trim
                Case 2
                    strThuTuVaoSoCapGCN = "000" + txtThuTuVaoSoCapGCN.Text.Trim
                Case 3
                    strThuTuVaoSoCapGCN = "00" + txtThuTuVaoSoCapGCN.Text.Trim
                Case 4
                    strThuTuVaoSoCapGCN = "0" + txtThuTuVaoSoCapGCN.Text.Trim
                Case Else
                    Exit Sub
            End Select
            strSoVaoSoCapGCN = cmbKyHieuThamQuyenCapGCN.Text.Trim + strThuTuVaoSoCapGCN
            txtSoVaoSoCapGCN.Text = strSoVaoSoCapGCN
        End If
    End Sub

    Private Sub btnThuTuVaoSoCapGCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThuTuVaoSoCapGCN.Click
        'Tạo thứ tự vào sổ cấp GCN tự động
        'If (cmbKyHieuThamQuyenCapGCN.Text.Trim <> "CH") Or (cmbKyHieuThamQuyenCapGCN.Text.Trim <> "CT") Then
        '    Exit Sub
        'End If
        'Thứ tự vào sổ cấp GCN lớn nhất
        Dim intThuTuVaoSoCapGCNLonNhat As String = ""
        Dim dtThuTuVaoSoCapGCNLonNhat As New DataTable
        Dim ThongTinSoCapGCN As New clsThongTinSoCapGCN
        ThongTinSoCapGCN.Connection = strConnection
        ThongTinSoCapGCN.MaHoSoCapGCN = strMaHoSoCapGCN
        If (cmbKyHieuThamQuyenCapGCN.Text.Trim = "CT") Then
            dtThuTuVaoSoCapGCNLonNhat = ThongTinSoCapGCN.SelectSoThuTuVaoSoCapGCNLonNhatTheoCapTinh
            If (dtThuTuVaoSoCapGCNLonNhat IsNot Nothing) Then
                If dtThuTuVaoSoCapGCNLonNhat.Rows.Count > 0 Then
                    If IsNumeric(dtThuTuVaoSoCapGCNLonNhat.Rows(0).Item("ThuTuVaoSoCapGCNLonNhat")) Then
                        intThuTuVaoSoCapGCNLonNhat = dtThuTuVaoSoCapGCNLonNhat.Rows(0).Item("ThuTuVaoSoCapGCNLonNhat").ToString
                    End If
                End If
            End If
        ElseIf (cmbKyHieuThamQuyenCapGCN.Text.Trim = "CH") Then
            dtThuTuVaoSoCapGCNLonNhat = ThongTinSoCapGCN.SelectSoThuTuVaoSoCapGCNLonNhatTheoCapXa
            If (dtThuTuVaoSoCapGCNLonNhat IsNot Nothing) Then
                If dtThuTuVaoSoCapGCNLonNhat.Rows.Count > 0 Then
                    If IsNumeric(dtThuTuVaoSoCapGCNLonNhat.Rows(0).Item("ThuTuVaoSoCapGCNLonNhat")) Then
                        intThuTuVaoSoCapGCNLonNhat = dtThuTuVaoSoCapGCNLonNhat.Rows(0).Item("ThuTuVaoSoCapGCNLonNhat").ToString
                    End If
                End If
            End If
        End If
            'Tăng giá trị tự động lên 1 đơn vị
            'Rồi gán vào mục Thứ tự vào sổ cấp GCN
        Me.txtThuTuVaoSoCapGCN.Text = (intThuTuVaoSoCapGCNLonNhat).ToString.Trim
    End Sub

    Private Sub cmbKyHieuThamQuyenCapGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbKyHieuThamQuyenCapGCN.KeyDown
        If (e.KeyValue = 13) Then
            txtThuTuVaoSoCapGCN.Focus()
        End If
    End Sub

    Private Sub txtThuTuVaoSoCapGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtThuTuVaoSoCapGCN.KeyDown
        If (e.KeyValue = 13) Then
            txtSoVaoSoCapGCN.Focus()
        End If
    End Sub

    Private Sub txtSoVaoSoCapGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoVaoSoCapGCN.KeyDown
        If (e.KeyValue = 13) Then
            dtpNgayVaoSoCapGCN.Focus()
        End If
    End Sub

    Private Sub dtpNgayVaoSoCapGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpNgayVaoSoCapGCN.KeyDown
        If (e.KeyValue = 13) Then
            btnGhi.Focus()
        End If
    End Sub
End Class
