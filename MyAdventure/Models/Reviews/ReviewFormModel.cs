namespace MyAdventure.Models.Reviews
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.User;

    public class ReviewFormModel
    {
        [Required(ErrorMessage = "Името не е попълнено.")]
        [Display(Name = "Име:")]
        [StringLength(UserFirstNameMaxLenght, ErrorMessage = "Името трябва да е между {2} и {1} символа.", MinimumLength = UserFirstNameMinLenght)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Съдържанието към отзива не е попълнен.")]
        [Display(Name = "Съдържание към отзива:")]
        [StringLength(UserReviewContentMaxLenght, ErrorMessage = "Името трябва да е между {2} и {1} символа.", MinimumLength = UserReviewContentMinLenght)]
        public string Content { get; set; }

        public int RouteId { get; set; }

    }
}
