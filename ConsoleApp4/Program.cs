using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp4.Program;

namespace ConsoleApp4
{
    internal class Program
    {

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual double wages()
            {
                return 0;
            }

            public Employee(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        public class Hourly_Emp : Employee
        {
            public double Hours_worked { get; set; }
            public double Hourly_salary { get; set; }

            public Hourly_Emp(double Hours_worked, double Hourly_salary, int Id, string Name) : base(Id, Name)
            {
                this.Hourly_salary = Hourly_salary;
                this.Hours_worked = Hours_worked;
            }

            public override double wages()
            {
                return Hourly_salary * Hours_worked;
            }
        }

        public class Salary_Emp : Employee
        {
            public double Salary { get; set; }

            public Salary_Emp(double Salary, int Id, string Name) : base(Id, Name)
            {
                this.Salary = Salary;
            }

            public override double wages()
            {
                return Salary / 30;
            }
        }

        public class Payroll
        {
            List<Employee> employees = new List<Employee>();

            public void add_Emp(Employee emp)
            {
                employees.Add(emp);
                Console.WriteLine("Employees Added Successfully");
            }

            public void remove_Emp(Employee emp)
            {
                employees.Remove(emp);
                Console.WriteLine("Employee remove successfully");
            }

            public void generate_report()
            {
                double t_payroll = 0;

                Console.WriteLine("Print Payroll Report");

                foreach (var Emp in employees)
                {
                    double wage = Emp.wages();

                    t_payroll += wage;
                    Console.WriteLine($"{Emp.Name} \n{Emp.Id} \n{wage}");
                }
                Console.WriteLine($"{t_payroll}");

            }
        }

        static void Main(string[] args)
        {
            Hourly_Emp hourlyEmp1 = new Hourly_Emp(40, 15.5, 1, "John Doe");
            Hourly_Emp hourly_Emp2 = new Hourly_Emp(50, 15.3, 2, "Jainil");
            Salary_Emp salaryEmp1 = new Salary_Emp(5000, 2, "Jane Smith");

            // Create payroll and add employees
            Payroll payroll = new Payroll();
            payroll.add_Emp(hourlyEmp1);
            payroll.add_Emp(hourly_Emp2 );
            payroll.add_Emp(salaryEmp1);

            // Generate and display payroll report
            payroll.generate_report();

            // Example of removing an employee
            payroll.remove_Emp(hourlyEmp1);
            payroll.generate_report();
            Console.ReadLine();
        }
    }
}
