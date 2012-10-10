Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlThongTinCongTrinhXayDungDeNghiCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã hồ số cấp GCN
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinCongTrinhXayDungDeNghiCapGCN As New DataTable
    Private shortAction As Short = 0
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
            With Me.grdvwDanhSachCongTrinhXayDungDangKyCapGCN
                Me.HideAllColumns(grdvwDanhSachCongTrinhXayDungDangKyCapGCN)
                'CHỈ HIỆN THỊ NHỮNG CỘT CẦN THIẾT
                'Hạng mục công trình
                With .Columns("TenHangMucCongTrinh")
                    .Visible = True
                    .HeaderText = "Tên hạng mục công trình"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Diện tích xây dựng
                With .Columns("DienTichXayDung")
                    .Visible = True
                    .HeaderText = "Diện tích xây dựng"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Công suất
                With .Columns("CongSuat")
                    .Visible = True
                    .HeaderText = "Diện tích sàn (c/suất)"
                    .Width = 250
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Kết cấu
                With .Columns("KetCau")
                    .Visible = True
                    .HeaderText = "Kết cấu"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Câp hạng
                With .Columns("CapHang")
                    .Visible = True
                    .HeaderText = "Cấp hạng"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Số tầng
                With .Columns("SoTang")
                    .Visible = True
                    .HeaderText = "Số tầng"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Năm xây dựng
                With .Columns("NamXayDung")
                    .Visible = True
                    .HeaderText = "Năm xây dựng"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Thời hạn sở hữu
                With .Columns("ThoiHanSoHuu")
                    .Visible = True
                    .HeaderText = "Thời hạn sở hữu"
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
            MsgBox(" Danh sách Công trình xây dựng đăng ký cấp GCN " & vbNewLine & "Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    ''' <summary>
    ''' Thêm thông tin Công trình xây dựng đề nghị cấp GCN 
    ''' </summary>
    ''' <param name="grdvw"></param>
    ''' <param name="intRowIndex"></param>
    ''' <remarks></remarks>
    Private Sub ThemThongTinCongTrinhXayDungDeNghiCapGCN(ByVal grdvw As DataGridView, ByVal intRowIndex As Int32)
        'Chắc chắn Form ở chế độ cho phép cập nhật thông tin
        If (txtThongTinCongTrinhXayDungDeNghiCapGCN.ReadOnly = True) Then
            Exit Sub
        End If
        'Chắc chắn có bản ghi được lựa chọn 
        If (intRowIndex < 0) Then
            Exit Sub
        End If
        If (System.Windows.Forms.MessageBox.Show("Bạn có muốn thêm thông tin Công trình xây dựng này vào" _
            & vbNewLine & "Thông tin CÔNG TRÌNH XÂY DỰNG ĐỀ NGHỊ CẤP GCN không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes) Then
            Dim strCongTrinhXayDung As String = ""
            With grdvw
                strCongTrinhXayDung += "a) Hạng mục công trình: " + .Rows(intRowIndex).Cells("TenHangMucCongTrinh").Value.ToString.Trim + ","
                strCongTrinhXayDung += vbNewLine + "b) Diện tích xây dựng: " + .Rows(intRowIndex).Cells("DienTichXayDung").Value.ToString.Trim.ToUpper + ","
                strCongTrinhXayDung += vbNewLine + "c) Diện tích sàn: " & String.Format("{0:0.0}", .Rows(intRowIndex).Cells("CongSuat").Value) + ","
                strCongTrinhXayDung += vbNewLine + "d) Kết cấu: " & .Rows(intRowIndex).Cells("KetCau").Value.ToString() + ","
                strCongTrinhXayDung += vbNewLine + "đ) Cấp(Hạng): " & .Rows(intRowIndex).Cells("CapHang").Value.ToString() + ","
                strCongTrinhXayDung += vbNewLine + "e) Số tầng: " + String.Format("{0:0.0}", .Rows(intRowIndex).Cells("SoTang").Value) + ","
                strCongTrinhXayDung += vbNewLine + "g) Năm xây dựng: " + .Rows(intRowIndex).Cells("NamXayDung").Value.ToString.Trim + ","
                strCongTrinhXayDung += vbNewLine + "h) Thời hạn sở hữu: " + .Rows(intRowIndex).Cells("ThoiHanSoHuu").Value.ToString.Trim + ","
            End With
            txtThongTinCongTrinhXayDungDeNghiCapGCN.Text = strCongTrinhXayDung
        End If
    End Sub

#Region "Danh sách Công trình xây dựng đăng ký cấp GCN"

    ''' <summary>
    ''' Hiển thị Danh sách Công trình xây dựng đăng ký cấp GCN lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Function HienThiDanhSachCongTrinhXayDung() As DataTable
        'Hiển thị danh sách Công trình xây dựng đăng ký cấp GCN
        Dim CongTrinhXayDung As New clsThongTinCongTrinhXayDungDangKyCapGCN
        Dim dtCongTrinhXayDung As New DataTable
        Try
            CongTrinhXayDung.Connection = strConnection ' Khai báo nhận chuỗi kết nối Database
            CongTrinhXayDung.MaHoSoCapGCN = strMaHoSoCapGCN
            dtCongTrinhXayDung.Clear()
            With Me
                .grdvwDanhSachCongTrinhXayDungDangKyCapGCN.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng
                dtCongTrinhXayDung = CongTrinhXayDung.SelectThongTinHangMucCongTrinhDangKyCapGCNByMaHoSoCapGCN()
                'Trình bày dữ liệu lên Grid
                .grdvwDanhSachCongTrinhXayDungDangKyCapGCN.DataSource = dtCongTrinhXayDung
                'Khi tồn tại bản ghi nhận được
                If dtCongTrinhXayDung.Rows.Count > 0 Then
                    .FormatGridContruction(Me.grdvwDanhSachCongTrinhXayDungDangKyCapGCN)
                Else
                    .HideAllColumns(grdvwDanhSachCongTrinhXayDungDangKyCapGCN)
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Thông tin Công trình xây dựng đăng ký cấp GCN " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return dtCongTrinhXayDung
    End Function

    Private Sub grdvwDanhSachCongTrinhXayDungDangKyCapGCN_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwDanhSachCongTrinhXayDungDangKyCapGCN.CellMouseDoubleClick
        Me.ThemThongTinCongTrinhXayDungDeNghiCapGCN(grdvwDanhSachCongTrinhXayDungDangKyCapGCN, e.RowIndex)
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
        Dim ThongTinCongTrinhXayDungDeNghiCapGCN As New clsThongTinCongTrinhXayDungDeNghiCapGCN
        'Khai báo và khởi tạo lớp Thông tin Công trình xây dựng đăng ký cấp GCN
        Dim CongTrinhXayDung As New clsThongTinCongTrinhXayDungDangKyCapGCN
        Try
            'Hiển thị danh sách Công trình xây dựng đăng ký cấp GCN lên Grid
            grdvwDanhSachCongTrinhXayDungDangKyCapGCN.DataSource = Me.HienThiDanhSachCongTrinhXayDung
            'Gán giá trị các thuộc tính đối với trường hợp truy vấn
            With ThongTinCongTrinhXayDungDeNghiCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Truy vấn thông tin
            If ThongTinCongTrinhXayDungDeNghiCapGCN.GetData(dtThongTinCongTrinhXayDungDeNghiCapGCN) = "" Then
                'Trình bày dữ liệu lên Form
                If dtThongTinCongTrinhXayDungDeNghiCapGCN.Rows.Count > 0 Then
                    Me.txtThongTinCongTrinhXayDungDeNghiCapGCN.Text = dtThongTinCongTrinhXayDungDeNghiCapGCN.Rows(0).Item("ThongTinHangMucCongTrinhDeNghiCapGCN").ToString
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Công trình xây dựng đề nghị cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp Thông tin Công trình xây dựng đề nghị cấp GCN
        Dim ThongTinCongTrinhXayDungDeNghiCapGCN As New clsThongTinCongTrinhXayDungDeNghiCapGCN
        Try
            'Xác nhận giá trị cần cập nhật
            With ThongTinCongTrinhXayDungDeNghiCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .ThongTinHangMucCongTrinhDeNghiCapGCN = Me.txtThongTinCongTrinhXayDungDeNghiCapGCN.Text.Trim
                Dim str As String = ""
                'Trường hợp sửa 
                If shortAction = 2 Then
                    ThongTinCongTrinhXayDungDeNghiCapGCN.UpdateThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN()
                ElseIf shortAction = 3 Then
                    ThongTinCongTrinhXayDungDeNghiCapGCN.DeleteThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN()
                    'Xóa dữ liệu trên Form
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Công trình xây dựng đề nghị cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtThongTinCongTrinhXayDungDeNghiCapGCN.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtThongTinCongTrinhXayDungDeNghiCapGCN.BackColor = Color.White
            Else
                .txtThongTinCongTrinhXayDungDeNghiCapGCN.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongTinCongTrinhXayDungDeNghiCapGCN.Clear()
            .txtThongTinCongTrinhXayDungDeNghiCapGCN.Text = ""
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
            'Cập nhật thông tin Công trình xây dựng đề nghị cấp GCN
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Công trình xây dựng đề nghị cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
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
