using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.Vehicles
{
    public class VehicleDescription : Entity
    {
        [Column("Codigo")]
        public override int Id { get; set; }

        public virtual string Nome { get; set; }
    }
}
