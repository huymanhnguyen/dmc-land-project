'Ngày hiệu chỉnh gần nhất: 200807
'Danh sách người thực hiện: Vũ Lê Thành,
'Mô tả:
'Khai bao mang tham so
Imports DMC.Database

Public Class clsYeuCauBoSung
    Dim Paras() As String = {"@MaYeuCauBoXung", "@MaHoSoCapGCN", "@SoCongVanYeuCauBoXung", "@NgayCongVanYeuCauBoXung", "@NoiDungYeuCauBoXung", _
 "@ThoiHanYeuCauBoXung", "@YeuCauBoXungTuNgay", "@SoCongVanBoXung", "@NgayCongVanBoXung", "@NoiDungBoXung", "@NgayBoXung", "@HoanTatBoXung"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    Private strError As String 'Khai bao bien kiem tra loi 
    Private strMaYeuCauBoXung As String
    Private strMaHoSoCapGCN As String
    Private strSoCongVanYeuCauBoXung As String
    Private strNgayCongVanYeuCauBoXung As String
    Private strNoiDungYeuCauBoXung As String
    Private strThoiHanYeuCauBoXung As String
    Private strYeuCauBoXungTuNgay As String
    Private strSoCongVanBoXung As String
    Private strNgayCongVanBoXung As String
    Private strNoiDungBoXung As String
    Private strNgayBoXung As String
    Private strHoanTatBoXung As String

    'Khai báo thuộc tính nhận chuỗi kết nối Database
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
    Public Property MaYeuCauBoXung() As String
        Get
            Return strMaYeuCauBoXung
        End Get
        Set(ByVal value As String)
            strMaYeuCauBoXung = value
        End Set
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
    Public Property SoCongVanYeuCauBoXung() As String
        Get
            Return strSoCongVanYeuCauBoXung
        End Get
        Set(ByVal value As String)
            strSoCongVanYeuCauBoXung = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property NgayCongVanYeuCauBoXung() As String
        Get
            Return strNgayCongVanYeuCauBoXung
        End Get
        Set(ByVal value As String)
            strNgayCongVanYeuCauBoXung = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property NoiDungYeuCauBoXung() As String
        Get
            Return strNoiDungYeuCauBoXung
        End Get
        Set(ByVal value As String)
            strNoiDungYeuCauBoXung = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property ThoiHanYeuCauBoXung() As String
        Get
            Return strThoiHanYeuCauBoXung
        End Get
        Set(ByVal value As String)
            strThoiHanYeuCauBoXung = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property YeuCauBoXungTuNgay() As String
        Get
            Return strYeuCauBoXungTuNgay
        End Get
        Set(ByVal value As String)
            strYeuCauBoXungTuNgay = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property SoCongVanBoXung() As String
        Get
            Return strSoCongVanBoXung
        End Get
        Set(ByVal value As String)
            strSoCongVanBoXung = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property NgayCongVanBoXung() As String
        Get
            Return strNgayCongVanBoXung
        End Get
        Set(ByVal value As String)
            strNgayCongVanBoXung = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property NoiDungBoXung() As String
        Get
            Return strNoiDungBoXung
        End Get
        Set(ByVal value As String)
            strNoiDungBoXung = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property NgayBoXung() As String
        Get
            Return strNgayBoXung
        End Get
        Set(ByVal value As String)
            strNgayBoXung = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property HoanTatBoXung() As String
        Get
            Return strHoanTatBoXung
        End Get
        Set(ByVal value As String)
            strHoanTatBoXung = value
        End Set
    End Property

#Region "YÊU CẦU BỔ XUNG"
    Public Function DeleteYeuCauBoXungByMaYeuCauBoXung(ByRef strResults As String) As String
        Return Me.Execute("spDeleteYeuCauBoXungByMaYeuCauBoXung", strResults)
    End Function

    Public Function DeleteYeuCauBoXungByMaHoSoCapGCN(ByRef strResults As String) As String
        Return Me.Execute("spDeleteYeuCauBoXungByMaHoSoCapGCN", strResults)
    End Function

    Public Function InsertYeuCauBoXung(ByRef strResults As String) As String
        Return Me.Execute("spInsertYeuCauBoXung", strResults)
    End Function

    Public Function UpdateYeuCauBoXung(ByRef strResults As String) As String
        Return Me.Execute("spUpdateYeuCauBoXung", strResults)
    End Function
#End Region

#Region "THÔNG TIN BỔ XUNG"
    Public Function DeleteThongTinBoXungByMaYeuCauBoXung(ByRef strResults As String) As String
        Return Me.Execute("spDeleteThongTinBoXungByMaYeuCauBoXung", strResults)
    End Function

    Public Function DeleteThongTinBoXungByMaHoSoCapGCN(ByRef strResults As String) As String
        Return Me.Execute("spDeleteThongTinBoXungByMaHoSoCapGCN", strResults)
    End Function

    Public Function InsertThongTinBoXung(ByRef strResults As String) As String
        Return Me.Execute("spInsertThongTinBoXung", strResults)
    End Function

    Public Function UpdateThongTinBoXung(ByRef strResults As String) As String
        Return Me.Execute("spUpdateThongTinBoXung", strResults)
    End Function
#End Region

    ''' <summary>
    ''' Hàm thực thi phát biểu SQL
    ''' </summary>
    ''' <param name="strStoreProcedureName"></param>
    ''' <param name="strResults"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Execute(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khoi tao doi tuong clsSqlDatabase
            Dim Database As New clsDatabase
            'Neu ket noi co so du lieu thanh cong
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Values() As String = _
                {strMaYeuCauBoXung, strMaHoSoCapGCN, strSoCongVanYeuCauBoXung, strNgayCongVanYeuCauBoXung _
                 , strNoiDungYeuCauBoXung, strThoiHanYeuCauBoXung, strYeuCauBoXungTuNgay, strSoCongVanBoXung _
                 , strNgayCongVanBoXung, strNoiDungBoXung, strNgayBoXung, strHoanTatBoXung}
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, strResults)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function SelectYeuCauBoXung(ByRef dtResult As DataTable)
        Return Me.GetData("spSelectYeuCauBoXung", dtResult)
    End Function

    Public Function SelectThongTinBoXung(ByRef dtResult As DataTable)
        Return Me.GetData("spSelectThongTinBoXung", dtResult)
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResult As DataTable) As String
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection

            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = _
                {strMaYeuCauBoXung, strMaHoSoCapGCN, strSoCongVanYeuCauBoXung, strNgayCongVanYeuCauBoXung _
                 , strNoiDungYeuCauBoXung, strThoiHanYeuCauBoXung, strYeuCauBoXungTuNgay, strSoCongVanBoXung _
                 , strNgayCongVanBoXung, strNoiDungBoXung, strNgayBoXung, strHoanTatBoXung}
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtResult, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class

