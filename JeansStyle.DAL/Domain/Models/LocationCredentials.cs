using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.DAL.Domain.Models
{
    public class LocationCredentials
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public int NumberOfWarehouse { get; set; }
    }
}
