//using Core.Entities;
//using Infrastructure;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Web.Controllers
//{
//    public class VisitorController : Controller
//    {
        
//            private readonly DataContext _context;

//            public VisitorController(DataContext context)
//            {
//                _context = context;
//            }

//            public async Task<int> GetTotalVisitorsAsync()
//            {
//                var visitor = await _context.Visitors.FirstOrDefaultAsync();
//                return visitor?.TotalVisitors ?? 0;
//            }

//            public async Task IncrementVisitorCountAsync()
//            {
//                var visitor = await _context.Visitors.FirstOrDefaultAsync();
//                if (visitor == null)
//                {
//                    visitor = new VisitorCount { TotalVisitors = 1 };
//                    _context.Visitors.Add(visitor);
//                }
//                else
//                {
//                    visitor.TotalVisitors++;
//                }
//                await _context.SaveChangesAsync();
            
//        }



//        //public async Task<IActionResult> Visitor([FromServices] DataContext dbContext)
//        //{
//        //    var visitCounter = await dbContext.Visitors.FirstOrDefaultAsync();
//        //    //ViewBag.VisitCount = visitCounter?.Count ?? 0;
//        //    ViewBag.VisitCount = visitCounter?.TotalVisitors ?? 0;

//        //    return View();
//        //}

//        public async Task<IActionResult> Visitor()
//        {
//            await IncrementVisitorCountAsync(); // Increment visitor count
//            var visitCounter = await _context.Visitors.FirstOrDefaultAsync(); // Then, fetch the updated count
//            ViewBag.VisitCount = visitCounter?.TotalVisitors ?? 0; // Use null conditional operator to safely access TotalVisitors
//            return View();
//        }

//    }
//}
