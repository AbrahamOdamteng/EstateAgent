using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateAgent.LinqToSQL
{
    public class LandlordDTO
    {
        public readonly int Id;

        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public LandlordDTO() { }

        public LandlordDTO(string forename, string surname, string email, string phone)
        {
            Forename = forename;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

        public LandlordDTO(Landlord landlord)
        {
            Id = landlord.LandlordId;
            Forename = landlord.Forename;
            Surname = landlord.Surname;
            Email = landlord.Email;
            Phone = landlord.Phone;
        }

        public LandlordDTO(LandlordDTO copy)
        {
            Id = copy.Id;
            Forename = copy.Forename;
            Surname = copy.Surname;
            Email = copy.Email;
            Phone = copy.Phone;
        }
    }
}
