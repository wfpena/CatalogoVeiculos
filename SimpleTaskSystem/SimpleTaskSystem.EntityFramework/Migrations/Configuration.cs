
namespace SimpleTaskSystem.Migrations
{
    using SimpleTaskSystem.Vehicles;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext context)
        {
            context.VehicleDescription.AddOrUpdate(x => x.Id,
                new VehicleDescription() { Id = 1, Nome = "Motocicleta" },
                new VehicleDescription() { Id = 2, Nome = "Automóvel" },
                new VehicleDescription() { Id = 3, Nome = "Microônibus" },
                new VehicleDescription() { Id = 4, Nome = "Ônibus" },
                new VehicleDescription() { Id = 5, Nome = "Caminhão" },
                new VehicleDescription() { Id = 6, Nome = "Caminhão-Trator" },
                new VehicleDescription() { Id = 7, Nome = "Caminhonete" }
            );
        }
    }
}
