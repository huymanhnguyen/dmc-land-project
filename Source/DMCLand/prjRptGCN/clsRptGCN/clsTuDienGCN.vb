Imports DMC.Database
Public Class clsTuDienGCN
    'Khai báo mảng tham số
    Dim Paras() As String = {"@Ma"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""

    Private strMa As String
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính nhận thông báo lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai báo thuộc tính 
    Public WriteOnly Property Ma() As String
        Set(ByVal value As String)
            strMa = value
        End Set
    End Property
    Public Function GetData(ByRef dtRecords As DataTable) As String
        Try
            'Khai báo và khởi tạo lớp thao tác cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng tham trị
                Dim Values() As String = {strMa}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi Thủ tục
                Database.getValue(dtRecords, "spTuDienGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(strError)
        End Try
        Return strError
    End Function
End Class
