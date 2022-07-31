using ShipmentDriver.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentDriver.Data.Contracts
{//Pickup,Delivered, Returned
    public interface IShipmentRepository : IRepositoryBase<Shipment>
    {
        void PickUp(string ShipmentId, string DriverId);
        void Delivered(string ShipmentId, string DriverId);
        void Returned(string ShipmentId, string DriverId);
    }
}
