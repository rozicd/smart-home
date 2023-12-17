using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.Application.Services.SmartDevices;
using SmartHome.DataTransferObjects.Responses;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SmartHome.Application.Services;
using InfluxDB.Client.Core.Flux.Domain;
using NodaTime;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("cargate")]
    public class CarGateController : BaseController
    {
        private readonly ICarGateService _carGateService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;
        private readonly IInfluxClientService _influxClientService;

        public CarGateController(ISmartDeviceService smartDeviceService, IInfluxClientService influxClientService, ICarGateService carGateService, IMapper mapper, IFileService fileService) : base(mapper)
        {
            _carGateService = carGateService;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
            _influxClientService = influxClientService;
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

        [HttpGet("{carGateId}")]
        public async Task<IActionResult> GetCarGateById(Guid carGateId)
        {
            CarGate carGate = await _carGateService.GetById(carGateId);

            var carGateDTO = _mapper.Map<CarGateResponseDTO>(carGate);

            return Ok(carGateDTO);
        }

        [HttpPut("{carGateId}/open")]
        public async Task<IActionResult> OpenGate(Guid carGateId)
        {
            var userEmail = GetUserEmailFromCookie(); 
            await _carGateService.OpenGate(carGateId, userEmail);
            return Ok();
        }

        [HttpPut("{carGateId}/close")]
        public async Task<IActionResult> CloseGate(Guid carGateId)
        {
            var userEmail = GetUserEmailFromCookie();
            await _carGateService.CloseGate(carGateId, userEmail);
            return Ok();
        }

        [HttpPut("{carGateId}/changemode")]
        public async Task<IActionResult> ChangeMode(Guid carGateId, [FromBody] ChangeModeDTO changeModeDTO)
        {
            await _carGateService.ChangeMode(carGateId, changeModeDTO.NewMode);
            return Ok();
        }

        [HttpPost("{carGateId}/addlicenseplate")]
        public async Task<IActionResult> AddLicensePlate(Guid carGateId, [FromBody] AddRemoveLicensePlateDTO addLicensePlateDTO)
        {
            await _carGateService.AddLicensePlate(carGateId, addLicensePlateDTO.LicensePlate);
            return Ok();
        }

        [HttpDelete("{carGateId}/removelicenseplate")]
        public async Task<IActionResult> RemoveLicensePlate(Guid carGateId, [FromBody] AddRemoveLicensePlateDTO removeLicensePlateDTO)
        {
            await _carGateService.RemoveLicensePlate(carGateId, removeLicensePlateDTO.LicensePlate);
            return Ok();
        }

        private string GetUserEmailFromCookie()
        {
            var tokenCookie = Request.Cookies["jwtToken"];

            if (string.IsNullOrEmpty(tokenCookie))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("smarthomesmarthomesmarthome");

            SecurityToken token;
            var principal = tokenHandler.ValidateToken(tokenCookie, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out token);

            var userEmail = principal?.FindFirst(ClaimTypes.Email)?.Value;

            return userEmail;
        }

        [HttpGet("{carGateId}/history")]
        public async Task<IActionResult> GetCarActions(Guid carGateId, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                if (!startDate.HasValue)
                {
                    startDate = DateTime.UtcNow.AddHours(-6);
                }

                if (!endDate.HasValue)
                {
                    endDate = DateTime.UtcNow;
                }

                var fluxTables = await _carGateService.GetCarGateInfluxDataAsync(carGateId, startDate.Value, endDate.Value);
                var influxData = new List<CarGateActionsDTO>();

                foreach (var fluxTable in fluxTables)
                {
                    foreach( var fluxRecord in fluxTable.Records)
                    {

                        var data = new CarGateActionsDTO
                        {
                            User = fluxRecord.Values["user"].ToString(),
                            Action = fluxRecord.Values["action"].ToString(),
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
