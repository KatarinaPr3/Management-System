using MyCommand;
using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel
{
    public class ProductsEmployeeUpdateSupplierViewModel : ViewModelBase
    {
        #region Members
        private ObservableCollection<Supplier> suppliers;
        private Supplier selectedSupplier;
        #endregion
        #region Constructor
        public ProductsEmployeeUpdateSupplierViewModel(NavigationStore navigationStore)
        {
            suppliers = Supplier.GetAllSuppliers();
            UpdateSupplierCommand = new CommandObject((s) => true, Update);
            DeleteSupplierCommand = new CommandObject((s) => true, Delete);
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            BackCommand = new NavigateCommand<ProductsEmployeeViewModel>(navigationStore, () => new ProductsEmployeeViewModel(navigationStore));
        }
        #endregion
        #region Properties
        public ObservableCollection<Supplier> Suppliers
        {
            get
            {
                return suppliers;
            }
            set
            {
                suppliers = value;
                OnPropertyChanged(nameof(Suppliers));
            }
        }
        public Supplier SelectedSupplier
        {
            get
            {
                return selectedSupplier;
            }
            set
            {
                selectedSupplier = value;
                OnPropertyChanged(nameof(SelectedSupplier));
            }
        }
        #endregion
        #region Methods
        private void Update(object obj)
        {
            Supplier.UpdateSupplier(SelectedSupplier);
            SelectedSupplier = new Supplier();
        }
        private void Delete(object obj)
        {
            Supplier.DeleteSupplier(SelectedSupplier);
            Suppliers.Remove(SelectedSupplier);
            SelectedSupplier = new Supplier();
        }
        #endregion
        #region Commands
        public ICommand UpdateSupplierCommand { get; set; }
        public ICommand DeleteSupplierCommand { get; set; }
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }
        #endregion
    }
}
