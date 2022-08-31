using System;
using System.Runtime.Serialization;
using WcfGameStore.Model.Entities;
using WcfGameStore.Utils;

namespace WcfGameStore.ViewModel
{
    [DataContract]
    public class GameTypeForView
    {
        [DataMember]
        public int GameID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public GameTypeForView() { }
        //konstruktor mapujący
        public GameTypeForView(GameType gameType)
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