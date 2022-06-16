using ProjekatTestWithBinding.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProjekatTestWithBinding.Model;
using System.Windows.Input;
using MyCommand;
using ProjekatTestWithBinding.Commands;

namespace ProjekatTestWithBinding.ViewModel
{
    public class LogisticEmployeeViewAllShippersViewModel : ViewModelBase
    {
        #region Members
        private ObservableCollection<Shipper> shippers;
        private List<Shipper> shippersList;
        private Shipper shipper;
        private Shipper selectedShipper;
        #endregion
        #region Constructor
        public LogisticEmployeeViewAllShippersViewModel(NavigationStore navigation)
        {
            shippers = new ObservableCollection<Shipper>();
            shippersList = Shipper.GetAllShippers();
            foreach (Shipper shipper in shippersList)
            {
                shippers.Add(shipper);
            }
            UpdateShipperCommand = new CommandObject((s) => true, UpdateShipper);
            DeleteShipperCommand = new CommandObject((s) => true, DeleteShipper);
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigation, () => new LoginViewModel(navigation));
            BackCommand = new NavigateCommand<LogisticEmployeeViewModel>(navigation, () => new LogisticEmployeeViewModel(navigation));
        }
        #endregion
        #region Properties
        public ObservableCollection<Shipper> Shippers
        {
            get
            {
                return shippers;
            }
            set
            {
                shippers = value;
                OnPropertyChanged("Shippers");
            }
        }
        public Shipper Shipper
        {
            get
            {
                return shipper;
            }
            set
            {
                shipper = value;
                OnPropertyChanged(nameof(Shipper));
            }
        }
        public Shipper SelectedShipper
        {
            get
            {
                return selectedShipper;
            }
            set
            {
                selectedShipper = value;
                OnPropertyChanged(nameof(SelectedShipper));
            }
        }
        #endregion
        #region Methods
        private void UpdateShipper(object obj)
        {
            Shipper.UpdateShipper(SelectedShipper);
            SelectedShipper = new Shipper();
        }
        private void DeleteShipper(object obj)
        {
            Shipper.DeleteShipper(SelectedShipper);
            Shippers.Remove(SelectedShipper);
            SelectedShipper = new Shipper();
            
        }
        #endregion
        #region Commands
        public ICommand UpdateShipperCommand { get; set; }
        public ICommand DeleteShipperCommand { get; set; }
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }

        #endregion
    }
}
