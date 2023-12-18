using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using InfluxDB.Client.Core.Flux.Domain;
using SmartHome.Application.Services.SmartDevices;

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
        public async Task<IActionResult> GetLampById(Guid lampId)
        {
            Lamp lamp = await _lampService.GetById(lampId);

            var lampDTO = _mapper.Map<LampResponseDTO>(lamp);

            return Ok(lampDTO);
        }

        [HttpPost("turnOn")]
        public async Task<IActionResult> TurnOn([FromBody] TurnOnOffDTO turnOnDTO)
        {
            await _lampService.TurnOn(turnOnDTO.LampId);
            return Ok();
        }

        [HttpPost("turnOff")]
        public async Task<IActionResult> TurnOff([FromBody] TurnOnOffDTO turnOffDTO)
        {
            await _lampService.TurnOff(turnOffDTO.LampId);
            return Ok();
        }

        [HttpPost("changeThreshold")]
        public async Task<IActionResult> ChangeThreshold([FromBody] ChangeThresholdDTO changeThresholdDTO)
        {
            await _lampService.ChangeThreshold(changeThresholdDTO.LampId, changeThresholdDTO.NewThreshold);
            return Ok();
        }

        [HttpPost("changeMode")]
        public async Task<IActionResult> ChangeMode([FromBody] ChangeLampModeDTO changeModeDTO)
        {
            await _lampService.ChangeMode(changeModeDTO.LampId, changeModeDTO.Mode);
            return Ok();
        }

        [HttpPost("data")]
        public async Task<IActionResult> GetPowerInLastHour([FromBody] DeviceHistoryRequestDTO bh)
        {
            List<FluxTable> fluxTables = await _lampService.GetInfluxDataAsync(bh.Id.ToString(), bh.Hours);

            var influxData = new List<LampDataResponseDTO>();

            foreach (var fluxTable in fluxTables)
            {
                foreach (var fluxRecord in fluxTable.Records)
                {

                    var data = new LampDataResponseDTO
                    {

                        CurrentLight = fluxRecord.Values["light"].ToString(),
                        PowerStatus = fluxRecord.Values["power"].ToString(),
                        Timestamp = fluxRecord.GetTimeInDateTime()
                    };

                    influxData.Add(data);
                }
            }

            return Ok(influxData);
        }

        [HttpPost("data/date")]
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
                foreach (var fluxRecord in fluxTable.Records)
                {

                    var data = new LampDataResponseDTO
                    {

                        CurrentLight = fluxRecord.Values["light"].ToString(),
                        PowerStatus = fluxRecord.Values["power"].ToString(),
                        Timestamp = fluxRecord.GetTimeInDateTime()
                    };

                    influxData.Add(data);
                }
            }

            return Ok(influxData);
        }
    }

}
