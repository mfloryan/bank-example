using CTM.Bank.Domain.Aggregates;
using CTM.Bank.Domain.ValueTypes;
using CTM.Domain.Core;
using NUnit.Framework;

namespace CTM.Bank.Tests.Unit.Aggregates
{
    [TestFixture]
    public class AccountSpecification
    {
        [Test]
        public void ShouldPublishAnAccountCreatedEvent()
        {
            var account = new BankAccount(AggregateDescriptor.New(), new SortCode("40-40-40"), new AccountNumber());
            Assert.That(account.UncommittedEvents.Count, Is.EqualTo(1));
        }
    }
}