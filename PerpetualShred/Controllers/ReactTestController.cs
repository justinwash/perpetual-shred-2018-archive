using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerpetualShred.Models;

namespace PerpetualShred.Controllers
{
    public class ReactTestController : Controller
    {
        private static readonly IList<CommentModel> _comments;

        private readonly PerpetualShredContext _context;
        private readonly ICookieService _cookieService;

        public ReactTestController(PerpetualShredContext context, ICookieService cookieService)
        {
            _context = context;
            _cookieService = cookieService;
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }

        public async Task<IActionResult> ReactTest(int? id)
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
    }
}