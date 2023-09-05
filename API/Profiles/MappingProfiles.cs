using Domain.Entities;
using AutoMapper;
using API.Dtos;
namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country,CountryDto>().ReverseMap();
    }
}