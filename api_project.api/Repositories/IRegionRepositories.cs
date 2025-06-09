using api_project.api.Model.Domain;

namespace api_project.api.Repositories
{
    public interface IRegionRepositories
    {
        Task<List<Regions>> GetAllRegionsAsync();
        Task<Regions?> GetRegionByIdAsync(Guid id);
        Task<Regions> AddRegionAsync(Regions region);
        Task<Regions> UpdateRegionAsync(Guid id,Regions region);
        Task<Regions> DeleteRegionAsync(Guid id);



    }
}
