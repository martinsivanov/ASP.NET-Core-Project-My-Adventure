namespace MyAdventure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.BlogPost;

    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ContentMaxLenght)]
        public string Content { get; set; }

        [Required]
        [MaxLength(AuthorMaxLenght)]
        public string Author { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
