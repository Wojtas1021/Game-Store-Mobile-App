using AppGameStore.Models;
using AppGameStore.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppGameStore.ViewModels
{
    public class OrderDetailViewModel : BaseViewModel
    {
        public List<Employee> Employees
        {
            get
            {
                return DependencyService.Get<IDataStore<Employee>>().items;
            }
        }
        public List<Game> Games
        {
            get
            {
                return DependencyService.Get<IDataStore<Game>>().items;
            }
        }
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set => SetProperty(ref selectedEmployee, value);
        }
        private Game selectedGame;
        public Game SelectedGame
        {
            get => selectedGame;
            set => SetProperty(ref selectedGame, value);
        }

        private DateTime orderDate;
        public DateTime OrderDate
        {
            get => orderDate;
            set => SetProperty(ref orderDate, value);
        }
        private DateTime modifiedDate;
        public DateTime ModifiedDate
        {
            get => modifiedDate;
            set => SetProperty(ref modifiedDate, value);
        }


        private decimal? orderValueOfWorker;
        public decimal? OrderValueOfWorker
        {
            get => orderValueOfWorker;
            set => SetProperty(ref orderValueOfWorker, value);
        }

        private decimal? salesReportForGame;
        public decimal? SalesReportForGame
        {
            get => salesReportForGame;
            set => SetProperty(ref salesReportForGame, value);
        }

        private decimal? salesReport;
        public decimal? SalesReport
        {
            get => salesReport;
            set => SetProperty(ref salesReport, value);
        }

        public Command SalesReportForGameCommand { get; }
        public Command SalesReportCommand { get; }
        public Command OrderValueOfWorkerCommand { get; }

        public OrderDetailViewModel()
        {
            OrderDate = DateTime.Now.Date;
            ModifiedDate = DateTime.Now.Date;
            SalesReportForGameCommand = new Command(OnSalesReportForGame);
            SalesReportCommand = new Command(OnSalesReport);
            OrderValueOfWorkerCommand = new Command(OnOrderValueOfWorker);
            SalesReportForGame = 0;
            SalesReport = 0;
            OrderValueOfWorker = 0;
        }

        private void OnSalesReportForGame()
        {
            SalesReportForGame = new OrderDetailDataStore().SalesReportForGame(OrderDate, ModifiedDate, selectedGame.GameID);
        }

        private void OnSalesReport()
        {
            SalesReport = new OrderDetailDataStore().SalesReport(OrderDate, ModifiedDate);
        }

        private void OnOrderValueOfWorker()
        {
            OrderValueOfWorker = new OrderDetailDataStore().OrderValueOfWorker(selectedEmployee.EmployeeID);
        }
    }
}