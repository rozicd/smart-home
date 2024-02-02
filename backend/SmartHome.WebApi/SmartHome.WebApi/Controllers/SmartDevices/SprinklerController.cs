using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SmartHome.Application.Services.SmartDevices;
using SmartHome.DataTransferObjects.Responses;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("api/sprinkler")]
    public class SprinklerController : BaseController
    {
        private readonly ISprinklerService _sprinklerService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;

        public SprinklerController(ISmartDeviceService smartDeviceService, ISprinklerService sprinklerService, IMapper mapper, IFileService fileService) : base(mapper)
        {
            _sprinklerService = sprinklerService;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddSprinkler([FromForm] CreateSprinklerDTO sprinkler)
        {
            Sprinkler response = _mapper.Map<Sprinkler>(sprinkler);
            var imagePath = await _fileService.SaveImageAsync(sprinkler.ImageFile, "static/properties");

            response.ImageUrl = imagePath;
            response.UserId = _user.UserId;
            await _sprinklerService.Add(response);

            return Ok();
        }
        [HttpGet("{sprinklerId}")]
        public async Task<IActionResult> GetSprinklerById(Guid sprinklerId)
        {
            Sprinkler sprinkler = await _sprinklerService.GetById(sprinklerId);
            List<SprinklerSchedule> sprinklerSchedules = await _sprinklerService.GetSprinklerSchedules(sprinklerId);
            if(sprinkler == null)
            {
                return NotFound($"Sprinkler with id {sprinklerId} does not exist!");
            }
            var sprinklerDto = _mapper.Map<SprinklerResponseDTO>(sprinkler);
            sprinklerDto.Schedules = _mapper.Map<List<SprinklerScheduleResponseDTO>>(sprinklerSchedules);
            return Ok(sprinklerDto);
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
        [HttpPost("{id}/turn-on")]
        public async Task<IActionResult> TurnOnSprinkler(Guid id)
        {
            await _sprinklerService.TurnOn(id, GetUserEmailFromCookie());
            return Ok();
        }

        [HttpPost("{id}/turn-off")]
        public async Task<IActionResult> TurnOffSprinkler(Guid id)
        {
            await _sprinklerService.TurnOff(id, GetUserEmailFromCookie());
            return Ok();
        }

        [HttpPost("{id}/add-schedule")]
        public async Task<IActionResult> AddSprinklerSchedule(Guid id, [FromBody] SprinklerScheduleDTO schedule)
        {
            var sprinklerResponse = _mapper.Map<SprinklerScheduleResponseDTO>(await _sprinklerService.AddSchedule(id, _mapper.Map<SprinklerSchedule>(schedule)));
            return Ok(sprinklerResponse);
        }

        [HttpPost("{id}/remove-schedule")]
        public async Task<IActionResult> RemoveSprinklerSchedule(Guid id, [FromBody] RemoveSprinklerScheduleDTO scheduleId)
        {
            await _sprinklerService.RemoveSchedule(id, scheduleId.ScheduleId);
            return Ok();
        }

        [HttpGet("{sprinklerId}/history")]
        public async Task<IActionResult> GetSprinklerActions(Guid sprinklerId, DateTime? startDate = null, DateTime? endDate = null)
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

                var fluxTables = await _sprinklerService.GetInfluxDataDateRangeAsync(sprinklerId.ToString(), startDate.Value, endDate.Value);
                var influxData = new List<SprinklerActionsDTO>();

                foreach (var fluxTable in fluxTables)
                {
                    int i = 0;
                    foreach (var fluxRecord in fluxTable.Records)
                    {
                        Console.WriteLine(fluxRecord.Values);

                        var data = new SprinklerActionsDTO
                        {
                            User = fluxRecord.Values["user"].ToString(),
                            Action = fluxRecord.Values["action"].ToString(),
                            Timestamp = fluxRecord.GetTimeInDateTime()
                        };

                        Console.WriteLine(i);
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
