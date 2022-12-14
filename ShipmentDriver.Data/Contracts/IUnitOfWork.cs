using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentDriver.Data.Contracts
{
    public interface IUnitOfWork
    {
        IDriverRepository Driver { get; }
        IShipmentRepository Shipment { get; }
        void Save();
    }
}
