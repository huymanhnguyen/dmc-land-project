Imports System.Data.SqlClient
Public Class ctrInToTrinh
    Private dtInPhieu As DataTable
    Private strError As String = ""
    Private conn As SqlConnection
    Private strMaDVHC As String = "" '"100241"
    Private strConnection As String = "" '"Server=DMC-SVR\MAP;Database=georgetown;User ID=sa;Password=1"
    Private strMaHoSoCapGCN As String = ""
    Private index As Int16 = 0
    Private arrMaHoSoCapGCN() As String = {}
    Dim app As New Object
    Private strSoToTrinh As String = ""
    Private strNgayTrinhPhuong As String = ""
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Public Property MaDVHC() As String
        Get
            Return strMaDVHC
        End Get
        Set(ByVal value As String)
            strMaDVHC = value
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
    Public Property SoToTrinh() As String
        Get
            Return strSoToTrinh
        End Get
        Set(ByVal value As String)
            strSoToTrinh = value
        End Set
    End Property
    Public Property NgayTrinhPhuong() As String
        Get
            Return strNgayTrinhPhuong
        End Get
        Set(ByVal value As String)
            strNgayTrinhPhuong = value
        End Set
    End Property
   

    Public Function TongHopChuSuDung(ByVal MaHoSoCapGCN As String) As String
        Dim strChuSuDung As String = ""
        Dim clsInToTrinhCSD As New clsInToTrinh
        Dim dtInPhieuCSD As New DataTable
        With Me
            'Lam sach du lieu
            dtInPhieuCSD.Clear()
            .strMaHoSoCapGCN = ""
        End With

        With clsInToTrinhCSD
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaHoSoCapGCN = MaHoSoCapGCN
        End With
        Try
            'Goi phuong thuc GetData de khoi tao doi tuong clsTimKiem
            dtInPhieuCSD = clsInToTrinhCSD.SelectChuSuDung()
            If dtInPhieuCSD.Rows.Count > 0 Then
                For i As Int16 = 0 To dtInPhieuCSD.Rows.Count - 1
                    strChuSuDung = strChuSuDung & dtInPhieuCSD.Rows(i).Item("HoTen") & ","
                Next
                strChuSuDung = strChuSuDung.Substring(0, strChuSuDung.Length - 1)
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return strChuSuDung
    End Function

    Public Sub LoadGrid(ByVal dt As DataTable, ByVal ChuSuDung As String)

        Dim dr As New DataGridViewRow()
        grdChonIn.Rows.Add(dr)
        Dim i As Int16 = 0
        i = grdChonIn.Rows.Count - 1
        If Not IsDBNull(dt.Rows(0).Item("ToBanDo")) Then
            grdChonIn.Rows(i).Cells(0).Value = dt.Rows(0).Item("ToBanDo")
        End If
        If Not IsDBNull(dt.Rows(0).Item("SoThua")) Then
            grdChonIn.Rows(i).Cells(1).Value = dt.Rows(0).Item("SoThua")
        End If
        If Not IsDBNull(dt.Rows(0).Item("DienTichTuNhien")) Then
            grdChonIn.Rows(i).Cells(2).Value = dt.Rows(0).Item("DienTichTuNhien")
        End If
        If Not IsDBNull(dt.Rows(0).Item("DiaChiThua")) Then
            grdChonIn.Rows(i).Cells(3).Value = dt.Rows(0).Item("DiaChiThua")
        End If
        If Not IsDBNull(dt.Rows(0).Item("NgayLapToTrinh")) Then
            grdChonIn.Rows(i).Cells(4).Value = dt.Rows(0).Item("NgayLapToTrinh")
        End If
        If Not IsDBNull(dt.Rows(0).Item("NgayQuyetDinhCapGCN")) Then
            grdChonIn.Rows(i).Cells(5).Value = dt.Rows(0).Item("NgayQuyetDinhCapGCN")
        End If
        grdChonIn.Rows(i).Cells(6).Value = ChuSuDung
        grdChonIn.Rows(i).Cells(7).Value = dt.Rows(0).Item("MaHoSoCapGCN")

    End Sub

    Public Sub AddColumns()
        Dim txtClnToBanDo As New DataGridViewTextBoxColumn
        Dim txtClnSoThua As New DataGridViewTextBoxColumn
        Dim txtClnDienTich As New DataGridViewTextBoxColumn
        Dim txtClnDiaChiThua As New DataGridViewTextBoxColumn
        Dim txtClnNgayLapToTrinh As New DataGridViewTextBoxColumn
        Dim txtClnNgayQuyetDinhCapGCN As New DataGridViewTextBoxColumn
        Dim txtClnHoTen As New DataGridViewTextBoxColumn
        Dim txtClnMaHoSoCapGCN As New DataGridViewTextBoxColumn
        Dim txtClnToTrinh As New DataGridViewTextBoxColumn
        Dim txtClnNgayTrinh As New DataGridViewTextBoxColumn
        Try
            'Tờ bản đồ
            With txtClnToTrinh
                .HeaderText = "Số tờ trình"
                .Name = "SoToTrinhDiaChinh"
                .Width = 100
            End With
            With txtClnNgayLapToTrinh
                .HeaderText = "Ngày lập tờ trình"
                .Name = "NgayLapToTrinhDiaChinh"
                .Width = 150
            End With
            'Số hiệu thửa
            With txtClnNgayTrinh
                .HeaderText = "Ngày trình"
                .Name = "NgayTrinhDiaChinh"
                .Width = 100
            End With
            With txtClnToBanDo
                .HeaderText = "Tờ bản đồ"
                .Name = "ToBanDo"
                .Width = 100
            End With
            'Số hiệu thửa
            With txtClnSoThua
                .HeaderText = "Số thửa"
                .Name = "SoThua"
                .Width = 100
            End With
            'Dien tich thửa đất
            With txtClnDienTich
                .HeaderText = "Diện tích"
                .Name = "DienTich"
                .Width = 100
            End With
            'Địa chỉ thửa
            With txtClnDiaChiThua
                .HeaderText = "Địa chỉ đất"
                .Name = "DiaChiThua"
                .Width = 400
            End With
            'Địa chỉ thửa
            

            With txtClnNgayQuyetDinhCapGCN
                .HeaderText = "Năm cấp GCN"
                .Name = "NgayQuyetDinhCapGCN"
                .Width = 150
            End With
            With txtClnHoTen
                .HeaderText = "Chủ sử dụng"
                .Name = "HoTen"
                .Width = 300
            End With
            With txtClnMaHoSoCapGCN
                .HeaderText = ""
                .Name = "MaHoSoCapGCN"
                .Width = 100
            End With
            'Add all to DataGridView
            With Me.grdChonIn
                .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'Add Columns
                With .Columns
                    .Add(txtClnToTrinh)
                    .Add(txtClnNgayLapToTrinh)
                    .Add(txtClnNgayTrinh)
                    .Add(txtClnToBanDo)
                    .Add(txtClnSoThua)
                    .Add(txtClnDienTich)
                    .Add(txtClnDiaChiThua)
                    .Add(txtClnNgayQuyetDinhCapGCN)
                    .Add(txtClnHoTen)
                    .Add(txtClnMaHoSoCapGCN)

                End With
                .Columns("MaHoSoCapGCN").Visible = False
                'Không cho phép thêm
                .AllowUserToAddRows = False
                'Không cho phép xóa
                .AllowUserToDeleteRows = False
                'Không lựa chọn bất kỳ dòng nào
                .ClearSelection()
            End With
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Tìm kiếm" + vbNewLine + " Lỗi: " & vbNewLine & strError, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub

    Private Sub grdChonIn_RowStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles grdChonIn.RowStateChanged
        index = e.Row.Index
    End Sub

    Public Function DuongDanFile() As String
        Dim sFileName As String = ""

        If Now.Day() < 10 Then
            sFileName += "0" & CStr(Now.Day())
        Else
            sFileName += CStr(Now.Day())
        End If


        If Now.Month() < 10 Then
            sFileName += "0" & CStr(Now.Month())
        Else
            sFileName += CStr(Now.Month())
        End If

        sFileName += CStr(Now.Year())

        If Now.Hour() < 10 Then
            sFileName += "0" & CStr(Now.Hour())
        Else
            sFileName += CStr(Now.Hour())
        End If

        If Now.Minute() < 10 Then
            sFileName += "0" & CStr(Now.Minute())
        Else
            sFileName += CStr(Now.Minute())
        End If

        If Now.Millisecond() < 10 Then
            sFileName += "0" & CStr(Now.Second())

        Else
            sFileName += CStr(Now.Second())
        End If

        Return sFileName
    End Function
    Public Sub InPhieuQuyetDinh()
        Dim cls As New clsInToTrinh
        Try
            app = CreateObject("Excel.Application")
        Catch ex As Exception
            app = Nothing
            MsgBox("Hãy cài đặt Excell", MsgBoxStyle.Critical, "DMCLand")
        End Try

        ' Try
        If MsgBox("Bạn có muốn lưu file?", MsgBoxStyle.YesNo, "In hồ sơ") = MsgBoxResult.Yes Then

            saveFile.Filter = "Excel 2007 Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls"
            saveFile.FileName = "HoSo" & DuongDanFile()
            saveFile.ShowDialog()

            cls.Connection = strConnection
            Dim strMangMaHoSoCapGCN As String = "'"
            For i As Int16 = 0 To grdChonIn.Rows.Count - 1
                strMangMaHoSoCapGCN = strMangMaHoSoCapGCN & grdChonIn.Rows(i).Cells("MaHoSoCapGCN").Value & "','"
            Next
            strMangMaHoSoCapGCN = strMangMaHoSoCapGCN.Substring(0, strMangMaHoSoCapGCN.Length - 2)

            cls.MaHoSoCapGCN = strMangMaHoSoCapGCN
            cls.MaDVHC = strMaDVHC
            Dim dt As New DataTable
            dt = cls.SelectGCN

            Dim dtDVHC As New DataTable
            dtDVHC = cls.SelectDVHC


            If saveFile.FileName <> "" Then
                cls.Config(app, "a4", "dung")
                Dim SoHoSo As Int16 = 0
                Dim arrMangGiaTriDVHC(3) As String
                If dtDVHC.Rows.Count > 0 Then
                    arrMangGiaTriDVHC(0) = dtDVHC.Rows(0).Item("Ten")
                    arrMangGiaTriDVHC(1) = dtDVHC.Rows(0).Item("TenHuyen")
                    arrMangGiaTriDVHC(2) = dtDVHC.Rows(0).Item("TenTinh")
                    cls.CauHinhTrangQuyetDinh(app, dt, arrMangGiaTriDVHC)
                End If

                ' ExpExSoCapGCN(app)
                LuuFile(app)
            End If
        End If
    End Sub
    Public Sub LuuFile(ByVal app As Object)

        With app
            If saveFile.FileName.ToString <> "" Then
                .ActiveCell.Worksheet.SaveAs(saveFile.FileName)
                .Workbooks.Open(saveFile.FileName)
                .Visible = True
            Else
                .ActiveCell.Worksheet.ClearArrows()
                .ActiveCell.Worksheet.ClearCircles()
                .ActiveCell.Worksheet.Delete()
            End If
        End With

        app = Nothing

    End Sub
    Public Sub InPhieuHoSo()

    End Sub


    Private Sub cmdInHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInHoSo.Click
        InPhieuQuyetDinh()
    End Sub

    'in quyet dinh
    Private Sub cmdInQuyetDinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInQuyetDinh.Click
        If txtToTrinhSo.Text = "" Then
            MessageBox.Show("Nhập thông tin tờ trình!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If dtpNgayTrinhDiaChinh.Checked = False Then
            MessageBox.Show("Nhập ngày trình!", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim strMangMaHoSoCapGCN As String = "'"
        For i As Int16 = 0 To grdChonIn.Rows.Count - 1
            strMangMaHoSoCapGCN = strMangMaHoSoCapGCN & grdChonIn.Rows(i).Cells("MaHoSoCapGCN").Value & "','"
        Next
        strMangMaHoSoCapGCN = strMangMaHoSoCapGCN.Substring(0, strMangMaHoSoCapGCN.Length - 2)
        Dim cls As New clsInToTrinh
        cls.Connection = strConnection
        cls.MaDVHC = strMaDVHC
        cls.MaHoSoCapGCN = strMangMaHoSoCapGCN
        Dim dtDVHC As New DataTable
        dtDVHC = cls.SelectDVHC
        Dim dtNghiavuTaiChinh As New DataTable
        dtNghiavuTaiChinh = cls.SelectGroupNghiaVuTaiChinh

        Dim arrMangGiaTriDVHC(3) As String
        If dtDVHC.Rows.Count > 0 Then
            arrMangGiaTriDVHC(0) = dtDVHC.Rows(0).Item("Ten")
            arrMangGiaTriDVHC(1) = dtDVHC.Rows(0).Item("TenHuyen")
            arrMangGiaTriDVHC(2) = dtDVHC.Rows(0).Item("TenTinh")
            InQuyetDinh(arrMangGiaTriDVHC, dtNghiavuTaiChinh)
        End If
    End Sub
    'chuc nang in quyet dinh cap giay chung nhan
    Public Sub InQuyetDinh(ByVal dtDVHC() As String, ByVal dtNVTC As DataTable)
        Dim cls As New clsInToTrinh
        If (grdChonIn.Rows.Count > 0) Then
            Try
                app = CreateObject("Excel.Application")
            Catch ex As Exception
                app = Nothing
                MsgBox("Hãy cài đặt Excell", MsgBoxStyle.Critical, "DMCLand")
            End Try

            ' Try
            If MsgBox("Bạn có muốn lưu file?", MsgBoxStyle.YesNo, "In phiếu") = MsgBoxResult.Yes Then

                saveFile.Filter = "Excel 2007 Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls"
                saveFile.FileName = "QuyetDinh" & DuongDanFile()
                saveFile.ShowDialog()
                If saveFile.FileName <> "" Then
                    cls.Config(app, "a4", "dung")
                    Dim totrinh() As String = {txtToTrinhSo.Text, Format(dtpNgayTrinhDiaChinh.Value, "dd/MM/yyyy")}
                    cls.QuyetDinh(app, dtDVHC, dtNVTC, totrinh, grdChonIn.Rows.Count)
                    ' ExpExSoCapGCN(app)
                    LuuFile(app)
                End If
            End If
        Else
            MessageBox.Show("Chọn hồ sơ cần trình trước khi in !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    'tim kiem ho so theo to trinh va ngay trinh
    Private Sub cmdTimHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimHoSo.Click
        If (txtToTrinhSo.Text = "") And (dtpNgayTrinhDiaChinh.Checked = False) Then
            MessageBox.Show("Hãy nhập số tờ trình hoặc chọn ngày trình để in phiếu", "InToTrinh", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            'neu thong tin to trinh va ngay trinh da dc nhap
            Dim cls As New clsInToTrinh
            cls.Connection = strConnection
            cls.MaDVHC = strMaDVHC
            If (txtToTrinhSo.Text = "") Then
                cls.SoToTrinh = Nothing
            Else
                cls.SoToTrinh = txtToTrinhSo.Text
            End If

            If dtpNgayTrinhDiaChinh.Checked Then
                cls.NgayTrinhPhuong = dtpNgayTrinhDiaChinh.Value.Month & "/" & dtpNgayTrinhDiaChinh.Value.Day & "/" & dtpNgayTrinhDiaChinh.Value.Year
            Else
                cls.NgayTrinhPhuong = Nothing
            End If
            Dim dtHoSoTrinh As New DataTable
            dtHoSoTrinh = cls.SelectThongTinToTrinh
            If dtHoSoTrinh.Rows.Count > 0 Then
                LoadGrid(dtHoSoTrinh)
            Else
                grdChonIn.Rows.Clear()
            End If
        End If
    End Sub
    'load thong tin du lieu vao grid view
    Public Sub LoadGrid(ByVal dtTimKiem As DataTable)
        If dtTimKiem.Rows.Count > 0 Then
            grdChonIn.Rows.Clear()
            For i As Integer = 0 To dtTimKiem.Rows.Count - 1
                With Me.grdChonIn
                    .RowCount += 1
                    .Item("SoToTrinhDiaChinh", i).Value = dtTimKiem.Rows(i).Item("SoToTrinhDiaChinh").ToString
                    If dtTimKiem.Rows(i).Item("NgayLapToTrinhDiaChinh").ToString <> "" Then
                        .Item("NgayLapToTrinhDiaChinh", i).Value = FormatDateTime(dtTimKiem.Rows(i).Item("NgayLapToTrinhDiaChinh").ToString, DateFormat.ShortDate)
                    End If
                    If dtTimKiem.Rows(i).Item("NgayTrinhDiaChinh").ToString <> "" Then
                        .Item("NgayTrinhDiaChinh", i).Value = FormatDateTime(dtTimKiem.Rows(i).Item("NgayTrinhDiaChinh").ToString, DateFormat.ShortDate)
                    End If

                    .Item("ToBanDo", i).Value = dtTimKiem.Rows(i).Item("ToBanDo").ToString
                    .Item("SoThua", i).Value = dtTimKiem.Rows(i).Item("SoThua").ToString
                    .Item("DienTich", i).Value = dtTimKiem.Rows(i).Item("DienTich").ToString
                    .Item("DiaChiThua", i).Value = dtTimKiem.Rows(i).Item("DiaChi").ToString
                    If dtTimKiem.Rows(i).Item("NgayQuyetDinhCapGCN").ToString <> "" Then
                        .Item("NgayQuyetDinhCapGCN", i).Value = FormatDateTime(dtTimKiem.Rows(i).Item("NgayQuyetDinhCapGCN").ToString, DateFormat.ShortDate)
                    End If
                    Dim strChu As String = ""
                    strChu = TongHopChuSuDung(dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString)
                    .Item("HoTen", i).Value = strChu
                    .Item("MaHoSoCapGCN", i).Value = dtTimKiem.Rows(i).Item("MaHoSoCapGCN").ToString
                End With
            Next i
        End If
    End Sub

    Public Sub ctrInToTrinh_Load() '(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                With .dtpNgayTrinhDiaChinh
                    .CustomFormat = "dd/MM/yyyy"
                    .Format = DateTimePickerFormat.Custom
                    .ShowCheckBox = True
                    .Value = Now
                End With
            End With
            conn = New SqlConnection
            conn.ConnectionString = strConnection
            conn.Open()
            app = Nothing
            AddColumns()
            'With Me.CrtTimKiemHoSoThuaDat1
            '    .Connection = strConnection
            '    .MaDonViHanhChinh = strMaDVHC
            'End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
