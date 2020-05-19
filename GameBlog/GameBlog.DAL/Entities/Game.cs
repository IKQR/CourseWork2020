using System;
using System.ComponentModel;

namespace GameBlog.DAL.Entities
{
    public class Game
    {
        public Int64 Id { get; set; }
        public Int64 SteamId { get; set; }
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool Permitted { get; set; }
    }
}