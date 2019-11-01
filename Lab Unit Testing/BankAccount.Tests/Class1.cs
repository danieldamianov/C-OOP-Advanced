using System;
using NUnit.Framework;
using TestAxe;

namespace BankAccount.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void TestDepositingInBankAccount()
        {
            BancAccount bancAccount = new BancAccount();
            bancAccount.Deposit(100);

            Assert.That<int>(100, Is.EqualTo(bancAccount.Amount));
        }

        [Test]
        public void TestWithdrawingInBankAccount()
        {
            BancAccount bancAccount = new BancAccount();
            bancAccount.Deposit(100);
            bancAccount.WithDraw(60);
            Assert.AreEqual(40, bancAccount.Amount);

            bancAccount.WithDraw(60);

            Assert.AreEqual(0,bancAccount.Amount);
        }
    }
}
