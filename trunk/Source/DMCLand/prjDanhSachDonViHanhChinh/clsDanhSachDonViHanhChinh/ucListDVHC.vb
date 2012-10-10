Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class ucListDVHC
    Private Arr_DVHC() As Integer
    Private Curr_DVHC As Integer
    Private sqlcon As SqlConnection
    Private MaQuyen As Integer
    Public Event AfterCheck As TreeViewEventHandler
#Region "Các Thuộc tính"


    Public Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Property Get_SqlCon() As SqlConnection
        Get
            Return sqlcon
        End Get
        Set(ByVal value As SqlConnection)
            sqlcon = value
        End Set
    End Property
    Public Property Get_ArrDVHC() As Integer()
        Get
            Return Arr_DVHC
        End Get
        Set(ByVal value As Integer())
            Arr_DVHC = value
        End Set
    End Property

    Public Property Get_CurrDVHC() As Integer
        Get
            Return Curr_DVHC
        End Get
        Set(ByVal value As Integer)
            Curr_DVHC = value
        End Set
    End Property
    Public Property Get_MaQuyen() As Integer
        Get
            Return MaQuyen
        End Get
        Set(ByVal value As Integer)
            MaQuyen = value
        End Set
    End Property
    Private strTrangThai As String = "0"
    Public Property TrangThai() As String
        Get
            Return strTrangThai
        End Get
        Set(ByVal value As String)
            strTrangThai = value
        End Set
    End Property
