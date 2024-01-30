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
    [Route("carcharger")]
    public class CarChargerController : BaseController
    {
        private readonly ICarChargerService _carChargerService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;

        public CarChargerController(ISmartDeviceService smartDeviceService, ICarChargerService carChargerService, IMapper mapper, IFileService fileService) : base(mapper)
        {
            _carChargerService = carChargerService;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCarCharger([FromForm] CreateCarChargerDTO carCharger)
        {
            CarCharger response = _mapper.Map<CarCharger>(carCharger);
            var imagePath = await _fileService.SaveImageAsync(carCharger.ImageFile, "static/properties");

            response.ImageUrl = imagePath;
            response.UserId = _user.UserId;
            await _carChargerService.Add(response);

            return Ok();
        }
        [HttpPost("treshold")]
        public async Task<IActionResult> ChangeTreshold([FromBody] ChangeCarTresholdDTO cct)
        {
           
            await _carChargerService.ChangeTreshold(cct.Id,cct.Plug,cct.Treshold);

            
            return Ok();
        }
        [HttpGet("{chargerId}")]
        public async Task<IActionResult> GetChargerById(Guid chargerId)
        {
            CarCharger charger = await _carChargerService.GetById(chargerId);

            var chargerDTO = _mapper.Map<CarChargerResponseDTO>(charger);

            return Ok(chargerDTO);
        }
    }

}
