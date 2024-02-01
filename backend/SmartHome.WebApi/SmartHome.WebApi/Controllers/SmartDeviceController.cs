using AutoMapper;
using InfluxDB.Client.Core.Flux.Domain;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Application.Services;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services;

namespace SmartHome.WebApi.Controllers
{
    [ApiController]
    [Route("smart-device")]
    public class SmartDeviceController : BaseController
    {
        private readonly ISmartDeviceServiceFactory _smartDeviceServiceFactory;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IPropertyService _propertyService;

        public SmartDeviceController(
            ISmartDeviceServiceFactory smartDeviceServiceFactory,
            ISmartDeviceService smartDeviceService,
            IPropertyService propertyService,
            IMapper mapper)
            : base(mapper)
        {
            _smartDeviceServiceFactory = smartDeviceServiceFactory;
            _smartDeviceService = smartDeviceService;
            _propertyService = propertyService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromQuery] Pagination page)
        {
            var devices = await _smartDeviceService.GetAll(page);
            return Ok(devices);
        }

        [HttpGet("property")]
        public async Task<IActionResult> GetAll([FromQuery] PropertySmartDeviceRequestDTO request)
        {
            var devices = await _smartDeviceService.GetAllFromProperty(request.Page, request.PropertyId);
            var property = await _propertyService.GetPropertyById(request.PropertyId);
            if(property.UserId != _user.UserId)
            {
                devices.Items = devices.Items.Where(device => device.SharedUsers.Any(user => user.Id == _user.UserId)).ToList();
                devices.TotalItems = devices.Items.Count();
            }
            return Ok(devices);
        }


        [HttpPost("on")]
        public async Task<IActionResult> PowerOn([FromForm] DevicePowerDTO dp)
        {
            ISmartDeviceActionsService actionsService = await _smartDeviceServiceFactory.GetServiceAsync(dp.Id);

            await actionsService.Connect(dp.Id);
            return Ok();
        }

        [HttpPost("off")]
        public async Task<IActionResult> PowerOff([FromForm] DevicePowerDTO dp)
        {
            ISmartDeviceActionsService actionsService = await _smartDeviceServiceFactory.GetServiceAsync(dp.Id);

            await actionsService.Disconnect(dp.Id);
            return Ok();
        }

        [HttpPost("data")]
        public async Task<IActionResult> GetAvailabilityInLastHour([FromBody] DeviceHistoryRequestDTO bh)
        {
            List<FluxTable> fluxTables = await _smartDeviceService.GetInfluxDataAsync(bh.Id.ToString(), bh.Hours);

            var influxData = new List<DeviceDataResponseDTO>();

            foreach (var fluxTable in fluxTables)
            {
                foreach (var fluxRecord in fluxTable.Records)
                {

                    var data = new DeviceDataResponseDTO
                    {
                        Units = fluxRecord.Values["units"].ToString(),
                        Percentage = fluxRecord.Values["percentage"].ToString(),
                        Duration = fluxRecord.Values["duration"].ToString(),
                        Timestamp = fluxRecord.Values["time"].ToString(),
                    };

                    influxData.Add(data);
                }
            }

            return Ok(influxData);
        }

        [HttpPost("data/date")]
        public async Task<IActionResult> GetAvailabilityDateRange([FromBody] DeviceHistoryDateRequestDTO bh)
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
            if (bh.StartDate > DateTime.Now || bh.EndDate > DateTime.Now)
            {
                return BadRequest("Cannot check availability in the future");
            }
            bh.EndDate = bh.EndDate.Date.AddDays(1).AddTicks(-1);
            List<FluxTable> fluxTables = await _smartDeviceService.GetInfluxDataDateRangeAsync(bh.Id.ToString(), bh.StartDate, bh.EndDate);

            var influxData = new List<DeviceDataResponseDTO>();

            foreach (var fluxTable in fluxTables)
            {
                foreach (var fluxRecord in fluxTable.Records)
                {

                    var data = new DeviceDataResponseDTO
                    {
                        Units = fluxRecord.Values["units"].ToString(),
                        Percentage = fluxRecord.Values["percentage"].ToString(),
                        Duration = fluxRecord.Values["duration"].ToString(),
                        Timestamp = fluxRecord.Values["time"].ToString(),
                    };

                    influxData.Add(data);
                }
            }

            return Ok(influxData);
        }
        [HttpPut("addPermission/{id}")]
        public async Task<IActionResult> AddUserPermission(Guid id, [FromBody]AddUserPermissionRequestDTO dto)
        {
            User user = await _smartDeviceService.addUserPermission(id, dto.Email);
            return Ok(user);
        }
        [HttpPut("removePermission/{id}")]
        public async Task<IActionResult> RemoveUserPermission(Guid id, [FromBody] AddUserPermissionRequestDTO dto)
        {
            User user = await _smartDeviceService.RemoveUserPermission(id, dto.Email);
            return Ok(user);
        }

        [HttpGet("getPermissions/{id}")]
        public async Task<IActionResult> getPermisions(Guid id)
        {
            PermissionsResponseDTO permissionsResponseDTO = new PermissionsResponseDTO();
            var smartDevice = await _smartDeviceService.GetDeviceById(id);
            if(smartDevice.UserId == _user.UserId)
            {
                List<UserResponseDTO> users = new List<UserResponseDTO>();
                foreach(User user in smartDevice.SharedUsers)
                {
                    UserResponseDTO dto = _mapper.Map<UserResponseDTO>(user);
                    users.Add(dto);
                }
                permissionsResponseDTO = new PermissionsResponseDTO
                {
                    Owner = true,
                    SharedUsers = users
                };
            }
            return Ok(permissionsResponseDTO);
        }

    }
}