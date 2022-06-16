using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjekatTestWithBinding.Model
{
    public enum Role { SalesEmployee, SalesManager, LogisticEmployee, LogisticManager, ProductsEmployee, HREmployee, ProductsManager, Admin }

    public class UserQueries
    {
        string _username, _password;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public static bool ValidateUser(string username, string password)
        {
            TEST_DOOEntities db = new TEST_DOOEntities();


            if (db.Users.Where(u => u.username == username && u.password == password).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static List<User> GetUsers()
        {
            try
            {
                using (TEST_DOOEntities db = new TEST_DOOEntities())
                {
                    var users = (from u in db.Users
                                 select u).ToList<User>();
                    return users;
                }
            }
            catch (Exception e)
            {
                return new List<User>();

            }
        }
        public static int GetEmployeeID(string username)
        {
            TEST_DOOEntities db = new TEST_DOOEntities();
            var usr = db.Users.Where(u => u.username == username).FirstOrDefault<User>();
            return usr is null ? 0 : usr.empid;

        }
        public static Role GetUserRole(string username)
        {
            TEST_DOOEntities db = new TEST_DOOEntities();
            var usr = db.Users.Where(u => u.username == username).FirstOrDefault<User>();
            return ConvertStringToRole(usr.role);
        }
        public static Role ConvertStringToRole(string role)
        {
            if (role == "Sales Manager" || role == "SalesManager")
            {
                return Role.SalesManager;
            }
            else if (role == "Admin")
            {
                return Role.Admin;
            }
            else if (role == "Sales Representative" || role == "SalesEmployee")
            {
                return Role.SalesEmployee;
            }
            else if (role == "LogisticEmployee")
            {
                return Role.LogisticEmployee;

            }
            else if (role == "LogisticManager")
            {
                return Role.LogisticManager;

            }
            else if (role == "ProductsEmployee")
            {
                return Role.ProductsEmployee;

            }
            else if (role == "ProductsManager")
            {
                return Role.ProductsManager;

            }
            else
            {
                return Role.HREmployee;
            }

        }

        public static ObservableCollection<int> GetFreeEmployees()
        {
            ObservableCollection<int> freeEmps = new ObservableCollection<int>();
            TEST_DOOEntities db = new TEST_DOOEntities();
            var emps = (from e in db.Employees
                        select e.empid).ToList<int>();
            var usrs = (from u in db.Users
                        select u.empid).ToList<int>();
            foreach (var item in emps)
            {
                if (!usrs.Contains(item))
                {
                    freeEmps.Add(item);
                }
            }
            return freeEmps;

        }
        public static string GetName(int id)
        {
            TEST_DOOEntities db = new TEST_DOOEntities();
            var employee = db.Employees.Where(u => u.empid == id).FirstOrDefault<Employee>();
            //if (employee is null)
            //{
            //    return "";
            //}
            //return employee?.firstname;
            return employee is null ? "" : employee.firstname;
           // return employee.firstname;
            
        }
        public static string GetLastName(int id)
        {
            TEST_DOOEntities db = new TEST_DOOEntities();
            var employee = db.Employees.Where(u => u.empid == id).FirstOrDefault<Employee>();
            if (employee is null)
            {
                return "";
            }
            return employee.lastname;
        }
        public static string GetRole(int id)
        {
            TEST_DOOEntities db = new TEST_DOOEntities();
            var employee = db.Employees.Where(u => u.empid == id).FirstOrDefault<Employee>();
            if (employee is null)
            {
                return "";
            }
            return employee.title;
        }
        public static List<string> GetStatus()
        {
            List<string> statuses = new List<string>();
            statuses.Add("Active");
            statuses.Add("Deactived");
            return statuses;
        }
        public static void SaveUser(User userObj)
        {
            TEST_DOOEntities db = new TEST_DOOEntities();
            User user = new User();
            user = userObj;
            if (user.username == null || user.password == null || user.empid == 0 || user.name == null || user.lastname == null || user.role == null || user.role == null)
            {
                MessageBox.Show("Please, fill blank fields");
            }
            else
            {
                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Added Successfully");
            }
            
        }
        public static void UpdateUser(User userObj)
        {
            TEST_DOOEntities db = new TEST_DOOEntities();
            db.SaveChanges();
            MessageBox.Show("Updated Successfully");

        }
        public static void DeleteUser(User userObj)
        {
            TEST_DOOEntities db = new TEST_DOOEntities();
            User user = userObj;
            db.Entry(user).State = EntityState.Deleted;
            db.SaveChanges();
            MessageBox.Show("Deleted Successfully");
        }

    }
}
