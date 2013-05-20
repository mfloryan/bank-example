using CTM.Bank.Domain.ValueTypes;
using NUnit.Framework;

namespace CTM.Bank.Tests
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void ShouldDetermineEquality()
        {
            object money = new Money(0.00m);
            Assert.That(money, Is.EqualTo(money));
        }
    }
}