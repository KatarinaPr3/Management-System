using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Stores;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel
{
    public class ProductsEmployeeViewModel : ViewModelBase
    {
        #region Constructor
        public ProductsEmployeeViewModel(NavigationStore navigationStore)
        {
            InsertProduct = new NavigateCommand<ProductsEmployeeInsertProductViewModel>(navigationStore, () => new ProductsEmployeeInsertProductViewModel(navigationStore));
            UpdateProduct = new NavigateCommand<ProductsEmployeeUpdateProductViewModel>(navigationStore, () => new ProductsEmployeeUpdateProductViewModel(navigationStore));
            InsertSupplier = new NavigateCommand<ProductsEmployeeInsertSupplierViewModel>(navigationStore, () => new ProductsEmployeeInsertSupplierViewModel(navigationStore));
            UpdateSupplier = new NavigateCommand<ProductsEmployeeUpdateSupplierViewModel>(navigationStore, () => new ProductsEmployeeUpdateSupplierViewModel(navigationStore));
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
        #endregion
        #region Commands
        public ICommand InsertProduct { get; }
        public ICommand UpdateProduct { get; }
        public ICommand InsertSupplier { get; }
        public ICommand UpdateSupplier { get; }
        public ICommand LogoutCommand { get; }
        #endregion
    }
}
