using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoccerWebApp.Models;

namespace SoccerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SoccerWebAppContext _context;

        public HomeController(SoccerWebAppContext context)
        {
            _context = context;
        }

        // GET: Predictions
        public async Task<IActionResult> Index(string matchstring, int? page)
        {
            var model = new MatchViewModel();

          
         
           
            if (!string.IsNullOrEmpty(matchstring))
            {
                           
                ViewData["stringname"] = matchstring;
              
            } 
            else
            {
                ViewData["stringname"] = "All matches";
            }         

          
            return View(await model.getAllMatches(_context, matchstring, page));
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
