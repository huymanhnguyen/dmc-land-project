Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel


<DefaultEvent("ButtonClicked")> Public Class OutlookBar
    Inherits Control

    Public Sub New()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me._Buttons = New DMC.Interface.OutlookBar.OutlookBarButtonCollection(Me)
    End Sub

    Public Event ButtonClicked(ByVal sender As Object, ByVal e As System.EventArgs)

    'Needed because this way the buttons can raise the ButtonClicked event...
    Public Sub SetSelectionChanged(ByVal button As OutlookBarButton)
        Me._SelectedButton = button
        Me.Invalidate()
        RaiseEvent ButtonClicked(Me, New System.EventArgs)
    End Sub

#Region " Members... "

    'Private Members...
    Private oToolTip As New ToolTip
    Private oContextMenuStrip As ContextMenuStrip
    Private _Buttons As DMC.Interface.OutlookBar.OutlookBarButtonCollection
    Private _Renderer As Renderer = Renderer.Outlook2003
    Private Const ImageDimension_Large As Integer = 24
    Private Const ImageDimension_Small As Integer = 18
    Private _DropDownHovering As Boolean
    Private _HoveringButton As DMC.Interface.OutlookBar.OutlookBarButton
    Private _LeftClickedButton As DMC.Interface.OutlookBar.OutlookBarButton
    Private _RightClickedButton As DMC.Interface.OutlookBar.OutlookBarButton
    Friend _SelectedButton As DMC.Interface.OutlookBar.OutlookBarButton
    Private IsResizing As Boolean
    Private CanGrow As Boolean
    Private CanShrink As Boolean
    Private _OutlookBarLineColor As Color
    Private _ButtonHeight As Integer = 35
    Private _ForeColorSelected As Color
    Private _ButtonColorHoveringTop As Color
    Private _ButtonColorSelectedTop As Color
    Private _ButtonColorSelectedAndHoveringTop As Color
    Private _ButtonColorPassiveTop As Color
    Private _ButtonColorHoveringBottom As Color
    Private _ButtonColorSelectedBottom As Color
    Private _ButtonColorSelectedAndHoveringBottom As Color
    Private _ButtonColorPassiveBottom As Color

    'Public Members...
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Behavior")> Public ReadOnly Property Buttons() As DMC.Interface.OutlookBar.OutlookBarButtonCollection
        Get
            Return Me._Buttons
        End Get
    End Property
    <Browsable(False)> Public ReadOnly Property SelectedButton() As DMC.Interface.OutlookBar.OutlookBarButton
        Get
            Return Me._SelectedButton
        End Get
    End Property
    <DefaultValue(GetType(Renderer), "Outlook2003")> <Category("Appearance")> Public Property Renderer() As Renderer
        Get
            Return Me._Renderer
        End Get
        Set(ByVal value As Renderer)
            Me._Renderer = value
            Me.Invalidate()
        End Set
    End Property
    Public Overrides Property MinimumSize() As System.Drawing.Size
        Get
            Return New Drawing.Size(Me.GetBottomContainerLeftMargin, Me.GetBottomContainerRectangle.Height + GetGripRectangle.Height)
        End Get
        Set(ByVal value As System.Drawing.Size)
            'do nothing...
        End Set
    End Property
    <Category("Appearance"), DisplayName("LineColor")> Public Property OutlookBarLineColor() As Color
        Get
            Return Me._OutlookBarLineColor
        End Get
        Set(ByVal value As Color)
            Me._OutlookBarLineColor = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance")> Public Property ButtonHeight() As Integer
        Get
            Return Me._ButtonHeight
        End Get
        Set(ByVal value As Integer)
            If value < 5 Then value = 5
            Me._ButtonHeight = value
            Me.Invalidate()
        End Set
    End Property
    <DisplayName("ForeColorNotSelected")> Public Overrides Property ForeColor() As System.Drawing.Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.ForeColor = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance")> Public Property ForeColorSelected() As Color
        Get
            Return Me._ForeColorSelected
        End Get
        Set(ByVal value As Color)
            Me._ForeColorSelected = value
            Me.Invalidate()
        End Set
    End Property
    <DisplayName("ButtonFont")> Public Overrides Property Font() As System.Drawing.Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As System.Drawing.Font)
            MyBase.Font = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance"), DisplayName("ButtonHovering1")> Public Property ButtonColorHoveringTop() As Color
        Get
            Return Me._ButtonColorHoveringTop
        End Get
        Set(ByVal value As Color)
            Me._ButtonColorHoveringTop = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance"), DisplayName("ButtonSelected1")> Public Property ButtonColorSelectedTop() As Color
        Get
            Return Me._ButtonColorSelectedTop
        End Get
        Set(ByVal value As Color)
            Me._ButtonColorSelectedTop = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance"), DisplayName("ButtonSelectedHovering1")> Public Property ButtonColorSelectedAndHoveringTop() As Color
        Get
            Return Me._ButtonColorSelectedAndHoveringTop
        End Get
        Set(ByVal value As Color)
            Me._ButtonColorSelectedAndHoveringTop = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance"), DisplayName("ButtonPassive1")> Public Property ButtonColorPassiveTop() As Color
        Get
            Return Me._ButtonColorPassiveTop
        End Get
        Set(ByVal value As Color)
            Me._ButtonColorPassiveTop = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance"), DisplayName("ButtonHovering2")> Public Property ButtonColorHoveringBottom() As Color
        Get
            Return Me._ButtonColorHoveringBottom
        End Get
        Set(ByVal value As Color)
            Me._ButtonColorHoveringBottom = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance"), DisplayName("ButtonSelected2")> Public Property ButtonColorSelectedBottom() As Color
        Get
            Return Me._ButtonColorSelectedBottom
        End Get
        Set(ByVal value As Color)
            Me._ButtonColorSelectedBottom = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance"), DisplayName("ButtonSelectedHovering2")> Public Property ButtonColorSelectedAndHoveringBottom() As Color
        Get
            Return Me._ButtonColorSelectedAndHoveringBottom
        End Get
        Set(ByVal value As Color)
            Me._ButtonColorSelectedAndHoveringBottom = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance"), DisplayName("ButtonPassive2")> Public Property ButtonColorPassiveBottom() As Color
        Get
            Return Me._ButtonColorPassiveBottom
        End Get
        Set(ByVal value As Color)
            Me._ButtonColorPassiveBottom = value
            Me.Invalidate()
        End Set
    End Property

    '

