using System.Collections.Generic;
using WcfGameStore.Model.Entities;
using WcfGameStore.ViewModel;
using System.Linq;
using System;
using WcfGameStore.Utils;

namespace WcfGameStore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GameStoreService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GameStoreService.svc or GameStoreService.svc.cs at the Solution Explorer and start debugging.
    public class GameStoreService : IGameStoreService
    {
        public List<GameForView> GetGames()
        {
            var db = new GameStoreEntities();
            var query = from game in db.Game select game;

            //w tym miejscu zapytanie dopiero działa
            return query.ToList()
                .Select(game => new GameForView(game))
                .ToList();
        }

        /*
        Wyrażenie lambda
        game = game.Title
        to jest równoznaczne
        funkcja(game){
        return game.Title
        }
        ()=> {}
        
        pobieramy dane z bazy danych za pomocą linq (system tworzenia zaytan na bazach danych i kolekcjach)
         */
        public List<GameForView> GetGameSortByName()
        {
            var db = new GameStoreEntities();
            var query = from game in db.Game select game;

            return query
                .OrderBy(game => game.Title)//zapytanie sql dopiero wykonywane na liście / sortowanie po stronie sql - w zapytaniu powyżej sortowanie po stronie c#
                .ToList()                           //.ToList()
                                                    //.Select(game => new GameForView(game))//towrzy nową listę
                .Select(game => new GameForView(game))
                //.AsNoTracking() // przyspiesza pobieranie z bazy danych - używać w funkcji, która nie modyfikuje obiektu
                .ToList();
        }
        public List<CustomerForView> GetCustomers()
        {
            var db = new GameStoreEntities();
            var query = from customer in db.Customer select customer;

            return query
                    .ToList()
                    .Select(customer => new CustomerForView(customer))
                    .ToList();
        }
        public List<CustomerForView> GetCustomerSortByName()
        {
            var db = new GameStoreEntities();
            var query = from customer in db.Customer
                        orderby customer.Name
                        select customer;
            return query
                    .ToList()
                    .Select(customer => new CustomerForView(customer))
                    .ToList();
        }

        public bool AddOrUpdateGame(GameForView game)
        {
            try
            {
                var db = new GameStoreEntities();

                if (game.GameID != 0 && db.Game.Any(a => a.GameID == game.GameID))
                {
                    var modified = db.Game.FirstOrDefault(a => a.GameID == game.GameID);
                    modified.AutomatedCopyingConstructor(game);
                    db.Entry(modified).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                db.Game.Add(game);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occured {e.Message}");
                return false;
            }
        }

        public bool AddOrUpdateCustomer(CustomerForView customer)
        {
            try
            {
                var db = new GameStoreEntities();

                if (customer.CustomerID != 0 && db.Customer.Any(a => a.CustomerID == customer.CustomerID))
                {
                    var modified = db.Customer.FirstOrDefault(a => a.CustomerID == customer.CustomerID);
                    modified.AutomatedCopyingConstructor(customer);
                    db.Entry(modified).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                db.Customer.Add(customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occured {e.Message}");
                return false;
            }
        }

        public bool AddOrUpdateEmployee(EmployeeForView employee)
        {
            try
            {
                var db = new GameStoreEntities();

                if (employee.EmployeeID != 0 && db.Employee.Any(a => a.EmployeeID == employee.EmployeeID))
                {
                    var modified = db.Employee.FirstOrDefault(a => a.EmployeeID == employee.EmployeeID);
                    modified.AutomatedCopyingConstructor(employee);
                    db.Entry(modified).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                db.Employee.Add(employee);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occured {e.Message}");
                return false;
            }
        }

        public List<EmployeeForView> GetEmployees()
        {
            var db = new GameStoreEntities();
            var query = from employee in db.Employee select employee;
            return query
                    .ToList()
                    .Select(employee => new EmployeeForView(employee))
                    .ToList();
        }

        public List<EmployeeForView> GetEmployeeSortByName()
        {
            var db = new GameStoreEntities();
            var query = from employee in db.Employee
                        orderby employee.Name + employee.Surname
                        select employee;
            return query
                    .ToList()
                    .Select(employee => new EmployeeForView(employee))
                    .ToList();
        }

        public List<OrderForView> GetOrders()
        {
            var db = new GameStoreEntities();
            var query = from order in db.Order select order;
            return query
                    .ToList()
                    .Select(order => new OrderForView(order))
                    .ToList();
        }

        public List<OrderForView> GetOrderSortByOrderNumber()
        {
            var db = new GameStoreEntities();
            var query = from order in db.Order
                        orderby order.OrderNumber
                        select order;
            return query
                    .ToList()
                    .Select(order => new OrderForView(order))
                    .ToList();
        }

        public bool AddOrUpdateOrder(OrderForView order)
        {
            try
            {
                var db = new GameStoreEntities();
                if (order.OrderID != 0
                    && db.Order.Any(a => a.OrderID == order.OrderID))
                {
                    var OrderModified = db.Order.Find(order.OrderID);
                    OrderModified.AutomatedCopyingConstructor(order);
                    db.Entry(OrderModified).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                var orderToAdd = (Order)order;
                db.Order.Add(orderToAdd);
                db.SaveChanges();
                if (order?.OrderDetail?.Any() == true)
                {
                    foreach (var item in order?.OrderDetail)
                    {
                        item.OrderID = orderToAdd.OrderID;
                        db.OrderDetail.Add((OrderDetail)item);
                    }
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception during adding or updating order {e.Message}");
                return false;
            }
        }

        public List<CategoryForView> GetCategories()
        {
            var db = new GameStoreEntities();
            var query = from category in db.Category select category;
            return query
                    .ToList()
                    .Select(category => new CategoryForView(category))
                    .ToList();
        }

        public List<CategoryForView> GetCategorySortByName()
        {
            var db = new GameStoreEntities();
            var query = from category in db.Category
                        orderby category.Name
                        select category;
            return query
                    .ToList()
                    .Select(category => new CategoryForView(category))
                    .ToList();
        }

        public bool AddOrUpdateCategory(CategoryForView category)
        {
            try
            {
                var db = new GameStoreEntities();

                if (category.CategoryID != 0 && db.Category.Any(a => a.CategoryID == category.CategoryID))
                {
                    var modified = db.Category.FirstOrDefault(a => a.CategoryID == category.CategoryID);
                    modified.AutomatedCopyingConstructor(category);
                    db.Entry(modified).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                db.Category.Add(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occured {e.Message}");
                return false;
            }
        }

        public List<GameTypeForView> GetGameTypes()
        {
            var db = new GameStoreEntities();
            var query = from gameType in db.GameType select gameType;
            return query
                    .ToList()
                    .Select(gameType => new GameTypeForView(gameType))
                    .ToList();
        }

        public bool AddOrUpdateGameType(GameTypeForView gameType)
        {
            try
            {
                var db = new GameStoreEntities();

                if (gameType.GameID != 0 && db.GameType.Any(a => a.GameID == gameType.GameID))
                {
                    var modified = db.GameType.FirstOrDefault(a => a.GameID == gameType.GameID);
                    modified.AutomatedCopyingConstructor(gameType);
                    db.Entry(modified).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                db.GameType.Add(gameType);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occured {e.Message}");
                return false;
            }
        }
        public List<PaymentMethodForView> GetPaymentMethods()
        {
            var db = new GameStoreEntities();
            var query = from paymentMethod in db.PaymentMethod select paymentMethod;
            return query
                    .ToList()
                    .Select(paymentMethod => new PaymentMethodForView(paymentMethod))
                    .ToList();
        }
        public bool AddOrUpdatePaymentMethod(PaymentMethodForView paymentMethod)
        {
            try
            {
                var db = new GameStoreEntities();

                if (paymentMethod.PaymentMethodID != 0 && db.PaymentMethod.Any(a => a.PaymentMethodID == paymentMethod.PaymentMethodID))
                {
                    var modified = db.PaymentMethod.FirstOrDefault(a => a.PaymentMethodID == paymentMethod.PaymentMethodID);
                    modified.AutomatedCopyingConstructor(paymentMethod);
                    db.Entry(modified).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                db.PaymentMethod.Add(paymentMethod);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occured {e.Message}");
                return false;
            }
        }
        private IQueryable<OrderDetail> _orderPriceQuery(GameStoreEntities db)
        {
            return from orderDetail
                    in db.OrderDetail
                   select orderDetail;
        }
        public List<OrderDetailForView> GetOrderDetail()
        {
            var db = new GameStoreEntities();
            var query = from orderDetail in db.OrderDetail select orderDetail;

            //w tym miejscu zapytanie dopiero działa
            return query.ToList()
                .Select(orderDetail => new OrderDetailForView(orderDetail))
                .ToList();
        }

        public decimal? SalesReportForGame(DateTime dateFrom, DateTime dateTo, int gameId)
        {
            var db = new GameStoreEntities();
            var query = (from orderDetail in db.OrderDetail
                         where (orderDetail.Game.GameID == gameId) &&
                             orderDetail.Order.OrderDate >= dateFrom &&
                             orderDetail.Order.ModifiedDate <= dateTo
                         select orderDetail.Quantity * ((orderDetail.NetPrice * orderDetail.Tax) + orderDetail.NetPrice)
            ).Sum();
            return query;
        }
        public decimal? SalesReport(DateTime orderDate, DateTime deliverDate)
        {
                var db = new GameStoreEntities();
            var query = (from orderDetail in db.OrderDetail
                         where
                             orderDetail.Order.OrderDate >= orderDate &&
                             orderDetail.Order.ModifiedDate <= deliverDate
                         select orderDetail.Quantity * orderDetail.NetPrice + (orderDetail.Tax * orderDetail.NetPrice)
                ).Sum();
            return query;
        }

        public decimal? OrderValueOfWorker(int employeeID)
        {
            var db = new GameStoreEntities();
            return _orderPriceQuery(db)
                    .Where(orderDetail => orderDetail.Order.EmployeeID == employeeID)
                    .Sum(item => item.Quantity * item.NetPrice + (item.NetPrice * item.Tax));
        }
    }
}
