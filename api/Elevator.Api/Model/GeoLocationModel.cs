namespace Elevator.Api.Model;

public class GeoLocationModel
{
    public required Guid Id { get; init; }

    public required GeometryModel Geometry { get; init; }

    public required Guid? OpenStreetMaPlaceId { get; init; }
    public required string? AddressText { get; init; }
}