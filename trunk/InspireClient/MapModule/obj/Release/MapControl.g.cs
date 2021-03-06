﻿#pragma checksum "..\..\MapControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8710D5FA72AAC95CF5367BEB78DA1D9E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InfoStrat.VE.Windows7Touch;
using Inspire;
using MapModule;
using Microsoft.Windows.Themes;
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
using Transitionals.Controls;


namespace MapModule {
    
    
    /// <summary>
    /// MapControl
    /// </summary>
    public partial class MapControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 202 "..\..\MapControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel PART_DockPanel;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\MapControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PART_SearchButton;
        
        #line default
        #line hidden
        
        
        #line 211 "..\..\MapControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Transitionals.Controls.TransitionElement PART_CategoryHolder;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\MapControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentPresenter mapHolder;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\MapControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PART_MapMode;
        
        #line default
        #line hidden
        
        
        #line 217 "..\..\MapControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton tglArial;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\MapControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton tglHybrid;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\MapControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton tglRoad;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\MapControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PART_ZoomControls;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\MapControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Transitionals.Controls.TransitionElement detailsHolder;
        
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
            System.Uri resourceLocater = new System.Uri("/MapModule;component/mapcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MapControl.xaml"
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
            
            #line 6 "..\..\MapControl.xaml"
            ((MapModule.MapControl)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UserControl_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 6 "..\..\MapControl.xaml"
            ((MapModule.MapControl)(target)).PreviewTouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.UserControl_PreviewTouchDown);
            
            #line default
            #line hidden
            
            #line 6 "..\..\MapControl.xaml"
            ((MapModule.MapControl)(target)).TouchMove += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.UserControl_TouchMove);
            
            #line default
            #line hidden
            
            #line 6 "..\..\MapControl.xaml"
            ((MapModule.MapControl)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.UserControl_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PART_DockPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 3:
            this.PART_SearchButton = ((System.Windows.Controls.StackPanel)(target));
            
            #line 203 "..\..\MapControl.xaml"
            this.PART_SearchButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.StackPanel_MouseDown);
            
            #line default
            #line hidden
            
            #line 203 "..\..\MapControl.xaml"
            this.PART_SearchButton.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.StackPanel_TouchDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PART_CategoryHolder = ((Transitionals.Controls.TransitionElement)(target));
            return;
            case 5:
            this.mapHolder = ((System.Windows.Controls.ContentPresenter)(target));
            return;
            case 6:
            this.PART_MapMode = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.tglArial = ((System.Windows.Controls.RadioButton)(target));
            
            #line 217 "..\..\MapControl.xaml"
            this.tglArial.Checked += new System.Windows.RoutedEventHandler(this.tglMap_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tglHybrid = ((System.Windows.Controls.RadioButton)(target));
            
            #line 218 "..\..\MapControl.xaml"
            this.tglHybrid.Checked += new System.Windows.RoutedEventHandler(this.tglMap_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tglRoad = ((System.Windows.Controls.RadioButton)(target));
            
            #line 219 "..\..\MapControl.xaml"
            this.tglRoad.Checked += new System.Windows.RoutedEventHandler(this.tglMap_Checked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.PART_ZoomControls = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            
            #line 222 "..\..\MapControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ZoomIn_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 223 "..\..\MapControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ZoomOut_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.detailsHolder = ((Transitionals.Controls.TransitionElement)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

