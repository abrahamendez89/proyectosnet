﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión del motor en tiempo de ejecución:2.0.50727.5466
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Xml.Serialization
Imports System.Text

Namespace V32
    '
    'This source code was auto-generated by xsd, Version=2.0.50727.1432.
    '

    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/nomina"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.sat.gob.mx/nomina", IsNullable:=False)> _
    Partial Public Class Nomina
        <System.Xml.Serialization.XmlAttribute("schemaLocation", Namespace:="http://www.w3.org/2001/XMLSchema-instance")> _
        Public xsiSchemaLocation As String = "http://www.sat.gob.mx/nomina http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina11.xsd"


        Private percepcionesField() As NominaPercepciones

        Private deduccionesField() As NominaDeducciones

        Private incapacidadesField() As NominaIncapacidadesIncapacidad

        Private horasExtrasField() As NominaHorasExtrasHorasExtra

        Private versionField As String

        Private registroPatronalField As String

        Private numEmpleadoField As String

        Private cURPField As String

        Private tipoRegimenField As Integer

        Private numSeguridadSocialField As String

        Private fechaPagoField As Date

        Private fechaInicialPagoField As Date

        Private fechaFinalPagoField As Date

        Private numDiasPagadosField As Decimal

        Private departamentoField As String

        Private cLABEField As String

        Private bancoField As Integer

        Private bancoFieldSpecified As Boolean

        Private fechaInicioRelLaboralField As Date

        Private fechaInicioRelLaboralFieldSpecified As Boolean

        Private antiguedadField As Integer

        Private antiguedadFieldSpecified As Boolean

        Private puestoField As String

        Private tipoContratoField As String

        Private tipoJornadaField As String

        Private periodicidadPagoField As String

        Private salarioBaseCotAporField As Decimal

        Private salarioBaseCotAporFieldSpecified As Boolean

        Private riesgoPuestoField As Integer

        Private riesgoPuestoFieldSpecified As Boolean

        Private salarioDiarioIntegradoField As Decimal

        Private salarioDiarioIntegradoFieldSpecified As Boolean

        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute("Percepciones")> _
        Public Property Percepciones() As NominaPercepciones()
            Get
                Return Me.percepcionesField
            End Get
            Set(ByVal value As NominaPercepciones())
                Me.percepcionesField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute("Deducciones")> _
        Public Property Deducciones() As NominaDeducciones()
            Get
                Return Me.deduccionesField
            End Get
            Set(ByVal value As NominaDeducciones())
                Me.deduccionesField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Incapacidad", GetType(NominaIncapacidadesIncapacidad), IsNullable:=False)> _
        Public Property Incapacidades() As NominaIncapacidadesIncapacidad()
            Get
                Return Me.incapacidadesField
            End Get
            Set(ByVal value As NominaIncapacidadesIncapacidad())
                Me.incapacidadesField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlArrayItemAttribute("HorasExtra", GetType(NominaHorasExtrasHorasExtra), IsNullable:=False)> _
        Public Property HorasExtras() As NominaHorasExtrasHorasExtra()
            Get
                Return Me.horasExtrasField
            End Get
            Set(ByVal value As NominaHorasExtrasHorasExtra())
                Me.horasExtrasField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Version() As String
            Get
                Return Me.versionField
            End Get
            Set(ByVal value As String)
                Me.versionField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property RegistroPatronal() As String
            Get
                Return Me.registroPatronalField
            End Get
            Set(ByVal value As String)
                Me.registroPatronalField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property NumEmpleado() As String
            Get
                Return Me.numEmpleadoField
            End Get
            Set(ByVal value As String)
                Me.numEmpleadoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property CURP() As String
            Get
                Return Me.cURPField
            End Get
            Set(ByVal value As String)
                Me.cURPField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TipoRegimen() As Integer
            Get
                Return Me.tipoRegimenField
            End Get
            Set(ByVal value As Integer)
                Me.tipoRegimenField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property NumSeguridadSocial() As String
            Get
                Return Me.numSeguridadSocialField
            End Get
            Set(ByVal value As String)
                Me.numSeguridadSocialField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="date")> _
        Public Property FechaPago() As Date
            Get
                Return Me.fechaPagoField
            End Get
            Set(ByVal value As Date)
                Me.fechaPagoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="date")> _
        Public Property FechaInicialPago() As Date
            Get
                Return Me.fechaInicialPagoField
            End Get
            Set(ByVal value As Date)
                Me.fechaInicialPagoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="date")> _
        Public Property FechaFinalPago() As Date
            Get
                Return Me.fechaFinalPagoField
            End Get
            Set(ByVal value As Date)
                Me.fechaFinalPagoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property NumDiasPagados() As Decimal
            Get
                Return Me.numDiasPagadosField
            End Get
            Set(ByVal value As Decimal)
                Me.numDiasPagadosField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Departamento() As String
            Get
                Return Me.departamentoField
            End Get
            Set(ByVal value As String)
                Me.departamentoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="integer")> _
        Public Property CLABE() As String
            Get
                Return Me.cLABEField
            End Get
            Set(ByVal value As String)
                Me.cLABEField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Banco() As Integer
            Get
                Return Me.bancoField
            End Get
            Set(ByVal value As Integer)
                Me.bancoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property BancoSpecified() As Boolean
            Get
                Return Me.bancoFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.bancoFieldSpecified = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="date")> _
        Public Property FechaInicioRelLaboral() As Date
            Get
                Return Me.fechaInicioRelLaboralField
            End Get
            Set(ByVal value As Date)
                Me.fechaInicioRelLaboralField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property FechaInicioRelLaboralSpecified() As Boolean
            Get
                Return Me.fechaInicioRelLaboralFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.fechaInicioRelLaboralFieldSpecified = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Antiguedad() As Integer
            Get
                Return Me.antiguedadField
            End Get
            Set(ByVal value As Integer)
                Me.antiguedadField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property AntiguedadSpecified() As Boolean
            Get
                Return Me.antiguedadFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.antiguedadFieldSpecified = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Puesto() As String
            Get
                Return Me.puestoField
            End Get
            Set(ByVal value As String)
                Me.puestoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TipoContrato() As String
            Get
                Return Me.tipoContratoField
            End Get
            Set(ByVal value As String)
                Me.tipoContratoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TipoJornada() As String
            Get
                Return Me.tipoJornadaField
            End Get
            Set(ByVal value As String)
                Me.tipoJornadaField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property PeriodicidadPago() As String
            Get
                Return Me.periodicidadPagoField
            End Get
            Set(ByVal value As String)
                Me.periodicidadPagoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property SalarioBaseCotApor() As Decimal
            Get
                Return Me.salarioBaseCotAporField
            End Get
            Set(ByVal value As Decimal)
                Me.salarioBaseCotAporField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property SalarioBaseCotAporSpecified() As Boolean
            Get
                Return Me.salarioBaseCotAporFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.salarioBaseCotAporFieldSpecified = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property RiesgoPuesto() As Integer
            Get
                Return Me.riesgoPuestoField
            End Get
            Set(ByVal value As Integer)
                Me.riesgoPuestoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property RiesgoPuestoSpecified() As Boolean
            Get
                Return Me.riesgoPuestoFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.riesgoPuestoFieldSpecified = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property SalarioDiarioIntegrado() As Decimal
            Get
                Return Me.salarioDiarioIntegradoField
            End Get
            Set(ByVal value As Decimal)
                Me.salarioDiarioIntegradoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property SalarioDiarioIntegradoSpecified() As Boolean
            Get
                Return Me.salarioDiarioIntegradoFieldSpecified
            End Get
            Set(ByVal value As Boolean)
                Me.salarioDiarioIntegradoFieldSpecified = value
            End Set
        End Property
    End Class

    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/nomina")> _
    Partial Public Class NominaPercepciones

        Private percepcionField() As NominaPercepcionesPercepcion

        Private totalGravadoField As Decimal

        Private totalExentoField As Decimal

        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute("Percepcion")> _
        Public Property Percepcion() As NominaPercepcionesPercepcion()
            Get
                Return Me.percepcionField
            End Get
            Set(ByVal value As NominaPercepcionesPercepcion())
                Me.percepcionField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TotalGravado() As Decimal
            Get
                Return Me.totalGravadoField
            End Get
            Set(ByVal value As Decimal)
                Me.totalGravadoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TotalExento() As Decimal
            Get
                Return Me.totalExentoField
            End Get
            Set(ByVal value As Decimal)
                Me.totalExentoField = value
            End Set
        End Property
    End Class

    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/nomina")> _
    Partial Public Class NominaPercepcionesPercepcion

        Private tipoPercepcionField As Integer

        Private claveField As String

        Private conceptoField As String

        Private importeGravadoField As Decimal

        Private importeExentoField As Decimal

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TipoPercepcion() As Integer
            Get
                Return Me.tipoPercepcionField
            End Get
            Set(ByVal value As Integer)
                Me.tipoPercepcionField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Clave() As String
            Get
                Return Me.claveField
            End Get
            Set(ByVal value As String)
                Me.claveField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Concepto() As String
            Get
                Return Me.conceptoField
            End Get
            Set(ByVal value As String)
                Me.conceptoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property ImporteGravado() As Decimal
            Get
                Return Me.importeGravadoField
            End Get
            Set(ByVal value As Decimal)
                Me.importeGravadoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property ImporteExento() As Decimal
            Get
                Return Me.importeExentoField
            End Get
            Set(ByVal value As Decimal)
                Me.importeExentoField = value
            End Set
        End Property
    End Class

    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/nomina")> _
    Partial Public Class NominaDeducciones

        Private deduccionField() As NominaDeduccionesDeduccion

        Private totalGravadoField As Decimal

        Private totalExentoField As Decimal

        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute("Deduccion")> _
        Public Property Deduccion() As NominaDeduccionesDeduccion()
            Get
                Return Me.deduccionField
            End Get
            Set(ByVal value As NominaDeduccionesDeduccion())
                Me.deduccionField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TotalGravado() As Decimal
            Get
                Return Me.totalGravadoField
            End Get
            Set(ByVal value As Decimal)
                Me.totalGravadoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TotalExento() As Decimal
            Get
                Return Me.totalExentoField
            End Get
            Set(ByVal value As Decimal)
                Me.totalExentoField = value
            End Set
        End Property
    End Class

    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/nomina")> _
    Partial Public Class NominaDeduccionesDeduccion

        Private tipoDeduccionField As Integer

        Private claveField As String

        Private conceptoField As String

        Private importeGravadoField As Decimal

        Private importeExentoField As Decimal

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TipoDeduccion() As Integer
            Get
                Return Me.tipoDeduccionField
            End Get
            Set(ByVal value As Integer)
                Me.tipoDeduccionField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Clave() As String
            Get
                Return Me.claveField
            End Get
            Set(ByVal value As String)
                Me.claveField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Concepto() As String
            Get
                Return Me.conceptoField
            End Get
            Set(ByVal value As String)
                Me.conceptoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property ImporteGravado() As Decimal
            Get
                Return Me.importeGravadoField
            End Get
            Set(ByVal value As Decimal)
                Me.importeGravadoField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property ImporteExento() As Decimal
            Get
                Return Me.importeExentoField
            End Get
            Set(ByVal value As Decimal)
                Me.importeExentoField = value
            End Set
        End Property
    End Class

    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/nomina")> _
    Partial Public Class NominaIncapacidadesIncapacidad

        Private diasIncapacidadField As Decimal

        Private tipoIncapacidadField As Integer

        Private descuentoField As Decimal

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property DiasIncapacidad() As Decimal
            Get
                Return Me.diasIncapacidadField
            End Get
            Set(ByVal value As Decimal)
                Me.diasIncapacidadField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TipoIncapacidad() As Integer
            Get
                Return Me.tipoIncapacidadField
            End Get
            Set(ByVal value As Integer)
                Me.tipoIncapacidadField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Descuento() As Decimal
            Get
                Return Me.descuentoField
            End Get
            Set(ByVal value As Decimal)
                Me.descuentoField = value
            End Set
        End Property
    End Class

    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/nomina")> _
    Partial Public Class NominaHorasExtrasHorasExtra

        Private diasField As Integer

        Private tipoHorasField As String

        Private horasExtraField As Integer

        Private importePagadoField As Decimal

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property Dias() As Integer
            Get
                Return Me.diasField
            End Get
            Set(ByVal value As Integer)
                Me.diasField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property TipoHoras() As String
            Get
                Return Me.tipoHorasField
            End Get
            Set(ByVal value As String)
                Me.tipoHorasField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property HorasExtra() As Integer
            Get
                Return Me.horasExtraField
            End Get
            Set(ByVal value As Integer)
                Me.horasExtraField = value
            End Set
        End Property

        '''<comentarios/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property ImportePagado() As Decimal
            Get
                Return Me.importePagadoField
            End Get
            Set(ByVal value As Decimal)
                Me.importePagadoField = value
            End Set

        End Property

    End Class

    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/nomina"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.sat.gob.mx/nomina", IsNullable:=False)> _
    Partial Public Class NewDataSet



        Private itemsField() As Nomina

        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute("Nomina")> _
        Public Property Items() As Nomina()
            Get
                Return Me.itemsField
            End Get
            Set(ByVal value As Nomina())
                Me.itemsField = value
            End Set
        End Property

    End Class



End Namespace

