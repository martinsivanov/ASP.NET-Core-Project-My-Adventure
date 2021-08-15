namespace MyAdventure.Models.Reservations
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.User;
    public class ReservationFormModel
    {

        public string RouteName { get; set; }

        [Required(ErrorMessage = "Името не е попълнено.")]
        [Display(Name = "Име:")]
        [StringLength(UserFirstNameMaxLenght, ErrorMessage = "Името трябва да е между {2} и {1} символа.", MinimumLength = UserFirstNameMinLenght)]
        public string FistName { get; set; }

        [Required(ErrorMessage = "Фамилията не е попълнена.")]
        [Display(Name = "Фамилия:")]
        [StringLength(UserLastNameMaxLenght, ErrorMessage = "Фамилията трябва да е между {2} и {1} символа.", MinimumLength = UserLastNameMinLenght)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Телефона не е попълнен.")]
        [Display(Name = "Телефон:")]
        [StringLength(UserPhoneNumberMaxLenght, ErrorMessage = "Телефона трябва да е между {2} и {1} символа.", MinimumLength = UserPhoneNumberMinLenght)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Населеното място не е попълнено.")]
        [Display(Name = "Населено място:")]
        [StringLength(UserCityMaxLenght, ErrorMessage = "Населеното място трябва да е между {2} и {1} символа.", MinimumLength = UserCityMinLenght)]
        public string City { get; set; }

        public int GuideId { get; set; }
        public int RouteId { get; set; }

    }
}
