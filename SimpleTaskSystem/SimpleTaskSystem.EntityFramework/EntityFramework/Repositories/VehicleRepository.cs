using Abp.EntityFramework;
using SimpleTaskSystem.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.EntityFramework.Repositories
{
    public class VehicleRepository : SimpleTaskSystemRepositoryBase<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(IDbContextProvider<SimpleTaskSystemDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
