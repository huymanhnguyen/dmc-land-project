Public Class ctrFilterGrid
    Private Grid As Windows.Forms.DataGridView
    Private dataTable As DataTable
    Private BD As System.Windows.Forms.BindingSource
    Public Property MydataTable() As DataTable
        Get
            Return dataTable
        End Get
        Set(ByVal value As DataTable)
            dataTable = value
        End Set
    End Property
    Public Property MyGrid() As Windows.Forms.DataGridView
        Get
            Return Grid
        End Get
        Set(ByVal value As Windows.Forms.DataGridView)
            Grid = value
        End Set
    End Property

    Public Sub TaoContol()
        If Not Grid Is Nothing Then
            BD = New BindingSource
            BD.DataSource = dataTable
            Me.Width = Grid.Width
            Dim Count As Integer = 0
            Dim left As Integer = 0
            Dim ThisHeight As Integer = 0
            Count = Grid.ColumnCount
            If Grid.RowHeadersVisible Then
                left = Grid.RowHeadersWidth
            Else
                left = 0
            End If

            Me.Controls.Clear() 
            For i As Integer = 0 To Grid.ColumnCount - 1
                If Grid.Columns(i).Visible Then 
                    Dim txt As New Windows.Forms.TextBox
                    'Dim lab As New Windows.Forms.Label
                    ''-------------------
                    'lab.Name = "lab" & Grid.Columns(i).Name
                    'lab.Text = Grid.Columns(i).HeaderText.Trim
                    'lab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    'lab.AutoSize = False
                    'lab.Width = Grid.Columns(i).Width
                    'lab.Left = left
                    'lab.Top = 0
                    '-------------
                    txt.Name = "txt" & Grid.Columns(i).Name
                    txt.Width = Grid.Columns(i).Width
                    txt.Height = Me.Height - 1
                    txt.Left = left
                    txt.Top = 0 ' lab.Height 
                    ToolTip1.SetToolTip(txt, Grid.Columns(i).HeaderText.Trim)


                    Me.Controls.Add(txt)
                    ' Me.Controls.Add(lab)
                    txt.Visible = True
                    'lab.Visible = True
                    'Else
                    '    txt.Visible = False
                    '    lab.Visible = False
                    AddHandler txt.Leave, AddressOf Me.txt_TextChanged
                    AddHandler txt.KeyDown, AddressOf Me.txt_Next
                    left = left + Grid.Columns(i).Width
                    ThisHeight = txt.Height ' + lab.Height
                End If


            Next
            Me.Height = ThisHeight + 21
            ' Me.Top = Grid.Top - Height
        End If
    End Sub

    Public Sub txt_Next(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = 13 Then
            Dim t As New TextBox
            t = sender
            SelectNextControl(t, True, True, False, False)
        End If
    End Sub

    Public Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strDieuKien As String = ""
        strDieuKien = KetHopDieuKien()
        BD.Filter = strDieuKien
        If BD.Filter <> "" Then
            Grid.DataSource = BD
        Else
            Grid.DataSource = dataTable
        End If
    End Sub

    Public Function KetHopDieuKien() As String
        Dim strDieuKien As String = "1 = 1 "
        For Each txt As Object In Me.Controls
            Try

          
                If txt.GetType.ToString() = "System.Windows.Forms.TextBox" Then
                    Dim strTen As String = txt.Name
                    Dim strTyle As String = ""
                    Dim strCol As String = ""
                    If strTen <> "" Then
                        strCol = strTen.Substring(3, strTen.Length - 3)
                        strTyle = dataTable.Columns(strCol).DataType.ToString

                        If txt.Text <> "" Then
                            Select Case dataTable.Columns(strCol).DataType.ToString
                                Case "System.Boolean"
                                    If txt.Text = "1" Then
                                        strDieuKien = strDieuKien & " and " & String.Format("{0}='{1}'", strCol, "True")
                                    Else
                                        strDieuKien = strDieuKien & " and " & String.Format("{0}='{1}'", strCol, "false")
                                    End If
                                Case "System.DateTime"
                                    If IsDate(txt.Text) Then
                                        strDieuKien = strDieuKien & " and " & String.Format("{0}='{1}'", strCol, txt.Text)
                                    End If
                                Case "System.Int32"
                                    If IsNumeric(txt.Text) Then
                                        strDieuKien = strDieuKien & " and " & String.Format("{0}={1}", strCol, txt.Text)
                                    End If
                                Case "System.Double"
                                    If IsNumeric(txt.Text) Then
                                        strDieuKien = strDieuKien & " and " & String.Format("{0}={1}", strCol, txt.Text)
                                    End If
                                Case "System.String"
                                    strDieuKien = strDieuKien & " and " & String.Format("{0} like '%{1}%'", strCol, txt.Text)
                            End Select
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
        Next
        Return strDieuKien
    End Function

    Private Sub ctrFilterGrid_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        For Each txt As Object In Me.Controls
            txt.Dispose()
        Next
        If (Not Grid Is Nothing) And (Not dataTable Is Nothing) Then
            TaoContol()
        End If
    End Sub

End Class
