using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace SteamGamesAPI
{
    public static class Getter
    {
        public static string Url = "https://api.steampowered.com/ISteamApps/GetAppList/v2/";
        public static HttpWebResponse GetResponse()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(Url));
            request.Method = "GET";
            return (HttpWebResponse)request.GetResponse();
        }
        public static IEnumerable<SteamGame> GetAll()
        {
            string jsonString = "";

            using (Stream stream = GetResponse().GetResponseStream())
                jsonString =
                    new StreamReader(stream, System.Text.Encoding.UTF8).ReadToEnd();
            var appList = JsonConvert.DeserializeObject<AppList>(jsonString);
            return appList.applist.apps;
        }
    }
}
