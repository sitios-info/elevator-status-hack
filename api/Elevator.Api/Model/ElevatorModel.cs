namespace Elevator.Api.Model;

public class ElevatorModel
{
    public required Guid Id { get; init; }

    public Guid? OpenStreetMapId { get; init; }

    public required Dictionary<string, string> Properties { get; init; }

    public required GeoLocationModel? Location { get; init; }
    
    public required string? ManufacturerName { get; init; }

    public required string? SerialNumber { get; init; }

    public required OperatorModel? Operator { get; init; }
}