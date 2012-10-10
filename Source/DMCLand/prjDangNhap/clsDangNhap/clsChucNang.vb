Imports DMC.Database

Public Class clsChucNang
    Dim Paras() As String = {"@MaNguoiDung"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String
    Private strMaNguoiDung As String
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
    'Khai bao thuoc tinh ung voi bien 
    Public Property MaNguoiDung() As String
        Get
            Return strMaNguoiDung
        End Get
        Set(ByVal value As String)
            strMaNguoiDung = value
        End Set
    End Property

    Public Function GetData(ByRef strRecords As DataTable) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Khai báo nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = {strMaNguoiDung}
                'Kiểm tra tính tương thích của cơ sở dữ liệu
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Mảng giá trị truyền vào không tương thích với mảng tham số", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng giá trị truyền vào không tương thích với mảng tham số"
                End If
                'Gọi phương thức thực thi Thủ tục truy vấn cơ sở dữ liệu
                Database.getValue(strRecords, "spSelectChucNangByMaNguoiDung", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

End Class
