using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentDriver.Web.Models
{
    [Table("shipment")]
    public class Shipment
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Origin is required")]
        [StringLength(60, ErrorMessage = "Origin can't be longer than 60 characters")]
        public string? Origin { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        [StringLength(60, ErrorMessage = "Destination can't be longer than 60 characters")]
        public string? Destination { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Shipment Date is required")]
        public DateTime? ShipmentDate { get; set; }

        [Required(ErrorMessage = "Planned Date is required")]
        public DateTime? PlannedDate { get; set; }

        [Required(ErrorMessage = "Effective Date is required")]
        public DateTime? EffectiveDate { get; set; }

        public string? Comments { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public string? DriverId { get; set; }

    }
}
