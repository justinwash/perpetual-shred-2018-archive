using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerpetualShred.Models;
using System;

namespace PerpetualShred.ViewComponents
{
    public class ComingUpViewComponent : ViewComponent
    {
        private readonly PerpetualShredContext _db;

        public ComingUpViewComponent(PerpetualShredContext context)
        {
            _db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int start)
        {
            var items = await GetNextTwo(start);
            return View(items);
        }

        private Task<List<WebVid>> GetNextTwo(int start)
        {
            var vidList = _db.WebVid.ToList();
            return _db.WebVid.Skip(new Random().Next(0, vidList.Count)).Take(2).ToListAsync();

        }
    }
}
