using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Application.Services.SmartDevices;

namespace SmartHome.WebApi.Controllers.SmartDevices
{
    [ApiController]
    [Route("washingmachine")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            WashingMachine washingMachine = await  _washingMachineService.GetById(id);
            WashingMachineResponseDTO response = _mapper.Map<WashingMachineResponseDTO>(washingMachine);
            return Ok(response);
            
        }

        [HttpGet("modes")]
        public async Task<IActionResult> GetWashingMachineModes()
        {
            List<WashingMachineMode> modes = await _washingMachineService.GetWashingMachineModes();
            WashingMachineModesResponseDTO response =  new WashingMachineModesResponseDTO 
            { 
                WashingMachineModes = modes.Select(_mapper.Map<WashingMachineModeDTO>).ToList()
            };
            
            return Ok(response);
        }
        [HttpGet("turnOn/{id}")]
        public async Task<IActionResult> TurnOn(Guid id)
        {
            await _washingMachineService.TurnOn(id);
            return Ok();
        }

        [HttpGet("turnOff/{id}")]
        public async Task<IActionResult> TurnOff(Guid id)
        {
            await _washingMachineService.TurnOff(id);
            return Ok();
        }
        [HttpPost("changeMode")]
        public async Task<IActionResult> ChangeMode([FromBody]ChangeWMModeRequestDTO changeWMModeRequestDTO)
        {
            WashingMachine washingMachine = await _washingMachineService.GetById(changeWMModeRequestDTO.Id);
            await _washingMachineService.changeMode(_user, changeWMModeRequestDTO.Mode, washingMachine);
            return Ok();
        }

        [HttpGet("history/{id}")]
        public async Task<IActionResult> getWMActions(Guid id, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (!startDate.HasValue)
            {
                startDate = DateTime.UtcNow.AddHours(-24);
            }

            if (!endDate.HasValue)
            {
                endDate = DateTime.UtcNow;
            }

            var fluxTables = await _washingMachineService.GetInfluxDataDateRangeAsync(id.ToString(), startDate.Value, endDate.Value);
            var influxData = new List<WMActionsDTO>();
            foreach (var fluxTable in fluxTables)
            {
                int i = 0;
                foreach (var fluxRecord in fluxTable.Records)
                {
                    Console.WriteLine("KURCINA: "+ fluxRecord.Values["mode"]);
                    Console.WriteLine(fluxRecord.Values);
                    var data = new WMActionsDTO
                    {
                        Mode = fluxRecord.Values["mode"] == null?"": fluxRecord.Values["mode"].ToString(),
                        Name = fluxRecord.Values["user"].ToString(),
                        Timestamp = fluxRecord.GetTimeInDateTime()
                    };

                    Console.WriteLine(i);
                    influxData.Add(data);
                }
            }
            return Ok(influxData);
        }
    }

}
