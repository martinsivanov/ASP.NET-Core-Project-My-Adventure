namespace MyAdventure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.User;
    public class User : IdentityUser
    {
        //[MaxLength(UserFirstNameMaxLenght)]
        //public string FirstName { get; set; }

        //[MaxLength(UserLastNameMaxLenght)]
        //public string LastName { get; set; }

        //[MaxLength(UserCityMaxLenght)]
        //public string City { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
