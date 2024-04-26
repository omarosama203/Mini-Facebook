using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FaceBook.Controllers
{
    public class SearchController : Controller
    {
        IUserRepository _userRepository;
      public  SearchController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Search(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                return NoContent();
            }
            var users =_userRepository.searchUser(searchValue);
            return View("SearchPage", users);
        }
    }
}
