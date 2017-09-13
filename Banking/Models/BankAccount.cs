using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Banking.Models
{
    public class BankAccount: IBankAccount
    {
        #region Fields
        private string _accountNumber;
        private IList<Transaction> _transactions;
        #endregion

        #region Properties
        public decimal Balance { get; private set; }

        public string AccountNumber
        {
            get { return _accountNumber }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Accountnumber must have a value");
                if (value == null)
                    throw new ArgumentNullException();
                Regex regex = new Regex(@"(\d{3})-(\d{7})-(\d{2})");
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new ArgumentException("Bankaccount number format is not correct");
                if (int.Parse(match.Groups[1] + match.Groups[2].ToString()) % 97 !=
                     int.Parse(match.Groups[3].ToString()))
                    throw new ArgumentException("97 test of the bankaccount number failed");
                _accountNumber = value;
            }
        }

        public int NumberOfTransactions
        {
            get { return _transactions.Count; }
        }
        #endregion

        #region Constructors
        public BankAccount(string account)
        {
            AccountNumber = account;
            Balance = Decimal.Zero;
            _transactions = new List<Transaction>();
        }
        #endregion

        #region Methods
        public void Withdraw(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");
           Transaction t = new Transaction(amount, TransactionType.Withdraw);
            Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");
                _transactions.Add(new Transaction(amount, TransactionType.Deposit));
            Balance = +amount;
        }

        public IEnumerable<Transaction> GetTransactions(DateTime? from, DateTime? till)
        {
            if (from == null && till == null) return _transactions;
            if (from == null) from = DateTime.MinValue;
            if (!till.HasValue) till = DateTime.MaxValue;

            IList<Transaction> transList = new List<Transaction>();
            foreach (Transaction t in _transactions)
                if (t.DateOfTrans >= from && t.DateOfTrans <= till)
                    transList.Add(t);
            return transList;
        }

        public override string ToString()
        {
            return $"{AccountNumber} - {Balance}";
        }

        public override bool Equals(object obj)
        {
            BankAccount account = obj as BankAccount;
            if (account == null) return false;
            return AccountNumber == account.AccountNumber;
        }

        public override int GetHashCode()
        {
            return AccountNumber?.GetHashCode() ?? 0;
        }
        #endregion
    }
}
