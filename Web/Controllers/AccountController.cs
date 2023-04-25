using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
           await signInManager.SignOutAsync();
           return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    organization = model.organization,
                    UserName =model.Email
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
    }
}

//[HttpPost]
//public async Task<IActionResult> Register(RegisterViewModel model)
//{
//    if (ModelState.IsValid)
//    {
//        var user = new ApplicationUser { 
//            UserName = model.Name,
//            Email = model.Email ,
//            organization=model.organization,
//            //EmailConfirmed = true
//        };

//        var result = await userManager.CreateAsync(user, model.Password);

//        if (result.Succeeded)
//        {
//           await signInManager.SignInAsync(user, isPersistent: false);
//            return RedirectToAction("Index", "Home");
//        }

//        foreach (var error in result.Errors)
//        {
//            ModelState.AddModelError("", error.Description);
//        }
//    }
//    return View(model);
//}

//[HttpPost]
//public async Task<IActionResult> CreateAccount(UserModelView model)
//{
//    if (ModelState.IsValid)
//    {
//        var user = new IdentityUser { UserName = model.Username, Email = model.Email };
//        var result = await _userManager.CreateAsync(user, model.Password);
//        if (result.Succeeded)
//        {
//            await _userManager.AddToRoleAsync(user, "سوبر أدمن");
//            ModelState.Clear();
//            ViewBag.alertMsg = "تمت ألعملية بنجاح";
//        }
//        foreach (var error in result.Errors)
//        {
//            ModelState.AddModelError("", error.Description);
//        }
//    }
//    return View();
//}
///////////////////////////////////////////
//[HttpGet]
//        public IActionResult Login()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)
//        {
//            if (ModelState.IsValid)
//            {
//                var result = await signInManager.PasswordSignInAsync(model.Email,
//                   model.Password, model.RememberMe, true);

//                if (result.Succeeded)
//                {
//                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
//                    {
//                        return Redirect(ReturnUrl);
//                    }
//                    else
//                    {
//                        return RedirectToAction("Index", "Account");
//                    }
//                }
//                if (result.IsLockedOut)
//                {
//                    ModelState.AddModelError("", "ألحساب معلق");
//                }
//            }
//            ModelState.AddModelError("", "خطأ في ألبريد الألكتروني أو ألرقم ألسري");
//            return View();
//        }






        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await signInManager.PasswordSignInAsync(
        //            model.Email, model.Password, model.RememberMe, false);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }

        //        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        //    }

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await signInManager.PasswordSignInAsync(model.Email,
        //               model.Password, model.RememberMe, true);

        //        if (result.Succeeded)
        //        {
        //            if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
        //            {
        //                return Redirect(ReturnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "Account");
        //            }
        //        }
        //        if (result.IsLockedOut)
        //        {
        //            ModelState.AddModelError("", "ألحساب معلق");
        //        }
        //    }
        //    ModelState.AddModelError("", "خطأ في ألبريد الألكتروني أو ألرقم ألسري");
        //    return View();
        //}
    //}
//}
