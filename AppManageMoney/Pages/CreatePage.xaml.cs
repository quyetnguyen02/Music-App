using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AppManageMoney.Entity;
using AppManageMoney.Service;
using SQLitePCL;
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

namespace AppManageMoney.Pages
{
   
   
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreatePage : Page
    {
       
       
        private CreateService createService;
        
        

        public CreatePage()
        {
            this.InitializeComponent();
            this.createService = new CreateService();
            Loaded += CreatePage_Loaded;
          

        }

        private  void CreatePage_Loaded(object sender, RoutedEventArgs e)
        {
 
            ListData.ItemsSource = createService.SelectedData(); 
        }

       

        public  void create_button(object sender, RoutedEventArgs e)
        {
            PersonalTransaction personal = new PersonalTransaction()
            {
                Name = Name.Text,
                Description = Description.Text,
                Money = Convert.ToDouble(Money.Text.ToString()),
                CreatedDate = Convert.ToDateTime(CreatedDate.SelectedDate.ToString()),
                Category = Convert.ToInt32(Category.Text.ToString()),
            };

           var result =  createService.Insert_Data(personal);
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

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ClearData();
            ListData.ItemsSource = createService.SelectedData();
            ListData.UpdateLayout();

        }

        private void ClearData()
        {
            Name.Text = String.Empty;
            Description.Text = String.Empty;
            Money.Text = String.Empty;
           CreatedDate.SelectedDate = null;
            Category.Text = String.Empty;

        }

        private void ListData_Loaded(object sender, RoutedEventArgs e)
        {
            ListData.ItemsSource=  createService.SelectedData();
          
        }

        private void SearchButton(object sender, RoutedEventArgs e)
        {
            var searchFrom = DateFrom.SelectedDate.ToString();
            var searchTo = DateTo.SelectedDate.ToString();

            var result = createService.Search(searchFrom,searchTo);
            if(result != null)
            {
                ListData.ItemsSource = result;
                ListData.UpdateLayout();

            }
           
           
        }
    }
}
