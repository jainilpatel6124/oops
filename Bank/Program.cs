using Bank.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();

            while (true)
            {
                Console.WriteLine("\nBank Account Management System");
                Console.WriteLine("1. Create Savings Account");
                Console.WriteLine("2. Create Current Account");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Balance Inquiry");
                Console.WriteLine("6. Add Interest (Savings Account)");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Create Savings Account
                        Console.Write("Enter Account Number: ");
                        int savingsAccountNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter Account Holder Name: ");
                        string savingsAccountHolder = Console.ReadLine();
                        Console.Write("Enter Initial Balance: ");
                        decimal savingsInitialBalance = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Interest Rate (%): ");
                        decimal interestRate = decimal.Parse(Console.ReadLine());

                        Account savingsAccount = new SavingsAccount(savingsAccountNumber, savingsAccountHolder, savingsInitialBalance, interestRate);
                        accounts.Add(savingsAccount);
                        Console.WriteLine("Savings Account created.");
                        break;

                    case 2:
                        // Create Current Account
                        Console.Write("Enter Account Number: ");
                        int currentAccountNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter Account Holder Name: ");
                        string currentAccountHolder = Console.ReadLine();
                        Console.Write("Enter Initial Balance: ");
                        decimal currentInitialBalance = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Overdraft Limit: ");
                        decimal overdraftLimit = decimal.Parse(Console.ReadLine());

                        Account currentAccount = new CurrentAccount(currentAccountNumber, currentAccountHolder, currentInitialBalance, overdraftLimit);
                        accounts.Add(currentAccount);
                        Console.WriteLine("Current Account created.");
                        break;

                    case 3:
                        // Deposit
                        Console.Write("Enter Account Number: ");
                        int depositAccountNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter Amount to Deposit: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());

                        var depositAccount = accounts.Find(a => a.AccountNumber == depositAccountNumber);
                        if (depositAccount != null)
                        {
                            depositAccount.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;

                    case 4:
                        // Withdraw
                        Console.Write("Enter Account Number: ");
                        int withdrawAccountNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter Amount to Withdraw: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());

                        var withdrawAccount = accounts.Find(a => a.AccountNumber == withdrawAccountNumber);
                        if (withdrawAccount != null)
                        {
                            withdrawAccount.Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;

                    case 5:
                        // Balance Inquiry
                        Console.Write("Enter Account Number: ");
                        int inquiryAccountNumber = int.Parse(Console.ReadLine());

                        var inquiryAccount = accounts.Find(a => a.AccountNumber == inquiryAccountNumber);
                        if (inquiryAccount != null)
                        {
                            inquiryAccount.BalanceInquiry();
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;

                    case 6:
                        // Add Interest
                        Console.Write("Enter Account Number: ");
                        int interestAccountNumber = int.Parse(Console.ReadLine());

                        var interestAccount = accounts.Find(a => a.AccountNumber == interestAccountNumber) as SavingsAccount;
                        if (interestAccount != null)
                        {
                            interestAccount.AddInterest();
                        }
                        else
                        {
                            Console.WriteLine("Savings account not found or invalid account type.");
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
