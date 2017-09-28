using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;
using SimpleTaskSystem.Vehicles;

namespace SimpleTaskSystem.EntityFramework
{
    public class SimpleTaskSystemDbContext : AbpDbContext
    {
        public virtual IDbSet<Vehicle> Vehicles { get; set; }
        public virtual IDbSet<VehicleDescription> VehicleDescription { get; set; }
        public virtual IDbSet<VehicleImage> VehicleImage { get; set; }

        public SimpleTaskSystemDbContext()
            : base("Default")
        {

        }

        public SimpleTaskSystemDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }

        //This constructor is used in tests
        public SimpleTaskSystemDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleImage>()
                    .HasRequired(i => i.Veiculo)
                    .WithMany(i => i.Images)
                    .HasForeignKey(i => i.VeiculoId);

            //modelBuilder.Entity<Vehicle>().HasOptional(e => e.TipoVeiculo);
        }
    }
}
