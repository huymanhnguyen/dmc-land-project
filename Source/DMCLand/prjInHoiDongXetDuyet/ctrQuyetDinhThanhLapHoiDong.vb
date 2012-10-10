Imports System.Data.SqlClient
Public Class ctrQuyetDinhThanhLapHoiDong
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

        file = Application.StartupPath & "\Reports\HoiDongXetDuyet\rptQuyetDinhThanhLapHDXD.rpt"
        Return file
    End Function

   

    Public Sub ctrBienbanXetDuyetHoSoCapGCN_Load()
        Dim cls As New clsBaoCaoHDXD
        cls.Connection = strConnection
        cls.MaHoSoCapGCN = strMaHoSoCapGCN
        Dim DVHC() As String = DonViHanhChinh()
        reportDocument1.FileName = fileReport()
        'cls.KNReports(reportDocument1)
        Dim dt As New DataTable
        dt = cls.SelectHoiDongXetDuyet()
        Dim OngBa As String = "Ông(bà):"
        Try
            If dt.Rows.Count > 0 Then
                dt.Columns.Add("OngBa")
                dt.Columns.Add("TenXa")
                dt.Columns.Add("TenXaHoa")
                dt.Columns.Add("TenXaDayDuThuong")
                dt.Columns.Add("TenXaDayDuHoa")
                dt.Columns.Add("NguoiDeDinh")
                dt.Columns.Add("ChucVuNguoiDeDinh")
                dt.Columns.Add("NgayThang")
                dt.Columns.Add("SoQuyetDinh")
                dt.Rows(0).Item("TenXa") = DVHC(0)
                dt.Rows(0).Item("TenXaHoa") = DVHC(0).ToUpper()
                dt.Rows(0).Item("TenXaDayDuThuong") = DVHC(0) & "," & DVHC(1) & "," & DVHC(2)
                dt.Rows(0).Item("TenXaDayDuHoa") = DVHC(0) & "," & DVHC(1) & "," & DVHC(2).ToUpper
                dt.Rows(0).Item("NguoiDeDinh") = ""
                dt.Rows(0).Item("ChucVuNguoiDeDinh") = ""
                dt.Rows(0).Item("NgayThang") = DVHC(0) & "," & "ngày " & Now.Day & " tháng " & Now.Month & " năm " & Now.Year
                dt.Rows(0).Item("SoQuyetDinh") = "/QĐ - UBND"
                For i As Int16 = 0 To dt.Rows.Count - 1
                    dt.Rows(i).Item("OngBa") = OngBa
                Next
                reportDocument1.SetDataSource(dt)
                CrystalReportViewer1.ReportSource = reportDocument1
            Else
                reportDocument1.SetDataSource(dt)
                CrystalReportViewer1.ReportSource = reportDocument1
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi hiển thị báo cáo: " & ex.Message)
        End Try
        
    End Sub

    Private Sub ctrQuyetDinhThanhLapHoiDong_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  ctrBienbanXetDuyetHoSoCapGCN_Load()
    End Sub
End Class
