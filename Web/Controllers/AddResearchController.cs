using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{

    public class AddResearchController : Controller
    {
        private readonly IUnitOfWork<research> _portfolio;

        private readonly IHostingEnvironment _hosting;

        public AddResearchController(IUnitOfWork<research> portfolio, IHostingEnvironment hosting)
        {
            _portfolio = portfolio;
            _hosting = hosting;
        }
        [Authorize(Roles = "Researcher, Admins")]

        // GET: PortfolioItems
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

        [Authorize(Roles = "Researcher, Admins")]

        // GET: PortfolioItems/Create
        public IActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "Researcher, Admins")]
        // POST: PortfolioItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddResearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                

                research research = new research
                {
                    ResearchName = model.ResearchName,
                    Discription = model.Discription,
                    year = model.year,
                    link = model.link,
                    owner = model.owner,
                    owner2 = model.owner2,
                    Author3= model.Author3
                };

                _portfolio.Entity.Insert(research);
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

            AddResearchViewModel portfolioViewModel = new AddResearchViewModel
            {
                Id = portfolioItem.Id,
                ResearchName = portfolioItem.ResearchName,
                Discription = portfolioItem.Discription,
                year = portfolioItem.year,
                link = portfolioItem.link
            };

            return View(portfolioViewModel);
        }

        // POST: PortfolioItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Researcher, Admins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, AddResearchViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    research portfolioItem = new research
                    {
                        Id = model.Id,
                        ResearchName = model.ResearchName,
                        Discription = model.Discription,
                        year = model.year,
                        link = model.link,
                        owner = model.owner,
                        owner2 = model.owner2,
                        Author3 = model.Author3
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
        [Authorize(Roles = "Researcher, Admins")]

        // GET: PortfolioItems/Delete/5
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
        [Authorize(Roles = "Researcher, Admins")]

        // POST: PortfolioItems/Delete/5
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
