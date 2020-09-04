using Microsoft.AspNetCore.Http;
using System;

namespace Auth.Services.CookieServices.CookieServices
{
    public interface ICookieService
    {
        void SetCookie(HttpContext context, string cookieName, string value);
        string Extract(HttpContext context, string cookieName);
        void RemoveCookie(HttpContext context, string cookieName);
    }
}
