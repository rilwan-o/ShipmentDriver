using System.ComponentModel.DataAnnotations;

namespace ShipmentDriver.API.Dtos
{
    public class ShipmentStatusUpdateDto
    {
        [Required]
        public string ShipmentId { get; set; }
        [Required]
        public string  DriverId { get; set; }
    }
}
