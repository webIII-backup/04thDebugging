using System;

namespace Banking.Models
{
    public class Transaction
    {
        private decimal _amount;

        #region Properties
        public DateTime DateOfTrans { get; private set; }
        public TransactionType TransactionType { get; private set; }

        public decimal Amount
        {
            get { return _amount; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Amount cannot be negative");
                _amount = value;
            }
        }

        #endregion

            #region Constructors
        public Transaction(decimal amount, TransactionType type)
        {
            Amount = amount;
            TransactionType = type;
            DateOfTrans = DateTime.Today;
        }
        #endregion

        #region Methods
        public bool IsWithdraw
        {
            get { return TransactionType == TransactionType.Withdraw; }
        }

        public bool IsDeposit
        {
            get { return TransactionType == TransactionType.Deposit; }
        }
        #endregion


    }
}