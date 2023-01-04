namespace MyAdventure.Models.Reservations
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.User;
    public class ReservationFormModel
    {
        public string RouteName { get; set; }

        [Required(ErrorMessage = "Името не е попълнено.")]
        [Display(Name = "Име:")]
        [StringLength(UserFirstNameMaxLength, ErrorMessage = "Името трябва да е между {2} и {1} символа.", MinimumLength = UserFirstNameMinLength)]
        public string FistName { get; set; }

        [Required(ErrorMessage = "Фамилията не е попълнена.")]
        [Display(Name = "Фамилия:")]
        [StringLength(UserLastNameMaxLength, ErrorMessage = "Фамилията трябва да е между {2} и {1} символа.", MinimumLength = UserLastNameMinLength)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Телефона не е попълнен.")]
        [Display(Name = "Телефон:")]
        [StringLength(UserPhoneNumberMaxLength, ErrorMessage = "Телефона трябва да е между {2} и {1} символа.", MinimumLength = UserPhoneNumberMinLength)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Населеното място не е попълнено.")]
        [Display(Name = "Населено място:")]
        [StringLength(UserCityMaxLength, ErrorMessage = "Населеното място трябва да е между {2} и {1} символа.", MinimumLength = UserCityMinLength)]
        public string City { get; set; }

        public int GuideId { get; set; }

        public int RouteId { get; set; }

        public bool IsGuide { get; set; }

    }
}
