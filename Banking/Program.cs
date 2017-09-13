using Banking.Models;
using System;
using System.Linq;

namespace Banking
{
    class Program
    {
        static void Main(string[] args)
        {

            BankAccount account = new BankAccount("123-4567890-02");
            Console.WriteLine($"AccountNumber: {account.AccountNumber} ");
            Console.WriteLine($"Balance: {account.Balance} ");
            account.Deposit(200M);
            Console.WriteLine($"Balance after deposit of 200 euros: {account.Balance} ");
            Console.WriteLine($"Number of transactions after deposit of 200 euros: {account.NumberOfTransactions} ");
            account.Withdraw(100M);
            Console.WriteLine($"Balance after withdraw 100 euros: {account.Balance} ");
            Console.WriteLine($"Number of transactions after withdraw of 100 euros: {account.NumberOfTransactions} ");
            int aantal = (account.GetTransactions(DateTime.Today.AddDays(-2), DateTime.Today)).Count();
            Console.WriteLine($"Aantal transacties: {aantal}");

            BankAccount savingsAccount = new SavingsAccount("123-4567890-02", 0.05M);
            Console.WriteLine($"SavingsAccount : {savingsAccount}");
            savingsAccount.Deposit(200M);
            savingsAccount.Withdraw(100M);
            Console.WriteLine($"Balance savingsaccount: {savingsAccount.Balance} ");
            Console.ReadKey();

        }
    }
}
