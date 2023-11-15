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
using SmartHome.Domain.Exceptions;

namespace SmartHome.WebApi.Controllers
{
    [ApiController]
    [Route("properties")]
    public class PropertyController : BaseController
    {
        private readonly IPropertyService _propertyService;
        private readonly ICityService _cityService;

        public PropertyController(IPropertyService propertyService, ICityService cityService, IMapper mapper)
            : base(mapper)
        {
            _propertyService = propertyService;
            _cityService = cityService;
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
                City city = await _cityService.GetCityByNameAndCountry(propertyRequest.CityName,propertyRequest.CountryName);

                Property property = _mapper.Map<Property>(propertyRequest);

                property.UserId = _user.UserId;
                property.CityId = city.Id;

                await _propertyService.AddProperty(property);

                property.City = city;

                return Ok(_mapper.Map<PropertyResponseDTO>(property));
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
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
