Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Drawing2D


Public Class OutlookBarButtonCollection
    Inherits CollectionBase

    Private Owner As OutlookBar

    Sub New(ByVal owner As OutlookBar)
        MyBase.New()
        Me.Owner = owner
    End Sub

    Default Public ReadOnly Property Item(ByVal index As Integer) As OutlookBarButton
        Get
            Return CType(List(index), OutlookBarButton)
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal text As String) As OutlookBarButton
        Get
            For Each b As OutlookBarButton In List
                If b.Text.Equals(text) Then Return b
            Next
            Return Nothing
        End Get
    End Property

    Default Friend ReadOnly Property Item(ByVal x As Integer, ByVal y As Integer) As OutlookBarButton
        Get
            For Each b As OutlookBarButton In List
                If Not b.Rectangle = Nothing Then
                    If b.Rectangle.Contains(New Point(x, y)) Then Return b
                End If
                If Not b.Rectangle = Nothing Then
                    If b.Rectangle.Contains(New Point(x, y)) Then Return b
                End If
            Next
            Return Nothing
        End Get
    End Property

    Public Overloads Function Add(ByVal item As OutlookBarButton) As OutlookBarButton
        item.Owner = Me.Owner
        Dim i As Integer = List.Add(item)
        Return DirectCast(List.Item(i), OutlookBarButton)
    End Function

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> Public Overloads Sub AddRange(ByVal items As OutlookBarButtonCollection)
        For Each item As OutlookBarButton In items
            Me.Add(item)
        Next
    End Sub
    
    Public ReadOnly Property IndexOf(ByVal item As OutlookBarButton) As Integer
        Get
            Return Me.List.IndexOf(item)
        End Get
    End Property

    Public Sub Insert(ByVal index As Integer, ByVal value As OutlookBarButton)
        List.Insert(index, value)
    End Sub

    Public Sub Remove(ByVal value As OutlookBarButton)
        List.Remove(value)
    End Sub

    Public Function Contains(ByVal item As OutlookBarButton) As Boolean
        Return List.Contains(item)
    End Function

    Protected Overrides Sub OnValidate(ByVal value As Object)
        If Not GetType(OutlookBarButton).IsAssignableFrom(value.GetType()) Then
            Throw New ArgumentException("value must be of type OutlookBarButton.", "value")
        End If
    End Sub

    Public Function CountVisible() As Integer
        For Each b As OutlookBarButton In Me.List
            If b.Visible And b.Allowed Then CountVisible += 1
        Next
    End Function
    Public Function Length() As Integer
        Dim i As Integer = 0
        For Each b As OutlookBarButton In Me.List
            i += 1
        Next
        Return i
    End Function

End Class

