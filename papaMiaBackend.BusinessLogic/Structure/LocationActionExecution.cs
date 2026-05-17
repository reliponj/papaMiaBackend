using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Location;

namespace papaMiaBackend.BusinessLogic.Structure;

public class LocationActionExecution : LocationActions, ILocationAction
{
    public LocationActionExecution(IMapper mapper, LocationContext db)
        : base(mapper, db)
    {
    }

    public List<LocationDto> GetAllLocationsAction()
    {
        return GetAllLocationsActionExecution();
    }

    public LocationDto? GetLocationByIdAction(int id)
    {
        return GetLocationByIdActionExecution(id);
    }

    public LocationDto? CreateLocationAction(LocationCreateDto dto)
    {
        return CreateLocationActionExecution(dto);
    }

    public LocationDto? UpdateLocationAction(int id, LocationUpdateDto dto)
    {
        return UpdateLocationActionExecution(id, dto);
    }

    public bool DeleteLocationAction(int id)
    {
        return DeleteLocationActionExecution(id);
    }
}
