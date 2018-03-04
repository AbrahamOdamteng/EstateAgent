using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EstateAgent.UnitTests
{
    [TestFixture]
    public class DataProviderUnitTests
    {
        [Test]
        public void Test_GetLandLords()
        {
            var dp = new DataProvider();
            var landlords = dp.GetLandLords();
            Assert.IsNotNull(landlords);
            CollectionAssert.IsNotEmpty(landlords);
        }

        [Test]
        public void Test_GetLandLord()
        {
            var dp = new DataProvider();
            var landlord = dp.GetLandLord(1);
            Assert.IsNotNull(landlord);
            Assert.AreEqual(1, landlord.LandlordId);
        }
    }
}
