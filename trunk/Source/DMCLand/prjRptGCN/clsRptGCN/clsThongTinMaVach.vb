Imports DMC.Database

Public Class clsThongTinMaVach
    'Khai bao mang tham so
    Dim Paras() As String = {"@MaHoSoCapGCN"}
    'khai báo biến nhận chuỗi kết nối Database
    Private strConnnection As String = ""
    'Khai bao bien kiem tra loi 
    Private strError As String
    Private strMaHoSoCapGCN As String
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnnection = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai bao thuoc tinh ung voi bien
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Public Function SelectData(ByRef records As DataTable) As String
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnnection
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                Database.getValue(records, "spSelectThongTinMaVach", Paras, Values)
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
