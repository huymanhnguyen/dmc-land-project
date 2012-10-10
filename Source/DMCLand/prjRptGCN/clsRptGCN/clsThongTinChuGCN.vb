Imports DMC.Database

Public Class clsThongTinChuGCN
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

    Public Function SelectChuDeNghiCapGCNByMaHoSoCapGCN(ByRef dtRecords As DataTable) As String
        ''' Return Me.GetData("spSelectChuDeNghiCapGCNByMaHoSoCapGCN", dtRecords)
        Return Me.GetData("spSelectChuSuDungInGiayChungNhan", dtRecords)
    End Function

    Public Function SelectGhiChuNoiDungChuDeNghiCapGCN(ByRef dtRecords As DataTable) As String
        Return Me.GetData("spSelectGhiChuNoiDungChuDeNghiCapGCN", dtRecords)
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable) As String
        Dim strError As String = ""
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                    {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn cơ sở dữ liệu
                Database.getValue(dtResults, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

End Class
