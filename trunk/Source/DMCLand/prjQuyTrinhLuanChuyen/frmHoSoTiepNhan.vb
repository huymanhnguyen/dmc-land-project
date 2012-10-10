Public Class frmHoSoTiepNhan
    Private strNgayTimKiem As String = ""
    Private shortAction As Short = 0
    Private strError As String = ""
    Private strConnection As String = ""
    Private dtTimKiem As New DataTable
    Private strMaDonViHanhChinh As String = ""
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
    Private Sub frmDanhSachHoSoDaChuyenVeNoiTiepNhan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.dtpMotCua
            .CustomFormat = "dd/MM/yyyy"
            .Format = DateTimePickerFormat.Custom
            .ShowCheckBox = True
        End With

    End Sub

    Private Sub btnTim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTim.Click
        DataGridTiepNhan.ClearSelection()
        strNgayTimKiem = ""
        TimKiemTiepNhanTu1Cua()
    End Sub
    Public Sub TimKiemTiepNhanTu1Cua()
        Try
            ShowDataTiepNhanTu1Cua()
            If Not DataGridTheoDoi.DataSource Is Nothing Then
                With CtrFilterGrid1CuaNhan
                    .MyGrid = DataGridTiepNhan
                    .MydataTable = Nothing
                    .MydataTable = DataGridTiepNhan.DataSource
                    .TaoContol()
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ShowDataTiepNhanTu1Cua()
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .DataGridTiepNhan
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
            dtTimKiem = TimKiem.SelectHoSoMoiTiepNhan()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If

            Dim col As New DataColumn()
            col.ColumnName = "Chon"
            col.DataType = System.Type.GetType("System.Boolean")
            dtTimKiem.Columns.Add(col)

            'Trình bày dữ liệu lên Form
            Me.DataGridTiepNhan.DataSource = dtTimKiem

            With DataGridTiepNhan
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

                .Columns("ThoiDiemTiepNhan").HeaderText = "Ngày Nhận"
                .Columns("ThoiDiemTiepNhan").Width = 100
                .Columns("ThoiDiemTiepNhan").Visible = True

                .Columns("TenNguoiTiepNhan").HeaderText = "Người Nhận"
                .Columns("TenNguoiTiepNhan").Width = 100
                .Columns("TenNguoiTiepNhan").Visible = True

                .Columns("TenNguoiDiKeKhai").HeaderText = "Người Kê Khai"
                .Columns("TenNguoiDiKeKhai").Width = 100
                .Columns("TenNguoiDiKeKhai").Visible = True

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

    Private Sub tbnChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnChuyen.Click
        strTrangThai = "2"
        Me.DataGridTiepNhan.EndEdit()
        For i As Integer = 0 To DataGridTiepNhan.Rows.Count - 1
            If (Me.DataGridTiepNhan.Rows(i).Cells("Chon").Value.ToString = "True") Then
                ' lấy các giá trị các cột tại dòng i được chọn
                strMaHoSoCapGCN = DataGridTiepNhan.Rows(i).Cells("MaHoSoCapGCN").Value.ToString()
                strToBanDo = DataGridTiepNhan.Rows(i).Cells("ToBanDo").Value.ToString()
                strSoThua = DataGridTiepNhan.Rows(i).Cells("SoThua").Value.ToString()
                strDienTich = DataGridTiepNhan.Rows(i).Cells("DienTich").Value.ToString()
                strDiaChi = DataGridTiepNhan.Rows(i).Cells("DiaChi").Value.ToString()
                strThoiDiemTiepNhan = DataGridTiepNhan.Rows(i).Cells("ThoiDiemTiepNhan").Value.ToString()
                strTenNguoiTiepNhan = DataGridTiepNhan.Rows(i).Cells("TenNguoiTiepNhan").Value.ToString()
                strTenNguoiKeKhai = DataGridTiepNhan.Rows(i).Cells("TenNguoiDiKeKhai").Value.ToString()
                If DataGridTiepNhan.Rows(i).Cells("DuDieuKien").Value.ToString() = "True" Then
                    strDieuKien = "1"
                Else
                    strDieuKien = "0"
                End If
                strLyDoKhongDuDK = DataGridTiepNhan.Rows(i).Cells("LyDoKhongDuDK").Value.ToString()
                ' truyền biến và insert vào bên bảng VPNhaDat
                InsertVPNhaDat()
                InsertLuanChuyenTiepNhan()
                ' insert vào bảng tblLuanChuyenTheoDoi
                InsertLuanChuyenTheoDoi()
            End If
        Next
        ' load lại grid của tiếp nhận
        DataGridTiepNhan.ClearSelection()
        strNgayTimKiem = ""
        ShowDataTiepNhanTu1Cua()
    End Sub
    Public Sub InsertVPNhaDat()
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim Insert As New ClsLuanChuyen
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .DataGridTiepNhan
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
            .TenNguoiNhan = strTenNguoiTiepNhan
            .TenNguoiKeKhai = strTenNguoiKeKhai
            .DieuKien = strDieuKien
            .LyDoKhongDuDK = strLyDoKhongDuDK
        End With
        Try
            Dim str As String = ""
            Insert.InsertVPNhaDat(str)

            strError = Insert.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub InsertLuanChuyenTiepNhan()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim Insert As New ClsLuanChuyen
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .DataGridTiepNhan
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
            .TenNguoiNhan = strTenNguoiTiepNhan
            .TenNguoiKeKhai = strTenNguoiKeKhai
            .DieuKien = strDieuKien
            .LyDoKhongDuDK = strLyDoKhongDuDK
        End With
        Try
            Dim str As String = ""
            Insert.InsertLuanChuyenTiepNhan(str)

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
            With .DataGridTiepNhan
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

    Private Sub cmdBC1CuaChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBC1CuaChuyen.Click
        Dim cls As New ClsLuanChuyen
        cls.Connection = strConnection
        cls.MaDonViHanhChinh = strMaDonViHanhChinh
        cls.InBaoCaoHoSo("1Cua", dtpMotCua)
    End Sub

    Private Sub chkDuDK1Cua_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDuDK1Cua.CheckedChanged
        Dim cls As New ClsLuanChuyen
        cls.Connection = strConnection
        cls.UpdateThongTinCheck(DataGridTiepNhan, DataGridTiepNhan.CurrentRow.Index, chkDuDK1Cua)
    End Sub

 

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridHoSoNhanVe.ClearSelection()
        strNgayTimKiem = ""
        TimKiemHoSoNhanVe()
    End Sub
    Public Sub TimKiemHoSoNhanVe()
        Try
            ShowDataHoSoNhanVe()
            If Not DataGridHoSoNhanVe.DataSource Is Nothing Then
                With CtrFilterGrid1CuaTra
                    .MyGrid = DataGridHoSoNhanVe
                    .MydataTable = Nothing
                    .MydataTable = DataGridHoSoNhanVe.DataSource
                    .TaoContol()
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ShowDataHoSoNhanVe()
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .DataGridHoSoNhanVe
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
            dtTimKiem = TimKiem.SelectHoSoNhanVe()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If

            Dim col As New DataColumn()
            col.ColumnName = "Chon"
            col.DataType = System.Type.GetType("System.Boolean")
            dtTimKiem.Columns.Add(col)
            'Trình bày dữ liệu lên Form
            Me.DataGridHoSoNhanVe.DataSource = dtTimKiem


            With DataGridHoSoNhanVe
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

                .Columns("NgayNhanHoSoTraVe").HeaderText = "Ngày Nhận Hồ Sơ"
                .Columns("NgayNhanHoSoTraVe").Width = 150
                .Columns("NgayNhanHoSoTraVe").Visible = True

                .Columns("DaTra").HeaderText = "Hồ sơ hoàn thành"
                .Columns("DaTra").Width = 150
                .Columns("DaTra").Visible = True

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
    ''
    'Public Sub ShowDataTNMTNhanTraVe()
    '    'Khai bao va khoi tao doi tuong clsTimKiem
    '    Dim TimKiem As New ClsTimKiem
    '    dtTimKiem = New DataTable
    '    With Me
    '        'Lam sach du lieu
    '        .dtTimKiem.Clear()
    '        With .DataGridTNMTNhanChuyenVe
    '            .ClearSelection()
    '        End With
    '    End With
    '    'Kiem tra xem da chon don vi hanh chinh can tac nghiep chua
    '    If (strMaDonViHanhChinh.Trim = "") Or (strMaDonViHanhChinh = "0") Then
    '        MsgBox("Bạn chưa chọn đơn vị hành chính!", MsgBoxStyle.Information, "DMCLand")
    '        Exit Sub
    '    End If
    '    With TimKiem
    '        'Gán chuỗi kết nối Database cho clsTimKiem
    '        .Connection = strConnection
    '        .MaDonViHanhChinh = strMaDonViHanhChinh

    '    End With
    '    Try
    '        dtTimKiem = TimKiem.SelectHoSoPhongTNMTDaNhanTraVe()
    '        'Kiểm tra tính hợp lệ của dữ liệu
    '        If dtTimKiem Is Nothing Then
    '            Return
    '        End If

    '        Dim col As New DataColumn()
    '        col.ColumnName = "Chon"
    '        col.DataType = System.Type.GetType("System.Boolean")
    '        dtTimKiem.Columns.Add(col)
    '        'Trình bày dữ liệu lên Form
    '        Me.DataGridTNMTNhanChuyenVe.DataSource = dtTimKiem


    '        With DataGridTNMTNhanChuyenVe
    '            For i As Integer = 0 To .Columns.Count - 1
    '                .Columns(i).Visible = False
    '            Next

    '            .Columns("MaHoSoCapGCN").HeaderText = "Mã Hồ Sơ Cấp GCN"
    '            .Columns("MaHoSoCapGCN").Visible = False
    '            .Columns("ToBanDo").HeaderText = "Tờ Bản Đồ"
    '            .Columns("ToBanDo").Width = 100
    '            .Columns("ToBanDo").Visible = True

    '            .Columns("SoThua").HeaderText = "Số Thửa"
    '            .Columns("SoThua").Width = 100
    '            .Columns("SoThua").Visible = True

    '            .Columns("DiaChi").HeaderText = "Địa Chỉ"
    '            .Columns("DiaChi").Width = 300
    '            .Columns("DiaChi").Visible = True

    '            .Columns("DienTich").HeaderText = "Diện Tích"
    '            .Columns("DienTich").Width = 100
    '            .Columns("DienTich").Visible = True

    '            .Columns("NgayNhanChuyenVe").HeaderText = "Ngày Nhận Hồ Sơ"
    '            .Columns("NgayNhanChuyenVe").Width = 150
    '            .Columns("NgayNhanChuyenVe").Visible = True

    '            .Columns("DuDieuKien").HeaderText = "Có/Không đủ ĐK"
    '            .Columns("DuDieuKien").Width = 150
    '            .Columns("DuDieuKien").Visible = True

    '            .Columns("LyDoKhongDuDK").HeaderText = "Lý do không đủ ĐK"
    '            .Columns("LyDoKhongDuDK").Width = 200
    '            .Columns("LyDoKhongDuDK").Visible = True

    '            .Columns("DaXuLy").HeaderText = "HS xử lý/chưa xử lý"
    '            .Columns("DaXuLy").Width = 200
    '            .Columns("DaXuLy").Visible = True

    '            .Columns("SoLan").HeaderText = "Số lần xử lý"
    '            .Columns("SoLan").Width = 100
    '            .Columns("SoLan").Visible = True

    '            .Columns("Chon").HeaderText = "Chọn"
    '            .Columns("Chon").Width = 50
    '            .Columns("Chon").Visible = True
    '        End With
    '    Catch ex As Exception
    '        strError = ex.Message
    '        MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
    '    End Try
    'End Sub

 

    Private Sub cmdBC1CuaNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBC1CuaNhan.Click

    End Sub

    Private Sub cmdCapNhat1Cua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCapNhat1Cua.Click
        Dim cls As New ClsLuanChuyen
        cls.Connection = strConnection
        cls.MaDonViHanhChinh = strMaDonViHanhChinh
        cls.CapNhatDieuKienHoSo("spUpdateDKLyDo1Cua", DataGridTiepNhan)
        ShowDataTiepNhanTu1Cua()
    End Sub

    Private Sub txtLyDoKhongDuDK1Cua_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLyDoKhongDuDK1Cua.KeyDown
        If e.KeyValue = 13 Then
            Dim cls As New ClsLuanChuyen
            cls.UpdateThongTinLyDo(DataGridTiepNhan, DataGridTiepNhan.CurrentRow.Index, chkDuDK1Cua, txtLyDoKhongDuDK1Cua)
        End If
    End Sub
    Public Sub TimKiemHoSoDaChuyenVeVPNhaDat()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        Dim frm As New frmHoSoVPDK()
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
            dtTimKiem = TimKiem.SelectHoSoDaChuyenVeVPNhaDat()
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

    Private Sub DataGridHoSoNhanVe_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DataGridHoSoNhanVe.ColumnWidthChanged
        If Not DataGridHoSoNhanVe.DataSource Is Nothing Then
            CtrFilterGrid1CuaTra.TaoContol()
        End If
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
                With CtrFilterGrid1
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
 
    Private Sub DataGridTiepNhan_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DataGridTiepNhan.ColumnWidthChanged
        If Not DataGridTiepNhan.DataSource Is Nothing Then
            CtrFilterGrid1CuaNhan.TaoContol()
        End If
    End Sub

    Private Sub DataGridTheoDoi_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DataGridTheoDoi.ColumnWidthChanged
        If Not DataGridTheoDoi.DataSource Is Nothing Then
            CtrFilterGrid1.TaoContol()
        End If
    End Sub

    Private Sub DataGridTiepNhan_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridTiepNhan.CellMouseClick
        Dim cls As New ClsLuanChuyen
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            cls.checkColumn(DataGridTiepNhan, e.RowIndex, e.ColumnIndex)
        End If
        cls.LayThongTin(DataGridTiepNhan, e.RowIndex, chkDuDK1Cua, txtLyDoKhongDuDK1Cua)
    End Sub

    Private Sub DataGridHoSoNhanVe_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridHoSoNhanVe.CellMouseClick
        Dim cls As New ClsLuanChuyen
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            cls.checkColumn(DataGridHoSoNhanVe, e.RowIndex, e.ColumnIndex)
        End If
    End Sub
   
    Private Sub chkDataGridTiepNhan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDataGridTiepNhan.CheckedChanged
        Dim cls As New ClsLuanChuyen
        cls.CheckGrid(DataGridTiepNhan, chkDataGridTiepNhan)
    End Sub

    Private Sub chkDataGridHoSoNhanVe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDataGridHoSoNhanVe.CheckedChanged
        Dim cls As New ClsLuanChuyen
        cls.CheckGrid(DataGridHoSoNhanVe, chkDataGridHoSoNhanVe)
    End Sub
    Private Sub cmdHoanThanhQuyTrinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHoanThanhQuyTrinh.Click
        Dim cls As New ClsLuanChuyen
        cls.Connection = strConnection
        cls.MaDonViHanhChinh = strMaDonViHanhChinh
        For i As Integer = 0 To DataGridHoSoNhanVe.Rows.Count - 1
            If (Me.DataGridHoSoNhanVe.Rows(i).Cells("Chon").Value.ToString = "True") Then
                ' lấy các giá trị các cột tại dòng i được chọn
                cls.MaHoSoCapGCN = DataGridHoSoNhanVe.Rows(i).Cells("MaHoSoCapGCN").Value.ToString()
                cls.DaTraHS = DataGridHoSoNhanVe.Rows(i).Cells("Chon").Value.ToString()
                cls.UpHoSoHoanThanh()
            End If
        Next
        ShowDataTNMTNhanTraVe()
    End Sub
    ' tìm kiếm hồ sơ ở văn phòng nhà đất đã được nhận từ 1 cửa chuyển lên
    '
    Public Sub ShowDataTNMTNhanTraVe()
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .DataGridHoSoNhanVe
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
            dtTimKiem = TimKiem.SelectHoSoPhongTNMTDaNhanTraVe()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If

            Dim col As New DataColumn()
            col.ColumnName = "Chon"
            col.DataType = System.Type.GetType("System.Boolean")
            dtTimKiem.Columns.Add(col)
            'Trình bày dữ liệu lên Form
            Me.DataGridHoSoNhanVe.DataSource = dtTimKiem


            With DataGridHoSoNhanVe
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

                .Columns("NgayNhanChuyenVe").HeaderText = "Ngày Nhận Hồ Sơ"
                .Columns("NgayNhanChuyenVe").Width = 150
                .Columns("NgayNhanChuyenVe").Visible = True

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
End Class