Imports System.Drawing
Imports System.Windows.Forms
Public Class ctrlThongTinPhapLyKhac
    'Định nghĩa trạng thái Thẩm định Hồ sơ có giá trị bằng 4
    ReadOnly TRANG_THAI_THAM_DINH As Integer = 4
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaHoSoCapGCN As String
    'Khai báo biến trạng thái Hồ sơ cấp GCN
    Private longTrangThaiHoSoCapGCN As Integer = 0
    Private dtThamDinh As New DataTable
    Private blnNonNumberEntered As Boolean
    Private shFlag As Short = 0
    Private strThongTinCu As String
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public WriteOnly Property Flag() As String
        Set(ByVal value As String)
            shFlag = value
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
    Private strMaDonViHanhChinh As String = ""
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    'Khai báo thuộc tính chỉ đọc Trạng thái Hồ sơ cấp GCN
    Public ReadOnly Property TrangThaiHoSoCapGCN() As Long
        Get
            Return longTrangThaiHoSoCapGCN
        End Get
    End Property
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Thẩm định nhà ở"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    ' Hien thi du lieu Phe duyet 
    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox2.Enabled = True
        Else
            Me.GroupBox2.Enabled = False
        End If
        'Khai bao va khoi tao doi tuong clsThamDinh
        Dim ThamDinh As New clsThongTinPhapLyKhac
        Try
            'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
            'Nhận chuỗi kết nối Database
            ThamDinh.Connection = strConnection
            ThamDinh.MaHoSoCapGCN = strMaHoSoCapGCN
            'Khoi tao trang thai ban dau
            TrangThaiBanDau()
            'Goi phuong thuc GetData de khoi tao doi tuong clsHSKKTaiSan
            If ThamDinh.GetData(dtThamDinh) = "" Then
                ' Trinh bay du lieu len grdvwTaiSan
                If dtThamDinh.Rows.Count > 0 Then
                    For i As Integer = 0 To dtThamDinh.Rows.Count - 1
                        With dtThamDinh.Rows(i)
                            'Trạng thái Hồ sơ cấp GCN TrangThaiHoSoCapGCN
                            If IsNumeric(.Item("TrangThaiHoSoCapGCN").ToString) Then
                                Me.longTrangThaiHoSoCapGCN = Convert.ToInt16(.Item("TrangThaiHoSoCapGCN").ToString)
                            Else
                                Me.longTrangThaiHoSoCapGCN = 0
                            End If
                            'Ngày nộp đủ hồ sơ hợp lệ
                            If Not IsDate(.Item("NgayNopDuHoSoHopLe").ToString) Then
                                Me.dtpNgayNopDuHoSoHopLe.Value = Date.Now.Date
                                Me.dtpNgayNopDuHoSoHopLe.Checked = False
                            Else
                                Me.dtpNgayNopDuHoSoHopLe.Value = Convert.ToDateTime(.Item("NgayNopDuHoSoHopLe").ToString).Date
                                Me.dtpNgayNopDuHoSoHopLe.Checked = True
                            End If
                            'Trình tự thủ tục phường
                            Me.cmbTrinhTuThuTucPhuong.Text = .Item("TrinhTuThuTucPhuong").ToString
                            'Các khoản phải nộp
                            Me.txtCacKhoanPhaiNop.Text = .Item("CacKhoanPhaiNop").ToString
                            Me.txtGhiChuThamDinh.Text = .Item("GhiChuThamDinh").ToString
                            Me.txtLyDo.Text = .Item("LyDoThamDinh").ToString
                            Me.txtSoSeri.Text = .Item("SoSerriToTrinh").ToString
                        End With
                    Next i
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu thẩm định " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub UpdateData()
        'Khai bao va khoi tao doi tuong clsThamDinh
        Dim ThamDinh As New clsThongTinPhapLyKhac
        Try
            'Xac nhan gia tri can cap nhat
            'Nhận chuỗi kết nối Database
            With ThamDinh
                .Connection = strConnection
                ' Kiểm tra trạng thái Hồ sơ trước khi cập nhật:
                ' Nếu giá trị trạng thái Hồ sơ hiện thời nhỏ hơn
                ' giá trị trạng thái Thẩm định thì ta lấy là giá trị 
                ' trạng thái tiếp nhận Hồ sơ, ngược lại giữ nguyên giá trị 
                If (longTrangThaiHoSoCapGCN < TRANG_THAI_THAM_DINH) Then
                    ThamDinh.TrangThaiHoSoCapGCN = TRANG_THAI_THAM_DINH
                Else
                    ThamDinh.TrangThaiHoSoCapGCN = longTrangThaiHoSoCapGCN
                End If
                .MaHoSoCapGCN = strMaHoSoCapGCN
                'Thông tin trình tự thủ tục hồ sơ và nghĩa vụ tài chính
                If (Me.dtpNgayNopDuHoSoHopLe.Checked) Then
                    .NgayNopDuHoSoHopLe = Me.dtpNgayNopDuHoSoHopLe.Text
                Else
                    .NgayNopDuHoSoHopLe = Nothing
                End If
                .TrinhTuThuTucPhuong = Me.cmbTrinhTuThuTucPhuong.Text
                .CacKhoanPhaiNop = Me.txtCacKhoanPhaiNop.Text.Trim
                .GhiChuThamDinh = Me.txtGhiChuThamDinh.Text.Trim
                .LyDo = Me.txtLyDo.Text.Trim
                .SoSerriToTrinh = Me.txtSoSeri.Text.Trim
                Dim str As String = ""
                'Trường hợp thêm mới
                If (shFlag = 1) Then
                    ThamDinh.InsertThamDinhByMaHoSoCapGCN()
                    'strThongTinCu = dtpNgayNopDuHoSoHopLe.Text & "-" & cmbTrinhTuThuTucPhuong.Text & " - " & txtLyDo.Text 
                    NhatKyNguoiDung("Thêm", dtpNgayNopDuHoSoHopLe.Text & "-" & cmbTrinhTuThuTucPhuong.Text & " - " & txtLyDo.Text)
                ElseIf shFlag = 2 Then
                    'Trường hợp cập nhật
                    ThamDinh.UpdateThamDinhByMaHoSoCapGCN()
                    NhatKyNguoiDung("Sửa", "Thay (" & strThongTinCu & ") bằng (" & dtpNgayNopDuHoSoHopLe.Text & "-" & cmbTrinhTuThuTucPhuong.Text & " - " & txtLyDo.Text & ")")
                End If
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu thẩm định " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtGhiChuThamDinh.ReadOnly = Not blnCapNhat
            .cmbTrinhTuThuTucPhuong.Enabled = blnCapNhat
            .txtCacKhoanPhaiNop.ReadOnly = Not blnCapNhat
            .txtLyDo.ReadOnly = Not blnCapNhat
            .dtpNgayNopDuHoSoHopLe.Enabled = blnCapNhat
            .txtSoSeri.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtGhiChuThamDinh.BackColor = Color.White
                .cmbTrinhTuThuTucPhuong.BackColor = Color.White
                .txtCacKhoanPhaiNop.BackColor = Color.White
                .txtLyDo.BackColor = Color.White
                .txtSoSeri.BackColor = Color.White
            Else
                .txtGhiChuThamDinh.BackColor = Color.LightYellow
                .cmbTrinhTuThuTucPhuong.BackColor = Color.LightYellow
                .txtCacKhoanPhaiNop.BackColor = Color.LightYellow
                .txtLyDo.BackColor = Color.LightYellow
                .txtSoSeri.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThamDinh.Clear()
            .txtGhiChuThamDinh.Text = ""
            .cmbTrinhTuThuTucPhuong.Text = ""
            .txtCacKhoanPhaiNop.Text = ""
            .txtLyDo.Text = ""
            .txtSoSeri.Text = ""
            .dtpNgayNopDuHoSoHopLe.Checked = False
            .dtpNgayNopDuHoSoHopLe.Value = Date.Now.Date
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox2.Enabled = True
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnCapNhat.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnCapNhat.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                End If
            Else
                Me.GroupBox2.Enabled = False

            End If

        End With
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        shFlag = 2
        With Me
            'Trang thai chuc nang
            .TrangThaiChucNang(True)
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            strThongTinCu = dtpNgayNopDuHoSoHopLe.Text & "-" & cmbTrinhTuThuTucPhuong.Text & " - " & txtLyDo.Text
        End With
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        With Me
            If strMaHoSoCapGCN <> "" Then
                If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                    Dim ThamDinh As New clsThongTinPhapLyKhac
                    ThamDinh.Connection = strConnection
                    ThamDinh.MaHoSoCapGCN = strMaHoSoCapGCN
                    ThamDinh.DeleteThamDinhByMaHoSoCapGCN()
                    NhatKyNguoiDung("Xóa", dtpNgayNopDuHoSoHopLe.Text & "-" & cmbTrinhTuThuTucPhuong.Text & " - " & txtLyDo.Text)
                    'Trạng thái ban đầu
                    .TrangThaiBanDau()
                    'Trạng thái chức năng
                    .TrangThaiChucNang(True, True)
                    If (strError = "") Then
                        MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                    Else
                        MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                    End If
                Else
                    'Trạng thái chức năng
                    .TrangThaiChucNang()
                End If
            End If
            'Thiết lập trạng thái cập nhật
            .TrangThaiCapNhat()
            'Hiển thị dữ liệu
            Me.ShowData()
        End With
        strError = ""
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Try
            'Cap nhat thong tin Tham Dinh
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật thẩm định " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Trang thai chuc nang
        Me.TrangThaiChucNang()
        'Trang thai cap nhat
        Me.TrangThaiCapNhat()
        'Hiển thị dữ liệu
        Me.ShowData()
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        strError = ""
    End Sub

    Private Sub ctrlThamDinh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .dtpNgayNopDuHoSoHopLe
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
            'Thiết lập trạng thái chức năng
            .TrangThaiChucNang(True, True)
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Xoa du lieu tren Form
            .TrangThaiBanDau()
            'Hien thi du lieu
            If strMaHoSoCapGCN <> "" Then
                .ShowData()
            End If
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat 
            .TrangThaiCapNhat()
        End With
        shFlag = 0
    End Sub

    Private Sub btnPhieuThamDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPhieuThamDinh.Click
        Try
            If strMaHoSoCapGCN <> "" Then
                Dim frmRpt As New frmRptThamDinh
                With frmRpt
                    With .CtrlRptPhieuThamDinh
                        'Xác nhận chuỗi kết nối cơ sở dữ liệu
                        .Connection = strConnection
                        'Xác nhận Hồ sơ cấp GCN cần hiển thị thông tin Thẩm định
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                    End With
                    .Show()
                End With
            Else
                MsgBox("Hồ sơ chưa có thông tin Thẩm định!", MsgBoxStyle.Information, "DMCLand")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Lỗi trong điều khiển Phiếu thẩm định: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub chkTongHopTuMucDichSuDung_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        With Me
            'Gán giá trị cho điều khiển tương ứng
            .Refresh()
        End With
    End Sub

    Private Sub txtCacKhoanPhaiNop_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCacKhoanPhaiNop.DoubleClick
        If txtCacKhoanPhaiNop.ReadOnly = False Then
            Try
                With Me
                    Dim frm As New frmBangMa
                    With frm
                        With .CtrlTuDienNghiaVuTaiChinh
                            'Gán chuỗi kết nối cơ sở dữ liệu
                            .Connection = strConnection
                        End With
                        .ShowDialog()
                        With .CtrlTuDienNghiaVuTaiChinh
                            If .KyHieu <> "" Then
                                'Hien thi truong hop nghia vu tai chinh
                                txtCacKhoanPhaiNop.Text = .KyHieu
                                'Hien thi noi dung nghia vu tai chinh 
                                txtCacKhoanPhaiNop.Text = .MoTa
                                .KyHieu = ""
                                .MoTa = ""
                            End If
                        End With
                    End With
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Thông tin THẨM ĐỊNH " & vbNewLine & "  Nghĩa vụ tài chính " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub btnHoSoKiThuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHoSoKiThuat.Click
        Dim HoSoKiThuat As New frmHoSoKiThuat
        With HoSoKiThuat
            With .CtrInHoSoKyThuat
                .Conection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .CtrInHoSoKyThuat_Load()
            End With
            .ShowDialog()
        End With
    End Sub

    Private Sub cmbTrinhTuThuTucPhuong_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTrinhTuThuTucPhuong.KeyDown
        If (e.KeyValue = 13) Then
            txtLyDo.Focus()
        End If
    End Sub

    Private Sub txtLyDo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLyDo.KeyDown
        If (e.KeyValue = 13) Then
            txtCacKhoanPhaiNop.Focus()
        End If
    End Sub

    Private Sub txtCacKhoanPhaiNop_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCacKhoanPhaiNop.KeyDown
        If (e.KeyValue = 13) Then
            txtSoSeri.Focus()
        End If
    End Sub

    Private Sub txtSoSeri_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoSeri.KeyDown
        If (e.KeyValue = 13) Then
            txtGhiChuThamDinh.Focus()
        End If
    End Sub

    Private Sub txtGhiChuThamDinh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGhiChuThamDinh.KeyDown
        If (e.KeyValue = 13) Then
            btnCapNhat.Focus()
        End If
    End Sub
End Class
