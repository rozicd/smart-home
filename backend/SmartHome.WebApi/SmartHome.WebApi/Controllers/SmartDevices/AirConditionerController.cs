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
        public async Task<IActionResult> TurnOn([FromBody] TurnOnOffAcDTO turnOnDTO)
        {
            await _airConditionerService.TurnOn(turnOnDTO.acId);
            return Ok();
        }

        [HttpPost("turnOff")]
        public async Task<IActionResult> TurnOff([FromBody] TurnOnOffAcDTO turnOffDTO)
        {
            await _airConditionerService.TurnOff(turnOffDTO.acId);
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

        [HttpPut("addScheduled/{id}")]
        public async Task<IActionResult> AddScheduledMode(Guid id, [FromBody] CreateACScheduledModeRequestDTO acScheduledModeRequestDTO)
        {
            ACScheduledMode acScheduledMode = _mapper.Map<ACScheduledMode>(acScheduledModeRequestDTO);
            AirConditioner ac = await _airConditionerService.AddScheduledMode(id, acScheduledMode, _user);

            return Ok(_mapper.Map<AirConditionerResponseDTO>(ac));
        }

        [HttpGet("{id}/history")]
        public async Task<IActionResult> GetACActions(Guid id, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (!startDate.HasValue)
            {
                startDate = DateTime.UtcNow.AddHours(-6);
            }

            if (!endDate.HasValue)
            {
                endDate = DateTime.UtcNow;
            }

            var fluxTables = await _airConditionerService.GetInfluxDataDateRangeAsync(id.ToString(), startDate.Value, endDate.Value);
            var influxData = new List<ACActionsDTO>();
            foreach (var fluxTable in fluxTables)
            {
                int i = 0;
                foreach (var fluxRecord in fluxTable.Records)
                {
                    Console.WriteLine(fluxRecord.Values);
                    Console.WriteLine(fluxRecord.ToString());
                    var data = new ACActionsDTO
                    {
                        Temperature = fluxRecord.Values["currentTemp"].ToString(),
                        Mode = fluxRecord.Values["mode"].ToString(),
                        Name = fluxRecord.Values["user"].ToString(),
                        Timestamp = fluxRecord.GetTimeInDateTime()
                    };

                    Console.WriteLine(i);
                    influxData.Add(data);
                }
            }
            return Ok(influxData);
        }
    }

}
