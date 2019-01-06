using Dominio.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladores.Sistema
{
    public class ModulosSistemaController
    {
        public Dictionary<String, List<String>> CargarModulosPorUsuarioUsandoLicencia(_sis_Usuario usuario, sis_Licencia licencia)
        {
            Dictionary<String, List<String>> modulosFormas = new Dictionary<string, List<String>>();

            if (usuario.Oo_rol == null)
            {
                return null;
            }

            if (usuario.Oo_rol.Ll_modulosAcceso != null)
            {
                foreach (_sis_ModuloSistemaPermiso modulo in usuario.Oo_rol.Ll_modulosAcceso)
                {
                    if (licencia.ModulosPermitidos.Contains(modulo.St_nombre))
                    {
                        List<String> formasAcceso = modulo.St_listaFormasAcceso.Split('|').ToList<String>();
                        modulosFormas.Add(modulo.St_nombre, formasAcceso);
                    }
                }
            }
            else
            {
                return null;
            }
            return modulosFormas;
        }
        public Dictionary<String, List<String>> CargarModulosGenerales()
        {
            Dictionary<String, List<String>> modulosConfiguracionGeneral = new Dictionary<string, List<string>>();
            //modulo Catálogos
            List<String> formasAcceso = new List<string>();
            //los primeros dos digitos #01 es el paquete al que pertenece por ejemplo "basico", los siguientes digitos son
            //el identificador de la ventana 001
            formasAcceso.Add("#01001|forma.xaml|Catalogo de meseros");
            formasAcceso.Add("#02001|forma.xaml|Catalogo de meseros"); //misma ventana trasladada al paquete 2
            formasAcceso.Add("#01002|forma.xaml|Catalogo de platillos");
            //los digitos $01 pertenece al identificador del modulo
            modulosConfiguracionGeneral.Add("$01|Catálogos", formasAcceso);
            //se seguiran agregando modulos con sus respectivas formas y paquetes
            modulosConfiguracionGeneral.Add("$02|Caja", formasAcceso); //por ejemplo este es el modulo 2

            return modulosConfiguracionGeneral;
        }
        public Dictionary<String, List<String>> CargarModulosDisponiblesDeAcuerdoLicenciaParaSeleccion(sis_Licencia licencia)
        {
            Dictionary<String, List<String>> modulosConfiguracionGeneral = CargarModulosGenerales();
            Dictionary<String, List<String>> modulosConfiguracionPaqueteComprado = new Dictionary<string, List<string>>();
            

            //de acuerdo a la licencia del cliente se obtienen los modulos y paquetes disponibles
            foreach (String modulo in modulosConfiguracionGeneral.Keys)
            {
                //filtrando solo a los modulos permitidos que el cliente compro
                if (licencia.ModulosPermitidos.Contains(modulo.Split('|')[0]))
                {
                    //ahora filtrando las formas de acuerdo al paquete comprado
                    List<String> formasDelPaqueteComprado = new List<string>();
                    foreach (String forma in modulosConfiguracionGeneral[modulo])
                    {
                        if (forma.StartsWith(licencia.PaqueteComprado))
                        {
                            formasDelPaqueteComprado.Add(forma);
                        }
                    }
                    if (formasDelPaqueteComprado.Count > 0)
                    {
                        modulosConfiguracionPaqueteComprado.Add(modulo, formasDelPaqueteComprado);
                    }
                }
            }

            //retornamos los accesos permitidos comprados
            return modulosConfiguracionPaqueteComprado;

        }
    }
}
