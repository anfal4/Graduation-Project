using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<admin> _Admin;
        private readonly IUnitOfWork<research> _resear;

        public HomeController(
            IUnitOfWork<admin> Admin,
            IUnitOfWork<research> resear)
        {
            _Admin = Admin;
            _resear = resear;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
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
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }


        public IActionResult CreateAccount()
        {
            return View();
        }

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
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }

    }
}
