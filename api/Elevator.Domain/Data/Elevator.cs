using NetTopologySuite.Geometries;

namespace Elevator.Domain.Data;

public class Elevator
{
    public Guid Id { get; set; }
    public Guid? OpenStreetMapId { get; set; }
    public Dictionary<string, string> Properties { get; set; } = null!;
    public GeoLocation Location { get; set; } = null!;
    public string ManufacturerName { get; set; }
    public string SerialNumber { get; set; }
}

public class GeoLocation
{
    public Point Location { get; set; } = null!;
    public Guid? OpenStreetMaPlaceId { get; set; }
    public string? AddressText { get; set; }
}