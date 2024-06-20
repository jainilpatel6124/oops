using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(int accountNumber, string accountHolder, decimal initialBalance, decimal interestRate)
            : base(accountNumber, accountHolder, initialBalance)
        {
            InterestRate = interestRate;
        }

        public void AddInterest()
        {
            decimal interest = Balance * InterestRate / 100;
            Balance += interest;
            Console.WriteLine($"Interest of {interest:C} added. New balance: {Balance:C}");
        }
    }
}
