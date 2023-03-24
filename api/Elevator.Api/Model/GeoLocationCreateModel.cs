namespace Elevator.Api.Model;

using System.ComponentModel.DataAnnotations;

public class GeoLocationCreateModel
{
    public required GeometryCreateModel Geometry { get; init; }

    public Guid? OpenStreetMaPlaceId { get; init; }

    public string? AddressText { get; init; }
}