using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("sprinkler")]
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
    }

}
