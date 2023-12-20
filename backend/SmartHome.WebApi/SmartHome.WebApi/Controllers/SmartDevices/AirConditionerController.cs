using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Application.Services.SmartDevices;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("airconditioner")]
    public class AirConditionerController : BaseController
    {
        private readonly IAirConditionerService _airConditionerService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;

        public AirConditionerController(ISmartDeviceService smartDeviceService, IAirConditionerService airConditionerService, IMapper mapper, IFileService fileService) : base(mapper)
        {
            _airConditionerService = airConditionerService;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddAirConditioner([FromForm] CreateAirConditionerDTO airConditioner)
        {
            AirConditioner response = _mapper.Map<AirConditioner>(airConditioner);
            var imagePath = await _fileService.SaveImageAsync(airConditioner.ImageFile, "static/properties");

     
            response.ImageUrl = imagePath;
            response.UserId = _user.UserId;
            await _airConditionerService.Add(response);

            return Ok();
        }

        [HttpGet("{airConditionId}")]
        public async Task<IActionResult> GetACById(Guid airConditionId)
        {
            AirConditioner ac = await _airConditionerService.GetById(airConditionId);
            AirConditionerResponseDTO response = _mapper.Map<AirConditionerResponseDTO>(ac);

            return Ok(response);

        }
        [HttpPost("turnOn")]
        public async Task<IActionResult> TurnOn([FromBody] TurnOnOffDTO turnOnDTO)
        {
            await _airConditionerService.TurnOn(turnOnDTO.LampId);
            return Ok();
        }

        [HttpPost("turnOff")]
        public async Task<IActionResult> TurnOff([FromBody] TurnOnOffDTO turnOffDTO)
        {
            await _airConditionerService.TurnOff(turnOffDTO.LampId);
            return Ok();
        }


        [HttpPost("changeMode")]
        public async Task<IActionResult> ChangeMode([FromBody] ChangeAcModeDTO changeModeDTO)
        {
            AirConditioner ac = await _airConditionerService.GetById(changeModeDTO.Id);
            ac.CurrentTemperature = changeModeDTO.currentTemperature;
            ac.Mode = changeModeDTO.mode;
            await _airConditionerService.ChangeMode(_user, ac);
            return Ok();
        }
    }

}
