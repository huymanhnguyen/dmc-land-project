Imports System.Data.SqlClient
Public Class ctrBienBanXetDuyetHoSoCapGCN
    Private strMaHoSoCapGCN As String = ""
    Private conn As SqlConnection
    Private strMaDVHC As String = ""
    Private strConnection As String = ""

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
    'lay thong tin ve phuong, quan, thanh pho
    Public Function DonViHanhChinh() As String()
        Dim cls As New clsBienBanXetDuyetCapGCN
        cls.Connection = strConnection
        cls.MaDVHC = strMaDVHC
        Dim dtDVHC As New DataTable
        dtDVHC = cls.SelectDVHC
        Dim arrMangGiaTriDVHC(3) As String
        If dtDVHC.Rows.Count > 0 Then
            arrMangGiaTriDVHC(0) = dtDVHC.Rows(0).Item("Ten")
            arrMangGiaTriDVHC(1) = dtDVHC.Rows(0).Item("TenHuyen")
            arrMangGiaTriDVHC(2) = dtDVHC.Rows(0).Item("TenTinh")
        End If
        Return arrMangGiaTriDVHC
    End Function
    Public Function fileReport() As String
        Dim ViTri As Short
        Dim path As String
        ViTri = InStr(4, Application.ExecutablePath, "\", CompareMethod.Binary)
        path = Application.ExecutablePath.Substring(0, ViTri) & Application.ProductName
        Dim file As String = ""
        file = Application.StartupPath & "\Reports\HoiDongXetDuyet\rptBienBanXetDuyetHoSoCapGCN.rpt"
        Return file
    End Function


    'laychu su dung
    Public Function GetChuSuDung() As String
        Dim strChu As String = ""
        Dim cls As New clsBienBanXetDuyetCapGCN
        cls.Connection = strConnection
        cls.MaHoSoCapGCN = strMaHoSoCapGCN
        Dim dt As New DataTable
        dt = cls.SelectChuSuDung
        Dim m As Int16 = 0
        MaDVHC = dt.Rows.Count
        If dt.Rows.Count > 0 Then
            m = dt.Rows.Count - 1
            Dim kt As Boolean = True
            For i As Int16 = 0 To m
                If (dt.Rows(i).Item("nhom") <> 0) Then
                    kt = False
                    GoTo nhan
                End If
            Next
nhan:
            If kt Then
                For i As Int16 = 0 To m
                    strChu = strChu & "Ông (bà)" & dt.Rows(i).Item("HoTen") & vbTab & vbTab & vbTab & vbTab & " Năm sinh:" & dt.Rows(i).Item("NamSinh") & vbTab & vbTab & vbTab & vbTab & " CMT(HC): " & dt.Rows(i).Item("SoDinhDanh") & vbTab & vbTab & vbTab & vbTab & "Ngày cấp: " & dt.Rows(i).Item("NgayCap") & vbTab & vbTab & vbTab & vbTab & "Nơi cấp: " & dt.Rows(i).Item("NoiCap") & vbTab & vbTab & vbTab & vbNewLine
                Next
            Else
                For i As Int16 = 0 To m
                    If dt.Rows(i).Item("nhom") = 0 Then
                        strChu = strChu & "Ông (bà)" & dt.Rows(i).Item("HoTen") & vbTab & vbTab & vbTab & vbTab & " Năm sinh:" & dt.Rows(i).Item("NamSinh") & vbTab & vbTab & vbTab & vbTab & " CMT(HC): " & dt.Rows(i).Item("SoDinhDanh") & vbTab & vbTab & vbTab & vbTab & "Ngày cấp: " & dt.Rows(i).Item("NgayCap") & vbTab & vbTab & vbTab & vbTab & "Nơi cấp: " & dt.Rows(i).Item("NoiCap") & vbTab & vbTab & vbTab & vbNewLine
                    Else
                        If dt.Rows(i).Item("nhom") = 1 Then
                            strChu = strChu & dt.Rows(i).Item("HoTen") & vbTab & vbTab & vbTab & vbTab & " Số đăng ký: " & dt.Rows(i).Item("SoDinhDanh") & vbTab & vbTab & vbTab & vbTab & "Ngày cấp: " & dt.Rows(i).Item("NgayCap") & vbTab & vbTab & vbTab & vbTab & "Nơi cấp: " & dt.Rows(i).Item("NoiCap") & vbTab & vbTab & vbTab & vbNewLine
                        Else
                            strChu = strChu & dt.Rows(i).Item("HoTen") & vbTab & vbTab & vbTab & vbTab
                        End If
                    End If
                Next
            End If
        End If

        Return strChu
    End Function
    Public Sub ctrBienbanXetDuyetHoSoCapGCN_Load()
        reportDocument1.FileName = fileReport()

        Dim cls As New clsBienBanXetDuyetCapGCN
        cls.Connection = strConnection
        cls.MaHoSoCapGCN = strMaHoSoCapGCN
        Dim DVHC() As String = DonViHanhChinh()
        Dim dt As New DataTable
        Dim dtHoiDong As New DataTable
        Dim dtTaiSan As New DataTable
        Dim dtHoSo As New DataTable
        dtHoSo = cls.SelectHoSoXetDuyet
        dt = cls.SelectBienBanXetDuyet()
        dtHoiDong = cls.SelectHoiDongXetDuyet
        Try
            If dt.Rows.Count > 0 Then
                Dim OngBa As String = "Ông(bà):"

                dt.Columns.Add("TenPhuong")
                dt.Columns.Add("TenPhuongHoa")
                dt.Columns.Add("TenXaDayDuThuong")
                dt.Columns.Add("TenXaDayDuHoa")
                dt.Columns.Add("HoTenCSD")
                dt.Columns.Add("NgayHeThong")
                dt.Rows(0).Item("TenPhuong") = DVHC(0)
                dt.Rows(0).Item("TenPhuongHoa") = DVHC(0).ToUpper
                dt.Rows(0).Item("TenXaDayDuThuong") = DVHC(0) & "," & DVHC(1) & "," & DVHC(2)
                dt.Rows(0).Item("TenXaDayDuHoa") = DVHC(0) & "," & DVHC(1) & "," & DVHC(2).ToUpper
                dt.Rows(0).Item("HoTenCSD") = GetChuSuDung()
                dt.Rows(0).Item("NgayHeThong") = "Vào hồi ... giờ ... ngày ... tháng ... năm " & Now.Year

                dtHoiDong.Columns.Add("OngBa")
                For i As Int16 = 0 To dtHoiDong.Rows.Count - 1
                    dtHoiDong.Rows(i).Item("OngBa") = OngBa
                Next

                reportDocument1.Subreports.Item("HoDongXetDuyet").SetDataSource(dtHoiDong)
                'reportDocument1.Subreports.Item("TaiSan").SetDataSource(dtTaiSan)
                ' reportDocument1.Subreports.Item("HoSoThuaDat").SetDataSource(dtHoSo)
                reportDocument1.SetDataSource(dt)
                CrystalReportViewer1.ReportSource = reportDocument1
            Else
                reportDocument1.SetDataSource(dt)
                CrystalReportViewer1.ReportSource = reportDocument1
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi hiển thị báo cáo: " & ex.ToString)
        End Try

    End Sub


End Class
