namespace MyAdventure.Models.Guides
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Guide;

    public class BecomeGuideFormModel
    {
        [Required]
        [MaxLength(GuideNameMaxLenght)]
        [MinLength(GuideNameMinLenght)]
        [Display(Name = "Име:")]
        public string Name { get; set; }

        [Required]
        [MaxLength(GuidePhoneMaxLenght)]
        [MinLength(GuidePhoneMinLenght)]
        [Display(Name = "Телефонен номер:")]
        public string PhoneNumber { get; set; }
    }
}
