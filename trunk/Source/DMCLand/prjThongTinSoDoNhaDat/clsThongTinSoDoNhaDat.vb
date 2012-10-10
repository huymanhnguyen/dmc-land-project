Imports DMC.Database

Public Class clsThongTinSoDoNhaDat
    Dim Paras() As String = {"@MaHoSoCapGCN"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String
    'Trạng thái Hồ sơ cấp GCN
    Private strMaHoSoCapGCN As String
    'Private bytSoDoNhaDat As Byte()
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
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    ''' <summary>
    ''' Xóa thông tin Sơ đồ nhà đất thẩm định theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Public Function DeleteSoDoNhaDatThamDinhByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteSoDoNhaDatThamDinhByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Hàm thực thi thủ tục SQLServer
    ''' </summary>
    ''' <param name="strStoreProcedureName"></param>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Execute(ByVal strStoreProcedureName As String, ByRef records As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu cập nhật dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaHoSoCapGCN}
                'Kiểm tra tính tương thích của cơ sở dữ liệu
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Mảng giá trị truyền vào không tương thích với mảng tham số", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng giá trị truyền vào không tương thích với mảng tham số"
                End If
                'Gọi phương thức thực thi Thủ tục SQLServer
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, records)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

#Region "Cần kiểm tra lại"
    Public Function GetData(ByRef strRecords As DataTable) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Khai báo nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                    {strMaHoSoCapGCN}
                'Kiểm tra tính tương thích của cơ sở dữ liệu
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Mảng giá trị truyền vào không tương thích với mảng tham số", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng giá trị truyền vào không tương thích với mảng tham số"
                End If
                'Gọi phương thức thực thi Thủ tục truy vấn cơ sở dữ liệu
                Database.getValue(strRecords, "", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
#End Region
End Class
