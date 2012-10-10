Imports System.IO
Imports System.Data.SqlClient
Public Class ctrUpdateHeThong
    Private strConnection As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Private folderName As String = ""
    Private Sub cmdThucThi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThucThi.Click
        Try
            If txtMatKhau.Text.ToUpper = "admin".ToUpper Then 
                For k As Integer = 0 To lstFile.Items.Count - 1
                    Dim mang() As String = lstFile.Items(k).ToString.Split("\")
                    If mang(mang.Length - 1).ToUpper <> "1_delTable".ToUpper And mang(mang.Length - 1).ToUpper <> "2_CreTable".ToUpper And mang(mang.Length - 1).ToUpper <> "3_delStore".ToUpper And mang(mang.Length - 1).ToUpper <> "4_CreStore".ToUpper Then
                        MessageBox.Show("Thư mục cập nhật không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                Next
                For k As Integer = 0 To lstFile.Items.Count - 1
                    Dim di As New IO.DirectoryInfo(lstFile.Items(k))
                    Dim aryFi As IO.FileInfo() = di.GetFiles("*.sql")
                    Dim fi As IO.FileInfo
                    For Each fi In aryFi
                        Dim sr As StreamReader = File.OpenText(fi.FullName)
                        Dim input As String = ""
                        While sr.Peek <> -1
                            Dim s As String = sr.ReadLine()
                            Try
                                If s.Trim <> "" Then
                                    Dim str As String = s
                                    Dim kt As Double = True
                                    If s.Trim.Length > 2 Then
                                        If s.Trim.Substring(0, 2).Trim = "--" Then
                                            kt = False
                                        End If
                                    End If
                                    If kt Then
                                        If s.ToUpper.Trim <> "GO".ToUpper.Trim And s.ToUpper.Trim <> "SET QUOTED_IDENTIFIER OFF".ToUpper.Trim And s.ToUpper.Trim <> "SET ANSI_NULLS ON".ToUpper.Trim And s.ToUpper.Trim <> "SET QUOTED_IDENTIFIER ON".Trim And s.ToUpper.Trim.Trim <> "SET NOCOUNT ON;".Trim Then
                                            input = input & " " & s & vbNewLine
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                MessageBox.Show(ex.ToString)
                            End Try

                        End While

                        Dim cmd As New SqlCommand
                        Dim conn As New SqlConnection
                        conn.ConnectionString = strConnection
                        If conn.State = ConnectionState.Closed Then
                            conn.Open()
                        End If
                        cmd.Connection = conn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = input
                        cmd.ExecuteNonQuery()
                        sr.Close()
                    Next
                Next
                MessageBox.Show("Hoàn thành cập nhật cơ sở dữ liệu", "Thông báo")
            End If
            Try
                For k As Integer = 0 To lstFile.Items.Count - 1
                    Dim mang() As String = lstFile.Items(k).ToString.Split("\")
                    If mang(mang.Length - 1).ToUpper = "1_delTable".ToUpper Or mang(mang.Length - 1).ToUpper = "2_CreTable".ToUpper Or mang(mang.Length - 1).ToUpper = "3_delStore".ToUpper Or mang(mang.Length - 1).ToUpper = "4_CreStore".ToUpper Then
                        If System.IO.Directory.Exists(lstFile.Items(k)) Then
                            System.IO.Directory.Delete(lstFile.Items(k), True)
                        End If
                    End If
                Next

            Catch ex As Exception

            End Try
        Catch ex As Exception
            MessageBox.Show("Cập nhật cơ sở dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub cmdChonThuMuc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChonThuMuc.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog
        With FolderBrowserDialog1
            .RootFolder = Environment.SpecialFolder.Desktop
            .SelectedPath = "c:\"
            .Description = "Chon thu muc chua cac tep convert"
            If .ShowDialog = DialogResult.OK Then
                txtThuMucConVert.Text = .SelectedPath.Trim

                Dim folders() As String, afolder As String
                'lay thu muc cap 1 (ten chi nhanh (cn06))

                folders = System.IO.Directory.GetDirectories(txtThuMucConVert.Text)
                For Each afolder In folders
                    lstFile.Items.Add(afolder)
                Next
                lstFile.Sorted = True
            End If
        End With
    End Sub
End Class
