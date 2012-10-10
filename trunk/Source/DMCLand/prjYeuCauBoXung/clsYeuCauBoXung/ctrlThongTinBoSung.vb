Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlThongTinBoSung
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    Private strError As String = "" 'Khai bao bien kiem tra loi
    Private strMaHoSoCapGCN As String = ""
    Private dtThongTinBoXung As New DataTable
    Private strMaYeuCauBoXung As String = ""
    Private shortAction As Short = 0
    'Khai báo biến nhận chuỗi kết nối Database
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
    Private MaLoaiBienDong As String = ""
    Public Property MaKhoa() As String
        Get
            Return MaLoaiBienDong
        End Get
        Set(ByVal value As String)
            MaLoaiBienDong = value
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

    Public Sub FormatGridContruction()

        Try
            With Me.grdrwYeuCauBoXung
                Me.HideAllColumns(grdrwYeuCauBoXung)
                '
                With .Columns("HoanTatBoXung")
                    .HeaderText = "Hoàn tất"
                    .Width = 80
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("NgayBoXung")
                    .HeaderText = "Ngày bổ xung"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("NgayCongVanBoXung")
                    .HeaderText = "Ngày c/văn bổ xung"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("NgayCongVanYeuCauBoXung")
                    .HeaderText = "Ngày c/văn y/c bổ xung"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("NoiDungBoXung")
                    .HeaderText = "Nội dung bổ xung"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("NoiDungYeuCauBoXung")
                    .HeaderText = "Nội dung y/c bổ xung"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("SoCongVanBoXung")
                    .HeaderText = "Số c/văn bổ xung"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("SoCongVanYeuCauBoXung")
                    .HeaderText = "Số c/văn y/c bổ xung"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("ThoiHanYeuCauBoXung")
                    .HeaderText = "T/hạn y/c bổ xung"
                    .Width = 120
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("YeuCauBoXungTuNgay")
                    .HeaderText = "Y/c bổ xung từ ngày"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With

                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Yêu cầu bổ xung " & vbNewLine & _
                   "Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Private Sub ctrlYeuCauBoXung_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            With Me
                With .dtpNgayBoXung
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                End With
                With .dtpNgayCongVanBoXung
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                End With
                'Trang thai cap nhat
                .TrangThaiCapNhat()
                'Trang thai chuc nang
                .TrangThaiChucNang(True, True)
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox("  " & vbNewLine & " Yêu cầu bổ xung " _
            & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            'If blnCapNhat Then
            .grdrwYeuCauBoXung.BackgroundColor = Color.White
            'Else
            '    .grdvwMucDich.BackgroundColor = Color.LightYellow
            'End If
            .chkHoanTatBoSung.Enabled = blnCapNhat

            .dtpNgayBoXung.Enabled = blnCapNhat
            .dtpNgayCongVanBoXung.Enabled = blnCapNhat
            .txtNoiDungBoXung.ReadOnly = Not blnCapNhat
            .txtSoCongVanBoXung.ReadOnly = Not blnCapNhat

            If blnCapNhat Then
                .txtNoiDungBoXung.BackColor = Color.White
                .txtSoCongVanBoXung.BackColor = Color.White
            Else
                .txtNoiDungBoXung.BackColor = Color.LightYellow
                .txtSoCongVanBoXung.BackColor = Color.LightYellow
            End If
        End With
    End Sub


    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            If (blnClearGrid) Then
                'Ẩn tất cả các cột trên Grid
                .HideAllColumns(grdrwYeuCauBoXung)
            End If
            'Thiết lập trên Form nhập liệu
            .chkHoanTatBoSung.Checked = False
            .dtpNgayBoXung.Value = Date.Now
            .dtpNgayBoXung.Checked = False
            .dtpNgayCongVanBoXung.Value = Date.Now
            .dtpNgayCongVanBoXung.Checked = False
            .txtNoiDungBoXung.Text = ""
            .txtSoCongVanBoXung.Text = ""
        End With
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

    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox1.Enabled = True
        Else
            Me.GroupBox1.Enabled = False

        End If
        'Khai bao va khoi tao doi tuong
        Dim ThongTinBoXung As New clsYeuCauBoSung
        'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
        Try
            With ThongTinBoXung
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                .HoanTatBoXung = ""
                .MaHoSoCapGCN = strMaHoSoCapGCN
                .MaYeuCauBoXung = ""
                .NgayBoXung = ""
                .NgayCongVanBoXung = ""
                .NgayCongVanYeuCauBoXung = ""
                .NoiDungBoXung = ""
                .NoiDungYeuCauBoXung = ""
                .SoCongVanBoXung = ""
                .SoCongVanYeuCauBoXung = ""
                .ThoiHanYeuCauBoXung = ""
                .YeuCauBoXungTuNgay = ""
            End With
            dtThongTinBoXung.Clear()
            With Me.grdrwYeuCauBoXung
                'Goi phuong thuc GetData de khoi tao doi tuong cls
                If ThongTinBoXung.SelectThongTinBoXung(dtThongTinBoXung) = "" Then
                    ' Trinh bay du lieu len grdvwMucDich
                    .DataSource = dtThongTinBoXung
                    If dtThongTinBoXung.Rows.Count > 0 Then
                        Me.FormatGridContruction()
                    Else
                        Me.HideAllColumns(grdrwYeuCauBoXung)
                    End If
                End If
            End With
            'Thiet dat trang thai ban dau
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Yêu cầu bổ xung " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub UpdateData()
        'Khai bao va khoi tao doi tuong clsYeuCauBoXung
        Dim YeuCauBoXung As New clsYeuCauBoSung
        Try
            'Xac nhan ban ghi can xoa
            'Khai báo biến nhận chuỗi kết nối Database
            YeuCauBoXung.Connection = strConnection
            YeuCauBoXung.MaHoSoCapGCN = strMaHoSoCapGCN
            YeuCauBoXung.MaYeuCauBoXung = strMaYeuCauBoXung

            If chkHoanTatBoSung.Checked = True Then
                YeuCauBoXung.HoanTatBoXung = "1"
            Else
                YeuCauBoXung.HoanTatBoXung = "0"
            End If

            If dtpNgayBoXung.Checked Then
                YeuCauBoXung.NgayBoXung = dtpNgayBoXung.Text
            Else
                YeuCauBoXung.NgayBoXung = Nothing
            End If
            If dtpNgayCongVanBoXung.Checked Then
                YeuCauBoXung.NgayCongVanBoXung = dtpNgayCongVanBoXung.Text
            Else
                YeuCauBoXung.NgayCongVanBoXung = Nothing
            End If


            If txtNoiDungBoXung.Text IsNot Nothing Then
                YeuCauBoXung.NoiDungBoXung = txtNoiDungBoXung.Text.Trim
            Else
                YeuCauBoXung.NoiDungBoXung = ""
            End If
            If (txtSoCongVanBoXung.Text IsNot Nothing) Then
                YeuCauBoXung.SoCongVanBoXung = txtSoCongVanBoXung.Text.Trim
            Else
                YeuCauBoXung.SoCongVanBoXung = ""
            End If

            Dim str As String = ""
            'Neu cap nhat thanh cong
            If shortAction = 1 Then
                YeuCauBoXung.InsertThongTinBoXung(str)
            ElseIf shortAction = 2 Then
                YeuCauBoXung.UpdateThongTinBoXung(str)
            End If
            strError = YeuCauBoXung.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Yêu cầu bổ xung " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        TrangThaiBanDau()
        shortAction = 0
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        strMaYeuCauBoXung = ""
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
        If strMaYeuCauBoXung <> "" Then
            shortAction = 2
            'Trang thai chuc nang
            TrangThaiChucNang(True)
            'Trang thai cap nhat
            TrangThaiCapNhat(True)
        Else
            MsgBox(" Bạn chưa chọn Yêu cầu cần sửa!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Neu ton tai ma can xoa
        If strMaYeuCauBoXung <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        Dim str As String = ""
                        Dim YeuCauBoXung As New clsYeuCauBoSung
                        YeuCauBoXung.DeleteThongTinBoXungByMaYeuCauBoXung(str)
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
            MsgBox(" Bạn chưa chọn Yêu cầu cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        strMaYeuCauBoXung = ""
        'Hien thi du lieu
        Me.ShowData()
        'Trang thai ban dau
        Me.TrangThaiBanDau()
        'Trang thai chuc nang
        Me.TrangThaiChucNang()
        'Trang thai cap nhat 
        Me.TrangThaiCapNhat()
        strError = ""
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        'Truong hop them moi mau tin
        Try
            With Me
                'Cập nhật thông tin yêu cầu bổ xung
                .UpdateData()
                'Hiển thị toàn bộ thông tin
                .ShowData()
                'Trang thai chuc nang
                .TrangThaiChucNang()
                'Trang thai cap nhat
                .TrangThaiCapNhat()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Yêu cầu bổ xung " & vbNewLine _
                & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        'Khoi tao gia tri cho bien dung chung
        strMaYeuCauBoXung = ""
        strError = ""
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hien thi du lieu
            If strMaYeuCauBoXung <> "" Then
                .ShowData()
            End If
            'Xoa du lieu tren Form
            .TrangThaiBanDau()
            'Khoi tao gia tri cho bien dung chung
            strMaYeuCauBoXung = ""
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat 
            .TrangThaiCapNhat()
        End With
        shortAction = 0
    End Sub

    Private Sub grdrwYeuCauBoXung_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles grdrwYeuCauBoXung.CellFormatting
        Try
            'With Me.grdrwYeuCauBoXung.Columns(e.ColumnIndex)
            '    If .Name = "NgayBoXung" Then
            '        If e.Value IsNot Nothing Then
            '            e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
            '        End If
            '    End If
            '    If .Name = "NgayCongVanBoXung" Then
            '        If e.Value IsNot Nothing Then
            '            e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
            '        End If
            '    End If
            '    If .Name = "NgayCongVanYeuCauBoXung" Then
            '        If e.Value IsNot Nothing Then
            '            e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
            '        End If
            '    End If
            '    If .Name = "YeuCauBoXungTuNgay" Then
            '        If e.Value IsNot Nothing Then
            '            e.Value = DateTime.Parse(e.Value).ToString("dd\/MM\/yyyy")
            '        End If
            '    End If
            'End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Định dạng ngày tháng " & vbNewLine & " Yêu cầu bổ xung " & vbNewLine _
       & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub grdrwYeuCauBoXung_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdrwYeuCauBoXung.CellMouseClick
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If
        'Khoi tao doi tuong 
        Dim YeuCauBoXung As New clsYeuCauBoSung
        If e.RowIndex >= 0 Then
            Try
                'Hien thi thong tin chu su dung
                With dtThongTinBoXung.Rows(e.RowIndex)
                    YeuCauBoXung.HoanTatBoXung = .Item("HoanTatBoXung").ToString
                    YeuCauBoXung.MaHoSoCapGCN = .Item("MaHoSoCapGCN").ToString
                    YeuCauBoXung.MaYeuCauBoXung = .Item("MaYeuCauBoXung").ToString
                    strMaYeuCauBoXung = YeuCauBoXung.MaYeuCauBoXung
                    YeuCauBoXung.NgayBoXung = .Item("NgayBoXung").ToString
                    YeuCauBoXung.NgayCongVanBoXung = .Item("NgayCongVanBoXung").ToString
                    YeuCauBoXung.NgayCongVanYeuCauBoXung = .Item("NgayCongVanYeuCauBoXung").ToString
                    YeuCauBoXung.NoiDungBoXung = .Item("NoiDungBoXung").ToString
                    YeuCauBoXung.NoiDungYeuCauBoXung = .Item("NoiDungYeuCauBoXung").ToString
                    YeuCauBoXung.SoCongVanBoXung = .Item("SoCongVanBoXung").ToString
                    YeuCauBoXung.SoCongVanYeuCauBoXung = .Item("SoCongVanYeuCauBoXung").ToString
                    YeuCauBoXung.ThoiHanYeuCauBoXung = .Item("ThoiHanYeuCauBoXung").ToString
                    YeuCauBoXung.YeuCauBoXungTuNgay = .Item("YeuCauBoXungTuNgay").ToString
                End With
                'Hien thi ban ghi tuong ung lenh Form
                With Me
                    'Hoan tat bo xung
                    If YeuCauBoXung.HoanTatBoXung = "True" Then
                        chkHoanTatBoSung.Checked = True
                    ElseIf YeuCauBoXung.HoanTatBoXung = "False" Then
                        chkHoanTatBoSung.Checked = False
                    Else
                        chkHoanTatBoSung.Checked = False
                    End If
                    If Not IsDate(YeuCauBoXung.NgayBoXung) Then
                        .dtpNgayBoXung.Value = Date.Now
                        .dtpNgayBoXung.Checked = False
                    Else
                        .dtpNgayBoXung.Value = YeuCauBoXung.NgayBoXung
                        .dtpNgayBoXung.Checked = True
                    End If
                    If Not IsDate(YeuCauBoXung.NgayCongVanBoXung) Then
                        .dtpNgayCongVanBoXung.Value = Date.Now
                        .dtpNgayCongVanBoXung.Checked = False
                    Else
                        .dtpNgayCongVanBoXung.Value = YeuCauBoXung.NgayCongVanBoXung
                        .dtpNgayCongVanBoXung.Checked = True
                    End If
                    .txtNoiDungBoXung.Text = YeuCauBoXung.NoiDungBoXung
                    .txtSoCongVanBoXung.Text = YeuCauBoXung.SoCongVanBoXung
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Yêu cầu bổ xung" _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub txtNoiDungBoXung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoiDungBoXung.KeyDown
        If (e.KeyValue = 13) Then
            txtSoCongVanBoXung.Focus()
        End If
    End Sub

    Private Sub txtSoCongVanBoXung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoCongVanBoXung.KeyDown
        If (e.KeyValue = 13) Then
            dtpNgayCongVanBoXung.Focus()
        End If
    End Sub

    Private Sub dtpNgayCongVanBoXung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpNgayCongVanBoXung.KeyDown
        If (e.KeyValue = 13) Then
            dtpNgayBoXung.Focus()
        End If
    End Sub

    Private Sub dtpNgayBoXung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpNgayBoXung.KeyDown
        If (e.KeyValue = 13) Then
            chkHoanTatBoSung.Focus()
        End If
    End Sub

    Private Sub chkHoanTatBoSung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkHoanTatBoSung.KeyDown
        If (e.KeyValue = 13) Then
            btnCapNhat.Focus()
        End If 
    End Sub
End Class
