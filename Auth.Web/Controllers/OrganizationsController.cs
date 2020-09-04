using Auth.Services.PrimitivesServices.OrganizationServices;
using Auth.Web.Builders.OrganizationRequisites;
using Auth.Web.Builders.Organizations;
using Auth.Web.Builders.Roles;
using Auth.Web.Forms.Organization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Auth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private IOrganizationService _organizationService;
        private IOrganizationBuilder _organizationBuilder;
        private IOrganizationRequisitesBuilder _organizationRequisitesBuilder;      

        public OrganizationsController(
            IOrganizationService organizationService,
            IOrganizationBuilder organizationBuilder, 
            IOrganizationRequisitesBuilder organizationRequisitesBuilder)
        {
            _organizationService = organizationService;
            _organizationBuilder = organizationBuilder;
            _organizationRequisitesBuilder = organizationRequisitesBuilder;
        }

        [HttpPost("create")]
        public IActionResult Create(RegisterOrganizationForm registerOrganizationForm)
        {
            if (ModelState.IsValid)
            {
                var organization = _organizationBuilder.BuildNew(registerOrganizationForm);

                var organizationRequisite = _organizationRequisitesBuilder.BuildNew(organization.Id, registerOrganizationForm.RequisitesForm);

                var added = _organizationService.Add(organization, organizationRequisite);

                var uri = Url.Link("OrganizationResource", new { id = added.Id });

                return Created(uri, added);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}", Name = "OrganizationResource")]
        public IActionResult Get(Guid id)
        {
            if (_organizationService.Contains(id))
            {
                var organization = _organizationService.Get(id);

                return Ok(organization);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("")]
        public IActionResult List()
        {
            var organizations = _organizationService.GetAll();

            return Ok(organizations);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(Guid id, EditOrganizationForm editOrganizationForm)
        {
            if (_organizationService.Contains(id))
            {
                if (ModelState.IsValid)
                {
                    var organization = _organizationBuilder.Edit(id, editOrganizationForm);

                    var updated = _organizationService.Update(organization);

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
        public IActionResult Remove(Guid id)
        {
            if (_organizationService.Contains(id))
            {
                _organizationService.Remove(id);

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
