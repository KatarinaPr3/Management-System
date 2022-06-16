using ProjekatTestWithBinding.Stores;
using System.Collections.Generic;
using ProjekatTestWithBinding.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ProjekatTestWithBinding.Commands;

namespace ProjekatTestWithBinding.ViewModel
{
    public class LogisticManagerOrdersViewModel : ViewModelBase
    {
        #region Members
        private ObservableCollection<Order> orders;
        #endregion
        #region Constructor
        public LogisticManagerOrdersViewModel(NavigationStore navigationStore)
        {
            orders = new ObservableCollection<Order>();
            List<Order> ordersList = Order.GetAllOrders();
            foreach (Order order in ordersList)
            {
                Orders.Add(order);
            }
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            BackCommand = new NavigateCommand<LogisticManagerViewModel>(navigationStore, () => new LogisticManagerViewModel(navigationStore));
        }
        #endregion
        #region Properties
        public ObservableCollection<Order> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
            }
        }
        #endregion
        #region Methods
        #endregion
        #region Commands
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }
        #endregion
    }
}
