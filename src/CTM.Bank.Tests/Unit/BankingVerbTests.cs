using CTM.Bank.Domain.Control;
using NUnit.Framework;

namespace CTM.Bank.Tests.Unit
{
    [TestFixture]
    public class BankingVerbTests
    {
        [Test]
        public void ShouldDetermineAppropriateVerbFromInputString()
        {
            Assert.That(BankingVerb.From("deposit £500"), Is.TypeOf<DepositContext>());
            Assert.That(BankingVerb.From("withdraw £500"), Is.TypeOf<WithdrawContext>());
            Assert.That(BankingVerb.From("help"), Is.TypeOf<HelpContext>());
            Assert.That(BankingVerb.From("create"), Is.TypeOf<CreateAccountContext>());
            Assert.That(BankingVerb.From("open"), Is.TypeOf<OpenAccountContext>());
        }
    }
}