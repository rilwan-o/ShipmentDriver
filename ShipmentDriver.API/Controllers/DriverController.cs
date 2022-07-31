using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShipmentDriver.API.Dtos;
using ShipmentDriver.API.Services;
using ShipmentDriver.API.ViewModels;
using ShipmentDriver.Data.Contracts;
using ShipmentDriver.Data.Models;

namespace ShipmentDriver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IShipmentDriverService _shipmentDriverService;
        private readonly IMapper _mapper;
        public DriverController(IShipmentDriverService shipmentDriverService, IMapper mapper)
        {
            _shipmentDriverService = shipmentDriverService;
            _mapper = mapper;
        }
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            List<DriverViewModel> driverViewModels = new List<DriverViewModel>();
            var drivers = _shipmentDriverService.GetDrivers();
            foreach (var driver in drivers)
            {
                DriverViewModel driverViewModel = _mapper.Map<DriverViewModel>(driver);
                driverViewModels.Add(driverViewModel);
            }
            return Ok(driverViewModels);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var driver = _shipmentDriverService.GetDriver(id);
            if (driver is null) return NotFound();

            return Ok(driver);
        }

        [HttpPost]
        public IActionResult Add(DriverDto driverDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(driverDto);
            }

            Driver driver = _shipmentDriverService.CreateDriver(driverDto);
            return CreatedAtAction(nameof(GetById), new { id = driver.Id }, driver);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Driver driver)
        {
            if (id != driver.Id.ToString())
            {
                return BadRequest();
            }

            _shipmentDriverService.UpdateDriver(driver);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _shipmentDriverService.DeleteDriver(id);
            return NoContent();
        }
    }
}
