﻿#pragma checksum "..\..\..\..\Modulos\ProgramaSiembra\win_ps_VisualizadorPresupuesto.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "244B8AA7B2E8EAD8B2F5172B6876D672"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Telerik.Charting;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.BulletGraph;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Controls.Data.PropertyGrid;
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Gauge;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.HeatMap;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Controls.Sparklines;
using Telerik.Windows.Controls.TimeBar;
using Telerik.Windows.Controls.Timeline;
using Telerik.Windows.Controls.TransitionEffects;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.Controls.TreeMap;
using Telerik.Windows.Data;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using Telerik.Windows.Input.Touch;
using Telerik.Windows.Rendering;
using Telerik.Windows.Shapes;


namespace InterfazWPF.Modulos.ProgramaSiembra {
    
    
    /// <summary>
    /// win_ps_VisualizadorPresupuesto
    /// </summary>
    public partial class win_ps_VisualizadorPresupuesto : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\Modulos\ProgramaSiembra\win_ps_VisualizadorPresupuesto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGanttView xGanttView;
        
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
            System.Uri resourceLocater = new System.Uri("/Vistas;component/modulos/programasiembra/win_ps_visualizadorpresupuesto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Modulos\ProgramaSiembra\win_ps_VisualizadorPresupuesto.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.xGanttView = ((Telerik.Windows.Controls.RadGanttView)(target));
            
            #line 8 "..\..\..\..\Modulos\ProgramaSiembra\win_ps_VisualizadorPresupuesto.xaml"
            this.xGanttView.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.xGanttView_MouseWheel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

