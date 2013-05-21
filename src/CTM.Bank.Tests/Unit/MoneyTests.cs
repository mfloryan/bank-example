using System;
using CTM.Bank.Domain.ValueTypes;
using NUnit.Framework;

namespace CTM.Bank.Tests.Unit
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void ShouldDetermineEquality()
        {
            var money = new Money(0, Currency.GBP);
            var onePound = new Money(1, Currency.GBP);
            var anotherPound = new Money(1, Currency.GBP);
            Assert.That(money, Is.EqualTo(money));
            Assert.That(onePound, Is.EqualTo(anotherPound));
        }
        
        [Test]
        public void ShouldBeAbleToAddMoneyTogether()
        {
            var onePound = new Money(1, Currency.GBP);
            var twoPounds = new Money(2, Currency.GBP);
            var threePounds = new Money(3, Currency.GBP);
            Assert.That(onePound + twoPounds, Is.EqualTo(threePounds));
        }
        
        [Test]
        [ExpectedException(typeof(Currency.Exception), ExpectedMessage = "Currencies do not match, arithmetic operations on money must use the same currency")]
        public void ShouldNotAllowMoneysOfDifferentCurrenciesToBeAddedTogether()
        {
            var onePound = new Money(1, Currency.GBP);
            var oneDollar = new Money(1, Currency.USD);
            var result = onePound + oneDollar;
            Assert.Fail("Should throw an exception before here, cannot add two currencies but got a result: " + result);
        }

        [Test]
        public void ShouldBeAbleToSubtractMoney()
        {
            var onePound = new Money(1, Currency.GBP);
            var twoPounds = new Money(2, Currency.GBP);
            var threePounds = new Money(3, Currency.GBP);
            Assert.That(threePounds - twoPounds, Is.EqualTo(onePound));
        }

        [Test]
        [ExpectedException(typeof(Currency.Exception), ExpectedMessage = "Currencies do not match, arithmetic operations on money must use the same currency")]
        public void ShouldNotAllowMoneysOfDifferentCurrenciesToBeSubtracted()
        {
            var onePound = new Money(1, Currency.GBP);
            var oneDollar = new Money(1, Currency.USD);
            var result = onePound - oneDollar;
            Assert.Fail("Should throw an exception before here, cannot add two currencies but got a result: " + result);
        }
        
        [Test]
        public void ShouldNotBeEqualWhenUsingTwoDifferentCurrencies()
        {
            var zeroPounds = new Money(0, Currency.GBP);
            var zeroDollars = new Money(0, Currency.USD);
            Assert.That(zeroPounds, Is.Not.EqualTo(zeroDollars));
        }
        
        [Test]
        public void ShouldCorrectlyPrintTheValueOfMoney()
        {
            var pounds = new Money(2.1, Currency.GBP);
            Assert.That(pounds.ToString(), Is.EqualTo("£2.10"));
            
            var dollars = new Money(2.1, Currency.USD);
            Assert.That(dollars.ToString(), Is.EqualTo("$2.10"));
        }
        
        [Test]
        public void ShouldCorrectlyPrintTheValueOfLotsOfMoney()
        {
            var lotsOfMoney = new Money(12.1, Currency.GBP);
            Assert.That(lotsOfMoney.ToString(), Is.EqualTo("£12.10"));

            var evenMoreMoney = new Money(1234.56, Currency.GBP);
            Assert.That(evenMoreMoney.ToString(), Is.EqualTo("£1,234.56"));
            
            var loadsAMoney = new Money(1234567890.12, Currency.GBP);
            Assert.That(loadsAMoney.ToString(), Is.EqualTo("£1,234,567,890.12"));

        }

        [Test]
        public void ShouldParseDollarValueFromAString()
        {
            var expected = new Money(1234.56, Currency.USD);
            Assert.That(Money.From("$1,234.56"), Is.EqualTo(expected));
        }

        [TestCase("£2.22")]
        [TestCase("£  2.22   ")]
        [TestCase("£+2.22   ")]
        [TestCase("2.22")]
        [TestCase("  2.22   £", Description = "Tom: The currency parsing in .NET will successfully parse this, not sure we need to be more strict...")]
        public void ShouldParseMoneyValueFromAString(string value)
        {
            var expected = new Money(2.22, Currency.GBP);
            Assert.That(Money.From(value), Is.EqualTo(expected));
        }
        
        [TestCase("-£2.22")]
        [TestCase("-£  2.22   ")]
        [TestCase("£-2.22   ")]
        public void ShouldParseNegativeMoneyValueFromAString(string value)
        {
            var expected = new Money(-2.22, Currency.GBP);
            Assert.That(Money.From(value), Is.EqualTo(expected));
        }

        [Test]
        public void ShouldParseStringWithOnlyDecimalPart()
        {
            var expected = new Money(.22, Currency.GBP);
            Assert.That(Money.From(".22"), Is.EqualTo(expected));
            Assert.That(Money.From("£.22"), Is.EqualTo(expected));
        }

        [TestCase("£2.")]
        [ExpectedException(typeof(FormatException))]
        [Ignore()]
        public void ShouldNotParseMoneyValueFromAnIncorrectString(string value)
        {
            Money.From(value);
            Assert.Fail("Should never get here!");
        }
        
        [Test]
        public void ShouldParseMoneyValueFromAStringWithoutDecimalValues()
        {
            var expected = new Money(2, Currency.GBP);
            Assert.That(Money.From("£2"), Is.EqualTo(expected));
        }
        
        [Test]
        public void ShouldParseMoneyValueFromAStringWithThousandSeparators()
        {
            var expected = new Money(1234.56, Currency.GBP);
            Assert.That(Money.From("£1,234.56"), Is.EqualTo(expected));
        }
        
        [Test]
        public void ShouldParseVastQuantitiesOfMoneyWithMultipleThousandSeparators()
        {
            var expected = new Money(1234567.89, Currency.GBP);
            Assert.That(Money.From("£1,234,567.89"), Is.EqualTo(expected));
        }
    }
}