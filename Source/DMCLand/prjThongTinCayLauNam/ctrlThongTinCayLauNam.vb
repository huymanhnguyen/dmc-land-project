Imports System.Drawing
Imports System.Windows.Forms

Public Class ctrlThongTinCayLauNam
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinCayLauNam As New DataTable
    Private blnNonNumberEntered As Boolean
    ' Khai báo nhận Tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaThongTinCayLauNam As String = ""
    Private shortAction As Short = 0
    'lay cac gia tri chon dc
    Private strDienTich As String = ""
    Private strLoaiCay As String = ""
    'Khai báo nhận Tên đơn vị hành chính
    Public WriteOnly Property TenDonViHanhChinh() As String
        Set(ByVal value As String)
            strTenDonViHanhChinh = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public WriteOnly Property Flag() As String
        Set(ByVal value As String)
            shortAction = value
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
    Public Property MaThongTinCayLauNam() As String
        Get
            Return strMaThongTinCayLauNam
        End Get
        Set(ByVal value As String)
            strMaThongTinCayLauNam = value
        End Set
    End Property

    Public Sub ShowData()
        'Khai báo và khởi tạo đối tượng
        Dim ThongTinCayLauNam As New DMC.Land.ThongTinCayLauNam.clsThongTinCayLauNam
        'Gán giá trị cho các thuộc tính đối với trường hợp truy vấn
        Try
            With ThongTinCayLauNam
                'Nhận chuỗi kết nối cơ sở dữ liệu
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            dtThongTinCayLauNam.Clear()
            With Me.grdvw
                .ClearSelection()
                'Gọi phương thức GetData 
                If ThongTinCayLauNam.SelectThongTinCayLauNamByMaHoSoCapGCN(dtThongTinCayLauNam) = "" Then
                    'Trình bày dữ liệu lên Grid
                    .DataSource = dtThongTinCayLauNam
                    'Định dạng các cột của Grid
                    If dtThongTinCayLauNam.Rows.Count > 0 Then
                        Me.FormatGridContruction()
                    Else
                        Me.HideAllColumns(grdvw)
                    End If
                End If
            End With
            'Thiết đặt trạng thái ban đầu
            Me.TrangThaiBanDau()
            'Trạng thái chức năng
            Me.TrangThaiChucNang()
            'Trạng thái cập nhật
            Me.TrangThaiCapNhat()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Thông tin Cây lâu năm " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
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

            End If
          
        End With
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo đối tượng clsThongTinCayLauNam
        Dim ThongTinCayLauNam As New DMC.Land.ThongTinCayLauNam.clsThongTinCayLauNam
        Try
            With ThongTinCayLauNam
                'Nhận chuỗi kết nối cơ sở dữ liệu
                .Connection = strConnection
                .MaThongTinCayLauNam = strMaThongTinCayLauNam
                .MaHoSoCapGCN = strMaHoSoCapGCN
                If IsNumeric(numDienTich.Text) Then
                    .DienTich = numDienTich.Text
                Else
                    .DienTich = Nothing
                End If
                .LoaiCay = txtLoaiCay.Text.Trim

                Dim str As String = ""
                Dim strResults As String = ""
                If (shortAction = 1) Then
                    strResults = .InsertThongTinCayLauNam(str)
                ElseIf (shortAction = 2) Then
                    strResults = .UpdateThongTinCayLauNam(str)
                ElseIf (shortAction = 3) Then
                    strResults = .DeleteThongTinCayLauNamByMaThongTinCayLauNam(str)
                ElseIf (shortAction = 4) Then
                    strResults = .DeleteThongTinCayLauNamByMaHoSoCapGCN(str)
                End If

                If strResults = "" Then
                    ShowData()
                    shortAction = 0
                End If

                strError = ThongTinCayLauNam.Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Cây lâu năm " & vbNewLine & " Cập nhật " & vbNewLine & _
                   " Lỗi " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Nếu tồn tại Mã Thông tin Cây lâu năm cần xóa
        If strMaThongTinCayLauNam <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        shortAction = 3
                        .UpdateData()
                        strMaThongTinCayLauNam = ""
                        'Hiển thị dữ liệu
                        .ShowData()
                        'Trạng thái chức năng
                    End With
                Catch ex As Exception
                    strError = ex.Message
                End Try
                If (strError = "") Then
                    MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                Else
                    MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                End If
            End If
        Else
            MsgBox(" Bạn phải chọn Thông tin Cây lâu năm cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        'Hiển thị dữ liệu
        Me.ShowData()
        strError = ""
    End Sub
    Private Sub grdvw_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvw.CellMouseClick
        'Chỉ thực thi khi người dùng chọn chuột trái
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khởi tạo đối tượng
        Dim ThongTinCayLauNam As New DMC.Land.ThongTinCayLauNam.clsThongTinCayLauNam
        If e.RowIndex >= 0 Then
            Try
                'Gán giá trị cho các thuộc tính ứng với trường hợp truy vấn
                shortAction = 0

                With Me.dtThongTinCayLauNam.Rows(e.RowIndex)
                    ThongTinCayLauNam.DienTich = .Item("DienTich").ToString
                    ThongTinCayLauNam.LoaiCay = .Item("LoaiCay").ToString
                    strMaThongTinCayLauNam = .Item("MaThongTinCayLauNam").ToString
                End With
                With Me
                    If IsNumeric(ThongTinCayLauNam.DienTich) Then
                        Me.numDienTich.Text = ThongTinCayLauNam.DienTich
                    Else
                        Me.numDienTich.Text = ""
                    End If
                    Me.txtLoaiCay.Text = ThongTinCayLauNam.LoaiCay
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Thông tin Cây lâu năm" _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .grdvw.BackgroundColor = Color.White
            'Diện tích 
            With .numDienTich
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            .txtLoaiCay.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                'Diện tích 
                .numDienTich.BackColor = Color.White
                .txtLoaiCay.BackColor = Color.White
            Else
                .numDienTich.BackColor = Color.LightYellow
                .txtLoaiCay.BackColor = Color.LightYellow
            End If
        End With
    End Sub
    Private Sub btnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThem.Click
        'Bo lua chon tren Grid
        Me.grdvw.ClearSelection()
        strMaThongTinCayLauNam = ""
        shortAction = 1
        With Me
            'Thiet lap trang thai ban dau
            .TrangThaiBanDau()
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            'Trang thai chuc nang 
            .TrangThaiChucNang(True)
        End With
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaThongTinCayLauNam <> "" Then
            shortAction = 2
            'Trang thai chuc nang
            TrangThaiChucNang(True)
            'Trang thai cap nhat
            TrangThaiCapNhat(True)
        Else
            MsgBox(" Bạn chưa chọn Thông tin Cây lâu năm cần sửa thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub
    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        Try
            With Me
                If (blnClearGrid) Then
                    .HideAllColumns(grdvw)
                End If
                .txtLoaiCay.Text = ""
                .numDienTich.Text = ""
            End With
        Catch ex As Exception
            MessageBox.Show("Thông tin Cây lâu năm " & vbNewLine & "Trạng thái ban đầu" & vbNewLine & "Lỗi: " & ex.Message(), "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ctrlThongTinRungCay0_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If strMaHoSoCapGCN = "" Then
                Me.TrangThaiBanDau()
                Me.TrangThaiCapNhat()
                'Trạng thái chức năng
                Me.TrangThaiChucNang()
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Thông tin Cây lâu năm " & vbNewLine _
            & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
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
    Public Sub FormatGridContruction()
        Try
            With Me.grdvw
                Me.HideAllColumns(grdvw)
                'CHỈ HIỆN THỊ NHỮNG CỘT CẦN THIẾT
                'Diện tích
                With .Columns("DienTich")
                    .Visible = True
                    .HeaderText = "Diện tích"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nguồn gốc tạo lập
                With .Columns("LoaiCay")
                    .Visible = True
                    .HeaderText = "Loại cây"
                    .Width = 500
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
            MsgBox(" Thông tin Cây lâu năm " & vbNewLine & "Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnCapNhat_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        'Kiểm tra dữ liệu nhập vào
        Try
            With Me
                'Cập nhật thông tin Cây lâu năm
                .UpdateData()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Cây lâu năm " & vbNewLine _
                & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        ShowData()
        'Khởi tạo giá trị cho biến dùng chung
        strMaThongTinCayLauNam = ""
        strError = ""
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            .ShowData()
            'Khởi tạo giá trị cho biến dùng chung
            strMaThongTinCayLauNam = ""
        End With
        shortAction = 0
    End Sub
End Class
