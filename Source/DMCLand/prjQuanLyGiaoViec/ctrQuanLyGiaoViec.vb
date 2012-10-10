Public Class ctrQuanLyGiaoViec
    Private shortAction As Short = 0
    Private strError As String = ""
    Private strConnection As String = ""
   
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

    Private Sub ctrQuanLyGiaoViec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MessageBox.Show(DateAdd(Now.Date, 5).ToString)

        Me.dtpTuNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpTuNgay.Format = DateTimePickerFormat.Custom
        Me.dtpTuNgay.ShowCheckBox = True
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
        LoadTuDienLuanChuyenHoSo()
        AddColumnsTimKiem()
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


    Private Sub cmdTongHop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTongHop.Click
        Dim ngaychay As DateTime = dtpTuNgay.Value
        With grdDanhSachCongViec
            .Columns.Clear()

            .Columns.Add("STT", "STT")
            .Columns.Add("TenCongViec", "Công việc")
            .Columns.Add("SoNgay", "Số ngày")
            .Columns.Add("TuNgay", "Từ ngày")
            .Columns.Add("DenNgay", "Đến ngày")
            .Columns.Add("BoPhan", "Bộ phận")
            .Columns.Add("CanBo", "Cán bộ")
            .Columns.Add("DieuChinh", "Điều chỉnh")
            .Columns.Add("SoNgayCanhBao", "Cảnh báo")

            .Columns("TuNgay").DefaultCellStyle.Format = "d"
            .Columns("DenNgay").DefaultCellStyle.Format = "d"
        End With

        Dim strSoNgayThuLy As String = "0"
        Dim strSoNgayInGiay As String = "0"
        Dim strSoNgayLDKy As String = "0"
        Dim strSoNgayKiemTra As String = "0"
        Dim strSoNgayKyGCN As String = "0"

        Dim dt As New DataTable
        Dim cls As New clsQuanLyGiaoViec

        cls.Connection = strConnection
        cls.MaLoaiHS = cboTuDienLuanChuyenHoSo.SelectedValue.ToString.Trim
        dt = cls.selDanhSachSoNgayQuanLy()
        If dt.Rows.Count > 0 Then
            ngaychay = dtpTuNgay.Value
            For i As Integer = 0 To dt.Rows.Count - 1
                With grdDanhSachCongViec
                    .Rows.Add(1)
                    .Rows(grdDanhSachCongViec.Rows.Count - 1).Cells("STT").Value = dt.Rows(i).Item("SoTT")
                    .Rows(grdDanhSachCongViec.Rows.Count - 1).Cells("TenCongViec").Value = dt.Rows(i).Item("TenCongViec")
                    .Rows(grdDanhSachCongViec.Rows.Count - 1).Cells("SoNgay").Value = dt.Rows(i).Item("SoNgayThucThi")
                    .Rows(grdDanhSachCongViec.Rows.Count - 1).Cells("TuNgay").Value = ngaychay
                    .Rows(grdDanhSachCongViec.Rows.Count - 1).Cells("DenNgay").Value = DateAdd(ngaychay, dt.Rows(i).Item("SoNgayThucThi"))
                    .Rows(grdDanhSachCongViec.Rows.Count - 1).Cells("BoPhan").Value = dt.Rows(i).Item("BoPhan")
                    .Rows(grdDanhSachCongViec.Rows.Count - 1).Cells("CanBo").Value = txtCanBo.Text
                    .Rows(grdDanhSachCongViec.Rows.Count - 1).Cells("DieuChinh").Value = ""
                    .Rows(grdDanhSachCongViec.Rows.Count - 1).Cells("SoNgayCanhBao").Value = NumNgayCanhBao.Value.ToString
                    ngaychay = DateAdd(ngaychay, dt.Rows(i).Item("SoNgayThucThi")).AddDays(1)
                End With
            Next
        Else
            MessageBox.Show("Chưa có thông tin quy định ngày quản lý quy trình", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub



    Public Sub XoaText()
        dtpTuNgay.Value = Now
        txtCanBo.Text = ""
        NumNgayCanhBao.Value = 0
    End Sub


    Public Sub LoadTuDienLuanChuyenHoSo()
        Dim dt As New DataTable
        Dim cls As New clsQuanLyGiaoViec
        With cls
            .Connection = strConnection
            dt = .selTuDienLuanChuyenHoSo()
            cboTuDienLuanChuyenHoSo.DataSource = dt
            cboTuDienLuanChuyenHoSo.DisplayMember = "TenLoaiHS"
            cboTuDienLuanChuyenHoSo.ValueMember = "MaLoaiHS"
        End With
    End Sub

    Private Sub cmdSoNgayQUanLy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSoNgayQUanLy.Click
        If cboTuDienLuanChuyenHoSo.Text = "" Then
            cboTuDienLuanChuyenHoSo.Focus()
            Return
        End If
        Dim frm As New fromTuDienSoNgayQuanLyQuyTrinh
        With frm
            .Connection = strConnection
            .MaLoaiHS = cboTuDienLuanChuyenHoSo.SelectedValue.ToString.Trim
            .TenLoaiHS = cboTuDienLuanChuyenHoSo.Text.Trim
            .ShowData()
        End With
        frm.ShowDialog()
    End Sub
    Public Sub AddColumnsTimKiem()
        Dim txtClnToBanDoTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnSoThuaTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnDienTichTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnDiaChiThuaTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnNgayLapToTrinhTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnNgayQuyetDinhCapGCNTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnHoTenTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnMaThuaDatTimKiem As New DataGridViewTextBoxColumn
        Dim txtClnHoSoCapGCNTimKiem As New DataGridViewTextBoxColumn
        'Dim txtClnSoDinhDanhTimKiem As New DataGridViewTextBoxColumn
        Try
            'Tờ bản đồ
            With txtClnHoSoCapGCNTimKiem
                .HeaderText = "Tờ bản đồ"
                .Name = "MaHoSoCapGCN"
                .Width = 100
                .Visible = False
            End With
            'Tờ bản đồ
            With txtClnToBanDoTimKiem
                .HeaderText = "Tờ bản đồ"
                .Name = "ToBanDoTimKiem"
                .Width = 100
            End With
            'Số hiệu thửa
            With txtClnSoThuaTimKiem
                .HeaderText = "Số thửa"
                .Name = "SoThuaTimKiem"
                .Width = 100
            End With
            'Dien tich thửa đất
            With txtClnDienTichTimKiem
                .HeaderText = "Diện tích"
                .Name = "DienTichTimKiem"
                .Width = 100
            End With
            'Địa chỉ thửa
            With txtClnDiaChiThuaTimKiem
                .HeaderText = "Địa chỉ đất"
                .Name = "DiaChiThuaTimKiem"
                .Width = 400
            End With
            'Địa chỉ thửa
            With txtClnNgayLapToTrinhTimKiem
                .HeaderText = "Năm trình"
                .Name = "NgayLapToTrinhTimKiem"
                .Width = 150
            End With

            With txtClnNgayQuyetDinhCapGCNTimKiem
                .HeaderText = "Năm cấp GCN"
                .Name = "NgayQuyetDinhCapGCNTimKiem"
                .Width = 150
            End With
            With txtClnHoTenTimKiem
                .HeaderText = "Chủ sử dụng"
                .Name = "HoTenTimKiem"
                .Width = 250
            End With
            With txtClnMaThuaDatTimKiem
                .HeaderText = ""
                .Name = "MaThuaDat"
                .Width = 0
                .Visible = False
            End With
            'With txtClnSoDinhDanhTimKiem
            '    .HeaderText = "Số định danh"
            '    .Name = "SoDinhDanhTimKiem"
            '    .Width = 100
            'End With
            'Add all to DataGridView
            With Me.grdDanhSachHoSo
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Add Columns
                With .Columns
                    .Add(txtClnToBanDoTimKiem)
                    .Add(txtClnSoThuaTimKiem)
                    .Add(txtClnDienTichTimKiem)
                    .Add(txtClnDiaChiThuaTimKiem)
                    .Add(txtClnNgayLapToTrinhTimKiem)
                    .Add(txtClnNgayQuyetDinhCapGCNTimKiem)
                    .Add(txtClnHoTenTimKiem)
                    .Add(txtClnMaThuaDatTimKiem)
                    .Add(txtClnHoSoCapGCNTimKiem)
                    '.Add(txtClnSoDinhDanhTimKiem)
                End With
                'Không cho phép thêm
                .AllowUserToAddRows = False
                'Không cho phép xóa
                .AllowUserToDeleteRows = False
                'Không lựa chọn bất kỳ dòng nào
                .ClearSelection()
            End With
        Catch ex As Exception
            MsgBox(" Tìm kiếm" + vbNewLine + " Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cboTuDienLuanChuyenHoSo.Text = "" Then
            cboTuDienLuanChuyenHoSo.Focus()
            Return
        End If

        Dim frm As New frmTimKiemHoSo
        With frm
            .MaximizeBox = False
            .MinimizeBox = False
            'Gán chuỗi kết nối cơ sở dữ liệu
            .CrtTimKiemHoSoThuaDat1.Connection = strConnection
            .CrtTimKiemHoSoThuaDat1.MaDonViHanhChinh = strMaDonViHanhChinh
            .CrtTimKiemHoSoThuaDat1.MaLoaiHS = cboTuDienLuanChuyenHoSo.SelectedValue.ToString.Trim
            .CrtTimKiemHoSoThuaDat1.LoadTrangThai()
            .ShowDialog()
            Dim strDanhSachHoSoChon As String = ""
            strDanhSachHoSoChon = .CrtTimKiemHoSoThuaDat1.DanhSachHoSoChon

            Dim dtTimKiem As New DataTable
            Dim TimKiem As New clsQuanLyGiaoViec
            dtTimKiem = New DataTable
            With Me
                'Lam sach du lieu
                dtTimKiem.Clear()
                With .grdDanhSachHoSo
                    .RowCount = 0
                    .ClearSelection()
                End With
            End With

            With TimKiem
                'Gán chuỗi kết nối Database cho clsTimKiem
                .Connection = strConnection
                .MaDonViHanhChinh = ToiUuXau(Me.strMaDonViHanhChinh)
                .DanhSachHoSoCapGCN = strDanhSachHoSoChon
            End With
            Try
                dtTimKiem = TimKiem.selDanhSachHoSoCapGCNDuocChon()
                'Kiểm tra tính hợp lệ của dữ liệu
                If dtTimKiem Is Nothing Then
                    Return
                End If
                If dtTimKiem.Rows.Count > 0 Then
                    'Trình bày dữ liệu lên Form
                    LoadGrid(dtTimKiem)
                End If
            Catch ex As Exception
                MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
            End Try
            .Close()
        End With
    End Sub
    Public Sub LoadGrid(ByVal dtTimKiem As DataTable)
        If dtTimKiem.Rows.Count > 0 Then
            For i As Integer = 0 To dtTimKiem.Rows.Count - 1
                With Me.grdDanhSachHoSo
                    .RowCount += 1
                    .Item("MaHoSoCapGCN", i).Value = dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString
                    .Item("ToBanDoTimKiem", i).Value = dtTimKiem.Rows(i).Item("ToBanDo").ToString
                    .Item("SoThuaTimKiem", i).Value = dtTimKiem.Rows(i).Item("SoThua").ToString
                    .Item("DiaChiThuaTimKiem", i).Value = dtTimKiem.Rows(i).Item("DiaChi").ToString
                    .Item("DienTichTimKiem", i).Value = dtTimKiem.Rows(i).Item("DienTich").ToString
                    .Item("NgayLapToTrinhTimKiem", i).Value = dtTimKiem.Rows(i).Item("NgayLapToTrinh").ToString
                    .Item("NgayQuyetDinhCapGCNTimKiem", i).Value = dtTimKiem.Rows(i).Item("NgayQuyetDinhCapGCN").ToString
                    .Item("HoTenTimKiem", i).Value = TongHopChu(dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString)
                    .Item("MaThuaDat", i).Value = dtTimKiem.Rows(i).Item("MaThuaDat").ToString
                End With
            Next i
        End If
    End Sub
    Public Function TongHopChu(ByVal strMaHoSoCapGCN As String) As String


        Dim strTongHop As String = ""
        Dim TimKiem As New clsTimKiemHoSo
        Dim dt As New DataTable

        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            'Mã đơn vị hành chính
            .MaHoSoCapGCN = strMaHoSoCapGCN
        End With
        Try
            'Goi phuong thuc GetData de khoi tao doi tuong clsTimKiem
            dt = TimKiem.SelectTongHopChu()
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    strTongHop = strTongHop & dt.Rows(i).Item(0) & ", "
                Next
                strTongHop = strTongHop.Substring(0, strTongHop.Length - 2)
            End If
        Catch ex As Exception
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return strTongHop
    End Function
    Public Function ToiUuXau(ByVal str As String) As String
        str = str.Replace("[", "[[]")
        str = str.Replace("%", "[%]")
        str = str.Replace("'", "''")
        Return str
    End Function

    Public Sub TrangThaiCapNhat(Optional ByVal blnCapNhat As Boolean = False)
        With Me
            dtpTuNgay.Enabled = blnCapNhat
            txtCanBo.ReadOnly = Not blnCapNhat
            NumNgayCanhBao.Enabled = blnCapNhat
        End With
    End Sub

    Public Sub TrangThaiBanDau(Optional ByVal blnClearGrid As Boolean = False)
        With Me
            dtpTuNgay.Value = Now
            txtCanBo.Text = ""
            NumNgayCanhBao.Value = 0
        End With
    End Sub

    Public Sub TrangThaiChucNang(Optional ByVal blnStartEdited As Boolean = False, Optional ByVal blnStartDeleted As Boolean = False)
        With Me
            .btnThem.Enabled = Not blnStartEdited
            .btnCapNhat.Enabled = blnStartEdited
            .btnHuyLenh.Enabled = blnStartEdited
            .cmdTongHop.Enabled = blnStartEdited
            If blnStartDeleted Then
                .btnCapNhat.Enabled = Not blnStartDeleted
                .btnHuyLenh.Enabled = Not blnStartDeleted
                .cmdTongHop.Enabled = Not blnStartEdited
            End If
        End With
    End Sub


    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        With Me
            .shortAction = 1
            'Thiet lap trang thai ban dau
            .TrangThaiBanDau()
            'Trang thai cap nhat
            .TrangThaiCapNhat(True)
            'Trang thai chuc nang 
            .TrangThaiChucNang(True)
        End With
    End Sub

   

    Public Sub UpdateData()
        'Khai báo và khởi tạo đối tượng
        Dim cls As New clsQuanLyGiaoViec
        cls.Connection = strConnection 'Gán chuỗi kết nối cơ sở dữ liệu
        Try
            'Xác nhận bản ghi cần xóa
            For i As Integer = 0 To grdDanhSachHoSo.RowCount - 1
                For j As Integer = 0 To grdDanhSachCongViec.RowCount - 1
                    With cls
                        .MaDonViHanhChinh = strMaDonViHanhChinh
                        .STT = grdDanhSachCongViec.Rows(j).Cells("STT").Value.ToString
                        .TenCongViec = grdDanhSachCongViec.Rows(j).Cells("TenCongViec").Value.ToString
                        .SoNgay = grdDanhSachCongViec.Rows(j).Cells("SoNgay").Value.ToString
                        .TuNgay = grdDanhSachCongViec.Rows(j).Cells("TuNgay").Value '.ToString("yyyy-MM-dd HH:mm:ss")
                        .DenNgay = grdDanhSachCongViec.Rows(j).Cells("DenNgay").Value '.ToString("yyyy-MM-dd HH:mm:ss")
                        .BoPhan = grdDanhSachCongViec.Rows(j).Cells("BoPhan").Value.ToString
                        .CanBo = grdDanhSachCongViec.Rows(j).Cells("CanBo").Value.ToString
                        .DieuChinh = grdDanhSachCongViec.Rows(j).Cells("DieuChinh").Value.ToString
                        .SoNgayCanhBao = grdDanhSachCongViec.Rows(j).Cells("SoNgayCanhBao").Value.ToString
                        .MaHoSoCapGCN = grdDanhSachHoSo.Rows(i).Cells("MaHoSoCapGCN").Value.ToString
                        .MaLoaiHS = cboTuDienLuanChuyenHoSo.SelectedValue.ToString.Trim
                        .LanDieuChinh = "0"
                    End With



                    Dim str As String = ""
                    If shortAction = 1 Then
                        cls.InsQuanLyGiaoViec(str)
                    End If
                    strError = cls.Err
                Next
                'ghi xac nhan thanh cong
                cls.UpQuanLyGiaoViec("")
            Next
           
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Cập nhật dữ liệu " & vbNewLine & " Thông tin thửa đất " _
                   & " Lỗi: " & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
        TrangThaiBanDau()
        shortAction = 0
    End Sub
    Public Shared Function ConvertoDate(ByVal dateString As String, ByRef result As DateTime) As Boolean
        Try
            Dim supportedFormats() As String = New String() {"MM/dd/yyyy", "MM/dd/yy", "ddMMMyyyy", "dMMMyyyy"}

            result = DateTime.ParseExact(dateString, supportedFormats, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
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
        strError = ""
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
    End Sub

    Private Sub btnHuyLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyLenh.Click
        shortAction = 0
        'Trạng thái chức năng
        Me.TrangThaiChucNang()
        'Trạng thái cập nhật
        Me.TrangThaiCapNhat()
    End Sub

    Private Sub cmdCongViecDaLapLich_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCongViecDaLapLich.Click
        Dim frm As New frmDanhSachCongViecDaGiao
        frm.Conection = strConnection
        frm.MaDonViHanhChinh = strMaDonViHanhChinh
        frm.AddColumnsTimKiem()
        frm.LoadTuDienLuanChuyenHoSo()
        frm.HienThiGhiChuMau()
        frm.showData()
        frm.ShowDialog()
    End Sub
End Class
