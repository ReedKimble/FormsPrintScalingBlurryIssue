Imports System.Windows.Forms

Public Class InvoicePrintDialog
    Public Property DocumentLayoutFilePath As String = "Documents\Invoice Header Default.xmldl"

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = PrintDialog1.ShowDialog
        If Me.DialogResult = DialogResult.OK Then PrintDocument1.Print()
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim docLayout As New DocumentLayout
        docLayout.ReadXml(DocumentLayoutFilePath)

        Using tmpbmp As New Bitmap(CInt(docLayout.PageSize.Width * DeviceDpi), CInt(docLayout.PageSize.Height * DeviceDpi))
            Using gfx = Graphics.FromImage(tmpbmp)
                gfx.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                gfx.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                gfx.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                gfx.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

                For Each element In docLayout
                    element.Draw(gfx)
                Next
            End Using
            e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            e.Graphics.DrawImage(tmpbmp, e.MarginBounds, 0, 0, tmpbmp.Width, tmpbmp.Height, GraphicsUnit.Pixel)
        End Using
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If PageSetupDialog1.ShowDialog() = DialogResult.Cancel Then
            PageSetupDialog1.Reset()
        End If
        PrintPreviewControl1.InvalidatePreview()
    End Sub

    Private Sub InvoicePrintDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrintDocument1.DefaultPageSettings.Margins = New Printing.Margins(50, 50, 50, 50)
    End Sub
End Class
