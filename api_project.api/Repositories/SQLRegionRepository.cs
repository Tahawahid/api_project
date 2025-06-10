using api_project.api.Data;
using api_project.api.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace api_project.api.Repositories
{
    public class SQLRegionRepository : IRegionRepositories
    {
        private readonly ApiProjectDBContext dBContext;

        public SQLRegionRepository(ApiProjectDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        // GetAllRegionsAsync method to retrieve all regions
        public async Task<List<Regions>> GetAllRegionsAsync()
        {
            return await dBContext.Regions.ToListAsync();
        }

        // GetRegionByIdAsync method to retrieve a region by its ID
        public async Task<Regions?> GetRegionByIdAsync(Guid id)
        {
            return await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        // AddRegionAsync method to add a new region
        public async Task<Regions> AddRegionAsync(Regions region)
        {
            await dBContext.Regions.AddAsync(region);
            await dBContext.SaveChangesAsync();
            return region;
        }

        // UpdateRegionAsync method to update a region by its ID
        public async Task<Regions?> UpdateRegionAsync(Guid id, Regions region)
        {
            var regionExist = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionExist == null)
            {
                return null;
            }

            regionExist.Code = region.Code;
            regionExist.Name = region.Name;
            regionExist.RegionImageUrl = region.RegionImageUrl;
            await dBContext.SaveChangesAsync();
            return regionExist;
        }

        // DeleteRegionAsync method to delete a region by its ID
        public async Task<Regions?> DeleteRegionAsync(Guid id)
        {
            var region = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            
            dBContext.Regions.Remove(region);
            await dBContext.SaveChangesAsync();
            return region ?? throw new KeyNotFoundException("Region not found");
        }

    }
}