#End Region

#Region " Control events "



    Private Sub OutlookBar_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        _RightClickedButton = Nothing
        Dim mButton As DMC.Interface.OutlookBar.OutlookBarButton = Me.Buttons.Item(e.X, e.Y)
        If Not mButton Is Nothing Then
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left
                    Me._SelectedButton = mButton
                    RaiseEvent ButtonClicked(Me, New System.EventArgs)
                    Me.Invalidate()
                Case Windows.Forms.MouseButtons.Right
                    Me._RightClickedButton = mButton
                    Me.Invalidate()
            End Select
            'Else
            '    If Me.GetDropDownRectangle.Contains(e.X, e.Y) Then
            '        Me.CreateContextMenu()
            '    End If
        End If
    End Sub

    Private Sub OutlookBar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        IsResizing = GetGripRectangle.Contains(e.X, e.Y)
    End Sub

    Private Sub OutlookBar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        If Me._RightClickedButton Is Nothing Then
            Me._HoveringButton = Nothing
            Me._DropDownHovering = False
            Me.Invalidate()
        End If
    End Sub

    Private Sub OutlookBar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Me._HoveringButton = Nothing
        Me._DropDownHovering = False
        If IsResizing Then
            If e.Y < -GetButtonHeight() Then
                If CanGrow Then
                    Me.Height += GetButtonHeight()
                Else
                    Exit Sub
                End If
            ElseIf e.Y > GetButtonHeight() Then
                If CanShrink Then
                    Me.Height -= GetButtonHeight()
                Else
                    Exit Sub
                End If
            End If
        Else
            If Me.GetGripRectangle.Contains(e.X, e.Y) Then
                Me.Cursor = Cursors.SizeNS
            ElseIf GetDropDownRectangle.Contains(e.X, e.Y) Then
                Me.Cursor = Cursors.Hand
                Me._DropDownHovering = True
                Me.Invalidate()

                'adjust Tooltip...
                If Not oToolTip.Tag Is Nothing Then
                    If Not oToolTip.Tag.Equals("Configure") Then
                        Me.oToolTip.Active = True
                        Me.oToolTip.SetToolTip(Me, "Configure buttons")
                        Me.oToolTip.Tag = "Configure"
                    End If
                Else
                    Me.oToolTip.Active = True
                    Me.oToolTip.SetToolTip(Me, "Configure buttons")
                    Me.oToolTip.Tag = "Configure"
                End If

            ElseIf Not Me.Buttons.Item(e.X, e.Y) Is Nothing Then
                Me.Cursor = Cursors.Hand
                Me._HoveringButton = Me.Buttons.Item(e.X, e.Y)
                Me.Invalidate()

                'adjust tooltip...
                'If Not Me.Buttons.Item(e.X, e.Y).isLarge Then
                '    If oToolTip.Tag Is Nothing Then
                '        Me.oToolTip.Active = True
                '        Me.oToolTip.SetToolTip(Me, Me.Buttons.Item(e.X, e.Y).Text)
                '        Me.oToolTip.Tag = Me.Buttons.Item(e.X, e.Y)
                '    Else
                '        If Not oToolTip.Tag.Equals(Me.Buttons.Item(e.X, e.Y)) Then
                '            Me.oToolTip.Active = True
                '            Me.oToolTip.SetToolTip(Me, Me.Buttons.Item(e.X, e.Y).Text)
                '            Me.oToolTip.Tag = Me.Buttons.Item(e.X, e.Y)
                '        End If
                '    End If
                'Else
                '    Me.oToolTip.Active = False
                'End If
            Else
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub OutlookBar_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Me.IsResizing = False
        Me._LeftClickedButton = Nothing
    End Sub

