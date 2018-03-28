using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PerpetualShred.Data;
using PerpetualShred.Models;

namespace PerpetualShred.ViewComponents
{
    public class FavsViewComponent : ViewComponent
    {
        private readonly PerpetualShredContext _vidDb;

        public FavsViewComponent(PerpetualShredContext vidContext)
        {
            _vidDb = vidContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string favString)
        {
            var items =  GetVidsAsync(favString);
            return View(items);
        }

        private List<WebVid> GetVidsAsync(string favString)
        {
            var favList = JsonConvert.DeserializeObject<List<string>>(favString);
            var webVidList = new List<WebVid>();
            foreach (var vidUrl in favList)
            {
                var tempVid = _vidDb.WebVid.First(r => r.PlayerUrl.Contains(vidUrl));
                webVidList.Add(tempVid);
            }
            return webVidList;
            
        }
    }
}