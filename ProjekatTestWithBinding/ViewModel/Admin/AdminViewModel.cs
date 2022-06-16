using ProjekatTestWithBinding.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProjekatTestWithBinding.Stores;
using System.Windows.Input;
using MicroMvvm;
using MyCommand;
using ProjekatTestWithBinding.Commands;

namespace ProjekatTestWithBinding.ViewModel.Admin
{
    public class AdminViewModel : ViewModelBase
    {
        #region Members
        private ObservableCollection<User> users;
        private int id;
        private ObservableCollection<int> freeEmployees;
        private User user;
        private ObservableCollection<string> statusList;
        private User userDelete;
        private User selectedUser;
        #endregion
        #region Constructor
        public AdminViewModel(NavigationStore navigationStore)
        {
            users = new ObservableCollection<User>();
            user = new User();
            List<User> usersList = UserQueries.GetUsers();
            foreach (User user in usersList)
            {
                users.Add(user);
            }
            statusList = new ObservableCollection<string>();
            List<string> statusListFromModel = UserQueries.GetStatus();
            foreach (string item in statusListFromModel)
            {
                statusList.Add(item);
            }
            FreeEmployees = UserQueries.GetFreeEmployees();
            UpdateCommand =  new CommandObject((s) => true, Update);
            UpdateUserCommand = new CommandObject((s) => true, UpdateUser);
            DeleteCommand = new CommandObject((s) => true, DeleteUser);
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }

        #endregion
        #region Properties
        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                RaisePropertyChanged("Users");
            }
        }
        public ObservableCollection<int> FreeEmployees
        {
            get
            {
               return freeEmployees;
            }
            set
            {
                freeEmployees = value;
                RaisePropertyChanged("FreeEmployees");
            }
        }

        public int EmpId
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                UserAdding.empid = value;
                UserAdding.name = UserQueries.GetName(value);
                UserAdding.lastname = UserQueries.GetLastName(value);
                UserAdding.role = UserQueries.GetRole(value);
                RaisePropertyChanged("EmpId");
                OnPropertyChanged(nameof(UserAdding));
            }
        }
        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public ObservableCollection<string> StatusChoose
        {
            get
            {
                return statusList;
            }
        }
        public User UserDelete
        {
            get
            {
                return userDelete;
            }
            set
            {
                userDelete = value;
                RaisePropertyChanged("Userr");
            }
        }
        public User UserAdding
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged(nameof(UserAdding));
            }
        }

        #endregion
        #region Methods
        private void AddUser()
        {
            UserQueries.SaveUser(UserAdding);
            Users.Add(UserAdding);
            UserAdding = new User();
            FreeEmployees = UserQueries.GetFreeEmployees();
        }

        private void Update(object obj)
        {
            SelectedUser = obj as User;
        }
        private void UpdateUser(object obj)
        {
            UserQueries.UpdateUser(SelectedUser);
            SelectedUser = new User();
            FreeEmployees = UserQueries.GetFreeEmployees();
        }
        private void DeleteUser(object obj)
        {
            var user = obj as User;
            UserQueries.DeleteUser(user);
            Users.Remove(user);
            FreeEmployees = UserQueries.GetFreeEmployees();
        }
        bool CanUpdate()
        {
            return true;
        }

        #endregion
        #region Commands
        public ICommand AddUserCommand { get { return new RelayCommand(AddUser, CanUpdate); } }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateUserCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand LogoutCommand { get; }

        #endregion
    }
}
