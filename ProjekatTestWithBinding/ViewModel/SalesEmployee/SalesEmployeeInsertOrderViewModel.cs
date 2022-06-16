
using MicroMvvm;
using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel.SalesEmployee
{
    public class SalesEmployeeInsertOrderViewModel : ViewModelBase
    {
        #region Members
        private int orderId, customerId, shipperId;
        private DateTime orderDate, requiredDate, shippedDate;
        private decimal? freight;
        private string shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry, status;
        private Order order;
        private List<int> customerList;
        private bool canExecuteOrder;
        NavigationStore navigation;
        #endregion
        #region Constructor
        public SalesEmployeeInsertOrderViewModel(NavigationStore navigationStore,int empId)
        {
            navigation = navigationStore;
            orderId = Order.GetIDFromDB();
            canExecuteOrder = false;
            order = new Order();
            customerList = Customer.GetCustomerList();
            EmployeeId = empId;
            orderDate = DateTime.Today;
            requiredDate = DateTime.Today;
            shippedDate = DateTime.Today;
            EmployeeId = empId;
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            BackCommand = new NavigateCommand<SalesEmployeeViewModel>(navigationStore, () => new SalesEmployeeViewModel(navigationStore, EmployeeId));
        }
        #endregion
        #region Properties


        public int OrderId
        {
            get
            {
                return Order.GetIDFromDB();
            }
        }
        public List<int> CustomerList
        {
            get
            {
                return customerList;
            }
            set
            {
                customerList = value;
                RaisePropertyChanged("CustomerList");
            }
        }
       
        public int CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
                RaisePropertyChanged("CustomerId");
            }
        }
        public int EmployeeId
        {
            get; set;
        }
        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }
            set
            {
                orderDate = value;
                RaisePropertyChanged("OrderDate");
            }
        }
        public DateTime RequiredDate
        {
            get
            {
                return requiredDate;
            }
            set
            {
                requiredDate = value;
                RaisePropertyChanged("RequiredDate");
            }
        }
        public DateTime ShippedDate
        {
            get
            {
                return shippedDate;
            }
            set
            {
                shippedDate = value;
                RaisePropertyChanged("ShippedDate");
            }
        }
        public List<int> ShippersIdList
        {
            get
            {
                return Shipper.GetShipperIdList();
            }
            
        }
        public int ShipperId
        {
            get
            {
                return shipperId;
            }
            set
            {
                shipperId = value;
                RaisePropertyChanged("ShipperId");
            }
        }
        public decimal? Freight
        {
            get
            {
                return freight;
            }
            set
            {
                freight = value;
                RaisePropertyChanged("Freight");
            }
        }
        public string ShipName
        {
            get
            {
                return shipName;
            }
            set
            {
                shipName = value;
                RaisePropertyChanged("ShipName");
            }
        }
        public string ShipAddress
        {
            get
            {
                return shipAddress;
            }
            set
            {
                shipAddress = value;
                RaisePropertyChanged("ShipAddress");
            }
        }
        public string ShipCity
        {
            get
            {
                return shipCity;
            }
            set
            {
                shipCity = value;
                RaisePropertyChanged("ShipCity");
            }
        }
        public string ShipRegion
        {
            get
            {
                return shipRegion;
            }
            set
            {
                shipRegion = value;
                RaisePropertyChanged("ShipRegion");
            }
        }
        public string ShipPostalCode
        {
            get
            {
                return shipPostalCode;
            }
            set
            {
                shipPostalCode = value;
                RaisePropertyChanged("ShipPostalCode");
            }
        }
        public string ShipCountry
        {
            get
            {
                return shipCountry;
            }
            set
            {
                shipCountry = value;
                RaisePropertyChanged("ShipCountry");
            }
        }
        public List<string> StatusList
        {
            get
            {
                return Order.GetStatusList();
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                RaisePropertyChanged("Status");
            }
        }
        public NavigationStore NavigationStore
        {
            get
            {
                return navigation;
            }
            set
            {
                navigation = value;
            }
        }
        #endregion
        #region Methods
        public void Method()
        {
            navigation.CurrentViewModel = new SalesEmployeeFillOrderViewModel(navigation, orderId, EmployeeId);
        }
       
        public void SaveOrder()
        {
            order.custid = CustomerId;
            order.empid = EmployeeId;
            order.orderdate = OrderDate;
            order.requireddate = RequiredDate;
            order.shippeddate = ShippedDate;
            order.shipperid = ShipperId;
            order.freight = (decimal)Freight;
            order.shipname = ShipName;
            order.shipaddress = ShipAddress;
            order.shipcity = ShipCity;
            order.shipregion = ShipRegion;
            order.shippostalcode = shipPostalCode;
            order.shipcountry = ShipCountry;
            order.status = Status;
            canExecuteOrder = true;
            FillOrder.CanExecute(CanExecuteFill());
            Order.SaveOrder(order);
        }
        bool CanUpdate()
            
        {
            return true;
        }

        bool CanExecuteFill()
        {
            return canExecuteOrder;
        }
       
       
        #endregion
        #region Commands
        public ICommand AddOrder { get { return new RelayCommand(SaveOrder, CanUpdate); } }
        public ICommand FillOrder { get { return new RelayCommand(Method, CanExecuteFill); } }
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }

        #endregion
    }
}
