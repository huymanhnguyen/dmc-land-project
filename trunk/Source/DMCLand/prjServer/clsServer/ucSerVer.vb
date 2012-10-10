Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO
Imports System.String
Imports System.Windows.Forms
Public Class ucSerVer
    Private strConnectionName As String
    Private strServerName As String
    Private strDataBase As String
    Private strDataBaseQuan As String
    Private strUserID As String
    Private strPasswordID As String
    Private sqlConnect As SqlConnection
    Private strPathXML As String
    Private strSQL As String
    Private xmlDocument As New XmlDocument
    'Private strMyForm As Form
    Private blnTestConection As Boolean
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

#Region "Các sự kiện"
    Public Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        strPathXML = Application.StartupPath + "\config.xml"
        Try
            xmlDocument.Load(strPathXML)
            txtTenKetNoi.Text = strConnectionName
            cmbDatabases.Text = strDataBase
            cmbDatabasesQuan.Text = strDataBaseQuan
            txtMayChu.Text = strServerName
            txtUser.Text = strUserID
            txtPass.Text = strPasswordID

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnChapNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChapNhan.Click
        Try
            If txtTenKetNoi.Text.Trim = "" Then
                MessageBox.Show("Nhập chuỗi kết nối", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtMayChu.Text.Trim = "" Then
                MessageBox.Show("Nhập tên máy chủ", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If cmbDatabases.Text.Trim = "" Then
                MessageBox.Show("Nhập tên cơ sở dữ liệu", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If blnTestConection Then
                Dim strwt As New StreamWriter(strPathXML)
                strwt.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
                strwt.WriteLine("<Servers>")
                strwt.WriteLine("</Servers>")
                strwt.Close()
                xmlDocument.Load(strPathXML)
                Dim ItemNode As XmlNode
                ItemNode = xmlDocument.CreateElement("Server")
                ' Thêm đặc tính.     
                Dim Attribute As XmlAttribute
                Attribute = xmlDocument.CreateAttribute("id")
                Attribute.Value = xmlDocument.ChildNodes(1).ChildNodes.Count + 1
                ItemNode.Attributes.Append(Attribute)

                ' Tạo và thêm các phần tử con cho nút này.       
                Dim TenKT, NameNode, DatabaseNode, DatabaseNodeQuan, UserNode, PassNode As XmlNode
                TenKT = xmlDocument.CreateElement("TenKetNoi")
                NameNode = xmlDocument.CreateElement("Name")
                DatabaseNode = xmlDocument.CreateElement("Database")
                DatabaseNodeQuan = xmlDocument.CreateElement("DatabaseQuan")
                If radTaiKhoanSQL.Checked Then
                    'truong hop ket noi bagn sql su dung pass va user
                    UserNode = xmlDocument.CreateElement("UserID")
                    PassNode = xmlDocument.CreateElement("Password")
                Else

                End If
                ItemNode.AppendChild(TenKT)
                ItemNode.AppendChild(NameNode)
                ItemNode.AppendChild(DatabaseNode)
                ItemNode.AppendChild(DatabaseNodeQuan)
                If radTaiKhoanSQL.Checked Then
                    'Trường hợp dùng mật khẩu SQL
                    '' Test 
                    'UserNode = Nothing
                    'PassNode = Nothing
                    '' EndTest
                    ItemNode.AppendChild(UserNode)
                    ItemNode.AppendChild(PassNode)
                End If

                ' Thêm dữ liệu text.  
                TenKT.AppendChild(xmlDocument.CreateTextNode(txtTenKetNoi.Text))
                NameNode.AppendChild(xmlDocument.CreateTextNode(txtMayChu.Text))
                DatabaseNode.AppendChild(xmlDocument.CreateTextNode(cmbDatabases.Text))
                DatabaseNodeQuan.AppendChild(xmlDocument.CreateTextNode(cmbDatabasesQuan.Text))
                If radTaiKhoanSQL.Checked Then
                    ''Test 
                    'UserNode = Nothing
                    'PassNode = Nothing
                    ''EndTest
                    UserNode.AppendChild(xmlDocument.CreateTextNode(txtUser.Text))
                    PassNode.AppendChild(xmlDocument.CreateTextNode(MaHoa(txtPass.Text)))
                End If

                ' Thêm phần tử mới. Trong trường hợp này, chúng ta   
                ' cho nó làm con ở cuối danh sách item.   
                xmlDocument.DocumentElement.AppendChild(ItemNode)
                'Lưu tài liệu.      
                xmlDocument.Save(strPathXML)
                MessageBox.Show("Cấu hình kết nối CSDL thành công !", "Cấu hình kết nối", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                FindForm.Close()
                'strMyForm.Hide()
            End If

        Catch ex As Exception
            sqlConnect = Nothing
            MsgBox("Kết nối này không hợp lệ" & ex.Message)
        End Try
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        Dim nodelist As XmlNodeList = xmlDocument.SelectNodes("/Servers/Server[./TenKetNoi/text() = '" + txtTenKetNoi.Text + "']")
        Try
            If nodelist.Count > 0 Then
                xmlDocument.DocumentElement.RemoveChild(nodelist(0))
                xmlDocument.Save(strPathXML)
                txtTenKetNoi.Text = ""
                txtMayChu.Text = ""
                cmbDatabases.Text = ""
                cmbDatabasesQuan.Text = ""
                txtUser.Text = ""
                txtPass.Text = ""
                MessageBox.Show("Đã xoá kết nối thành công !", "Xoá kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTenKetNoi_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTenKetNoi.KeyUp
        Dim nodelist As XmlNodeList = xmlDocument.SelectNodes("/Servers/Server[./TenKetNoi/text() = '" + txtTenKetNoi.Text + "']")
        If nodelist.Count > 0 Then
            txtMayChu.Text = nodelist(0).ChildNodes(1).InnerText
            cmbDatabases.Text = nodelist(0).ChildNodes(2).InnerText
            cmbDatabasesQuan.Text = nodelist(0).ChildNodes(3).InnerText
            Try
                'truong hop ko co 
                radTaiKhoanSQL.Checked = True
                txtUser.Text = nodelist(0).ChildNodes(4).InnerText
                txtPass.Text = GiaiMa(nodelist(0).ChildNodes(5).InnerText)
            Catch ex As Exception

            End Try

        Else
            txtMayChu.Text = ""
            cmbDatabases.Text = ""
            cmbDatabasesQuan.Text = ""
            txtUser.Text = ""
            txtPass.Text = ""
        End If
        If e.KeyCode = Keys.Enter Then
            txtMayChu.Focus()
        End If
        strConnectionName = txtTenKetNoi.Text
    End Sub

    Private Sub txtMayChu_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            cmbDatabases.Focus()
        End If
    End Sub

    Private Sub cmbDatabases_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbDatabases.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtUser.Focus()
        End If
    End Sub

    Private Sub txtTenKetNoi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenKetNoi.TextChanged
        strConnectionName = txtTenKetNoi.Text
    End Sub

    Private Sub txtDataBase_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        strDataBase = cmbDatabases.Text
    End Sub

    Private Sub txtMayChu_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        strServerName = txtMayChu.Text
    End Sub

    Private Sub ucSerVer_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        Try
            xmlDocument.Load(strPathXML)
            txtTenKetNoi.Text = strConnectionName
            loadTenKetNoi()
            HienThiThongTinLenTextBox(strConnectionName)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ucSerVer_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        strConnectionName = txtTenKetNoi.Text
        strDataBase = cmbDatabases.Text
        strDataBaseQuan = cmbDatabasesQuan.Text
        strServerName = txtMayChu.Text
        strUserID = txtUser.Text
        strPasswordID = txtPass.Text
    End Sub

#End Region

#Region "Các hàm sử dụng"

    Private Function Kiemtra(ByVal strSTR() As String, ByVal strChuoi As String) As Boolean
        Dim iI As Integer = 0
        Dim iDem As Integer = 0
        For iI = 1 To strSTR.Length - 1
            If strSTR(iI) = strChuoi Then
                iDem = iDem + 1
            End If
        Next
        If iDem > 1 Then
            Return False
        Else
            Return True
        End If
    End Function


#End Region

#Region "Hiển thị thông tin"

    Public Sub loadTenKetNoi()
        Try
            Dim iDem As Integer = 0
            Dim count As Integer = 0
            Dim nodes As XmlNodeList = xmlDocument.DocumentElement.ChildNodes
            For Each childnode As XmlNode In nodes
                For Each node As XmlNode In childnode.ChildNodes
                    If node.Name = "TenKetNoi" Then
                        txtTenKetNoi.Text = node("TenKetNoi").Value
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub HienThiThongTinLenTextBox(ByVal s As String)
        Try
            Dim nodelist As XmlNodeList = xmlDocument.SelectNodes("/Servers/Server[./TenKetNoi/text() = '" & s & "']")
            If nodelist.Count > 0 Then
                txtTenKetNoi.Text = nodelist(0).ChildNodes(0).InnerText
                txtMayChu.Text = nodelist(0).ChildNodes(1).InnerText
                cmbDatabases.Text = nodelist(0).ChildNodes(2).InnerText
                cmbDatabasesQuan.Text = nodelist(0).ChildNodes(3).InnerText
                txtUser.Text = nodelist(0).ChildNodes(4).InnerText
                txtPass.Text = nodelist(0).ChildNodes(5).InnerText
                If nodelist(0).ChildNodes(3).InnerText <> "" Then
                    radTaiKhoanSQL.Checked = True
                End If

            Else
                If strConnectionName = "" Then
                    Dim nodelst As XmlNodeList = xmlDocument.SelectNodes("/Servers/Server[./TenKetNoi/text() = '" & txtTenKetNoi.Text & "']")
                    cmbDatabases.Text = nodelst(0).ChildNodes(2).InnerText
                    cmbDatabasesQuan.Text = nodelst(0).ChildNodes(3).InnerText
                    txtMayChu.Text = nodelst(0).ChildNodes(1).InnerText
                    strConnectionName = txtTenKetNoi.Text
                    strServerName = txtMayChu.Text
                    strDataBase = cmbDatabases.Text
                    strDataBaseQuan = cmbDatabasesQuan.Text
                    strUserID = txtUser.Text
                    strPasswordID = GiaiMa(txtPass.Text)

                Else
                    cmbDatabases.Text = ""
                    cmbDatabasesQuan.Text = ""
                    txtMayChu.Text = ""
                    txtUser.Text = ""
                    txtPass.Text = ""
                    txtTenKetNoi.Text = strConnectionName
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Các phương thức lấy lại giá trị thuộc tính"

    Public Property Get_sqlConnect() As SqlConnection
        Get
            Return sqlConnect
        End Get
        Set(ByVal value As SqlConnection)
            sqlConnect = value
        End Set
    End Property

    Public Property Get_Ten() As String
        Get
            Return strConnectionName
        End Get
        Set(ByVal value As String)
            strConnectionName = value
        End Set
    End Property

    Public Property Get_MayChu() As String
        Get
            Return strServerName
        End Get
        Set(ByVal value As String)
            strServerName = value
        End Set
    End Property

    Public Property Get_CoSoDuLieu() As String
        Get
            Return strDataBase
        End Get
        Set(ByVal value As String)
            strDataBase = value
        End Set
    End Property
    Public Property Get_CoSoDuLieuQuan() As String
        Get
            Return strDataBaseQuan
        End Get
        Set(ByVal value As String)
            strDataBaseQuan = value
        End Set
    End Property
    'Public Property MyForm() As Form
    '    Get
    '        Return strMyForm
    '    End Get
    '    Set(ByVal value As Form)
    '        strMyForm = value
    '    End Set
    'End Property
    Public Property UserId() As String
        Get
            Return strUserID
        End Get
        Set(ByVal value As String)
            strUserID = value
        End Set
    End Property

    Public Property Pass() As String
        Get
            Return strPasswordID
        End Get
        Set(ByVal value As String)
            strPasswordID = value
        End Set
    End Property

#End Region

    Private Sub btnKiemTra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKiemTra.Click
        If blnTestConection Then
            MessageBox.Show("Kết nối thành công !", "Thông báo kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Kết nối thất bại. Xin kiểm tra lại kết nối ! ", "Thông báo kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub txtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = 13 Then
            txtPass.Focus()
        End If
    End Sub

    Private Sub txtUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        strUserID = txtUser.Text
    End Sub

    Private Sub txtPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = 13 Then
            btnChapNhan.Focus()
        End If
    End Sub

    Private Sub txtPass_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        strPasswordID = txtPass.Text
    End Sub

    Private Sub ucSerVer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub radTaiKhoanWin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTaiKhoanWin.CheckedChanged
        If radTaiKhoanSQL.Checked Then
            groupSQL.Enabled = True
        End If
    End Sub

    Private Sub radTaiKhoanSQL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTaiKhoanSQL.CheckedChanged
        If radTaiKhoanWin.Checked Then
            groupSQL.Enabled = False
            txtUser.Text = ""
            txtPass.Text = ""

        End If
    End Sub



    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            blnTestConection = False
            'Khai báo lớp liệt kê danh sách cơ sở dữ liệu
            Dim ListDatabases As New clsListDatabases
            Dim dtListDatabases As New DataTable
            strConnection = "SERVER=" + Me.txtMayChu.Text.Trim + ";DATABASE=master" + ";UID=" + txtUser.Text.Trim + ";PWD=" + txtPass.Text.Trim
            ListDatabases.Connection = strConnection
            'Xóa các thành phần trong ListBox
            cmbDatabases.Text = ""
            cmbDatabases.Items.Clear()
            cmbDatabasesQuan.Items.Clear()
            dtListDatabases = ListDatabases.ListDatabases()
            If dtListDatabases Is Nothing Then
                System.Windows.Forms.MessageBox.Show("Kết nối không thành công, vui lòng kiểm tra lại", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtMayChu.Focus()
                Return
            End If
            If (dtListDatabases.Rows.Count < 1) Then
                System.Windows.Forms.MessageBox.Show("Không tìm thấy cơ sở dữ liệu nào, vui lòng kiểm tra lại", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtMayChu.Focus()
                Return
            End If
            For i As Integer = 0 To dtListDatabases.Rows.Count - 1
                cmbDatabases.Items.Add(dtListDatabases.Rows(i).Item("Name").ToString())
                cmbDatabasesQuan.Items.Add(dtListDatabases.Rows(i).Item("Name").ToString())
            Next
            'Đặt Focus vào danh sách cơ sở dữ liệu
            cmbDatabases.Focus()
            blnTestConection = True
        Catch ex As Exception
            MessageBox.Show("Lỗi: " + System.Environment.NewLine + ex.Message(), "Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Function MaHoa(ByVal strChuoiMaHoa As String) As String

        Dim MangKemTheo() As Char = {}

        Dim strXauKem As String = "dmcadmin"
        MangKemTheo = strXauKem.ToCharArray()
        Dim MangKemTheoMaHoa(MangKemTheo.Length - 1) As String
        For i As Integer = 0 To MangKemTheo.Length - 1
            MangKemTheoMaHoa(i) = Hex(Asc(MangKemTheo(i)))
        Next
        Dim XauMaHoaDiKem As String = ""
        For j As Integer = 0 To MangKemTheoMaHoa.Length - 1
            XauMaHoaDiKem = XauMaHoaDiKem & MangKemTheoMaHoa(j)
        Next

        Dim strKq As String = ""
        Dim arrMangXau() As Char = {}
        arrMangXau = strChuoiMaHoa.ToCharArray()
        Dim arrMangMaHoa(arrMangXau.Length) As String
        For i As Integer = 0 To arrMangXau.Length - 1
            arrMangMaHoa(i) = Hex(Asc(arrMangXau(i)))
        Next
        For j As Integer = 0 To arrMangMaHoa.Length - 1
            strKq = strKq & arrMangMaHoa(j) & XauMaHoaDiKem
        Next
        Return strKq
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
End Class
