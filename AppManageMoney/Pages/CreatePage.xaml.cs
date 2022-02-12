using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class Reminder
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Time { get; set; }
        public bool IsActive { get; set; }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreatePage : Page
    {
        public List<Reminder> Reminder { get; set; }
       
        private CreateService createService;
        
        public CreatePage()
        {
            this.InitializeComponent();
            this.createService = new CreateService();
            Loaded += CreatePage_Loaded;
            
            Reminder = new List<Reminder>();
            
            
        }

        private async void CreatePage_Loaded(object sender, RoutedEventArgs e)
        {
            List<PersonalTransaction> list= await createService.Select_Data();
            ObservableCollection<PersonalTransaction> observabSongs = new ObservableCollection<PersonalTransaction>(list);

            DataGird.ItemsSource = observabSongs;



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public  void create_button(object sender, RoutedEventArgs e)
        {

            var name = Name.Text;
            var description = Description.Text;
            var money = Money.Text;
            var date = CreatedDate.SelectedDate.ToString();
            var category = Category.Text;

           var result =  createService.Insert_Data(name, description, money, date, category);
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
        }

      

    }
}
