using System;
using System.Collections.Generic;
using System.Windows.Input;
using MicroMvvm;
using ProjekatTestWithBinding.Commands;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;

namespace ProjekatTestWithBinding.ViewModel
{
    public class HREmployeeInsertViewModel : ViewModelBase
    {
        #region Members
        private string lastName, firstName, title, titleOfC, address, city, region, postalCode, country, phone;
        private int mgrid;
        private DateTime birthDate, hireDate;
        private List<string> titles;
        private Employee employee;
        private List<string> titlesOfC;
        private List<int> mGrid;
        #endregion
        #region Constructor
        public HREmployeeInsertViewModel(NavigationStore navigationStoree)
        {
            employee = new Employee();
            titles = Employee.GetAllTitles();
            titlesOfC = Employee.GetAllTitlesOfCourtesy();
            mGrid = Employee.GetNumsForMGrid();
            View = new NavigateCommand<HREmployeeUpdateViewModel>(navigationStoree, () => new HREmployeeUpdateViewModel(navigationStoree));
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStoree, () => new LoginViewModel(navigationStoree));
            BackCommand = new NavigateCommand<HREmployeeVM>(navigationStoree, () => new HREmployeeVM(navigationStoree));
        }
        #endregion
        #region Properties

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                RaisePropertyChanged("LastName");
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }
        public List<string> Titlee
        {
            get { return titles; }
            set
            {
                titles = value;
                RaisePropertyChanged("Titlee");
            }
        }
        public string Titleee
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged("Titleee");
            }
        }

        public List<string> TitleOfCourtesy
        {
            get { return titlesOfC; }
            set
            {
                titlesOfC = value;
                RaisePropertyChanged("TitleOfCourtesy");
            }
        }
        public string TitleOfC
        {
            get { return titleOfC; }
            set
            {
                titleOfC = value;
                RaisePropertyChanged("TitleOfC");
            }
        }
        public DateTime DateOfBirth
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                RaisePropertyChanged("DateOfBirth");
            }
        }


        public DateTime HireDate
        {
            get { return hireDate; }
            set
            {
                hireDate = value;
                RaisePropertyChanged("HireDate");
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
        public List<int> MGrid
        {
            get { return mGrid; }
            set
            {
                mGrid = value;
                RaisePropertyChanged("MGrid");
            }
        }
        public int MGridChoosen
        {
            get { return mgrid; }
            set
            {
                mgrid = value;
                RaisePropertyChanged("MGridChoosen");
            }
        }

        #endregion
        #region Methods
        void SaveEmployee()
        {
            employee.lastname = LastName;
            employee.firstname = FirstName;
            employee.title = Titleee;
            employee.titleofcourtesy = TitleOfC;
            employee.birthdate = DateOfBirth;
            employee.hiredate = HireDate;
            employee.address = Address;
            employee.city = City;
            employee.region = Region;
            employee.postalcode = PostalCode;
            employee.country = Country;
            employee.phone = Phone;
            employee.mgrid = MGridChoosen;
            Employee.SaveEmployee(employee);    
            employee = new Employee();
        }
        bool CanUpdate()
        {
            return true;
        }
        #endregion
        #region Commands
        public ICommand Save { get { return new RelayCommand(SaveEmployee, CanUpdate); } }
        public ICommand View { get; }
        public ICommand BackCommand { get; }
        public ICommand LogoutCommand { get; }
        #endregion
    }
}
