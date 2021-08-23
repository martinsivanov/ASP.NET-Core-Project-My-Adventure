﻿namespace MyAdventure.Services.BlogPosts
{
    using MyAdventure.Models.BlogPosts;
    using MyAdventure.Services.BlogPosts.Models;
    using System.Collections.Generic;

    public interface IBlogPostService
    {
        public void Create(BlogPostFormModel blog);

        public IEnumerable<BlogPostServiceModel> All();
        public BlogPostServiceModel Details(int id);
        public bool IsPostExists(int id);

        public bool Remove(int id);
    }
}
