using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Application.Services;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.Domain.Services.SmartDevices;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("conditions-sensor")]
    public class EnvironmentalConditionsSensorController : BaseController
    {
        private readonly IEnvironmentalConditionsSensorService _ecsService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;


        public EnvironmentalConditionsSensorController(ISmartDeviceService smartDeviceService, IEnvironmentalConditionsSensorService ecs, IMapper mapper, IFileService fileService) : base(mapper)
        {
            _ecsService = ecs;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddECS([FromForm] CreateSmartDeviceRequestDTO esc)
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

    }
}