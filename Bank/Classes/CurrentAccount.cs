using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    public class CurrentAccount : Account
    {
        public decimal OverdraftLimit { get; set; }

        public CurrentAccount(int accountNumber, string accountHolder, decimal initialBalance, decimal overdraftLimit)
            : base(accountNumber, accountHolder, initialBalance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override bool Withdraw(decimal amount)
        {
            if (Balance + OverdraftLimit >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient funds, even with overdraft limit.");
                return false;
            }
        }
    }
}
