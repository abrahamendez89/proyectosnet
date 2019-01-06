using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Herramientas.Conversiones
{
    public class Formatos
    {
        #region Double
        public static int DoubleRedondeoAEnteroArriba(double numero)
        {
            return (int)Math.Ceiling(numero);
        }
        public static int DoubleRedondeoAEnteroAbajo(double numero)
        {
            return (int)Math.Floor(numero);
        }
        public static String DoubleANumeroConSeparadores(double numero)
        {
            return numero.ToString("N");
        }
        public static String DoubleAPorcentaje(double numero)
        {
            return numero.ToString("P");
        }
        public static String DoubleAMoneda(double numero)
        {
            try
            {
                return numero.ToString("C");
            }
            catch
            {
                return 0.ToString("C");
            }
        }
        public static double DoubleRedondearANDecimales(double numero, int decimales)
        {
            if (Double.IsNaN(numero))
                return 0;
            return Math.Round(numero, decimales);
        }
        public static String DoubleRedondearANDecimalesString(double numero, int decimales)
        {
            numero = DoubleRedondearANDecimales(numero, decimales);
            return DoubleAMoneda(numero).Replace("$", "");
        }
        public static String DoubleAMonedaANDecimales(double numero, int decimales)
        {
            numero = DoubleRedondearANDecimales(numero, decimales);
            return DoubleAMoneda(numero);
        }
        #endregion
        #region Int
        public static String IntAMes(int mes)
        {
            System.Globalization.DateTimeFormatInfo mfi = Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            string Mes = mfi.GetAbbreviatedMonthName(mes).Replace(".", "");
            return Mes;
        }
        public static String IntANDigitos(int numero, int digitos)
        {
            String ceros = "";
            for (int i = 0; i < digitos; i++)
            {
                ceros += "0";
            }
            return numero.ToString(ceros);
        }
        #endregion
        #region DateTime
        public static String DateTimeAFechaCalendario(DateTime fecha)
        {
            String strFecha = DatetimeANombreDiaLargo(fecha) + " " + fecha.Day + " de " + DatetimeANombreMesLargo(fecha);
            return strFecha;
        }
        public static String DateTimeAFechaNumero(DateTime fecha)
        {
            return fecha.ToString("yyyyMMdd_HHmmss");
        }
        public static String DateTimeAFechaCorta(DateTime fecha)
        {
            return fecha.ToString("d");
        }

        public static String DatetimeAMesCorto(DateTime fecha)
        {
            System.Globalization.DateTimeFormatInfo mfi = Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            string Mes = mfi.GetAbbreviatedMonthName(fecha.Month).Replace(".", "");
            return Mes;
        }
        public static String DateTimeAFechaCortaConDiaMesTexto(DateTime fecha)
        {
            System.Globalization.DateTimeFormatInfo mfi = Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            string DiaSemana = mfi.GetDayName(fecha.DayOfWeek);
            string Mes = mfi.GetAbbreviatedMonthName(fecha.Month).Replace(".", "");

            String fechaSt = DiaSemana.Substring(0, 3) + "," + IntANDigitos(fecha.Day, 2) + @"" + Mes + @"'" + fecha.Year.ToString().Substring(2, 2);
            return fechaSt;
        }
        public static String DateTimeAFechaCortaConMesTexto(DateTime fecha)
        {
            string strMonthName = DatetimeANombreMesLargo(fecha);
            String fechaSt = fecha.Day.ToString("00") + @"-" + strMonthName.ToUpper() + @"-" + fecha.Year;
            return fechaSt;
        }
        public static String DatetimeANombreMesLargo(DateTime fecha)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(fecha.Month);

        }
        public static String DatetimeANombreDiaLargo(DateTime fecha)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(fecha.DayOfWeek);

        }
        public static String DateTimeAFechaLargaTextoDescripciones(DateTime fecha)
        {
            return String.Format("{0:F}", fecha);
        }
        public static String DateTimeAFechaCortaConMesTextoAbreviado(DateTime fecha)
        {
            System.Globalization.DateTimeFormatInfo mfi = Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            string strMonthName = mfi.GetAbbreviatedMonthName(fecha.Month).Replace(".", "");

            String fechaSt = fecha.Day.ToString("00") + @"-" + strMonthName.ToUpper() + @"-" + fecha.Year;
            return fechaSt;
        }
        public static String DateTimeAFechaLarga(DateTime fecha)
        {
            return fecha.ToString("G");
        }
        public static String DateTimeAFechaLOG(DateTime fecha)
        {
            return fecha.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static String DateTimeAFechaLOGArchivo(DateTime fecha)
        {
            return fecha.ToString("yyyyMMdd_HHmmss");
        }
        public static String DateTimeAFechaPolizaSAT(DateTime fecha)
        {
            return fecha.ToString("yyyy-MM-dd");
        }
        public static String DateTimeAFechaUniversal(DateTime fecha)
        {
            return fecha.ToString("u");
        }
        public static String DateTimeAHora(DateTime fecha)
        {
            return fecha.ToString("{0:t}");
        }
        #endregion
        #region Boolean
        public static Boolean BooleanIntABoolean(int bit)
        {
            if (bit == 0) return false;
            else if (bit == 1) return true;
            throw new Exception("El valor entero solo debe ser 1 o 0.");
        }
        public static Boolean BooleanStringABoolean(string bit)
        {
            if (bit.ToLower().Trim().Equals("true")) return true;
            else if (bit.ToLower().Trim().Equals("false")) return false;
            throw new Exception("El valor string solo debe ser 'true' o 'false'.");
        }
        public static int BooleanBooleanAInt(Boolean valor)
        {
            if (valor) return 1;
            else return 0;
        }
        public static String BooleanBooleanAString(Boolean valor)
        {
            if (valor) return "True";
            else return "False";
        }
        #endregion
        #region String
        public static double StringFormatoDineroADouble(String formatoDinero)
        {
            var cultureInfo = Thread.CurrentThread.CurrentUICulture;
            double plain = Double.Parse(formatoDinero, System.Globalization.NumberStyles.Currency);
            return plain;
        }
        #endregion
    }
}
