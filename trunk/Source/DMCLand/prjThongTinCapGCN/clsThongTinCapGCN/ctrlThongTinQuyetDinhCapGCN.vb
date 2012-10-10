Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlThongTinQuyetDinhCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã Quyết định cấp GCN
    Private strMaQuyetDinhCapGCN As String
    'Khai báo biến Mã hồ số cấp GCN
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinQuyetDinhCapGCN As New DataTable
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
        clsNhatky.NghiepVu = "Thông tin quyết định cấp GCN"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    'Hiển thị thông tin Quyết định cấp GCN
    Public Sub ShowData()
        'Khai báo và khởi tạo lớp Thông tin Quyết định cấp GCN
        Dim ThongTinQuyetDinhCapGCN As New clsThongTinQuyetDinhCapGCN
        Try
            'Gán giá trị các thuộc tính đối với trường hợp truy vấn
            With ThongTinQuyetDinhCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaQuyetDinhCapGCN = ""
            End With
            'Khởi tạo biến Mã Thông tin Quyết định
            strMaQuyetDinhCapGCN = ""
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Truy vấn thông tin
            If ThongTinQuyetDinhCapGCN.GetData(dtThongTinQuyetDinhCapGCN) = "" Then
                'Trình bày dữ liệu lên Form
                If dtThongTinQuyetDinhCapGCN.Rows.Count > 0 Then
                    strMaQuyetDinhCapGCN = dtThongTinQuyetDinhCapGCN.Rows(0).Item("MaQuyetDinhCapGCN").ToString
                    Me.txtDonViQuyetDinhCapGCN.Text = dtThongTinQuyetDinhCapGCN.Rows(0).Item("DonViQuyetDinhCapGCN").ToString
                    Me.txtSoQuyetDinhCapGCN.Text = dtThongTinQuyetDinhCapGCN.Rows(0).Item("SoQuyetDinhCapGCN").ToString
                    If Not IsDate(dtThongTinQuyetDinhCapGCN.Rows(0).Item("NgayQuyetDinhCapGCN").ToString) Then
                        Me.dtpNgayQuyetDinhCapGCN.Value = Date.Now.Date
                        Me.dtpNgayQuyetDinhCapGCN.Checked = False
                    Else
                        Me.dtpNgayQuyetDinhCapGCN.Value = Convert.ToDateTime(dtThongTinQuyetDinhCapGCN.Rows(0).Item("NgayQuyetDinhCapGCN").ToString)
                        Me.dtpNgayQuyetDinhCapGCN.Checked = True
                    End If
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Quyết định cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp Thông tin Quyết định cấp GCN
        Dim ThongTinQuyetDinhCapGCN As New clsThongTinQuyetDinhCapGCN
        Try
            'Xác nhận giá trị cần cập nhật
            With ThongTinQuyetDinhCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaQuyetDinhCapGCN = strMaQuyetDinhCapGCN
                If Me.dtpNgayQuyetDinhCapGCN.Checked Then
                    .NgayQuyetDinhCapGCN = Me.dtpNgayQuyetDinhCapGCN.Text
                Else
                    .NgayQuyetDinhCapGCN = Nothing
                End If
                .DonViQuyetDinhCapGCN = Me.txtDonViQuyetDinhCapGCN.Text.Trim
                .SoQuyetDinhCapGCN = Me.txtSoQuyetDinhCapGCN.Text.Trim

                Dim str As String = ""
                'Trường hợp sửa 
                If shortAction = 1 Then
                    ThongTinQuyetDinhCapGCN.InsertThongTinQuyetDinhCapGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Thêm", strThongTinCu = "Số QĐ: " & txtSoQuyetDinhCapGCN.Text & " - Đơn vị QĐ:" & txtDonViQuyetDinhCapGCN.Text)
                ElseIf shortAction = 2 Then
                    ThongTinQuyetDinhCapGCN.UpdateThongTinQuyetDinhCapGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Sửa", "Thay (" & strThongTinCu & ") bằng (" & strThongTinCu = "Số QĐ: " & txtSoQuyetDinhCapGCN.Text & " - Đơn vị QĐ:" & txtDonViQuyetDinhCapGCN.Text & ")")
                ElseIf shortAction = 3 Then
                    ThongTinQuyetDinhCapGCN.DeleteThongTinQuyetDinhCapGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Xóa", strThongTinCu = "Số QĐ: " & txtSoQuyetDinhCapGCN.Text & " - Đơn vị QĐ:" & txtDonViQuyetDinhCapGCN.Text)
                    'Xóa dữ liệu trên Form
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Quyết định cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtDonViQuyetDinhCapGCN.ReadOnly = Not blnCapNhat
            .txtSoQuyetDinhCapGCN.ReadOnly = Not blnCapNhat
            .dtpNgayQuyetDinhCapGCN.Enabled = blnCapNhat
            If blnCapNhat Then
                .txtDonViQuyetDinhCapGCN.BackColor = Color.White
                .txtSoQuyetDinhCapGCN.BackColor = Color.White
            Else
                .txtDonViQuyetDinhCapGCN.BackColor = Color.LightYellow
                .txtSoQuyetDinhCapGCN.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongTinQuyetDinhCapGCN.Clear()
            .txtDonViQuyetDinhCapGCN.Text = ""
            .txtSoQuyetDinhCapGCN.Text = ""
            .dtpNgayQuyetDinhCapGCN.Value = Date.Now
            .dtpNgayQuyetDinhCapGCN.Checked = False
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
        If strMaQuyetDinhCapGCN <> "" Then
            shortAction = 2
            With Me
                'Trạng thái chức năng
                .TrangThaiChucNang(True)
                'Trạng thái cập nhật
                .TrangThaiCapNhat(True)
                strThongTinCu = "Số QĐ: " & txtSoQuyetDinhCapGCN.Text & " - Đơn vị QĐ:" & txtDonViQuyetDinhCapGCN.Text
            End With
        Else
            MsgBox(" Bạn CHƯA chọn Quyết định cần sửa thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If strMaQuyetDinhCapGCN <> "" Then
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
        strMaQuyetDinhCapGCN = ""
        strError = ""
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Try
            'Cập nhật thông tin Quyết định cấp GCN
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Quyết định cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
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

    Private Sub ctrlThongTinQuyetDinhCapGCN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .dtpNgayQuyetDinhCapGCN
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
        If ((strMaQuyetDinhCapGCN = Nothing) Or (strMaQuyetDinhCapGCN = "")) Then
            shortAction = 1
            ' Thiết lập trạng thái ban đầu 
            Me.TrangThaiBanDau()
            ' Thiết lập trạng thái cập nhật cho các điều khiển 
            Me.TrangThaiCapNhat(True)
            ' Trạng thái chức năng 
            Me.TrangThaiChucNang(True, False)
        End If
    End Sub

    Private Sub txtSoQuyetDinhCapGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoQuyetDinhCapGCN.KeyDown
        If (e.KeyValue = 13) Then
            txtDonViQuyetDinhCapGCN.Focus()
        End If
    End Sub

    Private Sub txtDonViQuyetDinhCapGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDonViQuyetDinhCapGCN.KeyDown
        If (e.KeyValue = 13) Then
            btnGhi.Focus()
        End If
    End Sub

    Private Sub cmdCQQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCQQD.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtDonViQuyetDinhCapGCN.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub
End Class
