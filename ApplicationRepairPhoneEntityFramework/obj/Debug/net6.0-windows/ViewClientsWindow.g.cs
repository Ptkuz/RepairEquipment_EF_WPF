﻿#pragma checksum "..\..\..\ViewClientsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6746F308B53769147009A6E7572CE187DEE6E13D"
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
    /// DirectorViewClientsWindow
    /// </summary>
    public partial class DirectorViewClientsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\ViewClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_search_client;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\ViewClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridClients;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\ViewClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_Id_Client;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\ViewClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_fio;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\ViewClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_series_number;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\ViewClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_phone_number;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\ViewClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_email;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\ViewClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Add_Client;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\ViewClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Update_Client;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\ViewClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Delete_Client;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ApplicationRepairPhoneEntityFramework;component/viewclientswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ViewClientsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txbx_search_client = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\ViewClientsWindow.xaml"
            this.txbx_search_client.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_search_client_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dataGridClients = ((System.Windows.Controls.DataGrid)(target));
            
            #line 42 "..\..\..\ViewClientsWindow.xaml"
            this.dataGridClients.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGridClients_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txbx_Id_Client = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\..\ViewClientsWindow.xaml"
            this.txbx_Id_Client.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_Id_Client_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txbx_fio = ((System.Windows.Controls.TextBox)(target));
            
            #line 64 "..\..\..\ViewClientsWindow.xaml"
            this.txbx_fio.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_fio_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txbx_series_number = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\..\ViewClientsWindow.xaml"
            this.txbx_series_number.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_series_number_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txbx_phone_number = ((System.Windows.Controls.TextBox)(target));
            
            #line 72 "..\..\..\ViewClientsWindow.xaml"
            this.txbx_phone_number.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_phone_number_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txbx_email = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\..\ViewClientsWindow.xaml"
            this.txbx_email.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_email_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_Add_Client = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\ViewClientsWindow.xaml"
            this.btn_Add_Client.Click += new System.Windows.RoutedEventHandler(this.btn_Add_Client_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_Update_Client = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\ViewClientsWindow.xaml"
            this.btn_Update_Client.Click += new System.Windows.RoutedEventHandler(this.btn_Update_Client_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_Delete_Client = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\ViewClientsWindow.xaml"
            this.btn_Delete_Client.Click += new System.Windows.RoutedEventHandler(this.btn_Delete_Client_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

