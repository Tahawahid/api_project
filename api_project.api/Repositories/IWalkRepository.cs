using api_project.api.Model.Domain;

namespace api_project.api.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> UpdateAsync(Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
