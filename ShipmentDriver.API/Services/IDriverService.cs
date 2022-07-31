using ShipmentDriver.API.Dtos;
using ShipmentDriver.Data.Models;

namespace ShipmentDriver.API.Services
{
    public interface IDriverService
    {
        List<Driver> GetDrivers();
        Driver GetDriver(string id);
        Driver CreateDriver(DriverDto driverDto);
        void UpdateDriver(Driver driver);
        void DeleteDriver(string id);
    }
}
