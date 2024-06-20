using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Classes
{
    public class Order
    {
        public int Id { get; }
        public Table Table { get; }
        public List<MenuItem> Items { get; }
        public decimal TotalAmount { get; private set; }

        public Order(int id, Table table)
        {
            Id = id;
            Table = table;
            Items = new List<MenuItem>();
            TotalAmount = 0;
        }

        public void AddItem(MenuItem item)
        {
            Items.Add(item);
            TotalAmount += item.Price;
            Console.WriteLine($"Added {item.Name} to order {Id}. Total: {TotalAmount:C}");
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"Order ID: {Id}, Table: {Table.Number}, Total: {TotalAmount:C}");
            Console.WriteLine("Items:");
            foreach (var item in Items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
