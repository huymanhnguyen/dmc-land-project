Imports System.Data.SqlClient
Public Class FrmBaoCao
    Private strMaHoSoCapGCN As String = ""
    Private conn As New SqlConnection
    Private strMaDVHC As String = ""
    Private strConnection As String = ""
    Private DTChinh As New DataTable
    Private DTDuDK As New DataTable
    Private DTKhongDuDK As New DataTable
    Private strFileReport As String = ""
    Public Property FileReport() As String
        Get
            Return strFileReport
        End Get
        Set(ByVal value As String)
            strFileReport = value
        End Set
    End Property

    Public Property DBDTDuDK() As DataTable
        Get
            Return DTDuDK
        End Get
        Set(ByVal value As DataTable)
            DTDuDK = value
        End Set
    End Property
    Public Property DBDTKhongDuDK() As DataTable
        Get
            Return DTKhongDuDK
        End Get
        Set(ByVal value As DataTable)
            DTKhongDuDK = value
        End Set
    End Property

    Public Property DB() As DataTable
        Get
            Return DTChinh
        End Get
        Set(ByVal value As DataTable)
            DTChinh = value
        End Set
    End Property
    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

    Public Sub LoadReport()

        reportDocument1.FileName = strFileReport
        reportDocument1.SetDataSource(DTChinh)
        reportDocument1.Subreports("subDanhSachHoSoDuDK").SetDataSource(DTDuDK)
        reportDocument1.Subreports("subDanhSachHoSoKhongDuDieuKien").SetDataSource(DTKhongDuDK)
        CrystalReportViewer1.ReportSource = reportDocument1
    End Sub
End Class