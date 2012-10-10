Public Class ctrPhanQuyenQuyTrinhChucNang
    Private strConnection As String
    Private strMaUser As String

    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public Property MaUser() As String
        Get
            Return strMaUser
        End Get
        Set(ByVal value As String)
            strMaUser = value
        End Set
    End Property
    Private Sub ctrPhanQuyenQuyTrinhChucNang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me
            With .dtpNgayCapNhat
                .CustomFormat = "dd/MM/yyyy"
                .Format = DateTimePickerFormat.Custom
                .ShowCheckBox = True
            End With
        End With
    End Sub

    Public Sub ShowData(ByVal strMaNguoiDung As String)
        Dim cls As New clsPhanQuyenQuyTrinhChucNang
        Dim dt As New DataTable
        With cls
            .MaUser = strMaNguoiDung
            .Connection = strConnection
            dt = .SelectChucNangByMaUser()
        End With
        If dt.Rows.Count > 0 Then
            grdChucNang.DataSource = dt
            FormatGridChucNang()
        End If
    End Sub
    Public Sub FormatGridChucNang()
        With grdChucNang
            .Columns("MaUser").Visible = False
            .Columns("MaChucNang").Visible = False
            .Columns("TenChucNang").HeaderText = "Chức năng"
            .Columns("ChucNangCha").HeaderText = "Thuộc chức năng"
            .Columns("CapNhat").HeaderText = "Thao tác"
        End With
    End Sub
    Public Sub ShowDanhSachNguoiDung()
        Dim cls As New clsPhanQuyenQuyTrinhChucNang
        Dim dt As New DataTable
        With cls 
            .Connection = strConnection
            dt = .SelectMaUser()
        End With
        If dt.Rows.Count > 0 Then
            grdNguoiDung.DataSource = dt
            FormatGridNguoiDung()
        End If
    End Sub

    Public Sub FormatGridNguoiDung()
        With grdNguoiDung
            .Columns("MaUsers").Visible = False
            .Columns("TenDangNhap").HeaderText = "Tên đăng nhập"
            .Columns("TenDayDu").HeaderText = "Họ tên"
            .Columns("ChucVu").HeaderText = "Chức vụ"
            .Columns("PhongBan").HeaderText = "Phòng ban"
        End With
    End Sub


    Private Sub grdNguoiDung_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdNguoiDung.CellMouseDoubleClick
        If e.RowIndex >= 0 Then
            ShowData(grdNguoiDung.Rows(e.RowIndex).Cells("MaUsers").Value.ToString)
            grdNguoiDung.Enabled = False
        End If
    End Sub
    Private Sub checkColumn(ByRef grdvw As DataGridView, ByVal intRowIndex As Int32, ByVal intColumnIndex As Int32)
        If (intRowIndex) < 0 Then
            Exit Sub
        End If
        If intColumnIndex >= 0 Then
            If grdvw.Columns(intColumnIndex).Name.ToUpper() = "CapNhat".ToUpper Then
                If (grdvw.Rows(intRowIndex).Cells("CapNhat").Value.ToString = "") Then
                    grdvw.Rows(intRowIndex).Cells("CapNhat").Value = "True"
                Else
                    If (grdvw.Rows(intRowIndex).Cells("CapNhat").Value = True) Then
                        grdvw.Rows(intRowIndex).Cells("CapNhat").Value = "False"
                    Else
                        grdvw.Rows(intRowIndex).Cells("CapNhat").Value = "True"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdChucNang_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdChucNang.CellMouseClick
        'Khong cho chon chuot phai
        If e.Button.ToString = "Right" Then
            Exit Sub
        End If

        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Me.checkColumn(grdChucNang, e.RowIndex, e.ColumnIndex)
        End If
    End Sub
 
    Private Sub cmdCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCapNhat.Click
        Dim cls As New clsPhanQuyenQuyTrinhChucNang
        With cls
            .Connection = strConnection
            .MaUser = grdNguoiDung.CurrentRow.Cells("Mausers").Value.ToString
            For i As Integer = 0 To grdChucNang.Rows.Count - 1
                .MaChucNang = grdChucNang.Rows(i).Cells("MaChucNang").Value
                .CapNhat = grdChucNang.Rows(i).Cells("CapNhat").Value
                .insChucNang()
            Next
            MessageBox.Show("Hoàn thành cập nhật", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Question)
        End With
    End Sub

    Private Sub dmcXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dmcXoa.Click
        Dim cls As New clsPhanQuyenQuyTrinhChucNang
        With cls
            .Connection = strConnection
            .MaUser = grdNguoiDung.CurrentRow.Cells("Mausers").Value
            .DelChucNang()
        End With
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        FindForm.Close()
    End Sub

    Private Sub chkCheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheckAll.CheckedChanged
        If chkCheckAll.Checked Then
            For i As Integer = 0 To grdChucNang.RowCount - 1
                grdChucNang.Rows(i).Cells("capnhat").Value = True
            Next
        Else
            For i As Integer = 0 To grdChucNang.RowCount - 1
                grdChucNang.Rows(i).Cells("capnhat").Value = False
            Next
        End If
    End Sub

    Private Sub cmdHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHuyLenh.Click
        grdNguoiDung.Enabled = True
    End Sub
End Class
