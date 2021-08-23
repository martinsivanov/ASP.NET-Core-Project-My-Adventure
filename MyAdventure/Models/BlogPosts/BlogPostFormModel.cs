namespace MyAdventure.Models.BlogPosts
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.BlogPost;

    public class BlogPostFormModel
    {
        [Required(ErrorMessage = "Заглавието не е попълнено.")]
        [StringLength(TitleMaxLenght,ErrorMessage = "Заглавието трябва да е между {1} и {2} символа", MinimumLength = TitleMinLenght)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Автора не е попълнен.")]
        [StringLength(AuthorMaxLenght, ErrorMessage = "Името на Автора трябва да е между {1} и {2} символа", MinimumLength = AuthorMinLenght)]
        public string Author { get; set; }

        [Required(ErrorMessage = "Съдържанието не е попълнено.")]
        [StringLength(ContentMaxLenght, ErrorMessage = "Съдържанието трябва да е между {1} и {2} символа", MinimumLength = ContentMinLenght)]
        public string Content { get; set; }

        [Required(ErrorMessage = "URL адреса не е попълнен.")]
        [Url(ErrorMessage = "Невалиден адрес")]
        public string ImageUrl { get; set; }
    }
}
