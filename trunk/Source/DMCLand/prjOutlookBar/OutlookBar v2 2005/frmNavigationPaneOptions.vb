

Friend Class frmNavigationPaneOptions

    Private Items As DMC.Interface.OutlookBar.OutlookBarButtonCollection
    Private OriginalItems As New Collection

    Private Sub frmNavigationPaneOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FillList()
        'Try
        Me.CheckedListBox1.SelectedIndex = 0
        'Catch ex As Exception
        'do nothing...
        'End Try
    End Sub
    Private Sub FillList()
        Me.CheckedListBox1.Items.Clear()
        For Each b As DMC.Interface.OutlookBar.OutlookBarButton In Me.Items
            If b.Allowed Then Me.CheckedListBox1.Items.Add(b, b.Visible)
        Next
    End Sub
    Public Sub New(ByVal items As DMC.Interface.OutlookBar.OutlookBarButtonCollection)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Items = items
        For Each b As DMC.Interface.OutlookBar.OutlookBarButton In Me.Items
            Me.OriginalItems.Add(b)
        Next
    End Sub

    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        For Each b As DMC.Interface.OutlookBar.OutlookBarButton In Me.Items
            b.Visible = False
        Next
        For i As Integer = 0 To Me.CheckedListBox1.CheckedItems.Count - 1
            CType(Me.CheckedListBox1.CheckedItems(i), DMC.Interface.OutlookBar.OutlookBarButton).Visible = True
        Next
        Me.Close()
    End Sub

    Private Sub btn_Up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Up.Click
        Dim newIndex As Integer = Me.CheckedListBox1.SelectedIndex - 1
        Me.Items.Insert(newIndex, Me.CheckedListBox1.SelectedItem)
        Me.Items.RemoveAt(newIndex + 2)
        Me.FillList()
        Me.CheckedListBox1.SelectedIndex = newIndex
    End Sub

    Private Sub btn_Down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Down.Click
        Dim b As DMC.Interface.OutlookBar.OutlookBarButton = CType(Me.CheckedListBox1.SelectedItem, DMC.Interface.OutlookBar.OutlookBarButton)
        Dim newIndex As Integer = Me.CheckedListBox1.SelectedIndex + 2
        Me.Items.Insert(newIndex, Me.CheckedListBox1.SelectedItem)
        Me.Items.Remove(b)
        Me.FillList()
        Me.CheckedListBox1.SelectedIndex = newIndex - 1
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        If Me.CheckedListBox1.SelectedIndex = 0 Then
            Me.btn_Up.Enabled = False
        Else
            Me.btn_Up.Enabled = True
        End If
        If Me.CheckedListBox1.SelectedIndex = Me.CheckedListBox1.Items.Count - 1 Then
            Me.btn_Down.Enabled = False
        Else
            Me.btn_Down.Enabled = True
        End If
        If Me.CheckedListBox1.Items.Count = 1 Then
            Me.btn_Down.Enabled = False
            Me.btn_Up.Enabled = False
        End If
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Items.Clear()
        For Each b As DMC.Interface.OutlookBar.OutlookBarButton In Me.OriginalItems
            Me.Items.Add(b)
        Next
    End Sub
End Class