using ShipmentDriver.Data.Contracts;
using ShipmentDriver.Data.Data;
using ShipmentDriver.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentDriver.Data.Repositories
{
    public class ShipmentRepository : RepositoryBase<Shipment>, IShipmentRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public ShipmentRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Delivered(string ShipmentId, string DriverId)
        {
            var shipment = _repositoryContext.Shipments.FirstOrDefault(s => s.Id.ToString() == ShipmentId && s.DriverId.ToString()==DriverId);
            if(shipment is not null)
            {
                shipment.Status = (int)ShipmentStatus.delivered;
                shipment.DriverId = DriverId;
                shipment.UpdatedAt = DateTime.Now;
                _repositoryContext.Shipments.UpdateRange(shipment);

            };
        }

        public void PickUp(string ShipmentId, string DriverId)
        {
            var shipment = _repositoryContext.Shipments.FirstOrDefault(s => s.Id.ToString() == ShipmentId);
            if (shipment is not null)
            {
                shipment.Status = (int)ShipmentStatus.pickup;
                shipment.DriverId = DriverId;
                shipment.UpdatedAt = DateTime.Now;
                _repositoryContext.Shipments.UpdateRange(shipment);

            };
        }

        public void Returned(string ShipmentId, string DriverId)
        {
            var shipment = _repositoryContext.Shipments.FirstOrDefault(s => s.Id.ToString() == ShipmentId);
            if (shipment is not null)
            {
                shipment.Status = (int)ShipmentStatus.returned;
                shipment.DriverId=DriverId;
                shipment.UpdatedAt = DateTime.Now;
                _repositoryContext.Shipments.UpdateRange(shipment);

            };
        }
    }
}
