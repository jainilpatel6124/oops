using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    public abstract class Account
    {
        public int AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public decimal Balance { get; protected set; }

        public Account(int accountNumber, string accountHolder, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }
        }

        public virtual void BalanceInquiry()
        {
            Console.WriteLine($"Account Holder: {AccountHolder}, Account Number: {AccountNumber}, Balance: {Balance:C}");
        }
    }
}
