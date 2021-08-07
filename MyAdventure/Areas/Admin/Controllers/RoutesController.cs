namespace MyAdventure.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class RoutesController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
