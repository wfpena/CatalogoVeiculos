using AutoMapper;
using SimpleTaskSystem.Vehicles;
using SimpleTaskSystem.Vehicles.Dto;
using System;
using System.Collections.Generic;

namespace SimpleTaskSystem
{
    internal static class DtoMappings
    {
        public static void Map(IMapperConfigurationExpression mapper)
        {
            
            mapper.CreateMap<VehicleDto, Vehicle>();
            mapper.CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.Imagens, opt => opt.MapFrom(src => src.Images));
            mapper.CreateMap<VehicleImage, String>().ConvertUsing(r => r.Image);
            mapper.CreateMap<List<VehicleImage>, List<String>>();
            //mapper.CreateMap<List<String>,List<VehicleImage>>();
        }
    }
}
