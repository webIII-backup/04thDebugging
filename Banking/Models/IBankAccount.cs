using System;
using System.Collections.Generic;

namespace Banking.Models
{
    public interface IBankAccount
    {
        string AccountNumber { get; }
        decimal Balance { get; }
        int NumberOfTransactions { get; }

        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        IEnumerable<Transaction> GetTransactions(DateTime? from, DateTime? till);
    }
}