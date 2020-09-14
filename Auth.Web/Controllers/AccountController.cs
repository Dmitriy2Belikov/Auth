using Auth.DataLayer;
using Auth.Services.AccountServices;
using Auth.Services.AccountServices.TokenAuthenticateServices;
using Auth.Services.AccountServices.ValidateServices;
using Auth.Services.CookieServices.CookieServices;
using Auth.Services.PrimitivesServices.PersonServices;
using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Services.PrimitivesServices.UserServices;
using Auth.Web.Forms.Account;
using Auth.Web.Models.ModelBuilders.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace Auth.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IAccountService _accountService;
        private ITokenService _tokenService;
        private ICookieService _cookieService;
        private IPersonService _personService;
        private IValidateService _validateService;

        private IUserModelBuilder _userModelBuilder;

        public AccountController(
            IUserService userService,
            IRoleService roleService,
            IAccountService accountService,
            ITokenService tokenService,
            ICookieService cookieService,
            IUserModelBuilder userModelBuilder,
            IPersonService personService, 
            IValidateService validateService)
        {
            _userService = userService;
            _roleService = roleService;
            _accountService = accountService;
            _tokenService = tokenService;
            _cookieService = cookieService;
            _userModelBuilder = userModelBuilder;
            _personService = personService;
            _validateService = validateService;
        }

        [HttpGet("refresh_token")]
        [Authorize]
        public IActionResult GetNewTokens(Guid id, string ip, string userAgent)
        {
            var user = _userService.Get(id);

            var token = _cookieService.Extract(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE);

            var isVerified = _tokenService.VerifyRefreshToken(user, token);

            if (isVerified)
            {
                var identity = _accountService.GetIdentity(user);

                var tokens = _accountService.GetNewTokenPair(user, identity, token);

                _cookieService.RemoveCookie(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE);
                _cookieService.SetCookie(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE, tokens.RefreshToken);

                return Ok(tokens.AccessToken);
            }
            else
            {
                return Forbid();
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUserForm loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Get(loginViewModel.Login);

                if (_accountService.Verify(user, loginViewModel.Password))
                {
                    var identity = _accountService.GetIdentity(user);

                    if (identity != null)
                    {
                        var tokens = _accountService.Login(user, identity);

                        _cookieService.RemoveCookie(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE);
                        _cookieService.SetCookie(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE, tokens.RefreshToken);

                        return Ok(tokens.AccessToken);
                    }
                }

                return BadRequest("Неправильный логин или пароль");
            }
            else
            {
                return BadRequest("Заполните форму");
            }
        }

        [HttpGet("logout")]
        [Authorize]
        public IActionResult Logout(string token)
        {
            var refreshSession = _tokenService.GetRefreshSession(token);

            if (refreshSession != null)
            {
                _tokenService.RemoveRefreshSession(refreshSession.Id);
            }

            _cookieService.RemoveCookie(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE);

            return Ok();
        }

        [HttpPost("register")]
        [Authorize]
        public IActionResult Register(RegisterUserForm registerViewModel)
        {
            if(ModelState.IsValid)
            {
                if (!_validateService.IsExistLogin(registerViewModel.Login))
                {
                    var roles = registerViewModel.RoleIds.Select(r => _roleService.Get(r));

                    var registeredUser = _accountService.Register(
                        registerViewModel.Login,
                        registerViewModel.Password,
                        registerViewModel.FirstName,
                        registerViewModel.LastName,
                        registerViewModel.SurName,
                        registerViewModel.Gender,
                        registerViewModel.BirthDate,
                        registerViewModel.Snils,
                        registerViewModel.Email,
                        registerViewModel.Phone,
                        registerViewModel.RegistrationAddress,
                        registerViewModel.FactAddress,
                        registerViewModel.OtherPhones,
                        roles);

                    var url = Url.Link("UserResource", new { id = registeredUser.Id });

                    var userViewModel = _userModelBuilder.BuildNew(registeredUser);

                    return Created(url, userViewModel);
                }
                else
                {
                    return BadRequest("Логин занят");
                }
            }
            else
            {
                return BadRequest("Заполните форму");
            }
        }

        [HttpGet("{id}", Name = "UserResource")]
        [Authorize]
        public IActionResult GetProfile(Guid id)
        {
            var user = _userService.Get(id);

            var userViewModel = _userModelBuilder.BuildNew(user);

            return Ok(userViewModel);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult EditProfile(Guid id, EditUserForm editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var roles = editUserViewModel.RoleIds.Select(r => _roleService.Get(r));

                var user = _accountService.EditProfile(id,
                    editUserViewModel.Login,
                    editUserViewModel.Password,
                    roles, 
                    editUserViewModel.FirstName,
                    editUserViewModel.LastName,
                    editUserViewModel.SurName,
                    editUserViewModel.Gender,
                    editUserViewModel.BirthDate,
                    editUserViewModel.Snils,
                    editUserViewModel.Email,
                    editUserViewModel.Phone,
                    editUserViewModel.RegistrationAddress,
                    editUserViewModel.FactAddress,
                    editUserViewModel.OtherPhones);

                var userViewModel = _userModelBuilder.BuildNew(user);

                return Ok(userViewModel);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("verify/{id}")]
        public IActionResult VerifyUser(Guid id, string password)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Get(id);

                var isVerified = _accountService.Verify(user, password);

                if (isVerified)
                {
                    var userViewModel = _userModelBuilder.BuildNew(user);

                    return Ok(userViewModel);
                }
                else
                {
                    return Conflict("Неправильный пароль");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteProfile(Guid id)
        {
            _accountService.RemoveProfile(id);

            return NoContent();
        }
    }
}
