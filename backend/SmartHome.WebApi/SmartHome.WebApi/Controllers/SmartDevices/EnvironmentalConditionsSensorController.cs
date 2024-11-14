using AutoMapper;
using InfluxDB.Client.Core.Flux.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Application.Services;
using SmartHome.Application.Services.SmartDevices;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.Domain.Services.SmartDevices;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("api/environmentalconditionssensor")]
    public class EnvironmentalConditionsSensorController : BaseController
    {
        private readonly IEnvironmentalConditionsSensorService _ecsService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;
        private readonly IInfluxClientService _influxClientService;


        public EnvironmentalConditionsSensorController(ISmartDeviceService smartDeviceService, IEnvironmentalConditionsSensorService ecs, IMapper mapper, IFileService fileService, IInfluxClientService influxClientService) : base(mapper)
        {
            _ecsService = ecs;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
            _influxClientService = influxClientService;
        }

        [HttpPost("")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> AddECS([FromForm] CreateSmartDeviceRequestDTO esc)
        {

            EnvironmentalConditionsSensor response = new EnvironmentalConditionsSensor();
            var imagePath = await _fileService.SaveImageAsync(esc.ImageFile, "static/properties");

            response.Name = esc.Name;
            response.EnergySpending = esc.EnergySpending;
            response.UserId = _user.UserId;
            response.ImageUrl = imagePath;
            response.PropertyId = esc.PropertyId;
            await _ecsService.Add(response);

            return Ok();
        }

        [HttpGet("{environmentalConditionsSensorId}")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> GetEcsById(Guid environmentalConditionsSensorId)
        {
            EnvironmentalConditionsSensor sensor = await _ecsService.GetById(environmentalConditionsSensorId);

            var sensorDTO = _mapper.Map<EnvironmentalContitionsSensorResponseDTO>(sensor);

            return Ok(sensorDTO);
        }

        [HttpGet("history/{id}")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> GetEscData(Guid id, DateTime? start = null, DateTime? end = null)
        {
            if (!start.HasValue)
            {
                start = DateTime.UtcNow.AddHours(-1);
            }

            if (!end.HasValue)
            {
                end = DateTime.UtcNow;
            }
            var fluxTables = await _ecsService.GetInfluxDataDateRangeAsync(id.ToString(), start.Value, end.Value);
            var influxData = new List<ESCData>();
            foreach (var fluxTable in fluxTables)
            {
                int i = 0;
                foreach (var fluxRecord in fluxTable.Records)
                {
                    Console.WriteLine(fluxRecord.Values);
                    var data = new ESCData
                    {
                        RoomTemperate = float.Parse(fluxRecord.Values["roomTemperature"].ToString()),
                        AirHumidity = float.Parse(fluxRecord.Values["airHumidity"].ToString()),
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