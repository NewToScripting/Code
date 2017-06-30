﻿#pragma checksum "..\..\ScheduleWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A297411D29841CB480DED43DBEADF4BE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevComponents.WpfDock;
using Inspire.Client.ScheduleWindow.SchedulePropertyPanel;
using Inspire.Client.ScheduleWindow.ScheduledSlidePanel;
using Inspire.Commands;
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


namespace Inspire.Client.ScheduleWindow {
    
    
    /// <summary>
    /// ScheduleWindow
    /// </summary>
    public partial class ScheduleWindow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\ScheduleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Inspire.Client.ScheduleWindow.SchedulePropertyPanel.SchedulePropertyControl SchedulerPropertyControl;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\ScheduleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Transitionals.Controls.TransitionElement SchedulerHolder;
        
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
            System.Uri resourceLocater = new System.Uri("/Inspire.Client.ScheduleWindow;component/schedulewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ScheduleWindow.xaml"
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
            
            #line 10 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.UpdateScheduleExecuted);
            
            #line default
            #line hidden
            
            #line 10 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.UpdateScheduleCanExecute);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 11 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SaveScheduleExecuted);
            
            #line default
            #line hidden
            
            #line 11 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.SaveScheduleCanExecute);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 12 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CancelScheduleExecuted);
            
            #line default
            #line hidden
            
            #line 12 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CancelScheduleCanExecute);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 13 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ConfigureTouchscreenButtonsExecuted);
            
            #line default
            #line hidden
            
            #line 13 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ConfigureTouchscreenButtonsCanExecute);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 14 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ConfigureTransitionExecuted);
            
            #line default
            #line hidden
            
            #line 14 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ConfigureTransitionCanExecute);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 15 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SaveTouchscreenButtonsExecuted);
            
            #line default
            #line hidden
            
            #line 15 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.SaveTouchscreenButtonsCanExecute);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 16 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CancelTouchscreenButtonsExecuted);
            
            #line default
            #line hidden
            
            #line 16 "..\..\ScheduleWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CancelTouchscreenButtonsCanExecute);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SchedulerPropertyControl = ((Inspire.Client.ScheduleWindow.SchedulePropertyPanel.SchedulePropertyControl)(target));
            return;
            case 9:
            this.SchedulerHolder = ((Transitionals.Controls.TransitionElement)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
