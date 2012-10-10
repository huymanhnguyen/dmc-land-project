Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlChuCQNN
    Private dtChuCQNN As New System.Data.DataTable
    Public dtChuSelect As New System.Data.DataTable
    Private strConnection As String = ""
    Private strMaHoSoCapGCN As String = ""
    'Khai báo và khởi tạo giá trị cho biến hành động kiểu Short
    '0 tương đương với trường hợp truy vấn
    '1 tương đương với trường hợp thêm mới một mẩu tin
    '2 tương đương với trường hợp cập nhật thông tin
    '3 tương đương với trường hợp xóa mẩu tin
    Private shortAction As Short = 0
    'Khai báo biến nhận tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến Mã chủ 
    Private strMaChu As String = ""
    Private KTTonTai As Boolean
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
    'Khai báo thuộc tính nhận Tên đơn vị hành chính
    Public WriteOnly Property TenDonViHanhChinh() As String
        Set(ByVal value As String)
            strTenDonViHanhChinh = value
        End Set
    End Property
    Public Property MaChu() As String
        Get
            Return strMaChu
        End Get
        Set(ByVal value As String)
            strMaChu = value
        End Set
    End Property

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        strMaChu = ""
        shortAction = 1
        With Me
            'Thiết lập trạng thái ban đầu
            .TrangThaiBanDau()
            'Thiết lập giá trị mặc định ban đầu
            .txtDiaChi.Text = strTenDonViHanhChinh
            'Trạng thái cập nhật
            .TrangThaiCapNhat(True)
            'Trạng thái chức năng 
            .TrangThaiChucNang(True)
        End With
    End Sub
    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        'Chắc chắn rằng tồn tại Mã hồ sơ cấp GCN
        If (strMaHoSoCapGCN = "") Then
            Return
        End If
        If strMaChu <> "" Then
            shortAction = 2
            With Me
                'Trạng thái chức năng
                .TrangThaiChucNang(True)
                'Trạng thái cập nhật
                .TrangThaiCapNhat(True)
            End With
        Else
            MsgBox(" Bạn chưa chọn Chủ cần sửa thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub
    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        'Kiểm tra dữ liệu nhập vào
        If txtMaDoiTuong.Text.Trim = "" Then
            MsgBox("Bạn phải nhập Mã đối tượng sử dụng đất!", MsgBoxStyle.Information, "DMCLand")
            txtMaDoiTuong.Focus()
            Exit Sub
        End If
        With Me
            'Cập nhật thông tin Chủ sử dụng (Đối tượng: Cơ quan nhà nước, Ủy Ban nhân dân)
            .UpdateData()
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
    Private Sub TraCuuChuSuDung()
        Try
            Dim TonTai As String = ""
            TonTai = "1"
            'Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu
            If (strConnection Is Nothing) Or (strConnection = "") Then
                ''Hiển thị thông báo
                'System.Windows.Forms.MessageBox.Show("Không có chuỗi kết nối cơ sở dữ liệu!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ''Thoát khởi hàm
                Exit Sub
            End If
            Dim ChuCQNN As New clsChuCQNN
            With ChuCQNN
                .Connection = strConnection
                .DiaChi = txtDiaChi.Text.Trim
                .DoiTuongSDD = txtMaDoiTuong.Text.Trim
                .HoTen = txtTen.Text.Trim
                .MaChu = ""
                .TonTai = TonTai
            End With

            With Me
                .grdvwChu.Columns.Clear()
                .grdvwChu.ClearSelection()
                .grdvwChu.DataSource = Nothing
                dtChuCQNN.Clear()
                'Gọi phương thức GetData để khởi tạo đối tượng Chu
                If ChuCQNN.GetData(dtChuCQNN) = "" Then
                    'Trình bày dữ liệu lên gridView
                    .grdvwChu.DataSource = dtChuCQNN
                    'Khi tồn tại bản ghi nhận được
                    If dtChuCQNN.Rows.Count > 0 Then
                        .FormatGridContruction()
                    Else
                        .HideAllColumns(grdvwChu)
                    End If
                End If
            End With
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Lỗi: " & ex.Message, "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Neu ton tai ma can xoa
        If strMaChu <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        'Xác định kiểu cập nhật là xóa chủ sử dụng
                        shortAction = 3
                        'Thực thi xóa chủ sử dụng
                        .UpdateData()
                        strMaChu = ""
                        'Trạng thái ban đầu
                        .TrangThaiBanDau()
                        'Hiển thị dữ liệu
                        .ShowData()
                        'Trạng thái chức năng
                        .TrangThaiChucNang()
                    End With
                Catch ex As Exception
                    strError = ex.Message
                End Try
                If (strError = "") Then
                    MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                Else
                    MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                End If
            Else
                'Trạng thái chức năng
                Me.TrangThaiChucNang()
            End If
        Else
            MsgBox(" Bạn chưa chọn Chủ cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        'Trạng thái cập nhật 
        Me.TrangThaiCapNhat()
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

    Private Sub FormatGridContruction()
        Try
            With Me.grdvwChu
                'Ẩn tất cả các cột
                Me.HideAllColumns(grdvwChu)
                'Ma doi tuong
                With .Columns("KyHieu")
                    .HeaderText = "Mã đối tượng"
                    .Width = 120
                    .Visible = True
                End With
                'Ho va Ten
                With .Columns("HoTen")
                    .HeaderText = "Tên"
                    .Width = 300
                    .Visible = True
                End With
                'Dai chi thuong chu
                With .Columns("DiaChi")
                    .HeaderText = "Địa chỉ"
                    .Width = 400
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

    Public Sub ShowData()
        'Khai báo và khởi tạo đối tượng Chủ sử dụng thuộc nhóm Cơ quan nhà nước
        Dim ChuCQNN As New clsChuCQNN
        'Gán giá trị cho các thuộc tính đối với trường hợp truy vấn
        Try
            ' Khai báo nhận chuỗi kết nối Database
            ChuCQNN.Connection = strConnection
            ChuCQNN.MaHoSoCapGCN = strMaHoSoCapGCN
            With Me
                .grdvwChu.Columns.Clear()
                .grdvwChu.ClearSelection()
                .grdvwChu.DataSource = Nothing
                dtChuCQNN.Clear()
                'Gọi phương thức GetData để khởi tạo đối tượng Chu
                If ChuCQNN.GetData(dtChuCQNN) = "" Then
                    'Trình bày dữ liệu lên grdvwHoGiaDinhCaNhan
                    .grdvwChu.DataSource = dtChuCQNN
                    'Khi tồn tại bản ghi nhận được
                    If dtChuCQNN.Rows.Count > 0 Then
                        .FormatGridContruction()
                    Else
                        .HideAllColumns(grdvwChu)
                    End If
                End If
            End With
            'Trạng thái ban đầu
            Me.TrangThaiBanDau()
            'Trạng thái chức năng
            Me.TrangThaiChucNang()
            'Trạng thái cập nhật
            Me.TrangThaiCapNhat()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Đối tượng Cơ quan nhà nước " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try

    End Sub
    ''' <summary>
    ''' Cập nhật thông tin Chủ sử dụng
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateData()
        'Khai báo và khởi tạo đối tượng Chủ thuộc nhóm CƠ QUAN NHÀ NƯỚC
        Dim ChuCQNN As New clsChuCQNN
        Try
            'Khai báo nhận chuỗi kết nối Database
            ChuCQNN.Connection = strConnection
            'Khai báo nhận giá trị Mã chủ
            ChuCQNN.MaChu = strMaChu
            'Khai báo Mã hồ sơ cấp GCN
            ChuCQNN.MaHoSoCapGCN = strMaHoSoCapGCN
            If txtDiaChi.Text IsNot Nothing Then
                ChuCQNN.DiaChi = txtDiaChi.Text.Trim
            Else
                ChuCQNN.DiaChi = ""
            End If
            If txtMaDoiTuong.Text IsNot Nothing Then
                ChuCQNN.DoiTuongSDD = txtMaDoiTuong.Text.Trim
            Else
                ChuCQNN.DoiTuongSDD = ""
            End If

            If (txtTen.Text IsNot Nothing) Then
                ChuCQNN.HoTen = txtTen.Text.Trim
            Else
                If (shortAction = 1) Or (shortAction = 2) Then
                    MsgBox("Bạn cần khai báo TÊN CHỦ SỬ DỤNG", MsgBoxStyle.Information, "DMCLand")
                    Exit Sub
                Else
                    ChuCQNN.HoTen = ""
                End If
            End If
            'Xác định chủ thể sử dụng/ sở hữu
            ChuCQNN.CayLauNam = Me.chkChuCayLauNam.Checked
            ChuCQNN.CongTrinh = Me.chkChuCongTrinhXayDung.Checked
            ChuCQNN.Dat = Me.chkChuDat.Checked
            ChuCQNN.NhaO = Me.chkChuNhaO.Checked
            ChuCQNN.RungCay = Me.chkChuRungCay.Checked
            ChuCQNN.TonTai = "1"
            Dim str As String = ""
            Dim strCapNhat As String = ""
            'Xác định kiểu cập nhật
            If (shortAction = 1) Then
                'Thêm mới dữ liệu
                strCapNhat = ChuCQNN.InsertData(str)
            ElseIf (shortAction = 2) Then
                'Cập nhật dữ liệu
                strCapNhat = ChuCQNN.UpdateData(str)
            ElseIf (shortAction = 3) Then
                'Xóa dữ liệu
                strCapNhat = ChuCQNN.DeleteData(str)
            End If
            'Nếu cập nhật thành công
            If strCapNhat = "" Then
                Me.TrangThaiBanDau()
                shortAction = 0
            End If
            strError = ChuCQNN.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Đối tượng Cơ quan nhà nước " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Then
            Me.ShowData()
        End If
    End Sub
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            'If blnCapNhat Then
            .grdvwChu.BackgroundColor = Color.White
            'Else
            '    .grdvwGDCN.BackgroundColor = Color.LightYellow
            'End If
            .txtDiaChi.ReadOnly = Not blnCapNhat
            .txtTen.ReadOnly = Not blnCapNhat
            .txtMaDoiTuong.ReadOnly = Not blnCapNhat

            .chkChuDat.Enabled = blnCapNhat
            .chkChuNhaO.Enabled = blnCapNhat
            .chkChuCongTrinhXayDung.Enabled = blnCapNhat
            .chkChuRungCay.Enabled = blnCapNhat
            .chkChuCayLauNam.Enabled = blnCapNhat
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
            If blnClearGrid Then
                .HideAllColumns(grdvwChu)
            End If
            'Thiết lập trên Form nhập liệu
            .txtDiaChi.Text = ""
            .txtTen.Text = ""
            .txtMaDoiTuong.Text = ""
            'Mặc định Chủ hồ sơ cấp GCN là Chủ đất
            .chkChuDat.Checked = True
            .chkChuNhaO.Checked = False
            .chkChuCongTrinhXayDung.Checked = False
            .chkChuRungCay.Checked = False
            .chkChuCayLauNam.Checked = True
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            .btnSua.Enabled = Not blnStartEdited
            .btnXoa.Enabled = Not blnStartEdited
            .btnThem.Enabled = Not blnStartEdited
            .btnGhi.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnGhi.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
            End If
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            If strMaChu <> "" Then
                .ShowData()
            End If
            'Xóa dữ liệu trên Form
            .TrangThaiBanDau()
            'Khởi tạo giá trị ban đầu cho biến dùng chung
            strMaChu = ""
            'Trạng thái chức năng
            .TrangThaiChucNang()
            'Trạng thái cập nhật
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub

    Private Sub btnTraCuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraCuu.Click
        'TraCuuChuSuDung()
    End Sub
    Private Sub ctrlChuGDCN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                'Trạng thái cập nhật
                'Cho phép nhập thông tin tìm kiếm
                .TrangThaiCapNhat(True)
                'Trạng thái chức năng
                .TrangThaiChucNang(True, True)
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Đối tượng Cơ quan nhà nước" _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub grdvwChu_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'Try
        '    If (e.RowIndex >= 0) Then
        '        'Xác định mã Chủ sử dụng
        '        strMaChu = dtChuCQNN.Rows(e.RowIndex).Item("MaChu").ToString()
        '        'Khởi tạo đối tượng DataTable chứa bản ghi (Thông tin Chủ sử dụng) được lựa chọn
        '        dtChuSelect = New DataTable
        '        'Copy định dạng của đối tượng dtChuSuDungTCDN vào đối
        '        ' tượng DataTable chứa bản ghi (Thông tin Chủ sử dụng) được lựa chọn
        '        dtChuSelect = dtChuCQNN.Clone()
        '        'Add bản những chủ sử dụng được lựa chọn vào biến kiểu DataTable dùng chung
        '        dtChuSelect.ImportRow(dtChuCQNN.Rows(e.RowIndex))
        '        'Ẩn Form tra cứu thông tin Chủ sử dụng
        '        'NOTE: CẦN VIẾT SỰ KIỆN ẨN FORM TRA CỨU Ở ĐÂY
        '    End If
        'Catch ex As Exception
        '    System.Windows.Forms.MessageBox.Show("Lỗi: " & ex.Message, "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub grdvwChu_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwChu.CellMouseClick
        'Không chọn chuột phải
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khởi tạo đối tượng Chủ sử dụng thuộc nhóm cơ quan nhà nước
        Dim ChuCQNN As New clsChuCQNN
        If e.RowIndex >= 0 Then
            Try
                'Hiển thị thông tin Chủ sử dụng
                With dtChuCQNN.Rows(e.RowIndex)
                    ChuCQNN.DiaChi = .Item("DiaChi").ToString
                    ChuCQNN.DoiTuongSDD = .Item("DoiTuongSDD").ToString
                    ChuCQNN.HoTen = .Item("HoTen").ToString
                    ChuCQNN.MaChu = .Item("MaChu").ToString
                    'Gán Mã chủ sử dụng vừa lựa chon cho biến dùng chung
                    strMaChu = ChuCQNN.MaChu
                    ChuCQNN.TonTai = .Item("TonTai").ToString
                    ChuCQNN.CayLauNam = .Item("CayLauNam").ToString
                    ChuCQNN.CongTrinh = .Item("CongTrinhXayDung").ToString
                    ChuCQNN.Dat = .Item("Dat").ToString
                    ChuCQNN.NhaO = .Item("NhaO").ToString
                    ChuCQNN.RungCay = .Item("RungCay").ToString
                End With
                'Hiển thị bản ghi vừa lựa chọn lên Form
                With Me
                    .txtDiaChi.Text = ChuCQNN.DiaChi
                    .txtTen.Text = ChuCQNN.HoTen
                    .txtMaDoiTuong.Text = ChuCQNN.DoiTuongSDD

                    If ChuCQNN.CayLauNam.ToString <> "" Then
                        .chkChuCayLauNam.Checked = ChuCQNN.CayLauNam
                    Else
                        .chkChuCayLauNam.Checked = False
                    End If
                    If (ChuCQNN.CongTrinh.ToString <> "") Then
                        .chkChuCongTrinhXayDung.Checked = ChuCQNN.CongTrinh
                    Else
                        .chkChuCongTrinhXayDung.Checked = False
                    End If
                    If (ChuCQNN.Dat.ToString <> "") Then
                        .chkChuDat.Checked = ChuCQNN.Dat
                    Else
                        .chkChuDat.Checked = False
                    End If
                    If (ChuCQNN.NhaO.ToString <> "") Then
                        .chkChuNhaO.Checked = ChuCQNN.NhaO
                    Else
                        .chkChuNhaO.Checked = False
                    End If
                    If (ChuCQNN.RungCay.ToString <> "") Then
                        .chkChuRungCay.Checked = ChuCQNN.RungCay
                    Else
                        .chkChuRungCay.Checked = False
                    End If
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Đối tượng Cơ quan nhà nước " _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub btnMaDoiTuong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaDoiTuong.Click
        Dim TuDienChu As New frmBangMa
        With TuDienChu
            .CtrlTuDienDoiTuongSuDungDat.Connection = strConnection
            .CtrlTuDienDoiTuongSuDungDat.Nhom = "2"
            'Hiển thị Form bảng mã giữa màn hình
            TuDienChu.StartPosition = FormStartPosition.CenterScreen
            TuDienChu.ShowDialog()
        End With
        If (TuDienChu.CtrlTuDienDoiTuongSuDungDat.KyHieu IsNot Nothing) And (TuDienChu.CtrlTuDienDoiTuongSuDungDat.KyHieu <> "") Then
            Me.txtMaDoiTuong.Text = TuDienChu.CtrlTuDienDoiTuongSuDungDat.KyHieu.ToString()
        End If
    End Sub
End Class
