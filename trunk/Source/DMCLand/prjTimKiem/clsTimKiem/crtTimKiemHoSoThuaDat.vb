Imports System.Drawing
Imports System.Windows.Forms
Public Class crtTimKiemHoSoThuaDat
    Private dtTimKiem As New DataTable
    'Khai báo chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai bao bien kiem tra loi
    Private strError As String = ""
    Private blnCapNhat As Boolean = False
    'Khai báo Mã hồ sơ cấp GCN, phục vụ cho việc liệt kê 10 thửa đất mới thao tác trong thời gian gần nhất
    Public strMaHoSoCapGCN As String = ""
    Private strMaThuaDat As String = ""
    Private strMaDonViHanhChinh As String = ""
    Public strToBanDo As String = ""
    Public strSoThua As String = ""
    Public strDienTich As String = ""
    Public strDiaChiThua As String = ""
    Private strNgayLapToTrinh As String = ""
    Private strNgayQuyetDinhCapGCN As String = ""
    Private strChuSuDUng As String = ""
    Private strSoDinhDanh As String = ""
    Private strCanhBaoTranhChap As String = ""
    Private isChonBanDo As String ' = 1 nghia la da co ban do hanh chinh, 0 la chua co
    'Khai báo thuộc tính chuỗi kết nối Database
    Private strChuChuyenNhuong As String
    Private strTenBangBanDo As String
    Private ischeckbiendong As String ' =1 nghĩa là đã có biến động, 0 nghĩa là chưa biến động
    Public Property TenBangBanDo() As String
        Get
            Return strTenBangBanDo
        End Get
        Set(ByVal value As String)
            strTenBangBanDo = value
        End Set
    End Property

    Public Property ChuChuyenNhuong() As String
        Get
            Return strChuChuyenNhuong
        End Get
        Set(ByVal value As String)
            strChuChuyenNhuong = value
        End Set
    End Property

    Public Property CanhBaoTranhChap() As String
        Get
            Return strCanhBaoTranhChap
        End Get
        Set(ByVal value As String)
            strCanhBaoTranhChap = value
        End Set
    End Property

    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public Property ToBanDo() As String
        Get
            Return strToBanDo
        End Get
        Set(ByVal value As String)
            strToBanDo = value
        End Set
    End Property
    Public strmakhoahoso As String = ""
    Public ReadOnly Property MaKhoa() As String
        Get
            Return strmakhoahoso
        End Get

    End Property
    Public Property SoThua() As String
        Get
            Return strSoThua
        End Get
        Set(ByVal value As String)
            strSoThua = value
        End Set
    End Property
    Public Property DienTich() As String
        Get
            Return strDienTich
        End Get
        Set(ByVal value As String)
            strDienTich = value
        End Set
    End Property
    Public Property DiaChiThua() As String
        Get
            Return strDiaChiThua
        End Get
        Set(ByVal value As String)
            strDiaChiThua = value
        End Set
    End Property
    Public Property NamCapGCN() As String
        Get
            Return strNgayQuyetDinhCapGCN
        End Get
        Set(ByVal value As String)
            strNgayQuyetDinhCapGCN = value
        End Set
    End Property
    Public Property NgayLapToTrinh() As String
        Get
            Return strNgayLapToTrinh
        End Get
        Set(ByVal value As String)
            strNgayLapToTrinh = value
        End Set
    End Property
    Public Property ChuSuDung() As String
        Get
            Return strChuSuDUng
        End Get
        Set(ByVal value As String)
            strChuSuDUng = value
        End Set
    End Property
    Public Property SoDinhDanh() As String
        Get
            Return strSoDinhDanh
        End Get
        Set(ByVal value As String)
            strSoDinhDanh = value
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
    Public ReadOnly Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
    End Property
    Public ReadOnly Property MaThuaDat() As String
        Get
            Return strMaThuaDat
        End Get
    End Property
    Private Sub cmdTimMoiGCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimMoiGCN.Click
        txtSoPhatHanhGCN.Text = ""
        txtSoVaoSoGCN.Text = ""
        txtSoQuyetDinhCapGCN.Text = ""
        txtToTrinh.Text = ""
        txtNamTrinh.Text = ""
        txtNamCapGCN.Text = ""
    End Sub

    Private Sub cmdTimMoiThua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimMoiThua.Click
        txtToBanDo.Text = ""
        txtSoThua.Text = ""
        txtDiaChiDat.Text = ""
    End Sub

    Private Sub cmdTimMoiHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimMoiHoSo.Click
        cmbTrangThaiHoSo.Text = ""
        txtHoSoTiepNhanSo.Text = ""
        txtSoThuTuTiepNhan.Text = ""
    End Sub

    Private Sub cmdTimMoiChuSuDung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimMoiChuSuDung.Click
        txtTenChu.Text = ""
        txtDinhDanh.Text = ""
    End Sub
    Public Sub AddColumnsTimKiem()
        Dim txtClnToBanDoTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnSoThuaTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnDienTichTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnDiaChiThuaTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnNgayLapToTrinhTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnNgayQuyetDinhCapGCNTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnHoTenTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnHoTenChuChuyenNhuongTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnMaThuaDatTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnMaLoaiBienDong As New DataGridViewTextBoxColumn
        Dim txtClnCanhBaoTranhChap As New DataGridViewTextBoxColumn
        'Dim txtClnSoDinhDanhTimKiem As New DataGridViewTextBoxColumn
        Try
            'Tờ bản đồ
            With txtClnToBanDoTimKiem
                .HeaderText = "Tờ bản đồ"
                .Name = "ToBanDoTimKiem"
                .Width = 100
            End With
            'Số hiệu thửa
            With txtClnSoThuaTimKiem
                .HeaderText = "Số thửa"
                .Name = "SoThuaTimKiem"
                .Width = 100
            End With
            'Dien tich thửa đất
            With txtClnDienTichTimKiem
                .HeaderText = "Diện tích"
                .Name = "DienTichTimKiem"
                .Width = 100
            End With
            'Địa chỉ thửa
            With txtClnDiaChiThuaTimKiem
                .HeaderText = "Địa chỉ đất"
                .Name = "DiaChiThuaTimKiem"
                .Width = 400
            End With
            'Địa chỉ thửa
            With txtClnNgayLapToTrinhTimKiem
                .HeaderText = "Năm trình"
                .Name = "NgayLapToTrinhTimKiem"
                .Width = 150
            End With

            With txtClnNgayQuyetDinhCapGCNTimKiem
                .HeaderText = "Năm cấp GCN"
                .Name = "NgayQuyetDinhCapGCNTimKiem"
                .Width = 150
            End With
            With txtClnHoTenTimKiem
                .HeaderText = "Chủ sử dụng"
                .Name = "HoTenTimKiem"
                .Width = 250
            End With
            With txtClnHoTenChuChuyenNhuongTimKiem
                .HeaderText = "Người nhận chuyển nhượng"
                .Name = "HoTenChuChuyenNhuongTimKiem"
                .Width = 250
            End With
            With txtClnMaThuaDatTimKiem
                .HeaderText = ""
                .Name = "MaThuaDat"
                .Width = 0
                .Visible = False
            End With
            With txtClnMaLoaiBienDong
                .HeaderText = "Loại biến động"
                .Name = "MaLoaiBienDong"
                .Width = 250

            End With
            With txtClnCanhBaoTranhChap
                .HeaderText = "Cảnh báo tranh chấp"
                .Name = "CanhBaoTranhChapKhieuKien"
                .Width = 250
                .Visible = False
            End With
            'With txtClnSoDinhDanhTimKiem
            '    .HeaderText = "Số định danh"
            '    .Name = "SoDinhDanhTimKiem"
            '    .Width = 100
            'End With
            'Add all to DataGridView
            With Me.grdvwTimKiem
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Add Columns
                With .Columns
                    .Add(txtClnToBanDoTimKiem)
                    .Add(txtClnSoThuaTimKiem)
                    .Add(txtClnDienTichTimKiem)
                    .Add(txtClnDiaChiThuaTimKiem)
                    .Add(txtClnNgayLapToTrinhTimKiem)
                    .Add(txtClnNgayQuyetDinhCapGCNTimKiem)
                    .Add(txtClnHoTenTimKiem)
                    .Add(txtClnHoTenChuChuyenNhuongTimKiem)
                    .Add(txtClnMaThuaDatTimKiem)
                    .Add(txtClnMaLoaiBienDong)
                    .Add(txtClnCanhBaoTranhChap)
                End With
                'Không cho phép thêm
                .AllowUserToAddRows = False
                'Không cho phép xóa
                .AllowUserToDeleteRows = False
                'Không lựa chọn bất kỳ dòng nào
                .ClearSelection()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Tìm kiếm" + vbNewLine + " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub AddColumnsTacNghiep()
        Dim txtClnToBanDoTacNghiep As New DataGridViewTextBoxColumn
        Dim txtClnSoThuaTacNghiep As New DataGridViewTextBoxColumn
        Dim txtClnDienTichTacNghiep As New DataGridViewTextBoxColumn
        Dim txtClnDiaChiThuaTacNghiep As New DataGridViewTextBoxColumn
        Dim txtClnNgayLapToTrinhTacNghiep As New DataGridViewTextBoxColumn
        Dim txtClnNgayQuyetDinhCapGCNTacNghiep As New DataGridViewTextBoxColumn
        Dim txtClnHoTenTacNghiep As New DataGridViewTextBoxColumn
        Dim txtClnHoTenChuChuyenNhuongTacNghiep As New DataGridViewTextBoxColumn
        Dim txtClnMaLoaiBienDong As New DataGridViewTextBoxColumn
        Dim txtClnCanhBaoTranhChap As New DataGridViewTextBoxColumn

        'Dim txtClnSoDinhDanhTacNghiep As New DataGridViewTextBoxColumn
        Try
            'Tờ bản đồ
            With txtClnToBanDoTacNghiep
                .HeaderText = "Tờ bản đồ"
                .Name = "ToBanDoTacNghiep"
                .Width = 100
            End With
            'Số hiệu thửa
            With txtClnSoThuaTacNghiep
                .HeaderText = "Số thửa"
                .Name = "SoThuaTacNghiep"
                .Width = 100
            End With
            'Dien tich thửa đất
            With txtClnDienTichTacNghiep
                .HeaderText = "Diện tích"
                .Name = "DienTichTacNghiep"
                .Width = 100
            End With
            'Địa chỉ thửa
            With txtClnDiaChiThuaTacNghiep
                .HeaderText = "Địa chỉ đất"
                .Name = "DiaChiThuaTacNghiep"
                .Width = 400
            End With
            With txtClnNgayLapToTrinhTacNghiep
                .HeaderText = "Năm trình"
                .Name = "NgayLapToTrinhTacNghiep"
                .Width = 150
            End With

            With txtClnNgayQuyetDinhCapGCNTacNghiep
                .HeaderText = "Năm cấp GCN"
                .Name = "NgayQuyetDinhCapGCNTacNghiep"
                .Width = 150
            End With
            With txtClnHoTenTacNghiep
                .HeaderText = "Chủ sử dụng"
                .Name = "HoTenTacNghiep"
                .Width = 150
            End With
            With txtClnHoTenChuChuyenNhuongTacNghiep
                .HeaderText = "Người nhận chuyển nhượng"
                .Name = "HoTenChuChuyenNhuongTacNghiep"
                .Width = 150
            End With
            With txtClnMaLoaiBienDong
                .HeaderText = "Loại biến động"
                .Name = "MaLoaiBienDong"
                .Width = 250
            End With
            With txtClnCanhBaoTranhChap
                .HeaderText = "Cảnh báo tranh chấp"
                .Name = "CanhBaoTranhChapKhieuKien"
                .Width = 250
                .Visible = False
            End With
            'With txtClnSoDinhDanhTacNghiep
            '    .HeaderText = "Số định danh"
            '    .Name = "SoDinhDanhTacNghiep"
            '    .Width = 100
            'End With
            'Add all to DataGridView
            With Me.grdvwTacNghiep
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Add Columns
                With .Columns
                    .Add(txtClnToBanDoTacNghiep)
                    .Add(txtClnSoThuaTacNghiep)
                    .Add(txtClnDienTichTacNghiep)
                    .Add(txtClnDiaChiThuaTacNghiep)
                    .Add(txtClnNgayLapToTrinhTacNghiep)
                    .Add(txtClnNgayQuyetDinhCapGCNTacNghiep)
                    .Add(txtClnHoTenTacNghiep)
                    .Add(txtClnHoTenChuChuyenNhuongTacNghiep)
                    .Add(txtClnMaLoaiBienDong)
                    .Add(txtClnCanhBaoTranhChap)
                End With
                'Không cho phép thêm
                .AllowUserToAddRows = False
                'Không cho phép xóa
                .AllowUserToDeleteRows = False
                'Không lựa chọn bất kỳ dòng nào
                .ClearSelection()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Tìm kiếm" + vbNewLine + " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    'Doi ky tu rong ve dang so (0)
    Function DoiKyTuVeDangSo(ByVal strKyTu As String) As Double
        Dim dblTempNumber As Double = 0.0
        If strKyTu = "" Then
            dblTempNumber = 0.0
        Else
            dblTempNumber = Convert.ToDouble(strKyTu)
        End If
        Return dblTempNumber
    End Function
    Private Sub grdvwTimKiem_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwTimKiem.CellMouseClick
        'Truong hop click chuot trai vao grid
        If (e.Button.ToString = "Left") And (e.RowIndex >= 0) Then
            Me.grdvwTimKiem.ClearSelection()
            Exit Sub
        End If
        'Truong hop lua chon mot ban ghi

        If (e.Button.ToString = "Right") And (e.RowIndex >= 0) Then 
            Try
                With grdvwTimKiem
                    .ClearSelection()
                    .Rows(e.RowIndex).Selected = True
                End With
                With dtTimKiem.Rows(e.RowIndex)
                    'Gan gia tri vao bien dung chung
                    strMaThuaDat = ""
                    strMaThuaDat = .Item("MaThuaDat").ToString
                    strMaHoSoCapGCN = ""
                    strmakhoahoso = 0

                    strMaHoSoCapGCN = .Item("MaHoSoCapGCN").ToString
                    strmakhoahoso = MaLoaiBienDong(strMaHoSoCapGCN)
                    'Hien thi ban ghi lua chon len Danh sach thua can tac nghiep
                    grdvwTacNghiep.RowCount = 1
                    grdvwTacNghiep.Item("ToBanDoTacNghiep", 0).Value = .Item("ToBanDo").ToString
                    strToBanDo = .Item("ToBanDo").ToString
                    grdvwTacNghiep.Item("SoThuaTacNghiep", 0).Value = .Item("SoThua").ToString
                    strSoThua = .Item("SoThua").ToString
                    grdvwTacNghiep.Item("DiaChiThuaTacNghiep", 0).Value = .Item("DiaChi").ToString
                    strDiaChiThua = .Item("DiaChi").ToString
                    grdvwTacNghiep.Item("DienTichTacNghiep", 0).Value = .Item("DienTich").ToString
                    strDienTich = .Item("DienTich").ToString
                    grdvwTacNghiep.Item("NgayLapToTrinhTacNghiep", 0).Value = .Item("NgayLapToTrinh").ToString
                    strNgayLapToTrinh = .Item("NgayLapToTrinh").ToString
                    grdvwTacNghiep.Item("NgayQuyetDinhCapGCNTacNghiep", 0).Value = .Item("NgayQuyetDinhCapGCN").ToString
                    strNgayQuyetDinhCapGCN = .Item("NgayQuyetDinhCapGCN").ToString
                    grdvwTacNghiep.Item("HoTenTacNghiep", 0).Value = TongHopChu(strMaHoSoCapGCN)
                    grdvwTacNghiep.Item("HoTenChuChuyenNhuongTacNghiep", 0).Value = TongHopChuChuyenNhuong(strMaHoSoCapGCN)
                    grdvwTacNghiep.Item("MaLoaiBienDong", 0).Value = MaLoaiBienDong(strMaHoSoCapGCN)
                    grdvwTacNghiep.Item("CanhBaoTranhChapKhieuKien", 0).Value = .Item("CanhBaoTranhChapKhieuKien").ToString
                    strCanhBaoTranhChap = .Item("CanhBaoTranhChapKhieuKien").ToString
                    strChuChuyenNhuong = grdvwTacNghiep.Item("HoTenChuChuyenNhuongTacNghiep", 0).Value.ToString()
                    'strChuSuDung = .Item("HoTen").ToString
                    'grdvwTacNghiep.Item("SoDinhDanhTacNghiep", 0).Value = .Item("SoDinhDanh").ToString
                    'strSoDinhDanh = .Item("SoDinhDanh").ToString
                    '/...
                End With
                'Trang thai chuc nang 
                blnCapNhat = False
            Catch ex As Exception
                strError = ex.Message
                MsgBox("Tìm kiếm: " & vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Public Sub NguonGocHoSo()
        Dim dtNguonCap As New DataTable
        Dim cls As New clsTimKiemHoSo
        cls.Connection = strConnection
        dtNguonCap = cls.GetNguonCapHoSo()
        If dtNguonCap.Rows.Count > 0 Then
            cboNguonCapHoSo.DataSource = dtNguonCap
            cboNguonCapHoSo.ValueMember = "MaNguonHoSo"
            cboNguonCapHoSo.DisplayMember = "TenNguonHoSo"
            cboNguonCapHoSo.Text = ""
        End If
    End Sub

    Public Function MaLoaiBienDong(ByVal MaHoSo As String) As String
        Dim dt As New DataTable
        Dim strMaLoaiBD As String = ""
        Dim cls As New clsTimKiemHoSo
        cls.Connection = strConnection
        cls.MaHoSoCapGCN = MaHoSo
        dt = cls.SelectLoaiBienDong()
        If dt.Rows.Count > 0 Then
            strMaLoaiBD = dt.Rows(0).Item("MaLoaiBienDong").ToString.Trim
        End If
        Return strMaLoaiBD
    End Function

    Private Sub crtTimKiemHoSoThuaDat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            If (grdvwTacNghiep.Columns.Count = 0) Then
                .AddColumnsTacNghiep()
            End If
            If (grdvwTimKiem.Columns.Count = 0) Then
                .AddColumnsTimKiem()

            End If
            With .grdvwTimKiem
                .ReadOnly = True
                .RowCount = 0
            End With
            With .grdvwTacNghiep
                .ReadOnly = True
                .RowCount = 0
            End With
            If chkChonBanDo.Checked Then
                isChonBanDo = "1"
            Else
                isChonBanDo = "0"
            End If
        End With
    End Sub
    Public Sub TimThua()
        '---------------------Thong tin tim kiem Tong the------------------------'
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New clsTimKiemHoSo
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            .strMaHoSoCapGCN = ""
            .strMaThuaDat = ""
            With .grdvwTacNghiep
                .RowCount = 0
                .ClearSelection()
            End With
            With .grdvwTimKiem
                .RowCount = 0
                .ClearSelection()
            End With
        End With
        'Kiem tra xem da chon don vi hanh chinh can tac nghiep chua
        If (strMaDonViHanhChinh.Trim = "") Or (strMaDonViHanhChinh = "0") Then
            MsgBox("Bạn chưa chọn đơn vị hành chính!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDonViHanhChinh = ToiUuXau(Me.strMaDonViHanhChinh)
            'Mã đơn vị hành chính
            Dim strDVHC As String = ""
            Dim dtDVHC As New DataTable
            dtDVHC = TimKiem.SelectMaXa()
            strDVHC = dtDVHC.Rows(0).Item("MaXa")
            If isChonBanDo = "1" Then
                .MaDonViHanhChinh = ToiUuXau(Me.strMaDonViHanhChinh)
            Else
                .MaDonViHanhChinh = ToiUuXau(strDVHC)
            End If
            .IsBanDo = isChonBanDo
            'Tờ bản đồ
            .ToBanDo = ToiUuXau(Me.txtToBanDo.Text.Trim)
            'Số thửa
            .SoThua = ToiUuXau(Me.txtSoThua.Text.Trim)
            .DiaChiThua = ToiUuXau(txtDiaChiDat.Text.Trim)
        End With
        Try
            dtTimKiem = TimKiem.SelectThuaDat()
            'Kiểm tra tính hợp lệ của dữ liệu
            If (dtTimKiem Is Nothing) Then
                Return
            End If
            If dtTimKiem.Rows.Count > 0 Then
                'Trình bày dữ liệu lên Form
                LoadGrid(dtTimKiem)
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Private Sub cmdTimThua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimThua.Click
        TimThua()
    End Sub

    Private Sub cmdTimGCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimGCN.Click
        TimCapGCN()
    End Sub
    Public Sub TimCapGCN()
        '---------------------Thong tin tim kiem Tong the------------------------'
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New clsTimKiemHoSo
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            .strMaHoSoCapGCN = ""
            .strMaThuaDat = ""
            With .grdvwTacNghiep
                .RowCount = 0
                .ClearSelection()
            End With
            With .grdvwTimKiem
                .RowCount = 0
                .ClearSelection()
            End With
        End With
        'Kiem tra xem da chon don vi hanh chinh can tac nghiep chua
        If (strMaDonViHanhChinh.Trim = "") Or (strMaDonViHanhChinh = "0") Then
            MsgBox("Bạn chưa chọn đơn vị hành chính!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDonViHanhChinh = ToiUuXau(Me.strMaDonViHanhChinh)
            'Mã đơn vị hành chính
            Dim strDVHC As String = ""
            Dim dtDVHC As New DataTable
            dtDVHC = TimKiem.SelectMaXa()
            strDVHC = dtDVHC.Rows(0).Item("MaXa")
            If isChonBanDo = "1" Then
                .MaDonViHanhChinh = ToiUuXau(Me.strMaDonViHanhChinh)
            Else
                .MaDonViHanhChinh = ToiUuXau(strDVHC)
            End If
            .IsBanDo = isChonBanDo
            .SoPhatHanhGCN = ToiUuXau(Me.txtSoPhatHanhGCN.Text.Trim)
            .SoVaoSoCapGCN = ToiUuXau(Me.txtSoVaoSoGCN.Text.Trim)
            .SoQuyetDinhCapGCN = ToiUuXau(Me.txtSoQuyetDinhCapGCN.Text.Trim)
            .SoToTrinh = ToiUuXau(txtToTrinh.Text.Trim)
            .NgayQuyetDinhCapGCN = ToiUuXau(txtNamCapGCN.Text.Trim)
            .NamTrinh = ToiUuXau(txtNamTrinh.Text.Trim)
        End With
        Try
            dtTimKiem = TimKiem.SelectGCN()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If
            If dtTimKiem.Rows.Count > 0 Then
                'Trình bày dữ liệu lên Form
                LoadGrid(dtTimKiem)
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub LoadGrid(ByVal dtTimKiem As DataTable)
        If dtTimKiem.Rows.Count > 0 Then
            For i As Integer = 0 To dtTimKiem.Rows.Count - 1
                With Me.grdvwTimKiem
                    .RowCount += 1
                    .Item("ToBanDoTimKiem", i).Value = dtTimKiem.Rows(i).Item("ToBanDo").ToString
                    .Item("SoThuaTimKiem", i).Value = dtTimKiem.Rows(i).Item("SoThua").ToString
                    .Item("DiaChiThuaTimKiem", i).Value = dtTimKiem.Rows(i).Item("DiaChi").ToString
                    .Item("DienTichTimKiem", i).Value = dtTimKiem.Rows(i).Item("DienTich").ToString
                    .Item("NgayLapToTrinhTimKiem", i).Value = dtTimKiem.Rows(i).Item("NgayLapToTrinh").ToString
                    .Item("NgayQuyetDinhCapGCNTimKiem", i).Value = dtTimKiem.Rows(i).Item("NgayQuyetDinhCapGCN").ToString
                    .Item("HoTenTimKiem", i).Value = TongHopChu(dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString)
                    .Item("HoTenChuChuyenNhuongTimKiem", i).Value = TongHopChuChuyenNhuong(dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString)
                    .Item("MaThuaDat", i).Value = dtTimKiem.Rows(i).Item("MaThuaDat").ToString
                    .Item("MaLoaiBienDong", i).Value = MaLoaiBienDong(dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString)
                    .Item("CanhBaoTranhChapKhieuKien", i).Value = dtTimKiem.Rows(i).Item("CanhBaoTranhChapKhieuKien").ToString
                End With
            Next i 
        End If
    End Sub

    Public Function TongHopChu(ByVal strMaHoSoCapGCN As String) As String


        Dim strTongHop As String = ""
        Dim TimKiem As New clsTimKiemHoSo
        Dim dt As New DataTable

        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            'Mã đơn vị hành chính
            .MaHoSoCapGCN = strMaHoSoCapGCN
        End With
        Try
            'Goi phuong thuc GetData de khoi tao doi tuong clsTimKiem
            dt = TimKiem.SelectTongHopChu()
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    strTongHop = strTongHop & dt.Rows(i).Item("QuanHe") & ": " & dt.Rows(i).Item("HoTen") & ", "
                Next
                strTongHop = strTongHop.Substring(0, strTongHop.Length - 2)
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return strTongHop
    End Function

    Public Function TongHopChuChuyenNhuong(ByVal strMaHoSoCapGCN As String) As String


        Dim strTongHop As String = ""
        Dim TimKiem As New clsTimKiemHoSo
        Dim dt As New DataTable

        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            'Mã đơn vị hành chính
            .MaHoSoCapGCN = strMaHoSoCapGCN
        End With
        Try
            'Goi phuong thuc GetData de khoi tao doi tuong clsTimKiem
            dt = TimKiem.SelectTongHopChuChuyenNhuong()
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    strTongHop = strTongHop & dt.Rows(i).Item(0) & ", "
                Next
                strTongHop = strTongHop.Substring(0, strTongHop.Length - 2)
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return strTongHop
    End Function

    Public Sub timChuSuDung()
        '---------------------Thong tin tim kiem Tong the------------------------'
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New clsTimKiemHoSo
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            .strMaHoSoCapGCN = ""
            .strMaThuaDat = ""
            With .grdvwTacNghiep
                .RowCount = 0
                .ClearSelection()
            End With
            With .grdvwTimKiem
                .RowCount = 0
                .ClearSelection()
            End With
        End With
        'Kiem tra xem da chon don vi hanh chinh can tac nghiep chua
        If (strMaDonViHanhChinh.Trim = "") Or (strMaDonViHanhChinh = "0") Then
            MsgBox("Bạn chưa chọn đơn vị hành chính!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDonViHanhChinh = ToiUuXau(Me.strMaDonViHanhChinh)
            'Mã đơn vị hành chính
            Dim strDVHC As String = ""
            Dim dtDVHC As New DataTable
            dtDVHC = TimKiem.SelectMaXa()
            strDVHC = dtDVHC.Rows(0).Item("MaXa")
            If isChonBanDo = "1" Then
                .MaDonViHanhChinh = ToiUuXau(Me.strMaDonViHanhChinh)
            Else
                .MaDonViHanhChinh = ToiUuXau(strDVHC)
            End If

            .IsBienDong = ischeckbiendong
            .IsBanDo = isChonBanDo
            .TenChuSuDung = ToiUuXau(txtTenChu.Text.Trim)
            .SoDinhDanh = ToiUuXau(txtDinhDanh.Text.Trim)

        End With
        Try
            dtTimKiem = TimKiem.SelectChu()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If
            If dtTimKiem.Rows.Count > 0 Then
                'Trình bày dữ liệu lên Form
                LoadGrid(dtTimKiem)
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Private Sub cmdTimChuSuDung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimChuSuDung.Click
        timChuSuDung()
    End Sub

    Private Sub cmdTimHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimHoSo.Click
        TimHoSo()
    End Sub

    Public Sub TimHoSo()
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New clsTimKiemHoSo
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            .strMaHoSoCapGCN = ""
            .strMaThuaDat = ""
            With .grdvwTacNghiep
                .RowCount = 0
                .ClearSelection()
            End With
            With .grdvwTimKiem
                .RowCount = 0
                .ClearSelection()
            End With
        End With
        'Kiem tra xem da chon don vi hanh chinh can tac nghiep chua
        If (strMaDonViHanhChinh.Trim = "") Or (strMaDonViHanhChinh = "0") Then
            MsgBox("Bạn chưa chọn đơn vị hành chính!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDonViHanhChinh = ToiUuXau(Me.strMaDonViHanhChinh)
            'Mã đơn vị hành chính
            Dim strDVHC As String = ""
            Dim dtDVHC As New DataTable
            dtDVHC = TimKiem.SelectMaXa()
            strDVHC = dtDVHC.Rows(0).Item("MaXa")
            If isChonBanDo = "1" Then
                .MaDonViHanhChinh = ToiUuXau(Me.strMaDonViHanhChinh)
            Else
                .MaDonViHanhChinh = ToiUuXau(strDVHC)
            End If
            .IsBanDo = isChonBanDo
            If Not IsDBNull(cmbTrangThaiHoSo.DataSource) Then
                .TrangThaiHoSoCapGCN = cmbTrangThaiHoSo.SelectedValue.ToString()
            Else
                .TrangThaiHoSoCapGCN = 0
            End If
            If cboNguonCapHoSo.Items.Count > 0 Then
                .MaNguonGocHoSo = cboNguonCapHoSo.SelectedValue
            End If

            If chkKetHop.Checked Then
                .KetHopDK = "1"
            Else
                .KetHopDK = "0"
            End If
            'If Me.cmbTrangThaiHoSo.Text = "Thửa đã cấp GCN" Then
            '    .TrangThaiHoSoCapGCN = "7"
            'ElseIf Me.cmbTrangThaiHoSo.Text = "Phê duyệt" Then
            '    .TrangThaiHoSoCapGCN = "4"
            'ElseIf Me.cmbTrangThaiHoSo.Text = "Thẩm định" Then
            '    .TrangThaiHoSoCapGCN = "3"
            'ElseIf Me.cmbTrangThaiHoSo.Text = "Hồ sơ kê khai" Then
            '    .TrangThaiHoSoCapGCN = "1"
            'ElseIf Me.cmbTrangThaiHoSo.Text = "Các thửa mới tạo" Then
            '    .TrangThaiHoSoCapGCN = "0"
            'ElseIf Me.cmbTrangThaiHoSo.Text = "Thửa không đủ điều kiện" Then
            '    .TrangThaiHoSoCapGCN = "5"
            'ElseIf Me.cmbTrangThaiHoSo.Text = "Thửa chưa đủ điều kiện" Then
            '    .TrangThaiHoSoCapGCN = "6"
            'ElseIf Me.cmbTrangThaiHoSo.Text = "Thửa đã biến động" Then
            '    .TrangThaiHoSoCapGCN = "8"
            'ElseIf Me.cmbTrangThaiHoSo.Text = "Xét duyệt cấp phường" Then
            '    .TrangThaiHoSoCapGCN = "2"
            'Else
            '    .HoanTatCapGCN = ""
            'End If
            .SoHoSo = ToiUuXau(txtHoSoTiepNhanSo.Text.Trim)
            .SoThuTuHoSo = ToiUuXau(txtSoThuTuTiepNhan.Text.Trim)
        End With
        Try
            dtTimKiem = TimKiem.SelectHoSo()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If
            If dtTimKiem.Rows.Count > 0 Then
                'Trình bày dữ liệu lên Form
                LoadGrid(dtTimKiem)
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Private Sub TabControl1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown
        If e.KeyValue = Keys.Enter Then
            If TabControl1.TabPages.Item(0).Focus Then
                timChuSuDung()
            End If
            If TabControl1.TabPages.Item(1).Focus Then
                TimThua()
            End If
            If TabControl1.TabPages.Item(2).Focus Then
                TimHoSo()
            End If
            If TabControl1.TabPages.Item(3).Focus Then
                TimCapGCN()
            End If
        End If
    End Sub

    Public Function ToiUuXau(ByVal str As String) As String
        str = str.Replace("[", "[[]")
        str = str.Replace("%", "[%]")
        str = str.Replace("'", "''")
        Return str
    End Function

    Private Sub chkChonBanDo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChonBanDo.CheckedChanged
        If chkChonBanDo.Checked Then
            isChonBanDo = "1"
            chkChonBanDo.Text = "Đã có bản đồ hành chính"
        Else
            isChonBanDo = "0"
            chkChonBanDo.Text = "Chưa có bản đồ hành chính"
        End If
    End Sub

    Private Sub grdvwTimKiem_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdvwTimKiem.CellDoubleClick


        If (e.RowIndex <> -1) Then
            If (grdvwTimKiem.Rows(0).Cells("MaThuaDat").Value <> "") Then
                Dim frm As New frmHinhDangThua
                frm.CtrHinhDangThua1.Connection = strConnection
                frm.CtrHinhDangThua1.MaThuaDat = grdvwTimKiem.Rows(e.RowIndex).Cells("MaThuaDat").Value
                frm.CtrHinhDangThua1.MaDonViHanhChinh = strMaDonViHanhChinh
                frm.CtrHinhDangThua1.TenBangBanDo = strTenBangBanDo
                frm.CtrHinhDangThua1.ctrHinhDangThua_Load()
                frm.ShowDialog()
            End If
        End If
    End Sub
    Public Sub LoadTrangThai()
        Dim cls As New clsTimKiemHoSo
        With cls
            .Connection = strConnection
            Dim dt As New DataTable
            dt = .SelectTuDienTrangThai
            If dt.Rows.Count > 0 Then
                cmbTrangThaiHoSo.DataSource = dt
                cmbTrangThaiHoSo.DisplayMember = "MoTa"
                cmbTrangThaiHoSo.ValueMember = "GiaTri"
            End If
        End With
    End Sub

    Private Sub cmbTrangThaiHoSo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTrangThaiHoSo.SelectedIndexChanged

    End Sub

    Private Sub chkKetHop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKetHop.CheckedChanged
        If chkKetHop.Checked Then
            chkKetHop.Text = "Tách điều kiện nguồn hồ sơ"
        Else
            chkKetHop.Text = "Kết hợp điều kiện nguồn hồ sơ"
        End If
    End Sub
 
    Private Sub checkbiendong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkbiendong.CheckedChanged
        If checkbiendong.Checked Then
            ischeckbiendong = "1"
            checkbiendong.Text = "Đã có biến động"
        Else
            ischeckbiendong = "0"
            checkbiendong.Text = "Chưa có biến động"
        End If
    End Sub
End Class
