namespace MyAdventure.Services.Guides
{
    using MyAdventure.Data;
    using System;
    using System.Linq;

    public class GuideService : IGuideService
    {
        private readonly MyAdventureDbContext data;

        public GuideService(MyAdventureDbContext data)
        {
            this.data = data;
        }

        public int GetGuideId(string userId)
        {
            var guidId = this.data.Guides
            .Where(x => x.UserId == userId)
            .Select(x => x.Id)
            .FirstOrDefault();
            return guidId;
        }

        public bool IsGuide(string userId)
        {
            return this.data
                       .Guides
                       .Any(x => x.UserId == userId);
        }
    }
}
