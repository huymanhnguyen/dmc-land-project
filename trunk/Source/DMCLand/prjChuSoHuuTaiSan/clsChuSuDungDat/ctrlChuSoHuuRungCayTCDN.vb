Imports System.Windows.Forms
Imports System.Drawing
Imports DMC.Components

Public Class ctrlChuSoHuuRungCayTCDN
    'Khai báo biến xác định hành động thao tác cơ sở dữ liệu
    Private shortAction As Short = 0
    Private strMaTaiSan As String = ""
    Private dtChuTCDN As New DataTable
    'Khai báo biến nhận tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã 
    Private strMaChu As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Tên đơn vị hành chính
    Public WriteOnly Property TenDonViHanhChinh() As String
        Set(ByVal value As String)
            strTenDonViHanhChinh = value
        End Set
    End Property
    'Mã Rừng cây
    Public WriteOnly Property MaTaiSan() As String
        Set(ByVal value As String)
            strMaTaiSan = value
        End Set
    End Property
    'Mã Chủ sở hữu Rừng cây
    Public WriteOnly Property MaChu() As String
        Set(ByVal value As String)
            strMaChu = value
        End Set
    End Property


    Public Sub AddColumnsToChucDoanhNghiep()
        Dim txtClnMaDoiTuong As New DataGridViewTextBoxColumn
        Dim txtClnHoTen As New DataGridViewTextBoxColumn
        Dim txtClnSoDinhDanh As New DataGridViewTextBoxColumn
        Dim dtpNgayCapDinhDanh As New clsComponents.CalendarColumn
        Dim txtClnNoiCapDinhDanh As New DataGridViewTextBoxColumn
        Dim txtClnDiaChi As New DataGridViewTextBoxColumn
        Try
            'Mã đối tượng
            With txtClnMaDoiTuong
                .HeaderText = "Mã đối tượng"
                .Name = "KyHieu"
                .Width = 120
            End With
            'Họ và tên
            With txtClnHoTen
                .HeaderText = "Tên"
                .Name = "HoTen"
                .Width = 100
            End With
            'Nam sinh
            'So dinh danh
            With txtClnSoDinhDanh
                .HeaderText = "Số định GPKD"
                .Name = "SoDinhDanh"
                .Width = 100
            End With
            'Ngay cap dinh danh
            With dtpNgayCapDinhDanh
                .HeaderText = "Ngày cấp GPKD"
                .Name = "NgayCapDinhDanh"
                .Width = 130
            End With
            'Noi cap dinh danh
            With txtClnNoiCapDinhDanh
                .HeaderText = "Nơi cấp GPKD"
                .Name = "NoiCapDinhDanh"
                .Width = 130
            End With
            'Dai chi thuong chu
            With txtClnDiaChi
                .HeaderText = "Địa chỉ"
                .Name = "DiaChi"
                .Width = 130
            End With
            'Add all to DataGridView
            With grdvwTChucDNghiep
                '.GridColor = Color.WhiteSmoke
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Add columns to Grid
                .Columns.Add(txtClnMaDoiTuong)
                .Columns.Add(txtClnHoTen)
                .Columns.Add(txtClnSoDinhDanh)
                .Columns.Add(dtpNgayCapDinhDanh)
                .Columns.Add(txtClnNoiCapDinhDanh)
                .Columns.Add(txtClnDiaChi)
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Chủ sở hữu Rừng cây " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub HideAllColumns(ByRef grdvw As DataGridView)
        'Ẩn tất cả các cột trên Grid
        With grdvw
            For i As Integer = 0 To (.Columns.Count - 1)
                .Columns(i).Visible = False
            Next
            .RowHeadersVisible = False
        End With
    End Sub

    Private Sub FormatGridContruction()

        Try
            With Me.grdvwTChucDNghiep
                Me.HideAllColumns(grdvwTChucDNghiep)
                'Chỉ hiển thị những cột cần thiết
                'Mã đối tượng
                With .Columns("KyHieu")
                    .Visible = True
                    .HeaderText = "Mã đối tượng"
                    .Width = 120
                End With
                'Họ và tên
                With .Columns("HoTen")
                    .Visible = True
                    .HeaderText = "Tên"
                    .Width = 100
                End With
                'Số định danh
                With .Columns("SoDinhDanh")
                    .Visible = True
                    .HeaderText = "Số định GPKD"
                    .Width = 100
                End With
                'Ngày cấp định danh
                With .Columns("NgayCap")
                    .Visible = True
                    .HeaderText = "Ngày cấp GPKD"
                    .Width = 130
                End With
                'Nơi cấp định danh
                With .Columns("NoiCap")
                    .Visible = True
                    .HeaderText = "Nơi cấp GPKD"
                    .Width = 130
                End With
                'Địa chỉ thường trú
                With .Columns("DiaChi")
                    .Visible = True
                    .HeaderText = "Địa chỉ thường chú"
                    .Width = 130
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
            MsgBox(" Chủ sở hữu Rừng cây - Tổ chức, Doanh nghiệp " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        strMaChu = ""
        'Kiểm tra xem người dùng đã chọn tài sản chưa
        If strMaTaiSan = "" Then
            System.Windows.Forms.MessageBox.Show("Bạn phải lựa chọn Chủ sở hữu Rừng cây", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        With Me
            'Thiết lập trạng thái ban đầu
            .TrangThaiBanDau()
            'Xác định hành động thêm mới Chủ sử dụng
            shortAction = 1
            'Thiết lập trạng thái chức năng
            .TrangThaiChucNang(True)
            'Hiển thị Form tra cứu
            TraCuu()
        End With
    End Sub
    ''' <summary>
    ''' Hiển thị thông tin Chủ sở hữu Rừng cây lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        'Khai báo và khởi tạo đối tượng
        Dim ChuSoHuu As New DMC.Land.ChuSoHuuTaiSan.clsChuSoHuu
        dtChuTCDN.Clear()
        'Gán giá trị cho các thuộc tính đối với trường hợp truy vấn
        Try
            'Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu
            If (strConnection = "") Then
                MessageBox.Show("Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Khai báo nhận chuỗi kết nối Database
            ChuSoHuu.Connection = strConnection
            ChuSoHuu.MaChuSoHuu = ""
            ChuSoHuu.MaTaiSan = strMaTaiSan

            With Me
                '.grdvwTChucDNghiep.RowCount = 0
                .grdvwTChucDNghiep.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng ChuSoHuu
                If ChuSoHuu.SelectChuSoHuuRungCayByTCDN(dtChuTCDN) = "" Then
                    'Trình bày dữ liệu lên grdvwHoGiaDinhCaNhan
                    'Hiển thị bản ghi
                    .grdvwTChucDNghiep.DataSource = dtChuTCDN
                    'Định dạng các cột trong Grid
                    If dtChuTCDN.Rows.Count > 0 Then
                        .FormatGridContruction()
                    Else
                        .HideAllColumns(grdvwTChucDNghiep)
                    End If
                End If
            End With
            'Thiết đặt trạng thái ban đầu
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Đối tượng TỔ CHỨC, DOANH NGHIỆP " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            'If blnCapNhat Then
            .grdvwTChucDNghiep.BackgroundColor = Color.White
            'Else
            '    .grdvwGDCN.BackgroundColor = Color.LightYellow
            'End If
            .txtDiaChi.ReadOnly = Not blnCapNhat
            .txtTen.ReadOnly = Not blnCapNhat
            .txtMaDoiTuong.ReadOnly = Not blnCapNhat
            .txtNoiCap.ReadOnly = Not blnCapNhat
            .txtSoDinhDanh.ReadOnly = Not blnCapNhat
            .DTPNgayCap.Enabled = blnCapNhat
            If blnCapNhat Then
                .txtDiaChi.BackColor = Color.White
                .txtTen.BackColor = Color.White
                .txtMaDoiTuong.BackColor = Color.White
                .txtNoiCap.BackColor = Color.White
                .txtSoDinhDanh.BackColor = Color.White
            Else
                .txtDiaChi.BackColor = Color.LightYellow
                .txtTen.BackColor = Color.LightYellow
                .txtMaDoiTuong.BackColor = Color.LightYellow
                .txtNoiCap.BackColor = Color.LightYellow
                .txtSoDinhDanh.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau() 'Optional ByVal blnClearGrid As Boolean = False)
        With Me
            .HideAllColumns(grdvwTChucDNghiep)
            'Thiet lap tren Form nhap lieu
            .txtDiaChi.Text = ""
            .txtTen.Text = ""
            .txtMaDoiTuong.Text = ""
            .txtNoiCap.Text = ""
            .txtSoDinhDanh.Text = ""
            .DTPNgayCap.Value = Date.Now
            .DTPNgayCap.Checked = False
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            '.btnSua.Enabled = Not blnStartEdited
            .btnXoa.Enabled = Not blnStartEdited
            .btnCapNhat.Enabled = Not blnStartEdited
            .btnGhi.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            ' .btnTraCuu.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnGhi.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
                ' .btnTraCuu.Enabled = Not blnStartEdited
            End If
        End With
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        'Kiểm tra dữ liệu nhập vào
        If txtMaDoiTuong.Text.Trim = "" Then
            MsgBox("Bạn phải nhập Mã đối tượng sở hữu Rừng cây!", MsgBoxStyle.Information, "DMCLand")
            txtMaDoiTuong.Focus()
            Exit Sub
        End If
        With Me
            'Cập nhật thông tin Chủ sở hữu (Thuộc nhóm đối tượng Tổ chức, doanh nghiệp)
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
        strMaChu = ""
        strError = ""
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            If strMaTaiSan <> "" Then
                .ShowData()
            End If
            'Xoa du lieu tren Form
            .TrangThaiBanDau()
            'Khởi tạo giá trị ban đầu cho biến dùng chung
            strMaChu = ""
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
    End Sub


    Public Sub TraCuu()
        Dim TraCuuTCDN As New frmChuTCDN
        With TraCuuTCDN.CtrlChuTCDN
            .Connection = strConnection
            'Cần kiểm tra lại xem có thêm thuộc tính MaTaiSan vào ko?
            '.MaTaiSan = strMaTaiSan
            'Hiển thị Form giữa màn hình
            TraCuuTCDN.StartPosition = FormStartPosition.CenterScreen
            TraCuuTCDN.ShowDialog()
            Try
                strMaChu = .MaChu
                'Chắc chắn rằng có một bản ghi được lựa chọn 
                If (.dtChuSelect.Rows.Count <> 1) Then
                    Exit Sub
                End If
                With .dtChuSelect.Rows(0)
                    txtMaDoiTuong.Text = .Item("DoiTuongSDD").ToString()
                    txtTen.Text = .Item("HoTen").ToString()
                    txtSoDinhDanh.Text = .Item("SoDinhDanh").ToString()
                    If IsDate(.Item("NgayCap").ToString) Then
                        DTPNgayCap.Value = Convert.ToDateTime(.Item("NgayCap").ToString)
                        DTPNgayCap.Checked = True
                    Else
                        DTPNgayCap.Value = Date.Now
                        DTPNgayCap.Checked = False
                    End If

                    txtNoiCap.Text = .Item("NoiCap").ToString
                End With

            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show("Lỗi: " & ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With
    End Sub
    ''' <summary>
    ''' Xóa Chủ sở hữu Rừng cây (bảng trung gian tblChuSoHuu)
    ''' Note: Không phải xóa Chủ (tblChu)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Kiểm tra dữ liệu đầu vào
        'Kiểm tra xem người dùng đã chọn Chủ sở hữu cần xóa chưa?
        If strMaChu = "" Then
            System.Windows.Forms.MessageBox.Show("KHÔNG có CHỦ SỞ HỮU nào được lựa chọn", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        With Me
            'Xác định hành động Xóa Chủ sở hữu
            Me.shortAction = 3
            'Xóa Chủ sở hữu (Thuộc nhóm đối tượng Tổ chức, doanh nghiệp)
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
        strMaChu = ""
        'Gắn giá trị mặc định cho biến kiểm tra lỗi
        strError = ""
    End Sub

    ''' <summary>
    ''' Thêm Chủ sở hữu Tài sản
    ''' Note: Không phải cập nhật Chủ)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateData()
        'Khai bao va khoi tao doi tuong clsChuSoHuu
        Dim ChuSoHuu As New DMC.Land.ChuSoHuuTaiSan.clsChuSoHuu
        Try
            'Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu
            If (strConnection = "") Then
                MessageBox.Show("Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            'Chắc chắn rằng tồn tại Mã Tài sản
            If (strMaTaiSan = "") Then
                strError = "Không tìm thấy Mã Rừng cây "
                MessageBox.Show("Lỗi: " & strError, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Chắc chắn rằng tồn tại Mã chủ sở hữu
            If (strMaChu = "") Then
                strError = "Không tìm thấy Mã Chủ sở hữu Rừng cây"
                MessageBox.Show("Lỗi: " & strError, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Khai báo nhận chuỗi kết nối Database
            ChuSoHuu.Connection = strConnection
            'Gán giá trị cho thuộc tính của đối tượng Rừng cây
            'Mã Rừng cây ()
            ChuSoHuu.MaTaiSan = strMaTaiSan
            'Mã Chủ Rừng cây ()
            ChuSoHuu.MaChuSoHuu = strMaChu
            Dim str As String = ""
            Dim strUpdateResults As String = ""
            'Xác định kiểu cập nhật
            'Trường hợp thêm mới Chủ sở hữu Rừng cây
            If (Me.shortAction = 1) Then
                strUpdateResults = ChuSoHuu.InsertChuSoHuuRungCay(str)
                'Trường hợp Xóa Chủ Sở hữu Rừng cây
            ElseIf (Me.shortAction = 3) Then
                strUpdateResults = ChuSoHuu.DeleteChuSoHuuRungCay(str)
            End If
            'Nếu cập nhật thành công
            If strUpdateResults = "" Then
                Me.TrangThaiBanDau()
            End If
            strError = ChuSoHuu.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Đối tượng TỔ CHỨC, DOANH NGHIỆP " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub grdvwTChucDNghiep_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles grdvwTChucDNghiep.CellFormatting
        'If Me.grdvwTChucDNghiep.Columns(e.ColumnIndex).Name _
        '    = "NgayCapDinhDanh" Then
        '    If e.Value IsNot Nothing Then
        '        e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
        '    End If
        'End If
    End Sub

    Private Sub grdvwTChucDNghiep_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwTChucDNghiep.CellMouseClick
        'Chỉ thực thi khi người dùng chọn chuột TRÁI
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khoi tao doi tuong
        Dim ChuTCDN As New DMC.Land.Chu.clsChuTCDN
        If e.RowIndex >= 0 Then
            Try
                'Hiển thị thông tin Chủ sở hữu Rừng cây ()
                With dtChuTCDN.Rows(e.RowIndex)
                    ChuTCDN.DiaChi = .Item("DiaChi").ToString
                    ChuTCDN.DoiTuongSDD = .Item("DoiTuongSDD").ToString
                    ChuTCDN.HoTen = .Item("HoTen").ToString
                    ChuTCDN.MaChu = .Item("MaChu").ToString
                    strMaChu = ChuTCDN.MaChu
                    ChuTCDN.NgayCap = .Item("NgayCap").ToString
                    ChuTCDN.NoiCap = .Item("NoiCap").ToString
                    ChuTCDN.SoDinhDanh = .Item("SoDinhDanh").ToString
                End With

                'Hiển thị bản ghi tương ứng lên Form
                With Me
                    .txtDiaChi.Text = ChuTCDN.DiaChi
                    .txtTen.Text = ChuTCDN.HoTen
                    .txtMaDoiTuong.Text = ChuTCDN.DoiTuongSDD
                    .txtNoiCap.Text = ChuTCDN.NoiCap
                    .txtSoDinhDanh.Text = ChuTCDN.SoDinhDanh
                    If IsDate(ChuTCDN.NgayCap) Then
                        .DTPNgayCap.Value = ChuTCDN.NgayCap
                        .DTPNgayCap.Checked = True
                    Else
                        .DTPNgayCap.Value = Date.Now
                        .DTPNgayCap.Checked = False
                    End If

                End With

            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Đối tượng TỔ CHỨC, DOANH NGHIỆP" _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub ctrlChuSuDungTCDN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                With .DTPNgayCap
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                End With
                'Trạng thái cập nhật
                .TrangThaiCapNhat()
                'Trạng thái chức năng
                .TrangThaiChucNang(True, True)
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Đối tượng TỔ CHỨC, DOANH NGHIỆP " _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

End Class
