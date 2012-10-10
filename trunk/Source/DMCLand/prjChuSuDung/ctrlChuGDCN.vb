Imports System.Windows.Forms
Imports DMC.Components
Imports System.Drawing
Imports System.Text
Imports System.Globalization

Public Class ctrlChuGDCN
    'Khai báo biến kiểu DataTable chứa đối tượng Chủ thuộc nhóm Gia đình cá nhân
    Private dtChuGDCN As New System.Data.DataTable
    Dim dtFound As New DataTable
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
    Private strTenPhuong As String = ""
    Private strMaDonViHanhChinh As String
    Private strSoCMND As String = ""
    Private strSoCMND2 As String = ""
    Private strThongTinChuCu As String = ""
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property

    Public Property TenPhuong() As String
        Get
            Return strTenPhuong
        End Get
        Set(ByVal value As String)
            strTenPhuong = value
        End Set
    End Property
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
            .txtDiaChiThuongTru.Text = strTenPhuong
            .txtNoiCapCMT.Text = strTenDonViHanhChinh
            .txtNoiCapHK.Text = strTenDonViHanhChinh
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            'Trang thai chuc nang 
            .TrangThaiChucNang(True)
            strSoCMND = ""
            strSoCMND2 = ""
        End With
    End Sub
    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaChu <> "" Then
            shortAction = 2
            With Me
                If KTTonTai = False Then
                    chkDaChet.Enabled = False
                Else
                    chkDaChet.Enabled = True
                End If
                'Trang thai chuc nang
                .TrangThaiChucNang(True)
                'Trang thai cap nhat
                .TrangThaiCapNhat(True)
                strSoCMND = txtSoCMT.Text
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
        If txtSoCMT.Text.Trim <> "" Then
            If txtSoCMT.Text <> strSoCMND Then
                Dim cls As New clsChu
                cls.Connection = strConnection
                cls.SoDinhDanh = txtSoCMT.Text.Trim
                cls.Flag = 0
                Dim dt As New DataTable
                dt = cls.KtraCMD()
                If dt.Rows.Count > 0 Then
                    txtSoCMT.Focus()
                    MessageBox.Show("Số chứng minh thư này đã tồn tại !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
        End If
        'Xac dinh kieu cap nhat
        With Me
            'Cap nhat thong tin Chu su dung (Ho gia dinh - ca nhan)
            .UpdateData()
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat
            .TrangThaiCapNhat()
            strSoCMND = ""
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

    Private Sub grdvwChu_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
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

    Public Sub AddColumnsChuChon()
        grdChuDuocChon.Columns.Clear()
        For i As Integer = 0 To grdvwChu.ColumnCount - 1
            grdChuDuocChon.Columns.Add(grdvwChu.Columns(i).Name, grdvwChu.Columns(i).HeaderText)
        Next
    End Sub

    Private Sub FormatGridContruction(ByVal grd As DMC.Interface.GridView.ctrlGridView)
        Try
            'Ẩn tất cả các cột
            Me.HideAllColumns(grd)
            'Chỉ hiển thị những Cột cần thiết
            With grd
                ''Ma doi tuong
                'With .Columns("Chon")
                '    .HeaderText = "Chọn"
                '    .Width = 60
                '    .DisplayIndex = 0
                '    .Visible = True
                '    .SortMode = DataGridViewColumnSortMode.NotSortable
                'End With
                With .Columns("KyHieu")
                    .HeaderText = "Mã đối tượng"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Quan he
                With .Columns("QuanHe")
                    .HeaderText = "Quan hệ ghi trên GCN"
                    .Width = 150
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

                'Quốc tịch 1
                With .Columns("QuocTich")
                    .HeaderText = "Quốc tịch"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Số định danh 1
                With .Columns("DinhDanh")
                    .HeaderText = "Định danh"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("SoDinhDanh")
                    .HeaderText = "Số CMT"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ngày cấp định danh 1
                With .Columns("NgayCap")
                    .HeaderText = "Ngày cấp CMT(HC)"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nơi cấp định danh 1
                With .Columns("NoiCap")
                    .HeaderText = "Nơi cấp CMT(HC)"
                    .Width = 150
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


    Public Sub ShowData()
        'Khai báo và khởi tạo đối tượng Chủ sử dụng
        'thuộc nhóm GIA ĐÌNH, CÁ NHÂN
        Dim ChuGDCN As New clsChu
        'Gán giá trị cho thuộc tính với trường hợp truy vấn
        Try
            With ChuGDCN
                'Khai báo nhận chuỗi kết nối Database
                .Connection = strConnection
                .NhomDoiTuong = 0
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
                        .FormatGridContruction(grdvwChu)
                        AddColumnsChuChon()
                        .FormatGridContruction(grdChuDuocChon)
                    Else
                        .HideAllColumns(grdvwChu)
                    End If
                End If
            End With
            'Trạng thái ban đầu
            Me.TrangThaiBanDau()
            'Trạng thái chức năng
            Me.TrangThaiChucNang()
            'Trạng thái cập nhật
            Me.TrangThaiCapNhat()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Đối tượng HỘ GIA ĐÌNH, CÁ NHÂN " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try

    End Sub
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Cập nhật chủ chuyển nhượng GDCN"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    ''' <summary>
    ''' Cập nhật thông tin Chủ sử dụng
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateData()
        'Khai bao loi
        'Khai bao va khoi tao doi tuong
        Dim ChuGDCN As New clsChu
        Try
            'Khai báo nhận chuỗi kết nối Database
            ChuGDCN.Connection = strConnection
            'Khai báo Mã hồ sơ cấp GCN
            ChuGDCN.MaHoSoCapGCN = strMaHoSoCapGCN
            ChuGDCN.MaChu = strMaChu
            If txtDiaChiThuongTru.Text IsNot Nothing Then
                ChuGDCN.DiaChi = txtDiaChiThuongTru.Text.Trim
            Else
                ChuGDCN.DiaChi = ""
            End If
            If txtMaDoiTuong.Text IsNot Nothing Then
                ChuGDCN.DoiTuongSDD = txtMaDoiTuong.Text.Trim
            Else
                ChuGDCN.DoiTuongSDD = "GDC"
            End If
            If cmbGioiTinh.Text = cmbGioiTinh.Items.Item(0) Then
                ChuGDCN.GioiTinh = "True"
            End If
            If cmbGioiTinh.Text = cmbGioiTinh.Items.Item(1) Then
                ChuGDCN.GioiTinh = "False"
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
            'Quốc tịch 1
            ChuGDCN.QuocTich = cmbQuocTich.Text.Trim
            ChuGDCN.DinhDanh = cboDinhDanh.Text.Trim
            ChuGDCN.SoDinhDanh = txtSoCMT.Text.Trim
            If DTPNgayCapCMT.Checked Then
                ChuGDCN.NgayCap = DTPNgayCapCMT.Text
            Else
                ChuGDCN.NgayCap = Nothing
            End If
            ChuGDCN.NoiCap = txtNoiCapCMT.Text.Trim

            If DTPNgayCapHK.Checked Then
                ChuGDCN.NgayCapHoKhau = DTPNgayCapHK.Text
            Else
                ChuGDCN.NgayCapHoKhau = Nothing
            End If

            ChuGDCN.NoiCapHoKhau = txtNoiCapHK.Text
            If cmbQuanHe.Text IsNot Nothing Then
                ChuGDCN.QuanHe = cmbQuanHe.Text.Trim
            Else
                ChuGDCN.QuanHe = ""
            End If

            ChuGDCN.SoHoKhau = txtSoHoKhau.Text.Trim

            ChuGDCN.DaChet = chkDaChet.Checked.ToString
            Dim str As String = ""
            Dim strCapNhat As String = ""
            'Xác định kiểu cập nhật
            If (shortAction = 1) Then
                'Thêm mới dữ liệu
                strCapNhat = ChuGDCN.InsertData(str)
                NhatKyNguoiDung("Thêm", txtHoTen.Text & "_ CMT " & txtSoCMT.Text & "_" & txtDiaChiThuongTru.Text)
            ElseIf (shortAction = 2) Then
                'Cập nhật dữ liệu
                strCapNhat = ChuGDCN.UpdateData(str)
                NhatKyNguoiDung("Sửa", "Thay (" & strThongTinChuCu & ") bằng (" & txtHoTen.Text & "_ CMT " & txtSoCMT.Text & "_" & txtDiaChiThuongTru.Text & ")")
            ElseIf (shortAction = 3) Then
                'Xóa dữ liệu
                strCapNhat = ChuGDCN.DeleteData(str)
                NhatKyNguoiDung("Xóa", strThongTinChuCu)
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

            .txtNoiCapHK.ReadOnly = Not blnCapNhat
            .txtSoHoKhau.ReadOnly = Not blnCapNhat
            .cmbGioiTinh.Enabled = blnCapNhat
            .cmbQuanHe.Enabled = blnCapNhat

            .cmbQuocTich.Enabled = blnCapNhat
            .cboDinhDanh.Enabled = blnCapNhat
            .txtSoCMT.ReadOnly = Not blnCapNhat
            .DTPNgayCapCMT.Enabled = blnCapNhat
            .txtNoiCapCMT.ReadOnly = Not blnCapNhat



            .DTPNgayCapHK.Enabled = blnCapNhat
            chkDaChet.Enabled = blnCapNhat
            If blnCapNhat Then
                .txtDiaChiThuongTru.BackColor = Color.White
                .txtHoTen.BackColor = Color.White
                .txtMaDoiTuong.BackColor = Color.White
                .numNamSinh.BackColor = Color.White

                .txtSoCMT.BackColor = Color.White
                .txtNoiCapCMT.BackColor = Color.White


                .txtNoiCapHK.BackColor = Color.White
                .txtSoHoKhau.BackColor = Color.White
            Else
                .txtDiaChiThuongTru.BackColor = Color.LightYellow
                .txtHoTen.BackColor = Color.LightYellow
                .txtMaDoiTuong.BackColor = Color.LightYellow
                .numNamSinh.BackColor = Color.LightYellow

                .txtSoCMT.BackColor = Color.LightYellow
                .txtNoiCapCMT.BackColor = Color.LightYellow


                .txtNoiCapHK.BackColor = Color.LightYellow
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
            .txtDiaChiThuongTru.Text = strTenPhuong
            .txtHoTen.Text = ""
            .txtMaDoiTuong.Text = "GDC"
            .numNamSinh.Text = ""
            .cmbGioiTinh.Text = ""
            .cmbQuanHe.Text = ""
            .chkDaChet.Checked = True

            .cmbQuocTich.Text = "Việt Nam"
            .cboDinhDanh.Text = "CMND"
            .txtSoCMT.Text = ""
            .DTPNgayCapCMT.Value = Date.Now
            .DTPNgayCapCMT.Checked = False
            .txtNoiCapCMT.Text = ""

            .txtNoiCapHK.Text = ""
            .txtSoHoKhau.Text = ""
            .DTPNgayCapHK.Value = Date.Now
            .DTPNgayCapHK.Checked = False
            .DTPNgayCapHK.Enabled = False
            .chkDaChet.Checked = False
            ' .chkLoaiCSD.Checked = False
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            .btnSua.Enabled = Not blnStartEdited
            .btnXoa.Enabled = Not blnStartEdited
            .btnThem.Enabled = Not blnStartEdited
            .btnGhi.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            '.btnTraCuu.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnGhi.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
                '.btnTraCuu.Enabled = Not blnStartDeleted
            End If
            grdvwChu.Enabled = Not blnStartEdited
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
    Private Sub checkColumn(ByRef grdvw As DataGridView, ByVal intRowIndex As Int32, ByVal intColumnIndex As Int32)
        If (intRowIndex) < 0 Then
            Exit Sub
        End If
        'If intColumnIndex = 0 Then
        '    If (grdvw.Rows(intRowIndex).Cells("Chon").Value.ToString = "") Then
        '        grdvw.Rows(intRowIndex).Cells("Chon").Value = "True"
        '    Else
        '        If (grdvw.Rows(intRowIndex).Cells("Chon").Value = True) Then
        '            grdvw.Rows(intRowIndex).Cells("Chon").Value = "False"
        '        Else
        '            grdvw.Rows(intRowIndex).Cells("Chon").Value = "True"
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub grdvwChu_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwChu.CellMouseClick
        'Chỉ cho phép thực thi khi người dùng lựa chọn chuột Trái 
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If

        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Me.checkColumn(grdvwChu, e.RowIndex, e.ColumnIndex)
        End If
        'Khoi tao doi tuong clsTimKiem
        Dim ChuGDCN As New clsChu
        If e.RowIndex >= 0 Then
            Try
                'Gán giá trị cho thuộc tính với trường hợp truy vấn
                With grdvwChu.CurrentRow 'dtChuGDCN.Rows(e.RowIndex)
                    ChuGDCN.DoiTuongSDD = .Cells("KyHieu").Value.ToString
                    ChuGDCN.DiaChi = .Cells("DiaChi").Value.ToString  '.Item("DiaChi").ToString
                    ChuGDCN.GioiTinh = .Cells("GioiTinh").Value.ToString
                    ChuGDCN.HoTen = .Cells("HoTen").Value.ToString
                    ChuGDCN.MaChu = .Cells("MaChu").Value
                    strMaChu = ChuGDCN.MaChu
                    ChuGDCN.NamSinh = .Cells("NamSinh").Value.ToString
                    ChuGDCN.NgayCapHoKhau = .Cells("NgayCapHoKhau").Value.ToString

                    ChuGDCN.NoiCapHoKhau = .Cells("NoiCapHoKhau").Value.ToString
                    ChuGDCN.QuanHe = .Cells("QuanHe").Value.ToString
                    'Quốc tịch 1
                    ChuGDCN.QuocTich = .Cells("QuocTich").Value.ToString
                    ChuGDCN.DinhDanh = .Cells("DinhDanh").Value.ToString
                    ChuGDCN.SoDinhDanh = .Cells("SoDinhDanh").Value.ToString
                    ChuGDCN.NgayCap = .Cells("NgayCap").Value.ToString
                    ChuGDCN.NoiCap = .Cells("NoiCap").Value.ToString

                    ChuGDCN.SoHoKhau = .Cells("SoHoKhau").Value.ToString
                    ChuGDCN.DaChet = .Cells("DaChet").Value.ToString
                End With
                'Hien thi ban ghi tuong ung lenh Form
                With Me
                    .txtDiaChiThuongTru.Text = ChuGDCN.DiaChi
                    .txtHoTen.Text = ChuGDCN.HoTen
                    .txtMaDoiTuong.Text = ChuGDCN.DoiTuongSDD 'dtChuGDCN.Rows(e.RowIndex).Item("KyHieu").ToString
                    .numNamSinh.Text = ChuGDCN.NamSinh
                    'Quốc tịch thứ 1
                    .cmbQuocTich.Text = ChuGDCN.QuocTich
                    .cboDinhDanh.Text = ChuGDCN.DinhDanh
                    .txtSoCMT.Text = ChuGDCN.SoDinhDanh
                    If Not IsDate(ChuGDCN.NgayCap) Then
                        .DTPNgayCapCMT.Value = Date.Now
                        .DTPNgayCapCMT.Checked = False
                    Else
                        .DTPNgayCapCMT.Value = ChuGDCN.NgayCap
                        .DTPNgayCapCMT.Checked = True
                    End If
                    .txtNoiCapCMT.Text = ChuGDCN.NoiCap

                    .txtNoiCapHK.Text = ChuGDCN.NoiCapHoKhau
                    .txtSoHoKhau.Text = ChuGDCN.SoHoKhau

                    If Not (IsDate(ChuGDCN.NgayCapHoKhau)) Then
                        .DTPNgayCapHK.Value = Date.Now
                        .DTPNgayCapHK.Checked = False
                    Else
                        .DTPNgayCapHK.Value = ChuGDCN.NgayCapHoKhau
                        .DTPNgayCapHK.Checked = True
                    End If

                    If ChuGDCN.GioiTinh = "True" Then
                        .cmbGioiTinh.Text = "Nam"
                    ElseIf ChuGDCN.GioiTinh = "False" Then
                        .cmbGioiTinh.Text = "Nữ"
                    Else
                        .cmbGioiTinh.Text = ""
                    End If
                    .cmbQuanHe.Text = ChuGDCN.QuanHe

                    If ChuGDCN.DaChet = "True" Then
                        chkDaChet.Checked = True
                    Else
                        chkDaChet.Checked = False
                        chkDaChet.Enabled = False
                    End If
                    strThongTinChuCu = txtHoTen.Text & "_ CMT: " & txtSoCMT.Text & "_" & txtDiaChiThuongTru.Text
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Đối tượng HỘ GIA ĐÌNH, CÁ NHÂN " _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

#Region "XML"
    Private Function CreateXML(ByVal dtWork As DataTable) As String
        'Chắc chắn rằng tồn tại ít nhất một bản ghi cần chuyển ra định dạng XML
        If (dtWork.Rows.Count < 1) Then
            Return ""
        End If
        'Tạo tài liệu XML từ bảng 
        Dim strBuilder As New StringBuilder
        strBuilder.Append("<" + "root" + ">")
        For Each row As DataRow In dtWork.Rows
            strBuilder.Append("<tblChu>")
            'MaHoSoCapGCN
            strBuilder.Append("<" + "MaHoSoCapGCN" + ">" + strMaHoSoCapGCN + "</" + "MaHoSoCapGCN" + ">")
            For i As Int16 = 0 To dtWork.Columns.Count - 1
                strBuilder.Append("<" + dtWork.Columns(i).ColumnName.ToString + ">" + row(i).ToString() + "</" + dtWork.Columns(i).ColumnName.ToString + ">")
            Next i
            strBuilder.Append("</tblChu>")
        Next
        strBuilder.Append("</" + "root" + ">")
        Return strBuilder.ToString
    End Function
#End Region


    Private Sub ctrlChuGDCN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                'Ngày cấp CMT (HC) thứ 1
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
                .TrangThaiBanDau()
                .TrangThaiCapNhat()
                .TrangThaiChucNang()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Đối tượng hộ gia đình, cá nhân " _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub grdvwChu_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
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

    Private Sub cmbQuanHe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbQuanHe.SelectedIndexChanged

    End Sub

    Private Sub txtNoiCapCMT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoiCapCMT.Leave
        
    End Sub

    Private Sub grdvwChu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdvwChu.KeyPress
        If (Char.IsLetter(e.KeyChar)) Then
            Dim i As Integer = 0
            For Each dgvRow As DataGridViewRow In grdvwChu.Rows
                If (dgvRow.Cells("HoTen").FormattedValue.ToString().StartsWith(e.KeyChar.ToString(), True, CultureInfo.InvariantCulture)) Then
                    dgvRow.Selected = True
                    Me.grdvwChu.CurrentCell = Me.grdvwChu.Rows(i).Cells(1)
                    Exit For
                    Return
                End If
                i = i + 1
            Next
        End If
    End Sub

    Private Sub grdvwChu_ColumnWidthChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles grdvwChu.ColumnWidthChanged
        CtrFilterGrid1.TaoContol()
    End Sub

    Private Sub cmdTImChu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTImChu.Click
        Try
            ShowData()
            If Not grdvwChu.DataSource Is Nothing Then
                With CtrFilterGrid1
                    .MyGrid = grdvwChu
                    .MydataTable = Nothing
                    .MydataTable = grdvwChu.DataSource
                    .TaoContol()
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        If grdChuDuocChon.CurrentRow.Index >= 0 Then
            grdChuDuocChon.Rows.RemoveAt(grdChuDuocChon.CurrentRow.Index)
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If Not CheckTonTaiMaThuaDat(grdvwChu.Rows(grdvwChu.CurrentRow.Index).Cells("MaChu").Value.ToString) Then
            MessageBox.Show("Đã được chọn !!", "DMCLand")
            Return
        End If
        grdChuDuocChon.Rows.Add(1)
        For i As Integer = 0 To grdvwChu.Columns.Count - 1
            grdChuDuocChon.Item(grdChuDuocChon.Columns(i).Name, grdChuDuocChon.Rows.Count - 1).Value = grdvwChu.CurrentRow.Cells(i).Value
        Next
    End Sub

    Public Function CheckTonTaiMaThuaDat(ByVal MaThuaDat As String) As Boolean
        Dim kt As Boolean = True

        For i As Integer = 0 To grdChuDuocChon.Rows.Count - 1
            If grdChuDuocChon.Rows(i).Cells("MaChu").Value.ToString.Trim = MaThuaDat.Trim Then
                kt = False
                Return kt
            End If
        Next
        Return kt
    End Function

    Private Sub cmdChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbQuanHe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbQuanHe.KeyDown
        If (e.KeyValue = 13) Then
            txtHoTen.Focus()
        End If
    End Sub

    Private Sub txtHoTen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHoTen.KeyDown
        If (e.KeyValue = 13) Then
            numNamSinh.Focus()
        End If
    End Sub

    Private Sub numNamSinh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numNamSinh.KeyDown
        If (e.KeyValue = 13) Then
            cmbGioiTinh.Focus()
        End If
    End Sub

    Private Sub cmbGioiTinh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbGioiTinh.KeyDown
        If (e.KeyValue = 13) Then
            cmbQuocTich.Focus()
        End If
    End Sub

    Private Sub cmbQuocTich_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbQuocTich.KeyDown
        If (e.KeyValue = 13) Then
            cboDinhDanh.Focus()
        End If
    End Sub

    Private Sub cboDinhDanh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDinhDanh.KeyDown
        If (e.KeyValue = 13) Then
            txtSoCMT.Focus()
        End If
    End Sub

    Private Sub txtSoCMT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoCMT.KeyDown
        If (e.KeyValue = 13) Then
            DTPNgayCapCMT.Focus()
        End If
    End Sub

    Private Sub DTPNgayCapCMT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPNgayCapCMT.KeyDown
        If (e.KeyValue = 13) Then
            txtNoiCapCMT.Focus()
        End If
    End Sub

    Private Sub txtNoiCapCMT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoiCapCMT.KeyDown
        If (e.KeyValue = 13) Then
            txtDiaChiThuongTru.Focus()
        End If
    End Sub

    Private Sub txtDiaChiThuongTru_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiaChiThuongTru.KeyDown
        If (e.KeyValue = 13) Then
            btnGhi.Focus()
        End If
    End Sub
End Class
