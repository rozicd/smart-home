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
        private readonly ISmartDeviceService _smartDeviceService;

        public SmartDeviceController(
            ISmartDeviceServiceFactory smartDeviceServiceFactory,
            ISmartDeviceService smartDeviceService,
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

    }
}