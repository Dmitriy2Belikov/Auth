using Auth.DataLayer;
using Auth.DataLayer.Models;
using Auth.Services;
using Auth.Services.AccountServices;
using Auth.Services.AccountServices.BrowserDataModel;
using Auth.Services.AccountServices.TokenAuthenticateServices;
using Auth.Services.CookieServices.CookieServices;
using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Services.PrimitivesServices.UserServices;
using Auth.Web.Forms.Account;
using Auth.Web.Models.Builders.Persons;
using Auth.Web.Models.Builders.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
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
        private IUserBuilder _userBuilder;
        private IPersonBuilder _personBuilder;

        public AccountController(
            IUserService userService,
            IRoleService roleService,
            IAccountService accountService,
            ITokenService tokenService,
            ICookieService cookieService,
            IUserBuilder userBuilder,
            IPersonBuilder personBuilder)
        {
            _userService = userService;
            _roleService = roleService;
            _accountService = accountService;
            _tokenService = tokenService;
            _cookieService = cookieService;
            _userBuilder = userBuilder;
            _personBuilder = personBuilder;
        }

        [HttpGet("refresh_token")]
        public IActionResult GetNewTokens(Guid id, string ip, string userAgent)
        {
            var user = _userService.Get(id);

            var token = _cookieService.Extract(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE);

            var isVerified = _tokenService.VerifyRefreshToken(user, token);

            if (isVerified)
            {
                var identity = _accountService.GetIdentity(user);

                var accessToken = _tokenService.BuildNewAccessToken(identity);               
                var refreshToken = _tokenService.BuildNewRefreshToken();

                _cookieService.RemoveCookie(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE);
                _cookieService.SetCookie(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE, refreshToken);

                var oldRefreshSession = _tokenService.GetRefreshSession(token);
                _tokenService.RemoveOldRefreshSession(oldRefreshSession.Id);

                var newRefreshSession = _tokenService.BuildNewRefreshSession(user.Id, ip, userAgent, refreshToken);
                _tokenService.AddRefreshSession(newRefreshSession);

                var json = new
                {
                    token = accessToken
                };

                return Ok(json);
            }
            else
            {
                return Conflict();
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
                        var browserData = new BrowserData()
                        {
                            IP = "f",
                            UserAgent = loginViewModel.UserAgent
                        };

                        var tokens = _accountService.Login(loginViewModel.Login, loginViewModel.Password, browserData);

                        _cookieService.RemoveCookie(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE);
                        _cookieService.SetCookie(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE, tokens.RefreshToken);

                        var identityRoles = identity.Claims
                            .Where(c => c.Type == ClaimTypes.Role)
                            .Select(c => c.Value);

                        var response = new
                        {
                            access_token = tokens.AccessToken,
                            username = identity.Name,
                            roles = identityRoles
                        };

                        return Ok(response);
                    }
                }

                return BadRequest("Неправильный логин или пароль");
            }
            else
            {
                return BadRequest("Заполните форму правильно");
            }
        }

        [HttpGet("logout")]
        [Authorize]
        public IActionResult Logout(string token)
        {
            var refreshSession = _tokenService.GetRefreshSession(token);

            if (refreshSession != null)
            {
                _tokenService.RemoveOldRefreshSession(refreshSession.Id);
            }

            _cookieService.RemoveCookie(HttpContext, AuthOptions.REFRESH_TOKEN_COOKIE);

            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserForm registerViewModel)
        {
            if(ModelState.IsValid)
            {
                var person = _personBuilder.BuildNew(registerViewModel);

                var newUser = _userBuilder.BuildNew(person.Id, registerViewModel);

                var roles = registerViewModel.RoleIds.Select(r => _roleService.Get(r));

                var user = _accountService.Register(newUser, person, roles);

                var url = Url.Link("UserResource", user);

                return Created(url, user);
            }
            else
            {
                return BadRequest("Заполните форму правильно");
            }
        }

        [HttpGet("{id}", Name = "UserResource")]
        [Authorize]
        public IActionResult GetProfile(Guid id)
        {
            var user = _userService.Get(id);

            return Ok(user);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult EditProfile(Guid id, EditUserForm editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Get(id);

                var roles = editUserViewModel.RoleIds.Select(r => _roleService.Get(r));

                user.Login = editUserViewModel.Email;
                user.Password = editUserViewModel.Password;

                _userService.Update(user, roles);

                return Ok(user);
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
                    return Ok(user);
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
            _userService.Remove(id);

            return Ok();
        }
    }
}
