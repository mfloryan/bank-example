﻿using CTM.Bank.Domain.ValueTypes;
using NUnit.Framework;

namespace CTM.Bank.Tests
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void ShouldDetermineEquality()
        {
            object money = new Money();
            Assert.That(money, Is.EqualTo(money));
        }
    }
}