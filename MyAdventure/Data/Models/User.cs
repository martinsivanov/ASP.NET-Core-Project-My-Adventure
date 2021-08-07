namespace MyAdventure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.User;
    public class User : IdentityUser
    {
        [MaxLength(UserFullNameMaxLenght)]
        public string FullName { get; set; }
    }
}
