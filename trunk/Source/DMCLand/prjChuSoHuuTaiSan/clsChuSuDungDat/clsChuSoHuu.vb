Public Class clsChuSoHuu
    Dim Paras() As String = {"@MaChu", "@MaTaiSan"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaChu As String
    Private strMaTaiSan As String

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
    Public Property MaChuSoHuu() As String
        Get
            Return strMaChu
        End Get
        Set(ByVal value As String)
            strMaChu = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property MaTaiSan() As String
        Get
            Return strMaTaiSan
        End Get
        Set(ByVal value As String)
            strMaTaiSan = value
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
                {strMaChu, strMaTaiSan}
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
    Private Function GetData(ByRef dtResults As DataTable, ByVal strStoreProcedureName As String) As String
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            Database.Connection = strConnection ' Nhận chuỗi kết nối Database
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = _
                {strMaChu, strMaTaiSan}
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

#Region "Cập nhật thông tin Chủ sở hữu Tài sản nói chung"
    Public Function UpdateData(ByRef records As String) As String
        Return Me.Execute(records, "spUpdateChuSoHuu")
    End Function
    '
    Public Function InsertData(ByRef records As String) As String
        Return Me.Execute(records, "spInsertChuSoHuu")
    End Function
    Public Function DeleteData(ByRef records As String) As String
        Return Me.Execute(records, "spDeleteChuSoHuu")
    End Function
#End Region

#Region "Truy vấn thông tin Chủ sở hữu Tài sản nói chung"
    Public Function SelectChuSoHuuByGDCN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuByGDCN")
    End Function

    Public Function SelectChuSoHuuByTCDN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuByTCDN")
    End Function

    Public Function SelectChuSoHuuByCQNN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuByCQNN")
    End Function
#End Region

#Region "Truy vấn, cập nhật thông tin Chủ sở hữu NHÀ Ở"
    Public Function UpdateChuSoHuuNhaO(ByRef records As String) As String
        Return Me.Execute(records, "spUpdateChuSoHuuNhaO")
    End Function
    '
    Public Function InsertChuSoHuuNhaO(ByRef records As String) As String
        Return Me.Execute(records, "spInsertChuSoHuuNhaO")
    End Function
    Public Function DeleteChuSoHuuNhaO(ByRef records As String) As String
        Return Me.Execute(records, "spDeleteChuSoHuuNhaO")
    End Function

    Public Function SelectChuSoHuuNhaOByGDCN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuNhaOByGDCN")
    End Function

    Public Function SelectChuSoHuuNhaOByTCDN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuNhaOByTCDN")
    End Function

    Public Function SelectChuSoHuuNhaOByCQNN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuNhaOByCQNN")
    End Function
#End Region

#Region "Truy vấn, cập nhật thông tin Chủ sở hữu CÔNG TRÌNH XÂY DỰNG"
    Public Function UpdateChuSoHuuCongTrinhXayDung(ByRef records As String) As String
        Return Me.Execute(records, "spUpdateChuSoHuuCongTrinhXayDung")
    End Function
    '
    Public Function InsertChuSoHuuCongTrinhXayDung(ByRef records As String) As String
        Return Me.Execute(records, "spInsertChuSoHuuCongTrinhXayDung")
    End Function
    Public Function DeleteChuSoHuuCongTrinhXayDung(ByRef records As String) As String
        Return Me.Execute(records, "spDeleteChuSoHuuCongTrinhXayDung")
    End Function

    Public Function SelectChuSoHuuCongTrinhXayDungByGDCN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuCongTrinhXayDungByGDCN")
    End Function

    Public Function SelectChuSoHuuCongTrinhXayDungByTCDN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuCongTrinhXayDungByTCDN")
    End Function

    Public Function SelectChuSoHuuCongTrinhXayDungByCQNN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuCongTrinhXayDungByCQNN")
    End Function
#End Region

#Region "Truy vấn, cập nhật thông tin Chủ sở hữu CÂY LÂU NĂM"
    Public Function UpdateChuSoHuuCayLauNam(ByRef records As String) As String
        Return Me.Execute(records, "spUpdateChuSoHuuCayLauNam")
    End Function
    '
    Public Function InsertChuSoHuuCayLauNam(ByRef records As String) As String
        Return Me.Execute(records, "spInsertChuSoHuuCayLauNam")
    End Function
    Public Function DeleteChuSoHuuCayLauNam(ByRef records As String) As String
        Return Me.Execute(records, "spDeleteChuSoHuuCayLauNam")
    End Function

    Public Function SelectChuSoHuuCayLauNamByGDCN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuCayLauNamByGDCN")
    End Function

    Public Function SelectChuSoHuuCayLauNamByTCDN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuCayLauNamByTCDN")
    End Function

    Public Function SelectChuSoHuuCayLauNamByCQNN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuCayLauNamByCQNN")
    End Function
#End Region

#Region "Truy vấn, cập nhật thông tin Chủ sở hữu RỪNG CÂY"
    Public Function UpdateChuSoHuuRungCay(ByRef records As String) As String
        Return Me.Execute(records, "spUpdateChuSoHuuRungCay")
    End Function
    '
    Public Function InsertChuSoHuuRungCay(ByRef records As String) As String
        Return Me.Execute(records, "spInsertChuSoHuuRungCay")
    End Function
    Public Function DeleteChuSoHuuRungCay(ByRef records As String) As String
        Return Me.Execute(records, "spDeleteChuSoHuuRungCay")
    End Function

    Public Function SelectChuSoHuuRungCayByGDCN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuRungCayByGDCN")
    End Function

    Public Function SelectChuSoHuuRungCayByTCDN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuRungCayByTCDN")
    End Function

    Public Function SelectChuSoHuuRungCayByCQNN(ByRef dtResults As DataTable) As String
        Return GetData(dtResults, "spSelectChuSoHuuRungCayByCQNN")
    End Function
#End Region
End Class
