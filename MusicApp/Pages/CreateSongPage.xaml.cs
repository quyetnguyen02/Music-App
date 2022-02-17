using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
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
    public sealed partial class CreateSongPage : Windows.UI.Xaml.Controls.Page
    {
        private Account account;
        private Cloudinary cloudinary;
        private string image;
        private Stream openImage;
        private string link;
        private Stream openLink;
        private ImageUploadResult AvatarUpload;
        private RawUploadResult linkUpLoad;
        private SongService songService;
        public CreateSongPage()
        {
            this.InitializeComponent();
            Loaded += CreateSongPage_Loaded;
            account = new Account(
            "derrfxjxx",
            "264153566326369",
            "MiXlQ3uZhdp_7SxfMCkf65lAcD0");
            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
            this.songService = new SongService();
        }
        private void CreateSongPage_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        private void checkVaild()
        {
            var name = txtName.Text;
            var description = txtDescription.Text;
            var singer = txtSinger.Text;
            var author = txtAuthor.Text;
            var thumbnail = txtThumbnail.Text;
            var link = txtLink.Text;
            //check name
            if (String.IsNullOrEmpty(name))
            {
                txtErrName.Text = "Please enter the Name";
            }
            else
            {
                txtErrName.Text = "";
            }
            //check description
            if (String.IsNullOrEmpty(description))
            {
                txtErrDescription.Text = "Please enter the Description";
            }
            else
            {
                txtErrDescription.Text = "";
            }
            //check singer
            if (String.IsNullOrEmpty(singer))
            {
                txtErrSinger.Text = "Please enter the Singer";
            }
            else
            {
                txtErrSinger.Text = "";
            }
            //check author
            if (String.IsNullOrEmpty(author))
            {
                txtErrAuthor.Text = "Please enter the Author";
            }
            else
            {
                txtErrAuthor.Text = "";
            }
            //check thumbnail
            if (String.IsNullOrEmpty(thumbnail))
            {
                txtErrThumbnail.Text = "Please enter the Thumbnail";
            }
            else
            {
                txtErrThumbnail.Text = "";
            }
            //check link
            if (String.IsNullOrEmpty(link))
            {
                txtErrLink.Text = "Please enter the Link";
            }
            else
            {
                txtErrLink.Text = "";
            }
        }
        private async void OpenThumbnail(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jfif");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
          
            if (file != null)
            {
                txtThumbnail.Text = file.Name;
                image = file.Name;
                openImage = await file.OpenStreamForReadAsync();
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Action fails!";
                contentDialog.Content = "Please chosse a file to save!";
                contentDialog.CloseButtonText = "OK";
                contentDialog.ShowAsync();
            }
        }
        private async void OpenLink(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".mp3");
            picker.FileTypeFilter.Add(".mp4");
          
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
           
            if (file != null)
            {
                txtLink.Text = file.Name;
                link = file.Name;
                openLink = await file.OpenStreamForReadAsync();
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Action fails!";
                contentDialog.Content = "Please chosse a file to save!";
                contentDialog.CloseButtonText = "OK";
                contentDialog.ShowAsync();
            }
        }
        private async void Create(object sender, RoutedEventArgs e)
        {
            checkVaild();
            if (String.IsNullOrEmpty(txtErrLink.Text))
            {
                ImageUploadParams imageUpload = new ImageUploadParams()
                {
                    File = new FileDescription(image, openImage),
                };
                AvatarUpload = await cloudinary.UploadAsync(imageUpload);
                Debug.WriteLine(AvatarUpload.Url);
                RawUploadParams rawUpload = new RawUploadParams()
                {
                    File = new FileDescription(link, openLink),
                };
                linkUpLoad = await cloudinary.UploadAsync(rawUpload);
                Debug.WriteLine(linkUpLoad.Url);
                var song = new Entity.Song()
                {
                    name = txtName.Text,
                    description = txtDescription.Text,
                    singer = txtSinger.Text,
                    author = txtAuthor.Text,
                    thumbnail = AvatarUpload.SecureUrl.ToString(),
                    link = linkUpLoad.SecureUrl.ToString()
                };
                var result = await songService.Createsong(song);
                Debug.WriteLine(result);
                ContentDialog contentDialog = new ContentDialog();
                if (result)
                {
                    contentDialog.Title = "Action Success";
                    contentDialog.Content = "Create Success";
                }
                else
                {
                    contentDialog.Title = "Action Fails";
                    contentDialog.Content = "Create Fails";
                }
                contentDialog.CloseButtonText = "OK";
                contentDialog.ShowAsync();
            }                    
        }      
    }
}
