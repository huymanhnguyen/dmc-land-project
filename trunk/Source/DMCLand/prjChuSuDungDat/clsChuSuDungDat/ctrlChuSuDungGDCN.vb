Imports DMC.Components
Imports System.Windows.Forms
Imports System.Drawing
Public Class ctrlChuSuDungGDCN
    'Khai báo biến xác định hành động thao tác cơ sở dữ liệu
    Private shFlag As Short = 0
    Private strMaHoSoCapGCN As String = ""
    Private dtChuGDCN As New DataTable
    Private arrOptGioiTinh As New List(Of String)
    'Khai báo biến nhận tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã chủ sử dụng đất
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
    'Mã Hồ sơ cấp GCN
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Mã Chủ sử dụng đất
    Public WriteOnly Property MaChu() As String
        Set(ByVal value As String)
            strMaChu = value
        End Set
    End Property

    ''' <summary>
    ''' Ẩn tất cả các cột của Grid
    ''' </summary>
    ''' <param name="grdvw"></param>
    ''' <remarks></remarks>
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
            'Ẩn tất cả các cột
            Me.HideAllColumns(grdvwGDCN)
            'Chỉ hiển thị những Cột cần thiết
            With Me.grdvwGDCN
                'Ma doi tuong
                With .Columns("KyHieu")
                    .HeaderText = "Mã đối tượng"
                    .Width = 120
                    .Visible = True
                End With
                'Ho va Ten
                With .Columns("HoTen")
                    .HeaderText = "Họ tên"
                    .Width = 100
                    .Visible = True
                End With
                'Nam sinh
                With .Columns("NamSinh")
                    .HeaderText = "Năm sinh"
                    .Width = 100
                    .Visible = True
                End With
                'Gioi tinh
                With .Columns("GioiTinh")
                    .HeaderText = "Giới tính"
                    .Width = 100
                    .Visible = True
                End With
                'Quoc tich
                With .Columns("QuocTich")
                    .HeaderText = "Quốc tịch"
                    .Width = 100
                    .Visible = True
                End With
                'So dinh danh
                With .Columns("SoDinhDanh")
                    .HeaderText = "Số CMT"
                    .Width = 100
                    .Visible = True
                End With
                'Ngay cap dinh danh
                With .Columns("NgayCap")
                    .HeaderText = "Ngày cấp CMT"
                    .Width = 130
                    .Visible = True
                End With
                'Noi cap dinh danh
                With .Columns("NoiCap")
                    .HeaderText = "Nơi cấp CMT"
                    .Width = 130
                    .Visible = True
                End With
                'So Ho Khau
                With .Columns("SoHoKhau")
                    .HeaderText = "Số hộ khẩu"
                    .Width = 130
                    .Visible = True
                End With
                'Ngay cap Ho khau
                With .Columns("NgayCapHoKhau")
                    .HeaderText = "Ngày cấp Hộ khẩu"
                    .Width = 130
                    .Visible = True
                End With
                'Noi cap Ho Khau
                With .Columns("NoiCapHoKhau")
                    .HeaderText = "Nơi cấp hộ khẩu"
                    .Width = 130
                    .Visible = True
                End With
                'Dai chi thuong chu
                With .Columns("DiaChi")
                    .HeaderText = "Địa chỉ thường chú"
                    .Width = 130
                    .Visible = True
                End With
                'Quan he
                With .Columns("QuanHe")
                    .HeaderText = "Quan hệ"
                    .Width = 100
                    .Visible = True
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
            MsgBox(" Chủ sử dụng GDCN " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
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
                'Trang thai cap nhat
                .TrangThaiCapNhat()
                'Trang thai chuc nang
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
        With Me
            'Thiết lập trạng thái ban đầu
            .TrangThaiBanDau()
            'Xác định hành động thêm mới Chủ sử dụng
            shFlag = 1

            ''Thiết lập giá trị mặc định trạng thái ban đầu
            '.txtDiaChiThuongTru.Text = strTenDonViHanhChinh
            '.txtNoiCapCMT.Text = strTenDonViHanhChinh
            '.txtNoiCapHK.Text = strTenDonViHanhChinh
            'Trang thai cap nhat
            '.TrangThaiCapNhat(True)
            'Thiết lập trạng thái chức năng
            .TrangThaiChucNang(True)
            'Hiển thị Form tra cứu
            TraCuu()
        End With
    End Sub
    ''' <summary>
    ''' Hiển thị thông tin Chủ sử dụng đất trong lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        'Khai bao va khoi tao doi tuong
        Dim ChuSuDung As New DMC.Land.ChuSuDungDat.clsChuSuDung
        'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
        Try
            ChuSuDung.Connection = strConnection ' Khai báo nhận chuỗi kết nối Database
            ChuSuDung.MaChuSuDung = ""
            ChuSuDung.MaHoSoCapGCN = strMaHoSoCapGCN
            dtChuGDCN.Clear()
            With Me
                .grdvwGDCN.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng ChuSuDung
                If ChuSuDung.SelectChuSuDungByGDCN(dtChuGDCN) = "" Then
                    'Trình bày dữ liệu lên grdvwHoGiaDinhCaNhan
                    .grdvwGDCN.DataSource = dtChuGDCN
                    'Khi tồn tại bản ghi nhận được
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

    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            If blnClearGrid Then
                .HideAllColumns(grdvwGDCN)
            End If
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
            .DTPNgayCapHK.Value = Date.Now
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
            'Cập nhật thông tin Chủ sử dụng (Ho gia dinh - ca nhan)
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
            If strMaHoSoCapGCN <> "" Then
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
        'Khai báo và khởi tạo đối tượng Chủ sử dụng
        Dim ChuSuDung As New DMC.Land.Chu.clsChuGDCN
        If e.RowIndex >= 0 Then
            Try
                'Hien thi thong tin chu su dung
                With dtChuGDCN.Rows(e.RowIndex)
                    ChuSuDung.DiaChi = .Item("DiaChi").ToString
                    ChuSuDung.GioiTinh = .Item("GioiTinh").ToString
                    ChuSuDung.HoTen = .Item("HoTen").ToString
                    ChuSuDung.MaChu = .Item("MaChu").ToString
                    strMaChu = ChuSuDung.MaChu
                    ChuSuDung.NamSinh = .Item("NamSinh").ToString
                    ChuSuDung.NgayCap = .Item("NgayCap").ToString
                    ChuSuDung.NgayCapHoKhau = .Item("NgayCapHoKhau").ToString
                    ChuSuDung.NoiCap = .Item("NoiCap").ToString
                    ChuSuDung.NoiCapHoKhau = .Item("NoiCapHoKhau").ToString
                    ChuSuDung.QuanHe = .Item("QuanHe").ToString
                    ChuSuDung.QuocTich = .Item("QuocTich").ToString
                    ChuSuDung.SoDinhDanh = .Item("SoDinhDanh").ToString
                    ChuSuDung.SoHoKhau = .Item("SoHoKhau").ToString
                End With

                'Hien thi ban ghi tuong ung lenh Form
                With Me
                    .txtDiaChiThuongTru.Text = ChuSuDung.DiaChi
                    .txtHoTen.Text = ChuSuDung.HoTen
                    .txtMaDoiTuong.Text = dtChuGDCN.Rows(e.RowIndex).Item("DoiTuongSDD").ToString
                    .numNamSinh.Text = ChuSuDung.NamSinh
                    .txtNoiCapCMT.Text = ChuSuDung.NoiCap
                    .txtNoiCapHK.Text = ChuSuDung.NoiCapHoKhau
                    .txtSoCMT.Text = ChuSuDung.SoDinhDanh
                    .txtSoHoKhau.Text = ChuSuDung.SoHoKhau
                    If (ChuSuDung.NgayCap = Nothing) Then
                        .DTPNgayCapCMT.Checked = False
                        .DTPNgayCapCMT.Value = Date.Now
                    Else
                        .DTPNgayCapCMT.Checked = True
                        .DTPNgayCapCMT.Value = ChuSuDung.NgayCap
                    End If
                    If (ChuSuDung.NgayCapHoKhau = Nothing) Then
                        .DTPNgayCapHK.Checked = False
                        .DTPNgayCapHK.Value = Date.Now
                    Else
                        .DTPNgayCapHK.Checked = True
                        .DTPNgayCapHK.Value = ChuSuDung.NgayCapHoKhau
                    End If
                    If ChuSuDung.GioiTinh = "True" Then
                        .cmbGioiTinh.Text = "Nam"
                    ElseIf ChuSuDung.GioiTinh = "False" Then
                        .cmbGioiTinh.Text = "Nữ"
                    Else
                        .cmbGioiTinh.Text = ""
                    End If
                    .cmbQuanHe.Text = ChuSuDung.QuanHe
                    .cmbQuocTich.Text = ChuSuDung.QuocTich
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
            .MaHoSoCapGCN = strMaHoSoCapGCN
            'Hiển thị Form tra cứu giữa màn hình
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
    ''' Xóa Chủ sử dụng Hồ sơ cấp GCN (bảng trung gian tblChuSuDungHoSoCapGCN)
    ''' Note: Không phải xóa Chủ sử dụng đất (tblTuDienChuSuDung)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Kiểm tra dữ liệu đầu vào
        With Me
            'Xác định hành động Xóa Chủ sử dụng
            Me.shFlag = 3
            'Xóa Chủ sử dụng Hồ sơ cấp GCN (Hộ gia đình cá nhân)
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
    ''' Thêm Chủ sử dụng Hồ sơ cấp GCN
    ''' Note: Không phải cập nhật Chủ sử dụng đất)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateData()
        'Khai bao loi
        'Khai bao va khoi tao doi tuong clsChuSuDungHoSoCapGCN
        Dim ChuSuDung As New DMC.Land.ChuSuDungDat.clsChuSuDung
        Try
            'Khai báo nhận chuỗi kết nối Database
            ChuSuDung.Connection = strConnection
            'Chắc chắn rằng tồn tại Mã Hồ sơ cấp GCN
            If (strMaHoSoCapGCN = "") Then
                strError = "Không tìm thấy Mã Hồ sơ cấp GCN"
                Exit Sub
            End If
            'Chắc chắn rằng tồn tại Mã chủ sử dụng đất
            If (strMaChu = "") Then
                strError = "Không tìm thấy Mã Chủ sử dụng đất"
                Exit Sub
            End If
            'GÁN GIÁ TRỊ CHO THUỘC TÍNH CỦA ĐỐI TƯỢNG CHỦ SỬ DỤNG HỒ SƠ CẤP GCN
            'Mã Hồ sơ cấp GCN
            ChuSuDung.MaHoSoCapGCN = strMaHoSoCapGCN
            'Mã Chủ sử dụng đất
            ChuSuDung.MaChuSuDung = strMaChu
            Dim str As String = ""
            Dim strUpdateResults As String = ""
            'Xác định kiểu cập nhật
            'Trường hợp thêm mới Chủ Hồ sơ cấp GCN
            If (Me.shFlag = 1) Then
                strUpdateResults = ChuSuDung.InsertData(str)
                'Trường hợp Xóa Chủ Hồ sơ cấp GCN
            ElseIf (Me.shFlag = 3) Then
                strUpdateResults = ChuSuDung.DeleteData(str)
            End If
            'Nếu cập nhật thành công
            If strUpdateResults = "" Then
                Me.TrangThaiBanDau()
            End If
            strError = ChuSuDung.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Đối tượng hộ gia đình, cá nhân " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

End Class
