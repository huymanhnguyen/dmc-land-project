'Ngày hiệu chỉnh gần nhất: 200807
'Danh sách người thực hiện: Vũ Lê Thành,
'Mô tả:
'Khai bao mang tham so
Imports DMC.Database
Public Class clsBangMa
    Dim Paras() As String = {"@KyHieu", "@MoTa", "@Nhom"}
    Dim paras_Xoa() As String = {"@Ma"}
    Dim parasCoQuanDK() As String = {"@MaCoQuanDangKyBD"}
    Dim paras_Sua() As String = {"@Ma", "@KyHieu", "@MoTa", "@nhom"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strMa As String = ""
    Private strError As String = ""
    Private strKyHieu As String = ""
    Private strMoTa As String = ""
    Private strNhom As String = ""
    Private strDonViDangKy As String = ""
    'Khai báo thuộc tính gán chuỗi kết nối
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

    Public Property Get_Ma() As String
        Get
            Return strMa
        End Get
        Set(ByVal value As String)
            strMa = value
        End Set
    End Property
    Public Property DonViDangKy() As String
        Get
            Return strDonViDangKy
        End Get
        Set(ByVal value As String)
            strDonViDangKy = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien shBang
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai bao thuoc tinh ung voi bien KyHieu
    Public Property KyHieu() As String
        Get
            Return strKyHieu
        End Get
        Set(ByVal value As String)
            strKyHieu = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien strMoTa
    Public Property MoTa() As String
        Get
            Return strMoTa
        End Get
        Set(ByVal value As String)
            strMoTa = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien strNhom
    Public Property Nhom() As String
        Get
            Return strNhom
        End Get
        Set(ByVal value As String)
            strNhom = value
        End Set
    End Property



#Region "ĐỐI TƯỢNG SỬ DỤNG ĐẤT"

    ''' <summary>
    ''' Xóa ĐỐI TƯỢNG SỬ DỤNG ĐẤT ở bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteDoiTuongSuDungDat(ByRef intRecords As Integer) As String
        Return Me.Execute("spDeleteTuDienDoiTuongSuDungDat", intRecords)
    End Function

    ''' <summary>
    ''' Sửa ĐỐI TƯỢNG SỬ DỤNG ĐẤT Ở bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateDoiTuongSuDungDat(ByRef intRecords As Integer) As String
        Return Me.Execute("spUpdateTuDienDoiTuongSuDungDat", intRecords)
    End Function

    ''' <summary>
    ''' Thêm ĐỐI TƯỢNG SỬ DỤNG ĐẤT Ở bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertDoiTuongSuDungDat(ByRef intRecords As Integer) As String
        Return Me.Execute("spInsertTuDienDoiTuongSuDungDat", intRecords)
    End Function
    ''' <summary>
    ''' Truy vấn ĐỐI TƯỢNG SỬ DỤNG ĐẤT
    ''' </summary>
    ''' <param name="dtResults"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectDoiTuongSuDungDat(ByRef dtResults As DataTable) As String
        Return Me.GetData("spSelectTuDienDoiTuongSuDungDat", dtResults)
    End Function

#End Region

#Region "TỪ ĐIỂN NGHĨA VỤ TÀI CHÍNH"

    ''' <summary>
    ''' Xóa NGHĨA VỤ TÀI CHÍNH sử dụng đất vào bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteNghiaVuTaiChinh(ByRef intRecords As Integer) As String
        Return Me.Execute("spDeleteTuDienNghiaVuTaiChinh", intRecords)
    End Function

    ''' <summary>
    ''' Sửa NGHĨA VỤ TÀI CHÍNH sử dụng đất vào bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateNghiaVuTaiChinh(ByRef intRecords As Integer) As String
        Return Me.Execute("spUpdateTuDienNghiaVuTaiChinh", intRecords)
    End Function

    ''' <summary>
    ''' Thêm NGHĨA VỤ TÀI CHÍNH sử dụng đất vào bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertNghiaVuTaiChinh(ByRef intRecords As Integer) As String
        Return Me.Execute("spInsertTuDienNghiaVuTaiChinh", intRecords)
    End Function
    ''' <summary>
    ''' Truy vấn TỪ ĐIỂN NGHĨA VỤ TÀI CHÍNH
    ''' </summary>
    ''' <param name="dtResults"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectNghiaVuTaiChinh(ByRef dtResults As DataTable) As String
        Return Me.GetData("spSelectTuDienNghiaVuTaiChinh", dtResults)
    End Function

#End Region

#Region "NGUỒN GỐC SỬ DỤNG ĐẤT"

    ''' <summary>
    ''' Xóa NGUỒN GỐC sử dụng đất vào bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteNguonGocSuDung(ByRef intRecords As Integer) As String
        Return Me.Execute("spDeleteTuDienNguonGocSuDung", intRecords)
    End Function

    ''' <summary>
    ''' Sửa NGUỒN GỐC sử dụng đất vào bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateNguonGocSuDung(ByRef intRecords As Integer) As String
        Return Me.Execute("spUpdateTuDienNguonGocSuDung", intRecords)
    End Function

    ''' <summary>
    ''' Thêm NGUỒN GỐC sử dụng đất vào bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertNguonGocSuDung(ByRef intRecords As Integer) As String
        Return Me.Execute("spInsertTuDienNguonGocSuDung", intRecords)
    End Function
    ''' <summary>
    ''' Truy vấn TỪ ĐIỂN NGUỒN GỐC SỬ DỤNG ĐẤT
    ''' </summary>
    ''' <param name="dtResults"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectNguonGocSuDung(ByRef dtResults As DataTable) As String
        Return Me.GetData("spSelectTuDienNguonGocSuDung", dtResults)
    End Function

#End Region

#Region "Mục đích sử dụng đất"

    ''' <summary>
    ''' Xóa mục đích sử dụng đất vào bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteMucDichSuDung(ByRef intRecords As Integer) As String
        Return Me.Execute("spDeleteTuDienMucDichSuDung", intRecords)
    End Function

    ''' <summary>
    ''' Sửa mục đích sử dụng đất vào bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateMucDichSuDung(ByRef intRecords As Integer) As String
        Return Me.Execute("spUpdateTuDienMucDichSuDung", intRecords)
    End Function

    ''' <summary>
    ''' Thêm mục đích sử dụng đất vào bảng từ điển
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertMucDichSuDung(ByRef intRecords As Integer) As String
        Return Me.Execute("spInsertTuDienMucDichSuDung", intRecords)
    End Function

    Public Function SelectMucDichSuDung(ByRef dtResults As DataTable) As String
        Return Me.GetData("spSelectTuDienMucDichSuDung", dtResults)
    End Function

#End Region

#Region "Loại hình biến động"

    ''' <summary>
    ''' Xóa Từ điển Loại hình biến động
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteTuDienLoaiHinhBienDong(ByRef intRecords As Integer) As String
        Return Me.Execute("spDeleteTuDienLoaiHinhBienDong", intRecords)
    End Function

    Public Function DeleteTuDienLoaiHinhBienDong_Moi(ByRef intRecords As Integer) As String
        Return Me.Execute_Xoa("spDeleteTuDienLoaiHinhBienDong_Moi", intRecords)
    End Function


    ''' <summary>
    ''' Sửa Từ điển loại hình biến động
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateTuDienLoaiHinhBienDong(ByRef intRecords As Integer) As String
        Return Me.Execute_Sua("spUpdateTuDienLoaiHinhBienDong", intRecords)
    End Function

    ''' <summary>
    ''' Thêm Từ điển loại hình biến động
    ''' </summary>
    ''' <param name="intRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertTuDienLoaiHinhBienDong(ByRef intRecords As Integer) As String
        Return Me.Execute("spInsertTuDienLoaiHinhBienDong", intRecords)
    End Function

    Public Function SelectTuDienLoaiHinhBienDong(ByRef dtResults As DataTable) As String
        Return Me.GetLoaiHinhBienDong("sp_SelectTuDienLoaiHinhBienDong", dtResults)
    End Function

#End Region

    Private Function Execute(ByVal strStoreProcedure As String, ByRef records As Integer) As String
        Try
            'Khoi tao doi tuong clsSqlDatabase
            Dim Database As New clsDatabase
            'Neu ket noi co so du lieu thanh cong
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Values() As String = _
                {strKyHieu, strMoTa, strNhom}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP(strStoreProcedure, Paras, Values, records)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    Private Function Execute_Xoa(ByVal strStoreProcedure As String, ByRef records As Integer) As String
        Try
            'Khoi tao doi tuong clsSqlDatabase
            Dim Database As New clsDatabase
            'Neu ket noi co so du lieu thanh cong
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Values() As String = _
                 {strMa}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (paras_Xoa.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP(strStoreProcedure, paras_Xoa, Values, records)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    Private Function Execute_Sua(ByVal strStoreProcedure As String, ByRef records As Integer) As String
        Try
            'Khoi tao doi tuong clsSqlDatabase
            Dim Database As New clsDatabase
            'Neu ket noi co so du lieu thanh cong
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Values() As String = _
                 {strMa,strKyHieu,strMoTa,strNhom}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (paras_Sua.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP(strStoreProcedure, paras_Sua, Values, records)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable) As String
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = _
                    {strKyHieu, strMoTa, strNhom}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtResults, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    Private Function GetLoaiHinhBienDong(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable) As String
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = {strDonViDangKy}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (parasCoQuanDK.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtResults, strStoreProcedureName, parasCoQuanDK, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    'Lay toan bo thong tin cua MaCoQuanThucHien
    Private Function GetMaCoQuanThucHien(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable) As String
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = _
                    {strKyHieu, strMoTa, strNhom}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtResults, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    'Hien thi toan bo thong tin MaCoQuanThucHien

    Public Function SelectMaCoQuanThucHien(ByRef dtResults As DataTable) As String
        Return Me.GetMaCoQuanThucHien("spSelectMaCoQuanThucHienChinhLy", dtResults)
    End Function

    'Ham thuc thi MaCoQuanThucHien

    Private Function ExecuteMaCoQuanThucHien(ByVal strStoreProcedure As String, ByRef records As Integer) As String
        Try
            'Khoi tao doi tuong clsSqlDatabase
            Dim Database As New clsDatabase
            'Neu ket noi co so du lieu thanh cong
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Values() As String = _
                {strKyHieu, strMoTa, strNhom}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP(strStoreProcedure, Paras, Values, records)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    'Them MaCoQuanThucHien

    Public Function InsertMaCoQuanThucHien(ByRef intRecords As Integer) As String
        Return Me.Execute("spInsertMaCoQuanThucHien", intRecords)
    End Function

    'Update MaCoQuanThucHien

    Public Function UpdateMaCoQuanThucHien(ByRef intRecords As Integer) As String
        Return Me.Execute("spUpdateMaCoQuanThucHien", intRecords)
    End Function

    ' Delete MaCoQuanThucHien

    Public Function DeleteMaCoQuanThucHien(ByRef intRecords As Integer) As String
        Return Me.Execute("spDeleteMaCoQuanThucHien", intRecords)
    End Function
End Class


