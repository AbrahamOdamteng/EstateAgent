using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace EstateAgent
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
        public IQueryable<Landlord> GetLandLords()
        {
            return dataContext.Landlords;
        }

        public Landlord GetLandLord(int landlordId)
        {
            return dataContext.Landlords.Single(l => l.LandlordId == landlordId);
        }

        public IQueryable<Property> GetProperties()
        {
            return dataContext.Properties;
        }

        public Property GetProperty(int propertyId)
        {
            return dataContext.Properties.Single(p => p.PropertyId == propertyId);
        }

        public IQueryable<Property> GetPropertiesOfLandlord(int landlordId)
        {
            return dataContext.Properties.Where(p => p.LandlordId == landlordId);
        }
        #endregion
    }
}
