using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Application.Services;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models;
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
            PaginationReturnObject<SmartDeviceResponseDTO> response = new PaginationReturnObject<SmartDeviceResponseDTO>(_mapper.Map<IEnumerable<SmartDeviceResponseDTO>>(devices.Items),devices.Page,devices.PageSize,devices.TotalItems);

            return Ok(response);
        }
        
    }
}