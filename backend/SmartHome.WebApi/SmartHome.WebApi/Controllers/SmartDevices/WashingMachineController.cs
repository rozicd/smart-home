using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("washing-machine")]
    public class WashingMachineController : BaseController
    {
        private readonly IWashingMachineService _washingMachineService;
        private readonly ISmartDeviceService _smartDeviceService;
        private readonly IFileService _fileService;

        public WashingMachineController(ISmartDeviceService smartDeviceService, IWashingMachineService washingMachineService, IMapper mapper, IFileService fileService) : base(mapper)
        {
            _washingMachineService = washingMachineService;
            _fileService = fileService;
            _smartDeviceService = smartDeviceService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddWashingMachine([FromForm] CreateWashingMachineDTO washingMachine)
        {
            WashingMachine response = _mapper.Map<WashingMachine>(washingMachine);
            var imagePath = await _fileService.SaveImageAsync(washingMachine.ImageFile, "static/properties");
            response.UserId = _user.UserId;
            response.ImageUrl = imagePath;
            await _washingMachineService.Add(response);
           

            return Ok();
        }
    }

}
