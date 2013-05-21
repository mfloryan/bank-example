using CTM.Bank.Domain.Aggregates;
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
            var account = new Account(AggregateDescriptor.New());
            Assert.That(account.UncommittedEvents.Count, Is.EqualTo(1));
        }
    }
}