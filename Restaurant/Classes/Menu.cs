using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Classes
{
    public class MenuItem
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public MenuItem(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price:C}";
        }
    }

    public class Menu
    {
        private List<MenuItem> items = new List<MenuItem>();

        public void AddMenuItem(MenuItem item)
        {
            items.Add(item);
            Console.WriteLine("Menu item added.");
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public MenuItem GetMenuItemById(int id)
        {
            return items.Find(item => item.Id == id);
        }
    }
}
