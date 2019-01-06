using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.Anotaciones.Clase;
using ACCESO_DATOS.Anotaciones.Propiedad;
using ACCESO_DATOS.SuperClase;
using MODELO_DATOS_ADO.MG_MODULO_GENERAL;

namespace MODELO_DATOS_ADO.LO_LOGISTICA
{
    [ANC_Tabla(Nombre = "LO_TARIFAS_FLETES_AUTORIZADAS")]
    [ANC_Identificador(Columna = "GRUPO_ID", Propiedad = "GRUPO_ID")]
    [ANC_Identificador(Columna = "EMPRESA_ID", Propiedad = "EMPRESA_ID")]
    [ANC_Identificador(Columna = "TARIFAFLE_VIGENCIA", Propiedad = "TARIFAFLE_VIGENCIA")]
    [ANC_IDFormado(Columna = "TARIFAFLE_VIGENCIA", Propiedad = "TARIFAFLE_VIGENCIA")]

    public class LO_TARIFAS_FLETES_AUTORIZADAS : CLASE_BASE
    {

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 3)]
        [ANP_Columna(Columna = "GRUPO_ID")]
        public Int64? GRUPO_ID { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 5)]
        [ANP_Columna(Columna = "EMPRESA_ID")]
        public Int64? EMPRESA_ID { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 14)]
        [ANP_Columna(Columna = "LOCALIDAD_ID_ORIGEN")]
        public Int64? LOCALIDAD_ID_ORIGEN { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 14)]
        [ANP_Columna(Columna = "LOCALIDAD_ID_DESTINO")]
        public Int64? LOCALIDAD_ID_DESTINO { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 3)]
        [ANP_Columna(Columna = "ESTATUS_ID")]
        public Int64? ESTATUS_ID { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_Columna(Columna = "TARIFAFLE_VIGENCIA")]
        public DateTime? TARIFAFLE_VIGENCIA { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_Columna(Columna = "TARIFAFLE_ULTIMA_VIGENCIA")]
        public DateTime? TARIFAFLE_ULTIMA_VIGENCIA { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 10, Decimales = 6)]
        [ANP_Columna(Columna = "TARIFAFLE_PRECIO_TONELADA")]
        public Decimal? TARIFAFLE_PRECIO_TONELADA { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 10, Decimales = 6)]
        [ANP_Columna(Columna = "TARIFAFLE_PRECIO_MANIOBRA")]
        public Decimal? TARIFAFLE_PRECIO_MANIOBRA { get; set; }

        [ANP_Configuracion(Nullable = false)]
        [ANP_PrecisionNumerica(Enteros = 10, Decimales = 6)]
        [ANP_Columna(Columna = "TARIFAFLE_PRECIO_REPARTOS")]
        public Decimal? TARIFAFLE_PRECIO_REPARTOS { get; set; }
        public MG_EMPRESAS EMPRESA { get; set; }
        
    }
}
