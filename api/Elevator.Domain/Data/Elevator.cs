
namespace Elevator.Domain.Data;

public class Elevator
{
    public Guid Id { get; set; }
    public Guid? OpenStreetMapId { get; set; }
    public Dictionary<string, string> Properties { get; set; } = null!;
    public GeoLocation Location { get; set; } = null!;
    public string ManufacturerName { get; set; }
    public string SerialNumber { get; set; }
    public Operator? Operator { get; set; }
    public List<OperationChangeEvent> Events { get; set; } = new();
    public MetaDataSourceInfo? MetaDataSourceInfo { get; set; }
}

public class GeoLocation
{
    public Guid Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public Guid? OpenStreetMaPlaceId { get; set; }
    public string? AddressText { get; set; }
}