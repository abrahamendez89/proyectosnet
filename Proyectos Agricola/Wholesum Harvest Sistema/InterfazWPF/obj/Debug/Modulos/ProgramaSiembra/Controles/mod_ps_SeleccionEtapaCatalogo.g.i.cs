﻿#pragma checksum "..\..\..\..\..\Modulos\ProgramaSiembra\Controles\mod_ps_SeleccionEtapaCatalogo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "13451E14961CF0EE45BE1BB5B203FD78"
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


namespace InterfazWPF.Modulos.ProgramaSiembra.Controles {
    
    
    /// <summary>
    /// mod_ps_SeleccionEtapaCatalogo
    /// </summary>
    public partial class mod_ps_SeleccionEtapaCatalogo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\..\Modulos\ProgramaSiembra\Controles\mod_ps_SeleccionEtapaCatalogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.TextboxBusquedaCatalogo txt_buscadorEtapa;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\Modulos\ProgramaSiembra\Controles\mod_ps_SeleccionEtapaCatalogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.Boton btn_aceptar;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Modulos\ProgramaSiembra\Controles\mod_ps_SeleccionEtapaCatalogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.Boton btn_cancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/Vistas;component/modulos/programasiembra/controles/mod_ps_seleccionetapacatalogo" +
                    ".xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Modulos\ProgramaSiembra\Controles\mod_ps_SeleccionEtapaCatalogo.xaml"
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
            this.txt_buscadorEtapa = ((InterfazWPF.TextboxBusquedaCatalogo)(target));
            return;
            case 2:
            this.btn_aceptar = ((InterfazWPF.Boton)(target));
            return;
            case 3:
            this.btn_cancelar = ((InterfazWPF.Boton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
