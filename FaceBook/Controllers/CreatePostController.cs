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
    public class CreatePostController : Controller
    {
        private readonly IPostRepository post;
        private readonly UserManager<Applicationuser> userManager;
        public CreatePostController(IPostRepository post, UserManager<Applicationuser> userManager)
        {
            this.post = post;
            this.userManager = userManager;
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
        [HttpPost]
        public async Task<IActionResult> deletePost(int id)
        {
            post.deletePost(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
