using AppGameStore.Models;
using ServiceReferenceGameStore;
using System.Collections.Generic;
using System.Linq;

namespace AppGameStore.Services
{
    public class MockDataStore : AbstractDataStore<Game>
    {
        public MockDataStore()
        {
            List<GameForView> listaGFV = GameStoreServices.GetGames(new GetGamesRequest()).GetGamesResult.ToList();
            items = new List<Game>(); //to dodać
            foreach (var k in listaGFV)
            {
                items.Add(new Game(k));
            }
     /* var _GamesServices = DependencyService.Get<IGameStoreService>();
            items = _GamesServices.GetGames(new GetGamesRequest()).
                GetGamesResult
                .Select(k => new Game(k))
             .ToList();
           */
        }

        public override void Add(Game item)
        {
            GameStoreServices.AddOrUpdateGame(new AddOrUpdateGameRequest(item));
        }

        public override Game Find(Game game)
        {
            return items.Where((Game arg) => arg.GameID == game.GameID).FirstOrDefault();
        }
        public override Game Find(int id)
        {
            return items.Where((Game arg) => arg.GameID == id).FirstOrDefault();
        }
        public override void Refresh()
        {
            List<GameForView> listaGFV =
                GameStoreServices.GetGames(new GetGamesRequest())
                .GetGamesResult
                .ToList();
            items = new List<Game>();
            foreach (var k in listaGFV)
            {
                items.Add(new Game(k));
            }
        }
    }
}