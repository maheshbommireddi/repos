using System;
using System.Collections.Generic;
using System.Text;

namespace SprintZero.Core.Entities
{
    public class CustomerEntity : EntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Nullable<int> PhoneNumber { get; set; }
        public string BirthData { get; set; }
        public string EmailAddress { get; set; }

    }
}
