Imports System.Xml.Serialization
Imports System.Text

Public Class ClsCreaXML

    Public Shared Function CreaXML(ByVal Nomina As V32.Nomina, _
                                   Optional ByVal xmlFile As String = "", _
                                   Optional ByVal Guardar As Boolean = True) As Boolean

        Dim serializer As New Xml.Serialization.XmlSerializer(GetType(V32.Nomina))
        Dim ws As New IO.StreamWriter(xmlFile, False, New UTF8Encoding)


        Dim ns = New XmlSerializerNamespaces()
        ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance")
        ns.Add("nomina", "http://www.sat.gob.mx/nomina")

        serializer.Serialize(ws, Nomina, ns)
        'serializer.Serialize(ws, Nomina)

        ws.Flush()
        ws.Close()
        ws.Dispose()
        serializer = Nothing

    End Function

End Class
