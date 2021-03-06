﻿#pragma checksum "..\..\..\AdminTreeView\AdminTreeControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6FD53F23CAD690A3CC65938FCE9705AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Inspire;
using Inspire.Commands;
using Inspire.Common.TreeViewModel;
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


namespace Inspire.Client.ConfigurationWindow.AdminTreeView {
    
    
    /// <summary>
    /// AdminTreeControl
    /// </summary>
    public partial class AdminTreeControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 24 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRefresh;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView AdminTree;
        
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
            System.Uri resourceLocater = new System.Uri("/Inspire.Client.ConfigurationWindow;component/admintreeview/admintreecontrol.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
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
            
            #line 7 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((Inspire.Client.ConfigurationWindow.AdminTreeView.AdminTreeControl)(target)).PreviewMouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UserControl_PreviewMouseRightButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 12 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.NewDisplayExecuted);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.NewDisplayCanExecute);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 13 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.EditDisplayExecuted);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.EditDisplayCanExecute);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 14 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeleteDisplayExecuted);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.DeleteDisplayCanExecute);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 15 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.NewPropertyExecuted);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.NewPropertyCanExecute);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 16 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.EditPropertyExecuted);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.EditPropertyCanExecute);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 17 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeletePropertyExecuted);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.DeletePropertyCanExecute);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 18 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.NewGroupExecuted);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.NewGroupCanExecute);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 19 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.EditGroupExecuted);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.EditGroupCanExecute);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 20 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeleteGroupExecuted);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.DeleteGroupCanExecute);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 21 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.RefreshAdminDisplaysExecuted);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.RefreshAdminDisplaysCanExecute);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnRefresh = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.AdminTree = ((System.Windows.Controls.TreeView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 14:
            
            #line 197 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.OnRightMouseButtonUp);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 204 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.OnRightMouseButtonUp);
            
            #line default
            #line hidden
            
            #line 204 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TreeItem_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            case 16:
            
            #line 211 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.OnRightMouseButtonUp);
            
            #line default
            #line hidden
            
            #line 211 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.AdminDisplay_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 211 "..\..\..\AdminTreeView\AdminTreeControl.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TreeItem_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

