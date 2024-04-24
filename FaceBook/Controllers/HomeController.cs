using Microsoft.AspNetCore.Mvc;

namespace FaceBook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
