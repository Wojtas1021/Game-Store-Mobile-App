using AppGameStore.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace AppGameStore.ViewModels
{
    [QueryProperty(nameof(GameID), nameof(GameID))]
    public class GameDetailViewModel : BaseAViewModel<Game>
    {
        private int gameId;
        private string title;
        private string shortDescription;
        public int Id { get; set; }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string ShortDescription
        {
            get => shortDescription;
            set => SetProperty(ref shortDescription, value);
        }

        public int GameID
        {
            get
            {
                return gameId;
            }
            set
            {
                gameId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                GameID = item.GameID;
                Title = item.Title;
                ShortDescription = item.ShortDescription;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
