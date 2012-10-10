Imports System.Windows.Forms
Imports DMC.Components
Imports System.Drawing

Public Class ctrlChuGDCN
    'Khai báo biến kiểu DataTable chứa đối tượng Chủ thuộc nhóm Gia đình cá nhân
    Private dtChuGDCN As New System.Data.DataTable
    'Khai báo biến kiểu DataTable chứa đối tượng Chủ được lựa chọn thuộc nhóm Gia đình, cá nhân
    Public dtChuSelect As New System.Data.DataTable
    'Khai báo biến kiểu String chứa Mã hồ sơ cấp GCN
    Private strMaHoSoCapGCN As String = ""
    'Khai báo biến kiểu String chứa chuỗi kết nối cơ sở dữ liệu
    Private strConnection As String = ""
    'Khai báo và khởi tạo giá trị cho biến hành động kiểu Short
    '0 tương đương với trường hợp truy vấn
    '1 tương đương với trường hợp thêm mới một mẩu tin
    '2 tương đương với trường hợp cập nhật thông tin
    '3 tương đương với trường hợp xóa mẩu tin
    Private shortAction As Short = 0
    Private strTenDonViHanhChinh As String = "" ' Khai báo biến nhận tên đơn vị hành chính
    Private strError As String = ""     'Khai bao bien kiem tra loi
    Private strMaChu As String = ""
    Private KTTonTai As Boolean
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

    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property MaChu() As String
        Get
            Return strMaChu
        End Get
        Set(ByVal value As String)
            strMaChu = value
        End Set
    End Property

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        strMaChu = ""
        shortAction = 1
        With Me
            'Thiet lap trang thai ban dau
            .TrangThaiBanDau()
            'Thiet lap gia tri mac dinh ban dau
            .txtDiaChiThuongTru.Text = strTenDonViHanhChinh
            .txtNoiCapCMT.Text = strTenDonViHanhChinh
            .txtNoiCapHK.Text = strTenDonViHanhChinh
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            'Trang thai chuc nang 
            .TrangThaiChucNang(True)
        End With
    End Sub
    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaChu <> "" Then
            shortAction = 2
            With Me
                If KTTonTai = False Then
                    chbTonTai.Enabled = False
                Else
                    chbTonTai.Enabled = True
                End If
                'Trang thai chuc nang
                .TrangThaiChucNang(True)
                'Trang thai cap nhat
                .TrangThaiCapNhat(True)
            End With
        Else
            MsgBox(" Bạn chưa chọn Chủ cần sửa thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub
    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        'Kiem tra du lieu nhap vao
        If txtMaDoiTuong.Text.Trim = "" Then
            MsgBox("Bạn phải nhập Mã đối tượng sử dụng đất!", MsgBoxStyle.Information, "DMCLand")
            txtMaDoiTuong.Focus()
            Exit Sub
        End If
        'Xac dinh kieu cap nhat
        With Me
            'Cap nhat thong tin Chu su dung (Ho gia dinh - ca nhan)
            .UpdateData()
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat
            .TrangThaiCapNhat()
        End With
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        'Khoi tao gia tri cho bien dung chung
        strMaChu = ""
        strError = ""
    End Sub
    Private Sub TraCuuChuSuDung()
        Try
            Dim TonTai As String = ""
            Dim GioiTinh As String = ""
            If chbTonTai.Checked Then
                TonTai = "1"
            Else
                TonTai = "0"
            End If
            If cmbGioiTinh.Text.Trim = "Nam" Then
                GioiTinh = "1"
            End If
            If cmbGioiTinh.Text.Trim = "Nữ" Then
                GioiTinh = "0"
            End If
            'Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu
            If (strConnection Is Nothing) Or (strConnection = "") Then
                ''Hiển thị thông báo
                'System.Windows.Forms.MessageBox.Show("Không có chuỗi kết nối cơ sở dữ liệu!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Thoát khởi hàm
                Exit Sub
            End If
            Dim ChuGDCN As New clsChuGDCN
            With ChuGDCN
                .Connection = strConnection
                .DiaChi = txtDiaChiThuongTru.Text.Trim
                .GioiTinh = GioiTinh
                .HoTen = txtHoTen.Text.Trim
                .MaChu = ""
                .NamSinh = ""
                .NgayCap = ""
                .NgayCapHoKhau = ""
                .NoiCap = txtNoiCapCMT.Text.Trim
                .NoiCapHoKhau = txtNoiCapHK.Text.Trim
                .QuanHe = ""
                .QuocTich = cmbQuocTich.Text.Trim
                .SoDinhDanh = txtSoCMT.Text.Trim
                .SoHoKhau = txtSoHoKhau.Text.Trim
                .TonTai = TonTai
            End With

            'Hiển thị dữ liệu trên Grid
            With Me
                .grdvwChu.Columns.Clear()
                .grdvwChu.ClearSelection()
                .grdvwChu.DataSource = Nothing
                dtChuGDCN.Clear()
                'Gọi phương thức GetData để khởi tạo đối tượng Chu
                If ChuGDCN.GetData(dtChuGDCN) = "" Then
                    'Trình bày dữ liệu lên grdvwHoGiaDinhCaNhan
                    .grdvwChu.DataSource = dtChuGDCN
                    'Khi tồn tại bản ghi nhận được
                    If dtChuGDCN.Rows.Count > 0 Then
                        .FormatGridContruction()
                    Else
                        .HideAllColumns(grdvwChu)
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Lỗi: " & ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub grdvwChu_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdvwChu.CellDoubleClick
        Try
            If (e.RowIndex >= 0) Then
                'Xác định mã Chủ sử dụng
                strMaChu = dtChuGDCN.Rows(e.RowIndex).Item("MaChu").ToString()
                'Khởi tạo đối tượng DataTable chứa bản ghi (Thông tin Chủ sử dụng) được lựa chọn
                dtChuSelect = New DataTable
                'Copy định dạng của đối tượng dtChuSuDungTCDN vào đối
                ' tượng DataTable chứa bản ghi (Thông tin Chủ sử dụng) được lựa chọn
                dtChuSelect = dtChuGDCN.Clone()
                'Add bản những chủ sử dụng được lựa chọn vào biến kiểu DataTable dùng chung
                dtChuSelect.ImportRow(dtChuGDCN.Rows(e.RowIndex))
                'Ẩn Form tra cứu thông tin Chủ sử dụng
                'NOTE: CẦN VIẾT SỰ KIỆN ẨN FORM Ở ĐÂY
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Lỗi: " & ex.Message, "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Neu ton tai ma can xoa
        If strMaChu <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        'Xác định kiểu cập nhật là xóa chủ sử dụng
                        shortAction = 3
                        'Thực thi xóa chủ sử dụng
                        .UpdateData()
                        strMaChu = ""
                        'Trạng thái ban đầu
                        .TrangThaiBanDau()
                        'Hiển thị dữ liệu
                        .ShowData()
                        'Trạng thái chức năng
                        .TrangThaiChucNang()
                    End With
                Catch ex As Exception
                    strError = ex.Message
                End Try
                If (strError = "") Then
                    MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                Else
                    MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                End If
            Else
                'Trạng thái chức năng
                Me.TrangThaiChucNang()
            End If
        Else
            MsgBox(" Bạn chưa chọn Chủ cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        'Trạng thái cập nhật 
        Me.TrangThaiCapNhat()
        strError = ""
    End Sub

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
            Me.HideAllColumns(grdvwChu)
            'Chỉ hiển thị những Cột cần thiết
            With Me.grdvwChu
                'Ma doi tuong
                With .Columns("KyHieu")
                    .HeaderText = "Mã đối tượng"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ho va Ten
                With .Columns("HoTen")
                    .HeaderText = "Họ tên"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nam sinh
                With .Columns("NamSinh")
                    .HeaderText = "Năm sinh"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Gioi tinh
                With .Columns("GioiTinh")
                    .HeaderText = "Giới tính"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Quoc tich
                With .Columns("QuocTich")
                    .HeaderText = "Quốc tịch"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'So dinh danh
                With .Columns("SoDinhDanh")
                    .HeaderText = "Số CMT"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ngay cap dinh danh
                With .Columns("NgayCap")
                    .HeaderText = "Ngày cấp CMT"
                    .Width = 130
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Noi cap dinh danh
                With .Columns("NoiCap")
                    .HeaderText = "Nơi cấp CMT"
                    .Width = 130
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'So Ho Khau
                With .Columns("SoHoKhau")
                    .HeaderText = "Số hộ khẩu"
                    .Width = 130
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ngay cap Ho khau
                With .Columns("NgayCapHoKhau")
                    .HeaderText = "Ngày cấp Hộ khẩu"
                    .Width = 130
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Noi cap Ho Khau
                With .Columns("NoiCapHoKhau")
                    .HeaderText = "Nơi cấp hộ khẩu"
                    .Width = 130
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Dai chi thuong chu
                With .Columns("DiaChi")
                    .HeaderText = "Địa chỉ thường chú"
                    .Width = 130
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Quan he
                With .Columns("QuanHe")
                    .HeaderText = "Quan hệ"
                    .Width = 100
                    .Visible = True
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
            MsgBox(" Chủ sử dụng GDCN " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub ShowData()
        'Khai báo và khởi tạo đối tượng Chủ sử dụng
        'thuộc nhóm GIA ĐÌNH, CÁ NHÂN
        Dim ChuGDCN As New clsChuGDCN
        'Gán giá trị cho thuộc tính với trường hợp truy vấn
        Try
            With ChuGDCN
                'Khai báo nhận chuỗi kết nối Database
                .Connection = strConnection
                .DiaChi = ""
                .GioiTinh = ""
                .HoTen = ""
                .MaChu = ""
                .NamSinh = ""
                .NgayCap = ""
                .NgayCapHoKhau = ""
                .NoiCap = ""
                .NoiCapHoKhau = ""
                .QuanHe = ""
                .QuocTich = ""
                .SoDinhDanh = ""
                .SoHoKhau = ""
                .TonTai = ""
            End With
            With Me
                .grdvwChu.Columns.Clear()
                .grdvwChu.ClearSelection()
                .grdvwChu.DataSource = Nothing
                dtChuGDCN.Clear()
                'Gọi phương thức GetData để khởi tạo đối tượng Chu
                If ChuGDCN.GetData(dtChuGDCN) = "" Then
                    'Trình bày dữ liệu lên grdvwHoGiaDinhCaNhan
                    .grdvwChu.DataSource = dtChuGDCN
                    'Khi tồn tại bản ghi nhận được
                    If dtChuGDCN.Rows.Count > 0 Then
                        .FormatGridContruction()
                    Else
                        .HideAllColumns(grdvwChu)
                    End If
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Đối tượng HỘ GIA ĐÌNH, CÁ NHÂN " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try

    End Sub
    ''' <summary>
    ''' Cập nhật thông tin Chủ sử dụng
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateData()
        'Khai bao loi
        'Khai bao va khoi tao doi tuong
        Dim ChuGDCN As New clsChuGDCN
        Try
            'Khai báo nhận chuỗi kết nối Database
            ChuGDCN.Connection = strConnection
            ChuGDCN.MaChu = strMaChu

            If txtDiaChiThuongTru.Text IsNot Nothing Then
                ChuGDCN.DiaChi = txtDiaChiThuongTru.Text.Trim
            Else
                ChuGDCN.DiaChi = ""
            End If

            If cmbGioiTinh.Text = cmbGioiTinh.Items.Item(0) Then
                ChuGDCN.GioiTinh = "1"
            End If
            If cmbGioiTinh.Text = cmbGioiTinh.Items.Item(1) Then
                ChuGDCN.GioiTinh = "0"
            End If

            If (txtHoTen.Text IsNot Nothing) Then
                ChuGDCN.HoTen = txtHoTen.Text.Trim
            Else
                If (shortAction = 1) Or (shortAction = 2) Then
                    MsgBox("Bạn CHƯA KHAI báo tên Chủ sử dụng", MsgBoxStyle.Information, "DMCLand")
                    Exit Sub
                Else
                    ChuGDCN.HoTen = ""
                End If
            End If
            If Not IsNumeric(numNamSinh.Text.Trim) Then
                ChuGDCN.NamSinh = Nothing
            Else
                ChuGDCN.NamSinh = numNamSinh.Text.Trim
            End If

            If DTPNgayCapCMT.Checked Then
                ChuGDCN.NgayCap = DTPNgayCapCMT.Text
            Else
                ChuGDCN.NgayCap = Nothing
            End If
            If DTPNgayCapHK.Checked Then
                ChuGDCN.NgayCapHoKhau = DTPNgayCapHK.Text
            Else
                ChuGDCN.NgayCapHoKhau = Nothing
            End If

            ChuGDCN.NoiCap = txtNoiCapCMT.Text.Trim


            ChuGDCN.NoiCapHoKhau = txtNoiCapHK.Text

            If cmbQuanHe.Text IsNot Nothing Then
                ChuGDCN.QuanHe = cmbQuanHe.Text.Trim
            Else
                ChuGDCN.QuanHe = ""
            End If

            ChuGDCN.QuocTich = cmbQuocTich.Text.Trim


            ChuGDCN.SoDinhDanh = txtSoCMT.Text.Trim

            ChuGDCN.SoHoKhau = txtSoHoKhau.Text.Trim

            If chbTonTai.Checked Then
                ChuGDCN.TonTai = "1"
            Else
                ChuGDCN.TonTai = "0"
            End If
            Dim str As String = ""
            Dim strCapNhat As String = ""
            'Xác định kiểu cập nhật
            If (shortAction = 1) Then
                'Thêm mới dữ liệu
                strCapNhat = ChuGDCN.InsertData(str)
            ElseIf (shortAction = 2) Then
                'Cập nhật dữ liệu
                strCapNhat = ChuGDCN.UpdateData(str)
            ElseIf (shortAction = 3) Then
                'Xóa dữ liệu
                strCapNhat = ChuGDCN.DeleteData(str)
            End If
            'Nếu cập nhật thành công
            If strCapNhat = "" Then
                Me.TrangThaiBanDau()
                shortAction = 0
            End If
            strError = ChuGDCN.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Đối tượng HỘ GIA ĐÌNH, CÁ NHÂN " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Then
            Me.ShowData()
        End If
    End Sub
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            'If blnCapNhat Then
            .grdvwChu.BackgroundColor = Color.White
            'Else
            '    .grdvwChu.BackgroundColor = Color.LightYellow
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
                .HideAllColumns(grdvwChu)
            End If
            'Thiết lập trên Form nhập liệu
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
            .chbTonTai.Checked = True
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            .btnSua.Enabled = Not blnStartEdited
            .btnXoa.Enabled = Not blnStartEdited
            .btnThem.Enabled = Not blnStartEdited
            .btnGhi.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnGhi.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
            End If
        End With
    End Sub
    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            If strMaChu <> "" Then
                .ShowData()
            End If
            'Xóa dữ liệu trên Form
            .TrangThaiBanDau()
            'Khởi tạo giá trị ban đầu cho biến dùng chung
            strMaChu = ""
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub

    Private Sub grdvwChu_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwChu.CellMouseClick
        'Chỉ cho phép thực thi khi người dùng lựa chọn chuột Trái 
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        If chbTimKiem.Checked = False Then
            'Khoi tao doi tuong clsTimKiem
            Dim ChuGDCN As New clsChuGDCN
            If e.RowIndex >= 0 Then
                Try
                    'Gán giá trị cho thuộc tính với trường hợp truy vấn
                    With dtChuGDCN.Rows(e.RowIndex)
                        ChuGDCN.DiaChi = .Item("DiaChi").ToString
                        ChuGDCN.GioiTinh = .Item("GioiTinh").ToString
                        ChuGDCN.HoTen = .Item("HoTen").ToString
                        ChuGDCN.MaChu = .Item("MaChu").ToString
                        strMaChu = ChuGDCN.MaChu
                        ChuGDCN.NamSinh = .Item("NamSinh").ToString
                        ChuGDCN.NgayCap = .Item("NgayCap").ToString
                        ChuGDCN.NgayCapHoKhau = .Item("NgayCapHoKhau").ToString
                        ChuGDCN.NoiCap = .Item("NoiCap").ToString
                        ChuGDCN.NoiCapHoKhau = .Item("NoiCapHoKhau").ToString
                        ChuGDCN.QuanHe = .Item("QuanHe").ToString
                        ChuGDCN.QuocTich = .Item("QuocTich").ToString
                        ChuGDCN.SoDinhDanh = .Item("SoDinhDanh").ToString
                        ChuGDCN.SoHoKhau = .Item("SoHoKhau").ToString
                        ChuGDCN.TonTai = .Item("TonTai").ToString
                    End With
                    'Hien thi ban ghi tuong ung lenh Form
                    With Me
                        .txtDiaChiThuongTru.Text = ChuGDCN.DiaChi
                        .txtHoTen.Text = ChuGDCN.HoTen
                        .txtMaDoiTuong.Text = dtChuGDCN.Rows(e.RowIndex).Item("DoiTuongSDD").ToString
                        .numNamSinh.Text = ChuGDCN.NamSinh
                        .txtNoiCapCMT.Text = ChuGDCN.NoiCap
                        .txtNoiCapHK.Text = ChuGDCN.NoiCapHoKhau
                        .txtSoCMT.Text = ChuGDCN.SoDinhDanh
                        .txtSoHoKhau.Text = ChuGDCN.SoHoKhau
                        If Not IsDate(ChuGDCN.NgayCap) Then
                            .DTPNgayCapCMT.Checked = False
                            .DTPNgayCapCMT.Value = Date.Now
                        Else
                            .DTPNgayCapCMT.Checked = True
                            .DTPNgayCapCMT.Value = ChuGDCN.NgayCap
                        End If
                        If Not (IsDate(ChuGDCN.NgayCapHoKhau)) Then
                            .DTPNgayCapHK.Checked = False
                            .DTPNgayCapHK.Value = Date.Now
                        Else
                            .DTPNgayCapHK.Checked = True
                            .DTPNgayCapHK.Value = ChuGDCN.NgayCapHoKhau
                        End If

                        If ChuGDCN.GioiTinh = "True" Then
                            .cmbGioiTinh.Text = "Nam"
                        ElseIf ChuGDCN.GioiTinh = "False" Then
                            .cmbGioiTinh.Text = "Nữ"
                        Else
                            .cmbGioiTinh.Text = ""
                        End If
                        .cmbQuanHe.Text = ChuGDCN.QuanHe
                        .cmbQuocTich.Text = ChuGDCN.QuocTich
                        If ChuGDCN.TonTai = "True" Then
                            chbTonTai.Checked = True
                            KTTonTai = True
                        Else
                            chbTonTai.Checked = False
                            chbTonTai.Enabled = False
                            KTTonTai = False
                        End If
                    End With

                Catch ex As Exception
                    strError = ex.Message
                    MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Đối tượng HỘ GIA ĐÌNH, CÁ NHÂN " _
                           & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
                End Try
            End If
        End If

    End Sub

    Private Sub btnTraCuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraCuu.Click
        TraCuuChuSuDung()
    End Sub

    Private Sub chbTimKiem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTimKiem.CheckedChanged
        'TRƯỜNG HỢP TÌM KIẾM
        If chbTimKiem.Checked Then
            'Cho phép nhập thông tin tìm kiếm

            'Hiển thị nút Tra cứu
            btnTraCuu.Enabled = True
            'Ẩn tất cả các nút còn lại
            Me.TrangThaiChucNang(True, True)
            TraCuuChuSuDung()
        Else
            'TRƯỜNG HỢP CẬP NHẬT
            'Hiển thị các nút cập nhật
            Me.TrangThaiChucNang()
            'Ẩn nút tra cứu
            btnTraCuu.Enabled = False
            'Hiển thị dữ liệu
            ShowData()
        End If
    End Sub
    Private Sub chbTonTai_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTonTai.CheckedChanged
        If chbTonTai.Checked Then
            chbTonTai.Text = "Đang tồn tại"
            chbTonTai.ForeColor = Color.Black
        Else
            chbTonTai.Text = "Không còn tồn tại"
            chbTonTai.ForeColor = Color.Red
        End If
    End Sub
    Private Sub chbTonTai_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        If chbTonTai.Checked Then
            chbTonTai.Text = "Đang tồn tại"
            chbTonTai.ForeColor = Color.Black
        Else
            chbTonTai.Text = "Không còn tồn tại"
            chbTonTai.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ctrlChuGDCN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                'Cho phép nhập thông tin tìm kiếm
                .TrangThaiCapNhat(True)
                'Trạng thái chức năng
                .TrangThaiChucNang(True, True)
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Đối tượng hộ gia đình, cá nhân " _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub grdvwChu_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles grdvwChu.CellFormatting
        'If Me.grdvwChu.Columns(e.ColumnIndex).Name _
        '    = "NgayCapDinhDanh" Then
        '    If e.Value IsNot Nothing Then
        '        e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
        '    End If
        'End If
        'If Me.grdvwChu.Columns(e.ColumnIndex).Name _
        '    = "NgayCapHoKhau" Then
        '    If e.Value IsNot Nothing Then
        '        e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
        '    End If
        'End If
    End Sub
End Class
