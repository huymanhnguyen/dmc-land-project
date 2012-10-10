Imports DMC.Database
Public Class clsTuDienHDXD
    Dim Paras() As String = {"@MaNguoiXetDuyet", "@MaHoSoCapGCN", "@index"}

    ' Khai bao mang tham so Trang Thai Xet Duyet Cap Co So
    Dim Para() As String = {"@Flag", "@MaHoSoCapGCN", "@MaDonViHanhChinh"}

    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaNguoiXetDuyet As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strMaDonViHanhChinh As String = ""

    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
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
    Public Property MaNguoiXetDuyet() As String
        Get
            Return strMaNguoiXetDuyet
        End Get
        Set(ByVal value As String)
            strMaNguoiXetDuyet = value
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

    Private strIndex As Integer
    Public Property Index() As Integer
        Get
            Return strIndex
        End Get
        Set(ByVal value As Integer)
            strIndex = value
        End Set
    End Property

    Public Function Execute(ByRef records As String, ByVal strStoreProcedureName As String) As String
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công thị thực thi phát biểu SQL
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaNguoiXetDuyet, strMaHoSoCapGCN, strIndex}
                'Kiểm tra tính tương đồng của 2 mảng dữ liệu
                If (Paras.Length <> Values.Length) Then
                    Return "Giá trị truyền vào không tương thích"
                End If
                'Gọi phương thức thực thi cơ sở dữ liệu của đối tượng clsDatabase
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, records)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    'Public Function UpdateData(ByRef records As String) As String
    '    Return Me.Execute(records, "spUpdateHoiDongXetDuyet")
    'End Function
    Public Function UpdateViTrData(ByRef records As String) As String
        Return Me.Execute(records, "spUpdateTuDienHDXD")
    End Function
    Public Function InsertData(ByRef records As String) As String
        Return Me.Execute(records, "spInsertTuDienHDXD")
    End Function
    Public Function DeleteData(ByRef records As String) As String
        Return Me.Execute(records, "spDeleteTuDienHDXD")
    End Function
    Public Function InSertDataChuyenHDXD(ByRef records As String) As String
        Return Me.Execute(records, "spChuyenTiepTuDienHDXD")
    End Function

    Private Function GetData(ByRef dtResults As DataTable, ByVal strStoreProcedureName As String) As String
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            Database.Connection = strConnection ' Nhận chuỗi kết nối Database
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = _
                {strMaNguoiXetDuyet, strMaHoSoCapGCN, strIndex}
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
    ' Tao ham thuc thi cau lenh SQL cap nhat trang thai Xet Duyet Cap Co So

    Public Function ExcecuteXetDuyet(ByRef record As String) As String
        Try
            ' Khai bao va khoi tao doi tuong thao tac voi DataBase 

            Dim DataBase As New clsDatabase

            ' Thuc hien mo ket noi DataBase 

            DataBase.Connection = strConnection

            If DataBase.OpenConnection = True Then
                Dim ValuesXetDuyet() As String = {"3", strMaHoSoCapGCN, strMaDonViHanhChinh}
                DataBase.ExecuteSP("spUpdateTrangThaiHoSoCapGCN", Para, ValuesXetDuyet, record)
                strError = DataBase.Err
                DataBase.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function SelectHoiDongXetDuyet(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectTuDienHDXD")
    End Function
End Class
