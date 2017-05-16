﻿#pragma checksum "..\..\CreateGame.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AD6BFB1DB2D5861192C36C1801B8C23B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GUI;
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


namespace GUI {
    
    
    /// <summary>
    /// CreateGame
    /// </summary>
    public partial class CreateGame : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\CreateGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Min_Players;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\CreateGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Max_Players;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\CreateGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Small_Blind;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\CreateGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Big_Blind;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\CreateGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Allow_Spec;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\CreateGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Type_Policy;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\CreateGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Chip_Policy;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\CreateGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Buy_In_Policy;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\CreateGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button New_Game;
        
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
            System.Uri resourceLocater = new System.Uri("/GUI;component/creategame.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreateGame.xaml"
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
            this.Min_Players = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Max_Players = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Small_Blind = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Big_Blind = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Allow_Spec = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.Type_Policy = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Chip_Policy = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Buy_In_Policy = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.New_Game = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\CreateGame.xaml"
            this.New_Game.Click += new System.Windows.RoutedEventHandler(this.New_Game_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
