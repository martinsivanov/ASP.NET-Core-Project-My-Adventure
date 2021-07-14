namespace MyAdventure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class Season
    {
        public Season()
        {
            this.Routes = new HashSet<Route>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(SeasonNameMaxLenght)]
        public string Name { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}
