Imports System.Data.SqlClient
Public Class ctrBienbanXetDuyetHoSoCapGCN

    Private strMaHoSoCapGCN As String = "120"
    Private conn As SqlConnection
    Private strMaDVHC As String = "113651"
    Private strConnection As String = "Data Source=dmcthanh;Initial Catalog=georgetown ;User ID=sa ;PassWord=1"
    Private strServerName As String = "dmcthanh"
    Private strDatabase As String = "georgetown"
    Private strUID As String = "sa"
    Private strUpass As String = "1"

    Public Property DatabaseName() As String
        Get
            Return strDatabase
        End Get
        Set(ByVal value As String)
            strDatabase = value
        End Set
    End Property
    Public Property ServerName() As String
        Get
            Return strServerName
        End Get
        Set(ByVal value As String)
            strServerName = value
        End Set
    End Property
    Public Property UID() As String
        Get
            Return strUID
        End Get
        Set(ByVal value As String)
            strUID = value
        End Set
    End Property
    Public Property UPass() As String
        Get
            Return strUpass
        End Get
        Set(ByVal value As String)
            strUpass = value
        End Set
    End Property
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
        Dim cls As New clsBaoCaoHDXD
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
        'file = Application.StartupPath & "\Reports\Reports_HDXD\rptBienBanXetDuyetCapGCN.rpt"""
        file = "E:\DMCLandRoot\DMCLand\prjLandRegistration\bin\Debug\Reports\Reports_HDXD\rptBienBanXetDuyetCapGCN.rpt"
        Return file
    End Function


    'laychu su dung
    Public Function GetChuSuDung() As String
        Dim strChu As String = ""
        Dim cls As New clsBaoCaoHDXD
        cls.Connection = strConnection
        cls.MaHoSoCapGCN = strMaHoSoCapGCN
        Dim dt As New DataTable
        dt = cls.SelectChuSuDung
        Dim m As Int16 = 0
        MaDVHC = dt.Rows.Count
        If dt.Rows.Count > 0 Then
         
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
                    strChu = strChu & "Ông (bà)" & dt.Rows(0).Item("HoTen") & vbTab & vbTab & vbTab & vbTab & " Năm sinh:" & dt.Rows(0).Item("NamSinh") & vbTab & vbTab & vbTab & vbTab & " CMT(HC): " & dt.Rows(0).Item("SoDinhDanh") & vbTab & vbTab & vbTab & vbTab & "Ngày cấp: " & dt.Rows(0).Item("NgayCap") & vbTab & vbTab & vbTab & vbTab & "Nơi cấp: " & dt.Rows(0).Item("NoiCap") & vbTab & vbTab & vbTab & vbTab
                Next
            Else
                For i As Int16 = 0 To m
                    If dt.Rows(i).Item("nhom") = 0 Then
                        strChu = strChu & "Ông (bà)" & dt.Rows(0).Item("HoTen") & vbTab & vbTab & vbTab & vbTab & " Năm sinh:" & dt.Rows(0).Item("NamSinh") & vbTab & vbTab & vbTab & vbTab & " CMT(HC): " & dt.Rows(0).Item("SoDinhDanh") & vbTab & vbTab & vbTab & vbTab & "Ngày cấp: " & dt.Rows(0).Item("NgayCap") & vbTab & vbTab & vbTab & vbTab & "Nơi cấp: " & dt.Rows(0).Item("NoiCap") & vbTab & vbTab & vbTab & vbTab
                    Else
                        If dt.Rows(i).Item("nhom") = 1 Then
                            strChu = strChu & dt.Rows(0).Item("HoTen") & vbTab & vbTab & vbTab & vbTab & " Số đăng ký: " & dt.Rows(0).Item("SoDinhDanh") & vbTab & vbTab & vbTab & vbTab & "Ngày cấp: " & dt.Rows(0).Item("NgayCap") & vbTab & vbTab & vbTab & vbTab & "Nơi cấp: " & dt.Rows(0).Item("NoiCap") & vbTab & vbTab & vbTab & vbTab
                        Else
                            strChu = strChu & dt.Rows(0).Item("HoTen") & vbTab & vbTab & vbTab & vbTab
                        End If
                    End If
                Next
            End If
        End If

        Return strChu
    End Function
    Public Sub ctrBienbanXetDuyetHoSoCapGCN_Load()
        Dim cls As New clsBaoCaoHDXD
        cls.Connection = strConnection
        cls.MaHoSoCapGCN = strMaHoSoCapGCN
        cls.DatabaseName = strDatabase
        cls.ServerName = strServerName
        cls.UID = strUID
        cls.UPass = strUpass
        Dim DVHC() As String = DonViHanhChinh()
        reportDocument1.FileName = fileReport()
        cls.KNReports(reportDocument1)
        Dim dt As New DataTable
        Dim dtHoiDong As New DataTable
        Dim dtTaiSan As New DataTable
        Dim dtHoSo As New DataTable
        dtHoSo = cls.SelectHoSoXetDuyet
        dt = cls.SelectBienBanXetDuyet()
        dtTaiSan = cls.SelectTaiSanXetDuyet()
        dtHoiDong = cls.SelectHoiDongXetDuyet
        If dt.Rows.Count > 0 Then
            Dim OngBa As String = "Ông(bà):"

            dt.Columns.Add("TenPhuong")
            dt.Columns.Add("TenXaDayDuThuong")
            dt.Columns.Add("TenXaDayDuHoa")
            dt.Columns.Add("HoTenCSD")
            dt.Columns.Add("NgayHeThong")
            dt.Rows(0).Item("TenPhuong") = DVHC(0)
            dt.Rows(0).Item("TenXaDayDuThuong") = DVHC(0) & "," & DVHC(1) & "," & DVHC(2)
            dt.Rows(0).Item("TenXaDayDuHoa") = DVHC(0) & "," & DVHC(1) & "," & DVHC(2).ToUpper
            dt.Rows(0).Item("HoTenCSD") = GetChuSuDung()
            dt.Rows(0).Item("NgayHeThong") = "ngày " & Now.Day & " tháng " & Now.Month & " năm " & Now.Year

            dtHoiDong.Columns.Add("OngBa")
            For i As Int16 = 0 To dtHoiDong.Rows.Count - 1
                dtHoiDong.Rows(i).Item("OngBa") = OngBa
            Next
            reportDocument1.Subreports.Item("HoiDongXetDuyet").SetDataSource(dtHoiDong)
            reportDocument1.Subreports.Item("TaiSan").SetDataSource(dtTaiSan)
            reportDocument1.Subreports.Item("HoSoThuaDat").SetDataSource(dtHoSo)
            reportDocument1.SetDataSource(dt)

            CrystalReportViewer1.ReportSource = reportDocument1

        Else
            MessageBox.Show("Không tồn tại bản ghi nào")
        End If
    End Sub

    Private Sub ctrBienbanXetDuyetHoSoCapGCN_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' ctrBienbanXetDuyetHoSoCapGCN_Load()
    End Sub
End Class
