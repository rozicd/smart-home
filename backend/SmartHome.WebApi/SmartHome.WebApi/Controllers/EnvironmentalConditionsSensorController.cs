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
        private readonly IFileService _fileService;


        public EnvironmentalConditionsSensorController(IEnvironmentalConditionsSensorService ecs,IMapper mapper, IFileService fileService) : base(mapper)
        {
            _ecsService = ecs;
            _fileService = fileService;
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
            await _ecsService.Connect(cd.Id, cd.Address);
            return Ok();

        }
        [HttpPost("on")]
        public async Task<IActionResult> PowerOn([FromForm] DevicePowerDTO dp)
        {
            await _ecsService.PowerOn(dp.Id);
            return Ok();

        }
        [HttpPost("off")]
        public async Task<IActionResult> PowerOff([FromForm] DevicePowerDTO dp)
        {
            await _ecsService.PowerOff(dp.Id);
            return Ok();

        }
    }
}