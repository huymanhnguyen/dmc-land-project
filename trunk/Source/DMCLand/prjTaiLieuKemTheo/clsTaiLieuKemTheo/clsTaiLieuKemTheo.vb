Public Class clsTaiLieuKemTheo

    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến Connection
    Dim sqlCon As SqlClient.SqlConnection
    'Khai bao bien kiem tra loi
    Private strError As String = ""
    'Dim DS As New DataSet
    Dim dtTaiLieuKemTheo As DataTable
    Dim strMaHoSoCapGCN As String = ""
    Dim strMaTaiLieuKemTheo As String = ""
    Private strKichThuoc As String = ""

    Private strTenTaiLieu As String

    Public Property TenTaiLieu() As String
        Get
            Return strTenTaiLieu
        End Get
        Set(ByVal value As String)
            strTenTaiLieu = value
        End Set
    End Property

    Public Property KichThuoc() As String
        Get
            Return strKichThuoc
        End Get
        Set(ByVal value As String)
            strKichThuoc = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính Mã Hồ sơ cấp GCN
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Khai báo thuộc tính nhận thông tin Mô tả của Tài liệu kèm theo
    Private strMoTa As String = ""
    Public Property MoTa() As String
        Get
            Return strMoTa
        End Get
        Set(ByVal value As String)
            strMoTa = value
        End Set
    End Property
    'Khai báo thuộc tính nhận thông tin Tên tệp dữ liệu nguồn
    Private strTenTepDuLieuNguon As String = ""
    Public Property TenTepDuLieuNguon() As String
        Get
            Return strTenTepDuLieuNguon
        End Get
        Set(ByVal value As String)
            strTenTepDuLieuNguon = value
        End Set
    End Property

    ' Khai báo biến kiểu mảng Byte nhận Tài liệu
    Private byteTaiLieu() As Byte
    'Khai báo thuộc tính kiểu mảng Byte nhận Tài liệu
    Public Property TaiLieu() As Byte()
        Get
            Return byteTaiLieu
        End Get
        Set(ByVal value As Byte())
            byteTaiLieu = value
        End Set
    End Property
    'Khai báo thuộc tính Mã Tài liệu kèm theo
    Public Property MaTaiLieuKemTheo() As String
        Get
            Return strMaTaiLieuKemTheo
        End Get
        Set(ByVal value As String)
            strMaTaiLieuKemTheo = value
        End Set
    End Property

    'Mở kết nối cơ sở dữ liệu
    Public Function OpenConnection() As Boolean
        Dim boolSuccessfully As Boolean = False
        Try
            'Truyền chuỗi kết nối cơ sở dữ liệu
            sqlCon = New SqlClient.SqlConnection(strConnection)
            'Mở kết nối cơ sở dữ liệu
            sqlCon.Open()
            strError = ""
            boolSuccessfully = True
        Catch eq As SqlClient.SqlException
            strError = eq.Message
            MsgBox(" Lỗi: " & vbNewLine & eq.Message, MsgBoxStyle.Information, "Lỗi kết nối dữ liệu")
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Lỗi: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "Lỗi kết nối dữ liệu")
        End Try
        Return boolSuccessfully
    End Function
    'Đóng kết nối cơ sở dữ liệu
    Public Sub CloseConnection()
        'Nếu chưa đóng kết nối thì đóng kết nối lại
        If sqlCon.State <> ConnectionState.Closed Then
            'Đóng kết nối
            sqlCon.Close()
            'Giải phóng 
            sqlCon.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' Thực thi câu lệnh truy vấn thông tin Tài liệu kèm theo
    ''' </summary>
    ''' <param name="strStoreProcedureName">Tên thủ tục muốn thực thi phát biểu SQL</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Execute(ByVal strStoreProcedureName As String) As String
        Try
            'Chắc chắn rằng tồn tại tên Store Procedure 
            If (strStoreProcedureName = "") Then
                Return Nothing
            End If
            Dim Database As New DMC.Database.clsDatabase()
            'Neu ket noi co so du lieu thanh cong
            Database.Connection = strConnection
            If (Database.OpenConnection() = True) Then
                '/*  Khai báo đối tượng SqlCommand */
                Dim sqlCommand = New System.Data.SqlClient.SqlCommand()
                '/* Gán kết nối tới cơ sở dữ liệu */
                sqlCommand.Connection = New System.Data.SqlClient.SqlConnection(strConnection)
                '/*  Xác định kểu thực thi câu lệnh Sql là StoredProcedure */
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure
                '/*  Nhận tên Thủ tục trong cơ sở dữ liệu */
                sqlCommand.CommandText = strStoreProcedureName
                '/*  Khởi tạo đối tượng SqlParameter */
                Dim sqlParaMaTaiLieuKemTheo = New System.Data.SqlClient.SqlParameter("@MaTaiLieuKemTheo", System.Data.SqlDbType.NVarChar, 500)
                sqlParaMaTaiLieuKemTheo.Value = strMaTaiLieuKemTheo
                sqlCommand.Parameters.Add(sqlParaMaTaiLieuKemTheo)
                '/*  Khởi tạo đối tượng SqlParameter */
                Dim sqlParaMaHoSoCapGCN = New System.Data.SqlClient.SqlParameter("@MaHoSoCapGCN", System.Data.SqlDbType.BigInt)
                sqlParaMaHoSoCapGCN.Value = Convert.ToInt64(strMaHoSoCapGCN)
                sqlCommand.Parameters.Add(sqlParaMaHoSoCapGCN)
                Dim sqlParaTenTaiLieu = New System.Data.SqlClient.SqlParameter("@TenTaiLieu", System.Data.SqlDbType.NVarChar, 300)
                sqlParaTenTaiLieu.Value = strTenTaiLieu
                sqlCommand.Parameters.Add(sqlParaTenTaiLieu)
                '/*  Khởi tạo đối tượng SqlParameter */
                Dim sqlParaTenTepDuLieuNguon = New System.Data.SqlClient.SqlParameter("@TenTepDuLieuNguon", System.Data.SqlDbType.NVarChar, 500)
                sqlParaTenTepDuLieuNguon.Value = strTenTepDuLieuNguon
                sqlCommand.Parameters.Add(sqlParaTenTepDuLieuNguon)
                '/*  Khởi tạo đối tượng SqlParameter */
                Dim sqlParaMoTa = New System.Data.SqlClient.SqlParameter("@MoTa", System.Data.SqlDbType.NVarChar)
                sqlParaMoTa.Value = strMoTa
                sqlCommand.Parameters.Add(sqlParaMoTa)

               
                '/*  Khởi tạo đối tượng SqlParameter */
                If Not byteTaiLieu Is Nothing Then
                    Dim sqlParaTaiLieu = New System.Data.SqlClient.SqlParameter("@TaiLieu", System.Data.SqlDbType.Image)
                    sqlParaTaiLieu.Value = byteTaiLieu
                    strKichThuoc = byteTaiLieu.Length
                    sqlCommand.Parameters.Add(sqlParaTaiLieu)
                End If

                If (sqlCommand.Connection.State = System.Data.ConnectionState.Closed) Then
                    sqlCommand.Connection.Open()
                End If

                If strKichThuoc = "" Then
                    strKichThuoc = "0"
                End If
                Dim sqlParaKichThuoc = New System.Data.SqlClient.SqlParameter("@KichThuoc", System.Data.SqlDbType.Int)
                sqlParaKichThuoc.Value = strKichThuoc
                sqlCommand.Parameters.Add(sqlParaKichThuoc)

                '/*  Thực thi thủ tục hệ thống */
                '//strResult = sqlCom.ExecuteScalar();
                sqlCommand.ExecuteNonQuery()
            End If

        Catch ex As Exception
            strError = ex.Message()
            System.Windows.Forms.MessageBox.Show("Lỗi: " + System.Environment.NewLine + strError, "DMCLand", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End Try
        Return strError

    End Function

    ''' <summary>
    ''' Thêm mới tài liệu kèm theo
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertTaiLieuKemTheo()
        Me.Execute("spInsertTaiLieuKemTheo")
    End Sub

    ''' <summary>
    ''' Cập nhật thông tin tài liệu kèm theo 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateTaiLieuKemTheo()
        Me.Execute("spUpdateTaiLieuKemTheoByMaTaiLieuKemTheo")
    End Sub

    ''' <summary>
    ''' Xóa tài liệu kèm theo theo Mã Tài liệu kèm theo
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeleteTaiLieuKemTheoByMaTaiLieuKemTheo()
        Me.Execute("spDeleteTaiLieuKemTheoByMaTaiLieuKemTheo")
    End Sub
    ''' <summary>
    ''' Xóa tài liệu kèm theo theo Mã Hồ sơ cấp GCN
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeleteTaiLieuKemTheoByMaHoSoCapGCN()
        Me.Execute("spDeleteTaiLieuKemTheoByMaHoSoCapGCN")
    End Sub

    ''' <summary>
    ''' SelectTaiLieuKemTheo
    ''' </summary>
    ''' <remarks></remarks>
    Private Function SelectTaiLieuKemTheo(ByVal strStoreProcedureName) As DataTable
        'Initialize Dataset.
        Dim dtTaiLieuKemTheo As New DataTable("tblTaiLieuKemTheo")
        'Chắc chắn rằng tồn tại Tên Store procedure
        If (strStoreProcedureName = "") Then
            Return Nothing
        End If

        'Chắc chắn rằng Mã Hồ sơ cấp GCN là kiểu số 
        If Not IsNumeric(strMaHoSoCapGCN) Then
            Return Nothing
        End If

        Try
            'Khai báo và khởi tạo đối tượng SqlCommand
            Dim sqlCommand As New SqlClient.SqlCommand
            'Gán kết nối cơ sở dữ liệu
            sqlCommand.Connection = New System.Data.SqlClient.SqlConnection(strConnection)
            'Nhận kiểu thực thì câu lệnh truy vấn cơ sở dữ liệu là thủ tục 
            sqlCommand.CommandType = CommandType.StoredProcedure
            'Gán Tên thủ tục
            sqlCommand.CommandText = strStoreProcedureName
            '/*  Khởi tạo đối tượng SqlParameter */
            Dim sqlParaMaTaiLieuKemTheo = New System.Data.SqlClient.SqlParameter("@MaTaiLieuKemTheo", System.Data.SqlDbType.NVarChar)
            sqlParaMaTaiLieuKemTheo.Value = strMaTaiLieuKemTheo
            sqlCommand.Parameters.Add(sqlParaMaTaiLieuKemTheo)
            '/*  Khởi tạo đối tượng SqlParameter */
            Dim sqlParaMaHoSoCapGCN = New System.Data.SqlClient.SqlParameter("@MaHoSoCapGCN", System.Data.SqlDbType.BigInt)
            sqlParaMaHoSoCapGCN.Value = Convert.ToInt64(strMaHoSoCapGCN)
            sqlCommand.Parameters.Add(sqlParaMaHoSoCapGCN)
            Dim sqlParaTenTaiLieu = New System.Data.SqlClient.SqlParameter("@TenTaiLieu", System.Data.SqlDbType.NVarChar, 300)
            sqlParaTenTaiLieu.Value = strTenTaiLieu
            sqlCommand.Parameters.Add(sqlParaTenTaiLieu)
            '/*  Khởi tạo đối tượng SqlParameter */
            Dim sqlParaTenTepDuLieuNguon = New System.Data.SqlClient.SqlParameter("@TenTepDuLieuNguon", System.Data.SqlDbType.NVarChar)
            sqlParaTenTepDuLieuNguon.Value = strTenTepDuLieuNguon
            sqlCommand.Parameters.Add(sqlParaTenTepDuLieuNguon)
            '/*  Khởi tạo đối tượng SqlParameter */
            Dim sqlParaMoTa = New System.Data.SqlClient.SqlParameter("@MoTa", System.Data.SqlDbType.NVarChar)
            sqlParaMoTa.Value = strMoTa
            sqlCommand.Parameters.Add(sqlParaMoTa)
            '/*  Khởi tạo đối tượng SqlParameter */
            Dim sqlParaTaiLieu = New System.Data.SqlClient.SqlParameter("@TaiLieu", System.Data.SqlDbType.Image)
            sqlParaTaiLieu.Value = byteTaiLieu
            sqlCommand.Parameters.Add(sqlParaTaiLieu)
            If byteTaiLieu Is Nothing Then
                Dim sqlParaKichThuoc = New System.Data.SqlClient.SqlParameter("@KichThuoc", System.Data.SqlDbType.Int)
                sqlParaKichThuoc.Value = 0
                sqlCommand.Parameters.Add(sqlParaKichThuoc)
            Else
                Dim sqlParaKichThuoc = New System.Data.SqlClient.SqlParameter("@KichThuoc", System.Data.SqlDbType.Int)
                sqlParaKichThuoc.Value = byteTaiLieu.Length
                sqlCommand.Parameters.Add(sqlParaKichThuoc)
            End If
           

            'Khai báo vào khởi tạo đối tượng SqlDataAdapter
            Dim sqlDataAdapter As New SqlClient.SqlDataAdapter(sqlCommand)
            'Điền dữ liệu vào đối tượng DataTable
            sqlDataAdapter.Fill(dtTaiLieuKemTheo)
        Catch ex As Exception
            strError = ex.Message
            MsgBox(" Hiển thị dữ liệu " & vbNewLine & " Lỗi " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
        Return dtTaiLieuKemTheo
    End Function

    ''' <summary>
    ''' Select Tài liệu kèm theo theo Mã Tài liệu kèm theo
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectTaiLieuKemTheoByMaTaiLieuKemTheo() As DataTable
        Return Me.SelectTaiLieuKemTheo("spSelectTaiLieuKemTheoByMaTaiLieuKemTheo")
    End Function

    ''' <summary>
    ''' Select Tài liệu kèm theo theo Mã Hồ sơ cấp GCN
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectTaiLieuKemTheoByMaHoSoCapGCN() As DataTable
        Return Me.SelectTaiLieuKemTheo("spSelectTaiLieuKemTheoByMaHoSoCapGCN")
    End Function

#Region "Thao tác File"
    ''' <summary>
    ''' Lưu File trên ổ đĩa 
    ''' </summary>
    ''' <param name="strSaveFileName">Tên file cần lưu</param>
    ''' <param name="byteContent">Nội dung tài liệu cần luu (kiểu byte)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveFile(ByVal strSaveFileName As String, ByVal byteContent As Byte(), ByVal kichthuoc As Integer) As Boolean
        Dim objFstream As IO.FileStream = Nothing
        Try
            objFstream = IO.File.Open(strSaveFileName, IO.FileMode.Create, IO.FileAccess.Write)
            Dim lngLen As Long = byteContent.Length
            objFstream.Write(byteContent, 0, kichthuoc) 'CInt(lngLen))
            objFstream.Flush()
            Return True
        Catch ex As Exception
            MsgBox(" Lỗi ghi dữ liệu: " & vbNewLine & ex.Message, MsgBoxStyle.Information, "DMCLand")
            Return False
        Finally
            objFstream.Close()
        End Try
    End Function

    ''' <summary>
    ''' Đọc File tài liệu từ ổ đĩa với Tên đường dẫn cho trước
    ''' </summary>
    ''' <param name="strPath">Tên đường dẫn File tài liệu trên ổ đĩa</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadFile(ByVal strPath As String) As Byte()
        'Initialize byte array with a null value initially.
        Dim byteData As Byte()
        'Use FileInfo object to get file size.
        Dim fInfo As New IO.FileInfo(strPath)
        Dim numBytes As Long
        numBytes = fInfo.Length
        'Open file stream de doc file
        Dim fStream As IO.FileStream
        fStream = New IO.FileStream(strPath, IO.FileMode.Open, IO.FileAccess.Read)
        'Use BinaryReader to read file stream into byte array.
        Dim br As New IO.BinaryReader(fStream)
        'When you use BinaryReader, you need to supply number of bytes to read from file.
        'In this case we want to read entire file. So supplying total number of bytes.
        byteData = br.ReadBytes(CInt(numBytes))
        Return byteData
    End Function
#End Region

End Class
