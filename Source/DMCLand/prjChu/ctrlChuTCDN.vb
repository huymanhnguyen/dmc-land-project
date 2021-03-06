﻿Imports System.Windows.Forms
Imports DMC.Components
Imports System.Drawing

Public Class ctrlChuTCDN
    Private dtChuTCDN As New System.Data.DataTable
    Public dtChuSelect As New System.Data.DataTable
    'Khai báo chuỗi kết nối cơ sở dữ liệu
    Private strConnection As String = ""
    'Khai báo và khởi tạo giá trị cho biến hành động kiểu Short
    '0 tương đương với trường hợp truy vấn
    '1 tương đương với trường hợp thêm mới một mẩu tin
    '2 tương đương với trường hợp cập nhật thông tin
    '3 tương đương với trường hợp xóa mẩu tin
    Private shortAction As Short = 0
    ' Khai báo biến nhận tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaChu As String = ""
    Private KTTonTai As Boolean
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
            .txtNoiCap.Text = strTenDonViHanhChinh
            'Trạng thái cập nhật
            .TrangThaiCapNhat(True)
            'Trạng thái chức năng 
            .TrangThaiChucNang(True)
        End With
    End Sub
    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaChu <> "" Then
            shortAction = 2
            With Me
                If KTTonTai = False Then
                    chbTonTai.Enabled = False
                Else
                    chbTonTai.Enabled = True
                End If
                'Trang thai chuc nang
                .TrangThaiChucNang(True)
                'Trang thai cap nhat
                .TrangThaiCapNhat(True)
            End With
        Else
            MsgBox(" Bạn chưa chọn Chủ cần sửa thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub
    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        'Kiem tra du lieu nhap vao
        If txtMaDoiTuong.Text.Trim = "" Then
            MsgBox("Bạn phải nhập Mã đối tượng sử dụng đất!", MsgBoxStyle.Information, "DMCLand")
            txtMaDoiTuong.Focus()
            Exit Sub
        End If
        'Xac dinh kieu cap nhat
        With Me
            'Cap nhat thong tin Chu su dung (Ho gia dinh - ca nhan)
            .UpdateData()
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat
            .TrangThaiCapNhat()
        End With
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        'Khoi tao gia tri cho bien dung chung
        strMaChu = ""
        strError = ""
    End Sub
    Private Sub TraCuuChuSuDung()
        Try
            Dim TonTai As String = ""
            If chbTonTai.Checked Then
                TonTai = "1"
            Else
                TonTai = "0"
            End If
            'Chắc chắn rằng tồn tại chuỗi kết nối cơ sở dữ liệu
            If (strConnection Is Nothing) Or (strConnection = "") Then
                ''Hiển thị thông báo
                'System.Windows.Forms.MessageBox.Show("Không có chuỗi kết nối cơ sở dữ liệu!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ''Thoát khởi hàm
                Exit Sub
            End If
            Dim ChuTCDN As New clsChuTCDN
            With ChuTCDN
                .Connection = strConnection
                .DiaChi = txtDiaChi.Text.Trim
                .DoiTuongSDD = txtMaDoiTuong.Text.Trim
                .HoTen = txtTen.Text.Trim
                .MaChu = ""
                .NgayCap = ""
                .NoiCap = txtNoiCap.Text.Trim
                .SoDinhDanh = txtSoDinhDanh.Text.Trim
                .TonTai = TonTai
            End With

            With Me
                .grdvwChu.Columns.Clear()
                .grdvwChu.ClearSelection()
                .grdvwChu.DataSource = Nothing
                dtChuTCDN.Clear()
                'Gọi phương thức GetData để khởi tạo đối tượng Chu
                If ChuTCDN.GetData(dtChuTCDN) = "" Then
                    'Trình bày dữ liệu lên gridView
                    .grdvwChu.DataSource = dtChuTCDN
                    'Khi tồn tại bản ghi nhận được
                    If dtChuTCDN.Rows.Count > 0 Then
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
                If (strError = "") Or (strError = "OK") Then
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
    ''' Ẩn tất cả các cột
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
    ''' Định dạng các cột Grid Chủ thuộc nhóm Tổ chức doanh nghiệp
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FormatGridContruction()
        Try
            With Me.grdvwChu
                Me.HideAllColumns(grdvwChu)
                'Ma doi tuong
                With .Columns("KyHieu")
                    .HeaderText = "Mã đối tượng"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ho va Ten
                With .Columns("HoTen")
                    .HeaderText = "Tên"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nam sinh
                'So dinh danh
                With .Columns("SoDinhDanh")
                    .HeaderText = "Số GPKD"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ngay cap dinh danh
                With .Columns("NgayCap")
                    .HeaderText = "Ngày cấp GPKD"
                    .Width = 130
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Noi cap dinh danh
                With .Columns("NoiCap")
                    .HeaderText = "Nơi cấp GPKD"
                    .Width = 130
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Dai chi thuong chu
                With .Columns("DiaChi")
                    .HeaderText = "Địa chỉ"
                    .Width = 130
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
            MsgBox(" Chủ sử dụng " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub ShowData()
        'Khai báo và khởi tạo đối tượng
        Dim ChuTCDN As New clsChuTCDN
        'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
        Try
            'Khai báo nhận chuỗi kết nối Database
            ChuTCDN.Connection = strConnection
            ChuTCDN.DiaChi = ""
            ChuTCDN.DoiTuongSDD = ""
            ChuTCDN.HoTen = ""
            ChuTCDN.MaChu = ""
            ChuTCDN.NgayCap = ""
            ChuTCDN.NoiCap = ""
            ChuTCDN.SoDinhDanh = ""
            ChuTCDN.TonTai = ""

            With Me
                .grdvwChu.Columns.Clear()
                .grdvwChu.ClearSelection()
                .grdvwChu.DataSource = Nothing
                dtChuTCDN.Clear()
                'Gọi phương thức GetData để khởi tạo đối tượng Chu
                If ChuTCDN.GetData(dtChuTCDN) = "" Then
                    'Trình bày dữ liệu lên grdvwHoGiaDinhCaNhan
                    .grdvwChu.DataSource = dtChuTCDN
                    'Khi tồn tại bản ghi nhận được
                    If dtChuTCDN.Rows.Count > 0 Then
                        .FormatGridContruction()
                    Else
                        .HideAllColumns(grdvwChu)
                    End If
                End If
            End With

        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Đối tượng TỔ CHỨC, DOANH NGHIỆP " _
                   & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    ''' <summary>
    ''' Cập nhật thông tin Chủ sử dụng
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateData()
        'Khai bao loi
        'Khai bao va khoi tao doi tuong clsChuSuDung
        Dim ChuTCDN As New clsChuTCDN
        Try
            ChuTCDN.Connection = strConnection ' Khai báo nhận chuỗi kết nối Database
            ChuTCDN.MaChu = strMaChu

            If txtDiaChi.Text IsNot Nothing Then
                ChuTCDN.DiaChi = txtDiaChi.Text.Trim
            Else
                ChuTCDN.DiaChi = ""
            End If

            If txtMaDoiTuong.Text IsNot Nothing Then
                ChuTCDN.DoiTuongSDD = txtMaDoiTuong.Text.Trim
            Else
                ChuTCDN.DoiTuongSDD = ""
            End If

            If (txtTen.Text IsNot Nothing) Then
                ChuTCDN.HoTen = txtTen.Text.Trim
            Else
                If (shortAction = 1) Or (shortAction = 2) Then
                    MsgBox("Ban chua khai bao Ten chu su dung", MsgBoxStyle.Information, "DMCLand")
                    Exit Sub
                Else
                    ChuTCDN.HoTen = ""
                End If
            End If
            If DTPNgayCap.Checked Then
                ChuTCDN.NgayCap = DTPNgayCap.Text
            Else
                ChuTCDN.NgayCap = Nothing
            End If
            If txtNoiCap.Text IsNot Nothing Then
                ChuTCDN.NoiCap = txtNoiCap.Text.Trim
            Else
                ChuTCDN.NoiCap = ""
            End If
            If (txtSoDinhDanh.Text IsNot Nothing) Then
                ChuTCDN.SoDinhDanh = txtSoDinhDanh.Text.Trim
            Else
                ChuTCDN.SoDinhDanh = ""
            End If
            If chbTonTai.Checked Then
                ChuTCDN.TonTai = "1"
            Else
                ChuTCDN.TonTai = "0"
            End If
            Dim str As String = ""
            Dim strCapNhat As String = ""
            'Xác định kiểu cập nhật
            If (shortAction = 1) Then
                'Thêm mới dữ liệu
                strCapNhat = ChuTCDN.InsertData(str)
            ElseIf (shortAction = 2) Then
                'Cập nhật dữ liệu
                strCapNhat = ChuTCDN.UpdateData(str)
            ElseIf (shortAction = 3) Then
                'Xóa dữ liệu
                strCapNhat = ChuTCDN.DeleteData(str)
            End If
            'Nếu cập nhật thành công
            If strCapNhat = "OK" Then
                Me.TrangThaiBanDau()
                shortAction = 0
            End If
            strError = ChuTCDN.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Đối tượng TỔ CHỨC, DOANH NGHIỆP " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Or (strError = "OK") Then
            Me.ShowData()
        End If
    End Sub
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me

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

    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            If blnClearGrid Then
                .HideAllColumns(grdvwChu)
            End If
            'Thiet lap tren Form nhap lieu
            .txtDiaChi.Text = ""
            .txtTen.Text = ""
            .txtMaDoiTuong.Text = ""
            .txtNoiCap.Text = ""
            .txtSoDinhDanh.Text = ""
            .DTPNgayCap.Value = Date.Now
            .DTPNgayCap.Checked = False
            .chbTonTai.Checked = True
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
            'Hien thi du lieu
            If strMaChu <> "" Then
                .ShowData()
            End If
            'Xoa du lieu tren Form
            .TrangThaiBanDau()
            'Khoi tao gia tri ban dau chu bien dung chung
            strMaChu = ""
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat 
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub

    Private Sub btnTraCuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraCuu.Click
        TraCuuChuSuDung()
    End Sub

    Private Sub chbTimKiem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTimKiem.CheckedChanged
        'TRƯỜNG HỢP TÌM KIẾM
        If chbTimKiem.Checked Then
            'Hiển thị nút Tra cứu
            btnTraCuu.Enabled = True
            'Ẩn tất cả các nút còn lại
            Me.TrangThaiChucNang(True, True)
            TraCuuChuSuDung()
        Else
            'TRƯỜNG HỢP CẬP NHẬT
            'Hiển thị các nút cập nhật
            Me.TrangThaiChucNang()
            'Ẩn nút tra cứu
            btnTraCuu.Enabled = False
            'Hiển thị dữ liệu
            ShowData()
        End If
    End Sub

    Private Sub txtMaDoiTuong_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaDoiTuong.DoubleClick
        Dim TuDienChu As New frmBangMa
        With TuDienChu
            .CtrlTuDienDoiTuongSuDungDat.Connection = strConnection
            .CtrlTuDienDoiTuongSuDungDat.Nhom = "1"
            'Hiển thị Form bảng mã giữa màn hình
            TuDienChu.StartPosition = FormStartPosition.CenterScreen
            TuDienChu.ShowDialog()
        End With
        If (TuDienChu.CtrlTuDienDoiTuongSuDungDat.KyHieu IsNot Nothing) And (TuDienChu.CtrlTuDienDoiTuongSuDungDat.KyHieu <> "") Then
            Me.txtMaDoiTuong.Text = TuDienChu.CtrlTuDienDoiTuongSuDungDat.KyHieu.ToString()
        End If
    End Sub

    Private Sub grdvwChu_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdvwChu.CellDoubleClick
        Try
            If (e.RowIndex >= 0) Then
                'Xác định mã Chủ sử dụng
                strMaChu = dtChuTCDN.Rows(e.RowIndex).Item("MaChu").ToString()
                'Khởi tạo đối tượng DataTable chứa bản ghi (Thông tin Chủ sử dụng) được lựa chọn
                dtChuSelect = New DataTable
                'Copy định dạng của đối tượng dtChuTCDN vào đối
                ' tượng DataTable chứa bản ghi (Thông tin Chủ sử dụng) được lựa chọn
                dtChuSelect = dtChuTCDN.Clone()
                'Add bản những chủ sử dụng được lựa chọn vào biến kiểu DataTable dùng chung
                dtChuSelect.ImportRow(dtChuTCDN.Rows(e.RowIndex))
                'Ẩn Form tra cứu thông tin Chủ sử dụng

                'NOTE: CẦN VIẾT SỰ KIỆN ẨN FORM Ở ĐÂY

            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Lỗi: " & ex.Message, "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub grdvwChu_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwChu.CellMouseClick
        'Chỉ thực thi khi người dùng chọn chuột TRÁI
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        If chbTimKiem.Checked = False Then
            'Khai báo và khởi tạo đối tượng Chủ sử dung
            Dim ChuTCDN As New clsChuTCDN
            If e.RowIndex >= 0 Then
                Try
                    'Gán giá trị vào thuộc tính tương ứng của đối tượng Chủ sử dụng
                    With dtChuTCDN.Rows(e.RowIndex)
                        ChuTCDN.DiaChi = .Item("DiaChi").ToString
                        ChuTCDN.DoiTuongSDD = .Item("DoiTuongSDD").ToString
                        ChuTCDN.HoTen = .Item("HoTen").ToString
                        ChuTCDN.MaChu = .Item("MaChu").ToString
                        strMaChu = ChuTCDN.MaChu
                        ChuTCDN.NgayCap = .Item("NgayCap").ToString
                        ChuTCDN.NoiCap = .Item("NoiCap").ToString
                        ChuTCDN.SoDinhDanh = .Item("SoDinhDanh").ToString
                        ChuTCDN.TonTai = .Item("TonTai").ToString
                    End With

                    'Hien thi ban ghi tuong ung lenh Form
                    With Me
                        .txtDiaChi.Text = ChuTCDN.DiaChi
                        .txtTen.Text = ChuTCDN.HoTen
                        .txtMaDoiTuong.Text = ChuTCDN.DoiTuongSDD
                        .txtNoiCap.Text = ChuTCDN.NoiCap
                        .txtSoDinhDanh.Text = ChuTCDN.SoDinhDanh
                        If (ChuTCDN.NgayCap Is Nothing) Then
                            .DTPNgayCap.Checked = False
                            .DTPNgayCap.Value = Date.Now
                        Else
                            .DTPNgayCap.Checked = True
                            .DTPNgayCap.Value = ChuTCDN.NgayCap
                        End If

                        If ChuTCDN.TonTai = "True" Then
                            chbTonTai.Checked = True
                            KTTonTai = True
                        Else
                            chbTonTai.Checked = False
                            chbTonTai.Enabled = False
                            KTTonTai = False
                        End If
                    End With

                Catch ex As Exception
                    strError = ex.Message
                    MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Đối tượng TỔ CHỨC, DOANH NGHIỆP " _
                           & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
                End Try
            End If
        End If
    End Sub

    Private Sub ctrlChuTCDN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                With .DTPNgayCap
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = Windows.Forms.DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                End With
                'Trạng thái cập nhật
                'Cho phép nhập thông tin tìm kiếm
                .TrangThaiCapNhat(True)
                'Trạng thái chức năng
                .TrangThaiChucNang(True, True)
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Đối tượng TỔ CHỨC, DOANH NGHIỆP " _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub chbTonTai_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTonTai.CheckedChanged
        If chbTonTai.Checked Then
            chbTonTai.Text = "Đang tồn tại"
            chbTonTai.ForeColor = Color.Black
        Else
            chbTonTai.Text = "Không còn tồn tại"
            chbTonTai.ForeColor = Color.Red
        End If
    End Sub
End Class
