Imports DMC.Database
Public Class clsTuDienPhieuThamDinh
    'Khai báo mảng tham số
    Dim Paras() As String = {}
    'Khai báo biến nhận chuỗi kết nối
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối
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
    'Phương thức truy vấn cơ sở dữ liệu
    Public Function GetData(ByRef dtRecords As DataTable) As String
        Try
            'Khai báo và khởi tạo đối tượng truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = {}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn cơ sở dữ liệu
                Database.getValue(dtRecords, "spSelectTuDienPhieuThamDinh", Paras, Values)
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
