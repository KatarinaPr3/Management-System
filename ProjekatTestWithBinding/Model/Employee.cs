//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjekatTestWithBinding.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows;

    public enum Title { Mr, Ms, Mrs, Dr }


    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Users = new HashSet<User>();
            this.Employees1 = new HashSet<Employee>();
            this.Orders = new HashSet<Order>();
        }
    
        public int empid { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string title { get; set; }
        public string titleofcourtesy { get; set; }
        public System.DateTime birthdate { get; set; }
        public System.DateTime hiredate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalcode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public Nullable<int> mgrid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees1 { get; set; }
        public virtual Employee Employee1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }


        public static TEST_DOOEntities db = new TEST_DOOEntities();
        public static List<string> GetAllTitles()
        {
            List<string> roles = new List<string>();
            foreach (var item in Enum.GetValues(typeof(Role)))
            {
                roles.Add(item.ToString());
            }
            return roles;
        }
        public static List<string> GetAllTitlesOfCourtesy()
        {
            List<string> titles = new List<string>();
            foreach (var item in Enum.GetValues(typeof(Title)))
            {
                titles.Add(item.ToString());
            }
            return titles;
        }
        public static List<int> GetNumsForMGrid()
        {
            int max = 5;
            List<int> mgrid = new List<int>();
            for (int i = 0; i <= max; i++)
            {
                mgrid.Add(i);
            }
            return mgrid;
        }
        public static List<Employee> GetAllEmployees()
        {
            var employees = (from e in db.Employees.AsNoTracking()
                             select e).ToList<Employee>();
            return employees;
            
        }
        public static void SaveEmployee(Employee employeeObj)
        {
            db.Employees.Add(employeeObj);
            db.SaveChanges();
            MessageBox.Show("Added Successfully.");
        }
        public static void DeleteUser(Employee employeeObj)
        {
            db.Entry(employeeObj).State = EntityState.Deleted;
            db.SaveChanges();
            MessageBox.Show("Deleted Successfully");
        }
        public static void UpdateUser(Employee employeeObj)
        {
            db.Entry(employeeObj).State = EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("Updated Successfully");

        }

    }
}
