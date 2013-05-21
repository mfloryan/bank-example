using System.Globalization;
using System.Threading;
using CTM.Bank.Domain.ValueTypes;
using NUnit.Framework;

namespace CTM.Bank.Tests
{
    [TestFixture]
    public class CurrencyTests
    {
        [Test]
        public void ShouldDefaultToCurrentLocaleCurrencyIfUnableToDetermineFromString()
        {
            Assert.That(Currency.From("a random string"), Is.EqualTo(Currency.GBP));

            var defaultCulture = Thread.CurrentThread.CurrentCulture;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Assert.That(Currency.From("a random string"), Is.EqualTo(Currency.USD));
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = defaultCulture;
            }
        }
    }
}