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
           
            await _carChargerService.ChangeTreshold(cct.Id,cct.Plug,cct.Treshold,_user.Email);

            
            return Ok();
        }
        [HttpGet("{chargerId}")]
        public async Task<IActionResult> GetChargerById(Guid chargerId)
        {
            CarCharger charger = await _carChargerService.GetById(chargerId);

            var chargerDTO = _mapper.Map<CarChargerResponseDTO>(charger);

            return Ok(chargerDTO);
        }
        [HttpGet("{id}/history")]
        public async Task<IActionResult> GetCarActions(string id, DateTime? startDate = null, DateTime? endDate = null)
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

                var fluxTables = await _carChargerService.GetChargerActionsInfluxDate(id, startDate.Value, endDate.Value);
                var influxData = new List<CarChargerActionsDTO>();

                foreach (var fluxTable in fluxTables)
                {
                    foreach (var fluxRecord in fluxTable.Records)
                    {
                                
                        var data = new CarChargerActionsDTO
                        {
                            User = fluxRecord.GetValueByKey("user").ToString(),
                            Action = fluxRecord.GetValueByKey("action").ToString(),
                            Field = fluxRecord.GetValueByKey("_field").ToString(),
                            Value = fluxRecord.GetValueByKey("_value").ToString(),
                            Timestamp = fluxRecord.GetValueByKey("_time").ToString(),
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
