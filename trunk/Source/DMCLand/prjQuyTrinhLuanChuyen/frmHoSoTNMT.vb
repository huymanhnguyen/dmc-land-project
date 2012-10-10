Public Class frmHoSoTNMT
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

 

    ' tìm kiếm hồ sơ ở văn phòng nhà đất đã được nhận từ 1 cửa chuyển lên
    '
    Public Sub ShowDataTNMTTiepNhan()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .datagridTNMTChuyen
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
            dtTimKiem = TimKiem.SelectHoSoPhongTNMTDanhan()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If

            Dim col As New DataColumn()
            col.ColumnName = "Chon"
            col.DataType = System.Type.GetType("System.Boolean")
            dtTimKiem.Columns.Add(col)
            'Trình bày dữ liệu lên Form
            Me.datagridTNMTChuyen.DataSource = dtTimKiem

            With datagridTNMTChuyen
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
    Public Sub TimKiemTNMTTiepNhan()
        Try
            ShowDataTNMTTiepNhan()
            If Not datagridTNMTChuyen.DataSource Is Nothing Then
                With CtrFilterGridPhongTNNHan
                    .MyGrid = datagridTNMTChuyen
                    .MydataTable = Nothing
                    .MydataTable = datagridTNMTChuyen.DataSource
                    .TaoContol()
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub
 
    Public Sub InsertUBThamDinh()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim Insert As New ClsLuanChuyen
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .datagridTNMTChuyen
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
            Insert.InsertUBThamDinh(str)

            strError = Insert.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Public Sub UpdatePhongTNMT()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim Insert As New ClsLuanChuyen
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()

            With .datagridTNMTChuyen
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
            Insert.UpdatTNMT(str)

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
  
 

  
    Public Sub TimKiemHoSoDaChuyenLenUBThamDinh()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        Dim frm As New frmHoSoUB()
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
            dtTimKiem = TimKiem.SelectHoSoTNMTDaChuyen()
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

    Private Sub frmHoSoTNMT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With Me.dtpTNMT
            .CustomFormat = "dd/MM/yyyy"
            .Format = DateTimePickerFormat.Custom
            .ShowCheckBox = True
        End With
    End Sub

    Private Sub chkDuDieuKienTNMT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDuDieuKienTNMT.CheckedChanged
        Dim cls As New ClsLuanChuyen
        cls.UpdateThongTinCheck(datagridTNMTChuyen, datagridTNMTChuyen.CurrentRow.Index, chkDuDieuKienTNMT)
    End Sub

    Private Sub txtLyDoKhongDuDKTNMT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLyDoKhongDuDKTNMT.KeyDown
        If e.KeyValue = 13 Then
            Dim cls As New ClsLuanChuyen
            cls.UpdateThongTinLyDo(datagridTNMTChuyen, datagridTNMTChuyen.CurrentRow.Index, chkDuDieuKienTNMT, txtLyDoKhongDuDKTNMT)
        End If
    End Sub
 

    Private Sub cmdCapNhatTNMT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCapNhatTNMT.Click
        Dim cls As New ClsLuanChuyen
        cls.Connection = strConnection
        cls.MaDonViHanhChinh = strMaDonViHanhChinh
        cls.CapNhatDieuKienHoSo("spUpdateDKLyDoTNMT", datagridTNMTChuyen)
        ShowDataTNMTTiepNhan()
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        datagridTNMTChuyen.ClearSelection()
        strNgayTimKiem = ""
        TimKiemTNMTTiepNhan()
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        strTrangThai = "5"
        Me.datagridTNMTChuyen.EndEdit()
        For i As Integer = 0 To datagridTNMTChuyen.Rows.Count - 1
            If (Me.datagridTNMTChuyen.Rows(i).Cells("Chon").Value.ToString = "True") Then
                ' lấy các giá trị các cột tại dòng i được chọn
                strMaHoSoCapGCN = datagridTNMTChuyen.Rows(i).Cells("MaHoSoCapGCN").Value.ToString()
                strToBanDo = datagridTNMTChuyen.Rows(i).Cells("ToBanDo").Value.ToString()
                strSoThua = datagridTNMTChuyen.Rows(i).Cells("SoThua").Value.ToString()
                strDienTich = datagridTNMTChuyen.Rows(i).Cells("DienTich").Value.ToString()
                strDiaChi = datagridTNMTChuyen.Rows(i).Cells("DiaChi").Value.ToString()
                strThoiDiemTiepNhan = datagridTNMTChuyen.Rows(i).Cells("NgayNhanChuyenLen").Value.ToString()
                If datagridTNMTChuyen.Rows(i).Cells("DuDieuKien").Value.ToString() = "True" Then
                    strDieuKien = "1"
                Else
                    strDieuKien = "0"
                End If
                strLyDoKhongDuDK = datagridTNMTChuyen.Rows(i).Cells("LyDoKhongDuDK").Value.ToString()


                ' truyền biến và insert vào bên bảng VPThamDinh
                InsertUBThamDinh()
                UpdatePhongTNMT()
                InsertLuanChuyenTheoDoi()
            End If
        Next
        ' load lại grid của tiếp nhận
        datagridTNMTChuyen.ClearSelection()
        strNgayTimKiem = ""
        ShowDataTNMTTiepNhan()
        'MsgBox("Có " + S.ToString + " dòng được check" + vbLf + kq)
    End Sub

    Private Sub cmdBCTNChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBCTNChuyen.Click
        Dim cls As New ClsLuanChuyen
        cls.Connection = strConnection
        cls.MaDonViHanhChinh = strMaDonViHanhChinh
        cls.InBaoCaoHoSo("TNMT", dtpTNMT)
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

    Private Sub DataGridTheoDoi_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DataGridTheoDoi.ColumnWidthChanged
        If Not DataGridTheoDoi.DataSource Is Nothing Then
            CtrFilterGrid3.TaoContol()
        End If
    End Sub

    Private Sub datagridTNMTChuyen_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles datagridTNMTChuyen.ColumnWidthChanged
        If Not datagridTNMTChuyen.DataSource Is Nothing Then
            CtrFilterGridPhongTNNHan.TaoContol()
        End If
    End Sub

    Private Sub DataGridTNMTNhanChuyenVe_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DataGridTNMTNhanChuyenVe.ColumnWidthChanged
        If Not DataGridTNMTNhanChuyenVe.DataSource Is Nothing Then
            CtrFilterGridPhongTNTra.TaoContol()
        End If
    End Sub
    Private Sub datagridTNMTChuyen_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles datagridTNMTChuyen.CellMouseClick
        Dim cls As New ClsLuanChuyen
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            cls.checkColumn(datagridTNMTChuyen, e.RowIndex, e.ColumnIndex)
        End If
        cls.LayThongTin(datagridTNMTChuyen, e.RowIndex, chkDuDieuKienTNMT, txtLyDoKhongDuDKTNMT)
    End Sub

    Private Sub DataGridTNMTNhanChuyenVe_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridTNMTNhanChuyenVe.CellMouseClick
        Dim cls As New ClsLuanChuyen
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            cls.checkColumn(DataGridTNMTNhanChuyenVe, e.RowIndex, e.ColumnIndex)
        End If
    End Sub
    Private Sub chkDuDieuKienTNMT_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDuDieuKienTNMT.CheckStateChanged
        Dim cls As New ClsLuanChuyen
        cls.UpdateThongTinCheck(datagridTNMTChuyen, datagridTNMTChuyen.CurrentRow.Index, chkDuDieuKienTNMT)
    End Sub
    Private Sub chkDataGridTNMTNhanChuyenVe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDataGridTNMTNhanChuyenVe.CheckedChanged
        Dim cls As New ClsLuanChuyen
        cls.CheckGrid(DataGridTNMTNhanChuyenVe, chkDataGridTNMTNhanChuyenVe)
    End Sub
End Class