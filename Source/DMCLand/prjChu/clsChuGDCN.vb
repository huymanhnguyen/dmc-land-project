﻿Public Class clsChuGDCN
    'Khai báo mảng các tham số
    Dim Paras() As String = {"@MaChu", "@QuanHe", _
"@GioiTinh", "@HoTen", "@NamSinh", "@SoDinhDanh", "@NgayCap", "@NoiCap", "@DiaChi", "@QuocTich", _
"@SoHoKhau", "@NgayCapHoKhau", "@NoiCapHoKhau", "@TonTai"}
    ' Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaChu As String
    Private strQuanHe As String
    Private blnGioiTinh As String
    Private strHoTen As String
    Private dtmNamSinh As String
    Private strSoDinhDanh As String
    Private dtmNgayCap As String
    Private strNoiCap As String
    Private strDiaChi As String
    Private strQuocTich As String
    Private strSoHoKhau As String
    Private blnTonTai As String
    Private dtmNgayCapHoKhau As String
    Private strNoiCapHoKhau As String

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
    Public Property TonTai() As String
        Get
            Return blnTonTai
        End Get
        Set(ByVal value As String)
            blnTonTai = value
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
    Public Property DiaChi() As String
        Get
            Return strDiaChi
        End Get
        Set(ByVal value As String)
            strDiaChi = value
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
                {strMaChu, strQuanHe, blnGioiTinh, strHoTen _
                 , dtmNamSinh, strSoDinhDanh, dtmNgayCap, strNoiCap, strDiaChi, strQuocTich, strSoHoKhau, dtmNgayCapHoKhau, strNoiCapHoKhau, blnTonTai}
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
        Return Me.Execute(records, "spDeleteChuByGDCN")
    End Function
    ''' <summary>
    ''' Cập nhật Chủ sử dụng trong bảng tblChuSuDung
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateData(ByRef records As String) As String
        Return Me.Execute(records, "spUpdateChuByGDCN")
    End Function
    ''' <summary>
    ''' Thêm Chủ sử dụng trong bảng tblChuSuDung
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertData(ByRef records As String) As String
        Return Me.Execute(records, "spInsertChuByGDCN")
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
                {strMaChu, strQuanHe, blnGioiTinh, strHoTen _
                 , dtmNamSinh, strSoDinhDanh, dtmNgayCap, strNoiCap, strDiaChi, strQuocTich, strSoHoKhau, dtmNgayCapHoKhau, strNoiCapHoKhau, blnTonTai}
                'Kiểm tra tính tương thức của tham biến và tham trị truyền vào
                If (Paras.Length <> Values.Length) Then
                    Return "Tham biến và tham trị không tương thích!"
                End If
                'Gọi phương thức GetValue của đối tượng DMC.Database.clsDatabase
                Database.getValue(records, "spSelectChuByGDCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class