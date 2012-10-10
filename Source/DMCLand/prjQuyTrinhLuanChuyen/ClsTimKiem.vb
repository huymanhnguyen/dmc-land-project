Imports DMC.Database
Public Class ClsTimKiem
    Private strConnection As String = ""
    Private strMaDonViHanhChinh As String = ""
    Private strNgayTim As String = ""
    Private strToBanDo As String = ""
    Private strSoThua As String = ""
    Private parasTimHoSoTiepNhan() As String = {"@MaDonViHanhChinh", "@NgayTiepNhan"}
    Private parsTimKiemTheoDoi() As String = {"@MaDonViHanhChinh", "@ToBanDo", "@SoThua"}
    Private strChonBaoCao As String = ""
    Private strBaoCao As String = ""
    Public Property BaoCao() As String
        Get
            Return strBaoCao
        End Get
        Set(ByVal value As String)
            strBaoCao = value
        End Set
    End Property

    Public Property ChonBaoCao() As String
        Get
            Return strChonBaoCao
        End Get
        Set(ByVal value As String)
            strChonBaoCao = value
        End Set
    End Property

    'Khai báo thuộc tính gán chuỗi kết nối cơ sở dữ liệu
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien MaDonViHanhChinh
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Public Property NgayTimKiem() As String
        Get
            Return strNgayTim

        End Get
        Set(ByVal value As String)
            strNgayTim = value
        End Set
    End Property
    Public Property ToBanDo() As String
        Get
            Return strToBanDo
        End Get
        Set(ByVal value As String)
            strToBanDo = value
        End Set
    End Property

    Public Property SoThua() As String
        Get
            Return strSoThua
        End Get
        Set(ByVal value As String)
            strSoThua = value
        End Set
    End Property
    Public Function TimKiemHoSoTiepNhan(ByVal sp As String, ByVal Values() As String, ByVal paras() As String) As DataTable
        Dim strError As String = ""
        Dim MyTable As New DataTable
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            If (Database.OpenConnection) Then
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (paras.Length <> Values.Length) Then
                    Return Nothing
                End If
                'Gọi phương thức GetValue của đối tượng clsDatabase
                Database.getValue(MyTable, sp, paras, Values)
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return MyTable
    End Function
    Public Function SelectHoSoMoiTiepNhan() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim Paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenTiepNhan", Values, Paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    '''''''''''''''''''''''''''''''''

    Public Function SelectHoSoMoiTiepNhanDaChuyen() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim Paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenTiepNhanDaChuyen", Values, Paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    '''''''''''''''''''''''''''''''''

    Public Function SelectHoSoVPNhaDatTiepNhan() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenVPNhaDatTiepNhan", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    '''''''''''''''''''''''''''''''''

    Public Function SelectHoSoVPNhaDatChuyen() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenVPNhaDatDaChuyen", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    '''''''''''''''''''''''''''''''''
    ' select hồ sơ VP thẩm định đã nhận
    Public Function SelectHoSoVPThamDinhDaNhan() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenVPThamDinh", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function



    '''''''''''''''''''''''''''''''''
    'tìm hồ sơ đã chuyển PTNMT lên từ VPThamDinh

    Public Function SelectHoSoVPThamDinhDaChuyen() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenVPThamDinhDaChuyen", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    '''''''''''''''''''''''''''''''''
    ' select hồ sơ phòng TNMT đã nhận và còn ở đó
    Public Function SelectHoSoPhongTNMTDanhan() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenPhongTNMT", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function


    '''''''''''''''''''''''''''''''''
    'tìm hồ sơ đã chuyểnUBThamDinh lên từ TNMT

    Public Function SelectHoSoTNMTDaChuyen() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenTNMTDaChuyen", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    '''''''''''''''''''''''''''''''''
    ' select hồ sơ UBTHamDinh đã nhận và còn ở đó
    Public Function SelectHoSoUBThamDinhDaNhan() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenUBThamDinh", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    '''''''''''''''''''''''''''''''''
    'tìm hồ sơ đã chuyểnUBThamDinh về TNMT

    Public Function SelectHoSoUBThamDinhDaChuyen() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh, strNgayTim}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenUBThamDinhDaChuyen", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    '''''''''''''''''''''''''''''''''
    ' select hồ sơ phòng TNMT đã nhận trả về và còn ở đó
    Public Function SelectHoSoPhongTNMTDaNhanTraVe() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenPhongTNMTNhanTraVe", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function


    '/////////////////////////////////
    'tìm hồ sơ đã chuyển về VPNhaDat từ TNMT

    Public Function SelectHoSoDaChuyenVeVPNhaDat() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenTNMTDaChuyenLan2", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    '''''''''''''''''''''''''''''''''
    ' Hồ sơ văn phòng nhà đất đã nhận lại từ TNMT
    Public Function SelectHoSoVPNhaDatDaNhanLai() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenVPNhaDatNhanLai", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    '''''''''''''''''''''''''''''''''

    Public Function SelectHoSoVPNhaDatChuyenVeNoiTiepNhan() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenVPNhaDatDaChuyenVeNoiTiepNhan", Values, paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    '''''''''''''''''''''''''''''''''
    ' Hồ sơ Nhân Về Một Cửa
    Public Function SelectHoSoNhanVe() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim Paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenHoSoNhanVe", Values, Paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    '''''''''''''''''''''''''''''''''
    ' Hồ sơ Nhân Về Một Cửa
    Public Function SelectHoSoHoanTat() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim Paras() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenHoSoHoanTat", Values, Paras)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    ''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''
    ' select hồ sơ TheoDoi
    Public Function SelectHoSoTheoDoi() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            Dim parsTimKiemTheoDoi() As String = {"@MaDonViHanhChinh"}
            dt = TimKiemHoSoTiepNhan("SearchLuanChuyenTheoDoiTrangThai", Values, parsTimKiemTheoDoi)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    ' Báo Cáo
    Public Function SelectDVHC() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Dim ParaDVHC() As String = {"@MaDVHC"}
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            dt = TimKiemHoSoTiepNhan("spSelectHuyenTinh", Values, ParaDVHC)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    Public Function InBaoCao() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Dim paras() As String = {"@MaDonViHanhChinh"}
        Dim Values() As String = {strMaDonViHanhChinh}

        Select Case strChonBaoCao.Trim
            Case "DANH SÁCH HỒ SƠ ĐÃ CHUYỂN LÊN VĂN PHÒNG NHÀ ĐẤT".ToUpper()
                Try 
                    dt = TimKiemHoSoTiepNhan("SearchLuanChuyenTiepNhanDaChuyen", Values, paras)
                Catch ex As Exception
                    strError = ex.Message
                End Try

            Case "DANH SÁCH HỒ SƠ ĐÃ CHUYỂN LÊN VĂN PHÒNG THẨM ĐỊNH".ToUpper()
                Try 
                    dt = TimKiemHoSoTiepNhan("SearchLuanChuyenVPNhaDatDaChuyen", Values, paras)
                Catch ex As Exception
                    strError = ex.Message
                End Try
            Case "DANH SÁCH HỒ SƠ ĐÃ CHUYỂN LÊN PHÒNG TÀI NGUYÊN MÔI TRƯỜNG".ToUpper()
                Try 
                    dt = TimKiemHoSoTiepNhan("SearchLuanChuyenVPThamDinhDaChuyen", Values, paras)
                Catch ex As Exception
                    strError = ex.Message
                End Try
            Case "DANH SÁCH HỒ SƠ ĐÃ CHUYỂN LÊN UB THẨM ĐỊNH".ToUpper()
                Try 
                    dt = TimKiemHoSoTiepNhan("SearchLuanChuyenTNMTDaChuyen", Values, paras)
                Catch ex As Exception
                    strError = ex.Message
                End Try

            Case "DANH SÁCH HỒ SƠ ĐÃ TRẢ VỀ TNMT".ToUpper()
                Try 
                    dt = TimKiemHoSoTiepNhan("SearchLuanChuyenUBThamDinhDaChuyen", Values, paras)
                Catch ex As Exception
                    strError = ex.Message
                End Try
            Case "DANH SÁCH HỒ SƠ ĐÃ TRẢ VỀ VP NHÀ ĐẤT".ToUpper()
                Try 
                    dt = TimKiemHoSoTiepNhan("SearchLuanChuyenTNMTDaChuyenLan2", Values, paras)
                Catch ex As Exception
                    strError = ex.Message
                End Try

            Case "DANH SÁCH HỒ SƠ ĐÃ TRẢ VỀ NƠI TIẾP NHẬN".ToUpper()
                Try 
                    dt = TimKiemHoSoTiepNhan("SearchLuanChuyenVPNhaDatDaChuyenVeNoiTiepNhan", Values, paras)
                Catch ex As Exception
                    strError = ex.Message
                End Try

            Case "DANH SÁCH HỒ SƠ ĐÃ HOÀN TẤT".ToUpper()
                Try 
                    dt = TimKiemHoSoTiepNhan("SearchLuanChuyenHoSoHoanTat", Values, paras)
                Catch ex As Exception
                    strError = ex.Message
                End Try

        End Select
        Return dt
    End Function

End Class
