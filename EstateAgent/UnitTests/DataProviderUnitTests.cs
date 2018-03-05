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

        string street = "{071C1FFE-329E-4EAB-950A-6FDE0A54F1A6}";

        public DataProviderUnitTests()
        {
            testLandLord = new LandLordDTO()
            {
                Forename = "James",
                Surname = "Bond",
                Email = "james.bond@mi5.com",
                Phone = "0#123#456#789#",
            };

            testPropertyOne = new PropertyDTO()
            {
                AvailableFrom = DateTime.Now,
                Housenumber = "123",
                PostCode = "{PROP-01#}",
                Status = PropertyStatus.Vacant.ToString(),
                Street = street,
                Town = "Wimbledon",
            };


            testPropertyTwo = new PropertyDTO()
            {
                AvailableFrom = DateTime.Now,
                Housenumber = "456",
                PostCode = "{PROP-02#}",
                Status = PropertyStatus.Vacant.ToString(),
                Street = street,
                Town = "Wimbledon",
            };
        }


        [SetUp]
        public void SetUp()
        {
            RemoveTestPropertiesFromDatabase();
            RemoveTestLandlordFromDatabase();
        }

        [TearDown]
        public void TearDown()
        {
            RemoveTestPropertiesFromDatabase();
            RemoveTestLandlordFromDatabase();
        }

        public void RemoveTestLandlordFromDatabase()
        {
            var landLords = dp.GetLandLords()
                .Where(ll => ll.Phone == testLandLord.Phone)
                .ToArray();

            if (landLords.Any())
            {
                foreach(var ll in landLords)
                {
                    dp.DeleteLandLord(ll.LandlordId);
                }
            }
        }

        public void RemoveTestPropertiesFromDatabase()
        {
            var properties = dp.GetProperties().Where( p => p.Street == street).ToArray();

            if (properties.Any())
            {
                foreach (var prop in properties)
                {
                    dp.DeleteProperty(prop.PropertyId);
                }
            }
        }

        #region LandLord CRUD


        [Test]
        public void Test_CreateLandlord_Null()
        {
            var id = dp.CreateLandLord(null);
            Assert.AreEqual(0, id);
        }

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
            var landLord = dp.GetLandLord(id);

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

            var landLord = dp.GetLandLord(id);

            landLord.Forename = forename;
            landLord.Surname = surname;

            dp.UpdateLandLord(landLord);

            var updatedLandLord = dp.GetLandLord(id);

            Assert.AreEqual(forename, updatedLandLord.Forename);
            Assert.AreEqual(surname, updatedLandLord.Surname);
        }

        [Test]
        public void Test_DeleteLandLord()
        {
            var id = dp.CreateLandLord(testLandLord);

            dp.DeleteLandLord(id);

            var deletedLandlord = dp.GetLandLord(id);
            Assert.IsNull(deletedLandlord);
        }
        #endregion

        #region Property CRUD

        [Test]
        public void Test_CreateProperty()
        {
            var llid =  dp.CreateLandLord(testLandLord);
            var propId =  dp.CreateProperty(testPropertyOne, llid);
            Assert.AreNotEqual(0, propId);
        }

        [Test]
        public void Test_CreateProperty_Null()
        {
            var llid = dp.CreateLandLord(testLandLord);
            var propId = dp.CreateProperty(null, llid);
            Assert.AreEqual(0, propId);
        }

        [Test]
        public void Test_UpdateProperty()
        {
            var available = new DateTime(2000, 01, 01);
            var houseNumber = "753";
            var postCode = "#New#Post#Code";

            var status = PropertyStatus.Let;
            var town = "Wimbledon";
            var street = "downing street";

            var llid = dp.CreateLandLord(testLandLord);
            var propId = dp.CreateProperty(testPropertyOne, llid);
            var dto = dp.GetProperty(propId);

            Assert.AreNotEqual(0, propId);
        }
        #endregion
    }
}
