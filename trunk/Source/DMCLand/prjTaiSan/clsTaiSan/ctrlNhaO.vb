Imports System.Windows.Forms
Imports System.Drawing
Public Class ctrlNhaO
    Private strMaHoSoCapGCN As String = ""
    Private dtNhaO As New DataTable
    Private blnNonNumberEntered As Boolean
    ' Khai báo nhận Tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaNhaO As String = ""
    Private shortAction As Short = 0
    'lay cac gia tri chon dc
    Private strDiaChiNha As String = ""
    Private dblDienTichXayDung As String = ""
    Private strKetCauNha As String = ""
    Private strCapHangNha As String = ""
    Private strSoTang As String = ""
    Private strSoNha As String = ""
    Private strLoaiNha As String = ""
    Private strThoiHanSoHuu As String = ""

    Private strNamXayDung As String
    Private strNamHoanThanhXayDung As String
    Private strCoQuanCapGPXD As String = ""
    Private dblDienTichSanPhu As String = ""
    Private dblDienTichSanXayDung As String = ""
    'Số giấy phép xây dựng
    Private strSoGiayPhepXayDung As String = ""
    Private strNgayCapPhepXayDung As String = ""
    'Thông tin xử lý vi phạm
    Private strThongTinXuLyViPham As String = ""
    Private strThongTinChuCu As String = ""
    Private strMaDonViHanhChinh As String = ""
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    'Khai báo nhận Tên đơn vị hành chính
    Public WriteOnly Property TenDonViHanhChinh() As String
        Set(ByVal value As String)
            strTenDonViHanhChinh = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public WriteOnly Property Flag() As String
        Set(ByVal value As String)
            shortAction = value
        End Set
    End Property
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property MaNhaO() As String
        Get
            Return strMaNhaO
        End Get
        Set(ByVal value As String)
            strMaNhaO = value
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

    Public Sub ShowData()
      
        'Khai báo và khởi tạo đối tượng
        Dim NhaO As New clsNhaO
        'Gán giá trị cho các thuộc tính đối với trường hợp truy vấn
        Try
            With NhaO
                'Nhận chuỗi kết nối cơ sở dữ liệu
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            dtNhaO.Clear()
            With Me.grdvwNhaO
                .ClearSelection()
                'Gọi phương thức GetData 
                If NhaO.SelectNhaOByMaHoSoCapGCN(dtNhaO) = "" Then
                    'Trình bày dữ liệu lên Grid
                    .DataSource = dtNhaO
                    'Định dạng các cột của Grid
                    If dtNhaO.Rows.Count > 0 Then
                        Me.FormatGridContruction()
                    Else
                        Me.HideAllColumns(grdvwNhaO)
                    End If
                End If
            End With
            'Thiết đặt trạng thái ban đầu
            Me.TrangThaiBanDau()
            'Trạng thái chức năng
            Me.TrangThaiChucNang()
            'Trạng thái cập nhật
            Me.TrangThaiCapNhat()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Nhà ở (Căn hộ) " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox2.Enabled = True
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnThem.Enabled = Not blnStartEdited
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
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Cập nhật mục đích sử dụng"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    Public Sub UpdateData()
        'Khai báo và khởi tạo đối tượng Nhà ở
        Dim NhaO As New clsNhaO
        Try
            With NhaO
                'Nhận chuỗi kết nối cơ sở dữ liệu
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaNhaO = strMaNhaO
                .DiaChiNha = txtDiaChiNha.Text.Trim
                If IsNumeric(numDienTichXayDung.Text.Trim) Then
                    .DienTichXayDung = numDienTichXayDung.Text.Trim
                Else
                    .DienTichXayDung = Nothing
                End If
                .KetCauNha = txtKetCauNha.Text.Trim
                .CapHangNha = cmbCapHangNha.Text.Trim
                .SoTang = txtSoTang.Text.Trim
                .SoNha = txtSoNha.Text.Trim
                .LoaiNha = cmbLoaiNha.Text.Trim
                .ThoiHanSoHuu = txtThoiHanSoHuu.Text.Trim
                If IsNumeric(numNamXayDung.Text.Trim) Then
                    .NamXayDung = numNamXayDung.Text.Trim
                Else
                    .NamXayDung = Nothing
                End If
                If IsNumeric(numNamHoanThanhXayDung.Text.Trim) Then
                    .NamHoanThanhXayDung = numNamHoanThanhXayDung.Text.Trim
                Else
                    .NamHoanThanhXayDung = Nothing
                End If
                If IsNumeric(numDienTichSanXayDung.Text.Trim) Then
                    .DienTichSanXayDung = numDienTichSanXayDung.Text.Trim
                Else
                    .DienTichSanXayDung = Nothing
                End If
                .CoQuanCapGPXD = txtCoQuanCapGPXD.Text.Trim
                If IsNumeric(numDienTichSanPhu.Text.Trim) Then
                    .DienTichSanPhu = numDienTichSanPhu.Text.Trim
                Else
                    .DienTichSanPhu = Nothing
                End If
                '.DienTichSanXayDung = DienTichSanXayDung
                'Số giấy phép xây dựng
                .SoGiayPhepXayDung = txtSoGPXD.Text.Trim
                If dtpNgayCapPhepXayDung.Checked Then
                    .NgayCapPhepXayDung = dtpNgayCapPhepXayDung.Text
                Else
                    .NgayCapPhepXayDung = Nothing
                End If
                'Thông tin xử lý vi phạm
                .ThongTinXuLyViPham = txtThongTinViPham.Text.Trim
                .NguonGocNha = txtNguonGocNha.Text
                .GiaTriConLai = txtGiaTriConLai.Text
                .GhiChu = txtGhiChu.Text

                .SoHuuRieng = NumSoHuuRieng.Value.ToString
                .SoHuuChung = NumSoHuuChung.Value.ToString
                If chkCapPhepXD.Checked Then
                    .isGPXD = "1"
                Else
                    .isGPXD = "0"
                End If

                Dim str As String = ""
                Dim strResults As String = ""
                ' strThongTinChuCu = "So nhà " & txtSoNha.Text & "_ diện tích " & numDienTichXayDung.Text & "m2_" & txtKetCauNha.Text & "_" & txtSoTang.Text
                If (shortAction = 1) Then
                    strResults = .InsertNhaO(str)
                    NhatKyNguoiDung("Thêm", "Số nhà " & txtSoNha.Text & "_ diện tích " & numDienTichXayDung.Text & "m2_" & txtKetCauNha.Text & "_" & txtSoTang.Text)
                ElseIf (shortAction = 2) Then
                    strResults = .UpdateNhaO(str)
                    NhatKyNguoiDung("Sửa", "Thay (" & strThongTinChuCu & ") bằng   (" & "Số nhà " & txtSoNha.Text & "_ diện tích " & numDienTichXayDung.Text & "m2_" & txtKetCauNha.Text & "_" & txtSoTang.Text & ")")
                ElseIf (shortAction = 3) Then
                    strResults = .DeleteNhaOByMaNhaO(str)
                    NhatKyNguoiDung("Xóa", "Số nhà " & txtSoNha.Text & "_ diện tích " & numDienTichXayDung.Text & "m2_" & txtKetCauNha.Text & "_" & txtSoTang.Text)
                ElseIf (shortAction = 4) Then
                    strResults = .DeleteNhaOByMaHoSoCapGCN(str)
                    NhatKyNguoiDung("Xóa tất cả nhà", "Số nhà " & txtSoNha.Text & "_ diện tích " & numDienTichXayDung.Text & "m2_" & txtKetCauNha.Text & "_" & txtSoTang.Text)
                End If
                shortAction = 0
                strError = NhaO.Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nhà ở (Căn hộ) " & vbNewLine & " Cập nhật " & vbNewLine & _
                   " Lỗi " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Nếu tồn tại Mã Nhà ở sản cần xóa
        If strMaNhaO <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        shortAction = 3
                        .UpdateData()
                        strMaNhaO = ""
                    End With
                Catch ex As Exception
                    strError = ex.Message
                End Try
                If (strError = "") Then
                    MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                Else
                    MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                End If
            End If
        Else
            MsgBox(" Bạn phải chọn Nhà ở (Căn hộ) cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        'Hiển thị dữ liệu
        Me.ShowData()
        strError = ""
    End Sub

    Private Sub grdvwNhaO_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwNhaO.CellMouseClick
        'Chỉ thực thi khi người dùng chọn chuột trái
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khởi tạo đối tượng
        Dim NhaO As New clsNhaO
        If e.RowIndex >= 0 Then
            Try
                'Gán giá trị cho các thuộc tính ứng với trường hợp truy vấn
                shortAction = 0
                With Me.dtNhaO.Rows(e.RowIndex)
                    NhaO.CoQuanCapGPXD = .Item("CoQuanCapGPXD").ToString
                    NhaO.DiaChiNha = .Item("DiaChiNha").ToString
                    NhaO.DienTichSanPhu = .Item("DienTichSanPhu").ToString
                    If IsNumeric(.Item("DienTichSanXayDung").ToString) Then
                        NhaO.DienTichSanXayDung = .Item("DienTichSanXayDung").ToString
                    Else
                        NhaO.DienTichSanXayDung = Nothing
                    End If
                    NhaO.DienTichXayDung = .Item("DienTichXayDung").ToString
                    NhaO.KetCauNha = .Item("KetCauNha").ToString
                    NhaO.CapHangNha = .Item("CapHangNha").ToString
                    NhaO.LoaiNha = .Item("LoaiNha").ToString
                    NhaO.ThoiHanSoHuu = .Item("ThoiHanSoHuu").ToString
                    strMaNhaO = .Item("MaNhaO").ToString
                    NhaO.MaNhaO = strMaNhaO
                    NhaO.MaHoSoCapGCN = .Item("MaHoSoCapGCN").ToString
                    NhaO.NamXayDung = .Item("NamXayDung").ToString
                    NhaO.NamHoanThanhXayDung = .Item("NamHoanThanhXayDung").ToString
                    NhaO.ThoiHanSoHuu = .Item("ThoiHanSoHuu").ToString
                    NhaO.SoGiayPhepXayDung = .Item("SoGiayPhepXayDung").ToString
                    NhaO.SoNha = .Item("SoNha").ToString
                    'Ngày cấp phép xây dựng
                    If IsDate(.Item("NgayCapPhepXayDung").ToString) Then
                        NhaO.NgayCapPhepXayDung = .Item("NgayCapPhepXayDung").ToString
                    Else
                        NhaO.NgayCapPhepXayDung = Nothing
                    End If
                    NhaO.SoTang = .Item("SoTang").ToString
                    NhaO.ThongTinXuLyViPham = .Item("ThongTinXuLyViPham").ToString
                    NhaO.NguonGocNha = .Item("NguonGocNha").ToString
                    NhaO.GiaTriConLai = .Item("GiaTriConLai").ToString
                    NhaO.GhiChu = .Item("GhiChu").ToString

                    NhaO.SoHuuRieng = .Item("SoHuuRieng").ToString
                    NhaO.SoHuuChung = .Item("SoHuuChung").ToString
                    NhaO.isGPXD = .Item("isGPXD").ToString
                End With
                'Hiển thị bản ghi được lựa chon lên Form
                With Me
                    .txtCoQuanCapGPXD.Text = NhaO.CoQuanCapGPXD
                    .txtDiaChiNha.Text = NhaO.DiaChiNha
                    If IsNumeric(NhaO.DienTichSanPhu) Then
                        .numDienTichSanPhu.Text = NhaO.DienTichSanPhu.ToString
                    Else
                        .numDienTichSanPhu.Text = ""
                    End If
                    If IsNumeric(NhaO.DienTichSanXayDung) Then
                        .numDienTichSanXayDung.Text = NhaO.DienTichSanXayDung.ToString
                    Else
                        .numDienTichSanXayDung.Text = ""
                    End If
                    If IsNumeric(NhaO.DienTichXayDung) Then
                        .numDienTichXayDung.Text = NhaO.DienTichXayDung.ToString
                    Else
                        .numDienTichXayDung.Text = ""
                    End If
                    txtSoNha.Text = NhaO.SoNha
                    txtKetCauNha.Text = NhaO.KetCauNha
                    cmbCapHangNha.Text = NhaO.CapHangNha
                    cmbLoaiNha.Text = NhaO.LoaiNha
                    txtThoiHanSoHuu.Text = NhaO.ThoiHanSoHuu
                    If IsNumeric(NhaO.NamXayDung) Then
                        numNamXayDung.Text = NhaO.NamXayDung
                    Else
                        numNamXayDung.Text = ""
                    End If
                    If IsNumeric(NhaO.NamHoanThanhXayDung) Then
                        numNamHoanThanhXayDung.Text = NhaO.NamHoanThanhXayDung
                    Else
                        numNamHoanThanhXayDung.Text = ""
                    End If
                    txtThoiHanSoHuu.Text = NhaO.ThoiHanSoHuu
                    txtSoGPXD.Text = NhaO.SoGiayPhepXayDung
                    'Ngày cấp phép xây dựng
                    If IsDate(NhaO.NgayCapPhepXayDung) Then
                        dtpNgayCapPhepXayDung.Value = NhaO.NgayCapPhepXayDung
                        dtpNgayCapPhepXayDung.Checked = True
                    Else
                        dtpNgayCapPhepXayDung.Value = Date.Now
                        dtpNgayCapPhepXayDung.Checked = False
                    End If
                    txtSoTang.Text = NhaO.SoTang
                    txtThongTinViPham.Text = NhaO.ThongTinXuLyViPham
                    txtNguonGocNha.Text = NhaO.NguonGocNha
                    txtGiaTriConLai.Text = NhaO.GiaTriConLai
                    txtGhiChu.Text = NhaO.GhiChu
                    NumSoHuuRieng.Text = NhaO.SoHuuRieng.ToString
                    NumSoHuuChung.Text = NhaO.SoHuuChung.ToString
                    If NhaO.isGPXD = "True" Then
                        .chkCapPhepXD.Checked = True
                    Else
                        .chkCapPhepXD.Checked = False
                    End If
                    strThongTinChuCu = "So nhà " & txtSoNha.Text & "_ diện tích " & numDienTichXayDung.Text & "m2_" & txtKetCauNha.Text & "_" & txtSoTang.Text
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Nhà ở (Căn hộ)" _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .grdvwNhaO.BackgroundColor = Color.White
            'Diện tích 
            With .numDienTichSanPhu
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            'Diện tích 
            With .numDienTichSanXayDung
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            'Diện tích 
            With .numDienTichXayDung
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            'Nam h
            With .numNamHoanThanhXayDung
                .Enabled = blnCapNhat
            End With
            With .numNamXayDung
                .Enabled = blnCapNhat
            End With
            With .txtSoTang
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            .dtpNgayCapPhepXayDung.Enabled = blnCapNhat
            .txtCoQuanCapGPXD.ReadOnly = Not blnCapNhat
            .txtDiaChiNha.ReadOnly = Not blnCapNhat
            .txtKetCauNha.ReadOnly = Not blnCapNhat
            .txtSoNha.ReadOnly = Not blnCapNhat
            .txtSoGPXD.ReadOnly = Not blnCapNhat
            .txtThoiHanSoHuu.ReadOnly = Not blnCapNhat
            .txtThongTinViPham.ReadOnly = Not blnCapNhat

            txtNguonGocNha.ReadOnly = Not blnCapNhat
            txtGiaTriConLai.ReadOnly = Not blnCapNhat
            txtGhiChu.ReadOnly = Not blnCapNhat

            .cmbCapHangNha.Enabled = blnCapNhat
            .cmbLoaiNha.Enabled = blnCapNhat

            .NumSoHuuRieng.Enabled = blnCapNhat
            .NumSoHuuChung.Enabled = blnCapNhat
            .chkCapPhepXD.Enabled = blnCapNhat

            If blnCapNhat Then
                .txtSoNha.BackColor = Color.White
                .numDienTichSanPhu.BackColor = Color.White
                .numDienTichSanXayDung.BackColor = Color.White
                .numDienTichXayDung.BackColor = Color.White
                .NumSoHuuRieng.BackColor = Color.White
                .NumSoHuuChung.BackColor = Color.White

                .numNamHoanThanhXayDung.BackColor = Color.White
                .numNamXayDung.BackColor = Color.White
                .txtSoTang.BackColor = Color.White

                .txtCoQuanCapGPXD.BackColor = Color.White
                txtDiaChiNha.BackColor = Color.White
                .txtKetCauNha.BackColor = Color.White
                .txtSoGPXD.BackColor = Color.White
                .txtThoiHanSoHuu.BackColor = Color.White
                .txtThongTinViPham.BackColor = Color.White

                .cmbCapHangNha.BackColor = Color.White
                .cmbLoaiNha.BackColor = Color.White
                .txtNguonGocNha.BackColor = Color.White
                .txtGiaTriConLai.BackColor = Color.White
                .txtGhiChu.BackColor = Color.White
            Else
                .txtSoNha.BackColor = Color.LightYellow
                .numDienTichSanPhu.BackColor = Color.LightYellow
                .numDienTichSanXayDung.BackColor = Color.LightYellow
                .numDienTichXayDung.BackColor = Color.LightYellow
                .NumSoHuuRieng.BackColor = Color.LightYellow
                .NumSoHuuChung.BackColor = Color.LightYellow

                .numNamHoanThanhXayDung.BackColor = Color.LightYellow
                .numNamXayDung.BackColor = Color.LightYellow
                .txtSoTang.BackColor = Color.LightYellow

                .txtCoQuanCapGPXD.BackColor = Color.LightYellow
                txtDiaChiNha.BackColor = Color.LightYellow
                .txtKetCauNha.BackColor = Color.LightYellow
                .txtSoGPXD.BackColor = Color.LightYellow
                .txtThoiHanSoHuu.BackColor = Color.LightYellow
                .txtThongTinViPham.BackColor = Color.LightYellow

                .cmbCapHangNha.BackColor = Color.LightYellow
                .cmbLoaiNha.BackColor = Color.LightYellow
                .txtNguonGocNha.BackColor = Color.LightYellow
                .txtGiaTriConLai.BackColor = Color.LightYellow
                .txtGhiChu.BackColor = Color.LightYellow
            End If
        End With
    End Sub
    Private Sub btnCapNhat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        'Kiểm tra dữ liệu nhập vào
        Try
            With Me
                'Cập nhật thông tin Mục đích sử dụng
                If numNamHoanThanhXayDung.Text <> "" Then
                    If Not IsNumeric(numNamHoanThanhXayDung.Text) Then
                        MsgBox(" Kiểm tra dữ liệu nhập !!!" & vbNewLine & " Nhà ở ", MsgBoxStyle.Information, "DMCLand")
                        numNamHoanThanhXayDung.Focus()
                        Exit Sub
                    End If
                End If
                If numNamXayDung.Text <> "" Then
                    If Not IsNumeric(numNamXayDung.Text) Then
                        MsgBox(" Kiểm tra dữ liệu nhập !!!" & vbNewLine & " Nhà ở ", MsgBoxStyle.Information, "DMCLand")
                        numNamXayDung.Focus()
                        Exit Sub
                    End If
                End If
                .UpdateData()

            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Nhà ở " & vbNewLine _
                & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        Me.ShowData()
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
        'Khởi tạo giá trị cho biến dùng chung
        strMaNhaO = ""
        strError = ""
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaNhaO <> "" Then
            shortAction = 2
            'Trang thai chuc nang
            TrangThaiChucNang(True)
            'Trang thai cap nhat
            TrangThaiCapNhat(True)
        Else
            MsgBox(" Bạn chưa chọn Nhà ở (Căn hộ) cần sửa thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub
    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        Try
            With Me
                With .dtpNgayCapPhepXayDung
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                End With
                If (blnClearGrid) Then
                    .HideAllColumns(grdvwNhaO)
                End If
                .txtCoQuanCapGPXD.Text = ""
                .txtDiaChiNha.Text = "Như địa chỉ thửa đất"
                .numDienTichSanPhu.Text = ""
                .numDienTichXayDung.Text = ""
                .txtKetCauNha.Text = "-/-"
                .cmbCapHangNha.Text = "-/-"
                .cmbLoaiNha.Text = ""
                .txtSoGPXD.Text = ""
                .txtSoTang.Text = "-/-"
                .txtSoNha.Text = "-/-"
                .txtThongTinViPham.Text = "Không"
                .txtThoiHanSoHuu.Text = "-/-"
                'Năm cấp phép xây dựng
                .dtpNgayCapPhepXayDung.Value = Date.Now
                .dtpNgayCapPhepXayDung.Checked = False
                'Năm xây dựng
                .numNamXayDung.Text = "" 'Date.Now.Year
                .numNamHoanThanhXayDung.Text = "" 'Date.Now.Year
                .numDienTichSanXayDung.Text = ""
                .txtNguonGocNha.Text = ""
                .txtGiaTriConLai.Text = ""
                .txtGhiChu.Text = ""
                .chkCapPhepXD.Checked = True
                .NumSoHuuRieng.Text = ""
                .NumSoHuuChung.Text = ""
                LoadNam()
            End With
        Catch ex As Exception
            MessageBox.Show("Nhà ở (Căn hộ) " & vbNewLine & "Trạng thái ban đầu" & vbNewLine & "Lỗi: " & ex.Message(), "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Public Sub LoadNam()
        numNamHoanThanhXayDung.Items.Clear()
        numNamXayDung.Items.Clear()
        For i As Int16 = Now.Year() To Now.Year() - 20 Step -1
            numNamHoanThanhXayDung.Items.Add(i)
            numNamXayDung.Items.Add(i)
        Next
    End Sub
    Private Sub ctrlNhaO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If strMaHoSoCapGCN = "" Then
                Me.TrangThaiBanDau()
                Me.TrangThaiCapNhat()
                'Trạng thái chức năng
                Me.TrangThaiChucNang()
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Nhà ở (Căn hộ) " & vbNewLine _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try

    End Sub

    Private Sub grdvwNhaO_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles grdvwNhaO.CellFormatting
        'If Me.grdvwNhaO.Columns(e.ColumnIndex).Name _
        '    = "NgayCapPhepXayDung" Then
        '    If e.Value IsNot Nothing Then
        '        e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
        '    End If
        'End If
        'If Me.grdvwNhaO.Columns(e.ColumnIndex).Name _
        '    = "NgayBatDau" Then
        '    If e.Value IsNot Nothing Then
        '        e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
        '    End If
        'End If
        'If Me.grdvwNhaO.Columns(e.ColumnIndex).Name _
        '    = "NgayKetThuc" Then
        '    If e.Value IsNot Nothing Then
        '        e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
        '    End If
        'End If
    End Sub
    Private Sub HideAllColumns(ByRef grdvw As DataGridView)
        'Ẩn tất cả các cột trên Grid
        With grdvw
            For i As Integer = 0 To (.Columns.Count - 1)
                .Columns(i).Visible = False
            Next
            .RowHeadersVisible = False
        End With
    End Sub
    Public Sub FormatGridContruction()
        Try
            With Me.grdvwNhaO
                Me.HideAllColumns(grdvwNhaO)
                'CHỈ HIỆN THỊ NHỮNG CỘT CẦN THIẾT
                'Loại nhà
                With .Columns("LoaiNha")
                    .Visible = True
                    .HeaderText = "Loại"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Cấp hạng nhà
                With .Columns("CapHangNha")
                    .Visible = True
                    .HeaderText = "Cấp hạng"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Kết cấu nhà
                With .Columns("KetCauNha")
                    .Visible = True
                    .HeaderText = "Kết cấu"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'So tang
                With .Columns("SoTang")
                    .Visible = True
                    .HeaderText = "Số tầng"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nam xay dung
                With .Columns("NamXayDung")
                    .Visible = True
                    .HeaderText = "Năm xây dựng"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nam hoan thanh xay dung
                With .Columns("NamHoanThanhXayDung")
                    .Visible = True
                    .HeaderText = "Năm hoàn thành"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Thoi han so huu
                With .Columns("ThoiHanSoHuu")
                    .Visible = True
                    .HeaderText = "Thời hạn"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Dia chi nha
                With .Columns("DiaChiNha")
                    .Visible = True
                    .HeaderText = "Địa chỉ"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Dien tich xay dung
                With .Columns("DienTichXayDung")
                    .Visible = True
                    .HeaderText = "Diện tích xây dựng"
                    .Width = 130
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Dien tich san phu
                With .Columns("DienTichSanPhu")
                    .Visible = True
                    .HeaderText = "Diện tích sàn phụ"
                    .Width = 130
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Dien tich san xay dung
                With .Columns("DienTichSanXayDung")
                    .Visible = True
                    .HeaderText = "Diện tích sàn xây dựng"
                    .Width = 150
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'So giay phep xay dung
                With .Columns("SoGiayPhepXayDung")
                    .Visible = True
                    .HeaderText = "Số giấy phép xây dựng"
                    .Width = 150
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ngày cấp phép xây dựng
                With .Columns("NgayCapPhepXayDung")
                    .Visible = True
                    .HeaderText = "Năm cấp phép xây dựng"
                    .Width = 150
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Co quan cap phep xay dung
                With .Columns("CoQuanCapGPXD")
                    .Visible = True
                    .HeaderText = "Cơ quan cấp GPXD"
                    .Width = 130
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Thong tin xu ly vi pham
                With .Columns("ThongTinXuLyViPham")
                    .Visible = True
                    .HeaderText = "Thông tin vi pham"
                    .Width = 130
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("NguonGocNha")
                    .Visible = True
                    .HeaderText = "Nguồn gốc nhà"
                    .Width = 130
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("GiaTriConLai")
                    .Visible = True
                    .HeaderText = "Giá trị còn lại"
                    .Width = 130
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("GhiChu")
                    .Visible = True
                    .HeaderText = "Ghi chú"
                    .Width = 130
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("SoNha")
                    .Visible = True
                    .HeaderText = "Số nhà"
                    .Width = 130
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("SoHuuRieng")
                    .Visible = True
                    .HeaderText = "Sở hữu riêng"
                    .Width = 130
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("SoHuuChung")
                    .Visible = True
                    .HeaderText = "Sở hữu chung"
                    .Width = 130
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .GridColor = Color.WhiteSmoke
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nhà ở (Căn hộ) " & vbNewLine & "Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        'Bo lua chon tren Grid
        Me.grdvwNhaO.ClearSelection()
        strMaNhaO = ""
        shortAction = 1
        'Thiết lập giá trị mặc định
        Me.txtDiaChiNha.Text = "Như địa chỉ thửa đất"
        Me.txtThoiHanSoHuu.Text = "-/-"
        Me.txtThongTinViPham.Text = "Không"
        With Me
            'Thiet lap trang thai ban dau
            .TrangThaiBanDau()
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            'Trang thai chuc nang 
            .TrangThaiChucNang(True)
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            .ShowData()
            'Khởi tạo giá trị cho biến dùng chung
            strMaNhaO = ""
        End With
        shortAction = 0
    End Sub

 

    Private Sub txtSoNha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoNha.KeyDown
        If (e.KeyValue = 13) Then
            txtDiaChiNha.Focus()
        End If
    End Sub

    Private Sub txtDiaChiNha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiaChiNha.KeyDown
        If (e.KeyValue = 13) Then
            numDienTichXayDung.Focus()
        End If
    End Sub

    Private Sub numDienTichXayDung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDienTichXayDung.KeyDown
        If (e.KeyValue = 13) Then
            numDienTichSanXayDung.Focus()
        End If
    End Sub

    Private Sub numDienTichSanXayDung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDienTichSanXayDung.KeyDown
        If (e.KeyValue = 13) Then
            txtKetCauNha.Focus()
        End If
    End Sub

    Private Sub txtKetCauNha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKetCauNha.KeyDown
        If (e.KeyValue = 13) Then
            cmbCapHangNha.Focus()
        End If
    End Sub

    Private Sub cmbCapHangNha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCapHangNha.KeyDown
        If (e.KeyValue = 13) Then
            txtSoTang.Focus()
        End If
    End Sub

    Private Sub txtSoTang_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoTang.KeyDown
        If (e.KeyValue = 13) Then
            numNamHoanThanhXayDung.Focus()
        End If
    End Sub

    Private Sub numNamHoanThanhXayDung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numNamHoanThanhXayDung.KeyDown
        If (e.KeyValue = 13) Then
            txtThoiHanSoHuu.Focus()
        End If
    End Sub

    Private Sub txtThoiHanSoHuu_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtThoiHanSoHuu.KeyDown
        If (e.KeyValue = 13) Then
            numDienTichSanPhu.Focus()
        End If
    End Sub

    Private Sub numDienTichSanPhu_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDienTichSanPhu.KeyDown
        If (e.KeyValue = 13) Then
            NumSoHuuRieng.Focus()
        End If
    End Sub

    Private Sub NumSoHuuRieng_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumSoHuuRieng.KeyDown
        If (e.KeyValue = 13) Then
            NumSoHuuChung.Focus()
        End If
    End Sub

    Private Sub NumSoHuuChung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumSoHuuChung.KeyDown
        If (e.KeyValue = 13) Then
            numNamXayDung.Focus()
        End If
    End Sub

    Private Sub numNamXayDung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numNamXayDung.KeyDown
        If (e.KeyValue = 13) Then
            cmbLoaiNha.Focus()
        End If
    End Sub

    Private Sub cmbLoaiNha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbLoaiNha.KeyDown
        If (e.KeyValue = 13) Then
            txtSoGPXD.Focus()
        End If
    End Sub

    Private Sub txtSoGPXD_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoGPXD.KeyDown
        If (e.KeyValue = 13) Then
            txtCoQuanCapGPXD.Focus()
        End If
    End Sub

    Private Sub txtCoQuanCapGPXD_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoQuanCapGPXD.KeyDown
        If (e.KeyValue = 13) Then
            txtThongTinViPham.Focus()
        End If
    End Sub

    Private Sub txtThongTinViPham_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtThongTinViPham.KeyDown
        If (e.KeyValue = 13) Then
            txtNguonGocNha.Focus()
        End If
    End Sub

    Private Sub txtNguonGocNha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNguonGocNha.KeyDown
        If (e.KeyValue = 13) Then
            txtGiaTriConLai.Focus()
        End If
    End Sub

    Private Sub txtGiaTriConLai_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGiaTriConLai.KeyDown
        If (e.KeyValue = 13) Then
            txtGhiChu.Focus()
        End If
    End Sub

    Private Sub txtGhiChu_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGhiChu.KeyDown
        If (e.KeyValue = 13) Then
            btnCapNhat.Focus()
        End If
    End Sub

    Private Sub cmdKetCauNha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKetCauNha.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtKetCauNha.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub

    Private Sub cmdThoiHanSoHuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoiHanSoHuu.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtThoiHanSoHuu.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub

    Private Sub cmdCoQuanCapPhep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCoQuanCapPhep.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtCoQuanCapGPXD.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub
End Class
