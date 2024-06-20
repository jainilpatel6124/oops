using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Classes
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        public Supplier(int id, string name, string contactInfo)
        {
            Id = id;
            Name = name;
            ContactInfo = contactInfo;
        }

        public void DisplaySupplierInfo()
        {
            Console.WriteLine($"Supplier ID: {Id}, Name: {Name}, Contact Info: {ContactInfo}");
        }
    }
}
