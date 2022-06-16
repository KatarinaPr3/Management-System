using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;
using System.Windows.Input;
using ProjekatTestWithBinding.Commands;

namespace ProjekatTestWithBinding.ViewModel
{
    public class SalesManagerOrdersViewModel : ViewModelBase
    {
        #region Members
        private ObservableCollection<Order> orders;
        #endregion
        #region Constructor
        public SalesManagerOrdersViewModel(NavigationStore navigationStore)
        {
            orders = new ObservableCollection<Order>();
            List<Order> ordersList = Order.GetAllOrders();
            foreach (Order order in ordersList)
            {
                Orders.Add(order);
            }
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            BackCommand = new NavigateCommand<SalesManagerViewModel>(navigationStore, () => new SalesManagerViewModel(navigationStore));
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
        #region Commands
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }
        #endregion
    }
}
