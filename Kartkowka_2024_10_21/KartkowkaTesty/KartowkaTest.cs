using Library;
using System.Collections;

namespace KartkowkaTesty
{
    public class KartowkaTest
    {
        [Theory]
        [InlineData("a tu mamy mamuta")]
        [InlineData("jem s?d od ?smej")]
        [InlineData("o i natka tu tak tanio")]
        public void IsPalindromTest(string testing_string)
        {
            Assert.True(Library.Palindrome.IsPalindrome(testing_string));
        }

        [Fact]
        public void TestDepositPositive() {
            var bank_acc = new BankAccount();

            Assert.True(bank_acc.Deposit(25.0d));
        }
        [Fact]
        public void TestDepositNegative()
        {
            var bank_acc = new BankAccount();

            Assert.False(bank_acc.Deposit(-25.0d));
        }

        [Fact]
        public void IsBalanceCorrect()
        {
            var bankacc = new BankAccount();
            double balance_should_be = 200.0d;

            bankacc.Deposit(200.0d);
            Assert.Equal(balance_should_be, bankacc.GetBalance());

            balance_should_be -= 125.0d;
            bankacc.Withdraw(125.0d);
            Assert.Equal(balance_should_be, bankacc.GetBalance());
        }
    }
}