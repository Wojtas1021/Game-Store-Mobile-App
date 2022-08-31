using AppGameStore.Models;
using ServiceReferenceGameStore;
using System.Linq;

namespace AppGameStore.Services
{
    class OrderDataStore : AbstractDataStore<Order>
    {
        public OrderDataStore()
            : base()
        {

        }
        public override void Add(Order item)
        {
            GameStoreServices.AddOrUpdateOrder(new AddOrUpdateOrderRequest((OrderForView)item));
        }

        public override Order Find(Order item)
        {
            return items.FirstOrDefault(arg => arg.OrderID == item.OrderID);
        }
        public override Order Find(int id)
        {
            return items.FirstOrDefault(arg => arg.OrderID == id);
        }

        public override void Refresh()
        {
            items = GameStoreServices.GetOrders(new GetOrdersRequest())
                .GetOrdersResult
                .Select(item => new Order(item))
                .ToList();
        }
    }
}
