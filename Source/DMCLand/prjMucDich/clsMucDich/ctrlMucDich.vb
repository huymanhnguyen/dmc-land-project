'DATE MODIFIED: 200812
'CODER: Vũ Lê Thành
'AIM:
'NOTE:
Option Explicit On
Imports System.Drawing
Imports System.Windows.Forms
Public Class ctrlMucDich
    'Khai báo biến Mã Hồ sơ cấp GCN
    Private strMaThuaDatCapGCN As String = ""
    'Khai báo biến Mục đích sử dụng đất
    Private dtMucDich As New DataTable
    Private blnNonNumberEntered As Boolean
    Private strConnection As String ' Khai báo biến nhận chuỗi kết nối cơ sở dữ liệu
    Private strError As String = ""    'Khai báo biến kiểm tra kết nối
    Private strMaMucDich As String = "" 'Khai báo biến Mã mục đích sử dụng
    Private shortAction As Short = 0     'Khai báo biến trạng thái cập nhật
    'Trạng thái tổng hợp Mục đích sử dụng
    Private blnTrangThaiTongHop As Boolean = False
    'Khai báo thuộc tính chỉ đọc ứng với biến trạng thái tổng hợp
    Private strThongTinChuCu As String = ""
    Private strDienTichKeKhai As Double = 0
    Public Property DienTichKeKhai() As String
        Get
            Return strDienTichKeKhai
        End Get
        Set(ByVal value As String)
            strDienTichKeKhai = value
        End Set
    End Property

    Public ReadOnly Property TrangThaiTongHop() As Boolean
        Get
            Return blnTrangThaiTongHop
        End Get
    End Property

    Private strMaHoSoCapGCN As String
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
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
    'Tổng hợp thông tin Mục đích sử dụng ghi trên GCN
    Private strTongHopThongTinMucDich As String = ""
    Private strTongHopThongTinThoiMucDich As String = ""
    Public ReadOnly Property TongHopThongTinMucDich() As String
        Get
            Return strTongHopThongTinMucDich
        End Get
    End Property
    Public ReadOnly Property TongHopThongTinThoiHanMucDich() As String
        Get
            Return strTongHopThongTinThoiMucDich
        End Get
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính Mã thửa đất cấp GCN
    Public WriteOnly Property MaThuaDatCapGCN() As String
        Set(ByVal value As String)
            strMaThuaDatCapGCN = value
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

    'Add các cột cần thiết cho Grid mục đích sử dụng đất
    Public Sub FormatGridContruction()
        Try
            With Me.grdvwMucDich
                'Ẩn tất cả các cột trên Grid
                Me.HideAllColumns(grdvwMucDich)
                'Thiết đặt các giá trị cần thiết cho cột Mã mục đích sử dụng đất
                With .Columns("KyHieu")
                    .HeaderText = "Mã mục đích"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("KyHieuKiemKe")
                    .HeaderText = "Mã kiểm kê"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("KyHieuQuiHoach")
                    .HeaderText = "Mã qui hoạch"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("ChiTiet")
                    .HeaderText = "Chi tiết"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Diện tích kê khai
                With .Columns("DienTichKeKhai")
                    .HeaderText = "Diện tích kê khai"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Diện tích Riêng
                With .Columns("DienTichRieng")
                    .HeaderText = "Diện tích Riêng"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Diện tích Chung
                With .Columns("DienTichChung")
                    .HeaderText = "Diện tích Chung"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Thời hạn
                With .Columns("ThoiHan")
                    .HeaderText = "Thời hạn"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ghi chú
                With .Columns("GhiChu")
                    .HeaderText = "Ghi chú"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Không cho phép thêm
                .AllowUserToAddRows = False
                'Không cho phép xóa
                .AllowUserToDeleteRows = False
                'Không cho lựa chọn bất kỳ bản ghi nào lúc ban đầu
                .ClearSelection()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Mục đích sử dụng" + vbNewLine + " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        'Bỏ lựa chọn trên Grid
        Me.grdvwMucDich.ClearSelection()
        strMaMucDich = ""
        shortAction = 1
        'Thiết lập giá trị mặc định lúc thêm mới
        Me.txtThoiHan.Text = "Lâu dài"
        With Me
            'Thiết lập trạng thái ban đầu
            .TrangThaiBanDau()
            'Trạng thái cập nhật
            .TrangThaiCapNhat(True)
            'Trạng thái chức năng
            .TrangThaiChucNang(True)

            If grdvwMucDich.RowCount > 0 Then
                Dim dientich As Double = 0
                For i As Integer = 0 To grdvwMucDich.RowCount - 1
                    dientich = dientich + grdvwMucDich.Rows(i).Cells("DienTichKeKhai").Value
                Next
                numDienTichKeKhai.Value = Convert.ToDouble(strDienTichKeKhai) - dientich
                numDienTichRieng.Value = Convert.ToDouble(strDienTichKeKhai) - dientich
                numDienTichChung.Value = 0
            End If
        End With
    End Sub
    Public Sub ShowData()
        'Khai báo và khởi tạo lớp Mục đích sử dụng
        Dim MucDich As New clsMucDich
        Try
            With MucDich
                'Gán chuỗi kết nối cơ sở dữ liệu
                .Connection = strConnection
                .MaThuaDatCapGCN = strMaThuaDatCapGCN
                .MaDonViHanhChinh = strMaDonViHanhChinh
            End With
            dtMucDich.Clear()
            With Me.grdvwMucDich
                .ClearSelection()
                If MucDich.GetData(dtMucDich) = "" Then
                    'Trình bày dữ liệu lên Grid Mục đích sử dụng
                    .DataSource = dtMucDich
                    If dtMucDich.Rows.Count > 0 Then
                        'Định dạng lại các cột trên Grid
                        Me.FormatGridContruction()
                    Else
                        'Ẩn tất cả các cột
                        Me.HideAllColumns(grdvwMucDich)
                    End If
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu: " & vbNewLine & " Mục đích sử dụng " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
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
        'Khai báo và khởi tạo lớp Mục đich sử dụng
        Dim MucDich As New clsMucDich
        Try
            With MucDich
                .Connection = strConnection 'Gán chuỗi kết nối cơ sở dữ liệu
                .MaThuaDatCapGCN = strMaThuaDatCapGCN
                .MaMucDichSuDung = strMaMucDich
                .DienTichKeKhai = numDienTichKeKhai.Text.Trim
                .DienTichRieng = numDienTichRieng.Text.Trim
                .DienTichChung = numDienTichChung.Text.Trim
                .KyHieuKiemKe = txtMaKiemKe.Text.Trim
                .KyHieuQuiHoach = txtMaQuiHoach.Text.Trim
                .ChiTiet = txtChiTiet.Text.Trim
                .MaDonViHanhChinh = strMaDonViHanhChinh
            End With
            If txtMaMucDich.Text.Trim <> "" Then
                MucDich.KyHieu = txtMaMucDich.Text.Trim
            Else
                If (shortAction = 1) Or (shortAction = 2) Then
                    MsgBox("Bạn phải nhập Mã mục đích sử dụng đất", MsgBoxStyle.Information, "DMCLand")
                    Exit Sub
                Else
                    MucDich.KyHieu = ""
                End If
            End If
            MucDich.ThoiHan = txtThoiHan.Text.Trim
            MucDich.GhiChu = txtGhiChu.Text.Trim
            Dim str As String = ""
            '  strThongTinChuCu = MucDich.KyHieu & " _ " & MucDich.DienTichKeKhai & "_" & MucDich.ThoiHan
            If shortAction = 1 Then
                MucDich.InsertMucDich(str)
                NhatKyNguoiDung("Thêm", MucDich.KyHieu & " _ " & MucDich.DienTichKeKhai & "_" & MucDich.ThoiHan)
            ElseIf shortAction = 2 Then
                MucDich.UpdateMucDich(str)
                NhatKyNguoiDung("Sửa", "Thay (" & strThongTinChuCu & ") Bằng (" & MucDich.KyHieu & " _ " & MucDich.DienTichKeKhai & "_" & MucDich.ThoiHan & ")")
            ElseIf shortAction = 3 Then
                MucDich.DeleteMucDichByMaMucDichSuDung(str)
                NhatKyNguoiDung("Xóa", MucDich.KyHieu & " _ " & MucDich.DienTichKeKhai & "_" & MucDich.ThoiHan)
            End If
            strError = MucDich.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Mục đích sử dụng đất " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        TrangThaiBanDau()
        shortAction = 0
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .grdvwMucDich.BackgroundColor = Color.White
            'Diện tích kê khai
            With .numDienTichKeKhai
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            'Diện tích Riêng
            With .numDienTichRieng
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            'Diện tích Chung
            With .numDienTichChung
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            .txtGhiChu.ReadOnly = Not blnCapNhat
            .txtMaMucDich.ReadOnly = Not blnCapNhat
            .txtThoiHan.ReadOnly = Not blnCapNhat

            .txtChiTiet.ReadOnly = Not blnCapNhat
            .txtMaKiemKe.ReadOnly = Not blnCapNhat
            .txtMaQuiHoach.ReadOnly = Not blnCapNhat
            'Mã Mục đích sử dụng
            .btnMaMucDich.Enabled = blnCapNhat
            'Mã kiểm kê
            .btnMaKiemKe.Enabled = blnCapNhat
            'Mã qui hoạch
            .btnMaQuiHoach.Enabled = blnCapNhat
            If blnCapNhat Then
                .numDienTichKeKhai.BackColor = Color.White
                .numDienTichRieng.BackColor = Color.White
                .numDienTichChung.BackColor = Color.White
                .txtGhiChu.BackColor = Color.White
                txtThoiHan.BackColor = Color.White
                .txtMaMucDich.BackColor = Color.White
                .txtChiTiet.BackColor = Color.White
                .txtMaKiemKe.BackColor = Color.White
                .txtMaQuiHoach.BackColor = Color.White
            Else
                .numDienTichKeKhai.BackColor = Color.LightYellow
                .numDienTichRieng.BackColor = Color.LightYellow
                .numDienTichChung.BackColor = Color.LightYellow
                .txtGhiChu.BackColor = Color.LightYellow
                .txtMaMucDich.BackColor = Color.LightYellow
                .txtThoiHan.BackColor = Color.LightYellow
                .txtChiTiet.BackColor = Color.LightYellow
                .txtMaKiemKe.BackColor = Color.LightYellow
                .txtMaQuiHoach.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            If (blnClearGrid) Then
                .HideAllColumns(grdvwMucDich)
            End If
            'Thiết lập trên Form nhập liệu
            .numDienTichKeKhai.Text = strDienTichKeKhai.ToString
            .numDienTichRieng.Text = strDienTichKeKhai.ToString
            .numDienTichChung.Text = "0"
            .txtGhiChu.Text = ""
            .txtMaMucDich.Text = ""
            .txtThoiHan.Text = ""
            .txtChiTiet.Text = ""
            .txtMaKiemKe.Text = ""
            .txtMaQuiHoach.Text = ""
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            .btnSua.Enabled = Not blnStartEdited
            .btnXoa.Enabled = Not blnStartEdited
            .btnThem.Enabled = Not blnStartEdited
            .btnCapNhat.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnCapNhat.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
            End If
        End With
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaMucDich <> "" Then
            shortAction = 2
            'Thiết lập trạng thái chức năng
            TrangThaiChucNang(True)
            'Thiết lập trạng thái cập nhật
            TrangThaiCapNhat(True)
        Else
            MsgBox(" Bạn chưa chọn Mục đích cần sửa!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Xác nhật hành động thực thi dữ liệu là: Xóa
        shortAction = 3
        If strMaMucDich <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        .UpdateData()
                        strMaMucDich = ""
                        'Hiển thị dữ liệu
                        .ShowData()
                    End With
                Catch ex As Exception
                    strError = ex.Message
                End Try
                If (strError = "") Or (strError = "OK") Then
                    MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                Else
                    MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                End If
            End If
        Else
            MsgBox(" Bạn chưa chọn Mục đích cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        'Trạng thái ban đầu
        Me.TrangThaiBanDau()
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
        strError = ""
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        'Kiểm tra dữ liệu nhập vào
        If txtMaMucDich.Text.Trim = "" Then
            MsgBox("Bạn phải nhập Mã mục đích sử dụng!", MsgBoxStyle.Information, "DMCLand")
            txtMaMucDich.Focus()
            Exit Sub
        End If
        Try
            With Me
                'Cập nhật thông tin Mục đích sử dụng
                .UpdateData()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Mục đích sử dụng " & vbNewLine _
                & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        ShowData()
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
        'Khởi tạo giá trị cho biến dùng chung
        strMaMucDich = ""
        strError = ""
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            .ShowData()
            'Xóa dữ liệu trên Form
            .TrangThaiBanDau()
            'Khởi tạo giá trị cho biến dùng chung
            strMaMucDich = ""
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub

    'Private Sub grdvwMucDich_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
    'Try
    'With Me.grdvwMucDich.Columns(e.ColumnIndex)
    '    If .Name = "NgayBatDau" Then
    '        If e.Value IsNot Nothing Then
    '            e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
    '        End If
    '    End If
    '    If .Name = "NgayKetThuc" Then
    '        If e.Value IsNot Nothing Then
    '            e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
    '        End If
    '    End If
    'End With
    ' Catch ex As Exception
    '     strError = ex.Message
    '     MsgBox(" Định dạng ngày tháng " & vbNewLine & " Mục đích sử dụng đất " & vbNewLine _
    '& " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
    ' End Try
    'End Sub

    Private Sub grdvwMucDich_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwMucDich.CellMouseClick
        'Chỉ thực thi khi người dùng Click chuột Trái
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khai báo và khởi tạo lớp Mục đích sử dụng đất
        Dim MucDich As New clsMucDich
        If e.RowIndex >= 0 Then
            Try
                MucDich.Connection = strConnection 'Gán chuỗi kết nối cơ sở dữ liệu
                MucDich.MaDonViHanhChinh = strMaDonViHanhChinh
                With dtMucDich.Rows(e.RowIndex)
                    MucDich.DienTichKeKhai = .Item("DienTichKeKhai").ToString
                    MucDich.DienTichRieng = .Item("DienTichRieng").ToString
                    MucDich.DienTichChung = .Item("DienTichChung").ToString
                    MucDich.GhiChu = .Item("GhiChu").ToString
                    MucDich.KyHieu = .Item("KyHieu").ToString
                    MucDich.ThoiHan = .Item("ThoiHan").ToString
                    MucDich.MaMucDichSuDung = .Item("MaMucDichSuDung").ToString
                    strMaMucDich = MucDich.MaMucDichSuDung
                    MucDich.MaThuaDatCapGCN = .Item("MaThuaDatCapGCN").ToString
                    MucDich.ChiTiet = .Item("ChiTiet").ToString
                    MucDich.KyHieuKiemKe = .Item("KyHieuKiemKe").ToString
                    MucDich.KyHieuQuiHoach = .Item("KyHieuQuiHoach").ToString
                End With
                'Hiển thị bản ghi được lựa chon lên Form
                With Me
                    .txtChiTiet.Text = MucDich.ChiTiet
                    .txtMaKiemKe.Text = MucDich.KyHieuKiemKe
                    .txtMaQuiHoach.Text = MucDich.KyHieuQuiHoach
                    'Diên tích kê khai
                    If IsNumeric(MucDich.DienTichKeKhai) Then
                        .numDienTichKeKhai.Text = MucDich.DienTichKeKhai
                    Else
                        .numDienTichKeKhai.Text = ""
                    End If
                    'Diên tích Riêng
                    If IsNumeric(MucDich.DienTichRieng) Then
                        .numDienTichRieng.Text = MucDich.DienTichRieng
                    Else
                        .numDienTichRieng.Text = ""
                    End If
                    'Diên tích Chung
                    If IsNumeric(MucDich.DienTichChung) Then
                        .numDienTichChung.Text = MucDich.DienTichChung
                    Else
                        .numDienTichChung.Text = ""
                    End If
                    .txtGhiChu.Text = MucDich.GhiChu
                    .txtMaMucDich.Text = MucDich.KyHieu
                    .txtThoiHan.Text = MucDich.ThoiHan
                End With
                strThongTinChuCu = MucDich.KyHieu & " _ " & MucDich.DienTichKeKhai & "_" & MucDich.ThoiHan
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Mục đích sử dụng" _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub ctrlMucDich_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Mặc định là không tổng hợp Mục đích sử dụng
        blnTrangThaiTongHop = False
        Try
            With Me
                'Thiết lập trạng thái ban đầu
                .TrangThaiBanDau()
                'Thiết lập trạng thái cập nhật
                .TrangThaiCapNhat()
                'Thiết lập trạng thái chức năng
                .TrangThaiChucNang()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Mục đích sử dụng " _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub numDienTichRieng_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDienTichRieng.ValueChanged
        'If (numDienTichRieng.Value > numDienTichKeKhai.Value) Then
        '    System.Windows.Forms.MessageBox.Show("Diện tích Riêng phải nhỏ hơn hoặc bằng diện tích thửa đất", "DMCLand", MessageBoxButtons.OK)
        '    numDienTichRieng.Value = 0.0
        '    numDienTichRieng.Text = "0.0"
        '    numDienTichRieng.Focus()
        '    Return
        'End If
        Dim dblDienTichChung As Decimal
        Dim dblDienTichDat As New Decimal
        Dim dblDienTichRieng As New Decimal
        'If (numDienTichChung.Text <> "") Then
        '    If (numDienTichChung.Text = "0.0") Then
        '        dblDienTichChung = numDienTichKeKhai.Value - numDienTichRieng.Value
        '    Else
        '        Return
        '    End If
        'Else
        dblDienTichChung = numDienTichKeKhai.Value - numDienTichRieng.Value
        'End If
        numDienTichChung.Text = dblDienTichChung
    End Sub

    Private Sub btnMaMucDich_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaMucDich.Click
        If Not txtMaMucDich.ReadOnly Then
            Try
                Dim frm As New frmBangMa
                With frm
                    With .CtrlBangMa
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = strConnection
                    End With
                    .ShowDialog()
                    With .CtrlBangMa
                        If .KyHieu <> "" Then
                            txtMaMucDich.Text = .KyHieu
                            .KyHieu = ""
                        End If
                    End With
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị bảng mã " & vbNewLine & " Mục đích sử dụng đất " & vbNewLine _
                       & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub btnMaKiemKe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaKiemKe.Click
        If Not txtMaMucDich.ReadOnly Then
            Try
                Dim frm As New frmBangMa
                With frm
                    With .CtrlBangMa
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = strConnection
                    End With
                    .ShowDialog()
                    With .CtrlBangMa
                        If .KyHieu <> "" Then
                            txtMaKiemKe.Text = .KyHieu
                            .KyHieu = ""
                        End If
                    End With
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị bảng mã " & vbNewLine & " Kiểm kê sử dụng đất " & vbNewLine _
                       & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub btnMaQuiHoach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaQuiHoach.Click
        If Not txtMaMucDich.ReadOnly Then
            Try
                Dim frm As New frmBangMa
                With frm
                    With .CtrlBangMa
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = strConnection
                    End With
                    .ShowDialog()
                    With .CtrlBangMa
                        If .KyHieu <> "" Then
                            txtMaQuiHoach.Text = .KyHieu
                            .KyHieu = ""
                        End If
                    End With
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị bảng mã " & vbNewLine & " Qui hoạch sử dụng đất " & vbNewLine _
                       & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub chkTongHopMucDich_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTongHopMucDich.CheckedChanged
        strTongHopThongTinMucDich = ""
        strTongHopThongTinThoiMucDich = ""
        If Me.chkTongHopMucDich.Checked Then
            blnTrangThaiTongHop = True
            'Chắc chắn rằng tồn tại Mục đích sử dụng đất
            If dtMucDich IsNot Nothing Then
                'Chắc chắn rằng tồn tại ít nhất một mục đich sử dụng
                If dtMucDich.Rows.Count > 0 Then
                    'Trường hợp chỉ có một Mục đích sử dụng thì không cần Diện tích đính kèm
                    If dtMucDich.Rows.Count = 1 Then
                        strTongHopThongTinMucDich = dtMucDich.Rows(0).Item("MoTa").ToString
                        strTongHopThongTinThoiMucDich = dtMucDich.Rows(0).Item("ThoiHan").ToString
                        Return
                    End If
                    'Tổng hợp nội dung thông tin Mục đích sử dụng
                    For i As Int32 = 0 To dtMucDich.Rows.Count - 1
                        If dtMucDich.Rows(i).Item("MoTa").ToString <> "" Then
                            'Trường hợp đã có một mục đích rồi thì ta thêm dâu "," để ngăn cách 2 mục đích
                            If strTongHopThongTinMucDich <> "" Then
                                strTongHopThongTinMucDich += ", "
                            End If
                            strTongHopThongTinMucDich += dtMucDich.Rows(i).Item("MoTa").ToString
                            If dtMucDich.Rows(i).Item("DienTichKeKhai").ToString <> "" Then
                                strTongHopThongTinMucDich += " " + dtMucDich.Rows(i).Item("DienTichKeKhai").ToString + "m2"
                            End If
                        End If
                        If dtMucDich.Rows(i).Item("ThoiHan").ToString <> "" Then
                            'Trường hợp đã có một mục đích rồi thì ta thêm dâu "," để ngăn cách 2 mục đích
                            If strTongHopThongTinThoiMucDich <> "" Then
                                strTongHopThongTinThoiMucDich += ", "
                            End If
                            strTongHopThongTinThoiMucDich += dtMucDich.Rows(i).Item("ThoiHan").ToString
                            If dtMucDich.Rows(i).Item("DienTichKeKhai").ToString <> "" Then
                                strTongHopThongTinThoiMucDich += " " + dtMucDich.Rows(i).Item("DienTichKeKhai").ToString + "m2"
                            End If
                        End If
                    Next
                Else
                    Return
                End If
            Else
                Return
            End If
        Else
            blnTrangThaiTongHop = False
        End If
    End Sub

    Private Sub txtMaMucDich_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaMucDich.KeyDown
        If (e.KeyValue = 13) Then
            txtMaKiemKe.Focus()
        End If
    End Sub

    Private Sub txtMaKiemKe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaKiemKe.KeyDown
        If (e.KeyValue = 13) Then
            txtMaQuiHoach.Focus()
        End If
    End Sub

    Private Sub txtMaQuiHoach_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaQuiHoach.KeyDown
        If (e.KeyValue = 13) Then
            txtChiTiet.Focus()
        End If
    End Sub

    Private Sub txtChiTiet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChiTiet.KeyDown
        If (e.KeyValue = 13) Then
            numDienTichKeKhai.Focus()
        End If
    End Sub

    Private Sub numDienTichKeKhai_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDienTichKeKhai.KeyDown
        If (e.KeyValue = 13) Then
            numDienTichRieng.Focus()
        End If
    End Sub

    Private Sub numDienTichRieng_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDienTichRieng.KeyDown
        If (e.KeyValue = 13) Then
            numDienTichChung.Focus()
        End If
    End Sub

    Private Sub numDienTichChung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDienTichChung.KeyDown
        If (e.KeyValue = 13) Then
            txtThoiHan.Focus()
        End If
    End Sub

    Private Sub txtThoiHan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtThoiHan.KeyDown
        If (e.KeyValue = 13) Then
            txtGhiChu.Focus()
        End If
    End Sub

    Private Sub txtGhiChu_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGhiChu.KeyDown
        If (e.KeyValue = 13) Then
            btnCapNhat.Focus()
        End If
    End Sub
End Class
