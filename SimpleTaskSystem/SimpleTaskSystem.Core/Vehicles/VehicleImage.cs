using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.Vehicles
{
    public class VehicleImage : Entity
    {
        public virtual Vehicle Veiculo { get; set; }
        [ForeignKey("Veiculo")]
        public virtual int VeiculoId { get; set; }
        public virtual string Image { get; set; }
    }
}
