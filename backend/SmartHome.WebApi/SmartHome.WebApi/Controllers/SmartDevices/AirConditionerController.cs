using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("air-conditioner")]
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
    }

}
