using Microsoft.EntityFrameworkCore;
using ShipmentDriver.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentDriver.Data.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Driver>? Drivers { get; set; }
        public DbSet<Shipment>? Shipments { get; set; }
    }
}
