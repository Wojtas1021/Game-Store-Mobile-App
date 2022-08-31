using System;
using System.Collections.Generic;
using System.ServiceModel;
using WcfGameStore.ViewModel;

namespace WcfGameStore
{
    [ServiceContract]
    public interface IGameStoreService
    {
        [OperationContract]
        List<GameForView> GetGames();

        [OperationContract]
        List<GameForView> GetGameSortByName();
        
        [OperationContract]
        bool AddOrUpdateGame(GameForView game);

        [OperationContract]
        List<CustomerForView> GetCustomers();

        [OperationContract]
        List<CustomerForView> GetCustomerSortByName();

        [OperationContract]
        bool AddOrUpdateCustomer(CustomerForView customer);

        [OperationContract]
        bool AddOrUpdateEmployee(EmployeeForView employee);

        [OperationContract]
        List<EmployeeForView> GetEmployees();

        [OperationContract]
        List<EmployeeForView> GetEmployeeSortByName();

        [OperationContract]
        List<OrderForView> GetOrders();

        [OperationContract]
        List<OrderForView> GetOrderSortByOrderNumber();

        [OperationContract]
        bool AddOrUpdateOrder(OrderForView order);

        [OperationContract]
        List<CategoryForView> GetCategories();

        [OperationContract]
        List<CategoryForView> GetCategorySortByName();

        [OperationContract]
        bool AddOrUpdateCategory(CategoryForView category);

        [OperationContract]
        List<GameTypeForView> GetGameTypes();

        [OperationContract]
        bool AddOrUpdateGameType(GameTypeForView gameType);

        [OperationContract]
        List<PaymentMethodForView> GetPaymentMethods();

        [OperationContract]
        bool AddOrUpdatePaymentMethod(PaymentMethodForView paymentMethod);
      
        [OperationContract]
        List<OrderDetailForView> GetOrderDetail();

        [OperationContract]
        decimal? SalesReportForGame(DateTime dateFrom, DateTime datoTo, int gameId);

        [OperationContract]
        decimal? OrderValueOfWorker(int employeeID);

        [OperationContract]
        decimal? SalesReport(DateTime orderDate, DateTime deliverDate);

    }
}