#End Region

#Region " Graphics "

    Private MaxLargeButtonCount As Integer
    Private MaxSmallButtonCount As Integer

    Friend Sub OutlookBar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        MaxLargeButtonCount = Math.Floor((Me.Height - GetBottomContainerRectangle.Height - GetGripRectangle.Height) / GetButtonHeight())
        If Me.Buttons.CountVisible < MaxLargeButtonCount Then MaxLargeButtonCount = Me.Buttons.CountVisible

        CanShrink = (MaxLargeButtonCount <> 0)
        CanGrow = (MaxLargeButtonCount < Me.Buttons.CountVisible)

        Me.Height = (MaxLargeButtonCount * GetButtonHeight()) + GetGripRectangle.Height + GetBottomContainerRectangle.Height

        'Paint Grip...
        Me.PaintGripRectangle(e.Graphics)

        'Paint Large Buttons...
        Dim SyncLargeButtons As Integer
        Dim IterateLargeButtons As Integer
        For IterateLargeButtons = 0 To Me.Buttons.Count - 1
            If Me.Buttons(IterateLargeButtons).Visible Then
                Dim rec As New Drawing.Rectangle(0, (SyncLargeButtons * GetButtonHeight()) + GetGripRectangle.Height, Me.Width, GetButtonHeight)
                Buttons(IterateLargeButtons).Rectangle = rec
                Buttons(IterateLargeButtons).isLarge = True
                Me.PaintButton(Buttons(IterateLargeButtons), e.Graphics, (MaxLargeButtonCount <> SyncLargeButtons))
                If SyncLargeButtons = MaxLargeButtonCount Then Exit For
                SyncLargeButtons += 1
            End If
        Next

        'Paint Small Buttons...
        MaxSmallButtonCount = Math.Floor((Me.Width - GetDropDownRectangle.Width - Me.GetBottomContainerLeftMargin) / GetSmallButtonWidth())
        If (Me.Buttons.CountVisible - MaxLargeButtonCount) <= 0 Then
            MaxSmallButtonCount = 0
        End If
        If MaxSmallButtonCount > (Me.Buttons.CountVisible - MaxLargeButtonCount) Then
            MaxSmallButtonCount = (Me.Buttons.CountVisible - MaxLargeButtonCount)
        End If

        Dim StartX As Integer = Me.Width - GetDropDownRectangle.Width - (MaxSmallButtonCount * Me.GetSmallButtonWidth)
        Dim SyncSmallButtons As Integer
        Dim IterateSmallButtons As Integer
        For IterateSmallButtons = IterateLargeButtons To Me.Buttons.Count - 1
            If SyncSmallButtons = MaxSmallButtonCount Then Exit For
            If Me.Buttons(IterateSmallButtons).Visible Then
                Dim rec As New Drawing.Rectangle(StartX + (SyncSmallButtons * GetSmallButtonWidth()), GetBottomContainerRectangle.Y, GetSmallButtonWidth, GetBottomContainerRectangle.Height)
                Me.Buttons(IterateSmallButtons).Rectangle = rec
                Me.Buttons(IterateSmallButtons).isLarge = False
                Me.PaintButton(Me.Buttons(IterateSmallButtons), e.Graphics)
                SyncSmallButtons += 1
            End If
        Next

        For IterateMenuItems As Integer = IterateSmallButtons To Me.Buttons.CountVisible - 1
            Me.Buttons(IterateMenuItems).Rectangle = Nothing
        Next

        'Draw Empty Space...
        Dim recEmptySpace As Rectangle = Me.GetBottomContainerRectangle
        With recEmptySpace
            .Width = Me.Width - (MaxSmallButtonCount * Me.GetSmallButtonWidth) - Me.GetDropDownRectangle.Width
        End With
        Me.FillButton(recEmptySpace, e.Graphics, ButtonState.Passive, True, True, False)

        'Paint DropDown...
        Me.PaintDropDownRectangle(e.Graphics)

        'Finally, paint the bottom line...
        e.Graphics.DrawLine(New Pen(Me.GetOutlookBarLineColor), 0, Me.Height - 1, Me.Width - 1, Me.Height - 1)
    End Sub

    Private Sub PaintButton(ByRef Button As DMC.Interface.OutlookBar.OutlookBarButton, ByVal graphics As Graphics, Optional ByVal IsLastLarge As Boolean = False)
        If Button.Equals(_HoveringButton) Then
            If _LeftClickedButton Is Nothing Then
                If Button.Equals(Me.SelectedButton) Then
                    FillButton(Button.Rectangle, graphics, ButtonState.Selected Or ButtonState.Hovering, True, Button.isLarge, Button.isLarge)
                Else
                    Me.FillButton(Button.Rectangle, graphics, ButtonState.Hovering, True, Button.isLarge, Button.isLarge)
                End If
            Else
                Me.FillButton(Button.Rectangle, graphics, ButtonState.Selected Or ButtonState.Hovering, True, Button.isLarge, Button.isLarge)
            End If
        Else
            If Button.Equals(SelectedButton) Then
                FillButton(Button.Rectangle, graphics, ButtonState.Selected, True, Button.isLarge, Button.isLarge)
            Else
                FillButton(Button.Rectangle, graphics, ButtonState.Passive, True, Button.isLarge, Button.isLarge)
            End If
        End If

        'Text and icons...
        If Button.isLarge And IsLastLarge = True Then
            graphics.DrawString(Button.Text, Me.GetButtonFont, Me.GetButtonTextBrush(Button.Equals(Me.SelectedButton)), 10 + ImageDimension_Large + 8, CType(Button.Rectangle.Y + ((GetButtonHeight() / 2) - (Me.GetButtonFont.Height / 2)), Single) + 2)
        End If
        Dim recIma As New Rectangle
        Select Case Button.isLarge
            Case True
                With recIma
                    .Width = ImageDimension_Large
                    .Height = ImageDimension_Large
                    .X = 10
                    .Y = Button.Rectangle.Y + Math.Floor((GetButtonHeight() / 2) - (ImageDimension_Large / 2))
                End With
            Case False
                With recIma
                    .Width = ImageDimension_Small
                    .Height = ImageDimension_Small
                    .X = Button.Rectangle.X + Math.Floor((GetSmallButtonWidth() / 2) - (ImageDimension_Small / 2))
                    .Y = Button.Rectangle.Y + Math.Floor((GetButtonHeight() / 2) - (ImageDimension_Small / 2))
                End With
        End Select
        If Button.isLarge And IsLastLarge = True Then graphics.DrawImage(Button.Image.ToBitmap, recIma)
        If Button.isLarge = False Then graphics.DrawImage(Button.Image.ToBitmap, recIma)

    End Sub

    Private Sub FillButton(ByVal rectangle As Rectangle, _
                                ByVal graphics As Graphics, _
                                ByVal buttonState As ButtonState, _
                                ByVal DrawTopBorder As Boolean, _
                                ByVal DrawLeftBorder As Boolean, _
                                ByVal DrawRightBorder As Boolean)
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Dim aBrush As Brush = New LinearGradientBrush(rectangle, Me.GetButtonColor(buttonState, 0), Me.GetButtonColor(buttonState, 1), LinearGradientMode.Vertical)
                graphics.FillRectangle(aBrush, rectangle)
                aBrush.Dispose()
            Case Renderer.Outlook2007

                'Filling the top part of the button...
                Dim TopRectangle As Rectangle = rectangle
                Dim TopBrush As Brush = New LinearGradientBrush(TopRectangle, Me.GetButtonColor(buttonState, 0), Me.GetButtonColor(buttonState, 1), LinearGradientMode.Vertical)
                TopRectangle.Height = (GetButtonHeight() * 15) / 32
                graphics.FillRectangle(TopBrush, TopRectangle)
                TopBrush.Dispose()

                'and the bottom part...
                Dim BottomRectangle As Rectangle = rectangle
                Dim BottomBrush As Brush = New LinearGradientBrush(BottomRectangle, Me.GetButtonColor(buttonState, 2), Me.GetButtonColor(buttonState, 3), LinearGradientMode.Vertical)
                BottomRectangle.Y += (GetButtonHeight() * 12) / 32
                BottomRectangle.Height -= (GetButtonHeight() * 12) / 32
                graphics.FillRectangle(BottomBrush, BottomRectangle)
                BottomBrush.Dispose()
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Dim aBrush As Brush = New LinearGradientBrush(rectangle, Me.GetButtonColor(buttonState, 0), Me.GetButtonColor(buttonState, 1), LinearGradientMode.Vertical)
                graphics.FillRectangle(aBrush, rectangle)
                aBrush.Dispose()
        End Select

        'Draw Top Border...
        If DrawTopBorder Then graphics.DrawLine(New Pen(GetOutlookBarLineColor), rectangle.X, rectangle.Y, rectangle.Width + rectangle.X, rectangle.Y)

        'Draw Left Border...
        If DrawLeftBorder Then graphics.DrawLine(New Pen(GetOutlookBarLineColor), rectangle.X, rectangle.Y, rectangle.X, rectangle.Y + rectangle.Height)

        'Draw Right Border...
        If DrawRightBorder Then graphics.DrawLine(New Pen(GetOutlookBarLineColor), rectangle.X + rectangle.Width - 1, rectangle.Y, rectangle.X + rectangle.Width - 1, rectangle.Y + rectangle.Height)

    End Sub

    Private Sub PaintGripRectangle(ByVal graphics As Graphics)

        'Paint the backcolor...
        graphics.FillRectangle(Me.GetGripBrush, Me.GetGripRectangle)

        'Draw the icon...
        Dim oIcon As Icon = Me.GetGripIcon
        Dim RectangleIcon As New Rectangle(CInt((CInt(Me.Width) / 2) - (CInt(oIcon.Width / 2))), _
                                        ((CInt((GetGripRectangle.Height) / 2)) - CInt((oIcon.Height / 2))) + 1, _
                                        oIcon.Width, _
                                        oIcon.Height)
        graphics.DrawIcon(oIcon, RectangleIcon)
        graphics.DrawLine(New Pen(Me.GetGripTopColor, 1), 0, 0, Me.Width, 0)
        graphics.DrawLine(New Pen(Me.GetOutlookBarLineColor, 1), 0, 0, 0, GetGripRectangle.Height)
        graphics.DrawLine(New Pen(Me.GetOutlookBarLineColor, 1), GetGripRectangle.Width - 1, 0, GetGripRectangle.Width - 1, Me.GetGripRectangle.Height)
        oIcon.Dispose()
    End Sub

    Private Sub PaintDropDownRectangle(ByVal graphics As Graphics)

        'Repaint the backcolor if the mouse is hovering...
        Select Case Me._DropDownHovering
            Case True
                Me.FillButton(Me.GetDropDownRectangle, graphics, ButtonState.Hovering, True, False, True)
            Case False
                Me.FillButton(Me.GetDropDownRectangle, graphics, ButtonState.Passive, True, False, True)
        End Select
        'graphics.DrawRectangle(Pens.Red, Me.GetDropDownRectangle)

        'Draw the icon...
        Dim oIcon As Icon = Me.GetDropDownIcon
        Dim RectangleIcon As New Rectangle((Me.GetDropDownRectangle.X + ((Me.GetDropDownRectangle.Width / 2) - (oIcon.Width / 2))), _
                                            (Me.GetDropDownRectangle.Y + (((Me.GetDropDownRectangle.Height / 2) - (oIcon.Height / 2)) + 1)), _
                                            oIcon.Width, _
                                            oIcon.Height)
        graphics.DrawIcon(oIcon, RectangleIcon)
        oIcon.Dispose()

    End Sub


