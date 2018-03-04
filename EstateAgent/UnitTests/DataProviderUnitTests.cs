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

        [Test]
        public void Test_GetProperties()
        {
            var dp = new DataProvider();
            var properties = dp.GetProperties();
            Assert.IsNotNull(properties);
            CollectionAssert.IsNotEmpty(properties);
        }

        [Test]
        public void Test_GetProperty()
        {
            var dp = new DataProvider();
            var landlord = dp.GetProperty(1);
            Assert.IsNotNull(landlord);
            Assert.AreEqual(1, landlord.LandlordId);
        }

        [Test]
        public void Test_GetPropertiesOfLandlord()
        {
            var dp = new DataProvider();
            var properties = dp.GetPropertiesOfLandlord(1);
            Assert.IsNotNull(properties);
            CollectionAssert.IsNotEmpty(properties);
        }
    }
}
