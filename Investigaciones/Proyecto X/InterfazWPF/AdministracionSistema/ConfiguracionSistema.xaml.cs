using Dominio;
using Dominio.Sistema;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Herramientas.ORM;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para ConfiguracionSistema.xaml
    /// </summary>
    public partial class ConfiguracionSistema : Window
    {
        Assembly assem = Assembly.GetExecutingAssembly();
        List<_sis_Formulario> formulariosRegistrados = new List<_sis_Formulario>();
        ManejadorDB manejador;
        private _sis_Formulario formulario;
        private _sis_Contenedor ContenedorTemporal;
        private _sis_Contenedor ContenedorSeleccionado;
        private List<_sis_Contenedor> historial = new List<_sis_Contenedor>();
        private _sis_Contenedor ContenedorPadreRol = null;
        private _sis_Rol rol;
        private _sis_Usuario usuario;
        public ConfiguracionSistema()
        {
            InitializeComponent();
            try
            {
                manejador = new ManejadorDB();
                InicializarEventos();
                CargarIniciales();

            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Ocurrio un error: " + ex.Message, "Error al iniciar el formulario");
            }
        }
        private void InicializarEventos()
        {
            HerramientasWindow.AgregarEventoCambiarImagen(img_imagenFondoLogin);
            HerramientasWindow.AgregarEventoCambiarImagen(img_imagenFondoSistema);
            HerramientasWindow.AgregarEventoCambiarImagen(img_imagenFormulario);
            HerramientasWindow.AgregarEventoCambiarImagen(img_imagenIcono);
            HerramientasWindow.AgregarEventoCambiarImagen(img_rolImagenCarpeta);
            HerramientasWindow.AgregarEventoCambiarImagen(img_rolImagenRol);
            HerramientasWindow.AgregarEventoCambiarImagen(img_usuarioImagenUsuario);
        }
        private void CargarIniciales()
        {
            CargarFormularios(true);
            CargarRoles();
            CargarUsuarios();
            CargarApariencia();
        }

        private void toolbox_Guardar()
        {
            TabItem tabitem = (TabItem)tc_opciones.SelectedItem;
            if (tabitem.Header.Equals("Creación y configuración de roles"))
            {
                if (txt_rolNombreRol.Text.Equals(""))
                {
                    HerramientasWindow.MensajeInformacion("Se requiere un nombre de rol para poder guardar.", "Dato requerido");
                    return;
                }
                if (rol == null) rol = new _sis_Rol();
                rol.Nombre = txt_rolNombreRol.Text;
                if (rol.ImagenAsociada == null) rol.ImagenAsociada = new _sis_ImagenAsociada();
                rol.ImagenAsociada.Imagen = HerramientasWindow.ObtenerBitmapDeImageControl(img_rolImagenRol, HerramientasWindow.FormatoImagen.PNG);

                if (rol.ImagenAsociada.Imagen != null)
                    rol.ImagenAsociada.EsModificado = true;

                rol.EsModificado = true;
                rol.BPuedeAccederCatalogoRapido = (Boolean)chb_RolPuedeAccederACatalogoRapido.IsChecked;
                rol.EsAdministradorDeSistema = (bool)chb_rolEsAdministrador.IsChecked;
                if (ContenedorPadreRol != null)
                    rol.Contenedores = ContenedorPadreRol.Contenedores;
                try
                {
                    manejador.IniciarTransaccion();
                    if (manejador.Guardar(rol) != 0)
                    {
                        manejador.GuardarObjetosModificados();
                        manejador.TerminarTransaccion();
                        HerramientasWindow.MensajeInformacion("Se guardó el rol con éxito.", "Guardado Exitoso");
                    }
                    LimpiarDatosRoles();
                }
                catch (Exception ex) { manejador.DeshacerTransaccion(); HerramientasWindow.MensajeError(ex, "Ocurrió un error al guardar: " + ex.Message, "Error"); return; }
                CargarRoles();
            }
            else if (tabitem.Header.Equals("Registro de formularios"))
            {
                if (txt_formulariosReferenciaFormulario.Text.Equals(""))
                {
                    HerramientasWindow.MensajeInformacion("Se requiere un formulario de referencia para poder guardar.", "Dato requerido");
                    return;
                }
                if (txt_formulariosNombreEnSistema.Text.Equals(""))
                {
                    HerramientasWindow.MensajeInformacion("Se requiere un nombre de formulario para poder guardar.", "Dato requerido");
                    return;
                }

                if (formulario == null) formulario = new _sis_Formulario();
                formulario.EsModificado = true;

                formulario.STituloFormulario = txt_formulariosNombreEnSistema.Text;
                formulario.SReferenciaFormulario = txt_formulariosReferenciaFormulario.Text;
                formulario.BPermiteMultiples = (bool)chb_formulariosPermiteDuplicados.IsChecked;
                formulario.SDescripcion = txt_formulariosDescripcionEnSistema.Text;
                if (formulario.ImagenAsociada == null) formulario.ImagenAsociada = new _sis_ImagenAsociada();
                formulario.ImagenAsociada.Imagen = HerramientasWindow.ObtenerBitmapDeImageControl(img_imagenFormulario, HerramientasWindow.FormatoImagen.PNG);

                if (formulario.ImagenAsociada.Imagen != null)
                    formulario.ImagenAsociada.EsModificado = true;

                try
                {
                    manejador.IniciarTransaccion();
                    if (manejador.Guardar(formulario) != 0)
                    {
                        manejador.TerminarTransaccion();
                        HerramientasWindow.MensajeInformacion("Se guardó el formulario con éxito.", "Guardado Exitoso");
                        CargarFormularios(true);
                    }
                }
                catch (Exception ex) { manejador.DeshacerTransaccion(); HerramientasWindow.MensajeError(ex, "Ocurrió un error al guardar: " + ex.Message, "Error"); return; }
                formulario = null;
                LimpiarDatosFormulario();
                cmb_filtroFormularios.SelectedIndex = -1;
            }
            else if (tabitem.Header.Equals("Registro de usuarios"))
            {
                if (!txt_usuarioContraseñaUsuario.Password.Trim().Equals(""))
                {
                    if (!txt_usuarioContraseñaUsuario.Password.Trim().Equals(txt_usuarioContraseñaConfirmacionUsuario.Password))
                    {
                        HerramientasWindow.MensajeInformacion("La contraseña y su confirmación no coinciden.", "Error en contraseña");
                        return;
                    }
                }

                if (txt_usuarioCuentaUsuario.Text.Trim().Equals(""))
                {
                    HerramientasWindow.MensajeInformacion("El usuario debe tener una cuenta de usuario.", "Dato requerido");
                    return;
                }
                if (txt_usuarioNombreUsuario.Text.Trim().Equals(""))
                {
                    HerramientasWindow.MensajeInformacion("El usuario debe tener una Nombre de usuario.", "Dato requerido");
                    return;
                }
                if (usuario == null) usuario = new _sis_Usuario();
                usuario.BEstaDesactivado = (bool)chb_usuariosEstaDesactivada.IsChecked;
                usuario.Cuenta = txt_usuarioCuentaUsuario.Text;
                if (!txt_usuarioContraseñaUsuario.Password.Trim().Equals(""))
                    usuario.Contrasena = HerramientasWindow.EncriptarConAES(txt_usuarioContraseñaUsuario.Password);
                if (usuario.ImagenAsociada == null) usuario.ImagenAsociada = new _sis_ImagenAsociada();
                usuario.ImagenAsociada.Imagen = HerramientasWindow.ComprimirImagen(HerramientasWindow.ObtenerBitmapDeImageControl(img_usuarioImagenUsuario, HerramientasWindow.FormatoImagen.JPEG), 128, 128, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (usuario.ImagenAsociada.Imagen != null)
                    usuario.ImagenAsociada.EsModificado = true;
                usuario.SEmail = txt_usuarioEmailUsuario.Text;
                usuario.SNombreCompleto = txt_usuarioNombreUsuario.Text;
                usuario.EsModificado = true;
                usuario.BPuedeAccederCatalogoRapido = (Boolean)chb_UsuarioPuedeAccederACatalogoRapido.IsChecked;
                usuario.EsAdministradorDeSistema = (bool)chb_usuariosEsAdministrador.IsChecked;
                usuario.BRecibeVersionesPrueba = (bool)chb_UsuarioRecibeVersionesPrueba.IsChecked;
                usuario.BEsSoporte = (bool)chb_usuariosEsSoporte.IsChecked;
                if (cmb_usuariosRolesEnSistema.SelectedItem != null)
                {
                    _sis_Rol rolSel = manejador.Cargar<_sis_Rol>(_sis_Rol.ConsultaPorNombre, new List<object>() { cmb_usuariosRolesEnSistema.SelectedItem.ToString() });

                    usuario.RolSistema = rolSel;
                }

                try
                {
                    manejador.IniciarTransaccion();
                    if (manejador.Guardar(usuario) != 0)
                    {
                        manejador.TerminarTransaccion();
                        CargarUsuarios();
                        HerramientasWindow.MensajeInformacion("Se guardó el usuario con éxito.", "Guardado Exitoso");

                    }
                }
                catch (Exception ex) { manejador.DeshacerTransaccion(); HerramientasWindow.MensajeError(ex, "Ocurrió un error al guardar: " + ex.Message, "Error"); return; }
                usuario = null;
                LimpiarDatosUsuario();
                CargarUsuarios();

            }
            else if (tabitem.Header.Equals("Configuración de sistema"))
            {
                _sis_DatosSistema datosSistema = manejador.Cargar<_sis_DatosSistema>(_sis_DatosSistema.ConsultaTodos);
                if (datosSistema == null)
                    datosSistema = new _sis_DatosSistema();
                datosSistema.EsModificado = true;

                datosSistema.BImagenFondoLogin = HerramientasWindow.ComprimirImagen(HerramientasWindow.ObtenerBitmapDeImageControl(img_imagenFondoLogin, HerramientasWindow.FormatoImagen.JPEG), 480, 180, System.Drawing.Imaging.ImageFormat.Jpeg);
                datosSistema.BImagenFondoPrincipal = HerramientasWindow.ComprimirImagen(HerramientasWindow.ObtenerBitmapDeImageControl(img_imagenFondoSistema, HerramientasWindow.FormatoImagen.JPEG), 1024, 768, System.Drawing.Imaging.ImageFormat.Jpeg);
                datosSistema.BImagenIcono = HerramientasWindow.ComprimirImagen(HerramientasWindow.ObtenerBitmapDeImageControl(img_imagenIcono, HerramientasWindow.FormatoImagen.PNG), 128, 128, System.Drawing.Imaging.ImageFormat.Png);
                datosSistema.STitulo = txt_nombreSistema.Text;

                datosSistema.BUsarProteccionDeCuentasEnLogin = (Boolean)chb_proteccionSistemaLogin.IsChecked;

                if (!txt_sistemaTiempoAutobloqueo.Text.Trim().Equals(""))
                    datosSistema.ISegundosAutobloqueo = Convert.ToInt32(txt_sistemaTiempoAutobloqueo.Text);
                if (!txt_sistemaTiempoAlmacenObjetos.Text.Trim().Equals(""))
                    datosSistema.ISegundosParaAlmacenObjetos = Convert.ToInt32(txt_sistemaTiempoAlmacenObjetos.Text);

                try
                {
                    manejador.IniciarTransaccion();
                    if (manejador.Guardar(datosSistema) != 0)
                    {
                        manejador.TerminarTransaccion();
                        HerramientasWindow.MensajeInformacion("Se guardó la configuración con éxito.", "Guardado Exitoso");

                    }
                }
                catch (Exception ex) { manejador.DeshacerTransaccion(); HerramientasWindow.MensajeError(ex, "Ocurrió un error al guardar: " + ex.Message, "Error"); return; }

            }
        }
        private void toolbox_Nuevo()
        {
            TabItem tabitem = (TabItem)tc_opciones.SelectedItem;
            if (tabitem.Header.Equals("Creación y configuración de roles"))
            {
                ContenedorTemporal = new _sis_Contenedor();
                LimpiarDatosRoles();
                rol = null;
            }
            else if (tabitem.Header.Equals("Registro de formularios"))
            {
                LimpiarDatosFormulario();
                formulario = null;
                cmb_filtroFormularios.SelectedIndex = -1;
            }
            else if (tabitem.Header.Equals("Registro de usuarios"))
            {
                LimpiarDatosUsuario();
                usuario = null;
            }
        }
        private void toolbox_Eliminar()
        {
            TabItem tabitem = (TabItem)tc_opciones.SelectedItem;
            if (tabitem.Header.Equals("Creación y configuración de roles"))
            {
                if (rol != null)
                {
                    if (HerramientasWindow.MensajeSIoNO("Al eliminar un elemento es imposible recuperarlo de nuevo. ¿Desea continuar?", "Eliminación de objeto") && HerramientasWindow.MensajeSIoNOAdvertencia("Está por eliminar el objeto seleccionado, si continúa no podrá recuperarlo después. ¿Desea continuar?", "Advertencia!"))
                    {
                        rol.BorrarObjetoPermanentemente();
                        HerramientasWindow.MensajeInformacion("Se ha borrado con éxito.", "Mensaje");
                        toolbox_Nuevo();
                        CargarIniciales();
                    }
                }
                else
                    HerramientasWindow.MensajeInformacion("Debe seleccionar un rol primero.", "Mensaje");

            }
            else if (tabitem.Header.Equals("Registro de formularios"))
            {
                if (formulario != null)
                {
                    if (HerramientasWindow.MensajeSIoNO("Al eliminar un elemento es imposible recuperarlo de nuevo. ¿Desea continuar?", "Eliminación de objeto") && HerramientasWindow.MensajeSIoNOAdvertencia("Está por eliminar el objeto seleccionado, si continúa no podrá recuperarlo después. ¿Desea continuar?", "Advertencia!"))
                    {
                        formulario.BorrarObjetoPermanentemente();
                        HerramientasWindow.MensajeInformacion("Se ha borrado con éxito.", "Mensaje");
                        toolbox_Nuevo();
                        CargarIniciales();
                        cmb_filtroFormularios.SelectedIndex = -1;
                        BorrarFormulariosPermisosHuerfanos();
                    }
                }
                else
                    HerramientasWindow.MensajeInformacion("Debe seleccionar un formulario primero.", "Mensaje");
            }
            else if (tabitem.Header.Equals("Registro de usuarios"))
            {
                if (usuario != null)
                {
                    if (HerramientasWindow.MensajeSIoNO("Al eliminar un elemento es imposible recuperarlo de nuevo. ¿Desea continuar?", "Eliminación de objeto") && HerramientasWindow.MensajeSIoNOAdvertencia("Está por eliminar el objeto seleccionado, si continúa no podrá recuperarlo después. ¿Desea continuar?", "Advertencia!"))
                    {
                        usuario.BorrarObjetoPermanentemente();
                        HerramientasWindow.MensajeInformacion("Se ha borrado con éxito.", "Mensaje");
                        toolbox_Nuevo();
                        CargarIniciales();
                    }
                }
                else
                    HerramientasWindow.MensajeInformacion("Debe seleccionar un usuario primero.", "Mensaje");
            }
        }

        private void BorrarFormulariosPermisosHuerfanos()
        {
            List<_sis_FormularioPermisosPorRol> todos = manejador.CargarLista<_sis_FormularioPermisosPorRol>(_sis_FormularioPermisosPorRol.ConsultaTodos);

            foreach (_sis_FormularioPermisosPorRol form in todos)
            {
                if (form.Formulario == null)
                    form.BorrarObjetoPermanentemente();
            }

        }

        #region configuracion formularios
        private void CargarFormulariosDeBD()
        {
            formulariosRegistrados = manejador.CargarLista<_sis_Formulario>(_sis_Formulario.consultaTodos);
        }

        private Boolean EstaRegistrado(String referencia)
        {
            if (formulariosRegistrados == null) return false;
            foreach (_sis_Formulario formulario in formulariosRegistrados)
            {
                if (formulario.SReferenciaFormulario.Equals(referencia))
                    return true;
            }
            return false;
        }
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            lb_formulariosListaFormularios.Items.Clear();


            if (cmb_filtroFormularios.SelectedItem == null) return;
            if (((TextBlock)cmb_filtroFormularios.SelectedItem).Text.Equals("Sin registrar"))
            {
                LimpiarDatosFormulario();
                CargarFormulariosDeBD();
                Type[] tipos = assem.GetTypes();
                foreach (Type tipo in tipos)
                {
                    if (tipo.Name.ToLower().StartsWith("win_"))
                    {
                        if (!EstaRegistrado(tipo.FullName))
                            lb_formulariosListaFormularios.Items.Add(tipo.FullName);
                    }
                }
            }
            else
            {
                LimpiarDatosFormulario();
                CargarFormularios(false);
            }
        }
        private void CargarFormularios(Boolean paraRoles)
        {
            CargarFormulariosDeBD();
            lb_rolFormulariosRegistrados.Items.Clear();
            lb_usuariosFormulariosRegistrados.Items.Clear();
            if (formulariosRegistrados != null)
                foreach (_sis_Formulario formulario in formulariosRegistrados)
                {
                    if (!paraRoles)
                        lb_formulariosListaFormularios.Items.Add(formulario.STituloFormulario);
                    lb_rolFormulariosRegistrados.Items.Add(formulario.STituloFormulario);
                    lb_usuariosFormulariosRegistrados.Items.Add(formulario.STituloFormulario);
                }
        }

        private void btn_formulariosSeleccionar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lb_formulariosListaFormularios.SelectedItem != null)
            {
                TextBlock elegido = (TextBlock)cmb_filtroFormularios.SelectedItem;
                if (elegido == null) return;
                if (elegido.Text.Equals("Registrados"))
                {
                    String tituloFormulario = lb_formulariosListaFormularios.SelectedItem.ToString();

                    formulario = manejador.Cargar<_sis_Formulario>(_sis_Formulario.consultaPorTitulo, new List<object>() { tituloFormulario });

                    txt_formulariosNombreEnSistema.Text = formulario.STituloFormulario;
                    txt_formulariosReferenciaFormulario.Text = formulario.SReferenciaFormulario;
                    chb_formulariosPermiteDuplicados.IsChecked = formulario.BPermiteMultiples;
                    if (formulario.ImagenAsociada != null && formulario.ImagenAsociada.Imagen != null)
                        img_imagenFormulario.Source = HerramientasWindow.BitmapAImageSource(formulario.ImagenAsociada.Imagen);
                }
                else
                {
                    formulario = null;
                    txt_formulariosReferenciaFormulario.Text = lb_formulariosListaFormularios.SelectedItem.ToString();
                }
            }
        }

        public void LimpiarDatosFormulario()
        {
            txt_formulariosNombreEnSistema.Text = "";
            txt_formulariosReferenciaFormulario.Text = "";
            HerramientasWindow.AsignarFondoBlancoImage(img_imagenFormulario);
            lb_formulariosListaFormularios.Items.Clear();
            chb_formulariosPermiteDuplicados.IsChecked = false;
            formulario = null;
        }

        private void btn_formulariosNuevo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LimpiarDatosFormulario();
            formulario = null;
        }
        #endregion
        #region configuracion de roles
        private void btn_EditarPermisosFormulario_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ContenedorSeleccionado == null || ContenedorSeleccionado.FormulariosPermisos == null || lb_rolFormulariosEnCarpeta.SelectedItem == null) return;
            _sis_FormularioPermisosPorRol permisos = ContenedorSeleccionado.FormulariosPermisos[lb_rolFormulariosEnCarpeta.SelectedIndex];


            EditarPermisosFormulario permisosForm = new EditarPermisosFormulario(permisos);
            permisos.EsModificado = true;
            ContenedorSeleccionado.EsModificado = true;
            
            permisosForm.ShowDialog();
            manejador.GuardarAsincrono("", ContenedorSeleccionado);
            manejador.GuardarAsincrono("", permisos);
        }
        private void LimpiarDatosRoles()
        {
            HerramientasWindow.AsignarFondoBlancoImage(img_rolImagenRol);
            txt_rolNombreRol.Text = "";
            txt_rolNombreCarpeta.Text = "";
            txtr_rolDescripcion.Text = "";
            lb_rolCarpetasEnRol.Items.Clear();
            lb_rolFormulariosEnCarpeta.Items.Clear();
            chb_rolEsAdministrador.IsChecked = false;
            chb_RolPuedeAccederACatalogoRapido.IsChecked = false;
            HerramientasWindow.AsignarFondoBlancoImage(img_rolImagenCarpeta);
            ContenedorPadreRol = null;
            ContenedorTemporal = new _sis_Contenedor();
            ContenedorSeleccionado = null;
            rol = null;

        }
        List<_sis_Rol> roles;
        private void CargarRoles()
        {
            roles = manejador.CargarLista<_sis_Rol>(_sis_Rol.ConsultaTodos);
            lb_rolesRolesEnSistema.Items.Clear();
            cmb_usuariosRolesEnSistema.Items.Clear();
            if (roles != null)
                foreach (_sis_Rol rol in roles)
                {
                    lb_rolesRolesEnSistema.Items.Add(rol.Nombre);
                    cmb_usuariosRolesEnSistema.Items.Add(rol.Nombre);
                }
            cmb_usuariosRolesEnSistema.SelectedIndex = -1;
        }
        private void lb_rolCarpetasEnRol_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lb_rolCarpetasEnRol.SelectedItem == null) return;
            String nombre = lb_rolCarpetasEnRol.SelectedItem.ToString();

            txt_rolNombreCarpeta.Text = "";
            img_rolImagenCarpeta.Source = null;

            Boolean noAgregarHistorial = false;
            lb_rolFormulariosEnCarpeta.Items.Clear();
            if (nombre.Equals("Volver..."))
            {
                //if (historial.Count > 0)
                //{
                noAgregarHistorial = true;
                historial.RemoveAt(historial.Count - 1);
                if (historial.Count > 0)
                    ContenedorTemporal = historial[historial.Count - 1];
                else
                {
                    ContenedorTemporal = ContenedorPadreRol;
                }


                //}
            }
            else
            {
                List<_sis_Contenedor> ContenedoresACargar = null;
                ContenedorTemporal = traerContenedorDeArreglo(ContenedorTemporal, nombre);

                ContenedoresACargar = ContenedorTemporal.Contenedores;


            }


            if (!noAgregarHistorial)
                historial.Add(ContenedorTemporal);

            CargarContenedoresDeContenedorTemporal();

        }
        private void llenarFormularios()
        {
            lb_rolFormulariosEnCarpeta.Items.Clear();
            if (ContenedorSeleccionado.FormulariosPermisos != null)
                foreach (_sis_FormularioPermisosPorRol fornm in ContenedorSeleccionado.FormulariosPermisos)
                    if (fornm.Formulario != null)
                        lb_rolFormulariosEnCarpeta.Items.Add(fornm.Formulario.STituloFormulario);
        }
        private void CargarContenedoresDeContenedorTemporal()
        {
            lb_rolCarpetasEnRol.Items.Clear();
            if (ContenedorTemporal.Contenedores != null)
                foreach (_sis_Contenedor conten in ContenedorTemporal.Contenedores)
                    lb_rolCarpetasEnRol.Items.Add(conten.STitulo);
            if (historial.Count > 0)
                lb_rolCarpetasEnRol.Items.Add("Volver...");
        }
        private _sis_Contenedor traerContenedorDeArreglo(_sis_Contenedor contenedorTemp, String nombreCarpeta)
        {
            foreach (_sis_Contenedor contenedor in contenedorTemp.Contenedores)
                if (contenedor.STitulo.Equals(nombreCarpeta))
                    return contenedor;
            return null;
        }

        private void lb_rolCarpetasEnRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_rolCarpetasEnRol.SelectedItem == null) return;
            String sell = lb_rolCarpetasEnRol.SelectedItem.ToString();

            if (!sell.Equals("Volver..."))
            {
                ContenedorSeleccionado = traerContenedorDeArreglo(ContenedorTemporal, sell);
                if (ContenedorSeleccionado.ImagenAsociada != null)
                    img_rolImagenCarpeta.Source = HerramientasWindow.BitmapAImageSource(ContenedorSeleccionado.ImagenAsociada.Imagen);
                txt_rolNombreCarpeta.Text = ContenedorSeleccionado.STitulo;
                llenarFormularios();

            }


        }

        private void EliminarCarpetaYContenido(_sis_Contenedor contenedorRecursivo)
        {
            if (contenedorRecursivo.Contenedores != null)
            {
                foreach (_sis_Contenedor contenedorEnRecursivo in contenedorRecursivo.Contenedores)
                {
                    EliminarCarpetaYContenido(contenedorEnRecursivo);
                }
            }
            if (contenedorRecursivo.FormulariosPermisos != null)
            {
                foreach (_sis_FormularioPermisosPorRol formPermisos in contenedorRecursivo.FormulariosPermisos)
                {
                    formPermisos.BorrarObjetoPermanentemente();
                }
            }
            contenedorRecursivo.BorrarObjetoPermanentemente();
        }

        private void btn_QuitarCarpeta_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lb_rolCarpetasEnRol.SelectedItem == null) return;
            String sell = lb_rolCarpetasEnRol.SelectedItem.ToString();

            if (!sell.Equals("Volver..."))
            {
                if (HerramientasWindow.MensajeSIoNO("Si elimina la carpeta no podrá recuperarla, ¿Desea continuar eliminando la carpeta?", "Atención"))
                {
                    ContenedorSeleccionado = traerContenedorDeArreglo(ContenedorTemporal, sell);
                    ContenedorTemporal.Contenedores.Remove(ContenedorSeleccionado);
                    EliminarCarpetaYContenido(ContenedorSeleccionado);
                    CargarContenedoresDeContenedorTemporal();
                    lb_rolFormulariosEnCarpeta.Items.Clear();
                }
            }

        }
        private void btn_GuardarCarpeta_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ContenedorSeleccionado == null) return;
            if (txt_rolNombreCarpeta.Text.Trim().Equals(""))
            {
                HerramientasWindow.MensajeInformacion("Es necesario nombrar a la carpeta.", "Error al guardar la carpeta");
                return;
            }

            if (ContenedorSeleccionado.Contenedores == null) ContenedorSeleccionado.Contenedores = new List<_sis_Contenedor>();

            _sis_Contenedor contenedorAActualizar = ContenedorSeleccionado;
            contenedorAActualizar.STitulo = txt_rolNombreCarpeta.Text;
            if (contenedorAActualizar.ImagenAsociada == null) contenedorAActualizar.ImagenAsociada = new _sis_ImagenAsociada();
            contenedorAActualizar.ImagenAsociada.Imagen = HerramientasWindow.ObtenerBitmapDeImageControl(img_rolImagenCarpeta, HerramientasWindow.FormatoImagen.PNG);
            if (contenedorAActualizar.ImagenAsociada.Imagen != null)
                contenedorAActualizar.ImagenAsociada.EsModificado = true;
            contenedorAActualizar.EsModificado = true;
            CargarContenedoresDeContenedorTemporal();
        }

        private void btn_gregarCarpeta_MouseDown(object sender, MouseButtonEventArgs e)
        {


            if (txt_rolNombreCarpeta.Text.Trim().Equals(""))
            {
                HerramientasWindow.MensajeInformacion("Es necesario nombrar a la carpeta.", "Error al guardar la carpeta");
                return;
            }
            if (ContenedorTemporal == null) ContenedorTemporal = new _sis_Contenedor();
            if (ContenedorTemporal.Contenedores == null) ContenedorTemporal.Contenedores = new List<_sis_Contenedor>();
            if (ContenedorPadreRol == null) ContenedorPadreRol = ContenedorTemporal;
            _sis_Contenedor contenedorNuevo = new _sis_Contenedor();
            contenedorNuevo.Id = 0;
            contenedorNuevo.STitulo = txt_rolNombreCarpeta.Text;
            contenedorNuevo.ImagenAsociada = new _sis_ImagenAsociada();
            contenedorNuevo.ImagenAsociada.Imagen = HerramientasWindow.ObtenerBitmapDeImageControl(img_rolImagenCarpeta, HerramientasWindow.FormatoImagen.PNG);
            if (contenedorNuevo.ImagenAsociada.Imagen != null)
                contenedorNuevo.ImagenAsociada.EsModificado = true;
            contenedorNuevo.EsModificado = true;
            if (ContenedorTemporal.Contenedores == null) ContenedorTemporal.Contenedores = new List<_sis_Contenedor>();
            ContenedorTemporal.Contenedores.Add(contenedorNuevo);
            ContenedorTemporal.EsModificado = true;
            manejador.Guardar(ContenedorTemporal);

            CargarContenedoresDeContenedorTemporal();
        }

        private void btn_QuitarFormulario_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ContenedorSeleccionado == null || ContenedorSeleccionado.FormulariosPermisos == null || lb_rolFormulariosEnCarpeta.SelectedItem == null) return;
            _sis_FormularioPermisosPorRol aEliminar = ContenedorSeleccionado.FormulariosPermisos[lb_rolFormulariosEnCarpeta.SelectedIndex];
            ContenedorSeleccionado.FormulariosPermisos.Remove(aEliminar);
            aEliminar.BorrarObjetoPermanentemente();
            ActualizarFormulariosEnCarpeta();
        }

        private void btn_AgregarFormulario_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ContenedorSeleccionado == null || lb_rolFormulariosRegistrados.SelectedItem == null) return;

            String nombreFormulario = lb_rolFormulariosRegistrados.SelectedItem.ToString();

            _sis_Formulario formularioSeleccionado = manejador.Cargar<_sis_Formulario>(_sis_Formulario.consultaPorTitulo, new List<object>() { nombreFormulario });
            if (ContenedorSeleccionado.FormulariosPermisos == null) ContenedorSeleccionado.FormulariosPermisos = new List<_sis_FormularioPermisosPorRol>();

            _sis_FormularioPermisosPorRol permisos = new _sis_FormularioPermisosPorRol();
            permisos.EsModificado = true;

            permisos.Formulario = formularioSeleccionado;
            ContenedorSeleccionado.FormulariosPermisos.Add(permisos);
            ContenedorSeleccionado.EsModificado = true;
            ActualizarFormulariosEnCarpeta();
        }
        private void ActualizarFormulariosEnCarpeta()
        {
            if (ContenedorSeleccionado.FormulariosPermisos == null) return;
            lb_rolFormulariosEnCarpeta.Items.Clear();
            foreach (_sis_FormularioPermisosPorRol form in ContenedorSeleccionado.FormulariosPermisos)
            {
                lb_rolFormulariosEnCarpeta.Items.Add(form.Formulario.STituloFormulario);
            }
        }

        private void btn_rolSeleccionar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lb_rolesRolesEnSistema.SelectedItem == null) return;
            String nombre = lb_rolesRolesEnSistema.SelectedItem.ToString();
            rol = manejador.Cargar<_sis_Rol>(_sis_Rol.ConsultaPorNombre, new List<object>() { nombre });

            txt_rolNombreRol.Text = rol.Nombre;
            txtr_rolDescripcion.Text = rol.Descripcion;
            chb_rolEsAdministrador.IsChecked = rol.EsAdministradorDeSistema;
            chb_RolPuedeAccederACatalogoRapido.IsChecked = rol.BPuedeAccederCatalogoRapido;

            if (rol.ImagenAsociada != null)
                img_rolImagenRol.Source = HerramientasWindow.BitmapAImageSource(rol.ImagenAsociada.Imagen);

            lb_rolCarpetasEnRol.Items.Clear();

            if(rol.Contenedores != null)
            foreach (_sis_Contenedor conten in rol.Contenedores)
                lb_rolCarpetasEnRol.Items.Add(conten.STitulo);

            ContenedorPadreRol = new _sis_Contenedor();
            ContenedorTemporal = new _sis_Contenedor();
            ContenedorPadreRol.Contenedores = rol.Contenedores;
            ContenedorTemporal = ContenedorPadreRol;
            historial.Clear();

        }
        #endregion
        #region configuracion usuarios
        private void CargarUsuarios()
        {
            List<_sis_Usuario> usuarios = manejador.CargarLista<_sis_Usuario>(_sis_Usuario.consultaTodos);
            lb_usuariosListaUsuarios.Items.Clear();
            if (usuarios != null)
                foreach (_sis_Usuario usuario in usuarios)
                    lb_usuariosListaUsuarios.Items.Add(usuario.Cuenta);

        }

        private void btn_seleccionarUsuario_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lb_usuariosListaUsuarios.SelectedItem == null) return;

            String cuenta = lb_usuariosListaUsuarios.SelectedItem.ToString();

            usuario = manejador.Cargar<_sis_Usuario>(_sis_Usuario.consultaPorCuenta, new List<object>() { cuenta });
            chb_usuariosEsAdministrador.IsChecked = usuario.EsAdministradorDeSistema;
            chb_usuariosEsSoporte.IsChecked = usuario.BEsSoporte;
            chb_usuariosEstaDesactivada.IsChecked = usuario.BEstaDesactivado;
            txt_usuarioNombreUsuario.Text = usuario.SNombreCompleto;
            txt_usuarioEmailUsuario.Text = usuario.SEmail;
            chb_UsuarioPuedeAccederACatalogoRapido.IsChecked = usuario.BPuedeAccederCatalogoRapido;
            chb_UsuarioRecibeVersionesPrueba.IsChecked = usuario.BRecibeVersionesPrueba;
            if (usuario.RolSistema != null)
                cmb_usuariosRolesEnSistema.SelectedItem = usuario.RolSistema.Nombre;
            txt_usuarioCuentaUsuario.Text = usuario.Cuenta;
            if (usuario.ImagenAsociada != null)
                img_usuarioImagenUsuario.Source = HerramientasWindow.BitmapAImageSource(usuario.ImagenAsociada.Imagen);
            txt_usuarioCuentaUsuario.IsReadOnly = true;
            CargarFormulariosEspeciales();


        }
        private void LimpiarDatosUsuario()
        {
            HerramientasWindow.AsignarFondoBlancoImage(img_usuarioImagenUsuario);
            txt_usuarioNombreUsuario.Text = "";
            txt_usuarioEmailUsuario.Text = "";
            txt_usuarioContraseñaUsuario.Password = "";
            txt_usuarioCuentaUsuario.Text = "";
            txt_usuarioContraseñaConfirmacionUsuario.Password = "";
            cmb_usuariosRolesEnSistema.SelectedIndex = -1;
            txt_usuarioCuentaUsuario.IsReadOnly = false;
            chb_usuariosEsAdministrador.IsChecked = false;
            chb_usuariosEstaDesactivada.IsChecked = false;
            chb_usuariosEsSoporte.IsChecked = false;
            chb_UsuarioPuedeAccederACatalogoRapido.IsChecked = false;
            lb_usuariosFormulariosEspeciales.Items.Clear();
            usuario = null;
        }
        private void btn_QuitarFormularioEspecial_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lb_usuariosFormulariosEspeciales.SelectedItem == null || usuario == null || usuario.ContenedorEspecial == null || usuario.ContenedorEspecial.FormulariosPermisos.Count == 0) return;
            _sis_FormularioPermisosPorRol permisos = usuario.ContenedorEspecial.FormulariosPermisos[lb_usuariosFormulariosEspeciales.SelectedIndex];

            usuario.ContenedorEspecial.FormulariosPermisos.RemoveAt(lb_usuariosFormulariosEspeciales.SelectedIndex);
            permisos.BorrarObjetoPermanentemente();

            CargarFormulariosEspeciales();
        }

        private void btn_EditarPermisosFormularioEspecial_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (usuario == null || usuario.ContenedorEspecial == null || usuario.ContenedorEspecial.FormulariosPermisos == null || lb_usuariosFormulariosEspeciales.SelectedItem == null) return;
            _sis_FormularioPermisosPorRol permisos = usuario.ContenedorEspecial.FormulariosPermisos[lb_usuariosFormulariosEspeciales.SelectedIndex];

            EditarPermisosFormulario permisosForm = new EditarPermisosFormulario(permisos);
            permisos.EsModificado = true;
            permisosForm.ShowDialog();
        }

        private void btn_AgregarFormularioUsuarios_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (usuario == null || lb_usuariosFormulariosRegistrados.SelectedItem == null) return;

            String nombreFormulario = lb_usuariosFormulariosRegistrados.SelectedItem.ToString();

            _sis_Formulario formularioSeleccionado = manejador.Cargar<_sis_Formulario>(_sis_Formulario.consultaPorTitulo, new List<object>() { nombreFormulario });
            if (usuario.ContenedorEspecial == null) usuario.ContenedorEspecial = new _sis_Contenedor();
            if (usuario.ContenedorEspecial.FormulariosPermisos == null) usuario.ContenedorEspecial.FormulariosPermisos = new List<_sis_FormularioPermisosPorRol>();
            usuario.ContenedorEspecial.EsModificado = true;
            usuario.ContenedorEspecial.STitulo = "Opciones especiales";

            _sis_FormularioPermisosPorRol permisos = new _sis_FormularioPermisosPorRol();
            permisos.EsModificado = true;

            permisos.Formulario = formularioSeleccionado;
            usuario.ContenedorEspecial.FormulariosPermisos.Add(permisos);
            CargarFormulariosEspeciales();

        }

        private void CargarFormulariosEspeciales()
        {
            lb_usuariosFormulariosEspeciales.Items.Clear();
            if (usuario.ContenedorEspecial != null && usuario.ContenedorEspecial.FormulariosPermisos != null)
                foreach (_sis_FormularioPermisosPorRol formu in usuario.ContenedorEspecial.FormulariosPermisos)
                {
                    lb_usuariosFormulariosEspeciales.Items.Add(formu.Formulario.STituloFormulario);
                }
        }
        private void btn_QuitarRol_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (usuario == null) return;
            usuario.RolSistema = null;
            cmb_usuariosRolesEnSistema.SelectedIndex = -1;
        }
        #endregion
        #region configuracion de apariencia
        private void CargarApariencia()
        {
            _sis_DatosSistema datosSistema = manejador.Cargar<_sis_DatosSistema>(_sis_DatosSistema.ConsultaTodos);
            if (datosSistema != null)
            {
                img_imagenFondoSistema.Source = HerramientasWindow.BitmapAImageSource(datosSistema.BImagenFondoPrincipal);
                img_imagenFondoLogin.Source = HerramientasWindow.BitmapAImageSource(datosSistema.BImagenFondoLogin);
                img_imagenIcono.Source = HerramientasWindow.BitmapAImageSource(datosSistema.BImagenIcono);
                txt_nombreSistema.Text = datosSistema.STitulo;
                chb_proteccionSistemaLogin.IsChecked = datosSistema.BUsarProteccionDeCuentasEnLogin;
                txt_sistemaTiempoAutobloqueo.Text = datosSistema.ISegundosAutobloqueo.ToString();
                txt_sistemaTiempoAlmacenObjetos.Text = datosSistema.ISegundosParaAlmacenObjetos.ToString();
                if (datosSistema.BImagenFondoPrincipal != null)
                    img_imagenFondoSistema.DataContext = true;
                if (datosSistema.BImagenFondoLogin != null)
                    img_imagenFondoLogin.DataContext = true;
                if (datosSistema.BImagenIcono != null)
                    img_imagenIcono.DataContext = true;
            }
            
        }
        #endregion

    }
}
