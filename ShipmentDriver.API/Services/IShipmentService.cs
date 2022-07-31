using ShipmentDriver.API.Dtos;
using ShipmentDriver.API.ViewModels;
using ShipmentDriver.Data.Models;

namespace ShipmentDriver.API.Services
{
    public interface IShipmentService
    {
        Shipment CreateShipment(ShipmentDto shipmentDto);
        void DeleteShipment(string id);
        Shipment GetShipment(string id);
        List<Shipment> GetShipments();
        void UpdateShipment(Shipment shipment);
        ShipmentStatusUpdateViewModel PickUp(string ShipmentId, string DriverId);
        ShipmentStatusUpdateViewModel Delivered(string ShipmentId, string DriverId);
        ShipmentStatusUpdateViewModel Returned(string ShipmentId, string DriverId);
    }
}
