using api_project.api.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace api_project.api.Data
{
    public class ApiProjectDBContext : DbContext
    {
        public ApiProjectDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
