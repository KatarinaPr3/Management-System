using System.Collections.Generic;
using ProjekatTestWithBinding.Model;
using ProjekatTestWithBinding.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyCommand;
using ProjekatTestWithBinding.Commands;

namespace ProjekatTestWithBinding.ViewModel
{
    public class HREmployeeUpdateViewModel : ViewModelBase
    {
        #region Members
        private ObservableCollection<Employee> employees;
        private Employee employee;
        private Employee selectedEmployee;
        private List<string> titles;
        private List<string> titlesCourtesy;
        private List<int> mgrids;
        private string title;
        private ObservableCollection<string> titlesList;
        private ObservableCollection<string> titlesCourtesyList;
        private ObservableCollection<int> mgridList;

        #endregion
        #region Constructor

        public HREmployeeUpdateViewModel(NavigationStore navigationStore)
        {
            titlesList = new ObservableCollection<string>();
            titlesCourtesyList = new ObservableCollection<string>();
            mgridList = new ObservableCollection<int>();

            employees = new ObservableCollection<Employee>();
            List<Employee> employeesList = Employee.GetAllEmployees();

            foreach (Employee item in employeesList)
            {
                Employees.Add(item);
            }
            titles = Employee.GetAllTitles();
            titlesCourtesy = Employee.GetAllTitlesOfCourtesy();
            mgrids = Employee.GetNumsForMGrid();
            foreach (string item in titles)
            {
                titlesList.Add(item);
            }
            foreach (string item in titlesCourtesy)
            {
                titlesCourtesyList.Add(item);
            }
            foreach (int item in mgrids)
            {
                mgridList.Add(item);
            }
            
            DeleteCommand = new CommandObject((s) => true, DeleteUser);
            UpdateCommand = new CommandObject((s) => true, UpdateUser);
            UpdateEmployee = new CommandObject((s) => true, UpdateEmployeeDetails);
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            BackCommand = new NavigateCommand<HREmployeeVM>(navigationStore, () => new HREmployeeVM(navigationStore));

        }
        #endregion
        #region Properties
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }

            set
            {
                employees = value;
                Titles = Employee.GetAllTitles();
                OnPropertyChanged(nameof(Employees));
                OnPropertyChanged(nameof(Title));
            }
        }
        public Employee EmployeeDelete
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged(nameof(EmployeeDelete));
            }
        }
        public Employee SelectedEmployee
        {
            get
            {
                return selectedEmployee;
            }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }
        public List<string> Titles
        {
            get
            {
                return titles;
            }
            set
            {
                titles = value;
                OnPropertyChanged(nameof(Titles));
            }
        }
        public ObservableCollection<string> TitlesList
        {
            get
            {
                return titlesList;
            }
            set
            {
                titlesList = value;
                OnPropertyChanged(nameof(TitlesList));
            }
        }
        public ObservableCollection<string> TitlesCourtesyList
        {
            get
            {
                return titlesCourtesyList;
            }
            set
            {
                titlesCourtesyList = value;
                OnPropertyChanged(nameof(TitlesCourtesyList));
            }
        }
        public ObservableCollection<int> MGridList
        {
            get
            {
                return mgridList;
            }
            set
            {
                mgridList = value;
                OnPropertyChanged(nameof(MGridList));
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        #endregion
        #region Methods
        private void DeleteUser(object obj)
        {
            var employeeForDelete = obj as Employee;
            Employee.DeleteUser(employeeForDelete);
            Employees.Remove(employeeForDelete);
        }
        private void UpdateUser(object obj)
        {
            SelectedEmployee = obj as Employee; 
        }
        private void UpdateEmployeeDetails(object obj)
        {
            Employee.UpdateUser(SelectedEmployee);
            SelectedEmployee = new Employee();
        }
        #endregion
        #region 
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; }
        public ICommand UpdateEmployee { get; set; }
        public ICommand LogoutCommand { get; }
        public ICommand BackCommand { get; }
        #endregion
    }

}
