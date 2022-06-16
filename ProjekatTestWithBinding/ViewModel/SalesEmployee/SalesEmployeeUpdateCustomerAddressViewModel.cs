using MyCommand;
using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel.SalesEmployee
{

    public class SalesEmployeeUpdateCustomerAddressViewModel : ViewModelBase
    {
        #region Members
        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;
        #endregion
        #region Constructor
        public SalesEmployeeUpdateCustomerAddressViewModel(NavigationStore navigationStore, int empId)
        {
            EmpId = empId;
            customers = Customer.GetAllCustomers();
            UpdateCustomerCommand = new CommandObject((s) => true, UpdateAddress);
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            BackCommand = new NavigateCommand<SalesEmployeeViewModel>(navigationStore, () => new SalesEmployeeViewModel(navigationStore, empId));
        }
        #endregion
        #region Properties
        public int EmpId { get; set; }
        public ObservableCollection<Customer> Customers
        {
            get
            {
                return customers;
            }
            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }
        public Customer SelectedCustomer
        {
            get
            {
                return selectedCustomer;
            }
            set
            {
                selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }
        #endregion
        #region Methods
        private void UpdateAddress(object obj)
        {
            Customer.UpdateCustomer(SelectedCustomer);
            SelectedCustomer = new Customer();
        }

        #endregion
        #region Commands
        public ICommand UpdateCustomerCommand { get; set; }
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }
        #endregion
    }
}
