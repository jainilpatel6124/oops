using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    internal class Program
    {
        public class Car_rental
        {
            public Dictionary<Customer1, Car> bookings;
            public void rent_car(Customer1 customer, Car car)
            {
                if (car.isAvailable)
                {
                    car.isAvailable = false;
                    bookings[customer] = car;
                    Console.WriteLine($"{customer.CustomerName} is rented {car.Name}");
                }
                else
                {
                    Console.WriteLine("Car is not available for rent");
                }
            }
            public void return_car(Customer1 customer)
            {
                if (bookings.ContainsKey(customer))
                {
                    Car car1 = bookings[customer];
                    car1.isAvailable = true;
                    bookings.Remove(customer);
                    Console.WriteLine($"{customer.CustomerName} is return {car1.Name}");
                }
            }
        }
        public class Car
        {
            public string Name { get; set; }
            public int id { get; set; }

            public bool isAvailable { get; set; }

            public Car(string Name, int id)
            {
                this.Name = Name;
                this.id = id;
                isAvailable = true;
            }
        }
        public class Customer1
        {
            public string CustomerName { get; set; }
            public int CustomerId { get; set; }

            public Customer1(string customerName, int customerId)
            {
                this.CustomerName = customerName;
                this.CustomerId = customerId;
            }
        }

        static void Main(string[] args)
        {
            Car_rental carRental = new Car_rental
            {
                bookings = new Dictionary<Customer1, Car>()
            };

            List<Car> cars = new List<Car>
            {
                new Car("Toyota Camry", 1),
                new Car("Honda Civic", 2),
                new Car("Ford Mustang", 3)
            };

            List<Customer1> customers = new List<Customer1>
            {
                new Customer1("Alice", 1),
                new Customer1("Bob", 2),
                new Customer1("Charlie", 3)
            };

            while (true)
            {
                Console.WriteLine("Car Rental System");
                Console.WriteLine("1. Rent a Car");
                Console.WriteLine("2. Return a Car");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Available Cars:");
                        foreach (var car in cars)
                        {
                            if (car.isAvailable)
                            {
                                Console.WriteLine($"{car.id}. {car.Name}");
                            }
                        }

                        Console.Write("Enter car id to rent: ");
                        int carId = int.Parse(Console.ReadLine());

                        Car selectedCar = cars.Find(c => c.id == carId);
                        if (selectedCar != null)
                        {
                            Console.WriteLine("Available Customers:");
                            foreach (var customer in customers)
                            {
                                Console.WriteLine($"{customer.CustomerId}. {customer.CustomerName}");
                            }

                            Console.Write("Enter customer id: ");
                            int customerId = int.Parse(Console.ReadLine());

                            Customer1 selectedCustomer = customers.Find(c => c.CustomerId == customerId);
                            if (selectedCustomer != null)
                            {
                                carRental.rent_car(selectedCustomer, selectedCar);
                            }
                            else
                            {
                                Console.WriteLine("Invalid customer id.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid car id.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Customers with Rented Cars:");
                        foreach (var booking in carRental.bookings)
                        {
                            Console.WriteLine($"{booking.Key.CustomerId}. {booking.Key.CustomerName} - {booking.Value.Name}");
                        }

                        Console.Write("Enter customer id to return car: ");
                        int returnCustomerId = int.Parse(Console.ReadLine());

                        Customer1 returnCustomer = customers.Find(c => c.CustomerId == returnCustomerId);
                        if (returnCustomer != null)
                        {
                            carRental.return_car(returnCustomer);
                        }
                        else
                        {
                            Console.WriteLine("Invalid customer id.");
                        }
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
