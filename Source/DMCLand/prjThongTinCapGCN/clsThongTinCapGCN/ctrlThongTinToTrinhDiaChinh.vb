Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlThongTinToTrinhDiaChinh
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Tờ trình địa chính
    Private strMaToTrinhDiaChinh As String
    'Khai báo biến Mã hồ số cấp GCN
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinToTrinhDiaChinh As New DataTable
    Private shortAction As Short = 0
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

    'Hiển thị thông tin Tờ trình địa chính
    Public Sub ShowData()
        'Khai báo và khởi tạo lớp Thông tin tờ trình địa chính
        Dim ThongTinToTrinhDiaChinh As New clsThongTinToTrinhDiaChinh
        Try
            'Gán giá trị các thuộc tính đối với trường hợp truy vấn
            With ThongTinToTrinhDiaChinh
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaToTrinhDiaChinh = ""
                '
                strMaToTrinhDiaChinh = ""
            End With
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Truy vấn thông tin
            If ThongTinToTrinhDiaChinh.GetData(dtThongTinToTrinhDiaChinh) = "" Then
                'Trình bày dữ liệu lên Form
                If dtThongTinToTrinhDiaChinh.Rows.Count > 0 Then
                    strMaToTrinhDiaChinh = dtThongTinToTrinhDiaChinh.Rows(0).Item("MaToTrinhDiaChinh").ToString
                    Me.txtDonViLapToTrinhDiaChinh.Text = dtThongTinToTrinhDiaChinh.Rows(0).Item("DonViLapToTrinhDiaChinh").ToString
                    Me.txtSoToTrinhDiaChinh.Text = dtThongTinToTrinhDiaChinh.Rows(0).Item("SoToTrinhDiaChinh").ToString
                    Me.txtDieuKhoan.Text = dtThongTinToTrinhDiaChinh.Rows(0).Item("DieuKhoan").ToString
                    If Not IsDate(dtThongTinToTrinhDiaChinh.Rows(0).Item("NgayLapToTrinhDiaChinh").ToString) Then
                        Me.dtpNgayLapToTrinhDiaChinh.Value = Date.Now.Date
                        Me.dtpNgayLapToTrinhDiaChinh.Checked = False
                    Else
                        Me.dtpNgayLapToTrinhDiaChinh.Value = Convert.ToDateTime(dtThongTinToTrinhDiaChinh.Rows(0).Item("NgayLapToTrinhDiaChinh").ToString)
                        Me.dtpNgayLapToTrinhDiaChinh.Checked = True
                    End If
                    If Not IsDate(dtThongTinToTrinhDiaChinh.Rows(0).Item("NgayTrinhDiaChinh").ToString) Then
                        Me.dtpNgayTrinhDiaChinh.Value = Date.Now.Date
                        Me.dtpNgayTrinhDiaChinh.Checked = False
                    Else
                        Me.dtpNgayTrinhDiaChinh.Value = Convert.ToDateTime(dtThongTinToTrinhDiaChinh.Rows(0).Item("NgayTrinhDiaChinh").ToString)
                        Me.dtpNgayTrinhDiaChinh.Checked = True
                    End If
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Tờ trình địa chính" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp Thông tin tờ trình địa chính
        Dim ThongTinToTrinhDiaChinh As New clsThongTinToTrinhDiaChinh
        Try
            'Xác nhận giá trị cần cập nhật
            With ThongTinToTrinhDiaChinh
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaToTrinhDiaChinh = strMaToTrinhDiaChinh
                If Me.dtpNgayLapToTrinhDiaChinh.Checked Then
                    .NgayLapToTrinhDiaChinh = Me.dtpNgayLapToTrinhDiaChinh.Text
                Else
                    .NgayLapToTrinhDiaChinh = Nothing
                End If
                If Me.dtpNgayTrinhDiaChinh.Checked Then
                    .NgayTrinhDiaChinh = Me.dtpNgayTrinhDiaChinh.Text
                Else
                    .NgayTrinhDiaChinh = Nothing
                End If
                .DonViLapToTrinhDiaChinh = Me.txtDonViLapToTrinhDiaChinh.Text.Trim
                .SoToTrinhDiaChinh = Me.txtSoToTrinhDiaChinh.Text.Trim
                .DieuKhoan = txtDieuKhoan.Text
                Dim str As String = ""
                If shortAction = 1 Then
                    ThongTinToTrinhDiaChinh.InsertThongTinToTrinhDiaChinhByMaHoSoCapGCN()
                ElseIf shortAction = 2 Then
                    ThongTinToTrinhDiaChinh.UpdateThongTinToTrinhDiaChinhByMaHoSoCapGCN()
                ElseIf shortAction = 3 Then
                    ThongTinToTrinhDiaChinh.DeleteThongTinToTrinhDiaChinhByMaHoSoCapGCN()
                    'Xóa dữ liệu trên Form
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin tờ trình địa chính " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtDonViLapToTrinhDiaChinh.ReadOnly = Not blnCapNhat
            .txtSoToTrinhDiaChinh.ReadOnly = Not blnCapNhat
            .dtpNgayLapToTrinhDiaChinh.Enabled = blnCapNhat
            .dtpNgayTrinhDiaChinh.Enabled = blnCapNhat
            .txtDieuKhoan.ReadOnly = Not blnCapNhat

            If blnCapNhat Then
                .txtDonViLapToTrinhDiaChinh.BackColor = Color.White
                .txtSoToTrinhDiaChinh.BackColor = Color.White
                .txtDieuKhoan.BackColor = Color.White
            Else
                .txtDonViLapToTrinhDiaChinh.BackColor = Color.LightYellow
                .txtSoToTrinhDiaChinh.BackColor = Color.LightYellow
                .txtDieuKhoan.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongTinToTrinhDiaChinh.Clear()
            .txtDonViLapToTrinhDiaChinh.Text = ""
            .txtSoToTrinhDiaChinh.Text = ""
            .txtDieuKhoan.Text = ""
            .dtpNgayLapToTrinhDiaChinh.Value = Date.Now
            .dtpNgayLapToTrinhDiaChinh.Checked = False
            .dtpNgayTrinhDiaChinh.Value = Date.Now
            .dtpNgayTrinhDiaChinh.Checked = False
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox2.Enabled = True
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnThem.Enabled = Not blnStartEdited
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
        'Chắc chắn rằng tồn tại Mã hồ sơ cấp GCN
        If (strMaHoSoCapGCN = "") Then
            Return
        End If
        If strMaToTrinhDiaChinh <> "" Then
            shortAction = 2
            With Me
                'Trạng thái chức năng
                .TrangThaiChucNang(True)
                'Trạng thái cập nhật
                .TrangThaiCapNhat(True)
            End With
        Else
            MsgBox(" Bạn CHƯA chọn Tờ trình cần sửa thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If strMaToTrinhDiaChinh <> "" Then
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
        Me.ShowData()
        strMaToTrinhDiaChinh = ""
        strError = ""
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Dim frm As New ctrlThongTinCapGCN
        Try
            'Cập nhật thông tin tờ trình địa chính
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin tờ trình địa chính " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Hiển thị dữ liệu
        Me.ShowData()
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        strError = ""
    End Sub

    Private Sub ctrlThongTinToTrinhDiaChinh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .dtpNgayLapToTrinhDiaChinh
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            With .dtpNgayTrinhDiaChinh
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
            'Trạng thái chức năng
            .TrangThaiChucNang(True, True)
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Xóa dữ liệu trên Form
            .TrangThaiBanDau()
            'Hiển thị dữ liệu
            .ShowData()
        End With
        shortAction = 0
    End Sub
    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        If ((strMaToTrinhDiaChinh = Nothing) Or (strMaToTrinhDiaChinh = "")) Then
            shortAction = 1
            ' Thiết lập trạng thái ban đầu 
            Me.TrangThaiBanDau()
            ' Thiết lập trạng thái cập nhật cho các điều khiển 
            Me.TrangThaiCapNhat(True)
            ' Trạng thái chức năng 
            Me.TrangThaiChucNang(True, False)
        End If
    End Sub

    Private Sub txtDonViLapToTrinhDiaChinh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDonViLapToTrinhDiaChinh.KeyDown
        If (e.KeyValue = 13) Then
            txtSoToTrinhDiaChinh.Focus()
        End If
    End Sub

    Private Sub txtSoToTrinhDiaChinh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoToTrinhDiaChinh.KeyDown
        If (e.KeyValue = 13) Then
            dtpNgayLapToTrinhDiaChinh.Focus()
        End If
    End Sub

    Private Sub dtpNgayLapToTrinhDiaChinh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpNgayLapToTrinhDiaChinh.KeyDown
        If (e.KeyValue = 13) Then
            dtpNgayTrinhDiaChinh.Focus()
        End If
    End Sub

    Private Sub dtpNgayTrinhDiaChinh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpNgayTrinhDiaChinh.KeyDown
        If (e.KeyValue = 13) Then
            txtDieuKhoan.Focus()
        End If
    End Sub

    Private Sub txtDieuKhoan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDieuKhoan.KeyDown
        If (e.KeyValue = 13) Then
            btnGhi.Focus()
        End If
    End Sub

    Private Sub cmdDonViLapToTrinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDonViLapToTrinh.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtDonViLapToTrinhDiaChinh.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub
End Class
