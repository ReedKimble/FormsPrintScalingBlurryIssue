<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentLayoutDesigner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ScrollLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SnapCheckBox = New System.Windows.Forms.CheckBox()
        Me.WidthNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.GridNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.HeightNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RemoveElementButton = New System.Windows.Forms.ToolStripButton()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SelectButton = New System.Windows.Forms.RadioButton()
        Me.AddElementButton = New System.Windows.Forms.RadioButton()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SaveLayoutButton = New System.Windows.Forms.ToolStripButton()
        Me.OpenLayoutButton = New System.Windows.Forms.ToolStripButton()
        Me.NewLayoutButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DocumentCanvas1 = New FormsPrintScalingBlurryIssue.DocumentCanvas()
        CType(Me.WidthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeightNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Document Layouts|*.xmldl"
        Me.SaveFileDialog1.Title = "Save Layout"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Document Layouts|*.xmldl"
        Me.OpenFileDialog1.Title = "Open Layout"
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.CategoryForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.PropertyGrid1.CategorySplitterColor = System.Drawing.SystemColors.ActiveCaption
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.HelpBackColor = System.Drawing.SystemColors.Info
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 27)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(331, 1010)
        Me.PropertyGrid1.TabIndex = 0
        Me.PropertyGrid1.ToolbarVisible = False
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(331, 27)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Selected Element Properties"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ScrollLabel
        '
        Me.ScrollLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScrollLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrollLabel.Location = New System.Drawing.Point(550, 0)
        Me.ScrollLabel.Name = "ScrollLabel"
        Me.ScrollLabel.Size = New System.Drawing.Size(395, 45)
        Me.ScrollLabel.TabIndex = 7
        Me.ScrollLabel.Text = "Scroll Offset: [0x0]"
        Me.ScrollLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "W:"
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Location = New System.Drawing.Point(989, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.Button2, "Reset Zoom Level")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'SnapCheckBox
        '
        Me.SnapCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SnapCheckBox.AutoSize = True
        Me.SnapCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SnapCheckBox.Location = New System.Drawing.Point(415, 10)
        Me.SnapCheckBox.Name = "SnapCheckBox"
        Me.SnapCheckBox.Size = New System.Drawing.Size(129, 24)
        Me.SnapCheckBox.TabIndex = 6
        Me.SnapCheckBox.Text = "Snap to Grid:"
        Me.SnapCheckBox.UseVisualStyleBackColor = True
        '
        'WidthNumericUpDown
        '
        Me.WidthNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WidthNumericUpDown.DecimalPlaces = 2
        Me.WidthNumericUpDown.Location = New System.Drawing.Point(37, 9)
        Me.WidthNumericUpDown.Name = "WidthNumericUpDown"
        Me.WidthNumericUpDown.Size = New System.Drawing.Size(90, 26)
        Me.WidthNumericUpDown.TabIndex = 1
        Me.WidthNumericUpDown.Value = New Decimal(New Integer() {75, 0, 0, 65536})
        '
        'GridNumericUpDown
        '
        Me.GridNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GridNumericUpDown.Location = New System.Drawing.Point(321, 9)
        Me.GridNumericUpDown.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.GridNumericUpDown.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.GridNumericUpDown.Name = "GridNumericUpDown"
        Me.GridNumericUpDown.Size = New System.Drawing.Size(79, 26)
        Me.GridNumericUpDown.TabIndex = 5
        Me.GridNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "H:"
        '
        'HeightNumericUpDown
        '
        Me.HeightNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.HeightNumericUpDown.DecimalPlaces = 2
        Me.HeightNumericUpDown.Location = New System.Drawing.Point(164, 9)
        Me.HeightNumericUpDown.Name = "HeightNumericUpDown"
        Me.HeightNumericUpDown.Size = New System.Drawing.Size(90, 26)
        Me.HeightNumericUpDown.TabIndex = 3
        Me.HeightNumericUpDown.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(269, 12)
        Me.Label5.Margin = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Grid:"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.Location = New System.Drawing.Point(951, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.Button1, "Reset Page to Origin")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(207, 25)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Elements"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RemoveElementButton
        '
        Me.RemoveElementButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RemoveElementButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RemoveElementButton.Name = "RemoveElementButton"
        Me.RemoveElementButton.Size = New System.Drawing.Size(23, 22)
        Me.RemoveElementButton.Text = "Remove Element"
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(0, 50)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(207, 855)
        Me.ListBox1.TabIndex = 1
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveElementButton})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(207, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(207, 27)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Toolbox"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SelectButton
        '
        Me.SelectButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.SelectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SelectButton.Location = New System.Drawing.Point(4, 4)
        Me.SelectButton.Margin = New System.Windows.Forms.Padding(4)
        Me.SelectButton.Name = "SelectButton"
        Me.SelectButton.Size = New System.Drawing.Size(199, 34)
        Me.SelectButton.TabIndex = 0
        Me.SelectButton.TabStop = True
        Me.SelectButton.Text = "Select"
        Me.SelectButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.SelectButton.UseVisualStyleBackColor = True
        '
        'AddElementButton
        '
        Me.AddElementButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddElementButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.AddElementButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AddElementButton.Location = New System.Drawing.Point(4, 46)
        Me.AddElementButton.Margin = New System.Windows.Forms.Padding(4)
        Me.AddElementButton.Name = "AddElementButton"
        Me.AddElementButton.Size = New System.Drawing.Size(199, 34)
        Me.AddElementButton.TabIndex = 1
        Me.AddElementButton.TabStop = True
        Me.AddElementButton.Text = "Add Element"
        Me.AddElementButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AddElementButton.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.SelectButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.AddElementButton)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 27)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(207, 101)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label3)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.ListBox1)
        Me.SplitContainer3.Panel2.Controls.Add(Me.ToolStrip2)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer3.Size = New System.Drawing.Size(207, 1037)
        Me.SplitContainer3.SplitterDistance = 128
        Me.SplitContainer3.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 32)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Panel1MinSize = 180
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1574, 1037)
        Me.SplitContainer1.SplitterDistance = 207
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 3
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.DocumentCanvas1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer2.Panel1.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2.Panel2.Controls.Add(Me.PropertyGrid1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel2MinSize = 330
        Me.SplitContainer2.Size = New System.Drawing.Size(1362, 1037)
        Me.SplitContainer2.SplitterDistance = 1027
        Me.SplitContainer2.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.ScrollLabel, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.SnapCheckBox, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.WidthNumericUpDown, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GridNumericUpDown, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.HeightNumericUpDown, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 8, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 992)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1024, 45)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'SaveLayoutButton
        '
        Me.SaveLayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveLayoutButton.Name = "SaveLayoutButton"
        Me.SaveLayoutButton.Size = New System.Drawing.Size(111, 29)
        Me.SaveLayoutButton.Text = "Save Layout"
        '
        'OpenLayoutButton
        '
        Me.OpenLayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenLayoutButton.Name = "OpenLayoutButton"
        Me.OpenLayoutButton.Size = New System.Drawing.Size(118, 29)
        Me.OpenLayoutButton.Text = "Open Layout"
        '
        'NewLayoutButton
        '
        Me.NewLayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewLayoutButton.Name = "NewLayoutButton"
        Me.NewLayoutButton.Size = New System.Drawing.Size(109, 29)
        Me.NewLayoutButton.Text = "New Layout"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewLayoutButton, Me.OpenLayoutButton, Me.SaveLayoutButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1574, 32)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'DocumentCanvas1
        '
        Me.DocumentCanvas1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentCanvas1.DocumentLayout = Nothing
        Me.DocumentCanvas1.GridSize = 0
        Me.DocumentCanvas1.Location = New System.Drawing.Point(3, 3)
        Me.DocumentCanvas1.Mode = FormsPrintScalingBlurryIssue.DocumentCanvas.CanvasMode.[Select]
        Me.DocumentCanvas1.Name = "DocumentCanvas1"
        Me.DocumentCanvas1.Size = New System.Drawing.Size(1024, 989)
        Me.DocumentCanvas1.SnapToGrid = False
        Me.DocumentCanvas1.TabIndex = 3
        Me.DocumentCanvas1.Zoom = 1.0!
        '
        'DocumentLayoutDesigner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1574, 1069)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "DocumentLayoutDesigner"
        Me.Text = "DocumentLayoutDesigner"
        CType(Me.WidthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeightNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents Label6 As Label
    Friend WithEvents ScrollLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents SnapCheckBox As CheckBox
    Friend WithEvents WidthNumericUpDown As NumericUpDown
    Friend WithEvents GridNumericUpDown As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents HeightNumericUpDown As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents RemoveElementButton As ToolStripButton
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents Label3 As Label
    Friend WithEvents SelectButton As RadioButton
    Friend WithEvents AddElementButton As RadioButton
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents SaveLayoutButton As ToolStripButton
    Friend WithEvents OpenLayoutButton As ToolStripButton
    Friend WithEvents NewLayoutButton As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents DocumentCanvas1 As DocumentCanvas
End Class
