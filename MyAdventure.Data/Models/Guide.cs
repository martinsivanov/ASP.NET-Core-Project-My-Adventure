namespace MyAdventure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Guide;
    public class Guide
    {
        public Guide()
        {
            this.Routes = new HashSet<Route>();
            this.Reservations = new HashSet<Reservation>();
        }

        public int Id { get; init; }

        [Required]
        [MaxLength(GuideNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GuidePhoneMaxLenght)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<Route> Routes { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
