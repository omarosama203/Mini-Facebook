using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Contexts;
using DataAccessLayer.ViewModel;

namespace FaceBook.Controllers
{
    public class AccountController : Controller
    {

        public UserManager<Applicationuser> userManger { get; }
        public SignInManager<Applicationuser> signInManager { get; }
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(UserManager<Applicationuser> userManger, SignInManager<Applicationuser> signInManager, IWebHostEnvironment webHostEnvironment)

        {
            this.userManger = userManger;
            this.signInManager = signInManager;
            this._webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                DateOnly minDate = new DateOnly(2012, 1, 1);
                if (userVm.Birthdate.Year > minDate.Year)
                {
                    ModelState.AddModelError("Birthdate", "You must be at least 13 years old to register.");
                    return View(userVm);
                }
                Applicationuser user = new Applicationuser();
                user.FirstName = userVm.FirstName;
                user.LastName = userVm.LastName;
                user.UserName = userVm.UserName;
                user.Email = userVm.Email;
                user.PasswordHash = userVm.Password;
                user.PhoneNumber = userVm.PhoneNumber;
                user.Birthdate = userVm.Birthdate;
                user.Gender = userVm.Gender;
                user.Country = userVm.Country;
                user.Img = userVm.Img;
                if (string.IsNullOrWhiteSpace(userVm.Img))
                {
                    string defaultImgFileName = userVm.Gender.ToLower() == "male" ? "male.jpg" : "female.jpg";
                    string defaultImgPath = Path.Combine(_webHostEnvironment.WebRootPath, "Img", defaultImgFileName);
                    byte[] defaultImgBytes = await System.IO.File.ReadAllBytesAsync(defaultImgPath);
                    user.Img = defaultImgFileName;
                }
                else
                {
                    user.Img = userVm.Img;
                }
                IdentityResult Result = await userManger.CreateAsync(user, userVm.Password);
                if (Result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in Result.Errors)
                    {
                        ModelState.AddModelError("Password", error.Description);
                    }
                }
            }
            return View(userVm);

        }
    }
}
