using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Sistema;
using Dominio;
using Herramientas.Cifrado;
using System.Drawing;
using System.Data;
using Herramientas.ORM;

namespace LogicaNegocios.Sistema
{
    public class sis_ln_Login : LogicaNegociosBase
    {
        private ManejadorDB manejador = new ManejadorDB();
        public _sis_Usuario ValidarAcceso(String prmUsuario, String prmContrasena)
        {
            try
            {
                manejador.UsarAlmacenObjetos = false;
                _sis_Usuario usuario = manejador.Cargar<_sis_Usuario>(_sis_Usuario.consultaPorUsuarioYContra, new List<object>() { prmUsuario, CifradoAES.EncriptarTexto(prmContrasena) });
                if (usuario != null)
                {
                    if (!usuario.Cuenta.Equals("administrador") && usuario.BEstaDesactivado)
                    {
                        MT_EnviarMensaje("La cuenta se encuentra bloqueada.","Bloqueo de cuenta", MensajeException.TipoMensaje.Advertencia);
                        return null;
                    }
                }
                else
                {
                    MT_EnviarMensaje("Usuario o contraseña incorrecto.", "", MensajeException.TipoMensaje.ErrorSimple);
                    return null;
                }
                return usuario;
            }
            catch (Exception ex)
            {
                MT_EnviarMensaje(ex,ex.Message,"Error", MensajeException.TipoMensaje.Error);
                return null;
            }
        }
        public void VerificarExistenciaDeUsuarioAdmin()
        {
            DataTable cantidadUsuariosAdministradores = manejador.EjecutarConsulta(_sis_Usuario.consultaCantidadDeUsuariosAdministradores, new List<object>() { true });
            DataTable cantidadUsuarios = manejador.EjecutarConsulta(_sis_Usuario.consultaCantidadDeUsuarios);
            if (Convert.ToInt32(cantidadUsuariosAdministradores.Rows[0][0]) == 0)
            {
                //creacion del primer usuario como administrador
                if (Convert.ToInt32(cantidadUsuarios.Rows[0][0]) == 0)
                {
                    _sis_Usuario administrador = new _sis_Usuario();
                    administrador.EsModificado = true;
                    administrador.EsAdministradorDeSistema = true;

                    administrador.SNombreCompleto = "Administrador inicial del sistema";
                    administrador.Cuenta = "administrador";
                    administrador.Contrasena = Herramientas.Cifrado.CifradoAES.EncriptarTexto("12345");

                    manejador.Guardar(administrador);

                    MT_EnviarMensaje("El Sistema ha detectado que no existen usuarios registrados en la base de datos, Por lo que fue creado el primer usuario como administrador", "ATENCION", MensajeException.TipoMensaje.Advertencia);
                    MT_EnviarMensaje("A continuación se darán los datos del administrador. Favor de anotarlos.", "ATENCION", MensajeException.TipoMensaje.Advertencia);
                    MT_EnviarMensaje("Usuario: " + administrador.Cuenta + "\nContraseña: " + Herramientas.Cifrado.CifradoAES.DesencriptarTexto(administrador.Contrasena), "ATENCION", MensajeException.TipoMensaje.Advertencia);
                    return;
                }
                else
                {
                    _sis_Usuario administrador = manejador.Cargar<_sis_Usuario>(_sis_Usuario.consultaPorCuenta, new List<object>() { "administrador" });
                    if (administrador == null) administrador = new _sis_Usuario();
                    administrador.EsModificado = true;
                    administrador.EsAdministradorDeSistema = true;

                    administrador.SNombreCompleto = "Administrador inicial del sistema";
                    administrador.Cuenta = "administrador";
                    administrador.Contrasena = Herramientas.Cifrado.CifradoAES.EncriptarTexto("12345");

                    manejador.Guardar(administrador);
                    MT_EnviarMensaje("El Sistema ha detectado que no existen administradores actualmente en el sistema. Por lo que fue restaurado el primer usuario administrador", "ATENCION", MensajeException.TipoMensaje.Advertencia);
                    MT_EnviarMensaje("A continuación se darán los datos del administrador. Favor de anotarlos.", "ATENCION", MensajeException.TipoMensaje.Advertencia);
                    MT_EnviarMensaje("Usuario: " + administrador.Cuenta + ", contraseña: " + Herramientas.Cifrado.CifradoAES.DesencriptarTexto(administrador.Contrasena), "ATENCION", MensajeException.TipoMensaje.Advertencia);
                    return;
                }
            }
        }
    }
}
