﻿#pragma checksum "..\..\Dialog_IPadd.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E75B334753E66A375455A91203F9C1A19A0A905F"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using ChatClient;
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


namespace ChatClient {
    
    
    /// <summary>
    /// Dialog_IPadd
    /// </summary>
    public partial class Dialog_IPadd : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Dialog_IPadd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbox_DialogIPadd_Name;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Dialog_IPadd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbox_DialogIPadd_IP;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Dialog_IPadd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_DialogIPadd_OK;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Dialog_IPadd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbox_DialogIPadd_Port;
        
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
            System.Uri resourceLocater = new System.Uri("/ChatClient;component/dialog_ipadd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Dialog_IPadd.xaml"
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
            this.txtbox_DialogIPadd_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtbox_DialogIPadd_IP = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btn_DialogIPadd_OK = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Dialog_IPadd.xaml"
            this.btn_DialogIPadd_OK.Click += new System.Windows.RoutedEventHandler(this.Btn_DialogIPadd_OK_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtbox_DialogIPadd_Port = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

