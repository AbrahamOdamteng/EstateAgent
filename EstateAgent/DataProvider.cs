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
            throw new NotImplementedException();
        }

        public Property GetProperty()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Property> GetPropertiesOfLandlord(string landlordId)
        {
            throw new NotImplementedException();
        }
    }
}
