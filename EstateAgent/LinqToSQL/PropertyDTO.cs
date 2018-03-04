using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateAgent.LinqToSQL
{
    class PropertyDTO
    {
        public readonly int Id;

        public string Housenumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public System.DateTime AvailableFrom { get; set; }
        public string Status { get; set; }
        public int LandlordId { get; set; }
    }
}
