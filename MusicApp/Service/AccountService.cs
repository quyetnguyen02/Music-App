using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MusicApp.Config;
using MusicApp.Entity;
using Newtonsoft.Json;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace MusicApp.Service
{
   public class AccountService
    {
        private const string TokenFileName = "credential.txt";
        public async Task<bool> Register(Account account)
        {
            var jsonString = JsonConvert.SerializeObject(account);

            HttpClient httpClient = new HttpClient();
            HttpContent contentToSend = new StringContent(jsonString, Encoding.UTF8, ApiConfig.MediaType);
            var result = await httpClient.PostAsync($"{ApiConfig.ApitDomain}{ApiConfig.AccountPath}", contentToSend);
            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Credential> Login(LoginViewModel loginView)
        {
            var jsonString = JsonConvert.SerializeObject(loginView);
            using (HttpClient httpClient = new HttpClient())
            {
                HttpContent contentToSend = new StringContent(jsonString, Encoding.UTF8, ApiConfig.MediaType);
                var result = await httpClient.PostAsync($"{ApiConfig.ApitDomain}{ApiConfig.AccountLogin}", contentToSend);
                var content = await result.Content.ReadAsStringAsync();
                Debug.WriteLine($"Response {content} - {result.StatusCode}");
                if(result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                   SaveTokenAsync(content);
                    return JsonConvert.DeserializeObject<Credential>(content);

                }
                else
                {
                    return null;
                }
              
            }
           
        }

        public async Task<Account> GetLoggedAccountAsync()
        {
            Account account ;
            Credential credential = await LoadToken();
            if(credential == null)
            {
                return null;
            }
            App.currentCredential = credential;
            account= await GetAccountInformation(credential.access_token);
        
               return account;
        }

        private async Task SaveTokenAsync(string content)
        {
            // Create sample file; replace if exists.
            Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync(TokenFileName,
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);
            FileIO.WriteTextAsync(sampleFile, content);
        }

        public async Task<Account> GetAccountInformation(string token)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var result = await httpClient.GetAsync($"{ApiConfig.ApitDomain}{ApiConfig.AccountPath}");
                var content = await result.Content.ReadAsStringAsync();
                Debug.WriteLine($"Response {content} - {result.StatusCode}");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Account account = JsonConvert.DeserializeObject<Account>(content);
                    return account;

                }
                else
                {
                    return null;

                }
            }

        }

        private async Task<Credential> LoadToken()
        {
            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile storageFile = await storageFolder.GetFileAsync(TokenFileName);

                string tokenString = await FileIO.ReadTextAsync(storageFile);
                Credential credential = JsonConvert.DeserializeObject<Credential>(tokenString);

                return credential;
            }catch(Exception ex)
            {
                return null;
            }
           
            
        }

        public async void logOut()
        {
           
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile storageFile = await storageFolder.GetFileAsync(TokenFileName);
                 storageFile.DeleteAsync();
                          
        }
    }
}
