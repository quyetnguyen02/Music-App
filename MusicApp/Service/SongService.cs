using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MusicApp.Config;
using MusicApp.Entity;
using Newtonsoft.Json;
using Windows.UI.Xaml.Controls;

namespace MusicApp.Service
{
    class SongService
    {
        public void create()
        {

        }

        public async Task<List<Song>> GetListAsync() {
            List<Song> listSong = new List<Song>();
            using (HttpClient httpClient = new HttpClient())
            {
              
                var result = await httpClient.GetAsync($"{ApiConfig.ApitDomain}{ApiConfig.SongPath}");
                var content = await result.Content.ReadAsStringAsync();
                Debug.WriteLine($"Response {content} - {result.StatusCode}");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                   
                    listSong= JsonConvert.DeserializeObject<List<Song>>(content);

                }
                else
                {
                    Debug.WriteLine("Error 500");

                }

            }
            return listSong;
        }


    }
}
