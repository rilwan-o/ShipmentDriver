using ShipmentDriver.Web.Dtos;
using ShipmentDriver.Web.Models;
using ShipmentDriver.Web.ViewModels;


namespace ShipmentDriver.Web.Contracts
{
    public interface IShipmentPageServices 
    {
        Task<Shipment> CreateShipment(ShipmentDto shipment);
        Task DeleteShipment(string id);
        Task<Shipment> GetShipment(string id);
        Task<List<Shipment>> GetShipments();
        Task UpdateShipment(Shipment shipment);
        Task<ShipmentStatusUpdateViewModel> PickUp(string ShipmentId, string DriverId);
        Task<ShipmentStatusUpdateViewModel> Delivered(string ShipmentId, string DriverId);
        Task<ShipmentStatusUpdateViewModel> Returned(string ShipmentId, string DriverId);
    }
}
