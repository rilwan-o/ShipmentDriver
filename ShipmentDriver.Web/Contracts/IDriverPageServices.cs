using ShipmentDriver.Web.Dtos;
using ShipmentDriver.Web.Models;
using ShipmentDriver.Web.ViewModels;

namespace ShipmentDriver.Web.Contracts
{
    public interface IDriverPageServices
    {
        Task<List<DriverViewModel>> GetDrivers();
        Task<Driver> GetDriver(string id);
        Task<DriverViewModel> CreateDriver(DriverDto driverDto);
        Task UpdateDriver(Driver driver);
        Task DeleteDriver(string id);
    }
}
