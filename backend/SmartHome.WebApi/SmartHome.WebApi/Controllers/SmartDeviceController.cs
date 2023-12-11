using AutoMapper;
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
        private readonly ISmartDeviceService _smartDeviceService; // Use the common interface

        public SmartDeviceController(
            ISmartDeviceServiceFactory smartDeviceServiceFactory,
            ISmartDeviceService smartDeviceService, // Inject the common service
            IMapper mapper)
            : base(mapper)
        {
            _smartDeviceServiceFactory = smartDeviceServiceFactory;
            _smartDeviceService = smartDeviceService;
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
            return Ok(devices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeById(Guid lampId)
        {
            var devices = await _smartDeviceService.GetTypeById(request.Page, request.PropertyId);
            return Ok(devices);
        }

        [HttpPost("connect")]
        public async Task<IActionResult> ConnectDevice([FromForm] ConnectDeviceDTO cd)
        {
            await _smartDeviceService.Connect(cd.Id, cd.Address);

            return Ok();
        }

        [HttpPost("on")]
        public async Task<IActionResult> PowerOn([FromForm] DevicePowerDTO dp)
        {
            ISmartDeviceActionsService actionsService = await _smartDeviceServiceFactory.GetServiceAsync(dp.Id);

            await actionsService.TurnOn(dp.Id);
            return Ok();
        }

        [HttpPost("off")]
        public async Task<IActionResult> PowerOff([FromForm] DevicePowerDTO dp)
        {
            ISmartDeviceActionsService actionsService = await _smartDeviceServiceFactory.GetServiceAsync(dp.Id);

            await actionsService.TurnOff(dp.Id);
            return Ok();
        }

    }
}