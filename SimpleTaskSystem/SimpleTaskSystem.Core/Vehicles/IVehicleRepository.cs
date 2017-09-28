using System.Collections.Generic;
using Abp.Domain.Repositories;

namespace SimpleTaskSystem.Vehicles
{
    public interface IVehicleRepository : IRepository<Vehicle,int>
    {
       
    }
}
