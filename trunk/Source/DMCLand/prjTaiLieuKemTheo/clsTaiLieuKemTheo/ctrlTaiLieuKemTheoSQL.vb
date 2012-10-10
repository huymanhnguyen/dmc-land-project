Imports System.IO
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing
Public Class ctrlTaiLieuKemTheoSQL
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai bao bien kiem tra loi
    Private strError As String = ""
    'Dim DS As New DataSet
    Dim dtTaiLieuKemTheo As DataTable
    Dim strMaHoSoCapGCN As String = ""
    Dim strMaTaiLieuKemTheo As String = ""
    Private shtFlag As Short = 0
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public Property Flag() As String
        Set(ByVal value As String)
            shtFlag = value
        End Set
        Get
            Return shtFlag
        End Get
    End Property
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property MaTaiLieuKemTheo() As String
        Get
            Return strMaTaiLieuKemTheo
        End Get
        Set(ByVal value As String)
            strMaTaiLieuKemTheo = value
        End Set
    End Property
    'Public Sub AddColumnsTaiLieuKemTheo()
    '    Dim txtClnMoTa As New DataGridViewTextBoxColumn
    '    Dim txtClnTenTepDuLieuNguon As New DataGridViewTextBoxColumn
    '    Try
    '        '
    '        With txtClnMoTa
    '            .HeaderText = "Mô tả tài liệu"
    '            .Name = "MoTa"
    '            .Width = 300
    '        End With
    '        With txtClnTenTepDuLieuNguon
    '            .HeaderText = "Tên tệp dữ liệu nguồn"
    '            .Name = "TenTepDuLieuNguon"
    '            .Width = 400
    '        End With
    '        'Add all to DataGridView Co quan nha nuoc
    '        With grdvwTaiLieuKemTheo
    '            .BackgroundColor = Color.WhiteSmoke
    '            .GridColor = Color.WhiteSmoke
    '            .RowHeadersVisible = False
    '            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            'Add Columns to Grid
    '            With .Columns
    '                .Add(txtClnMoTa)
    '                .Add(txtClnTenTepDuLieuNguon)
    '            End With
    '            'Khong cho phep them
    '            .AllowUserToAddRows = False
    '            'Khong cho phep xoa
    '            .AllowUserToDeleteRows = False
    '            'Khong lua chon bat ky dong nao luc ban dau
    '            .ClearSelection()
    '        End With
    '    Catch ex As Exception
    '        'strError = ex.Message
    '        MsgBox(" Tài liệu kèm theo " & vbNewLine & _
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
            'Ẩn tất cả các cột
            Me.HideAllColumns(grdvwTaiLieuKemTheo)
            With Me.grdvwTaiLieuKemTheo
                With .Columns("MoTa")
                    .HeaderText = "Mô tả tài liệu"
                    .Width = 300
                    .Visible = True
                End With
                With .Columns("TenTepDuLieuNguon")
                    .HeaderText = "Tên tệp dữ liệu nguồn"
                    .Width = 400
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

    Private Sub UpdateData()
        strError = ""
        Try
            'Khai bao bien doc tep vao mang byte
            Dim byteData As Byte() = Nothing
            'Khai bao bien cau lenh truy van
            Dim strQuery As String = ""
            'Set insert query
            If shtFlag = 1 Then
                strQuery = "insert into tblTaiLieuKemTheo (MaHoSoCapGCN, MoTa, TenTepDuLieuNguon,TaiLieu) values(@MaHoSoCapGCN,@MoTa,@TenTepDuLieuNguon, @TaiLieu)"
                'Read data Bytes into a byte array with new record addition case
                byteData = ReadFile(txtTenTepDuLieuNguon.Text)
            ElseIf shtFlag = 2 Then
                strQuery = "Update tblTaiLieuKemTheo Set MoTa = @MoTa where MaTaiLieuKemTheo = '" + strMaTaiLieuKemTheo + "'"
            ElseIf shtFlag = 3 Then
                strQuery = "Delete tblTaiLieuKemTheo where MaTaiLieuKemTheo = '" + strMaTaiLieuKemTheo + "'"
            Else
                Exit Sub
            End If
            'Initialize SQL Server Connection
            'Khai báo và gán chuỗi kết nối Database
            Dim sqlCon As New SqlConnection(strConnection)
            'Initialize SqlCommand object for insert.
            Dim SqlCom As SqlCommand = New SqlCommand(strQuery, sqlCon)
            'We are passing Original Image Path and Image byte data as sql parameters.
            'Trường hợp thêm mới và sửa 
            SqlCom.Parameters.Add(New SqlParameter("@MoTa", Me.txtMoTa.Text.Trim))
            'Trường hợp thêm mới
            If shtFlag = 1 Then
                SqlCom.Parameters.Add(New SqlParameter("@MaHoSoCapGCN", strMaHoSoCapGCN))
                SqlCom.Parameters.Add(New SqlParameter("@TenTepDuLieuNguon", Me.txtTenTepDuLieuNguon.Text.Trim))
                SqlCom.Parameters.Add(New SqlParameter("@TaiLieu", byteData))
            End If
            'Open connection and execute insert query.
            If sqlCon.State = ConnectionState.Closed Then
                sqlCon.Open()
            End If
            SqlCom.ExecuteNonQuery()
            sqlCon.Close()
            'Close form and return to list or images.
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Lỗi tải dữ liệu lên Server! " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Try
            With Me
                'Cap nhat thong tin
                .UpdateData()
                'Trang thai chuc nang
                .TrangThaiChucNang()
                'Trang thai cap nhat
                .TrangThaiCapNhat()
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
    Private Function ReadFile(ByVal strPath As String) As Byte()
        'Initialize byte array with a null value initially.
        Dim byteData As Byte()
        'Use FileInfo object to get file size.
        Dim fInfo As New FileInfo(strPath)
        Dim numBytes As Long
        numBytes = fInfo.Length
        'Open file stream de doc file
        Dim fStream As FileStream
        fStream = New FileStream(strPath, FileMode.Open, FileAccess.Read)
        'Use BinaryReader to read file stream into byte array.
        Dim br As New BinaryReader(fStream)
        'When you use BinaryReader, you need to supply number of bytes to read from file.
        'In this case we want to read entire file. So supplying total number of bytes.
        byteData = br.ReadBytes(CInt(numBytes))
        Return byteData
    End Function

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        'Thiet dat Co cap nhat
        shtFlag = 1
        'Thiet dat cac gia tri ve trang thai khoi tao
        strMaTaiLieuKemTheo = ""
        With Me
            'Thiet lap trang thai ban dau
            .TrangThaiBanDau()
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            'Trang thai chuc nang 
            .TrangThaiChucNang(True)
        End With
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
                txtTenTepDuLieuNguon.Text = .FileName
            End If
        End With
    End Sub

    Public Sub ShowData()
        Try
            Dim dsTaiLieuKemTheo As New DataSet
            dsTaiLieuKemTheo = GetData()
            dtTaiLieuKemTheo = dsTaiLieuKemTheo.Tables("tblTaiLieuKemTheo")
            ''Fill Grid with dataset.
            'Dim intSoBanGhi As Integer
            'intSoBanGhi = dsTaiLieuKemTheo.Tables("tblTaiLieuKemTheo").Rows.Count
            'Me.grdvwTaiLieuKemTheo.RowCount = intSoBanGhi
            'For i As Integer = 0 To intSoBanGhi - 1
            '    Me.grdvwTaiLieuKemTheo.Item(0, i).Value = dsTaiLieuKemTheo.Tables("tblTaiLieuKemTheo").Rows(i).Item("MoTa").ToString
            '    Me.grdvwTaiLieuKemTheo.Item(1, i).Value = dsTaiLieuKemTheo.Tables("tblTaiLieuKemTheo").Rows(i).Item("TenTepDuLieuNguon").ToString
            'Next
            'Me.grdvwTaiLieuKemTheo.ClearSelection()

            'Hiển thị dữ liệu
            Me.grdvwTaiLieuKemTheo.DataSource = dtTaiLieuKemTheo
            If (dtTaiLieuKemTheo.Rows.Count > 0) Then
                'Định dạng lại cột trên Grid
                Me.FormatGridContruction()
            Else
                Me.HideAllColumns(grdvwTaiLieuKemTheo)
            End If

        Catch ex As Exception
            strError = ex.Message
            MsgBox(ex.Message)
        End Try
        'Thiết đặt cờ về giá trị ban đầu
        shtFlag = 0
    End Sub
    Private Function GetData() As DataSet
        'Initialize Dataset.
        Dim dsTaiLieuKemTheo As New DataSet
        If strMaHoSoCapGCN = "" Then
            Return Nothing
            Exit Function
        Else
            Try
                'Initialize SQL Server connection.
                'Khai báo và nhận chuỗi kết nối Database
                Dim sqlCon As New SqlConnection(strConnection)
                Dim strQuery As String = ""
                If (strMaTaiLieuKemTheo <> "") And (shtFlag = 0) Then
                    strQuery = "Select MaTaiLieuKemTheo, MoTa, TenTepDuLieuNguon, TaiLieu from tblTaiLieuKemTheo where MaTaiLieuKemTheo = '" + strMaTaiLieuKemTheo + "'"
                Else
                    strQuery = "Select MaTaiLieuKemTheo, MoTa, TenTepDuLieuNguon from tblTaiLieuKemTheo where MaHoSoCapGCN = '" + strMaHoSoCapGCN + "'"
                End If
                'Initialize SQL adapter.
                Dim sqlAdap As SqlDataAdapter = New SqlDataAdapter(strQuery, sqlCon)
                'Fill dataset with ImagesStore table.
                sqlAdap.Fill(dsTaiLieuKemTheo, "tblTaiLieuKemTheo")
            Catch ex As Exception
                strError = ex.Message
                MsgBox(" Tài liệu kèm theo " + vbNewLine + " Lỗi trong thủ tục GetData: " _
                + vbNewLine + strError, MsgBoxStyle.Critical, "DMCLand")
            End Try
        End If
        Return dsTaiLieuKemTheo
    End Function

    Private Sub btnTaiVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaiVe.Click
        'Thiet dat Co ve gia tri ban dau
        shtFlag = 0
        If strMaTaiLieuKemTheo = "" Then
            MsgBox("Bạn phải chọn một tài liệu cần tải về!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        Else
            Dim dlgSaveFile As New SaveFileDialog
            Dim strSaveFileName As String = ""
            'streamwriter is used to write text
            Try
                With dlgSaveFile
                    .Title = "Tai du lieu ve may"
                    .FileName = strSaveFileName
                    .Filter = "Bitmap Image (*.bmp)|*.bmp|" _
                    & "JPG Image (*.JPG)|*.JPG|" _
                    & "Word 97-2003 (*.doc)|*.doc|" & "Word 2007 (*.docx)|*.docx|" _
                    & "Excel 97-2003 (*.xls)|*.xls|" & "Excel 2007 (*.xlsx)|*.xlsx|" _
                    & "PDF (*.pdf)|*.pdf|" _
                    & "All files (*.*)|*.*"
                    If .ShowDialog() = DialogResult.OK Then
                        strSaveFileName = .FileName
                        'Khai bao bien kieu Dataset nhan du lieu
                        Dim dsTaiLieuKemTheo As New DataSet
                        dsTaiLieuKemTheo = GetData()
                        If dsTaiLieuKemTheo.Tables("tblTaiLieuKemTheo").Rows.Count <= 0 Then
                            Exit Sub
                        Else
                            SaveFile(strSaveFileName, dsTaiLieuKemTheo.Tables("tblTaiLieuKemTheo").Rows(0).Item("TaiLieu"))
                        End If
                        MsgBox("Dữ liệu đã tải về thành công!", MsgBoxStyle.Information, "DMCLand")
                    End If
                End With
            Catch ex As Exception
                MsgBox(" Lỗi ghi dữ liệu: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "DMCLand")
            End Try
        End If
    End Sub

    Public Function SaveFile(ByVal strSaveFileName As String, ByVal byteContent As Byte()) As Boolean
        Dim objFstream As FileStream = Nothing
        Try
            objFstream = File.Open(strSaveFileName, FileMode.Create, FileAccess.Write)
            Dim lngLen As Long = byteContent.Length
            objFstream.Write(byteContent, 0, CInt(lngLen))
            objFstream.Flush()
            Return True
        Catch ex As Exception
            MsgBox(" Lỗi ghi dữ liệu: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
            Return False
        Finally
            objFstream.Close()
        End Try
    End Function
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

    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            'Ẩn tất cả các cột trên Grid
            .HideAllColumns(grdvwTaiLieuKemTheo)
            'Thiet lap tren Form nhap lieu
            .txtMoTa.Text = ""
            .txtTenTepDuLieuNguon.Text = ""
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            .btnSua.Enabled = Not blnStartEdited
            .btnXoa.Enabled = Not blnStartEdited
            .btnThem.Enabled = Not blnStartEdited
            .btnCapNhat.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnCapNhat.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
            End If
        End With
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        'Dat Co ve gia tri ban dau
        shtFlag = 4
        With Me
            'Hien thi du lieu
            If strMaTaiLieuKemTheo <> "" Then
                .ShowData()
            End If
            'Xoa du lieu tren Form
            .TrangThaiBanDau()
            'Khoi tao gia tri cho bien dung chung
            strMaTaiLieuKemTheo = ""
            'Trang thai chuc nang
            .TrangThaiChucNang()
            'Trang thai cap nhat 
            .TrangThaiCapNhat()
        End With
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaTaiLieuKemTheo <> "" Then
            'Dat Co sua
            shtFlag = 2
            'Trang thai chuc nang
            TrangThaiChucNang(True)
            'Trang thai cap nhat
            TrangThaiCapNhat(True)
        Else
            MsgBox(" Bạn chưa chọn Tai lieu can sua!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        'Dat co Xoa
        shtFlag = 3
        'Neu ton tai ma can xoa
        If strMaTaiLieuKemTheo <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        '.Flag = 3
                        .UpdateData()
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
                'Trang thai cap nhat
                .TrangThaiCapNhat()
                'Trang thai chuc nang
                .TrangThaiChucNang(True, True)
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
        'Khoi tao doi tuong 
        'Dim cls As New DMC.Land.HoSoKeKhai.clsTaiLieuKemTheo 
        If e.RowIndex >= 0 Then
            Try
                'Hien thi thong tib
                With dtTaiLieuKemTheo.Rows(e.RowIndex)
                    strMaTaiLieuKemTheo = .Item("MaTaiLieuKemTheo").ToString
                    'Hien thi ban ghi tuong ung lenh Form
                    Me.txtMoTa.Text = .Item("MoTa").ToString
                    Me.txtTenTepDuLieuNguon.Text = .Item("TenTepDuLieuNguon").ToString
                End With
            Catch ex As Exception
                'strError = ex.Message
                MsgBox(" Hiển thị dữ liệu lên Form " & vbNewLine & " Yêu cầu bổ xung" _
                       & vbNewLine & " Lỗi: " & ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
        End If
    End Sub
End Class
