using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SteamGamesAPI
{
    public class SteamGame
    {
        [JsonProperty] private Int64 appid;
        [JsonProperty] private string name;

        public Int64 Id => appid;
        public string Name => name;

    }

    public class Apps
    {
        public SteamGame[] apps { get; set; }
    }
    public class AppList
    {
        public Apps applist { get; set; }
    }
}
