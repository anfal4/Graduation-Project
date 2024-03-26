using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AddAdminController : Controller
    {
        private readonly IUnitOfWork<admin> _portfolio;
        private readonly IHostingEnvironment _hosting;

        public AddAdminController(IUnitOfWork<admin> portfolio, IHostingEnvironment hosting)
        {
            _portfolio = portfolio;  
            _hosting = hosting;
        }

        // GET: PortfolioItems
        [Authorize(Roles = "Researcher, Admins")]

        public IActionResult Index()
        {
            return View(_portfolio.Entity.GetAll());
        }

        [Authorize(Roles = "Researcher, Admins")]

        // GET: PortfolioItems/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.Entity.GetById(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        [Authorize(Roles = "Admins")]

        // GET: PortfolioItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortfolioItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admins")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"imgeteam");
                    string fullPath = Path.Combine(uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                admin admin = new admin
                {
                    FullName = model.FullName,
                    field = model.field,
                    Avatar = model.File.FileName,
                    Email = model.Email,
                    about = model.about
                };

                _portfolio.Entity.Insert(admin);
                _portfolio.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Authorize(Roles = "Researcher, Admins")]


        // GET: PortfolioItems/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.Entity.GetById(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            NewAdminViewModel portfolioViewModel = new NewAdminViewModel
            {
                Id = portfolioItem.Id,
                FullName = portfolioItem.FullName,
                Avatar = portfolioItem.Avatar,
                field = portfolioItem.field,
                Email=portfolioItem.Email,
                about=portfolioItem.about
            };

            return View(portfolioViewModel);
        }


        [Authorize(Roles = "Researcher, Admins")]
        // POST: PortfolioItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, NewAdminViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.File != null)
                    {
                        string uploads = Path.Combine(_hosting.WebRootPath, @"imgeteam");
                        string fullPath = Path.Combine(uploads, model.File.FileName);
                        model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }

                    admin portfolioItem = new admin
                    {
                        Id = model.Id,
                        FullName = model.FullName,
                        field = model.field,
                        Avatar = model.File.FileName,
                        Email=model.Email,
                        about=model.about
                    };

                    _portfolio.Entity.Update(portfolioItem);
                    _portfolio.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioItemExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PortfolioItems/Delete/5
        [Authorize(Roles = "Admins")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.Entity.GetById(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        // POST: PortfolioItems/Delete/5
        [Authorize(Roles = "Admins")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _portfolio.Entity.Delete(id);
            _portfolio.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioItemExists(Guid id)
        {
            return _portfolio.Entity.GetAll().Any(e => e.Id == id);
        }
    }
}

