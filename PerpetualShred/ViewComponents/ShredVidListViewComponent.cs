using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerpetualShred.Models;

namespace PerpetualShred.ViewComponents
{
    public class ShredVidListViewComponent : ViewComponent
    {
        private readonly PerpetualShredContext _db;

        public ShredVidListViewComponent(PerpetualShredContext context)
        {
            _db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int start, int count)
        {
            var items = await GetVidsAsync(start, count);
            return View(items);
        }

        private Task<List<WebVid>> GetVidsAsync(int start, int count)
        {
            return _db.WebVid.Skip(start).Take(count).ToListAsync();
        }
    }
}