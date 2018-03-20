using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerpetualShred.Models;

namespace PerpetualShred.Controllers
{
    public class HomeController : Controller
    {
        private readonly PerpetualShredContext _context;

        public HomeController(PerpetualShredContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            
            if (id == null)
            {
                var randomizer = new Randomizer();

                var vidList = new List<WebVid>();
                vidList.AddRange(_context.WebVid);

                id = randomizer.RandomVidPicker(vidList);

                var webVid = await _context.WebVid
                    .SingleOrDefaultAsync(m => m.Id == id);

                if (webVid == null)
                {
                    return NotFound();
                }

                return View(webVid);
            }
            else
            {

                var vidId = id.Value;
                var webVid = await _context.WebVid
                    .SingleOrDefaultAsync(m => m.Id == vidId);

                if (webVid == null)
                {
                    return NotFound();
                }

                return View(webVid);
            }

            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ALlVidList(int start, int count)
        {
            return ViewComponent("AllVidList", new { start, count });
        }
    }
}
