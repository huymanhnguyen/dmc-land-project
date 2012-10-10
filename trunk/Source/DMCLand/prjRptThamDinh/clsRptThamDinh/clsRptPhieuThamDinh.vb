Imports DMC.Database
Public Class clsRptPhieuThamDinh
    'Khai bao mang tham so
    Dim Paras() As String = {"@MaHoSoCapGCN"}
    'Khai báo biến nhận chuỗi kết nối
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaHoSoCapGCN As String
    'Khai báo thuộc tính nhận chuỗi kết nối
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
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    ''' <summary>
    ''' Danh sách thông tin Chủ GCN đề nghị In GCN theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Kết quả trả về là Bảng danh sách chủ GCN đề nghị In GCN theo
    ''' Mã Hồ sơ cấp GCN cho trước</returns>
    ''' <remarks></remarks>
    Public Function SelectChuDeNghiCapGCNByMaHoSoCapGCN() As DataTable
        Dim dtResults As New DataTable
        Me.GetData("spSelectChuDeNghiCapGCNByMaHoSoCapGCN", dtResults)
        Return dtResults
    End Function


    Public Function PhieuThamDinh() As DataTable
        Dim dtResults As New DataTable
        Me.GetData("spPhieuThamDinh", dtResults)
        Return dtResults
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtRecords As DataTable) As String
        Try
            'Khai báo và khởi tạo đối tượng truy xuất cơ sở dữ liệu 
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức nhận dữ liệu
                Database.getValue(dtRecords, strStoreProcedureName, Paras, Values) ' "spPhieuThamDinh"
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
