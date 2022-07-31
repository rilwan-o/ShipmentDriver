using System.ComponentModel.DataAnnotations;

namespace ShipmentDriver.API.Dtos
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

        [Required(ErrorMessage = "Comments is required")]
        [StringLength(160, ErrorMessage = "Comments can't be longer than 160 characters")]
        public string? Comments { get; set; }

        [Required(ErrorMessage = "Created By  is required")]
        [StringLength(60, ErrorMessage = "Created By  can't be longer than 60 characters")]
        public string? CreatedBy { get; set; }
        public string? DriverId { get; set; }

    }
}
