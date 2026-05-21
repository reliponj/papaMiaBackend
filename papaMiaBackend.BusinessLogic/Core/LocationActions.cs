using AutoMapper;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.Location;
using papaMiaBackend.Domain.Models.Location;

namespace papaMiaBackend.BusinessLogic.Core;

public class LocationActions
{
    protected readonly IMapper Mapper;
    protected readonly LocationContext Db;

    public LocationActions(IMapper mapper, LocationContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal List<LocationDto> GetAllLocationsActionExecution()
    {
        var entities = Db.Locations
            .OrderBy(l => l.Name)
            .ToList();
        return Mapper.Map<List<LocationDto>>(entities);
    }

    internal LocationDto? GetLocationByIdActionExecution(int id)
    {
        var entity = Db.Locations.FirstOrDefault(l => l.Id == id);
        if (entity is null)
            return null;

        return Mapper.Map<LocationDto>(entity);
    }

    internal LocationDto? CreateLocationActionExecution(LocationCreateDto dto)
    {
        if (!IsValidLocationInput(dto.Name, dto.Address, dto.PhoneNumber, dto.Worktime, dto.Latitude, dto.Longitude))
            return null;

        var entity = Mapper.Map<Location>(dto);
        ApplyFields(entity, dto.Name, dto.Address, dto.PhoneNumber, dto.Worktime, dto.Latitude, dto.Longitude, dto.ImageUrl);

        Db.Locations.Add(entity);
        Db.SaveChanges();
        return Mapper.Map<LocationDto>(entity);
    }

    internal LocationDto? UpdateLocationActionExecution(int id, LocationUpdateDto dto)
    {
        var entity = Db.Locations.FirstOrDefault(l => l.Id == id);
        if (entity is null)
            return null;

        if (!IsValidLocationInput(dto.Name, dto.Address, dto.PhoneNumber, dto.Worktime, dto.Latitude, dto.Longitude))
            return null;

        ApplyFields(entity, dto.Name, dto.Address, dto.PhoneNumber, dto.Worktime, dto.Latitude, dto.Longitude, dto.ImageUrl);

        Db.SaveChanges();
        return Mapper.Map<LocationDto>(entity);
    }

    internal bool DeleteLocationActionExecution(int id)
    {
        var entity = Db.Locations.FirstOrDefault(l => l.Id == id);
        if (entity is null)
            return false;

        Db.Locations.Remove(entity);
        Db.SaveChanges();
        return true;
    }

    private static bool IsValidLocationInput(
        string name,
        string address,
        string phoneNumber,
        string worktime,
        double latitude,
        double longitude)
    {
        if (!IsValidText(name, 2, 50))
            return false;
        if (!IsValidText(address, 5, 100))
            return false;
        if (!IsValidText(phoneNumber, 5, 20))
            return false;
        if (!IsValidText(worktime, 5, 100))
            return false;
        if (latitude is < -90 or > 90)
            return false;
        if (longitude is < -180 or > 180)
            return false;

        return true;
    }

    private static bool IsValidText(string value, int minLength, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        var length = value.Trim().Length;
        return length >= minLength && length <= maxLength;
    }

    private static void ApplyFields(
        Location entity,
        string name,
        string address,
        string phoneNumber,
        string worktime,
        double latitude,
        double longitude,
        string imageUrl)
    {
        entity.Name = name.Trim();
        entity.Address = address.Trim();
        entity.PhoneNumber = phoneNumber.Trim();
        entity.Worktime = worktime.Trim();
        entity.Latitude = latitude;
        entity.Longitude = longitude;
        entity.ImageUrl = imageUrl.Trim();
    }
}
