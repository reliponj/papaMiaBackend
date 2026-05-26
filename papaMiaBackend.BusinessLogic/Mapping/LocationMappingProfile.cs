using AutoMapper;
using papaMiaBackend.Domain.Entities.Location;
using papaMiaBackend.Domain.Models.Location;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class LocationMappingProfile : Profile
{
    public LocationMappingProfile()
    {
        CreateMap<Location, LocationDto>();
        CreateMap<LocationCreateDto, Location>()
            .ForMember(d => d.Id, o => o.Ignore());
        CreateMap<LocationUpdateDto, Location>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}
