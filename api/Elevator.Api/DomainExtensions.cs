namespace Elevator.Api;

using Domain.Data;
using Model;

public static class DomainExtensions
{
    public static ElevatorModel ToModel(this Elevator elevator)
    {
        return new ElevatorModel
        {
            Id = elevator.Id,
            Location = elevator.Location.ToModel(),
            ManufacturerName = elevator.ManufacturerName,
            SerialNumber = elevator.SerialNumber,
            OpenStreetMapId = elevator.OpenStreetMapId,
            Properties = elevator.Properties,
            Operator = elevator.Operator.ToModel(),
            IsOperational = true // todo add actual logic
        };
    }

    public static GeoLocationModel? ToModel(this GeoLocation? location)
    {
        if (location == null)
            return null;

        return new GeoLocationModel
        {
            Id = location.Id,
            AddressText = location.AddressText,
            Geometry = CreateGeometry(location.Latitude, location.Longitude),
            OpenStreetMaPlaceId = location.OpenStreetMaPlaceId
        };
    }

    public static OperatorModel? ToModel(this Operator? @operator)
    {
        if (@operator == null)
            return null;
        
        return new OperatorModel
        {
            Id = @operator.Id,
            Name = @operator.Name,
            ContactEmail = @operator.ContactEmail,
            ContactPhone = @operator.ContactPhone
        };
    }

    private static GeometryModel CreateGeometry(double latitude, double longitude)
    {
        return new GeometryModel
        {
            Type = "Point",
            Coordinates = new[] { latitude, longitude }
        };
    }
}