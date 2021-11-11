using MyAdventure.Data;
using MyAdventure.Data.Models;
using MyAdventure.Services.BlogPosts.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyAdventure.Services.BlogPosts
{
    public class BlogPostService : IBlogPostService
    {
        private readonly MyAdventureDbContext data;

        public BlogPostService(MyAdventureDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<BlogPostServiceModel> All()
        {
            return this.data.BlogPosts
                .Select(x => new BlogPostServiceModel
                {
                    Author = x.Author,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl,
                    Title = x.Title,
                    Id = x.Id
                })
                .ToList();
        }

        public void Create(BlogPostServiceModel blog)
        {
            var blogPost = new BlogPost
            {
                Author = blog.Author,
                Content = blog.Content,
                ImageUrl = blog.ImageUrl,
                Title = blog.Title
            };

            this.data.BlogPosts.Add(blogPost);
            this.data.SaveChanges();
        }

        public BlogPostServiceModel Details(int id)
        {
            return this.data.BlogPosts.Select(x => new BlogPostServiceModel
            {
                Id = x.Id,
                Author = x.Author,
                Content = x.Content,
                ImageUrl = x.ImageUrl,
                Title = x.Title
            })
                .FirstOrDefault();

        }

        public bool IsPostExists(int id)
        {
            return this.data.BlogPosts.Any(x => x.Id == id);
        }

        public bool Remove(int id)
        {
            var post = this.data.BlogPosts.FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                return false;
            }

            this.data.BlogPosts.Remove(post);

            this.data.SaveChanges();

            return true;
        }
    }
}
