using Herramientas;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class CatalogoCuenta
    {
        public static String Formato;
        public int ID { get; set; }
        public String CodAgrup { get; set; }
        public String NumCuenta { get; set; }
        public String Descripcion { get; set; }
        public String SubCtaDe { get; set; }
        public int Nivel { get; set; }
        public char Naturaleza { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@CodAgrup", CodAgrup);
            xmlFinal = xmlFinal.Replace("@NumCta", NumCuenta);
            xmlFinal = xmlFinal.Replace("@Descripcion", Descripcion);
            
            xmlFinal = xmlFinal.Replace("@Nivel", Nivel.ToString());
            if (Nivel == 1)
            {
                xmlFinal = xmlFinal.Replace("SubCtaDe=\"@SubCtaDe\"", "");
            }
            else
            {
                xmlFinal = xmlFinal.Replace("@SubCtaDe", SubCtaDe);
            }
            xmlFinal = xmlFinal.Replace("@Naturaleza", Naturaleza.ToString());

            return xmlFinal;

        }
        public String ValidarDatos()
        {
            String resultado = "";
            if (!Validaciones.ValidaCodAgrupador(CodAgrup))
                resultado += "Código agrupador, ";
            if (!Validaciones.ValidaNumCuenta(NumCuenta))
                resultado += "NumCuenta, ";
            if (!Validaciones.ValidaDescripcion1_200(Descripcion))
                resultado += "Descripción, ";
            if (!Validaciones.ValidaSubCuentaDe1_100(SubCtaDe))
                resultado += "SubCtaDe, ";
            if (!Validaciones.ValidaNaturaleza(Naturaleza))
                resultado += "Naturaleza, ";
            if (Nivel < 1)
                resultado += "Nivel, ";
            if (resultado.Length > 0)
                resultado = resultado.Substring(0, resultado.Length - 2);
            return resultado;
        }


        public void Guardar(iSQL sql)
        {
            String query = "";
            List<Object> valores = new List<object>();
            if (ID == 0)
            {
                query = "insert empresas..ctl_cuentas_contables_sat (CodAgrup, NumCta, Descripcion, SubCtaDe, Nivel, Naturaleza) values (@CodAgrup, @NumCta, @Descripcion, @SubCtaDe, @Nivel, @Naturaleza)";
                valores.Add(CodAgrup);
                valores.Add(NumCuenta);
                valores.Add(Descripcion);
                valores.Add(SubCtaDe);
                valores.Add(Nivel);
                valores.Add(Naturaleza);
            }
            else
            {
                query = "update empresas..ctl_cuentas_contables_sat set CodAgrup = @CodAgrup, NumCta = @NumCta, Descripcion = @Descripcion, SubCtaDe = @SubCtaDe, Nivel = @Nivel, Naturaleza = @Naturaleza where id = @id";
                valores.Add(CodAgrup);
                valores.Add(NumCuenta);
                valores.Add(Descripcion);
                valores.Add(SubCtaDe);
                valores.Add(Nivel);
                valores.Add(Naturaleza);
                valores.Add(ID);
            }

            sql.EjecutarConsulta(query, valores);
        }

    }
}
