using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.Application.Services.SmartDevices;
using SmartHome.DataTransferObjects.Responses;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("solarpanelsystem")]
    public class SolarPanelSystemController : BaseController
    {
        private readonly ISolarPanelSystemService _solarPanelSystemService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;

        public SolarPanelSystemController(ISmartDeviceService smartDeviceService, ISolarPanelSystemService solarPanelSystemService, IMapper mapper, IFileService fileService) : base(mapper)
        {
            _solarPanelSystemService = solarPanelSystemService;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddSolarPanelSystem([FromForm] CreateSolarPanelSystemDTO solarPanelSystem)
        {
            SolarPanelSystem response = _mapper.Map<SolarPanelSystem>(solarPanelSystem);
            var imagePath = await _fileService.SaveImageAsync(solarPanelSystem.ImageFile, "static/properties");

            response.ImageUrl = imagePath;
            response.UserId = _user.UserId;
            await _solarPanelSystemService.Add(response);

            return Ok();
        }
        [HttpGet("{systemId}")]
        public async Task<IActionResult> GetSystemById(Guid systemId)
        {
            SolarPanelSystem system = await _solarPanelSystemService.GetById(systemId);

            var systemDTO = _mapper.Map<SolarPanelSystemResponseDTO>(system);

            return Ok(systemDTO);
        }
        [HttpPost("turnOn")]

        public async Task<IActionResult> TurnOn([FromBody] TurnOnOffDTO turnOnDTO)
        {
            await _solarPanelSystemService.TurnOn(turnOnDTO.LampId,_user);
            return Ok();
        }

        [HttpPost("turnOff")]
        public async Task<IActionResult> TurnOff([FromBody] TurnOnOffDTO turnOffDTO)
        {
            await _solarPanelSystemService.TurnOff(turnOffDTO.LampId,_user);
            return Ok();
        }
        [HttpGet("{id}/history")]
        public async Task<IActionResult> GetCarActions(Guid id, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                if (!startDate.HasValue)
                {
                    startDate = DateTime.UtcNow.AddHours(-6);
                }

                if (!endDate.HasValue)
                {
                    endDate = DateTime.UtcNow.AddHours(1);
                }

                var fluxTables = await _solarPanelSystemService.GetSPSInfluxDataAsync(id, startDate.Value, endDate.Value);
                var influxData = new List<CarGateActionsDTO>();

                foreach (var fluxTable in fluxTables)
                {
                    foreach (var fluxRecord in fluxTable.Records)
                    {

                        var data = new CarGateActionsDTO
                        {
                            User = fluxRecord.Values["user"].ToString(),
                            Action = fluxRecord.Values["command"].ToString(),
                            Timestamp = fluxRecord.GetTimeInDateTime()
                        };

                        influxData.Add(data);
                    }
                }
                return Ok(influxData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }

}
