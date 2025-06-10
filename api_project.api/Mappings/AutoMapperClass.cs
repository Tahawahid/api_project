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
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Regions>().ReverseMap();
            CreateMap<AddWalksRequestDto, Walk>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Regions>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

        }
    }
}
