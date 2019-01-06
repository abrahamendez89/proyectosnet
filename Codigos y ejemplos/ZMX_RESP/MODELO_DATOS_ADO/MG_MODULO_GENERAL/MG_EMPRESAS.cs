using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.Anotaciones.Clase;
using ACCESO_DATOS.Anotaciones.Propiedad;
using ACCESO_DATOS.SuperClase;

namespace MODELO_DATOS_ADO.MG_MODULO_GENERAL
{
    [ANC_Tabla(Nombre = "MG_EMPRESAS")]
    [ANC_Identificador(Columna = "EMPRESA_ID", Propiedad = "EMPRESA_ID")]
    [ANC_IDFormado(Columna = "EMPRESA_ID", Propiedad = "EMPRESA_ID")]

    public class MG_EMPRESAS : CLASE_BASE
    {

        [ANP_Configuracion(Nullable = false)]
        [ANP_LongitudString(Maxima = 15)]
        [ANP_Columna(Columna = "EMPRESA_NUMEXT")]
        public String EMPRESA_NUMEXT { get; set; }

        [ANP_Configuracion(Nullable = true)]
        [ANP_LongitudString(Maxima = 15)]
        [ANP_Columna(Columna = "EMPRESA_NUMINT")]
        public String EMPRESA_NUMINT { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_LongitudString(Maxima = 10)]
        [ANP_Columna(Columna = "EMPRESA_CP")]
        public String EMPRESA_CP { get; set; }

        [ANP_Configuracion(Nullable = true)]
        [ANP_LongitudString(Maxima = 80)]
        [ANP_Columna(Columna = "EMPRESA_EMAIL")]
        public String EMPRESA_EMAIL { get; set; }

        [ANP_Configuracion(Nullable = true)]
        [ANP_LongitudString(Maxima = 13)]
        [ANP_Columna(Columna = "EMPRESA_TELEFONO")]
        public String EMPRESA_TELEFONO { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_LongitudString(Maxima = 160)]
        [ANP_Columna(Columna = "EMPRESA_GIRO")]
        public String EMPRESA_GIRO { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 2)]
        [ANP_Columna(Columna = "EMPRESA_TIPO_EMPRESA")]
        public Int64? EMPRESA_TIPO_EMPRESA { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_Columna(Columna = "EMPRESA_INICIO_OPERACIONES")]
        public DateTime? EMPRESA_INICIO_OPERACIONES { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 2)]
        [ANP_Columna(Columna = "EMPRESA_MES_INICIAL")]
        public Int64? EMPRESA_MES_INICIAL { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 3)]
        [ANP_Columna(Columna = "EMPRESA_CODIGO")]
        public Int64? EMPRESA_CODIGO { get; set; }

        [ANP_Configuracion(Nullable = true)]
        [ANP_Columna(Columna = "EMPRESA_LOGOTIPO")]
        public Byte[] EMPRESA_LOGOTIPO { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 3)]
        [ANP_Columna(Columna = "ESTATUS_ID")]
        public Int64? ESTATUS_ID { get; set; }

        [ANP_Configuracion(Nullable = true)]
        [ANP_PrecisionNumerica(Enteros = 3)]
        [ANP_Columna(Columna = "IDIOMA_ID")]
        public Int64? IDIOMA_ID { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_LongitudString(Maxima = 320)]
        [ANP_Columna(Columna = "EMPRESA_NOMBRE")]
        public String EMPRESA_NOMBRE { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_LongitudString(Maxima = 160)]
        [ANP_Columna(Columna = "EMPRESA_NOMBRE_CORTO")]
        public String EMPRESA_NOMBRE_CORTO { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_LongitudString(Maxima = 52)]
        [ANP_Columna(Columna = "EMPRESA_RFC")]
        public String EMPRESA_RFC { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_LongitudString(Maxima = 320)]
        [ANP_Columna(Columna = "EMPRESA_DIRECCION")]
        public String EMPRESA_DIRECCION { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_LongitudString(Maxima = 160)]
        [ANP_Columna(Columna = "EMPRESA_COLONIA")]
        public String EMPRESA_COLONIA { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 5)]
        [ANP_Columna(Columna = "EMPRESA_ID")]
        public Int64? EMPRESA_ID { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 3)]
        [ANP_Columna(Columna = "GRUPO_ID")]
        public Int64? GRUPO_ID { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 14)]
        [ANP_Columna(Columna = "LOCALIDAD_ID")]
        public Int64? LOCALIDAD_ID { get; set; }

    }


}
