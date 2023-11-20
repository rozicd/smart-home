using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Domain.Services;
using SmartHome.DataTransferObjects.Responses;
using System.Threading.Tasks;

namespace SmartHome.WebApi.Controllers
{
    [ApiController]
    [Route("cities")]
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService, IMapper mapper) : base(mapper)
        {
            _cityService = cityService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _cityService.GetAllCities();
            var cityResponseDTOs = _mapper.Map<List<CityResponseDTO>>(cities);
            return Ok(cityResponseDTOs);
        }
    }
}
