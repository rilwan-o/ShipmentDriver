using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentDriver.Data.Data
{
    //"status": 1: init , 2: pickup, 3:delivered, 4:returned.
    public enum ShipmentStatus
    {
        init = 1,
        pickup = 2,
        delivered = 3,
        returned = 4
    }

    public enum DriverStatus
    {
        inactive = 0,
        active = 1
    }

}
