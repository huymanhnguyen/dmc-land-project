Imports DMC.Database
Public Class clsXacNhan
    Dim Paras() As String = {"@Flag", "@MaHoSoCapGCN", "@MaDonViHanhChinh"}
    'khai bao bien lay ve chuoi ket noi
    Private strConnection As String = ""
    'khai bao chuoi nhan ve MaHoSoCapGCN
    Private strMaHoSoCapGCN As String = ""
    'khai bao bien nhan ve loi
    Private strError As String = ""
    Private strMaXacNhan As Integer
    Private strMaDonViHanhChinh As String = ""

    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Public Property MaXacNhan() As String
        Get
            Return strMaXacNhan
        End Get
        Set(ByVal value As String)
            strMaXacNhan = value
        End Set
    End Property
    'khai bao thuoc tinh nhan ve chuoi ket noi DataBase

    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'khai bao thuoc tinh nhan ve MaHoSoCapGCN
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    'khai bao thuoc tinh nhan ve loi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Tao ham thuc thi cau lenh SQL

    Public Function Excecute(ByVal strStoreProcedureName As String, ByRef records As String) As String
        Try


            'khai bao va khoi tao lop truy xuat DaTaBase
            Dim DataBase As New clsDatabase
            'nhan chuoi ket noi 
            DataBase.Connection = strConnection
            'Neu cap nhat du lieu thanh cong thi thuc thi viec sau
            If DataBase.OpenConnection = True Then
                'khai bao mang nhan gia tri
                Dim Values() As String = {strMaXacNhan, strMaHoSoCapGCN, strMaDonViHanhChinh}
                'kiem tra du lieu dau vao
                If Paras.Length <> Values.Length Then
                    System.Windows.Forms.MessageBox.Show("Mảng giá trị truyền vào không tương thích với mảng tham số", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng giá trị truyền vào không tương thích với mảng tham số"
                End If
                DataBase.ExecuteSP(strStoreProcedureName, Paras, Values, records)
                strError = DataBase.Err
                DataBase.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    'tao ham cap nhat thong tin TrangThaiHoSoCapGCN dua vao MaHoSoCapGCN
    Public Function UpdateTrangThaiHoSoCapGCN() As String
        Dim str As String = ""
        Return Excecute("spUpdateTrangThaiHoSoCapGCN", str)
    End Function

    Public Function GetData(ByVal sp As String, ByVal Values() As String, ByVal Paras() As String) As DataTable
        Dim strError As String = ""
        Dim MyTable As New DataTable
        Try
            'khai bao khoi tao doi tuong ket noi
            Dim DataBase As New clsDatabase
            DataBase.Connection = strConnection
            If DataBase.OpenConnection Then
                If (Paras.Length <> Values.Length) Then
                    Return Nothing
                End If
                DataBase.getValue(MyTable, sp, Paras, Values)
                DataBase.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return MyTable
    End Function

End Class
