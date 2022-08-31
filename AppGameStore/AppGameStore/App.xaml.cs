using AppGameStore.Services;
using Xamarin.Forms;

namespace AppGameStore
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<CustomerDataStore>();
            DependencyService.Register<ServiceReferenceGameStore.GameStoreServiceClient>();
            DependencyService.Register<EmployeeDataStore>();
            DependencyService.Register<CategoryDataStore>();
            DependencyService.Register<OrderDataStore>();
            DependencyService.Register<OrderDetailDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
