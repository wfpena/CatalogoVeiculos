using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleTaskSystem.Vehicles
{
    [Table("Vehicles")]
    public class Vehicle : Entity
    {
        [Required]
        public virtual string Placa { get; set; }

        public virtual string Proprietario { get; set; }
        public virtual VehicleDescription TipoVeiculo { get; set; }
        [ForeignKey("TipoVeiculo")]
        public virtual int? Tipo { get; set; }

        public virtual ICollection<VehicleImage> Images { get; set; }
        //[ForeignKey("Images")]
       // public virtual int? ImageId { get; set; }
        
        //public virtual ICollection<Node> ChildNodes { get; set; }
    }
}
