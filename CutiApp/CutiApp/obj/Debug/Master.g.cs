﻿#pragma checksum "..\..\Master.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D6B027CB5B86769ACDDCE0BADA239EA196D7B629"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CutiApp;
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


namespace CutiApp {
    
    
    /// <summary>
    /// Master
    /// </summary>
    public partial class Master : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvKaryawan;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNama;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbDepartment;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNoTelp;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtJobTitle;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStatus;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtJumlahAnak;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSimpan;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Master.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIdKaryawan;
        
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
            System.Uri resourceLocater = new System.Uri("/CutiApp;component/master.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Master.xaml"
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
            this.dgvKaryawan = ((System.Windows.Controls.DataGrid)(target));
            
            #line 14 "..\..\Master.xaml"
            this.dgvKaryawan.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgvKaryawan_SelectionCellsChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtNama = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cbDepartment = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtNoTelp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtJobTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtStatus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtJumlahAnak = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.btnSimpan = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\Master.xaml"
            this.btnSimpan.Click += new System.Windows.RoutedEventHandler(this.btnSimpan_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\Master.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.txtIdKaryawan = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

