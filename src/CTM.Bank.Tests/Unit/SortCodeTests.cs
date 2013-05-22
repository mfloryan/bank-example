using CTM.Bank.Domain.ValueTypes;
using NUnit.Framework;

namespace CTM.Bank.Tests.Unit
{
    [TestFixture]
    public class SortCodeTests
    {
        [Test]
        public void ShouldDetermineWhenTwoSortCodesAreEqual()
        {
            var primary = new SortCode("01-01-01");
            var matchingPrimary = new SortCode("01-01-01");
            var different = new SortCode("22-22-22");
            Assert.That(primary, Is.EqualTo(matchingPrimary));
            Assert.That(primary, Is.Not.EqualTo(different));
        }
        
        [Test]
        public void ShouldPrintAFriendlySortCodeRepresentation()
        {
            var sortCodeString = "01-01-01";
            var sortCode = new SortCode(sortCodeString);
            
            Assert.That(sortCode.ToString(), Is.EqualTo(sortCodeString));
        }
    }
}