using Microsoft.AspNetCore.Mvc;

namespace FaceBook.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
