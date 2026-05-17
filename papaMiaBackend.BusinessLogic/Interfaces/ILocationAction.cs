using papaMiaBackend.Domain.Models.Location;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface ILocationAction
{
    List<LocationDto> GetAllLocationsAction();
    LocationDto? GetLocationByIdAction(int id);
    LocationDto? CreateLocationAction(LocationCreateDto dto);
    LocationDto? UpdateLocationAction(int id, LocationUpdateDto dto);
    bool DeleteLocationAction(int id);
}
