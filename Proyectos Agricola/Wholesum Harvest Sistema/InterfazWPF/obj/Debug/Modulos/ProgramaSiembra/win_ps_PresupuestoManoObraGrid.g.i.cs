﻿#pragma checksum "..\..\..\..\Modulos\ProgramaSiembra\win_ps_PresupuestoManoObraGrid.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2C607F59E3C83A10A95FC21A79CBE79E"
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


namespace InterfazWPF.Modulos.ProgramaSiembra {
    
    
    /// <summary>
    /// win_ps_PresupuestoManoObraGrid
    /// </summary>
    public partial class win_ps_PresupuestoManoObraGrid : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\Modulos\ProgramaSiembra\win_ps_PresupuestoManoObraGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgv_totalesTemporada;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\Modulos\ProgramaSiembra\win_ps_PresupuestoManoObraGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.Boton btn_exportarExcel;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\Modulos\ProgramaSiembra\win_ps_PresupuestoManoObraGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.Boton btn_cargar_costos;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Modulos\ProgramaSiembra\win_ps_PresupuestoManoObraGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal InterfazWPF.Boton btn_cargar_jornales;
        
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
            System.Uri resourceLocater = new System.Uri("/Vistas;component/modulos/programasiembra/win_ps_presupuestomanoobragrid.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Modulos\ProgramaSiembra\win_ps_PresupuestoManoObraGrid.xaml"
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
            this.dgv_totalesTemporada = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btn_exportarExcel = ((InterfazWPF.Boton)(target));
            return;
            case 3:
            this.btn_cargar_costos = ((InterfazWPF.Boton)(target));
            return;
            case 4:
            this.btn_cargar_jornales = ((InterfazWPF.Boton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

