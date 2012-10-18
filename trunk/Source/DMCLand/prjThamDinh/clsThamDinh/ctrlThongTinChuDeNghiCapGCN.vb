Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Xml

Public Class ctrlThongTinChuDeNghiCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã hồ số cấp GCN
    Private strMaHoSoCapGCN As String = ""
    Private dtGhiChuNoiDungChuDeNghiCapGCN As New DataTable
    'Danh sách kê khai Chủ sử dụng đất
    Dim dtChuHoSoDangKyCapGCNGDCN As New DataTable
    'Danh sách kê khai Chủ sở hữu Nhà Ở
    Dim dtChuHoSoDangKyCapGCNCQNN As New DataTable
    'Danh sách kê khai Chủ công trình xây dựng
    Dim dtChuHoSoDangKyCapGCNTCDN As New DataTable
    'Danh sách kê khai Chủ sở hữu Rừng cây
    Dim dtChuSoHuuRungCay As New DataTable
    'Danh sách kê khai Chủ sở hữu Cây lâu năm
    Dim dtChuSoHuuCayLauNam As New DataTable
    'Danh sách Chủ đề nghị cấp GCN
    Dim dtChuDeNghiCapGCN As New DataTable
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
    'Hiển thị thông tin GCN
    Public Sub ShowData()
        If MaLoaiBienDong <> "MG" Then
            Me.GroupBox2.Enabled = True
        Else
            Me.GroupBox2.Enabled = False

        End If
        'Khai báo và khởi tạo lớp Thông tin GCN
        Dim GhiChuNoiDungChuDeNghiCapGCN As New clsGhiChuNoiDungChuDeNghiCapGCN
        Try
            'Hiển thị DANH SÁCH CHỦ SỬ DỤNG ĐẤT đăng ký cấp GCN
            Me.grdvwChuHoSoDangKyCapGCNGDCN.DataSource = Me.HienThiChuHoSoDangKyCapGCNGDCN
            'Hiển thị DANH SÁCH CHỦ SỞ HỮU NHÀ đăng ký cấp GCN
            Me.grdvwChuHoSoDangKyCapGCNCQNN.DataSource = Me.HienThiChuHoSoDangKyCapGCNCQNN
            'Hiên thị DANH SÁCH CHỦ SỞ HỮU CÔNG TRÌNH XÂY DỰNG đăng ký cấp GCN
            Me.grdvwChuHoSoDangKyCapGCNTCDN.DataSource = Me.HienThiChuHoSoDangKyCapGCNTCDN
            'Hiển thị Danh sách Chủ đề nghị cấp GCN
            Me.grdvwChuDeNghiCapGCN.DataSource = Me.HienThiDanhSachChuDeNghiCapGCN
            'Gán giá trị các thuộc tính đối với trường hợp truy vấn
            With GhiChuNoiDungChuDeNghiCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
           ' MsgBox(" Mã HS Chủ đề nghị cấp GCN" & vbNewLine & strMaHoSoCapGCN, MsgBoxStyle.Information, "DMCLand")
            'Khởi tạo trạng thái ban đầu
            TrangThaiBanDau()
            'Truy vấn thông tin
            If GhiChuNoiDungChuDeNghiCapGCN.GetData(dtGhiChuNoiDungChuDeNghiCapGCN) = "" Then
                'Trình bày dữ liệu lên Form
                If dtGhiChuNoiDungChuDeNghiCapGCN.Rows.Count > 0 Then
                    Me.txtGhiChuNoiDungChuDeNghiCapGCN.Text = dtGhiChuNoiDungChuDeNghiCapGCN.Rows(0).Item("GhiChuNoiDungChuDeNghiCapGCN").ToString
                End If
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin tin Chủ đề nghị cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Thẩm định chử sử dụng"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp Thông tin GCN
        Dim ThongTinChuDeNghiCapGCN As New clsGhiChuNoiDungChuDeNghiCapGCN
        Try
            'Xác nhận giá trị cần cập nhật
            With ThongTinChuDeNghiCapGCN
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .GhiChuNoiDungChuDeNghiCapGCN = Me.txtGhiChuNoiDungChuDeNghiCapGCN.Text.Trim
                Dim str As String = ""
                'Trường hợp sửa 

                If shortAction = 2 Then
                    ThongTinChuDeNghiCapGCN.UpdateGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Cập nhật", "")
                ElseIf shortAction = 3 Then
                    ThongTinChuDeNghiCapGCN.DeleteGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN()
                    NhatKyNguoiDung("Xóa", "")
                    'Xóa dữ liệu trên Form
                    TrangThaiBanDau()
                End If
                shortAction = 0
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin Chủ đề nghị cấp GCN" & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .txtGhiChuNoiDungChuDeNghiCapGCN.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtGhiChuNoiDungChuDeNghiCapGCN.BackColor = Color.White
            Else
                .txtGhiChuNoiDungChuDeNghiCapGCN.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            dtGhiChuNoiDungChuDeNghiCapGCN.Clear()
            .txtGhiChuNoiDungChuDeNghiCapGCN.Text = ""
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox2.Enabled = True
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnGhi.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnGhi.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                End If
            Else
                Me.GroupBox2.Enabled = False

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
            'Cập nhật thông tin Quyết định cấp GCN
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật Thông tin GCN " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
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
            'Ẩn tất cả các cột
            Me.HideAllColumns(grdvw)
            'Chỉ hiển thị những Cột cần thiết
            With grdvw
                'Kiểm tra xem nếu có cột chọn thì Hiển thị lên
                If (.Columns.Contains("Chon")) Then
                    'Chọn
                    With .Columns("Chon")
                        .HeaderText = "Chọn"
                        .Width = 100
                        .Visible = True
                        .DisplayIndex = 0
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                End If
                'Quan he
                If (.Columns.Contains("QuanHe")) Then
                    With .Columns("QuanHe")
                        .HeaderText = "Quan hệ"
                        .Width = 100
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                End If
                'Ho va Ten
                With .Columns("HoTen")
                    .HeaderText = "Tên"
                    .Width = 200
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nam sinh
                If (.Columns.Contains("NamSinh")) Then
                    With .Columns("NamSinh")
                        .HeaderText = "Năm sinh"
                        .Width = 150
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                End If
                'So dinh danh
                If (.Columns.Contains("SoDinhDanh")) Then
                    With .Columns("SoDinhDanh")
                        .HeaderText = "Số CMND (HC)"
                        .Width = 150
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                End If
                'Dai chi thuong chu
                With .Columns("DiaChi")
                    .HeaderText = "Địa chỉ thường chú"
                    .Width = 300
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
            MsgBox(" Danh sách Chủ đăng ký cấp GCN " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
#Region "Các hàm xử lý Datatable và Grid"
    Private Function selectedRecords(ByVal dtOrginal As DataTable) As DataTable
        ' Làm sạch dữ liệu 
        Dim dtSecondary As New DataTable
        dtSecondary = dtOrginal.Clone
        dtSecondary.Rows.Clear()
        Try
            Dim intCounter As Int32 = dtOrginal.Rows.Count
            If intCounter > 0 Then
                Dim i As Int32 = 0
                For i = 0 To intCounter - 1
                    If (dtOrginal.Rows(i).Item("Chon").ToString <> "") Then
                        If (dtOrginal.Rows(i).Item("Chon").ToString = "True") Then
                            dtSecondary.Rows.Add(dtOrginal.Rows(i).ItemArray)
                        End If
                    End If
                Next i
            End If
        Catch ex As Exception
            strError = ""
            strError = ex.ToString()
            System.Windows.Forms.MessageBox.Show("Danh sách Chủ được lựa chọn đề nghị cấp GCN" + vbNewLine, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtSecondary
    End Function

    ''' <summary>
    ''' Thêm cột chọn vào  bảng
    ''' </summary>
    ''' <param name="workTable">Bảng cần thêm cột Chọn</param>
    ''' <param name="strColumnName">Tên cột chọn</param>
    ''' <param name="strCapture">Tiêu đề cột</param>
    ''' <remarks></remarks>
    Private Sub addSelectedColumn(ByRef workTable As DataTable, ByVal strColumnName As String, ByVal strCapture As String)
        Dim strError As String
        Try
            If (workTable.Columns.Contains(strColumnName)) Then
                Exit Sub
            End If
            Dim workColumn As New DataColumn(strColumnName, Type.GetType("System.Boolean")) ', strExpression)
            workTable.Columns.Add(workColumn)
            workColumn.AllowDBNull = True
            workColumn.Caption = strCapture
            workTable.Columns.Item("Chon").SetOrdinal(0)
        Catch ex As Exception
            strError = ex.Message
        End Try
    End Sub
#End Region


    '#Region "Danh sách Chủ sử dụng và chủ sở hữu đề nghị cấp GCN"
    '    Private Sub DeNghiCap(ByVal grdvwKeKhai As DataGridView, ByVal grdvwDeNghiCap As DataGridView)
    '        'Kiểm tra tính hợp lệ của dữ liệu
    '        'Chắc chắc rằng grdvwKeKhai tồn tại chủ cần đề nghị cấp GCN
    '        If grdvwKeKhai.RowCount < 1 Then
    '            System.Windows.Forms.MessageBox.Show("Không có Chủ nào kê khai đăng ký cấp GCN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If
    '        If (grdvwKeKhai.SelectedRows.Count < 1) Then
    '            System.Windows.Forms.MessageBox.Show("Bạn phải chọn Chủ cần đề nghị cấp GCN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If
    '        'Chắc chắn rằng grdvwDeNghiCap có số người đề nghị cấp GCN nhỏ hơn 2
    '        If (grdvwDeNghiCap.RowCount >= 2) Then
    '            System.Windows.Forms.MessageBox.Show("Danh sách chủ đề nghị cấp không lớn hơn 2", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If
    '        'Chuyển Chủ từ danh sách Kê khai về danh sách Đăng ký cấp GCN
    '    End Sub
    '#End Region

    ''' <summary>
    ''' Thêm thông tin Chủ đề nghị cấp GCN 
    ''' </summary>
    ''' <param name="grdvw"></param>
    ''' <param name="intRowIndex"></param>
    ''' <remarks></remarks>
    Private Sub ThemThongTinChuDeNghiCapGCN(ByVal grdvw As DataGridView, ByVal intRowIndex As Int32)
        'Chắc chắn Form ở chế độ cho phép cập nhật thông tin
        If (txtGhiChuNoiDungChuDeNghiCapGCN.ReadOnly = True) Then
            Exit Sub
        End If
        'Chắc chắn có bản ghi được lựa chọn 
        If (intRowIndex < 0) Then
            Exit Sub
        End If
        If (System.Windows.Forms.MessageBox.Show("Bạn có muốn thêm thông tin Chủ này vào" _
            & vbNewLine & "Thông tin CHỦ ĐỀ NGHỊ CẤP GCN không?", "DMCLand", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes) Then
            Dim strChu As String = ""
            With grdvw
                strChu += .Rows(intRowIndex).Cells("QuanHe").Value.ToString.Trim + " "
                strChu += .Rows(intRowIndex).Cells("HoTen").Value.ToString.Trim.ToUpper + ""
                strChu += vbNewLine + "Năm sinh: " & .Rows(intRowIndex).Cells("NamSinh").Value.ToString() + ", "
                strChu += "số CMND: " & .Rows(intRowIndex).Cells("SoDinhDanh").Value.ToString() + " "
                strChu += vbNewLine & "Địa chỉ thường trú: " & .Rows(intRowIndex).Cells("DiaChi").Value.ToString() + "." + vbNewLine

            End With
            txtGhiChuNoiDungChuDeNghiCapGCN.Text += strChu
        End If
    End Sub


#Region "Danh sách Chủ đề nghị cấp GCN"

    ''' <summary>
    ''' Hiển thị thông tin Chủ đề nghị cấp GCN lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Function HienThiDanhSachChuDeNghiCapGCN() As DataTable
        'Hiển thị danh sách Chủ sử đề nghị cấp GCN
        Dim ChuDeNghiCapGCN As New clsThongTinChuDeNghiCapGCN
        Try
            'Khai báo nhận chuỗi kết nối Database
            ChuDeNghiCapGCN.Connection = strConnection
            ChuDeNghiCapGCN.MaHoSoCapGCN = strMaHoSoCapGCN
            dtChuDeNghiCapGCN.Clear()
            With Me
                .grdvwChuDeNghiCapGCN.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng ChuSuDung
                dtChuDeNghiCapGCN = ChuDeNghiCapGCN.SelectChuDeNghiCapGCNByMaHoSoCapGCN()
                'Thêm cột chọn kiểu CheckBoxColumn vào Datatable
                Me.addSelectedColumn(dtChuDeNghiCapGCN, "Chon", "Chọn")
                'Trình bày dữ liệu lên Grid
                .grdvwChuDeNghiCapGCN.DataSource = dtChuDeNghiCapGCN
                'Khi tồn tại bản ghi nhận được
                If dtChuDeNghiCapGCN.Rows.Count > 0 Then
                    .FormatGridContruction(Me.grdvwChuDeNghiCapGCN)
                Else
                    .HideAllColumns(grdvwChuDeNghiCapGCN)
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Danh sách Chủ đề nghị cấp GCN " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return dtChuDeNghiCapGCN
    End Function
#End Region


#Region "Danh sách Chủ sử dụng đất đăng ký cấp GCN"

    ''' <summary>
    ''' Hiển thị thông tin Chủ sử dụng đất trong lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Function HienThiChuHoSoDangKyCapGCNGDCN() As DataTable
        'Hiển thị danh sách Chủ sử dụng đất đăng ký cấp GCN
        Dim Chu As New clsThongTinChuDangKyCapGCN
        Try
            Chu.Connection = strConnection ' Khai báo nhận chuỗi kết nối Database
            Chu.MaHoSoCapGCN = strMaHoSoCapGCN
            dtChuHoSoDangKyCapGCNGDCN.Clear()
            With Me
                .grdvwChuHoSoDangKyCapGCNGDCN.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng ChuSuDung
                dtChuHoSoDangKyCapGCNGDCN = Chu.SelectChuHoSoDangKyCapGCNGDCNByMaHoSoCapGCN()
                'Thêm cột chọn kiểu CheckBoxColumn vào Datatable
                Me.addSelectedColumn(dtChuHoSoDangKyCapGCNGDCN, "Chon", "Chọn")
                'Trình bày dữ liệu lên Grid
                .grdvwChuHoSoDangKyCapGCNGDCN.DataSource = dtChuHoSoDangKyCapGCNGDCN
                'Khi tồn tại bản ghi nhận được
                If dtChuHoSoDangKyCapGCNGDCN.Rows.Count > 0 Then
                    .FormatGridContruction(Me.grdvwChuHoSoDangKyCapGCNGDCN)
                Else
                    .HideAllColumns(grdvwChuHoSoDangKyCapGCNGDCN)
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Chủ sử dụng đất đăng ký cấp GCN " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return dtChuHoSoDangKyCapGCNGDCN
    End Function

    Private Sub grdvwChuSuDungDat_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwChuHoSoDangKyCapGCNGDCN.CellMouseClick
        'Trường hợp người dùng Check vào mục chọn
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Me.checkColumn(grdvwChuHoSoDangKyCapGCNGDCN, e.RowIndex, e.ColumnIndex)
        End If
    End Sub
#End Region

#Region "Danh sách Chủ sở hữu Nhà ở đăng ký cấp GCN"
    ''' <summary>
    ''' Hiển thị thông tin Chủ sở hữu NHÀ Ở trong lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Function HienThiChuHoSoDangKyCapGCNCQNN() As DataTable
        'Hiển thị danh sách Chủ sở hữu NHÀ Ở đăng ký cấp GCN
        Dim Chu As New clsThongTinChuDangKyCapGCN
        Try
            Chu.Connection = strConnection ' Khai báo nhận chuỗi kết nối Database
            Chu.MaHoSoCapGCN = strMaHoSoCapGCN
            dtChuHoSoDangKyCapGCNCQNN.Clear()
            With Me
                .grdvwChuHoSoDangKyCapGCNCQNN.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng ChuSuDung
                dtChuHoSoDangKyCapGCNCQNN = Chu.SelectChuHoSoDangKyCapGCNCQNNByMaHoSoCapGCN()
                'Thêm cột chọn kiểu CheckBoxColumn vào Datatable
                Me.addSelectedColumn(dtChuHoSoDangKyCapGCNCQNN, "Chon", "Chọn")
                'Trình bày dữ liệu lên Grid
                .grdvwChuHoSoDangKyCapGCNCQNN.DataSource = dtChuHoSoDangKyCapGCNCQNN
                'Khi tồn tại bản ghi nhận được
                If dtChuHoSoDangKyCapGCNCQNN.Rows.Count > 0 Then
                    .FormatGridContruction(Me.grdvwChuHoSoDangKyCapGCNCQNN)
                Else
                    .HideAllColumns(grdvwChuHoSoDangKyCapGCNCQNN)
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Chủ sử sở hữu NHÀ Ở đăng ký cấp GCN " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return dtChuHoSoDangKyCapGCNCQNN
    End Function
#End Region

#Region "Danh sách Chủ sở hữu CÔNG TRÌNH đăng ký cấp GCN"
    ''' <summary>
    ''' Hiển thị thông tin Chủ sở hữu NHÀ Ở trong lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Function HienThiChuHoSoDangKyCapGCNTCDN() As DataTable
        'Hiển thị danh sách Chủ sở hữu NHÀ Ở đăng ký cấp GCN
        Dim Chu As New clsThongTinChuDangKyCapGCN
        Try
            'Khai báo nhận chuỗi kết nối Database
            Chu.Connection = strConnection
            Chu.MaHoSoCapGCN = strMaHoSoCapGCN
            dtChuHoSoDangKyCapGCNTCDN.Clear()
            With Me
                .grdvwChuHoSoDangKyCapGCNTCDN.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng
                dtChuHoSoDangKyCapGCNTCDN = Chu.SelectChuHoSoDangKyCapGCNTCDNByMaHoSoCapGCN()
                'Thêm cột chọn kiểu CheckBoxColumn vào Datatable
                Me.addSelectedColumn(dtChuHoSoDangKyCapGCNTCDN, "Chon", "Chọn")
                'Trình bày dữ liệu lên Grid
                .grdvwChuHoSoDangKyCapGCNTCDN.DataSource = dtChuHoSoDangKyCapGCNTCDN
                'Khi tồn tại bản ghi nhận được
                If dtChuHoSoDangKyCapGCNTCDN.Rows.Count > 0 Then
                    .FormatGridContruction(Me.grdvwChuHoSoDangKyCapGCNTCDN)
                Else
                    .HideAllColumns(grdvwChuHoSoDangKyCapGCNTCDN)
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & "Chủ sử sở hữu CÔNG TRÌNH XÂY DỰNG đăng ký cấp GCN" _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return dtChuHoSoDangKyCapGCNTCDN
    End Function
#End Region

    Private Sub ctrlThongTinGCN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            ''Hiển thị danh sách Chủ sử dụng đất đăng ký cấp GCN
            'Me.grdvwChuSuDungDat.DataSource = Me.DanhSachChuSuDung
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

    Private Sub btnDownChuDat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownChuGDCN.Click
        'Thêm thông tin Chủ sử dụng đất đăng ký cấp GCN
        'vào thông tin Đề nghị cấp GCN
        Me.ThemChuDangKyVaoChuDeNghiCapGCN(dtChuHoSoDangKyCapGCNGDCN)
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
    ''' Xóa thông tin Chủ để nghị cấp GCN
    ''' Ở đây ta chỉ xóa thông tin Chủ đề nghị cấp GCN
    ''' trong bảng trung gian
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub XoaThongTinChuDeNghiCapGCN()
        'Xóa thông tin Chủ đề nghị cấp GCN
        'Danh sách Chủ được lựa chọn đề nghị cấp GCN
        Dim dtSelected As New DataTable
        dtSelected = Me.selectedRecords(dtChuDeNghiCapGCN)
        Dim strXML As String = ""
        strXML = Me.CreateXML(dtSelected)
        'Kiểm tra dữ liệu đầu vào
        If strXML = "" Then
            Return
        End If
        'Xóa thông tin Chủ đề nghị cấp GCN 
        Dim ChuDeNghiCapGCN As New clsThongTinChuDeNghiCapGCN
        ChuDeNghiCapGCN.Connection = strConnection
        ChuDeNghiCapGCN.XML = strXML
        ChuDeNghiCapGCN.DeleteChuDeNghiCapGCN()
        Me.ShowData()
    End Sub

    Private Sub btnUpChu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpChu.Click
        'Xóa thông tin Chủ đề nghị cấp GCN 
        Me.XoaThongTinChuDeNghiCapGCN()
    End Sub

    Private Sub grdvwChuDeNghiCapGCN_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwChuDeNghiCapGCN.CellMouseClick
        'Trường hợp người dùng Check vào mục chọn
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Me.checkColumn(grdvwChuDeNghiCapGCN, e.RowIndex, e.ColumnIndex)
        End If
    End Sub

    Private Sub grdvwChuSoHuuNhaO_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwChuHoSoDangKyCapGCNCQNN.CellMouseClick
        'Trường hợp người dùng Check vào mục chọn
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Me.checkColumn(grdvwChuHoSoDangKyCapGCNCQNN, e.RowIndex, e.ColumnIndex)
        End If
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

    Private Sub btnDownChuNhaO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownChuCQNN.Click
        'Thêm thông tin Chủ sở hữu nhà ở đăng ký cấp GCN
        'vào thông tin Đề nghị cấp GCN
        Me.ThemChuDangKyVaoChuDeNghiCapGCN(dtChuHoSoDangKyCapGCNCQNN)
    End Sub

    Private Sub grdvwChuSoHuuCongTrinhXayDung_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwChuHoSoDangKyCapGCNTCDN.CellMouseClick
        'Trường hợp người dùng Check vào mục chọn
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Me.checkColumn(grdvwChuHoSoDangKyCapGCNTCDN, e.RowIndex, e.ColumnIndex)
        End If
    End Sub
    Private Sub btnDownChuCongTrinhXayDung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownChuTCDN.Click
        'Thêm thông tin Chủ sở hữu công trình xây dựng đăng ký cấp GCN
        'vào thông tin Đề nghị cấp GCN
        Me.ThemChuDangKyVaoChuDeNghiCapGCN(dtChuHoSoDangKyCapGCNTCDN)
    End Sub

    ''' <summary>
    ''' Thêm thông tin Chủ đăng ký cấp GCN vào thông tin 
    ''' Chủ Đề nghị In, cấp GCN
    ''' </summary>
    ''' <param name="dtChuDangKy">Danh sách Chủ kê khai đăng ký đề nghị In, Cấp GCN</param>
    ''' <remarks></remarks>
    Private Sub ThemChuDangKyVaoChuDeNghiCapGCN(ByVal dtChuDangKy As DataTable)
        'Danh sách Chủ được lựa chọn đề nghị cấp GCN
        Dim dtSelected As New DataTable
        dtSelected = Me.selectedRecords(dtChuDangKy)
        Dim strXML As String = ""
        strXML = Me.CreateXML(dtSelected)
        'Kiểm tra dữ liệu đầu vào
        If strXML = "" Then
            Return
        End If
        'Thêm thông tin Chủ đề nghị cấp GCN 
        Dim ChuDeNghiCapGCN As New clsThongTinChuDeNghiCapGCN
        ChuDeNghiCapGCN.Connection = strConnection
        ChuDeNghiCapGCN.XML = strXML
        ''Thêm MHSCGCN
        'ChuDeNghiCapGCN.MaHoSoCapGCN = strMaHoSoCapGCN
        ChuDeNghiCapGCN.InsertChuDeNghiCapGCN()
        Me.ShowData()
    End Sub

    Private Sub btnDownChuSoHuuRungCay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Thêm thông tin Chủ sở hữu Rừng cây đăng ký cấp GCN
        'vào thông tin Đề nghị cấp GCN
        Me.ThemChuDangKyVaoChuDeNghiCapGCN(dtChuSoHuuRungCay)
    End Sub

    Private Sub btnDownChuSoHuuCayLauNam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Thêm thông tin Chủ sở hữu Cây lâu năm đăng ký cấp GCN
        'vào thông tin Đề nghị cấp GCN
        Me.ThemChuDangKyVaoChuDeNghiCapGCN(dtChuSoHuuCayLauNam)
    End Sub

    Private Sub btnUpChu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpChu2.Click
        'Xóa thông tin Chủ đề nghị cấp GCN 
        Me.XoaThongTinChuDeNghiCapGCN()
    End Sub

    Private Sub btnUpChu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpChu3.Click
        'Xóa thông tin Chủ đề nghị cấp GCN 
        Me.XoaThongTinChuDeNghiCapGCN()
    End Sub
End Class
