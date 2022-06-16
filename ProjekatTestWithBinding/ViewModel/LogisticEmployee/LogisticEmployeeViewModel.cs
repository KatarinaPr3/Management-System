using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Stores;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel
{
    public class LogisticEmployeeViewModel : ViewModelBase
    {
        #region Constructor
        public LogisticEmployeeViewModel(NavigationStore navigation)
        {
            InsertNewShipper = new NavigateCommand<LogisticEmployeeInsertViewModel>(navigation, () => new LogisticEmployeeInsertViewModel(navigation));
            ViewShippers = new NavigateCommand<LogisticEmployeeViewAllShippersViewModel>(navigation, () => new LogisticEmployeeViewAllShippersViewModel(navigation));
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigation, () => new LoginViewModel(navigation));
        }
        #endregion
        #region Commands 
        public ICommand InsertNewShipper { get; }
        public ICommand ViewShippers { get; }
        public ICommand LogoutCommand { get; }
        #endregion
    }
}
