Public Class DocumentLayoutElementCollection
    Inherits ObjectModel.KeyedCollection(Of String, DocumentLayoutElement)

    Protected Overrides Function GetKeyForItem(item As DocumentLayoutElement) As String
        Return item.Name
    End Function
End Class
