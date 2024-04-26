using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using FaceBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace FaceBook.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IPostRepository _postRepository;
        private readonly UserManager<Applicationuser> _userManager;

        public ProfileController(IProfileRepository profileRepository, IPostRepository postRepository, UserManager<Applicationuser> userManager)
        {
            _profileRepository = profileRepository;
            _postRepository = postRepository;
            _userManager = userManager;
        }
        public IActionResult Index(string id)
        {
            Applicationuser user = _profileRepository.getProfile(id);
            id = _profileRepository.getProfileId(id);
            List<PostViewModel> postsList = new List<PostViewModel>();
            var posts = _postRepository.getUserPosts(id);
            foreach (var item in posts)
            {
                PostViewModel postVM = new PostViewModel();
                postVM.Id = item.Id;
                postVM.Body = item.Body;
                postVM.Image = item.Image;
                postVM.Created = item.Created;
                postVM.UserId = item.UserId;
                postVM.User = item.User;
                postsList.Add(postVM);
            }
            List<string> images = _postRepository.GetPostsImages(id);
            ViewBag.images = images;
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            ViewBag.currentUserId = currentUserId;
            ViewBag.user = user;
            ViewBag.posts = postsList;
            ViewBag.userImage = user.Img;
            return View();
        }
    }
}
