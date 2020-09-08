using Auth.DataLayer.Models;
using Auth.Services.AccountServices.AccessServices;
using Auth.Services.AccountServices.TokenAuthenticateServices;
using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Web.Builders.Roles;
using Auth.Web.Forms.Role;
using Auth.Web.Models.Builders.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Auth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRoleService _roleService;
        private IRoleBuilder _roleBuilder;
        private IPermissionBuilder _permissionBuilder;
        private IAccessService _accessService;
        private ITokenService _tokenService;

        public RolesController(
            IRoleService roleService,
            IRoleBuilder roleBuilder,
            IPermissionBuilder permissionBuilder,
            IAccessService accessService,
            ITokenService tokenService)
        {
            _roleService = roleService;
            _roleBuilder = roleBuilder;
            _permissionBuilder = permissionBuilder;
            _accessService = accessService;
            _tokenService = tokenService;
        }

        [HttpPost("create")]
        [Authorize]
        public IActionResult Create(RegisterRoleForm registerRoleForm)
        {
            if (ModelState.IsValid)
            {
                var role = _roleBuilder.BuildNew(registerRoleForm);

                var permissions = registerRoleForm.Permissions.Select(r => _permissionBuilder.BuildNew(role, r));

                _roleService.Add(role, registerRoleForm.SystemModuleIds, permissions);

                var roleViewModel = _roleBuilder.BuildViewModel(role);

                return Ok(roleViewModel);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(Guid id)
        {
            var roleViewModel = _roleBuilder.BuildViewModel(id);

            return Ok(roleViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult List()
        {
            var roles = _roleService.GetAll();

            var roleViewModels = roles.Select(r => _roleBuilder.BuildViewModel(r));

            return Ok(roleViewModels);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Edit(Guid id, EditRoleForm editRoleForm)
        {
            if (ModelState.IsValid)
            {
                var role = _roleBuilder.Edit(id, editRoleForm);

                var permissions = editRoleForm.Permissions.Select(p => _permissionBuilder.BuildNew(role, p));

                _roleService.Update(role, editRoleForm.SystemModuleIds, permissions);

                var roleViewModel = _roleBuilder.BuildViewModel(role);

                return Ok(roleViewModel);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Remove(Guid id)
        {
            _roleService.Remove(id);

            return Ok();
        }
    }
}
