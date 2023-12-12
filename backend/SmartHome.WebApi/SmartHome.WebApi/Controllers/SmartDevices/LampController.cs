using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("lamp")]
    public class LampController : BaseController
    {
        private readonly ILampService _lampService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;

        public LampController(ISmartDeviceService smartDeviceService, ILampService lampService, IMapper mapper, IFileService fileService) : base(mapper)
        {
            _lampService = lampService;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddLamp([FromForm] CreateLampDTO lamp)
        {
            Lamp response = _mapper.Map<Lamp>(lamp);
            var imagePath = await _fileService.SaveImageAsync(lamp.ImageFile, "static/properties");

            response.ImageUrl = imagePath;
            response.UserId = _user.UserId;
            await _lampService.Add(response);

            return Ok();
        }

        [HttpGet("{lampId}")]
        public async Task<IActionResult> GetLampById(Guid lampId)
        {
            Lamp lamp = await _lampService.GetById(lampId);

            var lampDTO = _mapper.Map<LampResponseDTO>(lamp);

            return Ok(lampDTO);
        }
    }

}
