﻿#pragma checksum "..\..\..\..\..\UI\Steps\Lotka\UploadRelation.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AB7697BF1375AFE5F74FD7EE4036CB3F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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


namespace Manifest.UI.Steps.Lotka {
    
    
    /// <summary>
    /// UploadRelation
    /// </summary>
    public partial class UploadRelation : Manifest.Utils.DetailsPage, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 14 "..\..\..\..\..\UI\Steps\Lotka\UploadRelation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUploadContainer;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\UI\Steps\Lotka\UploadRelation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNew;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\UI\Steps\Lotka\UploadRelation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridRelation;
        
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
            System.Uri resourceLocater = new System.Uri("/Manifest;component/ui/steps/lotka/uploadrelation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UI\Steps\Lotka\UploadRelation.xaml"
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
            this.btnUploadContainer = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\..\UI\Steps\Lotka\UploadRelation.xaml"
            this.btnUploadContainer.Click += new System.Windows.RoutedEventHandler(this.BtnUploadContainer_OnClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnNew = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\..\UI\Steps\Lotka\UploadRelation.xaml"
            this.btnNew.Click += new System.Windows.RoutedEventHandler(this.BtnNew_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.gridRelation = ((System.Windows.Controls.DataGrid)(target));
            
            #line 19 "..\..\..\..\..\UI\Steps\Lotka\UploadRelation.xaml"
            this.gridRelation.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.GridRelation_OnLoadingRow);
            
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
            
            #line 75 "..\..\..\..\..\UI\Steps\Lotka\UploadRelation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnEdit_OnClick);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 84 "..\..\..\..\..\UI\Steps\Lotka\UploadRelation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnDelete_OnClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

