namespace MyAdventure.Models.Guides
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Guide;

    public class BecomeGuideFormModel
    {
        [Required(ErrorMessage = "Името на водача е заължително.")]
        [StringLength(GuideNameMaxLenght, ErrorMessage = "Телефона трябва да е между {2} и {1} символа.", MinimumLength = GuideNameMinLenght)]
        [Display(Name = "Име:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Телефона е здължителен.")]
        [StringLength(GuidePhoneMaxLenght, ErrorMessage = "Телефона трябва да е между {2} и {1} символа.", MinimumLength = GuidePhoneMinLenght)]
        [Display(Name = "Телефонен номер:")]
        public string PhoneNumber { get; set; }
    }
}
