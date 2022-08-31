using ServiceReferenceGameStore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppGameStore.Services
{
    public abstract class AbstractDataStore<T> : IDataStore<T>
    {
        public IGameStoreService GameStoreServices { get; set; }
        public List<T> items { get; set; }
        public AbstractDataStore()
        {
            GameStoreServices = DependencyService.Get<IGameStoreService>();
            Refresh();
        }

        public abstract void Add(T item);
        public async Task<bool> AddItemAsync(T item)
        {
            Add(item);
            Refresh();
            return await Task.FromResult(true);
        }
        public abstract T Find(T item);
        public abstract T Find(int id);
        public abstract void Refresh();

        public async Task<bool> UpdateItemAsync(T item)
        {
            var oldItem = Find(item);
            items.Remove(oldItem);
            items.Add(item);
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Find(id);
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }
        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(Find(id));
        }
        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }

}
