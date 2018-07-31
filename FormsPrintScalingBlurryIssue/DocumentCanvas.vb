Imports System.Drawing.Drawing2D

Public Class DocumentCanvas
    Public Event ElementAdded As EventHandler
    Public Event SelectedElementChanged As EventHandler
    Public Event ScrollChanged As EventHandler

    Private _DocumentLayout As DocumentLayout
    Public Property DocumentLayout As DocumentLayout
        Get
            Return _DocumentLayout
        End Get
        Set(value As DocumentLayout)
            _DocumentLayout = value
            If DocumentLayout IsNot Nothing Then _pageSize = _DocumentLayout.PageSize
            Invalidate()
        End Set
    End Property

    Private _GridSize As Integer
    Public Property GridSize As Integer
        Get
            Return _GridSize
        End Get
        Set(value As Integer)
            _GridSize = value
            Invalidate()
        End Set
    End Property

    Public Property SnapToGrid As Boolean

    Private _Mode As CanvasMode
    Public Property Mode As CanvasMode
        Get
            Return _Mode
        End Get
        Set(value As CanvasMode)
            _Mode = value
            Select Case _Mode
                Case CanvasMode.Select
                    Cursor = Cursors.Arrow
                Case CanvasMode.AddElement
                    Cursor = Cursors.Cross
            End Select
        End Set
    End Property

    Public ReadOnly Property SelectedElement As DocumentLayoutElement
    Public ReadOnly Property ScrollDelta As Size
        Get
            Return _scrollOffset
        End Get
    End Property

    Private _Zoom As Single = 1.0!
    Public Property Zoom As Single
        Get
            Return _Zoom
        End Get
        Set(value As Single)
            If Not _Zoom = value Then
                If value = 0 Then
                    _Zoom = 1
                Else
                    _Zoom = Math.Abs(value)
                End If
                RaiseEvent ScrollChanged(Me, EventArgs.Empty)
                Invalidate()
            End If
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        DoubleBuffered = True
    End Sub

    Public Sub SetSelected(element As DocumentLayoutElement)
        If Not _SelectedElement Is element Then
            _SelectedElement = element
            OnSelectedElementChanged()
            Invalidate()
        End If
    End Sub

    Public Sub SetPageWidth(width As Single)
        _pageSize.Width = width
        If DocumentLayout IsNot Nothing Then DocumentLayout.PageSize = New SizeF(width, DocumentLayout.PageSize.Height)
        Invalidate()
    End Sub

    Public Sub SetPageHeight(height As Single)
        _pageSize.Height = height
        If DocumentLayout IsNot Nothing Then DocumentLayout.PageSize = New SizeF(DocumentLayout.PageSize.Width, height)
        Invalidate()
    End Sub

    Public Sub Copy()
        If _SelectedElement IsNot Nothing Then
            Clipboard.SetText(_SelectedElement.AsXElement.ToString)
        End If
    End Sub

    Public Sub Paste()
        If Clipboard.ContainsText Then
            Dim xe As XElement
            Try
                xe = XElement.Parse(Clipboard.GetText)
            Catch ex As Exception
                MessageBox.Show("Could not create document element from clipboard text.", "Paste Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
            Try
                AddElement(DocumentLayoutElement.FromXElement(xe), PointToClient(MousePosition))
            Catch ex As Exception
                MessageBox.Show("Could not create document element from xml.", "Paste Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub

    Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Up, Keys.Down, Keys.Left, Keys.Right
                Return True
        End Select
        Return MyBase.IsInputKey(keyData)
    End Function

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        If _SelectedElement IsNot Nothing Then
            Dim i = 1
            If GridSize > i Then i = GridSize
            Dim p = _SelectedElement.Position
            Select Case e.KeyCode
                Case Keys.Up
                    p.Y -= i
                Case Keys.Down
                    p.Y += i
                Case Keys.Left
                    p.X -= i
                Case Keys.Right
                    p.X += i
            End Select
            _SelectedElement.Position = p
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
        MyBase.OnKeyUp(e)
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.C
                    Copy()
                Case Keys.V
                    Paste()
                Case Keys.Home
                    _scrollOffset = Size.Empty
                    Invalidate()
            End Select
        Else
            Select Case e.KeyCode
                Case Keys.Home
                    If _SelectedElement IsNot Nothing Then
                        _SelectedElement.Position = Point.Empty
                        Invalidate()
                    End If
            End Select
        End If
    End Sub

    Public Sub TransformBounds(ByRef bounds As Rectangle)
        Using m As New Drawing2D.Matrix
            m.Translate(_scrollOffset.Width, _scrollOffset.Height)
            m.Scale(_Zoom, _Zoom)
            Dim pts = {bounds.Location, New Point(bounds.Right, bounds.Bottom)}
            m.TransformPoints(pts)
            bounds.Location = pts(0)
            bounds.Width = pts(1).X - pts(0).X
            bounds.Height = pts(1).Y - pts(0).Y
        End Using
    End Sub

    Public Sub TransformPoint(ByRef pt As Point)
        Using m As New Drawing2D.Matrix
            m.Translate(_scrollOffset.Width, _scrollOffset.Height)
            m.Scale(_Zoom, _Zoom)
            m.TransformPoints({pt})
        End Using
    End Sub

    Public Sub InverseTransformPoint(ByRef pt As Point)
        Using m As New Drawing2D.Matrix
            m.Translate(_scrollOffset.Width, _scrollOffset.Height, Drawing2D.MatrixOrder.Prepend)
            m.Scale(_Zoom, _Zoom, Drawing2D.MatrixOrder.Prepend)
            m.Invert()
            m.TransformPoints({pt})
        End Using
    End Sub

    Private _pageSize As SizeF = New SizeF(7.5, 10)
    Private _scrollOffset As Size
    Private _lastMousePos As Point
    Private _mouseDownPos As Point
    Private _selectBounds As Rectangle
    Private _isSelecting As Boolean
    Private _isDragging As Boolean

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If DocumentLayout Is Nothing Then Exit Sub
        _isDragging = False
        Select Case Mode
            Case CanvasMode.Select
                If e.Button = MouseButtons.Left Then
                    _isSelecting = False
                    _selectBounds.Size = Size.Empty
                    _mouseDownPos = e.Location
                    _selectBounds.Location = _mouseDownPos
                    If _SelectedElement IsNot Nothing Then
                        Dim bounds = New Rectangle(_SelectedElement.Position, _SelectedElement.Size)
                        TransformBounds(bounds)
                        If Not bounds.Contains(e.Location) Then
                            _SelectedElement = Nothing
                            Invalidate()
                        Else
                            If Math.Abs(bounds.Right - e.X) < 12 Then
                                Mode = CanvasMode.ResizeElementH
                            End If
                            If Math.Abs(bounds.Bottom - e.Y) < 12 Then
                                If Mode = CanvasMode.ResizeElementH Then
                                    Mode = CanvasMode.ResizeElementB
                                Else
                                    Mode = CanvasMode.ResizeElementV
                                End If
                            End If
                        End If
                    End If
                End If
            Case CanvasMode.AddElement

        End Select
        _lastMousePos = e.Location
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        If Not Cursor = Cursors.Default Then Cursor = Cursors.Default
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If DocumentLayout Is Nothing Then Exit Sub
        Select Case Mode
            Case CanvasMode.Select
                Dim mouseDelta = e.Location - _lastMousePos
                If e.Button = MouseButtons.Left Then
                    If _SelectedElement IsNot Nothing Then
                        Dim pt = _SelectedElement.Position + mouseDelta
                        TransformPoint(pt)
                        _SelectedElement.Position = pt
                        If Not _isDragging Then _isDragging = True
                    Else
                        If e.Location.X < _mouseDownPos.X Then
                            _selectBounds.X += mouseDelta.X
                            _selectBounds.Width -= mouseDelta.X
                        Else
                            _selectBounds.Width += mouseDelta.X
                        End If
                        If e.Location.Y < _mouseDownPos.Y Then
                            _selectBounds.Y += mouseDelta.Y
                            _selectBounds.Height -= mouseDelta.Y
                        Else
                            _selectBounds.Height += mouseDelta.Y
                        End If
                        If Not _isSelecting Then _isSelecting = True
                    End If
                    Invalidate()
                ElseIf e.Button = MouseButtons.Right Then
                    _scrollOffset += New Size(mouseDelta)
                    RaiseEvent ScrollChanged(Me, EventArgs.Empty)
                    Invalidate()
                Else
                    If Not Cursor = Cursors.Default Then Cursor = Cursors.Default
                    If _SelectedElement IsNot Nothing Then
                        Dim bounds = New Rectangle(_SelectedElement.Position, _SelectedElement.Size)
                        TransformBounds(bounds)
                        If bounds.Contains(e.Location) Then
                            If Math.Abs(bounds.Right - e.X) < 12 Then
                                Cursor = Cursors.SizeWE
                            End If
                            If Math.Abs(bounds.Bottom - e.Y) < 12 Then
                                If Cursor = Cursors.SizeWE Then
                                    Cursor = Cursors.SizeNWSE
                                Else
                                    Cursor = Cursors.SizeNS
                                End If
                            End If
                        End If
                    End If
                End If
                _lastMousePos = e.Location
            Case CanvasMode.AddElement

            Case CanvasMode.ResizeElementH, CanvasMode.ResizeElementV, CanvasMode.ResizeElementB
                If e.Button = MouseButtons.Left Then
                    Dim mouseDelta = e.Location - _lastMousePos
                    If _SelectedElement IsNot Nothing Then
                        Dim sz = _SelectedElement.Size
                        Select Case Mode
                            Case CanvasMode.ResizeElementH
                                sz.Width += mouseDelta.X
                            Case CanvasMode.ResizeElementV
                                sz.Height += mouseDelta.Y
                            Case Else
                                sz.Width += mouseDelta.X
                                sz.Height += mouseDelta.Y
                        End Select
                        _SelectedElement.Size = sz
                    End If
                    _lastMousePos = e.Location
                    Invalidate()
                End If
        End Select
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If DocumentLayout Is Nothing Then Exit Sub

        Select Case Mode
            Case CanvasMode.Select
                If e.Button = MouseButtons.Left Then
                    If _isDragging Then
                        _isDragging = False
                        Exit Select
                    End If
                    Dim found As Boolean = False
                    For Each element In (From le In DocumentLayout Order By le.ZOrder Descending)
                        Dim bounds = New Rectangle(element.Position, element.Size)
                        TransformBounds(bounds)
                        If _isSelecting Then
                            If _selectBounds.Contains(bounds) Then
                                If Not _SelectedElement Is element Then
                                    _SelectedElement = element
                                    OnSelectedElementChanged()
                                End If
                                found = True
                                Exit For
                            End If
                        Else
                            If bounds.Contains(e.Location) Then
                                If Not _SelectedElement Is element Then
                                    _SelectedElement = element
                                    OnSelectedElementChanged()
                                End If
                                found = True
                                Exit For
                            End If
                        End If
                    Next
                    If Not found AndAlso _SelectedElement IsNot Nothing Then
                        _SelectedElement = Nothing
                        OnSelectedElementChanged()
                    End If
                    If SnapToGrid Then SnapSelectedElementPosition()
                    _lastMousePos = e.Location
                    _isSelecting = False
                    _selectBounds.Size = Size.Empty
                    If Not Cursor = Cursors.Default Then Cursor = Cursors.Default
                    Invalidate()
                End If
            Case CanvasMode.AddElement
                AddElement($"Element{DocumentLayout.ElementCount + 1}", e.Location - _scrollOffset)
            Case CanvasMode.ResizeElementB, CanvasMode.ResizeElementH, CanvasMode.ResizeElementV
                Mode = CanvasMode.Select
                If SnapToGrid Then SnapSelectedElementSize()
        End Select
    End Sub

    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        MyBase.OnMouseWheel(e)
        Zoom += Math.Sign(e.Delta) * 0.05
        RaiseEvent ScrollChanged(Me, EventArgs.Empty)
    End Sub

    Public Sub ResetScroll()
        _scrollOffset = Size.Empty
        RaiseEvent ScrollChanged(Me, EventArgs.Empty)
        Invalidate()
    End Sub

    Private Sub SnapSelectedElementPosition()
        If _SelectedElement Is Nothing Then Exit Sub
        If _GridSize < 2 Then Exit Sub
        Dim p = _SelectedElement.Position
        p.X = Math.Round(p.X / _GridSize) * _GridSize
        p.Y = Math.Round(p.Y / _GridSize) * _GridSize
        TransformPoint(p)
        _SelectedElement.Position = p
    End Sub

    Private Sub SnapSelectedElementSize()
        If _SelectedElement Is Nothing Then Exit Sub
        If GridSize < 2 Then Exit Sub
        Dim s = _SelectedElement.Size
        s.Width = Math.Round(s.Width / GridSize) * GridSize
        s.Height = Math.Round(s.Height / GridSize) * GridSize
        _SelectedElement.Size = s
    End Sub

    Public Sub AddElement(name As String, location As Point)
        Dim le = New DocumentLayoutElement
        le.Name = name
        While DocumentLayout.ContainsElement(le.Name)
            le.Name &= "_1"
        End While
        le.Position = location
        le.Size = New Size(100, 32)
        DocumentLayout.AddElement(le)
        _SelectedElement = le
        OnElementAdded()
        OnSelectedElementChanged()
        Invalidate()
    End Sub

    Public Sub AddElement(element As DocumentLayoutElement, location As Point)
        If element Is Nothing Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            Exit Sub
        End If
        Dim le = element
        While DocumentLayout.ContainsElement(le.Name)
            le.Name &= "_1"
        End While
        le.Position = location
        DocumentLayout.AddElement(le)
        _SelectedElement = le
        OnElementAdded()
        OnSelectedElementChanged()
        Invalidate()
    End Sub


    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.Clear(SystemColors.Control)
        If DocumentLayout IsNot Nothing Then
            e.Graphics.TranslateTransform(_scrollOffset.Width, _scrollOffset.Height)
            If Not _Zoom = 1.0! Then e.Graphics.ScaleTransform(_Zoom, _Zoom)

            Dim marginBounds As New RectangleF(0, 0, _pageSize.Width, _pageSize.Height)
            e.Graphics.FillRectangle(SystemBrushes.Window, marginBounds)

            If GridSize > 1 Then ControlPaint.DrawGrid(e.Graphics, Rectangle.Truncate(marginBounds), New Size(GridSize, GridSize), SystemColors.Window)

            For Each element In (From le In DocumentLayout Order By le.ZOrder)
                Dim bounds = New Rectangle(element.Position, element.Size)
                element.Draw(e.Graphics)
                ControlPaint.DrawBorder(e.Graphics, bounds, SystemColors.ActiveBorder, ButtonBorderStyle.Dashed)
                If element Is _SelectedElement Then
                    Using brsh As New SolidBrush(Color.FromArgb(64, SystemColors.Highlight))
                        e.Graphics.FillRectangle(brsh, bounds)
                    End Using
                    Using p As New Pen(ControlPaint.Light(SystemColors.Highlight), 3)
                        e.Graphics.DrawRectangle(p, bounds)
                    End Using
                End If
            Next

            Using p As New Pen(SystemColors.WindowFrame, 1 / e.Graphics.DpiX)
                e.Graphics.DrawRectangle(p, marginBounds.X, marginBounds.Y, marginBounds.Width, marginBounds.Height)
            End Using
            e.Graphics.ResetTransform()

            If _isSelecting Then
                Dim inner = _selectBounds
                inner.Inflate(-1, -1)
                ControlPaint.DrawSelectionFrame(e.Graphics, True, _selectBounds, inner, SystemColors.Window)
            End If
        End If
        ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle)
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        Invalidate()
    End Sub

    Protected Sub OnElementAdded()
        RaiseEvent ElementAdded(Me, EventArgs.Empty)
    End Sub

    Protected Sub OnSelectedElementChanged()
        RaiseEvent SelectedElementChanged(Me, EventArgs.Empty)
    End Sub

    Public Enum CanvasMode
        [Select]
        AddElement
        ResizeElementH
        ResizeElementV
        ResizeElementB
    End Enum
End Class
