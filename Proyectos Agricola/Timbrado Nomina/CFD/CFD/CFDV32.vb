
Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Xml.Serialization
Imports System.Collections
Imports System.Xml.Schema
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Xml

Namespace V32

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3"), System.Xml.Serialization.XmlRootAttribute(Namespace:="http://www.sat.gob.mx/cfd/3", IsNullable:=False)> _
    Partial Public Class Comprobante
        <System.Xml.Serialization.XmlAttribute("schemaLocation", Namespace:="http://www.w3.org/2001/XMLSchema-instance")> _
        Public xsiSchemaLocation As String = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd http://www.sat.gob.mx/nomina http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina11.xsd"

        Private emisorField As ComprobanteEmisor

        Private receptorField As ComprobanteReceptor

        Private conceptosField() As ComprobanteConcepto

        Private impuestosField As ComprobanteImpuestos

        Private complementoField As ComprobanteComplemento

        Private addendaField As ComprobanteAddenda

        Private versionField As String

        Private serieField As String

        Private folioField As String

        Private fechaField As System.DateTime

        Private selloField As String

        Private formaDePagoField As String

        Private noCertificadoField As String

        Private certificadoField As String

        Private condicionesDePagoField As String

        Private subTotalField As Decimal

        Private descuentoField As Decimal

        Private descuentoFieldSpecified As Boolean

        Private motivoDescuentoField As String

        Private tipoCambioField As String

        Private monedaField As String

        Private totalField As Decimal

        Private tipoDeComprobanteField As ComprobanteTipoDeComprobante

        Private metodoDePagoField As String

        Private lugarExpedicionField As String

        Private numCtaPagoField As String

        Private folioFiscalOrigField As String

        Private serieFolioFiscalOrigField As String

        Private fechaFolioFiscalOrigField As System.DateTime

        Private fechaFolioFiscalOrigFieldSpecified As Boolean

        Private montoFolioFiscalOrigField As Decimal

        Private montoFolioFiscalOrigFieldSpecified As Boolean

        Private Shared serializer_Renamed As System.Xml.Serialization.XmlSerializer

        Public Sub New()
            Me.versionField = "3.2"
        End Sub

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)> _
        Public Property Emisor() As ComprobanteEmisor
            Get
                Return Me.emisorField
            End Get
            Set(ByVal value As ComprobanteEmisor)
                Me.emisorField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=1)> _
        Public Property Receptor() As ComprobanteReceptor
            Get
                Return Me.receptorField
            End Get
            Set(ByVal value As ComprobanteReceptor)
                Me.receptorField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=2), System.Xml.Serialization.XmlArrayItemAttribute("Concepto", IsNullable:=False)> _
        Public Property Conceptos() As ComprobanteConcepto()
            Get
                Return Me.conceptosField
            End Get
            Set(ByVal value As ComprobanteConcepto())
                Me.conceptosField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=3)> _
        Public Property Impuestos() As ComprobanteImpuestos
            Get
                Return Me.impuestosField
            End Get
            Set(ByVal value As ComprobanteImpuestos)
                Me.impuestosField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=4)> _
        Public Property Complemento() As ComprobanteComplemento
            Get
                Return Me.complementoField
            End Get
            Set(ByVal value As ComprobanteComplemento)
                Me.complementoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=5)> _
        Public Property Addenda() As ComprobanteAddenda
            Get
                Return Me.addendaField
            End Get
            Set(ByVal value As ComprobanteAddenda)
                Me.addendaField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property version() As String
            Get
                Return Me.versionField
            End Get
            Set(ByVal value As String)
                Me.versionField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property serie() As String
            Get
                Return Me.serieField
            End Get
            Set(ByVal value As String)
                Me.serieField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property folio() As String
            Get
                Return Me.folioField
            End Get
            Set(ByVal value As String)
                Me.folioField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property fecha() As System.DateTime
            Get
                Return Me.fechaField
            End Get
            Set(ByVal value As System.DateTime)
                Me.fechaField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property sello() As String
            Get
                Return Me.selloField
            End Get
            Set(ByVal value As String)
                Me.selloField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property formaDePago() As String
            Get
                Return Me.formaDePagoField
            End Get
            Set(ByVal value As String)
                Me.formaDePagoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property noCertificado() As String
            Get
                Return Me.noCertificadoField
            End Get
            Set(ByVal value As String)
                Me.noCertificadoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property certificado() As String
            Get
                Return Me.certificadoField
            End Get
            Set(ByVal value As String)
                Me.certificadoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property condicionesDePago() As String
            Get
                Return Me.condicionesDePagoField
            End Get
            Set(ByVal value As String)
                Me.condicionesDePagoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property subTotal() As Decimal
            Get
                Return Me.subTotalField
            End Get
            Set(ByVal value As Decimal)
                Me.subTotalField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property descuento() As Decimal
            Get
                Return Me.descuentoField
            End Get
            Set(ByVal value As Decimal)
                Me.descuentoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property descuentoSpecified() As Boolean
            Get
                Return Me.descuentoFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.descuentoFieldSpecified = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property motivoDescuento() As String
            Get
                Return Me.motivoDescuentoField
            End Get
            Set(ByVal value As String)
                Me.motivoDescuentoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TipoCambio() As String
            Get
                Return Me.tipoCambioField
            End Get
            Set(ByVal value As String)
                Me.tipoCambioField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Moneda() As String
            Get
                Return Me.monedaField
            End Get
            Set(ByVal value As String)
                Me.monedaField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property total() As Decimal
            Get
                Return Me.totalField
            End Get
            Set(ByVal value As Decimal)
                Me.totalField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property tipoDeComprobante() As ComprobanteTipoDeComprobante
            Get
                Return Me.tipoDeComprobanteField
            End Get
            Set(ByVal value As ComprobanteTipoDeComprobante)
                Me.tipoDeComprobanteField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property metodoDePago() As String
            Get
                Return Me.metodoDePagoField
            End Get
            Set(ByVal value As String)
                Me.metodoDePagoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property LugarExpedicion() As String
            Get
                Return Me.lugarExpedicionField
            End Get
            Set(ByVal value As String)
                Me.lugarExpedicionField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property NumCtaPago() As String
            Get
                Return Me.numCtaPagoField
            End Get
            Set(ByVal value As String)
                Me.numCtaPagoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property FolioFiscalOrig() As String
            Get
                Return Me.folioFiscalOrigField
            End Get
            Set(ByVal value As String)
                Me.folioFiscalOrigField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property SerieFolioFiscalOrig() As String
            Get
                Return Me.serieFolioFiscalOrigField
            End Get
            Set(ByVal value As String)
                Me.serieFolioFiscalOrigField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property FechaFolioFiscalOrig() As System.DateTime
            Get
                Return Me.fechaFolioFiscalOrigField
            End Get
            Set(ByVal value As System.DateTime)
                Me.fechaFolioFiscalOrigField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property FechaFolioFiscalOrigSpecified() As Boolean
            Get
                Return Me.fechaFolioFiscalOrigFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.fechaFolioFiscalOrigFieldSpecified = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property MontoFolioFiscalOrig() As Decimal
            Get
                Return Me.montoFolioFiscalOrigField
            End Get
            Set(ByVal value As Decimal)
                Me.montoFolioFiscalOrigField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property MontoFolioFiscalOrigSpecified() As Boolean
            Get
                Return Me.montoFolioFiscalOrigFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.montoFolioFiscalOrigFieldSpecified = value
            End Set
        End Property

        Private Shared ReadOnly Property Serializer() As System.Xml.Serialization.XmlSerializer
            Get
                If (serializer_Renamed Is Nothing) Then
                    serializer_Renamed = New System.Xml.Serialization.XmlSerializer(GetType(Comprobante))
                End If
                Return serializer_Renamed
            End Get
        End Property

        Public Overridable Function Serialize(ByVal encoding As System.Text.Encoding) As String
            Dim streamReader As System.IO.StreamReader = Nothing
            Dim memoryStream As System.IO.MemoryStream = Nothing
            Try
                'Name spaces
                Dim xmlNameSpace As New XmlSerializerNamespaces()

                xmlNameSpace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance")
                xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/3")
                'xmlNameSpace.Add("nomina", "http://www.sat.gob.mx/nomina")


                memoryStream = New System.IO.MemoryStream()
                Dim xmlWriterSettings As New System.Xml.XmlWriterSettings()
                xmlWriterSettings.Encoding = encoding
                Dim xmlWriter As System.Xml.XmlWriter = xmlWriter.Create(memoryStream, xmlWriterSettings)

                'Agregar el xmlNameSpace
                Serializer.Serialize(xmlWriter, Me, xmlNameSpace)

                memoryStream.Seek(0, System.IO.SeekOrigin.Begin)
                streamReader = New System.IO.StreamReader(memoryStream)
                Return streamReader.ReadToEnd()
            Finally
                If (streamReader IsNot Nothing) Then
                    streamReader.Dispose()
                End If
                If (memoryStream IsNot Nothing) Then
                    memoryStream.Dispose()
                End If
            End Try
        End Function

        Public Overridable Sub SaveToFile(ByVal fileName As String, ByVal encoding As System.Text.Encoding)
            Dim streamWriter As System.IO.StreamWriter = Nothing
            Try
                Dim xmlString As String = Serialize(encoding)
                streamWriter = New System.IO.StreamWriter(fileName, False, encoding.UTF8)
                streamWriter.WriteLine(xmlString)
                streamWriter.Close()
            Finally
                If (streamWriter IsNot Nothing) Then
                    streamWriter.Dispose()
                End If
            End Try
        End Sub
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteEmisor

        Private domicilioFiscalField As t_UbicacionFiscal

        Private expedidoEnField As t_Ubicacion

        Private regimenFiscalField() As ComprobanteEmisorRegimenFiscal

        Private rfcField As String

        Private nombreField As String

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)> _
        Public Property DomicilioFiscal() As t_UbicacionFiscal
            Get
                Return Me.domicilioFiscalField
            End Get
            Set(ByVal value As t_UbicacionFiscal)
                Me.domicilioFiscalField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=1)> _
        Public Property ExpedidoEn() As t_Ubicacion
            Get
                Return Me.expedidoEnField
            End Get
            Set(ByVal value As t_Ubicacion)
                Me.expedidoEnField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute("RegimenFiscal", Order:=2)> _
        Public Property RegimenFiscal() As ComprobanteEmisorRegimenFiscal()
            Get
                Return Me.regimenFiscalField
            End Get
            Set(ByVal value As ComprobanteEmisorRegimenFiscal())
                Me.regimenFiscalField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property rfc() As String
            Get
                Return Me.rfcField
            End Get
            Set(ByVal value As String)
                Me.rfcField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property nombre() As String
            Get
                Return Me.nombreField
            End Get
            Set(ByVal value As String)
                Me.nombreField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(Namespace:="http://www.sat.gob.mx/cfd/3"), System.Xml.Serialization.XmlRootAttribute(Namespace:="http://www.sat.gob.mx/cfd/3", IsNullable:=True)> _
    Partial Public Class t_UbicacionFiscal

        Private calleField As String

        Private noExteriorField As String

        Private noInteriorField As String

        Private coloniaField As String

        Private localidadField As String

        Private referenciaField As String

        Private municipioField As String

        Private estadoField As String

        Private paisField As String

        Private codigoPostalField As String

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property calle() As String
            Get
                Return Me.calleField
            End Get
            Set(ByVal value As String)
                Me.calleField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property noExterior() As String
            Get
                Return Me.noExteriorField
            End Get
            Set(ByVal value As String)
                Me.noExteriorField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property noInterior() As String
            Get
                Return Me.noInteriorField
            End Get
            Set(ByVal value As String)
                Me.noInteriorField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property colonia() As String
            Get
                Return Me.coloniaField
            End Get
            Set(ByVal value As String)
                Me.coloniaField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property localidad() As String
            Get
                Return Me.localidadField
            End Get
            Set(ByVal value As String)
                Me.localidadField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property referencia() As String
            Get
                Return Me.referenciaField
            End Get
            Set(ByVal value As String)
                Me.referenciaField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property municipio() As String
            Get
                Return Me.municipioField
            End Get
            Set(ByVal value As String)
                Me.municipioField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property estado() As String
            Get
                Return Me.estadoField
            End Get
            Set(ByVal value As String)
                Me.estadoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property pais() As String
            Get
                Return Me.paisField
            End Get
            Set(ByVal value As String)
                Me.paisField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property codigoPostal() As String
            Get
                Return Me.codigoPostalField
            End Get
            Set(ByVal value As String)
                Me.codigoPostalField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(Namespace:="http://www.sat.gob.mx/cfd/3"), System.Xml.Serialization.XmlRootAttribute(Namespace:="http://www.sat.gob.mx/cfd/3", IsNullable:=True)> _
    Partial Public Class t_InformacionAduanera

        Private numeroField As String

        Private fechaField As System.DateTime

        Private aduanaField As String

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property numero() As String
            Get
                Return Me.numeroField
            End Get
            Set(ByVal value As String)
                Me.numeroField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="date")> _
        Public Property fecha() As System.DateTime
            Get
                Return Me.fechaField
            End Get
            Set(ByVal value As System.DateTime)
                Me.fechaField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property aduana() As String
            Get
                Return Me.aduanaField
            End Get
            Set(ByVal value As String)
                Me.aduanaField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(Namespace:="http://www.sat.gob.mx/cfd/3"), System.Xml.Serialization.XmlRootAttribute(Namespace:="http://www.sat.gob.mx/cfd/3", IsNullable:=True)> _
    Partial Public Class t_Ubicacion

        Private calleField As String

        Private noExteriorField As String

        Private noInteriorField As String

        Private coloniaField As String

        Private localidadField As String

        Private referenciaField As String

        Private municipioField As String

        Private estadoField As String

        Private paisField As String

        Private codigoPostalField As String

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property calle() As String
            Get
                Return Me.calleField
            End Get
            Set(ByVal value As String)
                Me.calleField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property noExterior() As String
            Get
                Return Me.noExteriorField
            End Get
            Set(ByVal value As String)
                Me.noExteriorField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property noInterior() As String
            Get
                Return Me.noInteriorField
            End Get
            Set(ByVal value As String)
                Me.noInteriorField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property colonia() As String
            Get
                Return Me.coloniaField
            End Get
            Set(ByVal value As String)
                Me.coloniaField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property localidad() As String
            Get
                Return Me.localidadField
            End Get
            Set(ByVal value As String)
                Me.localidadField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property referencia() As String
            Get
                Return Me.referenciaField
            End Get
            Set(ByVal value As String)
                Me.referenciaField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property municipio() As String
            Get
                Return Me.municipioField
            End Get
            Set(ByVal value As String)
                Me.municipioField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property estado() As String
            Get
                Return Me.estadoField
            End Get
            Set(ByVal value As String)
                Me.estadoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property pais() As String
            Get
                Return Me.paisField
            End Get
            Set(ByVal value As String)
                Me.paisField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property codigoPostal() As String
            Get
                Return Me.codigoPostalField
            End Get
            Set(ByVal value As String)
                Me.codigoPostalField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteEmisorRegimenFiscal

        Private regimenField As String

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Regimen() As String
            Get
                Return Me.regimenField
            End Get
            Set(ByVal value As String)
                Me.regimenField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteReceptor

        Private domicilioField As t_Ubicacion

        Private rfcField As String

        Private nombreField As String

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)> _
        Public Property Domicilio() As t_Ubicacion
            Get
                Return Me.domicilioField
            End Get
            Set(ByVal value As t_Ubicacion)
                Me.domicilioField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property rfc() As String
            Get
                Return Me.rfcField
            End Get
            Set(ByVal value As String)
                Me.rfcField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property nombre() As String
            Get
                Return Me.nombreField
            End Get
            Set(ByVal value As String)
                Me.nombreField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteConcepto

        Private itemsField() As Object

        Private cantidadField As Decimal

        Private unidadField As String

        Private noIdentificacionField As String

        Private descripcionField As String

        Private valorUnitarioField As Decimal

        Private importeField As Decimal

        <System.Xml.Serialization.XmlElementAttribute("ComplementoConcepto", GetType(ComprobanteConceptoComplementoConcepto), Order:=0), System.Xml.Serialization.XmlElementAttribute("CuentaPredial", GetType(ComprobanteConceptoCuentaPredial), Order:=0), System.Xml.Serialization.XmlElementAttribute("InformacionAduanera", GetType(t_InformacionAduanera), Order:=0), System.Xml.Serialization.XmlElementAttribute("Parte", GetType(ComprobanteConceptoParte), Order:=0)> _
        Public Property Items() As Object()
            Get
                Return Me.itemsField
            End Get
            Set(ByVal value As Object())
                Me.itemsField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property cantidad() As Decimal
            Get
                Return Me.cantidadField
            End Get
            Set(ByVal value As Decimal)
                Me.cantidadField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property unidad() As String
            Get
                Return Me.unidadField
            End Get
            Set(ByVal value As String)
                Me.unidadField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property noIdentificacion() As String
            Get
                Return Me.noIdentificacionField
            End Get
            Set(ByVal value As String)
                Me.noIdentificacionField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property descripcion() As String
            Get
                Return Me.descripcionField
            End Get
            Set(ByVal value As String)
                Me.descripcionField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property valorUnitario() As Decimal
            Get
                Return Me.valorUnitarioField
            End Get
            Set(ByVal value As Decimal)
                Me.valorUnitarioField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property importe() As Decimal
            Get
                Return Me.importeField
            End Get
            Set(ByVal value As Decimal)
                Me.importeField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteConceptoComplementoConcepto

        Private anyField() As System.Xml.XmlElement

        <System.Xml.Serialization.XmlAnyElementAttribute(Order:=0)> _
        Public Property Any() As System.Xml.XmlElement()
            Get
                Return Me.anyField
            End Get
            Set(ByVal value As System.Xml.XmlElement())
                Me.anyField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteConceptoCuentaPredial

        Private numeroField As String

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property numero() As String
            Get
                Return Me.numeroField
            End Get
            Set(ByVal value As String)
                Me.numeroField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteConceptoParte

        Private informacionAduaneraField() As t_InformacionAduanera

        Private cantidadField As Decimal

        Private unidadField As String

        Private noIdentificacionField As String

        Private descripcionField As String

        Private valorUnitarioField As Decimal

        Private valorUnitarioFieldSpecified As Boolean

        Private importeField As Decimal

        Private importeFieldSpecified As Boolean

        <System.Xml.Serialization.XmlElementAttribute("InformacionAduanera", Order:=0)> _
        Public Property InformacionAduanera() As t_InformacionAduanera()
            Get
                Return Me.informacionAduaneraField
            End Get
            Set(ByVal value As t_InformacionAduanera())
                Me.informacionAduaneraField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property cantidad() As Decimal
            Get
                Return Me.cantidadField
            End Get
            Set(ByVal value As Decimal)
                Me.cantidadField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property unidad() As String
            Get
                Return Me.unidadField
            End Get
            Set(ByVal value As String)
                Me.unidadField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property noIdentificacion() As String
            Get
                Return Me.noIdentificacionField
            End Get
            Set(ByVal value As String)
                Me.noIdentificacionField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property descripcion() As String
            Get
                Return Me.descripcionField
            End Get
            Set(ByVal value As String)
                Me.descripcionField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property valorUnitario() As Decimal
            Get
                Return Me.valorUnitarioField
            End Get
            Set(ByVal value As Decimal)
                Me.valorUnitarioField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property valorUnitarioSpecified() As Boolean
            Get
                Return Me.valorUnitarioFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.valorUnitarioFieldSpecified = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property importe() As Decimal
            Get
                Return Me.importeField
            End Get
            Set(ByVal value As Decimal)
                Me.importeField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property importeSpecified() As Boolean
            Get
                Return Me.importeFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.importeFieldSpecified = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteImpuestos

        Private retencionesField() As ComprobanteImpuestosRetencion

        Private trasladosField() As ComprobanteImpuestosTraslado

        Private totalImpuestosRetenidosField As Decimal

        Private totalImpuestosRetenidosFieldSpecified As Boolean

        Private totalImpuestosTrasladadosField As Decimal

        Private totalImpuestosTrasladadosFieldSpecified As Boolean

        <System.Xml.Serialization.XmlArrayAttribute(Order:=0), System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable:=False)> _
        Public Property Retenciones() As ComprobanteImpuestosRetencion()
            Get
                Return Me.retencionesField
            End Get
            Set(ByVal value As ComprobanteImpuestosRetencion())
                Me.retencionesField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=1), System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable:=False)> _
        Public Property Traslados() As ComprobanteImpuestosTraslado()
            Get
                Return Me.trasladosField
            End Get
            Set(ByVal value As ComprobanteImpuestosTraslado())
                Me.trasladosField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property totalImpuestosRetenidos() As Decimal
            Get
                Return Me.totalImpuestosRetenidosField
            End Get
            Set(ByVal value As Decimal)
                Me.totalImpuestosRetenidosField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property totalImpuestosRetenidosSpecified() As Boolean
            Get
                Return Me.totalImpuestosRetenidosFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.totalImpuestosRetenidosFieldSpecified = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property totalImpuestosTrasladados() As Decimal
            Get
                Return Me.totalImpuestosTrasladadosField
            End Get
            Set(ByVal value As Decimal)
                Me.totalImpuestosTrasladadosField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property totalImpuestosTrasladadosSpecified() As Boolean
            Get
                Return Me.totalImpuestosTrasladadosFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.totalImpuestosTrasladadosFieldSpecified = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteImpuestosRetencion

        Private impuestoField As ComprobanteImpuestosRetencionImpuesto

        Private importeField As Decimal

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property impuesto() As ComprobanteImpuestosRetencionImpuesto
            Get
                Return Me.impuestoField
            End Get
            Set(ByVal value As ComprobanteImpuestosRetencionImpuesto)
                Me.impuestoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property importe() As Decimal
            Get
                Return Me.importeField
            End Get
            Set(ByVal value As Decimal)
                Me.importeField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Public Enum ComprobanteImpuestosRetencionImpuesto
        ISR
        IVA
    End Enum

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteImpuestosTraslado

        Private impuestoField As ComprobanteImpuestosTrasladoImpuesto

        Private tasaField As Decimal

        Private importeField As Decimal

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property impuesto() As ComprobanteImpuestosTrasladoImpuesto
            Get
                Return Me.impuestoField
            End Get
            Set(ByVal value As ComprobanteImpuestosTrasladoImpuesto)
                Me.impuestoField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property tasa() As Decimal
            Get
                Return Me.tasaField
            End Get
            Set(ByVal value As Decimal)
                Me.tasaField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property importe() As Decimal
            Get
                Return Me.importeField
            End Get
            Set(ByVal value As Decimal)
                Me.importeField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Public Enum ComprobanteImpuestosTrasladoImpuesto
        IVA
        IEPS
    End Enum

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteComplemento

        Private anyField() As System.Xml.XmlElement
        Private version As String

        <System.Xml.Serialization.XmlAnyElementAttribute(Order:=0)> _
        Public Property Any() As System.Xml.XmlElement()
            Get
                Return Me.anyField
            End Get
            Set(ByVal value As System.Xml.XmlElement())
                Me.anyField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Partial Public Class ComprobanteAddenda

        Private anyField() As System.Xml.XmlElement

        <System.Xml.Serialization.XmlAnyElementAttribute(Order:=0)> _
        Public Property Any() As System.Xml.XmlElement()
            Get
                Return Me.anyField
            End Get
            Set(ByVal value As System.Xml.XmlElement())
                Me.anyField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233"), System.SerializableAttribute(), System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, Namespace:="http://www.sat.gob.mx/cfd/3")> _
    Public Enum ComprobanteTipoDeComprobante
        ingreso
        egreso
        traslado
    End Enum
End Namespace
