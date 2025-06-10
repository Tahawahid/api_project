using api_project.api.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace api_project.api.Data
{
    public class ApiProjectDBContext : DbContext
    {
        public ApiProjectDBContext(DbContextOptions dbContextOptions):base(dbContextOptions){}

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed the data for Difficulties
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>
            {
                new Difficulty { Id = Guid.Parse("27d53c7c-4d97-422e-876a-6093659436f9"), Name = "Easy" },
                new Difficulty { Id = Guid.Parse("e9b4e741-b526-414a-96fd-fdc6d7d13e98"), Name = "Medium" },
                new Difficulty { Id = Guid.Parse("1f47584e-8a47-4ec9-8705-d95fba905964"), Name = "Hard" }
            };

            // Seed the data for Difficulties
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            // Seed the data for Regions

            var regions = new List<Regions>
            {
                new Regions { Id = Guid.Parse("b1c8f0d2-3e4f-4c5a-9b6d-7e8f9a0b1c2d"), Code = "REG001", Name = "North Region", RegionImageUrl = "https://example.com/north-region.jpg" },
                new Regions { Id = Guid.Parse("c2d3e4f5-6a7b-8c9d-a0b1-c2d3e4f5a6b7"), Code = "REG002", Name = "South Region", RegionImageUrl = "https://example.com/south-region.jpg" },
                new Regions { Id = Guid.Parse("d3e4f5a6-b7c8-d9e0-f1a2-b3c4d5e6f7a8"), Code = "REG003", Name = "East Region", RegionImageUrl = "https://example.com/east-region.jpg" },
                new Regions { Id = Guid.Parse("e4f5a6b7-c8d9-e0f1-a2b3-c4d5e6f7a8b9"), Code = "REG004", Name = "West Region", RegionImageUrl = "https://example.com/west-region.jpg" }
            };

            modelBuilder.Entity<Regions>().HasData(regions);
        }

    }
}
