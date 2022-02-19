using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Contact_Information.Data;
using Contact_Information.Entity;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Contact_Information
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private CRUD crud;
        public MainPage()
        {
            this.InitializeComponent();
            crud = new CRUD();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ListData.ItemsSource = crud.SelectedData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Contact contact = new Contact()
            {
                Name = txtname.Text,
                Phone=txtPhone.Text,                             
            };
            var check = crud.CheckPhone(txtPhone.Text);
            if (check)
            {
                var result = crud.Insert_Data(contact);
                ContentDialog contentDialog = new ContentDialog();
                if (result)
                {
                    contentDialog.Title = "THÔNG BÁO ";
                    contentDialog.Content = "Thêm thành công!";
                    contentDialog.CloseButtonText = "OK";

                }
                else
                {
                    contentDialog.Title = "THÔNG BÁO ";
                    contentDialog.Content = "Thêm thất bại  !";
                    contentDialog.CloseButtonText = "OK";
                }
                _ = contentDialog.ShowAsync();
                contentDialog.CloseButtonClick += ContentDialog_CloseButtonClick;
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
               
                
                    contentDialog.Title = "THÔNG BÁO ";
                    contentDialog.Content = "Số Điện Thoại Đã Tồn Tại!";
                    contentDialog.CloseButtonText = "OK";

              
                _ = contentDialog.ShowAsync();
            }
            
        }

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ClearData();
            ListData.ItemsSource = crud.SelectedData();
            ListData.UpdateLayout();
        }
        private void ClearData()
        {
            txtname.Text = String.Empty;
            txtPhone.Text = String.Empty;
            

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Name = txtNameSearch.Text;
            

            var result = crud.Search(Name);
            if (result != null)
            {
                ListData.ItemsSource = result;
                ListData.UpdateLayout();

            }
            else
            {

                ContentDialog contentDialog = new ContentDialog();
              
                    contentDialog.Title = "THÔNG BÁO ";
                    contentDialog.Content = "Contact not found";
                    contentDialog.CloseButtonText = "OK";

            
                _ = contentDialog.ShowAsync();
            }
        }
    }
}
