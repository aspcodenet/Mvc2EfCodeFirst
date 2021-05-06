using System.Dynamic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mvc2EfCodeFirst.Data
{
    public class DataInitializer
    {
        public void InitializeDatabase(ApplicationDbContext context)
        {
            //context.Database.Migrate();
            SeedColors(context);

            context.SaveChanges();
        }

        private void SeedColors(ApplicationDbContext context)
        {
            if (!context.Colors.Any(r => r.Name == "Yellow" && r.IsMetallic == false))
                context.Colors.Add(new Color
                {
                    IsMetallic = false, Name="Yellow"
                });
            if (!context.Colors.Any(r => r.Name == "Green" && r.IsMetallic == false))
                context.Colors.Add(new Color
                {
                    IsMetallic = false,
                    Name = "Green"
                });
            if (!context.Colors.Any(r => r.Name == "Red" && r.IsMetallic == false))
                context.Colors.Add(new Color
                {
                    IsMetallic = false,
                    Name = "Red"
                });
        }
    }
}