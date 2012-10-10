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
    Private isChonBanDo As String ' = 1 nghia la da co ban do hanh chinh, 0 la chua co
    'Khai báo thuộc tính chuỗi kết nối Database
    Private strMaLoaiHS As String
    Public Property MaLoaiHS() As String
        Get
            Return strMaLoaiHS
        End Get
        Set(ByVal value As String)
            strMaLoaiHS = value
        End Set
    End Property
    Private strDanhSachHoSoChon As String = ""

    Public Property DanhSachHoSoChon() As String
        Get
            Return strDanhSachHoSoChon
        End Get
        Set(ByVal value As String)
            strDanhSachHoSoChon = value
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
        Dim txtClnMaThuaDatTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnHoSoCapGCNTimKiem As New DataGridViewTextBoxColumn
        'Dim txtClnSoDinhDanhTimKiem As New DataGridViewTextBoxColumn
        Try
            'Tờ bản đồ
            With txtClnHoSoCapGCNTimKiem
                .HeaderText = "Tờ bản đồ"
                .Name = "MaHoSoCapGCN"
                .Width = 100
                .Visible = False
            End With
            With txtClnMaThuaDatTimKiem
                .HeaderText = ""
                .Name = "MaThuaDat"
                .Width = 0
                .Visible = False
            End With
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
                    .Add(txtClnMaThuaDatTimKiem)
                    .Add(txtClnHoSoCapGCNTimKiem)
                    '.Add(txtClnSoDinhDanhTimKiem)
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
        Dim txtClnMaThuaDatTacNghiep As New DataGridViewTextBoxColumn
        Dim txtClnHoSoCapGCNTacNghiep As New DataGridViewTextBoxColumn
        'Dim txtClnSoDinhDanhTacNghiep As New DataGridViewTextBoxColumn
        Try
            'Tờ bản đồ
            'Tờ bản đồ
            With txtClnHoSoCapGCNTacNghiep
                .HeaderText = "Tờ bản đồ"
                .Name = "MaHoSoCapGCN"
                .Width = 100
                .Visible = False
            End With
            With txtClnMaThuaDatTacNghiep
                .HeaderText = ""
                .Name = "MaThuaDat"
                .Width = 0
                .Visible = False
            End With
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
                    .Add(txtClnMaThuaDatTacNghiep)
                    .Add(txtClnHoSoCapGCNTacNghiep)
                    .Add(txtClnToBanDoTacNghiep)
                    .Add(txtClnSoThuaTacNghiep)
                    .Add(txtClnDienTichTacNghiep)
                    .Add(txtClnDiaChiThuaTacNghiep)
                    .Add(txtClnNgayLapToTrinhTacNghiep)
                    .Add(txtClnNgayQuyetDinhCapGCNTacNghiep)
                    .Add(txtClnHoTenTacNghiep)
                    '.Add(txtClnSoDinhDanhTacNghiep)
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
        ''Truong hop click chuot trai vao grid
        'If (e.Button.ToString = "Left") And (e.RowIndex >= 0) Then
        '    Me.grdvwTimKiem.ClearSelection()
        '    Exit Sub
        'End If
        ''Truong hop lua chon mot ban ghi
        'If (e.Button.ToString = "Right") And (e.RowIndex >= 0) Then

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
                strMaHoSoCapGCN = .Item("MaHoSoCapGCN").ToString
                'Hien thi ban ghi lua chon len Danh sach thua can tac nghiep

            End With
            'Trang thai chuc nang 
            blnCapNhat = False
        Catch ex As Exception
            strError = ex.Message
            MsgBox("Tìm kiếm: " & vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'End If
    End Sub

    Private Sub crtTimKiemHoSoThuaDat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me

            If (grdvwTimKiem.Columns.Count = 0) Then
                .AddColumnsTimKiem()

            End If
            If (grdvwTacNghiep.Columns.Count = 0) Then
                .AddColumnsTacNghiep()
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
                    .Item("MaHoSoCapGCN", i).Value = dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString
                    .Item("ToBanDoTimKiem", i).Value = dtTimKiem.Rows(i).Item("ToBanDo").ToString
                    .Item("SoThuaTimKiem", i).Value = dtTimKiem.Rows(i).Item("SoThua").ToString
                    .Item("DiaChiThuaTimKiem", i).Value = dtTimKiem.Rows(i).Item("DiaChi").ToString
                    .Item("DienTichTimKiem", i).Value = dtTimKiem.Rows(i).Item("DienTich").ToString
                    .Item("NgayLapToTrinhTimKiem", i).Value = dtTimKiem.Rows(i).Item("NgayLapToTrinh").ToString
                    .Item("NgayQuyetDinhCapGCNTimKiem", i).Value = dtTimKiem.Rows(i).Item("NgayQuyetDinhCapGCN").ToString
                    .Item("HoTenTimKiem", i).Value = TongHopChu(dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString)
                    .Item("MaThuaDat", i).Value = dtTimKiem.Rows(i).Item("MaThuaDat").ToString
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

    Private Sub cmdChonHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChonHoSo.Click
        strDanhSachHoSoChon = ""
        If grdvwTacNghiep.RowCount >= 0 Then
            For i As Integer = 0 To grdvwTacNghiep.RowCount - 1
                If grdvwTacNghiep.Rows(i).Cells("MaHoSoCapGCN").Value <> "" Then
                    strDanhSachHoSoChon = strDanhSachHoSoChon & grdvwTacNghiep.Rows(i).Cells("MaHoSoCapGCN").Value.ToString & ","
                End If
            Next
            If strDanhSachHoSoChon.Length > 0 Then
                strDanhSachHoSoChon = strDanhSachHoSoChon.Substring(0, strDanhSachHoSoChon.Length - 1)
            End If
            FindForm.Hide()
        End If
    End Sub

    Public Function CheckTonTaiMaThuaDat(ByVal MaThuaDat As String) As Boolean
        Dim kt As Boolean = True

        For i As Integer = 0 To grdvwTacNghiep.Rows.Count - 1
            If grdvwTacNghiep.Rows(i).Cells("MaThuaDat").Value.ToString.Trim = MaThuaDat.Trim Then
                kt = False
                Return kt
            End If
        Next
        Return kt
    End Function


    Public Function TenDonViHanhChinh() As String
        Dim DonViHanhChinh As New clsTimKiemHoSo
        'Khai báo biến kiểu DataTable
        Dim dtDonViHanhChinh As New DataTable
        'Khai báo biến kiểu String chứa Mã xã
        Dim strMaXa As String = ""
        Try
            If Not ((strMaThuaDat = "") Or (strMaThuaDat = 0)) Then
                DonViHanhChinh.MaThuaDat = strMaThuaDat
            Else
                MessageBox.Show("Bạn phải chọn thửa đất cần tạo Hồ sơ cấp GCN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return strDiaChiThua
            End If
            '-------------- Xác định Mã xã từ Mã đơn vị hành chính -----------------
            With DonViHanhChinh
                .Connection = strConnection
                .MaDonViHanhChinh = strMaDonViHanhChinh
                dtDonViHanhChinh.Clear()
                .SelectTuDienDonViHanhChinhByMaXa(dtDonViHanhChinh)
            End With
            'Xác nhận Mã xã tìm được
            strMaXa = dtDonViHanhChinh.Rows(0).Item("MaXa").ToString()
            'Lấy địa chỉ Mặc định
            strDiaChiThua = dtDonViHanhChinh.Rows(0).Item("Ten").ToString() & " - " + dtDonViHanhChinh.Rows(0).Item("TenQuan").ToString() + " - TP Hà Nội"
        Catch ex As Exception

        End Try
        Return strDiaChiThua
    End Function

    ''' <summary>
    ''' Cập nhật Hồ sơ cấp GCN đã có thông tin không gian thửa đất
    ''' vào bảng tblHoSoCapGCN
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateHoSoCapGCNDaCoThongTinKhongGianThuaDat(ByRef MaHoSo As String, ByVal tobando As String, ByVal sothua As String, ByVal dientich As String, ByVal mathuadat As String)
        'Khai báo và khởi tạo đối tượng
        Dim HoSoCapGCN As New clsTimKiemHoSo
        'Khai báo biến kiểu DataTable
        Dim dtDonViHanhChinh As New DataTable
        'Khai báo biến kiểu String chứa Mã xã
        Dim strMaXa As String = ""
        Try
            If Not ((mathuadat = "") Or (mathuadat = 0)) Then
                HoSoCapGCN.MaThuaDat = mathuadat
            Else
                MessageBox.Show("Bạn phải chọn thửa đất cần tạo Hồ sơ cấp GCN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-------------- Xác định Mã xã từ Mã đơn vị hành chính -----------------
            With HoSoCapGCN
                .Connection = strConnection
                .MaDonViHanhChinh = strMaDonViHanhChinh
                dtDonViHanhChinh.Clear()
                .SelectTuDienDonViHanhChinhByMaXa(dtDonViHanhChinh)
            End With
            'Xác nhận Mã xã tìm được
            strMaXa = dtDonViHanhChinh.Rows(0).Item("MaXa").ToString()
            'Lấy địa chỉ Mặc định
            strDiaChiThua = TenDonViHanhChinh()

            HoSoCapGCN.MaXa = strMaXa
            HoSoCapGCN.DiaChiThua = strDiaChiThua
            HoSoCapGCN.DienTichTuNhien = dientich
            HoSoCapGCN.SoThua = sothua
            HoSoCapGCN.ToBanDo = tobando
            HoSoCapGCN.MaDonViHanhChinh = strMaDonViHanhChinh
            Dim str As String = "", strError As String = ""
            HoSoCapGCN.Connection = strConnection
            'Thêm Hồ sơ cấp GCN mới cho Thửa đất
            strError = HoSoCapGCN.InsertHoSoCapGCNCoThongTinKhongGianThuaDat(str)
            '
            If strError = "" Then
                'Nhận Mã hồ sơ cấp GCN mới tạo ra
                MaHoSo = str
                MessageBox.Show("Thêm Hồ sơ cấp GCN mới THÀNH CÔNG!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Thêm Hồ sơ cấp GCN mới KHÔNG thành công", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            strError = HoSoCapGCN.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hồ sơ cấp GCN " & vbNewLine & " Cập nhật dữ liệu " & vbNewLine _
                   & "Lỗi ....! ", MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
  
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            If Not CheckTonTaiMaThuaDat(grdvwTimKiem.Rows(grdvwTimKiem.CurrentRow.Index).Cells("MaThuaDat").Value.ToString) Then
                MessageBox.Show("Đã được chọn !!", "DMCLand")
                Return
            End If




            With grdvwTimKiem.Rows(grdvwTimKiem.CurrentRow.Index)
                'Gan gia tri vao bien dung chung

                strMaThuaDat = ""
                strMaThuaDat = .Cells("MaThuaDat").Value.ToString
                strMaHoSoCapGCN = ""
                strMaHoSoCapGCN = .Cells("MaHoSoCapGCN").Value.ToString
                strToBanDo = .Cells("ToBanDoTimKiem").Value.ToString
                strSoThua = .Cells("SoThuaTimKiem").Value.ToString
                strDiaChiThua = .Cells("DiaChiThuaTimKiem").Value.ToString
                strDienTich = .Cells("DienTichTimKiem").Value.ToString
                strNgayLapToTrinh = .Cells("NgayLapToTrinhTimKiem").Value.ToString
                strNgayQuyetDinhCapGCN = .Cells("NgayQuyetDinhCapGCNTimKiem").Value.ToString
                If MaLoaiHS = 2 Then
                    If strMaHoSoCapGCN = "" Or strMaHoSoCapGCN = "0" Then
                        If MessageBox.Show("Tạo mới hồ sơ trước khi phân công việc !! ", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            UpdateHoSoCapGCNDaCoThongTinKhongGianThuaDat(strMaHoSoCapGCN, strToBanDo, strSoThua, strDienTich, strMaThuaDat)
                        Else
                            Return
                        End If
                    Else
                        MessageBox.Show("Hãy chọn những hồ sơ chưa được tạo", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                Else
                    If strMaHoSoCapGCN = "" Or strMaHoSoCapGCN = "0" Then
                        Return
                    End If
                End If
                    grdvwTacNghiep.Rows.Add(1)
                    Dim iTacNghiep As Integer = grdvwTacNghiep.Rows.Count - 1
                    'Hien thi ban ghi lua chon len Danh sach thua can tac nghiep
                    grdvwTacNghiep.Item("ToBanDoTacNghiep", iTacNghiep).Value = .Cells("ToBanDoTimKiem").Value.ToString
                    grdvwTacNghiep.Item("SoThuaTacNghiep", iTacNghiep).Value = .Cells("SoThuaTimKiem").Value.ToString
                    grdvwTacNghiep.Item("DiaChiThuaTacNghiep", iTacNghiep).Value = .Cells("DiaChiThuaTimKiem").Value.ToString
                    grdvwTacNghiep.Item("DienTichTacNghiep", iTacNghiep).Value = .Cells("DienTichTimKiem").Value.ToString
                    grdvwTacNghiep.Item("NgayLapToTrinhTacNghiep", iTacNghiep).Value = .Cells("NgayLapToTrinhTimKiem").Value.ToString
                    grdvwTacNghiep.Item("NgayQuyetDinhCapGCNTacNghiep", iTacNghiep).Value = .Cells("NgayQuyetDinhCapGCNTimKiem").Value.ToString
                    grdvwTacNghiep.Item("HoTenTacNghiep", iTacNghiep).Value = .Cells("HoTenTimKiem").Value.ToString
                    grdvwTacNghiep.Item("MaThuaDat", iTacNghiep).Value = .Cells("MaThuaDat").Value.ToString
                    grdvwTacNghiep.Item("MaHoSoCapGCN", iTacNghiep).Value = strMaHoSoCapGCN
            End With
            'Trang thai chuc nang 
            blnCapNhat = False
        Catch ex As Exception
            strError = ex.Message
            MsgBox("Tìm kiếm: " & vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        If grdvwTacNghiep.CurrentRow.Index >= 0 Then
            grdvwTacNghiep.Rows.RemoveAt(grdvwTacNghiep.CurrentRow.Index)
        End If
    End Sub
End Class
