using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.Vehicles.Dto
{
    public class VehicleDto : EntityDto
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Proprietario { get; set; }
        public VehicleDescription TipoVeiculo { get; set; }
        public List<String> Imagens { get; set; }
        //public ICollection<NodeDto> ChildNodes { get; set; }
    }
}
