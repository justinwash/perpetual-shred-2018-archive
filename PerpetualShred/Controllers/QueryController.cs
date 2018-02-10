using System;
using Microsoft.AspNetCore.Mvc;

namespace PerpetualShred.Controllers
{
    public class QueryController : Controller
    {
        public IActionResult Fetch(string subindex)
        {
            var urlstart = Convert.ToInt32(subindex.Split("!")[0]);
            var urlcount = Convert.ToInt32(subindex.Split("!")[1]);
            
            if (subindex == "" || subindex == null)
            {
                return ViewComponent("ShredVidList", new {start = 0, count = 10});
            }
            else return ViewComponent("ShredVidList", new {start = urlstart, count = urlcount});
        }

        public IActionResult ComingUp()
        {
            return ViewComponent("ComingUp");
        }
    }
}