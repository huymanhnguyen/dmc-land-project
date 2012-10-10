Imports System.Data.SqlClient
Public Class ctrChonDonViHanhChinh
    Private iMaQuyen As Integer
    Private sqlConnect As New SqlConnection
    Private strConnection As String
    Private arrMaDVHC() As Integer
    Private arrChucNang() As Integer
    Private strMaDVHC As Integer
    Private frm As New Form

    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public Property Get_sqlConnect() As SqlConnection
        Get
            Return sqlConnect
        End Get
        Set(ByVal value As SqlConnection)
            sqlConnect = value
        End Set
    End Property
    Public Property MyForm() As Form
        Get
            Return frm
        End Get
        Set(ByVal value As Form)
            frm = value
        End Set
    End Property
    Public Property MaDVHC() As Integer
        Get
            Return strMaDVHC
        End Get
        Set(ByVal value As Integer)
            strMaDVHC = value
        End Set
    End Property
    Public Property Get_Maquyen() As Integer
        Get
            Return iMaQuyen
        End Get
        Set(ByVal value As Integer)
            iMaQuyen = value
        End Set
    End Property
    Public Property Get_arrMaDVHC() As Integer()
        Get
            Return arrMaDVHC
        End Get
        Set(ByVal value As Integer())
            arrMaDVHC = value
        End Set
    End Property


    Public Sub ctrChonDonViHanhChinhConnect()
        sqlConnect = New SqlConnection
        sqlConnect.ConnectionString = strConnection
        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
            Get_sqlConnect = sqlConnect
        End If
        ' ''Dim strConnection As String = "Data Source=DMC-CHUNG\DMC_CHUNG2005;Initial Catalog=DMCLand20090304;User ID=sa"
        ' ''Dim conn As New SqlConnection
        ' ''conn.ConnectionString = strConnection
        ' ''conn.Open()
        ' ''Get_sqlConnect = conn
        ' ''Dim Arr() As Integer = {100241, 100244}
        ' ''Get_arrMaDVHC = Arr
        ' ''Get_Maquyen = 1
        ' ''HienThiThongTinLenTreeview()

    End Sub
    Private Sub trvwDonViHanhChinh_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvwDonViHanhChinh.AfterCheck
        If e.Action <> TreeViewAction.ByKeyboard And e.Action <> TreeViewAction.ByMouse Then
            Exit Sub
        End If
        CheckChildren(e.Node, e.Node.Checked)
        CheckParent(e.Node)
        CheckNode(e.Node)

    End Sub
    'khi check vao nut con
    Private Sub CheckChildren(ByVal parentNode As TreeNode, ByVal check As Boolean)
        Dim node As TreeNode
        For Each node In parentNode.Nodes
            node.Checked = check
            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                Me.CheckChildren(node, check)
            End If
        Next node

    End Sub
    'khi check vao nut cha
    Private Sub CheckParent(ByVal e As TreeNode)
        Dim blnUncheck As Boolean = False
        If Not e.Parent Is Nothing Then
            For Each child As TreeNode In e.Parent.Nodes
                If child.Checked = False Then
                    blnUncheck = True
                End If
            Next
            If blnUncheck = False Then
                e.Parent.Checked = True
            Else
                e.Parent.Checked = False
            End If
            Me.CheckParent(e.Parent)
        End If
    End Sub
    Public Sub HienThiThongTinLenTreeview()
        trvwDonViHanhChinh.CheckBoxes = True
        Dim cmdCha As New SqlCommand
        Dim cmdCon As New SqlCommand
        Dim cmdDulieu As New SqlCommand
        Dim cmdCap As New SqlCommand
        cmdCap.CommandType = CommandType.StoredProcedure
        cmdCap.CommandText = "Proc_Getcap"
        cmdCap.Connection = sqlconnect
        cmdDulieu.CommandType = CommandType.StoredProcedure
        cmdDulieu.CommandText = "Proc_GetTuDienDonViHanhChinh"
        cmdCha.CommandType = CommandType.StoredProcedure
        cmdCha.CommandText = "proc_LayDonViCha"
        cmdCon.CommandType = CommandType.StoredProcedure
        cmdCon.CommandText = "proc_LayDonViCon"
        cmdDulieu.Connection = sqlconnect
        cmdCha.Connection = sqlconnect
        cmdCon.Connection = sqlconnect

        Dim dsdulieu As New DataSet
        Dim dsCha As New DataSet
        Dim dsCon As New DataSet
        Dim dsCap1 As New DataSet
        Dim dsCap2 As New DataSet
        Dim dsCap3 As New DataSet
        Dim dem As Integer = 0

        'Người có quyền cao nhất
        If iMaQuyen = 1 Then
            dsCap1 = AddParam("@cap," & 1, 1, cmdCap)
            If Not dsCap1 Is Nothing Then
                For j As Integer = 0 To dsCap1.Tables("result").Rows.Count - 1
                    trvwDonViHanhChinh.Nodes.Add(dsCap1.Tables("result").Rows(j).Item(0), dsCap1.Tables("result").Rows(j).Item(1))
                    cmdCap.Parameters.Clear()
                    dsCap2 = AddParam("@MaDVHC," & dsCap1.Tables("result").Rows(j).Item(0), 1, cmdCon)
                    If Not dsCap2 Is Nothing Then
                        For k As Integer = 0 To dsCap2.Tables("result").Rows.Count - 1
                            trvwDonViHanhChinh.Nodes(dsCap1.Tables("result").Rows(j).Item(0).ToString).Nodes.Add(dsCap2.Tables("result").Rows(k).Item(0), dsCap2.Tables("result").Rows(k).Item(1))
                            cmdCon.Parameters.Clear()
                            dsCap3 = AddParam("@maDVHC," & dsCap2.Tables("result").Rows(k).Item(0), 1, cmdCon)
                            If Not dsCap3 Is Nothing Then
                                For h As Integer = 0 To dsCap3.Tables("result").Rows.Count - 1
                                    trvwDonViHanhChinh.Nodes(dsCap1.Tables("result").Rows(j).Item(0).ToString).Nodes(dsCap2.Tables("result").Rows(k).Item(0).ToString).Nodes.Add(dsCap3.Tables("result").Rows(h).Item(0), dsCap3.Tables("result").Rows(h).Item(1))
                                Next
                            End If
                            cmdCon.Parameters.Clear()
                        Next
                    End If
                    cmdCon.Parameters.Clear()
                Next
            End If

            'Khi ADMIN login
        ElseIf iMaQuyen = 2 Or iMaQuyen = 3 Then
            cmdCap.CommandText = "proc_cap"
            'Duyệt tất cả các đơn vị Hành chính mà ADMIN quản lý
            For i As Integer = 0 To UBound(arrMaDVHC) - 1
                cmdCap.Parameters.Add("@MaDVHC", SqlDbType.Int)
                cmdCap.Parameters("@MaDVHC").Value = arrMaDVHC(i)
                cmdCap.Parameters.Add("@Cap", SqlDbType.Int)
                cmdCap.Parameters("@Cap").Direction = ParameterDirection.Output
                cmdCap.ExecuteNonQuery()

                'Nếu đơn vị quản lý thuộc cấp 1
                If cmdCap.Parameters("@Cap").Value = 1 Then
                    'Nếu đã tồn tại trên TreeView
                    If trvwDonViHanhChinh.Nodes.Find(arrMaDVHC(i), True).Length > 0 Then
                        trvwDonViHanhChinh.Nodes(arrMaDVHC(i).ToString).Checked = True
                        'Chưa tồn tại
                    Else
                        dsCap1 = AddParam("@MaDVHC," & arrMaDVHC(i), 1, cmdDulieu)
                        If Not dsCap1 Is Nothing Then
                            trvwDonViHanhChinh.Nodes.Add(dsCap1.Tables("result").Rows(0).Item(0), dsCap1.Tables(0).Rows(0).Item(1))
                            dsCap2 = AddParam("@MaDVHC," & dsCap1.Tables("result").Rows(0).Item(0), 1, cmdCon)
                            If Not dsCap2 Is Nothing Then
                                For j As Integer = 0 To dsCap2.Tables("result").Rows.Count - 1
                                    trvwDonViHanhChinh.Nodes(dsCap1.Tables("result").Rows(0).Item(0).ToString).Nodes.Add(dsCap2.Tables("result").Rows(j).Item(0), dsCap2.Tables("result").Rows(j).Item(1))
                                    cmdCon.Parameters.Clear()
                                    dsCap3 = AddParam("@MaDVHC," & dsCap2.Tables("result").Rows(j).Item(0), 1, cmdCon)
                                    If Not dsCap3 Is Nothing Then
                                        For k As Integer = 0 To dsCap3.Tables("result").Rows.Count - 1
                                            trvwDonViHanhChinh.Nodes(dsCap1.Tables("result").Rows(0).Item(0).ToString).Nodes(dsCap2.Tables("result").Rows(j).Item(0).ToString).Nodes.Add(dsCap3.Tables("result").Rows(k).Item(0), dsCap3.Tables("result").Rows(k).Item(1))
                                        Next
                                    End If
                                Next
                            End If
                        End If
                        trvwDonViHanhChinh.Nodes(arrMaDVHC(i).ToString).Checked = True
                    End If
                    'Nếu đơn vị quản lý thuộc cấp 2
                ElseIf cmdCap.Parameters("@Cap").Value = 2 Then
                    cmdDulieu.Parameters.Clear()
                    dsdulieu = AddParam("@MaDVHC," & arrMaDVHC(i), 1, cmdDulieu)
                    If trvwDonViHanhChinh.Nodes.Find(arrMaDVHC(i), True).Length > 0 Then

                    Else
                        cmdCha.Parameters.Clear()
                        dsCha = AddParam("@MaDVHC," & arrMaDVHC(i), 1, cmdCha)
                        If Not dsCha Is Nothing Then
