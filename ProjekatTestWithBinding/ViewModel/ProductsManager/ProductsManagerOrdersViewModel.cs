using ProjekatTestWithBinding.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProjekatTestWithBinding.Model;
using System.Windows.Input;
using ProjekatTestWithBinding.Commands;

namespace ProjekatTestWithBinding.ViewModel
{
    public class ProductsManagerOrdersViewModel : ViewModelBase
    {
        #region Members
        private ObservableCollection<Order> orders;
        #endregion
        #region Constructor
        public ProductsManagerOrdersViewModel(NavigationStore navigation)
        {
            orders = new ObservableCollection<Order>();
            List<Order> ordersList = Order.GetAllOrders();
            foreach (Order order in ordersList)
            {
                Orders.Add(order);
            }
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigation, () => new LoginViewModel(navigation));
            BackCommand = new NavigateCommand<ProductsManagerViewModel>(navigation, () => new ProductsManagerViewModel(navigation));
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
