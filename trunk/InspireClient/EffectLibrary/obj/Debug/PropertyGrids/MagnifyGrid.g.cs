﻿#pragma checksum "..\..\..\PropertyGrids\MagnifyGrid.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2C7322F13070E07F0E6834CDE92E6751"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace EffectLibrary.PropertyGrids {
    
    
    /// <summary>
    /// MagnifyGrid
    /// </summary>
    public partial class MagnifyGrid : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\PropertyGrids\MagnifyGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider radiiX;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\PropertyGrids\MagnifyGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider radiiY;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\PropertyGrids\MagnifyGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider centerX;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\PropertyGrids\MagnifyGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider centerY;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\PropertyGrids\MagnifyGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider shrinkFactor;
        
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
            System.Uri resourceLocater = new System.Uri("/EffectLibrary;component/propertygrids/magnifygrid.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PropertyGrids\MagnifyGrid.xaml"
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
            this.radiiX = ((System.Windows.Controls.Slider)(target));
            
            #line 20 "..\..\..\PropertyGrids\MagnifyGrid.xaml"
            this.radiiX.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.radiiX_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.radiiY = ((System.Windows.Controls.Slider)(target));
            
            #line 27 "..\..\..\PropertyGrids\MagnifyGrid.xaml"
            this.radiiY.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.radiiY_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.centerX = ((System.Windows.Controls.Slider)(target));
            
            #line 35 "..\..\..\PropertyGrids\MagnifyGrid.xaml"
            this.centerX.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.centerX_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.centerY = ((System.Windows.Controls.Slider)(target));
            
            #line 42 "..\..\..\PropertyGrids\MagnifyGrid.xaml"
            this.centerY.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.centerY_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.shrinkFactor = ((System.Windows.Controls.Slider)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

