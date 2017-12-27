using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerpetualShred.Models;

namespace PerpetualShred.Controllers
{
    public class HomeController : Controller
    {
        private readonly PerpetualShredContext _context;
        private readonly ICookieService _cookieService;

        public HomeController(PerpetualShredContext context, ICookieService cookieService)
        {
            _context = context;
            _cookieService = cookieService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            Randomizer randomizer = new Randomizer(_cookieService);

            List<WebVid> vidList = new List<WebVid>();
            vidList.AddRange(_context.WebVid);

            id = randomizer.RandomVidPicker(vidList);

            var webVid = await _context.WebVid
                .SingleOrDefaultAsync(m => m.ID == id);

            if (webVid == null)
            {
                return NotFound();
            }

            return View(webVid);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "A place to watch and share videos that get you pumped to be stoked.";

            return View();
        }

        public IActionResult Submit()
        {
            ViewData["Message"] = "The crawler can only do so much...";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
