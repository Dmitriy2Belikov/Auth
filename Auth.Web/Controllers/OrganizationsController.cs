using Auth.Services.PrimitivesServices.OrganizationServices;
using Auth.Web.Forms.Organization;
using Auth.Web.Models.ModelBuilders.Organizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Auth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private IOrganizationService _organizationService;

        private IOrganizationModelBuilder _organizationModelBuilder;

        public OrganizationsController(
            IOrganizationService organizationService, 
            IOrganizationModelBuilder organizationModelBuilder)
        {
            _organizationService = organizationService;
            _organizationModelBuilder = organizationModelBuilder;
        }

        [HttpPost("create")]
        [Authorize]
        public IActionResult Create(RegisterOrganizationForm registerOrganizationForm)
        {
            if (ModelState.IsValid)
            {
                var organization = _organizationService.Add(
                    registerOrganizationForm.Title,
                    registerOrganizationForm.TitleShort,
                    registerOrganizationForm.ParentOrganizationId,
                    registerOrganizationForm.OrganizationTypeId,
                    registerOrganizationForm.LegalAddress,
                    registerOrganizationForm.PostAddress,
                    registerOrganizationForm.Phone,
                    registerOrganizationForm.Fax,
                    registerOrganizationForm.Email,
                    registerOrganizationForm.Inn,
                    registerOrganizationForm.Kpp,
                    registerOrganizationForm.Ogrn,
                    registerOrganizationForm.Okved,
                    registerOrganizationForm.Okpo,
                    registerOrganizationForm.Okato,
                    registerOrganizationForm.AccountNumber,
                    registerOrganizationForm.BankTitle,
                    registerOrganizationForm.Bik,
                    registerOrganizationForm.BankCorrespAccount
                    );

                var uri = Url.Link("OrganizationResource", new { id = organization.Id });

                var organizationViewModel = _organizationModelBuilder.BuildNew(organization);

                return Created(uri, organizationViewModel);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}", Name = "OrganizationResource")]
        [Authorize]
        public IActionResult Get(Guid id)
        {
            if (_organizationService.Contains(id))
            {
                var organization = _organizationService.Get(id);

                var organizationViewModel = _organizationModelBuilder.BuildNew(organization);

                return Ok(organizationViewModel);
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
            var organizations = _organizationService.GetAll();

            var organizationViewModels = organizations.Select(o => _organizationModelBuilder.BuildNew(o));

            return Ok(organizationViewModels);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Edit(Guid id, EditOrganizationForm editOrganizationForm)
        {
            if (_organizationService.Contains(id))
            {
                if (ModelState.IsValid)
                {
                    var organization = _organizationService.Update(
                        id,
                        editOrganizationForm.Title,
                        editOrganizationForm.TitleShort,
                        editOrganizationForm.ParentOrganizationId,
                        editOrganizationForm.OrganizationTypeId,
                        editOrganizationForm.LegalAddress,
                        editOrganizationForm.PostAddress,
                        editOrganizationForm.Phone,
                        editOrganizationForm.Fax,
                        editOrganizationForm.Email,
                        editOrganizationForm.Inn,
                        editOrganizationForm.Kpp,
                        editOrganizationForm.Ogrn,
                        editOrganizationForm.Okved,
                        editOrganizationForm.Okpo,
                        editOrganizationForm.Okato,
                        editOrganizationForm.AccountNumber,
                        editOrganizationForm.BankTitle,
                        editOrganizationForm.Bik,
                        editOrganizationForm.BankCorrespAccount);

                    var organizationViewModel = _organizationModelBuilder.BuildNew(organization);

                    return Ok(organizationViewModel);
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
            if (_organizationService.Contains(id))
            {
                _organizationService.Remove(id);

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
