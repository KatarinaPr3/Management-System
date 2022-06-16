using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Stores;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel
{
    public class ProductsManagerViewModel : ViewModelBase
    {
        #region Constructor
        public ProductsManagerViewModel(NavigationStore navigationStore)
        {
            ViewAllOrders = new NavigateCommand<ProductsManagerOrdersViewModel>(navigationStore, () => new ProductsManagerOrdersViewModel(navigationStore));
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
        #endregion
        #region Commands
        public ICommand ViewAllOrders { get; }
        public ICommand LogoutCommand { get; }
        #endregion
    }
}
