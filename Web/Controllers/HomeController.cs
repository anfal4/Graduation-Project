using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;


namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<admin> _Admin;
        private readonly IUnitOfWork<research> _resear;
        //private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(
            IUnitOfWork<admin> Admin,
            IUnitOfWork<research> resear
            //,
            //SignInManager<ApplicationUser> signInManager
            )
        {
            _Admin = Admin;
            _resear = resear;
            //_signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginModelView model, string ReturnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(model.UserName,
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

        public IActionResult search()
        {
        //    //البحث عن النتائج بالتايبل الاول واحفظ النتائج بمتغير اسمه تيبل1 ريسيلت
        //    var table1Result = admin.admins.where(x => x.name.equle(xxxx)).tolist();

        //    // اذا نتائج التيبل الاول فارغه
        //    if (table1Result == null)
        //    {
        //        // ابحث بالتيبل الثاني
        //        var table2Result = research.Research.where(x => x.name.equle(xxxx)).tolist();
        //    }
            return View();
        }
        public IActionResult Index2()
        {
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }
        public IActionResult profile()
        {
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().OrderBy(a => a.reads).Reverse().ToList()
            };

            return View(homeViewModel);
        }


        //[HttpGet]
        //public IActionResult CreateAccount()
        //{
        //    return View();
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


        public IActionResult Mohsin()
        {
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Mustafa()
        {
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Enas()
        {
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Elaf()
        {
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Roaa()
        {
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Zainab()
        {
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Harith()
        {
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }


        public IActionResult Hiba()
        {
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }


        public IActionResult Publications()
        {
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().OrderBy(a => a.reads).Reverse().ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Preview(Guid id)
        {
            var preview = _resear.Entity.GetById(id);
            preview.reads++;
            _resear.Save();

            //return View();
            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);

        }
    }
}
