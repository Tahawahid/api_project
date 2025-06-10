using api_project.api.Data;
using api_project.api.Model.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api_project.api.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly ApiProjectDBContext dBContext;

        public SQLWalkRepository(ApiProjectDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dBContext.Walks.AddAsync(walk);
            await dBContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dBContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dBContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Walk walk)
        {
            var existingWalk = await dBContext.Walks.FindAsync(walk.Id);
            if (existingWalk == null)
            {
                return null; 
            }
            existingWalk.Name = walk.Name;
            existingWalk.lenghtInKM = walk.lenghtInKM;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;
            await dBContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var exist = await dBContext.Walks.FindAsync(id);

            if (exist == null)
            {
                return null;
            }
            dBContext.Walks.Remove(exist);
            await dBContext.SaveChangesAsync();

            return exist;
        }
    }
}
