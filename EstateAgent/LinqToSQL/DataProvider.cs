using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EstateAgent.LinqToSQL
{
    public class DataProvider
    {
        EstateAgentDataContext dataContext;

        public DataProvider()
        {
            var configName = "EstateAgent.Properties.Settings.dgcodetest_AOConnectionString";
            var connectionString = ConfigurationManager.ConnectionStrings[configName].ToString();
            dataContext = new EstateAgentDataContext();
        }


        #region Data Readers
        //public IQueryable<Landlord> LandLords
        //{
        //    get { return dataContext.Landlords; }
        //}

        public IEnumerable<LandlordDTO> LandLordDTOs
        {
            get
            {
                return dataContext.Landlords
                    .Select( ll => new LandlordDTO(ll))
                    .ToArray();
            }
        }


        //public IQueryable<Property> Properties
        //{
        //    get {return dataContext.Properties;}
        //}

        public IEnumerable<PropertyDTO> PropertyDTOs
        {
            get {
                return dataContext.Properties
                    .Select(p => new PropertyDTO(p))
                    .ToArray();
                }
        }

        public IQueryable<PropertyDTO> GetPropertiesOfLandlord(int landlordId)
        {
            return dataContext.Properties
                .Where(p => p.LandlordId == landlordId)
                .Select(p => new PropertyDTO(p));
        }
        #endregion


        #region CRUD LandLord Methods

        public int CreateLandLord(LandlordDTO dto)
        {
            if (dto is null) return 0;

            var landlord = new Landlord()
            {
                Forename = dto.Forename,
                Surname = dto.Surname,
                Email = dto.Email,
                Phone = dto.Phone
            };
            dataContext.Landlords.InsertOnSubmit(landlord);

            dataContext.SubmitChanges();

            return landlord.LandlordId;       
        }

        public LandlordDTO GetLandLord(int landLordId)
        {
            var landLord = dataContext.Landlords.SingleOrDefault(ll => ll.LandlordId == landLordId);

            if (landLord is null) return null;

            return new LandlordDTO(landLord);
        }
        
        public void UpdateLandLord(LandlordDTO landLord)
        {
            var original =  dataContext.Landlords.Single(ll => ll.LandlordId == landLord.Id);

            original.Forename = landLord.Forename;
            original.Surname = landLord.Surname;
            original.Email = landLord.Email;
            original.Phone = landLord.Phone;

            dataContext.SubmitChanges();
        }

        public void DeleteLandLord(int landLordId)
        {
            var landlord = dataContext.Landlords.Single(ll => ll.LandlordId == landLordId);
            var landLordProperties = dataContext.Properties.Where(p => p.LandlordId == landLordId);

            dataContext.Properties.DeleteAllOnSubmit(landLordProperties);
            dataContext.Landlords.DeleteOnSubmit(landlord);
            dataContext.SubmitChanges();
        }

        #endregion

        #region CRUD Property Methods

        public int CreateProperty(PropertyDTO dto)
        {
            if (dto is null) return 0;

            var property = new Property()
            {
                AvailableFrom = dto.AvailableFrom,
                Housenumber = dto.Housenumber,
                LandlordId = dto.LandlordId,
                PostCode = dto.PostCode,
                Status = dto.Status.ToString(),
                Street = dto.Street,
                Town = dto.Town,
            };
            dataContext.Properties.InsertOnSubmit(property);
            dataContext.SubmitChanges();

            return property.PropertyId;
        }


        public PropertyDTO GetProperty(int propertyId)
        {
            var property = dataContext.Properties.SingleOrDefault(ll => ll.PropertyId == propertyId);

            if (property is null) return null;

            return new PropertyDTO(property);
        }

        public void UpdateProperty(PropertyDTO prop)
        {
            var original = dataContext.Properties.Single(ll => ll.PropertyId == prop.Id);

            original.AvailableFrom = prop.AvailableFrom;
            original.Housenumber = prop.Housenumber;
            original.PostCode = prop.PostCode;

            original.Status = prop.Status.ToString();
            original.Street = prop.Street;
            original.Town = prop.Town;

            dataContext.SubmitChanges();
        }


        public void DeleteProperty(int propertyId)
        {
            var property = dataContext.Properties.Single(prop => prop.PropertyId == propertyId);
            dataContext.Properties.DeleteOnSubmit(property);
            dataContext.SubmitChanges();
        }
        #endregion
    }
}
