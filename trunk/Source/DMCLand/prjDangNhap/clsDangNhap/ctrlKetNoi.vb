Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports System.Windows.Forms
Public Class ctrlKetNoi
    Private sqlConnect As New SqlConnection
    Private strConnection As String
    Private strTenNguoiDung As String
    Private strMaNguoiDung As String
    Private intMaQuyen As Integer
    Private strTenquyen As String
    Private arrDonViHanhChinh() As Integer
    Private strConnectionName As String
    Private strUserID As String
    Private strPassword As String
    Private strDatabaseName As String
    Private strDatabaseNameQuan As String
    Private strServerName As String
    Private arrChucNang() As Integer
    Private strTrangThaiKetNoi As Integer

#Region "Các hàm lấy thuộc tính"
    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

    Public Property UserID() As String
        Get
            Return strUserID
        End Get
        Set(ByVal value As String)
            strUserID = value
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
            Return SQLConnect
        End Get
        Set(ByVal value As SqlConnection)
            sqlConnect = value
        End Set
    End Property
    Public Property TenNguoiDung() As String
        Get
            Return strTenNguoiDung
        End Get
        Set(ByVal value As String)
            strTenNguoiDung = value
        End Set
    End Property
    Public Property MaNguoiDung() As String
        Get
            Return strMaNguoiDung
        End Get
        Set(ByVal value As String)
            strMaNguoiDung = value
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
            Return arrDonViHanhChinh
        End Get
        Set(ByVal value As Integer())
            arrDonViHanhChinh = value
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

    Public Property ChucNang() As Integer()
        Get
            Return arrChucNang
        End Get
        Set(ByVal value As Integer())
            arrChucNang = value
        End Set
    End Property

    Public Property TrangThaiKetNoi() As Integer
        Get
            Return strTrangThaiKetNoi
        End Get
        Set(ByVal value As Integer)
            strTrangThaiKetNoi = value
        End Set
    End Property

#End Region

