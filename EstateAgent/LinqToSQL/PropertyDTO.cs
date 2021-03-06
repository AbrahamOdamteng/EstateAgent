﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateAgent.LinqToSQL
{
    public class PropertyDTO
    {
        public readonly int Id;
        public readonly int LandlordId;

        public string Housenumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }

        public string PostCode { get; set; }
        public System.DateTime AvailableFrom { get; set; }
        public PropertyStatus Status { get; set; }
        
        public PropertyDTO() { }

        public PropertyDTO(int landlordId)
        {
            LandlordId = landlordId;
            AvailableFrom = DateTime.Now;
        }

        public PropertyDTO(Property prop)
        {
            Id = prop.PropertyId;
            LandlordId = prop.LandlordId;

            Housenumber = prop.Housenumber;
            Street = prop.Street;
            Town = prop.Town;
            PostCode = prop.PostCode;
            AvailableFrom = prop.AvailableFrom;
            Status = (PropertyStatus) Enum.Parse( typeof(PropertyStatus), prop.Status);
        }

        public PropertyDTO(PropertyDTO copy)
        {
            Id = copy.Id;
            LandlordId = copy.LandlordId;

            Housenumber = copy.Housenumber;
            Street = copy.Street;
            Town = copy.Town;
            PostCode = copy.PostCode;
            AvailableFrom = copy.AvailableFrom;
            Status = copy.Status;
        }

        public bool ContainsEmptyValues()
        {
            return string.IsNullOrWhiteSpace(Housenumber) ||
                string.IsNullOrWhiteSpace(Street) ||
                string.IsNullOrWhiteSpace(Town) ||
                string.IsNullOrWhiteSpace(PostCode);
        }
    }
}
