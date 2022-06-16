using MyCommand;
using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel
{
    public class ProductsEmployeeInsertProductViewModel : ViewModelBase
    {
        #region Members
        private Product productAdding;
        private List<int> categoryIds;
        private List<int> supplierIdList;
        private List<int> discontinuedList;
        private int supplierId, stock, categoryId, productId;
        private string productName;
        private decimal unitPrice;
        public int discontinued;
        private ObservableCollection<int> supplierList;
        private ObservableCollection<int> categoryList;
        private ObservableCollection<int> discontinuedL;
        #endregion
        #region Constructor
        public ProductsEmployeeInsertProductViewModel(NavigationStore navigationStore)
        {
            supplierList = new ObservableCollection<int>();
            categoryList = new ObservableCollection<int>();
            ProductAdding = new Product();
            discontinuedL = new ObservableCollection<int>();
            productAdding = new Product();
            productAdding.productid = Product.GetIDFromDB();
            supplierIdList = Product.GetSupplierID();
            categoryIds = Product.GetCategoryIDList();
            discontinuedList = Product.GetContinuedOrDiscontinued();
            foreach (int item in supplierIdList)
            {
                supplierList.Add(item);
            }
            foreach (int item in categoryIds)
            {
                categoryList.Add(item);
            }
            foreach (int item in discontinuedList)
            {
                discontinuedL.Add(item);
            }

            Save = new CommandObject((s) => true, SaveProduct);
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            BackCommand = new NavigateCommand<ProductsEmployeeViewModel>(navigationStore, () => new ProductsEmployeeViewModel(navigationStore));
        }
        #endregion
        #region Properties
        public Product ProductAdding
        {
            get
            {
                return productAdding;
            }
            set
            {
                productAdding = value;
                productAdding.productid = Product.GetIDFromDB();
                OnPropertyChanged(nameof(ProductAdding));
            }
        }
        public ObservableCollection<int> SupplierIDList
        {
            get
            {
                return supplierList;
            }
            set
            {
                supplierList = value;
                OnPropertyChanged(nameof(SupplierIDList));
            }
        }
        public ObservableCollection<int> CategoryList
        {
            get
            {
                return categoryList;
            }
            set
            {
                categoryList = value;
                OnPropertyChanged(nameof(CategoryList));
            }
        }
        public ObservableCollection<int> DiscontinuedList
        {
            get
            {
                return discontinuedL;
            }
            set
            {
                discontinuedL = value;
                OnPropertyChanged(nameof(DiscontinuedList));
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
                OnPropertyChanged(nameof(ProductId));
                OnPropertyChanged(nameof(ProductAdding));
            }
        }
        public  string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
                RaisePropertyChanged("ProductName");
            }
        }
        public List<int> ListOfSuppliersId
        {
            get
            {
                return supplierIdList;
            }
        }
        public int SupplierId
        {
            get
            {
                return supplierId;
            }
            set
            {
                supplierId = value;
                RaisePropertyChanged("SupplierId");
            }
        }
        public List<int> CategoriesList
        {
            get
            {
                return categoryIds;
            }
            set
            {
                categoryIds = value;
            }
        }
        public int CategoryId
        {
            get
            {
                return categoryId;
            }
            set
            {
                categoryId = value;
                RaisePropertyChanged("CategoryId");
            }
        }
        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                unitPrice = value;
                RaisePropertyChanged("UnitPrice");
            }
        }
    
        public int Discontinued
        {
            get
            {
                return discontinued;
            }
            set
            {
              
                discontinued = value;
                RaisePropertyChanged("Discontinued");
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
                RaisePropertyChanged("Stock");
            }
        }
        #endregion
        #region Methods
        public void SaveProduct(object obj)
        {
            Product.Save(ProductAdding);
            ProductAdding = new Product();
        }
        #endregion
        #region Commands
        public ICommand Save { get; set; }
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }
        #endregion



    }
}
