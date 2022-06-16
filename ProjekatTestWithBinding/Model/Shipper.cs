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
    using System.Linq;
    using System.Collections.Generic;
    using System.Windows;
    using System.Data.Entity.Core.Objects.DataClasses;
    using System.Data.Entity;

    public partial class Shipper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipper()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int shipperid { get; set; }
        public string companyname { get; set; }
        public string phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public static TEST_DOOEntities db = new TEST_DOOEntities();
        public static List<Shipper> GetAllShippers()
        {
            var shippers = (from s in db.Shippers
                            select s).ToList<Shipper>();

            return shippers;
        }
        public static int GetIDFromDB()
        {
            //TEST_DOOEntities db = new TEST_DOOEntities();
            var id = db.Shippers.Max(m => m.shipperid);
            int idShipper = id + 1;
            return idShipper;
        }
       
        public static void SaveShipper(Shipper shipperObj)
        {
            //TEST_DOOEntities db = new TEST_DOOEntities();
            Shipper newShipper = new Shipper();
            newShipper = shipperObj;
            newShipper.companyname = shipperObj.companyname;
            newShipper.phone = shipperObj.phone;
            db.Shippers.Add(newShipper);
            db.SaveChanges();
            MessageBox.Show("Added Successfully");
        }
        public static void UpdateShipper(Shipper shipperObj)
        {
           
            db.Entry(shipperObj).State = EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("Updated Successfully");

        }
        public static void DeleteShipper(Shipper shipperObj)
        {
            try
            {
                db.Shippers.Remove(shipperObj);
                db.SaveChanges();
                MessageBox.Show("Deleted Successfully");
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
           

        }
        public static List<int> GetShipperIdList()
        {
            //TEST_DOOEntities db = new TEST_DOOEntities();
            List<int> shippersIDs = new List<int>();
            List<Shipper> allShippers = Shipper.GetAllShippers();
            foreach (Shipper item in allShippers)
            {
                shippersIDs.Add(item.shipperid);
                
            }
            return shippersIDs;
        }
    }
}
