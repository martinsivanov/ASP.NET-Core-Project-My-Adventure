namespace MyAdventure.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Services.BlogPosts;

    public class BlogPostsController : Controller
    {
        private readonly IBlogPostService blogPostService;

        public BlogPostsController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        public IActionResult Index()
        {
            var post = this.blogPostService.All();
            return this.View(post);
        }

        public IActionResult Details(int id)
        {
            if (!this.blogPostService.IsPostExists(id))
            {
                return BadRequest();
            }
            var post = this.blogPostService.Details(id);

            return this.View(post);
        }
    }
}
