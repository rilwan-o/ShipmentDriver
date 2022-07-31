using System.ComponentModel.DataAnnotations;

namespace ShipmentDriver.Web.Dtos
{
    public class ShipmentDto
    {
        [Required(ErrorMessage = "Origin is required")]
        [StringLength(60, ErrorMessage = "Origin can't be longer than 60 characters")]
        public string? Origin { get; set; }
        [Required(ErrorMessage = "Destination is required")]
        [StringLength(60, ErrorMessage = "Destination can't be longer than 60 characters")]
        public string? Destination { get; set; }
        [Required(ErrorMessage = "Shipment Date is required")]
        public DateTime? ShipmentDate { get; set; }
        [Required(ErrorMessage = "Planned Date is required")]
        public DateTime? PlannedDate { get; set; }
        [Required(ErrorMessage = "Effective Date is required")]
        public DateTime? EffectiveDate { get; set; }
        public string? Comments { get; set; }
        public string? CreatedBy { get; set; }
        public string? DriverId { get; set; }

    }

}
