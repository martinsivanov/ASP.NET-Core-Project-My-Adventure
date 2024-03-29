﻿namespace MyAdventure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Category;

    public class Category
    {
        public Category()
        {
            this.Routes = new HashSet<Route>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLenght)]
        public string Name { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}
