﻿#pragma checksum "..\..\..\ViewAllOrdersManagerWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1C67DF9173940AC17CE463EF381A718698C3AE8C"
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
    /// ViewAllOrdersManagerWindow
    /// </summary>
    public partial class ViewAllOrdersManagerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\ViewAllOrdersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_search_orders;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\ViewAllOrdersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_change_status;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\ViewAllOrdersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridOrders;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\ViewAllOrdersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_search_workingOrder;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\ViewAllOrdersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridWorkingOrder;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\ViewAllOrdersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_search_completeOrder;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\ViewAllOrdersManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridCompleteOrder;
        
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
            System.Uri resourceLocater = new System.Uri("/ApplicationRepairPhoneEntityFramework;component/viewallordersmanagerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ViewAllOrdersManagerWindow.xaml"
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
            this.txbx_search_orders = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\ViewAllOrdersManagerWindow.xaml"
            this.txbx_search_orders.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_search_orders_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_change_status = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\ViewAllOrdersManagerWindow.xaml"
            this.btn_change_status.Click += new System.Windows.RoutedEventHandler(this.btn_change_status_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DataGridOrders = ((System.Windows.Controls.DataGrid)(target));
            
            #line 46 "..\..\..\ViewAllOrdersManagerWindow.xaml"
            this.DataGridOrders.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridOrders_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txbx_search_workingOrder = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\..\ViewAllOrdersManagerWindow.xaml"
            this.txbx_search_workingOrder.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_search_workingOrder_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DataGridWorkingOrder = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.txbx_search_completeOrder = ((System.Windows.Controls.TextBox)(target));
            
            #line 96 "..\..\..\ViewAllOrdersManagerWindow.xaml"
            this.txbx_search_completeOrder.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_search_completeOrder_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DataGridCompleteOrder = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

