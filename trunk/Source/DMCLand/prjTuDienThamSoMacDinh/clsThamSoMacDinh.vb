Imports DMC.Database

Public Class clsThamSoMacDinh
    Dim Paras() As String = {"@Ma", "@Ten", "@MoTa"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strMa As String = ""
    Private strError As String = ""
    Private strTen As String = ""
    Private strMoTa As String = ""
    Private strNhom As String = ""
    Private strDonViDangKy As String = ""
    'Khai báo thuộc tính gán chuỗi kết nối
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

    Public Property Get_Ma() As String
        Get
            Return strMa
        End Get
        Set(ByVal value As String)
            strMa = value
        End Set
    End Property
    Public Property DonViDangKy() As String
        Get
            Return strDonViDangKy
        End Get
        Set(ByVal value As String)
            strDonViDangKy = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien shBang
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai bao thuoc tinh ung voi bien KyHieu
    Public Property Ten() As String
        Get
            Return strTen
        End Get
        Set(ByVal value As String)
            strTen = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien strMoTa
    Public Property MoTa() As String
        Get
            Return strMoTa
        End Get
        Set(ByVal value As String)
            strMoTa = value
        End Set
    End Property

    Private Function Execute(ByVal strStoreProcedure As String, ByRef records As Integer) As String
        Try
            'Khoi tao doi tuong clsSqlDatabase
            Dim Database As New clsDatabase
            'Neu ket noi co so du lieu thanh cong
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Values() As String = _
                {strMa, strTen, strMoTa}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP(strStoreProcedure, Paras, Values, records)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable) As String
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = _
                    {strMa, strTen, strMoTa}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtResults, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function SelectThamSoMacDinh(ByRef dtResults As DataTable) As String
        Return Me.GetData("spSelectThamSoMacDinh", dtResults)
    End Function

    Public Function InsertThamSoMacDinh(ByRef intRecords As Integer) As String
        Return Me.Execute("spInsertThamSoMacDinh", intRecords)
    End Function

    'Update MaCoQuanThucHien

    Public Function UpdateThamSoMacDinh(ByRef intRecords As Integer) As String
        Return Me.Execute("spUpdateThamSoMacDinh", intRecords)
    End Function

    ' Delete MaCoQuanThucHien

    Public Function DeleteThamSoMacDinh(ByRef intRecords As Integer) As String
        Return Me.Execute("spDeleteThamSoMacDinh", intRecords)
    End Function
End Class
