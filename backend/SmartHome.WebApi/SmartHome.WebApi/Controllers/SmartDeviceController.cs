using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Application.Services;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services;

namespace SmartHome.WebApi.Controllers
{
    [ApiController]
    [Route("smart-device")]
    public class SmartDeviceController : BaseController
    {
        private readonly ISmartDeviceService _smartDeviceService;


        public SmartDeviceController(ISmartDeviceService smartDeviceService, IMapper mapper) : base(mapper)
        {
            _smartDeviceService = smartDeviceService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromQuery] Pagination page)
        {

            PaginationReturnObject<SmartDevice> devices =await  _smartDeviceService.GetAll(page);
            PaginationReturnObject<SmartDeviceResponseDTO> response = new PaginationReturnObject<SmartDeviceResponseDTO>(_mapper.Map<IEnumerable<SmartDeviceResponseDTO>>(devices.Items),devices.PageNumber,devices.PageSize,devices.TotalItems);

            return Ok(response);
        }
        [HttpPost("connect")]
        public async Task<IActionResult> ConnectDevice([FromForm] ConnectDeviceDTO cd)
        {
            await _smartDeviceService.Connect(cd.Id, cd.Address);
            return Ok();

        }
        [HttpPost("on")]
        public async Task<IActionResult> PowerOn([FromForm] DevicePowerDTO dp)
        {
            await _smartDeviceService.TurnOn(dp.Id);
            return Ok();

        }
        [HttpPost("off")]
        public async Task<IActionResult> PowerOff([FromForm] DevicePowerDTO dp)
        {
            await _smartDeviceService.TurnOff(dp.Id);
            return Ok();

        }

    }
}