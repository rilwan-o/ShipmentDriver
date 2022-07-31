using ShipmentDriver.Data.Contracts;
using ShipmentDriver.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentDriver.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private RepositoryContext _repoContext;
        private IDriverRepository _driver;
        private IShipmentRepository _shipment;

        public UnitOfWork(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IDriverRepository Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new DriverRepository(_repoContext);
                }
                return _driver;
            }
        }
        public IShipmentRepository Shipment
        {
            get
            {
                if (_shipment == null)
                {
                    _shipment = new ShipmentRepository(_repoContext);
                }
                return _shipment;
            }
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
