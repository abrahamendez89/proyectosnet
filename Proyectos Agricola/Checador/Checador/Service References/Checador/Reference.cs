﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Checador.Checador {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://tempuri.org/", ItemName="string")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Checador.ChecadorSoap")]
    public interface ChecadorSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento featureSet del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ChecarEmpleadoPorHuella", ReplyAction="*")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Checador.Checador.ArrayOfString))]
        Checador.Checador.ChecarEmpleadoPorHuellaResponse ChecarEmpleadoPorHuella(Checador.Checador.ChecarEmpleadoPorHuellaRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ChecarEmpleadoPorHuellaRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ChecarEmpleadoPorHuella", Namespace="http://tempuri.org/", Order=0)]
        public Checador.Checador.ChecarEmpleadoPorHuellaRequestBody Body;
        
        public ChecarEmpleadoPorHuellaRequest() {
        }
        
        public ChecarEmpleadoPorHuellaRequest(Checador.Checador.ChecarEmpleadoPorHuellaRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ChecarEmpleadoPorHuellaRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public object featureSet;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string ccve_nomina;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string ccve_temporada;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string bdNomina;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string idChecador;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string tamSegmentos;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string idHorario;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public bool esUnaPrueba;
        
        public ChecarEmpleadoPorHuellaRequestBody() {
        }
        
        public ChecarEmpleadoPorHuellaRequestBody(object featureSet, string ccve_nomina, string ccve_temporada, string bdNomina, string idChecador, string tamSegmentos, string idHorario, bool esUnaPrueba) {
            this.featureSet = featureSet;
            this.ccve_nomina = ccve_nomina;
            this.ccve_temporada = ccve_temporada;
            this.bdNomina = bdNomina;
            this.idChecador = idChecador;
            this.tamSegmentos = tamSegmentos;
            this.idHorario = idHorario;
            this.esUnaPrueba = esUnaPrueba;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ChecarEmpleadoPorHuellaResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ChecarEmpleadoPorHuellaResponse", Namespace="http://tempuri.org/", Order=0)]
        public Checador.Checador.ChecarEmpleadoPorHuellaResponseBody Body;
        
        public ChecarEmpleadoPorHuellaResponse() {
        }
        
        public ChecarEmpleadoPorHuellaResponse(Checador.Checador.ChecarEmpleadoPorHuellaResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ChecarEmpleadoPorHuellaResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Checador.Checador.ArrayOfString ChecarEmpleadoPorHuellaResult;
        
        public ChecarEmpleadoPorHuellaResponseBody() {
        }
        
        public ChecarEmpleadoPorHuellaResponseBody(Checador.Checador.ArrayOfString ChecarEmpleadoPorHuellaResult) {
            this.ChecarEmpleadoPorHuellaResult = ChecarEmpleadoPorHuellaResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ChecadorSoapChannel : Checador.Checador.ChecadorSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChecadorSoapClient : System.ServiceModel.ClientBase<Checador.Checador.ChecadorSoap>, Checador.Checador.ChecadorSoap {
        
        public ChecadorSoapClient() {
        }
        
        public ChecadorSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChecadorSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChecadorSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChecadorSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Checador.Checador.ChecarEmpleadoPorHuellaResponse Checador.Checador.ChecadorSoap.ChecarEmpleadoPorHuella(Checador.Checador.ChecarEmpleadoPorHuellaRequest request) {
            return base.Channel.ChecarEmpleadoPorHuella(request);
        }
        
        public Checador.Checador.ArrayOfString ChecarEmpleadoPorHuella(object featureSet, string ccve_nomina, string ccve_temporada, string bdNomina, string idChecador, string tamSegmentos, string idHorario, bool esUnaPrueba) {
            Checador.Checador.ChecarEmpleadoPorHuellaRequest inValue = new Checador.Checador.ChecarEmpleadoPorHuellaRequest();
            inValue.Body = new Checador.Checador.ChecarEmpleadoPorHuellaRequestBody();
            inValue.Body.featureSet = featureSet;
            inValue.Body.ccve_nomina = ccve_nomina;
            inValue.Body.ccve_temporada = ccve_temporada;
            inValue.Body.bdNomina = bdNomina;
            inValue.Body.idChecador = idChecador;
            inValue.Body.tamSegmentos = tamSegmentos;
            inValue.Body.idHorario = idHorario;
            inValue.Body.esUnaPrueba = esUnaPrueba;
            Checador.Checador.ChecarEmpleadoPorHuellaResponse retVal = ((Checador.Checador.ChecadorSoap)(this)).ChecarEmpleadoPorHuella(inValue);
            return retVal.Body.ChecarEmpleadoPorHuellaResult;
        }
    }
}
