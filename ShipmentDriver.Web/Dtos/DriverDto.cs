using System.ComponentModel.DataAnnotations;

namespace ShipmentDriver.Web.Dtos
{
    public class DriverDto
    {
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
        [Required(ErrorMessage = "Status is required")]
        public int Active { get; set; }

    }
}
