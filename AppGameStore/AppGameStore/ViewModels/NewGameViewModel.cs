using AppGameStore.Models;
using System;

namespace AppGameStore.ViewModels
{
    public class NewGameViewModel : ANewItemViewModel<Game>
    {
        private string title;
        private string code;
        private string studio;
        private string shortDescription;
        private string fotoUrl;
        private decimal? price;
        private decimal? quantity;
        private DateTime? creationDate;
        private DateTime? modifiedDate;
        private string notes;
        public NewGameViewModel()
            : base()
        {

        }
        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(shortDescription);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string Code
        {
            get => code;
            set => SetProperty(ref code, value);
        }
        public string Studio
        {
            get => studio;
            set => SetProperty(ref studio, value);
        }
        public string ShortDescription
        {
            get => shortDescription;
            set => SetProperty(ref shortDescription, value);
        }
        public string FotoUrl
        {
            get => fotoUrl;
            set => SetProperty(ref fotoUrl, value);
        }
        public decimal? Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        public decimal? Quantity
        {
            get => quantity;
            set => SetProperty(ref quantity, value);
        }
        public DateTime? CreationDate
        {
            get => creationDate;
            set => SetProperty(ref creationDate, value);
        }
        public DateTime? ModifiedDate
        {
            get => modifiedDate;
            set => SetProperty(ref modifiedDate, value);
        }
        public string Notes
        {
            get => notes;
            set => SetProperty(ref notes, value);
        }
        public override Game SetItem()
        {
            Game newGame = new Game()
            {
                Title = Title,
                ShortDescription = ShortDescription
            };
            return newGame;
        }
    }
}