using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models;
using SmartHome.Domain.Services;
using SmartHome.WebApi.Controllers;

[ApiController]
[Route("properties")]
public class PropertyController : BaseController
{
    private readonly IPropertyService _propertyService;
    private readonly IFileService _fileService;
    private readonly IEmailService _emailService;
    private readonly IUserService _userService;

    public PropertyController(IPropertyService propertyService, IFileService fileService, IEmailService emailService, IUserService userService, IMapper mapper)
        : base(mapper)
    {
        _propertyService = propertyService;
        _fileService = fileService;
        _emailService = emailService;
        _userService = userService;
    }

    [HttpPost("")]
    [Authorize(Roles = "USER")]
    public async Task<IActionResult> RegisterProperty([FromForm] RegisterPropertyRequestDTO propertyRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var imagePath = await _fileService.SaveImageAsync(propertyRequest.ImageFile, "static/properties");

        Property property = _mapper.Map<Property>(propertyRequest);
        property.UserId = _user.UserId;
        property.ImageUrl = imagePath;

        await _propertyService.AddProperty(property);

        return Created("/", "Property successfully created");
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "USER")]
    public async Task<IActionResult> GetPropertyById(Guid id)
    {
        Property property = await _propertyService.GetPropertyById(id);

        if (property == null)
        {
            return NotFound("Property not found");
        }

        return Ok(_mapper.Map<PropertyResponseDTO>(property));
    }

    [HttpGet("user/{userId}")]
    [Authorize(Roles = "USER")]
    public async Task<IActionResult> GetPropertiesByUserId(Guid userId, [FromQuery] Pagination page)
    {
        var properties = await _propertyService.GetPropertiesByUserId(userId,page);

        PaginationReturnObject<PropertyResponseDTO> response = new PaginationReturnObject<PropertyResponseDTO>(_mapper.Map<IEnumerable<PropertyResponseDTO>>(properties.Items), properties.PageNumber, properties.PageSize, properties.TotalItems);


        return Ok(response);
    }

    [HttpGet("pending")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> GetPendingProperties([FromQuery] Pagination page)
    {
        var properties = await _propertyService.GetPropertiesByStatus(PropertyStatus.Pending, page);


        PaginationReturnObject<PropertyResponseDTO> response = new PaginationReturnObject<PropertyResponseDTO>(_mapper.Map<IEnumerable<PropertyResponseDTO>>(properties.Items), properties.PageNumber, properties.PageSize, properties.TotalItems);


        return Ok(response);
    }

    [HttpPut("{id}/approve")]
    [Authorize(Roles = "ADMIN,SUPERADMIN")]
    public async Task<IActionResult> ApproveProperty(Guid id)
    {
        Property property = await _propertyService.GetPropertyById(id);

        if (property == null)
        {
            return NotFound("Property not found");
        }

        property.Status = PropertyStatus.Approved;
        await _propertyService.UpdateProperty(property);

        User userOfProperty = await _userService.GetById(property.UserId);

        await _emailService.SendApprovePropertyEmail(userOfProperty, property);

        return Ok($"Property {id} approved successfully");
    }

    [HttpPut("{id}/reject")]
    [Authorize(Roles = "ADMIN,SUPERADMIN")]
    public async Task<IActionResult> RejectProperty(Guid id)
    {
        Property property = await _propertyService.GetPropertyById(id);

        if (property == null)
        {
            return NotFound("Property not found");
        }

        property.Status = PropertyStatus.Rejected;
        await _propertyService.UpdateProperty(property);

        User userOfProperty = await _userService.GetById(property.UserId);

        await _emailService.SendRejectPropertyEmail(userOfProperty, property);

        return Ok($"Property {id} rejected successfully");
    }
}
