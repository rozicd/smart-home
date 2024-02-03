using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.Application.Services.SmartDevices;
using SmartHome.DataTransferObjects.Responses;
using InfluxDB.Client.Core.Flux.Domain;
using Microsoft.AspNetCore.Authorization;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("homebattery")]
    public class HomeBatteryController : BaseController
    {
        private readonly IHomeBatteryService _homeBatteryService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;

        public HomeBatteryController(ISmartDeviceService smartDeviceService, IHomeBatteryService homeBatteryService, IMapper mapper, IFileService fileService) : base(mapper)
        {
            _homeBatteryService = homeBatteryService;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
        }

        [HttpPost("")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> AddHomeBattery([FromForm] CreateHomeBatteryDTO homeBattery)
        {
            HomeBattery response = _mapper.Map<HomeBattery>(homeBattery);
            var imagePath = await _fileService.SaveImageAsync(homeBattery.ImageFile, "static/properties");

            response.ImageUrl = imagePath;
            response.UserId = _user.UserId;
            await _homeBatteryService.Add(response);

            return Ok();
        }
        [HttpGet("{batteryId}")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> GetSystemById(Guid batteryId)
        {
            HomeBattery battery = await _homeBatteryService.GetById(batteryId);

            var batteryDTO = _mapper.Map<HomeBatteryResponseDTO>(battery);

            return Ok(batteryDTO);
        }
        [HttpPost("power")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> GetPowerInLastHour([FromBody] DeviceHistoryRequestDTO bh)
        {
            List<FluxTable> fluxTables = await _homeBatteryService.GetInfluxDataAsync(bh.Id.ToString(),bh.Hours);

            var influxData = new List<BatteryPowerResponseDTO>();

            foreach (var fluxTable in fluxTables)
            {
                foreach (var fluxRecord in fluxTable.Records)
                {

                    var data = new BatteryPowerResponseDTO
                    {

                        Energy = fluxRecord.GetValueByKey("_value").ToString(),
                        Timestamp = DateTime.Parse(fluxRecord.GetValueByKey("_time").ToString()),
                    };

                    influxData.Add(data);
                }
            }

            return Ok(influxData);
        }
        [HttpPost("power/date")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> GetPowerDateRange([FromBody] DeviceHistoryDateRequestDTO bh)
        {
            TimeSpan dateRange = bh.EndDate - bh.StartDate;
            if (dateRange.TotalDays > 30)
            {
                return BadRequest("Date range cannot be longer than one month");
            }
            if (bh.StartDate>bh.EndDate)
            {
                return BadRequest("Start date cannot be after end date");
            }
            List<FluxTable> fluxTables = await _homeBatteryService.GetInfluxDataDateRangeAsync(bh.Id.ToString(), bh.StartDate,bh.EndDate);

            var influxData = new List<BatteryPowerResponseDTO>();

            foreach (var fluxTable in fluxTables)
            {
                foreach (var fluxRecord in fluxTable.Records)
                {

                    var data = new BatteryPowerResponseDTO
                    {

                        Energy = fluxRecord.GetValueByKey("_value").ToString(),
                        Timestamp = DateTime.Parse(fluxRecord.GetValueByKey("_time").ToString()),
                    };

                    influxData.Add(data);
                }
            }

            return Ok(influxData);
        }

    }

}
