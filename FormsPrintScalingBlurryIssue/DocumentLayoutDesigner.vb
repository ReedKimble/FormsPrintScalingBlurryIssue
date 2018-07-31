Public Class DocumentLayoutDesigner
    Private documentLayout As DocumentLayout

    Public Sub SetLayout(layout As DocumentLayout)
        documentLayout = layout
        DocumentCanvas1.DocumentLayout = documentLayout
        BindingSource1.Clear()
        ListBox1.DataSource = BindingSource1
        BindingSource1.SuspendBinding()
        For Each element In layout
            BindingSource1.Add(element)
        Next
        BindingSource1.ResumeBinding()
        ListBox1.DisplayMember = "Name"
    End Sub

    Private Sub FlowLayoutPanel1_SizeChanged(sender As Object, e As EventArgs) Handles FlowLayoutPanel1.SizeChanged
        SelectButton.Width = FlowLayoutPanel1.ClientSize.Width - FlowLayoutPanel1.Margin.Horizontal - SelectButton.Margin.Horizontal
    End Sub

    Private Sub NewLayoutButton_Click(sender As Object, e As EventArgs) Handles NewLayoutButton.Click
        SetLayout(New DocumentLayout)
    End Sub

    Private Sub SelectButton_CheckedChanged(sender As Object, e As EventArgs) Handles SelectButton.CheckedChanged, AddElementButton.CheckedChanged
        If SelectButton.Checked Then
            DocumentCanvas1.Mode = DocumentCanvas.CanvasMode.Select
        ElseIf AddElementButton.Checked Then
            DocumentCanvas1.Mode = DocumentCanvas.CanvasMode.AddElement
        End If
    End Sub

    Private Sub DocumentCanvas1_SelectedElementChanged(sender As Object, e As EventArgs) Handles DocumentCanvas1.SelectedElementChanged
        PropertyGrid1.SelectedObject = DocumentCanvas1.SelectedElement
        settingList = True
        ListBox1.SelectedItem = DocumentCanvas1.SelectedElement
        settingList = False
    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        DocumentCanvas1.Refresh()
    End Sub

    Private Sub OpenLayoutButton_Click(sender As Object, e As EventArgs) Handles OpenLayoutButton.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            BindingSource1.SuspendBinding()
            settingList = True
            Try
                Dim d = New DocumentLayout
                Dim doc As XDocument = XDocument.Load(OpenFileDialog1.FileName)
                d.ReadXml(doc)
                SetLayout(d)
                HeightNumericUpDown.Value = d.PageSize.Height
                WidthNumericUpDown.Value = d.PageSize.Width
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Opening File", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                settingList = False
                BindingSource1.ResumeBinding()
            End Try
        End If
    End Sub

    Private Sub SaveLayoutButton_Click(sender As Object, e As EventArgs) Handles SaveLayoutButton.Click
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            documentLayout.WriteXml.Save(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub DocumentCanvas1_ElementAdded(sender As Object, e As EventArgs) Handles DocumentCanvas1.ElementAdded
        BindingSource1.Add(DocumentCanvas1.SelectedElement)
        If String.IsNullOrEmpty(ListBox1.DisplayMember) Then ListBox1.DisplayMember = "Name"
    End Sub

    Private settingList As Boolean
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If settingList Then Exit Sub
        If ListBox1.SelectedIndex > -1 Then
            DocumentCanvas1.SetSelected(CType(ListBox1.SelectedItem, DocumentLayoutElement))
        End If
    End Sub

    Private Sub WidthNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles WidthNumericUpDown.ValueChanged
        DocumentCanvas1.SetPageWidth(WidthNumericUpDown.Value)
    End Sub

    Private Sub HeightNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles HeightNumericUpDown.ValueChanged
        DocumentCanvas1.SetPageHeight(HeightNumericUpDown.Value)
    End Sub

    Private Sub DocumentLayoutDesigner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.InitialDirectory = IO.Path.Combine(My.Application.Info.DirectoryPath, "Documents")
        SaveFileDialog1.InitialDirectory = IO.Path.Combine(My.Application.Info.DirectoryPath, "Documents")
        Dim pinfo = GetType(Control).GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        pinfo.SetValue(ScrollLabel, True)
    End Sub

    Private Sub RemoveElementButton_Click(sender As Object, e As EventArgs) Handles RemoveElementButton.Click
        If BindingSource1.Current IsNot Nothing Then
            Dim element = CType(BindingSource1.Current, DocumentLayoutElement)
            documentLayout.RemoveElement(element.Name)
            BindingSource1.RemoveCurrent()
        End If
    End Sub

    Private Sub GridNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles GridNumericUpDown.ValueChanged
        DocumentCanvas1.GridSize = GridNumericUpDown.Value
    End Sub

    Private Sub SnapCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles SnapCheckBox.CheckedChanged
        DocumentCanvas1.SnapToGrid = SnapCheckBox.Checked
        If SnapCheckBox.Checked Then
            If GridNumericUpDown.Value < 2 Then GridNumericUpDown.Value = 8
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DocumentCanvas1.ResetScroll()
    End Sub

    Private Sub DocumentCanvas1_ScrollChanged(sender As Object, e As EventArgs) Handles DocumentCanvas1.ScrollChanged
        UpdateScrollLabel()
    End Sub

    Private Sub DocumentCanvas1_MouseMove(sender As Object, e As MouseEventArgs) Handles DocumentCanvas1.MouseMove
        UpdateScrollLabel()
    End Sub

    Private Sub UpdateScrollLabel()
        Dim p = DocumentCanvas1.PointToClient(MousePosition)
        ScrollLabel.Text = $"Pos:[{p.X}x{p.Y}] Off:[{DocumentCanvas1.ScrollDelta.Width}x{DocumentCanvas1.ScrollDelta.Height}] Zoom:[{DocumentCanvas1.Zoom:p}]"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DocumentCanvas1.Zoom = 1
    End Sub
End Class
