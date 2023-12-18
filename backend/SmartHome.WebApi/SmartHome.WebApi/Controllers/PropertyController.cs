using AutoMapper;
using InfluxDB.Client.Core.Flux.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Application.Services;
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
    private readonly IMqttClientService _mqttClientService;

    public PropertyController(IMqttClientService mqttClientService,IPropertyService propertyService, IFileService fileService, IEmailService emailService, IUserService userService, IMapper mapper)
        : base(mapper)
    {
        _mqttClientService = mqttClientService;
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
    [Authorize(Roles = "ADMIN,SUPERADMIN")]
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
        await _mqttClientService.PublishMessageAsync("property/create", property.Id.ToString());
        User userOfProperty = await _userService.GetById(property.UserId);

        await _emailService.SendApprovePropertyEmail(userOfProperty, property);

        return Ok($"Property {id} approved successfully");
    }

    [HttpPut("{id}/reject")]
    [Authorize(Roles = "ADMIN,SUPERADMIN")]
    public async Task<IActionResult> RejectProperty(Guid id, [FromBody] RejectRequestDTO rejectRequestDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Property property = await _propertyService.GetPropertyById(id);

        if (property == null)
        {
            return NotFound("Property not found");
        }

        property.Status = PropertyStatus.Rejected;
        await _propertyService.UpdateProperty(property);

        User userOfProperty = await _userService.GetById(property.UserId);

        await _emailService.SendRejectPropertyEmail(userOfProperty, property, rejectRequestDTO.Description);

        return Ok($"Property {id} rejected successfully");
    }

    [HttpPost("power")]
    public async Task<IActionResult> GetPowerInLastHour([FromBody] DeviceHistoryRequestDTO bh)
    {
        List<FluxTable> fluxTables = await _propertyService.GetPropertyPowerInfluxData(bh.Id.ToString(), bh.Hours);

        var influxData = new List<HomePowerResponseDTO>();

        foreach (var fluxTable in fluxTables)
        {
            foreach (var fluxRecord in fluxTable.Records)
            {

                var data = new HomePowerResponseDTO
                {
                    DeviceId = fluxRecord.Values["device"].ToString(),
                    Target = fluxRecord.Values["target"].ToString(),
                    Energy = fluxRecord.Values["power"].ToString(),
                    Timestamp = fluxRecord.GetTimeInDateTime()
                };

                influxData.Add(data);
            }
        }

        return Ok(influxData);
    }
    [HttpPost("power/date")]
    public async Task<IActionResult> GetPowerDateRange([FromBody] DeviceHistoryDateRequestDTO bh)
    {
        TimeSpan dateRange = bh.EndDate - bh.StartDate;
        if (dateRange.TotalDays > 30)
        {
            return BadRequest("Date range cannot be longer than one month");
        }
        if (bh.StartDate > bh.EndDate)
        {
            return BadRequest("Start date cannot be after end date");
        }
        List<FluxTable> fluxTables = await _propertyService.GetPropertyPowerInfluxDataDate(bh.Id.ToString(), bh.StartDate, bh.EndDate);

        var influxData = new List<HomePowerResponseDTO>();

        foreach (var fluxTable in fluxTables)
        {
            foreach (var fluxRecord in fluxTable.Records)
            {

                var data = new HomePowerResponseDTO
                {
                    DeviceId = fluxRecord.Values["device"].ToString(),
                    Target = fluxRecord.Values["target"].ToString(),
                    Energy = fluxRecord.Values["power"].ToString(),
                    Timestamp = fluxRecord.GetTimeInDateTime()
                };

                influxData.Add(data);
            }
        }

        return Ok(influxData);
    }

}
