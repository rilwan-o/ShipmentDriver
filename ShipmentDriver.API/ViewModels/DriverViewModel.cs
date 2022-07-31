namespace ShipmentDriver.API.ViewModels
{
    public class DriverViewModel
    {
        public Guid Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? VehiclePlate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Active { get; set; }
    }
}
