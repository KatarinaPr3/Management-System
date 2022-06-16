using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Stores;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel.SalesEmployee
{
    public class SalesEmployeeViewModel : ViewModelBase
    {
        #region Members
        #endregion
        #region Constructor
        public SalesEmployeeViewModel(NavigationStore navigationStore, int empId)
        {
            InsertNewOrder = new NavigateCommand<SalesEmployeeInsertOrderViewModel>(navigationStore, () => new SalesEmployeeInsertOrderViewModel(navigationStore, empId));
            EmployeeId = empId;
            InsertNewCustomer = new NavigateCommand<SalesEmployeeInsertCustomerViewModel>(navigationStore, () => new SalesEmployeeInsertCustomerViewModel(navigationStore, empId));
            UpdateCustomerAddress = new NavigateCommand<SalesEmployeeUpdateCustomerAddressViewModel>(navigationStore, () => new SalesEmployeeUpdateCustomerAddressViewModel(navigationStore, empId));
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
        #endregion
        #region Properties
        public int EmployeeId { get; set; }

        #endregion
        #region Commands
        public ICommand InsertNewOrder { get; }
        public ICommand InsertNewCustomer { get; }
        public ICommand UpdateCustomerAddress { get; }
        public ICommand LogoutCommand { get; }
        #endregion
    }
}
