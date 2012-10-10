Imports DMC.Database
Imports System.Data.SqlClient
''' <summary>
''' Note: Hiện tại class này Chỉ phục vụ cho Phiếu Thẩm định và GCN
''' Tương lại có thể BỎ class này
''' </summary>
''' <remarks></remarks>
Public Class clsChu
    Dim Paras() As String = {"@MaHoSoCapGCN"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo Field Mã hồ sơ cấp GCN
    Private strMaHoSoCapGCN As String = ""
    'Khai báo thuộc tính nhân chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến kiểm tra lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai báo thuôc tính ứng với biến Mã Hồ sơ cấp GCN
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Public Function GetData(ByRef dtResults As DataTable) As String
        Try
            'Khởi tạo đối tượng cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Nếu kết nối cơ sở dữ liệu thành công
                'Khai báo mảng giá trị
                Dim Values() As String = {strMaHoSoCapGCN}
                'Gọi phưong thức nhận dữ liệu của đối tượng clsDatabase
                Database.getValue(dtResults, "spChu", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
