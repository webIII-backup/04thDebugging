using System;
using Banking.Models;
using Xunit;

namespace Banking.Tests.Models
{
    public class BankAccountTestDeel2 
    {
        private BankAccount _bankAccount;

        public BankAccountTestDeel2()
        {
            string accountNumber = "123-4567890-02";
            _bankAccount = new BankAccount(accountNumber);
        }

        [Theory]
        [InlineData("123-4567890-0333")] //too long
        [InlineData("123-1547563@60")] //wrong format
        [InlineData("123-4567890-03")] //not divisable by 97
        public void NewAccount_WrongAccountNumber_Fails(string accountNumber)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(accountNumber));
        }

        //[Fact]
        //public void NewAccount_Null_Fails()
        //{
        //    Assert.Throws<ArgumentNullException>(() => new BankAccount(null));
        //}

        //[Fact]
        //public void NewAccount_ToLong_Fails()
        //{
        //    string number = "123-4567890-0333";
        //    Assert.Throws<ArgumentException>(() => new BankAccount(number));
        //}

        //[Fact]
        //public void NewAccount_WrongFormat_Fails()
        //{
        //    string number = "123-1547563@60";
        //    Assert.Throws<ArgumentException>(() => new BankAccount(number));
        //}

        //[Fact]
        //public void NewAccount_NoDivisionBy97_Fails()
        //{
        //    string number = "123-4567890-03";
        //    Assert.Throws<ArgumentException>(() => new BankAccount(number));
        //}

        //stort 200 en 100
        [Fact]
        public void Deposit_Amount_ChangesBalance()
        {
            _bankAccount.Deposit(200);
            _bankAccount.Deposit(100);
            Assert.Equal(300, _bankAccount.Balance);
        }

        //stort 200, haal dan 110 af
        //[Fact]
        //public void Withdraw_Amount_ChangesBalance()
        //{
        //    _bankAccount.Deposit(200);
        //    _bankAccount.Withdraw(110);
        //    Assert.Equal(90, _bankAccount.Balance);
        //}

        ////haal 100 af 
        //[Fact]
        //public void Withdraw_NegativeBalance_Allowed()
        //{
        //    _bankAccount.Withdraw(100);
        //    Assert.Equal(-100, _bankAccount.Balance);
        //}

        [Theory]
        [InlineData(200, 110, 90)]
        [InlineData(200, 300, -100)]
        public void Withdraw_Amount_Allowed(decimal depositAmount, decimal withdrawAmount,decimal expected)
        {
            _bankAccount.Deposit(depositAmount);
            _bankAccount.Withdraw(withdrawAmount);
            Assert.Equal(expected, _bankAccount.Balance);
        }

        [Fact]
        public void Withdraw_NegativeAmount_Fails()
        {
            Assert.Throws<ArgumentException>(() => _bankAccount.Withdraw(-100));
        }

        [Fact]
        public void Deposit_NegativeAmount_Fails()
        {
            Assert.Throws<ArgumentException>(() => _bankAccount.Deposit(-100));
        }

       
    }
}
