Public Class frmHoSoVPDK
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
    Private Sub frmDanhSachHoSoDaChuyenVeVPNhaDat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With Me.dtpVanPhong
            .CustomFormat = "dd/MM/yyyy"
            .Format = DateTimePickerFormat.Custom
            .ShowCheckBox = True
        End With

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        datagridvpnhan.ClearSelection()
        strNgayTimKiem = ""
        TimKiemVpNhaDatTiepNhan()
    End Sub
    ' ////////////////////////////////////////////////////////////////
    ' tìm kiếm hồ sơ ở văn phòng nhà đất đã được nhận từ 1 cửa chuyển lên
    '
    Public Sub TimKiemVpNhaDatTiepNhan()
        Try
            ShowDataVpNhaDatTiepNhan()
            If Not datagridvpnhan.DataSource Is Nothing Then
                With CtrFilterGridVpNhaDatNhan
                    .MyGrid = datagridvpnhan
                    .MydataTable = Nothing
                    .MydataTable = datagridvpnhan.DataSource
                    .TaoContol()
                End With
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Sub ShowDataVpNhaDatTiepNhan()
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .datagridvpnhan
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
            dtTimKiem = TimKiem.SelectHoSoVPNhaDatTiepNhan()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If

            Dim col As New DataColumn()
            col.ColumnName = "Chon"
            col.DataType = System.Type.GetType("System.Boolean")
            dtTimKiem.Columns.Add(col)

            'Trình bày dữ liệu lên Form
            Me.datagridvpnhan.DataSource = dtTimKiem


            With datagridvpnhan
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

    Private Sub cmdCapNhatVP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCapNhatVP.Click
        Dim cls As New ClsLuanChuyen 
        cls.Connection = strConnection
        cls.MaDonViHanhChinh = strMaDonViHanhChinh
        cls.CapNhatDieuKienHoSo("spUpdateDKLyDoVP", datagridvpnhan)
        ShowDataVpNhaDatTiepNhan()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        strTrangThai = "3"
        Me.datagridvpnhan.EndEdit()
        For i As Integer = 0 To datagridvpnhan.Rows.Count - 1
            If (Me.datagridvpnhan.Rows(i).Cells("Chon").Value.ToString = "True") Then
                ' lấy các giá trị các cột tại dòng i được chọn
                strMaHoSoCapGCN = datagridvpnhan.Rows(i).Cells("MaHoSoCapGCN").Value.ToString()
                strToBanDo = datagridvpnhan.Rows(i).Cells("ToBanDo").Value.ToString()
                strSoThua = datagridvpnhan.Rows(i).Cells("SoThua").Value.ToString()
                strDienTich = datagridvpnhan.Rows(i).Cells("DienTich").Value.ToString()
                strDiaChi = datagridvpnhan.Rows(i).Cells("DiaChi").Value.ToString()
                strThoiDiemTiepNhan = datagridvpnhan.Rows(i).Cells("NgayNhanChuyenLen").Value.ToString()
                If datagridvpnhan.Rows(i).Cells("DuDieuKien").Value.ToString() = "True" Then
                    strDieuKien = "1"
                Else
                    strDieuKien = "0"
                End If
                strLyDoKhongDuDK = datagridvpnhan.Rows(i).Cells("LyDoKhongDuDK").Value.ToString()


                ' truyền biến và insert vào bên bảng VPThamDinh
                InsertVPThamDinh()
                UpdateVPNhaDat()
                InsertLuanChuyenTheoDoi()
            End If
        Next
        ' load lại grid của tiếp nhận
        datagridvpnhan.ClearSelection()
        strNgayTimKiem = ""
        ShowDataVpNhaDatTiepNhan()
        'MsgBox("Có " + S.ToString + " dòng được check" + vbLf + kq)
    End Sub

    Public Sub InsertVPThamDinh()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim Insert As New ClsLuanChuyen
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .datagridvpnhan
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
            Insert.InsertVPThamDinh(str)

            strError = Insert.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub


    Public Sub UpdateVPNhaDat()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim Insert As New ClsLuanChuyen
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .datagridvpnhan
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
            Insert.UpdatVPNhaDat(str)

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

    Private Sub cmdBCVPChuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBCVPChuyen.Click
        Dim cls As New ClsLuanChuyen
        cls.Connection = strConnection
        cls.MaDonViHanhChinh = strMaDonViHanhChinh
        cls.InBaoCaoHoSo("VP", dtpVanPhong)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        DaTagridVpNhaDatNhanLai.ClearSelection()
        strNgayTimKiem = ""
        TimKiemVpNhaDatDaNhanLai()
    End Sub
    Public Sub TimKiemVpNhaDatDaNhanLai()
        Try
            ShowDataVpNhaDatDaNhanLai()
            If Not datagridvpnhan.DataSource Is Nothing Then
                With CtrFilterGridVpNhaDatTra
                    .MyGrid = DaTagridVpNhaDatNhanLai
                    .MydataTable = Nothing
                    .MydataTable = DaTagridVpNhaDatNhanLai.DataSource
                    .TaoContol()
                End With
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Sub TimKiemHoSoVPNhaDatChuyenLenThamDinh()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        
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
                datagridHoSoDaChuyenVeVPNhaDat.DataSource = dtTimKiem
                cls.ChangeTile(datagridHoSoDaChuyenVeVPNhaDat)
            ElseIf dtTimKiem.Rows.Count = 0 Then
                datagridHoSoDaChuyenVeVPNhaDat.DataSource = dtTimKiem
                cls.ChangeTile(datagridHoSoDaChuyenVeVPNhaDat)
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    ' ////////////////////////////////////////////////////////////////
    ' tìm kiếm hồ sơ ở văn phòng nhà đất đã được nhận từ 1 cửa chuyển lên
    '

    Public Sub ShowDataVpNhaDatDaNhanLai()
        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim TimKiem As New ClsTimKiem
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .DaTagridVpNhaDatNhanLai
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
            dtTimKiem = TimKiem.SelectHoSoVPNhaDatDaNhanLai()
            'Kiểm tra tính hợp lệ của dữ liệu
            If dtTimKiem Is Nothing Then
                Return
            End If

            Dim col As New DataColumn()
            col.ColumnName = "Chon"
            col.DataType = System.Type.GetType("System.Boolean")
            dtTimKiem.Columns.Add(col)

            'Trình bày dữ liệu lên Form
            Me.DaTagridVpNhaDatNhanLai.DataSource = dtTimKiem

            With DaTagridVpNhaDatNhanLai
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        strTrangThai = "8"
        Me.DaTagridVpNhaDatNhanLai.EndEdit()
        For i As Integer = 0 To DaTagridVpNhaDatNhanLai.Rows.Count - 1
            If (Me.DaTagridVpNhaDatNhanLai.Rows(i).Cells("Chon").Value.ToString = "True") Then
                ' lấy các giá trị các cột tại dòng i được chọn
                strMaHoSoCapGCN = DaTagridVpNhaDatNhanLai.Rows(i).Cells("MaHoSoCapGCN").Value.ToString()
                strToBanDo = DaTagridVpNhaDatNhanLai.Rows(i).Cells("ToBanDo").Value.ToString()
                strSoThua = DaTagridVpNhaDatNhanLai.Rows(i).Cells("SoThua").Value.ToString()
                strDienTich = DaTagridVpNhaDatNhanLai.Rows(i).Cells("DienTich").Value.ToString()
                strDiaChi = DaTagridVpNhaDatNhanLai.Rows(i).Cells("DiaChi").Value.ToString()
                strThoiDiemTiepNhan = DaTagridVpNhaDatNhanLai.Rows(i).Cells("NgayNhanChuyenVe").Value.ToString()
                If DaTagridVpNhaDatNhanLai.Rows(i).Cells("DuDieuKien").Value.ToString() = "True" Then
                    strDieuKien = "1"
                Else
                    strDieuKien = "0"
                End If

                strLyDoKhongDuDK = DaTagridVpNhaDatNhanLai.Rows(i).Cells("LyDoKhongDuDK").Value.ToString()


                ' truyền biến và insert vào bên bảng VPThamDinh
                InsertLaiNoiTiepNhan()
                UpdateVpNhaDatLan2()
                InsertLuanChuyenTheoDoi()
            End If
        Next
        ' load lại grid của tiếp nhận
        DaTagridVpNhaDatNhanLai.ClearSelection()
        strNgayTimKiem = ""
        ShowDataVpNhaDatDaNhanLai()
        'MsgBox("Có " + S.ToString + " dòng được check" + vbLf + kq)
    End Sub
    Public Sub InsertLaiNoiTiepNhan()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim Insert As New ClsLuanChuyen
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()
            With .DaTagridVpNhaDatNhanLai
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
            Insert.InsertLaiNoiTiepNhan(str)

            strError = Insert.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Sub UpdateVpNhaDatLan2()

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim Insert As New ClsLuanChuyen
        dtTimKiem = New DataTable
        With Me
            'Lam sach du lieu
            .dtTimKiem.Clear()

            With .DaTagridVpNhaDatNhanLai
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
            Insert.UpdatVPNhaDatLan2(str)

            strError = Insert.Err
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

 

    Private Sub chkDuDieuKienVP_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDuDieuKienVP.CheckStateChanged
        Dim cls As New ClsLuanChuyen
        cls.UpdateThongTinCheck(datagridvpnhan, datagridvpnhan.CurrentRow.Index, chkDuDieuKienVP)
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

    Private Sub datagridvpnhan_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles datagridvpnhan.ColumnWidthChanged
        If Not datagridvpnhan.DataSource Is Nothing Then
            CtrFilterGridVpNhaDatNhan.TaoContol()
        End If
    End Sub

    Private Sub DaTagridVpNhaDatNhanLai_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DaTagridVpNhaDatNhanLai.ColumnWidthChanged
        If Not DaTagridVpNhaDatNhanLai.DataSource Is Nothing Then
            CtrFilterGridVpNhaDatTra.TaoContol()
        End If
    End Sub

    Private Sub DataGridTheoDoi_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DataGridTheoDoi.ColumnWidthChanged
        If Not DataGridTheoDoi.DataSource Is Nothing Then
            CtrFilterGrid1.TaoContol()
        End If
    End Sub
    Private Sub datagridvpnhan_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles datagridvpnhan.CellMouseClick
        Dim cls As New ClsLuanChuyen
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            cls.checkColumn(datagridvpnhan, e.RowIndex, e.ColumnIndex)
        End If
        cls.LayThongTin(datagridvpnhan, e.RowIndex, chkDuDieuKienVP, txtLyDoKHongDuDKVP)
    End Sub
    Private Sub chkDaTagridVpNhaDatNhanLai_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDaTagridVpNhaDatNhanLai.CheckedChanged
        Dim cls As New ClsLuanChuyen
        cls.CheckGrid(DaTagridVpNhaDatNhanLai, chkDaTagridVpNhaDatNhanLai)
    End Sub

  

    Private Sub chkdatagridvpnhan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdatagridvpnhan.CheckedChanged
        Dim cls As New ClsLuanChuyen
        cls.CheckGrid(datagridvpnhan, chkdatagridvpnhan)
    End Sub
 

    Private Sub txtLyDoKHongDuDKVP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLyDoKHongDuDKVP.KeyDown
        If e.KeyValue = 13 Then
            Dim cls As New ClsLuanChuyen
            cls.UpdateThongTinLyDo(datagridvpnhan, datagridvpnhan.CurrentRow.Index, chkDuDieuKienVP, txtLyDoKHongDuDKVP)
        End If
    End Sub

End Class