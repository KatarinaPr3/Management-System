using ProjekatTestWithBinding.Stores;
using ProjekatTestWithBinding.ViewModel;
using System.Windows;

namespace ProjekatTestWithBinding
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigation = new NavigationStore();
            navigation.CurrentViewModel = new LoginViewModel(navigation);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigation)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
