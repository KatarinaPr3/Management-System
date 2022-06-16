using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Stores;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel
{
    public class LogisticManagerViewModel : ViewModelBase
    {
        #region Constructor
        public LogisticManagerViewModel(NavigationStore navigationStore)
        {
            ViewAllOrders = new NavigateCommand<LogisticManagerOrdersViewModel>(navigationStore, () => new LogisticManagerOrdersViewModel(navigationStore));
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
        #endregion
        #region Commands
        public ICommand ViewAllOrders { get; }
        public ICommand LogoutCommand { get; }
        #endregion
    }
}
