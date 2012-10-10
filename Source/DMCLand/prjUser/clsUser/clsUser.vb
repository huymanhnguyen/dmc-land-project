Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO
Imports System.Windows.Forms
Public Class clsUser
    Private sqlConnect As SqlClient.SqlConnection
    Private strConnection As String
    Private strMaUser As String
    Private strUserName As String
    Private intMaQuyen As Integer
    Private intArrayDonViHanhChinh() As Integer
    Private strConnectionName As String
    Private strServerName As String
    Private strDatabaseName As String
    Private dtmLogin As DateTime
    Private dtmLogout As DateTime
    Private strUserID As String = "sa"
    Private strPassword As String = ""
    Private intArrayChucNang() As Integer
    Private intDonViHanhChinhHienThoi As Integer

    Public Sub New(Optional ByVal sqlConnection As SqlConnection = Nothing, Optional ByVal MaUS As Integer = 0, Optional ByVal TenUS As String = "", Optional ByVal MaQuyen As Integer = 0, Optional ByVal arrMaDonViHanhChinh As Integer() = Nothing, Optional ByVal CurDVHC As Integer = 0, Optional ByVal ConnectionName As String = "", Optional ByVal ServerName As String = "", Optional ByVal DatabaseName As String = "")
        sqlConnect = sqlConnection
        MaUS = strMaUser
        TenUS = strUserName
        intMaQuyen = MaQuyen
        intArrayDonViHanhChinh = arrMaDonViHanhChinh
        intDonViHanhChinhHienThoi = CurDVHC
        strConnectionName = ConnectionName
        strServerName = ServerName
        strDatabaseName = DatabaseName
    End Sub

    Public Property UserID() As String
        Get
            Return strUserID
        End Get
        Set(ByVal value As String)
            strUserID = value
        End Set
    End Property

    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return strPassword
        End Get
        Set(ByVal value As String)
            strPassword = value
        End Set
    End Property

    Public Property SQLConnection() As SqlConnection
        Get
            Return sqlConnect
        End Get
        Set(ByVal value As SqlConnection)
            sqlConnect = value
        End Set
    End Property

    Public Property MaUser() As String
        Get
            Return strMaUser
        End Get
        Set(ByVal value As String)
            strMaUser = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return strUserName
        End Get
        Set(ByVal value As String)
            strUserName = value
        End Set
    End Property

    Public Property MaQuyen() As Integer
        Get
            Return intMaQuyen
        End Get
        Set(ByVal value As Integer)
            intMaQuyen = value
        End Set
    End Property

    Public Property DonViHanhChinh() As Integer()
        Get
            Return intArrayDonViHanhChinh
        End Get
        Set(ByVal value As Integer())
            If intMaQuyen = 1 Then
                QT()
            Else
                ReDim intArrayDonViHanhChinh(value.Length)
                intArrayDonViHanhChinh = value
            End If

        End Set
    End Property

    Public Property ConnectionName() As String
        Get
            Return strConnectionName
        End Get
        Set(ByVal value As String)
            strConnectionName = value
        End Set
    End Property

    Public Property ServerName() As String
        Get
            Return strServerName
        End Get
        Set(ByVal value As String)
            strServerName = value
        End Set
    End Property

    Public Property DatabaseName() As String
        Get
            Return strDatabaseName
        End Get
        Set(ByVal value As String)
            strDatabaseName = value
        End Set
    End Property

    Public Property LoginDateTime() As DateTime
        Get
            Return dtmLogin
        End Get
        Set(ByVal value As DateTime)
            dtmLogin = value
        End Set
    End Property

    Public Property LogOutDateTime() As DateTime
        Get
            Return dtmLogout
        End Get
        Set(ByVal value As DateTime)
            dtmLogout = value
        End Set
    End Property

    Public Property ChucNang() As Integer()
        Get
            Return intArrayChucNang
        End Get
        Set(ByVal value As Integer())
            ReDim intArrayChucNang(value.Length)
            intArrayChucNang = value
        End Set
    End Property
    Public Property DonViHanhChinhHienThoi() As Integer
        Get
            Return intDonViHanhChinhHienThoi
        End Get
        Set(ByVal value As Integer)
            intDonViHanhChinhHienThoi = value
        End Set
    End Property

    Private Sub QT()
        Dim cmd As New SqlCommand '("select madonvihanhchinh from tbltudiendonvihanhchinh where matinh<>0 and mahuyen=0 and maxa=0", sqlCon)
        Dim datAdap As New SqlDataAdapter
        Dim ds As New DataSet
        cmd = New SqlCommand
        With cmd
            .Connection = sqlConnect
            .CommandText = "spGetMaDvHC"
            .CommandType = CommandType.StoredProcedure
        End With
        datAdap.SelectCommand = cmd
        datAdap.Fill(ds)
        If sqlConnect.State <> ConnectionState.Open Then
            sqlConnect.Open()
        End If
        Dim dem As Integer = 0
        Try
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dem = dem + 1
                ReDim Preserve intArrayDonViHanhChinh(dem)
                intArrayDonViHanhChinh(dem - 1) = ds.Tables(0).Rows(i).Item(0)
            Next
        Catch ex As Exception
        End Try
        cmd.Dispose()
    End Sub

    Public Sub LogOut()
        dtmLogout = Now
        QuanTriLog()
        sqlConnect.Dispose()
        sqlConnect = Nothing
        strMaUser = ""
        strUserName = ""
        intMaQuyen = 0
        intArrayDonViHanhChinh = Nothing
        strConnectionName = ""
        strServerName = ""
        strDatabaseName = ""
        intArrayChucNang = Nothing
    End Sub
    'Thanh Test
    Public Sub QuanTriLog()
        Dim strpathXML As String
        Dim document As New XmlDocument
        strpathXML = Application.StartupPath + "\log.xml"
        'Dim document As New XmlDocument
        If File.Exists(strpathXML) = False Then
            Dim strWrite As New StreamWriter(strpathXML)
            strWrite.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            strWrite.WriteLine("<Users>")
            strWrite.WriteLine("</Users>")
            strWrite.Close()
        End If

