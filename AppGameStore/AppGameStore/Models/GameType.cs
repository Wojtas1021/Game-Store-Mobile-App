using AppGameStore.Utils;
using ServiceReferenceGameStore;
using System;

namespace AppGameStore.Models
{
    public class GameType
    {
        public int GameID { get; set; }
        public int CategoryID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public GameType() { }
        //konstruktor mapujący
        public GameType(GameType gameType)
        {
            PropertyUtils.AutomatedCopyingConstructor(this, gameType);
        }
        public static implicit operator GameType(GameTypeForView gameType)
        {
            var res = new GameType();
            res.AutomatedCopyingConstructor(gameType);
            return res;
        }

        public static implicit operator GameTypeForView(GameType gameType)
        {
            var res = new GameTypeForView();
            res.AutomatedCopyingConstructor(gameType);
            return res;
        }
    }
}
