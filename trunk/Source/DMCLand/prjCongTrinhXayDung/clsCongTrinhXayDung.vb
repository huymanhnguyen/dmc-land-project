Imports DMC.Database

Public Class clsCongTrinhXayDung
    Dim Paras() As String = {"@MaCongTrinhXayDung", "@MaHoSoCapGCN", "@GiayPhep" _
        , "@Ten", "@MoTa", "@NguonGoc", "@DienTichXayDung", "@HinhThanhTrongTuongLai" _
        , "@ThoiDiemHinhThanh"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaCongTrinhXayDung As String
    Private strMaHoSoCapGCN As String
    Private strGiayPhep As String
    Private strTen As String
    Private strMoTa As String
    Private strNguonGoc As String
    Private strDienTichXayDung As String
    Private strHinhThanhTrongTuongLai As String
    Private strThoiDiemHinhThanh As String

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

    'Khai bao thuoc tinh ung voi bien 
    Public Property MaCongTrinhXayDung() As String
        Get
            Return strMaCongTrinhXayDung
        End Get
        Set(ByVal value As String)
            strMaCongTrinhXayDung = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property GiayPhep() As String
        Get
            Return strGiayPhep
        End Get
        Set(ByVal value As String)
            strGiayPhep = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property Ten() As String
        Get
            Return strTen
        End Get
        Set(ByVal value As String)
            strTen = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property MoTa() As String
        Get
            Return strMoTa
        End Get
        Set(ByVal value As String)
            strMoTa = value
        End Set
    End Property

    Public Property NguonGoc() As String
        Get
            Return strNguonGoc
        End Get
        Set(ByVal value As String)
            strNguonGoc = value
        End Set
    End Property

    Public Property DienTichXayDung() As String
        Get
            Return strDienTichXayDung
        End Get
        Set(ByVal value As String)
            strDienTichXayDung = value
        End Set
    End Property

    Public Property HinhThanhTrongTuongLai() As String
        Get
            Return strHinhThanhTrongTuongLai
        End Get
        Set(ByVal value As String)
            strHinhThanhTrongTuongLai = value
        End Set
    End Property

    Public Property ThoiDiemHinhThanh() As String
        Get
            Return strThoiDiemHinhThanh
        End Get
        Set(ByVal value As String)
            strThoiDiemHinhThanh = value
        End Set
    End Property

    Public Function InsertCongTrinhXayDungByMaCongTrinhXayDung() As String
        Dim str As String = ""
        Return Me.Execute("spInsertCongTrinhXayDungByMaCongTrinhXayDung", str)
    End Function

    ''' <summary>
    ''' Cập nhật thông tin Công trình xây dựng theo Mã Công trình xây dựng
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Public Function UpdateCongTrinhXayDungByMaCongTrinhXayDung() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateCongTrinhXayDungByMaCongTrinhXayDung", str)
    End Function

    ''' <summary>
    ''' Xóa thông tin Công trình xây dựng theo Mã công trình xây dựng
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Public Function DeleteCongTrinhXayDungByMaCongTrinhXayDung() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteCongTrinhXayDungByMaCongTrinhXayDung", str)
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
                {strMaCongTrinhXayDung, strMaHoSoCapGCN, strGiayPhep _
                    , strTen, strMoTa, strNguonGoc, strDienTichXayDung _
                    , strHinhThanhTrongTuongLai, strThoiDiemHinhThanh}
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
                {strMaCongTrinhXayDung, strMaHoSoCapGCN, strGiayPhep _
                    , strTen, strMoTa, strNguonGoc, strDienTichXayDung _
                    , strHinhThanhTrongTuongLai, strThoiDiemHinhThanh}
                'Kiểm tra tính tương thích của cơ sở dữ liệu
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Mảng giá trị truyền vào không tương thích với mảng tham số", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng giá trị truyền vào không tương thích với mảng tham số"
                End If
                'Gọi phương thức thực thi Thủ tục truy vấn cơ sở dữ liệu
                Database.getValue(strRecords, "spSelectCongTrinhXayDungByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
