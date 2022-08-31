using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppGameStore.Services
{
    //odpowiada za komunikacje między viewModelem a servisem zewnętrznym
    public interface IDataStore<T>
    {
        List<T> items { get; set; }
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
