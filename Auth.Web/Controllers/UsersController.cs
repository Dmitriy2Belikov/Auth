using Auth.Services.AccountServices;
using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Services.PrimitivesServices.UserServices;
using Auth.Web.Models.ModelBuilders.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Auth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IAccountService _accountService;

        private IUserModelBuilder _userModelBuilder;

        public UsersController(
            IUserService userService,
            IRoleService roleService,
            IAccountService accountService, 
            IUserModelBuilder userModelBuilder)
        {
            _userService = userService;
            _roleService = roleService;
            _accountService = accountService;
            _userModelBuilder = userModelBuilder;
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(Guid id)
        {
            var user = _userService.Get(id);

            var userViewModel = _userModelBuilder.BuildNew(user);

            return Ok(userViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult List()
        {
            var users = _userService.GetAll();

            var userViewModels = users.Select(u => _userModelBuilder.BuildNew(u));

            return Ok(users);
        }
    }
}
