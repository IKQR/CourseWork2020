﻿using System.ComponentModel;

namespace GameBlog.DAL.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public int SteamId { get; set; }
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool Permitted { get; set; }
    }
}