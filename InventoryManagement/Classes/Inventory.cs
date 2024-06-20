using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Classes
{
    public class Inventory
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            Products.Add(product);
            Console.WriteLine($"Product {product.Name} added to inventory.");
        }

        public void RemoveProduct(int productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Products.Remove(product);
                Console.WriteLine($"Product {product.Name} removed from inventory.");
            }
            else
            {
                Console.WriteLine($"Product with ID {productId} not found in inventory.");
            }
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Current Inventory:");
            foreach (var product in Products)
            {
                product.DisplayProductInfo();
            }
        }
    }
}
