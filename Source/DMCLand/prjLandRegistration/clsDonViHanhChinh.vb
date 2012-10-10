Public Class clsDonViHanhChinh
    'Khai báo mảng tham số
    Dim Paras() As String = {"@MaDonViHanhChinh"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai bao bien kiem tra loi 
    Private strError As String = ""
    Private strMaDonViHanhChinh As String

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
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property

    Public Function SelectTuDienDonViHanhChinhByMaXa(ByRef dtResult As DataTable) As String
        Return Me.GetData("spSelectTuDienDonViHanhChinhByMaXa", dtResult)
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResult As DataTable) As String
        Dim strError As String = ""
        Try
            'Khởi tạo đối tượng thực thi cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            Database.Connection = GetConnection(bolKetNoiCSDL)
            If Database.OpenConnection = True Then
                'Nếu kết nối cơ sở dữ liệu thành công
                'Khai báo mảng giá trị
                Dim Values() As String = {strMaDonViHanhChinh}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtResult, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
            System.Windows.Forms.MessageBox.Show("Lỗi thực thi dữ liệu !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return strError
    End Function
End Class
