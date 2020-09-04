using Auth.DataLayer;
using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;

namespace Auth.Services.CookieServices.CookieServices
{
    class CookieService : ICookieService
    {
        public void SetCookie(HttpContext context, string cookieName, string value)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = new DateTimeOffset
                (
                     new DateTime
                     (
                         DateTime.Now.Year, 
                         DateTime.Now.Month + 2, 
                         DateTime.Now.Day, 
                         DateTime.Now.Hour, 
                         DateTime.Now.Minute, 
                         DateTime.Now.Second
                    )
                )
            };

            context.Response.Cookies.Append(cookieName, value, cookieOptions);
        }

        public string Extract(HttpContext context, string cookieName)
        {
            var cookie = context.Request.Cookies[cookieName];

            return cookie;
        }

        public void RemoveCookie(HttpContext context, string cookieName)
        {
            context.Response.Cookies.Delete(cookieName);
        }
    }
}
