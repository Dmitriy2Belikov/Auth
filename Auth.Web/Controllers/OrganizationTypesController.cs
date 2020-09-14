using Auth.Services.PrimitivesServices.OrganizationTypeServices;
using Auth.Web.Forms.OrganizationType;
using Auth.Web.Models.ModelBuilders.OrganizationTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Auth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationTypesController : ControllerBase
    {
        private IOrganizationTypeService _organizationTypeService;
        private IOrganizationTypeModelBuilder _organizationTypeModelBuilder;

        public OrganizationTypesController(
            IOrganizationTypeService organizationTypeService,
            IOrganizationTypeModelBuilder organizationModelBuilder)
        {
            _organizationTypeService = organizationTypeService;
            _organizationTypeModelBuilder = organizationModelBuilder;
        }

        [HttpPost("create")]
        [Authorize]
        public IActionResult Create(RegisterOrganizationTypeForm registerOrganizationTypeForm)
        {
            if (ModelState.IsValid)
            {

                var organizationType = _organizationTypeService.Add(registerOrganizationTypeForm.Title);

                var organizationTypeViewModel = _organizationTypeModelBuilder.BuildNew(organizationType);

                return Ok(organizationTypeViewModel);
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

                var organizationTypeViewModel = _organizationTypeModelBuilder.BuildNew(organizationType);

                return Ok(organizationTypeViewModel);
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

            var organizationTypeViewModels = organizationTypes.Select(o => _organizationTypeModelBuilder.BuildNew(o));

            return Ok(organizationTypeViewModels);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Edit(Guid id, EditOrganizationTypeForm editOrganizationTypeForm)
        {
            if (_organizationTypeService.Contains(id))
            {
                if (ModelState.IsValid)
                {
                    var organizationType = _organizationTypeService.Update(id, editOrganizationTypeForm.Title);

                    var organizationTypeViewModel = _organizationTypeModelBuilder.BuildNew(organizationType);

                    return Ok(organizationTypeViewModel);
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

            return NoContent();
        }
    }
}
