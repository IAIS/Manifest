﻿#pragma checksum "..\..\..\..\..\UI\Steps\Lotka\UploadConsignment.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FAEC15B90A8EB2EC85411E14B283773F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Manifest.UserControl;
using Manifest.Utils;
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


namespace Manifest.UI.Steps.Lotka {
    
    
    /// <summary>
    /// UploadConsignment
    /// </summary>
    public partial class UploadConsignment : Manifest.Utils.DetailsPage, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\UI\Steps\Lotka\UploadConsignment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUploadConsignment;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\UI\Steps\Lotka\UploadConsignment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewConsignment;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\UI\Steps\Lotka\UploadConsignment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Manifest.UserControl.uConsignmentDetails UConsignmentDetails;
        
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
            System.Uri resourceLocater = new System.Uri("/Manifest;component/ui/steps/lotka/uploadconsignment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UI\Steps\Lotka\UploadConsignment.xaml"
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
            this.btnUploadConsignment = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.btnNewConsignment = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\..\UI\Steps\Lotka\UploadConsignment.xaml"
            this.btnNewConsignment.Click += new System.Windows.RoutedEventHandler(this.BtnNewConsignment_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.UConsignmentDetails = ((Manifest.UserControl.uConsignmentDetails)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

