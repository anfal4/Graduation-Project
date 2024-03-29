﻿using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Web.Controllers
{

    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        //private readonly ILogger<ApplicationUser> logger;
        //private readonly IEmailSender emailSender;


        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager
                                 //,ILogger<ApplicationUser> logger
                                 /*, IEmailSender emailSender*/)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            //this.logger = logger;
            //this.emailSender = emailSender;


        }

        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Find the user by email
        //        var user = await userManager.FindByEmailAsync(model.Email);
        //        // If the user is found AND Email is confirmed
        //        if (user != null && await userManager.IsEmailConfirmedAsync(user))
        //        {
        //            // Generate the reset password token
        //            var token = await userManager.GeneratePasswordResetTokenAsync(user);

        //            // Build the password reset link
        //            var passwordResetLink = Url.Action("ResetPassword", "Account",
        //                    new { email = model.Email, token = token }, Request.Scheme);

        //            // Log the password reset link
        //            logger.Log(LogLevel.Warning, passwordResetLink);

        //            // Send the user to Forgot Password Confirmation view
        //            return View("ForgotPasswordConfirmation");
        //        }

        //        // To avoid account enumeration and brute force attacks, don't
        //        // reveal that the user does not exist or is not confirmed
        //        return View("ForgotPasswordConfirmation");
        //    }

        //    return View(model);
        //}

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new ApplicationUser
                {
                    //Name = model.UserName,
                    //UserName= model.Name,

                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    organization = model.organization,
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController

                if (result.Succeeded)
                {
                    
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
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
        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> ConfirmEmail(string userId, string token)
        //{
        //    if (userId == null || token == null)
        //    {
        //        return RedirectToAction("index", "home");
        //    }

        //    var user = await userManager.FindByIdAsync(userId);

        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
        //        return View("NotFound");
        //    }

        //    var result = await userManager.ConfirmEmailAsync(user, token);

        //    if (result.Succeeded)
        //    {
        //        return View();
        //    }

        //    ViewBag.ErrorTitle = "Email cannot be confirmed";
        //    return View("Error");
        //}

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model , string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);


                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        ////[HttpPost]
        ////public async Task<IActionResult> Login(LoginViewModel model)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        var result = await signInManager.PasswordSignInAsync(
        ////            model.Email, model.Password, model.RememberMe, false);

        ////        if (result.Succeeded)
        ////        {
        ////            return RedirectToAction("index", "home");
        ////        }

        ////        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        ////    }

        ////    return View(model);
        ////}

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
    }
}


//        [AllowAnonymous]
//public async Task<IActionResult>
//ExternalLoginCallback(string returnUrl = null, string remoteError = null)
//{
//    returnUrl = returnUrl ?? Url.Content("~/");

//    LoginViewModel loginViewModel = new LoginViewModel
//    {
//        ReturnUrl = returnUrl,
//        ExternalLogins =
//        (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
//    };

//    if (remoteError != null)
//    {
//        ModelState.AddModelError(string.Empty,
//            $"Error from external provider: {remoteError}");

//        return View("Login", loginViewModel);
//    }

//    var info = await signInManager.GetExternalLoginInfoAsync();
//    if (info == null)
//    {
//        ModelState.AddModelError(string.Empty,
//            "Error loading external login information.");

//        return View("Login", loginViewModel);
//    }

//    var email = info.Principal.FindFirstValue(ClaimTypes.Email);
//    ApplicationUser user = null;

//    if (email != null)
//    {
//        user = await userManager.FindByEmailAsync(email);

//        if (user != null && !user.EmailConfirmed)
//        {
//            ModelState.AddModelError(string.Empty, "Email not confirmed yet");
//            return View("Login", loginViewModel);
//        }
//    }

//    var signInResult = await signInManager.ExternalLoginSignInAsync(
//                                info.LoginProvider, info.ProviderKey,
//                                isPersistent: false, bypassTwoFactor: true);

//    if (signInResult.Succeeded)
//    {
//        return LocalRedirect(returnUrl);
//    }
//    else
//    {
//        if (email != null)
//        {
//            if (user == null)
//            {
//                user = new ApplicationUser
//                {
//                    UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
//                    Email = info.Principal.FindFirstValue(ClaimTypes.Email)
//                };

//                await userManager.CreateAsync(user);

//                // After a local user account is created, generate and log the
//                // email confirmation link
//                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

//                var confirmationLink = Url.Action("ConfirmEmail", "Account",
//                                new { userId = user.Id, token = token }, Request.Scheme);

//                logger.Log(LogLevel.Warning, confirmationLink);

//                ViewBag.ErrorTitle = "Registration successful";
//                ViewBag.ErrorMessage = "Before you can Login, please confirm your " +
//                    "email, by clicking on the confirmation link we have emailed you";
//                return View("Error");
//            }

//            await userManager.AddLoginAsync(user, info);
//            await signInManager.SignInAsync(user, isPersistent: false);

//            return LocalRedirect(returnUrl);
//        }

//        ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
//        ViewBag.ErrorMessage = "Please contact support on Pragim@PragimTech.com";

//        return View("Error");
//    }
//}


//        [HttpGet]
//        [AllowAnonymous]
//        public IActionResult ResetPassword(string token, string email)
//        {
//            // If password reset token or email is null, most likely the
//            // user tried to tamper the password reset link
//            if (token == null || email == null)
//            {
//                ModelState.AddModelError("", "Invalid password reset token");
//            }
//            return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                // Find the user by email
//                var user = await userManager.FindByEmailAsync(model.Email);

//                if (user != null)
//                {
//                    // reset the user password
//                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
//                    if (result.Succeeded)
//                    {
//                        return View("ResetPasswordConfirmation");
//                    }
//                    // Display validation errors. For example, password reset token already
//                    // used to change the password or password complexity rules not met
//                    foreach (var error in result.Errors)
//                    {
//                        ModelState.AddModelError("", error.Description);
//                    }
//                    return View(model);
//                }

//                // To avoid account enumeration and brute force attacks, don't
//                // reveal that the user does not exist
//                return View("ResetPasswordConfirmation");
//            }
//            // Display validation errors if model state is not valid
//            return View(model);
//        }
//    }
//}

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




//var user = await userManager.FindByEmailAsync(model.Email);
//if (user != null && /*!user.EmailConfirmed &&*/
//    (await userManager.CheckPasswordAsync(user, model.Password)))
//{
//    //ModelState.AddModelError(string.Empty, "Email not confirmed yet");
//    return View(model);
//}



//[AcceptVerbs("Get", "Post")]
//[AllowAnonymous]
//public async Task<IActionResult> IsUniversityMail(string email)
//{

//    //var user = await userManager.FindByEmailAsync(email);
//    //string[] domain = email.Split('@');
//    if (email.Contains(".edu"))
//    {
//        return Json(true);
//    }
//    else
//    {
//        return Json($"Email {email} is not University mail");
//    }

//}