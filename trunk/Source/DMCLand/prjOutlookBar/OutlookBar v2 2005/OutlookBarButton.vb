Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Drawing2D


<DesignTimeVisible(False), DefaultProperty("Text")> Public Class OutlookBarButton
    Implements IDisposable

#Region " Constructors "

    'Includes a constructor without parameters so the control can be configured during design-time.

    Public Sub New()
        Me.Owner = New DMC.Interface.OutlookBar.OutlookBar
    End Sub

    Public Sub New(ByVal text As String, ByVal image As Icon)
        Me.Owner = New DMC.Interface.OutlookBar.OutlookBar
        Me.Text = text
        Me.Image = image
    End Sub

    Friend Sub New(ByVal owner As OutlookBar)
        Me.Owner = owner
    End Sub

#End Region

#Region " Destructor "

    'The ButtonClass is not inheriting from Control, so I need this destructor...

    Private disposedValue As Boolean = False        ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#End Region


    'This field lets us react with the parent control.
    Friend Owner As DMC.Interface.OutlookBar.OutlookBar

    Friend State As ButtonState = ButtonState.Passive

    Private _Text As String
    Private _Visible As Boolean = True
    Private _Allowed As Boolean = True
    Private _Image As Icon = My.Resources.DefaultIcon
    Friend Rectangle As Rectangle
    Friend isLarge As Boolean
    Private _Selected As Boolean

    Public Property Text() As String
        Get
            Return Me._Text
        End Get
        Set(ByVal value As String)
            Me._Text = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> Public Property Visible() As Boolean
        Get
            Return Me._Visible
        End Get
        Set(ByVal value As Boolean)
            Me._Visible = value
            If value = False Then
                Me.Rectangle = Nothing
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False"), Browsable(False)> _
    Public Property Selected() As Boolean
        Get
            Return Me._Selected
        End Get
        Set(ByVal value As Boolean)
            Me._Selected = value
            Select Case value
                Case True
                    Me.Owner._SelectedButton = Me
                Case False
                    Me.Owner._SelectedButton = Nothing
            End Select
            Owner.SetSelectionChanged(Me)
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
  Public Property Allowed() As Boolean
        Get
            Return Me._Allowed
        End Get
        Set(ByVal value As Boolean)
            Me._Allowed = value
            If value = False Then
                Me.Visible = False
            End If
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
Public Property Image() As Icon
        Get
            If Me._Image Is Nothing Then
                Return My.Resources.DefaultIcon
            Else
                Return Me._Image
            End If
        End Get
        Set(ByVal value As Icon)
            Me._Image = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.Text
    End Function

End Class

