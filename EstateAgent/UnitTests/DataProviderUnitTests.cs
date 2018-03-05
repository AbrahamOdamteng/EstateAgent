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

        string PostcodeOne = "{071C1FFE}";
        string PostcodeTwo = "{E5EAA1A6}";

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
                PostCode = PostcodeOne,
                Status = PropertyStatus.Vacant,
                Street = "seasame street",
                Town = "Wimbledon",
            };


            testPropertyTwo = new PropertyDTO()
            {
                AvailableFrom = DateTime.Now,
                Housenumber = "456",
                PostCode = PostcodeOne,
                Status = PropertyStatus.Let,
                Street = "downing street",
                Town = "roswell",
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
            var properties = dp.GetProperties().Where( p => p.PostCode == PostcodeOne || p.PostCode == PostcodeTwo).ToArray();

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
            var status = PropertyStatus.Let;
            var town = "Wimbledon";
            var street = "downing street";

            var llid = dp.CreateLandLord(testLandLord);
            var propId = dp.CreateProperty(testPropertyOne, llid);
            var dto = dp.GetProperty(propId);

            dto.AvailableFrom = available;
            dto.Housenumber = houseNumber;
            dto.Status = status;
            dto.Town = town;
            dto.Street = street;
            dto.PostCode = PostcodeTwo;

            dp.UpdateProperty(dto);

            var updatedDto = dp.GetProperty(propId);

            Assert.AreEqual(available, updatedDto.AvailableFrom);
            Assert.AreEqual(houseNumber, updatedDto.Housenumber);
            Assert.AreEqual(PostcodeTwo, updatedDto.PostCode);
            Assert.AreEqual(status, updatedDto.Status);
            Assert.AreEqual(street, updatedDto.Street);
            Assert.AreEqual(town, updatedDto.Town);
        }

        [Test]
        public void Test_DeleteProperty()
        {
            var llid = dp.CreateLandLord(testLandLord);
            var propId = dp.CreateProperty(testPropertyOne, llid);
            var property = dp.GetProperty(propId);
            Assert.NotNull(property);
            dp.DeleteProperty(propId);

            var delProp = dp.GetProperty(propId);
            Assert.IsNull(delProp);

        }
        #endregion
    }
}
