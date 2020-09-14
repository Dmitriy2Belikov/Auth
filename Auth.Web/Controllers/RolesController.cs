using Auth.DataLayer.Models.Permissions;
using Auth.Services.AccountServices.AccessServices;
using Auth.Services.AccountServices.TokenAuthenticateServices;
using Auth.Services.PrimitivesServices.RoleServices;
using Auth.Web.Forms.Role;
using Auth.Web.Models.ModelBuilders.Roles;
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
        private IAccessService _accessService;
        private ITokenService _tokenService;

        private IRoleModelBuilder _roleModelBuilder;
        private IPermissionFactory _permissionFactory;

        public RolesController(
            IRoleService roleService,
            IAccessService accessService,
            ITokenService tokenService, 
            IRoleModelBuilder roleModelBuilder, 
            IPermissionFactory permissionFactory)
        {
            _roleService = roleService;
            _accessService = accessService;
            _tokenService = tokenService;
            _roleModelBuilder = roleModelBuilder;
            _permissionFactory = permissionFactory;
        }

        [HttpPost("create")]
        //[Authorize]
        public IActionResult Create(RegisterRoleForm registerRoleForm)
        {
            if (ModelState.IsValid)
            {
                var role = _roleService.Add(registerRoleForm.Name, registerRoleForm.SystemModuleIds);

                var permissions = registerRoleForm.Permissions.Select(p => _roleService.AddPermission(role.Id, p.WorkingEntityOperationId, p.RuleId));

                var roleViewModel = _roleModelBuilder.BuildNew(role);

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
            var role = _roleService.Get(id);

            var roleViewModel = _roleModelBuilder.BuildNew(role);

            return Ok(roleViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult List()
        {
            var roles = _roleService.GetAll();

            var roleViewModels = roles.Select(r => _roleModelBuilder.BuildNew(r));

            return Ok(roleViewModels);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Edit(Guid id, EditRoleForm editRoleForm)
        {
            if (ModelState.IsValid)
            {
                var role = _roleService.Update(id, editRoleForm.Name, editRoleForm.SystemModuleIds);

                var permissions = editRoleForm.Permissions.Select(p => _roleService.AddPermission(role.Id, p.WorkingEntityOperationId, p.RuleId));

                var roleViewModel = _roleModelBuilder.BuildNew(role);

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

            return NoContent();
        }
    }
}
