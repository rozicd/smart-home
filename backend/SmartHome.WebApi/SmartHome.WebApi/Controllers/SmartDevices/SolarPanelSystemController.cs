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
    }

}
