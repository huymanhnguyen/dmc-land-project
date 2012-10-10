Imports System.Windows.Forms
Imports System.Drawing
Public Class ctrlChuSuDungCQNN

    'Khai báo biến xác định hành động thao tác cơ sở dữ liệu
    Private shFlag As Short = 0
    Private strMaHoSoCapGCN As String = ""
    Private dtChuSuDungCQNN As New DataTable
    Private arrOptGioiTinh As New List(Of String)
    'Khai báo biến nhận tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã chủ sử dụng đất
    Private strMaChuSuDung As String = ""
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
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Mã Chủ sử dụng đất
    Public WriteOnly Property MaChuSuDung() As String
        Set(ByVal value As String)
            strMaChuSuDung = value
        End Set
    End Property


    'Public Sub AddColumnsCoQuanNhaNuoc()
    '    Dim txtClnMaDoiTuong As New DataGridViewTextBoxColumn
    '    Dim txtClnHoTen As New DataGridViewTextBoxColumn
    '    Dim txtClnDiaChi As New DataGridViewTextBoxColumn
    '    Try
    '        'Ma doi tuong
    '        With txtClnMaDoiTuong
    '            .HeaderText = "Mã đối tượng"
    '            .Name = "KyHieu"
    '            .Width = 120
    '        End With
    '        'Ho va Ten
    '        With txtClnHoTen
    '            .HeaderText = "Tên"
    '            .Name = "HoTen"
    '            .Width = 100
    '        End With
    '        'Dai chi thuong chu
    '        With txtClnDiaChi
    '            .HeaderText = "Địa chỉ"
    '            .Name = "DiaChi"
    '            .Width = 130
    '        End With
    '        'Add all to DataGridView Ho gia dinh ca nhan
    '        With grdvwCQuanNNuoc
    '            '.GridColor = Color.WhiteSmoke
    '            .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
    '            .RowHeadersVisible = False
    '            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            'Add columns to Grid
    '            .Columns.Add(txtClnMaDoiTuong)
    '            .Columns.Add(txtClnHoTen)
    '            .Columns.Add(txtClnDiaChi)
    '        End With
    '    Catch ex As Exception
    '        strError = ex.Message
    '        MsgBox(" Chủ sử dụng " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
    '    End Try
    'End Sub

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

    Private Sub FormatGridContruction()
        Try
            With Me.grdvwCQuanNNuoc
                'Ẩn tất cả các cột
                Me.HideAllColumns(grdvwCQuanNNuoc)
                'Ma doi tuong
                With .Columns("KyHieu")
                    .HeaderText = "Mã đối tượng"
                    .Width = 120
                    .Visible = True
                End With
                'Ho va Ten
                With .Columns("HoTen")
                    .HeaderText = "Tên"
                    .Width = 100
                    .Visible = True
                End With
                'Dai chi thuong chu
                With .Columns("DiaChi")
                    .HeaderText = "Địa chỉ"
                    .Width = 130
                    .Visible = True
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
            MsgBox(" Chủ sử dụng cơ quan nhà nước " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        strMaChuSuDung = ""
        With Me
            'Thiết lập trạng thái ban đầu
            .TrangThaiBanDau()
            'Xác định hành động thêm mới Chủ sử dụng
            shFlag = 1
            'Thiết lập trạng thái chức năng
            .TrangThaiChucNang(True)
            'Hiển thị Form tra cứu
            TraCuu()
        End With
    End Sub
    ''' <summary>
    ''' Hiển thị thông tin Chủ sử dụng đất trong lên Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        'Khai báo và khởi tạo đối tượng Chủ hồ sơ cấp GCN
        Dim ChuSuDung As New DMC.Land.ChuSuDungDat.clsChuSuDung
        'Gán giá trị cho các thuộc tính đối với trường hợp truy vấn
        Try
            'Khai báo nhận chuỗi kết nối Database
            ChuSuDung.Connection = strConnection
            ChuSuDung.MaChuSuDung = ""
            ChuSuDung.MaHoSoCapGCN = strMaHoSoCapGCN
            dtChuSuDungCQNN.Clear()
            With Me
                .grdvwCQuanNNuoc.ClearSelection()
                'Gọi phương thức GetData để khởi tạo đối tượng ChuSuDung
                If ChuSuDung.SelectChuSuDungByCQNN(dtChuSuDungCQNN) = "" Then
                    'Trình bày dữ liệu lên gridView
                    .grdvwCQuanNNuoc.DataSource = dtChuSuDungCQNN
                    'Khi tồn tại bản ghi nhận được
                    If dtChuSuDungCQNN.Rows.Count > 0 Then
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

    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            If (blnClearGrid) Then
                .HideAllColumns(grdvwCQuanNNuoc)
            End If
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
            'Cập nhật thông tin Chủ sử dụng (Ho gia dinh - ca nhan)
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
        strMaChuSuDung = ""
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
            strMaChuSuDung = ""
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
            'Cần kiểm tra lại xem có thêm thuộc tính MaHoSoCapGCN vào ko?
            '.MaHoSoCapGCN = strMaHoSoCapGCN
            'Hiển thị Form tra cứu giữa màn hình
            TraCuuCQNN.StartPosition = FormStartPosition.CenterScreen
            TraCuuCQNN.ShowDialog()
            Try
                strMaChuSuDung = .MaChu

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
    ''' Xóa Chủ sử dụng Hồ sơ cấp GCN (bảng trung gian tblChuSuDungHoSoCapGCN)
    ''' Note: Không phải xóa Chủ sử dụng đất (tblTuDienChuSuDung)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Kiểm tra dữ liệu đầu vào
        With Me
            'Xác định hành động Xóa Chủ sử dụng
            Me.shFlag = 3
            'Xóa Chủ sử dụng Hồ sơ cấp GCN (Hộ gia đình cá nhân)
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
        strMaChuSuDung = ""
        'Gắn giá trị mặc định cho biến kiểm tra lỗi
        strError = ""
    End Sub

    ''' <summary>
    ''' Thêm Chủ sử dụng Hồ sơ cấp GCN
    ''' Note: Không phải cập nhật Chủ sử dụng đất)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateData()
        'Khai bao loi
        'Khai bao va khoi tao doi tuong clsChuSuDungHoSoCapGCN
        Dim ChuSuDung As New DMC.Land.ChuSuDungDat.clsChuSuDung
        Try
            'Khai báo nhận chuỗi kết nối Database
            ChuSuDung.Connection = strConnection
            'Chắc chắn rằng tồn tại Mã Hồ sơ cấp GCN
            If (strMaHoSoCapGCN = "") Then
                strError = "Không tìm thấy Mã Hồ sơ cấp GCN"
                Exit Sub
            End If
            'Chắc chắn rằng tồn tại Mã chủ sử dụng đất
            If (strMaChuSuDung = "") Then
                strError = "Không tìm thấy Mã Chủ sử dụng đất"
                Exit Sub
            End If
            'GÁN GIÁ TRỊ CHO THUỘC TÍNH CỦA ĐỐI TƯỢNG CHỦ SỬ DỤNG HỒ SƠ CẤP GCN
            'Mã Hồ sơ cấp GCN
            ChuSuDung.MaHoSoCapGCN = strMaHoSoCapGCN
            'Mã Chủ sử dụng đất
            ChuSuDung.MaChuSuDung = strMaChuSuDung
            Dim str As String = ""
            Dim strUpdateResults As String = ""
            'Xác định kiểu cập nhật
            'Trường hợp thêm mới Chủ Hồ sơ cấp GCN
            If (Me.shFlag = 1) Then
                strUpdateResults = ChuSuDung.InsertData(str)
                'Trường hợp Xóa Chủ Hồ sơ cấp GCN
            ElseIf (Me.shFlag = 3) Then
                strUpdateResults = ChuSuDung.DeleteData(str)
            End If
            'Nếu cập nhật thành công
            If strUpdateResults = "" Then
                Me.TrangThaiBanDau()
            End If
            strError = ChuSuDung.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Đối tượng Cơ quan nhà nước " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub ctrlChuSuDungTCDN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                'Trang thai cap nhat
                .TrangThaiCapNhat()
                'Trang thai chuc nang
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
                With dtChuSuDungCQNN.Rows(e.RowIndex)
                    ChuCQNN.DiaChi = .Item("DiaChi").ToString
                    ChuCQNN.DoiTuongSDD = .Item("DoiTuongSDD").ToString
                    ChuCQNN.HoTen = .Item("HoTen").ToString
                    ChuCQNN.MaChu = .Item("MaChu").ToString
                    ChuCQNN.TonTai = .Item("TonTai").ToString
                    'Gán Mã Chủ sử dụng vừa lựa chọn cho biến dùng chung
                    strMaChuSuDung = ChuCQNN.MaChu
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

