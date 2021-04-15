using Microsoft.EntityFrameworkCore;

namespace Mvc2EfCodeFirst.Data
{
    public class DataInitializer
    {
        public void InitializeDatabase(ApplicationDbContext context)
        {
            context.Database.Migrate();
        }

    }
}