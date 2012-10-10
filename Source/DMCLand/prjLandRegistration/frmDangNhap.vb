Imports DMC.Land.QuanTriHeThong.DangNhap
Imports System.Xml
Imports System.IO

Public Class frmDangNhap
    Private Sub frmDangNhap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            'Nếu kết nối thành công
            If ctrlKetNoi.TenNguoiDung <> "" Then
                User.SQLConnection = ctrlKetNoi.SQLConnection
                User.UserName = ctrlKetNoi.TenNguoiDung
                User.MaQuyen = ctrlKetNoi.MaQuyen
                User.LoginDateTime = Now

                User.MaUser = CtrlKetNoi.MaNguoiDung
                If CtrlKetNoi.ChucNang Is Nothing Then
                    ReDim User.ChucNang(0)
                End If

                If CtrlKetNoi.DonViHanhChinh Is Nothing Then
                    ReDim User.DonViHanhChinh(0)
                Else
                    User.DonViHanhChinh = CtrlKetNoi.DonViHanhChinh
                End If
                If CtrlKetNoi.MaQuyen = "2" Then
                    frmMain.KhởiTạoDữLiệuToolStripMenuItem.Visible = True
                Else
                    frmMain.KhởiTạoDữLiệuToolStripMenuItem.Visible = False
                End If
                LuuUserName(User.UserName)
                blnGlobalDangNhap = True
                'Hien thi UseName len thanh trang thai
                With frmMain.staTrangThai
                    .Items("UserName").Text = "   Tên đăng nhập: " & User.UserName.ToString
                    If User.MaQuyen = 1 Then
                        .Items("QuyenDangNhap").Text = "   Quyền đăng nhập: " & " Supervisor "
                    ElseIf User.MaQuyen = 2 Then
                        .Items("QuyenDangNhap").Text = "   Quyền đăng nhập: " & " Admin "
                    Else
                        .Items("QuyenDangNhap").Text = "   Quyền đăng nhập: " & " Editer "
                    End If
                End With
                If User.MaQuyen > 2 Then
                    frmMain.PhanQuyenChucNangToolStripMenuItem.Visible = False
                Else
                    frmMain.PhanQuyenChucNangToolStripMenuItem.Visible = True
                End If
            End If
            If frmMain.Visible = False And blnGlobalDangNhap = False Then
                frmMain.Close()
            Else
                With frmMain
                    .Show()
                    'If CtrlKetNoi.TenNguoiDung <> "" Then
                    '    .HienThiNghiepVu(True)
                    'End If
                End With
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Thông báo: " + vbNewLine + ex.Message, "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LuuUserName(ByVal IDUser As String)
        Dim strPathXML As String
        Dim xmlDocument As New XmlDocument
        strPathXML = Application.StartupPath + "\logUser.xml"
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
        Dim strUser As XmlNode
        strUser = xmlDocument.CreateElement("UserName")

        ItemNode.AppendChild(strUser)
        ' Thêm dữ liệu text.  
        strUser.AppendChild(xmlDocument.CreateTextNode(IDUser))
        xmlDocument.DocumentElement.AppendChild(ItemNode)
        'Lưu tài liệu.      
        xmlDocument.Save(strPathXML)
    End Sub

End Class