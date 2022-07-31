
namespace ShipmentDriver.Web.ViewModels
{
    public class DriverViewModel
    {
        public string id { get; set; } 
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? vehiclePlate { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? expirationDate { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public int active { get; set; }
    }

}


