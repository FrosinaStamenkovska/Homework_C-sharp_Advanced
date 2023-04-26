using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IRepairService
    {
        public void CheckVehicle(Vehicle vehicle);
        public void FixVehicle(Vehicle vehicle);
    }
}
