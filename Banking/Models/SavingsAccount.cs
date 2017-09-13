using System;

namespace Banking.Models
{
    public class SavingsAccount : BankAccount
    {
        #region Fields
        protected const decimal WithdrawCost = 0.25;
        #endregion

        #region Properties
        public decimal InterestRate { get; private set; }
        #endregion

        #region Constructors
        public SavingsAccount(string bankAccountNumber, decimal interestRate)
            : base(bankAccountNumber)
        {
            InterestRate = interestRate;
        }
        #endregion

        #region Methods
        public override void Withdraw(decimal amount)
        {
            if (amount + WithdrawCost > Balance)
                throw new InvalidOperationException("Balance cannot be negative");
            base.Withdraw(amount);
            base.Withdraw(WithdrawCost);
        }

        public void AddInterest()
        {
            Deposit(Balance * InterestRate);
        }
        #endregion
    }
}