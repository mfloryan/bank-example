using System;
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
            var money = new Money(0.00m, Currency.GBP);
            var onePound = new Money(1.00m, Currency.GBP);
            var anotherPound = new Money(1.00m, Currency.GBP);
            Assert.That(money, Is.EqualTo(money));
            Assert.That(onePound, Is.EqualTo(anotherPound));
        }
        
        [Test]
        public void ShouldNotBeEqualWhenUsingTwoDifferentCurrencies()
        {
            var zeroPounds = new Money(0.00m, Currency.GBP);
            var zeroDollars = new Money(0.00m, Currency.USD);
            Assert.That(zeroPounds, Is.Not.EqualTo(zeroDollars));
        }
        
        [Test]
        public void ShouldCorrectlyPrintTheValueOfMoney()
        {
            var pounds = new Money(2.1m, Currency.GBP);
            Assert.That(pounds.ToString(), Is.EqualTo("£2.10"));
            
            var dollars = new Money(2.1m, Currency.USD);
            Assert.That(dollars.ToString(), Is.EqualTo("$2.10"));
        }
        
        [Test]
        public void ShouldCorrectlyPrintTheValueOfLotsOfMoney()
        {
            var lotsOfMoney = new Money(12.1m, Currency.GBP);
            Assert.That(lotsOfMoney.ToString(), Is.EqualTo("£12.10"));

            var evenMoreMoney = new Money(1234.56m, Currency.GBP);
            Assert.That(evenMoreMoney.ToString(), Is.EqualTo("£1,234.56"));
            
            var loadsAMoney = new Money(1234567890.12m, Currency.GBP);
            Assert.That(loadsAMoney.ToString(), Is.EqualTo("£1,234,567,890.12"));

        }

        [Test]
        public void ShouldParseDollarValueFromAString()
        {
            var expected = new Money(1234.56m, Currency.USD);
            Assert.That(Money.From("$1,234.56"), Is.EqualTo(expected));
        }

        [TestCase("£2.22")]
        [TestCase("£  2.22   ")]
        [TestCase("£+2.22   ")]
        public void ShouldParseMoneyValueFromAString(string value)
        {
            var expected = new Money(2.22m, Currency.GBP);
            Assert.That(Money.From(value), Is.EqualTo(expected));
        }
        
        [TestCase("-£2.22")]
        [TestCase("-£  2.22   ")]
        [TestCase("£-2.22   ")]
        public void ShouldParseNegativeMoneyValueFromAString(string value)
        {
            var expected = new Money(-2.22m, Currency.GBP);
            Assert.That(Money.From(value), Is.EqualTo(expected));
        }

        [TestCase("  2.22   £")]
        [TestCase("£2.")]
        [ExpectedException(typeof(FormatException))]
        [Ignore("Tom: The currency parsing in .NET will successfully parse this, not sure we need to be more strict...")]
        public void ShouldNotParseMoneyValueFromAnIncorrectString(string value)
        {
            Money.From(value);
            Assert.Fail("Should never get here!");
        }
        
        [Test]
        public void ShouldParseMoneyValueFromAStringWithoutDecimalValues()
        {
            var expected = new Money(2.00m, Currency.GBP);
            Assert.That(Money.From("£2"), Is.EqualTo(expected));
        }
        
        [Test]
        public void ShouldParseMoneyValueFromAStringWithThousandSeparators()
        {
            var expected = new Money(1234.56m, Currency.GBP);
            Assert.That(Money.From("£1,234.56"), Is.EqualTo(expected));
        }
        
        [Test]
        public void ShouldParseVastQuantitiesOfMoneyWithMultipleThousandSeparators()
        {
            var expected = new Money(1234567.89m, Currency.GBP);
            Assert.That(Money.From("£1,234,567.89"), Is.EqualTo(expected));
        }
    }
}