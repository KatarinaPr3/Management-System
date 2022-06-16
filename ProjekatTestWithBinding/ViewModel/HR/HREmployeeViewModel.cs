using System;
using System.Windows.Input;
using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Stores;

namespace ProjekatTestWithBinding.ViewModel
{
    public class HREmployeeVM : ViewModelBase
    {
        #region Constructor
        public HREmployeeVM(NavigationStore _navigationStore)
        {
            InsertingNewEmployee = new NavigateCommand<HREmployeeInsertViewModel>(_navigationStore, () => new HREmployeeInsertViewModel(_navigationStore));
            UpdateEmployees = new NavigateCommand<HREmployeeUpdateViewModel>(_navigationStore, () => new HREmployeeUpdateViewModel(_navigationStore));
            LogoutCommand = new NavigateCommand<LoginViewModel>(_navigationStore, () => new LoginViewModel(_navigationStore));
        }
        #endregion
        #region Commands
        public ICommand InsertingNewEmployee { get; }
        public ICommand UpdateEmployees { get; }
        public ICommand LogoutCommand { get; }
        #endregion
    }
}
