'Ngày hiệu chỉnh gần nhất: 200807
'Danh sách người thực hiện: Vũ Lê Thành,
'Mô tả:
'Khai bao mang tham so
Imports DMC.Database
Public Class clsPheDuyet
    Dim Paras() As String = {"@MaHoSoPheDuyet", "@MaHoSoCapGCN", "@KetQuaPheDuyet" _
                             , "@HoTenCanBoPheDuyet", "@NgayPheDuyet", "@YKienPheDuyet", "@LyDo"}

    ' Khai bao mang tham so them trang thai ho so
    Dim ParasTrangThaiHS() As String = {"@Flag", "@MaHoSoCapGCN", "@TrangThai", "@MaDonViHanhChinh"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String
    Private strMaHoSoPheDuyet As String
    Private strMaHoSoCapGCN As String
    Private strKetQuaPheDuyet As String
    Private strHoTenCanBoPheDuyet As String
    Private dtmNgayPheDuyet As String
    Private strYKienPheDuyet As String
    Private strLyDo As String
    Private strFlag As String
    Private strMaDonViHanhChinh As String
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    ' Khai bao thuoc tinh nhan ve Flag
    Public Property Flag() As String
        Get
            Return strFlag
        End Get
        Set(ByVal value As String)
            strFlag = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính nhận thông báo lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai báo thuộc tính nhận Mã Hồ sơ phê duyệt
    Public Property MaHoSoPheDuyet() As String
        Get
            Return strMaHoSoPheDuyet
        End Get
        Set(ByVal value As String)
            strMaHoSoPheDuyet = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Mã hồ sơ cấp GCN
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Khai báo thuộc tính nhận kết quả phê duyệt
    Public Property KetQuaPheDuyet() As String
        Get
            Return strKetQuaPheDuyet
        End Get
        Set(ByVal value As String)
            strKetQuaPheDuyet = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Họ tên cán bộ Phê duyệt
    Public Property HoTenCanBoPheDuyet() As String
        Get
            Return strHoTenCanBoPheDuyet
        End Get
        Set(ByVal value As String)
            strHoTenCanBoPheDuyet = value
        End Set
    End Property
    'Khai báo thuộc tính nhận Ngày phê duyệt
    Public Property NgayPheDuyet() As String
        Get
            Return dtmNgayPheDuyet
        End Get
        Set(ByVal value As String)
            dtmNgayPheDuyet = value
        End Set
    End Property
    'Khai báo thuộc tính ý kiến phê duyệt
    Public Property YKienPheDuyet() As String
        Get
            Return strYKienPheDuyet
        End Get
        Set(ByVal value As String)
            strYKienPheDuyet = value
        End Set
    End Property
    Public Property LyDo() As String
        Get
            Return strLyDo
        End Get
        Set(ByVal value As String)
            strLyDo = value
        End Set
    End Property
    ''' <summary>
    ''' Thêm mới thông tin Phê duyệt theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function InsertThongTinPheDuyetByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spInsertThongTinPheDuyetByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Cập nhật thông tin Phê duyệt theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Public Function UpdateThongTinPheDuyetByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongTinPheDuyetByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Xóa thông tin Phê duyệt theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinPheDuyetByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteThongTinPheDuyetByMaHoSoCapGCN", str)
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
                {strMaHoSoPheDuyet, strMaHoSoCapGCN, strKetQuaPheDuyet _
                 , strHoTenCanBoPheDuyet, dtmNgayPheDuyet, strYKienPheDuyet, strLyDo}
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
    ' Tao phuong thuc thuc thi them trang thai ho so
    Private Function ExecuteTrangThaiHS(ByRef strStoreProcedureName As String, ByRef records As String) As String
        Try
            ' Khai bao va khoi tao lop thao tac voi database 
            Dim DataBase As New clsDatabase
            ' Nhan ve chuoi ket noi 
            DataBase.Connection = strConnection
            If DataBase.OpenConnection() = True Then
                ' Khai bao mang gia tri
                Dim ValuesTrangThaiHS() As String = {0, strMaHoSoCapGCN, strFlag, strMaDonViHanhChinh}
                If (ValuesTrangThaiHS.Length <> ParasTrangThaiHS.Length) Then
                    System.Windows.Forms.MessageBox.Show("Mảng giá trị truyền vào không tương thích với mảng tham số", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng giá trị truyền vào không tương thích với mảng tham số"
                End If
                ' Goi phuong thuc thuc thi cau lenh SQL 
                DataBase.ExecuteSP(strStoreProcedureName, ParasTrangThaiHS, ValuesTrangThaiHS, records)
                strError = DataBase.Err
                DataBase.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ' Phuong thuc cap nhat thong tin Trang Thai Ho So
    Public Function UpdateTrangThaiHS() As String
        Dim records As String = ""
        Return Me.ExecuteTrangThaiHS("spUpdateTrangThaiHoSoCapGCN", records)
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
                {strMaHoSoPheDuyet, strMaHoSoCapGCN, strKetQuaPheDuyet _
                 , strHoTenCanBoPheDuyet, dtmNgayPheDuyet, strYKienPheDuyet, strLyDo}
                'Kiểm tra tính tương thích của cơ sở dữ liệu
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Mảng giá trị truyền vào không tương thích với mảng tham số", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng giá trị truyền vào không tương thích với mảng tham số"
                End If
                'Gọi phương thức thực thi Thủ tục truy vấn cơ sở dữ liệu
                Database.getValue(strRecords, "spSelectThongTinPheDuyetByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function SelectTuDienTrangThaiPheDuyet(ByRef strRecords As DataTable) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Khai báo nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim arrValues() As String = {}
                Dim arrParas() As String = {}
                'Kiểm tra tính tương thích của cơ sở dữ liệu
                If (arrParas.Length <> arrValues.Length) Then
                    System.Windows.Forms.MessageBox.Show("Mảng giá trị truyền vào không tương thích với mảng tham số", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng giá trị truyền vào không tương thích với mảng tham số"
                End If
                'Gọi phương thức thực thi Thủ tục truy vấn cơ sở dữ liệu
                Database.getValue(strRecords, "spSelectTuDienTrangThaiPheDuyet", arrParas, arrValues)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
