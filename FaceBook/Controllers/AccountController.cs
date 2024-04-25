﻿using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Contexts;
using DataAccessLayer.ViewModel;
using System.Reflection.Metadata;
using GemBox.Document;
using System.Drawing;
using FaceBook.Helpers;

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


                if (userVm.Image == null)
                {
                    string defaultImgFileName = userVm.Gender.ToLower() == "male" ? "male.jpg" : "female.jpg";
                    string defaultImgPath = Path.Combine(_webHostEnvironment.WebRootPath, "files/images", defaultImgFileName);
                    byte[] defaultImgBytes = await System.IO.File.ReadAllBytesAsync(defaultImgPath);
                    user.Img = defaultImgFileName;
                }
                else
                {
                    string imageName = ImageDocument.uploadFile(userVm.Image, "images");
                    user.Img = imageName;

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


        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(LoginViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                Applicationuser userModel = await userManger.FindByNameAsync(userVm.userName);
                if (userModel != null)
                {
                    bool found = await userManger.CheckPasswordAsync(userModel, userVm.password);
                    if (found)
                    {
                        await signInManager.SignInAsync(userModel, userVm.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("Password", " password or user name is wrong please try again");
            }
            return View(userVm);
        }

        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login");
        }
    }
}
