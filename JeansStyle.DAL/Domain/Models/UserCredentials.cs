using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.DAL.Domain.Models
{
    public class UserCredentials
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public LocationCredentials LocationCredentials { get; set; }
    } 
}
