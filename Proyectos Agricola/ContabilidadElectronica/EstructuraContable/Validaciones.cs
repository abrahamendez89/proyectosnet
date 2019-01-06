using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EstructuraContable
{
    public class Validaciones
    {
        #region validaciones balanza
        public static Boolean ValidaRFC(String RFC)
        {
            if (RFC.Trim().Length < 12 || RFC.Trim().Length > 13)
            {
                return false;
            }
            string reg = @"[A-ZÑ&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z0-9]?[A-Z0-9]? [0-9A-Z]?";

            if (!Regex.IsMatch(RFC, reg))
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaTipoEnvio(String TipoEnvio)
        {
            string reg = @"[NC]";

            if (!Regex.IsMatch(TipoEnvio, reg))
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaFechaModBal(String TipoEnvio, DateTime fechaModificacion)
        {
            if (TipoEnvio.Equals("C"))
            {
                if (fechaModificacion != DateTime.MinValue)
                    return true;
                else
                    return false;
            }
            else
            {
                return true;
            }
        }
        public static Boolean ValidaMes(int Mes)
        {
            if (Mes < 1 || Mes > 12)
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaAno(int ano)
        {
            if (ano < 2014 || ano > 2099)
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaTotalCuentas(int total)
        {
            if (total < 2)
                return false;
            return true;
        }
        #endregion 
        #region validaciones balanza cuentas
        public static Boolean ValidaNumCuenta(String cuenta)
        {
            if (cuenta.Trim().Length < 1 || cuenta.Trim().Length > 100)
                return false;
            return true;
        }
        #endregion
        #region validaciones catalogo cuentas
        public static Boolean ValidaCodAgrupador(String codigo)
        {
            string reg = @"[0.-9]{1,12}";

            if (!Regex.IsMatch(codigo, reg))
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaDescripcion1_200(String descripcion)
        {
            if (descripcion.Trim().Length < 1 || descripcion.Trim().Length > 200)
                return false;
            return true;
        }
        public static Boolean ValidaSubCuentaDe1_100(String descripcion)
        {
            if (descripcion == null)
                return false;
            if (descripcion.Trim().Length < 1 || descripcion.Trim().Length > 100)
                return false;
            return true;
        }
        public static Boolean ValidaNaturaleza(char naturaleza)
        {
            string reg = @"[DA]";

            if (!Regex.IsMatch(naturaleza.ToString(), reg))
            {
                return false;
            }
            return true;
        }
        #endregion
        #region validaciones para poliza contenedor
        public static Boolean ValidaTipoSolicitud(String TipoSolicitud)
        {
            string reg = @"AF|FC|DE|CO";

            if (!Regex.IsMatch(TipoSolicitud, reg))
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaNumOrden(String TipoSolicitud, String NumOrden)
        {
            
            if (TipoSolicitud.Equals("AF") || TipoSolicitud.Equals("FC"))
            {
                if (NumOrden.Equals(""))
                {
                    return false;
                }
                else
                {
                    if (TipoSolicitud.Length != 13)
                        return false;
                    else
                    {
                        string reg = @"[A-Z]{3}[0-6][0-9][0-9]{5}(/)[0-9]{2}";
                        if (!Regex.IsMatch(TipoSolicitud, reg))
                        {
                            return false;
                        }
                        else 
                            return true;
                    }
                }
            }
            return true;
        }
        public static Boolean ValidaNumTramite(String TipoSolicitud, String NumTramite)
        {

            if (TipoSolicitud.Equals("DE") || TipoSolicitud.Equals("CO"))
            {
                if (NumTramite.Equals(""))
                {
                    return false;
                }
                else
                {
                    if (TipoSolicitud.Length != 10)
                        return false;
                    else
                    {
                        string reg = @"[0-9]{10}";
                        if (!Regex.IsMatch(TipoSolicitud, reg))
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                }
            }
            return true;
        }
        #endregion
        #region validaciones para cheques
        public static Boolean ValidaNumeroCheque1_20(String numeroCheque)
        {
            if (numeroCheque.Trim().Length < 1 || numeroCheque.Trim().Length > 20)
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaBanco(String Banco)
        {
            string reg = @"[0-9]{3}";

            if (!Regex.IsMatch(Banco, reg))
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaCuenta1_50(String cuenta)
        {
            if (cuenta.Trim().Length < 1 || cuenta.Trim().Length > 50)
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaBeneficiario1_300(String beneficiario)
        {
            if (beneficiario.Trim().Length < 1 || beneficiario.Trim().Length > 300)
            {
                return false;
            }
            return true;
        }
        #endregion
        #region validaciones para comprobantes
        public static Boolean ValidaUUID_CFDI(String UUID_CFDI)
        {
            string reg = @"[a-f0-9A-F]{8}-[a-f0-9A-F]{4}-[a-f0-9A-F]{4}-[a-f0-9A-F]{4}-[a-f0-9A-F]{12}";

            if (!Regex.IsMatch(UUID_CFDI, reg))
            {
                return false;
            }
            return true;
        }
        #endregion
        #region validaciones para comprobantes
        public static Boolean ValidaTipoPoliza(int tipo)
        {
            if (tipo != 1 || tipo != 2 || tipo != 3)
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaNumeroPoliza1_50(String numeroPoliza)
        {
            if (numeroPoliza.Trim().Length < 1 || numeroPoliza.Trim().Length > 50)
                return false;
            return true;
        }
        public static Boolean ValidaConceptoPoliza1_300(String concepto)
        {
            if (concepto.Trim().Length < 1 || concepto.Trim().Length > 300)
                return false;
            return true;
        }
        public static Boolean ValidaDesCtaTransaccion1_100(String DesCta)
        {
            if (DesCta.Trim().Length < 1 || DesCta.Trim().Length > 100)
                return false;
            return true;
        }
        #endregion
        #region validaciones para comprobantes
        public static Boolean ValidaTaxID(String TaxID)
        {
            if (TaxID.Length >= 1 && TaxID.Length <= 30)
            {
                return true;
            }
            return false;
        }
        public static Boolean ValidaNumFactExt(String NumFactExt)
        {
            if (NumFactExt.Length >= 1 && NumFactExt.Length <= 36)
            {
                return true;
            }
            return false;
        }
        public static Boolean ValidaCFD_CBB_Serie(String cfd_cbb)
        {
            string reg = @"[A-Z]+";

            if (!Regex.IsMatch(cfd_cbb, reg))
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaCFD_CBB_NumFol(int cfd_cbb_folio)
        {
            string digitos = cfd_cbb_folio.ToString();

            if (digitos.Length >= 1 && digitos.Length <= 20)
            {
                return true;
            }
            return false;
        }
        public static Boolean ValidaNumeroCuenta1_100(String cta)
        {
            if (cta.Trim().Length < 1 || cta.Trim().Length > 100)
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaConcepto1_300(String numeroPoliza)
        {
            if (numeroPoliza.Trim().Length < 1 || numeroPoliza.Trim().Length > 50)
                return false;
            return true;
        }
        public static Boolean ValidaConceptoTransaccion1_200(String conceptoTransaccion)
        {
            if (conceptoTransaccion.Trim().Length < 1 || conceptoTransaccion.Trim().Length > 200)
                return false;
            return true;
        }
        public static Boolean ValidaMoneda(String moneda)
        {
            string reg = @"[A-Z]{3}";

            if (!Regex.IsMatch(moneda, reg))
            {
                return false;
            }
            return true;
        }
        public static Boolean ValidaTipoCambio(double tipoCambio)
        {
            String tipoCambio2 = tipoCambio.ToString();
            /*
             *  Dígitos Totales 19
                Valor Mínimo Incluyente 0
                Posiciones Decimales 5
             */
            if (tipoCambio2.Replace(".", "").Length > 19)
                return false;
            return true;
        }
        #endregion
        #region remplazo de caracteres especiales
        public static String RemplazarCaracteresEspeciales(String valor)
        {
            return valor.Replace("&", "&amp;").Replace("\"", "&quot;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;");
        }
        public static String ConvertirDineroAString(double dinero)
        {
            return String.Format("{0:0.00}", dinero);
        }
        #endregion
    }
}
