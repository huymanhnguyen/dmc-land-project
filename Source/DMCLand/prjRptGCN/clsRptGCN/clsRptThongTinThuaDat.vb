Imports DMC.Database

Public Class clsRptThongTinThuaDat
    'Khai báo mảng tham số
    Dim Paras() As String = {"@MaHoSoCapGCN"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String
    Private strMaHoSoCapGCN As String
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnnection = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến kiểm tra lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai báo thuộc tính ứng với biến Mã Hồ sơ cấp GCN
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    ''' <summary>
    ''' Phương thức thực thi thủ tục truy vấn dữ liệu
    ''' </summary>
    ''' <param name="strStoreProcedureName"></param>
    ''' <returns>Giá trị trả về là kiểu bảng </returns>
    ''' <remarks></remarks>
    Private Function SelectData(ByVal strStoreProcedureName As String) As DataTable
        Dim dtRecords As New DataTable
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            Database.Connection = strConnnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không phù hợp với mảng tham biến", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                End If
                Database.getValue(dtRecords, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(strError)
        End Try
        Return dtRecords
    End Function

    ''' <summary>
    ''' Lựa chọn thông tin Địa chỉ thửa đất đề nghị cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là bảng chứa thông tin 
    ''' Địa chỉ thửa đất đề nghị cấp GCN</returns>
    ''' <remarks></remarks>
    Public Function SelectDiaChiThuaDatByMaHoSoCapGCN() As DataTable
        Dim dtResults As New DataTable
        Try
            dtResults = Me.SelectData("spSelectDiaChiThuaDatByMaHoSoCapGCN")
        Catch ex As Exception
            MsgBox("Lỗi hiển thị thông tin địa chỉ thửa đất đề nghị cấp GCN: " + vbNewLine + ex.Message, MsgBoxStyle.OkOnly, "DMCLand")
        End Try
        Return dtResults
    End Function

    ''' <summary>
    ''' Lựa chọn thông tin Thửa đất đề nghị cấp GCN theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là dữ liệu kiểu bảng chứa thông tin
    ''' Thửa đất đất đề nghị cấp GCN</returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinThuaDat() As DataTable
        Dim dtResults As New DataTable
        Try
            dtResults = Me.SelectData("spSelectGCNThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN")
        Catch ex As Exception
            MsgBox("Lỗi hiển thị thông tin thửa đất đề nghị cấp GCN: " + vbNewLine + ex.Message, MsgBoxStyle.OkOnly, "DMCLand")
        End Try
        Return dtResults
    End Function
End Class
