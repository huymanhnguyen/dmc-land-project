Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlCongTrinhXayDung
    Private strConnection As String = "" 'Khai báo biến nhận chuỗi kết nối Database
    Private strError As String = "" 'Khai bao bien kiem tra loi
    'Khai bao bien MaHoSoCapGCN dung chung
    Private strMaHoSoCapGCN As String = ""
    Private strMaCongTrinhXayDung As String = ""
    Private dtCongTrinhXayDung As New DataTable
    Private shortAction As Short = 0
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

    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Private Sub HideAllColumns(ByRef grdvw As DataGridView)
        'Ẩn tất cả các cột trên Grid
        With grdvw
            For i As Integer = 0 To (.Columns.Count - 1)
                .Columns(i).Visible = False
            Next
            .RowHeadersVisible = False
        End With
    End Sub
    Private MaLoaiBienDong As String = ""
    Public Property MaKhoa() As String
        Get
            Return MaLoaiBienDong
        End Get
        Set(ByVal value As String)
            MaLoaiBienDong = value
        End Set
    End Property

    'Add các cột cần thiết cho Grid
    Public Sub FormatGridContruction()
        Try
            With Me.grdvw
                'Ẩn tất cả các cột trên Grid
                Me.HideAllColumns(grdvw)
                'Thiết đặt các giá trị cần thiết cho cột
                With .Columns("GiayPhep")
                    .HeaderText = "Giấy phép đầu tư (xây dựng)"
                    .Width = 250
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With

                With .Columns("Ten")
                    .HeaderText = "Tên công trình"
                    .Width = 200
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With

                With .Columns("MoTa")
                    .HeaderText = "Mô tả công trình"
                    .Width = 200
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With

                With .Columns("NguonGoc")
                    .HeaderText = "Nguồn gốc"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With

                With .Columns("DienTichXayDung")
                    .HeaderText = "Diện tích xây dựng"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With

                With .Columns("HinhThanhTrongTuongLai")
                    .HeaderText = "Hình thành trong tương lai"
                    .Width = 150
                    .Visible = True
                End With

                With .Columns("ThoiDiemHinhThanh")
                    .HeaderText = "Thời điểm hình thành"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With

                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Không cho phép thêm
                .AllowUserToAddRows = False
                'Không cho phép xóa
                .AllowUserToDeleteRows = False
                'Không cho lựa chọn bất kỳ bản ghi nào lúc ban đầu
                .ClearSelection()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Công trình xây dựng" + vbNewLine + " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    ''' <summary>
    ''' Hiển thị thông tin Công trình xây dựng
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        'Khai báo và khởi tạo lớp Công trình xây dựng
        Dim CongTrinh As New clsCongTrinhXayDung
        'Gán giá trị cho các thuộc tính ứng với trường hợp truy vấn
        Try
            With CongTrinh
                .Connection = strConnection 'Gán chuỗi kết nối cơ sở dữ liệu
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            dtCongTrinhXayDung.Clear()
            With Me.grdvw
                .ClearSelection()
                'Gọi phương thức truy vấn thông tin Công trình xây dựng
                If CongTrinh.GetData(dtCongTrinhXayDung) = "" Then
                    'Trình bày dữ liệu lên Grid
                    .DataSource = dtCongTrinhXayDung
                    If dtCongTrinhXayDung.Rows.Count > 0 Then
                        'Định dạng lại các cột trên Grid
                        Me.FormatGridContruction()
                    Else
                        'Ẩn tất cả các cột
                        Me.HideAllColumns(grdvw)
                    End If
                End If
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu: " & vbNewLine & " Thông tin Công trình xây dựng " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Trạng thái ban đầu
        Me.TrangThaiBanDau()
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
    End Sub
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Cập nhật hạng mục công trình"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    Public Sub UpdateData()
        'Khai báo và khởi tạo lớp thông tin Công trình xây dựng
        Dim CongTrinh As New clsCongTrinhXayDung
        Try
            'Xac nhan gia tri can cap nhat
            With CongTrinh
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaCongTrinhXayDung = strMaCongTrinhXayDung
                If IsNumeric(numDienTichXayDung.Text.Trim) Then
                    .DienTichXayDung = numDienTichXayDung.Text.Trim
                Else
                    .DienTichXayDung = Nothing
                End If
                .GiayPhep = Me.txtGiayPhep.Text.Trim
                .HinhThanhTrongTuongLai = Me.chkHinhThanhTrongTuongLai.Checked
                .MoTa = Me.txtMoTa.Text.Trim
                .NguonGoc = Me.txtNguonGoc.Text.Trim
                .Ten = Me.txtTen.Text.Trim
                If (Me.DTPThoiDiemHinhThanh.Checked) Then
                    .ThoiDiemHinhThanh = Me.DTPThoiDiemHinhThanh.Value
                Else
                    .ThoiDiemHinhThanh = Nothing
                End If

                Dim str As String = ""
                If (shortAction = 1) Then
                    CongTrinh.InsertCongTrinhXayDungByMaCongTrinhXayDung()
                    NhatKyNguoiDung("Thêm", Me.txtGiayPhep.Text.Trim & "_" & Me.txtTen.Text.Trim)
                ElseIf (shortAction = 2) Then
                    CongTrinh.UpdateCongTrinhXayDungByMaCongTrinhXayDung()
                    NhatKyNguoiDung("Sửa", "Thay hạng mục (" & txtGiayPhep.Text.Trim & "_" & Me.txtTen.Text.Trim & " bằng  " & strThongTinChuCu)
                End If
                strError = .Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật thông tin Công trình xây dựng " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Thiết lập trạng thái ban đầu
        TrangThaiBanDau()
        'Thiết đặt giá trị mặc định cho biến trạng thái hành động (truy vấn dữ liệu)
        shortAction = 0
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .numDienTichXayDung.ReadOnly = Not blnCapNhat
            .numDienTichXayDung.Enabled = blnCapNhat
            .txtGiayPhep.ReadOnly = Not blnCapNhat
            .txtMoTa.ReadOnly = Not blnCapNhat
            .txtNguonGoc.ReadOnly = Not blnCapNhat
            .txtTen.ReadOnly = Not blnCapNhat
            .DTPThoiDiemHinhThanh.Enabled = blnCapNhat
            .chkHinhThanhTrongTuongLai.Enabled = blnCapNhat
            If blnCapNhat Then
                .numDienTichXayDung.BackColor = Color.White
                .txtGiayPhep.BackColor = Color.White
                .txtMoTa.BackColor = Color.White
                .txtNguonGoc.BackColor = Color.White
                .txtTen.BackColor = Color.White
            Else
                .numDienTichXayDung.BackColor = Color.LightYellow
                .txtGiayPhep.BackColor = Color.LightYellow
                .txtMoTa.BackColor = Color.LightYellow
                .txtNguonGoc.BackColor = Color.LightYellow
                .txtTen.BackColor = Color.LightYellow
            End If
        End With
    End Sub

    Public Sub TrangThaiBanDau()
        Dim CongTrinh As New clsCongTrinhXayDung
        With Me
            'dtCongTrinhXayDung.Clear()
            .txtGiayPhep.Text = ""
            .txtMoTa.Text = ""
            .txtNguonGoc.Text = ""
            .txtTen.Text = ""
            .DTPThoiDiemHinhThanh.Value = Date.Now
            .DTPThoiDiemHinhThanh.Checked = False
            .chkHinhThanhTrongTuongLai.Checked = False
            .numDienTichXayDung.Text = ""
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox2.Enabled = True
                .btnThem.Enabled = Not blnStartEdited
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnCapNhat.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnCapNhat.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                End If
                If (strMaCongTrinhXayDung <> "") Then
                    .btnThem.Enabled = False
                End If
            Else
                Me.GroupBox2.Enabled = False

            End If
            
        End With
    End Sub


    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaCongTrinhXayDung <> "" Then
            shortAction = 2
            'Trang thai chuc nang
            TrangThaiChucNang(True)
            'Trang thai cap nhat
            TrangThaiCapNhat(True)
        Else
            MsgBox(" Bạn chưa chọn Công trình cần sửa!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Chắc chắn rằng tồn tại Hồ sơ cấp GCN cần xóa Công trình xây dựng
        If strMaHoSoCapGCN = "" Then
            System.Windows.Forms.MessageBox.Show("Bạn CHƯA chọn Hồ sơ cấp GCN", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        'Chắc chắn rằng bạn đã chọn Một công trình xây dựng cần xóa
        If (strMaCongTrinhXayDung = "") Then
            System.Windows.Forms.MessageBox.Show("Bạn CHƯA chọn Công trình xây dựng", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
            With Me
                Dim CongTrinh As New clsCongTrinhXayDung
                CongTrinh.Connection = strConnection
                CongTrinh.MaHoSoCapGCN = strMaHoSoCapGCN
                CongTrinh.MaCongTrinhXayDung = strMaCongTrinhXayDung
                CongTrinh.DeleteCongTrinhXayDungByMaCongTrinhXayDung()
            End With
            If (strError = "") Then
                MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
            Else
                MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
            End If
        End If

        'Hiển thị thông tin
        Me.ShowData()
        strError = ""
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Try
            'Kiểm tra tính hợp lệ của thông tin đầu vào
            If Me.txtTen.Text.Trim = "" Then
                If (System.Windows.Forms.MessageBox.Show("Bạn CHƯA nhập TÊN Công trình!" & vbNewLine _
                    & "Bạn có muốn nhập không?", "DMCLand", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                    Me.txtTen.Focus()
                    Exit Sub
                End If
            End If
            'Cập nhật thông tin Công trình xây dựng
            Me.UpdateData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật thông tin Công trình xây dựng " & vbNewLine & " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        'Hiển thị thông tin công trình xây dựng sau khi cập nhật
        Me.ShowData()
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        strError = ""
    End Sub

    Private Sub ctrlCongTrinhXayDung_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .DTPThoiDiemHinhThanh
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
            'Thiêt lập trạng thái cập nhật
            .TrangThaiCapNhat()
            'Thiết lập trạng thái chức năng
            .TrangThaiChucNang(True, True)
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            .ShowData()
            'Khởi tạo giá trị cho biến dùng chung
            strMaCongTrinhXayDung = ""
        End With
        shortAction = 0
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        'Bỏ lựa chọn
        Me.grdvw.ClearSelection()
        strMaCongTrinhXayDung = ""
        shortAction = 1
        With Me
            'Thiết lập trạng thái các điều khiển ban đầu
            .TrangThaiBanDau()
            'Thiết lập trạng thái các điều khiển
            .TrangThaiCapNhat(True)
            'Thiết đặt trạng thái các nút chức năng
            .TrangThaiChucNang(True)
        End With
    End Sub

    Private Sub grdvw_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvw.CellMouseClick
        'Không dùng chuột phải
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khai báo và khởi tạo lớp Thông tin Công trình xây dựng
        Dim CongTrinh As New clsCongTrinhXayDung
        If e.RowIndex >= 0 Then
            Try
                'Gán chuỗi kết nối cơ sở dữ liệu
                CongTrinh.Connection = strConnection
                With dtCongTrinhXayDung.Rows(e.RowIndex)
                    CongTrinh.MaCongTrinhXayDung = .Item("MaCongTrinhXayDung").ToString
                    strMaCongTrinhXayDung = CongTrinh.MaCongTrinhXayDung
                    CongTrinh.MaHoSoCapGCN = .Item("MaHoSoCapGCN").ToString
                    CongTrinh.DienTichXayDung = .Item("DienTichXayDung").ToString
                    CongTrinh.GiayPhep = .Item("GiayPhep").ToString
                    CongTrinh.MoTa = .Item("MoTa").ToString
                    CongTrinh.NguonGoc = .Item("NguonGoc").ToString
                    CongTrinh.Ten = .Item("Ten").ToString
                    CongTrinh.ThoiDiemHinhThanh = .Item("ThoiDiemHinhThanh").ToString
                    CongTrinh.HinhThanhTrongTuongLai = .Item("HinhThanhTrongTuongLai").ToString

                End With
                'Hiển thị bản ghi được lựa chon lên Form
                With Me
                    .txtGiayPhep.Text = CongTrinh.GiayPhep
                    .txtMoTa.Text = CongTrinh.MoTa
                    .txtNguonGoc.Text = CongTrinh.NguonGoc
                    .txtTen.Text = CongTrinh.Ten
                    'Diện tích xây dựng
                    If IsNumeric(CongTrinh.DienTichXayDung) Then
                        .numDienTichXayDung.Text = CongTrinh.DienTichXayDung
                    Else
                        .numDienTichXayDung.Text = ""
                    End If
                    'Hình thành trong tương lai
                    If CongTrinh.HinhThanhTrongTuongLai.ToString = "True" Then
                        .chkHinhThanhTrongTuongLai.Checked = True
                    Else
                        .chkHinhThanhTrongTuongLai.Checked = False
                    End If
                    'Thời điểm hình thành
                    If IsDate(CongTrinh.ThoiDiemHinhThanh) Then
                        .DTPThoiDiemHinhThanh.Value = Convert.ToDateTime(CongTrinh.ThoiDiemHinhThanh)
                        .DTPThoiDiemHinhThanh.Checked = True
                    Else
                        .DTPThoiDiemHinhThanh.Value = Date.Now
                        .DTPThoiDiemHinhThanh.Checked = False
                    End If
                    strThongTinChuCu = txtGiayPhep.Text.Trim & "_" & Me.txtTen.Text.Trim
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị Thông tin Công trình xây dựng lên Form " _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub btnHangMucCongTrinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHangMucCongTrinh.Click
        'Chắc chắn rằng có Công trình được lựa chọn để cập nhật thông tin 
        'Hạng mục công trình
        If strMaCongTrinhXayDung = "" Then
            System.Windows.Forms.MessageBox.Show("Bạn phải chọn một Công trình xây dựng", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim HangMuc As New frmHangMucCongTrinh
        With HangMuc
            'Hiển thị thông tin Hạng mục Công trình theo
            'Công trình được lựa chọn
            With .CtrlHangMucCongTrinh
                .Connection = strConnection
                .MaCongTrinhXayDung = strMaCongTrinhXayDung
                .ShowData()
            End With
            'Hiển thị Form Hạng mục công trình
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
    End Sub

    Private Sub txtGiayPhep_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGiayPhep.KeyDown
        If (e.KeyValue = 13) Then
            txtTen.Focus()
        End If
    End Sub

    Private Sub txtTen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTen.KeyDown
        If (e.KeyValue = 13) Then
            txtMoTa.Focus()
        End If
    End Sub

    Private Sub txtMoTa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMoTa.KeyDown
        If (e.KeyValue = 13) Then
            txtNguonGoc.Focus()
        End If
    End Sub

    Private Sub txtNguonGoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNguonGoc.KeyDown
        If (e.KeyValue = 13) Then
            numDienTichXayDung.Focus()
        End If
    End Sub

    Private Sub numDienTichXayDung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDienTichXayDung.KeyDown
        If (e.KeyValue = 13) Then
            btnCapNhat.Focus()
        End If
    End Sub
End Class