lb1:
                            If trvwDonViHanhChinh.Nodes.Find(dsCha.Tables(0).Rows(0).Item(0).ToString, True).Length > 0 Then
                                trvwDonViHanhChinh.Nodes(dsCha.Tables(0).Rows(0).Item(0).ToString).Nodes.Add(dsdulieu.Tables(0).Rows(0).Item(0), dsdulieu.Tables(0).Rows(0).Item(1))
                                dsCap3 = AddParam("@MaDVHC," & arrMaDVHC(i), 1, cmdCon)
                                If Not dsCap3 Is Nothing Then
                                    For j As Integer = 0 To dsCap3.Tables(0).Rows.Count - 1
                                        trvwDonViHanhChinh.Nodes(dsCha.Tables(0).Rows(0).Item(0).ToString).Nodes(arrMaDVHC(i).ToString).Nodes.Add(dsCap3.Tables(0).Rows(j).Item(0), dsCap3.Tables(0).Rows(j).Item(1))
                                    Next
                                End If
                                cmdCon.Parameters.Clear()
                            Else
                                trvwDonViHanhChinh.Nodes.Add(dsCha.Tables(0).Rows(0).Item(0), dsCha.Tables(0).Rows(0).Item(1))
                                GoTo lb1
                            End If
                        End If
                    End If

                    'Đơn vị hành chính cấp 3
                ElseIf cmdCap.Parameters("@Cap").Value = 3 Then
                    cmdDulieu.Parameters.Clear()
                    dsdulieu = AddParam("@MaDVHC," & arrMaDVHC(i), 1, cmdDulieu)
                    If trvwDonViHanhChinh.Nodes.Find(arrMaDVHC(i), True).Length > 0 Then

                    Else
                        cmdCha.Parameters.Clear()
                        dsCap2 = AddParam("@MaDVHC," & arrMaDVHC(i), 1, cmdCha)
                        If Not dsCap2 Is Nothing Then
                            If trvwDonViHanhChinh.Nodes.Find(dsCap2.Tables(0).Rows(0).Item(0).ToString, True).Length > 0 Then
                                cmdCha.Parameters.Clear()
                                dsCap1 = AddParam("@MaDVHC," & dsCap2.Tables(0).Rows(0).Item(0), 1, cmdCha)
                                trvwDonViHanhChinh.Nodes(dsCap1.Tables(0).Rows(0).Item(0).ToString).Nodes(dsCap2.Tables(0).Rows(0).Item(0).ToString).Nodes.Add(dsdulieu.Tables(0).Rows(0).Item(0), dsdulieu.Tables(0).Rows(0).Item(1))
                                cmdCon.Parameters.Clear()
                            Else
                                cmdCha.Parameters.Clear()
                                dsCap1 = AddParam("@MaDVHC," & dsCap2.Tables("result").Rows(0).Item(0), 1, cmdCha)
                                If Not dsCap1 Is Nothing Then
                                    If trvwDonViHanhChinh.Nodes.Find(dsCap1.Tables(0).Rows(0).Item(0).ToString, True).Length > 0 Then
                                        trvwDonViHanhChinh.Nodes(dsCap1.Tables(0).Rows(0).Item(0).ToString).Nodes.Add(dsCap2.Tables(0).Rows(0).Item(0), dsCap2.Tables(0).Rows(0).Item(1))
                                        trvwDonViHanhChinh.Nodes(dsCap2.Tables(0).Rows(0).Item(0).ToString).Nodes.Add(dsdulieu.Tables(0).Rows(0).Item(0), dsdulieu.Tables(0).Rows(0).Item(1))
                                    Else
                                        trvwDonViHanhChinh.Nodes.Add(dsCap1.Tables(0).Rows(0).Item(0), dsCap1.Tables(0).Rows(0).Item(1))
                                        trvwDonViHanhChinh.Nodes(dsCap1.Tables(0).Rows(0).Item(0).ToString).Nodes.Add(dsCap2.Tables(0).Rows(0).Item(0), dsCap2.Tables(0).Rows(0).Item(1))
                                        trvwDonViHanhChinh.Nodes(dsCap1.Tables(0).Rows(0).Item(0).ToString).Nodes(dsCap2.Tables(0).Rows(0).Item(0).ToString).Nodes.Add(dsdulieu.Tables(0).Rows(0).Item(0), dsdulieu.Tables(0).Rows(0).Item(1))
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                cmdDulieu.Parameters.Clear()
                cmdCap.Parameters.Clear()
            Next

        End If
        cmdCap.Dispose()
        cmdDulieu.Dispose()
        cmdCha.Dispose()
        cmdCon.Dispose()
        sqlConnect.Close()
    End Sub

    Private Function AddParam(ByVal strArrParam As String, ByVal iNumber As Integer, ByRef sqlCmd As SqlCommand) As DataSet
        Dim strtemp(iNumber * 2) As String
        Dim dtDA As New SqlDataAdapter
        Dim dtds As New DataSet
        TachXau(strArrParam, strtemp)
        'Set our parm properties
        For i As Integer = 1 To iNumber * 2
            If i Mod 2 = 1 Then
                Dim oParam As New SqlClient.SqlParameter
                oParam = sqlCmd.CreateParameter()
                oParam.ParameterName = strtemp(i)
                oParam.Value = strtemp(i + 1)
                sqlCmd.Parameters.Add(oParam)
            End If
        Next
        sqlCmd.ExecuteNonQuery()
        dtDA.SelectCommand = sqlCmd
        dtDA.Fill(dtds, "result")
        Try
            If dtds.Tables("result").Rows.Count > 0 Then
                Return dtds
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
        sqlConnect.Close()
    End Function

    Private Sub TachXau(ByVal FullString As String, ByRef SplitString() As String)
        Dim i As Integer, NumStr As Integer
        NumStr = 0
        i = 1
        Do
            Do While (Mid$(FullString, i, 1) = " ") Or (Mid$(FullString, i, 1) = ",") _
                                Or (Mid$(FullString, i, 1) = Chr(32)) Or (Mid$(FullString, i, 1) = ";") _
                                Or (Mid$(FullString, i, 1) = Chr(34)) Or (Mid$(FullString, i, 1) = Chr(9)) _
                                Or (Mid$(FullString, i, 1) = ":") _
                                And (i <= Len(FullString))
                i = i + 1
            Loop
            If i <= Len(FullString) Then
                NumStr = NumStr + 1
                ReDim Preserve SplitString(NumStr)
                SplitString(NumStr) = ""
            End If
            Do While (i <= Len(FullString)) And (Mid$(FullString, i, 1) <> " ") _
                And (Mid$(FullString, i, 1) <> ",") _
                And (Mid$(FullString, i, 1) <> Chr(32)) _
                And (Mid$(FullString, i, 1) <> ";") _
                And (Mid$(FullString, i, 1) <> Chr(34)) _
                And (Mid$(FullString, i, 1) <> Chr(9)) _
                And (Mid$(FullString, i, 1) <> ":")
                SplitString(NumStr) = SplitString(NumStr) + Mid$(FullString, i, 1)
                i = i + 1
            Loop
        Loop Until i > Len(FullString)
    End Sub

    Public Function getMaDVHC() As Integer
        Dim s As Integer
        With trvwDonViHanhChinh
            For i As Integer = 0 To .Nodes.Count - 1
                For j As Integer = 0 To .Nodes(i).Nodes.Count - 1
                    For k As Integer = 0 To .Nodes(i).Nodes(j).Nodes.Count - 1
                        If .Nodes(i).Nodes(j).Nodes(k).Checked = True Then
                            s = .Nodes(i).Nodes(j).Nodes(k).Name
                        End If
                    Next
                Next
            Next
        End With
        Return s
    End Function

    Public Function getArrMaDVHC() As String()
        Dim s As String = ""
        Dim Arr() As String = Nothing
        With trvwDonViHanhChinh
            For i As Integer = 0 To .Nodes.Count - 1
                If .Nodes(i).Checked Then
                    s = s & .Nodes(i).Name & ","
                End If
                For j As Integer = 0 To .Nodes(i).Nodes.Count - 1
                    If .Nodes(i).Nodes(j).Checked Then
                        s = s & .Nodes(i).Nodes(j).Name & ","
                    End If
                    For k As Integer = 0 To .Nodes(i).Nodes(j).Nodes.Count - 1
                        If .Nodes(i).Nodes(j).Nodes(k).Checked Then
                            s = s & .Nodes(i).Nodes(j).Nodes(k).Name & ","
                        End If
                    Next
                Next
            Next
        End With
        TachXau(s, Arr)
        Return Arr
    End Function

    Public Sub CheckNode(ByVal parentNode As TreeNode)

        With trvwDonViHanhChinh
            For i As Integer = 0 To .Nodes.Count - 1
                For j As Integer = 0 To .Nodes(i).Nodes.Count - 1
                    For k As Integer = 0 To .Nodes(i).Nodes(j).Nodes.Count - 1
                        .Nodes(i).Nodes(j).Nodes(k).Checked = False
                    Next
                Next
            Next
        End With
        If parentNode.Checked = False Then
            parentNode.Checked = True
        End If
    End Sub

    Private Sub ctrChonDonViHanhChinh_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        sqlConnect.Close()
    End Sub

End Class
