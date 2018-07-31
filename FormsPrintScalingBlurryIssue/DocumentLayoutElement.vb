
Imports System.ComponentModel

Public Class DocumentLayoutElement
    Implements ICloneable

    Private Shared _NotFoundImage As Bitmap
    Private Shared ReadOnly Property NotFoundImage As Bitmap
        Get
            If _NotFoundImage Is Nothing Then
                _NotFoundImage = New Bitmap(320, 320)
                Using g = Graphics.FromImage(_NotFoundImage)
                    Using p As New Pen(Color.Red, 4)
                        g.DrawRectangle(p, 2, 2, 318, 318)
                        g.DrawLine(p, 0, 0, 320, 320)
                        g.DrawLine(p, 0, 320, 320, 0)
                    End Using
                End Using
            End If
            Return _NotFoundImage
        End Get
    End Property

    Friend ProposedPosition As Point

    <Category("Appearance")>
    <Description("Fills the element background with the selected color.  Set to 0 or Transparent for no background.")>
    Public Property Backcolor As Color = Color.Empty

    Private backgroundImage As Image
    Private _BackgroundImagePath As String
    <Category("Background Image")>
    <Description("The image to draw in the background of the element when ImageLayoutStyle is set to something other than None.")>
    <EditorAttribute(GetType(System.Windows.Forms.Design.FileNameEditor), GetType(System.Drawing.Design.UITypeEditor))>
    Public Property BackgroundImagePath As String
        Get
            Return _BackgroundImagePath
        End Get
        Set(value As String)
            _BackgroundImagePath = value
            backgroundImage?.Dispose()
            backgroundImage = Nothing
        End Set
    End Property

    <Category("Border")>
    <Description("The style of border drawn around the element bounds when BorderWidth and BorderColor are set.")>
    Public Property BorderStyle As ButtonBorderStyle

    <Category("Border")>
    <Description("The width of the border drawn around the element bounds when BorderStyle and BorderColor are set.")>
    Public Property BorderWidth As Integer

    <Category("Border")>
    <Description("The color of the border drawn around the element bounds when BorderStyle and BorderWidth are set.")>
    Public Property BorderColor As Color

    <Category("Font")>
    <Description("The font used to draw the text when the FontColor and Text are set.")>
    Public Property Font As Font = SystemFonts.DefaultFont

    <Category("Font")>
    <Description("The color of the drawn text when the Font and Text are set.")>
    Public Property FontColor As Color = SystemColors.WindowText

    <Category("Background Image")>
    <Description("Defines how the background image is drawn within the bounds of the element when BackgroundImagePath is set to a valid image file.")>
    Public Property ImageLayoutStyle As ImageLayout

    <Category("Behavior")>
    <Description("The name of the element is used to link the content to a data source in the Print Map Editor.")>
    Public Property Name As String

    Friend _Position As Point
    <Category("Layout")>
    <Description("The top and left location of the element, in pixels.")>
    Public Property Position As Point
        Get
            Return _Position
        End Get
        Set(value As Point)
            _Position = value
            ProposedPosition = value
        End Set
    End Property

    <Category("Layout")>
    <Description("The width and height of the element, in pixels.")>
    Public Property Size As Size

    <Category("Text")>
    <Description("The text displayed in the element when the font and text color are set.")>
    Public Property Text As String

    <Category("Text")>
    <Description("The left-to-right alignment of the text within the bounds of the element.")>
    Public Property TextHorizontalAlign As StringAlignment

    <Category("Text")>
    <Description("The top-to-bottom alignment of the text within the bounds of the element.")>
    Public Property TextVerticalAlign As StringAlignment

    <Category("Appearance")>
    <Description("Whether or not this element is drawn in the document.")>
    Public Property Visible As Boolean = True

    <Category("Layout")>
    <Description("Determines the drawing and selecting order of overlapping elements.  Higher numbers are above lower numbers; higher numbers are selected first, lower numbers are drawn first.")>
    Public Property ZOrder As Integer

    Public Function AsXElement() As XElement
        Return <LayoutElement name=<%= Name %> backcolor=<%= Backcolor.Name %> positionX=<%= Position.X %> positionY=<%= Position.Y %> width=<%= Size.Width %> height=<%= Size.Height %> zorder=<%= ZOrder %>>
                   <border style=<%= BorderStyle %> width=<%= BorderWidth %> color=<%= BorderColor.Name %>/>
                   <font family=<%= Font.FontFamily.Name %> size=<%= Font.Size %> style=<%= Font.Style %> color=<%= FontColor.Name %>/>
                   <image path=<%= BackgroundImagePath %> layout=<%= ImageLayoutStyle %>/>
                   <text value=<%= Text %> halign=<%= TextHorizontalAlign %> valign=<%= TextVerticalAlign %>/>
               </LayoutElement>
    End Function

    Public Shared Function FromXElement(e As XElement) As DocumentLayoutElement
        If e Is Nothing Then Return Nothing
        If Not e.Name = "LayoutElement" Then Return Nothing
        Dim result As New DocumentLayoutElement
        result.Name = e.@name
        result.Backcolor = Color.FromName(e.@backcolor)
        result.Position = New Point(CInt(e.@positionX), CInt(e.@positionY))
        result.Size = New Size(CInt(e.@width), CInt(e.@height))
        result.ZOrder = CInt(e.@zorder)
        Dim b = e.<border>
        Try
            result.BorderStyle = CType([Enum].Parse(GetType(ButtonBorderStyle), b.@style), ButtonBorderStyle)
        Catch ex As Exception
            result.BorderStyle = ButtonBorderStyle.Solid
        End Try

        result.BorderWidth = CInt(b.@width)
        result.BorderColor = Color.FromName(b.@color)
        Dim f = e.<font>
        result.Font = New Font(f.@family, CSng(f.@size), CType([Enum].Parse(GetType(FontStyle), f.@style), FontStyle))
        result.FontColor = Color.FromName(f.@color)
        Dim i = e.<image>
        result.BackgroundImagePath = i.@path
        result.ImageLayoutStyle = CType([Enum].Parse(GetType(ImageLayout), i.@layout), ImageLayout)
        Dim t = e.<text>
        result.Text = t.@value
        result.TextHorizontalAlign = CType([Enum].Parse(GetType(StringAlignment), t.@halign), StringAlignment)
        result.TextVerticalAlign = CType([Enum].Parse(GetType(StringAlignment), t.@valign), StringAlignment)
        Return result
    End Function

    Public Sub Draw(g As Graphics)
        If Not _Visible Then Exit Sub
        Dim bounds As New Rectangle(Position, Size)
        If Not Backcolor = Color.Empty Then
            Using brsh As New SolidBrush(Backcolor)
                g.FillRectangle(brsh, bounds)
            End Using
        End If

        If backgroundImage Is Nothing AndAlso Not String.IsNullOrEmpty(BackgroundImagePath) Then
            If IO.File.Exists(BackgroundImagePath) Then
                Try
                    backgroundImage = Image.FromFile(BackgroundImagePath)
                Catch ex As Exception
                    backgroundImage = NotFoundImage
                End Try
            Else
                backgroundImage = NotFoundImage
            End If
        End If

        If backgroundImage IsNot Nothing AndAlso Not ImageLayoutStyle = ImageLayout.None Then
            Dim dst As Rectangle
            Select Case ImageLayoutStyle
                Case ImageLayout.Center
                    Dim center = New Point(bounds.Width * 0.5, bounds.Height * 0.5) + bounds.Location
                    center.X -= backgroundImage.Width * 0.5
                    center.Y -= backgroundImage.Height * 0.5
                    dst = New Rectangle(center, backgroundImage.Size)
                    g.SetClip(bounds)
                Case ImageLayout.Stretch
                    dst = bounds
                Case ImageLayout.Tile
                    dst = New Rectangle(bounds.Location, backgroundImage.Size)
                Case ImageLayout.Zoom
                    dst.Location = bounds.Location
                    If backgroundImage.Width >= backgroundImage.Height Then
                        dst.Width = bounds.Width
                        dst.Height = bounds.Width * (backgroundImage.Height / backgroundImage.Width)
                        dst.Y += (bounds.Height * 0.5) - (dst.Height * 0.5)
                    Else
                        dst.Height = bounds.Height
                        dst.Width = bounds.Height * (backgroundImage.Width / backgroundImage.Height)
                        dst.X += (bounds.Width * 0.5) - (dst.Width * 0.5)
                    End If
                    g.SetClip(bounds)
            End Select
            If ImageLayoutStyle = ImageLayout.Tile Then
                While dst.Y < bounds.Height - backgroundImage.Height
                    While dst.X < bounds.Width - backgroundImage.Width
                        g.DrawImage(backgroundImage, dst, 0, 0, backgroundImage.Width, backgroundImage.Height, GraphicsUnit.Pixel)
                        dst.X += backgroundImage.Width
                    End While
                    dst.X = bounds.Left
                    dst.Y += backgroundImage.Height
                End While
            Else
                g.DrawImage(backgroundImage, dst, 0, 0, backgroundImage.Width, backgroundImage.Height, GraphicsUnit.Pixel)
                g.ResetClip()
            End If
        End If

        If Not String.IsNullOrEmpty(Text) AndAlso Font IsNot Nothing AndAlso Not FontColor = Color.Empty Then
            Using fmt As New StringFormat, brsh As New SolidBrush(FontColor)
                fmt.Alignment = TextHorizontalAlign
                fmt.LineAlignment = TextVerticalAlign
                g.DrawString(Text, Font, brsh, bounds, fmt)
            End Using
        End If

        If Not BorderStyle = ButtonBorderStyle.None Then
            ControlPaint.DrawBorder(g, bounds, BorderColor, BorderStyle)
        End If
        'If BorderStyle = BorderStyle.Fixed3D Then
        '    ControlPaint.DrawBorder3D(g, bounds)
        'ElseIf BorderStyle = BorderStyle.FixedSingle Then
        '    bounds.Inflate(-BorderWidth, -BorderWidth)
        '    Using p As New Pen(BorderColor, BorderWidth)
        '        g.DrawRectangle(p, bounds)
        '    End Using
        'End If
    End Sub

    Protected Function ICloneable_Clone() As Object Implements ICloneable.Clone
        Return Clone()
    End Function

    Public Function Clone() As DocumentLayoutElement
        Dim result = DocumentLayoutElement.FromXElement(AsXElement)
        result.Name &= " (clone)"
        Return result
    End Function

    Friend Sub SetBackgroundImage(existingImage As Image)
        BackgroundImagePath = "(Image Supplied Internally)"
        backgroundImage = existingImage
        ImageLayoutStyle = ImageLayout.Center
    End Sub
End Class