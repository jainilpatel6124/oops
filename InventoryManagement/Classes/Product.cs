using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Supplier Supplier { get; set; }

        public Product(int id, string name, int quantity, Supplier supplier)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Supplier = supplier;
        }

        public void DisplayProductInfo()
        {
            Console.WriteLine($"Product ID: {Id}, Name: {Name}, Quantity: {Quantity}, Supplier: {Supplier.Name}");
        }
    }
}
