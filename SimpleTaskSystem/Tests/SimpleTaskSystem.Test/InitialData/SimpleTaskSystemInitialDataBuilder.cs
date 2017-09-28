using System.Data.Entity.Migrations;
using System.Linq;
using SimpleTaskSystem.EntityFramework;

namespace SimpleTaskSystem.Test.InitialData
{
    public class SimpleTaskSystemInitialDataBuilder
    {
        public void Build(SimpleTaskSystemDbContext context)
        {
            

            context.SaveChanges();
        }
    }
}
