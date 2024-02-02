using AutoMapper;
using InfluxDB.Client.Core.Flux.Domain;
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
        public async Task<IActionResult> GetEcsById(Guid environmentalConditionsSensorId)
        {
            EnvironmentalConditionsSensor sensor = await _ecsService.GetById(environmentalConditionsSensorId);

            var sensorDTO = _mapper.Map<EnvironmentalContitionsSensorResponseDTO>(sensor);

            return Ok(sensorDTO);
        }
        [HttpGet("data")]
        public async Task<IActionResult> GetEscData([FromQuery] EcsInfluxRangeRequestDTO ecsInfluxRangeRequestDTO)
        {
            List<ESCData> data = await _influxClientService.GetESCDataAsync(ecsInfluxRangeRequestDTO.Name, ecsInfluxRangeRequestDTO.start, ecsInfluxRangeRequestDTO.end);

            return Ok(data);
        }

    }
}