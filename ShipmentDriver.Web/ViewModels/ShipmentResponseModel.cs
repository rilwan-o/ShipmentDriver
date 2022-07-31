using Microsoft.AspNetCore.Mvc.Rendering;
using ShipmentDriver.Web.Contracts;

namespace ShipmentDriver.Web.ViewModels
{
    public class ShipmentResponseModel
    {
        public string id { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public int status { get; set; }
        public DateTime shipmentDate { get; set; }
        public DateTime plannedDate { get; set; }
        public DateTime effectiveDate { get; set; }
        public string? comments { get; set; }
        public DateTime createdAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public string? updatedBy { get; set; }
        public string? driverId { get; set; }
    }

    public class ShipmentResponseModel1
    {
        private readonly IDriverPageServices _driverPageService;
        public ShipmentResponseModel1(IDriverPageServices driverPageService)
        {
            _driverPageService = driverPageService;
        }
        public string? id { get; set; }
        public string? origin { get; set; }
        public string? destination { get; set; }
        public int? status { get; set; }
        public DateTime? shipmentDate { get; set; }
        public DateTime? plannedDate { get; set; }
        public DateTime? effectiveDate { get; set; }
        public string? comments { get; set; }
        public DateTime? createdAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public string? updatedBy { get; set; }
        public string? driverId { get; set; }
        public List<SelectListItem>? drivers { get; set; } = new List<SelectListItem>();
        public async Task OnGet()
        {
            drivers = (await _driverPageService.GetDrivers()).Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.id.ToString() ,
                                      Text = $"{a.firstName} {a.lastName}"
                                  }).ToList(); 
        }
    }
}
