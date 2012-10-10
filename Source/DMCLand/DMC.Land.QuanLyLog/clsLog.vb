Imports DMC.Database
Public Class clsLog
    Private strPara() As String = {"@UserName", "@ModulName", "@TimeStart", "@TimeEnd", "@ActionName", "@ObjName", "@MoTa"}
    Private strConnection As String = ""
    Private strUserName As String = ""
    Private strModulName As String = ""
    Private strTimeStart As String = ""
    Private strTimeEnd As String = ""
    Private strActionName As String = ""
    Private strObjName As String = ""
    Private strMoTa As String = ""
    Private strError As String = ""
    Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'ham thuc thi cac cau lenh them moi, sua , xoa
    Public Function Execute(ByVal sp As String, ByVal para() As String, ByVal values() As String) As String
        Try
            'Khai báo và khởi tạo đối tượng Database
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Neu ket noi co so du lieu thanh cong
            If Database.OpenConnection = True Then
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (para.Length <> values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                Dim records As String = ""
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP(sp, para, values, records)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    Public Function SetLog(ByVal UserName As String, ByVal ModulName As String, ByVal TimeStart As String, ByVal TimeEnd As String, ByVal ActionName As String, ByVal ObjName As String, ByVal MoTa As String) As String
        Dim values() As String = {UserName, ModulName, TimeStart, TimeEnd, ActionName, ObjName, MoTa}
        Return Execute("sp_QuanLyLog", strPara, values)
    End Function

End Class
