Imports DMC.Database
Imports System.Data.SqlClient

Public Class clsListDatabases
    Dim Paras() As String = {}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien shFlag
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property

    Public Function ListDatabases() As DataTable
        Dim sqlCommand As New SqlCommand
        Dim sqlDataAdapter As New SqlDataAdapter
        Dim dsListDatabases As New DataSet
        Dim sqlConnecttion As New SqlConnection
        Dim dtListDatabases As New DataTable
        Try
            sqlConnecttion.ConnectionString = strConnection
            If (sqlConnecttion.State = ConnectionState.Closed) Then
                sqlConnecttion.Open()
            End If
            With sqlCommand
                .Connection = sqlConnecttion
                .CommandText = "select Name from sys.databases"
                .CommandType = CommandType.Text
            End With
            sqlDataAdapter.SelectCommand = sqlCommand
            sqlDataAdapter.Fill(dsListDatabases)
            dtListDatabases = dsListDatabases.Tables(0)
        Catch ex As Exception
            Return Nothing
            System.Windows.Forms.MessageBox.Show("Lỗi liệt kê cơ sở dữ liệu: " + ex.Message, "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
        Return dtListDatabases
    End Function

End Class
