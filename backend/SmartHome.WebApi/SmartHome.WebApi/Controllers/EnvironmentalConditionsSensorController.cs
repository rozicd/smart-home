using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models;
using SmartHome.Domain.Services;

namespace SmartHome.WebApi.Controllers
{
    [ApiController]
    [Route("conditions-sensor")]
    public class EnvironmentalConditionsSensorController : BaseController
    {
        private readonly IEnvironmentalConditionsSensorRepository _ecsService;
    
        public EnvironmentalConditionsSensorController(IEnvironmentalConditionsSensorRepository ecs,IMapper mapper) : base(mapper)
        {
            _ecsService = ecs;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddECS([FromBody] CreateECSRequestDTO esc)
        {
          
            EnvironmentalConditionsSensor response = new EnvironmentalConditionsSensor();
            response.EnergySpending = esc.EnergySpending;
            response.UserId = _user.UserId;
            await _ecsService.Add(response);
          
            return Ok();
        }
    }
}