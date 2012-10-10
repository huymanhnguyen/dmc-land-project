Public Class clsTraCuu
    ' Dim Paras() As String = {"@HoTen", "@DiaChi"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo biến nhận Họ tên chủ
    Private strHoTen As String = ""
    'Khai báo biến nhận Địa chỉ chủ
    Private strDiaChi As String = ""

    Private blnGioiTinh As String
    Private dtmNamSinh As String
    Private strSoDinhDanh As String
    Private dtmNgayCap As String
    Private strNoiCap As String

    'Khai báo thuộc tính nhân chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Họ tên Chủ Hồ sơ cấp GCN
    Public WriteOnly Property HoTen() As String
        Set(ByVal value As String)
            strHoTen = value
        End Set
    End Property
    'Khai báo thuộc tính chỉ nhận địa chỉ Chủ hồ sơ cấp GCN
    Public WriteOnly Property DiaChi() As String
        Set(ByVal value As String)
            strDiaChi = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property NamSinh() As String
        Get
            Return dtmNamSinh
        End Get
        Set(ByVal value As String)
            dtmNamSinh = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property GioiTinh() As String
        Get
            Return blnGioiTinh
        End Get
        Set(ByVal value As String)
            blnGioiTinh = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property SoDinhDanh() As String
        Get
            Return strSoDinhDanh
        End Get
        Set(ByVal value As String)
            strSoDinhDanh = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property NgayCap() As String
        Get
            Return dtmNgayCap
        End Get
        Set(ByVal value As String)
            dtmNgayCap = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property NoiCap() As String
        Get
            Return strNoiCap
        End Get
        Set(ByVal value As String)
            strNoiCap = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến kiểm tra lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    ''' <summary>
    ''' Tra cứu Chủ hồ sơ cấp GCN thuộc nhóm Gia đình, cá nhận
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectTraCuuChuByGDCN() As DataTable
        Dim dtResults As New DataTable
        Dim paras() As String = {"@HoTen", "@DiaChi", "@SoDinhDanh", "@NgayCap", "@NoiCap"}
        Dim values() As String = {strHoTen, strDiaChi, strSoDinhDanh, dtmNgayCap, strNoiCap}
        Me.GetData("spSelectTraCuuChuByGDCN", dtResults, paras, values)
        Return dtResults
    End Function

    ''' <summary>
    ''' Tra cứu Chủ hồ sơ cấp GCN thuộc nhóm Cơ quan nhà nước
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectTraCuuChuByCQNN() As DataTable
        Dim dtResults As New DataTable
        Dim paras() As String = {"@HoTen", "@DiaChi"}
        Dim values() As String = {strHoTen, strDiaChi}
        Me.GetData("spSelectTraCuuChuByCQNN", dtResults, paras, values)
        Return dtResults
    End Function

    ''' <summary>
    ''' Tra cứu Chủ hồ sơ cấp GCN thuộc nhóm Tổ chức doanh nghiệp
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectTraCuuChuByTCDN() As DataTable
        Dim dtResults As New DataTable
        Dim Paras() As String = {"@HoTen", "@DiaChi", "@SoDinhDanh", "@NgayCap", "@NoiCap"}
        Dim Values() As String = {strHoTen, strDiaChi, strSoDinhDanh, dtmNgayCap, strNoiCap}
        Me.GetData("spSelectTraCuuChuByTCDN", dtResults, paras, values)
        Return dtResults
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable, ByVal paras() As String, ByVal Values() As String) As String
        Try
            'Khởi tạo đối tượng cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Nếu kết nối cơ sở dữ liệu thành công
                'Khai báo mảng giá trị
                'Dim Values() As String = {strHoTen, strDiaChi}
                'Gọi phưong thức nhận dữ liệu của đối tượng clsDatabase
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
