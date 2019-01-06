using CuentasParaPagar.AcercaDe;
using CuentasParaPagar.Catalogos;
using CuentasParaPagar.Consultas;
using CuentasParaPagar.Operaciones;
using Dominio;
using Herramientas.Archivos;
using Herramientas.Mail;
using Herramientas.ORM;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuentasParaPagar
{
    public partial class Principal : Form
    {
        iSQL sql; //este de aqui es un objeto de tipo interface, el no conoce el tipo de base de datos que sera de forma concreta...
        ManejadorDB manejador;
        List<_Cuenta> cuentas = null;
        String emails;
        public Principal()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            Variable var = new Variable("configuracion.conf");
            emails = var.ObtenerValorVariable<String>("EMAILS");

            Text = "CIC - Control Inteligente de Cuentas (Versión 20150901)";
            try
            {
                sql = new SQLite();
                sql.ConfigurarConexion("CuentasPagar.db", false);

                //sql = new MySQL();
                //sql.ConfigurarConexion("127.0.0.1", "nueva", "sa", "12345");

                manejador = new ManejadorDB(sql);
            }
            catch (Exception ex)
            {
                GenerarEstructuraDeBD();
            }
            //sql = new SQLServer();
            //sql.ConfigurarConexion(@"192.168.140.126\crop", "test", "sa", "1@TCE123");
            manejador.UsarAlmacenObjetos = true;
            ActualizarSaldos();
            contenedorCuentasMovimientosFuturos1.actualizarSaldosEvento += contenedorCuentasMovimientosFuturos1_actualizarSaldosEvento;


        }

        void contenedorCuentasMovimientosFuturos1_actualizarSaldosEvento()
        {
            CargarCuentas();
            contenedorSaldosAlDiaCuentas1.CargarCuentas(cuentas);
            contenedorCuentasMovimientosFuturos1.CargarCuentas(cuentas);
        }
        private void agregarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogoCuentas cat = new CatalogoCuentas(sql);
            cat.ShowDialog();
            contenedorCuentasMovimientosFuturos1_actualizarSaldosEvento();
        }

        private void registrarUnMovimientoAUnaCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarMovimiento reg = new RegistrarMovimiento(sql, false, null);
            reg.ShowDialog();
            contenedorCuentasMovimientosFuturos1_actualizarSaldosEvento();
        }

        private void historialDeMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorialDeMovimientos his = new HistorialDeMovimientos(sql, null);
            his.ShowDialog();
        }

        private void tiposDeMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogoTipoMovimiento mov = new CatalogoTipoMovimiento(sql);
            mov.ShowDialog();
            contenedorCuentasMovimientosFuturos1_actualizarSaldosEvento();
        }
        private void CargarCuentas()
        {
            cuentas = manejador.CargarLista<_Cuenta>("select * from _Cuenta where estaDeshabilitado = 'False'");

        }
        private void ActualizarSaldos()
        {
            CargarCuentas();
            if (cuentas != null)
                foreach (_Cuenta cuenta in cuentas)
                {
                    if (cuenta.Ll_Movimientos != null)
                    {
                        double multiplicadorCuenta = 1;
                        if (cuenta.Bo_EsDeAhorro)
                            multiplicadorCuenta = -1;
                        foreach (_MovimientoCuenta movimiento in cuenta.Ll_Movimientos)
                        {
                            if (new DateTime(movimiento.Dt_fechaAplicacion.Year, movimiento.Dt_fechaAplicacion.Month, movimiento.Dt_fechaAplicacion.Day) <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) && movimiento.Do_Saldo == 0)
                            {
                                movimiento.EsModificado = true;
                                cuenta.EsModificado = true;
                                movimiento.Bo_EstaAplicadoAlSaldo = true;
                                movimiento.Do_Saldo += cuenta.Do_saldo + (movimiento.Do_Importe * movimiento.Oo_TipoMovimiento.Do_MultiplicadorSigno * multiplicadorCuenta);
                                cuenta.Do_saldo = movimiento.Do_Saldo;
                            }
                        }
                    }

                    if (cuenta.Ll_MovimientosSimulados != null)
                    {
                        List<_MovimientoCuenta> movimientosAEliminar = new List<_MovimientoCuenta>();
                        foreach (_MovimientoCuenta movimiento in cuenta.Ll_MovimientosSimulados)
                        {
                            //movimiento.EsModificado = true;
                            //movimiento.Do_Saldo = 0;
                            if (new DateTime(movimiento.Dt_fechaAplicacion.Year, movimiento.Dt_fechaAplicacion.Month, movimiento.Dt_fechaAplicacion.Day) < new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                            {
                                movimientosAEliminar.Add(movimiento);
                            }
                        }

                        foreach (_MovimientoCuenta movimiento in movimientosAEliminar)
                        {
                            cuenta.EsModificado = true;
                            cuenta.Ll_MovimientosSimulados.Remove(movimiento);
                        }

                    }

                    //cuenta.Ll_Movimientos = null;
                    manejador.Guardar(cuenta);
                }
            contenedorCuentasMovimientosFuturos1_actualizarSaldosEvento();
        }

        private void proyecciónFuturaDeMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyeccionFutura fut = new ProyeccionFutura(sql, null);
            fut.ShowDialog();
            contenedorCuentasMovimientosFuturos1_actualizarSaldosEvento();
        }

        private void enviarUnCorreoAlDesarrolladorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnviarCorreo enviar = new EnviarCorreo();
            enviar.ShowDialog();
        }

        private void GenerarEstructuraDeBD()
        {
            #region query generacion
            try
            {
                String queryGeneracion = @"
                    CREATE TABLE _Cuenta
                    ( id integer PRIMARY KEY ASC AUTOINCREMENT, dtFechaCreacion datetime , dtFechaModificacion datetime , sUsuarioCreacion text , sUsuarioModificacion text , estaDeshabilitado boolean DEFAULT 0, _st_NombreCuenta text , _bm_Imagen blob , _in_DiasParaPago integer , _in_DiaCorte integer , _do_PorcentajeInteresMensual real , _do_saldo real , _bo_EsDeAhorro boolean)
                    |
                    CREATE TABLE _MovimientoCuenta
                    ( id integer PRIMARY KEY ASC AUTOINCREMENT, dtFechaCreacion datetime , dtFechaModificacion datetime , sUsuarioCreacion text , sUsuarioModificacion text , estaDeshabilitado boolean DEFAULT 0, _do_Importe real , _do_Saldo real , _dt_fecha datetime , _dt_fechaAplicacion datetime , _st_detalleMovimiento text , _oo_Cuenta integer REFERENCES _Cuenta(id), _oo_TipoMovimiento integer REFERENCES _TipoMovimiento(id), _bo_EsSimulado boolean, _bo_EstaAplicadoAlSaldo boolean, _oo_MovimientoPareja integer REFERENCES _MovimientoCuenta(id))
                    |
                    CREATE TABLE _TipoMovimiento
                    ( id integer PRIMARY KEY ASC AUTOINCREMENT, dtFechaCreacion datetime , dtFechaModificacion datetime , sUsuarioCreacion text , sUsuarioModificacion text , estaDeshabilitado boolean DEFAULT 0, _st_Nombre text , _st_Tipo text , _do_MultiplicadorSigno real , _bo_SeDivideEnMultiplesPagos boolean, _bo_SeAplicaInmediato boolean)
                    |
                    CREATE TABLE _Cuenta_X__MovimientoCuenta__ll_Movimientos
                    ( _fecha datetime
                    , _contenido integer REFERENCES _MovimientoCuenta(id), _contenedor integer REFERENCES _Cuenta(id))
                    |
                    CREATE TABLE _Cuenta_X__MovimientoCuenta__ll_MovimientosSimulados
                    ( _fecha datetime
                    , _contenido integer REFERENCES _MovimientoCuenta(id), _contenedor integer REFERENCES _Cuenta(id))

                    |    
                    CREATE INDEX ci__Cuenta_X__MovimientoCuenta__ll_Movimientos_contenedor_fecha ON _Cuenta_X__MovimientoCuenta__ll_Movimientos (_contenedor, _fecha)
                    |
                    CREATE INDEX nci__MovimientoCuenta__oo_TipoMovimiento ON _MovimientoCuenta ('_oo_TipoMovimiento' ASC)
                    |
                    CREATE INDEX nci__MovimientoCuenta__oo_MovimientoPareja ON _MovimientoCuenta ('_oo_MovimientoPareja' ASC)
                    |
                    CREATE INDEX nci__MovimientoCuenta__oo_Cuenta ON _MovimientoCuenta ('_oo_Cuenta' ASC)
                    |
                    CREATE INDEX ci__Cuenta_X__MovimientoCuenta__ll_MovimientosSimulados_contenedor_fecha ON _Cuenta_X__MovimientoCuenta__ll_MovimientosSimulados (_contenedor, _fecha)
                    ";
            #endregion

                sql.ConfigurarConexion("CuentasPagar.db", true);

                String[] querys = queryGeneracion.Split('|');
                sql.IniciarTransaccion();
                foreach (String query in querys)
                {
                    String q = query.Trim();
                    sql.EjecutarConsulta(q);
                }
                sql.TerminarTransaccion();
                sql.ConfigurarConexion("CuentasPagar.db", false);
                manejador = new ManejadorDB(sql);
                Herramientas.Forms.Mensajes.Informacion("Se generó la Base de datos con éxito.");
            }
            catch (Exception ex)
            {
                sql.DeshacerTransaccion();
                Herramientas.Forms.Mensajes.Error(ex.Message);

            }

        }

        private void desarrolladoPorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesarrolladoPor des = new DesarrolladoPor();
            des.ShowDialog();
        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            contenedorCuentasMovimientosFuturos1.AjustarTama();
        }

        private void enviarAlCorreoUnRespaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (emails.Trim().Equals(""))
                {
                    Herramientas.Forms.Mensajes.Exclamacion("Debe de registrar al menos un correo válido en el archivo 'Configuracion.conf' del programa.");
                    return;
                }
                Herramientas.Forms.Mensajes.Advertencia("Se hará un respaldo de la bd en su correo, no cierre el programa hasta que se le indique.");
                RespaldarAlCorreoLaBD();
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error("Error al enviar el correo de respaldo: " + ex.Message);
            }
        }
        private void RespaldarAlCorreoLaBD()
        {
            String nombreArchivo = "CuentasPagar_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".db";
            Herramientas.Archivos.Archivo.CopiarArchivo(Environment.CurrentDirectory + "\\CuentasPagar.db", Environment.CurrentDirectory + "\\" + nombreArchivo);

            Adjunto adj = new Adjunto();
            adj.NombreArchivo = nombreArchivo;
            adj.Tipo = Adjunto.TipoAdjunto.OTRO;
            adj.Stream = Herramientas.Archivos.Archivo.CargarArchivoAMemoria(Environment.CurrentDirectory + "\\" + nombreArchivo);

            Gmail gmail = new Gmail();
            gmail.EmailUsar = "cic.control.cuentas@gmail.com";
            gmail.ContrasenaUsar = "cic.control.cuentas1";
            gmail.EmailDestino = emails.Trim();
            gmail.ContenidoHTML = @"<h1>Correo de respaldo de BD</h1>

<p>Este correo fue enviado por <strong>CIC</strong>, su objetivo es que tengas en tu correo un respaldo de tu BD de cuentas y en cualquier problema puedas recuperar tu informaci&oacute;n.</p>

<p>El archivo adjunto es la BD, para instalarla en el sistema solo debes quitar los n&uacute;meros hasta que su nombre sea &quot;<em>CuentasPagar.db</em>&quot;.</p>

<p>Cualquier problema responder a este correo.</p>

<p>Saludos!</p>";
            gmail.Asunto = "Correo de respaldo CIC";
            gmail.NombreAMostrar = "CIC - Control Inteligente de Cuentas";
            gmail.ArchivosAdjuntos = new List<Adjunto>();
            gmail.ArchivosAdjuntos.Add(adj);
            gmail.EnviarCorreo(Gmail.Prioridad.Normal);

            Herramientas.Archivos.Archivo.EliminarArchivo(Environment.CurrentDirectory + "\\" + nombreArchivo);
            Herramientas.Forms.Mensajes.Informacion("Email enviado correctamente.");
        }

    }
}
