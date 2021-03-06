using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using MusicApp.Entity;
using MusicApp.Service;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private AccountService accountService = new AccountService();
       
        public LoginPage()
        {
            this.InitializeComponent();
           
        }
        private async void Button_Login(object sender, RoutedEventArgs e)
        {            
            var loginInformation = new LoginViewModel()
            {
                email = email.Text,
                password = password.Password.ToString()
            };
           Credential credential = await accountService.Login(loginInformation);
            if(credential == null)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Login Fail";
                contentDialog.Content = "Incorrect Email or Password";
                contentDialog.CloseButtonText = "OK";
                contentDialog.ShowAsync();
                Frame.Navigate(typeof(Pages.LoginPage));
            }
            else
            {
                Account account = await accountService.GetAccountInformation(credential.access_token);
                App.currentCredential = credential;
                if (account != null)
                {

                    App.currentLogin = account;
                    this.Frame.Navigate(typeof(Pages.MainPages));
                }
            }
        }
        private void Button_Register(object sender, RoutedEventArgs e)  
        {
            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.Navigate(typeof(Pages.RegisterPage));
        }      
    }
}
