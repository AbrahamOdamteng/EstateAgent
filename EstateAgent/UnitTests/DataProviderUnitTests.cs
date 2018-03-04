using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EstateAgent.LinqToSQL;

namespace EstateAgent.UnitTests
{
    [TestFixture]
    public class DataProviderUnitTests
    {
        DataProvider dp = new DataProvider();
        LandLordDTO testLandLord;
        PropertyDTO testPropertyOne;
        PropertyDTO testPropertyTwo;

        public DataProviderUnitTests()
        {
            testLandLord = new LandLordDTO()
            {
                Forename = "James",
                Surname = "Bond",
                Email = "james.bond@mi5.com",
                Phone = "007-007-007",
            };

            testPropertyOne = new PropertyDTO()
            {
                AvailableFrom = DateTime.Now,
                Housenumber = "123",
                PostCode = "{PROP-01#}",
                Status = PropertyStatus.Vacant.ToString(),
                Street = "C# Street",
                Town = ".NET town",
            };


            testPropertyTwo = new PropertyDTO()
            {
                AvailableFrom = DateTime.Now,
                Housenumber = "456",
                PostCode = "{PROP-02#}",
                Status = PropertyStatus.Vacant.ToString(),
                Street = "C# Street",
                Town = ".NET town",
            };
        }

        public void RemoveTestLandlordFromDatabase()
        {
            var landLord = dp.GetLandLords().SingleOrDefault(
                ll => ll.Email == testLandLord.Email);

            if (landLord is null) return;
        }


        public void RemoveTestPropertiesFromDatabase()
        {

            var postCodes = new string[] { testPropertyOne.PostCode, testPropertyTwo.PostCode };

            var properties = dp.GetProperties().Where( p => postCodes.Contains(p.PostCode)).ToArray();

            if (properties.Any())
            {
                
            }
        }

        //[SetUp]
        //public void SetUp()
        //{
        //    RemoveTestLandlordFromDatabase();
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    RemoveTestLandlordFromDatabase();
        //}

        [Test]
        public void Test_CreateLandlord()
        {
            var id = dp.CreateLandLord(testLandLord);
            Assert.AreNotEqual(0, id);
        }

        [Test]
        public void Test_GetLandLand()
        {
            var id = 1;
            var landLord = dp.GetLandLand(id);

            Assert.AreEqual(id, landLord.Id);

            Assert.NotNull(landLord.Forename);
            Assert.NotNull(landLord.Surname);
            Assert.NotNull(landLord.Phone);
            Assert.NotNull(landLord.Email);
        }

        [Test]
        public void Test_UpdateLandLord()
        {

            var forename = "Ernst";
            var surname = "Blofeld";

            var id = dp.CreateLandLord(testLandLord);

            var landLord = dp.GetLandLand(id);

            landLord.Forename = forename;
            landLord.Surname = surname;

            dp.UpdateLandLord(landLord);

            var updatedLandLord = dp.GetLandLand(id);

            Assert.AreEqual(forename, updatedLandLord.Forename);
            Assert.AreEqual(surname, updatedLandLord.Surname);
        }

        [Test]
        public void Test_DeleteLandLord()
        {
            var id = dp.CreateLandLord(testLandLord);

            dp.DeleteLandLord(id);

            var deletedLandlord = dp.GetLandLand(id);
            Assert.IsNull(deletedLandlord);
        }
    }
}
