Public Class DocumentLayout
    Implements IEnumerable(Of DocumentLayoutElement)

    Private elements As New DocumentLayoutElementCollection

    Friend ReadOnly Property ElementCollection As DocumentLayoutElementCollection
        Get
            Return elements
        End Get
    End Property

    Public Sub AddElement(element As DocumentLayoutElement)
        If elements.Contains(element.Name) Then
            elements.Remove(element.Name)
        End If
        elements.Add(element)
    End Sub

    Public Function ContainsElement(name As String) As Boolean
        Return elements.Contains(name)
    End Function

    Public ReadOnly Property ElementCount As Integer
        Get
            Return elements.Count
        End Get
    End Property

    Public Function GetEnumerator() As IEnumerator(Of DocumentLayoutElement) Implements IEnumerable(Of DocumentLayoutElement).GetEnumerator
        Return elements.GetEnumerator
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function

    Default Public ReadOnly Property Item(index As Integer) As DocumentLayoutElement
        Get
            If index > -1 AndAlso index < elements.Count Then
                Return elements(index)
            End If
            Return Nothing
        End Get
    End Property

    Default Public ReadOnly Property Item(name As String) As DocumentLayoutElement
        Get
            If elements.Contains(name) Then Return elements(name)
            Return Nothing
        End Get
    End Property

    Public Property PageSize As New SizeF(7.5, 10)

    Public Sub ReadXml(docPath As String)
        ReadXml(XDocument.Load(docPath))
    End Sub

    Public Sub ReadXml(doc As XDocument)
        If Not doc.Root.Name = "InvoiceDocument" Then Exit Sub
        PageSize = New SizeF(CSng(doc.Root.@pageWidth), CSng(doc.Root.@pageHeight))
        For Each e In doc.Root.<LayoutElement>
            Me.AddElement(DocumentLayoutElement.FromXElement(e))
        Next
    End Sub

    Public Function RemoveElement(name As String) As Boolean
        If elements.Contains(name) Then
            elements.Remove(name)
            Return True
        End If
        Return False
    End Function

    Public Function WriteXml() As XDocument
        Dim result = <?xml version="1.0" encoding="utf-8"?>
                     <InvoiceDocument pageWidth=<%= PageSize.Width %> pageHeight=<%= PageSize.Height %>/>
        For Each element In elements
            result.Root.Add(element.AsXElement)
        Next
        Return result
    End Function
End Class