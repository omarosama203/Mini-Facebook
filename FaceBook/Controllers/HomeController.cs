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
        //private readonly IUserRepository userRepository;

        public HomeController(IPostRepository post, UserManager<Applicationuser> userManager)
        {
            this.post = post;
            this.userManager = userManager;
            //this.userRepository = user;
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
            ViewBag.userid = user.Id;
            return View();
        }
        [HttpGet]
        public IActionResult EditPost(int id)
        {
            var item = this.post.getPostById(id);
            PostViewModel postVM = new PostViewModel
            {
                Id = item.Id,
                Body = item.Body,
                Image = item.Image,
                Created = item.Created,
                UserId = item.UserId,
                User = item.User
            };
            return View(postVM);
        }
        [HttpPost]
        public IActionResult EditPost(PostViewModel post)
        {
            var item= this.post.getPostById(post.Id);
            item.Body = post.Body;
            if (post.ImageFile != null)
            {
                string imageName = ImageDocument.uploadFile(post.ImageFile, "images");
                item.Image = imageName;
            }
            this.post.updatePost(item);
            return RedirectToAction("Index");

        }

        

    }
}
