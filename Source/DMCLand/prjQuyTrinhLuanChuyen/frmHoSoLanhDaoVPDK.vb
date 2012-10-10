Public Class frmHoSoLanhDaoVPDK
    Private shortAction As Short = 0
    Private strError As String = ""
    Private strConnection As String = ""
    Private dtTimKiem As New DataTable
    Private strMaDonViHanhChinh As String = ""
    Private strNgayTimKiem As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strToBanDo As String = ""
    Private strSoThua As String = ""
    Private strDienTich As String = ""
    Private strDiaChi As String = ""
    Private strThoiDiemTiepNhan As String = ""
    Private strTenNguoiTiepNhan As String = ""
    Private strTenNguoiKeKhai As String = ""
    Private strDieuKien As String = ""
    Private strLyDoKhongDuDK As String = ""
    Private strThoiDiemChuyen As String = Now.Date.ToString()
    Private strTrangThai As String = ""
    Private strChonIn As String = ""


    Public Property Conection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Private Sub frmDanhSachHoSoDaChuyenLenVPThamDinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With Me.dtpVPThamDinh
            .CustomFormat = "dd/MM/yyyy"
            .Format = DateTimePickerFormat.Custom
            .ShowCheckBox = True
        End With

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        gridVPThamDinhChuyenLen.ClearSelection()
        strNgayTimKiem = ""
        TimKiemVPThamDinhTiepNhan()
    End Sub
    Public Sub ShowDataVPThamDinhTiepNhan()
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .gridVPThamDinhChuyenLen
                .ClearSelection()
            End With
        End With
        'Kiem tra xem da chon don vi hanh chinh can tac nghiep chua
        If (strMaDonViHanhChinh.Trim = "") Or (strMaDonViHanhChinh = "0") Then
            MsgBox("Bạn chưa chọn đơn vị hành chính!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh

        End With
        Try
            dtTimKiem = TimKiem.SelectHoSoVPThamDinhDaNhan()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If

            Dim col As New DataColumn()
            col.ColumnName = "Chon"
            col.DataType = System.Type.GetType("System.Boolean")
            dtTimKiem.Columns.Add(col)
            'Trình bày dữ liệu lên Form
            Me.gridVPThamDinhChuyenLen.DataSource = dtTimKiem

            With gridVPThamDinhChuyenLen
                For i As Integer = 0 To .Columns.Count - 1
                    .Columns(i).Visible = False
                Next

                .Columns("MaHoSoCapGCN").HeaderText = "Mã Hồ Sơ Cấp GCN"
                .Columns("MaHoSoCapGCN").Visible = False

                .Columns("ToBanDo").HeaderText = "Tờ Bản Đồ"
                .Columns("ToBanDo").Width = 100
                .Columns("ToBanDo").Visible = True

                .Columns("SoThua").HeaderText = "Số Thửa"
                .Columns("SoThua").Width = 100
                .Columns("SoThua").Visible = True

                .Columns("DiaChi").HeaderText = "Địa Chỉ"
                .Columns("DiaChi").Width = 300
                .Columns("DiaChi").Visible = True

                .Columns("DienTich").HeaderText = "Diện Tích"
                .Columns("DienTich").Width = 100
                .Columns("DienTich").Visible = True

                .Columns("NgayNhanChuyenLen").HeaderText = "Ngày Nhận Hồ Sơ"
                .Columns("NgayNhanChuyenLen").Width = 150
                .Columns("NgayNhanChuyenLen").Visible = True

                .Columns("DuDieuKien").HeaderText = "Có/Không đủ ĐK"
                .Columns("DuDieuKien").Width = 150
                .Columns("DuDieuKien").Visible = True

                .Columns("LyDoKhongDuDK").HeaderText = "Lý do không đủ ĐK"
                .Columns("LyDoKhongDuDK").Width = 200
                .Columns("LyDoKhongDuDK").Visible = True

                .Columns("DaXuLy").HeaderText = "HS xử lý/chưa xử lý"
                .Columns("DaXuLy").Width = 200
                .Columns("DaXuLy").Visible = True

                .Columns("SoLan").HeaderText = "Số lần xử lý"
                .Columns("SoLan").Width = 100
                .Columns("SoLan").Visible = True

                .Columns("Chon").HeaderText = "Chọn"
                .Columns("Chon").Width = 50
                .Columns("Chon").Visible = True
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    ' tìm kiếm hồ sơ ở văn phòng nhà đất đã được nhận từ 1 cửa chuyển lên
    '
    Public Sub TimKiemVPThamDinhTiepNhan()
        Try
            ShowDataVPThamDinhTiepNhan()
            If Not gridVPThamDinhChuyenLen.DataSource Is Nothing Then
                With CtrFilterGridVpNhaDatThamDinh
                    .MyGrid = gridVPThamDinhChuyenLen
                    .MydataTable = Nothing
                    .MydataTable = gridVPThamDinhChuyenLen.DataSource
                    .TaoContol()
                End With
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        strTrangThai = "4"
        Me.gridVPThamDinhChuyenLen.EndEdit()
        For i As Integer = 0 To gridVPThamDinhChuyenLen.Rows.Count - 1
            If (Me.gridVPThamDinhChuyenLen.Rows(i).Cells("Chon").Value.ToString = "True") Then
                ' lấy các giá trị các cột tại dòng i được chọn
                strMaHoSoCapGCN = gridVPThamDinhChuyenLen.Rows(i).Cells("MaHoSoCapGCN").Value.ToString()
                strToBanDo = gridVPThamDinhChuyenLen.Rows(i).Cells("ToBanDo").Value.ToString()
                strSoThua = gridVPThamDinhChuyenLen.Rows(i).Cells("SoThua").Value.ToString()
                strDienTich = gridVPThamDinhChuyenLen.Rows(i).Cells("DienTich").Value.ToString()
                strDiaChi = gridVPThamDinhChuyenLen.Rows(i).Cells("DiaChi").Value.ToString()
                strThoiDiemTiepNhan = gridVPThamDinhChuyenLen.Rows(i).Cells("NgayNhanChuyenLen").Value.ToString()
                If gridVPThamDinhChuyenLen.Rows(i).Cells("DuDieuKien").Value.ToString() = "True" Then
                    strDieuKien = "1"
                Else
                    strDieuKien = "0"
                End If
                strLyDoKhongDuDK = gridVPThamDinhChuyenLen.Rows(i).Cells("LyDoKhongDuDK").Value.ToString()

                ' truyền biến và insert vào bên bảng VPThamDinh
                InsertPhongTNMT()
                UpdateVPThamDinh()
                InsertLuanChuyenTheoDoi()

            End If
        Next
        ' load lại grid của tiếp nhận
        gridVPThamDinhChuyenLen.ClearSelection()
        strNgayTimKiem = ""
        ShowDataVPThamDinhTiepNhan()
        'MsgBox("Có " + S.ToString + " dòng được check" + vbLf + kq)
    End Sub
    Public Sub InsertPhongTNMT()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim Insert As New ClsLuanChuyen
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .gridVPThamDinhChuyenLen
                .ClearSelection()
            End With
        End With
        'Kiem tra xem da chon don vi hanh chinh can tac nghiep chua
        If (strMaDonViHanhChinh.Trim = "") Or (strMaDonViHanhChinh = "0") Then
            MsgBox("Bạn chưa chọn đơn vị hành chính!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        With Insert
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh
            .MaHoSoCapGCN = strMaHoSoCapGCN
            .ToBanDo = strToBanDo
            .SoThua = strSoThua
            .DiaChi = strDiaChi
            .DienTich = strDienTich
            .ThoiDiemChuyen = strThoiDiemChuyen
            .ThoiDiemNhan = strThoiDiemTiepNhan
            .DieuKien = strDieuKien
            .LyDoKhongDuDK = strLyDoKhongDuDK
        End With
        Try
            Dim str As String = ""
            Insert.InsertPhongTNMT(str)

            strError = Insert.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Public Sub UpdateVPThamDinh()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim Insert As New ClsLuanChuyen
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .gridVPThamDinhChuyenLen
                .ClearSelection()
            End With
        End With
        'Kiem tra xem da chon don vi hanh chinh can tac nghiep chua
        If (strMaDonViHanhChinh.Trim = "") Or (strMaDonViHanhChinh = "0") Then
            MsgBox("Bạn chưa chọn đơn vị hành chính!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        With Insert
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh
            .MaHoSoCapGCN = strMaHoSoCapGCN
            .ToBanDo = strToBanDo
            .SoThua = strSoThua
            .DiaChi = strDiaChi
            .DienTich = strDienTich
            .ThoiDiemChuyen = strThoiDiemChuyen
            .DieuKien = strDieuKien
            .LyDoKhongDuDK = strLyDoKhongDuDK

        End With
        Try
            Dim str As String = ""
            Insert.UpdatPThamDinh(str)

            strError = Insert.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub InsertLuanChuyenTheoDoi()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim Insert As New ClsLuanChuyen
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
        End With
        'Kiem tra xem da chon don vi hanh chinh can tac nghiep chua
        If (strMaDonViHanhChinh.Trim = "") Or (strMaDonViHanhChinh = "0") Then
            MsgBox("Bạn chưa chọn đơn vị hành chính!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        With Insert
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh
            .MaHoSoCapGCN = strMaHoSoCapGCN
            .ToBanDo = strToBanDo
            .SoThua = strSoThua
            .DiaChi = strDiaChi
            .DienTich = strDienTich
            .ThoiDiemChuyen = strThoiDiemChuyen
            .ThoiDiemNhan = strThoiDiemTiepNhan
            .TenNguoiNhan = strTenNguoiTiepNhan
            .TenNguoiKeKhai = strTenNguoiKeKhai
            .TrangThai = strTrangThai
            .DieuKien = strDieuKien
            .LyDoKhongDuDK = strLyDoKhongDuDK
        End With
        Try
            Dim str As String = ""
            Insert.InsertLuanChuyenTheoDoi(str)

            strError = Insert.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub cmdBCVPThamDInhChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBCVPThamDInhChuyen.Click
        Dim cls As New ClsLuanChuyen
        cls.Connection = strConnection
        cls.MaDonViHanhChinh = strMaDonViHanhChinh
        cls.InBaoCaoHoSo("LDVP", dtpVPThamDinh)
    End Sub

    Private Sub cmdCapNhatVPThamDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCapNhatVPThamDinh.Click
        Dim cls As New ClsLuanChuyen
        cls.Connection = strConnection
        cls.MaDonViHanhChinh = strMaDonViHanhChinh
        cls.CapNhatDieuKienHoSo("spUpdateDKLyDoVPThamDinh", gridVPThamDinhChuyenLen)
        ShowDataVPThamDinhTiepNhan()
    End Sub
 

    Private Sub chkDuDKVPTHamDinh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDuDKVPTHamDinh.CheckedChanged
        Dim cls As New ClsLuanChuyen
        cls.UpdateThongTinCheck(gridVPThamDinhChuyenLen, gridVPThamDinhChuyenLen.CurrentRow.Index, chkDuDKVPTHamDinh)
    End Sub

    Private Sub txtLyDoKhongDuDKVPTHamDinh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLyDoKhongDuDKVPTHamDinh.KeyDown
        If e.KeyValue = 13 Then
            Dim cls As New ClsLuanChuyen
            cls.UpdateThongTinLyDo(gridVPThamDinhChuyenLen, gridVPThamDinhChuyenLen.CurrentRow.Index, chkDuDKVPTHamDinh, txtLyDoKhongDuDKVPTHamDinh)
        End If
    End Sub

    Public Sub TimKiemHoSoVPNhaDatChuyenLenThamDinh()
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        Dim frm As New frmHoSoLanhDaoVPDK()
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()

        End With
        'Kiem tra xem da chon don vi hanh chinh can tac nghiep chua
        If (strMaDonViHanhChinh.Trim = "") Or (strMaDonViHanhChinh = "0") Then
            MsgBox("Bạn chưa chọn đơn vị hành chính!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh

        End With
        Try
            dtTimKiem = TimKiem.SelectHoSoVPNhaDatChuyen()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If
            Dim cls As New ClsLuanChuyen
            If dtTimKiem.Rows.Count > 0 Then
                'Trình bày dữ liệu lên Form

                grdHoSoDaChuyen.DataSource = dtTimKiem
                cls.ChangeTile(grdHoSoDaChuyen)
            ElseIf dtTimKiem.Rows.Count = 0 Then
                grdHoSoDaChuyen.DataSource = dtTimKiem
                cls.ChangeTile(grdHoSoDaChuyen)
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub ShowTimKiemTheoDoi()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .DataGridTheoDoi
                .ClearSelection()
            End With
        End With
        'Kiem tra xem da chon don vi hanh chinh can tac nghiep chua
        If (strMaDonViHanhChinh.Trim = "") Or (strMaDonViHanhChinh = "0") Then
            MsgBox("Bạn chưa chọn đơn vị hành chính!", MsgBoxStyle.Information, "DMCLand")
            Exit Sub
        End If
        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh

        End With
        Try
            dtTimKiem = TimKiem.SelectHoSoTheoDoi()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If
            If dtTimKiem.Rows.Count > 0 Then
                'Trình bày dữ liệu lên Form
                Me.DataGridTheoDoi.DataSource = dtTimKiem
            Else
                Me.DataGridTheoDoi.DataSource = dtTimKiem
            End If

            With DataGridTheoDoi
                For i As Integer = 0 To .Columns.Count - 1
                    .Columns(i).Visible = False
                Next

                .Columns("ToBanDo").HeaderText = "Tờ Bản Đồ"
                .Columns("ToBanDo").Width = 100
                .Columns("ToBanDo").Visible = True

                .Columns("SoThua").HeaderText = "Số Thửa"
                .Columns("SoThua").Width = 100
                .Columns("SoThua").Visible = True

                .Columns("DiaChi").HeaderText = "Địa Chỉ"
                .Columns("DiaChi").Width = 300
                .Columns("DiaChi").Visible = True

                .Columns("DienTich").HeaderText = "Diện Tích"
                .Columns("DienTich").Width = 100
                .Columns("DienTich").Visible = True

                .Columns("NgayChuyen").HeaderText = "Ngày Chuyển Hồ Sơ"
                .Columns("NgayChuyen").Width = 150
                .Columns("NgayChuyen").Visible = True

                .Columns("ViTriHoSo").HeaderText = "Hồ Sơ Đã Qua"
                .Columns("ViTriHoSo").Width = 300
                .Columns("ViTriHoSo").Visible = True

                .Columns("DuDieuKien").HeaderText = "Có/Không đủ ĐK"
                .Columns("DuDieuKien").Width = 150
                .Columns("DuDieuKien").Visible = True

                .Columns("LyDoKhongDuDK").HeaderText = "Lý do không đủ ĐK"
                .Columns("LyDoKhongDuDK").Width = 200
                .Columns("LyDoKhongDuDK").Visible = True

            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub TimKiemTheoDoi()
        Try
            ShowTimKiemTheoDoi()
            If Not DataGridTheoDoi.DataSource Is Nothing Then
                With CtrFilterGrid3
                    .MyGrid = DataGridTheoDoi
                    .MydataTable = Nothing
                    .MydataTable = DataGridTheoDoi.DataSource
                    .TaoContol()
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        TimKiemTheoDoi()
    End Sub

    Private Sub gridVPThamDinhChuyenLen_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles gridVPThamDinhChuyenLen.ColumnWidthChanged
        If Not gridVPThamDinhChuyenLen.DataSource Is Nothing Then
            CtrFilterGridVpNhaDatThamDinh.TaoContol()
        End If
    End Sub

    Private Sub DataGridTheoDoi_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DataGridTheoDoi.ColumnWidthChanged
        If Not DataGridTheoDoi.DataSource Is Nothing Then
            CtrFilterGrid3.TaoContol()
        End If
    End Sub

    Private Sub chkgridVPThamDinhChuyenLen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkgridVPThamDinhChuyenLen.CheckedChanged
        Dim cls As New ClsLuanChuyen
        cls.CheckGrid(gridVPThamDinhChuyenLen, chkgridVPThamDinhChuyenLen)
    End Sub
    Private Sub gridVPThamDinhChuyenLen_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridVPThamDinhChuyenLen.CellMouseClick
        Dim cls As New ClsLuanChuyen
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            cls.checkColumn(gridVPThamDinhChuyenLen, e.RowIndex, e.ColumnIndex)
        End If
        cls.LayThongTin(gridVPThamDinhChuyenLen, e.RowIndex, chkDuDKVPTHamDinh, txtLyDoKhongDuDKVPTHamDinh)
    End Sub
End Class