using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Services.PrimitivesServices.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Auth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public HomeController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        //[HttpGet("index")]
        //public IActionResult Index(string token)
        //{
        //    var path = @"C:\Users\user\Desktop\Auth\Auth\Frontend\Index.html";

        //    var index = string.Empty;

        //    using (var sr = new StreamReader(path))
        //    {
        //        index = sr.ReadToEnd();
        //    }

        //    return Content(index, "text/html");
        //}
    }
}