#End Region

    Private Sub HienThiThongTinLenTreeview()
        'Xóa sạch dữ liệu trên Treview
        Me.TrVwCRDVHC.Nodes.Clear()
        If sqlcon.State <> ConnectionState.Open Then
            sqlcon.Open()
        End If
        TrVwCRDVHC.CheckBoxes = True
        Dim cmdCha As New SqlCommand
        Dim cmdCon As New SqlCommand
        Dim cmdDulieu As New SqlCommand
        Dim cmdCap As New SqlCommand
        cmdCap.CommandType = CommandType.StoredProcedure
        cmdCap.CommandText = "Proc_Getcap"
        cmdCap.Connection = sqlcon
        cmdDulieu.CommandType = CommandType.StoredProcedure
        cmdDulieu.CommandText = "Proc_GetTuDienDonViHanhChinh"
        cmdCha.CommandType = CommandType.StoredProcedure
        cmdCha.CommandText = "proc_LayDonViCha"
        cmdCon.CommandType = CommandType.StoredProcedure
        cmdCon.CommandText = "proc_LayDonViCon"
        cmdDulieu.Connection = sqlcon
        cmdCha.Connection = sqlcon
        cmdCon.Connection = sqlcon

        Dim dsdulieu As New DataSet
        Dim dsCha As New DataSet
        Dim dsCon As New DataSet
        Dim dsCap1 As New DataSet
        Dim dsCap2 As New DataSet
        Dim dsCap3 As New DataSet
        Dim dem As Integer = 0
        If UBound(Arr_DVHC) < 1 Then
            Curr_DVHC = 0
        End If

        cmdCap.CommandText = "proc_cap"
        'Duyệt tất cả các đơn vị Hành chính mà thao tác nghiệp vụ
        For i As Integer = 0 To UBound(Arr_DVHC) - 1
            cmdCap.Parameters.Add("@MaDVHC", SqlDbType.Int)
            cmdCap.Parameters("@MaDVHC").Value = Arr_DVHC(i)
            cmdCap.Parameters.Add("@Cap", SqlDbType.Int)
            cmdCap.Parameters("@Cap").Direction = ParameterDirection.Output
            cmdCap.ExecuteNonQuery()

            'Nếu đơn vị quản lý thuộc cấp 1
            If cmdCap.Parameters("@Cap").Value = 1 Then
                'Nếu đã tồn tại trên TreeView
                If TrVwCRDVHC.Nodes.Find(Arr_DVHC(i), True).Length <> 0 Then
                    ' TrVwCRDVHC.Nodes(Arr_DVHC(i).ToString).Checked = True
                    'Chưa tồn tại
                Else
                    dsCap1 = AddParam("@MaDVHC," & Arr_DVHC(i), 1, cmdDulieu)
                    If Not dsCap1 Is Nothing Then
                        TrVwCRDVHC.Nodes.Add(dsCap1.Tables("result").Rows(0).Item(0), dsCap1.Tables(0).Rows(0).Item(1))
                        dsCap2 = AddParam("@MaDVHC," & dsCap1.Tables("result").Rows(0).Item(0), 1, cmdCon)
                        If Not dsCap2 Is Nothing Then
                            For j As Integer = 0 To dsCap2.Tables("result").Rows.Count - 1
                                TrVwCRDVHC.Nodes(dsCap1.Tables("result").Rows(0).Item(0).ToString).Nodes.Add(dsCap2.Tables("result").Rows(j).Item(0), dsCap2.Tables("result").Rows(j).Item(1))
                                cmdCon.Parameters.Clear()
                                dsCap3 = AddParam("@MaDVHC," & dsCap2.Tables("result").Rows(j).Item(0), 1, cmdCon)
                                If Not dsCap3 Is Nothing Then
                                    For k As Integer = 0 To dsCap3.Tables("result").Rows.Count - 1
                                        TrVwCRDVHC.Nodes(dsCap1.Tables("result").Rows(0).Item(0).ToString).Nodes(dsCap2.Tables("result").Rows(j).Item(0).ToString).Nodes.Add(dsCap3.Tables("result").Rows(k).Item(0), dsCap3.Tables("result").Rows(k).Item(1))
                                    Next
                                End If
                            Next
                        End If
                    End If
                End If
                'Nếu đơn vị quản lý thuộc cấp 2
            ElseIf cmdCap.Parameters("@Cap").Value = 2 Then
                cmdDulieu.Parameters.Clear()
                dsdulieu = AddParam("@MaDVHC," & Arr_DVHC(i), 1, cmdDulieu)
                TrVwCRDVHC.Nodes.Add(dsdulieu.Tables(0).Rows(0).Item(0), dsdulieu.Tables(0).Rows(0).Item(1))
                dsCap3 = AddParam("@MaDVHC," & Arr_DVHC(i), 1, cmdCon)
                If Not dsCap3 Is Nothing Then
                    For j As Integer = 0 To dsCap3.Tables(0).Rows.Count - 1
                        TrVwCRDVHC.Nodes(Arr_DVHC(i).ToString).Nodes.Add(dsCap3.Tables(0).Rows(j).Item(0), dsCap3.Tables(0).Rows(j).Item(1))
                    Next
                End If
                cmdCon.Parameters.Clear()
                'Đơn vị hành chính cấp 3
            ElseIf cmdCap.Parameters("@Cap").Value = 3 Then
                cmdDulieu.Parameters.Clear()
                dsdulieu = AddParam("@MaDVHC," & Arr_DVHC(i), 1, cmdDulieu)
                If TrVwCRDVHC.Nodes.Find(Arr_DVHC(i), True).Length > 0 Then

                Else
                    TrVwCRDVHC.Nodes.Add(dsdulieu.Tables(0).Rows(0).Item(0), dsdulieu.Tables(0).Rows(0).Item(1))
                End If
            End If
            cmdDulieu.Parameters.Clear()
            cmdCap.Parameters.Clear()
        Next
        cmdCap.Dispose()
        cmdDulieu.Dispose()
        cmdCha.Dispose()
        cmdCon.Dispose()
        TrVwCRDVHC.ExpandAll()
        For Each d As TreeNode In TrVwCRDVHC.Nodes
            If d.Name = CStr(Curr_DVHC) Then
                d.Checked = True
                Exit Sub
            End If
            If d.Nodes.Count > 0 Then
                For Each dd As TreeNode In d.Nodes
                    If dd.Name = CStr(Curr_DVHC) Then
                        dd.Checked = True
                        Exit Sub
                    End If
                    If dd.Nodes.Count > 0 Then
                        For Each ddd As TreeNode In dd.Nodes
                            If ddd.Name = CStr(Curr_DVHC) Then
                                ddd.Checked = True
                                Exit Sub
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub hienthi()
        Try
            HienThiThongTinLenTreeview()
        Catch ex As Exception
            MessageBox.Show("Lỗi, hãy thực hiện lại", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FindForm.Close()
        End Try

    End Sub

#Region "Các thủ tục hỗ trợ SQl"
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
        Try
            sqlCmd.ExecuteNonQuery()
            dtDA.SelectCommand = sqlCmd
            dtDA.Fill(dtds, "result")

            If dtds.Tables("result").Rows.Count > 0 Then
                Return dtds
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
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
#End Region
    Private Sub TrVwCRDVHC_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TrVwCRDVHC.AfterCheck
        If e.Action <> TreeViewAction.ByKeyboard And e.Action <> TreeViewAction.ByMouse Then
            Exit Sub
        End If
        For Each d As TreeNode In TrVwCRDVHC.Nodes
            If d.Name <> e.Node.Name Then
                d.Checked = False
            End If
            If d.Nodes.Count > 0 Then
                For Each dd As TreeNode In d.Nodes
                    If dd.Name <> e.Node.Name Then
                        dd.Checked = False
                    End If
                    If dd.Nodes.Count > 0 Then
                        For Each ddd As TreeNode In dd.Nodes
                            If ddd.Name <> e.Node.Name Then
                                ddd.Checked = False
                            End If
                        Next
                    End If
                Next
            End If
        Next
        If e.Node.Checked Then
            Curr_DVHC = CInt(e.Node.Name)
            RaiseEvent AfterCheck(sender, e)
        Else
            Curr_DVHC = 0
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If Curr_DVHC = 0 Then
            MsgBox("Bạn chưa chọn đơn vị thao tác nghiệp vụ")
            Exit Sub
        End If
        TrangThai = "1"
        Me.FindForm.Close()
    End Sub

End Class
