using CTM.Bank.Domain.Control;
using NUnit.Framework;

namespace CTM.Bank.Tests
{
    [TestFixture]
    public class BankingVerbTests
    {
        [Test]
        public void ShouldDetermineAppropriateVerbFromInputString()
        {
            var inputString = "deposit £500";
            Assert.That(BankingVerb.From(inputString), Is.TypeOf<DepositContext>());
        }
    }
}