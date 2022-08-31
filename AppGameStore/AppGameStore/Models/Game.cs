using AppGameStore.Utils;
using ServiceReferenceGameStore;
using System;

namespace AppGameStore.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Studio { get; set; }
        public string ShortDescription { get; set; }
        public string FotoUrl { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public decimal? Quantity { get; set; }

        public Game() { }
        //konstruktor mapujący
        public Game(GameForView game)
        {
            PropertyUtils.AutomatedCopyingConstructor(this, game);
        }
        public static implicit operator GameForView(Game game)
        {
            var res = new GameForView();
            res.AutomatedCopyingConstructor(game);
            return res;
        }
        public static implicit operator Game(GameForView game)
        {
            var res = new Game();
            res.AutomatedCopyingConstructor(game);
            return res;
        }
    }
}