#Region "Các Sự kiện"
    Public Sub New()
        MyBase.New()
        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()
        txtMaNSD.Text = ""
        txtMatKhau.Text = ""
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
    End Sub

    Private Sub txtMaNSD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaNSD.KeyUp
        If e.KeyData = Keys.Enter Then
            txtMatKhau.Focus()
        End If
    End Sub

    Private Sub txtMatKhau_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMatKhau.KeyUp
        If e.KeyData = Keys.Enter Then
            btDangNhap.Focus()
        End If
    End Sub
    Private Sub btDangNhap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDangNhap.Click
        Try
            'Kiem tra truogn hop nhap thieu thogn tin
            If txtMaNSD.Text = "" Then
                MsgBox("Bạn hãy nhập tên người sử dụng!")
                txtMaNSD.Focus()
            ElseIf txtMatKhau.Text = "" Then
                MsgBox("Bạn hãy nhập mật khẩu!")
                txtMatKhau.Focus()
            Else
                If (Connect() = False) Then
                    If MsgBox("Kết nối không chính xác.Bạn có thay đổi kết nối không?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Thông báo") = MsgBoxResult.Yes Then
                        Dim frm As New frmServer
                        frm.ShowDialog()
                        frm.Activate()
                        Exit Sub
                    End If
                    Exit Sub
                End If

                If sqlConnect.State <> ConnectionState.Open Then
                    sqlConnect.Open()
                End If
                'TRUY VẤN NGƯỜI DÙNG THEO UserName VÀ Password
                Dim dtUser As New DataTable
                Dim User As New clsNguoiDung
                User.Connection = strConnection
                User.UserName = txtMaNSD.Text.Trim
                User.Password = Encrypt(txtMatKhau.Text)
                'Chắc chắn rằng không có lỗi xảy ra
                If (User.GetData(dtUser) <> "") Then
                    MsgBox("Tên đăng nhập hoặc mật khẩu chưa chính xác")
                    txtMaNSD.Focus()
                    Return
                End If
                'Chắc chắn rằng tồn tại bản ghi trả về của kết quả truy vấn
                If (dtUser.Rows.Count < 1) Then
                    MsgBox("Tên đăng nhập hoặc mật khẩu chưa chính xác")
                    txtMaNSD.Focus()
                    Return
                End If
                'Gán giá trị cho các biến
                strMaNguoiDung = dtUser.Rows(0).Item(0).ToString
                intMaQuyen = dtUser.Rows(0).Item(1).ToString
                strTenquyen = dtUser.Rows(0).Item(2).ToString
                'LIỆT KÊ DANH SÁCH ĐƠN VỊ HÀNH CHÍNH MÀ USER ĐÓ CÓ QUYỀN TÁC NGHIỆP
                Dim dtDonViHanhChinh As New DataTable
                Dim DonViHanhChinh As New clsDonViHanhChinh
                DonViHanhChinh.Connection = strConnection
                DonViHanhChinh.MaNguoiDung = strMaNguoiDung
                'Chắc chắn rằng không có lỗi xảy ra
                If (DonViHanhChinh.GetData(dtDonViHanhChinh) = "") Then
                    'Chắc chắn rằng tồn tại bản ghi trả về của kết quả truy vấn
                    If (dtDonViHanhChinh.Rows.Count > 0) Then
                        For i As Integer = 0 To dtDonViHanhChinh.Rows.Count - 1
                            ReDim Preserve arrDonViHanhChinh(i + 1)
                            arrDonViHanhChinh(i) = dtDonViHanhChinh.Rows(i).Item(0)
                        Next
                    End If
                End If
                'LIỆT KÊ DANH SÁCH ĐƠN VỊ HÀNH CHÍNH MÀ USER ĐÓ CÓ QUYỀN TÁC NGHIỆP
                Dim dtChucNang As New DataTable
                Dim ChucNang As New clsChucNang
                ChucNang.Connection = strConnection
                ChucNang.MaNguoiDung = strMaNguoiDung
                'Chắc chắn rằng không có lỗi xảy ra
                If (ChucNang.GetData(dtChucNang) = "") Then
                    'Chắc chắn rằng tồn tại bản ghi trả về của kết quả truy vấn
                    If (dtChucNang.Rows.Count < 1) Then
                        If dtChucNang.Rows.Count > 0 Then
                            For i As Integer = 0 To dtChucNang.Rows.Count - 1
                                ReDim Preserve arrChucNang(i + 1)
                                arrChucNang(i) = dtChucNang.Rows(i).Item(2)
                            Next
                        Else
                            arrChucNang = Nothing
                        End If
                    End If
                End If
                Try
                    strTenNguoiDung = txtMaNSD.Text
                    Me.FindForm.Close()
                Catch ex As Exception
                    MsgBox("Lỗi =>> " & ex.Message)
                End Try
            End If
            sqlConnect.Close()
        Catch ex As Exception
            MsgBox("Lỗi kết nối  " & ex.Message)
            sqlConnect = Nothing
        End Try

    End Sub

    Private Sub btThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThoat.Click
        sqlConnect.Close()
        Me.FindForm.Close()
    End Sub

#End Region

#Region "Các hàm dùng chung"
    Private Function Encrypt(ByVal mess As String) As String
        Dim x As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim bs As Byte()
        bs = System.Text.Encoding.UTF8.GetBytes(mess)
        bs = x.ComputeHash(bs)
        Dim s As New System.Text.StringBuilder
        For Each b As Byte In bs
            s.Append(b.ToString("x2").ToLower)
        Next
        Return s.ToString.ToUpper
    End Function
    ''Public Function Connect() As SqlConnection
    ''    Dim con As SqlConnection
    ''    Dim document As New XmlDocument
    ''    Dim strsql As String = ""
    ''    Dim strPathXML = Application.StartupPath + "\config.xml"
    ''    If File.Exists(strPathXML) = False Then
    ''        MsgBox("File cấu hình kết nối đã bị mất tồn tại")
    ''        Return Nothing
    ''        Exit Function
    ''    End If
    ''    document.Load(strPathXML)
    ''    Dim nodes As XmlNodeList = document.DocumentElement.ChildNodes
    ''    Try
    ''        If document.ChildNodes.Count > 0 Then
    ''            For Each childnode As XmlNode In nodes
    ''                Try
    ''                    If childnode.ChildNodes(3).InnerText <> "" Then
    ''                        'truong hop su dung bao mat theo sql
    ''                        strsql = "Server=" & childnode.ChildNodes(1).InnerText & ";database=" & childnode.ChildNodes(2).InnerText & ";uid=" & childnode.ChildNodes(3).InnerText & " ;pwd=" & childnode.ChildNodes(4).InnerText
    ''                    Else
    ''                        'truong hop su dung bao mat theo windown
    ''                        strsql = "Server=" & childnode.ChildNodes(1).InnerText & ";database=" & childnode.ChildNodes(2).InnerText & ";Integrated Security=SSPI;"
    ''                    End If
    ''                    con = New SqlConnection(strsql)
    ''                    If con.State <> ConnectionState.Open Then
    ''                        con.Open()
    ''                    End If
    ''                    Return con
    ''                    Exit Function
    ''                Catch ex As Exception
    ''                    Return Nothing
    ''                End Try
    ''            Next
    ''        Else
    ''            Return Nothing
    ''        End If
    ''    Catch ex As Exception
    ''        Return Nothing
    ''    End Try
    ''    Return Nothing
    ''End Function

