using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

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
        private IHttpContextAccessor _httpContextAccessor;
        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void RemoveVideoFromUnwatched(int? id)
        {
            var cookieDelimiter = ";";

            var unwatchedCookieName = "randomVideoUnwatched";
            var unwatchedCookieValue = id + cookieDelimiter;

            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Request.Cookies[unwatchedCookieName] is null)
            {
                // This should never actually happen.
            }
            else
            {
                // If the cookie already exists, we need to update it to remove the video we're watching.
                var oldUnwtachedCookie = httpContext.Request.Cookies[unwatchedCookieName];
                var unwatchedList = oldUnwtachedCookie.Split(cookieDelimiter).ToList();
                unwatchedList.Remove(id.ToString());
                unwatchedCookieValue = String.Join(';', unwatchedList);

                httpContext.Response.Cookies.Append(unwatchedCookieName, unwatchedCookieValue, cookieOptions);
            }
        }

        public string GetCookie(string name)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[name];
        }

        public void CreateCookie(string name, string value, CookieOptions options = null)
        {
            if (options is null)
            {
                options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
            }
            _httpContextAccessor.HttpContext.Response.Cookies.Append(name, value, options);
        }
    }
}
