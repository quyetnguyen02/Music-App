﻿#pragma checksum "D:\FPTAPTECH\SEM3\Universal\MusicApp\Pages\RegisterPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "547383CCA44FB63FED72AE1CD11F583D93BC25EB72067B61FC3B53987179C47A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicApp.Pages
{
    partial class RegisterPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\RegisterPage.xaml line 14
                {
                    this.firstName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Pages\RegisterPage.xaml line 15
                {
                    this.lastName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Pages\RegisterPage.xaml line 18
                {
                    this.txtEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Pages\RegisterPage.xaml line 21
                {
                    this.txtpassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 6: // Pages\RegisterPage.xaml line 22
                {
                    this.txtAddress = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // Pages\RegisterPage.xaml line 24
                {
                    this.txtAvatar = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // Pages\RegisterPage.xaml line 25
                {
                    this.txtPhone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // Pages\RegisterPage.xaml line 28
                {
                    this.male = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.male).Checked += this.HandleCheck;
                }
                break;
            case 10: // Pages\RegisterPage.xaml line 29
                {
                    this.female = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.female).Checked += this.HandleCheck;
                }
                break;
            case 11: // Pages\RegisterPage.xaml line 30
                {
                    this.other = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.other).Checked += this.HandleCheck;
                }
                break;
            case 12: // Pages\RegisterPage.xaml line 34
                {
                    this.birthday = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 13: // Pages\RegisterPage.xaml line 35
                {
                    this.checkFirstName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // Pages\RegisterPage.xaml line 36
                {
                    this.checkLastName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // Pages\RegisterPage.xaml line 37
                {
                    this.checkEmail = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // Pages\RegisterPage.xaml line 39
                {
                    this.checkAddress = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // Pages\RegisterPage.xaml line 40
                {
                    this.checkPhone = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18: // Pages\RegisterPage.xaml line 42
                {
                    this.passConfirm = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 19: // Pages\RegisterPage.xaml line 44
                {
                    this.checkPassConfirm = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 20: // Pages\RegisterPage.xaml line 45
                {
                    this.intro = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 21: // Pages\RegisterPage.xaml line 46
                {
                    this.checkAvatar = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 22: // Pages\RegisterPage.xaml line 47
                {
                    this.checkGender = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 23: // Pages\RegisterPage.xaml line 48
                {
                    this.checkBirthday = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 24: // Pages\RegisterPage.xaml line 50
                {
                    global::Windows.UI.Xaml.Controls.Button element24 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element24).Click += this.button_Register;
                }
                break;
            case 25: // Pages\RegisterPage.xaml line 51
                {
                    global::Windows.UI.Xaml.Controls.Button element25 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element25).Click += this.button_login;
                }
                break;
            case 26: // Pages\RegisterPage.xaml line 52
                {
                    global::Windows.UI.Xaml.Controls.Button element26 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element26).Click += this.OpenFileAvatar;
                }
                break;
            case 27: // Pages\RegisterPage.xaml line 53
                {
                    this.checkPassword = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 28: // Pages\RegisterPage.xaml line 55
                {
                    this.progress1 = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

