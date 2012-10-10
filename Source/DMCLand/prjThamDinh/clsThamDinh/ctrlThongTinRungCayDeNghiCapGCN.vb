Imports System.Drawing
Imports System.Windows.Forms

Public Class ctrlThongTinRungCayDeNghiCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã hồ số cấp GCN
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinRungCayDeNghiCapGCN As New DataTable
    Private shortAction As Short = 0
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
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
    Public WriteOnly Property MaHoSoCapGCN() As String
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
            With Me.grdvwDanhSachRungCayDangKyCapGCN
                Me.HideAllColumns(grdvwDanhSachRungCayDangKyCapGCN)
                'CHỈ HIỆN THỊ NHỮNG CỘT CẦN THIẾT
                'Diện tích có Rừng
                With .Columns("DienTichCoRung")
                    .Visible = True
                    .HeaderText = "Diện tích có Rừng"
                    .Width = 200
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nguồn gốc tạo lập
                With .Columns("NguonGocTaoLap")
                    .Visible = True
                    .HeaderText = "Nguồn gốc tạo lập"
                    .Width = 350
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Số hồ sơ giao Rừng
                With .Columns("SoHoSoGiaoRung")
                    .Visible = True
                    .HeaderText = "Số Hồ sơ giao Rừng"
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
            MsgBox(" Danh sách RỪNG CÂY đăng ký cấp GCN " & vbNewLine & "Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    ''' <summary>
    ''' Thêm thông tin RỪNG CÂY đề nghị cấp GCN 
    ''' </summary>
    ''' <param name="grdvw"></param>
    ''' <param name="intRowIndex"></param>
    ''' <remarks></remarks>
    Private Sub ThemThongTinRungCayDeNghiCapGCN(ByVal grdvw As DataGridView, ByVal intRowIndex As Int32)
        'Chắc chắn Form ở chế độ cho phép cập nhật thông tin
        If (txtThongTinRungCayDeNghiCapGCN.ReadOnly = True) Then
            Exit Sub
        End If
        'Chắc chắn có bản ghi được lựa chọn 
        If (intRowIndex < 0) Then
            Exit Sub
        End If
        If (System.Windows.Forms.MessageBox.Show("Bạn có muốn thêm thông tin RỪNG CÂY này vào" _
            & vbNewLine & "Thông tin RỪNG CÂY ĐỀ NGHỊ CẤP GCN không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes) Then
            Dim strRungCay As String = ""
            With grdvw
                strRungCay += "a) Diện tích có Rừng: " + .Rows(intRowIndex).Cells("DienTichCoRung").Value.ToString.Trim + " (m2),"
                strRungCay += vbNewLine + "b) Nguồn gốc tạo lập: " + .Rows(intRowIndex).Cells("NguonGocTaoLap").Value.ToString.Trim + ","
                strRungCay += vbNewLine + "c) Hồ sơ giao Rừng số: " + .Rows(intRowIndex).Cells("SoHoSoGiaoRung").Value.ToString.Trim + ","
            End With
            txtThongTinRungCayDeNghiCapGCN.Text = strRungCay
        End If
    End Sub

#Region "Danh sách RỪNG CÂY đăng ký cấp GCN"

    ''' <summary>
    ''' Hiển thị Danh sách RỪNG CÂY đăng ký cấp GCN lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Function HienThiDanhSachRungCay() As DataTable
        'Hiển thị danh sách RỪNG CÂY đăng ký cấp GCN
        Dim RungCay As New clsThongTinRungCayDangKyCapGCN
        Dim dtRungCay As New DataTable
        Try
            RungCay.Connection = strConnection ' Khai báo nhận chuỗi kết nối Database
            RungCay.MaHoSoCapGCN = strMaHoSoCapGCN
            dtRungCay.Clear()
            With Me
                .grdvwDanhSachRungCayDangKyCapGCN.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng
                dtRungCay = RungCay.SelectThongTinRungCayDangKyCapGCNByMaHoSoCapGCN()
                'Trình bày dữ liệu lên Grid
                .grdvwDanhSachRungCayDangKyCapGCN.DataSource = dtRungCay
                'Khi tồn tại bản ghi nhận được
                If dtRungCay.Rows.Count > 0 Then
                    .FormatGridContruction(Me.grdvwDanhSachRungCayDangKyCapGCN)
                Else
                    .HideAllColumns(grdvwDanhSachRungCayDangKyCapGCN)
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Thông tin RỪNG CÂY đăng ký cấp GCN " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return dtRungCay
    End Function

    Private Sub grdvwDanhSachRungCayDangKyCapGCN_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwDanhSachRungCayDangKyCapGCN.CellMouseDoubleClick
        Me.ThemThongTinRungCayDeNghiCapGCN(grdvwDanhSachRungCayDangKyCapGCN, e.RowIndex)
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
        Dim ThongTinRungCayDeNghiCapGCN As New clsThongTinRungCayDeNghiCapGCN
        'Khai báo và khởi tạo lớp Thông tin CÂY LÂU NĂM đăng ký cấp GCN
        Dim RungCay As New clsThongTinRungCayDangKyCapGCN
        Try
            'Hiển thị danh sách RỪNG CÂY đăng ký cấp GCN lên Grid
            grdvwDanhSachRungCayDangKyCapGCN.DataSource = Me.HienThiDanhSachRungCay
            'Gán giá trị các thuộc tính đối với trường hợp truy vấn
            With ThongTinRungCayDeNghiCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Truy vấn thông tin
            If ThongTinRungCayDeNghiCapGCN.GetData(dtThongTinRungCayDeNghiCapGCN) = "" Then
                'Trình bày dữ liệu lên Form
                If dtThongTinRungCayDeNghiCapGCN.Rows.Count > 0 Then
                    Me.txtThongTinRungCayDeNghiCapGCN.Text = dtThongTinRungCayDeNghiCapGCN.Rows(0).Item("ThongTinRungCayDeNghiCapGCN").ToString
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin RỪNG CÂY đề nghị cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp Thông tin RỪNG CÂY đề nghị cấp GCN
        Dim ThongTinRungCayDeNghiCapGCN As New clsThongTinRungCayDeNghiCapGCN
        Try
            'Xác nhận giá trị cần cập nhật
            With ThongTinRungCayDeNghiCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .ThongTinRungCayDeNghiCapGCN = Me.txtThongTinRungCayDeNghiCapGCN.Text.Trim
                Dim str As String = ""
                'Trường hợp sửa 
                If shortAction = 2 Then
                    ThongTinRungCayDeNghiCapGCN.UpdateThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN()
                ElseIf shortAction = 3 Then
                    ThongTinRungCayDeNghiCapGCN.DeleteThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN()
                    'Xóa dữ liệu trên Form
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin RỪNG CÂY đề nghị cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtThongTinRungCayDeNghiCapGCN.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtThongTinRungCayDeNghiCapGCN.BackColor = Color.White
            Else
                .txtThongTinRungCayDeNghiCapGCN.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtThongTinRungCayDeNghiCapGCN.Clear()
            .txtThongTinRungCayDeNghiCapGCN.Text = ""
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
            'Cập nhật thông tin RỪNG CÂY đề nghị cấp GCN
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin RỪNG CÂY đề nghị cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
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
