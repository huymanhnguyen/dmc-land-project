﻿Public Class clsChu
    'Khai báo mảng các tham số
    Dim Paras() As String = {"@NhomDoiTuong", "@MaChu", "@DoiTuongSDD", "@QuanHe", _
        "@GioiTinh", "@HoTen", "@NamSinh", "@DiaChi" _
        , "@QuocTich", "@SoDinhDanh", "@NgayCap", "@NoiCap" _
        , "@QuocTich2", "@SoDinhDanh2", "@NgayCap2", "@NoiCap2" _
        , "@SoHoKhau", "@NgayCapHoKhau", "@NoiCapHoKhau" _
        , "@DaChet", "@DinhDanh"}
    ' Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaHoSoCapGCN As String
    Private strMaChu As String
    Private strQuanHe As String
    Private blnGioiTinh As String
    Private strHoTen As String
    Private dtmNamSinh As String

    Private strQuocTich As String
    Private strSoDinhDanh As String
    Private dtmNgayCap As String
    Private strNoiCap As String

    Private strQuocTich2 As String
    Private strSoDinhDanh2 As String
    Private dtmNgayCap2 As String
    Private strNoiCap2 As String
    Private strDoiTuongSDD As String
    Private strDiaChi As String
    Private strSoHoKhau As String
    Private blnDaChet As String
    Private dtmNgayCapHoKhau As String
    Private strNoiCapHoKhau As String
    Private strFlag As String = ""
    Private strNhomDoiTuong As String
    Private strDinhDanh As String

    Public Property NhomDoiTuong() As String
        Get
            Return strNhomDoiTuong
        End Get
        Set(ByVal value As String)
            strNhomDoiTuong = value
        End Set
    End Property

    Public Property Flag() As String
        Get
            Return strFlag
        End Get
        Set(ByVal value As String)
            strFlag = value
        End Set
    End Property
    'Khai báo thuộc tính nhân chuỗi kết nối Database
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
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property MaChu() As String
        Get
            Return strMaChu
        End Get
        Set(ByVal value As String)
            strMaChu = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property QuanHe() As String
        Get
            Return strQuanHe
        End Get
        Set(ByVal value As String)
            strQuanHe = value
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
    Public Property DaChet() As String
        Get
            Return blnDaChet
        End Get
        Set(ByVal value As String)
            blnDaChet = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property HoTen() As String
        Get
            Return strHoTen
        End Get
        Set(ByVal value As String)
            strHoTen = value
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
    Public Property QuocTich() As String
        Get
            Return strQuocTich
        End Get
        Set(ByVal value As String)
            strQuocTich = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property DinhDanh() As String
        Get
            Return strDinhDanh
        End Get
        Set(ByVal value As String)
            strDinhDanh = value
        End Set
    End Property
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

    'Khai bao thuoc tinh ung voi bien 
    Public Property QuocTich2() As String
        Get
            Return strQuocTich2
        End Get
        Set(ByVal value As String)
            strQuocTich2 = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property SoDinhDanh2() As String
        Get
            Return strSoDinhDanh2
        End Get
        Set(ByVal value As String)
            strSoDinhDanh2 = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property NgayCap2() As String
        Get
            Return dtmNgayCap2
        End Get
        Set(ByVal value As String)
            dtmNgayCap2 = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property NoiCap2() As String
        Get
            Return strNoiCap2
        End Get
        Set(ByVal value As String)
            strNoiCap2 = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property DiaChi() As String
        Get
            Return strDiaChi
        End Get
        Set(ByVal value As String)
            strDiaChi = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property SoHoKhau() As String
        Get
            Return strSoHoKhau
        End Get
        Set(ByVal value As String)
            strSoHoKhau = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property NgayCapHoKhau() As String
        Get
            Return dtmNgayCapHoKhau
        End Get
        Set(ByVal value As String)
            dtmNgayCapHoKhau = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property NoiCapHoKhau() As String
        Get
            Return strNoiCapHoKhau
        End Get
        Set(ByVal value As String)
            strNoiCapHoKhau = value
        End Set
    End Property
    Public Property DoiTuongSDD() As String
        Get
            Return strDoiTuongSDD
        End Get
        Set(ByVal value As String)
            strDoiTuongSDD = value
        End Set
    End Property

    ''' <summary>
    ''' Thực thi phát biểu SQL
    ''' </summary>
    ''' <param name="records"></param>
    ''' <param name="strStoreProcedureName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Execute(ByRef records As String, ByVal strStoreProcedureName As String) As String
        Try
            'Khởi tạo đối tượng clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công thì thực thi lệnh xóa dữ liệu
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strNhomDoiTuong, strMaChu, strDoiTuongSDD, strQuanHe, _
                    blnGioiTinh, strHoTen, dtmNamSinh, strDiaChi _
                    , strQuocTich, strSoDinhDanh, dtmNgayCap, strNoiCap _
                    , strQuocTich2, strSoDinhDanh2, dtmNgayCap2, strNoiCap2 _
                    , strSoHoKhau, dtmNgayCapHoKhau, strNoiCapHoKhau _
                    , blnDaChet, strDinhDanh}
                'Kiểm tra tính tương thức của tham biến và tham trị truyền vào
                If (Paras.Length <> Values.Length) Then
                    Return "Tham biến và tham trị không tương thích!"
                End If
                'Gọi phương thức thực thi phát biểu SQL của đối tượng Database
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, records)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    ''' <summary>
    ''' Xóa chủ sử dụng trong bảng tblChuSuDung
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteData(ByRef records As String) As String
        Return Me.Execute(records, "spDeleteChuSuDung")
    End Function
    ''' <summary>
    ''' Cập nhật Chủ sử dụng trong bảng tblChuSuDung
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateData(ByRef records As String) As String
        Return Me.Execute(records, "spUpdateChuSuDung")
    End Function
    ''' <summary>
    ''' Thêm Chủ sử dụng trong bảng tblChuSuDung
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertData(ByRef records As String) As String
        Return Me.Execute(records, "spInsertChuSuDung")
    End Function
    ''' <summary>
    ''' Lựa chọn Chủ sử dụng (Đối tượng Gia đình - Cá nhân)
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetData(ByRef records As DataTable) As String
        Try
            'Khởi tạo đối tượng Database
            Dim Database As New DMC.Database.clsDatabase
            ' Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strNhomDoiTuong, strMaChu, strDoiTuongSDD, strQuanHe, _
                    blnGioiTinh, strHoTen, dtmNamSinh, strDiaChi _
                    , strQuocTich, strSoDinhDanh, dtmNgayCap, strNoiCap _
                    , strQuocTich2, strSoDinhDanh2, dtmNgayCap2, strNoiCap2 _
                    , strSoHoKhau, dtmNgayCapHoKhau, strNoiCapHoKhau _
                    , blnDaChet, strDinhDanh}
                'Kiểm tra tính tương thức của tham biến và tham trị truyền vào
                If (Paras.Length <> Values.Length) Then
                    Return "Tham biến và tham trị không tương thích!"
                End If
                'Gọi phương thức GetValue của đối tượng DMC.Database.clsDatabase
                Database.getValue(records, "spSelectChuSuDung", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function KtraCMD() As DataTable
        Dim dt As New DataTable
        Dim para() As String = {"@flag", "@CMT", "@CMT2"}
        Dim value() As String = {strFlag, strSoDinhDanh, strSoDinhDanh2}
        'Khởi tạo đối tượng Database
        Dim Database As New DMC.Database.clsDatabase
        ' Nhận chuỗi kết nối Database
        Database.Connection = strConnection
        'Nếu kết nối cơ sở dữ liệu thành công
        If Database.OpenConnection = True Then
            'Khai báo mảng giá trị
            Database.getValue(dt, "spSelectKeyChuSuDung", para, value)
            Database.CloseConnection()
        End If
        Return dt
    End Function

End Class
