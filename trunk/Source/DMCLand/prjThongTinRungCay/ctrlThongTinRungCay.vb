Imports System.Drawing
Imports System.Windows.Forms

Public Class ctrlThongTinRungCay
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinRungCay As New DataTable
    Private blnNonNumberEntered As Boolean
    ' Khai báo nhận Tên đơn vị hành chính
    Private strTenDonViHanhChinh As String = ""
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaThongTinRungCay As String = ""
    Private shortAction As Short = 0
    'lay cac gia tri chon dc
    Private strDienTichCoRung As String = ""

    Private strNguonGocTaoLap As String = ""
    Private strSoHoSoGiaoRung As String = ""
    'Khai báo nhận Tên đơn vị hành chính
    Public WriteOnly Property TenDonViHanhChinh() As String
        Set(ByVal value As String)
            strTenDonViHanhChinh = value
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
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property MaThongTinRungCay() As String
        Get
            Return strMaThongTinRungCay
        End Get
        Set(ByVal value As String)
            strMaThongTinRungCay = value
        End Set
    End Property

    Public Sub ShowData()
        'Khai báo và khởi tạo đối tượng
        Dim ThongTinRungCay As New DMC.Land.ThongTinRungCay.clsThongTinRungCay
        'Gán giá trị cho các thuộc tính đối với trường hợp truy vấn
        Try
            With ThongTinRungCay
                'Nhận chuỗi kết nối cơ sở dữ liệu
                .Connection = strConnection
                .MaHoSoCapGCN = strMaHoSoCapGCN
            End With
            dtThongTinRungCay.Clear()
            With Me.grdvwRungCay
                .ClearSelection()
                'Gọi phương thức GetData 
                If ThongTinRungCay.SelectThongTinRungCayByMaHoSoCapGCN(dtThongTinRungCay) = "" Then
                    'Trình bày dữ liệu lên Grid
                    .DataSource = dtThongTinRungCay
                    'Định dạng các cột của Grid
                    If dtThongTinRungCay.Rows.Count > 0 Then
                        Me.FormatGridContruction()
                    Else
                        Me.HideAllColumns(grdvwRungCay)
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
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Thông tin Rừng cây " _
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
        'Khai báo và khởi tạo đối tượng clsThongTinRungCay0
        Dim ThongTinRungCay As New DMC.Land.ThongTinRungCay.clsThongTinRungCay
        Try
            With ThongTinRungCay
                'Nhận chuỗi kết nối cơ sở dữ liệu
                .Connection = strConnection
                .MaThongTinRungCay = strMaThongTinRungCay
                .MaHoSoCapGCN = strMaHoSoCapGCN
                If IsNumeric(numDienTichCoRung.Text) Then
                    .DienTichCoRung = numDienTichCoRung.Text
                Else
                    .DienTichCoRung = Nothing
                End If
                .NguonGocTaoLap = txtNguonGocTaoLap.Text
                .SoHoSoGiaoRung = txtSoHoSoGiaoRung.Text
                Dim str As String = ""
                Dim strResults As String = ""
                If (shortAction = 1) Then
                    strResults = .InsertThongTinRungCay(str)
                ElseIf (shortAction = 2) Then
                    strResults = .UpdateThongTinRungCay(str)
                ElseIf (shortAction = 3) Then
                    strResults = .DeleteThongTinRungCayByMaThongTinRungCay(str)
                ElseIf (shortAction = 4) Then
                    strResults = .DeleteThongTinRungCayByMaHoSoCapGCN(str)
                End If

                If strResults = "" Then
                    ShowData()
                    shortAction = 0
                End If
                strError = ThongTinRungCay.Err
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Thông tin Rừng cây " & vbNewLine & " Cập nhật " & vbNewLine & _
                   " Lỗi " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Nếu tồn tại Mã Thông tin Rừng cây cần xóa
        If strMaThongTinRungCay <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        shortAction = 3
                        .UpdateData()
                        strMaThongTinRungCay = ""
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
            MsgBox(" Bạn phải chọn Thông tin rừng cây cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        'Hiển thị dữ liệu
        Me.ShowData()
        strError = ""
    End Sub
    Public Sub LayDL(ByVal row As Integer)
        If row >= 0 Then
            With Me.dtThongTinRungCay.Rows(row)
                strDienTichCoRung = .Item("DienTichCoRung").ToString
                strNguonGocTaoLap = .Item("NguonGocTaoLap").ToString
                strSoHoSoGiaoRung = .Item("SoHoSoGiaoRung").ToString
            End With
        End If

    End Sub
    Private Sub grdvwRungCay_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvwRungCay.CellMouseClick
        'Chỉ thực thi khi người dùng chọn chuột trái
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khởi tạo đối tượng
        Dim ThongTinRungCay As New DMC.Land.ThongTinRungCay.clsThongTinRungCay
        If e.RowIndex >= 0 Then
            Try
                'Gán giá trị cho các thuộc tính ứng với trường hợp truy vấn
                shortAction = 0

                With Me.dtThongTinRungCay.Rows(e.RowIndex)
                    ThongTinRungCay.DienTichCoRung = .Item("DienTichCoRung").ToString
                    ThongTinRungCay.NguonGocTaoLap = .Item("NguonGocTaoLap").ToString
                    ThongTinRungCay.SoHoSoGiaoRung = .Item("SoHoSoGiaoRung").ToString
                    strMaThongTinRungCay = .Item("MaThongTinRungCay").ToString
                End With
                With Me
                    If IsNumeric(ThongTinRungCay.DienTichCoRung) Then
                        numDienTichCoRung.Text = ThongTinRungCay.DienTichCoRung
                    Else
                        numDienTichCoRung.Text = ""
                    End If
                    Me.txtNguonGocTaoLap.Text = ThongTinRungCay.NguonGocTaoLap
                    Me.txtSoHoSoGiaoRung.Text = ThongTinRungCay.SoHoSoGiaoRung
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Thông tin Rừng cây" _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            .grdvwRungCay.BackgroundColor = Color.White
            'Diện tích 
            With .numDienTichCoRung
                .ReadOnly = Not blnCapNhat
                .Enabled = blnCapNhat
            End With
            .txtNguonGocTaoLap.ReadOnly = Not blnCapNhat
            .txtSoHoSoGiaoRung.ReadOnly = Not blnCapNhat
            If blnCapNhat Then
                'Diện tích 
                .numDienTichCoRung.BackColor = Color.White
                .txtNguonGocTaoLap.BackColor = Color.White
                .txtSoHoSoGiaoRung.BackColor = Color.White
            Else
                .numDienTichCoRung.BackColor = Color.LightYellow
                .txtNguonGocTaoLap.BackColor = Color.LightYellow
                .txtSoHoSoGiaoRung.BackColor = Color.LightYellow
            End If
        End With
    End Sub
    Private Sub btnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThem.Click
        'Bo lua chon tren Grid
        Me.grdvwRungCay.ClearSelection()
        strMaThongTinRungCay = ""
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
        If strMaThongTinRungCay <> "" Then
            shortAction = 2
            'Trang thai chuc nang
            TrangThaiChucNang(True)
            'Trang thai cap nhat
            TrangThaiCapNhat(True)

        Else
            MsgBox(" Bạn chưa chọn Thông tin rừng cây cần sửa thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub
    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        Try
            With Me
                If (blnClearGrid) Then
                    .HideAllColumns(grdvwRungCay)
                End If
                .txtNguonGocTaoLap.Text = ""
                .txtSoHoSoGiaoRung.Text = ""
                .numDienTichCoRung.Text = ""
            End With
        Catch ex As Exception
            MessageBox.Show("Thông tin rừng cây " & vbNewLine & "Trạng thái ban đầu" & vbNewLine & "Lỗi: " & ex.Message(), "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            MsgBox(" Nạp dữ liệu ban đầu " & vbNewLine & " Thông tin rừng cây " & vbNewLine _
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
            With Me.grdvwRungCay
                Me.HideAllColumns(grdvwRungCay)
                'CHỈ HIỆN THỊ NHỮNG CỘT CẦN THIẾT
                'Diện tích
                With .Columns("DienTichCoRung")
                    .Visible = True
                    .HeaderText = "Diện tích"
                    .Width = 120
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nguồn gốc tạo lập
                With .Columns("NguonGocTaoLap")
                    .Visible = True
                    .HeaderText = "Nguồn gốc tạo lập"
                    .Width = 400
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Số hồ sơ giao rừng
                With .Columns("SoHoSoGiaoRung")
                    .Visible = True
                    .HeaderText = "Số hồ sơ giao rừng"
                    .Width = 200
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
            MsgBox(" Thông tin rừng cây " & vbNewLine & "Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnCapNhat_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        'Kiểm tra dữ liệu nhập vào
        Try
            With Me
                'Cập nhật thông tin Rừng cây
                .UpdateData()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Rừng cây " & vbNewLine _
                & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        ShowData()
        'Khởi tạo giá trị cho biến dùng chung
        strMaThongTinRungCay = ""
        strError = ""
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            .ShowData()
            'Khởi tạo giá trị cho biến dùng chung
            strMaThongTinRungCay = ""
        End With
        shortAction = 0
    End Sub
End Class
