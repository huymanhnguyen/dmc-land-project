Public Class ctrDieuChinh
    Private strError As String = ""
    Private strMaQuanLy As String = ""
    Private shortAction As Short = 0
    Private strConnection As String = ""
    Private strMaLoaiHS As String

    Public Property MaLoaiHS() As String
        Get
            Return strMaLoaiHS
        End Get
        Set(ByVal value As String)
            strMaLoaiHS = value
        End Set
    End Property

    Private strTenLoaiHS As String

    Public Property TenLoaiHS() As String
        Get
            Return strTenLoaiHS
        End Get
        Set(ByVal value As String)
            strTenLoaiHS = value
        End Set
    End Property

    Public Property Conection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Private strMaDonViHanhChinh As String = "0"
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Private strUserName As String = ""
    Public Property UserName() As String
        Get
            Return strUserName
        End Get
        Set(ByVal value As String)
            strUserName = value
        End Set
    End Property
    Private strHoSoCapGCN As String = ""
    Public Property HoSoCapGCN() As String
        Get
            Return strHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strHoSoCapGCN = value
        End Set
    End Property

    Private strToBanDo As String = ""
    Public Property ToBanDo() As String
        Get
            Return strToBanDo
        End Get
        Set(ByVal value As String)
            strToBanDo = value
        End Set
    End Property
    Private strSoThua As String = ""
    Public Property SoThua() As String
        Get
            Return strSoThua
        End Get
        Set(ByVal value As String)
            strSoThua = value
        End Set
    End Property
    Private strChuSuDung As String = ""
    Public Property ChuSuDung() As String
        Get
            Return strChuSuDung
        End Get
        Set(ByVal value As String)
            strChuSuDung = value
        End Set
    End Property

    Private Sub grdDanhSachCongViec_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhSachCongViec.CellMouseClick

        If e.RowIndex >= 0 Then
            txtTenCongViec.Text = grdDanhSachCongViec.Rows(e.RowIndex).Cells("TenCongViec").Value.ToString
            NumSoNgay.Value = grdDanhSachCongViec.Rows(e.RowIndex).Cells("SoNgay").Value.ToString
            dtpTuNgay.Value = grdDanhSachCongViec.Rows(e.RowIndex).Cells("TuNgay").Value.ToString
            dtpDenNgay.Value = grdDanhSachCongViec.Rows(e.RowIndex).Cells("DenNgay").Value.ToString
            cboBoPhan.Text = grdDanhSachCongViec.Rows(e.RowIndex).Cells("BoPhan").Value.ToString
            txtCanBo.Text = grdDanhSachCongViec.Rows(e.RowIndex).Cells("CanBo").Value.ToString
            txtLyDoDieuChinh.Text = grdDanhSachCongViec.Rows(e.RowIndex).Cells("DieuChinh").Value.ToString
            NumNgayCanhBao.Value = grdDanhSachCongViec.Rows(e.RowIndex).Cells("SoNgayCanhBao").Value.ToString
        End If

    End Sub

    Private Sub ctrDieuChinh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'MessageBox.Show(DateAdd(Now.Date, 5).ToString)

        Me.dtpTuNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpTuNgay.Format = DateTimePickerFormat.Custom
        Me.dtpTuNgay.ShowCheckBox = True

        Me.dtpDenNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenNgay.Format = DateTimePickerFormat.Custom
        Me.dtpDenNgay.ShowCheckBox = True
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
        LabTenLoaiHS.Text = strTenLoaiHS
    End Sub
    Function DateAdd(ByVal CurDate As Date, ByVal Days As Long) As Date
        Do

            CurDate = CurDate.AddDays(1)
            If ((CurDate.DayOfWeek <> DayOfWeek.Saturday) And (CurDate.DayOfWeek <> DayOfWeek.Sunday)) Then
                ' If Weekday(CurDate) <> 1 Then
                Days = Days - 1
                'End If
            End If
        Loop While Days > 0
        DateAdd = CurDate
    End Function
    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            NumSoNgay.Enabled = blnCapNhat
            txtTenCongViec.ReadOnly = True
            dtpTuNgay.Enabled = blnCapNhat
            dtpDenNgay.Enabled = blnCapNhat
            cboBoPhan.Enabled = blnCapNhat
            txtCanBo.ReadOnly = True
            txtLyDoDieuChinh.ReadOnly = Not blnCapNhat
            NumNgayCanhBao.Enabled = blnCapNhat
        End With
    End Sub

    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            txtSTT.Text = "0"
            NumSoNgay.Value = 0
            txtTenCongViec.Text = ""
            dtpTuNgay.Value = Now
            dtpDenNgay.Value = Now
            cboBoPhan.Text = ""
            txtCanBo.Text = ""
            txtLyDoDieuChinh.Text = ""
            NumNgayCanhBao.Value = 0
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            .btnSua.Enabled = Not blnStartEdited
            '  .btnXoa.Enabled = Not blnStartEdited
            .btnCapNhat.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnCapNhat.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
            End If
        End With
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
    Private Sub FormatGridContruction(ByVal grd As DMC.Interface.GridView.ctrlGridView)
        Try
            'Ẩn tất cả các cột
            Me.HideAllColumns(grd)
            'Chỉ hiển thị những Cột cần thiết
            With grd 
                With .Columns("STT")
                    .HeaderText = "STT"
                    .Width = 80
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Quan he
                With .Columns("TenCongViec")
                    .HeaderText = "Công việc"
                    .Width = 250
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Ho va Ten
                With .Columns("SoNgay")
                    .HeaderText = "Số ngày"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Nam sinh
                With .Columns("TuNgay")
                    .HeaderText = "Từ ngày"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Gioi tinh
                With .Columns("DenNgay")
                    .HeaderText = "Đến ngày"
                    .Width = 100
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With

                'Quốc tịch 1
                With .Columns("CanBo")
                    .HeaderText = "Cán bộ"
                    .Width = 150
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                'Số định danh 1
                With .Columns("DieuChinh")
                    .HeaderText = "Lý do điều chỉnh"
                    .Width = 200
                    .Visible = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns("SoNgayCanhBao")
                    .HeaderText = "Số ngày cảnh báo"
                    .Width = 150
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
            MsgBox(" Điều chỉnh " & vbNewLine & " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub ShowData()
        txtToBanDo.Text = strToBanDo
        txtSoThua.Text = strSoThua
        txtCSD.Text = strChuSuDung
        Dim dt As New DataTable
        Dim cls As New clsQuanLyGiaoViec
        With cls
            .Connection = strConnection
            .MaHoSoCapGCN = strHoSoCapGCN
            .MaLoaiHS = strMaLoaiHS
            .MaDonViHanhChinh = strMaDonViHanhChinh
            dt = .selDanhSachCongViecQuanLy()

            If dt.Rows.Count > 0 Then
                'STT, MaHoSoCapGCN, TenCongViec, SoNgay, TuNgay, DenNgay, BoPhan, CanBo
                strMaQuanLy = dt.Rows(0).Item("maquanly")
                txtSTT.Text = dt.Rows(0).Item("STT")
                txtTenCongViec.Text = dt.Rows(0).Item("TenCongViec")
                NumSoNgay.Value = dt.Rows(0).Item("SoNgay")
                dtpTuNgay.Value = dt.Rows(0).Item("TuNgay")
                dtpDenNgay.Value = dt.Rows(0).Item("DenNgay")
                cboBoPhan.Text = dt.Rows(0).Item("BoPhan")
                txtCanBo.Text = dt.Rows(0).Item("CanBo")
                txtLyDoDieuChinh.Text = dt.Rows(0).Item("DieuChinh")
                NumNgayCanhBao.Value = dt.Rows(0).Item("SoNgayCanhBao")
                grdDanhSachCongViec.DataSource = dt
                FormatGridContruction(grdDanhSachCongViec)
            End If
        End With
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If strMaQuanLy <> "" Then
            shortAction = 2
            'Thiết lập trạng thái chức năng
            TrangThaiChucNang(True)
            'Thiết lập trạng thái cập nhật cho các điều khiển
            TrangThaiCapNhat(True)
        Else
            MsgBox("Chưa có thông tin!", MsgBoxStyle.Information, "DMCLand")
        End If
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If strMaQuanLy <> "" Then
            If MsgBox("Bạn chắc chắn muốn xóa không?", MsgBoxStyle.YesNo, "DMCLand!") = MsgBoxResult.Yes Then
                Try
                    With Me
                        .shortAction = 3
                        .UpdateData()
                        strMaQuanLy = ""
                    End With
                Catch ex As Exception
                    strError = ex.Message
                End Try
                If (strError = "") Or (strError = "OK") Then
                    MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
                Else
                    MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
                End If
            End If
        Else
            MsgBox(" Bạn chưa chọn thông tin cần xóa!", MsgBoxStyle.Information, "DMCLand")
        End If
        strError = ""
    End Sub

    Public Sub UpdateData()
        'Khai báo và khởi tạo đối tượng
        Dim cls As New clsQuanLyGiaoViec
        cls.Connection = strConnection
        cls.MaLoaiHS = strMaLoaiHS
        cls.MaDonViHanhChinh = strMaDonViHanhChinh
        cls.MaHoSoCapGCN = strHoSoCapGCN

        Dim dt As New DataTable
        dt = cls.selLanDieuChinh()
        Dim LanDieuCHinh As Integer
        LanDieuCHinh = dt.Rows(0).Item(0)

        Try
            'Xác nhận bản ghi cần xóa
            For j As Integer = 0 To grdDanhSachCongViec.RowCount - 1
                With cls

                    .STT = grdDanhSachCongViec.Rows(j).Cells("STT").Value.ToString
                    .TenCongViec = grdDanhSachCongViec.Rows(j).Cells("TenCongViec").Value.ToString
                    .SoNgay = grdDanhSachCongViec.Rows(j).Cells("SoNgay").Value.ToString
                    .TuNgay = grdDanhSachCongViec.Rows(j).Cells("TuNgay").Value.ToString
                    .DenNgay = grdDanhSachCongViec.Rows(j).Cells("DenNgay").Value.ToString
                    .BoPhan = grdDanhSachCongViec.Rows(j).Cells("BoPhan").Value.ToString
                    .CanBo = grdDanhSachCongViec.Rows(j).Cells("CanBo").Value.ToString
                    .DieuChinh = grdDanhSachCongViec.Rows(j).Cells("DieuChinh").Value.ToString
                    .SoNgayCanhBao = grdDanhSachCongViec.Rows(j).Cells("SoNgayCanhBao").Value.ToString
                    .LanDieuChinh = LanDieuCHinh + 1
                End With
                Dim str As String = ""
                If shortAction = 2 Then
                    cls.InsQuanLyGiaoViec(str)
                End If
                strError = cls.Err
            Next
            'ghi xac nhan thanh cong
            cls.UpQuanLyGiaoViec("")
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Thông tin thửa đất " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        TrangThaiBanDau()
        shortAction = 0
    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        Try
            With Me
                'Cập nhật thông tin Thửa đất sử dụng
                .UpdateData()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Thửa đất sử dụng " & vbNewLine _
                & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        If (strError = "") Or (strError = "OK") Then
            MsgBox(" Bạn đã cập nhật thành công!", MsgBoxStyle.Information, "DMCLand")
        Else
            MsgBox(" Cập nhật chưa thành công!", MsgBoxStyle.Critical, "DMCLand")
        End If
        ShowData()
        strError = ""
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        With Me
            'Hiển thị dữ liệu
            .ShowData()
        End With
        shortAction = 0
    End Sub

    Private Sub cmdTongHop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTongHop.Click
        Dim ngaychay As DateTime = dtpTuNgay.Value
        Dim dt As New DataTable
        Dim cls As New clsQuanLyGiaoViec

        cls.Connection = strConnection
        cls.MaLoaiHS = strMaLoaiHS
        dt = cls.selDanhSachSoNgayQuanLy()
        If dt.Rows.Count > 0 Then
            Dim stt As Integer = 0
            stt = grdDanhSachCongViec.CurrentRow.Cells("STT").Value
            ngaychay = dtpTuNgay.Value
            For i As Integer = 0 To grdDanhSachCongViec.Rows.Count - 1
                If grdDanhSachCongViec.Rows(i).Cells("STT").Value >= stt Then
                    grdDanhSachCongViec.Rows(i).Cells("TuNgay").Value = ngaychay.ToString
                    grdDanhSachCongViec.Rows(i).Cells("DenNgay").Value = DateAdd(ngaychay, grdDanhSachCongViec.Rows(i).Cells("SoNgay").Value).ToString
                    grdDanhSachCongViec.Rows(i).Cells("DieuChinh").Value = txtLyDoDieuChinh.Text
                    grdDanhSachCongViec.Rows(i).Cells("SoNgayCanhBao").Value = NumNgayCanhBao.Value.ToString
                    ngaychay = DateAdd(ngaychay, grdDanhSachCongViec.Rows(i).Cells("SoNgay").Value).AddDays(1)
                End If
            Next
        Else
            MessageBox.Show("Chưa có thông tin quy định ngày quản lý quy trình", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
