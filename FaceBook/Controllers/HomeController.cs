using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using FaceBook.Helpers;
using FaceBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FaceBook.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPostRepository post;
        private readonly UserManager<Applicationuser> userManager;

        public HomeController(IPostRepository post, UserManager<Applicationuser> userManager)
        {
            this.post = post;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            ViewBag.userImage = user.Img;
            var posts = post.getPostList();
            List<PostViewModel> postsList = new List<PostViewModel>();
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
            ViewBag.posts = postsList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> createPost([FromForm] PostViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                Post postModel = new Post();
                postModel.Body = postVM.Body;
                postModel.Created = postVM.Created;
                postModel.UserId = user.Id;
                if (postVM.ImageFile != null)
                {
                    postModel.Image = ImageDocument.uploadFile(postVM.ImageFile, "images");
                }
                post.createPost(postModel);
                return RedirectToAction("Index", "Home");
            }
            return NoContent();
        }

    }
}
