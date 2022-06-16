using MicroMvvm;
using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;
using System.Windows.Input;

namespace ProjekatTestWithBinding.ViewModel
{
    public class ProductsEmployeeInsertSupplierViewModel : ViewModelBase
    {
        #region Members
        private Supplier supplier;
        private int supplierId;
        private string companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax;
        #endregion
        #region Constructor
        public ProductsEmployeeInsertSupplierViewModel(NavigationStore navigationStore)
        {
            supplier = new Supplier();
            supplierId = Supplier.GetIDFromDB();
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            BackCommand = new NavigateCommand<ProductsEmployeeViewModel>(navigationStore, () => new ProductsEmployeeViewModel(navigationStore));
        }
        #endregion
        #region Properties
        public int SupplierId
        {
            get
            {
                return Supplier.GetIDFromDB();
            }
        }
        public string CompanyName
        {
            get
            {
                return companyName;
            }
            set
            {
                companyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }
        public string ContactName
        {
            get
            {
                return contactName;
            }
            set
            {
                contactName = value;
                RaisePropertyChanged("ContactName");
            }
        }
        public string ContactTitle
        {
            get
            {
                return contactTitle;
            }
            set
            {
                contactTitle = value;
                RaisePropertyChanged("ContactTitle");
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                RaisePropertyChanged("Address");
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                RaisePropertyChanged("City");
            }
        }
        public string Region
        {
            get { return region; }
            set
            {
                region = value;
                RaisePropertyChanged("Region");
            }
        }
        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                postalCode = value;
                RaisePropertyChanged("PostalCode");
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                RaisePropertyChanged("Country");
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                RaisePropertyChanged("Phone");
            }
        }
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
                RaisePropertyChanged("Fax");
            }
        }
        #endregion
        #region Methods
        void SaveSupplier()
        {
            supplier.companyname = CompanyName;
            supplier.contactname = ContactName;
            supplier.contacttitle = ContactTitle;
            supplier.address = Address;
            supplier.city = City;
            supplier.region = Region;
            supplier.postalcode = PostalCode;
            supplier.country = Country;
            supplier.phone = Phone;
            supplier.fax = Fax;
            Supplier.SaveSupplier(supplier);
        }
        bool CanUpdate()
        {
            return true;
        }
        #endregion
        #region Commands
        public ICommand Save { get { return new RelayCommand(SaveSupplier, CanUpdate); } }
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }
        #endregion
    }
}
