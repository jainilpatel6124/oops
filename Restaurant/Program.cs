using Restaurant.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            List<Table> tables = new List<Table>();
            List<Order> orders = new List<Order>();
            int menuItemIdCounter = 1;
            int orderIdCounter = 1;

            for (int i = 1; i <= 10; i++)
            {
                tables.Add(new Table(i, 4));
            }

            while (true)
            {
                Console.WriteLine("\nRestaurant Management System");
                Console.WriteLine("1. Add Menu Item");
                Console.WriteLine("2. Display Menu");
                Console.WriteLine("3. Reserve Table");
                Console.WriteLine("4. Release Table");
                Console.WriteLine("5. Create Order");
                Console.WriteLine("6. Display Orders");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Add Menu Item
                        Console.Write("Enter Item Name: ");
                        string itemName = Console.ReadLine();
                        Console.Write("Enter Item Price: ");
                        decimal itemPrice = decimal.Parse(Console.ReadLine());

                        MenuItem menuItem = new MenuItem(menuItemIdCounter++, itemName, itemPrice);
                        menu.AddMenuItem(menuItem);
                        break;

                    case 2:
                        // Display Menu
                        menu.DisplayMenu();
                        break;

                    case 3:
                        // Reserve Table
                        Console.Write("Enter Table Number to Reserve: ");
                        int tableNumberToReserve = int.Parse(Console.ReadLine());
                        var tableToReserve = tables.Find(t => t.Number == tableNumberToReserve);

                        if (tableToReserve != null)
                        {
                            tableToReserve.Reserve();
                        }
                        else
                        {
                            Console.WriteLine("Table not found.");
                        }
                        break;

                    case 4:
                        // Release Table
                        Console.Write("Enter Table Number to Release: ");
                        int tableNumberToRelease = int.Parse(Console.ReadLine());
                        var tableToRelease = tables.Find(t => t.Number == tableNumberToRelease);

                        if (tableToRelease != null)
                        {
                            tableToRelease.Release();
                        }
                        else
                        {
                            Console.WriteLine("Table not found.");
                        }
                        break;

                    case 5:
                        // Create Order
                        Console.Write("Enter Table Number for Order: ");
                        int tableNumberForOrder = int.Parse(Console.ReadLine());
                        var tableForOrder = tables.Find(t => t.Number == tableNumberForOrder);

                        if (tableForOrder != null && tableForOrder.IsReserved)
                        {
                            Order order = new Order(orderIdCounter++, tableForOrder);
                            while (true)
                            {
                                menu.DisplayMenu();
                                Console.Write("Enter Menu Item ID to Add to Order (0 to finish): ");
                                int menuItemId = int.Parse(Console.ReadLine());

                                if (menuItemId == 0)
                                    break;

                                var menuItemToAdd = menu.GetMenuItemById(menuItemId);
                                if (menuItemToAdd != null)
                                {
                                    order.AddItem(menuItemToAdd);
                                }
                                else
                                {
                                    Console.WriteLine("Menu item not found.");
                                }
                            }
                            orders.Add(order);
                        }
                        else
                        {
                            Console.WriteLine("Table not found or not reserved.");
                        }
                        break;

                    case 6:
                        // Display Orders
                        foreach (var order in orders)
                        {
                            order.DisplayOrder();
                        }
                        break;

                    case 7:
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
