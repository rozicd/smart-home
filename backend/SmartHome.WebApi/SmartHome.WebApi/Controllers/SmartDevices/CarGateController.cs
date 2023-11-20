using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("car-gate")]
    public class CarGateController : BaseController
    {
        private readonly ICarGateService _carGateService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;

        public CarGateController(ISmartDeviceService smartDeviceService, ICarGateService carGateService, IMapper mapper, IFileService fileService) : base(mapper)
        {
            _carGateService = carGateService;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCarGate([FromForm] CreateCarGateDTO carGate)
        {
            CarGate response = _mapper.Map<CarGate>(carGate);
            var imagePath = await _fileService.SaveImageAsync(carGate.ImageFile, "static/properties");

            response.ImageUrl = imagePath;
            response.UserId = _user.UserId;
            await _carGateService.Add(response);

            return Ok();
        }
    }

}
