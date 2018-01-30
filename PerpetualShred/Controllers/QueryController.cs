using Microsoft.AspNetCore.Mvc;

namespace PerpetualShred.Controllers
{
    public class QueryController : Controller
    {
        public IActionResult Fetch(string startandcount)
        {
            var urlstart = -1;
            var urlcount = -1;

            if (urlstart == -1)
                  return ViewComponent("ShredVidList", new {start = 0, count = 10});
            else return ViewComponent("ShredVidList", new {start = urlstart, count = urlcount});
        }
    }
}