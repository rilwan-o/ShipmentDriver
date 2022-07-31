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
    public class DriverRepository : RepositoryBase<Driver>, IDriverRepository
    {
        public DriverRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
