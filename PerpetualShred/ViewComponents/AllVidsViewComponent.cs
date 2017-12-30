using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerpetualShred.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ViewComponentSample.ViewComponents
{
    public class AllVidListViewComponent : ViewComponent
    {
        private readonly PerpetualShredContext db;

        public AllVidListViewComponent(PerpetualShredContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int start, int count)
        {
            var items = await GetVidsAsync(start, count);
            return View(items);
        }

        private Task<List<WebVid>> GetVidsAsync(int start, int count)
        {
            return db.WebVid.Skip(start).Take(count).ToListAsync();
        }
    }
}