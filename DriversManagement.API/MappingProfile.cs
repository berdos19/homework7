using AutoMapper;
using DriversManagement.API.DTOs;
using DriversManagement.API.Models;

namespace DriversManagement.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Driver, DriverDTO>()
            .ForMember(x => x.Name, cnf => cnf.MapFrom(x => x.FirstName))
            .ForMember(x => x.CategoryId, cnf => cnf.MapFrom(x => x.Category.Id))
            .ReverseMap();
    }
}