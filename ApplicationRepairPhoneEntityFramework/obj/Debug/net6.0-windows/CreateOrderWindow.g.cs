﻿#pragma checksum "..\..\..\CreateOrderWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30007AF9D94BF343549BA2621D7CD7AE3DCB4DD8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ApplicationRepairPhoneEntityFramework;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ApplicationRepairPhoneEntityFramework {
    
    
    /// <summary>
    /// CreateOrderWindow
    /// </summary>
    public partial class CreateOrderWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_ID_Order;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_searchClient;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridClients;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_searchDevice;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridDevices;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_searchEmployee;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridEmployees;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Add_Order;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ApplicationRepairPhoneEntityFramework;component/createorderwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CreateOrderWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txbx_ID_Order = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            
            #line 19 "..\..\..\CreateOrderWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 22 "..\..\..\CreateOrderWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txbx_searchClient = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\CreateOrderWindow.xaml"
            this.txbx_searchClient.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_searchClient_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dataGridClients = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.txbx_searchDevice = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\CreateOrderWindow.xaml"
            this.txbx_searchDevice.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_searchDevice_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dataGridDevices = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.txbx_searchEmployee = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\CreateOrderWindow.xaml"
            this.txbx_searchEmployee.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_searchEmployee_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dataGridEmployees = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.btn_Add_Order = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\CreateOrderWindow.xaml"
            this.btn_Add_Order.Click += new System.Windows.RoutedEventHandler(this.btn_Add_Order_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

