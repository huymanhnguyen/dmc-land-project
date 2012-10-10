Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text

Public Class ctrlTraCuu
    'Khai báo biến nhận chuỗi kết nối cơ sở dữ liệu
    Private strConnection As String = ""
    'Khai báo biến nhận thông báo lỗi
    Private strError As String = ""
    'Khai báo biến nhận Nhóm đối tượng cần tra cứu
    'GDCN: Gia đình, cá nhân
    'TCDN: Tổ chức doanh nghiệp
    'CQNN: Cơ quan nhà nước
    Private strNhom As String = ""

    'Khai báo thuộc tính nhận Nhóm đối tượng Chủ cần tra cứu
    Public Property Nhom() As String
        Get
            Return strNhom
        End Get
        Set(ByVal value As String)
            strNhom = value
        End Set
    End Property
    'Danh sách Chủ được lựa chọn đề nghị cấp GCN
    Dim dtSelected As New DataTable
    'Khai báo thuộc tính nhận Danh sách Chủ được lựa chọn
    Public Property Selected() As DataTable
        Get
            Return dtSelected
        End Get
        Set(ByVal value As DataTable)
            dtSelected = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kế nối cơ sở dữ liệu
    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

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
    ''' <summary>
    ''' Định dạng dữ liệu hiển thị trên Grid
    ''' </summary>
    ''' <param name="grdvw">Tên Grid cần định dạng</param>
    ''' <remarks></remarks>
    Private Sub FormatGridContruction(ByVal grdvw As DataGridView)
        Try
            'Ẩn tất cả các cột
            Me.HideAllColumns(grdvw)
            'Chỉ hiển thị những Cột cần thiết
            With grdvw
                'Kiểm tra xem nếu có cột chọn thì Hiển thị lên
                If (.Columns.Contains("Chon")) Then
                    'Chọn
                    With .Columns("Chon")
                        .HeaderText = "Chọn"
                        .Width = 100
                        .Visible = True
                        .DisplayIndex = 0
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                End If
                'Họ tên
                If (.Columns.Contains("HoTen")) Then
                    With .Columns("HoTen")
                        .HeaderText = "Tên"
                        .Width = 200
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                End If
                'Dai chi thuong chu
                If (.Columns.Contains("DiaChi")) Then
                    With .Columns("DiaChi")
                        .HeaderText = "Địa chỉ"
                        .Width = 300
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                End If
                If strNhom = "TCDN" Then
                    With .Columns("SoDinhDanh")
                        .HeaderText = "Số giấy phép"
                        .Width = 100
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                    'Ngày cấp định danh 1
                    With .Columns("NgayCap")
                        .HeaderText = "Ngày cấp giấy phép"
                        .Width = 150
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                    'Nơi cấp định danh 1
                    With .Columns("NoiCap")
                        .HeaderText = "Nơi cấp giấy phép"
                        .Width = 150
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                ElseIf strNhom = "GDCN" Then
                    With .Columns("DinhDanh")
                        .HeaderText = "Định danh"
                        .Width = 100
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                    With .Columns("SoDinhDanh")
                        .HeaderText = "Số CMT"
                        .Width = 100
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                    'Ngày cấp định danh 1
                    With .Columns("NgayCap")
                        .HeaderText = "Ngày cấp CMT(HC)"
                        .Width = 150
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                    'Nơi cấp định danh 1
                    With .Columns("NoiCap")
                        .HeaderText = "Nơi cấp CMT(HC)"
                        .Width = 150
                        .Visible = True
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    End With
                End If

               
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
            MsgBox(" Danh sách Chủ tìm được " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

#Region "Các hàm xử lý Datatable và Grid"
    Private Function selectedRecords(ByVal dtOrginal As DataTable) As DataTable
        ' Làm sạch dữ liệu 
        Dim dtSecondary As New DataTable
        dtSecondary = dtOrginal.Clone
        dtSecondary.Rows.Clear()
        Try
            Dim intCounter As Int32 = dtOrginal.Rows.Count
            If intCounter > 0 Then
                Dim i As Int32 = 0
                For i = 0 To intCounter - 1
                    If (dtOrginal.Rows(i).Item("Chon").ToString <> "") Then
                        If (dtOrginal.Rows(i).Item("Chon").ToString = "True") Then
                            dtSecondary.Rows.Add(dtOrginal.Rows(i).ItemArray)
                        End If
                    End If
                Next i
            End If
        Catch ex As Exception
            strError = ""
            strError = ex.ToString()
            System.Windows.Forms.MessageBox.Show("Danh sách Chủ được lựa chọn đề nghị cấp GCN" + vbNewLine, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtSecondary
    End Function

    ''' <summary>
    ''' Thêm cột chọn vào  bảng
    ''' </summary>
    ''' <param name="workTable">Bảng cần thêm cột Chọn</param>
    ''' <param name="strColumnName">Tên cột chọn</param>
    ''' <param name="strCapture">Tiêu đề cột</param>
    ''' <remarks></remarks>
    Private Sub addSelectedColumn(ByRef workTable As DataTable, ByVal strColumnName As String, ByVal strCapture As String)
        Dim strError As String
        Try
            If (workTable.Columns.Contains(strColumnName)) Then
                Exit Sub
            End If
            Dim workColumn As New DataColumn(strColumnName, Type.GetType("System.Boolean")) ', strExpression)
            workTable.Columns.Add(workColumn)
            workColumn.AllowDBNull = True
            workColumn.Caption = strCapture
            workTable.Columns.Item("Chon").SetOrdinal(0)
        Catch ex As Exception
            strError = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Thay đổi trạng thái khi người dùng chọn/hay bỏ chọn 
    ''' </summary>
    ''' <param name="grdvw">Tên đối tượng Grid chứa cột Chon</param>
    ''' <param name="intRowIndex">Chỉ số dòng được click chuột</param>
    ''' <param name="intColumnIndex">Chỉ số cột được click chuột</param>
    ''' <remarks></remarks>
    Private Sub checkColumn(ByRef grdvw As DataGridView, ByVal intRowIndex As Int32, ByVal intColumnIndex As Int32)
        If (intRowIndex) < 0 Then
            Exit Sub
        End If
        If intColumnIndex = 0 Then
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
    End Sub

#End Region


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim TraCuu As New clsTraCuu
        Dim dtSearch As New DataTable
        With TraCuu
            .Connection = strConnection
            .HoTen = Me.txtHoTen.Text.Trim
            .DiaChi = Me.txtDiaChi.Text.Trim
            .SoDinhDanh = Me.txtSoCMT.Text.Trim
            If DTPNgayCapCMT.Checked Then
                .NgayCap = FormatDateTime(Me.DTPNgayCapCMT.Value, DateFormat.ShortDate)
            Else
                .NgayCap = Nothing
            End If
            .NoiCap = txtNoiCapCMT.Text.Trim
        End With
        dtSearch.Clear()
        With Me
            .grdvw.ClearSelection()
            'Gọi phương thức GetData để khởi tạo đối tượng ChuSuDung
            If (strNhom = "GDCN") Then
                dtSearch = TraCuu.SelectTraCuuChuByGDCN()
            ElseIf strNhom = "TCDN" Then
                dtSearch = TraCuu.SelectTraCuuChuByTCDN()
            ElseIf strNhom = "CQNN" Then
                dtSearch = TraCuu.SelectTraCuuChuByCQNN()
            End If
            'Thêm cột chọn kiểu CheckBoxColumn vào Datatable
            Me.addSelectedColumn(dtSearch, "Chon", "Chọn")
            'Trình bày dữ liệu lên Grid
            .grdvw.DataSource = dtSearch
            'Khi tồn tại bản ghi nhận được
            If dtSearch.Rows.Count > 0 Then
                .FormatGridContruction(Me.grdvw)
            Else
                .HideAllColumns(Me.grdvw)
            End If
        End With
    End Sub

    Private Sub grdvw_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdvw.CellMouseClick
        'Khai báo và khởi tạo  danh sách Chủ tìm được
        Dim dtChuTimKiem As New DataTable
        'Trường hợp người dùng Check vào mục chọn
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Me.checkColumn(grdvw, e.RowIndex, e.ColumnIndex)
        End If
        dtChuTimKiem = Me.grdvw.DataSource
        dtSelected = Me.selectedRecords(dtChuTimKiem)
    End Sub

    Private Sub ctrlTraCuu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With DTPNgayCapCMT
            .CustomFormat = "dd/MM/yyyy"
            .Format = DateTimePickerFormat.Custom
            .ShowCheckBox = True
            .Checked = False
        End With
        If strNhom = "TCDN" Then
            LabSoDinhDanh.Text = "Số giấy phép"
            LabNgayCapDinhDanh.Text = "Ngày cấp"
            LabNoiCapDinhDanh.Text = "Nơi cấp"
        ElseIf strNhom = "CQNN" Then
            txtSoCMT.Enabled = False
            DTPNgayCapCMT.Enabled = False
            DTPNgayCapCMT.Checked = False
            txtNoiCapCMT.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    End Sub
End Class
