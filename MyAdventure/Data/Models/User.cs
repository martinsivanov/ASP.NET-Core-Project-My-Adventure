namespace MyAdventure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