#End Region

#Region " Renderer-dependent values "

    Private Function GetOutlookBarLineColor() As Color
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Return Color.FromArgb(0, 45, 150)
            Case Renderer.Outlook2007
                Return Color.FromArgb(101, 147, 207)
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Return Me.OutlookBarLineColor
        End Select
    End Function

    Private Function GetButtonTextBrush(ByVal isSelected As Boolean) As Brush
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Return Brushes.Black
            Case Renderer.Outlook2007
                Select Case isSelected
                    Case False
                        Return New SolidBrush(Color.FromArgb(32, 77, 137))
                    Case True
                        Return Brushes.Black
                End Select
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Select Case isSelected
                    Case False
                        Return New SolidBrush(Me.ForeColor)
                    Case True
                        Return New SolidBrush(Me.ForeColorSelected)
                End Select
        End Select
        Return Nothing
    End Function
    Private Function GetButtonFont() As Font
        Select Case Me.Renderer
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Return Me.Font
            Case DMC.Interface.OutlookBar.Renderer.Outlook2003
                Return New Font("Tahoma", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            Case DMC.Interface.OutlookBar.Renderer.Outlook2007
                Return New Font("Tahoma", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
        End Select
        Return Nothing
    End Function
    Private Function GetButtonColor(ByVal buttonState As ButtonState, ByVal colorIndex As Integer) As Color
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Select Case buttonState
                    Case buttonState.Hovering Or buttonState.Selected
                        If colorIndex = 0 Then Return Color.FromArgb(232, 127, 8)
                        If colorIndex = 1 Then Return Color.FromArgb(247, 218, 124)
                    Case buttonState.Hovering
                        If colorIndex = 0 Then Return Color.FromArgb(255, 255, 220)
                        If colorIndex = 1 Then Return Color.FromArgb(247, 192, 91)
                    Case buttonState.Selected
                        If colorIndex = 0 Then Return Color.FromArgb(247, 218, 124)
                        If colorIndex = 1 Then Return Color.FromArgb(232, 127, 8)
                    Case buttonState.Passive
                        If colorIndex = 0 Then Return Color.FromArgb(203, 225, 252)
                        If colorIndex = 1 Then Return Color.FromArgb(125, 166, 223)
                End Select
            Case Renderer.Outlook2007
                Select Case buttonState
                    Case buttonState.Hovering Or buttonState.Selected
                        If colorIndex = 0 Then Return Color.FromArgb(255, 189, 105)
                        If colorIndex = 1 Then Return Color.FromArgb(255, 172, 66)
                        If colorIndex = 2 Then Return Color.FromArgb(251, 140, 60)
                        If colorIndex = 3 Then Return Color.FromArgb(254, 211, 101)
                    Case buttonState.Hovering
                        If colorIndex = 0 Then Return Color.FromArgb(255, 254, 228)
                        If colorIndex = 1 Then Return Color.FromArgb(255, 232, 166)
                        If colorIndex = 2 Then Return Color.FromArgb(255, 215, 103)
                        If colorIndex = 3 Then Return Color.FromArgb(255, 230, 159)
                    Case buttonState.Selected
                        If colorIndex = 0 Then Return Color.FromArgb(255, 217, 170)
                        If colorIndex = 1 Then Return Color.FromArgb(255, 187, 109)
                        If colorIndex = 2 Then Return Color.FromArgb(255, 171, 63)
                        If colorIndex = 3 Then Return Color.FromArgb(254, 225, 123)
                    Case buttonState.Passive
                        If colorIndex = 0 Then Return Color.FromArgb(227, 239, 255)
                        If colorIndex = 1 Then Return Color.FromArgb(196, 221, 255)
                        If colorIndex = 2 Then Return Color.FromArgb(173, 209, 255)
                        If colorIndex = 3 Then Return Color.FromArgb(193, 219, 255)
                End Select
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Select Case buttonState
                    Case buttonState.Hovering Or buttonState.Selected
                        If colorIndex = 0 Then Return Me.ButtonColorSelectedAndHoveringTop
                        If colorIndex = 1 Then Return Me.ButtonColorSelectedAndHoveringBottom
                    Case buttonState.Hovering
                        If colorIndex = 0 Then Return Me.ButtonColorHoveringTop
                        If colorIndex = 1 Then Return Me.ButtonColorHoveringBottom
                    Case buttonState.Selected
                        If colorIndex = 0 Then Return Me.ButtonColorSelectedTop
                        If colorIndex = 1 Then Return Me.ButtonColorSelectedBottom
                    Case buttonState.Passive
                        If colorIndex = 0 Then Return Me.ButtonColorPassiveTop
                        If colorIndex = 1 Then Return Me.ButtonColorPassiveBottom
                End Select
        End Select
    End Function
    Private Function GetButtonHeight() As Integer
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Return 32
            Case Renderer.Outlook2007
                Return 32
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Return Me.ButtonHeight
        End Select
    End Function

    Private Function GetBottomContainerRectangle() As Rectangle
        Return New Rectangle(0, Me.Height - Me.GetButtonHeight, Me.Width, Me.GetButtonHeight)
    End Function
    Private Function GetBottomContainerLeftMargin() As Integer
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Return 15
            Case Renderer.Outlook2007
                Return 16
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Return 16
        End Select
    End Function

    Private Function GetSmallButtonWidth() As Integer
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Return 22
            Case Renderer.Outlook2007
                Return 26
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Return 25
        End Select
    End Function

    Private Function GetGripBrush() As Brush
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Return New LinearGradientBrush(Me.GetGripRectangle, Color.FromArgb(89, 135, 214), Color.FromArgb(0, 45, 150), LinearGradientMode.Vertical)
            Case Renderer.Outlook2007
                Return New LinearGradientBrush(Me.GetGripRectangle, Color.FromArgb(227, 239, 255), Color.FromArgb(179, 212, 255), LinearGradientMode.Vertical)
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Return New LinearGradientBrush(Me.GetGripRectangle, Me.ButtonColorPassiveTop, Me.ButtonColorPassiveBottom, LinearGradientMode.Vertical)
        End Select
        Return Nothing
    End Function
    Private Function GetGripRectangle() As Rectangle
        Dim Height As Integer
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Height = 6
            Case Renderer.Outlook2007
                Height = 8
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Height = 8
        End Select
        GetGripRectangle = New Rectangle(0, 0, Me.Width, Height)
    End Function
    Private Function GetGripIcon() As Icon
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Return My.Resources.Grip2003
            Case Renderer.Outlook2007
                Return My.Resources.Grip2007
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Return My.Resources.Grip2007
        End Select
        Return Nothing
    End Function
    Private Function GetGripTopColor() As Color
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Return Color.Transparent
            Case Renderer.Outlook2007
                Return GetOutlookBarLineColor()
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Return Color.Transparent
        End Select
    End Function

    Private Function GetDropDownRectangle() As Rectangle
        GetDropDownRectangle = New Rectangle((Me.Width - GetSmallButtonWidth()), _
                                                (Me.Height - GetButtonHeight()), _
                                                GetSmallButtonWidth, _
                                                GetButtonHeight)
    End Function
    Private Function GetDropDownIcon() As Icon
        Select Case Me.Renderer
            Case Renderer.Outlook2003
                Return My.Resources.DropDown2003
            Case Renderer.Outlook2007
                Return My.Resources.DropDown2007
            Case DMC.Interface.OutlookBar.Renderer.Custom
                Return My.Resources.DropDown2007
        End Select
        Return Nothing
    End Function

#End Region

#Region " MenuItems and Options "

    ''Private Sub CreateContextMenu()
    ''    Me.oContextMenuStrip = New ContextMenuStrip
    ''    Me.oContextMenuStrip.Items.Add("Show &More Buttons", My.Resources.Arrow_Up.ToBitmap, AddressOf ShowMoreButtons)
    ''    Me.oContextMenuStrip.Items.Add("Show Fe&wer Buttons", My.Resources.Arrow_Down.ToBitmap, AddressOf ShowFewerButtons)
    ''    If Me.MaxLargeButtonCount >= Me.Buttons.CountVisible Then Me.oContextMenuStrip.Items(0).Enabled = False
    ''    If Me.MaxLargeButtonCount = 0 Then Me.oContextMenuStrip.Items(1).Enabled = False
    ''    Me.oContextMenuStrip.Items.Add("Na&vigation Pane Options...", Nothing, AddressOf NavigationPaneOptions)
    ''    Dim mnuAdd As New ToolStripMenuItem("&Add or Remove Buttons", Nothing)
    ''    Me.oContextMenuStrip.Items.Add(mnuAdd)
    ''    For Each oButton As DMC.Interface.OutlookBar.OutlookBarButton In Me.Buttons
    ''        If oButton.Allowed Then
    ''            Dim mnuA As New ToolStripMenuItem
    ''            With mnuA
    ''                .Text = oButton.Text
    ''                .Image = oButton.Image.ToBitmap
    ''                .CheckOnClick = True
    ''                .Checked = oButton.Visible
    ''                .Tag = oButton
    ''            End With
    ''            AddHandler mnuA.Click, AddressOf ToggleVisible
    ''            mnuAdd.DropDownItems.Add(mnuA)
    ''        End If
    ''    Next
    ''    Dim c As Integer = 0
    ''    For Each oButton As DMC.Interface.OutlookBar.OutlookBarButton In Me.Buttons
    ''        If oButton.Visible Then
    ''            If oButton.Rectangle = Nothing Then c += 1
    ''        End If
    ''    Next
    ''    If c > 0 Then Me.oContextMenuStrip.Items.Add(New ToolStripSeparator)
    ''    For Each oButton As DMC.Interface.OutlookBar.OutlookBarButton In Me.Buttons
    ''        If oButton.Rectangle = Nothing Then
    ''            If oButton.Visible Then
    ''                Dim mnu As New ToolStripMenuItem
    ''                With mnu
    ''                    .Text = oButton.Text
    ''                    .Image = oButton.Image.ToBitmap
    ''                    .Tag = oButton
    ''                    .CheckOnClick = True
    ''                    If Not Me.SelectedButton Is Nothing Then
    ''                        If Me.SelectedButton.Equals(oButton) Then .Checked = True
    ''                    End If
    ''                End With
    ''                AddHandler mnu.Click, AddressOf MnuClicked
    ''                Me.oContextMenuStrip.Items.Add(mnu)
    ''            End If
    ''        End If
    ''    Next
    ''    Me.oContextMenuStrip.Show(Me, New Point(Me.Width, Me.Height - (GetButtonHeight() / 2)))
    ''End Sub
    ''Private Sub ShowMoreButtons(ByVal sender As Object, ByVal e As System.EventArgs)
    ''    Me.Height += GetButtonHeight()
    ''End Sub
    ''Private Sub ShowFewerButtons(ByVal sender As Object, ByVal e As System.EventArgs)
    ''    Me.Height -= GetButtonHeight()
    ''End Sub
    ''Private Sub NavigationPaneOptions(ByVal sender As Object, ByVal e As System.EventArgs)
    ''    Me._RightClickedButton = Nothing
    ''    Me._HoveringButton = Nothing
    ''    Me.Invalidate()
    ''    Dim frm As New frmNavigationPaneOptions(Me.Buttons)
    ''    frm.ShowDialog()
    ''    Me.Invalidate()
    ''End Sub
    ''Private Sub ToggleVisible(ByVal sender As Object, ByVal e As System.EventArgs)
    ''    Dim oButton As DMC.Interface.OutlookBar.OutlookBarButton = CType(CType(sender, ToolStripMenuItem).Tag, DMC.Interface.OutlookBar.OutlookBarButton)
    ''    oButton.Visible = Not oButton.Visible
    ''    Me.Invalidate()
    ''End Sub
    ''Private Sub MnuClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    ''    Dim oButton As DMC.Interface.OutlookBar.OutlookBarButton = CType(CType(sender, ToolStripMenuItem).Tag, DMC.Interface.OutlookBar.OutlookBarButton)
    ''    Me._SelectedButton = oButton
    ''    RaiseEvent ButtonClicked(Me, New System.EventArgs)
    ''End Sub

#End Region

End Class

Friend Enum ButtonState
    Passive
    Hovering
    Selected
End Enum

Public Enum Renderer
    Outlook2003
    Outlook2007
    Custom
End Enum

