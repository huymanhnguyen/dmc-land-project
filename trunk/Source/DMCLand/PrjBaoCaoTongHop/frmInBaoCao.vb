Imports System.Data.SqlClient

Public Class frmInBaoCao
    Private strMaHoSoCapGCN As String = ""
    Private conn As New SqlConnection
    Private strMaDVHC As String = ""
    Private strConnection As String = ""
    Private DTChinh As New DataTable
    Private strFileReport As String = ""

    Public Property FileReport() As String
        Get
            Return strFileReport
        End Get
        Set(ByVal value As String)
            strFileReport = value
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
        CrystalReportViewer1.ReportSource = reportDocument1
    End Sub

    Private Sub frmInBaoCao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class