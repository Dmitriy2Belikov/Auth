using Auth.Services.PrimitivesServices.OrganizationTypeServices;
using Auth.Web.Builders.OrganizationTypes;
using Auth.Web.Forms.OrganizationType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Auth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationTypesController : ControllerBase
    {
        private IOrganizationTypeService _organizationTypeService;
        private IOrganizationTypeBuilder _organizationTypeBuilder;

        public OrganizationTypesController(
            IOrganizationTypeService organizationTypeService,
            IOrganizationTypeBuilder organizationTypeBuilder)
        {
            _organizationTypeService = organizationTypeService;
            _organizationTypeBuilder = organizationTypeBuilder;
        }

        [HttpPost("create")]
        [Authorize]
        public IActionResult Create(RegisterOrganizationTypeForm registerOrganizationTypeForm)
        {
            if (ModelState.IsValid)
            {
                var organizationType = _organizationTypeBuilder.BuildNew(registerOrganizationTypeForm);

                var added = _organizationTypeService.Add(organizationType);

                return Ok(added);
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
            if (_organizationTypeService.Contains(id))
            {
                var organizationType = _organizationTypeService.Get(id);

                return Ok(organizationType);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult List()
        {
            var organizationTypes = _organizationTypeService.GetAll();

            return Ok(organizationTypes);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Edit(Guid id, EditOrganizationTypeForm editOrganizationTypeForm)
        {
            if (_organizationTypeService.Contains(id))
            {
                if (ModelState.IsValid)
                {
                    var organizationType = _organizationTypeBuilder.Edit(id, editOrganizationTypeForm);

                    var updated = _organizationTypeService.Update(organizationType);

                    return Ok(updated);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Remove(Guid id)
        {
            _organizationTypeService.Remove(id);

            return Ok();
        }
    }
}
