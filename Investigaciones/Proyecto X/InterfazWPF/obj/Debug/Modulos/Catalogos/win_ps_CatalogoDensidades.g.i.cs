﻿#pragma checksum "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoDensidades.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "670D06E9C4322D16F508823DEE4583C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
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
    /// win_ps_CatalogoDensidades
    /// </summary>
    public partial class win_ps_CatalogoDensidades : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoDensidades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.TextboxBusquedaCatalogo txt_Buscador;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoDensidades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_NumeroHileras;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoDensidades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.AdministracionSistema.ControlesUsuario.TextboxSoloNumeroDecimal txt_Separacion;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoDensidades.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.AdministracionSistema.ControlesUsuario.TextboxSoloNumeroDecimal txt_Corazon;
        
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
            System.Uri resourceLocater = new System.Uri("/Vistas;component/modulos/catalogos/win_ps_catalogodensidades.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Modulos\Catalogos\win_ps_CatalogoDensidades.xaml"
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
            this.cmb_NumeroHileras = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.txt_Separacion = ((InterfazWPF.AdministracionSistema.ControlesUsuario.TextboxSoloNumeroDecimal)(target));
            return;
            case 4:
            this.txt_Corazon = ((InterfazWPF.AdministracionSistema.ControlesUsuario.TextboxSoloNumeroDecimal)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

