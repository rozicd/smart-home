using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Domain.Models;
using SmartHome.Domain.Services;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace SmartHome.WebApi.Controllers
{
    [ApiController]
    [Route("properties")]
    public class PropertyController : BaseController
    {
        private readonly IPropertyService _propertyService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public PropertyController(IPropertyService propertyService, ICityService cityService, ICountryService countryService, IMapper mapper)
            : base(mapper)
        {
            _propertyService = propertyService;
            _cityService = cityService;
            _countryService = countryService;
        }

        [HttpPost("")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> RegisterProperty([FromBody] RegisterPropertyRequestDTO propertyRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                City city = await _cityService.GetCityByName(propertyRequest.CityName);
                if (city == null)
                {
                    return BadRequest($"City '{propertyRequest.CityName}' not found");
                }

                Country country = await _countryService.GetCountryByName(propertyRequest.CountryName);
                if (country == null)
                {
                    return BadRequest($"Country '{propertyRequest.CountryName}' not found");
                }

                Property property = _mapper.Map<Property>(propertyRequest);

                property.UserId = _user.UserId;

                await _propertyService.AddProperty(property);

                return Ok(_mapper.Map<PropertyResponseDTO>(property));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(Guid id)
        {
            try
            {
                Property property = await _propertyService.GetPropertyById(id);

                if (property == null)
                {
                    return NotFound("Property not found");
                }

                return Ok(_mapper.Map<PropertyResponseDTO>(property));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("{id}/approve")]
        [Authorize(Roles = "ADMIN,SUPERADMIN")]
        public async Task<IActionResult> ApproveProperty(Guid id)
        {
            try
            {
                Property property = await _propertyService.GetPropertyById(id);

                if (property == null)
                {
                    return NotFound("Property not found");
                }

                property.Status = PropertyStatus.Approved;
                await _propertyService.UpdateProperty(property);

                // Send email to the user with approval confirmation
                // ...

                return Ok($"Property {id} approved successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("{id}/reject")]
        [Authorize(Roles = "ADMIN,SUPERADMIN")] 
        public async Task<IActionResult> RejectProperty(Guid id)
        {
            try
            {
                Property property = await _propertyService.GetPropertyById(id);

                if (property == null)
                {
                    return NotFound("Property not found");
                }

                property.Status = PropertyStatus.Rejected;
                await _propertyService.UpdateProperty(property);

                // Send email to the user with rejection information
                // ...

                return Ok($"Property {id} rejected successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
