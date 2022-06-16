using ProjekatTestWithBinding.Stores;
using ProjekatTestWithBinding.Model;
using System.Windows.Input;
using ProjekatTestWithBinding.Commands;
using MicroMvvm;

namespace ProjekatTestWithBinding.ViewModel
{
    public class LogisticEmployeeInsertViewModel : ViewModelBase
    {
        #region  Members
        Shipper shipperAdding;
        #endregion
        #region Constructor
        public LogisticEmployeeInsertViewModel(NavigationStore navigation)
        {
            shipperAdding = new Shipper();
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigation, () => new LoginViewModel(navigation));
            BackCommand = new NavigateCommand<LogisticEmployeeViewModel>(navigation, () => new LogisticEmployeeViewModel(navigation));
        }
        #endregion
        #region Properties
        public Shipper ShipperAdding
        {
            get
            {
                return shipperAdding;
            }
            set
            {
                shipperAdding = value;
                OnPropertyChanged(nameof(ShipperAdding));
            }
        }
        #endregion
        #region Methods
        public void SaveShipper()
        {
         
            Shipper.SaveShipper(ShipperAdding);
            ShipperAdding = new Shipper();
        }
        bool CanUpdate()
        {
            return true;
        }
        #endregion
        #region Commands
        public ICommand Save { get { return new RelayCommand(SaveShipper, CanUpdate); } }
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }
        #endregion
    }
}
