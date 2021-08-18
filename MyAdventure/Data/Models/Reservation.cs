namespace MyAdventure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.User;

    public class Reservation
    {
        public int Id { get; set; }

        public int GuideId { get; set; }

        public int RouteId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(UserFirstNameMaxLenght)]
        public string UserFirstName { get; set; }

        [Required]
        [MaxLength(UserLastNameMaxLenght)]
        public string UserLastName { get; set; }

        [Required]
        [MaxLength(UserPhoneNumberMaxLenght)]
        public string UserPhoneNumber { get; set; }

        [Required]
        [MaxLength(UserCityMaxLenght)]
        public string UserCity { get; set; }

        public Route Route { get; set; }

        public Guide Guide { get; set; }

        public User User { get; set; }
    }
}
