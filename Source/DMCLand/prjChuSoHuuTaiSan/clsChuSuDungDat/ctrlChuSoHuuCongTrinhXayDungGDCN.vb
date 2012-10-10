Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlChuSoHuuCongTrinhXayDungGDCN
    'Khai báo biến xác định hành động thao tác cơ sở dữ liệu
    Private shortAction As Short = 0
    Private strMaTaiSan As String = ""
    Private dtChuGDCN As New DataTable
    'Khai báo biến nhận tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã sở hữu Tài sản
    Private strMaChu As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Tên đơn vị hành chính
    Public WriteOnly Property TenDonViHanhChinh() As String
        Set(ByVal value As String)
            strTenDonViHanhChinh = value
        End Set
    End Property
    'Mã Tài sản
    Public WriteOnly Property MaTaiSan() As String
        Set(ByVal value As String)
            strMaTaiSan = value
        End Set
    End Property
    'Mã Chủ sở hữu
    Public WriteOnly Property MaChu() As String
        Set(ByVal value As String)
            strMaChu = value
        End Set
    End Property

    Private Sub HideAllColumns(ByRef grdvw As DataGridView)
        'Ẩn tất cả các cột trên Grid
        With grdvw
            For i As Integer = 0 To (.Columns.Count - 1)
                .Columns(i).Visible = False
            Next
            .RowHeadersVisible = False
        End With
    End Sub

    Private Sub FormatGridContruction()
        Try
            With Me.grdvwGDCN
                Me.HideAllColumns(grdvwGDCN)
                'Ma doi tuong
                With .Columns("KyHieu")
                    .Visible = True
                    .HeaderText = "Mã đối tượng"
                    .Width = 120
                End With
                'Ho va Ten
                With .Columns("HoTen")
                    .Visible = True
                    .HeaderText = "Họ tên"
                    .Width = 100
                End With
                'Nam sinh
                With .Columns("NamSinh")
                    .Visible = True
                    .HeaderText = "Năm sinh"
                    .Width = 100
                End With
                'Gioi tinh
                With .Columns("GioiTinh")
                    .Visible = True
                    .HeaderText = "Giới tính"
                    .Width = 100
                End With
                'Quoc tich
                With .Columns("QuocTich")
                    .Visible = True
                    .HeaderText = "Quốc tịch"
                    .Width = 100
                End With
                'So dinh danh
                With .Columns("SoDinhDanh")
                    .Visible = True
                    .HeaderText = "Số CMT"
                    .Width = 100
                End With
                'Ngay cap dinh danh
                With .Columns("NgayCap")
                    .Visible = True
                    .HeaderText = "Ngày cấp CMT"
                    .Width = 130
                End With
                'Noi cap dinh danh
                With .Columns("NoiCap")
                    .Visible = True
                    .HeaderText = "Nơi cấp CMT"
                    .Width = 130
                End With
                'So Ho Khau
                With .Columns("SoHoKhau")
                    .Visible = True
                    .HeaderText = "Số hộ khẩu"
                    .Width = 130
                End With
                'Ngay cap Ho khau
                With .Columns("NgayCapHoKhau")
                    .Visible = True
                    .HeaderText = "Ngày cấp Hộ khẩu"
                    .Width = 130
                End With
                'Noi cap Ho Khau
                With .Columns("NoiCapHoKhau")
                    .Visible = True
                    .HeaderText = "Nơi cấp hộ khẩu"
                    .Width = 130
                End With
                'Dai chi thuong chu
                With .Columns("DiaChi")
                    .Visible = True
                    .HeaderText = "Địa chỉ thường chú"
                    .Width = 130
                End With
                'Quan he
                With .Columns("QuanHe")
                    .Visible = True
                    .HeaderText = "Quan hệ"
                    .Width = 100
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
            MsgBox(" CHỦ SỞ HỮU - GIA ĐÌNH, CÁ NHÂN " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub ctrlChuSuDungGDCN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                '.BackColor = Color.LightBlue
                With .DTPNgayCapCMT
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                End With
                With .DTPNgayCapHK
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                End With
                'Trạng thái cập nhật
                .TrangThaiCapNhat()
                'Trạng thái chức năng
                .TrangThaiChucNang(True, True)
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Đối tượng hộ gia đình, cá nhân " _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        strMaChu = ""
        'Kiểm tra xem người dùng đã chọn tài sản chưa
        If strMaTaiSan = "" Then
            System.Windows.Forms.MessageBox.Show("Bạn phải LỰA CHỌN TÀI SẢN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        With Me
            'Thiết lập trạng thái ban đầu
            .TrangThaiBanDau()
            'Xác định hành động thêm mới Chủ sử dụng
            shortAction = 1
            'Thiết lập trạng thái chức năng
            .TrangThaiChucNang(True)
            'Hiển thị Form tra cứu
            TraCuu()
        End With
    End Sub
    ''' <summary>
    ''' Hiển thị thông tin Chủ sở hữu Tài sản lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        'Khai bao và khởi tạo đối tượng Chủ sở hữu
        Dim ChuSoHuu As New DMC.Land.ChuSoHuuTaiSan.clsChuSoHuu
        dtChuGDCN.Clear()
        Try

            'Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu
            If (strConnection = "") Then
                MessageBox.Show("Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Khai báo nhận chuỗi kết nối Database
            ChuSoHuu.Connection = strConnection
            ChuSoHuu.MaChuSoHuu = ""
            ChuSoHuu.MaTaiSan = strMaTaiSan

            With Me
                .grdvwGDCN.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng ChuSoHuu
                If ChuSoHuu.SelectChuSoHuuCongTrinhXayDungByGDCN(dtChuGDCN) = "" Then
                    'Trình bày dữ liệu lên grdvwHoGiaDinhCaNhan
                    'Hiển thị các bản ghi
                    .grdvwGDCN.DataSource = dtChuGDCN
                    'Định dạng lại các cột trong Grid
                    If dtChuGDCN.Rows.Count > 0 Then
                        .FormatGridContruction()
                    Else
                        .HideAllColumns(grdvwGDCN)
                    End If
                End If
            End With
            'Thiet dat trang thai ban dau
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Đối tượng hộ gia đình, cá nhân " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            'If blnCapNhat Then
            .grdvwGDCN.BackgroundColor = Color.White
            'Else
            '    .grdvwGDCN.BackgroundColor = Color.LightYellow
            'End If
            .txtDiaChiThuongTru.ReadOnly = Not blnCapNhat
            .txtHoTen.ReadOnly = Not blnCapNhat
            .txtMaDoiTuong.ReadOnly = Not blnCapNhat
            .numNamSinh.ReadOnly = Not blnCapNhat
            .txtNoiCapCMT.ReadOnly = Not blnCapNhat
            .txtNoiCapHK.ReadOnly = Not blnCapNhat
            .txtSoCMT.ReadOnly = Not blnCapNhat
            .txtSoHoKhau.ReadOnly = Not blnCapNhat
            .cmbGioiTinh.Enabled = blnCapNhat
            .cmbQuanHe.Enabled = blnCapNhat
            .cmbQuocTich.Enabled = blnCapNhat
            .DTPNgayCapCMT.Enabled = blnCapNhat
            .DTPNgayCapHK.Enabled = blnCapNhat
            If blnCapNhat Then
                .txtDiaChiThuongTru.BackColor = Color.White
                .txtHoTen.BackColor = Color.White
                .txtMaDoiTuong.BackColor = Color.White
                .numNamSinh.BackColor = Color.White
                .txtNoiCapCMT.BackColor = Color.White
                .txtNoiCapHK.BackColor = Color.White
                .txtSoCMT.BackColor = Color.White
                .txtSoHoKhau.BackColor = Color.White
            Else
                .txtDiaChiThuongTru.BackColor = Color.LightYellow
                .txtHoTen.BackColor = Color.LightYellow
                .txtMaDoiTuong.BackColor = Color.LightYellow
                .numNamSinh.BackColor = Color.LightYellow
                .txtNoiCapCMT.BackColor = Color.LightYellow
                .txtNoiCapHK.BackColor = Color.LightYellow
                .txtSoCMT.BackColor = Color.LightYellow
                .txtSoHoKhau.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau() 'Optional ByVal blnClearGrid As Boolean = False)
        With Me
            'If blnClearGrid Then
            '    .grdvwGDCN.RowCount = 0
            'End If
            .HideAllColumns(grdvwGDCN)
            'Thiet lap tren Form nhap lieu
            .txtDiaChiThuongTru.Text = ""
            .txtHoTen.Text = ""
            .txtMaDoiTuong.Text = "GDC"
            .numNamSinh.Text = ""
            .txtNoiCapCMT.Text = ""
            .txtNoiCapHK.Text = ""
            .txtSoCMT.Text = ""
            .txtSoHoKhau.Text = ""
            .DTPNgayCapCMT.Value = Date.Now
            .DTPNgayCapCMT.Checked = False
            .DTPNgayCapHK.Value = Date.Now
            .DTPNgayCapHK.Checked = False
            .cmbGioiTinh.Text = ""
            .cmbQuanHe.Text = ""
            .cmbQuocTich.Text = "Việt Nam"
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            '.btnSua.Enabled = Not blnStartEdited
            .btnXoa.Enabled = Not blnStartEdited
            .btnCapNhat.Enabled = Not blnStartEdited
            .btnGhi.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            ' .btnTraCuu.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnGhi.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
                ' .btnTraCuu.Enabled = Not blnStartEdited
            End If
        End With
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        'Kiểm tra dữ liệu nhập vào
        If txtMaDoiTuong.Text.Trim = "" Then
            MsgBox("Bạn phải nhập Mã đối tượng sử dụng đất!", MsgBoxStyle.Information, "DMCLand")
            txtMaDoiTuong.Focus()
            Exit Sub
        End If
        With Me
            'Cập nhật thông tin Chủ sở hữu (Hộ gia đình - cá nhân)
            .UpdateData()
            'Hiển thị thông tin lên Form
            .ShowData()
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        'Khởi tạo giá trị cho biến dùng chung
        strMaChu = ""
        strError = ""
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            If strMaTaiSan <> "" Then
                .ShowData()
            End If
            'Xoa du lieu tren Form
            .TrangThaiBanDau()
            'Khởi tạo giá trị ban đầu cho biến dùng chung
            strMaChu = ""
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
    End Sub

    Private Sub grdvwHoGiaDinhCaNhan_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles grdvwGDCN.CellFormatting
        'If Me.grdvwGDCN.Columns(e.ColumnIndex).Name _
        '    = "NgayCapDinhDanh" Then
        '    If e.Value IsNot Nothing Then
        '        e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
        '    End If
        'End If
        'If Me.grdvwGDCN.Columns(e.ColumnIndex).Name _
        '    = "NgayCapHoKhau" Then
        '    If e.Value IsNot Nothing Then
        '        e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
        '    End If
        'End If
    End Sub

    Private Sub grdvwGDCN_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwGDCN.CellMouseClick
        'Chỉ thực thi khi người dùng chọn chuột TRÁI
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khai báo và khởi tạo đối tượng Chủ sở hữu
        Dim ChuSoHuu As New DMC.Land.Chu.clsChuGDCN
        If e.RowIndex >= 0 Then
            Try
                'Hiển thị thông tin Chủ sở hữu
                With dtChuGDCN.Rows(e.RowIndex)
                    ChuSoHuu.DiaChi = .Item("DiaChi").ToString
                    ChuSoHuu.GioiTinh = .Item("GioiTinh").ToString
                    ChuSoHuu.HoTen = .Item("HoTen").ToString
                    ChuSoHuu.MaChu = .Item("MaChu").ToString
                    strMaChu = ChuSoHuu.MaChu
                    ChuSoHuu.NamSinh = .Item("NamSinh").ToString
                    If IsDate(.Item("NgayCap").ToString) Then
                        ChuSoHuu.NgayCap = .Item("NgayCap").ToString
                    Else
                        ChuSoHuu.NgayCap = Nothing
                    End If
                    If (IsDate(.Item("NgayCapHoKhau").ToString)) Then
                        ChuSoHuu.NgayCapHoKhau = .Item("NgayCapHoKhau").ToString
                    Else
                        ChuSoHuu.NgayCapHoKhau = Nothing
                    End If
                    ChuSoHuu.NoiCap = .Item("NoiCap").ToString
                    ChuSoHuu.NoiCapHoKhau = .Item("NoiCapHoKhau").ToString
                    ChuSoHuu.QuanHe = .Item("QuanHe").ToString
                    ChuSoHuu.QuocTich = .Item("QuocTich").ToString
                    ChuSoHuu.SoDinhDanh = .Item("SoDinhDanh").ToString
                    ChuSoHuu.SoHoKhau = .Item("SoHoKhau").ToString
                End With

                'Hien thi ban ghi tuong ung lenh Form
                With Me
                    .txtDiaChiThuongTru.Text = ChuSoHuu.DiaChi
                    .txtHoTen.Text = ChuSoHuu.HoTen
                    .txtMaDoiTuong.Text = dtChuGDCN.Rows(e.RowIndex).Item("DoiTuongSDD").ToString
                    .numNamSinh.Text = ChuSoHuu.NamSinh
                    .txtNoiCapCMT.Text = ChuSoHuu.NoiCap
                    .txtNoiCapHK.Text = ChuSoHuu.NoiCapHoKhau
                    .txtSoCMT.Text = ChuSoHuu.SoDinhDanh
                    .txtSoHoKhau.Text = ChuSoHuu.SoHoKhau
                    If IsDate(ChuSoHuu.NgayCap) Then
                        .DTPNgayCapCMT.Value = ChuSoHuu.NgayCap
                        .DTPNgayCapCMT.Checked = True
                    Else
                        .DTPNgayCapCMT.Value = Date.Now
                        .DTPNgayCapCMT.Checked = False
                    End If
                    If IsDate(ChuSoHuu.NgayCapHoKhau) Then
                        .DTPNgayCapHK.Value = ChuSoHuu.NgayCapHoKhau
                        .DTPNgayCapHK.Checked = True
                    Else
                        .DTPNgayCapHK.Value = Date.Now
                        .DTPNgayCapHK.Checked = False
                    End If

                    If ChuSoHuu.GioiTinh = "True" Then
                        .cmbGioiTinh.Text = "Nam"
                    ElseIf ChuSoHuu.GioiTinh = "False" Then
                        .cmbGioiTinh.Text = "Nữ"
                    Else
                        .cmbGioiTinh.Text = ""
                    End If
                    .cmbQuanHe.Text = ChuSoHuu.QuanHe
                    .cmbQuocTich.Text = ChuSoHuu.QuocTich
                End With

            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Đối tượng HỘ GIA ĐÌNH, CÁ NHÂN " _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If

    End Sub

    Public Sub TraCuu()
        Dim TraCuuGDCN As New frmChuGDCN
        With TraCuuGDCN.CtrlChuGDCN
            .Connection = strConnection
            .MaHoSoCapGCN = strMaTaiSan
            TraCuuGDCN.StartPosition = FormStartPosition.CenterScreen
            TraCuuGDCN.ShowDialog()
            Try
                strMaChu = .MaChu
                'Chắc chắn rằng có một bản ghi được lựa chọn 
                If (.dtChuSelect.Rows.Count <> 1) Then
                    Exit Sub
                End If
                With .dtChuSelect.Rows(0)
                    txtMaDoiTuong.Text = .Item("DoiTuongSDD").ToString()
                    txtHoTen.Text = .Item("HoTen").ToString()
                    If IsNumeric(.Item("NamSinh").ToString()) Then
                        numNamSinh.Value = .Item("NamSinh").ToString()
                    End If
                    If .Item("GioiTinh").ToString() = "False" Then
                        cmbGioiTinh.Text = "Nữ"
                    ElseIf (.Item("GioiTinh").ToString() = "True") Then
                        cmbGioiTinh.Text = "Nam"
                    Else
                        cmbGioiTinh.Text = ""
                    End If
                    txtSoCMT.Text = .Item("SoDinhDanh").ToString()
                    If IsDate(.Item("NgayCap").ToString) Then
                        DTPNgayCapCMT.Value = Convert.ToDateTime(.Item("NgayCap").ToString)
                        DTPNgayCapCMT.Checked = True
                    Else
                        DTPNgayCapCMT.Value = Date.Now
                        DTPNgayCapCMT.Checked = False
                    End If
                    txtNoiCapCMT.Text = .Item("NoiCap").ToString
                    If IsDate(.Item("NgayCapHoKhau").ToString) Then
                        DTPNgayCapHK.Value = Convert.ToDateTime(.Item("NgayCapHoKhau").ToString)
                        DTPNgayCapHK.Checked = True
                    Else
                        DTPNgayCapHK.Value = Date.Now
                        DTPNgayCapHK.Checked = False
                    End If

                    txtNoiCapHK.Text = .Item("NoiCapHoKhau").ToString
                End With
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show("Lỗi: " & ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With
    End Sub
    ''' <summary>
    ''' Xóa Chủ sở hữu Tài sản (bảng trung gian tblChuSoHuu)
    ''' Note: Không phải xóa Chủ sở hữu (tblChuSoHuu)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Kiểm tra dữ liệu đầu vào
        'Kiểm tra xem người dùng đã chọn Chủ sở hữu cần xóa chưa?
        If strMaChu = "" Then
            System.Windows.Forms.MessageBox.Show("KHÔNG có CHỦ SỞ HỮU nào được lựa chọn", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        With Me
            'Xác định hành động Xóa Chủ sở hữu
            Me.shortAction = 3
            'Xóa Chủ sở hữu (Hộ gia đình cá nhân)
            .UpdateData()
            'Hiển thị dữ liệu lên Form
            Me.ShowData()
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        'Khởi tạo giá trị biến dùng chung
        strMaChu = ""
        'Gắn giá trị mặc định cho biến kiểm tra lỗi
        strError = ""
    End Sub

    ''' <summary>
    ''' Thêm Chủ sở hữu tài sản
    ''' Note: Không phải cập nhật Chủ  
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateData()
        'Khai bao loi
        'Khai báo và khởi tạo đối tượng clsChuSoHuu
        Dim ChuSoHuu As New DMC.Land.ChuSoHuuTaiSan.clsChuSoHuu
        Try
            'Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu
            If (strConnection = "") Then
                MessageBox.Show("Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            'Chắc chắn rằng tồn tại Mã Tài sản
            If (strMaTaiSan = "") Then
                strError = "Không tìm thấy Mã Tài sản"
                MessageBox.Show("Lỗi: " & strError, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Chắc chắn rằng tồn tại Mã chủ sở hữu
            If (strMaChu = "") Then
                strError = "Không tìm thấy Mã Chủ sở hữu tài sản"
                MessageBox.Show("Lỗi: " & strError, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'Khai báo nhận chuỗi kết nối Database
            ChuSoHuu.Connection = strConnection
            'GÁN GIÁ TRỊ CHO THUỘC TÍNH CỦA ĐỐI TƯỢNG CHỦ SỞ HỮU TÀI SẢN
            'Mã Tài sản
            ChuSoHuu.MaTaiSan = strMaTaiSan
            'Mã Chủ sở hữu
            ChuSoHuu.MaChuSoHuu = strMaChu
            Dim str As String = ""
            Dim strUpdateResults As String = ""
            'Xác định kiểu cập nhật
            'Trường hợp thêm mới Chủ Tài sản
            If (Me.shortAction = 1) Then
                strUpdateResults = ChuSoHuu.InsertChuSoHuuCongTrinhXayDung(str)
                'Trường hợp Xóa Chủ Tài sản
            ElseIf (Me.shortAction = 3) Then
                strUpdateResults = ChuSoHuu.DeleteChuSoHuuCongTrinhXayDung(str)
            End If
            'Nếu cập nhật thành công
            If strUpdateResults = "" Then
                Me.TrangThaiBanDau()
            End If
            strError = ChuSoHuu.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Đối tượng hộ gia đình, cá nhân " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

End Class
