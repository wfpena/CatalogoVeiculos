using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SimpleTaskSystem.Vehicles.Dto;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace SimpleTaskSystem.Vehicles
{
    public class VehicleAppService : ApplicationService, IVehicleAppService
    {
        
        private readonly IVehicleRepository _VehicleRepository;
        private readonly IRepository<VehicleDescription> _vehicleDescriptionRepository;
        private readonly IRepository<VehicleImage> _vehicleImageRepository;
        //private readonly IRepository<Person> _personRepository;

        public VehicleAppService(IVehicleRepository VehicleRepository, IRepository<VehicleDescription> vehicleDescriptionRepository, IRepository<VehicleImage> vehicleImageRepository)
        {
            _VehicleRepository = VehicleRepository;
            _vehicleDescriptionRepository = vehicleDescriptionRepository;
            _vehicleImageRepository = vehicleImageRepository;
        }
        
        public VehicleDto GetVehicle(int id)
        {
            return Mapper.Map <VehicleDto> (_VehicleRepository.Get(id));
        }
        
        public void UpdateVehicle(VehicleDto input)
        {
            var imageList = new List<VehicleImage>();
            var temp = _VehicleRepository.Get(input.Id);
            temp.Placa = input.Placa;
            temp.Proprietario = input.Proprietario;
            temp.TipoVeiculo = input.TipoVeiculo;
            _VehicleRepository.Update(temp);
            //var vehicleDesc = _vehicleDescriptionRepository.Get(input.TipoVeiculo.Id);
            
            //var Vehicle = new Vehicle { Placa = input.Placa, Proprietario = input.Proprietario, TipoVeiculo = vehicleDesc };
            int id = input.Id;

            _vehicleImageRepository.Delete(x => x.VeiculoId == input.Id);

            foreach (var imagem in input.Imagens)
            {
                var img = new VehicleImage();
                img.Image = imagem;
                img.VeiculoId = id;
                img.Id = _vehicleImageRepository.InsertOrUpdateAndGetId(img);
                imageList.Add(img);
            }
            
        }

        public void CreateVehicle(VehicleDto input)
        {
            //var image = new VehicleImage();
            var imageList = new List<VehicleImage>();

            var vehicleDesc = _vehicleDescriptionRepository.Get(input.TipoVeiculo.Id);
            var Vehicle = new Vehicle { Placa = input.Placa, Proprietario = input.Proprietario, TipoVeiculo = vehicleDesc};
            int id = _VehicleRepository.InsertAndGetId(Vehicle);

            foreach (var imagem in input.Imagens)
            {
                var img = new VehicleImage();
                img.Image = imagem;
                img.VeiculoId = id;
                img.Id = _vehicleImageRepository.InsertAndGetId(img);
                imageList.Add(img);
            }

            Vehicle.Images = imageList;
            var temp = _VehicleRepository.Get(id);
            temp.Images = imageList;
            _VehicleRepository.Update(temp);                

        }

        public List<VehicleDto> GetAll()
        {
            var Vehicles = _VehicleRepository.GetAll().ToList();
            var images = _vehicleImageRepository.GetAll().ToList();

            return Mapper.Map <List<VehicleDto>> (Vehicles);
        }


        public void DeleteVehicle(int id)
        {
            var mainVehicle = _VehicleRepository.Get(id);
            _VehicleRepository.Delete(id);
        }

        public void DeleteAll()
        {
            var Vehicle = _VehicleRepository.GetAll();
        }

        public List<VehicleDescription> GetTypes()
        {
            var types = _vehicleDescriptionRepository.GetAll();
            return types.ToList();
        }

        

    }
}