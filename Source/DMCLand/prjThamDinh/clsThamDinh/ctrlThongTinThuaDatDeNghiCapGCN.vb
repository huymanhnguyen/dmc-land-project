Imports System.Drawing
Imports System.Windows.Forms
Public Class ctrlThongTinThuaDatDeNghiCapGCN

    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã hồ số cấp GCN
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinThuaDatDeNghiCapGCN As New DataTable
    Private shortAction As Short = 0
    Private strThongTinCu As String

    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
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
    Private strMaDonViHanhChinh As String = ""
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Thẩm định nhà ở"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
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
    ''' <summary>
    ''' Định dạng dữ liệu hiển thị trên Grid
    ''' </summary>
    ''' <param name="grdvw">Tên Grid cần định dạng</param>
    ''' <remarks></remarks>
    Private Sub FormatGridContruction(ByVal grdvw As DataGridView)
        Try
            With Me.grdvwDanhSachThuaDatDangKyCapGCN
                Me.HideAllColumns(grdvwDanhSachThuaDatDangKyCapGCN)
                'CHỈ HIỆN THỊ NHỮNG CỘT CẦN THIẾT
                'Tờ bản đồ
                With .Columns("ToBanDo")
                    .Visible = True
                    .HeaderText = "Tờ bản đồ"
                    .Width = 150
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Số thửa
                With .Columns("SoThua")
                    .Visible = True
                    .HeaderText = "Số thửa"
                    .Width = 150
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Địa chỉ
                With .Columns("DiaChi")
                    .Visible = True
                    .HeaderText = "Địa chỉ"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Diện tích
                With .Columns("DienTich")
                    .Visible = True
                    .HeaderText = "Diện tích"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Diện tích bằng chữ
                With .Columns("DienTichBangChu")
                    .Visible = True
                    .HeaderText = "Diện tích bằng chữ"
                    .Width = 150
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Diện tích Riêng
                With .Columns("DienTichRieng")
                    .Visible = True
                    .HeaderText = "Diện tích Riêng"
                    .Width = 150
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Diện tích Chung
                With .Columns("DienTichChung")
                    .Visible = True
                    .HeaderText = "Diện tích Chung"
                    .Width = 150
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Mục đích sử dụng
                With .Columns("MucDichSuDung")
                    .Visible = True
                    .HeaderText = "Mục đích sử dụng"
                    .Width = 150
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Thời hạn sử dụng
                With .Columns("ThoiHanSuDung")
                    .Visible = True
                    .HeaderText = "Thời hạn sử dụng"
                    .Width = 150
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nguồn gốc sử dụng
                With .Columns("NguonGocSuDung")
                    .Visible = True
                    .HeaderText = "Nguồn gốc sử dụng"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Diện tích không cấp
                With .Columns("DienTichKhongCap")
                    .Visible = True
                    .HeaderText = "Diện tích không cấp"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Diện tích không cấp bằng chữ
                With .Columns("DienTichKhongCapBangChu")
                    .Visible = True
                    .HeaderText = "Diện tích không cấp bằng chữ"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Lý do không cấp
                With .Columns("LyDoKhongCap")
                    .Visible = True
                    .HeaderText = "Lý do không cấp"
                    .Width = 250
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
            MsgBox(" Danh sách Nhà ở (căn hộ) đăng ký cấp GCN " & vbNewLine & "Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    ''' <summary>
    ''' Thêm thông tin Thửa đất đề nghị cấp GCN 
    ''' </summary>
    ''' <param name="grdvw"></param>
    ''' <param name="intRowIndex"></param>
    ''' <remarks></remarks>
    Private Sub ThemThongTinThuaDatDeNghiCapGCN(ByVal grdvw As DataGridView, ByVal intRowIndex As Int32)
        'Chắc chắn Form ở chế độ cho phép cập nhật thông tin
        If (txtThongTinThuaDatDeNghiCapGCN.ReadOnly = True) Then
            Exit Sub
        End If
        'Chắc chắn có bản ghi được lựa chọn 
        If (intRowIndex < 0) Then
            Exit Sub
        End If
        If (System.Windows.Forms.MessageBox.Show("Bạn có muốn thêm thông tin Thửa đất này vào" _
            & vbNewLine & "Thông tin THỬA ĐẤT ĐỀ NGHỊ CẤP GCN không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes) Then
            Dim strThuaDat As String = ""
            Dim dt As New DataTable
            dt = ThongTinThuaDatTongHop()
            If dt.Rows.Count > 0 Then
            

                With dt
                    strThuaDat = "a) " & "Thửa đất số: " & .Rows(0).Item("SoThua").ToString.Trim.ToUpper & vbTab & "," & "tờ bản đồ số: " & .Rows(0).Item("ToBanDo").ToString.Trim.ToUpper & vbNewLine
                    strThuaDat += "b) " & "Địa chỉ: " & .Rows(0).Item("DiaChi").ToString.Trim & vbNewLine
                    strThuaDat += "c) " & "Diện tích: " & String.Format("{0:0.00}", .Rows(0).Item("DienTich")) & "  m2, " & "(bằng chữ: " & .Rows(0).Item("DienTichBangChu").ToString.Trim & ")" & vbNewLine
                    strThuaDat += "d) " & "Hình thức sử dụng: " & "riêng: " & String.Format("{0:0.00}", .Rows(0).Item("DienTichRieng")) & "  m2 , " & "chung: " & String.Format("{0:0.00}", .Rows(0).Item("DienTichChung")) & "  m2" & vbNewLine
                    strThuaDat += "đ) " & "Mục đích sử dụng: " & .Rows(0).Item("MucDichSuDung").ToString.Trim & vbNewLine
                    If (.Rows(0).Item("ThoiHanSuDung").ToString.Trim = "") Then
                        strThuaDat += "e) " & "Thời hạn sử dụng: -/- "
                    Else
                        strThuaDat += "e) " & "Thời hạn sử dụng: " & .Rows(0).Item("ThoiHanSuDung").ToString.Trim & vbNewLine
                    End If
                    strThuaDat += "g) " & "Nguồn gốc sử dụng: " & .Rows(0).Item("NguonGocSuDung").ToString.Trim & vbNewLine
                End With

                'With grdvw
                '    strThuaDat = "a) " & "Thửa đất số: " & .Rows(intRowIndex).Cells("SoThua").Value.ToString.Trim & vbTab & "," & "tờ bản đồ số: " & .Rows(intRowIndex).Cells("ToBanDo").Value.ToString.Trim & vbNewLine
                '    strThuaDat += "b) " & "Địa chỉ: " & .Rows(intRowIndex).Cells("DiaChi").Value.ToString.Trim & vbNewLine
                '    strThuaDat += "c) " & "Diện tích: " & String.Format("{0:0.00}", .Rows(intRowIndex).Cells("DienTich").Value) & "  m2, " & "(bằng chữ: " & .Rows(intRowIndex).Cells("DienTichBangChu").Value.ToString.Trim & ")" & vbNewLine
                '    strThuaDat += "d) " & "Hình thức sử dụng: " & "riêng: " & String.Format("{0:0.00}", .Rows(intRowIndex).Cells("DienTichRieng").Value) & "  m2 , " & "chung: " & String.Format("{0:0.00}", .Rows(intRowIndex).Cells("DienTichChung").Value) & "  m2" & vbNewLine
                '    strThuaDat += "đ) " & "Mục đích sử dụng: " & .Rows(intRowIndex).Cells("MucDichSuDung").Value.ToString.Trim & vbNewLine
                '    If (.Rows(intRowIndex).Cells("ThoiHanSuDung").Value.ToString.Trim = "") Then
                '        strThuaDat += "e) " & "Thời hạn sử dụng: -/- "
                '    Else
                '        strThuaDat += "e) " & "Thời hạn sử dụng: " & .Rows(intRowIndex).Cells("ThoiHanSuDung").Value.ToString.Trim & vbNewLine
                '    End If
                '    strThuaDat += "g) " & "Nguồn gốc sử dụng: " & .Rows(intRowIndex).Cells("NguonGocSuDung").Value.ToString.Trim & vbNewLine
                'End With
                'Hiển thị lên Form 
                txtThongTinThuaDatDeNghiCapGCN.Text = strThuaDat
            Else
                MessageBox.Show("Thông tin chưa được thẩm định", "DMCLand")
                Exit Sub
            End If
        End If
    End Sub

#Region "Danh sách Thửa đất đăng ký cấp GCN"

    ''' <summary>
    ''' Hiển thị Danh sách Thửa đất đăng ký cấp GCN lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Function HienThiDanhSachThuaDat() As DataTable
        'Hiển thị danh sách Thửa đất đăng ký cấp GCN
        Dim ThuaDat As New clsThongTinThuaDatDangKyCapGCN
        Dim dtThuaDat As New DataTable
        Try
            ThuaDat.Connection = strConnection ' Khai báo nhận chuỗi kết nối Database
            ThuaDat.MaHoSoCapGCN = strMaHoSoCapGCN
            ThuaDat.MaDonVIHanhChinh = strMaDonViHanhChinh
            dtThuaDat.Clear()
            With Me
                .grdvwDanhSachThuaDatDangKyCapGCN.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng
                dtThuaDat = ThuaDat.SelectThongTinThuaDatDangKyCapGCNByMaHoSoCapGCN()
                'Trình bày dữ liệu lên Grid
                .grdvwDanhSachThuaDatDangKyCapGCN.DataSource = dtThuaDat
                'Khi tồn tại bản ghi nhận được
                If dtThuaDat.Rows.Count > 0 Then
                    .FormatGridContruction(Me.grdvwDanhSachThuaDatDangKyCapGCN)
                Else
                    .HideAllColumns(grdvwDanhSachThuaDatDangKyCapGCN)
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Thông tin Thửa đất đăng ký cấp GCN " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return dtThuaDat
    End Function

    ''' <summary>
    ''' Hiển thị Danh sách Thửa đất đăng ký cấp GCN lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ThongTinThuaDatTongHop() As DataTable
        'Hiển thị danh sách Thửa đất đăng ký cấp GCN
        Dim ThuaDat As New clsThongTinThuaDatDangKyCapGCN
        Dim dtThuaDat As New DataTable
        Try
            ThuaDat.Connection = strConnection ' Khai báo nhận chuỗi kết nối Database
            ThuaDat.MaHoSoCapGCN = strMaHoSoCapGCN
            dtThuaDat.Clear()
            With Me
                'Gọi phương thức GetData để khởi tạo đối tượng
                dtThuaDat = ThuaDat.SelectThongTinThuaDatTongHopCapGCNByMaHoSoCapGCN()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Thông tin Thửa đất đăng ký cấp GCN " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return dtThuaDat
    End Function

    Private Sub grdvwDanhSachThuaDatDangKyCapGCN_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwDanhSachThuaDatDangKyCapGCN.CellMouseDoubleClick
        Me.ThemThongTinThuaDatDeNghiCapGCN(grdvwDanhSachThuaDatDangKyCapGCN, e.RowIndex)
    End Sub
#End Region

    'Hiển thị thông tin GCN
    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox3.Enabled = True
        Else
            Me.GroupBox3.Enabled = False
        End If
        'Khai báo và khởi tạo lớp Thông tin GCN
        Dim ThongTinThuaDatDeNghiCapGCN As New clsThongTinThuaDatDeNghiCapGCN
        'Khai báo và khởi tạo lớp Thông tin Thửa đất đăng ký cấp GCN
        Dim ThuaDat As New clsThongTinThuaDatDeNghiCapGCN
        Try
            'Hiển thị danh sách Thửa đất đăng ký cấp GCN lên Grid
            grdvwDanhSachThuaDatDangKyCapGCN.DataSource = Me.HienThiDanhSachThuaDat
            'Gán giá trị các thuộc tính đối với trường hợp truy vấn
            With ThongTinThuaDatDeNghiCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Truy vấn thông tin
            If ThongTinThuaDatDeNghiCapGCN.SelectThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN(dtThongTinThuaDatDeNghiCapGCN).ToString = "True" Then
                'Trình bày dữ liệu lên Form
                If dtThongTinThuaDatDeNghiCapGCN.Rows.Count > 0 Then
                    Me.txtThongTinThuaDatDeNghiCapGCN.Text = dtThongTinThuaDatDeNghiCapGCN.Rows(0).Item("ThongTinThuaDatDeNghiCapGCN").ToString
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Thửa đất đề nghị cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp Thông tin Thửa đất đề nghị cấp GCN
        Dim ThongTinThuaDatDeNghiCapGCN As New clsThongTinThuaDatDeNghiCapGCN
        Try
            'Xác nhận giá trị cần cập nhật
            With ThongTinThuaDatDeNghiCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .ThongTinThuaDatDeNghiCapGCN = Me.txtThongTinThuaDatDeNghiCapGCN.Text.Trim
                Dim str As String = ""
                'Trường hợp sửa 
                If shortAction = 2 Then
                    ThongTinThuaDatDeNghiCapGCN.UpdateThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Cập nhật", "Thay (" & strThongTinCu & ") bằng (" & txtThongTinThuaDatDeNghiCapGCN.Text & ")")
                ElseIf shortAction = 3 Then
                    ThongTinThuaDatDeNghiCapGCN.DeleteThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Xóa", txtThongTinThuaDatDeNghiCapGCN.Text)
                    'Xóa dữ liệu trên Form
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Thửa đất đề nghị cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtThongTinThuaDatDeNghiCapGCN.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtThongTinThuaDatDeNghiCapGCN.BackColor = Color.White
            Else
                .txtThongTinThuaDatDeNghiCapGCN.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongTinThuaDatDeNghiCapGCN.Clear()
            .txtThongTinThuaDatDeNghiCapGCN.Text = ""
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If MaLoaiBienDong <> "MG" Then
                Me.GroupBox3.Enabled = True
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnCapNhat.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnCapNhat.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                End If
            Else
                Me.GroupBox3.Enabled = False

            End If

        End With
    End Sub


    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        shortAction = 2
        With Me
            'Trạng thái chức năng
            .TrangThaiChucNang(True)
            'Trạng thái cập nhật
            .TrangThaiCapNhat(True)
            strThongTinCu = txtThongTinThuaDatDeNghiCapGCN.Text
        End With
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If strMaHoSoCapGCN <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                With Me
                    shortAction = 3
                    .UpdateData()
                    'Trạng thái ban đầu
                    .TrangThaiBanDau()
                    'Trạng thái chức năng
                    .TrangThaiChucNang(True, True)
                End With
                If (strError = "") Then
                    MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                Else
                    MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                End If
            Else
                'Trạng thái chức năng
                Me.TrangThaiChucNang()
            End If
        End If
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
        strError = ""
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Try
            'Cập nhật thông tin Thửa đất đề nghị cấp GCN
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Thửa đất đề nghị cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Hiển thị dữ liệu
        Me.ShowData()
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        strError = ""
    End Sub

    Private Sub ctrlThongTinThuaDatDeNghiCapGCN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
            'Trạng thái chức năng
            .TrangThaiChucNang(True, True)
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Xóa dữ liệu trên Form
            .TrangThaiBanDau()
            ''Hiển thị dữ liệu
            'If strMaHoSoCapGCN <> "" Then
            .ShowData()
            'End If
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub

    Private Sub btnPhieuThamDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPhieuThamDinh.Click
        Try
            If strMaHoSoCapGCN <> "" Then
                Dim frmRpt As New frmRptThamDinh

                'Tạm thời bỏ qua
                Exit Sub

                With frmRpt
                    With .CtrlRptPhieuThamDinh
                        'Xac nhan chuoi ket noi co so du lieu
                        .Connection = strConnection
                        'Xac nhan Ho so can hien thi thong tin Tham Dinh
                        .MaHoSoCapGCN = strMaHoSoCapGCN
                    End With
                    .Show()
                End With
            Else
                MsgBox("Hồ sơ chưa có thông tin Thẩm định!", MsgBoxStyle.Information, "DMCLand")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Lỗi trong điều khiển Phiếu thẩm định: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub btnHoSoKiThuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHoSoKiThuat.Click
        Dim HoSoKiThuat As New frmHoSoKiThuat
        'Tạm thời bỏ qua
        Exit Sub
        With HoSoKiThuat
            With .CtrInHoSoKyThuat
                .Conection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .CtrInHoSoKyThuat_Load()
            End With
            .ShowDialog()
        End With
    End Sub

End Class
