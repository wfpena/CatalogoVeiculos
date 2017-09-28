using System;
using Abp.Application.Services;
using SimpleTaskSystem.Vehicles.Dto;
using System.Collections.Generic;

namespace SimpleTaskSystem.Vehicles
{
    /// <summary>
    /// Defines an application service for <see cref="Task"/> operations.
    /// 
    /// It extends <see cref="IApplicationService"/>.
    /// Thus, ABP enables automatic dependency injection, validation and other benefits for it.
    /// 
    /// Application services works with DTOs (Data Transfer Objects).
    /// Service methods gets and returns DTOs.
    /// </summary>
    public interface IVehicleAppService : IApplicationService
    {
        List<VehicleDto> GetAll(); 
        VehicleDto GetVehicle(int id);

        void UpdateVehicle(VehicleDto input);
        void DeleteVehicle(int id);
        void CreateVehicle(VehicleDto input);
        void DeleteAll();

        List<VehicleDescription> GetTypes();
    }
}
