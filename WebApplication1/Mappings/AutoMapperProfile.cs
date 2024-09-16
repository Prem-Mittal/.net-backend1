using AutoMapper;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Mappings
{
    public class AutoMapperProfile : Profile    //This is a custom class that inherits from Profile, which is a class provided by AutoMapper.
    {
        //AutoMapper helps map data between objects
        public AutoMapperProfile()
        {
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto,Region>().ReverseMap();
            CreateMap<UpdateregionsRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDto,Walk>().ReverseMap();
            CreateMap<Walk, WalksDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
        }

    }
}
