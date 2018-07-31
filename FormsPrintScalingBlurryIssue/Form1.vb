Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using designerForm As New DocumentLayoutDesigner
            designerForm.ShowDialog()
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using printPreview As New InvoicePrintDialog
            printPreview.ShowDialog()
        End Using
    End Sub
End Class
