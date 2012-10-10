Imports System.Windows.Forms
Imports System.Math
Imports System.Drawing
Public Class ctrlHoiDongXetDuyet
    'Khai báo biến xác định hành động thao tác cơ sở dữ liệu
    Private shFlag As Short = 0
    Private strMaHoSoCapGCN As String = ""
    Private dtHoiDongXetDuyet As New DataTable
    ''Khai báo biến nhận tên đơn vị hành chính
    'Private strTenDonViHanhChinh As String = ""
    'Khai báo nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã chủ sử dụng đất
    Private strMaNguoiXetDuyet As String = ""
    Private strMaDVHC As String = ""
    Private strServerName As String = ""
    Private strDatabase As String = ""
    Private strUID As String = ""
    Private strUpass As String = ""
    Private indexGrid As Integer = 0
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
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    ''Khai báo thuộc tính nhận Tên đơn vị hành chính
    'Public WriteOnly Property TenDonViHanhChinh() As String
    '    Set(ByVal value As String)
    '        strTenDonViHanhChinh = value
    '    End Set
    'End Property
    'Mã Hồ sơ cấp GCN
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
    Public Property DatabaseName() As String
        Get
            Return strDatabase
        End Get
        Set(ByVal value As String)
            strDatabase = value
        End Set
    End Property
    Public Property ServerName() As String
        Get
            Return strServerName
        End Get
        Set(ByVal value As String)
            strServerName = value
        End Set
    End Property
    Public Property UID() As String
        Get
            Return strUID
        End Get
        Set(ByVal value As String)
            strUID = value
        End Set
    End Property
    Public Property UPass() As String
        Get
            Return strUpass
        End Get
        Set(ByVal value As String)
            strUpass = value
        End Set
    End Property
    Public Property MaDVHC() As String
        Get
            Return strMaDVHC
        End Get
        Set(ByVal value As String)
            strMaDVHC = value
        End Set

    End Property
    'Mã Chủ sử dụng đất
    Public WriteOnly Property MaNguoiXetDuyet() As String
        Set(ByVal value As String)
            strMaNguoiXetDuyet = value
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
            '.RowHeadersVisible = False
        End With
    End Sub

    Private Sub FormatGridContruction()
        Try
            With Me.grdvwHoiDongXetDuyet
                'Ẩn tất cả các cột
                Me.HideAllColumns(grdvwHoiDongXetDuyet)
                'Họ tên 
                With .Columns("HoTen")
                    .HeaderText = "Họ tên"
                    .Width = 200
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Chức danh
                With .Columns("ChucDanh")
                    .HeaderText = "Chức danh"
                    .Width = 250
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Chức danh
                With .Columns("ChucVu")
                    .HeaderText = "Chức vụ"
                    .Width = 250
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Giới tính
                With .Columns("GioiTinh")
                    .HeaderText = "Giới tính"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .GridColor = Color.WhiteSmoke
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                '.RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hội đồng xét duyệt " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub btnTraCuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraCuu.Click
        strMaNguoiXetDuyet = ""
        With Me
            'Thiết lập trạng thái ban đầu
            .TrangThaiBanDau()
            'Xác định hành động thêm mới Chủ sử dụng
            shFlag = 1
            'Thiết lập trạng thái chức năng
            .TrangThaiChucNang(True)
            'Hiển thị Form tra cứu
            Me.TraCuu()
        End With
    End Sub
    ''' <summary>
    ''' Hiển thị thông tin Chủ sử dụng đất trong lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox1.Enabled = True
        Else
            Me.GroupBox1.Enabled = False

        End If
        'Khai báo và khởi tạo đối tượng Chủ hồ sơ cấp GCN
        Dim HoiDongXetDuyet As New DMC.Land.HoiDongXetDuyet.clsHoiDongXetDuyet
        'Gán giá trị cho các thuộc tính đối với trường hợp truy vấn
        Try
            'Khai báo nhận chuỗi kết nối Database
            HoiDongXetDuyet.Connection = strConnection
            HoiDongXetDuyet.MaNguoiXetDuyet = ""
            HoiDongXetDuyet.MaHoSoCapGCN = strMaHoSoCapGCN
            dtHoiDongXetDuyet.Clear()
            With Me
                .grdvwHoiDongXetDuyet.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng HoiDongXetDuyet
                If HoiDongXetDuyet.SelectHoiDongXetDuyet(dtHoiDongXetDuyet) = "" Then
                    'Trình bày dữ liệu lên gridView
                    .grdvwHoiDongXetDuyet.DataSource = dtHoiDongXetDuyet

                    'Khi tồn tại bản ghi nhận được
                    If dtHoiDongXetDuyet.Rows.Count > 0 Then
                        .FormatGridContruction()
                    Else
                        .HideAllColumns(grdvwHoiDongXetDuyet)
                    End If
                    CtrFilterGrid1.MyGrid = grdvwHoiDongXetDuyet
                    CtrFilterGrid1.MydataTable = dtHoiDongXetDuyet
                    CtrFilterGrid1.TaoContol()
                End If
            End With
            If grdvwHoiDongXetDuyet.Rows.Count > 0 Then
                grdvwHoiDongXetDuyet.Rows(0).Selected = False
            Else
                Return
            End If

        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Hội đồng xét duyệt " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .grdvwHoiDongXetDuyet.BackgroundColor = Color.White
            .cmbGioiTinh.Enabled = blnCapNhat
            .txtHoTen.ReadOnly = Not blnCapNhat
            .txtChucDanh.ReadOnly = Not blnCapNhat
            .txtChucVu.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .cmbGioiTinh.BackColor = Color.White
                .txtChucDanh.BackColor = Color.White
                .txtChucVu.BackColor = Color.White
                .txtHoTen.BackColor = Color.White
            Else
                cmbGioiTinh.BackColor = Color.LightYellow
                .txtChucDanh.BackColor = Color.LightYellow
                .txtChucVu.BackColor = Color.LightYellow
                .txtHoTen.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        With Me
            'Thiết lập trên Form nhập liệu
            .cmbGioiTinh.Text = ""
            .txtChucDanh.Text = ""
            .txtChucVu.Text = ""
            .txtHoTen.Text = ""
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox1.Enabled = True
                '.btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnTraCuu.Enabled = Not blnStartEdited
                .btnCapNhat.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnCapNhat.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                End If
            Else
                Me.GroupBox1.Enabled = False

            End If
           
        End With
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        'Kiểm tra dữ liệu nhập vào
        If txtHoTen.Text.Trim = "" Then
            MsgBox("Bạn phải nhập Tên người xét duyệt!", MsgBoxStyle.Information, "DMCLand")
            txtHoTen.Focus()
            Exit Sub
        End If
        With Me
            'Cập nhật thông tin Hội đồng xét duyệt
            .UpdateData()
            'Hiển thị thông tin lên Form
            .ShowData()
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        'Khởi tạo giá trị cho biến dùng chung
        strMaNguoiXetDuyet = ""
        strError = ""
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            If strMaHoSoCapGCN <> "" Then
                .ShowData()
            End If
            'Xoa du lieu tren Form
            .TrangThaiBanDau()
            'Khởi tạo giá trị ban đầu cho biến dùng chung
            strMaNguoiXetDuyet = ""
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
    End Sub


    Public Sub TraCuu()
        Dim TuDienNguoiXetDuyet As New frmTuDienNguoiXetDuyet
        With TuDienNguoiXetDuyet.CtrlTuDienNguoiXetDuyet
            .Connection = strConnection
            'Cần kiểm tra lại xem có thêm thuộc tính MaHoSoCapGCN vào ko?
            '.MaHoSoCapGCN = strMaHoSoCapGCN
            TuDienNguoiXetDuyet.CtrlTuDienNguoiXetDuyet.showData()
            TuDienNguoiXetDuyet.ShowDialog()
            Try
                strMaNguoiXetDuyet = .Ma

                'Chắc chắn rằng có một bản ghi được lựa chọn '
                If (.dtTuDienNguoiXetDuyetSelect.Rows.Count <> 1) Then
                    Exit Sub
                End If
                With .dtTuDienNguoiXetDuyetSelect.Rows(0)
                    txtChucDanh.Text = .Item("ChucDanh").ToString()
                    txtChucVu.Text = .Item("ChucVu").ToString()
                    txtHoTen.Text = .Item("HoTen").ToString()
                    If (.Item("GioiTinh").ToString() = "True") Then
                        cmbGioiTinh.Text = "Ông"
                    ElseIf (.Item("GioiTinh").ToString() = "False") Then
                        cmbGioiTinh.Text = "Bà"
                    Else
                        cmbGioiTinh.Text = ""
                    End If
                End With
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show("Lỗi: " & ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With
    End Sub
    ''' <summary>
    ''' Xóa Người trong hội đồng xét duyệt (bảng trung gian tblHoiDongXetDuyet)
    ''' Note: Không phải xóa Người xét duyệt trong bảng từ điển (tblTuDienNguoiXetDuyet)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Kiểm tra dữ liệu đầu vào
        With Me
            'Xác định hành động Xóa Người xét duyệt trong Hội đồng xét duyệt
            Me.shFlag = 3
            'Xóa Người xét duyệt trong Hội đồng xét duyệt
            .UpdateData()
            'Hiển thị dữ liệu lên Form
            Me.ShowData()
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        'Khởi tạo giá trị biến dùng chung
        strMaNguoiXetDuyet = ""
        'Gắn giá trị mặc định cho biến kiểm tra lỗi
        strError = ""
    End Sub
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDVHC
        clsNhatky.NghiepVu = "Cập nhật hạng mục công trình"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    ''' <summary>
    ''' Thêm Người xét duyệt vào hội đồng xét duyệt
    ''' Note: Không phải cập nhật Từ điển người xét duyệt)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateData()
        'Khai bao loi
        'Khai bao va khoi tao doi tuong clsHoiDongXetDuyet
        Dim HoiDongXetDuyet As New DMC.Land.HoiDongXetDuyet.clsHoiDongXetDuyet
        Try
            'Khai báo nhận chuỗi kết nối Database
            HoiDongXetDuyet.Connection = strConnection
            'Chắc chắn rằng tồn tại Mã Hồ sơ cấp GCN
            If (strMaHoSoCapGCN = "") Then
                strError = "Không tìm thấy Mã Hồ sơ cấp GCN"
                Exit Sub
            End If
            'Chắc chắn rằng tồn tại Mã người xét duyệt
            If (strMaNguoiXetDuyet = "") Then
                strError = "Không tìm thấy Mã Người xét duyệt"
                Exit Sub
            End If
            'GÁN GIÁ TRỊ CHO THUỘC TÍNH CỦA ĐỐI TƯỢNG HỘI ĐỒNG XÉT DUYỆT
            'Mã Hồ sơ cấp GCN
            HoiDongXetDuyet.MaHoSoCapGCN = strMaHoSoCapGCN
            'Mã Người xét duyệt
            HoiDongXetDuyet.MaNguoiXetDuyet = strMaNguoiXetDuyet
            Dim str As String = ""
            Dim strUpdateResults As String = ""
            'Xác định kiểu cập nhật
            'Trường hợp thêm mới Người vào hội đồng xét duyệt
            HoiDongXetDuyet.Index = grdvwHoiDongXetDuyet.RowCount
            If (Me.shFlag = 1) Then
                strUpdateResults = HoiDongXetDuyet.InsertData(str)
                NhatKyNguoiDung("Thêm", "Thêm danh sách hội đồng xét duyệt")
                'Trường hợp Xóa Chủ Hồ sơ cấp GCN
            ElseIf (Me.shFlag = 3) Then
                strUpdateResults = HoiDongXetDuyet.DeleteData(str)
                NhatKyNguoiDung("Sửa", "Sửa danh sách hội đồng xét duyệt")
            End If
            'Nếu cập nhật thành công
            If strUpdateResults = "" Then
                Me.TrangThaiBanDau()
            End If
            strError = HoiDongXetDuyet.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Hội đồng xét duyệt " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub UpdateViTri(ByVal index)
        'Khai bao loi
        'Khai bao va khoi tao doi tuong clsHoiDongXetDuyet
        Dim HoiDongXetDuyet As New DMC.Land.HoiDongXetDuyet.clsHoiDongXetDuyet
        Try
            'Khai báo nhận chuỗi kết nối Database
            HoiDongXetDuyet.Connection = strConnection
            'Chắc chắn rằng tồn tại Mã Hồ sơ cấp GCN
            If (strMaHoSoCapGCN = "") Then
                strError = "Không tìm thấy Mã Hồ sơ cấp GCN"
                Exit Sub
            End If
            'Chắc chắn rằng tồn tại Mã người xét duyệt
            If (strMaNguoiXetDuyet = "") Then
                strError = "Không tìm thấy Mã Người xét duyệt"
                Exit Sub
            End If
            'GÁN GIÁ TRỊ CHO THUỘC TÍNH CỦA ĐỐI TƯỢNG HỘI ĐỒNG XÉT DUYỆT
            'Mã Hồ sơ cấp GCN
            HoiDongXetDuyet.MaHoSoCapGCN = strMaHoSoCapGCN
            'Mã Người xét duyệt
            HoiDongXetDuyet.MaNguoiXetDuyet = strMaNguoiXetDuyet
            Dim str As String = ""
            Dim strUpdateResults As String = ""
            'Xác định kiểu cập nhật
            'Trường hợp thêm mới Người vào hội đồng xét duyệt
            HoiDongXetDuyet.Index = index
            strUpdateResults = HoiDongXetDuyet.UpdateViTrData(str)
            'Nếu cập nhật thành công
            If strUpdateResults = "" Then
                Me.TrangThaiBanDau()
            End If
            strError = HoiDongXetDuyet.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Hội đồng xét duyệt " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub UpdateViTri1(ByVal index)
        'Khai bao loi
        'Khai bao va khoi tao doi tuong clsHoiDongXetDuyet
        Dim HoiDongXetDuyet As New DMC.Land.HoiDongXetDuyet.clsHoiDongXetDuyet
        Try
            'Khai báo nhận chuỗi kết nối Database
            HoiDongXetDuyet.Connection = strConnection
            'Chắc chắn rằng tồn tại Mã Hồ sơ cấp GCN
            If (strMaHoSoCapGCN = "") Then
                strError = "Không tìm thấy Mã Hồ sơ cấp GCN"
                Exit Sub
            End If
            'Chắc chắn rằng tồn tại Mã người xét duyệt
            If (strMaNguoiXetDuyet = "") Then
                strError = "Không tìm thấy Mã Người xét duyệt"
                Exit Sub
            End If
            'GÁN GIÁ TRỊ CHO THUỘC TÍNH CỦA ĐỐI TƯỢNG HỘI ĐỒNG XÉT DUYỆT
            'Mã Hồ sơ cấp GCN
            HoiDongXetDuyet.MaHoSoCapGCN = strMaHoSoCapGCN
            'Mã Người xét duyệt
            HoiDongXetDuyet.MaNguoiXetDuyet = strMaNguoiXetDuyet
            Dim str As String = ""
            Dim strUpdateResults As String = ""
            'Xác định kiểu cập nhật
            'Trường hợp thêm mới Người vào hội đồng xét duyệt
            HoiDongXetDuyet.Index = index
            strUpdateResults = HoiDongXetDuyet.UpdateViTrData1(str)
            'Nếu cập nhật thành công
            If strUpdateResults = "" Then
                Me.TrangThaiBanDau()
            End If
            strError = HoiDongXetDuyet.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Hội đồng xét duyệt " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub ctrlHoiDongXêtDuyet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                'Trang thai cap nhat
                .TrangThaiCapNhat()
                'Trang thai chuc nang
                .TrangThaiChucNang(True, True)
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Hội đồng xét duyệt " _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub grdvwHoiDongXetDuyet_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwHoiDongXetDuyet.CellMouseClick

        'Chỉ thực thi khi người dùng chọn chuột trái
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khởi tạo đối tượng
        Dim TuDienCanBoNghiepVu As New DMC.Land.TuDienCanBoNhiepVu.clsTuDienCanBoNghiepVu
        If e.RowIndex >= 0 Then
            Try
                'Gán thông tin Người xét duyệt vừa lựa chọn vào thuộc tính tương ứng của đối tượng
                'Chủ sử dụng thuộc nhóm Cơ quan nhà nước
                With dtHoiDongXetDuyet.Rows(e.RowIndex)
                    TuDienCanBoNghiepVu.ChucDanh = .Item("ChucDanh").ToString
                    If (.Item("GioiTinh").ToString() = "True") Then
                        TuDienCanBoNghiepVu.GioiTinh = "1"
                    ElseIf (.Item("GioiTinh").ToString() = "True") Then
                        TuDienCanBoNghiepVu.GioiTinh = "0"
                    Else
                        TuDienCanBoNghiepVu.GioiTinh = ""
                    End If
                    TuDienCanBoNghiepVu.HoTen = .Item("HoTen").ToString
                    TuDienCanBoNghiepVu.ChucDanh = .Item("ChucDanh").ToString
                    TuDienCanBoNghiepVu.ChucVu = .Item("ChucVu").ToString
                    'Gán Mã Người xét duyệt vừa lựa chọn cho biến dùng chung
                    TuDienCanBoNghiepVu.Ma = .Item("MaNguoiXetDuyet").ToString()
                    strMaNguoiXetDuyet = TuDienCanBoNghiepVu.Ma
                End With
                'Hiển thị thông tin Người xét duyệt vừa lựa chọn lên Form
                With Me
                    If (TuDienCanBoNghiepVu.GioiTinh = "1") Then
                        .cmbGioiTinh.Text = "Nam"
                    ElseIf (TuDienCanBoNghiepVu.GioiTinh = "0") Then
                        .cmbGioiTinh.Text = "Nữ"
                    Else
                        .cmbGioiTinh.Text = ""
                    End If
                    .txtChucDanh.Text = TuDienCanBoNghiepVu.ChucDanh
                    .txtChucVu.Text = TuDienCanBoNghiepVu.ChucVu
                    .txtHoTen.Text = TuDienCanBoNghiepVu.HoTen
                End With
                indexGrid = e.RowIndex
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Hội đồng xét duyệt" _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub btnQuyetDinhThanhLapHoiDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuyetDinhThanhLapHoiDong.Click
        Dim frm As New frmReportQuyetDinhThanhLapHDXD
        With frm.CtrQuyetDinhThanhLapHoiDong1
            .Conection = strConnection
            .MaHoSoCapGCN = strMaHoSoCapGCN
            .MaDVHC = strMaDVHC
            .ctrBienbanXetDuyetHoSoCapGCN_Load()
            frm.StartPosition = FormStartPosition.CenterScreen

            frm.ShowDialog()
        End With
    End Sub

    Private Sub cmdLen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLen.Click

        'dat lai vi tri cho can bo xet duyet co trong danh sach
        If grdvwHoiDongXetDuyet.RowCount > 0 Then
            For ctr As Integer = 0 To grdvwHoiDongXetDuyet.RowCount - 1
                strMaNguoiXetDuyet = grdvwHoiDongXetDuyet.Rows(ctr).Cells("MaNguoiXetDuyet").Value
                UpdateViTri1(ctr)
            Next
            ' doi cho 
            If indexGrid > 0 Then
                strMaNguoiXetDuyet = grdvwHoiDongXetDuyet.Rows(indexGrid - 1).Cells("MaNguoiXetDuyet").Value
                UpdateViTri1(indexGrid)
                strMaNguoiXetDuyet = grdvwHoiDongXetDuyet.Rows(indexGrid).Cells("MaNguoiXetDuyet").Value
                UpdateViTri1(indexGrid - 1)
            End If
            ShowData()
        End If
    End Sub

    Private Sub cmdXuong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXuong.Click
        'dat lai vi tri cho can bo xet duyet co trong danh sach

        Dim fl As Integer
        fl = indexGrid
        If grdvwHoiDongXetDuyet.RowCount > 0 Then
            For ctr As Integer = 0 To grdvwHoiDongXetDuyet.RowCount - 1
                strMaNguoiXetDuyet = grdvwHoiDongXetDuyet.Rows(ctr).Cells("MaNguoiXetDuyet").Value
                UpdateViTri1(ctr)
            Next
            ' doi cho 
            If (indexGrid > 0) Or (indexGrid = 0) Then
                strMaNguoiXetDuyet = grdvwHoiDongXetDuyet.Rows(indexGrid).Cells("MaNguoiXetDuyet").Value
                UpdateViTri1(indexGrid + 1)
                strMaNguoiXetDuyet = grdvwHoiDongXetDuyet.Rows(indexGrid + 1).Cells("MaNguoiXetDuyet").Value
                UpdateViTri1(indexGrid)
            End If
            ShowData()
            grdvwHoiDongXetDuyet.Rows(fl).Selected = True
        End If
    End Sub

    Private Sub cmdLayLai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLayLai.Click
        Dim frm As New frmTuDienHDXD
        With frm
            .Connection = strConnection
            .MaDVHC = strMaDVHC
            .MaHoSoCapGCN = strMaHoSoCapGCN
            .MaNguoiXetDuyet = strMaNguoiXetDuyet
            .ShowData()
            .ShowDialog()
        End With
        ShowData()
    End Sub


    Private Sub grdvwHoiDongXetDuyet_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles grdvwHoiDongXetDuyet.ColumnWidthChanged
        Try
            CtrFilterGrid1.TaoContol()
        Catch ex As Exception

        End Try

    End Sub
End Class
