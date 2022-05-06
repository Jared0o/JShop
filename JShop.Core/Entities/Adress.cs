using JShop.Core.Entities.Common;
using JShop.Core.Entities.Identity;

namespace JShop.Core.Entities
{
    public class Adress : AuditableEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public User User { get; set; }

        /// <summary>
        /// FOR EFCORE
        /// </summary>
        private Adress()
        {

        }

        public Adress(string name, string country, string city, string street, string houseNumber, string zipCode, string email, string telephone, User user)
        {
            Name = name;
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            ZipCode = zipCode;
            Email = email;
            Telephone = telephone;
            User = user;
        }
    }
}