l:
        Try
            document.Load(strpathXML)
            Dim ItemNode As XmlNode
            ItemNode = document.CreateElement("User")
            ' Thêm đặc tính.     
            Dim Attribute As XmlAttribute
            Attribute = document.CreateAttribute("id")
            Attribute.Value = document.ChildNodes(1).ChildNodes.Count + 1
            ItemNode.Attributes.Append(Attribute)
            ' Tạo và thêm các phần tử con cho nút này.       
            Dim TenDN, MaQuyen, Login, Logout As XmlNode
            TenDN = document.CreateElement("TenUser")
            MaQuyen = document.CreateElement("MaQuyen")
            Login = document.CreateElement("Login")
            Logout = document.CreateElement("Logout")
            ItemNode.AppendChild(TenDN)
            ItemNode.AppendChild(MaQuyen)
            ItemNode.AppendChild(Login)
            ItemNode.AppendChild(Logout)
            ' Thêm dữ liệu text.  
            TenDN.AppendChild(document.CreateTextNode(UserName))
            MaQuyen.AppendChild(document.CreateTextNode(intMaQuyen))
            Login.AppendChild(document.CreateTextNode(LoginDateTime))
            Logout.AppendChild(document.CreateTextNode(LogOutDateTime))
            ' Thêm phần tử mới. Trong trường hợp này, chúng ta   
            ' cho nó làm con ở cuối danh sách item.   
            document.DocumentElement.AppendChild(ItemNode)
            ' Lưu tài liệu.      
        Catch ex As Exception
            Dim strWrite As New StreamWriter(strpathXML)
            strWrite.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            strWrite.WriteLine("<Users>")
            strWrite.WriteLine("</Users>")
            strWrite.Close()
            GoTo l
        End Try
        document.Save(strpathXML)
    End Sub
End Class
