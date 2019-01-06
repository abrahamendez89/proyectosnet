using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.Anotaciones.Propiedad;
using ACCESO_DATOS.Anotaciones.Clase;
using System.Linq.Expressions;
using System.ComponentModel;
using ACCESO_DATOS.Manejador;
using System.Reflection;
using ACCESO_DATOS.Control;

namespace ACCESO_DATOS.SuperClase
{
    public abstract class CLASE_BASE
    {
        [ANP_Columna(Columna = "ULTIMA_ACT")]
        [ANP_Configuracion(Nullable = true, ValorDefault = 1)]
        [ANP_CampoVersionamiento]
        public Int16 ULTIMA_ACT { get; set; }

        [ANP_Columna(Columna = "FECHA_CREACION")]
        [ANP_Configuracion(Nullable = true)]
        public DateTime FECHA_CREACION { get; set; }

        [ANP_Columna(Columna = "FECHA_MODIFICACION")]
        [ANP_Configuracion(Nullable = true)]
        public DateTime FECHA_MODIFICACION { get; set; }

        [ANP_Columna(Columna = "USUARIO_CREACION")]
        [ANP_Configuracion(Nullable = true)]
        public String USUARIO_CREACION { get; set; }

        [ANP_Columna(Columna = "USUREG")]
        [ANP_Configuracion(Nullable = true)]
        public String USUREG { get; set; }

        public Boolean ES_NUEVO { get; set; }

        public T Carga<T>(Expression<Func<T>> expr, ManejadorInstanciasBD mibd, Dictionary<String, Object> parametros = null) where T : CLASE_BASE
        {
            var mexpr = expr.Body as MemberExpression;
            if (mexpr == null) return default(T);
            if (mexpr.Member == null) return default(T);
            object[] attrs = mexpr.Member.GetCustomAttributes(typeof(ANP_QueryPropiedad), true);
            if (attrs == null || attrs.Length == 0) return default(T);
            ANP_QueryPropiedad desc = attrs[0] as ANP_QueryPropiedad;
            if (desc == null) return default(T);

            object retorno = Activator.CreateInstance(typeof(T));
            //aqui obtengo los parametros para la consulta
            List<String> parametrosString = Estructura.ObtenerListaParametros(desc.Query);
            //y con reflection llenar las variables
            Dictionary<String, Object> parametrosInternos = new Dictionary<string, object>();
            //se pasan los parametros si los hay a los parametros internos
            if (parametros != null)
                parametros.Keys.ToList().ForEach(x => parametrosInternos.Add(x, parametros[x]));
            //si encontramos el parametro en la clase, lo mandamos en el query, en caso contrario, se omite

            foreach (String parametro in parametrosString)
            {
                PropertyInfo piValorParametro = this.GetType().GetProperty(parametro, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                if (piValorParametro != null)
                {
                    //el parametro fue encontrado como propiedad de la clase
                    object valor = piValorParametro.GetValue(this);
                    parametrosInternos.Add(parametro, valor);
                }
            }
            retorno = mibd.ZMX_ConsultarUnico<T>(desc.Query, parametrosInternos);
            //obteniendo la propiedad a afectar con el resultado
            PropertyInfo pi = this.GetType().GetProperty(mexpr.Member.Name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            pi.SetValue(this, retorno);

            return (T)retorno;
        }

        public List<T> Carga<T>(Expression<Func<List<T>>> expr, ManejadorInstanciasBD mibd, Dictionary<String, Object> parametros = null) where T : CLASE_BASE 
        {
            var mexpr = expr.Body as MemberExpression;
            if (mexpr == null) return null;
            if (mexpr.Member == null) return null;
            object[] attrs = mexpr.Member.GetCustomAttributes(typeof(ANP_QueryPropiedad), true);
            if (attrs == null || attrs.Length == 0) return null;
            ANP_QueryPropiedad desc = attrs[0] as ANP_QueryPropiedad;
            if (desc == null) return null;

            object retorno = Activator.CreateInstance(typeof(List<T>));
            //aqui obtengo los parametros para la consulta
            List<String> parametrosString = Estructura.ObtenerListaParametros(desc.Query);
            //y con reflection llenar las variables
            Dictionary<String, Object> parametrosInternos = new Dictionary<string, object>();
            //se pasan los parametros si los hay a los parametros internos
            if (parametros != null)
                parametros.Keys.ToList().ForEach(x => parametrosInternos.Add(x, parametros[x]));
            //si encontramos el parametro en la clase, lo mandamos en el query, en caso contrario, se omite

            foreach (String parametro in parametrosString)
            {
                PropertyInfo piValorParametro = this.GetType().GetProperty(parametro, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                if(piValorParametro != null)
                {
                    //el parametro fue encontrado como propiedad de la clase
                    object valor = piValorParametro.GetValue(this);
                    parametrosInternos.Add(parametro, valor);
                }
            }
            retorno = mibd.ZMX_ConsultarListado<T>(desc.Query, parametrosInternos);
            //obteniendo la propiedad a afectar con el resultado
            PropertyInfo pi = this.GetType().GetProperty(mexpr.Member.Name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            pi.SetValue(this, retorno);
           
            return (List<T>)retorno;
        }

    }
}
