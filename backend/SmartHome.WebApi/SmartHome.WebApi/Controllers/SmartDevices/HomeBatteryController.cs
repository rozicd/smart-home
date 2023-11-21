using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("home-battery")]
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
        public async Task<IActionResult> AddHomeBattery([FromForm] CreateHomeBatteryDTO homeBattery)
        {
            HomeBattery response = _mapper.Map<HomeBattery>(homeBattery);
            var imagePath = await _fileService.SaveImageAsync(homeBattery.ImageFile, "static/properties");

            response.ImageUrl = imagePath;
            response.UserId = _user.UserId;
            await _homeBatteryService.Add(response);

            return Ok();
        }
    }

}
