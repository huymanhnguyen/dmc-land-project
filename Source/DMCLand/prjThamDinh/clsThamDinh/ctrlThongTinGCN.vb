Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlThongTinGCN
    ' Định nghĩa trạng thái CẤP GCN có giá trị bằng 6
    ReadOnly TRANG_THAI_CAP_GCN As Integer = 6
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã hồ số cấp GCN
    Private strMaHoSoCapGCN As String = ""
    'Khai báo biến trạng thái Hồ sơ cấp GCN
    Private longTrangThaiHoSoCapGCN As Integer = 0
    Private dtThongTinGCN As New DataTable
    Private shortAction As Short = 0
    Private strThongTinCu As String
    Private strMaDonViHanhChinh As String
    Private strSoHoGocOld As String = ""
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
        clsNhatky.NghiepVu = "Thông tin GCN"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    'Hiển thị thông tin GCN
    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox2.Enabled = True
        Else
            Me.GroupBox2.Enabled = False
        End If
        'Khai báo và khởi tạo lớp Thông tin GCN
        Dim ThongTinGCN As New clsThongTinGCN
        Try
            'Gán giá trị các thuộc tính đối với trường hợp truy vấn
            With ThongTinGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Truy vấn thông tin
            If ThongTinGCN.GetData(dtThongTinGCN) = "" Then
                'Trình bày dữ liệu lên Form
                If dtThongTinGCN.Rows.Count > 0 Then
                    Me.txtMaXa.Text = dtThongTinGCN.Rows(0).Item("MaXa").ToString
                    If IsDate(dtThongTinGCN.Rows(0).Item("NgayKyGCN").ToString) Then
                        Me.dtpNgayKyGCN.Value = Convert.ToDateTime(dtThongTinGCN.Rows(0).Item("NgayKyGCN").ToString)
                        Me.dtpNgayKyGCN.Checked = True
                    Else
                        Me.dtpNgayKyGCN.Value = Date.Now
                        Me.dtpNgayKyGCN.Checked = False
                    End If
                    Me.txtSoHoSoGoc.Text = dtThongTinGCN.Rows(0).Item("SoHoSoGoc").ToString
                    strSoHoGocOld = dtThongTinGCN.Rows(0).Item("SoHoSoGoc").ToString
                    Me.txtSoPhatHangGCN.Text = dtThongTinGCN.Rows(0).Item("SoPhatHanhGCN").ToString
                    'Trạng thái Hồ sơ cấp GCN TrangThaiHoSoCapGCN
                    If IsNumeric(dtThongTinGCN.Rows(0).Item("TrangThaiHoSoCapGCN").ToString) Then
                        Me.longTrangThaiHoSoCapGCN = Convert.ToInt16(dtThongTinGCN.Rows(0).Item("TrangThaiHoSoCapGCN").ToString)
                    Else
                        Me.longTrangThaiHoSoCapGCN = 0
                    End If
                    Me.txtGhiChuGCN.Text = dtThongTinGCN.Rows(0).Item("GhiChuGCN").ToString
                    Me.txtMaSoGCN.Text = dtThongTinGCN.Rows(0).Item("MaSoGCN").ToString

                    Me.txtNghiaVuTaiChinh.Text = dtThongTinGCN.Rows(0).Item("NghiaVuTaiChinh").ToString
                    Me.txtCoQuanCapGCN.Text = dtThongTinGCN.Rows(0).Item("CoQuanCapGCN").ToString
                    If dtThongTinGCN.Rows(0).Item("InKhungMat3").ToString = "False" Or IsDBNull(dtThongTinGCN.Rows(0).Item("InKhungMat3")) Then
                        ChkInKhungMat3.Checked = False
                    Else
                        ChkInKhungMat3.Checked = True
                    End If
                    If dtThongTinGCN.Rows(0).Item("InSoDoThuaDat").ToString = "False" Or IsDBNull(dtThongTinGCN.Rows(0).Item("InSoDoThuaDat")) Then
                        chkInHoSoThuaDat.Checked = False
                    Else
                        chkInHoSoThuaDat.Checked = True
                    End If
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin GCN" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp Thông tin GCN
        Dim ThongTinGCN As New clsThongTinGCN
        Try
            'Xác nhận giá trị cần cập nhật
            With ThongTinGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                '' Kiểm tra trạng thái Hồ sơ trước khi cập nhật:
                '' Nếu giá trị trạng thái Hồ sơ hiện thời nhỏ hơn
                '' giá trị trạng thái Cấp GCN thì ta lấy là giá trị 
                '' trạng thái Cấp GCN, ngược lại giữ nguyên giá trị 
                ''Chắc chắn rằng Số Hồ sơ gốc phải là kiểu số
                'If Not IsNumeric(Me.txtSoHoSoGoc.Text.Trim) Then
                '    If (System.Windows.Forms.MessageBox.Show("Hồ sơ gốc phải là kiểu số" + vbNewLine + "Bạn có muốn nhập lại không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes) Then
                '        txtSoHoSoGoc.Focus()
                '        Exit Sub
                '    End If
                'End If
                ''Chắc chắn rằng Số Hồ sơ gốc phải gồm 6 số
                'If Me.txtSoHoSoGoc.Text.Trim.Length <> 6 Then
                '    If (System.Windows.Forms.MessageBox.Show("Hồ sơ gốc phải gồm 6 số" + vbNewLine + "Bạn có muốn nhập lại không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes) Then
                '        Me.txtSoHoSoGoc.Focus()
                '        Exit Sub
                '    End If
                'End If
                .SoHoSoGoc = Me.txtSoHoSoGoc.Text.Trim
                .SoPhatHanhGCN = Me.txtSoPhatHangGCN.Text.Trim
                If (longTrangThaiHoSoCapGCN < TRANG_THAI_CAP_GCN) Then
                    ThongTinGCN.TrangThaiHoSoCapGCN = TRANG_THAI_CAP_GCN
                Else
                    ThongTinGCN.TrangThaiHoSoCapGCN = longTrangThaiHoSoCapGCN
                End If
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .GhiChuGCN = Me.txtGhiChuGCN.Text.Trim
                .MaSoGCN = Me.txtMaSoGCN.Text.Trim
                .NghiaVuTaiChinh = Me.txtNghiaVuTaiChinh.Text.Trim
                .CoQuanCapGCN = Me.txtCoQuanCapGCN.Text.Trim
                If ChkInKhungMat3.Checked Then
                    .CheckInKhungMat3 = "True"
                Else
                    .CheckInKhungMat3 = "False"
                End If
                If chkInHoSoThuaDat.Checked Then
                    .CheckInHoSoThuaDatMat3 = "True"
                Else
                    .CheckInHoSoThuaDatMat3 = "False"
                End If
                Dim str As String = ""
                'Trường hợp sửa 
                If shortAction = 2 Then
                    ThongTinGCN.UpdateThongTinGCNByMaHoSoCapGCN()
                    'strThongTinCu = "HS gốc: " & txtSoHoSoGoc.Text & " - mã vạch: " & txtMaSoGCN.Text & " - Số phát hàng: " & txtSoPhatHangGCN.Text  & " - ghi chú: " & txtGhiChuGCN.Text
                    NhatKyNguoiDung("Cập nhật", "Thay (" & strThongTinCu & ") bằng (" & "HS gốc: " & txtSoHoSoGoc.Text & " - mã vạch: " & txtMaSoGCN.Text & " - Số phát hàng: " & txtSoPhatHangGCN.Text & " - ghi chú: " & txtGhiChuGCN.Text & ")")
                ElseIf shortAction = 3 Then
                    ThongTinGCN.DeleteThongTinGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Xóa", "HS gốc: " & txtSoHoSoGoc.Text & " - mã vạch: " & txtMaSoGCN.Text & " - Số phát hàng: " & txtSoPhatHangGCN.Text & " - ghi chú: " & txtGhiChuGCN.Text)
                    'Xóa dữ liệu trên Form
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin GCN" & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Function ktTonTaiMaVach() As Boolean
        Dim kt As Boolean = False
        Dim MaVach As New clsThongTinGCN
        MaVach.Connection = strConnection
        MaVach.MaSoGCN = txtSoHoSoGoc.Text.Trim
        Dim dt As New DataTable
        MaVach.selKiemTraTrungMaVach(dt)
        If (dt.Rows.Count = 0) Then
            kt = True
        Else
            kt = False
        End If
        Return kt
    End Function
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtGhiChuGCN.ReadOnly = Not blnCapNhat
            .txtMaSoGCN.ReadOnly = Not blnCapNhat
            .txtNghiaVuTaiChinh.ReadOnly = Not blnCapNhat
            .txtCoQuanCapGCN.ReadOnly = Not blnCapNhat
            .txtSoHoSoGoc.ReadOnly = Not blnCapNhat
            .txtSoPhatHangGCN.ReadOnly = Not blnCapNhat

            .btnSoHoSoGoc.Enabled = blnCapNhat
            .btnMaSoGCN.Enabled = blnCapNhat
            If blnCapNhat Then
                .txtGhiChuGCN.BackColor = Color.White
                .txtMaSoGCN.BackColor = Color.White
                .txtNghiaVuTaiChinh.BackColor = Color.White
                .txtCoQuanCapGCN.BackColor = Color.White
                .txtSoHoSoGoc.BackColor = Color.White
                .txtSoPhatHangGCN.BackColor = Color.White
            Else
                .txtGhiChuGCN.BackColor = Color.LightYellow
                .txtMaSoGCN.BackColor = Color.LightYellow
                .txtNghiaVuTaiChinh.BackColor = Color.LightYellow
                .txtCoQuanCapGCN.BackColor = Color.LightYellow
                .txtSoHoSoGoc.BackColor = Color.LightYellow
                .txtSoPhatHangGCN.BackColor = Color.LightYellow
            End If
            'Không cho phép cập nhật Ngày ký GCN và Mã xã
            .txtMaXa.ReadOnly = True
            .dtpNgayKyGCN.Enabled = False
            .ChkInKhungMat3.Enabled = blnCapNhat
            .chkInHoSoThuaDat.Enabled = blnCapNhat
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongTinGCN.Clear()
            .txtGhiChuGCN.Text = ""
            .txtMaSoGCN.Text = ""
            .txtNghiaVuTaiChinh.Text = ""
            .txtCoQuanCapGCN.Text = ""
            .txtSoHoSoGoc.Text = ""
            .txtSoPhatHangGCN.Text = ""
            .txtMaXa.Text = ""
            .dtpNgayKyGCN.Value = Date.Now
            .dtpNgayKyGCN.Checked = False
            .ChkInKhungMat3.Checked = True
            .chkInHoSoThuaDat.Checked = True
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
            strThongTinCu = "HS gốc: " & txtSoHoSoGoc.Text & " - mã vạch: " & txtMaSoGCN.Text & " - Số phát hàng: " & txtSoPhatHangGCN.Text & " - ghi chú: " & txtGhiChuGCN.Text
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
            'Cập nhật thông tin Quyết định cấp GCN
            If strSoHoGocOld.Trim.ToUpper = txtSoHoSoGoc.Text.ToUpper Then
                Me.UpdateData()
            Else
                If ktTonTaiMaVach() Then
                    Me.UpdateData()
                Else
                    MessageBox.Show("Mã vạch đã tồn tại....", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtMaSoGCN.Focus()
                    Return
                End If
            End If
            

        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
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

    Private Sub ctrlThongTinGCN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .dtpNgayKyGCN
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
    Public Sub LoadNghiaVuTaiChinh()
        If txtNghiaVuTaiChinh.ReadOnly = False Then
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
                                txtNghiaVuTaiChinh.Text = .KyHieu
                                'Hien thi noi dung nghia vu tai chinh 
                                txtNghiaVuTaiChinh.Text = .MoTa
                                .KyHieu = ""
                                .MoTa = ""
                            End If
                        End With
                    End With
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Thông tin cấp GCN " & vbNewLine & "  Nghĩa vụ tài chính " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub txtNghiaVuTaiChinh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNghiaVuTaiChinh.KeyDown
        If e.KeyData = Keys.F8 Then
            LoadNghiaVuTaiChinh()
        End If
    End Sub

    Private Sub btnSoHoSoGoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoHoSoGoc.Click
        'Số hồ sơ gốc lớn nhất
        Dim intSoHoSoGocLonNhat As Int32 = 0
        Dim dtSoHoSoGocLonNhat As New DataTable
        Dim ThongTinGCN As New clsThongTinGCN
        ThongTinGCN.Connection = strConnection
        ThongTinGCN.MaHoSoCapGCN = strMaHoSoCapGCN
        'Kiểm tra tính hợp lệ của dữ liệu
        'Chỉ tạo Số hồ sơ gốc tự động khi có đủ thông tin cần thiết
        'Không tạo số hồ sơ gốc khi không có Mã xã/phường
        If (txtMaXa.Text.Trim = "") Then
            Return
        End If
        'Không tạo số hồ sơ gốc khi không có Năm ký cấp GCN (Ngày ký cấp GCN)
        'If (dtpNgayKyGCN.Checked = False) Then
        '    Return
        'End If
        dtSoHoSoGocLonNhat = ThongTinGCN.SelectSoHoSoGocLonNhatByMaHoSoCapGCN
        If (dtSoHoSoGocLonNhat IsNot Nothing) Then
            If dtSoHoSoGocLonNhat.Rows.Count > 0 Then
                If Not IsDBNull(dtSoHoSoGocLonNhat.Rows(0).Item("SoHoSoGocLonNhat")) Then
                    intSoHoSoGocLonNhat = dtSoHoSoGocLonNhat.Rows(0).Item("SoHoSoGocLonNhat").ToString
                End If
            End If
        End If
        'Tăng giá trị tự động lên 1 đơn vị
        'Rồi gán vào mục Thứ tự vào sổ cấp GCN
        Me.txtSoHoSoGoc.Text = (intSoHoSoGocLonNhat).ToString
    End Sub

    Private Sub btnMaSoGCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaSoGCN.Click
        'Tổng hợp thông tin Số vào sổ cấp GCN
        Dim strMaSoGCN As String = ""
        Dim strSoHoSoGoc As String = ""
        Dim strMaXa As String = ""

        'Xác nhận Mã xã tìm được
        strMaXa = Me.txtMaXa.Text.Trim

        'Cập nhật Mã đơn vị hành chính (Mã xã/Phường) 
        'đảm bảo gồm 5 số theo qui định tại thông tin 17/2009
        'Bộ tài nguyên môi trường
        'vào bảng tblHoSoCapGCN để in ra mã vạch
        Select Case strMaXa.Trim.Length()
            Case 1
                strMaXa = "0000" + strMaXa
            Case 2
                strMaXa = "000" + strMaXa
            Case 3
                strMaXa = "00" + strMaXa
            Case 4
                strMaXa = "0" + strMaXa
            Case 5
                strMaXa = strMaXa
            Case Else
                strMaXa = "00000"
        End Select

        'Khai báo biến nhận hai số cuối của năm cấp GCN
        Dim intHaiSoCuoiNamCapGCN As String = "00"
        If IsNumeric(txtMaXa.Text.Trim) Then 'And (dtpNgayKyGCN.Checked) Then
            Select Case txtSoHoSoGoc.Text.Trim.Length
                Case 1
                    'Chắc chắn rằng số thứ tự khác 0
                    If txtSoHoSoGoc.Text.Trim = "0" Then
                        Exit Sub
                    End If
                    strSoHoSoGoc = "00000" + txtSoHoSoGoc.Text.Trim
                Case 2
                    strSoHoSoGoc = "0000" + txtSoHoSoGoc.Text.Trim
                Case 3
                    strSoHoSoGoc = "000" + txtSoHoSoGoc.Text.Trim
                Case 4
                    strSoHoSoGoc = "00" + txtSoHoSoGoc.Text.Trim
                Case 5
                    strSoHoSoGoc = "0" + txtSoHoSoGoc.Text.Trim
                Case Else
                    Exit Sub
            End Select
            intHaiSoCuoiNamCapGCN = dtpNgayKyGCN.Value.Year.ToString.Substring(2, 2)
            strMaSoGCN = strMaXa + intHaiSoCuoiNamCapGCN.ToString + strSoHoSoGoc
            txtMaSoGCN.Text = strMaSoGCN
        End If
    End Sub

    Private Sub ChkInKhungMat3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInKhungMat3.CheckedChanged
        'If ChkInKhungMat3.Checked Then
        '    ChkInKhungMat3.Text = "Có"
        'Else
        '    ChkInKhungMat3.Text = "Không"
        'End If
    End Sub

    Private Sub txtSoHoSoGoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoHoSoGoc.KeyDown
        If (e.KeyValue = 13) Then
            txtMaSoGCN.Focus()
        End If
    End Sub

    Private Sub txtMaSoGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaSoGCN.KeyDown
        If (e.KeyValue = 13) Then
            txtSoPhatHangGCN.Focus()
        End If
    End Sub

    Private Sub txtSoPhatHangGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoPhatHangGCN.KeyDown
        If (e.KeyValue = 13) Then
            txtCoQuanCapGCN.Focus()
        End If
    End Sub

    Private Sub txtCoQuanCapGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoQuanCapGCN.KeyDown
        If (e.KeyValue = 13) Then
            txtGhiChuGCN.Focus()
        End If
    End Sub

    Private Sub txtGhiChuGCN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGhiChuGCN.KeyDown
        If (e.KeyValue = 13) Then
            btnGhi.Focus()
        End If
    End Sub

    Private Sub cmdCoQuanCapGCn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCoQuanCapGCn.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtCoQuanCapGCN.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub

    Private Sub cmdGhiChuGCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGhiChuGCN.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtGhiChuGCN.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub
End Class
