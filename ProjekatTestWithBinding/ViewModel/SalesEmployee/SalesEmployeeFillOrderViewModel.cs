using MyCommand;
using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel.SalesEmployee
{
    public class SalesEmployeeFillOrderViewModel : ViewModelBase
    {
        #region Members
        private decimal price, discount;
        private OrderDetail orderAdding;
        private ObservableCollection<string> categoryList;
        private ObservableCollection<string> productList;
        private int categoryId;
        private string categoryName, productName;
        private int stock, productId;
        private short quantity;
        private ObservableCollection<OrderDetail> orderProduct;
        private OrderDetail selectedOrder;
        NavigationStore navigation;
        #endregion
        #region Constructor

        public SalesEmployeeFillOrderViewModel(NavigationStore navigationStore, int orderId, int empId)
        {
            EmpId = empId;
            OrderId = orderId;
            categoryList = Category.GetListCategoryNames();
            productList = new ObservableCollection<string>();
            AddItemToList = new CommandObject((s) => true, AddToList);
            PlaceOrder = new CommandObject((s) => true, Place);
            orderProduct = new ObservableCollection<OrderDetail>();
            orderAdding = new OrderDetail();
            orderAdding.orderid = OrderId;
            navigation = navigationStore;
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            BackCommand = new NavigateCommand<SalesEmployeeViewModel>(navigationStore, () => new SalesEmployeeViewModel(navigationStore, EmpId));

        }
        #endregion
        #region Properties
        public int EmpId { get; set; }
        public int OrderId { get; set; }
        public OrderDetail SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public OrderDetail OrderAdding
        {
            get
            {
                return orderAdding;
            }
            set
            {
                orderAdding = value;
                orderAdding.orderid = OrderId;
                orderAdding.productid = ProductId;
                orderAdding.discount = Discount;
                orderAdding.unitprice = Price;
                categoryList = Category.GetListCategoryNames();
                CategoryName = "";
                ProductName = "";
                OnPropertyChanged(nameof(OrderAdding));
            }
        }
        public ObservableCollection<OrderDetail> OrderProduct
        {
            get
            {
                return orderProduct;
            }
            set
            {
                orderProduct = value;
                OnPropertyChanged(nameof(OrderProduct));
            }
        }
        public ObservableCollection<string> CategoryNames
        {
            get
            {
                return categoryList;
            }
            set
            {
                categoryList = value;
                
                OnPropertyChanged(nameof(CategoryNames));
            }
        }
        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
                categoryId = Category.GetCategoryIdByCategoryName(categoryName);
                ProductsList = Product.GetProductsByCategory(categoryId);

                OnPropertyChanged(nameof(CategoryName));
            }
        }
        public ObservableCollection<string> ProductsList
        {
            get
            {
                return productList;
            }
            set
            {
                productList = value;
                OnPropertyChanged(nameof(ProductsList));
            }
        }
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
                Price = Product.PriceShow(ProductName);
                Stock = Product.ProductStock(ProductName);
                ProductId = Product.GetProductIdByProductName(ProductName);
                OnPropertyChanged(nameof(ProductName));
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public int Stock
        {
            get
            {
                return stock; 
            }
            set
            {
                stock = value;
                OnPropertyChanged(nameof(Stock));
            }
        }
        public short Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public decimal Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
                OnPropertyChanged(nameof(Discount));
            }
        }
        public int ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }
        #endregion
        #region Methods

        public void AddToList(object obj)
        {
            OrderAdding.productid = ProductId;
            OrderAdding.unitprice = Price;
            OrderProduct.Add(OrderAdding);
            OrderAdding = new OrderDetail();

        }
        public void Place(object obj)
        {
            OrderDetail.SaveList(OrderProduct);
            SendEmail();
            navigation.CurrentViewModel = new SalesEmployeeInsertOrderViewModel(navigation, EmpId);

        }

        private void SendEmail()
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "katarinalapovo95@gmail.com",
                    Password = "kaca2302."
                }

            };
            string emailMessage = "";
            foreach (OrderDetail item in OrderProduct)
            {
                emailMessage += "Order ID: " + item.orderid + ", Procuct ID: " + item.productid + " Unit Price: " + item.unitprice + ", Quantity: " + item.qty + ", Discount: " + item.discount + "\n\n";
            }
            MailAddress FromEmail = new MailAddress("katarinalapovo95@gmail.com", "Katarina Prljic");
            MailAddress toEmail = new MailAddress("kaca-p@live.com", "Manager");
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "Order " + OrderId.ToString(),
                Body = emailMessage
                
                //IsBodyHtml = true
            };
            Message.To.Add(toEmail);

            Client.SendCompleted += Client_SendCompleted;
            Client.SendMailAsync(Message);
        }
        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error Happening \n " + e.Error.Message, "Error");
                return;
            }
            MessageBox.Show("Sent Successfully", "Done");
        }


        #endregion
        #region Commands
        public ICommand AddItemToList { get; set; }
        public ICommand PlaceOrder { get; set; }
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }
        #endregion
    }
}
