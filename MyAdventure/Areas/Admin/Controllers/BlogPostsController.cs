namespace MyAdventure.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Models.BlogPosts;
    using MyAdventure.Services.BlogPosts;

    public class BlogPostsController : AdminController
    {
        private readonly IBlogPostService blogPostService;

        public BlogPostsController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        public IActionResult All()
        {
            var blogPosts = this.blogPostService.All();

            return this.View(blogPosts);
        }

        public IActionResult Add()
        {
            return this.View(new BlogPostFormModel());
        }

        [HttpPost]
        public IActionResult Add(BlogPostFormModel blog)
        {

            this.blogPostService.Create(blog);

            return RedirectToAction(nameof(All));

        }

        public IActionResult Remove(int id)
        {

            if (!this.blogPostService.IsPostExists(id))
            {
                return BadRequest();
            }

            this.blogPostService.Remove(id);

            return RedirectToAction(nameof(All));
        }
    }
}
