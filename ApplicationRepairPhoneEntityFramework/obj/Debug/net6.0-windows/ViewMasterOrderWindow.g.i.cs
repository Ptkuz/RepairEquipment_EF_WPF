﻿#pragma checksum "..\..\..\ViewMasterOrderWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8617597724966FC7EA91161F31A9381ED3733E9F"
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
    /// ViewMasterOrderWindow
    /// </summary>
    public partial class ViewMasterOrderWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\ViewMasterOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_search_orders;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\ViewMasterOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_change_status;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\ViewMasterOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridOrders;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\ViewMasterOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_search_workingOrder;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\ViewMasterOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_change_status_2;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\ViewMasterOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridWorkingOrder;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\ViewMasterOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_search_completeOrder;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\ViewMasterOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridCompleteOrder;
        
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
            System.Uri resourceLocater = new System.Uri("/ApplicationRepairPhoneEntityFramework;component/viewmasterorderwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ViewMasterOrderWindow.xaml"
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
            this.txbx_search_orders = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\ViewMasterOrderWindow.xaml"
            this.txbx_search_orders.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_search_orders_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_change_status = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\ViewMasterOrderWindow.xaml"
            this.btn_change_status.Click += new System.Windows.RoutedEventHandler(this.btn_change_status_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DataGridOrders = ((System.Windows.Controls.DataGrid)(target));
            
            #line 33 "..\..\..\ViewMasterOrderWindow.xaml"
            this.DataGridOrders.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridOrders_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txbx_search_workingOrder = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\..\ViewMasterOrderWindow.xaml"
            this.txbx_search_workingOrder.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_search_workingOrder_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_change_status_2 = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\ViewMasterOrderWindow.xaml"
            this.btn_change_status_2.Click += new System.Windows.RoutedEventHandler(this.btn_change_status_2_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DataGridWorkingOrder = ((System.Windows.Controls.DataGrid)(target));
            
            #line 58 "..\..\..\ViewMasterOrderWindow.xaml"
            this.DataGridWorkingOrder.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridWorkingOrder_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txbx_search_completeOrder = ((System.Windows.Controls.TextBox)(target));
            
            #line 80 "..\..\..\ViewMasterOrderWindow.xaml"
            this.txbx_search_completeOrder.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_search_completeOrder_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DataGridCompleteOrder = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

