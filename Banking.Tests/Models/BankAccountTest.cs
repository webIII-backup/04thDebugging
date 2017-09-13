using Banking.Models;
using System;
using Xunit;

namespace Banking.Tests.Models
{
    public class BankAccountTest
    {
        private BankAccount _account;
        private string _accountNumber;

        public BankAccountTest()
        {
            _accountNumber = "123-4567890-02";
            _account = new BankAccount(_accountNumber);
        }

        [Fact]
        public void NewAccount_BalanceZero()
        {
            //Assert
            Assert.Equal(0, _account.Balance);
        }

        [Fact]
        public void NewAccount_SetsAccountNumber()
        {
            Assert.Equal(_accountNumber, _account.AccountNumber);
        }


        [Fact]
        public void NewAccount_EmptyString_Fails()
        {
            Assert.Throws<ArgumentException>(
                () => new BankAccount(String.Empty));
        }


    }
}

