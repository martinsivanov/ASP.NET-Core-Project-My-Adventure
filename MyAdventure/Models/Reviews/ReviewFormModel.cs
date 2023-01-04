namespace MyAdventure.Models.Reviews
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.User;

    public class ReviewFormModel
    {
        [Required(ErrorMessage = "Името не е попълнено.")]
        [Display(Name = "Име:")]
        [StringLength(UserFirstNameMaxLength, ErrorMessage = "Името трябва да е между {2} и {1} символа.", MinimumLength = UserFirstNameMinLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Съдържанието към отзива не е попълнен.")]
        [Display(Name = "Съдържание към отзива:")]
        [StringLength(UserReviewContentMaxLength, ErrorMessage = "Името трябва да е между {2} и {1} символа.", MinimumLength = UserReviewContentMinLength)]
        public string Content { get; set; }

    }
}
