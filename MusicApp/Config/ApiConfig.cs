using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Config
{
    class ApiConfig
    {
        public static string ApitDomain = "https://music-i-like.herokuapp.com";
        public static string AccountPath = "/api/v1/accounts";
        public static string SongPath = "/api/v1/songs";
        public static string MySongPath = "/api/v1/songs/mine";
       
        public static string AccountLogin = "/api/v1/accounts/authentication";
        public static string MediaType = "application/json";
    }
}
