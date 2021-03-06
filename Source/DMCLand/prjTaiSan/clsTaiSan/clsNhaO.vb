'Ngày hiệu chỉnh gần nhất: 200807
'Danh sách người thực hiện: Vũ Lê Thành,
'Mô tả:
'Khai bao mang tham so
Imports DMC.Database
Public Class clsNhaO
    Dim Paras() As String = {"@MaNhaO", "@MaHoSoCapGCN", "@LoaiNha", "@CapHangNha", "@KetCauNha", "@SoTang", _
     "@NamXayDung", "@NamHoanThanhXayDung", "@ThoiHanSoHuu", "@DiaChiNha", "@DienTichXayDung", _
     "@DienTichSanPhu", "@DienTichSanXayDung", "@SoGiayPhepXayDung", "@NgayCapPhepXayDung", "@CoQuanCapGPXD", "@ThongTinXuLyViPham", "@NguonGocNha", "@GiaTriConLai", "@GhiChu", "@SoHuuRieng", "@SoHuuChung", "@IsGPXD", "@SoNha"}
    ' Nhận xâu kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗiNguonGocNha
    Private strError As String = ""
    Private strMaNhaO As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strLoaiNha As String = ""
    Private strCapHangNha As String = ""
    Private strKetCauNha As String = ""
    Private strSoTang As String = ""
    Private strSoNha As String = ""
    Private intNamXayDung As String = ""
    Private intNamHoanThanhXayDung As String = ""
    Private strThoiHanSoHuu As String
    Private strDiaChiNha As String = ""
    Private dblDienTichXayDung As String = ""
    Private dblDienTichSanPhu As String = ""
    Private dblDienTichSanXayDung As String = ""
    Private strSoGiayPhepXayDung As String = ""
    Private dtmNgayCapPhepXayDung As String = ""
    Private strCoQuanCapGPXD As String = ""
    Private strThongTinXuLyViPham As String = ""
    Private strNguonGocNha As String = ""
    Private strGiaTriConLai As String = ""
    Private strGhiChu As String = ""
    Private strSoHuuRieng As String = ""
    Private strSoHuuChung As String = ""
    Private strisGPXD As String = ""
    'Khai báo thuộc tính nhận xâu kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Kiểm tra lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property

    'Khai báo thuộc tính ứng với biến Mã Tài sản
    Public Property MaNhaO() As String
        Get
            Return strMaNhaO
        End Get
        Set(ByVal value As String)
            strMaNhaO = value
        End Set
    End Property

    Public Property SoNha() As String
        Get
            Return strSoNha
        End Get
        Set(ByVal value As String)
            strSoNha = value
        End Set
    End Property

    'Khai báo thuộc tính ứng với biến Mã Hồ sơ cấp GCN
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Loại nhà
    Public Property LoaiNha() As String
        Get
            Return strLoaiNha
        End Get
        Set(ByVal value As String)
            strLoaiNha = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Cập hạng nhà
    Public Property CapHangNha() As String
        Get
            Return strCapHangNha
        End Get
        Set(ByVal value As String)
            strCapHangNha = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Kết cấu nhà
    Public Property KetCauNha() As String
        Get
            Return strKetCauNha
        End Get
        Set(ByVal value As String)
            strKetCauNha = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Số tầng
    Public Property SoTang() As String
        Get
            Return strSoTang
        End Get
        Set(ByVal value As String)
            strSoTang = value
        End Set
    End Property
    'Khai báo thuộc tính nhận năm xây dựng
    Public Property NamXayDung() As String
        Get
            Return intNamXayDung
        End Get
        Set(ByVal value As String)
            intNamXayDung = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Năm hoàn thành xây dựng
    Public Property NamHoanThanhXayDung() As String
        Get
            Return intNamHoanThanhXayDung
        End Get
        Set(ByVal value As String)
            intNamHoanThanhXayDung = value
        End Set
    End Property
    'Khai báo thuộc tính thời hạn sở hữu
    Public Property ThoiHanSoHuu() As String
        Get
            Return strThoiHanSoHuu
        End Get
        Set(ByVal value As String)
            strThoiHanSoHuu = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Địa chỉ nhà
    Public Property DiaChiNha() As String
        Get
            Return strDiaChiNha
        End Get
        Set(ByVal value As String)
            strDiaChiNha = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Diện tích xây dựng
    Public Property DienTichXayDung() As String
        Get
            Return dblDienTichXayDung
        End Get
        Set(ByVal value As String)
            dblDienTichXayDung = value
        End Set
    End Property
    'Khai báo thuộc tính nhận diện tích sàn phụ
    Public Property DienTichSanPhu() As String
        Get
            Return dblDienTichSanPhu
        End Get
        Set(ByVal value As String)
            dblDienTichSanPhu = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Diện tích sàn xây dựng
    Public Property DienTichSanXayDung() As String
        Get
            Return dblDienTichSanXayDung
        End Get
        Set(ByVal value As String)
            dblDienTichSanXayDung = value
        End Set
    End Property
    'Khai báo thuộc tính Số giấy phép xây dựng
    Public Property SoGiayPhepXayDung() As String
        Get
            Return strSoGiayPhepXayDung
        End Get
        Set(ByVal value As String)
            strSoGiayPhepXayDung = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property NgayCapPhepXayDung() As String
        Get
            Return dtmNgayCapPhepXayDung
        End Get
        Set(ByVal value As String)
            dtmNgayCapPhepXayDung = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property CoQuanCapGPXD() As String
        Get
            Return strCoQuanCapGPXD
        End Get
        Set(ByVal value As String)
            strCoQuanCapGPXD = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property ThongTinXuLyViPham() As String
        Get
            Return strThongTinXuLyViPham
        End Get
        Set(ByVal value As String)
            strThongTinXuLyViPham = value
        End Set
    End Property

    Public Property NguonGocNha() As String
        Get
            Return strNguonGocNha
        End Get
        Set(ByVal value As String)
            strNguonGocNha = value
        End Set
    End Property
    Public Property GiaTriConLai() As String
        Get
            Return strGiaTriConLai
        End Get
        Set(ByVal value As String)
            strGiaTriConLai = value
        End Set
    End Property
    Public Property GhiChu() As String
        Get
            Return strGhiChu
        End Get
        Set(ByVal value As String)
            strGhiChu = value
        End Set
    End Property

    Public Property SoHuuRieng() As String
        Get
            Return strSoHuuRieng
        End Get
        Set(ByVal value As String)
            strSoHuuRieng = value
        End Set
    End Property
    Public Property SoHuuChung() As String
        Get
            Return strSoHuuChung
        End Get
        Set(ByVal value As String)
            strSoHuuChung = value
        End Set
    End Property
    Public Property isGPXD() As String
        Get
            Return strisGPXD
        End Get
        Set(ByVal value As String)
            strisGPXD = value
        End Set
    End Property

    ''' <summary>
    ''' Hàm thức thi cơ sở dữ liệu dùng chung cho
    ''' trường hợp: Insert, Update, Delete Tài sản
    ''' </summary>
    ''' <param name="records"></param>
    ''' <param name="strStoreProcedureName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Execute(ByRef records As String, ByVal strStoreProcedureName As String) As String
        Try
            'Khai báo và khởi tạo đối tựong clsDatabase
            Dim Database As New clsDatabase
            'Gán chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaNhaO, strMaHoSoCapGCN, strLoaiNha, strCapHangNha, strKetCauNha, strSoTang, _
                intNamXayDung, intNamHoanThanhXayDung, strThoiHanSoHuu, strDiaChiNha, dblDienTichXayDung, _
                dblDienTichSanPhu, dblDienTichSanXayDung, strSoGiayPhepXayDung, dtmNgayCapPhepXayDung _
                , strCoQuanCapGPXD, strThongTinXuLyViPham, strNguonGocNha, strGiaTriConLai, strGhiChu, strSoHuuRieng, strSoHuuChung, strisGPXD, strSoNha}
                'Gọi phương thức ExecuteSP của đối tượng Database
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, records)
                strError = Database.Err
                'Đóng kết nối cơ sở dữ liệu
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    ''' <summary>
    ''' Xóa Tài sản với Mã Hồ sơ cấp GCN cho trước
    ''' Trường hợp này xóa nhiều bản ghi Tài sản
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteNhaOByMaHoSoCapGCN(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spDeleteNhaOByMaHoSoCapGCN")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Xóa tài sản với Mã Tài sản cho trước
    ''' Trường hợp này Xóa một bản ghi tài sản
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteNhaOByMaNhaO(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spDeleteNhaOByMaNhaO")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Cập nhật thông tin Tài sản là NHÀ Ở
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateNhaO(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spUpdateNhaO")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Thêm thông tin nhà ở
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertNhaO(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spInsertNhaO")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function SelectNhaOByMaHoSoCapGCN(ByRef dtResults As DataTable) As String
        Return GetData("spSelectNhaOByMaHoSoCapGCN", dtResults)
    End Function

    ''' <summary>
    ''' Nhận Tài sản theo điều kiện truy vấn
    ''' </summary>
    ''' <param name="dtResults"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetData(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable) As String
        Dim strError As String = ""
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            'Gán chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Nếu kết nối cơ sở dữ liệu thành công
                'Khai báo mảng giá trị
                Dim Values() As String = _
                       {strMaNhaO, strMaHoSoCapGCN, strLoaiNha, strCapHangNha, strKetCauNha, strSoTang, _
                       intNamXayDung, intNamHoanThanhXayDung, strThoiHanSoHuu, strDiaChiNha, dblDienTichXayDung, _
                       dblDienTichSanPhu, dblDienTichSanXayDung, strSoGiayPhepXayDung, dtmNgayCapPhepXayDung _
                       , strCoQuanCapGPXD, strThongTinXuLyViPham, strNguonGocNha, strGiaTriConLai, strGhiChu, strSoHuuRieng, strSoHuuChung, strisGPXD, strSoNha}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức GetValue của đối tượng clsDatabase
                Database.getValue(dtResults, strStoreProcedureName, Paras, Values)
                'Đóng kết nối cơ sở dữ liệu
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class