#End Region
    Private Sub ucKetNoi_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        sqlConnect.Close()
        If Not sqlConnect Is Nothing Then
            sqlConnect.Close()
        End If
    End Sub

    Private Sub bntCauHinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntCauHinh.Click
        Dim frm As New frmServer
        frm.UcSerVer1.Connection = strConnection
        frm.ShowDialog()
    End Sub

    Public Sub ucKetNoi()
        Try
            sqlConnect = New SqlConnection
            sqlConnect.ConnectionString = strConnection
            sqlConnect.Open()
            SQLConnection = sqlConnect
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Kết nối cơ sở dữ liệu: " + vbNewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#Region "Test 20100114"
    ''' <summary>
    ''' Test 20100114
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Connect() As Boolean
        Dim blnConnect As Boolean = True
        Try
            With Me
                If Not ReadConfigFile() Then
                    Return False
                End If
                sqlConnect = New SqlConnection
                sqlConnect.ConnectionString = strConnection
                sqlConnect.Open()
            End With
        Catch ex As Exception
            blnConnect = False
            System.Windows.Forms.MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + vbNewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return blnConnect
    End Function
    Public Function GiaiMa(ByVal strChuoiGiaiMa As String) As String
        Dim strKq As String = ""
        Dim arrMangXau() As Char = {}
        arrMangXau = strChuoiGiaiMa.ToCharArray()
        Dim arrMangMaHoa(arrMangXau.Length / 16 - 1) As String
        Dim j As Integer = 0
        For i As Integer = 0 To arrMangXau.Length - 1 Step 2
            arrMangMaHoa(j) = arrMangXau(i) & arrMangXau(i + 1)
            j = j + 1
            i = i + 16
        Next
        For k As Integer = 0 To arrMangMaHoa.Length - 2
            strKq = strKq & Chr(CInt("&H" & (arrMangMaHoa(k))))
        Next
        Return strKq.Substring(0, strKq.Length - 1)
    End Function
    Public Function ReadConfigFile() As Boolean
        Dim strPathXML As String = ""
        Dim xmlDocument As New XmlDocument
        Dim blnReadXML As Boolean = True
        Try
            strPathXML = Application.StartupPath + "\config.xml"
            xmlDocument.Load(strPathXML)
            Dim nodelist As XmlNodeList = xmlDocument.SelectNodes("/Servers/Server[./TenKetNoi/text()]")
            If nodelist.Count > 0 Then
                strServerName = nodelist(0).ChildNodes(1).InnerText
                strDatabaseName = nodelist(0).ChildNodes(2).InnerText
                strDatabaseNameQuan = nodelist(0).ChildNodes(3).InnerText
                strUserID = nodelist(0).ChildNodes(4).InnerText
                strPassword = GiaiMa(nodelist(0).ChildNodes(5).InnerText)
            End If
            If ((strServerName = "") Or (strDatabaseName = "") Or (strUserID = "") Or (strPassword = "")) Then
                blnReadXML = False
                strConnection = ""
            End If
            'strConnection = "Data Source=" & TenMayChu & ";Initial Catalog=" & DatabaseName & " ;User ID=" & UID & " ;PassWord=" & Upass & ""
            strConnection = "SERVER=" & strServerName & ";DATABASE=" & strDatabaseName & " ;UID=" & strUserID & " ;PWD=" & strPassword & ""
        Catch ex As Exception
            blnReadXML = False
        End Try
        Return blnReadXML
    End Function
#End Region
End Class
