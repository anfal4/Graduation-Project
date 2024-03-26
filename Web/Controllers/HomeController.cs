using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels;


namespace Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly IUnitOfWork<admin> _Admin;
        private readonly IUnitOfWork<research> _resear;
        private DataContext _context;

        public HomeController(
            IUnitOfWork<admin> Admin,
            IUnitOfWork<research> resear,
            DataContext context
            )
        {
            _Admin = Admin;
            _resear = resear;
            _context = context;
        }
        public IActionResult Index()
        {

            var homeViewModel = new HomeViewModel
            {
                admin = _Admin.Entity.GetAll().ToList(),
                researches = _resear.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
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

        public IActionResult search(string q)
        {

            var res = _context.researches.Where(
                x => x.ResearchName.Contains(q) ||
                x.owner.Contains(q) ||
                x.owner2.Contains(q) ||
                x.year.Contains(q)||
                x.Author3.Contains(q)
            );

            if (!res.Any())
            {
                ViewBag.ErrorMessage = "NO Result !";

                return View("NotFound");

            }
            else
            {
                return View(res);

            }

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



        public async Task<IActionResult> Preview(Guid id)
        {
            var preview = await _resear.Entity.FirstOrDefaultAsync(m => m.Id == id);

            if (preview == null)
            {
                return NotFound();
            }

            preview.reads++;
            await _resear.SaveChangesAsync();

            // استخدم Query() للحصول على IQueryable ومن ثم استخدم ToListAsync()
            var adminList = await _Admin.Entity.Query().ToListAsync();
            var researchList = await _resear.Entity.Query().ToListAsync();

            var homeViewModel = new HomeViewModel
            {
                admin = adminList,
                researches = researchList
            };


            // إنشاء وتعبئة ViewModel
            var viewModel = new AddResearchViewModel
            {
                ResearchName = preview.ResearchName,
                Discription = preview.Discription,
                year = preview.year,
                link = preview.link,
                reads = preview.reads,
                owner = preview.owner,
                owner2 = preview.owner2,
                Author3 = preview.Author3

                // تعبئة أي خصائص أخرى حسب الحاجة
            };

            return View(viewModel);
        }



        


        //public async Task<IActionResult> VisitCounter([FromServices] DataContext dbContext)
        //{
        //    var visitCounter = await dbContext.visitorCounts.FirstOrDefaultAsync();
        //    ViewBag.VisitCount = visitCounter?.Count ?? 0;
        //    return View();
        //}

        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> VisitCounter()
        {
            // Get the visitor's IP address
            IPHostEntry iPHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            string ipAddress = Convert.ToString(iPHostEntry.AddressList.FirstOrDefault(address => address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork));

            // Check if the IP address exists in the database
            var visitorRecord = await _context.visitorCounts.FirstOrDefaultAsync(vc => vc.IPAddress == ipAddress);

            if (visitorRecord != null)
            {
                // If exists, increment the visit count and update the last visit
                visitorRecord.Count++;
                visitorRecord.LastVisit = DateTime.UtcNow;
            }
            else
            {
                // If new, create a new record
                visitorRecord = new VisitorCount
                {
                    IPAddress = ipAddress,
                    Count = 1,
                    LastVisit = DateTime.UtcNow
                };
                _context.visitorCounts.Add(visitorRecord);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Optional: Pass the total visit count to the view
            var totalVisits = await _context.visitorCounts.SumAsync(vc => vc.Count);
            var uniqueIPCount = await _context.visitorCounts.Select(vc => vc.IPAddress).Distinct().CountAsync();

            ViewBag.TotalVisits = totalVisits;
            ViewBag.UniqueIPCount = uniqueIPCount; // Now, this holds the count of unique IP addresses


            // Assuming _context.visitorCounts is accessible and DbContext is properly configured
            var visitorCounts = await _context.visitorCounts
                .Select(vc => new VisitorCountViewModel
                {
                    Id = vc.Id,
                    IPAddress = vc.IPAddress,
                    Count = vc.Count,
                    LastVisit = vc.LastVisit
                })
                .ToListAsync();

            // Now passing an IEnumerable<VisitorCountViewModel> to the view
            return View(visitorCounts);
        }



        


        public async Task<IActionResult> Comments(Guid id)
        {
           

                var research = await _context.researches.Include(r => r.comments).FirstOrDefaultAsync(m => m.Id == id);
                if (research == null)
                {
                    return NotFound();
                }


                // إنشاء وتعبئة ViewModel
                var viewModel = new AddResearchViewModel
                {
                    // تعبئة بيانات البحث
                    comments = research.comments.ToList(),

                    ResearchName = research.ResearchName,
                    Discription = research.Discription,
                    year = research.year,
                    link = research.link,
                    reads = research.reads,
                    Comments = research.Comments,
                    owner = research.owner,
                    owner2 = research.owner2,
                    Author3= research.Author3

                    // تعبئة أي خصائص أخرى حسب الحاجة
                };

                return View(viewModel);
            

        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(AddResearchViewModel model)
        {
            
                if (ModelState.IsValid)
                {
                    var comment = new AddResearchViewModel
                    {
                        Text = model.Text,
                        //Author = User.Identity.Name, // Assuming the user is logged in
                        Author =model.Author,
                        DatePosted = DateTime.UtcNow,
                        Id = model.Id
                    };

                    //_context.researches.Add(comment);
                    await _context.SaveChangesAsync();

                return RedirectToAction("Comments", "home");
            }
            return RedirectToAction("Comments", "home");

        }



    }
}
