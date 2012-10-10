Imports System.IO
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing
Public Class ctrlTaiLieuKemTheo
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai bao bien kiem tra loi
    Private strError As String = ""
    'Dim DS As New DataSet
    Dim dtTaiLieuKemTheo As DataTable
    Dim strMaTaiLieuKemTheo As String = ""
    Dim strSTTTaiLieuKemTheo As String = ""
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
    Private MaLoaiBienDong As String = ""
    Public Property MaKhoa() As String
        Get
            Return MaLoaiBienDong
        End Get
        Set(ByVal value As String)
            MaLoaiBienDong = value
        End Set
    End Property
    'Mã hồ sơ cấp GCN
    Dim strMaHoSoCapGCN As String = ""
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Tên tệp dữ liệu nguồn 
    Dim strTenTepDuLieuNguon As String = ""
    Public Property TenTepDuLieuNguon() As String
        Get
            Return strTenTepDuLieuNguon
        End Get
        Set(ByVal value As String)
            strTenTepDuLieuNguon = value
        End Set
    End Property

    Dim strTenTaiLieu As String = ""
    Public Property TenTaiLieu() As String
        Get
            Return strTenTaiLieu
        End Get
        Set(ByVal value As String)
            strTenTaiLieu = value
        End Set
    End Property
    'Khai báo biến Mô tả kiểu String
    Dim strMoTa As String = ""
    'Khai báo thuộc tính nhận thông tin Mô tả
    Public Property MoTa() As String
        Get
            Return strMoTa
        End Get
        Set(ByVal value As String)
            strMoTa = value
        End Set
    End Property
    'Khai báo thuộc tính Mã Tài liệu kèm theo
    Public Property MaTaiLieuKemTheo() As String
        Get
            Return strMaTaiLieuKemTheo
        End Get
        Set(ByVal value As String)
            strMaTaiLieuKemTheo = value
        End Set
    End Property

    'Khai báo biến lưu trữ Tài liệu, kiểu mảng byte 
    Dim byteTaiLieu() As Byte
    Public Property TaiLieu() As Byte()
        Get
            Return byteTaiLieu
        End Get
        Set(ByVal value As Byte())
            byteTaiLieu = value
        End Set
    End Property
    Public Sub NhatKyNguoiDung(ByVal ChucNang As String, ByVal MoTa As String)
        Dim clsNhatky As New prjNhatKyNguoiDung.clsNhatKyNguoiDung
        clsNhatky.Connection = strConnection
        clsNhatky.MaHoSoCapGCN = strMaHoSoCapGCN
        clsNhatky.MaDonViHanhChinh = strMaDonViHanhChinh
        clsNhatky.NghiepVu = "Cập nhật tài liệu kèm theo"
        clsNhatky.ChucNang = ChucNang
        clsNhatky.MoTa = MoTa
        clsNhatky.DuongDanFile = Application.StartupPath
        clsNhatky.LuuNhatKyNguoiDung()
    End Sub
    ''' <summary>
    ''' Ẩn tất cả các cột trên Grid
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
    ''' Định dạng lại cấu trúc Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FormatGridContruction()
        Try
            'Ẩn tất cả các cột
            Me.HideAllColumns(grdDanhSachFile)
            With Me.grdDanhSachFile
                With .Columns("TenTaiLieu")
                    .HeaderText = "Tên tài liệu"
                    .Width = 200
                    .Visible = True
                End With
                With .Columns("MoTa")
                    .HeaderText = "Mô tả tài liệu"
                    .Width = 500
                    .Visible = True
                End With
                With .Columns("TenTepDuLieuNguon")
                    .HeaderText = "Tên tệp dữ liệu nguồn"
                    .Width = 200
                    .Visible = True
                End With
                With .Columns("Chon")
                    .HeaderText = "Chọn"
                    .Width = 100
                    .Visible = True
                End With
                .BackgroundColor = Color.WhiteSmoke
                .GridColor = Color.WhiteSmoke
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Khong cho phep them
                .AllowUserToAddRows = False
                'Khong cho phep xoa
                .AllowUserToDeleteRows = False
                'Khong lua chon bat ky dong nao luc ban dau
                .ClearSelection()
            End With
        Catch ex As Exception
            'strError = ex.Message
            MsgBox(" Tài liệu kèm theo " & vbNewLine & _
                   "Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    ''' <summary>
    ''' Cập mhật dữ liệu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateData()
        strError = ""
        Try
            'Khai báo biến đọc tệp mảng byte
            Dim byteData As Byte() = Nothing
            'Khai báo và khởi tạo đối tượng clsTaiLieuKemTheo
            Dim TaiLieuKemTheo As New clsTaiLieuKemTheo
            'Xác nhận chuỗi kết nối cơ sở dữ liệu
            TaiLieuKemTheo.Connection = strConnection
            'Xác nhận Mã Hồ sơ cấp GCN
            TaiLieuKemTheo.MaHoSoCapGCN = strMaHoSoCapGCN

 

            'Trường hợp thêm
            If shortAction = 1 Then
                If chkCoFile.Checked Then
                    For i As Integer = 0 To grdvwTaiLieuKemTheo.RowCount - 1
                        If grdvwTaiLieuKemTheo.Rows(i).Cells("Chon").Value.ToString = "True" Then
                            'Xác nhận Mã Tài liệu kèm theo
                            TaiLieuKemTheo.MaTaiLieuKemTheo = strMaTaiLieuKemTheo
                            'Xác nhận Tên tệp dữ liệu nguồn
                            Dim strFile As String = grdvwTaiLieuKemTheo.Rows(i).Cells("DuongDanFile").Value.ToString
                            Dim strMang() As String = strFile.Split("\")
                            Dim strTenFile As String = strMang(strMang.Length - 1)
                            TaiLieuKemTheo.TenTepDuLieuNguon = strTenFile
                            'Xác nhận Mô tả
                            TaiLieuKemTheo.MoTa = grdvwTaiLieuKemTheo.Rows(i).Cells("MoTa").Value.ToString
                            TaiLieuKemTheo.TenTaiLieu = grdvwTaiLieuKemTheo.Rows(i).Cells("Ten").Value.ToString
                            'Read data Bytes into a byte array with new record addition case
                            If grdvwTaiLieuKemTheo.Rows(i).Cells("DuongDanFile").Value.ToString <> "" Then
                                byteData = TaiLieuKemTheo.ReadFile(grdvwTaiLieuKemTheo.Rows(i).Cells("DuongDanFile").Value.ToString)
                                TaiLieuKemTheo.TaiLieu = byteData
                            Else
                                TaiLieuKemTheo.TaiLieu = Nothing
                            End If


                            TaiLieuKemTheo.InsertTaiLieuKemTheo()
                            'strThongTinChuCu = txtTenTepDuLieuNguon.Text.Trim & " _ " & txtMoTa.Text
                            NhatKyNguoiDung("Thêm", grdvwTaiLieuKemTheo.Rows(i).Cells("DuongDanFile").Value.ToString & " _ " & grdvwTaiLieuKemTheo.Rows(i).Cells("MoTa").Value.ToString)
                            'Trường hợp cập nhật theo Mã Tài liệu kèm theo
                        End If
                    Next
                Else
                    TaiLieuKemTheo.MaTaiLieuKemTheo = strMaTaiLieuKemTheo 
                    TaiLieuKemTheo.TenTepDuLieuNguon = ""
                    TaiLieuKemTheo.TenTaiLieu = txtTenTaiLieu.Text.Trim 
                    TaiLieuKemTheo.MoTa = txtMoTa.Text 
                    TaiLieuKemTheo.TaiLieu = Nothing
                    TaiLieuKemTheo.InsertTaiLieuKemTheo()
                    NhatKyNguoiDung("Thêm", txtTenTaiLieu.Text & " _ " & txtMoTa.Text)
                    'Trường hợp cập nhật theo Mã Tài liệu kèm theo
                End If

            ElseIf shortAction = 2 Then
            'Xác nhận Mã Tài liệu kèm theo
                TaiLieuKemTheo.MaTaiLieuKemTheo = strMaTaiLieuKemTheo
            'Xác nhận Tên tệp dữ liệu nguồn
                TaiLieuKemTheo.TenTepDuLieuNguon = strTenTepDuLieuNguon
                TaiLieuKemTheo.TenTaiLieu = txtTenTaiLieu.Text
            'Xác nhận Mô tả
                TaiLieuKemTheo.MoTa = txtMoTa.Text

            'Read data Bytes into a byte array with new record addition case
                If txtTenTepDuLieuNguon.Text <> "" Then
                    byteData = TaiLieuKemTheo.ReadFile(txtTenTepDuLieuNguon.Text)
                    TaiLieuKemTheo.TaiLieu = byteData
                Else
                    TaiLieuKemTheo.TaiLieu = Nothing
                End If
                TaiLieuKemTheo.UpdateTaiLieuKemTheo()
                NhatKyNguoiDung("Sửa", "Thay (" & strThongTinChuCu & " bằng (" & txtTenTepDuLieuNguon.Text.Trim & " _ " & txtMoTa.Text & ")")
            Else
                Exit Sub
            End If
            'Close form and return to list or images.
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Lỗi tải dữ liệu lên Server! " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Try
            With Me
                'Gán giá trị cho các thuộc tính
                'Tên tệp dữ liệu nguồn
                strTenTepDuLieuNguon = .txtTenTepDuLieuNguon.Text.Trim
                'Mô tả tài liệu 
                strTenTaiLieu = .txtTenTaiLieu.Text.Trim
                strMoTa = .txtMoTa.Text.Trim
                'Cập nhật thông tin
                .UpdateData()
                .cmdTaiFile.Enabled = False
                .cmdSuaTTFile.Enabled = False
                .cmdCapNhatMoTa.Enabled = False
                'Trạng thái chức năng
                .TrangThaiChucNang()
                'Trạng thái cập nhật
                .TrangThaiCapNhat()
                cmdFile.Enabled = False
            End With
            Me.ShowData()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Yêu cầu bổ xung " & vbNewLine _
                & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        'Khoi tao gia tri cho bien dung chung
        strMaTaiLieuKemTheo = ""
        strError = ""
    End Sub

 

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        'Thiet dat Co cap nhat
        shortAction = 1
        'Thiet dat cac gia tri ve trang thai khoi tao
        strMaTaiLieuKemTheo = ""
        With Me
            'Thiet lap trang thai ban dau
            .TrangThaiBanDau()

            .cmdTaiFile.Enabled = True
            .cmdSuaTTFile.Enabled = True
            .cmdCapNhatMoTa.Enabled = False

            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            'Trang thai chuc nang 
            .TrangThaiChucNang(True)
        End With
       
    End Sub
    ''' <summary>
    ''' Hiển thị dữ liệu
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox2.Enabled = True
            Me.GroupBox1.Enabled = True
        Else
            Me.GroupBox1.Enabled = False
            Me.GroupBox2.Enabled = False
        End If
        Try
            'Khai báo đối tượng clsTaiLieuKemTheo
            Dim TaiLieuKemTheo As New clsTaiLieuKemTheo()
            'Gán chuỗi kết nối cơ sở dữ liệu
            TaiLieuKemTheo.Connection = strConnection
            TaiLieuKemTheo.MaHoSoCapGCN = strMaHoSoCapGCN
            TaiLieuKemTheo.MaTaiLieuKemTheo = strMaTaiLieuKemTheo
            If (strMaTaiLieuKemTheo <> "") And (shortAction = 0) Then
                'Lựa chọn theo Mã Tài liệu kèm theo
                dtTaiLieuKemTheo = TaiLieuKemTheo.SelectTaiLieuKemTheoByMaTaiLieuKemTheo
            Else
                'Lựa chọn theo Mã hồ sơ câp GCN
                dtTaiLieuKemTheo = TaiLieuKemTheo.SelectTaiLieuKemTheoByMaHoSoCapGCN()
            End If
            'Hiển thị dữ liệu
            Me.grdDanhSachFile.DataSource = dtTaiLieuKemTheo
            If (dtTaiLieuKemTheo.Rows.Count > 0) Then
                'Định dạng lại cột trên Grid
                Me.FormatGridContruction()
            Else
                Me.HideAllColumns(grdDanhSachFile)
            End If

        Catch ex As Exception
            strError = ex.Message
            MsgBox(ex.Message)
        End Try
        'Thiết đặt cờ về giá trị ban đầu
        shortAction = 0
    End Sub

    Private Sub btnTaiVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaiVe.Click
        Try
            shortAction = 0
            Dim strSaveFileName As String = ""
            Dim TaiLieuKemTheo As New clsTaiLieuKemTheo()
            TaiLieuKemTheo.Connection = strConnection
            TaiLieuKemTheo.MaHoSoCapGCN = strMaHoSoCapGCN
            Dim FolderBrowserDialog1 As New FolderBrowserDialog
            With FolderBrowserDialog1
                .RootFolder = Environment.SpecialFolder.Desktop
                .SelectedPath = "c:\"
                .Description = "Chon thu muc chua cac tep tai ve"
                If .ShowDialog = DialogResult.OK Then
                    txtThuMucChuaFile.Text = .SelectedPath.Trim
                    For i As Integer = 0 To grdDanhSachFile.Rows.Count - 1
                        If grdDanhSachFile.Rows(i).Cells("Chon").Value.ToString = "True" Then
                            strSaveFileName = txtThuMucChuaFile.Text.Trim & "\" & grdDanhSachFile.Rows(i).Cells("TenTepDuLieuNguon").Value.ToString

                            Dim dtTaiLieuKemTheo As New DataTable

                            TaiLieuKemTheo.MaTaiLieuKemTheo = grdDanhSachFile.Rows(i).Cells("MaTaiLieuKemTheo").Value.ToString
                            If (strMaTaiLieuKemTheo <> "") And (shortAction = 0) Then
                                'Lựa chọn theo Mã Tài liệu kèm theo
                                dtTaiLieuKemTheo = TaiLieuKemTheo.SelectTaiLieuKemTheoByMaTaiLieuKemTheo
                            Else
                                'Lựa chọn theo Mã hồ sơ câp GCN
                                dtTaiLieuKemTheo = TaiLieuKemTheo.SelectTaiLieuKemTheoByMaHoSoCapGCN()
                            End If

                            If dtTaiLieuKemTheo.Rows.Count <= 0 Then
                                Exit Sub
                            Else
                                'Ghi File tài liệu lên ổ cứng
                                TaiLieuKemTheo.SaveFile(strSaveFileName, dtTaiLieuKemTheo.Rows(0).Item("TaiLieu"), CInt(dtTaiLieuKemTheo.Rows(0).Item("KichThuoc")))
                            End If
                        End If
                    Next
                End If
            End With
            MsgBox("Tải File hoàn thành !", MsgBoxStyle.Information, "DMCLand")
        Catch ex As Exception
            MsgBox(" Lỗi ghi dữ liệu: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "DMCLand")
        End Try


        ''Thiet dat Co ve gia tri ban dau
        'shortAction = 0
        'If strMaTaiLieuKemTheo = "" Then
        '    MsgBox("Bạn phải chọn một tài liệu cần tải về!", MsgBoxStyle.Information, "DMCLand")
        '    Exit Sub
        'Else
        '    If txtTenTepDuLieuNguon.Text = "" Then
        '        MsgBox("Tài liệu không có file đính kèm!", MsgBoxStyle.Information, "DMCLand")
        '        Return
        '    End If
        '    Dim dlgSaveFile As New SaveFileDialog
        '    Dim strSaveFileName As String = ""
        '    'streamwriter is used to write text
        '    Try
        '        With dlgSaveFile
        '            .Title = "Tai du lieu ve may"
        '            .FileName = strSaveFileName
        '            .Filter = "Bitmap Image (*.bmp)|*.bmp|" _
        '            & "JPG Image (*.JPG)|*.JPG|" _
        '            & "Word 97-2003 (*.doc)|*.doc|" & "Word 2007 (*.docx)|*.docx|" _
        '            & "Excel 97-2003 (*.xls)|*.xls|" & "Excel 2007 (*.xlsx)|*.xlsx|" _
        '            & "PDF (*.pdf)|*.pdf|" _
        '            & "All files (*.*)|*.*"
        '            If .ShowDialog() = DialogResult.OK Then
        '                strSaveFileName = .FileName
        '                'Khai bao bien kieu Dataset nhan du lieu
        '                Dim dtTaiLieuKemTheo As New DataTable
        '                Dim TaiLieuKemTheo As New clsTaiLieuKemTheo()
        '                TaiLieuKemTheo.Connection = strConnection
        '                TaiLieuKemTheo.MaHoSoCapGCN = strMaHoSoCapGCN
        '                TaiLieuKemTheo.MaTaiLieuKemTheo = strMaTaiLieuKemTheo
        '                If (strMaTaiLieuKemTheo <> "") And (shortAction = 0) Then
        '                    'Lựa chọn theo Mã Tài liệu kèm theo
        '                    dtTaiLieuKemTheo = TaiLieuKemTheo.SelectTaiLieuKemTheoByMaTaiLieuKemTheo
        '                Else
        '                    'Lựa chọn theo Mã hồ sơ câp GCN
        '                    dtTaiLieuKemTheo = TaiLieuKemTheo.SelectTaiLieuKemTheoByMaHoSoCapGCN()
        '                End If

        '                If dtTaiLieuKemTheo.Rows.Count <= 0 Then
        '                    Exit Sub
        '                Else
        '                    'Ghi File tài liệu lên ổ cứng
        '                    TaiLieuKemTheo.SaveFile(strSaveFileName, dtTaiLieuKemTheo.Rows(0).Item("TaiLieu"))
        '                End If
        '                MsgBox("Dữ liệu đã tải về thành công!", MsgBoxStyle.Information, "DMCLand")
        '            End If
        '        End With
        '    Catch ex As Exception
        '        MsgBox(" Lỗi ghi dữ liệu: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "DMCLand")
        '    End Try
        'End If
    End Sub

    ''' <summary>
    ''' Xác định trạng thái cho các ô nhập liệu
    ''' </summary>
    ''' <param name="blnCapNhat"></param>
    ''' <remarks></remarks>
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .grdvwTaiLieuKemTheo.BackgroundColor = Color.White

            .txtMoTa.ReadOnly = Not blnCapNhat
            .txtTenTepDuLieuNguon.ReadOnly = True

            If blnCapNhat Then
                .txtMoTa.BackColor = Color.White
                .txtTenTepDuLieuNguon.BackColor = Color.LightYellow
            Else
                .txtMoTa.BackColor = Color.LightYellow
                .txtTenTepDuLieuNguon.BackColor = Color.LightYellow
            End If
        End With
    End Sub
    ''' <summary>
    ''' Thiết lập trạng thái cho ô nhập liệu
    ''' và Grid về trạng thái ban đầu
    ''' </summary>
    ''' <param name="blnClearGrid"></param>
    ''' <remarks></remarks>
    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            'Ẩn tất cả các cột trên Grid
            .HideAllColumns(grdvwTaiLieuKemTheo)
            'Thiet lap tren Form nhap lieu
            .txtMoTa.Text = ""
            .txtTenTepDuLieuNguon.Text = ""
        End With
    End Sub
    ''' <summary>
    ''' Thiết lập trạng thái cho các nút cập nhật
    ''' </summary>
    ''' <param name="blnStartEdited"></param>
    ''' <param name="blnStartDeleted"></param>
    ''' <remarks></remarks>
    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox2.Enabled = True
                Me.GroupBox1.Enabled = True
                .btnSua.Enabled = Not blnStartEdited
                .btnXoa.Enabled = Not blnStartEdited
                .btnThem.Enabled = Not blnStartEdited
                .btnCapNhat.Enabled = blnStartEdited
                .btnHuyLenh.Enabled = blnStartEdited
                If blnStartDeleted Then
                    .btnCapNhat.Enabled = Not blnStartDeleted
                    .btnHuyLenh.Enabled = Not blnStartDeleted
                End If
            Else
                Me.GroupBox1.Enabled = False
                Me.GroupBox2.Enabled = False
            End If
           
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        'Dat Co ve gia tri ban dau
        shortAction = 4
        With Me
            'Hien thi du lieu
            If strMaTaiLieuKemTheo <> "" Then
                .ShowData()
            End If
            'Xoa du lieu tren Form
            .TrangThaiBanDau()

            .cmdTaiFile.Enabled = False
            .cmdSuaTTFile.Enabled = False
            .cmdCapNhatMoTa.Enabled = False

            'Khoi tao gia tri cho bien dung chung
            strMaTaiLieuKemTheo = ""
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat 
            .TrangThaiCapNhat()
            cmdFile.Enabled = False
        End With
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaTaiLieuKemTheo <> "" Then
            'Dat Co sua
            shortAction = 2
            'Trang thai chuc nang
            TrangThaiChucNang(True)
            'Trang thai cap nhat
            TrangThaiCapNhat(True)
            cmdFile.Enabled = True
        Else
            MsgBox(" Bạn chưa chọn Tai lieu can sua!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Nếu tồn tại Mã cần xóa
        If strMaTaiLieuKemTheo <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        'Khai báo và khởi tạo đối tượng clsTaiLieuKemTheo
                        Dim TaiLieuKemTheo As New clsTaiLieuKemTheo
                        'Xác nhận chuỗi kết nối cơ sở dữ liệu
                        TaiLieuKemTheo.Connection = strConnection
                        'Xác nhận Mã hồ sơ cấp GCN
                        TaiLieuKemTheo.MaHoSoCapGCN = strMaHoSoCapGCN
                        'Xác nhận Mã tài liệu kèm theo
                        TaiLieuKemTheo.MaTaiLieuKemTheo = strMaTaiLieuKemTheo
                        'Xác nhận Tài liệu kèm theo
                        TaiLieuKemTheo.TaiLieu = byteTaiLieu
                        TaiLieuKemTheo.DeleteTaiLieuKemTheoByMaTaiLieuKemTheo()
                        NhatKyNguoiDung("Xóa", txtTenTepDuLieuNguon.Text.Trim & " _ " & txtMoTa.Text)
                        strMaTaiLieuKemTheo = ""
                        'Trang thai ban dau
                        .TrangThaiBanDau()
                        'Hien thi du lieu
                        .ShowData()
                        'Trang thai chuc nang
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
                'Trang thai chuc nang
                Me.TrangThaiChucNang()
            End If
        Else
            MsgBox(" Bạn chưa chọn Tài liệu cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        'Trang thai cap nhat 
        Me.TrangThaiCapNhat()
        strError = ""
    End Sub

    Private Sub ctrlTaiLieuKemTheoSQL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            With Me
                .cmdTaiFile.Enabled = False
                .cmdSuaTTFile.Enabled = False
                .cmdCapNhatMoTa.Enabled = False
                'Trang thai cap nhat
                .TrangThaiCapNhat()
                'Trang thai chuc nang
                .TrangThaiChucNang(True, True)
                cmdFile.Enabled = False
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox("  " & vbNewLine & " Tài liệu kèm theo " _
            & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub grdvwTaiLieuKemTheo_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwTaiLieuKemTheo.CellMouseClick
        'Khong cho chon chuot phai
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If

        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Me.checkColumn(grdvwTaiLieuKemTheo, e.RowIndex, e.ColumnIndex)
        End If

        'Khoi tao doi tuong 
        'Dim cls As New DMC.Land.HoSoKeKhai.clsTaiLieuKemTheo 
        If e.RowIndex >= 0 Then
            Try
                'Hiển thị thông 
                strSTTTaiLieuKemTheo = grdvwTaiLieuKemTheo.Rows(e.RowIndex).Cells("STT").Value.ToString
                'Hien thi ban ghi tuong ung lenh Form
                Me.txtMoTa.Text = grdvwTaiLieuKemTheo.Rows(e.RowIndex).Cells("MoTa").Value.ToString

                If grdvwTaiLieuKemTheo.Rows(e.RowIndex).Cells("DuongDanFile").Value.ToString <> "" Then
                    Dim s As String = grdvwTaiLieuKemTheo.Rows(e.RowIndex).Cells("DuongDanFile").Value.ToString
                    Dim mang() As String = s.Split("\")
                    Me.txtTenTaiLieu.Text = mang(mang.Length - 1).ToString
                End If

                Me.txtTenTepDuLieuNguon.Text = grdvwTaiLieuKemTheo.Rows(e.RowIndex).Cells("DuongDanFile").Value.ToString
            Catch ex As Exception
                'strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Yêu cầu bổ xung" _
                       & vbNewLine & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub
    
    Private Sub cmdTaiFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTaiFile.Click
        'Ask user to select file.
        Dim dlgOpenFile As New OpenFileDialog
        With dlgOpenFile
            .Title = "Chon tai lieu"
            .Multiselect = True
            .Filter = "Bitmap Image (*.bmp)|*.bmp|" _
                & "JPG Image (*.JPG)|*.JPG|" _
                & "Word 97-2003 (*.doc)|*.doc|" & "Word 2007 (*.docx)|*.docx|" _
                & "Excel 97-2003 (*.xls)|*.xls|" & "Excel 2007 (*.xlsx)|*.xlsx|" _
                & "PDF (*.pdf)|*.pdf|" _
                & "All files (*.*)|*.*"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                grdvwTaiLieuKemTheo.Columns.Clear()
                Dim mytable As New DataTable

                Dim columnSTT As New DataColumn()
                columnSTT.ColumnName = "STT"
                columnSTT.DataType = System.Type.GetType("System.String")
                mytable.Columns.Add(columnSTT)


                Dim columnSpec As New DataColumn()
                columnSpec.ColumnName = "DuongDanFile"
                columnSpec.DataType = System.Type.GetType("System.String")
                mytable.Columns.Add(columnSpec)

                Dim Ten As New DataColumn()
                Ten.ColumnName = "Ten"
                Ten.DataType = System.Type.GetType("System.String")
                mytable.Columns.Add(Ten)

                Dim MoTa As New DataColumn()
                MoTa.ColumnName = "MoTa"
                MoTa.DataType = System.Type.GetType("System.String")
                mytable.Columns.Add(MoTa)

                Dim col As New DataColumn()
                col.ColumnName = "Chon"
                col.DataType = System.Type.GetType("System.Boolean")
                mytable.Columns.Add(col)

                For i As Integer = 0 To dlgOpenFile.FileNames.Length - 1
                    Dim row = mytable.NewRow
                    row(columnSTT) = (i + 1).ToString.Trim
                    row(columnSpec) = dlgOpenFile.FileNames(i).ToString.Trim

                    If dlgOpenFile.FileNames(i).ToString.Trim <> "" Then
                        Dim s As String = dlgOpenFile.FileNames(i).ToString.Trim
                        Dim mang() As String = s.Split("\")
                        row(Ten) = mang(mang.Length - 1).ToString
                    End If


                    row(MoTa) = ""
                    row(col) = True
                    mytable.Rows.Add(row)
                Next
                grdvwTaiLieuKemTheo.DataSource = mytable
            End If
        End With
    End Sub
    Private Sub checkColumn(ByRef grdvw As DataGridView, ByVal intRowIndex As Int32, ByVal intColumnIndex As Int32)
        If (intRowIndex) < 0 Then
            Exit Sub
        End If
        If intColumnIndex >= 0 Then
            If grdvw.Columns(intColumnIndex).Name.ToUpper() = "chon".ToUpper Then
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
        End If
    End Sub
    Private Sub grdDanhSachFile_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhSachFile.CellMouseClick
        'Khong cho chon chuot phai
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If

        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Me.checkColumn(grdDanhSachFile, e.RowIndex, e.ColumnIndex)
        End If
        'Khoi tao doi tuong 
        'Dim cls As New DMC.Land.HoSoKeKhai.clsTaiLieuKemTheo 
        If e.RowIndex >= 0 Then
            Try
                'Chắc chắn rằng Datatable có thông tin để hiển thị 
                If (dtTaiLieuKemTheo Is Nothing) Then
                    Return
                End If
                'Hiển thị thông
                With dtTaiLieuKemTheo.Rows(e.RowIndex)
                    strMaTaiLieuKemTheo = .Item("MaTaiLieuKemTheo").ToString
                    'Hien thi ban ghi tuong ung lenh Form
                    Me.txtMoTa.Text = .Item("MoTa").ToString
                    Me.txtTenTepDuLieuNguon.Text = .Item("TenTepDuLieuNguon").ToString
                    If txtTenTepDuLieuNguon.Text.Trim <> "" Then
                        byteTaiLieu = .Item("TaiLieu")
                    End If
                    strThongTinChuCu = txtTenTepDuLieuNguon.Text.Trim & " _ " & txtMoTa.Text
                End With
            Catch ex As Exception
                'strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Yêu cầu bổ xung" _
                       & vbNewLine & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub cmdCapNhatMoTa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCapNhatMoTa.Click
        If strSTTTaiLieuKemTheo <> "" Then
            Dim stt As Integer = Convert.ToInt16(strSTTTaiLieuKemTheo)
            grdvwTaiLieuKemTheo.Rows(stt - 1).Cells("MoTa").Value = Me.txtMoTa.Text
            grdvwTaiLieuKemTheo.Rows(stt - 1).Cells("DuongDanFile").Value = Me.txtTenTepDuLieuNguon.Text
            cmdSuaTTFile.Enabled = True
            cmdCapNhatMoTa.Enabled = False
        End If
    End Sub

    Private Sub cmdSuaTTFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSuaTTFile.Click
        cmdSuaTTFile.Enabled = False
        cmdCapNhatMoTa.Enabled = True
    End Sub

   
    Private Sub cmdFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFile.Click
        'Ask user to select file.
        Dim dlgOpenFile As New OpenFileDialog
        With dlgOpenFile
            .Title = "Chon tai lieu"
            .Filter = "Bitmap Image (*.bmp)|*.bmp|" _
                & "JPG Image (*.JPG)|*.JPG|" _
                & "Word 97-2003 (*.doc)|*.doc|" & "Word 2007 (*.docx)|*.docx|" _
                & "Excel 97-2003 (*.xls)|*.xls|" & "Excel 2007 (*.xlsx)|*.xlsx|" _
                & "PDF (*.pdf)|*.pdf|" _
                & "All files (*.*)|*.*"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then 
                If dlgOpenFile.FileName.ToString.Trim <> "" Then
                    txtTenTepDuLieuNguon.Text = dlgOpenFile.FileName.ToString.Trim
                    Dim s As String = dlgOpenFile.FileName.ToString.Trim
                    Dim mang() As String = s.Split("\")
                    txtTenTaiLieu.Text = mang(mang.Length - 1).ToString
                End If
            End If
        End With
    End Sub
End Class
