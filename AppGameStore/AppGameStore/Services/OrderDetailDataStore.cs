using ServiceReferenceGameStore;
using System;
using Xamarin.Forms;

namespace AppGameStore.Services
{
    class OrderDetailDataStore
    {
        public IGameStoreService GameStoreService { get; set; }
        public OrderDetailDataStore()
        {
            GameStoreService = DependencyService.Get<IGameStoreService>();
        }

        public decimal? SalesReport(DateTime fromDate, DateTime toDate)
        {
            return GameStoreService
                .SalesReport(new SalesReportRequest(fromDate, toDate))
                .SalesReportResult;
        }

        public decimal? SalesReportForGame(DateTime dateFrom, DateTime datoTo, int gameId)
        {
            return GameStoreService
                .SalesReportForGame(new SalesReportForGameRequest(dateFrom, datoTo, gameId))
                .SalesReportForGameResult;
        }

        public decimal? OrderValueOfWorker(int employeeID)
        {
            return GameStoreService
                .OrderValueOfWorker(new OrderValueOfWorkerRequest(employeeID))
                .OrderValueOfWorkerResult;
        }
    }
}
