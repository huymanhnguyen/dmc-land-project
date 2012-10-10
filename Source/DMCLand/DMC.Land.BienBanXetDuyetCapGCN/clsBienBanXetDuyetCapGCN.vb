Imports System.Data.SqlClient
Imports DMC.Database
Public Class clsBienBanXetDuyetCapGCN
    Private Para() As String = {"@MaHoSoCapGCN"}
    Private ParaDVHC() As String = {"@MaDVHC"}
    Private strMaHoSoCapGCN As String = ""
    Private strConnection As String = ""
    Private strMaDVHC As String = ""
    Private strServerName As String = ""
    Private strDatabase As String = ""
    Private strUID As String = ""
    Private strUpass As String = ""

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

    Public Property Connection()
        Get
            Return strConnection
        End Get
        Set(ByVal value)
            strConnection = value
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
    Public Function Select_Data(ByVal sp As String, ByVal Values() As String, ByVal paras() As String) As DataTable
        Dim strError As String = ""
        Dim MyTable As New DataTable
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            Dim conn As New SqlConnection
            If (Database.OpenConnection) Then
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (paras.Length <> Values.Length) Then
                    Return Nothing
                End If
                'Gọi phương thức GetValue của đối tượng clsDatabase
                Database.getValue(MyTable, sp, paras, Values)
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return MyTable
    End Function
    Public Function SelectDVHC() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDVHC}
            dt = Select_Data("spSelectHuyenTinh", Values, ParaDVHC)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectHoiDongXetDuyet() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = Select_Data("sp_SelectInHoiDongXetDuyet", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    Public Function SelectHoSoXetDuyet() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = Select_Data("sp_SelectHoSoKyThuatBienBanXetDuyet", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectTaiSanXetDuyet() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = Select_Data("sp_SelectTaiSanBienBanXetDuyet", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectBienBanXetDuyet() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = Select_Data("sp_InBienBanXetDuyetHoSoCapGCN", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectChuSuDung() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = Select_Data("sp_SelectInPhieuChuSuDung", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Sub KNReports(ByVal reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Try
            Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
            Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
            For Each tbCurrent In reportDocument.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = strServerName
                    .DatabaseName = strDatabase
                    .UserID = strUID
                    .Password = strUpass

                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try


    End Sub
End Class
