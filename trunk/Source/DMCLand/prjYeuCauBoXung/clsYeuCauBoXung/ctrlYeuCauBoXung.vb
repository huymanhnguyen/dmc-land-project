Option Explicit On
Imports System.Windows.Forms
Imports System.Drawing

Public Class ctrlYeuCauBoXung
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    Private strError As String = "" 'Khai bao bien kiem tra loi
    Private strMaHoSoCapGCN As String = ""
    Private dtYeuCauBoXung As New DataTable
    Private strMaYeuCauBoXung As String = ""
    Private shortAction As Short = 0
    'Khai báo biến nhận chuỗi kết nối Database
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
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Public Sub AddColumnsYeuCauBoXung()
    '    Dim txtClnSoCongVanYeuCauBoXung As New DataGridViewTextBoxColumn
    '    Dim txtClnNgayCongVanYeuCauBoXung As New DataGridViewTextBoxColumn
    '    Dim txtClnNoiDungYeuCauBoXung As New DataGridViewTextBoxColumn
    '    Dim txtClnThoiHanYeuCauBoXung As New DataGridViewTextBoxColumn
    '    Dim txtClnYeuCauBoXungTuNgay As New DataGridViewTextBoxColumn
    '    Dim txtClnSoCongVanBoXung As New DataGridViewTextBoxColumn
    '    Dim txtClnNgayCongVanBoXung As New DataGridViewTextBoxColumn
    '    Dim txtClnNoiDungBoXung As New DataGridViewTextBoxColumn
    '    Dim txtClnNgayBoXung As New DataGridViewTextBoxColumn
    '    Dim chkClnHoanTatBoXung As New DataGridViewCheckBoxColumn
    '    Try
    '        '
    '        With chkClnHoanTatBoXung
    '            .HeaderText = "Hoàn tất"
    '            .Name = "HoanTatBoXung"
    '            .Width = 80
    '        End With
    '        With txtClnNgayBoXung
    '            .HeaderText = "Ngày bổ xung"
    '            .Name = "NgayBoXung"
    '            .Width = 120
    '        End With
    '        With txtClnNgayCongVanBoXung
    '            .HeaderText = "Ngày c/văn bổ xung"
    '            .Name = "NgayCongVanBoXung"
    '            .Width = 150
    '        End With
    '        With txtClnNgayCongVanYeuCauBoXung
    '            .HeaderText = "Ngày c/văn y/c bổ xung"
    '            .Name = "NgayCongVanYeuCauBoXung"
    '            .Width = 150
    '        End With
    '        With txtClnNoiDungBoXung
    '            .HeaderText = "Nội dung bổ xung"
    '            .Name = "NoiDungBoXung"
    '            .Width = 150
    '        End With
    '        With txtClnNoiDungYeuCauBoXung
    '            .HeaderText = "Nội dung y/c bổ xung"
    '            .Name = "NoiDungYeuCauBoXung"
    '            .Width = 150
    '        End With
    '        With txtClnSoCongVanBoXung
    '            .HeaderText = "Số c/văn bổ xung"
    '            .Name = "SoCongVanBoXung"
    '            .Width = 120
    '        End With
    '        With txtClnSoCongVanYeuCauBoXung
    '            .HeaderText = "Số c/văn y/c bổ xung"
    '            .Name = "SoCongVanYeuCauBoXung"
    '            .Width = 150
    '        End With
    '        With txtClnThoiHanYeuCauBoXung
    '            .HeaderText = "T/hạn y/c bổ xung"
    '            .Name = "ThoiHanYeuCauBoXung"
    '            .Width = 120
    '        End With
    '        With txtClnYeuCauBoXungTuNgay
    '            .HeaderText = "Y/c bổ xung từ ngày"
    '            .Name = "YeuCauBoXungTuNgay"
    '            .Width = 150
    '        End With

    '        'Add all to DataGridView Co quan nha nuoc
    '        With grdrwYeuCauBoXung
    '            .AllowUserToAddRows = False
    '            .AllowUserToDeleteRows = False
    '            .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
    '            .RowHeadersVisible = False
    '            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            'Add Columns to Grid
    '            With .Columns
    '                .Add(chkClnHoanTatBoXung)
    '                .Add(txtClnNoiDungYeuCauBoXung)
    '                .Add(txtClnNoiDungBoXung)
    '                .Add(txtClnSoCongVanYeuCauBoXung)
    '                .Add(txtClnNgayCongVanYeuCauBoXung)
    '                .Add(txtClnThoiHanYeuCauBoXung)
    '                .Add(txtClnYeuCauBoXungTuNgay)
    '                .Add(txtClnSoCongVanBoXung)
    '                .Add(txtClnNgayCongVanBoXung)
    '                .Add(txtClnNgayBoXung)
    '            End With
    '        End With
    '    Catch ex As Exception
    '        strError = ex.Message
    '        MsgBox(" Yêu cầu bổ xung " & vbNewLine & _
    '               "Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
    '    End Try
    'End Sub

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
                With .DTPNgayCongVanYeuCauBoXung
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                End With
                With .dtpYeuCauBoXungTuNgay
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

            .dtpNgayBoXung.Enabled = blnCapNhat
            .dtpNgayCongVanBoXung.Enabled = blnCapNhat
            .DTPNgayCongVanYeuCauBoXung.Enabled = blnCapNhat
            .dtpYeuCauBoXungTuNgay.Enabled = blnCapNhat

            .numThoiHanYeuCauBoXung.Enabled = blnCapNhat

            .txtNoiDungBoXung.ReadOnly = Not blnCapNhat
            .txtNoiDungYeuCauBoXung.ReadOnly = Not blnCapNhat
            .txtSoCongVanBoXung.ReadOnly = Not blnCapNhat
            .txtSoCongVanYeuCauBoXung.ReadOnly = Not blnCapNhat

            If blnCapNhat Then
                .txtNoiDungBoXung.BackColor = Color.White
                .txtNoiDungYeuCauBoXung.BackColor = Color.White
                .txtSoCongVanBoXung.BackColor = Color.White
                .txtSoCongVanYeuCauBoXung.BackColor = Color.White
            Else
                .txtNoiDungBoXung.BackColor = Color.LightYellow
                .txtNoiDungYeuCauBoXung.BackColor = Color.LightYellow
                .txtSoCongVanBoXung.BackColor = Color.LightYellow
                .txtSoCongVanYeuCauBoXung.BackColor = Color.LightYellow
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

            .dtpNgayBoXung.Checked = False
            .dtpNgayBoXung.Value = Date.Now

            .dtpNgayCongVanBoXung.Checked = False
            .dtpNgayCongVanBoXung.Value = Date.Now

            .DTPNgayCongVanYeuCauBoXung.Checked = False
            .DTPNgayCongVanYeuCauBoXung.Value = Date.Now

            .dtpYeuCauBoXungTuNgay.Checked = False
            .dtpYeuCauBoXungTuNgay.Value = Date.Now

            .numThoiHanYeuCauBoXung.Value = 0

            .txtNoiDungBoXung.Text = ""
            .txtNoiDungYeuCauBoXung.Text = ""
            .txtSoCongVanBoXung.Text = ""
            .txtSoCongVanYeuCauBoXung.Text = ""

        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            If Me.MaLoaiBienDong <> "MG" Then
                Me.GroupBox3.Enabled = True

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
                Me.GroupBox3.Enabled = False
            End If

        End With
    End Sub

    Public Sub ShowData()
        If Me.MaLoaiBienDong <> "MG" Then
            Me.GroupBox3.Enabled = True
        Else
            Me.GroupBox3.Enabled = False
        End If
        'Khai bao va khoi tao doi tuong
        Dim YeuCauBoXung As New clsYeuCauBoSung
        'Gan gia tri cho cac thuoc tinh doi voi truong hop truy van
        Try
            With YeuCauBoXung
                'Nhận chuỗi kết nối Database
                .Connection = strConnection
                '.HoanTatBoXung = ""
                .MaHoSoCapGCN = strMaHoSoCapGCN
                '.MaYeuCauBoXung = ""
                '.NgayBoXung = ""
                '.NgayCongVanBoXung = ""
                '.NgayCongVanYeuCauBoXung = ""
                '.NoiDungBoXung = ""
                '.NoiDungYeuCauBoXung = ""
                '.SoCongVanBoXung = ""
                '.SoCongVanYeuCauBoXung = ""
                '.ThoiHanYeuCauBoXung = ""
                '.YeuCauBoXungTuNgay = ""
            End With
            dtYeuCauBoXung.Clear()
            With Me.grdrwYeuCauBoXung
                'Goi phuong thuc GetData de khoi tao doi tuong cls
                If YeuCauBoXung.SelectYeuCauBoXung(dtYeuCauBoXung) = "" Then
                    ' Trinh bay du lieu len grdvwMucDich
                    .DataSource = dtYeuCauBoXung
                    If dtYeuCauBoXung.Rows.Count > 0 Then
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
            If DTPNgayCongVanYeuCauBoXung.Checked Then
                YeuCauBoXung.NgayCongVanYeuCauBoXung = DTPNgayCongVanYeuCauBoXung.Text
            Else
                YeuCauBoXung.NgayCongVanYeuCauBoXung = Nothing
            End If
            If dtpYeuCauBoXungTuNgay.Checked Then
                YeuCauBoXung.YeuCauBoXungTuNgay = dtpYeuCauBoXungTuNgay.Text
            Else
                YeuCauBoXung.YeuCauBoXungTuNgay = Nothing
            End If

            If IsNumeric(numThoiHanYeuCauBoXung.Text.Trim) Then
                YeuCauBoXung.ThoiHanYeuCauBoXung = numThoiHanYeuCauBoXung.Value
            Else
                YeuCauBoXung.ThoiHanYeuCauBoXung = Nothing
            End If

            If txtNoiDungBoXung.Text IsNot Nothing Then
                YeuCauBoXung.NoiDungBoXung = txtNoiDungBoXung.Text.Trim
            Else
                YeuCauBoXung.NoiDungBoXung = ""
            End If
            If txtNoiDungYeuCauBoXung.Text IsNot Nothing Then
                YeuCauBoXung.NoiDungYeuCauBoXung = txtNoiDungYeuCauBoXung.Text.Trim
            Else
                If (shortAction = 1) Or (shortAction = 2) Then
                    MsgBox("Bạn phải nhập nội dung yêu cầu bổ xung", MsgBoxStyle.Information, "DMCLand")
                    Exit Sub
                Else
                    YeuCauBoXung.NoiDungYeuCauBoXung = ""
                End If
            End If
            If (txtSoCongVanBoXung.Text IsNot Nothing) Then
                YeuCauBoXung.SoCongVanBoXung = txtSoCongVanBoXung.Text.Trim
            Else
                YeuCauBoXung.SoCongVanBoXung = ""
            End If
            If (txtSoCongVanYeuCauBoXung.Text IsNot Nothing) Then
                YeuCauBoXung.SoCongVanYeuCauBoXung = txtSoCongVanYeuCauBoXung.Text.Trim
            Else
                YeuCauBoXung.SoCongVanYeuCauBoXung = ""
            End If

            Dim str As String = ""
            'Neu cap nhat thanh cong
            If shortAction = 1 Then
                YeuCauBoXung.InsertYeuCauBoXung(str)
            ElseIf shortAction = 2 Then
                YeuCauBoXung.UpdateYeuCauBoXung(str)
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
                        YeuCauBoXung.DeleteYeuCauBoXungByMaYeuCauBoXung(str)
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
                With dtYeuCauBoXung.Rows(e.RowIndex)
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
                    If Not IsDate(YeuCauBoXung.NgayCongVanYeuCauBoXung) Then
                        .DTPNgayCongVanYeuCauBoXung.Value = Date.Now
                        .DTPNgayCongVanYeuCauBoXung.Checked = False
                    Else
                        .DTPNgayCongVanYeuCauBoXung.Value = YeuCauBoXung.NgayCongVanYeuCauBoXung
                        .DTPNgayCongVanYeuCauBoXung.Checked = True
                    End If
                    If Not IsDate(YeuCauBoXung.YeuCauBoXungTuNgay) Then
                        .dtpYeuCauBoXungTuNgay.Value = Date.Now
                        .dtpYeuCauBoXungTuNgay.Checked = False
                    Else
                        .dtpYeuCauBoXungTuNgay.Value = YeuCauBoXung.YeuCauBoXungTuNgay
                        .dtpYeuCauBoXungTuNgay.Checked = True
                    End If
                    If IsNumeric(YeuCauBoXung.ThoiHanYeuCauBoXung) Then
                        .numThoiHanYeuCauBoXung.Text = YeuCauBoXung.ThoiHanYeuCauBoXung
                    Else
                        .numThoiHanYeuCauBoXung.Text = ""
                    End If
                    .txtNoiDungBoXung.Text = YeuCauBoXung.NoiDungBoXung
                    .txtNoiDungYeuCauBoXung.Text = YeuCauBoXung.NoiDungYeuCauBoXung
                    .txtSoCongVanBoXung.Text = YeuCauBoXung.SoCongVanBoXung
                    .txtSoCongVanYeuCauBoXung.Text = YeuCauBoXung.SoCongVanYeuCauBoXung
                End With
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Yêu cầu bổ xung" _
                       & vbNewLine & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub

    Private Sub txtNoiDungYeuCauBoXung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoiDungYeuCauBoXung.KeyDown
        If (e.KeyValue = 13) Then
            txtSoCongVanYeuCauBoXung.Focus()
        End If
    End Sub

    Private Sub txtSoCongVanYeuCauBoXung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoCongVanYeuCauBoXung.KeyDown
        If (e.KeyValue = 13) Then
            DTPNgayCongVanYeuCauBoXung.Focus()
        End If
    End Sub

    Private Sub DTPNgayCongVanYeuCauBoXung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPNgayCongVanYeuCauBoXung.KeyDown
        If (e.KeyValue = 13) Then
            numThoiHanYeuCauBoXung.Focus()
        End If
    End Sub

    Private Sub numThoiHanYeuCauBoXung_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numThoiHanYeuCauBoXung.KeyDown
        If (e.KeyValue = 13) Then
            dtpYeuCauBoXungTuNgay.Focus()
        End If
    End Sub

    Private Sub dtpYeuCauBoXungTuNgay_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpYeuCauBoXungTuNgay.KeyDown
        If (e.KeyValue = 13) Then
            txtNoiDungBoXung.Focus()
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
            btnCapNhat.Focus()
        End If
    End Sub
End Class
