using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product(int Id, string Name, int Quantity, double Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Quantity = Quantity;
            this.Price = Price;
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer(int Id, string Name)
        {
            this.Name = Name;
            this.Id = Id;
        }
    }

    public class ShoppingCart
    {
        List<Product> products = new List<Product>();

        public void add_products(Product product)
        {
            products.Add(product);
            Console.WriteLine("Product Add Successfully");
        }

        public void remove_products(Product product)
        {
            Console.WriteLine("Enter Index to remove product. Index start from 0");
            int index = int.Parse(Console.ReadLine());

            products.RemoveAt(index);
            Console.WriteLine($"{product.Name} remove successfully");
        }

        public double calculate_price()
        {
            double total_price = 0;
            foreach (var product in products)
            {
                total_price += product.Price * product.Quantity;
            }
            return total_price;
        }

        public double place_order(Customer customer)
        {
            Console.WriteLine(customer.Name);

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} \n {product.Quantity} \n {product.Price}");
            }
            Console.WriteLine(calculate_price());

            return calculate_price();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product(1, "Laptop", 2, 1200.50);
            Product product2 = new Product(2, "Mouse", 5, 25.75);
            Product product3 = new Product(3, "Keyboard", 3, 85.00);

            // Creating a customer
            Customer customer = new Customer(1, "John Doe");

            // Creating a shopping cart
            ShoppingCart cart = new ShoppingCart();

            // Adding products to the shopping cart
            cart.add_products(product1);
            cart.add_products(product2);
            cart.add_products(product3);

            // Removing a product from the shopping cart (example: removing product1)
            cart.remove_products(product1);

            // Placing the order and calculating the total price
            double totalPrice = cart.place_order(customer);
            Console.WriteLine($"Total Price: {totalPrice}");

            Console.ReadLine(); // Keeps the console window open
        }
    }
}
