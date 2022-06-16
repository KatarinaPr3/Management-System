using MyCommand;
using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel.SalesEmployee
{
    public class SalesEmployeeInsertCustomerViewModel : ViewModelBase 
    {
        #region Members
        private Customer customer;
        #endregion
        #region Constructor

        public SalesEmployeeInsertCustomerViewModel(NavigationStore navigationStore, int empId)
        {
            customer = new Customer();
            Save = new CommandObject((s) => true, SaveCustomer);
            EmpId = empId;
            UpdateAddress = new NavigateCommand<SalesEmployeeUpdateCustomerAddressViewModel>(navigationStore, () => new SalesEmployeeUpdateCustomerAddressViewModel(navigationStore, empId));
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            BackCommand = new NavigateCommand<SalesEmployeeViewModel>(navigationStore, () => new SalesEmployeeViewModel(navigationStore, empId));
        }
        #endregion
        #region Properties
        public int EmpId { get; set; }
        public Customer CustomerAdding
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
                OnPropertyChanged(nameof(CustomerAdding));
            }
        }
        #endregion
        #region Methods

        private void SaveCustomer(object obj)
        {
            Customer.SaveCustomer(CustomerAdding);
            CustomerAdding = new Customer();
        }
       
        #endregion
        #region Commands

        public ICommand Save { get;set; }
        public ICommand UpdateAddress { get; }
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }
        #endregion
    }
}
