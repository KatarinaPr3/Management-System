using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Stores;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel
{
    public class SalesManagerViewModel : ViewModelBase
    {
        #region Constructor
        public SalesManagerViewModel(NavigationStore navigationStore)
        {
            ViewAllOrders = new NavigateCommand<SalesManagerOrdersViewModel>(navigationStore, () => new SalesManagerOrdersViewModel(navigationStore));
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
        #endregion
        #region Commands
        public ICommand ViewAllOrders { get; }
        public ICommand LogoutCommand { get;
        }
        #endregion
    }
}
