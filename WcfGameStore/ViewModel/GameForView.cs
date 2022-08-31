using System;
using System.Runtime.Serialization;
using WcfGameStore.Model.Entities;
using WcfGameStore.Utils;

namespace WcfGameStore.ViewModel
{
    [DataContract]
    public class GameForView
    {
        [DataMember]
        public int GameID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Studio { get; set; }
        [DataMember]
        public string ShortDescription { get; set; }
        [DataMember]
        public string FotoUrl { get; set; }
        [DataMember]
        public decimal? Price { get; set; }
        [DataMember]
        public DateTime? CreationDate { get; set; }
        [DataMember]
        public DateTime? ModifiedDate { get; set; }
        [DataMember]
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        [DataMember]
        public decimal? Quantity { get; set; }

        public GameForView() { }
        //konstruktor mapujący
        public GameForView(Game game)
        {
            PropertyUtils.AutomatedCopyingConstructor(this, game);
        }
        public static implicit operator Game(GameForView game)
        {
            var res = new Game();
            res.AutomatedCopyingConstructor(game);
            return res;
        }

        public static implicit operator GameForView(Game game)
        {
            var res = new GameForView(game);
            return res;
        }
    }
}