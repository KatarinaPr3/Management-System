using MyCommand;
using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel
{
    public class ProductsEmployeeUpdateProductViewModel : ViewModelBase
    {
        #region Members
        private ObservableCollection<Product> productsList;
        private Product selectedProduct;
        #endregion
        #region Constructor
        public ProductsEmployeeUpdateProductViewModel(NavigationStore navigationStore)
        {
            productsList = Product.GetAllProducts();
            UpdateProductCommand = new CommandObject((s) => true, Update);
            DeleteProductCommand = new CommandObject((s) => true, Delete);
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            BackCommand = new NavigateCommand<ProductsEmployeeViewModel>(navigationStore, () => new ProductsEmployeeViewModel(navigationStore));
        }
        #endregion
        #region Properties
        public ObservableCollection<Product> Products
        {
            get
            {
                return productsList;
            }
            set
            {
                productsList = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public Product SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        #endregion
        #region Methods
        private void Update(object obj)
        {
            var product = obj as Product;
            Product.UpdateProduct(SelectedProduct);
            SelectedProduct = new Product();
        }
        private void Delete(object obj)
        {
            Product.DeleteProduct(SelectedProduct);
            Products.Remove(SelectedProduct);
            SelectedProduct = new Product();
        }
        #endregion
        #region Commands
        public ICommand UpdateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }
        #endregion
    }
}
