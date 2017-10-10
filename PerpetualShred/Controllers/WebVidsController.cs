using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerpetualShred.Models;

namespace PerpetualShred.Controllers
{
    public class WebVidsController : Controller
    {
        private readonly PerpetualShredContext _context;

        public WebVidsController(PerpetualShredContext context)
        {
            _context = context;
        }

        // GET: WebVids
        public async Task<IActionResult> Index()
        {
            return View(await _context.WebVid.ToListAsync());
        }

        // GET: WebVids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webVid = await _context.WebVid
                .SingleOrDefaultAsync(m => m.ID == id);
            if (webVid == null)
            {
                return NotFound();
            }

            return View(webVid);
        }

        // Play random video?
        public async Task<IActionResult> PlayRandom(int? id)
        {
            WebVid vidToPlay;

            if (id == null)
            {
                var vidList = new List<WebVid>();
                vidList.AddRange(_context.WebVid);
                vidToPlay = vidList[(new Random().Next(0, vidList.Count))];
                id = vidToPlay.ID;
            }

            var webVid = await _context.WebVid
                .SingleOrDefaultAsync(m => m.ID == id);

            if (webVid == null)
            {
                return NotFound();
            }

            return View(webVid);
        }

        // GET: WebVids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WebVids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,PlayerUrl,OriginUrl,Synopsis")] WebVid webVid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(webVid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(webVid);
        }

        // GET: WebVids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webVid = await _context.WebVid.SingleOrDefaultAsync(m => m.ID == id);
            if (webVid == null)
            {
                return NotFound();
            }
            return View(webVid);
        }

        // POST: WebVids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,PlayerUrl,OriginUrl,Synopsis")] WebVid webVid)
        {
            if (id != webVid.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(webVid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebVidExists(webVid.ID))
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
            return View(webVid);
        }

        // GET: WebVids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webVid = await _context.WebVid
                .SingleOrDefaultAsync(m => m.ID == id);
            if (webVid == null)
            {
                return NotFound();
            }

            return View(webVid);
        }

        // POST: WebVids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var webVid = await _context.WebVid.SingleOrDefaultAsync(m => m.ID == id);
            _context.WebVid.Remove(webVid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebVidExists(int id)
        {
            return _context.WebVid.Any(e => e.ID == id);
        }

        
    }
}
