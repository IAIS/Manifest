﻿#pragma checksum "..\..\..\UserControl\uConsignmentDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "21346A085A08B1163DD644B07E1858D0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Manifest.UserControl {
    
    
    /// <summary>
    /// uConsignmentDetails
    /// </summary>
    public partial class uConsignmentDetails : Manifest.Utils.Details, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 1 "..\..\..\UserControl\uConsignmentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Manifest.UserControl.uConsignmentDetails consignmentDetails;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\UserControl\uConsignmentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\UserControl\uConsignmentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridConsignment;
        
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
            System.Uri resourceLocater = new System.Uri("/Manifest;component/usercontrol/uconsignmentdetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControl\uConsignmentDetails.xaml"
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
            this.consignmentDetails = ((Manifest.UserControl.uConsignmentDetails)(target));
            return;
            case 2:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 9 "..\..\..\UserControl\uConsignmentDetails.xaml"
            this.txtSearch.GotFocus += new System.Windows.RoutedEventHandler(this.UIElement_OnGotFocus);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\UserControl\uConsignmentDetails.xaml"
            this.txtSearch.LostFocus += new System.Windows.RoutedEventHandler(this.TxtSearch_OnLostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.gridConsignment = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\UserControl\uConsignmentDetails.xaml"
            this.gridConsignment.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.GridJFlightConsignment_OnLoadingRow);
            
            #line default
            #line hidden
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
            case 4:
            
            #line 70 "..\..\..\UserControl\uConsignmentDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnEdit_OnClick);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 79 "..\..\..\UserControl\uConsignmentDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnDelete_OnClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

