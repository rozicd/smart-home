using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using InfluxDB.Client.Core.Flux.Domain;
using SmartHome.Application.Services.SmartDevices;
using Microsoft.AspNetCore.Authorization;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("lamp")]
    public class LampController : BaseController
    {
        private readonly ILampService _lampService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;

        public LampController(ISmartDeviceService smartDeviceService, ILampService lampService, IMapper mapper, IFileService fileService) : base(mapper)
        {
            _lampService = lampService;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
        }

        [HttpPost("")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> AddLamp([FromForm] CreateLampDTO lamp)
        {
            Lamp response = _mapper.Map<Lamp>(lamp);
            var imagePath = await _fileService.SaveImageAsync(lamp.ImageFile, "static/properties");

            response.ImageUrl = imagePath;
            response.UserId = _user.UserId;
            await _lampService.Add(response);

            return Ok();
        }

        [HttpGet("{lampId}")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> GetLampById(Guid lampId)
        {
            Lamp lamp = await _lampService.GetById(lampId);

            var lampDTO = _mapper.Map<LampResponseDTO>(lamp);

            return Ok(lampDTO);
        }

        [HttpPost("turnOn")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> TurnOn([FromBody] TurnOnOffDTO turnOnDTO)
        {
            await _lampService.TurnOn(turnOnDTO.LampId);
            return Ok();
        }

        [HttpPost("turnOff")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> TurnOff([FromBody] TurnOnOffDTO turnOffDTO)
        {
            await _lampService.TurnOff(turnOffDTO.LampId);
            return Ok();
        }

        [HttpPost("changeThreshold")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> ChangeThreshold([FromBody] ChangeThresholdDTO changeThresholdDTO)
        {
            await _lampService.ChangeThreshold(changeThresholdDTO.LampId, changeThresholdDTO.NewThreshold);
            return Ok();
        }

        [HttpPost("changeMode")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> ChangeMode([FromBody] ChangeLampModeDTO changeModeDTO)
        {
            await _lampService.ChangeMode(changeModeDTO.LampId, changeModeDTO.Mode);
            return Ok();
        }

        [HttpPost("data")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> GetPowerInLastHour([FromBody] DeviceHistoryRequestDTO bh)
        {
            List<FluxTable> fluxTables = await _lampService.GetInfluxDataAsync(bh.Id.ToString(), bh.Hours);

            var influxData = new List<LampDataResponseDTO>();

            foreach (var fluxTable in fluxTables)
            {
                var lightRecord = fluxTable.Records[0];
                var powerRecord = fluxTable.Records[1];

                var data = new LampDataResponseDTO
                {

                    CurrentLight = GetFieldValue(lightRecord, "light"),
                    PowerStatus = GetFieldValue(powerRecord, "power"),
                    Timestamp = lightRecord.GetTimeInDateTime()
                };

                influxData.Add(data);
                
            }

            return Ok(influxData);
        }
        private static string GetFieldValue(FluxRecord fluxRecord, string fieldName)
        {
            if (fluxRecord.Values.TryGetValue("_field", out var field) && field.ToString() == fieldName)
            {
                if (fluxRecord.Values.TryGetValue("_value", out var value))
                {
                    if (value != null)
                    {
                        return value.ToString();
                    }
                }
            }

            return "0";
        }
        [HttpPost("data/date")]
        [Authorize(Roles = "USER")]
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

            List<FluxTable> fluxTables = await _lampService.GetInfluxDataDateRangeAsync(bh.Id.ToString(), bh.StartDate, bh.EndDate);

            var influxData = new List<LampDataResponseDTO>();

            foreach (var fluxTable in fluxTables)
            {
                var lightRecord = fluxTable.Records[0];
                var powerRecord = fluxTable.Records[1];

                var data = new LampDataResponseDTO
                {

                    CurrentLight = GetFieldValue(lightRecord, "light"),
                    PowerStatus = GetFieldValue(powerRecord, "power"),
                    Timestamp = lightRecord.GetTimeInDateTime()
                };

                influxData.Add(data);

            }

            return Ok(influxData);
        }
    }

}
