using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShipmentDriver.API.Dtos;
using ShipmentDriver.API.Services;
using ShipmentDriver.API.ViewModels;
using ShipmentDriver.Data.Models;

namespace ShipmentDriver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentDriverService _shipmentDriverService;
        private readonly IMapper _mapper;

        public ShipmentController(IShipmentDriverService shipmentDriverService, IMapper mapper)
        {
            _shipmentDriverService = shipmentDriverService;
            _mapper = mapper;
        }
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            var shipments = _shipmentDriverService.GetShipments();

            return Ok(shipments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var shipment = _shipmentDriverService.GetShipment(id);
            if (shipment is null) return NotFound();

            return Ok(shipment);
        }

        [HttpPost]
        public IActionResult Add(ShipmentDto shipmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Shipment shipment = _shipmentDriverService.CreateShipment(shipmentDto);

            return CreatedAtAction(nameof(GetById), new { id = shipment.Id }, shipment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Shipment shipment)
        {
            if (id != shipment.Id.ToString())
            {
                return BadRequest();
            }

            _shipmentDriverService.UpdateShipment(shipment);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _shipmentDriverService.DeleteShipment(id);
            return NoContent();
        }

        [HttpPost("pickup")]
        public IActionResult Pickup(ShipmentStatusUpdateDto shipmentStatusUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ShipmentStatusUpdateViewModel resp = _shipmentDriverService.PickUp(shipmentStatusUpdateDto.ShipmentId, shipmentStatusUpdateDto.DriverId);

            return Ok(resp);
        }

        [HttpPost("delivered")]
        public IActionResult Delievered(ShipmentStatusUpdateDto shipmentStatusUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ShipmentStatusUpdateViewModel resp = _shipmentDriverService.Delivered(shipmentStatusUpdateDto.ShipmentId, shipmentStatusUpdateDto.DriverId);

            return Ok(resp);
        }

        [HttpPost("returned")]
        public IActionResult Returned(ShipmentStatusUpdateDto shipmentStatusUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ShipmentStatusUpdateViewModel resp = _shipmentDriverService.Returned(shipmentStatusUpdateDto.ShipmentId, shipmentStatusUpdateDto.DriverId);

            return Ok(resp);
        }
    }
}


