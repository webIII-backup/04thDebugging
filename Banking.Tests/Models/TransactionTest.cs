using System;
using Banking.Models;
using Xunit;

namespace Banking.Tests.Models
{
    public class TransactionTest
    {
        private Transaction _transaction;

        public TransactionTest()
        {
            _transaction = new Transaction(200, TransactionType.Deposit);
        }

        [Fact]
        public void NewTransaction_SetsAmount()
        {
            Assert.Equal(200, _transaction.Amount);
        }

      [Fact]
        public void NewTransaction_SetsTransactionType()
        {
            Assert.Equal(TransactionType.Deposit, _transaction.TransactionType);
        }

        [Fact]
        public void NewTransaction_SetsDateOfTrans()
        {
            Assert.Equal(_transaction.DateOfTrans, DateTime.Today);
        }

        [Fact]
        public void NewTransaction_NegativeAmount_Fails()
        {
            Assert.Throws<ArgumentException>(() => new Transaction(-200, TransactionType.Deposit));
        }

        [Fact]
        public void IsWithDraw_IfWithDraw_ReturnsTrue()
        {
            _transaction = new Transaction(200, TransactionType.Withdraw);
            Assert.True(_transaction.IsWithdraw);
        }

        [Fact]
        public void IsWithDraw_IfDeposit_ReturnsFalse()
        {
            _transaction = new Transaction(200, TransactionType.Deposit);
            Assert.False(_transaction.IsWithdraw);
        }

        [Fact]
        public void IsDeposit_IfDeposit_ReturnsTrue()
        {
            _transaction = new Transaction(200, TransactionType.Deposit);
            Assert.True(_transaction.IsDeposit);
        }

        [Fact]
        public void IsDeposit_IfWithDraw_ReturnsFalse()
        {
            _transaction = new Transaction(200, TransactionType.Withdraw);
            Assert.False(_transaction.IsDeposit);
        }
    }
}
