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

        public ReactTestController(PerpetualShredContext context)
        {
            _context = context;
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }

        public async Task<IActionResult> ReactTest(int? id)
        {
            List<WebVid> vidList = new List<WebVid>();
            vidList.AddRange(_context.WebVid);

            id = Randomizer.RandomVidPicker(vidList);

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