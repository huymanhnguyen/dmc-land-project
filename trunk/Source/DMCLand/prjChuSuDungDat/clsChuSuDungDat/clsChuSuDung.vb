Imports DMC.Database
Imports System.Data.SqlClient
Public Class clsChuSuDung
    Dim Paras() As String = {"@MaChu", "@MaHoSoCapGCN"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaChu As String
    Private strMaHoSoCapGCN As String

    'Khai báo thuộc tính nhân chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property


    'Khai bao thuoc tinh ung voi bien 
    Public Property MaChuSuDung() As String
        Get
            Return strMaChu
        End Get
        Set(ByVal value As String)
            strMaChu = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property


    Public Function Execute(ByRef records As String, ByVal strStoreProcedureName As String) As String
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công thị thực thi phát biểu SQL
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaChu, strMaHoSoCapGCN}
                'Kiểm tra tính tương đồng của 2 mảng dữ liệu
                If (Paras.Length <> Values.Length) Then
                    Return "Giá trị truyền vào không tương thích"
                End If
                'Gọi phương thức thực thi cơ sở dữ liệu của đối tượng clsDatabase
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, records)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    Public Function UpdateData(ByRef records As String) As String
        Return Me.Execute(records, "spUpdateChuSuDung")
    End Function
    '
    Public Function InsertData(ByRef records As String) As String
        Return Me.Execute(records, "spInsertChuSuDung")
    End Function
    Public Function DeleteData(ByRef records As String) As String
        Return Me.Execute(records, "spDeleteChuSuDung")
    End Function

    Private Function GetData(ByRef dtResults As DataTable, ByVal strStoreProcedureName As String) As String
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            Database.Connection = strConnection ' Nhận chuỗi kết nối Database
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = _
                {strMaChu, strMaHoSoCapGCN}
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

    Public Function SelectChuSuDungByGDCN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSuDungByGDCN")
    End Function

    Public Function SelectChuSuDungByTCDN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSuDungByTCDN")
    End Function

    Public Function SelectChuSuDungByCQNN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSuDungByCQNN")
    End Function

End Class
