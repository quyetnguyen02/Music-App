using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserPage : Page
    {
        public UserPage()
        {
            this.InitializeComponent();
            Loaded += UserPage_Loaded;
        }

        private void UserPage_Loaded(object sender, RoutedEventArgs e)
        {
            txtFullName.Text = App.currentLogin.firstName + " " + App.currentLogin.lastName;
            txtFullName1.Text= App.currentLogin.firstName + " " + App.currentLogin.lastName;
            BitmapImage bitmapImage = new BitmapImage();
            avatarImage.ProfilePicture = new BitmapImage(new Uri(App.currentLogin.avatar));

            txtEmail.Text = App.currentLogin.email;
            txtPhone.Text = App.currentLogin.phone;

            switch (App.currentLogin.gender)
            {
                case 1:
                    txtGender.Text = "Male";
                    break;
                case 2:
                    txtGender.Text = "Female";
                    break;
                case 3 :
                   txtGender.Text = "Other";
                    break;

            }

            txtAddress.Text = App.currentLogin.address;
            txtBirthday.Text = App.currentLogin.birthday;



        }
    }
}
