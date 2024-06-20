using InventoryManagement.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            List<Supplier> suppliers = new List<Supplier>();

            while (true)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Supplier");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Remove Product");
                Console.WriteLine("4. Display Inventory");
                Console.WriteLine("5. Display Suppliers");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Add Supplier
                        Console.Write("Enter Supplier ID: ");
                        int supplierId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Supplier Name: ");
                        string supplierName = Console.ReadLine();
                        Console.Write("Enter Supplier Contact Info: ");
                        string contactInfo = Console.ReadLine();

                        Supplier supplier = new Supplier(supplierId, supplierName, contactInfo);
                        suppliers.Add(supplier);
                        Console.WriteLine("Supplier added.");
                        break;

                    case 2:
                        // Add Product
                        Console.Write("Enter Product ID: ");
                        int productId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Product Name: ");
                        string productName = Console.ReadLine();
                        Console.Write("Enter Product Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        Console.WriteLine("Available Suppliers:");
                        foreach (var supp in suppliers)
                        {
                            supp.DisplaySupplierInfo();
                        }
                        Console.Write("Enter Supplier ID for the product: ");
                        int prodSupplierId = int.Parse(Console.ReadLine());
                        var productSupplier = suppliers.FirstOrDefault(s => s.Id == prodSupplierId);

                        if (productSupplier != null)
                        {
                            Product product = new Product(productId, productName, quantity, productSupplier);
                            inventory.AddProduct(product);
                        }
                        else
                        {
                            Console.WriteLine("Supplier not found. Add the supplier first.");
                        }
                        break;

                    case 3:
                        // Remove Product
                        Console.Write("Enter Product ID to remove: ");
                        int removeProductId = int.Parse(Console.ReadLine());
                        inventory.RemoveProduct(removeProductId);
                        break;

                    case 4:
                        // Display Inventory
                        inventory.DisplayInventory();
                        break;

                    case 5:
                        // Display Suppliers
                        Console.WriteLine("Current Suppliers:");
                        foreach (var supp in suppliers)
                        {
                            supp.DisplaySupplierInfo();
                        }
                        break;

                    case 6:
                        // Exit
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                        
                }
                Console.ReadLine();
            }
        }
    }
}
