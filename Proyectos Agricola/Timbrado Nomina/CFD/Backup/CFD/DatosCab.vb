Imports Microsoft.VisualBasic
Imports System
Imports System.Text

Namespace Access


    Public Class DatosCab

        Private atrID As String
        Private atrCLIENTECLAVE As String
        Private atrCLIENTENOMBRE As String
        Private atrCLIENTERFC As String
        Private atrCLIENTEDIRECCION As String
        Private atrCLIENTENUMEXT As String
        Private atrCLIENTENUMINT As String
        Private atrCLIENTECOLONIA As String
        Private atrCLIENTECIUDAD As String
        Private atrCLIENTEESTADO As String
        Private atrCLIENTEPAIS As String
        Private atrCLIENTEMAIL As String
        Private atrCLIENTECP As String
        Private atrCLIENTECUENTA As String
        Private atrEFSERIE As String
        Private atrEFFACTURA As String
        Private atrEFFECHA As Date
        Private atrEFSUBTOTALAD As Decimal
        Private atrEFDESCUENTO As Decimal
        Private atrEFIMPUESTOS As Decimal
        Private atrEFIVARETENIDO As Decimal
        Private atrEFISRRETENIDO As Decimal
        Private atrEFSUBTOTALDD As Decimal
        Private atrEFFORMADEPAGO As String
        Private atrEFCONDICIONDEPAGO As String
        Private atrEFMONEDA As String
        Private atrEFPARIDAD As Decimal
        Private atrEFDOCUMENTO As String
        Private atrEFMETODOPAGO As String
        Private atrEFCUENTA As String
        Private atrEFCERTIFICADO As String
        Private atrEFSELLO As String
        Private atrEFCADENA As String
        Private atrEFUUID As String
        Private atrEFFECHATIMBRE As Date
        Private atrEFSELLOSAT As String
        Private atrEFREGIMEN As String
        Private atrEFLUGAREXPEDICION As String
        Private atrEFIMPLETRA As String
        Private atrEFIMPORTE As Decimal
        Private atrEFTIPOCOMPROBANTE As String

        Private atrRFC As String
        Private atrRazonSocial As String
        Private atrCalle As String
        Private atrCP As String
        Private atrColonia As String
        Private atrEstado As String
        Private atrLocalidad As String
        Private atrMunicipio As String
        Private atrNumExt As String
        Private atrNumInt As String
        Private atrPais As String
        Private atrRutaCert As String
        Private atrRutaKey As String
        Private atrPassKey As String
        Private atrRutaXml As String
        Private atrDestinoXml As String
        Private atrDestinoAcuseXml As String
        Private atrRutaBidimensional As String
        Private atrUsuarioWS As String
        Private atrPasswordWS As String
        Private atrAcuseCancelacion As String
        Private atrNoAprobacion As String
        Private atrAnoAprobacion As String
        Private atrSelloCancelacion As String
        Private atrPassCancelacion As String



        Public Property ID() As String
            Get
                Return atrID
            End Get
            Set(ByVal value As String)
                atrID = value
            End Set
        End Property

        Public Property CLIENTECLAVE() As String
            Get
                Return atrCLIENTECLAVE
            End Get
            Set(ByVal value As String)
                atrCLIENTECLAVE = value
            End Set
        End Property

        Public Property CLIENTENOMBRE() As String
            Get
                Return atrCLIENTENOMBRE
            End Get
            Set(ByVal value As String)
                atrCLIENTENOMBRE = value
            End Set
        End Property

        Public Property CLIENTERFC() As String
            Get
                Return atrCLIENTERFC
            End Get
            Set(ByVal value As String)
                atrCLIENTERFC = value
            End Set
        End Property

        Public Property CLIENTEDIRECCION() As String
            Get
                Return atrCLIENTEDIRECCION
            End Get
            Set(ByVal value As String)
                atrCLIENTEDIRECCION = value
            End Set
        End Property

        Public Property CLIENTENUMEXT() As String
            Get
                Return atrCLIENTENUMEXT
            End Get
            Set(ByVal value As String)
                atrCLIENTENUMEXT = value
            End Set
        End Property

        Public Property CLIENTENUMINT() As String
            Get
                Return atrCLIENTENUMINT
            End Get
            Set(ByVal value As String)
                atrCLIENTENUMINT = value
            End Set
        End Property

        Public Property CLIENTECOLONIA() As String
            Get
                Return atrCLIENTECOLONIA
            End Get
            Set(ByVal value As String)
                atrCLIENTECOLONIA = value
            End Set
        End Property

        Public Property CLIENTECIUDAD() As String
            Get
                Return atrCLIENTECIUDAD
            End Get
            Set(ByVal value As String)
                atrCLIENTECIUDAD = value
            End Set
        End Property

        Public Property CLIENTEESTADO() As String
            Get
                Return atrCLIENTEESTADO
            End Get
            Set(ByVal value As String)
                atrCLIENTEESTADO = value
            End Set
        End Property

        Public Property CLIENTEPAIS() As String
            Get
                Return atrCLIENTEPAIS
            End Get
            Set(ByVal value As String)
                atrCLIENTEPAIS = value
            End Set
        End Property

        Public Property CLIENTEMAIL() As String
            Get
                Return atrCLIENTEMAIL
            End Get
            Set(ByVal value As String)
                atrCLIENTEMAIL = value
            End Set
        End Property

        Public Property CLIENTECP() As String
            Get
                Return atrCLIENTECP
            End Get
            Set(ByVal value As String)
                atrCLIENTECP = value
            End Set
        End Property

        Public Property CLIENTECUENTA() As String
            Get
                Return atrCLIENTECUENTA
            End Get
            Set(ByVal value As String)
                atrCLIENTECUENTA = value
            End Set
        End Property

        Public Property EFSERIE() As String
            Get
                Return atrEFSERIE
            End Get
            Set(ByVal value As String)
                atrEFSERIE = value
            End Set
        End Property

        Public Property EFFACTURA() As String
            Get
                Return atrEFFACTURA
            End Get
            Set(ByVal value As String)
                atrEFFACTURA = value
            End Set
        End Property

        Public Property EFFECHA() As Date
            Get
                Return atrEFFECHA
            End Get
            Set(ByVal value As Date)
                atrEFFECHA = value
            End Set
        End Property

        Public Property EFSUBTOTALAD() As Decimal
            Get
                Return atrEFSUBTOTALAD
            End Get
            Set(ByVal value As Decimal)
                atrEFSUBTOTALAD = value
            End Set
        End Property

        Public Property EFDESCUENTO() As Decimal
            Get
                Return atrEFDESCUENTO
            End Get
            Set(ByVal value As Decimal)
                atrEFDESCUENTO = value
            End Set
        End Property

        Public Property EFIMPUESTOS() As Decimal
            Get
                Return atrEFIMPUESTOS
            End Get
            Set(ByVal value As Decimal)
                atrEFIMPUESTOS = value
            End Set
        End Property

        Public Property EFIVARETENIDO() As Decimal
            Get
                Return atrEFIVARETENIDO
            End Get
            Set(ByVal value As Decimal)
                atrEFIVARETENIDO = value
            End Set
        End Property

        Public Property EFISRRETENIDO() As Decimal
            Get
                Return atrEFISRRETENIDO
            End Get
            Set(ByVal value As Decimal)
                atrEFISRRETENIDO = value
            End Set
        End Property

        Public Property EFSUBTOTALDD() As Decimal
            Get
                Return atrEFSUBTOTALDD
            End Get
            Set(ByVal value As Decimal)
                atrEFSUBTOTALDD = value
            End Set
        End Property

        Public Property EFFORMADEPAGO() As String
            Get
                Return atrEFFORMADEPAGO
            End Get
            Set(ByVal value As String)
                atrEFFORMADEPAGO = value
            End Set
        End Property

        Public Property EFCONDICIONDEPAGO() As String
            Get
                Return atrEFCONDICIONDEPAGO
            End Get
            Set(ByVal value As String)
                atrEFCONDICIONDEPAGO = value
            End Set
        End Property

        Public Property EFMONEDA() As String
            Get
                Return atrEFMONEDA
            End Get
            Set(ByVal value As String)
                atrEFMONEDA = value
            End Set
        End Property

        Public Property EFPARIDAD() As Decimal
            Get
                Return atrEFPARIDAD
            End Get
            Set(ByVal value As Decimal)
                atrEFPARIDAD = value
            End Set
        End Property

        Public Property EFDOCUMENTO() As String
            Get
                Return atrEFDOCUMENTO
            End Get
            Set(ByVal value As String)
                atrEFDOCUMENTO = value
            End Set
        End Property

        Public Property EFMETODOPAGO() As String
            Get
                Return atrEFMETODOPAGO
            End Get
            Set(ByVal value As String)
                atrEFMETODOPAGO = value
            End Set
        End Property

        Public Property EFCUENTA() As String
            Get
                Return atrEFCUENTA
            End Get
            Set(ByVal value As String)
                atrEFCUENTA = value
            End Set
        End Property

        Public Property EFCERTIFICADO() As String
            Get
                Return atrEFCERTIFICADO
            End Get
            Set(ByVal value As String)
                atrEFCERTIFICADO = value
            End Set
        End Property

        Public Property EFSELLO() As String
            Get
                Return atrEFSELLO
            End Get
            Set(ByVal value As String)
                atrEFSELLO = value
            End Set
        End Property

        Public Property EFCADENA() As String
            Get
                Return atrEFCADENA
            End Get
            Set(ByVal value As String)
                atrEFCADENA = value
            End Set
        End Property

        Public Property EFUUID() As String
            Get
                Return atrEFUUID
            End Get
            Set(ByVal value As String)
                atrEFUUID = value
            End Set
        End Property

        Public Property EFFECHATIMBRE() As Date
            Get
                Return atrEFFECHATIMBRE
            End Get
            Set(ByVal value As Date)
                atrEFFECHATIMBRE = value
            End Set
        End Property

        Public Property EFSELLOSAT() As String
            Get
                Return atrEFSELLOSAT
            End Get
            Set(ByVal value As String)
                atrEFSELLOSAT = value
            End Set
        End Property

        Public Property EFREGIMEN() As String
            Get
                Return atrEFREGIMEN
            End Get
            Set(ByVal value As String)
                atrEFREGIMEN = value
            End Set
        End Property

        Public Property EFLUGAREXPEDICION() As String
            Get
                Return atrEFLUGAREXPEDICION
            End Get
            Set(ByVal value As String)
                atrEFLUGAREXPEDICION = value
            End Set
        End Property

        Public Property EFIMPLETRA() As String
            Get
                Return atrEFIMPLETRA
            End Get
            Set(ByVal value As String)
                atrEFIMPLETRA = value
            End Set
        End Property

        Public Property EFIMPORTE() As Decimal
            Get
                Return atrEFIMPORTE
            End Get
            Set(ByVal value As Decimal)
                atrEFIMPORTE = value
            End Set
        End Property


        Public Property EFTIPOCOMPROBANTE() As String
            Get
                Return atrEFTIPOCOMPROBANTE
            End Get
            Set(ByVal value As String)
                atrEFTIPOCOMPROBANTE = value
            End Set
        End Property

        Public Property RFC() As String
            Get
                Return atrRFC
            End Get
            Set(ByVal value As String)
                atrRFC = value
            End Set
        End Property

        Public Property RazonSocial() As String
            Get
                Return atrRazonSocial
            End Get
            Set(ByVal value As String)
                atrRazonSocial = value
            End Set
        End Property

        Public Property Calle() As String
            Get
                Return atrCalle
            End Get
            Set(ByVal value As String)
                atrCalle = value
            End Set
        End Property

        Public Property CP() As String
            Get
                Return atrCP
            End Get
            Set(ByVal value As String)
                atrCP = value
            End Set
        End Property

        Public Property Colonia() As String
            Get
                Return atrColonia
            End Get
            Set(ByVal value As String)
                atrColonia = value
            End Set
        End Property

        Public Property Estado() As String
            Get
                Return atrEstado
            End Get
            Set(ByVal value As String)
                atrEstado = value
            End Set
        End Property

        Public Property Localidad() As String
            Get
                Return atrLocalidad
            End Get
            Set(ByVal value As String)
                atrLocalidad = value
            End Set
        End Property

        Public Property Municipio() As String
            Get
                Return atrMunicipio
            End Get
            Set(ByVal value As String)
                atrMunicipio = value
            End Set
        End Property

        Public Property NumExt() As String
            Get
                Return atrNumExt
            End Get
            Set(ByVal value As String)
                atrNumExt = value
            End Set
        End Property

        Public Property NumInt() As String
            Get
                Return atrNumInt
            End Get
            Set(ByVal value As String)
                atrNumInt = value
            End Set
        End Property

        Public Property Pais() As String
            Get
                Return atrPais
            End Get
            Set(ByVal value As String)
                atrPais = value
            End Set
        End Property

        Public Property RutaCert() As String
            Get
                Return atrRutaCert
            End Get
            Set(ByVal value As String)
                atrRutaCert = value
            End Set
        End Property

        Public Property RutaKey() As String
            Get
                Return atrRutaKey
            End Get
            Set(ByVal value As String)
                atrRutaKey = value
            End Set
        End Property

        Public Property PassKey() As String
            Get
                Return atrPassKey
            End Get
            Set(ByVal value As String)
                atrPassKey = value
            End Set
        End Property

        Public Property RutaXml() As String
            Get
                Return atrRutaXml
            End Get
            Set(ByVal value As String)
                atrRutaXml = value
            End Set
        End Property

        Public Property DestinoXml() As String
            Get
                Return atrDestinoXml
            End Get
            Set(ByVal value As String)
                atrDestinoXml = value
            End Set
        End Property

        Public Property DestinoAcuseXml() As String
            Get
                Return atrDestinoAcuseXml
            End Get
            Set(ByVal value As String)
                atrDestinoAcuseXml = value
            End Set
        End Property

        Public Property RutaBidimensional() As String
            Get
                Return atrRutaBidimensional
            End Get
            Set(ByVal value As String)
                atrRutaBidimensional = value
            End Set
        End Property

        Public Property UsuarioWS() As String
            Get
                Return atrUsuarioWS
            End Get
            Set(ByVal value As String)
                atrUsuarioWS = value
            End Set
        End Property

        Public Property PasswordWS() As String
            Get
                Return atrPasswordWS
            End Get
            Set(ByVal value As String)
                atrPasswordWS = value
            End Set
        End Property

        Public Property AcuseCancelacion() As String
            Get
                Return atrAcuseCancelacion
            End Get
            Set(ByVal value As String)
                atrAcuseCancelacion = value
            End Set
        End Property

        Public Property NoAprobacion() As String
            Get
                Return atrNoAprobacion
            End Get
            Set(ByVal value As String)
                atrNoAprobacion = value
            End Set
        End Property

        Public Property AnoAprobacion() As String
            Get
                Return atrAnoAprobacion
            End Get
            Set(ByVal value As String)
                atrAnoAprobacion = value
            End Set
        End Property

        Public Property SelloCancelacion() As String
            Get
                Return atrSelloCancelacion
            End Get
            Set(ByVal value As String)
                atrSelloCancelacion = value
            End Set
        End Property

        Public Property PassCancelacion() As String
            Get
                Return (atrPassCancelacion)
            End Get
            Set(ByVal value As String)
                atrPassCancelacion = value
            End Set
        End Property


    End Class

End Namespace
