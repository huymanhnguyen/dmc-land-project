Imports System.Windows.Forms
Imports DMC.Components
Imports System.Drawing
Imports System.Text

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
    Private MaLoaiBienDong As String = ""
    Public Property MaKhoa() As String
        Get
            Return MaLoaiBienDong
        End Get
        Set(ByVal value As String)
            MaLoaiBienDong = value
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
            .cboDinhDanh.Text = "CMND"
            strSoCMND = ""
            strSoCMND2 = ""
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
                    chkDaChet.Enabled = False
                Else
                    chkDaChet.Enabled = True
                End If
                'Trang thai chuc nang
                .TrangThaiChucNang(True)
                'Trang thai cap nhat
                .TrangThaiCapNhat(True)
                strSoCMND = txtSoCMT.Text
                strSoCMND2 = txtSoCMT2.Text
            End With
        Else
            MsgBox(" Bạn chưa chọn Chủ cần sửa thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub
    'kiem tra xem tat ca la chu su dung co phai la dong so huu hay khong
    Public Function KiemTraDongSoHuu() As Boolean
        Dim cls As New clsChu
        cls.Connection = strConnection
        cls.MaHoSoCapGCN = strMaHoSoCapGCN
        Dim dt As New DataTable
        Dim kt As Boolean = True
        If cls.GetDataDongSoHuu(dt) = "" Then
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item(0) <> 0 Then
                    kt = False
                End If
            End If
        End If
        Return kt
    End Function
    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        'Kiem tra du lieu nhap vao
        If txtMaDoiTuong.Text.Trim = "" Then
            MsgBox("Bạn phải nhập Mã đối tượng sử dụng đất!", MsgBoxStyle.Information, "DMCLand")
            txtMaDoiTuong.Focus()
            Exit Sub
        End If

        Dim cls As New clsChuGDCN
        Dim dt As New DataTable
        cls.Connection = strConnection
        If txtSoCMT.Text.Trim <> "" Then
            If txtSoCMT.Text <> strSoCMND Then
                cls.SoDinhDanh = txtSoCMT.Text.Trim
                cls.Flag = 0

                dt = cls.KtraCMD()
                If dt.Rows.Count > 0 Then
                    txtSoCMT.Focus()
                    MessageBox.Show("Số chứng minh thư này đã tồn tại !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
        End If
        If txtSoCMT2.Text.Trim <> "" Then
            If txtSoCMT2.Text.Trim <> strSoCMND2 Then
                cls.SoDinhDanh2 = txtSoCMT2.Text.Trim
                cls.Flag = 1
                dt = New DataTable
                dt = cls.KtraCMD()
                If dt.Rows.Count > 0 Then
                    txtSoCMT2.Focus()
                    MessageBox.Show("Số chứng minh thư này đã tồn tại !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
        End If
        If grdvwChu.RowCount > 1 Then
            If KiemTraDongSoHuu() = chkDongSoHuu.Checked Then
                MsgBox("Tất cả các chủ sử dụng phải là đồng sở hữu!", MsgBoxStyle.Information, "DMCLand")
                Return
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
            strSoCMND2 = ""
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

                'Quốc tịch 2
                With .Columns("QuocTich2")
                    .HeaderText = "Quốc tịch 2"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Số định danh 2
                With .Columns("SoDinhDanh2")
                    .HeaderText = "Số CMT 2"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ngày cấp định danh 2
                With .Columns("NgayCap2")
                    .HeaderText = "Ngày cấp CMT(HC) 2"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nơi cấp định danh 2
                With .Columns("NoiCap2")
                    .HeaderText = "Nơi cấp CMT(HC) 2"
                    .Width = 150
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
        Dim ChuGDCN As New clsChuGDCN
        'Gán giá trị cho thuộc tính với trường hợp truy vấn
        Try
            With ChuGDCN
                'Khai báo nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
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
        clsNhatky.NghiepVu = "Cập nhật chủ GDCN"
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
        Dim ChuGDCN As New clsChuGDCN
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
            'Quốc tịch 2
            ChuGDCN.QuocTich2 = cmbQuocTich2.Text.Trim
            ChuGDCN.SoDinhDanh2 = txtSoCMT2.Text.Trim
            If DTPNgayCapCMT2.Checked Then
                ChuGDCN.NgayCap2 = DTPNgayCapCMT2.Text
            Else
                ChuGDCN.NgayCap2 = Nothing
            End If
            ChuGDCN.NoiCap2 = txtNoiCapCMT2.Text.Trim


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
            'Xác định chủ thể sử dụng/ sở hữu
            ChuGDCN.CayLauNam = Me.chkChuCayLauNam.Checked
            ChuGDCN.CongTrinh = Me.chkChuCongTrinhXayDung.Checked
            ChuGDCN.Dat = Me.chkChuDat.Checked
            ChuGDCN.NhaO = Me.chkChuNhaO.Checked
            ChuGDCN.DongSoHuu = Me.chkDongSoHuu.Checked
            If RadCaNhan.Checked Then
                ChuGDCN.LoaiCSD = "1"
            Else
                ChuGDCN.LoaiCSD = "0"
            End If

            ChuGDCN.RungCay = Me.chkChuRungCay.Checked
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

            .cmbQuocTich2.Enabled = blnCapNhat
            .txtSoCMT2.ReadOnly = Not blnCapNhat
            .DTPNgayCapCMT2.Enabled = blnCapNhat
            .txtNoiCapCMT2.ReadOnly = Not blnCapNhat

            .DTPNgayCapHK.Enabled = blnCapNhat
            'Đối tượng sử dụng/sở hữu
            .chkDongSoHuu.Enabled = blnCapNhat

            .RadCaNhan.Enabled = blnCapNhat
            .RadGiaDinh.Checked = blnCapNhat
            .chkChuDat.Enabled = blnCapNhat
            .chkChuNhaO.Enabled = blnCapNhat
            .chkChuCongTrinhXayDung.Enabled = blnCapNhat
            .chkChuRungCay.Enabled = blnCapNhat
            .chkChuCayLauNam.Enabled = blnCapNhat

            chkDaChet.Enabled = blnCapNhat
            If blnCapNhat Then
                .txtDiaChiThuongTru.BackColor = Color.White
                .txtHoTen.BackColor = Color.White
                .txtMaDoiTuong.BackColor = Color.White
                .numNamSinh.BackColor = Color.White

                .txtSoCMT.BackColor = Color.White
                .txtNoiCapCMT.BackColor = Color.White

                .txtSoCMT2.BackColor = Color.White
                .txtNoiCapCMT2.BackColor = Color.White

                .txtNoiCapHK.BackColor = Color.White
                .txtSoHoKhau.BackColor = Color.White
            Else
                .txtDiaChiThuongTru.BackColor = Color.LightYellow
                .txtHoTen.BackColor = Color.LightYellow
                .txtMaDoiTuong.BackColor = Color.LightYellow
                .numNamSinh.BackColor = Color.LightYellow

                .txtSoCMT.BackColor = Color.LightYellow
                .txtNoiCapCMT.BackColor = Color.LightYellow

                .txtSoCMT2.BackColor = Color.LightYellow
                .txtNoiCapCMT2.BackColor = Color.LightYellow

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
            .txtSoCMT.Text = ""
            .cboDinhDanh.Text = "CMND"
            .DTPNgayCapCMT.Value = Date.Now
            .DTPNgayCapCMT.Checked = False
            .txtNoiCapCMT.Text = ""

            .cmbQuocTich2.Text = ""
            .txtSoCMT2.Text = ""
            .DTPNgayCapCMT2.Value = Date.Now
            .DTPNgayCapCMT2.Checked = False
            .txtNoiCapCMT2.Text = ""

            .txtNoiCapHK.Text = ""
            .txtSoHoKhau.Text = ""
            .DTPNgayCapHK.Value = Date.Now
            .DTPNgayCapHK.Checked = False
            .DTPNgayCapHK.Enabled = False
            'Mặc định Chủ hồ sơ cấp GCN là Chủ đất
            .chkChuDat.Checked = True
            .chkChuNhaO.Checked = False
            .chkChuCongTrinhXayDung.Checked = False
            .chkChuRungCay.Checked = False
            .chkChuCayLauNam.Checked = False
            .chkDaChet.Checked = False
            .chkDongSoHuu.Checked = False
            ' .chkLoaiCSD.Checked = False
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox1.Enabled = True
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
            Else
                Me.GroupBox1.Enabled = False
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
                    ChuGDCN.NgayCapHoKhau = .Item("NgayCapHoKhau").ToString

                    ChuGDCN.NoiCapHoKhau = .Item("NoiCapHoKhau").ToString
                    ChuGDCN.QuanHe = .Item("QuanHe").ToString
                    'Quốc tịch 1
                    ChuGDCN.QuocTich = .Item("QuocTich").ToString
                    ChuGDCN.SoDinhDanh = .Item("SoDinhDanh").ToString
                    ChuGDCN.DinhDanh = .Item("DinhDanh").ToString
                    ChuGDCN.NgayCap = .Item("NgayCap").ToString
                    ChuGDCN.NoiCap = .Item("NoiCap").ToString
                    'Quốc tịch 2
                    ChuGDCN.QuocTich2 = .Item("QuocTich2").ToString
                    ChuGDCN.SoDinhDanh2 = .Item("SoDinhDanh2").ToString
                    ChuGDCN.NgayCap2 = .Item("NgayCap2").ToString
                    ChuGDCN.NoiCap2 = .Item("NoiCap2").ToString

                    ChuGDCN.SoHoKhau = .Item("SoHoKhau").ToString
                    ChuGDCN.DaChet = .Item("DaChet").ToString
                    'Chủ thể sở hữu/sử dụng
                    ChuGDCN.Dat = .Item("Dat").ToString
                    ChuGDCN.NhaO = .Item("NhaO").ToString
                    ChuGDCN.DongSoHuu = .Item("DongSoHuu").ToString
                    ChuGDCN.LoaiCSD = .Item("LoaiCSD").ToString

                    ChuGDCN.CongTrinh = .Item("CongTrinhXayDung").ToString
                    ChuGDCN.RungCay = .Item("RungCay").ToString
                    ChuGDCN.CayLauNam = .Item("CayLauNam").ToString
                End With
                'Hien thi ban ghi tuong ung lenh Form
                With Me
                    .txtDiaChiThuongTru.Text = ChuGDCN.DiaChi
                    .txtHoTen.Text = ChuGDCN.HoTen
                    .txtMaDoiTuong.Text = dtChuGDCN.Rows(e.RowIndex).Item("DoiTuongSDD").ToString
                    .numNamSinh.Text = ChuGDCN.NamSinh
                    'Quốc tịch thứ 1
                    .cmbQuocTich.Text = ChuGDCN.QuocTich
                    .txtSoCMT.Text = ChuGDCN.SoDinhDanh
                    .cboDinhDanh.Text = ChuGDCN.DinhDanh
                    If Not IsDate(ChuGDCN.NgayCap) Then
                        .DTPNgayCapCMT.Value = Date.Now
                        .DTPNgayCapCMT.Checked = False
                    Else
                        .DTPNgayCapCMT.Value = ChuGDCN.NgayCap
                        .DTPNgayCapCMT.Checked = True
                    End If
                    .txtNoiCapCMT.Text = ChuGDCN.NoiCap
                    'Quốc tịch thứ 2
                    .cmbQuocTich2.Text = ChuGDCN.QuocTich2
                    .txtSoCMT2.Text = ChuGDCN.SoDinhDanh2
                    If Not IsDate(ChuGDCN.NgayCap2) Then
                        .DTPNgayCapCMT2.Value = Date.Now
                        .DTPNgayCapCMT2.Checked = False
                    Else
                        .DTPNgayCapCMT2.Value = ChuGDCN.NgayCap
                        .DTPNgayCapCMT2.Checked = True
                    End If
                    .txtNoiCapCMT2.Text = ChuGDCN.NoiCap2

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
                    'Đối tượng sử dụng/sở hữu
                    If ChuGDCN.DongSoHuu = "True" Then
                        chkDongSoHuu.Checked = True
                    Else
                        chkDongSoHuu.Checked = False
                    End If
                    If ChuGDCN.LoaiCSD = "True" Then
                        RadCaNhan.Checked = True
                    Else
                        RadGiaDinh.Checked = True
                    End If
                    If ChuGDCN.Dat = "True" Then
                        chkChuDat.Checked = True
                    Else
                        chkChuDat.Checked = False
                    End If
                    If ChuGDCN.Dat = "True" Then
                        chkChuDat.Checked = True
                    Else
                        chkChuDat.Checked = False
                    End If
                    If ChuGDCN.NhaO = "True" Then
                        chkChuNhaO.Checked = True
                    Else
                        chkChuNhaO.Checked = False
                    End If
                    If ChuGDCN.CongTrinh = "True" Then
                        chkChuCongTrinhXayDung.Checked = True
                    Else
                        chkChuCongTrinhXayDung.Checked = False
                    End If
                    If ChuGDCN.RungCay = "True" Then
                        chkChuRungCay.Checked = True
                    Else
                        chkChuRungCay.Checked = False
                    End If
                    If ChuGDCN.CayLauNam = "True" Then
                        chkChuCayLauNam.Checked = True
                    Else
                        chkChuCayLauNam.Checked = False
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

    ''' <summary>
    ''' Thêm thông tin Chủ trong bảng Từ điển Chủ vào thông tin 
    ''' Chủ đăng ký cấp GCN
    ''' </summary>
    ''' <param name="dtChuTimKiem">Danh sách Chủ tìm được trong bảng Từ điển</param>
    ''' <remarks></remarks>
    Private Sub ThemChuTimKiemVaoChuDangKyCapGCN(ByVal dtChuTimKiem As DataTable)
        Dim strXML As String = ""
        dtChuTimKiem.Columns.Add("DongSoHuu")
        For I As Integer = 0 To dtChuTimKiem.Rows.Count - 1
            If chkDongSoHuu.Checked Then
                dtChuTimKiem.Rows(I).Item("DongSoHuu") = "True"
            Else
                dtChuTimKiem.Rows(I).Item("DongSoHuu") = "False"
            End If
        Next
        dtChuTimKiem.Columns.Add("LoaiCSD")
        For I As Integer = 0 To dtChuTimKiem.Rows.Count - 1
            If RadCaNhan.Checked Then
                dtChuTimKiem.Rows(I).Item("LoaiCSD") = "True"
            Else
                dtChuTimKiem.Rows(I).Item("LoaiCSD") = "False"
            End If
        Next
        strXML = Me.CreateXML(dtChuTimKiem)
        'Kiểm tra dữ liệu đầu vào
        If strXML = "" Then
            Return
        End If
        'Thêm thông tin Chủ đề nghị cấp GCN 
        Dim ChuDangKyCapGCN As New clsChuDangKyCapGCN
        ChuDangKyCapGCN.Connection = strConnection
        ChuDangKyCapGCN.XML = strXML
        ChuDangKyCapGCN.InsertChuDangKyCapGCN()
        Me.ShowData()
    End Sub


    Private Sub btnTraCuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraCuu.Click
        Dim TraCuu As New frmTraCuu
        Try
            TraCuu.CtrlTraCuu.Connection = strConnection
            'Xác nhận đối tượng cần tra cứu thuộc nhóm
            'Gia đình, cá nhân tương ứng với Giá trị là GDCN
            TraCuu.CtrlTraCuu.Nhom = "GDCN"
            TraCuu.StartPosition = FormStartPosition.CenterScreen
            TraCuu.ShowDialog()
            'Nhận danh sách Chủ được lựa chọn
            dtFound.Clear()
            dtFound = TraCuu.CtrlTraCuu.Selected
            'Chắc chắn rằng tồn tại danh sách được lựa chọn
            If dtFound Is Nothing Then
                Return
            End If
            'Chắc chắn rằng danh sách được chọn có số bản ghi lớn hơn 1
            If dtFound.Rows.Count < 1 Then
                Return
            End If
            If (System.Windows.Forms.MessageBox.Show("Bạn có muốn thêm Chủ đã lựa chọn vào hồ sơ không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Me.ThemChuTimKiemVaoChuDangKyCapGCN(dtFound)
                MessageBox.Show("Đã thêm thành công!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Lỗi thêm Chủ vào Hồ sơ cấp GCN: " + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ctrlChuGDCN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                'Ngày cấp CMT (HC) thứ 1
                With .DTPNgayCapCMT
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                End With
                'Ngày cấp CMT (HC) thứ 2
                With .DTPNgayCapCMT2
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

    'Private Sub chkLoaiCSD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkLoaiCSD.Checked Then
    '        chkLoaiCSD.Text = "Hộ gia đình"
    '    End If
    '    If chkLoaiCSD.Checked = False Then
    '        chkLoaiCSD.Text = "Cá nhân"
    '    End If
    'End Sub
 

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

    Private Sub cmdNoiCapCMT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNoiCapCMT1.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtNoiCapCMT.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub

    Private Sub cmdNoiCapCMT2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNoiCapCMT2.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtNoiCapCMT2.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub

    Private Sub cmdNoiDangKyHK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNoiDangKyHK.Click
        Dim frm As New frmThamSoMacDinh
        With frm.CtrThamSoMacDinh1
            .Connection = strConnection
            .ShowData()
        End With
        frm.ShowDialog()
        If frm.CtrThamSoMacDinh1.MoTa <> "" Then
            txtNoiCapHK.Text = frm.CtrThamSoMacDinh1.MoTa.Trim
        End If
    End Sub
End Class
