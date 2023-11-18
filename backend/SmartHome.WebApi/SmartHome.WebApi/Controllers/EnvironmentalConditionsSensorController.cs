using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Application.Services;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models;
using SmartHome.Domain.Services;

namespace SmartHome.WebApi.Controllers
{
    [ApiController]
    [Route("conditions-sensor")]
    public class EnvironmentalConditionsSensorController : BaseController
    {
        private readonly IEnvironmentalConditionsSensorService _ecsService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;


        public EnvironmentalConditionsSensorController(ISmartDeviceService smartDeviceService,IEnvironmentalConditionsSensorService ecs,IMapper mapper, IFileService fileService) : base(mapper)
        {
            _ecsService = ecs;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddECS([FromForm] CreateECSRequestDTO esc)
        {
          
            EnvironmentalConditionsSensor response = new EnvironmentalConditionsSensor();
            var imagePath = await _fileService.SaveImageAsync(esc.ImageFile, "static/properties");

            response.Name = esc.Name;
            response.EnergySpending = esc.EnergySpending;
            response.UserId = _user.UserId;
            response.ImageUrl = imagePath;
            await _ecsService.Add(response);
          
            return Ok();
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
            await _smartDeviceService.TurnOn(dp.Id);
            return Ok();

        }
        [HttpPost("off")]
        public async Task<IActionResult> PowerOff([FromForm] DevicePowerDTO dp)
        {
            await _smartDeviceService.TurnOff(dp.Id);
            return Ok();

        }
    }
}