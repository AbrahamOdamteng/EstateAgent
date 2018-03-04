using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateAgent.LinqToSQL
{
    public class LandLordDTO
    {
        public readonly int Id;

        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


        public LandLordDTO() { }

        public LandLordDTO(string forename, string surname, string email, string phone)
        {
            Forename = forename;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

        public LandLordDTO(Landlord landlord)
        {
            Id = landlord.LandlordId;
            Forename = landlord.Forename;
            Surname = landlord.Surname;
            Email = landlord.Email;
            Phone = landlord.Phone;
        }
    }
}
