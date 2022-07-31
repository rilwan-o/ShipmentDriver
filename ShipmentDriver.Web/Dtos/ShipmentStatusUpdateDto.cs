using System.ComponentModel.DataAnnotations;

namespace ShipmentDriver.Web.Dtos
{
    public class ShipmentStatusUpdateDto
    {
        public string ShipmentId { get; set; }
        public string  DriverId { get; set; }
    }
}
