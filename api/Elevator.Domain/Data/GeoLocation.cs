namespace Elevator.Domain.Data;

public class GeoLocation
{
    public Guid Id { get; init; }
    public required double Latitude { get; init; }
    public required double Longitude { get; init; }
    public Guid? OpenStreetMaPlaceId { get; init; }
    public string? AddressText { get; init; }
}