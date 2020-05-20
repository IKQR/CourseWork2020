﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBlog.CRUD.Abstracts;
using GameBlog.DAL.Entities;
using SteamGamesAPI;

namespace GameBlog.Initializer
{
    public class GamesInitializer
    {
        public static async Task InitializeAsync(GameRepository repo)
        {
            Game game = new Game();
            var allGames = Getter.GetAll()
                .Where(g => 
                    !g.Name.ToUpper().Contains("TEST") && 
                    !g.Name.ToUpper().Contains("DLC") &&
                    !g.Name.ToUpper().Contains("OST") 
                    )
                .OrderBy(g => g.Id)
                .Take(200);
            foreach (SteamGame steamGame in allGames)
            {
                repo.Create(new Game()
                {
                    Name = steamGame.Name,
                    SteamId = steamGame.Id,
                    Permitted = true
                });
            }
        }
    }
}
