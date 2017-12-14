using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PerpetualShred
{
    public interface ICookieService
    {
        void RemoveVideoFromUnwatched(int? id);
        string GetCookie(string name);
        void CreateCookie(string name, string value, CookieOptions options = null);
    }

    public class CookieService : ICookieService
    {
        IHttpContextAccessor httpContextAccessor;
        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void RemoveVideoFromUnwatched(int? id)
        {
            string cookieDelimiter = ";";

            string unwatchedCookieName = "randomVideoUnwatched";
            string unwatchedCookieValue = id.ToString() + cookieDelimiter;

            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);

            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext.Request.Cookies[unwatchedCookieName] is null)
            {
                // This should never actually happen.
            }
            else
            {
                // If the cookie already exists, we need to update it to remove the video we're watching.
                string oldUnwtachedCookie = httpContext.Request.Cookies[unwatchedCookieName];
                List<string> unwatchedList = oldUnwtachedCookie.Split(cookieDelimiter).ToList();
                unwatchedList.Remove(id.ToString());
                unwatchedCookieValue = String.Join(';', unwatchedList);

                httpContext.Response.Cookies.Append(unwatchedCookieName, unwatchedCookieValue, cookieOptions);
            }
        }

        public string GetCookie(string name)
        {
            return httpContextAccessor.HttpContext.Request.Cookies[name];
        }

        public void CreateCookie(string name, string value, CookieOptions options = null)
        {
            if (options is null)
            {
                options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
            }
            httpContextAccessor.HttpContext.Response.Cookies.Append(name, value, options);
        }
    }
}
