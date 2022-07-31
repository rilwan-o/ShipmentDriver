using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentDriver.Web.Models
{

    [Table("driver")]
    public class Driver
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fist Name is required")]
        [StringLength(60, ErrorMessage = "First Name can't be longer than 60 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(60, ErrorMessage = "Last Name can't be longer than 60 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Vehicle Plate is required")]
        [StringLength(60, ErrorMessage = "Vehicle Plate can't be longer than 60 characters")]
        public string? VehiclePlate { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Expiration Date is required")]
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public int Active { get; set; }
    }


}
