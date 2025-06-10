using api_project.api.Model.Domain;
using api_project.api.Model.DTO;
using AutoMapper;

namespace api_project.api.Mappings
{
    public class AutoMapperClass : Profile
    {
        public AutoMapperClass()
        {
            CreateMap<Regions, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Regions>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Regions>().ReverseMap();
        }
    }
}
