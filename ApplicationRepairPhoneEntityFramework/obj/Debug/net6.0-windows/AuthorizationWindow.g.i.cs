﻿#pragma checksum "..\..\..\AuthorizationWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A38F806EC18783A5213255838936ABD00B8617F7"
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
    /// AuthorizationWindow
    /// </summary>
    public partial class AuthorizationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_server;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_login;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txbx_pawword;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_login;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cxbx_Member;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar connectionProgressBar;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\AuthorizationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label connectionLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/ApplicationRepairPhoneEntityFramework;component/authorizationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AuthorizationWindow.xaml"
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
            this.txbx_server = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\AuthorizationWindow.xaml"
            this.txbx_server.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_server_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbx_login = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\AuthorizationWindow.xaml"
            this.txbx_login.SelectionChanged += new System.Windows.RoutedEventHandler(this.txbx_login_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txbx_pawword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 21 "..\..\..\AuthorizationWindow.xaml"
            this.txbx_pawword.PasswordChanged += new System.Windows.RoutedEventHandler(this.txbx_pawword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_login = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\AuthorizationWindow.xaml"
            this.btn_login.Click += new System.Windows.RoutedEventHandler(this.btn_login_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cxbx_Member = ((System.Windows.Controls.CheckBox)(target));
            
            #line 27 "..\..\..\AuthorizationWindow.xaml"
            this.cxbx_Member.Checked += new System.Windows.RoutedEventHandler(this.cxbx_Member_Checked);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\AuthorizationWindow.xaml"
            this.cxbx_Member.Unloaded += new System.Windows.RoutedEventHandler(this.cxbx_Member_Unloaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.connectionProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 7:
            this.connectionLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

