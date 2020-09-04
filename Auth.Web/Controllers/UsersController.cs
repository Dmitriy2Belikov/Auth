using Auth.Services.AccountServices;
using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Services.PrimitivesServices.UserServices;
using Auth.Web.Forms.Account;
using Auth.Web.Models.Builders.Persons;
using Auth.Web.Models.Builders.Users;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Auth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IAccountService _accountService;
        private IPersonBuilder _personBuilder;
        private IUserBuilder _userBuilder;

        public UsersController(
            IUserService userService,
            IRoleService roleService,
            IAccountService accountService,
            IPersonBuilder personBuilder, 
            IUserBuilder userBuilder)
        {
            _userService = userService;
            _roleService = roleService;
            _accountService = accountService;
            _personBuilder = personBuilder;
            _userBuilder = userBuilder;
        }

        [HttpPost("create")]
        public IActionResult Create(RegisterUserForm registerUserForm)
        {
            if (ModelState.IsValid)
            {
                var person = _personBuilder.BuildNew(registerUserForm);

                var user = _userBuilder.BuildNew(person.Id, registerUserForm);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _userService.Get(id);

            return Ok(user);
        }

        [HttpGet]
        public IActionResult List()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }
    }
}
