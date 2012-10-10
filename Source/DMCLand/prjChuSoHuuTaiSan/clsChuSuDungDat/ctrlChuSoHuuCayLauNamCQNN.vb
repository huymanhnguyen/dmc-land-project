Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlChuSoHuuCayLauNamCQNN
    'Khai báo biến xác định hành động thao tác cơ sở dữ liệu
    Private shortAction As Short = 0
    Private strMaTaiSan As String = ""
    Private dtChuSoHuuCQNN As New DataTable
    'Khai báo biến nhận tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã chủ 
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
    'Mã Hồ sơ cấp GCN
    Public WriteOnly Property MaTaiSan() As String
        Set(ByVal value As String)
            strMaTaiSan = value
        End Set
    End Property
    'Mã Chủ 
    Public WriteOnly Property MaChu() As String
        Set(ByVal value As String)
            strMaChu = value
        End Set
    End Property

    Public Sub AddColumnsCoQuanNhaNuoc()
        Dim txtClnMaDoiTuong As New DataGridViewTextBoxColumn
        Dim txtClnHoTen As New DataGridViewTextBoxColumn
        Dim txtClnDiaChi As New DataGridViewTextBoxColumn
        Try
            'Mã đối tượng
            With txtClnMaDoiTuong
                .HeaderText = "Mã đối tượng"
                .Name = "KyHieu"
                .Width = 120
            End With
            'Tên
            With txtClnHoTen
                .HeaderText = "Tên"
                .Name = "HoTen"
                .Width = 100
            End With
            'Địa chỉ thường chú
            With txtClnDiaChi
                .HeaderText = "Địa chỉ"
                .Name = "DiaChi"
                .Width = 130
            End With
            'Add all to DataGridView Ho gia dinh ca nhan
            With grdvwCQuanNNuoc
                '.GridColor = Color.WhiteSmoke
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Chủ sử dụng " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
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
            With Me.grdvwCQuanNNuoc
                Me.HideAllColumns(grdvwCQuanNNuoc)
                'Chỉ hiển thị những cột cần thiết
                'Mã đối tượng
                With .Columns("KyHieu")
                    .Visible = True
                    .HeaderText = "Mã đối tượng"
                    .Width = 120
                End With
                'Tên
                With .Columns("HoTen")
                    .Visible = True
                    .HeaderText = "Tên"
                    .Width = 100
                End With
                'Địa chỉ thường chú
                With .Columns("DiaChi")
                    .Visible = True
                    .HeaderText = "Địa chỉ"
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
            MsgBox(" CHỦ SỞ HỮU - CƠ QUAN NHÀ NƯỚC " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        'Trước khi thêm mới Chủ sở hữu, gán giá trị cho Mã chủ sở hữu bằng rỗng
        strMaChu = ""
        'Kiểm tra xem người dùng đã chọn tài sản chưa
        If strMaTaiSan = "" Then
            System.Windows.Forms.MessageBox.Show("Bạn phải LỰA CHỌN TÀI SẢN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
    ''' Hiển thị thông tin Chủ sở hữu Cây lâu năm trong lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        'Khai báo và khởi tạo đối tượng Chủ tài sản
        Dim ChuSoHuu As New DMC.Land.ChuSoHuuTaiSan.clsChuSoHuu
        dtChuSoHuuCQNN.Clear()
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
                .grdvwCQuanNNuoc.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng ChuSoHuu
                If ChuSoHuu.SelectChuSoHuuCayLauNamByCQNN(dtChuSoHuuCQNN) = "" Then
                    'Trình bày dữ liệu lên gridView
                    'Khi tồn tại bản ghi nhận được
                    'Hiển thị các bản ghi
                    .grdvwCQuanNNuoc.DataSource = dtChuSoHuuCQNN
                    'Định dạng lại các cột của Grid
                    If dtChuSoHuuCQNN.Rows.Count > 0 Then
                        .FormatGridContruction()
                    Else
                        .HideAllColumns(grdvwCQuanNNuoc)
                    End If
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Đối tượng Cơ quan nhà nước " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            'If blnCapNhat Then
            .grdvwCQuanNNuoc.BackgroundColor = Color.White
            'Else
            '    .grdvwGDCN.BackgroundColor = Color.LightYellow
            'End If
            .txtDiaChi.ReadOnly = Not blnCapNhat
            .txtTen.ReadOnly = Not blnCapNhat
            .txtMaDoiTuong.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                .txtDiaChi.BackColor = Color.White
                .txtTen.BackColor = Color.White
                .txtMaDoiTuong.BackColor = Color.White
            Else
                .txtDiaChi.BackColor = Color.LightYellow
                .txtTen.BackColor = Color.LightYellow
                .txtMaDoiTuong.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau() 'Optional ByVal blnClearGrid As Boolean = False)
        With Me
            'If blnClearGrid Then
            '    .grdvwCQuanNNuoc.RowCount = 0
            'End If
            .HideAllColumns(grdvwCQuanNNuoc)
            'Thiet lap tren Form nhap lieu
            .txtDiaChi.Text = ""
            .txtTen.Text = ""
            .txtMaDoiTuong.Text = ""
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
            MsgBox("Bạn phải nhập Mã đối tượng sử dụng đất!", MsgBoxStyle.Information, "DMCLand")
            txtMaDoiTuong.Focus()
            Exit Sub
        End If
        With Me
            'Cập nhật thông tin Chủ sở hữu Cây lâu năm (Hồ gia đình - cá nhân)
            .UpdateData()
            'Hiển thị thông tin Chủ sở hữu Cây lâu năm lên Form
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
        Dim TraCuuCQNN As New frmChuCQNN
        With TraCuuCQNN.CtrlChuCQNN
            .Connection = strConnection
            'Cần kiểm tra lại xem có thêm thuộc tính MaTaiSan vào ko?
            '.MaTaiSan = strMaTaiSan
            'Hiển thị Form giữa màn hình
            TraCuuCQNN.StartPosition = FormStartPosition.CenterScreen
            TraCuuCQNN.ShowDialog()
            Try
                strMaChu = .MaChu
                'Chắc chắn rằng có một bản ghi được lựa chọn 
                If (.dtChuSelect.Rows.Count <> 1) Then
                    Exit Sub
                End If
                With .dtChuSelect.Rows(0)
                    txtMaDoiTuong.Text = .Item("DoiTuongSDD").ToString()
                    txtTen.Text = .Item("HoTen").ToString()
                    txtDiaChi.Text = .Item("DiaChi").ToString()
                End With

            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show("Lỗi: " & ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With
    End Sub
    ''' <summary>
    ''' Xóa Chủ sở Hữu Tài sản (bảng trung gian tblChuSoHuu)
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
            .shortAction = 3
            'Xóa Chủ sở hữu Tài sản (Hộ gia đình cá nhân)
            .UpdateData()
            'Hiển thị dữ liệu lên Form
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
        'Khởi tạo giá trị biến dùng chung
        strMaChu = ""
        'Gắn giá trị mặc định cho biến kiểm tra lỗi
        strError = ""
    End Sub

    ''' <summary>
    ''' Thêm Chủ sở hữu Cây lâu năm
    ''' Note: Không phải cập nhật Chủ trong bảng Từ điển Chủ)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateData()
        'Khai báo và khởi tạo đối tượng Chủ sở hữu
        Dim ChuSoHuu As New DMC.Land.ChuSoHuuTaiSan.clsChuSoHuu
        Try
            'Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu
            If (strConnection = "") Then
                MessageBox.Show("Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            'Chắc chắn rằng tồn tại Mã Cây lâu năm
            If (strMaTaiSan = "") Then
                strError = "Không tìm thấy Mã Cây lâu năm"
                MessageBox.Show("Lỗi: " & strError, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Chắc chắn rằng tồn tại Mã chủ sở hữu Nhà sở
            If (strMaChu = "") Then
                strError = "Không tìm thấy Mã Chủ sở hữu Cây lâu năm"
                MessageBox.Show("Lỗi: " & strError, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Gán giá trị cho thuộc tính của đối tượng Chủ sở hữu Cây lâu năm
            'Khai báo nhận chuỗi kết nối Database
            ChuSoHuu.Connection = strConnection
            'Mã Hồ sơ cấp GCN
            ChuSoHuu.MaTaiSan = strMaTaiSan
            'Mã Chủ sử dụng đất
            ChuSoHuu.MaChuSoHuu = strMaChu
            Dim str As String = ""
            Dim strUpdateResults As String = ""
            'Xác định kiểu cập nhật
            'Trường hợp thêm mới Chủ sở hữu Cây lâu năm
            If (Me.shortAction = 1) Then
                strUpdateResults = ChuSoHuu.InsertChuSoHuuCayLauNam(str)
                'Trường hợp Xóa Chủ sở hữu Cây lâu năm
            ElseIf (Me.shortAction = 3) Then
                strUpdateResults = ChuSoHuu.DeleteChuSoHuuCayLauNam(str)
            End If
            'Nếu cập nhật thành công
            If strUpdateResults = "" Then
                Me.TrangThaiBanDau()
            End If
            strError = ChuSoHuu.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Đối tượng Cơ quan nhà nước " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub ctrlChuSuDungTCDN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                'Trạng thái cập nhật
                .TrangThaiCapNhat()
                'Trạng thái chức năng
                .TrangThaiChucNang(True, True)
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Đối tượng Cơ quan nhà nước " _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub grdvwCQuanNNuoc_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwCQuanNNuoc.CellMouseClick

        'Chỉ thực thi khi người dùng chọn chuột trái
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khởi tạo đối tượng
        Dim ChuCQNN As New DMC.Land.Chu.clsChuCQNN
        If e.RowIndex >= 0 Then
            Try
                'Gán thông tin Chủ sử dụng vừa lựa chọn vào thuộc tính tương ứng của đối tượng
                'Chủ sử dụng thuộc nhóm Cơ quan nhà nước
                With dtChuSoHuuCQNN.Rows(e.RowIndex)
                    ChuCQNN.DiaChi = .Item("DiaChi").ToString
                    ChuCQNN.DoiTuongSDD = .Item("DoiTuongSDD").ToString
                    ChuCQNN.HoTen = .Item("HoTen").ToString
                    ChuCQNN.MaChu = .Item("MaChu").ToString
                    ChuCQNN.TonTai = .Item("TonTai").ToString
                    'Gán Mã Chủ sử dụng vừa lựa chọn cho biến dùng chung
                    strMaChu = ChuCQNN.MaChu
                End With
                'Hiển thị thông tin Chủ sử dụng vừa lựa chọn lên Form
                With Me
                    .txtDiaChi.Text = ChuCQNN.DiaChi
                    .txtTen.Text = ChuCQNN.HoTen
                    .txtMaDoiTuong.Text = ChuCQNN.DoiTuongSDD
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Đối tượng Cơ quan nhà nước" _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub
End Class
