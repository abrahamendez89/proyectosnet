﻿#pragma checksum "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoActividadSiembra.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CA82975A785E11E2778A404EF212E0EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using InterfazWPF;
using InterfazWPF.AdministracionSistema.ControlesUsuario;
using RootLibrary.WPF.Localization;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace InterfazWPF.Modulos.Catalogos {
    
    
    /// <summary>
    /// win_ps_CatalogoActividadSiembra
    /// </summary>
    public partial class win_ps_CatalogoActividadSiembra : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoActividadSiembra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.TextboxBusquedaCatalogo txt_Buscador;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoActividadSiembra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.AdministracionSistema.ControlesUsuario.TextboxNormal txt_nombreActividad;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoActividadSiembra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.AdministracionSistema.ControlesUsuario.TextboxSoloNumeroDecimal txt_duracion;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoActividadSiembra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.TextboxBusquedaCatalogo txt_buscadorUnidadTiempo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Vistas;component/modulos/catalogos/win_ps_catalogoactividadsiembra.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoActividadSiembra.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txt_Buscador = ((InterfazWPF.TextboxBusquedaCatalogo)(target));
            return;
            case 2:
            this.txt_nombreActividad = ((InterfazWPF.AdministracionSistema.ControlesUsuario.TextboxNormal)(target));
            return;
            case 3:
            this.txt_duracion = ((InterfazWPF.AdministracionSistema.ControlesUsuario.TextboxSoloNumeroDecimal)(target));
            return;
            case 4:
            this.txt_buscadorUnidadTiempo = ((InterfazWPF.TextboxBusquedaCatalogo)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

