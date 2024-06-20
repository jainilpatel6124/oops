using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Classes
{
    public class Table
    {
        public int Number { get; }
        public int Seats { get; }
        public bool IsReserved { get; private set; }

        public Table(int number, int seats)
        {
            Number = number;
            Seats = seats;
            IsReserved = false;
        }

        public void Reserve()
        {
            if (!IsReserved)
            {
                IsReserved = true;
                Console.WriteLine($"Table {Number} reserved.");
            }
            else
            {
                Console.WriteLine($"Table {Number} is already reserved.");
            }
        }

        public void Release()
        {
            if (IsReserved)
            {
                IsReserved = false;
                Console.WriteLine($"Table {Number} released.");
            }
            else
            {
                Console.WriteLine($"Table {Number} is not reserved.");
            }
        }
    }
}
