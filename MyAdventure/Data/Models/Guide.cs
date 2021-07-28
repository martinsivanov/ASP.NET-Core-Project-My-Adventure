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


        public IEnumerable<Route> Routes { get; set; }
    }
}
