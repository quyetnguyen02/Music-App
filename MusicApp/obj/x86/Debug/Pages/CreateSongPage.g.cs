#pragma checksum "D:\FPTAPTECH\Music-App\MusicApp\Pages\CreateSongPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CEAA862E3DCA34C48CF62089B8C0351526ED05C90A36846597BB60C4814B9471"
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
    partial class CreateSongPage : 
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
            case 2: // Pages\CreateSongPage.xaml line 86
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.Create;
                }
                break;
            case 3: // Pages\CreateSongPage.xaml line 87
                {
                    this.progress1 = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 4: // Pages\CreateSongPage.xaml line 83
                {
                    this.thumbnailImg = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 5: // Pages\CreateSongPage.xaml line 80
                {
                    this.txtThumbnail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Pages\CreateSongPage.xaml line 81
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.OpenThumbnail;
                }
                break;
            case 7: // Pages\CreateSongPage.xaml line 77
                {
                    this.txtErrThumbnail = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Pages\CreateSongPage.xaml line 68
                {
                    this.txtLink = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // Pages\CreateSongPage.xaml line 69
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.OpenLink;
                }
                break;
            case 10: // Pages\CreateSongPage.xaml line 65
                {
                    this.txtErrLink = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // Pages\CreateSongPage.xaml line 56
                {
                    this.txtDescription = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12: // Pages\CreateSongPage.xaml line 54
                {
                    this.txtErrDescription = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // Pages\CreateSongPage.xaml line 47
                {
                    this.txtAuthor = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14: // Pages\CreateSongPage.xaml line 45
                {
                    this.txtErrAuthor = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // Pages\CreateSongPage.xaml line 36
                {
                    this.txtSinger = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16: // Pages\CreateSongPage.xaml line 34
                {
                    this.txtErrSinger = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // Pages\CreateSongPage.xaml line 27
                {
                    this.txtName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 18: // Pages\CreateSongPage.xaml line 25
                {
                    this.txtErrName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19: // Pages\CreateSongPage.xaml line 17
                {
                    this.addTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

