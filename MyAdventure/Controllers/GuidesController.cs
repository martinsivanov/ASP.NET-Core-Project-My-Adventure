namespace MyAdventure.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Data;
    using MyAdventure.Data.Models;
    using MyAdventure.Infrastructure;
    using MyAdventure.Models.Guides;
    using System.Linq;

    public class GuidesController : Controller
    {
        private readonly MyAdventureDbContext data;

        public GuidesController(MyAdventureDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Become()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeGuideFormModel guide)
        {
            var userId = this.User.GetId();

            var userIsAlreadyGuide = this.data
                .Guides.Any(x => x.UserId == userId);
            if (userIsAlreadyGuide)
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.View(guide);
            }

            var guideData = new Guide
            {
                Name = guide.Name,
                PhoneNumber = guide.PhoneNumber,
                UserId = userId
            };

            this.data.Guides.Add(guideData);
            this.data.SaveChanges();

            return this.RedirectToAction("All", "Routes");
        }
    }
}
