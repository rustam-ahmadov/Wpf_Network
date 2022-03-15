using Client.Services;
using Client.View;
using Client.ViewModel;
using SimpleInjector;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public partial class App : Application
    {
        private readonly Container Container = new();

        private void SetServices()
        {
            Container.RegisterSingleton<INetworkService, NetworkSevice>();
            Container.RegisterSingleton<MainViewModel>();
        }
       
        private void SetMainWindow()
        {          
            MainView window = new();
            window.DataContext = Container.GetInstance<MainViewModel>();
            window.Show();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetServices();
            SetMainWindow();
        }



    }
}
