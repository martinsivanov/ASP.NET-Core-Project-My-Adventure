namespace MyAdventure.Areas.Admin.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Models.BlogPosts;
    using MyAdventure.Services.BlogPosts;
    using MyAdventure.Services.BlogPosts.Models;

    public class BlogPostsController : AdminController
    {
        private readonly IBlogPostService blogPostService;
        private readonly IMapper mapper;

        public BlogPostsController(IBlogPostService blogPostService, IMapper mapper)
        {
            this.blogPostService = blogPostService;
            this.mapper = mapper;
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

           // var createdBlog = this.mapper.Map<BlogPostFormModel>(BlogPostServiceModel);
            //var createdBlog = this.mapper.ProjectTo<BlogPostServiceModel>(BlogPostFormModel);
            this.blogPostService.Create(new BlogPostServiceModel { 
            Title = blog.Title,
            Author = blog.Author,
            Content = blog.Content,
            ImageUrl = blog.ImageUrl
            });

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
