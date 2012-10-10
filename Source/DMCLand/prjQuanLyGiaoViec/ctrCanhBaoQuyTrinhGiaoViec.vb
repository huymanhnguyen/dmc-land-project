Public Class ctrCanhBaoQuyTrinhGiaoViec
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

    Private R, G, B As Integer
    Public Event NghiepVuHoSo()
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

    Private strMaHoSoCapGCN As String = ""
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Private strMaThuaDat As String = ""
    Public Property MaThuaDat() As String
        Get
            Return strMaThuaDat
        End Get
        Set(ByVal value As String)
            strMaThuaDat = value
        End Set
    End Property

    Private strCountBanGhi As Int16 = 0
    Public Property CountBanGhi() As Int16
        Get
            Return strCountBanGhi
        End Get
        Set(ByVal value As Int16)
            strCountBanGhi = value
        End Set
    End Property
    Private Sub cmdDieuChinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDieuChinh.Click
        If grdDanhMucHoSo.CurrentRow.Cells("MaHoSoCapGCN").Value.ToString <> "" And grdDanhMucHoSo.CurrentRow.Cells("MaHoSoCapGCN").Value.ToString <> "0" Then
            Dim frm As New frmDieuChinhQuyTrinhHoSo
            With frm.CtrDieuChinh1
                .Conection = strConnection
                .MaDonViHanhChinh = strMaDonViHanhChinh
                .ToBanDo = grdDanhMucHoSo.CurrentRow.Cells("ToBanDoTimKiem").Value.ToString
                .SoThua = grdDanhMucHoSo.CurrentRow.Cells("SoThuaTimKiem").Value.ToString
                .ChuSuDung = grdDanhMucHoSo.CurrentRow.Cells("HoTenTimKiem").Value.ToString
                .HoSoCapGCN = grdDanhMucHoSo.CurrentRow.Cells("MaHoSoCapGCN").Value.ToString
                .MaLoaiHS = cboTuDienLuanChuyenHoSo.SelectedValue.ToString.Trim
                .TenLoaiHS = cboTuDienLuanChuyenHoSo.Text.Trim
                .ShowData()
            End With
            frm.ShowDialog()
        End If
    End Sub

    Public Sub LoadTuDienLuanChuyenHoSo()
        Dim dt As New DataTable
        Dim cls As New clsQuanLyGiaoViec
        With cls
            .Connection = strConnection
            dt = .selTuDienLuanChuyenHoSo()
            cboTuDienLuanChuyenHoSo.DataSource = dt
            If dt.Rows.Count > 0 Then
                cboTuDienLuanChuyenHoSo.DisplayMember = "TenLoaiHS"
                cboTuDienLuanChuyenHoSo.ValueMember = "MaLoaiHS"
                cboTuDienLuanChuyenHoSo.SelectedItem = cboTuDienLuanChuyenHoSo.Items(1)
            End If
        End With
        
    End Sub
    Private Sub ctrCanhBaoQuyTrinhGiaoViec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub HienThiGhiChuMau()
        Dim cls As New clsQuanLyGiaoViec
        Dim dt As New DataTable
        With cls
            .Connection = strConnection
            .MaLoaiHS = cboTuDienLuanChuyenHoSo.SelectedValue.ToString.Trim
            dt = .selGhiChuMaMau
            Dim pt As New System.Drawing.Point(0, 0)
            Dim chayY As Integer = 0
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim R, G, B As Integer
                G = dt.Rows(i).Item("G").ToString
                R = dt.Rows(i).Item("R").ToString
                B = dt.Rows(i).Item("B").ToString
                Dim txt As New TextBox
                txt.Name = "txt" & i
                txt.Text = dt.Rows(i).Item("TenCongViec")
                txt.ForeColor = Color.FromArgb(255, 255, 255)
                txt.BackColor = Color.FromArgb(G, R, B)
                txt.Width = 200
                txt.Height = 20
                pt.X = 6
                pt.Y = 10 + chayY
                txt.Location = pt
                GrGhiChu.Controls.Add(txt)

                chayY = chayY + 20
            Next
             
        End With
    End Sub
    Public Sub showData()

        Dim cls As New clsQuanLyGiaoViec
        Dim dt As New DataTable
        With cls
            .Connection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh
            .MaLoaiHS = cboTuDienLuanChuyenHoSo.SelectedValue.ToString.Trim
            .MaDonViHanhChinh = strMaDonViHanhChinh
            dt = .selDanhSachHoSoCanhBao
            strCountBanGhi = dt.Rows.Count
        End With
        If dt.Rows.Count > 0 Then
            'Trình bày dữ liệu lên Form
            Try
                LoadGrid(dt)
            Catch ex As Exception

            End Try
        Else
            grdDanhMucHoSo.Rows.Clear()
        End If
    End Sub
    Public Sub LoadGrid(ByVal dtTimKiem As DataTable)
        grdDanhMucHoSo.Rows.Clear()
        If dtTimKiem.Rows.Count > 0 Then
            Dim R, G, B As Integer
            For i As Integer = 0 To dtTimKiem.Rows.Count - 1
                With Me.grdDanhMucHoSo
                    .RowCount += 1
                    .Item("TenCongViec", i).Value = dtTimKiem.Rows(i).Item("TenCongViec").ToString
                    .Item("MaThuaDat", i).Value = dtTimKiem.Rows(i).Item("MaThuaDat").ToString
                    .Item("MaHoSoCapGCN", i).Value = dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString
                    .Item("ToBanDoTimKiem", i).Value = dtTimKiem.Rows(i).Item("ToBanDo").ToString
                    .Item("SoThuaTimKiem", i).Value = dtTimKiem.Rows(i).Item("SoThua").ToString
                    .Item("DiaChiThuaTimKiem", i).Value = dtTimKiem.Rows(i).Item("DiaChi").ToString
                    .Item("DienTichTimKiem", i).Value = dtTimKiem.Rows(i).Item("DienTich").ToString
                    .Item("NgayLapToTrinhTimKiem", i).Value = dtTimKiem.Rows(i).Item("NgayLapToTrinh").ToString
                    .Item("NgayQuyetDinhCapGCNTimKiem", i).Value = dtTimKiem.Rows(i).Item("NgayQuyetDinhCapGCN").ToString
                    .Item("HoTenTimKiem", i).Value = TongHopChu(dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString)
                    .Item("MaThuaDat", i).Value = dtTimKiem.Rows(i).Item("MaThuaDat").ToString

                    G = dtTimKiem.Rows(i).Item("G").ToString
                    R = dtTimKiem.Rows(i).Item("R").ToString
                    B = dtTimKiem.Rows(i).Item("B").ToString
                    .Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(G, R, B)

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
    Public Sub AddColumnsTimKiem()
        Dim txtClnTenCongViecTimKiem As New DataGridViewTextBoxColumn
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
            With txtClnTenCongViecTimKiem
                .HeaderText = "Công việc"
                .Name = "TenCongViec"
                .Width = 100 
            End With
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
            With Me.grdDanhMucHoSo
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Add Columns
                With .Columns
                    .Add(txtClnTenCongViecTimKiem)
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

    'Private Sub grdMaMau_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
    '    e.CellStyle.BackColor = Color.FromArgb(grdMaMau.Rows(e.RowIndex).Cells("G").Value, grdMaMau.Rows(e.RowIndex).Cells("R").Value, grdMaMau.Rows(e.RowIndex).Cells("B").Value)

    'End Sub

    Private Sub cmdChiTietHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChiTietHoSo.Click
        If grdDanhMucHoSo.Rows.Count >= 0 Then
            strMaHoSoCapGCN = grdDanhMucHoSo.CurrentRow.Cells("MaHoSoCapGCN").Value
            strMaThuaDat = grdDanhMucHoSo.CurrentRow.Cells("MaThuaDat").Value
            RaiseEvent NghiepVuHoSo()
        End If
    End Sub

    Private Sub cboTuDienLuanChuyenHoSo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTuDienLuanChuyenHoSo.SelectedIndexChanged
        For Each txt As Control In GrGhiChu.Controls
            GrGhiChu.Controls.RemoveByKey(txt.Name)
        Next
        HienThiGhiChuMau()
        showData()
    End Sub
End Class
