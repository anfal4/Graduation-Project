using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize(Roles = "Admins")]

    public class AddUserController : Controller
    {
        private readonly IUnitOfWork<ApplicationUser> _portfolio;
        private readonly IHostingEnvironment _hosting;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        

        public AddUserController(IUnitOfWork<ApplicationUser> portfolio, IHostingEnvironment hosting, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _portfolio = portfolio;
            _hosting = hosting;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        // GET: PortfolioItems
        public IActionResult Index()
        {
            return View(_portfolio.Entity.GetAll());
        }


        // GET: PortfolioItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortfolioItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {


                ApplicationUser User = new ApplicationUser
                {
                    Name = model.Name,
                    Email = model.Email,
                    organization = model.organization,
                    PasswordHash = model.Password,

                };

                _portfolio.Entity.Insert(User);
                _portfolio.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("Index");
            }

        }

    }
}
