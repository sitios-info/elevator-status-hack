
namespace Elevator.Domain.Data;

public class Elevator
{
    public Guid Id { get; init; }
    public Guid? OpenStreetMapId { get; init; }
    public Dictionary<string, string> Properties { get; init; } = new();
    public GeoLocation? Location { get; init; }
    public string? ManufacturerName { get; init; }
    public string? SerialNumber { get; init; }
    public Operator? Operator { get; init; }
    public required IEnumerable<OperationChangeEvent> Events { get; init; }
    public MetaDataSourceInfo? MetaDataSourceInfo { get; init; }
}