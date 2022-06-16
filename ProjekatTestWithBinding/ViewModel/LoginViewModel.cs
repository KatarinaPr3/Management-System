using System.Windows;
using System.Windows.Input;
using MicroMvvm;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;


namespace ProjekatTestWithBinding.ViewModel
{
    public  class LoginViewModel :  ViewModelBase
    {
        #region Members
        private NavigationStore navigation;
        private string username;
        private string password;
        #endregion
        #region Constructor
        public LoginViewModel(NavigationStore navigationStore)
        {
            navigation = navigationStore;          
        }
        #endregion
        #region Properties
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                RaisePropertyChanged("Username");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        #endregion
        #region Methods
        public void LoginMethod()
        {
            bool exist = UserQueries.ValidateUser(Username, Password);
            if (exist)
            {
                int employeeId = UserQueries.GetEmployeeID(Username);
                Role role = UserQueries.GetUserRole(Username);
                switch (role)
                {
                    case Role.SalesEmployee:
                        navigation.CurrentViewModel = new SalesEmployee.SalesEmployeeViewModel(navigation, employeeId);
                        break;
                    case Role.SalesManager:
                        navigation.CurrentViewModel = new SalesManagerViewModel(navigation);
                        break;
                    case Role.LogisticEmployee:
                        navigation.CurrentViewModel = new LogisticEmployeeViewModel(navigation);
                        break;
                    case Role.LogisticManager:
                        navigation.CurrentViewModel = new LogisticManagerViewModel(navigation);
                        break;
                    case Role.ProductsEmployee:
                        navigation.CurrentViewModel = new ProductsEmployeeViewModel(navigation);
                        break;
                    case Role.HREmployee:
                        navigation.CurrentViewModel = new HREmployeeVM(navigation);
                        break;
                    case Role.ProductsManager:
                        navigation.CurrentViewModel = new ProductsManagerViewModel(navigation);
                        break;
                    case Role.Admin:
                        navigation.CurrentViewModel = new Admin.AdminViewModel(navigation);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("User doesn't exist");
            }
        } 
        bool CanUpdate()
        {
            return true;
        }
        #endregion
        #region Commands
        public ICommand LoginBindingBtn { get { return new RelayCommand(LoginMethod, CanUpdate); } }
        #endregion
    }
}
