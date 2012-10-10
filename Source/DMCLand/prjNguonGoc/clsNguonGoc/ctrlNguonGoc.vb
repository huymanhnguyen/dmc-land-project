Imports System.Windows.Forms
Imports System.Drawing
Public Class ctrlNguonGoc
    Private strMaThuaDatCapGCN As String = ""
    Private dtNguonGoc As New DataTable
    Private blnNonNumberEntered As Boolean
    Private strConnection As String ' Khai báo biến nhận chuỗi kết nối cơ sở dữ liệu
    Private strError As String = ""     'Khai bao bien kiem tra loi
    Private strMaNguonGoc As String = ""
    Private shortAction As Short = 0

    Private strMaHoSoCapGCN As String = ""
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
    'Trạng thái tổng hợp Nguồn gốc sử dụng
    Private blnTrangThaiTongHop As Boolean = False
    'Khai báo thuộc tính chỉ đọc ứng với biến trạng thái tổng hợp
    Public ReadOnly Property TrangThaiTongHop() As Boolean
        Get
            Return blnTrangThaiTongHop
        End Get
    End Property
    'Tổng hợp thông tin Nguồn gốc sử dụng ghi trên GCN
    Private strTongHopThongTin As String = ""
    Public ReadOnly Property TongHopThongTin() As String
        Get
            Return strTongHopThongTin
        End Get
    End Property

    'Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
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
    Public WriteOnly Property MaThuaDatCapGCN() As String
        Set(ByVal value As String)
            strMaThuaDatCapGCN = value
        End Set
    End Property

    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
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

    Public Sub FormatGridContruction()
        Try
            'Ẩn tất cả các cột
            Me.HideAllColumns(grdvwNguonGoc)
            With Me.grdvwNguonGoc
                'Mã mục đích
                With .Columns("KyHieu")
                    .HeaderText = "Mã nguồn gốc"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Diện tích
                With .Columns("DienTich")
                    .HeaderText = "Diện tích (m2)"
                    .Width = 130
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Chi tiết
                With .Columns("ChiTiet")
                    .HeaderText = "Chi tiết"
                    .Width = 200
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ghi chú
                With .Columns("GhiChu")
                    .HeaderText = "Ghi chú"
                    .Width = 450
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Khong cho phep them
                .AllowUserToAddRows = False
                'Khong cho phep xoa
                .AllowUserToDeleteRows = False
                'Khong lua chon bat ky dong nao luc ban dau
                .ClearSelection()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nguồn gốc sử dụng" & vbNewLine & "Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub ctrlNguonGoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                'Trạng thái cập nhật
                .TrangThaiCapNhat()
                'Trạng thái chức năng
                .TrangThaiChucNang()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " NGUỒN GỐC SỬ DỤNG " _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        strMaNguonGoc = ""
        shortAction = 1
        With Me
            'Thiết lập trạng thái ban đầu
            .TrangThaiBanDau()
            'Trạng thái cập nhật
            .TrangThaiCapNhat(True)
            'Trạng thái chức năng 
            .TrangThaiChucNang(True)
        End With
    End Sub
    Public Sub ShowData()
        'Khai bao va khoi tao doi tuong
        Dim NguonGoc As New clsNguonGoc
        'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
        Try
            NguonGoc.Connection = strConnection ' Gán chuỗi kết nối Database
            NguonGoc.MaThuaDatCapGCN = strMaThuaDatCapGCN
            dtNguonGoc.Clear()
            With Me.grdvwNguonGoc
                .ClearSelection()
                'Goi phuong thuc GetData de khoi tao doi tuong cls
                If NguonGoc.GetData(dtNguonGoc) = "" Then
                    ' Trình bày dữ liệu lên grdvwNguonGoc
                    .DataSource = dtNguonGoc
                    If dtNguonGoc.Rows.Count > 0 Then
                        'Định dạng lại các cột
                        Me.FormatGridContruction()
                    Else
                        'Ẩn tất cả các cột
                        Me.HideAllColumns(grdvwNguonGoc)
                    End If
                End If
            End With
            'Thiet dat trang thai ban dau
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " NGUỒN GỐC SỬ DỤNG " & vbNewLine _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Private Sub checkColumn(ByRef grdvw As DataGridView, ByVal intRowIndex As Int32, ByVal intColumnIndex As Int32)
        If (intRowIndex) < 0 Then
            Exit Sub
        End If
        If intColumnIndex = 0 Then
            If (grdvw.Rows(intRowIndex).Cells("Chon").Value.ToString = "") Then
                grdvw.Rows(intRowIndex).Cells("Chon").Value = "True"
            Else
                If (grdvw.Rows(intRowIndex).Cells("Chon").Value = True) Then
                    grdvw.Rows(intRowIndex).Cells("Chon").Value = "False"
                Else
                    grdvw.Rows(intRowIndex).Cells("Chon").Value = "True"
                End If
            End If
        End If
    End Sub
    Public Sub UpdateData()
        'Khai bao va khoi tao doi tuong clsNguonGoc
        Dim NguonGoc As New clsNguonGoc
        Try
            NguonGoc.Connection = strConnection ' Gán chuỗi kết nối Database
            NguonGoc.MaThuaDatCapGCN = strMaThuaDatCapGCN
            NguonGoc.MaNguonGoc = strMaNguonGoc
            NguonGoc.DienTich = numDienTich.Value
            If (txtMaNguonGoc.Text IsNot Nothing) Then
                NguonGoc.KyHieu = txtMaNguonGoc.Text.Trim
            Else
                If (shortAction = 1) Or (shortAction = 2) Then
                    MsgBox("Bạn phải nhập MÃ NGUỒN GỐC sử dụng đất", MsgBoxStyle.Information, "DMCLand")
                    Exit Sub
                Else
                    NguonGoc.KyHieu = ""
                End If
            End If
            'Chi tiết
            If (txtChiTiet.Text IsNot Nothing) Then
                NguonGoc.ChiTiet = txtChiTiet.Text.Trim
            Else
                NguonGoc.ChiTiet = ""
            End If
            'Ghi chú Nguồn gốc
            If (txtGhiChu.Text IsNot Nothing) Then
                NguonGoc.GhiChu = txtGhiChu.Text.Trim
            Else
                NguonGoc.GhiChu = ""
            End If
            Dim str As String = ""
            'Nếu cập nhật thành công
            If (shortAction = 1) Then
                NguonGoc.InsertNguonGocSuDungDat(str)
                'strThongTinChuCu = txtMaNguonGoc.Text & " _  " & NguonGoc.ChiTiet
                NhatKyNguoiDung("Thêm", txtMaNguonGoc.Text & " _  " & NguonGoc.ChiTiet)
            ElseIf (shortAction = 2) Then
                NguonGoc.UpdateNguonGocSuDungDat(str)
                NhatKyNguoiDung("Sửa", "Thay (" & txtMaNguonGoc.Text & " _  " & NguonGoc.ChiTiet & ") Bằng (" & strThongTinChuCu & ")")
            End If
            strError = NguonGoc.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Nguồn gốc sử dụng đất " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        TrangThaiBanDau()
        shortAction = 0
    End Sub
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Cập nhật nguồn gốc sử dụng"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        'Thiết đặt trạng thái các điều khiển theo trạng thái cập nhật dữ liệu
        With Me
            .grdvwNguonGoc.BackgroundColor = Color.White
            'Diện tích
            With .numDienTich
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            'Ghi chú
            .txtGhiChu.ReadOnly = Not blnCapNhat
            'Mã Nguồn gốc
            .txtMaNguonGoc.ReadOnly = Not blnCapNhat
            'Chi tiết
            .txtChiTiet.ReadOnly = Not blnCapNhat
            'Mã Nguồn gốc sử dụng
            .btnMaNguonGoc.Enabled = blnCapNhat
            'Thiết đặt màu nền cho các điều khiển
            If blnCapNhat Then
                'Diện tích
                .numDienTich.BackColor = Color.White
                'Ghi chú
                .txtGhiChu.BackColor = Color.White
                'Mã Nguồn gốc
                .txtMaNguonGoc.BackColor = Color.White
                'Chi tiết
                .txtChiTiet.BackColor = Color.White
            Else
                'Diện tích
                .numDienTich.BackColor = Color.LightYellow
                'Ghi chú
                .txtGhiChu.BackColor = Color.LightYellow
                'Mã nguồn gốc
                .txtMaNguonGoc.BackColor = Color.LightYellow
                'Chi tiết
                .txtChiTiet.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        'Thiết đặt trạng dữ liệu lên Form
        With Me
            If blnClearGrid Then
                'Ẩn tất cả các cột
                .HideAllColumns(grdvwNguonGoc)
            End If
            'Diện tích
            .numDienTich.Value = 0.0
            'Ghi chú
            .txtGhiChu.Text = ""
            'Mã ký hiệu Nguồn gốc
            .txtMaNguonGoc.Text = ""
            'Chi tiết
            .txtChiTiet.Text = ""
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
        If strMaNguonGoc <> "" Then
            shortAction = 2
            With Me
                'Trang thai chuc nang
                .TrangThaiChucNang(True)
                'Trang thai cap nhat
                .TrangThaiCapNhat(True)
            End With
        Else
            MsgBox(" Bạn phải chọn Nguồn gốc cần sửa thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Neu ton tai ma can xoa
        If strMaNguonGoc <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    Dim NguonGoc As New clsNguonGoc
                    Dim str As String = ""
                    NguonGoc.Connection = strConnection
                    NguonGoc.MaNguonGoc = strMaNguonGoc
                    NguonGoc.DeleteNguonGocSuDungDatByMaNguonGoc(str)
                    NhatKyNguoiDung("Xóa", txtMaNguonGoc.Text & " _  " & NguonGoc.ChiTiet)
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
            MsgBox(" Bạn phải chọn Nguồn gốc cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        With Me
            strMaNguonGoc = ""
            'Trang thai ban dau
            .TrangThaiBanDau()
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat 
            .TrangThaiCapNhat()
            'Hien thi du lieu
            .ShowData()
        End With
        strError = ""
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        '
        If txtMaNguonGoc.Text.Trim = "" Then
            MsgBox("Bạn phải nhập Mã nguồn gốc!", MsgBoxStyle.Information, "DMCLand")
            txtMaNguonGoc.Focus()
            Exit Sub
        End If
        With Me
            'Cap nhat thong tin Nguon goc ()
            .UpdateData()
            'Hien thi du lieu
            .ShowData()
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
        strMaNguonGoc = ""
        strError = ""
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hien thi du lieu
            .ShowData()
            'Xoa du lieu tren Form
            .TrangThaiBanDau()
            'Khoi tao gia tri cho bien dung chung
            strMaNguonGoc = ""
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat 
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub

    Private Sub grdvwNguonGoc_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwNguonGoc.CellMouseClick
        'Khong cho click chuot phai
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khoi tao doi tuong clsTimKiem
        Dim NguonGoc As New clsNguonGoc
        If e.RowIndex >= 0 Then
            Try
                'Cập nhật dữ liệu tương Ứng khi click chuột vào thuộc tính 
                'lớp Nguồn gốc sử dụng đất
                With dtNguonGoc.Rows(e.RowIndex)
                    'Diện tích
                    NguonGoc.DienTich = .Item("DienTich").ToString
                    'Ký hiệu
                    NguonGoc.KyHieu = .Item("KyHieu").ToString
                    'Mã Nguồn gốc
                    NguonGoc.MaNguonGoc = .Item("MaNguonGoc").ToString
                    strMaNguonGoc = NguonGoc.MaNguonGoc
                    'Ghi chú
                    NguonGoc.GhiChu = .Item("GhiChu").ToString
                    'Mã thửa đất cấp GCN
                    NguonGoc.MaThuaDatCapGCN = .Item("MaThuaDatCapGCN").ToString
                    'Chi tiết
                    NguonGoc.ChiTiet = .Item("ChiTiet").ToString
                End With
                'Hiển thị dữ liệu tương ứng lên Form
                With Me
                    'Diện tích
                    If IsNumeric(NguonGoc.DienTich) Then
                        .numDienTich.Text = NguonGoc.DienTich
                    Else
                        .numDienTich.Text = ""
                    End If
                    'Ghi chú
                    .txtGhiChu.Text = NguonGoc.GhiChu
                    'Ký hiệu nguồn gốc
                    .txtMaNguonGoc.Text = NguonGoc.KyHieu
                    'Chi tiết
                    .txtChiTiet.Text = NguonGoc.ChiTiet
                End With
                strThongTinChuCu = txtMaNguonGoc.Text & " _  " & NguonGoc.ChiTiet
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Nguồn gốc sử dụng" _
                       & vbNewLine & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub btnMaNguonGoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaNguonGoc.Click
        If Not txtMaNguonGoc.ReadOnly Then
            Try
                Dim frm As New frmBangMa
                With frm
                    With .CtrlTuDienNguonGoc
                        'Gán chuỗi kết nối cơ sở dữ liệu
                        .Connection = strConnection
                    End With
                    .ShowDialog()
                    With .CtrlTuDienNguonGoc
                        If .KyHieu <> "" Then
                            txtMaNguonGoc.Text = .KyHieu
                            .KyHieu = ""
                        End If
                    End With
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị bảng mã " & vbNewLine & " Nguồn gốc sử dụng đất " & vbNewLine _
                       & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub chkTongHopNguonGoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTongHopNguonGoc.CheckedChanged
        strTongHopThongTin = ""
        If Me.chkTongHopNguonGoc.Checked Then
            blnTrangThaiTongHop = True
            'Chắc chắn rằng tồn tại Nguồn gốc sử dụng đất
            If dtNguonGoc IsNot Nothing Then
                'Chắc chắn rằng tồn tại ít nhất một Nguồn gốc sử dụng
                If dtNguonGoc.Rows.Count > 0 Then
                    'Trường hợp chỉ có một Nguồn gốc sử dụng thì không cần Diện tích đính kèm
                    If dtNguonGoc.Rows.Count = 1 Then
                        strTongHopThongTin = dtNguonGoc.Rows(0).Item("MoTa").ToString
                        Return
                    End If
                    'Tổng hợp nội dung thông tin Nguồn gốc sử dụng
                    For i As Int32 = 0 To dtNguonGoc.Rows.Count - 1
                        If dtNguonGoc.Rows(i).Item("MoTa").ToString <> "" Then
                            'Trường hợp đã có một Nguồn gốc rồi thì ta thêm dâu "," để ngăn cách 2 Nguồn gốc
                            If strTongHopThongTin <> "" Then
                                strTongHopThongTin += ", "
                            End If
                            strTongHopThongTin += dtNguonGoc.Rows(i).Item("MoTa").ToString
                            If dtNguonGoc.Rows(i).Item("DienTich").ToString <> "" Then
                                strTongHopThongTin += " " + dtNguonGoc.Rows(i).Item("DienTich").ToString + "m2"
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

    Private Sub txtMaNguonGoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaNguonGoc.KeyDown
        If (e.KeyValue = 13) Then
            numDienTich.Focus()
        End If
    End Sub

    Private Sub numDienTich_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDienTich.KeyDown
        If (e.KeyValue = 13) Then
            txtChiTiet.Focus()
        End If
    End Sub

    Private Sub txtChiTiet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChiTiet.KeyDown
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
