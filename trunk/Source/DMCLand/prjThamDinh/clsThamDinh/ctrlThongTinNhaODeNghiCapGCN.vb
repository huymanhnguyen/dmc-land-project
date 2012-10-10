Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlThongTinNhaODeNghiCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã hồ số cấp GCN
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinNhaODeNghiCapGCN As New DataTable
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
            With Me.grdvwDanhSachNhaODangKyCapGCN
                Me.HideAllColumns(grdvwDanhSachNhaODangKyCapGCN)
                'CHỈ HIỆN THỊ NHỮNG CỘT CẦN THIẾT
                'Loại nhà
                With .Columns("LoaiNha")
                    .Visible = True
                    .HeaderText = "Loại"
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .Width = 120
                End With
                'Cấp hạng nhà
                With .Columns("CapHangNha")
                    .Visible = True
                    .HeaderText = "Cấp hạng"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Kết cấu nhà
                With .Columns("KetCauNha")
                    .Visible = True
                    .HeaderText = "Kết cấu"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'So tang
                With .Columns("SoTang")
                    .Visible = True
                    .HeaderText = "Số tầng"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nam xay dung
                With .Columns("NamXayDung")
                    .Visible = True
                    .HeaderText = "Năm xây dựng"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nam hoan thanh xay dung
                With .Columns("NamHoanThanhXayDung")
                    .Visible = True
                    .HeaderText = "Năm hoàn thành"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Thoi han so huu
                With .Columns("ThoiHanSoHuu")
                    .Visible = True
                    .HeaderText = "Thời hạn"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Dia chi nha
                With .Columns("DiaChiNha")
                    .Visible = True
                    .HeaderText = "Địa chỉ"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Dien tich xay dung
                With .Columns("DienTichXayDung")
                    .Visible = True
                    .HeaderText = "Diện tích xây dựng"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Dien tich san phu
                With .Columns("DienTichSanPhu")
                    .Visible = True
                    .HeaderText = "Diện tích sàn phụ"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Dien tich san xay dung
                With .Columns("DienTichSanXayDung")
                    .Visible = True
                    .HeaderText = "Diện tích sàn xây dựng"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'So giay phep xay dung
                With .Columns("SoGiayPhepXayDung")
                    .Visible = True
                    .HeaderText = "Số giấy phép xây dựng"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ngày cấp phép xây dựng
                With .Columns("NgayCapPhepXayDung")
                    .Visible = True
                    .HeaderText = "Năm cấp phép xây dựng"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Co quan cap phep xay dung
                With .Columns("CoQuanCapGPXD")
                    .Visible = True
                    .HeaderText = "Cơ quan cấp GPXD"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Thong tin xu ly vi pham
                With .Columns("ThongTinXuLyViPham")
                    .Visible = True
                    .HeaderText = "Thông tin vi pham"
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
    ''' Thêm thông tin Nhà ở (căn hộ) đề nghị cấp GCN 
    ''' </summary>
    ''' <param name="grdvw"></param>
    ''' <param name="intRowIndex"></param>
    ''' <remarks></remarks>
    Private Sub ThemThongTinNhaODeNghiCapGCN(ByVal grdvw As DataGridView, ByVal intRowIndex As Int32)
        'Chắc chắn Form ở chế độ cho phép cập nhật thông tin
        If (txtThongTinNhaODeNghiCapGCN.ReadOnly = True) Then
            Exit Sub
        End If
        'Chắc chắn có bản ghi được lựa chọn 
        If (intRowIndex < 0) Then
            Exit Sub
        End If
        If (System.Windows.Forms.MessageBox.Show("Bạn có muốn thêm thông tin Nhà ở này vào" _
            & vbNewLine & "Thông tin NHÀ Ở ĐỀ NGHỊ CẤP GCN không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes) Then
            Dim strNhaO As String = ""
            With grdvw
                'Địa chỉ
                strNhaO += "a) Địa chỉ: " + .Rows(intRowIndex).Cells("DiaChiNha").Value.ToString.Trim
                'Diện tích xây dựng
                If (.Rows(intRowIndex).Cells("DienTichXayDung").Value.ToString.Trim() = "") Then
                    strNhaO += vbNewLine + "b) Diện tích xây dựng: " + "-/-"
                Else
                    strNhaO += vbNewLine + "b) Diện tích xây dựng: " + String.Format("{0:0.00}", .Rows(intRowIndex).Cells("DienTichXayDung").Value) + "  m2"
                End If
                'Diện tích sàn xây dựng
                If (.Rows(intRowIndex).Cells("DienTichSanXayDung").Value.ToString.Trim() = "") Then
                    strNhaO += vbTab + "c) Diện tích sàn: " + "-/-"
                Else
                    strNhaO += vbTab + "c) Diện tích sàn: " & String.Format("{0:0.00}", .Rows(intRowIndex).Cells("DienTichSanXayDung").Value) + "  m2"
                End If
                'Kết cấu nhà
                strNhaO += vbNewLine + "d) Kết cấu nhà: " & .Rows(intRowIndex).Cells("KetCauNha").Value.ToString()
                'Cấp hạng nhà
                strNhaO += vbNewLine + "đ) Cấp(Hạng): " & .Rows(intRowIndex).Cells("CapHangNha").Value.ToString()
                'Số tầng
                strNhaO += vbTab + "e) Số tầng: " + String.Format("{0:0.00}", .Rows(intRowIndex).Cells("SoTang").Value)
                'Năm hoàn thành xây dựng
                If (.Rows(intRowIndex).Cells("NamHoanThanhXayDung").Value.ToString.Trim() = "") Then
                    strNhaO += vbNewLine + "g) Năm hoàn thành xây dựng: " + "-/-"
                Else
                    strNhaO += vbNewLine + "g) Năm hoàn thành xây dựng: " + .Rows(intRowIndex).Cells("NamHoanThanhXayDung").Value.ToString.Trim()
                End If
                'Thời hạn sở hữu
                If (.Rows(intRowIndex).Cells("ThoiHanSoHuu").Value.ToString.Trim() = "") Then
                    strNhaO += vbTab + "h) Thời hạn sở hữu: " + "-/-"
                Else
                    strNhaO += vbTab + "h) Thời hạn sở hữu: " + .Rows(intRowIndex).Cells("ThoiHanSoHuu").Value.ToString.Trim()
                End If
            End With
            txtThongTinNhaODeNghiCapGCN.Text = strNhaO
        End If
    End Sub

#Region "Danh sách Nhà ở đăng ký cấp GCN"

    ''' <summary>
    ''' Hiển thị Danh sách Nhà ở đăng ký cấp GCN lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Function HienThiDanhSachNhaO() As DataTable
        'Hiển thị danh sách NHÀ Ở đăng ký cấp GCN
        Dim NhaO As New clsThongTinNhaODangKyCapGCN
        Dim dtNhaO As New DataTable
        Try
            NhaO.Connection = strConnection ' Khai báo nhận chuỗi kết nối Database
            NhaO.MaHoSoCapGCN = strMaHoSoCapGCN
            dtNhaO.Clear()
            With Me
                .grdvwDanhSachNhaODangKyCapGCN.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng
                dtNhaO = NhaO.SelectThongTinNhaODangKyCapGCNByMaHoSoCapGCN()
                'Trình bày dữ liệu lên Grid
                .grdvwDanhSachNhaODangKyCapGCN.DataSource = dtNhaO
                'Khi tồn tại bản ghi nhận được
                If dtNhaO.Rows.Count > 0 Then
                    .FormatGridContruction(Me.grdvwDanhSachNhaODangKyCapGCN)
                Else
                    .HideAllColumns(grdvwDanhSachNhaODangKyCapGCN)
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Thông tin Nhà ở đăng ký cấp GCN " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return dtNhaO
    End Function

    Private Sub grdvwDanhSachNhaODangKyCapGCN_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwDanhSachNhaODangKyCapGCN.CellMouseDoubleClick
        Me.ThemThongTinNhaODeNghiCapGCN(grdvwDanhSachNhaODangKyCapGCN, e.RowIndex)
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
        Dim ThongTinNhaODeNghiCapGCN As New clsThongTinNhaODeNghiCapGCN
        'Khai báo và khởi tạo lớp Thông tin NHÀ Ở đăng ký cấp GCN
        Dim NhaO As New clsThongTinNhaODangKyCapGCN
        Try
            'Hiển thị danh sách NHÀ Ở đăng ký cấp GCN lên Grid
            grdvwDanhSachNhaODangKyCapGCN.DataSource = Me.HienThiDanhSachNhaO
            'Gán giá trị các thuộc tính đối với trường hợp truy vấn
            With ThongTinNhaODeNghiCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Truy vấn thông tin
            If ThongTinNhaODeNghiCapGCN.GetData(dtThongTinNhaODeNghiCapGCN) = "" Then
                'Trình bày dữ liệu lên Form
                If dtThongTinNhaODeNghiCapGCN.Rows.Count > 0 Then
                    Me.txtThongTinNhaODeNghiCapGCN.Text = dtThongTinNhaODeNghiCapGCN.Rows(0).Item("ThongTinNhaODeNghiCapGCN").ToString
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Nhà ở đề nghị cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp Thông tin Nhà ở đề nghị cấp GCN
        Dim ThongTinNhaODeNghiCapGCN As New clsThongTinNhaODeNghiCapGCN
        Try
            'Xác nhận giá trị cần cập nhật
            With ThongTinNhaODeNghiCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .ThongTinNhaODeNghiCapGCN = Me.txtThongTinNhaODeNghiCapGCN.Text.Trim
                Dim str As String = ""
                'Trường hợp sửa 
                If shortAction = 2 Then
                    ThongTinNhaODeNghiCapGCN.UpdateThongTinNhaODeNghiCapGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Cập nhật", "thay (" & strThongTinCu & ") bằng (" & txtThongTinNhaODeNghiCapGCN.Text & ")")
                ElseIf shortAction = 3 Then
                    ThongTinNhaODeNghiCapGCN.DeleteThongTinNhaODeNghiCapGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Xóa", txtThongTinNhaODeNghiCapGCN.Text)
                    'Xóa dữ liệu trên Form
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Nhà ở đề nghị cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtThongTinNhaODeNghiCapGCN.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtThongTinNhaODeNghiCapGCN.BackColor = Color.White
            Else
                .txtThongTinNhaODeNghiCapGCN.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongTinNhaODeNghiCapGCN.Clear()
            .txtThongTinNhaODeNghiCapGCN.Text = ""
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox3.Enabled = True

                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnGhi.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnGhi.Enabled = Not blnStartDeleted
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
            strThongTinCu = txtThongTinNhaODeNghiCapGCN.Text
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

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Try
            'Cập nhật thông tin Nhà ở đề nghị cấp GCN
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Nhà ở đề nghị cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
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

    Private Sub ctrlThongTinGCN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            'Hiển thị dữ liệu
            If strMaHoSoCapGCN <> "" Then
                .ShowData()
            End If
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub
End Class
